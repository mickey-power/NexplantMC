/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FHsmsSendBuffer.cs
--  Creator         : spike.lee
--  Create Date     : 2011.09.02
--  Description     : FAmate Converter FaSecs1ToHsms HSMS Send Buffer Class
--  History         : Created by spike.lee at 2011.09.02
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecs1ToHsms
{
    internal class FHsmsSendBuffer : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private UInt16 m_sessionId = 0;
        private byte m_byte2 = 0;
        private byte m_byte3 = 0;
        private byte m_ptype = 0;
        private byte m_stype = 0;
        private UInt32 m_systemBytes = 0;
        private List<byte> m_body = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FHsmsSendBuffer(            
            )                       
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FHsmsSendBuffer(
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
                    return (UInt32)(10 + m_body.Count);
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

        public byte byte2
        {
            get
            {
                try
                {
                    return m_byte2;
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
                    m_byte2 = value;
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

        public byte byte3
        {
            get
            {
                try
                {
                    return m_byte3;
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
                    m_byte3 = value;
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

        public byte ptype
        {
            get
            {
                try
                {
                    return m_ptype;
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
                    m_ptype = value;
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

        public byte stype
        {
            get
            {
                try
                {
                    return m_stype;
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
                    m_stype = value;
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

            set
            {
                try
                {
                    m_systemBytes = value;
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

            set
            {
                try
                {
                    if (value == null)
                    {
                        m_body.Clear();
                    }
                    else
                    {
                        m_body = new List<byte>(value);
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int stream
        {
            get
            {
                try
                {
                    return m_byte2 & 0x7F;
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

        public int function
        {
            get
            {
                try
                {
                    return m_byte3;
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
                    return (m_byte2 & 0x80) == 0x00 ? false : true;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public void init(
            )
        {
            try
            {
                m_sessionId = 0;
                m_byte2 = 0;
                m_byte3 = 0;
                m_ptype = 0;
                m_stype = 0;
                m_systemBytes = 0;
                m_body = new List<byte>();
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

        public void genDataMessage(
            UInt16 sessionId, 
            byte stream, 
            byte function, 
            bool wbit,
            UInt32 systemBytes,
            byte[] body
            )
        {
            try
            {
                m_sessionId = sessionId;
                m_byte2 = (byte)(stream | (wbit ? 0x80 : 0x00));
                m_byte3 = function;
                m_ptype = 0;
                m_stype = 0;
                m_systemBytes = systemBytes;
                // --
                if (body == null)
                {
                    m_body = new List<byte>();
                }
                else
                {
                    m_body = new List<byte>(body);
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

        //------------------------------------------------------------------------------------------------------------------------

        public void genSelectReq(
            UInt32 systemBytes
            )
        {
            try
            {
                m_sessionId = 0xFFFF;
                m_byte2 = 0;
                m_byte3 = 0;
                m_ptype = 0;
                m_stype = 1;
                m_systemBytes = systemBytes;
                m_body = new List<byte>();
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

        public void genSelectRsp(
            UInt16 sessionId,
            byte status,
            UInt32 systemBytes
            )
        {
            try
            {
                m_sessionId = sessionId;
                m_byte2 = 0;
                m_byte3 = status;
                m_ptype = 0;
                m_stype = 2;
                m_systemBytes = systemBytes;
                m_body = new List<byte>();
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

        public void genDeselectRsp(
            UInt16 sessionId,
            UInt32 systemBytes
            )
        {
            try
            {
                m_sessionId = sessionId;
                m_byte2 = 0;
                m_byte3 = 0;
                m_ptype = 0;
                m_stype = 4;
                m_systemBytes = systemBytes;
                m_body = new List<byte>();
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

        public void genLinktestReq(
            UInt32 systemBytes
            )
        {
            try
            {
                m_sessionId = 0xFFFF;
                m_byte2 = 0;
                m_byte3 = 0;
                m_ptype = 0;
                m_stype = 5;
                m_systemBytes = systemBytes;
                m_body = new List<byte>();
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

        public void genLinktestRsp(
            UInt16 sessionId,
            UInt32 systemBytes
            )
        {
            try
            {
                m_sessionId = sessionId;
                m_byte2 = 0;
                m_byte3 = 0;
                m_ptype = 0;
                m_stype = 6;
                m_systemBytes = systemBytes;
                m_body = new List<byte>();
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

        public void genRejectReq(
            UInt16 sessionId,
            byte stype,
            byte reasonCode,
            UInt32 systemBytes
            )
        {
            try
            {
                m_sessionId = 0xFFFF;
                m_byte2 = stype;
                m_byte3 = reasonCode;
                m_ptype = 0;
                m_stype = 7;
                m_systemBytes = systemBytes;
                m_body = new List<byte>();
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

        public void genSeparateReq(
            UInt32 systemBytes
            )
        {
            try
            {
                m_sessionId = 0xFFFF;
                m_byte2 = 0;
                m_byte3 = 0;
                m_ptype = 0;
                m_stype = 9;
                m_systemBytes = systemBytes;
                m_body = new List<byte>();
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

        public byte[] getBinaryData(
            )
        {
            UInt32 length = 0;            
            byte[] data = null;

            try
            {
                length = this.length;                
                data = new byte[length + 4];

                // --

                // ***
                // Length Copy
                // ***
                Buffer.BlockCopy(FByteConverter.getBytes(length, true), 0, data, 0, 4);

                // --

                // ***
                // Header Copy
                // ***
                Buffer.BlockCopy(FByteConverter.getBytes(m_sessionId, true), 0, data, 4, 2);
                data[6] = m_byte2;
                data[7] = m_byte3;
                data[8] = m_ptype;
                data[9] = m_stype;
                Buffer.BlockCopy(FByteConverter.getBytes(m_systemBytes, true), 0, data, 10, 4);                                

                // --

                // ***
                // Body
                // ***
                if (m_body.Count > 0)
                {
                    Buffer.BlockCopy(m_body.ToArray(), 0, data, 14, m_body.Count);
                }                

                // --

                return data;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                data = null;
            }
            return null;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
