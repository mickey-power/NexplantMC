/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropMshEnv.cs
--  Creator         : mjkim
--  Create Date     : 2013.04.05
--  Description     : FAMate Admin Manager Model Version Schema Environment Source Object Class 
--  History         : Created by mjkim at 2013.04.05
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
    public class FPropMshEnv : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryFormat = "[02] Format";
        private const string CategoryValue = "[03] Value";

        // --

        private bool m_disposed = false;
        // --
        private string m_type = "Environment";
        private FXmlNode m_fXmlNodeEnv = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropMshEnv(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            FXmlNode fXmlNodeEnv
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_fXmlNodeEnv = fXmlNodeEnv;
            // --
            init();
        }        

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropMshEnv(
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
                    m_fXmlNodeEnv = null;
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
                    return m_fXmlNodeEnv.get_elemVal(
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_Name,
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_Name
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
                    return m_fXmlNodeEnv.get_elemVal(
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_Description,
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_Description
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

        #region Format

        [Category(CategoryFormat)]
        public string Format
        {
            get
            {
                try
                {
                    return m_fXmlNodeEnv.get_elemVal(
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_Format,
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_Format
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

        #region Value

        [Category(CategoryValue)]
        public string Value
        {
            get
            {
                try
                {
                    return m_fXmlNodeEnv.get_elemVal(
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_Value,
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_Value
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

        [Category(CategoryValue)]
        public string Length
        {
            get
            {
                try
                {
                    return m_fXmlNodeEnv.get_elemVal(
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_Length,
                        FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_Length
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
            FFormat fFormat;
            string val = string.Empty;

            try
            {
                base.fTypeDescriptor.properties["Type"].attributes.replace(new DisplayNameAttribute("Type"));
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DisplayNameAttribute("Name"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
                // --
                base.fTypeDescriptor.properties["Format"].attributes.replace(new DisplayNameAttribute("Format"));
                // --
                base.fTypeDescriptor.properties["Value"].attributes.replace(new DisplayNameAttribute("Value"));
                base.fTypeDescriptor.properties["Length"].attributes.replace(new DisplayNameAttribute("Length"));

                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_type));
                // --
                val = m_fXmlNodeEnv.get_elemVal(
                    FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_Name,
                    FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_Name
                    ).Trim();
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(val));
                // --
                val = m_fXmlNodeEnv.get_elemVal(
                    FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_Description,
                    FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_Description
                    ).Trim();
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(val));
                // --
                val = m_fXmlNodeEnv.get_elemVal(
                    FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_Format,
                    FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_Format
                    ).Trim();
                fFormat = (FFormat)Enum.Parse(typeof(FFormat), val);
                base.fTypeDescriptor.properties["Format"].attributes.replace(new DefaultValueAttribute(val));
                // --
                val = m_fXmlNodeEnv.get_elemVal(
                    FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_Value,
                    FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_Value
                    ).Trim();
                base.fTypeDescriptor.properties["Value"].attributes.replace(new DefaultValueAttribute(val));
                // --
                val = m_fXmlNodeEnv.get_elemVal(
                    FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_Length,
                    FADMADS_InqModelVerSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_Length
                    ).Trim();
                base.fTypeDescriptor.properties["Length"].attributes.replace(new DefaultValueAttribute(val));

                // --
                
                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                {
                    base.fTypeDescriptor.properties["Value"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["Length"].attributes.replace(new BrowsableAttribute(false));
                }
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
