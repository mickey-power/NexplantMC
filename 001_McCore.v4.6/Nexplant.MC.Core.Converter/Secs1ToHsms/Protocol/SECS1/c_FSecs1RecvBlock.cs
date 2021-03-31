/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecs1RecvBlock.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.10
--  Description     : FAmate Converter FaSecs1ToHsms SECS1 Recveived Block Class
--  History         : Created by spike.lee at 2017.04.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecs1ToHsms
{
    internal class FSecs1RecvBlock: IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private byte m_length = 0;
        private List<byte> m_blockData = null;
        // --
        private bool m_rbit = false;
        private UInt16 m_sessionId = 0;
        private bool m_wbit = false;
        private byte m_stream = 0;
        private byte m_function = 0;
        private bool m_ebit = false;
        private UInt16 m_blockNo = 0;
        private UInt32 m_systemBytes = 0;
        private List<byte> m_body = null;
        private UInt16 m_checkSum = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecs1RecvBlock(
            byte length
            )
        {
            m_length = length;
            m_blockData = new List<byte>();
            m_blockData.Add(m_length);
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSecs1RecvBlock(
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
                    m_blockData = null;
                    m_body = null;
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

        public byte length
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

        public byte[] blockData
        {
            get
            {
                try
                {
                    return m_blockData.ToArray();
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

        public int blockDataLength
        {
            get
            {
                try
                {
                    return m_blockData.Count;
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

        public bool blockDataCollectionCompleted
        {
            get
            {
                try
                {
                    return this.calculateNeedLength() == 0 ? true : false;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool wbit
        {
            get
            {
                try
                {
                    return m_wbit;
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

        public byte stream
        {
            get
            {
                try
                {
                    return m_stream;
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

        public byte function
        {
            get
            {
                try
                {
                    return m_function;
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

        public bool ebit
        {
            get
            {
                try
                {
                    return m_ebit;
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

        public UInt16 blockNo
        {
            get
            {
                try
                {
                    return m_blockNo;
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

        public UInt32 systemBytes
        {
            get
            {
                try
                {
                    return m_systemBytes;
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

        public byte[] body
        {
            get
            {
                try
                {
                    return m_body.ToArray();
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

        public UInt16 checkSum
        {
            get
            {
                try
                {
                    return m_checkSum;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public int calculateNeedLength(
            )
        {
            try
            {
                return this.length - this.blockDataLength + 1 + 2;    // Length와 CheckSum 포함
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

        //------------------------------------------------------------------------------------------------------------------------

        public void input(
            byte[] blockData
            )
        {
            try
            {
                m_blockData.AddRange(blockData);
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

        public void parse(
            )
        {
            try
            {
                m_rbit = (m_blockData[1] & 0x80) == 0 ? false : true;
                m_sessionId = BitConverter.ToUInt16(new byte[] { m_blockData[2], (byte)(m_blockData[1] & 0x7F) }, 0);
                m_wbit = (m_blockData[3] & 0x80) == 0 ? false : true;
                m_stream = (byte)(m_blockData[3] & 0x7F);
                m_function = m_blockData[4];
                m_ebit = (m_blockData[5] & 0x80) == 0 ? false : true;
                m_blockNo = BitConverter.ToUInt16(new byte[] { m_blockData[6], (byte)(m_blockData[5] & 0x7F) }, 0);
                m_systemBytes = BitConverter.ToUInt32(new byte[] { m_blockData[10], m_blockData[9], m_blockData[8], m_blockData[7] }, 0);
                // --
                m_body = new List<byte>();
                if (length > 10)
                {
                    m_body.AddRange(m_blockData.GetRange(11, length - 10));
                }
                // --
                m_checkSum = BitConverter.ToUInt16(new byte[] { m_blockData[m_length + 2], m_blockData[m_length + 1] }, 0);
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

        public bool validateCheckSum(
            )
        {
            UInt16 sum = 0;

            try
            {
                for (int i = 1; i < m_blockData.Count - 2; i++)
                {
                    sum += m_blockData[i];
                }
                return sum == m_checkSum ? true : false;
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

        //------------------------------------------------------------------------------------------------------------------------

        public bool validateRbit(
            bool rbit
            )
        {
            try
            {
                return m_rbit == rbit ? false : true;
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

        //------------------------------------------------------------------------------------------------------------------------

        public bool validateSessionId(UInt16 sessionId)
        {
            try
            {
                return m_sessionId == sessionId ? true : false;
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
