/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropEwdOpcOdv.cs
--  Creator         : spike.lee
--  Create Date     : 2015.07.24
--  Description     : FAMate Admin Manager EAP Wizard OPC Device Source Object for PLC Class 
--  History         : Created by spike.lee at 2015.07.24
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
using Nexplant.MC.H101Interface;
using Infragistics.Win.UltraWinTree;

namespace Nexplant.MC.AdminManager
{
    public class FPropEwdOpcOdv : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";        
        private const string CategoryProtocol = "[02] Protocol";
        private const string CategoryTimeout = "[03] Timeout";

        // --

        private bool m_disposed = false;
        // --
        private string m_type = "OpcDevice";
        private FOpcEapWizard m_fOwnerForm = null;
        private UltraTreeNode m_tNodeOdv = null;
        private FXmlNode m_fXmlNodeOdv = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropEwdOpcOdv(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            FOpcEapWizard fOwnerForm,
            UltraTreeNode tNodeOdv,
            FXmlNode fXmlNodeOdv
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_fOwnerForm = fOwnerForm;
            m_tNodeOdv = tNodeOdv;
            m_fXmlNodeOdv = fXmlNodeOdv;
            // --
            init();
        }        

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropEwdOpcOdv(
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
                    m_fOwnerForm = null;
                    m_tNodeOdv = null;
                    m_fXmlNodeOdv = null;
                }                
                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region General

