/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FEapSelector.cs
--  Creator         : mjkim
--  Create Date     : 2015.08.06
--  Description     : FAMate Admin Manager EAP Select Dialog Form Class 
--  History         : Created by mjkim at 2014.09.02
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager
{
    public partial class FEapSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private string m_oldEapName = string.Empty;
        private string m_deleteFlag = string.Empty; 

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEapSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEapSelector(
            FAdmCore fAdmCore,
            string oldEapName,
            string deleteFlag
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
            m_oldEapName = oldEapName;
            m_deleteFlag = deleteFlag;
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

        public string selectedEapName
        {
            get
            {
                try
                {
                    return grdList.activeDataRowKey;
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
                    return grdList.activeDataRow == null ? string.Empty : grdList.activeDataRow["Type"].ToString();
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

        private void designGridOfList(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --                
                uds.Band.Columns.Add("EAP");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Type");

                // --

                grdList.DisplayLayout.Bands[0].Columns["EAP"].CellAppearance.Image = Properties.Resources.Eap;
                // --
                grdList.DisplayLayout.Bands[0].Columns["EAP"].Width = 150;
                grdList.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
                grdList.DisplayLayout.Bands[0].Columns["Type"].Width = 80;

                // --

                grdList.multiSelected = false;
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

        private void refreshGridOfList(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            UltraGridRow row = null;
            object[] cellValues = null;
            int nextRowNumber = 0;
            int index = 0;
            string deleteFlag = string.Empty;

            try
            {
                btnOk.Enabled = false;

                // --

                grdList.beginUpdate(false);
                grdList.removeAllDataRow();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("delete_flag", m_deleteFlag, m_deleteFlag == string.Empty ? true : false);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "EapSelector", "ListAllEap", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        deleteFlag = r[6].ToString();   // Delete Flag

                        // --

                        cellValues = new object[] {
                            r[0].ToString(), // Equipment
                            r[1].ToString(), // Description
                            r[2].ToString() // Type
                            };
                        index = grdList.appendDataRow(r[0].ToString(), cellValues).Index;

                        // --

                        if (deleteFlag == "Y")
                        {
                            row = grdList.Rows.GetRowWithListIndex(index);
                            row.Appearance.ForeColor = Color.DimGray;
                        }
                    }
                } while (nextRowNumber >= 0);

                // --

                grdList.endUpdate();

                // --

                if (grdList.Rows.Count > 0)
                {
                    if (m_oldEapName != string.Empty)
                    {
                        grdList.activateDataRow(m_oldEapName);
                    }
                    // --
                    if (grdList.ActiveRow == null || grdList.ActiveRow.VisibleIndex < 0)
                    {
                        grdList.ActiveRow = grdList.Rows[0];
                    }
                }

                // --

                grdList.Focus();
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
                row = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FEapSelector Form Event Handler

        private void FEapSelector_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                btnReset.Enabled = (m_oldEapName == string.Empty ? false : true);

                // --

                designGridOfList();
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

        private void FEapSelector_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfList();                
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

        private void FEapSelector_KeyDown(
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
                    refreshGridOfList();
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

                if (grdList.activeDataRow == null)
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

        //------------------------------------------------------------------------------------------------------------------------

        private void grdList_DoubleClickRow(
            object sender,
            DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                grdList.Selected.Rows.Clear();
                grdList.ActiveRow.Selected = true;
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

                grdList.Selected.Rows.Clear();
                grdList.ActiveRow = null;
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

                refreshGridOfList();
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
