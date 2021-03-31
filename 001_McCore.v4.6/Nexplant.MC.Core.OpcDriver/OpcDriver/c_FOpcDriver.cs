/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FOpcDriver.cs
--  Creator         : spike.lee
--  Create Date     : 2013.07.10
--  Description     : FAMate Core FaOpcDriver OPC Driver Main Class 
--  History         : Created by spike.lee at 2013.07.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    public class FOpcDriver : FBaseObject<FOpcDriver>, FIObject
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
        public event FOpcDeviceStateChangedEventHandler OpcDeviceStateChanged = null;
        public event FOpcDeviceErrorRaisedEventHandler OpcDeviceErrorRaised = null;
        public event FOpcDeviceTimeoutRaisedEventHandler OpcDeviceTimeoutRaised = null;
        public event FOpcDeviceDataMessageReadEventHandler OpcDeviceDataMessageRead = null;
        public event FOpcDeviceDataMessageWrittenEventHandler OpcDeviceDataMessageWritten = null;
        // --
        public event FOpcSessionItemNameRefreshedEventHandler OpcSessionItemNameRefreshed = null;
        // --
        public event FHostDeviceStateChangedEventHandler HostDeviceStateChanged = null;
        public event FHostDeviceErrorRaisedEventHandler HostDeviceErrorRaised = null;
        public event FHostDeviceVfeiReceivedEventHandler HostDeviceVfeiReceived = null;
        public event FHostDeviceVfeiSentEventHandler HostDeviceVfeiSent = null;
        public event FHostDeviceDataMessageReceivedEventHandler HostDeviceDataMessageReceived = null;
        public event FHostDeviceDataMessageSentEventHandler HostDeviceDataMessageSent = null;
        // --
        public event FOpcTriggerRaisedEventHandler OpcTriggerRaised = null;
        public event FOpcTransmitterRaisedEventHandler OpcTransmitterRaised = null;
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

        // --

        private FOpcRunMode m_fOpecRunMode = FOpcRunMode.WorkspaceManager;
        
        // --

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
        // OPC Driver 생성에 사용
        // ***
        public FOpcDriver(
            string licFileName,
            FOpcRunMode fOpcRunMode
            )
            : base(licFileName)
        {
            this.fOpcDriver = this;
            this.m_fOpecRunMode = fOpcRunMode;
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2014.02.03 by spike.lee
        // OPC Driver reopenModelingFile 메소드에 사용
        // ***
        internal FOpcDriver(            
            ) 
            : base()
        {
            this.fOpcDriver = this;
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2014.02.03 by spike.lee
        // OPC Driver Clone에 사용
        // ***
        internal FOpcDriver(
            FXmlDocument fXmlDoc
            )
            : base(fXmlDoc)
        {   
            this.fOpcDriver = this;
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2014.02.03 by spike.lee
        // OPC Driver Instance 복사에 사용
        // ***
        internal FOpcDriver(            
            FOcdCore fOcdCore,
            FXmlNode fXmlNode
            ) 
            : base(fOcdCore, fXmlNode)
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FOpcDriver(
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
                    return FObjectType.OpcDriver;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.OpcDriver;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOpcRunMode fOpcRunMode
        {
            get
            {
                try
                {
                    return m_fOpecRunMode;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FOpcRunMode.WorkspaceManager;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOCD.A_UniqueId, FXmlTagOCD.D_UniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOCD.A_Name, FXmlTagOCD.D_Name);
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
                    FOpcDriverCommon.validateName(value, true);

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagOCD.A_Name, FXmlTagOCD.D_Name, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOCD.A_Description, FXmlTagOCD.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagOCD.A_Description, FXmlTagOCD.D_Description, value, true);
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

                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagOCD.A_FontColor, FXmlTagOCD.D_FontColor));
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
                    this.fXmlNode.set_attrVal(FXmlTagOCD.A_FontColor, FXmlTagOCD.D_FontColor, value.Name, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagOCD.A_FontBold, FXmlTagOCD.D_FontBold));
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
                    this.fXmlNode.set_attrVal(FXmlTagOCD.A_FontBold, FXmlTagOCD.D_FontBold, FBoolean.fromBool(value), true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOCD.A_EapName, FXmlTagOCD.D_EapName);
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
                    FOpcDriverCommon.validateName(value, true);

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagOCD.A_EapName, FXmlTagOCD.D_EapName, value, true);

                    // -- 

                    this.fOcdCore.fConfig.eapName = value;
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
                    return this.fXmlNode.get_attrVal(FXmlTagOCD.A_UserTag1, FXmlTagOCD.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagOCD.A_UserTag1, FXmlTagOCD.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOCD.A_UserTag2, FXmlTagOCD.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagOCD.A_UserTag2, FXmlTagOCD.D_UserTag2, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOCD.A_UserTag3, FXmlTagOCD.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagOCD.A_UserTag3, FXmlTagOCD.D_UserTag3, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOCD.A_UserTag4, FXmlTagOCD.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagOCD.A_UserTag4, FXmlTagOCD.D_UserTag4, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOCD.A_UserTag5, FXmlTagOCD.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagOCD.A_UserTag5, FXmlTagOCD.D_UserTag5, value, true);
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
                    return new FObjectNameListCollection(this.fOcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return new FFunctionNameListCollection(this.fOcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return new FUserTagNameCollection(this.fOcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return new FDataConversionSetListCollection(this.fOcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return new FEquipmentStateSetListCollection(this.fOcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return new FRepositoryListCollection(this.fOcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return new FDataSetListCollection(this.fOcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return new FEnvironmentListCollection(this.fOcdCore, this.fXmlNode.selectNodes(xpath));
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

        public FOpcLibraryGroupCollection fChildOpcLibraryGroupCollection
        {
            get
            {
                const string xpath = FXmlTagOLM.E_OpcLibraryModeling + "/" + FXmlTagOLG.E_OpcLibraryGroup;

                try
                {
                    return new FOpcLibraryGroupCollection(this.fOcdCore, this.fXmlNode.selectNodes(xpath));
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

        public FOpcDeviceCollection fChildOpcDeviceCollection
        {
            get
            {
                const string xpath = FXmlTagODM.E_OpcDeviceModeling + "/" + FXmlTagODV.E_OpcDevice;

                try
                {
                    return new FOpcDeviceCollection(this.fOcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return new FHostLibraryGroupCollection(this.fOcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return new FHostDeviceCollection(this.fOcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return new FEquipmentCollection(this.fOcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return this.fOcdCore.fEventPusher.eventCount;
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
                    return this.fOcdCore.fEventPusher.isCompletedEventHandling;
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
                        FXmlTagOLM.E_OpcLibraryModeling + "/" + FXmlTagOLG.E_OpcLibraryGroup + " | " +
                        FXmlTagODM.E_OpcDeviceModeling + "/" + FXmlTagODV.E_OpcDevice + " | " +
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

        public bool canAppendChildOpcDevice
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

        public bool canAppendChildOpcLibraryGroup
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

        public bool canPasteChildOpcDevice
        {
            get
            {
                try
                {
                    if (!FClipboard.containsData(FCbObjectFormat.OpcDevice))
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

        public bool canPasteChildOpcLibraryGroup
        {
            get
            {
                try
                {
                    if (!FClipboard.containsData(FCbObjectFormat.OpcLibraryGroup))
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
                    return new FObjectCollection(this.fOcdCore, this.fXmlNode.selectNodes("NULL"));
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
                    return new FObjectCollection(this.fOcdCore, this.fXmlNode.selectNodes("NULL"));
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

        public FRepositoryMaterialStorage fRepositoryMaterialStorage
        {
            get
            {
                try
                {
                    return this.fOcdCore.fRepositoryMaterialStorage;
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
                    return this.fOcdCore.fEquipmentStateMaterialStorage;
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

        #region OPC Driver Config

        public string hostDriverDirectory
        {
            get
            {
                try
                {
                    return this.fOcdCore.fConfig.hostDriverDirectory;
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
                    this.fOcdCore.fConfig.hostDriverDirectory = value;
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
                    return this.fOcdCore.fConfig.logDirectory;
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
                    this.fOcdCore.fConfig.logDirectory = value;
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

        public bool enabledEventsOfOpcDeviceState
        {
            get
            {
                try
                {
                    return this.fOcdCore.fConfig.enabledEventsOfOpcDeviceState;
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
                    this.fOcdCore.fConfig.enabledEventsOfOpcDeviceState = value;
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

        public bool enabledEventsOfOpcDeviceError
        {
            get
            {
                try
                {
                    return this.fOcdCore.fConfig.enabledEventsOfOpcDeviceError;
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
                    this.fOcdCore.fConfig.enabledEventsOfOpcDeviceError = value;
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

        public bool enabledEventsOfOpcDeviceTimeout
        {
            get
            {
                try
                {
                    return this.fOcdCore.fConfig.enabledEventsOfOpcDeviceTimeout;
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
                    this.fOcdCore.fConfig.enabledEventsOfOpcDeviceTimeout = value;
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

        public bool enabledEventsOfOpcDeviceDataMessage
        {
            get
            {
                try
                {
                    return this.fOcdCore.fConfig.enabledEventsOfOpcDeviceDataMessage;
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
                    this.fOcdCore.fConfig.enabledEventsOfOpcDeviceDataMessage = value;
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
                    return this.fOcdCore.fConfig.enabledEventsOfHostDeviceState;
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
                    this.fOcdCore.fConfig.enabledEventsOfHostDeviceState = value;
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
                    return this.fOcdCore.fConfig.enabledEventsOfHostDeviceError;
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
                    this.fOcdCore.fConfig.enabledEventsOfHostDeviceError = value;
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
                    return this.fOcdCore.fConfig.enabledEventsOfHostDeviceVfei;
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
                    this.fOcdCore.fConfig.enabledEventsOfHostDeviceVfei = value;
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
                    return this.fOcdCore.fConfig.enabledEventsOfHostDeviceDataMessage;
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
                    this.fOcdCore.fConfig.enabledEventsOfHostDeviceDataMessage = value;
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
                    return this.fOcdCore.fConfig.enabledEventsOfScenario;
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
                    this.fOcdCore.fConfig.enabledEventsOfScenario = value;
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
                    return this.fOcdCore.fConfig.enabledEventsOfApplication;
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
                    this.fOcdCore.fConfig.enabledEventsOfApplication = value;
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
                    return this.fOcdCore.fConfig.enabledLogOfVfei;
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
                    this.fOcdCore.fConfig.enabledLogOfVfei = value;
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

        public bool enabledLogOfOpc
        {
            get
            {
                try
                {
                    return this.fOcdCore.fConfig.enabledLogOfOpc;
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
                    this.fOcdCore.fConfig.enabledLogOfOpc = value;
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
                    return this.fOcdCore.fConfig.maxLogFileSizeOfVfei;
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

                    this.fOcdCore.fConfig.maxLogFileSizeOfVfei = value;
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

        public long maxLogFileSizeOfOpc
        {
            get
            {
                try
                {
                    return this.fOcdCore.fConfig.maxLogFileSizeOfOpc;
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
                    this.fOcdCore.fConfig.maxLogFileSizeOfOpc = value;
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
                    return this.fOcdCore.fConfig.maxLogCountOfVfei;
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
                    this.fOcdCore.fConfig.maxLogCountOfVfei = value;
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

        public long maxLogCountOfOpc
        {
            get
            {
                try
                {
                    return this.fOcdCore.fConfig.maxLogCountOfOpc;
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
                    this.fOcdCore.fConfig.maxLogCountOfOpc = value;
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
                    return this.fOcdCore.fConfig.repositorySaveDirectory;
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
                    this.fOcdCore.fConfig.repositorySaveDirectory = value;
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
                    return this.fOcdCore.fConfig.enabledRepositorySave;
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
                    this.fOcdCore.fConfig.enabledRepositorySave = value;
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
                    return this.fOcdCore.fConfig.enabledRepositoryAutoRemove;
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
                    this.fOcdCore.fConfig.enabledRepositoryAutoRemove = value;
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
                    return this.fOcdCore.fConfig.repositoryKeepingPeriod;
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

                    this.fOcdCore.fConfig.repositoryKeepingPeriod = value;
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

        public FHostLibraryGroup pasteChildHostLibraryGroup(
            )
        {
            FHostLibraryGroup fHostLibraryGroup = null;

            try
            {
                FOpcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.HostLibraryGroup);

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
                FOpcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.HostDevice);

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
                FOpcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.Equipment);

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
                // 새로운 File Open할 경우 모든 OPc Device와 Host Device를 Close 한다.
                // ***
                closeAllDevice();
                this.waitEventHandlingCompleted();

                // --

                this.fOcdCore.openModelingFile(fileName);
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
                this.fOcdCore.reopenModelingFile(fileName);
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
                this.fOcdCore.saveModelingFile(fileName);
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
                this.fOcdCore.fEventPusher.waitEventHandlingCompleted();
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
                openAllOpcDevice();
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

        public void openAllOpcDevice(
            )
        {
            try
            {
                foreach (FOpcDevice fOdv in this.fChildOpcDeviceCollection)
                {
                    fOdv.open();
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
                closeAllOpcDevice();
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

        public void closeAllOpcDevice(
            )
        {
            try
            {
                foreach (FOpcDevice fOdv in this.fChildOpcDeviceCollection)
                {
                    fOdv.close();
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

        public FOpcDriverLog createOpcDriverLog(
            )
        {
            try
            {
                return new FOpcDriverLog(this);
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

        public FOpcDriver cloneOpcDriver(
            )
        {
            try
            {
                return new FOpcDriver(this.fOcdCore.fXmlDoc.clone(true));
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
                        return FOpcDriverCommon.createObject(this.fOcdCore, fXmlNodeSearchList[i]);
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
                        return FOpcDriverCommon.createObject(this.fOcdCore, fXmlNodeSearchList[i]);
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

        public FIObject searchOpcLibrarySeries(
            FIObject fBaseObject,
            string searchWord
            )
        {  
            const string xPath =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + "/" + FXmlTagOLM.E_OpcLibraryModeling + "//*";

            try
            {
                // ***
                // OPC Library Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.OpcDriver &&
                    fBaseObject.fObjectType != FObjectType.OpcLibraryGroup &&
                    fBaseObject.fObjectType != FObjectType.OpcLibrary &&
                    fBaseObject.fObjectType != FObjectType.OpcMessageList &&
                    fBaseObject.fObjectType != FObjectType.OpcMessages &&
                    fBaseObject.fObjectType != FObjectType.OpcMessage &&
                    fBaseObject.fObjectType != FObjectType.OpcEventItemList &&
                    fBaseObject.fObjectType != FObjectType.OpcEventItem &&
                    fBaseObject.fObjectType != FObjectType.OpcItemList &&
                    fBaseObject.fObjectType != FObjectType.OpcItem
                    )
                {
                    return null;
                }

                // --

                return searchCommonSeries(
                   fBaseObject.uniqueIdToString,
                   searchWord,
                   this.fOcdCore.fXmlDoc.selectNodes(xPath)
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

        public FIObject searchOpcDeviceSeries(
           FIObject fBaseObject,
           ref FOpcSession fBaseSession,
           string searchWord
           )
        {
            const string xPathOdm =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + "/" + FXmlTagODM.E_OpcDeviceModeling + "/" + FXmlTagODV.E_OpcDevice + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + "/" + FXmlTagODM.E_OpcDeviceModeling + "/" + FXmlTagODV.E_OpcDevice + "/" + FXmlTagOSN.E_OpcSession;
            // --
            const string xPathOlb =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + "/" + FXmlTagOLM.E_OpcLibraryModeling + "/" + FXmlTagOLG.E_OpcLibraryGroup + "/" +
                FXmlTagOLB.E_OpcLibrary + "[@" + FXmlTagOLB.A_UniqueId + "='{0}']";
            // --            
            const string xPathOlm = ".//*";
            // --
            const string xPathOsn =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + "/" + FXmlTagODM.E_OpcDeviceModeling + "/" + FXmlTagODV.E_OpcDevice + "/" +
                FXmlTagOSN.E_OpcSession + "[@" + FXmlTagOSN.A_UniqueId + "='{0}']";

            string baseUniqueId = string.Empty;
            FXmlNodeList fXmlNodeOdmSearchList = null;
            FXmlNodeList fXmlNodeOlmSearchList = null;
            FXmlNode fXmlNodeOlb = null;
            FXmlNode fXmlNodeOsn = null;
            int index = 0;
            int indexNo = 0;
            string uniqueId = string.Empty;
            string osnUniqueId = string.Empty;
            string olbUniqueId = string.Empty;
            string[] uniqueIds = null;
            List<string> keys = null;
            List<FXmlNode> values = null;

            try
            {
                // ***
                // OPC Device Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.OpcDriver &&
                    fBaseObject.fObjectType != FObjectType.OpcDevice &&
                    fBaseObject.fObjectType != FObjectType.OpcSession &&
                    fBaseObject.fObjectType != FObjectType.OpcMessageList &&
                    fBaseObject.fObjectType != FObjectType.OpcMessages &&
                    fBaseObject.fObjectType != FObjectType.OpcMessage &&
                    fBaseObject.fObjectType != FObjectType.OpcEventItemList &&
                    fBaseObject.fObjectType != FObjectType.OpcEventItem &&
                    fBaseObject.fObjectType != FObjectType.OpcItemList &&
                    fBaseObject.fObjectType != FObjectType.OpcItem
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
                fXmlNodeOdmSearchList = this.fOcdCore.fXmlDoc.selectNodes(xPathOdm);
                // --
                foreach (FXmlNode x in fXmlNodeOdmSearchList)
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

                    if (x.name == FXmlTagOSN.E_OpcSession)
                    {
                        osnUniqueId = uniqueId;
                        olbUniqueId = x.get_attrVal(FXmlTagOSN.A_OpcLibraryId, FXmlTagOSN.D_OpcLibraryId);
                        // --
                        if (olbUniqueId != string.Empty)
                        {
                            fXmlNodeOlb = this.fOcdCore.fXmlDoc.selectSingleNode(string.Format(xPathOlb, olbUniqueId));
                            fXmlNodeOlmSearchList = fXmlNodeOlb.selectNodes(xPathOlm);
                            // --
                            foreach (FXmlNode xn in fXmlNodeOlmSearchList)
                            {
                                uniqueId = osnUniqueId + "-" + xn.get_attrVal(FXmlTagCommon.A_UniqueId, FXmlTagCommon.D_UniqueId);
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
                            fXmlNodeOsn = this.fOcdCore.fXmlDoc.selectSingleNode(string.Format(xPathOsn, uniqueIds[0]));
                            fBaseSession = (FOpcSession)FOpcDriverCommon.createObject(this.fOcdCore, fXmlNodeOsn);
                        }
                        else
                        {
                            fBaseSession = null;
                        }
                        return FOpcDriverCommon.createObject(this.fOcdCore, values[i]);
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
                            fXmlNodeOsn = this.fOcdCore.fXmlDoc.selectSingleNode(string.Format(xPathOsn, uniqueIds[0]));
                            fBaseSession = (FOpcSession)FOpcDriverCommon.createObject(this.fOcdCore, fXmlNodeOsn);
                        }
                        else
                        {
                            fBaseSession = null;
                        }
                        return FOpcDriverCommon.createObject(this.fOcdCore, values[i]);
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
                fXmlNodeOdmSearchList = null;
                fXmlNodeOlmSearchList = null;
                fXmlNodeOlb = null;
                fXmlNodeOsn = null;
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
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + "/" + FXmlTagHLM.E_HostLibraryModeling + "//*";

            try
            {
                // ***
                // Host Library Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.OpcDriver &&
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
                   this.fOcdCore.fXmlDoc.selectNodes(xPath)
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
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + "/" + FXmlTagHDM.E_HostDeviceModeling + "//*";
            // --
            const string xPathHlb =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + "/" + FXmlTagHLM.E_HostLibraryModeling + "/" + FXmlTagHLG.E_HostLibraryGroup + "/" +
                FXmlTagHLB.E_HostLibrary + "[@" + FXmlTagHLB.A_UniqueId + "='{0}']";
            // --            
            const string xPatHlm = ".//*";
            // --
            const string xPathHsn =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + "/" + FXmlTagHDM.E_HostDeviceModeling + "/" + FXmlTagHDV.E_HostDevice + "/" +
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
                    fBaseObject.fObjectType != FObjectType.OpcDriver &&
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
                fXmlNodeHdmSearchList = this.fOcdCore.fXmlDoc.selectNodes(xPathHdm);
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
                            fXmlNodeHlb = this.fOcdCore.fXmlDoc.selectSingleNode(string.Format(xPathHlb, hlbUniqueId));
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
                            fXmlNodeHsn = this.fOcdCore.fXmlDoc.selectSingleNode(string.Format(xPathHsn, uniqueIds[0]));
                            fBaseSession = (FHostSession)FOpcDriverCommon.createObject(this.fOcdCore, fXmlNodeHsn);
                        }
                        else
                        {
                            fBaseSession = null;
                        }
                        return FOpcDriverCommon.createObject(this.fOcdCore, values[i]);
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
                            fXmlNodeHsn = this.fOcdCore.fXmlDoc.selectSingleNode(string.Format(xPathHsn, uniqueIds[0]));
                            fBaseSession = (FHostSession)FOpcDriverCommon.createObject(this.fOcdCore, fXmlNodeHsn);
                        }
                        else
                        {
                            fBaseSession = null;
                        }
                        return FOpcDriverCommon.createObject(this.fOcdCore, values[i]);
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
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + "/" + FXmlTagSET.E_Setup + "/" + FXmlTagOND.E_ObjectNameDefinition + "//*";

            try
            {
                // ***
                // Object Name Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.OpcDriver &&
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
                   this.fOcdCore.fXmlDoc.selectNodes(xPath)
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
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + "/" + FXmlTagSET.E_Setup + "/" + FXmlTagFND.E_FunctionNameDefinition + "//*";

            try
            {
                // ***
                // Function Name Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.OpcDriver &&
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
                   this.fOcdCore.fXmlDoc.selectNodes(xPath)
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
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + "/" + FXmlTagSET.E_Setup + "/" + FXmlTagUTD.E_UserTagNameDefinition + "//*";

            try
            {
                // ***
                // User Name Series 검증
                // ***
                if (fBaseObject.fObjectType != FObjectType.UserTagName)
                {
                    return null;
                }

                // --

                return searchCommonSeries(
                   fBaseObject.uniqueIdToString,
                   searchWord,
                   this.fOcdCore.fXmlDoc.selectNodes(xPath)
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
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + "/" + FXmlTagSET.E_Setup + "/" + FXmlTagDCD.E_DataConversionSetDefinition + "//*";

            try
            {
                // ***
                // Data Conversion Set Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.OpcDriver && 
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
                   this.fOcdCore.fXmlDoc.selectNodes(xPath)
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
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + "/" + FXmlTagSET.E_Setup + "/" + FXmlTagESD.E_EquipmentStateSetDefinition + "//*";

            try
            {
                // ***
                // Equipment State Set Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.OpcDriver &&
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
                   this.fOcdCore.fXmlDoc.selectNodes(xPath)
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
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + "/" + FXmlTagSET.E_Setup + "/" + FXmlTagRPD.E_RepositoryDefinition + "//*";

            try
            {
                // ***
                // Repository Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.OpcDriver &&
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
                   this.fOcdCore.fXmlDoc.selectNodes(xPath)
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
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + "/" + FXmlTagSET.E_Setup + "/" + FXmlTagEND.E_EnvironmentDefinition + "//*";

            try
            {
                // ***
                // Environment Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.OpcDriver &&
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
                   this.fOcdCore.fXmlDoc.selectNodes(xPath)
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
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + "/" + FXmlTagSET.E_Setup + "/" + FXmlTagDSD.E_DataSetDefinition + "//*";

            try
            {
                // ***
                // Data Set Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.OpcDriver &&
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
                   this.fOcdCore.fXmlDoc.selectNodes(xPath)
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
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + "/" + FXmlTagEQM.E_EquipmentModeling + "/" + FXmlTagEQP.E_Equipment + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + "/" + FXmlTagEQM.E_EquipmentModeling + "/" + FXmlTagEQP.E_Equipment + " /" + FXmlTagSNG.E_ScenarioGroup + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + "/" + FXmlTagEQM.E_EquipmentModeling + "/" + FXmlTagEQP.E_Equipment + " /" + FXmlTagSNG.E_ScenarioGroup + "/" + FXmlTagSNR.E_Scenario;

            try
            {
                // ***
                // Equipment Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.OpcDriver &&
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
                    this.fOcdCore.fXmlDoc.selectNodes(xPath)
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
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + "/" + FXmlTagEQM.E_EquipmentModeling + "/" + FXmlTagEQP.E_Equipment + " /" + FXmlTagSNG.E_ScenarioGroup + "/" +
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
                        fBaseObject.fObjectType != FObjectType.OpcTrigger &&
                        fBaseObject.fObjectType != FObjectType.OpcCondition &&
                        fBaseObject.fObjectType != FObjectType.OpcExpression &&
                        fBaseObject.fObjectType != FObjectType.OpcTransmitter &&
                        fBaseObject.fObjectType != FObjectType.OpcTransfer &&
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

                fXmlNodeSearchList = this.fOcdCore.fXmlDoc.selectNodes(string.Format(xPath, fBaseScenario.uniqueIdToString));
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
                        return FOpcDriverCommon.createObject(this.fOcdCore, fXmlNodeSearchList[i]);
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
                        return FOpcDriverCommon.createObject(this.fOcdCore, fXmlNodeSearchList[i]);
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

        public FIObject searchItemNameSeries(
           FIObject fBaseObject,
           string searchWord
           )
        {
            const string xPath =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagOCD.E_OpcDriver + "/" + FXmlTagODM.E_OpcDeviceModeling + "//*";

            try
            {
                // ***
                // Item Name 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.OpcDriver &&
                    fBaseObject.fObjectType != FObjectType.OpcDevice &&
                    fBaseObject.fObjectType != FObjectType.OpcSession &&
                    fBaseObject.fObjectType != FObjectType.ItemName
                    )
                {
                    return null;
                }

                // --

                return searchCommonSeries(
                   fBaseObject.uniqueIdToString,
                   searchWord,
                   this.fOcdCore.fXmlDoc.selectNodes(xPath)
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

        public FObjectNameList appendChildObjectNameList(
            FObjectNameList fNewChild
            )
        {
            FXmlNode fXmlNodeOnd = null;

            try
            {
                fXmlNodeOnd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagOND.E_ObjectNameDefinition);

                // --

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeOnd.appendChild(fNewChild.fXmlNode));
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(fXmlNodeOnd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeOnd.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(fXmlNodeOnd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeOnd.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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
                FOpcDriverCommon.validateRemoveChildObject(fXmlNodeOnd, fChild.fXmlNode);

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
                    FOpcDriverCommon.validateRemoveChildObject(fXmlNodeOnd, fOnl.fXmlNode);
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

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeFnd.appendChild(fNewChild.fXmlNode));
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(fXmlNodeFnd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeFnd.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(fXmlNodeFnd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeFnd.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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
                FOpcDriverCommon.validateRemoveChildObject(fXmlNodeFnd, fChild.fXmlNode);

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
                    FOpcDriverCommon.validateRemoveChildObject(fXmlNodeFnd, fFnl.fXmlNode);
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

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeDcd.appendChild(fNewChild.fXmlNode));
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(fXmlNodeEsd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeEsd.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(fXmlNodeEsd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeEsd.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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
                FOpcDriverCommon.validateRemoveChildObject(fXmlNodeDcd, fChild.fXmlNode);

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
                    FOpcDriverCommon.validateRemoveChildObject(fXmlNodeDcd, fDcl.fXmlNode);
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

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeEsd.appendChild(fNewChild.fXmlNode));
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(fXmlNodeEsd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeEsd.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(fXmlNodeEsd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeEsd.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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
                FOpcDriverCommon.validateRemoveChildObject(fXmlNodeEsd, fChild.fXmlNode);

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
                    FOpcDriverCommon.validateRemoveChildObject(fXmlNodeEsd, fEsl.fXmlNode);
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

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeRpd.appendChild(fNewChild.fXmlNode));
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(fXmlNodeRpd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeRpd.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(fXmlNodeRpd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeRpd.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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
                FOpcDriverCommon.validateRemoveChildObject(fXmlNodeRpd, fChild.fXmlNode);

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
                    FOpcDriverCommon.validateRemoveChildObject(fXmlNodeRpd, fRpl.fXmlNode);
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

        public FObjectNameList pasteChildObjectNameList(
            )
        {
            FObjectNameList fObjectNameList = null;

            try
            {
                FOpcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.ObjectNameList);

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
                FOpcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.FunctionNameList);

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
                FOpcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.DataConversionSetList);

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
                FOpcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.EquipmentStateSetList);

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
                FOpcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.RepositoryList);

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
                FOpcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.EnvironmentList);

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
                FOpcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.DataSetList);

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

        public FOpcLibraryGroup pasteChildOpcLibraryGroup(
            )
        {
            FOpcLibraryGroup fOpcLibraryGroup = null;

            try
            {
                FOpcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.OpcLibraryGroup);

                // -- 

                fOpcLibraryGroup = (FOpcLibraryGroup)this.pasteObject(FCbObjectFormat.OpcLibraryGroup);
                this.appendChildOpcLibraryGroup(fOpcLibraryGroup);

                // --

                return fOpcLibraryGroup;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fOpcLibraryGroup = null;
            }

            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOpcDevice pasteChildOpcDevice(
            )
        {
            FOpcDevice fOpcDevice = null;

            try
            {
                FOpcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.OpcDevice);

                // -- 

                fOpcDevice = (FOpcDevice)this.pasteObject(FCbObjectFormat.OpcDevice);
                // --
                fOpcDevice.changeState(FDeviceState.Closed);
                // --
                foreach (FOpcSession fOsn in fOpcDevice.fChildOpcSessionCollection)
                {
                    fOsn.fXmlNode.set_attrVal(FXmlTagOSN.A_OpcLibraryId, FXmlTagOSN.D_OpcLibraryId, "");
                }
                this.appendChildOpcDevice(fOpcDevice);

                // --

                return fOpcDevice;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fOpcDevice = null;
            }
            return null;
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

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeEnd.appendChild(fNewChild.fXmlNode));
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(fXmlNodeEnd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeEnd.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(fXmlNodeEnd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeEnd.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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
                FOpcDriverCommon.validateRemoveChildObject(fXmlNodeEnd, fChild.fXmlNode);

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
                    FOpcDriverCommon.validateRemoveChildObject(fXmlNodeEnd, fEnl.fXmlNode);
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

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeDsd.appendChild(fNewChild.fXmlNode));
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(fXmlNodeDsd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeDsd.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(fXmlNodeDsd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeDsd.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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
                FOpcDriverCommon.validateRemoveChildObject(fXmlNodeRpd, fChild.fXmlNode);

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
                    FOpcDriverCommon.validateRemoveChildObject(fXmlNodeDsd, fDsl.fXmlNode);
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

        public FOpcLibraryGroup appendChildOpcLibraryGroup(
            FOpcLibraryGroup fNewChild
            )
        {
            FXmlNode fXmlNodePlm = null;

            try
            {
                fXmlNodePlm = this.fXmlNode.selectSingleNode(FXmlTagOLM.E_OpcLibraryModeling);

                // --

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodePlm.appendChild(fNewChild.fXmlNode));                
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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
                if (fXmlNodePlm != null)
                {
                    fXmlNodePlm.Dispose();
                    fXmlNodePlm = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOpcLibraryGroup insertBeforeChildOpcLibraryGroup(
            FOpcLibraryGroup fNewChild,
            FOpcLibraryGroup fRefChild
            )
        {
            FXmlNode fXmlNodePlm = null;

            try
            {
                fXmlNodePlm = this.fXmlNode.selectSingleNode(FXmlTagOLM.E_OpcLibraryModeling);

                // --

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(fXmlNodePlm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodePlm.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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
                if (fXmlNodePlm != null)
                {
                    fXmlNodePlm.Dispose();
                    fXmlNodePlm = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOpcLibraryGroup insertAfterChildOpcLibraryGroup(
            FOpcLibraryGroup fNewChild,
            FOpcLibraryGroup fRefChild
            )
        {
            FXmlNode fXmlNodePlm = null;

            try
            {
                fXmlNodePlm = this.fXmlNode.selectSingleNode(FXmlTagOLM.E_OpcLibraryModeling);

                // --

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(fXmlNodePlm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodePlm.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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
                if (fXmlNodePlm != null)
                {
                    fXmlNodePlm.Dispose();
                    fXmlNodePlm = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOpcLibraryGroup removeChildOpcLibraryGroup(
            FOpcLibraryGroup fChild
            )
        {
            FXmlNode fXmlNodePlm = null;

            try
            {
                fXmlNodePlm = this.fXmlNode.selectSingleNode(FXmlTagOLM.E_OpcLibraryModeling);
                FOpcDriverCommon.validateRemoveChildObject(fXmlNodePlm, fChild.fXmlNode);

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
                if (fXmlNodePlm != null)
                {
                    fXmlNodePlm.Dispose();
                    fXmlNodePlm = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeChildOpcLibraryGroup(
            FOpcLibraryGroup[] fChilds
            )
        {
            FXmlNode fXmlNodePlm = null;

            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                fXmlNodePlm = this.fXmlNode.selectSingleNode(FXmlTagOLM.E_OpcLibraryModeling);
                foreach (FOpcLibraryGroup fSlg in fChilds)
                {
                    FOpcDriverCommon.validateRemoveChildObject(fXmlNodePlm, fSlg.fXmlNode);
                }

                // --

                foreach (FOpcLibraryGroup fSlg in fChilds)
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
                if (fXmlNodePlm != null)
                {
                    fXmlNodePlm.Dispose();
                    fXmlNodePlm = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeAllChildOpcLibraryGroup(
            )
        {
            FOpcLibraryGroupCollection fOlgCollection = null;

            try
            {
                fOlgCollection = this.fChildOpcLibraryGroupCollection;
                if (fOlgCollection.count == 0)
                {
                    return;
                }

                // --

                foreach (FOpcLibraryGroup fPlg in fOlgCollection)
                {
                    if (fPlg.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }
                }

                // --

                foreach (FOpcLibraryGroup fPlg in fOlgCollection)
                {
                    fPlg.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fOlgCollection != null)
                {
                    fOlgCollection.Dispose();
                    fOlgCollection = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOpcDevice appendChildOpcDevice(
            FOpcDevice fNewChild
            )
        {
            FXmlNode fXmlNodeOdm = null;

            try
            {
                fXmlNodeOdm = this.fXmlNode.selectSingleNode(FXmlTagODM.E_OpcDeviceModeling);

                // --

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeOdm.appendChild(fNewChild.fXmlNode));                
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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
                if (fXmlNodeOdm != null)
                {
                    fXmlNodeOdm.Dispose();
                    fXmlNodeOdm = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOpcDevice insertBeforeChildOpcDevice(
           FOpcDevice fNewChild,
           FOpcDevice fRefChild
           )
        {
            FXmlNode fXmlNodeOdm = null;

            try
            {
                fXmlNodeOdm = this.fXmlNode.selectSingleNode(FXmlTagODM.E_OpcDeviceModeling);

                // --

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(fXmlNodeOdm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeOdm.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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
                if (fXmlNodeOdm != null)
                {
                    fXmlNodeOdm.Dispose();
                    fXmlNodeOdm = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOpcDevice insertAfterChildOpcDevice(
           FOpcDevice fNewChild,
           FOpcDevice fRefChild
           )
        {
            FXmlNode fXmlNodeOdm = null;

            try
            {
                fXmlNodeOdm = this.fXmlNode.selectSingleNode(FXmlTagODM.E_OpcDeviceModeling);

                // --

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(fXmlNodeOdm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeOdm.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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
                if (fXmlNodeOdm != null)
                {
                    fXmlNodeOdm.Dispose();
                    fXmlNodeOdm = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOpcDevice removeChildOpcDevice(
            FOpcDevice fChild
            )
        {
            FXmlNode fXmlNodeOdm = null;

            try
            {
                fXmlNodeOdm = this.fXmlNode.selectSingleNode(FXmlTagODM.E_OpcDeviceModeling);
                FOpcDriverCommon.validateRemoveChildObject(fXmlNodeOdm, fChild.fXmlNode);

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
                if (fXmlNodeOdm != null)
                {
                    fXmlNodeOdm.Dispose();
                    fXmlNodeOdm = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeChildOpcDevice(
            FOpcDevice[] fChilds
            )
        {
            FXmlNode fXmlNodeOdm = null;

            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                fXmlNodeOdm = this.fXmlNode.selectSingleNode(FXmlTagODM.E_OpcDeviceModeling);
                foreach (FOpcDevice fOdv in fChilds)
                {
                    FOpcDriverCommon.validateRemoveChildObject(fXmlNodeOdm, fOdv.fXmlNode);
                    // --
                    if (fOdv.fState != FDeviceState.Closed)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0027, "Device"));
                    }
                }

                // --

                foreach (FOpcDevice fOdv in fChilds)
                {
                    fOdv.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeOdm != null)
                {
                    fXmlNodeOdm.Dispose();
                    fXmlNodeOdm = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeAllChildOpcDevice(
            )
        {
            FOpcDeviceCollection fOdvCollection = null;

            try
            {
                fOdvCollection = this.fChildOpcDeviceCollection;
                if (fOdvCollection.count == 0)
                {
                    return;
                }

                // --

                foreach (FOpcDevice fOdv in fOdvCollection)
                {
                    if (fOdv.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }

                    if (fOdv.fState != FDeviceState.Closed)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0027, "Device"));
                    }
                }

                // --

                foreach (FOpcDevice fOdv in fOdvCollection)
                {
                    fOdv.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fOdvCollection != null)
                {
                    fOdvCollection.Dispose();
                    fOdvCollection = null;
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

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeHlm.appendChild(fNewChild.fXmlNode));                
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(fXmlNodeHlm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeHlm.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(fXmlNodeHlm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeHlm.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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
                FOpcDriverCommon.validateRemoveChildObject(fXmlNodeHlm, fChild.fXmlNode);

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
                    FOpcDriverCommon.validateRemoveChildObject(fXmlNodeHlm, fHlg.fXmlNode);
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

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeHdm.appendChild(fNewChild.fXmlNode));                
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(fXmlNodeHdm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeHdm.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(fXmlNodeHdm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeHdm.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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
                FOpcDriverCommon.validateRemoveChildObject(fXmlNodeHdm, fChild.fXmlNode);

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
                    FOpcDriverCommon.validateRemoveChildObject(fXmlNodeHdm, fHdv.fXmlNode);
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

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeEqm.appendChild(fNewChild.fXmlNode));                
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(fXmlNodeEqm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeEqm.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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

                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(fXmlNodeEqm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, fXmlNodeEqm.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fOcdCore.fEventPusher.pushEvent(
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
                FOpcDriverCommon.validateRemoveChildObject(fXmlNodeEqm, fChild.fXmlNode);

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
                    FOpcDriverCommon.validateRemoveChildObject(fXmlNodeEqm, fEqp.fXmlNode);
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
        // Add by Jeff.Kim 2015.11.07
        // 특정 Host Messages, DataSet을 여러 모델링 파일에 한번에 적용하기 위함.
        public bool substitute(
            out string resultMsg
            )
        {
            FIObject fIObjectCopied = null;
            FIObject fIOld = null;
            FIOpcOperand fIOpcOperand = null;
            // --
            FHostMessages fOldHostMessages = null;
            FHostMessages fNewHostMessages = null;
            // --
            FDataSetList fOldDataSetList = null;
            FDataSetList fNewDataSetList = null;
            // --
            FDataConversionSet fOldDataConvSet = null;
            FDataConversionSet fNewDataConvSet = null;
            // --
            FOpcTrigger fOpcTrigger = null;
            FOpcCondition fNewOpcCondition = null;
            List<FOpcExpression> fOpcExpressionList = null;
            FOpcExpression fNewOpcExpression = null;
            // --
            resultMsg = string.Empty;

            try
            {
                // --

                fIObjectCopied = this.pasteObject();
                if (fIObjectCopied == null)
                {
                    return false;
                }

                // --
                if (fIObjectCopied.fObjectType == FObjectType.HostMessages)
                {
                    #region Host Messages

                    fIOld = this.searchHostLibrarySeries(this, fIObjectCopied.name);
                    if (fIOld == null)
                    {
                        resultMsg = string.Format(FConstants.err_m_0016, "Host Messages");
                        return false;
                    }

                    // --

                    if (fIObjectCopied.fObjectType == fIOld.fObjectType)
                    {
                        fOldHostMessages = (FHostMessages)fIOld;
                        fNewHostMessages = fOldHostMessages.pasteSibling();
                            
                        // --

                        fNewHostMessages.fXmlNode.set_attrVal(FXmlTagHMS.A_UniqueId, FXmlTagHMS.D_UniqueId, fOldHostMessages.uniqueIdToString);
                        fNewHostMessages.fXmlNode.set_attrVal(FXmlTagHMS.A_Locked, FXmlTagHMS.D_Locked, FBoolean.fromBool(fOldHostMessages.locked));

                        for (int i = 0; i < fOldHostMessages.fChildHostMessageCollection.count; i++)
                        {
                            FHostMessage fOldHmg = fOldHostMessages.fChildHostMessageCollection[i];
                            foreach (FHostMessage fNewHmg in fNewHostMessages.selectHostMessageByName(fOldHmg.name))
                            {
                                // --
                                fNewHmg.fXmlNode.set_attrVal(FXmlTagHMG.A_UniqueId, FXmlTagHMG.D_UniqueId, fOldHmg.uniqueIdToString);
                                fNewHmg.fXmlNode.set_attrVal(FXmlTagHMG.A_Locked, FXmlTagHMG.D_Locked, FBoolean.fromBool(fOldHmg.locked));
                                // --
                                FHostItemCollection fLockItems = fOldHmg.selectAllHostItemByLock();
                                if (fLockItems.count > 0)
                                {
                                    foreach (FHostItem hItm in fLockItems)
                                    {
                                        FHostItem hNewItm = fNewHmg.selectSingleAllHostItemByName(hItm.name);
                                        if (hNewItm != null)
                                        {
                                            hNewItm.fXmlNode.set_attrVal(FXmlTagHIT.A_UniqueId, FXmlTagHIT.D_UniqueId, hItm.uniqueIdToString);
                                            hNewItm.fXmlNode.set_attrVal(FXmlTagHIT.A_Locked, FXmlTagHIT.D_Locked, FBoolean.fromBool(hItm.locked));
                                        }
                                    }
                                }
                            }
                        }

                        // --
                        fOldHostMessages.forceRemove();
                    }
                   

                    #endregion
                }
                else if (fIObjectCopied.fObjectType == FObjectType.DataSetList)
                {
                    #region Data Set List

                    fIOld = this.searchDataSetSeries(this, fIObjectCopied.name);
                    if (fIOld != null)
                    {
                        if (fIObjectCopied.fObjectType == fIOld.fObjectType)
                        {
                            fOldDataSetList = (FDataSetList)fIOld;
                            fNewDataSetList = fOldDataSetList.pasteSibling();

                            // --
                            fNewDataSetList.fXmlNode.set_attrVal(FXmlTagDSL.A_UniqueId, FXmlTagDSL.D_UniqueId, fOldDataSetList.uniqueIdToString);
                            fNewDataSetList.fXmlNode.set_attrVal(FXmlTagDSL.A_Locked, FXmlTagDSL.D_Locked, FBoolean.fromBool(fOldDataSetList.locked));

                            // --
                            for (int i = 0; i < fOldDataSetList.fChildDataSetCollection.count; i++)
                            {
                                FDataSet fOldDs = fOldDataSetList.fChildDataSetCollection[i];
                                foreach (FDataSet fNewDs in fNewDataSetList.selectDataSetByName(fOldDs.name))
                                {
                                    // --
                                    fNewDs.fXmlNode.set_attrVal(FXmlTagDTS.A_UniqueId, FXmlTagDTS.D_UniqueId, fOldDs.uniqueIdToString);
                                    fNewDs.fXmlNode.set_attrVal(FXmlTagDTS.A_Locked, FXmlTagDTS.D_Locked, FBoolean.fromBool(fOldDs.locked));
                                    // --
                                    FDataCollection fLockItems = fOldDs.selectAllDataByLock();
                                    if (fLockItems.count > 0)
                                    {
                                        foreach (FData fData in fLockItems)
                                        {
                                            FData fNewData = fNewDs.selectSingleDataByName(fData.name);
                                            if (fNewData != null)
                                            {
                                                fNewData.fXmlNode.set_attrVal(FXmlTagDAT.A_UniqueId, FXmlTagDAT.D_UniqueId, fData.uniqueIdToString);
                                                fNewData.fXmlNode.set_attrVal(FXmlTagDAT.A_Locked, FXmlTagDAT.D_Locked, FBoolean.fromBool(fData.locked));
                                            }
                                        }
                                    }
                                }
                            }

                            // --
                            fOldDataSetList.forceRemove();
                        }
                    }
                    else
                    {
                        this.pasteChildDataSetList();                    
                    }

                    // --
                    #endregion
                }
                else if (fIObjectCopied.fObjectType == FObjectType.DataConversionSet)
                {
                    #region Data Conversion Set

                    fIOld = this.searchDataConversionSetSeries(this, fIObjectCopied.name);
                    if (fIOld == null)
                    {
                        resultMsg = string.Format(FConstants.err_m_0016, "Data Conversion Set");
                        return false;
                    }

                    // --

                    if (fIObjectCopied.fObjectType == fIOld.fObjectType)
                    {
                        fOldDataConvSet = (FDataConversionSet)fIOld;
                        fNewDataConvSet = fOldDataConvSet.pasteSibling();

                        // --

                        fNewDataConvSet.fXmlNode.set_attrVal(FXmlTagDCS.A_UniqueId, FXmlTagDCS.D_UniqueId, fOldDataConvSet.uniqueIdToString);
                        fNewDataConvSet.fXmlNode.set_attrVal(FXmlTagDCS.A_Locked, FXmlTagDCS.D_Locked, FBoolean.fromBool(fOldDataConvSet.locked));
                                                
                        // --
                        fOldDataConvSet.forceRemove();
                    }


                    #endregion
                }
                else if (fIObjectCopied.fObjectType == FObjectType.OpcCondition)
                {
                    #region Opc Condition

                    fNewOpcCondition = (FOpcCondition)fIObjectCopied;

                    // --
                    // Add by Jeff.Kim 2015.12.01
                    // Opc Condition을 적용하는것이 아니라, Condition의 Child Expression 을 적용한다. 
                    // --
                    foreach (FEquipment fEqp in this.fChildEquipmentCollection)
                    {
                        foreach (FScenarioGroup fSg in fEqp.fChildScenarioGroupCollection)
                        {
                            foreach (FScenario fScenario in fSg.fChildScenarioCollection)
                            {
                                foreach (FIFlow fFlow in fScenario.fChildFlowCollection)
                                {
                                    if (fFlow.fFlowType == FFlowType.OpcTrigger)
                                    {
                                        fOpcTrigger = (FOpcTrigger)fFlow;

                                        // --
                                        // 이름이 같은 Triger일경우만 Expression 적용
                                        if (fOpcTrigger.name != fNewOpcCondition.parentName)
                                        {
                                            continue;
                                        }

                                        // --

                                        foreach (FOpcCondition fOpcCondition in fOpcTrigger.fChildOpcConditionCollection)
                                        {
                                            // --
                                            
                                            if (fOpcCondition.hasMessage)
                                            {
                                                if (fOpcCondition.fMessage.name == fNewOpcCondition.messageName)
                                                {
                                                    // --
                                                    fOpcExpressionList = new List<FOpcExpression>();

                                                    // --
                                                    #region Duplicated Expression Check

                                                    foreach (FOpcExpression fNewOpcExp in fNewOpcCondition.fChildOpcExpressionCollection)
                                                    {
                                                        // --

                                                        // 중복 Expression 확인
                                                        bool duplicated = false;
                                                        foreach (FOpcExpression fOpcExp in fOpcCondition.fChildOpcExpressionCollection)
                                                        {
                                                            if (fNewOpcExp.fOperandType == fOpcExp.fOperandType)
                                                            {
                                                                if (fNewOpcExp.operandName2 == fOpcExp.operandName)
                                                                {
                                                                    if (fNewOpcExp.fOperation == fOpcExp.fOperation)
                                                                    {
                                                                        if (fNewOpcExp.stringValue == fOpcExp.stringValue)
                                                                        {
                                                                            duplicated = true;
                                                                            break;
                                                                        }
                                                                    }
                                                                }
                                                            }

                                                        }
                                                        
                                                        // --
                                                        if (!duplicated)
                                                        {
                                                            fOpcExpressionList.Add(fNewOpcExp);
                                                        }

                                                        // --
                                                    }

                                                    #endregion

                                                    // --
                                                    #region Append Expression

                                                    foreach (FOpcExpression fOpcExp in fOpcExpressionList)
                                                    {
                                                        // --
                                                        fIOpcOperand = null;
                                                        if (fOpcExp.fOperandType == FOpcOperandType.OpcItem)
                                                        {
                                                            fIOpcOperand = fOpcCondition.fMessage.selectSingleOpcItemByName(fOpcExp.operandName2);
                                                        }
                                                        else if (fOpcExp.fOperandType == FOpcOperandType.OpcEventItem)
                                                        {
                                                            fIOpcOperand = fOpcCondition.fMessage.selectSingleOpcEventItemByName(fOpcExp.operandName2);                                                            
                                                        }
                                                        else if (fOpcExp.fOperandType == FOpcOperandType.Environment)
                                                        {
                                                            fIOld = this.searchEnvironmentSeries(this, fOpcExp.operandName2);
                                                            if (fIOld.fObjectType == FObjectType.Environment)
                                                            {
                                                                fIOpcOperand = (FEnvironment)fIOld;
                                                            }
                                                        }

                                                        // --

                                                        if (fIOpcOperand != null)
                                                        {
                                                            // --
                                                            fNewOpcExpression = fOpcCondition.appendChildOpcExpression(new FOpcExpression(this));
                                                            fNewOpcExpression.fOperandType = fOpcExp.fOperandType;
                                                            fNewOpcExpression.fOperation = fOpcExp.fOperation;
                                                            fNewOpcExpression.fExpressionValueType = fOpcExp.fExpressionValueType;
                                                            // --
                                                            fNewOpcExpression.setOperand(fIOpcOperand);
                                                            fNewOpcExpression.value = fOpcExp.value;
                                                            // --
                                                            if (fNewOpcExpression.fPreviousSibling != null)
                                                            {
                                                                fNewOpcExpression.fLogical = fOpcExp.fLogical;
                                                            }
                                                        }

                                                        // --
                                                    }

                                                    #endregion

                                                    // --
                                                }
                                            }
                                        }

                                        // --
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    // --

                    #endregion
                }

                // --

                return true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fIObjectCopied = null;
                fIOld = null;
                // --
                fOldHostMessages = null;
                fNewHostMessages = null;
                // --
                fOldDataSetList = null;
                fNewDataSetList = null;
                // --
                fOldDataConvSet = null;
                fNewDataConvSet = null;
                // --
                fOpcTrigger = null;
                fNewOpcCondition = null;
                fOpcExpressionList = null;
                fNewOpcExpression = null;
            }
            return false;
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

                fXmlNode = FOpcDriverCommon.getObjectXmlNode(fObject);
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
                    fObject.fObjectType == FObjectType.OpcLibraryGroup ||
                    fObject.fObjectType == FObjectType.OpcDevice ||
                    fObject.fObjectType == FObjectType.HostLibraryGroup ||
                    fObject.fObjectType == FObjectType.HostDevice ||
                    fObject.fObjectType == FObjectType.EquipmentStateSetList ||
                    fObject.fObjectType == FObjectType.Equipment
                    )
                {
                    return this;
                }

                // --

                return FOpcDriverCommon.createObject(this.fOcdCore, fXmlNode.fParentNode);
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

                fXmlNode = FOpcDriverCommon.getObjectXmlNode(fObject);
                if (fXmlNode.fPreviousSibling == null)
                {
                    return null;
                }

                // --

                return FOpcDriverCommon.createObject(this.fOcdCore, fXmlNode.fPreviousSibling);
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

                fXmlNode = FOpcDriverCommon.getObjectXmlNode(fObject);
                if (fXmlNode.fNextSibling == null)
                {
                    return null;
                }

                // --

                return FOpcDriverCommon.createObject(this.fOcdCore, fXmlNode.fNextSibling);
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

        public void cutVfeiLogFile(
            )
        {
            try
            {
                this.fOcdCore.fLogWriter.cutVfeiLogFile();
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

        public void cutOpcLogFile(
            )
        {
            try
            {
                this.fOcdCore.fLogWriter.cutOpcLogFile();
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
                this.fOcdCore.fLogWriter.cutVfeiLogFile();
                this.fOcdCore.fLogWriter.cutOpcLogFile();
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

        public FIObject selectSingleObjectByUniqueId(
            UInt64 uniqueId
            )
        {
            string xpath = string.Empty;
            FXmlNode fXmlNode = null;

            try
            {
                xpath = "//*[@" + FXmlTagCommon.A_UniqueId + "='" + uniqueId + "']";
                fXmlNode = this.fXmlNode.selectSingleNode(xpath);
                if (fXmlNode != null)
                {
                    return FOpcDriverCommon.createObject(this.fOcdCore, fXmlNode);
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
                    this.fOcdCore,
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
                return new FObjectNameList(this.fOcdCore, fXmlNode);
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
                return new FObjectNameList(this.fOcdCore, fXmlNode);
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
                    this.fOcdCore,
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
                return new FFunctionNameList(this.fOcdCore, fXmlNode);
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
                    this.fOcdCore,
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
                return new FUserTagName(this.fOcdCore, fXmlNode);
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
                return new FUserTagName(this.fOcdCore, fXmlNode);
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
                    this.fOcdCore,
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
                return new FDataConversionSetList(this.fOcdCore, fXmlNode);
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
                    this.fOcdCore,
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
                return new FEquipmentStateSetList(this.fOcdCore, fXmlNode);
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
                    this.fOcdCore,
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
                return new FRepositoryList(this.fOcdCore, fXmlNode);
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
                    this.fOcdCore,
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
                return new FDataSetList(this.fOcdCore, fXmlNode);
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
                    this.fOcdCore,
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
                return new FEnvironmentList(this.fOcdCore, fXmlNode);
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

        public FOpcLibraryGroupCollection selectOpcLibraryGroupByName(
            string name
            )
        {
            const string xpath = FXmlTagOLM.E_OpcLibraryModeling +
                "/" + FXmlTagOLG.E_OpcLibraryGroup + "[@" + FXmlTagOLG.A_Name + "='{0}']";

            try
            {
                return new FOpcLibraryGroupCollection(
                    this.fOcdCore,
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

        public FOpcLibraryGroup selectSingleOpcLibraryGroupByName(
            string name
            )
        {
            const string xpath = FXmlTagOLM.E_OpcLibraryModeling +
                "/" + FXmlTagOLG.E_OpcLibraryGroup + "[@" + FXmlTagOLG.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FOpcLibraryGroup(this.fOcdCore, fXmlNode);
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

        public FOpcDeviceCollection selectOpcDeviceByName(
            string name
            )
        {
            const string xpath =
                FXmlTagODM.E_OpcDeviceModeling +
                "/" + FXmlTagODV.E_OpcDevice + "[@" + FXmlTagODV.A_Name + "='{0}']";

            try
            {
                return new FOpcDeviceCollection(
                    this.fOcdCore,
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

        public FOpcDevice selectSingleSecsDeviceByName(
            string name
            )
        {
            const string xpath =
                FXmlTagODM.E_OpcDeviceModeling +
                "/" + FXmlTagODV.E_OpcDevice + "[@" + FXmlTagODV.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FOpcDevice(this.fOcdCore, fXmlNode);
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
                    this.fOcdCore,
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
                return new FHostLibraryGroup(this.fOcdCore, fXmlNode);
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
                    this.fOcdCore,
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
                return new FHostDevice(this.fOcdCore, fXmlNode);
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
                    this.fOcdCore,
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
                return new FEquipment(this.fOcdCore, fXmlNode);
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
                return new FEntryPoint(this.fOcdCore, fXmlNode);
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
                    this.fOcdCore,
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
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the OPC Driver and the Entry Point", "same"));
                }

                // --

                this.fOcdCore.fEventPusher.pushEntryPointCalledEvent(
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

        public void openRepository(
            )
        {
            try
            {
                this.fOcdCore.openRepositoryMaterial();
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
                this.fOcdCore.loadRepositoryMaterial(rawData);
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
                this.fOcdCore.saveRepositoryMaterial(rawData);
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
                return this.fOcdCore.getRepositoryMaterialRawData();
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
                this.fOcdCore.removeRepositoryMaterialById(rpmIds);
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

        #region On OPC Driver Modeling Event

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

        #region On OPC Driver Communication Event

        internal void onOpcDeviceStateChanged(
            FEventArgsBase fArgsBase
            )
        {
            FOpcDeviceStateChangedEventArgs fArgs = null;

            try
            {
                fArgs = (FOpcDeviceStateChangedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FOpcDriverCommon.resetLocked(fArgs.fOpcDeviceStateChangedLog.fXmlNode);

                // --

                fArgs.fOpcDeviceStateChangedLog.fXmlNode.set_attrVal(FXmlTagODVL.A_Time, FXmlTagODVL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fOcdCore.fLogWriter.pushOpcLog(fArgs.fOpcDeviceStateChangedLog.fXmlNode);

                // --

                if (OpcDeviceStateChanged != null)
                {
                    OpcDeviceStateChanged(this, fArgs);
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

        internal void onOpcDeviceErrorRaised(
            FEventArgsBase fArgsBase
            )
        {
            FOpcDeviceErrorRaisedEventArgs fArgs = null;

            try
            {
                fArgs = (FOpcDeviceErrorRaisedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FOpcDriverCommon.resetLocked(fArgs.fOpcDeviceErrorRaisedLog.fXmlNode);

                // --

                fArgs.fOpcDeviceErrorRaisedLog.fXmlNode.set_attrVal(FXmlTagODEL.A_Time, FXmlTagODEL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fOcdCore.fLogWriter.pushOpcLog(fArgs.fOpcDeviceErrorRaisedLog.fXmlNode);

                // --

                if (OpcDeviceErrorRaised != null)
                {
                    OpcDeviceErrorRaised(this, fArgs);
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

        internal void onOpcDeviceTimeoutRaised(
            FEventArgsBase fArgsBase
            )
        {
            FOpcDeviceTimeoutRaisedEventArgs fArgs = null;

            try
            {
                fArgs = (FOpcDeviceTimeoutRaisedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FOpcDriverCommon.resetLocked(fArgs.fOpcDeviceTimeoutRaisedLog.fXmlNode);

                // --

                fArgs.fOpcDeviceTimeoutRaisedLog.fXmlNode.set_attrVal(FXmlTagODTL.A_Time, FXmlTagODTL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fOcdCore.fLogWriter.pushOpcLog(fArgs.fOpcDeviceTimeoutRaisedLog.fXmlNode);

                // --

                if (OpcDeviceTimeoutRaised != null)
                {
                    OpcDeviceTimeoutRaised(this, fArgs);
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

        internal void onOpcDeviceDataMessageRead(
            FEventArgsBase fArgsBase
            )
        {
            FOpcDeviceDataMessageReadEventArgs fArgs = null;

            try
            {
                fArgs = (FOpcDeviceDataMessageReadEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FOpcDriverCommon.resetLocked(fArgs.fOpcDeviceDataMessageReadLog.fXmlNode);

                // --

                fArgs.fOpcDeviceDataMessageReadLog.fXmlNode.set_attrVal(FXmlTagOMGL.A_Time, FXmlTagOMGL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                // Modify by Jeff.Kim 2015.09.17
                // Modeling 에서 Log Enable 되었을 경우만 Log Write
                if (fArgs.fOpcDeviceDataMessageReadLog.logEnabled && confirmlogLevelEnabled(fArgs.fOpcDeviceDataMessageReadLog.logLevel))
                {
                    this.fOcdCore.fLogWriter.pushOpcLog(fArgs.fOpcDeviceDataMessageReadLog.fXmlNode);
                }

                // --

                if (OpcDeviceDataMessageRead != null)
                {
                    OpcDeviceDataMessageRead(this, fArgs);
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

        internal void onOpcDeviceDataMessageWritten(
            FEventArgsBase fArgsBase
            )
        {
            FOpcDeviceDataMessageWrittenEventArgs fArgs = null;

            try
            {
                fArgs = (FOpcDeviceDataMessageWrittenEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FOpcDriverCommon.resetLocked(fArgs.fOpcDeviceDataMessageWrittenLog.fXmlNode);

                // --

                fArgs.fOpcDeviceDataMessageWrittenLog.fXmlNode.set_attrVal(FXmlTagOMGL.A_Time, FXmlTagOMGL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                // Modify by Jeff.Kim 2015.09.17
                // Modeling 에서 Log Enable 되었을 경우만 Log Write
                if (fArgs.fOpcDeviceDataMessageWrittenLog.logEnabled && confirmlogLevelEnabled(fArgs.fOpcDeviceDataMessageWrittenLog.logLevel))
                {
                    this.fOcdCore.fLogWriter.pushOpcLog(fArgs.fOpcDeviceDataMessageWrittenLog.fXmlNode);
                }
                // --

                if (OpcDeviceDataMessageWritten != null)
                {
                    OpcDeviceDataMessageWritten(this, fArgs);
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

        internal void onOpcSessionItemNameRefreshed(
            FEventArgsBase fArgsBase
            )
        {
            FOpcSessionItemNameRefreshedEventArgs fArgs = null;

            try
            {
                fArgs = (FOpcSessionItemNameRefreshedEventArgs)fArgsBase;
                
                // --

                if (OpcSessionItemNameRefreshed != null)
                {
                    OpcSessionItemNameRefreshed(this, fArgs);
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
                FOpcDriverCommon.resetLocked(fArgs.fHostDeviceStateChangedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Host Device State Changed Log Write
                // ***
                fArgs.fHostDeviceStateChangedLog.fXmlNode.set_attrVal(FXmlTagHDVL.A_Time, FXmlTagHDVL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fOcdCore.fLogWriter.pushOpcLog(fArgs.fHostDeviceStateChangedLog.fXmlNode);

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
                FOpcDriverCommon.resetLocked(fArgs.fHostDeviceErrorRaisedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Host Device Error Raised Log Write
                // ***
                fArgs.fHostDeviceErrorRaisedLog.fXmlNode.set_attrVal(FXmlTagHDEL.A_Time, FXmlTagHDEL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fOcdCore.fLogWriter.pushOpcLog(fArgs.fHostDeviceErrorRaisedLog.fXmlNode);

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
                FOpcDriverCommon.resetLocked(fArgs.fHostDeviceVfeiReceivedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Host Device VFEI Received Log Write
                // ***
                fArgs.fHostDeviceVfeiReceivedLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_Time, FXmlTagVFEL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fOcdCore.fLogWriter.pushOpcLog(fArgs.fHostDeviceVfeiReceivedLog.fXmlNode);

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
                FOpcDriverCommon.resetLocked(fArgs.fHostDeviceVfeiSentLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Host Device VFEI Sent Log Write
                // ***
                fArgs.fHostDeviceVfeiSentLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_Time, FXmlTagVFEL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fOcdCore.fLogWriter.pushOpcLog(fArgs.fHostDeviceVfeiSentLog.fXmlNode);

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
                FOpcDriverCommon.resetLocked(fArgs.fHostDeviceDataMessageReceivedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Host Device Data Message Received Log Write
                // ***
                fArgs.fHostDeviceDataMessageReceivedLog.fXmlNode.set_attrVal(FXmlTagHMGL.A_Time, FXmlTagHMGL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fHostDeviceDataMessageReceivedLog.logEnabled && confirmlogLevelEnabled(fArgs.fHostDeviceDataMessageReceivedLog.logLevel))
                {
                    // --
                    this.fOcdCore.fLogWriter.pushOpcLog(fArgs.fHostDeviceDataMessageReceivedLog.fXmlNode);
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
                FOpcDriverCommon.resetLocked(fArgs.fHostDeviceDataMessageSentLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Host Device Data Message Sent Log Write
                // ***
                fArgs.fHostDeviceDataMessageSentLog.fXmlNode.set_attrVal(FXmlTagHMGL.A_Time, FXmlTagHMGL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fHostDeviceDataMessageSentLog.logEnabled && confirmlogLevelEnabled(fArgs.fHostDeviceDataMessageSentLog.logLevel))
                {
                    this.fOcdCore.fLogWriter.pushOpcLog(fArgs.fHostDeviceDataMessageSentLog.fXmlNode);
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

        internal void onOpcTriggerRaised(
            FEventArgsBase fArgsBase
            )
        {
            FOpcTriggerRaisedEventArgs fArgs = null;

            try
            {
                fArgs = (FOpcTriggerRaisedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FOpcDriverCommon.resetLocked(fArgs.fOpcTriggerRaisedLog.fXmlNode);

                // --

                // ***
                // OPC Trigger Raised Log Write
                // ***
                fArgs.fOpcTriggerRaisedLog.fXmlNode.set_attrVal(FXmlTagOTRL.A_Time, FXmlTagOTRL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    this.fOcdCore.fLogWriter.pushOpcLog(fArgs.fOpcTriggerRaisedLog.fXmlNode);
                }

                // --

                if (OpcTriggerRaised != null)
                {
                    OpcTriggerRaised(this, fArgs);
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

        internal void onOpcTransmitterRaised(
            FEventArgsBase fArgsBase
            )
        {
            FOpcTransmitterRaisedEventArgs fArgs = null;

            try
            {
                fArgs = (FOpcTransmitterRaisedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FOpcDriverCommon.resetLocked(fArgs.fOpcTransmitterRaisedLog.fXmlNode);

                // --

                // ***
                // OPC Transmitter Raised Log Write
                // ***
                fArgs.fOpcTransmitterRaisedLog.fXmlNode.set_attrVal(FXmlTagOTNL.A_Time, FXmlTagOTNL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    this.fOcdCore.fLogWriter.pushOpcLog(fArgs.fOpcTransmitterRaisedLog.fXmlNode);
                }

                // --

                if (OpcTransmitterRaised != null)
                {
                    OpcTransmitterRaised(this, fArgs);
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
                FOpcDriverCommon.resetLocked(fArgs.fHostTriggerRaisedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Host Trigger Raised Log Write
                // ***
                fArgs.fHostTriggerRaisedLog.fXmlNode.set_attrVal(FXmlTagHTRL.A_Time, FXmlTagHTRL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    // --
                    this.fOcdCore.fLogWriter.pushOpcLog(fArgs.fHostTriggerRaisedLog.fXmlNode);
                }

                // --

                if (HostTriggerRaised != null)
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
                FOpcDriverCommon.resetLocked(fArgs.fHostTransmitterRaisedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Host Transmitter Raised Log Write
                // ***
                fArgs.fHostTransmitterRaisedLog.fXmlNode.set_attrVal(FXmlTagHTNL.A_Time, FXmlTagHTNL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    // --
                    this.fOcdCore.fLogWriter.pushOpcLog(fArgs.fHostTransmitterRaisedLog.fXmlNode);
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
                FOpcDriverCommon.resetLocked(fArgs.fJudgementPerformedLog.fXmlNode);

                // --

                // ***
                // Judgement Performed Log Write
                // ***
                fArgs.fJudgementPerformedLog.fXmlNode.set_attrVal(FXmlTagJDML.A_Time, FXmlTagJDML.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    // --
                    this.fOcdCore.fLogWriter.pushOpcLog(fArgs.fJudgementPerformedLog.fXmlNode);
                }

                // --

                if (JudgementPerformed != null)
                {
                    JudgementPerformed(this, fArgs);
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
                FOpcDriverCommon.resetLocked(fArgs.fMapperPerformedLog.fXmlNode);

                // --

                // ***
                // Mapper Performed Log Write
                // ***
                fArgs.fMapperPerformedLog.fXmlNode.set_attrVal(FXmlTagMAPL.A_Time, FXmlTagMAPL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    // --
                    this.fOcdCore.fLogWriter.pushOpcLog(fArgs.fMapperPerformedLog.fXmlNode);
                }

                // --

                if (MapperPerformed != null)
                {
                    MapperPerformed(this, fArgs);
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
                FOpcDriverCommon.resetLocked(fArgs.fEquipmentStateSetAltererPerformedLog.fXmlNode);

                // --

                // ***
                // Equipment State Set Alterer Performed Log Write
                // ***
                fArgs.fEquipmentStateSetAltererPerformedLog.fXmlNode.set_attrVal(FXmlTagESAL.A_Time, FXmlTagESAL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    this.fOcdCore.fLogWriter.pushOpcLog(fArgs.fEquipmentStateSetAltererPerformedLog.fXmlNode);
                }

                // --

                if (EquipmentStateSetAltererPerformed != null)
                {
                    EquipmentStateSetAltererPerformed(this, fArgs);
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
                FOpcDriverCommon.resetLocked(fArgs.fStoragePerformedLog.fXmlNode);

                // --

                // ***
                // Storage Performed Log Write
                // ***
                fArgs.fStoragePerformedLog.fXmlNode.set_attrVal(FXmlTagSTGL.A_Time, FXmlTagSTGL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    this.fOcdCore.fLogWriter.pushOpcLog(fArgs.fStoragePerformedLog.fXmlNode);
                }

                // --

                if (StoragePerformed != null)
                {
                    StoragePerformed(this, fArgs);
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
                FOpcDriverCommon.resetLocked(fArgs.fCallbackRaisedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Callback Raised Log Write
                // ***
                fArgs.fCallbackRaisedLog.fXmlNode.set_attrVal(FXmlTagCBKL.A_Time, FXmlTagCBKL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    this.fOcdCore.fLogWriter.pushOpcLog(fArgs.fCallbackRaisedLog.fXmlNode);
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
                FOpcDriverCommon.resetLocked(fArgs.fFunctionCalledLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Function Called Log Write
                // ***
                fArgs.fFunctionCalledLog.fXmlNode.set_attrVal(FXmlTagFUNL.A_Time, FXmlTagFUNL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    this.fOcdCore.fLogWriter.pushOpcLog(fArgs.fFunctionCalledLog.fXmlNode);
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
                FOpcDriverCommon.resetLocked(fArgs.fBranchRaisedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Bransh Raised Log Write
                // ***
                fArgs.fBranchRaisedLog.fXmlNode.set_attrVal(FXmlTagBRNL.A_Time, FXmlTagBRNL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    this.fOcdCore.fLogWriter.pushOpcLog(fArgs.fBranchRaisedLog.fXmlNode);
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
                FOpcDriverCommon.resetLocked(fArgs.fCommentWrittenLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Comment Written Log Write
                // ***
                fArgs.fCommentWrittenLog.fXmlNode.set_attrVal(FXmlTagCMTL.A_Time, FXmlTagCMTL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    this.fOcdCore.fLogWriter.pushOpcLog(fArgs.fCommentWrittenLog.fXmlNode);
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
                FOpcDriverCommon.resetLocked(fArgs.fPauserRaisedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Comment Written Log Write
                // ***
                fArgs.fPauserRaisedLog.fXmlNode.set_attrVal(FXmlTagPAUL.A_Time, FXmlTagPAUL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    this.fOcdCore.fLogWriter.pushOpcLog(fArgs.fPauserRaisedLog.fXmlNode);
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
                FOpcDriverCommon.resetLocked(fArgs.fEntryPointCalledLog.fXmlNode);

                // --

                fArgs.fEntryPointCalledLog.fXmlNode.set_attrVal(FXmlTagETPL.A_Time, FXmlTagETPL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    this.fOcdCore.fLogWriter.pushOpcLog(fArgs.fEntryPointCalledLog.fXmlNode);
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
                FOpcDriverCommon.resetLocked(fArgs.fApplicationWrittenLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Application Written Log Write
                // ***
                fArgs.fApplicationWrittenLog.fXmlNode.set_attrVal(FXmlTagCMTL.A_Time, FXmlTagCMTL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fOcdCore.fLogWriter.pushOpcLog(fArgs.fApplicationWrittenLog.fXmlNode);

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
                if (!this.fOcdCore.fConfig.enabledEventsOfApplication)
                {
                    return;
                }

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FOpcDriverCommon.resetLocked(fApplicationWrittenLog.fXmlNode);

                // --
                
                this.fOcdCore.fEventPusher.pushApplicationWrittenEvent(fApplicationWrittenLog.fXmlNode);
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

        #region Virtual Data Read

        // --
        // Add by Jeff.Kim 2015.12.4
        // 임의의 OPC Read Event를 발생시키고자 할경우 사용하기 위해 추가
        // Device의 Open state와 관계없이 구동하고자 Opc Driver에 추가함.
        public void procVirtualDataRead(
            FOpcSession fOpcSession,
            FOpcMessageTransfer fOpcMessage
            )
        {
            FResultCode fResultCode = FResultCode.Success;
            FXmlNode fXmlNodeOmgl = null;
            FOpcDeviceDataMessageReadLog fLog = null;
            // --
            FXmlNode[] fXmlNodeOtrList = null;

            try
            {
                // --

                // ***
                // Read Message Parsing
                // ***
                fXmlNodeOmgl = FKepware2.parseVirtualOpcRead(
                    fOpcSession,
                    fOpcMessage
                    );
                fLog = this.fOcdCore.fEventPusher.createOpcDeviceDataMessageReadLog(fOpcSession.fXmlNode, fXmlNodeOmgl);

                // --                

                if (this.fOcdCore.fConfig.enabledEventsOfOpcDeviceDataMessage)
                {
                    this.fOcdCore.fEventPusher.pushOpcDeviceDataMessageReadEvent(fOpcSession.fParent, fResultCode, string.Empty, fLog);
                }

                // --

                // ***
                // OPC Trigger Parsing
                // ***
                if (this.fOcdCore.fOpcDriver.enabledEventsOfScenario)
                {
                    fXmlNodeOtrList = FKepware2.parseExpressionTrigger(this.fOpcDriver, fXmlNodeOmgl);
                    foreach (FXmlNode fXmlNodeOtr in fXmlNodeOtrList)
                    {
                        this.fOcdCore.fEventPusher.pushOpcTriggerRaisedEvent(FResultCode.Success, string.Empty, fXmlNodeOtr, fLog);
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeOmgl = null;
                fLog = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------       

    }   // Class end
}   // Namespace end
