/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FSecsLogFilterSelector.cs
--  Creator         : byjeon
--  Create Date     : 2013.12.06
--  Description     : FAMate Admin Manager SECS Log Filter Selector Form Class
--  History         : Created by byjeon at 2013.12.06
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.AdminManager
{
    public partial class FSecsLogFilterSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------
        
        private bool m_disposed = false;
        // -- 
        private FAdmCore m_fAdmCore = null;
        private FSecsLogFilter m_fLogFilter = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        private FSecsLogFilterSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsLogFilterSelector(
            FAdmCore fAdnCore
            )
            : this(fAdnCore, new FSecsLogFilter())
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsLogFilterSelector(
            FAdmCore fAdmCore,
            FSecsLogFilter fSecsLogFilter
            )
            :this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
            m_fLogFilter = fSecsLogFilter;
            m_fLogFilter = new FSecsLogFilter(fSecsLogFilter);
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSecsLogFilterSelector(
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
                    m_fLogFilter = null;
                    m_fAdmCore = null;
                }
                m_disposed = true;

                // -- 

                base.myDispose(disposing);
            }            
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FSecsLogFilter fLogFilter
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
                pgdFilter.selectedObject = new FPropSecsLogFilter(m_fAdmCore, pgdFilter, m_fLogFilter);
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
                m_fLogFilter.enabledEventsOfSecsDeviceState = true;
                m_fLogFilter.enabledEventsOfSecsDeviceError = true;
                m_fLogFilter.enabledEventsOfSecsDeviceTimeout = true;
                m_fLogFilter.enabledEventsOfSecsDeviceControlMessage = true;
                m_fLogFilter.enabledEventsOfSecsDeviceDataMessage = true;
                m_fLogFilter.enabledEventsOfSecsDeviceTelnet = false;
                m_fLogFilter.enabledEventsOfSecsDeviceHandshake = false;
                m_fLogFilter.enabledEventsOfSecsDeviceBlock = false;
                // --
                m_fLogFilter.enabledEventsOfHostDeviceState = true;
                m_fLogFilter.enabledEventsOfHostDeviceError = true;
                m_fLogFilter.enabledEventsOfHostDeviceDataMessage = true;
                // --
                m_fLogFilter.enabledEventsOfScenario = true;
                // --
                m_fLogFilter.enabledEventsOfApplication = true;

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