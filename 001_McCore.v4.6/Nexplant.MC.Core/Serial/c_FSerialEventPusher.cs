/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSerialEventPusher.cs
--  Creator         : byungyun.jeon
--  Create Date     : 2011.10.21
--  Description     : FAMate Core FaCommon Serial Event Pusher Class
--  History         : Created by byungyun.jeon at 2011.10.21
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    internal class FSerialEventPusher : IDisposable
    {
        
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        FISerial m_fSerial = null;
        private FQueue<FSerialEventArgsBase> m_fEvents = null;
        // --
        private FThread m_fEventPusher = null;
        private bool m_isCompletedEventHandling = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSerialEventPusher(
            FISerial fSerial
            )
        {
            m_fSerial = fSerial;
            m_fEvents = new FQueue<FSerialEventArgsBase>();

            // --

            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSerialEventPusher(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected void myDispose(
            bool disposing
            )
        {
            if(!m_disposed)
            {
                if(disposing)
                {
                    term();

                    // --

                    if (m_fEvents != null)
                    {
                        m_fEvents.Dispose();
                        m_fEvents = null;
                    }
                    // --
                    m_fSerial = null;
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

        public int eventCount
        {
            get
            {
                try
                {
                    return m_fEvents.count;
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
                    if (this.eventCount == 0 && m_isCompletedEventHandling)
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
                m_isCompletedEventHandling = true;
                m_fEventPusher = new FThread("SerialEventPusherThread", false, System.Threading.ThreadPriority.Normal, false);
                m_fEventPusher.ThreadJobCalled += new FThreadJobCalledEventHandler(m_fEventPusher_ThreadJobCalled);
                m_fEventPusher.start();
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
                if (m_fEventPusher != null)
                {
                    while (!this.m_isCompletedEventHandling)
                    {
                        System.Threading.Thread.Sleep(10);
                    }

                    // --

                    m_fEventPusher.ThreadJobCalled -= new FThreadJobCalledEventHandler(m_fEventPusher_ThreadJobCalled);
                    // --
                    m_fEventPusher.stop();
                    m_fEventPusher.Dispose();
                    m_fEventPusher = null;
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

        public void pushEvent(
            FSerialEventArgsBase fSerialEvent
            )
        {
            try
            {
                m_fEvents.enqueue(fSerialEvent);
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

        public void pushEvent(
            FSerialEventArgsBase[] fSerialEvents
            )
        {
            try
            {
                m_fEvents.enqueue(fSerialEvents);
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
                while (!this.m_isCompletedEventHandling)
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

        #region m_fEventPusher Object Event Handler

        private void m_fEventPusher_ThreadJobCalled(
            object sender,
            FThreadEventArgs e
            )
        {
            FSerialEventArgsBase args = null;

            try
            {
                if (m_fEvents.count == 0)
                {
                    m_isCompletedEventHandling = true;
                    e.sleepThread(1);
                    return;
                }
                m_isCompletedEventHandling = false;

                // --

                while ((args = m_fEvents.dequeue()) != null)
                {                    
                    if (args.fSerialEventId == FSerialEventId.SerialStateChanged)
                    {
                        ((FSerial)m_fSerial).onSerialStateChanged(args);
                    }
                    else if (args.fSerialEventId == FSerialEventId.SerialDataReceived)
                    {
                        ((FSerial)m_fSerial).onSerialDataReceived(args);
                    }
                    else if (args.fSerialEventId == FSerialEventId.SerialDataSent)
                    {
                        ((FSerial)m_fSerial).onSerialDataSent(args);
                    }
                    else if (args.fSerialEventId == FSerialEventId.SerialDataSendFailed)
                    {
                        ((FSerial)m_fSerial).onSerialDataSendFailed(args);
                    }
                    else if (args.fSerialEventId == FSerialEventId.SerialErrorRaised)
                    {
                        ((FSerial)m_fSerial).onSerialErrorRaised(args);
                    }                    
                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                args = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
