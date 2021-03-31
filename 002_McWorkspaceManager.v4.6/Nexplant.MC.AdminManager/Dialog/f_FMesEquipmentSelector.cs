/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FMesEquipmentSelector.cs
--  Creator         : iskim
--  Create Date     : 2014.09.04
--  Description     : FAMate Admin Manager MES Equipment Select Dialog Form Class 
--  History         : Created by iskim at 2014.09.04
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
    public partial class FMesEquipmentSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private string m_oldEqp = string.Empty;
        private string m_selectedEqpName = string.Empty;
        private int m_selectedEqpId = 0;
        private string m_selectedEqpDesc = string.Empty;
        private string m_selectedEqpType = string.Empty;
        private string m_selectedEqpLine = string.Empty;
        private string m_selectedEqpArea = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FMesEquipmentSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FMesEquipmentSelector(
            FAdmCore fAdmCore
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FMesEquipmentSelector(
            FAdmCore fAdmCore,
            string oldEqp
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
            m_oldEqp = oldEqp;
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

        public string selectedEqpName
        {
            get
            {
                try
                {
                    return m_selectedEqpName;
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

        public int selectedEqpId
        {
            get
            {
                try
                {
                    return m_selectedEqpId;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string selectedEqpDesc
        {
            get
            {
                try
                {
                    return m_selectedEqpDesc;
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

        public string selectedEqpType
        {
            get
            {
                try
                {
                    return m_selectedEqpType;
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

        public string selectedEqpLine
        {
            get
            {
                try
                {
                    return m_selectedEqpLine;
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

        public string selectedEqpArea
        {
            get
            {
                try
                {
                    return m_selectedEqpArea;
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

        private void clear(
            )
        {
            try
            {
                grdDeptEqpList.beginUpdate();
                grdDeptEqpList.removeAllDataRow();
                grdDeptEqpList.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdDeptEqpList.endUpdate();

                // --

                btnOk.Enabled = false;
            }
            catch (Exception ex)
            {
                grdDeptEqpList.endUpdate();
                // --
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void designGridOfEqpList(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdEqpList.dataSource;
                // --                
                uds.Band.Columns.Add("Equipment");
                uds.Band.Columns.Add("Equipment ID");
                uds.Band.Columns.Add("Description");

                // --

                grdEqpList.DisplayLayout.Bands[0].Columns["Equipment"].CellAppearance.Image = Properties.Resources.Equipment;
                // --
                grdEqpList.DisplayLayout.Bands[0].Columns["Equipment"].Width = 150;
                grdEqpList.DisplayLayout.Bands[0].Columns["Equipment ID"].Width = 100;
                grdEqpList.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void designGridOfDeptEqpList(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdDeptEqpList.dataSource;
                // --                
                uds.Band.Columns.Add("Equipment");
                uds.Band.Columns.Add("Equipment ID");
                uds.Band.Columns.Add("Description");

                // --

                grdDeptEqpList.DisplayLayout.Bands[0].Columns["Equipment"].CellAppearance.Image = Properties.Resources.Equipment;
                // --
                grdDeptEqpList.DisplayLayout.Bands[0].Columns["Equipment"].Width = 150;
                grdDeptEqpList.DisplayLayout.Bands[0].Columns["Equipment ID"].Width = 100;
                grdDeptEqpList.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void designComboOfGroup(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = ucbGroup.dataSource;
                // --
                uds.Band.Columns.Add("Group");
                uds.Band.Columns.Add("Group Code");
                // --

                //ucbGroup.Appearance.Image = Properties.Resources.EapAttrCategory;
                // --
                //ucbGroup.DisplayLayout.Bands[0].Columns["Group"].CellAppearance.Image = Properties.Resources.EapAttrCategory;
                ucbGroup.DisplayLayout.Bands[0].Columns["Group"].Width = 120;
                ucbGroup.DisplayLayout.Bands[0].Columns["Group Code"].Width = 50;
                // --
                ucbGroup.DisplayLayout.Bands[0].Columns["Group Code"].Hidden = true;
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

        private void refreshComboOfGroup(
             )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            object[] cellValues = null;
            string key = string.Empty;
            int nextRowNumber = 0;

            try
            {
                ucbGroup.beginUpdate();
                ucbGroup.removeAllDataRow();

                // --

                fSqlParams = new FSqlParams();

                // --

                // ***
                // Init. Data input
                // ***
                cellValues = new object[]{
                    " ",   
                    string.Empty    
                    };
                ucbGroup.appendDataRow(string.Empty, cellValues);

                // --

                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "MesEquipmentSelector", "ListGroup", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[]{
                            r[0].ToString(),   // Group
                            r[1].ToString()    // Group Code
                        };
                        key = (string)cellValues[1];
                        ucbGroup.appendDataRow(key, cellValues);
                    }
                } while (nextRowNumber >= 0);

                // --

                ucbGroup.endUpdate();
            }
            catch (Exception ex)
            {
                ucbGroup.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfEquipment(
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

                grdEqpList.beginUpdate(false);
                grdEqpList.removeAllDataRow();

                // --
                fSqlParams = new FSqlParams();
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "MesEquipmentSelector", "ListEquipment", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // Equipment
                            r[1].ToString(),   // Equipment ID
                            r[2].ToString()    // Description
                            };
                        key = (string)cellValues[0];
                        index = grdEqpList.appendDataRow(key, cellValues).Index;
         
         
                        // --

                        row = grdEqpList.Rows.GetRowWithListIndex(index);

                        // --

                        cell = row.Cells["Equipment"];
                    }
                } while (nextRowNumber >= 0);

                // --

                grdEqpList.endUpdate();

                // --

                if (grdEqpList.Rows.Count > 0)
                {
                    if (m_oldEqp != string.Empty)
                    {
                        grdEqpList.activateDataRow(m_oldEqp);
                    }
                    // --
                    if (grdEqpList.activeDataRow == null)
                    {
                        grdEqpList.ActiveRow = grdEqpList.Rows[0];
                    }
                }
            }
            catch (Exception ex)
            {
                grdEqpList.endUpdate();
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

        private void refreshGridOfDeptEquipment(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            UltraGridRow row = null;
            UltraGridCell cell = null;
            object[] cellValues = null;
            int index = 0;
            int key = 0;
            int nextRowNumber = 0;

            try
            {
                btnOk.Enabled = false;

                // --

                grdDeptEqpList.beginUpdate(false);
                grdDeptEqpList.removeAllDataRow();

                // --
                fSqlParams = new FSqlParams();
                fSqlParams.add("group_name", ucbGroup.activeDataRowKey + "%", ucbGroup.activeDataRowKey == string.Empty ? true : false);
                fSqlParams.add("dept_class", txtDeptClass.Tag.ToString(), txtDeptClass.Tag.ToString() == string.Empty ? true : false);
                fSqlParams.add("dept_code", txtDept.Tag.ToString(), txtDept.Tag.ToString() == string.Empty ? true : false);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "MesEquipmentSelector", "ListDepartmentEquipment", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // Equipment
                            r[1].ToString(),   // Equipment ID
                            r[2].ToString()    // Description
                            };
                        index = grdDeptEqpList.appendDataRow((key++).ToString(), cellValues).Index;

                        // --

                        row = grdDeptEqpList.Rows.GetRowWithListIndex(index);

                        // --

                        cell = row.Cells["Equipment"];
                    }
                } while (nextRowNumber >= 0);

                // --

                grdDeptEqpList.endUpdate();

                // --

                if (grdDeptEqpList.Rows.Count > 0)
                {
                    if (m_oldEqp != string.Empty)
                    {
                        grdDeptEqpList.activateDataRow(m_oldEqp);
                    }
                    // --
                    if (grdDeptEqpList.activeDataRow == null)
                    {
                        grdDeptEqpList.ActiveRow = grdDeptEqpList.Rows[0];
                    }
                }
            }
            catch (Exception ex)
            {
                grdDeptEqpList.endUpdate();
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

        private void selectEqp(
            )
        {
            try
            {
                m_selectedEqpName = grdEqpList.selectedDataRows[0]["Equipment"].ToString();
                m_selectedEqpId = Convert.ToInt32(grdEqpList.selectedDataRows[0]["Equipment ID"]);
                m_selectedEqpDesc = grdEqpList.selectedDataRows[0]["Description"].ToString();
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

        //------------------------------------------------------------------------------------------------------------------------

        private void selectDeptEqp(
            )
        {
            try
            {
                m_selectedEqpName = grdDeptEqpList.selectedDataRows[0]["Equipment"].ToString();
                m_selectedEqpId = Convert.ToInt32(grdDeptEqpList.selectedDataRows[0]["Equipment ID"]);
                m_selectedEqpDesc = grdDeptEqpList.selectedDataRows[0]["Description"].ToString();
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

        //------------------------------------------------------------------------------------------------------------------------

        private void setRelation(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;

            try
            {
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("eqp_name", selectedEqpName);
                // --
                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "MesEquipmentSelector", "SearchEquipment", fSqlParams, false);
                
                // --

                if (dt.Rows.Count > 0)
                {
                    m_selectedEqpType = dt.Rows[0]["TYPE"].ToString();
                    m_selectedEqpArea = dt.Rows[0]["AREA"].ToString();
                    m_selectedEqpLine = dt.Rows[0]["LINE"].ToString();
                }
                else
                {
                    m_selectedEqpType = string.Empty;
                    m_selectedEqpArea = string.Empty;
                    m_selectedEqpLine = string.Empty;
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

        #region FEquipmentSelector Form Event Handler

        private void FEquipmentSelector_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                btnReset.Enabled = (m_oldEqp == string.Empty ? false : true);

                // --

                designGridOfEqpList();
                designGridOfDeptEqpList();
                designComboOfGroup();
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

        private void FEquipmentSelector_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfEquipment();
                refreshComboOfGroup();
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

        #region grdEqpList Control Event Handler

        private void grdEqpList_AfterRowActivate(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (grdEqpList.activeDataRow == null)
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

        private void grdEqpList_DoubleClickRow(
            object sender,
            DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                selectEqp();
                setRelation();
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

        #region grdDeptEqpList Control Event Handler

        private void grdDeptEqpList_AfterRowActivate(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (grdDeptEqpList.activeDataRow == null)
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

        private void grdDeptEqpList_DoubleClickRow(
            object sender,
            DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                selectDeptEqp();
                setRelation();
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
                if (tabMain.SelectedTab == tabMain.Tabs["Equipment"])
                {
                    selectEqp();
                    setRelation();
                }
                else
                {
                    selectDeptEqp();
                    setRelation();
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

        #region btnReset Control Event Handler

        private void btnReset_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                m_selectedEqpName = string.Empty;
                m_selectedEqpId = 0;
                m_selectedEqpDesc = string.Empty;
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

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region ucbGroup Control Event Handler

        private void ucbGroup_BeforeDropDown(
            object sender,
            System.ComponentModel.CancelEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshComboOfGroup();
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

        private void ucbGroup_ValueChanged(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                clear();

                // --

                txtDeptClass.Text = string.Empty;
                txtDeptClass.Tag = string.Empty;
                txtDept.Text = string.Empty;
                txtDept.Tag = string.Empty;
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

        #region txtDeptClass Control Event Handler

        private void txtDeptClass_EditorButtonClick(
            object sender,
            Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e
            )
        {
            FDepartmentClassSelector dialog = null;
            string deptClass = string.Empty;

            try
            {
                dialog = new FDepartmentClassSelector(
                    m_fAdmCore,
                    txtDeptClass.Text,
                    ucbGroup.activeDataRowKey
                    );
                if (dialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                if (dialog.selectedDeptClass != null)
                {
                    txtDeptClass.Text = dialog.selectedDeptClass["Dept. Class Name"].ToString() + " [" + dialog.selectedDeptClass["Dept. Class Code"].ToString() + "] ";
                    txtDeptClass.Tag = dialog.selectedDeptClass["Dept. Class Code"].ToString();
                }
                else
                {
                    txtDeptClass.Text = string.Empty;
                    txtDeptClass.Tag = string.Empty;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                if (dialog != null)
                {
                    dialog.Dispose();
                    dialog = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void txtDeptClass_ValueChanged(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                clear();

                // --

                txtDept.Text = string.Empty;
                txtDept.Tag = string.Empty;
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

        #region txtDept Control Evnet Handler

        private void txtDept_EditorButtonClick(
            object sender,
            Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e
            )
        {
            FDepartmentSelector dialog = null;
            string dept = string.Empty;

            try
            {
                dialog = new FDepartmentSelector(
                   m_fAdmCore,
                   txtDept.Text,
                   ucbGroup.activeDataRowKey,
                   txtDeptClass.Tag.ToString()
                   );
                if (dialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                if (dialog.selectedDept != null)
                {
                    txtDept.Text = dialog.selectedDept["Dept. Name"].ToString() + " [" + dialog.selectedDept["Dept. Code"].ToString() + "] ";
                    txtDept.Tag = dialog.selectedDept["Dept. Code"].ToString();
                }
                else
                {
                    txtDept.Text = string.Empty;
                    txtDept.Tag = string.Empty;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void txtDept_ValueChanged(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                clear();
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

        #region rstEqp Control Event Handler

        private void rstEqp_RefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --     

                refreshGridOfEquipment();
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

        private void rstEqp_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdEqpList.searchGridRow(e.searchWord))
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

        #region rstDeptEqp Control Event Handler
        
        private void rstDeptEqp_RefreshRequested(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --     

                refreshGridOfDeptEquipment();
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

        private void rstDeptEqp_SearchRequested(
            object sender, 
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdDeptEqpList.searchGridRow(e.searchWord))
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

        #region tabMain Control Event Handler
        
        private void tabMain_ActiveTabChanged(
            object sender, 
            Infragistics.Win.UltraWinTabControl.ActiveTabChangedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tab.Key == "Equipment")
                {
                    btnOk.Enabled = (grdEqpList.activeDataRowKey != string.Empty);
                }
                else if(e.Tab.Key == "Department")
                {
                    btnOk.Enabled = (grdDeptEqpList.activeDataRowKey != string.Empty);
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
