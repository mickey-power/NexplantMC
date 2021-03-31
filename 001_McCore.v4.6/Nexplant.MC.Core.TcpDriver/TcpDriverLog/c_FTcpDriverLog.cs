/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTcpDriverLog.cs
--  Creator         : spike.lee
--  Create Date     : 2011.09.28
--  Description     : FAMate Core FaTcpDriver TCP Driver Log Class 
--  History         : Created by spike.lee at 2011.09.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;
using System.IO;

namespace Nexplant.MC.Core.FaTcpDriver
{
    public class FTcpDriverLog : FBaseObjectLog<FTcpDriverLog>, FIObjectLog
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTcpDriverLog(            
            )           
            : base()
        {
            this.fTcpDriverLog = this;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FTcpDriverLog(
            FTcpDriver fTcpDriver
            )
            : base()
        {
            this.fXmlNode.set_attrVal(FXmlTagTCDL.A_UniqueId, FXmlTagTCDL.D_UniqueId, fTcpDriver.uniqueIdToString);
            this.fXmlNode.set_attrVal(FXmlTagTCDL.A_Name, FXmlTagTCDL.D_Name, fTcpDriver.name);
            this.fXmlNode.set_attrVal(FXmlTagTCDL.A_Description, FXmlTagTCDL.D_Description, fTcpDriver.description);
            this.fXmlNode.set_attrVal(FXmlTagTCDL.A_FontColor, FXmlTagTCDL.D_FontColor, fTcpDriver.fontColor.Name);
            this.fXmlNode.set_attrVal(FXmlTagTCDL.A_FontBold, FXmlTagTCDL.D_FontBold, FBoolean.fromBool(fTcpDriver.fontBold));
            this.fXmlNode.set_attrVal(FXmlTagTCDL.A_EapName, FXmlTagTCDL.D_EapName, fTcpDriver.eapName);
            this.fXmlNode.set_attrVal(FXmlTagTCDL.A_UserTag1, FXmlTagTCDL.D_UserTag1, fTcpDriver.userTag1);
            this.fXmlNode.set_attrVal(FXmlTagTCDL.A_UserTag2, FXmlTagTCDL.D_UserTag2, fTcpDriver.userTag2);
            this.fXmlNode.set_attrVal(FXmlTagTCDL.A_UserTag3, FXmlTagTCDL.D_UserTag3, fTcpDriver.userTag3);
            this.fXmlNode.set_attrVal(FXmlTagTCDL.A_UserTag4, FXmlTagTCDL.D_UserTag4, fTcpDriver.userTag4);
            this.fXmlNode.set_attrVal(FXmlTagTCDL.A_UserTag5, FXmlTagTCDL.D_UserTag5, fTcpDriver.userTag5);
            // --
            this.fTcpDriverLog = this;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FTcpDriverLog(
            FTcdlCore fTcdlCore, 
            FXmlNode fXmlNode
            )
            : base(fTcdlCore, fXmlNode)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FTcpDriverLog(
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
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FObjectLogType fObjectLogType
        {
            get
            {
                try
                {
                    return FObjectLogType.TcpDriverLog;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string logUniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTCDL.A_LogUniqueId, FXmlTagTCDL.D_LogUniqueId);
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

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTCDL.A_UniqueId, FXmlTagTCDL.D_UniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagTCDL.A_Name, FXmlTagTCDL.D_Name);
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
                    return this.fXmlNode.get_attrVal(FXmlTagTCDL.A_Description, FXmlTagTCDL.D_Description);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagTCDL.A_FontColor, FXmlTagTCDL.D_FontColor));
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagTCDL.A_FontBold, FXmlTagTCDL.D_FontBold));
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

