/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FOpcLogFilterSelector.cs
--  Creator         : mjkim
--  Create Date     : 2015.08.03
--  Description     : FAMate Admin Manager OPC Log Filter Selector Form Class
--  History         : Created by mjkim at 2015.08.03
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.AdminManager
{
    public partial class FOpcLogFilterSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------
        
        private bool m_disposed = false;
        // -- 
        private FAdmCore m_fAdmCore = null;
        private FOpcLogFilter m_fLogFilter = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        private FOpcLogFilterSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOpcLogFilterSelector(
            FAdmCore fAdmCore
            )
            : this(fAdmCore, new FOpcLogFilter())
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOpcLogFilterSelector(
            FAdmCore fAdmCore,
            FOpcLogFilter fOpcLogFilter
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
            m_fLogFilter = new FOpcLogFilter(fOpcLogFilter);
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FOpcLogFilterSelector(
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

        public FOpcLogFilter fLogFilter
        {
            get
            {
                try
                {
                    return m_fLogFilter;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return null;
            }
        }

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
                pgdFilter.selectedObject = new FPropOpcLogFilter(m_fAdmCore, pgdFilter, m_fLogFilter);
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
                m_fLogFilter.enabledFilterOfOpcDeviceState = true;
                m_fLogFilter.enabledFilterOfOpcDeviceError = true;
                m_fLogFilter.enabledFilterOfOpcDeviceTimeout = true;
                m_fLogFilter.enabledFilterOfOpcDeviceDataMessage = true;
                // --
                m_fLogFilter.enabledFilterOfHostDeviceState = true;
                m_fLogFilter.enabledFilterOfHostDeviceError = true;
                m_fLogFilter.enabledFilterOfHostDeviceDataMessage = true;
                // --
                m_fLogFilter.enabledFilterOfScenario = true;
                // --
                m_fLogFilter.enabledFilterOfApplication = true;

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