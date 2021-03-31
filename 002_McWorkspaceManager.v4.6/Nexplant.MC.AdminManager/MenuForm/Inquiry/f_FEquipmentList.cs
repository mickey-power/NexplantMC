/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FEquipmentList.cs
--  Creator         : hsshim
--  Create Date     : 2013.02.08
--  Description     : FAMate Admin Manager Equipment List Form Class 
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
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinTree;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public partial class FEquipmentList : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private string[] m_logLevelCaption = null;
 
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEquipmentList(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEquipmentList(
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
                    if (grdEqp.activeDataRow == null)
                    {
                        return string.Empty;
                    }

                    // --

                    return (string)grdEqp.activeDataRow["EAP"];
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
                string eqpName = string.Empty;

                try
                {
                    if (tabMain.ActiveTab.Key == "Equipment")
                    {
                        eqpName = grdEqp.activeDataRowKey;
                    }
                    else
                    {
                        if (tvwSchema.ActiveNode != null)
                        {
                            n = (FXmlNode)tvwSchema.ActiveNode.Tag;
                            eqpName = n.get_elemVal(
                                FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.A_Name,
                                FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.D_Name
                                );
                        }
                    }
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    n = null;
                }
                return eqpName;
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
                uds.Band.Columns.Add("IP Address");
                uds.Band.Columns.Add("Equipment Type");
                uds.Band.Columns.Add("Equipment Area");
                uds.Band.Columns.Add("Equipment Line");
                uds.Band.Columns.Add("Control Mode");
                uds.Band.Columns.Add("Primary State");
                uds.Band.Columns.Add("State");
                uds.Band.Columns.Add("MDLN");
                uds.Band.Columns.Add("Soft Rev.");
                uds.Band.Columns.Add("Event Define");
                uds.Band.Columns.Add("RPM Count");
                uds.Band.Columns.Add("EAP Type");
                uds.Band.Columns.Add("Operation Mode");
                uds.Band.Columns.Add("Server");
                uds.Band.Columns.Add("Step");
                uds.Band.Columns.Add("Up/Down");
                uds.Band.Columns.Add("Status");
                uds.Band.Columns.Add("Reload Count");
                uds.Band.Columns.Add("Package");
                uds.Band.Columns.Add("Model");
                uds.Band.Columns.Add("Component");
                uds.Band.Columns.Add("Need Action");
                uds.Band.Columns.Add("Next Need Action");
                uds.Band.Columns.Add("Last Event Time");
                uds.Band.Columns.Add("Last Event ID");
                uds.Band.Columns.Add("Create User ID");
                uds.Band.Columns.Add("Create Time");
                uds.Band.Columns.Add("Update User ID");
                uds.Band.Columns.Add("Update Time");

                // --

                grdEqp.DisplayLayout.Bands[0].Columns["Equipment"].CellAppearance.Image = Properties.Resources.Equipment;

                //--

                grdEqp.DisplayLayout.Bands[0].Columns["RPM Count"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdEqp.DisplayLayout.Bands[0].Columns["Reload Count"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdEqp.DisplayLayout.Bands[0].Columns["Last Event Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdEqp.DisplayLayout.Bands[0].Columns["Create Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdEqp.DisplayLayout.Bands[0].Columns["Update Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

                // -- 

                grdEqp.DisplayLayout.Bands[0].Columns["Equipment"].Header.Fixed = true;
                grdEqp.DisplayLayout.Bands[0].Columns["Description"].Header.Fixed = true;
                grdEqp.DisplayLayout.Bands[0].Columns["EAP"].Header.Fixed = true;

                // --

                grdEqp.DisplayLayout.Bands[0].Columns["Equipment"].Width = 100;
                grdEqp.DisplayLayout.Bands[0].Columns["Description"].Width = 165;
                grdEqp.DisplayLayout.Bands[0].Columns["EAP"].Width = 100;
                grdEqp.DisplayLayout.Bands[0].Columns["IP Address"].Width = 100;
                grdEqp.DisplayLayout.Bands[0].Columns["Equipment Type"].Width = 120;
                grdEqp.DisplayLayout.Bands[0].Columns["Equipment Area"].Width = 120;
                grdEqp.DisplayLayout.Bands[0].Columns["Equipment Line"].Width = 120;
                grdEqp.DisplayLayout.Bands[0].Columns["Control Mode"].Width = 90;
                grdEqp.DisplayLayout.Bands[0].Columns["Primary State"].Width = 90;
                grdEqp.DisplayLayout.Bands[0].Columns["State"].Width = 90;
                grdEqp.DisplayLayout.Bands[0].Columns["MDLN"].Width = 120;
                grdEqp.DisplayLayout.Bands[0].Columns["Soft Rev."].Width = 120;
                grdEqp.DisplayLayout.Bands[0].Columns["RPM Count"].Width = 70;
                grdEqp.DisplayLayout.Bands[0].Columns["EAP Type"].Width = 80;
                grdEqp.DisplayLayout.Bands[0].Columns["Operation Mode"].Width = 110;
                grdEqp.DisplayLayout.Bands[0].Columns["Server"].Width = 100;
                grdEqp.DisplayLayout.Bands[0].Columns["Step"].Width = 120;
                grdEqp.DisplayLayout.Bands[0].Columns["Up/Down"].Width = 80;
                grdEqp.DisplayLayout.Bands[0].Columns["Status"].Width = 80;
                grdEqp.DisplayLayout.Bands[0].Columns["Reload Count"].Width = 80;
                grdEqp.DisplayLayout.Bands[0].Columns["Package"].Width = 180;
                grdEqp.DisplayLayout.Bands[0].Columns["Model"].Width = 180;
                grdEqp.DisplayLayout.Bands[0].Columns["Component"].Width = 180;
                grdEqp.DisplayLayout.Bands[0].Columns["Need Action"].Width = 100;
                grdEqp.DisplayLayout.Bands[0].Columns["Next Need Action"].Width = 100;
                grdEqp.DisplayLayout.Bands[0].Columns["Last Event Time"].Width = 165;
                grdEqp.DisplayLayout.Bands[0].Columns["Last Event ID"].Width = 165;
                grdEqp.DisplayLayout.Bands[0].Columns["Create User ID"].Width = 100;
                grdEqp.DisplayLayout.Bands[0].Columns["Create Time"].Width = 165;
                grdEqp.DisplayLayout.Bands[0].Columns["Update User ID"].Width = 100;
                grdEqp.DisplayLayout.Bands[0].Columns["Update Time"].Width = 165;

                // --

                grdEqp.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
                grdEqp.DisplayLayout.Override.FilterUIProvider = this.grdFilter;
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

                grdEqpDetail.addColumns(3, columns);
                grdEqpDetail.setColumnHeaderWidth(120);
                // --
                grdEqpDetail.DisplayLayout.Override.TipStyleCell = TipStyle.Show;

                // --

                grdEqpDetail.Rows[4].Cells[4].Value = string.Empty;
                grdEqpDetail.Rows[5].Cells[4].Value = string.Empty;
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
                // EAP Config Clear
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
                // Equipment List Clear
                // ***
                grdEqp.beginUpdate();
                grdEqp.removeAllDataRow();
                grdEqp.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdEqp.endUpdate();

                // --

                refreshEquipmentTotal();

                // --

                // ***
                // Equipment Detail Information Clear
                // ***
                grdEqpDetail.beginUpdate();
                grdEqpDetail.clearColumnValue();
                grdEqpDetail.endUpdate();

                // --

                // ***
                // EAP Detail Information Clear
                // ***
                clearGridOfEapDetail();
            }
            catch (Exception ex)
            {
                grdEqp.endUpdate();
                grdEqpDetail.endUpdate();
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
            try
            {
                foreach (string s in Enum.GetNames(typeof(FEapAttrCategory)))
                {
                    ucbCategory.appendDataRow(s, new object[] { s });
                }

                // --

                ucbCategory.Text = FEapAttrCategory.Applied.ToString();
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

        private void refreshGridOfEquipment(
             )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            object[] cellValues = null;
            string key = string.Empty;
            string beforeKey = string.Empty;
            int nextRowNumber = 0;
            int index = 0;
            int tempIndex = 0;
            // --
            string eqpName = string.Empty;
            string eqpDesc = string.Empty;
            string type = string.Empty;
            string area = string.Empty;
            string line = string.Empty;
            string controlMode = string.Empty;
            string priState = string.Empty;
            string state = string.Empty;            
            string eap = string.Empty;
            string eqMdln = string.Empty;
            string eqSoftRev = string.Empty;
            string eqEventDefine = string.Empty;            
            string server = string.Empty;
            string step = string.Empty;
            string eapUpDown = string.Empty;
            string eapStatus = string.Empty;
            string reloadCount = string.Empty;
            string package = string.Empty;
            string model = string.Empty;
            string component = string.Empty;
            string needAction = string.Empty;
            string nextNeedAtion = string.Empty;
            string createTime = string.Empty;
            string createUserID = string.Empty;
            string updateTime = string.Empty;
            string updateUserID = string.Empty;
            string lastEventTime = string.Empty;
            string lastEventID = string.Empty;
            string eqpRecipe = string.Empty;
            // --
            string ipAddr = string.Empty;
            string rpmCnt = string.Empty;
            string eapType = string.Empty;
            string operMode = string.Empty;

            try
            {
                beforeKey = grdEqp.activeDataRowKey;
                // --
                grdEqp.beginUpdate(false);
                grdEqp.removeAllDataRow();
                grdEqp.DisplayLayout.Bands[0].SortedColumns.Clear();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("category", ucbCategory.activeDataRowKey, ucbCategory.activeDataRowKey == string.Empty ? true : false);
                fSqlParams.add("type", txtEqpType.Text, txtEqpType.Text == string.Empty ? true : false);
                fSqlParams.add("area", txtEqpArea.Text, txtEqpArea.Text == string.Empty ? true : false);
                fSqlParams.add("line", txtEqpLine.Text, txtEqpLine.Text == string.Empty ? true : false);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "EquipmentList", "ListEquipment", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        eqpName       = r[tempIndex++].ToString();
                        eqpDesc       = r[tempIndex++].ToString();
                        type          = r[tempIndex++].ToString();
                        area          = r[tempIndex++].ToString();
                        line          = r[tempIndex++].ToString();
                        controlMode   = r[tempIndex++].ToString();                        
                        priState      = r[tempIndex++].ToString();
                        state         = r[tempIndex++].ToString();                        
                        eap           = r[tempIndex++].ToString();
                        eqMdln        = r[tempIndex++].ToString();
                        eqSoftRev     = r[tempIndex++].ToString();
                        eqEventDefine = r[tempIndex++].ToString();
                        eqpRecipe     = r[tempIndex++].ToString();  
                        server        = r[tempIndex++].ToString();
                        step          = r[tempIndex++].ToString();
                        eapUpDown     = r[tempIndex++].ToString();
                        eapStatus     = r[tempIndex++].ToString();
                        reloadCount   = r[tempIndex++].ToString();
                        // --
                        package = FCommon.generateStringForPackage(r[tempIndex++].ToString(), r[tempIndex++].ToString());
                        model = FCommon.generateStringForModel(r[tempIndex++].ToString(), r[tempIndex++].ToString());
                        component = FCommon.generateStringForComponent(r[tempIndex++].ToString(), r[tempIndex++].ToString(), r[tempIndex++].ToString());
                        // --
                        needAction = r[tempIndex++].ToString();
                        nextNeedAtion = r[tempIndex++].ToString();
                        // --
                        createUserID = r[tempIndex++].ToString();
                        createTime = FDataConvert.defaultDataTimeFormating(r[tempIndex++].ToString());
                        updateUserID = r[tempIndex++].ToString();
                        updateTime = FDataConvert.defaultDataTimeFormating(r[tempIndex++].ToString());
                        lastEventID = r[tempIndex++].ToString();
                        lastEventTime = string.IsNullOrEmpty(r[tempIndex].ToString()) ? string.Empty : FDataConvert.defaultDataTimeFormating(r[tempIndex].ToString());
                        tempIndex++;
                        // --
                        ipAddr = r[tempIndex++].ToString();
                        rpmCnt = r[tempIndex++].ToString();
                        eapType = r[tempIndex++].ToString();
                        operMode = r[tempIndex++].ToString();
                        
                        // --

                        cellValues = new object[] {
                            eqpName,                                        // Equipment
                            eqpDesc,                                        // Euipment Description
                            string.IsNullOrWhiteSpace(eap) ? "N/A" : eap,   // EAP
                            ipAddr,                                         // IP Address (2017.06.07 by spike.lee add)
                            type,                                           // Type
                            area,                                           // Area
                            line,                                           // Line
                            controlMode ,                                   // Control Mode
                            priState,                                       // Primary State
                            state,                                          // State                        
                            eqMdln,                                         // Equipment Model Number
                            eqSoftRev,                                      // Equipment Soft Version
                            eqEventDefine,                                  // EVENT DEFINE   
                            string.IsNullOrWhiteSpace(rpmCnt)        ? "N/A" : rpmCnt,                 // RPM Count (2017.06.07 by spike.lee add)
                            string.IsNullOrWhiteSpace(eapType)       ? "N/A" : eapType,                // EAP Type (2017.06.07 by spike.lee add)
                            string.IsNullOrWhiteSpace(operMode)      ? "N/A" : operMode,               // Operation Mode (2017.06.07 by spike.lee add)
                            string.IsNullOrWhiteSpace(server)        ? "N/A" : server,                 // Server
                            string.IsNullOrWhiteSpace(step)          ? "N/A" : step,                   // Step
                            string.IsNullOrWhiteSpace(eapUpDown)     ? "N/A" : eapUpDown,              // Up/Down
                            string.IsNullOrWhiteSpace(eapStatus)     ? "N/A" : eapStatus,              // Status
                            string.IsNullOrWhiteSpace(reloadCount)   ? "N/A" : reloadCount,            // Reload Count   
                            string.IsNullOrWhiteSpace(package)       ? "N/A" : package,                // Package
                            string.IsNullOrWhiteSpace(model)         ? "N/A" : model,                  // Model
                            string.IsNullOrWhiteSpace(component)     ? "N/A" : component,              // Component
                            string.IsNullOrWhiteSpace(needAction)    ? "N/A" : needAction,             // Need Action
                            string.IsNullOrWhiteSpace(nextNeedAtion) ? "N/A" : nextNeedAtion,          // Next Need Action
                            lastEventTime,        // Last Event Time
                            lastEventID,          // Last Event ID
                            createUserID,         // Create User ID
                            createTime,           // Create Time
                            updateUserID,         // Update User ID
                            updateTime            // Update Time
                            };
                        // --
                        key = (string)cellValues[0];
                        index = grdEqp.appendDataRow(key, cellValues).Index;
                        grdEqp.Rows[index].Tag = r;

                        // --

                        tempIndex = 0;
                    }
                } while (nextRowNumber >= 0);

                // --

                grdEqp.endUpdate(false);

                // --

                if (grdEqp.Rows.Count != 0)
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

                refreshEquipmentTotal();
            }
            catch (Exception ex)
            {
                grdEqp.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
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
            string eqpDesc = string.Empty;
            string type = string.Empty;
            string area = string.Empty;
            string line = string.Empty;
            string controlMode = string.Empty;
            string priState = string.Empty;
            string state = string.Empty;            
            string eap = string.Empty;
            string eqMdln = string.Empty;
            string eqSoftRev = string.Empty;
            string eqEventDefine = string.Empty;
            string eapType = string.Empty;
            string eapDesc = string.Empty;
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
            string eqpRecipe = string.Empty;
            string ipAddr = string.Empty;
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
                grdEqpDetail.beginUpdate();
                grdEapDetail.beginUpdate();
                grdLogLevel.beginUpdate();
                grdEqpDetail.clearColumnValue();
                grdEapDetail.clearColumnValue();
                grdLogLevel.clearColumnValue();
                // --
                if (grdEqp.activeDataRow == null)
                {
                    grdEqpDetail.endUpdate();
                    grdEapDetail.endUpdate();
                    grdLogLevel.endUpdate();
                    return;
                }
                
                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("eqpName", grdEqp.activeDataRowKey);
                fSqlParams.add("category", ucbCategory.activeDataRowKey);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "EquipmentList", "SearchEquipment", fSqlParams, true);
                row = dt.Rows[0];

                // --

                eqpName = row[index++].ToString();
                eqpDesc = row[index++].ToString();
                type = row[index++].ToString();
                area = row[index++].ToString();
                line = row[index++].ToString();
                controlMode = row[index++].ToString();
                priState = row[index++].ToString();
                state = row[index++].ToString();                
                eqMdln = row[index++].ToString();
                eqSoftRev = row[index++].ToString();
                eqEventDefine = row[index++].ToString();
                eqpRecipe = row[index++].ToString();
                creator = row[index++] + " [" + FDataConvert.defaultDataTimeFormating(row[index++].ToString()) + "]";
                updater = row[index++] + " [" + FDataConvert.defaultDataTimeFormating(row[index++].ToString()) + "]";                
                lastEventTime = FDataConvert.defaultDataTimeFormating(row[index++].ToString());
                lastEventID = row[index++].ToString();

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

                // --

                ipAddr = row[index++].ToString();
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
                    eqpName,                        // Equipment
                    eqpDesc,                        // Equipment Description
                    ipAddr,                         // IP Address (2017.06.07 by spiek.lee add)
                    // --
                    type,                           // Type
                    area,                           // Area
                    line,                           // Line                    
                    // --
                    controlMode,                                              // Control Mode
                    string.IsNullOrWhiteSpace(priState)  ? "N/A" : priState,  // Primary State
                    string.IsNullOrWhiteSpace(state)     ? "N/A" : state,     // State
                    // --
                    string.IsNullOrWhiteSpace(eqMdln)    ? "N/A" : eqMdln,            // Equipment Model Number
                    string.IsNullOrWhiteSpace(eqSoftRev) ? "N/A" : eqSoftRev,         // Equipment Soft Version
                    string.IsNullOrWhiteSpace(eqEventDefine) ? "N/A" : eqEventDefine, // Event Define Result
                    // --                                        
                    creator,
                    updater,
                    string.Empty,
                    // --
                    lastEventTime,
                    lastEventID,
                    string.Empty
                    };
                grdEqpDetail.setColumnValues(cellValues);

                // --

                FCommon.designGridCellForControlMode(grdEqpDetail.getColumn("Control Mode"));
                FCommon.designGridCellForNotApplicable(grdEqpDetail.getColumn("Primary State"));
                FCommon.designGridCellForNotApplicable(grdEqpDetail.getColumn("State"));
                FCommon.designGridCellForNotApplicable(grdEqpDetail.getColumn("MDLN"));
                FCommon.designGridCellForNotApplicable(grdEqpDetail.getColumn("Soft Rev."));
                FCommon.designGridCellForNotApplicable(grdEqpDetail.getColumn("Event Define"));
                                
                // --

                if (eap != string.Empty)
                {
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

                grdEapDetail.endUpdate();
                grdEqpDetail.endUpdate();
                grdLogLevel.endUpdate();

                // --

                foreach (UltraGridRow r in grdEqpDetail.Rows)
                {
                    for (int i = 0; i < r.Cells.Count; i += 2)
                    {
                        r.Cells[i + 1].ToolTipText = (string)r.Cells[i + 1].Value;
                    }
                }

                // --

                foreach (UltraGridRow r in grdEapDetail.Rows)
                {
                    for (int i = 0; i < r.Cells.Count; i += 2)
                    {
                        r.Cells[i + 1].ToolTipText = (string)r.Cells[i + 1].Value;
                    }
                }

                // --

                foreach (UltraGridRow r in grdConfig.Rows)
                {
                    r.Hidden = true;
                }

                // --

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
                //else if (this.activeType == FEapType.PLC.ToString())
                //{
                //    grdConfig.Rows[3].Cells[0].Value = "PLC Log";
                //    // --
                //    grdConfig.Rows[2].Hidden = false;
                //    grdConfig.Rows[3].Hidden = false;
                //    grdConfig.Rows[4].Hidden = false;
                //    grdConfig.Rows[5].Hidden = false;
                //}
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
                grdEqpDetail.endUpdate();
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
                if (tabMain.ActiveTab.Key == "Equipment")
                {
                    refreshGridOfEquipment();
                    grdEqp.Focus();
                }
                else 
                {
                    refreshGridOfEapDetail();
                    refreshEapSchema();
                    grdEqpDetail.Focus();
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

        private void refreshEquipmentTotal(
            )
        {
            try
            {
                lblEquipmentTotal.Text = grdEqp.Rows.VisibleRowCount.ToString("#,##0") + " / " + grdEqp.Rows.Count.ToString("#,##0");
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

        private void exportGridOfEquipment(
            )
        {
            SaveFileDialog sfd = null;
            string fileName = string.Empty;
            FExcelExporter2 fExcelExp = null;
            FExcelSheet fExcelSht = null;
            int rowIndex = 0;

            try
            {
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_EquipmentList.xlsx";

                // --

                sfd = new SaveFileDialog();
                // --
                sfd.Title = "Export Equipment List to Excel";
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
                fExcelSht = fExcelExp.addExcelSheet("Equipment List");

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
                fExcelSht.writeCondition(lblEqpType.Text, txtEqpType.Text, rowIndex, 0);
                fExcelSht.writeCondition(lblEqpArea.Text, txtEqpArea.Text, rowIndex, 2);
                fExcelSht.writeCondition(lblEqpLine.Text, txtEqpLine.Text, rowIndex, 4);
                // --
                rowIndex += 1;
                fExcelSht.writeCondition(lblCategory.Text, ucbCategory.Text, rowIndex, 0);

                // --

                // ***
                // Equipment List Grid Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Equipment List") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                rowIndex = fExcelSht.writeGrid(grdEqp, rowIndex, 0);
                // --
                rowIndex += 1;
                fExcelSht.writeText("Total Count: " + grdEqp.Rows.Count.ToString(), rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);

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

        private void exportGridOfEquipmentDetail(
            )
        {
            SaveFileDialog sfd = null;
            string fileName = string.Empty;
            FExcelExporter2 fExcelExp = null;
            FExcelSheet fExcelSht = null;
            int rowIndex = 0;

            try
            {
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_EquipmentList_" + tabMain.ActiveTab.Text + ".xlsx";

                // --

                sfd = new SaveFileDialog();
                // --                
                sfd.Title = "Export Equipment List to Excel";
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
                fExcelSht = fExcelExp.addExcelSheet("Equipment List");

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
                fExcelSht.writeCondition(lblEqpType.Text, txtEqpType.Text, rowIndex, 0);
                fExcelSht.writeCondition(lblEqpArea.Text, txtEqpArea.Text, rowIndex, 2);
                fExcelSht.writeCondition(lblEqpLine.Text, txtEqpLine.Text, rowIndex, 4);
                // --
                rowIndex += 1;
                fExcelSht.writeCondition(lblCategory.Text, ucbCategory.Text, rowIndex, 0);

                // --

                // ***
                // Equipment Detail Grid Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Equipment Detail") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                rowIndex = fExcelSht.writeDetailViewGrid(grdEqpDetail, rowIndex, 0);

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

        private void export(
            )
        {
            try
            {
                if (tabMain.ActiveTab.Key == "Equipment")
                {
                    exportGridOfEquipment();
                }
                else
                {
                    exportGridOfEquipmentDetail();
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
                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "EquipmentList", "SearchFactory", fSqlParams, true);

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

        #endregion
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Equipment Popup Menu

        private void procMenuEquipmentStatus(
            )
        {
            FEquipmentStatus fEqpStatus = null;

            try
            {
                fEqpStatus = (FEquipmentStatus)m_fAdmCore.fAdmContainer.getChild(typeof(FEquipmentStatus));
                if (fEqpStatus == null)
                {
                    fEqpStatus = new FEquipmentStatus(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEqpStatus);
                }
                // --
                fEqpStatus.attach(this.activeEq, ucbCategory.Text);
                fEqpStatus.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEqpStatus = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEquipmentHistory(
            )
        {
            FEquipmentHistory fEqpHistory = null;

            try
            {
                fEqpHistory = (FEquipmentHistory)m_fAdmCore.fAdmContainer.getChild(typeof(FEquipmentHistory));
                if (fEqpHistory == null)
                {
                    fEqpHistory = new FEquipmentHistory(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEqpHistory);
                }
                // --
                fEqpHistory.attach(this.activeEq);
                fEqpHistory.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEqpHistory = null;
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
                fEquipmentGemStatus.attach(this.activeEq);
                fEquipmentGemStatus.activate();
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

        public void procMenuEquipmentEventDefineRequest(
            )
        {
            FEquipmentEventDefineRequest fEqpEventDefineReq = null;
            UltraDataRow dr = null;
            string[,] eqpList = null;

            try
            {
                fEqpEventDefineReq = (FEquipmentEventDefineRequest)m_fAdmCore.fAdmContainer.getChild(typeof(FEquipmentEventDefineRequest));
                if (fEqpEventDefineReq == null)
                {
                    fEqpEventDefineReq = new FEquipmentEventDefineRequest(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEqpEventDefineReq);
                }

                // --

                if (tabMain.ActiveTab.Key == "Equipment")
                {
                    eqpList = new string[grdEqp.selectedDataRows.Length, 2];
                    for (int i = 0; i < grdEqp.selectedDataRows.Length; i++)
                    {
                        dr = grdEqp.selectedDataRows[i];
                        eqpList[i, 0] = (string)dr["Equipment"];
                        eqpList[i, 1] = (string)dr["EAP"];
                    }
                    fEqpEventDefineReq.attach(eqpList);
                }
                else 
                {
                    fEqpEventDefineReq.attach(this.selectedEqs, this.activeEap);
                }

                // --

                fEqpEventDefineReq.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEqpEventDefineReq = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void procMenuEquipmentVersionRequest(
            )
        {
            FEquipmentVersionRequest fEqpVerReq = null;
            UltraDataRow dr = null;
            string[,] eqpList = null;

            try
            {
                fEqpVerReq = (FEquipmentVersionRequest)m_fAdmCore.fAdmContainer.getChild(typeof(FEquipmentVersionRequest));
                if (fEqpVerReq == null)
                {
                    fEqpVerReq = new FEquipmentVersionRequest(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEqpVerReq);
                }

                // --

                if (tabMain.ActiveTab.Key == "Equipment")
                {
                    eqpList = new string[grdEqp.selectedDataRows.Length, 2];
                    for (int i = 0; i < grdEqp.selectedDataRows.Length; i++)
                    {
                        dr = grdEqp.selectedDataRows[i];
                        eqpList[i, 0] = (string)dr["Equipment"];
                        eqpList[i, 1] = (string)dr["EAP"];
                    }
                    fEqpVerReq.attach(eqpList);
                }
                else
                {
                    fEqpVerReq.attach(this.selectedEqs, this.activeEap);
                }

                // --

                fEqpVerReq.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEqpVerReq = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void procMenuEquipmentControlModeRequest(
            )
        {
            FEquipmentControlModeRequest fEqpControlModeReq = null;
            UltraDataRow dr = null;
            string[,] eqpList = null;

            try
            {
                fEqpControlModeReq = (FEquipmentControlModeRequest)m_fAdmCore.fAdmContainer.getChild(typeof(FEquipmentControlModeRequest));
                if (fEqpControlModeReq == null)
                {
                    fEqpControlModeReq = new FEquipmentControlModeRequest(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEqpControlModeReq);
                }

                // --

                if (tabMain.ActiveTab.Key == "Equipment")
                {
                    eqpList = new string[grdEqp.selectedDataRows.Length, 2];
                    for (int i = 0; i < grdEqp.selectedDataRows.Length; i++)
                    {
                        dr = grdEqp.selectedDataRows[i];
                        eqpList[i, 0] = (string)dr["Equipment"];
                        eqpList[i, 1] = (string)dr["EAP"];
                    }
                    fEqpControlModeReq.attach(eqpList);
                }
                else
                {
                    fEqpControlModeReq.attach(this.selectedEqs, this.activeEap);
                }

                // --

                fEqpControlModeReq.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEqpControlModeReq = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void procMenuCustomRemoteCommandRequest(
            )
        {
            FCustomRemoteCommandRequest fCustomRemoteCommandReq = null;
            UltraDataRow dr = null;
            string[,] eqpList = null;

            try
            {
                fCustomRemoteCommandReq = (FCustomRemoteCommandRequest)m_fAdmCore.fAdmContainer.getChild(typeof(FCustomRemoteCommandRequest));
                if (fCustomRemoteCommandReq == null)
                {
                    fCustomRemoteCommandReq = new FCustomRemoteCommandRequest(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fCustomRemoteCommandReq);
                }

                // --

                if (tabMain.ActiveTab.Key == "Equipment")
                {
                    eqpList = new string[grdEqp.selectedDataRows.Length, 2];
                    for (int i = 0; i < grdEqp.selectedDataRows.Length; i++)
                    {
                        dr = grdEqp.selectedDataRows[i];
                        eqpList[i, 0] = dr["Equipment"].ToString();
                        eqpList[i, 1] = dr["EAP"].ToString();
                    }
                    fCustomRemoteCommandReq.attach(eqpList);
                }
                else
                {
                    fCustomRemoteCommandReq.attach(this.selectedEqs, this.activeEap);
                }

                // --

                fCustomRemoteCommandReq.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fCustomRemoteCommandReq = null;
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
                if (tabMain.ActiveTab.Key == "Equipment")
                {
                    if (grdEqp.selectedDataRows.Length == 0)
                    {
                        return;
                    }
                }
                else
                {
                    fXmlNode = (FXmlNode)tvwSchema.ActiveNode.Tag;
                    if (fXmlNode.name != FADMADS_TolEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.E_Equipment)
                    {
                        return;
                    }
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

                if (tabMain.ActiveTab.Key == "Equipment")
                {

                    foreach (UltraDataRow row in grdEqp.selectedDataRows)
                    {
                        fEquipmentList.Add(
                            new FStructureEquipment(
                                ((DataRow)grdEqp.Rows[row.Index].Tag)[0].ToString(), // Equipment
                                ((DataRow)grdEqp.Rows[row.Index].Tag)[2].ToString(), // Eap
                                ((DataRow)grdEqp.Rows[row.Index].Tag)[1].ToString(), // Description
                                ((DataRow)grdEqp.Rows[row.Index].Tag)[33].ToString() // Ip Address
                                )
                            );
                    }
                }
                else
                {
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
                    // --
                    fEquipmentList.Add(
                        new FStructureEquipment(
                            eqpName,
                            this.activeEap,
                            eqpDesc,
                            eqpIpAddress
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
                fXmlNode = null;
            }
        }
     
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FEquipmentList Form Event Handler

        private void FEquipmentList_Load(
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

                designComboOfCategory();
                // --
                designGridOfEquipment();
                designGridOfEquipmentDetail();
                // --
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

        private void FEquipmentList_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                //--

                refreshComboOfCategory();
                refresh();

                // --

                txtEqpType.Focus();
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

        private void FEquipmentList_FormClosing(
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

        private void FEquipmentList_KeyDown(
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

                if (e.Tool.Key == FMenuKey.MenuEqlRefresh)
                {
                    refresh();
                }
                else if (e.Tool.Key == FMenuKey.MenuEqlExport)
                {
                    export();
                }

                // --

                else if (e.Tool.Key == FMenuKey.MenuInqEqpStatus)
                {
                    procMenuEquipmentStatus();
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

        #region txtEqpType Control Event Handler

        private void txtEqpType_EditorButtonClick(
            object sender,
            EditorButtonEventArgs e
            )
        {
            FEquipmentTypeSelector fDialog = null;

            try
            {
                FCursor.waitCursor();

                // --

                fDialog = new FEquipmentTypeSelector(m_fAdmCore, txtEqpType.Text);
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                txtEqpType.Text = fDialog.selectedType;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region txtEqpArea Control Event Handler

        private void txtEqpArea_EditorButtonClick(
            object sender,
            EditorButtonEventArgs e
            )
        {
            FEquipmentAreaSelector fDialog = null;

            try
            {
                FCursor.waitCursor();

                // --

                fDialog = new FEquipmentAreaSelector(m_fAdmCore, txtEqpArea.Text);
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                txtEqpArea.Text = fDialog.selectedArea;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region txtEqpLine Control Event Handler

        private void txtEqpLine_EditorButtonClick(
            object sender,
            EditorButtonEventArgs e
            )
        {
            FEquipmentLineSelector fDialog = null;

            try
            {
                FCursor.waitCursor();

                // --

                fDialog = new FEquipmentLineSelector(m_fAdmCore, txtEqpLine.Text);
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                txtEqpLine.Text = fDialog.selectedLine;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region TextBox Common Control Event Handler

        private void txtCommon_ValueChanged(
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

        #region grdEqp Control Event Handler

        private void grdEqp_AfterRowActivate(
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

                tabMain.SelectedTab = tabMain.Tabs["EqDetail"];

                // --

                grdEqpDetail.Focus();
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

                mnuMenu.Tools[FMenuKey.MenuInqEqpStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentStatus);
                mnuMenu.Tools[FMenuKey.MenuInqEqpHistory].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentHistory);                
                // --
                mnuMenu.Tools[FMenuKey.MenuInqEqpGemStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentGemStatus);
                // --
                mnuMenu.Tools[FMenuKey.MenuInqEqpEventDefineRequest].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentEventDefineRequest);
                mnuMenu.Tools[FMenuKey.MenuInqEqpVersionRequest].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentVersionRequest);
                mnuMenu.Tools[FMenuKey.MenuInqEqpControlModeRequest].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentControlModeRequest);
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
                r = null;
                // --
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------     

        private void grdEqp_AfterRowFilterChanged(
            object sender,
            AfterRowFilterChangedEventArgs e
            )
        {
            int activateIndex = -1;

            try
            {
                FCursor.waitCursor();

                // --

                if (e.Rows.VisibleRowCount == 0)
                {
                    return;
                }

                // --

                grdEqp.beginUpdate();

                // --

                grdEqp.Selected.Rows.Clear();
                foreach (UltraGridRow r in e.Rows.GetFilteredInNonGroupByRows())
                {
                    if (r == grdEqp.ActiveRow)
                    {
                        activateIndex = r.VisibleIndex;
                        break;
                    }
                }
                // --
                if (activateIndex == -1)
                {
                    activateIndex = e.Rows.VisibleRowCount - 1;
                }
                grdEqp.ActiveRow = e.Rows.GetRowAtVisibleIndex(activateIndex);
                grdEqp.DisplayLayout.RowScrollRegions[0].ScrollRowIntoView(grdEqp.ActiveRow);

                // --

                grdEqp.endUpdate();

                // --

                refreshEquipmentTotal();
            }
            catch (Exception ex)
            {
                grdEqp.endUpdate();
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
            Infragistics.Win.UltraWinTree.NodeEventArgs e
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

                mnuMenu.Tools[FMenuKey.MenuInqEqpStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentStatus);
                mnuMenu.Tools[FMenuKey.MenuInqEqpHistory].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentHistory);                
                // --
                mnuMenu.Tools[FMenuKey.MenuInqEqpGemStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentGemStatus);
                // --
                mnuMenu.Tools[FMenuKey.MenuInqEqpEventDefineRequest].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentEventDefineRequest);
                mnuMenu.Tools[FMenuKey.MenuInqEqpVersionRequest].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentVersionRequest);
                mnuMenu.Tools[FMenuKey.MenuInqEqpControlModeRequest].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentControlModeRequest);
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

        #region rstToolbar Control Event Handler

        private void rstToolbar_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --
                
                if (!grdEqp.searchGridRow(e.searchWord))
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
