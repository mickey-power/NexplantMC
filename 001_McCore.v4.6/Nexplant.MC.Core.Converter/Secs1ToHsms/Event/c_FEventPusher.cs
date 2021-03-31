/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FEventPusher.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.10
--  Description     : FAmate Converter FaSecs1ToHsms Event Pusher Class
--  History         : Created by spike.lee at 2017.04.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecs1ToHsms
{
    internal class FEventPusher: IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSecs1ToHsms m_fSecs1ToHsms = null;
        // --
        private FQueue<FEventArgsBase> m_fSecs1Events = null;
        private FQueue<FEventArgsBase> m_fHsmsEvents = null;
        private FThread m_fThdEventPusher = null;
        private bool m_isCompletedEventHandling = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FEventPusher(
            FSecs1ToHsms fSecs1ToHsms
            )
        {
            m_fSecs1ToHsms = fSecs1ToHsms;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FEventPusher(
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
                    term();
                    // --
                    m_fSecs1ToHsms = null;
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

        public int secs1EventCount
        {
            get
            {
                try
                {
                    return m_fSecs1Events.count;
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

        public int hsmsEventCount
        {
            get
            {
                try
                {
                    return m_fHsmsEvents.count;
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

        public bool isCompletedEventHandling
        {
            get
            {
                try
                {
                    if (this.secs1EventCount == 0 && this.hsmsEventCount == 0 && m_isCompletedEventHandling)
                    {
                        return true;
                    }
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            try
            {
                m_fSecs1Events = new FQueue<FEventArgsBase>();
                m_fHsmsEvents = new FQueue<FEventArgsBase>();

                // --

                m_isCompletedEventHandling = true;
                m_fThdEventPusher = new FThread("EventPushThread", false, System.Threading.ThreadPriority.Normal, true);
                m_fThdEventPusher.ThreadJobCalled += new FThreadJobCalledEventHandler(m_fThdEventPusher_ThreadJobCalled);
                m_fThdEventPusher.start();
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

        private void term(
            )
        {
            try
            {
                if (m_fThdEventPusher != null)
                {
                    while (!this.isCompletedEventHandling)
                    {
                        System.Threading.Thread.Sleep(10);
                    }

                    // --

                    m_fThdEventPusher.ThreadJobCalled -= new FThreadJobCalledEventHandler(m_fThdEventPusher_ThreadJobCalled);
                    m_fThdEventPusher.stop();
                    m_fThdEventPusher.Dispose();
                    m_fThdEventPusher = null;
                }

                if (m_fSecs1Events != null)
                {
                    m_fSecs1Events.Dispose();
                    m_fSecs1Events = null;
                }

                if (m_fHsmsEvents != null)
                {
                    m_fHsmsEvents.Dispose();
                    m_fHsmsEvents = null;
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

        public void pushSecs1Event(
            FEventArgsBase fArgs
            )
        {
            try
            {
                m_fSecs1Events.enqueue(fArgs);
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

        public void pushHsmsEvent(
            FEventArgsBase fArgs
            )
        {
            try
            {
                m_fHsmsEvents.enqueue(fArgs);
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

        public void waitEventHandlingCompleted(
            )
        {
            try
            {
                while (!this.isCompletedEventHandling)
                {
                    if (System.Windows.Forms.Application.MessageLoop)
                    {
                        System.Windows.Forms.Application.DoEvents();
                    }
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

        #region m_fThdEventHandler Object Event Handler

        private void m_fThdEventPusher_ThreadJobCalled(
            object sender, 
            FThreadEventArgs e
            )
        {
            try
            {
                if (this.secs1EventCount == 0 && this.hsmsEventCount == 0)
                {
                    m_isCompletedEventHandling = true;
                    e.sleepThread(1);
                    return;
                }
                m_isCompletedEventHandling = false;

                // --

                while (this.secs1EventCount > 0)
                {
                    m_fSecs1ToHsms.onEventRaised(m_fSecs1Events.dequeue());
                }

                // --

                while (this.hsmsEventCount > 0)
                {
                    m_fSecs1ToHsms.onEventRaised(m_fHsmsEvents.dequeue());
                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
