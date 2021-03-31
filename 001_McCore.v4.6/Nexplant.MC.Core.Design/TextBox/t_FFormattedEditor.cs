/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : t_FFormattedEditor.cs
--  Creator         : mjkim
--  Create Date     : 2014.01.16
--  Description     : FAMate Core FaUIs Formatted Text Editor Control
--  History         : Created by mjkim at 2014.01.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Infragistics.Win;
using Infragistics.Win.FormattedLinkLabel;
using Infragistics.Win.UltraWinToolbars;

namespace Nexplant.MC.Core.FaUIs
{
    public partial class FFormattedEditor : UserControl
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const int FONT_MAX_VALUE = 72;
        private const int FONT_MIN_VALUE = 8;

        // --

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FFormattedEditor(
            )
        {
            InitializeComponent();
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

        public object value
        {
            get
            {
                try
                {
                    return formattedBox.Value;
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

            set
            {
                try
                {
                    formattedBox.Value = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
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

        private void applyFontForeName(
            )
        {
            string fontName = string.Empty;

            try
            {
                fontName = ((FontListTool)mnuMenu.Tools["FontName"]).Text;

                // --

                this.formattedBox.EditInfo.ApplyStyle("Font-family: " + fontName, false);
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

        private void applyFontHighlight(
            )
        {
            PopupColorPickerTool tool;
            Color backColor;
            string hexColor = string.Empty;

            try
            {
                tool = (PopupColorPickerTool)mnuMenu.Tools["FontHighlight"];
                backColor = this.formattedBox.Appearance.BackColor;
                if (tool.Checked)
                {
                    backColor = tool.SelectedColor;
                }
                hexColor = System.Drawing.ColorTranslator.ToHtml(backColor);

                // --

                this.formattedBox.EditInfo.ApplyStyle("Background-color: " + hexColor, false);
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

        private void applyFontForeColor(
            )
        {
            Color fontColor;
            string hexColor = string.Empty;

            try
            {
                fontColor = ((PopupColorPickerTool)mnuMenu.Tools["FontColor"]).SelectedColor;
                hexColor = System.Drawing.ColorTranslator.ToHtml(fontColor);

                // --

                this.formattedBox.EditInfo.ApplyStyle("Color: " + hexColor, false);
                this.formattedBox.EditInfo.ApplyStyle("Border-color: " + hexColor, false);
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

        private void applyFontForeSize(
            )
        {
            string fontSize = string.Empty;

            try
            {
                fontSize = mskFontSize.Value.ToString();

                // --

                this.formattedBox.EditInfo.ApplyStyle("Font-size: " + fontSize + "pt", false);
                this.formattedBox.Focus();
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

        #region FFormattedEditor Form Event Handler

        private void FFormattedEditor_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                ((FontListTool)mnuMenu.Tools["FontName"]).Text = this.Font.Name;
                mskFontSize.Value = this.Font.Size;

                // --

                ((StateButtonTool)mnuMenu.Tools["Left"]).Checked = true;
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FFormattedEditor", ex, null);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FFormattedEditor_FontChanged(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                ((FontListTool)mnuMenu.Tools["FontName"]).Text = this.Font.Name;
                mskFontSize.Value = this.Font.Size;
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FFormattedEditor", ex, null);
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
            Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                switch (e.Tool.Key)
                {
                    case "Bold":
                        this.formattedBox.EditInfo.PerformAction(FormattedLinkEditorAction.ToggleBold);
                        break;

                    case "Italic":
                        this.formattedBox.EditInfo.PerformAction(FormattedLinkEditorAction.ToggleItalics);
                        break;

                    case "Underline":
                        this.formattedBox.EditInfo.PerformAction(FormattedLinkEditorAction.ToggleUnderline);
                        break;

                    case "Left":
                    case "Center":
                    case "Right":
                    case "Justify":
                        this.formattedBox.EditInfo.ApplyStyle("Text-align: " + e.Tool.Key, true);
                        break;

                    case "InsertPicture":
                        this.formattedBox.EditInfo.ShowImageDialog();
                        break;

                    case "Hyperlink":
                        this.formattedBox.EditInfo.ShowLinkDialog();
                        break;

                    case "Paste":
                        this.formattedBox.EditInfo.PerformAction(FormattedLinkEditorAction.Paste);
                        break;

                    case "ShowImageDialog":
                        this.formattedBox.EditInfo.ShowImageDialog();
                        break;

                    case "FontHighlight":
                        applyFontHighlight();
                        break;

                    case "FontColor":
                        applyFontForeColor();
                        break;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FFormattedEditor", ex, null);
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

                switch (e.Tool.Key)
                {
                    case "FontName":
                        applyFontForeName();
                        break;

                    case "FontHighlight":
                        applyFontHighlight();
                        break;

                    case "FontColor":
                        applyFontForeColor();
                        break;
                }
                // --
                this.formattedBox.Focus();
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FFormattedEditor", ex, null);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region formattedBox Control Event Handler

        private void formattedBox_EditStateChanged(
            object sender, 
            EditStateChangedEventArgs e
            )
        {
            StyleInfo si;

            try
            {
                FCursor.waitCursor();

                // --

                this.mnuMenu.EventManager.SetEnabled(ToolbarEventIds.ToolClick, false);

                // --

                #region Update Format Button States

                si = this.formattedBox.EditInfo.GetCurrentStyle();
                // --
                ((StateButtonTool)this.mnuMenu.Tools["Bold"]).Checked =
                    si.Appearance.FontData.Bold == DefaultableBoolean.True ? true : false;

                ((StateButtonTool)this.mnuMenu.Tools["Italic"]).Checked =
                    si.Appearance.FontData.Italic == DefaultableBoolean.True ? true : false;

                ((StateButtonTool)this.mnuMenu.Tools["Underline"]).Checked =
                    si.Appearance.FontData.Underline == DefaultableBoolean.True ? true : false;

                ((StateButtonTool)this.mnuMenu.Tools["Left"]).Checked =
                    si.LineAlignment == LineAlignment.Left || si.LineAlignment == LineAlignment.Default;

                ((StateButtonTool)this.mnuMenu.Tools["Center"]).Checked =
                    si.LineAlignment == LineAlignment.Center;

                ((StateButtonTool)this.mnuMenu.Tools["Right"]).Checked =
                    si.LineAlignment == LineAlignment.Right;

                ((StateButtonTool)this.mnuMenu.Tools["Justify"]).Checked =
                    si.LineAlignment == LineAlignment.Justify;

                #endregion //Update Format Button States

                // --

                this.mnuMenu.EventManager.SetEnabled(ToolbarEventIds.ToolClick, true);
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FFormattedEditor", ex, null);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region mskFontSize Control Event Handler

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
                    mskFontSize.Value = fontSize < FONT_MAX_VALUE ? (int)++fontSize : FONT_MAX_VALUE;
                }
                else if (e.ButtonType == Infragistics.Win.UltraWinEditors.SpinButtonItem.PreviousItem)
                {
                    mskFontSize.Value = fontSize > FONT_MIN_VALUE ? (int)--fontSize : FONT_MIN_VALUE;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FFormattedEditor", ex, null);
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

                applyFontForeSize();
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FFormattedEditor", ex, null);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

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
                if (fontSize < FONT_MIN_VALUE)
                {
                    mskFontSize.Value = FONT_MIN_VALUE;
                }
                else if (fontSize > FONT_MAX_VALUE)
                {
                    mskFontSize.Value = FONT_MAX_VALUE;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FFormattedEditor", ex, null);
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
                    this.formattedBox.Focus();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FFormattedEditor", ex, null);
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
