/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FSecsLibraryGemInspector.cs
--  Creator         : mjkim
--  Create Date     : 2018.05.04
--  Description     : FAMate SECS Modeler GEM Inspectory Form Class 
--  History         : Created by mjkim at 2018.05.04
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.SecsModeler
{
    public partial class FSecsLibraryGemInspector : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm, FITransaction
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string Title = "GEM Inspector";
        //--
        /// <summary>
        /// not used
        /// </summary>
        private const string Error_NotUsed = "Not used";
        /// <summary>
        /// At least one CEID link already defined
        /// </summary>
        private const string CEID_Error_Already = "At least one CEID link already defined";
        /// <summary>
        /// At least one CEID does not exist
        /// </summary>
        private const string CEID_Error_NoExists = "At least one CEID does not exist";
        /// <summary>
        /// At least one RPTID does not exists
        /// </summary>
        private const string RPTID_Error_NoExists = "At least one RPTID does not exists";
        /// <summary>
        /// At least one RPTID already defined
        /// </summary>
        private const string RPTID_Error_Already = "At least one RPTID already defined";
        /// <summary>
        /// At least one VID does not exists
        /// </summary>
        private const string VID_Error_NoExists = "At least one VID does not exists";
        /// <summary>
        /// At least one VID already defined
        /// </summary>
        private const string VID_Error_Already = "At least one VID already defined";

        // --

        private bool m_disposed = false;
        // --
        private FSsmCore m_fSsmCore = null;
        private FSecsLibrary m_fSecsLibrary = null;
        private bool m_cancel = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecsLibraryGemInspector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsLibraryGemInspector(
            FSsmCore fSsmCore
            )
            : this()
        {
            base.fUIWizard = fSsmCore.fUIWizard;
            m_fSsmCore = fSsmCore;
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
                    m_fSsmCore = null;
                    m_fSecsLibrary = null;
                }
                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public bool cancel
        {
            get
            {
                try
                {
                    return m_cancel;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_cancel = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void setTitle(
            )
        {
            try
            {
                this.Text = m_fSsmCore.fWsmCore.fUIWizard.searchCaption(Title) + " - [" + m_fSecsLibrary.name + "]";
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

        protected override void changeControlCaption(
            )
        {
            try
            {
                base.changeControlCaption();
                base.fUIWizard.changeControlCaption(mnuMenu);
                // --
                setTitle();
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

        private void designGridOfDefineReport(
            )
        {
            UltraDataSource uds = null;            

            try
            {
                uds = grdDefine.dataSource;

                // --

                uds.Band.Columns.Add("RPTID");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Result");
                uds.Band.Columns.Add("Proc. Time (ms)");
                uds.Band.Columns.Add("Message");

                // --

                uds.Band.ChildBands.Add("VID");
                uds.Band.ChildBands["VID"].Columns.Add("VID");

                // --

                grdDefine.DisplayLayout.Bands[0].Columns["RPTID"].CellAppearance.Image = Properties.Resources.Trn_Target;
                // --
                grdDefine.DisplayLayout.Bands[0].Columns["RPTID"].Width = 100;
                grdDefine.DisplayLayout.Bands[0].Columns["Description"].Width = 180;
                grdDefine.DisplayLayout.Bands[0].Columns["Result"].Width = 80;
                grdDefine.DisplayLayout.Bands[0].Columns["Proc. Time (ms)"].Width = 90;
                grdDefine.DisplayLayout.Bands[0].Columns["Proc. Time (ms)"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdDefine.DisplayLayout.Bands[0].Columns["Message"].Width = 80;
                // --
                grdDefine.DisplayLayout.Bands[0].Columns["RPTID"].Header.Fixed = true;
                //grdDefine.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.MultiBand;

                // --

                grdDefine.ImageList = new ImageList();
                // --
                grdDefine.ImageList.Images.Add("Transaction_Target", Properties.Resources.Trn_Target);
                grdDefine.ImageList.Images.Add("Transaction_Result_Success", Properties.Resources.Trn_Result_Success);
                grdDefine.ImageList.Images.Add("Transaction_Result_Fail", Properties.Resources.Trn_Result_Fail);
                grdDefine.ImageList.Images.Add("Transaction_Result_Cancel", Properties.Resources.Trn_Result_Cancel);
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

        private void designGridOfLinkEventReport(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdLink.dataSource;

                // --

                uds.Band.Columns.Add("CEID");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Result");
                uds.Band.Columns.Add("Proc. Time (ms)");
                uds.Band.Columns.Add("Message");

                // --

                uds.Band.ChildBands.Add("RPTID");
                uds.Band.ChildBands["RPTID"].Columns.Add("RPTID");

                // --

                grdLink.DisplayLayout.Bands[0].Columns["CEID"].CellAppearance.Image = Properties.Resources.Trn_Target;
                // --
                grdLink.DisplayLayout.Bands[0].Columns["CEID"].Width = 100;
                grdLink.DisplayLayout.Bands[0].Columns["Description"].Width = 180;
                grdLink.DisplayLayout.Bands[0].Columns["Result"].Width = 80;
                grdLink.DisplayLayout.Bands[0].Columns["Proc. Time (ms)"].Width = 90;
                grdLink.DisplayLayout.Bands[0].Columns["Proc. Time (ms)"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdLink.DisplayLayout.Bands[0].Columns["Message"].Width = 80;
                // --
                grdLink.DisplayLayout.Bands[0].Columns["CEID"].Header.Fixed = true;
                //grdLink.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.MultiBand;

                // --

                grdLink.ImageList = new ImageList();
                // --
                grdLink.ImageList.Images.Add("Transaction_Target", Properties.Resources.Trn_Target);
                grdLink.ImageList.Images.Add("Transaction_Result_Success", Properties.Resources.Trn_Result_Success);
                grdLink.ImageList.Images.Add("Transaction_Result_Fail", Properties.Resources.Trn_Result_Fail);
                grdLink.ImageList.Images.Add("Transaction_Result_Cancel", Properties.Resources.Trn_Result_Cancel);
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

        private Image getImageOfResult(
            string result
            )
        {
            try
            {
                if (result == "Success")
                {
                    return grdDefine.ImageList.Images["Transaction_Result_Success"];
                }
                else if (result == "Fail")
                {
                    return grdDefine.ImageList.Images["Transaction_Result_Fail"];
                }
                else if (result == "Cancel")
                {
                    return grdDefine.ImageList.Images["Transaction_Result_Cancel"];
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return grdDefine.ImageList.Images["File_Log"];
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridGemDefineReport(
            )
        {
            UltraDataRow dataRow = null;
            object[] cellValues = null;

            try
            {
                grdDefine.beginUpdate(false);

                // --

                grdDefine.removeAllDataRow();
                grdDefine.DisplayLayout.Bands[0].SortedColumns.Clear();

                // --                

                foreach (FSecsMessageList fSml in m_fSecsLibrary.fChildSecsMessageListCollection)
                {
                    foreach (FSecsMessages fSms in fSml.fChildSecsMessagesCollection)
                    {
                        if (fSms.stream != 2 || fSms.function != 33)
                        {
                            continue;
                        }
                        foreach (FSecsMessage fSmg in fSms.fChildSecsMessageCollection)
                        {
                            if (fSmg.isPrimary == false)
                            {
                                continue;
                            }
                            foreach (FSecsItem fRootSit in fSmg.fChildSecsItemCollection)
                            {
                                if (fRootSit.fFormat == FFormat.List && fRootSit.hasChild)
                                {
                                    // L[2] L
                                    foreach (FSecsItem fParentSit in fRootSit.fChildSecsItemCollection)
                                    {
                                        if (fParentSit.fFormat == FFormat.List && fParentSit.hasChild)
                                        {
                                            // L[32] L
                                            foreach (FSecsItem fSit in fParentSit.fChildSecsItemCollection)
                                            {
                                                if (fSit.fFormat == FFormat.List && fSit.hasChild)
                                                {
                                                    foreach (FSecsItem fRptSit in fSit.fChildSecsItemCollection)
                                                    {
                                                        if (fRptSit.fFormat == FFormat.List)
                                                        {
                                                            continue;
                                                        }
                                                        // --
                                                        dataRow = grdDefine.getDataRow(fRptSit.stringValue);
                                                        if (dataRow == null)
                                                        {
                                                            cellValues = new object[] {
                                                                fRptSit.stringValue,
                                                                fRptSit.description
                                                            };
                                                            dataRow = grdDefine.appendDataRow(fRptSit.stringValue, cellValues);
                                                            if (!fSms.locked)
                                                            {
                                                                grdDefine.Rows[dataRow.Index].Cells["Message"].Tag = Error_NotUsed;
                                                            }
                                                        }
                                                        else if (grdDefine.Rows[dataRow.Index].Cells["Message"].Tag == null)
                                                        {
                                                            grdDefine.Rows[dataRow.Index].Cells["Message"].Tag = RPTID_Error_Already;
                                                        }
                                                        grdDefine.Rows[dataRow.Index].Tag = fRptSit;
                                                        // --
                                                        if (fRptSit.fNextSibling != null && fRptSit.fNextSibling.fFormat == FFormat.List && fRptSit.fNextSibling.hasChild)
                                                        {
                                                            foreach (FSecsItem fSvSit in fRptSit.fNextSibling.fChildSecsItemCollection)
                                                            {
                                                                if (grdDefine.Rows[dataRow.Index].Cells["Message"].Tag == null)
                                                                { 
                                                                    foreach(UltraDataRow r in dataRow.GetChildRows("VID"))
                                                                    {
                                                                        if ((string)r["VID"] == fSvSit.stringValue)
                                                                        {
                                                                            grdDefine.Rows[dataRow.Index].Cells["Message"].Tag = VID_Error_Already;
                                                                        }
                                                                    }
                                                                    dataRow.GetChildRows("VID").Add(new object[] {fSvSit.stringValue});
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                // --

                grdDefine.endUpdate(false);
            }
            catch (Exception ex)
            {
                grdDefine.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                dataRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridGemLinkEventReport(
            )
        {
            object[] cellValues = null;
            UltraDataRow dataRow = null;

            try
            {
                grdLink.beginUpdate(false);

                // --                

                grdLink.removeAllDataRow();
                grdLink.DisplayLayout.Bands[0].SortedColumns.Clear();

                // --

                foreach (FSecsMessageList fSml in m_fSecsLibrary.fChildSecsMessageListCollection)
                {
                    foreach (FSecsMessages fSms in fSml.fChildSecsMessagesCollection)
                    {
                        if (fSms.stream != 2 || fSms.function != 35)
                        {
                            continue;
                        }
                        foreach (FSecsMessage fSmg in fSms.fChildSecsMessageCollection)
                        {
                            if (fSmg.isPrimary == false)
                            {
                                continue;
                            }
                            foreach (FSecsItem fRootSit in fSmg.fChildSecsItemCollection)
                            {
                                if (fRootSit.fFormat == FFormat.List && fRootSit.hasChild)
                                {
                                    // L[2] L
                                    foreach (FSecsItem fParentSit in fRootSit.fChildSecsItemCollection)
                                    {
                                        if (fParentSit.fFormat == FFormat.List && fParentSit.hasChild)
                                        {
                                            // L[57] L
                                            foreach (FSecsItem fSit in fParentSit.fChildSecsItemCollection)
                                            {
                                                if (fSit.fFormat == FFormat.List && fSit.hasChild)
                                                {
                                                    foreach (FSecsItem fEvtSit in fSit.fChildSecsItemCollection)
                                                    {
                                                        if (fEvtSit.fFormat != FFormat.List)
                                                        {
                                                            dataRow = grdLink.getDataRow(fEvtSit.stringValue);
                                                            if (dataRow == null)
                                                            {
                                                                cellValues = new object[] {
                                                                    fEvtSit.stringValue,
                                                                    fEvtSit.description
                                                                };
                                                                dataRow = grdLink.appendDataRow((string)cellValues[0], cellValues);
                                                                if (!fSmg.locked) 
                                                                {
                                                                    grdLink.Rows[dataRow.Index].Cells["Message"].Tag = Error_NotUsed;
                                                                }
                                                            }
                                                            else if (grdLink.Rows[dataRow.Index].Cells["Message"].Tag == null)
                                                            {
                                                                grdLink.Rows[dataRow.Index].Cells["Message"].Tag = CEID_Error_Already;
                                                            }
                                                            grdLink.Rows[dataRow.Index].Tag = fEvtSit;
                                                        }
                                                        else
                                                        {
                                                            foreach (FSecsItem fRptSit in fEvtSit.fChildSecsItemCollection)
                                                            {
                                                                if (grdLink.Rows[dataRow.Index].Cells["Message"].Tag == null)
                                                                {
                                                                    foreach (UltraDataRow r in dataRow.GetChildRows("RPTID"))
                                                                    {
                                                                        if ((string)r["RPTID"] == fRptSit.stringValue)
                                                                        {
                                                                            grdLink.Rows[dataRow.Index].Cells["Message"].Tag = RPTID_Error_Already;
                                                                        }
                                                                    }
                                                                    dataRow.GetChildRows("RPTID").Add(new object[] {fRptSit.stringValue});
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                grdLink.endUpdate(false);
            }
            catch (Exception ex)
            {
                grdLink.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                dataRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void refresh(
            FSecsLibrary fSecsLibrary
            )
        {
            try
            {
                m_fSecsLibrary = fSecsLibrary;
                setTitle();

                // --

                refreshGridGemLinkEventReport();
                refreshGridGemDefineReport();

                // --

                btnInspect.Enabled = grdDefine.Rows.Count > 0 || grdLink.Rows.Count > 0 ? true : false;
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

        public void action(
            )
        {
            string result = string.Empty;
            string msg = string.Empty;
            Stopwatch sw = null;
            int sCnt = 0;
            int fCnt = 0;
            int cCnt = 0;

            try
            {
                btnInspect.Enabled = false;
                m_cancel = false;
                sw = new Stopwatch();

                // --

                foreach (UltraGridRow r in grdLink.Rows)
                {
                    sw.Reset();
                    sw.Start();
                    // --
                    Application.DoEvents();

                    // --

                    grdLink.activateDataRow(r.Index);

                    // --

                    if (m_cancel)
                    {
                        r.Cells["CEID"].Appearance.Image = getImageOfResult("Cancel");
                        result = this.fUIWizard.searchCaption("Cancel");
                        msg = this.fUIWizard.generateMessage("M0011");
                        cCnt++;
                    }
                    else if(r.Cells["Message"].Tag != null || r.ChildBands[0].Rows.Count <= 0)
                    {
                        r.Cells["CEID"].Appearance.Image = getImageOfResult("Fail");
                        result = this.fUIWizard.searchCaption("Fail");
                        msg = r.Cells["Message"].Tag == null ? RPTID_Error_NoExists : (string)r.Cells["Message"].Tag;
                        fCnt++;
                    }
                    else
                    {
                        r.Cells["CEID"].Appearance.Image = getImageOfResult("Success");
                        result = this.fUIWizard.searchCaption("Success");
                        msg = "";// this.fUIWizard.generateMessage("M0012");
                        sCnt++;
                    }

                    // --

                    sw.Stop();

                    // --

                    r.Cells["Result"].Value = result;
                    r.Cells["Proc. Time (ms)"].Value = sw.ElapsedMilliseconds.ToString();
                    r.Cells["Message"].Value = msg;
                }

                // --

                foreach (UltraGridRow r in grdDefine.Rows)
                {
                    sw.Reset();
                    sw.Start();
                    // --
                    Application.DoEvents();

                    // --

                    grdDefine.activateDataRow(r.Index);

                    // --

                    if (m_cancel)
                    {
                        r.Cells["RPTID"].Appearance.Image = getImageOfResult("Cancel");
                        result = this.fUIWizard.searchCaption("Cancel");
                        msg = this.fUIWizard.generateMessage("M0011");
                        cCnt++;
                    }
                    else if (r.Cells["Message"].Tag != null || r.ChildBands[0].Rows.Count <= 0)
                    {
                        r.Cells["RPTID"].Appearance.Image = getImageOfResult("Fail");
                        result = this.fUIWizard.searchCaption("Fail");
                        msg = r.Cells["Message"].Tag == null ? VID_Error_NoExists : (string)r.Cells["Message"].Tag;
                        fCnt++;
                    }
                    else if (grdLink.searchGridRow(grdDefine.activeDataRowKey) == false)
                    {
                        r.Cells["RPTID"].Appearance.Image = getImageOfResult("Fail");
                        result = this.fUIWizard.searchCaption("Fail");
                        msg = CEID_Error_NoExists;
                        fCnt++;
                    }
                    else
                    {
                        r.Cells["RPTID"].Appearance.Image = getImageOfResult("Success");
                        result = this.fUIWizard.searchCaption("Success");
                        msg = "";// this.fUIWizard.generateMessage("M0012");
                        sCnt++;
                    }

                    // --

                    sw.Stop();

                    // --

                    r.Cells["Result"].Value = result;
                    r.Cells["Proc. Time (ms)"].Value = sw.ElapsedMilliseconds.ToString();
                    r.Cells["Message"].Value = msg;
                }

                // --

                lblSuccess.Text = sCnt.ToString();
                lblFail.Text = fCnt.ToString();
                lblCancel.Text = cCnt.ToString();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FSecsLibraryGemInspector Form Event Handler

        private void FSecsLibraryGemInspector_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfDefineReport();
                designGridOfLinkEventReport();

                // --

                btnInspect.Enabled = false;

                // --

                m_fSsmCore.fOption.fChildFormList.add(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FSecsLibraryGemInspector_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();
                
                // --

                grdDefine.Focus();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FSecsLibraryGemInspector_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fSsmCore.fOption.fChildFormList.remove(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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

                if (e.Tool.Key == "Refresh")
                {
                    refresh(m_fSecsLibrary);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

        #region btnInspect Control Event Handler

        private void btnInspect_Click(
            object sender, 
            EventArgs e
            )
        {
            FTransactionProgress fPrgDialog = null;

            try
            {
                FCursor.waitCursor();

                // --

                fPrgDialog = new FTransactionProgress(
                    m_fSsmCore,
                    this,
                    this.fUIWizard.generateMessage("M0010", new object[] { "Start" })
                    );
                fPrgDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                if (fPrgDialog != null)
                {
                    fPrgDialog.Dispose();
                    fPrgDialog = null;
                }

                // --

                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region grdDefine Control Event Handler

        private void grdDefine_DoubleClickRow(
            object sender, 
            DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fSsmCore.fSsmContainer.gotoRelation((FIObject)e.Row.Tag);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region grdLink Control Event Handler

        private void grdLink_DoubleClickRow(
            object sender, 
            DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fSsmCore.fSsmContainer.gotoRelation((FIObject)e.Row.Tag);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
