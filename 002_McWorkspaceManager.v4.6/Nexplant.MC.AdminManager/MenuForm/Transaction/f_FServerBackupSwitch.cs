/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FServerBackupSwitch.cs
--  Creator         : spike.lee
--  Create Date     : 2013.02.08
--  Description     : FAMate Admin Manager Transaction - Server Backup Switch Class 
--  History         : Created by spike.lee at 2013.02.08
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
    public partial class FServerBackupSwitch : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm, FITransaction
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_tranEnabled = false;
        private bool m_cancel = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FServerBackupSwitch(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FServerBackupSwitch(
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

                //

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
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Transaction", "ServerBackupSwitch", "ListEap", fSqlParams, false, ref nextRowNumber);
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
            bool isServerBackupFail = false;
            string server = string.Empty;
            string status = string.Empty;
            string backupUsed = string.Empty;
            string backupServer = string.Empty;
            string backupServerUpDown = string.Empty;
            string backupServerStatus = string.Empty;
            string backupAdminAgentUpDown = string.Empty;
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
                // Server Backup Validation
                // ***
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("server", server);
                // --
                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Transaction", "ServerBackupSwitch", "SearchServer", fSqlParams, false);

                // --

                if (dt.Rows.Count == 0)
                {
                    isServerBackupFail = true;
                    result = this.fUIWizard.searchCaption("Fail");
                    msg = this.fUIWizard.generateMessage("E0010", new object[] { "Server" });
                }
                else
                {
                    status = dt.Rows[0][0].ToString();
                    backupUsed = dt.Rows[0][1].ToString();
                    backupServer = dt.Rows[0][2].ToString();
                    backupServerUpDown = dt.Rows[0][3].ToString();
                    backupServerStatus = dt.Rows[0][4].ToString();
                    backupAdminAgentUpDown = dt.Rows[0][5].ToString();

                    // --

                    if (status == FServerStatusEnum.Backup.ToString())
                    {
                        isServerBackupFail = true;
                        result = this.fUIWizard.searchCaption("Fail");
                        msg = this.fUIWizard.generateMessage("E0031", new object[] { "Server" });
                    }
                    else if (backupUsed == FYesNo.No.ToString())
                    {
                        isServerBackupFail = true;
                        result = this.fUIWizard.searchCaption("Fail");
                        msg = this.fUIWizard.generateMessage("E0041", new object[] { "Backup Server" });
                    }
                    else if (backupServerUpDown == FUpDown.Down.ToString())
                    {
                        isServerBackupFail = true;
                        result = this.fUIWizard.searchCaption("Fail");
                        msg = this.fUIWizard.generateMessage("E0030", new object[] { "Backup Server" });
                    }
                    else if (backupServerStatus == FServerStatusEnum.Backup.ToString())
                    {
                        isServerBackupFail = true;
                        result = this.fUIWizard.searchCaption("Fail");
                        msg = this.fUIWizard.generateMessage("E0031", new object[] { "Backup Server" });
                    }
                    else if (backupAdminAgentUpDown == FUpDown.Down.ToString())
                    {
                        isServerBackupFail = true;
                        result = this.fUIWizard.searchCaption("Fail");
                        msg = this.fUIWizard.generateMessage("E0030", new object[] { "Admin Agent of Backup Server" });
                    }
                }

                // --

                // ***
                // EAP Backup Switch
                // ***
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TrnEapBackupSwitch_In.E_ADMADS_TrnEapBackupSwitch_In);
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapBackupSwitch_In.A_hLanguage, FADMADS_TrnEapBackupSwitch_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapBackupSwitch_In.A_hStep, FADMADS_TrnEapBackupSwitch_In.D_hStep, "1");
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapBackupSwitch_In.A_hFactory, FADMADS_TrnEapBackupSwitch_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapBackupSwitch_In.A_hUserId, FADMADS_TrnEapBackupSwitch_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapBackupSwitch_In.A_hHostIp, FADMADS_TrnEapBackupSwitch_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapBackupSwitch_In.A_hHostName, FADMADS_TrnEapBackupSwitch_In.D_hHostName, m_fAdmCore.fOption.hostName);
                // --
                fXmlNodeInEap = fXmlNodeIn.set_elem(FADMADS_TrnEapBackupSwitch_In.FEap.E_Eap);

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
                    // Server Backup Validation 실패 시, EAP Backup Fail 처리
                    // ***
                    if (isServerBackupFail)
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
                        FADMADS_TrnEapBackupSwitch_In.FEap.A_Name,
                        FADMADS_TrnEapBackupSwitch_In.FEap.D_Name,
                        eap
                        );
                    // --
                    fXmlNodeInEap.set_elemVal(
                        FADMADS_TrnEapBackupSwitch_In.FEap.A_BackupServer,
                        FADMADS_TrnEapBackupSwitch_In.FEap.D_BackupServer,
                        backupServer
                        );

                    // --

                    try
                    {
                        FADMADSCaster.ADMADS_TrnEapBackupSwitch_Req(
                            m_fAdmCore.fH101,
                            fXmlNodeIn,
                            ref fXmlNodeOut
                            );

                        // --

                        if (fXmlNodeOut.get_elemVal(FADMADS_TrnEapBackupSwitch_Out.A_hStatus, FADMADS_TrnEapBackupSwitch_Out.D_hStatus) != "0")
                        {
                            result = this.fUIWizard.searchCaption("Fail");
                            msg = fXmlNodeOut.get_elemVal(FADMADS_TrnEapBackupSwitch_Out.A_hStatusMessage, FADMADS_TrnEapBackupSwitch_Out.D_hStatusMessage);
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

                if (isServerBackupFail)
                {
                    return;
                }

                // --

                // ***
                // Server Backup Switch
                // ***
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TrnServerBackupSwitch_In.E_ADMADS_TrnServerBackupSwitch_In);
                fXmlNodeIn.set_elemVal(FADMADS_TrnServerBackupSwitch_In.A_hLanguage, FADMADS_TrnServerBackupSwitch_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TrnServerBackupSwitch_In.A_hStep, FADMADS_TrnServerBackupSwitch_In.D_hStep, "1");
                fXmlNodeIn.set_elemVal(FADMADS_TrnServerBackupSwitch_In.A_hFactory, FADMADS_TrnServerBackupSwitch_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TrnServerBackupSwitch_In.A_hUserId, FADMADS_TrnServerBackupSwitch_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TrnServerBackupSwitch_In.A_hHostIp, FADMADS_TrnServerBackupSwitch_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_TrnServerBackupSwitch_In.A_hHostName, FADMADS_TrnServerBackupSwitch_In.D_hHostName, m_fAdmCore.fOption.hostName);
                // --
                fXmlNodeInServer = fXmlNodeIn.set_elem(FADMADS_TrnServerBackupSwitch_In.FServer.E_Server);
                fXmlNodeInServer.set_elemVal(FADMADS_TrnServerBackupSwitch_In.FServer.A_Name, FADMADS_TrnServerBackupSwitch_In.FServer.D_Name, server);

                // --

                FADMADSCaster.ADMADS_TrnServerBackupSwitch_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );

                if (fXmlNodeOut.get_elemVal(FADMADS_TrnServerBackupSwitch_Out.A_hStatus, FADMADS_TrnServerBackupSwitch_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_TrnServerBackupSwitch_Out.A_hStatusMessage, FADMADS_TrnServerBackupSwitch_Out.D_hStatusMessage)
                        );
                }                
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
                fXmlNodeIn = null;
                fXmlNodeInEap = null;
                fXmlNodeInServer = null;
                fXmlNodeOut = null;
            }
        }        

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FServerBackupSwitch Form Event Handler

        private void FServerBackupSwitch_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_tranEnabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.ServerBackupSwitch);

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

        private void FServerBackupSwitch_Shown(
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

        private void FServerBackupSwitch_FormClosing(
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
                    this.fUIWizard.generateMessage("M0010", new object[] { "Server Backup Switch" }),
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
