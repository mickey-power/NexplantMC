/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FMonitoring.cs
--  Creator         : mjkim
--  Create Date     : 2019.09.10
--  Description     : Nexplant MC Counter Monitoring Form Class
--  History         : Created by mjkim at 2019.09.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaSecs1ToHsms;

namespace Nexplant.MC.Counter
{
    public partial class FMonitoring : Form
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FCntCore m_fCntCore = null;
        private FEventHandler m_fEventHandler = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FMonitoring(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FMonitoring(
            FCntCore fCntCore
            )
            : this()
        {
            m_fCntCore = fCntCore;
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
                    m_fCntCore = null;
                }
            }

            m_disposed = true;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Proeprties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void changeSecs1State(
            FCommunicationState fState
            )
        {
            Color ColorClosed = Color.White;
            Color ColorOpened = Color.OrangeRed;
            Color ColorConnected = Color.Gold;
            Color ColorSelected = Color.Lime;

            try
            {
                lblSecs1State.Text = fState.ToString();
                if (fState == FCommunicationState.Closed)
                {
                    lblSecs1State.BackColor = ColorClosed;
                }
                else if (fState == FCommunicationState.Opened)
                {
                    lblSecs1State.BackColor = ColorOpened;
                }
                else if (fState == FCommunicationState.Connected)
                {
                    lblSecs1State.BackColor = ColorConnected;
                }
                else if (fState == FCommunicationState.Selected)
                {
                    lblSecs1State.BackColor = ColorSelected;
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

        private void changeHsmsState(
            FCommunicationState fState
            )
        {
            Color ColorClosed = Color.White;
            Color ColorOpened = Color.OrangeRed;
            Color ColorConnected = Color.Gold;
            Color ColorSelected = Color.Lime;

            try
            {
                lblHsmsState.Text = fState.ToString();
                if (fState == FCommunicationState.Closed)
                {
                    lblHsmsState.BackColor = ColorClosed;
                }
                else if (fState == FCommunicationState.Opened)
                {
                    lblHsmsState.BackColor = ColorOpened;
                }
                else if (fState == FCommunicationState.Connected)
                {
                    lblHsmsState.BackColor = ColorConnected;
                }
                else if (fState == FCommunicationState.Selected)
                {
                    lblHsmsState.BackColor = ColorSelected;
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

        private void procLogMonitoring(
            FLogMonitoringEventArgs fArgs
            )
        {
            StringBuilder logData = null;
            int length = 0;

            try
            {
                logData = new StringBuilder();
                logData.Append(rtxLog.Text);
                logData.Insert(0, fArgs.log);
                // --
                if (logData.Length > 500000)
                {
                    length = 500000;
                }
                else
                {
                    length = logData.Length;
                }
                // --
                rtxLog.Text = logData.ToString(0, length);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                logData = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FMonitoring Form Event Handler

        private void FMonitoring_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                changeSecs1State(m_fCntCore.fSecs1ToHsms.fSecs1State);
                changeHsmsState(m_fCntCore.fSecs1ToHsms.fHsmsState);

                // --

                m_fEventHandler = new FEventHandler(m_fCntCore.fSecs1ToHsms, this);
                m_fEventHandler.EventRaised += new FEventRaisedEventHandler(m_fEventHandler_EventRaised);

                // --

                // ***
                // Log Monitoring Enabed
                // ***
                m_fCntCore.fSecs1ToHsms.logMonitoringEnabled = true;
            }
            catch (Exception ex)
            {
                FCommon.showErrorMessageBox(this, ex); 
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FMonitoring_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                // **
                // Log Monitoring Disable 
                // *** 
                m_fCntCore.fSecs1ToHsms.logMonitoringEnabled = false;

                // --

                if (m_fEventHandler != null)
                {                    
                    m_fEventHandler.EventRaised -= new FEventRaisedEventHandler(m_fEventHandler_EventRaised);
                    m_fEventHandler.Dispose();
                    m_fEventHandler = null;
                }
            }
            catch (Exception ex)
            {
                FCommon.showErrorMessageBox(this, ex); 
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnClose Control Event Handler

        private void btnClose_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                this.Close();
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

        #region m_fEventHandler Object Event Handler

        private void m_fEventHandler_EventRaised(
            object sender, 
            FEventArgsBase e
            )
        {
            try
            {
                if (e.fEventId == FEventId.Secs1StateChanged)
                {
                    if (((FSecs1StateChangedEventArgs)e).fResult == FResultCode.Success)
                    {
                        changeSecs1State(((FSecs1StateChangedEventArgs)e).fState);
                    }
                }
                else if (e.fEventId == FEventId.HsmsStateChanged)
                {
                    if (((FHsmsStateChangedEventArgs)e).fResult == FResultCode.Success)
                    {
                        changeHsmsState(((FHsmsStateChangedEventArgs)e).fState);
                    }
                }
                else if (e.fEventId == FEventId.LogMonitoring)
                {
                    procLogMonitoring((FLogMonitoringEventArgs)e);
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

    }   // class end
}   // namespace end
