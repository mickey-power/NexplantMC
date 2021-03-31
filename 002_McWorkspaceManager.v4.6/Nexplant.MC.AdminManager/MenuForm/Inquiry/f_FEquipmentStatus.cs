/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FEquipmentStatus.cs
--  Creator         : hsshim
--  Create Date     : 2013.02.08
--  Description     : FAMate Admin Manager Equipment Status Form Class 
--  History         : Created by hsshim at 2013.02.08
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinTree;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public partial class FEquipmentStatus : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private string[] m_logLevelCaption = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEquipmentStatus(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEquipmentStatus(
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

        private string activeEap
        {
            get
            {
                try
                {
                    return grdEapDetail.Rows[0].Cells[1].Text;                
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
                    if (n.name != FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.E_Equipment)
                    {
                        return string.Empty;
                    }

                    // --

                    return n.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.A_Name,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.D_Name
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
                    n = null;
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
                base.fUIWizard.changeControlFontName(mnuMenu);
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
   
        private void designComboOfCategory(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = ucbCategory.dataSource;
                // --
                uds.Band.Columns.Add("Category");

                // --

                ucbCategory.Appearance.Image = Properties.Resources.EapAttrCategory;
                // --
                ucbCategory.DisplayLayout.Bands[0].Columns["Category"].CellAppearance.Image = Properties.Resources.EapAttrCategory;
                ucbCategory.DisplayLayout.Bands[0].Columns["Category"].Width = ucbCategory.Width - 2;
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
        
        private void designGridOfEquipmentDetail(
            )
        {
            string[] columns = null;

            try
            {
                columns = new string[]
                {
                    "Equipment",
                    "Description",
                    "IP Address",
                    // --
                    "Equipment Type",
                    "Equipment Area",
                    "Equipment Line",                    
                    // --
                    "Control Mode",
                    "Primary State",
                    "State",                    
                    // --
                    "MDLN",
                    "Soft Rev.",
                    "Event Define",                    
                    // --
                    "Creator",
                    "Updater",
                    "Empty2",
                    // --
                    "Last Event Time",
                    "Last Event ID",
                    "Empty3"
                };

                // --

                grdDetail.addColumns(3, columns);
                grdDetail.setColumnHeaderWidth(120);
                // --
                grdDetail.DisplayLayout.Override.TipStyleCell = TipStyle.Show;

                // --

                grdDetail.Rows[4].Cells[4].Value = string.Empty;
                grdDetail.Rows[5].Cells[4].Value = string.Empty;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                columns = null;
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------        
        
        private void designGridOfEapDetail(
            )
        {
            string[] columns = null;

            try
            {
                columns = new string[]
                {
                    "EAP",
                    "EAP Description",
                    "RPM Count",
                    // --
                    "Type",
                    "Operation Mode",
                    "Server",
                    // --
                    "Up/Down",
                    "Status",                       
                    "Step",
                    // --
                    "Need Action",
                    "Next Need Action",
                    "Reload Count",
                    // --
                    "Package",
                    "Model",
                    "Component",
                    // --
                    "Creator",
                    "Updater",
                    "Empty1",
                    // --
                    "Last Event Time",
                    "Last Event",
                    "Empty2"                 
                };

                // --

                grdEapDetail.addColumns(3, columns);
                grdEapDetail.setColumnHeaderWidth(120);
                // --
                grdEapDetail.DisplayLayout.Override.TipStyleCell = TipStyle.Show;

                // --

                grdEapDetail.Rows[5].Cells[4].Value = string.Empty;
                grdEapDetail.Rows[6].Cells[4].Value = string.Empty;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                columns = null;
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

        private void designGridOfEapConfig(
            )
        {
            string[] columns = null;

            try
            {
                columns = new string[]
                {
                    "Network Path",
                    "File User",
                    "File Password",
                    // --
                    "Backup Path",
                    "Backup User",
                    "Backup Password",
                    // --
                    "Error Path",
                    "Error User",
                    "Error Password",             
                    // --
                    "Search Pattern",
                    "Search Period",
                    "Empty1",
                    // --
                    "Language",
                    "User ID",
                    "Debug Log",
                    // --
                    "SECS Log",
                    "SECS Log Max File Size (MB)",
                    "SECS Log Max File Size (Byte)",
                    // --
                    "Binary Log",
                    "Binary Log Max File Size (MB)",
                    "Binary Log Max File Size (Byte)",                    
                    // --    
                    "VFEI Log",
                    "VFEI Log Max File Size (MB)",
                    "VFEI Log Max File Size (Byte)",                    
                    // --
                    "SML Log",
                    "SML Log Max File Size (MB)",
                    "SML Log Max File Size (Byte)"
                };

                // --

                grdConfig.addColumns(3, columns);
                grdConfig.setColumnHeaderWidth(120);

                // --

                grdConfig.DisplayLayout.Override.TipStyleCell = TipStyle.Show;

                // --

                grdConfig.Rows[3].Cells[4].Value = string.Empty;

                // --

                grdConfig.Rows[3].Cells[3].Appearance.TextHAlign = HAlign.Right;
                // --
                grdConfig.Rows[4].Cells[5].Appearance.TextHAlign = HAlign.Right;
                // --
                grdConfig.Rows[5].Cells[2].Value = "Max File Size (MB)";
                grdConfig.Rows[5].Cells[3].Appearance.TextHAlign = HAlign.Right;
                grdConfig.Rows[5].Cells[4].Value = "Max File Size (Byte)";
                grdConfig.Rows[5].Cells[5].Appearance.TextHAlign = HAlign.Right;
                // --
                grdConfig.Rows[6].Cells[2].Value = "Max File Size (MB)";
                grdConfig.Rows[6].Cells[3].Appearance.TextHAlign = HAlign.Right;
                grdConfig.Rows[6].Cells[4].Value = "Max File Size (Byte)";
                grdConfig.Rows[6].Cells[5].Appearance.TextHAlign = HAlign.Right;
                // --
                grdConfig.Rows[7].Cells[2].Value = "Max File Size (MB)";
                grdConfig.Rows[7].Cells[3].Appearance.TextHAlign = HAlign.Right;
                grdConfig.Rows[7].Cells[4].Value = "Max File Size (Byte)";
                grdConfig.Rows[7].Cells[5].Appearance.TextHAlign = HAlign.Right;
                // --
                grdConfig.Rows[8].Cells[2].Value = "Max File Size (MB)";
                grdConfig.Rows[8].Cells[3].Appearance.TextHAlign = HAlign.Right;
                grdConfig.Rows[8].Cells[4].Value = "Max File Size (Byte)";
                grdConfig.Rows[8].Cells[5].Appearance.TextHAlign = HAlign.Right;

                // --

                foreach (UltraGridRow r in grdConfig.Rows)
                {
                    r.Hidden = true;
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                columns = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void designGridOfLogLevel(
            )
        {
            string[] columns = null;

            try
            {
                columns = new string[]
                {
                    "Log Level 1",
                    "Log Level 2",
                    "Log Level 3",
                    // --
                    "Log Level 4",
                    "Log Level 5",
                    "Log Level 6",
                    // --
                    "Log Level 7",
                    "Log Level 8",
                    "Log Level 9",
                    // --
                    "Log Level 10",
                    "Empty1",
                    "Empty2",
                };

                // --

                grdLogLevel.addColumns(3, columns);
                grdLogLevel.setColumnHeaderWidth(120);

                // --

                grdConfig.DisplayLayout.Override.TipStyleCell = TipStyle.Show;

                // --

                grdLogLevel.Rows[3].Cells[2].Value = string.Empty;
                grdLogLevel.Rows[3].Cells[4].Value = string.Empty;

                // --

                grdLogLevel.Rows[0].Cells[0].Value = m_logLevelCaption[0];
                grdLogLevel.Rows[0].Cells[2].Value = m_logLevelCaption[1];
                grdLogLevel.Rows[0].Cells[4].Value = m_logLevelCaption[2];
                // --
                grdLogLevel.Rows[1].Cells[0].Value = m_logLevelCaption[3];
                grdLogLevel.Rows[1].Cells[2].Value = m_logLevelCaption[4];
                grdLogLevel.Rows[1].Cells[4].Value = m_logLevelCaption[5];
                // --
                grdLogLevel.Rows[2].Cells[0].Value = m_logLevelCaption[6];
                grdLogLevel.Rows[2].Cells[2].Value = m_logLevelCaption[7];
                grdLogLevel.Rows[2].Cells[4].Value = m_logLevelCaption[8];
                // --
                grdLogLevel.Rows[3].Cells[0].Value = m_logLevelCaption[9];
                grdLogLevel.Rows[3].Cells[2].Value = string.Empty;
                grdLogLevel.Rows[3].Cells[4].Value = string.Empty;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                columns = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void designTreeOfEapEnvironment(
            )
        {
            try
            {
                tvwEnv.ImageList = new ImageList();
                // --
                tvwEnv.ImageList.Images.Add("SecsDriver", Properties.Resources.SecsDriver);
                tvwEnv.ImageList.Images.Add("PlcDriver", Properties.Resources.PlcDriver);
                tvwEnv.ImageList.Images.Add("OpcDriver", Properties.Resources.OpcDriver);
                tvwEnv.ImageList.Images.Add("TcpDriver", Properties.Resources.TcpDriver);
                tvwEnv.ImageList.Images.Add("Equipment", Properties.Resources.Equipment);
                tvwEnv.ImageList.Images.Add("EnvironmentList", Properties.Resources.EnvironmentList);
                tvwEnv.ImageList.Images.Add("Environment", Properties.Resources.Environment);
                tvwEnv.ImageList.Images.Add("Environment_List", Properties.Resources.Environment_List);
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

        private void clearGridOfEapDetail(
            )
        {
            try
            {
                // ***
                // EAP Detail Clear
                // ***
                grdEapDetail.beginUpdate();
                grdEapDetail.clearColumnValue();
                grdEapDetail.endUpdate();

                // --

                // ***
                // EAP Schema Clear
                // ***
                tvwSchema.beginUpdate();
                tvwSchema.Nodes.Clear();
                tvwSchema.endUpdate();
                // --
                pgdSchema.selectedObject = null;

                // --

                // ***
                // EAP Environment Clear
                // ***
                tvwEnv.beginUpdate();
                tvwEnv.Nodes.Clear();
                tvwEnv.endUpdate();
                // --
                pgdEnv.selectedObject = null;

                // --

                // ***
                // EAP Detail Clear
                // ***
                grdConfig.beginUpdate();
                grdConfig.clearColumnValue();
                foreach (UltraGridRow r in grdConfig.Rows)
                {
                    r.Hidden = true;
                }
                grdConfig.endUpdate();

                // --

                // ***
                // Log Level Clear
                // *** 
                grdLogLevel.beginUpdate();
                grdLogLevel.clearColumnValue();
                grdLogLevel.endUpdate();
            }
            catch (Exception ex)
            {
                grdEapDetail.endUpdate();
                tvwSchema.endUpdate();
                tvwEnv.endUpdate();
                grdConfig.endUpdate();
                grdLogLevel.endUpdate();
                // --
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void clear(
            )
        {
            try
            {
                // ***
                // Equipment Detail Information Clear
                // ***
                grdDetail.beginUpdate();
                grdDetail.clearColumnValue();
                grdDetail.endUpdate();

                // --

                // ***
                // EAP Detail Information Clear
                // ***
                clearGridOfEapDetail();
            }
            catch (Exception ex)
            {
                grdDetail.endUpdate();
                // --
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void refreshComboOfCategory(
             )
        {
            string category = string.Empty;

            try
            {
                category = ucbCategory.Text == string.Empty ? FEapAttrCategory.Applied.ToString() : ucbCategory.Text;

                // --

                ucbCategory.beginUpdate(false);
                ucbCategory.removeAllDataRow();

                // --

                foreach (string s in Enum.GetNames(typeof(FEapAttrCategory)))
                {
                    ucbCategory.appendDataRow(s, new object[] { s });
                }

                // --
                 
                ucbCategory.endUpdate(false);

                // --

                ucbCategory.Text = category;
            }
            catch (Exception ex)
            {
                ucbCategory.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfEquipmentDetail(
             )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            DataRow row = null;
            object[] cellValues = null;
            string eqpName = string.Empty;
            string eqpDesc = string.Empty;
            string eqpRecipe = string.Empty;
            string type = string.Empty;
            string area = string.Empty;
            string line = string.Empty;
            string controlMode = string.Empty;
            string priState = string.Empty;
            string state = string.Empty;
            string eqMdln = string.Empty;
            string eqSoftRev = string.Empty;
            string eqEventDefine = string.Empty;
            string creator = string.Empty;
            string updater = string.Empty;
            string lastEventTime = string.Empty;
            string lastEventID = string.Empty;
            string ipAddr = string.Empty;
            int index = 0;

            try
            {
                grdDetail.beginUpdate();
                grdDetail.clearColumnValue();

                // --

                #region Validation

                if (txtEqpName.Text == string.Empty)
                {
                    grdDetail.endUpdate();
                    txtEqpName.Focus();
                    FDebug.throwFException(fUIWizard.generateMessage("E0004", new object[] { "Equipment" }));
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("eqp_name", txtEqpName.Text);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "EquipmentStatus", "HasEquipment", fSqlParams, false);
                // --
                if (dt.Rows.Count == 0)
                {
                    grdDetail.endUpdate();
                    txtEqpName.Focus();
                    FDebug.throwFException(fUIWizard.generateMessage("E0010", new object[] { "Equipment" }));
                }

                #endregion

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("eqp_name", txtEqpName.Text.Trim());

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "EquipmentStatus", "SearchEquipment", fSqlParams, false);
                // --
                if (dt.Rows.Count > 0)
                {
                    row = dt.Rows[0];
                    // --
                    eqpName = row[index++].ToString();
                    eqpDesc = row[index++].ToString();
                    eqpRecipe = row[index++].ToString();
                    type = row[index++].ToString();
                    area = row[index++].ToString();
                    line = row[index++].ToString();
                    controlMode = row[index++].ToString();                    
                    priState = row[index++].ToString();
                    state = row[index++].ToString();
                    eqMdln = row[index++].ToString();
                    eqSoftRev = row[index++].ToString();
                    eqEventDefine = row[index++].ToString();
                    creator = row[index++] + " [" + FDataConvert.defaultDataTimeFormating(row[index++].ToString()) + "]";
                    updater = row[index++] + " [" + FDataConvert.defaultDataTimeFormating(row[index++].ToString()) + "]";
                    lastEventTime = FDataConvert.defaultDataTimeFormating(row[index++].ToString());
                    lastEventID = row[index++].ToString();
                    ipAddr = row[index++].ToString();
                }

                // --

                cellValues = new object[] {
                    eqpName,                                                            // Equipment
                    eqpDesc,                                                            // Equipment Description
                    ipAddr,                                                             // IP Address (2017.06.07 by spike.lee add)
                    // --
                    type,                                                               // Type
                    area,                                                               // Area
                    line,                                                               // Line                    
                    // --
                    controlMode,                                                        // Control Mode
                    string.IsNullOrWhiteSpace(priState)  ? "N/A" : priState,            // Primary State
                    string.IsNullOrWhiteSpace(state)     ? "N/A" : state,               // State             
                    // --
                    string.IsNullOrWhiteSpace(eqMdln)    ? "N/A" : eqMdln,              // Equipment Model Number
                    string.IsNullOrWhiteSpace(eqSoftRev) ? "N/A" : eqSoftRev,           // Equipment Soft Version
                    string.IsNullOrWhiteSpace(eqEventDefine) ? "N/A" :  eqEventDefine,  // Event Define Result
                    // --                                        
                    creator,
                    updater,
                    string.Empty,
                    // --
                    lastEventTime,
                    lastEventID,
                    string.Empty
                    };
                grdDetail.setColumnValues(cellValues);

                // --

                FCommon.designGridCellForControlMode(grdDetail.getColumn("Control Mode"));
                FCommon.designGridCellForNotApplicable(grdDetail.getColumn("Primary State"));
                FCommon.designGridCellForNotApplicable(grdDetail.getColumn("State"));
                FCommon.designGridCellForNotApplicable(grdDetail.getColumn("MDLN"));
                FCommon.designGridCellForNotApplicable(grdDetail.getColumn("Soft Rev."));
                FCommon.designGridCellForNotApplicable(grdDetail.getColumn("Event Define"));

                // --

                grdDetail.endUpdate();

                // --

                foreach (UltraGridRow r in grdDetail.Rows)
                {
                    for (int i = 0; i < r.Cells.Count; i += 2)
                    {
                        r.Cells[i + 1].ToolTipText = (string)r.Cells[i + 1].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                grdDetail.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
                row = null;
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfEapDetail(
             )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            DataRow row = null;
            UltraGridCell cell = null;
            object[] cellValues = null;
            string eqpName = string.Empty;
            string eap = string.Empty;
            string eapDesc = string.Empty;
            string eapType = string.Empty;
            string reloadCount = string.Empty;
            string server = string.Empty;
            string step = string.Empty;
            string eapUpDown = string.Empty;
            string eapStatus = string.Empty;
            string package = string.Empty;
            string model = string.Empty;
            string component = string.Empty;
            string needAction = string.Empty;
            string nextNeedAtion = string.Empty;
            string creator = string.Empty;
            string updater = string.Empty;
            string lastEventTime = string.Empty;
            string lastEventID = string.Empty;
            string rpmCnt = string.Empty;
            string operMode = string.Empty;
            string logLevel1 = string.Empty;
            string logLevel2 = string.Empty;
            string logLevel3 = string.Empty;
            string logLevel4 = string.Empty;
            string logLevel5 = string.Empty;
            string logLevel6 = string.Empty;
            string logLevel7 = string.Empty;
            string logLevel8 = string.Empty;
            string logLevel9 = string.Empty;
            string logLevel10 = string.Empty;
            int index = 0;

            try
            {
                grdEapDetail.beginUpdate();
                grdLogLevel.beginUpdate();
                grdEapDetail.clearColumnValue();
                grdLogLevel.clearColumnValue();
                // --
                if (txtEqpName.Text == string.Empty)
                {
                    grdEapDetail.endUpdate();
                    grdLogLevel.endUpdate();
                    return;
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("eqp_name", txtEqpName.Text);
                fSqlParams.add("attr_category", ucbCategory.Text);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "EquipmentStatus", "SearchEap", fSqlParams, false);
                
                // --
                
                if (dt.Rows.Count > 0)
                {
                    row = dt.Rows[0];
                    // --
                    eap = row[index++].ToString();
                    eapDesc = row[index++].ToString();
                    eapType = row[index++].ToString();
                    server = row[index++].ToString();
                    eapUpDown = row[index++].ToString();
                    eapStatus = row[index++].ToString();
                    step = row[index++].ToString();
                    needAction = row[index++].ToString();
                    nextNeedAtion = row[index++].ToString();
                    package = FCommon.generateStringForPackage(row[index++].ToString(), row[index++].ToString());
                    model = FCommon.generateStringForModel(row[index++].ToString(), row[index++].ToString());
                    component = FCommon.generateStringForComponent(row[index++].ToString(), row[index++].ToString(), row[index++].ToString());
                    reloadCount = row[index++].ToString();
                    creator = row[index++] + " [" + FDataConvert.defaultDataTimeFormating(row[index++].ToString()) + "]";
                    updater = row[index++] + " [" + FDataConvert.defaultDataTimeFormating(row[index++].ToString()) + "]";
                    lastEventTime = FDataConvert.defaultDataTimeFormating(row[index++].ToString());
                    lastEventID = row[index++].ToString();
                    rpmCnt = row[index++].ToString();
                    operMode = row[index++].ToString();

                    // --

                    logLevel1 = row[index++].ToString().Trim();
                    logLevel2 = row[index++].ToString().Trim();
                    logLevel3 = row[index++].ToString().Trim();
                    logLevel4 = row[index++].ToString().Trim();
                    logLevel5 = row[index++].ToString().Trim();
                    logLevel6 = row[index++].ToString().Trim();
                    logLevel7 = row[index++].ToString().Trim();
                    logLevel8 = row[index++].ToString().Trim();
                    logLevel9 = row[index++].ToString().Trim();
                    logLevel10 = row[index++].ToString().Trim();

                    // --

                    cellValues = new object[] {
                        eap,
                        eapDesc,
                        rpmCnt,
                        // --
                        eapType,
                        operMode,
                        server,
                        // --
                        eapUpDown,
                        eapStatus,
                        step,
                        // -- 
                        needAction,
                        nextNeedAtion,
                        reloadCount,
                        // --
                        package,
                        model,
                        component,
                        // --                                                
                        creator,
                        updater,
                        string.Empty,
                        // --
                        lastEventTime,
                        lastEventID,
                        string.Empty
                        };
                    grdEapDetail.setColumnValues(cellValues);

                    // --

                    // ***
                    // 2017.07.05 by spike.lee
                    // EAP Log Level 
                    // ***
                    cellValues = new object[] {
                        logLevel1 == string.Empty ? FYesNo.Yes.ToString() : logLevel1, // Log Level 1                    
                        logLevel2 == string.Empty ? FYesNo.No.ToString() : logLevel2,  // Log Level 2
                        logLevel3 == string.Empty ? FYesNo.No.ToString() : logLevel3,  // Log Level 3
                        // --
                        logLevel4 == string.Empty ? FYesNo.No.ToString() : logLevel4,  // Log Level 4
                        logLevel5 == string.Empty ? FYesNo.No.ToString() : logLevel5,  // Log Level 5
                        logLevel6 == string.Empty ? FYesNo.No.ToString() : logLevel6,  // Log Level 6
                        // --
                        logLevel7 == string.Empty ? FYesNo.No.ToString() : logLevel7,  // Log Level 7
                        logLevel8 == string.Empty ? FYesNo.No.ToString() : logLevel8,  // Log Level 8
                        logLevel9 == string.Empty ? FYesNo.No.ToString() : logLevel9,  // Log Level 9
                        // --
                        logLevel10 == string.Empty ? FYesNo.No.ToString() : logLevel10,  // Log Level 10
                        string.Empty,            // Empty 1
                        string.Empty,            // Empty 2
                        };
                    grdLogLevel.setColumnValues(cellValues);
                }

                // --

                cell = grdEapDetail.getColumn("EAP");
                if (grdEapDetail.getColumn("Up/Down").Text == FUpDown.Down.ToString())
                {
                    cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    cell.Appearance.ForeColor = Color.Red;
                }

                // --

                FCommon.designGridCellForEapStep(grdEapDetail.getColumn("Step"));
                FCommon.designGridCellForEapNeedAction(grdEapDetail.getColumn("Need Action"));
                FCommon.designGridCellForEapNextNeedAction(grdEapDetail.getColumn("Next Need Action"));
                FCommon.designGridCellForEapUpDown(grdEapDetail.getColumn("Up/Down"));
                FCommon.designGridCellForEapStatus(grdEapDetail.getColumn("Status"));
                FCommon.designGridCellForEapPackage(grdEapDetail.getColumn("Package"));
                FCommon.designGridCellForEapModel(grdEapDetail.getColumn("Model"));
                FCommon.designGridCellForEapComponent(grdEapDetail.getColumn("Component"));

                // --

                grdEapDetail.endUpdate();
                grdLogLevel.endUpdate();

                // --

                foreach (UltraGridRow r in grdEapDetail.Rows)
                {
                    for (int i = 0; i < r.Cells.Count; i += 2)
                    {
                        r.Cells[i + 1].ToolTipText = (string)r.Cells[i + 1].Value;
                    }
                }

                // --

                for (int i = 0; i < grdEapDetail.Rows.Count; i++)
                {
                    for (int j = 1; j <= grdEapDetail.Rows[i].Cells.Count; j += 2)
                    {
                        cell = grdEapDetail.Rows[i].Cells[j];
                        if (grdEapDetail.Rows[i].Cells[j].Value.ToString() == "N/A")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }
                    }

                }

                // --

                foreach (UltraGridRow r in grdConfig.Rows)
                {
                    r.Hidden = true;
                }

                if (eapType == FEapType.SECS.ToString())
                {
                    grdConfig.Rows[5].Cells[0].Value = "SECS Log";
                    grdConfig.Rows[8].Cells[0].Value = "SML Log";
                    // --
                    grdConfig.Rows[4].Hidden = false;
                    grdConfig.Rows[5].Hidden = false;
                    grdConfig.Rows[6].Hidden = false;
                    grdConfig.Rows[7].Hidden = false;
                    grdConfig.Rows[8].Hidden = false;
                }
                else if (eapType == FEapType.OPC.ToString())
                {
                    grdConfig.Rows[5].Cells[0].Value = "OPC Log";
                    // --
                    grdConfig.Rows[4].Hidden = false;
                    grdConfig.Rows[5].Hidden = false;
                    grdConfig.Rows[7].Hidden = false;
                }
                else if (eapType == FEapType.TCP.ToString())
                {
                    grdConfig.Rows[5].Cells[0].Value = "TCP Log";
                    grdConfig.Rows[8].Cells[0].Value = "XLG Log";
                    // --
                    grdConfig.Rows[4].Hidden = false;
                    grdConfig.Rows[5].Hidden = false;
                    grdConfig.Rows[6].Hidden = false;
                    grdConfig.Rows[7].Hidden = false;
                    grdConfig.Rows[8].Hidden = false;
                }
                else if (eapType == FEapType.FILE.ToString())
                {
                    grdConfig.Rows[5].Cells[0].Value = "File Log";
                    // --
                    grdConfig.Rows[0].Hidden = false;
                    grdConfig.Rows[1].Hidden = false;
                    grdConfig.Rows[2].Hidden = false;
                    grdConfig.Rows[3].Hidden = false;
                    grdConfig.Rows[4].Hidden = false;
                    grdConfig.Rows[5].Hidden = false;
                }
            }
            catch (Exception ex)
            {
                grdEapDetail.endUpdate();
                grdLogLevel.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
                row = null;
                cell = null;
                cellValues = null;
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
            string beforeKey = string.Empty;
            int keyIndex = 0;
            string eapType = string.Empty;

            try
            {
                beforeKey = tvwSchema.ActiveNode == null ? string.Empty : tvwSchema.ActiveNode.Key;
                // --
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
                eapType = fXmlNode.get_elemVal(FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.A_EapType, FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.D_EapType);

                // --

                // ***
                // SECS Device Load
                // ***
                foreach (FXmlNode fXmlNodeSdv in fXmlNode.get_elemList(FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.E_SecsDevice))
                {
                    tNodeSdv = new UltraTreeNode(keyIndex.ToString(), FCommon.getEapSchemaObjectText(fXmlNodeSdv));
                    tNodeSdv.Override.NodeAppearance.Image = FCommon.getImageOfEapSchemaSecsDevice(tvwSchema, fXmlNodeSdv);
                    tNodeSdv.Tag = fXmlNodeSdv;
                    keyIndex++;

                    // --

                    // ***
                    // SECS Session Load
                    // ***
                    foreach (FXmlNode fXmlNodeSsn in fXmlNodeSdv.get_elemList(FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.E_SecsSession))
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
                foreach (FXmlNode fXmlNodeHdv in fXmlNode.get_elemList(FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.E_HostDevice))
                {
                    tNodeHdv = new UltraTreeNode(keyIndex.ToString(), FCommon.getEapSchemaObjectText(fXmlNodeHdv));
                    tNodeHdv.Override.NodeAppearance.Image = FCommon.getImageOfEapSchemaHostDevice(tvwSchema, fXmlNodeHdv);
                    tNodeHdv.Tag = fXmlNodeHdv;
                    keyIndex++;

                    // --

                    // ***
                    // Host Session Load
                    // *** 
                    foreach (FXmlNode fXmlNodeHsn in fXmlNodeHdv.get_elemList(FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.E_HostSession))
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
                foreach (FXmlNode fXmlNodeEqp in fXmlNode.get_elemList(FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.E_Equipment))
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
                    if (beforeKey != string.Empty)
                    {
                        tvwSchema.ActiveNode = tvwSchema.GetNodeByKey(beforeKey);
                    }
                    if (beforeKey == string.Empty || tvwSchema.ActiveNode == null)
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

        private void refreshTreeOfEapEnvironment(
            FXmlNode fXmlNode
            )
        {
            UltraTreeNode tNodeScd = null;
            UltraTreeNode tNodeEnl = null;
            UltraTreeNode tNodeEnv = null;
            string beforeKey = string.Empty;
            int keyIndex = 0;

            try
            {
                beforeKey = tvwEnv.ActiveNode == null ? string.Empty : tvwEnv.ActiveNode.Key;
                // --
                tvwEnv.beginUpdate();
                tvwEnv.Nodes.Clear();
                pgdEnv.selectedObject = null;
                // --
                if (fXmlNode == null)
                {
                    tvwEnv.endUpdate();
                    return;
                }

                // --

                // ***
                // SECS Driver Load
                // ***
                tNodeScd = new UltraTreeNode(keyIndex.ToString(), FCommon.getEapSchemaObjectText(fXmlNode));
                tNodeScd.Override.NodeAppearance.Image = FCommon.getImageOfEapDriver(tvwEnv, fXmlNode); 
                tNodeScd.Tag = fXmlNode;
                keyIndex++;

                // --

                // ***
                // Environment List Load
                // ***
                foreach (FXmlNode fXmlNodeEnl in fXmlNode.get_elemList(FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.E_EnvironmentList))
                {
                    tNodeEnl = new UltraTreeNode(keyIndex.ToString(), FCommon.getEapSchemaObjectText(fXmlNodeEnl));
                    tNodeEnl.Override.NodeAppearance.Image = tvwEnv.ImageList.Images["EnvironmentList"];
                    tNodeEnl.Tag = fXmlNodeEnl;
                    keyIndex++;

                    // --

                    // ***
                    // Environment Load
                    // ***
                    foreach (FXmlNode fXmlNodeEnv in fXmlNodeEnl.get_elemList(FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.E_Environment))
                    {
                        tNodeEnv = new UltraTreeNode(keyIndex.ToString(), FCommon.getEapSchemaObjectText(fXmlNodeEnv));
                        tNodeEnv.Override.NodeAppearance.Image = FCommon.getImageOfEapSchemaEnvironment(tvwEnv, fXmlNodeEnv);
                        tNodeEnv.Tag = fXmlNodeEnv;
                        keyIndex++;
                        // --
                        tNodeEnl.Nodes.Add(tNodeEnv);
                    }

                    // --

                    tNodeScd.Nodes.Add(tNodeEnl);
                }

                // --

                tNodeScd.Expanded = true;
                tvwEnv.Nodes.Add(tNodeScd);
                tvwEnv.endUpdate();

                // --

                if (tvwEnv.Nodes.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        tvwEnv.ActiveNode = tvwEnv.GetNodeByKey(beforeKey);
                    }
                    if (beforeKey == string.Empty || tvwEnv.ActiveNode == null)
                    {
                        tvwEnv.ActiveNode = tvwEnv.Nodes[0];
                    }
                }
            }
            catch (Exception ex)
            {
                tvwEnv.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeScd = null;
                tNodeEnl = null;
                tNodeEnv = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void refreshGridOfEapConfig(
            FXmlNode fXmlNode
            )
        {
            FXmlNode fXmlNodeCfg = null;
            object[] cellValues = null;
            string language = string.Empty;
            string userId = string.Empty;
            string debugLogKeepingPeriod = string.Empty;
            string binaryLogEnabled = string.Empty;
            string maxBinaryLogFileSize = string.Empty;
            string smlLogEnabled = string.Empty;
            string maxSmlLogEnabled = string.Empty;
            string vfeiLogEnabled = string.Empty;
            string maxVfeiLogFileSize = string.Empty;
            string secsLogEnabled = string.Empty;
            string maxSecsLogFileSize = string.Empty;
            string fileNetworkPath = string.Empty;
            string fileUser = string.Empty;
            string filePassword = string.Empty;
            string fileSearchPattern = string.Empty;
            string fileSearchPeriod = string.Empty;
            string fileBackupPath = string.Empty;
            string fileBackupUser = string.Empty;
            string fileBackupPassword = string.Empty;
            string fileErrorPath = string.Empty;
            string fileErrorUser = string.Empty;
            string fileErrorPassword = string.Empty;

            try
            {
                grdConfig.beginUpdate();
                grdConfig.clearColumnValue();
                // --
                if (fXmlNode == null)
                {
                    grdConfig.endUpdate();
                    return;
                }

                // --

                fXmlNodeCfg = fXmlNode.get_elem(FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.E_EapConfig);
                if (fXmlNodeCfg == null)
                {
                    grdConfig.endUpdate();
                    return;
                }

                // --

                language = fXmlNodeCfg.get_elemVal(FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.A_Language, FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.D_Language);
                userId = fXmlNodeCfg.get_elemVal(FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.A_UserId, FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.D_UserId);
                debugLogKeepingPeriod = fXmlNodeCfg.get_elemVal(FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.A_DebugLogKeepingPeriod, FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.D_DebugLogKeepingPeriod);
                secsLogEnabled = fXmlNodeCfg.get_elemVal(FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.A_SecsLogEnabled, FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.D_SecsLogEnabled);
                maxSecsLogFileSize = fXmlNodeCfg.get_elemVal(FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.A_MaxSecsLogFileSize, FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.D_MaxSecsLogFileSize);
                binaryLogEnabled = fXmlNodeCfg.get_elemVal(FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.A_BinaryLogEnabled, FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.D_BinaryLogEnabled);
                maxBinaryLogFileSize = fXmlNodeCfg.get_elemVal(FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.A_MaxBinaryLogFileSize, FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.D_MaxBinaryLogFileSize);
                vfeiLogEnabled = fXmlNodeCfg.get_elemVal(FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.A_VfeiLogEnabled, FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.D_VfeiLogEnabled);
                maxVfeiLogFileSize = fXmlNodeCfg.get_elemVal(FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.A_MaxVfeiLogFileSize, FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.D_MaxVfeiLogFileSize);
                smlLogEnabled = fXmlNodeCfg.get_elemVal(FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.A_SmlLogEnabled, FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.D_SmlLogEnabled);
                maxSmlLogEnabled = fXmlNodeCfg.get_elemVal(FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.A_MaxSmlLogFileSize, FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.D_MaxSmlLogFileSize);
                // --
                fileNetworkPath = fXmlNodeCfg.get_elemVal(FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.A_FileNetworkPath, FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.D_FileNetworkPath);
                fileUser = fXmlNodeCfg.get_elemVal(FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.A_FileUser, FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.D_FileUser);
                filePassword = fXmlNodeCfg.get_elemVal(FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.A_FilePassword, FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.D_FilePassword);
                fileSearchPattern = fXmlNodeCfg.get_elemVal(FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.A_FileSearchPattern, FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.D_FileSearchPattern);
                fileSearchPeriod = fXmlNodeCfg.get_elemVal(FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.A_FileSearchPeriod, FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.D_FileSearchPeriod);
                fileBackupPath = fXmlNodeCfg.get_elemVal(FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.A_FileBackUpPath, FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.D_FileBackUpPath);
                fileBackupUser = fXmlNodeCfg.get_elemVal(FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.A_FileBackUpUser, FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.D_FileBackUpUser);
                fileBackupPassword = fXmlNodeCfg.get_elemVal(FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.A_FileBackUpPassword, FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.D_FileBackUpPassword);
                fileErrorPath = fXmlNodeCfg.get_elemVal(FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.A_FileErrorPath, FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.D_FileErrorPath);
                fileErrorUser = fXmlNodeCfg.get_elemVal(FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.A_FileErrorUser, FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.D_FileErrorUser);
                fileErrorPassword = fXmlNodeCfg.get_elemVal(FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.A_FileErrorPassword, FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEapConfig.D_FileErrorPassword);

                // --

                cellValues = new object[] {
                    fileNetworkPath,
                    fileUser,
                    filePassword,
                    // --
                    fileBackupPath,
                    fileBackupUser,
                    fileBackupPassword,
                    // --
                    fileErrorPath,
                    fileErrorUser,
                    fileErrorPassword,
                    // --
                    fileSearchPattern,
                    fileSearchPeriod + " sec",
                    string.Empty,
                    // --
                    language,                                                                   // Language
                    userId,                                                                     // User ID
                    debugLogKeepingPeriod + " Day",                                             // Debug Log Keeping Period
                    // --
                    secsLogEnabled,                                                             // SECS or PLC Log Enabled                    
                    string.Format("{0:#,#} MB", int.Parse(maxSecsLogFileSize) / 1024 / 1024),   // Max SECS Log File Size (MB)
                    string.Format("{0:#,#} Byte", int.Parse(maxSecsLogFileSize)),               // Max SECS Log File Size (Byte)
                    // --
                    binaryLogEnabled,                                                           // Binary Log Enabled
                    string.Format("{0:#,#} MB", int.Parse(maxBinaryLogFileSize) / 1024 / 1024), // Max Binary Log File Size (MB)
                    string.Format("{0:#,#} Byte", int.Parse(maxBinaryLogFileSize)),             // Max Binary Log File Size (Byte)                    
                    // --
                    vfeiLogEnabled,                                                             // VFEI Log Enabled
                    string.Format("{0:#,#} MB", int.Parse(maxVfeiLogFileSize) / 1024 / 1024),   // Max VFEI Log File Size (MB)
                    string.Format("{0:#,#} Byte", int.Parse(maxVfeiLogFileSize)),               // Max VFEI Log File Size (Byte)
                    // --
                    smlLogEnabled,                                                              // SML Log Enabled                    
                    string.Format("{0:#,#} MB", int.Parse(maxSmlLogEnabled)/ 1024 / 1024),      // Max SML Log FIle Size (MB)
                    string.Format("{0:#,#} Byte", int.Parse(maxSmlLogEnabled))                  // Max Binary Log File Size (Byte)                    
                    };
                grdConfig.setColumnValues(cellValues);

                // --

                if (fileBackupPath.Trim() == string.Empty)
                {
                    grdConfig.Rows[1].Hidden = true;
                }
                // --
                if (fileErrorPath.Trim() == string.Empty)
                {
                    grdConfig.Rows[2].Hidden = true;
                }

                // --

                grdConfig.endUpdate();

                // --

                foreach (UltraGridRow r in grdConfig.Rows)
                {
                    for (int i = 0; i < r.Cells.Count; i += 2)
                    {
                        r.Cells[i + 1].ToolTipText = (string)r.Cells[i + 1].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                grdConfig.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeCfg = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshEapSchema(
            )
        {
            FXmlNode fXmlNode = null;
            string eapType = string.Empty;

            try
            {
                fXmlNode = FCommon.refreshEapSchema(m_fAdmCore, this.activeEap, ucbCategory.Text);
                if (fXmlNode != null)
                {
                    eapType = fXmlNode.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.A_EapType,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.D_EapType
                        );
                }

                // --

                if (eapType == FEapType.FILE.ToString())
                {
                    refreshTreeOfEapSchema(fXmlNode);
                    refreshTreeOfEapEnvironment(null);
                }
                else
                {
                    refreshTreeOfEapSchema(fXmlNode);
                    refreshTreeOfEapEnvironment(fXmlNode);
                }
                refreshGridOfEapConfig(fXmlNode);
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

        private void refresh(
            )
        {
            try
            {
                clearGridOfEapDetail();

                // --

                refreshGridOfEquipmentDetail();
                refreshGridOfEapDetail();
                refreshEapSchema();

                // --

                grdDetail.Focus();
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

        private void export(
            )
        {
            SaveFileDialog sfd = null;
            string fileName = string.Empty;
            FExcelExporter2 fExcelExp = null;
            FExcelSheet fExcelSht = null;
            int rowIndex = 0;

            try
            {
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_EquipmentStatus_" + txtEqpName.Text + ".xlsx";

                // --

                sfd = new SaveFileDialog();
                // --                
                sfd.Title = "Export Equipment Status to Excel";
                sfd.Filter = "Excel Files | *.xlsx";
                sfd.DefaultExt = "xlsx";
                sfd.InitialDirectory = m_fAdmCore.fOption.recentExportPath;
                sfd.FileName = fileName;
                // --
                if (sfd.ShowDialog(m_fAdmCore.fWsmCore.fWsmContainer) == DialogResult.Cancel)
                {
                    return;
                }

                // --

                fileName = sfd.FileName;

                // --

                fExcelExp = new FExcelExporter2(fileName, m_fAdmCore.fUIWizard.fontName, 9);
                fExcelSht = fExcelExp.addExcelSheet("Equipment Status");

                // --

                // ***
                // Title write
                // ***
                rowIndex = 0;
                fExcelSht.writeTitle(this.Text, rowIndex, 0);                

                // --

                // ***
                // Input Condition (입력 조건) Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Input Condition") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                fExcelSht.writeCondition(lblEqpName.Text, txtEqpName.Text, rowIndex, 0);

                // --

                // ***
                // Equipment Detail Grid Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Equipment Detail") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;                
                rowIndex = fExcelSht.writeDetailViewGrid(grdDetail, rowIndex, 0);

                // --

                // ***
                // Category Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Category") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                fExcelSht.writeCondition(lblCategory.Text, ucbCategory.Text, rowIndex, 0);

                // --

                // ***
                // EAP Detail Grid Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("EAP Detail") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                rowIndex = fExcelSht.writeDetailViewGrid(grdEapDetail, rowIndex, 0);

                // --

                // ***
                // EAP Schema Tree Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("EAP Schema") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;                
                fExcelSht.writeTreeView(tvwSchema, rowIndex, 0, rowIndex + 12, 6);

                // --

                // ***
                // Environment Tree Write
                // ***
                rowIndex += 13;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Environment") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                fExcelSht.writeTreeView(tvwEnv, rowIndex, 0, rowIndex + 12, 6);

                // --

                // ***
                // Configuration Detail Grid Wirte
                // ***
                rowIndex += 13;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Configuration") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                rowIndex = fExcelSht.writeDetailViewGrid(grdConfig, rowIndex, 0);

                // --

                // ***
                // Log Level Grid Wirte
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Log Level") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                rowIndex = fExcelSht.writeDetailViewGrid(grdLogLevel, rowIndex, 0);

                // --

                // ***
                // Create Time Write
                // ***
                rowIndex += 2;
                // --
                fExcelSht.writeText("Create Time: " + FDataConvert.defaultNowDateTimeToString(), rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);

                // --

                fExcelExp.save();

                // --

                // ***
                // Last Excel Export Path 저장
                // ***
                m_fAdmCore.fOption.recentExportPath = Path.GetDirectoryName(fileName);

                // --

                // ***
                // Excel Open
                // ***
                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0012"),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                Process.Start(fileName);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fExcelExp != null)
                {
                    fExcelExp.Dispose();
                    fExcelExp = null;
                }

                if (fExcelSht != null)
                {
                    fExcelSht.Dispose();
                    fExcelSht = null;
                }

                sfd = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadLogLevelCatpion(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;

            try
            {
                m_logLevelCaption = new string[10];

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "EquipmentStatus", "SearchFactory", fSqlParams, true);

                // --

                for (int i = 0; i < 10; i++)
                {
                    m_logLevelCaption[i] = dt.Rows[0][i].ToString();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        #region MC Popup Menu

        public void procMenuEquipmentEventDefineRequest(
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
                fEquipmentEventDefineRequest.attach(this.selectedEqs, this.activeEap);
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

        public void procMenuEquipmentVersionRequest(
            )
        {
            FEquipmentVersionRequest fEquipmentVersionRequest = null;

            try
            {
                fEquipmentVersionRequest = (FEquipmentVersionRequest)m_fAdmCore.fAdmContainer.getChild(typeof(FEquipmentVersionRequest));
                if (fEquipmentVersionRequest == null)
                {
                    fEquipmentVersionRequest = new FEquipmentVersionRequest(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEquipmentVersionRequest);
                }
                fEquipmentVersionRequest.activate();
                fEquipmentVersionRequest.attach(this.selectedEqs, this.activeEap);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEquipmentVersionRequest = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void procMenuEquipmentControlModeRequest(
            )
        {
            FEquipmentControlModeRequest fEquipmentControlModeRequest = null;

            try
            {
                fEquipmentControlModeRequest = (FEquipmentControlModeRequest)m_fAdmCore.fAdmContainer.getChild(typeof(FEquipmentControlModeRequest));
                if (fEquipmentControlModeRequest == null)
                {
                    fEquipmentControlModeRequest = new FEquipmentControlModeRequest(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEquipmentControlModeRequest);
                }
                fEquipmentControlModeRequest.activate();
                fEquipmentControlModeRequest.attach(this.selectedEqs, this.activeEap);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEquipmentControlModeRequest = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void procMenuCustomRemoteCommandRequest(
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
                fCustomRemoteCommandRequest.attach(this.selectedEqs, this.activeEap);
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

        private void procMenuEquipmentHistory(
            )
        {
            FEquipmentHistory fEquipmentHistory = null;

            try
            {
                fEquipmentHistory = (FEquipmentHistory)m_fAdmCore.fAdmContainer.getChild(typeof(FEquipmentHistory));
                if (fEquipmentHistory == null)
                {
                    fEquipmentHistory = new FEquipmentHistory(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEquipmentHistory);
                }
                fEquipmentHistory.activate();
                fEquipmentHistory.attach(activeEq);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEquipmentHistory = null;
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
                fEquipmentGemStatus.attach(activeEq);
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

        private void procMenuRemotePingTestByEquipment(
            )
        {
            FRemotePingTestByEquipment fRemotePingTest = null;
            List<FStructureEquipment> fEquipmentList = null;
            FXmlNode fXmlNode = null;
            // --
            string eqpName = string.Empty;
            string eqpDesc = string.Empty;
            string eqpIpAddress = string.Empty;

            try
            {
                // --

                fXmlNode = (FXmlNode)tvwSchema.ActiveNode.Tag;
                if (fXmlNode.name != FADMADS_TolEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.E_Equipment)
                {
                    return;
                }

                // --

                fRemotePingTest = (FRemotePingTestByEquipment)m_fAdmCore.fAdmContainer.getChild(typeof(FRemotePingTestByEquipment));
                if (fRemotePingTest == null)
                {
                    fRemotePingTest = new FRemotePingTestByEquipment(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fRemotePingTest);
                }
                fRemotePingTest.activate();

                // --

                fEquipmentList = new List<FStructureEquipment>();

                // --

                eqpName = fXmlNode.get_elemVal(
                    FADMADS_TolEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.A_Name,
                    FADMADS_TolEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.D_Name
                    );
                eqpDesc = fXmlNode.get_elemVal(
                    FADMADS_TolEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.A_Description,
                    FADMADS_TolEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.D_Description
                    );
                eqpIpAddress = fXmlNode.get_elemVal(
                    FADMADS_TolEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.A_IpAddress,
                    FADMADS_TolEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.D_IpAddress
                    );

                fEquipmentList.Add(
                    new FStructureEquipment(
                        eqpName,
                        this.activeEap,
                        eqpDesc,
                        eqpIpAddress
                        )
                    );

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
                fXmlNode = null;
            }
        }


        #endregion

        //------------------------------------------------------------------------------------------------------------------------        

        public void attach(
            string eqpName,
            string category
            )
        {
            try
            {
                refreshComboOfCategory();

                // --

                txtEqpName.Text = eqpName;
                ucbCategory.Text = category;

                // --

                refresh();

                // --

                txtEqpName.Focus();
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

        #region FEquipmentStatus Form Event Handler

        private void FEquipmentStatus_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                loadLogLevelCatpion();

                // --

                designGridOfEquipmentDetail();
                // --
                designComboOfCategory();
                designGridOfEapDetail();
                designTreeOfEapSchema();
                designTreeOfEapEnvironment();
                designGridOfEapConfig();
                designGridOfLogLevel();

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

        private void FEquipmentStatus_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshComboOfCategory();

                // --

                txtEqpName.Focus();
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

        private void FEquipmentStatus_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fAdmCore.fOption.fChildFormList.remove(this);

                // --

                pgdSchema.selectedObject = null;
                pgdEnv.selectedObject = null;                
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

        private void FEquipmentStatus_KeyDown(
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
                    refresh();
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

                if (e.Tool.Key == FMenuKey.MenuEqsRefresh)
                {
                    refresh();
                }
                else if (e.Tool.Key == FMenuKey.MenuEqsExport)
                {
                    export();
                }

                // --

                else if (e.Tool.Key == FMenuKey.MenuInqEqpEventDefineRequest)
                {
                    procMenuEquipmentEventDefineRequest();
                }
                else if (e.Tool.Key == FMenuKey.MenuInqEqpVersionRequest)
                {
                    procMenuEquipmentVersionRequest();
                }
                else if (e.Tool.Key == FMenuKey.MenuInqEqpControlModeRequest)
                {
                    procMenuEquipmentControlModeRequest();
                }
                else if (e.Tool.Key == FMenuKey.MenuInqEqpCustomRemoteCommandRequest)
                {
                    procMenuCustomRemoteCommandRequest();
                }
                else if (e.Tool.Key == FMenuKey.MenuInqEqpHistory)
                {
                    procMenuEquipmentHistory();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuInqEqpGemStatus)
                {
                    procMenuEquipmentGemStatus();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuInqEqpRemotePingTest)
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

        #region txtEqpName Control Event Handler

        private void txtEqpName_EditorButtonClick(
            object sender,
            EditorButtonEventArgs e
            )
        {
            FEquipmentSelector fDialog = null;

            try
            {
                FCursor.waitCursor();

                // --

                fDialog = new FEquipmentSelector(m_fAdmCore, txtEqpName.Text, "N");
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                txtEqpName.Text = fDialog.selectedEqpName;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                if (fDialog != null)
                {
                    fDialog.Dispose();
                    fDialog = null;
                }

                // --

                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void txtEqpName_ValueChanged(
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

        #region ucbCategory Control Event Handler
        
        private void ucbCategory_ValueChanged(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfEapDetail();
                refreshEapSchema();
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

                mnuMenu.Tools[FMenuKey.MenuInqEqpEventDefineRequest].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentEventDefineRequest);
                mnuMenu.Tools[FMenuKey.MenuInqEqpVersionRequest].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentVersionRequest);
                mnuMenu.Tools[FMenuKey.MenuInqEqpControlModeRequest].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentControlModeRequest);
                mnuMenu.Tools[FMenuKey.MenuInqEqpHistory].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentHistory);
                // --
                mnuMenu.Tools[FMenuKey.MenuInqEqpGemStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentGemStatus);
                // --
                mnuMenu.Tools[FMenuKey.MenuInqEqpCustomRemoteCommandRequest].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.CustomRemoteCommandRequest);
                // --
                mnuMenu.Tools[FMenuKey.MenuInqEqpRemotePingTest].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.RemotePingTestByEquipment);

                // --

                mnuMenu.ShowPopup(FMenuKey.MenuInqEqpPopupMenu);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region tvwEnv Control Event Handler

        private void tvwEnv_AfterActivate(
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

                FCommon.setPropertyOfEapSchemaObject(m_fAdmCore, pgdEnv, (FXmlNode)e.TreeNode.Tag);
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
