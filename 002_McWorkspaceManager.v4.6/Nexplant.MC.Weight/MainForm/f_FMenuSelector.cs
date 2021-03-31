/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FMenuSelector.cs
--  Creator         : mjkim
--  Create Date     : 2019.09.10
--  Description     : Nexplant MC Counter Menu Selector Form Class
--  History         : Created by mjkim at 2019.09.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaSecs1ToHsms;

namespace Nexplant.MC.Counter
{
    public partial class FMenuSelector : Form
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FCntCore m_fCntCore = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FMenuSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FMenuSelector(
            FCntCore fCntCore
            )
            : this()
        {
            m_fCntCore = fCntCore;
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    m_fCntCore = null;
                }
            }

            m_disposed = true;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Proeprties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods
        
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FMenuSelecter Form Event Handler

        private void FMenuSelecter_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                if (m_fCntCore.fSecs1ToHsms.fSecs1State == FCommunicationState.Closed)
                {
                    btnSecs1Open.Enabled = true;
                    btnSecs1Close.Enabled = false;
                    btnSecs1Option.Enabled = true;
                }
                else
                {
                    btnSecs1Open.Enabled = false;
                    btnSecs1Close.Enabled = true;
                    btnSecs1Option.Enabled = false;
                }

                // --

                if (m_fCntCore.fSecs1ToHsms.fHsmsState == FCommunicationState.Closed)
                {
                    btnHsmsOpen.Enabled = true;
                    btnHsmsClose.Enabled = false;
                    btnHsmsOption.Enabled = true;
                }
                else
                {
                    btnHsmsOpen.Enabled = false;
                    btnHsmsClose.Enabled = true;
                    btnHsmsOption.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnClose Control Event Handler

        private void btnClose_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnSecs1Open Control Event Handler

        private void btnSecs1Open_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                m_fCntCore.setSecs1Option();
                m_fCntCore.fSecs1ToHsms.openSecs1();

                // --

                btnSecs1Open.Enabled = false;
                btnSecs1Close.Enabled = true;
                btnSecs1Option.Enabled = false;
            }
            catch (Exception ex)
            {
                FCommon.showErrorMessageBox(this, ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnSecs1Close Control Event Handler

        private void btnSecs1Close_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                m_fCntCore.fSecs1ToHsms.closeSecs1();

                // --

                btnSecs1Open.Enabled = true;
                btnSecs1Close.Enabled = false;
                btnSecs1Option.Enabled = true;
            }
            catch (Exception ex)
            {
                FCommon.showErrorMessageBox(this, ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnSecs1Option Control Event Handler

        private void btnSecs1Option_Click(
            object sender, 
            EventArgs e
            )
        {
            FSecs1OptionDialog fDialog = null;

            try
            {
                fDialog = new FSecs1OptionDialog(m_fCntCore);
                fDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                FCommon.showErrorMessageBox(this, ex);
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

        #region btnHsmsOpen Control Event Handler

        private void btnHsmsOpen_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                m_fCntCore.setHsmsOption();
                m_fCntCore.fSecs1ToHsms.openHsms();

                // --

                btnHsmsOpen.Enabled = false;
                btnHsmsClose.Enabled = true;
                btnHsmsOption.Enabled = false;
            }
            catch (Exception ex)
            {
                FCommon.showErrorMessageBox(this, ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnHsmsClose Control Event Handler

        private void btnHsmsClose_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                m_fCntCore.fSecs1ToHsms.closeHsms();

                // --

                btnHsmsOpen.Enabled = true;
                btnHsmsClose.Enabled = false;
                btnHsmsOption.Enabled = true;
            }
            catch (Exception ex)
            {
                FCommon.showErrorMessageBox(this, ex);
            }
            finally
            {

            }
        }

        #endregion 

        //------------------------------------------------------------------------------------------------------------------------

        #region btnHsmsOption Control Event Handler

        private void btnHsmsOption_Click(
            object sender, 
            EventArgs e
            )
        {
            FHsmsOptionDialog fDialog = null;

            try
            {
                fDialog = new FHsmsOptionDialog(m_fCntCore);
                fDialog.ShowDialog(this);
            }
            catch (Exception ex)
            {
                FCommon.showErrorMessageBox(this, ex);
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

        #region btnMonitoring Control Event Handler

        private void btnMonitoring_Click(
            object sender, 
            EventArgs e
            )
        {
            FMonitoring fDialog = null;

            try
            {
                fDialog = new FMonitoring(m_fCntCore);
                fDialog.ShowDialog(this);
            }
            catch (Exception ex)
            {
                FCommon.showErrorMessageBox(this, ex);
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

    }   // class end
}   // namespace end
