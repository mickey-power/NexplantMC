/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FAdsContainer.cs
--  Creator         : spike.lee
--  Create Date     : 2012.11.30
--  Description     : FAMate Admin Service Container Form Class
--  History         : Created by spike.lee at 2012.11.30
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using Miracom.FAMate.Core.FaCommon;
using Miracom.FAMate.SqlService;

namespace Miracom.FAMate.SqlServiceContainer
{
    public partial class FSqsContainer : Form
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSqsMain m_fSqsMain = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSqsContainer(
            )
        {
            InitializeComponent();
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

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void procRestart(
            )
        {
            try
            {
                if (m_fSqsMain == null)
                {
                    return;
                }

                // --

                // ***
                // 기존 Admin Service Main Object Terminate
                // ***            
                m_fSqsMain.term();
                // --
                m_fSqsMain.Dispose();
                m_fSqsMain = null;

                // --

                // ***
                // 새로운 Sql Service Main Object Create
                // ***
                m_fSqsMain = new FSqsMain();
                // --
                m_fSqsMain.init();
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

        #region FSqsContainer Form Event Handler

        private void FSqsContainer_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                m_fSqsMain = new FSqsMain();
                // --                
                m_fSqsMain.init();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, this);
                // --
                this.BeginInvoke(new MethodInvoker(
                    delegate()
                    {
                        this.Close();
                    }
                ));
            }
            finally
            {

            }
        }        

        //------------------------------------------------------------------------------------------------------------------------

        private void FAdsContainer_FormClosing(
            object sender,
            FormClosingEventArgs e
            )
        {
            try
            {
                if (m_fSqsMain != null)
                {
                    m_fSqsMain.term();
                    // --
                    m_fSqsMain.Dispose();                    
                    m_fSqsMain = null;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, this);
            }
            finally
            {

            }
        }

        #endregion
               
        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
