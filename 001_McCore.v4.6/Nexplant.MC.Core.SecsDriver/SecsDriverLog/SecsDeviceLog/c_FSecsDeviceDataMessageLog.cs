/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecsDeviceDataMessageLog.cs
--  Creator         : spike.lee
--  Create Date     : 2011.10.07
--  Description     : FAMate Core FaSecsDriver SECS Device Data Message Log Class 
--  History         : Created by spike.lee at 2011.10.07
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public abstract class FSecsDeviceDataMessageLog<T> : FBaseObjectLog<T>, FIObjectLog
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FXmlNode m_fXmlNodeSsn = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FSecsDeviceDataMessageLog(      
            FXmlNode fXmlNodeSsn,
            FXmlNode fXmlNode      
            )
            : base(fXmlNode)
        {
            m_fXmlNodeSsn = fXmlNodeSsn;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FSecsDeviceDataMessageLog(
            FScdlCore fScdlCore, 
            FXmlNode fXmlNode
            )
            : base(fScdlCore, fXmlNode)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSecsDeviceDataMessageLog(
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

        internal FXmlNode fXmlNodeSsn
        {
            get
            {
                try
                {
                    return m_fXmlNodeSsn;
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
                    return this.fXmlNode.get_attrVal(FXmlTagSMGL.A_LogUniqueId, FXmlTagSMGL.D_LogUniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSMGL.A_Time, FXmlTagSMGL.D_Time);
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
                    return FEnumConverter.toResultCode(this.fXmlNode.get_attrVal(FXmlTagSMGL.A_ResultCode, FXmlTagSMGL.D_ResultCode));
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
                    return this.fXmlNode.get_attrVal(FXmlTagSMGL.A_ResultMessage, FXmlTagSMGL.D_ResultMessage);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSMGL.A_UniqueId, FXmlTagSMGL.D_UniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSMGL.A_Name, FXmlTagSMGL.D_Name);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSMGL.A_Description, FXmlTagSMGL.D_Description);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagSMGL.A_FontColor, FXmlTagSMGL.D_FontColor));
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSMGL.A_FontBold, FXmlTagSMGL.D_FontBold));
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
                    return this.fXmlNode.get_attrVal(FXmlTagSMGL.A_SecsDeviceId, FXmlTagSMGL.D_SecsDeviceId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSMGL.A_SecsDeviceName, FXmlTagSMGL.D_SecsDeviceName);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSMGL.A_SecsSessionId, FXmlTagSMGL.D_SecsSessionId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSMGL.A_SecsSessionName, FXmlTagSMGL.D_SecsSessionName);
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
                    return UInt16.Parse(this.fXmlNode.get_attrVal(FXmlTagSMGL.A_SessionId, FXmlTagSMGL.D_SessionId));
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

        public int stream
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSMGL.A_Stream, FXmlTagSMGL.D_Stream));
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

        public int function
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSMGL.A_Function, FXmlTagSMGL.D_Function));
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

        public int version
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSMGL.A_Version, FXmlTagSMGL.D_Version));
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

        public bool wBit
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSMGL.A_WBit, FXmlTagSMGL.D_WBit));
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

        public UInt32 systemBytes
        {
            get
            {
                try
                {
                    return UInt32.Parse(this.fXmlNode.get_attrVal(FXmlTagSMGL.A_SystemBytes, FXmlTagSMGL.D_SystemBytes));
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

        public UInt32 length
        {
            get
            {
                try
                {
                    return UInt32.Parse(this.fXmlNode.get_attrVal(FXmlTagSMGL.A_Length, FXmlTagSMGL.D_Length));
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
                int f = 0;

                try
                {
                    // ***
                    // Function이 0이거나 Primary Message일 경우에는 항상 False를 반환하고, Secondary Message일
                    // 경우에만 AutoReply 값을 반환한다.
                    // ***
                    f = this.function;
                    if (f == 0 && f % 2 == 1)
                    {
                        return false;
                    }
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSMGL.A_AutoReply, FXmlTagSMGL.D_AutoReply));
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSMGL.A_LogEnabled, FXmlTagSMGL.D_LogEnabled));
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
                    return FEnumConverter.toLogLevel(this.fXmlNode.get_attrVal(FXmlTagSMGL.A_LogLevel, FXmlTagSMGL.D_LogLevel));
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
                    return this.fXmlNode.get_attrVal(FXmlTagSMGL.A_UserTag1, FXmlTagSMGL.D_UserTag1);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSMGL.A_UserTag2, FXmlTagSMGL.D_UserTag2);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSMGL.A_UserTag3, FXmlTagSMGL.D_UserTag3);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSMGL.A_UserTag4, FXmlTagSMGL.D_UserTag4);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSMGL.A_UserTag5, FXmlTagSMGL.D_UserTag5);
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

        public FSecsItemLogCollection fChildSecsItemLogCollection
        {
            get
            {
                try
                {
                    return new FSecsItemLogCollection(this.fScdlCore, this.fXmlNode.selectNodes(FXmlTagSITL.E_SecsItem));
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
                    if (this.function == 0 || this.function % 2 == 1)
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
                    return this.fXmlNode.containsNode(FXmlTagSITL.E_SecsItem);
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

        public FSecsDriverLog fParent
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

                    return this.fSecsDriverLog;
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

                    return FSecsDriverLogCommon.createObjectLog(this.fScdlCore, this.fXmlNode.fPreviousSibling);
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

                    return FSecsDriverLogCommon.createObjectLog(this.fScdlCore, this.fXmlNode.fNextSibling);
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
                    info = "[" + this.time + "] [S" + this.stream.ToString() + " F" + this.function.ToString() + " V" + this.version.ToString() + "] " + this.name;                    
                    
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
                    info += (" Length=[" + this.length.ToString() + "]");
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
                fXmlNode.set_attrVal(FXmlTagSMGL.A_LogType, FXmlTagSMGL.D_LogType, FXmlTagSMGL.D_LogType);
                fXmlNode.set_attrVal(FXmlTagSMGL.A_Time, FXmlTagSMGL.D_Time, FXmlTagSMGL.D_Time);
                fXmlNode.set_attrVal(FXmlTagSMGL.A_ResultCode, FXmlTagSMGL.D_ResultCode, FXmlTagSMGL.D_ResultCode);
                fXmlNode.set_attrVal(FXmlTagSMGL.A_ResultMessage, FXmlTagSMGL.D_ResultMessage, FXmlTagSMGL.D_ResultMessage);                
                // --
                fXmlNode.set_attrVal(FXmlTagSMGL.A_SecsDeviceId, FXmlTagSMGL.D_SecsDeviceId, FXmlTagSMGL.D_SecsDeviceId);
                fXmlNode.set_attrVal(FXmlTagSMGL.A_SecsDeviceName, FXmlTagSMGL.D_SecsDeviceName, FXmlTagSMGL.D_SecsDeviceName);
                fXmlNode.set_attrVal(FXmlTagSMGL.A_SecsSessionId, FXmlTagSMGL.D_SecsSessionId, FXmlTagSMGL.D_SecsSessionId);
                fXmlNode.set_attrVal(FXmlTagSMGL.A_SecsSessionName, FXmlTagSMGL.D_SecsSessionName, FXmlTagSMGL.D_SecsSessionName);
                fXmlNode.set_attrVal(FXmlTagSMGL.A_SessionId, FXmlTagSMGL.D_SessionId, FXmlTagSMGL.D_SessionId);
                // --
                fXmlNode.set_attrVal(FXmlTagSMGL.A_SystemBytes, FXmlTagSMGL.D_SystemBytes, FXmlTagSMGL.D_SystemBytes);
                fXmlNode.set_attrVal(FXmlTagSMGL.A_Length, FXmlTagSMGL.D_Length, FXmlTagSMGL.D_Length);
                // -- 
                FSecsDriverLogCommon.removeLogUniqueId(fXmlNode);

                // --

                // ***
                // [2016.12.19 by spike.lee]
                // FSecsItemLog Copy 시, LengthBytes를 Auto로 변경
                // ***
                foreach (FXmlNode x in fXmlNode.selectNodes(".//" + FXmlTagSITL.E_SecsItem))
                {
                    x.set_attrVal(FXmlTagSITL.A_LengthBytes, FXmlTagSITL.D_LengthBytes, FXmlTagSITL.D_LengthBytes);
                }
                
                // --

                this.copyObject(FCbObjectFormat.SecsMessage, fXmlNode);
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

        public string convertToSml(
            )
        {
            try
            {
                return FMessageConverter.convertSmgToSml(this.fXmlNode);
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

        public string convertToXml(
            )
        {
            try
            {
                return FMessageConverter.convertSmglToXml(this.fXmlNode);
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

        public FSecsItemLogCollection selectSecsItemLogByName(
            string name
            )
        {
            const string xpath = FXmlTagSITL.E_SecsItem + "[@" + FXmlTagSITL.A_Name + "='{0}']";

            try
            {
                return new FSecsItemLogCollection(
                    this.fScdlCore,
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

        public FSecsItemLog selectSingleSecsItemLogByName(
            string name
            )
        {
            const string xpath = FXmlTagSITL.E_SecsItem + "[@" + FXmlTagSITL.A_Name + "='{0}']";
            //--
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsItemLog(this.fScdlCore, fXmlNode);
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

        public FSecsItemLogCollection selectAllSecsItemLogByName(
            string name
            )
        {
            const string xpath = ".//" + FXmlTagSITL.E_SecsItem + "[@" + FXmlTagSITL.A_Name + "='{0}']";

            try
            {
                return new FSecsItemLogCollection(
                    this.fScdlCore,
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

        public FSecsItemLog selectSingleAllSecsItemLogByName(
            string name
            )
        {
            const string xpath = ".//" + FXmlTagSITL.E_SecsItem + "[@" + FXmlTagSITL.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsItemLog(this.fScdlCore, fXmlNode);
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

        public FSecsItemLogCollection selectSecsItemLogByReservedWord(
            string reservedWord
            )
        {
            const string xpath = FXmlTagSITL.E_SecsItem + "[@" + FXmlTagSITL.A_ReservedWord + "='{0}']";

            try
            {
                return new FSecsItemLogCollection(
                    this.fScdlCore,
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

        public FSecsItemLog selectSingleSecsItemLogByReservedWord(
            string reservedWord
            )
        {
            const string xpath = FXmlTagSITL.E_SecsItem + "[@" + FXmlTagSITL.A_ReservedWord + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, reservedWord));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsItemLog(this.fScdlCore, fXmlNode);
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

        public FSecsItemLogCollection selectAllSecsItemLogByReservedWord(
            string reservedWord
            )
        {
            const string xpath = ".//" + FXmlTagSITL.E_SecsItem + "[@" + FXmlTagSITL.A_ReservedWord + "='{0}']";

            try
            {
                return new FSecsItemLogCollection(
                    this.fScdlCore,
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

        public FSecsItemLog selectSingleAllSecsItemLogByReservedWord(
            string reservedWord
            )
        {
            const string xpath = ".//" + FXmlTagSITL.E_SecsItem + "[@" + FXmlTagSITL.A_ReservedWord + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, reservedWord));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsItemLog(this.fScdlCore, fXmlNode);
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

        public FSecsItemLogCollection selectSecsItemLogByExtraction(
            )
        {
            const string xpath = FXmlTagSITL.E_SecsItem + "[@" + FXmlTagSITL.A_Extraction + "='{0}']";

            try
            {
                return new FSecsItemLogCollection(
                    this.fScdlCore,
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
        
        public FSecsItemLog selectSingleSecsItemLogByExtraction(
            )
        {
            const string xpath = FXmlTagSITL.E_SecsItem + "[@" + FXmlTagSITL.A_Extraction + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, FBoolean.True));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsItemLog(this.fScdlCore, fXmlNode);
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

        public FSecsItemLogCollection selectAllSecsItemLogByExtraction(
            )
        {
            const string xpath = ".//" + FXmlTagSITL.E_SecsItem + "[@" + FXmlTagSITL.A_Extraction + "='{0}']";

            try
            {
                return new FSecsItemLogCollection(
                    this.fScdlCore,
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

        public FSecsItemLog selectSingleAllSecsItemLogByExtraction(
            )
        {
            const string xpath = ".//" + FXmlTagSITL.E_SecsItem + "[@" + FXmlTagSITL.A_Extraction + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, FBoolean.True));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsItemLog(this.fScdlCore, fXmlNode);
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

        public FSecsItemLog selectSingleAllSecsItemLogByInddex(
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

                fXmlNode = this.fXmlNode.clone(true);
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
                    fXmlNode = fXmlNode.fChildNodes[index].clone(true);
                }
                // --
                return new FSecsItemLog(this.fScdlCore, fXmlNode);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
