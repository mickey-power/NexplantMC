/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FServerHistory.cs
--  Creator         : mjkim
--  Create Date     : 2013.01.16
--  Description     : FAMate Admin Manager Server History Form Class 
--  History         : Created by mjkim at 2013.01.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ComponentModel;
using System.Windows.Forms;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager
{
    public partial class FServerHistory : Nexplant.MC.Core.FaUIs.FBaseTabChildForm, FIInquiry
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        // --
        private FInquiryProgress m_fInqProgress = null;
        private DataTable m_dtFsyssvrhis = null;
        private DataTable m_dtFsyssvrevt = null;
        private List<string[]> m_lstReqTimes = null;
        private string m_beforeKey = string.Empty;  

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FServerHistory(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FServerHistory(
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
                    m_dtFsyssvrhis = null;
                    m_dtFsyssvrevt = null;
                    m_lstReqTimes = null;
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

        private void designGridOfHistory(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --
                uds.Band.Columns.Add("Time");
                uds.Band.Columns.Add("Server");
                uds.Band.Columns.Add("Event");
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
                for (int i = 1; i <= 20; i++)
                {
                    uds.Band.Columns.Add("Header " + i.ToString());
                    uds.Band.Columns.Add("Data " + i.ToString());
                }    
                uds.Band.Columns.Add("Comment");

                // --

                grdList.DisplayLayout.Bands[0].Columns["Time"].CellAppearance.Image = Properties.Resources.History;

                // --

                grdList.DisplayLayout.Bands[0].Columns["Time"].Header.Fixed = true;
                grdList.DisplayLayout.Bands[0].Columns["Server"].Header.Fixed = true;
                grdList.DisplayLayout.Bands[0].Columns["Event"].Header.Fixed = true;

                // --

                grdList.DisplayLayout.Bands[0].Columns["Time"].Width = 174;
                grdList.DisplayLayout.Bands[0].Columns["Server"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["Event"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["Server Type"].Width = 90;
                grdList.DisplayLayout.Bands[0].Columns["Up/Down"].Width = 60;
                grdList.DisplayLayout.Bands[0].Columns["Status"].Width = 60;
                grdList.DisplayLayout.Bands[0].Columns["Agent"].Width = 60;
                grdList.DisplayLayout.Bands[0].Columns["Server IP"].Width = 110;
                grdList.DisplayLayout.Bands[0].Columns["Used Backup"].Width = 90;
                grdList.DisplayLayout.Bands[0].Columns["Backup Mode"].Width = 70;
                grdList.DisplayLayout.Bands[0].Columns["Backup Server"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["B.Server Up/Down"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["B.Server Status"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["B.Server Agent"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["OPC Server Monitoring"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["OPC Server"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["User ID"].Width = 100;
                for (int i = 1; i <= 20; i++)
                {
                    grdList.DisplayLayout.Bands[0].Columns["Header " + i.ToString()].Width = 100;
                    grdList.DisplayLayout.Bands[0].Columns["Header " + i.ToString()].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    // --
                    grdList.DisplayLayout.Bands[0].Columns["Data " + i.ToString()].Width = 100;
                }
                grdList.DisplayLayout.Bands[0].Columns["Comment"].Width = 200;

                // --

                grdList.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                grdList.DisplayLayout.Override.FilterUIProvider = this.grdFilter;
                grdList.DisplayLayout.Override.TipStyleCell = TipStyle.Show;

                // --

                grdList.DisplayLayout.Bands[0].Columns["Server"].Hidden = true;
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

        private void clear(
            )
        {
            try
            {
                #region Init Data Table

                if (m_dtFsyssvrhis == null)
                {
                    m_dtFsyssvrhis = new DataTable();
                    foreach (string clmName in new string[] { "TRAN_TIME", "HIST_SEQ", "SERVER", "EVENT_ID", "SVR_TYPE", "SVR_IP", "UP_DOWN", "STATUS", "ADA_UP_DOWN", "B_USED", "B_MODE", "B_SERVER", "B_UP_DOWN", "B_STATUS", "B_ADA_UP_DOWN", "OPC_SVR_MON", "OPC_SVR_UP_DOWN", "TRAN_USER_ID" })
                    {
                        // ***
                        // 2017.04.04 by spike.lee
                        // HIST_SEQ Sort를 숫자형으로 적용하도록 수정
                        // ***
                        if (clmName == "HIST_SEQ")
                        {
                            m_dtFsyssvrhis.Columns.Add(clmName, typeof(UInt64));
                        }
                        else
                        {
                            m_dtFsyssvrhis.Columns.Add(clmName, typeof(string));
                        }
                    }
                    // --
                    for (int i = 1; i <= 20; i++)
                    {
                        foreach (string clmName in new string[] { "EVT_H", "EVT_D" })
                        {
                            m_dtFsyssvrhis.Columns.Add(string.Format("{0}_{1}", clmName, i.ToString()), typeof(string));
                        }
                    }
                    // --
                    m_dtFsyssvrhis.Columns.Add("TRAN_COMMENT", typeof(string));
                }
                m_dtFsyssvrhis.Rows.Clear();

                // --

                if (m_dtFsyssvrevt == null)
                {
                    m_dtFsyssvrevt = new DataTable();
                    foreach (string clmName in new string[] { "EVENT_ID", "EVENT_DESC", "ISS_EVENT" })
                    {
                        m_dtFsyssvrevt.Columns.Add(clmName, typeof(string));
                    }
                }
                m_dtFsyssvrevt.Rows.Clear();

                #endregion
                
                // --

                initPropOfServerHistory();

                // --

                grdList.beginUpdate();
                grdList.removeAllDataRow();
                grdList.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdList.endUpdate();

                // --

                refreshTotal();
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                // --
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void validationInputCondition(
            )
        {
            FSqlParams fSqlParams = null;
            string fromDateTime = string.Empty;
            string toDateTime = string.Empty;

            try
            {
                // ***
                // Date Time Validation
                // ***
                udtToTime.DateTime = udtToTime.ReadOnly ? DateTime.Now : udtToTime.DateTime;
                // --
                fromDateTime = udtFromTime.DateTime.ToString("yyyyMMddHHmmss000");
                toDateTime = udtToTime.DateTime.ToString("yyyyMMddHHmmss999");

                // --

                if (FCommon.convertStringToDateTime(toDateTime).Subtract(FCommon.convertStringToDateTime(fromDateTime)).TotalMilliseconds < 0)
                {
                    if (udtToTime.ReadOnly)
                    {
                        udtFromTime.Focus();
                    }
                    else
                    {
                        udtToTime.Focus();
                    }
                    // --
                    FDebug.throwFException(fUIWizard.generateMessage("E0015", new object[] { "Start and End Time" }));
                }

                // --

                // ***
                // Server Validation
                // ***
                if (txtSvrName.Text.Trim() == string.Empty)
                {
                    txtSvrName.Focus();
                    FDebug.throwFException(fUIWizard.generateMessage("E0004", new object[] { "Server" }));
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("server", txtSvrName.Text);
                // --
                using (DataTable dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ServerHistory", "HasServer", fSqlParams, false))
                {
                    if (dt.Rows.Count == 0)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0010", new object[] { "Server" }));
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        public void attach(
            string serverName
            )
        {
            try
            {
                txtSvrName.Text = serverName;

                // --

                procMenuRefresh();

                // --

                udtFromTime.Focus();
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

        private void initPropOfServerHistory(
            )
        {
            try
            {
                pgdProp.selectedObject = new FPropServerHistory(m_fAdmCore, pgdProp);
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

        public void request(
            )
        {
            try
            {
                if (bwRequest.IsBusy)
                {
                    return;
                }

                // --

                bwRequest.RunWorkerAsync();
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

        private void doCollect(
            BackgroundWorker worker
            )
        {
            FSqlParams fSqlParams = null;
            int nextRowNumber = 0;
            int procCount = 0;

            try
            {
                // ***
                // 시작 보고
                // ***
                worker.ReportProgress(0);

                // --

                // ***
                // Search Server Events Definition
                // ***
                nextRowNumber = 0;
                // --
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    using (DataTable dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Common", "EventSearch", "SearchServerEventAll", fSqlParams, false, ref nextRowNumber))
                    {
                        dt.AsEnumerable().Take(dt.Rows.Count).CopyToDataTable(m_dtFsyssvrevt, LoadOption.OverwriteChanges);
                    }
                }
                while (nextRowNumber >= 0);
                
                // --

                // ***
                // Search Sever Events
                // ***
                foreach (string[] reqTimes in m_lstReqTimes)
                {
                    if (worker.CancellationPending)
                    {
                        break;
                    }

                    // --

                    procCount++;
                    nextRowNumber = 0;
                    // --
                    fSqlParams = new FSqlParams();
                    fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                    fSqlParams.add("server", txtSvrName.Text);
                    fSqlParams.add("tran_from_time", reqTimes[0]);
                    fSqlParams.add("tran_to_time", reqTimes[1]);
                    // --
                    do
                    {
                        using (DataTable dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ServerHistory", "SearchServerHistory", fSqlParams, false, ref nextRowNumber))
                        {
                            dt.AsEnumerable().Take(dt.Rows.Count).CopyToDataTable(m_dtFsyssvrhis, LoadOption.OverwriteChanges);                            
                        }
                        // --
                        worker.ReportProgress(procCount);
                    }
                    while (nextRowNumber >= 0);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void refreshGridOfHistory(
             )
        {
            object[] cellValues = null;
            int rowIndex = 0;
            bool validDataField = false;
            string header = string.Empty;
            string data = string.Empty;

            try
            {
                grdList.beginUpdate(false);

                // --

                m_dtFsyssvrhis.DefaultView.Sort = "HIST_SEQ ASC";
                foreach (DataRow r in m_dtFsyssvrhis.DefaultView.ToTable().Rows)
                {
                    validDataField = true;
                    for (int i = 1; i <= 20; i++)
                    {
                        header = r["EVT_H_" + i.ToString()].ToString();
                        data = r["EVT_D_" + i.ToString()].ToString();
                        // --
                        if (header == string.Empty)
                        {
                            break;
                        }
                        if (data == string.Empty)
                        {
                            validDataField = false;
                            break;
                        }
                    }

                    // --

                    cellValues = new object[] {
                        FDataConvert.defaultDataTimeFormating(r["TRAN_TIME"].ToString()),
                        r["SERVER"].ToString(),
                        r["EVENT_ID"].ToString(),
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
                        r["TRAN_COMMENT"].ToString()
                        };
                    // --
                    rowIndex = grdList.appendDataRow(generateKey(new string[] { r["SERVER"].ToString(), r["HIST_SEQ"].ToString() }), cellValues).Index;
                    grdList.Rows[rowIndex].Tag = r;

                    //-- 

                    m_dtFsyssvrevt.DefaultView.RowFilter = string.Format("EVENT_ID = '{0}'", r["EVENT_ID"].ToString());
                    if (m_dtFsyssvrevt.DefaultView.ToTable().Rows.Count > 0)
                    {
                        grdList.Rows[rowIndex].Cells["Event"].ToolTipText = m_dtFsyssvrevt.DefaultView.ToTable().Rows[0]["EVENT_DESC"].ToString();
                        // --
                        if (m_dtFsyssvrevt.DefaultView.ToTable().Rows[0]["ISS_EVENT"].ToString() == FYesNo.Yes.ToString())
                        {
                            grdList.Rows[rowIndex].Appearance.BackColor = Color.FromArgb(255, 221, 211);
                        }
                    }
                    // --
                    if (!validDataField)
                    {
                        grdList.Rows[rowIndex].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    }
                }

                // --

                grdList.endUpdate(false);

                // --

                if (grdList.Rows.Count > 0)
                {
                    if (m_beforeKey != string.Empty)
                    {
                        grdList.activateDataRow(m_beforeKey);
                    }
                    if (grdList.activeDataRow == null)
                    {
                        grdList.ActiveRow = grdList.Rows[grdList.Rows.Count - 1];
                    }
                }
            }
            catch (Exception ex)
            {
                grdList.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                refreshTotal();
                // --
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void refreshTotal(
            )
        {
            try
            {
                lblTotal.Text = grdList.Rows.VisibleRowCount.ToString("#,##0") + " / " + grdList.Rows.Count.ToString("#,##0");
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

        private void procMenuRefresh(
            )
        {
            try
            {
                m_beforeKey = grdList.activeDataRowKey;

                // --

                clear();

                // --

                validationInputCondition();

                // --

                m_lstReqTimes = FCommon.generateRequestTimes(
                    FCommon.convertStringToDateTime(udtFromTime.DateTime.ToString("yyyyMMddHHmmss000")),
                    FCommon.convertStringToDateTime(udtToTime.DateTime.ToString("yyyyMMddHHmmss999"))
                    );

                // --

                m_fInqProgress.ReqCount = m_lstReqTimes.Count;
                m_fInqProgress.StartPosition = FormStartPosition.CenterParent;
                m_fInqProgress.ShowDialog(this);
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
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_ServerHistory_" + (txtSvrName.Text == string.Empty ? "All" : txtSvrName.Text) + ".xlsx";

                // --

                sfd = new SaveFileDialog();
                // --
                sfd.Title = "Export Server History to Excel";
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
                fExcelSht = fExcelExp.addExcelSheet("Server History");

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
                rowIndex = 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Input Condition") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                fExcelSht.writeCondition(lblFromTime.Text, udtFromTime.Text, rowIndex, 0);
                fExcelSht.writeCondition(lblToTime.Text, udtToTime.Text, rowIndex, 2);
                fExcelSht.writeCondition(lblServer.Text, txtSvrName.Text, rowIndex, 4);

                // --

                // ***
                // Server History Grid Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Server History") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                rowIndex = fExcelSht.writeGrid(grdList, rowIndex, 0);
                // --
                rowIndex += 1;
                fExcelSht.writeText("Total Count: " + grdList.Rows.Count.ToString(), rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                                
                // --

                // ***
                // Create Time Write
                // ***
                rowIndex += 2;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------        

        #region FServerHistory Form Event Handler

        private void FServerHistory_Load(
            object sender,
            EventArgs e
            )
        {
            DateTime dateTime;

            try
            {
                FCursor.waitCursor();

                // --

                dateTime = DateTime.Now;
                // --
                udtFromTime.DateTime = DateTime.Parse(dateTime.AddDays(-m_fAdmCore.fOption.historySearchPeriod).ToString("yyyy-MM-dd") + " 00:00:00.000");
                udtToTime.DateTime = dateTime;
                ((StateEditorButton)udtToTime.ButtonsLeft[0]).Checked = false;

                // --

                m_fInqProgress = new FInquiryProgress(m_fAdmCore, this);
                m_fInqProgress.Canceled += new EventHandler<EventArgs>(fInqProgress_Canceled);

                // --

                designGridOfHistory();
                initPropOfServerHistory();

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

        private void FServerHistory_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                udtFromTime.Focus();
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

        private void FServerHistory_Enter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();
                
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

        private void FServerHistory_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fInqProgress != null)
                {
                    m_fInqProgress.Canceled -= new EventHandler<EventArgs>(fInqProgress_Canceled);
                    // --
                    m_fInqProgress.Dispose();
                    m_fInqProgress = null;
                }

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

        private void FServerHistory_KeyDown(
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
                    procMenuRefresh();
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

                if (e.Tool.Key == FMenuKey.MenuSvhRefresh)
                {
                    procMenuRefresh();
                }
                else if (e.Tool.Key == FMenuKey.MenuSvhExport)
                {
                    procMenuExport();
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

        #region udtFromTime Control Event Handler

        private void udtFromTime_ValueChanged(
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

        #region udtToTime Control Event Handler

        private void udtToTime_AfterEditorButtonCheckStateChanged(
            object sender,
            Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (((StateEditorButton)e.Button).Checked)
                {
                    udtToTime.ReadOnly = false;
                    // --
                    udtToTime.Appearance.BackColor = Color.White;
                    udtToTime.Appearance.ForeColor = Color.Black;
                    // --
                    udtToTime.ButtonsLeft[0].Appearance.BorderColor = Color.White;
                    udtToTime.ButtonsLeft[0].Appearance.BackColor = Color.White;
                    // --
                    udtToTime.ButtonAppearance.BorderColor = Color.White;
                    udtToTime.ButtonAppearance.BackColor = Color.White;
                    // --
                    udtToTime.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59.999");
                }
                else
                {
                    udtToTime.ReadOnly = true;
                    // --
                    udtToTime.Appearance.BackColor = Color.WhiteSmoke;
                    udtToTime.Appearance.ForeColor = SystemColors.ControlDarkDark;
                    // --
                    udtToTime.ButtonsLeft[0].Appearance.BorderColor = Color.WhiteSmoke;
                    udtToTime.ButtonsLeft[0].Appearance.BackColor = Color.WhiteSmoke;
                    // --
                    udtToTime.ButtonAppearance.BorderColor = Color.WhiteSmoke;
                    udtToTime.ButtonAppearance.BackColor = Color.WhiteSmoke;
                    udtToTime.ButtonAppearance.BackColorDisabled = Color.WhiteSmoke;
                    udtToTime.ButtonAppearance.ForeColorDisabled = Color.DimGray;
                    // --
                    udtToTime.Value = DateTime.Now;
                }

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

        //------------------------------------------------------------------------------------------------------------------------

        private void udtToTime_ValueChanged(
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

        #region txtSvrName Control Event Handler

        private void txtSvrName_EditorButtonClick(
            object sender,
            EditorButtonEventArgs e
            )
        {
            FServerSelector fDialog = null;

            try
            {
                FCursor.waitCursor();

                // --

                fDialog = new FServerSelector(m_fAdmCore, "", txtSvrName.Text, "");
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                txtSvrName.Text = fDialog.selectedServer;
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

        private void txtSvrName_ValueChanged(
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

                pgdProp.selectedObject = new FPropServerHistory(m_fAdmCore, pgdProp, (DataRow)grdList.ActiveRow.Tag);
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
   
        private void grdList_AfterRowFilterChanged(
            object sender, 
            AfterRowFilterChangedEventArgs e
            )
        {
            int activateIndex = -1;

            try
            {
                FCursor.waitCursor();

                // --

                initPropOfServerHistory();
                if (e.Rows.VisibleRowCount == 0)
                {
                    return;
                }

                // --

                grdList.beginUpdate();

                // --

                grdList.Selected.Rows.Clear();
                foreach (UltraGridRow r in e.Rows.GetFilteredInNonGroupByRows())
                {
                    if (r == grdList.ActiveRow)
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
                grdList.ActiveRow = e.Rows.GetRowAtVisibleIndex(activateIndex);
                grdList.DisplayLayout.RowScrollRegions[0].ScrollRowIntoView(grdList.ActiveRow);

                // --

                grdList.endUpdate();

                // --

                refreshTotal();
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
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

        #region fInqProgress Control Event Handler

        private void fInqProgress_Canceled(
            object sender,
            EventArgs e
            )
        {
            try
            {
                if (bwRequest.WorkerSupportsCancellation)
                {
                    bwRequest.CancelAsync();
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region bwRequest Control Event Handler

        private void bwRequest_DoWork(
            object sender,
            DoWorkEventArgs e
            )
        {
            try
            {
                doCollect((BackgroundWorker)sender);
            }
            catch (Exception ex)
            {
                this.Invoke(
                    new Action(() => { FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer); })
                    );
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void bwRequest_ProgressChanged(
            object sender,
            ProgressChangedEventArgs e
            )
        {
            try
            {
                if (!bwRequest.CancellationPending)
                {
                    m_fInqProgress.changedProgress(e.ProgressPercentage, m_dtFsyssvrhis.Rows.Count);
                }
            }
            catch (Exception ex)
            {
                if (bwRequest.WorkerSupportsCancellation)
                {
                    bwRequest.CancelAsync();
                }
                // -
                this.Invoke(
                    new Action(() => { FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer); })
                    );
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void bwRequest_RunWorkerCompleted(
            object sender,
            RunWorkerCompletedEventArgs e
            )
        {
            try
            {
                m_fInqProgress.Close();

                // --

                if (e.Error != null)
                {
                    throw e.Error;
                }

                // --

                refreshGridOfHistory();
            }
            catch (Exception ex)
            {
                this.Invoke(
                    new Action(() => { FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer); })
                    );
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
