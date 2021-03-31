/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropEshSsn.cs
--  Creator         : spike.lee
--  Create Date     : 2012.06.29
--  Description     : FAMate Admin Manager Common EAP SECS Session Schema Propertiy Source Object Class 
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
    public class FPropEshSsn : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategorySession = "[02] Session";
        private const string CategoryLinkMapExpression = "[03] Link Map Expression";
        private const string CategoryReadLinkMap = "[04] Read Link Map";
        private const string CategoryWriteLinkMap = "[05] Write Link Map";

        // --

        private bool m_disposed = false;
        // --
        private FEapType m_fEapType = FEapType.SECS;
        private string m_type = string.Empty;
        private FXmlNode m_fXmlNodeSsn = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropEshSsn(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            FXmlNode fXmlNodeSsn
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_fXmlNodeSsn = fXmlNodeSsn;
            // --
            init();
        }        

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropEshSsn(
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
                    m_fXmlNodeSsn = null;
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
                    return m_fXmlNodeSsn.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_Name, 
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_Name
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
                    return m_fXmlNodeSsn.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_Description,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_Description
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

        #region Session

        [Category(CategorySession)]
        public string SessionID
        {
            get
            {
                try
                {
                    return m_fXmlNodeSsn.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_SessionId,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_SessionId
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

        [Category(CategorySession)]
        public string ScanEnabled
        {
            get
            {
                try
                {
                    return m_fXmlNodeSsn.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_ScanEnabled,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_ScanEnabled
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

        [Category(CategorySession)]
        public string ScanTime
        {
            get
            {
                try
                {
                    return m_fXmlNodeSsn.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_ScanTime,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_ScanTime
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

        [Category(CategorySession)]
        public string Channel
        {
            get
            {
                try
                {
                    return m_fXmlNodeSsn.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_OpcChannel,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_OpcChannel
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

        [Category(CategorySession)]
        public string UpdateRate
        {
            get
            {
                try
                {
                    return m_fXmlNodeSsn.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_OpcUpdateRate,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_OpcUpdateRate
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

        [Category(CategorySession)]
        public string DeadBand
        {
            get
            {
                try
                {
                    return m_fXmlNodeSsn.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_OpcDeadBand,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_OpcDeadBand
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

        [Category(CategorySession)]
        public string AutoClear
        {
            get
            {
                try
                {
                    return m_fXmlNodeSsn.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_AutoClear,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_AutoClear
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

        #region Link Map Expression

        [Category(CategoryLinkMapExpression)]
        public string LinkMapExpression
        {
            get
            {
                try
                {
                    return m_fXmlNodeSsn.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_LinkMapExpression,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_LinkMapExpression
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

        #region Read Link Map

        [Category(CategoryReadLinkMap)]
        public string ReadBitDeviceCode
        {
            get
            {
                try
                {
                    return m_fXmlNodeSsn.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_ReadBitDeviceCode,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_ReadBitDeviceCode
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

        [Category(CategoryReadLinkMap)]
        public string ReadBitStartAddress
        {
            get
            {
                try
                {
                    return m_fXmlNodeSsn.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_ReadBitStartAddress,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_ReadBitStartAddress
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

        [Category(CategoryReadLinkMap)]
        public string ReadBitLength
        {
            get
            {
                try
                {
                    return m_fXmlNodeSsn.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_ReadBitLength,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_ReadBitLength
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

        [Category(CategoryReadLinkMap)]
        public string ReadWordDeviceCode
        {
            get
            {
                try
                {
                    return m_fXmlNodeSsn.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_ReadWordDeviceCode,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_ReadWordDeviceCode
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

        [Category(CategoryReadLinkMap)]
        public string ReadWordStartAddress
        {
            get
            {
                try
                {
                    return m_fXmlNodeSsn.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_ReadWordStartAddress,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_ReadWordStartAddress
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

        [Category(CategoryReadLinkMap)]
        public string ReadWordLength
        {
            get
            {
                try
                {
                    return m_fXmlNodeSsn.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_ReadWordLength,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_ReadWordLength
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

        #region Write Link Map

        [Category(CategoryWriteLinkMap)]
        public string WriteBitDeviceCode
        {
            get
            {
                try
                {
                    return m_fXmlNodeSsn.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_WriteBitDeviceCode,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_WriteBitDeviceCode
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

        [Category(CategoryWriteLinkMap)]
        public string WriteBitStartAddress
        {
            get
            {
                try
                {
                    return m_fXmlNodeSsn.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_WriteBitStartAddress,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_WriteBitStartAddress
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

        [Category(CategoryWriteLinkMap)]
        public string WriteBitLength
        {
            get
            {
                try
                {
                    return m_fXmlNodeSsn.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_WriteBitLength,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_WriteBitLength
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

        [Category(CategoryWriteLinkMap)]
        public string WriteWordDeviceCode
        {
            get
            {
                try
                {
                    return m_fXmlNodeSsn.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_WriteWordDeviceCode,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_WriteWordDeviceCode
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

        [Category(CategoryWriteLinkMap)]
        public string WriteWordStartAddress
        {
            get
            {
                try
                {
                    return m_fXmlNodeSsn.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_WriteWordStartAddress,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_WriteWordStartAddress
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

        [Category(CategoryWriteLinkMap)]
        public string WriteWordLength
        {
            get
            {
                try
                {
                    return m_fXmlNodeSsn.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_WriteWordLength,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_WriteWordLength
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
                val = m_fXmlNodeSsn.get_elemVal(
                    FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_EapType,
                    FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_EapType
                    );
                m_fEapType = (FEapType)Enum.Parse(typeof(FEapType), val);
                // --
                if (m_fEapType == FEapType.SECS)
                {
                    m_type = "SecsSession";
                }
                //else if (m_fEapType == FEapType.PLC)
                //{
                //    m_type = "PlcSession";
                //}
                else if (m_fEapType == FEapType.OPC)
                {
                    m_type = "OpcSession";
                }
                else if (m_fEapType == FEapType.TCP)
                {
                    m_type = "TcpSession";
                }

                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DisplayNameAttribute("Type"));                
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DisplayNameAttribute("Name"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
                // --
                base.fTypeDescriptor.properties["SessionID"].attributes.replace(new DisplayNameAttribute("Session ID"));
                base.fTypeDescriptor.properties["ScanEnabled"].attributes.replace(new DisplayNameAttribute("Scan Enabled"));
                base.fTypeDescriptor.properties["Channel"].attributes.replace(new DisplayNameAttribute("Channel"));
                base.fTypeDescriptor.properties["UpdateRate"].attributes.replace(new DisplayNameAttribute("Update Rate"));
                base.fTypeDescriptor.properties["DeadBand"].attributes.replace(new DisplayNameAttribute("Dead Band"));
                base.fTypeDescriptor.properties["AutoClear"].attributes.replace(new DisplayNameAttribute("Auto Clear"));
                // --
                base.fTypeDescriptor.properties["LinkMapExpression"].attributes.replace(new DisplayNameAttribute("Link Map Expression"));
                // --
                base.fTypeDescriptor.properties["ReadBitDeviceCode"].attributes.replace(new DisplayNameAttribute("Bit Device Code"));
                base.fTypeDescriptor.properties["ReadBitStartAddress"].attributes.replace(new DisplayNameAttribute("Bit Start Address"));
                base.fTypeDescriptor.properties["ReadBitLength"].attributes.replace(new DisplayNameAttribute("Bit Length"));
                base.fTypeDescriptor.properties["ReadWordDeviceCode"].attributes.replace(new DisplayNameAttribute("Word Device Code"));
                base.fTypeDescriptor.properties["ReadWordStartAddress"].attributes.replace(new DisplayNameAttribute("Word Start Address"));
                base.fTypeDescriptor.properties["ReadWordLength"].attributes.replace(new DisplayNameAttribute("Word Length"));
                // --
                base.fTypeDescriptor.properties["WriteBitDeviceCode"].attributes.replace(new DisplayNameAttribute("Bit Device Code"));
                base.fTypeDescriptor.properties["WriteBitStartAddress"].attributes.replace(new DisplayNameAttribute("Bit Start Address"));
                base.fTypeDescriptor.properties["WriteBitLength"].attributes.replace(new DisplayNameAttribute("Bit Length"));
                base.fTypeDescriptor.properties["WriteWordDeviceCode"].attributes.replace(new DisplayNameAttribute("Word Device Code"));
                base.fTypeDescriptor.properties["WriteWordStartAddress"].attributes.replace(new DisplayNameAttribute("Word Start Address"));
                base.fTypeDescriptor.properties["WriteWordLength"].attributes.replace(new DisplayNameAttribute("Word Length"));

                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_type));
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(this.Name));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(this.Description));
                // --
                base.fTypeDescriptor.properties["SessionID"].attributes.replace(new DefaultValueAttribute(this.SessionID));
                base.fTypeDescriptor.properties["ScanEnabled"].attributes.replace(new DefaultValueAttribute(this.ScanEnabled));
                base.fTypeDescriptor.properties["ScanTime"].attributes.replace(new DefaultValueAttribute(this.ScanTime));
                base.fTypeDescriptor.properties["Channel"].attributes.replace(new DefaultValueAttribute(this.Channel));
                base.fTypeDescriptor.properties["UpdateRate"].attributes.replace(new DefaultValueAttribute(this.UpdateRate));
                base.fTypeDescriptor.properties["DeadBand"].attributes.replace(new DefaultValueAttribute(this.DeadBand));
                base.fTypeDescriptor.properties["AutoClear"].attributes.replace(new DefaultValueAttribute(this.AutoClear));
                // --
                base.fTypeDescriptor.properties["LinkMapExpression"].attributes.replace(new DefaultValueAttribute(this.LinkMapExpression));
                // --
                base.fTypeDescriptor.properties["ReadBitDeviceCode"].attributes.replace(new DefaultValueAttribute(this.ReadBitDeviceCode));
                base.fTypeDescriptor.properties["ReadBitStartAddress"].attributes.replace(new DefaultValueAttribute(this.ReadBitStartAddress));
                base.fTypeDescriptor.properties["ReadBitLength"].attributes.replace(new DefaultValueAttribute(this.ReadBitLength));
                base.fTypeDescriptor.properties["ReadWordDeviceCode"].attributes.replace(new DefaultValueAttribute(this.ReadWordDeviceCode));
                base.fTypeDescriptor.properties["ReadWordStartAddress"].attributes.replace(new DefaultValueAttribute(this.ReadWordStartAddress));
                base.fTypeDescriptor.properties["ReadWordLength"].attributes.replace(new DefaultValueAttribute(this.ReadWordLength));
                // --
                base.fTypeDescriptor.properties["WriteBitDeviceCode"].attributes.replace(new DefaultValueAttribute(this.WriteBitDeviceCode));
                base.fTypeDescriptor.properties["WriteBitStartAddress"].attributes.replace(new DefaultValueAttribute(this.WriteBitStartAddress));
                base.fTypeDescriptor.properties["WriteBitLength"].attributes.replace(new DefaultValueAttribute(this.WriteBitLength));
                base.fTypeDescriptor.properties["WriteWordDeviceCode"].attributes.replace(new DefaultValueAttribute(this.WriteWordDeviceCode));
                base.fTypeDescriptor.properties["WriteWordStartAddress"].attributes.replace(new DefaultValueAttribute(this.WriteWordStartAddress));
                base.fTypeDescriptor.properties["WriteWordLength"].attributes.replace(new DefaultValueAttribute(this.WriteWordLength));

                // --

                setChangeEapType();
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

        private void setChangeEapType(
            )
        {
            try
            {
                base.fTypeDescriptor.properties["ScanEnabled"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["ScanTime"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["Channel"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["UpdateRate"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["DeadBand"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["AutoClear"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["LinkMapExpression"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["ReadBitDeviceCode"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["ReadBitStartAddress"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["ReadBitLength"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["ReadWordDeviceCode"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["ReadWordStartAddress"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["ReadWordLength"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["WriteBitDeviceCode"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["WriteBitStartAddress"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["WriteBitLength"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["WriteWordDeviceCode"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["WriteWordStartAddress"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["WriteWordLength"].attributes.replace(new BrowsableAttribute(false));

                // --

                if (m_fEapType == FEapType.OPC)
                {
                    base.fTypeDescriptor.properties["Channel"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["UpdateRate"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["DeadBand"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["AutoClear"].attributes.replace(new BrowsableAttribute(true));
                }
                //else if (m_fEapType == FEapType.PLC)
                //{
                //    base.fTypeDescriptor.properties["ScanEnabled"].attributes.replace(new BrowsableAttribute(true));
                //    base.fTypeDescriptor.properties["ScanTime"].attributes.replace(new BrowsableAttribute(true));
                //    base.fTypeDescriptor.properties["AutoClear"].attributes.replace(new BrowsableAttribute(true));
                //    // --
                //    base.fTypeDescriptor.properties["LinkMapExpression"].attributes.replace(new BrowsableAttribute(true));
                //    // --
                //    base.fTypeDescriptor.properties["ReadBitDeviceCode"].attributes.replace(new BrowsableAttribute(true));
                //    base.fTypeDescriptor.properties["ReadBitStartAddress"].attributes.replace(new BrowsableAttribute(true));
                //    base.fTypeDescriptor.properties["ReadBitLength"].attributes.replace(new BrowsableAttribute(true));
                //    base.fTypeDescriptor.properties["ReadWordDeviceCode"].attributes.replace(new BrowsableAttribute(true));
                //    base.fTypeDescriptor.properties["ReadWordStartAddress"].attributes.replace(new BrowsableAttribute(true));
                //    base.fTypeDescriptor.properties["ReadWordLength"].attributes.replace(new BrowsableAttribute(true));
                //    // --
                //    base.fTypeDescriptor.properties["WriteBitDeviceCode"].attributes.replace(new BrowsableAttribute(true));
                //    base.fTypeDescriptor.properties["WriteBitStartAddress"].attributes.replace(new BrowsableAttribute(true));
                //    base.fTypeDescriptor.properties["WriteBitLength"].attributes.replace(new BrowsableAttribute(true));
                //    base.fTypeDescriptor.properties["WriteWordDeviceCode"].attributes.replace(new BrowsableAttribute(true));
                //    base.fTypeDescriptor.properties["WriteWordStartAddress"].attributes.replace(new BrowsableAttribute(true));
                //    base.fTypeDescriptor.properties["WriteWordLength"].attributes.replace(new BrowsableAttribute(true));
                //}
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
