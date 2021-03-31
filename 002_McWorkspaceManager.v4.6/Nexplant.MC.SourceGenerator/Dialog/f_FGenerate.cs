/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FGenerate.cs
--  Creator         : baehyun seo
--  Create Date     : 2011.10.14
--  Description     : FAMate Source Generator Option Form Class
--  History         : Created by baehyun seo at 2011.10.14
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.SourceGenerator
{
    public partial class FGenerate : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm, IDisposable
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FScgCore m_fScgCore = null;                             
           
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FGenerate(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FGenerate(
            FScgCore fScgCore            
            )
            : this()
        {
            base.fUIWizard = fScgCore.fUIWizard;
            m_fScgCore = fScgCore;            
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
                    m_fScgCore = null;
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


        public void loadOptionInfo(            
            )
        {
            try
            {
                // ***
                // Source Generator Option Load
                // ***                
                txtSavePath.Text = m_fScgCore.fOption.optionSavePath;
                txtCreator.Text = m_fScgCore.fOption.optionCreator;
                txtDescription.Text = m_fScgCore.fOption.optionDescription;
                txtCopyright.Text = m_fScgCore.fOption.optionCopyright;
                txtUsingNamespace.Text = m_fScgCore.fOption.optionUsingNamespace;
                // --
                checkParameters.Checked = m_fScgCore.fOption.paramGenerator;
                checkFunction.Checked = m_fScgCore.fOption.funcGenerator;
                checkH101BaseCode.Checked = m_fScgCore.fOption.h101BaseGenerator;
                checkInternalClass.Checked = m_fScgCore.fOption.internalClass;
                checkOldFilesClear.Checked = m_fScgCore.fOption.oldFilesClear;
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

        #region FGenerator Form Event Handler

        private void FGenerator_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {                   
                loadOptionInfo();              
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fScgCore.fWsmCore.fWsmContainer);
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
                // ***
                // Update
                // ***
                m_fScgCore.fOption.optionSavePath = txtSavePath.Text;
                m_fScgCore.fOption.optionCreator = txtCreator.Text;
                m_fScgCore.fOption.optionDescription = txtDescription.Text;
                m_fScgCore.fOption.optionCopyright = txtCopyright.Text;
                m_fScgCore.fOption.optionUsingNamespace = txtUsingNamespace.Text;
                m_fScgCore.fOption.paramGenerator = checkParameters.Checked;
                m_fScgCore.fOption.funcGenerator = checkFunction.Checked;
                m_fScgCore.fOption.h101BaseGenerator = checkH101BaseCode.Checked;
                m_fScgCore.fOption.internalClass = checkInternalClass.Checked;
                m_fScgCore.fOption.oldFilesClear = checkOldFilesClear.Checked;

                this.DialogResult = DialogResult.OK;
                this.Close(); 
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fScgCore.fWsmCore.fWsmContainer);
            }
            finally
            {
 
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnCancel Control Event Handler

        private void btnCancel_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fScgCore.fWsmCore.fWsmContainer);
            }
            finally
            {
 
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region txtSavePath Control Event Handler

        private void txtSavePath_EditorButtonClick(
            object sender, 
            Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e
            )
        {
            FolderBrowserDialog dialog = null;

            try
            {
                dialog = new FolderBrowserDialog();
                dialog.SelectedPath = txtSavePath.Text;
                if (dialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                txtSavePath.Text = dialog.SelectedPath;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fScgCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                if (dialog != null)
                {
                    dialog.Dispose();
                    dialog = null;
                }
            }
        }

        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
