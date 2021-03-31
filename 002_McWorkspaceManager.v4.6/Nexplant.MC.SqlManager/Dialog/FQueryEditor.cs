/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FQueryEditor.cs
--  Creator         : mjkim
--  Create Date     : 2012.12.12
--  Description     : FAMate SQL Manager Query Editor Form Class 
--  History         : Created by mjkim at 2012.12.12
 ----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinToolbars;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.SqlManager
{
    public partial class FQueryEditor : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        
        private FSqmCore m_fSqmCore = null;
        private string m_query = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FQueryEditor(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FQueryEditor(
            FSqmCore fSqmCore,            
            string query,
            string usedMigration
            )
            : this()
        {
            base.fUIWizard = fSqmCore.fUIWizard;
            m_fSqmCore = fSqmCore;
            m_query = query;
            // --
            if (usedMigration == FYesNo.No.ToString())
            {
                fcbCopyQuery.Enabled = false;
            }
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
                    m_fSqmCore = null;
                    m_query = null;
                }
                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public string query
        {
            get
            {
                try
                {
                    return txtQuery.Text;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool copyToOtherQuery
        {
            get
            {
                try
                {
                    return fcbCopyQuery.Checked;
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

        private void setTitle(
            )
        {
            try
            {
                this.Text = m_fSqmCore.fWsmCore.fUIWizard.searchCaption(this.Text);
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

        private void procMenuClear(
            )
        {
            try
            {
                txtQuery.Text = string.Empty;
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

        private void procMenuComment(
            )
        {
            try
            {
                sqlRefactoring(FConstants.SqlCommentChars);
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

        private void procMenuCommentRemove(
            )
        {
            try
            {
                sqlRefactoringRemove(FConstants.SqlCommentChars);
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

        private void procMenuIndent(
            )
        {
            try
            {
                sqlRefactoring(FConstants.SqlIndentChars);
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

        private void procMenuIndentRemove(
            )
        {
            string[] lineSeparator = { Environment.NewLine };
            string[] selectedText = null;
            string finalText = string.Empty;
            int selectionStart = 0;
            int selectionLength = 0;
            int caretPosition = 0;
            bool notApplied = false;

            try
            {
                foreach (string originalText in txtQuery.Text.Split(lineSeparator, StringSplitOptions.None))
                {
                    if (txtQuery.SelectionLength == 0)
                    {
                        if (
                            txtQuery.SelectionStart >= caretPosition &&
                            txtQuery.SelectionStart < caretPosition + originalText.Length + 1
                           )
                        {
                            if (originalText.IndexOf(FConstants.SqlIndentChars) > -1)
                            {
                                finalText += originalText.Substring(FConstants.SqlIndentChars.Length);
                                selectionLength = originalText.Length - FConstants.SqlIndentChars.Length;
                            }
                            else
                            {
                                finalText += originalText.TrimStart();
                                selectionLength = finalText.Length;

                            }
                            selectionStart = caretPosition;
                        }
                        else
                        {
                            finalText += originalText;
                        }
                    }
                    else
                    {
                        notApplied = true;
                        selectedText = txtQuery.SelectedText.Split(lineSeparator, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < selectedText.Length; i++)
                        {
                            if (originalText.IndexOf(selectedText[i]) > -1)
                            {
                                notApplied = false;
                                if (originalText.IndexOf(FConstants.SqlIndentChars) > -1)
                                {
                                    finalText += originalText.Substring(FConstants.SqlIndentChars.Length);
                                    selectionLength += (originalText.Length + Environment.NewLine.Length) - FConstants.SqlIndentChars.Length;
                                }
                                else
                                {
                                    finalText += originalText.TrimStart();
                                    selectionLength += (originalText.TrimStart().Length + Environment.NewLine.Length);
                                }
                                if (i == 0)
                                {
                                    selectionStart = caretPosition;
                                }
                                break;
                            }
                        }
                        if (notApplied == true)
                        {
                            finalText += originalText;
                        }
                    }
                    finalText += Environment.NewLine;
                    caretPosition += originalText.Length + Environment.NewLine.Length;
                }

                txtQuery.Text = finalText.TrimEnd();
                txtQuery.Select(selectionStart, selectionLength);
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

        private void procMenuToUpperLowerInitCap(
            )
        {
            string[] lineSeparator = { Environment.NewLine };
            string[] words = null;
            char[] wordSeparator = { ' ' };
            char[] charsToTrim = { '\r', '\n' };
            string finalText = string.Empty;
            int selectionStart = 0;
            int selectionLength = 0;
            int caretPosition = 0;

            try
            {
                if (txtQuery.SelectionLength == 0)
                {
                    return;
                }

                selectionStart = txtQuery.SelectionStart;
                selectionLength = txtQuery.SelectedText.TrimEnd(charsToTrim).Length;
                foreach (string line in txtQuery.Text.Split(lineSeparator, StringSplitOptions.None))
                {
                    words = line.Split(wordSeparator);
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (
                            selectionStart <= caretPosition &&
                            selectionStart + selectionLength >= caretPosition + words[i].Length
                           )
                        {
                            if (words[i] == words[i].ToUpper())
                            {
                                finalText += words[i].ToLower();
                            }
                            else if (words[i] == words[i].ToLower())
                            {
                                finalText += words[i].ToUpperInvariant();
                            }
                            else if (words[i] == words[i].ToUpperInvariant())
                            {
                                finalText += words[i].ToUpper();
                            }
                            else
                            {
                                finalText += words[i];
                            }
                        }
                        else
                        {
                            finalText += words[i];
                        }
                        caretPosition += words[i].Length;
                        if (i < words.Length - 1)
                        {
                            finalText += wordSeparator[0].ToString();
                            caretPosition += wordSeparator[0].ToString().Length;
                        }
                    }
                    finalText += Environment.NewLine;
                    caretPosition += Environment.NewLine.Length;
                }

                txtQuery.Text = finalText.TrimEnd();
                txtQuery.Select(selectionStart, selectionLength);
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
                txtQuery.Appearance.FontData.Name = (new System.Drawing.FontFamily(preFontName)).Name;
                m_fSqmCore.fOption.fontName = preFontName;
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
                txtQuery.Appearance.FontData.SizeInPoints = float.Parse(mskFontSize.Value.ToString());
                m_fSqmCore.fOption.fontSize = float.Parse(mskFontSize.Value.ToString());
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

        private void sqlRefactoringRemove(
            string s
            )
        {
            string[] lineSeparator = { Environment.NewLine };
            string[] selectedText = null;
            string finalText = string.Empty;
            int selectionStart = 0;
            int selectionLength = 0;
            int caretPosition = 0;
            bool notApplied = false;

            try
            {
                foreach (string originalText in txtQuery.Text.Split(lineSeparator, StringSplitOptions.None))
                {
                    if (txtQuery.SelectionLength == 0)
                    {
                        if (
                            txtQuery.SelectionStart >= caretPosition &&
                            txtQuery.SelectionStart < caretPosition + originalText.Length + 1
                           )
                        {
                            if (originalText.IndexOf(s) > -1)
                            {
                                finalText += originalText.Substring(s.Length);
                                selectionLength = originalText.Length - s.Length;
                            }
                            else
                            {
                                finalText += originalText;
                                selectionLength = originalText.Length;

                            }
                            selectionStart = caretPosition;
                        }
                        else
                        {
                            finalText += originalText;
                        }
                    }
                    else
                    {
                        notApplied = true;
                        selectedText = txtQuery.SelectedText.Split(lineSeparator, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < selectedText.Length; i++)
                        {
                            if (originalText.IndexOf(selectedText[i]) > -1)
                            {
                                notApplied = false;
                                if (originalText.IndexOf(s) > -1)
                                {
                                    finalText += originalText.Substring(s.Length);
                                    selectionLength += (originalText.Length + Environment.NewLine.Length) - s.Length;
                                }
                                else
                                {
                                    finalText += originalText;
                                    selectionLength += (originalText.Length + Environment.NewLine.Length);
                                }
                                if (i == 0)
                                {
                                    selectionStart = caretPosition;
                                }
                                break;
                            }
                        }
                        if (notApplied == true)
                        {
                            finalText += originalText;
                        }
                    }
                    finalText += Environment.NewLine;
                    caretPosition += originalText.Length + Environment.NewLine.Length;
                }

                txtQuery.Text = finalText.TrimEnd();
                txtQuery.Select(selectionStart, selectionLength);
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

        private void sqlRefactoring(
            string s
            )
        {
            string[] lineSeparator = { Environment.NewLine };
            string[] selectedText = null;
            string finalText = string.Empty;
            int selectionStart = 0;
            int selectionLength = 0;
            int caretPosition = 0;

            try
            {
                foreach (string originalText in txtQuery.Text.Split(lineSeparator, StringSplitOptions.None))
                {
                    if (txtQuery.SelectionLength == 0)
                    {
                        if (
                            txtQuery.SelectionStart >= caretPosition &&
                            txtQuery.SelectionStart < caretPosition + originalText.Length + 1
                           )
                        {
                            finalText += s;
                            selectionStart = caretPosition;
                            selectionLength = originalText.Length + s.Length;
                        }
                    }
                    else
                    {
                        selectedText = txtQuery.SelectedText.Split(lineSeparator, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < selectedText.Length; i++)
                        {
                            if (originalText.IndexOf(selectedText[i]) > -1)
                            {
                                finalText += s;
                                if (i == 0)
                                {
                                    selectionStart = caretPosition;
                                }
                                selectionLength += (originalText.Length + Environment.NewLine.Length) + s.Length;
                                break;
                            }
                        }
                    }
                    finalText += originalText;
                    finalText += Environment.NewLine;
                    caretPosition += originalText.Length + Environment.NewLine.Length;
                }

                txtQuery.Text = finalText.TrimEnd();
                txtQuery.Select(selectionStart, selectionLength);
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

        #region FQueryEditor Form Event Handler

        private void FQueryEditor_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                ((FontListTool)mnuMenu.Tools[FMenuKey.MenuFontName]).Text = m_fSqmCore.fOption.fontName;
                mskFontSize.Value = m_fSqmCore.fOption.fontSize;

                // --

                txtQuery.Appearance.FontData.Name = ((FontListTool)mnuMenu.Tools[FMenuKey.MenuFontName]).Text;
                txtQuery.Appearance.FontData.SizeInPoints = float.Parse(mskFontSize.Value.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FQueryEditor_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                txtQuery.Text = m_query;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                FCursor.defaultCursor();
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

                if (e.Tool.Key == FMenuKey.MenuSqwClear)
                {
                    procMenuClear();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqwToUpperLowerInitCap)
                {
                    procMenuToUpperLowerInitCap();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqwComment)
                {
                    procMenuComment();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqwCommentRemove)
                {
                    procMenuCommentRemove();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqwIndent)
                {
                    procMenuIndent();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqwIndentRemove)
                {
                    procMenuIndentRemove();
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
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
                        ((FontListTool)mnuMenu.Tools[FMenuKey.MenuFontName]).Value = m_fSqmCore.fOption.fontName;
                        txtQuery.Appearance.FontData.Name = m_fSqmCore.fOption.fontName;
                    }
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

        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

        #region  btnOk Control Event Handler

        private void btnOk_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --
                
                this.DialogResult = DialogResult.OK;
                this.Close();
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region mskFontSize Control Event Handler

        private void mskFontSize_BeforeExitEditMode(
            object sender, 
            Infragistics.Win.BeforeExitEditModeEventArgs e
            )
        {
            float fontSize = 0;

            try
            {
                FCursor.waitCursor();

                // --

                fontSize = float.Parse(mskFontSize.Value.ToString());
                if (fontSize < FConstants.FontMinSize)
                {
                    mskFontSize.Value = FConstants.FontMinSize;
                }
                else if (fontSize > FConstants.FontMaxSize)
                {
                    mskFontSize.Value = FConstants.FontMaxSize;
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

        private void mskFontSize_ValueChanged(
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void mskFontSize_EditorSpinButtonClick(
            object sender,
            Infragistics.Win.UltraWinEditors.SpinButtonClickEventArgs e
            )
        {
            float fontSize = 0;

            try
            {
                FCursor.waitCursor();

                // --

                fontSize = float.Parse(mskFontSize.Value.ToString());
                if (e.ButtonType == Infragistics.Win.UltraWinEditors.SpinButtonItem.NextItem)
                {
                    mskFontSize.Value = fontSize < FConstants.FontMaxSize ? (int)++fontSize : FConstants.FontMaxSize;
                }
                else if (e.ButtonType == Infragistics.Win.UltraWinEditors.SpinButtonItem.PreviousItem)
                {
                    mskFontSize.Value = fontSize > FConstants.FontMinSize ? (int)--fontSize : FConstants.FontMinSize;
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

        private void mskFontSize_KeyDown(
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
                    txtQuery.Focus();
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

        #endregion               

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end