/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSendBlockManager.cs
--  Creator         : byungyun.jeon
--  Create Date     : 2011.12.15
--  Description     : FAMate Core FaSecsDriver SECS-I Send Block Manager Class 
--  History         : Created by byungyun.jeon at 2011.11.22
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal class FSendBlockManager : FBaseBlockManager
    {
        
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private ArrayList m_body = null;
        private FSecsDeviceDataMessageSentLog m_fLog = null;        
        private int m_totalBlockCount = 0;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSendBlockManager(
            List<byte[]> blockList,
            ArrayList body,
            FSecsDeviceDataMessageSentLog fLog
            )
        {
            m_blockList = blockList;
            m_body = body;
            m_fLog = fLog;
            // -- 
            init(blockList[0]);
            m_totalBlockCount = m_blockList.Count;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSendBlockManager(
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

                }
                m_disposed = true;
            }
            // --
            base.myDispose(disposing);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties
                
        public override bool isCompleted
        {
            get
            {
                int numOfBlock = 0;
                
                try
                {                            
                    if (m_blockList != null)  
                    {
                        numOfBlock = 0;
                    }
                    else
                    {
                        numOfBlock = m_blockList.Count;
                    }
                    return (m_totalBlockCount == numOfBlock) ? true : false;
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

        public override byte[] body
        {
            get
            {
                try
                {
                    return m_body == null ? null : (byte[])m_body.ToArray(typeof(byte));
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
                byte[] message = null;

                try
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

                    // ***
                    // 2016.07.01 Jungyoul (WISOL)
                    // ***
                    if (bodyLength > 0)
                    {
                        Buffer.BlockCopy(body, 0, message, 10, bodyLength);
                    }

                    // --
                    
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
                try
                {
                    return (message != null) ? (UInt32) message.Length : 0;
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

        protected override int bodyLength
        {
            get
            {
                try
                {
                    return (body != null) ? body.Length : 0;
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

        public FSecsDeviceDataMessageSentLog fLog
        {
            get
            {
                try
                {
                    return m_fLog;
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
        
        public byte[] getBlock(
            )
        {
            try
            {
                if (m_blockList == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Block", "Block List"));
                }

                if (m_blockList.Count == 0)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0033, "Block List"));
                }

                // --

                return m_blockList[0];
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

        //--------------------------------------------------------------------------------------------------------------

        public int removeBlock(
            )
        {
            try
            {
                if (m_blockList == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Block", "Block List"));
                }

                if (m_blockList.Count != 0)
                {
                    m_blockList.RemoveAt(0);
                }
                
                // -- 

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
        
        #endregion

        //------------------------------------------------------------------------------------------------------------------------
        
    }   // Class end
}   // Namespace end