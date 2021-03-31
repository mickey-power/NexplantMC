/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropSecsLogFilter.cs
--  Creator         : spike.lee
--  Create Date     : 2017.05.22
--  Description     : FAmate Admin Manager SECS Log Filter Properties Class
--  History         : Created by spike.lee at 2017.05.22
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.AdminManager
{
    public class FPropSecsLogFilter : FDynPropCusBase<FAdmCore>
    {
        //------------------------------------------------------------------------------------------------------------------------

        private const string CategorySecsDeviceFilter = "[01] SECS Device Filter";
        private const string CategoryHostDeviceFilter = "[02] Host Device Filter";
        private const string CategoryScenarioFilter = "[03] Scenario Filter";
        private const string CategoryApplicationFilter = "[04] Application Filter";

        // --

        private bool m_disposed = false;
        // --
        private FSecsLogFilter m_fLogFilter = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropSecsLogFilter(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            FSecsLogFilter fLogFilter
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_fLogFilter = fLogFilter;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropSecsLogFilter(
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
                    term();
                    // --
                    m_fLogFilter = null;
                }
                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region SECS Device

        [Category(CategorySecsDeviceFilter)]
        public bool EnabledFilterOfSecsDeviceState
        {
            get
            {
                try
                {
                    return m_fLogFilter.enabledEventsOfSecsDeviceState;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_fLogFilter.enabledEventsOfSecsDeviceState = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategorySecsDeviceFilter)]
        public bool EnabledFilterOfSecsDeviceError
        {
            get
            {
                try
                {
                    return m_fLogFilter.enabledEventsOfSecsDeviceError;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_fLogFilter.enabledEventsOfSecsDeviceError = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategorySecsDeviceFilter)]
        public bool EnabledFilterOfSecsDeviceTimeout
        {
            get
            {
                try
                {
                    return m_fLogFilter.enabledEventsOfSecsDeviceTimeout;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_fLogFilter.enabledEventsOfSecsDeviceTimeout = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategorySecsDeviceFilter)]
        public bool EnabledFilterOfSecsDeviceControlMessage
        {
            get
            {
                try
                {
                    return m_fLogFilter.enabledEventsOfSecsDeviceControlMessage;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_fLogFilter.enabledEventsOfSecsDeviceControlMessage = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategorySecsDeviceFilter)]
        public bool EnabledFilterOfSecsDeviceDataMessage
        {
            get
            {
                try
                {
                    return m_fLogFilter.enabledEventsOfSecsDeviceDataMessage;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_fLogFilter.enabledEventsOfSecsDeviceDataMessage = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategorySecsDeviceFilter)]
        public bool EnabledFilterOfSecsDeviceTelnet
        {
            get
            {
                try
                {
                    return m_fLogFilter.enabledEventsOfSecsDeviceTelnet;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_fLogFilter.enabledEventsOfSecsDeviceTelnet = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategorySecsDeviceFilter)]
        public bool EnabledFilterOfSecsDeviceHandshake
        {
            get
            {
                try
                {
                    return m_fLogFilter.enabledEventsOfSecsDeviceHandshake;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_fLogFilter.enabledEventsOfSecsDeviceHandshake = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategorySecsDeviceFilter)]
        public bool EnabledFilterOfSecsDeviceBlock
        {
            get
            {
                try
                {
                    return m_fLogFilter.enabledEventsOfSecsDeviceBlock;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_fLogFilter.enabledEventsOfSecsDeviceBlock = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Host Device

        [Category(CategoryHostDeviceFilter)]
        public bool EnabledFilterOfHostDeviceState
        {
            get
            {
                try
                {
                    return m_fLogFilter.enabledEventsOfHostDeviceState;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_fLogFilter.enabledEventsOfHostDeviceState = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryHostDeviceFilter)]
        public bool EnabledFilterOfHostDeviceError
        {
            get
            {
                try
                {
                    return m_fLogFilter.enabledEventsOfHostDeviceError;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_fLogFilter.enabledEventsOfHostDeviceError = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryHostDeviceFilter)]
        public bool EnabledFilterOfHostDeviceDataMessage
        {
            get
            {
                try
                {
                    return m_fLogFilter.enabledEventsOfHostDeviceDataMessage;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_fLogFilter.enabledEventsOfHostDeviceDataMessage = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Scenario

        [Category(CategoryScenarioFilter)]
        public bool EnabledFilterOfScenario
        {
            get
            {
                try
                {
                    return m_fLogFilter.enabledEventsOfScenario;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_fLogFilter.enabledEventsOfScenario = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Application

        [Category(CategoryApplicationFilter)]
        public bool EnabledFilterOfApplication
        {
            get
            {
                try
                {
                    return m_fLogFilter.enabledEventsOfApplication;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_fLogFilter.enabledEventsOfApplication = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            try
            {
                base.fTypeDescriptor.properties["EnabledFilterOfSecsDeviceState"].attributes.replace(new DisplayNameAttribute("State Enabled"));
                base.fTypeDescriptor.properties["EnabledFilterOfSecsDeviceError"].attributes.replace(new DisplayNameAttribute("Error Enabled"));
                base.fTypeDescriptor.properties["EnabledFilterOfSecsDeviceTimeout"].attributes.replace(new DisplayNameAttribute("Timeout Enabled"));
                base.fTypeDescriptor.properties["EnabledFilterOfSecsDeviceControlMessage"].attributes.replace(new DisplayNameAttribute("Control Message Enabled"));
                base.fTypeDescriptor.properties["EnabledFilterOfSecsDeviceDataMessage"].attributes.replace(new DisplayNameAttribute("Data Message Enabled"));                
                base.fTypeDescriptor.properties["EnabledFilterOfSecsDeviceTelnet"].attributes.replace(new DisplayNameAttribute("Telnet Enabled"));
                base.fTypeDescriptor.properties["EnabledFilterOfSecsDeviceHandshake"].attributes.replace(new DisplayNameAttribute("Handshake Enabled"));                
                base.fTypeDescriptor.properties["EnabledFilterOfSecsDeviceBlock"].attributes.replace(new DisplayNameAttribute("Block Message Enabled"));                
                // --
                base.fTypeDescriptor.properties["EnabledFilterOfHostDeviceState"].attributes.replace(new DisplayNameAttribute("State Enabled "));
                base.fTypeDescriptor.properties["EnabledFilterOfHostDeviceError"].attributes.replace(new DisplayNameAttribute("Error Enabled "));
                base.fTypeDescriptor.properties["EnabledFilterOfHostDeviceDataMessage"].attributes.replace(new DisplayNameAttribute("Data Message Enabled "));
                // --
                base.fTypeDescriptor.properties["EnabledFilterOfScenario"].attributes.replace(new DisplayNameAttribute("Scenario Enabled"));      
                // --
                base.fTypeDescriptor.properties["EnabledFilterOfApplication"].attributes.replace(new DisplayNameAttribute("Application Enabled"));      

                // --

                base.fTypeDescriptor.properties["EnabledFilterOfSecsDeviceState"].attributes.replace(new DefaultValueAttribute(m_fLogFilter.enabledEventsOfSecsDeviceState));
                base.fTypeDescriptor.properties["EnabledFilterOfSecsDeviceError"].attributes.replace(new DefaultValueAttribute(m_fLogFilter.enabledEventsOfSecsDeviceError));
                base.fTypeDescriptor.properties["EnabledFilterOfSecsDeviceTimeout"].attributes.replace(new DefaultValueAttribute(m_fLogFilter.enabledEventsOfSecsDeviceTimeout));
                base.fTypeDescriptor.properties["EnabledFilterOfSecsDeviceControlMessage"].attributes.replace(new DefaultValueAttribute(m_fLogFilter.enabledEventsOfSecsDeviceControlMessage));
                base.fTypeDescriptor.properties["EnabledFilterOfSecsDeviceDataMessage"].attributes.replace(new DefaultValueAttribute(m_fLogFilter.enabledEventsOfSecsDeviceDataMessage));
                base.fTypeDescriptor.properties["EnabledFilterOfSecsDeviceTelnet"].attributes.replace(new DefaultValueAttribute(m_fLogFilter.enabledEventsOfSecsDeviceTelnet));
                base.fTypeDescriptor.properties["EnabledFilterOfSecsDeviceHandshake"].attributes.replace(new DefaultValueAttribute(m_fLogFilter.enabledEventsOfSecsDeviceHandshake));
                base.fTypeDescriptor.properties["EnabledFilterOfSecsDeviceBlock"].attributes.replace(new DefaultValueAttribute(m_fLogFilter.enabledEventsOfSecsDeviceBlock));
                // --
                base.fTypeDescriptor.properties["EnabledFilterOfHostDeviceState"].attributes.replace(new DefaultValueAttribute(m_fLogFilter.enabledEventsOfHostDeviceState));
                base.fTypeDescriptor.properties["EnabledFilterOfHostDeviceError"].attributes.replace(new DefaultValueAttribute(m_fLogFilter.enabledEventsOfHostDeviceError));
                base.fTypeDescriptor.properties["EnabledFilterOfHostDeviceDataMessage"].attributes.replace(new DefaultValueAttribute(m_fLogFilter.enabledEventsOfHostDeviceDataMessage));
                // --
                base.fTypeDescriptor.properties["EnabledFilterOfScenario"].attributes.replace(new DefaultValueAttribute(m_fLogFilter.enabledEventsOfScenario));
                // --
                base.fTypeDescriptor.properties["EnabledFilterOfApplication"].attributes.replace(new DefaultValueAttribute(m_fLogFilter.enabledEventsOfApplication));

                // --

                this.fPropGrid.DynPropGridRefreshRequested += new FDynPropGridRefreshRequestedEventHandler(fPropGrid_DynPropGridRefreshRequested);
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

        private void term(
            )
        {
            try
            {
                this.fPropGrid.DynPropGridRefreshRequested -= new FDynPropGridRefreshRequestedEventHandler(fPropGrid_DynPropGridRefreshRequested);
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

        private void procRefreshRequested(
            )
        {
            try
            {
                this.fPropGrid.Refresh();
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

        #region fPropGrid Event Handler

        private void fPropGrid_DynPropGridRefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                procRefreshRequested();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end


