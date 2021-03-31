/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropOpcLogFilter.cs
--  Creator         : spike.lee
--  Create Date     : 2017.05.22
--  Description     : FAmate Admin Manager OPC Log Filter Properties Class
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
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.AdminManager
{
    public class FPropOpcLogFilter : FDynPropCusBase<FAdmCore>
    {
        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryOpcDeviceFilter = "[01] OPC Device Filter";
        private const string CategoryHostDeviceFilter = "[02] Host Device Filter";
        private const string CategoryScenarioFilter = "[03] Scenario Filter";
        private const string CategoryApplicationFilter = "[04] Application Filter";

        // --

        private bool m_disposed = false;
        // --
        private FOpcLogFilter m_fLogFilter = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropOpcLogFilter(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            FOpcLogFilter fOpcLogFilter
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_fLogFilter = fOpcLogFilter;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropOpcLogFilter(
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

        #region Opc Device

        [Category(CategoryOpcDeviceFilter)]
        public bool EnabledFilterOfOpcDeviceState
        {
            get
            {
                try
                {
                    return m_fLogFilter.enabledFilterOfOpcDeviceState;
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
                    m_fLogFilter.enabledFilterOfOpcDeviceState = value;
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

        [Category(CategoryOpcDeviceFilter)]
        public bool EnabledFilterOfOpcDeviceError
        {
            get
            {
                try
                {
                    return m_fLogFilter.enabledFilterOfOpcDeviceError;
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
                    m_fLogFilter.enabledFilterOfOpcDeviceError = value;
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

        [Category(CategoryOpcDeviceFilter)]
        public bool EnabledFilterOfOpcDeviceTimeout
        {
            get
            {
                try
                {
                    return m_fLogFilter.enabledFilterOfOpcDeviceTimeout;
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
                    m_fLogFilter.enabledFilterOfOpcDeviceTimeout = value;
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

        [Category(CategoryOpcDeviceFilter)]
        public bool EnabledFilterOfOpcDeviceDataMessage
        {
            get
            {
                try
                {
                    return m_fLogFilter.enabledFilterOfOpcDeviceDataMessage;
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
                    m_fLogFilter.enabledFilterOfOpcDeviceDataMessage = value;
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
                    return m_fLogFilter.enabledFilterOfHostDeviceState;
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
                    m_fLogFilter.enabledFilterOfHostDeviceState = value;
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
                    return m_fLogFilter.enabledFilterOfHostDeviceError;
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
                    m_fLogFilter.enabledFilterOfHostDeviceError = value;
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
                    return m_fLogFilter.enabledFilterOfHostDeviceDataMessage;
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
                    m_fLogFilter.enabledFilterOfHostDeviceDataMessage = value;
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
                    return m_fLogFilter.enabledFilterOfScenario;
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
                    m_fLogFilter.enabledFilterOfScenario = value;
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
                    return m_fLogFilter.enabledFilterOfApplication;
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
                    m_fLogFilter.enabledFilterOfApplication = value;
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
                base.fTypeDescriptor.properties["EnabledFilterOfOpcDeviceState"].attributes.replace(new DisplayNameAttribute("State Enabled"));
                base.fTypeDescriptor.properties["EnabledFilterOfOpcDeviceError"].attributes.replace(new DisplayNameAttribute("Error Enabled"));
                base.fTypeDescriptor.properties["EnabledFilterOfOpcDeviceTimeout"].attributes.replace(new DisplayNameAttribute("Timeout Enabled"));
                base.fTypeDescriptor.properties["EnabledFilterOfOpcDeviceDataMessage"].attributes.replace(new DisplayNameAttribute("Data Message Enabled"));                
                // --
                base.fTypeDescriptor.properties["EnabledFilterOfHostDeviceState"].attributes.replace(new DisplayNameAttribute("State Enabled "));
                base.fTypeDescriptor.properties["EnabledFilterOfHostDeviceError"].attributes.replace(new DisplayNameAttribute("Error Enabled "));
                base.fTypeDescriptor.properties["EnabledFilterOfHostDeviceDataMessage"].attributes.replace(new DisplayNameAttribute("Data Message Enabled "));
                // --
                base.fTypeDescriptor.properties["EnabledFilterOfScenario"].attributes.replace(new DisplayNameAttribute("Scenario Enabled"));      
                // --
                base.fTypeDescriptor.properties["EnabledFilterOfApplication"].attributes.replace(new DisplayNameAttribute("Application Enabled"));      

                // --

                base.fTypeDescriptor.properties["EnabledFilterOfOpcDeviceState"].attributes.replace(new DefaultValueAttribute(m_fLogFilter.enabledFilterOfOpcDeviceState));
                base.fTypeDescriptor.properties["EnabledFilterOfOpcDeviceError"].attributes.replace(new DefaultValueAttribute(m_fLogFilter.enabledFilterOfOpcDeviceError));
                base.fTypeDescriptor.properties["EnabledFilterOfOpcDeviceTimeout"].attributes.replace(new DefaultValueAttribute(m_fLogFilter.enabledFilterOfOpcDeviceTimeout));
                base.fTypeDescriptor.properties["EnabledFilterOfOpcDeviceDataMessage"].attributes.replace(new DefaultValueAttribute(m_fLogFilter.enabledFilterOfOpcDeviceDataMessage));
                // --
                base.fTypeDescriptor.properties["EnabledFilterOfHostDeviceState"].attributes.replace(new DefaultValueAttribute(m_fLogFilter.enabledFilterOfHostDeviceState));
                base.fTypeDescriptor.properties["EnabledFilterOfHostDeviceError"].attributes.replace(new DefaultValueAttribute(m_fLogFilter.enabledFilterOfHostDeviceError));
                base.fTypeDescriptor.properties["EnabledFilterOfHostDeviceDataMessage"].attributes.replace(new DefaultValueAttribute(m_fLogFilter.enabledFilterOfHostDeviceDataMessage));
                // --
                base.fTypeDescriptor.properties["EnabledFilterOfScenario"].attributes.replace(new DefaultValueAttribute(m_fLogFilter.enabledFilterOfScenario));
                // --
                base.fTypeDescriptor.properties["EnabledFilterOfApplication"].attributes.replace(new DefaultValueAttribute(m_fLogFilter.enabledFilterOfApplication));

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


