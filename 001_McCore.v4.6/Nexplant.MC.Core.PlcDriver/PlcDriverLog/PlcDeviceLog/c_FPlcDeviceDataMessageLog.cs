/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPlcDeviceDataMessageLog.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2013.10.30
--  Description     : FAMate Core FaPlcDriver PLC Device Data Message Log Class 
--  History         : Created by jungyoul.moon at 2013.10.30
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    public abstract class FPlcDeviceDataMessageLog<T> : FBaseObjectLog<T>, FIObjectLog
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FXmlNode m_fXmlNodePsn = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FPlcDeviceDataMessageLog(      
            FXmlNode fXmlNodePsn,
            FXmlNode fXmlNode
            )
            : base(fXmlNode)
        {
            m_fXmlNodePsn = fXmlNodePsn;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FPlcDeviceDataMessageLog(
            FPcdlCore fPcdlCore, 
            FXmlNode fXmlNode
            )
            : base(fPcdlCore, fXmlNode)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPlcDeviceDataMessageLog(
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

        internal FXmlNode fXmlNodePsn
        {
            get
            {
                try
                {
                    return m_fXmlNodePsn;
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
                    return this.fXmlNode.get_attrVal(FXmlTagPMGL.A_LogUniqueId, FXmlTagPMGL.D_LogUniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPMGL.A_Time, FXmlTagPMGL.D_Time);
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
                    return FEnumConverter.toResultCode(this.fXmlNode.get_attrVal(FXmlTagPMGL.A_ResultCode, FXmlTagPMGL.D_ResultCode));
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
                    return this.fXmlNode.get_attrVal(FXmlTagPMGL.A_ResultMessage, FXmlTagPMGL.D_ResultMessage);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPMGL.A_UniqueId, FXmlTagPMGL.D_UniqueId);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagPMGL.A_Locked, FXmlTagPMGL.D_Locked));
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

        public string name
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagPMGL.A_Name, FXmlTagPMGL.D_Name);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPMGL.A_Description, FXmlTagPMGL.D_Description);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagPMGL.A_FontColor, FXmlTagPMGL.D_FontColor));
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagPMGL.A_FontBold, FXmlTagPMGL.D_FontBold));
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
                    return this.fXmlNode.get_attrVal(FXmlTagPMGL.A_PlcDeviceId, FXmlTagPMGL.D_PlcDeviceId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPMGL.A_PlcDeviceName, FXmlTagPMGL.D_PlcDeviceName);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPMGL.A_PlcSessionId, FXmlTagPMGL.D_PlcSessionId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPMGL.A_PlcSessionName, FXmlTagPMGL.D_PlcSessionName);
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
                    return UInt16.Parse(this.fXmlNode.get_attrVal(FXmlTagPMGL.A_SessionId, FXmlTagPMGL.D_SessionId));
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

        public FLinkMapExpression fLinkMapExpression
        {
            get
            {

                try
                {
                    return FEnumConverter.toLinkMapExpression(
                        this.fXmlNode.get_attrVal(FXmlTagPMGL.A_LinkMapExpression, FXmlTagPMGL.D_LinkMapExpression)
                        );
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FLinkMapExpression.Decimal;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string bitDeviceCode
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagPMGL.A_BitDeviceCode, FXmlTagPMGL.D_BitDeviceCode);
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

        public string bitStartAddress
        {
            get
            {
                try
                {
                    return FPlcValueConverter.toLinkMapValue(
                        this.fLinkMapExpression,
                        this.fXmlNode.get_attrVal(FXmlTagPMGL.A_BitStartAddress, FXmlTagPMGL.D_BitStartAddress)
                        );
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return "0";
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public UInt32 bitStartAddr
        {
            get
            {
                try
                {
                    return UInt32.Parse(this.fXmlNode.get_attrVal(FXmlTagPMGL.A_BitStartAddress, FXmlTagPMGL.D_BitStartAddress));
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

        public string wordDeviceCode
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagPMGL.A_WordDeviceCode, FXmlTagPMGL.D_WordDeviceCode);
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

        public string wordStartAddress
        {
            get
            {
                try
                {
                    return FPlcValueConverter.toLinkMapValue(
                        this.fLinkMapExpression,
                        this.fXmlNode.get_attrVal(FXmlTagPMGL.A_WordStartAddress, FXmlTagPMGL.D_WordStartAddress)
                        );
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return "0";
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public UInt32 wordStartAddr
        {
            get
            {
                try
                {
                    return UInt32.Parse(this.fXmlNode.get_attrVal(FXmlTagPMGL.A_WordStartAddress, FXmlTagPMGL.D_WordStartAddress));
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagPMGL.A_AutoReply, FXmlTagPMGL.D_AutoReply));
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagPMGL.A_AutoReset, FXmlTagPMGL.D_AutoReset));
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagPMGL.A_UsedAutoTrace, FXmlTagPMGL.D_UsedAutoTrace));
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
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagPMGL.A_AutoTracePeriod, FXmlTagPMGL.D_AutoTracePeriod));
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagPMGL.A_LogEnabled, FXmlTagPMGL.D_LogEnabled));
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
                    return FEnumConverter.toLogLevel(this.fXmlNode.get_attrVal(FXmlTagPMGL.A_LogLevel, FXmlTagPMGL.D_LogLevel));
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagPMGL.A_IsPrimary, FXmlTagPMGL.D_IsPrimary));
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
                    return this.fXmlNode.get_attrVal(FXmlTagPMGL.A_UserTag1, FXmlTagPMGL.D_UserTag1);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPMGL.A_UserTag2, FXmlTagPMGL.D_UserTag2);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPMGL.A_UserTag3, FXmlTagPMGL.D_UserTag3);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPMGL.A_UserTag4, FXmlTagPMGL.D_UserTag4);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPMGL.A_UserTag5, FXmlTagPMGL.D_UserTag5);
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

        public FPlcBitListLogCollection fChildPlcBitListLogCollection
        {
            get
            {
                try
                {
                    return new FPlcBitListLogCollection(this.fPcdlCore, this.fXmlNode.selectNodes(FXmlTagPBLL.E_PlcBitList));
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

        public FPlcWordListLogCollection fChildPlcWordListLogCollection
        {
            get
            {
                try
                {
                    return new FPlcWordListLogCollection(this.fPcdlCore, this.fXmlNode.selectNodes(FXmlTagPWLL.E_PlcWordList));
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
                    if (this.fXmlNode.containsNode(FXmlTagPBLL.E_PlcBitList) || this.fXmlNode.containsNode(FXmlTagPWLL.E_PlcWordList))
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

        public FPlcDriverLog fParent
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

                    return this.fPlcDriverLog;
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

                    return FPlcDriverLogCommon.createObjectLog(this.fPcdlCore, this.fXmlNode.fPreviousSibling);
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

                    return FPlcDriverLogCommon.createObjectLog(this.fPcdlCore, this.fXmlNode.fNextSibling);
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
                fXmlNode.set_attrVal(FXmlTagPMGL.A_Time, FXmlTagPMGL.D_Time, FXmlTagPMGL.D_Time);
                fXmlNode.set_attrVal(FXmlTagPMGL.A_ResultCode, FXmlTagPMGL.D_ResultCode, FXmlTagPMGL.D_ResultCode);
                fXmlNode.set_attrVal(FXmlTagPMGL.A_ResultMessage, FXmlTagPMGL.D_ResultMessage, FXmlTagPMGL.D_ResultMessage);                
                // --
                fXmlNode.set_attrVal(FXmlTagPMGL.A_PlcDeviceId, FXmlTagPMGL.D_PlcDeviceId, FXmlTagPMGL.D_PlcDeviceId);
                fXmlNode.set_attrVal(FXmlTagPMGL.A_PlcDeviceName, FXmlTagPMGL.D_PlcDeviceName, FXmlTagPMGL.D_PlcDeviceName);
                fXmlNode.set_attrVal(FXmlTagPMGL.A_PlcSessionId, FXmlTagPMGL.D_PlcSessionId, FXmlTagPMGL.D_PlcSessionId);
                fXmlNode.set_attrVal(FXmlTagPMGL.A_PlcSessionName, FXmlTagPMGL.D_PlcSessionName, FXmlTagPMGL.D_PlcSessionName);
                fXmlNode.set_attrVal(FXmlTagPMGL.A_SessionId, FXmlTagPMGL.D_SessionId, FXmlTagPMGL.D_SessionId);
                // -- 
                FPlcDriverLogCommon.removeLogUniqueId(fXmlNode);
                
                // --

                this.copyObject(FCbObjectFormat.PlcMessages, fXmlNode);
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

        public FPlcBitListLogCollection selectPlcBitListLogByName(
            string name
            )
        {
            const string xpath = FXmlTagPBLL.E_PlcBitList + "[@" + FXmlTagPBLL.A_Name + "='{0}']";

            try
            {
                return new FPlcBitListLogCollection(
                    this.fPcdlCore,
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

        public FPlcBitListLog selectSinglePlcBitListLogByName(
            string name
            )
        {
            const string xpath = FXmlTagPBLL.E_PlcBitList + "[@" + FXmlTagPBLL.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FPlcBitListLog(this.fPcdlCore, fXmlNode);
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

        public FPlcWordListLogCollection selectPlcWordListLogByName(
            string name
            )
        {
            const string xpath = FXmlTagPWLL.E_PlcWordList + "[@" + FXmlTagPWLL.A_Name + "='{0}']";

            try
            {
                return new FPlcWordListLogCollection(
                    this.fPcdlCore,
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

        public FPlcWordListLog selectSinglePlcWordListLogByName(
            string name
            )
        {
            const string xpath = FXmlTagPWLL.E_PlcWordList + "[@" + FXmlTagPWLL.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FPlcWordListLog(this.fPcdlCore, fXmlNode);
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

        public FPlcBitLogCollection selectPlcBitLogByName(
            string name
            )
        {
            const string xpath = FXmlTagPBLL.E_PlcBitList + "/" +
                FXmlTagPBTL.E_PlcBit + "[@" + FXmlTagPBTL.A_Name + "='{0}']";

            try
            {
                return new FPlcBitLogCollection(
                    this.fPcdlCore,
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

        public FPlcBitLog selectSinglePlcBitLogByName(
            string name
            )
        {
            const string xpath = FXmlTagPBLL.E_PlcBitList +
                "/" + FXmlTagPBTL.E_PlcBit + "[@" + FXmlTagPBTL.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FPlcBitLog(this.fPcdlCore, fXmlNode);

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

        public FPlcWordLogCollection selectPlcWordLogByName(
            string name
            )
        {
            const string xpath = FXmlTagPWLL.E_PlcWordList + "/" +
                FXmlTagPWDL.E_PlcWord + "[@" + FXmlTagPWDL.A_Name + "='{0}']";

            try
            {
                return new FPlcWordLogCollection(
                    this.fPcdlCore,
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

        public FPlcWordLog selectSinglePlcWordLogByName(
            string name
            )
        {
            const string xpath = FXmlTagPWLL.E_PlcWordList + "/" +
                FXmlTagPWDL.E_PlcWord + "[@" + FXmlTagPWDL.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FPlcWordLog(this.fPcdlCore, fXmlNode);

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
