/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FPackageVersionSelector.cs
--  Creator         : spike.lee
--  Create Date     : 2012.05.07
--  Description     : FAMate Admin Manager Package Version Select Dialog Form Class 
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
    public partial class FPackageVersionSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private string m_packageType = string.Empty;
        private string m_oldPackage = string.Empty;
        private string m_oldPackageVer = string.Empty;
        private int m_step = 0;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPackageVersionSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPackageVersionSelector(
            FAdmCore fAdmCore,
            string oldPackage,
            string oldPackageVer
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
            // --
            m_oldPackage = oldPackage;
            m_oldPackageVer = oldPackageVer;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPackageVersionSelector(
            FAdmCore fAdmCore,
            string packageType,
            string oldPackage,
            string oldPackageVer
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
            // --
            m_packageType = packageType;
            m_oldPackage = oldPackage;
            m_oldPackageVer = oldPackageVer;
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

        public string selectedPackage
        {
            get
            {
                try
                {
                    return grdPackage.activeDataRowKey;
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
                    return grdPackage.activeDataRow == null ? string.Empty : grdPackage.activeDataRow["Type"].ToString();
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

        public string selectedPackageVer
        {
            get
            {
                try
                {
                    return grdPackageVer.activeDataRowKey;
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

        private void designGridOfPackage(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdPackage.dataSource;
                // --
                uds.Band.Columns.Add("Package");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Type");
                uds.Band.Columns.Add("Release Ver.");
                uds.Band.Columns.Add("Last Ver.");

                // --

                grdPackage.DisplayLayout.Bands[0].Columns["Package"].CellAppearance.Image = Properties.Resources.Package;
                grdPackage.DisplayLayout.Bands[0].Columns["Release Ver."].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdPackage.DisplayLayout.Bands[0].Columns["Last Ver."].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                // --
                grdPackage.DisplayLayout.Bands[0].Columns["Package"].Header.Fixed = true;
                // --
                grdPackage.DisplayLayout.Bands[0].Columns["Package"].Width = 150;
                grdPackage.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
                grdPackage.DisplayLayout.Bands[0].Columns["Type"].Width = 80;
                grdPackage.DisplayLayout.Bands[0].Columns["Release Ver."].Width = 80;
                grdPackage.DisplayLayout.Bands[0].Columns["Last Ver."].Width = 80;
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

        private void designGridOfPackageVer(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdPackageVer.dataSource;
                // --
                uds.Band.Columns.Add("Version");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Comment");

                // --

                grdPackageVer.DisplayLayout.Bands[0].Columns["Comment"].ButtonDisplayStyle = ButtonDisplayStyle.OnMouseEnter;
                // --
                grdPackageVer.DisplayLayout.Bands[0].Columns["Version"].CellAppearance.Image = Properties.Resources.PackageVersion;
                // --
                grdPackageVer.DisplayLayout.Bands[0].Columns["Comment"].CellButtonAppearance.BorderColor = Color.Transparent;
                grdPackageVer.DisplayLayout.Bands[0].Columns["Comment"].CellButtonAppearance.Image = Properties.Resources.More;
                // --
                grdPackageVer.DisplayLayout.Bands[0].Columns["Version"].Header.Fixed = true;
                // --
                grdPackageVer.DisplayLayout.Bands[0].Columns["Version"].Width = 60;
                grdPackageVer.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
                grdPackageVer.DisplayLayout.Bands[0].Columns["Comment"].Width = 100;

                // --

                grdPackageVer.ClickCellButton += new CellEventHandler(grdPackageVer_ClickCellButton);
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

        private void refreshGridOfPackage(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            object[] cellValues = null;
            string key = string.Empty;
            int nextRowNumber = 0;

            try
            {
                grdPackage.beginUpdate();
                grdPackage.removeAllDataRow();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("pkg_type", m_packageType, m_packageType == string.Empty ? true : false);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "PackageVerSelector", "ListPackage", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // Package
                            r[1].ToString(),   // Description
                            r[4].ToString(),   // Type
                            r[2].ToString(),   // Release Ver.
                            r[3].ToString()    // Last Ver.
                            };
                        key = (string)cellValues[0];
                        grdPackage.appendDataRow(key, cellValues);                        
                    }
                } while (nextRowNumber >= 0);

                // --

                grdPackage.endUpdate();

                // --

                if (grdPackage.Rows.Count > 0)                
                {
                    if (m_oldPackage != string.Empty)
                    {
                        grdPackage.activateDataRow(m_oldPackage);
                    }
                    // --
                    if (grdPackage.activeDataRow == null)
                    {
                        grdPackage.ActiveRow = grdPackage.Rows[0];
                    }
                }

                // --

                if (m_step == 0)
                {
                    grdPackage.Focus();
                }
            }
            catch (Exception ex)
            {
                grdPackage.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfPackageVer(
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
                if (grdPackage.activeDataRow == null)
                {
                    return;
                }

                // --

                grdPackageVer.beginUpdate(false);
                grdPackageVer.removeAllDataRow();

                // --
                
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("package", grdPackage.activeDataRowKey);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "PackageVerSelector", "ListPackageVer", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString() + (r[2].ToString() == FYesNo.Yes.ToString() ? "*" : ""), // Version
                            r[1].ToString(),   // Description                            
                            r[3].ToString()    // Comment
                            };
                        key = r[0].ToString();
                        index = grdPackageVer.appendDataRow(key, cellValues).Index;                        

                        // --

                        if (r[3].ToString() == string.Empty)
                        {
                            grdPackageVer.Rows.GetRowWithListIndex(index).Cells["Comment"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.FormattedText;
                        }
                        else
                        {
                            grdPackageVer.Rows.GetRowWithListIndex(index).Cells["Comment"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
                        }
                    }
                } while (nextRowNumber >= 0);

                // --

                grdPackageVer.endUpdate(false);

                // --                
                
                if (grdPackageVer.Rows.Count > 0)
                {
                    if (grdPackage.activeDataRowKey == m_oldPackage && m_oldPackageVer != string.Empty)
                    {
                        grdPackageVer.activateDataRow(m_oldPackageVer);
                    }
                    // --
                    if (grdPackageVer.activeDataRow == null)
                    {
                        grdPackageVer.ActiveRow = grdPackageVer.Rows[0];
                    }
                }

                // --

                if (m_step == 1)
                {
                    grdPackageVer.Focus();
                }
            }
            catch (Exception ex)
            {
                grdPackageVer.endUpdate(false);
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
                    btnNext.Enabled = (grdPackage.activeDataRow == null ? false : true);
                    btnOk.Enabled = false;
                    // --
                    grdPackage.Focus();
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
                    refreshGridOfPackageVer();
                    // --
                    if (grdPackageVer.activeDataRow != null)
                    {
                        btnOk.Enabled = true;
                    }
                    // --
                    grdPackageVer.Focus();
                }
                else if (m_step == 1)
                {
                    selectPackageVer();
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

        private void selectPackageVer(
            )
        {
            try
            {
                grdPackage.Selected.Rows.Clear();
                grdPackage.ActiveRow.Selected = true;
                grdPackageVer.Selected.Rows.Clear();
                grdPackageVer.ActiveRow.Selected = true;
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

        #region FPackageVersionSelector Form Event Handler

        private void FPackageVersionSelector_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                btnReset.Enabled = (m_oldPackageVer == string.Empty ? false : true);

                // --

                designGridOfPackage();
                designGridOfPackageVer();
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

        private void FPackageVersionSelector_Shown(
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

                refreshGridOfPackage();

                // --

                if (grdPackage.activeDataRow != null)
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

        private void FPackageVersionSelector_KeyDown(
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
                        refreshGridOfPackage();
                    }
                    else if (m_step == 1)
                    {
                        refreshGridOfPackageVer();
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

                selectPackageVer();
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

                grdPackage.Selected.Rows.Clear();
                grdPackage.ActiveRow = null;
                grdPackageVer.Selected.Rows.Clear();
                grdPackageVer.ActiveRow = null;
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

                if (sender == rstPkg)
                {
                    refreshGridOfPackage();
                }
                else if (sender == rstPkgVer)
                {
                    refreshGridOfPackageVer();
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

                if (sender == rstPkg)
                {
                    if (!grdPackage.searchGridRow(e.searchWord))
                    {
                        FMessageBox.showInformation("Search", m_fAdmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { e.searchWord }), this);
                    }
                }
                else if (sender == rstPkgVer)
                {
                    if (!grdPackageVer.searchGridRow(e.searchWord))
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

        #region grdpackageVer Control Event Handler

        private void grdPackageVer_ClickCellButton(
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
