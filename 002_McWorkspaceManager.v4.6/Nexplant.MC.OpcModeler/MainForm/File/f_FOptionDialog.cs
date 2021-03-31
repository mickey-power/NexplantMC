/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FOptionDialog.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.04
--  Description     : FAMate Opc Modeler Option Dialog Form Class
--  History         : Created by spike.lee at 2017.04.04
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using Infragistics.Win.UltraWinExplorerBar;
using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinEditors;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaOpcDriver;

namespace Nexplant.MC.OpcModeler
{
    public partial class FOptionDialog : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------
        
        private bool m_disposed = false;
        // -- 
        private FOpmCore m_fOpmCore = null;
        private FOptionSource m_fOptionSource = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        private FOptionDialog(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOptionDialog(
            FOpmCore fOpmCore
            )
            :this()
        {
            base.fUIWizard = fOpmCore.fUIWizard;
            m_fOpmCore = fOpmCore;
            m_fOptionSource = new FOptionSource(fOpmCore);
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
                    if (m_fOptionSource != null)
                    {
                        m_fOptionSource.Dispose();
                        m_fOptionSource = null;
                    }
                }
                m_disposed = true;

                // -- 

                base.myDispose(disposing);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FOptionDialog Form Event Handler

        private void FOptionDialog_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                #region Event Option

                m_fOptionSource.enabledEventsOfOpcDeviceState = m_fOpmCore.fOption.enabledEventsOfOpcDeviceState;
                m_fOptionSource.enabledEventsOfOpcDeviceError = m_fOpmCore.fOption.enabledEventsOfOpcDeviceError;
                m_fOptionSource.enabledEventsOfOpcDeviceTimeout = m_fOpmCore.fOption.enabledEventsOfOpcDeviceTimeout;
                m_fOptionSource.enabledEventsOfOpcDeviceDataMessage = m_fOpmCore.fOption.enabledEventsOfOpcDeviceDataMessage;
                // --
                m_fOptionSource.enabledEventsOfHostDeviceState = m_fOpmCore.fOption.enabledEventsOfHostDeviceState;
                m_fOptionSource.enabledEventsOfHostDeviceError = m_fOpmCore.fOption.enabledEventsOfHostDeviceError;                
                m_fOptionSource.enabledEventsOfHostDeviceDataMessage = m_fOpmCore.fOption.enabledEventsOfHostDeviceDataMessage;
                m_fOptionSource.enabledEventsOfHostDeviceVfei = m_fOpmCore.fOption.enabledEventsOfHostDeviceVfei;
                // --
                m_fOptionSource.enabledEventsOfScenario = m_fOpmCore.fOption.enabledEventsOfScenario;
                // --
                m_fOptionSource.enabledEventsOfApplication = m_fOpmCore.fOption.enabledEventsOfApplication;

                #endregion

                // --

                #region Log Option

                m_fOptionSource.logDirectory = m_fOpmCore.fOption.logDirectory;
                // --                
                m_fOptionSource.enabledLogOfOpc = m_fOpmCore.fOption.enabledLogOfOpc;
                m_fOptionSource.enabledLogOfVfei = m_fOpmCore.fOption.enabledLogOfVfei;                
                // --
                m_fOptionSource.maxLogFileSizeOfOpc = m_fOpmCore.fOption.maxLogFileSizeOfOpc;
                m_fOptionSource.maxLogFileSizeOfVfei = m_fOpmCore.fOption.maxLogFileSizeOfVfei;                

                #endregion

                // --

                pgdEvent.selectedObject = new FPropOptionEvent(m_fOpmCore, pgdEvent, m_fOptionSource);
                pgdLog.selectedObject = new FPropOptionLog(m_fOpmCore, pgdEvent, m_fOptionSource);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, this);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FOptionDialog_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {

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

        #region btnEventDefault Control Event Handler

        private void btnEventDefault_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                m_fOptionSource.enabledEventsOfOpcDeviceState = true;
                m_fOptionSource.enabledEventsOfOpcDeviceError = true;
                m_fOptionSource.enabledEventsOfOpcDeviceTimeout = true;
                m_fOptionSource.enabledEventsOfOpcDeviceDataMessage = true;
                // --
                m_fOptionSource.enabledEventsOfHostDeviceState = true;
                m_fOptionSource.enabledEventsOfHostDeviceError = true;
                m_fOptionSource.enabledEventsOfHostDeviceDataMessage = true;
                m_fOptionSource.enabledEventsOfHostDeviceVfei = false;
                // --
                m_fOptionSource.enabledEventsOfScenario = true;
                // --
                m_fOptionSource.enabledEventsOfApplication = true;

                // --

                pgdEvent.Refresh();
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

        #region btnLogDefault Control Event Handler

        private void btnLogDefault_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                m_fOptionSource.enabledLogOfOpc = false;
                m_fOptionSource.enabledLogOfVfei = false;
                // --
                m_fOptionSource.maxLogFileSizeOfOpc = 5 * 1024 * 1024;
                m_fOptionSource.maxLogFileSizeOfVfei = 5 * 1024 * 1024;

                // --

                pgdLog.Refresh();
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

        #region btnOk Control Event Handler

        private void btnOk_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                m_fOpmCore.fOption.enabledEventsOfOpcDeviceState = m_fOptionSource.enabledEventsOfOpcDeviceState;
                m_fOpmCore.fOption.enabledEventsOfOpcDeviceError = m_fOptionSource.enabledEventsOfOpcDeviceError;
                m_fOpmCore.fOption.enabledEventsOfOpcDeviceTimeout = m_fOptionSource.enabledEventsOfOpcDeviceTimeout;
                m_fOpmCore.fOption.enabledEventsOfOpcDeviceDataMessage = m_fOptionSource.enabledEventsOfOpcDeviceDataMessage;
                // --
                m_fOpmCore.fOption.enabledEventsOfHostDeviceState = m_fOptionSource.enabledEventsOfHostDeviceState;
                m_fOpmCore.fOption.enabledEventsOfHostDeviceError = m_fOptionSource.enabledEventsOfHostDeviceError;
                m_fOpmCore.fOption.enabledEventsOfHostDeviceDataMessage = m_fOptionSource.enabledEventsOfHostDeviceDataMessage;
                m_fOpmCore.fOption.enabledEventsOfHostDeviceVfei = m_fOptionSource.enabledEventsOfHostDeviceVfei;
                // --
                m_fOpmCore.fOption.enabledEventsOfScenario = m_fOptionSource.enabledEventsOfScenario;
                // --
                m_fOpmCore.fOption.enabledEventsOfApplication = m_fOptionSource.enabledEventsOfApplication;

                // --

                m_fOpmCore.fOption.logDirectory = m_fOptionSource.logDirectory;
                // --
                m_fOpmCore.fOption.enabledLogOfOpc = m_fOptionSource.enabledLogOfOpc;
                m_fOpmCore.fOption.enabledLogOfVfei = m_fOptionSource.enabledLogOfVfei;
                // --
                m_fOpmCore.fOption.maxLogFileSizeOfOpc = m_fOptionSource.maxLogFileSizeOfOpc;
                m_fOpmCore.fOption.maxLogFileSizeOfVfei = m_fOptionSource.maxLogFileSizeOfVfei;

                // --

                // ***
                // Opc Driver에 반영
                // ***
                m_fOpmCore.fOpmFileInfo.setOpcDriverConfig();

                // --

                this.DialogResult = DialogResult.OK;
                this.Close();
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