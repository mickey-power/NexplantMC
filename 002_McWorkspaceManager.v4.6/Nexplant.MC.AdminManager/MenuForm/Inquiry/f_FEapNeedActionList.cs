/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FEapNeedActionList.cs
--  Creator         : mjkim
--  Create Date     : 2014.03.12
--  Description     : FAMate Admin Manager EAP Need Action List Form Class 
--  History         : Created by mjkim at 2014.03.12
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinTree;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public partial class FEapNeedActionList : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEapNeedActionList(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEapNeedActionList(
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
                uds = ucbNeedAction.dataSource;
                // --
                uds.Band.Columns.Add("Action");

                // --

                ucbNeedAction.Appearance.Image = Properties.Resources.EapAttrCategory;
                // --
                ucbNeedAction.DisplayLayout.Bands[0].Columns["Action"].CellAppearance.Image = Properties.Resources.EapAttrCategory;
                ucbNeedAction.DisplayLayout.Bands[0].Columns["Action"].Width = ucbNeedAction.Width - 2;
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
                grdEap.DisplayLayout.Bands[0].Columns["Reload Count"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
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
                grdEap.ImageList.Images.Add("Eap_Secs", Properties.Resources.Eap_Secs);
                grdEap.ImageList.Images.Add("Eap_Plc", Properties.Resources.Eap_Plc);
                grdEap.ImageList.Images.Add("Eap_Opc", Properties.Resources.Eap_Opc);
                grdEap.ImageList.Images.Add("Eap_Tcp", Properties.Resources.Eap_Tcp);
                grdEap.ImageList.Images.Add("Eap_Process", Properties.Resources.Eap_Process);
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
                // ***
                // EAP List Clear
                // ***
                grdEap.beginUpdate();
                grdEap.removeAllDataRow();
                grdEap.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdEap.endUpdate();

                // --

                refreshTotal();
            }
            catch (Exception ex)
            {
                grdEap.endUpdate();
                // --
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void refreshComboOfNeedAction(
             )
        {
            try
            {
                ucbNeedAction.beginUpdate(false);
                ucbNeedAction.removeAllDataRow();

                // --

                foreach (string s in Enum.GetNames(typeof(FEapNeedAction)))
                {
                    ucbNeedAction.appendDataRow(s, new object[] { s });
                }

                // --

                ucbNeedAction.endUpdate(false);

                // --

                ucbNeedAction.Text = FEapNeedAction.Release.ToString();
            }
            catch (Exception ex)
            {
                ucbNeedAction.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {

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
                beforeKey = this.activeEap;
                // --
                grdEap.beginUpdate(false);
                grdEap.removeAllDataRow();
                grdEap.DisplayLayout.Bands[0].SortedColumns.Clear();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("need_action", ucbNeedAction.activeDataRowKey);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "EapNeedActionList", "ListEap", fSqlParams, false, ref nextRowNumber);
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

                        cellValues = new object[] {
                            r[0].ToString(),   // Eap
                            r[1].ToString(),   // Description     
                            r[33].ToString(),  // RPM Count (2017.06.07 by spike.lee add)
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

                refreshTotal();

                // --

                grdEap.Focus();
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

        private void refreshTotal(
            )
        {
            try
            {
                lblTotal.Text = grdEap.Rows.Count.ToString("#,##0");
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
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_McNeedActionList.xlsx";

                // --

                sfd = new SaveFileDialog();
                // --
                sfd.Title = "Export MC Need Action List to Excel";
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
                fExcelSht = fExcelExp.addExcelSheet("EAP Need Action List");

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
                fExcelSht.writeCondition(lblNeedAction.Text, ucbNeedAction.Text, rowIndex, 0);

                // --

                // ***
                // EAP List Grid Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("EAP Need Action List") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
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
            {   fEapRelease = (FEapRelease)m_fAdmCore.fAdmContainer.getChild(typeof(FEapRelease));
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FEapNeedActionList Form Event Handler

        private void FEapNeedActionList_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designComboOfCategory();
                designGridOfEap();

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

        private void FEapNeedActionList_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshComboOfNeedAction();

                // --

                ucbNeedAction.Focus();
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

        private void FEapNeedActionList_FormClosing(
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

        private void FEapNeedActionList_KeyDown(
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
                    refreshGridOfEap();
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

                if (e.Tool.Key == FMenuKey.MenuEnlRefresh)
                {
                    refreshGridOfEap();
                }
                else if (e.Tool.Key == FMenuKey.MenuEnlExport)
                {
                    procMenuExport();
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

        #region ucbNeedAction Control Event Handler

        private void ucbNeedAction_ValueChanged(
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

        #region grdEap Control Event Handler

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

                if (grdEap.ActiveRow != null)
                {
                    operMode = grdEap.activeDataRow["Operation Mode"].ToString();

                    // --

                    if (operMode == FEapOperationMode.Client.ToString())
                    {
                        mnuMenu.Tools[FMenuKey.MenuInqEapStart].SharedProps.Enabled = false;
                    }
                }

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
