/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTcpDevice.cs
--  Creator         : heonsik
--  Create Date     : 2013.07.12
--  Description     : FAMate Core FaTcpDriver TCP Device Class 
--  History         : Created by heonsik at 2013.07.12
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    public class FTcpDevice : FBaseObject<FTcpDevice>, FIObject, FIDevice
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTcpDevice(
            FTcpDriver fTcpDriver
            )
            : base(fTcpDriver.fTcdCore, FTcpDriverCommon.createXmlNodeTDV(fTcpDriver.fTcdCore.fXmlDoc))
        {
            // init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FTcpDevice(
            FTcdCore fTcdCore,
            FXmlNode fXmlNode
            )
            : base(fTcdCore, fXmlNode)
        {
            // init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FTcpDevice(
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
                    // term();
                }

                term();
                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FObjectType fObjectType
        {
            get
            {
                try
                {
                    return FObjectType.TcpDevice;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.TcpDriver;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDeviceType fDeviceType
        {
            get
            {
                try
                {
                    return FDeviceType.TcpDevice;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FDeviceType.TcpDevice;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTDV.A_UniqueId, FXmlTagTDV.D_UniqueId);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public UInt64 uniqueId
        {
            get
            {
                try
                {
                    return UInt64.Parse(this.uniqueIdToString);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool locked
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagTDV.A_Locked, FXmlTagTDV.D_Locked));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int index
        {
            get
            {
                try
                {
                    return this.fXmlNode.getIndex(false);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string name
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTDV.A_Name, FXmlTagTDV.D_Name);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
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
                    FTcpDriverCommon.validateName(value, true);

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagTDV.A_Name, FXmlTagTDV.D_Name, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string description
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTDV.A_Description, FXmlTagTDV.D_Description);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
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
                    this.fXmlNode.set_attrVal(FXmlTagTDV.A_Description, FXmlTagTDV.D_Description, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public Color fontColor
        {
            get
            {
                try
                {
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagTDV.A_FontColor, FXmlTagTDV.D_FontColor));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return Color.Black;
            }

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagTDV.A_FontColor, FXmlTagTDV.D_FontColor, value.Name, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool fontBold
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagTDV.A_FontBold, FXmlTagTDV.D_FontBold));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
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
                    this.fXmlNode.set_attrVal(FXmlTagTDV.A_FontBold, FXmlTagTDV.D_FontBold, FBoolean.fromBool(value), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDeviceMode fDeviceMode
        {
            get
            {
                try
                {
                    return (FDeviceMode)Enum.Parse(typeof(FDeviceMode), this.fXmlNode.get_attrVal(FXmlTagTDV.A_Mode, FXmlTagTDV.D_Mode));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
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
                    this.fXmlNode.set_attrVal(FXmlTagTDV.A_Mode, FXmlTagTDV.D_Mode, value.ToString(), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FProtocol fProtocol
        {
            get
            {
                try
                {
                    return (FProtocol)Enum.Parse(typeof(FProtocol), this.fXmlNode.get_attrVal(FXmlTagTDV.A_Protocol, FXmlTagTDV.D_Protocol));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
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
                    validateStateCheck();

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagTDV.A_Protocol, FXmlTagTDV.D_Protocol, value.ToString(), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        // ***
        // 2021.03.24 add by Sunghoon.Park
        // Tcp Device Driver
        // ***

        public string driver
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTDV.A_Driver, FXmlTagTDV.D_Driver);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FConnectMode fConnectMode
        {
            get
            {
                try
                {
                    return (FConnectMode)Enum.Parse(typeof(FConnectMode), this.fXmlNode.get_attrVal(FXmlTagTDV.A_ConnectMode, FXmlTagTDV.D_ConnectMode));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FConnectMode.Active;
            }

            set
            {
                try
                {
                    validateStateCheck();

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagTDV.A_ConnectMode, FXmlTagTDV.D_ConnectMode, value.ToString(), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string localIp
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTDV.A_LocalIp, FXmlTagTDV.D_LocalIp);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
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
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Local IP"));
                    }

                    // --

                    validateStateCheck();

                    // --
                    this.fXmlNode.set_attrVal(FXmlTagTDV.A_LocalIp, FXmlTagTDV.D_LocalIp, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int localPort
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagTDV.A_LocalPort, FXmlTagTDV.D_LocalPort));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
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
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Local Port"));
                    }

                    // --

                    validateStateCheck();

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagTDV.A_LocalPort, FXmlTagTDV.D_LocalPort, value.ToString(), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string remoteIp
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTDV.A_RemoteIp, FXmlTagTDV.D_RemoteIp);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
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
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Remote IP"));
                    }

                    // --

                    validateStateCheck();

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagTDV.A_RemoteIp, FXmlTagTDV.D_RemoteIp, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int remotePort
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagTDV.A_RemotePort, FXmlTagTDV.D_RemotePort));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
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
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Remote Port"));
                    }

                    // --

                    validateStateCheck();

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagTDV.A_RemotePort, FXmlTagTDV.D_RemotePort, value.ToString(), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }        

        //------------------------------------------------------------------------------------------------------------------------

        public int t3Timeout
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagTDV.A_T3Timeout, FXmlTagTDV.D_T3Timeout));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
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
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "T3 Timeout"));
                    }

                    // --

                    validateStateCheck();

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagTDV.A_T3Timeout, FXmlTagTDV.D_T3Timeout, value.ToString(), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int t5Timeout
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagTDV.A_T5Timeout, FXmlTagTDV.D_T5Timeout));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
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
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "T5 Timeout"));
                    }

                    // --

                    validateStateCheck();

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagTDV.A_T5Timeout, FXmlTagTDV.D_T5Timeout, value.ToString(), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int t8Timeout
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagTDV.A_T8Timeout, FXmlTagTDV.D_T8Timeout));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
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
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "T8 Timeout"));
                    }

                    // --

                    validateStateCheck();

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagTDV.A_T8Timeout, FXmlTagTDV.D_T8Timeout, value.ToString(), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag1
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTDV.A_UserTag1, FXmlTagTDV.D_UserTag1);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
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
                    this.fXmlNode.set_attrVal(FXmlTagTDV.A_UserTag1, FXmlTagTDV.D_UserTag1, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag2
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTDV.A_UserTag2, FXmlTagTDV.D_UserTag2);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
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
                    this.fXmlNode.set_attrVal(FXmlTagTDV.A_UserTag2, FXmlTagTDV.D_UserTag2, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag3
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTDV.A_UserTag3, FXmlTagTDV.D_UserTag3);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
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
                    this.fXmlNode.set_attrVal(FXmlTagTDV.A_UserTag3, FXmlTagTDV.D_UserTag3, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag4
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTDV.A_UserTag4, FXmlTagTDV.D_UserTag4);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
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
                    this.fXmlNode.set_attrVal(FXmlTagTDV.A_UserTag4, FXmlTagTDV.D_UserTag4, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag5
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTDV.A_UserTag5, FXmlTagTDV.D_UserTag5);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
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
                    this.fXmlNode.set_attrVal(FXmlTagTDV.A_UserTag5, FXmlTagTDV.D_UserTag5, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string defUserTagName1
        {
            get
            {
                try
                {
                    return this.getDefUserTagName(1);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string defUserTagName2
        {
            get
            {
                try
                {
                    return this.getDefUserTagName(2);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string defUserTagName3
        {
            get
            {
                try
                {
                    return this.getDefUserTagName(3);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string defUserTagName4
        {
            get
            {
                try
                {
                    return this.getDefUserTagName(4);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string defUserTagName5
        {
            get
            {
                try
                {
                    return this.getDefUserTagName(5);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpDriver fParent
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null)
                    {
                        return null;
                    }

                    // --

                    return this.fTcpDriver;
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

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpDevice fPreviousSibling
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fPreviousSibling == null)
                    {
                        return null;
                    }

                    // --

                    return new FTcpDevice(this.fTcdCore, this.fXmlNode.fPreviousSibling);
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

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpDevice fNextSibling
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fNextSibling == null)
                    {
                        return null;
                    }

                    // --

                    return new FTcpDevice(this.fTcdCore, this.fXmlNode.fNextSibling);
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

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpSessionCollection fChildTcpSessionCollection
        {
            get
            {
                try
                {
                    return new FTcpSessionCollection(this.fTcdCore, this.fXmlNode.selectNodes(FXmlTagTSN.E_TcpSession));
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

        //------------------------------------------------------------------------------------------------------------------------

        public FObjectNameCollection fObjectNameCollection
        {
            get
            {
                try
                {
                    return this.getObjectNameCollection();
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

        //------------------------------------------------------------------------------------------------------------------------

        public FObjectCollection fReferenceObjectCollection
        {
            get
            {
                string xpath = string.Empty;

                try
                {
                    xpath =
                        "../../" + FXmlTagEQM.E_EquipmentModeling +
                        "/" + FXmlTagEQP.E_Equipment +
                        "/" + FXmlTagSNG.E_ScenarioGroup +
                        "/" + FXmlTagSNR.E_Scenario +
                        "/" + FXmlTagTTR.E_TcpTrigger +
                        "/" + FXmlTagTCN.E_TcpCondition + "[@" + FXmlTagTCN.A_TcpDeviceId + "='" + this.uniqueIdToString + "']" +
                        " | " +
                        "../../" + FXmlTagEQM.E_EquipmentModeling +
                        "/" + FXmlTagEQP.E_Equipment +
                        "/" + FXmlTagSNG.E_ScenarioGroup +
                        "/" + FXmlTagSNR.E_Scenario +
                        "/" + FXmlTagTTN.E_TcpTransmitter +
                        "/" + FXmlTagTTF.E_TcpTransfer + "[@" + FXmlTagTTF.A_TcpDeviceId + "='" + this.uniqueIdToString + "']";
                    // --
                    return new FObjectCollection(this.fTcdCore, this.fXmlNode.selectNodes(xpath));
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

        //------------------------------------------------------------------------------------------------------------------------

        public FObjectCollection fInclusionObjectCollection
        {
            get
            {
                try
                {
                    return new FObjectCollection(this.fTcdCore, this.fXmlNode.selectNodes("NULL"));
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

        //------------------------------------------------------------------------------------------------------------------------

        public bool hasChild
        {
            get
            {
                try
                {
                    return this.fXmlNode.containsNode(FXmlTagTSN.E_TcpSession);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }        

        //------------------------------------------------------------------------------------------------------------------------

        public bool canAppendChild
        {
            get
            {
                try
                {   
                    return true;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------

        public bool canInsertBefore
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null)
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canInsertAfter
        {
            get
            {
                try
                {
                    return this.canInsertBefore;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canRemove
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null || this.locked || this.fState != FDeviceState.Closed)
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canMoveUp
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null || this.fXmlNode.fPreviousSibling == null)
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canMoveDown
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null || this.fXmlNode.fNextSibling == null)
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        public bool canCut
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null || this.locked || this.fState != FDeviceState.Closed)
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canCopy
        {
            get
            {
                try
                {
                    return true;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canPasteSibling
        {
            get
            {
                try
                {
                    if (
                        this.fXmlNode.fParentNode == null ||
                        !FClipboard.containsData(FCbObjectFormat.TcpDevice)
                        )
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canPasteChild
        {
            get
            {
                try
                {
                    if (!FClipboard.containsData(FCbObjectFormat.TcpSession))
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDeviceState fState
        {
            get
            {
                try
                {
                    return FEnumConverter.toDeviceState(this.fXmlNode.get_attrVal(FXmlTagTDV.A_State, FXmlTagTDV.D_State));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FDeviceState.Closed;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        internal void init(
            )
        {
            try
            {
                this.fTcdCore.ModelingFileChanged += new FModelingFileChangedEventHandler(fTcdCore_ModelingFileChanged);
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

        internal void term(
            )
        {
            try
            {
                this.fTcdCore.ModelingFileChanged -= new FModelingFileChangedEventHandler(fTcdCore_ModelingFileChanged);
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

        public string ToString(
            FStringOption option
            )
        {
            string info = string.Empty;

            try
            {
                if (option == FStringOption.Default)
                {
                    info = this.name;
                }
                else
                {
                    info = this.name + " Protocol=[" + this.fProtocol.ToString() + "]";
                }

                // --

                if (this.description != string.Empty)
                {
                    info += (" Desc=[" + this.description + "]");
                }
                // --                
                return info;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpSession appendChildTcpSession(
            FTcpSession fNewChild
            )
        {
            try
            {
                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, this.fXmlNode.appendChild(fNewChild.fXmlNode));
                // --                
                if (this.isModelingObject)
                {
                    FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fTcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectAppendCompleted, this.fTcpDriver, this, fNewChild)
                        );
                }

                // --

                return fNewChild;
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

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpSession insertBeforeChildTcpSession(
            FTcpSession fNewChild,
            FTcpSession fRefChild
            )
        {
            try
            {
                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, this.fXmlNode.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                // --                
                if (this.isModelingObject)
                {
                    FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fTcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectInsertBeforeCompleted, this.fTcpDriver, this, fNewChild)
                        );
                }

                // --

                return fNewChild;
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

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpSession insertAfterChildTcpSession(
            FTcpSession fNewChild,
            FTcpSession fRefChild
            )
        {
            try
            {
                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, this.fXmlNode.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                // --                
                if (this.isModelingObject)
                {
                    FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fTcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this.fTcpDriver, this, fNewChild)
                        );
                }

                // --

                return fNewChild;
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

        //------------------------------------------------------------------------------------------------------------------------

        public void remove(
            )
        {
            FIObject fParent = null;
            bool isModelingObject = false;

            try
            {
                FTcpDriverCommon.validateRemoveChildObject(this.fXmlNode.fParentNode, this.fXmlNode);
                validateStateCheck();

                // --

                resetRelation();

                // --

                fParent = this.fParent;
                isModelingObject = this.isModelingObject;
                this.replace(this.fTcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));

                // --

                if (isModelingObject)
                {
                    this.fTcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectRemoveCompleted, this.fTcpDriver, fParent, this)
                        );
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fParent = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpSession removeChildTcpSession(
            FTcpSession fChild
            )
        {
            try
            {
                FTcpDriverCommon.validateRemoveChildObject(this.fXmlNode, fChild.fXmlNode);

                // --

                fChild.remove();

                // --

                return fChild;
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

        //------------------------------------------------------------------------------------------------------------------------

        public void removeChildTcpSession(
            FTcpSession[] fChilds
            )
        {
            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                foreach (FTcpSession fTsn in fChilds)
                {
                    FTcpDriverCommon.validateRemoveChildObject(this.fXmlNode, fTsn.fXmlNode);
                }

                // --

                foreach (FTcpSession fOsn in fChilds)
                {
                    fOsn.remove();
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

        public void removeAllChildTcpSession(
            )
        {
            FTcpSessionCollection fTsnCollection = null;

            try
            {
                fTsnCollection = this.fChildTcpSessionCollection;
                if (fTsnCollection.count == 0)
                {
                    return;
                }

                // --

                foreach (FTcpSession fTsn in fTsnCollection)
                {
                    if (fTsn.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }
                }

                // --

                foreach (FTcpSession fTsn in fTsnCollection)
                {
                    fTsn.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fTsnCollection != null)
                {
                    fTsnCollection.Dispose();
                    fTsnCollection = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void resetRelation(
            )
        {
            try
            {
                foreach (FTcpSession fOsn in this.fChildTcpSessionCollection)
                {
                    fOsn.resetRelation();
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

        public void moveUp(
            )
        {
            bool isModelingObject = false;

            try
            {
                FTcpDriverCommon.validateMoveUpObject(this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fTcdCore, this.fXmlNode.moveUp());

                // --

                if (isModelingObject)
                {
                    this.fTcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveUpCompleted, this.fTcpDriver, fParent, this)
                        );
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

        public void moveDown(
            )
        {
            bool isModelingObject = false;

            try
            {
                FTcpDriverCommon.validateMoveDownObject(this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fTcdCore, this.fXmlNode.moveDown());

                // --

                if (isModelingObject)
                {
                    this.fTcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveDownCompleted, this.fTcpDriver, fParent, this)
                        );
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

        public void moveTo(
            FTcpDevice fRefObject
            )
        {
            try
            {
                FTcpDriverCommon.validateMoveToObject(this.fXmlNode, fRefObject.fXmlNode);

                // --

                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Object", "Modeling Object"));
                }

                if (!fRefObject.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Reference Object", "Modeling Object"));
                }

                if (!this.equalsModelingFile(fRefObject))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Modeling File", "same"));
                }

                // --                

                this.replace(this.fTcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fTcdCore, fRefObject.fXmlNode.fParentNode.insertAfter(this.fXmlNode, fRefObject.fXmlNode));

                // --

                this.fTcdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fTcpDriver, this, fRefObject)
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

        //------------------------------------------------------------------------------------------------------------------------

        internal void lockObject(
            )
        {
            try
            {
                if (this.locked)
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagTDV.A_Locked, FXmlTagTDV.D_Locked, FBoolean.True, true);
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

        internal void unlockObject(
            )
        {
            string xpath = string.Empty;

            try
            {
                if (!this.locked)
                {
                    return;
                }

                // ---
                
                xpath = FXmlTagTSN.E_TcpSession + "[@" + FXmlTagTSN.A_Locked + "='" + FBoolean.True + "']" +
                    " | " +
                    FXmlTagEQM.E_EquipmentModeling +
                    "/" + FXmlTagEQP.E_Equipment +
                    "/" + FXmlTagSNG.E_ScenarioGroup +
                    "/" + FXmlTagSNR.E_Scenario +
                    "/" + FXmlTagTTR.E_TcpTrigger +
                    "/" + FXmlTagTCN.E_TcpCondition + "[@" + FXmlTagTCN.A_TcpDeviceId + "='" + this.uniqueIdToString + "']";
                // --
                if (this.fXmlNode.containsNode(xpath))
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagTDV.A_Locked, FXmlTagTDV.D_Locked, FBoolean.False, true);
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

        public void open(
            )
        {
            try
            {
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "TCP Device", "Modeling File"));
                }

                // --

                if (this.fState != FDeviceState.Closed)
                {
                    return;
                }

                // --

                this.fTcdCore.fProtocolAgent.openTcpDevice(this);
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

        public void close(
            )
        {
            try
            {
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "TCP Device", "Modeling File"));
                }

                // --

                if (this.fState == FDeviceState.Closed)
                {
                    return;
                }

                // --

                this.fTcdCore.fProtocolAgent.closeTcpDevice(this);
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

        internal void changeState(
            FDeviceState fState
            )
        {
            try
            {
                if (this.fState == fState)
                {
                    return;
                }
                this.fXmlNode.set_attrVal(FXmlTagTDV.A_State, FXmlTagTDV.D_State, FEnumConverter.fromDeviceState(fState));
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

        public void cut(
            )
        {
            try
            {
                FTcpDriverCommon.validateCutObject(this.fXmlNode);

                // --

                this.remove();
                this.copyObject(FCbObjectFormat.TcpDevice, this.fXmlNode);
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

        public void copy(
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.clone(true);

                // --

                this.copyObject(FCbObjectFormat.TcpDevice, fXmlNode);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpDevice pasteSibling(
            )
        {
            FTcpDevice fTcpDevice = null;

            try
            {
                FTcpDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.TcpDevice);

                // --

                fTcpDevice = (FTcpDevice)this.pasteObject(FCbObjectFormat.TcpDevice);
                // --
                fTcpDevice.changeState(FDeviceState.Closed);
                // -- 
                foreach (FTcpSession fSsn in fTcpDevice.fChildTcpSessionCollection)
                {
                    fSsn.fXmlNode.set_attrVal(FXmlTagTSN.A_TcpLibraryId, FXmlTagTSN.D_TcpLibraryId, "");
                }
                return this.fParent.insertAfterChildTcpDevice(fTcpDevice, this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fTcpDevice = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpSession pasteChild(
            )
        {
            FTcpSession fTcpSession = null;

            try
            {
                FTcpDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.TcpSession);

                // --

                fTcpSession = (FTcpSession)this.pasteObject(FCbObjectFormat.TcpSession);
                this.appendChildTcpSession(fTcpSession);
                fTcpSession.fXmlNode.set_attrVal(FXmlTagTSN.A_TcpLibraryId, FXmlTagTSN.D_TcpLibraryId, "");
                return fTcpSession;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fTcpSession = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void validateStateCheck(
            )
        {
            try
            {
                if (fState != FDeviceState.Closed)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0027, "Device"));
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

        public FTcpSessionCollection selectTcpSessionByName(
            string name
            )
        {
            const string xpath = FXmlTagTSN.E_TcpSession + "[@" + FXmlTagTSN.A_Name + "='{0}']";

            try
            {
                return new FTcpSessionCollection(
                    this.fTcdCore,
                    this.fXmlNode.selectNodes(string.Format(xpath, name))
                    );
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

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpSession selectSingleTcpSessionByName(
            string name
            )
        {
            const string xpath = FXmlTagTSN.E_TcpSession + "[@" + FXmlTagTSN.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FTcpSession(this.fTcdCore, fXmlNode);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpSession selectSingleTcpSessionByUniqueId(
            UInt64 uid
            )
        {
            const string xpath = FXmlTagTSN.E_TcpSession + "[@" + FXmlTagTSN.A_UniqueId + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, uid));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FTcpSession(this.fTcdCore, fXmlNode);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FITcpDeviceDriver createTcpDeviceDriver(
            string fileName
            )
        {
            try
            {
                if (!this.isModelingObject)
                {
                    return null;
                }

                // --

                return (FITcpDeviceDriver)FReflection.createInstanceInMemory(
                    fileName,
                    FConstants.TcpDeviceDriverName,
                    new object[] { new FTcpDeviceDriverArgs(this.fTcpDriver, this) }
                    );
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

        //------------------------------------------------------------------------------------------------------------------------

        public FITcpDeviceDriver createTcpDeviceDriver(
            )
        {
            try
            {
                if (!this.isModelingObject || this.driver == string.Empty)
                {
                    return null;
                }
                // --
                return createTcpDeviceDriver(this.fTcpDriver.tcpDeviceDriverDirectory + "//" + this.driver);
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

        //------------------------------------------------------------------------------------------------------------------------


        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region fTcdCore Object Event Handler

        private void fTcdCore_ModelingFileChanged(
            object sender,
            FModelingFileChangedEventArgs e
            )
        {
            const string xpath =
                FXmlTagTDM.E_TcpDeviceModeling +
                "/" + FXmlTagTDV.E_TcpDevice + "[@" + FXmlTagTDV.A_UniqueId + "='{0}']";            

            FXmlNode fXmlNode = null;

            try
            {                
                fXmlNode = this.fTcdCore.fXmlNodeTcd.selectSingleNode(string.Format(xpath, this.uniqueIdToString));
                fXmlNode.set_attrVal(FXmlTagTDV.A_State, FXmlTagTDV.D_State, FEnumConverter.fromDeviceState(this.fState)); // 기존 상태 유지

                // --

                this.replace(this.fTcdCore, fXmlNode);
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                fXmlNode = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
