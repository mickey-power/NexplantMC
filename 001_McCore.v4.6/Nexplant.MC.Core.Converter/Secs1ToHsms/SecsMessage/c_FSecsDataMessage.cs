/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecsDataMessage.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.10
--  Description     : FAmate Converter FaSecs1ToHsms SECS Data Message Class
--  History         : Created by spike.lee at 2017.04.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecs1ToHsms
{
    public class FSecsDataMessage: IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSecs1ToHsms m_fSecs1ToHsms = null;
        // --
        private UInt16 m_sessionId = 0;
        private bool m_wbit = false;
        private byte m_stream = 0;
        private byte m_function = 0;
        private UInt32 m_systemBytes = 0;
        private List<byte> m_body = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FSecsDataMessage(
            FSecs1ToHsms fSecs1ToHsms,
            UInt16 sessionId,
            bool wbit,
            byte stream,
            byte function,
            UInt32 systemBytes,
            byte[] body
            )
        {
            m_fSecs1ToHsms = fSecs1ToHsms;
            // --
            m_sessionId = sessionId;
            m_wbit = wbit;
            m_stream = stream;
            m_function = function;
            m_systemBytes = systemBytes;
            m_body = new List<byte>(body);
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSecsDataMessage(
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        internal FSecsDataMessage clone(
            )
        {
            try
            {
                return new FSecsDataMessage(
                    m_fSecs1ToHsms, 
                    m_sessionId, 
                    m_wbit, 
                    m_stream, 
                    m_function, 
                    m_systemBytes, 
                    m_body.ToArray()
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

        internal byte[] getHsmsBinaryData(
            bool lengthInclude
            )
        {
            byte[] binData = null;
            UInt32 length = 0;
            byte byte2 = 0;
            byte byte3 = 0;
            byte ptype = 0;
            byte stype = 0;
            int pos = 0;

            try
            {
                length = this.length;
                byte2 = (byte)(stream | (wbit ? 0x80 : 0x00));
                byte3 = function;
                ptype = 0;
                stype = 0;

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
                // Header
                // ***
                Buffer.BlockCopy(FByteConverter.getBytes(m_sessionId, true), 0, binData, pos, 2);
                pos += 2;
                binData[pos++] = byte2;
                binData[pos++] = byte3;
                binData[pos++] = ptype;
                binData[pos++] = stype;
                Buffer.BlockCopy(FByteConverter.getBytes(m_systemBytes, true), 0, binData, pos, 4);
                pos += 4;

                // --

                // ***
                // Body
                // ***
                if (m_body.Count > 0)
                {
                    Buffer.BlockCopy(m_body.ToArray(), 0, binData, pos, m_body.Count);
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

        //------------------------------------------------------------------------------------------------------------------------

        internal FSecs1SendBlockList getSecs1SendBlockList(
            )
        {
            const int MAX_BODY_SIZE = 244;

            FSecs1SendBlockList fBlockList = null;
            FSecs1SendBlock fBlock = null;
            int blockCnt = 0;
            UInt16 blockNo = 0;
            bool ebit = false;
            byte[] body = null;
            int pos = 0;
            int copyLen = 0;

            try
            {
                fBlockList = new FSecs1SendBlockList(m_fSecs1ToHsms, this);

                // --

                // ***
                // 2017.04.21 by spike.lee
                // Body가 없을 경우 Header만 보내기 위해서 Block Cnt를 1로 설정한다.
                // ***
                if (m_body.Count == 0)
                {
                    blockCnt = 1;
                }
                else
                {
                    blockCnt = m_body.Count / MAX_BODY_SIZE;
                    blockCnt += (m_body.Count % MAX_BODY_SIZE > 0 ? 1 : 0);
                }

                // --

                for (int i = 0; i < blockCnt; i++)
                {
                    blockNo++;  // Block No.는 1부터

                    // --

                    // ***
                    // End Block 검사
                    // ***
                    if (i == blockCnt - 1)
                    {
                        ebit = true;
                        if (m_body.Count == 0)
                        {
                            copyLen = 0;
                        }
                        else
                        {
                            copyLen = m_body.Count % MAX_BODY_SIZE;
                            if (copyLen == 0)
                            {
                                copyLen = MAX_BODY_SIZE;
                            }
                        }                        
                    }
                    else
                    {
                        ebit = false; 
                        copyLen = MAX_BODY_SIZE;                         
                    }
                    // --

                    body = m_body.GetRange(pos, copyLen).ToArray();
                    pos += copyLen;

                    // --

                    fBlock = new FSecs1SendBlock(
                        fBlockList,
                        m_fSecs1ToHsms.fSecs1Config.rbit,
                        m_sessionId,
                        m_wbit,
                        m_stream,
                        m_function,
                        ebit,
                        blockNo,
                        systemBytes,
                        body
                        );
                    // --
                    fBlockList.addBlock(fBlock);
                }
                // --
                return fBlockList;
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

        public FXmlNode convertToXmlNode(
            )
        {
            try
            {
                return FSecsConverter.convertBinToXmlNode(m_sessionId, m_stream, m_function, m_wbit, m_systemBytes, m_body.ToArray());
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
