/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FRecentNotice.cs
--  Creator         : mjkim
--  Create Date     : 2014.01.17
--  Description     : FAMate Admin Manager Recent Notice Form Class 
--  History         : Created by mjkim at 2014.01.17
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager
{
    public partial class FRecentNotice : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FRecentNotice(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FRecentNotice(
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
                base.fUIWizard.changeControlCaption(mnuMenu);
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
                base.fUIWizard.changeControlFontName(mnuMenu);
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

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "RecentNotice", "SearchNotice", fSqlParams, false);
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

                ftxNotice.Value = contents;

                // --

                ftxNotice.Focus();
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

        #region FRecentNotice Form Event Handler

        private void FRecentNotice_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

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

        private void FRecentNotice_FormClosing(
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

        //------------------------------------------------------------------------------------------------------------------------        

        private void FRecentNotice_Enter(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

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

        private void FRecentNotice_Shown(
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

        private void FRecentNotice_KeyDown(
            object sender, 
            KeyEventArgs e
            )
        {
            try
            {
                if (e.KeyCode == Keys.F5)
                {
                    FCursor.waitCursor();
                    // --
                    refreshNotice();
                    // --
                    FCursor.defaultCursor();
                }
            }
            catch (Exception ex)
            {
                FCursor.defaultCursor();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------        

        #region mnuMenu Control Event Handler

        private void mnuMenu_ToolClick(
            object sender,
            Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tool.Key == FMenuKey.MenuRntRefresh)
                {
                    refreshNotice();
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
