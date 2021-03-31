/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecsDriver.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.28
--  Description     : FAMate Core FaSecsDriver SECS Driver Main Class 
--  History         : Created by spike.lee at 2011.01.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public class FSecsDriver : FBaseObject<FSecsDriver>, FIObject
    {

        //------------------------------------------------------------------------------------------------------------------------

        public event FModelingFileOpenCompletedEventHandler ModelingFileOpenCompleted = null;
        public event FModelingFileReopenPrecompletedEventHandler ModelingFileReopenPrecompleted = null;
        public event FModelingFileReopenCompletedEventHandler ModelingFileReopenCompleted = null;
        public event FModelingFileReopenFailedEventHandler ModelingFileReopenFailed = null;
        public event FModelingFileSaveCompletedEventHandler ModelingFileSaveCompleted = null;
        // --        
        public event FObjectModifyCompletedEventHandler ObjectModifyCompleted = null;        
        public event FObjectInsertBeforeCompletedEventHandler ObjectInsertBeforeCompleted = null;
        public event FObjectInsertAfterCompletedEventHandler ObjectInsertAfterCompleted = null;
        public event FObjectAppendCompletedEventHandler ObjectAppendCompleted = null;
        public event FObjectRemoveCompletedEventHandler ObjectRemoveCompleted = null;
        public event FObjectMoveUpCompletedEventHandler ObjectMoveUpCompleted = null;
        public event FObjectMoveDownCompletedEventHandler ObjectMoveDownCompleted = null;
        public event FObjectMoveToCompletedEventHandler ObjectMoveToCompleted = null;
        // --
        public event FSecsDeviceStateChangedEventHandler SecsDeviceStateChanged = null;
        public event FSecsDeviceErrorRaisedEventHandler SecsDeviceErrorRaised = null;
        public event FSecsDeviceTimeoutRaisedEventHandler SecsDeviceTimeoutRaised = null;
        public event FSecsDeviceDataReceivedEventHandler SecsDeviceDataReceived = null;
        public event FSecsDeviceDataSentEventHandler SecsDeviceDataSent = null;
        public event FSecsDeviceTelnetPacketReceivedEventHandler SecsDeviceTelnetPacketReceived = null;
        public event FSecsDeviceTelnetPacketSentEventHandler SecsDeviceTelnetPacketSent = null;
        public event FSecsDeviceTelnetStateChangedEventHandler SecsDeviceTelnetStateChanged = null;        
        public event FSecsDeviceHandshakeReceivedEventHandler SecsDeviceHandshakeReceived = null;
        public event FSecsDeviceHandshakeSentEventHandler SecsDeviceHandshakeSent = null;        
        public event FSecsDeviceControlMessageReceivedEventHandler SecsDeviceControlMessageReceived = null;
        public event FSecsDeviceControlMessageSentEventHandler SecsDeviceControlMessageSent = null;
        public event FSecsDeviceBlockReceivedEventHandler SecsDeviceBlockReceived = null;
        public event FSecsDeviceBlockSentEventHandler SecsDeviceBlockSent = null;
        public event FSecsDeviceSmlReceivedEventHandler SecsDeviceSmlReceived = null;
        public event FSecsDeviceSmlSentEventHandler SecsDeviceSmlSent = null;
        public event FSecsDeviceDataMessageReceivedEventHandler SecsDeviceDataMessageReceived = null;
        public event FSecsDeviceDataMessageSentEventHandler SecsDeviceDataMessageSent = null;        
        // --
        public event FHostDeviceStateChangedEventHandler HostDeviceStateChanged = null;
        public event FHostDeviceErrorRaisedEventHandler HostDeviceErrorRaised = null;
        public event FHostDeviceVfeiReceivedEventHandler HostDeviceVfeiReceived = null;
        public event FHostDeviceVfeiSentEventHandler HostDeviceVfeiSent = null;
        public event FHostDeviceDataMessageReceivedEventHandler HostDeviceDataMessageReceived = null;
        public event FHostDeviceDataMessageSentEventHandler HostDeviceDataMessageSent = null;
        // --
        public event FSecsTriggerRaisedEventHandler SecsTriggerRaised = null;
        public event FSecsTransmitterRaisedEventHandler SecsTransmitterRaised = null;
        public event FHostTriggerRaisedEventHandler HostTriggerRaised = null;
        public event FHostTransmitterRaisedEventHandler HostTransmitterRaised = null;
        public event FJudgementPerformedEventHandler JudgementPerformed = null;
        public event FMapperPerformedEventHandler MapperPerformed = null;
        public event FEquipmentStateSetAltererPerformedEventHandler EquipmentStateSetAltererPerformed = null;
        public event FStoragePerformedEventHandler StoragePerformed = null;
        public event FCallbackRaisedEventHandler CallbackRaised = null;
        public event FFunctionCalledEventHandler FunctionCalled = null;
        public event FBranchRaisedEventHandler BranchRaised = null;
        public event FCommentWrittenEventHandler CommentWritten = null;
        public event FEntryPointCalledEventHandler EntryPointCalled = null;
        public event FPauserRaisedEventHandler PauserRaised = null;
        public event FApplicationWrittenEventHandler ApplicationWritten = null;
        // ***
        // 2017.05.31 by spike.lee
        // Repository Material Saved Event Handler 추가
        // ***
        public event FRepositoryMaterialSavedEventHandler RepositoryMaterialSaved = null;
        
        //--
        
        private bool m_disposed = false;
        // --
        // ***
        // 2017.07.04 by spike.lee
        // Log Level Enabled Member Add
        // ***
        private bool m_logLevel1 = true;
        private bool m_logLevel2 = false;
        private bool m_logLevel3 = false;
        private bool m_logLevel4 = false;
        private bool m_logLevel5 = false;
        private bool m_logLevel6 = false;
        private bool m_logLevel7 = false;
        private bool m_logLevel8 = false;
        private bool m_logLevel9 = false;
        private bool m_logLevel10 = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        // ***
        // 2014.02.03 by spike.lee
        // SECS Driver 생성에 사용
        // ***
        public FSecsDriver(
            string licFileName
            )
            : base(licFileName)
        {
            this.fSecsDriver = this;
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        // ***
        // 2014.02.03 by spike.lee
        // SECS Driver reopenModelingFile 메소드에 사용
        // ***
        internal FSecsDriver(
            )
            : base()
        {
            this.fSecsDriver = this;
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2014.02.03 by spike.lee
        // SECS Driver Clone에 사용
        // ***
        internal FSecsDriver(
            FXmlDocument fXmlDoc
            )
            : base(fXmlDoc)
        {
            this.fSecsDriver = this;
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2014.02.03 by spike.lee
        // SECS Driver Instance 복사에 사용
        // ***
        internal FSecsDriver(            
            FScdCore fScdCore,
            FXmlNode fXmlNode
            ) 
            : base(fScdCore, fXmlNode)
        {
           
        }

        //------------------------------------------------------------------------------------------------------------------------        

        ~FSecsDriver(
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
                    closeAllDevice();
                }
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
                    return FObjectType.SecsDriver;
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

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSCD.A_UniqueId, FXmlTagSCD.D_UniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSCD.A_Name, FXmlTagSCD.D_Name);
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

                    this.fXmlNode.set_attrVal(FXmlTagSCD.A_Name, FXmlTagSCD.D_Name, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSCD.A_Description, FXmlTagSCD.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagSCD.A_Description, FXmlTagSCD.D_Description, value, true);                                        
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

                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagSCD.A_FontColor, FXmlTagSCD.D_FontColor));
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
                    this.fXmlNode.set_attrVal(FXmlTagSCD.A_FontColor, FXmlTagSCD.D_FontColor, value.Name, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSCD.A_FontBold, FXmlTagSCD.D_FontBold));
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
                    this.fXmlNode.set_attrVal(FXmlTagSCD.A_FontBold, FXmlTagSCD.D_FontBold, FBoolean.fromBool(value), true);
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

        public string eapName
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSCD.A_EapName, FXmlTagSCD.D_EapName);
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

                    this.fXmlNode.set_attrVal(FXmlTagSCD.A_EapName, FXmlTagSCD.D_EapName, value, true);

                    // -- 

                    // ***
                    // 2012.11.19 by spike.lee
                    // EAP Name를 변경할 경우 SECS Driver의 Config에 EAP Name로 변경한다.
                    // FLogWriter에서 Log File를 만들 경우 사용한다.
                    // SECS Driver의 EAP Name과 Log File의 EAP Name를 동기화 한다.
                    // ***
                    this.fScdCore.fConfig.eapName = value;
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
                    return this.fXmlNode.get_attrVal(FXmlTagSCD.A_UserTag1, FXmlTagSCD.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagSCD.A_UserTag1, FXmlTagSCD.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSCD.A_UserTag2, FXmlTagSCD.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagSCD.A_UserTag2, FXmlTagSCD.D_UserTag2, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSCD.A_UserTag3, FXmlTagSCD.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagSCD.A_UserTag3, FXmlTagSCD.D_UserTag3, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSCD.A_UserTag4, FXmlTagSCD.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagSCD.A_UserTag4, FXmlTagSCD.D_UserTag4, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSCD.A_UserTag5, FXmlTagSCD.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagSCD.A_UserTag5, FXmlTagSCD.D_UserTag5, value, true);
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

        public FObjectNameListCollection fChildObjectNameListCollection
        {
            get
            {
                const string xpath = FXmlTagSET.E_Setup + "/" + FXmlTagOND.E_ObjectNameDefinition + "/" + FXmlTagONL.E_ObjectNameList;

                try
                {
                    return new FObjectNameListCollection(this.fScdCore, this.fXmlNode.selectNodes(xpath));
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

        public FFunctionNameListCollection fChildFunctionNameListCollection
        {
            get
            {
                const string xpath = FXmlTagSET.E_Setup + "/" + FXmlTagFND.E_FunctionNameDefinition + "/" + FXmlTagFNL.E_FunctionNameList;

                try
                {
                    return new FFunctionNameListCollection(this.fScdCore, this.fXmlNode.selectNodes(xpath));
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

        public FUserTagNameCollection fChildUserTagNameCollection
        {
            get
            {
                const string xpath = FXmlTagSET.E_Setup + "/" + FXmlTagUTD.E_UserTagNameDefinition + "/" + FXmlTagUTN.E_UserTagName;

                try
                {
                    return new FUserTagNameCollection(this.fScdCore, this.fXmlNode.selectNodes(xpath));
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

        public FDataConversionSetListCollection fChildDataConversionSetListCollection
        {
            get
            {
                const string xpath = FXmlTagSET.E_Setup + "/" + FXmlTagDCD.E_DataConversionSetDefinition + "/" + FXmlTagDCL.E_DataConversionSetList;

                try
                {
                    return new FDataConversionSetListCollection(this.fScdCore, this.fXmlNode.selectNodes(xpath));
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

        public FEquipmentStateSetListCollection fChildEquipmentStateSetListCollection
        {
            get
            {
                const string xpath = FXmlTagSET.E_Setup + "/" + FXmlTagESD.E_EquipmentStateSetDefinition + "/" + FXmlTagESL.E_EquipmentStateSetList;

                try
                {
                    return new FEquipmentStateSetListCollection(this.fScdCore, this.fXmlNode.selectNodes(xpath));
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

        public FRepositoryListCollection fChildRepositoryListCollection
        {
            get
            {
                const string xpath = FXmlTagSET.E_Setup + "/" + FXmlTagRPD.E_RepositoryDefinition + "/" + FXmlTagRPL.E_RepositoryList;

                try
                {
                    return new FRepositoryListCollection(this.fScdCore, this.fXmlNode.selectNodes(xpath));
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

        public FDataSetListCollection fChildDataSetListCollection
        {
            get
            {
                const string xpath = FXmlTagSET.E_Setup + "/" + FXmlTagDSD.E_DataSetDefinition + "/" + FXmlTagDSL.E_DataSetList;

                try
                {
                    return new FDataSetListCollection(this.fScdCore,this.fXmlNode.selectNodes(xpath));
                }
                catch(Exception ex)
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

        public FEnvironmentListCollection fChildEnvironmentListCollection
        {
            get
            {
                const string xpath = 
                    FXmlTagSET.E_Setup + "/" + 
                    FXmlTagEND.E_EnvironmentDefinition + "/" + 
                    FXmlTagENL.E_EnvironmentList;

                try
                {
                    return new FEnvironmentListCollection(this.fScdCore, this.fXmlNode.selectNodes(xpath));
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

        public FSecsLibraryGroupCollection fChildSecsLibraryGroupCollection
        {
            get
            {
                const string xpath = FXmlTagSLM.E_SecsLibraryModeling + "/" + FXmlTagSLG.E_SecsLibraryGroup;

                try
                {
                    return new FSecsLibraryGroupCollection(this.fScdCore, this.fXmlNode.selectNodes(xpath));
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

        public FSecsDeviceCollection fChildSecsDeviceCollection
        {
            get
            {
                const string xpath = FXmlTagSDM.E_SecsDeviceModeling + "/" + FXmlTagSDV.E_SecsDevice;

                try
                {
                    return new FSecsDeviceCollection(this.fScdCore, this.fXmlNode.selectNodes(xpath));
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

        public FHostLibraryGroupCollection fChildHostLibraryGroupCollection
        {
            get
            {
                const string xpath = FXmlTagHLM.E_HostLibraryModeling + "/" + FXmlTagHLG.E_HostLibraryGroup;

                try
                {
                    return new FHostLibraryGroupCollection(this.fScdCore, this.fXmlNode.selectNodes(xpath));
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

        public FHostDeviceCollection fChildHostDeviceCollection
        {
            get
            {
                const string xpath = FXmlTagHDM.E_HostDeviceModeling + "/" + FXmlTagHDV.E_HostDevice;

                try
                {
                    return new FHostDeviceCollection(this.fScdCore, this.fXmlNode.selectNodes(xpath));
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

        public FEquipmentCollection fChildEquipmentCollection
        {
            get
            {
                const string xpath = FXmlTagEQM.E_EquipmentModeling + "/" + FXmlTagEQP.E_Equipment;

                try
                {
                    return new FEquipmentCollection(this.fScdCore, this.fXmlNode.selectNodes(xpath));
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

        public int eventCount
        {
            get
            {
                try
                {
                    return this.fScdCore.fEventPusher.eventCount;
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

        public bool isCompletedEventHandling
        {
            get
            {
                try
                {
                    return this.fScdCore.fEventPusher.isCompletedEventHandling;
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
                string xpath = string.Empty;

                try
                {
                    xpath =
                        FXmlTagSET.E_Setup + "/" + FXmlTagOND.E_ObjectNameDefinition + "/" + FXmlTagONL.E_ObjectNameList + " | " +
                        FXmlTagSET.E_Setup + "/" + FXmlTagFND.E_FunctionNameDefinition + "/" + FXmlTagFNL.E_FunctionNameList + " | " +
                        FXmlTagSET.E_Setup + "/" + FXmlTagUTD.E_UserTagNameDefinition + "/" + FXmlTagUTN.E_UserTagName + " | " +
                        FXmlTagSET.E_Setup + "/" + FXmlTagDCD.E_DataConversionSetDefinition + "/" + FXmlTagDCL.E_DataConversionSetList + " | " +
                        FXmlTagSET.E_Setup + "/" + FXmlTagEND.E_EnvironmentDefinition + "/" + FXmlTagENL.E_EnvironmentList + " | " +
                        FXmlTagSET.E_Setup + "/" + FXmlTagRPD.E_RepositoryDefinition + "/" + FXmlTagRPL.E_RepositoryList + " | " +
                        FXmlTagSET.E_Setup + "/" + FXmlTagDSD.E_DataSetDefinition + "/" + FXmlTagDSL.E_DataSetList + " | " +                        
                        FXmlTagSLM.E_SecsLibraryModeling + "/" + FXmlTagSLG.E_SecsLibraryGroup + " | " +
                        FXmlTagSDM.E_SecsDeviceModeling + "/" + FXmlTagSDV.E_SecsDevice + " | " +
                        FXmlTagHLM.E_HostLibraryModeling + "/" + FXmlTagHLG.E_HostLibraryGroup + " | " +
                        FXmlTagHDM.E_HostDeviceModeling + "/" + FXmlTagHDV.E_HostDevice + " | " +
                        FXmlTagEQM.E_EquipmentModeling + "/" + FXmlTagEQP.E_Equipment; 
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

        public bool hasChildObjectNameList
        {
            get
            {
                string xpath = string.Empty;

                try
                {
                    xpath = FXmlTagSET.E_Setup + "/" + FXmlTagOND.E_ObjectNameDefinition + "/" + FXmlTagONL.E_ObjectNameList;
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

        public bool hasChildFunctionNameList
        {
            get
            {
                string xpath = string.Empty;

                try
                {
                    xpath = FXmlTagSET.E_Setup + "/" + FXmlTagFND.E_FunctionNameDefinition + "/" + FXmlTagFNL.E_FunctionNameList;
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

        public bool hasUserTagName
        {
            get
            {
                string xpath = string.Empty;

                try
                {
                    xpath = FXmlTagSET.E_Setup + "/" + FXmlTagUTD.E_UserTagNameDefinition + "/" + FXmlTagUTN.E_UserTagName;
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

        public bool hasDataConversionSetList
        {
            get
            {
                string xpath = string.Empty;

                try
                {
                    xpath = FXmlTagSET.E_Setup + "/" + FXmlTagDCD.E_DataConversionSetDefinition + "/" + FXmlTagDCL.E_DataConversionSetList;
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

        public bool hasEquipmentStateSetList
        {
            get
            {
                string xpath = string.Empty;

                try
                {
                    xpath = FXmlTagSET.E_Setup + "/" + FXmlTagESD.E_EquipmentStateSetDefinition + "/" + FXmlTagESL.E_EquipmentStateSetList;
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

        public bool hasRepositoryList
        {
            get
            {
                string xpath = string.Empty;

                try
                {
                    xpath = FXmlTagSET.E_Setup + "/" + FXmlTagRPD.E_RepositoryDefinition + "/" + FXmlTagRPL.E_RepositoryList;
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

        public bool hasEnvironmentList
        {
            get
            {
                string xpath = string.Empty;

                try
                {
                    xpath = FXmlTagSET.E_Setup + "/" + FXmlTagEND.E_EnvironmentDefinition + "/" + FXmlTagENL.E_EnvironmentList;
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

        public bool hasDataSetList
        {
            get
            {
                string xpath = string.Empty;

                try
                {
                    xpath = FXmlTagSET.E_Setup + "/" + FXmlTagDSD.E_DataSetDefinition + "/" + FXmlTagDSL.E_DataSetList;
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

        public bool hasSecsLibraryGroup
        {
            get
            {
                string xpath = string.Empty;

                try
                {
                    xpath = FXmlTagSLM.E_SecsLibraryModeling + "/" + FXmlTagSLG.E_SecsLibraryGroup;
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

        public bool hasSecsDevice
        {
            get
            {
                string xpath = string.Empty;

                try
                {
                    xpath = FXmlTagSDM.E_SecsDeviceModeling + "/" + FXmlTagSDV.E_SecsDevice;
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

        public bool hasHostLibraryGroup
        {
            get
            {
                string xpath = string.Empty;

                try
                {
                    xpath = FXmlTagHLM.E_HostLibraryModeling + "/" + FXmlTagHLG.E_HostLibraryGroup;
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

        public bool hasHostDevice
        {
            get
            {
                string xpath = string.Empty;

                try
                {
                    xpath = FXmlTagHDM.E_HostDeviceModeling + "/" + FXmlTagHDV.E_HostDevice;
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

        public bool hasEquipment
        {
            get
            {
                string xpath = string.Empty;

                try
                {
                    xpath = FXmlTagEQM.E_EquipmentModeling + "/" + FXmlTagEQP.E_Equipment;
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

        //------------------------------------------------------------------------------------------------------------------------

        public bool canAppendChildObjectNameList
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

        public bool canAppendChildFunctionNameList
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

        public bool canAppendChildUserTagName
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

        public bool canAppendChildDataConversionSetList
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

        public bool canAppendChildEquipmentStateSetList
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

        public bool canAppendChildRepositoryList
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

        public bool canAppendChildEnvironmentList
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

        public bool canAppendChildDataSetList
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

        public bool canAppendChildSecsLibraryGroup
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

        public bool canAppendChildSecsDevice
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

        public bool canAppendChildHostLibraryGroup
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

        public bool canAppendChildHostDevice
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

        public bool canAppendChildEquipment
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

        public bool canInsertBefore
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

        public bool canMoveUp
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

        public bool canMoveDown
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

        public bool canCopy
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

        public bool canCut
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

        public bool canPasteChild
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

        public bool canPasteChildObjectNameList
        {
            get
            {
                try
                {
                    if (!FClipboard.containsData(FCbObjectFormat.ObjectNameList))
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

        public bool canPasteChildFunctionNameList
        {
            get
            {
                try
                {
                    if (!FClipboard.containsData(FCbObjectFormat.FunctionNameList))
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

        public bool canPasteChildDataConversionSetList
        {
            get
            {
                try
                {
                    if (!FClipboard.containsData(FCbObjectFormat.DataConversionSetList))
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

        public bool canPasteChildEquipmentStateSetList
        {
            get
            {
                try
                {
                    if (!FClipboard.containsData(FCbObjectFormat.EquipmentStateSetList))
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

        public bool canPasteChildRepositoryList
        {
            get
            {
                try
                {
                    if (!FClipboard.containsData(FCbObjectFormat.RepositoryList))
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

        public bool canPasteChildEnvironmentList
        {
            get
            {
                try
                {
                    if (!FClipboard.containsData(FCbObjectFormat.EnvironmentList))
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

        public bool canPasteChildDataSetList
        {
            get
            {
                try
                {
                    if (!FClipboard.containsData(FCbObjectFormat.DataSetList))
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

        public bool canPasteChildSecsLibraryGroup
        {
            get
            {
                try
                {
                    if (!FClipboard.containsData(FCbObjectFormat.SecsLibraryGroup))
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

        public bool canPasteChildSecsDevice
        {
            get
            {
                try
                {
                    if (!FClipboard.containsData(FCbObjectFormat.SecsDevice))
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

        public bool canPasteChildHostLibraryGroup
        {
            get
            {
                try
                {
                    if (!FClipboard.containsData(FCbObjectFormat.HostLibraryGroup))
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

        public bool canPasteChildHostDevice
        {
            get
            {
                try
                {
                    if (!FClipboard.containsData(FCbObjectFormat.HostDevice))
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

        public bool canPasteChildEquipment
        {
            get
            {
                try
                {
                    if (!FClipboard.containsData(FCbObjectFormat.Equipment))
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

        public bool canPasteSibling
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

        public FRepositoryMaterialStorage fRepositoryMaterialStorage
        {
            get
            {
                try
                {
                    return this.fScdCore.fRepositoryMaterialStorage;
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

        public FEquipmentStateMaterialStorage fEquipmentStateMaterialStorage
        {
            get
            {
                try
                {
                    return this.fScdCore.fEquipmentStateMaterialStorage;
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

        public bool logLevel1
        {
            get
            {
                try
                {
                    return m_logLevel1;
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
                    m_logLevel1 = value;
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

        public bool logLevel2
        {
            get
            {
                try
                {
                    return m_logLevel2;
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
                    m_logLevel2 = value;
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

        public bool logLevel3
        {
            get
            {
                try
                {
                    return m_logLevel3;
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
                    m_logLevel3 = value;
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

        public bool logLevel4
        {
            get
            {
                try
                {
                    return m_logLevel4;
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
                    m_logLevel4 = value;
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

        public bool logLevel5
        {
            get
            {
                try
                {
                    return m_logLevel5;
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
                    m_logLevel5 = value;
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

        public bool logLevel6
        {
            get
            {
                try
                {
                    return m_logLevel6;
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
                    m_logLevel6 = value;
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

        public bool logLevel7
        {
            get
            {
                try
                {
                    return m_logLevel7;
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
                    m_logLevel7 = value;
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

        public bool logLevel8
        {
            get
            {
                try
                {
                    return m_logLevel8;
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
                    m_logLevel8 = value;
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

        public bool logLevel9
        {
            get
            {
                try
                {
                    return m_logLevel9;
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
                    m_logLevel9 = value;
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

        public bool logLevel10
        {
            get
            {
                try
                {
                    return m_logLevel10;
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
                    m_logLevel10 = value;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region SECS Driver Config

        public string hostDriverDirectory
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.hostDriverDirectory;
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
                    this.fScdCore.fConfig.hostDriverDirectory = value;
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

        public string logDirectory
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.logDirectory;
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
                    this.fScdCore.fConfig.logDirectory = value;
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

        public bool enabledEventsOfSecsDeviceState
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.enabledEventsOfSecsDeviceState;
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
                    this.fScdCore.fConfig.enabledEventsOfSecsDeviceState = value;
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

        public bool enabledEventsOfSecsDeviceError
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.enabledEventsOfSecsDeviceError;
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
                    this.fScdCore.fConfig.enabledEventsOfSecsDeviceError = value;
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

        public bool enabledEventsOfSecsDeviceTimeout
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.enabledEventsOfSecsDeviceTimeout;
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
                    this.fScdCore.fConfig.enabledEventsOfSecsDeviceTimeout = value;
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

        public bool enabledEventsOfSecsDeviceData
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.enabledEventsOfSecsDeviceData;
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
                    this.fScdCore.fConfig.enabledEventsOfSecsDeviceData = value;
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

        public bool enabledEventsOfSecsDeviceTelnet
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.enabledEventsOfSecsDeviceTelnet;
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
                    this.fScdCore.fConfig.enabledEventsOfSecsDeviceTelnet = value;
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

        public bool enabledEventsOfSecsDeviceHandshake
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.enabledEventsOfSecsDeviceHandshake;
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
                    this.fScdCore.fConfig.enabledEventsOfSecsDeviceHandshake = value;
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

        public bool enabledEventsOfSecsDeviceControlMessage
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.enabledEventsOfSecsDeviceControlMessage;
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
                    this.fScdCore.fConfig.enabledEventsOfSecsDeviceControlMessage = value;
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

        public bool enabledEventsOfSecsDeviceBlock
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.enabledEventsOfSecsDeviceBlock;
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
                    this.fScdCore.fConfig.enabledEventsOfSecsDeviceBlock = value;
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

        public bool enabledEventsOfSecsDeviceSml
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.enabledEventsOfSecsDeviceSml;
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
                    this.fScdCore.fConfig.enabledEventsOfSecsDeviceSml = value;
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

        public bool enabledEventsOfSecsDeviceDataMessage
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.enabledEventsOfSecsDeviceDataMessage;
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
                    this.fScdCore.fConfig.enabledEventsOfSecsDeviceDataMessage = value;
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

        public bool enabledEventsOfHostDeviceState
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.enabledEventsOfHostDeviceState;
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
                    this.fScdCore.fConfig.enabledEventsOfHostDeviceState = value;
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

        public bool enabledEventsOfHostDeviceError
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.enabledEventsOfHostDeviceError;
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
                    this.fScdCore.fConfig.enabledEventsOfHostDeviceError = value;
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

        public bool enabledEventsOfHostDeviceVfei
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.enabledEventsOfHostDeviceVfei;
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
                    this.fScdCore.fConfig.enabledEventsOfHostDeviceVfei = value;
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

        public bool enabledEventsOfHostDeviceDataMessage
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.enabledEventsOfHostDeviceDataMessage;
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
                    this.fScdCore.fConfig.enabledEventsOfHostDeviceDataMessage = value;
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

        public bool enabledEventsOfScenario
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.enabledEventsOfScenario;
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
                    this.fScdCore.fConfig.enabledEventsOfScenario = value;
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

        public bool enabledEventsOfApplication
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.enabledEventsOfApplication;
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
                    this.fScdCore.fConfig.enabledEventsOfApplication = value;
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

        public bool enabledLogOfBinary
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.enabledLogOfBinary;
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
                    this.fScdCore.fConfig.enabledLogOfBinary = value;
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

        public bool enabledLogOfSml
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.enabledLogOfSml;
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
                    this.fScdCore.fConfig.enabledLogOfSml = value;
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

        public bool enabledLogOfVfei
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.enabledLogOfVfei;
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
                    this.fScdCore.fConfig.enabledLogOfVfei = value;
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

        public bool enabledLogOfSecs
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.enabledLogOfSecs;
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
                    this.fScdCore.fConfig.enabledLogOfSecs = value;
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

        public long maxLogFileSizeOfBinary
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.maxLogFileSizeOfBinary;
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
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Max Binary Log File Size"));
                    }

                    // --

                    this.fScdCore.fConfig.maxLogFileSizeOfBinary = value;
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

        public long maxLogFileSizeOfSml
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.maxLogFileSizeOfSml;
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
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Max SML Log File Size"));
                    }

                    // --

                    this.fScdCore.fConfig.maxLogFileSizeOfSml = value;
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

        public long maxLogFileSizeOfVfei
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.maxLogFileSizeOfVfei;
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
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Max VFEI Log File Size"));
                    }

                    // --

                    this.fScdCore.fConfig.maxLogFileSizeOfVfei = value;
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

        public long maxLogFileSizeOfSecs
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.maxLogFileSizeOfSecs;
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
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Max SECS Log File Size"));
                    }

                    // --

                    this.fScdCore.fConfig.maxLogFileSizeOfSecs = value;
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

        public long maxLogCountOfBinary
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.maxLogCountOfBinary;
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
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Max Binary Log Count"));
                    }

                    // --

                    this.fScdCore.fConfig.maxLogCountOfBinary = value;
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

        public long maxLogCountOfSml
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.maxLogCountOfSml;
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
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Max SML Log Count"));
                    }

                    // --

                    this.fScdCore.fConfig.maxLogCountOfSml = value;
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

        public long maxLogCountOfVfei
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.maxLogCountOfVfei;
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
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Max VFEI Log Count"));
                    }

                    // --

                    this.fScdCore.fConfig.maxLogCountOfVfei = value;
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

        public long maxLogCountOfSecs
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.maxLogCountOfSecs;
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
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Max SECS Log Count"));
                    }

                    // --

                    this.fScdCore.fConfig.maxLogCountOfSecs = value;
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

        public string repositorySaveDirectory
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.repositorySaveDirectory;
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
                    this.fScdCore.fConfig.repositorySaveDirectory = value;
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

        public bool enabledRepositorySave
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.enabledRepositorySave;
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
                    this.fScdCore.fConfig.enabledRepositorySave = value;
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

        public bool enabledRepositoryAutoRemove
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.enabledRepositoryAutoRemove;
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
                    this.fScdCore.fConfig.enabledRepositoryAutoRemove = value;
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

        public int repositoryKeepingPeriod
        {
            get
            {
                try
                {
                    return this.fScdCore.fConfig.repositoryKeepingPeriod;
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
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Repository keeping period"));
                    }

                    // --

                    this.fScdCore.fConfig.repositoryKeepingPeriod = value;
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

        public FObjectNameList appendChildObjectNameList(
            FObjectNameList fNewChild
            )
        {
            FXmlNode fXmlNodeOnd = null;

            try
            {
                fXmlNodeOnd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagOND.E_ObjectNameDefinition);

                // --

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeOnd.appendChild(fNewChild.fXmlNode));
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectAppendCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeOnd != null)
                {
                    fXmlNodeOnd.Dispose();
                    fXmlNodeOnd = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FObjectNameList insertBeforeChildObjectNameList(
            FObjectNameList fNewChild,
            FObjectNameList fRefChild
            )
        {
            FXmlNode fXmlNodeOnd = null;

            try
            {
                fXmlNodeOnd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagOND.E_ObjectNameDefinition);

                // --

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(fXmlNodeOnd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeOnd.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectInsertBeforeCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeOnd != null)
                {
                    fXmlNodeOnd.Dispose();
                    fXmlNodeOnd = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FObjectNameList insertAfterChildObjectNameList(
            FObjectNameList fNewChild,
            FObjectNameList fRefChild
            )
        {
            FXmlNode fXmlNodeOnd = null;

            try
            {
                fXmlNodeOnd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagOND.E_ObjectNameDefinition);

                // --

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(fXmlNodeOnd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeOnd.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeOnd != null)
                {
                    fXmlNodeOnd.Dispose();
                    fXmlNodeOnd = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FObjectNameList removeChildObjectNameList(
            FObjectNameList fChild
            )
        {
            FXmlNode fXmlNodeOnd = null;

            try
            {
                fXmlNodeOnd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagOND.E_ObjectNameDefinition);
                FSecsDriverCommon.validateRemoveChildObject(fXmlNodeOnd, fChild.fXmlNode);

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
                if (fXmlNodeOnd != null)
                {
                    fXmlNodeOnd.Dispose();
                    fXmlNodeOnd = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeChildObjectNameList(
            FObjectNameList[] fChilds
            )
        {
            FXmlNode fXmlNodeOnd = null;

            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                fXmlNodeOnd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagOND.E_ObjectNameDefinition);
                foreach (FObjectNameList fOnl in fChilds)
                {
                    FSecsDriverCommon.validateRemoveChildObject(fXmlNodeOnd, fOnl.fXmlNode);
                }

                // --

                foreach (FObjectNameList fOnl in fChilds)
                {
                    fOnl.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeOnd != null)
                {
                    fXmlNodeOnd.Dispose();
                    fXmlNodeOnd = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeAllChildObjectNameList(
            )
        {
            FObjectNameListCollection fOnlCollection = null;

            try
            {
                fOnlCollection = this.fChildObjectNameListCollection;
                if (fOnlCollection.count == 0)
                {
                    return;
                }

                // --

                foreach (FObjectNameList fOnl in fOnlCollection)
                {
                    fOnl.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fOnlCollection != null)
                {
                    fOnlCollection.Dispose();
                    fOnlCollection = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FFunctionNameList appendChildFuntionNameList(
            FFunctionNameList fNewChild
            )
        {
            FXmlNode fXmlNodeFnd = null;

            try
            {
                fXmlNodeFnd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagFND.E_FunctionNameDefinition);

                // --

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeFnd.appendChild(fNewChild.fXmlNode));
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectAppendCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeFnd != null)
                {
                    fXmlNodeFnd.Dispose();
                    fXmlNodeFnd = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FFunctionNameList insertBeforeChildFunctionNameList(
            FFunctionNameList fNewChild,
            FFunctionNameList fRefChild
            )
        {
            FXmlNode fXmlNodeFnd = null;

            try
            {
                fXmlNodeFnd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagFND.E_FunctionNameDefinition);

                // --

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(fXmlNodeFnd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeFnd.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectInsertBeforeCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeFnd != null)
                {
                    fXmlNodeFnd.Dispose();
                    fXmlNodeFnd = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FFunctionNameList insertAfterChildFunctionNameList(
            FFunctionNameList fNewChild,
            FFunctionNameList fRefChild
            )
        {
            FXmlNode fXmlNodeFnd = null;

            try
            {
                fXmlNodeFnd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagFND.E_FunctionNameDefinition);

                // --

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(fXmlNodeFnd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeFnd.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeFnd != null)
                {
                    fXmlNodeFnd.Dispose();
                    fXmlNodeFnd = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FFunctionNameList removeChildFunctionNameList(
            FFunctionNameList fChild
            )
        {
            FXmlNode fXmlNodeFnd = null;

            try
            {
                fXmlNodeFnd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagFND.E_FunctionNameDefinition);
                FSecsDriverCommon.validateRemoveChildObject(fXmlNodeFnd, fChild.fXmlNode);

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
                if (fXmlNodeFnd != null)
                {
                    fXmlNodeFnd.Dispose();
                    fXmlNodeFnd = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeChildFunctionNameList(
            FFunctionNameList[] fChilds
            )
        {
            FXmlNode fXmlNodeFnd = null;

            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                fXmlNodeFnd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagFND.E_FunctionNameDefinition);
                foreach (FFunctionNameList fFnl in fChilds)
                {
                    FSecsDriverCommon.validateRemoveChildObject(fXmlNodeFnd, fFnl.fXmlNode);
                }

                // --

                foreach (FFunctionNameList fFnl in fChilds)
                {
                    fFnl.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeFnd != null)
                {
                    fXmlNodeFnd.Dispose();
                    fXmlNodeFnd = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeAllChildFunctionNameList(
            )
        {
            FFunctionNameListCollection fFnlCollection = null;

            try
            {
                fFnlCollection = this.fChildFunctionNameListCollection;
                if (fFnlCollection.count == 0)
                {
                    return;
                }

                // --

                foreach (FFunctionNameList fFnl in fFnlCollection)
                {
                    fFnl.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fFnlCollection != null)
                {
                    fFnlCollection.Dispose();
                    fFnlCollection = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDataConversionSetList appendChildDataConversionSetList(
            FDataConversionSetList fNewChild
            )
        {
            FXmlNode fXmlNodeDcd = null;

            try
            {
                fXmlNodeDcd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagDCD.E_DataConversionSetDefinition);

                // --

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeDcd.appendChild(fNewChild.fXmlNode));
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectAppendCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeDcd != null)
                {
                    fXmlNodeDcd.Dispose();
                    fXmlNodeDcd = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDataConversionSetList insertBeforeChildDataConversionSetList(
            FDataConversionSetList fNewChild,
            FDataConversionSetList fRefChild
            )
        {
            FXmlNode fXmlNodeEsd = null;

            try
            {
                fXmlNodeEsd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagDCD.E_DataConversionSetDefinition);

                // --

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(fXmlNodeEsd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeEsd.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectInsertBeforeCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeEsd != null)
                {
                    fXmlNodeEsd.Dispose();
                    fXmlNodeEsd = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDataConversionSetList insertAfterChildDataConversionSetList(
            FDataConversionSetList fNewChild,
            FDataConversionSetList fRefChild
            )
        {
            FXmlNode fXmlNodeEsd = null;

            try
            {
                fXmlNodeEsd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagDCD.E_DataConversionSetDefinition);

                // --

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(fXmlNodeEsd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeEsd.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeEsd != null)
                {
                    fXmlNodeEsd.Dispose();
                    fXmlNodeEsd = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDataConversionSetList removeChildDataConversionSetList(
            FDataConversionSetList fChild
            )
        {
            FXmlNode fXmlNodeDcd = null;

            try
            {
                fXmlNodeDcd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagDCD.E_DataConversionSetDefinition);
                FSecsDriverCommon.validateRemoveChildObject(fXmlNodeDcd, fChild.fXmlNode);

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
                if (fXmlNodeDcd != null)
                {
                    fXmlNodeDcd.Dispose();
                    fXmlNodeDcd = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeChildDataConversionSetList(
            FDataConversionSetList[] fChilds
            )
        {
            FXmlNode fXmlNodeDcd = null;

            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                fXmlNodeDcd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagDCD.E_DataConversionSetDefinition);
                foreach (FDataConversionSetList fDcl in fChilds)
                {
                    FSecsDriverCommon.validateRemoveChildObject(fXmlNodeDcd, fDcl.fXmlNode);
                }

                // --

                foreach (FDataConversionSetList fDcl in fChilds)
                {
                    fDcl.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeDcd != null)
                {
                    fXmlNodeDcd.Dispose();
                    fXmlNodeDcd = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeAllChildDataConversionSetList(
            )
        {
            FDataConversionSetListCollection fDclCollection = null;

            try
            {
                fDclCollection = this.fChildDataConversionSetListCollection;
                if (fDclCollection.count == 0)
                {
                    return;
                }

                // --

                foreach (FDataConversionSetList fDcl in fDclCollection)
                {
                    if (fDcl.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }
                }

                // --

                foreach (FDataConversionSetList fDcl in fDclCollection)
                {
                    fDcl.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fDclCollection != null)
                {
                    fDclCollection.Dispose();
                    fDclCollection = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEquipmentStateSetList appendChildEquipmentStateSetList(
            FEquipmentStateSetList fNewChild
            )
        {
            FXmlNode fXmlNodeEsd = null;

            try
            {
                fXmlNodeEsd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagESD.E_EquipmentStateSetDefinition);

                // --

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeEsd.appendChild(fNewChild.fXmlNode));
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectAppendCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeEsd != null)
                {
                    fXmlNodeEsd.Dispose();
                    fXmlNodeEsd = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEquipmentStateSetList insertBeforeChildEquipmentStateSetList(
            FEquipmentStateSetList fNewChild,
            FEquipmentStateSetList fRefChild
            )
        {
            FXmlNode fXmlNodeEsd = null;

            try
            {
                fXmlNodeEsd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagESD.E_EquipmentStateSetDefinition);

                // --

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(fXmlNodeEsd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeEsd.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectInsertBeforeCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeEsd != null)
                {
                    fXmlNodeEsd.Dispose();
                    fXmlNodeEsd = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEquipmentStateSetList insertAfterChildEquipmentStateSetList(
            FEquipmentStateSetList fNewChild,
            FEquipmentStateSetList fRefChild
            )
        {
            FXmlNode fXmlNodeEsd = null;

            try
            {
                fXmlNodeEsd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagESD.E_EquipmentStateSetDefinition);

                // --

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(fXmlNodeEsd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeEsd.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeEsd != null)
                {
                    fXmlNodeEsd.Dispose();
                    fXmlNodeEsd = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEquipmentStateSetList removeChildEquipmentStateSetList(
            FEquipmentStateSetList fChild
            )
        {
            FXmlNode fXmlNodeEsd = null;

            try
            {
                fXmlNodeEsd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagESD.E_EquipmentStateSetDefinition);
                FSecsDriverCommon.validateRemoveChildObject(fXmlNodeEsd, fChild.fXmlNode);

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
                if (fXmlNodeEsd != null)
                {
                    fXmlNodeEsd.Dispose();
                    fXmlNodeEsd = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeChildEquipmentStateSetList(
            FEquipmentStateSetList[] fChilds
            )
        {
            FXmlNode fXmlNodeEsd = null;

            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                fXmlNodeEsd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagESD.E_EquipmentStateSetDefinition);
                foreach (FEquipmentStateSetList fEsl in fChilds)
                {
                    FSecsDriverCommon.validateRemoveChildObject(fXmlNodeEsd, fEsl.fXmlNode);
                }

                // --

                foreach (FEquipmentStateSetList fEsl in fChilds)
                {
                    fEsl.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeEsd != null)
                {
                    fXmlNodeEsd.Dispose();
                    fXmlNodeEsd = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeAllChildEquipmentStateSetList(
            )
        {
            FEquipmentStateSetListCollection fEslCollection = null;

            try
            {
                fEslCollection = this.fChildEquipmentStateSetListCollection;
                if (fEslCollection.count == 0)
                {
                    return;
                }

                // --

                foreach (FEquipmentStateSetList fEsl in fEslCollection)
                {
                    if (fEsl.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }
                }

                // --

                foreach (FEquipmentStateSetList fEsl in fEslCollection)
                {
                    fEsl.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fEslCollection != null)
                {
                    fEslCollection.Dispose();
                    fEslCollection = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FRepositoryList appendChildRepositoryList(
            FRepositoryList fNewChild
            )
        {
            FXmlNode fXmlNodeRpd = null;

            try
            {
                fXmlNodeRpd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagRPD.E_RepositoryDefinition);

                // -- 

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeRpd.appendChild(fNewChild.fXmlNode));
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectAppendCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeRpd != null)
                {
                    fXmlNodeRpd.Dispose();
                    fXmlNodeRpd = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FRepositoryList insertBeforeChildRepositoryList(
           FRepositoryList fNewChild,
           FRepositoryList fRefChild
           )
        {
            FXmlNode fXmlNodeRpd = null;

            try
            {
                fXmlNodeRpd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagRPD.E_RepositoryDefinition);

                // --

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(fXmlNodeRpd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeRpd.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectInsertBeforeCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeRpd != null)
                {
                    fXmlNodeRpd.Dispose();
                    fXmlNodeRpd = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FRepositoryList insertAfterChildRepositoryList(
            FRepositoryList fNewChild,
            FRepositoryList fRefChild
            )
        {
            FXmlNode fXmlNodeRpd = null;

            try
            {
                fXmlNodeRpd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagRPD.E_RepositoryDefinition);

                // --

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(fXmlNodeRpd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeRpd.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeRpd != null)
                {
                    fXmlNodeRpd.Dispose();
                    fXmlNodeRpd = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FRepositoryList removeChildRepositoryList(
            FRepositoryList fChild
            )
        {
            FXmlNode fXmlNodeRpd = null;

            try
            {
                fXmlNodeRpd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagRPD.E_RepositoryDefinition);
                FSecsDriverCommon.validateRemoveChildObject(fXmlNodeRpd, fChild.fXmlNode);

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
                if (fXmlNodeRpd != null)
                {
                    fXmlNodeRpd.Dispose();
                    fXmlNodeRpd = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeChildRepositoryList(
            FRepositoryList[] fChilds
            )
        {
            FXmlNode fXmlNodeRpd = null;

            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                fXmlNodeRpd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagRPD.E_RepositoryDefinition);
                foreach (FRepositoryList fRpl in fChilds)
                {
                    FSecsDriverCommon.validateRemoveChildObject(fXmlNodeRpd, fRpl.fXmlNode);
                }

                // --

                foreach (FRepositoryList fRpl in fChilds)
                {
                    fRpl.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeRpd != null)
                {
                    fXmlNodeRpd.Dispose();
                    fXmlNodeRpd = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeAllChildRepositoryList(
            )
        {
            FRepositoryListCollection fRplCollection = null;

            try
            {
                fRplCollection = this.fChildRepositoryListCollection;
                if (fRplCollection.count == 0)
                {
                    return;
                }

                // --

                foreach (FRepositoryList fRpl in fRplCollection)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                }

                // --

                foreach (FRepositoryList fRpl in fRplCollection)
                {
                    fRpl.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fRplCollection != null)
                {
                    fRplCollection.Dispose();
                    fRplCollection = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEnvironmentList appendChildEnvironmentList(
            FEnvironmentList fNewChild
            )
        {
            FXmlNode fXmlNodeEnd = null;

            try
            {
                fXmlNodeEnd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagEND.E_EnvironmentDefinition);

                // -- 

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeEnd.appendChild(fNewChild.fXmlNode));
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectAppendCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeEnd != null)
                {
                    fXmlNodeEnd.Dispose();
                    fXmlNodeEnd = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEnvironmentList insertBeforeChildEnvironmentList(
           FEnvironmentList fNewChild,
           FEnvironmentList fRefChild
           )
        {
            FXmlNode fXmlNodeEnd = null;

            try
            {
                fXmlNodeEnd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagEND.E_EnvironmentDefinition);

                // --

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(fXmlNodeEnd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeEnd.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectInsertBeforeCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeEnd != null)
                {
                    fXmlNodeEnd.Dispose();
                    fXmlNodeEnd = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEnvironmentList insertAfterChildEnvironmentList(
            FEnvironmentList fNewChild,
            FEnvironmentList fRefChild
            )
        {
            FXmlNode fXmlNodeEnd = null;

            try
            {
                fXmlNodeEnd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagEND.E_EnvironmentDefinition);

                // --

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(fXmlNodeEnd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeEnd.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeEnd != null)
                {
                    fXmlNodeEnd.Dispose();
                    fXmlNodeEnd = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEnvironmentList removeChildEnvironmentList(
            FEnvironmentList fChild
            )
        {
            FXmlNode fXmlNodeEnd = null;

            try
            {
                fXmlNodeEnd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagEND.E_EnvironmentDefinition);
                FSecsDriverCommon.validateRemoveChildObject(fXmlNodeEnd, fChild.fXmlNode);

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
                if (fXmlNodeEnd != null)
                {
                    fXmlNodeEnd.Dispose();
                    fXmlNodeEnd = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeChildEnvironmentList(
            FEnvironmentList[] fChilds
            )
        {
            FXmlNode fXmlNodeEnd = null;

            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                fXmlNodeEnd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagEND.E_EnvironmentDefinition);
                foreach (FEnvironmentList fEnl in fChilds)
                {
                    FSecsDriverCommon.validateRemoveChildObject(fXmlNodeEnd, fEnl.fXmlNode);
                }

                // --

                foreach (FEnvironmentList fEnl in fChilds)
                {
                    fEnl.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeEnd != null)
                {
                    fXmlNodeEnd.Dispose();
                    fXmlNodeEnd = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeAllChildEnvironmentList(
            )
        {
            FEnvironmentListCollection fEnlCollection = null;

            try
            {
                fEnlCollection = this.fChildEnvironmentListCollection;
                if (fEnlCollection.count == 0)
                {
                    return;
                }

                // --

                foreach (FEnvironmentList fEnl in fEnlCollection)
                {
                    if (fEnl.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }
                }

                // --

                foreach (FEnvironmentList fEnl in fEnlCollection)
                {
                    fEnl.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fEnlCollection != null)
                {
                    fEnlCollection.Dispose();
                    fEnlCollection = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDataSetList appendChildDataSetList(
            FDataSetList fNewChild
            )
        {
            FXmlNode fXmlNodeDsd = null;

            try
            {
                fXmlNodeDsd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagDSD.E_DataSetDefinition);

                // -- 

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeDsd.appendChild(fNewChild.fXmlNode));
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectAppendCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeDsd != null)
                {
                    fXmlNodeDsd.Dispose();
                    fXmlNodeDsd = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDataSetList insertBeforeChildDataSetList(
           FDataSetList fNewChild,
           FDataSetList fRefChild
           )
        {
            FXmlNode fXmlNodeDsd = null;

            try
            {
                fXmlNodeDsd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagDSD.E_DataSetDefinition);

                // --

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(fXmlNodeDsd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeDsd.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectInsertBeforeCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeDsd != null)
                {
                    fXmlNodeDsd.Dispose();
                    fXmlNodeDsd = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDataSetList insertAfterChildDataSetList(
            FDataSetList fNewChild,
            FDataSetList fRefChild
            )
        {
            FXmlNode fXmlNodeDsd = null;

            try
            {
                fXmlNodeDsd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagDSD.E_DataSetDefinition);

                // --

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(fXmlNodeDsd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeDsd.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeDsd != null)
                {
                    fXmlNodeDsd.Dispose();
                    fXmlNodeDsd = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDataSetList removeChildDataSetList(
            FDataSetList fChild
            )
        {
            FXmlNode fXmlNodeRpd = null;

            try
            {
                fXmlNodeRpd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagDSD.E_DataSetDefinition);
                FSecsDriverCommon.validateRemoveChildObject(fXmlNodeRpd, fChild.fXmlNode);

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
                if (fXmlNodeRpd != null)
                {
                    fXmlNodeRpd.Dispose();
                    fXmlNodeRpd = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeChildDataSetList(
            FDataSetList[] fChilds
            )
        {
            FXmlNode fXmlNodeDsd = null;

            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                fXmlNodeDsd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagDSD.E_DataSetDefinition);
                foreach (FDataSetList fDsl in fChilds)
                {
                    FSecsDriverCommon.validateRemoveChildObject(fXmlNodeDsd, fDsl.fXmlNode);
                }

                // --

                foreach (FDataSetList fDsl in fChilds)
                {
                    fDsl.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeDsd != null)
                {
                    fXmlNodeDsd.Dispose();
                    fXmlNodeDsd = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeAllChildDataSetList(
            )
        {
            FDataSetListCollection fDslCollection = null;

            try
            {
                fDslCollection = this.fChildDataSetListCollection;
                if (fDslCollection.count == 0)
                {
                    return;
                }

                // --

                foreach (FDataSetList fDsl in fDslCollection)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                }

                // --

                foreach (FDataSetList fDsl in fDslCollection)
                {
                    fDsl.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fDslCollection != null)
                {
                    fDslCollection.Dispose();
                    fDslCollection = null;
                }
            }
        }              
        
        //------------------------------------------------------------------------------------------------------------------------

        public FSecsLibraryGroup appendChildSecsLibraryGroup(
            FSecsLibraryGroup fNewChild
            )
        {
            FXmlNode fXmlNodeSlm = null;

            try
            {
                fXmlNodeSlm = this.fXmlNode.selectSingleNode(FXmlTagSLM.E_SecsLibraryModeling);

                // --

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeSlm.appendChild(fNewChild.fXmlNode));                
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectAppendCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeSlm != null)
                {
                    fXmlNodeSlm.Dispose();
                    fXmlNodeSlm = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsLibraryGroup insertBeforeChildSecsLibraryGroup(
            FSecsLibraryGroup fNewChild, 
            FSecsLibraryGroup fRefChild
            )
        {
            FXmlNode fXmlNodeSlm = null;

            try
            {
                fXmlNodeSlm = this.fXmlNode.selectSingleNode(FXmlTagSLM.E_SecsLibraryModeling);

                // --

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(fXmlNodeSlm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeSlm.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectInsertBeforeCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeSlm != null)
                {
                    fXmlNodeSlm.Dispose();
                    fXmlNodeSlm = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsLibraryGroup insertAfterChildSecsLibraryGroup(
            FSecsLibraryGroup fNewChild,
            FSecsLibraryGroup fRefChild
            )
        {
            FXmlNode fXmlNodeSlm = null;

            try
            {
                fXmlNodeSlm = this.fXmlNode.selectSingleNode(FXmlTagSLM.E_SecsLibraryModeling);

                // --
                
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(fXmlNodeSlm, fRefChild.fXmlNode);
                
                // --

                fNewChild.replace(this.fScdCore, fXmlNodeSlm.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeSlm != null)
                {
                    fXmlNodeSlm.Dispose();
                    fXmlNodeSlm = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsLibraryGroup removeChildSecsLibraryGroup(
            FSecsLibraryGroup fChild
            )
        {
            FXmlNode fXmlNodeSlm = null;

            try
            {
                fXmlNodeSlm = this.fXmlNode.selectSingleNode(FXmlTagSLM.E_SecsLibraryModeling);
                FSecsDriverCommon.validateRemoveChildObject(fXmlNodeSlm, fChild.fXmlNode);

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
                if (fXmlNodeSlm != null)
                {
                    fXmlNodeSlm.Dispose();
                    fXmlNodeSlm = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeChildSecsLibraryGroup(
            FSecsLibraryGroup[] fChilds
            )
        {
            FXmlNode fXmlNodeSlm = null;

            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --
                
                fXmlNodeSlm = this.fXmlNode.selectSingleNode(FXmlTagSLM.E_SecsLibraryModeling);
                foreach (FSecsLibraryGroup fSlg in fChilds)
                {
                    FSecsDriverCommon.validateRemoveChildObject(fXmlNodeSlm, fSlg.fXmlNode);                    
                }
                
                // --

                foreach (FSecsLibraryGroup fSlg in fChilds)
                {
                    fSlg.remove();
                }                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeSlm != null)
                {
                    fXmlNodeSlm.Dispose();
                    fXmlNodeSlm = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeAllChildSecsLibraryGroup(
            )
        {
            FSecsLibraryGroupCollection fSlgCollection = null;

            try
            {
                fSlgCollection = this.fChildSecsLibraryGroupCollection;
                if (fSlgCollection.count == 0)
                {
                    return;
                }                

                // --

                foreach (FSecsLibraryGroup fSlg in fSlgCollection)
                {
                    if (fSlg.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }
                }                

                // --

                foreach (FSecsLibraryGroup fSlg in fSlgCollection)
                {
                    fSlg.remove();
                }                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fSlgCollection != null)
                {
                    fSlgCollection.Dispose();
                    fSlgCollection = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsDevice appendChildSecsDevice(
            FSecsDevice fNewChild
            )
        {
            FXmlNode fXmlNodeSdm = null;

            try
            {
                fXmlNodeSdm = this.fXmlNode.selectSingleNode(FXmlTagSDM.E_SecsDeviceModeling);

                // --

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeSdm.appendChild(fNewChild.fXmlNode));                
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectAppendCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeSdm != null)
                {
                    fXmlNodeSdm.Dispose();
                    fXmlNodeSdm = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsDevice insertBeforeChildSecsDevice(
           FSecsDevice fNewChild,
           FSecsDevice fRefChild
           )
        {
            FXmlNode fXmlNodeSdm = null;

            try
            {
                fXmlNodeSdm = this.fXmlNode.selectSingleNode(FXmlTagSDM.E_SecsDeviceModeling);

                // --

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(fXmlNodeSdm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeSdm.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectInsertBeforeCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeSdm != null)
                {
                    fXmlNodeSdm.Dispose();
                    fXmlNodeSdm = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsDevice insertAfterChildSecsDevice(
           FSecsDevice fNewChild,
           FSecsDevice fRefChild
           )
        {
            FXmlNode fXmlNodeSdm = null;

            try
            {
                fXmlNodeSdm = this.fXmlNode.selectSingleNode(FXmlTagSDM.E_SecsDeviceModeling);

                // --

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(fXmlNodeSdm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeSdm.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeSdm != null)
                {
                    fXmlNodeSdm.Dispose();
                    fXmlNodeSdm = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsDevice removeChildSecsDevice(
            FSecsDevice fChild
            )
        {
            FXmlNode fXmlNodeSdm = null;

            try
            {
                fXmlNodeSdm = this.fXmlNode.selectSingleNode(FXmlTagSDM.E_SecsDeviceModeling);
                FSecsDriverCommon.validateRemoveChildObject(fXmlNodeSdm, fChild.fXmlNode);

                if (fChild.fState != FDeviceState.Closed)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0027, "Device"));
                }

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
                if (fXmlNodeSdm != null)
                {
                    fXmlNodeSdm.Dispose();
                    fXmlNodeSdm = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeChildSecsDevice(
            FSecsDevice[] fChilds
            )
        {
            FXmlNode fXmlNodeSdm = null;

            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                fXmlNodeSdm = this.fXmlNode.selectSingleNode(FXmlTagSDM.E_SecsDeviceModeling);
                foreach (FSecsDevice fSdv in fChilds)
                {
                    FSecsDriverCommon.validateRemoveChildObject(fXmlNodeSdm, fSdv.fXmlNode);
                    // --
                    if (fSdv.fState != FDeviceState.Closed)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0027, "Device"));
                    }                                        
                }

                // --

                foreach (FSecsDevice fSdv in fChilds)
                {
                    fSdv.remove();
                }                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeSdm != null)
                {
                    fXmlNodeSdm.Dispose();
                    fXmlNodeSdm = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeAllChildSecsDevice(
            )
        {
            FSecsDeviceCollection fSdvCollection = null;

            try
            {
                fSdvCollection = this.fChildSecsDeviceCollection;
                if (fSdvCollection.count == 0)
                {
                    return;
                }

                // --

                foreach (FSecsDevice fSdv in fSdvCollection)
                {
                    if (fSdv.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }

                    if (fSdv.fState != FDeviceState.Closed)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0027, "Device"));
                    } 
                }

                // --

                foreach (FSecsDevice fSdv in fSdvCollection)
                {
                    fSdv.remove();
                }                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fSdvCollection != null)
                {
                    fSdvCollection.Dispose();
                    fSdvCollection = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostLibraryGroup appendChildHostLibraryGroup(
            FHostLibraryGroup fNewChild
            )
        {
            FXmlNode fXmlNodeHlm = null;

            try
            {
                fXmlNodeHlm = this.fXmlNode.selectSingleNode(FXmlTagHLM.E_HostLibraryModeling);

                // --

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeHlm.appendChild(fNewChild.fXmlNode));                
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectAppendCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeHlm != null)
                {
                    fXmlNodeHlm.Dispose();
                    fXmlNodeHlm = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostLibraryGroup insertBeforeChildHostLibraryGroup(
            FHostLibraryGroup fNewChild,
            FHostLibraryGroup fRefChild
            )
        {
            FXmlNode fXmlNodeHlm = null;

            try
            {
                fXmlNodeHlm = this.fXmlNode.selectSingleNode(FXmlTagHLM.E_HostLibraryModeling);

                // --

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(fXmlNodeHlm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeHlm.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectInsertBeforeCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeHlm != null)
                {
                    fXmlNodeHlm.Dispose();
                    fXmlNodeHlm = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostLibraryGroup insertAfterChildHostLibraryGroup(
            FHostLibraryGroup fNewChild,
            FHostLibraryGroup fRefChild
            )
        {
            FXmlNode fXmlNodeHlm = null;

            try
            {
                fXmlNodeHlm = this.fXmlNode.selectSingleNode(FXmlTagHLM.E_HostLibraryModeling);

                // --

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(fXmlNodeHlm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeHlm.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeHlm != null)
                {
                    fXmlNodeHlm.Dispose();
                    fXmlNodeHlm = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostLibraryGroup removeChildHostLibraryGroup(
            FHostLibraryGroup fChild
            )
        {
            FXmlNode fXmlNodeHlm = null;

            try
            {
                fXmlNodeHlm = this.fXmlNode.selectSingleNode(FXmlTagHLM.E_HostLibraryModeling);
                FSecsDriverCommon.validateRemoveChildObject(fXmlNodeHlm, fChild.fXmlNode);

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
                if (fXmlNodeHlm != null)
                {
                    fXmlNodeHlm.Dispose();
                    fXmlNodeHlm = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeChildHostLibraryGroup(
            FHostLibraryGroup[] fChilds
            )
        {
            FXmlNode fXmlNodeHlm = null;

            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                fXmlNodeHlm = this.fXmlNode.selectSingleNode(FXmlTagHLM.E_HostLibraryModeling);
                foreach (FHostLibraryGroup fHlg in fChilds)
                {
                    FSecsDriverCommon.validateRemoveChildObject(fXmlNodeHlm, fHlg.fXmlNode);
                }

                // --

                foreach (FHostLibraryGroup fHlg in fChilds)
                {
                    fHlg.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeHlm != null)
                {
                    fXmlNodeHlm.Dispose();
                    fXmlNodeHlm = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeAllChildHostLibraryGroup(
            )
        {
            FHostLibraryGroupCollection fHlgCollection = null;

            try
            {
                fHlgCollection = this.fChildHostLibraryGroupCollection;
                if (fHlgCollection.count == 0)
                {
                    return;
                }

                // --

                foreach (FHostLibraryGroup fHlg in fHlgCollection)
                {
                    if (fHlg.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }
                }

                // --

                foreach (FHostLibraryGroup fHlg in fHlgCollection)
                {
                    fHlg.remove();
                }                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fHlgCollection != null)
                {
                    fHlgCollection.Dispose();
                    fHlgCollection = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostDevice appendChildHostDevice(
            FHostDevice fNewChild
            )
        {
            FXmlNode fXmlNodeHdm = null;

            try
            {
                fXmlNodeHdm = this.fXmlNode.selectSingleNode(FXmlTagHDM.E_HostDeviceModeling);

                // --

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeHdm.appendChild(fNewChild.fXmlNode));                
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectAppendCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeHdm != null)
                {
                    fXmlNodeHdm.Dispose();
                    fXmlNodeHdm = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostDevice insertBeforeChildHostDevice(
           FHostDevice fNewChild,
           FHostDevice fRefChild
           )
        {
            FXmlNode fXmlNodeHdm = null;

            try
            {
                fXmlNodeHdm = this.fXmlNode.selectSingleNode(FXmlTagHDM.E_HostDeviceModeling);

                // --

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(fXmlNodeHdm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeHdm.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectInsertBeforeCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeHdm != null)
                {
                    fXmlNodeHdm.Dispose();
                    fXmlNodeHdm = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostDevice insertAfterChildHostDevice(
           FHostDevice fNewChild,
           FHostDevice fRefChild
           )
        {
            FXmlNode fXmlNodeHdm = null;

            try
            {
                fXmlNodeHdm = this.fXmlNode.selectSingleNode(FXmlTagHDM.E_HostDeviceModeling);

                // --

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(fXmlNodeHdm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeHdm.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeHdm != null)
                {
                    fXmlNodeHdm.Dispose();
                    fXmlNodeHdm = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostDevice removeChildHostDevice(
            FHostDevice fChild
            )
        {
            FXmlNode fXmlNodeHdm = null;

            try
            {
                fXmlNodeHdm = this.fXmlNode.selectSingleNode(FXmlTagHDM.E_HostDeviceModeling);
                FSecsDriverCommon.validateRemoveChildObject(fXmlNodeHdm, fChild.fXmlNode);

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
                if (fXmlNodeHdm != null)
                {
                    fXmlNodeHdm.Dispose();
                    fXmlNodeHdm = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeChildHostDevice(
            FHostDevice[] fChilds
            )
        {
            FXmlNode fXmlNodeHdm = null;

            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                fXmlNodeHdm = this.fXmlNode.selectSingleNode(FXmlTagHDM.E_HostDeviceModeling);
                foreach (FHostDevice fHdv in fChilds)
                {
                    FSecsDriverCommon.validateRemoveChildObject(fXmlNodeHdm, fHdv.fXmlNode);
                }

                // --

                foreach (FHostDevice fHdv in fChilds)
                {
                    fHdv.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeHdm != null)
                {
                    fXmlNodeHdm.Dispose();
                    fXmlNodeHdm = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeAllChildHostDevice(
            )
        {
            FHostDeviceCollection fHdvCollection = null;

            try
            {
                fHdvCollection = this.fChildHostDeviceCollection;
                if (fHdvCollection.count == 0)
                {
                    return;
                }

                // --

                foreach (FHostDevice fHdv in fHdvCollection)
                {
                    if (fHdv.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }
                }

                // --

                foreach (FHostDevice fHdv in fHdvCollection)
                {
                    fHdv.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fHdvCollection != null)
                {
                    fHdvCollection.Dispose();
                    fHdvCollection = null;
                }
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        public FEquipment appendChildEquipment(
            FEquipment fNewChild
            )
        {
            FXmlNode fXmlNodeEqm = null;

            try
            {
                fXmlNodeEqm = this.fXmlNode.selectSingleNode(FXmlTagEQM.E_EquipmentModeling);

                // --

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeEqm.appendChild(fNewChild.fXmlNode));                
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectAppendCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeEqm != null)
                {
                    fXmlNodeEqm.Dispose();
                    fXmlNodeEqm = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEquipment insertBeforeChildEquipment(
           FEquipment fNewChild,
           FEquipment fRefChild
           )
        {
            FXmlNode fXmlNodeEqm = null;

            try
            {
                fXmlNodeEqm = this.fXmlNode.selectSingleNode(FXmlTagEQM.E_EquipmentModeling);

                // --

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(fXmlNodeEqm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeEqm.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectInsertBeforeCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeEqm != null)
                {
                    fXmlNodeEqm.Dispose();
                    fXmlNodeEqm = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEquipment insertAfterChildEquipment(
           FEquipment fNewChild,
           FEquipment fRefChild
           )
        {
            FXmlNode fXmlNodeEqm = null;

            try
            {
                fXmlNodeEqm = this.fXmlNode.selectSingleNode(FXmlTagEQM.E_EquipmentModeling);

                // --

                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(fXmlNodeEqm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fScdCore, fXmlNodeEqm.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this, this, fNewChild)
                    );

                // --

                return fNewChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeEqm != null)
                {
                    fXmlNodeEqm.Dispose();
                    fXmlNodeEqm = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEquipment removeChildEquipment(
            FEquipment fChild
            )
        {
            FXmlNode fXmlNodeEqm = null;

            try
            {
                fXmlNodeEqm = this.fXmlNode.selectSingleNode(FXmlTagEQM.E_EquipmentModeling);
                FSecsDriverCommon.validateRemoveChildObject(fXmlNodeEqm, fChild.fXmlNode);

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
                if (fXmlNodeEqm != null)
                {
                    fXmlNodeEqm.Dispose();
                    fXmlNodeEqm = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeChildEquipment(
            FEquipment[] fChilds
            )
        {
            FXmlNode fXmlNodeEqm = null;

            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                fXmlNodeEqm = this.fXmlNode.selectSingleNode(FXmlTagEQM.E_EquipmentModeling);
                foreach (FEquipment fEqp in fChilds)
                {
                    FSecsDriverCommon.validateRemoveChildObject(fXmlNodeEqm, fEqp.fXmlNode);
                }

                // --

                foreach (FEquipment fEqp in fChilds)
                {
                    fEqp.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeEqm != null)
                {
                    fXmlNodeEqm.Dispose();
                    fXmlNodeEqm = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeAllChildEquipment(
            )
        {
            FEquipmentCollection fEqpCollection = null;

            try
            {
                fEqpCollection = this.fChildEquipmentCollection;
                if (fEqpCollection.count == 0)
                {
                    return;
                }

                // --

                foreach (FEquipment fEqp in fEqpCollection)
                {
                    if (fEqp.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }
                }

                // --

                foreach (FEquipment fEqp in fEqpCollection)
                {
                    fEqp.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fEqpCollection != null)
                {
                    fEqpCollection.Dispose();
                    fEqpCollection = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FObjectNameList pasteChildObjectNameList(
            )
        {
            FObjectNameList fObjectNameList = null;

            try
            {
                FSecsDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.ObjectNameList);

                // --

                fObjectNameList = (FObjectNameList)this.pasteObject(FCbObjectFormat.ObjectNameList);
                this.appendChildObjectNameList(fObjectNameList);

                // --

                return fObjectNameList;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fObjectNameList = null; 
            }            
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FFunctionNameList pasteChildFunctionNameList(
            )
        {
            FFunctionNameList fFunctionNameList = null;

            try
            {
                FSecsDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.FunctionNameList);

                // --

                fFunctionNameList = (FFunctionNameList)this.pasteObject(FCbObjectFormat.FunctionNameList);
                this.appendChildFuntionNameList(fFunctionNameList);

                // --

                return fFunctionNameList;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fFunctionNameList = null; 
            }


            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDataConversionSetList pasteChildDataConversionSetList(
            )
        {
            FDataConversionSetList fDataConversionSetList = null;

            try
            {
                FSecsDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.DataConversionSetList);

                // --

                fDataConversionSetList = (FDataConversionSetList)this.pasteObject(FCbObjectFormat.DataConversionSetList);
                this.appendChildDataConversionSetList(fDataConversionSetList);

                // --

                return fDataConversionSetList;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fDataConversionSetList = null;
            }
            return null;

        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEquipmentStateSetList pasteChildEquipmentStateSetList(
            )
        {
            FEquipmentStateSetList fEquipmentStateSetList = null;

            try
            {
                FSecsDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.EquipmentStateSetList);

                // --

                fEquipmentStateSetList = (FEquipmentStateSetList)this.pasteObject(FCbObjectFormat.EquipmentStateSetList);
                this.appendChildEquipmentStateSetList(fEquipmentStateSetList);

                // --

                return fEquipmentStateSetList;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEquipmentStateSetList = null;
            }
            return null;

        }

        //------------------------------------------------------------------------------------------------------------------------

        public FRepositoryList pasteChildRepositoryList(
            )
        {
            FRepositoryList fRepositoryList = null;

            try
            {
                FSecsDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.RepositoryList);

                // --

                fRepositoryList = (FRepositoryList)this.pasteObject(FCbObjectFormat.RepositoryList);
                this.appendChildRepositoryList(fRepositoryList);

                // --

                return fRepositoryList;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fRepositoryList = null;
            }
            return null;

        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEnvironmentList pasteChildEnvironmentList(
            )
        {
            FEnvironmentList fEnvironmentList = null;

            try
            {
                FSecsDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.EnvironmentList);

                //--

                fEnvironmentList = (FEnvironmentList)this.pasteObject(FCbObjectFormat.EnvironmentList);
                this.appendChildEnvironmentList(fEnvironmentList);

                // --

                return fEnvironmentList;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEnvironmentList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDataSetList pasteChildDataSetList(
            )
        {
            FDataSetList fDataSetList = null;

            try
            {
                FSecsDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.DataSetList);

                // --

                fDataSetList = (FDataSetList)this.pasteObject(FCbObjectFormat.DataSetList);
                this.appendChildDataSetList(fDataSetList);

                // --

                return fDataSetList;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fDataSetList = null;
            }
            return null;

        }
        
        //------------------------------------------------------------------------------------------------------------------------

        public FSecsLibraryGroup pasteChildSecsLibraryGroup(
            )
        {
            FSecsLibraryGroup fSecsLibraryGroup = null;

            try
            {
                FSecsDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.SecsLibraryGroup);

                // -- 

                fSecsLibraryGroup = (FSecsLibraryGroup)this.pasteObject(FCbObjectFormat.SecsLibraryGroup);
                this.appendChildSecsLibraryGroup(fSecsLibraryGroup);

                // --

                return fSecsLibraryGroup;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecsLibraryGroup = null;
            }

            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsDevice pasteChildSecsDevice(
            )
        {
            FSecsDevice fSecsDevice = null;

            try
            {
                FSecsDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.SecsDevice);

                // -- 

                fSecsDevice = (FSecsDevice)this.pasteObject(FCbObjectFormat.SecsDevice);                
                // --
                fSecsDevice.changeState(FDeviceState.Closed);
                // --
                foreach (FSecsSession fSsn in fSecsDevice.fChildSecsSessionCollection)
                {
                    fSsn.fXmlNode.set_attrVal(FXmlTagSSN.A_SecsLibraryId, FXmlTagSSN.D_SecsLibraryId, "");
                }
                this.appendChildSecsDevice(fSecsDevice);

                // --

                return fSecsDevice;
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

        public FHostLibraryGroup pasteChildHostLibraryGroup(
            )
        {
            FHostLibraryGroup fHostLibraryGroup = null;

            try
            {
                FSecsDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.HostLibraryGroup);

                // -- 

                fHostLibraryGroup = (FHostLibraryGroup)this.pasteObject(FCbObjectFormat.HostLibraryGroup);
                this.appendChildHostLibraryGroup(fHostLibraryGroup);

                // --

                return fHostLibraryGroup;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fHostLibraryGroup = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostDevice pasteChildHostDevice(
            )
        {
            FHostDevice fHostDevice = null;

            try
            {
                FSecsDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.HostDevice);

                // --

                fHostDevice = (FHostDevice)this.pasteObject(FCbObjectFormat.HostDevice);
                // --
                fHostDevice.changeState(FDeviceState.Closed);
                // --                 
                foreach (FHostSession fHsn in fHostDevice.fChildHostSessionCollection)
                {
                    fHsn.fXmlNode.set_attrVal(FXmlTagHSN.A_HostLibraryId, FXmlTagHSN.D_HostLibraryId, "");
                }
                this.appendChildHostDevice(fHostDevice);

                // --

                return fHostDevice;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fHostDevice = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEquipment pasteChildEquipment(
            )
        {
            FEquipment fEquipment = null;

            try
            {
                FSecsDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.Equipment);

                // -- 

                fEquipment = (FEquipment)this.pasteObject(FCbObjectFormat.Equipment);
                this.appendChildEquipment(fEquipment);

                // --

                return fEquipment;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEquipment = null;
            }
            return null;
        }
                
        //------------------------------------------------------------------------------------------------------------------------

        public void openModelingFile(
            string fileName
            )
        {
            try
            {
                // ***
                // 2012.11.19 by spike.lee
                // 새로운 File Open할 경우 모든 SECS Device와 Host Device를 Close 한다.
                // ***
                closeAllDevice();                
                this.waitEventHandlingCompleted();
                
                // --

                this.fScdCore.openModelingFile(fileName);
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

        public void reopenModelingFile(
            string fileName
            )
        {
            try
            {
                this.fScdCore.reopenModelingFile(fileName);
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

        public void saveModelingFile(
            string fileName
            )
        {
            try
            {
                this.fScdCore.saveModelingFile(fileName);
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

        public void waitEventHandlingCompleted(
            )
        {
            try
            {
                this.fScdCore.fEventPusher.waitEventHandlingCompleted();
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

        public void openAllDevice(
            )
        {
            try
            {
                openAllHostDevice();
                openAllSecsDevice();                
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

        public void openAllSecsDevice(
            )
        {
            try
            {
                foreach (FSecsDevice fSdv in this.fChildSecsDeviceCollection)
                {
                    fSdv.open();
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

        public void openAllHostDevice(
            )
        {
            try
            {
                foreach (FHostDevice fHdv in this.fChildHostDeviceCollection)
                {
                    fHdv.open();
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

        public void closeAllDevice(
            )
        {
            try
            {
                closeAllSecsDevice();
                closeAllHostDevice();
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

        public void closeAllSecsDevice(
            )
        {
            try
            {
                foreach (FSecsDevice fSdv in this.fChildSecsDeviceCollection)
                {
                    fSdv.close();
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

        public void closeAllHostDevice(
            )
        {
            try
            {
                foreach (FHostDevice fHdv in this.fChildHostDeviceCollection)
                {
                    fHdv.close();
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

        public FSecsDriverLog createSecsDriverLog(
            )
        {
            try
            {
                return new FSecsDriverLog(this);               
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

        public FSecsDriver cloneSecsDriver(
            )
        {
            try
            {
                return new FSecsDriver(this.fScdCore.fXmlDoc.clone(true));
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

        private FIObject searchCommonSeries(
            string baseUniqueId, 
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
                    if (fXmlNodeSearchList[i].get_attrVal(FXmlTagCommon.A_UniqueId, FXmlTagCommon.D_UniqueId) == baseUniqueId)
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
                        return FSecsDriverCommon.createObject(this.fScdCore, fXmlNodeSearchList[i]);
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
                        return FSecsDriverCommon.createObject(this.fScdCore, fXmlNodeSearchList[i]);
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

        public FIObject searchSecsLibrarySeries(
            FIObject fBaseObject,
            string searchWord
            )
        {
            const string xPath =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + "/" + FXmlTagSLM.E_SecsLibraryModeling + "//*";                

            try
            {
                // ***
                // Secs Library Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.SecsDriver &&
                    fBaseObject.fObjectType != FObjectType.SecsLibraryGroup &&
                    fBaseObject.fObjectType != FObjectType.SecsLibrary &&
                    fBaseObject.fObjectType != FObjectType.SecsMessageList &&
                    fBaseObject.fObjectType != FObjectType.SecsMessages &&
                    fBaseObject.fObjectType != FObjectType.SecsMessage &&
                    fBaseObject.fObjectType != FObjectType.SecsItem
                    )
                {
                    return null;
                }

                // --

                return searchCommonSeries(
                    fBaseObject.uniqueIdToString, 
                    searchWord, 
                    this.fScdCore.fXmlDoc.selectNodes(xPath)
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

        public FIObject searchSecsDeviceSeries(
            FIObject fBaseObject,
            ref FSecsSession fBaseSession,
            string searchWord
            )
        {
            const string xPathSdm =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + "/" + FXmlTagSDM.E_SecsDeviceModeling + "//*";
            // --
            const string xPathSlb =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + "/" + FXmlTagSLM.E_SecsLibraryModeling + "/" + FXmlTagSLG.E_SecsLibraryGroup + "/" +
                FXmlTagSLB.E_SecsLibrary + "[@" + FXmlTagSLB.A_UniqueId + "='{0}']";
            // --            
            const string xPathSlm = ".//*";                
            // --
            const string xPathSsn =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + "/" + FXmlTagSDM.E_SecsDeviceModeling + "/" + FXmlTagSDV.E_SecsDevice + "/" +
                FXmlTagSSN.E_SecsSession + "[@" + FXmlTagSSN.A_UniqueId + "='{0}']";

            string baseUniqueId = string.Empty;
            FXmlNodeList fXmlNodeSdmSearchList = null;
            FXmlNodeList fXmlNodeSlmSearchList = null;
            FXmlNode fXmlNodeSlb = null;
            FXmlNode fXmlNodeSsn = null;
            int index = 0;
            int indexNo = 0;
            string uniqueId = string.Empty;
            string ssnUniqueId = string.Empty;
            string slbUniqueId = string.Empty;
            string[] uniqueIds = null;
            List<string> keys = null;
            List<FXmlNode> values = null;

            try
            {
                // ***
                // Secs Device Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.SecsDriver &&
                    fBaseObject.fObjectType != FObjectType.SecsDevice &&
                    fBaseObject.fObjectType != FObjectType.SecsSession &&
                    fBaseObject.fObjectType != FObjectType.SecsMessageList &&
                    fBaseObject.fObjectType != FObjectType.SecsMessages &&
                    fBaseObject.fObjectType != FObjectType.SecsMessage &&
                    fBaseObject.fObjectType != FObjectType.SecsItem
                   )
                {
                    return null;
                }

                // --

                if (fBaseSession == null)
                {
                    baseUniqueId = fBaseObject.uniqueIdToString;
                }
                else
                {
                    baseUniqueId = fBaseSession.uniqueIdToString + "-" + fBaseObject.uniqueIdToString;
                }
                searchWord = searchWord.ToLower();

                // --

                keys = new List<string>();
                values = new List<FXmlNode>();

                // --

                // ***
                // Search Index
                // ***
                fXmlNodeSdmSearchList = this.fScdCore.fXmlDoc.selectNodes(xPathSdm);
                // --
                foreach (FXmlNode x in fXmlNodeSdmSearchList)
                {
                    uniqueId = x.get_attrVal(FXmlTagCommon.A_UniqueId, FXmlTagCommon.D_UniqueId);
                    // --
                    keys.Add(uniqueId);
                    values.Add(x);
                    // --
                    if (baseUniqueId == uniqueId)
                    {
                        index = indexNo;
                    }
                    indexNo++;

                    // --

                    if (x.name == FXmlTagSSN.E_SecsSession)
                    {
                        ssnUniqueId = uniqueId;
                        slbUniqueId = x.get_attrVal(FXmlTagSSN.A_SecsLibraryId, FXmlTagSSN.D_SecsLibraryId);
                        // --
                        if (slbUniqueId != string.Empty)
                        {
                            fXmlNodeSlb = this.fScdCore.fXmlDoc.selectSingleNode(string.Format(xPathSlb, slbUniqueId));
                            fXmlNodeSlmSearchList = fXmlNodeSlb.selectNodes(xPathSlm);
                            // --
                            foreach (FXmlNode xn in fXmlNodeSlmSearchList)
                            {
                                uniqueId = ssnUniqueId + "-" + xn.get_attrVal(FXmlTagCommon.A_UniqueId, FXmlTagCommon.D_UniqueId);
                                // --
                                keys.Add(uniqueId);
                                values.Add(xn);
                                // --
                                if (baseUniqueId == uniqueId)
                                {
                                    index = indexNo;
                                }
                                indexNo++;
                            }
                        }
                    }
                }

                // --

                // ***
                // Next Search
                // ***
                for (int i = index + 1; i < values.Count; i++)
                {
                    if (FCommon.compareSearchObject(values[i], searchWord))
                    {
                        uniqueIds = keys[i].Split('-');
                        if (uniqueIds.Length == 2)
                        {
                            fXmlNodeSsn = this.fScdCore.fXmlDoc.selectSingleNode(string.Format(xPathSsn, uniqueIds[0]));
                            fBaseSession = (FSecsSession)FSecsDriverCommon.createObject(this.fScdCore, fXmlNodeSsn);
                        }
                        else
                        {
                            fBaseSession = null;
                        }
                        return FSecsDriverCommon.createObject(this.fScdCore, values[i]);
                    }
                }

                // --

                // ***
                // Previous Search
                // ***
                for (int i = 0; i <= index; i++)
                {
                    if (FCommon.compareSearchObject(values[i], searchWord))
                    {
                        uniqueIds = keys[i].Split('-');
                        if (uniqueIds.Length == 2)
                        {
                            fXmlNodeSsn = this.fScdCore.fXmlDoc.selectSingleNode(string.Format(xPathSsn, uniqueIds[0]));
                            fBaseSession = (FSecsSession)FSecsDriverCommon.createObject(this.fScdCore, fXmlNodeSsn);
                        }
                        else
                        {
                            fBaseSession = null;
                        }
                        return FSecsDriverCommon.createObject(this.fScdCore, values[i]);
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
                fXmlNodeSdmSearchList = null;
                fXmlNodeSlmSearchList = null;
                fXmlNodeSlb = null;
                fXmlNodeSsn = null;
                keys = null;
                values = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIObject searchHostLibrarySeries(
            FIObject fBaseObject,
            string searchWord
            )
        {
            const string xPath =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + "/" + FXmlTagHLM.E_HostLibraryModeling + "//*";

            try
            {
                // ***
                // Host Library Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.SecsDriver &&
                    fBaseObject.fObjectType != FObjectType.HostLibraryGroup &&
                    fBaseObject.fObjectType != FObjectType.HostLibrary &&
                    fBaseObject.fObjectType != FObjectType.HostMessageList &&
                    fBaseObject.fObjectType != FObjectType.HostMessages &&
                    fBaseObject.fObjectType != FObjectType.HostMessage &&
                    fBaseObject.fObjectType != FObjectType.HostItem
                    )
                {
                    return null;
                }

                // --

                return searchCommonSeries(
                    fBaseObject.uniqueIdToString,
                    searchWord,
                    this.fScdCore.fXmlDoc.selectNodes(xPath)
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

        public FIObject searchHostDeviceSeries(
           FIObject fBaseObject,
           ref FHostSession fBaseSession,
           string searchWord
           )
        {
            const string xPathHdm =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + "/" + FXmlTagHDM.E_HostDeviceModeling + "//*";
            // --
            const string xPathHlb =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + "/" + FXmlTagHLM.E_HostLibraryModeling + "/" + FXmlTagHLG.E_HostLibraryGroup + "/" +
                FXmlTagHLB.E_HostLibrary + "[@" + FXmlTagHLB.A_UniqueId + "='{0}']";
            // --            
            const string xPatHlm = ".//*";
            // --
            const string xPathHsn =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + "/" + FXmlTagHDM.E_HostDeviceModeling + "/" + FXmlTagHDV.E_HostDevice + "/" +
                FXmlTagHSN.E_HostSession + "[@" + FXmlTagHSN.A_UniqueId + "='{0}']";

            string baseUniqueId = string.Empty;
            FXmlNodeList fXmlNodeHdmSearchList = null;
            FXmlNodeList fXmlNodeHlmSearchList = null;
            FXmlNode fXmlNodeHlb = null;
            FXmlNode fXmlNodeHsn = null;
            int index = 0;
            int indexNo = 0;
            string uniqueId = string.Empty;
            string hsnUniqueId = string.Empty;
            string hlbUniqueId = string.Empty;
            string[] uniqueIds = null;
            List<string> keys = null;
            List<FXmlNode> values = null;

            try
            {
                // ***
                // Host Device Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.SecsDriver &&
                    fBaseObject.fObjectType != FObjectType.HostDevice &&
                    fBaseObject.fObjectType != FObjectType.HostSession &&
                    fBaseObject.fObjectType != FObjectType.HostMessageList &&
                    fBaseObject.fObjectType != FObjectType.HostMessages &&
                    fBaseObject.fObjectType != FObjectType.HostMessage &&
                    fBaseObject.fObjectType != FObjectType.HostItem
                   )
                {
                    return null;
                }

                // --

                if (fBaseSession == null)
                {
                    baseUniqueId = fBaseObject.uniqueIdToString;
                }
                else
                {
                    baseUniqueId = fBaseSession.uniqueIdToString + "-" + fBaseObject.uniqueIdToString;
                }
                searchWord = searchWord.ToLower();

                // --

                keys = new List<string>();
                values = new List<FXmlNode>();

                // --

                // ***
                // Search Index
                // ***
                fXmlNodeHdmSearchList = this.fScdCore.fXmlDoc.selectNodes(xPathHdm);
                // --
                foreach (FXmlNode x in fXmlNodeHdmSearchList)
                {
                    uniqueId = x.get_attrVal(FXmlTagCommon.A_UniqueId, FXmlTagCommon.D_UniqueId);
                    // --
                    keys.Add(uniqueId);
                    values.Add(x);
                    // --
                    if (baseUniqueId == uniqueId)
                    {
                        index = indexNo;
                    }
                    indexNo++;

                    // --

                    if (x.name == FXmlTagHSN.E_HostSession)
                    {
                        hsnUniqueId = uniqueId;
                        hlbUniqueId = x.get_attrVal(FXmlTagHSN.A_HostLibraryId, FXmlTagHSN.D_HostLibraryId);
                        // --
                        if (hlbUniqueId != string.Empty)
                        {
                            fXmlNodeHlb = this.fScdCore.fXmlDoc.selectSingleNode(string.Format(xPathHlb, hlbUniqueId));
                            fXmlNodeHlmSearchList = fXmlNodeHlb.selectNodes(xPatHlm);
                            // --
                            foreach (FXmlNode xn in fXmlNodeHlmSearchList)
                            {
                                uniqueId = hsnUniqueId + "-" + xn.get_attrVal(FXmlTagCommon.A_UniqueId, FXmlTagCommon.D_UniqueId);
                                // --
                                keys.Add(uniqueId);
                                values.Add(xn);
                                // --
                                if (baseUniqueId == uniqueId)
                                {
                                    index = indexNo;
                                }
                                indexNo++;
                            }
                        }
                    }
                }

                // --

                // ***
                // Next Search
                // ***
                for (int i = index + 1; i < values.Count; i++)
                {
                    if (FCommon.compareSearchObject(values[i], searchWord))
                    {
                        uniqueIds = keys[i].Split('-');
                        if (uniqueIds.Length == 2)
                        {
                            fXmlNodeHsn = this.fScdCore.fXmlDoc.selectSingleNode(string.Format(xPathHsn, uniqueIds[0]));
                            fBaseSession = (FHostSession)FSecsDriverCommon.createObject(this.fScdCore, fXmlNodeHsn);
                        }
                        else
                        {
                            fBaseSession = null;
                        }
                        return FSecsDriverCommon.createObject(this.fScdCore, values[i]);
                    }
                }

                // --

                // ***
                // Previous Search
                // ***
                for (int i = 0; i <= index; i++)
                {
                    if (FCommon.compareSearchObject(values[i], searchWord))
                    {
                        uniqueIds = keys[i].Split('-');
                        if (uniqueIds.Length == 2)
                        {
                            fXmlNodeHsn = this.fScdCore.fXmlDoc.selectSingleNode(string.Format(xPathHsn, uniqueIds[0]));
                            fBaseSession = (FHostSession)FSecsDriverCommon.createObject(this.fScdCore, fXmlNodeHsn);
                        }
                        else
                        {
                            fBaseSession = null;
                        }
                        return FSecsDriverCommon.createObject(this.fScdCore, values[i]);
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
                fXmlNodeHdmSearchList = null;
                fXmlNodeHlmSearchList = null;
                fXmlNodeHlb = null;
                fXmlNodeHsn = null;
                keys = null;
                values = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIObject searchObjectNameSeries(
           FIObject fBaseObject,
           string searchWord
           )
        {
            const string xPath =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + "/" + FXmlTagSET.E_Setup + "/" + FXmlTagOND.E_ObjectNameDefinition + "//*";

            try
            {
                // ***
                // Object Name Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.SecsDriver &&
                    fBaseObject.fObjectType != FObjectType.ObjectNameList &&                    
                    fBaseObject.fObjectType != FObjectType.ObjectName
                    )
                {
                    return null;
                }

                // --

                return searchCommonSeries(
                    fBaseObject.uniqueIdToString,
                    searchWord,
                    this.fScdCore.fXmlDoc.selectNodes(xPath)
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

        public FIObject searchFunctionNameSeries(
           FIObject fBaseObject,
           string searchWord
           )
        {
            const string xPath =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + "/" + FXmlTagSET.E_Setup + "/" + FXmlTagFND.E_FunctionNameDefinition + "//*";

            try
            {
                // ***
                // Function Name Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.SecsDriver &&
                    fBaseObject.fObjectType != FObjectType.FunctionNameList &&
                    fBaseObject.fObjectType != FObjectType.FunctionName &&
                    fBaseObject.fObjectType != FObjectType.ParameterName &&
                    fBaseObject.fObjectType != FObjectType.Argument
                    )
                {
                    return null;
                }

                // --

                return searchCommonSeries(
                    fBaseObject.uniqueIdToString,
                    searchWord,
                    this.fScdCore.fXmlDoc.selectNodes(xPath)
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

        public FIObject searchUserTagNameSeries(
           FIObject fBaseObject,
           string searchWord
           )
        {
            const string xPath =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + "/" + FXmlTagSET.E_Setup + "/" + FXmlTagUTD.E_UserTagNameDefinition + "//*";

            try
            {
                // ***
                // User Tag Name Series 검증
                // ***
                if (fBaseObject.fObjectType != FObjectType.UserTagName)
                {
                    return null;
                }

                // --

                return searchCommonSeries(
                    fBaseObject.uniqueIdToString,
                    searchWord,
                    this.fScdCore.fXmlDoc.selectNodes(xPath)
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

        public FIObject searchDataConversionSetSeries(
           FIObject fBaseObject,
           string searchWord
           )
        {
            const string xPath =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + "/" + FXmlTagSET.E_Setup + "/" + FXmlTagDCD.E_DataConversionSetDefinition + "//*";

            try
            {
                // ***
                // Data Conversion Set Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.SecsDriver &&
                    fBaseObject.fObjectType != FObjectType.DataConversionSetList &&
                    fBaseObject.fObjectType != FObjectType.DataConversionSet &&
                    fBaseObject.fObjectType != FObjectType.DataConversion 
                    )
                {
                    return null;
                }

                // --

                return searchCommonSeries(
                    fBaseObject.uniqueIdToString,
                    searchWord,
                    this.fScdCore.fXmlDoc.selectNodes(xPath)
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

        public FIObject searchEquipmentStateSetSeries(
           FIObject fBaseObject,
           string searchWord
           )
        {
            const string xPath =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + "/" + FXmlTagSET.E_Setup + "/" + FXmlTagESD.E_EquipmentStateSetDefinition + "//*";

            try
            {
                // ***
                // Equipment State Set Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.SecsDriver &&
                    fBaseObject.fObjectType != FObjectType.EquipmentStateSetList &&
                    fBaseObject.fObjectType != FObjectType.EquipmentStateSet &&
                    fBaseObject.fObjectType != FObjectType.EquipmentState &&
                    fBaseObject.fObjectType != FObjectType.StateValue
                    )
                {
                    return null;
                }

                // --

                return searchCommonSeries(
                    fBaseObject.uniqueIdToString,
                    searchWord,
                    this.fScdCore.fXmlDoc.selectNodes(xPath)
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

        public FIObject searchRepositorySeries(
           FIObject fBaseObject,
           string searchWord
           )
        {
            const string xPath =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + "/" + FXmlTagSET.E_Setup + "/" + FXmlTagRPD.E_RepositoryDefinition + "//*";

            try
            {
                // ***
                // Repository Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.SecsDriver &&
                    fBaseObject.fObjectType != FObjectType.RepositoryList &&
                    fBaseObject.fObjectType != FObjectType.Repository &&                    
                    fBaseObject.fObjectType != FObjectType.Column
                    )
                {
                    return null;
                }

                // --

                return searchCommonSeries(
                    fBaseObject.uniqueIdToString,
                    searchWord,
                    this.fScdCore.fXmlDoc.selectNodes(xPath)
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

        public FIObject searchEnvironmentSeries(
           FIObject fBaseObject,
           string searchWord
           )
        {
            const string xPath =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + "/" + FXmlTagSET.E_Setup + "/" + FXmlTagEND.E_EnvironmentDefinition + "//*";

            try
            {
                // ***
                // Environment Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.SecsDriver &&
                    fBaseObject.fObjectType != FObjectType.EnvironmentList &&                    
                    fBaseObject.fObjectType != FObjectType.Environment
                    )
                {
                    return null;
                }

                // --

                return searchCommonSeries(
                    fBaseObject.uniqueIdToString,
                    searchWord,
                    this.fScdCore.fXmlDoc.selectNodes(xPath)
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

        public FIObject searchDataSetSeries(
           FIObject fBaseObject,
           string searchWord
           )
        {
            const string xPath =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + "/" + FXmlTagSET.E_Setup + "/" + FXmlTagDSD.E_DataSetDefinition + "//*";

            try
            {
                // ***
                // Data Set Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.SecsDriver &&
                    fBaseObject.fObjectType != FObjectType.DataSetList &&
                    fBaseObject.fObjectType != FObjectType.DataSet &&
                    fBaseObject.fObjectType != FObjectType.Data
                    )
                {
                    return null;
                }

                // --

                return searchCommonSeries(
                    fBaseObject.uniqueIdToString,
                    searchWord,
                    this.fScdCore.fXmlDoc.selectNodes(xPath)
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

        public FIObject searchEquipmentSeries(
           FIObject fBaseObject,
           string searchWord
           )
        {
            const string xPath =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + "/" + FXmlTagEQM.E_EquipmentModeling + "/" + FXmlTagEQP.E_Equipment + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + "/" + FXmlTagEQM.E_EquipmentModeling + "/" + FXmlTagEQP.E_Equipment + " /" + FXmlTagSNG.E_ScenarioGroup + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + "/" + FXmlTagEQM.E_EquipmentModeling + "/" + FXmlTagEQP.E_Equipment + " /" + FXmlTagSNG.E_ScenarioGroup + "/" + FXmlTagSNR.E_Scenario;

            try
            {
                // ***
                // Equipment Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.SecsDriver &&
                    fBaseObject.fObjectType != FObjectType.Equipment &&
                    fBaseObject.fObjectType != FObjectType.ScenarioGroup &&
                    fBaseObject.fObjectType != FObjectType.Scenario
                    )
                {
                    return null;
                }

                // --

                return searchCommonSeries(
                    fBaseObject.uniqueIdToString,
                    searchWord,
                    this.fScdCore.fXmlDoc.selectNodes(xPath)
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

        public FIObject searchScenarioSeries(
           FIObject fBaseObject,
           FScenario fBaseScenario,
           string searchWord
           )
        {
            const string xPath =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagSCD.E_SecsDriver + "/" + FXmlTagEQM.E_EquipmentModeling + "/" + FXmlTagEQP.E_Equipment + " /" + FXmlTagSNG.E_ScenarioGroup + "/" +
                FXmlTagSNR.E_Scenario + "[@" + FXmlTagSNR.A_UniqueId + "='{0}']//*";

            FXmlNodeList fXmlNodeSearchList = null;
            string baseUniqueId = string.Empty;            
            int index = 0;

            try
            {
                // ***
                // Scenario Series 검증
                // ***
                if (fBaseObject != null)
                {
                    if (
                        fBaseObject.fObjectType != FObjectType.SecsTrigger &&
                        fBaseObject.fObjectType != FObjectType.SecsCondition &&
                        fBaseObject.fObjectType != FObjectType.SecsExpression &&
                        fBaseObject.fObjectType != FObjectType.SecsTransmitter &&
                        fBaseObject.fObjectType != FObjectType.SecsTransfer &&
                        fBaseObject.fObjectType != FObjectType.HostTrigger &&
                        fBaseObject.fObjectType != FObjectType.HostCondition &&
                        fBaseObject.fObjectType != FObjectType.HostExpression &&
                        fBaseObject.fObjectType != FObjectType.HostTransmitter &&
                        fBaseObject.fObjectType != FObjectType.HostTransfer &&
                        fBaseObject.fObjectType != FObjectType.Judgement &&
                        fBaseObject.fObjectType != FObjectType.JudgementCondition &&
                        fBaseObject.fObjectType != FObjectType.JudgementExpression &&
                        fBaseObject.fObjectType != FObjectType.Mapper &&
                        fBaseObject.fObjectType != FObjectType.Storage &&
                        fBaseObject.fObjectType != FObjectType.Callback &&
                        fBaseObject.fObjectType != FObjectType.Function &&
                        fBaseObject.fObjectType != FObjectType.Branch &&
                        fBaseObject.fObjectType != FObjectType.Comment &&
                        fBaseObject.fObjectType != FObjectType.Pauser &&
                        fBaseObject.fObjectType != FObjectType.EquipmentStateSetAlterer &&
                        fBaseObject.fObjectType != FObjectType.EquipmentStateAlterer &&
                        fBaseObject.fObjectType != FObjectType.EntryPoint 
                        )
                    {
                        return null;
                    }
                }
                
                // --

                fXmlNodeSearchList = this.fScdCore.fXmlDoc.selectNodes(string.Format(xPath, fBaseScenario.uniqueIdToString));
                if (fXmlNodeSearchList.count == 0)
                {
                    return null;
                }

                // --

                if (fBaseObject == null)
                {
                    index = fXmlNodeSearchList.count - 1;
                }
                else
                {
                    baseUniqueId = fBaseObject.uniqueIdToString;
                    // --
                    for (int i = 0; i < fXmlNodeSearchList.count; i++)
                    {
                        if (fXmlNodeSearchList[i].get_attrVal(FXmlTagCommon.A_UniqueId, FXmlTagCommon.D_UniqueId) == baseUniqueId)
                        {
                            index = i;
                            break;
                        }
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
                        return FSecsDriverCommon.createObject(this.fScdCore, fXmlNodeSearchList[i]);
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
                        return FSecsDriverCommon.createObject(this.fScdCore, fXmlNodeSearchList[i]);
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
                fXmlNodeSearchList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        public FIObject selectSingleObjectByUniqueId(
            UInt64 uniqueId
            )
        {
            string xpath = string.Empty;
            FXmlNode fXmlNode = null;

            try
            {
                xpath = "//*[@" + FXmlTagCommon.A_UniqueId + "='" + uniqueId +"']";
                fXmlNode = this.fXmlNode.selectSingleNode(xpath);
                if (fXmlNode != null)
                {
                    return FSecsDriverCommon.createObject(this.fScdCore, fXmlNode);
                }
                return null;
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

        public FObjectNameListCollection selectObjectNameListByName(
            string name
            )
        {
            const string xpath =
                FXmlTagSET.E_Setup +
                "/" + FXmlTagOND.E_ObjectNameDefinition +
                "/" + FXmlTagONL.E_ObjectNameList + "[@" + FXmlTagONL.A_Name + "='{0}']";

            try
            {
                return new FObjectNameListCollection(
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

        public FObjectNameList selectSingleObjectNameListByName(
            string name
            )
        {
            const string xpath =
                FXmlTagSET.E_Setup +
                "/" + FXmlTagOND.E_ObjectNameDefinition +
                "/" + FXmlTagONL.E_ObjectNameList + "[@" + FXmlTagONL.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FObjectNameList(this.fScdCore, fXmlNode);
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

        public FObjectNameList selectSingleObjectNameListByObjectType(
            FObjectType fObjectType
            )
        {
            const string xpath =
                FXmlTagSET.E_Setup +
                "/" + FXmlTagOND.E_ObjectNameDefinition +
                "/" + FXmlTagONL.E_ObjectNameList + "[@" + FXmlTagONL.A_ObjectType + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, fObjectType.ToString()));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FObjectNameList(this.fScdCore, fXmlNode);
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

        public FFunctionNameListCollection selectFunctionNameListByName(
            string name
            )
        {
            const string xpath =
                FXmlTagSET.E_Setup +
                "/" + FXmlTagFND.E_FunctionNameDefinition +
                "/" + FXmlTagFNL.E_FunctionNameList + "[@" + FXmlTagFNL.A_Name + "='{0}']";

            try
            {
                return new FFunctionNameListCollection(
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

        public FFunctionNameList selectSingleFunctionNameListByName(
            string name
            )
        {
            const string xpath =
                FXmlTagSET.E_Setup +
                "/" + FXmlTagFND.E_FunctionNameDefinition +
                "/" + FXmlTagFNL.E_FunctionNameList + "[@" + FXmlTagFNL.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FFunctionNameList(this.fScdCore, fXmlNode);
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

        public FUserTagNameCollection selectUserTagNameListByName(
            string name
            )
        {
            const string xpath =
                FXmlTagSET.E_Setup +
                "/" + FXmlTagUTD.E_UserTagNameDefinition +
                "/" + FXmlTagUTN.E_UserTagName + "[@" + FXmlTagUTN.A_Name + "='{0}']";

            try
            {
                return new FUserTagNameCollection(
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

        public FUserTagName selectSingleUserTagNameByName(
            string name
            )
        {
            const string xpath =
                FXmlTagSET.E_Setup +
                "/" + FXmlTagUTD.E_UserTagNameDefinition +
                "/" + FXmlTagUTN.E_UserTagName + "[@" + FXmlTagUTN.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FUserTagName(this.fScdCore, fXmlNode);
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

        public FUserTagName selectSingleUserTagNameByObjectType(
            FObjectType fObjectType
            )
        {
            const string xpath =
                FXmlTagSET.E_Setup +
                "/" + FXmlTagUTD.E_UserTagNameDefinition +
                "/" + FXmlTagUTN.E_UserTagName + "[@" + FXmlTagUTN.A_ObjectType + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, fObjectType.ToString()));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FUserTagName(this.fScdCore, fXmlNode);
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

        public FDataConversionSetListCollection selectDataConversionSetListByName(
            string name
            )
        {
            const string xpath =
                FXmlTagSET.E_Setup + "/" +
                FXmlTagDCD.E_DataConversionSetDefinition + "/" +
                FXmlTagDCL.E_DataConversionSetList + "[@" + FXmlTagDCL.A_Name + "='{0}']";

            try
            {
                return new FDataConversionSetListCollection(
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

        public FDataConversionSetList selectSingleDataConversionSetListByName(
            string name
            )
        {
            const string xpath =
                FXmlTagSET.E_Setup + "/" +
                FXmlTagDCD.E_DataConversionSetDefinition + "/" +
                FXmlTagDCL.E_DataConversionSetList + "[@" + FXmlTagDCL.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FDataConversionSetList(this.fScdCore, fXmlNode);
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

        public FEquipmentStateSetListCollection selectEquipmentStateSetListByName(
            string name
            )
        {
            const string xpath =
                FXmlTagSET.E_Setup + "/" +
                FXmlTagESD.E_EquipmentStateSetDefinition + "/" +
                FXmlTagESL.E_EquipmentStateSetList + "[@" + FXmlTagESL.A_Name + "='{0}']";

            try
            {
                return new FEquipmentStateSetListCollection(
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

        public FEquipmentStateSetList selectSingleEquipmentStateSetListByName(
            string name
            )
        {
            const string xpath =
                FXmlTagSET.E_Setup + "/" +
                FXmlTagESD.E_EquipmentStateSetDefinition + "/" +
                FXmlTagESL.E_EquipmentStateSetList + "[@" + FXmlTagESL.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FEquipmentStateSetList(this.fScdCore, fXmlNode);
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

        public FRepositoryListCollection selectRepositoryListByName(
            string name
            )
        {
            const string xpath =
                FXmlTagSET.E_Setup + "/" +
                FXmlTagRPD.E_RepositoryDefinition + "/" +
                FXmlTagRPL.E_RepositoryList + "[@" + FXmlTagRPL.A_Name + "='{0}']";
            
            try
            {
                return new FRepositoryListCollection(
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

        public FRepositoryList selectSingleRepositoryListByName(
            string name
            )
        {
            const string xpath =
                FXmlTagSET.E_Setup + "/" +
                FXmlTagRPD.E_RepositoryDefinition + "/" +
                FXmlTagRPL.E_RepositoryList + "[@" + FXmlTagRPL.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FRepositoryList(this.fScdCore, fXmlNode);
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

        public FDataSetListCollection selectDataSetListByName(
            string name
            )
        {
            const string xpath =
                FXmlTagSET.E_Setup + "/" +
                FXmlTagDSD.E_DataSetDefinition + "/" +
                FXmlTagDSL.E_DataSetList + "[@" + FXmlTagDSL.A_Name + "='{0}']";

            try
            {
                return new FDataSetListCollection(
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

        public FDataSetList selectSingleDataSetListByName(
            string name
            )
        {
            const string xpath =
                FXmlTagSET.E_Setup + "/" +
                FXmlTagDSD.E_DataSetDefinition + "/" +
                FXmlTagDSL.E_DataSetList + "[@" + FXmlTagDSL.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FDataSetList(this.fScdCore, fXmlNode);
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

        public FEnvironmentListCollection selectEnvironmentListByName(
            string name
            )
        {
            const string xpath =
                FXmlTagSET.E_Setup + "/" +
                FXmlTagEND.E_EnvironmentDefinition + "/" +
                FXmlTagENL.E_EnvironmentList + "[@" + FXmlTagENL.A_Name + "='{0}']";

            try
            {
                return new FEnvironmentListCollection(
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

        public FEnvironmentList selectSingleEnvironmentListByName(
            string name
            )
        {
            const string xpath =
                FXmlTagSET.E_Setup + "/" +
                FXmlTagEND.E_EnvironmentDefinition + "/" +
                FXmlTagENL.E_EnvironmentList + "[@" + FXmlTagENL.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FEnvironmentList(this.fScdCore, fXmlNode);
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

        public FSecsLibraryGroupCollection selectSecsLibraryGroupByName(
            string name
            )
        {
            const string xpath = FXmlTagSLM.E_SecsLibraryModeling +
                "/" + FXmlTagSLG.E_SecsLibraryGroup + "[@" + FXmlTagSLG.A_Name + "='{0}']";

            try
            {
                return new FSecsLibraryGroupCollection(
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

        public FSecsLibraryGroup selectSingleSecsLibraryGroupByName(
            string name
            )
        {
            const string xpath = FXmlTagSLM.E_SecsLibraryModeling +
                "/" + FXmlTagSLG.E_SecsLibraryGroup + "[@" + FXmlTagSLG.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsLibraryGroup(this.fScdCore, fXmlNode);
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

        public FSecsDeviceCollection selectSecsDeviceByName(
            string name
            )
        {
            const string xpath =
                FXmlTagSDM.E_SecsDeviceModeling +
                "/" + FXmlTagSDV.E_SecsDevice + "[@" + FXmlTagSDV.A_Name + "='{0}']";

            try
            {
                return new FSecsDeviceCollection(
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

        public FSecsDevice selectSingleSecsDeviceByName(
            string name
            )
        {
            const string xpath =
                FXmlTagSDM.E_SecsDeviceModeling +
                "/" + FXmlTagSDV.E_SecsDevice + "[@" + FXmlTagSDV.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsDevice(this.fScdCore, fXmlNode);
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

        public FHostLibraryGroupCollection selectHostLibraryGroupByName(
            string name
            )
        {
            const string xpath = FXmlTagHLM.E_HostLibraryModeling +
                "/" + FXmlTagHLG.E_HostLibraryGroup + "[@" + FXmlTagHLG.A_Name + "='{0}']";

            try
            {
                return new FHostLibraryGroupCollection(
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

        public FHostLibraryGroup selectSingleHostLibraryGroupByName(
            string name
            )
        {
            const string xpath = FXmlTagHLM.E_HostLibraryModeling +
                "/" + FXmlTagHLG.E_HostLibraryGroup + "[@" + FXmlTagHLG.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FHostLibraryGroup(this.fScdCore, fXmlNode);
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

        public FHostDeviceCollection selectHostDeviceByName(
            string name
            )
        {
            const string xpath =
                FXmlTagHDM.E_HostDeviceModeling +
                "/" + FXmlTagHDV.E_HostDevice + "[@" + FXmlTagHDV.A_Name + "='{0}']";

            try
            {
                return new FHostDeviceCollection(
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

        public FHostDevice selectSingleHostDeviceByName(
            string name
            )
        {
            const string xpath =
                FXmlTagHDM.E_HostDeviceModeling +
                "/" + FXmlTagHDV.E_HostDevice + "[@" + FXmlTagHDV.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FHostDevice(this.fScdCore, fXmlNode);
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

        public FEquipmentCollection selectEquipmentByName(
            string name
            )
        {
            const string xpath =
                FXmlTagEQM.E_EquipmentModeling +
                "/" + FXmlTagEQP.E_Equipment + "[@" + FXmlTagEQP.A_Name + "='{0}']";

            try
            {
                return new FEquipmentCollection(
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

        public FEquipment selectSingleEquipmentByName(
            string name
            )
        {
            const string xpath =
                FXmlTagEQM.E_EquipmentModeling +
                "/" + FXmlTagEQP.E_Equipment + "[@" + FXmlTagEQP.A_Name + "='{0}']";
            
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FEquipment(this.fScdCore, fXmlNode);
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

        public FEntryPoint selectSingleEntryPointByName(
            string name
            )
        {
            const string xpath =
                FXmlTagEQM.E_EquipmentModeling +
                "/" + FXmlTagEQP.E_Equipment +
                "/" + FXmlTagSNG.E_ScenarioGroup +
                "/" + FXmlTagSNR.E_Scenario +
                "/" + FXmlTagETP.E_EntryPoint + "[@" + FXmlTagEQP.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FEntryPoint(this.fScdCore, fXmlNode);
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

        public FObjectCollection selectEntryPointByName(
            string name
            )
        {
            const string xpath =
               FXmlTagEQM.E_EquipmentModeling +
               "/" + FXmlTagEQP.E_Equipment +
               "/" + FXmlTagSNG.E_ScenarioGroup +
               "/" + FXmlTagSNR.E_Scenario +
               "/" + FXmlTagETP.E_EntryPoint + "[@" + FXmlTagEQP.A_Name + "='{0}']";

            try
            {
                return new FObjectCollection(
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

        public void pushEntryPointEvent(
            FEntryPoint fEntryPoint,
            object entryPointData
            )
        {
            try
            {
                // ***
                // Entry Point 개체가 Modeling File에 포함된 개체인지 검사
                // ***                
                if (!this.equalsModelingFile(fEntryPoint))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the SECS Driver and the Entry Point", "same"));
                }

                // --

                this.fScdCore.fEventPusher.pushEntryPointCalledEvent(
                    FResultCode.Success, 
                    string.Empty, 
                    fEntryPoint.fXmlNode,
                    entryPointData
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

        public FIObject getParentOfObject(
            FIObject fObject
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                if (fObject == null)
                {
                    return null;
                }

                // --

                if (!this.containsObject(fObject))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Object", "Modeling File"));
                }

                // --

                fXmlNode = FSecsDriverCommon.getObjectXmlNode(fObject);
                if (fXmlNode.fParentNode == null)
                {
                    return null;
                }

                // -- 

                if (
                    fObject.fObjectType == FObjectType.ObjectNameList ||
                    fObject.fObjectType == FObjectType.FunctionNameList ||
                    fObject.fObjectType == FObjectType.UserTagName ||
                    fObject.fObjectType == FObjectType.DataConversionSetList ||
                    fObject.fObjectType == FObjectType.EquipmentStateSetList ||
                    fObject.fObjectType == FObjectType.RepositoryList ||
                    fObject.fObjectType == FObjectType.EnvironmentList ||
                    fObject.fObjectType == FObjectType.DataSetList ||
                    // --
                    fObject.fObjectType == FObjectType.SecsLibraryGroup ||
                    fObject.fObjectType == FObjectType.SecsDevice ||
                    fObject.fObjectType == FObjectType.HostLibraryGroup ||
                    fObject.fObjectType == FObjectType.HostDevice ||
                    fObject.fObjectType == FObjectType.EquipmentStateSetList ||
                    fObject.fObjectType == FObjectType.Equipment
                    )
                {
                    return this;
                }

                // --

                return FSecsDriverCommon.createObject(this.fScdCore, fXmlNode.fParentNode);                
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

        public FIObject getPreviousSiblingOfObject(
            FIObject fObject
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                if (fObject == null)
                {
                    return null;
                }

                // --

                if (!this.containsObject(fObject))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Object", "Modeling File"));
                }

                // --

                fXmlNode = FSecsDriverCommon.getObjectXmlNode(fObject);
                if (fXmlNode.fPreviousSibling == null)
                {
                    return null;
                }

                // --

                return FSecsDriverCommon.createObject(this.fScdCore, fXmlNode.fPreviousSibling);                
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

        public FIObject getNextSiblingOfObject(
            FIObject fObject
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                if (fObject == null)
                {
                    return null;
                }

                // --

                if (!this.containsObject(fObject))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Object", "Modeling File"));
                }

                // --

                fXmlNode = FSecsDriverCommon.getObjectXmlNode(fObject);
                if (fXmlNode.fNextSibling == null)
                {
                    return null;
                }

                // --

                return FSecsDriverCommon.createObject(this.fScdCore, fXmlNode.fNextSibling);                
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

        public void cutBinaryLogFile(
            )
        {
            try
            {
                this.fScdCore.fLogWriter.cutBinaryLogFile();
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

        public void cutSmlLogFile(
            )
        {
            try
            {
                this.fScdCore.fLogWriter.cutSmlLogFile();
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

        public void cutVfeiLogFile(
            )
        {
            try
            {
                this.fScdCore.fLogWriter.cutVfeiLogFile();
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

        public void cutSecsLogFile(
            )
        {
            try
            {
                this.fScdCore.fLogWriter.cutSecsLogFile();
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

        public void cutAllLogFiles(
            )
        {
            try
            {
                this.fScdCore.fLogWriter.cutBinaryLogFile();
                this.fScdCore.fLogWriter.cutSmlLogFile();
                this.fScdCore.fLogWriter.cutVfeiLogFile();
                this.fScdCore.fLogWriter.cutSecsLogFile();
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

        public void openRepository(
            )
        {
            try
            {
                this.fScdCore.openRepositoryMaterial();
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

        public void saveRepository(
            string rawData
            )
        {
            try
            {
                this.fScdCore.saveRepositoryMaterial(rawData);
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

        public void loadRepository(
            string rawData
            )
        {
            try
            {
                this.fScdCore.loadRepositoryMaterial(rawData);
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

        public string getRepositoryRawData(
            )
        {
            try
            {
                return this.fScdCore.getRepositoryMaterialRawData();
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

        public void removeRepositoryById(
            UInt64 rpmId
            )
        {
            try
            {
                removeRepositoryById(new UInt64[] { rpmId });
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

        public void removeRepositoryById(
            UInt64[] rpmIds
            )
        {
            try
            {
                this.fScdCore.removeRepositoryMaterialById(rpmIds);
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

        private bool confirmlogLevelEnabled(
            FLogLevel fLogLevel
            )
        {
            try
            {
                if (fLogLevel == FLogLevel.Level1)
                {
                    return m_logLevel1;
                }
                else if (fLogLevel == FLogLevel.Level2)
                {
                    return m_logLevel2;
                }
                else if (fLogLevel == FLogLevel.Level3)
                {
                    return m_logLevel3;
                }
                else if (fLogLevel == FLogLevel.Level4)
                {
                    return m_logLevel4;
                }
                else if (fLogLevel == FLogLevel.Level5)
                {
                    return m_logLevel5;
                }
                else if (fLogLevel == FLogLevel.Level6)
                {
                    return m_logLevel6;
                }
                else if (fLogLevel == FLogLevel.Level7)
                {
                    return m_logLevel7;
                }
                else if (fLogLevel == FLogLevel.Level8)
                {
                    return m_logLevel8;
                }
                else if (fLogLevel == FLogLevel.Level9)
                {
                    return m_logLevel9;
                }
                else if (fLogLevel == FLogLevel.Level10)
                {
                    return m_logLevel10;
                }
                return m_logLevel1;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region On SECS Driver Modeling Event

        internal void onModelingFileOpenCompleted(
            FEventArgsBase fArgsBase
            )
        {
            try
            {
                if (ModelingFileOpenCompleted != null)
                {
                    ModelingFileOpenCompleted(this, (FModelingFileOpenCompletedEventArgs)fArgsBase);
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

        internal void onModelingFileReopenPrecompleted(
            FModelingFileReopenPrecompletedEventArgs fArgs
            )
        {
            try
            {
                if (ModelingFileReopenPrecompleted != null)
                {
                    ModelingFileReopenPrecompleted(this, fArgs);
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

        internal void onModelingFileReopenCompleted(
            FEventArgsBase fArgsBase
            )
        {
            try
            {
                if (ModelingFileReopenCompleted != null)
                {
                    ModelingFileReopenCompleted(this, (FModelingFileReopenCompletedEventArgs)fArgsBase);
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

        internal void onModelingFileReopenFailed(
            FEventArgsBase fArgsBase
            )
        {
            try
            {
                if (ModelingFileReopenFailed != null)
                {
                    ModelingFileReopenFailed(this, (FModelingFileReopenFailedEventArgs)fArgsBase);
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

        internal void onModelingFileSaveCompleted(
            FEventArgsBase fArgsBase
            )
        {
            try
            {
                if (ModelingFileSaveCompleted != null)
                {
                    ModelingFileSaveCompleted(this, (FModelingFileSaveCompletedEventArgs)fArgsBase);
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

        internal void onObjectModifyCompleted(
            FEventArgsBase fArgsBase
            )
        {
            try
            {
                if (ObjectModifyCompleted != null)
                {
                    ObjectModifyCompleted(this, (FObjectEventArgs)fArgsBase);
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

        internal void onObjectInsertBeforeCompleted(
            FEventArgsBase fArgsBase
            )
        {
            try
            {
                if (ObjectInsertBeforeCompleted != null)
                {
                    ObjectInsertBeforeCompleted(this, (FObjectEventArgs)fArgsBase);
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

        internal void onObjectInsertAfterCompleted(
            FEventArgsBase fArgsBase
            )
        {
            try
            {
                if (ObjectInsertAfterCompleted != null)
                {
                    ObjectInsertAfterCompleted(this, (FObjectEventArgs)fArgsBase);
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

        internal void onObjectAppendCompleted(
            FEventArgsBase fArgsBase
            )
        {
            try
            {
                if (ObjectAppendCompleted != null)
                {
                    ObjectAppendCompleted(this, (FObjectEventArgs)fArgsBase);
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

        internal void onObjectRemoveCompleted(
            FEventArgsBase fArgsBase
            )
        {
            try
            {
                if (ObjectRemoveCompleted != null)
                {
                    ObjectRemoveCompleted(this, (FObjectEventArgs)fArgsBase);
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

        internal void onObjectMoveUpCompleted(
            FEventArgsBase fArgsBase
            )
        {
            try
            {
                if (ObjectMoveUpCompleted != null)
                {
                    ObjectMoveUpCompleted(this, (FObjectEventArgs)fArgsBase);
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

        internal void onObjectMoveDownCompleted(
            FEventArgsBase fArgsBase
            )
        {
            try
            {
                if (ObjectMoveDownCompleted != null)
                {
                    ObjectMoveDownCompleted(this, (FObjectEventArgs)fArgsBase);
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

        internal void onObjectMoveToCompleted(
            FEventArgsBase fArgsBase
            )
        {
            try
            {
                if (ObjectMoveToCompleted != null)
                {
                    ObjectMoveToCompleted(this, (FObjectMoveToCompletedEventArgs)fArgsBase);
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

        internal void onRepositoryMaterialSaved(
            FEventArgsBase fArgsBase
            )
        {
            try
            {
                // ***
                // 2017.05.31 by spike.lee
                // Repository Material Saved Event Call 추가
                // ***
                if (RepositoryMaterialSaved != null)
                {
                    RepositoryMaterialSaved(this, (FRepositoryMaterialSavedEventArgs)fArgsBase);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region On SECS Driver Communication Event

        internal void onSecsDeviceStateChanged(
            FEventArgsBase fArgsBase
            )
        {
            FSecsDeviceStateChangedEventArgs fArgs = null;

            try
            {
                fArgs = (FSecsDeviceStateChangedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fSecsDeviceStateChangedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // SECS Device State Changed Log Write
                // ***
                fArgs.fSecsDeviceStateChangedLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_Time, FXmlTagSDVL.D_Time, FDataConvert.defaultNowDateTimeToString());                
                // --
                this.fScdCore.fLogWriter.pushSecsLog(fArgs.fSecsDeviceStateChangedLog.fXmlNode);

                // --

                if (SecsDeviceStateChanged != null)
                {
                    SecsDeviceStateChanged(this, fArgs);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onSecsDeviceErrorRaised(
            FEventArgsBase fArgsBase
            )
        {
            FSecsDeviceErrorRaisedEventArgs fArgs = null;

            try
            {
                fArgs = (FSecsDeviceErrorRaisedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fSecsDeviceErrorRaisedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // SECS Device Error Raised Log Write
                // ***
                fArgs.fSecsDeviceErrorRaisedLog.fXmlNode.set_attrVal(FXmlTagSDEL.A_Time, FXmlTagSDEL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fScdCore.fLogWriter.pushSecsLog(fArgs.fSecsDeviceErrorRaisedLog.fXmlNode);

                // --

                if (SecsDeviceErrorRaised != null)
                {
                    SecsDeviceErrorRaised(this, fArgs);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onSecsDeviceTimeoutRaised(
            FEventArgsBase fArgsBase
            )
        {
            FSecsDeviceTimeoutRaisedEventArgs fArgs = null;

            try
            {
                fArgs = (FSecsDeviceTimeoutRaisedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fSecsDeviceTimeoutRaisedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // SECS Device Timeout Raised Log Write
                // ***
                fArgs.fSecsDeviceTimeoutRaisedLog.fXmlNode.set_attrVal(FXmlTagSDTL.A_Time, FXmlTagSDTL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fScdCore.fLogWriter.pushSecsLog(fArgs.fSecsDeviceTimeoutRaisedLog.fXmlNode);

                // --

                if (SecsDeviceTimeoutRaised != null)
                {
                    SecsDeviceTimeoutRaised(this, fArgs);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onSecsDeviceDataReceived(
            FEventArgsBase fArgsBase
            )
        {
            FSecsDeviceDataReceivedEventArgs fArgs = null;

            try
            {
                fArgs = (FSecsDeviceDataReceivedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fSecsDeviceDataReceivedLog.fXmlNode);

                // --
                
                // ***
                // 2012.11.01 by spike.lee
                // SECS Device Data Received Log Write
                // ***                
                fArgs.fSecsDeviceDataReceivedLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_Time, FXmlTagSDVL.D_Time, FDataConvert.defaultNowDateTimeToString());                
                // --
                this.fScdCore.fLogWriter.pushSecsLog(fArgs.fSecsDeviceDataReceivedLog.fXmlNode);
                
                // --
                
                if (SecsDeviceDataReceived != null)
                {
                    SecsDeviceDataReceived(this, fArgs);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onSecsDeviceDataSent(
            FEventArgsBase fArgsBase
            )
        {
            FSecsDeviceDataSentEventArgs fArgs = null;

            try
            {
                fArgs = (FSecsDeviceDataSentEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fSecsDeviceDataSentLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // SECS Device Data Sent Log Write
                // ***
                fArgs.fSecsDeviceDataSentLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_Time, FXmlTagSDVL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fScdCore.fLogWriter.pushSecsLog(fArgs.fSecsDeviceDataSentLog.fXmlNode);

                // --

                if (SecsDeviceDataSent != null)
                {
                    SecsDeviceDataSent(this, fArgs);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }        

        //------------------------------------------------------------------------------------------------------------------------

        internal void onSecsDeviceTelnetPacketReceived(
            FEventArgsBase fArgsBase
            )
        {
            FSecsDeviceTelnetPacketReceivedEventArgs fArgs = null;

            try
            {
                fArgs = (FSecsDeviceTelnetPacketReceivedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fSecsDeviceTelnetPacketReceivedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // SECS Device Telnet Package Received Log Write
                // ***
                fArgs.fSecsDeviceTelnetPacketReceivedLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_Time, FXmlTagSTPL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fScdCore.fLogWriter.pushSecsLog(fArgs.fSecsDeviceTelnetPacketReceivedLog.fXmlNode);

                // --

                if (SecsDeviceTelnetPacketReceived != null)
                {
                    SecsDeviceTelnetPacketReceived(this, fArgs);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onSecsDeviceTelnetPacketSent(
            FEventArgsBase fArgsBase
            )
        {
            FSecsDeviceTelnetPacketSentEventArgs fArgs = null;

            try
            {
                fArgs = (FSecsDeviceTelnetPacketSentEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fSecsDeviceTelnetPacketSentLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // SECS Device Telnet Package Sent Log Write
                // ***
                fArgs.fSecsDeviceTelnetPacketSentLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_Time, FXmlTagSTPL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fScdCore.fLogWriter.pushSecsLog(fArgs.fSecsDeviceTelnetPacketSentLog.fXmlNode);

                // --

                if (SecsDeviceTelnetPacketSent != null)
                {
                    SecsDeviceTelnetPacketSent(this, fArgs);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onSecsDeviceTelnetStateChanged(
            FEventArgsBase fArgsBase
            )
        {
            FSecsDeviceTelnetStateChangedEventArgs fArgs = null;

            try
            {
                fArgs = (FSecsDeviceTelnetStateChangedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fSecsDeviceTelnetStateChangedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // SECS Device Telnet State Changed Log Write
                // ***
                fArgs.fSecsDeviceTelnetStateChangedLog.fXmlNode.set_attrVal(FXmlTagSTSL.A_Time, FXmlTagSTSL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fScdCore.fLogWriter.pushSecsLog(fArgs.fSecsDeviceTelnetStateChangedLog.fXmlNode);

                // --

                if (SecsDeviceTelnetStateChanged != null)
                {
                    SecsDeviceTelnetStateChanged(this, fArgs);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onSecsDeviceHandshakeReceived(
            FEventArgsBase fArgsBase
            )
        {
            FSecsDeviceHandshakeReceivedEventArgs fArgs = null;

            try
            {
                fArgs = (FSecsDeviceHandshakeReceivedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fSecsDeviceHandshakeReceivedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // SECS Device Handshake Received Log Write
                // ***
                fArgs.fSecsDeviceHandshakeReceivedLog.fXmlNode.set_attrVal(FXmlTagSDHL.A_Time, FXmlTagSDHL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fScdCore.fLogWriter.pushSecsLog(fArgs.fSecsDeviceHandshakeReceivedLog.fXmlNode);

                // --

                if (SecsDeviceHandshakeReceived != null)
                {
                    SecsDeviceHandshakeReceived(this, fArgs);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onSecsDeviceHandshakeSent(
            FEventArgsBase fArgsBase
            )
        {
            FSecsDeviceHandshakeSentEventArgs fArgs = null;

            try
            {
                fArgs = (FSecsDeviceHandshakeSentEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fSecsDeviceHandshakeSentLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // SECS Device Handshake Sent Log Write
                // ***
                fArgs.fSecsDeviceHandshakeSentLog.fXmlNode.set_attrVal(FXmlTagSDHL.A_Time, FXmlTagSDHL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fScdCore.fLogWriter.pushSecsLog(fArgs.fSecsDeviceHandshakeSentLog.fXmlNode);

                // --

                if (SecsDeviceHandshakeSent != null)
                {
                    SecsDeviceHandshakeSent(this, fArgs);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onSecsDeviceControlMessageReceived(
            FEventArgsBase fArgsBase
            )
        {
            FSecsDeviceControlMessageReceivedEventArgs fArgs = null;

            try
            {
                fArgs = (FSecsDeviceControlMessageReceivedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fSecsDeviceControlMessageReceivedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // SECS Device Control Message Received Log Write
                // ***
                fArgs.fSecsDeviceControlMessageReceivedLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_Time, FXmlTagCMGL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fScdCore.fLogWriter.pushSecsLog(fArgs.fSecsDeviceControlMessageReceivedLog.fXmlNode);

                // --

                if (SecsDeviceControlMessageReceived != null)
                {
                    SecsDeviceControlMessageReceived(this, fArgs);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onSecsDeviceControlMessageSent(
            FEventArgsBase fArgsBase
            )
        {
            FSecsDeviceControlMessageSentEventArgs fArgs = null;

            try
            {
                fArgs = (FSecsDeviceControlMessageSentEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fSecsDeviceControlMessageSentLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // SECS Device Control Message Sent Log Write
                // ***
                fArgs.fSecsDeviceControlMessageSentLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_Time, FXmlTagCMGL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fScdCore.fLogWriter.pushSecsLog(fArgs.fSecsDeviceControlMessageSentLog.fXmlNode);

                // --

                if (SecsDeviceControlMessageSent != null)
                {
                    SecsDeviceControlMessageSent(this, fArgs);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onSecsDeviceBlockReceived(
            FEventArgsBase fArgsBase
            )
        {
            FSecsDeviceBlockReceivedEventArgs fArgs = null;

            try
            {
                fArgs = (FSecsDeviceBlockReceivedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fSecsDeviceBlockReceivedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // SECS Device Block Received Log Write
                // ***
                fArgs.fSecsDeviceBlockReceivedLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_Time, FXmlTagSDBL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fScdCore.fLogWriter.pushSecsLog(fArgs.fSecsDeviceBlockReceivedLog.fXmlNode);

                // --

                if (SecsDeviceBlockReceived != null)
                {
                    SecsDeviceBlockReceived(this, fArgs);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onSecsDeviceBlockSent(
            FEventArgsBase fArgsBase
            )
        {
            FSecsDeviceBlockSentEventArgs fArgs = null;

            try
            {
                fArgs = (FSecsDeviceBlockSentEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fSecsDeviceBlockSentLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // SECS Device Block Sent Log Write
                // ***
                fArgs.fSecsDeviceBlockSentLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_Time, FXmlTagSDBL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fScdCore.fLogWriter.pushSecsLog(fArgs.fSecsDeviceBlockSentLog.fXmlNode);

                // --

                if (SecsDeviceBlockSent != null)
                {
                    SecsDeviceBlockSent(this, (FSecsDeviceBlockSentEventArgs)fArgsBase);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onSecsDeviceSmlReceived(
            FEventArgsBase fArgsBase
            )
        {
            FSecsDeviceSmlReceivedEventArgs fArgs = null;

            try
            {
                fArgs = (FSecsDeviceSmlReceivedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fSecsDeviceSmlReceivedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // SECS Device SML Received Log Write
                // ***
                fArgs.fSecsDeviceSmlReceivedLog.fXmlNode.set_attrVal(FXmlTagSMLL.A_Time, FXmlTagSMLL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fScdCore.fLogWriter.pushSecsLog(fArgs.fSecsDeviceSmlReceivedLog.fXmlNode);

                // --

                if (SecsDeviceSmlReceived != null)
                {
                    SecsDeviceSmlReceived(this, fArgs);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onSecsDeviceSmlSent(
            FEventArgsBase fArgsBase
            )
        {
            FSecsDeviceSmlSentEventArgs fArgs = null;

            try
            {
                fArgs = (FSecsDeviceSmlSentEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fSecsDeviceSmlSentLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // SECS Device SML Sent Log Write
                // ***
                fArgs.fSecsDeviceSmlSentLog.fXmlNode.set_attrVal(FXmlTagSMLL.A_Time, FXmlTagSMLL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fScdCore.fLogWriter.pushSecsLog(fArgs.fSecsDeviceSmlSentLog.fXmlNode);

                // --

                if (SecsDeviceSmlSent != null)
                {
                    SecsDeviceSmlSent(this, fArgs);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onSecsDeviceDataMessageReceived(
            FEventArgsBase fArgsBase
            )
        {
            FSecsDeviceDataMessageReceivedEventArgs fArgs = null;

            try
            {
                fArgs = (FSecsDeviceDataMessageReceivedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fSecsDeviceDataMessageReceivedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // SECS Device Data Message Received Log Write
                // ***
                fArgs.fSecsDeviceDataMessageReceivedLog.fXmlNode.set_attrVal(FXmlTagSMGL.A_Time, FXmlTagSMGL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fSecsDeviceDataMessageReceivedLog.logEnabled && confirmlogLevelEnabled(fArgs.fSecsDeviceDataMessageReceivedLog.logLevel))
                {                    
                    this.fScdCore.fLogWriter.pushSecsLog(fArgs.fSecsDeviceDataMessageReceivedLog.fXmlNode);
                }                

                // --

                if (SecsDeviceDataMessageReceived != null)
                {
                    SecsDeviceDataMessageReceived(this, fArgs);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onSecsDeviceDataMessageSent(
            FEventArgsBase fArgsBase
            )
        {
            FSecsDeviceDataMessageSentEventArgs fArgs = null;

            try
            {
                fArgs = (FSecsDeviceDataMessageSentEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fSecsDeviceDataMessageSentLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // SECS Device Data Message Sent Log Write
                // ***
                fArgs.fSecsDeviceDataMessageSentLog.fXmlNode.set_attrVal(FXmlTagSMGL.A_Time, FXmlTagSMGL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fSecsDeviceDataMessageSentLog.logEnabled && confirmlogLevelEnabled(fArgs.fSecsDeviceDataMessageSentLog.logLevel))
                {
                    // --
                    this.fScdCore.fLogWriter.pushSecsLog(fArgs.fSecsDeviceDataMessageSentLog.fXmlNode);
                }

                // --

                if (SecsDeviceDataMessageSent != null)
                {
                    SecsDeviceDataMessageSent(this, fArgs);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }        

        //------------------------------------------------------------------------------------------------------------------------

        internal void onHostDeviceStateChanged(
            FEventArgsBase fArgsBase
            )
        {
            FHostDeviceStateChangedEventArgs fArgs = null;

            try
            {
                fArgs = (FHostDeviceStateChangedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fHostDeviceStateChangedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Host Device State Changed Log Write
                // ***
                fArgs.fHostDeviceStateChangedLog.fXmlNode.set_attrVal(FXmlTagHDVL.A_Time, FXmlTagHDVL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fScdCore.fLogWriter.pushSecsLog(fArgs.fHostDeviceStateChangedLog.fXmlNode);

                // --

                if (HostDeviceStateChanged != null)
                {
                    HostDeviceStateChanged(this, fArgs);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onHostDeviceErrorRaised(
            FEventArgsBase fArgsBase
            )
        {
            FHostDeviceErrorRaisedEventArgs fArgs = null;

            try
            {
                fArgs = (FHostDeviceErrorRaisedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fHostDeviceErrorRaisedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Host Device Error Raised Log Write
                // ***
                fArgs.fHostDeviceErrorRaisedLog.fXmlNode.set_attrVal(FXmlTagHDEL.A_Time, FXmlTagHDEL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fScdCore.fLogWriter.pushSecsLog(fArgs.fHostDeviceErrorRaisedLog.fXmlNode);

                // --

                if (HostDeviceErrorRaised != null)
                {
                    HostDeviceErrorRaised(this, fArgs);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onHostDeviceVfeiReceived(
            FEventArgsBase fArgsBase
            )
        {
            FHostDeviceVfeiReceivedEventArgs fArgs = null;

            try
            {
                fArgs = (FHostDeviceVfeiReceivedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fHostDeviceVfeiReceivedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Host Device VFEI Received Log Write
                // ***
                fArgs.fHostDeviceVfeiReceivedLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_Time, FXmlTagVFEL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fScdCore.fLogWriter.pushSecsLog(fArgs.fHostDeviceVfeiReceivedLog.fXmlNode);

                // --

                if (HostDeviceVfeiReceived != null)
                {
                    HostDeviceVfeiReceived(this, fArgs);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onHostDeviceVfeiSent(
            FEventArgsBase fArgsBase
            )
        {
            FHostDeviceVfeiSentEventArgs fArgs = null;

            try
            {
                fArgs = (FHostDeviceVfeiSentEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fHostDeviceVfeiSentLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Host Device VFEI Sent Log Write
                // ***
                fArgs.fHostDeviceVfeiSentLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_Time, FXmlTagVFEL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fScdCore.fLogWriter.pushSecsLog(fArgs.fHostDeviceVfeiSentLog.fXmlNode);

                // --

                if (HostDeviceVfeiSent != null)
                {
                    HostDeviceVfeiSent(this, fArgs);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onHostDeviceDataMessageReceived(
            FEventArgsBase fArgsBase
            )
        {
            FHostDeviceDataMessageReceivedEventArgs fArgs = null;

            try
            {
                fArgs = (FHostDeviceDataMessageReceivedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fHostDeviceDataMessageReceivedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Host Device Data Message Received Log Write
                // ***
                fArgs.fHostDeviceDataMessageReceivedLog.fXmlNode.set_attrVal(FXmlTagHMGL.A_Time, FXmlTagHMGL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fHostDeviceDataMessageReceivedLog.logEnabled && confirmlogLevelEnabled(fArgs.fHostDeviceDataMessageReceivedLog.logLevel))
                {   
                    this.fScdCore.fLogWriter.pushSecsLog(fArgs.fHostDeviceDataMessageReceivedLog.fXmlNode);
                }

                // --

                if (HostDeviceDataMessageReceived != null)
                {
                    HostDeviceDataMessageReceived(this, fArgs);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onHostDeviceDataMessageSent(
            FEventArgsBase fArgsBase
            )
        {
            FHostDeviceDataMessageSentEventArgs fArgs = null;

            try
            {
                fArgs = (FHostDeviceDataMessageSentEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fHostDeviceDataMessageSentLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Host Device Data Message Sent Log Write
                // ***
                fArgs.fHostDeviceDataMessageSentLog.fXmlNode.set_attrVal(FXmlTagHMGL.A_Time, FXmlTagHMGL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fHostDeviceDataMessageSentLog.logEnabled && confirmlogLevelEnabled(fArgs.fHostDeviceDataMessageSentLog.logLevel))
                {                    
                    this.fScdCore.fLogWriter.pushSecsLog(fArgs.fHostDeviceDataMessageSentLog.fXmlNode);
                }

                // --

                if (HostDeviceDataMessageSent != null)
                {
                    HostDeviceDataMessageSent(this, fArgs);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onSecsTriggerRaised(
            FEventArgsBase fArgsBase
            )
        {
            FSecsTriggerRaisedEventArgs fArgs = null;

            try
            {
                fArgs = (FSecsTriggerRaisedEventArgs)fArgsBase;                

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fSecsTriggerRaisedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // SECS Trigger Raised Log Write
                // ***
                fArgs.fSecsTriggerRaisedLog.fXmlNode.set_attrVal(FXmlTagSTRL.A_Time, FXmlTagSTRL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {   
                    this.fScdCore.fLogWriter.pushSecsLog(fArgs.fSecsTriggerRaisedLog.fXmlNode);
                }

                // --

                if (SecsTriggerRaised != null)
                {
                    SecsTriggerRaised(this, fArgs);
                }

                // --

                // ***
                // Scenario Control
                // ***
                FScenarioController.controlScenario(fArgs);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onSecsTransmitterRaised(
            FEventArgsBase fArgsBase
            )
        {
            FSecsTransmitterRaisedEventArgs fArgs = null;

            try
            {
                fArgs = (FSecsTransmitterRaisedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fSecsTransmitterRaisedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // SECS Transmitter Raised Log Write
                // ***
                fArgs.fSecsTransmitterRaisedLog.fXmlNode.set_attrVal(FXmlTagSTNL.A_Time, FXmlTagSTNL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {   
                    this.fScdCore.fLogWriter.pushSecsLog(fArgs.fSecsTransmitterRaisedLog.fXmlNode);
                }

                // --

                if (SecsTransmitterRaised != null)
                {
                    SecsTransmitterRaised(this, fArgs);
                }

                // --

                FScenarioController.controlScenario(fArgs);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onHostTriggerRaised(
            FEventArgsBase fArgsBase
            )
        {
            FHostTriggerRaisedEventArgs fArgs = null;

            try
            {
                fArgs = (FHostTriggerRaisedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fHostTriggerRaisedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Host Trigger Raised Log Write
                // ***
                fArgs.fHostTriggerRaisedLog.fXmlNode.set_attrVal(FXmlTagHTRL.A_Time, FXmlTagHTRL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    this.fScdCore.fLogWriter.pushSecsLog(fArgs.fHostTriggerRaisedLog.fXmlNode);
                }

                // --

                if (SecsTriggerRaised != null)
                {
                    HostTriggerRaised(this, fArgs);
                }

                // --

                FScenarioController.controlScenario(fArgs);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onHostTransmitterRaised(
            FEventArgsBase fArgsBase
            )
        {
            FHostTransmitterRaisedEventArgs fArgs = null;

            try
            {
                fArgs = (FHostTransmitterRaisedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fHostTransmitterRaisedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Host Transmitter Raised Log Write
                // ***
                fArgs.fHostTransmitterRaisedLog.fXmlNode.set_attrVal(FXmlTagHTNL.A_Time, FXmlTagHTNL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {   
                    this.fScdCore.fLogWriter.pushSecsLog(fArgs.fHostTransmitterRaisedLog.fXmlNode);
                }

                // --

                if (HostTransmitterRaised != null)
                {
                    HostTransmitterRaised(this, fArgs);
                }

                // --

                FScenarioController.controlScenario(fArgs);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onJudgementPerformed(
            FEventArgsBase fArgsBase
            )
        {
            FJudgementPerformedEventArgs fArgs = null;

            try
            {
                fArgs = (FJudgementPerformedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fJudgementPerformedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Judgement Performed Log Write
                // ***
                fArgs.fJudgementPerformedLog.fXmlNode.set_attrVal(FXmlTagJDML.A_Time, FXmlTagJDML.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    this.fScdCore.fLogWriter.pushSecsLog(fArgs.fJudgementPerformedLog.fXmlNode);
                }

                // --

                if (JudgementPerformed != null)
                {
                    JudgementPerformed(this, fArgs);
                }

                // --

                FScenarioController.controlScenario(fArgs);
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

        internal void onMapperPerformed(
            FEventArgsBase fArgsBase
            )
        {
            FMapperPerformedEventArgs fArgs = null;

            try
            {
                fArgs = (FMapperPerformedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fMapperPerformedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Mapper Performed Log Write
                // ***
                fArgs.fMapperPerformedLog.fXmlNode.set_attrVal(FXmlTagMAPL.A_Time, FXmlTagMAPL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    this.fScdCore.fLogWriter.pushSecsLog(fArgs.fMapperPerformedLog.fXmlNode);
                }

                // --

                if (MapperPerformed != null)
                {
                    MapperPerformed(this, fArgs);
                }

                // --

                FScenarioController.controlScenario(fArgs);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onEquipmentStateSetAltererPerformed(
            FEventArgsBase fArgsBase
            )
        {
            FEquipmentStateSetAltererPerformedEventArgs fArgs = null;

            try
            {
                fArgs = (FEquipmentStateSetAltererPerformedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fEquipmentStateSetAltererPerformedLog.fXmlNode);

                // --

                // ***
                // 2013.06.21 by jeff.kim
                // Equipment State Set Alterer Performed Log Write
                // ***
                fArgs.fEquipmentStateSetAltererPerformedLog.fXmlNode.set_attrVal(FXmlTagESAL.A_Time, FXmlTagESAL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    this.fScdCore.fLogWriter.pushSecsLog(fArgs.fEquipmentStateSetAltererPerformedLog.fXmlNode);
                }

                // --

                if (EquipmentStateSetAltererPerformed != null)
                {
                    EquipmentStateSetAltererPerformed(this, fArgs);
                }

                // --

                FScenarioController.controlScenario(fArgs);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onStoragePerformed(
            FEventArgsBase fArgsBase
            )
        {
            FStoragePerformedEventArgs fArgs = null;

            try
            {
                fArgs = (FStoragePerformedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fStoragePerformedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Storage Performed Log Write
                // ***
                fArgs.fStoragePerformedLog.fXmlNode.set_attrVal(FXmlTagSTGL.A_Time, FXmlTagSTGL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    this.fScdCore.fLogWriter.pushSecsLog(fArgs.fStoragePerformedLog.fXmlNode);
                }

                // --

                if (StoragePerformed != null)
                {
                    StoragePerformed(this, fArgs);
                }

                // --

                FScenarioController.controlScenario(fArgs);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onCallbackRaised(
            FEventArgsBase fArgsBase
            )
        {
            FCallbackRaisedEventArgs fArgs = null;

            try
            {
                fArgs = (FCallbackRaisedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fCallbackRaisedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Callback Raised Log Write
                // ***
                fArgs.fCallbackRaisedLog.fXmlNode.set_attrVal(FXmlTagCBKL.A_Time, FXmlTagCBKL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    this.fScdCore.fLogWriter.pushSecsLog(fArgs.fCallbackRaisedLog.fXmlNode);
                }

                // --

                if (CallbackRaised != null)
                {
                    CallbackRaised(this, fArgs);
                }

                // --

                FScenarioController.controlScenario(fArgs);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onFunctionCalled(
            FEventArgsBase fArgsBase
            )
        {
            FFunctionCalledEventArgs fArgs = null;

            try
            {
                fArgs = (FFunctionCalledEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fFunctionCalledLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Function Called Log Write
                // ***
                fArgs.fFunctionCalledLog.fXmlNode.set_attrVal(FXmlTagFUNL.A_Time, FXmlTagFUNL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    this.fScdCore.fLogWriter.pushSecsLog(fArgs.fFunctionCalledLog.fXmlNode);
                }

                // --

                if (FunctionCalled != null)
                {
                    FunctionCalled(this, fArgs);
                }

                // --

                FScenarioController.controlScenario(fArgs);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onBranchRaised(
            FEventArgsBase fArgsBase
            )
        {
            FBranchRaisedEventArgs fArgs = null;

            try
            {
                fArgs = (FBranchRaisedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fBranchRaisedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Bransh Raised Log Write
                // ***
                fArgs.fBranchRaisedLog.fXmlNode.set_attrVal(FXmlTagBRNL.A_Time, FXmlTagBRNL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    this.fScdCore.fLogWriter.pushSecsLog(fArgs.fBranchRaisedLog.fXmlNode);
                }

                // --

                if (BranchRaised != null)
                {
                    BranchRaised(this, fArgs);
                }

                // --

                FScenarioController.controlScenario(fArgs);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onCommentWritten(
            FEventArgsBase fArgsBase
            )
        {
            FCommentWrittenEventArgs fArgs = null;

            try
            {
                fArgs = (FCommentWrittenEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fCommentWrittenLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Comment Written Log Write
                // ***
                fArgs.fCommentWrittenLog.fXmlNode.set_attrVal(FXmlTagCMTL.A_Time, FXmlTagCMTL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    this.fScdCore.fLogWriter.pushSecsLog(fArgs.fCommentWrittenLog.fXmlNode);
                }

                // --

                if (CommentWritten != null)
                {
                    CommentWritten(this, fArgs);
                }

                // --

                FScenarioController.controlScenario(fArgs);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onPauserRaised(
            FEventArgsBase fArgsBase
            )
        {
            FPauserRaisedEventArgs fArgs = null;

            try
            {
                fArgs = (FPauserRaisedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fPauserRaisedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Comment Written Log Write
                // ***
                fArgs.fPauserRaisedLog.fXmlNode.set_attrVal(FXmlTagPAUL.A_Time, FXmlTagPAUL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {  
                    this.fScdCore.fLogWriter.pushSecsLog(fArgs.fPauserRaisedLog.fXmlNode);
                }

                // --

                if (PauserRaised != null)
                {
                    PauserRaised(this, fArgs);
                }

                // --

                FScenarioController.controlScenario(fArgs);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onEntryPointCalled(
            FEventArgsBase fArgsBase
            )
        {
            FEntryPointCalledEventArgs fArgs = null;

            try
            {
                fArgs = (FEntryPointCalledEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fEntryPointCalledLog.fXmlNode);

                // --

                fArgs.fEntryPointCalledLog.fXmlNode.set_attrVal(FXmlTagETPL.A_Time, FXmlTagETPL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {   
                    this.fScdCore.fLogWriter.pushSecsLog(fArgs.fEntryPointCalledLog.fXmlNode);
                }

                // --

                if (EntryPointCalled != null)
                {
                    EntryPointCalled(this, fArgs);
                }

                // --

                FScenarioController.controlScenario(fArgs);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onApplicationWritten(
            FEventArgsBase fArgsBase
            )
        {
            FApplicationWrittenEventArgs fArgs = null;

            try
            {
                fArgs = (FApplicationWrittenEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fArgs.fApplicationWrittenLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Application Written Log Write
                // ***
                fArgs.fApplicationWrittenLog.fXmlNode.set_attrVal(FXmlTagCMTL.A_Time, FXmlTagCMTL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fScdCore.fLogWriter.pushSecsLog(fArgs.fApplicationWrittenLog.fXmlNode);

                // --

                if (ApplicationWritten != null)
                {
                    ApplicationWritten(this, fArgs);
                }                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 외부 Applicaiton Log Write 처리
        // ***
        public void onApplicationWritten(
            FApplicationWrittenLog fApplicationWrittenLog
            )
        {
            try
            {
                if (!this.fScdCore.fConfig.enabledEventsOfApplication)
                {
                    return;
                }

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FSecsDriverCommon.resetLocked(fApplicationWrittenLog.fXmlNode);

                // --
                
                this.fScdCore.fEventPusher.pushApplicationWrittenEvent(fApplicationWrittenLog.fXmlNode);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
