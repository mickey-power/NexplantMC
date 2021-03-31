/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropOptionEvent.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.04
--  Description     : FAMate Tcp Modeler Filter of Event Property Source Object Class 
--  History         : Created by spike.lee at 2017.04.04
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
using Nexplant.MC.Core.FaTcpDriver;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.TcpModeler
{
    public class FPropFilterEvent : FDynPropCusBase<FTcmCore>
    {
        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryTcpDeviceFilter = "[01] TCP Device Filter";
        private const string CategoryHostDeviceFilter = "[02] Host Device Filter";
        private const string CategoryScenarioFilter = "[03] Scenario Filter";
        private const string CategoryApplicationFilter = "[04] Application Filter";

        // --

        private bool m_disposed = false;
        // --
        private FOptionSource m_fOptionSource = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropFilterEvent(
            FTcmCore fTcmCore,
            FDynPropGrid fPropGrid,
            FOptionSource fOptionSource
            )
            : base(fTcmCore, fTcmCore.fUIWizard, fPropGrid)
        {
            m_fOptionSource = fOptionSource;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropFilterEvent(
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
                    m_fOptionSource = null;
                }
                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Tcp Device

        [Category(CategoryTcpDeviceFilter)]
        public bool EnabledFilterOfTcpDeviceState
        {
            get
            {
                try
                {
                    return m_fOptionSource.enabledFilterOfTcpDeviceState;
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
                    m_fOptionSource.enabledFilterOfTcpDeviceState = value;
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

        [Category(CategoryTcpDeviceFilter)]
        public bool EnabledFilterOfTcpDeviceError
        {
            get
            {
                try
                {
                    return m_fOptionSource.enabledFilterOfTcpDeviceError;
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
                    m_fOptionSource.enabledFilterOfTcpDeviceError = value;
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

        [Category(CategoryTcpDeviceFilter)]
        public bool EnabledFilterOfTcpDeviceTimeout
        {
            get
            {
                try
                {
                    return m_fOptionSource.enabledFilterOfTcpDeviceTimeout;
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
                    m_fOptionSource.enabledFilterOfTcpDeviceTimeout = value;
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

        [Category(CategoryTcpDeviceFilter)]
        public bool EnabledFilterOfTcpDeviceDataMessage
        {
            get
            {
                try
                {
                    return m_fOptionSource.enabledFilterOfTcpDeviceDataMessage;
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
                    m_fOptionSource.enabledFilterOfTcpDeviceDataMessage = value;
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
                    return m_fOptionSource.enabledFilterOfHostDeviceState;
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
                    m_fOptionSource.enabledFilterOfHostDeviceState = value;
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
                    return m_fOptionSource.enabledFilterOfHostDeviceError;
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
                    m_fOptionSource.enabledFilterOfHostDeviceError = value;
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
                    return m_fOptionSource.enabledFilterOfHostDeviceDataMessage;
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
                    m_fOptionSource.enabledFilterOfHostDeviceDataMessage = value;
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
                    return m_fOptionSource.enabledFilterOfScenario;
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
                    m_fOptionSource.enabledFilterOfScenario = value;
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
                    return m_fOptionSource.enabledFilterOfApplication;
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
                    m_fOptionSource.enabledFilterOfApplication = value;
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
                base.fTypeDescriptor.properties["EnabledFilterOfTcpDeviceState"].attributes.replace(new DisplayNameAttribute("State Enabled"));
                base.fTypeDescriptor.properties["EnabledFilterOfTcpDeviceError"].attributes.replace(new DisplayNameAttribute("Error Enabled"));
                base.fTypeDescriptor.properties["EnabledFilterOfTcpDeviceTimeout"].attributes.replace(new DisplayNameAttribute("Timeout Enabled"));
                base.fTypeDescriptor.properties["EnabledFilterOfTcpDeviceDataMessage"].attributes.replace(new DisplayNameAttribute("Data Message Enabled"));                
                // --
                base.fTypeDescriptor.properties["EnabledFilterOfHostDeviceState"].attributes.replace(new DisplayNameAttribute("State Enabled "));
                base.fTypeDescriptor.properties["EnabledFilterOfHostDeviceError"].attributes.replace(new DisplayNameAttribute("Error Enabled "));
                base.fTypeDescriptor.properties["EnabledFilterOfHostDeviceDataMessage"].attributes.replace(new DisplayNameAttribute("Data Message Enabled "));
                // --
                base.fTypeDescriptor.properties["EnabledFilterOfScenario"].attributes.replace(new DisplayNameAttribute("Scenario Enabled"));      
                // --
                base.fTypeDescriptor.properties["EnabledFilterOfApplication"].attributes.replace(new DisplayNameAttribute("Application Enabled"));      

                // --

                base.fTypeDescriptor.properties["EnabledFilterOfTcpDeviceState"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledFilterOfTcpDeviceState));
                base.fTypeDescriptor.properties["EnabledFilterOfTcpDeviceError"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledFilterOfTcpDeviceError));
                base.fTypeDescriptor.properties["EnabledFilterOfTcpDeviceTimeout"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledFilterOfTcpDeviceTimeout));
                base.fTypeDescriptor.properties["EnabledFilterOfTcpDeviceDataMessage"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledFilterOfTcpDeviceDataMessage));
                // --
                base.fTypeDescriptor.properties["EnabledFilterOfHostDeviceState"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledFilterOfHostDeviceState));
                base.fTypeDescriptor.properties["EnabledFilterOfHostDeviceError"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledFilterOfHostDeviceError));
                base.fTypeDescriptor.properties["EnabledFilterOfHostDeviceDataMessage"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledFilterOfHostDeviceDataMessage));
                // --
                base.fTypeDescriptor.properties["EnabledFilterOfScenario"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledFilterOfScenario));
                // --
                base.fTypeDescriptor.properties["EnabledFilterOfApplication"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledFilterOfApplication));

                // --

                base.fTypeDescriptor.properties["EnabledFilterOfTcpDeviceState"].attributes.replace(new ReadOnlyAttribute(true));
                base.fTypeDescriptor.properties["EnabledFilterOfHostDeviceState"].attributes.replace(new ReadOnlyAttribute(true));

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


