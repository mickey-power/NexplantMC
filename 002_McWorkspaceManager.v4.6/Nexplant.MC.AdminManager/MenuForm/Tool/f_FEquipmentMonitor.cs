/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FEquipmentMonitor.cs
--  Creator         : iskim
--  Create Date     : 2013.07.16
--  Description     : FAMate Admin Manager Equipment Monitor Form Class 
--  History         : Created by iskim at 2013.07.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinTree;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public partial class FEquipmentMonitor : FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private string m_lastSelectedSchema = string.Empty;
        private bool m_isSearchMode = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEquipmentMonitor()
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEquipmentMonitor(
            FAdmCore fAdmCore
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
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

        private string activeEq
        {
            get
            {
                FXmlNode n = null;

                try
                {
                    if (tvwSchema.ActiveNode == null)
                    {
                        return string.Empty;
                    }

                    // --

                    n = (FXmlNode)tvwSchema.ActiveNode.Tag;
                    if (n.name != FADMADS_TolEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.E_Equipment)
                    {
                        return string.Empty;
                    }

                    // --

                    return n.get_elemVal(
                        FADMADS_TolEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.A_Name,
                        FADMADS_TolEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.D_Name
                        );
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    n = null;
                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private string[] selectedEqs
        {
            get
            {
                FXmlNode n = null;
                string[] eqs = new string[1];

                try
                {
                    if (tvwSchema.ActiveNode == null)
                    {
                        return null;
                    }

                    // --

                    n = (FXmlNode)tvwSchema.ActiveNode.Tag;
                    if (n.name != FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.E_Equipment)
                    {
                        return null;
                    }

                    // --

                    eqs[0] = n.get_elemVal(
                            FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.A_Name,
                            FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.D_Name
                            );

                    // --

                    return eqs;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    eqs = null;
                }
                return null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        protected override void changeControlCaption(
            )
        {
            try
            {
                base.changeControlCaption();
                base.fUIWizard.changeControlCaption(mnuMenu);
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

        protected override void changeControlFontName(
            )
        {
            try
            {
                base.changeControlFontName();
                base.fUIWizard.changeControlCaption(mnuMenu);
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

        private void designGridOfEquipment(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdEqp.dataSource;
                // --
                uds.Band.Columns.Add("Equipment");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("EAP");
                uds.Band.Columns.Add("Server");
                uds.Band.Columns.Add("Up/Down");
                uds.Band.Columns.Add("Status");
                uds.Band.Columns.Add("Equipment Type");
                uds.Band.Columns.Add("Equipment Area");
                uds.Band.Columns.Add("Equipment Line");
                uds.Band.Columns.Add("MDLN");
                uds.Band.Columns.Add("SOFTREV");
                uds.Band.Columns.Add("Control Mode");
                uds.Band.Columns.Add("Pri_State");
                uds.Band.Columns.Add("State");
                uds.Band.Columns.Add("Alarm");
                uds.Band.Columns.Add("Event Define");
                uds.Band.Columns.Add("Ip Address");

                // --

                grdEqp.DisplayLayout.Bands[0].Columns["Equipment"].Header.Fixed = true;
                // --
                grdEqp.DisplayLayout.Bands[0].Columns["Equipment"].Width = 120;
                grdEqp.DisplayLayout.Bands[0].Columns["Description"].Width = 180;
                grdEqp.DisplayLayout.Bands[0].Columns["EAP"].Width = 100;
                grdEqp.DisplayLayout.Bands[0].Columns["Server"].Width = 100;
                grdEqp.DisplayLayout.Bands[0].Columns["Up/Down"].Width = 80;
                grdEqp.DisplayLayout.Bands[0].Columns["Status"].Width = 80;
                grdEqp.DisplayLayout.Bands[0].Columns["Equipment Type"].Width = 100;
                grdEqp.DisplayLayout.Bands[0].Columns["Equipment Area"].Width = 100;
                grdEqp.DisplayLayout.Bands[0].Columns["Equipment Line"].Width = 100;
                grdEqp.DisplayLayout.Bands[0].Columns["MDLN"].Width = 80;
                grdEqp.DisplayLayout.Bands[0].Columns["SOFTREV"].Width = 80;
                grdEqp.DisplayLayout.Bands[0].Columns["Control Mode"].Width = 100;
                grdEqp.DisplayLayout.Bands[0].Columns["Pri_State"].Width = 80;
                grdEqp.DisplayLayout.Bands[0].Columns["State"].Width = 80;
                grdEqp.DisplayLayout.Bands[0].Columns["Alarm"].Width = 80;
                grdEqp.DisplayLayout.Bands[0].Columns["Event Define"].Width = 80;

                // --

                grdEqp.ImageList = new ImageList();
                // --
                grdEqp.ImageList.Images.Add("Equipment_Offline", Properties.Resources.Equipment_Offline);
                grdEqp.ImageList.Images.Add("Equipment_OnlineLocal", Properties.Resources.Equipment_OnlineLocal);
                grdEqp.ImageList.Images.Add("Equipment_OnlineRemote", Properties.Resources.Equipment_OnlineRemote);
                grdEqp.ImageList.Images.Add("Equipment_Unknown", Properties.Resources.Equipment_Unknown);
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

        private void designTreeOfEapSchema(
            )
        {
            try
            {
                tvwSchema.ImageList = new ImageList();
                // --
                tvwSchema.ImageList.Images.Add("SecsDriver", Properties.Resources.SecsDriver);
                tvwSchema.ImageList.Images.Add("SecsDevice_Closed", Properties.Resources.SecsDevice_Closed);
                tvwSchema.ImageList.Images.Add("SecsDevice_Opened", Properties.Resources.SecsDevice_Opened);
                tvwSchema.ImageList.Images.Add("SecsDevice_Connected", Properties.Resources.SecsDevice_Connected);
                tvwSchema.ImageList.Images.Add("SecsDevice_Selected", Properties.Resources.SecsDevice_Selected);
                tvwSchema.ImageList.Images.Add("SecsDevice_Unknown", Properties.Resources.SecsDevice_Unknown);
                tvwSchema.ImageList.Images.Add("SecsSession", Properties.Resources.SecsSession);
                tvwSchema.ImageList.Images.Add("PlcDriver", Properties.Resources.PlcDriver);
                tvwSchema.ImageList.Images.Add("PlcDevice_Closed", Properties.Resources.PlcDevice_Closed);
                tvwSchema.ImageList.Images.Add("PlcDevice_Opened", Properties.Resources.PlcDevice_Opened);
                tvwSchema.ImageList.Images.Add("PlcDevice_Connected", Properties.Resources.PlcDevice_Connected);
                tvwSchema.ImageList.Images.Add("PlcDevice_Selected", Properties.Resources.PlcDevice_Selected);
                tvwSchema.ImageList.Images.Add("PlcDevice_Unknown", Properties.Resources.PlcDevice_Unknown);
                tvwSchema.ImageList.Images.Add("PlcSession", Properties.Resources.PlcSession);
                tvwSchema.ImageList.Images.Add("OpcDriver", Properties.Resources.OpcDriver);
                tvwSchema.ImageList.Images.Add("OpcDevice_Closed", Properties.Resources.OpcDevice_Closed);
                tvwSchema.ImageList.Images.Add("OpcDevice_Opened", Properties.Resources.OpcDevice_Opened);
                tvwSchema.ImageList.Images.Add("OpcDevice_Connected", Properties.Resources.OpcDevice_Connected);
                tvwSchema.ImageList.Images.Add("OpcDevice_Selected", Properties.Resources.OpcDevice_Selected);
                tvwSchema.ImageList.Images.Add("OpcDevice_Unknown", Properties.Resources.OpcDevice_Unknown);
                tvwSchema.ImageList.Images.Add("OpcSession", Properties.Resources.OpcSession);
                tvwSchema.ImageList.Images.Add("TcpDriver", Properties.Resources.TcpDriver);
                tvwSchema.ImageList.Images.Add("TcpDevice_Closed", Properties.Resources.TcpDevice_Closed);
                tvwSchema.ImageList.Images.Add("TcpDevice_Opened", Properties.Resources.TcpDevice_Opened);
                tvwSchema.ImageList.Images.Add("TcpDevice_Connected", Properties.Resources.TcpDevice_Connected);
                tvwSchema.ImageList.Images.Add("TcpDevice_Selected", Properties.Resources.TcpDevice_Selected);
                tvwSchema.ImageList.Images.Add("TcpDevice_Unknown", Properties.Resources.TcpDevice_Unknown);
                tvwSchema.ImageList.Images.Add("TcpSession", Properties.Resources.TcpSession);
                tvwSchema.ImageList.Images.Add("FileDriver", Properties.Resources.SecsDriver);
                tvwSchema.ImageList.Images.Add("FileDevice_Closed", Properties.Resources.SecsDevice_Closed);
                tvwSchema.ImageList.Images.Add("FileDevice_Opened", Properties.Resources.SecsDevice_Opened);
                tvwSchema.ImageList.Images.Add("FileDevice_Connected", Properties.Resources.SecsDevice_Connected);
                tvwSchema.ImageList.Images.Add("FileDevice_Selected", Properties.Resources.SecsDevice_Selected);
                tvwSchema.ImageList.Images.Add("FileDevice_Unknown", Properties.Resources.SecsDevice_Unknown);
                tvwSchema.ImageList.Images.Add("HostDevice_Closed", Properties.Resources.HostDevice_Closed);
                tvwSchema.ImageList.Images.Add("HostDevice_Opened", Properties.Resources.HostDevice_Opened);
                tvwSchema.ImageList.Images.Add("HostDevice_Connected", Properties.Resources.HostDevice_Connected);
                tvwSchema.ImageList.Images.Add("HostDevice_Selected", Properties.Resources.HostDevice_Selected);
                tvwSchema.ImageList.Images.Add("HostDevice_Unknown", Properties.Resources.HostDevice_Unknown);
                tvwSchema.ImageList.Images.Add("HostSession", Properties.Resources.HostSession);
                tvwSchema.ImageList.Images.Add("Equipment_Offline", Properties.Resources.Equipment_Offline);
                tvwSchema.ImageList.Images.Add("Equipment_OnlineLocal", Properties.Resources.Equipment_OnlineLocal);
                tvwSchema.ImageList.Images.Add("Equipment_OnlineRemote", Properties.Resources.Equipment_OnlineRemote);
                tvwSchema.ImageList.Images.Add("Equipment_Unknown", Properties.Resources.Equipment_Unknown);
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

        private void refreshClassTotal(
            )
        {
            try
            {
                lblClassTotal.Text = grdClass.Rows.Count.ToString("#,##0");
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

        private void refreshEquipmentTotal(
            )
        {
            try
            {
                lblEqpTotal.Text = grdEqp.Rows.Count.ToString("#,##0");
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

        private void refreshClassGridOfEquipmentType(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            UltraGridRow row = null;
            UltraGridCell cell = null;
            string beforeKey = string.Empty;
            string key = string.Empty;
            object[] cellValues = null;
            int nextRowNumber = 0;
            int index = 0;

            try
            {
                beforeKey = grdClass.activeDataRowKey;
                // --
                grdClass.beginUpdate(false);
                grdClass.removeAllDataRow();
                grdClass.DisplayLayout.Bands[0].SortedColumns.Clear();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Tool", "EquipmentMonitor", "ListEquipmentType", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // Equipment Type
                            r[1].ToString()    // description
                            };
                        key = (string)cellValues[0];
                        index = grdClass.appendDataRow(key, cellValues).Index;

                        // --

                        row = grdClass.Rows.GetRowWithListIndex(index);

                        // --

                        cell = row.Cells["Name"];
                        cell.Appearance.Image = grdClass.ImageList.Images["EquipmentType"];
                    }
                } while (nextRowNumber >= 0);

                // --

                grdClass.endUpdate(false);
                grdClass.DisplayLayout.Bands[0].SortedColumns.Add("Name", false);

                // --

                if (grdClass.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdClass.activateDataRow(beforeKey);
                    }
                    if (grdClass.activeDataRow == null)
                    {
                        grdClass.ActiveRow = grdClass.Rows[0];
                    }
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
                refreshClassTotal();

                // --

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
            string beforeKey = string.Empty;
            string key = string.Empty;
            object[] cellValues = null;
            int nextRowNumber = 0;
            int index = 0;

            try
            {
                beforeKey = grdClass.activeDataRowKey;
                // --
                grdClass.beginUpdate(false);
                grdClass.removeAllDataRow();
                grdClass.DisplayLayout.Bands[0].SortedColumns.Clear();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Tool", "EquipmentMonitor", "ListEquipmentArea", fSqlParams, false, ref nextRowNumber);
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

                        // --

                        cell = row.Cells["Name"];
                        cell.Appearance.Image = grdClass.ImageList.Images["EquipmentArea"];
                    }
                } while (nextRowNumber >= 0);

                // --

                grdClass.endUpdate(false);
                grdClass.DisplayLayout.Bands[0].SortedColumns.Add("Name", false);

                // --

                if (grdClass.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdClass.activateDataRow(beforeKey);
                    }
                    if (grdClass.activeDataRow == null)
                    {
                        grdClass.ActiveRow = grdClass.Rows[0];
                    }
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
                refreshClassTotal();

                // --

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
            string beforeKey = string.Empty;
            string key = string.Empty;
            object[] cellValues = null;
            int nextRowNumber = 0;
            int index = 0;

            try
            {
                beforeKey = grdClass.activeDataRowKey;
                // --
                grdClass.beginUpdate(false);
                grdClass.removeAllDataRow();
                grdClass.DisplayLayout.Bands[0].SortedColumns.Clear();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Tool", "EquipmentMonitor", "ListEquipmentLine", fSqlParams, false, ref nextRowNumber);
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

                        // --

                        cell = row.Cells["Name"];
                        cell.Appearance.Image = grdClass.ImageList.Images["EquipmentLine"];
                    }
                } while (nextRowNumber >= 0);

                // --

                grdClass.endUpdate(false);
                grdClass.DisplayLayout.Bands[0].SortedColumns.Add("Name", false);

                // --

                if (grdClass.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdClass.activateDataRow(beforeKey);
                    }
                    if (grdClass.activeDataRow == null)
                    {
                        grdClass.ActiveRow = grdClass.Rows[0];
                    }
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
                refreshClassTotal();

                // --

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
            string beforeKey = string.Empty;
            string key = string.Empty;
            int nextRowNumber = 0;
            int index = 0;
            string ctrlMode = string.Empty;

            try
            {
                tvwSchema.beginUpdate();
                tvwSchema.Nodes.Clear();
                tvwSchema.endUpdate();
                // --
                pgdSchema.selectedObject = null;

                // --

                beforeKey = grdEqp.activeDataRowKey;
                // --
                grdEqp.beginUpdate(false);
                grdEqp.removeAllDataRow();
                grdEqp.DisplayLayout.Bands[0].SortedColumns.Clear();

                // --

                if (grdClass.Enabled == true)
                {
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
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("type", type, type == string.Empty ? true : false);
                fSqlParams.add("area", area, area == string.Empty ? true : false);
                fSqlParams.add("line", line, line == string.Empty ? true : false);
                fSqlParams.add("attr_category", FEapAttrCategory.Applied.ToString());
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Tool", "EquipmentMonitor", "ListEquipment", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        ctrlMode = r[11].ToString();
                        // --

                        cellValues = new object[] {
                            r[0].ToString(),  // Equipment
                            r[1].ToString(),  // Description
                            r[2].ToString(),  // EAP
                            r[3].ToString(),  // Server
                            r[4].ToString(),  // UpDown
                            r[5].ToString(),  // Status
                            r[6].ToString(),  // Type
                            r[7].ToString(),  // Area                     
                            r[8].ToString(),  // Line
                            r[9].ToString(),  // Mdln
                            r[10].ToString(), // Softrev
                            ctrlMode,         // Control Mode
                            r[12].ToString(), // Pri State
                            r[13].ToString(), // State
                            r[14].ToString(), // Alarm
                            r[15].ToString(), // Event Define
                            r[16].ToString()  // IP Address
                            };
                        index = grdEqp.appendDataRow(r[0].ToString(), cellValues).Index;
                        row = grdEqp.Rows[index];
                        
                        // --

                        cell = row.Cells["Equipment"];
                        cell.Appearance.Image = FCommon.getImageOfEquipment(grdEqp, ctrlMode);

                        // --

                        if (ctrlMode == FEquipmentControlMode.Offline.ToString())
                        {
                            row.Appearance.BackColor = Color.FromArgb(233, 233, 233);
                        }
                        else if (ctrlMode == FEquipmentControlMode.OnlineLocal.ToString())
                        {
                            row.Appearance.BackColor = Color.FromArgb(250, 237, 125);
                        }
                        else
                        {
                            row.Appearance.BackColor = Color.WhiteSmoke;
                        }

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
                        }
                        
                        // --

                        cell = row.Cells["Up/Down"];
                        if (cell.Text == FUpDown.Down.ToString())
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                            // --
                            cell = row.Cells["Equipment"];
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
                        cell = row.Cells["Server"];
                        if (cell.Text == "N/A")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                            // --
                            cell = row.Cells["Equipment"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }

                        FCommon.designGridCellForEapUpDown(row.Cells["Up/Down"]);
                        FCommon.designGridCellForEapStatus(row.Cells["Status"]);

                    }
                } while (nextRowNumber >= 0);

                // --

                grdEqp.endUpdate(false);
                grdEqp.DisplayLayout.Bands[0].SortedColumns.Add("Equipment", false);

                // --

                if (grdEqp.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdEqp.activateDataRow(beforeKey);
                    }
                    if (grdEqp.activeDataRow == null)
                    {
                        grdEqp.ActiveRow = grdEqp.Rows[0];
                    }
                }

                // --

                m_isSearchMode = false;
            }
            catch (Exception ex)
            {
                grdEqp.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                refreshEquipmentTotal();

                // --

                fSqlParams = null;
                dt = null;
                row = null;
                cell = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshTreeOfEapSchema(
            FXmlNode fXmlNode
            )
        {
            UltraTreeNode tNodeScd = null;
            UltraTreeNode tNodeSdv = null;
            UltraTreeNode tNodeSsn = null;
            UltraTreeNode tNodeHdv = null;
            UltraTreeNode tNodeHsn = null;
            UltraTreeNode tNodeEqp = null;
            int keyIndex = 0;
            string eapType = string.Empty;

            try
            {
                tvwSchema.beginUpdate();
                tvwSchema.Nodes.Clear();
                pgdSchema.selectedObject = null;
                // --
                if (
                    fXmlNode == null ||
                    FCommon.getEapSchemaObjectText(fXmlNode) == string.Empty
                    )
                {
                    tvwSchema.endUpdate();
                    return;
                }

                // --

                // ***
                // SECS Driver Load
                // ***
                tNodeScd = new UltraTreeNode(keyIndex.ToString(), FCommon.getEapSchemaObjectText(fXmlNode));
                tNodeScd.Override.NodeAppearance.Image = FCommon.getImageOfEapDriver(tvwSchema, fXmlNode);
                tNodeScd.Tag = fXmlNode;
                keyIndex++;
                eapType = fXmlNode.get_elemVal(FADMADS_TolEapSchemaSearch_Out.FSchema.FSecsDriver.A_EapType, FADMADS_TolEapSchemaSearch_Out.FSchema.FSecsDriver.D_EapType);
                                
                // --

                // ***
                // SECS Device Load
                // ***
                foreach (FXmlNode fXmlNodeSdv in fXmlNode.get_elemList(FADMADS_TolEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.E_SecsDevice))
                {
                    tNodeSdv = new UltraTreeNode(keyIndex.ToString(), FCommon.getEapSchemaObjectText(fXmlNodeSdv));
                    tNodeSdv.Override.NodeAppearance.Image = FCommon.getImageOfEapSchemaSecsDevice(tvwSchema, fXmlNodeSdv);
                    tNodeSdv.Tag = fXmlNodeSdv;
                    keyIndex++;

                    // --

                    // ***
                    // SECS Session Load
                    // ***
                    foreach (FXmlNode fXmlNodeSsn in fXmlNodeSdv.get_elemList(FADMADS_TolEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.E_SecsSession))
                    {
                        tNodeSsn = new UltraTreeNode(keyIndex.ToString(), FCommon.getEapSchemaObjectText(fXmlNodeSsn));
                        tNodeSsn.Override.NodeAppearance.Image = FCommon.getImageOfEapSession(tvwSchema, fXmlNodeSsn); 
                        tNodeSsn.Tag = fXmlNodeSsn;
                        keyIndex++;
                        // --
                        tNodeSdv.Nodes.Add(tNodeSsn);
                    }

                    // --

                    tNodeScd.Nodes.Add(tNodeSdv);
                }

                // --

                // ***
                // Host Device Load
                // ***
                foreach (FXmlNode fXmlNodeHdv in fXmlNode.get_elemList(FADMADS_TolEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.E_HostDevice))
                {
                    tNodeHdv = new UltraTreeNode(keyIndex.ToString(), FCommon.getEapSchemaObjectText(fXmlNodeHdv));
                    tNodeHdv.Override.NodeAppearance.Image = FCommon.getImageOfEapSchemaHostDevice(tvwSchema, fXmlNodeHdv);
                    tNodeHdv.Tag = fXmlNodeHdv;
                    keyIndex++;

                    // --

                    // ***
                    // Host Session Load
                    // *** 
                    foreach (FXmlNode fXmlNodeHsn in fXmlNodeHdv.get_elemList(FADMADS_TolEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.E_HostSession))
                    {
                        tNodeHsn = new UltraTreeNode(keyIndex.ToString(), FCommon.getEapSchemaObjectText(fXmlNodeHsn));
                        tNodeHsn.Override.NodeAppearance.Image = Properties.Resources.HostSession;
                        tNodeHsn.Tag = fXmlNodeHsn;
                        keyIndex++;
                        // --
                        tNodeHdv.Nodes.Add(tNodeHsn);
                    }

                    // --

                    tNodeScd.Nodes.Add(tNodeHdv);
                }

                // --

                // ***
                // Equipment Load
                // ***
                
                foreach (FXmlNode fXmlNodeEqp in fXmlNode.get_elemList(FADMADS_TolEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.E_Equipment))
                {
                    tNodeEqp = new UltraTreeNode(keyIndex.ToString(), FCommon.getEapSchemaObjectText(fXmlNodeEqp));
                    tNodeEqp.Override.NodeAppearance.Image = FCommon.getImageOfEapSchemaEquipment(tvwSchema, fXmlNodeEqp);
                    tNodeEqp.Tag = fXmlNodeEqp;
                    keyIndex++;
                    // --
                    tNodeScd.Nodes.Add(tNodeEqp);
                }
                

                // --

                tNodeScd.Expanded = true;
                tvwSchema.Nodes.Add(tNodeScd);
                tvwSchema.endUpdate();

                // --

                if (tvwSchema.Nodes.Count > 0)
                {
                    if (m_lastSelectedSchema != string.Empty)
                    {
                        tvwSchema.ActiveNode = tvwSchema.GetNodeByKey(m_lastSelectedSchema);
                    }
                    if (m_lastSelectedSchema == string.Empty || tvwSchema.ActiveNode == null)
                    {
                        tvwSchema.ActiveNode = tvwSchema.Nodes[0];
                    }
                }
            }
            catch (Exception ex)
            {
                tvwSchema.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeScd = null;
                tNodeSdv = null;
                tNodeSsn = null;
                tNodeHdv = null;
                tNodeHsn = null;
                tNodeEqp = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private FXmlNode refreshEapSchema(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInEap = null;
            FXmlNode fXmlNodeOut = null;
            string eapName = string.Empty;

            try
            {
                if (grdEqp.activeDataRow == null)
                {
                    return null;
                }
                
                // --

                eapName = (string)grdEqp.activeDataRow["EAP"];
                if (eapName == string.Empty || eapName == "N/A")
                {
                    return null;
                }

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TolEapSchemaSearch_In.E_ADMADS_TolEapSchemaSearch_In);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapSchemaSearch_In.A_hLanguage, FADMADS_TolEapSchemaSearch_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TolEapSchemaSearch_In.A_hFactory, FADMADS_TolEapSchemaSearch_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapSchemaSearch_In.A_hUserId, FADMADS_TolEapSchemaSearch_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapSchemaSearch_In.A_hStep, FADMADS_TolEapSchemaSearch_In.D_hStep, "1");
                // --
                fXmlNodeInEap = fXmlNodeIn.set_elem(FADMADS_TolEapSchemaSearch_In.FEap.E_Eap);
                fXmlNodeInEap.set_elemVal(FADMADS_TolEapSchemaSearch_In.FEap.A_Name, FADMADS_TolEapSchemaSearch_In.FEap.D_Name, eapName);

                // --

                FADMADSCaster.ADMADS_TolEapSchemaSearch_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_TolEapSchemaSearch_Out.A_hStatus, FADMADS_TolEapSchemaSearch_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_TolEapSchemaSearch_Out.A_hStatusMessage, FADMADS_TolEapSchemaSearch_Out.D_hStatusMessage)
                        );
                }

                // --

                return fXmlNodeOut.get_elem(FADMADS_TolEapSchemaSearch_Out.FSchema.E_Schema).get_elem(FADMADS_TolEapSchemaSearch_Out.FSchema.FSecsDriver.E_SecsDriver);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInEap = null;
                fXmlNodeOut = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMonitoringEapEquipmentData(
            FMonitoringEapDataReceivedEventArgs args
            )
        {
            UltraGridRow row = null;
            UltraGridCell cell = null;
            object[] cellValues = null;
            FXmlNode fXmlNodeScd = null;
            FXmlNodeList fXmlNodeListEqp = null;
            // --
            string equipment = string.Empty;
            string description = string.Empty;
            string server = string.Empty;
            string eap = string.Empty;
            string upDown = string.Empty;
            string status = string.Empty;
            string type = string.Empty;
            string area = string.Empty;
            string line = string.Empty;
            string mdln = string.Empty;
            string softrev = string.Empty;
            string ctrlMode = string.Empty;
            string priState = string.Empty;
            string state = string.Empty;
            string alarm = string.Empty;
            string eventDefine = string.Empty;
            int index = 0;
            bool changedCategory = false;
            string activeEqp = string.Empty;

            try
            {
                if (args.fType == FMonitoringDataType.Update)
                {
                    #region Update

                    fXmlNodeScd = args.fXmlNode.get_elem(FADMADS_TolEapDataPush_In.FEap.FSecsDriver.E_SecsDriver);
                    if (fXmlNodeScd == null)
                    {
                        return;
                    }

                    // --

                    fXmlNodeListEqp = fXmlNodeScd.get_elemList(FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.E_Equipment);
                    if (fXmlNodeListEqp.count == 0)
                    {
                        return;
                    }

                    // --

                    eap = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_Name, FADMADS_TolEapDataPush_In.FEap.D_Name);
                    server = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_Server, FADMADS_TolEapDataPush_In.FEap.D_Server);
                    upDown = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_UpDown, FADMADS_TolEapDataPush_In.FEap.D_UpDown);
                    status = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_Status, FADMADS_TolEapDataPush_In.FEap.D_Status);

                    // --

                    grdEqp.beginUpdate(false);

                    // --

                    foreach (FXmlNode fxmlNodeEqp in fXmlNodeListEqp)
                    {
                        changedCategory = false;

                        // --

                        equipment = fxmlNodeEqp.get_elemVal(FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.A_Name, FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.D_Name);
                        type = fxmlNodeEqp.get_elemVal(FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.A_Type, FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.D_Type);
                        area = fxmlNodeEqp.get_elemVal(FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.A_Area, FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.D_Area);
                        line = fxmlNodeEqp.get_elemVal(FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.A_Line, FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.D_Line);

                        // --

                        if (m_isSearchMode)
                        {
                            if (!grdEqp.containsDataRow(equipment))
                            {
                                continue;
                            }
                        }
                        else if (!chkAll.Checked)
                        {
                            if (tabMain.ActiveTab.Key == "Type")
                            {
                                if (!grdClass.activeDataRowKey.Equals(type))
                                {
                                    if (!grdEqp.containsDataRow(equipment))
                                    {
                                        continue;
                                    }
                                    changedCategory = true;
                                }
                            }
                            else if (tabMain.ActiveTab.Key == "Area")
                            {
                                if (!grdClass.activeDataRowKey.Equals(area))
                                {
                                    if (!grdEqp.containsDataRow(equipment))
                                    {
                                        continue;
                                    }
                                    changedCategory = true;
                                }
                            }
                            else if (tabMain.ActiveTab.Key == "Line")
                            {
                                if (!grdClass.activeDataRowKey.Equals(line))
                                {
                                    if (!grdEqp.containsDataRow(equipment))
                                    {
                                        continue;
                                    }
                                    changedCategory = true;
                                }
                            }
                        }

                        // --

                        if (changedCategory)
                        {
                            #region Delete Equipment Information

                            // ***
                            // Category가 변경되었을 경우 Equipment 목록에서 제거
                            // ***
                            if (equipment == grdEqp.activeDataRowKey)
                            {
                                // ***
                                // Refresh Eap Schema
                                // ***
                                procMonitoringEapSchema(null);
                            }

                            // --

                            grdEqp.removeDataRow(equipment);

                            #endregion
                        }
                        else
                        {
                            #region Insert or Update Equipment information

                            description = fxmlNodeEqp.get_elemVal(FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.A_Description, FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.D_Description);
                            mdln = fxmlNodeEqp.get_elemVal(FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.A_Mdln, FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.D_Mdln);
                            softrev = fxmlNodeEqp.get_elemVal(FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.A_SoftRev, FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.D_SoftRev);
                            ctrlMode = fxmlNodeEqp.get_elemVal(FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.A_ControlMode, FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.D_ControlMode);
                            priState = fxmlNodeEqp.get_elemVal(FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.A_PrimaryState, FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.D_PrimaryState);
                            state = fxmlNodeEqp.get_elemVal(FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.A_State, FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.D_State);
                            alarm = fxmlNodeEqp.get_elemVal(FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.A_Alarm, FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.D_Alarm);
                            eventDefine = fxmlNodeEqp.get_elemVal(FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.A_EventDefine, FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.D_EventDefine);

                            // --

                            cellValues = new object[] {
                                equipment,
                                description,
                                eap,
                                server,
                                upDown,
                                status,
                                type,
                                area,
                                line,
                                mdln,
                                softrev,
                                ctrlMode,
                                priState,
                                state,
                                alarm,
                                eventDefine
                                };
                            // --
                            index = grdEqp.appendOrUpdateDataRow(equipment, cellValues).Index;
                            row = grdEqp.Rows[index];

                            // --

                            if (ctrlMode == FEquipmentControlMode.Offline.ToString())
                            {
                                row.Appearance.BackColor = Color.FromArgb(233, 233, 233);
                                activeEqp = equipment;
                            }
                            else if (ctrlMode == FEquipmentControlMode.OnlineLocal.ToString())
                            {
                                row.Appearance.BackColor = Color.FromArgb(250, 237, 125);
                            }
                            else
                            {
                                row.Appearance.BackColor = Color.WhiteSmoke;
                            }

                            // --

                            // ***
                            // Set Equipment Image
                            // ***
                            cell = row.Cells["Equipment"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                            cell.Appearance.ForeColor = Color.Black;
                            cell.Appearance.Image = FCommon.getImageOfEquipment(grdEqp, ctrlMode);

                            // --

                            // ***
                            // Control Mode Check
                            // ***
                            cell = row.Cells["Control Mode"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                            cell.Appearance.ForeColor = Color.Black;
                            // --
                            if (cell.Text == FEquipmentControlMode.Offline.ToString())
                            {
                                cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                                cell.Appearance.ForeColor = Color.Red;
                                // --
                                cell = row.Cells["Equipment"];
                                cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                                cell.Appearance.ForeColor = Color.Red;
                            }

                            // --

                            // ***
                            // Eap Check
                            // ***
                            cell = row.Cells["EAP"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                            cell.Appearance.ForeColor = Color.Black;
                            // --
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

                            // ***
                            // Eap Up/Down Check
                            // ***
                            cell = row.Cells["Up/Down"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                            cell.Appearance.ForeColor = Color.Black;
                            // --
                            if (cell.Text == FUpDown.Down.ToString())
                            {
                                cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                                cell.Appearance.ForeColor = Color.Red;
                                // --
                                cell = row.Cells["Equipment"];
                                cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                                cell.Appearance.ForeColor = Color.Red;
                            }

                            // --

                            // ***
                            // Eap Status Check
                            // ***
                            cell = row.Cells["Status"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                            cell.Appearance.ForeColor = Color.Black;
                            // --
                            if (cell.Text == FEapStatusEnum.Backup.ToString())
                            {
                                cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                                cell.Appearance.ForeColor = Color.Red;
                                // --
                                cell = row.Cells["Equipment"];
                                cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                                cell.Appearance.ForeColor = Color.Red;
                            }

                            // --

                            // ***
                            // Server Check
                            // ***
                            cell = row.Cells["Server"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                            cell.Appearance.ForeColor = Color.Black;
                            // --
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

                            if (equipment == grdEqp.activeDataRowKey)
                            {
                                // ***
                                // Refresh Eap Schema
                                // ***
                                procMonitoringEapSchema(fXmlNodeScd);
                            }

                            #endregion
                        }
                    }

                    // --

                    grdEqp.endUpdate(false);

                    #endregion
                }
                else
                {
                    #region Delete

                    // ***
                    // EAP가 삭제되었을 경우, Equipment 목록에서 해당 EAP를 검색해서 
                    // *** 
                    eap = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_Name, FADMADS_TolEapDataPush_In.FEap.D_Name);

                    // --

                    grdEqp.beginUpdate(false);

                    foreach (UltraGridRow r in grdEqp.Rows)
                    {
                        if (eap != r.Cells["EAP"].Text)
                        {
                            continue;
                        }

                        // --

                        equipment = r.Cells["Equipment"].Text;

                        // --

                        cell = r.Cells["EAP"];
                        cell.Value = "N/A";
                        cell.Appearance.ForeColor = Color.Red;
                        cell.Appearance.FontData.Bold = DefaultableBoolean.True;

                        // --

                        cell = r.Cells["Server"];
                        cell.Value = "N/A";
                        cell.Appearance.ForeColor = Color.Red;
                        cell.Appearance.FontData.Bold = DefaultableBoolean.True;

                        // --

                        cell = r.Cells["Up/Down"];
                        cell.Value = "N/A";
                        cell.Appearance.ForeColor = Color.Black;
                        cell.Appearance.FontData.Bold = DefaultableBoolean.False;

                        // --

                        cell = r.Cells["Status"];
                        cell.Value = "N/A";
                        cell.Appearance.ForeColor = Color.Black;
                        cell.Appearance.FontData.Bold = DefaultableBoolean.False;

                        // --

                        if (equipment == grdEqp.activeDataRowKey)
                        {
                            // ***
                            // Refresh Eap Schema
                            // ***
                            procMonitoringEapSchema(null);
                        }
                    }

                    grdEqp.endUpdate(false);

                    #endregion
                }

                // --

                if (chkAutoActive.Checked && grdEqp.containsDataRow(activeEqp))
                {
                    grdEqp.activateDataRow(equipment);
                }
            }
            catch (Exception ex)
            {
                grdEqp.endUpdate(false);
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                row = null;
                cell = null;
                cellValues = null;
                fXmlNodeScd = null;
                fXmlNodeListEqp = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMonitoringEquipmentData(
            FMonitoringEquipmentDataReceivedEventArgs args
            )
        {
            UltraGridRow row = null;
            UltraGridCell cell = null;
            object[] cellValues = null;
            string equipment = string.Empty;
            string description = string.Empty;
            string server = string.Empty;
            string eap = string.Empty;
            string upDown = string.Empty;
            string status = string.Empty;
            string type = string.Empty;
            string area = string.Empty;
            string line = string.Empty;
            string mdln = string.Empty;
            string softrev = string.Empty;
            string ctrlMode = string.Empty;
            string priState = string.Empty;
            string state = string.Empty;
            string alarm = string.Empty;
            string eventDefine = string.Empty;
            int index = 0;
            bool changedCategory = false;
            
            try
            {
                equipment = args.fXmlNode.get_elemVal(FADMADS_TolEquipmentDataPush_In.FEquipment.A_Name, FADMADS_TolEquipmentDataPush_In.FEquipment.D_Name);
                description = args.fXmlNode.get_elemVal(FADMADS_TolEquipmentDataPush_In.FEquipment.A_Description, FADMADS_TolEquipmentDataPush_In.FEquipment.D_Description);
                server = args.fXmlNode.get_elemVal(FADMADS_TolEquipmentDataPush_In.FEquipment.A_Server, FADMADS_TolEquipmentDataPush_In.FEquipment.D_Server);
                eap = args.fXmlNode.get_elemVal(FADMADS_TolEquipmentDataPush_In.FEquipment.A_Eap, FADMADS_TolEquipmentDataPush_In.FEquipment.D_Eap);
                upDown = args.fXmlNode.get_elemVal(FADMADS_TolEquipmentDataPush_In.FEquipment.A_UpDown, FADMADS_TolEquipmentDataPush_In.FEquipment.D_UpDown);
                status = args.fXmlNode.get_elemVal(FADMADS_TolEquipmentDataPush_In.FEquipment.A_Status, FADMADS_TolEquipmentDataPush_In.FEquipment.D_Status);
                type = args.fXmlNode.get_elemVal(FADMADS_TolEquipmentDataPush_In.FEquipment.A_Type, FADMADS_TolEquipmentDataPush_In.FEquipment.D_Type);
                area = args.fXmlNode.get_elemVal(FADMADS_TolEquipmentDataPush_In.FEquipment.A_Area, FADMADS_TolEquipmentDataPush_In.FEquipment.D_Area);
                line = args.fXmlNode.get_elemVal(FADMADS_TolEquipmentDataPush_In.FEquipment.A_Line, FADMADS_TolEquipmentDataPush_In.FEquipment.D_Line);
                mdln = args.fXmlNode.get_elemVal(FADMADS_TolEquipmentDataPush_In.FEquipment.A_Mdln, FADMADS_TolEquipmentDataPush_In.FEquipment.D_Mdln);
                softrev = args.fXmlNode.get_elemVal(FADMADS_TolEquipmentDataPush_In.FEquipment.A_SoftRev, FADMADS_TolEquipmentDataPush_In.FEquipment.D_SoftRev);
                ctrlMode = args.fXmlNode.get_elemVal(FADMADS_TolEquipmentDataPush_In.FEquipment.A_CtrlMode, FADMADS_TolEquipmentDataPush_In.FEquipment.D_CtrlMode);                
                priState = args.fXmlNode.get_elemVal(FADMADS_TolEquipmentDataPush_In.FEquipment.A_PriState, FADMADS_TolEquipmentDataPush_In.FEquipment.D_PriState);
                state = args.fXmlNode.get_elemVal(FADMADS_TolEquipmentDataPush_In.FEquipment.A_State, FADMADS_TolEquipmentDataPush_In.FEquipment.D_State);
                alarm = args.fXmlNode.get_elemVal(FADMADS_TolEquipmentDataPush_In.FEquipment.A_Alarm, FADMADS_TolEquipmentDataPush_In.FEquipment.D_Alarm);
                eventDefine = args.fXmlNode.get_elemVal(FADMADS_TolEquipmentDataPush_In.FEquipment.A_EventDefine, FADMADS_TolEquipmentDataPush_In.FEquipment.D_EventDefine);

                // --

                if (m_isSearchMode)
                {
                    if (!grdEqp.containsDataRow(equipment))
                    {
                        return;
                    }
                }
                else if (!chkAll.Checked)
                {
                    if (tabMain.ActiveTab.Key == "Type")
                    {
                        if (!grdClass.activeDataRowKey.Equals(type))
                        {
                            if (!grdEqp.containsDataRow(equipment))
                            {
                                return;
                            }
                            changedCategory = true;
                        }
                    }
                    else if (tabMain.ActiveTab.Key == "Area")
                    {
                        if (!grdClass.activeDataRowKey.Equals(area))
                        {
                            if (!grdEqp.containsDataRow(equipment))
                            {
                                return;
                            }
                            changedCategory = true;
                        }
                    }
                    else if (tabMain.ActiveTab.Key == "Line")
                    {
                        if (!grdClass.activeDataRowKey.Equals(line))
                        {
                            if (!grdEqp.containsDataRow(equipment))
                            {
                                return;
                            }
                            changedCategory = true;
                        }
                    }
                }               

                // --

                grdEqp.beginUpdate(false);

                // --

                if (args.fType == FMonitoringDataType.Update && changedCategory == false)
                {
                    // ***
                    // Insert or Update Equipment information
                    // ***
                    cellValues = new object[] {
                        equipment,
                        description,
                        eap,
                        server,
                        upDown,
                        status,
                        type,
                        area,
                        line,
                        mdln,
                        softrev,
                        ctrlMode,
                        priState,
                        state,
                        alarm,
                        eventDefine
                        };

                    // --

                    index = grdEqp.appendOrUpdateDataRow(equipment, cellValues).Index;
                    row = grdEqp.Rows.GetRowWithListIndex(index);                    
                    
                    // --

                    cell = row.Cells["Equipment"];
                    cell.Appearance.Image = FCommon.getImageOfEquipment(grdEqp, ctrlMode);

                    // --

                    if (ctrlMode == FEquipmentControlMode.Offline.ToString())
                    {
                        row.Appearance.BackColor = Color.FromArgb(233, 233, 233);
                    }
                    else if (ctrlMode == FEquipmentControlMode.OnlineLocal.ToString())
                    {
                        row.Appearance.BackColor = Color.FromArgb(250, 237, 125);
                    }
                    else
                    {
                        row.Appearance.BackColor = Color.WhiteSmoke;
                    }

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
                    }

                    // --

                    cell = row.Cells["Up/Down"];
                    if (cell.Text == FUpDown.Down.ToString())
                    {
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        cell.Appearance.ForeColor = Color.Red;
                        // --
                        cell = row.Cells["Equipment"];
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

                    cell = row.Cells["Server"];
                    if (cell.Text == "N/A")
                    {
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        cell.Appearance.ForeColor = Color.Red;
                        // --
                        cell = row.Cells["Equipment"];
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        cell.Appearance.ForeColor = Color.Red;
                    }

                    FCommon.designGridCellForEapUpDown(row.Cells["Up/Down"]);
                    FCommon.designGridCellForEapStatus(row.Cells["Status"]);
                }
                else
                {
                    // ***
                    // Delete EAP information
                    // ***
                    grdEqp.removeDataRow(equipment);
                }

                // --

                grdEqp.endUpdate(false);

                // --

                if (chkAutoActive.Checked && grdEqp.containsDataRow(equipment) && ctrlMode == FEquipmentControlMode.Offline.ToString())
                {
                    grdEqp.activateDataRow(equipment);
                }
            }
            catch (Exception ex)
            {
                grdEqp.endUpdate(false);
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                refreshEquipmentTotal();

                // --

                row = null;
                cell = null;
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMonitoringEapSchema(
            FXmlNode fXmlNodeScd
            )
        {
            UltraTreeNode tNodeScd = null;
            UltraTreeNode tNodeSdv = null;
            UltraTreeNode tNodeSsn = null;
            UltraTreeNode tNodeHdv = null;
            UltraTreeNode tNodeHsn = null;
            UltraTreeNode tNodeEqp = null;
            int keyIndex = 0;

            try
            {
                tvwSchema.beginUpdate();
                tvwSchema.Nodes.Clear();
                pgdSchema.selectedObject = null;
                // --                                          
                if (fXmlNodeScd == null)
                {
                    tvwSchema.endUpdate();
                    return;
                }

                // ***
                // SECS Driver Load
                // ***
                tNodeScd = new UltraTreeNode(keyIndex.ToString(), FCommon.getEapSchemaObjectText(fXmlNodeScd));
                tNodeScd.Override.NodeAppearance.Image = tvwSchema.ImageList.Images["SecsDriver"];
                tNodeScd.Tag = fXmlNodeScd;
                keyIndex++;

                // --

                // ***
                // SECS Device Load
                // ***
                foreach (FXmlNode fXmlNodeSdv in fXmlNodeScd.get_elemList(FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FSecsDevice.E_SecsDevice))
                {
                    tNodeSdv = new UltraTreeNode(keyIndex.ToString(), FCommon.getEapSchemaObjectText(fXmlNodeSdv));
                    tNodeSdv.Override.NodeAppearance.Image = FCommon.getImageOfEapSchemaSecsDevice(tvwSchema, fXmlNodeSdv);
                    tNodeSdv.Tag = fXmlNodeSdv;
                    keyIndex++;

                    // --

                    // ***
                    // SECS Session Load
                    // ***
                    foreach (FXmlNode fXmlNodeSsn in fXmlNodeSdv.get_elemList(FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.E_SecsSession))
                    {
                        tNodeSsn = new UltraTreeNode(keyIndex.ToString(), FCommon.getEapSchemaObjectText(fXmlNodeSsn));
                        tNodeSsn.Override.NodeAppearance.Image = tvwSchema.ImageList.Images["SecsSession"];
                        tNodeSsn.Tag = fXmlNodeSsn;
                        keyIndex++;
                        // --
                        tNodeSdv.Nodes.Add(tNodeSsn);
                    }

                    // --

                    tNodeScd.Nodes.Add(tNodeSdv);
                }

                // --

                // ***
                // Host Device Load
                // ***
                foreach (FXmlNode fXmlNodeHdv in fXmlNodeScd.get_elemList(FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FHostDevice.E_HostDevice))
                {
                    tNodeHdv = new UltraTreeNode(keyIndex.ToString(), FCommon.getEapSchemaObjectText(fXmlNodeHdv));
                    tNodeHdv.Override.NodeAppearance.Image = FCommon.getImageOfEapSchemaHostDevice(tvwSchema, fXmlNodeHdv);
                    tNodeHdv.Tag = fXmlNodeHdv;
                    keyIndex++;

                    // --

                    // ***
                    // Host Session Load
                    // *** 
                    foreach (FXmlNode fXmlNodeHsn in fXmlNodeHdv.get_elemList(FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FHostDevice.FHostSession.E_HostSession))
                    {
                        tNodeHsn = new UltraTreeNode(keyIndex.ToString(), FCommon.getEapSchemaObjectText(fXmlNodeHsn));
                        tNodeHsn.Override.NodeAppearance.Image = tvwSchema.ImageList.Images["HostSession"];
                        tNodeHsn.Tag = fXmlNodeHsn;
                        keyIndex++;
                        // --
                        tNodeHdv.Nodes.Add(tNodeHsn);
                    }

                    // --

                    tNodeScd.Nodes.Add(tNodeHdv);
                }

                // --

                // ***
                // Equipment Load
                // ***
                foreach (FXmlNode fXmlNodeEqp in fXmlNodeScd.get_elemList(FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.E_Equipment))
                {
                    tNodeEqp = new UltraTreeNode(keyIndex.ToString(), FCommon.getEapSchemaObjectText(fXmlNodeEqp));
                    tNodeEqp.Override.NodeAppearance.Image = FCommon.getImageOfEapSchemaEquipment(tvwSchema, fXmlNodeEqp);
                    tNodeEqp.Tag = fXmlNodeEqp;
                    keyIndex++;
                    // --
                    tNodeScd.Nodes.Add(tNodeEqp);
                }

                // --

                tNodeScd.Expanded = true;
                tvwSchema.Nodes.Add(tNodeScd);
                tvwSchema.endUpdate();

                // --

                if (tvwSchema.Nodes.Count > 0)
                {
                    if (m_lastSelectedSchema != string.Empty)
                    {
                        tvwSchema.ActiveNode = tvwSchema.GetNodeByKey(m_lastSelectedSchema);
                    }
                    if (m_lastSelectedSchema == string.Empty || tvwSchema.ActiveNode == null)
                    {
                        tvwSchema.ActiveNode = tvwSchema.Nodes[0];
                    }
                }
            }
            catch (Exception ex)
            {
                tvwSchema.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeScd = null;
                tNodeSdv = null;
                tNodeSsn = null;
                tNodeHdv = null;
                tNodeHsn = null;
                tNodeEqp = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMonitoringEquipmentTypeData(
            FMonitoringEquipmentTypeDataReceivedEventArgs args
            )
        {
            UltraGridRow row = null;
            UltraGridCell cell = null;
            object[] cellValues = null;
            string equipmentType = string.Empty;
            string desc = string.Empty;

            int index = 0;

            try
            {
                if (!tabMain.ActiveTab.Key.Equals("Type"))
                {
                    return;
                }

                // --

                grdClass.beginUpdate(false);

                // --

                equipmentType = args.equipmentType;
                desc = args.fXmlNode.get_elemVal(FADMADS_TolEquipmentTypeDataPush_In.FEquipmentType.A_Description, FADMADS_TolEquipmentTypeDataPush_In.FEquipmentType.D_Description);


                if (args.fType == FMonitoringDataType.Update)
                {
                    // ***
                    // Insert or Update Type information in tabMain
                    // ***
                    cellValues = new object[] {
                        equipmentType,
                        desc
                        };
                    // --
                    index = grdClass.appendOrUpdateDataRow(equipmentType, cellValues).Index;
                    row = grdClass.Rows.GetRowWithListIndex(index);

                    // --

                    cell = row.Cells["Name"];
                    cell.Appearance.Image = grdClass.ImageList.Images["EquipmentType"];
                }
                else
                {
                    // ***
                    // Delete server information in tabMain
                    // ***
                    grdClass.removeDataRow(equipmentType);
                }

                // --

                grdClass.endUpdate(false);
            }
            catch (Exception ex)
            {
                grdClass.endUpdate(false);
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                refreshClassTotal();

                // --

                row = null;
                cell = null;
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMonitoringEquipmentAreaData(
            FMonitoringEquipmentAreaDataReceivedEventArgs args
            )
        {
            UltraGridRow row = null;
            UltraGridCell cell = null;
            object[] cellValues = null;
            string equipmentArea = string.Empty;
            string desc = string.Empty;
            int index = 0;

            try
            {
                if (!tabMain.ActiveTab.Key.Equals("Area"))
                {
                    return;
                }

                // --

                grdClass.beginUpdate(false);

                // --

                equipmentArea = args.equipmentArea;
                desc = args.fXmlNode.get_elemVal(FADMADS_TolEquipmentAreaDataPush_In.FEquipmentArea.A_Description, FADMADS_TolEquipmentAreaDataPush_In.FEquipmentArea.D_Description);


                if (args.fType == FMonitoringDataType.Update)
                {
                    // ***
                    // Insert or Update Equipment Area information in tabMain
                    // ***
                    cellValues = new object[] {
                        equipmentArea,
                        desc
                        };
                    // --

                    index = grdClass.appendOrUpdateDataRow(equipmentArea, cellValues).Index;
                    row = grdClass.Rows.GetRowWithListIndex(index);

                    // --

                    cell = row.Cells["Name"];
                    cell.Appearance.Image = grdClass.ImageList.Images["EquipmentArea"];
                }
                else
                {
                    // ***
                    // Delete Equipment Area information in tabMain
                    // ***
                    grdClass.removeDataRow(equipmentArea);
                }

                // --

                grdClass.endUpdate(false);
            }
            catch (Exception ex)
            {
                grdClass.endUpdate(false);
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                refreshClassTotal();

                // --

                row = null;
                cell = null;
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMonitoringEquipmentLineData(
            FMonitoringEquipmentLineDataReceivedEventArgs args
            )
        {
            UltraGridRow row = null;
            UltraGridCell cell = null;
            object[] cellValues = null;
            string equipmentLine = string.Empty;
            string desc = string.Empty;
            int index = 0;

            try
            {
                if (!tabMain.ActiveTab.Key.Equals("Line"))
                {
                    return;
                }

                // --

                grdClass.beginUpdate(false);

                // --

                equipmentLine = args.equipmentLine;
                desc = args.fXmlNode.get_elemVal(FADMADS_TolEquipmentLineDataPush_In.FEquipmentLine.A_Description, FADMADS_TolEquipmentLineDataPush_In.FEquipmentLine.D_Description);


                if (args.fType == FMonitoringDataType.Update)
                {
                    // ***
                    // Insert or Update Equipment Line information in tabMain
                    // ***
                    cellValues = new object[] {
                        equipmentLine,
                        desc
                        };
                    // --
                    index = grdClass.appendOrUpdateDataRow(equipmentLine, cellValues).Index;
                    row = grdClass.Rows.GetRowWithListIndex(index);

                    // --

                    cell = row.Cells["Name"];
                    cell.Appearance.Image = grdClass.ImageList.Images["EquipmentLine"];
                }
                else
                {
                    // ***
                    // Delete Equipment Line information in tabMain
                    // ***
                    grdClass.removeDataRow(equipmentLine);
                }

                // --

                grdClass.endUpdate(false);
            }
            catch (Exception ex)
            {
                grdClass.endUpdate(false);
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                refreshClassTotal();

                // --

                row = null;
                cell = null;
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        #region Equipment Popup Menu

        private void procMenuEqStatus(
            )
        {
            FEquipmentStatus fEqStatus = null;

            try
            {
                fEqStatus = (FEquipmentStatus)m_fAdmCore.fAdmContainer.getChild(typeof(FEquipmentStatus));
                if (fEqStatus == null)
                {
                    fEqStatus = new FEquipmentStatus(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEqStatus);
                }
                fEqStatus.activate();
                
                // --
                
                if (this.activeEq == string.Empty)
                {
                    fEqStatus.attach(grdEqp.activeDataRowKey, FEapAttrCategory.Applied.ToString());
                }
                else
                {
                    fEqStatus.attach(this.activeEq, FEapAttrCategory.Applied.ToString());
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEqStatus = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEqHistory(
            )
        {
            FEquipmentHistory fEqHistory = null;

            try
            {
                fEqHistory = (FEquipmentHistory)m_fAdmCore.fAdmContainer.getChild(typeof(FEquipmentHistory));
                if (fEqHistory == null)
                {
                    fEqHistory = new FEquipmentHistory(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEqHistory);
                }
                fEqHistory.activate();
                // --
                if (activeEq == string.Empty)
                {
                    fEqHistory.attach(grdEqp.activeDataRowKey);
                }
                else
                {
                    fEqHistory.attach(activeEq);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEqHistory = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEquipmentGemStatus(
            )
        {
            FEquipmentGemStatus fEquipmentGemStatus = null;

            try
            {
                fEquipmentGemStatus = (FEquipmentGemStatus)m_fAdmCore.fAdmContainer.getChild(typeof(FEquipmentGemStatus));
                if (fEquipmentGemStatus == null)
                {
                    fEquipmentGemStatus = new FEquipmentGemStatus(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEquipmentGemStatus);
                }
                fEquipmentGemStatus.activate();
                // --
                if (activeEq == string.Empty)
                {
                    fEquipmentGemStatus.attach(grdEqp.activeDataRowKey);
                }
                else
                {
                    fEquipmentGemStatus.attach(activeEq);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEquipmentGemStatus = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEqEventDefineRequest(
            )
        {
            FEquipmentEventDefineRequest fEquipmentEventDefineRequest = null;

            try
            {
                fEquipmentEventDefineRequest = (FEquipmentEventDefineRequest)m_fAdmCore.fAdmContainer.getChild(typeof(FEquipmentEventDefineRequest));
                if (fEquipmentEventDefineRequest == null)
                {
                    fEquipmentEventDefineRequest = new FEquipmentEventDefineRequest(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEquipmentEventDefineRequest);
                }
                fEquipmentEventDefineRequest.activate();
                if (this.selectedEqs == null)
                {
                    fEquipmentEventDefineRequest.attach(grdEqp.selectedDataRows);
                }
                else
                {
                    fEquipmentEventDefineRequest.attach(this.selectedEqs, grdEqp.activeDataRowKey);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEquipmentEventDefineRequest = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEqVersionRequest(
            )
        {
            FEquipmentVersionRequest fEqVersionRequest = null;

            try
            {
                fEqVersionRequest = (FEquipmentVersionRequest)m_fAdmCore.fAdmContainer.getChild(typeof(FEquipmentVersionRequest));
                if (fEqVersionRequest == null)
                {
                    fEqVersionRequest = new FEquipmentVersionRequest(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEqVersionRequest);
                }
                fEqVersionRequest.activate();
                // --
                if (this.selectedEqs == null)
                {
                    fEqVersionRequest.attach(grdEqp.selectedDataRows);
                }
                else
                {
                    fEqVersionRequest.attach(this.selectedEqs, grdEqp.activeDataRowKey);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEqVersionRequest = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEqControlModeRequest(
            )
        {
            FEquipmentControlModeRequest fEqControlModeRequest = null;

            try
            {
                fEqControlModeRequest = (FEquipmentControlModeRequest)m_fAdmCore.fAdmContainer.getChild(typeof(FEquipmentControlModeRequest));
                if (fEqControlModeRequest == null)
                {
                    fEqControlModeRequest = new FEquipmentControlModeRequest(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEqControlModeRequest);
                }
                fEqControlModeRequest.activate();
                // --
                if (this.selectedEqs == null)
                {
                    fEqControlModeRequest.attach(grdEqp.selectedDataRows);
                }
                else
                {
                    fEqControlModeRequest.attach(this.selectedEqs, grdEqp.activeDataRowKey);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEqControlModeRequest = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuCustomRemoteCommandRequest(
            )
        {
            FCustomRemoteCommandRequest fCustomRemoteCommandRequest = null;

            try
            {
                fCustomRemoteCommandRequest = (FCustomRemoteCommandRequest)m_fAdmCore.fAdmContainer.getChild(typeof(FCustomRemoteCommandRequest));
                if (fCustomRemoteCommandRequest == null)
                {
                    fCustomRemoteCommandRequest = new FCustomRemoteCommandRequest(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fCustomRemoteCommandRequest);
                }
                fCustomRemoteCommandRequest.activate();
                // --
                if (this.selectedEqs == null)
                {
                    fCustomRemoteCommandRequest.attach(grdEqp.selectedDataRows);
                }
                else
                {
                    fCustomRemoteCommandRequest.attach(this.selectedEqs, grdEqp.activeDataRowKey);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fCustomRemoteCommandRequest = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuRemotePingTestByEquipment(
            )
        {
            FRemotePingTestByEquipment fRemotePingTest = null;
            List<FStructureEquipment> fEquipmentList = null;

            try
            {
                fRemotePingTest = (FRemotePingTestByEquipment)m_fAdmCore.fAdmContainer.getChild(typeof(FRemotePingTestByEquipment));
                if (fRemotePingTest == null)
                {
                    fRemotePingTest = new FRemotePingTestByEquipment(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fRemotePingTest);
                }
                fRemotePingTest.activate();

                // --

                fEquipmentList = new List<FStructureEquipment>();
                foreach (UltraDataRow row in grdEqp.selectedDataRows)
                {
                    fEquipmentList.Add(
                        new FStructureEquipment(
                            row["Equipment"].ToString(),   // Equipment
                            row["Eap"].ToString(),         // Eap
                            row["Description"].ToString(), // Description
                            row["Ip Address"].ToString()   // Ip Address
                            )
                        );
                }

                // --
                fRemotePingTest.attach(fEquipmentList);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fRemotePingTest = null;
                fEquipmentList = null;
            }
        }

        #endregion

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FEquipmentMonitor Form Event Handler

        private void FEquipmentMonitor_Load(
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
                designTreeOfEapSchema();

                // --

                // ***
                // 2012.11.22 by mjkim
                // Design에서 설정하는 경우,
                // 'Form_Load'보다 'Tab_Changed' Event가 더 먼저 발생한다.
                // ***
                tabMain.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(tabMain_SelectedTabChanged);

                // --

                m_fAdmCore.fOption.fChildFormList.add(this);
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

        private void FEquipmentMonitor_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshClassGridOfEquipmentType();

                // --

                // ***
                // FAdsCore Event Handler 설정
                // ***
                m_fAdmCore.MonitoringEapDataReceived += new FMonitoringEapDataReceivedEventHandler(m_fAdmCore_MonitoringEapDataReceived);
                m_fAdmCore.MonitoringEquipmentTypeDataReceived += new FMonitoringEquipmentTypeDataReceivedEventHandler(m_fAdmCore_MonitoringEquipmentTypeDataReceived);
                m_fAdmCore.MonitoringEquipmentAreaDataReceived += new FMonitoringEquipmentAreaDataReceivedEventHandler(m_fAdmCore_MonitoringEquipmentAreaDataReceived);
                m_fAdmCore.MonitoringEquipmentLineDataReceived += new FMonitoringEquipmentLineDataReceivedEventHandler(m_fAdmCore_MonitoringEquipmentLineDataReceived);
                m_fAdmCore.MonitoringEquipmentDataReceived += new FMonitoringEquipmentDataReceivedEventHandler(m_fAdmCore_MonitoringEquipmentDataReceived);

                // --

                grdEqp.Focus();
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

        private void FEquipmentMonitor_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                // ***
                // FAdsCore Event Handler 해지
                // ***
                m_fAdmCore.MonitoringEapDataReceived -= new FMonitoringEapDataReceivedEventHandler(m_fAdmCore_MonitoringEapDataReceived);
                m_fAdmCore.MonitoringEquipmentTypeDataReceived -= new FMonitoringEquipmentTypeDataReceivedEventHandler(m_fAdmCore_MonitoringEquipmentTypeDataReceived);
                m_fAdmCore.MonitoringEquipmentAreaDataReceived -= new FMonitoringEquipmentAreaDataReceivedEventHandler(m_fAdmCore_MonitoringEquipmentAreaDataReceived);
                m_fAdmCore.MonitoringEquipmentLineDataReceived -= new FMonitoringEquipmentLineDataReceivedEventHandler(m_fAdmCore_MonitoringEquipmentLineDataReceived);
                m_fAdmCore.MonitoringEquipmentDataReceived -= new FMonitoringEquipmentDataReceivedEventHandler(m_fAdmCore_MonitoringEquipmentDataReceived);

                // --

                tabMain.SelectedTabChanged -= new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(tabMain_SelectedTabChanged);

                // --

                m_fAdmCore.fOption.fChildFormList.remove(this);
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

        private void FEquipmentMonitor_KeyDown(
            object sender, 
            KeyEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                if (e.KeyCode == Keys.F5)
                {
                    if (grdClass.Focused)
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
                    else
                    {
                        refreshGridOfEquipment();
                        // --
                        grdEqp.Focus();
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

        #region mnuMenu Control Event Handler

        private void mnuMenu_ToolClick(
            object sender,
            Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --
                if (e.Tool.Key == FMenuKey.MenuMonEquipmentStatus)
                {
                    procMenuEqStatus();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonEquipmentHistory)
                {
                    procMenuEqHistory();
                }
                // --
                if (e.Tool.Key == FMenuKey.MenuMonEquipmentGemStatus)
                {
                    procMenuEquipmentGemStatus();
                }
                // --                
                else if (e.Tool.Key == FMenuKey.MenuMonEquipmentEventDefineRequest)
                {
                    procMenuEqEventDefineRequest();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonEquipmentVersionRequest)
                {
                    procMenuEqVersionRequest();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonEquipmentControlModeRequest)
                {
                    procMenuEqControlModeRequest();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonCustomRemoteCommandRequest)
                {
                    procMenuCustomRemoteCommandRequest();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonRemotePingTestByEquipment)
                {
                    procMenuRemotePingTestByEquipment();
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

        private void tabMain_SelectedTabChanged(
            object sender,
            Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

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

        #region grdEqp Control Event Handler

        private void grdEqp_AfterRowActivate(
            object sender, 
            EventArgs e
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                FCursor.waitCursor();

                // --

                 fXmlNode = refreshEapSchema();

                // --

                refreshTreeOfEapSchema(fXmlNode);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fXmlNode = null;

                // --

                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void grdEqp_MouseDown(
            object sender, 
            MouseEventArgs e
            )
        {
            UltraGridRow r = null;

            try
            {
                FCursor.waitCursor();

                // --

                if (e.Button != MouseButtons.Right || grdEqp.Rows.Count == 0)
                {
                    return;
                }

                // --

                r = (UltraGridRow)grdEqp.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y)).
                    GetContext(typeof(UltraGridRow));
                if (r != null)
                {
                    grdEqp.ActiveRow = grdEqp.Rows[r.Index];
                }

                // --

                mnuMenu.Tools[FMenuKey.MenuMonEquipmentStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentStatus);
                mnuMenu.Tools[FMenuKey.MenuMonEquipmentHistory].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentHistory);                
                // --
                mnuMenu.Tools[FMenuKey.MenuMonEquipmentGemStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentGemStatus);
                // --
                mnuMenu.Tools[FMenuKey.MenuMonEquipmentEventDefineRequest].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentEventDefineRequest);
                mnuMenu.Tools[FMenuKey.MenuMonEquipmentVersionRequest].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentVersionRequest);
                mnuMenu.Tools[FMenuKey.MenuMonEquipmentControlModeRequest].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentControlModeRequest);
                mnuMenu.Tools[FMenuKey.MenuMonCustomRemoteCommandRequest].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.CustomRemoteCommandRequest);
                // --
                mnuMenu.Tools[FMenuKey.MenuMonRemotePingTestByEquipment].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.RemotePingTestByEquipment);

                // --

                mnuMenu.ShowPopup(FMenuKey.MenuMonEqpPopupMenu);         
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                r = null;
                // --
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void grdEqp_DoubleClickRow(
            object sender, 
            DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (grdEqp.ActiveRow == null || !FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentHistory))
                {
                    return;
                }

                // --

                procMenuEqHistory();
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

        #region tvwSchema Control Event Handler

        private void tvwSchema_AfterActivate(
            object sender, 
            NodeEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.TreeNode == null)
                {
                    return;
                }

                // --

                FCommon.setPropertyOfEapSchemaObject(m_fAdmCore, pgdSchema, (FXmlNode)e.TreeNode.Tag);
                // --
                m_lastSelectedSchema = e.TreeNode.Key;
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

        private void tvwSchema_MouseDown(
            object sender, 
            MouseEventArgs e
            )
        {
            UltraTreeNode tNode = null;
            FXmlNode fXmlNode = null;
            
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Button != MouseButtons.Right || tvwSchema.ActiveNode == null)
                {
                    return;
                }

                // --

                tNode = tvwSchema.GetNodeFromPoint(e.X, e.Y);
                if (tNode != null)
                {
                    tvwSchema.ActiveNode = tNode;
                }

                // --

                fXmlNode = (FXmlNode)tvwSchema.ActiveNode.Tag;
                if (fXmlNode.name != FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.E_Equipment)
                {
                    return;
                }

                // --

                mnuMenu.Tools[FMenuKey.MenuMonEquipmentStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentStatus);
                mnuMenu.Tools[FMenuKey.MenuMonEquipmentHistory].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentHistory);
                // --
                mnuMenu.Tools[FMenuKey.MenuMonEquipmentGemStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentGemStatus);
                // --
                mnuMenu.Tools[FMenuKey.MenuMonEquipmentEventDefineRequest].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentEventDefineRequest);
                mnuMenu.Tools[FMenuKey.MenuMonEquipmentVersionRequest].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentVersionRequest);
                mnuMenu.Tools[FMenuKey.MenuMonEquipmentControlModeRequest].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentControlModeRequest);
                mnuMenu.Tools[FMenuKey.MenuMonCustomRemoteCommandRequest].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.CustomRemoteCommandRequest);
                // --
                mnuMenu.Tools[FMenuKey.MenuMonRemotePingTestByEquipment].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.RemotePingTestByEquipment);

                // --

                mnuMenu.ShowPopup(FMenuKey.MenuMonEqpPopupMenu);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                tNode = null;
                fXmlNode = null;
                // --
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwSchema_DoubleClick(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (
                    tvwSchema.ActiveNode == null ||
                    ((FXmlNode)tvwSchema.ActiveNode.Tag).name != FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.E_Equipment ||
                    !FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentHistory)
                    )
                {
                    return;
                }


                // --

                procMenuEqHistory();
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

        #region chkAll Control Event Handler

        private void chkAll_CheckedChanged(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                grdClass.Enabled = !chkAll.Checked;

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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region rstClassToolbar Control Event Handler

        private void rstClassToolbar_RefreshRequested(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

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

        private void rstClassToolbar_SearchRequested(
            object sender, 
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdClass.searchGridRow(e.searchWord))
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
        
        #region rstEquipmentToolbar Control Event Handler
        
        private void rstEquipmentToolbar_RefreshRequested(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfEquipment();

                // --

                grdEqp.Focus();
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
        
        private void rstEquipmentToolbar_SearchRequested(
            object sender, 
            FSearchRequestedEventArgs e
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
            string beforeKey = string.Empty;
            string key = string.Empty;
            int nextRowNumber = 0;
            int index = 0;
            string ctrlMode = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                if (e.searchWord == string.Empty)
                {
                    return;
                }

                // --

                tvwSchema.beginUpdate();
                tvwSchema.Nodes.Clear();
                tvwSchema.endUpdate();
                // --
                pgdSchema.selectedObject = null;

                // --

                beforeKey = grdEqp.activeDataRowKey;
                // --
                grdEqp.beginUpdate(false);
                grdEqp.removeAllDataRow();
                grdEqp.DisplayLayout.Bands[0].SortedColumns.Clear();

                // --

                if (grdClass.Enabled == true)
                {
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
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("search_word", e.searchWord);
                fSqlParams.add("attr_category", FEapAttrCategory.Applied.ToString());
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Tool", "EquipmentMonitor", "SearchEquipment", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        ctrlMode = r[11].ToString();
                        // --

                        cellValues = new object[] {
                            r[0].ToString(),  // Equipment
                            r[1].ToString(),  // Description
                            r[2].ToString(),  // EAP
                            r[3].ToString(),  // Server
                            r[4].ToString(),  // UpDown
                            r[5].ToString(),  // Status
                            r[6].ToString(),  // Type
                            r[7].ToString(),  // Area                     
                            r[8].ToString(),  // Line
                            r[9].ToString(),  // Mdln
                            r[10].ToString(), // Softrev
                            ctrlMode,         // Control Mode
                            r[12].ToString(), // Pri State
                            r[13].ToString(), // State
                            r[14].ToString(), // Alarm
                            r[15].ToString()  // Event Define
                            };
                        index = grdEqp.appendDataRow(r[0].ToString(), cellValues).Index;
                        row = grdEqp.Rows[index];

                        // --

                        cell = row.Cells["Equipment"];
                        cell.Appearance.Image = FCommon.getImageOfEquipment(grdEqp, ctrlMode);

                        // --

                        if (ctrlMode == FEquipmentControlMode.Offline.ToString())
                        {
                            row.Appearance.BackColor = Color.FromArgb(233, 233, 233);
                        }
                        else if (ctrlMode == FEquipmentControlMode.OnlineLocal.ToString())
                        {
                            row.Appearance.BackColor = Color.FromArgb(250, 237, 125);
                        }
                        else
                        {
                            row.Appearance.BackColor = Color.WhiteSmoke;
                        }

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
                        }

                        // --

                        cell = row.Cells["Up/Down"];
                        if (cell.Text == FUpDown.Down.ToString())
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                            // --
                            cell = row.Cells["Equipment"];
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
                        cell = row.Cells["Server"];
                        if (cell.Text == "N/A")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                            // --
                            cell = row.Cells["Equipment"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }

                        FCommon.designGridCellForEapUpDown(row.Cells["Up/Down"]);
                        FCommon.designGridCellForEapStatus(row.Cells["Status"]);

                    }
                } while (nextRowNumber >= 0);

                // --

                grdEqp.endUpdate(false);
                grdEqp.DisplayLayout.Bands[0].SortedColumns.Add("Equipment", false);

                // --

                if (grdEqp.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdEqp.activateDataRow(beforeKey);
                    }
                    if (grdEqp.activeDataRow == null)
                    {
                        grdEqp.ActiveRow = grdEqp.Rows[0];
                    }
                }

                // --

                m_isSearchMode = true;
            }
            catch (Exception ex)
            {
                grdEqp.endUpdate(false);
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                refreshEquipmentTotal();

                // --

                fSqlParams = null;
                dt = null;
                row = null;
                cell = null;

                // --

                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fAdmCore Object Event Handler

        private void m_fAdmCore_MonitoringEapDataReceived(
            object sender, 
            FMonitoringEapDataReceivedEventArgs e
            )
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        procMonitoringEapEquipmentData(e);
                    }));
                }
                else
                {
                    procMonitoringEapEquipmentData(e);
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

        private void m_fAdmCore_MonitoringEquipmentDataReceived(
            object sender, 
            FMonitoringEquipmentDataReceivedEventArgs e
            )
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        procMonitoringEquipmentData(e);
                    }));
                }
                else
                {
                    procMonitoringEquipmentData(e);
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

        private void m_fAdmCore_MonitoringEquipmentLineDataReceived(
            object sender, 
            FMonitoringEquipmentLineDataReceivedEventArgs e
            )
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        procMonitoringEquipmentLineData(e);
                    }));
                }
                else
                {
                    procMonitoringEquipmentLineData(e);
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

        private void m_fAdmCore_MonitoringEquipmentAreaDataReceived(
            object sender, 
            FMonitoringEquipmentAreaDataReceivedEventArgs e
            )
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        procMonitoringEquipmentAreaData(e);
                    }));
                }
                else
                {
                    procMonitoringEquipmentAreaData(e);
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

        private void m_fAdmCore_MonitoringEquipmentTypeDataReceived(
            object sender, 
            FMonitoringEquipmentTypeDataReceivedEventArgs e
            )
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        procMonitoringEquipmentTypeData(e);
                    }));
                }
                else
                {
                    procMonitoringEquipmentTypeData(e);
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

    }   // Class end
}   // Namespace end
