/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FIssueEventMonitor.cs
--  Creator         : spike.lee
--  Create Date     : 2017.07.13
--  Description     : FAMate Admin Service Backup Log List Form Class 
--  History         : Created by spike.lee at 2017.07.13
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Data;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public partial class FIssueEventMonitor : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private List<string> m_oldServerKyes = null;
        private List<string> m_oldEapKeys = null;
        private List<string> m_oldEquipmentKeys = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FIssueEventMonitor(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIssueEventMonitor(
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
                    return grdEap.ActiveRow.Cells["EAP"].Text;
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

                    return grdEap.ActiveRow.Cells["Type"].Text;
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

        private void designGridOfServer(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdServer.dataSource;
                // --
                uds.Band.Columns.Add("Time");
                uds.Band.Columns.Add("Server");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Event");
                for (int i = 1; i <= 20; i++)
                {
                    uds.Band.Columns.Add("Header " + i.ToString());
                    uds.Band.Columns.Add("Data " + i.ToString());
                }
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
                uds.Band.Columns.Add("User ID");                
                uds.Band.Columns.Add("Comment");

                // --

                grdServer.DisplayLayout.Bands[0].Columns["Time"].CellAppearance.Image = Properties.Resources.History;

                // --

                grdServer.DisplayLayout.Bands[0].Columns["Time"].Header.Fixed = true;
                grdServer.DisplayLayout.Bands[0].Columns["Server"].Header.Fixed = true;
                grdServer.DisplayLayout.Bands[0].Columns["Description"].Header.Fixed = true;
                grdServer.DisplayLayout.Bands[0].Columns["Event"].Header.Fixed = true;

                // --

                grdServer.DisplayLayout.Bands[0].Columns["Time"].Width = 174;
                grdServer.DisplayLayout.Bands[0].Columns["Server"].Width = 100;
                grdServer.DisplayLayout.Bands[0].Columns["Description"].Width = 150;
                grdServer.DisplayLayout.Bands[0].Columns["Event"].Width = 180;
                grdServer.DisplayLayout.Bands[0].Columns["Server Type"].Width = 90;
                grdServer.DisplayLayout.Bands[0].Columns["Up/Down"].Width = 60;
                grdServer.DisplayLayout.Bands[0].Columns["Status"].Width = 60;
                grdServer.DisplayLayout.Bands[0].Columns["Agent"].Width = 60;
                grdServer.DisplayLayout.Bands[0].Columns["Server IP"].Width = 110;
                grdServer.DisplayLayout.Bands[0].Columns["Used Backup"].Width = 90;
                grdServer.DisplayLayout.Bands[0].Columns["Backup Mode"].Width = 70;
                grdServer.DisplayLayout.Bands[0].Columns["Backup Server"].Width = 120;
                grdServer.DisplayLayout.Bands[0].Columns["B.Server Up/Down"].Width = 100;
                grdServer.DisplayLayout.Bands[0].Columns["B.Server Status"].Width = 100;
                grdServer.DisplayLayout.Bands[0].Columns["B.Server Agent"].Width = 100;
                grdServer.DisplayLayout.Bands[0].Columns["OPC Server Monitoring"].Width = 100;
                grdServer.DisplayLayout.Bands[0].Columns["OPC Server"].Width = 100;
                grdServer.DisplayLayout.Bands[0].Columns["User ID"].Width = 100;
                for (int i = 1; i <= 20; i++)
                {
                    grdServer.DisplayLayout.Bands[0].Columns["Header " + i.ToString()].Width = 100;
                    grdServer.DisplayLayout.Bands[0].Columns["Header " + i.ToString()].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    // --
                    grdServer.DisplayLayout.Bands[0].Columns["Data " + i.ToString()].Width = 100;
                }
                grdServer.DisplayLayout.Bands[0].Columns["Comment"].Width = 200;

                // --
                
                grdServer.DisplayLayout.Override.TipStyleCell = TipStyle.Show;
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
                uds.Band.Columns.Add("Time");
                uds.Band.Columns.Add("EAP");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Event");
                for (int i = 1; i <= 20; i++)
                {
                    uds.Band.Columns.Add("Header " + i.ToString());
                    uds.Band.Columns.Add("Data " + i.ToString());
                }
                uds.Band.Columns.Add("Type");
                uds.Band.Columns.Add("Operation Mode");
                uds.Band.Columns.Add("Server");
                uds.Band.Columns.Add("Step");
                uds.Band.Columns.Add("Up/Down");
                uds.Band.Columns.Add("Status");
                uds.Band.Columns.Add("Operation Status");
                uds.Band.Columns.Add("Need Action");
                uds.Band.Columns.Add("Next Need Action");
                uds.Band.Columns.Add("User ID");
                uds.Band.Columns.Add("(Set) Package");
                uds.Band.Columns.Add("(Rel) Package");
                uds.Band.Columns.Add("(Apl) Package");
                uds.Band.Columns.Add("(Set) Model");
                uds.Band.Columns.Add("(Rel) Model");
                uds.Band.Columns.Add("(Apl) Model");
                uds.Band.Columns.Add("(Set) Component");
                uds.Band.Columns.Add("(Rel) Component");
                uds.Band.Columns.Add("(Apl) Component");                
                uds.Band.Columns.Add("Comment");

                // --

                grdEap.DisplayLayout.Bands[0].Columns["Time"].CellAppearance.Image = Properties.Resources.History;

                // --

                grdEap.DisplayLayout.Bands[0].Columns["Time"].Header.Fixed = true;
                grdEap.DisplayLayout.Bands[0].Columns["EAP"].Header.Fixed = true;
                grdEap.DisplayLayout.Bands[0].Columns["Description"].Header.Fixed = true;
                grdEap.DisplayLayout.Bands[0].Columns["Event"].Header.Fixed = true;

                // --

                grdEap.DisplayLayout.Bands[0].Columns["Time"].Width = 174;
                grdEap.DisplayLayout.Bands[0].Columns["EAP"].Width = 100;
                grdEap.DisplayLayout.Bands[0].Columns["Description"].Width = 150;
                grdEap.DisplayLayout.Bands[0].Columns["Event"].Width = 180;
                grdEap.DisplayLayout.Bands[0].Columns["Type"].Width = 80;
                grdEap.DisplayLayout.Bands[0].Columns["Operation Mode"].Width = 110;
                grdEap.DisplayLayout.Bands[0].Columns["Server"].Width = 100;
                grdEap.DisplayLayout.Bands[0].Columns["Step"].Width = 80;
                grdEap.DisplayLayout.Bands[0].Columns["Up/Down"].Width = 80;
                grdEap.DisplayLayout.Bands[0].Columns["Status"].Width = 80;
                grdEap.DisplayLayout.Bands[0].Columns["Operation Status"].Width = 80;
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
                for (int i = 1; i <= 20; i++)
                {
                    grdEap.DisplayLayout.Bands[0].Columns["Header " + i.ToString()].Width = 100;
                    grdEap.DisplayLayout.Bands[0].Columns["Header " + i.ToString()].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    // --
                    grdEap.DisplayLayout.Bands[0].Columns["Data " + i.ToString()].Width = 100;
                }
                grdEap.DisplayLayout.Bands[0].Columns["Comment"].Width = 200;

                // --

                grdEap.DisplayLayout.Override.TipStyleCell = TipStyle.Show;
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
                uds.Band.Columns.Add("Time");
                uds.Band.Columns.Add("Equipment");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Event");
                for (int i = 1; i <= 20; i++)
                {
                    uds.Band.Columns.Add("Header " + i.ToString());
                    uds.Band.Columns.Add("Data " + i.ToString());
                }
                uds.Band.Columns.Add("System Code");
                uds.Band.Columns.Add("EAP");
                uds.Band.Columns.Add("Control Mode");
                uds.Band.Columns.Add("Primary State");
                uds.Band.Columns.Add("State");
                uds.Band.Columns.Add("Mode");
                uds.Band.Columns.Add("MDLN");
                uds.Band.Columns.Add("Soft Rev.");
                uds.Band.Columns.Add("Event Define");
                uds.Band.Columns.Add("EAP Event");
                uds.Band.Columns.Add("Equipment Recipe");
                uds.Band.Columns.Add("User ID");                
                uds.Band.Columns.Add("Comment");

                // --

                grdEqp.DisplayLayout.Bands[0].Columns["Time"].CellAppearance.Image = Properties.Resources.History;

                // --

                grdEqp.DisplayLayout.Bands[0].Columns["Time"].Header.Fixed = true;
                grdEqp.DisplayLayout.Bands[0].Columns["Equipment"].Header.Fixed = true;
                grdEqp.DisplayLayout.Bands[0].Columns["Description"].Header.Fixed = true;
                grdEqp.DisplayLayout.Bands[0].Columns["Event"].Header.Fixed = true;

                // --

                grdEqp.DisplayLayout.Bands[0].Columns["Time"].Width = 174;
                grdEqp.DisplayLayout.Bands[0].Columns["Equipment"].Width = 100;
                grdEqp.DisplayLayout.Bands[0].Columns["Description"].Width = 150;
                grdEqp.DisplayLayout.Bands[0].Columns["Event"].Width = 180;
                grdEqp.DisplayLayout.Bands[0].Columns["System Code"].Width = 60;
                grdEqp.DisplayLayout.Bands[0].Columns["EAP"].Width = 100;
                grdEqp.DisplayLayout.Bands[0].Columns["Control Mode"].Width = 100;
                grdEqp.DisplayLayout.Bands[0].Columns["Primary State"].Width = 120;
                grdEqp.DisplayLayout.Bands[0].Columns["State"].Width = 80;
                grdEqp.DisplayLayout.Bands[0].Columns["Mode"].Width = 80;
                grdEqp.DisplayLayout.Bands[0].Columns["MDLN"].Width = 80;
                grdEqp.DisplayLayout.Bands[0].Columns["Soft Rev."].Width = 80;
                grdEqp.DisplayLayout.Bands[0].Columns["Event Define"].Width = 80;
                grdEqp.DisplayLayout.Bands[0].Columns["EAP Event"].Width = 180;
                grdEqp.DisplayLayout.Bands[0].Columns["Equipment Recipe"].Width = 140;
                grdEqp.DisplayLayout.Bands[0].Columns["User ID"].Width = 100;
                for (int i = 1; i <= 20; i++)
                {
                    grdEqp.DisplayLayout.Bands[0].Columns["Header " + i.ToString()].Width = 100;
                    grdEqp.DisplayLayout.Bands[0].Columns["Header " + i.ToString()].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    // --
                    grdEqp.DisplayLayout.Bands[0].Columns["Data " + i.ToString()].Width = 100;
                }
                grdEqp.DisplayLayout.Bands[0].Columns["Comment"].Width = 200;

                // --

                grdEqp.DisplayLayout.Override.TipStyleCell = TipStyle.Show;
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

        private void refreshGridOfServer(
             )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            object[] cellValues = null;
            string beforeKey = string.Empty;
            string key = string.Empty;
            string server = string.Empty;
            string seq = string.Empty;
            int nextRowNumber = 0;
            int index = 0;
            bool isFreeze = false;

            try
            {
                isFreeze = ((Infragistics.Win.UltraWinToolbars.StateButtonTool)mnuMenu.Tools[FMenuKey.MenuMonIehFreezeScreen]).Checked;

                // --

                beforeKey = grdServer.activeDataRowKey;
                // --
                grdServer.beginUpdate(false);
                grdServer.removeAllDataRow();
                grdServer.DisplayLayout.Bands[0].SortedColumns.Clear();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("maxNum", m_fAdmCore.fOption.serverIssueMonitoringCount.ToString());
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Tool", "IssueEventMonitor", "SearchServerIeh", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        server = r["SERVER"].ToString();
                        seq = r["HIST_SEQ"].ToString();

                        // --

                        cellValues = new object[] {
                            FDataConvert.defaultDataTimeFormating(r["TRAN_TIME"].ToString()), // Time
                            r["SERVER"].ToString(),     // Server
                            r["SVR_DESC"].ToString(),    // Description
                            r["EVENT_ID"].ToString(),     // Event                            
                            // --
                            r["EVT_H_1"].ToString(),
                            r["EVT_D_1"].ToString(),
                            r["EVT_H_2"].ToString(),
                            r["EVT_D_2"].ToString(),
                            r["EVT_H_3"].ToString(),
                            r["EVT_D_3"].ToString(),
                            r["EVT_H_4"].ToString(),
                            r["EVT_D_4"].ToString(),
                            r["EVT_H_5"].ToString(),
                            r["EVT_D_5"].ToString(),
                            r["EVT_H_6"].ToString(),
                            r["EVT_D_6"].ToString(),
                            r["EVT_H_7"].ToString(),
                            r["EVT_D_7"].ToString(),
                            r["EVT_H_8"].ToString(),
                            r["EVT_D_8"].ToString(),
                            r["EVT_H_9"].ToString(),
                            r["EVT_D_9"].ToString(),
                            r["EVT_H_10"].ToString(),
                            r["EVT_D_10"].ToString(),
                            r["EVT_H_11"].ToString(),
                            r["EVT_D_11"].ToString(),
                            r["EVT_H_12"].ToString(),
                            r["EVT_D_12"].ToString(),
                            r["EVT_H_13"].ToString(),
                            r["EVT_D_13"].ToString(),
                            r["EVT_H_14"].ToString(),
                            r["EVT_D_14"].ToString(),
                            r["EVT_H_15"].ToString(),
                            r["EVT_D_15"].ToString(),
                            r["EVT_H_16"].ToString(),
                            r["EVT_D_16"].ToString(),
                            r["EVT_H_17"].ToString(),
                            r["EVT_D_17"].ToString(),
                            r["EVT_H_18"].ToString(),
                            r["EVT_D_18"].ToString(),
                            r["EVT_H_19"].ToString(),
                            r["EVT_D_19"].ToString(),
                            r["EVT_H_20"].ToString(),
                            r["EVT_D_20"].ToString(), 
                            // --
                            r["SVR_TYPE"].ToString(),
                            r["SVR_IP"].ToString(),
                            r["UP_DOWN"].ToString(),
                            r["STATUS"].ToString(),
                            r["ADA_UP_DOWN"].ToString(),
                            r["B_USED"].ToString(),
                            r["B_MODE"].ToString(),
                            r["B_SERVER"].ToString(),
                            r["B_UP_DOWN"].ToString(),
                            r["B_STATUS"].ToString(),
                            r["B_ADA_UP_DOWN"].ToString(),
                            r["OPC_SVR_MON"].ToString(),
                            r["OPC_SVR_UP_DOWN"].ToString(),
                            r["TRAN_USER_ID"].ToString(),
                            r["TRAN_COMMENT"].ToString()
                            };
                        key = generateKey(new string[] { server, seq });
                        index = grdServer.appendDataRow(key, cellValues).Index;

                        // --

                        if (isFreeze && m_oldServerKyes != null && !m_oldServerKyes.Contains(key))
                        {
                            grdServer.Rows[index].Appearance.FontData.Bold = DefaultableBoolean.True;
                            grdServer.Rows[index].Appearance.BackColor = Color.FromArgb(255, 221, 211);
                        }
                        else
                        {
                            grdServer.Rows[index].Appearance.FontData.Bold = DefaultableBoolean.False;
                            grdServer.Rows[index].Appearance.BackColor = Color.WhiteSmoke;
                        }
                    }
                } while (nextRowNumber >= 0);

                // --

                grdServer.endUpdate(false);

                // --

                if (grdServer.Rows.Count > 0)
                {
                    if (isFreeze)
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
                    else
                    {
                        grdServer.ActiveRow = grdServer.Rows[0];
                    }                    
                }
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

                // --

                m_oldServerKyes = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void refreshGridOfEap(
             )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            object[] cellValues = null;
            string beforeKey = string.Empty;
            string key = string.Empty;
            string eap = string.Empty;
            string seq = string.Empty;
            int nextRowNumber = 0;
            int index = 0;
            bool isFreeze = false;

            try
            {
                isFreeze = ((Infragistics.Win.UltraWinToolbars.StateButtonTool)mnuMenu.Tools[FMenuKey.MenuMonIehFreezeScreen]).Checked;

                // --

                beforeKey = grdEap.activeDataRowKey;
                // --
                grdEap.beginUpdate(false);
                grdEap.removeAllDataRow();
                grdEap.DisplayLayout.Bands[0].SortedColumns.Clear();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("maxNum", m_fAdmCore.fOption.eapIssueMonitoringCount.ToString());
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Tool", "IssueEventMonitor", "SearchEapIeh", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        eap = r["EAP"].ToString();
                        seq = r["HIST_SEQ"].ToString();

                        // --

                        cellValues = new object[] {
                            FDataConvert.defaultDataTimeFormating(r["TRAN_TIME"].ToString()), // Time
                            r["EAP"].ToString(),     // EAP
                            r["EAP_DESC"].ToString(),    // Description
                            r["EVENT_ID"].ToString(),     // Event
                            // --
                            r["EVT_H_1"].ToString(),
                            r["EVT_D_1"].ToString(),
                            r["EVT_H_2"].ToString(),
                            r["EVT_D_2"].ToString(),
                            r["EVT_H_3"].ToString(),
                            r["EVT_D_3"].ToString(),
                            r["EVT_H_4"].ToString(),
                            r["EVT_D_4"].ToString(),
                            r["EVT_H_5"].ToString(),
                            r["EVT_D_5"].ToString(),
                            r["EVT_H_6"].ToString(),
                            r["EVT_D_6"].ToString(),
                            r["EVT_H_7"].ToString(),
                            r["EVT_D_7"].ToString(),
                            r["EVT_H_8"].ToString(),
                            r["EVT_D_8"].ToString(),
                            r["EVT_H_9"].ToString(),
                            r["EVT_D_9"].ToString(),
                            r["EVT_H_10"].ToString(),
                            r["EVT_D_10"].ToString(),
                            r["EVT_H_11"].ToString(),
                            r["EVT_D_11"].ToString(),
                            r["EVT_H_12"].ToString(),
                            r["EVT_D_12"].ToString(),
                            r["EVT_H_13"].ToString(),
                            r["EVT_D_13"].ToString(),
                            r["EVT_H_14"].ToString(),
                            r["EVT_D_14"].ToString(),
                            r["EVT_H_15"].ToString(),
                            r["EVT_D_15"].ToString(),
                            r["EVT_H_16"].ToString(),
                            r["EVT_D_16"].ToString(),
                            r["EVT_H_17"].ToString(),
                            r["EVT_D_17"].ToString(),
                            r["EVT_H_18"].ToString(),
                            r["EVT_D_18"].ToString(),
                            r["EVT_H_19"].ToString(),
                            r["EVT_D_19"].ToString(),
                            r["EVT_H_20"].ToString(),
                            r["EVT_D_20"].ToString(),
                            // --
                            r["EAP_TYPE"].ToString(),    // Type
                            r["OPER_MODE"].ToString(),    // Operation Mode
                            r["SERVER"].ToString(),     // Server
                            r["STEP"].ToString(),     // Step            
                            r["UP_DOWN"].ToString(),     // Up/Down
                            r["STATUS"].ToString(),     // Status            
                            r["OPERATION_STATUS"].ToString(),     // Operation Status
                            r["NEED_ACTION"].ToString(),     // Need Action         
                            r["NEXT_NEED_ACTION"].ToString(),    // Next Need Action          
                            r["TRAN_USER_ID"].ToString(),    // User ID
                            // --
                            FCommon.generateStringForPackage(r["SET_PACKAGE"].ToString(), r["SET_PKG_VER"].ToString()),   // (Set) Package
                            FCommon.generateStringForPackage(r["REL_PACKAGE"].ToString(), r["REL_PKG_VER"].ToString()),   // (Rel) Package
                            FCommon.generateStringForPackage(r["APL_PACKAGE"].ToString(), r["APL_PKG_VER"].ToString()),   // (Apl) Package
                            FCommon.generateStringForModel(r["SET_MODEL"].ToString(), r["SET_MDL_VER"].ToString()),     // (Set) Model
                            FCommon.generateStringForModel(r["REL_MODEL"].ToString(), r["REL_MDL_VER"].ToString()),     // (Rel) Model
                            FCommon.generateStringForModel(r["APL_MODEL"].ToString(), r["APL_MDL_VER"].ToString()),     // (Apl) Model
                            FCommon.generateStringForComponent(r["SET_USED_COM"].ToString(), r["SET_COMPONENT"].ToString(), r["SET_COM_VER"].ToString()),   // (Set) Component
                            FCommon.generateStringForComponent(r["REL_USED_COM"].ToString(), r["REL_COMPONENT"].ToString(), r["REL_COM_VER"].ToString()),   // (Rel) Component
                            FCommon.generateStringForComponent(r["APL_USED_COM"].ToString(), r["APL_COMPONENT"].ToString(), r["APL_COM_VER"].ToString()),   // (Apl) Component
                            // --
                            r["TRAN_COMMENT"].ToString()     // Comments
                            };
                        key = generateKey(new string[] { eap, seq });
                        index = grdEap.appendDataRow(key, cellValues).Index;

                        // --

                        if (isFreeze && m_oldEapKeys != null && !m_oldEapKeys.Contains(key))
                        {
                            grdEap.Rows[index].Appearance.FontData.Bold = DefaultableBoolean.True;
                            grdEap.Rows[index].Appearance.BackColor = Color.FromArgb(255, 221, 211);
                        }
                        else
                        {
                            grdEap.Rows[index].Appearance.FontData.Bold = DefaultableBoolean.False;
                            grdEap.Rows[index].Appearance.BackColor = Color.WhiteSmoke;
                        }
                    }
                } while (nextRowNumber >= 0);

                // --

                grdEap.endUpdate(false);

                // --

                if (grdEap.Rows.Count > 0)
                {
                    if (isFreeze)
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
                    else
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

                // --

                m_oldEapKeys = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void refreshGridOfEquipment(
             )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            object[] cellValues = null;
            string beforeKey = string.Empty;
            string key = string.Empty;
            string eqp = string.Empty;
            string seq = string.Empty;
            int nextRowNumber = 0;
            int index = 0;
            bool isFreeze = false;

            try
            {
                isFreeze = ((Infragistics.Win.UltraWinToolbars.StateButtonTool)mnuMenu.Tools[FMenuKey.MenuMonIehFreezeScreen]).Checked;

                // --

                beforeKey = grdEqp.activeDataRowKey;
                // --
                grdEqp.beginUpdate(false);
                grdEqp.removeAllDataRow();
                grdEqp.DisplayLayout.Bands[0].SortedColumns.Clear();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("maxNum", m_fAdmCore.fOption.equipmentIssueMonitoringCount.ToString());
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Tool", "IssueEventMonitor", "SearchEquipmentIeh", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        eqp = r["EQP_NAME"].ToString();
                        seq = r["HIST_SEQ"].ToString();

                        // --

                        cellValues = new object[] {
                            FDataConvert.defaultDataTimeFormating(r["TRAN_TIME"].ToString()), // Time
                            r["EQP_NAME"].ToString(),     // Equipment
                            r["EQP_DESC"].ToString(),    // Description                            
                            r["EVENT_ID"].ToString(),     // Event                            
                            // --
                            r["EVT_H_1"].ToString(),
                            r["EVT_D_1"].ToString(),
                            r["EVT_H_2"].ToString(),
                            r["EVT_D_2"].ToString(),
                            r["EVT_H_3"].ToString(),
                            r["EVT_D_3"].ToString(),
                            r["EVT_H_4"].ToString(),
                            r["EVT_D_4"].ToString(),
                            r["EVT_H_5"].ToString(),
                            r["EVT_D_5"].ToString(),
                            r["EVT_H_6"].ToString(),
                            r["EVT_D_6"].ToString(),
                            r["EVT_H_7"].ToString(),
                            r["EVT_D_7"].ToString(),
                            r["EVT_H_8"].ToString(),
                            r["EVT_D_8"].ToString(),
                            r["EVT_H_9"].ToString(),
                            r["EVT_D_9"].ToString(),
                            r["EVT_H_10"].ToString(),
                            r["EVT_D_10"].ToString(),
                            r["EVT_H_11"].ToString(),
                            r["EVT_D_11"].ToString(),
                            r["EVT_H_12"].ToString(),
                            r["EVT_D_12"].ToString(),
                            r["EVT_H_13"].ToString(),
                            r["EVT_D_13"].ToString(),
                            r["EVT_H_14"].ToString(),
                            r["EVT_D_14"].ToString(),
                            r["EVT_H_15"].ToString(),
                            r["EVT_D_15"].ToString(),
                            r["EVT_H_16"].ToString(),
                            r["EVT_D_16"].ToString(),
                            r["EVT_H_17"].ToString(),
                            r["EVT_D_17"].ToString(),
                            r["EVT_H_18"].ToString(),
                            r["EVT_D_18"].ToString(),
                            r["EVT_H_19"].ToString(),
                            r["EVT_D_19"].ToString(),
                            r["EVT_H_20"].ToString(),
                            r["EVT_D_20"].ToString(),
                            // --
                            r["SYSTEM"].ToString(),     // System Code
                            r["EAP"].ToString(),     // EAP
                            r["CTRL_MODE"].ToString(),     // Control Mode
                            r["PRI_STATE"].ToString(),     // Primary State      
                            r["STATE"].ToString(),     // State
                            r["EQP_MODE"].ToString(),     // Mode            
                            r["MDLN"].ToString(),    // MDLN          
                            r["SOFTREV"].ToString(),    // Soft Rev.
                            r["EVENT_DEFINE"].ToString(),    // Event Define
                            r["EAP_EVENT_ID"].ToString(),    // EAP Event
                            r["EQP_RCP_ID"].ToString(),    // Equipment Recipe                            
                            r["TRAN_USER_ID"].ToString(),    // User ID
                            r["TRAN_COMMENT"].ToString()     // Comments
                            };
                        key = generateKey(new string[] { eqp, seq });
                        index = grdEqp.appendDataRow(key, cellValues).Index;

                        // --

                        if (isFreeze && m_oldEquipmentKeys != null && !m_oldEquipmentKeys.Contains(key))
                        {
                            grdEqp.Rows[index].Appearance.FontData.Bold = DefaultableBoolean.True;
                            grdEqp.Rows[index].Appearance.BackColor = Color.FromArgb(255, 221, 211);
                        }
                        else
                        {
                            grdEqp.Rows[index].Appearance.FontData.Bold = DefaultableBoolean.False;
                            grdEqp.Rows[index].Appearance.BackColor = Color.WhiteSmoke;
                        }
                    }
                } while (nextRowNumber >= 0);

                // --

                grdEqp.endUpdate(false);

                // --

                if (grdEqp.Rows.Count > 0)
                {
                    if (isFreeze)
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
                    else
                    {
                        grdEqp.ActiveRow = grdEqp.Rows[0];
                    }
                }
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

                // --

                m_oldEquipmentKeys = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private string generateKey(
            string[] items
            )
        {
            try
            {
                return string.Join(new string(new char[] { FConstants.KeySeparator }), items);
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

        //------------------------------------------------------------------------------------------------------------------------        

        private void refreshServer(
            )
        {
            try
            {
                m_oldServerKyes = new List<string>();
                foreach (UltraGridRow r in grdServer.Rows)
                {
                    if (r.Appearance.FontData.Bold == DefaultableBoolean.True)
                    {
                        continue;
                    }
                    // --
                    m_oldServerKyes.Add(grdServer.getDataRowKey(r.Index));  
                }
                // --
                refreshGridOfServer();
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void refreshEap(
            )
        {
            try
            {
                m_oldEapKeys = new List<string>();
                foreach (UltraGridRow r in grdEap.Rows)
                {
                    if (r.Appearance.FontData.Bold == DefaultableBoolean.True)
                    {
                        continue;
                    }
                    m_oldEapKeys.Add(grdEap.getDataRowKey(r.Index));
                }
                // --
                refreshGridOfEap();
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void refreshEquipment(
            )
        {
            try
            {
                m_oldEquipmentKeys = new List<string>();
                foreach (UltraGridRow r in grdEqp.Rows)
                {
                    if (r.Appearance.FontData.Bold == DefaultableBoolean.True)
                    {
                        continue;
                    }
                    m_oldEquipmentKeys.Add(grdEqp.getDataRowKey(r.Index));
                }
                // --
                refreshGridOfEquipment();
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
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
                fServerStatus.attach(grdServer.ActiveRow.Cells["Server"].Text);
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
                fServerHistory.attach(grdServer.ActiveRow.Cells["Server"].Text);
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
                fServerResourceStatus.attach(grdServer.ActiveRow.Cells["Server"].Text);
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
                fServerResourceHistory.attach(grdServer.ActiveRow.Cells["Server"].Text);
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
                fAdminAgentLogList.attach(grdServer.ActiveRow.Cells["Server"].Text);
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
                fAdminAgentBackupLogList.attach(grdServer.ActiveRow.Cells["Server"].Text);
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
                fEapStatus.attach(grdEap.ActiveRow.Cells["EAP"].Text, grdEap.ActiveRow.Cells["Type"].Text);
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
                fEapHistory.attach(grdEap.ActiveRow.Cells["EAP"].Text);
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
                        ((FEapReferenceSheet)f).eapName == grdEap.ActiveRow.Cells["EAP"].Text
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
                fEqpStatus.attach(grdEqp.ActiveRow.Cells["Equipment"].Text, FEapAttrCategory.Applied.ToString());
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
                fEqpHistory.attach(grdEqp.ActiveRow.Cells["Equipment"].Text);
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
                fEquipmentGemStatus.attach(grdEqp.ActiveRow.Cells["Equipment"].Text);
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

        #endregion

        #endregion

        //------------------------------------------------------------------------------------------------------------------------        

        #region FIssueEventMonitor Form Event Handler

        private void FIssueEventMonitor_Load(
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

        private void FIssueEventMonitor_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --          

                refreshGridOfServer();
                refreshGridOfEap();
                refreshGridOfEquipment();

                // --

                m_fAdmCore.ServerIssueEventRefresh += new FServerIssueEventRefreshEventHandler(m_fAdmCore_ServerIssueEventRefresh);
                m_fAdmCore.EapIssueEventRefresh += new FEapIssueEventRefreshEventHandler(m_fAdmCore_EapIssueEventRefresh);
                m_fAdmCore.EquipmentIssueEventRefresh += new FEquipmentIssueEventRefreshEventHandler(m_fAdmCore_EquipmentIssueEventRefresh);
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

        private void FIssueEventMonitor_FormClosing(
            object sender,
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fAdmCore.ServerIssueEventRefresh -= new FServerIssueEventRefreshEventHandler(m_fAdmCore_ServerIssueEventRefresh);
                m_fAdmCore.EapIssueEventRefresh -= new FEapIssueEventRefreshEventHandler(m_fAdmCore_EapIssueEventRefresh);
                m_fAdmCore.EquipmentIssueEventRefresh -= new FEquipmentIssueEventRefreshEventHandler(m_fAdmCore_EquipmentIssueEventRefresh);

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

        private void FIssueEventMonitor_KeyDown(
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

        #region picServer Control Event Handler

        private void picServer_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (spcMain.Panel2Collapsed)
                {
                    spcMain.Panel2Collapsed = false;
                }
                else
                {
                    spcMain.Panel2Collapsed = true;
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

        #region picEap Control Event Handler

        private void picEap_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (spcSub.Panel2Collapsed)
                {
                    spcMain.Panel1Collapsed = false;
                    spcSub.Panel2Collapsed = false;
                }
                else
                {
                    spcMain.Panel1Collapsed = true;
                    spcSub.Panel2Collapsed = true;
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

        #region picEqp Control Event Handler

        private void picEqp_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (spcSub.Panel1Collapsed)
                {
                    spcMain.Panel1Collapsed = false;
                    spcSub.Panel1Collapsed = false;
                }
                else
                {
                    spcMain.Panel1Collapsed = true;
                    spcSub.Panel1Collapsed = true;
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

                if (e.Tool.Key == FMenuKey.MenuMonIehRefresh)
                {
                    refreshGridOfServer();
                    refreshGridOfEap();
                    refreshGridOfEquipment();
                }
                // ***
                // Server Popup Menu
                // ***
                else if (e.Tool.Key == FMenuKey.MenuMonServerStatus)
                {
                    procMenuServerStatus();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonServerHistory)
                {
                    procMenuServerHistory();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonServerResourceStatus)
                {
                    procMenuServerResourceStatus();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonServerResourceHistory)
                {
                    procMenuServerResourceHistory();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonAdminAgentLogList)
                {
                    procMenuAdminAgentLogList();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonAdminAgentBackupLogList)
                {
                    procMenuAdminAgentBackupLogList();
                }
                // ***
                // EAP Popup Menu
                // ***
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
                else if (e.Tool.Key == FMenuKey.MenuMonEapResourceHistory)
                {
                    procMenuEapResourceHistory();
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
                else if (e.Tool.Key == FMenuKey.MenuMonEapReferenceSheet)
                {
                    procMenuEapReferenceSheet();
                }
                // ***
                // Equipment Popup Menu
                // *** 
                else if (e.Tool.Key == FMenuKey.MenuMonEquipmentStatus)
                {
                    procMenuEquipmentStatus();
                }
                else if (e.Tool.Key == FMenuKey.MenuMonEquipmentHistory)
                {
                    procMenuEquipmentHistory();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuMonEquipmentGemStatus)
                {
                    procMenuEquipmentGemStatus();
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

        #region m_fAdmCore Object Event Handler

        private void m_fAdmCore_ServerIssueEventRefresh(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        refreshServer();
                    }));
                }
                else
                {
                    refreshServer();
                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fAdmCore_EapIssueEventRefresh(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        refreshEap();
                    }));
                }
                else
                {
                    refreshEap();
                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fAdmCore_EquipmentIssueEventRefresh(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        refreshEquipment();
                    }));
                }
                else
                {
                    refreshGridOfEquipment();
                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

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
                if (grdEap.ActiveRow == null)
                {
                    return;
                }

                if (grdEap.ActiveRow.Appearance.FontData.Bold == DefaultableBoolean.True)
                {
                    grdEap.ActiveRow.Appearance.FontData.Bold = DefaultableBoolean.False;
                    grdEap.ActiveRow.Appearance.BackColor = Color.WhiteSmoke;
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

        private void grdEap_MouseDown(
            object sender, 
            MouseEventArgs e
            )
        {
            UltraGridRow r = null;

            try
            {
                FCursor.waitCursor();

                // --

                if (e.Button != MouseButtons.Right || grdEap.Rows.Count == 0)
                {
                    return;
                }

                // --

                r = (UltraGridRow)grdEap.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y)).GetContext(typeof(UltraGridRow));
                if (r != null)
                {
                    grdEap.ActiveRow = grdEap.Rows[r.Index];
                }

                // --

                mnuMenu.Tools[FMenuKey.MenuMonEapStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapStatus);
                mnuMenu.Tools[FMenuKey.MenuMonEapHistory].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapHistory);
                // --
                mnuMenu.Tools[FMenuKey.MenuMonEapRepositoryStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapRepositoryStatus) ? true : false;
                // --
                mnuMenu.Tools[FMenuKey.MenuMonEapResourceHistory].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapResourceHistory);
                // --
                mnuMenu.Tools[FMenuKey.MenuMonEapLogList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapLogList);
                mnuMenu.Tools[FMenuKey.MenuMonEapBackupLogList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapBackupLogList);
                // --
                mnuMenu.Tools[FMenuKey.MenuMonEapInterfaceLogList].SharedProps.Visible = false;
                mnuMenu.Tools[FMenuKey.MenuMonEapInterfaceBackupLogList].SharedProps.Visible = false;
                //mnuMenu.Tools[FMenuKey.MenuMonEapInterfaceLogList].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapInterfaceLogList) ? true : false;
                //mnuMenu.Tools[FMenuKey.MenuMonEapInterfaceBackupLogList].SharedProps.Enabled = grdEap.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapInterfaceBackupLogList) ? true : false;
                // --
                mnuMenu.Tools[FMenuKey.MenuMonEapReferenceSheet].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapReferenceSheet);

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

        private void grdEap_MouseDoubleClick(
            object sender, 
            MouseEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (grdEap.ActiveRow == null || !FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapHistory))
                {
                    return;
                }

                // --

                procMenuEapHistory();
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

        #region grdServer Control Event Handler

        private void grdServer_AfterRowActivate(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                if (grdServer.ActiveRow == null)
                {
                    return;
                }

                if (grdServer.ActiveRow.Appearance.FontData.Bold == DefaultableBoolean.True)
                {
                    grdServer.ActiveRow.Appearance.FontData.Bold = DefaultableBoolean.False;
                    grdServer.ActiveRow.Appearance.BackColor = Color.WhiteSmoke;
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

        private void grdServer_MouseDown(
            object sender, 
            MouseEventArgs e
            )
        {
            UltraGridRow r = null;

            try
            {
                FCursor.waitCursor();

                // --

                if (e.Button != MouseButtons.Right || grdServer.Rows.Count == 0)
                {
                    return;
                }

                // --

                r = (UltraGridRow)grdServer.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y)).GetContext(typeof(UltraGridRow));
                if (r != null)
                {
                    grdServer.ActiveRow = grdServer.Rows[r.Index];
                }

                // --

                mnuMenu.Tools[FMenuKey.MenuMonServerStatus].SharedProps.Enabled = grdServer.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerStatus) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuMonServerHistory].SharedProps.Enabled = grdServer.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerHistory) ? true : false;
                // --                
                mnuMenu.Tools[FMenuKey.MenuMonServerResourceStatus].SharedProps.Enabled = grdServer.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerResourceStatus) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuMonServerResourceHistory].SharedProps.Enabled = grdServer.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerResourceHistory) ? true : false;
                // --
                mnuMenu.Tools[FMenuKey.MenuMonAdminAgentLogList].SharedProps.Enabled = grdServer.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.AdminAgentLogList) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuMonAdminAgentBackupLogList].SharedProps.Enabled = grdServer.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.AdminAgentBackupLogList) ? true : false;
                
                // --

                mnuMenu.ShowPopup(FMenuKey.MenuMonSvrPopupMenu);
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

        private void grdServer_MouseDoubleClick(
            object sender, 
            MouseEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (grdServer.ActiveRow == null || !FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerHistory))
                {
                    return;
                }

                // --

                procMenuServerHistory();
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
                if (grdEqp.ActiveRow == null)
                {
                    return;
                }

                if (grdEqp.ActiveRow.Appearance.FontData.Bold == DefaultableBoolean.True)
                {
                    grdEqp.ActiveRow.Appearance.FontData.Bold = DefaultableBoolean.False;
                    grdEqp.ActiveRow.Appearance.BackColor = Color.WhiteSmoke;
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

                r = (UltraGridRow)grdEqp.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y)).GetContext(typeof(UltraGridRow));
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

        private void grdEqp_MouseDoubleClick(
            object sender, 
            MouseEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (grdEqp.ActiveRow == null || !FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapHistory))
                {
                    return;
                }

                // --

                procMenuEquipmentHistory();
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
