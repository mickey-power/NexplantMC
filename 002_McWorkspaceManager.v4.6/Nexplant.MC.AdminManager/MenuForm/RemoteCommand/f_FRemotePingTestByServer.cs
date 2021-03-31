/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FRemotePingTestByServer.cs
--  Creator         : baehyun seo
--  Create Date     : 2013.02.25
--  Description     : FAMate Admin Manager Remote Command - Remote Ping Test By Server Form Class 
--  History         : Created by baehyun seo at 2013.02.25
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Nexplant.MC.AdminManager
{
    public partial class FRemotePingTestByServer : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm, FIRemoteCommand
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;        
        private bool m_cancel = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FRemotePingTestByServer(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FRemotePingTestByServer(
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

        private void designGridOfServer(
            )
        {
            UltraDataSource uds = null;            

            try
            {
                uds = grdList.dataSource;

                // --

                uds.Band.Columns.Add("Server");
                uds.Band.Columns.Add("Result");
                uds.Band.Columns.Add("Proc. Time (ms)");
                uds.Band.Columns.Add("Message");                
                                
                // --

                grdList.DisplayLayout.Bands[0].Columns["Server"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["Result"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Proc. Time (ms)"].Width = 90;
                grdList.DisplayLayout.Bands[0].Columns["Proc. Time (ms)"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdList.DisplayLayout.Bands[0].Columns["Message"].Width = 80;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Server"].Header.Fixed = true;
                
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

        public void attach(
            string[] serverList
            )
        {
            object[] cellValues = null;
            int index = 0;

            try
            {
                grdList.beginUpdate(false);

                // --

                procMenuClear();

                // --

                foreach (string server in serverList)
                {
                    cellValues = new object[] {
                        server,
                        string.Empty
                        };
                    index = grdList.appendOrUpdateDataRow(server, cellValues).Index;
                    grdList.Rows[index].Cells["Server"].Appearance.Image = grdList.ImageList.Images["Transaction_Target"];
                }

                // --

                grdList.endUpdate(false);

                // --

                if (grdList.activeDataRow == null)
                {
                    grdList.ActiveRow = grdList.Rows[0];
                }
                btnPing.Enabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.RemotePingTestByServer);
                btnClear.Enabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.RemotePingTestByServer);

                // --

                txtRemoteIp.Focus();
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

        private void procMenuAttach(
            )
        {
            FServerSelector fDialog = null;

            try
            {
                fDialog = new FServerSelector(m_fAdmCore);
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                attach(fDialog.selectedServerList);
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
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
                    btnPing.Enabled = false;
                    btnClear.Enabled = false;
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
                btnPing.Enabled = false;
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

        private void procMenuReset(
            )
        {
            try
            {
                grdList.beginUpdate();

                // --

                foreach (UltraDataRow r in grdList.dataSource.Rows)
                {
                    r["Result"] = string.Empty;
                    r["Proc. Time (ms)"] = string.Empty;
                    r["Proc. Time (ms)"] = string.Empty;
                    r["Message"] = string.Empty;
                }

                // --

                grdList.endUpdate();

                // --

                lblSuccess.Text = "0";
                lblFail.Text = "0";
                lblCancel.Text = "0";
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
            FXmlNode fXmlNodeInSvd = null;
            FXmlNode fXmlNodeOut = null;
            string server = null;
            string remoteIp = string.Empty;
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
                btnPing.Enabled = false;
                m_cancel = false;
                sw = new Stopwatch();

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_RcmRemotePingTest_In.E_ADMADS_RcmRemotePingTest_In);
                fXmlNodeIn.set_elemVal(FADMADS_RcmRemotePingTest_In.A_hLanguage, FADMADS_RcmRemotePingTest_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_RcmRemotePingTest_In.A_hStep, FADMADS_RcmRemotePingTest_In.D_hStep, "1");
                fXmlNodeIn.set_elemVal(FADMADS_RcmRemotePingTest_In.A_hFactory, FADMADS_RcmRemotePingTest_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_RcmRemotePingTest_In.A_hUserId, FADMADS_RcmRemotePingTest_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_RcmRemotePingTest_In.A_hHostIp, FADMADS_RcmRemotePingTest_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_RcmRemotePingTest_In.A_hHostName, FADMADS_RcmRemotePingTest_In.D_hHostName, m_fAdmCore.fOption.hostName);
                // --
                fXmlNodeInSvd = fXmlNodeIn.set_elem(FADMADS_RcmRemotePingTest_In.FServerData.E_ServerData);

                // --

                foreach (UltraDataRow r in grdList.dataSource.Rows)
                {
                    sw.Reset();
                    sw.Start();
                    // --
                    Application.DoEvents();

                    // --

                    remoteIp = txtRemoteIp.Text;
                    server = grdList.getDataRowKey(r.Index);

                    if (m_cancel)
                    {
                        grdList.Rows[r.Index].Cells["Server"].Appearance.Image = getImageOfCommandResult("Cancel");
                        result = this.fUIWizard.searchCaption("Cancel");
                        msg = this.fUIWizard.generateMessage("M0011");
                        // --
                        cCnt++;
                    }
                    else
                    {
                        fXmlNodeInSvd.set_elemVal(
                            FADMADS_RcmRemotePingTest_In.FServerData.A_ServerName,
                            FADMADS_RcmRemotePingTest_In.FServerData.D_ServerName,
                            server
                            );
                        // --
                        fXmlNodeInSvd.set_elemVal(
                            FADMADS_RcmRemotePingTest_In.FServerData.A_RemoteIp,
                            FADMADS_RcmRemotePingTest_In.FServerData.D_RemoteIp,
                            remoteIp
                            );

                        // --

                        try
                        {
                            FADMADSCaster.ADMADS_RcmRemotePingTest_Req(
                                m_fAdmCore.fH101,
                                fXmlNodeIn,
                                ref fXmlNodeOut
                                );

                            if (fXmlNodeOut.get_elemVal(FADMADS_RcmRemotePingTest_Out.A_hStatus, FADMADS_RcmRemotePingTest_Out.D_hStatus) != "0")
                            {
                                grdList.Rows[r.Index].Cells["Server"].Appearance.Image = getImageOfCommandResult("Fail");
                                result = this.fUIWizard.searchCaption("Fail");
                                msg = fXmlNodeOut.get_elemVal(FADMADS_RcmRemotePingTest_Out.A_hStatusMessage, FADMADS_RcmRemotePingTest_Out.D_hStatusMessage);
                                // --
                                fCnt++;
                            }
                            else
                            {
                                grdList.Rows[r.Index].Cells["Server"].Appearance.Image = getImageOfCommandResult("Success");
                                result = this.fUIWizard.searchCaption("Success");
                                msg = this.fUIWizard.generateMessage("M0012");
                                // --
                                sCnt++;
                            }
                        }
                        catch (Exception ex)
                        {
                            grdList.Rows[r.Index].Cells["Server"].Appearance.Image = getImageOfCommandResult("Fail");
                            result = this.fUIWizard.searchCaption("Fail");
                            msg = ex.Message;
                            // --
                            fCnt++;
                            
                        }
                    }

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
                sw = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------   

        private Image getImageOfCommandResult(
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
            return grdList.ImageList.Images["File_Log"];
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FRemotePingTestByServer Form Event Handler

        private void FRemotePingTestByServer_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfServer();

                // --

                btnPing.Enabled = false;
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

        private void FRemotePingTestByServer_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                txtRemoteIp.Focus();
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

        private void FRemotePingTestByServer_FormClosing(
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

        #region btnPing Control Event Handler

        private void btnPing_Click(
            object sender,
            EventArgs e
            )
        {
            FRemoteCommandProgress fPrgDialog = null;

            try
            {
                FCursor.waitCursor();

                // --

                #region Validation

                if (txtRemoteIp.Text.Trim() == string.Empty)
                {
                    txtRemoteIp.Focus();
                    FDebug.throwFException(fUIWizard.generateMessage("E0004", new object[] {"Remote IP"}));
                }

                #endregion

                // --

                procMenuReset();

                // --

                fPrgDialog = new FRemoteCommandProgress(
                    m_fAdmCore,
                    this,
                    this.fUIWizard.generateMessage("M0010", new object[] { "Request" })
                    );
                fPrgDialog.ShowDialog();

                // --

                mnuMenu.Tools["Attach"].SharedProps.Enabled = true;
                mnuMenu.Tools["Detach"].SharedProps.Enabled = true;
                btnPing.Enabled = true;
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

        #region btnClear Control Event Handler

        private void btnClear_Click(
            object sender,
            EventArgs e
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

                txtRemoteIp.Text = string.Empty;

                // --
                
                lblSuccess.Text = "0";
                lblFail.Text = "0";
                lblCancel.Text = "0";

                // --

                mnuMenu.Tools["Attach"].SharedProps.Enabled = true;
                mnuMenu.Tools["Detach"].SharedProps.Enabled = true;
                btnPing.Enabled = false;
                btnClear.Enabled = false;
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
