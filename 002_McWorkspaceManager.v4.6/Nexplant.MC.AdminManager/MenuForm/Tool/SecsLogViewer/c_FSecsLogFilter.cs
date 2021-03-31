/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FSecsLogFilter.cs
--  Creator         : baehyun.seo
--  Create Date     : 2012.05.01
--  Description     : FAMate Admin Manager SECS Log Filter Class
--  History         : Created by baehyun.seo at 2012.05.01
----------------------------------------------------------------------------------------------------------*/
using System;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.AdminManager
{
    public class FSecsLogFilter : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private bool m_enabledEventsOfSecsDeviceState = true;
        private bool m_enabledEventsOfSecsDeviceError = true;
        private bool m_enabledEventsOfSecsDeviceTimeout = true;
        private bool m_enabledEventsOfSecsDeviceTelnet = false;
        private bool m_enabledEventsOfSecsDeviceHandshake = false;
        private bool m_enabledEventsOfSecsDeviceControlMessage = true;
        private bool m_enabledEventsOfSecsDeviceBlock = false;
        private bool m_enabledEventsOfSecsDeviceDataMessage = true;
        // --
        private bool m_enabledEventsOfHostDeviceState = true;
        private bool m_enabledEventsOfHostDeviceError = true;
        private bool m_enabledEventsOfHostDeviceDataMessage = true;
        // --
        private bool m_enabledEventsOfScenario = true;
        // --
        private bool m_enabledEventsOfApplication = true;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecsLogFilter(
            )
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsLogFilter(
            FSecsLogFilter fFilter
            )
        {
            if (fFilter == null)
            {
                return;
            }

            // -- 

            m_enabledEventsOfSecsDeviceState = fFilter.enabledEventsOfSecsDeviceState;
            m_enabledEventsOfSecsDeviceError = fFilter.enabledEventsOfSecsDeviceError;
            m_enabledEventsOfSecsDeviceTimeout = fFilter.enabledEventsOfSecsDeviceTimeout;
            m_enabledEventsOfSecsDeviceTelnet = fFilter.enabledEventsOfSecsDeviceTelnet;
            m_enabledEventsOfSecsDeviceHandshake = fFilter.enabledEventsOfSecsDeviceHandshake;
            m_enabledEventsOfSecsDeviceControlMessage = fFilter.enabledEventsOfSecsDeviceControlMessage;
            m_enabledEventsOfSecsDeviceBlock = fFilter.enabledEventsOfSecsDeviceBlock;
            m_enabledEventsOfSecsDeviceDataMessage = fFilter.enabledEventsOfSecsDeviceDataMessage;
            // --
            m_enabledEventsOfHostDeviceState = fFilter.enabledEventsOfHostDeviceState;
            m_enabledEventsOfHostDeviceError = fFilter.enabledEventsOfHostDeviceError;
            m_enabledEventsOfHostDeviceDataMessage = fFilter.enabledEventsOfHostDeviceDataMessage;
            // --
            m_enabledEventsOfScenario = fFilter.enabledEventsOfScenario;
            // --
            m_enabledEventsOfApplication = fFilter.enabledEventsOfApplication;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSecsLogFilter(
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

        public bool enabledEventsOfSecsDeviceState
        {
            get
            {
                try
                {
                    return m_enabledEventsOfSecsDeviceState;
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
                    m_enabledEventsOfSecsDeviceState = value;
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

        public bool enabledEventsOfSecsDeviceError
        {
            get
            {
                try
                {
                    return m_enabledEventsOfSecsDeviceError;
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
                    m_enabledEventsOfSecsDeviceError = value;
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

        public bool enabledEventsOfSecsDeviceTimeout
        {
            get
            {
                try
                {
                    return m_enabledEventsOfSecsDeviceTimeout;
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
                    m_enabledEventsOfSecsDeviceTimeout = value;
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

        public bool enabledEventsOfSecsDeviceTelnet
        {
            get
            {
                try
                {
                    return m_enabledEventsOfSecsDeviceTelnet;
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
                    m_enabledEventsOfSecsDeviceTelnet = value;
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

        public bool enabledEventsOfSecsDeviceHandshake
        {
            get
            {
                try
                {
                    return m_enabledEventsOfSecsDeviceHandshake;
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
                    m_enabledEventsOfSecsDeviceHandshake = value;
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

        public bool enabledEventsOfSecsDeviceControlMessage
        {
            get
            {
                try
                {
                    return m_enabledEventsOfSecsDeviceControlMessage;
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
                    m_enabledEventsOfSecsDeviceControlMessage = value;
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

        public bool enabledEventsOfSecsDeviceBlock
        {
            get
            {
                try
                {
                    return m_enabledEventsOfSecsDeviceBlock;
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
                    m_enabledEventsOfSecsDeviceBlock = value;
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

        public bool enabledEventsOfSecsDeviceDataMessage
        {
            get
            {
                try
                {
                    return m_enabledEventsOfSecsDeviceDataMessage;
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
                    m_enabledEventsOfSecsDeviceDataMessage = value;
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
