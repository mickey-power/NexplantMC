/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FUserGroupAuthoritySelector.cs
--  Creator         : mjkim 
--  Create Date     : 2013.02.04
--  Description     : FAMate Admin Manager User Group Authority Select Dialog Form Class 
--  History         : Created by mjkim at 2013.02.04
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Infragistics.Win.UltraWinTree;

namespace Nexplant.MC.AdminManager
{
    public partial class FUserGroupAuthoritySelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private string m_application = string.Empty;
        private FUserFunctionData[] m_functionList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FUserGroupAuthoritySelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FUserGroupAuthoritySelector(
            FAdmCore fAdmCore
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FUserGroupAuthoritySelector(
            FAdmCore fAdmCore,
            string application
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
            m_application = application;
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

        public FUserFunctionData[] functionList
        {
            get
            {
                try
                {
                    return m_functionList;
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

        //------------------------------------------------------------------------------------------------------------------------

        private void designGridOfUserGroup(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdUserGroup.dataSource;
                // --
                uds.Band.Columns.Add("User Group");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("All Authority");

                // --

                grdUserGroup.DisplayLayout.Bands[0].Columns["User Group"].CellAppearance.Image = Properties.Resources.UserGroup;
                // --
                grdUserGroup.DisplayLayout.Bands[0].Columns["User Group"].Header.Fixed = true;
                // --
                grdUserGroup.DisplayLayout.Bands[0].Columns["User Group"].Width = 120;
                grdUserGroup.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
                grdUserGroup.DisplayLayout.Bands[0].Columns["All Authority"].Width = 100;
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

        private void designGridOfFunction(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdFunction.dataSource;
                // --
                uds.Band.Columns.Add("Function");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Enabled Transaction", typeof(bool));

                // --

                grdFunction.DisplayLayout.Bands[0].Columns["Function"].CellActivation = Activation.NoEdit;
                grdFunction.DisplayLayout.Bands[0].Columns["Description"].CellActivation = Activation.NoEdit;
                // --
                grdFunction.DisplayLayout.Bands[0].Columns["Enabled Transaction"].CellAppearance.ForeColor = System.Drawing.Color.WhiteSmoke;
                grdFunction.DisplayLayout.Bands[0].Columns["Function"].CellAppearance.Image = Properties.Resources.UserGroupFunction;
                // --
                grdFunction.DisplayLayout.Bands[0].Columns["Enabled Transaction"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                // --
                grdFunction.DisplayLayout.Bands[0].Columns["Function"].Width = 218;
                grdFunction.DisplayLayout.Bands[0].Columns["Description"].Width = 218;
                grdFunction.DisplayLayout.Bands[0].Columns["Enabled Transaction"].Width = 30;
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

        private void setGridCellStyle(
            UltraGridCell cell
            )
        {
            try
            {
                cell.Activation = Activation.NoEdit;
                cell.ActiveAppearance.ForegroundAlpha = Infragistics.Win.Alpha.Transparent;
                cell.SelectedAppearance.ForegroundAlpha = Infragistics.Win.Alpha.Transparent;
                cell.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
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

        private void refreshGridOfUserGroup(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            object[] cellValues = null;
            string beforeKey = string.Empty;
            string key = string.Empty;
            int nextRowNumber = 0;

            try
            {
                if (grdUserGroup.activeDataRow != null)
                {
                    beforeKey = grdUserGroup.activeDataRowKey;
                }

                // --

                grdUserGroup.beginUpdate();
                grdUserGroup.removeAllDataRow();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "UserGroupAuthoritySelector", "ListUserGroup", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // User Group
                            r[1].ToString(),   // Description
                            r[2].ToString()    // All Authority   
                            };
                        key = (string)cellValues[0];
                        grdUserGroup.appendDataRow(key, cellValues);
                    }
                } while (nextRowNumber >= 0);

                // --

                grdUserGroup.endUpdate();

                // --

                if (grdUserGroup.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdUserGroup.activateDataRow(beforeKey);
                    }
                    if (grdUserGroup.activeDataRow == null)
                    {
                        grdUserGroup.ActiveRow = grdUserGroup.Rows[0];
                    }
                }

                // --

                grdUserGroup.Focus();
            }
            catch (Exception ex)
            {
                grdUserGroup.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfFunction(
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
                grdFunction.beginUpdate(false);
                grdFunction.removeAllDataRow();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("user_grp", grdUserGroup.activeDataRowKey);
                fSqlParams.add("app", m_application);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "UserGroupAuthoritySelector", "ListAuthority", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),        // Function
                            r[1].ToString(),        // Description
                            Convert.ToBoolean(r[2]) // Enabled Transaction
                            };
                        key = (string)cellValues[0];
                        index = grdFunction.appendDataRow(key, cellValues).Index;
                        // --
                        if (r[3].ToString() == FYesNo.No.ToString())
                        {
                            setGridCellStyle(grdFunction.Rows.GetRowWithListIndex(index).Cells["Enabled Transaction"]);
                        }
                    }

                } while (nextRowNumber >= 0);

                // --

                grdFunction.endUpdate(false);
            }
            catch (Exception ex)
            {
                grdFunction.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FUserGroupAuthoritySelector Form Event Handler

        private void FUserGroupAuthoritySelector_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfUserGroup();
                designGridOfFunction();
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

        private void FUserGroupAuthoritySelector_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfUserGroup();

                // --

                txtApplication.Text = m_application;
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

        private void FUserGroupAuthoritySelector_KeyDown(
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
                    if (grdFunction.Focused)
                    {
                        refreshGridOfFunction();
                    }
                    else
                    {
                        refreshGridOfUserGroup();
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

        #region grdUserGroup Control Event Handler

        private void grdUserGroup_AfterRowActivate(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfFunction();
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

        #region grdFunction Control Event Handler

        private void grdFunction_AfterRowActivate(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (grdFunction.activeDataRow == null)
                {
                    return;
                }

                // --

                btnOk.Enabled = true;
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
            int i = 0;
            FYesNo transUsed = FYesNo.No;

            try
            {
                FCursor.waitCursor();

                // --

                m_functionList = new FUserFunctionData[grdFunction.Rows.Count];
                foreach (UltraGridRow r in grdFunction.Rows)
                {
                    transUsed = FYesNo.No;
                    if (r.Cells["Enabled Transaction"].Style != Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
                    {
                        transUsed = FYesNo.Yes;
                    }
                    // --
                    m_functionList[i++] = new FUserFunctionData(
                        r.Cells["Function"].Value.ToString(),
                        r.Cells["Description"].Value.ToString(),
                        transUsed,
                        Convert.ToBoolean(r.Cells["Enabled Transaction"].Value)
                        );
                }
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

        #region rstUrgToolbar Control Event Handler

        private void rstUrgToolbar_RefreshRequested(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfUserGroup();
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

        private void rstUrgToolbar_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdUserGroup.searchGridRow(e.searchWord))
                {
                    FMessageBox.showInformation("Search", m_fAdmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { e.searchWord }), this);
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

        #region rstFunToolbar Control Event Handler

        private void rstFunToolbar_RefreshRequested(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfFunction();
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

        private void rstFunToolbar_SearchRequested(
            object sender, 
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdFunction.searchGridRow(e.searchWord))
                {
                    FMessageBox.showInformation("Search", m_fAdmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { e.searchWord }), this);
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

    }   // Class end
}   // Namespace end
