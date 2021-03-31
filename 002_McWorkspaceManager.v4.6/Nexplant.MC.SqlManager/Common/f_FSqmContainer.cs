/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSqmContainer.cs
--  Creator         : mj.kim
--  Create Date     : 2011.09.23
--  Description     : FAMate SQL Manager Form Class
--  History         : Created by mj.kim at 2011.09.23
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinToolbars;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.SqlManager
{
    public partial class FSqmContainer : Core.FaUIs.FBaseTabMdiChildForm
    {
 
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSqmCore m_fSqmCore = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSqmContainer(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSqmContainer(
            FIWsmCore fWsmCore
            )
            : this()
        {
            base.fUIWizard = fWsmCore.fUIWizard;
            m_fSqmCore = new FSqmCore(fWsmCore, this);
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
                    if (m_fSqmCore != null)
                    {
                        m_fSqmCore.Dispose();
                        m_fSqmCore = null;
                    }
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

        private void setTitle(
           )
        {
            string appName = string.Empty;

            try
            {
                appName = m_fSqmCore.fWsmCore.fUIWizard.searchCaption(FConstants.ApplicationName);
                // --
                if (m_fSqmCore.fOption.isConnect == false)
                {
                    this.Text = appName;
                }
                else
                {
                    this.Text = appName + " - [" + m_fSqmCore.fOption.connection + "]";
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

        private void setMainStatusBar(
            )
        {
            System.Reflection.Assembly assembly = null;
            string caption = string.Empty;
            string version = string.Empty;

            try
            {
                caption = m_fSqmCore.fUIWizard.searchCaption(FConstants.ApplicationName);
                if (m_fSqmCore.fOption.isConnect == true)
                {
                    caption += " - [" + m_fSqmCore.fOption.connection;
                    if (m_fSqmCore.fOption.connectionDescription != string.Empty)
                    {
                        caption += ": " + m_fSqmCore.fOption.connectionDescription;
                    }
                    caption += "]";
                }

                // --

                assembly = System.Reflection.Assembly.GetCallingAssembly();
                if (assembly != null)
                {
                    version = assembly.GetName().Version.ToString();
                }

                // --

                m_fSqmCore.fWsmCore.onMainStatusBarChanged(
                    true,
                    caption,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    version
                    );
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                assembly = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

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

        private void reconnection(
            )
        {
            FConnectionDialog fConnectionDialog = null;

            try
            {
                fConnectionDialog = new FConnectionDialog(m_fSqmCore);
                if (fConnectionDialog.ShowDialog(this) == DialogResult.Cancel)
                {
                    this.Close();
                    return;
                }

                // --

                setTitle();
                setMainStatusBar();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fConnectionDialog != null)
                {
                    fConnectionDialog.Dispose();
                    fConnectionDialog = null;
                }
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuReconnection(
            )
        {
            DialogResult dialogResult;

            try
            {
                // ***
                // Reconnect Confirm
                // ***
                dialogResult = FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fSqmCore.fWsmCore.fUIWizard.generateMessage("Q0010", new object[] { "Nexplant MC SQL Manager v4.1" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    );
                if (dialogResult == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                // --

                this.closeAllChilds();

                // --

                m_fSqmCore.fOption.isConnect = false;

                // --

                setTitle();
                setMainStatusBar();

                // --

                reconnection();
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

        private void procMenuExit(
            )
        {
            try
            {
                this.Close();
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

        private void procMenuSystem(
            )
        {
            FSystem fSystem = null;

            try
            {   
                fSystem = (FSystem)this.getChild(typeof(FSystem));
                if (fSystem == null)
                {
                    fSystem = new FSystem(m_fSqmCore);
                    this.showChild(fSystem);
                }
                fSystem.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSystem = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuModule(
            )
        {
            FModule fModule = null;

            try
            {   
                fModule = (FModule)this.getChild(typeof(FModule));
                if (fModule == null)
                {
                    fModule = new FModule(m_fSqmCore);
                    this.showChild(fModule);
                }
                fModule.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fModule = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuFunction(
            )
        {
            FFunction fFunction = null;

            try
            {
                fFunction = (FFunction)this.getChild(typeof(FFunction));
                if (fFunction == null)
                {
                    fFunction = new FFunction(m_fSqmCore);
                    this.showChild(fFunction);
                }
                fFunction.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fFunction = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSqlCode(
            )
        {
            FSqlCode fSqlCode = null;

            try
            {   
                fSqlCode = (FSqlCode)this.getChild(typeof(FSqlCode));
                if (fSqlCode == null)
                {
                    fSqlCode = new FSqlCode(m_fSqmCore);
                    this.showChild(fSqlCode);
                }
                fSqlCode.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlCode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSqlExplorer(
            )
        {
            FSqlExplorer fSqlExplorer = null;

            try
            {   
                fSqlExplorer = (FSqlExplorer)this.getChild(typeof(FSqlExplorer));
                if (fSqlExplorer == null)
                {
                    fSqlExplorer = new FSqlExplorer(m_fSqmCore);
                    this.showChild(fSqlExplorer);
                }
                fSqlExplorer.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlExplorer = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSqlWorksheet(
            )
        {
            FSqlWorksheet fSqlWorksheet = null;

            try
            {   
                fSqlWorksheet = new FSqlWorksheet(m_fSqmCore);
                this.showChild(fSqlWorksheet);                
                fSqlWorksheet.activate();
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

        private void procMenuSqlServiceLogFileList(
            )
        {
            FLogList fSqlServiceLogFileList = null;

            try
            {   
                fSqlServiceLogFileList = (FLogList)this.getChild(typeof(FLogList).Name);
                if (fSqlServiceLogFileList == null)
                {
                    fSqlServiceLogFileList = new FLogList(m_fSqmCore);
                    this.showChild(fSqlServiceLogFileList);
                }
                fSqlServiceLogFileList.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlServiceLogFileList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void openLog(
            FLogType logType,
            string fileName
            )
        {
            FApplicationLogViewer fApplicationLogViewer = null;
            FDebugLogViewer fDebugLogViewer = null;

            try
            {   
                if (logType == FLogType.Application)
                {
                    fApplicationLogViewer = new FApplicationLogViewer(m_fSqmCore, fileName);
                    this.showChild(fApplicationLogViewer);
                    fApplicationLogViewer.activate();
                }
                else
                {
                    fDebugLogViewer = new FDebugLogViewer(m_fSqmCore, fileName);
                    this.showChild(fDebugLogViewer);
                    fDebugLogViewer.activate();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fApplicationLogViewer = null;
                fDebugLogViewer = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuAbout(
            )
        {
            FAbout fAbout = null;

            try
            {
                fAbout = new FAbout(m_fSqmCore);
                fAbout.ShowDialog(this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fAbout != null)
                {
                    fAbout.Dispose();
                    fAbout = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuWinCloseAllWindows(
            )
        {

            try
            {
                for (int i = this.fChilds.Length - 1; i >= 0; i--)
                {
                    this.fChilds[i].Close();
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

        private void procMenuWinWindow(
            string key
            )
        {
            FBaseTabChildForm fChildForm = null;

            try
            {
                fChildForm = (FBaseTabChildForm)m_fSqmCore.fOption.fChildList.getFormOfKey(key);                
                fChildForm.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fChildForm = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------       

        private void procMenuWinMoreWindows(
            )
        {
            FFormSelector fFormSelector = null;

            try
            {
                fFormSelector = new FFormSelector(m_fSqmCore);
                fFormSelector.ShowDialog();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fFormSelector != null)
                {
                    fFormSelector.Dispose();
                    fFormSelector = null;
                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FSqmContainer Form Event Handler

        private void FSqmContainer_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                this.BeginInvoke(new MethodInvoker(
                    delegate()
                    {
                        reconnection();
                    }
                ));
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FSqmContainer_Activated(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fSqmCore == null)
                {
                    return;
                }

                // --

                setMainStatusBar();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FSqmContainer_FormClosing(
            object sender, FormClosingEventArgs e
            )
        {
            try
            {
                m_fSqmCore.fWsmCore.onMainStatusBarChanged(true);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region mnuMenu Control Event Handler

        private void mnuMenu_ToolClick(
            object sender,
            Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tool.Key == FMenuKey.MenuReconnection)
                {
                    procMenuReconnection();
                }
                else if (e.Tool.Key == FMenuKey.MenuExit)
                {
                    procMenuExit();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuSystem)
                {
                    procMenuSystem();
                }
                else if (e.Tool.Key == FMenuKey.MenuModule)
                {
                    procMenuModule();
                }
                else if (e.Tool.Key == FMenuKey.MenuFunction)
                {
                    procMenuFunction();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqlCode)
                {
                    procMenuSqlCode();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuSqlExplorer)
                {
                    procMenuSqlExplorer();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqlWorksheet)
                {
                    procMenuSqlWorksheet();
                }                
                // --
                else if (e.Tool.Key == FMenuKey.MenuSqlServiceLogList)
                {
                    procMenuSqlServiceLogFileList();
                }

                // --

                // ***
                // Window Menu
                // ***
                else if (e.Tool.Key == FMenuKey.MenuWinCloseAllWindows)
                {
                    procMenuWinCloseAllWindows();
                }                
                else if (
                    e.Tool.Key == FMenuKey.MenuWinWindow0 ||
                    e.Tool.Key == FMenuKey.MenuWinWindow1 ||
                    e.Tool.Key == FMenuKey.MenuWinWindow2 ||
                    e.Tool.Key == FMenuKey.MenuWinWindow3 ||
                    e.Tool.Key == FMenuKey.MenuWinWindow4 ||
                    e.Tool.Key == FMenuKey.MenuWinWindow5 ||
                    e.Tool.Key == FMenuKey.MenuWinWindow6 ||
                    e.Tool.Key == FMenuKey.MenuWinWindow7 ||
                    e.Tool.Key == FMenuKey.MenuWinWindow8 ||
                    e.Tool.Key == FMenuKey.MenuWinWindow9
                    )
                {
                    procMenuWinWindow((string)e.Tool.SharedProps.Tag);
                }
                else if (e.Tool.Key == FMenuKey.MenuWinMoreWindows)
                {
                    procMenuWinMoreWindows();
                }

                // --

                // ***
                // Help
                // ***
                else if (e.Tool.Key == FMenuKey.MenuAbout)
                {
                    procMenuAbout();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void mnuMenu_BeforeToolDropdown(
            object sender,
            BeforeToolDropdownEventArgs e
            )
        {
            const string MenuWinWindow = "WinWindow";

            // --

            ToolBase mnuTool = null;

            try
            {
                if (e.Tool.Key != FMenuKey.MenuWindow)
                {
                    return;
                }

                // --

                mnuMenu.beginUpdate();

                // --

                for (int i = 0; i < 10; i++)
                {
                    mnuMenu.Tools[MenuWinWindow + i.ToString()].SharedProps.Visible = false;
                }
                mnuMenu.Tools[FMenuKey.MenuWinMoreWindows].SharedProps.Visible = false;
                
                // --

                // ***
                // Control Window List
                // ***
                for (int i = 0; i < 10; i++)
                {
                    if (i >= m_fSqmCore.fOption.fChildList.count)
                    {
                        break;
                    }

                    // --

                    mnuTool = mnuMenu.Tools[MenuWinWindow + i.ToString()];
                    mnuTool.SharedProps.Tag = m_fSqmCore.fOption.fChildList.getKeyOfIndex(i);
                    mnuTool.SharedProps.Caption = "&" + (i + 1).ToString() + " " + fUIWizard .searchCaption(m_fSqmCore.fOption.fChildList.getTextOfIndex(i));
                    mnuTool.SharedProps.Visible = true;
                }                

                // --

                if (m_fSqmCore.fOption.fChildList.count > 10)
                {
                    mnuMenu.Tools[FMenuKey.MenuWinMoreWindows].SharedProps.Visible = true;
                }

                // --

                mnuMenu.endUpdate();
            }
            catch (Exception ex)
            {
                mnuMenu.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                mnuTool = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
