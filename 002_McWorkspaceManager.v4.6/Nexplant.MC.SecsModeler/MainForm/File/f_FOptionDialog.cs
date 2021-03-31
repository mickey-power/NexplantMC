/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FOptionDialog.cs
--  Creator         : spike.lee
--  Create Date     : 2012.11.19
--  Description     : FAMate SECS Modeler Option Dialog Form Class
--  History         : Created by spike.lee at 2012.11.19
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using Infragistics.Win.UltraWinExplorerBar;
using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinEditors;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaSecsDriver;

namespace Nexplant.MC.SecsModeler
{
    public partial class FOptionDialog : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------
        
        private bool m_disposed = false;
        // -- 
        private FSsmCore m_fSsmCore = null;
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
            FSsmCore fSsmCore
            )
            :this()
        {
            base.fUIWizard = fSsmCore.fUIWizard;
            m_fSsmCore = fSsmCore;
            m_fOptionSource = new FOptionSource(fSsmCore);
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

                m_fOptionSource.enabledEventsOfSecsDeviceState = m_fSsmCore.fOption.enabledEventsOfSecsDeviceState;
                m_fOptionSource.enabledEventsOfSecsDeviceError = m_fSsmCore.fOption.enabledEventsOfSecsDeviceError;
                m_fOptionSource.enabledEventsOfSecsDeviceTimeout = m_fSsmCore.fOption.enabledEventsOfSecsDeviceTimeout;
                m_fOptionSource.enabledEventsOfSecsDeviceData = m_fSsmCore.fOption.enabledEventsOfSecsDeviceData;
                m_fOptionSource.enabledEventsOfSecsDeviceTelnet = m_fSsmCore.fOption.enabledEventsOfSecsDeviceTelnet;
                m_fOptionSource.enabledEventsOfSecsDeviceHandshake = m_fSsmCore.fOption.enabledEventsOfSecsDeviceHandshake;
                m_fOptionSource.enabledEventsOfSecsDeviceControlMessage = m_fSsmCore.fOption.enabledEventsOfSecsDeviceControlMessage;
                m_fOptionSource.enabledEventsOfSecsDeviceBlock = m_fSsmCore.fOption.enabledEventsOfSecsDeviceBlock;
                m_fOptionSource.enabledEventsOfSecsDeviceSml = m_fSsmCore.fOption.enabledEventsOfSecsDeviceSml;
                m_fOptionSource.enabledEventsOfSecsDeviceDataMessage = m_fSsmCore.fOption.enabledEventsOfSecsDeviceDataMessage;
                // --
                m_fOptionSource.enabledEventsOfHostDeviceState = m_fSsmCore.fOption.enabledEventsOfHostDeviceState;
                m_fOptionSource.enabledEventsOfHostDeviceError = m_fSsmCore.fOption.enabledEventsOfHostDeviceError;                
                m_fOptionSource.enabledEventsOfHostDeviceDataMessage = m_fSsmCore.fOption.enabledEventsOfHostDeviceDataMessage;
                m_fOptionSource.enabledEventsOfHostDeviceVfei = m_fSsmCore.fOption.enabledEventsOfHostDeviceVfei;
                // --
                m_fOptionSource.enabledEventsOfScenario = m_fSsmCore.fOption.enabledEventsOfScenario;
                // --
                m_fOptionSource.enabledEventsOfApplication = m_fSsmCore.fOption.enabledEventsOfApplication;
                
                #endregion

                // --

                #region Log Option

                m_fOptionSource.logDirectory = m_fSsmCore.fOption.logDirectory;
                // --                
                m_fOptionSource.enabledLogOfSecs = m_fSsmCore.fOption.enabledLogOfSecs;
                m_fOptionSource.enabledLogOfBinary = m_fSsmCore.fOption.enabledLogOfBinary;
                m_fOptionSource.enabledLogOfSml = m_fSsmCore.fOption.enabledLogOfSml;
                m_fOptionSource.enabledLogOfVfei = m_fSsmCore.fOption.enabledLogOfVfei;                
                // --
                m_fOptionSource.maxLogFileSizeOfSecs = m_fSsmCore.fOption.maxLogFileSizeOfSecs;
                m_fOptionSource.maxLogFileSizeOfBinary = m_fSsmCore.fOption.maxLogFileSizeOfBinary;
                m_fOptionSource.maxLogFileSizeOfSml = m_fSsmCore.fOption.maxLogFileSizeOfSml;
                m_fOptionSource.maxLogFileSizeOfVfei = m_fSsmCore.fOption.maxLogFileSizeOfVfei;                

                #endregion

                // --
                #region UI
                m_fOptionSource.dragDropConfirm = m_fSsmCore.fOption.dragDropConfirm;

                #endregion

                // --

                pgdEvent.selectedObject = new FPropOptionEvent(m_fSsmCore, pgdEvent, m_fOptionSource);
                pgdLog.selectedObject = new FPropOptionLog(m_fSsmCore, pgdEvent, m_fOptionSource);
                pgdUi.selectedObject = new FPropOptionUi(m_fSsmCore, pgdUi, m_fOptionSource);
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
                m_fOptionSource.enabledEventsOfSecsDeviceState = true;
                m_fOptionSource.enabledEventsOfSecsDeviceError = true;
                m_fOptionSource.enabledEventsOfSecsDeviceTimeout = true;
                m_fOptionSource.enabledEventsOfSecsDeviceControlMessage = true;
                m_fOptionSource.enabledEventsOfSecsDeviceDataMessage = true;
                m_fOptionSource.enabledEventsOfSecsDeviceData = false;
                m_fOptionSource.enabledEventsOfSecsDeviceSml = false;
                m_fOptionSource.enabledEventsOfSecsDeviceTelnet = false;
                m_fOptionSource.enabledEventsOfSecsDeviceHandshake = false;
                m_fOptionSource.enabledEventsOfSecsDeviceBlock = false;
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
                m_fOptionSource.enabledLogOfSecs = false;
                m_fOptionSource.enabledLogOfBinary = false;
                m_fOptionSource.enabledLogOfSml = false;
                m_fOptionSource.enabledLogOfVfei = false;
                // --
                m_fOptionSource.maxLogFileSizeOfSecs = 5 * 1024 * 1024;
                m_fOptionSource.maxLogFileSizeOfBinary = 5 * 1024 * 1024;
                m_fOptionSource.maxLogFileSizeOfSml = 5 * 1024 * 1024;
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
                m_fSsmCore.fOption.enabledEventsOfSecsDeviceState = m_fOptionSource.enabledEventsOfSecsDeviceState;
                m_fSsmCore.fOption.enabledEventsOfSecsDeviceError = m_fOptionSource.enabledEventsOfSecsDeviceError;
                m_fSsmCore.fOption.enabledEventsOfSecsDeviceTimeout = m_fOptionSource.enabledEventsOfSecsDeviceTimeout;
                m_fSsmCore.fOption.enabledEventsOfSecsDeviceControlMessage = m_fOptionSource.enabledEventsOfSecsDeviceControlMessage;
                m_fSsmCore.fOption.enabledEventsOfSecsDeviceDataMessage = m_fOptionSource.enabledEventsOfSecsDeviceDataMessage;
                m_fSsmCore.fOption.enabledEventsOfSecsDeviceData = m_fOptionSource.enabledEventsOfSecsDeviceData;
                m_fSsmCore.fOption.enabledEventsOfSecsDeviceSml = m_fOptionSource.enabledEventsOfSecsDeviceSml;
                m_fSsmCore.fOption.enabledEventsOfSecsDeviceTelnet = m_fOptionSource.enabledEventsOfSecsDeviceTelnet;
                m_fSsmCore.fOption.enabledEventsOfSecsDeviceHandshake = m_fOptionSource.enabledEventsOfSecsDeviceHandshake;
                m_fSsmCore.fOption.enabledEventsOfSecsDeviceBlock = m_fOptionSource.enabledEventsOfSecsDeviceBlock;
                // --
                m_fSsmCore.fOption.enabledEventsOfHostDeviceState = m_fOptionSource.enabledEventsOfHostDeviceState;
                m_fSsmCore.fOption.enabledEventsOfHostDeviceError = m_fOptionSource.enabledEventsOfHostDeviceError;
                m_fSsmCore.fOption.enabledEventsOfHostDeviceDataMessage = m_fOptionSource.enabledEventsOfHostDeviceDataMessage;
                m_fSsmCore.fOption.enabledEventsOfHostDeviceVfei = m_fOptionSource.enabledEventsOfHostDeviceVfei;
                // --
                m_fSsmCore.fOption.enabledEventsOfScenario = m_fOptionSource.enabledEventsOfScenario;
                // --
                m_fSsmCore.fOption.enabledEventsOfApplication = m_fOptionSource.enabledEventsOfApplication;

                // --

                m_fSsmCore.fOption.logDirectory = m_fOptionSource.logDirectory;
                // --
                m_fSsmCore.fOption.enabledLogOfSecs = m_fOptionSource.enabledLogOfSecs;
                m_fSsmCore.fOption.enabledLogOfBinary = m_fOptionSource.enabledLogOfBinary;
                m_fSsmCore.fOption.enabledLogOfSml = m_fOptionSource.enabledLogOfSml;
                m_fSsmCore.fOption.enabledLogOfVfei = m_fOptionSource.enabledLogOfVfei;
                // --
                m_fSsmCore.fOption.maxLogFileSizeOfSecs = m_fOptionSource.maxLogFileSizeOfSecs;
                m_fSsmCore.fOption.maxLogFileSizeOfBinary = m_fOptionSource.maxLogFileSizeOfBinary;
                m_fSsmCore.fOption.maxLogFileSizeOfSml = m_fOptionSource.maxLogFileSizeOfSml;
                m_fSsmCore.fOption.maxLogFileSizeOfVfei = m_fOptionSource.maxLogFileSizeOfVfei;
                // --
                m_fSsmCore.fOption.dragDropConfirm = m_fOptionSource.dragDropConfirm;
                // --

                // ***
                // SECS Driver에 반영
                // ***
                m_fSsmCore.fSsmFileInfo.setSecsDriverConfig();

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

        #region btnLogDefault Control Event Handler

        private void btnUiDefault_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                m_fOptionSource.dragDropConfirm = false;

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

    }   // Class end
}   // Namespace end