/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FAlvContainer.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.11
--  Description     : FAMate Application Log Viewer Container Form Class 
--  History         : Created by spike.lee at 2011.01.11
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.WorkspaceInterface;
using Infragistics.Win.UltraWinToolbars;

namespace Nexplant.MC.ApplicationLogViewer
{
    public partial class FAlvContainer : FBaseTabMdiChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAlvCore m_fAlvCore = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FAlvContainer(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FAlvContainer(
            FIWsmCore fWsmCore
            )
            : this()
        {
            base.fUIWizard = fWsmCore.fUIWizard;
            m_fAlvCore = new FAlvCore(fWsmCore, this);
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
                    if (m_fAlvCore != null)
                    {
                        m_fAlvCore.Dispose();
                        m_fAlvCore = null;
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

        private void setMainStatusBar(
            )
        {
            System.Reflection.Assembly assembly = null;
            string caption = string.Empty;
            string version = string.Empty;

            try
            {
                caption = m_fAlvCore.fUIWizard.searchCaption(FConstants.ApplicationName);

                // --

                assembly = System.Reflection.Assembly.GetCallingAssembly();
                if (assembly != null)
                {
                    version = assembly.GetName().Version.ToString();
                }

                // --

                m_fAlvCore.fWsmCore.onMainStatusBarChanged(
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

        private void loadLogList(
            )
        {
            FLogList fLogList = null;

            try
            {
                fLogList = new FLogList(m_fAlvCore);
                this.showChild(fLogList);
                fLogList.activate();
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

        private void procMenuLogList(
            )
        {
            FLogList fLogList = null;

            try
            {
                fLogList = (FLogList)this.getChild(typeof(FLogList).Name);
                if (fLogList == null)
                {
                    fLogList = new FLogList(m_fAlvCore);
                    this.showChild(fLogList);
                }
                fLogList.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fLogList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuAbout(
            )
        {
            FAbout fAbout = null;

            try
            {
                fAbout = new FAbout(m_fAlvCore);
                fAbout.ShowDialog(this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fAbout = null;
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
                fChildForm = (FBaseTabChildForm)m_fAlvCore.fOption.fChildFormList.getFormOfKey(key);                
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
            FFormSelector dialog = null;

            try
            {
                dialog = new FFormSelector(m_fAlvCore);
                dialog.ShowDialog();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                dialog = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FAlvContainer Form Event Handler

        private void FAlvContainer_Activated(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fAlvCore == null)
                {
                    return;
                }

                // --

                setMainStatusBar();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAlvCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FAlvContainer_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                loadLogList();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAlvCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FAlvContainer_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                m_fAlvCore.fWsmCore.onMainStatusBarChanged(true);
                // --
                if (m_fAlvCore != null)
                {
                    m_fAlvCore.Dispose();
                    m_fAlvCore = null;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAlvCore.fWsmCore.fWsmContainer);
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

                if (e.Tool.Key == FMenuKey.MenuExit)
                {
                    this.Close();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuLogList)
                {
                    procMenuLogList();
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAlvCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void mnuMenu_BeforeToolDropdown(
            object sender, 
            Infragistics.Win.UltraWinToolbars.BeforeToolDropdownEventArgs e
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
                    if (i >= m_fAlvCore.fOption.fChildFormList.count)
                    {
                        break;
                    }

                    // --

                    mnuTool = mnuMenu.Tools[MenuWinWindow + i.ToString()];
                    mnuTool.SharedProps.Tag = m_fAlvCore.fOption.fChildFormList.getKeyOfIndex(i);
                    mnuTool.SharedProps.Caption = "&" + (i + 1).ToString() + " " + fUIWizard .searchCaption(m_fAlvCore.fOption.fChildFormList.getTextOfIndex(i));
                    mnuTool.SharedProps.Visible = true;
                }                

                // --

                if (m_fAlvCore.fOption.fChildFormList.count > 10)
                {
                    mnuMenu.Tools[FMenuKey.MenuWinMoreWindows].SharedProps.Visible = true;
                }

                // --

                mnuMenu.endUpdate();
            }
            catch (Exception ex)
            {
                mnuMenu.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAlvCore.fWsmCore.fWsmContainer);
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
