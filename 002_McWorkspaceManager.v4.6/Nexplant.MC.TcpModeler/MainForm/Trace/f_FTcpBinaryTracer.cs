/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FTcpBinaryTracer.cs
--  Creator         : kitae
--  Create Date     : 2011.09.09
--  Description     : FAMate TCP Modeler TCP Binary Tracer  Class
--  History         : Created by kitae at 2011.09.09
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Text;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaTcpDriver;
using Infragistics.Win.UltraWinToolbars;

namespace Nexplant.MC.TcpModeler
{
    public partial class FTcpBinaryTracer : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcmCore m_fTcmCore = null;
        private int m_countTrace = 0;
        // --
        private FEventHandler m_fEventHandler = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTcpBinaryTracer(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpBinaryTracer(
            FTcmCore fTcmCore
            )
            :this()
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
            FTcpDeviceDataSentEventArgs e
            )
        {
            string header2 = string.Empty;
            StringBuilder logBuilder = null;

            try
            {
                logBuilder = new StringBuilder();
                
                // --

                logBuilder.AppendLine(
                        "[" + e.fTcpDeviceDataSentLog.time + "] " +
                        "DataSent    , " +
                        "TcpDevice=<" + e.fTcpDeviceDataSentLog.name + ">, " +
                        "Protocol=<" + e.fTcpDeviceDataSentLog.fProtocol + ">, " +
                        "Length=<" + e.fTcpDeviceDataSentLog.length + ">"
                        );

                // -- 

                header2 =
                        "[" + e.fTcpDeviceDataSentLog.time + "] " +
                        "ConnectMode=<" + e.fTcpDeviceDataSentLog.fConnectMode + ">, " +
                        "LocalIp=<" + e.fTcpDeviceDataSentLog.localIp + ">, " +
                        "LocalPort=<" + e.fTcpDeviceDataSentLog.localPort + ">, " +
                        "RemoteIp=<" + e.fTcpDeviceDataSentLog.remoteIp + ">, " +
                        "RemotePort=<" + e.fTcpDeviceDataSentLog.remotePort + ">";

                // --

                logBuilder.AppendLine(header2);

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
            FTcpDeviceDataReceivedEventArgs e
            )
        {
            string header2 = string.Empty;
            StringBuilder logBuilder = null;

            try
            {
                logBuilder = new StringBuilder();
                
                // -- 

                logBuilder.AppendLine(
                    "[" + e.fTcpDeviceDataReceivedLog.time + "] " +
                    "DataReceived, " +
                    "TcpDevice=<" + e.fTcpDeviceDataReceivedLog.name + ">, " +
                    "Protocol=<" + e.fTcpDeviceDataReceivedLog.fProtocol + ">, " +
                    "Length=<" + e.fTcpDeviceDataReceivedLog.length + ">"
                    );

                // -- 

                header2 =
                        "[" + e.fTcpDeviceDataReceivedLog.time + "] " +
                        "ConnectMode=<" + e.fTcpDeviceDataReceivedLog.fConnectMode + ">, " +
                        "LocalIp=<" + e.fTcpDeviceDataReceivedLog.localIp + ">, " +
                        "LocalPort=<" + e.fTcpDeviceDataReceivedLog.localPort + ">, " +
                        "RemoteIp=<" + e.fTcpDeviceDataReceivedLog.remoteIp + ">, " +
                        "RemotePort=<" + e.fTcpDeviceDataReceivedLog.remotePort + ">";

                // --

                logBuilder.AppendLine(header2);                    

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
                if (int.Parse(nmbMaxTraceCount.Value.ToString()) <= m_countTrace)
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

        #region FTcpBinaryTracer Form Event Handler

        private void FTcpBinaryTracer_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();
                                
                // --

                m_fEventHandler = new FEventHandler(m_fTcmCore.fTcmFileInfo.fTcpDriver, txtMonitor);
                // --
                m_fEventHandler.TcpDeviceDataReceived += new FTcpDeviceDataReceivedEventHandler(m_fEventHandler_TcpDeviceDataReceived);
                m_fEventHandler.TcpDeviceDataSent += new FTcpDeviceDataSentEventHandler(m_fEventHandler_TcpDeviceDataSent);         
              
                // --

                nmbMaxTraceCount.Value = m_fTcmCore.fOption.tcpBinaryTracerMaxTraceCount;
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

        private void FTcpBinaryTracer_FormClosing(
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
                    m_fEventHandler.TcpDeviceDataSent -= new FTcpDeviceDataSentEventHandler(m_fEventHandler_TcpDeviceDataSent);
                    m_fEventHandler.TcpDeviceDataReceived -= new FTcpDeviceDataReceivedEventHandler(m_fEventHandler_TcpDeviceDataReceived);
                    //  --
                    m_fEventHandler = null;
                }

                // --

                m_fTcmCore.fOption.tcpBinaryTracerMaxTraceCount = int.Parse(nmbMaxTraceCount.Value.ToString());

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
        
        private void m_fEventHandler_TcpDeviceDataSent(
           object sender,
           FTcpDeviceDataSentEventArgs e
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

                if (((StateButtonTool)mnuMenu.Tools[FMenuKey.MenuTbtTraceEnabled]).Checked == true)
                {
                    log.Append(checkTrace(txtMonitor.Text));
                    log.Append(writeHeader(e));

                    // --

                    foreach (string s in e.dataToString(30).Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                    {
                        log.AppendLine("[" + e.fTcpDeviceDataSentLog.time + "] " + s);
                    }
                    log.AppendLine("--");
                    
                    // --

                    m_countTrace++;

                    // --

                    if (((StateButtonTool)mnuMenu.Tools[FMenuKey.MenuTbtUnfreezeScreen]).Checked == true)
                    {
                        txtMonitor.Text = log.ToString();
                        txtMonitor.SelectionStart = log.Length;
                    }
                    else if (((StateButtonTool)mnuMenu.Tools[FMenuKey.MenuTbtFreezeScreen]).Checked == true)
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

        private void m_fEventHandler_TcpDeviceDataReceived(
           object sender,
           FTcpDeviceDataReceivedEventArgs e
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

                if (((StateButtonTool)mnuMenu.Tools[FMenuKey.MenuTbtTraceEnabled]).Checked == true)
                {
                    log.Append(checkTrace(txtMonitor.Text));                    
                    log.Append(writeHeader(e));
                    
                    // --

                    foreach(string s in e.dataToString(30).Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                    {
                        log.AppendLine("[" + e.fTcpDeviceDataReceivedLog.time + "] " + s);                        
                    }                    
                    log.AppendLine("--");

                    // --
                    
                    m_countTrace++;
                    
                    // --

                    if (((StateButtonTool)mnuMenu.Tools[FMenuKey.MenuTbtUnfreezeScreen]).Checked == true)
                    {                        
                        txtMonitor.Text = log.ToString();
                        txtMonitor.SelectionStart = log.Length;
                    }
                    else if (((StateButtonTool)mnuMenu.Tools[FMenuKey.MenuTbtFreezeScreen]).Checked == true)
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

                if (e.Tool.Key == FMenuKey.MenuTbtTraceEnabled)
                {
                    nmbMaxTraceCount.Enabled = true;
                }
                else if (e.Tool.Key == FMenuKey.MenuTbtTraceDisabled)
                {
                    nmbMaxTraceCount.Enabled = false;
                }
                else if (e.Tool.Key == FMenuKey.MenuTbtClear)
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
            int maxTraceCount = 0;

            try
            {
                maxTraceCount = int.Parse(nmbMaxTraceCount.Value.ToString());
                if (maxTraceCount < FConstants.TraceMinCount)
                {
                    nmbMaxTraceCount.Value = FConstants.TraceMinCount;
                }
                else if (maxTraceCount > FConstants.TraceMaxCount)
                {
                    nmbMaxTraceCount.Value = FConstants.TraceMaxCount;
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
                maxTraceCount = int.Parse(nmbMaxTraceCount.Value.ToString());
                if (e.ButtonType == Infragistics.Win.UltraWinEditors.SpinButtonItem.NextItem)
                {
                    nmbMaxTraceCount.Value = maxTraceCount < FConstants.TraceMaxCount ? ++maxTraceCount : FConstants.TraceMaxCount;
                }
                else if (e.ButtonType == Infragistics.Win.UltraWinEditors.SpinButtonItem.PreviousItem)
                {
                    nmbMaxTraceCount.Value = maxTraceCount > FConstants.TraceMinCount ? --maxTraceCount : FConstants.TraceMinCount;
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
                FCursor.defaultCursor();
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

    }   // Class end
}   // Namespace end
