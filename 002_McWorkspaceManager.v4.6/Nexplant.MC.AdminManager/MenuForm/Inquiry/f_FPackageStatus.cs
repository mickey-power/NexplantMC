/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FPackageStatus.cs
--  Creator         : baehyun.seo
--  Create Date     : 2012.05.14
--  Description     : FAMate Admin Manager Package Status Form Class 
--  History         : Created by baehyun.seo at 2012.05.14
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
    public partial class FPackageStatus : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private string[] m_logLevelCaption = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPackageStatus(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPackageStatus(
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
                    return grdEap.activeDataRowKey;
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

        private string activeType
        {
            get
            {
                try
                {
                    if (grdEap.activeDataRow == null)
                    {
                        return string.Empty;
                    }

                    // --

                    return (string)grdEap.activeDataRow["Type"];
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

        private void designGridOfPackageDetail(
            )
        {
            string[] columns = null;

            try
            {
                columns = new string[]
                {
                    "Package",
                    "Description",
                    "Type",
                    // --
                    "Release Ver.",
                    "Last Ver.",
                    "Empty1",
                    // --
                    "Version",
                    "Ver. Description",
                    "File",
                    // --                    
                    "Comment",
                    "Creator",
                    "Updater"                    
                };
                // --

                grdDetail.addColumns(3, columns);
                grdDetail.setColumnHeaderWidth(120);
                // --
                grdDetail.DisplayLayout.Override.TipStyleCell = TipStyle.Show;

                // --

                grdDetail.Rows[2].Cells[5].ButtonAppearance.BorderColor = Color.Transparent;
                grdDetail.Rows[3].Cells[1].ButtonAppearance.BorderColor = Color.Transparent;
                grdDetail.Rows[2].Cells[5].ButtonAppearance.Image = Properties.Resources.More;
                grdDetail.Rows[3].Cells[1].ButtonAppearance.Image = Properties.Resources.More;
                grdDetail.Rows[2].Cells[1].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                grdDetail.Rows[2].Cells[3].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                // --
                grdDetail.Rows[1].Cells[4].Value = string.Empty;                
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

        private void designGridOfEap(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdEap.dataSource;
                // --
                uds.Band.Columns.Add("EAP");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("RPM Count");
                uds.Band.Columns.Add("Type");
                uds.Band.Columns.Add("Operation Mode");
                uds.Band.Columns.Add("Server");
                uds.Band.Columns.Add("Step");
                uds.Band.Columns.Add("Up/Down");
                uds.Band.Columns.Add("Status");
                uds.Band.Columns.Add("Reload Count");
                uds.Band.Columns.Add("(Set) Package");
                uds.Band.Columns.Add("(Rel) Package");
                uds.Band.Columns.Add("(Apl) Package");
                uds.Band.Columns.Add("(Set) Model");
                uds.Band.Columns.Add("(Rel) Model");
                uds.Band.Columns.Add("(Apl) Model");
                uds.Band.Columns.Add("(Set) Component");
                uds.Band.Columns.Add("(Rel) Component");
                uds.Band.Columns.Add("(Apl) Component");
                uds.Band.Columns.Add("Need Action");
                uds.Band.Columns.Add("Next Need Action");
                uds.Band.Columns.Add("Last Event Time");
                uds.Band.Columns.Add("Last Event");
                uds.Band.Columns.Add("Create User ID");
                uds.Band.Columns.Add("Create Time");
                uds.Band.Columns.Add("Update User ID");
                uds.Band.Columns.Add("Update Time");

                // --

                grdEap.DisplayLayout.Bands[0].Columns["RPM Count"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdEap.DisplayLayout.Bands[0].Columns["Reload Count"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdEap.DisplayLayout.Bands[0].Columns["Last Event Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdEap.DisplayLayout.Bands[0].Columns["Create Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdEap.DisplayLayout.Bands[0].Columns["Update Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

                // -- 

                grdEap.DisplayLayout.Bands[0].Columns["EAP"].Header.Fixed = true;

                // --

                grdEap.DisplayLayout.Bands[0].Columns["EAP"].Width = 100;
                grdEap.DisplayLayout.Bands[0].Columns["Description"].Width = 180;
                grdEap.DisplayLayout.Bands[0].Columns["RPM Count"].Width = 70;
                grdEap.DisplayLayout.Bands[0].Columns["Type"].Width = 80;
                grdEap.DisplayLayout.Bands[0].Columns["Operation Mode"].Width = 110;
                grdEap.DisplayLayout.Bands[0].Columns["Server"].Width = 100;
                grdEap.DisplayLayout.Bands[0].Columns["Step"].Width = 120;
                grdEap.DisplayLayout.Bands[0].Columns["Up/Down"].Width = 80;
                grdEap.DisplayLayout.Bands[0].Columns["Status"].Width = 80;
                grdEap.DisplayLayout.Bands[0].Columns["Reload Count"].Width = 80;
                grdEap.DisplayLayout.Bands[0].Columns["(Set) Package"].Width = 180;
                grdEap.DisplayLayout.Bands[0].Columns["(Rel) Package"].Width = 180;
                grdEap.DisplayLayout.Bands[0].Columns["(Apl) Package"].Width = 180;
                grdEap.DisplayLayout.Bands[0].Columns["(Set) Model"].Width = 180;
                grdEap.DisplayLayout.Bands[0].Columns["(Rel) Model"].Width = 180;
                grdEap.DisplayLayout.Bands[0].Columns["(Apl) Model"].Width = 180;
                grdEap.DisplayLayout.Bands[0].Columns["(Set) Component"].Width = 180;
                grdEap.DisplayLayout.Bands[0].Columns["(Rel) Component"].Width = 180;
                grdEap.DisplayLayout.Bands[0].Columns["(Apl) Component"].Width = 180;
                grdEap.DisplayLayout.Bands[0].Columns["Need Action"].Width = 100;
                grdEap.DisplayLayout.Bands[0].Columns["Next Need Action"].Width = 100;
                grdEap.DisplayLayout.Bands[0].Columns["Last Event Time"].Width = 165;
                grdEap.DisplayLayout.Bands[0].Columns["Last Event"].Width = 100;
                grdEap.DisplayLayout.Bands[0].Columns["Create User ID"].Width = 100;
                grdEap.DisplayLayout.Bands[0].Columns["Create Time"].Width = 165;
                grdEap.DisplayLayout.Bands[0].Columns["Update User ID"].Width = 100;
                grdEap.DisplayLayout.Bands[0].Columns["Update Time"].Width = 165;

                // --

                grdEap.ImageList = new ImageList();
                // --
                grdEap.ImageList.Images.Add("Eap_Secs", Properties.Resources.Eap_Secs);
                grdEap.ImageList.Images.Add("Eap_Plc", Properties.Resources.Eap_Plc);
                grdEap.ImageList.Images.Add("Eap_Opc", Properties.Resources.Eap_Opc);
                grdEap.ImageList.Images.Add("Eap_Tcp", Properties.Resources.Eap_Tcp);
                grdEap.ImageList.Images.Add("Eap_Process", Properties.Resources.Eap_Process);

                // --

                grdEap.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                grdEap.DisplayLayout.Override.FilterUIProvider = this.grdFilter;
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

        private void designGridOfEapDetail(
            )
        {
            string[] columns = null;

            try
            {
                columns = new string[]
                {
                    "EAP",
                    "Description",
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
                    "(Set) Package",
                    "(Set) Model",
                    "(Set) Component",
                    // --
                    "(Rel) Package",
                    "(Rel) Model",
                    "(Rel) Component",
                    // --
                    "(Apl) Package",
                    "(Apl) Model",
                    "(Apl) Component",
                    // --
                    "Creator",
                    "Updater",
                    "Empty2",
                    // --
                    "Last Event Time",
                    "Last Event",
                    "Empty3"
                };

                // --

                grdEapDetail.addColumns(3, columns);
                grdEapDetail.setColumnHeaderWidth(120);
                // --
                grdEapDetail.DisplayLayout.Override.TipStyleCell = TipStyle.Show;

                // --

                grdEapDetail.Rows[7].Cells[4].Value = string.Empty;
                grdEapDetail.Rows[8].Cells[4].Value = string.Empty;
                
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
                // Package Detail Information Clear
                // ***
                grdDetail.beginUpdate();
                grdDetail.clearColumnValue();
                grdDetail.endUpdate();

                // --

                // ***
                // EAP List Clear
                // ***
                grdEap.beginUpdate();
                grdEap.removeAllDataRow();
                grdEap.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdEap.endUpdate();

                // --

                refreshEapTotal();

                // --

                // ***
                // EAP Detail Information Clear
                // ***
                clearGridOfEapDetail();
            }
            catch (Exception ex)
            {
                grdDetail.endUpdate();
                grdEap.endUpdate();
                // --
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        public void attach(
            string packageName,
            string packageType,
            string packageVersion
            )
        {
            try
            {
                txtPackage.Text = packageName;
                txtPackage.Tag = packageType;
                txtVersion.Text = packageVersion;

                // --

                refresh();

                // --

                txtVersion.Focus();
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

        private void refreshComboOfCategory(
             )
        {
            try
            {
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

                ucbCategory.Text = FEapAttrCategory.Applied.ToString();
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

        private void refreshGridOfPackageDetail(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            DataRow row = null;
            object[] cellValues = null;
            string creator = string.Empty;
            string updater = string.Empty;

            try
            {
                grdDetail.beginUpdate();
                grdDetail.clearColumnValue();

                // --

                #region Validation

                if (txtPackage.Text == string.Empty || txtVersion.Text == string.Empty)
                {
                    grdDetail.endUpdate();
                    txtVersion.Focus();
                    FDebug.throwFException(fUIWizard.generateMessage("E0004", new object[] { "Package" }));
                }

                #endregion

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("package", txtPackage.Text);
                fSqlParams.add("pkg_ver", txtVersion.Text);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "PackageStatus", "SearchPackage", fSqlParams, true);
                row = dt.Rows[0];

                // --

                creator = row[10].ToString() + " [" + FDataConvert.defaultDataTimeFormating(row[11].ToString()) + "]";
                updater = row[12].ToString() + " [" + FDataConvert.defaultDataTimeFormating(row[13].ToString()) + "]";

                // --

                cellValues = new object[] {
                    row[0].ToString(),          // Package
                    row[1].ToString(),          // Description
                    row[2].ToString(),          // Package Type
                    // --
                    row[3].ToString(),          // Release Version
                    row[4].ToString(),          // Last Version
                    string.Empty,
                    // --
                    string.Format("{0}{1}", row[5].ToString(), (row[6].ToString() == FYesNo.Yes.ToString() ? "*" : string.Empty)),  // Version,
                    row[7].ToString(),          // Ver. Description
                    row[8].ToString(),          // File
                    // --
                    row[9].ToString(),          // Comment
                    creator,                    // Creator
                    updater                     // Updater
                    };
                grdDetail.setColumnValues(cellValues);

                // --

                FCommon.designGridCellForEditButton(grdDetail.getColumn("File"));
                FCommon.designGridCellForEditButton(grdDetail.getColumn("Comment"));

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
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void refreshGridOfEap(
             )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            UltraGridRow row = null;
            UltraGridCell cell = null;
            object[] cellValues = null;
            string eapType = string.Empty;
            string set_Package = string.Empty;
            string rel_Package = string.Empty;
            string apl_Package = string.Empty;
            string set_Model = string.Empty;
            string rel_Model = string.Empty;
            string apl_Model = string.Empty;
            string set_Component = string.Empty;
            string rel_Component = string.Empty;
            string apl_Component = string.Empty;
            string lastEventTime = string.Empty;
            string createTime = string.Empty;
            string updateTime = string.Empty;
            string key = string.Empty;
            string beforeKey = string.Empty;
            int nextRowNumber = 0;
            int index = 0;

            try
            {
                clearGridOfEapDetail();

                // --

                beforeKey = this.activeEap;
                // --
                grdEap.beginUpdate(false);
                grdEap.removeAllDataRow();
                grdEap.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                if (txtPackage.Text == string.Empty || txtVersion.Text == string.Empty)
                {
                    grdEap.endUpdate(false);
                    return;
                }

                // --
                
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("package", txtPackage.Text);
                fSqlParams.add("pkg_ver", txtVersion.Text);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "PackageStatus", "ListEap", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        eapType = r[2].ToString();

                        // --

                        set_Package = FCommon.generateStringForPackage(r[9].ToString(), r[10].ToString());
                        rel_Package = FCommon.generateStringForPackage(r[11].ToString(), r[12].ToString());
                        apl_Package = FCommon.generateStringForPackage(r[13].ToString(), r[14].ToString());
                        set_Model = FCommon.generateStringForModel(r[15].ToString(), r[16].ToString());
                        rel_Model = FCommon.generateStringForModel(r[17].ToString(), r[18].ToString());
                        apl_Model = FCommon.generateStringForModel(r[19].ToString(), r[20].ToString());
                        set_Component = FCommon.generateStringForComponent(r[21].ToString(), r[22].ToString(), r[23].ToString());
                        rel_Component = FCommon.generateStringForComponent(r[24].ToString(), r[25].ToString(), r[26].ToString());
                        apl_Component = FCommon.generateStringForComponent(r[27].ToString(), r[28].ToString(), r[29].ToString());

                        // --

                        lastEventTime = FDataConvert.defaultDataTimeFormating(r[32].ToString());
                        createTime = FDataConvert.defaultDataTimeFormating(r[35].ToString());
                        updateTime = FDataConvert.defaultDataTimeFormating(r[37].ToString());

                        // --

                        cellValues = new object[] {
                            r[0].ToString(),  // EAP
                            r[1].ToString(),  // Description
                            r[38].ToString(), // RPM Count (2017.06.07 by spike.lee add)
                            eapType,          // Type
                            r[3].ToString(),  // Oper Mode
                            r[4].ToString(),  // Server
                            r[5].ToString(),  // Step
                            r[6].ToString(),  // Up/Down
                            r[7].ToString(),  // Status
                            r[8].ToString(),  // Reload Count
                            set_Package,      // (Set) Package
                            rel_Package,      // (Rel) Package
                            apl_Package,      // (Apl) Package
                            set_Model,        // (Set) Model
                            rel_Model,        // (Rel) Model
                            apl_Model,        // (Apl) Model
                            set_Component,    // (Set) Component
                            rel_Component,    // (Rel) Component
                            apl_Component,    // (Apl) Component
                            r[30].ToString(), // Need Action
                            r[31].ToString(), // Next Need Action
                            lastEventTime,    // Last Event Time
                            r[33].ToString(), // Last Event ID
                            r[34].ToString(), // Create User ID
                            createTime,       // Create Time
                            r[36].ToString(), // Update User ID
                            updateTime        // Update Time
                            };
                        key = (string)cellValues[0];
                        index = grdEap.appendDataRow(key, cellValues).Index;

                        // --

                        row = grdEap.Rows.GetRowWithListIndex(index);

                        // --

                        cell = row.Cells["EAP"];
                        cell.Appearance.Image = FCommon.getImageOfEap(grdEap, eapType);

                    }
                } while (nextRowNumber >= 0);

                // --

                grdEap.endUpdate(false);

                // --

                if (grdEap.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdEap.activateDataRow(beforeKey);
                    }
                    if (grdEap.activeDataRow == null)
                    {
                        grdEap.ActiveRow = grdEap.Rows[0];
                    }
                }

                // --

                refreshEapTotal();
            }
            catch (Exception ex)
            {
                grdEap.endUpdate(false);
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

        private void refreshGridOfEapDetail(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            DataRow row = null;
            UltraGridCell cell = null;
            object[] cellValues = null;
            string set_Package = string.Empty;
            string set_Model = string.Empty;
            string set_Component = string.Empty;
            string rel_Package = string.Empty;
            string rel_Model = string.Empty;
            string rel_Component = string.Empty;
            string apl_Package = string.Empty;
            string apl_Model = string.Empty;
            string apl_Component = string.Empty;
            string creator = string.Empty;
            string updater = string.Empty;
            string lastEventTime = string.Empty;

            try
            {
                grdEapDetail.beginUpdate();
                grdLogLevel.beginUpdate();
                grdEapDetail.clearColumnValue();
                grdLogLevel.clearColumnValue();
                // --
                if (grdEap.activeDataRow == null)
                {
                    grdEapDetail.endUpdate();
                    grdLogLevel.endUpdate();
                    return;
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("eap", this.activeEap);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ServerList", "SearchEap", fSqlParams, true);
                row = dt.Rows[0];

                // --

                set_Package = FCommon.generateStringForPackage(row[11].ToString(), row[12].ToString());
                set_Model = FCommon.generateStringForModel(row[13].ToString(), row[14].ToString());
                set_Component = FCommon.generateStringForComponent(row[15].ToString(), row[16].ToString(), row[17].ToString());
                rel_Package = FCommon.generateStringForPackage(row[18].ToString(), row[19].ToString());
                rel_Model = FCommon.generateStringForModel(row[20].ToString(), row[21].ToString());
                rel_Component = FCommon.generateStringForComponent(row[22].ToString(), row[23].ToString(), row[24].ToString());
                apl_Package = FCommon.generateStringForPackage(row[25].ToString(), row[26].ToString());
                apl_Model = FCommon.generateStringForModel(row[27].ToString(), row[28].ToString());
                apl_Component = FCommon.generateStringForComponent(row[29].ToString(), row[30].ToString(), row[31].ToString());

                // --

                creator = row[32].ToString() + " [" + FDataConvert.defaultDataTimeFormating(row[33].ToString()) + "]";
                updater = row[34].ToString() + " [" + FDataConvert.defaultDataTimeFormating(row[35].ToString()) + "]";
                lastEventTime = FDataConvert.defaultDataTimeFormating(row[36].ToString());

                // --

                cellValues = new object[] {
                    row[0].ToString(),       // EAP
                    row[1].ToString(),       // Description
                    row[38].ToString(),      // RPM Count (2017.06.07 by spike.lee add)
                    // --
                    row[2].ToString(),       // EAP Type
                    row[3].ToString(),       // Oper Mode
                    row[4].ToString(),       // Server
                    // --
                    row[5].ToString(),       // Up/Down
                    row[6].ToString(),       // Status                    
                    row[7].ToString(),       // Step
                    // --
                    row[8].ToString(),       // Need Action
                    row[9].ToString(),       // Next Need Action
                    row[10].ToString(),      // Reload Count
                    // --
                    set_Package,             // (Set) Package                    
                    set_Model,               // (Set) Model
                    set_Component,           // (Set) Component                    
                    // --
                    rel_Package,             // (Rel) Package                    
                    rel_Model,               // (Rel) Model
                    rel_Component,           // (Rel) Component                    
                    // --
                    apl_Package,             // (Apl) Package                    
                    apl_Model,               // (Apl) Model
                    apl_Component,           // (Apl) Component                    
                    // --
                    creator,                 // Create Time
                    updater,                 // Update Time
                    string.Empty,
                    // --
                    lastEventTime,            // Last Event Time
                    row[37].ToString(),       // Last Event
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

                if (!FCommon.stringEquals(set_Package, rel_Package, apl_Package))
                {
                    cell = grdEapDetail.getColumn("(Set) Package");
                    cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    cell.Appearance.ForeColor = Color.Blue;
                    cell = grdEapDetail.getColumn("(Rel) Package");
                    cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    cell.Appearance.ForeColor = Color.Blue;
                    cell = grdEapDetail.getColumn("(Apl) Package");
                    cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    cell.Appearance.ForeColor = Color.Blue;
                }

                // --

                if (!FCommon.stringEquals(set_Model, rel_Model, apl_Model))
                {
                    cell = grdEapDetail.getColumn("(Set) Model");
                    cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    cell.Appearance.ForeColor = Color.Blue;
                    cell = grdEapDetail.getColumn("(Rel) Model");
                    cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    cell.Appearance.ForeColor = Color.Blue;
                    cell = grdEapDetail.getColumn("(Apl) Model");
                    cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    cell.Appearance.ForeColor = Color.Blue;
                }

                // --

                if (!FCommon.stringEquals(set_Component, rel_Component, apl_Component))
                {
                    cell = grdEapDetail.getColumn("(Set) Component");
                    cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    cell.Appearance.ForeColor = Color.Blue;
                    cell = grdEapDetail.getColumn("(Rel) Component");
                    cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    cell.Appearance.ForeColor = Color.Blue;
                    cell = grdEapDetail.getColumn("(Apl) Component");
                    cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    cell.Appearance.ForeColor = Color.Blue;
                }

                // --

                FCommon.designGridCellForEapStep(grdEapDetail.getColumn("Step"));
                FCommon.designGridCellForEapNeedAction(grdEapDetail.getColumn("Need Action"));
                FCommon.designGridCellForEapNextNeedAction(grdEapDetail.getColumn("Next Need Action"));
                FCommon.designGridCellForEapUpDown(grdEapDetail.getColumn("Up/Down"));
                FCommon.designGridCellForEapStatus(grdEapDetail.getColumn("Status"));
                FCommon.designGridCellForEapPackage(grdEapDetail.getColumn("(Set) Package"));
                FCommon.designGridCellForEapModel(grdEapDetail.getColumn("(Set) Model"));
                FCommon.designGridCellForEapComponent(grdEapDetail.getColumn("(Set) Component"));
                FCommon.designGridCellForEapPackage(grdEapDetail.getColumn("(Rel) Package"));
                FCommon.designGridCellForEapModel(grdEapDetail.getColumn("(Rel) Model"));
                FCommon.designGridCellForEapComponent(grdEapDetail.getColumn("(Rel) Component"));
                FCommon.designGridCellForEapPackage(grdEapDetail.getColumn("(Apl) Package"));
                FCommon.designGridCellForEapModel(grdEapDetail.getColumn("(Apl) Model"));
                FCommon.designGridCellForEapComponent(grdEapDetail.getColumn("(Apl) Component"));

                // --

                grdEapDetail.endUpdate();

                // --

                foreach (UltraGridRow r in grdEapDetail.Rows)
                {
                    for (int i = 0; i < r.Cells.Count; i += 2)
                    {
                        r.Cells[i + 1].ToolTipText = (string)r.Cells[i + 1].Value;
                    }
                }

                // --

                // ***
                // 2017.07.05 by spike.lee
                // EAP Log Level 
                // ***
                cellValues = new object[] {
                    row[39].ToString().Trim() == string.Empty ? FYesNo.Yes.ToString() : row[39].ToString(), // Log Level 1                    
                    row[40].ToString().Trim() == string.Empty ? FYesNo.No.ToString() : row[40].ToString(),  // Log Level 2
                    row[41].ToString().Trim() == string.Empty ? FYesNo.No.ToString() : row[41].ToString(),  // Log Level 3
                    // --
                    row[42].ToString().Trim() == string.Empty ? FYesNo.No.ToString() : row[42].ToString(),  // Log Level 4
                    row[43].ToString().Trim() == string.Empty ? FYesNo.No.ToString() : row[43].ToString(),  // Log Level 5
                    row[44].ToString().Trim() == string.Empty ? FYesNo.No.ToString() : row[44].ToString(),  // Log Level 6
                    // --
                    row[45].ToString().Trim() == string.Empty ? FYesNo.No.ToString() : row[45].ToString(),  // Log Level 7
                    row[46].ToString().Trim() == string.Empty ? FYesNo.No.ToString() : row[46].ToString(),  // Log Level 8
                    row[47].ToString().Trim() == string.Empty ? FYesNo.No.ToString() : row[47].ToString(),  // Log Level 9
                    // --
                    row[48].ToString().Trim() == string.Empty ? FYesNo.No.ToString() : row[48].ToString(),  // Log Level 10
                    string.Empty,            // Empty 1
                    string.Empty,            // Empty 2
                    };
                grdLogLevel.setColumnValues(cellValues);

                // --

                grdLogLevel.endUpdate();

                // --

                foreach (UltraGridRow r in grdLogLevel.Rows)
                {
                    for (int i = 0; i < r.Cells.Count; i += 2)
                    {
                        r.Cells[i + 1].ToolTipText = (string)r.Cells[i + 1].Value;
                    }
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
                tvwSchema.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------   

        private void refresh(
            )
        {
            try
            {
                if (tabMain.ActiveTab.Key == "Package")
                {
                    refreshGridOfPackageDetail();
                    refreshGridOfEap();
                    // --
                    grdDetail.Focus();
                }
                else
                {
                    refreshGridOfEapDetail();
                    refreshEapSchema();
                    // --
                    grdEapDetail.Focus();
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

        private void refreshEapTotal(
            )
        {
            try
            {
                lblEapTotal.Text = grdEap.Rows.VisibleRowCount.ToString("#,##0") + " / " + grdEap.Rows.Count.ToString("#,##0");
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

        private void exportGridOfPackage(
            )
        {
            SaveFileDialog sfd = null;
            string fileName = string.Empty;
            FExcelExporter2 fExcelExp = null;
            FExcelSheet fExcelSht = null;
            int rowIndex = 0;

            try
            {
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_PackageStatus_" + txtPackage.Text + "_" + txtVersion.Text + ".xlsx";

                // --

                sfd = new SaveFileDialog();
                // --
                sfd.Title = "Export Package Status to Excel";
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
                fExcelSht = fExcelExp.addExcelSheet("Package Status");

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
                fExcelSht.writeCondition(lblPackage.Text, txtPackage.Text, rowIndex, 0);
                fExcelSht.writeCondition("Version", txtVersion.Text, rowIndex, 2);

                // --

                // ***
                // Package Detail Grid Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Package Detail") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                rowIndex = fExcelSht.writeDetailViewGrid(grdDetail, rowIndex, 0);

                // --

                // ***
                // EAP List Grid Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("EAP List") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                rowIndex = fExcelSht.writeGrid(grdEap, rowIndex, 0);
                // --
                rowIndex += 1;
                fExcelSht.writeText("Total Count: " + grdEap.Rows.Count.ToString(), rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);

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

                //--

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

        private void exportGridOfEapDetail(
            )
        {
            SaveFileDialog sfd = null;
            string fileName = string.Empty;
            FExcelExporter2 fExcelExp = null;
            FExcelSheet fExcelSht = null;
            int rowIndex = 0;

            try
            {
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_PackageStatus_" + txtPackage.Text + "_" + txtVersion.Text + ".xlsx";

                // --

                sfd = new SaveFileDialog();
                // --                
                sfd.Title = "Export Package Status to Excel";
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
                fExcelSht = fExcelExp.addExcelSheet("Package Status");

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
                fExcelSht.writeCondition(lblPackage.Text, txtPackage.Text, rowIndex, 0);
                fExcelSht.writeCondition("Version", txtVersion.Text, rowIndex, 2);

                // --

                // ***
                // Package Status EAP Detail Grid Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("EAP Detail") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                rowIndex = fExcelSht.writeDetailViewGrid(grdEapDetail, rowIndex, 0);

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
                if (tabMain.ActiveTab.Key == "Package")
                {
                    exportGridOfPackage();
                }
                else
                {
                    exportGridOfEapDetail();
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
                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "PackageStatus", "SearchFactory", fSqlParams, true);

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

        private void procMenuEapStatus(
            )
        {
            FEapStatus fEapStatus = null;

            try
            {
                fEapStatus = (FEapStatus)m_fAdmCore.fAdmContainer.getChild(typeof(FEapStatus));
                if (fEapStatus == null)
                {
                    fEapStatus = new FEapStatus(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEapStatus);
                }
                fEapStatus.activate();
                fEapStatus.attach(this.activeEap, this.activeType);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapStatus = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapHistory(
            )
        {
            FEapHistory fEapHistory = null;

            try
            {
                fEapHistory = (FEapHistory)m_fAdmCore.fAdmContainer.getChild(typeof(FEapHistory));
                if (fEapHistory == null)
                {
                    fEapHistory = new FEapHistory(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEapHistory);
                }
                fEapHistory.activate();
                fEapHistory.attach(this.activeEap);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapHistory = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapRepositoryStatus(
            )
        {
            FEapRepositoryStatus fEapRepositoryStatus = null;

            try
            {
                fEapRepositoryStatus = (FEapRepositoryStatus)m_fAdmCore.fAdmContainer.getChild(typeof(FEapRepositoryStatus));
                if (fEapRepositoryStatus == null)
                {
                    fEapRepositoryStatus = new FEapRepositoryStatus(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEapRepositoryStatus);
                }
                fEapRepositoryStatus.activate();
                fEapRepositoryStatus.attach(this.activeEap, this.activeType);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapRepositoryStatus = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapResourceHistory(
            )
        {
            FEapResourceHistory fEapResourceHistory = null;

            try
            {
                fEapResourceHistory = (FEapResourceHistory)m_fAdmCore.fAdmContainer.getChild(typeof(FEapResourceHistory));
                if (fEapResourceHistory == null)
                {
                    fEapResourceHistory = new FEapResourceHistory(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEapResourceHistory);
                }
                fEapResourceHistory.activate();
                fEapResourceHistory.attach(this.activeEap);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapResourceHistory = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapRelease(
            )
        {
            FEapRelease fEapRelease = null;
            string[] eapList = null;
            string[] eapDescList = null;

            try
            {                
                fEapRelease = (FEapRelease)m_fAdmCore.fAdmContainer.getChild(typeof(FEapRelease));
                if (fEapRelease == null)
                {
                    fEapRelease = new FEapRelease(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEapRelease);
                }
                fEapRelease.activate();

                // --

                eapList = grdEap.selectedDataRowKeys;
                eapDescList = new string[eapList.Length];
                // --
                for (int i = 0; i < eapList.Length; i++)
                {
                    eapDescList[i] = grdEap.getDataRow(eapList[i])["Description"].ToString();
                }
                // --
                fEapRelease.attach(eapList, eapDescList);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapRelease = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapReload(
            )
        {
            FEapReload fEapReload = null;
            string[] eapList = null;
            string[] eapDescList = null;

            try
            {   
                fEapReload = (FEapReload)m_fAdmCore.fAdmContainer.getChild(typeof(FEapReload));
                if (fEapReload == null)
                {
                    fEapReload = new FEapReload(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEapReload);
                }
                fEapReload.activate();

                // --

                eapList = grdEap.selectedDataRowKeys;
                eapDescList = new string[eapList.Length];
                // --
                for (int i = 0; i < eapList.Length; i++)
                {
                    eapDescList[i] = grdEap.getDataRow(eapList[i])["Description"].ToString();
                }
                // --
                fEapReload.attach(eapList, eapDescList);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapReload = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapRestart(
            )
        {
            FEapRestart fEapRestart = null;
            string[] eapList = null;
            string[] eapDescList = null;

            try
            {
                fEapRestart = (FEapRestart)m_fAdmCore.fAdmContainer.getChild(typeof(FEapRestart));
                if (fEapRestart == null)
                {
                    fEapRestart = new FEapRestart(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEapRestart);
                }
                fEapRestart.activate();

                // --

                eapList = grdEap.selectedDataRowKeys;
                eapDescList = new string[eapList.Length];
                // --
                for (int i = 0; i < eapList.Length; i++)
                {
                    eapDescList[i] = grdEap.getDataRow(eapList[i])["Description"].ToString();
                }
                // --
                fEapRestart.attach(eapList, eapDescList);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapRestart = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapStart(
            )
        {
            FEapStart fEapStart = null;
            string[] eapList = null;
            string[] eapDescList = null;

            try
            {
                fEapStart = (FEapStart)m_fAdmCore.fAdmContainer.getChild(typeof(FEapStart));
                if (fEapStart == null)
                {
                    fEapStart = new FEapStart(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEapStart);
                }
                fEapStart.activate();

                // --

                eapList = grdEap.selectedDataRowKeys;
                eapDescList = new string[eapList.Length];
                // --
                for (int i = 0; i < eapList.Length; i++)
                {
                    eapDescList[i] = grdEap.getDataRow(eapList[i])["Description"].ToString();
                }
                // --
                fEapStart.attach(eapList, eapDescList);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapStart = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapStop(
            )
        {
            FEapStop fEapStop = null;
            string[] eapList = null;
            string[] eapDescList = null;

            try
            {   
                fEapStop = (FEapStop)m_fAdmCore.fAdmContainer.getChild(typeof(FEapStop));
                if (fEapStop == null)
                {
                    fEapStop = new FEapStop(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEapStop);
                }
                fEapStop.activate();

                // --

                eapList = grdEap.selectedDataRowKeys;
                eapDescList = new string[eapList.Length];
                // --
                for (int i = 0; i < eapList.Length; i++)
                {
                    eapDescList[i] = grdEap.getDataRow(eapList[i])["Description"].ToString();
                }
                // --
                fEapStop.attach(eapList, eapDescList);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapStop = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapAbort(
            )
        {
            FEapAbort fEapAbort = null;
            string[] eapList = null;
            string[] eapDescList = null;

            try
            {
                fEapAbort = (FEapAbort)m_fAdmCore.fAdmContainer.getChild(typeof(FEapAbort));
                if (fEapAbort == null)
                {
                    fEapAbort = new FEapAbort(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEapAbort);
                }
                fEapAbort.activate();

                // --

                eapList = grdEap.selectedDataRowKeys;
                eapDescList = new string[eapList.Length];
                // --
                for (int i = 0; i < eapList.Length; i++)
                {
                    eapDescList[i] = grdEap.getDataRow(eapList[i])["Description"].ToString();
                }
                // --
                fEapAbort.attach(eapList, eapDescList);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapAbort = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapMove(
            )
        {
            FEapMove fEapMove = null;

            try
            {
                fEapMove = (FEapMove)m_fAdmCore.fAdmContainer.getChild(typeof(FEapMove));
                if (fEapMove == null)
                {
                    fEapMove = new FEapMove(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEapMove);
                }
                fEapMove.activate();
                fEapMove.attach(grdEap.selectedDataRowKeys);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapMove = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapLogList(
            )
        {
            FEapLogList fEapLogList = null;

            try
            {
                fEapLogList = (FEapLogList)m_fAdmCore.fAdmContainer.getChild(typeof(FEapLogList));
                if (fEapLogList == null)
                {
                    fEapLogList = new FEapLogList(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEapLogList);
                }
                fEapLogList.activate();
                fEapLogList.attach(this.activeEap, this.activeType);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapLogList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapBackupLogList(
            )
        {
            FEapBackupLogList fEapBackupLogList = null;

            try
            {
                fEapBackupLogList = (FEapBackupLogList)m_fAdmCore.fAdmContainer.getChild(typeof(FEapBackupLogList));
                if (fEapBackupLogList == null)
                {
                    fEapBackupLogList = new FEapBackupLogList(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEapBackupLogList);
                }
                fEapBackupLogList.activate();
                fEapBackupLogList.attach(this.activeEap, this.activeType);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapBackupLogList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        //private void procMenuEapInterfaceLogList(
        //    )
        //{
        //    FEapInterfaceLogList fEapLogList = null;

        //    try
        //    {
        //        fEapLogList = (FEapInterfaceLogList)m_fAdmCore.fAdmContainer.getChild(typeof(FEapInterfaceLogList));
        //        if (fEapLogList == null)
        //        {
        //            fEapLogList = new FEapInterfaceLogList(m_fAdmCore);
        //            m_fAdmCore.fAdmContainer.showChild(fEapLogList);
        //        }
        //        fEapLogList.activate();
        //        fEapLogList.attach(this.activeEap, this.activeType);
        //    }
        //    catch (Exception ex)
        //    {
        //        FDebug.throwException(ex);
        //    }
        //    finally
        //    {
        //        fEapLogList = null;
        //    }
        //}

        ////------------------------------------------------------------------------------------------------------------------------

        //private void procMenuEapInterfaceBackupLogList(
        //    )
        //{
        //    FEapInterfaceBackupLogList fEapBackupLogList = null;

        //    try
        //    {
        //        fEapBackupLogList = (FEapInterfaceBackupLogList)m_fAdmCore.fAdmContainer.getChild(typeof(FEapInterfaceBackupLogList));
        //        if (fEapBackupLogList == null)
        //        {
        //            fEapBackupLogList = new FEapInterfaceBackupLogList(m_fAdmCore);
        //            m_fAdmCore.fAdmContainer.showChild(fEapBackupLogList);
        //        }
        //        fEapBackupLogList.activate();
        //        fEapBackupLogList.attach(this.activeEap, this.activeType);
        //    }
        //    catch (Exception ex)
        //    {
        //        FDebug.throwException(ex);
        //    }
        //    finally
        //    {
        //        fEapBackupLogList = null;
        //    }
        //}

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapReferenceSheet(
            )
        {
            FEapReferenceSheet fReferenceSheet = null;

            try
            {
                foreach (FBaseTabChildForm f in m_fAdmCore.fAdmContainer.fChilds)
                {
                    if (
                        f is FEapReferenceSheet &&
                        ((FEapReferenceSheet)f).eapName == this.activeEap
                        )
                    {
                        fReferenceSheet = (FEapReferenceSheet)f;
                        fReferenceSheet.refresh();
                        fReferenceSheet.activate();
                        return;
                    }
                }
                // --
                fReferenceSheet = new FEapReferenceSheet(m_fAdmCore, this.activeEap);
                m_fAdmCore.fAdmContainer.showChild(fReferenceSheet);
                fReferenceSheet.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fReferenceSheet = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Equipment Popup Menu

        private void procMenuEquipmentStatus(
            )
        {
            FEquipmentStatus fEquipmentStatus = null;

            try
            {
                fEquipmentStatus = (FEquipmentStatus)m_fAdmCore.fAdmContainer.getChild(typeof(FEquipmentStatus));
                if (fEquipmentStatus == null)
                {
                    fEquipmentStatus = new FEquipmentStatus(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEquipmentStatus);
                }
                fEquipmentStatus.activate();
                fEquipmentStatus.attach(this.activeEq, ucbCategory.Text);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEquipmentStatus = null;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------        

        #region FPackageStatus Form Event Handler

        private void FPackageStatus_Load(
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
                designGridOfPackageDetail();
                designGridOfEap();
                designGridOfEapDetail();
                // --
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

        private void FPackageStatus_Shown(
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

                txtVersion.Focus();
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

        private void FPackageStatus_FormClosing(
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

        private void FPackageStatus_KeyDown(
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

                if (e.Tool.Key == FMenuKey.MenuPksRefresh)
                {
                    refresh();
                }
                else if (e.Tool.Key == FMenuKey.MenuPksExport)
                {
                    export();
                }

                // --

                else if (e.Tool.Key == FMenuKey.MenuInqEapStatus)
                {
                    procMenuEapStatus();
                }
                else if (e.Tool.Key == FMenuKey.MenuInqEapHistory)
                {
                    procMenuEapHistory();
                }
                else if (e.Tool.Key == FMenuKey.MenuInqEapRepositoryStatus)
                {
                    procMenuEapRepositoryStatus();
                }
                else if (e.Tool.Key == FMenuKey.MenuInqEapResourceHistory)
                {
                    procMenuEapResourceHistory();
                }
                else if (e.Tool.Key == FMenuKey.MenuInqEapRelease)
                {
                    procMenuEapRelease();
                }
                else if (e.Tool.Key == FMenuKey.MenuInqEapStart)
                {
                    procMenuEapStart();
                }
                else if (e.Tool.Key == FMenuKey.MenuInqEapStop)
                {
                    procMenuEapStop();
                }
                else if (e.Tool.Key == FMenuKey.MenuInqEapReload)
                {
                    procMenuEapReload();
                }
                else if (e.Tool.Key == FMenuKey.MenuInqEapRestart)
                {
                    procMenuEapRestart();
                }
                else if (e.Tool.Key == FMenuKey.MenuInqEapAbort)
                {
                    procMenuEapAbort();
                }
                else if (e.Tool.Key == FMenuKey.MenuInqEapMove)
                {
                    procMenuEapMove();
                }
                else if (e.Tool.Key == FMenuKey.MenuInqEapLogList)
                {
                    procMenuEapLogList();
                }
                else if (e.Tool.Key == FMenuKey.MenuInqEapBackupLogList)
                {
                    procMenuEapBackupLogList();
                }
                //else if (e.Tool.Key == FMenuKey.MenuInqEapInterfaceLogList)
                //{
                //    procMenuEapInterfaceLogList();
                //}
                //else if (e.Tool.Key == FMenuKey.MenuInqEapInterfaceBackupLogList)
                //{
                //    procMenuEapInterfaceBackupLogList();
                //}
                else if (e.Tool.Key == FMenuKey.MenuInqEapReferenceSheet)
                {
                    procMenuEapReferenceSheet();
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

        #region grdDetail Control Event Handler

        private void grdDetail_ClickCellButton(
            object sender,
            Infragistics.Win.UltraWinGrid.CellEventArgs e
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            FPackageVersionFileViewer fPackageVersionFileViewer = null;
            List<FPackageVersionFile> pathList = null;
            FCommentViewer fCommentViewer = null;
            int nextRowNumber = 0;

            try
            {
                if (e.Cell.Row.Index == 2 && e.Cell.Column.Index == 5)
                {
                    pathList = new List<FPackageVersionFile>();

                    // --

                    fSqlParams = new FSqlParams();
                    fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                    fSqlParams.add("package", txtPackage.Text);
                    fSqlParams.add("pkg_ver", txtVersion.Text);
                    
                    // --

                    do
                    {
                        dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "PackageStatus", "ListPackageVerFile", fSqlParams, false, ref nextRowNumber);
                        // --
                        foreach (DataRow r in dt.Rows)
                        {
                            pathList.Add(new FPackageVersionFile(r[0].ToString(), r[1].ToString()));
                        }
                    } while (nextRowNumber >= 0);

                    // --

                    fPackageVersionFileViewer = new FPackageVersionFileViewer(m_fAdmCore, pathList.ToArray());
                    fPackageVersionFileViewer.ShowDialog();
                    e.Cell.ActiveAppearance.BackColor = Color.WhiteSmoke;
                }
                else if (e.Cell.Row.Index == 3 && e.Cell.Column.Index == 1)
                {
                    fCommentViewer = new FCommentViewer(m_fAdmCore, grdDetail.ActiveCell.Text);
                    fCommentViewer.ShowDialog();
                    e.Cell.ActiveAppearance.BackColor = Color.WhiteSmoke;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
                fPackageVersionFileViewer = null;
                pathList = null;
                fCommentViewer = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------        

        #region grdEap Control Event Handler

        private void grdEap_AfterRowActivate(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                foreach (UltraGridRow r in grdConfig.Rows)
                {
                    r.Hidden = true;
                }

                if (this.activeType == FEapType.SECS.ToString())
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
                else if (this.activeType == FEapType.OPC.ToString())
                {
                    grdConfig.Rows[5].Cells[0].Value = "OPC Log";
                    // --
                    grdConfig.Rows[4].Hidden = false;
                    grdConfig.Rows[5].Hidden = false;
                    grdConfig.Rows[7].Hidden = false;
                }
                else if (this.activeType == FEapType.TCP.ToString())
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
                else if (this.activeType == FEapType.FILE.ToString())
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

        private void grdEap_DoubleClickRow(
            object sender,
            Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                tabMain.SelectedTab = tabMain.Tabs["EapDetail"];

                // --

                grdEapDetail.Focus();
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

        private void grdEap_MouseDown(
            object sender, 
            MouseEventArgs e
            )
        {
            UltraGridRow r = null;
            string operMode = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                if (e.Button != MouseButtons.Right || grdEap.Rows.Count == 0)
                {
                    return;
                }

                // --

                r = (UltraGridRow)grdEap.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y)).
                    GetContext(typeof(UltraGridRow));
                if (r != null)
                {
                    grdEap.ActiveRow = grdEap.Rows[r.Index];
                }

                // --

                mnuMenu.Tools[FMenuKey.MenuInqEapStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapStatus);
                mnuMenu.Tools[FMenuKey.MenuInqEapHistory].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapHistory);
                // --
                mnuMenu.Tools[FMenuKey.MenuInqEapRepositoryStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapRepositoryStatus) ? true : false;
                // --
                mnuMenu.Tools[FMenuKey.MenuInqEapResourceHistory].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapResourceHistory);
                //--
                mnuMenu.Tools[FMenuKey.MenuInqEapRelease].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapRelease);
                mnuMenu.Tools[FMenuKey.MenuInqEapStart].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapStart);
                mnuMenu.Tools[FMenuKey.MenuInqEapStop].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapStop);
                mnuMenu.Tools[FMenuKey.MenuInqEapReload].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapReload);
                mnuMenu.Tools[FMenuKey.MenuInqEapRestart].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapRestart);
                mnuMenu.Tools[FMenuKey.MenuInqEapAbort].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapAbort);
                mnuMenu.Tools[FMenuKey.MenuInqEapMove].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapMove);
                // --
                mnuMenu.Tools[FMenuKey.MenuInqEapLogList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapLogList);
                mnuMenu.Tools[FMenuKey.MenuInqEapBackupLogList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapBackupLogList);
                // --
                // ***
                // 2017.06.02 by spike.lee
                // EAP Interface Log 관련 권한 추가
                // ***
                //mnuMenu.Tools[FMenuKey.MenuInqEapInterfaceLogList].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapInterfaceLogList) ? true : false;
                //mnuMenu.Tools[FMenuKey.MenuInqEapInterfaceBackupLogList].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapInterfaceBackupLogList) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuInqEapInterfaceLogList].SharedProps.Visible = false;
                mnuMenu.Tools[FMenuKey.MenuInqEapInterfaceBackupLogList].SharedProps.Visible = false;
                // --
                mnuMenu.Tools[FMenuKey.MenuInqEapReferenceSheet].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapReferenceSheet);

                // --

                #region Menu Control

                if (grdEap.ActiveRow != null)
                {
                    operMode = grdEap.activeDataRow["Operation Mode"].ToString();

                    // --

                    if (operMode == FEapOperationMode.Client.ToString())
                    {
                        mnuMenu.Tools[FMenuKey.MenuInqEapStart].SharedProps.Enabled = false;
                    }
                }

                #endregion

                // --

                mnuMenu.ShowPopup(FMenuKey.MenuInqEapPopupMenu);
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

        private void grdEap_AfterRowFilterChanged(
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

                grdEap.beginUpdate();

                // --

                grdEap.Selected.Rows.Clear();
                foreach (UltraGridRow r in e.Rows.GetFilteredInNonGroupByRows())
                {
                    if (r == grdEap.ActiveRow)
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
                grdEap.ActiveRow = e.Rows.GetRowAtVisibleIndex(activateIndex);
                grdEap.DisplayLayout.RowScrollRegions[0].ScrollRowIntoView(grdEap.ActiveRow);

                // --

                grdEap.endUpdate();

                // --

                refreshEapTotal();
            }
            catch (Exception ex)
            {
                grdEap.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region txtVersion Control Event Handler

        private void txtVersion_EditorButtonClick(
            object sender,
            EditorButtonEventArgs e
            )
        {
            FPackageVersionSelector fDialog = null;

            try
            {
                FCursor.waitCursor();

                // --

                fDialog = new FPackageVersionSelector(m_fAdmCore, txtPackage.Text, txtVersion.Text);
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                txtPackage.Text = fDialog.selectedPackage;
                txtPackage.Tag = fDialog.selectedType;
                txtVersion.Text = fDialog.selectedPackageVer;
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

                mnuMenu.Tools[FMenuKey.MenuInqEqpStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentStatus);
                mnuMenu.Tools[FMenuKey.MenuInqEqpHistory].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentHistory);                
                // --
                mnuMenu.Tools[FMenuKey.MenuInqEqpGemStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentGemStatus);
                // --
                mnuMenu.Tools[FMenuKey.MenuInqEqpEventDefineRequest].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentEventDefineRequest);
                mnuMenu.Tools[FMenuKey.MenuInqEqpVersionRequest].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentVersionRequest);
                mnuMenu.Tools[FMenuKey.MenuInqEqpControlModeRequest].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentControlModeRequest);
                mnuMenu.Tools[FMenuKey.MenuInqEqpCustomRemoteCommandRequest].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentControlModeRequest);
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

                if (!grdEap.searchGridRow(e.searchWord))
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
