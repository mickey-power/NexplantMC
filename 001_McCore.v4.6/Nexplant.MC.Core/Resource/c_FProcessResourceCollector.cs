/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FProcessResourceCollector.cs
--  Creator         : mj.kim
--  Create Date     : 2011.09.05
--  Description     : FAMate Core FaCommon Process Resource Collector Class
--  History         : Created by mj.kim at 2011.09.05
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    public class FProcessResourceCollector : IDisposable 
    {

        //------------------------------------------------------------------------------------------------------------------------

        public event FProcessResourceEventHandler ResourceDataReceived = null;

        private bool m_disposed = false;
        // --
        private FThread m_fThdPusher = null;
        private FStaticTimer m_fTmrPusher = null;
        private ManagementScope m_scope = null;
        // --
        private Dictionary<string, FProcessResource> m_fProcResDict = null;
        // --
        private string m_appliedDirPath = string.Empty;
        private int m_interval = 0;    
 
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FProcessResourceCollector(
            string appliedDirPath
            )
        {
            m_appliedDirPath = appliedDirPath;

            // --

            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FProcessResourceCollector(
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
                    m_fProcResDict = null;
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

        //------------------------------------------------------------------------------------------------------------------------

        public FProcessResourceCollection procResCol
        {
            get
            {
                FProcessResourceCollection fProcResCol = null;

                try
                {
                    if (m_fProcResDict != null)
                    {
                        fProcResCol = new FProcessResourceCollection(m_fProcResDict, m_fProcResDict.Values.ToList());
                    }

                    return fProcResCol;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    fProcResCol = null;
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
                try
                {
                    m_scope = new ManagementScope("root\\CIMV2");
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

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

                m_fThdPusher = new FThread("ProcessResourcePushThread", false, System.Threading.ThreadPriority.Normal, true);
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

        private void procProcessResourcePush(
            )
        {
            try
            {
                getProcessResource();

                // --

                if (ResourceDataReceived != null)
                {
                    ResourceDataReceived(
                        this,
                        new FProcessResourceEventArgs(this.procResCol)
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

        public void getProcessResource(
            )
        {
            ManagementObjectSearcher searcher = null;
            // --
            DirectoryInfo dirInfo = null;
            string[] processList = null;
            string[] dirList = null;
            string processName = string.Empty;
            long porcessDiskUsage = 0;

            try
            {

                // ***
                // All Process Resource : Cpu(%), Memory(Mb), Disk(Mb)
                // ***
                if (m_fProcResDict == null)
                {
                    m_fProcResDict = new Dictionary<string, FProcessResource>();
                }
                                                                                
                // --

                if (!Directory.Exists(m_appliedDirPath))
                {
                    m_fProcResDict.Clear();
                    return;
                }

                // --

                // ***
                // 삭제된 Eap는 수집 목록에서 제거한다.
                processList = m_fProcResDict.Keys.ToArray();
                foreach (string process in processList)
                {
                    if (!Directory.Exists(
                        Path.Combine(new string[] { m_appliedDirPath, process })
                        ))
                    {
                        m_fProcResDict.Remove(process);
                    }
                }
                                
                // --

                // ***
                // Applied Directory에서 삭제되지 않은 Eap Directory 목록을 가져온다.
                // **
                dirList = Directory.GetDirectories(m_appliedDirPath).Where(name => !name.Contains("@")).ToArray();
                if (dirList.Length == 0)
                {
                    m_fProcResDict.Clear();
                    return;
                }

                // ***
                // Process 목록을 생성하고, Disk 사용량을 구한다.
                // ***
                foreach (string dir in dirList)
                {
                    processName = dir.Split(Path.DirectorySeparatorChar).Last();

                    // Eap Disk Size : Directory의 전체 File Size를 합산
                    dirInfo = new DirectoryInfo(dir);
                    porcessDiskUsage = dirInfo.EnumerateFiles("*.*", SearchOption.AllDirectories).Sum(f => f.Length);
                    
                    // --

                    // 이전에 수집된 정보가 있는지 확인.
                    if (!m_fProcResDict.ContainsKey(processName))
                    {
                        FProcessResource fProcRes = new FProcessResource(processName);
                        // --
                        fProcRes.diskUsage = Convert.ToDouble(porcessDiskUsage) / (1024 * 1024);
                        m_fProcResDict.Add(processName, fProcRes);
                    }
                    else
                    {
                        m_fProcResDict[processName].diskUsage = Convert.ToDouble(porcessDiskUsage) / (1024 * 1024);
                    }
                }
                
                // --

                // ***
                // 실행중인 Process의 Cpu, Memory 사용량을 구한다.
                // ***
                searcher = new ManagementObjectSearcher(
                       m_scope,
                       new SelectQuery("SELECT Name, PercentProcessorTime, WorkingSetPrivate FROM Win32_PerfFormattedData_PerfProc_Process")
                       );
                foreach (ManagementObject mo in searcher.Get())
                {
                    if (m_fProcResDict.ContainsKey(mo["Name"].ToString()))
                    {
                        m_fProcResDict[mo["Name"].ToString()].cpuUsage = Convert.ToDouble(mo["PercentProcessorTime"]) / Environment.ProcessorCount;
                        m_fProcResDict[mo["Name"].ToString()].memoryUsage = Convert.ToDouble(mo["WorkingSetPrivate"]) / (1024 * 1024);
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                searcher = null;
                dirInfo = null;
                dirList = null;
                processList = null;
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

                procProcessResourcePush();

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
