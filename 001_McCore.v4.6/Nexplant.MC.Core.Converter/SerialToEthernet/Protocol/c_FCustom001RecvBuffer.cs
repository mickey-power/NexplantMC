/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTcpRecvBuffer.cs
--  Creator         : mjkim
--  Create Date     : 2020.03.03
--  Description     : FAmate Converter FaSerialToEthernet TCP Receive Buffer Class
--  History         : Created by mjkim at 2020.03.03
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSerialToEthernet
{
    internal class FTcpRecvBuffer : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private List<byte> m_data = null;
        private bool m_isCompleted = true;
        // --
        private UInt32 m_length = 0;
        private byte[] m_bin = null;
        private FXmlNode m_fXmlMsg = null;
        private bool m_isParseSuccess = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTcpRecvBuffer(            
            )                       
        {
            m_data = new List<byte>();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FTcpRecvBuffer(
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
                    m_data = null;
                    m_bin = null;
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

        public bool isCompleted
        {
            get
            {
                try
                {
                    return m_isCompleted;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public UInt32 length
        {
            get
            {
                try
                {
                    return m_length;
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

        public byte[] bin
        {
            get
            {
                try
                {
                    return m_bin;
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

        public bool isParseSuccess
        {
            get
            {
                try
                {
                    return m_isParseSuccess;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FXmlNode fXmlMsg
        {
            get
            {
                try
                {
                    return m_fXmlMsg;
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

        public void init(
            )
        {
            try
            {
                m_length = 0;
                m_bin = null;
                m_fXmlMsg = null;
                m_isParseSuccess = false;
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

        public void clear(
            )
        {
            try
            {
                init();
                m_data.Clear();
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

        public void input(
            byte[] data
            )
        {
            try
            {
                m_data.AddRange(data);              
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

        public bool parse(
            )
        {
            int etxPtr = 0;
            int index = 0;

            try
            {
                if (m_data.Count == 0)
                {
                    m_isCompleted = true;
                    return false;
                }

                // --

                etxPtr = -1;
                while (index < m_data.Count)
                {
                    etxPtr = m_data.IndexOf((byte)0x0A, index);
                    if (etxPtr == -1)
                    {
                        break;
                    }
                    // --
                    if (etxPtr + 1 < m_data.Count && (byte)m_data[etxPtr + 1] == 0x0A)
                    {
                        break;
                    }
                    index = etxPtr + 1;
                }
                // --
                if (etxPtr == -1)
                {
                    m_isCompleted = false;
                    return false;
                }

                // --

                // ***
                // 01234 5 6789
                // ABCD\n\n 
                // ***
                m_length = (UInt32)etxPtr + 2;
                m_bin = m_data.GetRange(0, etxPtr).ToArray();

                // --

                // ***
                // Etx(0x0A, 0x0A)를 포함한 데이터 제거
                // ***
                m_data.RemoveRange(0, etxPtr + 2);
                m_isCompleted = true;
                return true;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
