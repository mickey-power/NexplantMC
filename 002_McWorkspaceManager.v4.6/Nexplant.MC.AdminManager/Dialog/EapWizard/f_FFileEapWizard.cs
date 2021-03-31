/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FFileEapWizard.cs
--  Creator         : spike.lee
--  Create Date     : 2017.06.22
--  Description     : FAmate Admin Manager EAP Wizard for File Form Class 
--  History         : Created by spike.lee at 2017.06.22
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;
using Nexplant.MC.WorkspaceInterface;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinTree;
using Nexplant.MC.Adminmanager;

namespace Nexplant.MC.AdminManager
{
    public partial class FFileEapWizard : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private FEapWizardData m_fEapWizardData = null;
        private string m_eapName = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FFileEapWizard(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FFileEapWizard(
            FAdmCore fAdmCore
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;

            // --

            m_fEapWizardData = new FEapWizardData();
            m_fEapWizardData.wizardMode = FEapWizardMode.New;
            m_fEapWizardData.fEapType = FEapType.FILE;
            m_fEapWizardData.fOperMode = FEapOperationMode.Server;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FFileEapWizard(
            FAdmCore fAdmCore,
            FEapWizardData fEapWizardData
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;

            // --

            m_fEapWizardData = fEapWizardData;
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

        public FEapWizardData fEapWizardData
        {
            get
            {
                try
                {
                    return m_fEapWizardData;
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void designComboOfLanguage(
          )
        {
            UltraDataSource uds = null;

            try
            {
                uds = ucbLanguage.dataSource;
                // --
                uds.Band.Columns.Add("Language");

                // --

                ucbLanguage.DisplayLayout.Bands[0].Columns["Language"].Width = 120;
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

        private void refreshComboOfLanguage(
            )
        {
            try
            {
                ucbLanguage.beginUpdate();

                // --

                foreach (string s in Enum.GetNames(typeof(FLanguage)))
                {
                    ucbLanguage.appendDataRow(s, new object[] { s });
                }

                // --

                ucbLanguage.endUpdate();

                // --

                ucbLanguage.ActiveRow = ucbLanguage.Rows[0];
            }
            catch (Exception ex)
            {
                ucbLanguage.endUpdate();
                // --
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadEapConfig(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;

            try
            {
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                if (m_fEapWizardData.wizardMode == FEapWizardMode.Clone)
                {
                    fSqlParams.add("eap", m_fEapWizardData.eap);
                }
                else
                {
                    fSqlParams.add("eap", txtEap.Text);
                }

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "EapWizard", "SearchEap", fSqlParams, true);

                // --

                ucbLanguage.Value = dt.Rows[0]["CFG_LANGUAGE"].ToString();
                txtUserId.Text = dt.Rows[0]["CFG_USER_ID"].ToString();
                // --
                nmbDebugLogKeepingPeriod.Value = dt.Rows[0]["CFG_DEBUG_LOG_KEEPING_PERIOD"].ToString();
                // --
                nmbMaxLogFileSizeOfFileM.Value = int.Parse(dt.Rows[0]["CFG_MAX_SECS_LOG_FILE_SIZE"].ToString()) / 1024 / 1024;
                nmbMaxLogFileSizeOfFileB.Value = dt.Rows[0]["CFG_MAX_SECS_LOG_FILE_SIZE"].ToString();
                // --
                txtNetworkPath.Text = dt.Rows[0]["FILE_NETWORK_PATH"].ToString();
                txtFileUser.Text = dt.Rows[0]["FILE_USER"].ToString();
                txtFilePassword.Text = dt.Rows[0]["FILE_PASSWORD"].ToString();
                txtSearchPattern.Text = dt.Rows[0]["FILE_SEARCH_PATTERN"].ToString();
                nmbSearchPeriod.Value = dt.Rows[0]["FILE_SEARCH_PERIOD"].ToString();
                txtBackUpPath.Text = dt.Rows[0]["FILE_BACKUP_PATH"].ToString();
                txtBackUpUser.Text = dt.Rows[0]["FILE_BACKUP_USER"].ToString();
                txtBackUpPassWord.Text = dt.Rows[0]["FILE_BACKUP_PASSWORD"].ToString();
                txtErrorPath.Text = dt.Rows[0]["FILE_ERROR_PATH"].ToString();
                txtErrorUser.Text = dt.Rows[0]["FILE_ERROR_USER"].ToString();
                txtErrorPassword.Text = dt.Rows[0]["FILE_ERROR_PASSWORD"].ToString();
                if (txtBackUpPath.Text != string.Empty)
                {
                    ((StateEditorButton)txtBackUpPath.ButtonsLeft["Enabled"]).Checked = true;
                }

                if (txtErrorPath.Text != string.Empty)
                {
                    ((StateEditorButton)txtErrorPath.ButtonsLeft["Enabled"]).Checked = true;
                }
                // --
                ProcChecksFtpEnable();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadDefaultEapConfig(
            )
        {
            try
            {
                ucbLanguage.Value = FLanguage.Default.ToString();
                txtUserId.Text = "EAP";
                // --
                nmbDebugLogKeepingPeriod.Value = 30;
                // --                
                nmbMaxLogFileSizeOfFileM.Value = 5;
                nmbMaxLogFileSizeOfFileB.Value = 5 * 1024 * 1024;

                // --

                txtSearchPattern.Text = "*.*";
                nmbSearchPeriod.Value = 30;
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

        private void loadEapWizardData(
            )
        {
            try
            {
                if (m_fEapWizardData.wizardMode == FEapWizardMode.Update)
                {
                    txtEap.Text = m_fEapWizardData.eap;
                }
                else
                {
                    txtEap.Text = string.Empty;
                }
                txtDesc.Text = m_fEapWizardData.description;
                txtSvrName.Text = m_fEapWizardData.server;
                // --
                txtPackage.Text = m_fEapWizardData.package;
                txtPackageVer.Text = m_fEapWizardData.packageVer;
                txtComponent.Text = m_fEapWizardData.component;
                txtComponentVer.Text = m_fEapWizardData.componentVer;

                // --

                if (m_fEapWizardData.wizardMode == FEapWizardMode.Clone)
                {
                    loadEapConfig();
                }
                else if (m_fEapWizardData.wizardMode == FEapWizardMode.Update)
                {
                    txtEap.Enabled = false;
                    txtSvrName.Enabled = false;
                    // --
                    loadEapConfig();
                }
                else
                {
                    loadDefaultEapConfig();
                }

                loadEapHostDDeviceData();
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

        private void showServerSelector(
            )
        {
            FServerSelector fDialog = null;

            try
            {
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

        private void showPackageVerSelector(
            )
        {
            FPackageVersionSelector fDialog = null;

            try
            {
                fDialog = new FPackageVersionSelector(m_fAdmCore, FEapType.FILE.ToString(), txtPackage.Text, txtPackageVer.Text);
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                txtPackage.Text = fDialog.selectedPackage;
                txtPackageVer.Text = fDialog.selectedPackageVer;
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
                fDialog = new FComponentVersionSelector(m_fAdmCore, FEapType.FILE.ToString(), txtComponent.Text, txtComponentVer.Text);
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                txtComponent.Text = fDialog.selectedComponent;
                txtComponentVer.Text = fDialog.selectedComponentVer;
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

        private void validateStep100(
            )
        {
            string errorMessage = string.Empty;

            try
            {
                if (!FCommon.validateName(txtEap.Text, true, ref errorMessage, m_fAdmCore.fUIWizard, "EAP"))
                {
                    txtEap.Focus();
                    FDebug.throwFException(errorMessage);
                }

                if (txtSvrName.Text == string.Empty)
                {
                    txtSvrName.Focus();
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0025", new object[] { "Server" }));
                }

                if (txtPackage.Text == string.Empty)
                {
                    txtPackageVer.Focus();
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0025", new object[] { "Package" }));
                }

                if (txtComponent.Text == string.Empty)
                {
                    txtComponentVer.Focus();
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0025", new object[] { "Component" }));
                }

                // --

                if (txtNetworkPath.Text == string.Empty)
                {
                    txtNetworkPath.Focus();
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0004", new object[] { "NetworkPath" }));
                }

                // --

                if (!FCommon.validateName(txtUserId.Text, true, ref errorMessage, m_fAdmCore.fUIWizard, "User ID"))
                {
                    txtUserId.Focus();
                    FDebug.throwFException(errorMessage);
                }

                // --

                if ((int)nmbMaxLogFileSizeOfFileB.Value < 1)
                {
                    nmbMaxLogFileSizeOfFileB.Focus();
                    FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Max File Log File Size" }));
                }

                if ((int)nmbDebugLogKeepingPeriod.Value < 1)
                {
                    nmbDebugLogKeepingPeriod.Focus();
                    FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Debug Log Keeping Period" }));
                }
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

        private void procPreviousStep(
            )
        {
            string key = string.Empty;

            try
            {
                key = tabMain.ActiveTab.Key;

                // --

                if (key == "General")
                {

                }
                else if (key == "BackUp")
                {
                    key = "General";

                    // --
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = true;
                    // --
                    btnConfigDefault.Enabled = true;
                }
                else if (key == "Host")
                {
                    key = "BackUp";

                    // --
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = true;
                    // --
                    btnConfigDefault.Enabled = false;
                    btnOk.Enabled = false;
                }

                // --

                tabMain.ActiveTab.Visible = false;
                tabMain.ActiveTab = tabMain.Tabs[key];
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

        private void procNextStep(
            )
        {
            string key = string.Empty;

            try
            {
                key = tabMain.ActiveTab.Key;

                // --

                if (key == "General")
                {
                    validateStep100();

                    // --

                    key = "BackUp";

                    // --



                    // --

                    btnPrevious.Enabled = true;
                    btnNext.Enabled = true;
                    // --
                    btnConfigDefault.Enabled = false;

                    // --

                    tvwHdv.Focus();

                    loadEapHostDDeviceData();
                }
                else if (key == "BackUp")
                {
                    key = "Host";

                    // --
                    btnPrevious.Enabled = true;
                    btnOk.Enabled = true;
                    btnNext.Enabled = false;
                    // --
                    btnConfigDefault.Enabled = false;
                }
                else if (key == "Host")
                {

                }

                // --

                tabMain.ActiveTab.Visible = false;
                tabMain.ActiveTab = tabMain.Tabs[key];
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

        private void ProcChecksFtpEnable(
            object sender
            )
        {
            try
            {
                if (((FTextBox)sender).Text.Length > 3)
                {
                    if (chkEnabledUseSftp.Visible)
                    {
                        if (((FTextBox)sender).Text.Substring(0, 4).ToLower() == "ftp:")
                        {

                        }
                        else
                        {
                            if (((FTextBox)sender).Name == "txtBackUpPath")
                            {
                                if (!txtErrorPath.Text.Contains("ftp://"))
                                {
                                    chkEnabledUseSftp.Checked = false;
                                    chkEnabledUseSftp.Visible = false;
                                    fPanel8.Visible = false;
                                }
                            }
                            else
                            {
                                if (!txtBackUpPath.Text.Contains("ftp://"))
                                {
                                    chkEnabledUseSftp.Checked = false;
                                    chkEnabledUseSftp.Visible = false;
                                    fPanel8.Visible = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (((FTextBox)sender).Text.Substring(0, 4).ToLower() == "ftp:")
                        {
                            chkEnabledUseSftp.Visible = true;
                            fPanel8.Visible = true;
                        }
                        else
                        {
                            chkEnabledUseSftp.Checked = false;
                            chkEnabledUseSftp.Visible = false;
                            fPanel8.Visible = false;
                        }
                    }
                }
                else
                {
                    if (chkEnabledUseSftp.Visible)
                    {
                        if (((FTextBox)sender).Name == "txtBackUpPath")
                        {
                            if (!txtErrorPath.Text.Contains("ftp://"))
                            {
                                chkEnabledUseSftp.Checked = false;
                                chkEnabledUseSftp.Visible = false;
                                fPanel8.Visible = false;
                            }
                        }
                        else
                        {
                            if (!txtBackUpPath.Text.Contains("ftp://"))
                            {
                                chkEnabledUseSftp.Checked = false;
                                chkEnabledUseSftp.Visible = false;
                                fPanel8.Visible = false;
                            }
                        }
                    }
                }
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

        private void ProcChecksFtpEnable(           
           )
        {
            try
            {
                if (!txtErrorPath.Text.Contains("ftp://"))
                {
                    chkEnabledUseSftp.Checked = false;
                    chkEnabledUseSftp.Visible = false;
                    fPanel8.Visible = false;
                }
                else
                {
                    chkEnabledUseSftp.Visible = true;
                    fPanel8.Visible = true;
                }

                if (!chkEnabledUseSftp.Checked)
                {
                    if (!txtBackUpPath.Text.Contains("ftp://"))
                    {
                        chkEnabledUseSftp.Checked = false;
                        chkEnabledUseSftp.Visible = false;
                        fPanel8.Visible = false;
                    }
                }
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

        private void loadEapHostDDeviceData(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            DataTable dt2 = null;
            // --


            FXmlNode fXmlNodeOutFcd = null;
            FXmlNode fXmlNodeOuthdv = null;            

            try
            {
                tvwHdv.Nodes.Clear();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                if (m_fEapWizardData.wizardMode == FEapWizardMode.Clone)
                {
                    fSqlParams.add("eap", m_fEapWizardData.eap);
                }
                else
                {
                    fSqlParams.add("eap", txtEap.Text);
                }
                fSqlParams.add("attr_category", "Setup"); 

                // --
                if (m_fEapWizardData.wizardMode != FEapWizardMode.New)
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "EapWizard", "SearchEapSecsDriverAtr", fSqlParams,false);
                    dt2 = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "EapWizard", "SearchEapHostDeviceAtr", fSqlParams, false) ;
                }
                
                // --
                fXmlNodeOutFcd = FCommon.createXmlNode(FFileDriver.E_FileDriver);
                if (dt != null && dt.Rows.Count > 0)
                {
                    fXmlNodeOutFcd.set_elemVal(
                        FFileDriver.A_Name,
                        FFileDriver.D_Name,
                        dt.Rows[0][0].ToString()
                        );
                    fXmlNodeOutFcd.set_elemVal(
                        FFileDriver.A_Description,
                        FFileDriver.D_Description,
                        dt.Rows[0][1].ToString()
                        );
                }
                else
                {
                    fXmlNodeOutFcd.set_elemVal(
                        FFileDriver.A_Name,
                        FFileDriver.D_Name,
                        txtEap.Text
                        );
                    fXmlNodeOutFcd.set_elemVal(
                        FFileDriver.A_Description,
                        FFileDriver.D_Description
                        );
                }
                // --
                if (dt2 != null && dt2.Rows.Count > 0)
                {
                    foreach (DataRow drow in dt2.Rows)
                    {
                        fXmlNodeOuthdv = FCommon.createXmlNode(FFileDriver.FHostDevice.E_HostDevice);
                        // --
                        fXmlNodeOuthdv.set_elemVal(
                            FFileDriver.FHostDevice.A_Seq,
                            FFileDriver.FHostDevice.D_Seq,
                            drow[0].ToString()
                            );
                        fXmlNodeOuthdv.set_elemVal(
                            FFileDriver.FHostDevice.A_Name,
                            FFileDriver.FHostDevice.D_Name,
                            drow[1].ToString()
                            );
                        fXmlNodeOuthdv.set_elemVal(
                            FFileDriver.FHostDevice.A_Description,
                            FFileDriver.FHostDevice.D_Description,
                            drow[2].ToString()
                            );
                        fXmlNodeOuthdv.set_elemVal(
                            FFileDriver.FHostDevice.A_Mode,
                            FFileDriver.FHostDevice.D_Mode,
                            drow[3].ToString()
                            );
                        fXmlNodeOuthdv.set_elemVal(
                            FFileDriver.FHostDevice.A_Driver,
                            FFileDriver.FHostDevice.D_Driver,
                            drow[4].ToString()
                            );
                        fXmlNodeOuthdv.set_elemVal(
                            FFileDriver.FHostDevice.A_DriverDescription,
                            FFileDriver.FHostDevice.D_DriverDescription,
                            drow[5].ToString()
                            );
                        fXmlNodeOuthdv.set_elemVal(
                            FFileDriver.FHostDevice.A_DriverOption,
                            FFileDriver.FHostDevice.D_DriverOption,
                            drow[6].ToString()
                            );
                        fXmlNodeOuthdv.set_elemVal(
                            FFileDriver.FHostDevice.A_TransactionTimeout,
                            FFileDriver.FHostDevice.D_TransactionTimeout,
                            drow[7].ToString()
                            );
                        fXmlNodeOuthdv.appendChild(FCommon.ConvertFileEapHostOptionStringtoXml(drow[6].ToString()));
                        fXmlNodeOutFcd.appendChild(fXmlNodeOuthdv);
                    }
                }
                else
                {
                    fXmlNodeOuthdv = FCommon.createXmlNode(FFileDriver.FHostDevice.E_HostDevice);
                    // --
                    fXmlNodeOuthdv.set_elemVal(
                        FFileDriver.FHostDevice.A_Seq,
                        FFileDriver.FHostDevice.D_Seq,
                        "0"
                        );
                    fXmlNodeOuthdv.set_elemVal(
                        FFileDriver.FHostDevice.A_Name,
                        FFileDriver.FHostDevice.D_Name,
                        "ADS"
                        );
                    fXmlNodeOuthdv.set_elemVal(
                        FFileDriver.FHostDevice.A_Driver,
                        FFileDriver.FHostDevice.D_Driver,
                        "Nexplant.MC.HostDriver.File");
                    fXmlNodeOuthdv.appendChild(createDefaultHostOption());
                    fXmlNodeOutFcd.appendChild(fXmlNodeOuthdv);

                    // --

                    fXmlNodeOuthdv = FCommon.createXmlNode(FFileDriver.FHostDevice.E_HostDevice);
                    // --
                    fXmlNodeOuthdv.set_elemVal(
                        FFileDriver.FHostDevice.A_Seq,
                        FFileDriver.FHostDevice.D_Seq,
                        "1"
                        );
                    fXmlNodeOuthdv.set_elemVal(
                        FFileDriver.FHostDevice.A_Name,
                        FFileDriver.FHostDevice.D_Name,
                        "EIS"
                        );
                    fXmlNodeOuthdv.set_elemVal(
                        FFileDriver.FHostDevice.A_Driver,
                        FFileDriver.FHostDevice.D_Driver,
                        "Nexplant.MC.HostDriver.File");
                    fXmlNodeOuthdv.appendChild(createDefaultHostOption());
                    fXmlNodeOutFcd.appendChild(fXmlNodeOuthdv);
                }
                // --


                // --

                refreshTreeOfHostDevice(fXmlNodeOutFcd);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeOutFcd = null;
                fXmlNodeOuthdv = null; 
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        private void refreshTreeOfHostDevice(
            FXmlNode fXmlNodeFileEap
            )
        {
            UltraTreeNode tNodeScd = null;
            UltraTreeNode tNodeHdv = null;                        
            int keyIndex = 0;

            try
            {
                tvwHdv.beginUpdate();
                tvwHdv.Nodes.Clear();

                // --
                
                tNodeScd = new UltraTreeNode(keyIndex.ToString(), getSchemaObjectText(fXmlNodeFileEap));
                tNodeScd.Override.NodeAppearance.Image = Properties.Resources.SecsDriver;
                keyIndex++;
                tNodeScd.Tag = fXmlNodeFileEap;

                // --

                foreach (FXmlNode fXmlNodeHdv in fXmlNodeFileEap.get_elemList(FFileDriver.FHostDevice.E_HostDevice))
                {
                    tNodeHdv = new UltraTreeNode(keyIndex.ToString(), getSchemaObjectText(fXmlNodeHdv));
                    tNodeHdv.Override.NodeAppearance.Image = Properties.Resources.HostDevice;
                    keyIndex++;
                    tNodeHdv.Tag = fXmlNodeHdv;
                    tNodeScd.Nodes.Add(tNodeHdv);
                }

                // --

                tvwHdv.Nodes.Add(tNodeScd);
                tvwHdv.ExpandAll();
                // --
                tvwHdv.ActiveNode = tNodeScd;

                // --

                tvwHdv.endUpdate();
            }
            catch (Exception ex)
            {
                tvwHdv.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeScd = null;
                tNodeHdv = null;                
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private string getSchemaObjectText(
            FXmlNode fXmlNode
            )
        {
            string info = string.Empty;
            string name = string.Empty;
            string desc = string.Empty;            
            string value = string.Empty;
            FXmlNode fXmlNodeHostOption = null;


            try
            {
                if (fXmlNode.name == FFileDriver.E_FileDriver)
                {
                    name = fXmlNode.get_elemVal(
                        FFileDriver.A_Name,
                        FFileDriver.D_Name
                        ).Trim();
                    desc = fXmlNode.get_elemVal(
                        FFileDriver.A_Description,
                        FFileDriver.D_Description
                        ).Trim();
                    // --
                    info = name;
                    if (desc != string.Empty)
                    {
                        info += " Desc=[" + desc + "]";
                    }
                }                
                else if (fXmlNode.name == FFileDriver.FHostDevice.E_HostDevice)
                {
                    name = fXmlNode.get_elemVal(
                        FFileDriver.FHostDevice.A_Name,
                        FFileDriver.FHostDevice.D_Name
                        ).Trim();
                   
                    // --
                    info = name;
                    // --
                    fXmlNodeHostOption = fXmlNode.get_elem(FFileDriver.FHostDevice.FHostOption.E_HostOption);

                    value = fXmlNodeHostOption.get_elemVal(
                        FFileDriver.FHostDevice.FHostOption.A_StationConnectString, 
                        FFileDriver.FHostDevice.FHostOption.D_StationConnectString
                        );
                    info += " ConnectString=[";
                    info += value;
                    info += "]";
                    fXmlNode.set_elemVal(
                        FFileDriver.FHostDevice.A_DriverOption,
                        FFileDriver.FHostDevice.D_DriverOption,
                        FCommon.ConvertFileEapHostOptionXmltoString(fXmlNodeHostOption)
                        );
                }                

                // --

                return info;
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

        private FXmlNode createDefaultHostOption(
            )
        {
            FXmlNode fXmlNodeHostOption = null;
            try
            {
                fXmlNodeHostOption = FCommon.createXmlNode(FFileDriver.FHostDevice.FHostOption.E_HostOption);

                fXmlNodeHostOption.set_elemVal(FFileDriver.FHostDevice.FHostOption.A_StationConnectString, FFileDriver.FHostDevice.FHostOption.D_StationConnectString);
                fXmlNodeHostOption.set_elemVal(FFileDriver.FHostDevice.FHostOption.A_StationTimeOut, FFileDriver.FHostDevice.FHostOption.D_StationTimeOut);
                fXmlNodeHostOption.set_elemVal(FFileDriver.FHostDevice.FHostOption.A_StationVersion, FFileDriver.FHostDevice.FHostOption.D_StationVersion);
                fXmlNodeHostOption.set_elemVal(FFileDriver.FHostDevice.FHostOption.A_GuaranteedtimeOut, FFileDriver.FHostDevice.FHostOption.D_GuaranteedtimeOut);
                fXmlNodeHostOption.set_elemVal(FFileDriver.FHostDevice.FHostOption.A_MaxSpoling, FFileDriver.FHostDevice.FHostOption.D_MaxSpoling);
                fXmlNodeHostOption.set_elemVal(FFileDriver.FHostDevice.FHostOption.A_SessionId, FFileDriver.FHostDevice.FHostOption.D_SessionId);
                fXmlNodeHostOption.set_elemVal(FFileDriver.FHostDevice.FHostOption.A_ModuleName, FFileDriver.FHostDevice.FHostOption.D_ModuleName);
                fXmlNodeHostOption.set_elemVal(FFileDriver.FHostDevice.FHostOption.A_TuneChannel, FFileDriver.FHostDevice.FHostOption.D_TuneChannel);
                fXmlNodeHostOption.set_elemVal(FFileDriver.FHostDevice.FHostOption.A_CastChannel, FFileDriver.FHostDevice.FHostOption.D_CastChannel);
                fXmlNodeHostOption.set_elemVal(FFileDriver.FHostDevice.FHostOption.A_ParsingType, FFileDriver.FHostDevice.FHostOption.D_ParsingType);
                return fXmlNodeHostOption;
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

        private void procMenuAppendHostDevice()
        {
            FXmlNode fXmlNodeOutFcd = null;
            FXmlNode fXmlNodeOutHdv = null;

            try
            {
                fXmlNodeOutFcd = (FXmlNode)tvwHdv.ActiveNode.Tag;
                fXmlNodeOutHdv = FCommon.createXmlNode(FFileDriver.FHostDevice.E_HostDevice);
                // --
                fXmlNodeOutHdv.set_elemVal(
                    FFileDriver.FHostDevice.A_Seq,
                    FFileDriver.FHostDevice.D_Seq,
                    "0"
                    );
                fXmlNodeOutHdv.set_elemVal(
                    FFileDriver.FHostDevice.A_Name,
                    FFileDriver.FHostDevice.D_Name
                    );
                fXmlNodeOutHdv.set_elemVal(
                    FFileDriver.FHostDevice.A_Driver,
                    FFileDriver.FHostDevice.D_Driver,
                    "Nexplant.MC.HostDriver.File");
                fXmlNodeOutHdv.appendChild(createDefaultHostOption());
                fXmlNodeOutFcd.appendChild(fXmlNodeOutHdv);

                refreshTreeOfHostDevice(fXmlNodeOutFcd);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeOutFcd = null;
                fXmlNodeOutHdv = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuInsertBeforHostDevice()
        {
            FXmlNode fXmlNodeOutFcd = null;
            FXmlNode fXmlNodeOutHdv = null;
            FXmlNode fXmlNodeOutRefHdv = null;

            try
            {
                fXmlNodeOutRefHdv = (FXmlNode)tvwHdv.ActiveNode.Tag;
                fXmlNodeOutFcd = (FXmlNode)tvwHdv.ActiveNode.Parent.Tag;
                fXmlNodeOutHdv = FCommon.createXmlNode(FFileDriver.FHostDevice.E_HostDevice);
                // --
                fXmlNodeOutHdv.set_elemVal(
                    FFileDriver.FHostDevice.A_Seq,
                    FFileDriver.FHostDevice.D_Seq,
                    "0"
                    );
                fXmlNodeOutHdv.set_elemVal(
                    FFileDriver.FHostDevice.A_Name,
                    FFileDriver.FHostDevice.D_Name
                    );
                fXmlNodeOutHdv.set_elemVal(
                    FFileDriver.FHostDevice.A_Driver,
                    FFileDriver.FHostDevice.D_Driver,
                    "Nexplant.MC.HostDriver.File");
                fXmlNodeOutHdv.appendChild(createDefaultHostOption());
                fXmlNodeOutFcd.insertBefore(fXmlNodeOutHdv, fXmlNodeOutRefHdv);

                refreshTreeOfHostDevice(fXmlNodeOutFcd);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeOutFcd = null;
                fXmlNodeOutHdv = null;
                fXmlNodeOutRefHdv = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuInsertAfterHostDevice()
        {
            FXmlNode fXmlNodeOutFcd = null;
            FXmlNode fXmlNodeOutHdv = null;
            FXmlNode fXmlNodeOutRefHdv = null;

            try
            {
                fXmlNodeOutRefHdv = (FXmlNode)tvwHdv.ActiveNode.Tag;
                fXmlNodeOutFcd = (FXmlNode)tvwHdv.ActiveNode.Parent.Tag;
                fXmlNodeOutHdv = FCommon.createXmlNode(FFileDriver.FHostDevice.E_HostDevice);
                // --
                fXmlNodeOutHdv.set_elemVal(
                    FFileDriver.FHostDevice.A_Seq,
                    FFileDriver.FHostDevice.D_Seq,
                    "0"
                    );
                fXmlNodeOutHdv.set_elemVal(
                    FFileDriver.FHostDevice.A_Name,
                    FFileDriver.FHostDevice.D_Name
                    );
                fXmlNodeOutHdv.set_elemVal(
                    FFileDriver.FHostDevice.A_Driver,
                    FFileDriver.FHostDevice.D_Driver,
                    "Nexplant.MC.HostDriver.File");
                fXmlNodeOutHdv.appendChild(createDefaultHostOption());
                fXmlNodeOutFcd.insertAfter(fXmlNodeOutHdv, fXmlNodeOutRefHdv);

                refreshTreeOfHostDevice(fXmlNodeOutFcd);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeOutFcd = null;
                fXmlNodeOutHdv = null;
                fXmlNodeOutRefHdv = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuCopy()
        {
            UltraTreeNode tNode = null;
            FXmlNode fXmlNodeOutHdv = null;

            try
            {
                tNode = tvwHdv.ActiveNode;
                fXmlNodeOutHdv = (FXmlNode)tNode.Tag;

                // --          
                FClipboard.setStringData(FFileDriver.FHostDevice.E_HostDevice, fXmlNodeOutHdv.outerXml);
                refreshPopUpMenu(fXmlNodeOutHdv.name);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
                fXmlNodeOutHdv = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuCut()
        {
            UltraTreeNode tNode = null;
            FXmlNode fXmlNodeOutHdv = null;

            try
            {
                tNode = tvwHdv.ActiveNode;
                fXmlNodeOutHdv = (FXmlNode)tNode.Tag;


                // --          
                FClipboard.setStringData(FFileDriver.FHostDevice.E_HostDevice, fXmlNodeOutHdv.outerXml);
                if (tNode.NextVisibleNode != null)
                {
                    tvwHdv.ActiveNode = tNode.NextVisibleNode;
                }
                else
                {
                    tvwHdv.ActiveNode = tNode.Parent;
                }
                
                tvwHdv.Nodes.Remove(tNode);
                refreshTreeOfHostDevice((FXmlNode)tNode.Parent.Tag);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
                fXmlNodeOutHdv = null;                
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuPasteChild()
        {
            FXmlDocument fXmlDoc = null;
            FXmlNode fXmlNodeTemp = null;
            FXmlNode fParentXmlNode = null;            

            try
            {
                fParentXmlNode = (FXmlNode)tvwHdv.ActiveNode.Tag;               
                
                // --          
                
                fXmlDoc = new FXmlDocument();
                fXmlDoc.preserveWhiteSpace = false;
                fXmlDoc.loadXml(FClipboard.getStringData(FFileDriver.FHostDevice.E_HostDevice));
                fXmlNodeTemp = fXmlDoc.fFirstChild.clone(true);

                fParentXmlNode.appendChild(fXmlNodeTemp);
                refreshTreeOfHostDevice(fParentXmlNode);
                tvwHdv.ActiveNode = tvwHdv.Nodes[0].Nodes[tvwHdv.Nodes[0].Nodes.Count-1];
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeTemp = null;
                fParentXmlNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuPasteSibling()
        {
            FXmlDocument fXmlDoc = null;
            UltraTreeNode tNode = null;            
            FXmlNode refXmlNode = null;
            FXmlNode fXmlNodeTemp = null;
            FXmlNode parentXmlNode = null;
            int activeNodeIndex = 0;

            try
            {
                tNode = tvwHdv.ActiveNode;
                activeNodeIndex = tNode.Index;
                refXmlNode = (FXmlNode)tNode.Tag;

                // --          
                
                fXmlDoc = new FXmlDocument();
                fXmlDoc.preserveWhiteSpace = false;
                fXmlDoc.loadXml(FClipboard.getStringData(FFileDriver.FHostDevice.E_HostDevice));
                fXmlNodeTemp = fXmlDoc.fFirstChild.clone(true);
                
                // --
                
                parentXmlNode = (FXmlNode)tNode.Parent.Tag;
                parentXmlNode.insertAfter(fXmlNodeTemp, refXmlNode);                
                
                // --
                
                refreshTreeOfHostDevice(parentXmlNode);
                tvwHdv.ActiveNode = tvwHdv.Nodes[0].Nodes[activeNodeIndex + 1];
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;                
                refXmlNode = null;
                fXmlNodeTemp = null;
                parentXmlNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuRemove()
        {
            UltraTreeNode tNode = null;
            FXmlNode fXmlNodeOutHdv = null;
            FXmlNode fXmlNodeOutParent = null;
            FXmlNode fXmlNOdeOut = null;
            try
            {
                tNode = tvwHdv.ActiveNode;
                fXmlNodeOutHdv = (FXmlNode)tNode.Tag;
                fXmlNodeOutParent = (FXmlNode)tNode.Parent.Tag;

                // --          
                
                if (tNode.NextVisibleNode != null)
                {
                    tvwHdv.ActiveNode = tNode.NextVisibleNode;
                }
                else
                {
                    tvwHdv.ActiveNode = tNode.Parent;
                }
                // --
                fXmlNOdeOut = fXmlNodeOutParent.removeChild(fXmlNodeOutHdv);
                
                // --

                refreshTreeOfHostDevice(fXmlNodeOutParent);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
                fXmlNodeOutHdv = null;
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        private void refreshPopUpMenu(string type)
        {
            try
            {
                if (type == FFileDriver.E_FileDriver)
                {

                    
                    mnuMenu.Tools[FMenuKey.MenuFwhCut].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuFwhCopy].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuFwhHdvRemove].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuFwhInsertAfterHostDevice].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuFwhInsertBeforeHostDevice].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuFwhPasteSibling].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuFwhAppendHostDevice].SharedProps.Enabled = true;

                    if (FClipboard.containsData(FFileDriver.FHostDevice.E_HostDevice))
                    {
                        mnuMenu.Tools[FMenuKey.MenuFwhPasteChild].SharedProps.Enabled = true;
                    }
                    else
                    {
                        mnuMenu.Tools[FMenuKey.MenuFwhPasteChild].SharedProps.Enabled = false;
                    }

                }
                else if (type == FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.E_HostDevice)
                {                    
                    mnuMenu.Tools[FMenuKey.MenuFwhCut].SharedProps.Enabled = true;
                    mnuMenu.Tools[FMenuKey.MenuFwhCopy].SharedProps.Enabled = true;
                    mnuMenu.Tools[FMenuKey.MenuFwhHdvRemove].SharedProps.Enabled = true;
                    mnuMenu.Tools[FMenuKey.MenuFwhInsertAfterHostDevice].SharedProps.Enabled = true;
                    mnuMenu.Tools[FMenuKey.MenuFwhInsertBeforeHostDevice].SharedProps.Enabled = true;
                    mnuMenu.Tools[FMenuKey.MenuFwhPasteChild].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuFwhAppendHostDevice].SharedProps.Enabled = false;
                    if (FClipboard.containsData(FFileDriver.FHostDevice.E_HostDevice))
                    {
                        mnuMenu.Tools[FMenuKey.MenuFwhPasteSibling].SharedProps.Enabled = true;
                    }
                    else
                    {
                        mnuMenu.Tools[FMenuKey.MenuFwhPasteSibling].SharedProps.Enabled = false;
                    }

                }
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

        #region FFileEapWizard Form Event Handler

        private void FFileEapWizard_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                ((StateEditorButton)txtBackUpPath.ButtonsLeft["Enabled"]).AfterCheckStateChanged += new EditorButtonEventHandler(txtCommon_LeftButtonAfterCheckStateChanged);
                ((StateEditorButton)txtErrorPath.ButtonsLeft["Enabled"]).AfterCheckStateChanged += new EditorButtonEventHandler(txtCommon_LeftButtonAfterCheckStateChanged);
                //--
                ((EditorButton)txtSvrName.ButtonsRight["List"]).Click += new EditorButtonEventHandler(txtCommon_RightButtonClick);
                ((EditorButton)txtPackageVer.ButtonsRight["List"]).Click += new EditorButtonEventHandler(txtCommon_RightButtonClick);
                ((EditorButton)txtComponentVer.ButtonsRight["List"]).Click += new EditorButtonEventHandler(txtCommon_RightButtonClick);

                // --

                designComboOfLanguage();
                refreshComboOfLanguage();
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

        private void FFileEapWizard_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                loadEapWizardData();

                // --
                btnNext.Enabled = true;
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

        private void FFileEapWizard_FormClosing(
            object sender,
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                ((StateEditorButton)txtBackUpPath.ButtonsLeft["Enabled"]).AfterCheckStateChanged -= new EditorButtonEventHandler(txtCommon_LeftButtonAfterCheckStateChanged);
                ((StateEditorButton)txtErrorPath.ButtonsLeft["Enabled"]).AfterCheckStateChanged -= new EditorButtonEventHandler(txtCommon_LeftButtonAfterCheckStateChanged);
                // --
                ((EditorButton)txtSvrName.ButtonsRight["List"]).Click -= new EditorButtonEventHandler(txtCommon_RightButtonClick);
                ((EditorButton)txtPackageVer.ButtonsRight["List"]).Click -= new EditorButtonEventHandler(txtCommon_RightButtonClick);
                ((EditorButton)txtComponentVer.ButtonsRight["List"]).Click -= new EditorButtonEventHandler(txtCommon_RightButtonClick);
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

        public void refreshSchemaObject(
            FXmlNode fXmlNode,
            UltraTreeNode tNode
            )
        {
            string info = string.Empty;

            try
            {
                info = getSchemaObjectText(fXmlNode);                
                tNode.Text = info;
                // --
                if (fXmlNode.name == FFileDriver.E_FileDriver)
                {                    
                    if (tvwHdv.Nodes[0] != tNode)
                    {
                        tvwHdv.Nodes[0].Text = info;
                        if (tvwHdv.Nodes[0].IsActive)
                        {
                            pgdHdv.Refresh();
                        }
                    }                   
                }
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

        #region TextBox Common Control Event Handler

        private void txtCommon_RightButtonClick(
            object sender,
            EditorButtonEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --                

                if (sender == txtSvrName.ButtonsRight["List"])
                {
                    showServerSelector();
                }
                else if (sender == txtPackageVer.ButtonsRight["List"])
                {
                    showPackageVerSelector();
                }
                else if (sender == txtComponentVer.ButtonsRight["List"])
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

                if (sender == txtBackUpPath.ButtonsLeft["Enabled"])
                {
                    if (((StateEditorButton)e.Button).CheckState == CheckState.Checked)
                    {
                        txtBackUpPath.ReadOnly = false;
                        txtBackUpUser.Enabled = true;
                        txtBackUpPassWord.Enabled = true;
                    }
                    else
                    {
                        txtBackUpPath.Text = string.Empty;
                        txtBackUpUser.Text = string.Empty;
                        txtBackUpPassWord.Text = string.Empty;
                        txtBackUpPath.ReadOnly = true;
                        txtBackUpUser.Enabled = false;
                        txtBackUpPassWord.Enabled = false;
                    }
                }
                else if (sender == txtErrorPath.ButtonsLeft["Enabled"])
                {
                    if (((StateEditorButton)e.Button).CheckState == CheckState.Checked)
                    {
                        txtErrorPath.ReadOnly = false;
                        txtErrorUser.Enabled = true;
                        txtErrorPassword.Enabled = true;
                    }
                    else
                    {
                        txtErrorPath.Text = string.Empty;
                        txtErrorUser.Text = string.Empty;
                        txtErrorPassword.Text = string.Empty;
                        txtErrorPath.ReadOnly = true;
                        txtErrorUser.Enabled = false;
                        txtErrorPassword.Enabled = false;
                    }
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

        #region btnOk Control Event Handler

        private void btnOk_Click(
            object sender,
            EventArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInEap = null;
            FXmlNode fXmlNodeInCfg = null;
            FXmlNode fXmlNodeInFcd = null;
            FXmlNode fXmlNodeInFdv = null;            
            FXmlNode fXmlNodeInHdv = null;
            FXmlNode fXmlNodeInEqp = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNode = null;            
            UltraTreeNode tNodeFcd = null;            
            UltraTreeNode tNodeHdv = null;
            // --
            string eap = string.Empty;
            string eapDesc = string.Empty;
            string eapType = string.Empty;
            string operMode = string.Empty;
            string server = string.Empty;
            string package = string.Empty;
            string packageVer = string.Empty;
            string model = string.Empty;
            string modelVer = string.Empty;
            string usedComponent = string.Empty;
            string component = string.Empty;
            string componentVer = string.Empty;
            // --
            string language = string.Empty;
            string userId = string.Empty;
            string debugLogKeepingPeriod = string.Empty;
            string fileLogEnabled = string.Empty;
            string maxFileLogFileSize = string.Empty;
            // --
            string networkPath = string.Empty;
            string fileUser = string.Empty;
            string filePassword = string.Empty;
            string BackUpPath = string.Empty;
            string BackUpUser = string.Empty;
            string BackUpPassword = string.Empty;
            string ErrorPath = string.Empty;
            string ErrorUser = string.Empty;
            string ErrorPassword = string.Empty;
            string searchPattern = string.Empty;
            string searchPeriod = string.Empty;           
            // --
            string sFileDriver = string.Empty;
            string sFileDriverDesc = string.Empty;
            string tempPath = string.Empty;
            // --
            string hostDevice = string.Empty;
            string hostDeviceDesc = string.Empty;
            string hostDeviceMode = string.Empty;
            string driver = string.Empty;
            string driverDesc = string.Empty;
            string driverOption = string.Empty;
            string tTimeout = string.Empty;
            // --
            string errorMessage = string.Empty;
            FFileDeviceType fileDeviceType = FFileDeviceType.NetWork;

            try
            {
                FCursor.waitCursor();

                // --

                #region Validation

                if (!FCommon.validateName(txtEap.Text, true, ref errorMessage, m_fAdmCore.fUIWizard, "EAP"))
                {
                    txtEap.Focus();
                    FDebug.throwFException(errorMessage);
                }

                if (txtSvrName.Text == string.Empty)
                {
                    txtSvrName.Focus();
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0025", new object[] { "Server" }));
                }

                if (txtPackage.Text == string.Empty)
                {
                    txtPackageVer.Focus();
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0025", new object[] { "Package" }));
                }

                if (txtComponent.Text == string.Empty)
                {
                    txtComponentVer.Focus();
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0025", new object[] { "Component" }));
                }

                if (txtNetworkPath.Text == string.Empty)
                {
                    txtComponentVer.Focus();
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0025", new object[] { "Component" }));
                }

                if (txtSearchPattern.Text == string.Empty)
                {
                    txtSearchPattern.Focus();
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0004", new object[] { "Search Pattern" }));
                }

                if ((int)nmbSearchPeriod.Value < 1)
                {
                    nmbSearchPeriod.Focus();
                    FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Search Period" }));
                }

                if (!FCommon.validateName(txtUserId.Text, true, ref errorMessage, m_fAdmCore.fUIWizard, "User ID"))
                {
                    txtUserId.Focus();
                    FDebug.throwFException(errorMessage);
                }

                if ((int)nmbMaxLogFileSizeOfFileB.Value < 1)
                {
                    nmbMaxLogFileSizeOfFileB.Focus();
                    FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Max File Log Size" }));
                }

                if ((int)nmbDebugLogKeepingPeriod.Value < 1)
                {
                    nmbDebugLogKeepingPeriod.Focus();
                    FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Debug Log Keeping Period" }));
                }

                #endregion

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetEapUpdate_In.E_ADMADS_SetEapUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetEapUpdate_In.A_hLanguage, FADMADS_SetEapUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetEapUpdate_In.A_hFactory, FADMADS_SetEapUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetEapUpdate_In.A_hUserId, FADMADS_SetEapUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetEapUpdate_In.A_hHostIp, FADMADS_SetEapUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetEapUpdate_In.A_hHostName, FADMADS_SetEapUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                if (m_fEapWizardData.wizardMode == FEapWizardMode.Update)
                {
                    fXmlNodeIn.set_elemVal(FADMADS_SetEapUpdate_In.A_hStep, FADMADS_SetEapUpdate_In.D_hStep, "1");
                }
                else
                {
                    fXmlNodeIn.set_elemVal(FADMADS_SetEapUpdate_In.A_hStep, FADMADS_SetEapUpdate_In.D_hStep, "2");
                }

                // --

                #region MC

                eap = txtEap.Text;
                eapDesc = txtDesc.Text == string.Empty ? " " : txtDesc.Text;
                eapType = FEapType.FILE.ToString();
                operMode = FEapOperationMode.Server.ToString();
                server = txtSvrName.Text;
                package = txtPackage.Text;
                packageVer = txtPackageVer.Text;
                model = "";
                modelVer = "0";
                usedComponent = FYesNo.Yes.ToString();
                component = txtComponent.Text;
                componentVer = txtComponentVer.Text;

                // --

                fXmlNodeInEap = fXmlNodeIn.set_elem(FADMADS_SetEapUpdate_In.FEap.E_Eap);
                fXmlNodeInEap.set_elemVal(FADMADS_SetEapUpdate_In.FEap.A_Name, FADMADS_SetEapUpdate_In.FEap.D_Name, eap);
                fXmlNodeInEap.set_elemVal(FADMADS_SetEapUpdate_In.FEap.A_Description, FADMADS_SetEapUpdate_In.FEap.D_Description, eapDesc);
                fXmlNodeInEap.set_elemVal(FADMADS_SetEapUpdate_In.FEap.A_EapType, FADMADS_SetEapUpdate_In.FEap.D_EapType, eapType);
                fXmlNodeInEap.set_elemVal(FADMADS_SetEapUpdate_In.FEap.A_OperMode, FADMADS_SetEapUpdate_In.FEap.D_OperMode, operMode);
                fXmlNodeInEap.set_elemVal(FADMADS_SetEapUpdate_In.FEap.A_Server, FADMADS_SetEapUpdate_In.FEap.D_Server, server);
                fXmlNodeInEap.set_elemVal(FADMADS_SetEapUpdate_In.FEap.A_Package, FADMADS_SetEapUpdate_In.FEap.D_Package, package);
                fXmlNodeInEap.set_elemVal(FADMADS_SetEapUpdate_In.FEap.A_PackageVer, FADMADS_SetEapUpdate_In.FEap.D_PackageVer, packageVer);
                fXmlNodeInEap.set_elemVal(FADMADS_SetEapUpdate_In.FEap.A_Model, FADMADS_SetEapUpdate_In.FEap.D_Model, model);
                fXmlNodeInEap.set_elemVal(FADMADS_SetEapUpdate_In.FEap.A_ModelVer, FADMADS_SetEapUpdate_In.FEap.D_ModelVer, modelVer);
                fXmlNodeInEap.set_elemVal(FADMADS_SetEapUpdate_In.FEap.A_UsedComponent, FADMADS_SetEapUpdate_In.FEap.D_UsedComponent, usedComponent);
                fXmlNodeInEap.set_elemVal(FADMADS_SetEapUpdate_In.FEap.A_Component, FADMADS_SetEapUpdate_In.FEap.D_Component, component);
                fXmlNodeInEap.set_elemVal(FADMADS_SetEapUpdate_In.FEap.A_ComponentVer, FADMADS_SetEapUpdate_In.FEap.D_ComponentVer, componentVer);            

                #endregion

                // --

                #region Config

                language = ucbLanguage.Value.ToString();
                userId = txtUserId.Text;
                debugLogKeepingPeriod = nmbDebugLogKeepingPeriod.Value.ToString();                
                fileLogEnabled = FYesNo.Yes.ToString();
                maxFileLogFileSize = nmbMaxLogFileSizeOfFileB.Value.ToString();
                // --
                fXmlNodeInCfg = fXmlNodeInEap.set_elem(FADMADS_SetEapUpdate_In.FEap.FConfig.E_Config);
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_Language, FADMADS_SetEapUpdate_In.FEap.FConfig.D_Language, language);
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_UserId, FADMADS_SetEapUpdate_In.FEap.FConfig.D_UserId, userId);
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_DebugLogKeepingPeriod, FADMADS_SetEapUpdate_In.FEap.FConfig.D_DebugLogKeepingPeriod, debugLogKeepingPeriod);
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_BinaryLogEnabled, FADMADS_SetEapUpdate_In.FEap.FConfig.D_BinaryLogEnabled, " ");
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_MaxBinaryLogFileSize, FADMADS_SetEapUpdate_In.FEap.FConfig.D_MaxBinaryLogFileSize, "0");
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_SmlLogEnabled, FADMADS_SetEapUpdate_In.FEap.FConfig.D_SmlLogEnabled, " ");
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_MaxSmlLogFileSize, FADMADS_SetEapUpdate_In.FEap.FConfig.D_MaxSmlLogFileSize, "0");
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_VfeiLogEnabled, FADMADS_SetEapUpdate_In.FEap.FConfig.D_VfeiLogEnabled, " ");
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_MaxVfeiLogFileSize, FADMADS_SetEapUpdate_In.FEap.FConfig.D_MaxVfeiLogFileSize, "0");
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_SecsLogEnabled, FADMADS_SetEapUpdate_In.FEap.FConfig.D_SecsLogEnabled, fileLogEnabled);
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_MaxSecsLogFileSize, FADMADS_SetEapUpdate_In.FEap.FConfig.D_MaxSecsLogFileSize, maxFileLogFileSize);

                // --

                networkPath = txtNetworkPath.Text;
                fileUser = txtFileUser.Text;
                filePassword = txtFilePassword.Text;
                searchPattern = txtSearchPattern.Text;
                searchPeriod = nmbSearchPeriod.Value.ToString();
                BackUpPath = txtBackUpPath.Text;
                BackUpUser = txtBackUpUser.Text;
                BackUpPassword = txtBackUpPassWord.Text;
                ErrorPath = txtErrorPath.Text;
                ErrorUser = txtErrorUser.Text;
                ErrorPassword = txtErrorPassword.Text;

                // --
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_FileNetworkPath, FADMADS_SetEapUpdate_In.FEap.FConfig.D_FileNetworkPath, networkPath);
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_FileUser, FADMADS_SetEapUpdate_In.FEap.FConfig.D_FileUser, fileUser);
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_FilePassword, FADMADS_SetEapUpdate_In.FEap.FConfig.D_FilePassword, filePassword);
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_FileSearchPattern, FADMADS_SetEapUpdate_In.FEap.FConfig.D_FileSearchPattern, searchPattern);
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_FileSearchPeriod, FADMADS_SetEapUpdate_In.FEap.FConfig.D_FileSearchPeriod, searchPeriod);
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_FileBackUpPath, FADMADS_SetEapUpdate_In.FEap.FConfig.D_FileBackUpPath, BackUpPath);
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_FileBackUpUser, FADMADS_SetEapUpdate_In.FEap.FConfig.D_FileBackUpUser, BackUpUser);
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_FileBackUpPassword, FADMADS_SetEapUpdate_In.FEap.FConfig.D_FileBackUpPassword, BackUpPassword);
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_FileErrorPath, FADMADS_SetEapUpdate_In.FEap.FConfig.D_FileErrorPath, ErrorPath);
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_FileErrorUser, FADMADS_SetEapUpdate_In.FEap.FConfig.D_FileErrorUser, ErrorUser);
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_FileErrorPassword, FADMADS_SetEapUpdate_In.FEap.FConfig.D_FileErrorPassword, ErrorPassword);

                #endregion

                // --        

                #region FileDriver

                tNodeFcd = tvwHdv.Nodes[0];
                fXmlNode = (FXmlNode)tNodeFcd.Tag;
                // --
                sFileDriver = fXmlNode.get_elemVal(
                    FFileDriver.A_Name,
                    FFileDriver.D_Name
                    );
                sFileDriverDesc = fXmlNode.get_elemVal(
                    FFileDriver.A_Description,
                    FFileDriver.D_Description
                    );
                // --
                fXmlNodeInFcd = fXmlNodeInEap.set_elem(FADMADS_SetEapUpdate_In.FEap.FSecsDriver.E_SecsDriver);
                fXmlNodeInFcd.set_elemVal(
                    FADMADS_SetEapUpdate_In.FEap.FSecsDriver.A_Name,
                    FADMADS_SetEapUpdate_In.FEap.FSecsDriver.D_Name,
                    sFileDriver
                    );
                fXmlNodeInFcd.set_elemVal(
                    FADMADS_SetEapUpdate_In.FEap.FSecsDriver.A_Description,
                    FADMADS_SetEapUpdate_In.FEap.FSecsDriver.D_Description,
                    sFileDriverDesc == string.Empty ? " " : sFileDriverDesc
                    );

                #endregion


                // --

                #region File Device
                
                tempPath = networkPath;
                // --
                for (int i = 0; i < (typeof(FFileDeviceType)).GetEnumValues().Length; i++)
                {
                    if (i == (int)FFileDeviceType.Backup)
                    {
                        if (txtBackUpPath.ReadOnly)
                        {
                            continue;
                        }
                        fileDeviceType = FFileDeviceType.Backup;
                        tempPath = BackUpPath;
                    }

                    if (i == (int)FFileDeviceType.Error)
                    {
                        if (txtErrorPath.ReadOnly)
                        {
                            continue;
                        }
                        fileDeviceType = FFileDeviceType.Error;
                        tempPath = ErrorPath;
                    }
                    fXmlNodeInFdv = fXmlNodeInFcd.add_elem(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.E_SecsDevice
                        );
                    fXmlNodeInFdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_Seq,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_Seq,
                        i.ToString()
                        );
                    fXmlNodeInFdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_Name,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_Name,
                        fileDeviceType.ToString()
                        );
                    fXmlNodeInFdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_Description,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_Description,
                        eap + "_" + fileDeviceType.ToString()
                        );
                    fXmlNodeInFdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_OpcUrl,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_OpcUrl,
                        tempPath
                        );
                }
                
                #endregion

                // --

                #region Host Device

                tNodeFcd = tvwHdv.Nodes[0];
                // --
                for (int i = 0; i < tNodeFcd.Nodes.Count; i++)
                {
                    tNodeHdv = tNodeFcd.Nodes[i];
                    fXmlNode = (FXmlNode)tNodeHdv.Tag;
                    // --
                    hostDevice = fXmlNode.get_elemVal(
                        FFileDriver.FHostDevice.A_Name,
                        FFileDriver.FHostDevice.D_Name
                        );
                    hostDeviceDesc = fXmlNode.get_elemVal(
                        FFileDriver.FHostDevice.A_Description,
                        FFileDriver.FHostDevice.D_Description
                        );
                    hostDeviceMode = fXmlNode.get_elemVal(
                        FFileDriver.FHostDevice.A_Mode,
                        FFileDriver.FHostDevice.D_Mode
                        );
                    driver = fXmlNode.get_elemVal(
                        FFileDriver.FHostDevice.A_Driver,
                        FFileDriver.FHostDevice.D_Driver
                        );
                    driverDesc = fXmlNode.get_elemVal(
                        FFileDriver.FHostDevice.A_DriverDescription,
                        FFileDriver.FHostDevice.D_DriverDescription
                        );
                    driverOption = fXmlNode.get_elemVal(
                        FFileDriver.FHostDevice.A_DriverOption,
                        FFileDriver.FHostDevice.D_DriverOption
                        );
                    tTimeout = fXmlNode.get_elemVal(
                        FFileDriver.FHostDevice.A_TransactionTimeout,
                        FFileDriver.FHostDevice.D_TransactionTimeout
                        );
                    // --
                    fXmlNodeInHdv = fXmlNodeInFcd.add_elem(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.E_HostDevice
                        );
                    fXmlNodeInHdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.A_Seq,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.D_Seq,
                        i.ToString()
                        );
                    fXmlNodeInHdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.A_Name,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.D_Name,
                        hostDevice
                        );
                    fXmlNodeInHdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.A_Description,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.D_Description,
                        hostDeviceDesc == string.Empty ? " " : hostDeviceDesc
                        );
                    fXmlNodeInHdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.A_Mode,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.D_Mode,
                        hostDeviceMode == string.Empty ? " " : hostDeviceMode
                        );
                    fXmlNodeInHdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.A_Driver,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.D_Driver,
                        driver == string.Empty ? " " : driver
                        );
                    fXmlNodeInHdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.A_DriverDescription,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.D_DriverDescription,
                        driverDesc == string.Empty ? " " : driverDesc
                        );
                    fXmlNodeInHdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.A_DriverOption,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.D_DriverOption,
                        driverOption == string.Empty ? " " : driverOption
                        );
                    fXmlNodeInHdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.A_TransactionTimeout,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.D_TransactionTimeout,
                        tTimeout
                        );                                      
                }

                #endregion

                // --

                #region Equipment

                fXmlNodeInEqp = fXmlNodeInFcd.add_elem(
                    FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEquipment.E_Equipment
                    );
                // --
                fXmlNodeInEqp.set_elemVal(
                    FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEquipment.A_Seq,
                    FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEquipment.D_Seq,
                    "0"
                    );
                fXmlNodeInEqp.set_elemVal(
                    FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEquipment.A_Name,
                    FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEquipment.D_Name,
                    eap
                    );
                fXmlNodeInEqp.set_elemVal(
                    FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEquipment.A_Description,
                    FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEquipment.D_Description,
                    eapDesc
                    );

                #endregion

                // --

                FADMADSCaster.ADMADS_SetEapUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetEapUpdate_Out.A_hStatus, FADMADS_SetEapUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetEapUpdate_Out.A_hStatusMessage, FADMADS_SetEapUpdate_Out.D_hStatusMessage));
                }

                // --

                m_fEapWizardData.eap = eap;
                m_fEapWizardData.description = eapDesc;
                m_fEapWizardData.server = server;
                m_fEapWizardData.package = package;
                m_fEapWizardData.packageVer = packageVer;
                m_fEapWizardData.model = model;
                m_fEapWizardData.modelVer = modelVer;
                m_fEapWizardData.usedComponent = FYesNo.Yes;
                m_fEapWizardData.component = component;
                m_fEapWizardData.componentVer = componentVer;                

                // --

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInEap = null;
                fXmlNodeInCfg = null;
                fXmlNodeOut = null;                

                // --

                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnCancel Control Event Handler

        private void btnCancel_Click(
            object sender,
            EventArgs e
            )
        {
            try
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
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

        #region txtEap Control Event Handler

        private void txtEap_EditorButtonClick(
            object sender,
            EditorButtonEventArgs e
            )
        {
            FEapNameSelector dialog = null;
            string dept = string.Empty;

            try
            {
                dialog = new FEapNameSelector(
                   m_fAdmCore,
                   txtEap.Text,
                   "N"
                   );
                if (dialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                if (dialog.selectedEqpName != null)
                {
                    txtEap.Text = dialog.selectedEqpName;
                    txtDesc.Text = dialog.selectedEqpDesc;
                }
                else
                {
                    txtEap.Text = string.Empty;
                    txtDesc.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                dialog = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnConfigDefault Control Event Handler

        private void btnConfigDefault_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                loadDefaultEapConfig();
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

        #region Common NumericBox Control Event Handler

        private void CommonNumericBoxControl_ValueChanged(
            object sender,
            EventArgs e
            )
        {
            FNumericBox nmb = null;

            try
            {
                nmb = (FNumericBox)sender;

                // --

                if (!nmb.Focused)
                {
                    return;
                }

                // --

                if (nmb == nmbMaxLogFileSizeOfFileM)
                {
                    nmbMaxLogFileSizeOfFileB.Value = (int)nmb.Value * 1024 * 1024;
                }
                else if (nmb == nmbMaxLogFileSizeOfFileB)
                {
                    nmbMaxLogFileSizeOfFileM.Value = (int)nmb.Value / 1024 / 1024;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, this);
            }
            finally
            {
                nmb = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnNext Control Event Handler
        private void btnNext_Click(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                procNextStep();
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

        #region btnPrevious Control Event Handler

        private void btnPrevious_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                procPreviousStep();
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

        #region txtbaupPath_ValueChange        

        private void txtBackUpPath_ValueChanged(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --
                if (((StateEditorButton)txtBackUpPath.ButtonsLeft["Enabled"]).CheckState == CheckState.Checked)
                {
                    ProcChecksFtpEnable(sender);
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

        private void txtErrorPath_ValueChanged(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --
                if (((StateEditorButton)txtErrorPath.ButtonsLeft["Enabled"]).CheckState == CheckState.Checked)
                {
                    ProcChecksFtpEnable(sender);
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

        #region tabMain Control Event Handler

        private void tabMain_ActiveTabChanging(
            object sender,
            Infragistics.Win.UltraWinTabControl.ActiveTabChangingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                e.Tab.Visible = true;
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

        #region TreeView Common Control Event Handler

        private void tvwCommon_AfterActivate(
            object sender,
            NodeEventArgs e
            )
        {
            FTreeView fTreeView = null;
            FXmlNode fXmlNode = null;


            try
            {
                fTreeView = (FTreeView)sender;
                if (fTreeView.ActiveNode == null)
                {
                    return;
                }

                // --

                fXmlNode = (FXmlNode)fTreeView.ActiveNode.Tag;

                // --

                if (fXmlNode.name == FFileDriver.E_FileDriver)
                {

                    if (fTreeView == tvwHdv)
                    {
                        pgdHdv.selectedObject = new FPropEwdFieFcd(m_fAdmCore, pgdHdv, this, fTreeView.ActiveNode, fXmlNode);
                    }
                    mnuMenu.Tools[FMenuKey.MenuFwhCut].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuFwhCopy].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuFwhHdvRemove].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuFwhInsertAfterHostDevice].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuFwhInsertBeforeHostDevice].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuFwhPasteSibling].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuFwhAppendHostDevice].SharedProps.Enabled = true;
                    
                    if (FClipboard.containsData(FFileDriver.FHostDevice.E_HostDevice))
                    {
                        mnuMenu.Tools[FMenuKey.MenuFwhPasteChild].SharedProps.Enabled = true;
                    }
                    else
                    {
                        mnuMenu.Tools[FMenuKey.MenuFwhPasteChild].SharedProps.Enabled = false;
                    }

                }
                else if (fXmlNode.name == FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.E_HostDevice)
                {
                    pgdHdv.selectedObject = new FPropEwdFieHdv(m_fAdmCore, pgdHdv, this, fTreeView.ActiveNode, fXmlNode);
                    mnuMenu.Tools[FMenuKey.MenuFwhCut].SharedProps.Enabled = true;
                    mnuMenu.Tools[FMenuKey.MenuFwhCopy].SharedProps.Enabled = true;
                    mnuMenu.Tools[FMenuKey.MenuFwhHdvRemove].SharedProps.Enabled = true;
                    mnuMenu.Tools[FMenuKey.MenuFwhInsertAfterHostDevice].SharedProps.Enabled = true;
                    mnuMenu.Tools[FMenuKey.MenuFwhInsertBeforeHostDevice].SharedProps.Enabled = true;                    
                    mnuMenu.Tools[FMenuKey.MenuFwhPasteChild].SharedProps.Enabled = false;                                        
                    mnuMenu.Tools[FMenuKey.MenuFwhAppendHostDevice].SharedProps.Enabled = false;
                    if (FClipboard.containsData(FFileDriver.FHostDevice.E_HostDevice))
                    {
                        mnuMenu.Tools[FMenuKey.MenuFwhPasteSibling].SharedProps.Enabled = true;
                    }
                    else
                    {
                        mnuMenu.Tools[FMenuKey.MenuFwhPasteSibling].SharedProps.Enabled = false;
                    }

                }              
         
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fTreeView = null;
                fXmlNode = null;
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        private void tvwHdv_MouseDown
            (
            object sender,
            MouseEventArgs e
            )
        {
            UltraTreeNode tNode = null;
            FXmlNode fXmlNode = null;

            try
            {
                FCursor.waitCursor();
                
                // --

                if (e.Button != MouseButtons.Right || tvwHdv.Nodes.Count == 0)
                {
                    return;
                }

                tNode = tvwHdv.GetNodeFromPoint(e.X, e.Y);
                if (tNode != null)
                {
                    tvwHdv.ActiveNode = tNode;
                }

                fXmlNode = (FXmlNode)tvwHdv.ActiveNode.Tag;
                if (fXmlNode.name == "FileDriver")
                {
                    mnuMenu.ShowPopup(FMenuKey.MenuFwhHdrPopUp);
                }
                else if (fXmlNode.name == FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.E_HostDevice)
                {
                    mnuMenu.ShowPopup(FMenuKey.MenuFwhHdvPopUp);
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

        private void tvwHdv_KeyDown(object sender, KeyEventArgs e)
        {
            FXmlNode fXmlNode = null;

            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuFwhHdvRemove].SharedProps.Enabled)
                    {
                        procMenuRemove();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.X)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuFwhCut].SharedProps.Enabled)
                    {
                        procMenuCut();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.C)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuFwhCopy].SharedProps.Enabled)
                    {
                        procMenuCopy();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.V)
                {
                    fXmlNode = (FXmlNode)this.tvwHdv.ActiveNode.Tag;

                    if (fXmlNode.name == "FileDriver")
                    {
                        procMenuPasteChild();
                    }
                    else
                    {
                        procMenuPasteSibling();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.B)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuFwhInsertBeforeHostDevice].SharedProps.Enabled)
                    {
                        procMenuInsertBeforHostDevice();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.A)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuFwhInsertAfterHostDevice].SharedProps.Enabled)
                    {
                        procMenuInsertAfterHostDevice();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.P)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuFwhAppendHostDevice].SharedProps.Enabled)
                    {
                        procMenuAppendHostDevice();
                    }
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

        #region mnuMenu Event Handler
        private void mnuMenu_ToolClick(
            object sender,
            Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tool.Key == FMenuKey.MenuFwhAppendHostDevice)
                {
                    procMenuAppendHostDevice();
                }
                else if (e.Tool.Key == FMenuKey.MenuFwhInsertBeforeHostDevice)
                {
                    procMenuInsertBeforHostDevice();
                }
                else if (e.Tool.Key == FMenuKey.MenuFwhInsertAfterHostDevice)
                {
                    procMenuInsertAfterHostDevice();
                }
                else if (e.Tool.Key == FMenuKey.MenuFwhPasteChild)
                {
                    procMenuPasteChild();
                }
                else if (e.Tool.Key == FMenuKey.MenuFwhPasteSibling)
                {
                    procMenuPasteSibling();
                }
                else if (e.Tool.Key == FMenuKey.MenuFwhCopy)
                {
                    procMenuCopy();
                }
                else if (e.Tool.Key == FMenuKey.MenuFwhCut)
                {
                    procMenuCut();
                }
                else if (e.Tool.Key == FMenuKey.MenuFwhHdvRemove)
                {
                    procMenuRemove();
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
