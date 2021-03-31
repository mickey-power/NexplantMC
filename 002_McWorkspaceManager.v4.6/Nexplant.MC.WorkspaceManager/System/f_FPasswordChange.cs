/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FPasswordChange.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2014.08.14
--  Description     : FAMate Workspace Manager Password Chagne Form Class
--  History         : Created by jungyoul.moon at 2014.08.14
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace Nexplant.MC.WorkspaceManager
{
    public partial class FPasswordChange : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FWsmCore m_fWsmCore = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPasswordChange(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPasswordChange(
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

        //------------------------------------------------------------------------------------------------------------------------

        private void initUserInfo(
            )
        {
            try
            {
                txtFactory.Text = m_fWsmCore.fOption.factory;
                txtUserGroup.Text = m_fWsmCore.fOption.userGroup;
                txtUser.Text = m_fWsmCore.fOption.user;
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

        #region FUserPasswordChange Form Event Handler

        private void FPasswordChange_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                initUserInfo();
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
            // --
            FXmlNode fXmlNodeIn = null;  
            FXmlNode fXmlNodeInPas = null;
            FXmlNode fXmlNodeOut = null;            
            string oldPassword = string.Empty;
            string newPassword = string.Empty;            

            try
            {
                FCursor.waitCursor();

                // --

                #region Validation

                if (txtNewPass.Text.Length > 50)
                {
                    FDebug.throwFException(m_fWsmCore.fUIWizard.generateMessage("E0023", new object[] { "Password" }));
                }

                // --

                if (txtNewPass.Text != txtConPass.Text)
                {
                    FDebug.throwFException(m_fWsmCore.fUIWizard.generateMessage("E0026", new object[] { "New Password", "Confrim Password" }));
                }

                #endregion

                // --

                fCrypt = new FCrypt();
                oldPassword = fCrypt.encrypt2(txtOldPass.Text);
                newPassword = fCrypt.encrypt2(txtNewPass.Text);

                // --

                fXmlNodeIn = FCommon.createXmlNode(FWSMADS_SysPasswordChange_In.E_WSMADS_SysPasswordChange_In);
                fXmlNodeIn.set_elemVal(FWSMADS_SysPasswordChange_In.A_hLanguage, FWSMADS_SysPasswordChange_In.D_hLanguage, m_fWsmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FWSMADS_SysPasswordChange_In.A_hStep, FWSMADS_SysPasswordChange_In.D_hStep, "1");
                fXmlNodeIn.set_elemVal(FWSMADS_SysPasswordChange_In.A_hFactory, FWSMADS_SysPasswordChange_In.D_hFactory, m_fWsmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FWSMADS_SysPasswordChange_In.A_hHostIp, FWSMADS_SysPasswordChange_In.D_hHostIp, m_fWsmCore.fOption.hostIP);
                fXmlNodeIn.set_elemVal(FWSMADS_SysPasswordChange_In.A_hHostName, FWSMADS_SysPasswordChange_In.D_hHostName, m_fWsmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FWSMADS_SysPasswordChange_In.A_hUserId, FWSMADS_SysPasswordChange_In.D_hUserId, m_fWsmCore.fOption.user);
                // --
                fXmlNodeInPas = fXmlNodeIn.set_elem(FWSMADS_SysPasswordChange_In.FPassword.E_Password);
                fXmlNodeInPas.set_elemVal(
                    FWSMADS_SysPasswordChange_In.FPassword.A_OldPassword,
                    FWSMADS_SysPasswordChange_In.FPassword.D_OldPassword,
                    oldPassword
                    );
                fXmlNodeInPas.set_elemVal(
                    FWSMADS_SysPasswordChange_In.FPassword.A_NewPassword,
                    FWSMADS_SysPasswordChange_In.FPassword.D_NewPassword,
                    newPassword
                    );

                // -- 

                FWSMADSCaster.WSMADS_SysPasswordChange_Req(
                    m_fWsmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FWSMADS_SysPasswordChange_Out.A_hStatus, FWSMADS_SysPasswordChange_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FWSMADS_SysPasswordChange_Out.A_hStatusMessage, FWSMADS_SysPasswordChange_Out.D_hStatusMessage)
                        );
                }

                // --
                
                FMessageBox.showInformation("Password Change", m_fWsmCore.fUIWizard.generateMessage("M0007", new object[] { "Password" }), this);
                
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
                fXmlNodeIn = null;
                fXmlNodeInPas = null;
                fXmlNodeOut = null;
                
                // --
                
                if (fCrypt != null)
                {
                    fCrypt.Dispose();
                    fCrypt = null;
                }                

                // --

                FCursor.defaultCursor();                
            }
        }

        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
