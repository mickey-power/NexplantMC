/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FEapBatchModification.cs
--  Creator         : mjkim
--  Create Date     : 2013.02.06
--  Description     : FAMate Admin Manager Transaction - MC Batch Modification Form Class 
--  History         : Created by mjkim at 2012.02.06
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public partial class FEapBatchModification : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm, FITransaction
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_tranEnabled = false;
        private bool m_cancel = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEapBatchModification(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEapBatchModification(
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

        private void clear(
            )
        {
            try
            {
                grdList.beginUpdate();
                grdList.removeAllDataRow();
                grdList.endUpdate();

                // --

                lblSuccess.Text = "0";
                lblFail.Text = "0";
                lblSkip.Text = "0";
                lblCancel.Text = "0";

                // --

                btnSearch.Enabled = true;
                btnUpdate.Enabled = false;
                btnClear.Enabled = false;
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
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
                uds = grdList.dataSource;

                // --

                uds.Band.Columns.Add("Check", typeof(bool));
                uds.Band.Columns.Add("EAP");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Equipment Type");
                uds.Band.Columns.Add("Equipment Area");
                uds.Band.Columns.Add("Equipment Line");
                uds.Band.Columns.Add("Package");
                uds.Band.Columns.Add("Model");
                uds.Band.Columns.Add("Component");
                uds.Band.Columns.Add("Result");
                uds.Band.Columns.Add("Proc. Time (ms)");
                uds.Band.Columns.Add("Message");

                // --

                grdList.DisplayLayout.Bands[0].Columns["Check"].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                grdList.DisplayLayout.Bands[0].Columns["EAP"].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                grdList.DisplayLayout.Bands[0].Columns["Description"].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                grdList.DisplayLayout.Bands[0].Columns["Package"].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                grdList.DisplayLayout.Bands[0].Columns["Model"].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                grdList.DisplayLayout.Bands[0].Columns["Component"].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                grdList.DisplayLayout.Bands[0].Columns["Result"].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                grdList.DisplayLayout.Bands[0].Columns["Proc. Time (ms)"].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                grdList.DisplayLayout.Bands[0].Columns["Message"].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                // --
                grdList.DisplayLayout.Bands[0].Columns["EAP"].CellAppearance.Image = Properties.Resources.Eap;
                grdList.DisplayLayout.Bands[0].Columns["Proc. Time (ms)"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                // --
                grdList.DisplayLayout.Bands[0].Columns["EAP"].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
                grdList.DisplayLayout.Bands[0].Columns["Description"].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
                grdList.DisplayLayout.Bands[0].Columns["Equipment Type"].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
                grdList.DisplayLayout.Bands[0].Columns["Equipment Area"].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
                grdList.DisplayLayout.Bands[0].Columns["Equipment Line"].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
                grdList.DisplayLayout.Bands[0].Columns["Package"].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
                grdList.DisplayLayout.Bands[0].Columns["Model"].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
                grdList.DisplayLayout.Bands[0].Columns["Component"].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
                grdList.DisplayLayout.Bands[0].Columns["Result"].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
                grdList.DisplayLayout.Bands[0].Columns["Proc. Time (ms)"].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
                grdList.DisplayLayout.Bands[0].Columns["Message"].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Equipment Type"].FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains;
                grdList.DisplayLayout.Bands[0].Columns["Equipment Area"].FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains;
                grdList.DisplayLayout.Bands[0].Columns["Equipment LIne"].FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = string.Empty;
                grdList.DisplayLayout.Bands[0].Columns["Check"].Header.CheckBoxVisibility = Infragistics.Win.UltraWinGrid.HeaderCheckBoxVisibility.Always;
                grdList.DisplayLayout.Bands[0].Columns["Check"].Header.Fixed = true;
                grdList.DisplayLayout.Bands[0].Columns["EAP"].Header.Fixed = true;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Check"].Width = 22;
                grdList.DisplayLayout.Bands[0].Columns["EAP"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["Description"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["Package"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["Model"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["Component"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["Result"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Proc. Time (ms)"].Width = 90;
                grdList.DisplayLayout.Bands[0].Columns["Message"].Width = 80;
                
                // --

                grdList.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                grdList.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
                grdList.DisplayLayout.Override.FilterUIProvider = this.grdFilter;

                // --

                grdList.ImageList = new ImageList();
                // --
                grdList.ImageList.Images.Add("Transaction_Target", Properties.Resources.Trn_Target);
                grdList.ImageList.Images.Add("Transaction_Result_Success", Properties.Resources.Trn_Result_Success);
                grdList.ImageList.Images.Add("Transaction_Result_Fail", Properties.Resources.Trn_Result_Fail);
                grdList.ImageList.Images.Add("Transaction_Result_Cancel", Properties.Resources.Trn_Result_Cancel);
                grdList.ImageList.Images.Add("Transaction_Result_Skip", Properties.Resources.Trn_Result_Skip);
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

        private Image getImageOfEap(
            string result
            )
        {
            try
            {
                if (result == "Success")
                {
                    return grdList.ImageList.Images["Transaction_Result_Success"];
                }
                else if (result == "Fail")
                {
                    return grdList.ImageList.Images["Transaction_Result_Fail"];
                }
                else if (result == "Cancel")
                {
                    return grdList.ImageList.Images["Transaction_Result_Cancel"];
                }
                else if (result == "Skip")
                {
                    return grdList.ImageList.Images["Transaction_Result_Skip"];
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return grdList.ImageList.Images["File_Log"];
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfEap(
            )
        {
            StateEditorButton sp = null;
            StateEditorButton sm = null;
            StateEditorButton sc = null;
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            UltraDataRow row = null;
            object[] cellValues = null;
            int nextRowNumber = 0;
            string package = string.Empty;
            string model = string.Empty;
            string component = string.Empty;
            string searchString = string.Empty;

            try
            {
                sp = (StateEditorButton)txtNewPackage.ButtonsLeft["Enabled"];
                sm = (StateEditorButton)txtNewModel.ButtonsLeft["Enabled"];
                sc = (StateEditorButton)txtNewComponent.ButtonsLeft["Enabled"];

                // --

                #region Validation

                if (!sp.Checked && !sm.Checked && !sc.Checked)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0020"));
                }

                // --

                if (sp.Checked && txtNewPackage.Text == string.Empty)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0025", new object[] { "Package" }));
                }

                // --

                if (sm.Checked && txtNewModel.Text == string.Empty)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0025", new object[] { "Model" }));
                }

                // --

                if (sc.Checked && txtNewComponent.Text == string.Empty)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0025", new object[] { "Component" }));
                }

                #endregion

                // --

                btnUpdate.Enabled = false;
                btnClear.Enabled = false;

                // --

                grdList.beginUpdate(false);
                grdList.removeAllDataRow();
                grdList.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
                grdList.DisplayLayout.Bands[0].SortedColumns.Clear();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("package1", txtPackage.Text, txtPackage.Text == string.Empty ? true : false);
                fSqlParams.add("model1", txtModel.Text, txtModel.Text == string.Empty ? true : false);
                fSqlParams.add("component1", txtComponent.Text, txtComponent.Text == string.Empty ? true : false);
                fSqlParams.add("package", txtNewPackage.Text, sp.Checked ? false : true);
                fSqlParams.add("pkg_ver", txtNewPkgVer.Text, sp.Checked ? false : true);
                fSqlParams.add("model", txtNewModel.Text, sm.Checked ? false : true);
                fSqlParams.add("mdl_ver", txtNewMdlVer.Text, sm.Checked ? false : true);
                fSqlParams.add("component", txtNewComponent.Text, sc.Checked ? false : true);
                fSqlParams.add("com_ver", txtNewComVer.Text, sc.Checked ? false : true);

                // --

                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Transaction", "EapBatchModification", "SearchEap", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        package = FCommon.generateStringForPackage(r["PACKAGE"].ToString(), r["PKG_VER"].ToString());
                        model = FCommon.generateStringForModel(r["MODEL"].ToString(), r["MDL_VER"].ToString());
                        component = FCommon.generateStringForComponent(r["USED_COM"].ToString(), r["COMPONENT"].ToString(), r["COM_VER"].ToString());

                        // --

                        row = grdList.getDataRow(r["EAP"].ToString());
                        if (row == null)
                        {
                            cellValues = new object[] {
                                true,
                                r["EAP"].ToString(),
                                r["EAP_DESC"].ToString(), 
                                r["TYPE"].ToString(), 
                                r["AREA"].ToString(), 
                                r["LINE"].ToString(), 
                                package, 
                                model,
                                component
                                };
                            grdList.appendDataRow((string)cellValues[1], cellValues);
                        }
                        else
                        {
                            if (!grdList.Rows.GetRowWithListIndex(row.Index).Cells["Equipment Type"].Text.Contains(r["TYPE"].ToString()))
                            {
                                grdList.Rows.GetRowWithListIndex(row.Index).Cells["Equipment Type"].Value += ", " + r["TYPE"].ToString();
                            }
                            // --
                            if (!grdList.Rows.GetRowWithListIndex(row.Index).Cells["Equipment Area"].Text.Contains(r["AREA"].ToString()))
                            {
                                grdList.Rows.GetRowWithListIndex(row.Index).Cells["Equipment Area"].Value += ", " + r["AREA"].ToString();
                            }
                            // --
                            if (!grdList.Rows.GetRowWithListIndex(row.Index).Cells["Equipment Line"].Text.Contains(r["LINE"].ToString()))
                            {
                                grdList.Rows.GetRowWithListIndex(row.Index).Cells["Equipment Line"].Value += ", " + r["LINE"].ToString();
                            }
                        }
                    }
                } while (nextRowNumber >= 0);

                // --

                grdList.endUpdate(false);

                //--

                if (grdList.Rows.Count != 0)
                {
                    if (grdList.activeDataRow == null)
                    {
                        grdList.ActiveRow = grdList.Rows[0];
                    }

                    // --

                    btnUpdate.Enabled = m_tranEnabled;
                    btnClear.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                grdList.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                sp = null;
                sm = null;
                sc = null;
                fSqlParams = null;
                dt = null;
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void showPackageVerSelector(
            )
        {
            FPackageVersionSelector fDialog = null;

            try
            {
                fDialog = new FPackageVersionSelector(m_fAdmCore, txtNewPackage.Text, txtNewPkgVer.Text);
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                txtNewPackage.Text = fDialog.selectedPackage;
                txtNewPkgVer.Text = fDialog.selectedPackageVer;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fDialog != null)
                {
                    fDialog.Dispose();
                    fDialog = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void showModelVerSelector(
            )
        {
            FModelVersionSelector fDialog = null;

            try
            {
                fDialog = new FModelVersionSelector(m_fAdmCore, txtNewModel.Text, txtNewMdlVer.Text);
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                txtNewModel.Text = fDialog.selectedModel;
                txtNewMdlVer.Text = fDialog.selectedModelVer;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fDialog != null)
                {
                    fDialog.Dispose();
                    fDialog = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void showComponentVerSelector(
            )
        {
            FComponentVersionSelector fDialog = null;

            try
            {
                fDialog = new FComponentVersionSelector(m_fAdmCore, txtNewPackage.Text, txtNewComVer.Text);
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                txtNewComponent.Text = fDialog.selectedComponent;
                txtNewComVer.Text = fDialog.selectedComponentVer;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fDialog != null)
                {
                    fDialog.Dispose();
                    fDialog = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void action(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInEap = null;
            FXmlNode fXmlNodeOut = null;
            string eap = string.Empty;
            string result = string.Empty;
            string msg = string.Empty;
            Stopwatch sw = null;
            int sCnt = 0;
            int fCnt = 0;
            int kCnt = 0;
            int cCnt = 0;

            try
            {
                btnSearch.Enabled = false;
                btnUpdate.Enabled = false;
                m_cancel = false;
                sw = new Stopwatch();

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TrnEapBatchModification_In.E_ADMADS_TrnEapBatchModification_In);
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapBatchModification_In.A_hLanguage, FADMADS_TrnEapBatchModification_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapBatchModification_In.A_hStep, FADMADS_TrnEapBatchModification_In.D_hStep, "1");
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapBatchModification_In.A_hFactory, FADMADS_TrnEapBatchModification_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapBatchModification_In.A_hUserId, FADMADS_TrnEapBatchModification_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapBatchModification_In.A_hHostIp, FADMADS_TrnEapBatchModification_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapBatchModification_In.A_hHostName, FADMADS_TrnEapBatchModification_In.D_hHostName, m_fAdmCore.fOption.hostName);
                // --
                fXmlNodeInEap = fXmlNodeIn.set_elem(FADMADS_TrnEapBatchModification_In.FEap.E_Eap);

                // --

                foreach (UltraGridRow r in grdList.Rows)
                {
                    sw.Reset();
                    sw.Start();
                    // --
                    Application.DoEvents();

                    // --

                    eap = grdList.getDataRowKey(r.Index);

                    // --

                    grdList.activateDataRow(eap);

                    // --

                    if (r.VisibleIndex < 0 || !Convert.ToBoolean(r.Cells["Check"].Value))
                    {
                        grdList.Rows[r.Index].Cells["EAP"].Appearance.Image = getImageOfEap("Skip");
                        result = this.fUIWizard.searchCaption("Skip");
                        msg = this.fUIWizard.generateMessage("M0015");
                        kCnt++;
                    }
                    else if (m_cancel)
                    {
                        grdList.Rows[r.Index].Cells["EAP"].Appearance.Image = getImageOfEap("Cancel");
                        result = this.fUIWizard.searchCaption("Cancel");
                        msg = this.fUIWizard.generateMessage("M0011");
                        cCnt++;
                    }
                    else
                    {
                        fXmlNodeInEap.set_elemVal(FADMADS_TrnEapBatchModification_In.FEap.A_Name, FADMADS_TrnEapBatchModification_In.FEap.D_Name, eap);
                        if (((StateEditorButton)txtNewPackage.ButtonsLeft["Enabled"]).Checked)
                        {
                            fXmlNodeInEap.set_elemVal(FADMADS_TrnEapBatchModification_In.FEap.A_Package, FADMADS_TrnEapBatchModification_In.FEap.D_Package, txtNewPackage.Text);
                            fXmlNodeInEap.set_elemVal(FADMADS_TrnEapBatchModification_In.FEap.A_PackageVer, FADMADS_TrnEapBatchModification_In.FEap.D_PackageVer, txtNewPkgVer.Text);
                        }
                        if (((StateEditorButton)txtNewModel.ButtonsLeft["Enabled"]).Checked)
                        {
                            fXmlNodeInEap.set_elemVal(FADMADS_TrnEapBatchModification_In.FEap.A_Model, FADMADS_TrnEapBatchModification_In.FEap.D_Model, txtNewModel.Text);
                            fXmlNodeInEap.set_elemVal(FADMADS_TrnEapBatchModification_In.FEap.A_ModelVer, FADMADS_TrnEapBatchModification_In.FEap.D_ModelVer, txtNewMdlVer.Text);
                        }
                        if (((StateEditorButton)txtNewComponent.ButtonsLeft["Enabled"]).Checked)
                        {
                            fXmlNodeInEap.set_elemVal(FADMADS_TrnEapBatchModification_In.FEap.A_Component, FADMADS_TrnEapBatchModification_In.FEap.D_Component, txtNewComponent.Text);
                            fXmlNodeInEap.set_elemVal(FADMADS_TrnEapBatchModification_In.FEap.A_ComponentVer, FADMADS_TrnEapBatchModification_In.FEap.D_ComponentVer, txtNewComVer.Text);
                        }

                        // --

                        try
                        {
                            FADMADSCaster.ADMADS_TrnEapBatchModification_Req(
                                m_fAdmCore.fH101,
                                fXmlNodeIn,
                                ref fXmlNodeOut
                                );

                            if (fXmlNodeOut.get_elemVal(FADMADS_TrnEapBatchModification_Out.A_hStatus, FADMADS_TrnEapBatchModification_Out.D_hStatus) != "0")
                            {
                                grdList.Rows[r.Index].Cells["EAP"].Appearance.Image = getImageOfEap("Fail");
                                result = this.fUIWizard.searchCaption("Fail");
                                msg = fXmlNodeOut.get_elemVal(FADMADS_TrnEapBatchModification_Out.A_hStatusMessage, FADMADS_TrnEapBatchModification_Out.D_hStatusMessage);
                                fCnt++;
                            }
                            else
                            {
                                grdList.Rows[r.Index].Cells["EAP"].Appearance.Image = getImageOfEap("Success");
                                result = this.fUIWizard.searchCaption("Success");
                                msg = this.fUIWizard.generateMessage("M0012");
                                sCnt++;
                            }
                        }
                        catch (Exception ex)
                        {
                            grdList.Rows[r.Index].Cells["EAP"].Appearance.Image = getImageOfEap("Fail");
                            result = this.fUIWizard.searchCaption("Fail");
                            msg = ex.Message;
                            fCnt++;
                        }
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
                lblSkip.Text = kCnt.ToString();
                lblCancel.Text = cCnt.ToString();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
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

                eapList = grdList.selectedDataRowKeys;
                eapDescList = new string[eapList.Length];
                // --
                for (int i = 0; i < eapList.Length; i++)
                {
                    eapDescList[i] = grdList.getDataRow(eapList[i])["Description"].ToString();
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FEapBatchModification Form Event Handler

        private void FEapBatchModification_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_tranEnabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.EapBatchModification);

                // --

                designGridOfEap();

                // --

                txtNewPkgVer.ButtonsRight["List"].Enabled = false;
                txtNewMdlVer.ButtonsRight["List"].Enabled = false;
                txtNewComVer.ButtonsRight["List"].Enabled = false;

                // --

                btnUpdate.Enabled = false;
                btnClear.Enabled = false;

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

        private void FEapBatchModification_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                txtPackage.Focus();
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

        private void FEapBatchModification_FormClosing(
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region txtPackage Control Event Handler

        private void txtPackage_EditorButtonClick(
            object sender,
            EditorButtonEventArgs e
            )
        {
            FPackageSelector fDialog = null;

            try
            {
                FCursor.waitCursor();

                // --

                fDialog = new FPackageSelector(m_fAdmCore, txtPackage.Text);
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                txtPackage.Tag = fDialog.selectedVersion;
                txtPackage.Text = fDialog.selectedPackage;
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

        private void txtPackage_ValueChanged(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                txtNewPackage.Text = txtPackage.Text;
                txtNewPkgVer.Text = txtPackage.Tag.ToString();

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

        #region txtModel Control Event Handler

        private void txtModel_EditorButtonClick(
            object sender,
            EditorButtonEventArgs e
            )
        {
            FModelSelector fDialog = null;

            try
            {
                FCursor.waitCursor();

                // --

                fDialog = new FModelSelector(m_fAdmCore, txtModel.Text);
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                txtModel.Tag = fDialog.selectedVersion;
                txtModel.Text = fDialog.selectedModel;
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

        private void txtModel_ValueChanged(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                txtNewModel.Text = txtModel.Text;
                txtNewMdlVer.Text = txtModel.Tag.ToString();

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

        #region txtComponent Control Event Handler

        private void txtComponent_EditorButtonClick(
            object sender,
            EditorButtonEventArgs e
            )
        {
            FComponentSelector fDialog = null;

            try
            {
                FCursor.waitCursor();

                // --

                fDialog = new FComponentSelector(m_fAdmCore, txtComponent.Text);
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                txtComponent.Tag = fDialog.selectedVersion;
                txtComponent.Text = fDialog.selectedComponent;
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

        private void txtComponent_ValueChanged(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                txtNewComponent.Text = txtComponent.Text;
                txtNewComVer.Text = txtComponent.Tag.ToString();

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

        #region TextBox Common Control Event Handler

        private void txtCommon_LeftButtonAfterCheckStateChanged(
            object sender,
            EditorButtonEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (sender == txtNewPackage)
                {
                    ((EditorButton)txtNewPkgVer.ButtonsRight["List"]).Enabled = 
                        ((StateEditorButton)e.Button).CheckState == CheckState.Checked ? true : false;
                }
                else if (sender == txtNewModel)
                {
                    ((EditorButton)txtNewMdlVer.ButtonsRight["List"]).Enabled = 
                        ((StateEditorButton)e.Button).CheckState == CheckState.Checked ? true : false;
                }
                else if (sender == txtNewComponent)
                {
                    ((EditorButton)txtNewComVer.ButtonsRight["List"]).Enabled = 
                        ((StateEditorButton)e.Button).CheckState == CheckState.Checked ? true : false;
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

        private void txtCommon_RightButtonClick(
            object sender,
            EditorButtonEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --                

                if (sender == txtNewPkgVer)
                {
                    showPackageVerSelector();
                }
                else if (sender == txtNewMdlVer)
                {
                    showModelVerSelector();
                }
                else if (sender == txtNewComVer)
                {
                    showComponentVerSelector();
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

        #region btnSearch Control Event Handler

        private void btnSearch_Click(
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnUpdate Control Event Handler

        private void btnUpdate_Click(
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
                    m_fAdmCore,
                    this,
                    this.fUIWizard.generateMessage("M0010", new object[] { "Update" })
                    );
                fPrgDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
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

        #region btnClear Control Event Handler

        private void btnClear_Click(
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

                if (e.Tool.Key == "EAP Release")
                {
                    procMenuEapRelease();
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

        #region  grdList Control Event Handler

        private void grdList_AfterRowFilterChanged(
            object sender, 
            AfterRowFilterChangedEventArgs e
            )
        {
            string toolTipText = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                e.Column.Header.ToolTipText = e.NewColumnFilter.ToString();
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

        private void grdList_MouseDown(
            object sender, 
            MouseEventArgs e
            )
        {
            UltraGridRow r = null;

            try
            {
                FCursor.waitCursor();

                // --

                if (e.Button != MouseButtons.Right || grdList.Rows.Count == 0)
                {
                    return;
                }

                // --

                r = (UltraGridRow)grdList.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y)).
                    GetContext(typeof(UltraGridRow));
                if (r != null)
                {
                    grdList.ActiveRow = grdList.Rows[r.Index];
                }

                // --

                mnuMenu.Tools[FMenuKey.MenuTrnEapRelease].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapRelease);

                // --

                mnuMenu.ShowPopup(FMenuKey.MenuTrnPopupMenu);
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

        private void grdList_KeyDown(
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
                    grdList.Selected.Rows.AddRange((UltraGridRow[])grdList.Rows.All);
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
