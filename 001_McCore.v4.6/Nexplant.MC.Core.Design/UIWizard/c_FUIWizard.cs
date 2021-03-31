/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FUIWizard.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.30
--  Description     : FAMate Core FaUIs UI Wizard Class
--  History         : Created by spike.lee at 2010.12.30
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;
using System.ComponentModel;
using Nexplant.MC.Core.FaCommon;
using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinExplorerBar;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.FormattedLinkLabel;

namespace Nexplant.MC.Core.FaUIs
{
    public class FUIWizard : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        public event FLanguageChangedEventHandler LanguageChanged = null;        
        public event FFontNameChangedEventHandler FontNameChanged = null;        

        // --

        private bool m_disposed = false;
        // --
        private string m_languageFileName = string.Empty;
        private string m_language = string.Empty;
        private string m_fontName = string.Empty;
        private FXmlDocument m_fXmlDocLanguage = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FUIWizard(            
            string languageFileName,
            string language,
            string fontName
            )
        {
            m_languageFileName = languageFileName;
            m_language = language;
            m_fontName = fontName;
            // --
            init();
        }        

        //------------------------------------------------------------------------------------------------------------------------

        ~FUIWizard(
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

        public string languageFileName
        {
            get
            {
                try
                {
                    return m_languageFileName;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string language
        {
            get
            {
                try
                {
                    return m_language;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string fontName
        {
            get
            {
                try
                {
                    return m_fontName;
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            try
            {
                m_fXmlDocLanguage = new FXmlDocument();
                m_fXmlDocLanguage.preserveWhiteSpace = false;
                m_fXmlDocLanguage.load(m_languageFileName);
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
                if (m_fXmlDocLanguage != null)
                {
                    m_fXmlDocLanguage.Dispose();
                    m_fXmlDocLanguage = null;
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

        public void onLanguageChanged(
            string language
            )
        {
            try
            {
                m_language = language;
                // --
                if (LanguageChanged != null)
                {
                    LanguageChanged(this, new FLanguageChangedEventArgs(language));
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

        public void onFontNameChanged(
            string fontName
            )
        {
            try
            {
                m_fontName = fontName;
                // --
                if (FontNameChanged != null)
                {
                    FontNameChanged(this, new FFontNameChangedEventArgs(fontName));
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

        public string searchCaption(            
            string caption            
            )
        {
            try
            {
                return searchCaption(m_language, caption);
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

        public string searchCaption(
            string language,
            string caption            
            )
        {
            const string XPathFormat =
                FXmlTagFAMate.E_FAMate +
                "/" + FXmlTagCaptionGroup.E_CaptionGroup +
                "/" + FXmlTagCaption.E_Caption + "[@*='{0}']";

            FXmlNode fXmlNodeCap = null;            
            string oldCaption = string.Empty;
            string newCaption = string.Empty;

            try
            {
                if (caption.IndexOf("'") > -1)
                {
                    return caption;
                }

                // --

                // ***
                // 2013.05.28 by spike.lee
                // Caption의 앞에 Space만 제거하도록 변경
                // (Language 변경시, 용어가 변경되지 않는 경우 지원 하도록 처리, 문제 발생시 Trim으로 복귀 필요)
                // ***
                oldCaption = caption.TrimStart();

                // --

                fXmlNodeCap = m_fXmlDocLanguage.selectSingleNode(string.Format(XPathFormat, oldCaption));
                if (fXmlNodeCap == null)
                {
                    return caption;
                }

                // --

                newCaption = fXmlNodeCap.get_attrVal(language, FXmlTagCaption.D_Language);
                if (newCaption == string.Empty)
                {
                    return caption;
                }
                return caption.Replace(oldCaption, newCaption);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeCap != null)
                {
                    fXmlNodeCap.Dispose();
                    fXmlNodeCap = null;
                }
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string searchMessage(
            string messageId
            )
        {
            try
            {
                return searchMessage(m_language, messageId);
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

        public string searchMessage(
            string language,
            string messageId            
            )
        {
            const string XPathFormat =
                FXmlTagFAMate.E_FAMate +
                "/" + FXmlTagMessageGroup.E_MessageGroup +
                "/" + FXmlTagMessage.E_Message + "[@" + FXmlTagMessage.A_MessageId + "='{0}']";

            FXmlNode fXmlNodeMsg = null;
            string message = string.Empty;

            try
            {
                fXmlNodeMsg = m_fXmlDocLanguage.selectSingleNode(string.Format(XPathFormat, messageId));
                if (fXmlNodeMsg == null)
                {
                    return string.Empty;
                }

                // --

                // ***
                // 2012.12.12 by spike.lee
                // Language에 해당하는 Message가 없을 경우 Default Message를 Return하도록 수정
                // ***
                message = fXmlNodeMsg.get_attrVal(language, FXmlTagMessage.D_Language);
                if (message == string.Empty)
                {
                    return fXmlNodeMsg.get_attrVal("Default", FXmlTagMessage.D_Language);
                }
                return message;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeMsg != null)
                {
                    fXmlNodeMsg.Dispose();
                    fXmlNodeMsg = null;
                }
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string generateMessage(
            string messageId, 
            params object[] args
            )
        {
            try
            {
                return generateMessage(m_language, messageId, args);
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

        public string generateMessage(
            string language,
            string messageId,
            params object[] args
            )
        {
            string message = string.Empty;

            try
            {
                message = searchMessage(language, messageId);
                if (args == null || args.Length == 0)
                {
                    return message;
                }

                // --

                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] is string)
                    {
                        args[i] = searchCaption(language, (string)args[i]);
                    }
                }
                return string.Format(message, args);
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

        public string generateMessage(
            string messageId
            )
        {
            try
            {
                return generateMessage(m_language, messageId, null);
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

        public string generateMessage(
            string language,
            string messageId
            )
        {
            try
            {
                return generateMessage(language, messageId, null);
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

        public void changeControlFontName(            
            object control
            )
        {
            Type type = null;
            PropertyInfo propInfo = null;
            Infragistics.Win.Appearance appearance = null;
            Font font = null;

            try
            {
                type = control.GetType();

                // --

                if ((propInfo = type.GetProperty("Appearance")) != null)
                {
                    appearance = (Infragistics.Win.Appearance)propInfo.GetValue(control, null);
                    appearance.FontData.Name = m_fontName;
                }
                else if ((propInfo = type.GetProperty("Font")) != null)
                {
                    font = (Font)propInfo.GetValue(control, null);
                    font = new Font(m_fontName, font.Size, font.Style);
                    propInfo.SetValue(control, font, null);
                }

                // --

                if (control is Control)
                {
                    foreach (Control c in ((Control)control).Controls)
                    {
                        if (c is Form)
                        {
                            continue;
                        }                        
                        changeControlFontName(c);
                    }
                }                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                propInfo = null;
                appearance = null;
                font = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void changeControlFontName(
            string fontName,
            object control
            )
        {
            Type type = null;
            PropertyInfo propInfo = null;
            Infragistics.Win.Appearance appearance = null;
            Font font = null;

            try
            {
                type = control.GetType();

                // --

                if ((propInfo = type.GetProperty("Appearance")) != null)
                {
                    appearance = (Infragistics.Win.Appearance)propInfo.GetValue(control, null);
                    appearance.FontData.Name = fontName;
                }
                else if ((propInfo = type.GetProperty("Font")) != null)
                {
                    font = (Font)propInfo.GetValue(control, null);
                    font = new Font(fontName, font.Size, font.Style);
                    propInfo.SetValue(control, font, null);
                }

                // --

                if (control is Control)
                {
                    foreach (Control c in ((Control)control).Controls)
                    {
                        if (c is Form)
                        {
                            continue;
                        }
                        FUIWizard.changeControlFontName(fontName, c);
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                propInfo = null;
                appearance = null;
                font = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void changeControlCaption(            
            object[] controls
            )
        {
            try
            {
                foreach (object c in controls)
                {
                    changeControlCaption(c);
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

        public void changeControlCaption(
            object control
            )
        {
            bool isExistChild = true;

            try
            {
                if (control is FDetailViewGrid)
                {
                    changeCaptionInDetailViewGrid((UltraGrid)control);
                }
                else if (control is FDynPropGrid)
                {
                    changeCaptionInFDynPropGrid((FDynPropGrid)control);
                    isExistChild = false;
                }
                else if (control is UltraCombo)
                {
                    changeCaptionInCombo((UltraCombo)control);
                }
                else if (control is UltraExplorerBar)
                {
                    changeCaptionInExplorerBar((UltraExplorerBar)control);
                    isExistChild = false;
                }
                else if (control is UltraGrid)
                {
                    changeCaptionInGrid((UltraGrid)control);
                }
                else if (control is UltraTabControl)
                {
                    foreach(UltraTab t in ((UltraTabControl)control).Tabs)
                    {
                        t.Text = searchCaption(t.Text);
                    }
                }
                else if (control is UltraTile)
                {
                    ((UltraTile)control).Caption = searchCaption(((UltraTile)control).Caption);
                }
                else if (control is UltraToolbarsManager)                    
                {
                    changeCaptionInToolbarsManager((UltraToolbarsManager)control);
                }
                else if (control is UltraOptionSet)
                {
                    foreach (ValueListItem i in ((UltraOptionSet)control).Items)
                    {
                        i.DisplayText = searchCaption(i.DisplayText);
                    }
                }
                else if (control is WindowDockingArea)
                {
                    changeCaptionInDockingArea(((WindowDockingArea)control).Pane);
                }
                else if (
                    control is FValueLabel   ||
                    control is UltraTrackBar ||
                    control is UltraTextEditor ||
                    control is UltraDesktopAlert ||
                    control is UltraFormattedTextEditor ||
                    control is RichTextBox
                    )
                {
                    isExistChild = false;
                }
                else
                {
                    ((Control)control).Text = searchCaption(((Control)control).Text);
                }

                // --

                if (isExistChild && control is Control)
                {
                    foreach (Control c in ((Control)control).Controls)
                    {
                        if (c is Form)
                        {
                            continue;
                        }
                        changeControlCaption(c);
                    }
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

        private void changeCaptionInFDynPropGrid(
            FDynPropGrid control
            )
        {
            FDynPropBase propBase = null;
            FDynPropGridProp[] propArray = null;
            int index = 0;
            string caption = string.Empty;

            try
            {
                propBase = control.selectedObject;
                if (propBase == null)
                {
                    return;
                }

                // --

                propArray = propBase.fTypeDescriptor.properties.getPropertyArray();
                if (propArray == null)
                {
                    return;
                }
                
                // --
                
                foreach (FDynPropGridProp p in propArray)
                {
                    index = p.attributes.indexOf(typeof(DisplayNameAttribute));
                    if (index > -1)
                    {
                        caption = ((DisplayNameAttribute)p.attributes[index].value).DisplayName;
                        p.attributes.replace(
                            new DisplayNameAttribute(searchCaption(caption))
                            );                        
                    }                    
                }

                control.Refresh();
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

        private void changeCaptionInExplorerBar(
            UltraExplorerBar control
            )
        {
            string caption = string.Empty;

            try
            {
                foreach (UltraExplorerBarGroup group in control.Groups)
                {
                    foreach(UltraExplorerBarItem item in group.Items)
                    {
                        caption = item.Text;
                        item.Text = searchCaption(caption);
                    }
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

        private void changeCaptionInToolbarsManager(
            UltraToolbarsManager control
            )
        {
            try
            {
                foreach (RibbonTab t in control.Ribbon.Tabs)
                {
                    t.Caption = searchCaption(t.Caption);
                    foreach (RibbonGroup g in t.Groups)
                    {
                        g.Caption = searchCaption(g.Caption);
                    }
                }

                // --

                foreach (ToolBase t in control.Tools)
                {
                    t.SharedProps.Caption = searchCaption(t.SharedProps.Caption);
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

        private void changeCaptionInDockingArea(
            DockAreaPane dockablePane
            )
        {
            try
            {
                foreach(DockablePaneBase pane in dockablePane.Panes)
                {
                    pane.Text = searchCaption(pane.Text);
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

        private void changeCaptionInGrid(
            UltraGrid control
            )
        {
            try
            {
                foreach (UltraGridBand b in control.DisplayLayout.Bands)
                {
                    foreach (UltraGridColumn c in b.Columns)
                    {
                        c.Header.Caption = searchCaption(c.Header.Caption);
                    }
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

        private void changeCaptionInCombo(
            UltraCombo control
            )
        {
            try
            {
                foreach (UltraGridBand b in control.DisplayLayout.Bands)
                {
                    foreach (UltraGridColumn c in b.Columns)
                    {
                        c.Header.Caption = searchCaption(c.Header.Caption);
                    }
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

        private void changeCaptionInDetailViewGrid(
            UltraGrid control
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = (UltraDataSource)control.DataSource;

                // --

                for (int i = 0; i < uds.Rows.Count; i++)
                {
                    for (int j = 0; j < uds.Band.Columns.Count; j += 2)
                    {
                        if (uds.Rows[i][j].GetType() != typeof(System.DBNull))
                        {
                            uds.Rows[i][j] = searchCaption((string)uds.Rows[i][j]);
                        }
                    }
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

    }   // Class end
}   // Namespace end
