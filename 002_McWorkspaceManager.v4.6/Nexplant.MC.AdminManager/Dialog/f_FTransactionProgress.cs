/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FTransactionProgress.cs
--  Creator         : spike.lee
--  Create Date     : 2012.05.31
--  Description     : FAMate Admin Manager Transaction Progress Dialog Form Class 
--  History         : Created by spike.lee at 2012.05.31
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager
{
    public partial class FTransactionProgress : FBaseForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private FITransaction m_fParent = null;
        private string m_displayMessage = string.Empty;
        private bool m_cancelEnabled = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTransactionProgress(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTransactionProgress(
            FAdmCore fAdmCore,
            FITransaction fParent,
            string displayMessage,
            bool cancelEnabled
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
            m_fParent = fParent;
            m_displayMessage = displayMessage;
            m_cancelEnabled = cancelEnabled;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTransactionProgress(
            FAdmCore fAdmCore,
            FITransaction fParent,
            string displayMessage
            )
            : this(fAdmCore, fParent, displayMessage, true)
        {
            
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

        private void procProcess(
            )
        {
            try
            {
                m_fParent.action();

                // --

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

        #region FTransactionProgress Form Event Handler

        private void FTransactionProgress_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                lblMsg.Text = m_displayMessage;
                btnCancel.Enabled = m_cancelEnabled;

                // --

                this.BeginInvoke(new MethodInvoker(
                    delegate()
                    {
                        procProcess();
                    }
                ));
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

        #region btnCanel Control Event Handler

        private void btnCancel_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                m_fParent.cancel = true;
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
