/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FOpcDriverLog.cs
--  Creator         : spike.lee
--  Create Date     : 2011.09.28
--  Description     : FAMate Core FaOpcDriver OPC Driver Log Class 
--  History         : Created by spike.lee at 2011.09.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;
using System.IO;

namespace Nexplant.MC.Core.FaOpcDriver
{
    public class FOpcDriverLog : FBaseObjectLog<FOpcDriverLog>, FIObjectLog
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FOpcDriverLog(            
            )           
            : base()
        {
            this.fOpcDriverLog = this;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FOpcDriverLog(
            FOpcDriver fOpcDriver
            )
            : base()
        {
            this.fXmlNode.set_attrVal(FXmlTagOCDL.A_UniqueId, FXmlTagOCDL.D_UniqueId, fOpcDriver.uniqueIdToString);
            this.fXmlNode.set_attrVal(FXmlTagOCDL.A_Name, FXmlTagOCDL.D_Name, fOpcDriver.name);
            this.fXmlNode.set_attrVal(FXmlTagOCDL.A_Description, FXmlTagOCDL.D_Description, fOpcDriver.description);
            this.fXmlNode.set_attrVal(FXmlTagOCDL.A_FontColor, FXmlTagOCDL.D_FontColor, fOpcDriver.fontColor.Name);
            this.fXmlNode.set_attrVal(FXmlTagOCDL.A_FontBold, FXmlTagOCDL.D_FontBold, FBoolean.fromBool(fOpcDriver.fontBold));
            this.fXmlNode.set_attrVal(FXmlTagOCDL.A_EapName, FXmlTagOCDL.D_EapName, fOpcDriver.eapName);
            this.fXmlNode.set_attrVal(FXmlTagOCDL.A_UserTag1, FXmlTagOCDL.D_UserTag1, fOpcDriver.userTag1);
            this.fXmlNode.set_attrVal(FXmlTagOCDL.A_UserTag2, FXmlTagOCDL.D_UserTag2, fOpcDriver.userTag2);
            this.fXmlNode.set_attrVal(FXmlTagOCDL.A_UserTag3, FXmlTagOCDL.D_UserTag3, fOpcDriver.userTag3);
            this.fXmlNode.set_attrVal(FXmlTagOCDL.A_UserTag4, FXmlTagOCDL.D_UserTag4, fOpcDriver.userTag4);
            this.fXmlNode.set_attrVal(FXmlTagOCDL.A_UserTag5, FXmlTagOCDL.D_UserTag5, fOpcDriver.userTag5);
            // --
            this.fOpcDriverLog = this;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FOpcDriverLog(
            FOcdlCore fOcdlCore, 
            FXmlNode fXmlNode
            )
            : base(fOcdlCore, fXmlNode)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FOpcDriverLog(
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
                    return FObjectLogType.OpcDriverLog;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectLogType.OpcDriverLog;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string logUniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOCDL.A_LogUniqueId, FXmlTagOCDL.D_LogUniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOCDL.A_UniqueId, FXmlTagOCDL.D_UniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOCDL.A_Name, FXmlTagOCDL.D_Name);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOCDL.A_Description, FXmlTagOCDL.D_Description);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagOCDL.A_FontColor, FXmlTagOCDL.D_FontColor));
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagOCDL.A_FontBold, FXmlTagOCDL.D_FontBold));
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
                    return this.fXmlNode.get_attrVal(FXmlTagOCDL.A_EapName, FXmlTagOCDL.D_EapName);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOCDL.A_UserTag1, FXmlTagOCDL.D_UserTag1);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOCDL.A_UserTag2, FXmlTagOCDL.D_UserTag2);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOCDL.A_UserTag3, FXmlTagOCDL.D_UserTag3);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOCDL.A_UserTag4, FXmlTagOCDL.D_UserTag4);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOCDL.A_UserTag5, FXmlTagOCDL.D_UserTag5);
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
                    return new FObjectLogCollection(this.fOcdlCore, this.fXmlNode.selectNodes("*"));
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
                        FXmlTagODVL.E_OpcDevice + " | " +
                        FXmlTagODTL.E_OpcDeviceTimeout + " | " +
                        FXmlTagODEL.E_OpcDeviceError + " | " +
                        FXmlTagOMGL.E_OpcMessage + " | " +
                        FXmlTagHDVL.E_HostDevice + " | " +
                        FXmlTagHDEL.E_HostDeviceError + " | " +
                        FXmlTagVFEL.E_Vfei + " | " +
                        FXmlTagHMGL.E_HostMessage + " | " +
                        FXmlTagOTRL.E_OpcTrigger + " | " +
                        FXmlTagOTNL.E_OpcTransmitter + " | " +
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
                fXmlNode = FOpcDriverLogCommon.getObjectLogXmlNode(fObjectLog).clone(true);
                // --
                if (
                    fXmlNode == null ||
                    fObjectLog.fObjectLogType == FObjectLogType.OpcDriverLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.OpcEventItemListLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.OpcEventItemLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.OpcItemListLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.OpcItemLog ||
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
                FOpcDriverLogCommon.resetLogUniqueId(this.fOcdlCore.fIdPointer, fXmlNode);

                // --

                if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceStateChangedLog)
                {
                    ((FOpcDeviceStateChangedLog)fObjectLog).replace(this.fOcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceErrorRaisedLog)
                {
                    ((FOpcDeviceErrorRaisedLog)fObjectLog).replace(this.fOcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceTimeoutRaisedLog)
                {
                    ((FOpcDeviceTimeoutRaisedLog)fObjectLog).replace(this.fOcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageReadLog)
                {
                    ((FOpcDeviceDataMessageReadLog)fObjectLog).replace(this.fOcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageWrittenLog)
                {
                    ((FOpcDeviceDataMessageWrittenLog)fObjectLog).replace(this.fOcdlCore, fXmlNode);
                }
                // --
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceStateChangedLog)
                {
                    ((FHostDeviceStateChangedLog)fObjectLog).replace(this.fOcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceErrorRaisedLog)
                {
                    ((FHostDeviceErrorRaisedLog)fObjectLog).replace(this.fOcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceVfeiReceivedLog)
                {
                    ((FHostDeviceVfeiReceivedLog)fObjectLog).replace(this.fOcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceVfeiSentLog)
                {
                    ((FHostDeviceVfeiSentLog)fObjectLog).replace(this.fOcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                {
                    ((FHostDeviceDataMessageReceivedLog)fObjectLog).replace(this.fOcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                {
                    ((FHostDeviceDataMessageSentLog)fObjectLog).replace(this.fOcdlCore, fXmlNode);
                }
                // --        
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcTriggerRaisedLog)
                {
                    ((FOpcTriggerRaisedLog)fObjectLog).replace(this.fOcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcTransmitterRaisedLog)
                {
                    ((FOpcTransmitterRaisedLog)fObjectLog).replace(this.fOcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTriggerRaisedLog)
                {
                    ((FHostTriggerRaisedLog)fObjectLog).replace(this.fOcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTransmitterRaisedLog)
                {
                    ((FHostTransmitterRaisedLog)fObjectLog).replace(this.fOcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.JudgementPerformedLog)
                {
                    ((FJudgementPerformedLog)fObjectLog).replace(this.fOcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.MapperPerformedLog)
                {
                    ((FMapperPerformedLog)fObjectLog).replace(this.fOcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EquipmentStateSetAltererPerformedLog)
                {
                    ((FEquipmentStateSetAltererPerformedLog)fObjectLog).replace(this.fOcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.StoragePerformedLog)
                {
                    ((FStoragePerformedLog)fObjectLog).replace(this.fOcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CallbackRaisedLog)
                {
                    ((FCallbackRaisedLog)fObjectLog).replace(this.fOcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.FunctionCalledLog)
                {
                    ((FFunctionCalledLog)fObjectLog).replace(this.fOcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.BranchRaisedLog)
                {
                    ((FBranchRaisedLog)fObjectLog).replace(this.fOcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CommentWrittenLog)
                {
                    ((FCommentWrittenLog)fObjectLog).replace(this.fOcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PauserRaisedLog)
                {
                    ((FPauserRaisedLog)fObjectLog).replace(this.fOcdlCore, fXmlNode);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EntryPointCalledLog)
                {
                    ((FEntryPointCalledLog)fObjectLog).replace(this.fOcdlCore, fXmlNode);
                }
                // --
                else if (fObjectLog.fObjectLogType == FObjectLogType.ApplicationWrittenLog)
                {
                    ((FApplicationWrittenLog)fObjectLog).replace(this.fOcdlCore, fXmlNode);
                }

                // --

                return FOpcDriverLogCommon.createObjectLog(this.fOcdlCore, fXmlNode);
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
        
        // Add by Jeff.Kim 2015.11.24
        // Object Parent 관계없이 Log Object이 Append 될수 있도록 한다. 
        public FIObjectLog forceAppendChildObjectLog(
            FIObjectLog fObjectLog
            )
        {
            FXmlNode fXmlNodeTemp = null;

            try
            {
                fXmlNodeTemp = FOpcDriverLogCommon.getObjectLogXmlNode(fObjectLog);
                if (
                    fXmlNodeTemp == null ||
                    fObjectLog.fObjectLogType == FObjectLogType.OpcDriverLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.OpcEventItemListLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.OpcEventItemLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.OpcItemListLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.OpcItemLog ||
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

                // --

                fXmlNodeTemp = this.fXmlNode.appendChild(fXmlNodeTemp.clone(true));
                FOpcDriverLogCommon.resetLogUniqueId(this.fOcdlCore.fIdPointer, fXmlNodeTemp);

                // --

                fObjectLog = FOpcDriverLogCommon.createObjectLog(this.fOcdlCore, fXmlNodeTemp);

                // --
                
                return fObjectLog;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeTemp = null;
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
                    if (f.fObjectLogType == FObjectLogType.OpcDeviceStateChangedLog)
                    {
                        ((FOpcDeviceStateChangedLog)f).replace(this.fOcdlCore, this.fXmlNode.removeChild(((FOpcDeviceStateChangedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.OpcDeviceErrorRaisedLog)
                    {
                        ((FOpcDeviceErrorRaisedLog)f).replace(this.fOcdlCore, this.fXmlNode.removeChild(((FOpcDeviceErrorRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.OpcDeviceTimeoutRaisedLog)
                    {
                        ((FOpcDeviceTimeoutRaisedLog)f).replace(this.fOcdlCore, this.fXmlNode.removeChild(((FOpcDeviceTimeoutRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.OpcDeviceDataMessageReadLog)
                    {
                        ((FOpcDeviceDataMessageReadLog)f).replace(this.fOcdlCore, this.fXmlNode.removeChild(((FOpcDeviceDataMessageReadLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.OpcDeviceDataMessageWrittenLog)
                    {
                        ((FOpcDeviceDataMessageWrittenLog)f).replace(this.fOcdlCore, this.fXmlNode.removeChild(((FOpcDeviceDataMessageWrittenLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.OpcEventItemListLog)
                    {
                        ((FOpcEventItemListLog)f).replace(this.fOcdlCore, this.fXmlNode.removeChild(((FOpcEventItemListLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.OpcEventItemLog)
                    {
                        ((FOpcEventItemLog)f).replace(this.fOcdlCore, this.fXmlNode.removeChild(((FOpcEventItemLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.OpcItemListLog)
                    {
                        ((FOpcItemListLog)f).replace(this.fOcdlCore, this.fXmlNode.removeChild(((FOpcItemListLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.OpcItemLog)
                    {
                        ((FOpcItemLog)f).replace(this.fOcdlCore, this.fXmlNode.removeChild(((FOpcItemLog)f).fXmlNode));
                    }
                    // --
                    else if (f.fObjectLogType == FObjectLogType.HostDeviceStateChangedLog)
                    {
                        ((FHostDeviceStateChangedLog)f).replace(this.fOcdlCore, this.fXmlNode.removeChild(((FHostDeviceStateChangedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.HostDeviceErrorRaisedLog)
                    {
                        ((FHostDeviceErrorRaisedLog)f).replace(this.fOcdlCore, this.fXmlNode.removeChild(((FHostDeviceErrorRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.HostDeviceVfeiReceivedLog)
                    {
                        ((FHostDeviceVfeiReceivedLog)f).replace(this.fOcdlCore, this.fXmlNode.removeChild(((FHostDeviceVfeiReceivedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.HostDeviceVfeiSentLog)
                    {
                        ((FHostDeviceVfeiSentLog)f).replace(this.fOcdlCore, this.fXmlNode.removeChild(((FHostDeviceVfeiSentLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                    {
                        ((FHostDeviceDataMessageReceivedLog)f).replace(this.fOcdlCore, this.fXmlNode.removeChild(((FHostDeviceDataMessageReceivedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                    {
                        ((FHostDeviceDataMessageSentLog)f).replace(this.fOcdlCore, this.fXmlNode.removeChild(((FHostDeviceDataMessageSentLog)f).fXmlNode));
                    }
                    // --
                    else if (f.fObjectLogType == FObjectLogType.HostTriggerRaisedLog)
                    {
                        ((FHostTriggerRaisedLog)f).replace(this.fOcdlCore, this.fXmlNode.removeChild(((FHostTriggerRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.HostTransmitterRaisedLog)
                    {
                        ((FHostTransmitterRaisedLog)f).replace(this.fOcdlCore, this.fXmlNode.removeChild(((FHostTransmitterRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.CallbackRaisedLog)
                    {
                        ((FCallbackRaisedLog)f).replace(this.fOcdlCore, this.fXmlNode.removeChild(((FCallbackRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.FunctionCalledLog)
                    {
                        ((FFunctionCalledLog)f).replace(this.fOcdlCore, this.fXmlNode.removeChild(((FFunctionCalledLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.BranchRaisedLog)
                    {
                        ((FBranchRaisedLog)f).replace(this.fOcdlCore, this.fXmlNode.removeChild(((FBranchRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.CommentWrittenLog)
                    {
                        ((FCommentWrittenLog)f).replace(this.fOcdlCore, this.fXmlNode.removeChild(((FCommentWrittenLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.PauserRaisedLog)
                    {
                        ((FPauserRaisedLog)f).replace(this.fOcdlCore, this.fXmlNode.removeChild(((FPauserRaisedLog)f).fXmlNode));
                    }
                    else if (f.fObjectLogType == FObjectLogType.EntryPointCalledLog)
                    {
                        ((FEntryPointCalledLog)f).replace(this.fOcdlCore, this.fXmlNode.removeChild(((FEntryPointCalledLog)f).fXmlNode));
                    }
                    // --
                    else if (f.fObjectLogType == FObjectLogType.ApplicationWrittenLog)
                    {
                        ((FApplicationWrittenLog)f).replace(this.fOcdlCore, this.fXmlNode.removeChild(((FApplicationWrittenLog)f).fXmlNode));
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
                this.fOcdlCore.openLogFile(fileName);
                this.replace(this.fOcdlCore, this.fOcdlCore.fXmlNodeOcdl);
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
                this.fOcdlCore.saveLogFile(fileName);
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
                        return FOpcDriverLogCommon.createObjectLog(this.fOcdlCore, fXmlNodeSearchList[i]);
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
                        return FOpcDriverLogCommon.createObjectLog(this.fOcdlCore, fXmlNodeSearchList[i]);
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
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCDL.E_OpcDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCDL.E_OpcDriver + "//*";

            try
            {
                return searchLogCommonSeries(
                    fBaseObject.logUniqueIdToString,
                    searchWord,
                    this.fOcdlCore.fXmlDoc.selectNodes(xPath)
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

                foreach (FXmlNode fXmlNode in this.fOcdlCore.fXmlNodeOcdl.selectNodes("//*[@HT='" + FBoolean.True + "']"))
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
