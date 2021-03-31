/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropEwdSecsSdv.cs
--  Creator         : spike.lee
--  Create Date     : 2012.05.11
--  Description     : FAMate Admin Manager EAP Wizard SECS Device Source Object for SECS Class 
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
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.H101Interface;
using Infragistics.Win.UltraWinTree;

namespace Nexplant.MC.AdminManager
{
    public class FPropEwdSecsSdv : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";        
        private const string CategoryProtocol = "[02] Protocol";
        private const string CategoryTimeout = "[03] Timeout";

        // --

        private bool m_disposed = false;
        // --
        private string m_type = "SecsDevice";
        private FSecsEapWizard m_fOwnerForm = null;
        private UltraTreeNode m_tNodeSdv = null;
        private FXmlNode m_fXmlNodeSdv = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropEwdSecsSdv(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            FSecsEapWizard fOwnerForm,
            UltraTreeNode tNodeSdv,
            FXmlNode fXmlNodeSdv
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_fOwnerForm = fOwnerForm;
            m_tNodeSdv = tNodeSdv;
            m_fXmlNodeSdv = fXmlNodeSdv;
            // --
            init();
        }        

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropEwdSecsSdv(
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
                    m_tNodeSdv = null;
                    m_fXmlNodeSdv = null;
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
                    return m_fXmlNodeSdv.get_elemVal(
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

                    m_fXmlNodeSdv.set_elemVal(
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
                    return m_fXmlNodeSdv.get_elemVal(
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

                    m_fXmlNodeSdv.set_elemVal(
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
                    val = m_fXmlNodeSdv.get_elemVal(
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
                    m_fXmlNodeSdv.set_elemVal(
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
                    val = m_fXmlNodeSdv.get_elemVal(
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
                return FProtocol.HSMS;
            }

            set
            {
                try
                {
                    m_fXmlNodeSdv.set_elemVal(
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
                    val = m_fXmlNodeSdv.get_elemVal(
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
                    m_fXmlNodeSdv.set_elemVal(
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
                    return m_fXmlNodeSdv.get_elemVal(
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

                    m_fXmlNodeSdv.set_elemVal(
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
                    val = m_fXmlNodeSdv.get_elemVal(
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

                    m_fXmlNodeSdv.set_elemVal(
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
                    return m_fXmlNodeSdv.get_elemVal(
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

                    m_fXmlNodeSdv.set_elemVal(
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
                    val = m_fXmlNodeSdv.get_elemVal(
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

                    m_fXmlNodeSdv.set_elemVal(
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

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryProtocol)]
        public string SerialPort
        {
            get
            {
                try
                {
                    return m_fXmlNodeSdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_SerialPort,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_SerialPort
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
                        FDebug.throwFException(this.fUIWizard.generateMessage("E0004", new object[] { "Serial Port" }));
                    }

                    if (value.Length > 20)
                    {
                        FDebug.throwFException(this.fUIWizard.generateMessage("E0023", new object[] { "Serial Port" }));
                    }

                    // --

                    m_fXmlNodeSdv.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_SerialPort,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_SerialPort,
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
        public int Baud
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = m_fXmlNodeSdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Baud,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Baud
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
                    if (value < 1)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Baud" }));
                    }

                    // --

                    m_fXmlNodeSdv.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Baud,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Baud,
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
        public bool RBit
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = m_fXmlNodeSdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_RBit,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_RBit
                        ).Trim();

                    // --

                    return bool.Parse(val);                    
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
                    m_fXmlNodeSdv.set_elemVal(
                       FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_RBit,
                       FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_RBit,
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
        public bool Interleave
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = m_fXmlNodeSdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Interleave,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Interleave
                        ).Trim();

                    // --

                    return bool.Parse(val);
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
                    m_fXmlNodeSdv.set_elemVal(
                       FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Interleave,
                       FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Interleave,
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
        public bool DuplicateError
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = m_fXmlNodeSdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_DuplicateError,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_DuplicateError
                        ).Trim();

                    // --

                    return bool.Parse(val);
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
                    m_fXmlNodeSdv.set_elemVal(
                       FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_DuplicateError,
                       FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_DuplicateError,
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
        public bool IgnoreSystemBytes
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = m_fXmlNodeSdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_IgnoreSystemBytes,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_IgnoreSystemBytes
                        ).Trim();

                    // --

                    return bool.Parse(val);
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
                    m_fXmlNodeSdv.set_elemVal(
                       FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_IgnoreSystemBytes,
                       FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_IgnoreSystemBytes,
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
        public int LinkTestPeriod
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = m_fXmlNodeSdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_LinkTestTimePeriod,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_LinkTestTimePeriod
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
                    if (value < 0 || value > 240)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Link Test Period" }));
                    }

                    // --

                    m_fXmlNodeSdv.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_LinkTestTimePeriod,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_LinkTestTimePeriod,
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
        public int RetryLimit
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = m_fXmlNodeSdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_RetryLimit,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_RetryLimit
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
                    if (value < 0 || value > 31)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Link Test Period" }));
                    }

                    // --

                    m_fXmlNodeSdv.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_RetryLimit,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_RetryLimit,
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
        public float T1Timeout
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = m_fXmlNodeSdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T1Timeout,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T1Timeout
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
                        FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "T1 Timeout" }));
                    }

                    // validate resolution (applied to SEMI E4-0699 p10.) 
                    if (setValue % resolution != 0)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "T1 Timeout" }));
                    }

                    // --

                    m_fXmlNodeSdv.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T1Timeout,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T1Timeout,
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
        public float T2Timeout
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = m_fXmlNodeSdv.get_elemVal(
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

                    m_fXmlNodeSdv.set_elemVal(
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
                    val = m_fXmlNodeSdv.get_elemVal(
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

                    m_fXmlNodeSdv.set_elemVal(
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
        public int T4Timeout
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = m_fXmlNodeSdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T4Timeout,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T4Timeout
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
                        FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "T4 Timeout" }));
                    }

                    // --

                    m_fXmlNodeSdv.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T4Timeout,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T4Timeout,
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
                    val = m_fXmlNodeSdv.get_elemVal(
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

                    m_fXmlNodeSdv.set_elemVal(
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
        public int T6Timeout
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = m_fXmlNodeSdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T6Timeout,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T6Timeout
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
                        FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "T6 Timeout" }));
                    }

                    // --

                    m_fXmlNodeSdv.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T6Timeout,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T6Timeout,
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
        public int T7Timeout
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = m_fXmlNodeSdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T7Timeout,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T7Timeout
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
                        FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "T7 Timeout" }));
                    }

                    // --

                    m_fXmlNodeSdv.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T7Timeout,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T7Timeout,
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
                    val = m_fXmlNodeSdv.get_elemVal(
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

                    m_fXmlNodeSdv.set_elemVal(
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
                base.fTypeDescriptor.properties["SerialPort"].attributes.replace(new DisplayNameAttribute("Serial Port"));
                base.fTypeDescriptor.properties["Baud"].attributes.replace(new DisplayNameAttribute("Baud"));
                base.fTypeDescriptor.properties["RBit"].attributes.replace(new DisplayNameAttribute("R-Bit"));
                base.fTypeDescriptor.properties["Interleave"].attributes.replace(new DisplayNameAttribute("Interleave"));
                base.fTypeDescriptor.properties["DuplicateError"].attributes.replace(new DisplayNameAttribute("Duplicate Error"));
                base.fTypeDescriptor.properties["IgnoreSystemBytes"].attributes.replace(new DisplayNameAttribute("Ignore System Bytes"));
                base.fTypeDescriptor.properties["LinkTestPeriod"].attributes.replace(new DisplayNameAttribute("Link Test Period"));
                base.fTypeDescriptor.properties["RetryLimit"].attributes.replace(new DisplayNameAttribute("Retry Limit"));
                // --
                base.fTypeDescriptor.properties["T1Timeout"].attributes.replace(new DisplayNameAttribute("T1 Timeout"));
                base.fTypeDescriptor.properties["T2Timeout"].attributes.replace(new DisplayNameAttribute("T2 Timeout"));
                base.fTypeDescriptor.properties["T3Timeout"].attributes.replace(new DisplayNameAttribute("T3 Timeout"));
                base.fTypeDescriptor.properties["T4Timeout"].attributes.replace(new DisplayNameAttribute("T4 Timeout"));
                base.fTypeDescriptor.properties["T5Timeout"].attributes.replace(new DisplayNameAttribute("T5 Timeout"));
                base.fTypeDescriptor.properties["T6Timeout"].attributes.replace(new DisplayNameAttribute("T6 Timeout"));
                base.fTypeDescriptor.properties["T7Timeout"].attributes.replace(new DisplayNameAttribute("T7 Timeout"));
                base.fTypeDescriptor.properties["T8Timeout"].attributes.replace(new DisplayNameAttribute("T8 Timeout"));

                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_type));
                // --
                val = m_fXmlNodeSdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Name,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Name
                    ).Trim();
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(val));
                // --
                val = m_fXmlNodeSdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Description,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Description
                    ).Trim();
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(val));        
                
                // --
                
                val = m_fXmlNodeSdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Mode,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Mode
                    ).Trim();
                base.fTypeDescriptor.properties["Mode"].attributes.replace(new DefaultValueAttribute((FDeviceMode)Enum.Parse(typeof(FDeviceMode), val)));        
                // --
                val = m_fXmlNodeSdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_ConnectMode,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_ConnectMode
                    ).Trim();
                base.fTypeDescriptor.properties["ConnectMode"].attributes.replace(new DefaultValueAttribute((FConnectMode)Enum.Parse(typeof(FConnectMode), val)));        
                // --
                val = m_fXmlNodeSdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Protocol,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Protocol
                    ).Trim();
                base.fTypeDescriptor.properties["Protocol"].attributes.replace(new DefaultValueAttribute((FProtocol)Enum.Parse(typeof(FProtocol), val)));        
                // --
                val = m_fXmlNodeSdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_LocalIp,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_LocalIp
                    ).Trim();
                base.fTypeDescriptor.properties["LocalIP"].attributes.replace(new DefaultValueAttribute(val));
                // --
                val = m_fXmlNodeSdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_LocalPort,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_LocalPort
                    ).Trim();
                base.fTypeDescriptor.properties["LocalPort"].attributes.replace(new DefaultValueAttribute(int.Parse(val)));
                // --
                val = m_fXmlNodeSdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_RemoteIp,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_RemoteIp
                    ).Trim();
                base.fTypeDescriptor.properties["RemoteIP"].attributes.replace(new DefaultValueAttribute(val));
                // --
                val = m_fXmlNodeSdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_RemotePort,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_RemotePort
                    ).Trim();
                base.fTypeDescriptor.properties["RemotePort"].attributes.replace(new DefaultValueAttribute(int.Parse(val)));
                // --
                val = m_fXmlNodeSdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_SerialPort,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_SerialPort
                    ).Trim();
                base.fTypeDescriptor.properties["SerialPort"].attributes.replace(new DefaultValueAttribute(val));
                // --
                val = m_fXmlNodeSdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Baud,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Baud
                    ).Trim();
                base.fTypeDescriptor.properties["Baud"].attributes.replace(new DefaultValueAttribute(int.Parse(val)));
                // --
                val = m_fXmlNodeSdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_RBit,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_RBit
                    ).Trim();
                base.fTypeDescriptor.properties["RBit"].attributes.replace(new DefaultValueAttribute(bool.Parse(val)));
                // --
                val = m_fXmlNodeSdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Interleave,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Interleave
                    ).Trim();
                base.fTypeDescriptor.properties["Interleave"].attributes.replace(new DefaultValueAttribute(bool.Parse(val)));
                // --
                val = m_fXmlNodeSdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_DuplicateError,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_DuplicateError
                    ).Trim();
                base.fTypeDescriptor.properties["DuplicateError"].attributes.replace(new DefaultValueAttribute(bool.Parse(val)));
                // --
                val = m_fXmlNodeSdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_IgnoreSystemBytes,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_IgnoreSystemBytes
                    ).Trim();
                base.fTypeDescriptor.properties["IgnoreSystemBytes"].attributes.replace(new DefaultValueAttribute(bool.Parse(val)));
                // --
                val = m_fXmlNodeSdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_LinkTestTimePeriod,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_LinkTestTimePeriod
                    ).Trim();
                base.fTypeDescriptor.properties["LinkTestPeriod"].attributes.replace(new DefaultValueAttribute(int.Parse(val)));
                // --
                val = m_fXmlNodeSdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_RetryLimit,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_RetryLimit
                    ).Trim();
                base.fTypeDescriptor.properties["RetryLimit"].attributes.replace(new DefaultValueAttribute(int.Parse(val)));
                
                // --
                
                val = m_fXmlNodeSdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T1Timeout,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T1Timeout
                    ).Trim();
                base.fTypeDescriptor.properties["T1Timeout"].attributes.replace(new DefaultValueAttribute(float.Parse(val)));
                // --
                val = m_fXmlNodeSdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T2Timeout,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T2Timeout
                    ).Trim();
                base.fTypeDescriptor.properties["T2Timeout"].attributes.replace(new DefaultValueAttribute(float.Parse(val)));
                // --
                val = m_fXmlNodeSdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T3Timeout,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T3Timeout
                    ).Trim();
                base.fTypeDescriptor.properties["T3Timeout"].attributes.replace(new DefaultValueAttribute(int.Parse(val)));
                // --
                val = m_fXmlNodeSdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T4Timeout,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T4Timeout
                    ).Trim();
                base.fTypeDescriptor.properties["T4Timeout"].attributes.replace(new DefaultValueAttribute(int.Parse(val)));
                // --
                val = m_fXmlNodeSdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T5Timeout,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T5Timeout
                    ).Trim();
                base.fTypeDescriptor.properties["T5Timeout"].attributes.replace(new DefaultValueAttribute(int.Parse(val)));
                // --
                val = m_fXmlNodeSdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T6Timeout,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T6Timeout
                    ).Trim();
                base.fTypeDescriptor.properties["T6Timeout"].attributes.replace(new DefaultValueAttribute(int.Parse(val)));
                // --
                val = m_fXmlNodeSdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T7Timeout,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T7Timeout
                    ).Trim();
                base.fTypeDescriptor.properties["T7Timeout"].attributes.replace(new DefaultValueAttribute(int.Parse(val)));
                // --
                val = m_fXmlNodeSdv.get_elemVal(
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
                base.fTypeDescriptor.properties["ConnectMode"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["LocalIP"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["LocalPort"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["RemoteIP"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["RemotePort"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["SerialPort"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["Baud"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["RBit"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["Interleave"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["DuplicateError"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["IgnoreSystemBytes"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["LinkTestPeriod"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["RetryLimit"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["T1Timeout"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["T2Timeout"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["T3Timeout"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["T4Timeout"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["T5Timeout"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["T6Timeout"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["T7Timeout"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["T8Timeout"].attributes.replace(new BrowsableAttribute(false));

                // --

                if (this.Protocol == FProtocol.SECS1)
                {
                    base.fTypeDescriptor.properties["SerialPort"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["Baud"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["RBit"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["Interleave"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["DuplicateError"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["IgnoreSystemBytes"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["RetryLimit"].attributes.replace(new BrowsableAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["T1Timeout"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["T2Timeout"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["T3Timeout"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["T4Timeout"].attributes.replace(new BrowsableAttribute(true));
                }
                else if (
                    this.Protocol == FProtocol.TCPIP ||
                    this.Protocol == FProtocol.TELNET
                    )
                {
                    base.fTypeDescriptor.properties["ConnectMode"].attributes.replace(new BrowsableAttribute(true));
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
                    base.fTypeDescriptor.properties["RBit"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["Interleave"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["DuplicateError"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["IgnoreSystemBytes"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["RetryLimit"].attributes.replace(new BrowsableAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["T1Timeout"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["T2Timeout"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["T3Timeout"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["T4Timeout"].attributes.replace(new BrowsableAttribute(true));
                }
                else if (this.Protocol == FProtocol.HSMS)
                {
                    base.fTypeDescriptor.properties["ConnectMode"].attributes.replace(new BrowsableAttribute(true));
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
                    base.fTypeDescriptor.properties["LinkTestPeriod"].attributes.replace(new BrowsableAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["T3Timeout"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["T5Timeout"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["T6Timeout"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["T7Timeout"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["T8Timeout"].attributes.replace(new BrowsableAttribute(true));
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
                m_fOwnerForm.refreshSchemaObject(m_fXmlNodeSdv, m_tNodeSdv);
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
