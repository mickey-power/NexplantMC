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
using Nexplant.MC.Adminmanager;
using System.CodeDom;

namespace Nexplant.MC.AdminManager
{
    public class FPropEwdFieHdv : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";        
        private const string CategoryStation = "[02] Station";
        private const string CategoryChannel = "[03] Channel";
        private const string CategoryTimeOut = "[04] TimeOut";
        private const string CategoryMessageType = "[05] Message Type";

        // --

        private bool m_disposed = false;
        // --
        private string m_type = "HostDevice";
        private FFileEapWizard m_fOwnerForm = null;
        private UltraTreeNode m_tNodeHdv = null;
        private FXmlNode m_fXmlNodeHdv = null;
        private FXmlNode m_fxmlNodeHot = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropEwdFieHdv(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            FFileEapWizard fOwnerForm,
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

        ~FPropEwdFieHdv(
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
                        FFileDriver.FHostDevice.A_Name,
                        FFileDriver.FHostDevice.D_Name
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
                        FFileDriver.FHostDevice.A_Name,
                        FFileDriver.FHostDevice.D_Name,
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
                        FFileDriver.FHostDevice.A_Description,
                        FFileDriver.FHostDevice.D_Description
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
                        FFileDriver.FHostDevice.A_Description,
                        FFileDriver.FHostDevice.D_Description,
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

        #region HostOption

        [Category(CategoryStation)]
        public string StationConnectString
        {
            get
            {
                try
                {
                    return m_fxmlNodeHot.get_elemVal(
                         FFileDriver.FHostDevice.FHostOption.A_StationConnectString,
                         FFileDriver.FHostDevice.FHostOption.D_StationConnectString
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
                    m_fxmlNodeHot.set_elemVal(
                        FFileDriver.FHostDevice.FHostOption.A_StationConnectString,
                        FFileDriver.FHostDevice.FHostOption.D_StationConnectString,
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

        [Category(CategoryStation)]
        public string StationVersion
        {
            get
            {
                try
                {
                    return m_fxmlNodeHot.get_elemVal(
                         FFileDriver.FHostDevice.FHostOption.A_StationVersion,
                         FFileDriver.FHostDevice.FHostOption.D_StationVersion
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
                    m_fxmlNodeHot.set_elemVal(
                        FFileDriver.FHostDevice.FHostOption.A_StationVersion,
                        FFileDriver.FHostDevice.FHostOption.D_StationVersion,
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

        [Category(CategoryStation)]
        public string StationTimeOut
        {
            get
            {
                try
                {
                    return m_fxmlNodeHot.get_elemVal(
                         FFileDriver.FHostDevice.FHostOption.A_StationTimeOut,
                         FFileDriver.FHostDevice.FHostOption.D_StationTimeOut
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
                    m_fxmlNodeHot.set_elemVal(
                        FFileDriver.FHostDevice.FHostOption.A_StationTimeOut,
                        FFileDriver.FHostDevice.FHostOption.D_StationTimeOut,
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

        [Category(CategoryStation)]
        public string GuarantedtimeOut
        {
            get
            {
                try
                {
                    return m_fxmlNodeHot.get_elemVal(
                         FFileDriver.FHostDevice.FHostOption.A_GuaranteedtimeOut,
                         FFileDriver.FHostDevice.FHostOption.D_GuaranteedtimeOut
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
                    m_fxmlNodeHot.set_elemVal(
                        FFileDriver.FHostDevice.FHostOption.A_GuaranteedtimeOut,
                        FFileDriver.FHostDevice.FHostOption.D_GuaranteedtimeOut,
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

        [Category(CategoryStation)]
        public string MaxSpoling
        {
            get
            {
                try
                {
                    return m_fxmlNodeHot.get_elemVal(
                         FFileDriver.FHostDevice.FHostOption.A_MaxSpoling,
                         FFileDriver.FHostDevice.FHostOption.D_MaxSpoling
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
                    m_fxmlNodeHot.set_elemVal(
                        FFileDriver.FHostDevice.FHostOption.A_MaxSpoling,
                        FFileDriver.FHostDevice.FHostOption.D_MaxSpoling,
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

        [Category(CategoryChannel)]
        public string SessionId
        {
            get
            {
                try
                {
                    return m_fxmlNodeHot.get_elemVal(
                         FFileDriver.FHostDevice.FHostOption.A_SessionId,
                         FFileDriver.FHostDevice.FHostOption.D_SessionId
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
                    m_fxmlNodeHot.set_elemVal(
                        FFileDriver.FHostDevice.FHostOption.A_SessionId,
                        FFileDriver.FHostDevice.FHostOption.D_SessionId,
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

        [Category(CategoryChannel)]
        public string ModuleName
        {
            get
            {
                try
                {
                    return m_fxmlNodeHot.get_elemVal(
                         FFileDriver.FHostDevice.FHostOption.A_ModuleName,
                         FFileDriver.FHostDevice.FHostOption.D_ModuleName
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
                    m_fxmlNodeHot.set_elemVal(
                        FFileDriver.FHostDevice.FHostOption.A_ModuleName,
                        FFileDriver.FHostDevice.FHostOption.D_ModuleName,
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

        [Category(CategoryChannel)]
        public string TuneChannel
        {
            get
            {
                try
                {
                    return m_fxmlNodeHot.get_elemVal(
                         FFileDriver.FHostDevice.FHostOption.A_TuneChannel,
                         FFileDriver.FHostDevice.FHostOption.D_TuneChannel
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
                    m_fxmlNodeHot.set_elemVal(
                        FFileDriver.FHostDevice.FHostOption.A_TuneChannel,
                        FFileDriver.FHostDevice.FHostOption.D_TuneChannel,
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

        [Category(CategoryChannel)]
        public string CastChannel
        {
            get
            {
                try
                {
                    return m_fxmlNodeHot.get_elemVal(
                         FFileDriver.FHostDevice.FHostOption.A_CastChannel,
                         FFileDriver.FHostDevice.FHostOption.D_CastChannel
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
                    m_fxmlNodeHot.set_elemVal(
                        FFileDriver.FHostDevice.FHostOption.A_CastChannel,
                        FFileDriver.FHostDevice.FHostOption.D_CastChannel,
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

        [Category(CategoryTimeOut)]
        public int TransactionTimeout
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = m_fXmlNodeHdv.get_elemVal(
                        FFileDriver.FHostDevice.A_TransactionTimeout,
                        FFileDriver.FHostDevice.D_TransactionTimeout
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
                        FFileDriver.FHostDevice.A_TransactionTimeout,
                        FFileDriver.FHostDevice.D_TransactionTimeout,
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

        [Category(CategoryMessageType)]
        public FParsingType MessageType
        {
            get
            {
                try
                {
                    return (FParsingType)Enum.Parse(typeof(FParsingType),
                        m_fxmlNodeHot.get_elemVal(
                            FFileDriver.FHostDevice.FHostOption.A_ParsingType,
                            FFileDriver.FHostDevice.FHostOption.D_ParsingType)
                        );
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FParsingType.Xml;
            }

            set
            {
                try
                {
                    m_fxmlNodeHot.set_elemVal(
                        FFileDriver.FHostDevice.FHostOption.A_ParsingType,
                        FFileDriver.FHostDevice.FHostOption.D_ParsingType,
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

        #region Properties

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
                m_fxmlNodeHot = m_fXmlNodeHdv.get_elem(FFileDriver.FHostDevice.FHostOption.E_HostOption);

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DisplayNameAttribute("Type"));                
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DisplayNameAttribute("Name"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
                // --
                base.fTypeDescriptor.properties["StationConnectString"].attributes.replace(new DisplayNameAttribute("Station Connect String"));
                base.fTypeDescriptor.properties["StationTimeOut"].attributes.replace(new DisplayNameAttribute("Station Time Out"));
                base.fTypeDescriptor.properties["StationVersion"].attributes.replace(new DisplayNameAttribute("Station Version"));
                base.fTypeDescriptor.properties["GuarantedtimeOut"].attributes.replace(new DisplayNameAttribute("Guaranted Time Out"));
                base.fTypeDescriptor.properties["MaxSpoling"].attributes.replace(new DisplayNameAttribute("Max Spoling"));
                base.fTypeDescriptor.properties["SessionId"].attributes.replace(new DisplayNameAttribute("Session Id"));
                base.fTypeDescriptor.properties["ModuleName"].attributes.replace(new DisplayNameAttribute("Module Name"));
                base.fTypeDescriptor.properties["TuneChannel"].attributes.replace(new DisplayNameAttribute("Tune Channel"));
                base.fTypeDescriptor.properties["CastChannel"].attributes.replace(new DisplayNameAttribute("Cast Channel"));                
                // --
                base.fTypeDescriptor.properties["TransactionTimeout"].attributes.replace(new DisplayNameAttribute("Transaction Timeout"));
                // --
                base.fTypeDescriptor.properties["MessageType"].attributes.replace(new DisplayNameAttribute("Message Type"));                
                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_type));                
                // --                
                val = m_fXmlNodeHdv.get_elemVal(
                    FFileDriver.FHostDevice.A_Name,
                    FFileDriver.FHostDevice.D_Name
                    ).Trim();
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(val));                
                // --                
                val = m_fXmlNodeHdv.get_elemVal(
                    FFileDriver.FHostDevice.A_Description,
                    FFileDriver.FHostDevice.D_Description
                    ).Trim();
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(val));                                              
                // --
                val = m_fxmlNodeHot.get_elemVal(
                    FFileDriver.FHostDevice.FHostOption.A_StationConnectString,
                    FFileDriver.FHostDevice.FHostOption.D_StationConnectString
                    ).Trim();
                base.fTypeDescriptor.properties["StationConnectString"].attributes.replace(new DefaultValueAttribute(val));
                // --
                val = m_fxmlNodeHot.get_elemVal(
                    FFileDriver.FHostDevice.FHostOption.A_StationTimeOut,
                    FFileDriver.FHostDevice.FHostOption.D_StationTimeOut
                    ).Trim();
                base.fTypeDescriptor.properties["StationTimeOut"].attributes.replace(new DefaultValueAttribute(val));
                // --
                val = m_fxmlNodeHot.get_elemVal(
                    FFileDriver.FHostDevice.FHostOption.A_StationVersion,
                    FFileDriver.FHostDevice.FHostOption.D_StationVersion
                    ).Trim();
                base.fTypeDescriptor.properties["StationVersion"].attributes.replace(new DefaultValueAttribute(val));
                // --
                val = m_fxmlNodeHot.get_elemVal(
                    FFileDriver.FHostDevice.FHostOption.A_GuaranteedtimeOut,
                    FFileDriver.FHostDevice.FHostOption.D_GuaranteedtimeOut
                    ).Trim();
                base.fTypeDescriptor.properties["GuarantedtimeOut"].attributes.replace(new DefaultValueAttribute(val));
                // --
                val = m_fxmlNodeHot.get_elemVal(
                    FFileDriver.FHostDevice.FHostOption.A_MaxSpoling,
                    FFileDriver.FHostDevice.FHostOption.D_MaxSpoling
                    ).Trim();
                base.fTypeDescriptor.properties["MaxSpoling"].attributes.replace(new DefaultValueAttribute(val));
                // --
                val = m_fxmlNodeHot.get_elemVal(
                    FFileDriver.FHostDevice.FHostOption.A_SessionId,
                    FFileDriver.FHostDevice.FHostOption.D_SessionId
                    ).Trim();
                base.fTypeDescriptor.properties["SessionId"].attributes.replace(new DefaultValueAttribute(val));
                // --
                val = m_fxmlNodeHot.get_elemVal(
                    FFileDriver.FHostDevice.FHostOption.A_ModuleName,
                    FFileDriver.FHostDevice.FHostOption.D_ModuleName
                    ).Trim();
                base.fTypeDescriptor.properties["ModuleName"].attributes.replace(new DefaultValueAttribute(val));
                // --
                val = m_fxmlNodeHot.get_elemVal(
                    FFileDriver.FHostDevice.FHostOption.A_TuneChannel,
                    FFileDriver.FHostDevice.FHostOption.D_TuneChannel
                    ).Trim();
                base.fTypeDescriptor.properties["TuneChannel"].attributes.replace(new DefaultValueAttribute(val));
                // --
                val = m_fxmlNodeHot.get_elemVal(
                    FFileDriver.FHostDevice.FHostOption.A_CastChannel,
                    FFileDriver.FHostDevice.FHostOption.D_CastChannel
                    ).Trim();
                base.fTypeDescriptor.properties["CastChannel"].attributes.replace(new DefaultValueAttribute(val));                
                // --
                val = m_fXmlNodeHdv.get_elemVal(
                    FFileDriver.FHostDevice.A_TransactionTimeout,
                    FFileDriver.FHostDevice.D_TransactionTimeout
                    ).Trim();
                base.fTypeDescriptor.properties["TransactionTimeout"].attributes.replace(new DefaultValueAttribute(int.Parse(val)));
                // --
                val = m_fxmlNodeHot.get_elemVal(
                    FFileDriver.FHostDevice.FHostOption.A_ParsingType,
                    FFileDriver.FHostDevice.FHostOption.D_ParsingType
                    ).Trim();
                base.fTypeDescriptor.properties["MessageType"].attributes.replace(new DefaultValueAttribute(val));
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
