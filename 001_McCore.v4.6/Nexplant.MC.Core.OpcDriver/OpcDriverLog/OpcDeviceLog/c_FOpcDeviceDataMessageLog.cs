/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FOpcDeviceDataMessageLog.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2013.10.30
--  Description     : FAMate Core FaOpcDriver OPC Device Data Message Log Class 
--  History         : Created by jungyoul.moon at 2013.10.30
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    public abstract class FOpcDeviceDataMessageLog<T> : FBaseObjectLog<T>, FIObjectLog
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FXmlNode m_fXmlNodeOsn = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FOpcDeviceDataMessageLog(      
            FXmlNode fXmlNodeOsn,
            FXmlNode fXmlNode
            )
            : base(fXmlNode)
        {
            m_fXmlNodeOsn = fXmlNodeOsn;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FOpcDeviceDataMessageLog(
            FOcdlCore fOcdlCore, 
            FXmlNode fXmlNode
            )
            : base(fOcdlCore, fXmlNode)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FOpcDeviceDataMessageLog(
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

        internal FXmlNode fXmlNodeOsn
        {
            get
            {
                try
                {
                    return m_fXmlNodeOsn;
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
                    return this.fXmlNode.get_attrVal(FXmlTagOMGL.A_LogUniqueId, FXmlTagOMGL.D_LogUniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOMGL.A_Time, FXmlTagOMGL.D_Time);
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
                    return FEnumConverter.toResultCode(this.fXmlNode.get_attrVal(FXmlTagOMGL.A_ResultCode, FXmlTagOMGL.D_ResultCode));
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
                    return this.fXmlNode.get_attrVal(FXmlTagOMGL.A_ResultMessage, FXmlTagOMGL.D_ResultMessage);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOMGL.A_UniqueId, FXmlTagOMGL.D_UniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOMGL.A_Name, FXmlTagOMGL.D_Name);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOMGL.A_Description, FXmlTagOMGL.D_Description);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagOMGL.A_FontColor, FXmlTagOMGL.D_FontColor));
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagOMGL.A_FontBold, FXmlTagOMGL.D_FontBold));
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
                    return this.fXmlNode.get_attrVal(FXmlTagOMGL.A_OpcDeviceId, FXmlTagOMGL.D_OpcDeviceId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOMGL.A_OpcDeviceName, FXmlTagOMGL.D_OpcDeviceName);
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

        public string deviceDefaultNamespace
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOMGL.A_OpcDeviceDefaultNamespace, FXmlTagOMGL.D_OpcDeviceDefaultNamespace);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOMGL.A_OpcSessionId, FXmlTagOMGL.D_OpcSessionId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOMGL.A_OpcSessionName, FXmlTagOMGL.D_OpcSessionName);
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
                    return UInt16.Parse(this.fXmlNode.get_attrVal(FXmlTagOMGL.A_SessionId, FXmlTagOMGL.D_SessionId));
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

        public string sessionChannel
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOMGL.A_OpcSessionChannel, FXmlTagOMGL.D_OpcSessionChannel);
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

        public bool IgnoreReadResult
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagOMGL.A_IgnoreReadResult, FXmlTagOMGL.D_IgnoreReadResult));
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

        public int delayTime
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagOMGL.A_DelayTime, FXmlTagOMGL.D_DelayTime));
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

        public bool autoReply
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagOMGL.A_AutoReply, FXmlTagOMGL.D_AutoReply));
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

        public bool autoReset
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagOMGL.A_AutoReset, FXmlTagOMGL.D_AutoReset));
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

        public bool usedAutoTrace
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagOMGL.A_UsedAutoTrace, FXmlTagOMGL.D_UsedAutoTrace));
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

        public int autoTracePeriod
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagOMGL.A_AUtoTracePeriod, FXmlTagOMGL.D_AutoTracePeriod));
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

        public bool logEnabled
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagOMGL.A_LogEnabled, FXmlTagOMGL.D_LogEnabled));
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
                    return FEnumConverter.toLogLevel(this.fXmlNode.get_attrVal(FXmlTagOMGL.A_LogLevel, FXmlTagOMGL.D_LogLevel));
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

        public bool isPrimary
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagOMGL.A_IsPrimary, FXmlTagOMGL.D_IsPrimary));
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

        public string userTag1
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOMGL.A_UserTag1, FXmlTagOMGL.D_UserTag1);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOMGL.A_UserTag2, FXmlTagOMGL.D_UserTag2);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOMGL.A_UserTag3, FXmlTagOMGL.D_UserTag3);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOMGL.A_UserTag4, FXmlTagOMGL.D_UserTag4);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOMGL.A_UserTag5, FXmlTagOMGL.D_UserTag5);
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

        public FOpcEventItemListLogCollection fChildOpcEventItemListLogCollection
        {
            get
            {
                try
                {
                    return new FOpcEventItemListLogCollection(this.fOcdlCore, this.fXmlNode.selectNodes(FXmlTagOELL.E_OpcEventItemList));
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

        public FOpcItemListLogCollection fChildOpcItemListLogCollection
        {
            get
            {
                try
                {
                    return new FOpcItemListLogCollection(this.fOcdlCore, this.fXmlNode.selectNodes(FXmlTagOILL.E_OpcItemList));
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
                    if (this.fXmlNode.containsNode(FXmlTagOELL.E_OpcEventItemList) || this.fXmlNode.containsNode(FXmlTagOILL.E_OpcItemList))
                    {
                        return true;
                    }
                    return false;
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
                try
                {
                    if (this.fXmlNode.containsNode(FXmlTagOELL.E_OpcEventItemList + "/" + FXmlTagOEIL.E_OpcEventItem + "[@" + FXmlTagOEIL.A_HashTag + "='" + FBoolean.True + "']") ||
                        this.fXmlNode.containsNode(FXmlTagOILL.E_OpcItemList + "/" + FXmlTagOITL.E_OpcItem + "[@" + FXmlTagOITL.A_HashTag + "='" + FBoolean.True + "']"))
                    {
                        return true;
                    }
                    return false;
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
                    return sessionName;
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
                    info = "[" + this.time + "] " + this.name;
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
                
                // --

                if (option == FStringOption.Detail)
                {
                    info += " Device=[" + this.deviceName + "] Session=[" + this.sessionName + "(" + this.sessionId.ToString() + ")]";
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
                fXmlNode.set_attrVal(FXmlTagOMGL.A_Time, FXmlTagOMGL.D_Time, FXmlTagOMGL.D_Time);
                fXmlNode.set_attrVal(FXmlTagOMGL.A_ResultCode, FXmlTagOMGL.D_ResultCode, FXmlTagOMGL.D_ResultCode);
                fXmlNode.set_attrVal(FXmlTagOMGL.A_ResultMessage, FXmlTagOMGL.D_ResultMessage, FXmlTagOMGL.D_ResultMessage);                
                // --
                fXmlNode.set_attrVal(FXmlTagOMGL.A_OpcDeviceId, FXmlTagOMGL.D_OpcDeviceId, FXmlTagOMGL.D_OpcDeviceId);
                fXmlNode.set_attrVal(FXmlTagOMGL.A_OpcDeviceName, FXmlTagOMGL.D_OpcDeviceName, FXmlTagOMGL.D_OpcDeviceName);
                fXmlNode.set_attrVal(FXmlTagOMGL.A_OpcDeviceDefaultNamespace, FXmlTagOMGL.D_OpcDeviceDefaultNamespace, FXmlTagOMGL.D_OpcDeviceDefaultNamespace);
                fXmlNode.set_attrVal(FXmlTagOMGL.A_OpcSessionId, FXmlTagOMGL.D_OpcSessionId, FXmlTagOMGL.D_OpcSessionId);
                fXmlNode.set_attrVal(FXmlTagOMGL.A_OpcSessionName, FXmlTagOMGL.D_OpcSessionName, FXmlTagOMGL.D_OpcSessionName);
                fXmlNode.set_attrVal(FXmlTagOMGL.A_OpcSessionChannel, FXmlTagOMGL.D_OpcSessionChannel, FXmlTagOMGL.D_OpcSessionChannel);
                fXmlNode.set_attrVal(FXmlTagOMGL.A_SessionId, FXmlTagOMGL.D_SessionId, FXmlTagOMGL.D_SessionId);
                // -- 
                FOpcDriverLogCommon.removeLogUniqueId(fXmlNode);
                
                // --

                this.copyObject(FCbObjectFormat.OpcMessage, fXmlNode);
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

        public FOpcEventItemListLogCollection selectOpcEventItemListLogByName(
            string name
            )
        {
            const string xpath = FXmlTagOELL.E_OpcEventItemList + "[@" + FXmlTagOELL.A_Name + "='{0}']";

            try
            {
                return new FOpcEventItemListLogCollection(
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

        public FOpcEventItemListLog selectSingleOpcEventItemListLogByName(
            string name
            )
        {
            const string xpath = FXmlTagOELL.E_OpcEventItemList + "[@" + FXmlTagOELL.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FOpcEventItemListLog(this.fOcdlCore, fXmlNode);
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

        public FOpcItemListLogCollection selectOpcItemListLogByName(
            string name
            )
        {
            const string xpath = FXmlTagOILL.E_OpcItemList + "[@" + FXmlTagOILL.A_Name + "='{0}']";

            try
            {
                return new FOpcItemListLogCollection(
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

        public FOpcItemListLog selectSingleOpcItemListLogByName(
            string name
            )
        {
            const string xpath = FXmlTagOILL.E_OpcItemList + "[@" + FXmlTagOILL.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FOpcItemListLog(this.fOcdlCore, fXmlNode);
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

        public FOpcEventItemLogCollection selectOpcEventItemLogByName(
            string name
            )
        {
            const string xpath = 
                FXmlTagOELL.E_OpcEventItemList + "/" +
                FXmlTagOEIL.E_OpcEventItem + "[@" + FXmlTagOEIL.A_Name + "='{0}']";

            try
            {
                return new FOpcEventItemLogCollection(
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

        public FOpcEventItemLogCollection selectOpcEventItemLogByHashTag(
            string hashTagValue
            )
        {
            const string xpath =
                FXmlTagOELL.E_OpcEventItemList + "/" +
                FXmlTagOEIL.E_OpcEventItem + "[@" + FXmlTagOEIL.A_Value + "='{0}']";

            try
            {
                return new FOpcEventItemLogCollection(
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

        public FOpcEventItemLog selectSingleOpcEventItemLogByName(
            string name
            )
        {
            const string xpath = 
                FXmlTagOELL.E_OpcEventItemList +
                "/" + FXmlTagOEIL.E_OpcEventItem + "[@" + FXmlTagOEIL.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FOpcEventItemLog(this.fOcdlCore, fXmlNode);

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

        public FOpcItemLogCollection selectOpcItemLogByName(
            string name
            )
        {
            const string xpath = 
                FXmlTagOILL.E_OpcItemList + "/" +
                FXmlTagOITL.E_OpcItem + "[@" + FXmlTagOITL.A_Name + "='{0}']";

            try
            {
                return new FOpcItemLogCollection(
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

        public FOpcItemLogCollection selectOpcItemLogByHashTag(
            string hashTagValue
            )
        {
            const string xpath =
                FXmlTagOILL.E_OpcItemList + "/" +
                FXmlTagOITL.E_OpcItem + "[@" + FXmlTagOITL.A_Value + "='{0}']";

            try
            {
                return new FOpcItemLogCollection(
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

        public FOpcItemLog selectSingleOpcItemLogByName(
            string name
            )
        {
            const string xpath = 
                FXmlTagOILL.E_OpcItemList + "/" +
                FXmlTagOITL.E_OpcItem + "[@" + FXmlTagOITL.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FOpcItemLog(this.fOcdlCore, fXmlNode);

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
                return FMessageConverter.convertOmglToXml(this.fXmlNode);
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
