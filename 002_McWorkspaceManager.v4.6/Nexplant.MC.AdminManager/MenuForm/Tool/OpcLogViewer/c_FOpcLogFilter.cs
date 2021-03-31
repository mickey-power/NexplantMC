/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FOpcLogFilter.cs
--  Creator         : mjkim
--  Create Date     : 2015.08.03
--  Description     : FAMate Admin Manager OPC Log Filter Class
--  History         : Created by mjkim at 2015.08.03
----------------------------------------------------------------------------------------------------------*/
using System;
using Nexplant.MC.Core.FaCommon;
//using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.Core.FaUIs;
using System.IO;

namespace Nexplant.MC.AdminManager
{
    public class FOpcLogFilter : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private bool m_enabledFilterOfOpcDeviceState = true;
        private bool m_enabledFilterOfOpcDeviceError = true;
        private bool m_enabledFilterOfOpcDeviceTimeout = true;
        private bool m_enabledFilterOfOpcDeviceDataMessage = true;
        // --
        private bool m_enabledFilterOfHostDeviceState = true;
        private bool m_enabledFilterOfHostDeviceError = true;
        private bool m_enabledFilterOfHostDeviceDataMessage = true;
        // --
        private bool m_enabledFilterOfScenario = true;
        // --
        private bool m_enabledFilterOfApplication = true;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FOpcLogFilter(
            )
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOpcLogFilter(
            FOpcLogFilter fFilter
            )
        {
            if (fFilter == null)
            {
                return;
            }

            // --

            m_enabledFilterOfOpcDeviceState = fFilter.enabledFilterOfOpcDeviceState;
            m_enabledFilterOfOpcDeviceError = fFilter.enabledFilterOfOpcDeviceError;
            m_enabledFilterOfOpcDeviceTimeout = fFilter.enabledFilterOfOpcDeviceTimeout;
            m_enabledFilterOfOpcDeviceDataMessage = fFilter.enabledFilterOfOpcDeviceDataMessage;
            // --
            m_enabledFilterOfHostDeviceState = fFilter.enabledFilterOfHostDeviceState;
            m_enabledFilterOfHostDeviceError = fFilter.enabledFilterOfHostDeviceError;
            m_enabledFilterOfHostDeviceDataMessage = fFilter.enabledFilterOfHostDeviceDataMessage;
            // --
            m_enabledFilterOfScenario = fFilter.enabledFilterOfScenario;
            // --
            m_enabledFilterOfApplication = fFilter.enabledFilterOfApplication;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FOpcLogFilter(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    
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

        public bool enabledFilterOfOpcDeviceState
        {
            get
            {
                try
                {
                    return m_enabledFilterOfOpcDeviceState;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return true;
            }

            set
            {
                try
                {
                    m_enabledFilterOfOpcDeviceState = value;
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

        public bool enabledFilterOfOpcDeviceError
        {
            get
            {
                try
                {
                    return m_enabledFilterOfOpcDeviceError;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return true;
            }

            set
            {
                try
                {
                    m_enabledFilterOfOpcDeviceError = value;
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

        public bool enabledFilterOfOpcDeviceTimeout
        {
            get
            {
                try
                {
                    return m_enabledFilterOfOpcDeviceTimeout;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return true;
            }

            set
            {
                try
                {
                    m_enabledFilterOfOpcDeviceTimeout = value;
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

        public bool enabledFilterOfOpcDeviceDataMessage
        {
            get
            {
                try
                {
                    return m_enabledFilterOfOpcDeviceDataMessage;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return true;
            }

            set
            {
                try
                {
                    m_enabledFilterOfOpcDeviceDataMessage = value;
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
        
        public bool enabledFilterOfHostDeviceState
        {
            get
            {
                try
                {
                    return m_enabledFilterOfHostDeviceState;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return true;
            }

            set
            {
                try
                {
                    m_enabledFilterOfHostDeviceState = value;
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

        public bool enabledFilterOfHostDeviceError
        {
            get
            {
                try
                {
                    return m_enabledFilterOfHostDeviceError;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return true;
            }

            set
            {
                try
                {
                    m_enabledFilterOfHostDeviceError = value;
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

        public bool enabledFilterOfHostDeviceDataMessage
        {
            get
            {
                try
                {
                    return m_enabledFilterOfHostDeviceDataMessage;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return true;
            }

            set
            {
                try
                {
                    m_enabledFilterOfHostDeviceDataMessage = value;
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

        public bool enabledFilterOfScenario
        {
            get
            {
                try
                {
                    return m_enabledFilterOfScenario;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return true;
            }

            set
            {
                try
                {
                    m_enabledFilterOfScenario = value;
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

        public bool enabledFilterOfApplication
        {
            get
            {
                try
                {
                    return m_enabledFilterOfApplication;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return true;
            }

            set
            {
                try
                {
                    m_enabledFilterOfApplication = value;
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