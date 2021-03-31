/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FEquipmentTypeSelector.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2013.07.03
--  Description     : FAMate Admin Manager Equipment Type Select Dialog Form Class 
--  History         : Created by jungyoul.moon at 2013.07.03
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using System.Collections;

namespace Nexplant.MC.AdminManager
{
    public partial class FEquipmentTypeSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private string m_oldType = string.Empty;
        private string m_selectedType = string.Empty;
        private string[] m_selectedTypeList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEquipmentTypeSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEquipmentTypeSelector(
            FAdmCore fAdmCore
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEquipmentTypeSelector(
            FAdmCore fAdmCore,
            string oldType
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
            m_oldType = oldType;
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

        public string selectedType
        {
            get
            {
                try
                {
                    return m_selectedType;
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

        public string[] selectedTypeList
        {
            get
            {
                try
                {
                    return m_selectedTypeList;
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

            set 
            {
                try
                {
                    m_selectedTypeList = value;
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

        private void designGridOfList(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --                
                uds.Band.Columns.Add("Equipment Type");
                uds.Band.Columns.Add("Description");

                // --

                grdList.DisplayLayout.Bands[0].Columns["Equipment Type"].CellAppearance.Image = Properties.Resources.EquipmentType;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Equipment Type"].Width = 120;
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

        private void refreshGridOfType(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            UltraGridRow row = null;
            UltraGridCell cell = null;
            object[] cellValues = null;
            int index = 0;
            string key = string.Empty;
            int nextRowNumber = 0;

            try
            {
                btnOk.Enabled = false;

                // --

                grdList.beginUpdate(false);
                grdList.removeAllDataRow();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "EquipmentTypeSelector", "ListEquipmentType", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // Type
                            r[1].ToString()    // Description
                            };
                        key = (string)cellValues[0];
                        index = grdList.appendDataRow(key, cellValues).Index;
         
                        // --

                        row = grdList.Rows.GetRowWithListIndex(index);

                        // --

                        cell = row.Cells["Equipment Type"];
                    }
                } while (nextRowNumber >= 0);

                // --

                grdList.endUpdate();

                // --

                if (grdList.Rows.Count > 0)
                {
                    if (m_oldType != string.Empty)
                    {
                        grdList.activateDataRow(m_oldType);
                    }
                    // --
                    if (grdList.activeDataRow == null)
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
                row = null;
                cell = null;
                fSqlParams = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void selectType(
            )
        {
            try
            {
                m_selectedType = grdList.activeDataRowKey;
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

        #region FEquipmentTypeSelector Form Event Handler

        private void FEquipmentTypeSelector_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                btnReset.Enabled = (m_oldType == string.Empty ? false : true);

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

        private void FEquipmentTypeSelector_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfType();
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

        private void FEquipmentTypeSelector_KeyDown(
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
                    refreshGridOfType();
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

                selectType();

                // --

                m_selectedTypeList = grdList.selectedDataRowKeys;
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
            string server = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                selectType();

                // --

                selectedTypeList = grdList.selectedDataRowKeys;
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
                m_selectedType = string.Empty;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region rstToolbar Control EventHandler

        private void rstToolbar_RefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --     

                refreshGridOfType();
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
