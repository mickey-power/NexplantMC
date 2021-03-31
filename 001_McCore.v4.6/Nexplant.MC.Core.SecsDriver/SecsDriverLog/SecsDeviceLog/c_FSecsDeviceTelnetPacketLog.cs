/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecsDeviceTelnetPacketLog.cs
--  Creator         : byungyun.jeon
--  Create Date     : 2012.02.08
--  Description     : FAMate Core FaSecsDriver SECS Device Telnet Packet Log Base Class 
--  History         : Created by byungyun.jeon at 2012.02.08
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public abstract class FSecsDeviceTelnetPacketLog<T> : FBaseObjectLog<T>, FIObjectLog
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction
        
        internal FSecsDeviceTelnetPacketLog(      
            FXmlNode fXmlNode      
            )
            : base(fXmlNode)
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FSecsDeviceTelnetPacketLog(
            FScdlCore fScdlCore, 
            FXmlNode fXmlNode
            )
            : base(fScdlCore, fXmlNode)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSecsDeviceTelnetPacketLog(
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

        public string logUniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSTPL.A_LogUniqueId, FXmlTagSTPL.D_LogUniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSTPL.A_Time, FXmlTagSTPL.D_Time);
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
                    return FEnumConverter.toResultCode(this.fXmlNode.get_attrVal(FXmlTagSTPL.A_ResultCode, FXmlTagSTPL.D_ResultCode));
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
                    return this.fXmlNode.get_attrVal(FXmlTagSTPL.A_ResultMessage, FXmlTagSTPL.D_ResultMessage);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSTPL.A_UniqueId, FXmlTagSTPL.D_UniqueId);
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

        public int index
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSTPL.A_Index, FXmlTagSTPL.D_Index));
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
                    return this.fXmlNode.get_attrVal(FXmlTagSTPL.A_Name, FXmlTagSTPL.D_Name);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSTPL.A_Description, FXmlTagSTPL.D_Description);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagSTPL.A_FontColor, FXmlTagSTPL.D_FontColor));
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSTPL.A_FontBold, FXmlTagSTPL.D_FontBold));
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

        public FTelnetPacketType fPacketType
        {
            get
            {
                try
                {
                    return FEnumConverter.toTelnetPacketType(this.fXmlNode.get_attrVal(FXmlTagSTPL.A_PacketType, FXmlTagSTPL.D_PacketType));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FTelnetPacketType.Data;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTelnetCommand fCommand
        {
            get
            {
                try
                {
                    return FEnumConverter.toTelnetCommand(this.fXmlNode.get_attrVal(FXmlTagSTPL.A_TelnetCommand, FXmlTagSTPL.D_TelnetCommand));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FTelnetCommand.NoOperation;
            }

        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTelnetOption fOption
        {
            get
            {
                try
                {
                    return FEnumConverter.toTelnetOption(this.fXmlNode.get_attrVal(FXmlTagSTPL.A_TelnetOption, FXmlTagSTPL.D_TelnetOption));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FTelnetOption.TransmitBinary;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        public string originalStringValue
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSTPL.A_TelnetData, FXmlTagSTPL.D_TelnetData);
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

        public string originalEncodingValue
        {
            get
            {
                string value = string.Empty;
                List<byte> byteValueList = null;

                try
                {
                    value = FValueConverter.toEncodingValue(FFormat.Binary, this.originalStringValue);

                    // -- 

                    if (value == string.Empty)
                    {
                        return string.Empty;
                    }

                    // -- 

                    byteValueList = new List<byte>();
                    foreach (string s in value.Split(' '))
                    {
                        byteValueList.Add(byte.Parse(s));
                    }

                    return Encoding.Default.GetString(byteValueList.ToArray());
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
                    return this.fXmlNode.get_attrVal(FXmlTagSDHL.A_UserTag1, FXmlTagSDHL.D_UserTag1);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSDHL.A_UserTag2, FXmlTagSDHL.D_UserTag2);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSDHL.A_UserTag3, FXmlTagSDHL.D_UserTag3);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSDHL.A_UserTag4, FXmlTagSDHL.D_UserTag4);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSDHL.A_UserTag5, FXmlTagSDHL.D_UserTag5);
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

        public bool hasChild
        {
            get
            {
                try
                {
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

        public FSecsDriverLog fParent
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null)
                    {

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
                    info = "[" + this.time + "] " + this.name; 
                    //--
                    if (this.fPacketType == FTelnetPacketType.Option)
                    {
                        info += (" Packet=[" + this.fPacketType.ToString() + "] " + this.fCommand.ToString() + " " + this.fOption.ToString());
                    }
                    else if (this.fPacketType == FTelnetPacketType.Command)
                    {
                        info += (" Packet=[" + this.fPacketType.ToString() + "] " + this.fCommand.ToString());
                    }
                    else if (this.fPacketType == FTelnetPacketType.Data)
                    {
                        info += (" Packet=[" + this.fPacketType.ToString() + "] " + this.originalEncodingValue);
                    }
                    else if (this.fPacketType == FTelnetPacketType.Subnegotiation)
                    {
                        info += (" Packet=[" + this.fPacketType.ToString() + "] ");
                    }
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------
        
    }   // Class end
}   // Namespace end