/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecsDeviceLog.cs
--  Creator         : spike.lee
--  Create Date     : 2011.09.06
--  Description     : FAMate Core FaSecsDriver SECS Device Log Class 
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
    public abstract class FSecsDeviceLog<T> : FBaseObjectLog<T>, FIObjectLog
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FSecsDeviceLog(      
            FXmlNode fXmlNode      
            )
            : base(fXmlNode)
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FSecsDeviceLog(
            FScdlCore fScdlCore, 
            FXmlNode fXmlNode
            )
            : base(fScdlCore, fXmlNode)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSecsDeviceLog(
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
                    return this.fXmlNode.get_attrVal(FXmlTagSDVL.A_LogUniqueId, FXmlTagSDVL.D_LogUniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSDVL.A_Time, FXmlTagSDVL.D_Time);
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
                    return FEnumConverter.toResultCode(this.fXmlNode.get_attrVal(FXmlTagSDVL.A_ResultCode, FXmlTagSDVL.D_ResultCode));
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
                    return this.fXmlNode.get_attrVal(FXmlTagSDVL.A_ResultMessage, FXmlTagSDVL.D_ResultMessage);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSDVL.A_UniqueId, FXmlTagSDVL.D_UniqueId);
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
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSDVL.A_Index, FXmlTagSDVL.D_Index));
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
                    return this.fXmlNode.get_attrVal(FXmlTagSDVL.A_Name, FXmlTagSDVL.D_Name);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSDVL.A_Description, FXmlTagSDVL.D_Description);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagSDVL.A_FontColor, FXmlTagSDVL.D_FontColor));
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSDVL.A_FontBold, FXmlTagSDVL.D_FontBold));
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

        public FDeviceMode fDeviceMode
        {
            get
            {
                try
                {
                    return (FDeviceMode)Enum.Parse(typeof(FDeviceMode), this.fXmlNode.get_attrVal(FXmlTagSDVL.A_Mode, FXmlTagSDVL.D_Mode));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FDeviceMode.Both;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FProtocol fProtocol
        {
            get
            {
                try
                {
                    return (FProtocol)Enum.Parse(typeof(FProtocol), this.fXmlNode.get_attrVal(FXmlTagSDVL.A_Protocol, FXmlTagSDVL.D_Protocol));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FProtocol.HSMS;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FConnectMode fConnectMode
        {
            get
            {
                try
                {
                    return (FConnectMode)Enum.Parse(typeof(FConnectMode), this.fXmlNode.get_attrVal(FXmlTagSDVL.A_ConnectMode, FXmlTagSDVL.D_ConnectMode));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FConnectMode.Active;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string localIp
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSDVL.A_LocalIp, FXmlTagSDVL.D_LocalIp);
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

        public int localPort
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSDVL.A_LocalPort, FXmlTagSDVL.D_LocalPort));
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

        public string remoteIp
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSDVL.A_RemoteIp, FXmlTagSDVL.D_RemoteIp);
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

        public int remotePort
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSDVL.A_RemotePort, FXmlTagSDVL.D_RemotePort));
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

        public string serialPort
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSDVL.A_SerialPort, FXmlTagSDVL.D_SerialPort);
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

        public int baud
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSDVL.A_Baud, FXmlTagSDVL.D_Baud));
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

        public bool rbit
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSDVL.A_RBit, FXmlTagSDVL.D_RBit));
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

        public bool interleave
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSDVL.A_Interleave, FXmlTagSDVL.D_Interleave));
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

        public bool duplicateError
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSDVL.A_DuplicateError, FXmlTagSDVL.D_DuplicateError));
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

        public bool ignoreSystemBytes
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSDVL.A_IgnoreSytemBytes, FXmlTagSDVL.D_IgnoreSytemBytes));
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

        public int linkTestTimePeriod
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSDVL.A_LinkTestPeriod, FXmlTagSDVL.D_LinkTestPeriod));
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

        public int retryLimit
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSDVL.A_RetryLimit, FXmlTagSDVL.D_RetryLimit));
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

        public float t1Timeout
        {
            get
            {
                try
                {
                    return float.Parse(this.fXmlNode.get_attrVal(FXmlTagSDVL.A_T1Timeout, FXmlTagSDVL.D_T1Timeout));
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

        public float t2Timeout
        {
            get
            {
                try
                {
                    return float.Parse(this.fXmlNode.get_attrVal(FXmlTagSDVL.A_T2Timeout, FXmlTagSDVL.D_T2Timeout));
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

        public int t3Timeout
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSDVL.A_T3Timeout, FXmlTagSDVL.D_T3Timeout));
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

        public int t4Timeout
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSDVL.A_T4Timeout, FXmlTagSDVL.D_T4Timeout));
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

        public int t5Timeout
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSDVL.A_T5Timeout, FXmlTagSDVL.D_T5Timeout));
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

        public int t6Timeout
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSDVL.A_T6Timeout, FXmlTagSDVL.D_T6Timeout));
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

        public int t7Timeout
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSDVL.A_T7Timeout, FXmlTagSDVL.D_T7Timeout));
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

        public int t8Timeout
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSDVL.A_T8Timeout, FXmlTagSDVL.D_T8Timeout));
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

        public string userTag1
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSDVL.A_UserTag1, FXmlTagSDVL.D_UserTag1);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSDVL.A_UserTag2, FXmlTagSDVL.D_UserTag2);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSDVL.A_UserTag3, FXmlTagSDVL.D_UserTag3);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSDVL.A_UserTag4, FXmlTagSDVL.D_UserTag4);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSDVL.A_UserTag5, FXmlTagSDVL.D_UserTag5);
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

        public FDeviceState fState
        {
            get
            {
                try
                {
                    return FEnumConverter.toDeviceState(this.fXmlNode.get_attrVal(FXmlTagSDVL.A_State, FXmlTagSDVL.D_State));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FDeviceState.Closed;
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

        public abstract string ToString(
            FStringOption option
            );

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
