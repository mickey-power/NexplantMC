/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FSourceEditor.cs
--  Creator         : baehyun seo
--  Create Date     : 2011.09.30
--  Description     : FAMate Source Generaotr Editor Form Class
--  History         : Created by baehyun seo at 2011.09.30
                    : Modified by kitae at 2012.03.20
                        - Recent Library 
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using System.IO;
using Infragistics.Win.UltraWinToolbars;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using System.Text;

namespace Nexplant.MC.SourceGenerator
{
    public partial class FSourceEditor : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FScgCore m_fScgCore = null;
        private string m_fileName = string.Empty;        
        private bool m_isNewFile = true;
        private bool m_isOpened = false;
        private bool m_isModifiedFile = false;
        private bool m_isSaved = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSourceEditor(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSourceEditor(
            FScgCore fScgCore,
            bool isNewFile,
            bool isOpenFile,
            string fileName
            )
            : this()
        {
            base.fUIWizard = fScgCore.fUIWizard;
            m_fScgCore = fScgCore;
            m_isNewFile = isNewFile;
            m_isOpened = isOpenFile;
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
                    m_fScgCore = null;
                }
                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public string fileName
        {
            get 
            {
                try
                {
                    return m_fileName;
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
                    m_fileName = value;
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

        private void setTitle(
            )
        {
            try
            {
                this.Text = m_fScgCore.fWsmCore.fUIWizard.searchCaption(this.Text);

                // --

                txtFileName.Text = Path.GetFileName(m_fileName) + (m_isModifiedFile | m_isNewFile ? "*" : "");
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

        private void changeRecentLibraryFile(
            string fileName
            )
        {
            try
            {
                if (m_fScgCore.fOption.recentGenFileList.Contains(fileName))
                {
                    m_fScgCore.fOption.recentGenFileList.Remove(fileName);
                }
                else if (m_fScgCore.fOption.recentGenFileList.Count == 4)
                {
                    m_fScgCore.fOption.recentGenFileList.RemoveAt(3);
                }
                m_fScgCore.fOption.recentGenFileList.Insert(0, fileName);
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
                txtEditor.Appearance.FontData.Name = (new System.Drawing.FontFamily(preFontName)).Name;
                m_fScgCore.fOption.fontName = preFontName;
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
                txtEditor.Appearance.FontData.SizeInPoints = float.Parse(mskFontSize.Value.ToString());
                m_fScgCore.fOption.fontSize = float.Parse(mskFontSize.Value.ToString());
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

        private void procMenuOpen(
            )
        {
            OpenFileDialog dialog = null;

            try
            {
                if (!confirmSave())
                {
                    return;
                }

                // --

                dialog = new OpenFileDialog();
                dialog.InitialDirectory = m_fScgCore.fOption.recentOpenPath;
                dialog.Title = fUIWizard.searchCaption("Open GEN File");
                dialog.Filter = "GEN Files | *.gen";
                dialog.DefaultExt = "gen";
                
                // --                

                if (dialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                m_fileName = dialog.FileName;
                
                // --

                appendText();

                // --

                m_fScgCore.fOption.recentOpenPath = Path.GetDirectoryName(m_fileName);
                changeRecentLibraryFile(m_fileName);
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

        //------------------------------------------------------------------------------------------------------------------------

        private void appendText(
            )
        {
            StreamReader str = null;

            try
            {
                txtEditor.Clear();

                // --

                str = new StreamReader(m_fileName, Encoding.Unicode);
                txtEditor.Text = str.ReadToEnd();
                txtEditor.Select(txtEditor.TextLength, 0);
                txtEditor.ScrollToCaret();
                txtEditor.Focus();

                // --

                if (str != null)
                {
                    str.Dispose();
                    str = null;
                }

                // --

                m_isNewFile = false;
                m_isModifiedFile = false;
                m_isSaved = true;

                // --
                
                setTitle();
                controlMenu();
            }
            catch (Exception ex)
            {
                txtEditor.EndUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                str = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuFind(
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                txtEditor.showSearcher();
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

        private bool procMenuSave(
            )
        {
            StreamWriter stw = null;

            try
            {
                if (!m_isNewFile)
                {
                    stw = new StreamWriter(m_fileName, false, Encoding.Unicode);
                    stw.Write(txtEditor.Text);
                    stw.Close();
                }
                else
                {
                    return procMenuSaveAs();
                }

                // --

                m_isNewFile = false;
                m_isModifiedFile = false;
                m_isSaved = true;

                // --

                m_fScgCore.fOption.recentSavePath = Path.GetDirectoryName(m_fileName);

                // --

                if (stw != null)
                {
                    stw.Dispose();
                    stw = null;
                }

                // --

                setTitle();
                controlMenu();

                // --

                return true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                stw = null;
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private bool procMenuSaveAs(
            )
        {
            SaveFileDialog dialog = null;
            StreamWriter stw = null;

            try
            {
                dialog = new SaveFileDialog();
                dialog.Title = fUIWizard.searchCaption("Save XML Generator File");
                dialog.Filter = "GEN File | *.gen";
                dialog.DefaultExt = "gen";
                dialog.FileName = m_fileName;
                // --
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    stw = new StreamWriter(dialog.FileName, false, Encoding.Unicode);
                    stw.Write(txtEditor.Text);
                    stw.Close();
                }
                else
                {
                    return false;
                }

                // --

                m_fileName = dialog.FileName;
                m_isNewFile = false;
                m_isModifiedFile = false;
                m_isSaved = true;

                // --

                m_fScgCore.fOption.recentSavePath = Path.GetDirectoryName(m_fileName);

                // --

                if (stw != null)
                {
                    stw.Dispose();
                    stw = null;
                }

                // --

                setTitle();
                controlMenu();

                // --

                return true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                dialog = null;
                stw = null;
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuGenerate(
            )
        {
            try
            {
                m_fScgCore.fScgContainer.openSourceGenerate(m_fileName);
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

        private void controlMenu(
            )
        {
            try
            {
                mnuMenu.beginUpdate();

                // --

                mnuMenu.Tools[FMenuKey.MenuSceFind].SharedProps.Enabled = true;
                
                // --
                
                mnuMenu.Tools[FMenuKey.MenuSceOpen].SharedProps.Enabled = true;
                
                // --
                
                mnuMenu.Tools[FMenuKey.MenuSceSave].SharedProps.Enabled = m_isNewFile | m_isModifiedFile | m_isSaved;
                mnuMenu.Tools[FMenuKey.MenuSceSaveAs].SharedProps.Enabled = true;
                
                // --

                mnuMenu.Tools[FMenuKey.MenuSceGenerate].SharedProps.Enabled = m_isOpened | m_isSaved;

                // --

                mnuMenu.endUpdate();
            }
            catch (Exception ex)
            {
                mnuMenu.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void createGenFile(
            )
        {
            FXmlDocument fXmlDoc = null;
            FXmlNode fXmlNodeFam = null;
            FXmlNode fXmlNodeGroup = null;
            FXmlNode fXmlNodeParameterIn = null;
            FXmlNode fXmlNodeParameterOut = null;
            FXmlNode fXmlNodeParentElementIn = null;
            FXmlNode fXmlNodeParentElementOut = null;
            FXmlNode fXmlNodeChildElementOut = null;
            FXmlNode fXmlNodeAttribute = null;
            FXmlNode fXmlNodeFunction = null;
            // --
            string creationTime = string.Empty;
            string updateTime = string.Empty;
            string fileName = string.Empty;

            try
            {
                creationTime = FDataConvert.defaultNowDateTimeToString();
                updateTime = FDataConvert.defaultNowDateTimeToString();

                // --

                // ***
                // Language XML Document Create
                // ***
                fXmlDoc = new FXmlDocument();
                fXmlDoc.preserveWhiteSpace = false;
                fXmlDoc.appendChild(fXmlDoc.createXmlDeclaration("1.0", "UTF-16", string.Empty));

                // --

                // ***
                // FAMate Element Create
                // ***
                fXmlNodeFam = fXmlDoc.appendChild(fXmlDoc.createNode(FXmlTagFAMate.E_FAMate));
                // --
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileFormat, FXmlTagFAMate.D_FileFormat, "GEN");
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileVersion, FXmlTagFAMate.D_FileVersion, "4.1.0.1");
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileCreationTime, FXmlTagFAMate.D_FileCreationTime, creationTime);
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileUpdateTime, FXmlTagFAMate.D_FileUpdateTime, updateTime);
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileDescription, FXmlTagFAMate.D_FileDescription, "Nexplant MC Source Generator File");
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_UniqueIdPointer, FXmlTagFAMate.D_UniqueIdPointer, "0");

                // --

                // ***
                // Namespace Element Create
                // ***
                fXmlNodeFam = fXmlNodeFam.appendChild(fXmlDoc.createNode(FXmlTagNamespace.E_Namespace));
                // --
                fXmlNodeFam.set_attrVal(FXmlTagNamespace.A_NamespaceName, FXmlTagNamespace.D_NamespaceName, "Nexplant.MC.H101Interface");
                fXmlNodeFam.set_attrVal(FXmlTagNamespace.A_NamespaceModuleName, FXmlTagNamespace.D_NamespaceModuleName, "SQMSQS");

                // --

                // ***
                // [FXmlTagSystemList_In]Parameters Element Create
                // ***
                fXmlNodeGroup = fXmlNodeFam.appendChild(fXmlDoc.createNode(FXmlTagGroup.E_Group));
                // --
                fXmlNodeGroup.set_attrVal(FXmlTagGroup.A_GroupName, FXmlTagGroup.D_GroupName, "Setup");
                // --

                // ***
                // [FXmlTagSystemList_In]Parameters Element Create
                // ***
                fXmlNodeParameterIn = fXmlNodeGroup.appendChild(fXmlDoc.createNode(FXmlTagParameters.E_Parameters));
                // --
                fXmlNodeParameterIn.set_attrVal(FXmlTagParameters.A_ParametersName, FXmlTagParameters.D_ParametersName, "FXmlTagSetSystemList_In");

                // --

                // ***
                // [SystemList_In]Element Element Create
                // ***
                fXmlNodeParentElementIn = fXmlNodeParameterIn.appendChild(fXmlDoc.createNode(FXmlTagElement.E_Element));
                // --
                fXmlNodeParentElementIn.set_attrVal(FXmlTagElement.A_ElementName, FXmlTagElement.D_ElementName, "SetSystemList_In");
                fXmlNodeParentElementIn.set_attrVal(FXmlTagElement.A_ElementTag, FXmlTagElement.D_ElementTag);
                // --

                // ***
                // Attribute Element Create
                // ***
                fXmlNodeAttribute = fXmlNodeParentElementIn.appendChild(fXmlDoc.createNode(FXmlTagAttribute.E_Attribute));
                // --
                fXmlNodeAttribute.set_attrVal(FXmlTagAttribute.A_AttributeName, FXmlTagAttribute.D_AttributeName, "hLanguage");
                fXmlNodeAttribute.set_attrVal(FXmlTagAttribute.A_AttributeTag, FXmlTagAttribute.D_AttributeTag);
                fXmlNodeAttribute.set_attrVal(FXmlTagAttribute.A_AttributeDefaultValue, FXmlTagAttribute.D_AttributeDefaultValue);

                // --

                fXmlNodeAttribute = fXmlNodeParentElementIn.appendChild(fXmlDoc.createNode(FXmlTagAttribute.E_Attribute));
                // --
                fXmlNodeAttribute.set_attrVal(FXmlTagAttribute.A_AttributeName, FXmlTagAttribute.D_AttributeName, "hStep");
                fXmlNodeAttribute.set_attrVal(FXmlTagAttribute.A_AttributeTag, FXmlTagAttribute.D_AttributeTag);
                fXmlNodeAttribute.set_attrVal(FXmlTagAttribute.A_AttributeDefaultValue, FXmlTagAttribute.D_AttributeDefaultValue);

                // --

                // ***
                // [FXmlTagSystemList_Out]Parameters Element Create
                // ***
                fXmlNodeParameterOut = fXmlNodeGroup.appendChild(fXmlDoc.createNode(FXmlTagParameters.E_Parameters));
                // --
                fXmlNodeParameterOut.set_attrVal(FXmlTagParameters.A_ParametersName, FXmlTagParameters.D_ParametersName, "FXmlTagSetSystemList_Out");

                // --

                // ***
                // [SystemList_Out]Element Element Create
                // ***
                fXmlNodeParentElementOut = fXmlNodeParameterOut.appendChild(fXmlDoc.createNode(FXmlTagElement.E_Element));
                // --
                fXmlNodeParentElementOut.set_attrVal(FXmlTagElement.A_ElementName, FXmlTagElement.D_ElementName, "SetSystemList_Out");
                fXmlNodeParentElementOut.set_attrVal(FXmlTagElement.A_ElementTag, FXmlTagElement.D_ElementTag);

                // --

                // ***
                // Attribute Element Create
                // ***
                fXmlNodeAttribute = fXmlNodeParentElementOut.appendChild(fXmlDoc.createNode(FXmlTagAttribute.E_Attribute));
                // --
                fXmlNodeAttribute.set_attrVal(FXmlTagAttribute.A_AttributeName, FXmlTagAttribute.D_AttributeName, "hStatus");
                fXmlNodeAttribute.set_attrVal(FXmlTagAttribute.A_AttributeTag, FXmlTagAttribute.D_AttributeTag);
                fXmlNodeAttribute.set_attrVal(FXmlTagAttribute.A_AttributeDefaultValue, FXmlTagAttribute.D_AttributeDefaultValue);

                // --

                fXmlNodeAttribute = fXmlNodeParentElementOut.appendChild(fXmlDoc.createNode(FXmlTagAttribute.E_Attribute));
                // --
                fXmlNodeAttribute.set_attrVal(FXmlTagAttribute.A_AttributeName, FXmlTagAttribute.D_AttributeName, "hStatusMessage");
                fXmlNodeAttribute.set_attrVal(FXmlTagAttribute.A_AttributeTag, FXmlTagAttribute.D_AttributeTag);
                fXmlNodeAttribute.set_attrVal(FXmlTagAttribute.A_AttributeDefaultValue, FXmlTagAttribute.D_AttributeDefaultValue);

                // --

                // ***
                // [System]Element Element Create
                // ***
                fXmlNodeChildElementOut = fXmlNodeParentElementOut.appendChild(fXmlDoc.createNode(FXmlTagElement.E_Element));
                // --
                fXmlNodeChildElementOut.set_attrVal(FXmlTagElement.A_ElementName, FXmlTagElement.D_ElementName, "System");
                fXmlNodeChildElementOut.set_attrVal(FXmlTagElement.A_ElementTag, FXmlTagElement.D_ElementTag, "");

                // --

                // ***
                // Attribute Element Create
                // ***
                fXmlNodeAttribute = fXmlNodeChildElementOut.appendChild(fXmlDoc.createNode(FXmlTagAttribute.E_Attribute));
                // --
                fXmlNodeAttribute.set_attrVal(FXmlTagAttribute.A_AttributeName, FXmlTagAttribute.D_AttributeName, "UniqueId");
                fXmlNodeAttribute.set_attrVal(FXmlTagAttribute.A_AttributeTag, FXmlTagAttribute.D_AttributeTag, "");
                fXmlNodeAttribute.set_attrVal(FXmlTagAttribute.A_AttributeDefaultValue, FXmlTagAttribute.D_AttributeDefaultValue, "");

                // --

                // ***
                // Attribute Element Create
                // ***
                fXmlNodeAttribute = fXmlNodeChildElementOut.appendChild(fXmlDoc.createNode(FXmlTagAttribute.E_Attribute));
                // --
                fXmlNodeAttribute.set_attrVal(FXmlTagAttribute.A_AttributeName, FXmlTagAttribute.D_AttributeName, "System");
                fXmlNodeAttribute.set_attrVal(FXmlTagAttribute.A_AttributeTag, FXmlTagAttribute.D_AttributeTag, "");
                fXmlNodeAttribute.set_attrVal(FXmlTagAttribute.A_AttributeDefaultValue, FXmlTagAttribute.D_AttributeDefaultValue, "");

                // ***
                // Attribute Element Create
                // ***
                fXmlNodeAttribute = fXmlNodeChildElementOut.appendChild(fXmlDoc.createNode(FXmlTagAttribute.E_Attribute));
                // --
                fXmlNodeAttribute.set_attrVal(FXmlTagAttribute.A_AttributeName, FXmlTagAttribute.D_AttributeName, "Description");
                fXmlNodeAttribute.set_attrVal(FXmlTagAttribute.A_AttributeTag, FXmlTagAttribute.D_AttributeTag, "");
                fXmlNodeAttribute.set_attrVal(FXmlTagAttribute.A_AttributeDefaultValue, FXmlTagAttribute.D_AttributeDefaultValue, "");

                // --

                // ***
                // Function
                // ***
                fXmlNodeFunction = fXmlNodeGroup.appendChild(fXmlDoc.createNode(FXmlTagFunction.E_Function));
                // --
                fXmlNodeFunction.set_attrVal(FXmlTagFunction.A_FunctionClass, FXmlTagFunction.D_FunctionClass, "FSQMSQSCallback");
                fXmlNodeFunction.set_attrVal(FXmlTagFunction.A_FunctionDeliveryMode, FXmlTagFunction.A_FunctionDeliveryMode, "REQUEST");
                fXmlNodeFunction.set_attrVal(FXmlTagFunction.A_FunctionName, FXmlTagFunction.D_FunctionName, "SQMSQS_SetSystemList_Req");
                fXmlNodeFunction.set_attrVal(FXmlTagFunction.A_FunctionAsync, FXmlTagFunction.D_FunctionAsync, "True");
                fXmlNodeFunction.set_attrVal(FXmlTagFunction.A_FunctionGuaranteed, FXmlTagFunction.D_FunctionGuaranteed, "True");

                // --

                txtEditor.Text = fXmlDoc.xmlToString(true);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlDoc = null;
                fXmlNodeFam = null;
                fXmlNodeGroup = null;
                fXmlNodeParameterIn = null;
                fXmlNodeParameterOut = null;
                fXmlNodeParentElementIn = null;
                fXmlNodeParentElementOut = null;
                fXmlNodeChildElementOut = null;
                fXmlNodeAttribute = null;
                fXmlNodeFunction = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private bool confirmSave(
            )
        {
            DialogResult dialogResult;

            try
            {
                if (m_isModifiedFile)
                {
                    dialogResult = FMessageBox.showQuestion(
                        FConstants.ApplicationName,
                        m_fScgCore.fWsmCore.fUIWizard.generateMessage("Q0002", new object[] { FConstants.ApplicationName }),
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxDefaultButton.Button3,
                        m_fScgCore.fWsmCore.fWsmContainer
                        );
                    if (dialogResult == DialogResult.Yes)
                    {
                        return procMenuSave();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
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

        //------------------------------------------------------------------------------------------------------------------------

        public void refreshEditor(
            string fileName
            )
        {
            try
            {
                m_fileName = fileName;
                appendText();
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

        #region FSourceEditor Form Event Handler

        private void FSourceEditor_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                ((FontListTool)mnuMenu.Tools[FMenuKey.MenuFontName]).Text = m_fScgCore.fOption.fontName;
                mskFontSize.Value = m_fScgCore.fOption.fontSize;

                // --

                txtEditor.Appearance.FontData.Name = ((FontListTool)mnuMenu.Tools[FMenuKey.MenuFontName]).Value.ToString();
                txtEditor.Appearance.FontData.SizeInPoints = float.Parse(mskFontSize.Value.ToString());

                // --

                m_fScgCore.fOption.fChildFormList.add(this, this.Text + " - [" + Path.GetFileName(m_fileName) + "]");
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

        private void FSourceEditor_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_isNewFile)
                {
                    createGenFile();
                }
                else
                {
                    appendText();
                }

                // --

                setTitle();
                controlMenu();

                // --

                txtEditor.Focus();
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

        private void FSourceEditor_FormCloseConfirm(
            object sender,
            FFormCloseConfirmEventArgs e
            )
        {
            try
            {
                if (!confirmSave())
                {
                    e.cancel = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, this);
            }
            finally
            {

            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        private void FSourceEditor_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fScgCore.fOption.fChildFormList.remove(this);
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

        #region txtEditor Control Event Handler

        private void txtEditor_KeyDown(
            object sender,
            KeyEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Control && e.KeyCode == Keys.F)
                {
                    txtEditor.showSearcher();
                }
                
                // --

                if (!m_isModifiedFile)
                {
                    m_isModifiedFile = true;
                    setTitle();
                    controlMenu();
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

                if (e.Tool.Key == FMenuKey.MenuSceFind)
                {
                    procMenuFind();
                }
                else if (e.Tool.Key == FMenuKey.MenuSceOpen)
                {
                    procMenuOpen();
                }
                else if (e.Tool.Key == FMenuKey.MenuSceSave)
                {
                    procMenuSave();
                }
                else if (e.Tool.Key == FMenuKey.MenuSceSaveAs)
                {
                    procMenuSaveAs();
                }
                else if (e.Tool.Key == FMenuKey.MenuSceGenerate)
                {
                    procMenuGenerate();
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

        private void mnuMenu_FontNameChange(
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fScgCore.fWsmCore.fWsmContainer);
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
                        ((FontListTool)mnuMenu.Tools[FMenuKey.MenuFontName]).Value = m_fScgCore.fOption.fontName;
                        txtEditor.Appearance.FontData.Name = m_fScgCore.fOption.fontName;
                    }
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
                if (int.Parse(mskFontSize.Value.ToString()) < FConstants.FontMinSize)
                {
                    mskFontSize.Value = FConstants.FontMinSize;
                }
                else if (int.Parse(mskFontSize.Value.ToString()) > FConstants.FontMaxSize)
                {
                    mskFontSize.Value = FConstants.FontMaxSize;
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fScgCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fScgCore.fWsmCore.fWsmContainer);
            }
            finally
            {

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
                    txtEditor.Focus();
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