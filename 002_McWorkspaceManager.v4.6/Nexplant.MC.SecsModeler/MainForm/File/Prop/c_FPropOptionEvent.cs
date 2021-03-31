/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropOptionEvent.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.03
--  Description     : FAMate SECS Modeler Option of Event Property Source Object Class 
--  History         : Created by spike.lee at 2017.04.03
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

namespace Nexplant.MC.SecsModeler
{
    public class FPropOptionEvent : FDynPropCusBase<FSsmCore>
    {
        //------------------------------------------------------------------------------------------------------------------------

        private const string CategorySecsDeviceEvent = "[01] SECS Device Event";
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
            FSsmCore fSsmCore,
            FDynPropGrid fPropGrid,
            FOptionSource fOptionSource
            )
            : base(fSsmCore, fSsmCore.fUIWizard, fPropGrid)
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

        #region SECS Device

        [Category(CategorySecsDeviceEvent)]
        public bool EnabledEventsOfSecsDeviceState
        {
            get
            {
                try
                {
                    return m_fOptionSource.enabledEventsOfSecsDeviceState;
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
                    m_fOptionSource.enabledEventsOfSecsDeviceState = value;
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

        [Category(CategorySecsDeviceEvent)]
        public bool EnabledEventsOfSecsDeviceError
        {
            get
            {
                try
                {
                    return m_fOptionSource.enabledEventsOfSecsDeviceError;
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
                    m_fOptionSource.enabledEventsOfSecsDeviceError = value;
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

        [Category(CategorySecsDeviceEvent)]
        public bool EnabledEventsOfSecsDeviceTimeout
        {
            get
            {
                try
                {
                    return m_fOptionSource.enabledEventsOfSecsDeviceTimeout;
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
                    m_fOptionSource.enabledEventsOfSecsDeviceTimeout = value;
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

        [Category(CategorySecsDeviceEvent)]
        public bool EnabledEventsOfSecsDeviceControlMessage
        {
            get
            {
                try
                {
                    return m_fOptionSource.enabledEventsOfSecsDeviceControlMessage;
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
                    m_fOptionSource.enabledEventsOfSecsDeviceControlMessage = value;
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

        [Category(CategorySecsDeviceEvent)]
        public bool EnabledEventsOfSecsDeviceDataMessage
        {
            get
            {
                try
                {
                    return m_fOptionSource.enabledEventsOfSecsDeviceDataMessage;
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
                    m_fOptionSource.enabledEventsOfSecsDeviceDataMessage = value;
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

        [Category(CategorySecsDeviceEvent)]
        public bool EnabledEventsOfSecsDeviceData
        {
            get
            {
                try
                {
                    return m_fOptionSource.enabledEventsOfSecsDeviceData;
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
                    m_fOptionSource.enabledEventsOfSecsDeviceData = value;
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

        [Category(CategorySecsDeviceEvent)]
        public bool EnabledEventsOfSecsDeviceSml
        {
            get
            {
                try
                {
                    return m_fOptionSource.enabledEventsOfSecsDeviceSml;
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
                    m_fOptionSource.enabledEventsOfSecsDeviceSml = value;
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

        [Category(CategorySecsDeviceEvent)]
        public bool EnabledEventsOfSecsDeviceTelnet
        {
            get
            {
                try
                {
                    return m_fOptionSource.enabledEventsOfSecsDeviceTelnet;
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
                    m_fOptionSource.enabledEventsOfSecsDeviceTelnet = value;
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

        [Category(CategorySecsDeviceEvent)]
        public bool EnabledEventsOfSecsDeviceHandshake
        {
            get
            {
                try
                {
                    return m_fOptionSource.enabledEventsOfSecsDeviceHandshake;
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
                    m_fOptionSource.enabledEventsOfSecsDeviceHandshake = value;
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

        [Category(CategorySecsDeviceEvent)]
        public bool EnabledEventsOfSecsDeviceBlock
        {
            get
            {
                try
                {
                    return m_fOptionSource.enabledEventsOfSecsDeviceBlock;
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
                    m_fOptionSource.enabledEventsOfSecsDeviceBlock = value;
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
                base.fTypeDescriptor.properties["EnabledEventsOfSecsDeviceState"].attributes.replace(new DisplayNameAttribute("State Enabled"));
                base.fTypeDescriptor.properties["EnabledEventsOfSecsDeviceError"].attributes.replace(new DisplayNameAttribute("Error Enabled"));
                base.fTypeDescriptor.properties["EnabledEventsOfSecsDeviceTimeout"].attributes.replace(new DisplayNameAttribute("Timeout Enabled"));
                base.fTypeDescriptor.properties["EnabledEventsOfSecsDeviceControlMessage"].attributes.replace(new DisplayNameAttribute("Control Message Enabled"));
                base.fTypeDescriptor.properties["EnabledEventsOfSecsDeviceDataMessage"].attributes.replace(new DisplayNameAttribute("Data Message Enabled"));                
                base.fTypeDescriptor.properties["EnabledEventsOfSecsDeviceData"].attributes.replace(new DisplayNameAttribute("Data Enabled"));
                base.fTypeDescriptor.properties["EnabledEventsOfSecsDeviceSml"].attributes.replace(new DisplayNameAttribute("SML Enabled"));
                base.fTypeDescriptor.properties["EnabledEventsOfSecsDeviceTelnet"].attributes.replace(new DisplayNameAttribute("Telnet Enabled"));
                base.fTypeDescriptor.properties["EnabledEventsOfSecsDeviceHandshake"].attributes.replace(new DisplayNameAttribute("Handshake Enabled"));                
                base.fTypeDescriptor.properties["EnabledEventsOfSecsDeviceBlock"].attributes.replace(new DisplayNameAttribute("Block Message Enabled"));                
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

                base.fTypeDescriptor.properties["EnabledEventsOfSecsDeviceState"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledEventsOfSecsDeviceState));
                base.fTypeDescriptor.properties["EnabledEventsOfSecsDeviceError"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledEventsOfSecsDeviceError));
                base.fTypeDescriptor.properties["EnabledEventsOfSecsDeviceTimeout"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledEventsOfSecsDeviceTimeout));
                base.fTypeDescriptor.properties["EnabledEventsOfSecsDeviceControlMessage"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledEventsOfSecsDeviceControlMessage));
                base.fTypeDescriptor.properties["EnabledEventsOfSecsDeviceDataMessage"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledEventsOfSecsDeviceDataMessage));
                base.fTypeDescriptor.properties["EnabledEventsOfSecsDeviceData"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledEventsOfSecsDeviceData));
                base.fTypeDescriptor.properties["EnabledEventsOfSecsDeviceSml"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledEventsOfSecsDeviceSml));
                base.fTypeDescriptor.properties["EnabledEventsOfSecsDeviceTelnet"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledEventsOfSecsDeviceTelnet));
                base.fTypeDescriptor.properties["EnabledEventsOfSecsDeviceHandshake"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledEventsOfSecsDeviceHandshake));
                base.fTypeDescriptor.properties["EnabledEventsOfSecsDeviceBlock"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledEventsOfSecsDeviceBlock));
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

                base.fTypeDescriptor.properties["EnabledEventsOfSecsDeviceState"].attributes.replace(new ReadOnlyAttribute(true));
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


