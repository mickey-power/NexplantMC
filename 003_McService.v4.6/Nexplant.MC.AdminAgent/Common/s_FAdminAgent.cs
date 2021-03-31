/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : s_FAdminAgent.cs
--  Creator         : byungyun.jeon
--  Create Date     : 2012.03.26
--  Description     : FAMate Admin Agent Class 
--  History         : Created by byungyun.jeon at 2012.03.26
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ServiceProcess;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.AdminAgentCore;

namespace Nexplant.MC.AdminAgent
{
    public partial class FAdminAgent : ServiceBase
    {
        
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // -- 
        private FTimer m_fRestartTimer = null;
        private FAdaMain m_fAdaMain = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Contruction and Destruction

        public FAdminAgent(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override void OnStart(
            string[] args
            )
        {
            try
            {
                m_fRestartTimer = new FTimer("AdminServiceRestartTimer", true, 1, true);
                m_fRestartTimer.TimerElapsed += new FTimerElapsedEventHandler(m_fRestartTimer_TimerElapsed);

                // --

                init();
            }
            catch
            {
                //추후 이벤트 로그 기록
                this.Stop();
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override void OnStop(
            )
        {
            try
            {
                term();

                // --

                if (m_fRestartTimer != null)
                {
                    m_fRestartTimer.Dispose();
                    m_fRestartTimer.TimerElapsed -= new FTimerElapsedEventHandler(m_fRestartTimer_TimerElapsed);
                    m_fRestartTimer = null;
                }
            }
            catch
            {
                // 추후 이벤트 로그 기록
            }
            finally
            {

            }
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
                }
                m_disposed = true;
            }
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
                m_fAdaMain = new FAdaMain();
                // --
                m_fAdaMain.RestartRequested += new FRestartRequestedEventHandler(m_fAdaMain_RestartRequested);
                m_fAdaMain.init();
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
                if (m_fAdaMain != null)
                {
                    m_fAdaMain.term();
                    // --
                    m_fAdaMain.Dispose();
                    m_fAdaMain.RestartRequested -= new FRestartRequestedEventHandler(m_fAdaMain_RestartRequested);
                    m_fAdaMain = null;
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

        #region m_fRestartTimer Object Event Handler

        private void m_fRestartTimer_TimerElapsed(
            object sender,
            FTimerElapsedEventArgs e
            )
        {
            try
            {
                m_fRestartTimer.stop();

                // --

                term();

                // --

                init();
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

        #region m_fAdaMain Object Event Handler

        private void m_fAdaMain_RestartRequested(
            object sender,
            FRestartRequestedEventArgs e
            )
        {
            try
            {
                m_fRestartTimer.start();
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