/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSerialFlag.cs
--  Creator         : byungyun.jeon
--  Create Date     : 2011.10.24
--  Description     : FAMate Core FaCommon Serial Flag Class
--  History         : Created by byungyun.jeon at 2011.10.24
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    public class FSerialFlag : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FCodeLock m_fLock = null;
        private int m_sendCount = 0;
        private int m_receiveCount = 0;
        // --
        private bool m_closed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSerialFlag(
            )
        {
            m_fLock = new FCodeLock();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSerialFlag(
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

        public bool doReceiveCompleted
        {
            get
            {
                try
                {
                    return m_receiveCount == 0 ? true : false;
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

        public bool doSendCompleted
        {
            get
            {
                try
                {
                    return m_sendCount == 0 ? true : false;
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

        public bool closed
        {
            get
            {
                try
                {
                    return m_closed;
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
                    m_closed = value;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public void init(
            )
        {
            try
            {
                m_sendCount = 0;
                m_receiveCount = 0;
                // --
                m_closed = false;
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

        public int beginOpen(
            )
        {
            try
            {

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

        public int endOpen(
            )
        {
            try
            {

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

        public int beginSend(
            )
        {
            try
            {
                m_fLock.wait();
                return ++m_sendCount;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fLock.set();
            }
            return 0;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int endSend(
            )
        {
            try
            {
                m_fLock.wait();
                return --m_sendCount;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fLock.set();
            }
            return 0;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int beginReceive(
            )
        {
            try
            {
                m_fLock.wait();
                return ++m_receiveCount;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fLock.set();
            }
            return 0;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int endReceive(
            )
        {
            try
            {
                m_fLock.wait();
                return --m_receiveCount;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fLock.set();
            }
            return 0;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void waitSendCompleted(
            )
        {
            try
            {
                while (!this.doSendCompleted)
                {
                    System.Threading.Thread.Sleep(1);
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

        public void waitReceiveCompleted(
            )
        {
            try
            {
                while (!this.doReceiveCompleted)
                {
                    System.Threading.Thread.Sleep(1);
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

        public void waitAllCompleted(
            )
        {
            try
            {
                while (!this.doSendCompleted || !this.doReceiveCompleted)
                {
                    System.Threading.Thread.Sleep(1);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
