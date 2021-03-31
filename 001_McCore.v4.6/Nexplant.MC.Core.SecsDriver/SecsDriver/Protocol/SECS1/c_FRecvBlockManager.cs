/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FRecvBlockManager.cs
--  Creator         : byungyun.jeon
--  Create Date     : 2011.12.15
--  Description     : FAMate Core FaSecsDriver SECS-I Receive Block Manager Class 
--  History         : Created by byungyun.jeon at 2011.11.22
----------------------------------------------------------------------------------------------------------*/
using System;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal class FRecvBlockManager : FBaseBlockManager
    {
        
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;        
        // --
        private UInt16 m_justRecvBlockNo = 0;        
        private FStaticTimer m_fTmrT4 = null;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FRecvBlockManager(
            byte[] block
            )
            : base()
        {
            m_fTmrT4 = new FStaticTimer();
            m_justRecvBlockNo = 0;

            init(block);
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FRecvBlockManager(
            bool rbit,
            UInt16 sessionId,
            bool wbit,
            int stream,
            int function,
            UInt32 systemBytes
            )
            : base()
        {
            m_fTmrT4 = new FStaticTimer();
            m_justRecvBlockNo = 0;

            init(rbit, sessionId, wbit, stream, function, systemBytes);
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FRecvBlockManager(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    if (m_fTmrT4 != null)
                    {
                        m_fTmrT4.Dispose();
                        m_fTmrT4 = null;
                    }
                }
                m_disposed = true;
            }
            // --
            base.myDispose(disposing);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------
        
        #region Properties

        public UInt16 justRecvBlockNo
        {
            get
            {
                try
                {
                    return m_justRecvBlockNo;
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

        public override bool isCompleted
        {
            get
            {
                try
                {
                    if (m_blockList == null)
                    {
                        return false;
                    }

                    if (m_blockList.Count == 0)
                    {
                        return false;
                    }

                    // --

                    return (new FBlockInfo(m_blockList[m_blockList.Count - 1])).ebit;
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
        
        public FStaticTimer fTmrT4
        {
            get
            {
                try
                {
                    return m_fTmrT4;
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

        public override byte[] body
        {
            get
            {
                int cursor;
                int blockLength;
                byte[] body = null;

                try
                {
                    if (isCompleted)
                    {
                        body = new byte[bodyLength];

                        // -- 

                        cursor = 0;
                        foreach (byte[] b in m_blockList)
                        {
                            blockLength = b[0] - 10;
                            Buffer.BlockCopy(b, 11, body, cursor, blockLength);

                            cursor += blockLength;
                        }
                    }
                    return body;
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

        public override byte[] message
        {
            get
            {
                int cursor;
                int blockLength;
                byte[] message = null;

                try
                {
                    if (isCompleted)
                    {
                        message = new byte[bodyLength + 10];

                        // -- 

                        Buffer.BlockCopy(FByteConverter.getBytes(sessionId, true), 0, message, 0, 2);
                        message[2] = (byte)(stream | (wbit ? 0x80 : 0x00));
                        message[3] = (byte)function;
                        message[4] = 0;
                        message[5] = 0;
                        Buffer.BlockCopy(FByteConverter.getBytes(systemBytes, true), 0, message, 6, 4);

                        // -- 

                        cursor = 10;
                        foreach (byte[] b in m_blockList)
                        {
                            blockLength = b[0] - 10;
                            Buffer.BlockCopy(b, 11, message, cursor, blockLength);

                            cursor += blockLength;
                        }
                    }
                    return message;
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

        public override UInt32 length
        {
            get
            {
                byte[] message = null;
                try
                {
                    message = this.message;
                    if (message != null)
                    {
                        return (UInt32)message.Length;
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    message = null;
                }
                return 0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override int bodyLength
        {
            get
            {
                int bodyLength;

                try
                {
                    bodyLength = 0;
                    foreach (byte[] b in m_blockList)
                    {
                        bodyLength += (int)(b[0] - 10);
                    }
                    return bodyLength;
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

        public int blockCount
        {
            get
            {
                try
                {
                    return m_blockList.Count;
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
                
        public void addBlock(
            Byte[] block
            )
        {
            try            
            {
                m_blockList.Add(block);
                m_justRecvBlockNo = (new FBlockInfo(block)).blockNo;
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