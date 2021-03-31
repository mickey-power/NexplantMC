/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FDelayMessageList.cs
--  Creator         : spike.lee
--  Create Date     : 2015.07.17
--  Description     : FAMate Core FaTcpDriver Delay Message List Class 
--  History         : Created by spike.lee at 2015.07.17
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    internal class FDelayMessageList : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        
        private FCodeLock m_fCodeLock = null;
        private List<FDelayMessage> m_fList = null; 

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FDelayMessageList(                                    
            )
        {
            m_fCodeLock = new FCodeLock();
            m_fList = new List<FDelayMessage>();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FDelayMessageList(
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
                    if (m_fList != null)
                    {
                        m_fList.Clear();
                        m_fList = null;
                    }

                    if (m_fCodeLock != null)
                    {
                        m_fCodeLock.Dispose();
                        m_fCodeLock = null;
                    }
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

        public int count
        {
            get
            {
                try
                {
                    m_fCodeLock.wait(); 
                    // --
                    return m_fList.Count;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    m_fCodeLock.set();
                }
                return 0;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods        

        public void add(
            FDelayMessage fDelayMessage
            )
        {
            try
            {
                m_fCodeLock.wait();
                // --
                m_fList.Add(fDelayMessage);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fCodeLock.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void clear(
            )
        {
            try
            {
                m_fCodeLock.wait();
                // --
                m_fList.Clear();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fCodeLock.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDelayMessage[] getMessage(
            )
        {
            List<FDelayMessage> fList = null;

            try
            {
                m_fCodeLock.wait();

                // --

                if (m_fList.Count == 0)
                {
                    return null;
                }

                // -- 

                fList = new List<FDelayMessage>();
                // --
                foreach (FDelayMessage m in m_fList)
                {
                    if (m.elasped())
                    {
                        fList.Add(m);
                    }
                }

                // --

                if (fList.Count == 0)
                {
                    return null;
                }

                // --

                foreach (FDelayMessage m in fList)
                {
                    m_fList.Remove(m);
                }

                // --                

                return fList.ToArray();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fList != null)
                {
                    fList.Clear();
                    fList = null;
                }
                m_fCodeLock.set();
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDelayMessage[] getMessage(
            FTcpSession fOpcSession
            )
        {
            List<FDelayMessage> fList = null;

            try
            {
                m_fCodeLock.wait();

                // --

                if (m_fList.Count == 0)
                {
                    return null;
                }

                // -- 

                fList = new List<FDelayMessage>();
                // --
                foreach (FDelayMessage m in m_fList)
                {
                    if (m.fOpcSession.uniqueId == fOpcSession.uniqueId)
                    {
                        if (m.elasped())
                        {
                            fList.Add(m);
                        }
                    }
                }

                // --

                if (fList.Count == 0)
                {
                    return null;
                }

                // --

                foreach (FDelayMessage m in fList)
                {
                    m_fList.Remove(m);
                }

                // --                

                return fList.ToArray();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fList != null)
                {
                    fList.Clear();
                    fList = null;
                }
                m_fCodeLock.set();
            }
            return null;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
