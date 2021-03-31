/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecsDevice.cs
--  Creator         : spike.lee
--  Create Date     : 2011.03.14
--  Description     : FAMate Core FaSecsDriver SECS Device Class 
--  History         : Created by spike.lee at 2011.03.14
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public class FSecsDevice : FBaseObject<FSecsDevice>, FIObject, FIDevice
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecsDevice(
            FSecsDriver fSecsDriver
            )
            : base(fSecsDriver.fScdCore, FSecsDriverCommon.createXmlNodeSDV(fSecsDriver.fScdCore.fXmlDoc))
        {
            // init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FSecsDevice(
            FScdCore fScdCore,
            FXmlNode fXmlNode
            )
            : base(fScdCore, fXmlNode)
        {
            // init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSecsDevice(
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
                    // term();
                }

                term();
                m_disposed = true;

                // --
                
                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FObjectType fObjectType
        {
            get
            {
                try
                {
                    return FObjectType.SecsDevice;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.SecsDriver;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDeviceType fDeviceType
        {
            get
            {
                try
                {
                    return FDeviceType.SecsDevice;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FDeviceType.SecsDevice;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSDV.A_UniqueId, FXmlTagSDV.D_UniqueId);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSDV.A_Locked, FXmlTagSDV.D_Locked));
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

        public int index
        {
            get
            {
                try
                {
                    return this.fXmlNode.getIndex(false);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSDV.A_Name, FXmlTagSDV.D_Name);
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

            set
            {
                try
                {
                    FSecsDriverCommon.validateName(value, true);

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_Name, FXmlTagSDV.D_Name, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string description
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSDV.A_Description, FXmlTagSDV.D_Description);
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

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_Description, FXmlTagSDV.D_Description, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public Color fontColor
        {
            get
            {
                try
                {
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagSDV.A_FontColor, FXmlTagSDV.D_FontColor));
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

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_FontColor, FXmlTagSDV.D_FontColor, value.Name, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool fontBold
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSDV.A_FontBold, FXmlTagSDV.D_FontBold));
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

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_FontBold, FXmlTagSDV.D_FontBold, FBoolean.fromBool(value), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDeviceMode fDeviceMode
        {
            get
            {
                try
                {
                    return (FDeviceMode)Enum.Parse(typeof(FDeviceMode), this.fXmlNode.get_attrVal(FXmlTagSDV.A_Mode, FXmlTagSDV.D_Mode));
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

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_Mode, FXmlTagSDV.D_Mode, value.ToString(), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FProtocol fProtocol
        {
            get
            {
                try
                {
                    return (FProtocol)Enum.Parse(typeof(FProtocol), this.fXmlNode.get_attrVal(FXmlTagSDV.A_Protocol, FXmlTagSDV.D_Protocol));
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

            set
            {
                try
                {
                    validateStateCheck();
                    
                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_Protocol, FXmlTagSDV.D_Protocol, value.ToString(), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FConnectMode fConnectMode
        {
            get
            {
                try
                {
                    return (FConnectMode)Enum.Parse(typeof(FConnectMode), this.fXmlNode.get_attrVal(FXmlTagSDV.A_ConnectMode, FXmlTagSDV.D_ConnectMode));
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

            set
            {
                try
                {
                    validateStateCheck();

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_ConnectMode, FXmlTagSDV.D_ConnectMode, value.ToString(), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string localIp
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSDV.A_LocalIp, FXmlTagSDV.D_LocalIp);
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

            set
            {
                try
                {
                    if (value.Trim() == string.Empty)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Local IP"));
                    }

                    // --

                    validateStateCheck();

                    // --
                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_LocalIp, FXmlTagSDV.D_LocalIp, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int localPort
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSDV.A_LocalPort, FXmlTagSDV.D_LocalPort));
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

            set
            {
                try
                {
                    if (value < 0 || value > 65535)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Local Port"));
                    }
                    
                    // --

                    validateStateCheck();

                    // --
                    
                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_LocalPort, FXmlTagSDV.D_LocalPort, value.ToString(), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string remoteIp
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSDV.A_RemoteIp, FXmlTagSDV.D_RemoteIp);
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

            set
            {
                try
                {
                    if (value.Trim() == string.Empty)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Remote IP"));
                    }

                    // --

                    validateStateCheck();

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_RemoteIp, FXmlTagSDV.D_RemoteIp, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int remotePort
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSDV.A_RemotePort, FXmlTagSDV.D_RemotePort));
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

            set
            {
                try
                {
                    if (value < 0 || value > 65535)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Remote Port"));
                    }

                    // --

                    validateStateCheck();

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_RemotePort, FXmlTagSDV.D_RemotePort, value.ToString(), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string serialPort
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSDV.A_SerialPort, FXmlTagSDV.D_SerialPort);
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

            set
            {
                try
                {
                    if (value.Trim() == string.Empty)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Serial Port"));
                    }

                    // --
                    
                    validateStateCheck();

                    // --
                    
                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_SerialPort, FXmlTagSDV.D_SerialPort, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int baud
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSDV.A_Baud, FXmlTagSDV.D_Baud));
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

            set
            {
                try
                {
                    if (value < 1)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Baud"));
                    }

                    // --

                    validateStateCheck();

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_Baud, FXmlTagSDV.D_Baud, value.ToString(), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool rbit
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSDV.A_RBit, FXmlTagSDV.D_RBit));
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

            set
            {
                try
                {
                    validateStateCheck();

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_RBit, FXmlTagSDV.D_RBit, FBoolean.fromBool(value), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool interleave
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSDV.A_Interleave, FXmlTagSDV.D_Interleave));
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

            set
            {
                try
                {
                    validateStateCheck();

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_Interleave, FXmlTagSDV.D_Interleave, FBoolean.fromBool(value), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool duplicateError
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSDV.A_DuplicateError, FXmlTagSDV.D_DuplicateError));
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

            set
            {
                try
                {
                    validateStateCheck();

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_DuplicateError, FXmlTagSDV.D_DuplicateError, FBoolean.fromBool(value), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool ignoreSystemBytes
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSDV.A_IgnoreSytemBytes, FXmlTagSDV.D_IgnoreSytemBytes));
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

            set
            {
                try
                {
                    validateStateCheck();

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_IgnoreSytemBytes, FXmlTagSDV.D_IgnoreSytemBytes, FBoolean.fromBool(value), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int linkTestTimePeriod
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSDV.A_LinkTestPeriod, FXmlTagSDV.D_LinkTestPeriod));
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

            set
            {
                try
                {
                    if (value < 0 || value > 240)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Link-Test Time Period"));
                    }

                    // --

                    validateStateCheck();

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_LinkTestPeriod, FXmlTagSDV.D_LinkTestPeriod, value.ToString(), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int retryLimit
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSDV.A_RetryLimit, FXmlTagSDV.D_RetryLimit));
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

            set
            {
                try
                {
                    if (value < 0 || value > 31)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Retry Limit"));
                    }

                    validateStateCheck();

                    // --

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_RetryLimit, FXmlTagSDV.D_RetryLimit, value.ToString(), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public uint maxSystemBytes
        {
            get
            {
                try
                {
                    return uint.Parse(this.fXmlNode.get_attrVal(FXmlTagSDV.A_MaxSystemBytes, FXmlTagSDV.D_MaxSystemBytes));
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

            set
            {
                try
                {
                    if (value < 0 || value > UInt32.MaxValue)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Max System Bytes"));
                    }

                    // --
                    validateStateCheck();

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_MaxSystemBytes, FXmlTagSDV.D_MaxSystemBytes, value.ToString(), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public float t1Timeout
        {
            get
            {
                try
                {
                    return float.Parse(this.fXmlNode.get_attrVal(FXmlTagSDV.A_T1Timeout, FXmlTagSDV.D_T1Timeout));
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

            set
            {
                try
                {
                    if (value < 0.1F || value > 10.0F)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "T1 Timeout"));
                    }

                    // --

                    validateStateCheck();

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_T1Timeout, FXmlTagSDV.D_T1Timeout, value.ToString(), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public float t2Timeout
        {
            get
            {
                try
                {
                    return float.Parse(this.fXmlNode.get_attrVal(FXmlTagSDV.A_T2Timeout, FXmlTagSDV.D_T2Timeout));
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

            set
            {
                try
                {
                    if (value < 0.2F || value > 25.0F)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "T2 Timeout"));
                    }

                    // --
                    
                    validateStateCheck();

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_T2Timeout, FXmlTagSDV.D_T2Timeout, value.ToString(), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int t3Timeout
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSDV.A_T3Timeout, FXmlTagSDV.D_T3Timeout));
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

            set
            {
                try
                {
                    if (value < 1 || value > 120)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "T3 Timeout"));
                    }

                    // --

                    validateStateCheck();

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_T3Timeout, FXmlTagSDV.D_T3Timeout, value.ToString(), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int t4Timeout
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSDV.A_T4Timeout, FXmlTagSDV.D_T4Timeout));
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

            set
            {
                try
                {
                    if (value < 1 || value > 120)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "T4 Timeout"));
                    }

                    // --

                    validateStateCheck();

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_T4Timeout, FXmlTagSDV.D_T4Timeout, value.ToString(), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int t5Timeout
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSDV.A_T5Timeout, FXmlTagSDV.D_T5Timeout));
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

            set
            {
                try
                {
                    if (value < 1 || value > 240)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "T5 Timeout"));
                    }

                    // --

                    validateStateCheck();

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_T5Timeout, FXmlTagSDV.D_T5Timeout, value.ToString(), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int t6Timeout
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSDV.A_T6Timeout, FXmlTagSDV.D_T6Timeout));
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

            set
            {
                try
                {
                    if (value < 1 || value > 240)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "T6 Timeout"));
                    }

                    // --

                    validateStateCheck();

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_T6Timeout, FXmlTagSDV.D_T6Timeout, value.ToString(), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int t7Timeout
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSDV.A_T7Timeout, FXmlTagSDV.D_T7Timeout));
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

            set
            {
                try
                {
                    if (value < 1 || value > 240)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "T7 Timeout"));
                    }

                    // --

                    validateStateCheck();

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_T7Timeout, FXmlTagSDV.D_T7Timeout, value.ToString(), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int t8Timeout
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSDV.A_T8Timeout, FXmlTagSDV.D_T8Timeout));
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

            set
            {
                try
                {
                    if (value < 1 || value > 120)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "T8 Timeout"));
                    }

                    // --

                    validateStateCheck();

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_T8Timeout, FXmlTagSDV.D_T8Timeout, value.ToString(), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag1
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSDV.A_UserTag1, FXmlTagSDV.D_UserTag1);
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

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_UserTag1, FXmlTagSDV.D_UserTag1, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag2
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSDV.A_UserTag2, FXmlTagSDV.D_UserTag2);
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

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_UserTag2, FXmlTagSDV.D_UserTag2, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag3
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSDV.A_UserTag3, FXmlTagSDV.D_UserTag3);
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

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_UserTag3, FXmlTagSDV.D_UserTag3, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag4
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSDV.A_UserTag4, FXmlTagSDV.D_UserTag4);
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

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_UserTag4, FXmlTagSDV.D_UserTag4, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag5
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSDV.A_UserTag5, FXmlTagSDV.D_UserTag5);
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

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagSDV.A_UserTag5, FXmlTagSDV.D_UserTag5, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        public string defUserTagName1
        {
            get
            {
                try
                {
                    return this.getDefUserTagName(1);
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

        public string defUserTagName2
        {
            get
            {
                try
                {
                    return this.getDefUserTagName(2);
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

        public string defUserTagName3
        {
            get
            {
                try
                {
                    return this.getDefUserTagName(3);
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

        public string defUserTagName4
        {
            get
            {
                try
                {
                    return this.getDefUserTagName(4);
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

        public string defUserTagName5
        {
            get
            {
                try
                {
                    return this.getDefUserTagName(5);
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

        public FSecsDriver fParent
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

                    return this.fSecsDriver;
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

        public FSecsDevice fPreviousSibling
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

                    return new FSecsDevice(this.fScdCore, this.fXmlNode.fPreviousSibling);
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

        public FSecsDevice fNextSibling
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

                    return new FSecsDevice(this.fScdCore, this.fXmlNode.fNextSibling);
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

        public FSecsSessionCollection fChildSecsSessionCollection
        {
            get
            {
                try
                {
                    return new FSecsSessionCollection(this.fScdCore, this.fXmlNode.selectNodes(FXmlTagSSN.E_SecsSession));
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

        public FObjectNameCollection fObjectNameCollection
        {
            get
            {
                try
                {
                    return this.getObjectNameCollection();
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

        public FObjectCollection fReferenceObjectCollection
        {
            get
            {
                string xpath = string.Empty;

                try
                {
                    xpath =
                        "../../" + FXmlTagEQM.E_EquipmentModeling +
                        "/" + FXmlTagEQP.E_Equipment +
                        "/" + FXmlTagSNG.E_ScenarioGroup +
                        "/" + FXmlTagSNR.E_Scenario +
                        "/" + FXmlTagSTR.E_SecsTrigger +
                        "/" + FXmlTagSCN.E_SecsCondition + "[@" + FXmlTagSCN.A_SecsDeviceId + "='" + this.uniqueIdToString + "']" +
                        " | " +
                        "../../" + FXmlTagEQM.E_EquipmentModeling +
                        "/" + FXmlTagEQP.E_Equipment +
                        "/" + FXmlTagSNG.E_ScenarioGroup +
                        "/" + FXmlTagSNR.E_Scenario +
                        "/" + FXmlTagSTN.E_SecsTransmitter +
                        "/" + FXmlTagSTF.E_SecsTransfer + "[@" + FXmlTagSTF.A_SecsDeviceId + "='" + this.uniqueIdToString + "']";
                    // --
                    return new FObjectCollection(this.fScdCore, this.fXmlNode.selectNodes(xpath));
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

        public FObjectCollection fInclusionObjectCollection
        {
            get
            {
                try
                {
                    return new FObjectCollection(this.fScdCore, this.fXmlNode.selectNodes("NULL"));
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
                    return this.fXmlNode.containsNode(FXmlTagSSN.E_SecsSession);
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

        public bool canAppendChild
        {
            get
            {
                try
                {
                    return true;
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

        //-----------------------------------------------------------------------------------------------------------------------

        public bool canInsertBefore
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null)
                    {
                        return false;
                    }
                    return true;
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

        public bool canInsertAfter
        {
            get
            {
                try
                {
                    return this.canInsertBefore;
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

        public bool canRemove
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null || this.locked || this.fState != FDeviceState.Closed)
                    {
                        return false;
                    }
                    return true;
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

        public bool canMoveUp
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null || this.fXmlNode.fPreviousSibling == null)
                    {
                        return false;
                    }
                    return true;
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

        public bool canMoveDown
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null || this.fXmlNode.fNextSibling == null)
                    {
                        return false;
                    }
                    return true;
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

        public bool canCut
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null || this.locked || this.fState != FDeviceState.Closed)
                    {
                        return false;
                    }
                    return true;
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

        public bool canCopy
        {
            get
            {
                try
                {
                    return true;
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

        public bool canPasteSibling
        {
            get
            {
                try
                {
                    if (
                        this.fXmlNode.fParentNode == null ||
                        !FClipboard.containsData(FCbObjectFormat.SecsDevice)
                        )
                    {
                        return false;
                    }
                    return true;
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

        public bool canPasteChild
        {
            get
            {
                try
                {
                    if (!FClipboard.containsData(FCbObjectFormat.SecsSession))
                    {
                        return false;
                    }
                    return true;
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

        public FDeviceState fState
        {
            get
            {
                try
                {
                    return FEnumConverter.toDeviceState(this.fXmlNode.get_attrVal(FXmlTagSDV.A_State, FXmlTagSDV.D_State));
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        internal void init(
            )
        {
            try
            {
                this.fScdCore.ModelingFileChanged += new FModelingFileChangedEventHandler(fScdCore_ModelingFileChanged);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }       

        //------------------------------------------------------------------------------------------------------------------------

        internal void term(
            )
        {
            try
            {
                this.fScdCore.ModelingFileChanged -= new FModelingFileChangedEventHandler(fScdCore_ModelingFileChanged);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

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
                    info = this.name + " Protocol=[" + this.fProtocol.ToString() + "]";
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

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsSession appendChildSecsSession(
            FSecsSession fNewChild
            )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, this.fXmlNode.appendChild(fNewChild.fXmlNode));                
                // --                
                if (this.isModelingObject)
                {
                    FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectAppendCompleted, this.fSecsDriver, this, fNewChild)
                        );
                }

                // --

                return fNewChild;
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

        public FSecsSession insertBeforeChildSecsSession(
            FSecsSession fNewChild,
            FSecsSession fRefChild
            )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, this.fXmlNode.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                // --                
                if (this.isModelingObject)
                {
                    FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectInsertBeforeCompleted, this.fSecsDriver, this, fNewChild)
                        );
                }

                // --

                return fNewChild;
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

        public FSecsSession insertAfterChildSecsSession(
            FSecsSession fNewChild,
            FSecsSession fRefChild
            )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, this.fXmlNode.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                // --                
                if (this.isModelingObject)
                {
                    FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this.fSecsDriver, this, fNewChild)
                        );
                }

                // --

                return fNewChild;
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

        public void remove(
            )
        {
            FIObject fParent = null;
            bool isModelingObject = false;

            try
            {
                FSecsDriverCommon.validateRemoveChildObject(this.fXmlNode.fParentNode, this.fXmlNode);
                validateStateCheck();

                // --

                resetRelation();

                // --

                fParent = this.fParent;
                isModelingObject = this.isModelingObject;
                this.replace(this.fScdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));                

                // --

                if (isModelingObject)
                {
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectRemoveCompleted, this.fSecsDriver, fParent, this)
                        );
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fParent = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsSession removeChildSecsSession(
            FSecsSession fChild
            )
        {
            try
            {
                FSecsDriverCommon.validateRemoveChildObject(this.fXmlNode, fChild.fXmlNode);

                // --
                
                fChild.remove();
                
                // --
                
                return fChild;
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

        public void removeChildSecsSession(
            FSecsSession[] fChilds
            )
        {
            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                foreach (FSecsSession fSsn in fChilds)
                {
                    FSecsDriverCommon.validateRemoveChildObject(this.fXmlNode, fSsn.fXmlNode);
                }

                // --

                foreach (FSecsSession fSsn in fChilds)
                {
                    fSsn.remove();
                }                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeAllChildSecsSession(
            )
        {
            FSecsSessionCollection fSsnCollection = null;

            try
            {
                fSsnCollection = this.fChildSecsSessionCollection;
                if (fSsnCollection.count == 0)
                {
                    return;
                }                

                // --

                foreach (FSecsSession fSsn in fSsnCollection)
                {
                    if (fSsn.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }
                }

                // --

                foreach (FSecsSession fSsn in fSsnCollection)
                {
                    fSsn.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fSsnCollection != null)
                {
                    fSsnCollection.Dispose();
                    fSsnCollection = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void resetRelation(
            )
        {
            try
            {
                foreach (FSecsSession fSsn in this.fChildSecsSessionCollection)
                {
                    fSsn.resetRelation();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void moveUp(
            )
        {
            bool isModelingObject = false;

            try
            {
                FSecsDriverCommon.validateMoveUpObject(this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fScdCore, this.fXmlNode.moveUp());

                // --

                if (isModelingObject)
                {
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveUpCompleted, this.fSecsDriver, fParent, this)
                        );
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void moveDown(
            )
        {
            bool isModelingObject = false;

            try
            {
                FSecsDriverCommon.validateMoveDownObject(this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fScdCore, this.fXmlNode.moveDown());

                // --

                if (isModelingObject)
                {
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveDownCompleted, this.fSecsDriver, fParent, this)
                        );
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void moveTo(
            FSecsDevice fRefObject
            )
        {
            try
            {
                FSecsDriverCommon.validateMoveToObject(this.fXmlNode, fRefObject.fXmlNode);

                // --

                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Object", "Modeling Object"));
                }

                if (!fRefObject.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Reference Object", "Modeling Object"));
                }

                if (!this.equalsModelingFile(fRefObject))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Modeling File", "same"));
                }

                // --                

                this.replace(this.fScdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fScdCore, fRefObject.fXmlNode.fParentNode.insertAfter(this.fXmlNode, fRefObject.fXmlNode));

                // --

                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fSecsDriver, this, fRefObject)
                    );
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void lockObject(
            )
        {
            try
            {
                if (this.locked)
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagSDV.A_Locked, FXmlTagSDV.D_Locked, FBoolean.True, true);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void unlockObject(
            )
        {
            string xpath = string.Empty;

            try
            {
                if (!this.locked)
                {
                    return;
                }

                // ---

                // ***
                // Lock이 설정되어 있는 자식 SECS Session이 존재할 경우 Unlock 작업을 취소한다.
                // --
                // 2013.08.12 by spike.lee
                // SECS Condition에 Device가 설정되어 있는지 검색하는 XPath 수정
                // SECS Device 내에서 검색하는 것이 아니라 SECS Driver에서 XPath 검색을 수정하도록 처리
                // ***
                xpath = FXmlTagSSN.E_SecsSession + "[@" + FXmlTagSSN.A_Locked + "='" + FBoolean.True + "']" +
                    " | " +
                    "../../" + FXmlTagEQM.E_EquipmentModeling +
                    "/" + FXmlTagEQP.E_Equipment +
                    "/" + FXmlTagSNG.E_ScenarioGroup +
                    "/" + FXmlTagSNR.E_Scenario +
                    "/" + FXmlTagSTR.E_SecsTrigger +
                    "/" + FXmlTagSCN.E_SecsCondition + "[@" + FXmlTagSCN.A_SecsDeviceId + "='" + this.uniqueIdToString + "']";
                // --
                if (this.fXmlNode.containsNode(xpath))
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagSDV.A_Locked, FXmlTagSDV.D_Locked, FBoolean.False, true);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void open(
            )
        {
            try
            {
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "SECS Device", "Modeling File"));
                }

                // --

                if (this.fState != FDeviceState.Closed)
                {
                    return;
                }

                // --

                this.fScdCore.fProtocolAgent.openSecsDevice(this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void close(
            )
        {
            try
            {
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "SECS Device", "Modeling File"));
                }

                // --

                if (this.fState == FDeviceState.Closed)
                {
                    return;
                }

                // --

                this.fScdCore.fProtocolAgent.closeSecsDevice(this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void changeState(
            FDeviceState fState
            )
        {
            try
            {
                if (this.fState == fState)
                {
                    return;
                }
                this.fXmlNode.set_attrVal(FXmlTagSDV.A_State, FXmlTagSDV.D_State, FEnumConverter.fromDeviceState(fState));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void cut(
            )
        {
            try
            {
                FSecsDriverCommon.validateCutObject(this.fXmlNode);

                // --

                this.remove();
                this.copyObject(FCbObjectFormat.SecsDevice, this.fXmlNode);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
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

                this.copyObject(FCbObjectFormat.SecsDevice, fXmlNode);
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

        public FSecsDevice pasteSibling(
            )
        {
            FSecsDevice fSecsDevice = null;

            try
            {
                FSecsDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.SecsDevice);

                // --
                
                fSecsDevice = (FSecsDevice)this.pasteObject(FCbObjectFormat.SecsDevice);
                // --
                fSecsDevice.changeState(FDeviceState.Closed);                
                // -- 
                foreach (FSecsSession fSsn in fSecsDevice.fChildSecsSessionCollection)
                {
                    fSsn.fXmlNode.set_attrVal(FXmlTagSSN.A_SecsLibraryId, FXmlTagSSN.D_SecsLibraryId, "");
                }
                return this.fParent.insertAfterChildSecsDevice(fSecsDevice, this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecsDevice = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsSession pasteChild(
            )
        {
            FSecsSession fSecsSession = null;

            try
            {
                FSecsDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.SecsSession);

                // --

                fSecsSession = (FSecsSession)this.pasteObject(FCbObjectFormat.SecsSession);                
                this.appendChildSecsSession(fSecsSession);
                fSecsSession.fXmlNode.set_attrVal(FXmlTagSSN.A_SecsLibraryId, FXmlTagSSN.D_SecsLibraryId, "");
                return fSecsSession;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecsSession = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        private void validateStateCheck(
            )
        {
            try
            {
                if (fState != FDeviceState.Closed)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0027, "Device"));
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsSessionCollection selectSecsSessionByName(
            string name
            )
        {
            const string xpath = FXmlTagSSN.E_SecsSession + "[@" + FXmlTagSSN.A_Name + "='{0}']";

            try
            {
                return new FSecsSessionCollection(
                    this.fScdCore,
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

        public FSecsSession selectSingleSecsSessionByName(
            string name
            )
        {
            const string xpath = FXmlTagSSN.E_SecsSession + "[@" + FXmlTagSSN.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsSession(this.fScdCore, fXmlNode);
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

        #region fScdCore Object Event Handler

        private void fScdCore_ModelingFileChanged(
            object sender, 
            FModelingFileChangedEventArgs e
            )
        {
            const string xpath =
                FXmlTagSDM.E_SecsDeviceModeling +
                "/" + FXmlTagSDV.E_SecsDevice + "[@" + FXmlTagSDV.A_UniqueId + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fScdCore.fXmlNodeScd.selectSingleNode(string.Format(xpath, this.uniqueIdToString));
                fXmlNode.set_attrVal(FXmlTagSDV.A_State, FXmlTagSDV.D_State, FEnumConverter.fromDeviceState(this.fState)); // 기존 상태 유지
                
                // --
                
                this.replace(this.fScdCore, fXmlNode);
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                fXmlNode = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