        public string eapName
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTCDL.A_EapName, FXmlTagTCDL.D_EapName);
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
                    return this.fXmlNode.get_attrVal(FXmlTagTCDL.A_UserTag1, FXmlTagTCDL.D_UserTag1);
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
                    return this.fXmlNode.get_attrVal(FXmlTagTCDL.A_UserTag2, FXmlTagTCDL.D_UserTag2);
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
                    return this.fXmlNode.get_attrVal(FXmlTagTCDL.A_UserTag3, FXmlTagTCDL.D_UserTag3);
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
                    return this.fXmlNode.get_attrVal(FXmlTagTCDL.A_UserTag4, FXmlTagTCDL.D_UserTag4);
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
                    return this.fXmlNode.get_attrVal(FXmlTagTCDL.A_UserTag5, FXmlTagTCDL.D_UserTag5);
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

        public FObjectLogCollection fChildObjectLogCollection
        {
            get
            {
                try
                {
                    return new FObjectLogCollection(this.fTcdlCore, this.fXmlNode.selectNodes("*"));
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
                string xpath = string.Empty;

                try
                {
                    xpath =
                        FXmlTagTDVL.E_TcpDevice + " | " +
                        FXmlTagTDTL.E_TcpDeviceTimeout + " | " +
                        FXmlTagTDEL.E_TcpDeviceError + " | " +
                        FXmlTagTMGL.E_TcpMessage + " | " +
                        FXmlTagHDVL.E_HostDevice + " | " +
                        FXmlTagHDEL.E_HostDeviceError + " | " +
                        FXmlTagVFEL.E_Vfei + " | " +
                        FXmlTagHMGL.E_HostMessage + " | " +
                        FXmlTagTTRL.E_TcpTrigger + " | " +
                        FXmlTagTTNL.E_TcpTransmitter + " | " +
                        FXmlTagHTRL.E_HostTrigger + " | " +
                        FXmlTagHTNL.E_HostTransmitter + " | " +
                        FXmlTagMAPL.E_Mapper + " | " +
                        FXmlTagSTGL.E_Storage + " | " +
                        FXmlTagCBKL.E_Callback + " | " +
                        FXmlTagFUNL.E_Function + " | " +
                        FXmlTagBRNL.E_Branch + " | " +
                        FXmlTagCMTL.E_Comment + " | " +
                        FXmlTagPAUL.E_Pauser + " | " +
                        FXmlTagETPL.E_EntryPoint + " | " +
                        FXmlTagAPPL.E_Application;
                    // --
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

        public bool hasHashTagChild
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

        public string equipmentName
        {
            get
            {
                try
                {
                    return string.Empty;
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

        public FIObjectLog appendChildObjectLog(
            FIObjectLog fObjectLog
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                // ***
                // 2017.05.30 by spike.lee
                // Log 객체를 다중 Driver Log에 추가하기 위해 XmlNode를 Clone 처리
                // ***
                fXmlNode = FTcpDriverLogCommon.getObjectLogXmlNode(fObjectLog).clone(true);
                // --
                if (
                    fXmlNode == null ||
                    fObjectLog.fObjectLogType == FObjectLogType.TcpDriverLog ||                    
                    fObjectLog.fObjectLogType == FObjectLogType.TcpItemLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.HostItemLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.DataSetLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.DataLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.RepositoryLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.ColumnLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.ContentLog

                    )
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0015, "Object Log"));
                }

                if (fXmlNode.fParentNode != null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0004, "Object Log", "Parent"));
                }

                // --

                fXmlNode = this.fXmlNode.appendChild(fXmlNode);
                FTcpDriverLogCommon.resetLogUniqueId(this.fTcdlCore.fIdPointer, fXmlNode);

                // --

                if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceStateChangedLog)
                {
                    ((FTcpDeviceStateChangedLog)fObjectLog).replace(this.fTcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceErrorRaisedLog)
                {
                    ((FTcpDeviceErrorRaisedLog)fObjectLog).replace(this.fTcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceTimeoutRaisedLog)
                {
                    ((FTcpDeviceTimeoutRaisedLog)fObjectLog).replace(this.fTcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog)
                {
                    ((FTcpDeviceDataMessageReceivedLog)fObjectLog).replace(this.fTcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog)
                {
                    ((FTcpDeviceDataMessageSentLog)fObjectLog).replace(this.fTcdlCore, fXmlNode);
                }
                // --
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceStateChangedLog)
                {
                    ((FHostDeviceStateChangedLog)fObjectLog).replace(this.fTcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceErrorRaisedLog)
                {
                    ((FHostDeviceErrorRaisedLog)fObjectLog).replace(this.fTcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceVfeiReceivedLog)
                {
                    ((FHostDeviceVfeiReceivedLog)fObjectLog).replace(this.fTcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceVfeiSentLog)
                {
                    ((FHostDeviceVfeiSentLog)fObjectLog).replace(this.fTcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                {
                    ((FHostDeviceDataMessageReceivedLog)fObjectLog).replace(this.fTcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                {
                    ((FHostDeviceDataMessageSentLog)fObjectLog).replace(this.fTcdlCore, fXmlNode);
                }
                // --        
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpTriggerRaisedLog)
                {
                    ((FTcpTriggerRaisedLog)fObjectLog).replace(this.fTcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpTransmitterRaisedLog)
                {
                    ((FTcpTransmitterRaisedLog)fObjectLog).replace(this.fTcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTriggerRaisedLog)
                {
                    ((FHostTriggerRaisedLog)fObjectLog).replace(this.fTcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTransmitterRaisedLog)
                {
                    ((FHostTransmitterRaisedLog)fObjectLog).replace(this.fTcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.JudgementPerformedLog)
                {
                    ((FJudgementPerformedLog)fObjectLog).replace(this.fTcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.MapperPerformedLog)
                {
                    ((FMapperPerformedLog)fObjectLog).replace(this.fTcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EquipmentStateSetAltererPerformedLog)
                {
                    ((FEquipmentStateSetAltererPerformedLog)fObjectLog).replace(this.fTcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.StoragePerformedLog)
                {
                    ((FStoragePerformedLog)fObjectLog).replace(this.fTcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CallbackRaisedLog)
                {
                    ((FCallbackRaisedLog)fObjectLog).replace(this.fTcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.FunctionCalledLog)
                {
                    ((FFunctionCalledLog)fObjectLog).replace(this.fTcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.BranchRaisedLog)
                {
                    ((FBranchRaisedLog)fObjectLog).replace(this.fTcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CommentWrittenLog)
                {
                    ((FCommentWrittenLog)fObjectLog).replace(this.fTcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PauserRaisedLog)
                {
                    ((FPauserRaisedLog)fObjectLog).replace(this.fTcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EntryPointCalledLog)
                {
                    ((FEntryPointCalledLog)fObjectLog).replace(this.fTcdlCore, fXmlNode);
                }
                // --
                else if (fObjectLog.fObjectLogType == FObjectLogType.ApplicationWrittenLog)
                {
                    ((FApplicationWrittenLog)fObjectLog).replace(this.fTcdlCore, fXmlNode);
                }

                // --

                return FTcpDriverLogCommon.createObjectLog(this.fTcdlCore, fXmlNode);
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

        public void removeAllObjectLog(
            )
        {
            try
            {
                foreach (FIObjectLog f in this.fChildObjectLogCollection)
                {
                    if (f.fObjectLogType == FObjectLogType.TcpDeviceStateChangedLog)
                    {
                        ((FTcpDeviceStateChangedLog)f).replace(this.fTcdlCore, this.fXmlNode.removeChild(((FTcpDeviceStateChangedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.TcpDeviceErrorRaisedLog)
                    {
                        ((FTcpDeviceErrorRaisedLog)f).replace(this.fTcdlCore, this.fXmlNode.removeChild(((FTcpDeviceErrorRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.TcpDeviceTimeoutRaisedLog)
                    {
                        ((FTcpDeviceTimeoutRaisedLog)f).replace(this.fTcdlCore, this.fXmlNode.removeChild(((FTcpDeviceTimeoutRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog)
                    {
                        ((FTcpDeviceDataMessageReceivedLog)f).replace(this.fTcdlCore, this.fXmlNode.removeChild(((FTcpDeviceDataMessageReceivedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog)
                    {
                        ((FTcpDeviceDataMessageSentLog)f).replace(this.fTcdlCore, this.fXmlNode.removeChild(((FTcpDeviceDataMessageSentLog)f).fXmlNode));
                    }                   
                    else if (f.fObjectLogType == FObjectLogType.TcpItemLog)
                    {
                        ((FTcpItemLog)f).replace(this.fTcdlCore, this.fXmlNode.removeChild(((FTcpItemLog)f).fXmlNode));
                    }
                    // --
                    else if (f.fObjectLogType == FObjectLogType.HostDeviceStateChangedLog)
                    {
                        ((FHostDeviceStateChangedLog)f).replace(this.fTcdlCore, this.fXmlNode.removeChild(((FHostDeviceStateChangedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.HostDeviceErrorRaisedLog)
                    {
                        ((FHostDeviceErrorRaisedLog)f).replace(this.fTcdlCore, this.fXmlNode.removeChild(((FHostDeviceErrorRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.HostDeviceVfeiReceivedLog)
                    {
                        ((FHostDeviceVfeiReceivedLog)f).replace(this.fTcdlCore, this.fXmlNode.removeChild(((FHostDeviceVfeiReceivedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.HostDeviceVfeiSentLog)
                    {
                        ((FHostDeviceVfeiSentLog)f).replace(this.fTcdlCore, this.fXmlNode.removeChild(((FHostDeviceVfeiSentLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                    {
                        ((FHostDeviceDataMessageReceivedLog)f).replace(this.fTcdlCore, this.fXmlNode.removeChild(((FHostDeviceDataMessageReceivedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                    {
                        ((FHostDeviceDataMessageSentLog)f).replace(this.fTcdlCore, this.fXmlNode.removeChild(((FHostDeviceDataMessageSentLog)f).fXmlNode));
                    }
                    // --
                    else if (f.fObjectLogType == FObjectLogType.HostTriggerRaisedLog)
                    {
                        ((FHostTriggerRaisedLog)f).replace(this.fTcdlCore, this.fXmlNode.removeChild(((FHostTriggerRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.HostTransmitterRaisedLog)
                    {
                        ((FHostTransmitterRaisedLog)f).replace(this.fTcdlCore, this.fXmlNode.removeChild(((FHostTransmitterRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.CallbackRaisedLog)
                    {
                        ((FCallbackRaisedLog)f).replace(this.fTcdlCore, this.fXmlNode.removeChild(((FCallbackRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.FunctionCalledLog)
                    {
                        ((FFunctionCalledLog)f).replace(this.fTcdlCore, this.fXmlNode.removeChild(((FFunctionCalledLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.BranchRaisedLog)
                    {
                        ((FBranchRaisedLog)f).replace(this.fTcdlCore, this.fXmlNode.removeChild(((FBranchRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.CommentWrittenLog)
                    {
                        ((FCommentWrittenLog)f).replace(this.fTcdlCore, this.fXmlNode.removeChild(((FCommentWrittenLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.PauserRaisedLog)
                    {
                        ((FPauserRaisedLog)f).replace(this.fTcdlCore, this.fXmlNode.removeChild(((FPauserRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.EntryPointCalledLog)
                    {
                        ((FEntryPointCalledLog)f).replace(this.fTcdlCore, this.fXmlNode.removeChild(((FEntryPointCalledLog)f).fXmlNode));
                    }
                    // --
                    else if (f.fObjectLogType == FObjectLogType.ApplicationWrittenLog)
                    {
                        ((FApplicationWrittenLog)f).replace(this.fTcdlCore, this.fXmlNode.removeChild(((FApplicationWrittenLog)f).fXmlNode));
                    }
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

        public void openLogFile(
            string fileName
            )
        {
            try
            {
                this.fTcdlCore.openLogFile(fileName);
                this.replace(this.fTcdlCore, this.fTcdlCore.fXmlNodeTcdl);
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

        public void saveLogFile(
            string fileName
            )
        {
            try
            {
                this.fTcdlCore.saveLogFile(fileName);
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
                    info = this.name + " MC=[" + this.eapName + "]";
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

        private FIObjectLog searchLogCommonSeries(
           string baseLogUniqueId,
           string searchWord,
           FXmlNodeList fXmlNodeSearchList
           )
        {
            int index = 0;

            try
            {
                searchWord = searchWord.ToLower();

                // --

                for (int i = 0; i < fXmlNodeSearchList.count; i++)
                {
                    if (fXmlNodeSearchList[i].get_attrVal(FXmlTagCommon.A_LogUniqueId, FXmlTagCommon.D_LogUniqueId) == baseLogUniqueId)
                    {
                        index = i;
                        break;
                    }
                }

                // --

                // ***
                // Next Search
                // ***
                for (int i = index + 1; i < fXmlNodeSearchList.count; i++)
                {
                    if (FCommon.compareSearchObject(fXmlNodeSearchList[i], searchWord))
                    {
                        return FTcpDriverLogCommon.createObjectLog(this.fTcdlCore, fXmlNodeSearchList[i]);
                    }
                }

                // --

                // ***
                // Previous Search
                // ***
                for (int i = 0; i <= index; i++)
                {
                    if (FCommon.compareSearchObject(fXmlNodeSearchList[i], searchWord))
                    {
                        return FTcpDriverLogCommon.createObjectLog(this.fTcdlCore, fXmlNodeSearchList[i]);
                    }
                }

                // --

                return null;
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

        public FIObjectLog searchLogSeries(
             FIObjectLog fBaseObject,
             string searchWord
             )
        {
            const string xPath =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCDL.E_TcpDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCDL.E_TcpDriver + "//*";

            try
            {
                return searchLogCommonSeries(
                    fBaseObject.logUniqueIdToString,
                    searchWord,
                    this.fTcdlCore.fXmlDoc.selectNodes(xPath)
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

        public List<string> hashTagList(
            )
        {
            List<string> hashTagList = new List<string>();
            string value = string.Empty;
            try
            {
                // --

                foreach (FXmlNode fXmlNode in this.fTcdlCore.fXmlNodeTcdl.selectNodes("//*[@HT='" + FBoolean.True + "']"))
                {
                    value = fXmlNode.get_attrVal(FXmlTagHIT.A_Value, FXmlTagHIT.D_Value);
                    if (!string.IsNullOrEmpty(value) && !hashTagList.Contains(value))
                    {
                        hashTagList.Add(value);
                    }
                }

                // --

                return hashTagList;
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
                
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
