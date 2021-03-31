/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FScgContainer.cs
--  Creator         : baehyun seo
--  Create Date     : 2011.09.30
--  Description     : FAMate Source Generator Main Form Class
--  History         : Created by baehyun seo at 2011.09.30
                    : Modified by kitae at 2012.03.20
                        - Recent Library 
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.WorkspaceInterface;
using Infragistics.Win.UltraWinToolbars;

namespace Nexplant.MC.SourceGenerator
{
    public partial class FScgContainer : FBaseTabMdiChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        private string m_fileName = string.Empty;
        // --
        private FScgCore m_fScgCore = null;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FScgContainer(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FScgContainer(
            FIWsmCore fWsmCore
            )
            : this()
        {
            base.fUIWizard = fWsmCore.fUIWizard;
            m_fScgCore = new FScgCore(fWsmCore, this);
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FScgContainer(
            FIWsmCore fWsmCore,
            string fileName
            )
            : this(fWsmCore)
        {
            m_fileName = fileName;
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
                    if (m_fScgCore != null)
                    {
                        m_fScgCore.Dispose();
                        m_fScgCore = null;
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

        private void setMainStatusBar(
            )
        {
            System.Reflection.Assembly assembly = null;
            string caption = string.Empty;
            string version = string.Empty;

            try
            {
                caption = m_fScgCore.fUIWizard.searchCaption(FConstants.ApplicationName);

                // --

                assembly = System.Reflection.Assembly.GetCallingAssembly();
                if (assembly != null)
                {
                    version = assembly.GetName().Version.ToString();
                }

                // --

                m_fScgCore.fWsmCore.onMainStatusBarChanged(
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

        public void openSourceGenerate(
            string fileName
            )
        {
            FSourceGenerate fSourceGenerator = null;

            try
            {
                foreach (FBaseTabChildForm f in this.fChilds)
                {
                    if (f is FSourceGenerate)
                    {
                        fSourceGenerator = (FSourceGenerate)f;
                        if (Path.GetFileName(fSourceGenerator.fileName) == Path.GetFileName(fileName))
                        {
                            fSourceGenerator.refreshGenerate();
                            fSourceGenerator.activate();
                            return;
                        }
                    }                    
                }

                // --

                fSourceGenerator = new FSourceGenerate(m_fScgCore, fileName);
                this.showChild(fSourceGenerator);
                fSourceGenerator.activate();      
          
                // --

                m_fScgCore.fOption.recentOpenPath = Path.GetDirectoryName(fileName);
                changeRecentGenFile(fileName);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSourceGenerator = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void procMenuNew(
            )
        {
            const string DefaultFileName = "FAmateXmlTagGenerateFile{0}.gen";
            
            // --

            FSourceEditor fSourceEditor = null;
            string fileName = string.Empty;

            try
            {
                fileName = string.Format(DefaultFileName, m_fScgCore.fFileIdPointer.uniqueId.ToString());
                // --
                fSourceEditor = new FSourceEditor(m_fScgCore, true, false, fileName);
                this.showChild(fSourceEditor);
                fSourceEditor.activate();                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSourceEditor = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuOpen(
            )
        {
            OpenFileDialog dialog = null;
            FSourceEditor fSourceEditor = null;

            try
            {
                dialog = new OpenFileDialog();
                // --
                dialog.Title = fUIWizard.searchCaption("Open Source Generator File");
                dialog.Filter = "Source Generator Files | *.gen";
                dialog.DefaultExt = "gen";
                dialog.InitialDirectory = m_fScgCore.fOption.recentOpenPath;
                // --
                if (dialog.ShowDialog(m_fScgCore.fWsmCore.fWsmContainer) == DialogResult.Cancel)
                {
                    return;
                }

                // --

                foreach (FBaseTabChildForm fBaseEdit in this.fChilds)
                {
                    if (fBaseEdit is FSourceEditor)
                    {
                        fSourceEditor = (FSourceEditor)fBaseEdit;
                        if (fSourceEditor.fileName == dialog.FileName)
                        {
                            fSourceEditor.refreshEditor(dialog.FileName);
                            fSourceEditor.activate();
                            return;
                        }
                    }                    
                }

                // --

                fSourceEditor = new FSourceEditor(m_fScgCore, false, true, dialog.FileName);
                this.showChild(fSourceEditor);
                fSourceEditor.activate();

                // --

                m_fScgCore.fOption.recentOpenPath = Path.GetDirectoryName(dialog.FileName);
                changeRecentGenFile(dialog.FileName);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (dialog != null)
                {
                    dialog.Dispose();
                    dialog = null;
                }
                fSourceEditor = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuGenerate(
            )
        {
            OpenFileDialog dialog = null;

            try
            {
                dialog = new OpenFileDialog();
                dialog.InitialDirectory = m_fScgCore.fOption.recentOpenPath;
                dialog.Title = fUIWizard.searchCaption("Open Generate File");
                dialog.Filter = "Generate Files (*.gen) | *.gen";
                dialog.DefaultExt = "gen";

                // --

                if (dialog.ShowDialog(m_fScgCore.fWsmCore.fWsmContainer) == DialogResult.Cancel)
                {
                    return;
                }

                // --

                openSourceGenerate(dialog.FileName);
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

        private void procMenuAbout(
            )
        {
            FAbout fAbout = null;

            try
            {
                fAbout = new FAbout(m_fScgCore);
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

        private void changeRecentGenFile(
            string fileName
            )
        {
            try
            {
                if (m_fScgCore.fOption.recentGenFileList.Contains(fileName))
                {
                    m_fScgCore.fOption.recentGenFileList.Remove(fileName);
                }
                else if (m_fScgCore.fOption.recentGenFileList.Count == FConstants.RecentMaxCount)
                {
                    m_fScgCore.fOption.recentGenFileList.RemoveAt(m_fScgCore.fOption.recentGenFileList.Count - 1);
                }
                m_fScgCore.fOption.recentGenFileList.Insert(0, fileName);

                // --

                m_fScgCore.fWsmOption.recentFile = fileName;
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

        private void procMenuRecentFile(
            string fileName
            )
        {
            FSourceEditor fSourceEditor = null;     

            try
            {
                if (!File.Exists(fileName))
                {
                    FMessageBox.showError(
                        FConstants.ApplicationName,
                        m_fScgCore.fWsmCore.fUIWizard.generateMessage("E0010", new object[] { fileName }),
                        m_fScgCore.fWsmCore.fWsmContainer
                        );
                    // --
                    if (m_fScgCore.fOption.recentGenFileList.Contains(fileName))
                    {
                        m_fScgCore.fOption.recentGenFileList.Remove(fileName);
                    }
                    // --
                    return;
                }

                // --

                fSourceEditor = new FSourceEditor(m_fScgCore, false, true, fileName);
                this.showChild(fSourceEditor);
                fSourceEditor.activate();

                // --

                m_fScgCore.fOption.recentOpenPath = Path.GetDirectoryName(fileName);
                changeRecentGenFile(fileName);
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

        private string reduceFileName(
            string fileName
            )
        {
            string filePath = string.Empty;
            string dfileName = string.Empty;
            List<string> arrfilePath = null;

            try
            {
                if (fileName.Length > 40)
                {
                    arrfilePath = new List<string>((Path.GetDirectoryName(fileName)).Split('\\'));
                    arrfilePath.Reverse();
                    // --
                    dfileName = Path.GetFileName(fileName);

                    // --

                    foreach (string tfilePath in arrfilePath)
                    {
                        if (dfileName.Length < 40)
                        {
                            dfileName = tfilePath + @"\" + dfileName;
                        }
                    }

                    // --

                    return @"..\" + dfileName;
                }
                else
                {
                    return fileName;
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return string.Empty;
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
                fChildForm = (FBaseTabChildForm)m_fScgCore.fOption.fChildFormList.getFormOfKey(key);                
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
                dialog = new FFormSelector(m_fScgCore);
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

        #region FScgContainer Form Event Handler

        private void FScgContainer_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                mnuMenu.ImageListSmall = new ImageList();
                // --
                mnuMenu.ImageListSmall.Images.Add("File_Gen", Properties.Resources.File_Gen);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fScgCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FScgContainer_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fileName != string.Empty)
                {
                    openSourceGenerate(m_fileName);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fScgCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FScgContainer_Activated(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fScgCore == null)
                {
                    return;
                }

                // --

                setMainStatusBar();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fScgCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FScgContainer_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                m_fScgCore.fWsmCore.onMainStatusBarChanged(true);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fScgCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region mnuMenu Control Event Handler

        private void mnuMenu_BeforeToolDropdown(
           object sender,
           Infragistics.Win.UltraWinToolbars.BeforeToolDropdownEventArgs e
           )
        {
            const string MenuWinWindow = "WinWindow";
            // --
            ToolBase mnuTool = null;
            PopupMenuTool popMenuTool = null;

            try
            {
                FCursor.waitCursor();

                // --

                mnuMenu.beginUpdate();

                // --

                if (e.Tool.Key == FMenuKey.MenuFile)
                {
                    popMenuTool = (PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuRecentFile];
                    popMenuTool.Tools.Clear();
                    // --
                    foreach (string s in m_fScgCore.fOption.recentGenFileList)
                    {
                        if (!mnuMenu.Tools.Exists(s))
                        {
                            mnuMenu.Tools.Add(new ButtonTool(s));
                        }
                        mnuTool = mnuMenu.Tools[s];
                        mnuTool.SharedProps.Caption = reduceFileName(s);
                        mnuTool.SharedProps.AppearancesSmall.Appearance.Image = mnuMenu.ImageListSmall.Images["File_Gen"];
                        popMenuTool.Tools.AddTool(s);
                    }
                    // --
                    popMenuTool.SharedProps.Enabled = popMenuTool.Tools.Count > 0 ? true : false;
                }
                else if (e.Tool.Key == FMenuKey.MenuWindow)
                {
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
                        if (i >= m_fScgCore.fOption.fChildFormList.count)
                        {
                            break;
                        }

                        // --

                        mnuTool = mnuMenu.Tools[MenuWinWindow + i.ToString()];
                        mnuTool.SharedProps.Tag = m_fScgCore.fOption.fChildFormList.getKeyOfIndex(i);
                        mnuTool.SharedProps.Caption = "&" + (i + 1).ToString() + " " + fUIWizard.searchCaption(m_fScgCore.fOption.fChildFormList.getTextOfIndex(i));
                        mnuTool.SharedProps.Visible = true;
                    }                    

                    // --

                    if (m_fScgCore.fOption.fChildFormList.count > 10)
                    {
                        mnuMenu.Tools[FMenuKey.MenuWinMoreWindows].SharedProps.Visible = true;
                    }
                }

                // --

                mnuMenu.endUpdate();
            }
            catch (Exception ex)
            {
                mnuMenu.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fScgCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                mnuTool = null;
                popMenuTool = null;
                // --
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void mnuMenu_ToolClick(
            object sender,
            Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tool.Key == FMenuKey.MenuNew)
                {
                    procMenuNew();
                }
                else if (e.Tool.Key == FMenuKey.MenuOpen)
                {
                    procMenuOpen();
                }
                else if (e.Tool.Key == FMenuKey.MenuTreeView)
                {
                    procMenuGenerate();
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
                
                else if (e.Tool.Key == FMenuKey.MenuAbout)
                {
                    procMenuAbout();
                }

                // --

                // ***
                // Recent File
                // ***
                else 
                {
                    procMenuRecentFile(e.Tool.Key);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fScgCore.fWsmCore.fWsmContainer);
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
