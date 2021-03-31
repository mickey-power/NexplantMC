/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FEquipmentClassSelector.cs
--  Creator         : iskim
--  Create Date     : 2013.07.05
--  Description     : FAMate Admin Manager FEquipmentSelector Select Dialog Form Class 
--  History         : Created by iskim at 2013.07.05
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Infragistics.Win.UltraWinTree;

namespace Nexplant.MC.AdminManager
{
    public partial class FEquipmentClassSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private Hashtable m_selectedEquipmentList = null;
        private Dictionary<string, FStructureEquipment> m_selectedEquipmentListByObject = null;
        private bool m_isMultiSelect = true;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEquipmentClassSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEquipmentClassSelector(
            FAdmCore fAdmCore
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEquipmentClassSelector(
            FAdmCore fAdmCore,
            bool isMultiSelect
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
            m_isMultiSelect = isMultiSelect;
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

        public Hashtable selectedEquipmentList
        {
            get
            {
                try
                {
                    return m_selectedEquipmentList;
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

        //------------------------------------------------------------------------------------------------------------------------

        public Dictionary<string, FStructureEquipment> selectedEquipmentListByObject
        {
            get
            {
                try
                {
                    return m_selectedEquipmentListByObject;
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
        
        private void designGridOfEquipment(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --
                uds.Band.Columns.Add("Equipment");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Control Mode");
                uds.Band.Columns.Add("MDLN");
                uds.Band.Columns.Add("SOFTREV");
                uds.Band.Columns.Add("EAP");
                uds.Band.Columns.Add("Server");
                uds.Band.Columns.Add("Up/Down");
                uds.Band.Columns.Add("Status");
                uds.Band.Columns.Add("Package");
                uds.Band.Columns.Add("Model");
                uds.Band.Columns.Add("Component");
                uds.Band.Columns.Add("Ip Address");

                // --

                grdList.ImageList = new ImageList();
                // --
                grdList.ImageList.Images.Add("Equipment_Unknown", Properties.Resources.Equipment_Unknown);
                grdList.ImageList.Images.Add("Equipment_Offline", Properties.Resources.Equipment_Offline);
                grdList.ImageList.Images.Add("Equipment_OnlineLocal", Properties.Resources.Equipment_OnlineLocal);
                grdList.ImageList.Images.Add("Equipment_OnlineRemote", Properties.Resources.Equipment_OnlineRemote);

                // --

                grdList.DisplayLayout.Bands[0].Columns["Equipment"].CellAppearance.Image = Properties.Resources.Equipment;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Equipment"].Header.Fixed = true;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Equipment"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["Description"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["Control Mode"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["MDLN"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["SOFTREV"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["EAP"].Width = 150;
                grdList.DisplayLayout.Bands[0].Columns["Server"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Up/Down"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Status"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Package"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["Model"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["Component"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["Ip Address"].Width = 180;

                // --
 
                grdList.multiSelected = m_isMultiSelect;
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

        private void designGridOfEquipmentClass(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdClass.dataSource;
                // --
                uds.Band.Columns.Add("Name");
                uds.Band.Columns.Add("Description");

                // --

                grdClass.DisplayLayout.Bands[0].Columns["Name"].Width = 100;
                grdClass.DisplayLayout.Bands[0].Columns["Description"].Width = 180;
                // --
                grdClass.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.MultiBand;
                grdClass.DisplayLayout.ViewStyleBand = ViewStyleBand.Vertical;

                // --

                grdClass.ImageList = new ImageList();
                // --
                grdClass.ImageList.Images.Add("EquipmentType", Properties.Resources.EquipmentType);
                grdClass.ImageList.Images.Add("EquipmentArea", Properties.Resources.EquipmentArea);
                grdClass.ImageList.Images.Add("EquipmentLine", Properties.Resources.EquipmentLine);
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

        private void refreshClassGridOfEquipmentType(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            UltraGridRow row = null;
            UltraGridCell cell = null;
            string key = string.Empty;
            object[] cellValues = null;
            int nextRowNumber = 0;
            int index = 0;

            try
            {
                grdClass.beginUpdate(false);
                grdClass.removeAllDataRow();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "EquipmentSelector", "ListEquipmentType", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // Type
                            r[1].ToString()    // description
                            };
                        key = (string)cellValues[0];
                        index = grdClass.appendDataRow(key, cellValues).Index;

                        // --

                        row = grdClass.Rows.GetRowWithListIndex(index);
                        row.Tag = key;

                        // --

                        cell = row.Cells["Name"];
                        cell.Appearance.Image = grdClass.ImageList.Images["EquipmentType"];
                    }
                } while (nextRowNumber >= 0);

                // --

                grdClass.endUpdate(false);
                grdClass.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;

                // --

                if (grdClass.Rows.Count > 0)
                {
                    grdClass.ActiveRow = grdClass.Rows[0];
                }

                // --

                grdClass.Focus();
            }
            catch (Exception ex)
            {
                grdClass.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
                row = null;
                cell = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshClassGridOfEquipmentArea(
            )
        {

            FSqlParams fSqlParams = null;
            DataTable dt = null;
            UltraGridRow row = null;
            UltraGridCell cell = null;
            string key = string.Empty;
            object[] cellValues = null;
            int nextRowNumber = 0;
            int index = 0;

            try
            {
                grdClass.beginUpdate(false);
                grdClass.removeAllDataRow();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "EquipmentSelector", "ListEquipmentArea", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // Equipment Area
                            r[1].ToString()    // Description
                            };
                        key = (string)cellValues[0];
                        index = grdClass.appendDataRow(key, cellValues).Index;

                        // --

                        row = grdClass.Rows.GetRowWithListIndex(index);
                        row.Tag = key;

                        // --

                        cell = row.Cells["Name"];
                        cell.Appearance.Image = grdClass.ImageList.Images["EquipmentArea"];
                    }
                } while (nextRowNumber >= 0);

                // --

                grdClass.endUpdate(false);
                grdClass.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;

                // --

                if (grdClass.Rows.Count > 0)
                {
                    grdClass.ActiveRow = grdClass.Rows[0];
                }

                // --

                grdClass.Focus();
            }
            catch (Exception ex)
            {
                grdClass.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
                row = null;
                cell = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshClassGridOfEquipmentLine(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            UltraGridRow row = null;
            UltraGridCell cell = null;
            string key = string.Empty;
            object[] cellValues = null;
            int nextRowNumber = 0;
            int index = 0;

            try
            {
                grdClass.beginUpdate(false);
                grdClass.removeAllDataRow();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "EquipmentSelector", "ListEquipmentLine", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // Equipment Line
                            r[1].ToString(),   // Description
                            };
                        key = (string)cellValues[0];
                        index = grdClass.appendDataRow(key, cellValues).Index;

                        // --

                        row = grdClass.Rows.GetRowWithListIndex(index);
                        row.Tag = key;

                        // --

                        cell = row.Cells["Name"];
                        cell.Appearance.Image = grdClass.ImageList.Images["EquipmentLine"];
                    }
                } while (nextRowNumber >= 0);

                // --

                grdClass.endUpdate(false);
                grdClass.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;

                // --

                if (grdClass.Rows.Count > 0)
                {
                    grdClass.ActiveRow = grdClass.Rows[0];
                }

                // --

                grdClass.Focus();
            }
            catch (Exception ex)
            {
                grdClass.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
                row = null;
                cell = null;
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
            string type = string.Empty;
            string area = string.Empty;
            string line = string.Empty;
            object[] cellValues = null;
            string key = string.Empty;
            int nextRowNumber = 0;
            int index = 0;
            string package = string.Empty;
            string model = string.Empty;
            string component = string.Empty;
            string controlMode = string.Empty;

            try
            {
                btnOk.Enabled = false;

                // --

                if (tabMain.ActiveTab.Key == "Type")
                {
                    type = grdClass.activeDataRowKey;
                }
                else if (tabMain.ActiveTab.Key == "Area")
                {
                    area = grdClass.activeDataRowKey;
                }
                else if (tabMain.ActiveTab.Key == "Line")
                {
                    line = grdClass.activeDataRowKey;
                }
                
                // --

                if (
                    type == string.Empty &&
                    area == string.Empty &&
                    line == string.Empty
                   )
                {
                    return;
                }

                // --

                grdList.beginUpdate(false);
                grdList.removeAllDataRow();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("type", type == string.Empty ? " " : type);
                fSqlParams.add("area", area == string.Empty ? " " : area);
                fSqlParams.add("line", line == string.Empty ? " " : line);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "EquipmentSelector", "ListEquipment", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        package = FCommon.generateStringForPackage(r[9].ToString(), r[10].ToString());
                        model = FCommon.generateStringForModel(r[11].ToString(), r[12].ToString());
                        component = FCommon.generateStringForComponent(r[13].ToString(), r[14].ToString(), r[15].ToString());
                        controlMode = r[2].ToString();

                        // --

                        cellValues = new object[] {
                            r[0].ToString(),   // Equipment
                            r[1].ToString(),   // Description
                            controlMode,       // Control Mode
                            r[3].ToString(),   // MDLN
                            r[4].ToString(),   // SOFTREV
                            r[5].ToString(),   // MC
                            r[6].ToString(),   // Server
                            r[7].ToString(),   // Up/Down
                            r[8].ToString(),   // Status
                            package,           // Package
                            model,             // Model
                            component,         // Component
                            r[16].ToString()   // Ip Address
                            };
                        key = (string)cellValues[0];
                        index = grdList.appendDataRow(key, cellValues).Index;

                        // --

                        row = grdList.Rows.GetRowWithListIndex(index);

                        // --

                        cell = row.Cells["Equipment"];
                        cell.Appearance.Image = FCommon.getImageOfEquipment(grdList, controlMode);

                        // --
                        cell = row.Cells["Control Mode"];

                        if (cell.Text == FEquipmentControlMode.Offline.ToString())
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                            // --
                            cell = row.Cells["Equipment"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                            // --
                            cell.Appearance.Image = grdList.ImageList.Images["Equipment_Offline"];
                        }

                        // --
                        cell = row.Cells["Up/Down"];
                        if (cell.Text == FUpDown.Down.ToString())
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                            // --
                            cell = row.Cells["EAP"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }

                        // -- 
                        cell = row.Cells["EAP"];
                        if (cell.Text == "N/A")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                            // --
                            cell = row.Cells["Equipment"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }

                        // --

                        FCommon.designGridCellForEapServer(row.Cells["Server"]);
                        FCommon.designGridCellForEapUpDown(row.Cells["Up/Down"]);
                        FCommon.designGridCellForEapStatus(row.Cells["Status"]);
                        FCommon.designGridCellForEapPackage(row.Cells["Package"]);
                        FCommon.designGridCellForEapModel(row.Cells["Model"]);
                        FCommon.designGridCellForEapComponent(row.Cells["Component"]);
                        
                    }
                } while (nextRowNumber >= 0);

                // --

                grdList.endUpdate(false);

                // --

                if (grdList.Rows.Count > 0)
                {
                    grdList.ActiveRow = grdList.Rows[0];
                }
            }
            catch (Exception ex)
            {
                grdList.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
                row = null;
                cell = null;
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

                designGridOfEquipment();
                designGridOfEquipmentClass();

                // --

                tabMain.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(tabMain_SelectedTabChanged);

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

                refreshClassGridOfEquipmentType();

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

        // ***
        // 2012.11.26 by mjkim
        // Escape 키를 사용하여 폼을 닫으려면,
        // 사용하지 않을 버튼을 만들어 CancelButton로 설정하는 것보다 폼의 Key Event를 사용하는 게 현명한 선택.
        // 그리고, Key Event를 사용하려면, 'KeyPreview' Property를 'True'로 설정해야 한다. 
        // ***
        private void FEquipmentSelector_KeyDown(
            object sender, 
            KeyEventArgs e
            )
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
                else if (e.KeyCode == Keys.F5)
                {
                    FCursor.waitCursor();
                    // --
                    if (grdList.Focused)
                    {
                        refreshGridOfEquipment();
                    }
                    else
                    {
                        if (tabMain.ActiveTab.Key == "Type")
                        {
                            refreshClassGridOfEquipmentType();
                        }
                        else if (tabMain.ActiveTab.Key == "Area")
                        {
                            refreshClassGridOfEquipmentArea();
                        }
                        else if (tabMain.ActiveTab.Key == "Line")
                        {
                            refreshClassGridOfEquipmentLine();
                        }
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

        #region tabMdin Control Event Handler

        private void tabMain_SelectedTabChanged(
            object sender, 
            Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --
                switch (tabMain.ActiveTab.Key)
                {
                    case "Type":
                        refreshClassGridOfEquipmentType();
                        break;
                    case "Area":
                        refreshClassGridOfEquipmentArea();
                        break;
                    case "Line":
                        refreshClassGridOfEquipmentLine();
                        break;
                    default:
                        break;
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

                m_selectedEquipmentList = new Hashtable();
                m_selectedEquipmentListByObject = new Dictionary<string, FStructureEquipment>();
                // --
                foreach (UltraDataRow row in grdList.selectedDataRows)
                {
                    m_selectedEquipmentList.Add(
                        row.GetCellValue("Equipment").ToString(),
                        row.GetCellValue("EAP").ToString()
                        );

                    // --
                    m_selectedEquipmentListByObject.Add(
                        row.GetCellValue("Equipment").ToString(), 
                        new FStructureEquipment(
                            row.GetCellValue("Equipment").ToString(),
                            row.GetCellValue("EAP").ToString(),
                            row.GetCellValue("Description").ToString(),
                            row.GetCellValue("Ip Address").ToString()
                            )
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

                m_selectedEquipmentList = new Hashtable();
                m_selectedEquipmentListByObject = new Dictionary<string, FStructureEquipment>();

                // --
                foreach (UltraDataRow row in grdList.selectedDataRows)
                {
                    m_selectedEquipmentList.Add(
                        row.GetCellValue("Equipment").ToString(),
                        row.GetCellValue("EAP").ToString()
                        );

                    // --
                    m_selectedEquipmentListByObject.Add(
                        row.GetCellValue("Equipment").ToString(),
                        new FStructureEquipment(
                            row.GetCellValue("Equipment").ToString(),
                            row.GetCellValue("EAP").ToString(),
                            row.GetCellValue("Description").ToString(),
                            row.GetCellValue("Ip Address").ToString()
                            )
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

        #region rstToolbar Control Event Handler

        private void rstToolbar_SearchRequested(
            object sender, 
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FSqlParams fSqlParams = null;
                DataTable dt = null;

                FCursor.waitCursor();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("target", tabMain.ActiveTab.Key);
                fSqlParams.add("eqpName", "%"+ e.searchWord + "%");

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "EquipmentSelector", "SearchEquipment", fSqlParams, false);
                // --
                if (dt.Rows.Count <= 0)
                {
                    FDebug.throwFException(m_fAdmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { e.searchWord }));
                }

                // --

                switch (tabMain.ActiveTab.Key)
                {
                    case "Type":
                            grdClass.searchGridRow(dt.Rows[0][0].ToString());
                            break;
                    case "Area":
                            grdClass.searchGridRow(dt.Rows[0][1].ToString());
                            break;
                    case "Line":
                            grdClass.searchGridRow(dt.Rows[0][2].ToString());
                            break;
                    default:
                        break;
                }

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

        #region grdClass Control Event Handler

        private void grdClass_AfterRowActivate(
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

        private void grdClass_DoubleClickRow(
            object sender, 
            DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (grdClass.ActiveRow != null)
                {
                    if (grdClass.ActiveRow.ChildBands != null && grdClass.ActiveRow.ChildBands.Count != 0)
                    {
                        grdClass.ActiveRow.Expanded = (grdClass.ActiveRow.Expanded == true) ? false : true;
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

    }   // Class end
}   // Namespace end
