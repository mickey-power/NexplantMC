/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FLogFilter.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.04
--  Description     : FAMate TCP Modeler Log Filter Form Class
--  History         : Created by spike.lee at 2017.04.04
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.TcpModeler
{
    public partial class FLogFilter : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------
        
        private bool m_disposed = false;
        // -- 
        private FTcmCore m_fTcmCore = null;
        private FOptionSource m_fOptionSource = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        private FLogFilter(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FLogFilter(
            FTcmCore fTcmCore
            )
            :this()
        {
            base.fUIWizard = fTcmCore.fUIWizard;
            m_fTcmCore = fTcmCore;
            m_fOptionSource = new FOptionSource(fTcmCore);
		}

        //------------------------------------------------------------------------------------------------------------------------

        ~FLogFilter(
            )
        {
            myDispose(false);
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

        #region FLogFilter Form Event Handler

        private void FLogFilter_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                #region Event Option

                m_fOptionSource.enabledFilterOfTcpDeviceState = m_fTcmCore.fOption.enabledFilterOfTcpDeviceState;
                m_fOptionSource.enabledFilterOfTcpDeviceError = m_fTcmCore.fOption.enabledFilterOfTcpDeviceError;
                m_fOptionSource.enabledFilterOfTcpDeviceTimeout = m_fTcmCore.fOption.enabledFilterOfTcpDeviceTimeout;
                m_fOptionSource.enabledFilterOfTcpDeviceDataMessage = m_fTcmCore.fOption.enabledFilterOfTcpDeviceDataMessage;
                // --
                m_fOptionSource.enabledFilterOfHostDeviceState = m_fTcmCore.fOption.enabledFilterOfHostDeviceState;
                m_fOptionSource.enabledFilterOfHostDeviceError = m_fTcmCore.fOption.enabledFilterOfHostDeviceError;
                m_fOptionSource.enabledFilterOfHostDeviceDataMessage = m_fTcmCore.fOption.enabledFilterOfHostDeviceDataMessage;
                // --
                m_fOptionSource.enabledFilterOfScenario = m_fTcmCore.fOption.enabledFilterOfScenario;
                // --
                m_fOptionSource.enabledFilterOfApplication = m_fTcmCore.fOption.enabledFilterOfApplication;

                #endregion

                // --

                pgdFilter.selectedObject = new FPropFilterEvent(m_fTcmCore, pgdFilter, m_fOptionSource);
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

        private void FLogFilter_FormClosing(
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

        #region btnDefault Control Event Handler

        private void btnDefault_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                m_fOptionSource.enabledFilterOfTcpDeviceState = true;
                m_fOptionSource.enabledFilterOfTcpDeviceError = true;
                m_fOptionSource.enabledFilterOfTcpDeviceTimeout = true;
                m_fOptionSource.enabledFilterOfTcpDeviceDataMessage = true;
                // --
                m_fOptionSource.enabledFilterOfHostDeviceState = true;
                m_fOptionSource.enabledFilterOfHostDeviceError = true;
                m_fOptionSource.enabledFilterOfHostDeviceDataMessage = true;
                // --
                m_fOptionSource.enabledFilterOfScenario = true;
                // --
                m_fOptionSource.enabledFilterOfApplication = true;

                // --

                pgdFilter.Refresh();
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
                m_fTcmCore.fOption.enabledFilterOfTcpDeviceState = m_fOptionSource.enabledFilterOfTcpDeviceState;
                m_fTcmCore.fOption.enabledFilterOfTcpDeviceError = m_fOptionSource.enabledFilterOfTcpDeviceError;
                m_fTcmCore.fOption.enabledFilterOfTcpDeviceTimeout = m_fOptionSource.enabledFilterOfTcpDeviceTimeout;
                m_fTcmCore.fOption.enabledFilterOfTcpDeviceDataMessage = m_fOptionSource.enabledFilterOfTcpDeviceDataMessage;
                // --
                m_fTcmCore.fOption.enabledFilterOfHostDeviceState = m_fOptionSource.enabledFilterOfHostDeviceState;
                m_fTcmCore.fOption.enabledFilterOfHostDeviceError = m_fOptionSource.enabledFilterOfHostDeviceError;
                m_fTcmCore.fOption.enabledFilterOfHostDeviceDataMessage = m_fOptionSource.enabledFilterOfHostDeviceDataMessage;
                // --
                m_fTcmCore.fOption.enabledFilterOfScenario = m_fOptionSource.enabledFilterOfScenario;
                // --
                m_fTcmCore.fOption.enabledFilterOfApplication = m_fOptionSource.enabledFilterOfApplication;

                // --

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
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