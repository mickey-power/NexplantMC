/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FHostDeviceDataMessageLog.cs
--  Creator         : spike.lee
--  Create Date     : 2011.11.14
--  Description     : FAMate Core FaOpcDriver Host Device Data Message Log Class 
--  History         : Created by spike.lee at 2011.11.14
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    public abstract class FHostDeviceDataMessageLog<T> : FBaseObjectLog<T>, FIObjectLog
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FXmlNode m_fXmlNodeHsn = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FHostDeviceDataMessageLog(      
            FXmlNode fXmlNodeHsn,
            FXmlNode fXmlNode      
            )
            : base(fXmlNode)
        {
            m_fXmlNodeHsn = fXmlNodeHsn;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FHostDeviceDataMessageLog(
            FOcdlCore fOcdlCore, 
            FXmlNode fXmlNode
            )
            : base(fOcdlCore, fXmlNode)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FHostDeviceDataMessageLog(
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

        public abstract FObjectLogType fObjectLogType
        {
            get;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FXmlNode fXmlNodeHsn
        {
            get
            {
                try
                {
                    return m_fXmlNodeHsn;
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

        public string logUniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagHMGL.A_LogUniqueId, FXmlTagHMGL.D_LogUniqueId);
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

        public string time
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagHMGL.A_Time, FXmlTagHMGL.D_Time);
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

        public FResultCode fResultCode
        {
            get
            {
                try
                {
                    return FEnumConverter.toResultCode(this.fXmlNode.get_attrVal(FXmlTagHMGL.A_ResultCode, FXmlTagHMGL.D_ResultCode));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FResultCode.Success;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string resultMessage
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagHMGL.A_ResultMessage, FXmlTagHMGL.D_ResultMessage);
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

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagHMGL.A_UniqueId, FXmlTagHMGL.D_UniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHMGL.A_Name, FXmlTagHMGL.D_Name);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHMGL.A_Description, FXmlTagHMGL.D_Description);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagHMGL.A_FontColor, FXmlTagHMGL.D_FontColor));
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagHMGL.A_FontBold, FXmlTagHMGL.D_FontBold));
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

        public UInt64 deviceUniqueId
        {
            get
            {
                try
                {
                    return UInt64.Parse(this.deviceUniqueIdToString);
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

        public string deviceUniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagHMGL.A_HostDeviceId, FXmlTagHMGL.D_HostDeviceId);
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

        public string deviceName        
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagHMGL.A_HostDeviceName, FXmlTagHMGL.D_HostDeviceName);
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

        public UInt64 sessionUniqueId
        {
            get
            {
                try
                {
                    return UInt64.Parse(this.sessionUniqueIdToString);
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

        public string sessionUniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagHMGL.A_HostSessionId, FXmlTagHMGL.D_HostSessionId);
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

        public string sessionName
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagHMGL.A_HostSessionName, FXmlTagHMGL.D_HostSessionName);
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

        public string machineId
        {
            get
            {
                try
                {
                    return fXmlNode.get_attrVal(FXmlTagHMGL.A_MachineId, FXmlTagHMGL.D_MachineId);
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

        public UInt16 sessionId
        {
            get
            {
                try
                {
                    return UInt16.Parse(this.fXmlNode.get_attrVal(FXmlTagHMGL.A_SessionId, FXmlTagHMGL.D_SessionId));
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

        public string command
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagHMGL.A_Command, FXmlTagHMGL.D_Command);
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

        public int version
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagHMGL.A_Version, FXmlTagHMGL.D_Version));
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

        public FHostMessageType fHostMessageType
        {
            get
            {
                try
                {
                    return FEnumConverter.toHostMessageType(this.fXmlNode.get_attrVal(FXmlTagHMGL.A_HostMessageType, FXmlTagHMGL.D_HostMessageType));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FHostMessageType.Command;
            }
        }        

        //------------------------------------------------------------------------------------------------------------------------

        public UInt32 tid
        {
            get
            {
                try
                {
                    return UInt32.Parse(this.fXmlNode.get_attrVal(FXmlTagHMGL.A_TID, FXmlTagHMGL.D_TID));
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

        public bool multiCastMessage
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagHMGL.A_MultiCastMessage, FXmlTagHMGL.D_MultiCastMessage));
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

        public bool guaranteedMessage
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagHMGL.A_GuaranteedMessage, FXmlTagHMGL.D_GuaranteedMessage));
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

        public string connectString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagHMGL.A_ConnectString, FXmlTagHMGL.D_ConnectString);
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

        public string moduleName
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagHMGL.A_ModuleName, FXmlTagHMGL.D_ModuleName);
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

        public string castChannel
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagHMGL.A_CastChannel, FXmlTagHMGL.D_CastChannel);
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

        public bool spooling
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagHMGL.A_Spooling, FXmlTagHMGL.D_Spooling));
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

        public bool autoReply
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagHMGL.A_AutoReply, FXmlTagHMGL.D_AutoReply));
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

        public bool logEnabled
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagHMGL.A_LogEnabled, FXmlTagHMGL.D_LogEnabled));
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

        // ***
        // 2017.07.04 by spike.lee
        // Log Level Add
        // ***
        public FLogLevel logLevel
        {
            get
            {
                try
                {
                    return FEnumConverter.toLogLevel(this.fXmlNode.get_attrVal(FXmlTagHMGL.A_LogLevel, FXmlTagHMGL.D_LogLevel));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FLogLevel.Level1;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag1
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagHMGL.A_UserTag1, FXmlTagHMGL.D_UserTag1);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHMGL.A_UserTag2, FXmlTagHMGL.D_UserTag2);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHMGL.A_UserTag3, FXmlTagHMGL.D_UserTag3);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHMGL.A_UserTag4, FXmlTagHMGL.D_UserTag4);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHMGL.A_UserTag5, FXmlTagHMGL.D_UserTag5);
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

        public FHostItemLogCollection fChildHostItemLogCollection
        {
            get
            {
                try
                {
                    return new FHostItemLogCollection(this.fOcdlCore, this.fXmlNode.selectNodes(FXmlTagHITL.E_HostItem));
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

        public bool isPrimary
        {
            get
            {
                try
                {
                    return this.fHostMessageType == FHostMessageType.Reply ? false : true;
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

        public bool isSecondary
        {
            get
            {
                try
                {
                    return !this.isPrimary;
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

        public bool hasChild
        {
            get
            {
                try
                {
                    return this.fXmlNode.containsNode(FXmlTagHITL.E_HostItem);
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

        public bool hasHashTagChild
        {
            get
            {
                string xpath = string.Empty;

                try
                {
                    xpath = FXmlTagHITL.E_HostItem + "[@" + FXmlTagHITL.A_HashTag + "='" + FBoolean.True + "']";
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

        //------------------------------------------------------------------------------------------------------------------------

        public FOpcDriverLog fParent
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

                    return this.fOpcDriverLog;
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

        public FIObjectLog fPreviousSibling
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

                    return FOpcDriverLogCommon.createObjectLog(this.fOcdlCore, this.fXmlNode.fPreviousSibling);                    
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

        public FIObjectLog fNextSibling
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

                    return FOpcDriverLogCommon.createObjectLog(this.fOcdlCore, this.fXmlNode.fNextSibling);
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

        public string equipmentName
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagHMGL.A_EquipmentName, FXmlTagHMGL.D_EquipmentName); ;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

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
                    info = "[" + this.time + "] [" + this.command + " V" + this.version.ToString() + "] " + this.name;                    
                    // --
                    if (this.resultMessage != string.Empty)
                    {
                        info += (" Msg=[" + this.resultMessage + "]");
                    }
                }

                // --

                if (this.description != string.Empty)
                {
                    info += (" Desc=[" + this.description + "]");
                }

                if (option == FStringOption.Detail)
                {
                    info += " Device=[" + this.deviceName + "] Session=[" + this.sessionName + "(" + this.sessionId.ToString() + ")] MachineID=[" + this.machineId + "]";
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

        public void copy(
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.clone(true);
                // --
                fXmlNode.set_attrVal(FXmlTagHMGL.A_LogType, FXmlTagHMGL.D_LogType, FXmlTagHMGL.D_LogType);
                fXmlNode.set_attrVal(FXmlTagHMGL.A_Time, FXmlTagHMGL.D_Time, FXmlTagHMGL.D_Time);
                fXmlNode.set_attrVal(FXmlTagHMGL.A_ResultCode, FXmlTagHMGL.D_ResultCode, FXmlTagHMGL.D_ResultCode);
                fXmlNode.set_attrVal(FXmlTagHMGL.A_ResultMessage, FXmlTagHMGL.D_ResultMessage, FXmlTagHMGL.D_ResultMessage);                
                // --
                fXmlNode.set_attrVal(FXmlTagHMGL.A_HostDeviceId, FXmlTagHMGL.D_HostDeviceId, FXmlTagHMGL.D_HostDeviceId);
                fXmlNode.set_attrVal(FXmlTagHMGL.A_HostDeviceName, FXmlTagHMGL.D_HostDeviceName, FXmlTagHMGL.D_HostDeviceName);
                fXmlNode.set_attrVal(FXmlTagHMGL.A_HostSessionId, FXmlTagHMGL.D_HostSessionId, FXmlTagHMGL.D_HostSessionId);
                fXmlNode.set_attrVal(FXmlTagHMGL.A_HostSessionName, FXmlTagHMGL.D_HostSessionName, FXmlTagHMGL.D_HostSessionName);
                fXmlNode.set_attrVal(FXmlTagHMGL.A_MachineId, FXmlTagHMGL.D_MachineId, FXmlTagHMGL.D_MachineId);
                fXmlNode.set_attrVal(FXmlTagHMGL.A_SessionId, FXmlTagHMGL.D_SessionId, FXmlTagHMGL.D_SessionId);
                // --
                fXmlNode.set_attrVal(FXmlTagHMGL.A_TID, FXmlTagHMGL.D_TID, FXmlTagHMGL.D_TID);                
                // -- 
                FOpcDriverLogCommon.removeLogUniqueId(fXmlNode);
                
                // --

                this.copyObject(FCbObjectFormat.HostMessage, fXmlNode);
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

        public string convertToVfei(
            )
        {
            try
            {
                return FMessageConverter.convertHmgToVfei(this.fXmlNode, this.machineId, (int)this.tid);
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

        public string convertToTrs(
            )
        {
            try
            {
                return FMessageConverter.convertHmgToTrs(this.fXmlNode);
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

        public FHostItemLogCollection selectHostItemLogByName(
            string name
            )
        {
            const string xpath = FXmlTagHITL.E_HostItem + "[@" + FXmlTagHITL.A_Name + "='{0}']";

            try
            {
                return new FHostItemLogCollection(
                    this.fOcdlCore,
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

        public FHostItemLog selectSingleHostItemLogByName(
            string name
            )
        {
            const string xpath = FXmlTagHITL.E_HostItem + "[@" + FXmlTagHITL.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FHostItemLog(this.fOcdlCore, fXmlNode);
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

        public FHostItemLogCollection selectAllHostItemLogByName(
            string name
            )
        {
            const string xpath = ".//" + FXmlTagHITL.E_HostItem + "[@" + FXmlTagHITL.A_Name + "='{0}']";

            try
            {
                return new FHostItemLogCollection(
                    this.fOcdlCore,
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

        public FHostItemLogCollection selectAllHostItemLogByHashTag(
            string hashTagValue
            )
        {
            const string xpath = ".//" + FXmlTagHITL.E_HostItem + "[@" + FXmlTagHITL.A_Value + "='{0}']";

            try
            {
                return new FHostItemLogCollection(
                    this.fOcdlCore,
                    this.fXmlNode.selectNodes(string.Format(xpath, hashTagValue))
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

        public FHostItemLog selectSingleAllHostItemLogByName(
            string name
            )
        {
            const string xpath = ".//" + FXmlTagHITL.E_HostItem + "[@" + FXmlTagHITL.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FHostItemLog(this.fOcdlCore, fXmlNode);
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

        public FHostItemLogCollection selectHostItemLogByReservedWord(
            string reservedWord
            )
        {
            const string xpath = FXmlTagHITL.E_HostItem + "[@" + FXmlTagHITL.A_ReservedWord + "='{0}']";

            try
            {
                return new FHostItemLogCollection(
                    this.fOcdlCore,
                    this.fXmlNode.selectNodes(string.Format(xpath, reservedWord))
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

        public FHostItemLog selectSingleHostItemLogByReservedWord(
            string reservedWord
            )
        {
            const string xpath = FXmlTagHITL.E_HostItem + "[@" + FXmlTagHITL.A_ReservedWord + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, reservedWord));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FHostItemLog(this.fOcdlCore, fXmlNode);
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

        public FHostItemLogCollection selectAllHostItemLogByReservedWord(
            string reservedWord
            )
        {
            const string xpath = ".//" + FXmlTagHITL.E_HostItem + "[@" + FXmlTagHITL.A_ReservedWord + "='{0}']";

            try
            {
                return new FHostItemLogCollection(
                    this.fOcdlCore,
                    this.fXmlNode.selectNodes(string.Format(xpath, reservedWord))
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

        public FHostItemLog selectSingleAllHostItemLogByReservedWord(
            string reservedWord
            )
        {
            const string xpath = ".//" + FXmlTagHITL.E_HostItem + "[@" + FXmlTagHITL.A_ReservedWord + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, reservedWord));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FHostItemLog(this.fOcdlCore, fXmlNode);
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

        public FHostItemLogCollection selectHostItemLogByExtraction(
            )
        {
            const string xpath = FXmlTagHITL.E_HostItem + "[@" + FXmlTagHITL.A_Extraction + "='{0}']";

            try
            {
                return new FHostItemLogCollection(
                    this.fOcdlCore,
                    this.fXmlNode.selectNodes(string.Format(xpath, FBoolean.True))
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

        public FHostItemLog selectSingleHostItemLogByExtraction(
            )
        {
            const string xpath = FXmlTagHITL.E_HostItem + "[@" + FXmlTagHITL.A_Extraction + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, FBoolean.True));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FHostItemLog(this.fOcdlCore, fXmlNode);
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

        public FHostItemLogCollection selectAllHostItemLogByExtraction(
            )
        {
            const string xpath = ".//" + FXmlTagHITL.E_HostItem + "[@" + FXmlTagHITL.A_Extraction + "='{0}']";

            try
            {
                return new FHostItemLogCollection(
                    this.fOcdlCore,
                    this.fXmlNode.selectNodes(string.Format(xpath, FBoolean.True))
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

        public FHostItemLog selectSingleAllHostItemLogByExtraction(
            )
        {
            const string xpath = ".//" + FXmlTagHITL.E_HostItem + "[@" + FXmlTagHITL.A_Extraction + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, FBoolean.True));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FHostItemLog(this.fOcdlCore, fXmlNode);
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

        public FHostItemLog selectSingleAllHostItemLogByIndex(
            params object[] args
            )
        {
            FXmlNode fXmlNode = null;
            int index = 0;

            try
            {
                if (args == null || args.Length == 0)
                {
                    return null;
                }

                // --

                fXmlNode = this.fXmlNode;
                // --
                foreach (object obj in args)
                {
                    index = (int)obj;
                    // --
                    if (index >= fXmlNode.fChildNodes.count)
                    {
                        return null;
                    }
                    // --
                    fXmlNode = fXmlNode.fChildNodes[index];
                }
                // --
                return new FHostItemLog(this.fOcdlCore, fXmlNode);
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

        public string convertToXml(
            )
        {
            try
            {
                return FMessageConverter.convertHmglToXml(this.fXmlNode);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
