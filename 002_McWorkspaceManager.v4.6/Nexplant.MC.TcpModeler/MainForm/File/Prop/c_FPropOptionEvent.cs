/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropOptionEvent.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.04
--  Description     : FAMate Tcp Modeler Option of Event Property Source Object Class 
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
    public class FPropOptionEvent : FDynPropCusBase<FTcmCore>
    {
        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryTcpDeviceEvent = "[01] TCP Device Event";
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

        #region Tcp Device

        [Category(CategoryTcpDeviceEvent)]
        public bool EnabledEventsOfTcpDeviceState
        {
            get
            {
                try
                {
                    return m_fOptionSource.enabledEventsOfTcpDeviceState;
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
                    m_fOptionSource.enabledEventsOfTcpDeviceState = value;
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

        [Category(CategoryTcpDeviceEvent)]
        public bool EnabledEventsOfTcpDeviceError
        {
            get
            {
                try
                {
                    return m_fOptionSource.enabledEventsOfTcpDeviceError;
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
                    m_fOptionSource.enabledEventsOfTcpDeviceError = value;
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

        [Category(CategoryTcpDeviceEvent)]
        public bool EnabledEventsOfTcpDeviceTimeout
        {
            get
            {
                try
                {
                    return m_fOptionSource.enabledEventsOfTcpDeviceTimeout;
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
                    m_fOptionSource.enabledEventsOfTcpDeviceTimeout = value;
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

        [Category(CategoryTcpDeviceEvent)]
        public bool EnabledEventsOfTcpDeviceXlg
        {
            get
            {
                try
                {
                    return m_fOptionSource.enabledEventsOfTcpDeviceXlg;
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
                    m_fOptionSource.enabledEventsOfTcpDeviceXlg = value;
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
                base.fTypeDescriptor.properties["EnabledEventsOfTcpDeviceState"].attributes.replace(new DisplayNameAttribute("State Enabled"));
                base.fTypeDescriptor.properties["EnabledEventsOfTcpDeviceError"].attributes.replace(new DisplayNameAttribute("Error Enabled"));
                base.fTypeDescriptor.properties["EnabledEventsOfTcpDeviceTimeout"].attributes.replace(new DisplayNameAttribute("Timeout Enabled"));
                base.fTypeDescriptor.properties["EnabledEventsOfTcpDeviceDataMessage"].attributes.replace(new DisplayNameAttribute("Data Message Enabled"));                
                base.fTypeDescriptor.properties["EnabledEventsOfTcpDeviceXlg"].attributes.replace(new DisplayNameAttribute("XLG Enabled"));
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

                base.fTypeDescriptor.properties["EnabledEventsOfTcpDeviceState"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledEventsOfTcpDeviceState));
                base.fTypeDescriptor.properties["EnabledEventsOfTcpDeviceError"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledEventsOfTcpDeviceError));
                base.fTypeDescriptor.properties["EnabledEventsOfTcpDeviceTimeout"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledEventsOfTcpDeviceTimeout));
                base.fTypeDescriptor.properties["EnabledEventsOfTcpDeviceDataMessage"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledEventsOfTcpDeviceDataMessage));
                base.fTypeDescriptor.properties["EnabledEventsOfTcpDeviceXlg"].attributes.replace(new DefaultValueAttribute(m_fOptionSource.enabledEventsOfTcpDeviceXlg));
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

                base.fTypeDescriptor.properties["EnabledEventsOfTcpDeviceState"].attributes.replace(new ReadOnlyAttribute(true));
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


