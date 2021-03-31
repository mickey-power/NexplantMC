/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecs1Config.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.06
--  Description     : FAmate Converter FaSecs1ToHsms Configuration of SECS1 Class
--  History         : Created by spike.lee at 2017.04.06
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecs1ToHsms
{
    public class FSecs1Config: IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSecs1ToHsms m_fSecs1ToHsms = null;
        // --
        private UInt16 m_sessionId = 0;
        private string m_serialPort = "COM1";
        private int m_baud = 9600;
        private bool m_rbit = false;
        private bool m_interleave = true;
        private bool m_duplicateError = true;
        private bool m_ignoreSystemBytes = false;
        private int m_retryLimit = 3;
        // --
        private float m_t1Timeout = 0.5f;
        private float m_t2Timeout = 10;
        private int m_t3Timeout = 45;
        private int m_t4Timeout = 45;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FSecs1Config(
            FSecs1ToHsms fSecs1ToHsms
            )
        {
            m_fSecs1ToHsms = fSecs1ToHsms;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSecs1Config(
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

        public UInt16 sessionId
        {
            get
            {
                try
                {
                    return m_sessionId;
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
                    m_sessionId = value;
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

        public string serialPort
        {
            get
            {
                try
                {
                    return m_serialPort;
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
                    validateState();
                    // --
                    if (value.Trim() == string.Empty)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Serial Port"));
                    }
                    // --
                    m_serialPort = value;
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

        public int baud
        {
            get
            {
                try
                {
                    return m_baud;
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
                    validateState();
                    // --
                    if (value < 1)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Baud"));
                    }
                    // --
                    m_baud = value;
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

        public bool rbit
        {
            get
            {
                try
                {
                    return m_rbit;
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
                    validateState();
                    // --
                    m_rbit = value;
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

        public bool interleave
        {
            get
            {
                try
                {
                    return m_interleave;
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
                    validateState();
                    // --
                    m_interleave = value;
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

        public bool duplicateError
        {
            get
            {
                try
                {
                    return m_duplicateError;
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
                    validateState();
                    // --
                    m_duplicateError = value;
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

        public bool ignoreSystemBytes
        {
            get
            {
                try
                {
                    return m_ignoreSystemBytes;
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
                    validateState();
                    // --
                    m_ignoreSystemBytes = value;
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

        public int retryLimit
        {
            get
            {
                try
                {
                    return m_retryLimit;
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
                    validateState();
                    // --
                    if (value < 0 || value > 31)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Retry Limit"));
                    }
                    // --
                    m_retryLimit = value;
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

        public float t1Timeout
        {
            get
            {
                try
                {
                    return m_t1Timeout;
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
                    validateState();
                    // --
                    if (value < 0.1F || value > 10.0F)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "T1 Timeout"));
                    }
                    // --
                    m_t1Timeout = value;
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

        public float t2Timeout
        {
            get
            {
                try
                {
                    return m_t2Timeout;
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
                    validateState();
                    // --
                    if (value < 0.2F || value > 25.0F)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "T2 Timeout"));
                    }
                    // --
                    m_t2Timeout = value;
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

        public int t3Timeout
        {
            get
            {
                try
                {
                    return m_t3Timeout;
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
                    validateState();
                    // --
                    if (value < 1 || value > 120)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "T3 Timeout"));
                    }
                    // --
                    m_t3Timeout = value;
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

        public int t4Timeout
        {
            get
            {
                try
                {
                    return m_t4Timeout;
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
                    validateState();
                    // --
                    if (value < 1 || value > 120)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "T4 Timeout"));
                    }
                    // --
                    m_t4Timeout = value;
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

        private void validateState(
            )
        {
            try
            {
                if (m_fSecs1ToHsms.fSecs1State != FCommunicationState.Closed)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0027, "SECS1 Port"));
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
