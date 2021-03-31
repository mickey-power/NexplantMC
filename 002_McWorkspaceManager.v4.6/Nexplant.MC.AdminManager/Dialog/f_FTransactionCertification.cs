/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FTransactionCertification.cs.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2013.12.11
--  Description     : FAMate Admin Manager Transaction Certification Form Class 
--  History         : Created by jungyoul.moon at 2013.12.11
 ----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public partial class FTransactionCertification : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        
        private FAdmCore m_fAdmCore = null;
        // --
        private string m_itemCode = string.Empty;
        private string m_itemCodeRevision = string.Empty;
        private string m_comment = string.Empty;
        private string m_optionText = string.Empty;
        private bool m_usedOption = false;
        private bool m_visiableItemCode = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTransactionCertification(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTransactionCertification(
            FAdmCore fAdmCore
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTransactionCertification(
            FAdmCore fAdmCore,
            bool visiableItemCode,
            bool usedOption,
            string optionText
            ) 
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
            // --
            m_visiableItemCode = visiableItemCode;
            m_usedOption = usedOption;
            m_optionText = optionText;
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

        public string ItemCode
        {
            get
            {
                try
                {
                    return m_itemCode;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string ItemCodeRevision
        {
            get
            {
                try
                {
                    return m_itemCodeRevision;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string Comment
        {
            get
            {
                try
                {
                    return m_comment;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool Option
        {
            get
            {
                try
                {
                    return chkOption.Checked;
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods


        private void setTitle(
            )
        {
            string caption = string.Empty;

            try
            {
                caption = m_fAdmCore.fWsmCore.fUIWizard.searchCaption(this.Text);
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

        private void procTransactionCertification(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInUsr = null;
            FXmlNode fXmlNodeOut = null;
            FCrypt fCrypt = null;
            string password = string.Empty;

            try
            {
                #region Validation

                if (txtItemCode.Text.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage(this.m_fAdmCore.fUIWizard.language, "E0023", new object[] { "Item Code" }));
                }

                if (txtRevision.Text.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage(this.m_fAdmCore.fUIWizard.language, "E0023", new object[] { "Item Code Revision" }));
                }

                if (txtComment.Text.Length > 400)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage(this.m_fAdmCore.fUIWizard.language, "E0023", new object[] { "Comment" }));
                }

                #endregion

                // --
                
                fCrypt = new FCrypt();

                // --

                password = fCrypt.encrypt2(txtPassword.Text);

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TrnTransactionCertification_In.E_ADMADS_TrnTransactionCertification_In);
                fXmlNodeIn.set_elemVal(FADMADS_TrnTransactionCertification_In.A_hLanguage, FADMADS_TrnTransactionCertification_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TrnTransactionCertification_In.A_hFactory, FADMADS_TrnTransactionCertification_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TrnTransactionCertification_In.A_hUserId, FADMADS_TrnTransactionCertification_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TrnTransactionCertification_In.A_hHostIp, FADMADS_TrnTransactionCertification_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_TrnTransactionCertification_In.A_hHostName, FADMADS_TrnTransactionCertification_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_TrnTransactionCertification_In.A_hStep, FADMADS_TrnTransactionCertification_In.D_hStep, "1");
                // --
                fXmlNodeInUsr = fXmlNodeIn.set_elem(FADMADS_TrnTransactionCertification_In.FUser.E_User);
                fXmlNodeInUsr.set_elemVal(FADMADS_TrnTransactionCertification_In.FUser.A_Password, FADMADS_TrnTransactionCertification_In.FUser.D_Password, password);

                // --

                FADMADSCaster.ADMADS_TrnTransactionCertification_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_TrnTransactionCertification_Out.A_hStatus, FADMADS_TrnTransactionCertification_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_TrnTransactionCertification_Out.A_hStatusMessage, FADMADS_TrnTransactionCertification_Out.D_hStatusMessage)
                        );
                }

                // --

                m_itemCode = txtItemCode.Text;
                m_itemCodeRevision = txtRevision.Text;
                // --
                m_comment = txtComment.Text;

                // --

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInUsr = null;
                fXmlNodeOut = null;
                fCrypt = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FTransactionCertification Form Event Handler

        private void FTransactionCertification_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                chkOption.Visible = m_usedOption;
                chkOption.Text = m_optionText;
                
                // --

                txtPassword.Focus();
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

        private void FTransactionCertification_Shown(
            object sender, 
            EventArgs e
            )
        {
            int prevPosY = 0;

            try
            {
                FCursor.waitCursor();

                // --

                // ***
                // Item Code를 사용하지 않을 경우 Comment 위치 이동
                // ***
                if (!m_visiableItemCode)
                {
                    pnlItemCode.Hide();

                    // --

                    prevPosY = pnlComment.Location.Y;
                    // --
                    pnlComment.Location = new System.Drawing.Point(0, 0);
                    // --
                    pnlComment.Height = pnlComment.Height + prevPosY;
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

        #region  btnOk Control Event Handler

        private void btnOk_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                procTransactionCertification();
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
