/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSerialData.cs
--  Creator         : mjkim
--  Create Date     : 2019.09.25
--  Description     : FAmate Converter FaSerialToEthernet Serial Recveived Data Class
--  History         : Created by mjkim at 2019.09.25
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSerialToEthernet
{
    public class FSerialPluginRecvData: IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSerialToEthernet m_fSerialToEthernet = null;
        // --
        private List<byte> m_data = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FSerialPluginRecvData(
            FSerialToEthernet fSerialToEthernet,
            byte[] data
            )
        {
            m_fSerialToEthernet = fSerialToEthernet;
            // --
            m_data = new List<byte>(data);
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSerialPluginRecvData(
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
                    m_fSerialToEthernet = null;
                    m_data = null;              
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

        public UInt32 length
        {
            get
            {
                try
                {
                    return (UInt32)(10 + m_data.Count);
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

        public byte[] data
        {
            get
            {
                try
                {
                    return m_data.ToArray();
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

        public string dataToString
        {
            get
            {
                try
                {
                    return Encoding.Default.GetString(m_data.ToArray());
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        internal FSerialPluginRecvData clone(
            )
        {
            try
            {
                return new FSerialPluginRecvData(
                    m_fSerialToEthernet, 
                    m_data.ToArray()
                    );
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

        //------------------------------------------------------------------------------------------------------------------------

        internal byte[] getTcpBinaryData(
            bool lengthInclude
            )
        {
            byte[] binData = null;
            UInt32 length = 0;
            int pos = 0;

            try
            {
                length = this.length;

                // --

                if (lengthInclude)
                {
                    binData = new byte[length + 4];

                    // --

                    // ***
                    // Length
                    // ***
                    Buffer.BlockCopy(FByteConverter.getBytes(length, true), 0, binData, pos, 4);
                    pos += 4;
                }
                else
                {
                    binData = new byte[length];
                }                

                // --

                // ***
                // Body
                // ***
                if (m_data.Count > 0)
                {
                    Buffer.BlockCopy(m_data.ToArray(), 0, binData, pos, m_data.Count);
                }

                // --

                return binData;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
