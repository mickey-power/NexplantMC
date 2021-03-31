/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FNotification.cs
--  Creator         : mjkim
--  Create Date     : 2014.01.23
--  Description     : FAMate Admin Manager Notification Form Class 
--  History         : Created by mjkim at 2014.01.23
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Net;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public partial class FNotification : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private string m_noticeUpdateTime = string.Empty;
        private string m_contents = string.Empty;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FNotification(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FNotification(
            FAdmCore fAdmCore,
            string noticeUpdateTime,
            string contents
            ) 
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
            // --
            m_noticeUpdateTime = noticeUpdateTime;
            m_contents = contents;
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

        private void updateUserNotice(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInUsr = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SysUserNoticeUpdate_In.E_ADMADS_SysUserNoticeUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SysUserNoticeUpdate_In.A_hLanguage, FADMADS_SysUserNoticeUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SysUserNoticeUpdate_In.A_hFactory, FADMADS_SysUserNoticeUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SysUserNoticeUpdate_In.A_hUserId, FADMADS_SysUserNoticeUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SysUserNoticeUpdate_In.A_hHostIp, FADMADS_SysUserNoticeUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SysUserNoticeUpdate_In.A_hHostName, FADMADS_SysUserNoticeUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SysUserNoticeUpdate_In.A_hStep, FADMADS_SysUserNoticeUpdate_In.D_hStep, "1");
                // --
                fXmlNodeInUsr = fXmlNodeIn.set_elem(FADMADS_SysUserNoticeUpdate_In.FUser.E_User);
                fXmlNodeInUsr.set_elemVal(FADMADS_SysUserNoticeUpdate_In.FUser.A_UserId, FADMADS_SysUserNoticeUpdate_In.FUser.D_UserId, m_fAdmCore.fOption.user);
                fXmlNodeInUsr.set_elemVal(FADMADS_SysUserNoticeUpdate_In.FUser.A_LastNoticeTime, FADMADS_SysUserNoticeUpdate_In.FUser.D_LastNoticeTime, m_noticeUpdateTime);

                // --

                FADMADSCaster.ADMADS_SysUserNoticeUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SysUserNoticeUpdate_Out.A_hStatus, FADMADS_SysUserNoticeUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_SysUserNoticeUpdate_Out.A_hStatusMessage, FADMADS_SysUserNoticeUpdate_Out.D_hStatusMessage)
                        );
                }
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
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FNotification Form Event Handler

        private void FNotification_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                ftxNotice.Value = m_contents;

                // --

                updateUserNotice();
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
