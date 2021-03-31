/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecs1RecvBlockList.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.10
--  Description     : FAmate Converter FaSecs1ToHsms SECS1 Recveived Block List Class
--  History         : Created by spike.lee at 2017.04.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecs1ToHsms
{
    internal class FSecs1RecvBlockList: IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSecs1ToHsms m_fSecs1ToHsms = null;
        private Dictionary<string, Dictionary<UInt16, FSecs1RecvBlock>> m_fSecs1BlockList = null;
        private Dictionary<string, FStaticTimer> m_fTmrT4List = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecs1RecvBlockList(   
            FSecs1ToHsms fSecs1ToHsms
            )
        {
            m_fSecs1ToHsms = fSecs1ToHsms;
            m_fSecs1BlockList = new Dictionary<string, Dictionary<UInt16, FSecs1RecvBlock>>();
            m_fTmrT4List = new Dictionary<string, FStaticTimer>();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSecs1RecvBlockList(
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
                    m_fSecs1BlockList = null;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private string makeKey(
            byte stream, 
            byte function, 
            UInt32 systemBytes
            )
        {
            string key = string.Empty;

            try
            {
                if (m_fSecs1ToHsms.fSecs1Config.ignoreSystemBytes)
                {
                    key = string.Format("{0}-{1}", stream.ToString(), function.ToString());
                }
                else
                {
                    key = string.Format("{0}-{1}-{2}", stream.ToString(), function.ToString(), systemBytes.ToString());
                }
                // --
                return key;
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

        //------------------------------------------------------------------------------------------------------------------------

        public bool validateInterleave(
            FSecs1RecvBlock fRecvBlock
            )
        {
            string key = string.Empty;

            try
            {
                // ***
                // Interleave가 지원될 경우
                // ***
                if (m_fSecs1ToHsms.fSecs1Config.interleave)
                {
                    return true;
                }

                // --

                // ***
                // Block List가 존재하지 않을 경우
                // ***
                if (m_fSecs1BlockList.Count == 0)
                {
                    return true;
                }

                // --

                // ***
                // Block이 존재할 경우
                // ***
                key = makeKey(fRecvBlock.stream, fRecvBlock.function, fRecvBlock.systemBytes);
                // --
                if (m_fSecs1BlockList.ContainsKey(key))
                {
                    return true;
                }

                // --

                return false;
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

        public bool validateBlockNo(
            FSecs1RecvBlock fRecvBlock
            )
        {
            string key = string.Empty;
            FSecs1RecvBlock fLastRecvBlock = null;

            try
            {
                key = makeKey(fRecvBlock.stream, fRecvBlock.function, fRecvBlock.systemBytes);
                // --
                if (m_fSecs1BlockList.ContainsKey(key))
                {
                    fLastRecvBlock = m_fSecs1BlockList[key].Last().Value;
                }
                
                // --

                if (fLastRecvBlock == null)
                {
                    // ***
                    // Init. Block No 0 or 1 검사
                    // ***
                    if (fRecvBlock.blockNo != 0 && fRecvBlock.blockNo != 1)
                    {
                        return false;
                    }
                }
                else
                {
                    // ***
                    // Add Block No.인 경우 Block No.가 순차적인지 검사   
                    // Block No.에 해당하는 Block이 존재할 경우, DuplidateBlock에서 검사
                    // ***
                    if (fLastRecvBlock.blockNo != fRecvBlock.blockNo - 1)
                    {
                        if (!m_fSecs1BlockList[key].ContainsKey(fRecvBlock.blockNo))
                        {
                            return false;
                        }                        
                    }
                }
                // --
                return true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fLastRecvBlock = null;
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool validateDuplidateBlock(
            FSecs1RecvBlock fRecvBlock
            )
        {
            string key = string.Empty;

            try
            {
                key = makeKey(fRecvBlock.stream, fRecvBlock.function, fRecvBlock.systemBytes);
                // --
                if (m_fSecs1BlockList.ContainsKey(key))
                {
                    if (m_fSecs1BlockList[key].ContainsKey(fRecvBlock.blockNo))
                    {
                        if (m_fSecs1ToHsms.fSecs1Config.duplicateError)
                        {
                            return false;
                        }
                    }              
                }
                // --
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

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsDataMessage addBlock(
            FSecs1RecvBlock fBlock
            )
        {
            string key = string.Empty;
            Dictionary<UInt16, FSecs1RecvBlock> fSecs1Blocks = null;
            List<byte> body = null;
            FSecsDataMessage fSecsDataMessage = null;
            FStaticTimer fTmrT4 = null;

            try
            {
                key = makeKey(fBlock.stream, fBlock.function, fBlock.systemBytes);
                // --
                if (m_fSecs1BlockList.ContainsKey(key))
                {
                    // ***
                    // 기존 Block List에 Block 추가
                    // ***
                    fSecs1Blocks = m_fSecs1BlockList[key];
                    // --
                    if (fSecs1Blocks.ContainsKey(fBlock.blockNo))
                    {
                        // ***
                        // Block Duplidate Error를 사용하지 않을 경우, 마지막 Block으로 설정
                        // ***
                        if (!m_fSecs1ToHsms.fSecs1Config.duplicateError)
                        {
                            fSecs1Blocks[fBlock.blockNo] = fBlock;
                        }
                    }
                    else
                    {
                        fSecs1Blocks.Add(fBlock.blockNo, fBlock);
                    }

                    // --

                    // ***
                    // T4 Timer 재 설정
                    // ***
                    m_fTmrT4List[key].restart(m_fSecs1ToHsms.fSecs1Config.t4Timeout * 1000);
                }
                else
                {
                    // ***
                    // 신규 Block List 생성
                    // ***
                    fSecs1Blocks = new Dictionary<ushort,FSecs1RecvBlock>();
                    fSecs1Blocks.Add(fBlock.blockNo, fBlock);
                    // --
                    m_fSecs1BlockList.Add(key, fSecs1Blocks);

                    // --

                    // ***
                    // T4 Timer 설정
                    // ***
                    fTmrT4 = new FStaticTimer();
                    fTmrT4.start(m_fSecs1ToHsms.fSecs1Config.t4Timeout * 1000);
                    m_fTmrT4List.Add(key, fTmrT4);
                }

                // --

                if (!fBlock.ebit)
                {
                    return null;  
                }

                // --

                body = new List<byte>();
                // --
                foreach (FSecs1RecvBlock b in fSecs1Blocks.Values)
                {
                    body.AddRange(b.body);
                }
                // --
                fSecsDataMessage = new FSecsDataMessage(
                    m_fSecs1ToHsms, 
                    fBlock.sessionId, 
                    fBlock.wbit, 
                    fBlock.stream, 
                    fBlock.function, 
                    fBlock.systemBytes, 
                    body.ToArray()
                    );

                // --
                
                m_fSecs1BlockList.Remove(key);
                m_fTmrT4List.Remove(key);

                // --

                return fSecsDataMessage;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fTmrT4 = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecs1T4TimeoutBlock[] removeT4TimeoutBlock(
            )
        {
            List<string> keyList = null;
            List<FSecs1T4TimeoutBlock> fBlockList = null;
            FSecs1RecvBlock fRecvBlock = null;

            try
            {
                keyList = new List<string>();
                fBlockList = new List<FSecs1T4TimeoutBlock>();
                
                // --
                
                foreach (string key in m_fSecs1BlockList.Keys)
                {
                    if (m_fTmrT4List[key].elasped(false))
                    {
                        keyList.Add(key);
                    }
                }

                // --

                foreach (string key in keyList)
                {
                    fRecvBlock = m_fSecs1BlockList[key].First().Value;
                    fBlockList.Add(
                        new FSecs1T4TimeoutBlock(fRecvBlock.sessionId, fRecvBlock.stream, fRecvBlock.function, fRecvBlock.systemBytes)
                        );
                    // --
                    m_fSecs1BlockList.Remove(key);
                    m_fTmrT4List.Remove(key);
                }

                // --

                return fBlockList.ToArray();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                keyList = null;
                fBlockList = null;
                fRecvBlock = null;
            }
            return null;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
