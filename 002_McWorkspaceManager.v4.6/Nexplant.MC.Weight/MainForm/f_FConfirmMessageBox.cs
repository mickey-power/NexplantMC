/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FConfirmMessageBox.cs
--  Creator         : mjkim
--  Create Date     : 2019.09.10
--  Description     : Nexplant MC Counter Confirm Message Form Class
--  History         : Created by mjkim at 2019.09.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Counter
{
    public partial class FConfirmMessageBox : Form
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private string m_confirmMessage = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FConfirmMessageBox(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FConfirmMessageBox(
            string confirmMessage
            )
            : this()
        {
            m_confirmMessage = confirmMessage;
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

        #region FConfirmMessageBox Form Event Handler

        private void FConfirmMessageBox_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                lblMessage.Text = m_confirmMessage;
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

        #region btnNo Control Event Handler

        private void btnNo_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                this.DialogResult = System.Windows.Forms.DialogResult.No;
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

        #region btnYes Control Event Handler

        private void btnYes_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
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

    }   // class end
}   // namespace end