        [Category(CategoryGeneral)]
        public string Type
        {
            get
            {
                try
                {
                    return m_type;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryGeneral)]
        public string Name
        {
            get
            {
                try
                {
                    return m_fXmlNodeOdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Name, 
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Name
                        ).Trim();
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
                    FCommon.validateName(value, true, this.fUIWizard, "Name");

                    if (value.Length > 50)
                    {
                        FDebug.throwFException(this.fUIWizard.generateMessage("E0023", new object[] { "Name" }));
                    }

                    // --

                    m_fXmlNodeOdv.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Name,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Name,
                        value
                        );

                    // --

                    refresh();
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

        [Category(CategoryGeneral)]
        public string Description
        {
            get
            {
                try
                {
                    return m_fXmlNodeOdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Description,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Description
                        ).Trim();
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
                    if (value.Length > 100)
                    {
                        FDebug.throwFException(this.fUIWizard.generateMessage("E0023", new object[] { "Description" }));
                    }

                    // --

                    m_fXmlNodeOdv.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Description,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Description,
                        value
                        );

                    // --

                    refresh();
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

        #region Protocol

        [Category(CategoryProtocol)]
        public FProtocol Protocol
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = m_fXmlNodeOdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Protocol, 
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Protocol
                        ).Trim();

                    // --

                    return (FProtocol)Enum.Parse(typeof(FProtocol), val);
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FProtocol.KEPWARE;
            }

            set
            {
                try
                {
                    m_fXmlNodeOdv.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Protocol,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Protocol,
                        value.ToString()
                        );
                    
                    // --

                    setChangedProtocol();

                    // --

                    refresh();
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

        [Category(CategoryProtocol)]
        public string Url
        {
            get
            {
                try
                {
                    return m_fXmlNodeOdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_OpcUrl,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_OpcUrl
                        ).Trim();
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
                        FDebug.throwFException(this.fUIWizard.generateMessage("E0004", new object[] { "Url" }));
                    }

                    if (value.Length > 255)
                    {
                        FDebug.throwFException(this.fUIWizard.generateMessage("E0023", new object[] { "Url" }));
                    }

                    // --

                    m_fXmlNodeOdv.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_OpcUrl,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_OpcUrl,
                        value
                        );

                    // --

                    refresh();
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

        [Category(CategoryProtocol)]
        public string ProgId
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = m_fXmlNodeOdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_OpcProgId,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_OpcProgId
                        ).Trim();

                    // --

                    return val;
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
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "ProgId" }));
                    }

                    // --

                    m_fXmlNodeOdv.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_OpcProgId,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_OpcProgId,
                        value
                        );

                    // --

                    refresh();
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

        [Category(CategoryProtocol)]
        public int HandleId
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = m_fXmlNodeOdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_OpcHandleId,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_OpcHandleId
                        ).Trim();

                    // --

                    return int.Parse(val);
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
                    if (value < 0 || value > int.MaxValue)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Handle ID" }));
                    }

                    // --

                    m_fXmlNodeOdv.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_OpcHandleId,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_OpcHandleId,
                        value.ToString()
                        );

                    // --

                    refresh();
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

        [Category(CategoryProtocol)]
        public string LocalId
        {
            get
            {
                try
                {
                    return m_fXmlNodeOdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_OpcLocalId,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_OpcLocalId
                        ).Trim();
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
                        FDebug.throwFException(this.fUIWizard.generateMessage("E0004", new object[] { "Local ID" }));
                    }

                    if (value.Length > 255)
                    {
                        FDebug.throwFException(this.fUIWizard.generateMessage("E0023", new object[] { "Local ID" }));
                    }

                    // --

                    m_fXmlNodeOdv.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_OpcLocalId,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_OpcLocalId,
                        value
                        );

                    // --

                    refresh();
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

        [Category(CategoryProtocol)]
        public string Namespace
        {
            get
            {
                try
                {
                    return m_fXmlNodeOdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_OpcDefaultNamespace,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_OpcDefaultNamespace
                        ).Trim();
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
                        FDebug.throwFException(this.fUIWizard.generateMessage("E0004", new object[] { "Namespace" }));
                    }

                    if (value.Length > 255)
                    {
                        FDebug.throwFException(this.fUIWizard.generateMessage("E0023", new object[] { "Namespace" }));
                    }

                    // --

                    m_fXmlNodeOdv.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_OpcDefaultNamespace,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_OpcDefaultNamespace,
                        value
                        );

                    // --

                    refresh();
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

        [Category(CategoryProtocol)]
        public int KeepAliveTime
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = m_fXmlNodeOdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_OpcKeepAliveTime,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_OpcKeepAliveTime
                        ).Trim();

                    // --

                    return int.Parse(val);
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
                    if (value < 1 || value > 120)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Keep Alive Time" }));
                    }

                    // --

                    m_fXmlNodeOdv.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_OpcKeepAliveTime,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_OpcKeepAliveTime,
                        value.ToString()
                        );

                    // --

                    refresh();
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

        [Category(CategoryProtocol)]
        public int EventReloadTime
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = m_fXmlNodeOdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_OpcEventReloadTime,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_OpcEventReloadTime
                        ).Trim();

                    // --

                    return int.Parse(val);
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
                    if (value < 1 || value > 120)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Event Reload Time" }));
                    }

                    // --

                    m_fXmlNodeOdv.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_OpcEventReloadTime,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_OpcEventReloadTime,
                        value.ToString()
                        );

                    // --

                    refresh();
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

        #region Timeout

        [Category(CategoryTimeout)]
        public float T2Timeout
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = m_fXmlNodeOdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T2Timeout,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T2Timeout
                        ).Trim();

                    // --

                    return float.Parse(val);
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
                decimal setValue = 0;
                decimal resolution = 0.1m;

                try
                {
                    setValue = (decimal)value;

                    // validate range (applied to SEMI E4-0699 p10.)
                    if (setValue < 0.1m || setValue > 10.0m)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "T2 Timeout" }));
                    }

                    // validate resolution (applied to SEMI E4-0699 p10.) 
                    if (setValue % resolution != 0)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "T2 Timeout" }));
                    }

                    // --

                    m_fXmlNodeOdv.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T2Timeout,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T2Timeout,
                        value.ToString()
                        );

                    // --

                    refresh();
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

        [Category(CategoryTimeout)]
        public int T3Timeout
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = m_fXmlNodeOdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T3Timeout,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T3Timeout
                        ).Trim();

                    // --

                    return int.Parse(val);
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
                    if (value < 1 || value > 120)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "T3 Timeout" }));
                    }

                    // --

                    m_fXmlNodeOdv.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T3Timeout,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T3Timeout,
                        value.ToString()
                        );

                    // --

                    refresh();
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

        [Category(CategoryTimeout)]
        public int T5Timeout
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = m_fXmlNodeOdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T5Timeout,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T5Timeout
                        ).Trim();

                    // --

                    return int.Parse(val);
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
                    if (value < 1 || value > 240)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "T5 Timeout" }));
                    }

                    // --

                    m_fXmlNodeOdv.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T5Timeout,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T5Timeout,
                        value.ToString()
                        );

                    // --

                    refresh();
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
            string val = string.Empty;

            try
            {
                base.fTypeDescriptor.properties["Type"].attributes.replace(new DisplayNameAttribute("Type"));                
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DisplayNameAttribute("Name"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
                // --
                base.fTypeDescriptor.properties["Protocol"].attributes.replace(new DisplayNameAttribute("Protocol"));
                base.fTypeDescriptor.properties["Url"].attributes.replace(new DisplayNameAttribute("Url"));
                base.fTypeDescriptor.properties["ProgId"].attributes.replace(new DisplayNameAttribute("Prog ID"));
                base.fTypeDescriptor.properties["HandleId"].attributes.replace(new DisplayNameAttribute("Handle ID"));
                base.fTypeDescriptor.properties["LocalId"].attributes.replace(new DisplayNameAttribute("Local ID"));
                base.fTypeDescriptor.properties["Namespace"].attributes.replace(new DisplayNameAttribute("Default Namespace"));
                base.fTypeDescriptor.properties["KeepAliveTime"].attributes.replace(new DisplayNameAttribute("Keep Alive Time"));
                base.fTypeDescriptor.properties["EventReloadTime"].attributes.replace(new DisplayNameAttribute("Event Reload Time"));
                // --
                base.fTypeDescriptor.properties["T2Timeout"].attributes.replace(new DisplayNameAttribute("T2 Timeout"));
                base.fTypeDescriptor.properties["T3Timeout"].attributes.replace(new DisplayNameAttribute("T3 Timeout"));
                base.fTypeDescriptor.properties["T5Timeout"].attributes.replace(new DisplayNameAttribute("T5 Timeout"));
                
                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_type));
                // --
                val = m_fXmlNodeOdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Name,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Name
                    ).Trim();
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(val));
                // --
                val = m_fXmlNodeOdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Description,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Description
                    ).Trim();
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(val));        
                
                // --
                
                val = m_fXmlNodeOdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Protocol,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Protocol
                    ).Trim();
                base.fTypeDescriptor.properties["Protocol"].attributes.replace(new DefaultValueAttribute((FProtocol)Enum.Parse(typeof(FProtocol), val)));        
                // --                
                val = m_fXmlNodeOdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_OpcUrl,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_OpcUrl
                    ).Trim();
                base.fTypeDescriptor.properties["Url"].attributes.replace(new DefaultValueAttribute(val));
                // --
                val = m_fXmlNodeOdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_OpcProgId,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_OpcProgId
                    ).Trim();
                base.fTypeDescriptor.properties["ProgId"].attributes.replace(new DefaultValueAttribute(val));
                // --
                val = m_fXmlNodeOdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_OpcHandleId,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_OpcHandleId
                    ).Trim();
                base.fTypeDescriptor.properties["HandleId"].attributes.replace(new DefaultValueAttribute(int.Parse(val)));
                // --
                val = m_fXmlNodeOdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_OpcLocalId,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_OpcLocalId
                    ).Trim();
                base.fTypeDescriptor.properties["LocalId"].attributes.replace(new DefaultValueAttribute(val));
                // --
                val = m_fXmlNodeOdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_OpcDefaultNamespace,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_OpcDefaultNamespace
                    ).Trim();
                base.fTypeDescriptor.properties["Namespace"].attributes.replace(new DefaultValueAttribute(val));
                // --
                val = m_fXmlNodeOdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_OpcKeepAliveTime,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_OpcKeepAliveTime
                    ).Trim();
                base.fTypeDescriptor.properties["KeepAliveTime"].attributes.replace(new DefaultValueAttribute(int.Parse(val)));
                // --
                val = m_fXmlNodeOdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_OpcEventReloadTime,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_OpcEventReloadTime
                    ).Trim();
                base.fTypeDescriptor.properties["EventReloadTime"].attributes.replace(new DefaultValueAttribute(int.Parse(val)));

                // --
                
                val = m_fXmlNodeOdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T2Timeout,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T2Timeout
                    ).Trim();
                base.fTypeDescriptor.properties["T2Timeout"].attributes.replace(new DefaultValueAttribute(float.Parse(val)));
                // --
                val = m_fXmlNodeOdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T3Timeout,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T3Timeout
                    ).Trim();
                base.fTypeDescriptor.properties["T3Timeout"].attributes.replace(new DefaultValueAttribute(int.Parse(val)));
                // --
                val = m_fXmlNodeOdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T5Timeout,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T5Timeout
                    ).Trim();
                base.fTypeDescriptor.properties["T5Timeout"].attributes.replace(new DefaultValueAttribute(int.Parse(val)));

                // --

                setChangedProtocol();
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

        private void setChangedProtocol(
            )
        {
            try
            {
                base.fTypeDescriptor.properties["Url"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["ProgId"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["HandleId"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["LocalId"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["ItemNameFormat"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["BrowerItemNameFormat"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["Namespace"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["KeepAliveTime"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["EventReloadTime"].attributes.replace(new BrowsableAttribute(false));

                // --

                // ***
                // Modified by spike.lee at 2016.01.19
                // 프로토콜이 OPC DA인 경우에만 COM ID 입력 가능하도록 처리
                // ***
                if (this.Protocol == FProtocol.KEPWARE || this.Protocol == FProtocol.OPCUA)
                {
                    base.fTypeDescriptor.properties["Url"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["HandleId"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["LocalId"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["ItemNameFormat"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["BrowerItemNameFormat"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["Namespace"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["KeepAliveTime"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["EventReloadTime"].attributes.replace(new BrowsableAttribute(true));
                }
                else if (this.Protocol == FProtocol.OPCDA)
                {
                    base.fTypeDescriptor.properties["Url"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["ProgId"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["HandleId"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["LocalId"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["ItemNameFormat"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["BrowerItemNameFormat"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["Namespace"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["KeepAliveTime"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["EventReloadTime"].attributes.replace(new BrowsableAttribute(true));
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

        private void refresh(
            )
        {
            try
            {
                m_fOwnerForm.refreshSchemaObject(m_fXmlNodeOdv, m_tNodeOdv);
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
