/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FProcessEapWizard.cs
--  Creator         : spike.lee
--  Create Date     : 2015.08.05
--  Description     : FAMate Admin Manager EAP Wizard for Process Form Class 
--  History         : Created by spike.lee at 2015.08.05
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

namespace Nexplant.MC.AdminManager
{
    public partial class FProcessEapWizard : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;        
        private FEapWizardData m_fEapWizardData = null;
        private string m_eapName = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FProcessEapWizard(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FProcessEapWizard(
            FAdmCore fAdmCore
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;

            // --

            m_fEapWizardData = new FEapWizardData();
            m_fEapWizardData.wizardMode = FEapWizardMode.New;
            m_fEapWizardData.fEapType = FEapType.Process;
            m_fEapWizardData.fOperMode = FEapOperationMode.Client;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FProcessEapWizard(
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
                
                if (m_fEapWizardData.wizardMode == FEapWizardMode.Update)
                {
                    txtEap.Enabled = false;                    
                    txtSvrName.Enabled = false;                    
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

        private void showServerSelector(
            )
        {
            FServerSelector fDialog = null;

            try
            {
                fDialog = new FServerSelector(m_fAdmCore, FServerType.Virtual.ToString(), txtSvrName.Text, "N");
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FEapWizard Form Event Handler

        private void FEapWizard_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                ((EditorButton)txtSvrName.ButtonsRight["List"]).Click += new EditorButtonEventHandler(txtCommon_RightButtonClick);
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

        private void FEapWizard_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                loadEapWizardData();
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

        private void FEapWizard_FormClosing(
            object sender,
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                ((EditorButton)txtSvrName.ButtonsRight["List"]).Click -= new EditorButtonEventHandler(txtCommon_RightButtonClick);
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

        #region DropDownListCombo Control Common Event Handler

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
            FXmlNode fXmlNodeOut = null;            
            // --
            string eap = string.Empty;
            string eapDesc = string.Empty;
            string eapType = string.Empty;
            string operMode = string.Empty;
            string server = string.Empty;
            string errorMessage = string.Empty;

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

                #endregion

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetProcessEapUpdate_In.E_ADMADS_SetProcessEapUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetProcessEapUpdate_In.A_hLanguage, FADMADS_SetProcessEapUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetProcessEapUpdate_In.A_hFactory, FADMADS_SetProcessEapUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetProcessEapUpdate_In.A_hUserId, FADMADS_SetProcessEapUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetProcessEapUpdate_In.A_hHostIp, FADMADS_SetProcessEapUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetProcessEapUpdate_In.A_hHostName, FADMADS_SetProcessEapUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                if (m_fEapWizardData.wizardMode == FEapWizardMode.Update)
                {
                    fXmlNodeIn.set_elemVal(FADMADS_SetProcessEapUpdate_In.A_hStep, FADMADS_SetProcessEapUpdate_In.D_hStep, "1");
                }
                else
                {
                    fXmlNodeIn.set_elemVal(FADMADS_SetProcessEapUpdate_In.A_hStep, FADMADS_SetProcessEapUpdate_In.D_hStep, "2");
                }

                // --

                #region MC

                eap = txtEap.Text;
                eapDesc = txtDesc.Text == string.Empty ? " " : txtDesc.Text;
                eapType = FEapType.Process.ToString();
                operMode = FEapOperationMode.Client.ToString();
                server = txtSvrName.Text;                
                // --
                fXmlNodeInEap = fXmlNodeIn.set_elem(FADMADS_SetProcessEapUpdate_In.FEap.E_Eap);
                fXmlNodeInEap.set_elemVal(FADMADS_SetProcessEapUpdate_In.FEap.A_Name, FADMADS_SetProcessEapUpdate_In.FEap.D_Name, eap);
                fXmlNodeInEap.set_elemVal(FADMADS_SetProcessEapUpdate_In.FEap.A_Description, FADMADS_SetProcessEapUpdate_In.FEap.D_Description, eapDesc);
                fXmlNodeInEap.set_elemVal(FADMADS_SetProcessEapUpdate_In.FEap.A_EapType, FADMADS_SetProcessEapUpdate_In.FEap.D_EapType, eapType);
                fXmlNodeInEap.set_elemVal(FADMADS_SetProcessEapUpdate_In.FEap.A_OperMode, FADMADS_SetProcessEapUpdate_In.FEap.D_OperMode, operMode);
                fXmlNodeInEap.set_elemVal(FADMADS_SetProcessEapUpdate_In.FEap.A_Server, FADMADS_SetProcessEapUpdate_In.FEap.D_Server, server);                

                #endregion

                // --                

                FADMADSCaster.ADMADS_SetProcessEapUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetProcessEapUpdate_Out.A_hStatus, FADMADS_SetProcessEapUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetProcessEapUpdate_Out.A_hStatusMessage, FADMADS_SetProcessEapUpdate_Out.D_hStatusMessage));
                }

                // --

                m_fEapWizardData.eap = eap;
                m_fEapWizardData.description = eapDesc;
                m_fEapWizardData.fEapType = FEapType.Process;
                m_fEapWizardData.fOperMode = FEapOperationMode.Client;
                m_fEapWizardData.server = server;
                m_fEapWizardData.step = FEapAttrCategory.Applied.ToString();

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

    }   // Class end
}   // Namespace end
