/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropEshHsn.cs
--  Creator         : spike.lee
--  Create Date     : 2012.06.29
--  Description     : FAMate Admin Manager Common EAP Host Session Schema Propertiy Source Object Class 
--  History         : Created by spike.lee at 2015.06.29
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
    public class FPropEshHsn : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryMachine = "[02] Machine";

        // --

        private bool m_disposed = false;
        // --
        private FEapType m_fEapType = FEapType.SECS;
        private string m_type = "HostSession";
        private FXmlNode m_fXmlNodeHsn = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropEshHsn(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            FXmlNode fXmlNodeHsn
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_fXmlNodeHsn = fXmlNodeHsn;
            // --
            init();
        }        

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropEshHsn(
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
                    m_fXmlNodeHsn = null;
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
                    return m_fXmlNodeHsn.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.A_Name, 
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.D_Name
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
                    return m_fXmlNodeHsn.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.A_Description,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.D_Description
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

        #region Machine

        [Category(CategoryMachine)]
        public string MachineID
        {
            get
            {
                string val = string.Empty;

                try
                {
                    return m_fXmlNodeHsn.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.A_MachineId,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.D_MachineId
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

        [Category(CategoryMachine)]
        public string SessionID
        {
            get
            {
                try
                {
                    return m_fXmlNodeHsn.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.A_SessionId,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.D_SessionId
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

        [Browsable(false)]
        public FEapType fEapType
        {
            get
            {
                try
                {
                    return m_fEapType;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FEapType.SECS;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            string val = string.Empty;

            try
            {
                val = m_fXmlNodeHsn.get_elemVal(
                    FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.A_EapType,
                    FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.D_EapType
                    );
                m_fEapType = (FEapType)Enum.Parse(typeof(FEapType), val);

                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DisplayNameAttribute("Type"));                
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DisplayNameAttribute("Name"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
                // --
                base.fTypeDescriptor.properties["MachineID"].attributes.replace(new DisplayNameAttribute("Machine ID"));
                base.fTypeDescriptor.properties["SessionID"].attributes.replace(new DisplayNameAttribute("Session ID"));

                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_type));
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(this.Name));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(this.Description));
                // --
                base.fTypeDescriptor.properties["MachineID"].attributes.replace(new DefaultValueAttribute(this.MachineID));
                base.fTypeDescriptor.properties["SessionID"].attributes.replace(new DefaultValueAttribute(this.SessionID));       
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
