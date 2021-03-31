/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSerialPluginConfig.cs
--  Creator         : mjkim
--  Create Date     : 2019.09.23
--  Description     : FAmate Converter FaSerialToEthernet Serial Configuration Class
--  History         : Created by mjkim at 2019.09.23
----------------------------------------------------------------------------------------------------------*/
using System;
using System.IO.Ports;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSerialToEthernet
{
    public class FSerialPluginConfig: IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSerialToEthernet m_fSerialToTcp = null;
        // --
        private string m_serialPort = "COM1";
        private int m_baud = 9600;
        private StopBits m_stopBits = StopBits.One;
        private int m_dataBits = 8;
        private Parity m_parity = Parity.None;
        private byte[] m_prefix = null;
        private byte[] m_suffix = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FSerialPluginConfig(
            FSerialToEthernet fSerialToEthernet
            )
        {
            m_fSerialToTcp = fSerialToEthernet;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSerialPluginConfig(
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
                    m_fSerialToTcp = null;
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

        public StopBits stopBits
        {
            get
            {
                try
                {
                    return m_stopBits;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return StopBits.One;
            }

            set
            {
                try
                {
                    validateState();
                    // --
                    m_stopBits = value;
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

        public int dataBits
        {
            get
            {
                try
                {
                    return m_dataBits;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 8;
            }

            set
            {
                try
                {
                    validateState();
                    // --
                    m_dataBits = value;
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

        public Parity parity
        {
            get
            {
                try
                {
                    return m_parity;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return Parity.None;
            }

            set
            {
                try
                {
                    validateState();
                    // --
                    m_parity = value;
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

        public byte[] prefix
        {
            get
            {
                try
                {
                    return m_prefix;
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

            set
            {
                try
                {
                    m_prefix = value;
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

        public byte[] suffix
        {
            get
            {
                try
                {
                    return m_suffix;
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

            set
            {
                try
                {
                    m_suffix = value;
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
                if (m_fSerialToTcp.fSerialState != FCommunicationState.Closed)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0027, "COM Port"));
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
