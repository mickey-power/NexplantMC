/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FBaseHsms.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.11
--  Description     : FAmate Converter FaSecs1ToHsms HSMS Base Protocol Class
--  History         : Created by spike.lee at 2017.04.11
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecs1ToHsms
{
    internal abstract class FBaseHsms : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSecs1ToHsms m_fSecs1ToHsms = null;
        private FIDPointer32 m_fSystemBytesPointer = null;
        private string m_localIp = string.Empty;
        private int m_localPort = 0;
        private string m_remoteIp = string.Empty;
        private int m_remotePort = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FBaseHsms(            
            FSecs1ToHsms fSecs1ToHsms
            )
        {
            m_fSecs1ToHsms = fSecs1ToHsms;
            m_fSystemBytesPointer = new FIDPointer32();
            // --
            m_localIp = m_fSecs1ToHsms.fHsmsConfig.localIp;
            m_localPort = m_fSecs1ToHsms.fHsmsConfig.localPort;
            m_remoteIp = m_fSecs1ToHsms.fHsmsConfig.remoteIp;
            m_remotePort = m_fSecs1ToHsms.fHsmsConfig.remotePort;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FBaseHsms(
           )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected virtual void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    if (m_fSystemBytesPointer != null)
                    {
                        m_fSystemBytesPointer.Dispose();
                        m_fSystemBytesPointer = null;
                    }
                    m_fSecs1ToHsms = null;
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

        public FSecs1ToHsms fSecs1ToHsms
        {
            get
            {
                try
                {
                    return m_fSecs1ToHsms;
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

        //------------------------------------------------------------------------------------------------------------------------

        public FIDPointer32 fSystemBytesPointer
        {
            get
            {
                try
                {
                    return m_fSystemBytesPointer;
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

        //------------------------------------------------------------------------------------------------------------------------

        public string localIp
        {
            get
            {
                try
                {
                    return m_localIp;
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

            set
            {
                try
                {
                    m_localIp = value;
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

        public int localPort
        {
            get
            {
                try
                {
                    return m_localPort;
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

            set
            {
                try
                {
                    m_localPort = value;
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

        public string remoteIp
        {
            get
            {
                try
                {
                    return m_remoteIp;
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

            set
            {
                try
                {
                    m_remoteIp = value;
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

        public int remotePort
        {
            get
            {
                try
                {
                    return m_remotePort;
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

            set
            {
                try
                {
                    m_remotePort = value;
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

        public abstract void open(
            );

        //------------------------------------------------------------------------------------------------------------------------

        public abstract void close(
            );

        //------------------------------------------------------------------------------------------------------------------------

        public abstract void send(
            FSecsDataMessage fSecsDataMessage
            );

        //------------------------------------------------------------------------------------------------------------------------

        public string getSelectStatusMessage(
            byte status
            )
        {
            try
            {
                if (status == 0)
                {
                    return string.Empty;
                }
                else if (status == 1)
                {
                    return FConstants.err_m_12001;
                }
                else if (status == 2)
                {
                    return FConstants.err_m_12002;
                }
                else if (status == 3)
                {
                    return FConstants.err_m_12003;
                }
                else if (status < 128)
                {
                    return FConstants.err_m_12004;
                }
                return FConstants.err_m_12128;
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

        //------------------------------------------------------------------------------------------------------------------------

        public string getDeselectStatusMessage(
            int status
            )
        {
            try
            {
                if (status == 0)
                {
                    return string.Empty;
                }
                else if (status == 1)
                {
                    return FConstants.err_m_14001;
                }
                else if (status == 2)
                {
                    return FConstants.err_m_14002;
                }
                else if (status < 128)
                {
                    return FConstants.err_m_14003;
                }
                return FConstants.err_m_14128;
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

        //------------------------------------------------------------------------------------------------------------------------

        public string getRejectReasonMessage(
            int reasonCode
            )
        {
            try
            {
                if (reasonCode == 0)
                {
                    return string.Empty;
                }
                else if (reasonCode == 1)
                {
                    return FConstants.err_m_17001;
                }
                else if (reasonCode == 2)
                {
                    return FConstants.err_m_17002;
                }
                else if (reasonCode == 3)
                {
                    return FConstants.err_m_17003;
                }
                else if (reasonCode == 4)
                {
                    return FConstants.err_m_17004;
                }
                else if (reasonCode < 128)
                {
                    return FConstants.err_m_17128;
                }
                return FConstants.err_m_14128;
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

        //------------------------------------------------------------------------------------------------------------------------
                
        public string getTimeoutMessage(
            FSecsTimeout fTimeout
            )
        {
            try
            {
                if (fTimeout == FSecsTimeout.T3)
                {
                    return FConstants.err_m_20003;
                }
                else if (fTimeout == FSecsTimeout.T5)
                {
                    return FConstants.err_m_20005;
                }
                else if (fTimeout == FSecsTimeout.T6)
                {
                    return FConstants.err_m_20006;
                }
                else if (fTimeout == FSecsTimeout.T7)
                {
                    return FConstants.err_m_20007;
                }
                else if (fTimeout == FSecsTimeout.T8)
                {
                    return FConstants.err_m_20008;
                }
                return string.Empty;
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

        //------------------------------------------------------------------------------------------------------------------------

        public string getTimeoutDescription(
            FSecsTimeout fTimeout
            )
        {
            try
            {
                if (fTimeout == FSecsTimeout.T3)
                {
                    return FConstants.err_m_21003;
                }
                else if (fTimeout == FSecsTimeout.T5)
                {
                    return FConstants.err_m_21005;
                }
                else if (fTimeout == FSecsTimeout.T6)
                {
                    return FConstants.err_m_21006;
                }
                else if (fTimeout == FSecsTimeout.T7)
                {
                    return FConstants.err_m_21007;
                }
                else if (fTimeout == FSecsTimeout.T8)
                {
                    return FConstants.err_m_21008;
                }
                return string.Empty;
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
         
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
