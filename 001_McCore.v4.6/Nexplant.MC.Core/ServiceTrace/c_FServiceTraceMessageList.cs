/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FServiceTraceMessageList.cs
--  Creator         : spike.lee
--  Create Date     : 2011.09.16
--  Description     : FAMate Core FaCommon Service Trace Message List Class
--  History         : Created by spike.lee at 2011.09.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    internal class FServiceTraceMessageList : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private int m_maxMessageCount = 100;
        private FCodeLock m_fLock = null;        
        private List<FServiceTraceMessage> m_fMessageList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FServiceTraceMessageList(            
            )
        {
            m_fLock = new FCodeLock();
            m_fMessageList = new List<FServiceTraceMessage>();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FServiceTraceMessageList(
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
                    if (m_fLock != null)
                    {
                        m_fLock.Dispose();
                        m_fLock = null;
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

        public int maxMessageCount
        {
            get
            {
                try
                {
                    return m_maxMessageCount;
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
                    if (value < 1)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0005, "Max Message Count"));
                    }
                    
                    // --

                    m_maxMessageCount = value;
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

        public int count
        {
            get
            {
                try
                {
                    return m_fMessageList.Count;
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

        public FServiceTraceMessage this[int index]
        {
            get
            {
                try
                {
                    if (index < m_fMessageList.Count)
                    {
                        return m_fMessageList[index];
                    }
                    return null;
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

        public void add(
            FServiceTraceMessage fMessage
            )
        {
            try
            {
                m_fLock.wait();
                
                // --
                
                m_fMessageList.Add(fMessage);

                // --

                if (m_fMessageList.Count > m_maxMessageCount)
                {
                    m_fMessageList.RemoveRange(0, m_fMessageList.Count - m_maxMessageCount);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fLock.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void remove(
            FServiceTraceMessage fMessage
            )
        {
            try
            {
                m_fLock.wait();
                m_fMessageList.Remove(fMessage);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fLock.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void rmeoveAt(
            int index
            )
        {
            try
            {
                m_fLock.wait();
                m_fMessageList.RemoveAt(index);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fLock.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void clear(
            )
        {
            try
            {
                m_fLock.wait();
                m_fMessageList.Clear();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fLock.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FServiceTraceMessage[] getMessageAll(
            bool isRemoveAll
            )
        {
            FServiceTraceMessage[] fMessages = null;

            try
            {
                m_fLock.wait();

                // --

                if (m_fMessageList.Count == 0)
                {
                    return null;
                }

                // --

                fMessages =  m_fMessageList.ToArray();
                m_fMessageList.Clear();
                return fMessages;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fLock.set();
            }
            return null;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
