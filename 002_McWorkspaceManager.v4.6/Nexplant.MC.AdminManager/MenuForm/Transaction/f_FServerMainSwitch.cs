/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FServerMainSwitch.cs
--  Creator         : spike.lee
--  Create Date     : 2013.02.07
--  Description     : FAMate Admin Manager Transaction - Server Main Switch Class 
--  History         : Created by spike.lee at 2013.02.07
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Nexplant.MC.AdminManager
{
    public partial class FServerMainSwitch : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm, FITransaction
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_tranEnabled = false;
        private bool m_cancel = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FServerMainSwitch(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FServerMainSwitch(
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
                uds.Band.Columns.Add("Result");
                uds.Band.Columns.Add("Proc. Time (ms)");
                uds.Band.Columns.Add("Message");

                // --

                grdList.DisplayLayout.Bands[0].Columns["EAP"].Width = 150;
                grdList.DisplayLayout.Bands[0].Columns["EAP"].CellAppearance.Image = Properties.Resources.Eap;
                grdList.DisplayLayout.Bands[0].Columns["Result"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Proc. Time (ms)"].Width = 90;
                grdList.DisplayLayout.Bands[0].Columns["Proc. Time (ms)"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdList.DisplayLayout.Bands[0].Columns["Message"].Width = 80;
                // --
                grdList.DisplayLayout.Bands[0].Columns["EAP"].Header.Fixed = true;
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
            string serverName
            )
        {
            try
            {
                txtSvrName.Text = serverName;
                refreshGridOfEap();

                // --

                txtSvrName.Focus();
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

        private void refreshGridOfEap(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            object[] cellValues = null;
            string key = string.Empty;
            int nextRowNumber = 0;

            try
            {
                grdList.beginUpdate();
                grdList.removeAllDataRow();
                // --
                btnClear.Enabled = false;

                // --

                if (txtSvrName.Text == string.Empty)
                {
                    grdList.endUpdate();
                    return;
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("server", txtSvrName.Text);

                // --

                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Transaction", "ServerMainSwitch", "ListEap", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),       // EAP
                            string.Empty
                            };
                        key = (string)cellValues[0];
                        grdList.appendDataRow(key, cellValues);                        
                    }
                } while (nextRowNumber >= 0);

                // --

                grdList.endUpdate();
                
                // --

                if (grdList.Rows.Count > 0 && grdList.activeDataRow == null)
                {
                    grdList.ActiveRow = grdList.Rows[0];
                    // --
                    btnClear.Enabled = true;
                }

                // --

                btnSwitch.Enabled = m_tranEnabled;
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void action(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInEap = null;
            FXmlNode fXmlNodeInServer = null;
            FXmlNode fXmlNodeOut = null;
            bool isServerMainFail = false;
            string server = string.Empty;
            string upDown = string.Empty;
            string status = string.Empty;
            string adminAgentUpDown = string.Empty;
            string eap = string.Empty;
            string result = string.Empty;
            string msg = string.Empty;
            Stopwatch sw = null;      

            try
            {
                txtSvrName.Enabled = false;
                btnSwitch.Enabled = false;
                sw = new Stopwatch();

                // --

                server = txtSvrName.Text;

                // --

                // ***
                // Server Main Validation
                // ***
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("server", server);
                // --
                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Transaction", "ServerMainSwitch", "SearchServer", fSqlParams, false);

                // --

                if (dt.Rows.Count == 0)
                {
                    isServerMainFail = true;
                    result = this.fUIWizard.searchCaption("Fail");
                    msg = this.fUIWizard.generateMessage("E0010", new object[] { "Server" });
                }
                else
                {
                    upDown = dt.Rows[0][0].ToString();
                    status = dt.Rows[0][1].ToString();
                    adminAgentUpDown = dt.Rows[0][2].ToString();

                    // --

                    if (upDown == FUpDown.Down.ToString())
                    {
                        isServerMainFail = true;
                        result = this.fUIWizard.searchCaption("Fail");
                        msg = this.fUIWizard.generateMessage("E0030", new object[] { "Server" });
                    }
                    else if (status == FServerStatusEnum.Main.ToString())
                    {
                        isServerMainFail = true;
                        result = this.fUIWizard.searchCaption("Fail");
                        msg = this.fUIWizard.generateMessage("E0045", new object[] { "Server" });
                    }
                    else if (adminAgentUpDown == FUpDown.Down.ToString())
                    {
                        isServerMainFail = true;
                        result = this.fUIWizard.searchCaption("Fail");
                        msg = this.fUIWizard.generateMessage("E0030", new object[] { "Admin Agent of Server" });
                    }
                }

                // --

                // ***
                // EAP Main Switch
                // ***
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TrnEapMainSwitch_In.E_ADMADS_TrnEapMainSwitch_In);
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapMainSwitch_In.A_hLanguage, FADMADS_TrnEapMainSwitch_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapMainSwitch_In.A_hStep, FADMADS_TrnEapMainSwitch_In.D_hStep, "1");
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapMainSwitch_In.A_hFactory, FADMADS_TrnEapMainSwitch_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapMainSwitch_In.A_hUserId, FADMADS_TrnEapMainSwitch_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapMainSwitch_In.A_hHostIp, FADMADS_TrnEapMainSwitch_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapMainSwitch_In.A_hHostName, FADMADS_TrnEapMainSwitch_In.D_hHostName, m_fAdmCore.fOption.hostName);
                // --
                fXmlNodeInEap = fXmlNodeIn.set_elem(FADMADS_TrnEapMainSwitch_In.FEap.E_Eap);

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

                    // ***
                    // Server Main Validation 실패 시, MC Main Fail 처리
                    // ***
                    if (isServerMainFail)
                    {
                        sw.Stop();
                        // --
                        r["Result"] = result;
                        r["Proc. Time (ms)"] = sw.ElapsedMilliseconds.ToString();
                        r["Message"] = msg;
                        // --
                        continue;
                    }

                    // --

                    fXmlNodeInEap.set_elemVal(
                        FADMADS_TrnEapMainSwitch_In.FEap.A_Name,
                        FADMADS_TrnEapMainSwitch_In.FEap.D_Name,
                        eap
                        );
                    // --
                    fXmlNodeInEap.set_elemVal(
                        FADMADS_TrnEapMainSwitch_In.FEap.A_Server,
                        FADMADS_TrnEapMainSwitch_In.FEap.D_Server,
                        server
                        );

                    // --

                    try
                    {
                        FADMADSCaster.ADMADS_TrnEapMainSwitch_Req(
                            m_fAdmCore.fH101,
                            fXmlNodeIn,
                            ref fXmlNodeOut
                            );

                        // --

                        if (fXmlNodeOut.get_elemVal(FADMADS_TrnEapMainSwitch_Out.A_hStatus, FADMADS_TrnEapMainSwitch_Out.D_hStatus) != "0")
                        {
                            result = this.fUIWizard.searchCaption("Fail");
                            msg = fXmlNodeOut.get_elemVal(FADMADS_TrnEapMainSwitch_Out.A_hStatusMessage, FADMADS_TrnEapMainSwitch_Out.D_hStatusMessage);
                        }
                        else
                        {
                            result = this.fUIWizard.searchCaption("Success");
                            msg = this.fUIWizard.generateMessage("M0012");
                        }
                    }
                    catch (Exception ex)
                    {
                        result = this.fUIWizard.searchCaption("Fail");
                        msg = ex.Message;
                    }

                    // --

                    sw.Stop();

                    // --

                    r["Result"] = result;
                    r["Proc. Time (ms)"] = sw.ElapsedMilliseconds.ToString();
                    r["Message"] = msg;
                }

                // --

                if (isServerMainFail)
                {
                    return;
                }

                // --

                // ***
                // Server Main Switch
                // ***
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TrnServerMainSwitch_In.E_ADMADS_TrnServerMainSwitch_In);
                fXmlNodeIn.set_elemVal(FADMADS_TrnServerMainSwitch_In.A_hLanguage, FADMADS_TrnServerMainSwitch_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TrnServerMainSwitch_In.A_hStep, FADMADS_TrnServerMainSwitch_In.D_hStep, "1");
                fXmlNodeIn.set_elemVal(FADMADS_TrnServerMainSwitch_In.A_hFactory, FADMADS_TrnServerMainSwitch_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TrnServerMainSwitch_In.A_hUserId, FADMADS_TrnServerMainSwitch_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TrnServerMainSwitch_In.A_hHostIp, FADMADS_TrnServerMainSwitch_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_TrnServerMainSwitch_In.A_hHostName, FADMADS_TrnServerMainSwitch_In.D_hHostName, m_fAdmCore.fOption.hostName);
                // --
                fXmlNodeInServer = fXmlNodeIn.set_elem(FADMADS_TrnServerMainSwitch_In.FServer.E_Server);
                fXmlNodeInServer.set_elemVal(FADMADS_TrnServerMainSwitch_In.FServer.A_Name, FADMADS_TrnServerMainSwitch_In.FServer.D_Name, server);

                // --

                FADMADSCaster.ADMADS_TrnServerMainSwitch_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );

                if (fXmlNodeOut.get_elemVal(FADMADS_TrnServerMainSwitch_Out.A_hStatus, FADMADS_TrnServerMainSwitch_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_TrnServerMainSwitch_Out.A_hStatusMessage, FADMADS_TrnServerMainSwitch_Out.D_hStatusMessage)
                        );
                }
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FServerMainSwitch Form Event Handler

        private void FServerMainSwitch_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_tranEnabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.ServerMainSwitch);

                // --

                designGridOfEap();

                // --

                btnSwitch.Enabled = false;
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

        private void FServerMainSwitch_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                txtSvrName.Focus();
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

        private void FServerMainSwitch_FormClosing(
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

                fDialog = new FServerSelector(m_fAdmCore, FServerType.Real.ToString(), txtSvrName.Text, "N");
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

        #region btnSwitch Control Event Handler

        private void btnSwitch_Click(
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
                    this.fUIWizard.generateMessage("M0010", new object[] { "Server Main Switch" }),
                    false
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
                txtSvrName.Text = string.Empty;

                // --
                
                grdList.beginUpdate();
                // --
                grdList.removeAllDataRow();
                // --
                grdList.endUpdate();               

                // --

                txtSvrName.Enabled = true;
                btnSwitch.Enabled = false;
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
