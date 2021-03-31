/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSystemResourceCollector.cs
--  Creator         : mj.kim
--  Create Date     : 2011.09.06
--  Description     : FAMate Core FaCommon System Resource Collector Class
--  History         : Created by mj.kim at 2011.09.06
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.IO;

namespace Nexplant.MC.Core.FaCommon
{
    public class FSystemResourceCollector : IDisposable 
    {
        //------------------------------------------------------------------------------------------------------------------------

        public event FSystemResourceEventHandler ResourceDataReceived = null;

        private bool m_disposed = false;
        // --
        private FThread m_fThdPusher = null;
        private FStaticTimer m_fTmrPusher = null;
        private ManagementScope m_scope = null;
        private PerformanceCounter m_perfCounter = null;
        // --
        private string m_cpu = string.Empty;
        private List<double> m_cpuUsageList = null;
        private double m_memory = double.NaN;
        private double m_memoryFreeSize = double.NaN;
        private FLogicalDiskCollection m_fLogicalDiskCol = null;
        // --
        private int m_interval = 0;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSystemResourceCollector(
            )
        {
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSystemResourceCollector(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    term();
                    // --
                    m_scope = null;
                    m_perfCounter = null;
                    m_fLogicalDiskCol = null;
                    m_cpuUsageList = null;
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region IDisposable 멤버

        public void Dispose(
            )
        {
            myDispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public string cpu
        {
            get
            {
                try
                {
                    return m_cpu;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }
        }
    
        //------------------------------------------------------------------------------------------------------------------------

        public double cpuUsage
        {
            get
            {
                double usage = 0;
                try
                {
                    if (m_cpuUsageList.Count > 0)
                    {
                        usage = m_cpuUsageList.Average();
                    }
                    return usage;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0;
            }
        }


        //------------------------------------------------------------------------------------------------------------------------

        public double memory
        {
            get
            {
                try
                {
                    return m_memory;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    
                }
                return 0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public double memoryFreeSize
        {
            get
            {
                try
                {
                    return m_memoryFreeSize;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    
                }
                return 0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FLogicalDiskCollection logicalDiskCol
        {
            get
            {
                try
                {
                    return m_fLogicalDiskCol;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    
                }
                return null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            try
            {
                m_scope = new ManagementScope("root\\CIMV2");
                m_perfCounter = new PerformanceCounter();
                m_perfCounter.CategoryName = "Processor Information";
                m_perfCounter.CounterName = (Environment.OSVersion.Version.Major >= 6 && Environment.OSVersion.Version.Minor > 1) ?
                    "% Processor Utility" : // Windows 2012
                    "% Processor Time";
                m_perfCounter.InstanceName = "_Total";

                // --

                m_cpuUsageList = new List<double>();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void term(
            )
        {
            try
            {
                if (m_fThdPusher != null)
                {
                    m_fThdPusher.ThreadJobCalled -= new FThreadJobCalledEventHandler(m_fThdPusher_ThreadJobCalled);
                    // --
                    m_fThdPusher.stop();
                    m_fThdPusher.Dispose();
                    m_fThdPusher = null;
                }

                // --

                if (m_fTmrPusher != null)
                {
                    m_fTmrPusher.Dispose();
                    m_fThdPusher = null;
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procSysResourcePush(
            )
        {
            try
            {
                getSystemReresource();

                // --

                if (ResourceDataReceived != null)
                {
                    ResourceDataReceived(
                        this,
                        new FSystemResourceEventArgs(this.cpu, this.cpuUsage, this.memory, this.memoryFreeSize, this.logicalDiskCol)
                        );
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void startEventHandler(
            int interval
            )
        {
            try
            {
                m_interval = interval;

                // --

                term();

                // --

                m_fThdPusher = new FThread("PResourcePushThread", false, System.Threading.ThreadPriority.Normal, true);
                m_fThdPusher.ThreadJobCalled += new FThreadJobCalledEventHandler(m_fThdPusher_ThreadJobCalled);
                m_fThdPusher.start();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void stopEventHandler(
            )
        {
            try
            {
                term();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void getSystemReresource(
            )
        {
            ManagementObjectSearcher searcher = null;
            // --
            Dictionary<string, FLogicalDisk> diskDict = null;
            List<FLogicalDisk> diskList = null;
            
            try
            {
                // --

                #region Cpu

                // ***
                // Cpu
                // ***
                searcher = new ManagementObjectSearcher(
                        m_scope,
                        new SelectQuery("SELECT Name FROM Win32_Processor")
                        );
                foreach (ManagementObject mo in searcher.Get())
                {
                    m_cpu = mo["Name"].ToString();
                    break;
                }

                // --

                // ***
                // Cpu Usage (%)
                // ***
                m_cpuUsageList.Add(Convert.ToDouble(m_perfCounter.NextValue()));
                //searcher = new ManagementObjectSearcher(
                //    m_scope,
                //    new SelectQuery("SELECT PercentProcessorTime FROM Win32_PerfFormattedData_PerfOS_Processor WHERE Name = '_Total'")
                //    );
                //foreach (ManagementObject mo in searcher.Get())
                //{
                //    m_cpuUsageList.Add(Convert.ToDouble(mo["PercentProcessorTime"]));
                //    break;
                //}

                #endregion

                // --

                #region Memroy

                // ***
                // Total Memory Size (Mb)
                // ***
                searcher = new ManagementObjectSearcher(
                    m_scope,
                    new SelectQuery("SELECT TotalPhysicalMemory FROM Win32_ComputerSystem")
                    );
                foreach (ManagementObject mo in searcher.Get())
                {
                    m_memory = Convert.ToDouble(mo["TotalPhysicalMemory"]) / (1024 * 1024);
                    break;
                }

                // --

                // ***
                // Free Memory Size (Mb)
                // ***
                searcher = new ManagementObjectSearcher(
                    m_scope,
                    new SelectQuery("SELECT AvailableBytes FROM Win32_PerfFormattedData_PerfOS_Memory")
                    );
                foreach (ManagementObject mo in searcher.Get())
                {
                    m_memoryFreeSize = Convert.ToDouble(mo["AvailableBytes"]) / (1024 * 1024);
                    break;
                }

                #endregion

                // --

                #region Logical Disk

                // ***
                // All Logical Disk Size & FreeSize (Mb)
                // ***
                diskDict = new Dictionary<string, FLogicalDisk>();
                diskList = new List<FLogicalDisk>();

                // --

                searcher = new ManagementObjectSearcher(
                    m_scope,
                    new SelectQuery("SELECT deviceID,FreeSpace,Size FROM Win32_LogicalDisk WHERE DriveType = 3")
                    );
                foreach (ManagementObject mo in searcher.Get())
                {
                    FLogicalDisk fDisk = new FLogicalDisk(mo["deviceID"].ToString());
                    // --
                    fDisk.freeSpace = Convert.ToDouble(mo["FreeSpace"]) / (1024 * 1024);
                    fDisk.size = Convert.ToDouble(mo["Size"]) / (1024 * 1024);
                    // --
                    if (!diskDict.ContainsKey(fDisk.devceId))
                    {
                        diskDict.Add(fDisk.devceId, fDisk);
                        diskList.Add(fDisk);
                    }
                }

                m_fLogicalDiskCol = (new FLogicalDiskCollection(diskDict, diskList));

                #endregion
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                searcher = null;
                diskDict = null;
                diskList = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fDataPusher Object Event Handler

        private void m_fThdPusher_ThreadJobCalled(
            object sender,
            FThreadEventArgs e
            )
        {
            try
            {
                if (m_fTmrPusher == null)
                {
                    m_fTmrPusher = new FStaticTimer();
                    #if (DEBUG)
                    m_fTmrPusher.start(1000);
                    #else
                    m_fTmrPusher.start(m_interval * 60 * 1000);
                    #endif
                    return;
                }

                // --

                if (!m_fTmrPusher.elasped(true))
                {
                    e.sleepThread(1);
                    return;
                }

                // --

                procSysResourcePush();

                // --

                e.sleepThread(10);                
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);

                // --

                e.sleepThread(1000);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end    
}   // Namespace end
