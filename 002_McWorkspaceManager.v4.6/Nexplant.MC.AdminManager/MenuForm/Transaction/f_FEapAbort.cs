/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FEapAbort.cs
--  Creator         : mjkim
--  Create Date     : 2012.05.04
--  Description     : FAMate Admin Manager Transaction - EAP Abort Form Class 
--  History         : Created by mjkim at 2012.05.04
                      Modified by spike.lee at 2012.06.11
                        - 기능 구현
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public partial class FEapAbort : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm, FITransaction
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_tranEnabled = false;
        private bool m_cancel = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEapAbort(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEapAbort(
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

        private void setTitle(
            )
        {
            try
            {
                this.Text = m_fAdmCore.fWsmCore.fUIWizard.searchCaption(this.Text);
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

        private void designGridOfEap(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --
                uds.Band.Columns.Add("EAP");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Result");
                uds.Band.Columns.Add("Proc. Time (ms)");
                uds.Band.Columns.Add("Message");

                // --

                grdList.DisplayLayout.Bands[0].Columns["EAP"].CellAppearance.Image = Properties.Resources.Eap;
                grdList.DisplayLayout.Bands[0].Columns["Proc. Time (ms)"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                // --
                grdList.DisplayLayout.Bands[0].Columns["EAP"].Header.Fixed = true;
                // --
                grdList.DisplayLayout.Bands[0].Columns["EAP"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["Description"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["Result"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Proc. Time (ms)"].Width = 90;
                grdList.DisplayLayout.Bands[0].Columns["Message"].Width = 80;

                // --

                grdList.ImageList = new ImageList();
                // --
                grdList.ImageList.Images.Add("Transaction_Target", Properties.Resources.Trn_Target);
                grdList.ImageList.Images.Add("Transaction_Result_Success", Properties.Resources.Trn_Result_Success);
                grdList.ImageList.Images.Add("Transaction_Result_Fail", Properties.Resources.Trn_Result_Fail);
                grdList.ImageList.Images.Add("Transaction_Result_Cancel", Properties.Resources.Trn_Result_Cancel);
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

        public void attach(
            string[] eapList,
            string[] eapDescList
            )
        {
            object[] cellValues = null;
            int index = 0;

            try
            {
                grdList.beginUpdate(false);

                // --

                if (mnuMenu.Tools["Attach"].SharedProps.Enabled == false)
                {
                    procMenuClear();
                }

                // --

                for (int i = 0; i < eapList.Length; i++)
                {
                    cellValues = new object[] {
                        eapList[i],
                        eapDescList[i]
                        };
                    index = grdList.appendOrUpdateDataRow(eapList[i], cellValues).Index;
                    grdList.Rows[index].Cells["EAP"].Appearance.Image = grdList.ImageList.Images["Transaction_Target"];
                }

                // --

                grdList.endUpdate(false);

                // --

                if (grdList.activeDataRow == null)
                {
                    grdList.ActiveRow = grdList.Rows[0];
                }

                // --

                btnAbort.Enabled = m_tranEnabled;

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
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuAttach(
            )
        {
            FEapClassSelector fEapSelector = null;

            try
            {
                fEapSelector = new FEapClassSelector(m_fAdmCore, FEapAttrCategory.Applied, FEapType.Process.ToString());
                if (fEapSelector.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                attach(fEapSelector.selectedEapList, fEapSelector.selectedEapDescList);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fEapSelector != null)
                {
                    fEapSelector.Dispose();
                    fEapSelector = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuDetach(
            )
        {
            try
            {
                if (grdList.Rows.Count == 0)
                {
                    return;
                }

                // --

                grdList.beginUpdate();

                // --

                grdList.removeDataRows(grdList.selectedDataRowKeys);

                // --

                grdList.endUpdate();

                // --

                if (grdList.Rows.Count == 0)
                {
                    btnAbort.Enabled = false;
                }
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

        private void procMenuClear(
            )
        {
            try
            {
                grdList.beginUpdate();

                // --

                grdList.removeAllDataRow();

                // --

                grdList.endUpdate();

                // --

                lblSuccess.Text = "0";
                lblFail.Text = "0";
                lblCancel.Text = "0";

                // --

                mnuMenu.Tools["Attach"].SharedProps.Enabled = true;
                mnuMenu.Tools["Detach"].SharedProps.Enabled = true;
                btnAbort.Enabled = false;
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
            int cCnt = 0;

            try
            {
                mnuMenu.Tools["Attach"].SharedProps.Enabled = false;
                mnuMenu.Tools["Detach"].SharedProps.Enabled = false;
                btnAbort.Enabled = false;
                m_cancel = false;
                sw = new Stopwatch();

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TrnEapAbort_In.E_ADMADS_TrnEapAbort_In);
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapAbort_In.A_hLanguage, FADMADS_TrnEapAbort_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapAbort_In.A_hStep, FADMADS_TrnEapAbort_In.D_hStep, "1");
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapAbort_In.A_hFactory, FADMADS_TrnEapAbort_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapAbort_In.A_hUserId, FADMADS_TrnEapAbort_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapAbort_In.A_hHostIp, FADMADS_TrnEapAbort_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapAbort_In.A_hHostName, FADMADS_TrnEapAbort_In.D_hHostName, m_fAdmCore.fOption.hostName);
                // --
                fXmlNodeInEap = fXmlNodeIn.set_elem(FADMADS_TrnEapAbort_In.FEap.E_Eap);

                // --

                foreach (UltraDataRow r in grdList.dataSource.Rows)
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

                    if (m_cancel)
                    {
                        grdList.Rows[r.Index].Cells["EAP"].Appearance.Image = getImageOfEap("Cancel");
                        result = this.fUIWizard.searchCaption("Cancel");
                        msg = this.fUIWizard.generateMessage("M0011");
                        cCnt++;
                    }
                    else
                    {
                        fXmlNodeInEap.set_elemVal(
                            FADMADS_TrnEapAbort_In.FEap.A_Name, 
                            FADMADS_TrnEapAbort_In.FEap.D_Name, 
                            eap
                            );

                        // --

                        try
                        {
                            FADMADSCaster.ADMADS_TrnEapAbort_Req(
                                m_fAdmCore.fH101,
                                fXmlNodeIn,
                                ref fXmlNodeOut
                                );

                            if (fXmlNodeOut.get_elemVal(FADMADS_TrnEapAbort_Out.A_hStatus, FADMADS_TrnEapAbort_Out.D_hStatus) != "0")
                            {
                                grdList.Rows[r.Index].Cells["EAP"].Appearance.Image = getImageOfEap("Fail");
                                result = this.fUIWizard.searchCaption("Fail");
                                msg = fXmlNodeOut.get_elemVal(FADMADS_TrnEapAbort_Out.A_hStatusMessage, FADMADS_TrnEapAbort_Out.D_hStatusMessage);
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

                    r["Result"] = result;
                    r["Proc. Time (ms)"] = sw.ElapsedMilliseconds.ToString();
                    r["Message"] = msg;
                }

                // --

                lblSuccess.Text = sCnt.ToString();
                lblFail.Text = fCnt.ToString();
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

                eapList = grdList.selectedDataRowKeys;
                eapDescList = new string[eapList.Length];
                // --
                for (int i = 0; i < eapList.Length; i++)
                {
                    eapDescList[i] = grdList.getDataRow(eapList[i])["Description"].ToString();
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

                eapList = grdList.selectedDataRowKeys;
                eapDescList = new string[eapList.Length];
                // --
                for (int i = 0; i < eapList.Length; i++)
                {
                    eapDescList[i] = grdList.getDataRow(eapList[i])["Description"].ToString();
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

                eapList = grdList.selectedDataRowKeys;
                eapDescList = new string[eapList.Length];
                // --
                for (int i = 0; i < eapList.Length; i++)
                {
                    eapDescList[i] = grdList.getDataRow(eapList[i])["Description"].ToString();
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

                eapList = grdList.selectedDataRowKeys;
                eapDescList = new string[eapList.Length];
                // --
                for (int i = 0; i < eapList.Length; i++)
                {
                    eapDescList[i] = grdList.getDataRow(eapList[i])["Description"].ToString();
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FEapAbort Form Event Handler

        private void FEapAbort_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_tranEnabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.EapAbort);

                // --

                designGridOfEap();

                // --

                btnAbort.Enabled = false;

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

        private void FEapAbort_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                grdList.Focus();
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

        private void FEapAbort_FormClosing(
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

                if (e.Tool.Key == "Attach")
                {
                    procMenuAttach();
                }
                else if (e.Tool.Key == "Detach")
                {
                    procMenuDetach();
                }
                else if (e.Tool.Key == "Clear")
                {
                    procMenuClear();
                }
                else if (e.Tool.Key == FMenuKey.MenuTrnEapRelease)
                {
                    procMenuEapRelease();
                }
                else if (e.Tool.Key == FMenuKey.MenuTrnEapStart)
                {
                    procMenuEapStart();
                }
                else if (e.Tool.Key == FMenuKey.MenuTrnEapStop)
                {
                    procMenuEapStop();
                }
                else if (e.Tool.Key == FMenuKey.MenuTrnEapReload)
                {
                    procMenuEapReload();
                }
                else if (e.Tool.Key == FMenuKey.MenuTrnEapRestart)
                {
                    procMenuEapRestart();
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

        #region btnAbort Control Event Handler

        private void btnAbort_Click(
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
                    this.fUIWizard.generateMessage("M0010", new object[] { "Abort" })
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

        #region grdList Control Event Handler
                
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
                mnuMenu.Tools[FMenuKey.MenuTrnEapStart].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapStart);
                mnuMenu.Tools[FMenuKey.MenuTrnEapStop].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapStop);
                mnuMenu.Tools[FMenuKey.MenuTrnEapReload].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapReload);
                mnuMenu.Tools[FMenuKey.MenuTrnEapRestart].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapRestart);

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
