/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FEapMonitor.cs
--  Creator         : mjkim
--  Create Date     : 2012.11.22
--  Description     : FAMate Admin Manager Monitor Form Class 
--  History         : Created by mjkim at 2012.11.22
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
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
    public partial class FEapMonitor : FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private string m_lastSelectedSchema = string.Empty;
        private bool m_isSearchMode = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEapMonitor(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEapMonitor(
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
                uds.Band.Columns.Add("RPM Count", typeof(int));
                uds.Band.Columns.Add("Type");
                uds.Band.Columns.Add("Operation Mode");
                uds.Band.Columns.Add("Server");
                uds.Band.Columns.Add("Step");
                uds.Band.Columns.Add("Up/Down");
                uds.Band.Columns.Add("Status");
                uds.Band.Columns.Add("Reload Count");
                uds.Band.Columns.Add("Need Action");
                uds.Band.Columns.Add("Next Need Action");
                uds.Band.Columns.Add("(Set) Package");
                uds.Band.Columns.Add("(Rel) Package"); 
                uds.Band.Columns.Add("(Apl) Package");
                uds.Band.Columns.Add("(Set) Model");
                uds.Band.Columns.Add("(Rel) Model");
                uds.Band.Columns.Add("(Apl) Model");
                uds.Band.Columns.Add("(Set) Component");
                uds.Band.Columns.Add("(Rel) Component");
                uds.Band.Columns.Add("(Apl) Component");

                // --

                grdEap.DisplayLayout.Bands[0].Columns["EAP"].Header.Fixed = true;
                // --
                grdEap.DisplayLayout.Bands[0].Columns["RPM Count"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdEap.DisplayLayout.Bands[0].Columns["Reload Count"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                // --
                grdEap.DisplayLayout.Bands[0].Columns["EAP"].Width = 120;
                grdEap.DisplayLayout.Bands[0].Columns["Description"].Width = 180;
                grdEap.DisplayLayout.Bands[0].Columns["RPM Count"].Width = 70;
                grdEap.DisplayLayout.Bands[0].Columns["Type"].Width = 80;
                grdEap.DisplayLayout.Bands[0].Columns["Operation Mode"].Width = 110;
                grdEap.DisplayLayout.Bands[0].Columns["Server"].Width = 100;
                grdEap.DisplayLayout.Bands[0].Columns["Step"].Width = 80;
                grdEap.DisplayLayout.Bands[0].Columns["Up/Down"].Width = 80;
                grdEap.DisplayLayout.Bands[0].Columns["Status"].Width = 80;
                grdEap.DisplayLayout.Bands[0].Columns["Reload Count"].Width = 80;
                grdEap.DisplayLayout.Bands[0].Columns["Need Action"].Width = 80;
                grdEap.DisplayLayout.Bands[0].Columns["Next Need Action"].Width = 80;
                grdEap.DisplayLayout.Bands[0].Columns["(Set) Package"].Width = 180;
                grdEap.DisplayLayout.Bands[0].Columns["(Rel) Package"].Width = 180;
                grdEap.DisplayLayout.Bands[0].Columns["(Apl) Package"].Width = 180;
                grdEap.DisplayLayout.Bands[0].Columns["(Set) Model"].Width = 180;
                grdEap.DisplayLayout.Bands[0].Columns["(Rel) Model"].Width = 180;
                grdEap.DisplayLayout.Bands[0].Columns["(Apl) Model"].Width = 180;
                grdEap.DisplayLayout.Bands[0].Columns["(Set) Component"].Width = 180;
                grdEap.DisplayLayout.Bands[0].Columns["(Rel) Component"].Width = 180;
                grdEap.DisplayLayout.Bands[0].Columns["(Apl) Component"].Width = 180;

                // --

                grdEap.ImageList = new ImageList();
                // --
                grdEap.ImageList.Images.Add("Eap_Secs_Main_Up", Properties.Resources.Eap_Secs_Main_Up);
                grdEap.ImageList.Images.Add("Eap_Secs_Main_Alarm", Properties.Resources.Eap_Secs_Main_Alarm);
                grdEap.ImageList.Images.Add("Eap_Secs_Main_Down", Properties.Resources.Eap_Secs_Main_Down);
                grdEap.ImageList.Images.Add("Eap_Secs_Backup_Up", Properties.Resources.Eap_Secs_Backup_Up);
                grdEap.ImageList.Images.Add("Eap_Secs_Backup_Alarm", Properties.Resources.Eap_Secs_Backup_Alarm);
                grdEap.ImageList.Images.Add("Eap_Secs_Backup_Down", Properties.Resources.Eap_Secs_Backup_Down);
                grdEap.ImageList.Images.Add("Eap_Plc_Main_Up", Properties.Resources.Eap_Plc_Main_Up);
                grdEap.ImageList.Images.Add("Eap_Plc_Main_Alarm", Properties.Resources.Eap_Plc_Main_Alarm);
                grdEap.ImageList.Images.Add("Eap_Plc_Main_Down", Properties.Resources.Eap_Plc_Main_Down);
                grdEap.ImageList.Images.Add("Eap_Plc_Backup_Up", Properties.Resources.Eap_Plc_Backup_Up);
                grdEap.ImageList.Images.Add("Eap_Plc_Backup_Alarm", Properties.Resources.Eap_Plc_Backup_Alarm);
                grdEap.ImageList.Images.Add("Eap_Plc_Backup_Down", Properties.Resources.Eap_Plc_Backup_Down);
                grdEap.ImageList.Images.Add("Eap_Opc_Main_Up", Properties.Resources.Eap_Opc_Main_Up);
                grdEap.ImageList.Images.Add("Eap_Opc_Main_Alarm", Properties.Resources.Eap_Opc_Main_Alarm);
                grdEap.ImageList.Images.Add("Eap_Opc_Main_Down", Properties.Resources.Eap_Opc_Main_Down);
                grdEap.ImageList.Images.Add("Eap_Opc_Backup_Up", Properties.Resources.Eap_Opc_Backup_Up);
                grdEap.ImageList.Images.Add("Eap_Opc_Backup_Alarm", Properties.Resources.Eap_Opc_Backup_Alarm);
                grdEap.ImageList.Images.Add("Eap_Opc_Backup_Down", Properties.Resources.Eap_Opc_Backup_Down);
                grdEap.ImageList.Images.Add("Eap_Tcp_Main_Up", Properties.Resources.Eap_Tcp_Main_Up);
                grdEap.ImageList.Images.Add("Eap_Tcp_Main_Alarm", Properties.Resources.Eap_Tcp_Main_Alarm);
                grdEap.ImageList.Images.Add("Eap_Tcp_Main_Down", Properties.Resources.Eap_Tcp_Main_Down);
                grdEap.ImageList.Images.Add("Eap_Tcp_Backup_Up", Properties.Resources.Eap_Tcp_Backup_Up);
                grdEap.ImageList.Images.Add("Eap_Tcp_Backup_Alarm", Properties.Resources.Eap_Tcp_Backup_Alarm);
                grdEap.ImageList.Images.Add("Eap_Tcp_Backup_Down", Properties.Resources.Eap_Tcp_Backup_Down);
                grdEap.ImageList.Images.Add("Eap_Process_Main_Up", Properties.Resources.Eap_Process_Main_Up);
                grdEap.ImageList.Images.Add("Eap_Process_Main_Alarm", Properties.Resources.Eap_Process_Main_Alarm);
                grdEap.ImageList.Images.Add("Eap_Process_Main_Down", Properties.Resources.Eap_Process_Main_Down);
                grdEap.ImageList.Images.Add("Eap_Process_Backup_Up", Properties.Resources.Eap_Process_Backup_Up);
                grdEap.ImageList.Images.Add("Eap_Process_Backup_Alarm", Properties.Resources.Eap_Process_Backup_Alarm);
                grdEap.ImageList.Images.Add("Eap_Process_Backup_Down", Properties.Resources.Eap_Process_Backup_Down);
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

        private void designGridOfEapClass(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdClass.dataSource;
                // --
                uds.Band.Columns.Add("Name");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Server Type");
                uds.Band.Columns.Add("Server IP");
                uds.Band.Columns.Add("Agent");
                uds.Band.Columns.Add("OPC Server");
                uds.Band.Columns.Add("Type");

                // --
                
                grdClass.DisplayLayout.Bands[0].Columns["Name"].Width = 100;
                grdClass.DisplayLayout.Bands[0].Columns["Description"].Width = 180;
                grdClass.DisplayLayout.Bands[0].Columns["Server Type"].Width = 90;
                grdClass.DisplayLayout.Bands[0].Columns["Server IP"].Width = 120;
                grdClass.DisplayLayout.Bands[0].Columns["Agent"].Width = 90;
                grdClass.DisplayLayout.Bands[0].Columns["OPC Server"].Width = 90;
                grdClass.DisplayLayout.Bands[0].Columns["Type"].Width = 80;
                // --
                grdClass.DisplayLayout.Bands[0].Columns["Type"].Hidden = true;

                // --

                uds.Band.ChildBands.Add("Version");
                // --
                uds.Band.ChildBands["Version"].Columns.Add("Version");
                uds.Band.ChildBands["Version"].Columns.Add("Description");
                // --
                grdClass.DisplayLayout.Bands["Version"].Columns["Version"].Width = 100;
                grdClass.DisplayLayout.Bands["Version"].Columns["Description"].Width = 180;

                // --

                grdClass.DisplayLayout.ViewStyleBand = ViewStyleBand.Vertical;

                // --

                grdClass.ImageList = new ImageList();
                // --
                grdClass.ImageList.Images.Add("Server_Main_Up", Properties.Resources.Server_Main_Up);
                grdClass.ImageList.Images.Add("Server_Main_Alarm", Properties.Resources.Server_Main_Alarm);
                grdClass.ImageList.Images.Add("Server_Main_Down", Properties.Resources.Server_Main_Down);
                grdClass.ImageList.Images.Add("Server_Backup_Up", Properties.Resources.Server_Backup_Up);
                grdClass.ImageList.Images.Add("Server_Backup_Alarm", Properties.Resources.Server_Backup_Alarm);
                grdClass.ImageList.Images.Add("Server_Backup_Down", Properties.Resources.Server_Backup_Down);
                grdClass.ImageList.Images.Add("Package", Properties.Resources.Package);
                grdClass.ImageList.Images.Add("Package_Secs", Properties.Resources.Package_Secs);
                grdClass.ImageList.Images.Add("Package_Plc", Properties.Resources.Package_Plc);
                grdClass.ImageList.Images.Add("Package_Opc", Properties.Resources.Package_Opc);
                grdClass.ImageList.Images.Add("Package_Tcp", Properties.Resources.Package_Tcp);
                grdClass.ImageList.Images.Add("PackageVersion", Properties.Resources.PackageVersion);
                grdClass.ImageList.Images.Add("PackageVersion_Secs", Properties.Resources.PackageVersion_Secs);
                grdClass.ImageList.Images.Add("PackageVersion_Plc", Properties.Resources.PackageVersion_Plc);
                grdClass.ImageList.Images.Add("PackageVersion_Opc", Properties.Resources.PackageVersion_Opc);
                grdClass.ImageList.Images.Add("PackageVersion_Tcp", Properties.Resources.PackageVersion_Tcp);
                grdClass.ImageList.Images.Add("Model", Properties.Resources.Model);
                grdClass.ImageList.Images.Add("Model_Secs", Properties.Resources.Model_Secs);
                grdClass.ImageList.Images.Add("Model_Plc", Properties.Resources.Model_Plc);
                grdClass.ImageList.Images.Add("Model_Opc", Properties.Resources.Model_Opc);
                grdClass.ImageList.Images.Add("Model_Tcp", Properties.Resources.Model_Tcp);
                grdClass.ImageList.Images.Add("ModelVersion", Properties.Resources.ModelVersion);
                grdClass.ImageList.Images.Add("ModelVersion_Secs", Properties.Resources.ModelVersion_Secs);
                grdClass.ImageList.Images.Add("ModelVersion_Plc", Properties.Resources.ModelVersion_Plc);
                grdClass.ImageList.Images.Add("ModelVersion_Opc", Properties.Resources.ModelVersion_Opc);
                grdClass.ImageList.Images.Add("ModelVersion_Tcp", Properties.Resources.ModelVersion_Tcp);
                grdClass.ImageList.Images.Add("Component", Properties.Resources.Component);
                grdClass.ImageList.Images.Add("Component_Secs", Properties.Resources.Component_Secs);
                grdClass.ImageList.Images.Add("Component_Plc", Properties.Resources.Component_Plc);
                grdClass.ImageList.Images.Add("Component_Opc", Properties.Resources.Component_Opc);
                grdClass.ImageList.Images.Add("Component_Tcp", Properties.Resources.Component_Tcp);
                grdClass.ImageList.Images.Add("ComponentVersion", Properties.Resources.ComponentVersion);
                grdClass.ImageList.Images.Add("ComponentVersion_Secs", Properties.Resources.ComponentVersion_Secs);
                grdClass.ImageList.Images.Add("ComponentVersion_Plc", Properties.Resources.ComponentVersion_Plc);
                grdClass.ImageList.Images.Add("ComponentVersion_Opc", Properties.Resources.ComponentVersion_Opc);
                grdClass.ImageList.Images.Add("ComponentVersion_Tcp", Properties.Resources.ComponentVersion_Tcp);
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

        private Image getImageOfServer(
            string upDown,
            string status,
            string alarm
            )
        {
            try
            {
                if (status == FServerStatusEnum.Main.ToString())
                {
                    if (upDown == FUpDown.Down.ToString())
                    {
                        return grdClass.ImageList.Images["Server_Main_Down"];
                    }
                    else if (alarm == FYesNo.Yes.ToString())
                    {
                        return grdClass.ImageList.Images["Server_Main_Alarm"];
                    }
                    else
                    {
                        return grdClass.ImageList.Images["Server_Main_Up"];
                    }
                }
                else if (status == FServerStatusEnum.Backup.ToString())
                {
                    if (upDown == FUpDown.Down.ToString())
                    {
                        return grdClass.ImageList.Images["Server_Backup_Down"];
                    }
                    else if (alarm == FYesNo.Yes.ToString())
                    {
                        return grdClass.ImageList.Images["Server_Backup_Alarm"];
                    }
                    else
                    {
                        return grdClass.ImageList.Images["Server_Backup_Up"];
                    }
                }                
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

        private void refreshEapTotal(
            )
        {
            try
            {
                lblEapTotal.Text = grdEap.Rows.Count.ToString("#,##0");
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

        private void refreshClassGridOfServer(
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
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Tool", "EapMonitor", "ListServer", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // Server
                            r[1].ToString(),   // Description
                            r[2].ToString(),   // Server Type
                            r[3].ToString(),   // Server Ip
                            r[4].ToString(),   // Agent
                            r[5].ToString()    // OPC Server
                            };
                        key = (string)cellValues[0];
                        index = grdClass.appendDataRow(key, cellValues).Index;

                        // --

                        row = grdClass.Rows.GetRowWithListIndex(index);

                        // --

                        cell = row.Cells["Name"];
                        cell.Appearance.Image = getImageOfServer(r[6].ToString(), r[7].ToString(), r[8].ToString());

                        // --

                        if (r[6].ToString() == FUpDown.Down.ToString())
                        {
                            row.Appearance.BackColor = Color.FromArgb(233, 233, 233);
                        }
                        else if (r[8].ToString() == FYesNo.Yes.ToString())
                        {
                            row.Appearance.BackColor = Color.FromArgb(255, 221, 211);
                        }
                        else
                        {
                            row.Appearance.BackColor = Color.WhiteSmoke;
                        }  
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

        private void refreshClassGridOfPackage(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            UltraDataRow drPkg = null;
            UltraDataRow drVer = null;
            UltraGridCell cell = null;
            string beforeKey = string.Empty;
            string beforeVer = string.Empty;
            string package = string.Empty;
            object[] cellValues = null;
            int nextRowNumber = 0;

            try
            {
                if (grdClass.ActiveRow != null)
                {
                    if (grdClass.ActiveRow.Band.Key == "Version")
                    {
                        beforeKey = grdClass.ActiveRow.ParentRow.Cells["Name"].Text;
                        beforeVer = grdClass.ActiveRow.Tag.ToString();
                    }
                    else
                    {
                        beforeKey = grdClass.activeDataRowKey;
                        beforeVer = string.Empty;
                    }
                }

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
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Tool", "EapMonitor", "ListPackage", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        package = r[0].ToString();  // Package

                        // --

                        // ***
                        // Append Package Row
                        // ***
                        if (!grdClass.containsDataRow(package))
                        {
                            cellValues = new object[] {
                                package,          // Eap Package
                                r[1].ToString(),  // Package Description
                                null,             // Server Type
                                null,             // Server Ip
                                null,             // Agent
                                null,             // OPC Server
                                r[5].ToString()   // Type                           
                                };
                            drPkg = grdClass.appendDataRow(package, cellValues);
                            grdClass.Rows[drPkg.Index].Tag = r[6].ToString();   // Released Version 

                            // --

                            cell = grdClass.Rows[drPkg.Index].Cells["Name"];
                            cell.Appearance.Image = FCommon.getImageOfPackage(grdClass, r[5].ToString());
                            // --
                            drPkg.GetChildRows("Version").Clear();
                        }

                        // --

                        // ***
                        // Append Package Version Row
                        // ***
                        if (r[2].ToString() != string.Empty)
                        {
                            cellValues = new object[] {
                                r[2].ToString(), // Package Version
                                r[3].ToString()  // Package Version Description
                                };
                            drVer = drPkg.GetChildRows("Version").Add(cellValues);                            
                            grdClass.Rows[drPkg.Index].ChildBands["Version"].Rows[drVer.Index].Tag = r[2].ToString(); // Packagte Version

                            // --

                            // ***
                            // Released Version 표기
                            // ***
                            if (r[4].ToString() == FYesNo.Yes.ToString())
                            {
                                grdClass.Rows[drPkg.Index].ChildBands["Version"].Rows[drVer.Index].Cells["Version"].Value += "*";
                            }

                            // --

                            cell = grdClass.Rows[drPkg.Index].ChildBands["Version"].Rows[drVer.Index].Cells["Version"];
                            cell.Appearance.Image = FCommon.getImageOfPackageVersion(grdClass, r[5].ToString());
                        }
                    }
                } while (nextRowNumber >= 0);

                // --

                grdClass.endUpdate(false);
                grdClass.DisplayLayout.Bands[0].SortedColumns.Add("Name", false);

                // --

                // ***
                // Activate Row 찾기
                // ***
                if (grdClass.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        if (beforeVer == string.Empty)
                        {
                            grdClass.activateDataRow(beforeKey);
                        }
                        else
                        {
                            if (grdClass.getDataRowIndex(beforeKey) >= 0)
                            {
                                foreach (UltraGridRow r in grdClass.Rows[grdClass.getDataRowIndex(beforeKey)].ChildBands["Version"].Rows)
                                {
                                    if (beforeVer == r.Tag.ToString())
                                    {
                                        r.Activate();
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    // --

                    if (grdClass.ActiveRow == null)
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
                drPkg = null;
                drVer = null;
                cell = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshClassGridOfModel(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            UltraDataRow drMdl = null;
            UltraDataRow drVer = null;
            UltraGridCell cell = null;
            string beforeKey = string.Empty;
            string beforeVer = string.Empty;
            string model = string.Empty;
            object[] cellValues = null;
            int nextRowNumber = 0;

            try
            {
                if (grdClass.ActiveRow != null)
                {
                    if (grdClass.ActiveRow.Band.Key == "Version")
                    {
                        beforeKey = grdClass.ActiveRow.ParentRow.Cells["Name"].Text.ToString();
                        beforeVer = grdClass.ActiveRow.Tag.ToString();
                    }
                    else
                    {
                        beforeKey = grdClass.activeDataRowKey;
                        beforeVer = string.Empty;
                    }
                }

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
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Tool", "EapMonitor", "ListModel", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        model = r[0].ToString();  // Model

                        // --

                        // ***
                        // Append Model Row
                        // ***
                        if (!grdClass.containsDataRow(model))
                        {
                            cellValues = new object[] {
                                model,             // Model
                                r[1].ToString(),      // Model Description
                                null,                 // Server Type
                                null,                 // Server Ip
                                null,                 // Agent
                                null,                 // OPC Server
                                r[5].ToString()       // Type   
                                };
                            drMdl = grdClass.appendDataRow(model, cellValues);
                            grdClass.Rows[drMdl.Index].Tag = r[6].ToString();   // Released Version

                            // --

                            cell = grdClass.Rows[drMdl.Index].Cells["Name"];
                            cell.Appearance.Image = FCommon.getImageOfModel(grdClass, r[5].ToString());
                            // --
                            drMdl.GetChildRows("Version").Clear();
                        }

                        // --

                        // ***
                        // Append Model Version Row
                        // ***
                        if (r[2].ToString() != string.Empty)
                        {
                            cellValues = new object[] {
                                r[2].ToString(), // Model Version
                                r[3].ToString()  // Model Version Description
                                };
                            drVer = drMdl.GetChildRows("Version").Add(cellValues);
                            grdClass.Rows[drMdl.Index].ChildBands["Version"].Rows[drVer.Index].Tag = r[2].ToString();   // Model Version

                            // --

                            // ***
                            // Active Version 표기
                            // ***
                            if (r[4].ToString() == FYesNo.Yes.ToString())
                            {
                                grdClass.Rows[drMdl.Index].ChildBands["Version"].Rows[drVer.Index].Cells["Version"].Value += "*";
                            }

                            // --

                            cell = grdClass.Rows[drMdl.Index].ChildBands["Version"].Rows[drVer.Index].Cells["Version"];
                            cell.Appearance.Image = FCommon.getImageOfModelVersion(grdClass, r[5].ToString());
                        }
                    }
                } while (nextRowNumber >= 0);

                // --

                grdClass.endUpdate(false);
                grdClass.DisplayLayout.Bands[0].SortedColumns.Add("Name", false);

                // --

                // ***
                // Activate Row 찾기
                // ***
                if (grdClass.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        if (beforeVer == string.Empty)
                        {
                            grdClass.activateDataRow(beforeKey);
                        }
                        else
                        {
                            if (grdClass.getDataRowIndex(beforeKey) >= 0)
                            {
                                foreach (UltraGridRow r in grdClass.Rows[grdClass.getDataRowIndex(beforeKey)].ChildBands["Version"].Rows)
                                {
                                    if (beforeVer == r.Tag.ToString())
                                    {
                                        r.Activate();
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    // --

                    if (grdClass.ActiveRow == null)
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
                drMdl = null;
                drVer = null;
                cell = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshClassGridOfComponent(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            UltraDataRow drCom = null;
            UltraDataRow drVer = null;
            UltraGridCell cell = null;
            string beforeKey = string.Empty;
            string beforeVer = string.Empty;
            string component = string.Empty;
            object[] cellValues = null;
            int nextRowNumber = 0;

            try
            {
                if (grdClass.ActiveRow != null)
                {
                    if (grdClass.ActiveRow.Band.Key == "Version")
                    {
                        beforeKey = grdClass.ActiveRow.ParentRow.Cells["Name"].Text.ToString();
                        beforeVer = grdClass.ActiveRow.Tag.ToString();
                    }
                    else
                    {
                        beforeKey = grdClass.activeDataRowKey;
                        beforeVer = string.Empty;
                    }
                }

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
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Tool", "EapMonitor", "ListComponent", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        component = r[0].ToString();  // Component
                        
                        // --

                        // ***
                        // Append Component Row
                        // ***
                        if (!grdClass.containsDataRow(component))
                        {
                            cellValues = new object[] {
                                component,        // Component
                                r[1].ToString(),  // Component Description
                                null,             // Server Type
                                null,             // Server Ip
                                null,             // Agent
                                null,             // OPC Server
                                r[5].ToString()   // Type   
                                };
                            drCom = grdClass.appendDataRow(component, cellValues);
                            grdClass.Rows[drCom.Index].Tag = r[6].ToString();   // Released Version

                            // --

                            cell = grdClass.Rows[drCom.Index].Cells["Name"];
                            cell.Appearance.Image = FCommon.getImageOfComponent(grdClass, r[5].ToString());
                            // --
                            drCom.GetChildRows("Version").Clear();
                        }

                        // --

                        // ***
                        // Append Component Version Row
                        // ***
                        if (r[2].ToString() != string.Empty)
                        {
                            cellValues = new object[] {
                                r[2].ToString(), // Component Version
                                r[3].ToString()  // Component Version Description
                                };
                            drVer = drCom.GetChildRows("Version").Add(cellValues);
                            grdClass.Rows[drCom.Index].ChildBands["Version"].Rows[drVer.Index].Tag = r[2].ToString();   // Component Version

                            // --

                            // ***
                            // Active Version 표시
                            // ***
                            if (r[4].ToString() == FYesNo.Yes.ToString())
                            {
                                grdClass.Rows[drCom.Index].ChildBands["Version"].Rows[drVer.Index].Cells["Version"].Value += "*";
                            }

                            // --

                            cell = grdClass.Rows[drCom.Index].ChildBands["Version"].Rows[drVer.Index].Cells["Version"];
                            cell.Appearance.Image = FCommon.getImageOfComponentVersion(grdClass, r[5].ToString());
                        }
                    }
                } while (nextRowNumber >= 0);

                // --

                grdClass.endUpdate(false);
                grdClass.DisplayLayout.Bands[0].SortedColumns.Add("Name", false);

                // --

                // ***
                // Activate Row 찾기
                // ***
                if (grdClass.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        if (beforeVer == string.Empty)
                        {
                            grdClass.activateDataRow(beforeKey);
                        }
                        else
                        {
                            if (grdClass.getDataRowIndex(beforeKey) >= 0)
                            {
                                foreach (UltraGridRow r in grdClass.Rows[grdClass.getDataRowIndex(beforeKey)].ChildBands["Version"].Rows)
                                {
                                    if (beforeVer == r.Tag.ToString())
                                    {
                                        r.Activate();
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    // --

                    if (grdClass.ActiveRow == null)
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
                drCom = null;
                drVer = null;
                cell = null;
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
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Tool", "EapMonitor", "ListEquipmentType", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // Equipment Type
                            r[1].ToString(),   // Description                            
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
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Tool", "EapMonitor", "ListEquipmentArea", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // Equipment Area
                            r[1].ToString(),   // Description                            
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
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Tool", "EapMonitor", "ListEquipmentLine", fSqlParams, false, ref nextRowNumber);
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

        private void refreshGridOfEap(
            )
        {
            string tabKey = string.Empty;

            try
            {
                if (!grdClass.Enabled)
                {
                    refreshGridOfEapAtr();
                }
                else
                {
                    tabKey = tabMain.ActiveTab.Key;
                    if (
                        tabKey == "Server" ||
                        tabKey == "Package" ||
                        tabKey == "Model" ||
                        tabKey == "Component"
                        )
                    {
                        refreshGridOfEapAtr();
                    }
                    else
                    {
                        refreshGridOfEquipmentAtr();
                    }
                }      
          
                // -- 

                m_isSearchMode = false;
            }
            catch (Exception ex)
            {
                grdEap.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                refreshEapTotal();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfEapAtr(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            UltraGridRow row = null;
            UltraGridCell cell = null;
            string rpmCnt = string.Empty;
            string server = string.Empty;
            string pkg = string.Empty;
            string pkgVer = string.Empty;
            string mdl = string.Empty;
            string mdlVer = string.Empty;
            string com = string.Empty;
            string comVer = string.Empty;            
            object[] cellValues = null;
            string beforeKey = string.Empty;
            string key = string.Empty;
            int nextRowNumber = 0;
            int index = 0;
            string eapType = string.Empty;
            string eapUpDown = string.Empty;
            string eapStatus = string.Empty;
            string eapAlarm = string.Empty;
            string set_Package = string.Empty;
            string rel_Package = string.Empty;
            string apl_Package = string.Empty;
            string set_Model = string.Empty;
            string rel_Model = string.Empty;
            string apl_Model = string.Empty;
            string set_Component = string.Empty;
            string rel_Component = string.Empty;
            string apl_Component = string.Empty;

            try
            {
                tvwSchema.beginUpdate();
                tvwSchema.Nodes.Clear();
                tvwSchema.endUpdate();
                // --
                pgdSchema.selectedObject = null;

                // --

                beforeKey = grdEap.activeDataRowKey;
                // --
                grdEap.beginUpdate(false);
                grdEap.removeAllDataRow();
                grdEap.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                if (grdClass.ActiveRow == null)
                {
                    grdEap.endUpdate(false);
                    return;
                }

                // --

                if (grdClass.Enabled == true)
                {
                    if (tabMain.ActiveTab.Key == "Server")
                    {
                        server = grdClass.activeDataRowKey;
                    }
                    else if (tabMain.ActiveTab.Key == "Package")
                    {
                        if (grdClass.ActiveRow.ParentRow == null)
                        {
                            pkg = grdClass.activeDataRowKey;
                        }
                        else
                        {
                            pkg = (string)grdClass.ActiveRow.ParentRow.Cells[0].Text;
                            pkgVer = (string)grdClass.ActiveRow.Tag;
                        }
                    }
                    else if (tabMain.ActiveTab.Key == "Model")
                    {
                        if (grdClass.ActiveRow.ParentRow == null)
                        {
                            mdl = grdClass.activeDataRowKey;
                        }
                        else
                        {
                            mdl = (string)grdClass.ActiveRow.ParentRow.Cells[0].Text;
                            mdlVer = (string)grdClass.ActiveRow.Tag;
                        }
                    }
                    else if (tabMain.ActiveTab.Key == "Component")
                    {
                        if (grdClass.ActiveRow.ParentRow == null)
                        {
                            com = grdClass.activeDataRowKey;
                        }
                        else
                        {
                            com = (string)grdClass.ActiveRow.ParentRow.Cells[0].Text;
                            comVer = (string)grdClass.ActiveRow.Tag;
                        }
                    }                    
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("server", server, server == string.Empty ? true : false);
                fSqlParams.add("package", pkg, pkg == string.Empty ? true : false);
                fSqlParams.add("pkg_ver", pkgVer, pkgVer == string.Empty ? true : false);
                fSqlParams.add("model", mdl, mdl == string.Empty ? true : false);
                fSqlParams.add("mdl_ver", mdlVer, mdlVer == string.Empty ? true : false);
                fSqlParams.add("component", com, com == string.Empty ? true : false);
                fSqlParams.add("com_ver", comVer, comVer == string.Empty ? true : false);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Tool", "EapMonitor", "ListEapOfEapAtr", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        eapType = r[2].ToString();
                        eapUpDown = r[6].ToString();
                        eapStatus = r[7].ToString();
                        eapAlarm = r[9].ToString();

                        // --

                        set_Package = FCommon.generateStringForPackage(r[12].ToString(), r[13].ToString());
                        rel_Package = FCommon.generateStringForPackage(r[14].ToString(), r[15].ToString());
                        apl_Package = FCommon.generateStringForPackage(r[16].ToString(), r[17].ToString());
                        set_Model = FCommon.generateStringForModel(r[18].ToString(), r[19].ToString());
                        rel_Model = FCommon.generateStringForModel(r[20].ToString(), r[21].ToString());
                        apl_Model = FCommon.generateStringForModel(r[22].ToString(), r[23].ToString());
                        set_Component = FCommon.generateStringForComponent(r[24].ToString(), r[25].ToString(), r[26].ToString());
                        rel_Component = FCommon.generateStringForComponent(r[27].ToString(), r[28].ToString(), r[29].ToString());
                        apl_Component = FCommon.generateStringForComponent(r[30].ToString(), r[31].ToString(), r[32].ToString());
                        // --
                        rpmCnt = r[33].ToString();

                        // --

                        cellValues = new object[] {
                            r[0].ToString(),   // Eap
                            r[1].ToString(),   // Description    
                            rpmCnt,            // RPM Count (2017.06.07 by spike.lee add)
                            eapType,           // Type
                            r[3].ToString(),   // Oper Mode
                            r[4].ToString(),   // Server
                            r[5].ToString(),   // Step
                            eapUpDown,         // Up/Down
                            eapStatus,         // Status
                            r[8].ToString(),   // Reload Count
                            r[10].ToString(),  // Need Action
                            r[11].ToString(),  // Next Need Action
                            set_Package,       // (Set) Package
                            rel_Package,       // (Rel) Package
                            apl_Package,       // (Apl) Package
                            set_Model,         // (Set) Model
                            rel_Model,         // (Rel) Model
                            apl_Model,         // (Apl) Model
                            set_Component,     // (Set) Component
                            rel_Component,     // (Rel) Component
                            apl_Component      // (Apl) Component
                            };
                        key = (string)cellValues[0];
                        index = grdEap.appendDataRow(key, cellValues).Index;

                        // --

                        row = grdEap.Rows.GetRowWithListIndex(index);

                        // --

                        cell = row.Cells["EAP"];
                        cell.Appearance.Image = FCommon.getImageOfEap(grdEap, eapType, eapUpDown, eapStatus, eapAlarm);

                        // --

                        if (eapUpDown == FUpDown.Down.ToString())
                        {
                            row.Appearance.BackColor = Color.FromArgb(233, 233, 233);
                        }
                        else if (eapAlarm == FYesNo.Yes.ToString())
                        {
                            row.Appearance.BackColor = Color.FromArgb(255, 221, 211);
                        }
                        else
                        {
                            row.Appearance.BackColor = Color.WhiteSmoke;
                        }

                        // --

                        if (rpmCnt != "0")
                        {
                            cell = row.Cells["RPM Count"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        }

                        // --

                        cell = row.Cells["Step"];
                        if (cell.Text != FEapAttrCategory.Applied.ToString())
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
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

                        cell = row.Cells["Status"];
                        if (cell.Text == "Backup")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }

                        // --

                        cell = row.Cells["Need Action"];
                        if (cell.Text.Trim() != "")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                        }

                        // --

                        cell = row.Cells["Next Need Action"];
                        if (cell.Text.Trim() != "")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                        }

                        // --

                        if (!FCommon.stringEquals(set_Package, rel_Package, apl_Package))
                        {
                            cell = row.Cells["(Set) Package"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                            cell = row.Cells["(Rel) Package"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                            cell = row.Cells["(Apl) Package"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                        }
                        // --
                        cell = row.Cells["(Set) Package"];
                        if (cell.Text == "N/A")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }
                        // --
                        cell = row.Cells["(Rel) Package"];
                        if (cell.Text == "N/A")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }
                        // --
                        cell = row.Cells["(Apl) Package"];
                        if (cell.Text == "N/A")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }

                        // --

                        if (!FCommon.stringEquals(set_Model, rel_Model, apl_Model))
                        {
                            cell = row.Cells["(Set) Model"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                            cell = row.Cells["(Rel) Model"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                            cell = row.Cells["(Apl) Model"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                        }
                        // --
                        cell = row.Cells["(Set) Model"];
                        cell.Tag = r[16].ToString();
                        if (cell.Text == "N/A")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }
                        // --
                        cell = row.Cells["(Rel) Model"];
                        cell.Tag = r[18].ToString();
                        if (cell.Text == "N/A")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }
                        // --
                        cell = row.Cells["(Apl) Model"];
                        cell.Tag = r[20].ToString();
                        if (cell.Text == "N/A")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }

                        // --

                        if (!FCommon.stringEquals(set_Component, rel_Component, apl_Component))
                        {
                            cell = row.Cells["(Set) Component"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                            cell = row.Cells["(Rel) Component"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                            cell = row.Cells["(Apl) Component"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                        }
                        // --
                        cell = row.Cells["(Set) Component"];
                        if (cell.Text == "N/A")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }
                        // --
                        cell = row.Cells["(Rel) Component"];
                        if (cell.Text == "N/A")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }
                        // --
                        cell = row.Cells["(Apl) Component"];
                        if (cell.Text == "N/A")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }
                    }
                } while (nextRowNumber >= 0);

                // --

                grdEap.endUpdate(false);
                grdEap.DisplayLayout.Bands[0].SortedColumns.Add("EAP", false);

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
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfEquipmentAtr(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            UltraGridRow row = null;
            UltraGridCell cell = null;
            string rpmCnt = string.Empty;
            string eqpType = string.Empty;
            string eqpArea = string.Empty;
            string eqpLine = string.Empty;
            object[] cellValues = null;
            string beforeKey = string.Empty;
            string key = string.Empty;
            int nextRowNumber = 0;
            int index = 0;
            string eapType = string.Empty;
            string eapUpDown = string.Empty;
            string eapStatus = string.Empty;
            string eapAlarm = string.Empty;
            string set_Package = string.Empty;
            string rel_Package = string.Empty;
            string apl_Package = string.Empty;
            string set_Model = string.Empty;
            string rel_Model = string.Empty;
            string apl_Model = string.Empty;
            string set_Component = string.Empty;
            string rel_Component = string.Empty;
            string apl_Component = string.Empty;

            try
            {
                tvwSchema.beginUpdate();
                tvwSchema.Nodes.Clear();
                tvwSchema.endUpdate();
                // --
                pgdSchema.selectedObject = null;

                // --

                beforeKey = grdEap.activeDataRowKey;
                // --
                grdEap.beginUpdate(false);
                grdEap.removeAllDataRow();
                grdEap.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                if (grdClass.ActiveRow == null)
                {
                    grdEap.endUpdate(false);
                    return;
                }

                // --

                if (tabMain.ActiveTab.Key == "Equipment Type")
                {
                    eqpType = grdClass.activeDataRowKey;
                }
                else if (tabMain.ActiveTab.Key == "Equipment Area")
                {
                    eqpArea = grdClass.activeDataRowKey;
                }
                else if (tabMain.ActiveTab.Key == "Equipment Line")
                {
                    eqpLine = grdClass.activeDataRowKey;
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("type", eqpType, eqpType == string.Empty ? true : false);
                fSqlParams.add("area", eqpArea, eqpArea == string.Empty ? true : false);
                fSqlParams.add("line", eqpLine, eqpLine == string.Empty ? true : false);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Tool", "EapMonitor", "ListEapOfEquipmentAtr", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        eapType = r[2].ToString();
                        eapUpDown = r[6].ToString();
                        eapStatus = r[7].ToString();
                        eapAlarm = r[9].ToString();

                        // --

                        set_Package = FCommon.generateStringForPackage(r[12].ToString(), r[13].ToString());
                        rel_Package = FCommon.generateStringForPackage(r[14].ToString(), r[15].ToString());
                        apl_Package = FCommon.generateStringForPackage(r[16].ToString(), r[17].ToString());
                        set_Model = FCommon.generateStringForModel(r[18].ToString(), r[19].ToString());
                        rel_Model = FCommon.generateStringForModel(r[20].ToString(), r[21].ToString());
                        apl_Model = FCommon.generateStringForModel(r[22].ToString(), r[23].ToString());
                        set_Component = FCommon.generateStringForComponent(r[24].ToString(), r[25].ToString(), r[26].ToString());
                        rel_Component = FCommon.generateStringForComponent(r[27].ToString(), r[28].ToString(), r[29].ToString());
                        apl_Component = FCommon.generateStringForComponent(r[30].ToString(), r[31].ToString(), r[32].ToString());
                        // --
                        rpmCnt = r[33].ToString();

                        // --

                        cellValues = new object[] {
                            r[0].ToString(),   // Eap
                            r[1].ToString(),   // Description    
                            rpmCnt,            // RPM Count (2017.06.07 by spike.lee add)
                            eapType,           // Type
                            r[3].ToString(),   // Oper Mode
                            r[4].ToString(),   // Server
                            r[5].ToString(),   // Step
                            eapUpDown,         // Up/Down
                            eapStatus,         // Status
                            r[8].ToString(),   // Reload Count
                            r[10].ToString(),  // Need Action
                            r[11].ToString(),  // Next Need Action
                            set_Package,       // (Set) Package
                            rel_Package,       // (Rel) Package
                            apl_Package,       // (Apl) Package
                            set_Model,         // (Set) Model
                            rel_Model,         // (Rel) Model
                            apl_Model,         // (Apl) Model
                            set_Component,     // (Set) Component
                            rel_Component,     // (Rel) Component
                            apl_Component      // (Apl) Component
                            };
                        key = (string)cellValues[0];
                        index = grdEap.appendDataRow(key, cellValues).Index;

                        // --

                        row = grdEap.Rows.GetRowWithListIndex(index);

                        // --

                        cell = row.Cells["EAP"];
                        cell.Appearance.Image = FCommon.getImageOfEap(grdEap, eapType, eapUpDown, eapStatus, eapAlarm);

                        // --

                        if (eapUpDown == FUpDown.Down.ToString())
                        {
                            row.Appearance.BackColor = Color.FromArgb(233, 233, 233);
                        }
                        else if (eapAlarm == FYesNo.Yes.ToString())
                        {
                            row.Appearance.BackColor = Color.FromArgb(255, 221, 211);
                        }
                        else
                        {
                            row.Appearance.BackColor = Color.WhiteSmoke;
                        }

                        // --

                        if (rpmCnt != "0")
                        {
                            cell = row.Cells["RPM Count"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        }

                        // --

                        cell = row.Cells["Step"];
                        if (cell.Text != FEapAttrCategory.Applied.ToString())
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
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

                        cell = row.Cells["Status"];
                        if (cell.Text == "Backup")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }

                        // --

                        cell = row.Cells["Need Action"];
                        if (cell.Text.Trim() != "")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                        }

                        // --

                        cell = row.Cells["Next Need Action"];
                        if (cell.Text.Trim() != "")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                        }

                        // --

                        if (!FCommon.stringEquals(set_Package, rel_Package, apl_Package))
                        {
                            cell = row.Cells["(Set) Package"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                            cell = row.Cells["(Rel) Package"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                            cell = row.Cells["(Apl) Package"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                        }
                        // --
                        cell = row.Cells["(Set) Package"];
                        if (cell.Text == "N/A")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }
                        // --
                        cell = row.Cells["(Rel) Package"];
                        if (cell.Text == "N/A")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }
                        // --
                        cell = row.Cells["(Apl) Package"];
                        if (cell.Text == "N/A")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }

                        // --

                        if (!FCommon.stringEquals(set_Model, rel_Model, apl_Model))
                        {
                            cell = row.Cells["(Set) Model"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                            cell = row.Cells["(Rel) Model"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                            cell = row.Cells["(Apl) Model"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                        }
                        // --
                        cell = row.Cells["(Set) Model"];
                        cell.Tag = r[16].ToString();
                        if (cell.Text == "N/A")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }
                        // --
                        cell = row.Cells["(Rel) Model"];
                        cell.Tag = r[18].ToString();
                        if (cell.Text == "N/A")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }
                        // --
                        cell = row.Cells["(Apl) Model"];
                        cell.Tag = r[20].ToString();
                        if (cell.Text == "N/A")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }

                        // --

                        if (!FCommon.stringEquals(set_Component, rel_Component, apl_Component))
                        {
                            cell = row.Cells["(Set) Component"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                            cell = row.Cells["(Rel) Component"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                            cell = row.Cells["(Apl) Component"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                        }
                        // --
                        cell = row.Cells["(Set) Component"];
                        if (cell.Text == "N/A")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }
                        // --
                        cell = row.Cells["(Rel) Component"];
                        if (cell.Text == "N/A")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }
                        // --
                        cell = row.Cells["(Apl) Component"];
                        if (cell.Text == "N/A")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }
                    }
                } while (nextRowNumber >= 0);

                // --

                grdEap.endUpdate(false);
                grdEap.DisplayLayout.Bands[0].SortedColumns.Add("EAP", false);

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
                if (fXmlNode == null)
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

            try
            {
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TolEapSchemaSearch_In.E_ADMADS_TolEapSchemaSearch_In);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapSchemaSearch_In.A_hLanguage, FADMADS_TolEapSchemaSearch_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TolEapSchemaSearch_In.A_hFactory, FADMADS_TolEapSchemaSearch_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapSchemaSearch_In.A_hUserId, FADMADS_TolEapSchemaSearch_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapSchemaSearch_In.A_hStep, FADMADS_TolEapSchemaSearch_In.D_hStep, "1");
                // --
                fXmlNodeInEap = fXmlNodeIn.set_elem(FADMADS_TolEapSchemaSearch_In.FEap.E_Eap);
                fXmlNodeInEap.set_elemVal(FADMADS_TolEapSchemaSearch_In.FEap.A_Name, FADMADS_TolEapSchemaSearch_In.FEap.D_Name, this.activeEap);

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

        private void procMonitoringEapData(
            FMonitoringEapDataReceivedEventArgs args
            )
        {
            UltraGridRow row = null;
            UltraGridCell cell = null;
            object[] cellValues = null;
            FXmlNode fXmlNodeScd = null;
            string eap = string.Empty;
            string eapDesc = string.Empty;
            string rpmCnt = string.Empty;
            string eapType = string.Empty;
            string operMode = string.Empty;
            string server = string.Empty;
            string step = string.Empty;
            string upDown = string.Empty;
            string status = string.Empty;
            string reloadCount = string.Empty;
            string need_action = string.Empty;
            string next_need_action = string.Empty;
            string alarm = string.Empty;
            string set_Package = string.Empty;
            string rel_Package = string.Empty;
            string apl_Package = string.Empty;
            string set_PackageVer = string.Empty;
            string rel_PackageVer = string.Empty;
            string apl_PackageVer = string.Empty;
            string set_Model = string.Empty;
            string rel_Model = string.Empty;
            string apl_Model = string.Empty;
            string set_ModelVer = string.Empty;
            string rel_ModelVer = string.Empty;
            string apl_ModelVer = string.Empty;
            string set_Used_Component = string.Empty;
            string rel_Used_Component = string.Empty;
            string apl_Used_Component = string.Empty;
            string set_Component = string.Empty;
            string rel_Component = string.Empty;
            string apl_Component = string.Empty;
            string set_ComponentVer = string.Empty;
            string rel_ComponentVer = string.Empty;
            string apl_ComponentVer = string.Empty;            
            int index = 0;
            bool changedCategory = false;
            string eqpData = string.Empty;
            bool eqpDataExist = false;

            try
            {
                eap = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_Name, FADMADS_TolEapDataPush_In.FEap.D_Name);
                eapDesc = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_Description, FADMADS_TolEapDataPush_In.FEap.D_Description);
                rpmCnt = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_RpmCount, FADMADS_TolEapDataPush_In.FEap.D_RpmCount);
                eapType = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_EapType, FADMADS_TolEapDataPush_In.FEap.D_EapType);
                operMode = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_OperMode, FADMADS_TolEapDataPush_In.FEap.D_OperMode);
                server = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_Server, FADMADS_TolEapDataPush_In.FEap.D_Server);
                step = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_Step, FADMADS_TolEapDataPush_In.FEap.D_Step);
                upDown = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_UpDown, FADMADS_TolEapDataPush_In.FEap.D_UpDown);
                status = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_Status, FADMADS_TolEapDataPush_In.FEap.D_Status);
                reloadCount = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_ReloadCount, FADMADS_TolEapDataPush_In.FEap.D_ReloadCount);
                need_action = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_NeedAction, FADMADS_TolEapDataPush_In.FEap.D_NeedAction);
                next_need_action = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_NextNeedAction, FADMADS_TolEapDataPush_In.FEap.D_NextNeedAction);
                alarm = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_Alarm, FADMADS_TolEapDataPush_In.FEap.D_Alarm);
                set_Package = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_SetPackage, FADMADS_TolEapDataPush_In.FEap.D_SetPackage);
                set_PackageVer = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_SetPackageVer, FADMADS_TolEapDataPush_In.FEap.D_SetPackageVer);
                rel_Package = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_RelPackage, FADMADS_TolEapDataPush_In.FEap.D_RelPackage);
                rel_PackageVer = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_RelPackageVer, FADMADS_TolEapDataPush_In.FEap.D_RelPackageVer);
                apl_Package = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_AplPackage, FADMADS_TolEapDataPush_In.FEap.D_AplPackage);
                apl_PackageVer = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_AplPackageVer, FADMADS_TolEapDataPush_In.FEap.D_AplPackageVer);
                set_Model = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_SetModel, FADMADS_TolEapDataPush_In.FEap.D_SetModel);
                set_ModelVer = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_SetModelVer, FADMADS_TolEapDataPush_In.FEap.D_SetModelVer);
                rel_Model = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_RelModel, FADMADS_TolEapDataPush_In.FEap.D_RelModel);
                rel_ModelVer = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_RelModelVer, FADMADS_TolEapDataPush_In.FEap.D_RelModelVer);
                apl_Model = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_AplModel, FADMADS_TolEapDataPush_In.FEap.D_AplModel);
                apl_ModelVer = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_AplModelVer, FADMADS_TolEapDataPush_In.FEap.D_AplModelVer);
                set_Used_Component = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_SetUsedComponent, FADMADS_TolEapDataPush_In.FEap.D_SetUsedComponent);
                set_Component = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_SetComponent, FADMADS_TolEapDataPush_In.FEap.D_SetComponent);
                set_ComponentVer = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_SetComponentVer, FADMADS_TolEapDataPush_In.FEap.D_SetComponentVer);
                rel_Used_Component = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_RelUsedComponent, FADMADS_TolEapDataPush_In.FEap.D_RelUsedComponent);
                rel_Component = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_RelComponent, FADMADS_TolEapDataPush_In.FEap.D_RelComponent);
                rel_ComponentVer = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_RelComponentVer, FADMADS_TolEapDataPush_In.FEap.D_RelComponentVer);
                apl_Used_Component = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_AplUsedComponent, FADMADS_TolEapDataPush_In.FEap.D_AplUsedComponent);
                apl_Component = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_AplComponent, FADMADS_TolEapDataPush_In.FEap.D_AplComponent);
                apl_ComponentVer = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_AplComponentVer, FADMADS_TolEapDataPush_In.FEap.D_AplComponentVer);                

                // --

                if (m_isSearchMode)
                {
                    if (!grdEap.containsDataRow(eap))
                    {
                        return;
                    }
                }
                else if (!chkAll.Checked)
                {
                    if (tabMain.ActiveTab.Key == "Server")
                    {
                        if (!grdClass.activeDataRowKey.Equals(server))
                        {
                            if (!grdEap.containsDataRow(eap))
                            {
                                return;
                            }
                            changedCategory = true;
                        }
                    }
                    else if (tabMain.ActiveTab.Key == "Package")
                    {
                        if (grdClass.ActiveRow == null)
                            return;

                        if (grdClass.ActiveRow.ParentRow == null)
                        {
                            if (
                                !grdClass.activeDataRowKey.Equals(set_Package) &&
                                !grdClass.activeDataRowKey.Equals(rel_Package) &&
                                !grdClass.activeDataRowKey.Equals(apl_Package)
                                )
                            {
                                if (!grdEap.containsDataRow(eap))
                                {
                                    return;
                                }
                                changedCategory = true;
                            }
                        }
                        else
                        {
                            if (
                                (!grdClass.ActiveRow.ParentRow.Cells["Name"].Text.Equals(set_Package) || !grdClass.ActiveRow.Tag.Equals(set_PackageVer)) &&
                                (!grdClass.ActiveRow.ParentRow.Cells["Name"].Text.Equals(rel_Package) || !grdClass.ActiveRow.Tag.Equals(rel_PackageVer)) &&
                                (!grdClass.ActiveRow.ParentRow.Cells["Name"].Text.Equals(apl_Package) || !grdClass.ActiveRow.Tag.Equals(apl_PackageVer))
                                )
                            {
                                if (!grdEap.containsDataRow(eap))
                                {
                                    return;
                                }
                                changedCategory = true;
                            }
                        }
                    }
                    else if (tabMain.ActiveTab.Key == "Model")
                    {
                        if (grdClass.ActiveRow == null)
                            return;

                        if (grdClass.ActiveRow.ParentRow == null)
                        {
                            if (
                                !grdClass.activeDataRowKey.Equals(set_Model) &&
                                !grdClass.activeDataRowKey.Equals(rel_Model) &&
                                !grdClass.activeDataRowKey.Equals(apl_Model)
                                )
                            {
                                if (!grdEap.containsDataRow(eap))
                                {
                                    return;
                                }
                                changedCategory = true;
                            }
                        }
                        else
                        {
                            if (
                                (!grdClass.ActiveRow.ParentRow.Cells["Name"].Text.Equals(set_Model) || !grdClass.ActiveRow.Tag.Equals(set_ModelVer)) &&
                                (!grdClass.ActiveRow.ParentRow.Cells["Name"].Text.Equals(rel_Model) || !grdClass.ActiveRow.Tag.Equals(rel_ModelVer)) &&
                                (!grdClass.ActiveRow.ParentRow.Cells["Name"].Text.Equals(apl_Model) || !grdClass.ActiveRow.Tag.Equals(apl_ModelVer))
                                )
                            {
                                if (!grdEap.containsDataRow(eap))
                                {
                                    return;
                                }
                                changedCategory = true;
                            }
                        }
                    }
                    else if (tabMain.ActiveTab.Key == "Component")
                    {
                        if (grdClass.ActiveRow == null)
                            return;

                        if (grdClass.ActiveRow.ParentRow == null)
                        {
                            if (
                                !grdClass.activeDataRowKey.Equals(set_Component) &&
                                !grdClass.activeDataRowKey.Equals(rel_Component) &&
                                !grdClass.activeDataRowKey.Equals(apl_Component)
                                )
                            {
                                if (!grdEap.containsDataRow(eap))
                                {
                                    return;
                                }
                                changedCategory = true;
                            }
                        }
                        else
                        {
                            if (
                                (!grdClass.ActiveRow.ParentRow.Cells["Name"].Text.Equals(set_Component) || !grdClass.ActiveRow.Tag.Equals(set_ComponentVer)) &&
                                (!grdClass.ActiveRow.ParentRow.Cells["Name"].Text.Equals(rel_Component) || !grdClass.ActiveRow.Tag.Equals(rel_ComponentVer)) &&
                                (!grdClass.ActiveRow.ParentRow.Cells["Name"].Text.Equals(apl_Component) || !grdClass.ActiveRow.Tag.Equals(apl_ComponentVer))
                                )
                            {
                                if (!grdEap.containsDataRow(eap))
                                {
                                    return;
                                }
                                changedCategory = true;
                            }
                        }
                    }
                    else if (tabMain.ActiveTab.Key == "Equipment Type")
                    {
                        eqpData = grdClass.activeDataRowKey;

                        // --

                        fXmlNodeScd = args.fXmlNode.get_elem(FADMADS_TolEapDataPush_In.FEap.FSecsDriver.E_SecsDriver);
                        // --
                        if (fXmlNodeScd != null)
                        {
                            foreach (FXmlNode x in fXmlNodeScd.get_elemList(FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.E_Equipment))
                            {
                                if (eqpData == x.get_elemVal(FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.A_Type, FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.D_Type))
                                {
                                    eqpDataExist = true;
                                    break;
                                }
                            }
                        }

                        // --

                        if (!eqpDataExist)
                        {
                            if (!grdEap.containsDataRow(eap))
                            {
                                return;
                            }
                            changedCategory = true;
                        }                        
                    }
                    else if (tabMain.ActiveTab.Key == "Equipment Area")
                    {
                        eqpData = grdClass.activeDataRowKey;

                        // --

                        fXmlNodeScd = args.fXmlNode.get_elem(FADMADS_TolEapDataPush_In.FEap.FSecsDriver.E_SecsDriver);
                        // --
                        if (fXmlNodeScd != null)
                        {
                            foreach (FXmlNode x in fXmlNodeScd.get_elemList(FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.E_Equipment))
                            {
                                if (eqpData == x.get_elemVal(FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.A_Area, FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.D_Area))
                                {
                                    eqpDataExist = true;
                                    break;
                                }
                            }
                        }

                        // --

                        if (!eqpDataExist)
                        {
                            if (!grdEap.containsDataRow(eap))
                            {
                                return;
                            }
                            changedCategory = true;
                        }       
                    }
                    else if (tabMain.ActiveTab.Key == "Equipment Line")
                    {
                        eqpData = grdClass.activeDataRowKey;

                        // --

                        fXmlNodeScd = args.fXmlNode.get_elem(FADMADS_TolEapDataPush_In.FEap.FSecsDriver.E_SecsDriver);
                        // --
                        if (fXmlNodeScd != null)
                        {
                            foreach (FXmlNode x in fXmlNodeScd.get_elemList(FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.E_Equipment))
                            {
                                if (eqpData == x.get_elemVal(FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.A_Line, FADMADS_TolEapDataPush_In.FEap.FSecsDriver.FEquipment.D_Line))
                                {
                                    eqpDataExist = true;
                                    break;
                                }
                            }
                        }

                        // --

                        if (!eqpDataExist)
                        {
                            if (!grdEap.containsDataRow(eap))
                            {
                                return;
                            }
                            changedCategory = true;
                        }  
                    }
                }                

                // --

                grdEap.beginUpdate(false);

                // --

                if (args.fType == FMonitoringDataType.Update && changedCategory == false)
                {
                    #region Insert or Update EAP information

                    set_Package = FCommon.generateStringForPackage(set_Package, set_PackageVer);
                    rel_Package = FCommon.generateStringForPackage(rel_Package, rel_PackageVer);
                    apl_Package = FCommon.generateStringForPackage(apl_Package, apl_PackageVer);

                    // --

                    set_Model = FCommon.generateStringForModel(set_Model, set_ModelVer);
                    rel_Model = FCommon.generateStringForModel(rel_Model, rel_ModelVer);
                    apl_Model = FCommon.generateStringForModel(apl_Model, apl_ModelVer);

                    // --

                    set_Component = FCommon.generateStringForComponent(set_Used_Component, set_Component, set_ComponentVer);
                    rel_Component = FCommon.generateStringForComponent(rel_Used_Component, rel_Component, rel_ComponentVer);
                    apl_Component = FCommon.generateStringForComponent(apl_Used_Component, apl_Component, apl_ComponentVer);

                    // --

                    cellValues = new object[] {
                        eap,
                        eapDesc,
                        rpmCnt,
                        eapType,
                        operMode,
                        server,
                        step,
                        upDown,
                        status,
                        reloadCount,
                        need_action,
                        next_need_action,
                        set_Package,
                        rel_Package,
                        apl_Package,
                        set_Model,
                        rel_Model,
                        apl_Model,
                        set_Component,
                        rel_Component,
                        apl_Component
                        };

                    // --

                    index = grdEap.appendOrUpdateDataRow(eap, cellValues).Index;
                    row = grdEap.Rows.GetRowWithListIndex(index);
                    row.Tag = eap;
                    
                    // --

                    cell = row.Cells["EAP"];
                    cell.Appearance.Image = FCommon.getImageOfEap(grdEap, eapType, upDown, status, alarm);

                    // --

                    if (upDown == FUpDown.Down.ToString())
                    {
                        row.Appearance.BackColor = Color.FromArgb(233, 233, 233);
                    }
                    else if (alarm == FYesNo.Yes.ToString())
                    {
                        row.Appearance.BackColor = Color.FromArgb(255, 221, 211);
                    }
                    else
                    {
                        row.Appearance.BackColor = Color.WhiteSmoke;
                    }  

                    // --

                    foreach (UltraGridCell c in row.Cells)
                    {
                        c.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                        c.Appearance.ForeColor = Color.Black;
                    }

                    // --

                    if (rpmCnt != "0")
                    {
                        cell = row.Cells["RPM Count"];
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    }

                    // --

                    if (!step.Equals(FEapAttrCategory.Applied.ToString()))
                    {
                        cell = row.Cells["Step"];
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        cell.Appearance.ForeColor = Color.Blue;
                    }

                    // --

                    if (upDown.Equals(FUpDown.Down.ToString()))
                    {
                        cell = row.Cells["Up/Down"];
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        cell.Appearance.ForeColor = Color.Red;
                        // --
                        cell = row.Cells["EAP"];
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        cell.Appearance.ForeColor = Color.Red;
                    }

                    // --

                    if (!need_action.Equals(string.Empty))
                    {
                        cell = row.Cells["Need Action"];
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        cell.Appearance.ForeColor = Color.Blue;
                    }

                    // --

                    if (!next_need_action.Equals(string.Empty))
                    {
                        cell = row.Cells["Next Need Action"];
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        cell.Appearance.ForeColor = Color.Blue;
                    }

                    // --

                    if (!FCommon.stringEquals(set_Package, rel_Package, apl_Package))
                    {
                        cell = row.Cells["(Set) Package"];
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        cell.Appearance.ForeColor = Color.Blue;
                        cell = row.Cells["(Rel) Package"];
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        cell.Appearance.ForeColor = Color.Blue;
                        cell = row.Cells["(Apl) Package"];
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        cell.Appearance.ForeColor = Color.Blue;
                    }
                    // --
                    if (set_Package.Equals("N/A"))
                    {
                        cell = row.Cells["(Set) Package"];
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        cell.Appearance.ForeColor = Color.Red;
                    }
                    // --
                    if (rel_Package.Equals("N/A"))
                    {
                        cell = row.Cells["(Rel) Package"];
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        cell.Appearance.ForeColor = Color.Red;
                    }
                    // --
                    if (apl_Package.Equals("N/A"))
                    {
                        cell = row.Cells["(Apl) Package"];
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        cell.Appearance.ForeColor = Color.Red;
                    }

                    // --

                    if (!FCommon.stringEquals(set_Model, rel_Model, apl_Model))
                    {
                        cell = row.Cells["(Set) Model"];
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        cell.Appearance.ForeColor = Color.Blue;
                        cell = row.Cells["(Rel) Model"];
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        cell.Appearance.ForeColor = Color.Blue;
                        cell = row.Cells["(Apl) Model"];
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        cell.Appearance.ForeColor = Color.Blue;
                    }
                    // --
                    if (set_Model.Equals("N/A"))
                    {
                        cell = row.Cells["(Set) Model"];
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        cell.Appearance.ForeColor = Color.Red;
                    }
                    // --
                    if (rel_Model.Equals("N/A"))
                    {
                        cell = row.Cells["(Rel) Model"];
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        cell.Appearance.ForeColor = Color.Red;
                    }
                    // --
                    if (apl_Model.Equals("N/A"))
                    {
                        cell = row.Cells["(Apl) Model"];
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        cell.Appearance.ForeColor = Color.Red;
                    }

                    // --

                    if (!FCommon.stringEquals(set_Component, rel_Component, apl_Component))
                    {
                        cell = row.Cells["(Set) Component"];
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        cell.Appearance.ForeColor = Color.Blue;
                        cell = row.Cells["(Rel) Component"];
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        cell.Appearance.ForeColor = Color.Blue;
                        cell = row.Cells["(Apl) Component"];
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        cell.Appearance.ForeColor = Color.Blue;
                    }
                    // --
                    if (set_Used_Component.Equals("N/A"))
                    {
                        cell = row.Cells["(Set) Component"];
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        cell.Appearance.ForeColor = Color.Red;
                    }
                    // --
                    if (rel_Used_Component.Equals("N/A"))
                    {
                        cell = row.Cells["(Rel) Component"];
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        cell.Appearance.ForeColor = Color.Red;
                    }
                    // --
                    if (apl_Used_Component.Equals("N/A"))
                    {
                        cell = row.Cells["(Apl) Component"];
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        cell.Appearance.ForeColor = Color.Red;
                    }

                    #endregion
                }
                else
                {
                    #region Delete EAP information

                    grdEap.removeDataRow(eap);

                    #endregion
                }

                // --

                grdEap.endUpdate(false);
          
                // --

                if (this.activeEap.Equals(eap))
                {
                    // EAP Category가 변경되었을 경우 기존의 Schema를 Clear하기 위해, Schema 정보를 Null로 처리한다.
                    fXmlNodeScd = changedCategory == true ? 
                        null : 
                        args.fXmlNode.get_elem(FADMADS_TolEapDataPush_In.FEap.FSecsDriver.E_SecsDriver);

                    // ***
                    // Refresh Eap Schema
                    // ***
                    procMonitoringEapSchema(fXmlNodeScd);
                }

                // --

                if (chkAutoActive.Checked && grdEap.containsDataRow(eap) && alarm == FYesNo.Yes.ToString())
                {
                    grdEap.activateDataRow(eap);
                }
            }
            catch (Exception ex)
            {
                grdEap.endUpdate(false);
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                refreshEapTotal();

                // --

                row = null;
                cell = null;
                cellValues = null;
                fXmlNodeScd = null;
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
            string eapType = string.Empty;

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
                eapType = fXmlNodeScd.get_elemVal(FADMADS_TolEapDataPush_In.FEap.FSecsDriver.A_EapType, FADMADS_TolEapDataPush_In.FEap.FSecsDriver.D_EapType);

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

                // --

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

        private void procMonitoringServerData(
            FMonitoringServerDataReceivedEventArgs args
            )
        {
            UltraGridRow row = null;
            UltraGridCell cell = null;
            object[] cellValues = null;
            string svr = string.Empty;
            string svrDesc = string.Empty;
            string svrType = string.Empty;
            string svrIp = string.Empty;
            string svrStatus = string.Empty;
            string svrUpDown = string.Empty;
            string adaUpDown = string.Empty;
            string opcServerUpDown = string.Empty;
            string svrAlarm = string.Empty;
            int index = 0;

            try
            {
                if (tabMain.ActiveTab.Key != "Server")
                {
                    return;
                }

                // --

                grdClass.beginUpdate(false);

                // --

                svr = args.server;
                svrDesc = args.fXmlNode.get_elemVal(FADMADS_TolServerDataPush_In.FServer.A_Description, FADMADS_TolServerDataPush_In.FServer.D_Description);
                svrType = args.fXmlNode.get_elemVal(FADMADS_TolServerDataPush_In.FServer.A_ServerType, FADMADS_TolServerDataPush_In.FServer.D_ServerType);
                svrIp = args.fXmlNode.get_elemVal(FADMADS_TolServerDataPush_In.FServer.A_ServerIp, FADMADS_TolServerDataPush_In.FServer.D_ServerIp);
                svrUpDown = args.fXmlNode.get_elemVal(FADMADS_TolServerDataPush_In.FServer.A_UpDown, FADMADS_TolServerDataPush_In.FServer.D_UpDown);
                svrStatus = args.fXmlNode.get_elemVal(FADMADS_TolServerDataPush_In.FServer.A_Status, FADMADS_TolServerDataPush_In.FServer.D_Status);
                adaUpDown = args.fXmlNode.get_elemVal(FADMADS_TolServerDataPush_In.FServer.A_AdminAgentUpDown, FADMADS_TolServerDataPush_In.FServer.D_AdminAgentUpDown);
                opcServerUpDown = args.fXmlNode.get_elemVal(FADMADS_TolServerDataPush_In.FServer.A_OpcServerUpDown, FADMADS_TolServerDataPush_In.FServer.D_OpcServerUpDown);
                svrAlarm = args.fXmlNode.get_elemVal(FADMADS_TolServerDataPush_In.FServer.A_Alarm, FADMADS_TolServerDataPush_In.FServer.D_Alarm);

                // --

                if (args.fType == FMonitoringDataType.Update)
                {
                    // ***
                    // Insert or Update server information in tabMain
                    // ***
                    cellValues = new object[] {
                        svr,
                        svrDesc,
                        svrType,
                        svrIp,
                        adaUpDown,
                        opcServerUpDown
                        };
                    // --
                    index = grdClass.appendOrUpdateDataRow(svr, cellValues).Index;
                    row = grdClass.Rows.GetRowWithListIndex(index);
                    
                    // --
                    
                    cell = row.Cells["Name"];
                    cell.Appearance.Image = getImageOfServer(svrUpDown, svrStatus, svrAlarm);   

                    // --

                    if (svrUpDown == FUpDown.Down.ToString())
                    {
                        row.Appearance.BackColor = Color.FromArgb(233, 233, 233);
                    }
                    else if (svrAlarm == FYesNo.Yes.ToString())
                    {
                        row.Appearance.BackColor = Color.FromArgb(255, 221, 211);
                    }
                    else
                    {
                        row.Appearance.BackColor = Color.WhiteSmoke;
                    }  
                }
                else
                {
                    // ***
                    // Delete server information in tabMain
                    // ***
                    grdClass.removeDataRow(svr);
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

        private void procMonitoringPackageData(
            FMonitoringPackageDataReceivedEventArgs args
            )
        {
            UltraGridRow row = null;
            UltraGridCell cell = null;
            object[] cellValues = null;
            string pkg = string.Empty;
            string pkgDesc = string.Empty;
            string pkgType = string.Empty;
            string releaseVer = string.Empty;
            int index = 0;

            try
            {
                if (tabMain.ActiveTab.Key != "Package")
                {
                    return;
                }

                // --

                grdClass.beginUpdate(false);

                // --

                pkg = args.fXmlNode.get_elemVal(FADMADS_TolPackageDataPush_In.FPackage.A_Name, FADMADS_TolPackageDataPush_In.FPackage.D_Name);
                pkgDesc = args.fXmlNode.get_elemVal(FADMADS_TolPackageDataPush_In.FPackage.A_Description, FADMADS_TolPackageDataPush_In.FPackage.A_Description);
                pkgType = args.fXmlNode.get_elemVal(FADMADS_TolPackageDataPush_In.FPackage.A_Type, FADMADS_TolPackageDataPush_In.FPackage.D_Type);
                releaseVer = args.fXmlNode.get_elemVal(FADMADS_TolPackageDataPush_In.FPackage.A_ReleaseVer, FADMADS_TolPackageDataPush_In.FPackage.D_ReleaseVer);

                // --

                if (args.fType == FMonitoringDataType.Update)
                {
                    // ***
                    // Insert or Update package information in tabMain
                    // ***
                    cellValues = new object[] {
                        pkg,
                        pkgDesc,
                        null,
                        null,
                        null,
                        null,
                        pkgType
                        };

                    // --

                    index = grdClass.appendOrUpdateDataRow(pkg, cellValues).Index;
                    row = grdClass.Rows.GetRowWithListIndex(index);
                    row.Tag = releaseVer;

                    // --

                    cell = row.Cells["Name"];
                    cell.Appearance.Image = FCommon.getImageOfPackage(grdClass, pkgType);
                }
                else
                {
                    // ***
                    // Delete package information in tabMain
                    // ***
                    grdClass.removeDataRow(pkg);
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

        private void procMonitoringPackageVerData(
            FMonitoringPackageVerDataReceivedEventArgs args
            )
        {
            UltraGridRow row = null;
            UltraGridRow childRow = null;
            UltraGridCell cell = null;
            object[] cellValues = null;
            string pkg = string.Empty;
            string ver = string.Empty;
            string verDesc = string.Empty;
            string verRelease = string.Empty;
            int index = 0;
            int childIndex = 0;

            try
            {
                if (tabMain.ActiveTab.Key != "Package")
                {
                    return;
                }

                // --

                grdClass.beginUpdate(false);

                // --

                pkg = args.fXmlNode.get_elemVal(FADMADS_TolPackageVerDataPush_In.FPackageVer.A_Name, FADMADS_TolPackageVerDataPush_In.FPackageVer.D_Name);
                ver = args.fXmlNode.get_elemVal(FADMADS_TolPackageVerDataPush_In.FPackageVer.A_Version, FADMADS_TolPackageVerDataPush_In.FPackageVer.D_Version);
                verDesc = args.fXmlNode.get_elemVal(FADMADS_TolPackageVerDataPush_In.FPackageVer.A_Description, FADMADS_TolPackageVerDataPush_In.FPackageVer.D_Description);
                verRelease = args.fXmlNode.get_elemVal(FADMADS_TolPackageVerDataPush_In.FPackageVer.A_Release, FADMADS_TolPackageVerDataPush_In.FPackageVer.D_Release);

                // --

                if ((index = grdClass.getDataRowIndex(pkg)) < 0)
                {
                    grdClass.endUpdate(false);
                    return;
                }

                // --

                if (args.fType == FMonitoringDataType.Update)
                {
                    // ***
                    // Insert or Update package information in tabMain
                    // ***
                    row = grdClass.Rows.GetRowWithListIndex(index);
                    foreach (UltraGridRow r in row.ChildBands["Version"].Rows)
                    {
                        if (verRelease.Equals(FYesNo.Yes.ToString()))
                        {
                            cell = r.Cells["Version"];
                            cell.Value = r.Tag;
                        }
                        // --
                        if (r.Tag.Equals(ver))
                        {
                            cell = r.Cells["Description"];
                            cell.Value = verDesc;
                            // --
                            childRow = r;
                        }
                    }

                    // --

                    if (childRow == null)
                    {
                        cellValues = new object[] {
                            ver,
                            verDesc
                            };
                        childIndex = grdClass.getDataRow(index).GetChildRows("Version").Insert(0, cellValues).Index;
                        // --
                        childRow = grdClass.Rows[index].ChildBands["Version"].Rows[childIndex];
                        childRow.Tag = ver;
                    }

                    // --

                    cell = childRow.Cells["Version"];
                    // --
                    if (verRelease == FYesNo.Yes.ToString())
                    {
                        cell.Value = ver + "*";
                        row.Tag = ver;  // Package에 Release Version 설정
                    }
                    else
                    {
                        cell.Value = ver;
                    }


                    cell.Value = ver + (verRelease == FYesNo.Yes.ToString() ? "*" : string.Empty);
                    cell.Appearance.Image = FCommon.getImageOfPackageVersion(grdClass, row.Cells["Type"].Text); 
                }
                else
                {
                    // ***
                    // Delete package information in tabMain
                    // ***
                    row = grdClass.Rows.GetRowWithListIndex(index);
                    foreach (UltraGridRow r in row.ChildBands["Version"].Rows)
                    {
                        if (r.Tag.Equals(ver))
                        {
                            childRow = r;
                            break;
                        }
                    }

                    // --

                    if (childRow != null)
                    {
                        grdClass.getDataRow(index).GetChildRows("Version").RemoveAt(childRow.Index, false);
                    }
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
                row = null;
                childRow = null;
                cell = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMonitoringModelData(
            FMonitoringModelDataReceivedEventArgs args
            )
        {
            UltraGridRow row = null;
            UltraGridCell cell = null;
            object[] cellValues = null;
            string mdl = string.Empty;
            string mdlDesc = string.Empty;
            string mdlType = string.Empty;
            string releaseVer = string.Empty;
            int index = 0;

            try
            {
                if (tabMain.ActiveTab.Key != "Model")
                {
                    return;
                }

                // --

                grdClass.beginUpdate(false);

                // --

                mdl = args.fXmlNode.get_elemVal(FADMADS_TolModelDataPush_In.FModel.A_Name, FADMADS_TolModelDataPush_In.FModel.D_Name);
                mdlDesc = args.fXmlNode.get_elemVal(FADMADS_TolModelDataPush_In.FModel.A_Description, FADMADS_TolModelDataPush_In.FModel.D_Description);
                mdlType = args.fXmlNode.get_elemVal(FADMADS_TolModelDataPush_In.FModel.A_Type, FADMADS_TolModelDataPush_In.FModel.D_Type);
                releaseVer = args.fXmlNode.get_elemVal(FADMADS_TolModelDataPush_In.FModel.A_ReleaseVer, FADMADS_TolModelDataPush_In.FModel.D_ReleaseVer);

                // --

                if (args.fType == FMonitoringDataType.Update)
                {
                    // ***
                    // Insert or Update model information in tabMain
                    // ***
                    cellValues = new object[] {
                        mdl,
                        mdlDesc,
                        null,
                        null,
                        null,
                        null,                        
                        mdlType
                        };

                    // --

                    index = grdClass.appendOrUpdateDataRow(mdl, cellValues).Index;
                    row = grdClass.Rows.GetRowWithListIndex(index);
                    row.Tag = releaseVer;

                    // --

                    cell = row.Cells["Name"];
                    cell.Appearance.Image = FCommon.getImageOfModel(grdClass, mdlType);
                }
                else
                {
                    // ***
                    // Delete model information in tabMain
                    // ***
                    grdClass.removeDataRow(mdl);
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

        private void procMonitoringModelVerData(
            FMonitoringModelVerDataReceivedEventArgs args
            )
        {
            UltraGridRow row = null;
            UltraGridRow childRow = null;
            UltraGridCell cell = null;
            object[] cellValues = null;
            string mdl = string.Empty;
            string ver = string.Empty;
            string orVer = string.Empty;
            string verDesc = string.Empty;
            string verRelease = string.Empty;
            int index = 0;
            int childIndex = 0;

            try
            {
                if (tabMain.ActiveTab.Key != "Model")
                {
                    return;
                }

                // --

                grdClass.beginUpdate(false);

                // --

                mdl = args.fXmlNode.get_elemVal(FADMADS_TolModelVerDataPush_In.FModelVer.A_Name, FADMADS_TolModelVerDataPush_In.FModelVer.D_Name);
                ver = args.fXmlNode.get_elemVal(FADMADS_TolModelVerDataPush_In.FModelVer.A_Version, FADMADS_TolModelVerDataPush_In.FModelVer.D_Version);
                verDesc = args.fXmlNode.get_elemVal(FADMADS_TolModelVerDataPush_In.FModelVer.A_Description, FADMADS_TolModelVerDataPush_In.FModelVer.D_Description);
                verRelease = args.fXmlNode.get_elemVal(FADMADS_TolModelVerDataPush_In.FModelVer.A_Release, FADMADS_TolModelVerDataPush_In.FModelVer.D_Release);
                
                // --

                if ((index = grdClass.getDataRowIndex(mdl)) < 0)
                {
                    grdClass.endUpdate(false);
                    return;
                }

                // --

                if (args.fType == FMonitoringDataType.Update)
                {
                    // ***
                    // Insert or Update model information in tabMain
                    // ***
                    row = grdClass.Rows.GetRowWithListIndex(index);
                    foreach (UltraGridRow r in row.ChildBands["Version"].Rows)
                    {
                        // --
                        orVer = r.Cells["Version"].Text;

                        // --

                        if (verRelease.Equals(FYesNo.Yes.ToString()))
                        {
                            cell = r.Cells["Version"];
                            cell.Value = r.Tag;
                        }

                        // --
                        if (orVer.Equals(ver))
                        {
                            cell = r.Cells["Description"];
                            cell.Value = verDesc;
                            // --
                            childRow = r;
                        }
                    }

                    // --

                    if (childRow == null)
                    {
                        cellValues = new object[] {
                            ver,
                            verDesc
                            };
                        childIndex = grdClass.getDataRow(index).GetChildRows("Version").Insert(0, cellValues).Index;
                        // --
                        childRow = grdClass.Rows[index].ChildBands["Version"].Rows[childIndex];
                        childRow.Tag = ver;
                    }

                    // --

                    cell = childRow.Cells["Version"];
                    // --
                    if (verRelease == FYesNo.Yes.ToString())
                    {
                        cell.Value = ver + "*";
                        row.Tag = ver; // Model Releae Version 설정
                    }
                    else
                    {
                        cell.Value = ver;
                    }
                    // --
                    cell.Appearance.Image = FCommon.getImageOfModelVersion(grdClass, row.Cells["Type"].Text);
                }
                else
                {
                    // ***
                    // Delete model information in tabMain
                    // ***
                    row = grdClass.Rows.GetRowWithListIndex(index);
                    foreach (UltraGridRow r in row.ChildBands["Version"].Rows)
                    {
                        if (r.Tag.Equals(ver))
                        {
                            childRow = r;
                            break;
                        }
                    }

                    // --

                    if (childRow != null)
                    {
                        grdClass.getDataRow(index).GetChildRows("Version").RemoveAt(childRow.Index, false);
                    }
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
                row = null;
                childRow = null;
                cell = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMonitoringComponentData(
            FMonitoringComponentDataReceivedEventArgs args
            )
        {
            UltraGridRow row = null;
            UltraGridCell cell = null;
            object[] cellValues = null;
            string com = string.Empty;
            string comDesc = string.Empty;
            string comType = string.Empty;
            string releaseVer = string.Empty;
            int index = 0;

            try
            {
                if (tabMain.ActiveTab.Key != "Component")
                {
                    return;
                }

                // --

                grdClass.beginUpdate(false);

                // --

                com = args.fXmlNode.get_elemVal(FADMADS_TolComponentDataPush_In.FComponent.A_Name, FADMADS_TolComponentDataPush_In.FComponent.D_Name);
                comDesc = args.fXmlNode.get_elemVal(FADMADS_TolComponentDataPush_In.FComponent.A_Description, FADMADS_TolComponentDataPush_In.FComponent.D_Description);
                comType = args.fXmlNode.get_elemVal(FADMADS_TolComponentDataPush_In.FComponent.A_Type, FADMADS_TolComponentDataPush_In.FComponent.D_Type);
                releaseVer = args.fXmlNode.get_elemVal(FADMADS_TolComponentDataPush_In.FComponent.A_ReleaseVer, FADMADS_TolComponentDataPush_In.FComponent.D_ReleaseVer);

                // --

                if (args.fType == FMonitoringDataType.Update)
                {
                    // ***
                    // Insert or Update component information in tabMain
                    // ***
                    cellValues = new object[] {
                        com,
                        comDesc,
                        null,
                        null,
                        null,
                        null,
                        comType
                        };

                    // --

                    index = grdClass.appendOrUpdateDataRow(com, cellValues).Index;
                    row = grdClass.Rows.GetRowWithListIndex(index);
                    row.Tag = releaseVer;

                    // --

                    cell = row.Cells["Name"];
                    cell.Appearance.Image = FCommon.getImageOfComponent(grdClass, comType);
                }
                else
                {
                    // ***
                    // Delete component information in tabMain
                    // ***
                    grdClass.removeDataRow(com);
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

        private void procMonitoringComponentVerData(
            FMonitoringComponentVerDataReceivedEventArgs args
            )
        {
            UltraGridRow row = null;
            UltraGridRow childRow = null;
            UltraGridCell cell = null;
            object[] cellValues = null;
            string com = string.Empty;
            string ver = string.Empty;
            string verDesc = string.Empty;
            string verRelease = string.Empty;
            int index = 0;
            int childIndex = 0;

            try
            {
                if (tabMain.ActiveTab.Key != "Component")
                {
                    return;
                }

                // --

                grdClass.beginUpdate(false);

                // --

                com = args.fXmlNode.get_elemVal(FADMADS_TolComponentVerDataPush_In.FComponentVer.A_Name, FADMADS_TolComponentVerDataPush_In.FComponentVer.D_Name);
                ver = args.fXmlNode.get_elemVal(FADMADS_TolComponentVerDataPush_In.FComponentVer.A_Version, FADMADS_TolComponentVerDataPush_In.FComponentVer.D_Version);
                verDesc = args.fXmlNode.get_elemVal(FADMADS_TolComponentVerDataPush_In.FComponentVer.A_Description, FADMADS_TolComponentVerDataPush_In.FComponentVer.D_Description);
                verRelease = args.fXmlNode.get_elemVal(FADMADS_TolComponentVerDataPush_In.FComponentVer.A_Release, FADMADS_TolComponentVerDataPush_In.FComponentVer.D_Release);

                // --

                if ((index = grdClass.getDataRowIndex(com)) < 0)
                {
                    grdClass.endUpdate(false);
                    return;
                }
                
                // --

                if (args.fType == FMonitoringDataType.Update)
                {
                    // ***
                    // Insert or Update component information in tabMain
                    // ***
                    row = grdClass.Rows.GetRowWithListIndex(index);
                    foreach (UltraGridRow r in row.ChildBands["Version"].Rows)
                    {
                        if (verRelease.Equals(FYesNo.Yes.ToString()))
                        {
                            cell = r.Cells["Version"];
                            cell.Value = r.Tag;
                        }
                        // --
                        if (r.Tag.Equals(ver))
                        {
                            cell = r.Cells["Description"];
                            cell.Value = verDesc;
                            // --
                            childRow = r;
                        }
                    }

                    // --

                    if (childRow == null)
                    {
                        cellValues = new object[] {
                            ver,
                            verDesc
                            };
                        childIndex = grdClass.getDataRow(index).GetChildRows("Version").Insert(0, cellValues).Index; 
                        // --
                        childRow = grdClass.Rows[index].ChildBands["Version"].Rows[childIndex];
                        childRow.Tag = ver;
                    }

                    // --

                    cell = childRow.Cells["Version"];
                    // --
                    if (verRelease == FYesNo.Yes.ToString())
                    {
                        cell.Value = ver + "*";
                        row.Tag = ver;  // Component Release Version 설정
                    }
                    else
                    {
                        cell.Value = ver;
                    }
                    cell.Appearance.Image = FCommon.getImageOfComponentVersion(grdClass, row.Cells["Type"].Text);
                }
                else
                {
                    // ***
                    // Delete component information in tabMain
                    // ***
                    row = grdClass.Rows.GetRowWithListIndex(index);
                    foreach (UltraGridRow r in row.ChildBands["Version"].Rows)
                    {
                        if (r.Tag.Equals(ver))
                        {
                            childRow = r;
                            break;
                        }
                    }

                    // --

                    if (childRow != null)
                    {
                        grdClass.getDataRow(index).GetChildRows("Version").RemoveAt(childRow.Index, false);
                    }
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
                row = null;
                childRow = null;
                cell = null;
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
                if (!tabMain.ActiveTab.Key.Equals("Equipment Type"))
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
                    // Delete Equipment Type information in tabMain
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
                if (!tabMain.ActiveTab.Key.Equals("Equipment Area"))
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
                if (!tabMain.ActiveTab.Key.Equals("Equipment Line"))
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

        #region Server Popup Menu

        private void procMenuServerStatus(
            )
        {
            FServerStatus fServerStatus = null;

            try
            {
                fServerStatus = (FServerStatus)m_fAdmCore.fAdmContainer.getChild(typeof(FServerStatus));
                if (fServerStatus == null)
                {
                    fServerStatus = new FServerStatus(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fServerStatus);
                }
                fServerStatus.activate();
                fServerStatus.attach(grdClass.activeDataRowKey);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fServerStatus = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuServerHistory(
            )
        {
            FServerHistory fServerHistory = null;

            try
            {
                fServerHistory = (FServerHistory)m_fAdmCore.fAdmContainer.getChild(typeof(FServerHistory));
                if (fServerHistory == null)
                {
                    fServerHistory = new FServerHistory(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fServerHistory);
                }
                fServerHistory.activate();
                fServerHistory.attach(grdClass.activeDataRowKey);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fServerHistory = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuServerResourceStatus(
            )
        {
            FServerResourceStatus fServerResourceStatus = null;

            try
            {
                fServerResourceStatus = (FServerResourceStatus)m_fAdmCore.fAdmContainer.getChild(typeof(FServerResourceStatus));
                if (fServerResourceStatus == null)
                {
                    fServerResourceStatus = new FServerResourceStatus(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fServerResourceStatus);
                }
                fServerResourceStatus.activate();
                fServerResourceStatus.attach(grdClass.activeDataRowKey);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fServerResourceStatus = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuServerResourceHistory(
            )
        {
            FServerResourceHistory fServerResourceHistory = null;

            try
            {
                fServerResourceHistory = (FServerResourceHistory)m_fAdmCore.fAdmContainer.getChild(typeof(FServerResourceHistory));
                if (fServerResourceHistory == null)
                {
                    fServerResourceHistory = new FServerResourceHistory(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fServerResourceHistory);
                }
                fServerResourceHistory.activate();
                fServerResourceHistory.attach(grdClass.activeDataRowKey);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fServerResourceHistory = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuServerMainSwitch(
            )
        {
            FServerMainSwitch fServerMainSwitch = null;

            try
            {
                fServerMainSwitch = (FServerMainSwitch)m_fAdmCore.fAdmContainer.getChild(typeof(FServerMainSwitch));
                if (fServerMainSwitch == null)
                {
                    fServerMainSwitch = new FServerMainSwitch(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fServerMainSwitch);
                }
                fServerMainSwitch.activate();
                fServerMainSwitch.attach(grdClass.activeDataRowKey);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fServerMainSwitch = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuServerBackupSwitch(
            )
        {
            FServerBackupSwitch fServerBackupSwitch = null;

            try
            {
                fServerBackupSwitch = (FServerBackupSwitch)m_fAdmCore.fAdmContainer.getChild(typeof(FServerBackupSwitch));
                if (fServerBackupSwitch == null)
                {
                    fServerBackupSwitch = new FServerBackupSwitch(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fServerBackupSwitch);
                }
                fServerBackupSwitch.activate();
                fServerBackupSwitch.attach(grdClass.activeDataRowKey);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fServerBackupSwitch = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuAdminAgentLogList(
            )
        {
            FAdminAgentLogList fAdminAgentLogList = null;

            try
            {
                fAdminAgentLogList = (FAdminAgentLogList)m_fAdmCore.fAdmContainer.getChild(typeof(FAdminAgentLogList));
                if (fAdminAgentLogList == null)
                {
                    fAdminAgentLogList = new FAdminAgentLogList(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fAdminAgentLogList);
                }
                fAdminAgentLogList.activate();
                fAdminAgentLogList.attach(grdClass.activeDataRowKey);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fAdminAgentLogList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuAdminAgentBackupLogList(
            )
        {
            FAdminAgentBackupLogList fAdminAgentBackupLogList = null;

            try
            {
                fAdminAgentBackupLogList = (FAdminAgentBackupLogList)m_fAdmCore.fAdmContainer.getChild(typeof(FAdminAgentBackupLogList));
                if (fAdminAgentBackupLogList == null)
                {
                    fAdminAgentBackupLogList = new FAdminAgentBackupLogList(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fAdminAgentBackupLogList);
                }
                fAdminAgentBackupLogList.activate();
                fAdminAgentBackupLogList.attach(grdClass.activeDataRowKey);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fAdminAgentBackupLogList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuRemotePingTest(
            )
        {
            FRemotePingTestByServer fRemotePingTest = null;

            try
            {
                fRemotePingTest = (FRemotePingTestByServer)m_fAdmCore.fAdmContainer.getChild(typeof(FRemotePingTestByServer));
                if (fRemotePingTest == null)
                {
                    fRemotePingTest = new FRemotePingTestByServer(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fRemotePingTest);
                }
                fRemotePingTest.activate();
                fRemotePingTest.attach(grdClass.selectedDataRowKeys);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fRemotePingTest = null;
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

        #region Package Popup Menu

        private void procMenuPackageStatus(
            )
        {
            FPackageStatus fPackageStatus = null;
            string package = string.Empty;
            string packageType = string.Empty;
            string packageVer = string.Empty;

            try
            {
                fPackageStatus = (FPackageStatus)m_fAdmCore.fAdmContainer.getChild(typeof(FPackageStatus));
                if (fPackageStatus == null)
                {
                    fPackageStatus = new FPackageStatus(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fPackageStatus);
                }
                fPackageStatus.activate();

                // --
                
                if (grdClass.ActiveRow.ParentRow == null)
                {
                    package = grdClass.activeDataRowKey;
                    packageType = grdClass.ActiveRow.Cells["Type"].Text;
                    packageVer = (string)grdClass.ActiveRow.Tag;
                }
                else
                {
                    package = grdClass.ActiveRow.ParentRow.Cells["Name"].Text;
                    packageType = grdClass.ActiveRow.ParentRow.Cells["Type"].Text;
                    packageVer = (string)grdClass.ActiveRow.Tag;
                }
                fPackageStatus.attach(package, packageType, packageVer);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPackageStatus = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Model Popup Menu

        private void procMenuModelStatus(
            )
        {
            FModelStatus fModelStatus = null;
            string model = string.Empty;
            string modelType = string.Empty;
            string modelVer = string.Empty;

            try
            {
                fModelStatus = (FModelStatus)m_fAdmCore.fAdmContainer.getChild(typeof(FModelStatus));
                if (fModelStatus == null)
                {
                    fModelStatus = new FModelStatus(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fModelStatus);
                }
                fModelStatus.activate();

                // --
                
                if (grdClass.ActiveRow.ParentRow == null)
                {
                    model = grdClass.activeDataRowKey;
                    modelType = grdClass.ActiveRow.Cells["Type"].Text;
                    modelVer = (string)grdClass.ActiveRow.Tag;
                }
                else
                {
                    model = grdClass.ActiveRow.ParentRow.Cells["Name"].Text;
                    modelType = grdClass.ActiveRow.ParentRow.Cells["Type"].Text;
                    modelVer = (string)grdClass.ActiveRow.Tag;
                }
                fModelStatus.attach(model, modelType, modelVer);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fModelStatus = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Component Popup Menu

        private void procMenuComponentStatus(
            )
        {
            FComponentStatus fComponentStatus = null;
            string component = string.Empty;
            string componentType = string.Empty;
            string componentVer = string.Empty;

            try
            {
                fComponentStatus = (FComponentStatus)m_fAdmCore.fAdmContainer.getChild(typeof(FComponentStatus));
                if (fComponentStatus == null)
                {
                    fComponentStatus = new FComponentStatus(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fComponentStatus);
                }
                fComponentStatus.activate();

                // --

                if (grdClass.ActiveRow.ParentRow == null)
                {
                    component = grdClass.activeDataRowKey;
                    componentType = grdClass.ActiveRow.Cells["Type"].Text;
                    componentVer = (string)grdClass.ActiveRow.Tag;
                }
                else
                {
                    component = grdClass.ActiveRow.ParentRow.Cells["Name"].Text;
                    componentType = grdClass.ActiveRow.ParentRow.Cells["Type"].Text;
                    componentVer = (string)grdClass.ActiveRow.Tag;
                }
                fComponentStatus.attach(component, componentType, componentVer);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fComponentStatus = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region EAP Popup Menu

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

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapModelDownload(
            )
        {
            FolderBrowserDialog fbd = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInEap = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutEap = null;
            FFtp fFtp = null;
            string downloadFilePath = string.Empty;
            string tempFilePath = string.Empty;
            string zipFileName = string.Empty;

            try
            {
                fbd = new FolderBrowserDialog();
                fbd.SelectedPath = m_fAdmCore.fOption.recentDownloadPath;
                if (fbd.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                // ***
                // Temp Directory Create
                // ***
                tempFilePath = Path.Combine(m_fAdmCore.fWsmCore.tempPath, Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempFilePath);

                // --

                // ***
                // FTP Create
                // ***
                fFtp = FCommon.createFtp(m_fAdmCore);

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TolEapModelDownload_In.E_ADMADS_TolEapModelDownload_In);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapModelDownload_In.A_hLanguage, FADMADS_TolEapModelDownload_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TolEapModelDownload_In.A_hFactory, FADMADS_TolEapModelDownload_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapModelDownload_In.A_hUserId, FADMADS_TolEapModelDownload_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapModelDownload_In.A_hStep, FADMADS_TolEapModelDownload_In.D_hStep, "1");
                // --
                fXmlNodeInEap = fXmlNodeIn.set_elem(FADMADS_TolEapModelDownload_In.FEap.E_Eap);
                fXmlNodeInEap.set_elemVal(FADMADS_TolEapModelDownload_In.FEap.A_Name, FADMADS_TolEapModelDownload_In.FEap.D_Name, activeEap);

                // --

                FADMADSCaster.ADMADS_TolEapModelDownload_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_TolEapModelDownload_Out.A_hStatus, FADMADS_TolEapModelDownload_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_TolEapModelDownload_Out.A_hStatusMessage, FADMADS_TolEapModelDownload_Out.D_hStatusMessage)
                        );
                }

                // --

                fXmlNodeOutEap = fXmlNodeOut.get_elem(FADMADS_TolEapModelDownload_Out.FEap.E_Eap);
                zipFileName = fXmlNodeOutEap.get_elemVal(FADMADS_TolEapModelDownload_Out.FEap.A_Path, FADMADS_TolEapModelDownload_Out.FEap.D_Path);

                // --

                fFtp.downloadFiles(tempFilePath, zipFileName);
                fFtp.deleteFiles(zipFileName);

                // --

                zipFileName = tempFilePath + "\\" + zipFileName;
                downloadFilePath = Path.Combine(fbd.SelectedPath, m_fAdmCore.fOption.factory + "_" + activeEap);
                if (Directory.Exists(downloadFilePath))
                {
                    Directory.Delete(downloadFilePath, true);
                }
                Directory.CreateDirectory(downloadFilePath);
                // --
                F7Zip.unpack(zipFileName, downloadFilePath);

                // --

                m_fAdmCore.fOption.recentDownloadPath = fbd.SelectedPath;
                FCommon.deleteDirectory(tempFilePath);

                // --

                // ***
                // Download Folder Open
                // ***
                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0005"),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                Process.Start("explorer.exe", "/select, " + downloadFilePath);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fFtp != null)
                {
                    fFtp.Dispose();
                    fFtp = null;
                }

                // --

                fXmlNodeIn = null;
                fXmlNodeInEap = null;
                fXmlNodeOut = null;
                fXmlNodeOutEap = null;
                fbd = null;
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
                fEqStatus.attach(this.activeEq, FEapAttrCategory.Applied.ToString());
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
                fEqHistory.attach(activeEq);               
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

        private void procMenuEqtEventDefineRequest(
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
                fEqVersionRequest.attach(this.selectedEqs, this.activeEap);
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
                fEqControlModeRequest.attach(this.selectedEqs, this.activeEap);
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

        private void procMenuEapInsert(
            )
        {
            FEapTypeSelector fEapTypeSelector = null;
            FSecsEapWizard fSecsEapWizard = null;
            //FPlcEapWizard fPlcEapWizard = null;
            FOpcEapWizard fOpcEapWizard = null;
            FTcpEapWizard fTcpEapWizard = null;
            FFileEapWizard fFileEapWizard = null;
            FChdEapWizard fChdEapWizard = null;
            FProcessEapWizard fProcessEapWizard = null;

            try
            {
                // ***
                // Check Eap Transaction Authority 
                // ***
                if (!FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.Eap))
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0047"));
                }

                // --

                fEapTypeSelector = new FEapTypeSelector(m_fAdmCore);
                // --
                if (fEapTypeSelector.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                if (fEapTypeSelector.fEapType == FEapType.SECS)
                {
                    fSecsEapWizard = new FSecsEapWizard(m_fAdmCore);
                    fSecsEapWizard.ShowDialog();                    
                }
                //else if (fEapTypeSelector.fEapType == FEapType.PLC)
                //{
                //    fPlcEapWizard = new FPlcEapWizard(m_fAdmCore);
                //    fPlcEapWizard.ShowDialog();
                //}
                else if (fEapTypeSelector.fEapType == FEapType.OPC)
                {
                    fOpcEapWizard = new FOpcEapWizard(m_fAdmCore);
                    fOpcEapWizard.ShowDialog();
                }
                else if (fEapTypeSelector.fEapType == FEapType.TCP)
                {
                    fTcpEapWizard = new FTcpEapWizard(m_fAdmCore);
                    fTcpEapWizard.ShowDialog();                    
                }
                else if (fEapTypeSelector.fEapType == FEapType.CHD)
                {
                    fChdEapWizard = new FChdEapWizard(m_fAdmCore);
                    fChdEapWizard.ShowDialog();
                }
                else if (fEapTypeSelector.fEapType == FEapType.Process)
                {
                    fProcessEapWizard = new FProcessEapWizard(m_fAdmCore);
                    fProcessEapWizard.ShowDialog();
                }
                else if (fEapTypeSelector.fEapType == FEapType.FILE)
                {
                    fFileEapWizard = new FFileEapWizard(m_fAdmCore);
                    fFileEapWizard.ShowDialog();
                }
                else
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0015", new object[] { "EAP Type" }));
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fEapTypeSelector != null)
                {
                    fEapTypeSelector.Dispose();
                    fEapTypeSelector = null;
                }
                if (fSecsEapWizard != null)
                {
                    fSecsEapWizard.Dispose();
                    fSecsEapWizard = null;
                }
                //if (fPlcEapWizard != null)
                //{
                //    fPlcEapWizard.Dispose();
                //    fPlcEapWizard = null;
                //}
                if (fOpcEapWizard != null)
                {
                    fOpcEapWizard.Dispose();
                    fOpcEapWizard = null;
                }
                if (fTcpEapWizard != null)
                {
                    fTcpEapWizard.Dispose();
                    fTcpEapWizard = null;
                }
                if (fChdEapWizard != null)
                {
                    fChdEapWizard.Dispose();
                    fChdEapWizard = null;
                }
                if (fProcessEapWizard != null)
                {
                    fProcessEapWizard.Dispose();
                    fProcessEapWizard = null;
                }
                if (fFileEapWizard != null)
                {
                    fFileEapWizard.Dispose();
                    fFileEapWizard = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapUpdate(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            DataRow r = null;
            FSecsEapWizard fSecsEapWizard = null;
            //FPlcEapWizard fPlcEapWizard = null;
            FOpcEapWizard fOpcEapWizard = null;
            FTcpEapWizard fTcpEapWizard = null;
            FFileEapWizard fFileEapWizard = null;
            FChdEapWizard fChdEapWizard = null;
            FProcessEapWizard fProcessEapWizard = null;
            FEapWizardData fEapWizardData = null;
            
            try
            {
                // ***
                // Check Eap Transaction Authority 
                // ***
                if (!FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.Eap))
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0047"));
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("attr_category", FEapAttrCategory.Setup.ToString());
                fSqlParams.add("eap", this.activeEap);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Tool", "EapMonitor", "SearchEapForUpdate", fSqlParams, true);
                r = dt.Rows[0];

                // --

                fEapWizardData = new FEapWizardData();
                // --
                fEapWizardData.eap = r[0].ToString();
                fEapWizardData.description = r[1].ToString();
                fEapWizardData.fEapType = (FEapType)Enum.Parse(typeof(FEapType), r[2].ToString());
                fEapWizardData.fOperMode = (FEapOperationMode)Enum.Parse(typeof(FEapOperationMode), r[3].ToString());
                fEapWizardData.server = r[4].ToString();
                fEapWizardData.step = r[5].ToString();
                fEapWizardData.package = r[6].ToString();
                fEapWizardData.packageVer = r[7].ToString();
                fEapWizardData.model = r[8].ToString();
                fEapWizardData.modelVer = r[9].ToString();
                fEapWizardData.usedComponent = (r[10].ToString() == FYesNo.Yes.ToString() ? FYesNo.Yes : FYesNo.No);
                fEapWizardData.component = r[11].ToString();
                fEapWizardData.componentVer = r[12].ToString();
                fEapWizardData.wizardMode = FEapWizardMode.Update;
                // --

                if (fEapWizardData.fEapType == FEapType.SECS)
                {
                    fSecsEapWizard = new FSecsEapWizard(m_fAdmCore, fEapWizardData);
                    fSecsEapWizard.ShowDialog();
                }
                //else if (fEapWizardData.fEapType == FEapType.PLC)
                //{
                //    fPlcEapWizard = new FPlcEapWizard(m_fAdmCore, fEapWizardData);
                //    fPlcEapWizard.ShowDialog();
                //}
                else if (fEapWizardData.fEapType == FEapType.OPC)
                {
                    fOpcEapWizard = new FOpcEapWizard(m_fAdmCore, fEapWizardData);
                    fOpcEapWizard.ShowDialog();
                }
                else if (fEapWizardData.fEapType == FEapType.TCP)
                {
                    fTcpEapWizard = new FTcpEapWizard(m_fAdmCore, fEapWizardData);
                    fTcpEapWizard.ShowDialog();
                }
                else if (fEapWizardData.fEapType == FEapType.CHD)
                {
                    fChdEapWizard = new FChdEapWizard(m_fAdmCore, fEapWizardData);
                    fChdEapWizard.ShowDialog();
                }
                else if (fEapWizardData.fEapType == FEapType.Process)
                {
                    fProcessEapWizard = new FProcessEapWizard(m_fAdmCore, fEapWizardData);
                    fProcessEapWizard.ShowDialog();
                }
                else if (fEapWizardData.fEapType == FEapType.FILE)
                {
                    fFileEapWizard = new FFileEapWizard(m_fAdmCore, fEapWizardData);
                    fFileEapWizard.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fSecsEapWizard != null)
                {
                    fSecsEapWizard.Dispose();
                    fSecsEapWizard = null;
                }
                //if (fPlcEapWizard != null)
                //{
                //    fPlcEapWizard.Dispose();
                //    fPlcEapWizard = null;
                //}
                if (fOpcEapWizard != null)
                {
                    fOpcEapWizard.Dispose();
                    fOpcEapWizard = null;
                }
                if (fTcpEapWizard != null)
                {
                    fTcpEapWizard.Dispose();
                    fTcpEapWizard = null;
                }
                if (fChdEapWizard != null)
                {
                    fChdEapWizard.Dispose();
                    fChdEapWizard = null;
                }
                if (fProcessEapWizard != null)
                {
                    fProcessEapWizard.Dispose();
                    fProcessEapWizard = null;
                }
                if (fFileEapWizard != null)
                {
                    fFileEapWizard.Dispose();
                    fFileEapWizard = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapClone(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            DataRow r = null;
            FSecsEapWizard fSecsEapWizard = null;
            //FPlcEapWizard fPlcEapWizard = null;
            FOpcEapWizard fOpcEapWizard = null;
            FTcpEapWizard fTcpEapWizard = null;
            FFileEapWizard fFileEapWizard = null;
            FChdEapWizard fChdEapWizard = null;
            FProcessEapWizard fProcessEapWizard = null;
            FEapWizardData fEapWizardData = null;

            try
            {
                // ***
                // Check Eap Transaction Authority 
                // ***
                if (!FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.Eap))
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0047"));
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("attr_category", FEapAttrCategory.Setup.ToString());
                fSqlParams.add("eap", this.activeEap);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Tool", "EapMonitor", "SearchEapForClone", fSqlParams, true);
                r = dt.Rows[0];

                // --

                fEapWizardData = new FEapWizardData();
                // --
                fEapWizardData.eap = this.activeEap;
                fEapWizardData.description = string.Empty;
                fEapWizardData.fEapType = (FEapType)Enum.Parse(typeof(FEapType), r[0].ToString());
                fEapWizardData.fOperMode = (FEapOperationMode)Enum.Parse(typeof(FEapOperationMode), r[1].ToString());
                fEapWizardData.server = r[2].ToString();
                fEapWizardData.step = r[3].ToString();
                fEapWizardData.package = r[4].ToString();
                fEapWizardData.packageVer = r[5].ToString();
                fEapWizardData.model = r[6].ToString();
                fEapWizardData.modelVer = r[7].ToString();
                fEapWizardData.usedComponent = (r[8].ToString() == FYesNo.Yes.ToString() ? FYesNo.Yes : FYesNo.No);
                fEapWizardData.component = r[9].ToString();
                fEapWizardData.componentVer = r[10].ToString();
                fEapWizardData.wizardMode = FEapWizardMode.Clone;

                // --

                if (fEapWizardData.fEapType == FEapType.SECS)
                {
                    fSecsEapWizard = new FSecsEapWizard(m_fAdmCore, fEapWizardData);
                    fSecsEapWizard.ShowDialog();
                }
                //else if (fEapWizardData.fEapType == FEapType.PLC)
                //{
                //    fPlcEapWizard = new FPlcEapWizard(m_fAdmCore, fEapWizardData);
                //    fPlcEapWizard.ShowDialog();
                //}
                else if (fEapWizardData.fEapType == FEapType.OPC)
                {
                    fOpcEapWizard = new FOpcEapWizard(m_fAdmCore, fEapWizardData);
                    fOpcEapWizard.ShowDialog();
                }
                else if (fEapWizardData.fEapType == FEapType.TCP)
                {
                    fTcpEapWizard = new FTcpEapWizard(m_fAdmCore, fEapWizardData);
                    fTcpEapWizard.ShowDialog();
                }
                else if (fEapWizardData.fEapType == FEapType.CHD)
                {
                    fChdEapWizard = new FChdEapWizard(m_fAdmCore, fEapWizardData);
                    fChdEapWizard.ShowDialog();
                }
                else if (fEapWizardData.fEapType == FEapType.Process)
                {
                    fProcessEapWizard = new FProcessEapWizard(m_fAdmCore, fEapWizardData);
                    fProcessEapWizard.ShowDialog();
                }
                else if (fEapWizardData.fEapType == FEapType.FILE)
                {
                    fFileEapWizard = new FFileEapWizard(m_fAdmCore, fEapWizardData);
                    fFileEapWizard.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fSecsEapWizard != null)
                {
                    fSecsEapWizard.Dispose();
                    fSecsEapWizard = null;
                }
                //if (fPlcEapWizard != null)
                //{
                //    fPlcEapWizard.Dispose();
                //    fPlcEapWizard = null;
                //}
                if (fOpcEapWizard != null)
                {
                    fOpcEapWizard.Dispose();
                    fOpcEapWizard = null;
                }
                if (fTcpEapWizard != null)
                {
                    fTcpEapWizard.Dispose();
                    fTcpEapWizard = null;
                }
                if (fChdEapWizard != null)
                {
                    fChdEapWizard.Dispose();
                    fChdEapWizard = null;
                }
                if (fProcessEapWizard != null)
                {
                    fProcessEapWizard.Dispose();
                    fProcessEapWizard = null;
                }
                if (fFileEapWizard != null)
                {
                    fFileEapWizard.Dispose();
                    fFileEapWizard = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapDelete(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInEap = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                // ***
                // Check Eap Transaction Authority 
                // ***
                if (!FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.Eap))
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0047"));
                }

                // --

                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0003", new object[] { "Selected EAP" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetEapUpdate_In.E_ADMADS_SetEapUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetEapUpdate_In.A_hLanguage, FADMADS_SetEapUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetEapUpdate_In.A_hFactory, FADMADS_SetEapUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetEapUpdate_In.A_hUserId, FADMADS_SetEapUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetEapUpdate_In.A_hHostIp, FADMADS_SetEapUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetEapUpdate_In.A_hHostName, FADMADS_SetEapUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetEapUpdate_In.A_hStep, FADMADS_SetEapUpdate_In.D_hStep, "3");

                // --

                fXmlNodeInEap = fXmlNodeIn.set_elem(FADMADS_SetEapUpdate_In.FEap.E_Eap);

                // --

                foreach (string eap in grdEap.selectedDataRowKeys)
                {
                    fXmlNodeInEap.set_elemVal(FADMADS_SetEapUpdate_In.FEap.A_Name, FADMADS_SetEapUpdate_In.FEap.D_Name, eap);

                    // --

                    FADMADSCaster.ADMADS_SetEapUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetEapUpdate_Out.A_hStatus, FADMADS_SetEapUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(
                            fXmlNodeOut.get_elemVal(FADMADS_SetEapUpdate_Out.A_hStatusMessage, FADMADS_SetEapUpdate_Out.D_hStatusMessage)
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
                fXmlNodeIn = null;
                fXmlNodeInEap = null;
                fXmlNodeOut = null;
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

        private void procMenuEapLogLevelSetup(
            )
        {
            FEapLogLevelSetup fEapLogLevelSetup = null;

            try
            {
                fEapLogLevelSetup = (FEapLogLevelSetup)m_fAdmCore.fAdmContainer.getChild(typeof(FEapLogLevelSetup));
                if (fEapLogLevelSetup == null)
                {
                    fEapLogLevelSetup = new FEapLogLevelSetup(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEapLogLevelSetup);
                }
                fEapLogLevelSetup.activate();
                fEapLogLevelSetup.attach(this.activeEap);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapLogLevelSetup = null;
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

        #endregion

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FEapMonitor Form Event Handler

        private void FEapMonitor_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfEap();
                designGridOfEapClass();
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

        private void FEapMonitor_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshClassGridOfServer();

                // --

                // ***
                // FAdsCore Event Handler 설정
                // ***
                m_fAdmCore.MonitoringServerDataReceived += new FMonitoringServerDataReceivedEventHandler(m_fAdmCore_MonitoringServerDataReceived);
                m_fAdmCore.MonitoringPackageDataReceived += new FMonitoringPackageDataReceivedEventHandler(m_fAdmCore_MonitoringPackageDataReceived);
                m_fAdmCore.MonitoringPackageVerDataReceived += new FMonitoringPackageVerDataReceivedEventHandler(m_fAdmCore_MonitoringPackageVerDataReceived);
                m_fAdmCore.MonitoringModelDataReceived += new FMonitoringModelDataReceivedEventHandler(m_fAdmCore_MonitoringModelDataReceived);
                m_fAdmCore.MonitoringModelVerDataReceived += new FMonitoringModelVerDataReceivedEventHandler(m_fAdmCore_MonitoringModelVerDataReceived);
                m_fAdmCore.MonitoringComponentDataReceived += new FMonitoringComponentDataReceivedEventHandler(m_fAdmCore_MonitoringComponentDataReceived);
                m_fAdmCore.MonitoringComponentVerDataReceived += new FMonitoringComponentVerDataReceivedEventHandler(m_fAdmCore_MonitoringComponentVerDataReceived);
                m_fAdmCore.MonitoringEapDataReceived += new FMonitoringEapDataReceivedEventHandler(m_fAdmCore_MonitoringEapDataReceived);
                // --
                m_fAdmCore.MonitoringEquipmentTypeDataReceived += new FMonitoringEquipmentTypeDataReceivedEventHandler(m_fAdmCore_MonitoringEquipmentTypeDataReceived);
                m_fAdmCore.MonitoringEquipmentAreaDataReceived += new FMonitoringEquipmentAreaDataReceivedEventHandler(m_fAdmCore_MonitoringEquipmentAreaDataReceived);
                m_fAdmCore.MonitoringEquipmentLineDataReceived += new FMonitoringEquipmentLineDataReceivedEventHandler(m_fAdmCore_MonitoringEquipmentLineDataReceived);

                // --

                grdEap.Focus();
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

        private void FEapMonitor_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                // ***
                // FAdsCore Event Handler 설정
                // ***
                m_fAdmCore.MonitoringServerDataReceived -= new FMonitoringServerDataReceivedEventHandler(m_fAdmCore_MonitoringServerDataReceived);
                m_fAdmCore.MonitoringPackageDataReceived -= new FMonitoringPackageDataReceivedEventHandler(m_fAdmCore_MonitoringPackageDataReceived);
                m_fAdmCore.MonitoringPackageVerDataReceived -= new FMonitoringPackageVerDataReceivedEventHandler(m_fAdmCore_MonitoringPackageVerDataReceived);
                m_fAdmCore.MonitoringModelDataReceived -= new FMonitoringModelDataReceivedEventHandler(m_fAdmCore_MonitoringModelDataReceived);
                m_fAdmCore.MonitoringModelVerDataReceived -= new FMonitoringModelVerDataReceivedEventHandler(m_fAdmCore_MonitoringModelVerDataReceived);
                m_fAdmCore.MonitoringComponentDataReceived -= new FMonitoringComponentDataReceivedEventHandler(m_fAdmCore_MonitoringComponentDataReceived);
                m_fAdmCore.MonitoringComponentVerDataReceived -= new FMonitoringComponentVerDataReceivedEventHandler(m_fAdmCore_MonitoringComponentVerDataReceived);
                m_fAdmCore.MonitoringEapDataReceived -= new FMonitoringEapDataReceivedEventHandler(m_fAdmCore_MonitoringEapDataReceived);
                // --
                m_fAdmCore.MonitoringEquipmentTypeDataReceived -= new FMonitoringEquipmentTypeDataReceivedEventHandler(m_fAdmCore_MonitoringEquipmentTypeDataReceived);
                m_fAdmCore.MonitoringEquipmentAreaDataReceived -= new FMonitoringEquipmentAreaDataReceivedEventHandler(m_fAdmCore_MonitoringEquipmentAreaDataReceived);
                m_fAdmCore.MonitoringEquipmentLineDataReceived -= new FMonitoringEquipmentLineDataReceivedEventHandler(m_fAdmCore_MonitoringEquipmentLineDataReceived);

                // --

                // ***
                // 2013.01.16 by spike.lee
                // 참 띠어 쓰기 못 한다. 소스는 깔끔하게~~
                // ***
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

        private void FEapMonitor_KeyDown(
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
                    if (grdClass.Focused)
                    {
                        if (tabMain.ActiveTab.Key == "Server")
                        {
                            refreshClassGridOfServer();
                        }
                        else if (tabMain.ActiveTab.Key == "Package")
                        {
                            refreshClassGridOfPackage();
                        }
                        else if (tabMain.ActiveTab.Key == "Model")
                        {
                            refreshClassGridOfModel();
                        }
                        else if (tabMain.ActiveTab.Key == "Component")
                        {
                            refreshClassGridOfComponent();
                        }
                    }
                    else
                    {
                        refreshGridOfEap();
                        // --
                        grdEap.Focus();
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
                if (e.Tool.Key == FMenuKey.MenuMonNewEap)
                {
                    procMenuEapInsert();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonEapUpdate)
                {
                    procMenuEapUpdate();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonEapClone)
                {
                    procMenuEapClone();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonEapDelete)
                {
                    procMenuEapDelete();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonEapRelease)
                {
                    procMenuEapRelease();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonEapStart)
                {
                    procMenuEapStart();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonEapStop)
                {
                    procMenuEapStop();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonEapReload)
                {
                    procMenuEapReload();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonEapRestart)
                {
                    procMenuEapRestart();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonEapAbort)
                {
                    procMenuEapAbort();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonEapMove)
                {
                    procMenuEapMove();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonEapLogLevelSetup)
                {
                    procMenuEapLogLevelSetup();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonEapLogList)
                {
                    procMenuEapLogList();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonEapBackupLogList)
                {
                    procMenuEapBackupLogList();
                }
                //else if (e.Tool.Key == FMenuKey.MenuMonEapInterfaceLogList)
                //{
                //    procMenuEapInterfaceLogList();
                //}
                //else if (e.Tool.Key == FMenuKey.MenuMonEapInterfaceBackupLogList)
                //{
                //    procMenuEapInterfaceBackupLogList();
                //}
                // --
                else if (e.Tool.Key == FMenuKey.MenuMonEapStatus)
                {
                    procMenuEapStatus();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonEapHistory)
                {
                    procMenuEapHistory();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonEapRepositoryStatus)
                {
                    procMenuEapRepositoryStatus();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuMonEapResourceHistory)
                {
                    procMenuEapResourceHistory();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuMonEapReferenceSheet)
                {
                    procMenuEapReferenceSheet();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuMonEapModelDownload)
                {
                    procMenuEapModelDownload();
                }

                // --

                else if (e.Tool.Key == FMenuKey.MenuMonServerStatus)
                {
                    procMenuServerStatus();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonServerHistory)
                {
                    procMenuServerHistory();
                }
                // --                
                else if (e.Tool.Key == FMenuKey.MenuMonServerResourceStatus)
                {
                    procMenuServerResourceStatus();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonServerResourceHistory)
                {
                    procMenuServerResourceHistory();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuMonServerMainSwitch)
                {
                    procMenuServerMainSwitch();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonServerBackupSwitch)
                {
                    procMenuServerBackupSwitch();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonAdminAgentLogList)
                {
                    procMenuAdminAgentLogList();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonAdminAgentBackupLogList)
                {
                    procMenuAdminAgentBackupLogList();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuMonRemotePingTestByServer)
                {
                    procMenuRemotePingTest();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonRemotePingTestByEquipment)
                {
                    procMenuRemotePingTestByEquipment();
                }


                // --

                else if (e.Tool.Key == FMenuKey.MenuMonPackageStatus)
                {
                    procMenuPackageStatus();
                }

                // --

                else if (e.Tool.Key == FMenuKey.MenuMonModelStatus)
                {
                    procMenuModelStatus();
                }

                // --

                else if (e.Tool.Key == FMenuKey.MenuMonComponentStatus)
                {
                    procMenuComponentStatus();
                }

                // --

                else if (e.Tool.Key == FMenuKey.MenuMonEquipmentStatus)
                {
                    procMenuEqStatus();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonEquipmentHistory)
                {
                    procMenuEqHistory();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuMonEquipmentGemStatus)
                {
                    procMenuEquipmentGemStatus();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuMonEquipmentEventDefineRequest)
                {
                    procMenuEqtEventDefineRequest();
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

                // ***
                // 2017.08.16 by spike.lee
                // EAP List Clear
                // ***
                grdEap.beginUpdate();
                grdEap.removeAllDataRow();
                grdEap.endUpdate();

                // --

                grdClass.DisplayLayout.Bands[0].Columns["Server Type"].Hidden = true;
                grdClass.DisplayLayout.Bands[0].Columns["Server IP"].Hidden = true;
                grdClass.DisplayLayout.Bands[0].Columns["Agent"].Hidden = true;
                grdClass.DisplayLayout.Bands[0].Columns["OPC Server"].Hidden = true;
                grdClass.DisplayLayout.Bands[0].Columns["Type"].Hidden = false;
                grdClass.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.MultiBand;

                // --

                if (e.Tab.Key == "Server")
                {
                    grdClass.DisplayLayout.Bands[0].Columns["Server Type"].Hidden = false;
                    grdClass.DisplayLayout.Bands[0].Columns["Server IP"].Hidden = false;
                    grdClass.DisplayLayout.Bands[0].Columns["Agent"].Hidden = false;
                    grdClass.DisplayLayout.Bands[0].Columns["OPC Server"].Hidden = false;
                    grdClass.DisplayLayout.Bands[0].Columns["Type"].Hidden = true;
                    grdClass.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
                    // --
                    refreshClassGridOfServer();
                }
                else if (e.Tab.Key == "Package")
                {
                    refreshClassGridOfPackage();
                }
                else if (e.Tab.Key == "Model")
                {
                    refreshClassGridOfModel();
                }
                else if (e.Tab.Key == "Component")
                {
                    refreshClassGridOfComponent();
                }
                // ***
                // 2017.08.17 by spike.lee
                // Equipment Type, Equipment Area, Equipment Line 별 EAP List 조회 기능 추가
                // ***
                else if (e.Tab.Key == "Equipment Type")
                {
                    grdClass.DisplayLayout.Bands[0].Columns["Type"].Hidden = true;
                    grdClass.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
                    // --
                    refreshClassGridOfEquipmentType();
                }
                else if (e.Tab.Key == "Equipment Area")
                {
                    grdClass.DisplayLayout.Bands[0].Columns["Type"].Hidden = true;
                    grdClass.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
                    // --
                    refreshClassGridOfEquipmentArea();
                }
                else if (e.Tab.Key == "Equipment Line")
                {
                    grdClass.DisplayLayout.Bands[0].Columns["Type"].Hidden = true;
                    grdClass.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
                    // --
                    refreshClassGridOfEquipmentLine();
                }
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

                refreshGridOfEap();
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

        private void grdClass_MouseDown(
            object sender, 
            MouseEventArgs e
            )
        {
            UltraGridRow r = null;
            string serverType = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                if (e.Button != MouseButtons.Right || grdClass.Rows.Count == 0)
                {
                    return;
                }

                // --

                r = (UltraGridRow)grdClass.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y)).GetContext(typeof(UltraGridRow));
                if (r != null)
                {
                    if (r.Band.Key == "Version")
                    {
                        grdClass.ActiveRow = grdClass.Rows[r.ParentRow.Index].ChildBands[r.Band.Key].Rows[r.Index];
                    }
                    else
                    {
                        grdClass.ActiveRow = grdClass.Rows[r.Index];
                    }
                }

                // --

                if (tabMain.SelectedTab == tabMain.Tabs["Server"])
                {
                    serverType = grdClass.activeDataRow["Server Type"].ToString(); 

                    // --

                    mnuMenu.Tools[FMenuKey.MenuMonServerStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerStatus);
                    mnuMenu.Tools[FMenuKey.MenuMonServerHistory].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerHistory);
                    // --                    
                    mnuMenu.Tools[FMenuKey.MenuMonServerResourceStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerResourceStatus);
                    mnuMenu.Tools[FMenuKey.MenuMonServerResourceHistory].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerResourceHistory);
                    // --
                    mnuMenu.Tools[FMenuKey.MenuMonServerMainSwitch].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerMainSwitch);
                    mnuMenu.Tools[FMenuKey.MenuMonServerBackupSwitch].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerBackupSwitch);
                    // --
                    mnuMenu.Tools[FMenuKey.MenuMonAdminAgentLogList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.AdminAgentLogList);
                    mnuMenu.Tools[FMenuKey.MenuMonAdminAgentBackupLogList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.AdminAgentBackupLogList);
                    // --
                    mnuMenu.Tools[FMenuKey.MenuMonRemotePingTestByServer].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.RemotePingTestByEquipment);

                    // --

                    #region Menu Control

                    if (serverType == FServerType.Virtual.ToString())
                    {
                        mnuMenu.Tools[FMenuKey.MenuMonServerResourceStatus].SharedProps.Enabled = false;
                        mnuMenu.Tools[FMenuKey.MenuMonServerResourceHistory].SharedProps.Enabled = false;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuMonServerMainSwitch].SharedProps.Enabled = false;
                        mnuMenu.Tools[FMenuKey.MenuMonServerBackupSwitch].SharedProps.Enabled = false;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuMonAdminAgentLogList].SharedProps.Enabled = false;
                        mnuMenu.Tools[FMenuKey.MenuMonAdminAgentBackupLogList].SharedProps.Enabled = false;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuMonRemotePingTestByServer].SharedProps.Enabled = false;
                    }

                    #endregion

                    // -- 

                    mnuMenu.ShowPopup(FMenuKey.MenuMonSvrPopupMenu);
                }

                else if (tabMain.SelectedTab == tabMain.Tabs["Package"])
                {
                    mnuMenu.Tools[FMenuKey.MenuMonPackageStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.PackageStatus);
                    
                    // --

                    mnuMenu.ShowPopup(FMenuKey.MenuMonPkgPopupMenu);
                }
                else if (tabMain.SelectedTab == tabMain.Tabs["Model"])
                {
                    mnuMenu.Tools[FMenuKey.MenuMonModelStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ModelStatus);

                    // --

                    mnuMenu.ShowPopup(FMenuKey.MenuMonMdlPopupMenu);
                }
                else if (tabMain.SelectedTab == tabMain.Tabs["Component"])
                {
                    mnuMenu.Tools[FMenuKey.MenuMonComponentStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ComponentStatus);

                    // --

                    mnuMenu.ShowPopup(FMenuKey.MenuMonComPopupMenu);
                }
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

                    // --

                    if (
                        tabMain.ActiveTab.Key == "Server" &&
                        FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerHistory)
                        )
                    {
                        procMenuServerHistory();
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

        #region grdEap Control Event Handler

        private void grdEap_AfterRowActivate(
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

        private void grdEap_MouseDown(
            object sender, 
            MouseEventArgs e
            )
        {
            UltraGridRow r = null;
            string eapType = string.Empty;
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

                mnuMenu.Tools[FMenuKey.MenuMonEapStatus].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapStatus) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuMonEapHistory].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapHistory) ? true : false;
                // --
                mnuMenu.Tools[FMenuKey.MenuMonEapRepositoryStatus].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapRepositoryStatus) ? true : false;
                // --
                mnuMenu.Tools[FMenuKey.MenuMonEapResourceHistory].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapResourceHistory) ? true : false;
                // --
                mnuMenu.Tools[FMenuKey.MenuMonNewEap].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Eap);
                mnuMenu.Tools[FMenuKey.MenuMonEapUpdate].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Eap) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuMonEapDelete].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Eap) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuMonEapClone].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Eap) ? true : false;
                // --
                mnuMenu.Tools[FMenuKey.MenuMonEapRelease].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapRelease) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuMonEapStart].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapStart) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuMonEapStop].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapStop) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuMonEapReload].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapReload) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuMonEapRestart].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapRestart) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuMonEapAbort].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapAbort) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuMonEapMove].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapMove) ? true : false;
                // --
                mnuMenu.Tools[FMenuKey.MenuMonEapLogList].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapLogList) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuMonEapBackupLogList].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapBackupLogList) ? true : false;
                // --
                // ***
                // 2017.06.02 by spike.lee
                // EAP Interface 관련 권한 추가
                // ***
                //mnuMenu.Tools[FMenuKey.MenuMonEapInterfaceLogList].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapInterfaceLogList) ? true : false;
                //mnuMenu.Tools[FMenuKey.MenuMonEapInterfaceBackupLogList].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapInterfaceBackupLogList) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuMonEapInterfaceLogList].SharedProps.Visible = false;
                mnuMenu.Tools[FMenuKey.MenuMonEapInterfaceBackupLogList].SharedProps.Visible = false;
                // --
                mnuMenu.Tools[FMenuKey.MenuMonEapReferenceSheet].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapReferenceSheet) ? true : false;
                
                // --

                #region Menu Control

                if (grdEap.ActiveRow != null)
                {
                    eapType = grdEap.activeDataRow["Type"].ToString();
                    operMode = grdEap.activeDataRow["Operation Mode"].ToString();

                    // --

                    if (eapType == FEapType.Process.ToString())
                    {
                        mnuMenu.Tools[FMenuKey.MenuMonEapRelease].SharedProps.Enabled = false;
                        mnuMenu.Tools[FMenuKey.MenuMonEapStart].SharedProps.Enabled = false;
                        mnuMenu.Tools[FMenuKey.MenuMonEapStop].SharedProps.Enabled = false;
                        mnuMenu.Tools[FMenuKey.MenuMonEapReload].SharedProps.Enabled = false;
                        mnuMenu.Tools[FMenuKey.MenuMonEapRestart].SharedProps.Enabled = false;
                        mnuMenu.Tools[FMenuKey.MenuMonEapAbort].SharedProps.Enabled = false;
                        mnuMenu.Tools[FMenuKey.MenuInqEapLogList].SharedProps.Enabled = false;
                        mnuMenu.Tools[FMenuKey.MenuInqEapBackupLogList].SharedProps.Enabled = false;
                        mnuMenu.Tools[FMenuKey.MenuInqEapInterfaceLogList].SharedProps.Enabled = false;
                        mnuMenu.Tools[FMenuKey.MenuInqEapInterfaceBackupLogList].SharedProps.Enabled = false;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuMonEapReferenceSheet].SharedProps.Enabled = false;
                    }
                    else if (operMode == FEapOperationMode.Client.ToString())
                    {
                        mnuMenu.Tools[FMenuKey.MenuMonEapStart].SharedProps.Enabled = false;
                    }
                    else if (eapType == FEapType.FILE.ToString())
                    {
                        mnuMenu.Tools[FMenuKey.MenuInqEapInterfaceLogList].SharedProps.Visible = false;
                        mnuMenu.Tools[FMenuKey.MenuInqEapInterfaceBackupLogList].SharedProps.Visible = false;
                        mnuMenu.Tools[FMenuKey.MenuMonEapRepositoryStatus].SharedProps.Visible = false;
                        mnuMenu.Tools[FMenuKey.MenuMonEapReferenceSheet].SharedProps.Visible = false;
                        mnuMenu.Tools[FMenuKey.MenuMonEapModelDownload].SharedProps.Visible = false;
                    }
                    else if (
                             eapType == FEapType.OPC.ToString() ||
                             eapType == FEapType.SECS.ToString() ||
                             eapType == FEapType.TCP.ToString()
                            )
                    {
                        mnuMenu.Tools[FMenuKey.MenuInqEapInterfaceLogList].SharedProps.Visible = false;
                        mnuMenu.Tools[FMenuKey.MenuInqEapInterfaceBackupLogList].SharedProps.Visible = false;
                        mnuMenu.Tools[FMenuKey.MenuMonEapRepositoryStatus].SharedProps.Visible = true;
                        mnuMenu.Tools[FMenuKey.MenuMonEapReferenceSheet].SharedProps.Visible = true;
                        mnuMenu.Tools[FMenuKey.MenuMonEapModelDownload].SharedProps.Visible = true;
                    }
                }

                #endregion

                // --

                mnuMenu.ShowPopup(FMenuKey.MenuMonEapPopupMenu);
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

        private void grdEap_KeyDown(
            object sender, 
            KeyEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Control && e.KeyCode == Keys.A)
                {
                    grdEap.Selected.Rows.AddRange((UltraGridRow[])grdEap.Rows.All);
                }
                else if (e.Control && e.KeyCode == Keys.B)
                {
                    if (grdEap.ActiveRow != null)
                    {
                        procMenuEapBackupLogList();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.L)
                {
                    if (grdEap.ActiveRow != null)
                    {
                        procMenuEapLogList();
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
        
        //------------------------------------------------------------------------------------------------------------------------

        private void grdEap_DoubleClickRow(
            object sender, 
            DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (
                    grdEap.ActiveRow == null ||
                    !FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapLogList)
                    )
                {
                    return;
                }
                else
                {
                    procMenuEapLogList();
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
                mnuMenu.Tools[FMenuKey.MenuMonRemotePingTestByEquipment].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.RemotePingTestByEquipment) ? true : false;

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

                refreshGridOfEap();
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

                if (tabMain.ActiveTab.Key == "Server")
                {
                    refreshClassGridOfServer();
                }
                else if (tabMain.ActiveTab.Key == "Package")
                {
                    refreshClassGridOfPackage();
                }
                else if (tabMain.ActiveTab.Key == "Model")
                {
                    refreshClassGridOfModel();
                }
                else if (tabMain.ActiveTab.Key == "Component")
                {
                    refreshClassGridOfComponent();
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
        
        #region rstEapToolbar Control Event Handler
        
        private void rstEapToolbar_RefreshRequested(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfEap();

                // --

                grdEap.Focus();
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
        
        private void rstEapToolbar_SearchRequested(
            object sender, 
            FSearchRequestedEventArgs e
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            UltraGridRow row = null;
            UltraGridCell cell = null;
            string rpmCnt = string.Empty;
            string server = string.Empty;
            string pkg = string.Empty;
            string pkgVer = string.Empty;
            string mdl = string.Empty;
            string mdlVer = string.Empty;
            string com = string.Empty;
            string comVer = string.Empty;
            object[] cellValues = null;
            string beforeKey = string.Empty;
            string key = string.Empty;
            int nextRowNumber = 0;
            int index = 0;
            string eapType = string.Empty;
            string eapUpDown = string.Empty;
            string eapStatus = string.Empty;
            string eapAlarm = string.Empty;
            string set_Package = string.Empty;
            string rel_Package = string.Empty;
            string apl_Package = string.Empty;
            string set_Model = string.Empty;
            string rel_Model = string.Empty;
            string apl_Model = string.Empty;
            string set_Component = string.Empty;
            string rel_Component = string.Empty;
            string apl_Component = string.Empty;

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

                beforeKey = grdEap.activeDataRowKey;
                // --
                grdEap.beginUpdate(false);
                grdEap.removeAllDataRow();
                grdEap.DisplayLayout.Bands[0].SortedColumns.Clear();                

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("search_word", e.searchWord);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Tool", "EapMonitor", "SearchEap", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        eapType = r[2].ToString();
                        eapUpDown = r[6].ToString();
                        eapStatus = r[7].ToString();
                        eapAlarm = r[9].ToString();

                        // --

                        set_Package = FCommon.generateStringForPackage(r[12].ToString(), r[13].ToString());
                        rel_Package = FCommon.generateStringForPackage(r[14].ToString(), r[15].ToString());
                        apl_Package = FCommon.generateStringForPackage(r[16].ToString(), r[17].ToString());
                        set_Model = FCommon.generateStringForModel(r[18].ToString(), r[19].ToString());
                        rel_Model = FCommon.generateStringForModel(r[20].ToString(), r[21].ToString());
                        apl_Model = FCommon.generateStringForModel(r[22].ToString(), r[23].ToString());
                        set_Component = FCommon.generateStringForComponent(r[24].ToString(), r[25].ToString(), r[26].ToString());
                        rel_Component = FCommon.generateStringForComponent(r[27].ToString(), r[28].ToString(), r[29].ToString());
                        apl_Component = FCommon.generateStringForComponent(r[30].ToString(), r[31].ToString(), r[32].ToString());
                        // --
                        rpmCnt = r[33].ToString();

                        // --

                        cellValues = new object[] {
                            r[0].ToString(),   // Eap
                            r[1].ToString(),   // Description    
                            rpmCnt,            // RPM Count (2017.06.07 by spike.lee add)
                            eapType,           // Type
                            r[3].ToString(),   // Oper Mode
                            r[4].ToString(),   // Server
                            r[5].ToString(),   // Step
                            eapUpDown,         // Up/Down
                            eapStatus,         // Status
                            r[8].ToString(),   // Reload Count
                            r[10].ToString(),  // Need Action
                            r[11].ToString(),  // Next Need Action
                            set_Package,       // (Set) Package
                            rel_Package,       // (Rel) Package
                            apl_Package,       // (Apl) Package
                            set_Model,         // (Set) Model
                            rel_Model,         // (Rel) Model
                            apl_Model,         // (Apl) Model
                            set_Component,     // (Set) Component
                            rel_Component,     // (Rel) Component
                            apl_Component      // (Apl) Component
                            };
                        key = (string)cellValues[0];
                        index = grdEap.appendDataRow(key, cellValues).Index;

                        // --

                        row = grdEap.Rows.GetRowWithListIndex(index);

                        // --

                        cell = row.Cells["EAP"];
                        cell.Appearance.Image = FCommon.getImageOfEap(grdEap, eapType, eapUpDown, eapStatus, eapAlarm);

                        // --

                        if (eapUpDown == FUpDown.Down.ToString())
                        {
                            row.Appearance.BackColor = Color.FromArgb(233, 233, 233);
                        }
                        else if (eapAlarm == FYesNo.Yes.ToString())
                        {
                            row.Appearance.BackColor = Color.FromArgb(255, 221, 211);
                        }
                        else
                        {
                            row.Appearance.BackColor = Color.WhiteSmoke;
                        }

                        // --

                        if (rpmCnt != "0")
                        {
                            cell = row.Cells["RPM Count"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        }

                        // --

                        cell = row.Cells["Step"];
                        if (cell.Text != FEapAttrCategory.Applied.ToString())
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
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

                        cell = row.Cells["Status"];
                        if (cell.Text == "Backup")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }

                        // --

                        cell = row.Cells["Need Action"];
                        if (cell.Text.Trim() != "")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                        }

                        // --

                        cell = row.Cells["Next Need Action"];
                        if (cell.Text.Trim() != "")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                        }

                        // --

                        if (!FCommon.stringEquals(set_Package, rel_Package, apl_Package))
                        {
                            cell = row.Cells["(Set) Package"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                            cell = row.Cells["(Rel) Package"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                            cell = row.Cells["(Apl) Package"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                        }
                        // --
                        cell = row.Cells["(Set) Package"];
                        if (cell.Text == "N/A")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }
                        // --
                        cell = row.Cells["(Rel) Package"];
                        if (cell.Text == "N/A")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }
                        // --
                        cell = row.Cells["(Apl) Package"];
                        if (cell.Text == "N/A")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }

                        // --

                        if (!FCommon.stringEquals(set_Model, rel_Model, apl_Model))
                        {
                            cell = row.Cells["(Set) Model"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                            cell = row.Cells["(Rel) Model"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                            cell = row.Cells["(Apl) Model"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                        }
                        // --
                        cell = row.Cells["(Set) Model"];
                        cell.Tag = r[16].ToString();
                        if (cell.Text == "N/A")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }
                        // --
                        cell = row.Cells["(Rel) Model"];
                        cell.Tag = r[18].ToString();
                        if (cell.Text == "N/A")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }
                        // --
                        cell = row.Cells["(Apl) Model"];
                        cell.Tag = r[20].ToString();
                        if (cell.Text == "N/A")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }

                        // --

                        if (!FCommon.stringEquals(set_Component, rel_Component, apl_Component))
                        {
                            cell = row.Cells["(Set) Component"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                            cell = row.Cells["(Rel) Component"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                            cell = row.Cells["(Apl) Component"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                        }
                        // --
                        cell = row.Cells["(Set) Component"];
                        if (cell.Text == "N/A")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }
                        // --
                        cell = row.Cells["(Rel) Component"];
                        if (cell.Text == "N/A")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }
                        // --
                        cell = row.Cells["(Apl) Component"];
                        if (cell.Text == "N/A")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }
                    }
                } while (nextRowNumber >= 0);

                // --

                grdEap.endUpdate(false);
                grdEap.DisplayLayout.Bands[0].SortedColumns.Add("EAP", false);

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

                m_isSearchMode = true;
            }
            catch (Exception ex)
            {
                grdEap.endUpdate(false);
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
                row = null;
                cell = null;

                // --

                refreshEapTotal();

                // --

                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fAdmCore Object Event Handler

        private void m_fAdmCore_MonitoringServerDataReceived(
            object sender, 
            FMonitoringServerDataReceivedEventArgs e
            )
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        procMonitoringServerData(e);
                    }));
                }
                else
                {
                    procMonitoringServerData(e);
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

        private void m_fAdmCore_MonitoringPackageDataReceived(
            object sender, 
            FMonitoringPackageDataReceivedEventArgs e
            )
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        procMonitoringPackageData(e);
                    }));
                }
                else
                {
                    procMonitoringPackageData(e);
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

        private void m_fAdmCore_MonitoringPackageVerDataReceived(
            object sender, 
            FMonitoringPackageVerDataReceivedEventArgs e
            )
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        procMonitoringPackageVerData(e);
                    }));
                }
                else
                {
                    procMonitoringPackageVerData(e);
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

        private void m_fAdmCore_MonitoringModelDataReceived(
            object sender, 
            FMonitoringModelDataReceivedEventArgs e
            )
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        procMonitoringModelData(e);
                    }));
                }
                else
                {
                    procMonitoringModelData(e);
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

        private void m_fAdmCore_MonitoringModelVerDataReceived(
            object sender, 
            FMonitoringModelVerDataReceivedEventArgs e
            )
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        procMonitoringModelVerData(e);
                    }));
                }
                else
                {
                    procMonitoringModelVerData(e);
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

        private void m_fAdmCore_MonitoringComponentDataReceived(
            object sender, 
            FMonitoringComponentDataReceivedEventArgs e
            )
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        procMonitoringComponentData(e);
                    }));
                }
                else
                {
                    procMonitoringComponentData(e);
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

        private void m_fAdmCore_MonitoringComponentVerDataReceived(
            object sender,
            FMonitoringComponentVerDataReceivedEventArgs e
            )
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        procMonitoringComponentVerData(e);
                    }));
                }
                else
                {
                    procMonitoringComponentVerData(e);
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
                        procMonitoringEapData(e);
                    }));
                }
                else
                {
                    procMonitoringEapData(e);
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

        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
