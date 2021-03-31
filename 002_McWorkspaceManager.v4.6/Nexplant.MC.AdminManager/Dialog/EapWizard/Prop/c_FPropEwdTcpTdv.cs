/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropEwdTcpTdv.cs
--  Creator         : spike.lee
--  Create Date     : 2012.05.11
--  Description     : FAMate Admin Manager EAP Wizard TCP Device Source Object for TCP Class 
--  History         : Created by spike.lee at 2012.05.11
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
using Nexplant.MC.H101Interface;
using Infragistics.Win.UltraWinTree;

namespace Nexplant.MC.AdminManager
{
    public class FPropEwdTcpTdv : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";        
        private const string CategoryProtocol = "[02] Protocol";
        private const string CategoryTimeout = "[03] Timeout";

        // --

        private bool m_disposed = false;
        // --
        private string m_type = "TcpDevice";
        private FTcpEapWizard m_fOwnerForm = null;
        private UltraTreeNode m_tNodeTdv = null;
        private FXmlNode m_fXmlNodeTdv = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropEwdTcpTdv(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            FTcpEapWizard fOwnerForm,
            UltraTreeNode tNodeTdv,
            FXmlNode fXmlNodeTdv
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_fOwnerForm = fOwnerForm;
            m_tNodeTdv = tNodeTdv;
            m_fXmlNodeTdv = fXmlNodeTdv;
            // --
            init();
        }        

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropEwdTcpTdv(
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
                    m_tNodeTdv = null;
                    m_fXmlNodeTdv = null;
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
                    return m_fXmlNodeTdv.get_elemVal(
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

                    m_fXmlNodeTdv.set_elemVal(
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
                    return m_fXmlNodeTdv.get_elemVal(
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

                    m_fXmlNodeTdv.set_elemVal(
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
        public FDeviceMode Mode
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = m_fXmlNodeTdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Mode, 
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Mode
                        ).Trim();

                    // --

                    return (FDeviceMode)Enum.Parse(typeof(FDeviceMode), val);
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FDeviceMode.Both;
            }

            set
            {
                try
                {
                    m_fXmlNodeTdv.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Mode,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Mode,
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
        public FProtocol Protocol
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = m_fXmlNodeTdv.get_elemVal(
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
                return FProtocol.CUSTOM_001;
            }

            set
            {
                try
                {
                    m_fXmlNodeTdv.set_elemVal(
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
        public FConnectMode ConnectMode
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = m_fXmlNodeTdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_ConnectMode,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_ConnectMode
                        ).Trim();

                    // --

                    return (FConnectMode)Enum.Parse(typeof(FConnectMode), val);
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FConnectMode.Passive;
            }

            set
            {
                try
                {
                    m_fXmlNodeTdv.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_ConnectMode,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_ConnectMode,
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
        public string LocalIP
        {
            get
            {
                try
                {
                    return m_fXmlNodeTdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_LocalIp,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_LocalIp
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
                        FDebug.throwFException(this.fUIWizard.generateMessage("E0004", new object[] { "Local IP" }));
                    }

                    if (value.Length > 50)
                    {
                        FDebug.throwFException(this.fUIWizard.generateMessage("E0023", new object[] { "Local IP" }));
                    }

                    // --

                    m_fXmlNodeTdv.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_LocalIp,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_LocalIp,
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
        public int LocalPort
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = m_fXmlNodeTdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_LocalPort,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_LocalPort
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
                    if (value < 0 || value > 65535)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Local Port" }));
                    }                    

                    // --

                    m_fXmlNodeTdv.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_LocalPort,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_LocalPort,
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
        public string RemoteIP
        {
            get
            {
                try
                {
                    return m_fXmlNodeTdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_RemoteIp,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_RemoteIp
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
                        FDebug.throwFException(this.fUIWizard.generateMessage("E0004", new object[] { "Remote IP" }));
                    }

                    if (value.Length > 50)
                    {
                        FDebug.throwFException(this.fUIWizard.generateMessage("E0023", new object[] { "Remote IP" }));
                    }

                    // --

                    m_fXmlNodeTdv.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_RemoteIp,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_RemoteIp,
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
        public int RemotePort
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = m_fXmlNodeTdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_RemotePort,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_RemotePort
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
                    if (value < 0 || value > 65535)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Remote Port" }));
                    }

                    // --

                    m_fXmlNodeTdv.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_RemotePort,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_RemotePort,
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
        public int T3Timeout
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = m_fXmlNodeTdv.get_elemVal(
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

                    m_fXmlNodeTdv.set_elemVal(
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
                    val = m_fXmlNodeTdv.get_elemVal(
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

                    m_fXmlNodeTdv.set_elemVal(
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

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryTimeout)]
        public int T8Timeout
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = m_fXmlNodeTdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T8Timeout,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T8Timeout
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
                        FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "T8 Timeout" }));
                    }

                    // --

                    m_fXmlNodeTdv.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T8Timeout,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T8Timeout,
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
                base.fTypeDescriptor.properties["Mode"].attributes.replace(new DisplayNameAttribute("Mode"));
                base.fTypeDescriptor.properties["Protocol"].attributes.replace(new DisplayNameAttribute("Protocol"));
                base.fTypeDescriptor.properties["ConnectMode"].attributes.replace(new DisplayNameAttribute("Connect Mode"));
                base.fTypeDescriptor.properties["LocalIP"].attributes.replace(new DisplayNameAttribute("Local IP"));
                base.fTypeDescriptor.properties["LocalPort"].attributes.replace(new DisplayNameAttribute("Local Port"));
                base.fTypeDescriptor.properties["RemoteIP"].attributes.replace(new DisplayNameAttribute("Remote IP"));
                base.fTypeDescriptor.properties["RemotePort"].attributes.replace(new DisplayNameAttribute("Remote Port"));
                // --
                base.fTypeDescriptor.properties["T3Timeout"].attributes.replace(new DisplayNameAttribute("T3 Timeout"));
                base.fTypeDescriptor.properties["T5Timeout"].attributes.replace(new DisplayNameAttribute("T5 Timeout"));
                base.fTypeDescriptor.properties["T8Timeout"].attributes.replace(new DisplayNameAttribute("T8 Timeout"));

                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_type));
                // --
                val = m_fXmlNodeTdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Name,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Name
                    ).Trim();
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(val));
                // --
                val = m_fXmlNodeTdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Description,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Description
                    ).Trim();
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(val));        
                
                // --
                
                val = m_fXmlNodeTdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Mode,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Mode
                    ).Trim();
                base.fTypeDescriptor.properties["Mode"].attributes.replace(new DefaultValueAttribute((FDeviceMode)Enum.Parse(typeof(FDeviceMode), val)));        
                // --
                val = m_fXmlNodeTdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_ConnectMode,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_ConnectMode
                    ).Trim();
                base.fTypeDescriptor.properties["ConnectMode"].attributes.replace(new DefaultValueAttribute((FConnectMode)Enum.Parse(typeof(FConnectMode), val)));        
                // --
                val = m_fXmlNodeTdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Protocol,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Protocol
                    ).Trim();
                base.fTypeDescriptor.properties["Protocol"].attributes.replace(new DefaultValueAttribute((FProtocol)Enum.Parse(typeof(FProtocol), val)));        
                // --
                val = m_fXmlNodeTdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_LocalIp,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_LocalIp
                    ).Trim();
                base.fTypeDescriptor.properties["LocalIP"].attributes.replace(new DefaultValueAttribute(val));
                // --
                val = m_fXmlNodeTdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_LocalPort,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_LocalPort
                    ).Trim();
                base.fTypeDescriptor.properties["LocalPort"].attributes.replace(new DefaultValueAttribute(int.Parse(val)));
                // --
                val = m_fXmlNodeTdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_RemoteIp,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_RemoteIp
                    ).Trim();
                base.fTypeDescriptor.properties["RemoteIP"].attributes.replace(new DefaultValueAttribute(val));
                // --
                val = m_fXmlNodeTdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_RemotePort,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_RemotePort
                    ).Trim();
                base.fTypeDescriptor.properties["RemotePort"].attributes.replace(new DefaultValueAttribute(int.Parse(val)));
                
                // --
                
                val = m_fXmlNodeTdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T3Timeout,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T3Timeout
                    ).Trim();
                base.fTypeDescriptor.properties["T3Timeout"].attributes.replace(new DefaultValueAttribute(int.Parse(val)));
                // --
                val = m_fXmlNodeTdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T5Timeout,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T5Timeout
                    ).Trim();
                base.fTypeDescriptor.properties["T5Timeout"].attributes.replace(new DefaultValueAttribute(int.Parse(val)));
                // --
                val = m_fXmlNodeTdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T8Timeout,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T8Timeout
                    ).Trim();
                base.fTypeDescriptor.properties["T8Timeout"].attributes.replace(new DefaultValueAttribute(int.Parse(val)));

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
                base.fTypeDescriptor.properties["LocalIP"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["LocalPort"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["RemoteIP"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["RemotePort"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["LocalIP"].attributes.replace(new BrowsableAttribute(true));
                
                // --

                if (this.ConnectMode == FConnectMode.Passive)
                {
                    base.fTypeDescriptor.properties["LocalPort"].attributes.replace(new BrowsableAttribute(true));
                }
                else
                {
                    base.fTypeDescriptor.properties["RemoteIP"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["RemotePort"].attributes.replace(new BrowsableAttribute(true));
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
                m_fOwnerForm.refreshSchemaObject(m_fXmlNodeTdv, m_tNodeTdv);
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
