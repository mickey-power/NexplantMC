/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FQueue.cs
--  Creator         : spike.lee
--  Create Date     : 2011.03.21
--  Description     : FAMate Core FaCommon Queue Class 
--  History         : Created by spike.lee at 2011.03.21
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Nexplant.MC.Core.FaCommon
{
    public class FQueue<T> : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FCodeLock m_fCodeLock = null;
        private Queue<T> m_queue = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FQueue(
            )
        {
            m_fCodeLock = new FCodeLock();
            m_queue = new Queue<T>();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FQueue(
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
                    if (m_queue != null)
                    {
                        m_queue.Clear();
                        m_queue = null;
                    }

                    // --

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
                    return m_queue.Count;
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

        public void enqueue(
            T data
            )
        {
            try
            {
                m_fCodeLock.wait();
                m_queue.Enqueue(data);
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

        public void enqueue(T[] datas)
        {
            try
            {
                m_fCodeLock.wait();
                foreach (T t in datas)
                {
                    m_queue.Enqueue(t);
                }
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

        public T dequeue(
            )
        {
            try
            {
                m_fCodeLock.wait();
                if (m_queue.Count == 0)
                {
                    return default(T);
                }
                return m_queue.Dequeue();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fCodeLock.set();
            }
            return default(T);
        }

        //------------------------------------------------------------------------------------------------------------------------

        public T[] dequeueAll(
            )
        {
            try
            {
                m_fCodeLock.wait();
                return m_queue.ToArray();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_queue.Clear();
                m_fCodeLock.set();
            }
            return null;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
