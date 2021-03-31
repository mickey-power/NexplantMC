/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FMessageEditor.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.03
--  Description     : FAMate Language File Editor Message Editor Form Class 
--  History         : Created by spike.lee at 2011.01.03
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
using Infragistics.Win.UltraWinDataSource;

namespace Nexplant.MC.LanguageFileEditor
{
    public partial class FMessageEditor : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FLfeCore m_fLfeCore = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FMessageEditor(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FMessageEditor(
            FLfeCore fLfeCore
            )
            : this()
        {
            base.fUIWizard = fLfeCore.fUIWizard;
            m_fLfeCore = fLfeCore;
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
                    m_fLfeCore = null;
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FGrid fGrid
        {
            get
            {
                try
                {
                    return this.grdList;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void designGridOfMessage(
           )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --
                uds.Band.Columns.Add("Message ID");
                uds.Band.Columns.Add(FLanguage.Default.ToString());
                uds.Band.Columns.Add(FLanguage.English.ToString());
                uds.Band.Columns.Add(FLanguage.Korean.ToString());
                uds.Band.Columns.Add(FLanguage.Chinese.ToString());
                uds.Band.Columns.Add("Description");
    
                // --

                grdList.DisplayLayout.Bands[0].Columns["Message ID"].CellAppearance.Image = Properties.Resources.Message;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Message ID"].Header.Fixed = true;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Message ID"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns[FLanguage.Default.ToString()].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns[FLanguage.English.ToString()].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns[FLanguage.Korean.ToString()].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns[FLanguage.Chinese.ToString()].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                uds = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfMessage(
            )
        {
            FXmlNodeList fXmlNodeListMsg = null;
            object[] cellValues = null;
            string xpath = string.Empty;

            try
            {
                grdList.beginUpdate();

                // --

                grdList.removeAllDataRow();
                initPropOfMessage();
                btnDelete.Enabled = false;

                // --

                xpath =
                    FXmlTagFAMate.E_FAMate +
                    "/" + FXmlTagMessageGroup.E_MessageGroup +
                    "/" + FXmlTagMessage.E_Message;
                fXmlNodeListMsg = m_fLfeCore.fLfeFileInfo.fXmlDocLanguage.selectNodes(xpath);

                // --

                foreach (FXmlNode n in fXmlNodeListMsg)
                {
                    cellValues = new object[] 
                    {
                        n.get_attrVal(FXmlTagMessage.A_MessageId, FXmlTagMessage.D_MessageId),
                        n.get_attrVal(FLanguage.Default.ToString(), FXmlTagMessage.D_Language),
                        n.get_attrVal(FLanguage.English.ToString(), FXmlTagMessage.D_Language),
                        n.get_attrVal(FLanguage.Korean.ToString(), FXmlTagMessage.D_Language),
                        n.get_attrVal(FLanguage.Chinese.ToString(), FXmlTagMessage.D_Language),
                        n.get_attrVal(FXmlTagMessage.A_Description, FXmlTagMessage.D_Description)
                    };
                    // --
                    grdList.appendDataRow((string)cellValues[0], cellValues);
                }

                // --

                grdList.endUpdate();

                // --

                grdList.DisplayLayout.Bands[0].SortedColumns.Add("Message ID", false);
                if (grdList.Rows.Count > 0)
                {
                    grdList.ActiveRow = grdList.Rows[0];
                }
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeListMsg != null)
                {
                    fXmlNodeListMsg.Dispose();
                    fXmlNodeListMsg = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void initPropOfMessage(
            )
        {
            try
            {
                pgdProp.selectedObject = (new FPropMessage(m_fLfeCore, pgdProp));
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

        private void setPropOfMessage(
            )
        {
            FXmlNode fXmlNodeMsg = null;
            string xpath = string.Empty;
            string key = string.Empty;

            try
            {
                key = grdList.activeDataRowKey;
                if (key == string.Empty)
                {
                    return;
                }

                // --

                xpath =
                    FXmlTagFAMate.E_FAMate +
                    "/" + FXmlTagMessageGroup.E_MessageGroup +
                    "/" + FXmlTagMessage.E_Message + "[@" + FXmlTagMessage.A_MessageId + "='" + key + "']";
                fXmlNodeMsg = m_fLfeCore.fLfeFileInfo.fXmlDocLanguage.selectSingleNode(xpath);
                pgdProp.selectedObject = (new FPropMessage(m_fLfeCore, pgdProp, fXmlNodeMsg));

                // --

                btnDelete.Enabled = true;
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

        public void excelImport(
            string fileName
            )
        {
            FXmlNode fXmlNodeMgp = null;
            FXmlNode fXmlNodeMsg = null;
            string xpath = null;
            string key = string.Empty;
            object[] cellValues = null;
            DataTable dt = null;
            FExcelImporter fExcelImporter = null;            

            try
            {
                fExcelImporter = new FExcelImporter(fileName);
                dt = new DataTable();
                dt = fExcelImporter.excelImport(this.Text).Tables[0];

                // --

                FCursor.waitCursor();

                // --

                grdList.beginUpdate();
                
                // --
                
                xpath =
                    FXmlTagFAMate.E_FAMate +
                    "/" + FXmlTagMessageGroup.E_MessageGroup;
                fXmlNodeMgp = m_fLfeCore.fLfeFileInfo.fXmlDocLanguage.selectSingleNode(xpath);

                // --

                foreach (DataRow dr in dt.Rows)
                {
                    xpath = FXmlTagMessage.E_Message + "[@" + FXmlTagMessage.A_MessageId + "='" + dr[0].ToString().Trim() + "']";
                    fXmlNodeMsg = fXmlNodeMgp.selectSingleNode(xpath);
                    if (fXmlNodeMsg == null)
                    {
                        fXmlNodeMsg = fXmlNodeMgp.appendChild(m_fLfeCore.fLfeFileInfo.fXmlDocLanguage.createNode(FXmlTagMessage.E_Message));
                    }

                    // --
                    if (
                        fXmlNodeMsg.get_attrVal(FXmlTagMessage.A_MessageId, FXmlTagMessage.D_MessageId) != dr[0].ToString().Trim() ||
                        fXmlNodeMsg.get_attrVal(FLanguage.Default.ToString(), FXmlTagMessage.D_Language) != dr[1].ToString().Trim() ||
                        fXmlNodeMsg.get_attrVal(FLanguage.English.ToString(), FXmlTagMessage.D_Language) != dr[2].ToString().Trim() ||
                        fXmlNodeMsg.get_attrVal(FLanguage.Korean.ToString(), FXmlTagMessage.D_Language) != dr[3].ToString().Trim() ||
                        fXmlNodeMsg.get_attrVal(FLanguage.Chinese.ToString(), FXmlTagMessage.D_Language) != dr[4].ToString().Trim() ||
                        fXmlNodeMsg.get_attrVal(FXmlTagMessage.A_Description, FXmlTagMessage.D_Description) != dr[5].ToString().Trim()
                        )
                    {
                        fXmlNodeMsg.set_attrVal(FXmlTagMessage.A_MessageId, FXmlTagMessage.D_MessageId, dr[0].ToString().Trim());
                        fXmlNodeMsg.set_attrVal(FLanguage.Default.ToString(), FXmlTagMessage.D_Language, dr[1].ToString().Trim());
                        fXmlNodeMsg.set_attrVal(FLanguage.English.ToString(), FXmlTagMessage.D_Language, dr[2].ToString().Trim());
                        fXmlNodeMsg.set_attrVal(FLanguage.Korean.ToString(), FXmlTagMessage.D_Language, dr[3].ToString().Trim());
                        fXmlNodeMsg.set_attrVal(FLanguage.Chinese.ToString(), FXmlTagMessage.D_Language, dr[4].ToString().Trim());
                        fXmlNodeMsg.set_attrVal(FXmlTagMessage.A_Description, FXmlTagMessage.D_Description, dr[5].ToString().Trim());

                        // --

                        key = dr[0].ToString().Trim();
                        cellValues = new object[]
                        {
                            key,                        // MessageId
                            dr[1].ToString().Trim(),    // Default
                            dr[2].ToString().Trim(),    // English
                            dr[3].ToString().Trim(),    // Korean
                            dr[4].ToString().Trim(),    // Chinese
                            dr[5].ToString().Trim()     // Description
                        };
                        // --
                        grdList.appendOrUpdateDataRow(key, cellValues);
                        grdList.activateDataRow(key);
                    }
                }

                // --

                grdList.endUpdate();

                // --

                m_fLfeCore.fLfeFileInfo.onLanguageFileModified();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLfeCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                if (fXmlNodeMgp != null)
                {
                    fXmlNodeMgp.Dispose();
                    fXmlNodeMgp = null;
                }

                if (fXmlNodeMsg != null)
                {
                    fXmlNodeMsg.Dispose();
                    fXmlNodeMsg = null;
                }

                // --

                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FMessageEditor Form Event Handler

        private void FMessageEditor_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfMessage();

                // --

                m_fLfeCore.fOption.fChildFormList.add(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLfeCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FMessageEditor_Shown(
           object sender,
           EventArgs e
           )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfMessage();

                // --

                grdList.Focus();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLfeCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FMessageEditor_FormClosing(
            object sender,
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fLfeCore.fOption.fChildFormList.remove(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLfeCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region grdList Control Event Handler

        private void grdList_AfterRowActivate(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfMessage();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLfeCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnUpdate Control Event Handler

        private void btnUpdate_Click(
            object sender,
            EventArgs e
            )
        {
            FPropMessage fPropMessage = null;
            FXmlNode fXmlNodeMgp = null;
            FXmlNode fXmlNodeMsg = null;
            string xpath = null;
            string key = string.Empty;
            object[] cellValues = null;

            try
            {
                FCursor.waitCursor();

                // --

                fPropMessage = (FPropMessage)pgdProp.selectedObject;

                // --

                if (fPropMessage.MessageId.Trim() == string.Empty)
                {
                    FDebug.throwFException(m_fLfeCore.fUIWizard.generateMessage("E0001", new object[] { "Message ID" }));
                }

                // --

                xpath =
                    FXmlTagFAMate.E_FAMate +
                    "/" + FXmlTagMessageGroup.E_MessageGroup;
                fXmlNodeMgp = m_fLfeCore.fLfeFileInfo.fXmlDocLanguage.selectSingleNode(xpath);

                // --

                xpath = FXmlTagMessage.E_Message + "[@" + FXmlTagMessage.A_MessageId + "='" + fPropMessage.MessageId + "']";
                fXmlNodeMsg = fXmlNodeMgp.selectSingleNode(xpath);
                if (fXmlNodeMsg == null)
                {
                    fXmlNodeMsg = fXmlNodeMgp.appendChild(m_fLfeCore.fLfeFileInfo.fXmlDocLanguage.createNode(FXmlTagMessage.E_Message));
                }

                // --

                fXmlNodeMsg.set_attrVal(FXmlTagMessage.A_MessageId, FXmlTagMessage.D_MessageId, fPropMessage.MessageId);
                fXmlNodeMsg.set_attrVal(FLanguage.Default.ToString(), FXmlTagMessage.D_Language, fPropMessage.Default);
                fXmlNodeMsg.set_attrVal(FLanguage.English.ToString(), FXmlTagMessage.D_Language, fPropMessage.English);
                fXmlNodeMsg.set_attrVal(FLanguage.Korean.ToString(), FXmlTagMessage.D_Language, fPropMessage.Korean);
                fXmlNodeMsg.set_attrVal(FLanguage.Chinese.ToString(), FXmlTagMessage.D_Language, fPropMessage.Chinese);
                fXmlNodeMsg.set_attrVal(FXmlTagMessage.A_Description.ToString(), FXmlTagMessage.D_Description, fPropMessage.Description);

                // --

                key = fPropMessage.MessageId;
                cellValues = new object[]
                {
                    key,
                    fPropMessage.Default,
                    fPropMessage.English,
                    fPropMessage.Korean,
                    fPropMessage.Chinese,
                    fPropMessage.Description
                };
                // --
                grdList.appendOrUpdateDataRow(key, cellValues);
                grdList.activateDataRow(key);

                // --

                m_fLfeCore.fLfeFileInfo.onLanguageFileModified();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLfeCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                if (fXmlNodeMgp != null)
                {
                    fXmlNodeMgp.Dispose();
                    fXmlNodeMgp = null;
                }

                if (fXmlNodeMsg != null)
                {
                    fXmlNodeMsg.Dispose();
                    fXmlNodeMsg = null;
                }

                // --

                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnClear Control Event Handler

        private void btnClear_Click(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                initPropOfMessage();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLfeCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnDelete Control Event Handler

        private void btnDelete_Click(
            object sender,
            EventArgs e
            )
        {
            FXmlNode fXmlNodeMsg = null;
            string xpath = string.Empty;
            string key = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                key = grdList.activeDataRowKey;
                if (key == string.Empty)
                {
                    return;
                }

                // --

                btnDelete.Enabled = false;

                // --

                xpath =
                    FXmlTagFAMate.E_FAMate +
                    "/" + FXmlTagMessageGroup.E_MessageGroup +
                    "/" + FXmlTagMessage.E_Message + "[@" + FXmlTagMessage.A_MessageId + "='" + key + "']";
                fXmlNodeMsg = m_fLfeCore.fLfeFileInfo.fXmlDocLanguage.selectSingleNode(xpath);
                fXmlNodeMsg.fParentNode.removeChild(fXmlNodeMsg);

                // --

                grdList.removeDataRow(key);

                // --

                m_fLfeCore.fLfeFileInfo.onLanguageFileModified();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLfeCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                if (fXmlNodeMsg != null)
                {
                    fXmlNodeMsg.Dispose();
                    fXmlNodeMsg = null;
                }

                // --

                FCursor.defaultCursor();
            }
        }

        #endregion
              
        //------------------------------------------------------------------------------------------------------------------------  

        #region rstToolbar Control Event Handler

        private void rstToolbar_RefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfMessage();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLfeCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void rstToolbar_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdList.searchGridRow(e.searchWord))
                {
                    FMessageBox.showInformation("Search", m_fLfeCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { e.searchWord }), this);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLfeCore.fWsmCore.fWsmContainer);
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
