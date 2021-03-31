/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FReplaceNameDialog.cs
--  Creator         : spike.lee
--  Create Date     : 2016.04.25
--  Description     : FAMate SECS Modeler Replace Name Dialog Form Class
--  History         : Created by spike.lee at 2016.04.24
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace Nexplant.MC.SecsModeler
{
    public partial class FReplaceNameDialog : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSsmCore m_fSsmCore = null;
        private string m_findWhat = string.Empty;
        private string m_replaceWith = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FReplaceNameDialog(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FReplaceNameDialog(
            FSsmCore fSsmCore,
            string findWhat
            )
            : this()
        {
            base.fUIWizard = fSsmCore.fUIWizard;
            m_fSsmCore = fSsmCore;
            m_findWhat = findWhat;
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
                    m_fSsmCore = null;
                }
                m_disposed = true;
            }
        }

        #endregion  

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public string findWhat
        {
            get
            {
                try
                {
                    return m_findWhat;
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

        public string replaceWith
        {
            get
            {
                try
                {
                    return m_replaceWith;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void setTitle(
            )
        {
            string caption = string.Empty;

            try
            {
                caption = m_fSsmCore.fUIWizard.searchCaption(this.Text);
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

        #region FUserPasswordChange Form Event Handler

        private void FPasswordChange_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                txtFindWhat.Text = m_findWhat;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
            try
            {
                FCursor.waitCursor();

                // --

                if (txtFindWhat.Text == string.Empty)
                {
                    FDebug.throwFException(
                        m_fSsmCore.fWsmCore.fUIWizard.generateMessage("E0004", new object[] { "Find What" })
                        );
                }

                // --

                m_findWhat = txtFindWhat.Text;
                m_replaceWith = txtReplaceWith.Text;
                
                // --

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
