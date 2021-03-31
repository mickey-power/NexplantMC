/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FPasswordReset.cs
--  Creator         : spike.lee
--  Create Date     : 2017.08.08
--  Description     : FAmate Admin Manager Password Reset Form Class
--  History         : Created by spike.lee at 2017.08.08
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace Nexplant.MC.AdminManager
{
    public partial class FPasswordReset : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private string m_factory = string.Empty;
        private string m_userGroup = string.Empty;
        private string m_user = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPasswordReset(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPasswordReset(
            FAdmCore fAdmCore,
            string factory,
            string userGroup,
            string user
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
            m_factory = factory;
            m_userGroup = userGroup;
            m_user = user;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void setTitle(
            )
        {
            string caption = string.Empty;

            try
            {
                caption = m_fAdmCore.fUIWizard.searchCaption(this.Text);
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
                txtFactory.Text = m_factory;
                txtUserGroup.Text = m_userGroup;
                txtUser.Text = m_user;
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

        #region FUserPasswordReset Form Event Handler

        private void FPasswordReset_Load(
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
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
            FXmlNode fXmlNodeInUser = null;
            FXmlNode fXmlNodeOut = null;            
            string password = string.Empty;            

            try
            {
                FCursor.waitCursor();

                // --

                if (
                    FMessageBox.showQuestion(
                        FConstants.ApplicationName,
                        m_fAdmCore.fUIWizard.generateMessage("Q0022", new object[] { "Password" }),
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button2,
                        this
                        ) == DialogResult.No
                    )
                {
                    return;
                }

                // --

                fCrypt = new FCrypt();
                password = fCrypt.encrypt2(txtPass.Text);

                //// --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SysPasswordReset_In.E_ADMADS_SysPasswordReset_In);
                fXmlNodeIn.set_elemVal(FADMADS_SysPasswordReset_In.A_hLanguage, FADMADS_SysPasswordReset_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SysPasswordReset_In.A_hFactory, FADMADS_SysPasswordReset_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SysPasswordReset_In.A_hUserId, FADMADS_SysPasswordReset_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SysPasswordReset_In.A_hHostIp, FADMADS_SysPasswordReset_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SysPasswordReset_In.A_hHostName, FADMADS_SysPasswordReset_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SysPasswordReset_In.A_hStep, FADMADS_SetUserUpdate_In.D_hStep, "1"); 
                // --
                fXmlNodeInUser = fXmlNodeIn.set_elem(FADMADS_SysPasswordReset_In.FUser.E_User);
                fXmlNodeInUser.set_elemVal(
                    FADMADS_SysPasswordReset_In.FUser.A_UserId,
                    FADMADS_SysPasswordReset_In.FUser.D_UserId,
                    m_user
                    );
                fXmlNodeInUser.set_elemVal(
                    FADMADS_SysPasswordReset_In.FUser.A_CurrentUserPassword,
                    FADMADS_SysPasswordReset_In.FUser.D_CurrentUserPassword,
                    password
                    );

                // -- 

                FADMADSCaster.ADMADS_SysPasswordReset_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SysPasswordReset_Out.A_hStatus, FADMADS_SysPasswordReset_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_SysPasswordReset_Out.A_hStatusMessage, FADMADS_SysPasswordReset_Out.D_hStatusMessage)
                        );
                }

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
                fXmlNodeInUser = null;
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
