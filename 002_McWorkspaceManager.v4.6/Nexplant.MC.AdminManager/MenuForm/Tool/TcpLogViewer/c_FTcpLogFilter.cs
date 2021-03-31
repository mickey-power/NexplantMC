/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FTcpLogFilter.cs
--  Creator         : baehyun.seo
--  Create Date     : 2012.05.01
--  Description     : FAMate Admin Manager TCP Log Filter Class
--  History         : Created by baehyun.seo at 2012.05.01
----------------------------------------------------------------------------------------------------------*/
using System;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.AdminManager
{
    public class FTcpLogFilter : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private bool m_enabledEventsOfTcpDeviceState = true;
        private bool m_enabledEventsOfTcpDeviceError = true;
        private bool m_enabledEventsOfTcpDeviceTimeout = true;
        private bool m_enabledEventsOfTcpDeviceData = false;
        private bool m_enabledEventsOfTcpDeviceXlg = false;
        private bool m_enabledEventsOfTcpDeviceDataMessage = true;
        // --
        private bool m_enabledEventsOfHostDeviceState = true;
        private bool m_enabledEventsOfHostDeviceError = true;
        private bool m_enabledEventsOfHostDeviceVfei = false;
        private bool m_enabledEventsOfHostDeviceDataMessage = true;
        // --
        private bool m_enabledEventsOfScenario = true;
        // --
        private bool m_enabledEventsOfApplication = true;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTcpLogFilter(
            )
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpLogFilter(
            FTcpLogFilter fFilter
            )
        {
            if (fFilter == null)
            {
                return;
            }

            // -- 

            m_enabledEventsOfTcpDeviceState = fFilter.enabledEventsOfTcpDeviceState;
            m_enabledEventsOfTcpDeviceError = fFilter.enabledEventsOfTcpDeviceError;
            m_enabledEventsOfTcpDeviceTimeout = fFilter.enabledEventsOfTcpDeviceTimeout;
            m_enabledEventsOfTcpDeviceData = fFilter.enabledEventsOfTcpDeviceData;
            m_enabledEventsOfTcpDeviceXlg = fFilter.enabledEventsOfTcpDeviceXlg;
            m_enabledEventsOfTcpDeviceDataMessage = fFilter.enabledEventsOfTcpDeviceDataMessage;
            // --
            m_enabledEventsOfHostDeviceState = fFilter.enabledEventsOfHostDeviceState;
            m_enabledEventsOfHostDeviceError = fFilter.enabledEventsOfHostDeviceError;
            m_enabledEventsOfHostDeviceVfei = fFilter.enabledEventsOfHostDeviceVfei;
            m_enabledEventsOfHostDeviceDataMessage = fFilter.enabledEventsOfHostDeviceDataMessage;
            // --
            m_enabledEventsOfScenario = fFilter.enabledEventsOfScenario;
            // --
            m_enabledEventsOfApplication = fFilter.enabledEventsOfApplication;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FTcpLogFilter(
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
                if(disposing)
                {
                    //term();
                }

                m_disposed = true;
            }            
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region IDisposable 맴버

        public void Dispose(
            )
        {
            myDispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public bool enabledEventsOfTcpDeviceState
        {
            get
            {
                try
                {
                    return m_enabledEventsOfTcpDeviceState;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    
                }
                return false;
            }

            set
            {
                try
                {
                    m_enabledEventsOfTcpDeviceState = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }        

        //------------------------------------------------------------------------------------------------------------------------

        public bool enabledEventsOfTcpDeviceError
        {
            get
            {
                try
                {
                    return m_enabledEventsOfTcpDeviceError;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_enabledEventsOfTcpDeviceError = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool enabledEventsOfTcpDeviceTimeout
        {
            get
            {
                try
                {
                    return m_enabledEventsOfTcpDeviceTimeout;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_enabledEventsOfTcpDeviceTimeout = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool enabledEventsOfTcpDeviceData
        {
            get
            {
                try
                {
                    return m_enabledEventsOfTcpDeviceData;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_enabledEventsOfTcpDeviceData = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool enabledEventsOfTcpDeviceXlg
        {
            get
            {
                try
                {
                    return m_enabledEventsOfTcpDeviceXlg;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_enabledEventsOfTcpDeviceXlg = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool enabledEventsOfTcpDeviceDataMessage
        {
            get
            {
                try
                {
                    return m_enabledEventsOfTcpDeviceDataMessage;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_enabledEventsOfTcpDeviceDataMessage = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }

        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool enabledEventsOfHostDeviceState
        {
            get
            {
                try
                {
                    return m_enabledEventsOfHostDeviceState;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_enabledEventsOfHostDeviceState = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool enabledEventsOfHostDeviceError
        {
            get
            {
                try
                {
                    return m_enabledEventsOfHostDeviceError;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_enabledEventsOfHostDeviceError = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool enabledEventsOfHostDeviceVfei
        {
            get
            {
                try
                {
                    return m_enabledEventsOfHostDeviceVfei;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_enabledEventsOfHostDeviceVfei = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool enabledEventsOfHostDeviceDataMessage
        {
            get
            {
                try
                {
                    return m_enabledEventsOfHostDeviceDataMessage;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_enabledEventsOfHostDeviceDataMessage = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool enabledEventsOfScenario
        {
            get
            {
                try
                {
                    return m_enabledEventsOfScenario;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_enabledEventsOfScenario = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool enabledEventsOfApplication
        {
            get
            {
                try
                {
                    return this.m_enabledEventsOfApplication;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    this.m_enabledEventsOfApplication = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }
                
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
