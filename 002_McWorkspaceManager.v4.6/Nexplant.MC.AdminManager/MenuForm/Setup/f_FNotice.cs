/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FNotice.cs
--  Creator         : mjkim
--  Create Date     : 2014.01.17
--  Description     : FAMate Admin Manager Setup Notice Form Class 
--  History         : Created by mjkim at 2014.01.17
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using Infragistics.Win.UltraWinDataSource;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public partial class FNotice : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------
    
        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_tranEnabled = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FNotice(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FNotice(
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        protected override void changeControlCaption(
            )
        {
            try
            {
                base.changeControlCaption();                
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

        private void refreshNotice(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            string contents = string.Empty;

            try
            {
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("system_code", FSystemCode.ADM.ToString()); 

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "Notice", "SearchNotice", fSqlParams, false);
                // --
                if (dt.Rows.Count == 0)
                {
                    return;
                }

                // --

                contents = "";
                contents += dt.Rows[0]["NTC_CONTENTS_01"].ToString();
                contents += dt.Rows[0]["NTC_CONTENTS_02"].ToString();
                contents += dt.Rows[0]["NTC_CONTENTS_03"].ToString();
                contents += dt.Rows[0]["NTC_CONTENTS_04"].ToString();
                contents += dt.Rows[0]["NTC_CONTENTS_05"].ToString();
                contents += dt.Rows[0]["NTC_CONTENTS_06"].ToString();
                contents += dt.Rows[0]["NTC_CONTENTS_07"].ToString();
                contents += dt.Rows[0]["NTC_CONTENTS_08"].ToString();
                contents += dt.Rows[0]["NTC_CONTENTS_09"].ToString();
                contents += dt.Rows[0]["NTC_CONTENTS_10"].ToString();
                contents += dt.Rows[0]["NTC_CONTENTS_11"].ToString();
                contents += dt.Rows[0]["NTC_CONTENTS_12"].ToString();
                contents += dt.Rows[0]["NTC_CONTENTS_13"].ToString();
                contents += dt.Rows[0]["NTC_CONTENTS_14"].ToString();
                contents += dt.Rows[0]["NTC_CONTENTS_15"].ToString();
                contents += dt.Rows[0]["NTC_CONTENTS_16"].ToString();
                contents += dt.Rows[0]["NTC_CONTENTS_17"].ToString();
                contents += dt.Rows[0]["NTC_CONTENTS_18"].ToString();
                contents += dt.Rows[0]["NTC_CONTENTS_19"].ToString();
                contents += dt.Rows[0]["NTC_CONTENTS_20"].ToString();

                // --

                ftxNotice.value = contents;
                ftxNotice.Tag = ftxNotice.value;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FNotice Form Event Handler

        private void FNotice_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_tranEnabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.Notice);

                // --

                btnReset.Enabled = true;
                btnUpdate.Enabled = m_tranEnabled;
                btnClear.Enabled = m_tranEnabled;

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

        private void FNotice_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshNotice();

                // --

                ftxNotice.Focus();
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

        private void FNotice_FormClosing(
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

        #region btnUpdate Control Event Handler

        private void btnUpdate_Click(
            object sender,
            EventArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInNtc = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                FCursor.waitCursor();

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetNoticeUpdate_In.E_ADMADS_SetNoticeUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetNoticeUpdate_In.A_hLanguage, FADMADS_SetNoticeUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetNoticeUpdate_In.A_hFactory, FADMADS_SetNoticeUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetNoticeUpdate_In.A_hUserId, FADMADS_SetNoticeUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetNoticeUpdate_In.A_hHostIp, FADMADS_SetNoticeUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetNoticeUpdate_In.A_hHostName, FADMADS_SetNoticeUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetNoticeUpdate_In.A_hStep, FADMADS_SetNoticeUpdate_In.D_hStep, "1");
                // --
                fXmlNodeInNtc = fXmlNodeIn.set_elem(FADMADS_SetNoticeUpdate_In.FNotice.E_Notice);
                fXmlNodeInNtc.set_elemVal(FADMADS_SetNoticeUpdate_In.FNotice.A_Contents, FADMADS_SetNoticeUpdate_In.FNotice.D_Contents, ftxNotice.value.ToString());

                // --

                FADMADSCaster.ADMADS_SetNoticeUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetNoticeUpdate_Out.A_hStatus, FADMADS_SetNoticeUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetNoticeUpdate_Out.A_hStatusMessage, FADMADS_SetNoticeUpdate_Out.D_hStatusMessage));
                }

                // --

                ftxNotice.Tag = ftxNotice.value;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInNtc = null;
                fXmlNodeOut = null;

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
                FCursor.waitCursor();

                // --

                ftxNotice.value = string.Empty;
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

        #region btnReset Control Event Handler

        private void btnReset_Click(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                ftxNotice.value = ftxNotice.Tag;
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
