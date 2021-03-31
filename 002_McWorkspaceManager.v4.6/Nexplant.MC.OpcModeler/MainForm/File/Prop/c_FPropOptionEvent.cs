/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropOptionEvent.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.04
--  Description     : FAMate OPC Modeler Option of Event Property Source Object Class 
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
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.OpcModeler
{
    public class FPropOptionEvent : FDynPropCusBase<FOpmCore>
    {
        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryOpcDeviceEvent = "[01] OPC Device Event";
        private const string CategoryHostDeviceEvent = "[02] Host Device Event";
        private const string CategoryScenarioEvent = "[03] Scenario Event";
        private const string CategoryApplicationEvent = "[04] Application Event";

        // --

        private bool m_disposed = false;
        // --
        private FOptionSource m_fOptionSource = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropOptionEvent(
            FOpmCore fOpmCore,
            FDynPropGrid fPropGrid,
            FOptionSource fOptionSource
            )
            : base(fOpmCore, fOpmCore.fUIWizard, fPropGrid)
        {
            m_fOptionSource = fOptionSource;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropOptionEvent(
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

        #region Opc Device

        [Category(CategoryOpcDeviceEvent)]
        public bool EnabledEventsOfOpcDeviceState
        {
            get
            {
                try
                {
                    return m_fOptionSource.enabledEventsOfOpcDeviceState;
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
                    m_fOptionSource.enabledEventsOfOpcDeviceState = value;
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

        [Category(CategoryOpcDeviceEvent)]
        public bool EnabledEventsOfOpcDeviceError
        {
            get
            {
                try
                {
                    return m_fOptionSource.enabledEventsOfOpcDeviceError;
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
                    m_fOptionSource.enabledEventsOfOpcDeviceError = value;
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

        [Category(CategoryOpcDeviceEvent)]
        public bool EnabledEventsOfOpcDeviceTimeout
        {
            get
            {
                try
                {
                    return m_fOptionSource.enabledEventsOfOpcDeviceTimeout;
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
                    m_fOptionSource.enabledEventsOfOpcDeviceTimeout = value;
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

        [Category(CategoryOpcDeviceEvent)]
        public bool EnabledEventsOfOpcDeviceDataMessage
        {
            get
            {
                try
                {
                    return m_fOptionSource.enabledEventsOfOpcDeviceDataMessage;
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
                    m_fOptionSource.enabledEventsOfOpcDeviceDataMessage = value;
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

        [Category(CategoryHostDeviceEvent)]
        public bool EnabledEventsOfHostDeviceState
        {
            get
            {
                try
                {
                    return m_fOptionSource.enabledEventsOfHostDeviceState;
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
                    m_fOptionSource.enabledEventsOfHostDeviceState = value;
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

        [Category(CategoryHostDeviceEvent)]
        public bool EnabledEventsOfHostDeviceError
        {
            get
            {
                try
                {
                    return m_fOptionSource.enabledEventsOfHostDeviceError;
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
                    m_fOptionSource.enabledEventsOfHostDeviceError = value;
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

        [Category(CategoryHostDeviceEvent)]
        public bool EnabledEventsOfHostDeviceDataMessage
        {
            get
            {
                try
                {
                    return m_fOptionSource.enabledEventsOfHostDeviceDataMessage;
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
                    m_fOptionSource.enabledEventsOfHostDeviceDataMessage = value;
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

        [Category(CategoryHostDeviceEvent)]
        public bool EnabledEventsOfHostDeviceVfei
        {
            get
            {
                try
                {
                    return m_fOptionSource.enabledEventsOfHostDeviceVfei;
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
                    m_fOptionSource.enabledEventsOfHostDeviceVfei = value;
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

        [Category(CategoryScenarioEvent)]
        public bool EnabledEventsOfScenario
        {
            get
            {
                try
                {
                    return m_fOptionSource.enabledEventsOfScenario;
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
                    m_fOptionSource.enabledEventsOfScenario = value;
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

        [Category(CategoryApplicationEvent)]
        public bool EnabledEventsOfApplication
        {
            get
            {
                try
                {
                    return m_fOptionSource.enabledEventsOfApplication;
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
                    m_fOptionSource.enabledEventsOfApplication = value;
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
                base.fTypeDescriptor.properties["EnabledEventsOfOpcDeviceState"].attributes.replace(new DisplayNameAttribute("State Enabled"));
                base.fTypeDescriptor.properties["EnabledEventsOfOpcDeviceError"].attributes.replace(new DisplayNameAttribute("Error Enabled"));
                base.fTypeDescriptor.properties["EnabledEventsOfOpcDeviceTimeout"].attributes.replace(new DisplayNameAttribute("Timeout Enabled"));
                base.fTypeDescriptor.properties["EnabledEventsOfOpcDeviceDataMessage"].attributes.replace(new DisplayNameAttribute("Data Message Enabled"));                
                // --
                base.fTypeDescriptor.properties["EnabledEventsOfHostDeviceState"].attributes.replace(new DisplayNameAttribute("State Enabled "));
                base.fTypeDescriptor.properties["EnabledEventsOfHostDeviceError"].attributes.replace(new DisplayNameAttribute("Error Enabled "));
                base.fTypeDescriptor.properties["EnabledEventsOfHostDeviceDataMessage"].attributes.replace(new DisplayNameAttribute("Data Message Enabled "));
                base.fTypeDescriptor.properties["EnabledEventsOfHostDeviceVfei"].attributes.replace(new DisplayNameAttribute("VFEI Enabled"));      
                // --
                base.fTypeDescriptor.properties["EnabledEventsOfScenario"].attributes.replace(new DisplayNameAttribute("Scenario Enabled"));      
                // --
                base.fTypeDescriptor.properties["EnabledEventsOfApplication"].attributes.replace(new DisplayNameAttribute("Application Enabled"));      

                // --

                base.fTypeDescriptor.properties["EnabledEventsOfOpcDeviceState"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledEventsOfOpcDeviceState));
                base.fTypeDescriptor.properties["EnabledEventsOfOpcDeviceError"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledEventsOfOpcDeviceError));
                base.fTypeDescriptor.properties["EnabledEventsOfOpcDeviceTimeout"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledEventsOfOpcDeviceTimeout));
                base.fTypeDescriptor.properties["EnabledEventsOfOpcDeviceDataMessage"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledEventsOfOpcDeviceDataMessage));
                // --
                base.fTypeDescriptor.properties["EnabledEventsOfHostDeviceState"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledEventsOfHostDeviceState));
                base.fTypeDescriptor.properties["EnabledEventsOfHostDeviceError"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledEventsOfHostDeviceError));
                base.fTypeDescriptor.properties["EnabledEventsOfHostDeviceDataMessage"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledEventsOfHostDeviceDataMessage));
                base.fTypeDescriptor.properties["EnabledEventsOfHostDeviceVfei"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledEventsOfHostDeviceVfei));
                // --
                base.fTypeDescriptor.properties["EnabledEventsOfScenario"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledEventsOfScenario));
                // --
                base.fTypeDescriptor.properties["EnabledEventsOfApplication"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledEventsOfApplication));

                // --

                base.fTypeDescriptor.properties["EnabledEventsOfOpcDeviceState"].attributes.replace(new ReadOnlyAttribute(true));
                base.fTypeDescriptor.properties["EnabledEventsOfHostDeviceState"].attributes.replace(new ReadOnlyAttribute(true));

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


