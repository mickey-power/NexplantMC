/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPlcDriver.cs
--  Creator         : spike.lee
--  Create Date     : 2013.07.10
--  Description     : FAMate Core FaPlcDriver PLC Driver Main Class 
--  History         : Created by spike.lee at 2013.07.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    public class FPlcDriver : FBaseObject<FPlcDriver>, FIObject
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
        public event FPlcDeviceStateChangedEventHandler PlcDeviceStateChanged = null;
        public event FPlcDeviceErrorRaisedEventHandler PlcDeviceErrorRaised = null;
        public event FPlcDeviceTimeoutRaisedEventHandler PlcDeviceTimeoutRaised = null;
        public event FPlcDeviceDataReceivedEventHandler PlcDeviceDataReceived = null;
        public event FPlcDeviceDataSentEventHandler PlcDeviceDataSent = null;
        public event FPlcDeviceDataMessageReadEventHandler PlcDeviceDataMessageRead = null;
        public event FPlcDeviceDataMessageWrittenEventHandler PlcDeviceDataMessageWritten = null;
        // --
        public event FHostDeviceStateChangedEventHandler HostDeviceStateChanged = null;
        public event FHostDeviceErrorRaisedEventHandler HostDeviceErrorRaised = null;
        public event FHostDeviceVfeiReceivedEventHandler HostDeviceVfeiReceived = null;
        public event FHostDeviceVfeiSentEventHandler HostDeviceVfeiSent = null;
        public event FHostDeviceDataMessageReceivedEventHandler HostDeviceDataMessageReceived = null;
        public event FHostDeviceDataMessageSentEventHandler HostDeviceDataMessageSent = null;
        // --
        public event FPlcTriggerRaisedEventHandler PlcTriggerRaised = null;
        public event FPlcTransmitterRaisedEventHandler PlcTransmitterRaised = null;
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
        // PLC Driver 생성에 사용
        // ***
        public FPlcDriver(
            string licFileName
            )
            : base(licFileName)
        {
            this.fPlcDriver = this;
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2014.02.03 by spike.lee
        // PLC Driver reopenModelingFile 메소드에 사용
        // ***
        internal FPlcDriver(            
            ) 
            : base()
        {
            this.fPlcDriver = this;
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2014.02.03 by spike.lee
        // PLC Driver Clone에 사용
        // ***
        internal FPlcDriver(
            FXmlDocument fXmlDoc
            )
            : base(fXmlDoc)
        {   
            this.fPlcDriver = this;
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2014.02.03 by spike.lee
        // PLC Driver Instance 복사에 사용
        // ***
        internal FPlcDriver(            
            FPcdCore fPcdCore,
            FXmlNode fXmlNode
            ) 
            : base(fPcdCore, fXmlNode)
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPlcDriver(
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
                    return FObjectType.PlcDriver;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.PlcDriver;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagPCD.A_UniqueId, FXmlTagPCD.D_UniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name);
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
                    FPlcDriverCommon.validateName(value, true);

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPCD.A_Description, FXmlTagPCD.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagPCD.A_Description, FXmlTagPCD.D_Description, value, true);
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

                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagPCD.A_FontColor, FXmlTagPCD.D_FontColor));
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
                    this.fXmlNode.set_attrVal(FXmlTagPCD.A_FontColor, FXmlTagPCD.D_FontColor, value.Name, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagPCD.A_FontBold, FXmlTagPCD.D_FontBold));
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
                    this.fXmlNode.set_attrVal(FXmlTagPCD.A_FontBold, FXmlTagPCD.D_FontBold, FBoolean.fromBool(value), true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPCD.A_EapName, FXmlTagPCD.D_EapName);
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
                    FPlcDriverCommon.validateName(value, true);

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagPCD.A_EapName, FXmlTagPCD.D_EapName, value, true);

                    // -- 

                    this.fPcdCore.fConfig.eapName = value;
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
                    return this.fXmlNode.get_attrVal(FXmlTagPCD.A_UserTag1, FXmlTagPCD.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagPCD.A_UserTag1, FXmlTagPCD.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPCD.A_UserTag2, FXmlTagPCD.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagPCD.A_UserTag2, FXmlTagPCD.D_UserTag2, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPCD.A_UserTag3, FXmlTagPCD.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagPCD.A_UserTag3, FXmlTagPCD.D_UserTag3, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPCD.A_UserTag4, FXmlTagPCD.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagPCD.A_UserTag4, FXmlTagPCD.D_UserTag4, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPCD.A_UserTag5, FXmlTagPCD.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagPCD.A_UserTag5, FXmlTagPCD.D_UserTag5, value, true);
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
                    return new FObjectNameListCollection(this.fPcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return new FFunctionNameListCollection(this.fPcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return new FUserTagNameCollection(this.fPcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return new FDataConversionSetListCollection(this.fPcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return new FEquipmentStateSetListCollection(this.fPcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return new FRepositoryListCollection(this.fPcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return new FDataSetListCollection(this.fPcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return new FEnvironmentListCollection(this.fPcdCore, this.fXmlNode.selectNodes(xpath));
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

        public FPlcLibraryGroupCollection fChildPlcLibraryGroupCollection
        {
            get
            {
                const string xpath = FXmlTagPLM.E_PlcLibraryModeling + "/" + FXmlTagPLG.E_PlcLibraryGroup;

                try
                {
                    return new FPlcLibraryGroupCollection(this.fPcdCore, this.fXmlNode.selectNodes(xpath));
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

        public FPlcDeviceCollection fChildPlcDeviceCollection
        {
            get
            {
                const string xpath = FXmlTagPDM.E_PlcDeviceModeling + "/" + FXmlTagPDV.E_PlcDevice;

                try
                {
                    return new FPlcDeviceCollection(this.fPcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return new FHostLibraryGroupCollection(this.fPcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return new FHostDeviceCollection(this.fPcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return new FEquipmentCollection(this.fPcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return this.fPcdCore.fEventPusher.eventCount;
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
                    return this.fPcdCore.fEventPusher.isCompletedEventHandling;
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
                        FXmlTagPLM.E_PlcLibraryModeling + "/" + FXmlTagPLG.E_PlcLibraryGroup + " | " +
                        FXmlTagPDM.E_PlcDeviceModeling + "/" + FXmlTagPDV.E_PlcDevice + " | " +
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

        public bool canAppendChildPlcDevice
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

        public bool canAppendChildPlcLibraryGroup
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

        public bool canPasteChildPlcDevice
        {
            get
            {
                try
                {
                    if (!FClipboard.containsData(FCbObjectFormat.PlcDevice))
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

        public bool canPasteChildPlcLibraryGroup
        {
            get
            {
                try
                {
                    if (!FClipboard.containsData(FCbObjectFormat.PlcLibraryGroup))
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
                    return new FObjectCollection(this.fPcdCore, this.fXmlNode.selectNodes("NULL"));
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
                    return new FObjectCollection(this.fPcdCore, this.fXmlNode.selectNodes("NULL"));
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
                    return this.fPcdCore.fEquipmentStateMaterialStorage;
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
                    return this.fPcdCore.fRepositoryMaterialStorage;
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

        #region PLC Driver Config

        public string hostDriverDirectory
        {
            get
            {
                try
                {
                    return this.fPcdCore.fConfig.hostDriverDirectory;
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
                    this.fPcdCore.fConfig.hostDriverDirectory = value;
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
                    return this.fPcdCore.fConfig.logDirectory;
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
                    this.fPcdCore.fConfig.logDirectory = value;
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

        public bool enabledEventsOfPlcDeviceState
        {
            get
            {
                try
                {
                    return this.fPcdCore.fConfig.enabledEventsOfPlcDeviceState;
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
                    this.fPcdCore.fConfig.enabledEventsOfPlcDeviceState = value;
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

        public bool enabledEventsOfPlcDeviceError
        {
            get
            {
                try
                {
                    return this.fPcdCore.fConfig.enabledEventsOfPlcDeviceError;
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
                    this.fPcdCore.fConfig.enabledEventsOfPlcDeviceError = value;
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

        public bool enabledEventsOfPlcDeviceTimeout
        {
            get
            {
                try
                {
                    return this.fPcdCore.fConfig.enabledEventsOfPlcDeviceTimeout;
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
                    this.fPcdCore.fConfig.enabledEventsOfPlcDeviceTimeout = value;
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

        public bool enabledEventsOfPlcDeviceData
        {
            get
            {
                try
                {
                    return this.fPcdCore.fConfig.enabledEventsOfPlcDeviceData;
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
                    this.fPcdCore.fConfig.enabledEventsOfPlcDeviceData = value;
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

        public bool enabledEventsOfPlcDeviceDataMessage
        {
            get
            {
                try
                {
                    return this.fPcdCore.fConfig.enabledEventsOfPlcDeviceDataMessage;
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
                    this.fPcdCore.fConfig.enabledEventsOfPlcDeviceDataMessage = value;
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
                    return this.fPcdCore.fConfig.enabledEventsOfHostDeviceState;
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
                    this.fPcdCore.fConfig.enabledEventsOfHostDeviceState = value;
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
                    return this.fPcdCore.fConfig.enabledEventsOfHostDeviceError;
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
                    this.fPcdCore.fConfig.enabledEventsOfHostDeviceError = value;
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
                    return this.fPcdCore.fConfig.enabledEventsOfHostDeviceVfei;
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
                    this.fPcdCore.fConfig.enabledEventsOfHostDeviceVfei = value;
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
                    return this.fPcdCore.fConfig.enabledEventsOfHostDeviceDataMessage;
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
                    this.fPcdCore.fConfig.enabledEventsOfHostDeviceDataMessage = value;
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
                    return this.fPcdCore.fConfig.enabledEventsOfScenario;
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
                    this.fPcdCore.fConfig.enabledEventsOfScenario = value;
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
                    return this.fPcdCore.fConfig.enabledEventsOfApplication;
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
                    this.fPcdCore.fConfig.enabledEventsOfApplication = value;
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
                    return this.fPcdCore.fConfig.enabledLogOfBinary;
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
                    this.fPcdCore.fConfig.enabledLogOfBinary = value;
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
                    return this.fPcdCore.fConfig.enabledLogOfVfei;
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
                    this.fPcdCore.fConfig.enabledLogOfVfei = value;
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

        public bool enabledLogOfPlc
        {
            get
            {
                try
                {
                    return this.fPcdCore.fConfig.enabledLogOfPlc;
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
                    this.fPcdCore.fConfig.enabledLogOfPlc = value;
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
                    return this.fPcdCore.fConfig.maxLogFileSizeOfVfei;
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

                    this.fPcdCore.fConfig.maxLogFileSizeOfVfei = value;
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
                    return this.fPcdCore.fConfig.maxLogFileSizeOfBinary;
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
                    this.fPcdCore.fConfig.maxLogFileSizeOfBinary = value;
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

        public long maxLogFileSizeOfPlc
        {
            get
            {
                try
                {
                    return this.fPcdCore.fConfig.maxLogFileSizeOfPlc;
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
                    this.fPcdCore.fConfig.maxLogFileSizeOfPlc = value;
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
                    return this.fPcdCore.fConfig.maxLogCountOfBinary;
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
                    this.fPcdCore.fConfig.maxLogCountOfBinary = value;
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
                    return this.fPcdCore.fConfig.maxLogCountOfVfei;
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
                    this.fPcdCore.fConfig.maxLogCountOfVfei = value;
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

        public long maxLogCountOfPlc
        {
            get
            {
                try
                {
                    return this.fPcdCore.fConfig.maxLogCountOfPlc;
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
                    this.fPcdCore.fConfig.maxLogCountOfPlc = value;
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
                    return this.fPcdCore.fConfig.repositorySaveDirectory;
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
                    this.fPcdCore.fConfig.repositorySaveDirectory = value;
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
                    return this.fPcdCore.fConfig.enabledRepositorySave;
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
                    this.fPcdCore.fConfig.enabledRepositorySave = value;
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
                    return this.fPcdCore.fConfig.enabledRepositoryAutoRemove;
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
                    this.fPcdCore.fConfig.enabledRepositoryAutoRemove = value;
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
                    return this.fPcdCore.fConfig.repositoryKeepingPeriod;
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

                    this.fPcdCore.fConfig.repositoryKeepingPeriod = value;
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
                    info = this.name + " EAP=[" + this.eapName + "]";
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
                FPlcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.HostLibraryGroup);

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
                FPlcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.HostDevice);

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
                FPlcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.Equipment);

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
                // 새로운 File Open할 경우 모든 PLC Device와 Host Device를 Close 한다.
                // ***
                closeAllDevice();
                this.waitEventHandlingCompleted();

                // --

                this.fPcdCore.openModelingFile(fileName);
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
                this.fPcdCore.reopenModelingFile(fileName);
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
                this.fPcdCore.saveModelingFile(fileName);
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
                this.fPcdCore.fEventPusher.waitEventHandlingCompleted();
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
                openAllPlcDevice();
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

        public void openAllPlcDevice(
            )
        {
            try
            {
                foreach (FPlcDevice fPdv in this.fChildPlcDeviceCollection)
                {
                    fPdv.open();
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
                closeAllPlcDevice();
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

        public void closeAllPlcDevice(
            )
        {
            try
            {
                foreach (FPlcDevice fPdv in this.fChildPlcDeviceCollection)
                {
                    fPdv.close();
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

        public FPlcDriverLog createPlcDriverLog(
            )
        {
            try
            {
                return new FPlcDriverLog(this);
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

        public FPlcDriver clonePlcDriver(
            )
        {
            try
            {
                return new FPlcDriver(this.fPcdCore.fXmlDoc.clone(true));
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

        public FIObject searchPlcDeviceSeries(
           FIObject fBaseObject,
           ref FIObject fBaseSessionObject,
           string searchWord
           )
        {
            FIObject fObject = null;
            FXmlNode fXmlNode = null;
            FXmlNode fXmlNodePdv = null;
            FXmlNode fXmlNodePcd = null;
            string sessionId = string.Empty;

            try
            {
                // ***
                // Plc Device Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.PlcDriver &&
                    fBaseObject.fObjectType != FObjectType.PlcDevice &&
                    fBaseObject.fObjectType != FObjectType.PlcSession &&
                    fBaseObject.fObjectType != FObjectType.PlcLibraryGroup &&
                    fBaseObject.fObjectType != FObjectType.PlcLibrary &&
                    fBaseObject.fObjectType != FObjectType.PlcMessageList &&
                    fBaseObject.fObjectType != FObjectType.PlcMessages &&
                    fBaseObject.fObjectType != FObjectType.PlcMessage &&
                    fBaseObject.fObjectType != FObjectType.PlcBitList &&
                    fBaseObject.fObjectType != FObjectType.PlcBit &&
                    fBaseObject.fObjectType != FObjectType.PlcWordList &&
                    fBaseObject.fObjectType != FObjectType.PlcWord
                   )
                {
                    return null;
                }

                // --

                fXmlNode = FPlcDriverCommon.getObjectXmlNode(fBaseObject);

                // --                

                if (fXmlNode.name == FXmlTagPCD.E_PlcDriver)
                {
                    fXmlNodePdv = fXmlNode.selectSingleNode(FXmlTagPDM.E_PlcDeviceModeling + "/" + FXmlTagPDV.E_PlcDevice);

                    // -- 

                    if (fXmlNodePdv == null)
                    {
                        if (FSearchNode.contains(fXmlNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord))
                        {
                            return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNode);
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else if (FSearchNode.contains(fXmlNodePdv.get_attrVal(FXmlTagPDV.A_Name, FXmlTagPDV.D_Name), searchWord))
                    {
                        return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNodePdv);
                    }

                    // -- 

                    fXmlNode = fXmlNodePdv;
                }
                else if (fXmlNode.name == FXmlTagPDV.E_PlcDevice)
                {
                    if (
                        fXmlNode.fFirstChild == null &&
                        fXmlNode.fNextSibling == null
                        )
                    {
                        fXmlNodePcd = fXmlNode.fParentNode.fParentNode;
                        if (FSearchNode.contains(fXmlNodePcd.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord))
                        {
                            return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNodePcd);
                        }
                    }
                }

                if (fBaseSessionObject != null)
                {
                    sessionId = fBaseSessionObject.uniqueIdToString;
                }

                // --                

                fXmlNode = searchPlcDeviceNode(fXmlNode, sessionId, searchWord);
                if (fXmlNode == null)
                {
                    return null;
                }

                fObject = FPlcDriverCommon.createObject(this.fPcdCore, fXmlNode);

                if (
                    fObject.fObjectType == FObjectType.PlcDriver ||
                    fObject.fObjectType == FObjectType.PlcDevice ||
                    fObject.fObjectType == FObjectType.PlcSession
                    )
                {
                    fBaseSessionObject = null;
                }
                else
                {
                    fBaseSessionObject = this.selectSingleObjectByUniqueId(UInt64.Parse(FSearchNode.lastSession));
                }
                return fObject;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                FSearchNode.resetResource();
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private FXmlNode searchPlcDeviceNode(
            FXmlNode fXmlNodeBase,
            string baseSessionId,
            string searchWord
            )
        {
            FXmlNode fXmlNodeRoot = null;           
            FXmlNode fXmlNodeStart = null;          
            FXmlNode fXmlNodePlcDriver = null;
            FXmlNode fXmlNodeSession = null;
            string xpath = string.Empty;

            try
            {
                fXmlNodeRoot = this.fXmlNode.selectSingleNode(FXmlTagPDM.E_PlcDeviceModeling);

                // --

                if (fXmlNodeBase.fFirstChild != null)
                {
                    fXmlNodeStart = fXmlNodeBase.fFirstChild;
                }
                else if (
                    (fXmlNodeBase.fNextSibling != null) &&
                    (fXmlNodeBase.name != FXmlTagPSN.E_PlcSession)
                    )
                {
                    fXmlNodeStart = fXmlNodeBase.fNextSibling;
                }
                else if (fXmlNodeBase.name == FXmlTagPSN.E_PlcSession)
                {
                    baseSessionId = fXmlNodeBase.get_attrVal(FXmlTagPSN.A_UniqueId, FXmlTagPSN.D_UniqueId);
                    // --
                    if (fXmlNodeBase.get_attrVal(FXmlTagPSN.A_PlcLibraryId, FXmlTagPSN.D_PlcLibraryId) == string.Empty)
                    {
                        if (fXmlNodeBase.fNextSibling != null)
                        {
                            fXmlNodeStart = fXmlNodeBase.fNextSibling;
                        }
                        else
                        {
                            fXmlNodeStart = FSearchNode.getNextNode(fXmlNodeBase, fXmlNodeRoot);

                            if (fXmlNodeStart.fPreviousSibling == fXmlNodeRoot)
                            {
                                fXmlNodeStart = fXmlNodeRoot.fFirstChild;
                            }
                            else if (
                                fXmlNodeStart.name == FXmlTagPDM.E_PlcDeviceModeling &&
                                FSearchNode.contains(fXmlNodeStart.fParentNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord)
                                )
                            {
                                return fXmlNodeRoot.fParentNode;
                            }
                        }
                    }
                    else
                    {
                        xpath = FXmlTagPLM.E_PlcLibraryModeling + "//" + FXmlTagPLB.E_PlcLibrary +
                               "[@" + FXmlTagCommon.A_UniqueId + "='" + fXmlNodeBase.get_attrVal(FXmlTagPSN.A_PlcLibraryId, FXmlTagPSN.D_PlcLibraryId) + "']";
                        // --                        

                        fXmlNodeStart = fXmlNodeRoot.fParentNode.selectSingleNode(xpath);
                        if (fXmlNodeStart == null)
                        {
                            fXmlNodeStart = FSearchNode.getNextNode(fXmlNodeBase, fXmlNodeRoot);

                            if (
                                (fXmlNodeStart.fParentNode != null) &&
                                (fXmlNodeStart.fPreviousSibling == fXmlNodeRoot)
                                )
                            {
                                fXmlNodeStart = fXmlNodeRoot;
                            }
                        }
                        else
                        {
                            if (fXmlNodeStart.fFirstChild == null)
                            {
                                if (fXmlNodeBase.fNextSibling != null)
                                {
                                    fXmlNodeStart = fXmlNodeBase.fNextSibling;
                                }
                                else
                                {
                                    fXmlNodeStart = FSearchNode.getNextNode(fXmlNodeBase, fXmlNodeRoot);
                                }
                            }
                            else
                            {
                                fXmlNodeStart = fXmlNodeStart.fFirstChild;
                            }
                        }
                    }
                }
                else
                {
                    fXmlNodeStart = FSearchNode.getNextNode(fXmlNodeBase, fXmlNodeRoot);

                    if (
                        (fXmlNodeStart.fParentNode != null) &&
                        fXmlNodeStart.fPreviousSibling == fXmlNodeRoot
                        )
                    {
                        fXmlNodeStart = fXmlNodeRoot;
                    }
                    else if (fXmlNodeStart.name == FXmlTagPLB.E_PlcLibrary)
                    {
                        if (fXmlNodeBase.name == FXmlTagPSN.E_PlcSession)
                        {
                            fXmlNodeStart = fXmlNodeRoot;
                        }
                        else
                        {
                            fXmlNodePlcDriver = fXmlNodeRoot.fParentNode;

                            // --

                            xpath = "//" + FXmlTagPSN.E_PlcSession + "[@" + FXmlTagPSN.A_UniqueId + "='" + baseSessionId + "']";
                            fXmlNodeSession = fXmlNodeRoot.selectSingleNode(xpath);

                            // --

                            if (fXmlNodeSession.fNextSibling != null)
                            {
                                fXmlNodeStart = fXmlNodeSession.fNextSibling;
                            }
                            else
                            {
                                fXmlNodeStart = fXmlNodeStart.fParentNode;
                            }
                        }
                    }
                }

                return FSearchNode.searchPlcDeviceNode(fXmlNodeStart, fXmlNodeBase, fXmlNodeRoot, searchWord, baseSessionId);
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

        public FIObject searchPlcLibrarySeries(
            FIObject fBaseObject,
            string searchWord
            )
        {
            FXmlNode fXmlNode = null;
            FXmlNode fXmlNodePlg = null;

            try
            {
                // ***
                // Plc Library Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.PlcDriver &&
                    fBaseObject.fObjectType != FObjectType.PlcLibraryGroup &&
                    fBaseObject.fObjectType != FObjectType.PlcLibrary &&
                    fBaseObject.fObjectType != FObjectType.PlcMessageList &&
                    fBaseObject.fObjectType != FObjectType.PlcMessages &&
                    fBaseObject.fObjectType != FObjectType.PlcMessage &&
                    fBaseObject.fObjectType != FObjectType.PlcBitList &&
                    fBaseObject.fObjectType != FObjectType.PlcBit &&
                    fBaseObject.fObjectType != FObjectType.PlcWordList &&
                    fBaseObject.fObjectType != FObjectType.PlcWord
                    )
                {
                    return null;
                }

                // --

                fXmlNode = FPlcDriverCommon.getObjectXmlNode(fBaseObject);
                
                // --

                if (fXmlNode.name == FXmlTagPCD.E_PlcDriver)
                {
                    fXmlNodePlg = fXmlNode.selectSingleNode(FXmlTagPLM.E_PlcLibraryModeling + "/" + FXmlTagPLG.E_PlcLibraryGroup);

                    // -- 

                    if (fXmlNodePlg == null)
                    {
                        if (FSearchNode.contains(fXmlNode.get_attrVal(FXmlTagPLG.A_Name, FXmlTagPLG.D_Name), searchWord))
                        {
                            return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNode);
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else if (FSearchNode.contains(fXmlNodePlg.get_attrVal(FXmlTagPLG.A_Name, FXmlTagPLG.D_Name), searchWord))
                    {
                        return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNodePlg);
                    }

                    // --

                    fXmlNode = fXmlNodePlg;
                }

                // --

                fXmlNode = searchPlcLibraryNode(fXmlNode, searchWord);
                if (fXmlNode == null)
                {
                    return null;
                }

                return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNode);
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

        private FXmlNode searchPlcLibraryNode(
            FXmlNode fXmlNodeBase,
            string searchWord
            )
        {
            FXmlNode fXmlNodeRoot = null;
            FXmlNode fXmlNodeStart = null;

            try
            {
                fXmlNodeRoot = this.fXmlNode.selectSingleNode(FXmlTagPLM.E_PlcLibraryModeling);

                // --

                if (fXmlNodeBase.fFirstChild != null)
                {
                    fXmlNodeStart = fXmlNodeBase.fFirstChild;
                }
                else if (fXmlNodeBase.fNextSibling != null)
                {
                    fXmlNodeStart = fXmlNodeBase.fNextSibling;
                }
                else
                {
                    fXmlNodeStart = FSearchNode.getNextNode(fXmlNodeBase, fXmlNodeRoot);

                    if (fXmlNodeStart.fPreviousSibling == fXmlNodeRoot)
                    {
                        fXmlNodeStart = fXmlNodeRoot;
                    }
                    else if (
                        fXmlNodeStart.name == FXmlTagPLM.E_PlcLibraryModeling &&
                        FSearchNode.contains(fXmlNodeStart.fParentNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord)
                        )
                    {
                        return fXmlNodeRoot.fParentNode;
                    }
                }

                return FSearchNode.searchPlcLibraryNode(fXmlNodeStart, fXmlNodeBase, fXmlNodeRoot, searchWord);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                FSearchNode.resetResource();
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIObject searchHostDeviceSeries(
           FIObject fBaseObject,
           ref FIObject fBaseSessionObject,
           string searchWord
           )
        {
            FIObject fObject = null;
            FXmlNode fXmlNode = null;
            FXmlNode fXmlNodeHdv = null;
            FXmlNode fXmlNodePcd = null;
            string sessionId = string.Empty;

            try
            {
                // ***
                // Host Device Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.PlcDriver &&
                    fBaseObject.fObjectType != FObjectType.HostDevice &&
                    fBaseObject.fObjectType != FObjectType.HostSession &&
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

                fXmlNode = FPlcDriverCommon.getObjectXmlNode(fBaseObject);

                // --                

                if (fXmlNode.name == FXmlTagPCD.E_PlcDriver)
                {
                    fXmlNodeHdv = fXmlNode.selectSingleNode(FXmlTagHDM.E_HostDeviceModeling + "/" + FXmlTagHDV.E_HostDevice);

                    // -- 

                    if (fXmlNodeHdv == null)
                    {
                        if (FSearchNode.contains(fXmlNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord))
                        {
                            return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNode);
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else if (FSearchNode.contains(fXmlNodeHdv.get_attrVal(FXmlTagHDV.A_Name, FXmlTagHDV.D_Name), searchWord))
                    {
                        return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNodeHdv);
                    }

                    // -- 

                    fXmlNode = fXmlNodeHdv;
                }
                else if (fXmlNode.name == FXmlTagHDV.E_HostDevice)
                {
                    if (
                        fXmlNode.fFirstChild == null &&
                        fXmlNode.fNextSibling == null
                        )
                    {
                        fXmlNodePcd = fXmlNode.fParentNode.fParentNode;
                        if (FSearchNode.contains(fXmlNodePcd.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord))
                        {
                            return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNodePcd);
                        }
                    }
                }

                if (fBaseSessionObject != null)
                {
                    sessionId = fBaseSessionObject.uniqueIdToString;
                }

                // --                

                fXmlNode = searchHostDeviceNode(fXmlNode, sessionId, searchWord);
                if (fXmlNode == null)
                {
                    return null;
                }

                fObject = FPlcDriverCommon.createObject(this.fPcdCore, fXmlNode);

                if (
                    fObject.fObjectType == FObjectType.PlcDriver ||
                    fObject.fObjectType == FObjectType.HostDevice ||
                    fObject.fObjectType == FObjectType.HostSession
                    )
                {
                    fBaseSessionObject = null;
                }
                else
                {
                    fBaseSessionObject = this.selectSingleObjectByUniqueId(UInt64.Parse(FSearchNode.lastSession));
                }
                return fObject;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                FSearchNode.resetResource();
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private FXmlNode searchHostDeviceNode(
            FXmlNode fXmlNodeBase,
            string baseSessionId,
            string searchWord
            )
        {
            FXmlNode fXmlNodeRoot = null;           // HostDevice
            FXmlNode fXmlNodeStart = null;          // ActiveNode
            FXmlNode fXmlNodeSecsDriver = null;
            FXmlNode fXmlNodeSession = null;
            string xpath = string.Empty;

            try
            {
                fXmlNodeRoot = this.fXmlNode.selectSingleNode(FXmlTagHDM.E_HostDeviceModeling);

                // --

                if (fXmlNodeBase.fFirstChild != null)
                {
                    fXmlNodeStart = fXmlNodeBase.fFirstChild;
                }
                else if (
                    (fXmlNodeBase.fNextSibling != null) &&
                    (fXmlNodeBase.name != FXmlTagHSN.E_HostSession)
                    )
                {
                    fXmlNodeStart = fXmlNodeBase.fNextSibling;
                }
                else if (fXmlNodeBase.name == FXmlTagHSN.E_HostSession)
                {
                    baseSessionId = fXmlNodeBase.get_attrVal(FXmlTagHSN.A_UniqueId, FXmlTagHSN.D_UniqueId);
                    // --
                    if (fXmlNodeBase.get_attrVal(FXmlTagHSN.A_HostLibraryId, FXmlTagHSN.D_HostLibraryId) == string.Empty)
                    {
                        if (fXmlNodeBase.fNextSibling != null)
                        {
                            fXmlNodeStart = fXmlNodeBase.fNextSibling;
                        }
                        else
                        {
                            fXmlNodeStart = FSearchNode.getNextNode(fXmlNodeBase, fXmlNodeRoot);

                            if (fXmlNodeStart.fPreviousSibling == fXmlNodeRoot)
                            {
                                fXmlNodeStart = fXmlNodeRoot.fFirstChild;
                            }
                            else if (
                                fXmlNodeStart.name == FXmlTagHDM.E_HostDeviceModeling &&
                                FSearchNode.contains(fXmlNodeStart.fParentNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord)
                                )
                            {
                                return fXmlNodeRoot.fParentNode;
                            }
                        }
                    }
                    else
                    {
                        xpath = FXmlTagHLM.E_HostLibraryModeling + "//" + FXmlTagHLB.E_HostLibrary +
                               "[@" + FXmlTagCommon.A_UniqueId + "='" + fXmlNodeBase.get_attrVal(FXmlTagHSN.A_HostLibraryId, FXmlTagHSN.D_HostLibraryId) + "']";
                        // --                        

                        fXmlNodeStart = fXmlNodeRoot.fParentNode.selectSingleNode(xpath);
                        if (fXmlNodeStart == null)
                        {
                            fXmlNodeStart = FSearchNode.getNextNode(fXmlNodeBase, fXmlNodeRoot);

                            if (
                                (fXmlNodeStart.fParentNode != null) &&
                                (fXmlNodeStart.fPreviousSibling == fXmlNodeRoot)
                                )
                            {
                                fXmlNodeStart = fXmlNodeRoot;
                            }
                        }
                        else
                        {
                            if (fXmlNodeStart.fFirstChild == null)
                            {
                                if (fXmlNodeBase.fNextSibling != null)
                                {
                                    fXmlNodeStart = fXmlNodeBase.fNextSibling;
                                }
                                else
                                {
                                    fXmlNodeStart = FSearchNode.getNextNode(fXmlNodeBase, fXmlNodeRoot);
                                }
                            }
                            else
                            {
                                fXmlNodeStart = fXmlNodeStart.fFirstChild;
                            }
                        }
                    }
                }
                else
                {
                    fXmlNodeStart = FSearchNode.getNextNode(fXmlNodeBase, fXmlNodeRoot);

                    if (
                        (fXmlNodeStart.fParentNode != null) &&
                        fXmlNodeStart.fPreviousSibling == fXmlNodeRoot
                        )
                    {
                        fXmlNodeStart = fXmlNodeRoot;
                    }
                    else if (fXmlNodeStart.name == FXmlTagHLB.E_HostLibrary)
                    {
                        if (fXmlNodeBase.name == FXmlTagHSN.E_HostSession)
                        {
                            fXmlNodeStart = fXmlNodeRoot;
                        }
                        else
                        {
                            fXmlNodeSecsDriver = fXmlNodeRoot.fParentNode;

                            // --

                            xpath = "//" + FXmlTagHSN.E_HostSession + "[@" + FXmlTagHSN.A_UniqueId + "='" + baseSessionId + "']";
                            fXmlNodeSession = fXmlNodeRoot.selectSingleNode(xpath);

                            // --

                            if (fXmlNodeSession.fNextSibling != null)
                            {
                                fXmlNodeStart = fXmlNodeSession.fNextSibling;
                            }
                            else
                            {
                                fXmlNodeStart = fXmlNodeStart.fParentNode;
                            }
                        }
                    }
                }

                return FSearchNode.searchHostDeviceNode(fXmlNodeStart, fXmlNodeBase, fXmlNodeRoot, searchWord, baseSessionId);
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

        public FIObject searchHostLibrarySeries(
            FIObject fBaseObject,
            string searchWord
            )
        {
            FXmlNode fXmlNode = null;
            FXmlNode fXmlNodeHlg = null;

            try
            {
                // ***
                // Host Library Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.PlcDriver &&
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

                fXmlNode = FPlcDriverCommon.getObjectXmlNode(fBaseObject);

                // --

                if (fXmlNode.name == FXmlTagPCD.E_PlcDriver)
                {
                    fXmlNodeHlg = fXmlNode.selectSingleNode(FXmlTagHLM.E_HostLibraryModeling + "/" + FXmlTagHLG.E_HostLibraryGroup);

                    // -- 

                    if (fXmlNodeHlg == null)
                    {
                        if (FSearchNode.contains(fXmlNode.get_attrVal(FXmlTagHLG.A_Name, FXmlTagHLG.D_Name), searchWord))
                        {
                            return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNode);
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else if (FSearchNode.contains(fXmlNodeHlg.get_attrVal(FXmlTagHLG.A_Name, FXmlTagHLG.D_Name), searchWord))
                    {
                        return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNodeHlg);
                    }

                    // --

                    fXmlNode = fXmlNodeHlg;
                }

                // --

                fXmlNode = searchHostLibraryNode(fXmlNode, searchWord);
                if (fXmlNode == null)
                {
                    return null;
                }

                return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNode);
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

        private FXmlNode searchHostLibraryNode(
            FXmlNode fXmlNodeBase,
            string searchWord
            )
        {
            FXmlNode fXmlNodeRoot = null;
            FXmlNode fXmlNodeStart = null;

            try
            {
                fXmlNodeRoot = this.fXmlNode.selectSingleNode(FXmlTagHLM.E_HostLibraryModeling);

                // --

                if (fXmlNodeBase.fFirstChild != null)
                {
                    fXmlNodeStart = fXmlNodeBase.fFirstChild;
                }
                else if (fXmlNodeBase.fNextSibling != null)
                {
                    fXmlNodeStart = fXmlNodeBase.fNextSibling;
                }
                else
                {
                    fXmlNodeStart = FSearchNode.getNextNode(fXmlNodeBase, fXmlNodeRoot);

                    if (fXmlNodeStart.fPreviousSibling == fXmlNodeRoot)
                    {
                        fXmlNodeStart = fXmlNodeRoot;
                    }
                    else if (
                        fXmlNodeStart.name == FXmlTagHLM.E_HostLibraryModeling &&
                        FSearchNode.contains(fXmlNodeStart.fParentNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord)
                        )
                    {
                        return fXmlNodeRoot.fParentNode;
                    }
                }

                return FSearchNode.searchHostLibraryNode(fXmlNodeStart, fXmlNodeBase, fXmlNodeRoot, searchWord);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                FSearchNode.resetResource();
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIObject searchEquipmentSeries(
            FIObject fBaseObject,
            string searchWord
            )
        {
            FIObject fObject = null;
            FXmlNode fXmlNode = null;

            try
            {
                // ***
                // Equipment Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.PlcDriver &&
                    fBaseObject.fObjectType != FObjectType.Equipment &&
                    fBaseObject.fObjectType != FObjectType.ScenarioGroup &&
                    fBaseObject.fObjectType != FObjectType.Scenario
                    )
                {
                    return null;
                }

                // --

                fXmlNode = FPlcDriverCommon.getObjectXmlNode(fBaseObject);

                // --                

                if (fXmlNode.name == FXmlTagPCD.E_PlcDriver)
                {
                    fXmlNode = fXmlNode.selectSingleNode(FXmlTagEQM.E_EquipmentModeling + "/" + FXmlTagEQP.E_Equipment);
                    if (FSearchNode.contains(fXmlNode.get_attrVal(FXmlTagEQP.A_Name, FXmlTagEQP.D_Name), searchWord))
                    {
                        fObject = FPlcDriverCommon.createObject(this.fPcdCore, fXmlNode);
                        // --
                        return fObject;
                    }
                }

                // --                

                fXmlNode = searchEquipmentNode(fXmlNode, searchWord);
                if (fXmlNode == null)
                {
                    return null;
                }

                fObject = FPlcDriverCommon.createObject(this.fPcdCore, fXmlNode);

                return fObject;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                FSearchNode.resetResource();
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private FXmlNode searchEquipmentNode(
            FXmlNode fXmlNodeBase,
            string searchWord
            )
        {
            FXmlNode fXmlNodeRoot = null;
            FXmlNode fXmlNodeStart = null;

            try
            {
                fXmlNodeRoot = this.fXmlNode.selectSingleNode(FXmlTagEQM.E_EquipmentModeling);

                // -- 

                if (
                    (fXmlNodeBase.fFirstChild != null) &&
                    (fXmlNodeBase.name != FXmlTagSNR.E_Scenario)
                    )
                {
                    fXmlNodeStart = fXmlNodeBase.fFirstChild;
                }
                else if (fXmlNodeBase.fNextSibling != null)
                {
                    fXmlNodeStart = fXmlNodeBase.fNextSibling;
                }
                else
                {
                    fXmlNodeStart = FSearchNode.getNextNode(fXmlNodeBase, fXmlNodeRoot);

                    if (fXmlNodeStart.fPreviousSibling == fXmlNodeRoot)
                    {
                        fXmlNodeStart = fXmlNodeRoot;
                    }
                }

                return FSearchNode.searchEquipmentNode(fXmlNodeStart, fXmlNodeBase, fXmlNodeRoot, searchWord);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                FSearchNode.resetResource();
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIObject searchDataConversionSeries(
            FIObject fBaseObject,
            string searchWord
            )
        {
            FXmlNode fXmlNode = null;
            FXmlNode fXmlNodeDcl = null;

            try
            {
                // ***
                // DataConversion Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.PlcDriver &&
                    fBaseObject.fObjectType != FObjectType.DataConversionSetList &&
                    fBaseObject.fObjectType != FObjectType.DataConversionSet &&
                    fBaseObject.fObjectType != FObjectType.DataConversion
                    )
                {
                    return null;
                }

                // --

                fXmlNode = FPlcDriverCommon.getObjectXmlNode(fBaseObject);

                // --

                if (fXmlNode.name == FXmlTagPCD.E_PlcDriver)
                {
                    fXmlNodeDcl = fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagDCD.E_DataConversionSetDefinition + "/" + FXmlTagDCL.E_DataConversionSetList);

                    // -- 

                    if (fXmlNodeDcl == null)
                    {
                        if (FSearchNode.contains(fXmlNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord))
                        {
                            return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNode);
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else if (FSearchNode.contains(fXmlNodeDcl.get_attrVal(FXmlTagDCL.A_Name, FXmlTagDCL.D_Name), searchWord))
                    {
                        return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNodeDcl);
                    }

                    // --

                    fXmlNode = fXmlNodeDcl;
                }

                // --

                fXmlNode = searchDataConversionNode(fXmlNode, searchWord);
                if (fXmlNode == null)
                {
                    return null;
                }

                return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNode);
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

        private FXmlNode searchDataConversionNode(
            FXmlNode fXmlNodeBase,
            string searchWord
            )
        {
            FXmlNode fXmlNodeRoot = null;
            FXmlNode fXmlNodeStart = null;

            try
            {
                fXmlNodeRoot = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagDCD.E_DataConversionSetDefinition);

                // -- 

                if (fXmlNodeBase.fFirstChild != null)
                {
                    fXmlNodeStart = fXmlNodeBase.fFirstChild;
                }
                else if (fXmlNodeBase.fNextSibling != null)
                {
                    fXmlNodeStart = fXmlNodeBase.fNextSibling;
                }
                else
                {
                    fXmlNodeStart = FSearchNode.getNextNode(fXmlNodeBase, fXmlNodeRoot);

                    if (fXmlNodeStart.fPreviousSibling == fXmlNodeRoot)
                    {
                        fXmlNodeStart = fXmlNodeRoot;
                    }
                    else if (
                       fXmlNodeStart.name == FXmlTagDCD.E_DataConversionSetDefinition &&
                       FSearchNode.contains(fXmlNodeStart.fParentNode.fParentNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord)
                       )
                    {
                        // ***
                        // fParentNode 두번쓴 이유는 Definition은 Set이라는 테그가 하나 더 있기 때문
                        // ***
                        return fXmlNodeRoot.fParentNode.fParentNode;
                    }
                }

                return FSearchNode.searchDataConversionNode(fXmlNodeStart, fXmlNodeBase, fXmlNodeRoot, searchWord);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                FSearchNode.resetResource();
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIObject searchObjectNameSeries(
           FIObject fBaseObject,
           string searchWord
           )
        {
            FXmlNode fXmlNode = null;
            FXmlNode fXmlNodeOnl = null;

            try
            {
                // ***
                // Object Name Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.PlcDriver &&
                    fBaseObject.fObjectType != FObjectType.ObjectNameList &&
                    fBaseObject.fObjectType != FObjectType.ObjectName
                    )
                {
                    return null;
                }

                // --

                fXmlNode = FPlcDriverCommon.getObjectXmlNode(fBaseObject);

                // --

                if (fXmlNode.name == FXmlTagPCD.E_PlcDriver)
                {
                    fXmlNodeOnl = fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagOND.E_ObjectNameDefinition + "/" + FXmlTagONL.E_ObjectNameList);

                    // -- 

                    if (fXmlNodeOnl == null)
                    {
                        if (FSearchNode.contains(fXmlNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord))
                        {
                            return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNode);
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else if (FSearchNode.contains(fXmlNodeOnl.get_attrVal(FXmlTagONL.A_Name, FXmlTagONL.D_Name), searchWord))
                    {
                        return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNodeOnl);
                    }

                    // --

                    fXmlNode = fXmlNodeOnl;
                }

                // --

                fXmlNode = searchObjectNameNode(fXmlNode, searchWord);
                if (fXmlNode == null)
                {
                    return null;
                }

                return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNode);
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

        private FXmlNode searchObjectNameNode(
            FXmlNode fXmlNodeBase,
            string searchWord
            )
        {
            FXmlNode fXmlNodeRoot = null;
            FXmlNode fXmlNodeStart = null;

            try
            {
                fXmlNodeRoot = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagOND.E_ObjectNameDefinition);

                // --

                if (fXmlNodeBase.fFirstChild != null)
                {
                    fXmlNodeStart = fXmlNodeBase.fFirstChild;
                }
                else if (fXmlNodeBase.fNextSibling != null)
                {
                    fXmlNodeStart = fXmlNodeBase.fNextSibling;
                }
                else
                {
                    fXmlNodeStart = FSearchNode.getNextNode(fXmlNodeBase, fXmlNodeRoot);

                    if (fXmlNodeStart.fPreviousSibling == fXmlNodeRoot)
                    {
                        fXmlNodeStart = fXmlNodeRoot;
                    }
                    else if (
                        fXmlNodeStart.name == FXmlTagOND.E_ObjectNameDefinition &&
                        FSearchNode.contains(fXmlNodeStart.fParentNode.fParentNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord)
                        )
                    {
                        // ***
                        // fParentNode 두번쓴 이유는 Definition은 Set이라는 테그가 하나 더 있기 때문
                        // ***
                        return fXmlNodeRoot.fParentNode.fParentNode;
                    }
                }

                // --

                return FSearchNode.searchObjectNameNode(fXmlNodeStart, fXmlNodeBase, fXmlNodeRoot, searchWord);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                FSearchNode.resetResource();
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIObject searchFunctionNameSeries(
           FIObject fBaseObject,
           string searchWord
           )
        {
            FXmlNode fXmlNode = null;
            FXmlNode fXmlNodeFnl = null;

            try
            {
                // ***
                // Function Name Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.PlcDriver &&
                    fBaseObject.fObjectType != FObjectType.FunctionNameList &&
                    fBaseObject.fObjectType != FObjectType.FunctionName &&
                    fBaseObject.fObjectType != FObjectType.ParameterName &&
                    fBaseObject.fObjectType != FObjectType.Argument
                    )
                {
                    return null;
                }

                // --

                fXmlNode = FPlcDriverCommon.getObjectXmlNode(fBaseObject);

                // --

                if (fXmlNode.name == FXmlTagPCD.E_PlcDriver)
                {
                    fXmlNodeFnl = fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagFND.E_FunctionNameDefinition + "/" + FXmlTagFNL.E_FunctionNameList);

                    // -- 

                    if (fXmlNodeFnl == null)
                    {
                        if (FSearchNode.contains(fXmlNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord))
                        {
                            return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNode);
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else if (FSearchNode.contains(fXmlNodeFnl.get_attrVal(FXmlTagFNL.A_Name, FXmlTagFNL.D_Name), searchWord))
                    {
                        return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNodeFnl);
                    }

                    // --

                    fXmlNode = fXmlNodeFnl;
                }

                // --

                fXmlNode = searchFunctionNameNode(fXmlNode, searchWord);
                if (fXmlNode == null)
                {
                    return null;
                }

                return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNode);
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

        private FXmlNode searchFunctionNameNode(
            FXmlNode fXmlNodeBase,
            string searchWord
            )
        {
            FXmlNode fXmlNodeRoot = null;
            FXmlNode fXmlNodeStart = null;

            try
            {
                fXmlNodeRoot = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagFND.E_FunctionNameDefinition);

                // --

                if (fXmlNodeBase.fFirstChild != null)
                {
                    fXmlNodeStart = fXmlNodeBase.fFirstChild;
                }
                else if (fXmlNodeBase.fNextSibling != null)
                {
                    fXmlNodeStart = fXmlNodeBase.fNextSibling;
                }
                else
                {
                    fXmlNodeStart = FSearchNode.getNextNode(fXmlNodeBase, fXmlNodeRoot);

                    if (fXmlNodeStart.fPreviousSibling == fXmlNodeRoot)
                    {
                        fXmlNodeStart = fXmlNodeRoot;
                    }
                    else if (
                        fXmlNodeStart.name == FXmlTagFND.E_FunctionNameDefinition &&
                        FSearchNode.contains(fXmlNodeStart.fParentNode.fParentNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord)
                        )
                    {
                        // ***
                        // fParentNode 두번쓴 이유는 Definition은 Set이라는 테그가 하나 더 있기 때문
                        // ***
                        return fXmlNodeRoot.fParentNode.fParentNode;
                    }
                }

                // --

                return FSearchNode.searchFunctionNameNode(fXmlNodeStart, fXmlNodeBase, fXmlNodeRoot, searchWord);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                FSearchNode.resetResource();
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIObject searchRepositorySeries(
           FIObject fBaseObject,
           string searchWord
           )
        {
            FXmlNode fXmlNode = null;
            FXmlNode fXmlNodeRpl = null;

            try
            {
                // ***
                // Repository Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.PlcDriver &&
                    fBaseObject.fObjectType != FObjectType.RepositoryList &&
                    fBaseObject.fObjectType != FObjectType.Repository &&
                    fBaseObject.fObjectType != FObjectType.Column
                    )
                {
                    return null;
                }

                // --

                fXmlNode = FPlcDriverCommon.getObjectXmlNode(fBaseObject);

                // --

                if (fXmlNode.name == FXmlTagPCD.E_PlcDriver)
                {
                    fXmlNodeRpl = fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagRPD.E_RepositoryDefinition + "/" + FXmlTagRPL.E_RepositoryList);

                    // -- 

                    if (fXmlNodeRpl == null)
                    {
                        if (FSearchNode.contains(fXmlNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord))
                        {
                            return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNode);
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else if (FSearchNode.contains(fXmlNodeRpl.get_attrVal(FXmlTagRPL.A_Name, FXmlTagRPL.D_Name), searchWord))
                    {
                        return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNodeRpl);
                    }

                    // --

                    fXmlNode = fXmlNodeRpl;
                }

                // --

                fXmlNode = searchRepositoryNode(fXmlNode, searchWord);
                if (fXmlNode == null)
                {
                    return null;
                }

                return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNode);
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

        private FXmlNode searchRepositoryNode(
            FXmlNode fXmlNodeBase,
            string searchWord
            )
        {
            FXmlNode fXmlNodeRoot = null;
            FXmlNode fXmlNodeStart = null;

            try
            {
                fXmlNodeRoot = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagRPD.E_RepositoryDefinition);

                // --

                if (fXmlNodeBase.fFirstChild != null)
                {
                    fXmlNodeStart = fXmlNodeBase.fFirstChild;
                }
                else if (fXmlNodeBase.fNextSibling != null)
                {
                    fXmlNodeStart = fXmlNodeBase.fNextSibling;
                }
                else
                {
                    fXmlNodeStart = FSearchNode.getNextNode(fXmlNodeBase, fXmlNodeRoot);

                    if (fXmlNodeStart.fPreviousSibling == fXmlNodeRoot)
                    {
                        fXmlNodeStart = fXmlNodeRoot;
                    }
                    else if (
                        fXmlNodeStart.name == FXmlTagRPD.E_RepositoryDefinition &&
                        FSearchNode.contains(fXmlNodeStart.fParentNode.fParentNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord)
                        )
                    {
                        // ***
                        // fParentNode 두번쓴 이유는 Definition은 Set이라는 테그가 하나 더 있기 때문
                        // ***
                        return fXmlNodeRoot.fParentNode.fParentNode;
                    }
                }

                // --

                return FSearchNode.searchRepositoryNode(fXmlNodeStart, fXmlNodeBase, fXmlNodeRoot, searchWord);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                FSearchNode.resetResource();
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIObject searchEquipmentStateSetSeries(
           FIObject fBaseObject,
           string searchWord
           )
        {
            FXmlNode fXmlNode = null;
            FXmlNode fXmlNodeEsl = null;

            try
            {
                // ***
                // EquipmentStateSet Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.PlcDriver &&
                    fBaseObject.fObjectType != FObjectType.EquipmentStateSetList &&
                    fBaseObject.fObjectType != FObjectType.EquipmentStateSet &&
                    fBaseObject.fObjectType != FObjectType.EquipmentState &&
                    fBaseObject.fObjectType != FObjectType.StateValue
                    )
                {
                    return null;
                }

                // --

                fXmlNode = FPlcDriverCommon.getObjectXmlNode(fBaseObject);

                // --

                if (fXmlNode.name == FXmlTagPCD.E_PlcDriver)
                {
                    fXmlNodeEsl = fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagESD.E_EquipmentStateSetDefinition + "/" + FXmlTagESL.E_EquipmentStateSetList);

                    // -- 

                    if (fXmlNodeEsl == null)
                    {
                        if (FSearchNode.contains(fXmlNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord))
                        {
                            return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNode);
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else if (FSearchNode.contains(fXmlNodeEsl.get_attrVal(FXmlTagESL.A_Name, FXmlTagESL.D_Name), searchWord))
                    {
                        return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNodeEsl);
                    }

                    // --

                    fXmlNode = fXmlNodeEsl;
                }

                // --

                fXmlNode = searchEquipmentStateSetNode(fXmlNode, searchWord);
                if (fXmlNode == null)
                {
                    return null;
                }

                return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNode);
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

        private FXmlNode searchEquipmentStateSetNode(
            FXmlNode fXmlNodeBase,
            string searchWord
            )
        {
            FXmlNode fXmlNodeRoot = null;
            FXmlNode fXmlNodeStart = null;

            try
            {
                fXmlNodeRoot = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagESD.E_EquipmentStateSetDefinition);

                // --

                if (fXmlNodeBase.fFirstChild != null)
                {
                    fXmlNodeStart = fXmlNodeBase.fFirstChild;
                }
                else if (fXmlNodeBase.fNextSibling != null)
                {
                    fXmlNodeStart = fXmlNodeBase.fNextSibling;
                }
                else
                {
                    fXmlNodeStart = FSearchNode.getNextNode(fXmlNodeBase, fXmlNodeRoot);

                    if (fXmlNodeStart.fPreviousSibling == fXmlNodeRoot)
                    {
                        fXmlNodeStart = fXmlNodeRoot;
                    }
                    else if (
                        fXmlNodeStart.name == FXmlTagESD.E_EquipmentStateSetDefinition &&
                        FSearchNode.contains(fXmlNodeStart.fParentNode.fParentNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord)
                        )
                    {
                        // ***
                        // fParentNode 두번쓴 이유는 Definition은 Set이라는 테그가 하나 더 있기 때문
                        // ***
                        return fXmlNodeRoot.fParentNode.fParentNode;
                    }
                }

                // --

                return FSearchNode.searchEquipmentStateSetNode(fXmlNodeStart, fXmlNodeBase, fXmlNodeRoot, searchWord);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                FSearchNode.resetResource();
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIObject searchEnvironmentSeries(
           FIObject fBaseObject,
           string searchWord
           )
        {
            FXmlNode fXmlNode = null;
            FXmlNode fXmlNodeEnl = null;

            try
            {
                // ***
                // Environment Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.PlcDriver &&
                    fBaseObject.fObjectType != FObjectType.EnvironmentList &&
                    fBaseObject.fObjectType != FObjectType.Environment
                    )
                {
                    return null;
                }

                // --

                fXmlNode = FPlcDriverCommon.getObjectXmlNode(fBaseObject);

                // --

                if (fXmlNode.name == FXmlTagPCD.E_PlcDriver)
                {
                    fXmlNodeEnl = fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagEND.E_EnvironmentDefinition + "/" + FXmlTagENL.E_EnvironmentList);

                    // -- 

                    if (fXmlNodeEnl == null)
                    {
                        if (FSearchNode.contains(fXmlNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord))
                        {
                            return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNode);
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else if (FSearchNode.contains(fXmlNodeEnl.get_attrVal(FXmlTagENL.A_Name, FXmlTagENL.D_Name), searchWord))
                    {
                        return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNodeEnl);
                    }

                    // --

                    fXmlNode = fXmlNodeEnl;
                }

                // --

                fXmlNode = searchEnvironmentNode(fXmlNode, searchWord);
                if (fXmlNode == null)
                {
                    return null;
                }

                return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNode);
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

        private FXmlNode searchEnvironmentNode(
            FXmlNode fXmlNodeBase,
            string searchWord
            )
        {
            FXmlNode fXmlNodeRoot = null;
            FXmlNode fXmlNodeStart = null;

            try
            {
                fXmlNodeRoot = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagEND.E_EnvironmentDefinition);

                // --

                if (fXmlNodeBase.fFirstChild != null)
                {
                    fXmlNodeStart = fXmlNodeBase.fFirstChild;
                }
                else if (fXmlNodeBase.fNextSibling != null)
                {
                    fXmlNodeStart = fXmlNodeBase.fNextSibling;
                }
                else
                {
                    fXmlNodeStart = FSearchNode.getNextNode(fXmlNodeBase, fXmlNodeRoot);

                    if (fXmlNodeStart.fPreviousSibling == fXmlNodeRoot)
                    {
                        fXmlNodeStart = fXmlNodeRoot;
                    }
                    else if (
                        fXmlNodeStart.name == FXmlTagEND.E_EnvironmentDefinition &&
                        FSearchNode.contains(fXmlNodeStart.fParentNode.fParentNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord)
                        )
                    {
                        // ***
                        // fParentNode 두번쓴 이유는 Definition은 Set이라는 테그가 하나 더 있기 때문
                        // ***
                        return fXmlNodeRoot.fParentNode.fParentNode;
                    }
                }

                // --

                return FSearchNode.searchEnvironmentNode(fXmlNodeStart, fXmlNodeBase, fXmlNodeRoot, searchWord);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                FSearchNode.resetResource();
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIObject searchDataSetSeries(
           FIObject fBaseObject,
           string searchWord
           )
        {
            FXmlNode fXmlNode = null;
            FXmlNode fXmlNodeDsl = null;

            try
            {
                // ***
                // Data Set Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.PlcDriver &&
                    fBaseObject.fObjectType != FObjectType.DataSetList &&
                    fBaseObject.fObjectType != FObjectType.DataSet &&
                    fBaseObject.fObjectType != FObjectType.Data
                    )
                {
                    return null;
                }

                // --

                fXmlNode = FPlcDriverCommon.getObjectXmlNode(fBaseObject);

                // --

                if (fXmlNode.name == FXmlTagPCD.E_PlcDriver)
                {
                    fXmlNodeDsl = fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagDSD.E_DataSetDefinition + "/" + FXmlTagDSL.E_DataSetList);

                    // -- 

                    if (fXmlNodeDsl == null)
                    {
                        if (FSearchNode.contains(fXmlNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord))
                        {
                            return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNode);
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else if (FSearchNode.contains(fXmlNodeDsl.get_attrVal(FXmlTagDSL.A_Name, FXmlTagDSL.D_Name), searchWord))
                    {
                        return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNodeDsl);
                    }

                    // --

                    fXmlNode = fXmlNodeDsl;
                }

                // --

                fXmlNode = searchDataSetNode(fXmlNode, searchWord);
                if (fXmlNode == null)
                {
                    return null;
                }

                return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNode);
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

        private FXmlNode searchDataSetNode(
            FXmlNode fXmlNodeBase,
            string searchWord
            )
        {
            FXmlNode fXmlNodeRoot = null;
            FXmlNode fXmlNodeStart = null;

            try
            {
                fXmlNodeRoot = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagDSD.E_DataSetDefinition);

                // --

                if (fXmlNodeBase.fFirstChild != null)
                {
                    fXmlNodeStart = fXmlNodeBase.fFirstChild;
                }
                else if (fXmlNodeBase.fNextSibling != null)
                {
                    fXmlNodeStart = fXmlNodeBase.fNextSibling;
                }
                else
                {
                    fXmlNodeStart = FSearchNode.getNextNode(fXmlNodeBase, fXmlNodeRoot);

                    if (fXmlNodeStart.fPreviousSibling == fXmlNodeRoot)
                    {
                        fXmlNodeStart = fXmlNodeRoot;
                    }
                    else if (
                        fXmlNodeStart.name == FXmlTagDSD.E_DataSetDefinition &&
                        FSearchNode.contains(fXmlNodeStart.fParentNode.fParentNode.get_attrVal(FXmlTagPCD.A_Name, FXmlTagPCD.D_Name), searchWord)
                        )
                    {
                        // ***
                        // fParentNode 두번쓴 이유는 Definition은 Set이라는 테그가 하나 더 있기 때문
                        // ***
                        return fXmlNodeRoot.fParentNode.fParentNode;
                    }
                }

                // --

                return FSearchNode.searchDataSetNode(fXmlNodeStart, fXmlNodeBase, fXmlNodeRoot, searchWord);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                FSearchNode.resetResource();
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIObject searchScenarioSeries(
           FIObject fBaseObject,
           FIObject fScenarioObject,
           string searchWord
           )
        {
            FXmlNode fXmlNode = null;
            FXmlNode fXmlNodeSnr = null;

            try
            {
                // ***
                // Scenario Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.Scenario &&
                    fBaseObject.fObjectType != FObjectType.PlcTrigger &&
                    fBaseObject.fObjectType != FObjectType.PlcCondition &&
                    fBaseObject.fObjectType != FObjectType.PlcExpression &&
                    fBaseObject.fObjectType != FObjectType.PlcTransmitter &&
                    fBaseObject.fObjectType != FObjectType.PlcTransfer &&
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

                // --

                fXmlNode = FPlcDriverCommon.getObjectXmlNode(fBaseObject);
                fXmlNodeSnr = FPlcDriverCommon.getObjectXmlNode(fScenarioObject);

                // --

                fXmlNode = searchScenarioNode(fXmlNode, fXmlNodeSnr, searchWord);
                if (fXmlNode == null)
                {
                    return null;
                }

                return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNode);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
                fXmlNodeSnr = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private FXmlNode searchScenarioNode(
            FXmlNode fXmlNodeBase,
            FXmlNode fXmlNodeRoot,
            string searchWord
            )
        {
            FXmlNode fXmlNodeStart = null;

            try
            {
                if (fXmlNodeBase.name == FXmlTagSNR.E_Scenario)
                {
                    if (fXmlNodeBase.fFirstChild == null)
                    {
                        return null;
                    }
                    fXmlNodeStart = fXmlNodeBase.fFirstChild;
                }
                else
                {
                    if (fXmlNodeBase.fFirstChild != null)
                    {
                        fXmlNodeStart = fXmlNodeBase.fFirstChild;
                    }
                    else if (fXmlNodeBase.fNextSibling != null)
                    {
                        fXmlNodeStart = fXmlNodeBase.fNextSibling;
                    }
                    else
                    {
                        fXmlNodeStart = FSearchNode.getNextNode(fXmlNodeBase, fXmlNodeRoot);

                        if (fXmlNodeStart.fPreviousSibling == fXmlNodeRoot)
                        {
                            fXmlNodeStart = fXmlNodeRoot;
                        }
                        else if (fXmlNodeStart.name == FXmlTagSNR.E_Scenario)
                        {
                            fXmlNodeStart = fXmlNodeStart.fFirstChild;
                        }
                    }
                }

                // --

                return FSearchNode.searchScenarioNode(fXmlNodeStart, fXmlNodeBase, fXmlNodeRoot, searchWord);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                FSearchNode.resetResource();
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

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeOnd.appendChild(fNewChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FPlcDriverCommon.validateRefChildObject(fXmlNodeOnd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeOnd.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FPlcDriverCommon.validateRefChildObject(fXmlNodeOnd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeOnd.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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
                FPlcDriverCommon.validateRemoveChildObject(fXmlNodeOnd, fChild.fXmlNode);

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
                    FPlcDriverCommon.validateRemoveChildObject(fXmlNodeOnd, fOnl.fXmlNode);
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

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeFnd.appendChild(fNewChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FPlcDriverCommon.validateRefChildObject(fXmlNodeFnd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeFnd.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FPlcDriverCommon.validateRefChildObject(fXmlNodeFnd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeFnd.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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
                FPlcDriverCommon.validateRemoveChildObject(fXmlNodeFnd, fChild.fXmlNode);

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
                    FPlcDriverCommon.validateRemoveChildObject(fXmlNodeFnd, fFnl.fXmlNode);
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

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeDcd.appendChild(fNewChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FPlcDriverCommon.validateRefChildObject(fXmlNodeEsd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeEsd.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FPlcDriverCommon.validateRefChildObject(fXmlNodeEsd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeEsd.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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
                FPlcDriverCommon.validateRemoveChildObject(fXmlNodeDcd, fChild.fXmlNode);

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
                    FPlcDriverCommon.validateRemoveChildObject(fXmlNodeDcd, fDcl.fXmlNode);
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

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeEsd.appendChild(fNewChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FPlcDriverCommon.validateRefChildObject(fXmlNodeEsd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeEsd.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FPlcDriverCommon.validateRefChildObject(fXmlNodeEsd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeEsd.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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
                FPlcDriverCommon.validateRemoveChildObject(fXmlNodeEsd, fChild.fXmlNode);

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
                    FPlcDriverCommon.validateRemoveChildObject(fXmlNodeEsd, fEsl.fXmlNode);
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

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeRpd.appendChild(fNewChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FPlcDriverCommon.validateRefChildObject(fXmlNodeRpd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeRpd.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FPlcDriverCommon.validateRefChildObject(fXmlNodeRpd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeRpd.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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
                FPlcDriverCommon.validateRemoveChildObject(fXmlNodeRpd, fChild.fXmlNode);

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
                    FPlcDriverCommon.validateRemoveChildObject(fXmlNodeRpd, fRpl.fXmlNode);
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
                FPlcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.ObjectNameList);

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
                FPlcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.FunctionNameList);

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
                FPlcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.DataConversionSetList);

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
                FPlcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.EquipmentStateSetList);

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
                FPlcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.RepositoryList);

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
                FPlcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.EnvironmentList);

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
                FPlcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.DataSetList);

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

        public FPlcLibraryGroup pasteChildPlcLibraryGroup(
            )
        {
            FPlcLibraryGroup fPlcLibraryGroup = null;

            try
            {
                FPlcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.PlcLibraryGroup);

                // -- 

                fPlcLibraryGroup = (FPlcLibraryGroup)this.pasteObject(FCbObjectFormat.PlcLibraryGroup);
                this.appendChildPlcLibraryGroup(fPlcLibraryGroup);

                // --

                return fPlcLibraryGroup;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPlcLibraryGroup = null;
            }

            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPlcDevice pasteChildPlcDevice(
            )
        {
            FPlcDevice fPlcDevice = null;

            try
            {
                FPlcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.PlcDevice);

                // -- 

                fPlcDevice = (FPlcDevice)this.pasteObject(FCbObjectFormat.PlcDevice);
                // --
                fPlcDevice.changeState(FDeviceState.Closed);
                // --
                foreach (FPlcSession fPsn in fPlcDevice.fChildPlcSessionCollection)
                {
                    fPsn.fXmlNode.set_attrVal(FXmlTagPSN.A_PlcLibraryId, FXmlTagPSN.D_PlcLibraryId, "");
                }
                this.appendChildPlcDevice(fPlcDevice);

                // --

                return fPlcDevice;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPlcDevice = null;
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

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeEnd.appendChild(fNewChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FPlcDriverCommon.validateRefChildObject(fXmlNodeEnd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeEnd.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FPlcDriverCommon.validateRefChildObject(fXmlNodeEnd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeEnd.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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
                FPlcDriverCommon.validateRemoveChildObject(fXmlNodeEnd, fChild.fXmlNode);

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
                    FPlcDriverCommon.validateRemoveChildObject(fXmlNodeEnd, fEnl.fXmlNode);
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

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeDsd.appendChild(fNewChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FPlcDriverCommon.validateRefChildObject(fXmlNodeDsd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeDsd.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FPlcDriverCommon.validateRefChildObject(fXmlNodeDsd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeDsd.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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
                FPlcDriverCommon.validateRemoveChildObject(fXmlNodeRpd, fChild.fXmlNode);

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
                    FPlcDriverCommon.validateRemoveChildObject(fXmlNodeDsd, fDsl.fXmlNode);
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

        public FPlcLibraryGroup appendChildPlcLibraryGroup(
            FPlcLibraryGroup fNewChild
            )
        {
            FXmlNode fXmlNodePlm = null;

            try
            {
                fXmlNodePlm = this.fXmlNode.selectSingleNode(FXmlTagPLM.E_PlcLibraryModeling);

                // --

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodePlm.appendChild(fNewChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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

        public FPlcLibraryGroup insertBeforeChildPlcLibraryGroup(
            FPlcLibraryGroup fNewChild,
            FPlcLibraryGroup fRefChild
            )
        {
            FXmlNode fXmlNodePlm = null;

            try
            {
                fXmlNodePlm = this.fXmlNode.selectSingleNode(FXmlTagPLM.E_PlcLibraryModeling);

                // --

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FPlcDriverCommon.validateRefChildObject(fXmlNodePlm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodePlm.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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

        public FPlcLibraryGroup insertAfterChildPlcLibraryGroup(
            FPlcLibraryGroup fNewChild,
            FPlcLibraryGroup fRefChild
            )
        {
            FXmlNode fXmlNodePlm = null;

            try
            {
                fXmlNodePlm = this.fXmlNode.selectSingleNode(FXmlTagPLM.E_PlcLibraryModeling);

                // --

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FPlcDriverCommon.validateRefChildObject(fXmlNodePlm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodePlm.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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

        public FPlcLibraryGroup removeChildPlcLibraryGroup(
            FPlcLibraryGroup fChild
            )
        {
            FXmlNode fXmlNodePlm = null;

            try
            {
                fXmlNodePlm = this.fXmlNode.selectSingleNode(FXmlTagPLM.E_PlcLibraryModeling);
                FPlcDriverCommon.validateRemoveChildObject(fXmlNodePlm, fChild.fXmlNode);

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

        public void removeChildPlcLibraryGroup(
            FPlcLibraryGroup[] fChilds
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

                fXmlNodePlm = this.fXmlNode.selectSingleNode(FXmlTagPLM.E_PlcLibraryModeling);
                foreach (FPlcLibraryGroup fSlg in fChilds)
                {
                    FPlcDriverCommon.validateRemoveChildObject(fXmlNodePlm, fSlg.fXmlNode);
                }

                // --

                foreach (FPlcLibraryGroup fSlg in fChilds)
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

        public void removeAllChildPlcLibraryGroup(
            )
        {
            FPlcLibraryGroupCollection fPlgCollection = null;

            try
            {
                fPlgCollection = this.fChildPlcLibraryGroupCollection;
                if (fPlgCollection.count == 0)
                {
                    return;
                }

                // --

                foreach (FPlcLibraryGroup fPlg in fPlgCollection)
                {
                    if (fPlg.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }
                }

                // --

                foreach (FPlcLibraryGroup fPlg in fPlgCollection)
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
                if (fPlgCollection != null)
                {
                    fPlgCollection.Dispose();
                    fPlgCollection = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPlcDevice appendChildPlcDevice(
            FPlcDevice fNewChild
            )
        {
            FXmlNode fXmlNodeSdm = null;

            try
            {
                fXmlNodeSdm = this.fXmlNode.selectSingleNode(FXmlTagPDM.E_PlcDeviceModeling);

                // --

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeSdm.appendChild(fNewChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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

        public FPlcDevice insertBeforeChildPlcDevice(
           FPlcDevice fNewChild,
           FPlcDevice fRefChild
           )
        {
            FXmlNode fXmlNodeSdm = null;

            try
            {
                fXmlNodeSdm = this.fXmlNode.selectSingleNode(FXmlTagPDM.E_PlcDeviceModeling);

                // --

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FPlcDriverCommon.validateRefChildObject(fXmlNodeSdm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeSdm.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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

        public FPlcDevice insertAfterChildPlcDevice(
           FPlcDevice fNewChild,
           FPlcDevice fRefChild
           )
        {
            FXmlNode fXmlNodeSdm = null;

            try
            {
                fXmlNodeSdm = this.fXmlNode.selectSingleNode(FXmlTagPDM.E_PlcDeviceModeling);

                // --

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FPlcDriverCommon.validateRefChildObject(fXmlNodeSdm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeSdm.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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

        public FPlcDevice removeChildPlcDevice(
            FPlcDevice fChild
            )
        {
            FXmlNode fXmlNodeSdm = null;

            try
            {
                fXmlNodeSdm = this.fXmlNode.selectSingleNode(FXmlTagPDM.E_PlcDeviceModeling);
                FPlcDriverCommon.validateRemoveChildObject(fXmlNodeSdm, fChild.fXmlNode);

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

        public void removeChildPlcDevice(
            FPlcDevice[] fChilds
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

                fXmlNodeSdm = this.fXmlNode.selectSingleNode(FXmlTagPDM.E_PlcDeviceModeling);
                foreach (FPlcDevice fSdv in fChilds)
                {
                    FPlcDriverCommon.validateRemoveChildObject(fXmlNodeSdm, fSdv.fXmlNode);
                    // --
                    if (fSdv.fState != FDeviceState.Closed)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0027, "Device"));
                    }
                }

                // --

                foreach (FPlcDevice fSdv in fChilds)
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

        public void removeAllChildPlcDevice(
            )
        {
            FPlcDeviceCollection fPdvCollection = null;

            try
            {
                fPdvCollection = this.fChildPlcDeviceCollection;
                if (fPdvCollection.count == 0)
                {
                    return;
                }

                // --

                foreach (FPlcDevice fSdv in fPdvCollection)
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

                foreach (FPlcDevice fSdv in fPdvCollection)
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
                if (fPdvCollection != null)
                {
                    fPdvCollection.Dispose();
                    fPdvCollection = null;
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

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeHlm.appendChild(fNewChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FPlcDriverCommon.validateRefChildObject(fXmlNodeHlm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeHlm.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FPlcDriverCommon.validateRefChildObject(fXmlNodeHlm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeHlm.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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
                FPlcDriverCommon.validateRemoveChildObject(fXmlNodeHlm, fChild.fXmlNode);

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
                    FPlcDriverCommon.validateRemoveChildObject(fXmlNodeHlm, fHlg.fXmlNode);
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

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeHdm.appendChild(fNewChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FPlcDriverCommon.validateRefChildObject(fXmlNodeHdm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeHdm.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FPlcDriverCommon.validateRefChildObject(fXmlNodeHdm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeHdm.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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
                FPlcDriverCommon.validateRemoveChildObject(fXmlNodeHdm, fChild.fXmlNode);

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
                    FPlcDriverCommon.validateRemoveChildObject(fXmlNodeHdm, fHdv.fXmlNode);
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

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeEqm.appendChild(fNewChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FPlcDriverCommon.validateRefChildObject(fXmlNodeEqm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeEqm.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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

                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FPlcDriverCommon.validateRefChildObject(fXmlNodeEqm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fPcdCore, fXmlNodeEqm.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fPcdCore.fEventPusher.pushEvent(
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
                FPlcDriverCommon.validateRemoveChildObject(fXmlNodeEqm, fChild.fXmlNode);

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
                    FPlcDriverCommon.validateRemoveChildObject(fXmlNodeEqm, fEqp.fXmlNode);
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

                fXmlNode = FPlcDriverCommon.getObjectXmlNode(fObject);
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
                    fObject.fObjectType == FObjectType.PlcLibraryGroup ||
                    fObject.fObjectType == FObjectType.PlcDevice ||
                    fObject.fObjectType == FObjectType.HostLibraryGroup ||
                    fObject.fObjectType == FObjectType.HostDevice ||
                    fObject.fObjectType == FObjectType.EquipmentStateSetList ||
                    fObject.fObjectType == FObjectType.Equipment
                    )
                {
                    return this;
                }

                // --

                return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNode.fParentNode);
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

                fXmlNode = FPlcDriverCommon.getObjectXmlNode(fObject);
                if (fXmlNode.fPreviousSibling == null)
                {
                    return null;
                }

                // --

                return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNode.fPreviousSibling);
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

                fXmlNode = FPlcDriverCommon.getObjectXmlNode(fObject);
                if (fXmlNode.fNextSibling == null)
                {
                    return null;
                }

                // --

                return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNode.fNextSibling);
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
                this.fPcdCore.fLogWriter.cutBinaryLogFile();
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
                this.fPcdCore.fLogWriter.cutVfeiLogFile();
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

        public void cutPlcLogFile(
            )
        {
            try
            {
                this.fPcdCore.fLogWriter.cutPlcLogFile();
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
                this.fPcdCore.fLogWriter.cutBinaryLogFile();
                this.fPcdCore.fLogWriter.cutVfeiLogFile();
                this.fPcdCore.fLogWriter.cutPlcLogFile();
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
                    return FPlcDriverCommon.createObject(this.fPcdCore, fXmlNode);
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
                    this.fPcdCore,
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
                return new FObjectNameList(this.fPcdCore, fXmlNode);
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
                return new FObjectNameList(this.fPcdCore, fXmlNode);
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
                    this.fPcdCore,
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
                return new FFunctionNameList(this.fPcdCore, fXmlNode);
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
                    this.fPcdCore,
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
                return new FUserTagName(this.fPcdCore, fXmlNode);
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
                return new FUserTagName(this.fPcdCore, fXmlNode);
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
                    this.fPcdCore,
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
                return new FDataConversionSetList(this.fPcdCore, fXmlNode);
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
                    this.fPcdCore,
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
                return new FEquipmentStateSetList(this.fPcdCore, fXmlNode);
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
                    this.fPcdCore,
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
                return new FRepositoryList(this.fPcdCore, fXmlNode);
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
                    this.fPcdCore,
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
                return new FDataSetList(this.fPcdCore, fXmlNode);
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
                    this.fPcdCore,
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
                return new FEnvironmentList(this.fPcdCore, fXmlNode);
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

        public FPlcLibraryGroupCollection selectPlcLibraryGroupByName(
            string name
            )
        {
            const string xpath = FXmlTagPLM.E_PlcLibraryModeling +
                "/" + FXmlTagPLG.E_PlcLibraryGroup + "[@" + FXmlTagPLG.A_Name + "='{0}']";

            try
            {
                return new FPlcLibraryGroupCollection(
                    this.fPcdCore,
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

        public FPlcLibraryGroup selectSinglePlcLibraryGroupByName(
            string name
            )
        {
            const string xpath = FXmlTagPLM.E_PlcLibraryModeling +
                "/" + FXmlTagPLG.E_PlcLibraryGroup + "[@" + FXmlTagPLG.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FPlcLibraryGroup(this.fPcdCore, fXmlNode);
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

        public FPlcDeviceCollection selectPlcDeviceByName(
            string name
            )
        {
            const string xpath =
                FXmlTagPDM.E_PlcDeviceModeling +
                "/" + FXmlTagPDV.E_PlcDevice + "[@" + FXmlTagPDV.A_Name + "='{0}']";

            try
            {
                return new FPlcDeviceCollection(
                    this.fPcdCore,
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

        public FPlcDevice selectSingleSecsDeviceByName(
            string name
            )
        {
            const string xpath =
                FXmlTagPDM.E_PlcDeviceModeling +
                "/" + FXmlTagPDV.E_PlcDevice + "[@" + FXmlTagPDV.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FPlcDevice(this.fPcdCore, fXmlNode);
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
                    this.fPcdCore,
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
                return new FHostLibraryGroup(this.fPcdCore, fXmlNode);
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
                    this.fPcdCore,
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
                return new FHostDevice(this.fPcdCore, fXmlNode);
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
                    this.fPcdCore,
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
                return new FEquipment(this.fPcdCore, fXmlNode);
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
                return new FEntryPoint(this.fPcdCore, fXmlNode);
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
                    this.fPcdCore,
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
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the PLC Driver and the Entry Point", "same"));
                }

                // --

                this.fPcdCore.fEventPusher.pushEntryPointCalledEvent(
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
                this.fPcdCore.openRepositoryMaterial();
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
                this.fPcdCore.saveRepositoryMaterial(rawData);
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
                this.fPcdCore.loadRepositoryMaterial(rawData);
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
                return this.fPcdCore.getRepositoryMaterialRawData();
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
                this.fPcdCore.removeRepositoryMaterialById(rpmIds);
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

        #region On PLC Driver Modeling Event

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

        #region On PLC Driver Communication Event

        internal void onPlcDeviceStateChanged(
            FEventArgsBase fArgsBase
            )
        {
            FPlcDeviceStateChangedEventArgs fArgs = null;

            try
            {
                fArgs = (FPlcDeviceStateChangedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FPlcDriverCommon.resetLocked(fArgs.fPlcDeviceStateChangedLog.fXmlNode);

                // --

                fArgs.fPlcDeviceStateChangedLog.fXmlNode.set_attrVal(FXmlTagPDVL.A_Time, FXmlTagPDVL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fPcdCore.fLogWriter.pushPlcLog(fArgs.fPlcDeviceStateChangedLog.fXmlNode);

                // --

                if (PlcDeviceStateChanged != null)
                {
                    PlcDeviceStateChanged(this, fArgs);
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

        internal void onPlcDeviceErrorRaised(
            FEventArgsBase fArgsBase
            )
        {
            FPlcDeviceErrorRaisedEventArgs fArgs = null;

            try
            {
                fArgs = (FPlcDeviceErrorRaisedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FPlcDriverCommon.resetLocked(fArgs.fPlcDeviceErrorRaisedLog.fXmlNode);

                // --

                fArgs.fPlcDeviceErrorRaisedLog.fXmlNode.set_attrVal(FXmlTagPDEL.A_Time, FXmlTagPDEL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fPcdCore.fLogWriter.pushPlcLog(fArgs.fPlcDeviceErrorRaisedLog.fXmlNode);

                // --

                if (PlcDeviceErrorRaised != null)
                {
                    PlcDeviceErrorRaised(this, fArgs);
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

        internal void onPlcDeviceTimeoutRaised(
            FEventArgsBase fArgsBase
            )
        {
            FPlcDeviceTimeoutRaisedEventArgs fArgs = null;

            try
            {
                fArgs = (FPlcDeviceTimeoutRaisedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FPlcDriverCommon.resetLocked(fArgs.fPlcDeviceTimeoutRaisedLog.fXmlNode);

                // --

                fArgs.fPlcDeviceTimeoutRaisedLog.fXmlNode.set_attrVal(FXmlTagPDTL.A_Time, FXmlTagPDTL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fPcdCore.fLogWriter.pushPlcLog(fArgs.fPlcDeviceTimeoutRaisedLog.fXmlNode);

                // --

                if (PlcDeviceTimeoutRaised != null)
                {
                    PlcDeviceTimeoutRaised(this, fArgs);
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

        internal void onPlcDeviceDataReceived(
            FEventArgsBase fArgsBase
            )
        {
            FPlcDeviceDataReceivedEventArgs fArgs = null;

            try
            {
                fArgs = (FPlcDeviceDataReceivedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FPlcDriverCommon.resetLocked(fArgs.fPlcDeviceDataReceivedLog.fXmlNode);

                // --
  
                fArgs.fPlcDeviceDataReceivedLog.fXmlNode.set_attrVal(FXmlTagPDVL.A_Time, FXmlTagPDVL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fPcdCore.fLogWriter.pushPlcLog(fArgs.fPlcDeviceDataReceivedLog.fXmlNode);

                // --

                if (PlcDeviceDataReceived != null)
                {
                    PlcDeviceDataReceived(this, fArgs);
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

        internal void onPlcDeviceDataSent(
            FEventArgsBase fArgsBase
            )
        {
            FPlcDeviceDataSentEventArgs fArgs = null;

            try
            {
                fArgs = (FPlcDeviceDataSentEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FPlcDriverCommon.resetLocked(fArgs.fPlcDeviceDataSentLog.fXmlNode);

                // --

                fArgs.fPlcDeviceDataSentLog.fXmlNode.set_attrVal(FXmlTagPDVL.A_Time, FXmlTagPDVL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fPcdCore.fLogWriter.pushPlcLog(fArgs.fPlcDeviceDataSentLog.fXmlNode);

                // --

                if (PlcDeviceDataSent != null)
                {
                    PlcDeviceDataSent(this, fArgs);
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

        internal void onPlcDeviceDataMessageRead(
            FEventArgsBase fArgsBase
            )
        {
            FPlcDeviceDataMessageReadEventArgs fArgs = null;

            try
            {
                fArgs = (FPlcDeviceDataMessageReadEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FPlcDriverCommon.resetLocked(fArgs.fPlcDeviceDataMessageReadLog.fXmlNode);

                // --
                
                fArgs.fPlcDeviceDataMessageReadLog.fXmlNode.set_attrVal(FXmlTagPMGL.A_Time, FXmlTagPMGL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fPlcDeviceDataMessageReadLog.logEnabled && confirmlogLevelEnabled(fArgs.fPlcDeviceDataMessageReadLog.logLevel))
                {
                    this.fPcdCore.fLogWriter.pushPlcLog(fArgs.fPlcDeviceDataMessageReadLog.fXmlNode);
                }

                // --

                if (PlcDeviceDataMessageRead != null)
                {
                    PlcDeviceDataMessageRead(this, fArgs);
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

        internal void onPlcDeviceDataMessageWritten(
            FEventArgsBase fArgsBase
            )
        {
            FPlcDeviceDataMessageWrittenEventArgs fArgs = null;

            try
            {
                fArgs = (FPlcDeviceDataMessageWrittenEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FPlcDriverCommon.resetLocked(fArgs.fPlcDeviceDataMessageWrittenLog.fXmlNode);

                // --

                fArgs.fPlcDeviceDataMessageWrittenLog.fXmlNode.set_attrVal(FXmlTagPMGL.A_Time, FXmlTagPMGL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fPlcDeviceDataMessageWrittenLog.logEnabled && confirmlogLevelEnabled(fArgs.fPlcDeviceDataMessageWrittenLog.logLevel))
                {
                    this.fPcdCore.fLogWriter.pushPlcLog(fArgs.fPlcDeviceDataMessageWrittenLog.fXmlNode);
                }

                // --

                if (PlcDeviceDataMessageWritten != null)
                {
                    PlcDeviceDataMessageWritten(this, fArgs);
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
                FPlcDriverCommon.resetLocked(fArgs.fHostDeviceStateChangedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Host Device State Changed Log Write
                // ***
                fArgs.fHostDeviceStateChangedLog.fXmlNode.set_attrVal(FXmlTagHDVL.A_Time, FXmlTagHDVL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fPcdCore.fLogWriter.pushPlcLog(fArgs.fHostDeviceStateChangedLog.fXmlNode);

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
                FPlcDriverCommon.resetLocked(fArgs.fHostDeviceErrorRaisedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Host Device Error Raised Log Write
                // ***
                fArgs.fHostDeviceErrorRaisedLog.fXmlNode.set_attrVal(FXmlTagHDEL.A_Time, FXmlTagHDEL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fPcdCore.fLogWriter.pushPlcLog(fArgs.fHostDeviceErrorRaisedLog.fXmlNode);

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
                FPlcDriverCommon.resetLocked(fArgs.fHostDeviceVfeiReceivedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Host Device VFEI Received Log Write
                // ***
                fArgs.fHostDeviceVfeiReceivedLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_Time, FXmlTagVFEL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fPcdCore.fLogWriter.pushPlcLog(fArgs.fHostDeviceVfeiReceivedLog.fXmlNode);

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
                FPlcDriverCommon.resetLocked(fArgs.fHostDeviceVfeiSentLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Host Device VFEI Sent Log Write
                // ***
                fArgs.fHostDeviceVfeiSentLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_Time, FXmlTagVFEL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fPcdCore.fLogWriter.pushPlcLog(fArgs.fHostDeviceVfeiSentLog.fXmlNode);

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
                FPlcDriverCommon.resetLocked(fArgs.fHostDeviceDataMessageReceivedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Host Device Data Message Received Log Write
                // ***
                fArgs.fHostDeviceDataMessageReceivedLog.fXmlNode.set_attrVal(FXmlTagHMGL.A_Time, FXmlTagHMGL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fHostDeviceDataMessageReceivedLog.logEnabled && confirmlogLevelEnabled(fArgs.fHostDeviceDataMessageReceivedLog.logLevel))
                {
                    // --
                    this.fPcdCore.fLogWriter.pushPlcLog(fArgs.fHostDeviceDataMessageReceivedLog.fXmlNode);
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
                FPlcDriverCommon.resetLocked(fArgs.fHostDeviceDataMessageSentLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Host Device Data Message Sent Log Write
                // ***
                fArgs.fHostDeviceDataMessageSentLog.fXmlNode.set_attrVal(FXmlTagHMGL.A_Time, FXmlTagHMGL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fHostDeviceDataMessageSentLog.logEnabled && confirmlogLevelEnabled(fArgs.fHostDeviceDataMessageSentLog.logLevel))
                {                    
                    this.fPcdCore.fLogWriter.pushPlcLog(fArgs.fHostDeviceDataMessageSentLog.fXmlNode);
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

        internal void onPlcTriggerRaised(
            FEventArgsBase fArgsBase
            )
        {
            FPlcTriggerRaisedEventArgs fArgs = null;

            try
            {
                fArgs = (FPlcTriggerRaisedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FPlcDriverCommon.resetLocked(fArgs.fPlcTriggerRaisedLog.fXmlNode);

                // --

                // ***
                // PLC Trigger Raised Log Write
                // ***
                fArgs.fPlcTriggerRaisedLog.fXmlNode.set_attrVal(FXmlTagPTRL.A_Time, FXmlTagPTRL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    this.fPcdCore.fLogWriter.pushPlcLog(fArgs.fPlcTriggerRaisedLog.fXmlNode);
                }

                // --

                if (PlcTriggerRaised != null)
                {
                    PlcTriggerRaised(this, fArgs);
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

        internal void onPlcTransmitterRaised(
            FEventArgsBase fArgsBase
            )
        {
            FPlcTransmitterRaisedEventArgs fArgs = null;

            try
            {
                fArgs = (FPlcTransmitterRaisedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FPlcDriverCommon.resetLocked(fArgs.fPlcTransmitterRaisedLog.fXmlNode);

                // --

                // ***
                // PLC Transmitter Raised Log Write
                // ***
                fArgs.fPlcTransmitterRaisedLog.fXmlNode.set_attrVal(FXmlTagPTNL.A_Time, FXmlTagPTNL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    this.fPcdCore.fLogWriter.pushPlcLog(fArgs.fPlcTransmitterRaisedLog.fXmlNode);
                }

                // --

                if (PlcTransmitterRaised != null)
                {
                    PlcTransmitterRaised(this, fArgs);
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
                FPlcDriverCommon.resetLocked(fArgs.fHostTriggerRaisedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Host Trigger Raised Log Write
                // ***
                fArgs.fHostTriggerRaisedLog.fXmlNode.set_attrVal(FXmlTagHTRL.A_Time, FXmlTagHTRL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {                    
                    this.fPcdCore.fLogWriter.pushPlcLog(fArgs.fHostTriggerRaisedLog.fXmlNode);
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
                FPlcDriverCommon.resetLocked(fArgs.fHostTransmitterRaisedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Host Transmitter Raised Log Write
                // ***
                fArgs.fHostTransmitterRaisedLog.fXmlNode.set_attrVal(FXmlTagHTNL.A_Time, FXmlTagHTNL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {                    
                    this.fPcdCore.fLogWriter.pushPlcLog(fArgs.fHostTransmitterRaisedLog.fXmlNode);
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
                FPlcDriverCommon.resetLocked(fArgs.fJudgementPerformedLog.fXmlNode);

                // --

                // ***
                // Judgement Performed Log Write
                // ***
                fArgs.fJudgementPerformedLog.fXmlNode.set_attrVal(FXmlTagJDML.A_Time, FXmlTagJDML.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    // --
                    this.fPcdCore.fLogWriter.pushPlcLog(fArgs.fJudgementPerformedLog.fXmlNode);
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
                FPlcDriverCommon.resetLocked(fArgs.fMapperPerformedLog.fXmlNode);

                // --

                // ***
                // Mapper Performed Log Write
                // ***
                fArgs.fMapperPerformedLog.fXmlNode.set_attrVal(FXmlTagMAPL.A_Time, FXmlTagMAPL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {                    
                    this.fPcdCore.fLogWriter.pushPlcLog(fArgs.fMapperPerformedLog.fXmlNode);
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
                FPlcDriverCommon.resetLocked(fArgs.fEquipmentStateSetAltererPerformedLog.fXmlNode);

                // --

                // ***
                // Equipment State Set Alterer Performed Log Write
                // ***
                fArgs.fEquipmentStateSetAltererPerformedLog.fXmlNode.set_attrVal(FXmlTagESAL.A_Time, FXmlTagESAL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    // --
                    this.fPcdCore.fLogWriter.pushPlcLog(fArgs.fEquipmentStateSetAltererPerformedLog.fXmlNode);
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
                FPlcDriverCommon.resetLocked(fArgs.fStoragePerformedLog.fXmlNode);

                // --

                // ***
                // Storage Performed Log Write
                // ***
                fArgs.fStoragePerformedLog.fXmlNode.set_attrVal(FXmlTagSTGL.A_Time, FXmlTagSTGL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    // --
                    this.fPcdCore.fLogWriter.pushPlcLog(fArgs.fStoragePerformedLog.fXmlNode);
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
                FPlcDriverCommon.resetLocked(fArgs.fCallbackRaisedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Callback Raised Log Write
                // ***
                fArgs.fCallbackRaisedLog.fXmlNode.set_attrVal(FXmlTagCBKL.A_Time, FXmlTagCBKL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    // --
                    this.fPcdCore.fLogWriter.pushPlcLog(fArgs.fCallbackRaisedLog.fXmlNode);
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
                FPlcDriverCommon.resetLocked(fArgs.fFunctionCalledLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Function Called Log Write
                // ***
                fArgs.fFunctionCalledLog.fXmlNode.set_attrVal(FXmlTagFUNL.A_Time, FXmlTagFUNL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    // --
                    this.fPcdCore.fLogWriter.pushPlcLog(fArgs.fFunctionCalledLog.fXmlNode);
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
                FPlcDriverCommon.resetLocked(fArgs.fBranchRaisedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Bransh Raised Log Write
                // ***
                fArgs.fBranchRaisedLog.fXmlNode.set_attrVal(FXmlTagBRNL.A_Time, FXmlTagBRNL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    // --
                    this.fPcdCore.fLogWriter.pushPlcLog(fArgs.fBranchRaisedLog.fXmlNode);
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
                FPlcDriverCommon.resetLocked(fArgs.fCommentWrittenLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Comment Written Log Write
                // ***
                fArgs.fCommentWrittenLog.fXmlNode.set_attrVal(FXmlTagCMTL.A_Time, FXmlTagCMTL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    // --
                    this.fPcdCore.fLogWriter.pushPlcLog(fArgs.fCommentWrittenLog.fXmlNode);
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
                FPlcDriverCommon.resetLocked(fArgs.fPauserRaisedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Comment Written Log Write
                // ***
                fArgs.fPauserRaisedLog.fXmlNode.set_attrVal(FXmlTagPAUL.A_Time, FXmlTagPAUL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    // --
                    this.fPcdCore.fLogWriter.pushPlcLog(fArgs.fPauserRaisedLog.fXmlNode);
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
                FPlcDriverCommon.resetLocked(fArgs.fEntryPointCalledLog.fXmlNode);

                // --

                fArgs.fEntryPointCalledLog.fXmlNode.set_attrVal(FXmlTagETPL.A_Time, FXmlTagETPL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    this.fPcdCore.fLogWriter.pushPlcLog(fArgs.fEntryPointCalledLog.fXmlNode);
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
                FPlcDriverCommon.resetLocked(fArgs.fApplicationWrittenLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Application Written Log Write
                // ***
                fArgs.fApplicationWrittenLog.fXmlNode.set_attrVal(FXmlTagCMTL.A_Time, FXmlTagCMTL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fPcdCore.fLogWriter.pushPlcLog(fArgs.fApplicationWrittenLog.fXmlNode);

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
                if (!this.fPcdCore.fConfig.enabledEventsOfApplication)
                {
                    return;
                }

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FPlcDriverCommon.resetLocked(fApplicationWrittenLog.fXmlNode);

                // --

                this.fPcdCore.fEventPusher.pushApplicationWrittenEvent(fApplicationWrittenLog.fXmlNode);
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
