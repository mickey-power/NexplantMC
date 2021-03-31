/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecsDriverLogCommon.cs
--  Creator         : spike.lee
--  Create Date     : 2011.09.06
--  Description     : FAMate Core FaSecsDriver SECS Driver Log Common Interface
--  History         : Created by spike.lee at 2011.09.06
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal static class FSecsDriverLogCommon
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
                fXmlNode.set_attrVal(FXmlTagFAM.A_FileFormat, FXmlTagFAM.D_FileFormat, "SSL");
                fXmlNode.set_attrVal(FXmlTagFAM.A_FileVersion, FXmlTagFAM.D_FileVersion, "4.1.0.1");
                fXmlNode.set_attrVal(FXmlTagFAM.A_FileCreationTime, FXmlTagFAM.D_FileCreationTime, dateTime);
                fXmlNode.set_attrVal(FXmlTagFAM.A_FileUpdateTime, FXmlTagFAM.D_FileUpdateTime, dateTime);
                fXmlNode.set_attrVal(FXmlTagFAM.A_FileDescription, FXmlTagFAM.D_FileDescription, "FAMate SECS Log File");
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

        public static FXmlNode createXmlNodeSCDL(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagSCDL.E_SecsDriver);
                // --
                fXmlNode.set_attrVal(FXmlTagSCDL.A_UniqueId, FXmlTagSCDL.D_UniqueId, "0");
                fXmlNode.set_attrVal(FXmlTagSCDL.A_Name, FXmlTagSCDL.D_Name, "SecsDriverLog");
                fXmlNode.set_attrVal(FXmlTagSCDL.A_Description, FXmlTagSCDL.D_Description, string.Empty);
                // --
                fXmlNode.set_attrVal(FXmlTagSCDL.A_FontColor, FXmlTagSCDL.D_FontColor, Color.Black.Name);
                fXmlNode.set_attrVal(FXmlTagSCDL.A_FontBold, FXmlTagSCDL.D_FontBold, FBoolean.False);
                // --
                fXmlNode.set_attrVal(FXmlTagSCDL.A_EapName, FXmlTagSCDL.D_EapName, "MC");
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

        public static FXmlNode createXmlNodeSDVL(
            FXmlNode fXmlNodeSdv, 
            string logType
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlNodeSdv.clone(false);
                fXmlNode.set_attrVal(FXmlTagSDVL.A_LogType, FXmlTagSDVL.D_LogType, logType);                
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

        public static FXmlNode createXmlNodeCMGL(
            FXmlDocument fXmlDoc,
            string logType
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagCMGL.E_ControlMessage);
                fXmlNode.set_attrVal(FXmlTagCMGL.A_LogType, FXmlTagCMGL.D_LogType, logType);
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

        public static FXmlNode createXmlNodeSMLL(
            FXmlDocument fXmlDoc, 
            string logType
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagSMLL.E_Sml);
                fXmlNode.set_attrVal(FXmlTagSMLL.A_LogType, FXmlTagSMLL.D_LogType, logType);
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

        public static FXmlNode createXmlNodeSDTL(
            FXmlDocument fXmlDoc            
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagSDTL.E_SecsDeviceTimeout);
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

        public static FXmlNode createXmlNodeSDEL(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagSDEL.E_SecsDeviceError);
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

        public static FXmlNode createXmlNodeSMGL(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagSMGL.E_SecsMessage);
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

        public static FXmlNode createXmlNodeSITL(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagSITL.E_SecsItem);
                fXmlNode.set_attrVal(FXmlTagSITL.A_UniqueId, FXmlTagSITL.D_UniqueId, "0");
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

        public static FXmlNode createXmlNodeSDBL(
            FXmlDocument fXmlDoc,
            string logType
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagSDBL.E_SecsDeviceBlock);
                fXmlNode.set_attrVal(FXmlTagSDBL.A_LogType, FXmlTagSDBL.D_LogType, logType);
                // --
                return fXmlNode;
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

        public static FXmlNode createXmlNodeSDHL(
            FXmlDocument fXmlDoc,
            string logType
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagSDHL.E_SecsDeviceHandshake);
                fXmlNode.set_attrVal(FXmlTagSDHL.A_LogType, FXmlTagSDHL.D_LogType, logType);
                // --
                return fXmlNode;
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

        public static FXmlNode createXmlNodeSTPL(
            FXmlDocument fXmlDoc,
            string logType
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagSTPL.E_SecsDeviceTelnetPacket);
                fXmlNode.set_attrVal(FXmlTagSTPL.A_LogType, FXmlTagSTPL.D_LogType, logType);
                // -- 
                return fXmlNode;
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

        public static FXmlNode createXmlNodeSTSL(
            FXmlDocument fXmlDoc
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = fXmlDoc.createNode(FXmlTagSTSL.E_SecsDeviceTelnetStateChanged);
                // -- 
                return fXmlNode;
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
                FSecsDriverCommon.validateName(name, true);

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
                FSecsDriverCommon.validateName(name, true);

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
            FScdlCore fScdlCore,
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

                if (name == FXmlTagSCDL.E_SecsDriver)
                {
                    fObjectLog = new FSecsDriverLog(fScdlCore, fXmlNode);
                }
                // --
                else if (name == FXmlTagSDVL.E_SecsDevice)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagSDVL.A_LogType, FXmlTagSDVL.D_LogType);
                    // --
                    if (logType == FXmlTagSDVL.L_StateChanged)
                    {
                        fObjectLog = new FSecsDeviceStateChangedLog(fScdlCore, fXmlNode);
                    }
                    else if (logType == FXmlTagSDVL.L_DataReceived)
                    {
                        fObjectLog = new FSecsDeviceDataReceivedLog(fScdlCore, fXmlNode);
                    }
                    else if (logType == FXmlTagSDVL.L_DataSent)
                    {
                        fObjectLog = new FSecsDeviceDataSentLog(fScdlCore, fXmlNode);
                    }                    
                }
                else if (name == FXmlTagSDEL.E_SecsDeviceError)
                {
                    fObjectLog = new FSecsDeviceErrorRaisedLog(fScdlCore, fXmlNode);
                }
                else if (name == FXmlTagSDTL.E_SecsDeviceTimeout)
                {
                    fObjectLog = new FSecsDeviceTimeoutRaisedLog(fScdlCore, fXmlNode);
                }
                else if (name == FXmlTagSTSL.E_SecsDeviceTelnetStateChanged)
                {
                    fObjectLog = new FSecsDeviceTelnetStateChangedLog(fScdlCore, fXmlNode);
                }
                else if (name == FXmlTagSTPL.E_SecsDeviceTelnetPacket)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagSTPL.A_LogType, FXmlTagSTPL.D_LogType);
                    if (logType == FXmlTagSTPL.L_Received)
                    {
                        fObjectLog = new FSecsDeviceTelnetPacketReceivedLog(fScdlCore, fXmlNode);
                    }
                    else if (logType == FXmlTagSTPL.L_Sent)
                    {
                        fObjectLog = new FSecsDeviceTelnetPacketSentLog(fScdlCore, fXmlNode);
                    }
                }
                else if (name == FXmlTagSDHL.E_SecsDeviceHandshake)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagSDHL.A_LogType, FXmlTagSDHL.D_LogType);
                    if (logType == FXmlTagSDHL.L_Received)
                    {
                        fObjectLog = new FSecsDeviceHandshakeReceivedLog(fScdlCore, fXmlNode);
                    }
                    else if (logType == FXmlTagSDHL.L_Sent)
                    {
                        fObjectLog = new FSecsDeviceHandshakeSentLog(fScdlCore, fXmlNode);
                    }
                }
                else if (name == FXmlTagCMGL.E_ControlMessage)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagCMGL.A_LogType, FXmlTagCMGL.D_LogType);
                    // --
                    if (logType == FXmlTagCMGL.L_Received)
                    {
                        fObjectLog = new FSecsDeviceControlMessageReceivedLog(fScdlCore, fXmlNode);
                    }
                    else if (logType == FXmlTagCMGL.L_Sent)
                    {
                        fObjectLog = new FSecsDeviceControlMessageSentLog(fScdlCore, fXmlNode);
                    }
                }
                else if (name == FXmlTagSDBL.E_SecsDeviceBlock)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagSDBL.A_LogType, FXmlTagSDBL.D_LogType);
                    if (logType == FXmlTagSDBL.L_Received)
                    {
                        fObjectLog = new FSecsDeviceBlockReceivedLog(fScdlCore, fXmlNode);
                    }
                    else if (logType == FXmlTagSDBL.L_Sent)
                    {
                        fObjectLog = new FSecsDeviceBlockSentLog(fScdlCore, fXmlNode);
                    }
                }
                else if (name == FXmlTagSMLL.E_Sml)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagSMLL.A_LogType, FXmlTagSMLL.D_LogType);
                    // --
                    if (logType == FXmlTagSMLL.L_Received)
                    {
                        fObjectLog = new FSecsDeviceSmlReceivedLog(fScdlCore, fXmlNode);
                    }
                    else if (logType == FXmlTagSMLL.L_Sent)
                    {
                        fObjectLog = new FSecsDeviceSmlSentLog(fScdlCore, fXmlNode);
                    }
                }
                else if (name == FXmlTagSMGL.E_SecsMessage)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagSMGL.A_LogType, FXmlTagSMGL.D_LogType);
                    // --
                    if (logType == FXmlTagSMGL.L_Received)
                    {
                        fObjectLog = new FSecsDeviceDataMessageReceivedLog(fScdlCore, fXmlNode);
                    }
                    else if (logType == FXmlTagSMGL.L_Sent)
                    {
                        fObjectLog = new FSecsDeviceDataMessageSentLog(fScdlCore, fXmlNode);
                    }
                }
                else if (name == FXmlTagSITL.E_SecsItem)
                {
                    fObjectLog = new FSecsItemLog(fScdlCore, fXmlNode);
                }
                // --
                else if (name == FXmlTagHDVL.E_HostDevice)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagHDVL.A_LogType, FXmlTagHDVL.D_LogType);
                    if (logType == FXmlTagHDVL.L_StateChanged)
                    {
                        fObjectLog = new FHostDeviceStateChangedLog(fScdlCore, fXmlNode);
                    }                    
                }
                else if (name == FXmlTagHDEL.E_HostDeviceError)
                {
                    fObjectLog = new FHostDeviceErrorRaisedLog(fScdlCore, fXmlNode);
                }
                else if (name == FXmlTagVFEL.E_Vfei)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagVFEL.A_LogType, FXmlTagVFEL.D_LogType);
                    if (logType == FXmlTagVFEL.L_Received)
                    {
                        fObjectLog = new FHostDeviceVfeiReceivedLog(fScdlCore, fXmlNode);
                    }
                    else if (logType == FXmlTagVFEL.L_Sent)
                    {
                        fObjectLog = new FHostDeviceVfeiSentLog(fScdlCore, fXmlNode);
                    }
                }
                else if (name == FXmlTagHMGL.E_HostMessage)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagHMGL.A_LogType, FXmlTagHMGL.D_LogType);
                    if (logType == FXmlTagHMGL.L_Received)
                    {
                        fObjectLog = new FHostDeviceDataMessageReceivedLog(fScdlCore, fXmlNode);
                    }
                    else if (logType == FXmlTagHMGL.L_Sent)
                    {
                        fObjectLog = new FHostDeviceDataMessageSentLog(fScdlCore, fXmlNode);
                    }
                }
                else if (name == FXmlTagHITL.E_HostItem)
                {
                    fObjectLog = new FHostItemLog(fScdlCore, fXmlNode);
                }
                // --
                else if (name == FXmlTagSTRL.E_SecsTrigger)
                {
                    fObjectLog = new FSecsTriggerRaisedLog(fScdlCore, fXmlNode);
                }
                else if (name == FXmlTagSTNL.E_SecsTransmitter)
                {
                    fObjectLog = new FSecsTransmitterRaisedLog(fScdlCore, fXmlNode);
                }
                else if (name == FXmlTagHTRL.E_HostTrigger)
                {
                    fObjectLog = new FHostTriggerRaisedLog(fScdlCore, fXmlNode);
                }
                else if (name == FXmlTagHTNL.E_HostTransmitter)
                {
                    fObjectLog = new FHostTransmitterRaisedLog(fScdlCore, fXmlNode);
                }
                else if (name == FXmlTagJDML.E_Judgement)
                {
                    fObjectLog = new FJudgementPerformedLog(fScdlCore, fXmlNode);
                }
                else if (name == FXmlTagMAPL.E_Mapper)
                {
                    fObjectLog = new FMapperPerformedLog(fScdlCore, fXmlNode);
                }
                else if (name == FXmlTagESAL.E_EquipmentStateSetAlterer)
                {
                    fObjectLog = new FEquipmentStateSetAltererPerformedLog(fScdlCore, fXmlNode);
                }
                else if (name == FXmlTagSTGL.E_Storage)
                {
                    fObjectLog = new FStoragePerformedLog(fScdlCore, fXmlNode);
                }
                else if (name == FXmlTagRPSL.E_Repository)
                {
                    fObjectLog = new FRepositoryLog(fScdlCore, fXmlNode);
                }
                else if (name == FXmlTagCOLL.E_Column)
                {
                    fObjectLog = new FColumnLog(fScdlCore, fXmlNode);
                }
                else if (name == FXmlTagDTSL.E_DataSet)
                {
                    fObjectLog = new FDataSetLog(fScdlCore, fXmlNode);
                }
                else if (name == FXmlTagDATL.E_Data)
                {
                    fObjectLog = new FDataLog(fScdlCore, fXmlNode);
                }
                else if (name == FXmlTagCBKL.E_Callback)
                {
                    fObjectLog = new FCallbackRaisedLog(fScdlCore, fXmlNode);
                }
                else if (name == FXmlTagFUNL.E_Function)
                {
                    fObjectLog = new FFunctionCalledLog(fScdlCore, fXmlNode);
                }
                else if (name == FXmlTagBRNL.E_Branch)
                {
                    fObjectLog = new FBranchRaisedLog(fScdlCore, fXmlNode);
                }
                else if (name == FXmlTagCMTL.E_Comment)
                {
                    fObjectLog = new FCommentWrittenLog(fScdlCore, fXmlNode);
                }
                else if (name == FXmlTagPAUL.E_Pauser)
                {
                    fObjectLog = new FPauserRaisedLog(fScdlCore, fXmlNode);
                }
                else if (name == FXmlTagETPL.E_EntryPoint)
                {
                    fObjectLog = new FEntryPointCalledLog(fScdlCore, fXmlNode);
                }
                // --                
                else if (name == FXmlTagAPPL.E_Application)
                {
                    fObjectLog = new FApplicationWrittenLog(fScdlCore, fXmlNode);
                }
                else if (name == FXmlTagCTTL.E_Content)
                {
                    fObjectLog = new FContentLog(fScdlCore, fXmlNode);
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
            FObjectLogType type = FObjectLogType.SecsDriverLog;
            string name = string.Empty;
            string logType = string.Empty;

            try
            {
                name = fXmlNode.name;

                // --

                if (name == FXmlTagSCDL.E_SecsDriver)
                {
                    type = FObjectLogType.SecsDriverLog;
                }
                else if (name == FXmlTagSDVL.E_SecsDevice)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagSDVL.A_LogType, FXmlTagSDVL.D_LogType);
                    // --
                    if (logType == FXmlTagSDVL.L_StateChanged)
                    {
                        type = FObjectLogType.SecsDeviceStateChangedLog;
                    }
                    else if (logType == FXmlTagSDVL.L_DataReceived)
                    {
                        type = FObjectLogType.SecsDeviceDataReceivedLog;
                    }
                    else if (logType == FXmlTagSDVL.L_DataSent)
                    {
                        type = FObjectLogType.SecsDeviceDataSentLog;
                    }                    
                }
                else if (name == FXmlTagSDTL.E_SecsDeviceTimeout)
                {
                    type = FObjectLogType.SecsDeviceTimeoutRaisedLog;
                }
                else if (name == FXmlTagSDEL.E_SecsDeviceError)
                {
                    type = FObjectLogType.SecsDeviceErrorRaisedLog;
                }                
                else if (name == FXmlTagSDHL.E_SecsDeviceHandshake)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagSDHL.A_LogType, FXmlTagSDHL.D_LogType);
                    if (logType == FXmlTagSDHL.L_Received)
                    {
                        type = FObjectLogType.SecsDeviceHandshakeReceivedLog;
                    }
                    else if (logType == FXmlTagSDHL.L_Sent)
                    {
                        type = FObjectLogType.SecsDeviceHandshakeSentLog;
                    }
                }
                else if (name == FXmlTagSTPL.E_SecsDeviceTelnetPacket)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagSTPL.A_LogType, FXmlTagSTPL.D_LogType);
                    if (logType == FXmlTagSTPL.L_Received)
                    {
                        type = FObjectLogType.SecsDeviceTelnetPacketReceivedLog;
                    }
                    else if (logType == FXmlTagSTPL.L_Sent)
                    {
                        type = FObjectLogType.SecsDeviceTelnetPacketSentLog;
                    }
                }
                else if (name == FXmlTagSTSL.E_SecsDeviceTelnetStateChanged)
                {
                    type = FObjectLogType.SecsDeviceTelnetStateChangedLog;
                }
                else if (name == FXmlTagCMGL.E_ControlMessage)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagCMGL.A_LogType, FXmlTagCMGL.D_LogType);
                    // --
                    if (logType == FXmlTagCMGL.L_Received)
                    {
                        type = FObjectLogType.SecsDeviceControlMessageReceivedLog;
                    }
                    else if (logType == FXmlTagCMGL.L_Sent)
                    {
                        type = FObjectLogType.SecsDeviceControlMessageSentLog;
                    }
                }
                else if (name == FXmlTagSMLL.E_Sml)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagSMLL.A_LogType, FXmlTagSMLL.D_LogType);
                    // --
                    if (logType == FXmlTagSMLL.L_Received)
                    {
                        type = FObjectLogType.SecsDeviceSmlReceivedLog;
                    }
                    else if (logType == FXmlTagSMLL.L_Sent)
                    {
                        type = FObjectLogType.SecsDeviceSmlSentLog;
                    }
                }
                else if (name == FXmlTagSDBL.E_SecsDeviceBlock)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagSDBL.A_LogType, FXmlTagSDBL.D_LogType);
                    if (logType == FXmlTagSDBL.L_Received)
                    {
                        type = FObjectLogType.SecsDeviceBlockReceivedLog;
                    }
                    else if (logType == FXmlTagSDBL.L_Sent)
                    {
                        type = FObjectLogType.SecsDeviceBlockSentLog;
                    }
                }
                else if (name == FXmlTagSMGL.E_SecsMessage)
                {
                    logType = fXmlNode.get_attrVal(FXmlTagSMGL.A_LogType, FXmlTagSMGL.D_LogType);
                    // --
                    if (logType == FXmlTagSMGL.L_Received)
                    {
                        type = FObjectLogType.SecsDeviceDataMessageReceivedLog;
                    }
                    else if (logType == FXmlTagSMGL.L_Sent)
                    {
                        type = FObjectLogType.SecsDeviceDataMessageSentLog;
                    }
                }
                else if (name == FXmlTagSITL.E_SecsItem)
                {
                    type = FObjectLogType.SecsItemLog;
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
                else if (name == FXmlTagHDEL.E_HostDeviceError)
                {
                    type = FObjectLogType.HostDeviceErrorRaisedLog;
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
                else if (name == FXmlTagSTRL.E_SecsTrigger)
                {
                    type = FObjectLogType.SecsTriggerRaisedLog;
                }
                else if (name == FXmlTagSTNL.E_SecsTransmitter)
                {
                    type = FObjectLogType.SecsTransmitterRaisedLog;
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
            return FObjectLogType.SecsDriverLog;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode getObjectLogXmlNode(
            FIObjectLog fObjectLog
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                if (fObjectLog.fObjectLogType == FObjectLogType.SecsDriverLog)
                {
                    fXmlNode = ((FSecsDriverLog)fObjectLog).fXmlNode;
                }
                // --
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceStateChangedLog)
                {
                    fXmlNode = ((FSecsDeviceStateChangedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceErrorRaisedLog)
                {
                    fXmlNode = ((FSecsDeviceErrorRaisedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTimeoutRaisedLog)
                {
                    fXmlNode = ((FSecsDeviceTimeoutRaisedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataReceivedLog)
                {
                    fXmlNode = ((FSecsDeviceDataReceivedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataSentLog)
                {
                    fXmlNode = ((FSecsDeviceDataSentLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTelnetStateChangedLog)
                {
                    fXmlNode = ((FSecsDeviceTelnetStateChangedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTelnetPacketReceivedLog)
                {
                    fXmlNode = ((FSecsDeviceTelnetPacketReceivedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTelnetPacketSentLog)
                {
                    fXmlNode = ((FSecsDeviceTelnetPacketSentLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceHandshakeReceivedLog)
                {
                    fXmlNode = ((FSecsDeviceHandshakeReceivedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceHandshakeSentLog)
                {
                    fXmlNode = ((FSecsDeviceHandshakeSentLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceControlMessageReceivedLog)
                {
                    fXmlNode = ((FSecsDeviceControlMessageReceivedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceControlMessageSentLog)
                {
                    fXmlNode = ((FSecsDeviceControlMessageSentLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceBlockReceivedLog)
                {
                    fXmlNode = ((FSecsDeviceBlockReceivedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceBlockSentLog)
                {
                    fXmlNode = ((FSecsDeviceBlockSentLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceSmlReceivedLog)
                {
                    fXmlNode = ((FSecsDeviceSmlReceivedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceSmlSentLog)
                {
                    fXmlNode = ((FSecsDeviceSmlSentLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog)
                {
                    fXmlNode = ((FSecsDeviceDataMessageReceivedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog)
                {
                    fXmlNode = ((FSecsDeviceDataMessageSentLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsItemLog)
                {
                    fXmlNode = ((FSecsItemLog)fObjectLog).fXmlNode;
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
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsTriggerRaisedLog)
                {
                    fXmlNode = ((FSecsTriggerRaisedLog)fObjectLog).fXmlNode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsTransmitterRaisedLog)
                {
                    fXmlNode = ((FSecsTransmitterRaisedLog)fObjectLog).fXmlNode;
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
