/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecsDriverLog.cs
--  Creator         : spike.lee
--  Create Date     : 2011.09.28
--  Description     : FAMate Core FaSecsDriver SECS Driver Log Class 
--  History         : Created by spike.lee at 2011.09.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public class FSecsDriverLog : FBaseObjectLog<FSecsDriverLog>, FIObjectLog
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecsDriverLog(            
            )           
            : base()
        {
            this.fSecsDriverLog = this;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FSecsDriverLog(
            FSecsDriver fSecsDriver
            )
            : base()
        {
            this.fXmlNode.set_attrVal(FXmlTagSCDL.A_UniqueId, FXmlTagSCDL.D_UniqueId, fSecsDriver.uniqueIdToString);
            this.fXmlNode.set_attrVal(FXmlTagSCDL.A_Name, FXmlTagSCDL.D_Name, fSecsDriver.name);
            this.fXmlNode.set_attrVal(FXmlTagSCDL.A_Description, FXmlTagSCDL.D_Description, fSecsDriver.description);
            this.fXmlNode.set_attrVal(FXmlTagSCDL.A_FontColor, FXmlTagSCDL.D_FontColor, fSecsDriver.fontColor.Name);
            this.fXmlNode.set_attrVal(FXmlTagSCDL.A_FontBold, FXmlTagSCDL.D_FontBold, FBoolean.fromBool(fSecsDriver.fontBold));
            this.fXmlNode.set_attrVal(FXmlTagSCDL.A_EapName, FXmlTagSCDL.D_EapName, fSecsDriver.eapName);
            this.fXmlNode.set_attrVal(FXmlTagSCDL.A_UserTag1, FXmlTagSCDL.D_UserTag1, fSecsDriver.userTag1);
            this.fXmlNode.set_attrVal(FXmlTagSCDL.A_UserTag2, FXmlTagSCDL.D_UserTag2, fSecsDriver.userTag2);
            this.fXmlNode.set_attrVal(FXmlTagSCDL.A_UserTag3, FXmlTagSCDL.D_UserTag3, fSecsDriver.userTag3);
            this.fXmlNode.set_attrVal(FXmlTagSCDL.A_UserTag4, FXmlTagSCDL.D_UserTag4, fSecsDriver.userTag4);
            this.fXmlNode.set_attrVal(FXmlTagSCDL.A_UserTag5, FXmlTagSCDL.D_UserTag5, fSecsDriver.userTag5);
            // --
            this.fSecsDriverLog = this;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FSecsDriverLog(
            FScdlCore fScdlCore, 
            FXmlNode fXmlNode
            )
            : base(fScdlCore, fXmlNode)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSecsDriverLog(
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
                    
                }                
                m_disposed = true;
         
                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FObjectLogType fObjectLogType
        {
            get
            {
                try
                {
                    return FObjectLogType.SecsDriverLog;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectLogType.SecsDriverLog;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string logUniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSCDL.A_LogUniqueId, FXmlTagSCDL.D_LogUniqueId);
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

        public UInt64 logUniqueId
        {
            get
            {
                try
                {
                    return UInt64.Parse(this.logUniqueIdToString);
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

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSCDL.A_UniqueId, FXmlTagSCDL.D_UniqueId);
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

        public string name
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSCDL.A_Name, FXmlTagSCDL.D_Name);
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

        public string description
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSCDL.A_Description, FXmlTagSCDL.D_Description);
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

        public Color fontColor
        {
            get
            {
                try
                {
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagSCDL.A_FontColor, FXmlTagSCDL.D_FontColor));
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool fontBold
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSCDL.A_FontBold, FXmlTagSCDL.D_FontBold));
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

        public string eapName
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSCDL.A_EapName, FXmlTagSCDL.D_EapName);
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

        public string userTag1
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSCDL.A_UserTag1, FXmlTagSCDL.D_UserTag1);
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

        public string userTag2
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSCDL.A_UserTag2, FXmlTagSCDL.D_UserTag2);
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

        public string userTag3
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSCDL.A_UserTag3, FXmlTagSCDL.D_UserTag3);
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

        public string userTag4
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSCDL.A_UserTag4, FXmlTagSCDL.D_UserTag4);
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

        public string userTag5
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSCDL.A_UserTag5, FXmlTagSCDL.D_UserTag5);
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

        public FObjectLogCollection fChildObjectLogCollection
        {
            get
            {
                try
                {
                    return new FObjectLogCollection(this.fScdlCore, this.fXmlNode.selectNodes("*"));
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
                string xpath = string.Empty;

                try
                {
                    xpath =
                        FXmlTagSDVL.E_SecsDevice + " | " +
                        FXmlTagSDTL.E_SecsDeviceTimeout + " | " +
                        FXmlTagSDEL.E_SecsDeviceError + " | " +
                        FXmlTagSTPL.E_SecsDeviceTelnetPacket + " | " +
                        FXmlTagSTSL.E_SecsDeviceTelnetStateChanged + " | " +
                        FXmlTagSDHL.E_SecsDeviceHandshake + " | " +
                        FXmlTagCMGL.E_ControlMessage + " | " +
                        FXmlTagSDBL.E_SecsDeviceBlock + " | " +
                        FXmlTagSMLL.E_Sml + " | " +
                        FXmlTagSMGL.E_SecsMessage + " | " +
                        FXmlTagHDVL.E_HostDevice + " | " +
                        FXmlTagHDEL.E_HostDeviceError + " | " +
                        FXmlTagVFEL.E_Vfei + " | " +
                        FXmlTagHMGL.E_HostMessage + " | " +
                        FXmlTagSTRL.E_SecsTrigger + " | " +
                        FXmlTagSTNL.E_SecsTransmitter + " | " +
                        FXmlTagHTRL.E_HostTrigger + " | " +
                        FXmlTagHTNL.E_HostTransmitter + " | " +
                        FXmlTagMAPL.E_Mapper + " | " +
                        FXmlTagSTGL.E_Storage + " | " +
                        FXmlTagCBKL.E_Callback + " | " +
                        FXmlTagFUNL.E_Function + " | " +
                        FXmlTagBRNL.E_Branch + " | " +
                        FXmlTagCMTL.E_Comment + " | " +
                        FXmlTagETPL.E_EntryPoint + " | " +
                        FXmlTagPAUL.E_Pauser + " | " +
                        FXmlTagETPL.E_EntryPoint + " | " +
                        FXmlTagAPPL.E_Application;
                    // --
                    return this.fXmlNode.containsNode(xpath);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public FIObjectLog appendChildObjectLog(
            FIObjectLog fObjectLog
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                // ***
                // 2017.05.30 by spike.lee
                // Log 객체를 다중 Driver Log에 추가하기 위해 XmlNode를 Clone 처리
                // ***
                fXmlNode = FSecsDriverLogCommon.getObjectLogXmlNode(fObjectLog).clone(true);
                // --
                if (
                    fXmlNode == null || 
                    fObjectLog.fObjectLogType == FObjectLogType.SecsDriverLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.SecsItemLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.HostItemLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.DataSetLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.DataLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.RepositoryLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.ColumnLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.ContentLog

                    )
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0015, "Object Log"));
                }

                if (fXmlNode.fParentNode != null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0004, "Object Log", "Parent"));
                }

                // --

                fXmlNode = this.fXmlNode.appendChild(fXmlNode);
                FSecsDriverLogCommon.resetLogUniqueId(this.fScdlCore.fIdPointer, fXmlNode);                

                // --

                if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceStateChangedLog)
                {
                    ((FSecsDeviceStateChangedLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataReceivedLog)
                {
                    ((FSecsDeviceDataReceivedLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataSentLog)
                {
                    ((FSecsDeviceDataSentLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceErrorRaisedLog)
                {
                    ((FSecsDeviceErrorRaisedLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceControlMessageReceivedLog)
                {
                    ((FSecsDeviceControlMessageReceivedLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceControlMessageSentLog)
                {
                    ((FSecsDeviceControlMessageSentLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceSmlReceivedLog)
                {
                    ((FSecsDeviceSmlReceivedLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceSmlSentLog)
                {
                    ((FSecsDeviceSmlSentLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTimeoutRaisedLog)
                {
                    ((FSecsDeviceTimeoutRaisedLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog)
                {
                    ((FSecsDeviceDataMessageReceivedLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog)
                {
                    ((FSecsDeviceDataMessageSentLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                // --
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceStateChangedLog)
                {
                    ((FHostDeviceStateChangedLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceErrorRaisedLog)
                {
                    ((FHostDeviceErrorRaisedLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceVfeiReceivedLog)
                {
                    ((FHostDeviceVfeiReceivedLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceVfeiSentLog)
                {
                    ((FHostDeviceVfeiSentLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                {
                    ((FHostDeviceDataMessageReceivedLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }                
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                {
                    ((FHostDeviceDataMessageSentLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                // --
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsTriggerRaisedLog)
                {
                    ((FSecsTriggerRaisedLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsTransmitterRaisedLog)
                {
                    ((FSecsTransmitterRaisedLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTriggerRaisedLog)
                {
                    ((FHostTriggerRaisedLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTransmitterRaisedLog)
                {
                    ((FHostTransmitterRaisedLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.JudgementPerformedLog)
                {
                    ((FJudgementPerformedLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.MapperPerformedLog)
                {
                    ((FMapperPerformedLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EquipmentStateSetAltererPerformedLog)
                {
                    ((FEquipmentStateSetAltererPerformedLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.StoragePerformedLog)
                {
                    ((FStoragePerformedLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CallbackRaisedLog)
                {
                    ((FCallbackRaisedLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.FunctionCalledLog)
                {
                    ((FFunctionCalledLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.BranchRaisedLog)
                {
                    ((FBranchRaisedLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CommentWrittenLog)
                {
                    ((FCommentWrittenLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PauserRaisedLog)
                {
                    ((FPauserRaisedLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EntryPointCalledLog)
                {
                    ((FEntryPointCalledLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                // --
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceBlockReceivedLog)
                {
                    ((FSecsDeviceBlockReceivedLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceBlockSentLog)
                {
                    ((FSecsDeviceBlockSentLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceHandshakeReceivedLog)
                {
                    ((FSecsDeviceHandshakeReceivedLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceHandshakeSentLog)
                {
                    ((FSecsDeviceHandshakeSentLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTelnetPacketReceivedLog)
                {
                    ((FSecsDeviceTelnetPacketReceivedLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTelnetPacketSentLog)
                {
                    ((FSecsDeviceTelnetPacketSentLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTelnetStateChangedLog)
                {
                    ((FSecsDeviceTelnetStateChangedLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.ApplicationWrittenLog)
                {
                    ((FApplicationWrittenLog)fObjectLog).replace(this.fScdlCore, fXmlNode);
                }

                // --

                return FSecsDriverLogCommon.createObjectLog(this.fScdlCore, fXmlNode);
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

        public void removeAllObjectLog(
            )
        {
            try
            {
                foreach (FIObjectLog f in this.fChildObjectLogCollection)
                {
                    if (f.fObjectLogType == FObjectLogType.SecsDeviceStateChangedLog)
                    {
                        ((FSecsDeviceStateChangedLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FSecsDeviceStateChangedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.SecsDeviceDataReceivedLog)
                    {
                        ((FSecsDeviceDataReceivedLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FSecsDeviceDataReceivedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.SecsDeviceDataSentLog)
                    {
                        ((FSecsDeviceDataSentLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FSecsDeviceDataSentLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.SecsDeviceErrorRaisedLog)
                    {
                        ((FSecsDeviceErrorRaisedLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FSecsDeviceErrorRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.SecsDeviceControlMessageReceivedLog)
                    {
                        ((FSecsDeviceControlMessageReceivedLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FSecsDeviceControlMessageReceivedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.SecsDeviceControlMessageSentLog)
                    {
                        ((FSecsDeviceControlMessageSentLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FSecsDeviceControlMessageSentLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.SecsDeviceSmlReceivedLog)
                    {
                        ((FSecsDeviceSmlReceivedLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FSecsDeviceSmlReceivedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.SecsDeviceSmlSentLog)
                    {
                        ((FSecsDeviceSmlSentLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FSecsDeviceSmlSentLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.SecsDeviceTimeoutRaisedLog)
                    {
                        ((FSecsDeviceTimeoutRaisedLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FSecsDeviceTimeoutRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog)
                    {
                        ((FSecsDeviceDataMessageReceivedLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FSecsDeviceDataMessageReceivedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog)
                    {
                        ((FSecsDeviceDataMessageSentLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FSecsDeviceDataMessageSentLog)f).fXmlNode));
                    }
                    // -- 
                    else if (f.fObjectLogType == FObjectLogType.SecsDeviceBlockReceivedLog)
                    {
                        ((FSecsDeviceBlockReceivedLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FSecsDeviceBlockReceivedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.SecsDeviceBlockSentLog)
                    {
                        ((FSecsDeviceBlockSentLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FSecsDeviceBlockSentLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.SecsDeviceHandshakeReceivedLog)
                    {
                        ((FSecsDeviceHandshakeReceivedLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FSecsDeviceHandshakeReceivedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.SecsDeviceHandshakeSentLog)
                    {
                        ((FSecsDeviceHandshakeSentLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FSecsDeviceHandshakeSentLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.SecsDeviceTelnetPacketReceivedLog)
                    {
                        ((FSecsDeviceTelnetPacketReceivedLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FSecsDeviceTelnetPacketReceivedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.SecsDeviceTelnetPacketSentLog)
                    {
                        ((FSecsDeviceTelnetPacketSentLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FSecsDeviceTelnetPacketSentLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.SecsDeviceTelnetStateChangedLog)
                    {
                        ((FSecsDeviceTelnetStateChangedLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FSecsDeviceTelnetStateChangedLog)f).fXmlNode));
                    }
                    // --
                    else if (f.fObjectLogType == FObjectLogType.HostDeviceStateChangedLog)
                    {
                        ((FHostDeviceStateChangedLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FHostDeviceStateChangedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.HostDeviceErrorRaisedLog)
                    {
                        ((FHostDeviceErrorRaisedLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FHostDeviceErrorRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.HostDeviceVfeiReceivedLog)
                    {
                        ((FHostDeviceVfeiReceivedLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FHostDeviceVfeiReceivedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.HostDeviceVfeiSentLog)
                    {
                        ((FHostDeviceVfeiSentLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FHostDeviceVfeiSentLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                    {
                        ((FHostDeviceDataMessageReceivedLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FHostDeviceDataMessageReceivedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                    {
                        ((FHostDeviceDataMessageSentLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FHostDeviceDataMessageSentLog)f).fXmlNode));
                    }
                    // --
                    else if (f.fObjectLogType == FObjectLogType.SecsTriggerRaisedLog)
                    {
                        ((FSecsTriggerRaisedLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FSecsTriggerRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.SecsTransmitterRaisedLog)
                    {
                        ((FSecsTransmitterRaisedLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FSecsTransmitterRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.HostTriggerRaisedLog)
                    {
                        ((FHostTriggerRaisedLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FHostTriggerRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.HostTransmitterRaisedLog)
                    {
                        ((FHostTransmitterRaisedLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FHostTransmitterRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.JudgementPerformedLog)
                    {
                        ((FJudgementPerformedLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FJudgementPerformedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.MapperPerformedLog)
                    {
                        ((FMapperPerformedLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FMapperPerformedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.EquipmentStateSetAltererPerformedLog)
                    {
                        ((FEquipmentStateSetAltererPerformedLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FEquipmentStateSetAltererPerformedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.StoragePerformedLog)
                    {
                        ((FStoragePerformedLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FStoragePerformedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.CallbackRaisedLog)
                    {
                        ((FCallbackRaisedLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FCallbackRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.FunctionCalledLog)
                    {
                        ((FFunctionCalledLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FFunctionCalledLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.BranchRaisedLog)
                    {
                        ((FBranchRaisedLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FBranchRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.CommentWrittenLog)
                    {
                        ((FCommentWrittenLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FCommentWrittenLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.PauserRaisedLog)
                    {
                        ((FPauserRaisedLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FPauserRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.EntryPointCalledLog)
                    {
                        ((FEntryPointCalledLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FEntryPointCalledLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.ApplicationWrittenLog)
                    {
                        ((FApplicationWrittenLog)f).replace(this.fScdlCore, this.fXmlNode.removeChild(((FApplicationWrittenLog)f).fXmlNode));
                    }
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

        public void openLogFile(
            string fileName
            )
        {
            try
            {
                this.fScdlCore.openLogFile(fileName);
                this.replace(this.fScdlCore, this.fScdlCore.fXmlNodeScdl);
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

        public void saveLogFile(
            string fileName
            )
        {
            try
            {
                this.fScdlCore.saveLogFile(fileName);
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
                    info = this.name + " MC=[" + this.eapName + "]";
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

        private FIObjectLog searchLogCommonSeries(
           string baseLogUniqueId,
           string searchWord,
           FXmlNodeList fXmlNodeSearchList
           )
        {
            int index = 0;

            try
            {
                searchWord = searchWord.ToLower();

                // --

                for (int i = 0; i < fXmlNodeSearchList.count; i++)
                {
                    if (fXmlNodeSearchList[i].get_attrVal(FXmlTagCommon.A_LogUniqueId, FXmlTagCommon.D_LogUniqueId) == baseLogUniqueId)
                    {
                        index = i;
                        break;
                    }
                }

                // --

                // ***
                // Next Search
                // ***
                for (int i = index + 1; i < fXmlNodeSearchList.count; i++)
                {
                    if (FCommon.compareSearchObject(fXmlNodeSearchList[i], searchWord))
                    {
                        return FSecsDriverLogCommon.createObjectLog(this.fScdlCore, fXmlNodeSearchList[i]);
                    }
                }

                // --

                // ***
                // Previous Search
                // ***
                for (int i = 0; i <= index; i++)
                {
                    if (FCommon.compareSearchObject(fXmlNodeSearchList[i], searchWord))
                    {
                        return FSecsDriverLogCommon.createObjectLog(this.fScdlCore, fXmlNodeSearchList[i]);
                    }
                }

                // --

                return null;
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

        public FIObjectLog searchLogSeries(
             FIObjectLog fBaseObject,
             string searchWord
             )
        {
            const string xPath =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCDL.E_SecsDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCDL.E_SecsDriver + "//*";

            try
            {
                return searchLogCommonSeries(
                    fBaseObject.logUniqueIdToString,
                    searchWord,
                    this.fScdlCore.fXmlDoc.selectNodes(xPath)          
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
