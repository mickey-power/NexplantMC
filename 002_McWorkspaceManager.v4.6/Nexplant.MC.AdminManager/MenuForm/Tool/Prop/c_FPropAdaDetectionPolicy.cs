/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAdaDetectionPolicy.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2013.03.26
--  Description     : FAMate Admin Manager Admin Agent Option Detection Policy Source Object Class 
--  History         : Created by jungyoul.moon at 2013.03.26
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Design;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public class FPropAdaDetectionPolicy : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryEap = "[01] EAP";
        private const string CategoryOpcServer = "[02] OPC Server";
        
        // --

        private bool m_disposed = false;
        private FADAOption m_source = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropAdaDetectionPolicy(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            FADAOption source
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_source = source;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropAdaDetectionPolicy(
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
                    m_source = null;
                }
            }
            m_disposed = true;

            // --

            base.myDispose(disposing);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Eap

        [Category(CategoryEap)]
        public FYesNo EapWatchEnabled
        {
            get
            {
                try
                {
                    return m_source.eapWatchEnabled;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FYesNo.No;
            }

            set
            {
                try
                {
                    m_source.eapWatchEnabled = value;

                    // --

                    setChangedEapWatchEnabled();
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

        [Category(CategoryEap)]
        public int EapWatchCycleTime
        {
            get
            {
                try
                {
                    return m_source.eapWatchCycleTime;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return 0;
            }

            set
            {
                try
                {
                    if (value < 1)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Value" }));
                    }

                    // --

                    m_source.eapWatchCycleTime = value;
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

        #region OPC Server

        [Category(CategoryOpcServer)]
        public FYesNo OpcServerWatchEnabled
        {
            get
            {
                try
                {
                    return m_source.opcServerWatchEnabled;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FYesNo.No;
            }

            set
            {
                try
                {
                    m_source.opcServerWatchEnabled = value;

                    // --

                    setChangedOpcServerWatchEnabled();
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

        [Category(CategoryOpcServer)]
        public int OpcServerWatchCycleTime
        {
            get
            {
                try
                {
                    return m_source.opcServerWatchCycleTime;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return 0;
            }

            set
            {
                try
                {
                    if (value < 1)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Value" }));
                    }

                    // --

                    m_source.opcServerWatchCycleTime = value;
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

        [Category(CategoryOpcServer)]
        public string OpcServerProcessName
        {
            get
            {
                try
                {
                    return m_source.opcServerProcessName;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }

            set
            {
                try
                {
                    if (value.Trim() == string.Empty)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0004", new object[] { "Value" }));
                    }

                    // --

                    m_source.opcServerProcessName = value;
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
                base.fTypeDescriptor.properties["EapWatchEnabled"].attributes.replace(new DisplayNameAttribute("Enabled"));
                base.fTypeDescriptor.properties["EapWatchCycleTime"].attributes.replace(new DisplayNameAttribute("Eap Watch Cycle Time (sec)"));
                // --
                base.fTypeDescriptor.properties["OpcServerWatchEnabled"].attributes.replace(new DisplayNameAttribute("Enabled"));
                base.fTypeDescriptor.properties["OpcServerWatchCycleTime"].attributes.replace(new DisplayNameAttribute("OPC Server Watch Cycle Time (sec)"));
                base.fTypeDescriptor.properties["OpcServerProcessName"].attributes.replace(new DisplayNameAttribute("OPC Server Process Name"));

                // -- 

                base.fTypeDescriptor.properties["EapWatchEnabled"].attributes.replace(new DefaultValueAttribute(this.EapWatchEnabled));
                base.fTypeDescriptor.properties["EapWatchCycleTime"].attributes.replace(new DefaultValueAttribute(this.EapWatchCycleTime));
                // --
                base.fTypeDescriptor.properties["OpcServerWatchEnabled"].attributes.replace(new DefaultValueAttribute(this.OpcServerWatchEnabled));
                base.fTypeDescriptor.properties["OpcServerWatchCycleTime"].attributes.replace(new DefaultValueAttribute(this.OpcServerWatchCycleTime));
                base.fTypeDescriptor.properties["OpcServerProcessName"].attributes.replace(new DefaultValueAttribute(this.OpcServerProcessName));

                // --

                setChangedEapWatchEnabled();
                setChangedOpcServerWatchEnabled();
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

        private void setChangedEapWatchEnabled(
            )
        {
            try
            {
                if (m_source.eapWatchEnabled == FYesNo.Yes)
                {
                    base.fTypeDescriptor.properties["EapWatchCycleTime"].attributes.replace(new BrowsableAttribute(true));
                }
                else
                {
                    base.fTypeDescriptor.properties["EapWatchCycleTime"].attributes.replace(new BrowsableAttribute(false));
                }

                // --

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

        //------------------------------------------------------------------------------------------------------------------------

        private void setChangedOpcServerWatchEnabled(
            )
        {
            try
            {
                if (m_source.opcServerWatchEnabled == FYesNo.Yes)
                {
                    base.fTypeDescriptor.properties["OpcServerWatchCycleTime"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["OpcServerProcessName"].attributes.replace(new BrowsableAttribute(true));
                }
                else
                {
                    base.fTypeDescriptor.properties["OpcServerWatchCycleTime"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["OpcServerProcessName"].attributes.replace(new BrowsableAttribute(false));
                }

                // --

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

    }   // Class end
}   // Namespace end
