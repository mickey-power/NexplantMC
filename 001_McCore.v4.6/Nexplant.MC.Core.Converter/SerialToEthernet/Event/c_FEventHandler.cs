/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FEventHandler.cs
--  Creator         : mjkim
--  Create Date     : 2019.09.23
--  Description     : FAmate Converter FaSerialToEthernet Event Handler Class
--  History         : Created by mjkim at 2019.09.23
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSerialToEthernet
{
    public class FEventHandler: IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        public event FEventRaisedEventHandler EventRaised = null;

        // --

        private bool m_disposed = false;
        // --
        private FSerialToEthernet m_fSerialToEthernet = null;
        private Control m_invoker = null;

        // --

        #region Class Construction and Destruction

        public FEventHandler(
            FSerialToEthernet fSerialToEthernet,
            Control invoker
            )
        {
            m_fSerialToEthernet = fSerialToEthernet;
            m_invoker = invoker;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FEventHandler(
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
                    m_fSerialToEthernet = null;
                    m_invoker = null;
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

        private void init(
            )
        {
            try
            {
                m_fSerialToEthernet.EventRaised += new FEventRaisedEventHandler(m_fSerialToEthernet_EventRaised);
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
                m_fSerialToEthernet.EventRaised -= new FEventRaisedEventHandler(m_fSerialToEthernet_EventRaised);
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

        private bool validateInvoker(
            )
        {
            try
            {
                if (m_invoker != null)
                {
                    if (!m_invoker.Created || !m_invoker.IsHandleCreated)
                    {
                        return false;
                    }
                }
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

        public void waitEventHandlingCompleted(
            )
        {
            try
            {
                m_fSerialToEthernet.fEventPusher.waitEventHandlingCompleted();
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

        #region m_fSerialToEthernet Object Evnet Handler

        private void m_fSerialToEthernet_EventRaised(
            object sender, 
            FEventArgsBase e
            )
        {
            try
            {
                if (EventRaised == null)
                {
                    return;
                }

                // --

                if (!validateInvoker())
                {
                    return;
                }

                // --

                if (m_invoker == null || !m_invoker.InvokeRequired)
                {
                    EventRaised(this, e);
                }
                else
                {
                    m_invoker.Invoke(new MethodInvoker(delegate()
                    {
                        EventRaised(this, e);
                    }));
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    return;
                }
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
