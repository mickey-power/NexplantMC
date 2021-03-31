/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FOptionDialog.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.04
--  Description     : FAMate Tcp Modeler Option Dialog Form Class
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
using Nexplant.MC.Core.FaTcpDriver;

namespace Nexplant.MC.TcpModeler
{
    public partial class FOptionDialog : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------
        
        private bool m_disposed = false;
        // -- 
        private FTcmCore m_fTcmCore = null;
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
            FTcmCore fTcmCore
            )
            :this()
        {
            base.fUIWizard = fTcmCore.fUIWizard;
            m_fTcmCore = fTcmCore;
            m_fOptionSource = new FOptionSource(fTcmCore);
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

                m_fOptionSource.enabledEventsOfTcpDeviceState = m_fTcmCore.fOption.enabledEventsOfTcpDeviceState;
                m_fOptionSource.enabledEventsOfTcpDeviceError = m_fTcmCore.fOption.enabledEventsOfTcpDeviceError;
                m_fOptionSource.enabledEventsOfTcpDeviceTimeout = m_fTcmCore.fOption.enabledEventsOfTcpDeviceTimeout;
                m_fOptionSource.enabledEventsOfTcpDeviceDataMessage = m_fTcmCore.fOption.enabledEventsOfTcpDeviceDataMessage;
                m_fOptionSource.enabledEventsOfTcpDeviceXlg = m_fTcmCore.fOption.enabledEventsOfTcpDeviceXlg;                
                // --
                m_fOptionSource.enabledEventsOfHostDeviceState = m_fTcmCore.fOption.enabledEventsOfHostDeviceState;
                m_fOptionSource.enabledEventsOfHostDeviceError = m_fTcmCore.fOption.enabledEventsOfHostDeviceError;                
                m_fOptionSource.enabledEventsOfHostDeviceDataMessage = m_fTcmCore.fOption.enabledEventsOfHostDeviceDataMessage;
                m_fOptionSource.enabledEventsOfHostDeviceVfei = m_fTcmCore.fOption.enabledEventsOfHostDeviceVfei;
                // --
                m_fOptionSource.enabledEventsOfScenario = m_fTcmCore.fOption.enabledEventsOfScenario;
                // --
                m_fOptionSource.enabledEventsOfApplication = m_fTcmCore.fOption.enabledEventsOfApplication;

                #endregion

                // --

                #region Log Option

                m_fOptionSource.logDirectory = m_fTcmCore.fOption.logDirectory;
                // --                
                m_fOptionSource.enabledLogOfTcp = m_fTcmCore.fOption.enabledLogOfTcp;
                m_fOptionSource.enabledLogOfBinary = m_fTcmCore.fOption.enabledLogOfBinary;
                m_fOptionSource.enabledLogOfXlg = m_fTcmCore.fOption.enabledLogOfXlg;
                m_fOptionSource.enabledLogOfVfei = m_fTcmCore.fOption.enabledLogOfVfei;                
                // --
                m_fOptionSource.maxLogFileSizeOfTcp = m_fTcmCore.fOption.maxLogFileSizeOfTcp;
                m_fOptionSource.maxLogFileSizeOfBinary = m_fTcmCore.fOption.maxLogFileSizeOfBinary;
                m_fOptionSource.maxLogFileSizeOfXlg = m_fTcmCore.fOption.maxLogFileSizeOfXlg;
                m_fOptionSource.maxLogFileSizeOfVfei = m_fTcmCore.fOption.maxLogFileSizeOfVfei;                

                #endregion

                // --

                pgdEvent.selectedObject = new FPropOptionEvent(m_fTcmCore, pgdEvent, m_fOptionSource);
                pgdLog.selectedObject = new FPropOptionLog(m_fTcmCore, pgdEvent, m_fOptionSource);
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
                m_fOptionSource.enabledEventsOfTcpDeviceState = true;
                m_fOptionSource.enabledEventsOfTcpDeviceError = true;
                m_fOptionSource.enabledEventsOfTcpDeviceTimeout = true;
                m_fOptionSource.enabledEventsOfTcpDeviceDataMessage = true;
                m_fOptionSource.enabledEventsOfTcpDeviceXlg = false;
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
                m_fOptionSource.enabledLogOfTcp = false;
                m_fOptionSource.enabledLogOfBinary = false;
                m_fOptionSource.enabledLogOfXlg = false;
                m_fOptionSource.enabledLogOfVfei = false;
                // --
                m_fOptionSource.maxLogFileSizeOfTcp = 5 * 1024 * 1024;
                m_fOptionSource.maxLogFileSizeOfBinary = 5 * 1024 * 1024;
                m_fOptionSource.maxLogFileSizeOfXlg = 5 * 1024 * 1024;
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
                m_fTcmCore.fOption.enabledEventsOfTcpDeviceState = m_fOptionSource.enabledEventsOfTcpDeviceState;
                m_fTcmCore.fOption.enabledEventsOfTcpDeviceError = m_fOptionSource.enabledEventsOfTcpDeviceError;
                m_fTcmCore.fOption.enabledEventsOfTcpDeviceTimeout = m_fOptionSource.enabledEventsOfTcpDeviceTimeout;
                m_fTcmCore.fOption.enabledEventsOfTcpDeviceDataMessage = m_fOptionSource.enabledEventsOfTcpDeviceDataMessage;
                m_fTcmCore.fOption.enabledEventsOfTcpDeviceXlg = m_fOptionSource.enabledEventsOfTcpDeviceXlg;
                // --
                m_fTcmCore.fOption.enabledEventsOfHostDeviceState = m_fOptionSource.enabledEventsOfHostDeviceState;
                m_fTcmCore.fOption.enabledEventsOfHostDeviceError = m_fOptionSource.enabledEventsOfHostDeviceError;
                m_fTcmCore.fOption.enabledEventsOfHostDeviceDataMessage = m_fOptionSource.enabledEventsOfHostDeviceDataMessage;
                m_fTcmCore.fOption.enabledEventsOfHostDeviceVfei = m_fOptionSource.enabledEventsOfHostDeviceVfei;
                // --
                m_fTcmCore.fOption.enabledEventsOfScenario = m_fOptionSource.enabledEventsOfScenario;
                // --
                m_fTcmCore.fOption.enabledEventsOfApplication = m_fOptionSource.enabledEventsOfApplication;

                // --

                m_fTcmCore.fOption.logDirectory = m_fOptionSource.logDirectory;
                // --
                m_fTcmCore.fOption.enabledLogOfTcp = m_fOptionSource.enabledLogOfTcp;
                m_fTcmCore.fOption.enabledLogOfBinary = m_fOptionSource.enabledLogOfBinary;
                m_fTcmCore.fOption.enabledLogOfXlg = m_fOptionSource.enabledLogOfXlg;
                m_fTcmCore.fOption.enabledLogOfVfei = m_fOptionSource.enabledLogOfVfei;
                // --
                m_fTcmCore.fOption.maxLogFileSizeOfTcp = m_fOptionSource.maxLogFileSizeOfTcp;
                m_fTcmCore.fOption.maxLogFileSizeOfBinary = m_fOptionSource.maxLogFileSizeOfBinary;
                m_fTcmCore.fOption.maxLogFileSizeOfXlg = m_fOptionSource.maxLogFileSizeOfXlg;
                m_fTcmCore.fOption.maxLogFileSizeOfVfei = m_fOptionSource.maxLogFileSizeOfVfei;

                // --

                // ***
                // Tcp Driver에 반영
                // ***
                m_fTcmCore.fTcmFileInfo.setTcpDriverConfig();

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