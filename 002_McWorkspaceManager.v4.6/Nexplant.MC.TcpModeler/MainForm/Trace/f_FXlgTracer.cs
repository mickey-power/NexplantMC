/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FXlgTracer.cs
--  Creator         : kitae
--  Create Date     : 2011.09.30
--  Description     : FAMate TCP Modeler XLG Tracer  Class
--  History         : Created by kitae at 2011.09.30
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinToolbars;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaTcpDriver;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.TcpModeler
{
    public partial class FXlgTracer : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {
        
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcmCore m_fTcmCore = null;        
        private int m_countTrace = 0;
        // --
        private FEventHandler m_fEventHandler = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destructtion

        public FXlgTracer(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FXlgTracer(
            FTcmCore fTcmCore
            )
            : this()
        {
            base.fUIWizard = fTcmCore.fUIWizard;
            m_fTcmCore = fTcmCore;
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    m_fTcmCore = null;
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

        protected override void changeControlCaption(
            )
        {
            try
            {
                base.changeControlCaption();
                base.fUIWizard.changeControlCaption(mnuMenu);
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

        protected override void changeControlFontName(
            )
        {
            try
            {
                base.changeControlFontName();
                base.fUIWizard.changeControlFontName(mnuMenu);
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

        private bool procMenuChangeFontName(
            )
        {
            bool isValidFontName = true;
            string preFontName = string.Empty;

            try
            {
                preFontName = ((FontListTool)mnuMenu.Tools[FMenuKey.MenuFontName]).Value.ToString();
                // --
                txtMonitor.Appearance.FontData.Name = (new System.Drawing.FontFamily(preFontName)).Name;
                m_fTcmCore.fOption.commonFontName = preFontName;
            }
            catch (Exception)
            {
                isValidFontName = false;
            }
            finally
            {

            }
            return isValidFontName;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuChangeFontSize(
            )
        {
            try
            {
                txtMonitor.Appearance.FontData.SizeInPoints = float.Parse(mnbFontSize.Value.ToString());
                m_fTcmCore.fOption.commonFontSize = float.Parse(mnbFontSize.Value.ToString());
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

        private string writeHeader(
            FTcpDeviceXmlSentEventArgs e
            )
        {
            StringBuilder logBuilder = null;

            try
            {
                logBuilder = new StringBuilder();

                // --

                logBuilder.AppendLine(
                    "[" + e.fTcpDeviceXmlSentLog.time + "] " +
                    "DataSent    , " +
                    "TcpDevice=<" + e.fTcpDeviceXmlSentLog.name + ">, " +
                    "SessionId=<" + e.fTcpDeviceXmlSentLog.sessionId + ">, " +
                    "Length=<" + e.fTcpDeviceXmlSentLog.length + ">"
                    );
                logBuilder.AppendLine(
                    "[" + e.fTcpDeviceXmlSentLog.time + "] " +
                    "ResultCode=<" + e.fTcpDeviceXmlSentLog.fResultCode + ">, " +
                    "ResultMessage=<" + e.fTcpDeviceXmlSentLog.resultMessage + ">"
                    );

                // -- 

                return logBuilder.ToString();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string writeHeader(
            FTcpDeviceXmlReceivedEventArgs e
            )
        {
            StringBuilder logBuilder = null;

            try
            {
                logBuilder = new StringBuilder();

                // --

                logBuilder.AppendLine(
                    "[" + e.fTcpDeviceXmlReceivedLog.time + "] " +
                    "DataReceived, " +
                    "TcpDevice=<" + e.fTcpDeviceXmlReceivedLog.name + ">, " +
                    "SessionId=<" + e.fTcpDeviceXmlReceivedLog.sessionId + ">, " +
                    "Length=<" + e.fTcpDeviceXmlReceivedLog.length + ">"
                    );
                logBuilder.AppendLine(
                    "[" + e.fTcpDeviceXmlReceivedLog.time + "] " +
                    "ResultCode=<" + e.fTcpDeviceXmlReceivedLog.fResultCode + ">, " +
                    "ResultMessage=<" + e.fTcpDeviceXmlReceivedLog.resultMessage + ">"
                    );

                // --

                return logBuilder.ToString();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private string checkTrace(
            string textLog
            )
        {
            try
            {
                if (int.Parse(mnbMaxTraceCount.Value.ToString()) < m_countTrace)
                {
                    m_countTrace--;
                    return textLog.Remove(0, textLog.IndexOf("--") + 3);
                }

                // --

                return textLog;
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

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuClear(
            )
        {
            try
            {
                txtMonitor.beginUpdate();

                // --

                txtMonitor.Text = string.Empty;
                m_countTrace = 0;

                // -- 

                txtMonitor.endUpdate();
            }
            catch (Exception ex)
            {
                txtMonitor.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FXlgTracer Form Event Handler

        private void FXlgTracer_Load(
            object sender, EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fEventHandler = new FEventHandler(m_fTcmCore.fTcmFileInfo.fTcpDriver, txtMonitor);
                // --
                m_fEventHandler.TcpDeviceXmlReceived += new FTcpDeviceXmlReceivedEventHandler(m_fEventHandler_TcpDeviceXmlReceived);
                m_fEventHandler.TcpDeviceXmlSent += new FTcpDeviceXmlSentEventHandler(m_fEventHandler_TcpDeviceXmlSent);

                // --

                mnbMaxTraceCount.Value = m_fTcmCore.fOption.xlgTracerMaxTraceCount;
                ((FontListTool)mnuMenu.Tools[FMenuKey.MenuFontName]).Value = m_fTcmCore.fOption.commonFontName;
                mnbFontSize.Value = m_fTcmCore.fOption.commonFontSize;

                // --

                txtMonitor.Appearance.FontData.Name = ((FontListTool)mnuMenu.Tools[FMenuKey.MenuFontName]).Value.ToString();
                txtMonitor.Appearance.FontData.SizeInPoints = float.Parse(mnbFontSize.Value.ToString());

                // --

                m_fTcmCore.fOption.fChildFormList.add(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        private void FXlgTracer_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                if (m_fEventHandler != null)
                {
                    m_fTcmCore.fTcmFileInfo.fTcpDriver.waitEventHandlingCompleted();
                    // --
                    m_fEventHandler.Dispose();
                    // --
                    m_fEventHandler.TcpDeviceXmlSent -= new FTcpDeviceXmlSentEventHandler(m_fEventHandler_TcpDeviceXmlSent);
                    m_fEventHandler.TcpDeviceXmlReceived -= new FTcpDeviceXmlReceivedEventHandler(m_fEventHandler_TcpDeviceXmlReceived);
                    //  --
                    m_fEventHandler = null;
                }

                // --

                m_fTcmCore.fOption.xlgTracerMaxTraceCount = int.Parse(mnbMaxTraceCount.Value.ToString());

                // --

                m_fTcmCore.fOption.fChildFormList.remove(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }
        
        #endregion

        //------------------------------------------------------------------------------------------------------------------------
        
        #region m_fEventHandler Object Event Handler
        
        private void m_fEventHandler_TcpDeviceXmlSent(
            object sender,
            FTcpDeviceXmlSentEventArgs e
            )
        {
            StringBuilder log = null;
            int selectedLength = 0;
            int beforCaretPosition = 0;
            int deleteLength = 0;

            try
            {
                txtMonitor.beginUpdate();

                // --

                log = new StringBuilder();
                beforCaretPosition = txtMonitor.SelectionStart;
                deleteLength = txtMonitor.Text.IndexOf("--") + 3;

                // --

                if (((StateButtonTool)mnuMenu.Tools[FMenuKey.MenuXltTraceEnabled]).Checked == true)
                {
                    log.Append(checkTrace(txtMonitor.Text));
                    log.Append(writeHeader(e));

                    // --

                    foreach (string s in e.xml.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                    {
                        log.AppendLine("[" + e.fTcpDeviceXmlSentLog.time + "] " + s);
                    }
                    log.AppendLine("--");

                    // --

                    m_countTrace++;

                    // --

                    if (((StateButtonTool)mnuMenu.Tools[FMenuKey.MenuXltUnfreezeScreen]).Checked == true)
                    {
                        txtMonitor.Text = log.ToString();
                        txtMonitor.SelectionStart = log.Length;
                    }
                    else if (((StateButtonTool)mnuMenu.Tools[FMenuKey.MenuXltFreezeScreen]).Checked == true)
                    {
                        if (txtMonitor.SelectedText.Length > 0)
                        {
                            selectedLength = txtMonitor.SelectedText.Length;
                        }

                        // --

                        txtMonitor.Text = log.ToString();
                        txtMonitor.SelectionStart = beforCaretPosition - deleteLength > 0 ? beforCaretPosition - deleteLength : 0;
                    }

                    // --                                                                               

                    if (selectedLength > 0 && (beforCaretPosition - deleteLength) >= 0)
                    {
                        txtMonitor.Select(beforCaretPosition - deleteLength, selectedLength);
                    }

                    // --

                    txtMonitor.ScrollToCaret();
                }

                // --

                txtMonitor.endUpdate();
            }
            catch (Exception ex)
            {
                txtMonitor.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                log = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_TcpDeviceXmlReceived(
            object sender,
            FTcpDeviceXmlReceivedEventArgs e
            )
        {
            StringBuilder log = null;
            int selectedLength = 0;
            int beforCaretPosition = 0;
            int deleteLength = 0;

            try
            {
                txtMonitor.beginUpdate();

                // --

                log = new StringBuilder();
                beforCaretPosition = txtMonitor.SelectionStart;
                deleteLength = txtMonitor.Text.IndexOf("--") + 3;
                
                // --

                if (((StateButtonTool)mnuMenu.Tools[FMenuKey.MenuXltTraceEnabled]).Checked == true)
                {
                    log.Append(checkTrace(txtMonitor.Text));
                    log.Append(writeHeader(e));

                    // --

                    foreach (string s in e.xml.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                    {
                        log.AppendLine("[" + e.fTcpDeviceXmlReceivedLog.time + "] " + s);
                    }
                    log.AppendLine("--");

                    // --

                    m_countTrace++;

                    // --

                    if (((StateButtonTool)mnuMenu.Tools[FMenuKey.MenuXltUnfreezeScreen]).Checked == true)
                    {
                        txtMonitor.Text = log.ToString();
                        txtMonitor.SelectionStart = log.Length;
                    }
                    else if (((StateButtonTool)mnuMenu.Tools[FMenuKey.MenuXltFreezeScreen]).Checked == true)
                    {
                        if (txtMonitor.SelectedText.Length > 0)
                        {
                            selectedLength = txtMonitor.SelectedText.Length;
                        }

                        // --

                        txtMonitor.Text = log.ToString();
                        txtMonitor.SelectionStart = beforCaretPosition - deleteLength > 0 ? beforCaretPosition - deleteLength + selectedLength : 0;
                    }                    

                    // --                                      

                    if (selectedLength > 0 && (beforCaretPosition - deleteLength) >= 0)
                    {
                        txtMonitor.Select(beforCaretPosition - deleteLength, selectedLength);
                    }

                    // --
                    
                    txtMonitor.ScrollToCaret();
                }

                // --

                txtMonitor.endUpdate();
            }
            catch (Exception ex)
            {
                txtMonitor.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                log = null;               
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region mnuMenu Control Event Handler

        private void mnuMenu_ToolClick(
            object sender,
            ToolClickEventArgs e
            )
        {

            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tool.Key == FMenuKey.MenuXltTraceEnabled)
                {
                    mnbMaxTraceCount.Enabled = true;
                }
                else if (e.Tool.Key == FMenuKey.MenuXltTraceDisabled)
                {
                    mnbMaxTraceCount.Enabled = false;
                }
                else if (e.Tool.Key == FMenuKey.MenuXltClear)
                {
                    procMenuClear();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void mnuMenu_ToolValueChanged(
            object sender,
            ToolEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tool.Key == FMenuKey.MenuFontName)
                {
                    procMenuChangeFontName();
                    
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void mnuMenu_AfterToolDeactivate(
            object sender,
            ToolEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tool.Key == FMenuKey.MenuFontName)
                {
                    if (!procMenuChangeFontName())
                    {
                        ((FontListTool)mnuMenu.Tools[FMenuKey.MenuFontName]).Value = m_fTcmCore.fOption.commonFontName;
                        txtMonitor.Appearance.FontData.Name = m_fTcmCore.fOption.commonFontName;
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region mnbMaxTraceCount Control Event Handler

        private void mnbMaxTraceCount_BeforeExitEditMode(
            object sender, 
            Infragistics.Win.BeforeExitEditModeEventArgs e
            )
        {
            try
            {
                if (int.Parse(mnbMaxTraceCount.Value.ToString()) < FConstants.TraceMinCount)
                {
                    mnbMaxTraceCount.Value = FConstants.TraceMinCount;
                }
                else if (int.Parse(mnbMaxTraceCount.Value.ToString()) > FConstants.TraceMaxCount)
                {
                    mnbMaxTraceCount.Value = FConstants.TraceMaxCount;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void mnbMaxTraceCount_EditorSpinButtonClick(
            object sender,
            Infragistics.Win.UltraWinEditors.SpinButtonClickEventArgs e
            )
        {
            int maxTraceCount = 0;

            try
            {
                maxTraceCount = int.Parse(mnbMaxTraceCount.Value.ToString());

                // --

                if (e.ButtonType == Infragistics.Win.UltraWinEditors.SpinButtonItem.NextItem)
                {
                    mnbMaxTraceCount.Value = maxTraceCount < FConstants.TraceMaxCount ? ++maxTraceCount : FConstants.TraceMaxCount;
                }
                else if (e.ButtonType == Infragistics.Win.UltraWinEditors.SpinButtonItem.PreviousItem)
                {
                    mnbMaxTraceCount.Value = maxTraceCount > FConstants.TraceMinCount ? --maxTraceCount : FConstants.TraceMinCount;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void mnbMaxTraceCount_KeyDown(
            object sender,
            KeyEventArgs e
            )
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMonitor.Focus();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region mnbFontSize Control Event Handler

        private void mnbFontSize_EditorSpinButtonClick(
            object sender,
            Infragistics.Win.UltraWinEditors.SpinButtonClickEventArgs e
            )
        {
            float fontSize = 0;

            try
            {
                FCursor.waitCursor();

                // --

                fontSize = float.Parse(mnbFontSize.Value.ToString());
                if (e.ButtonType == Infragistics.Win.UltraWinEditors.SpinButtonItem.NextItem)
                {
                    mnbFontSize.Value = fontSize < FConstants.FontMaxSize ? (int)++fontSize : FConstants.FontMaxSize;
                }
                else if (e.ButtonType == Infragistics.Win.UltraWinEditors.SpinButtonItem.PreviousItem)
                {
                    mnbFontSize.Value = fontSize > FConstants.FontMinSize ? (int)--fontSize : FConstants.FontMinSize;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void mnbFontSize_BeforeExitEditMode(
            object sender, 
            Infragistics.Win.BeforeExitEditModeEventArgs e
            )
        {
            float fontSize = 0;

            try
            {
                FCursor.waitCursor();

                // --

                fontSize = float.Parse(mnbFontSize.Value.ToString());
                if (fontSize < FConstants.FontMinSize)
                {
                    mnbFontSize.Value = FConstants.FontMinSize;
                }
                else if (fontSize > FConstants.FontMaxSize)
                {
                    mnbFontSize.Value = FConstants.FontMaxSize;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void mnbFontSize_KeyDown(
            object sender,
            KeyEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.KeyCode == Keys.Enter)
                {
                    txtMonitor.Focus();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void mnbFontSize_ValueChanged(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                procMenuChangeFontSize();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion 

        //------------------------------------------------------------------------------------------------------------------------

    }  // Class end
}  // Namespace end
