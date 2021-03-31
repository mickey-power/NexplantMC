/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTcpDriverLogCommon.cs
--  Creator         : spike.lee
--  Create Date     : 2011.09.06
--  Description     : FAMate Core FaTcpDriver TCP Driver Log Common Class 
--  History         : Created by spike.lee at 2011.09.06
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    internal static class FTcpDriverLogCommon
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
                fXmlNode.set_attrVal(FXmlTagFAM.A_FileFormat, FXmlTagFAM.D_FileFormat, "TSL");
                fXmlNode.set_attrVal(FXmlTagFAM.A_FileVersion, FXmlTagFAM.D_FileVersion, "4.5.2.1");
                fXmlNode.set_attrVal(FXmlTagFAM.A_FileCreationTime, FXmlTagFAM.D_FileCreationTime, dateTime);
                fXmlNode.set_attrVal(FXmlTagFAM.A_FileUpdateTime, FXmlTagFAM.D_FileUpdateTime, dateTime);
                fXmlNode.set_attrVal(FXmlTagFAM.A_FileDescription, FXmlTagFAM.D_FileDescription, "FAmate TCP Log File");
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

        public static FXmlNode createXmlNodeTCDL(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagTCDL.E_TcpDriver);
                // --
                fXmlNode.set_attrVal(FXmlTagTCDL.A_UniqueId, FXmlTagTCDL.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagTCDL.A_Name, FXmlTagTCDL.D_Name, "TcpDriverLog");
                fXmlNode.set_attrVal(FXmlTagTCDL.A_Description, FXmlTagTCDL.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagTCDL.A_FontColor, FXmlTagTCDL.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagTCDL.A_FontBold, FXmlTagTCDL.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagTCDL.A_EapName, FXmlTagTCDL.D_EapName, "MC");
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

        public static FXmlNode createXmlNodeTDVL(
            FXmlNode fXmlNodeTdv,
            string logType
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlNodeTdv.clone(false);
                fXmlNode.set_attrVal(FXmlTagTDVL.A_LogType, FXmlTagTDVL.D_LogType, logType);
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

        public static FXmlNode createXmlNodeTDTL(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagTDTL.E_TcpDeviceTimeout);
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

        public static FXmlNode createXmlNodeTDEL(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagTDEL.E_TcpDeviceError);
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
                FTcpDriverCommon.validateName(name, true);

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
                FTcpDriverCommon.validateName(name, true);

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

        public static FXmlNode createXmlNodeXMLL(
            FXmlDocument fXmlDoc,
            string logType
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagXMLL.E_Xml);
                fXmlNode.set_attrVal(FXmlTagXMLL.A_LogType, FXmlTagXMLL.D_LogType, logType);
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

        public static FXmlNode createXmlNodeTMGL(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagTMGL.E_TcpMessage);
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

        public static FXmlNode createXmlNodeTITL(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagTITL.E_TcpItem);
                fXmlNode.set_attrVal(FXmlTagTITL.A_UniqueId, FXmlTagTITL.D_UniqueId, "0");
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
            FTcdlCore fTcdlCore,
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
                if (name == FXmlTagTCDL.E_TcpDriver)
                {
                    fObjectLog = new FTcpDriverLog(fTcdlCore, fXmlNode);
                }
                // --
                else if (name == FXmlTagTDVL.E_TcpDevice)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagTDVL.A_LogType, FXmlTagTDVL.D_LogType);
                    // --
                    if (logType == FXmlTagTDVL.L_StateChanged)
                    {
                        fObjectLog = new FTcpDeviceStateChangedLog(fTcdlCore, fXmlNode);
                    }
                    else if (logType == FXmlTagTDVL.L_DataReceived)
                    {
                        fObjectLog = new FTcpDeviceDataReceivedLog(fTcdlCore, fXmlNode); 
                    }
                    else if (logType == FXmlTagTDVL.L_DataSent)
                    {
                        fObjectLog = new FTcpDeviceDataSentLog(fTcdlCore, fXmlNode); 
                    }
                }
                else if (name == FXmlTagTDEL.E_TcpDeviceError)
                {
                    fObjectLog = new FTcpDeviceErrorRaisedLog(fTcdlCore, fXmlNode);
                }
                else if (name == FXmlTagTDTL.E_TcpDeviceTimeout)
                {
                    fObjectLog = new FTcpDeviceTimeoutRaisedLog(fTcdlCore, fXmlNode);
                }
                else if (name == FXmlTagXMLL.E_Xml)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagXMLL.A_LogType, FXmlTagXMLL.D_LogType);
                    // --
                    if (logType == FXmlTagXMLL.L_Received)
                    {
                        fObjectLog = new FTcpDeviceXmlReceivedLog(fTcdlCore, fXmlNode); 
                    }
                    else if (logType == FXmlTagXMLL.L_Sent)
                    {
                        fObjectLog = new FTcpDeviceXmlSentLog(fTcdlCore, fXmlNode); 
                    }
                }
                else if (name == FXmlTagTMGL.E_TcpMessage)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagTMGL.A_LogType, FXmlTagTMGL.D_LogType);
                    // --
                    if (logType == FXmlTagTMGL.L_Received)
                    {
                        fObjectLog = new FTcpDeviceDataMessageReceivedLog(fTcdlCore, fXmlNode);
                    }
                    else if (logType == FXmlTagTMGL.L_Sent)
                    {
                        fObjectLog = new FTcpDeviceDataMessageSentLog(fTcdlCore, fXmlNode);
                    }
                }
                else if (name == FXmlTagTITL.E_TcpItem)
                {
                    fObjectLog = new FTcpItemLog(fTcdlCore, fXmlNode);
                }
                // --
                else if (name == FXmlTagHDVL.E_HostDevice)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagHDVL.A_LogType, FXmlTagHDVL.D_LogType);
                    if (logType == FXmlTagHDVL.L_StateChanged)
                    {
                        fObjectLog = new FHostDeviceStateChangedLog(fTcdlCore, fXmlNode);
                    }
                }
                else if (name == FXmlTagHDEL.E_HostDeviceError)
                {
                    fObjectLog = new FHostDeviceErrorRaisedLog(fTcdlCore, fXmlNode);
                }
                else if (name == FXmlTagVFEL.E_Vfei)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagVFEL.A_LogType, FXmlTagVFEL.D_LogType);
                    if (logType == FXmlTagVFEL.L_Received)
                    {
                        fObjectLog = new FHostDeviceVfeiReceivedLog(fTcdlCore, fXmlNode);
                    }
                    else if (logType == FXmlTagVFEL.L_Sent)
                    {
                        fObjectLog = new FHostDeviceVfeiSentLog(fTcdlCore, fXmlNode);
                    }
                }
                else if (name == FXmlTagHMGL.E_HostMessage)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagHMGL.A_LogType, FXmlTagHMGL.D_LogType);
                    if (logType == FXmlTagHMGL.L_Received)
                    {
                        fObjectLog = new FHostDeviceDataMessageReceivedLog(fTcdlCore, fXmlNode);
                    }
                    else if (logType == FXmlTagHMGL.L_Sent)
                    {
                        fObjectLog = new FHostDeviceDataMessageSentLog(fTcdlCore, fXmlNode);
                    }
                }
                else if (name == FXmlTagHITL.E_HostItem)
                {
                    fObjectLog = new FHostItemLog(fTcdlCore, fXmlNode);
                }
                // --
                else if (name == FXmlTagTTRL.E_TcpTrigger)
                {
                    fObjectLog = new FTcpTriggerRaisedLog(fTcdlCore, fXmlNode);
                }
                else if (name == FXmlTagTTNL.E_TcpTransmitter)
                {
                    fObjectLog = new FTcpTransmitterRaisedLog(fTcdlCore, fXmlNode);
                }
                else if (name == FXmlTagHTRL.E_HostTrigger)
                {
                    fObjectLog = new FHostTriggerRaisedLog(fTcdlCore, fXmlNode);
                }
                else if (name == FXmlTagHTNL.E_HostTransmitter)
                {
                    fObjectLog = new FHostTransmitterRaisedLog(fTcdlCore, fXmlNode);
                }
                else if (name == FXmlTagJDML.E_Judgement)
                {
                    fObjectLog = new FJudgementPerformedLog(fTcdlCore, fXmlNode);
                }
                else if (name == FXmlTagMAPL.E_Mapper)
                {
                    fObjectLog = new FMapperPerformedLog(fTcdlCore, fXmlNode);
                }
                else if (name == FXmlTagESAL.E_EquipmentStateSetAlterer)
                {
                    fObjectLog = new FEquipmentStateSetAltererPerformedLog(fTcdlCore, fXmlNode);
                }
                else if (name == FXmlTagSTGL.E_Storage)
                {
                    fObjectLog = new FStoragePerformedLog(fTcdlCore, fXmlNode);
                }
                else if (name == FXmlTagRPSL.E_Repository)
                {
                    fObjectLog = new FRepositoryLog(fTcdlCore, fXmlNode);
                }
                else if (name == FXmlTagCOLL.E_Column)
                {
                    fObjectLog = new FColumnLog(fTcdlCore, fXmlNode);
                }
                else if (name == FXmlTagDTSL.E_DataSet)
                {
                    fObjectLog = new FDataSetLog(fTcdlCore, fXmlNode);
                }
                else if (name == FXmlTagDATL.E_Data)
                {
                    fObjectLog = new FDataLog(fTcdlCore, fXmlNode);
                }
                else if (name == FXmlTagCBKL.E_Callback)
                {
                    fObjectLog = new FCallbackRaisedLog(fTcdlCore, fXmlNode);
                }
                else if (name == FXmlTagFUNL.E_Function)
                {
                    fObjectLog = new FFunctionCalledLog(fTcdlCore, fXmlNode);
                }
                else if (name == FXmlTagBRNL.E_Branch)
                {
                    fObjectLog = new FBranchRaisedLog(fTcdlCore, fXmlNode);
                }
                else if (name == FXmlTagCMTL.E_Comment)
                {
                    fObjectLog = new FCommentWrittenLog(fTcdlCore, fXmlNode);
                }
                else if (name == FXmlTagPAUL.E_Pauser)
                {
                    fObjectLog = new FPauserRaisedLog(fTcdlCore, fXmlNode);
                }
                else if (name == FXmlTagETPL.E_EntryPoint)
                {
                    fObjectLog = new FEntryPointCalledLog(fTcdlCore, fXmlNode);
                }
                else if (name == FXmlTagAPPL.E_Application)
                {
                    fObjectLog = new FApplicationWrittenLog(fTcdlCore, fXmlNode);
                }
                else if (name == FXmlTagCTTL.E_Content)
                {
                    fObjectLog = new FContentLog(fTcdlCore, fXmlNode);
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
            FObjectLogType type = FObjectLogType.TcpDriverLog;
            string name = string.Empty;
            string logType = string.Empty;

            try
            {
                name = fXmlNode.name;

                // --

                if (name == FXmlTagTCDL.E_TcpDriver)
                {
                    type = FObjectLogType.TcpDriverLog;
                }
                else if (name == FXmlTagTDVL.E_TcpDevice)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagTDVL.A_LogType, FXmlTagTDVL.D_LogType);
                    // --
                    if (logType == FXmlTagTDVL.L_StateChanged)
                    {
                        type = FObjectLogType.TcpDeviceStateChangedLog;
                    }
                    else if (logType == FXmlTagTDVL.L_DataReceived)
                    {
                        type = FObjectLogType.TcpDeviceDataReceivedLog;
                    }
                    else if (logType == FXmlTagTDVL.L_DataSent)
                    {
                        type = FObjectLogType.TcpDeviceDataSentLog;
                    }
                }
                else if (name == FXmlTagTDTL.E_TcpDeviceTimeout)
                {
                    type = FObjectLogType.TcpDeviceTimeoutRaisedLog;
                }
                else if (name == FXmlTagTDEL.E_TcpDeviceError)
                {
                    type = FObjectLogType.TcpDeviceErrorRaisedLog;
                }
                else if (name == FXmlTagXMLL.E_Xml)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagXMLL.A_LogType, FXmlTagXMLL.D_LogType);
                    if (logType == FXmlTagXMLL.L_Received)
                    {
                        type = FObjectLogType.TcpDeviceXmlReceivedLog;
                    }
                    else if (logType == FXmlTagXMLL.L_Sent)
                    {
                        type = FObjectLogType.TcpDeviceXmlSentLog; 
                    }
                }
                else if (name == FXmlTagTMGL.E_TcpMessage)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagTMGL.A_LogType, FXmlTagTMGL.D_LogType);
                    if (logType == FXmlTagTMGL.L_Received)
                    {
                        type = FObjectLogType.TcpDeviceDataMessageReceivedLog;
                    }
                    else if (logType == FXmlTagTMGL.L_Sent)
                    {
                        type = FObjectLogType.TcpDeviceDataMessageSentLog;
                    }
                }
                else if (name == FXmlTagTITL.E_TcpItem)
                {
                    type = FObjectLogType.TcpItemLog;
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
                else if (name == FXmlTagTTRL.E_TcpTrigger)
                {
                    type = FObjectLogType.TcpTriggerRaisedLog;
                }
                else if (name == FXmlTagTTNL.E_TcpTransmitter)
                {
                    type = FObjectLogType.TcpTransmitterRaisedLog;
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
            return FObjectLogType.TcpDriverLog;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode getObjectLogXmlNode(
            FIObjectLog fObjectLog
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                if (fObjectLog.fObjectLogType == FObjectLogType.TcpDriverLog)
                {
                    fXmlNode = ((FTcpDriverLog)fObjectLog).fXmlNode;
                }
                // --
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceStateChangedLog)
                {
                    fXmlNode = ((FTcpDeviceStateChangedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataReceivedLog)
                {
                    fXmlNode = ((FTcpDeviceXmlReceivedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataSentLog)
                {
                    fXmlNode = ((FTcpDeviceXmlSentLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceErrorRaisedLog)
                {
                    fXmlNode = ((FTcpDeviceErrorRaisedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceTimeoutRaisedLog)
                {
                    fXmlNode = ((FTcpDeviceTimeoutRaisedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceXmlReceivedLog)
                {
                    fXmlNode = ((FTcpDeviceDataReceivedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceXmlSentLog)
                {
                    fXmlNode = ((FTcpDeviceDataSentLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog)
                {
                    fXmlNode = ((FTcpDeviceDataMessageReceivedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog)
                {
                    fXmlNode = ((FTcpDeviceDataMessageSentLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpItemLog)
                {
                    fXmlNode = ((FTcpItemLog)fObjectLog).fXmlNode;
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
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpTriggerRaisedLog)
                {
                    fXmlNode = ((FTcpTriggerRaisedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpTransmitterRaisedLog)
                {
                    fXmlNode = ((FTcpTransmitterRaisedLog)fObjectLog).fXmlNode;
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
