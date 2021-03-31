/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FCaptionEditor.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.03
--  Description     : FAMate Language File Editor Caption Editor Form Class 
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
    public partial class FCaptionEditor : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FLfeCore m_fLfeCore = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FCaptionEditor(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FCaptionEditor(
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

        private void designGridOfCaption(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --
                uds.Band.Columns.Add(FLanguage.Default.ToString());
                uds.Band.Columns.Add(FLanguage.English.ToString());
                uds.Band.Columns.Add(FLanguage.Korean.ToString());
                uds.Band.Columns.Add(FLanguage.Chinese.ToString());
                uds.Band.Columns.Add("Description");

                // --

                grdList.DisplayLayout.Bands[0].Columns[FLanguage.Default.ToString()].CellAppearance.Image = Properties.Resources.Caption;
                // --
                grdList.DisplayLayout.Bands[0].Columns[FLanguage.Default.ToString()].Header.Fixed = true;
                // --
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

        private void refreshGridOfCaption(
            )
        {
            FXmlNodeList fXmlNodeListCap = null;
            object[] cellValues = null;
            string xpath = string.Empty;

            try
            {
                grdList.beginUpdate();

                // --

                grdList.removeAllDataRow();
                initPropOfCaption();
                btnDelete.Enabled = false;

                // --

                xpath =
                    FXmlTagFAMate.E_FAMate +
                    "/" + FXmlTagCaptionGroup.E_CaptionGroup +
                    "/" + FXmlTagCaption.E_Caption;
                fXmlNodeListCap = m_fLfeCore.fLfeFileInfo.fXmlDocLanguage.selectNodes(xpath);

                // --

                foreach (FXmlNode n in fXmlNodeListCap)
                {
                    cellValues = new object[] 
                    {
                        n.get_attrVal(FLanguage.Default.ToString(), FXmlTagCaption.D_Language),
                        n.get_attrVal(FLanguage.English.ToString(), FXmlTagCaption.D_Language),
                        n.get_attrVal(FLanguage.Korean.ToString(), FXmlTagCaption.D_Language),
                        n.get_attrVal(FLanguage.Chinese.ToString(), FXmlTagCaption.D_Language),
                        n.get_attrVal(FXmlTagCaption.A_Description, FXmlTagCaption.D_Description)
                    };
                    grdList.appendDataRow((string)cellValues[0], cellValues);
                }

                // --

                grdList.endUpdate();                

                // --                

                grdList.DisplayLayout.Bands[0].SortedColumns.Add(FLanguage.Default.ToString(), false);
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
                if (fXmlNodeListCap != null)
                {
                    fXmlNodeListCap.Dispose();
                    fXmlNodeListCap = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void initPropOfCaption(
            )
        {
            try
            {
                pgdProp.selectedObject = (new FPropCaption(m_fLfeCore, pgdProp));
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

        private void setPropOfCaption(
            )
        {
            FXmlNode fXmlNodeCap = null;
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
                    "/" + FXmlTagCaptionGroup.E_CaptionGroup +
                    "/" + FXmlTagCaption.E_Caption + "[@" + FLanguage.Default.ToString() + "='" + key + "']";
                fXmlNodeCap = m_fLfeCore.fLfeFileInfo.fXmlDocLanguage.selectSingleNode(xpath);
                pgdProp.selectedObject = new FPropCaption(m_fLfeCore, pgdProp, fXmlNodeCap);

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
            FXmlNode fXmlNodeCgp = null;
            FXmlNode fXmlNodeCap = null;
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
                    "/" + FXmlTagCaptionGroup.E_CaptionGroup;
                fXmlNodeCgp = m_fLfeCore.fLfeFileInfo.fXmlDocLanguage.selectSingleNode(xpath);

                // --

                foreach (DataRow dr in dt.Rows)
                {
                    xpath = FXmlTagCaption.E_Caption + "[@" + FLanguage.Default.ToString() + "='" + dr[0].ToString().Trim() + "']";
                    fXmlNodeCap = fXmlNodeCgp.selectSingleNode(xpath);
                    if (fXmlNodeCap == null)
                    {
                        fXmlNodeCap = fXmlNodeCgp.appendChild(m_fLfeCore.fLfeFileInfo.fXmlDocLanguage.createNode(FXmlTagCaption.E_Caption));
                    }

                    // --
                    if (
                        fXmlNodeCap.get_attrVal(FLanguage.Default.ToString(), FXmlTagCaption.D_Language) != dr[0].ToString().Trim() ||
                        fXmlNodeCap.get_attrVal(FLanguage.English.ToString(), FXmlTagCaption.D_Language) != dr[1].ToString().Trim() ||
                        fXmlNodeCap.get_attrVal(FLanguage.Korean.ToString(), FXmlTagCaption.D_Language) != dr[2].ToString().Trim() ||
                        fXmlNodeCap.get_attrVal(FLanguage.Chinese.ToString(), FXmlTagCaption.D_Language) != dr[3].ToString().Trim() ||
                        fXmlNodeCap.get_attrVal(FXmlTagCaption.A_Description.ToString(), FXmlTagCaption.D_Description) != dr[4].ToString().Trim()
                        )
                    {
                        fXmlNodeCap.set_attrVal(FLanguage.Default.ToString(), FXmlTagCaption.D_Language, dr[0].ToString().Trim());
                        fXmlNodeCap.set_attrVal(FLanguage.English.ToString(), FXmlTagCaption.D_Language, dr[1].ToString().Trim());
                        fXmlNodeCap.set_attrVal(FLanguage.Korean.ToString(), FXmlTagCaption.D_Language, dr[2].ToString().Trim());
                        fXmlNodeCap.set_attrVal(FLanguage.Chinese.ToString(), FXmlTagCaption.D_Language, dr[3].ToString().Trim());
                        fXmlNodeCap.set_attrVal(FXmlTagCaption.A_Description.ToString(), FXmlTagCaption.D_Description, dr[4].ToString().Trim());

                        // --

                        key = dr[0].ToString().Trim();
                        cellValues = new object[]
                        {
                            key,                        // Default
                            dr[1].ToString().Trim(),    // English
                            dr[2].ToString().Trim(),    // Korean
                            dr[3].ToString().Trim(),    // Chinese
                            dr[4].ToString().Trim()     // Description
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
                if (fXmlNodeCgp != null)
                {
                    fXmlNodeCgp.Dispose();
                    fXmlNodeCgp = null;
                }

                if (fXmlNodeCap != null)
                {
                    fXmlNodeCap.Dispose();
                    fXmlNodeCap = null;
                }

                // --

                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FCaptionEditor Form Event Handler

        private void FCaptionEditor_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfCaption();

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

        private void FCaptionEditor_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfCaption();

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

        private void FCaptionEditor_FormClosing(
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

                setPropOfCaption();
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
            FPropCaption fPropCaption = null;
            FXmlNode fXmlNodeCgp = null;
            FXmlNode fXmlNodeCap = null;
            string xpath = null;
            string key = string.Empty;
            object[] cellValues = null;

            try
            {
                FCursor.waitCursor();

                // --

                fPropCaption = (FPropCaption)pgdProp.selectedObject;

                // --

                if (fPropCaption.Default.Trim() == string.Empty)
                {
                    FDebug.throwFException(m_fLfeCore.fUIWizard.generateMessage("E0001", new object[] { "Default" }));
                }

                // --

                xpath =
                    FXmlTagFAMate.E_FAMate +
                    "/" + FXmlTagCaptionGroup.E_CaptionGroup;
                fXmlNodeCgp = m_fLfeCore.fLfeFileInfo.fXmlDocLanguage.selectSingleNode(xpath);

                // --

                xpath = FXmlTagCaption.E_Caption + "[@" + FLanguage.Default.ToString() + "='" + fPropCaption.Default + "']";
                fXmlNodeCap = fXmlNodeCgp.selectSingleNode(xpath);
                if (fXmlNodeCap == null)
                {
                    fXmlNodeCap = fXmlNodeCgp.appendChild(m_fLfeCore.fLfeFileInfo.fXmlDocLanguage.createNode(FXmlTagCaption.E_Caption));
                }

                // --

                fXmlNodeCap.set_attrVal(FLanguage.Default.ToString(), FXmlTagCaption.D_Language, fPropCaption.Default);
                fXmlNodeCap.set_attrVal(FLanguage.English.ToString(), FXmlTagCaption.D_Language, fPropCaption.English);
                fXmlNodeCap.set_attrVal(FLanguage.Korean.ToString(), FXmlTagCaption.D_Language, fPropCaption.Korean);
                fXmlNodeCap.set_attrVal(FLanguage.Chinese.ToString(), FXmlTagCaption.D_Language, fPropCaption.Chinese);
                fXmlNodeCap.set_attrVal(FXmlTagCaption.A_Description.ToString(), FXmlTagCaption.D_Description, fPropCaption.Description);

                // --

                key = fPropCaption.Default;
                cellValues = new object[]
                {
                    key,
                    fPropCaption.English,
                    fPropCaption.Korean,
                    fPropCaption.Chinese,
                    fPropCaption.Description
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
                if (fXmlNodeCgp != null)
                {
                    fXmlNodeCgp.Dispose();
                    fXmlNodeCgp = null;
                }

                if (fXmlNodeCap != null)
                {
                    fXmlNodeCap.Dispose();
                    fXmlNodeCap = null;
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

                initPropOfCaption();
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
            FXmlNode fXmlNodeCap = null;
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
                    "/" + FXmlTagCaptionGroup.E_CaptionGroup +
                    "/" + FXmlTagCaption.E_Caption + "[@" + FLanguage.Default.ToString() + "='" + key + "']";
                fXmlNodeCap = m_fLfeCore.fLfeFileInfo.fXmlDocLanguage.selectSingleNode(xpath);
                fXmlNodeCap.fParentNode.removeChild(fXmlNodeCap);

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
                if (fXmlNodeCap != null)
                {
                    fXmlNodeCap.Dispose();
                    fXmlNodeCap = null;
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

                refreshGridOfCaption();
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
