/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FUserLogIn.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2014.08.08
--  Description     : FAMate Workspace Manager User Log-In Form Class 
--  History         : Created by jungyoul.moon at 2014.08.08
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Net;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.WorkspaceManager
{
    public partial class FUserLogIn : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FWsmCore m_fWsmCore = null;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FUserLogIn(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FUserLogIn(
            FWsmCore fWsmCore
            ) 
            : this()
        {
            base.fUIWizard = fWsmCore.fUIWizard;
            m_fWsmCore = fWsmCore;
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
                    m_fWsmCore = null;
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

        private void setTitle(
            )
        {
            string caption = string.Empty;

            try
            {
                caption = m_fWsmCore.fUIWizard.searchCaption(this.Text);
                this.Text = caption;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FUeserLogIn Form Event Handler

        private void FUserLogIn_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fWsmCore.termH101();

                // --

                txtSite.Text = m_fWsmCore.fOption.site;
                txtFactory.Text = m_fWsmCore.fOption.factory;
                txtDescription.Text = m_fWsmCore.fOption.description;
                chkIdSave.Checked = m_fWsmCore.fOption.checkedIdSave;
                // --
                if (chkIdSave.Checked == true)
                {
                    txtUserId.Text = m_fWsmCore.fOption.user;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FUserLogIn_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                if (txtUserId.Text.Trim().Length != 0)
                {
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fWsmCore.fWsmContainer);
            }
            finally
            {
 
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
            FCrypt fCrypt = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInLgi = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutUsr = null;
            string password = string.Empty;
            string hostName = string.Empty;
            string ipAddress = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                #region Validation

                FCommon.validateName(txtUserId.Text, true, m_fWsmCore.fUIWizard, "User ID");

                #endregion

                // --                

                fCrypt = new FCrypt();
                password = fCrypt.encrypt2(txtPassword.Text);
                hostName = FUserPCInfo.ComputerName;
                ipAddress = FUserPCInfo.getIPAddress();

                // --

                m_fWsmCore.initH101();

                // --

                fXmlNodeIn = FCommon.createXmlNode(FWSMADS_SysUserLogIn_In.E_WSMADS_SysUserLogIn_In);
                fXmlNodeIn.set_elemVal(FWSMADS_SysUserLogIn_In.A_hLanguage, FWSMADS_SysUserLogIn_In.D_hLanguage, m_fWsmCore.fOption.language.ToString());
                fXmlNodeIn.set_elemVal(FWSMADS_SysUserLogIn_In.A_hFactory, FWSMADS_SysUserLogIn_In.D_hFactory, txtFactory.Text);
                fXmlNodeIn.set_elemVal(FWSMADS_SysUserLogIn_In.A_hUserId, FWSMADS_SysUserLogIn_In.D_hUserId, txtUserId.Text);
                fXmlNodeIn.set_elemVal(FWSMADS_SysUserLogIn_In.A_hHostName, FWSMADS_SysUserLogIn_In.D_hHostName, hostName);
                fXmlNodeIn.set_elemVal(FWSMADS_SysUserLogIn_In.A_hHostIp, FWSMADS_SysUserLogIn_In.D_hHostIp, ipAddress);
                fXmlNodeIn.set_elemVal(FWSMADS_SysUserLogIn_In.A_hStep, FWSMADS_SysUserLogIn_In.D_hStep, "1");
                // --
                fXmlNodeInLgi = fXmlNodeIn.set_elem(FWSMADS_SysUserLogIn_In.FLogIn.E_LogIn);
                fXmlNodeInLgi.set_elemVal(FWSMADS_SysUserLogIn_In.FLogIn.A_UserId, FWSMADS_SysUserLogIn_In.FLogIn.D_UserId, txtUserId.Text);
                fXmlNodeInLgi.set_elemVal(FWSMADS_SysUserLogIn_In.FLogIn.A_Password, FWSMADS_SysUserLogIn_In.FLogIn.D_Password, password);

                // --

                FWSMADSCaster.WSMADS_SysLogIn_Req(
                    m_fWsmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FWSMADS_SysUserLogIn_Out.A_hStatus, FWSMADS_SysUserLogIn_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FWSMADS_SysUserLogIn_Out.A_hStatusMessage, FWSMADS_SysUserLogIn_Out.D_hStatusMessage)
                        );
                }

                // --

                fXmlNodeOutUsr = fXmlNodeOut.get_elem(FWSMADS_SysUserLogIn_Out.FUser.E_User);
                // --
                m_fWsmCore.fOption.checkedIdSave = chkIdSave.Checked;
                m_fWsmCore.fOption.user = txtUserId.Text;
                m_fWsmCore.fOption.userName = fXmlNodeOutUsr.get_elemVal(FWSMADS_SysUserLogIn_Out.FUser.A_UserName, FWSMADS_SysUserLogIn_Out.FUser.D_UserName);
                m_fWsmCore.fOption.userGroup = fXmlNodeOutUsr.get_elemVal(FWSMADS_SysUserLogIn_Out.FUser.A_UserGroup, FWSMADS_SysUserLogIn_Out.FUser.D_UserGroup);
                
                // --

                m_fWsmCore.fOption.isLogIn = true;
                m_fWsmCore.fOption.hostIP = ipAddress;
                m_fWsmCore.fOption.hostName = hostName;

                // --

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fWsmCore.fWsmContainer);
            }
            finally
            {
                fCrypt = null;
                fXmlNodeIn = null;
                fXmlNodeInLgi = null;
                fXmlNodeOut = null;
                fXmlNodeOutUsr = null;

                // --

                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnOption Control Event Handler

        private void btnOption_Click(
            object sender, 
            EventArgs e
            )
        {
            FUserLogInOptionDialog fDialog = null;

            try
            {
                FCursor.waitCursor();

                // --

                m_fWsmCore.termH101();

                // --

                fDialog = new FUserLogInOptionDialog(m_fWsmCore);
                // --
                if (fDialog.ShowDialog(this) == DialogResult.OK)
                {
                    txtSite.Text = m_fWsmCore.fOption.site;
                    txtFactory.Text = m_fWsmCore.fOption.factory;
                    txtDescription.Text = m_fWsmCore.fOption.description;
                    if (chkIdSave.Checked)
                    {
                        txtUserId.Text = m_fWsmCore.fOption.user;
                        chkIdSave.Checked = m_fWsmCore.fOption.checkedIdSave;
                    }
                    // --
                    m_fWsmCore.fOption.save();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fWsmCore.fWsmContainer);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
