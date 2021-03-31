/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropEwdOpcHdv.cs
--  Creator         : spike.lee
--  Create Date     : 2015.07.24
--  Description     : FAMate Admin Manager EAP Wizard Host Device Source Object for OPC Class 
--  History         : Created by spike.lee at 2015.07.24
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing;
using System.IO;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.H101Interface;
using Infragistics.Win.UltraWinTree;

namespace Nexplant.MC.AdminManager
{
    public class FPropEwdOpcHdv : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryProtocol = "[02] Protocol";
        private const string CategoryTimeout = "[03] Timeout";

        // --

        private bool m_disposed = false;
        // --
        private string m_type = "HostDevice";
        private FOpcEapWizard m_fOwnerForm = null;
        private UltraTreeNode m_tNodeHdv = null;
        private FXmlNode m_fXmlNodeHdv = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropEwdOpcHdv(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            FOpcEapWizard fOwnerForm,
            UltraTreeNode tNodeHdv,
            FXmlNode fXmlNodeHdv
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_fOwnerForm = fOwnerForm;
            m_tNodeHdv = tNodeHdv;
            m_fXmlNodeHdv = fXmlNodeHdv;
            // --
            init();
        }        

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropEwdOpcHdv(
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
                    m_tNodeHdv = null;
                    m_fXmlNodeHdv = null;
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
                    return m_fXmlNodeHdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_Name, 
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_Name
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

                    m_fXmlNodeHdv.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_Name,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_Name,
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
                    return m_fXmlNodeHdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_Description,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_Description
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

                    m_fXmlNodeHdv.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_Description,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_Description,
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
                    val = m_fXmlNodeHdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_Mode,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_Mode
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
                    m_fXmlNodeHdv.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_Mode,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_Mode,
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
        [Editor(typeof(FPropAttrEwdOpcHdvDriverUITypeEditor), typeof(UITypeEditor))]
        public string Driver
        {
            get
            {
                try
                {
                    return m_fXmlNodeHdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_Driver,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_Driver
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryProtocol)]
        public string DriverDescription
        {
            get
            {
                try
                {
                    return m_fXmlNodeHdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_DriverDescription,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_DriverDescription
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryProtocol)]
        [Editor(typeof(FPropAttrEwdOpcHdvDriverOptionUITypeEditor), typeof(UITypeEditor))]
        public string DriverOption
        {
            get
            {
                try
                {
                    if (m_fOwnerForm.fHostDevice.driver == string.Empty)
                    {
                        return string.Empty;
                    }
                    return m_fOwnerForm.fHostDevice.createHostDriverOption().ToString();
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Timeout

        [Category(CategoryTimeout)]
        public int TransactionTimeout
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = m_fXmlNodeHdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_TransactionTimeout,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_TransactionTimeout
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
                        FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Transaction Timeout" }));
                    }

                    // --

                    m_fXmlNodeHdv.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_TransactionTimeout,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_TransactionTimeout,
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

        [Browsable(false)]
        public FHostDevice fHostDevice
        {
            get
            {
                try
                {
                    return m_fOwnerForm.fHostDevice;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            string fileName = string.Empty;
            string val = string.Empty;

            try
            {
                val = m_fXmlNodeHdv.get_elemVal(
                   FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_Driver,
                   FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_Driver
                   ).Trim();
                // --
                if (val != string.Empty)
                {
                    fileName = Path.Combine(this.mainObject.fWsmCore.hostDriverPath, val);
                    m_fOwnerForm.fHostDevice.setHostDriver(fileName);
                }

                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DisplayNameAttribute("Type"));                
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DisplayNameAttribute("Name"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
                // --
                base.fTypeDescriptor.properties["Mode"].attributes.replace(new DisplayNameAttribute("Mode"));
                base.fTypeDescriptor.properties["Driver"].attributes.replace(new DisplayNameAttribute("Driver"));
                base.fTypeDescriptor.properties["DriverDescription"].attributes.replace(new DisplayNameAttribute("Driver Description"));
                base.fTypeDescriptor.properties["DriverOption"].attributes.replace(new DisplayNameAttribute("Driver Option"));
                // --
                base.fTypeDescriptor.properties["TransactionTimeout"].attributes.replace(new DisplayNameAttribute("Transaction Timeout"));

                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_type));
                // --
                val = m_fXmlNodeHdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_Name,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_Name
                    ).Trim();
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(val));
                // --
                val = m_fXmlNodeHdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_Description,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_Description
                    ).Trim();
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(val));               
                
                // --
                
                val = m_fXmlNodeHdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_Mode,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_Mode
                    ).Trim();
                base.fTypeDescriptor.properties["Mode"].attributes.replace(new DefaultValueAttribute((FDeviceMode)Enum.Parse(typeof(FDeviceMode), val)));               
                // --
                val = m_fXmlNodeHdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_Driver,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_Driver
                    ).Trim();
                base.fTypeDescriptor.properties["Driver"].attributes.replace(new DefaultValueAttribute(val));               
                // --
                val = m_fXmlNodeHdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_DriverDescription,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_DriverDescription
                    ).Trim();
                base.fTypeDescriptor.properties["DriverDescription"].attributes.replace(new DefaultValueAttribute(val));
                // --
                
                if (fileName != string.Empty)
                {
                    val = m_fXmlNodeHdv.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_DriverOption,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_DriverOption
                        ).Trim();
                    m_fOwnerForm.fHostDevice.driverOption = val;
                    base.fTypeDescriptor.properties["DriverOption"].attributes.replace(new DefaultValueAttribute(m_fOwnerForm.fHostDevice.createHostDriverOption().ToString()));
                }
                else
                {
                    base.fTypeDescriptor.properties["DriverOption"].attributes.replace(new DefaultValueAttribute(""));
                }
                
                // --
                
                val = m_fXmlNodeHdv.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_TransactionTimeout,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_TransactionTimeout
                    ).Trim();
                base.fTypeDescriptor.properties["TransactionTimeout"].attributes.replace(new DefaultValueAttribute(int.Parse(val)));
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

        private void refresh(
            )
        {
            try
            {
                m_fOwnerForm.refreshSchemaObject(m_fXmlNodeHdv, m_tNodeHdv);
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

        public void setHostDriver(
            string fileName
            )
        {
            try
            {
                fileName = Path.Combine(this.mainObject.fWsmCore.hostDriverPath, fileName);
                m_fOwnerForm.fHostDevice.setHostDriver(fileName);

                // --

                m_fXmlNodeHdv.set_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_Driver,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_Driver,
                    Path.GetFileName(fileName)
                    );
                // --
                m_fXmlNodeHdv.set_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_DriverOption,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_DriverOption,
                    m_fOwnerForm.fHostDevice.driverOption
                    );

                // --

                this.fPropGrid.Refresh();
                refresh();
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

        public void setHostDriverOption(
            string driverOption
            )
        {
            try
            {
                m_fXmlNodeHdv.set_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_DriverOption,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_DriverOption,
                    driverOption
                    );
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
