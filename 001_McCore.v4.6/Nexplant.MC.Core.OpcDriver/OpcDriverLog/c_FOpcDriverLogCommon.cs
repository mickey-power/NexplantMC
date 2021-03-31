/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : i_FSecsDriverLogCommon.cs
--  Creator         : spike.lee
--  Create Date     : 2011.09.06
--  Description     : FAMate Core FaOpcDriver  Interface
--  History         : Created by spike.lee at 2011.09.06
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    internal static class FOpcDriverLogCommon
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
                fXmlNode.set_attrVal(FXmlTagFAM.A_FileFormat, FXmlTagFAM.D_FileFormat, "OSL");
                fXmlNode.set_attrVal(FXmlTagFAM.A_FileVersion, FXmlTagFAM.D_FileVersion, "4.1.0.1");
                fXmlNode.set_attrVal(FXmlTagFAM.A_FileCreationTime, FXmlTagFAM.D_FileCreationTime, dateTime);
                fXmlNode.set_attrVal(FXmlTagFAM.A_FileUpdateTime, FXmlTagFAM.D_FileUpdateTime, dateTime);
                fXmlNode.set_attrVal(FXmlTagFAM.A_FileDescription, FXmlTagFAM.D_FileDescription, "FAMate OPC Log File");
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

        public static FXmlNode createXmlNodeOCDL(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagOCDL.E_OpcDriver);
                // --
                fXmlNode.set_attrVal(FXmlTagOCDL.A_UniqueId, FXmlTagOCDL.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagOCDL.A_Name, FXmlTagOCDL.D_Name, "OpcDriverLog");
                fXmlNode.set_attrVal(FXmlTagOCDL.A_Description, FXmlTagOCDL.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagOCDL.A_FontColor, FXmlTagOCDL.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagOCDL.A_FontBold, FXmlTagOCDL.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagOCDL.A_EapName, FXmlTagOCDL.D_EapName, "EAP");
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

        public static FXmlNode createXmlNodeODVL(
            FXmlNode fXmlNodeOdv,
            string logType
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlNodeOdv.clone(false);
                fXmlNode.set_attrVal(FXmlTagODVL.A_LogType, FXmlTagODVL.D_LogType, logType);
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

        public static FXmlNode createXmlNodeODTL(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagODTL.E_OpcDeviceTimeout);
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

        public static FXmlNode createXmlNodeODEL(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagODEL.E_OpcDeviceError);
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
                FOpcDriverCommon.validateName(name, true);

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
                FOpcDriverCommon.validateName(name, true);

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
            FOcdlCore fOcdlCore,
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
                if (name == FXmlTagOCDL.E_OpcDriver)
                {
                    fObjectLog = new FOpcDriverLog(fOcdlCore, fXmlNode);
                }
                // --
                else if (name == FXmlTagODVL.E_OpcDevice)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagODVL.A_LogType, FXmlTagODVL.D_LogType);
                    // --
                    if (logType == FXmlTagODVL.L_StateChanged)
                    {
                        fObjectLog = new FOpcDeviceStateChangedLog(fOcdlCore, fXmlNode);
                    }                    
                }
                else if (name == FXmlTagODEL.E_OpcDeviceError)
                {
                    fObjectLog = new FOpcDeviceErrorRaisedLog(fOcdlCore, fXmlNode);
                }
                else if (name == FXmlTagODTL.E_OpcDeviceTimeout)
                {
                    fObjectLog = new FOpcDeviceTimeoutRaisedLog(fOcdlCore, fXmlNode);
                }
                else if (name == FXmlTagOMGL.E_OpcMessage)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagOMGL.A_LogType, FXmlTagOMGL.D_LogType);
                    // --
                    if (logType == FXmlTagOMGL.L_Read)
                    {
                        fObjectLog = new FOpcDeviceDataMessageReadLog(fOcdlCore, fXmlNode);
                    }
                    else if (logType == FXmlTagOMGL.L_Written)
                    {
                        fObjectLog = new FOpcDeviceDataMessageWrittenLog(fOcdlCore, fXmlNode);
                    }
                }
                else if (name == FXmlTagOELL.E_OpcEventItemList)
                {
                    fObjectLog = new FOpcEventItemListLog(fOcdlCore, fXmlNode);
                }
                else if (name == FXmlTagOEIL.E_OpcEventItem)
                {
                    fObjectLog = new FOpcEventItemLog(fOcdlCore, fXmlNode);
                }
                else if (name == FXmlTagOILL.E_OpcItemList)
                {
                    fObjectLog = new FOpcItemListLog(fOcdlCore, fXmlNode);
                }
                else if (name == FXmlTagOITL.E_OpcItem)
                {
                    fObjectLog = new FOpcItemLog(fOcdlCore, fXmlNode);
                }
                // --
                else if (name == FXmlTagHDVL.E_HostDevice)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagHDVL.A_LogType, FXmlTagHDVL.D_LogType);
                    if (logType == FXmlTagHDVL.L_StateChanged)
                    {
                        fObjectLog = new FHostDeviceStateChangedLog(fOcdlCore, fXmlNode);
                    }
                }
                else if (name == FXmlTagHDEL.E_HostDeviceError)
                {
                    fObjectLog = new FHostDeviceErrorRaisedLog(fOcdlCore, fXmlNode);
                }
                else if (name == FXmlTagVFEL.E_Vfei)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagVFEL.A_LogType, FXmlTagVFEL.D_LogType);
                    if (logType == FXmlTagVFEL.L_Received)
                    {
                        fObjectLog = new FHostDeviceVfeiReceivedLog(fOcdlCore, fXmlNode);
                    }
                    else if (logType == FXmlTagVFEL.L_Sent)
                    {
                        fObjectLog = new FHostDeviceVfeiSentLog(fOcdlCore, fXmlNode);
                    }
                }
                else if (name == FXmlTagHMGL.E_HostMessage)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagHMGL.A_LogType, FXmlTagHMGL.D_LogType);
                    if (logType == FXmlTagHMGL.L_Received)
                    {
                        fObjectLog = new FHostDeviceDataMessageReceivedLog(fOcdlCore, fXmlNode);
                    }
                    else if (logType == FXmlTagHMGL.L_Sent)
                    {
                        fObjectLog = new FHostDeviceDataMessageSentLog(fOcdlCore, fXmlNode);
                    }
                }
                else if (name == FXmlTagHITL.E_HostItem)
                {
                    fObjectLog = new FHostItemLog(fOcdlCore, fXmlNode);
                }
                // --
                else if (name == FXmlTagOTRL.E_OpcTrigger)
                {
                    fObjectLog = new FOpcTriggerRaisedLog(fOcdlCore, fXmlNode);
                }
                else if (name == FXmlTagOTNL.E_OpcTransmitter)
                {
                    fObjectLog = new FOpcTransmitterRaisedLog(fOcdlCore, fXmlNode);
                }
                else if (name == FXmlTagHTRL.E_HostTrigger)
                {
                    fObjectLog = new FHostTriggerRaisedLog(fOcdlCore, fXmlNode);
                }
                else if (name == FXmlTagHTNL.E_HostTransmitter)
                {
                    fObjectLog = new FHostTransmitterRaisedLog(fOcdlCore, fXmlNode);
                }
                else if (name == FXmlTagJDML.E_Judgement)
                {
                    fObjectLog = new FJudgementPerformedLog(fOcdlCore, fXmlNode);
                }
                else if (name == FXmlTagMAPL.E_Mapper)
                {
                    fObjectLog = new FMapperPerformedLog(fOcdlCore, fXmlNode);
                }
                else if (name == FXmlTagESAL.E_EquipmentStateSetAlterer)
                {
                    fObjectLog = new FEquipmentStateSetAltererPerformedLog(fOcdlCore, fXmlNode);
                }
                else if (name == FXmlTagSTGL.E_Storage)
                {
                    fObjectLog = new FStoragePerformedLog(fOcdlCore, fXmlNode);
                }
                else if (name == FXmlTagRPSL.E_Repository)
                {
                    fObjectLog = new FRepositoryLog(fOcdlCore, fXmlNode);
                }
                else if (name == FXmlTagCOLL.E_Column)
                {
                    fObjectLog = new FColumnLog(fOcdlCore, fXmlNode);
                }
                else if (name == FXmlTagDTSL.E_DataSet)
                {
                    fObjectLog = new FDataSetLog(fOcdlCore, fXmlNode);
                }
                else if (name == FXmlTagDATL.E_Data)
                {
                    fObjectLog = new FDataLog(fOcdlCore, fXmlNode);
                }
                else if (name == FXmlTagCBKL.E_Callback)
                {
                    fObjectLog = new FCallbackRaisedLog(fOcdlCore, fXmlNode);
                }
                else if (name == FXmlTagFUNL.E_Function)
                {
                    fObjectLog = new FFunctionCalledLog(fOcdlCore, fXmlNode);
                }
                else if (name == FXmlTagBRNL.E_Branch)
                {
                    fObjectLog = new FBranchRaisedLog(fOcdlCore, fXmlNode);
                }
                else if (name == FXmlTagCMTL.E_Comment)
                {
                    fObjectLog = new FCommentWrittenLog(fOcdlCore, fXmlNode);
                }
                else if (name == FXmlTagPAUL.E_Pauser)
                {
                    fObjectLog = new FPauserRaisedLog(fOcdlCore, fXmlNode);
                }
                else if (name == FXmlTagETPL.E_EntryPoint)
                {
                    fObjectLog = new FEntryPointCalledLog(fOcdlCore, fXmlNode);
                }
                else if (name == FXmlTagAPPL.E_Application)
                {
                    fObjectLog = new FApplicationWrittenLog(fOcdlCore, fXmlNode);
                }
                else if (name == FXmlTagCTTL.E_Content)
                {
                    fObjectLog = new FContentLog(fOcdlCore, fXmlNode);
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
            FObjectLogType type = FObjectLogType.OpcDriverLog;
            string name = string.Empty;
            string logType = string.Empty;

            try
            {
                name = fXmlNode.name;

                // --

                if (name == FXmlTagOCDL.E_OpcDriver)
                {
                    type = FObjectLogType.OpcDriverLog;
                }
                else if (name == FXmlTagODVL.E_OpcDevice)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagODVL.A_LogType, FXmlTagODVL.D_LogType);
                    // --
                    if (logType == FXmlTagODVL.L_StateChanged)
                    {
                        type = FObjectLogType.OpcDeviceStateChangedLog;
                    }                    
                }
                else if (name == FXmlTagODTL.E_OpcDeviceTimeout)
                {
                    type = FObjectLogType.OpcDeviceTimeoutRaisedLog;
                }
                else if (name == FXmlTagODEL.E_OpcDeviceError)
                {
                    type = FObjectLogType.OpcDeviceErrorRaisedLog;
                }    
                else if (name == FXmlTagOMGL.E_OpcMessage)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagOMGL.A_LogType, FXmlTagOMGL.D_LogType);
                    if (logType == FXmlTagOMGL.L_Read)
                    {
                        type = FObjectLogType.OpcDeviceDataMessageReadLog;
                    }
                    else if (logType == FXmlTagOMGL.L_Written)
                    {
                        type = FObjectLogType.OpcDeviceDataMessageWrittenLog;
                    }
                }
                else if (name == FXmlTagOELL.E_OpcEventItemList)
                {
                    type = FObjectLogType.OpcEventItemListLog;
                }
                else if (name == FXmlTagOEIL.E_OpcEventItem)
                {
                    type = FObjectLogType.OpcEventItemLog;
                }
                else if (name == FXmlTagOILL.E_OpcItemList)
                {
                    type = FObjectLogType.OpcItemListLog;
                }
                else if (name == FXmlTagOITL.E_OpcItem)
                {
                    type = FObjectLogType.OpcItemLog;
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
                else if (name == FXmlTagOTRL.E_OpcTrigger)
                {
                    type = FObjectLogType.OpcTriggerRaisedLog;
                }
                else if (name == FXmlTagOTNL.E_OpcTransmitter)
                {
                    type = FObjectLogType.OpcTransmitterRaisedLog;
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
            return FObjectLogType.OpcDriverLog;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode getObjectLogXmlNode(
            FIObjectLog fObjectLog
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                if (fObjectLog.fObjectLogType == FObjectLogType.OpcDriverLog)
                {
                    fXmlNode = ((FOpcDriverLog)fObjectLog).fXmlNode;
                }
                // --
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceStateChangedLog)
                {
                    fXmlNode = ((FOpcDeviceStateChangedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceErrorRaisedLog)
                {
                    fXmlNode = ((FOpcDeviceErrorRaisedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceTimeoutRaisedLog)
                {
                    fXmlNode = ((FOpcDeviceTimeoutRaisedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageReadLog)
                {
                    fXmlNode = ((FOpcDeviceDataMessageReadLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageWrittenLog)
                {
                    fXmlNode = ((FOpcDeviceDataMessageWrittenLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcEventItemListLog)
                {
                    fXmlNode = ((FOpcEventItemListLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcEventItemLog)
                {
                    fXmlNode = ((FOpcEventItemLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcItemListLog)
                {
                    fXmlNode = ((FOpcItemListLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcItemLog)
                {
                    fXmlNode = ((FOpcItemLog)fObjectLog).fXmlNode;
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
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcTriggerRaisedLog)
                {
                    fXmlNode = ((FOpcTriggerRaisedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcTransmitterRaisedLog)
                {
                    fXmlNode = ((FOpcTransmitterRaisedLog)fObjectLog).fXmlNode;
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
