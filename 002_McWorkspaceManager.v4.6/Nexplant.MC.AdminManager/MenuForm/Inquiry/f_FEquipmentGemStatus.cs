/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FEquipmentGemStatus.cs
--  Creator         : mjkim
--  Create Date     : 2018.03.30
--  Description     : FAmate Admin Manager Equipment GEM Status Form Class 
--  History         : Created by mjkim at 2018.03.30
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinToolbars;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public partial class FEquipmentGemStatus : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const char KEY_SEPARATOR = (char)0x1F;

        // --

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEquipmentGemStatus(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEquipmentGemStatus(
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

        private void designGridOfEquipmentGemStatus(
           )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --
                uds.Band.Columns.Add("CEID");
                uds.Band.Columns.Add("Name");
                uds.Band.Columns.Add("RPTID");
                uds.Band.Columns.Add("VID");
                uds.Band.Columns.Add("Data Type");
                uds.Band.Columns.Add("Description");

                // --

                grdList.DisplayLayout.Bands[0].Columns["CEID"].CellAppearance.Image = Properties.Resources.SecsItemLog;
                grdList.DisplayLayout.Bands[0].Columns["RPTID"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdList.DisplayLayout.Bands[0].Columns["VID"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdList.DisplayLayout.Bands[0].Columns["Data Type"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                // --
                grdList.DisplayLayout.Bands[0].Columns["CEID"].MergedCellStyle = MergedCellStyle.Always;
                grdList.DisplayLayout.Bands[0].Columns["Name"].MergedCellStyle = MergedCellStyle.Always;
                grdList.DisplayLayout.Bands[0].Columns["RPTID"].MergedCellStyle = MergedCellStyle.Always;
                // --
                grdList.DisplayLayout.Bands[0].Columns["CEID"].MergedCellEvaluator = new FEquipmentGemStatusMergedCellEvaluator();
                grdList.DisplayLayout.Bands[0].Columns["Name"].MergedCellEvaluator = new FEquipmentGemStatusMergedCellEvaluator();
                grdList.DisplayLayout.Bands[0].Columns["RPTID"].MergedCellEvaluator = new FEquipmentGemStatusMergedCellEvaluator();
                // --
                grdList.DisplayLayout.Bands[0].Columns["CEID"].Width = 70;
                grdList.DisplayLayout.Bands[0].Columns["Name"].Width = 190;
                grdList.DisplayLayout.Bands[0].Columns["RPTID"].Width = 70;
                grdList.DisplayLayout.Bands[0].Columns["VID"].Width = 70;
                grdList.DisplayLayout.Bands[0].Columns["Data Type"].Width = 70;
                grdList.DisplayLayout.Bands[0].Columns["Description"].Width = 250;

                // --

                grdList.multiSelected = false;
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

        private void designTreeOfEquipmentGemStatus(
            )
        {
            try
            {
                tvwTree.ImageList = new ImageList();
                // --
                tvwTree.ImageList.Images.Add("CEID", Properties.Resources.SecsItemLog_List);
                tvwTree.ImageList.Images.Add("RPTID", Properties.Resources.SecsItemLog_List);
                tvwTree.ImageList.Images.Add("VID", Properties.Resources.SecsItemLog);

                // --

                tvwTree.setPopupMenu((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuEgsPopupMenuTree]);
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

                if (grdList.activeDataRow == null)
                {
                    mnuMenu.Tools[FMenuKey.MenuEgsExport].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuEgsExpand].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuEgsCollapse].SharedProps.Enabled = false;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuEgsExport].SharedProps.Enabled = true;
                    mnuMenu.Tools[FMenuKey.MenuEgsExpand].SharedProps.Enabled = true;
                    mnuMenu.Tools[FMenuKey.MenuEgsCollapse].SharedProps.Enabled = true;
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

        private void clear(
            )
        {
            try
            {
                grdList.beginUpdate();
                grdList.removeAllDataRow();
                grdList.DisplayLayout.Bands[0].SortedColumns.Clear();
                foreach(UltraGridColumn c in grdList.DisplayLayout.Bands[0].Columns)
                {
                    c.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                    c.Header.Appearance.ForeColor = Color.Black;
                }
                grdList.endUpdate();

                // --

                tvwTree.beginUpdate();
                tvwTree.Nodes.Clear();
                tvwTree.endUpdate();

                // --

                controlMenu();

                // --

                lblTotal.Text = grdList.Rows.Count.ToString("#,##0");
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        private string generateStringForObject(
            FXmlNode fXmlNode
            )
        {
            FFormat fFormat;
            StringBuilder info = null;
            string description = string.Empty;

            try
            {
                info = new StringBuilder();

                // --
                fFormat = (FFormat)Enum.Parse(typeof(FFormat), fXmlNode.get_attrVal(FADMADS_InqEquipmentGemStatus_Out.FGem.FEvent.A_Format, FADMADS_InqEquipmentGemStatus_Out.FGem.FEvent.D_Format));
                info.Append(((FFormatShortName)fFormat).ToString() + "[] ");
                // --
                info.Append(fXmlNode.get_attrVal(FADMADS_InqEquipmentGemStatus_Out.FGem.FEvent.A_Name, FADMADS_InqEquipmentGemStatus_Out.FGem.FEvent.D_Name) + "=\"");
                info.Append(fXmlNode.get_attrVal(FADMADS_InqEquipmentGemStatus_Out.FGem.FEvent.A_Id, FADMADS_InqEquipmentGemStatus_Out.FGem.FEvent.D_Id) + "\"");
                // --
                description = fXmlNode.get_attrVal(FADMADS_InqEquipmentGemStatus_Out.FGem.FEvent.A_Description);
                if (description != string.Empty)
                {
                    info.Append(" Desc=[" + description + "]");
                }

                // --

                return info.ToString(); ;
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

        private void loadTreeOfObject(
            FXmlNode fXmlNode
            )
        {
            UltraTreeNode tNodeEvt = null;
            UltraTreeNode tNodeRpt = null;
            UltraTreeNode tNodeVar = null;
            int index = 0;

            try
            {
                tvwTree.beginUpdate();
                tvwTree.Nodes.Clear();
                // --
                if (fXmlNode == null)
                {
                    tvwTree.endUpdate();
                    return;
                }

                // --

                // ***
                // CEID
                // ***
                tNodeEvt = new UltraTreeNode(index.ToString(), generateStringForObject(fXmlNode));
                tNodeEvt.Override.NodeAppearance.Image = tvwTree.ImageList.Images["CEID"];
                index++;

                // --

                // ***
                // Report
                // ***
                foreach (FXmlNode fXmlNodeRpt in fXmlNode.get_elemList(FADMADS_InqEquipmentGemStatus_Out.FGem.FEvent.FReport.E_Report))
                {
                    tNodeRpt = new UltraTreeNode(index.ToString(), generateStringForObject(fXmlNodeRpt));
                    tNodeRpt.Override.NodeAppearance.Image = tvwTree.ImageList.Images["RPTID"];
                    index++;

                    // ***
                    // SV
                    // ***
                    if (fXmlNodeRpt.fChildNodes.count > 0)
                    {
                        foreach (FXmlNode fXmlNodeVid in fXmlNodeRpt.get_elemList(FADMADS_InqEquipmentGemStatus_Out.FGem.FEvent.FReport.FVariable.E_Variable))
                        {
                            tNodeVar = new UltraTreeNode(index.ToString(), generateStringForObject(fXmlNodeVid));
                            tNodeVar.Override.NodeAppearance.Image = tvwTree.ImageList.Images["VID"];
                            index++;
                            // --
                            tNodeRpt.Nodes.Add(tNodeVar);
                        }
                    }
                    // --
                    tNodeEvt.Nodes.Add(tNodeRpt);
                }

                // --

                tNodeEvt.ExpandAll();
                tvwTree.Nodes.Add(tNodeEvt);
                tvwTree.ActiveNode = tNodeEvt;

                // --

                tvwTree.endUpdate();

                // --

                controlMenu();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------  

        private bool duplicatedEventId(
            string searchText,
            int searchIndex
            )
        {
            UltraGridCell cell = null;
            int index = 0;

            try
            {
                foreach (UltraGridRow r in grdList.Rows)
                {
                    cell = r.Cells["CEID"];
                    if (searchText == cell.Text && searchIndex != (int)cell.Tag)
                    {
                        if (index > 0)
                        {
                            return true;
                        }
                        index++;
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                cell = null;
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------  

        private bool duplicatedVId(
            string searchKey, 
            UltraGridCell[] mergedCells
            )
        {
            UltraGridCell cell = null;
            int index = 0;

            try
            {
                foreach(UltraGridCell c in mergedCells)
                {
                    cell = grdList.Rows[c.Row.Index].Cells["VID"];
                    if (searchKey == cell.Text)
                    {
                        if (index > 0)
                        {
                            return true;
                        }
                        index++;
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                cell = null;
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void refresh(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInGem = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutGem = null;
            object[] cellValues = null;
            string beforeKey = string.Empty;
            string eventId = string.Empty;
            string eventDesc = string.Empty;
            string reportId = string.Empty;
            UltraDataRow dataRow = null;
            UltraGridCell[] mergedCells = null;
            UltraGridCell cell = null;
            int index = 0;

            try
            {
                if (txtEqpName.Text.Trim() == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0004", new object[] { "Equipment" }));
                }

                // --

                beforeKey = grdList.activeDataRowKey;

                // --

                clear();

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_InqEquipmentGemStatus_In.E_ADMADS_InqEquipmentGemStatus_In);
                fXmlNodeIn.set_elemVal(FADMADS_InqEquipmentGemStatus_In.A_hLanguage, FADMADS_InqEquipmentGemStatus_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_InqEquipmentGemStatus_In.A_hFactory, FADMADS_InqEquipmentGemStatus_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_InqEquipmentGemStatus_In.A_hUserId, FADMADS_InqEquipmentGemStatus_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_InqEquipmentGemStatus_In.A_hStep, FADMADS_InqEquipmentGemStatus_In.D_hStep, "1");
                // --
                fXmlNodeInGem = fXmlNodeIn.set_elem(FADMADS_InqEquipmentGemStatus_In.FGem.E_Gem);
                fXmlNodeInGem.set_elemVal(
                    FADMADS_InqEquipmentGemStatus_In.FGem.A_EquipmentId,
                    FADMADS_InqEquipmentGemStatus_In.FGem.D_EquipmentId,
                    txtEqpName.Text
                    );

                // --

                FADMADSCaster.ADMADS_InqEquipmentGemStatus_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_InqEquipmentGemStatus_Out.A_hStatus, FADMADS_InqEquipmentGemStatus_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_InqEquipmentGemStatus_Out.A_hStatusMessage, FADMADS_InqEquipmentGemStatus_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeOutGem = fXmlNodeOut.get_elem(FADMADS_InqEquipmentGemStatus_Out.FGem.E_Gem);

                // --

                grdList.beginUpdate(false);

                // --

                for (int i = 0; i < fXmlNodeOutGem.fChildNodes.count; i++)
                {
                    FXmlNode fXmlNodeEvt = fXmlNodeOutGem.fChildNodes[i];
                    eventId = fXmlNodeEvt.get_attrVal(FADMADS_InqEquipmentGemStatus_Out.FGem.FEvent.A_Id, FADMADS_InqEquipmentGemStatus_Out.FGem.FEvent.D_Id);
                    eventDesc = fXmlNodeEvt.get_attrVal(FADMADS_InqEquipmentGemStatus_Out.FGem.FEvent.A_Description, FADMADS_InqEquipmentGemStatus_Out.FGem.FEvent.D_Description);

                    foreach (FXmlNode fXmlNodeRpt in fXmlNodeEvt.fChildNodes)
                    {
                        reportId = fXmlNodeRpt.get_attrVal(FADMADS_InqEquipmentGemStatus_Out.FGem.FEvent.FReport.A_Id, FADMADS_InqEquipmentGemStatus_Out.FGem.FEvent.FReport.D_Id);

                        if (fXmlNodeRpt.fChildNodes.count > 0)
                        {
                            foreach (FXmlNode n in fXmlNodeRpt.fChildNodes)
                            {
                                cellValues = new object[] {
                                    eventId,
                                    eventDesc,
                                    reportId,
                                    n.get_attrVal(FADMADS_InqEquipmentGemStatus_Out.FGem.FEvent.FReport.FVariable.A_Id, FADMADS_InqEquipmentGemStatus_Out.FGem.FEvent.FReport.FVariable.D_Id),
                                    n.get_attrVal(FADMADS_InqEquipmentGemStatus_Out.FGem.FEvent.FReport.FVariable.A_Format, FADMADS_InqEquipmentGemStatus_Out.FGem.FEvent.FReport.FVariable.D_Format),
                                    n.get_attrVal(FADMADS_InqEquipmentGemStatus_Out.FGem.FEvent.FReport.FVariable.A_Description, FADMADS_InqEquipmentGemStatus_Out.FGem.FEvent.FReport.FVariable.D_Description)
                                    };
                                // --
                                dataRow = grdList.appendDataRow(index.ToString(), cellValues);
                                dataRow.Tag = fXmlNodeEvt;
                                index++;

                                grdList.Rows[dataRow.Index].Cells[0].Tag = i;
                            }
                        }
                        else
                        {
                            cellValues = new object[] {
                                    eventId,
                                    eventDesc,
                                    reportId,
                                    "",
                                    "",
                                    ""
                                    };
                            // --
                            dataRow = grdList.appendDataRow(index.ToString(), cellValues);
                            dataRow.Tag = fXmlNodeEvt;
                            index++;

                            grdList.Rows[dataRow.Index].Cells[0].Tag = i;
                            grdList.Rows[dataRow.Index].Cells[0].ToolTipText = i.ToString();

                            // --

                            grdList.Rows[dataRow.Index].Cells["RPTID"].Appearance.BackColor = Color.FromArgb(255, 221, 211);
                            grdList.Rows[dataRow.Index].Cells["RPTID"].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            grdList.Rows[dataRow.Index].Cells["RPTID"].Appearance.ForeColor = Color.Red;
                            // --
                            grdList.Rows[dataRow.Index].Cells["VID"].Appearance.BackColor = Color.FromArgb(255, 221, 211);
                            grdList.Rows[dataRow.Index].Cells["Data Type"].Appearance.BackColor = Color.FromArgb(255, 221, 211);
                            grdList.Rows[dataRow.Index].Cells["Description"].Appearance.BackColor = Color.FromArgb(255, 221, 211);
                            // --
                            grdList.Rows[dataRow.Index].Cells["RPTID"].Column.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            grdList.Rows[dataRow.Index].Cells["RPTID"].Column.Header.Appearance.ForeColor = Color.Red;
                        }
                    }
                }

                // --

                foreach (UltraGridRow r in grdList.Rows)
                {
                    cell = r.Cells["CEID"];
                    if (duplicatedEventId(cell.Text, (int)cell.Tag))
                    {
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        cell.Appearance.ForeColor = Color.Red;
                        cell.Column.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        cell.Column.Header.Appearance.ForeColor = Color.Red;
                    }

                    // --
                    
                    mergedCells = r.Cells["RPTID"].GetMergedCells();
                    if (mergedCells != null)
                    {
                        cell = r.Cells["VID"];
                        if (duplicatedVId(cell.Text, mergedCells))
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                            cell.Column.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Column.Header.Appearance.ForeColor = Color.Red;
                        }
                    }
                }

                // --

                grdList.endUpdate(false);

                // --

                if (grdList.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdList.activateDataRow(beforeKey);
                    }
                    if (grdList.activeDataRow == null)
                    {
                        grdList.ActiveRow = grdList.Rows[0];
                    }
                }

                // --

                controlMenu();

                // --

                lblTotal.Text = fXmlNodeOutGem.fChildNodes.count.ToString("#,##0");

                // --

                grdList.Focus();
            }
            catch (Exception ex)
            {
                grdList.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInGem = null;
                fXmlNodeOut = null;
                fXmlNodeOutGem = null;
                dataRow = null;
                mergedCells = null;
                cell = null;
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
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_EquipmentGemStatus_" + txtEqpName.Text + ".xlsx";

                // --

                sfd = new SaveFileDialog();
                // --                
                sfd.Title = "Export Equipment GEM Status to Excel";
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
                fExcelSht = fExcelExp.addExcelSheet("Equipment GEM Status");

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
                fExcelSht.writeCondition(lblEqp.Text, txtEqpName.Text, rowIndex, 0);

                // --

                // ***
                // Event List Grid Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("DYNAMIC EVENT REPORT(CEID)") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                rowIndex = fExcelSht.writeGridGroup(grdList, rowIndex, 0);
                // --
                rowIndex += 1;
                fExcelSht.writeText("Total Count: " + lblTotal.Text, rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);

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

        private void expand(
            )
        {
            try
            {
                tvwTree.beginUpdate();

                // -- 

                tvwTree.ActiveNode.ExpandAll();

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void collapse(
            )
        {
            try
            {
                tvwTree.beginUpdate();

                // --

                tvwTree.ActiveNode.CollapseAll();

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void attach(
            string eqpName
            )
        {
            try
            {
                txtEqpName.Text = eqpName;

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

        #region FEquipmentGemStatus Form Event Handler

        private void FEquipmentGemStatus_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfEquipmentGemStatus();
                designTreeOfEquipmentGemStatus();

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

        private void FEquipmentGemStatus_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                controlMenu();

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

        private void FEquipmentGemStatus_FormClosing(
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

        private void FEquipmentGemStatus_KeyDown(
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

                if (e.Tool.Key == FMenuKey.MenuEgsRefresh)
                {
                    refresh();
                }
                else if (e.Tool.Key == FMenuKey.MenuEgsExport)
                {
                    export();
                }
                else if (e.Tool.Key == FMenuKey.MenuEgsExpand)
                {
                    expand();
                }
                else if (e.Tool.Key == FMenuKey.MenuEgsCollapse)
                {
                    collapse();
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

                if (grdList.ActiveRow == null)
                {
                    tvwTree.beginUpdate();
                    tvwTree.Nodes.Clear();
                    tvwTree.endUpdate();
                }
                else
                {
                    loadTreeOfObject((FXmlNode)grdList.activeDataRow.Tag);
                }
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
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

    }   // Class end

    //------------------------------------------------------------------------------------------------------------------------

    internal class FEquipmentGemStatusMergedCellEvaluator : IMergedCellEvaluator
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEquipmentGemStatusMergedCellEvaluator()
        {

        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public bool ShouldCellsBeMerged(
            UltraGridRow row1,
            UltraGridRow row2, 
            UltraGridColumn column
            )
        {
            // Test to make sure the Type is not DBNull since we allow the ShippedDate to be null
            if (row1.GetCellValue(column).GetType().ToString() != "System.DBNull" && row2.GetCellValue(column).GetType().ToString() != "System.DBNull")
            {
                return (
                    row1.GetCellValue(column) == row2.GetCellValue(column) &&
                    (int)row1.Cells["CEID"].Tag == (int)row2.Cells["CEID"].Tag
                    );
            }
            // --
            return false;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
