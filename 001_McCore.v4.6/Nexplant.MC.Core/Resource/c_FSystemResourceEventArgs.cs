/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSystemResourceEventArgs.cs
--  Creator         : mj.kim
--  Create Date     : 2011.09.15
--  Description     : FAMate Core FaCommon System Resource Data Received Event Arguments Class
--  History         : Created by mj.kim at 2011.09.15
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    public class FSystemResourceEventArgs : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private string m_cpu = string.Empty;
        private double m_cpuUsage = 0;
        private double m_memory = 0;
        private double m_memoryFreeSize = 0;
        private FLogicalDiskCollection m_fLogicalDiskCol = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSystemResourceEventArgs(
            string cpu,
            double cpuUsage,
            double memory,
            double memoryFreeSize,
            FLogicalDiskCollection fLogicalDiskCol
            )
        {
            m_cpu = cpu;
            m_cpuUsage = cpuUsage;
            m_memory = memory;
            m_memoryFreeSize = memoryFreeSize;
            m_fLogicalDiskCol = fLogicalDiskCol;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSystemResourceEventArgs(
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
                    m_fLogicalDiskCol = null;
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
                try
                {
                    return m_cpuUsage;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
