/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropEwOpcOcd.cs
--  Creator         : spike.lee
--  Create Date     : 2015.07.24
--  Description     : FAMate Admin Manager EAP Wizard OPC Driver Source Object for PLC Class 
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
    public class FPropEwdOpcOcd : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";        

        // --

        private bool m_disposed = false;
        // --
        private string m_type = "OpcDriver";
        private FOpcEapWizard m_fOwnerForm = null;
        private UltraTreeNode m_tNodeOcd = null;
        private FXmlNode m_fXmlNodeOcd = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropEwdOpcOcd(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            FOpcEapWizard fOwnerForm,
            UltraTreeNode tNodeOcd,
            FXmlNode fXmlNodeOcd
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_fOwnerForm = fOwnerForm;
            m_tNodeOcd = tNodeOcd;
            m_fXmlNodeOcd = fXmlNodeOcd;
            // --
            init();
        }        

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropEwdOpcOcd(
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
                    m_tNodeOcd = null;
                    m_fXmlNodeOcd = null;
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
                    return m_fXmlNodeOcd.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.A_Name, 
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.D_Name
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

                    m_fXmlNodeOcd.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.A_Name,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.D_Name,
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
                    return m_fXmlNodeOcd.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.A_Description,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.D_Description
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

                    m_fXmlNodeOcd.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.A_Description,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.D_Description,
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

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_type));
                // --
                val = m_fXmlNodeOcd.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.A_Name,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.D_Name
                    ).Trim();
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(val));
                // --
                val = m_fXmlNodeOcd.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.A_Description,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.D_Description
                    ).Trim();
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(val));               
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
                m_fOwnerForm.refreshSchemaObject(m_fXmlNodeOcd, m_tNodeOcd);
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
