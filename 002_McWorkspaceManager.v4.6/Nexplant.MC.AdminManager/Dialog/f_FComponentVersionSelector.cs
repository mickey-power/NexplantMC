/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FComponentVersionSelector.cs
--  Creator         : spike.lee
--  Create Date     : 2012.05.07
--  Description     : FAMate Admin Manager Component Version Select Dialog Form Class 
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
    public partial class FComponentVersionSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private string m_componentType = string.Empty;
        private string m_oldComponent = string.Empty;
        private string m_oldComponentVer = string.Empty;
        private int m_step = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FComponentVersionSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FComponentVersionSelector(
            FAdmCore fAdmCore,
            string oldComponent,
            string oldComponentVer
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
            // --
            m_oldComponent = oldComponent;
            m_oldComponentVer = oldComponentVer;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FComponentVersionSelector(
            FAdmCore fAdmCore,
            string componentType,
            string oldComponent,
            string oldComponentVer
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
            // --
            m_componentType = componentType;
            m_oldComponent = oldComponent;
            m_oldComponentVer = oldComponentVer;
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

        public string selectedComponent
        {
            get
            {
                try
                {
                    return grdComponent.activeDataRowKey;
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
                    return grdComponent.activeDataRow == null ? string.Empty : grdComponent.activeDataRow["Type"].ToString();
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

        public string selectedComponentVer
        {
            get
            {
                try
                {
                    return grdComponentVer.activeDataRowKey;
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

        private void designGridOfComponent(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdComponent.dataSource;
                // --
                uds.Band.Columns.Add("Component");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Type");
                uds.Band.Columns.Add("Release Ver.");
                uds.Band.Columns.Add("Last Ver.");

                // --

                grdComponent.DisplayLayout.Bands[0].Columns["Component"].CellAppearance.Image = Properties.Resources.Component;
                grdComponent.DisplayLayout.Bands[0].Columns["Last Ver."].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdComponent.DisplayLayout.Bands[0].Columns["Release Ver."].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                // --
                grdComponent.DisplayLayout.Bands[0].Columns["Component"].Header.Fixed = true;
                // --
                grdComponent.DisplayLayout.Bands[0].Columns["Component"].Width = 150;
                grdComponent.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
                grdComponent.DisplayLayout.Bands[0].Columns["Type"].Width = 80;
                grdComponent.DisplayLayout.Bands[0].Columns["Release Ver."].Width = 80;
                grdComponent.DisplayLayout.Bands[0].Columns["Last Ver."].Width = 80;
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

        private void designGridOfComponentVer(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdComponentVer.dataSource;
                // --
                uds.Band.Columns.Add("Version");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Comment");

                // --

                grdComponentVer.DisplayLayout.Bands[0].Columns["Comment"].ButtonDisplayStyle = ButtonDisplayStyle.OnMouseEnter;
                // --
                grdComponentVer.DisplayLayout.Bands[0].Columns["Version"].CellAppearance.Image = Properties.Resources.ComponentVersion;
                // --
                grdComponentVer.DisplayLayout.Bands[0].Columns["Comment"].CellButtonAppearance.BorderColor = Color.Transparent;
                grdComponentVer.DisplayLayout.Bands[0].Columns["Comment"].CellButtonAppearance.Image = Properties.Resources.More;
                // --
                grdComponentVer.DisplayLayout.Bands[0].Columns["Version"].Header.Fixed = true;
                // --
                grdComponentVer.DisplayLayout.Bands[0].Columns["Version"].Width = 60;
                grdComponentVer.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
                grdComponentVer.DisplayLayout.Bands[0].Columns["Comment"].Width = 100;                               

                // --

                grdComponentVer.ClickCellButton += new CellEventHandler(grdComponentVer_ClickCellButton);
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

        private void refreshGridOfComponent(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            object[] cellValues = null;
            string key = string.Empty;
            int nextRowNumber = 0;

            try
            {
                grdComponent.beginUpdate();
                grdComponent.removeAllDataRow();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("com_type", m_componentType, m_componentType == string.Empty ? true : false);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "ComponentVerSelector", "ListComponent", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // Component
                            r[1].ToString(),   // Description
                            r[4].ToString(),   // Type
                            r[2].ToString(),   // Release Ver.
                            r[3].ToString()    // Last Ver.
                            };
                        key = (string)cellValues[0];
                        grdComponent.appendDataRow(key, cellValues);                        
                    }
                } while (nextRowNumber >= 0);

                // --

                grdComponent.endUpdate();

                // --

                if (grdComponent.Rows.Count > 0)                
                {
                    if (m_oldComponent != string.Empty)
                    {
                        grdComponent.activateDataRow(m_oldComponent);
                    }
                    // --
                    if (grdComponent.activeDataRow == null)
                    {
                        grdComponent.ActiveRow = grdComponent.Rows[0];
                    }
                }

                // --
                if (m_step == 0)
                {
                    grdComponent.Focus();
                }
            }
            catch (Exception ex)
            {
                grdComponent.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfComponentVer(
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
                if (grdComponent.activeDataRow == null)
                {
                    return;
                }

                // --

                grdComponentVer.beginUpdate(false);
                grdComponentVer.removeAllDataRow();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("component", grdComponent.activeDataRowKey);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "ComponentVerSelector", "ListComponentVer", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString() + (r[2].ToString() == FYesNo.Yes.ToString() ? "*" : ""), // Version
                            r[1].ToString(),   // Description                            
                            r[3].ToString()    // Comment
                            };
                        key = r[0].ToString();
                        index = grdComponentVer.appendDataRow(key, cellValues).Index;

                        // --

                        if (r[3].ToString() == string.Empty)
                        {
                            grdComponentVer.Rows.GetRowWithListIndex(index).Cells["Comment"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.FormattedText;
                        }
                        else
                        {
                            grdComponentVer.Rows.GetRowWithListIndex(index).Cells["Comment"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
                        }
                    }
                } while (nextRowNumber >= 0);

                // --

                grdComponentVer.endUpdate(false);

                // --
                
                if (grdComponentVer.Rows.Count > 0)
                {
                    if (grdComponent.activeDataRowKey == m_oldComponent && m_oldComponentVer != string.Empty)
                    {
                        grdComponentVer.activateDataRow(m_oldComponentVer);
                    }
                    // --
                    if (grdComponentVer.activeDataRow == null)
                    {
                        grdComponentVer.ActiveRow = grdComponentVer.Rows[0];
                    }
                }

                // --

                if (m_step == 1)
                {
                    grdComponentVer.Focus();
                }                
            }
            catch (Exception ex)
            {
                grdComponentVer.endUpdate(false);
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
                    btnNext.Enabled = (grdComponent.activeDataRow == null ? false : true);
                    btnOk.Enabled = false;
                    // --
                    grdComponent.Focus();
                    
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
                    refreshGridOfComponentVer();
                    if (grdComponentVer.activeDataRow != null)
                    {
                        btnOk.Enabled = true;
                    }
                    // --
                    grdComponentVer.Focus();
                }
                else if (m_step == 1)
                {
                    selectComponentVer();
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

        private void selectComponentVer(
            )
        {
            try
            {
                grdComponent.Selected.Rows.Clear();
                grdComponent.ActiveRow.Selected = true;
                grdComponentVer.Selected.Rows.Clear();
                grdComponentVer.ActiveRow.Selected = true;
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

        #region FComponentVersionSelector Form Event Handler

        private void FComponentVersionSelector_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                btnReset.Enabled = (m_oldComponentVer == string.Empty ? false : true);

                // --

                designGridOfComponent();
                designGridOfComponentVer();
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

        private void FComponentVersionSelector_Shown(
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

                refreshGridOfComponent();

                // --

                if (grdComponent.activeDataRow != null)
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

        private void FComponentVersionSelector_KeyDown(
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
                        refreshGridOfComponent();
                    }
                    else if (m_step == 1)
                    {
                        refreshGridOfComponentVer();
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

                selectComponentVer();
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

                grdComponent.Selected.Rows.Clear();
                grdComponent.ActiveRow = null;
                grdComponentVer.Selected.Rows.Clear();
                grdComponentVer.ActiveRow = null;
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

                if (sender == rstCom)
                {
                    refreshGridOfComponent();
                }
                else if (sender == rstComVer)
                {
                    refreshGridOfComponentVer();
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

                if (sender == rstCom)
                {
                    if (!grdComponent.searchGridRow(e.searchWord))
                    {
                        FMessageBox.showInformation("Search", m_fAdmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { e.searchWord }), this);
                    }
                }
                else if (sender == rstComVer)
                {
                    if (!grdComponentVer.searchGridRow(e.searchWord))
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

        #region grdCommentVer Control Event Handler

        private void grdComponentVer_ClickCellButton(
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
