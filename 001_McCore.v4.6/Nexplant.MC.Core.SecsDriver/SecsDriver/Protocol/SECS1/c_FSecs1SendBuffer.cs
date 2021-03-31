/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecs1SendBuffer.cs
--  Creator         : byungyun.jeon
--  Create Date     : 2011.11.16
--  Description     : FAMate Core FaSecsDriver SECS-I Send Buffer Class 
--  History         : Created by byungyun.jeon at 2011.11.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;
using System.Collections;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal class FSecs1SendBuffer : IDisposable
    {
        
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private const int MAX_BODY_SIZE = 244;
        // --
        private bool m_rbit = false;
        private UInt16 m_sessionId = 0;
        private byte m_byte2 = 0;
        private byte m_byte3 = 0;
        private UInt32 m_systemBytes = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecs1SendBuffer(
            )
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSecs1SendBuffer(
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

        public List<byte[]> genBlocks(
            bool rbit,
            UInt16 sessionId,
            int stream,
            int function,
            bool wbit,
            UInt32 systemBytes,
            ArrayList body
            )
        {
            int i;
            int cursor = 0;
            int messageLength = 0;
            int blockBodySize = 0;
            int blockNo = 0;
            byte[] tmpBytes = null;
            // -- 
            UInt16 checksum = 0;
            bool ebit = false;
            byte[] binBody = null;
            byte[] block = null;
            // --
            List<byte[]> blockList = null;

            try
            {

                m_rbit = rbit;
                m_sessionId = sessionId;
                m_byte2 = (byte)(stream | (wbit ? 0x80 : 0x00));
                m_byte3 = (byte)function;
                m_systemBytes = systemBytes;
                //--
                blockList = new List<byte[]>();

                // --

                // ***
                // Generate Blocks
                // ***
                cursor = 0;
                blockNo = 1;

                // --

                if (body != null)
                {
                    binBody = (byte[])body.ToArray(typeof(byte));
                    messageLength = binBody.Length;
                }
                else
                {
                    binBody = null;
                    messageLength = 0;
                }

                do
                {
                    if (messageLength > cursor + MAX_BODY_SIZE)
                    {
                        blockBodySize = MAX_BODY_SIZE;
                        ebit = false;
                    }
                    else if (messageLength == cursor + MAX_BODY_SIZE)
                    {
                        blockBodySize = MAX_BODY_SIZE;
                        ebit = true;
                    }
                    else if (messageLength != 0)
                    {
                        blockBodySize = binBody.Length - cursor;
                        ebit = true;
                    }
                    else if (messageLength == 0)
                    {
                        blockBodySize = 0;
                        ebit = true;
                    }
                    
                    // --

                    block = new byte[1 + 10 + blockBodySize + 2];

                    // ***
                    // block length (header + bodySize)
                    // ***
                    block[0] = (byte)(10 + blockBodySize);

                    // ***
                    // masking block header 
                    // ***
                    tmpBytes = FByteConverter.getBytes(sessionId, true);
                    block[1] = (byte)((int)tmpBytes[0] | (rbit ? 0x80 : 0x00));
                    block[2] = tmpBytes[1];
                    block[3] = (byte)(stream | (wbit ? 0x80 : 0x00));
                    block[4] = (byte)function;

                    tmpBytes = FByteConverter.getBytes((UInt16)blockNo, true);
                    block[5] = (byte)((int)tmpBytes[0] | (ebit ? 0x80 : 0x00));
                    block[6] = tmpBytes[1];

                    Buffer.BlockCopy(FByteConverter.getBytes(systemBytes, true), 0, block, 7, 4);

                    // ***
                    // masking block body
                    // ***
                    if (blockBodySize != 0)
                    {
                        Buffer.BlockCopy(binBody, cursor, block, 11, blockBodySize);
                    }

                    // ***
                    // masking checksum
                    // ***
                    checksum = 0;
                    for (i = 1; i <= 10 + blockBodySize; i++)
                    {
                        checksum += (UInt16)block[i];
                    }
                    Buffer.BlockCopy(FByteConverter.getBytes(checksum, true), 0, block, 11 + blockBodySize, 2);

                    blockList.Add(block);
                    
                    // --
                    
                    cursor += blockBodySize;
                    blockNo++;

                } while (cursor < messageLength);

                // --

                return blockList;
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
        
        public byte[] genEOT(
            )
        {
            byte[] eot = null;

            try
            {
                eot = new byte[1];
                eot[0] = (byte)FSecs1HandshakeCode.EOT;

                // -- 

                return eot;
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

        public byte[] genENQ(
            )
        {
            byte[] enq = null;

            try
            {
                enq = new byte[1];
                enq[0] = (byte)FSecs1HandshakeCode.ENQ;

                // --

                return enq;
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

        public byte[] genACK(
            )
        {
            byte[] ack = null;

            try
            {
                ack = new byte[1];
                ack[0] = (byte)FSecs1HandshakeCode.ACK;

                 // --

                return ack;
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

        public byte[] genNAK(
            )
        {
            byte[] nak = null;

            try
            {
                nak = new byte[1];
                nak[0] = (byte)FSecs1HandshakeCode.NAK;

                // --

                return nak;
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