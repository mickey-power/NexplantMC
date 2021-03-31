/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropEshSdv.cs
--  Creator         : spike.lee
--  Create Date     : 2012.06.29
--  Description     : FAMate Admin Manager Common EAP SECS Device Schema Propertiy Source Object Class 
--  History         : Created by spike.lee at 2012.06.29
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
//using Nexplant.MC.Core.FaPlcDriver;
using Nexplant.MC.H101Interface;
using Infragistics.Win.UltraWinTree;

namespace Nexplant.MC.AdminManager
{
    public class FPropEshSdv : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";        
        private const string CategoryProtocol = "[02] Protocol";
        private const string CategoryTimeout = "[03] Timeout";

        // --

        private bool m_disposed = false;
        // --
        private FEapType m_fEapType = FEapType.SECS;
        private string m_type = string.Empty;
        private FXmlNode m_fXmlNodeSdv = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropEshSdv(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            FXmlNode fXmlNodeSdv
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_fXmlNodeSdv = fXmlNodeSdv;
            // --
            init();
        }        

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropEshSdv(
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
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Name, 
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Name
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
                    return m_fXmlNodeSdv.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Description,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Description
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
        public string Mode
        {
            get
            {
                string val = string.Empty;

                try
                {
                    return m_fXmlNodeSdv.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Mode, 
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Mode
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
        public string Protocol
        {
            get
            {
                try
                {
                    return m_fXmlNodeSdv.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Protocol, 
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Protocol
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
        public string ConnectMode
        {
            get
            {
                try
                {
                    return m_fXmlNodeSdv.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_ConnectMode,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_ConnectMode
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
        public string LocalIP
        {
            get
            {
                try
                {
                    return m_fXmlNodeSdv.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_LocalIp,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_LocalIp
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
        public string LocalPort
        {
            get
            {
                try
                {
                    return m_fXmlNodeSdv.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_LocalPort,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_LocalPort
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
        public string RemoteIP
        {
            get
            {
                try
                {
                    return m_fXmlNodeSdv.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_RemoteIp,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_RemoteIp
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
        public string RemotePort
        {
            get
            {
                try
                {
                    return m_fXmlNodeSdv.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_RemotePort,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_RemotePort
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
        public string SerialPort
        {
            get
            {
                try
                {
                    return m_fXmlNodeSdv.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_SerialPort,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_SerialPort
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
        public string Baud
        {
            get
            {
                try
                {
                    return m_fXmlNodeSdv.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Baud,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Baud
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
        public string RBit
        {
            get
            {
                try
                {
                    return m_fXmlNodeSdv.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_RBit,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_RBit
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
        public string Interleave
        {
            get
            {
                try
                {
                    return m_fXmlNodeSdv.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Interleave,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Interleave
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
        public string DuplicateError
        {
            get
            {
                try
                {
                    return m_fXmlNodeSdv.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_DuplicateError,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_DuplicateError
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
        public string IgnoreSystemBytes
        {
            get
            {
                try
                {
                    return m_fXmlNodeSdv.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_IgnoreSystemBytes,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_IgnoreSystemBytes
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
        public string LinkTestPeriod
        {
            get
            {
                try
                {
                    return m_fXmlNodeSdv.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_LinkTestTimePeriod,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_LinkTestTimePeriod
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
        public string RetryLimit
        {
            get
            {
                try
                {
                    return m_fXmlNodeSdv.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_RetryLimit,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_RetryLimit
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
        public string Url
        {
            get
            {
                try
                {
                    return m_fXmlNodeSdv.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_OpcUrl,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_OpcUrl
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
        public string HandleID
        {
            get
            {
                try
                {
                    return m_fXmlNodeSdv.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_OpcHandleId,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_OpcHandleId
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
        public string LocalID
        {
            get
            {
                try
                {
                    return m_fXmlNodeSdv.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_OpcLocalId,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_OpcLocalId
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
        public string DefaultNamespace
        {
            get
            {
                try
                {
                    return m_fXmlNodeSdv.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_OpcDefaultNamespace,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_OpcDefaultNamespace
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
        public string KeepAliveTime
        {
            get
            {
                try
                {
                    return m_fXmlNodeSdv.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_OpcKeepAliveTime,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_OpcKeepAliveTime
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
        public string EventReloadTime
        {
            get
            {
                try
                {
                    return m_fXmlNodeSdv.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_OpcEventReloadTime,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_OpcEventReloadTime
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
        public string State
        {
            get
            {
                try
                {
                    return m_fXmlNodeSdv.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_State,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_State
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

        #region Timeout

        [Category(CategoryTimeout)]
        public string T1Timeout
        {
            get
            {
                try
                {
                    return m_fXmlNodeSdv.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T1Timeout,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T1Timeout
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

        [Category(CategoryTimeout)]
        public string T2Timeout
        {
            get
            {
                try
                {
                    return m_fXmlNodeSdv.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T2Timeout,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T2Timeout
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

        [Category(CategoryTimeout)]
        public string T3Timeout
        {
            get
            {
                try
                {
                    return m_fXmlNodeSdv.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T3Timeout,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T3Timeout
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

        [Category(CategoryTimeout)]
        public string T4Timeout
        {
            get
            {
                try
                {
                    return m_fXmlNodeSdv.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T4Timeout,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T4Timeout
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

        [Category(CategoryTimeout)]
        public string T5Timeout
        {
            get
            {
                try
                {
                    return m_fXmlNodeSdv.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T5Timeout,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T5Timeout
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

        [Category(CategoryTimeout)]
        public string T6Timeout
        {
            get
            {
                try
                {
                    return m_fXmlNodeSdv.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T6Timeout,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T6Timeout
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

        [Category(CategoryTimeout)]
        public string T7Timeout
        {
            get
            {
                try
                {
                    return m_fXmlNodeSdv.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T7Timeout,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T7Timeout
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

        [Category(CategoryTimeout)]
        public string T8Timeout
        {
            get
            {
                try
                {
                    return m_fXmlNodeSdv.get_elemVal(
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T8Timeout,
                        FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T8Timeout
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
                val = m_fXmlNodeSdv.get_elemVal(
                    FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_EapType,
                    FADMADS_ComEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_EapType
                    );
                m_fEapType = (FEapType)Enum.Parse(typeof(FEapType), val);
                // --
                if (m_fEapType == FEapType.SECS)
                {
                    m_type = "SecsDevice";
                }
                //else if (m_fEapType == FEapType.PLC)
                //{
                //    m_type = "PlcDevice";
                //}
                else if (m_fEapType == FEapType.OPC || m_fEapType == FEapType.CHD)
                {
                    m_type = "OpcDevice";
                }
                else if (m_fEapType == FEapType.TCP)
                {
                    m_type = "TcpDevice";
                }

                // --

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
                base.fTypeDescriptor.properties["Url"].attributes.replace(new DisplayNameAttribute("Url"));
                base.fTypeDescriptor.properties["HandleID"].attributes.replace(new DisplayNameAttribute("Handle ID"));
                base.fTypeDescriptor.properties["LocalID"].attributes.replace(new DisplayNameAttribute("Local ID"));
                base.fTypeDescriptor.properties["DefaultNamespace"].attributes.replace(new DisplayNameAttribute("Default Namespace"));
                base.fTypeDescriptor.properties["KeepAliveTime"].attributes.replace(new DisplayNameAttribute("Keep Alive Time"));
                base.fTypeDescriptor.properties["EventReloadTime"].attributes.replace(new DisplayNameAttribute("Event Reload Time"));
                base.fTypeDescriptor.properties["State"].attributes.replace(new DisplayNameAttribute("State"));
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
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(this.Name));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(this.Description));
                base.fTypeDescriptor.properties["Mode"].attributes.replace(new DefaultValueAttribute(this.Mode));
                base.fTypeDescriptor.properties["ConnectMode"].attributes.replace(new DefaultValueAttribute(this.ConnectMode));
                base.fTypeDescriptor.properties["Protocol"].attributes.replace(new DefaultValueAttribute(this.Protocol));
                base.fTypeDescriptor.properties["LocalIP"].attributes.replace(new DefaultValueAttribute(this.LocalIP));
                base.fTypeDescriptor.properties["LocalPort"].attributes.replace(new DefaultValueAttribute(this.LocalPort));
                base.fTypeDescriptor.properties["RemoteIP"].attributes.replace(new DefaultValueAttribute(this.RemoteIP));
                base.fTypeDescriptor.properties["RemotePort"].attributes.replace(new DefaultValueAttribute(this.RemotePort));
                base.fTypeDescriptor.properties["SerialPort"].attributes.replace(new DefaultValueAttribute(this.SerialPort));
                base.fTypeDescriptor.properties["Baud"].attributes.replace(new DefaultValueAttribute(this.Baud));
                base.fTypeDescriptor.properties["RBit"].attributes.replace(new DefaultValueAttribute(this.RBit));
                base.fTypeDescriptor.properties["Interleave"].attributes.replace(new DefaultValueAttribute(this.Interleave));
                base.fTypeDescriptor.properties["DuplicateError"].attributes.replace(new DefaultValueAttribute(this.DuplicateError));
                base.fTypeDescriptor.properties["IgnoreSystemBytes"].attributes.replace(new DefaultValueAttribute(this.IgnoreSystemBytes));
                base.fTypeDescriptor.properties["LinkTestPeriod"].attributes.replace(new DefaultValueAttribute(this.LinkTestPeriod));
                base.fTypeDescriptor.properties["RetryLimit"].attributes.replace(new DefaultValueAttribute(this.RetryLimit));
                base.fTypeDescriptor.properties["Url"].attributes.replace(new DefaultValueAttribute(this.Url));
                base.fTypeDescriptor.properties["HandleID"].attributes.replace(new DefaultValueAttribute(this.HandleID));
                base.fTypeDescriptor.properties["LocalID"].attributes.replace(new DefaultValueAttribute(this.LocalID));
                base.fTypeDescriptor.properties["DefaultNamespace"].attributes.replace(new DefaultValueAttribute(this.DefaultNamespace));
                base.fTypeDescriptor.properties["KeepAliveTime"].attributes.replace(new DefaultValueAttribute(this.KeepAliveTime));
                base.fTypeDescriptor.properties["EventReloadTime"].attributes.replace(new DefaultValueAttribute(this.EventReloadTime));
                base.fTypeDescriptor.properties["State"].attributes.replace(new DefaultValueAttribute(this.State));
                // --
                base.fTypeDescriptor.properties["T1Timeout"].attributes.replace(new DefaultValueAttribute(this.T1Timeout));
                base.fTypeDescriptor.properties["T2Timeout"].attributes.replace(new DefaultValueAttribute(this.T2Timeout));
                base.fTypeDescriptor.properties["T3Timeout"].attributes.replace(new DefaultValueAttribute(this.T3Timeout));
                base.fTypeDescriptor.properties["T4Timeout"].attributes.replace(new DefaultValueAttribute(this.T4Timeout));
                base.fTypeDescriptor.properties["T5Timeout"].attributes.replace(new DefaultValueAttribute(this.T5Timeout));
                base.fTypeDescriptor.properties["T6Timeout"].attributes.replace(new DefaultValueAttribute(this.T6Timeout));
                base.fTypeDescriptor.properties["T7Timeout"].attributes.replace(new DefaultValueAttribute(this.T7Timeout));
                base.fTypeDescriptor.properties["T8Timeout"].attributes.replace(new DefaultValueAttribute(this.T8Timeout)); 

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
                base.fTypeDescriptor.properties["Mode"].attributes.replace(new BrowsableAttribute(false));
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
                base.fTypeDescriptor.properties["Url"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["HandleID"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["LocalID"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["DefaultNamespace"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["KeepAliveTime"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["EventReloadTime"].attributes.replace(new BrowsableAttribute(false));                
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

                if (m_fEapType == FEapType.SECS)
                {
                    if (this.Protocol == Nexplant.MC.Core.FaSecsDriver.FProtocol.SECS1.ToString())
                    {
                        base.fTypeDescriptor.properties["Mode"].attributes.replace(new BrowsableAttribute(true));
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
                        this.Protocol == Nexplant.MC.Core.FaSecsDriver.FProtocol.TCPIP.ToString() ||
                        this.Protocol == Nexplant.MC.Core.FaSecsDriver.FProtocol.TELNET.ToString()
                        )
                    {
                        base.fTypeDescriptor.properties["Mode"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["ConnectMode"].attributes.replace(new BrowsableAttribute(true));
                        // --
                        base.fTypeDescriptor.properties["LocalIP"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["LocalPort"].attributes.replace(new BrowsableAttribute(true));
                        // --
                        base.fTypeDescriptor.properties["RemoteIP"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["RemotePort"].attributes.replace(new BrowsableAttribute(true));
                        // --
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
                    else if (this.Protocol == Nexplant.MC.Core.FaSecsDriver.FProtocol.HSMS.ToString())
                    {
                        base.fTypeDescriptor.properties["Mode"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["ConnectMode"].attributes.replace(new BrowsableAttribute(true));
                        // --
                        base.fTypeDescriptor.properties["LocalIP"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["LocalPort"].attributes.replace(new BrowsableAttribute(true));
                        // --
                        base.fTypeDescriptor.properties["RemoteIP"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["RemotePort"].attributes.replace(new BrowsableAttribute(true));
                        // --
                        base.fTypeDescriptor.properties["LinkTestPeriod"].attributes.replace(new BrowsableAttribute(true));
                        // --
                        base.fTypeDescriptor.properties["T3Timeout"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["T5Timeout"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["T6Timeout"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["T7Timeout"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["T8Timeout"].attributes.replace(new BrowsableAttribute(true));
                    }
                }
                //else if (m_fEapType == FEapType.PLC)
                //{
                //    base.fTypeDescriptor.properties["LocalIP"].attributes.replace(new BrowsableAttribute(true));
                //    base.fTypeDescriptor.properties["LocalPort"].attributes.replace(new BrowsableAttribute(true));
                //    // --
                //    base.fTypeDescriptor.properties["RemoteIP"].attributes.replace(new BrowsableAttribute(true));
                //    base.fTypeDescriptor.properties["RemotePort"].attributes.replace(new BrowsableAttribute(true));
                //    // --
                //    base.fTypeDescriptor.properties["T2Timeout"].attributes.replace(new BrowsableAttribute(true));
                //    base.fTypeDescriptor.properties["T3Timeout"].attributes.replace(new BrowsableAttribute(true));
                //    base.fTypeDescriptor.properties["T5Timeout"].attributes.replace(new BrowsableAttribute(true));
                //}
                else if (m_fEapType == FEapType.OPC)
                {
                    base.fTypeDescriptor.properties["Url"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["HandleID"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["LocalID"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["DefaultNamespace"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["KeepAliveTime"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["EventReloadTime"].attributes.replace(new BrowsableAttribute(true));   
                }
                else if (m_fEapType == FEapType.TCP)
                {
                    base.fTypeDescriptor.properties["Mode"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["ConnectMode"].attributes.replace(new BrowsableAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["LocalIP"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["LocalPort"].attributes.replace(new BrowsableAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["RemoteIP"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["RemotePort"].attributes.replace(new BrowsableAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["T3Timeout"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["T5Timeout"].attributes.replace(new BrowsableAttribute(true));
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
