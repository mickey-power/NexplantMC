/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FModelVersionSelector.cs
--  Creator         : spike.lee
--  Create Date     : 2012.05.07
--  Description     : FAMate Admin Manager Model Version Select Dialog Form Class 
--  History         : Created by spike.lee at 2012.05.07
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;

namespace Nexplant.MC.AdminManager
{
    public partial class FModelVersionSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private string m_modelType = string.Empty;
        private string m_oldModel = string.Empty;
        private string m_oldModelVer = string.Empty;
        private int m_step = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FModelVersionSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FModelVersionSelector(
            FAdmCore fAdmCore,
            string oldModel,
            string oldModelVer
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
            // --
            m_oldModel = oldModel;
            m_oldModelVer = oldModelVer;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FModelVersionSelector(
            FAdmCore fAdmCore,
            string modelType,
            string oldModel,
            string oldModelVer
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
            // --
            m_modelType = modelType;
            m_oldModel = oldModel;
            m_oldModelVer = oldModelVer;
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
                    m_fAdmCore = null;
                }
                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public string selectedModel
        {
            get
            {
                try
                {
                    return grdModel.activeDataRowKey;
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

        public string selectedType
        {
            get
            {
                try
                {
                    return grdModel.activeDataRow == null ? string.Empty : grdModel.activeDataRow["Type"].ToString();
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

        public string selectedModelVer
        {
            get
            {
                try
                {
                    return grdModelVer.activeDataRowKey;
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

        private void designGridOfModel(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdModel.dataSource;
                // --
                uds.Band.Columns.Add("Model");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Type");
                uds.Band.Columns.Add("Release Ver.");
                uds.Band.Columns.Add("Last Ver.");

                // --

                grdModel.DisplayLayout.Bands[0].Columns["Model"].CellAppearance.Image = Properties.Resources.Model;
                // --
                grdModel.DisplayLayout.Bands[0].Columns["Release Ver."].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdModel.DisplayLayout.Bands[0].Columns["Last Ver."].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                // --
                grdModel.DisplayLayout.Bands[0].Columns["Model"].Header.Fixed = true;
                // --
                grdModel.DisplayLayout.Bands[0].Columns["Model"].Width = 200;
                grdModel.DisplayLayout.Bands[0].Columns["Description"].Width = 180;
                grdModel.DisplayLayout.Bands[0].Columns["Type"].Width = 80;
                grdModel.DisplayLayout.Bands[0].Columns["Release Ver."].Width = 80;
                grdModel.DisplayLayout.Bands[0].Columns["Last Ver."].Width = 80;
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

        private void designGridOfModelVer(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdModelVer.dataSource;
                // --
                uds.Band.Columns.Add("Version");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Comment");

                // --

                grdModelVer.DisplayLayout.Bands[0].Columns["Comment"].ButtonDisplayStyle = ButtonDisplayStyle.OnMouseEnter;
                // --
                grdModelVer.DisplayLayout.Bands[0].Columns["Version"].CellAppearance.Image = Properties.Resources.ModelVersion;
                // --
                grdModelVer.DisplayLayout.Bands[0].Columns["Comment"].CellButtonAppearance.BorderColor = Color.Transparent;
                grdModelVer.DisplayLayout.Bands[0].Columns["Comment"].CellButtonAppearance.Image = Properties.Resources.More;
                // --
                grdModelVer.DisplayLayout.Bands[0].Columns["Version"].Header.Fixed = true;
                // --
                grdModelVer.DisplayLayout.Bands[0].Columns["Version"].Width = 60;
                grdModelVer.DisplayLayout.Bands[0].Columns["Description"].Width = 200;                
                grdModelVer.DisplayLayout.Bands[0].Columns["Comment"].Width = 100;

                // --

                grdModelVer.ClickCellButton +=new CellEventHandler(grdModelVer_ClickCellButton);
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

        private void refreshGridOfModel(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            object[] cellValues = null;
            string key = string.Empty;
            int nextRowNumber = 0;

            try
            {
                grdModel.beginUpdate();
                grdModel.removeAllDataRow();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("mdl_type", m_modelType, m_modelType == string.Empty ? true : false);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "ModelVerSelector", "ListModel", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(), // Model
                            r[1].ToString(), // Description
                            r[4].ToString(), // Type
                            r[2].ToString(), // Release Ver.
                            r[3].ToString()  // Last Ver.
                            };
                        key = (string)cellValues[0];
                        grdModel.appendDataRow(key, cellValues);                        
                    }
                } while (nextRowNumber >= 0);

                // --

                grdModel.endUpdate();

                // --

                if (grdModel.Rows.Count > 0)                
                {
                    if (m_oldModel != string.Empty)
                    {
                        grdModel.activateDataRow(m_oldModel);
                    }
                    // --
                    if (grdModel.activeDataRow == null)
                    {
                        grdModel.ActiveRow = grdModel.Rows[0];
                    }
                }

                // --

                if (m_step == 0)
                {
                    grdModel.Focus();
                }
            }
            catch (Exception ex)
            {
                grdModel.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfModelVer(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            object[] cellValues = null;
            string key = string.Empty;
            int nextRowNumber = 0;
            int index = 0;

            try
            {
                if (grdModel.activeDataRow == null)
                {
                    return;
                }

                // --

                grdModelVer.beginUpdate(false);
                grdModelVer.removeAllDataRow();

                // --
                
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("model", grdModel.activeDataRowKey);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "ModelVerSelector", "ListModelVer", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString() + (r[2].ToString() == FYesNo.Yes.ToString() ? "*" : ""), // Version
                            r[1].ToString(),   // Description                            
                            r[3].ToString()    // Comment
                            };
                        key = r[0].ToString();
                        index = grdModelVer.appendDataRow(key, cellValues).Index;   
                     
                        // --

                        if (r[3].ToString() == string.Empty)
                        {
                            grdModelVer.Rows.GetRowWithListIndex(index).Cells["Comment"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.FormattedText;
                        }
                        else
                        {
                            grdModelVer.Rows.GetRowWithListIndex(index).Cells["Comment"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
                        }
                    }
                } while (nextRowNumber >= 0);

                // --

                grdModelVer.endUpdate(false);

                // --

                if (grdModelVer.Rows.Count > 0)
                {
                    if (grdModel.activeDataRowKey == m_oldModel && m_oldModelVer != string.Empty)
                    {
                        grdModelVer.activateDataRow(m_oldModelVer);
                    }
                    // --
                    if (grdModelVer.activeDataRow == null)
                    {
                        grdModelVer.ActiveRow = grdModelVer.Rows[0];
                    }
                }

                // --

                if (m_step == 1)
                {
                    grdModelVer.Focus();
                }
            }
            catch (Exception ex)
            {
                grdModelVer.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procPreviousStep(
            )
        {
            try
            {
                if (m_step == 0)
                {
                    // No Action
                }
                else if (m_step == 1)
                {
                    m_step = 0;
                    pnlStep1.Visible = true;
                    pnlStep2.Visible = false;

                    // --
                    
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = (grdModel.activeDataRow == null ? false : true);
                    btnOk.Enabled = false;
                    // --
                    grdModel.Focus();
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

        private void procNextStep(
            )
        {
            try
            {
                if (m_step == 0)
                {
                    m_step = 1;
                    pnlStep1.Visible = false;
                    pnlStep2.Visible = true;

                    // --

                    btnPrevious.Enabled = true;
                    btnNext.Enabled = false;
                    btnOk.Enabled = false;
                    // --
                    refreshGridOfModelVer();
                    // --
                    if (grdModelVer.activeDataRow != null)
                    {
                        btnOk.Enabled = true;
                    }
                    // --
                    grdModelVer.Focus();
                }
                else if (m_step == 1)
                {
                    selectModelVer();
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

        private void selectModelVer(
            )
        {
            try
            {
                grdModel.Selected.Rows.Clear();
                grdModel.ActiveRow.Selected = true;
                grdModelVer.Selected.Rows.Clear();
                grdModelVer.ActiveRow.Selected = true;
                // --
                this.DialogResult = DialogResult.OK;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FModelVersionSelector Form Event Handler

        private void FModelVersionSelector_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                btnReset.Enabled = (m_oldModelVer == string.Empty ? false : true);

                // --

                designGridOfModel();
                designGridOfModelVer();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FModelVersionSelector_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_step = 0;
                btnPrevious.Enabled = false;
                btnNext.Enabled = false;
                btnOk.Enabled = false;

                // --

                refreshGridOfModel();

                // --

                if (grdModel.activeDataRow != null)
                {
                    btnNext.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FModelVersionSelector_KeyDown(
            object sender, 
            KeyEventArgs e
            )
        {
            try
            {
                if (e.KeyCode == Keys.F5)
                {
                    FCursor.waitCursor();
                    // --
                    if (m_step == 0)
                    {
                        refreshGridOfModel();
                    }
                    else if (m_step == 1)
                    {
                        refreshGridOfModelVer();
                    }
                    // --
                    FCursor.defaultCursor();
                }
            }
            catch (Exception ex)
            {
                FCursor.defaultCursor();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnPrevious Control Event Handler

        private void btnPrevious_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                procPreviousStep();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnNext Control Event Handler

        private void btnNext_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                procNextStep();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnOk Control Event Handler

        private void btnOk_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                selectModelVer();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnReset Control Event Handler

        private void btnReset_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                grdModel.Selected.Rows.Clear();
                grdModel.ActiveRow = null;
                grdModelVer.Selected.Rows.Clear();
                grdModelVer.ActiveRow = null;
                // --
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Grid Control Common Event Handler

        private void grdCommon_DoubleClickRow(
            object sender, 
            DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                procNextStep();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region RefreshAndSearchToolbar Control Common EventHandler

        private void rstCommon_RefreshRequested(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (sender == rstMdl)
                {
                    refreshGridOfModel();
                }
                else if (sender == rstMdlVer)
                {
                    refreshGridOfModelVer();
                } 
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void rstCommon_SearchRequested(
            object sender, 
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (sender == rstMdl)
                {
                    if (!grdModel.searchGridRow(e.searchWord))
                    {
                        FMessageBox.showInformation("Search", m_fAdmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { e.searchWord }), this);
                    }
                }
                else if (sender == rstMdlVer)
                {
                    if (!grdModelVer.searchGridRow(e.searchWord))
                    {
                        FMessageBox.showInformation("Search", m_fAdmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { e.searchWord }), this);
                    }
                }       
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Grid Control Cell Button Event Handler

        private void grdModelVer_ClickCellButton(
            object sender,
            CellEventArgs e
            )
        {
            FCommentViewer fDialog = null;

            try
            {
                if (e.Cell.Column.Key == "Comment")
                {
                    fDialog = new FCommentViewer(m_fAdmCore, e.Cell.Value.ToString());
                    fDialog.ShowDialog(this);
                    e.Cell.ActiveAppearance.BackColor = Color.WhiteSmoke;
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fDialog != null)
                {
                    fDialog.Dispose();
                    fDialog = null;
                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
