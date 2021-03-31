/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FServerResourceList.cs
--  Creator         : jungyoul moon
--  Create Date     : 2013.02.18
--  Description     : FAMate Admin Manager Server Resource List Form Class 
--  History         : Created by jungyoul moon at 2013.02.18
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinTree;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Infragistics.Win;

namespace Nexplant.MC.AdminManager
{
    public partial class FServerResourceList : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_cleared = true;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FServerResourceList(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FServerResourceList(
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
        
        private void designGridOfServerResource(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdServer.dataSource;
                // --
                uds.Band.Columns.Add("Server");
                uds.Band.Columns.Add("Computer Name");
                uds.Band.Columns.Add("Work Group");
                uds.Band.Columns.Add("User Name");
                uds.Band.Columns.Add("OS");
                uds.Band.Columns.Add("CPU");
                uds.Band.Columns.Add("CPU Usage (%)");
                uds.Band.Columns.Add("Memory (MB)");
                uds.Band.Columns.Add("Disk1 (MB)");
                uds.Band.Columns.Add("Disk2 (MB)");
                uds.Band.Columns.Add("Disk3 (MB)");
                uds.Band.Columns.Add("Disk4 (MB)");
                uds.Band.Columns.Add("Disk5 (MB)");
                uds.Band.Columns.Add("Disk6 (MB)");
                uds.Band.Columns.Add("Disk7 (MB)");
                uds.Band.Columns.Add("Disk8 (MB)");
                uds.Band.Columns.Add("Disk9 (MB)");
                uds.Band.Columns.Add("Disk10 (MB)");
                uds.Band.Columns.Add("Create User ID");
                uds.Band.Columns.Add("Create Time");
                uds.Band.Columns.Add("Update User ID");
                uds.Band.Columns.Add("Update Time");

                // --

                grdServer.DisplayLayout.Bands[0].Columns["Server"].CellAppearance.Image = Properties.Resources.Server;
                // --
                grdServer.DisplayLayout.Bands[0].Columns["CPU Usage (%)"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdServer.DisplayLayout.Bands[0].Columns["Memory (MB)"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdServer.DisplayLayout.Bands[0].Columns["Disk1 (MB)"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdServer.DisplayLayout.Bands[0].Columns["Disk2 (MB)"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdServer.DisplayLayout.Bands[0].Columns["Disk3 (MB)"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdServer.DisplayLayout.Bands[0].Columns["Disk4 (MB)"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdServer.DisplayLayout.Bands[0].Columns["Disk5 (MB)"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdServer.DisplayLayout.Bands[0].Columns["Disk6 (MB)"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdServer.DisplayLayout.Bands[0].Columns["Disk7 (MB)"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdServer.DisplayLayout.Bands[0].Columns["Disk8 (MB)"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdServer.DisplayLayout.Bands[0].Columns["Disk9 (MB)"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdServer.DisplayLayout.Bands[0].Columns["Disk10 (MB)"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdServer.DisplayLayout.Bands[0].Columns["Create Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdServer.DisplayLayout.Bands[0].Columns["Update Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

                // --

                grdServer.DisplayLayout.Bands[0].Columns["Server"].Header.Fixed = true;

                // --

                grdServer.DisplayLayout.Bands[0].Columns["Server"].Width = 120;
                grdServer.DisplayLayout.Bands[0].Columns["Computer name"].Width = 120;
                grdServer.DisplayLayout.Bands[0].Columns["Work Group"].Width = 180;
                grdServer.DisplayLayout.Bands[0].Columns["User Name"].Width = 180;
                grdServer.DisplayLayout.Bands[0].Columns["OS"].Width = 180;
                grdServer.DisplayLayout.Bands[0].Columns["CPU"].Width = 200;
                grdServer.DisplayLayout.Bands[0].Columns["CPU Usage (%)"].Width = 100;
                grdServer.DisplayLayout.Bands[0].Columns["Memory (MB)"].Width = 180;
                grdServer.DisplayLayout.Bands[0].Columns["Disk1 (MB)"].Width = 180;
                grdServer.DisplayLayout.Bands[0].Columns["Disk2 (MB)"].Width = 180;
                grdServer.DisplayLayout.Bands[0].Columns["Disk3 (MB)"].Width = 180;
                grdServer.DisplayLayout.Bands[0].Columns["Disk4 (MB)"].Width = 180;
                grdServer.DisplayLayout.Bands[0].Columns["Disk5 (MB)"].Width = 180;
                grdServer.DisplayLayout.Bands[0].Columns["Disk6 (MB)"].Width = 180;
                grdServer.DisplayLayout.Bands[0].Columns["Disk7 (MB)"].Width = 180;
                grdServer.DisplayLayout.Bands[0].Columns["Disk8 (MB)"].Width = 180;
                grdServer.DisplayLayout.Bands[0].Columns["Disk9 (MB)"].Width = 180;
                grdServer.DisplayLayout.Bands[0].Columns["Disk10 (MB)"].Width = 180;
                grdServer.DisplayLayout.Bands[0].Columns["Create User ID"].Width = 100;
                grdServer.DisplayLayout.Bands[0].Columns["Create Time"].Width = 165;
                grdServer.DisplayLayout.Bands[0].Columns["Update User ID"].Width = 100;
                grdServer.DisplayLayout.Bands[0].Columns["Update Time"].Width = 165;

                // --

                grdServer.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.MultiBand;
                grdServer.DisplayLayout.ViewStyleBand = ViewStyleBand.Vertical;

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

        private void controlMenu(
            )
        {
            try
            {
                mnuMenu.beginUpdate();

                // --

                if (m_cleared)
                {
                    mnuMenu.Tools[FMenuKey.MenuSvlExport].SharedProps.Enabled = false;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuSvlExport].SharedProps.Enabled = true;
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

        private void refreshGridOfServerResource(
             )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            object[] cellValues = null;
            List<string> diskList = null;
            string svrUpDown = string.Empty;
            string svrStatus = string.Empty;
            string cpu = string.Empty;
            string cpuUsage = string.Empty;
            string memory = string.Empty;
            string createTime = string.Empty;
            string updateTime = string.Empty;
            string key = string.Empty;
            string beforeKey = string.Empty;
            int nextRowNumber = 0;
            int index = 0;
            int diskIndex = 0;
            
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
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ServerResourceList", "ListServerResource", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        svrUpDown = r[1].ToString();
                        svrStatus = r[2].ToString();

                        // --

                        // Cpu
                        if(r[7].ToString() == string.Empty)
                        {
                            cpu = "N/A";
                            cpuUsage = "N/A";
                        }
                        else
                        {
                            cpu = r[7].ToString();
                            cpuUsage = r[8].ToString();
                        }
                        // Memory
                        if (double.Parse(r[9].ToString()) == 0)
                        {
                            memory = "N/A";
                        }
                        else
                        {
                            // Memory / Usage
                            memory = string.Format("{0} / {1}", r[10].ToString(), r[9].ToString());
                        }
                        // Disk
                        diskList = new List<string>();
                        diskIndex = 11;
                        for (int i = 0; i < 10; i++)
                        {
                            if (r[(diskIndex)].ToString() == string.Empty)
                            {
                                diskList.Add("N/A");
                            }
                            else
                            {
                                // DiskName : Size / Usage
                                diskList.Add(string.Format("({0}) {1} / {2}", r[diskIndex], r[diskIndex + 2], r[diskIndex + 1]));
                            }
                            diskIndex += 3;
                        }
                        // --
                        createTime = r[41].ToString() == string.Empty ? "N/A" : FDataConvert.defaultDataTimeFormating(r[41].ToString());
                        updateTime = r[43].ToString() == string.Empty ? "N/A" : FDataConvert.defaultDataTimeFormating(r[43].ToString());

                        // --                        

                        cellValues = new object[] {
                            r[0].ToString() == string.Empty ? "N/A" : r[0].ToString(),    // Server
                            r[3].ToString() == string.Empty ? "N/A" : r[3].ToString(),    // Computer Name
                            r[4].ToString() == string.Empty ? "N/A" : r[4].ToString(),    // Work Group
                            r[5].ToString() == string.Empty ? "N/A" : r[5].ToString(),    // User Name
                            r[6].ToString() == string.Empty ? "N/A" : r[6].ToString(),    // OS
                            cpu,                                                          // Cpu
                            cpuUsage,                                                     // Cpu Usage
                            memory,                                                       // Memory
                            diskList[0],                                                  // Disk1
                            diskList[1],                                                  // Disk2
                            diskList[2],                                                  // Disk3
                            diskList[3],                                                  // Disk4
                            diskList[4],                                                  // Disk5
                            diskList[5],                                                  // Disk6
                            diskList[6],                                                  // Disk7
                            diskList[7],                                                  // Disk8
                            diskList[8],                                                  // Disk9
                            diskList[9],                                                  // Disk10
                            r[42].ToString(),                                             // Create User ID
                            createTime,                                                   // Create Time
                            r[44].ToString(),                                             // Update User ID
                            updateTime                                                    // Update Time
                            };
                        key = (string)cellValues[0];
                        index = grdServer.appendDataRow(key, cellValues).Index;
                      
                    }
                } while (nextRowNumber >= 0);

                // --

                grdServer.endUpdate(false);

                // --

                if (grdServer.Rows.Count > 0)
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

                m_cleared = false;

                // --

                controlMenu();

                // --

                refreshTotal();

                // --

                grdServer.Focus();
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
                cellValues = null;
                diskList = null;
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        private void refreshTotal(
            )
        {
            try
            {
                lblTotal.Text = grdServer.Rows.VisibleRowCount.ToString("#,##0") + " / " + grdServer.Rows.Count.ToString("#,##0");
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
            SaveFileDialog sfd = null;
            string fileName = string.Empty;
            FExcelExporter2 fExcelExp = null;
            FExcelSheet fExcelSht = null;
            int rowIndex = 0;

            try
            {
                fileName= DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_ServerResourceList.xlsx";

                // --

                sfd = new SaveFileDialog();
                // --
                sfd.Title = "Export Server Resource List to Excel";
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
                fExcelSht = fExcelExp.addExcelSheet("Server Resource List");

                // --

                // ***
                // Title write
                // ***
                rowIndex = 0;
                fExcelSht.writeTitle(this.Text, rowIndex, 0);

                // --

                // ***
                // Server Resource List Grid Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Server Resource List") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
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

        #endregion

        #endregion

        //------------------------------------------------------------------------------------------------------------------------        

        #region FServerResourceList Form Event Handler

        private void FServerResourceList_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfServerResource();

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

        private void FServerResourceList_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfServerResource();

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

        private void FServerResourceList_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

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

        private void FServerResourceList_KeyDown(
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
                    refreshGridOfServerResource();
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

                if (e.Tool.Key == FMenuKey.MenuSrlRefresh)
                {
                    refreshGridOfServerResource();
                }
                if (e.Tool.Key == FMenuKey.MenuSrlExport)
                {
                    procMenuExport();
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

                r = (UltraGridRow)grdServer.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y)).
                    GetContext(typeof(UltraGridRow));
                if (r != null)
                {
                    grdServer.ActiveRow = grdServer.Rows[r.Index];
                }

                // --

                mnuMenu.Tools[FMenuKey.MenuInqSvrStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerStatus);
                mnuMenu.Tools[FMenuKey.MenuInqSvrHistory].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerHistory);
                // --                
                mnuMenu.Tools[FMenuKey.MenuInqSvrResourceStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerResourceStatus);               
                mnuMenu.Tools[FMenuKey.MenuInqSvrResourceHistory].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerResourceHistory);
                // --
                mnuMenu.Tools[FMenuKey.MenuInqSvrMainSwitch].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerMainSwitch);
                mnuMenu.Tools[FMenuKey.MenuInqSvrBackupSwitch].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerBackupSwitch);
                // --
                mnuMenu.Tools[FMenuKey.MenuInqSvrAdminAgentLogList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.AdminAgentLogList);
                mnuMenu.Tools[FMenuKey.MenuInqSvrAdminAgentBackupLogList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.AdminAgentBackupLogList);

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

                refreshTotal();
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

    }   // Class end
}   // Namespace end
