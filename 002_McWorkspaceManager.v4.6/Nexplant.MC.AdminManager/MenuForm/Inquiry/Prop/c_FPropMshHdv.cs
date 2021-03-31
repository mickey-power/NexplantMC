/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropMshHdv.cs
--  Creator         : mjkim
--  Create Date     : 2012.05.11
--  Description     : FAMate Admin Manager Model Version Schema Host Device Property Source Object Class 
--  History         : Created by mjkim at 2012.05.11
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public class FPropMshHdv : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryProtocol = "[02] Protocol";

        // --

        private bool m_disposed = false;
        // --
        private string m_type = "HostDevice";
        private FXmlNode m_fXmlNodeHdv = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropMshHdv(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            FXmlNode fXmlNodeHdv
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_fXmlNodeHdv = fXmlNodeHdv;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropMshHdv(
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
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_Name,
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_Name
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

        [Category(CategoryGeneral)]
        public string Description
        {
            get
            {
                try
                {
                    return m_fXmlNodeHdv.get_elemVal(
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_Description,
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_Description
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Protocol

        [Category(CategoryProtocol)]
        public string Driver
        {
            get
            {
                try
                {
                    return m_fXmlNodeHdv.get_elemVal(
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_Driver,
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_Driver
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
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_DriverDescription,
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_DriverDescription
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
                base.fTypeDescriptor.properties["Driver"].attributes.replace(new DisplayNameAttribute("Driver"));
                base.fTypeDescriptor.properties["DriverDescription"].attributes.replace(new DisplayNameAttribute("Driver Description"));

                // --
                
                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_type));
                // --
                val = m_fXmlNodeHdv.get_elemVal(
                    FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_Name,
                    FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_Name
                    ).Trim();
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(val));
                // --
                val = m_fXmlNodeHdv.get_elemVal(
                    FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_Description,
                    FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_Description
                    ).Trim();
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(val));
                // --
                val = m_fXmlNodeHdv.get_elemVal(
                    FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_Driver,
                    FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_Driver
                    ).Trim();
                base.fTypeDescriptor.properties["Driver"].attributes.replace(new DefaultValueAttribute(val));
                // --
                val = m_fXmlNodeHdv.get_elemVal(
                    FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_DriverDescription,
                    FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_DriverDescription
                    ).Trim();
                base.fTypeDescriptor.properties["DriverDescription"].attributes.replace(new DefaultValueAttribute(val));
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
