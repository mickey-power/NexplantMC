/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : i_FSecsDriverLogCommon.cs
--  Creator         : spike.lee
--  Create Date     : 2011.09.06
--  Description     : FAMate Core FaSecsDriver  Interface
--  History         : Created by spike.lee at 2011.09.06
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal static class FPlcDriverLogCommon
    {

        //------------------------------------------------------------------------------------------------------------------------        

        #region Methods

        public static FXmlNode createXmlNodeFAM(
            FXmlDocument fXmlDoc
            )
        {
            string dateTime = string.Empty;
            FXmlNode fXmlNode = null;

            try
            {
                dateTime = FDataConvert.defaultNowDateTimeToString();
                // --
                fXmlNode = fXmlDoc.createNode(FXmlTagFAM.E_FAMate);
                // --
                fXmlNode.set_attrVal(FXmlTagFAM.A_FileFormat, FXmlTagFAM.D_FileFormat, "PSL");
                fXmlNode.set_attrVal(FXmlTagFAM.A_FileVersion, FXmlTagFAM.D_FileVersion, "4.1.0.1");
                fXmlNode.set_attrVal(FXmlTagFAM.A_FileCreationTime, FXmlTagFAM.D_FileCreationTime, dateTime);
                fXmlNode.set_attrVal(FXmlTagFAM.A_FileUpdateTime, FXmlTagFAM.D_FileUpdateTime, dateTime);
                fXmlNode.set_attrVal(FXmlTagFAM.A_FileDescription, FXmlTagFAM.D_FileDescription, "FAMate PLC Log File");
                // --
                return fXmlNode;
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

        public static FXmlNode createXmlNodePCDL(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagPCDL.E_PlcDriver);
                // --
                fXmlNode.set_attrVal(FXmlTagPCDL.A_UniqueId, FXmlTagPCDL.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagPCDL.A_Name, FXmlTagPCDL.D_Name, "PlcDriverLog");
                fXmlNode.set_attrVal(FXmlTagPCDL.A_Description, FXmlTagPCDL.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagPCDL.A_FontColor, FXmlTagPCDL.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagPCDL.A_FontBold, FXmlTagPCDL.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagPCDL.A_EapName, FXmlTagPCDL.D_EapName, "EAP");
                // --
                return fXmlNode;
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

        public static FXmlNode createXmlNodePDVL(
            FXmlNode fXmlNodePdv,
            string logType
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlNodePdv.clone(false);
                fXmlNode.set_attrVal(FXmlTagPDVL.A_LogType, FXmlTagPDVL.D_LogType, logType);
                // --
                return fXmlNode;
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

        public static FXmlNode createXmlNodePDTL(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagPDTL.E_PlcDeviceTimeout);
                // --
                return fXmlNode;
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

        public static FXmlNode createXmlNodePDEL(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagPDEL.E_PlcDeviceError);
                // --

                // --
                return fXmlNode;
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

        public static FXmlNode createXmlNodeHDVL(
            FXmlNode fXmlNodeHdv,
            string logType
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlNodeHdv.clone(false);
                fXmlNode.set_attrVal(FXmlTagHDVL.A_LogType, FXmlTagHDVL.D_LogType, logType);
                // --
                return fXmlNode;
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

        public static FXmlNode createXmlNodeHDEL(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagHDEL.E_HostDeviceError);
                // --
                return fXmlNode;
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

        public static FXmlNode createXmlNodeVEFL(
            FXmlDocument fXmlDoc,
            string logType
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagVFEL.E_Vfei);
                fXmlNode.set_attrVal(FXmlTagVFEL.A_LogType, FXmlTagVFEL.D_LogType, logType);
                // --
                return fXmlNode;
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

        public static FXmlNode createXmlNodeHMGL(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagHMGL.E_HostMessage);
                // --
                return fXmlNode;
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

        public static FXmlNode createXmlNodeHITL(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagHITL.E_HostItem);
                fXmlNode.set_attrVal(FXmlTagHITL.A_UniqueId, FXmlTagHITL.D_UniqueId, "0");
                // --
                return fXmlNode;
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

        public static FXmlNode createXmlNodeAPPL(
            FXmlDocument fXmlDoc
            )
        {
            try
            {
                return createXmlNodeAPPL(fXmlDoc, "Application");
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

        public static FXmlNode createXmlNodeAPPL(
            FXmlDocument fXmlDoc,
            string name
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                FPlcDriverCommon.validateName(name, true);

                // --

                fXmlNode = fXmlDoc.createNode(FXmlTagAPPL.E_Application);
                // --
                fXmlNode.set_attrVal(FXmlTagAPPL.A_UniqueId, FXmlTagAPPL.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagAPPL.A_Name, FXmlTagAPPL.D_Name, name);
                fXmlNode.set_attrVal(FXmlTagAPPL.A_Description, FXmlTagAPPL.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagAPPL.A_FontColor, FXmlTagAPPL.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagAPPL.A_FontBold, FXmlTagAPPL.D_FontBold, FBoolean.False);
                // --
                return fXmlNode;
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

        public static FXmlNode createXmlNodeCTTL(
            FXmlDocument fXmlDoc
            )
        {
            try
            {
                return createXmlNodeCTTL(fXmlDoc, "Content", FFormat.List, string.Empty);
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

        public static FXmlNode createXmlNodeCTTL(
            FXmlDocument fXmlDoc,
            string name,
            FFormat fFormat,
            string stringValue
            )
        {
            FXmlNode fXmlNode = null;
            int length = 0;
            string val = string.Empty;

            try
            {
                FPlcDriverCommon.validateName(name, true);

                // --

                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                {
                    length = 0;
                    val = string.Empty;
                }
                else
                {
                    val = FValueConverter.fromStringValue(fFormat, stringValue, out length);
                }

                // --

                fXmlNode = fXmlDoc.createNode(FXmlTagCTTL.E_Content);
                // --
                fXmlNode.set_attrVal(FXmlTagCTTL.A_UniqueId, FXmlTagCTTL.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagCTTL.A_Name, FXmlTagCTTL.D_Name, name);
                fXmlNode.set_attrVal(FXmlTagCTTL.A_Description, FXmlTagCTTL.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagCTTL.A_FontColor, FXmlTagCTTL.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagCTTL.A_FontBold, FXmlTagCTTL.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagCTTL.A_Format, FXmlTagCTTL.D_Format, FEnumConverter.fromFormat(fFormat));
                // --
                fXmlNode.set_attrVal(FXmlTagCTTL.A_Value, FXmlTagCTTL.D_Value, val);
                fXmlNode.set_attrVal(FXmlTagCTTL.A_Length, FXmlTagCTTL.D_Length, length.ToString());
                // --
                return fXmlNode;
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

        public static FIObjectLog createObjectLog(
            FPcdlCore fPcdlCore,
            FXmlNode fXmlNode
            )
        {
            FIObjectLog fObjectLog = null;
            string name = string.Empty;
            string logType = string.Empty;

            try
            {
                name = fXmlNode.name;

                // --
                if (name == FXmlTagPCDL.E_PlcDriver)
                {
                    fObjectLog = new FPlcDriverLog(fPcdlCore, fXmlNode);
                }
                // --
                else if (name == FXmlTagPDVL.E_PlcDevice)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagPDVL.A_LogType, FXmlTagPDVL.D_LogType);
                    // --
                    if (logType == FXmlTagPDVL.L_StateChanged)
                    {
                        fObjectLog = new FPlcDeviceStateChangedLog(fPcdlCore, fXmlNode);
                    }
                    else if (logType == FXmlTagPDVL.L_DataReceived)
                    {
                        fObjectLog = new FPlcDeviceDataReceivedLog(fPcdlCore, fXmlNode);
                    }
                    else if (logType == FXmlTagPDVL.L_DataSent)
                    {
                        fObjectLog = new FPlcDeviceDataSentLog(fPcdlCore, fXmlNode);
                    }
                }
                else if (name == FXmlTagPDEL.E_PlcDeviceError)
                {
                    fObjectLog = new FPlcDeviceErrorRaisedLog(fPcdlCore, fXmlNode);
                }
                else if (name == FXmlTagPDTL.E_PlcDeviceTimeout)
                {
                    fObjectLog = new FPlcDeviceTimeoutRaisedLog(fPcdlCore, fXmlNode);
                }
                else if (name == FXmlTagPMGL.E_PlcMessage)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagPMGL.A_LogType, FXmlTagPMGL.D_LogType);
                    // --
                    if (logType == FXmlTagPMGL.L_Read)
                    {
                        fObjectLog = new FPlcDeviceDataMessageReadLog(fPcdlCore, fXmlNode);
                    }
                    else if (logType == FXmlTagPMGL.L_Written)
                    {
                        fObjectLog = new FPlcDeviceDataMessageWrittenLog(fPcdlCore, fXmlNode);
                    }
                }
                else if (name == FXmlTagPBLL.E_PlcBitList)
                {
                    fObjectLog = new FPlcBitListLog(fPcdlCore, fXmlNode);
                }
                else if (name == FXmlTagPBTL.E_PlcBit)
                {
                    fObjectLog = new FPlcBitLog(fPcdlCore, fXmlNode);
                }
                else if (name == FXmlTagPWLL.E_PlcWordList)
                {
                    fObjectLog = new FPlcWordListLog(fPcdlCore, fXmlNode);
                }
                else if (name == FXmlTagPWDL.E_PlcWord)
                {
                    fObjectLog = new FPlcWordLog(fPcdlCore, fXmlNode);
                }
                // --
                else if (name == FXmlTagHDVL.E_HostDevice)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagHDVL.A_LogType, FXmlTagHDVL.D_LogType);
                    if (logType == FXmlTagHDVL.L_StateChanged)
                    {
                        fObjectLog = new FHostDeviceStateChangedLog(fPcdlCore, fXmlNode);
                    }
                }
                else if (name == FXmlTagHDEL.E_HostDeviceError)
                {
                    fObjectLog = new FHostDeviceErrorRaisedLog(fPcdlCore, fXmlNode);
                }
                else if (name == FXmlTagVFEL.E_Vfei)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagVFEL.A_LogType, FXmlTagVFEL.D_LogType);
                    if (logType == FXmlTagVFEL.L_Received)
                    {
                        fObjectLog = new FHostDeviceVfeiReceivedLog(fPcdlCore, fXmlNode);
                    }
                    else if (logType == FXmlTagVFEL.L_Sent)
                    {
                        fObjectLog = new FHostDeviceVfeiSentLog(fPcdlCore, fXmlNode);
                    }
                }
                else if (name == FXmlTagHMGL.E_HostMessage)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagHMGL.A_LogType, FXmlTagHMGL.D_LogType);
                    if (logType == FXmlTagHMGL.L_Received)
                    {
                        fObjectLog = new FHostDeviceDataMessageReceivedLog(fPcdlCore, fXmlNode);
                    }
                    else if (logType == FXmlTagHMGL.L_Sent)
                    {
                        fObjectLog = new FHostDeviceDataMessageSentLog(fPcdlCore, fXmlNode);
                    }
                }
                else if (name == FXmlTagHITL.E_HostItem)
                {
                    fObjectLog = new FHostItemLog(fPcdlCore, fXmlNode);
                }
                // --
                else if (name == FXmlTagPTRL.E_PlcTrigger)
                {
                    fObjectLog = new FPlcTriggerRaisedLog(fPcdlCore, fXmlNode);
                }
                else if (name == FXmlTagPTNL.E_PlcTransmitter)
                {
                    fObjectLog = new FPlcTransmitterRaisedLog(fPcdlCore, fXmlNode);
                }
                else if (name == FXmlTagHTRL.E_HostTrigger)
                {
                    fObjectLog = new FHostTriggerRaisedLog(fPcdlCore, fXmlNode);
                }
                else if (name == FXmlTagHTNL.E_HostTransmitter)
                {
                    fObjectLog = new FHostTransmitterRaisedLog(fPcdlCore, fXmlNode);
                }
                else if (name == FXmlTagJDML.E_Judgement)
                {
                    fObjectLog = new FJudgementPerformedLog(fPcdlCore, fXmlNode);
                }
                else if (name == FXmlTagMAPL.E_Mapper)
                {
                    fObjectLog = new FMapperPerformedLog(fPcdlCore, fXmlNode);
                }
                else if (name == FXmlTagESAL.E_EquipmentStateSetAlterer)
                {
                    fObjectLog = new FEquipmentStateSetAltererPerformedLog(fPcdlCore, fXmlNode);
                }
                else if (name == FXmlTagSTGL.E_Storage)
                {
                    fObjectLog = new FStoragePerformedLog(fPcdlCore, fXmlNode);
                }
                else if (name == FXmlTagRPSL.E_Repository)
                {
                    fObjectLog = new FRepositoryLog(fPcdlCore, fXmlNode);
                }
                else if (name == FXmlTagCOLL.E_Column)
                {
                    fObjectLog = new FColumnLog(fPcdlCore, fXmlNode);
                }
                else if (name == FXmlTagDTSL.E_DataSet)
                {
                    fObjectLog = new FDataSetLog(fPcdlCore, fXmlNode);
                }
                else if (name == FXmlTagDATL.E_Data)
                {
                    fObjectLog = new FDataLog(fPcdlCore, fXmlNode);
                }
                else if (name == FXmlTagCBKL.E_Callback)
                {
                    fObjectLog = new FCallbackRaisedLog(fPcdlCore, fXmlNode);
                }
                else if (name == FXmlTagFUNL.E_Function)
                {
                    fObjectLog = new FFunctionCalledLog(fPcdlCore, fXmlNode);
                }
                else if (name == FXmlTagBRNL.E_Branch)
                {
                    fObjectLog = new FBranchRaisedLog(fPcdlCore, fXmlNode);
                }
                else if (name == FXmlTagCMTL.E_Comment)
                {
                    fObjectLog = new FCommentWrittenLog(fPcdlCore, fXmlNode);
                }
                else if (name == FXmlTagPAUL.E_Pauser)
                {
                    fObjectLog = new FPauserRaisedLog(fPcdlCore, fXmlNode);
                }
                else if (name == FXmlTagETPL.E_EntryPoint)
                {
                    fObjectLog = new FEntryPointCalledLog(fPcdlCore, fXmlNode);
                }
                else if (name == FXmlTagAPPL.E_Application)
                {
                    fObjectLog = new FApplicationWrittenLog(fPcdlCore, fXmlNode);
                }
                else if (name == FXmlTagCTTL.E_Content)
                {
                    fObjectLog = new FContentLog(fPcdlCore, fXmlNode);
                }

                // --

                return fObjectLog;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fObjectLog = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FObjectLogType getObjectLogType(
            FXmlNode fXmlNode
            )
        {
            FObjectLogType type = FObjectLogType.PlcDriverLog;
            string name = string.Empty;
            string logType = string.Empty;

            try
            {
                name = fXmlNode.name;

                // --

                if (name == FXmlTagPCDL.E_PlcDriver)
                {
                    type = FObjectLogType.PlcDriverLog;
                }
                else if (name == FXmlTagPDVL.E_PlcDevice)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagPDVL.A_LogType, FXmlTagPDVL.D_LogType);
                    // --
                    if (logType == FXmlTagPDVL.L_StateChanged)
                    {
                        type = FObjectLogType.PlcDeviceStateChangedLog;
                    }
                    else if (logType == FXmlTagPDVL.L_DataReceived)
                    {
                        type = FObjectLogType.PlcDeviceDataReceivedLog;
                    }
                    else if (logType == FXmlTagPDVL.L_DataSent)
                    {
                        type = FObjectLogType.PlcDeviceDataSentLog;
                    }
                }
                else if (name == FXmlTagPDTL.E_PlcDeviceTimeout)
                {
                    type = FObjectLogType.PlcDeviceTimeoutRaisedLog;
                }
                else if (name == FXmlTagPDEL.E_PlcDeviceError)
                {
                    type = FObjectLogType.PlcDeviceErrorRaisedLog;
                }    
                else if (name == FXmlTagPMGL.E_PlcMessage)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagPMGL.A_LogType, FXmlTagPMGL.D_LogType);
                    if (logType == FXmlTagPMGL.L_Read)
                    {
                        type = FObjectLogType.PlcDeviceDataMessageReadLog;
                    }
                    else if (logType == FXmlTagPMGL.L_Written)
                    {
                        type = FObjectLogType.PlcDeviceDataMessageWrittenLog;
                    }
                }
                else if (name == FXmlTagPBLL.E_PlcBitList)
                {
                    type = FObjectLogType.PlcBitListLog;
                }
                else if (name == FXmlTagPBTL.E_PlcBit)
                {
                    type = FObjectLogType.PlcBitLog;
                }
                else if (name == FXmlTagPWLL.E_PlcWordList)
                {
                    type = FObjectLogType.PlcWordListLog;
                }
                else if (name == FXmlTagPWDL.E_PlcWord)
                {
                    type = FObjectLogType.PlcWordLog;
                }
                // --
                else if (name == FXmlTagHDVL.E_HostDevice)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagHDVL.A_LogType, FXmlTagHDVL.D_LogType);
                    if (logType == FXmlTagHDVL.L_StateChanged)
                    {
                        type = FObjectLogType.HostDeviceStateChangedLog;
                    }
                }
                else if (name == FXmlTagVFEL.E_Vfei)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagVFEL.A_LogType, FXmlTagVFEL.D_LogType);
                    if (logType == FXmlTagVFEL.L_Received)
                    {
                        type = FObjectLogType.HostDeviceVfeiReceivedLog;
                    }
                    else if (logType == FXmlTagVFEL.L_Sent)
                    {
                        type = FObjectLogType.HostDeviceVfeiSentLog;
                    }
                }
                else if (name == FXmlTagHDEL.E_HostDeviceError)
                {
                    type = FObjectLogType.HostDeviceErrorRaisedLog;
                }
                else if (name == FXmlTagHMGL.E_HostMessage)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagHMGL.A_LogType, FXmlTagHMGL.D_LogType);
                    if (logType == FXmlTagHMGL.L_Received)
                    {
                        type = FObjectLogType.HostDeviceDataMessageReceivedLog;
                    }
                    else if (logType == FXmlTagHMGL.L_Sent)
                    {
                        type = FObjectLogType.HostDeviceDataMessageSentLog;
                    }
                }
                else if (name == FXmlTagHITL.E_HostItem)
                {
                    type = FObjectLogType.HostItemLog;
                }
                // --
                else if (name == FXmlTagPTRL.E_PlcTrigger)
                {
                    type = FObjectLogType.PlcTriggerRaisedLog;
                }
                else if (name == FXmlTagPTNL.E_PlcTransmitter)
                {
                    type = FObjectLogType.PlcTransmitterRaisedLog;
                }
                else if (name == FXmlTagHTRL.E_HostTrigger)
                {
                    type = FObjectLogType.HostTriggerRaisedLog;
                }
                else if (name == FXmlTagHTNL.E_HostTransmitter)
                {
                    type = FObjectLogType.HostTransmitterRaisedLog;
                }
                else if (name == FXmlTagJDML.E_Judgement)
                {
                    type = FObjectLogType.JudgementPerformedLog;
                }
                else if (name == FXmlTagMAPL.E_Mapper)
                {
                    type = FObjectLogType.MapperPerformedLog;
                }
                else if (name == FXmlTagSTGL.E_Storage)
                {
                    type = FObjectLogType.StoragePerformedLog;
                }
                else if (name == FXmlTagDTSL.E_DataSet)
                {
                    type = FObjectLogType.DataSetLog;
                }
                else if (name == FXmlTagDATL.E_Data)
                {
                    type = FObjectLogType.DataLog;
                }
                else if (name == FXmlTagRPSL.E_Repository)
                {
                    type = FObjectLogType.RepositoryLog;
                }
                else if (name == FXmlTagCOLL.E_Column)
                {
                    type = FObjectLogType.ColumnLog;
                }
                else if (name == FXmlTagCBKL.E_Callback)
                {
                    type = FObjectLogType.CallbackRaisedLog;
                }
                else if (name == FXmlTagFUNL.E_Function)
                {
                    type = FObjectLogType.FunctionCalledLog;
                }
                else if (name == FXmlTagBRNL.E_Branch)
                {
                    type = FObjectLogType.BranchRaisedLog;
                }
                else if (name == FXmlTagCMTL.E_Comment)
                {
                    type = FObjectLogType.CommentWrittenLog;
                }
                else if (name == FXmlTagPAUL.E_Pauser)
                {
                    type = FObjectLogType.PauserRaisedLog;
                }
                else if (name == FXmlTagETPL.E_EntryPoint)
                {
                    type = FObjectLogType.EntryPointCalledLog;
                }
                else if (name == FXmlTagAPPL.E_Application)
                {
                    type = FObjectLogType.ApplicationWrittenLog;
                }
                else if (name == FXmlTagCTTL.E_Content)
                {
                    type = FObjectLogType.ContentLog;
                }                
                                               
                // --

                return type;
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

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode getObjectLogXmlNode(
            FIObjectLog fObjectLog
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                if (fObjectLog.fObjectLogType == FObjectLogType.PlcDriverLog)
                {
                    fXmlNode = ((FPlcDriverLog)fObjectLog).fXmlNode;
                }
                // --
                else if (fObjectLog.fObjectLogType == FObjectLogType.PlcDeviceStateChangedLog)
                {
                    fXmlNode = ((FPlcDeviceStateChangedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PlcDeviceErrorRaisedLog)
                {
                    fXmlNode = ((FPlcDeviceErrorRaisedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PlcDeviceTimeoutRaisedLog)
                {
                    fXmlNode = ((FPlcDeviceTimeoutRaisedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PlcDeviceDataReceivedLog)
                {
                    fXmlNode = ((FPlcDeviceDataReceivedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PlcDeviceDataSentLog)
                {
                    fXmlNode = ((FPlcDeviceDataSentLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PlcDeviceDataMessageReadLog)
                {
                    fXmlNode = ((FPlcDeviceDataMessageReadLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PlcDeviceDataMessageWrittenLog)
                {
                    fXmlNode = ((FPlcDeviceDataMessageWrittenLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PlcBitListLog)
                {
                    fXmlNode = ((FPlcBitListLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PlcBitLog)
                {
                    fXmlNode = ((FPlcBitLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PlcWordListLog)
                {
                    fXmlNode = ((FPlcWordListLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PlcWordLog)
                {
                    fXmlNode = ((FPlcWordLog)fObjectLog).fXmlNode;
                }
                // --
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceStateChangedLog)
                {
                    fXmlNode = ((FHostDeviceStateChangedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceErrorRaisedLog)
                {
                    fXmlNode = ((FHostDeviceErrorRaisedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceVfeiReceivedLog)
                {
                    fXmlNode = ((FHostDeviceVfeiReceivedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceVfeiSentLog)
                {
                    fXmlNode = ((FHostDeviceVfeiSentLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                {
                    fXmlNode = ((FHostDeviceDataMessageReceivedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                {
                    fXmlNode = ((FHostDeviceDataMessageSentLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostItemLog)
                {
                    fXmlNode = ((FHostItemLog)fObjectLog).fXmlNode;
                }
                // -- 
                else if (fObjectLog.fObjectLogType == FObjectLogType.PlcTriggerRaisedLog)
                {
                    fXmlNode = ((FPlcTriggerRaisedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PlcTransmitterRaisedLog)
                {
                    fXmlNode = ((FPlcTransmitterRaisedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTriggerRaisedLog)
                {
                    fXmlNode = ((FHostTriggerRaisedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTransmitterRaisedLog)
                {
                    fXmlNode = ((FHostTransmitterRaisedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.JudgementPerformedLog)
                {
                    fXmlNode = ((FJudgementPerformedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.MapperPerformedLog)
                {
                    fXmlNode = ((FMapperPerformedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EquipmentStateSetAltererPerformedLog)
                {
                    fXmlNode = ((FEquipmentStateSetAltererPerformedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.DataSetLog)
                {
                    fXmlNode = ((FDataSetLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.DataLog)
                {
                    fXmlNode = ((FDataLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.StoragePerformedLog)
                {
                    fXmlNode = ((FStoragePerformedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.RepositoryLog)
                {
                    fXmlNode = ((FRepositoryLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.ColumnLog)
                {
                    fXmlNode = ((FColumnLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CallbackRaisedLog)
                {
                    fXmlNode = ((FCallbackRaisedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.FunctionCalledLog)
                {
                    fXmlNode = ((FFunctionCalledLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.BranchRaisedLog)
                {
                    fXmlNode = ((FBranchRaisedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CommentWrittenLog)
                {
                    fXmlNode = ((FCommentWrittenLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PauserRaisedLog)
                {
                    fXmlNode = ((FPauserRaisedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EntryPointCalledLog)
                {
                    fXmlNode = ((FEntryPointCalledLog)fObjectLog).fXmlNode;
                }
                // --
                else if (fObjectLog.fObjectLogType == FObjectLogType.ApplicationWrittenLog)
                {
                    fXmlNode = ((FApplicationWrittenLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.ContentLog)
                {
                    fXmlNode = ((FContentLog)fObjectLog).fXmlNode;
                }

                // --

                return fXmlNode;
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

        public static void resetLogUniqueId(
            FIDPointer64 fIdPointer,
            FXmlNode fXmlNode
            )
        {
            FXmlNodeList fXmlNodeList = null;

            try
            {
                fXmlNodeList = fXmlNode.selectNodes(". | .//*");
                // --
                foreach (FXmlNode n in fXmlNodeList)
                {
                    n.set_attrVal(FXmlTagCommon.A_LogUniqueId, FXmlTagCommon.D_LogUniqueId, fIdPointer.uniqueId.ToString());
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeList != null)
                {
                    fXmlNodeList.Dispose();
                    fXmlNodeList = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void removeLogUniqueId(
            FXmlNode fXmlNode
            )
        {
            FXmlNodeList fXmlNodeList = null;
            string xpath = string.Empty;

            try
            {
                xpath = ". | .//*[@" + FXmlTagCommon.A_LogUniqueId + "]";
                fXmlNodeList = fXmlNode.selectNodes(xpath);
                // -- 
                foreach (FXmlNode n in fXmlNodeList)
                {
                    n.set_attrVal(FXmlTagCommon.A_LogUniqueId, FXmlTagCommon.D_LogUniqueId, FXmlTagCommon.D_LogUniqueId);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeList != null)
                {
                    fXmlNodeList.Dispose();
                    fXmlNodeList = null;
                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Interface end
}   // Namespace end
