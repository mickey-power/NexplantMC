/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FsystemCheckList.cs
--  Creator         : shim
--  Create Date     : 2013.04.29
--  Description     : FAMate Admin Manager System Check List Form Class 
--  History         : Created by shim at 2013.04.29
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
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinEditors;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager
{
    public partial class FSystemCheckList : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private FThread m_thdAutoRefresh = null;
        private FStaticTimer m_autoRefreshTimer = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSystemCheckList(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSystemCheckList(
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
                try
                {
                    return grdEqp.activeDataRowKey;
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

        private string activeStep
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

                    return (string)grdEqp.activeDataRow["Step"];
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
        
        private void designGridOfServer(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdServer.dataSource;
                // --
                uds.Band.Columns.Add("Server");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Server Type");
                uds.Band.Columns.Add("Server IP");
                uds.Band.Columns.Add("Up/Down");
                uds.Band.Columns.Add("Status");
                uds.Band.Columns.Add("Agent");
                uds.Band.Columns.Add("Used Backup");
                uds.Band.Columns.Add("Backup Mode");
                uds.Band.Columns.Add("Backup Server");
                uds.Band.Columns.Add("B.Server Up/Down");
                uds.Band.Columns.Add("B.Server Status");                
                uds.Band.Columns.Add("B.Server Agent");
                uds.Band.Columns.Add("OPC Server Monitoring");
                uds.Band.Columns.Add("OPC Server");
                uds.Band.Columns.Add("Last Event Time");
                uds.Band.Columns.Add("Last Event ID");
                uds.Band.Columns.Add("Create User ID");
                uds.Band.Columns.Add("Create Time");
                uds.Band.Columns.Add("Update User ID");
                uds.Band.Columns.Add("Update Time");

                // --

                grdServer.DisplayLayout.Bands[0].Columns["Last Event Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdServer.DisplayLayout.Bands[0].Columns["Create Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdServer.DisplayLayout.Bands[0].Columns["Update Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

                // --

                grdServer.DisplayLayout.Bands[0].Columns["Server"].Header.Fixed = true;

                // --

                grdServer.DisplayLayout.Bands[0].Columns["Server"].Width = 100;
                grdServer.DisplayLayout.Bands[0].Columns["Description"].Width = 180;
                grdServer.DisplayLayout.Bands[0].Columns["Server Type"].Width = 90;
                grdServer.DisplayLayout.Bands[0].Columns["Server IP"].Width = 110;
                grdServer.DisplayLayout.Bands[0].Columns["Up/Down"].Width = 60;
                grdServer.DisplayLayout.Bands[0].Columns["Status"].Width = 60;
                grdServer.DisplayLayout.Bands[0].Columns["Agent"].Width = 60;
                grdServer.DisplayLayout.Bands[0].Columns["Used Backup"].Width = 90;
                grdServer.DisplayLayout.Bands[0].Columns["Backup Mode"].Width = 70;
                grdServer.DisplayLayout.Bands[0].Columns["Backup Server"].Width = 100;
                grdServer.DisplayLayout.Bands[0].Columns["B.Server Up/Down"].Width = 100;
                grdServer.DisplayLayout.Bands[0].Columns["B.Server Status"].Width = 100;                
                grdServer.DisplayLayout.Bands[0].Columns["B.Server Agent"].Width = 100;
                grdServer.DisplayLayout.Bands[0].Columns["OPC Server Monitoring"].Width = 90;
                grdServer.DisplayLayout.Bands[0].Columns["OPC Server"].Width = 100;
                grdServer.DisplayLayout.Bands[0].Columns["Last Event Time"].Width = 165;
                grdServer.DisplayLayout.Bands[0].Columns["Last Event ID"].Width = 100;
                grdServer.DisplayLayout.Bands[0].Columns["Create User ID"].Width = 100;
                grdServer.DisplayLayout.Bands[0].Columns["Create Time"].Width = 165;
                grdServer.DisplayLayout.Bands[0].Columns["Update User ID"].Width = 100;
                grdServer.DisplayLayout.Bands[0].Columns["Update Time"].Width = 165;

                // --

                grdServer.ImageList = new ImageList();
                // --
                grdServer.ImageList.Images.Add("Server_Main_Up", Properties.Resources.Server_Main_Up);
                grdServer.ImageList.Images.Add("Server_Main_Alarm", Properties.Resources.Server_Main_Alarm);
                grdServer.ImageList.Images.Add("Server_Main_Down", Properties.Resources.Server_Main_Down);
                grdServer.ImageList.Images.Add("Server_Backup_Up", Properties.Resources.Server_Backup_Up);
                grdServer.ImageList.Images.Add("Server_Backup_Alarm", Properties.Resources.Server_Backup_Alarm);
                grdServer.ImageList.Images.Add("Server_Backup_Down", Properties.Resources.Server_Backup_Down);

                // --

                grdServer.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                grdServer.DisplayLayout.Override.FilterUIProvider = this.grdFilter;
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
                uds.Band.Columns.Add("Last Event ID");
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
                grdEap.DisplayLayout.Bands[0].Columns["Step"].Width = 80;
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
                grdEap.DisplayLayout.Bands[0].Columns["Need Action"].Width = 90;
                grdEap.DisplayLayout.Bands[0].Columns["Next Need Action"].Width = 90;
                grdEap.DisplayLayout.Bands[0].Columns["Last Event Time"].Width = 165;
                grdEap.DisplayLayout.Bands[0].Columns["Last Event ID"].Width = 100;
                grdEap.DisplayLayout.Bands[0].Columns["Create User ID"].Width = 100;
                grdEap.DisplayLayout.Bands[0].Columns["Create Time"].Width = 165;
                grdEap.DisplayLayout.Bands[0].Columns["Update User ID"].Width = 100;
                grdEap.DisplayLayout.Bands[0].Columns["Update Time"].Width = 165;

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
                uds.Band.Columns.Add("Equipment Type");
                uds.Band.Columns.Add("Equipment Area");
                uds.Band.Columns.Add("Equipment Line");
                uds.Band.Columns.Add("Control Mode");
                uds.Band.Columns.Add("Primary State"); ;
                uds.Band.Columns.Add("State");
                uds.Band.Columns.Add("Alarm");
                uds.Band.Columns.Add("MDLN");
                uds.Band.Columns.Add("Soft Rev.");
                uds.Band.Columns.Add("Event Define");
                uds.Band.Columns.Add("Server");
                uds.Band.Columns.Add("Step");
                uds.Band.Columns.Add("Up/Down");
                uds.Band.Columns.Add("Status");
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

                grdEqp.DisplayLayout.Bands[0].Columns["Create Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdEqp.DisplayLayout.Bands[0].Columns["Update Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdEqp.DisplayLayout.Bands[0].Columns["Last Event Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

                // --

                grdEqp.DisplayLayout.Bands[0].Columns["Equipment"].Header.Fixed = true;
                grdEqp.DisplayLayout.Bands[0].Columns["EAP"].Header.Fixed = true;
                grdEqp.DisplayLayout.Bands[0].Columns["Description"].Header.Fixed = true;

                // --

                grdEqp.DisplayLayout.Bands[0].Columns["Equipment"].Width = 100;
                grdEqp.DisplayLayout.Bands[0].Columns["Description"].Width = 165;
                grdEqp.DisplayLayout.Bands[0].Columns["EAP"].Width = 100;
                grdEqp.DisplayLayout.Bands[0].Columns["Equipment Type"].Width = 80;
                grdEqp.DisplayLayout.Bands[0].Columns["Equipment Area"].Width = 120;
                grdEqp.DisplayLayout.Bands[0].Columns["Equipment Line"].Width = 120;
                grdEqp.DisplayLayout.Bands[0].Columns["Control Mode"].Width = 90;
                grdEqp.DisplayLayout.Bands[0].Columns["Primary State"].Width = 90;
                grdEqp.DisplayLayout.Bands[0].Columns["State"].Width = 90;
                grdEqp.DisplayLayout.Bands[0].Columns["Alarm"].Width = 90;
                grdEqp.DisplayLayout.Bands[0].Columns["MDLN"].Width = 120;
                grdEqp.DisplayLayout.Bands[0].Columns["Soft Rev."].Width = 120;
                grdEqp.DisplayLayout.Bands[0].Columns["Server"].Width = 120;
                grdEqp.DisplayLayout.Bands[0].Columns["Step"].Width = 120;
                grdEqp.DisplayLayout.Bands[0].Columns["Up/Down"].Width = 80;
                grdEqp.DisplayLayout.Bands[0].Columns["Status"].Width = 80;
                grdEqp.DisplayLayout.Bands[0].Columns["Package"].Width = 180;
                grdEqp.DisplayLayout.Bands[0].Columns["Model"].Width = 180;
                grdEqp.DisplayLayout.Bands[0].Columns["Component"].Width = 180;
                grdEqp.DisplayLayout.Bands[0].Columns["Need Action"].Width = 100;
                grdEqp.DisplayLayout.Bands[0].Columns["Next Need Action"].Width = 100;
                grdEqp.DisplayLayout.Bands[0].Columns["Last Event Time"].Width = 165;
                grdEqp.DisplayLayout.Bands[0].Columns["Last Event ID"].Width = 100;
                grdEqp.DisplayLayout.Bands[0].Columns["Create User ID"].Width = 100;
                grdEqp.DisplayLayout.Bands[0].Columns["Create Time"].Width = 165;
                grdEqp.DisplayLayout.Bands[0].Columns["Update User ID"].Width = 100;
                grdEqp.DisplayLayout.Bands[0].Columns["Update Time"].Width = 165;

                // --

                grdEqp.ImageList = new ImageList();
                // --
                grdEqp.ImageList.Images.Add("Equipment_Offline", Properties.Resources.Equipment_Offline);
                grdEqp.ImageList.Images.Add("Equipment_OnlineLocal", Properties.Resources.Equipment_OnlineLocal);
                grdEqp.ImageList.Images.Add("Equipment_OnlineRemote", Properties.Resources.Equipment_OnlineRemote);
                grdEqp.ImageList.Images.Add("Equipment_Unknown", Properties.Resources.Equipment_Unknown);

                // --

                grdEqp.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                grdEqp.DisplayLayout.Override.FilterUIProvider = this.grdFilter;
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

        private void controlMenu(
            )
        {
            try
            {
                mnuMenu.beginUpdate();

                // --

                if (
                    grdServer.Rows.Count == 0 &&
                    grdEap.Rows.Count == 0 &&
                    grdEqp.Rows.Count == 0
                    )
                {
                    mnuMenu.Tools[FMenuKey.MenuSclExport].SharedProps.Enabled = false;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuSclExport].SharedProps.Enabled = true;
                }
                
                // --

                mnuMenu.endUpdate();
            }
            catch (Exception ex)
            {
                mnuMenu.endUpdate();
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
                refreshGridOfServer();
                refreshGridOfEap();
                refreshGridOfEquipment();

                // --

                controlMenu();

                // --

                if (tabMain.ActiveTab.Key == "Server")
                {
                    grdServer.Focus();
                }
                else if (tabMain.ActiveTab.Key == "Eap")
                {
                    grdEap.Focus();
                }
                else if (tabMain.ActiveTab.Key == "Eqp")
                {
                    grdEqp.Focus();
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

        private void refreshGridOfServer(
             )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            UltraGridRow row = null;
            UltraGridCell cell = null;
            object[] cellValues = null;
            string key = string.Empty;
            string beforeKey = string.Empty;
            int nextRowNumber = 0;
            int index = 0;
            string svrUpDown = string.Empty;
            string svrStatus = string.Empty;
            string lastEventTime = string.Empty;
            string createTime = string.Empty;
            string updateTime = string.Empty;

            try
            {
                beforeKey = grdServer.activeDataRowKey;
                // --
                grdServer.beginUpdate(false);
                grdServer.removeAllDataRow();
                grdServer.DisplayLayout.Bands[0].SortedColumns.Clear();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "SystemCheckList", "ListServer", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        svrUpDown = r[4].ToString();
                        svrStatus = r[5].ToString();
                        lastEventTime = FDataConvert.defaultDataTimeFormating(r[15].ToString());
                        createTime = FDataConvert.defaultDataTimeFormating(r[18].ToString());
                        updateTime = FDataConvert.defaultDataTimeFormating(r[20].ToString());

                        // --                        

                        cellValues = new object[] {
                            r[0].ToString(),    // Server
                            r[1].ToString(),    // Description
                            r[2].ToString(),    // Server Type
                            r[3].ToString(),    // Server IP
                            svrUpDown,          // Up/Down
                            svrStatus,          // Status
                            r[6].ToString(),    // Agent
                            r[7].ToString(),    // Used Backup 
                            r[8].ToString(),    // Backup Mode
                            r[9].ToString(),    // Backup Server
                            r[10].ToString(),   // B.Server Up/Down
                            r[11].ToString(),   // B.Server Status  
                            r[12].ToString(),   // B.Server Agent
                            r[13].ToString(),   // OPC Server Monitoring
                            r[14].ToString(),   // OPC Server (Up/Down) 
                            lastEventTime,      // Last Event Time
                            r[16].ToString(),   // Last Event ID
                            r[17].ToString(),   // Create User ID
                            createTime,         // Create Time
                            r[19].ToString(),   // Update User ID
                            updateTime          // Update Time
                            };
                        key = (string)cellValues[0];
                        index = grdServer.appendDataRow(key, cellValues).Index;

                        // --

                        row = grdServer.Rows.GetRowWithListIndex(index);

                        // --

                        cell = row.Cells["Server"];
                        cell.Appearance.Image = FCommon.getImageOfServer(grdServer, svrUpDown, svrStatus, "Yes");

                        // --

                        FCommon.designGridCellForEapUpDown(row.Cells["Up/Down"]);
                        cell = row.Cells["Up/Down"];
                        if (cell.Text == FUpDown.Down.ToString())
                        {
                            cell = row.Cells["Server"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }
                       
                        // --

                        FCommon.designGridCellForEapUpDown(row.Cells["Agent"]);
                        
                        // --
                        
                        cell = row.Cells["Used Backup"];
                        if (cell.Text == FYesNo.Yes.ToString())
                        {
                            FCommon.designGridCellForEapUpDown(row.Cells["B.Server Up/Down"]);
                            if (cell.Text == FUpDown.Down.ToString())
                            {
                                cell = row.Cells["Backup Server"];
                                cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                                cell.Appearance.ForeColor = Color.Red;
                            }
                            
                            // --

                            FCommon.designGridCellForEapUpDown(row.Cells["B.Server Agent"]);
                        }

                        // --

                        FCommon.designGridCellForEapUpDown(row.Cells["OPC Server"]);
                    }
                } while (nextRowNumber >= 0);

                // --

                grdServer.endUpdate(false);

                // --

                if (grdServer.Rows.Count != 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdServer.activateDataRow(beforeKey);
                    }
                    if (grdServer.activeDataRow == null)
                    {
                        grdServer.ActiveRow = grdServer.Rows[0];
                    }
                }

                // --

                refreshServerTotal();                
            }
            catch (Exception ex)
            {
                grdServer.endUpdate(false);
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

        private void refreshGridOfEap(
             )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            UltraGridRow row = null;
            UltraGridCell cell = null;
            object[] cellValues = null;
            string key = string.Empty;
            string beforeKey = string.Empty;
            int nextRowNumber = 0;
            int index = 0;
            int tempIndex = 0;
            string eap = string.Empty;
            string eapDesc = string.Empty;
            string server = string.Empty;
            string step = string.Empty;
            string eapUpDown = string.Empty;
            string eapStatus = string.Empty;
            string reloadCount = string.Empty;
            string set_Package = string.Empty;
            string rel_Package = string.Empty;
            string apl_Package = string.Empty;
            string set_Model = string.Empty;
            string rel_Model = string.Empty;
            string apl_Model = string.Empty;
            string set_Component = string.Empty;
            string rel_Component = string.Empty;
            string apl_Component = string.Empty;
            string needAction = string.Empty;
            string nextNeedAtion = string.Empty;
            string lastEventTime = string.Empty;
            string lastEventID = string.Empty;
            string createUserID = string.Empty;
            string createTime = string.Empty;
            string updateUserID = string.Empty;
            string updateTime = string.Empty;
            string eapType = string.Empty;
            string operMode = string.Empty;
            string rpmCnt = string.Empty;

            try
            {
                beforeKey = this.activeEap;
                // --
                grdEap.beginUpdate(false);
                grdEap.removeAllDataRow();
                grdEap.DisplayLayout.Bands[0].SortedColumns.Clear();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "SystemCheckList", "ListEap", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        eap = r[tempIndex++].ToString();
                        eapDesc = r[tempIndex++].ToString();
                        eapType = r[tempIndex++].ToString();
                        operMode = r[tempIndex++].ToString();
                        server = r[tempIndex++].ToString();
                        step = r[tempIndex++].ToString();
                        eapUpDown = r[tempIndex++].ToString();
                        eapStatus = r[tempIndex++].ToString();
                        reloadCount = r[tempIndex++].ToString();

                        // --

                        set_Package = FCommon.generateStringForPackage(r[tempIndex++].ToString(), r[tempIndex++].ToString());
                        rel_Package = FCommon.generateStringForPackage(r[tempIndex++].ToString(), r[tempIndex++].ToString());
                        apl_Package = FCommon.generateStringForPackage(r[tempIndex++].ToString(), r[tempIndex++].ToString());
                        set_Model = FCommon.generateStringForModel(r[tempIndex++].ToString(), r[tempIndex++].ToString());
                        rel_Model = FCommon.generateStringForModel(r[tempIndex++].ToString(), r[tempIndex++].ToString());
                        apl_Model = FCommon.generateStringForModel(r[tempIndex++].ToString(), r[tempIndex++].ToString());
                        set_Component = FCommon.generateStringForComponent(r[tempIndex++].ToString(), r[tempIndex++].ToString(), r[tempIndex++].ToString());
                        rel_Component = FCommon.generateStringForComponent(r[tempIndex++].ToString(), r[tempIndex++].ToString(), r[tempIndex++].ToString());
                        apl_Component = FCommon.generateStringForComponent(r[tempIndex++].ToString(), r[tempIndex++].ToString(), r[tempIndex++].ToString());          

                        // --

                        needAction = r[tempIndex++].ToString();
                        nextNeedAtion = r[tempIndex++].ToString();

                        // --

                        lastEventTime = FDataConvert.defaultDataTimeFormating(r[tempIndex++].ToString());
                        lastEventID = r[tempIndex++].ToString();
                        createUserID = r[tempIndex++].ToString();
                        createTime = FDataConvert.defaultDataTimeFormating(r[tempIndex++].ToString());
                        updateUserID = r[tempIndex++].ToString();
                        updateTime = FDataConvert.defaultDataTimeFormating(r[tempIndex++].ToString());
                        // --
                        rpmCnt = r[tempIndex++].ToString();

                        // --

                        cellValues = new object[] {
                            eap,           // EAP
                            eapDesc,       // Description
                            rpmCnt,        // RPM Count (2017.06.07 by spike.lee add)
                            eapType,       // EAP Type
                            operMode,      // Operation Mode
                            server,        // Server
                            step,          // Step
                            eapUpDown,     // Up/Down
                            eapStatus,     // Status
                            reloadCount,   // Reload Count
                            set_Package,   // (Set) Package
                            rel_Package,   // (Rel) Package
                            apl_Package,   // (Apl) Package
                            set_Model,     // (Set) Model
                            rel_Model,     // (Rel) Model
                            apl_Model,     // (Apl) Model
                            set_Component, // (Set) Component
                            rel_Component, // (Rel) Component
                            apl_Component, // (Apl) Component
                            needAction,    // Need Action
                            nextNeedAtion, // Next Need Action
                            lastEventTime, // Last Event Time
                            lastEventID,   // Last Event ID
                            createUserID,  // Create User ID
                            createTime,    // Create Time
                            updateUserID,  // Update User ID
                            updateTime     // Update Time
                            };
                        key = (string)cellValues[0];
                        index = grdEap.appendDataRow(key, cellValues).Index;
                        
                        // --

                        row = grdEap.Rows.GetRowWithListIndex(index);
                        
                        // --

                        cell = row.Cells["EAP"];
                        cell.Appearance.Image = FCommon.getImageOfEap(grdEap, eapType, eapUpDown, eapStatus, "Yes");
                        if (row.Cells["Up/Down"].Text == FUpDown.Down.ToString())
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
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

                        FCommon.designGridCellForEapStep(row.Cells["Step"]);
                        FCommon.designGridCellForEapNeedAction(row.Cells["Need Action"]);
                        FCommon.designGridCellForEapNextNeedAction(row.Cells["Next Need Action"]);
                        FCommon.designGridCellForEapUpDown(row.Cells["Up/Down"]);
                        FCommon.designGridCellForEapStatus(row.Cells["Status"]);
                        FCommon.designGridCellForEapPackage(row.Cells["(Set) Package"]);
                        FCommon.designGridCellForEapPackage(row.Cells["(Rel) Package"]);
                        FCommon.designGridCellForEapPackage(row.Cells["(Apl) Package"]);
                        FCommon.designGridCellForEapModel(row.Cells["(Set) Model"]);
                        FCommon.designGridCellForEapModel(row.Cells["(Rel) Model"]);
                        FCommon.designGridCellForEapModel(row.Cells["(Apl) Model"]);
                        FCommon.designGridCellForEapComponent(row.Cells["(Set) Component"]);
                        FCommon.designGridCellForEapComponent(row.Cells["(Rel) Component"]);
                        FCommon.designGridCellForEapComponent(row.Cells["(Apl) Component"]);

                        // --

                        tempIndex = 0;
                    }
                } while (nextRowNumber >= 0);

                // --

                grdEap.endUpdate(false);

                // --

                if (grdEap.Rows.Count != 0)
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

        private void refreshGridOfEquipment(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            UltraGridRow row = null;
            UltraGridCell cell = null;
            object[] cellValues = null;
            // --
            string eqpName = string.Empty;
            string eqpDesc = string.Empty;
            string type = string.Empty;
            string area = string.Empty;
            string line = string.Empty;
            string controlMode = string.Empty;
            string primaryState = string.Empty;
            string state = string.Empty;
            string alarm = string.Empty;
            string eap = string.Empty;
            string eqMdln = string.Empty;
            string eqSoftRev = string.Empty;
            string eqEventDefine = string.Empty;
            string server = string.Empty;
            string step = string.Empty;
            string eapUpDown = string.Empty;
            string eapStatus = string.Empty;
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
            string key = string.Empty;
            string beforeKey = string.Empty;
            int nextRowNumber = 0;
            int index = 0;
            int tempIndex = 0;

            try
            {
                // ***
                // Equipment Clear
                // ***

                beforeKey = grdEqp.activeDataRowKey;
                // --
                grdEqp.beginUpdate(false);
                grdEqp.removeAllDataRow();
                grdEqp.DisplayLayout.Bands[0].SortedColumns.Clear();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "SystemCheckList", "ListEquipment", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        eqpName = r[tempIndex++].ToString();
                        eqpDesc = r[tempIndex++].ToString();
                        type = r[tempIndex++].ToString();
                        area = r[tempIndex++].ToString();
                        line = r[tempIndex++].ToString();
                        controlMode = r[tempIndex++].ToString();
                        primaryState = r[tempIndex++].ToString();
                        state = r[tempIndex++].ToString();
                        alarm = r[tempIndex++].ToString();
                        eap = r[tempIndex++].ToString();
                        eqMdln = r[tempIndex++].ToString();    // EQ Model Num
                        eqSoftRev = r[tempIndex++].ToString(); // EQ SOFT Rev
                        eqEventDefine = r[tempIndex++].ToString();
                        server = r[tempIndex++].ToString();
                        step = r[tempIndex++].ToString();
                        eapUpDown = r[tempIndex++].ToString();
                        eapStatus = r[tempIndex++].ToString();
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
                        // --

                        cellValues = new object[] {
                        eqpName,                                                        // Equipment
                        eqpDesc,                                                        // Euipment Description
                        eap,                                                            // EAP
                        type,                                                           // Type
                        area,                                                           // Area
                        line,                                                           // Line
                        string.IsNullOrWhiteSpace(controlMode) ? "N/A" : controlMode,   // Control Mode
                        string.IsNullOrWhiteSpace(primaryState) ? "N/A" : primaryState, // Primary State
                        string.IsNullOrWhiteSpace(state) ? "N/A" : state,               // State
                        alarm,                                                          // Alarm
                        string.IsNullOrWhiteSpace(eqMdln) ? "N/A" : eqMdln,             // Equipment Model Number
                        string.IsNullOrWhiteSpace(eqSoftRev) ? "N/A" : eqSoftRev,       // Equipment Soft Version
                        string.IsNullOrEmpty(eqEventDefine) ? "N/A" : eqEventDefine,    // EVENT DEFINE
                        server,                                                         // Server
                        step,                                                           // Step
                        eapUpDown,                                                      // Up/Down
                        eapStatus,                                                      // Status
                        package,                                                        // Package
                        model,                                                          // Model
                        component,                                                      // Component
                        needAction,                                                     // Need Action
                        nextNeedAtion,                                                  // Next Need Action
                        lastEventTime,                                                  // Last Event Time
                        lastEventID,                                                    // Last Event ID
                        createUserID,                                                   // Create User ID
                        createTime,                                                     // Create Time
                        updateUserID,                                                   // Update User ID
                        updateTime                                                      // Update Time

                        };
                        key = (string)cellValues[0];
                        index = grdEqp.appendDataRow(key, cellValues).Index;
                        grdEqp.Rows[index].Tag = r;

                        // --

                        row = grdEqp.Rows.GetRowWithListIndex(index);

                        // --

                        cell = row.Cells["Equipment"];
                        cell.Appearance.Image = FCommon.getImageOfEquipment(grdEqp, controlMode);
                        if (controlMode == FEquipmentControlMode.Offline.ToString())
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }

                        // --

                        cell = row.Cells["EAP"];
                        if (row.Cells["Up/Down"].Text == FUpDown.Down.ToString())
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }

                        // --

                        FCommon.designGridCellForNotApplicable(row.Cells["Primary State"]);
                        FCommon.designGridCellForNotApplicable(row.Cells["State"]);
                        FCommon.designGridCellForNotApplicable(row.Cells["MDLN"]);
                        FCommon.designGridCellForNotApplicable(row.Cells["Soft Rev."]);
                        FCommon.designGridCellForNotApplicable(row.Cells["Event Define"]);
                        FCommon.designGridCellForEapStep(row.Cells["Step"]);
                        FCommon.designGridCellForEapNeedAction(row.Cells["Need Action"]);
                        FCommon.designGridCellForEapNextNeedAction(row.Cells["Next Need Action"]);
                        FCommon.designGridCellForEapUpDown(row.Cells["Up/Down"]);
                        FCommon.designGridCellForEapStatus(row.Cells["Status"]);
                        FCommon.designGridCellForEapPackage(row.Cells["Package"]);
                        FCommon.designGridCellForEapModel(row.Cells["Model"]);
                        FCommon.designGridCellForEapComponent(row.Cells["Component"]);

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
                grdEqp.endUpdate();
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

        private void refreshServerTotal(
            )
        {
            try
            {
                lblServerTotal.Text = grdServer.Rows.VisibleRowCount.ToString("#,##0") + " / " + grdServer.Rows.Count.ToString("#,##0");
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

        private void procMenuExport(
            )
        {

            try
            {
                if (tabMain.ActiveTab.Key == "Server")
                {
                    procMenuServerExport();
                }
                else if (tabMain.ActiveTab.Key == "Eap")
                {
                    procMenuEapExport();
                }
                else
                {
                    procMenuEquipmentExport();
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

        private void procMenuServerExport(
            )
        {
            SaveFileDialog sfd = null;
            string fileName = string.Empty;
            FExcelExporter2 fExcelExp = null;
            FExcelSheet fExcelSht = null;
            int rowIndex = 0;

            try
            {
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_ServerCheckList.xlsx";

                // --

                sfd = new SaveFileDialog();
                // --
                sfd.Title = "Export Server Check List to Excel";
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
                fExcelSht = fExcelExp.addExcelSheet("Server List");

                // --

                // ***
                // Title write
                // ***
                rowIndex = 0;
                fExcelSht.writeTitle(this.Text, rowIndex, 0);

                // --

                // ***
                // Server List Grid Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Server List") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                rowIndex = fExcelSht.writeGrid(grdServer, rowIndex, 0);
                // --
                rowIndex += 1;
                // --
                fExcelSht.writeText("Total Count: " + grdServer.Rows.Count.ToString(), rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);

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

        private void procMenuEapExport(
            )
        {
            SaveFileDialog sfd = null;
            string fileName = string.Empty;
            FExcelExporter2 fExcelExp = null;
            FExcelSheet fExcelSht = null;
            int rowIndex = 0;

            try
            {
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_McCheckList.xlsx";

                // --

                sfd = new SaveFileDialog();
                // --
                sfd.Title = "Export MC Check List to Excel";
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
                fExcelSht = fExcelExp.addExcelSheet("EAP List");

                // --

                // ***
                // Title write
                // ***
                rowIndex = 0;
                fExcelSht.writeTitle(this.Text, rowIndex, 0);

                // --

                // ***
                // Server List Grid Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("EAP List") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                rowIndex = fExcelSht.writeGrid(grdEap, rowIndex, 0);
                // --
                rowIndex += 1;
                // --
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

        private void procMenuEquipmentExport(
            )
        {
            SaveFileDialog sfd = null;
            string fileName = string.Empty;
            FExcelExporter2 fExcelExp = null;
            FExcelSheet fExcelSht = null;
            int rowIndex = 0;

            try
            {
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_EquipmentCheckList.xlsx";
               
                // --

                sfd = new SaveFileDialog();
                // --
                sfd.Title = "Export Equipment Check List to Excel";
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
                // Server List Grid Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Equipment List") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                rowIndex = fExcelSht.writeGrid(grdEqp, rowIndex, 0);
                // --
                rowIndex += 1;
                // --
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

        private void initAutoRefresh(
            )
        {
            try
            {
                m_thdAutoRefresh = new FThread("AutoRefreshThread");
                m_thdAutoRefresh.ThreadJobCalled += new FThreadJobCalledEventHandler(m_thdAutoRefresh_ThreadJobCalled);
                m_thdAutoRefresh.start();

                //--

                uneSec.Enabled = false;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //-----------------------------------------------------------------------------------------------------------------------

        private void termAutoRefresh(
            )
        {
            try
            {
                if (m_autoRefreshTimer != null)
                {
                    m_autoRefreshTimer.Dispose();
                    m_autoRefreshTimer = null;
                }

                if (m_thdAutoRefresh != null)
                {
                    m_thdAutoRefresh.stop();
                    m_thdAutoRefresh.Dispose();
                    m_thdAutoRefresh.ThreadJobCalled -= new FThreadJobCalledEventHandler(m_thdAutoRefresh_ThreadJobCalled);
                    m_thdAutoRefresh = null;
                }

                //--

                uneSec.Enabled = true;
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
                fServerStatus.attach(grdServer.activeDataRowKey);
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
                fServerHistory.attach(grdServer.activeDataRowKey);
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

        public void procMenuServerResourceStatus(
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
                fServerResourceStatus.attach(grdServer.activeDataRowKey);
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

        public void procMenuServerResourceHistory(
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
                fServerResourceHistory.attach(grdServer.activeDataRowKey);
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

        public void procMenuServerMainSwitch(
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
                fServerMainSwitch.attach(grdServer.activeDataRowKey);
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

        public void procMenuServerBackupSwitch(
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
                fServerBackupSwitch.attach(grdServer.activeDataRowKey);
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

        public void procMenuAdminAgentLogList(
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
                fAdminAgentLogList.attach(grdServer.activeDataRowKey);
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

        public void procMenuAdminAgentBackupLogList(
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
                fAdminAgentBackupLogList.attach(grdServer.activeDataRowKey);
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

        public void procMenuRemotePingTestByServer(
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
                fRemotePingTest.attach(grdServer.selectedDataRowKeys);
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

        #endregion

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

        private void procMenuEqStatus(
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
                fEquipmentStatus.attach(this.activeEq, this.activeStep);
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

        private void procMenuEqHistory(
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
                fEquipmentHistory.attach(grdEqp.ActiveRow.Cells["Equipment"].Text.Trim());
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
                fEquipmentGemStatus.attach(grdEqp.ActiveRow.Cells["Equipment"].Text.Trim());
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

                eqpList = new string[grdEqp.selectedDataRows.Length, 2];
                for (int i = 0; i < grdEqp.selectedDataRows.Length; i++)
                {
                    dr = grdEqp.selectedDataRows[i];
                    eqpList[i, 0] = dr["Equipment"].ToString();
                    eqpList[i, 1] = dr["EAP"].ToString();
                }

                // --

                fEqpEventDefineReq.attach(eqpList);
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

                eqpList = new string[grdEqp.selectedDataRows.Length, 2];
                for (int i = 0; i < grdEqp.selectedDataRows.Length; i++)
                {
                    dr = grdEqp.selectedDataRows[i];
                    eqpList[i, 0] = dr["Equipment"].ToString();
                    eqpList[i, 1] = dr["EAP"].ToString();
                }

                // --

                fEqpVerReq.attach(eqpList);
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

                eqpList = new string[grdEqp.selectedDataRows.Length, 2];
                for (int i = 0; i < grdEqp.selectedDataRows.Length; i++)
                {
                    dr = grdEqp.selectedDataRows[i];
                    eqpList[i, 0] = dr["Equipment"].ToString();
                    eqpList[i, 1] = dr["EAP"].ToString();
                }

                // --

                fEqpControlModeReq.attach(eqpList);
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

                eqpList = new string[grdEqp.selectedDataRows.Length, 2];
                for (int i = 0; i < grdEqp.selectedDataRows.Length; i++)
                {
                    dr = grdEqp.selectedDataRows[i];
                    eqpList[i, 0] = dr["Equipment"].ToString();
                    eqpList[i, 1] = dr["EAP"].ToString();
                }

                // --

                fCustomRemoteCommandReq.attach(eqpList);
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

        public void procMenuRemotePingTestByEquipment(
            )
        {
            FRemotePingTestByEquipment fRemotePingTest = null;
            List<FStructureEquipment> equipmentList = null;

            try
            {
                equipmentList = new List<FStructureEquipment>();
                // --
                foreach (UltraDataRow r in grdEqp.selectedDataRows)
                {
                    equipmentList.Add(new FStructureEquipment(
                        ((DataRow)grdEqp.Rows[r.Index].Tag)[0].ToString(), // Equipment
                        ((DataRow)grdEqp.Rows[r.Index].Tag)[2].ToString(), // Eap
                        ((DataRow)grdEqp.Rows[r.Index].Tag)[1].ToString(), // Description
                        ((DataRow)grdEqp.Rows[r.Index].Tag)[32].ToString() // Plc Address
                        ));
                }

                // --

                fRemotePingTest = (FRemotePingTestByEquipment)m_fAdmCore.fAdmContainer.getChild(typeof(FRemotePingTestByEquipment));
                if (fRemotePingTest == null)
                {
                    fRemotePingTest = new FRemotePingTestByEquipment(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fRemotePingTest);
                }
                fRemotePingTest.activate();
                fRemotePingTest.attach(equipmentList);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fRemotePingTest = null;
                equipmentList = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        public void attachServer(
            string serverName
            )
        {
            try
            {
                refresh();

                // --

                tabMain.Tabs["Server"].Active = true;
                tabMain.SelectedTab = tabMain.ActiveTab;
                // --
                if (grdServer.containsDataRow(serverName))
                {
                    grdServer.activateDataRow(serverName);
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

        public void attachEap(
            string eapName
            )
        {
            try
            {
                refresh();   

                // --

                tabMain.ActiveTab = tabMain.Tabs["Eap"];
                tabMain.SelectedTab = tabMain.ActiveTab;                
                // --
                if (grdEap.containsDataRow(eapName))
                {
                    grdEap.activateDataRow(eapName);
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

        #region FSystemCheckList Form Event Handler

        private void FSystemCheckList_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --
         
                designGridOfServer();
                designGridOfEap();
                designGridOfEquipment();

                // --

                uneSec.Value = 5;

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

        private void FSystemCheckList_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refresh();

                // --

                grdServer.Focus();
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

        private void FSystemCheckList_FormClosing(
            object sender,
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                termAutoRefresh();
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

        private void FSystemCheckList_KeyDown(
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

                if (e.Tool.Key == FMenuKey.MenuSclRefresh)
                {
                    refresh();
                }
                else if (e.Tool.Key == FMenuKey.MenuSclExport)
                {
                    procMenuExport();
                }
                else if (e.Tool.Key == FMenuKey.MenuSclAutoRefresh)
                {
                    if (((StateButtonTool)e.Tool).Checked)
                    {
                        initAutoRefresh();
                    }
                    else
                    {
                        termAutoRefresh();
                    }
                }

                // --

                else if (e.Tool.Key == FMenuKey.MenuInqSvrStatus)
                {
                    procMenuServerStatus();
                }
                else if (e.Tool.Key == FMenuKey.MenuInqSvrHistory)
                {
                    procMenuServerHistory();
                }
                else if (e.Tool.Key == FMenuKey.MenuInqSvrResourceStatus)
                {
                    procMenuServerResourceStatus();
                }
                else if (e.Tool.Key == FMenuKey.MenuInqSvrResourceHistory)
                {
                    procMenuServerResourceHistory();
                }
                else if (e.Tool.Key == FMenuKey.MenuInqSvrMainSwitch)
                {
                    procMenuServerMainSwitch();
                }
                else if (e.Tool.Key == FMenuKey.MenuInqSvrBackupSwitch)
                {
                    procMenuServerBackupSwitch();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuInqSvrAdminAgentLogList)
                {
                    procMenuAdminAgentLogList();
                }
                else if (e.Tool.Key == FMenuKey.MenuInqSvrAdminAgentBackupLogList)
                {
                    procMenuAdminAgentBackupLogList();
                }
                else if (e.Tool.Key == FMenuKey.MenuInqSvrRemotePingTest)
                {
                    procMenuRemotePingTestByServer();
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
                    procMenuEqStatus();
                }
                else if (e.Tool.Key == FMenuKey.MenuInqEqpHistory)
                {
                    procMenuEqHistory();
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

        #region tabMain Control Event Handler

        private void tabMain_SelectedTabChanged(
            object sender,
            Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e
            )
        {
            try
            {
                controlMenu();
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

        #region grdServer Control Event Handler

        private void grdServer_MouseDown(
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

                if (e.Button != MouseButtons.Right || grdServer.Rows.Count == 0)
                {
                    return;
                }

                // --

                r = (UltraGridRow)grdServer.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y)).
                    GetContext(typeof(UltraGridRow));
                if (r != null)
                {
                    grdServer.ActiveRow = grdServer.Rows[r.Index];
                }

                // --

                serverType = grdServer.activeDataRow["Server Type"].ToString();

                // --
                mnuMenu.Tools[FMenuKey.MenuInqSvrRemotePingTest].SharedProps.Enabled = grdServer.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerStatus) ? true : false;
                // --
                mnuMenu.Tools[FMenuKey.MenuInqSvrStatus].SharedProps.Enabled = grdServer.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerStatus) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuInqSvrHistory].SharedProps.Enabled = grdServer.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerHistory) ? true : false;
                // --                
                mnuMenu.Tools[FMenuKey.MenuInqSvrResourceStatus].SharedProps.Enabled = grdServer.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerResourceStatus) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuInqSvrResourceHistory].SharedProps.Enabled = grdServer.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerResourceHistory) ? true : false;
                // --
                mnuMenu.Tools[FMenuKey.MenuInqSvrMainSwitch].SharedProps.Enabled = grdServer.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerMainSwitch) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuInqSvrBackupSwitch].SharedProps.Enabled = grdServer.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerBackupSwitch) ? true : false;
                // --
                mnuMenu.Tools[FMenuKey.MenuInqSvrAdminAgentLogList].SharedProps.Enabled = grdServer.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.AdminAgentLogList) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuInqSvrAdminAgentBackupLogList].SharedProps.Enabled = grdServer.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.AdminAgentBackupLogList) ? true : false;
                // --
                mnuMenu.Tools[FMenuKey.MenuInqSvrRemotePingTest].SharedProps.Enabled = grdServer.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.RemotePingTestByServer) ? true : false;

                // --

                #region Menu Control

                if (serverType == FServerType.Virtual.ToString())
                {
                    mnuMenu.Tools[FMenuKey.MenuInqSvrResourceStatus].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuInqSvrResourceHistory].SharedProps.Enabled = false;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuInqSvrMainSwitch].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuInqSvrBackupSwitch].SharedProps.Enabled = false;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuInqSvrAdminAgentLogList].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuInqSvrAdminAgentBackupLogList].SharedProps.Enabled = false;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuInqSvrRemotePingTest].SharedProps.Enabled = false;
                }

                #endregion

                // --

                mnuMenu.ShowPopup(FMenuKey.MenuInqSvrPopupMenu);
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

        private void grdServer_AfterRowFilterChanged(
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

                grdServer.beginUpdate();

                // --

                grdServer.Selected.Rows.Clear();
                foreach (UltraGridRow r in e.Rows.GetFilteredInNonGroupByRows())
                {
                    if (r == grdServer.ActiveRow)
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
                grdServer.ActiveRow = e.Rows.GetRowAtVisibleIndex(activateIndex);
                grdServer.DisplayLayout.RowScrollRegions[0].ScrollRowIntoView(grdServer.ActiveRow);

                // --

                grdServer.endUpdate();

                // --

                refreshServerTotal();
            }
            catch (Exception ex)
            {
                grdServer.endUpdate();
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

                mnuMenu.Tools[FMenuKey.MenuInqEapStatus].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapStatus) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuInqEapHistory].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapHistory) ? true : false;
                // --
                mnuMenu.Tools[FMenuKey.MenuInqEapRepositoryStatus].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapRepositoryStatus) ? true : false;
                // --
                mnuMenu.Tools[FMenuKey.MenuInqEapResourceHistory].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapResourceHistory) ? true : false;
                // --
                mnuMenu.Tools[FMenuKey.MenuInqEapRelease].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapRelease) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuInqEapStart].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapStart) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuInqEapStop].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapStop) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuInqEapReload].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapReload) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuInqEapRestart].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapRestart) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuInqEapAbort].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapAbort) ? true : false;
                // --
                mnuMenu.Tools[FMenuKey.MenuInqEapMove].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapMove) ? true : false;
                // --
                mnuMenu.Tools[FMenuKey.MenuInqEapLogList].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapLogList) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuInqEapBackupLogList].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapBackupLogList) ? true : false;
                // --
                // ***
                // 2017.06.02 by spike.lee
                // EAP Interface Log 관련 권한 추가
                // ***
                mnuMenu.Tools[FMenuKey.MenuInqEapInterfaceLogList].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapInterfaceLogList) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuInqEapInterfaceBackupLogList].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapInterfaceBackupLogList) ? true : false;
                // --
                mnuMenu.Tools[FMenuKey.MenuInqEapReferenceSheet].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapReferenceSheet);

                // --

                #region Menu Control

                if (grdEap.ActiveRow != null)
                {
                    eapType = grdEap.activeDataRow["Type"].ToString();
                    operMode = grdEap.activeDataRow["Operation Mode"].ToString();
                    mnuMenu.Tools[FMenuKey.MenuInqEapInterfaceLogList].SharedProps.Visible = false;
                    mnuMenu.Tools[FMenuKey.MenuInqEapInterfaceBackupLogList].SharedProps.Visible = false;

                    // --

                    if (eapType == FEapType.Process.ToString())
                    {
                        mnuMenu.Tools[FMenuKey.MenuInqEapRelease].SharedProps.Enabled = false;
                        mnuMenu.Tools[FMenuKey.MenuInqEapStart].SharedProps.Enabled = false;
                        mnuMenu.Tools[FMenuKey.MenuInqEapStop].SharedProps.Enabled = false;
                        mnuMenu.Tools[FMenuKey.MenuInqEapReload].SharedProps.Enabled = false;
                        mnuMenu.Tools[FMenuKey.MenuInqEapRestart].SharedProps.Enabled = false;
                        mnuMenu.Tools[FMenuKey.MenuInqEapAbort].SharedProps.Enabled = false;
                        mnuMenu.Tools[FMenuKey.MenuInqEapLogList].SharedProps.Enabled = false;
                        mnuMenu.Tools[FMenuKey.MenuInqEapBackupLogList].SharedProps.Enabled = false;
                        mnuMenu.Tools[FMenuKey.MenuInqEapInterfaceLogList].SharedProps.Enabled = false;
                        mnuMenu.Tools[FMenuKey.MenuInqEapInterfaceBackupLogList].SharedProps.Enabled = false;
                        // --
                        mnuMenu.Tools[FMenuKey.MenuInqEapReferenceSheet].SharedProps.Enabled = false;
                    }
                    else if (operMode == FEapOperationMode.Client.ToString())
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

        #region grdEquipment Control Event Handler

        private void grdEquipment_MouseDown(
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

                mnuMenu.Tools[FMenuKey.MenuInqEqpRemotePingTest].SharedProps.Enabled = grdEqp.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.RemotePingTestByEquipment) ? true : false;
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

        #region rstSvrToolbar Control Event Handler

        private void rstSvrToolbar_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdServer.searchGridRow(e.searchWord))
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

        private void rstEapToolbar_SearchRequested(
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

        #region rstEquipmentToolbar Control Event Handler

        private void rstEquipmentToolbar_SearchRequested(
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
        
        #region uneSec Control Event Handler

        private void uneSec_BeforeExitEditMode(
            object sender,
            Infragistics.Win.BeforeExitEditModeEventArgs e
            )
        {
            int secInterval = 0;

            try
            {
                secInterval = (int)uneSec.Value;

                if (secInterval < 2 || secInterval > 600)
                {
                    uneSec.Value = 2;
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

        private void uneSec_EditorSpinButtonClick(
            object sender,
            SpinButtonClickEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                if (e.ButtonType == SpinButtonItem.NextItem)
                {
                    uneSec.Value = (int)uneSec.Value >= 600 ? 2 : (int)uneSec.Value + 1;
                }
                else if (e.ButtonType == SpinButtonItem.PreviousItem)
                {
                    uneSec.Value = (int)uneSec.Value <= 2 ? 600 : (int)uneSec.Value - 1;
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

        #region m_thdAutoRefresh Object Event Handler

        private void m_thdAutoRefresh_ThreadJobCalled(
            object sender,
            FThreadEventArgs e
            )
        {
            try
            {
                if (m_autoRefreshTimer == null)
                {
                    m_autoRefreshTimer = new FStaticTimer();
                    m_autoRefreshTimer.start(int.Parse(uneSec.Value.ToString()) * 1000);
                    return;
                }
                // --

                if (!m_autoRefreshTimer.elasped(true))
                {
                    e.sleepThread(1);
                    return;
                }

                // --
                this.Invoke(new MethodInvoker(
                    delegate()
                    {
                        refresh();
                    }
                ));

                // --
                e.sleepThread(10);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);

                // ***
                // Thread 작업 실패 시, 빈번히 발생할 수 있기 때문에 1초간 Delay 한다.
                // ***
                e.sleepThread(1000);
            }
            finally
            {

            }

        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
