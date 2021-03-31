/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPlcDriverLog.cs
--  Creator         : spike.lee
--  Create Date     : 2011.09.28
--  Description     : FAMate Core FaSecsDriver SECS Driver Log Class 
--  History         : Created by spike.lee at 2011.09.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;
using System.IO;

namespace Nexplant.MC.Core.FaPlcDriver
{
    public class FPlcDriverLog : FBaseObjectLog<FPlcDriverLog>, FIObjectLog
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPlcDriverLog(            
            )           
            : base()
        {
            this.fPlcDriverLog = this;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FPlcDriverLog(
            FPlcDriver fPlcDriver
            )
            : base()
        {
            this.fXmlNode.set_attrVal(FXmlTagPCDL.A_UniqueId, FXmlTagPCDL.D_UniqueId, fPlcDriver.uniqueIdToString);
            this.fXmlNode.set_attrVal(FXmlTagPCDL.A_Name, FXmlTagPCDL.D_Name, fPlcDriver.name);
            this.fXmlNode.set_attrVal(FXmlTagPCDL.A_Description, FXmlTagPCDL.D_Description, fPlcDriver.description);
            this.fXmlNode.set_attrVal(FXmlTagPCDL.A_FontColor, FXmlTagPCDL.D_FontColor, fPlcDriver.fontColor.Name);
            this.fXmlNode.set_attrVal(FXmlTagPCDL.A_FontBold, FXmlTagPCDL.D_FontBold, FBoolean.fromBool(fPlcDriver.fontBold));
            this.fXmlNode.set_attrVal(FXmlTagPCDL.A_EapName, FXmlTagPCDL.D_EapName, fPlcDriver.eapName);
            this.fXmlNode.set_attrVal(FXmlTagPCDL.A_UserTag1, FXmlTagPCDL.D_UserTag1, fPlcDriver.userTag1);
            this.fXmlNode.set_attrVal(FXmlTagPCDL.A_UserTag2, FXmlTagPCDL.D_UserTag2, fPlcDriver.userTag2);
            this.fXmlNode.set_attrVal(FXmlTagPCDL.A_UserTag3, FXmlTagPCDL.D_UserTag3, fPlcDriver.userTag3);
            this.fXmlNode.set_attrVal(FXmlTagPCDL.A_UserTag4, FXmlTagPCDL.D_UserTag4, fPlcDriver.userTag4);
            this.fXmlNode.set_attrVal(FXmlTagPCDL.A_UserTag5, FXmlTagPCDL.D_UserTag5, fPlcDriver.userTag5);
            // --
            this.fPlcDriverLog = this;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FPlcDriverLog(
            FPcdlCore fPcdlCore, 
            FXmlNode fXmlNode
            )
            : base(fPcdlCore, fXmlNode)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPlcDriverLog(
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
                    return FObjectLogType.PlcDriverLog;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectLogType.PlcDriverLog;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string logUniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagPCDL.A_LogUniqueId, FXmlTagPCDL.D_LogUniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPCDL.A_UniqueId, FXmlTagPCDL.D_UniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPCDL.A_Name, FXmlTagPCDL.D_Name);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPCDL.A_Description, FXmlTagPCDL.D_Description);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagPCDL.A_FontColor, FXmlTagPCDL.D_FontColor));
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagPCDL.A_FontBold, FXmlTagPCDL.D_FontBold));
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
                    return this.fXmlNode.get_attrVal(FXmlTagPCDL.A_EapName, FXmlTagPCDL.D_EapName);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPCDL.A_UserTag1, FXmlTagPCDL.D_UserTag1);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPCDL.A_UserTag2, FXmlTagPCDL.D_UserTag2);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPCDL.A_UserTag3, FXmlTagPCDL.D_UserTag3);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPCDL.A_UserTag4, FXmlTagPCDL.D_UserTag4);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPCDL.A_UserTag5, FXmlTagPCDL.D_UserTag5);
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
                    return new FObjectLogCollection(this.fPcdlCore, this.fXmlNode.selectNodes("*"));
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
                        FXmlTagPDVL.E_PlcDevice + " | " +
                        FXmlTagPDTL.E_PlcDeviceTimeout + " | " +
                        FXmlTagPDEL.E_PlcDeviceError + " | " +                        
                        FXmlTagPMGL.E_PlcMessage + " | " +
                        FXmlTagHDVL.E_HostDevice + " | " +
                        FXmlTagHDEL.E_HostDeviceError + " | " +
                        FXmlTagVFEL.E_Vfei + " | " +
                        FXmlTagHMGL.E_HostMessage + " | " +
                        FXmlTagPTRL.E_PlcTrigger + " | " +
                        FXmlTagPTNL.E_PlcTransmitter + " | " +
                        FXmlTagHTRL.E_HostTrigger + " | " +
                        FXmlTagHTNL.E_HostTransmitter + " | " +
                        FXmlTagMAPL.E_Mapper + " | " +
                        FXmlTagSTGL.E_Storage + " | " +
                        FXmlTagCBKL.E_Callback + " | " +
                        FXmlTagFUNL.E_Function + " | " +
                        FXmlTagBRNL.E_Branch + " | " +
                        FXmlTagCMTL.E_Comment + " | " +
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
                fXmlNode = FPlcDriverLogCommon.getObjectLogXmlNode(fObjectLog).clone(true);
                // --
                if (
                    fXmlNode == null ||
                    fObjectLog.fObjectLogType == FObjectLogType.PlcDriverLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.PlcBitListLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.PlcBitLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.PlcWordListLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.PlcWordLog ||
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
                FPlcDriverLogCommon.resetLogUniqueId(this.fPcdlCore.fIdPointer, fXmlNode);                

                // --

                if (fObjectLog.fObjectLogType == FObjectLogType.PlcDeviceStateChangedLog)
                {
                    ((FPlcDeviceStateChangedLog)fObjectLog).replace(this.fPcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PlcDeviceDataReceivedLog)
                {
                    ((FPlcDeviceDataReceivedLog)fObjectLog).replace(this.fPcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PlcDeviceDataSentLog)
                {
                    ((FPlcDeviceDataSentLog)fObjectLog).replace(this.fPcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PlcDeviceErrorRaisedLog)
                {
                    ((FPlcDeviceErrorRaisedLog)fObjectLog).replace(this.fPcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PlcDeviceTimeoutRaisedLog)
                {
                    ((FPlcDeviceTimeoutRaisedLog)fObjectLog).replace(this.fPcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PlcDeviceDataMessageReadLog)
                {
                    ((FPlcDeviceDataMessageReadLog)fObjectLog).replace(this.fPcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PlcDeviceDataMessageWrittenLog)
                {
                    ((FPlcDeviceDataMessageWrittenLog)fObjectLog).replace(this.fPcdlCore, fXmlNode);
                }
                // --
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceStateChangedLog)
                {
                    ((FHostDeviceStateChangedLog)fObjectLog).replace(this.fPcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceErrorRaisedLog)
                {
                    ((FHostDeviceErrorRaisedLog)fObjectLog).replace(this.fPcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceVfeiReceivedLog)
                {
                    ((FHostDeviceVfeiReceivedLog)fObjectLog).replace(this.fPcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceVfeiSentLog)
                {
                    ((FHostDeviceVfeiSentLog)fObjectLog).replace(this.fPcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                {
                    ((FHostDeviceDataMessageReceivedLog)fObjectLog).replace(this.fPcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                {
                    ((FHostDeviceDataMessageSentLog)fObjectLog).replace(this.fPcdlCore, fXmlNode);
                }
                // --        
                else if (fObjectLog.fObjectLogType == FObjectLogType.PlcTriggerRaisedLog)
                {
                    ((FPlcTriggerRaisedLog)fObjectLog).replace(this.fPcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PlcTransmitterRaisedLog)
                {
                    ((FPlcTransmitterRaisedLog)fObjectLog).replace(this.fPcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTriggerRaisedLog)
                {
                    ((FHostTriggerRaisedLog)fObjectLog).replace(this.fPcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTransmitterRaisedLog)
                {
                    ((FHostTransmitterRaisedLog)fObjectLog).replace(this.fPcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.JudgementPerformedLog)
                {
                    ((FJudgementPerformedLog)fObjectLog).replace(this.fPcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.MapperPerformedLog)
                {
                    ((FMapperPerformedLog)fObjectLog).replace(this.fPcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EquipmentStateSetAltererPerformedLog)
                {
                    ((FEquipmentStateSetAltererPerformedLog)fObjectLog).replace(this.fPcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.StoragePerformedLog)
                {
                    ((FStoragePerformedLog)fObjectLog).replace(this.fPcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CallbackRaisedLog)
                {
                    ((FCallbackRaisedLog)fObjectLog).replace(this.fPcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.FunctionCalledLog)
                {
                    ((FFunctionCalledLog)fObjectLog).replace(this.fPcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.BranchRaisedLog)
                {
                    ((FBranchRaisedLog)fObjectLog).replace(this.fPcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CommentWrittenLog)
                {
                    ((FCommentWrittenLog)fObjectLog).replace(this.fPcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PauserRaisedLog)
                {
                    ((FPauserRaisedLog)fObjectLog).replace(this.fPcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EntryPointCalledLog)
                {
                    ((FEntryPointCalledLog)fObjectLog).replace(this.fPcdlCore, fXmlNode);
                }
                // --
                else if (fObjectLog.fObjectLogType == FObjectLogType.ApplicationWrittenLog)
                {
                    ((FApplicationWrittenLog)fObjectLog).replace(this.fPcdlCore, fXmlNode);
                }

                // --

                return FPlcDriverLogCommon.createObjectLog(this.fPcdlCore, fXmlNode);
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
                    if (f.fObjectLogType == FObjectLogType.PlcDeviceStateChangedLog)
                    {
                        ((FPlcDeviceStateChangedLog)f).replace(this.fPcdlCore, this.fXmlNode.removeChild(((FPlcDeviceStateChangedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.PlcDeviceDataReceivedLog)
                    {
                        ((FPlcDeviceDataReceivedLog)f).replace(this.fPcdlCore, this.fXmlNode.removeChild(((FPlcDeviceDataReceivedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.PlcDeviceDataSentLog)
                    {
                        ((FPlcDeviceDataSentLog)f).replace(this.fPcdlCore, this.fXmlNode.removeChild(((FPlcDeviceDataSentLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.PlcDeviceErrorRaisedLog)
                    {
                        ((FPlcDeviceErrorRaisedLog)f).replace(this.fPcdlCore, this.fXmlNode.removeChild(((FPlcDeviceErrorRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.PlcDeviceTimeoutRaisedLog)
                    {
                        ((FPlcDeviceTimeoutRaisedLog)f).replace(this.fPcdlCore, this.fXmlNode.removeChild(((FPlcDeviceTimeoutRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.PlcDeviceDataMessageReadLog)
                    {
                        ((FPlcDeviceDataMessageReadLog)f).replace(this.fPcdlCore, this.fXmlNode.removeChild(((FPlcDeviceDataMessageReadLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.PlcDeviceDataMessageWrittenLog)
                    {
                        ((FPlcDeviceDataMessageWrittenLog)f).replace(this.fPcdlCore, this.fXmlNode.removeChild(((FPlcDeviceDataMessageWrittenLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.PlcBitListLog)
                    {
                        ((FPlcBitListLog)f).replace(this.fPcdlCore, this.fXmlNode.removeChild(((FPlcBitListLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.PlcBitLog)
                    {
                        ((FPlcBitLog)f).replace(this.fPcdlCore, this.fXmlNode.removeChild(((FPlcBitLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.PlcWordListLog)
                    {
                        ((FPlcWordListLog)f).replace(this.fPcdlCore, this.fXmlNode.removeChild(((FPlcWordListLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.PlcWordLog)
                    {
                        ((FPlcWordLog)f).replace(this.fPcdlCore, this.fXmlNode.removeChild(((FPlcWordLog)f).fXmlNode));
                    }       
                    // --
                    else if (f.fObjectLogType == FObjectLogType.HostDeviceStateChangedLog)
                    {
                        ((FHostDeviceStateChangedLog)f).replace(this.fPcdlCore, this.fXmlNode.removeChild(((FHostDeviceStateChangedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.HostDeviceErrorRaisedLog)
                    {
                        ((FHostDeviceErrorRaisedLog)f).replace(this.fPcdlCore, this.fXmlNode.removeChild(((FHostDeviceErrorRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.HostDeviceVfeiReceivedLog)
                    {
                        ((FHostDeviceVfeiReceivedLog)f).replace(this.fPcdlCore, this.fXmlNode.removeChild(((FHostDeviceVfeiReceivedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.HostDeviceVfeiSentLog)
                    {
                        ((FHostDeviceVfeiSentLog)f).replace(this.fPcdlCore, this.fXmlNode.removeChild(((FHostDeviceVfeiSentLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                    {
                        ((FHostDeviceDataMessageReceivedLog)f).replace(this.fPcdlCore, this.fXmlNode.removeChild(((FHostDeviceDataMessageReceivedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                    {
                        ((FHostDeviceDataMessageSentLog)f).replace(this.fPcdlCore, this.fXmlNode.removeChild(((FHostDeviceDataMessageSentLog)f).fXmlNode));
                    }
                    // --
                    else if (f.fObjectLogType == FObjectLogType.HostTriggerRaisedLog)
                    {
                        ((FHostTriggerRaisedLog)f).replace(this.fPcdlCore, this.fXmlNode.removeChild(((FHostTriggerRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.HostTransmitterRaisedLog)
                    {
                        ((FHostTransmitterRaisedLog)f).replace(this.fPcdlCore, this.fXmlNode.removeChild(((FHostTransmitterRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.CallbackRaisedLog)
                    {
                        ((FCallbackRaisedLog)f).replace(this.fPcdlCore, this.fXmlNode.removeChild(((FCallbackRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.FunctionCalledLog)
                    {
                        ((FFunctionCalledLog)f).replace(this.fPcdlCore, this.fXmlNode.removeChild(((FFunctionCalledLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.BranchRaisedLog)
                    {
                        ((FBranchRaisedLog)f).replace(this.fPcdlCore, this.fXmlNode.removeChild(((FBranchRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.CommentWrittenLog)
                    {
                        ((FCommentWrittenLog)f).replace(this.fPcdlCore, this.fXmlNode.removeChild(((FCommentWrittenLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.PauserRaisedLog)
                    {
                        ((FPauserRaisedLog)f).replace(this.fPcdlCore, this.fXmlNode.removeChild(((FPauserRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.EntryPointCalledLog)
                    {
                        ((FEntryPointCalledLog)f).replace(this.fPcdlCore, this.fXmlNode.removeChild(((FEntryPointCalledLog)f).fXmlNode));
                    }
                    // --
                    else if (f.fObjectLogType == FObjectLogType.ApplicationWrittenLog)
                    {
                        ((FApplicationWrittenLog)f).replace(this.fPcdlCore, this.fXmlNode.removeChild(((FApplicationWrittenLog)f).fXmlNode));
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
                this.fPcdlCore.openLogFile(fileName);
                this.replace(this.fPcdlCore, this.fPcdlCore.fXmlNodePcdl);
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
                this.fPcdlCore.saveLogFile(fileName);
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
                    info = this.name + " EAP=[" + this.eapName + "]";
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

        private bool searchLogNode(
            FXmlNode fXmlNode,
            FXmlNode fXmlNodeStart,
            string searchWord,
            ref FXmlNode fXmlNodeResult
            )
        {
            try
            {
                // ***
                // Text 비교
                // ***
                if (FCommon.contains(fXmlNode, searchWord))
                {
                    fXmlNodeResult = fXmlNode;
                    return true;
                }

                // ***
                // 1 Cycle이면 검색 종료
                // ***
                if (fXmlNode == fXmlNodeStart)
                {
                    return true;
                }

                // ***
                // Child 검색
                // ***
                foreach (FXmlNode n in fXmlNode.fChildNodes)
                {
                    if (searchLogNode(n, fXmlNodeStart, searchWord, ref fXmlNodeResult))
                    {
                        return true;
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
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIObjectLog searchLogSeries(
             FIObjectLog fBaseObject,
             string searchWord
             )
        {
            FXmlNode fXmlNodeStart = null;
            FXmlNode fXmlNodeSearch = null;
            FXmlNode fXmlNodeResult = null;

            try
            {
                fXmlNodeStart = FPlcDriverLogCommon.getObjectLogXmlNode(fBaseObject);
                fXmlNodeSearch = fXmlNodeStart;

                // --

                while (true)
                {
                    // ***
                    // Child Node 검색
                    // ***
                    foreach (FXmlNode n in fXmlNodeSearch.fChildNodes)
                    {
                        if (searchLogNode(n, fXmlNodeStart, searchWord, ref fXmlNodeResult))
                        {
                            return fXmlNodeResult != null ?
                                FPlcDriverLogCommon.createObjectLog(this.fPcdlCore, fXmlNodeResult) :
                                null;
                        }
                    }

                    // ***
                    // Get Next Node
                    // ***
                    fXmlNodeSearch = FCommon.getNextNode(fXmlNodeSearch, this.fXmlNode);

                    // ***
                    // Current Node 검색
                    // ***
                    if (FCommon.contains(fXmlNodeSearch, searchWord))
                    {
                        return FPlcDriverLogCommon.createObjectLog(this.fPcdlCore, fXmlNodeSearch);
                    }

                    // ***
                    // 1 Cycle이면 검색 종료
                    // ***
                    if (fXmlNodeSearch == fXmlNodeStart)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeStart = null;
                fXmlNodeSearch = null;
                fXmlNodeResult = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private FXmlNode searchLogNode(
            FXmlNode fXmlNodeBase,
            string searchWord
            )
        {
            FXmlNode fXmlNodeRoot = null;
            FXmlNode fXmlNodeStart = null;

            try
            {
                fXmlNodeRoot = this.fXmlNode;
                
                // --

                if (fXmlNodeBase.fFirstChild != null)
                {
                    fXmlNodeStart = fXmlNodeBase.fFirstChild;
                }
                else if (fXmlNodeBase.fNextSibling != null)
                {
                    fXmlNodeStart = fXmlNodeBase.fNextSibling;
                }
                else
                {
                    fXmlNodeStart = FSearchNode.getNextNode(fXmlNodeBase, fXmlNodeRoot);
                    // --
                    if (fXmlNodeStart.fPreviousSibling == fXmlNodeRoot)
                    {
                        fXmlNodeStart = fXmlNodeRoot;
                    }
                    else if (
                        fXmlNodeStart.name == FXmlTagPCDL.E_PlcDriver &&
                        FSearchNode.contains(fXmlNodeStart.get_attrVal(FXmlTagPCDL.A_Name, FXmlTagPCDL.D_Name), searchWord)
                        )
                    {
                        return fXmlNodeStart;
                    }
                }

                // --

                return FSearchNode.searchLogNode(fXmlNodeStart, fXmlNodeBase, fXmlNodeRoot, searchWord);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                FSearchNode.resetResource();
            }
            return null;
        }
                
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
