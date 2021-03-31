/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTcpDriver.cs
--  Creator         : spike.lee
--  Create Date     : 2013.07.10
--  Description     : FAMate Core FaTcpDriver TCP Driver Main Class 
--  History         : Created by spike.lee at 2013.07.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    public class FTcpDriver : FBaseObject<FTcpDriver>, FIObject
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
        public event FTcpDeviceStateChangedEventHandler TcpDeviceStateChanged = null;
        public event FTcpDeviceDataReceivedEventHandler TcpDeviceDataReceived = null;
        public event FTcpDeviceDataSentEventHandler TcpDeviceDataSent = null;
        public event FTcpDeviceXmlReceivedEventHandler TcpDeviceXmlReceived = null;
        public event FTcpDeviceXmlSentEventHandler TcpDeviceXmlSent = null;
        public event FTcpDeviceErrorRaisedEventHandler TcpDeviceErrorRaised = null;
        public event FTcpDeviceTimeoutRaisedEventHandler TcpDeviceTimeoutRaised = null;
        public event FTcpDeviceDataMessageReceivedEventHandler TcpDeviceDataMessageReceived = null;
        public event FTcpDeviceDataMessageSentEventHandler TcpDeviceDataMessageSent = null;       
        // --
        public event FHostDeviceStateChangedEventHandler HostDeviceStateChanged = null;
        public event FHostDeviceErrorRaisedEventHandler HostDeviceErrorRaised = null;
        public event FHostDeviceVfeiReceivedEventHandler HostDeviceVfeiReceived = null;
        public event FHostDeviceVfeiSentEventHandler HostDeviceVfeiSent = null;
        public event FHostDeviceDataMessageReceivedEventHandler HostDeviceDataMessageReceived = null;
        public event FHostDeviceDataMessageSentEventHandler HostDeviceDataMessageSent = null;
        // --
        public event FTcpTriggerRaisedEventHandler TcpTriggerRaised = null;
        public event FTcpTransmitterRaisedEventHandler TcpTransmitterRaised = null;
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
        // TCP Driver 생성에 사용
        // ***
        public FTcpDriver(
            string licFileName
            )
            : base(licFileName)
        {
            this.fTcpDriver = this;            
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2014.02.03 by spike.lee
        // TCP Driver reopenModelingFile 메소드에 사용
        // ***
        internal FTcpDriver(            
            ) 
            : base()
        {
            this.fTcpDriver = this;
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2014.02.03 by spike.lee
        // TCP Driver Clone에 사용
        // ***
        internal FTcpDriver(
            FXmlDocument fXmlDoc
            )
            : base(fXmlDoc)
        {   
            this.fTcpDriver = this;
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2014.02.03 by spike.lee
        // TCP Driver Instance 복사에 사용
        // ***
        internal FTcpDriver(            
            FTcdCore fTcdCore,
            FXmlNode fXmlNode
            ) 
            : base(fTcdCore, fXmlNode)
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FTcpDriver(
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
                    return FObjectType.TcpDriver;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.TcpDriver;
            }
        }        

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTCD.A_UniqueId, FXmlTagTCD.D_UniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagTCD.A_Name, FXmlTagTCD.D_Name);
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
                    FTcpDriverCommon.validateName(value, true);

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagTCD.A_Name, FXmlTagTCD.D_Name, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagTCD.A_Description, FXmlTagTCD.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagTCD.A_Description, FXmlTagTCD.D_Description, value, true);
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

                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagTCD.A_FontColor, FXmlTagTCD.D_FontColor));
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
                    this.fXmlNode.set_attrVal(FXmlTagTCD.A_FontColor, FXmlTagTCD.D_FontColor, value.Name, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagTCD.A_FontBold, FXmlTagTCD.D_FontBold));
                }
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
                    this.fXmlNode.set_attrVal(FXmlTagTCD.A_FontBold, FXmlTagTCD.D_FontBold, FBoolean.fromBool(value), true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagTCD.A_EapName, FXmlTagTCD.D_EapName);
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
                    FTcpDriverCommon.validateName(value, true);

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagTCD.A_EapName, FXmlTagTCD.D_EapName, value, true);

                    // -- 

                    this.fTcdCore.fConfig.eapName = value;
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
                    return this.fXmlNode.get_attrVal(FXmlTagTCD.A_UserTag1, FXmlTagTCD.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagTCD.A_UserTag1, FXmlTagTCD.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagTCD.A_UserTag2, FXmlTagTCD.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagTCD.A_UserTag2, FXmlTagTCD.D_UserTag2, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagTCD.A_UserTag3, FXmlTagTCD.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagTCD.A_UserTag3, FXmlTagTCD.D_UserTag3, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagTCD.A_UserTag4, FXmlTagTCD.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagTCD.A_UserTag4, FXmlTagTCD.D_UserTag4, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagTCD.A_UserTag5, FXmlTagTCD.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagTCD.A_UserTag5, FXmlTagTCD.D_UserTag5, value, true);
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
                    return new FObjectNameListCollection(this.fTcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return new FFunctionNameListCollection(this.fTcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return new FUserTagNameCollection(this.fTcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return new FDataConversionSetListCollection(this.fTcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return new FEquipmentStateSetListCollection(this.fTcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return new FRepositoryListCollection(this.fTcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return new FDataSetListCollection(this.fTcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return new FEnvironmentListCollection(this.fTcdCore, this.fXmlNode.selectNodes(xpath));
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

        public FTcpLibraryGroupCollection fChildTcpLibraryGroupCollection
        {
            get
            {
                const string xpath = FXmlTagTLM.E_TcpLibraryModeling + "/" + FXmlTagTLG.E_TcpLibraryGroup;

                try
                {
                    return new FTcpLibraryGroupCollection(this.fTcdCore, this.fXmlNode.selectNodes(xpath));
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

        public FTcpDeviceCollection fChildTcpDeviceCollection
        {
            get
            {
                const string xpath = FXmlTagTDM.E_TcpDeviceModeling + "/" + FXmlTagTDV.E_TcpDevice;

                try
                {
                    return new FTcpDeviceCollection(this.fTcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return new FHostLibraryGroupCollection(this.fTcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return new FHostDeviceCollection(this.fTcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return new FEquipmentCollection(this.fTcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return this.fTcdCore.fEventPusher.eventCount;
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
                    return this.fTcdCore.fEventPusher.isCompletedEventHandling;
                }
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
                        FXmlTagTLM.E_TcpLibraryModeling + "/" + FXmlTagTLG.E_TcpLibraryGroup + " | " +
                        FXmlTagTDM.E_TcpDeviceModeling + "/" + FXmlTagTDV.E_TcpDevice + " | " +
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

        public bool canAppendChildTcpDevice
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

        public bool canAppendChildTcpLibraryGroup
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

        public bool canPasteChildTcpDevice
        {
            get
            {
                try
                {
                    if (!FClipboard.containsData(FCbObjectFormat.TcpDevice))
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

        public bool canPasteChildTcpLibraryGroup
        {
            get
            {
                try
                {
                    if (!FClipboard.containsData(FCbObjectFormat.TcpLibraryGroup))
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
                    return new FObjectCollection(this.fTcdCore, this.fXmlNode.selectNodes("NULL"));
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
                    return new FObjectCollection(this.fTcdCore, this.fXmlNode.selectNodes("NULL"));
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
                    return this.fTcdCore.fRepositoryMaterialStorage;
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
                    return this.fTcdCore.fEquipmentStateMaterialStorage;
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

        #region TCP Driver Config

        public string hostDriverDirectory
        {
            get
            {
                try
                {
                    return this.fTcdCore.fConfig.hostDriverDirectory;
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
                    this.fTcdCore.fConfig.hostDriverDirectory = value;
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
                    return this.fTcdCore.fConfig.logDirectory;
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
                    this.fTcdCore.fConfig.logDirectory = value;
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

        // ***
        // 2021.03.25 add by Sunghoon.Park 
        // tcp driver directory property 추가
        // ***

        public string tcpDeviceDriverDirectory
        {
            get
            {
                try
                {
                    return this.fTcdCore.fConfig.tcpDeviceDriverDirectory;
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
                    this.fTcdCore.fConfig.tcpDeviceDriverDirectory = value;
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

        public bool enabledEventsOfTcpDeviceState
        {
            get
            {
                try
                {
                    return this.fTcdCore.fConfig.enabledEventsOfTcpDeviceState;
                }
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
                    this.fTcdCore.fConfig.enabledEventsOfTcpDeviceState = value;
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

        public bool enabledEventsOfTcpDeviceError
        {
            get
            {
                try
                {
                    return this.fTcdCore.fConfig.enabledEventsOfTcpDeviceError;
                }
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
                    this.fTcdCore.fConfig.enabledEventsOfTcpDeviceError = value;
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

        public bool enabledEventsOfTcpDeviceTimeout
        {
            get
            {
                try
                {
                    return this.fTcdCore.fConfig.enabledEventsOfTcpDeviceTimeout;
                }
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
                    this.fTcdCore.fConfig.enabledEventsOfTcpDeviceTimeout = value;
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

        public bool enabledEventsOfTcpDeviceXml
        {
            get
            {
                try
                {
                    return this.fTcdCore.fConfig.enabledEventsOfTcpDeviceXml;
                }
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
                    this.fTcdCore.fConfig.enabledEventsOfTcpDeviceXml = value;
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

        public bool enabledEventsOfTcpDeviceDataMessage
        {
            get
            {
                try
                {
                    return this.fTcdCore.fConfig.enabledEventsOfTcpDeviceDataMessage;
                }
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
                    this.fTcdCore.fConfig.enabledEventsOfTcpDeviceDataMessage = value;
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
                    return this.fTcdCore.fConfig.enabledEventsOfHostDeviceState;
                }
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
                    this.fTcdCore.fConfig.enabledEventsOfHostDeviceState = value;
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
                    return this.fTcdCore.fConfig.enabledEventsOfHostDeviceError;
                }
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
                    this.fTcdCore.fConfig.enabledEventsOfHostDeviceError = value;
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
                    return this.fTcdCore.fConfig.enabledEventsOfHostDeviceVfei;
                }
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
                    this.fTcdCore.fConfig.enabledEventsOfHostDeviceVfei = value;
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
                    return this.fTcdCore.fConfig.enabledEventsOfHostDeviceDataMessage;
                }
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
                    this.fTcdCore.fConfig.enabledEventsOfHostDeviceDataMessage = value;
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
                    return this.fTcdCore.fConfig.enabledEventsOfScenario;
                }
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
                    this.fTcdCore.fConfig.enabledEventsOfScenario = value;
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
                    return this.fTcdCore.fConfig.enabledEventsOfApplication;
                }
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
                    this.fTcdCore.fConfig.enabledEventsOfApplication = value;
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
                    return this.fTcdCore.fConfig.enabledLogOfBinary;
                }
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
                    this.fTcdCore.fConfig.enabledLogOfBinary = value;
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

        public bool enabledLogOfXml
        {
            get
            {
                try
                {
                    return this.fTcdCore.fConfig.enabledLogOfXml;
                }
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
                    this.fTcdCore.fConfig.enabledLogOfXml = value;
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
                    return this.fTcdCore.fConfig.enabledLogOfVfei;
                }
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
                    this.fTcdCore.fConfig.enabledLogOfVfei = value;
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

        public bool enabledLogOfTcp
        {
            get
            {
                try
                {
                    return this.fTcdCore.fConfig.enabledLogOfTcp;
                }
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
                    this.fTcdCore.fConfig.enabledLogOfTcp = value;
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
                    return this.fTcdCore.fConfig.maxLogFileSizeOfBinary;
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

                    this.fTcdCore.fConfig.maxLogFileSizeOfBinary = value;
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

        public long maxLogFileSizeOfXml
        {
            get
            {
                try
                {
                    return this.fTcdCore.fConfig.maxLogFileSizeOfXml;
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

                    this.fTcdCore.fConfig.maxLogFileSizeOfXml = value;
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
                    return this.fTcdCore.fConfig.maxLogFileSizeOfVfei;
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

                    this.fTcdCore.fConfig.maxLogFileSizeOfVfei = value;
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

        public long maxLogFileSizeOfTcp
        {
            get
            {
                try
                {
                    return this.fTcdCore.fConfig.maxLogFileSizeOfTcp;
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
                    this.fTcdCore.fConfig.maxLogFileSizeOfTcp = value;
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
                    return this.fTcdCore.fConfig.maxLogCountOfBinary;
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
                    this.fTcdCore.fConfig.maxLogCountOfBinary = value;
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

        public long maxLogCountOfXml
        {
            get
            {
                try
                {
                    return this.fTcdCore.fConfig.maxLogCountOfXml;
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
                    this.fTcdCore.fConfig.maxLogCountOfXml = value;
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
                    return this.fTcdCore.fConfig.maxLogCountOfVfei;
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
                    this.fTcdCore.fConfig.maxLogCountOfVfei = value;
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

        public long maxLogCountOfTcp
        {
            get
            {
                try
                {
                    return this.fTcdCore.fConfig.maxLogCountOfTcp;
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
                    this.fTcdCore.fConfig.maxLogCountOfTcp = value;
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
                    return this.fTcdCore.fConfig.repositorySaveDirectory;
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
                    this.fTcdCore.fConfig.repositorySaveDirectory = value;
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
                    return this.fTcdCore.fConfig.enabledRepositorySave;
                }
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
                    this.fTcdCore.fConfig.enabledRepositorySave = value;
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
                    return this.fTcdCore.fConfig.enabledRepositoryAutoRemove;
                }
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
                    this.fTcdCore.fConfig.enabledRepositoryAutoRemove = value;
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
                    return this.fTcdCore.fConfig.repositoryKeepingPeriod;
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

                    this.fTcdCore.fConfig.repositoryKeepingPeriod = value;
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
                FTcpDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.HostLibraryGroup);

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
                FTcpDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.HostDevice);

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
                FTcpDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.Equipment);

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
                // 새로운 File Open할 경우 모든 TCP Device와 Host Device를 Close 한다.
                // ***
                closeAllDevice();
                this.waitEventHandlingCompleted();

                // --

                this.fTcdCore.openModelingFile(fileName);
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
                this.fTcdCore.reopenModelingFile(fileName);
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
                this.fTcdCore.saveModelingFile(fileName);
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
                this.fTcdCore.fEventPusher.waitEventHandlingCompleted();
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
                openAllTcpDevice();
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

        public void openAllTcpDevice(
            )
        {
            try
            {
                foreach (FTcpDevice fTdv in this.fChildTcpDeviceCollection)
                {
                    fTdv.open();
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
                closeAllTcpDevice();
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

        public void closeAllTcpDevice(
            )
        {
            try
            {
                foreach (FTcpDevice fTdv in this.fChildTcpDeviceCollection)
                {
                    fTdv.close();
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

        public FTcpDriverLog createTcpDriverLog(
            )
        {
            try
            {
                return new FTcpDriverLog(this);
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

        public FTcpDriver cloneTcpDriver(
            )
        {
            try
            {
                return new FTcpDriver(this.fTcdCore.fXmlDoc.clone(true));
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
                        return FTcpDriverCommon.createObject(this.fTcdCore, fXmlNodeSearchList[i]);
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
                        return FTcpDriverCommon.createObject(this.fTcdCore, fXmlNodeSearchList[i]);
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

        public FIObject searchTcpLibrarySeries(
            FIObject fBaseObject,
            string searchWord
            )
        {
            const string xPath =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + "/" + FXmlTagTLM.E_TcpLibraryModeling + "//*";

            try
            {
                // ***
                // TCP Library Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.TcpDriver &&
                    fBaseObject.fObjectType != FObjectType.TcpLibraryGroup &&
                    fBaseObject.fObjectType != FObjectType.TcpLibrary &&
                    fBaseObject.fObjectType != FObjectType.TcpMessageList &&
                    fBaseObject.fObjectType != FObjectType.TcpMessages &&
                    fBaseObject.fObjectType != FObjectType.TcpMessage &&
                    fBaseObject.fObjectType != FObjectType.TcpItem
                    )
                {
                    return null;
                }

                // --

                return searchCommonSeries(
                   fBaseObject.uniqueIdToString,
                   searchWord,
                   this.fTcdCore.fXmlDoc.selectNodes(xPath)
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

        public FIObject searchTcpDeviceSeries(
           FIObject fBaseObject,
           ref FTcpSession fBaseSession,
           string searchWord
           )
        {
            const string xPathTdm =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + "/" + FXmlTagTDM.E_TcpDeviceModeling + "//*";
            // --
            const string xPathTlb =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + "/" + FXmlTagTLM.E_TcpLibraryModeling + "/" + FXmlTagTLG.E_TcpLibraryGroup + "/" +
                FXmlTagTLB.E_TcpLibrary + "[@" + FXmlTagTLB.A_UniqueId + "='{0}']";
            // --            
            const string xPathTlm = ".//*";
            // --
            const string xPathTsn =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + "/" + FXmlTagTDM.E_TcpDeviceModeling + "/" + FXmlTagTDV.E_TcpDevice + "/" +
                FXmlTagTSN.E_TcpSession + "[@" + FXmlTagTSN.A_UniqueId + "='{0}']";

            string baseUniqueId = string.Empty;
            FXmlNodeList fXmlNodeTdmSearchList = null;
            FXmlNodeList fXmlNodeTlmSearchList = null;
            FXmlNode fXmlNodeTlb = null;
            FXmlNode fXmlNodeTsn = null;
            int index = 0;
            int indexNo = 0;
            string uniqueId = string.Empty;
            string tsnUniqueId = string.Empty;
            string tlbUniqueId = string.Empty;
            string[] uniqueIds = null;
            List<string> keys = null;
            List<FXmlNode> values = null;

            try
            {
                // ***
                // TCP Device Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.TcpDriver &&
                    fBaseObject.fObjectType != FObjectType.TcpDevice &&
                    fBaseObject.fObjectType != FObjectType.TcpSession &&
                    fBaseObject.fObjectType != FObjectType.TcpMessageList &&
                    fBaseObject.fObjectType != FObjectType.TcpMessages &&
                    fBaseObject.fObjectType != FObjectType.TcpMessage &&
                    fBaseObject.fObjectType != FObjectType.TcpItem
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
                fXmlNodeTdmSearchList = this.fTcdCore.fXmlDoc.selectNodes(xPathTdm);
                // --
                foreach (FXmlNode x in fXmlNodeTdmSearchList)
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

                    if (x.name == FXmlTagTSN.E_TcpSession)
                    {
                        tsnUniqueId = uniqueId;
                        tlbUniqueId = x.get_attrVal(FXmlTagTSN.A_TcpLibraryId, FXmlTagTSN.D_TcpLibraryId);
                        // --
                        if (tlbUniqueId != string.Empty)
                        {
                            fXmlNodeTlb = this.fTcdCore.fXmlDoc.selectSingleNode(string.Format(xPathTlb, tlbUniqueId));
                            fXmlNodeTlmSearchList = fXmlNodeTlb.selectNodes(xPathTlm);
                            // --
                            foreach (FXmlNode xn in fXmlNodeTlmSearchList)
                            {
                                uniqueId = tsnUniqueId + "-" + xn.get_attrVal(FXmlTagCommon.A_UniqueId, FXmlTagCommon.D_UniqueId);
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
                            fXmlNodeTsn = this.fTcdCore.fXmlDoc.selectSingleNode(string.Format(xPathTsn, uniqueIds[0]));
                            fBaseSession = (FTcpSession)FTcpDriverCommon.createObject(this.fTcdCore, fXmlNodeTsn);
                        }
                        else
                        {
                            fBaseSession = null;
                        }
                        return FTcpDriverCommon.createObject(this.fTcdCore, values[i]);
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
                            fXmlNodeTsn = this.fTcdCore.fXmlDoc.selectSingleNode(string.Format(xPathTsn, uniqueIds[0]));
                            fBaseSession = (FTcpSession)FTcpDriverCommon.createObject(this.fTcdCore, fXmlNodeTsn);
                        }
                        else
                        {
                            fBaseSession = null;
                        }
                        return FTcpDriverCommon.createObject(this.fTcdCore, values[i]);
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
                fXmlNodeTdmSearchList = null;
                fXmlNodeTlmSearchList = null;
                fXmlNodeTlb = null;
                fXmlNodeTsn = null;
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
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + "/" + FXmlTagHLM.E_HostLibraryModeling + "//*";

            try
            {
                // ***
                // Host Library Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.TcpDriver &&
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
                   this.fTcdCore.fXmlDoc.selectNodes(xPath)
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
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + "/" + FXmlTagHDM.E_HostDeviceModeling + "//*";
            // --
            const string xPathHlb =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + "/" + FXmlTagHLM.E_HostLibraryModeling + "/" + FXmlTagHLG.E_HostLibraryGroup + "/" +
                FXmlTagHLB.E_HostLibrary + "[@" + FXmlTagHLB.A_UniqueId + "='{0}']";
            // --            
            const string xPatHlm = ".//*";
            // --
            const string xPathHsn =
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + "/" + FXmlTagHDM.E_HostDeviceModeling + "/" + FXmlTagHDV.E_HostDevice + "/" +
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
                    fBaseObject.fObjectType != FObjectType.TcpDriver &&
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
                fXmlNodeHdmSearchList = this.fTcdCore.fXmlDoc.selectNodes(xPathHdm);
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
                            fXmlNodeHlb = this.fTcdCore.fXmlDoc.selectSingleNode(string.Format(xPathHlb, hlbUniqueId));
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
                            fXmlNodeHsn = this.fTcdCore.fXmlDoc.selectSingleNode(string.Format(xPathHsn, uniqueIds[0]));
                            fBaseSession = (FHostSession)FTcpDriverCommon.createObject(this.fTcdCore, fXmlNodeHsn);
                        }
                        else
                        {
                            fBaseSession = null;
                        }
                        return FTcpDriverCommon.createObject(this.fTcdCore, values[i]);
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
                            fXmlNodeHsn = this.fTcdCore.fXmlDoc.selectSingleNode(string.Format(xPathHsn, uniqueIds[0]));
                            fBaseSession = (FHostSession)FTcpDriverCommon.createObject(this.fTcdCore, fXmlNodeHsn);
                        }
                        else
                        {
                            fBaseSession = null;
                        }
                        return FTcpDriverCommon.createObject(this.fTcdCore, values[i]);
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
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + "/" + FXmlTagSET.E_Setup + "/" + FXmlTagOND.E_ObjectNameDefinition + "//*";

            try
            {
                // ***
                // Object Name Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.TcpDriver &&
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
                   this.fTcdCore.fXmlDoc.selectNodes(xPath)
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
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + "/" + FXmlTagSET.E_Setup + "/" + FXmlTagFND.E_FunctionNameDefinition + "//*";

            try
            {
                // ***
                // Function Name Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.TcpDriver &&
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
                   this.fTcdCore.fXmlDoc.selectNodes(xPath)
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
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + "/" + FXmlTagSET.E_Setup + "/" + FXmlTagUTD.E_UserTagNameDefinition + "//*";

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
                   this.fTcdCore.fXmlDoc.selectNodes(xPath)
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
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + "/" + FXmlTagSET.E_Setup + "/" + FXmlTagDCD.E_DataConversionSetDefinition + "//*";

            try
            {
                // ***
                // Data Conversion Set Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.TcpDriver &&
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
                   this.fTcdCore.fXmlDoc.selectNodes(xPath)
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
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + "/" + FXmlTagSET.E_Setup + "/" + FXmlTagESD.E_EquipmentStateSetDefinition + "//*";

            try
            {
                // ***
                // Equipment State Set Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.TcpDriver &&
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
                   this.fTcdCore.fXmlDoc.selectNodes(xPath)
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
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + "/" + FXmlTagSET.E_Setup + "/" + FXmlTagRPD.E_RepositoryDefinition + "//*";

            try
            {
                // ***
                // Repository Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.TcpDriver &&
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
                   this.fTcdCore.fXmlDoc.selectNodes(xPath)
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
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + "/" + FXmlTagSET.E_Setup + "/" + FXmlTagEND.E_EnvironmentDefinition + "//*";

            try
            {
                // ***
                // Environment Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.TcpDriver &&
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
                   this.fTcdCore.fXmlDoc.selectNodes(xPath)
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
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + "/" + FXmlTagSET.E_Setup + "/" + FXmlTagDSD.E_DataSetDefinition + "//*";

            try
            {
                // ***
                // Data Set Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.TcpDriver &&
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
                   this.fTcdCore.fXmlDoc.selectNodes(xPath)
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
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + "/" + FXmlTagEQM.E_EquipmentModeling + "/" + FXmlTagEQP.E_Equipment + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + "/" + FXmlTagEQM.E_EquipmentModeling + "/" + FXmlTagEQP.E_Equipment + " /" + FXmlTagSNG.E_ScenarioGroup + " | " +
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + "/" + FXmlTagEQM.E_EquipmentModeling + "/" + FXmlTagEQP.E_Equipment + " /" + FXmlTagSNG.E_ScenarioGroup + "/" + FXmlTagSNR.E_Scenario;

            try
            {
                // ***
                // Equipment Series 검증
                // ***
                if (
                    fBaseObject.fObjectType != FObjectType.TcpDriver &&
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
                    this.fTcdCore.fXmlDoc.selectNodes(xPath)
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
                FXmlTagFAM.E_FAMate + "/" + FXmlTagTCD.E_TcpDriver + "/" + FXmlTagEQM.E_EquipmentModeling + "/" + FXmlTagEQP.E_Equipment + " /" + FXmlTagSNG.E_ScenarioGroup + "/" +
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
                        fBaseObject.fObjectType != FObjectType.TcpTrigger &&
                        fBaseObject.fObjectType != FObjectType.TcpCondition &&
                        fBaseObject.fObjectType != FObjectType.TcpExpression &&
                        fBaseObject.fObjectType != FObjectType.TcpTransmitter &&
                        fBaseObject.fObjectType != FObjectType.TcpTransfer &&
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

                fXmlNodeSearchList = this.fTcdCore.fXmlDoc.selectNodes(string.Format(xPath, fBaseScenario.uniqueIdToString));
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
                        return FTcpDriverCommon.createObject(this.fTcdCore, fXmlNodeSearchList[i]);
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
                        return FTcpDriverCommon.createObject(this.fTcdCore, fXmlNodeSearchList[i]);
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

        public FObjectNameList appendChildObjectNameList(
            FObjectNameList fNewChild
            )
        {
            FXmlNode fXmlNodeOnd = null;

            try
            {
                fXmlNodeOnd = this.fXmlNode.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagOND.E_ObjectNameDefinition);

                // --

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeOnd.appendChild(fNewChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(fXmlNodeOnd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeOnd.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(fXmlNodeOnd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeOnd.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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
                FTcpDriverCommon.validateRemoveChildObject(fXmlNodeOnd, fChild.fXmlNode);

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
                    FTcpDriverCommon.validateRemoveChildObject(fXmlNodeOnd, fOnl.fXmlNode);
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

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeFnd.appendChild(fNewChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(fXmlNodeFnd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeFnd.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(fXmlNodeFnd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeFnd.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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
                FTcpDriverCommon.validateRemoveChildObject(fXmlNodeFnd, fChild.fXmlNode);

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
                    FTcpDriverCommon.validateRemoveChildObject(fXmlNodeFnd, fFnl.fXmlNode);
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

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeDcd.appendChild(fNewChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(fXmlNodeEsd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeEsd.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(fXmlNodeEsd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeEsd.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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
                FTcpDriverCommon.validateRemoveChildObject(fXmlNodeDcd, fChild.fXmlNode);

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
                    FTcpDriverCommon.validateRemoveChildObject(fXmlNodeDcd, fDcl.fXmlNode);
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

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeEsd.appendChild(fNewChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(fXmlNodeEsd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeEsd.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(fXmlNodeEsd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeEsd.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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
                FTcpDriverCommon.validateRemoveChildObject(fXmlNodeEsd, fChild.fXmlNode);

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
                    FTcpDriverCommon.validateRemoveChildObject(fXmlNodeEsd, fEsl.fXmlNode);
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

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeRpd.appendChild(fNewChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(fXmlNodeRpd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeRpd.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(fXmlNodeRpd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeRpd.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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
                FTcpDriverCommon.validateRemoveChildObject(fXmlNodeRpd, fChild.fXmlNode);

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
                    FTcpDriverCommon.validateRemoveChildObject(fXmlNodeRpd, fRpl.fXmlNode);
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
                FTcpDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.ObjectNameList);

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
                FTcpDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.FunctionNameList);

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
                FTcpDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.DataConversionSetList);

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
                FTcpDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.EquipmentStateSetList);

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
                FTcpDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.RepositoryList);

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
                FTcpDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.EnvironmentList);

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
                FTcpDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.DataSetList);

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

        public FTcpLibraryGroup pasteChildTcpLibraryGroup(
            )
        {
            FTcpLibraryGroup fTcpLibraryGroup = null;

            try
            {
                FTcpDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.TcpLibraryGroup);

                // -- 

                fTcpLibraryGroup = (FTcpLibraryGroup)this.pasteObject(FCbObjectFormat.TcpLibraryGroup);
                this.appendChildTcpLibraryGroup(fTcpLibraryGroup);

                // --

                return fTcpLibraryGroup;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fTcpLibraryGroup = null;
            }

            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpDevice pasteChildTcpDevice(
            )
        {
            FTcpDevice fTcpDevice = null;

            try
            {
                FTcpDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.TcpDevice);

                // -- 

                fTcpDevice = (FTcpDevice)this.pasteObject(FCbObjectFormat.TcpDevice);
                // --
                fTcpDevice.changeState(FDeviceState.Closed);
                // --
                foreach (FTcpSession fOsn in fTcpDevice.fChildTcpSessionCollection)
                {
                    fOsn.fXmlNode.set_attrVal(FXmlTagTSN.A_TcpLibraryId, FXmlTagTSN.D_TcpLibraryId, "");
                }
                this.appendChildTcpDevice(fTcpDevice);

                // --

                return fTcpDevice;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fTcpDevice = null;
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

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeEnd.appendChild(fNewChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(fXmlNodeEnd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeEnd.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(fXmlNodeEnd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeEnd.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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
                FTcpDriverCommon.validateRemoveChildObject(fXmlNodeEnd, fChild.fXmlNode);

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
                    FTcpDriverCommon.validateRemoveChildObject(fXmlNodeEnd, fEnl.fXmlNode);
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

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeDsd.appendChild(fNewChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(fXmlNodeDsd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeDsd.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(fXmlNodeDsd, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeDsd.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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
                FTcpDriverCommon.validateRemoveChildObject(fXmlNodeRpd, fChild.fXmlNode);

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
                    FTcpDriverCommon.validateRemoveChildObject(fXmlNodeDsd, fDsl.fXmlNode);
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

        public FTcpLibraryGroup appendChildTcpLibraryGroup(
            FTcpLibraryGroup fNewChild
            )
        {
            FXmlNode fXmlNodePlm = null;

            try
            {
                fXmlNodePlm = this.fXmlNode.selectSingleNode(FXmlTagTLM.E_TcpLibraryModeling);

                // --

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodePlm.appendChild(fNewChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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

        public FTcpLibraryGroup insertBeforeChildTcpLibraryGroup(
            FTcpLibraryGroup fNewChild,
            FTcpLibraryGroup fRefChild
            )
        {
            FXmlNode fXmlNodePlm = null;

            try
            {
                fXmlNodePlm = this.fXmlNode.selectSingleNode(FXmlTagTLM.E_TcpLibraryModeling);

                // --

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(fXmlNodePlm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodePlm.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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

        public FTcpLibraryGroup insertAfterChildTcpLibraryGroup(
            FTcpLibraryGroup fNewChild,
            FTcpLibraryGroup fRefChild
            )
        {
            FXmlNode fXmlNodePlm = null;

            try
            {
                fXmlNodePlm = this.fXmlNode.selectSingleNode(FXmlTagTLM.E_TcpLibraryModeling);

                // --

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(fXmlNodePlm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodePlm.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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

        public FTcpLibraryGroup removeChildTcpLibraryGroup(
            FTcpLibraryGroup fChild
            )
        {
            FXmlNode fXmlNodePlm = null;

            try
            {
                fXmlNodePlm = this.fXmlNode.selectSingleNode(FXmlTagTLM.E_TcpLibraryModeling);
                FTcpDriverCommon.validateRemoveChildObject(fXmlNodePlm, fChild.fXmlNode);

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

        public void removeChildTcpLibraryGroup(
            FTcpLibraryGroup[] fChilds
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

                fXmlNodePlm = this.fXmlNode.selectSingleNode(FXmlTagTLM.E_TcpLibraryModeling);
                foreach (FTcpLibraryGroup fSlg in fChilds)
                {
                    FTcpDriverCommon.validateRemoveChildObject(fXmlNodePlm, fSlg.fXmlNode);
                }

                // --

                foreach (FTcpLibraryGroup fSlg in fChilds)
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

        public void removeAllChildTcpLibraryGroup(
            )
        {
            FTcpLibraryGroupCollection fTlgCollection = null;

            try
            {
                fTlgCollection = this.fChildTcpLibraryGroupCollection;
                if (fTlgCollection.count == 0)
                {
                    return;
                }

                // --

                foreach (FTcpLibraryGroup fPlg in fTlgCollection)
                {
                    if (fPlg.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }
                }

                // --

                foreach (FTcpLibraryGroup fPlg in fTlgCollection)
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
                if (fTlgCollection != null)
                {
                    fTlgCollection.Dispose();
                    fTlgCollection = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpDevice appendChildTcpDevice(
            FTcpDevice fNewChild
            )
        {
            FXmlNode fXmlNodeOdm = null;

            try
            {
                fXmlNodeOdm = this.fXmlNode.selectSingleNode(FXmlTagTDM.E_TcpDeviceModeling);

                // --

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeOdm.appendChild(fNewChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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

        public FTcpDevice insertBeforeChildTcpDevice(
           FTcpDevice fNewChild,
           FTcpDevice fRefChild
           )
        {
            FXmlNode fXmlNodeOdm = null;

            try
            {
                fXmlNodeOdm = this.fXmlNode.selectSingleNode(FXmlTagTDM.E_TcpDeviceModeling);

                // --

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(fXmlNodeOdm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeOdm.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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

        public FTcpDevice insertAfterChildTcpDevice(
           FTcpDevice fNewChild,
           FTcpDevice fRefChild
           )
        {
            FXmlNode fXmlNodeOdm = null;

            try
            {
                fXmlNodeOdm = this.fXmlNode.selectSingleNode(FXmlTagTDM.E_TcpDeviceModeling);

                // --

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(fXmlNodeOdm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeOdm.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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

        public FTcpDevice removeChildTcpDevice(
            FTcpDevice fChild
            )
        {
            FXmlNode fXmlNodeOdm = null;

            try
            {
                fXmlNodeOdm = this.fXmlNode.selectSingleNode(FXmlTagTDM.E_TcpDeviceModeling);
                FTcpDriverCommon.validateRemoveChildObject(fXmlNodeOdm, fChild.fXmlNode);

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

        public void removeChildTcpDevice(
            FTcpDevice[] fChilds
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

                fXmlNodeOdm = this.fXmlNode.selectSingleNode(FXmlTagTDM.E_TcpDeviceModeling);
                foreach (FTcpDevice fOdv in fChilds)
                {
                    FTcpDriverCommon.validateRemoveChildObject(fXmlNodeOdm, fOdv.fXmlNode);
                    // --
                    if (fOdv.fState != FDeviceState.Closed)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0027, "Device"));
                    }
                }

                // --

                foreach (FTcpDevice fOdv in fChilds)
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

        public void removeAllChildTcpDevice(
            )
        {
            FTcpDeviceCollection fOdvCollection = null;

            try
            {
                fOdvCollection = this.fChildTcpDeviceCollection;
                if (fOdvCollection.count == 0)
                {
                    return;
                }

                // --

                foreach (FTcpDevice fOdv in fOdvCollection)
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

                foreach (FTcpDevice fOdv in fOdvCollection)
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

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeHlm.appendChild(fNewChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(fXmlNodeHlm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeHlm.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(fXmlNodeHlm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeHlm.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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
                FTcpDriverCommon.validateRemoveChildObject(fXmlNodeHlm, fChild.fXmlNode);

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
                    FTcpDriverCommon.validateRemoveChildObject(fXmlNodeHlm, fHlg.fXmlNode);
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

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeHdm.appendChild(fNewChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(fXmlNodeHdm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeHdm.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(fXmlNodeHdm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeHdm.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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
                FTcpDriverCommon.validateRemoveChildObject(fXmlNodeHdm, fChild.fXmlNode);

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
                    FTcpDriverCommon.validateRemoveChildObject(fXmlNodeHdm, fHdv.fXmlNode);
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

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeEqm.appendChild(fNewChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(fXmlNodeEqm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeEqm.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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

                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(fXmlNodeEqm, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fTcdCore, fXmlNodeEqm.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                // --
                this.fTcdCore.fEventPusher.pushEvent(
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
                FTcpDriverCommon.validateRemoveChildObject(fXmlNodeEqm, fChild.fXmlNode);

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
                    FTcpDriverCommon.validateRemoveChildObject(fXmlNodeEqm, fEqp.fXmlNode);
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

                fXmlNode = FTcpDriverCommon.getObjectXmlNode(fObject);
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
                    fObject.fObjectType == FObjectType.TcpLibraryGroup ||
                    fObject.fObjectType == FObjectType.TcpDevice ||
                    fObject.fObjectType == FObjectType.HostLibraryGroup ||
                    fObject.fObjectType == FObjectType.HostDevice ||
                    fObject.fObjectType == FObjectType.EquipmentStateSetList ||
                    fObject.fObjectType == FObjectType.Equipment
                    )
                {
                    return this;
                }

                // --

                return FTcpDriverCommon.createObject(this.fTcdCore, fXmlNode.fParentNode);
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

                fXmlNode = FTcpDriverCommon.getObjectXmlNode(fObject);
                if (fXmlNode.fPreviousSibling == null)
                {
                    return null;
                }

                // --

                return FTcpDriverCommon.createObject(this.fTcdCore, fXmlNode.fPreviousSibling);
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

                fXmlNode = FTcpDriverCommon.getObjectXmlNode(fObject);
                if (fXmlNode.fNextSibling == null)
                {
                    return null;
                }

                // --

                return FTcpDriverCommon.createObject(this.fTcdCore, fXmlNode.fNextSibling);
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

        public void cutTcpBinaryLogFile(
            )
        {
            try
            {
                this.fTcdCore.fLogWriter.cutBinaryLogFile();
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

        public void cutXmlLogFile(
            )
        {
            try
            {
                this.fTcdCore.fLogWriter.cutXmlLogFile();
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
                this.fTcdCore.fLogWriter.cutVfeiLogFile();
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

        public void cutTcpLogFile(
            )
        {
            try
            {
                this.fTcdCore.fLogWriter.cutTcpLogFile();
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
                this.fTcdCore.fLogWriter.cutBinaryLogFile();
                this.fTcdCore.fLogWriter.cutXmlLogFile();
                this.fTcdCore.fLogWriter.cutVfeiLogFile();
                this.fTcdCore.fLogWriter.cutTcpLogFile();
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
                    return FTcpDriverCommon.createObject(this.fTcdCore, fXmlNode);
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
                    this.fTcdCore,
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
                return new FObjectNameList(this.fTcdCore, fXmlNode);
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
                return new FObjectNameList(this.fTcdCore, fXmlNode);
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
                    this.fTcdCore,
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
                return new FFunctionNameList(this.fTcdCore, fXmlNode);
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
                    this.fTcdCore,
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
                return new FUserTagName(this.fTcdCore, fXmlNode);
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
                return new FUserTagName(this.fTcdCore, fXmlNode);
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
                    this.fTcdCore,
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
                return new FDataConversionSetList(this.fTcdCore, fXmlNode);
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
                    this.fTcdCore,
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
                return new FEquipmentStateSetList(this.fTcdCore, fXmlNode);
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
                    this.fTcdCore,
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
                return new FRepositoryList(this.fTcdCore, fXmlNode);
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
                    this.fTcdCore,
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
                return new FDataSetList(this.fTcdCore, fXmlNode);
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
                    this.fTcdCore,
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
                return new FEnvironmentList(this.fTcdCore, fXmlNode);
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

        public FTcpLibraryGroupCollection selectTcpLibraryGroupByName(
            string name
            )
        {
            const string xpath = FXmlTagTLM.E_TcpLibraryModeling +
                "/" + FXmlTagTLG.E_TcpLibraryGroup + "[@" + FXmlTagTLG.A_Name + "='{0}']";

            try
            {
                return new FTcpLibraryGroupCollection(
                    this.fTcdCore,
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

        public FTcpLibraryGroup selectSingleTcpLibraryGroupByName(
            string name
            )
        {
            const string xpath = FXmlTagTLM.E_TcpLibraryModeling +
                "/" + FXmlTagTLG.E_TcpLibraryGroup + "[@" + FXmlTagTLG.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FTcpLibraryGroup(this.fTcdCore, fXmlNode);
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

        public FTcpDeviceCollection selectTcpDeviceByName(
            string name
            )
        {
            const string xpath =
                FXmlTagTDM.E_TcpDeviceModeling +
                "/" + FXmlTagTDV.E_TcpDevice + "[@" + FXmlTagTDV.A_Name + "='{0}']";

            try
            {
                return new FTcpDeviceCollection(
                    this.fTcdCore,
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

        public FTcpDevice selectSingleSecsDeviceByName(
            string name
            )
        {
            const string xpath =
                FXmlTagTDM.E_TcpDeviceModeling +
                "/" + FXmlTagTDV.E_TcpDevice + "[@" + FXmlTagTDV.A_Name + "='{0}']";

            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FTcpDevice(this.fTcdCore, fXmlNode);
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
                    this.fTcdCore,
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
                return new FHostLibraryGroup(this.fTcdCore, fXmlNode);
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
                    this.fTcdCore,
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
                return new FHostDevice(this.fTcdCore, fXmlNode);
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
                    this.fTcdCore,
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
                return new FEquipment(this.fTcdCore, fXmlNode);
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
                return new FEntryPoint(this.fTcdCore, fXmlNode);
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
                    this.fTcdCore,
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
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the TCP Driver and the Entry Point", "same"));
                }

                // --

                this.fTcdCore.fEventPusher.pushEntryPointCalledEvent(
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
                this.fTcdCore.openRepositoryMaterial();
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
                this.fTcdCore.loadRepositoryMaterial(rawData);
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
                this.fTcdCore.saveRepositoryMaterial(rawData);
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
                return this.fTcdCore.getRepositoryMaterialRawData();
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
                this.fTcdCore.removeRepositoryMaterialById(rpmIds);
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

        #region On TCP Driver Modeling Event

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

        #region On TCP Driver Communication Event

        internal void onTcpDeviceStateChanged(
            FEventArgsBase fArgsBase
            )
        {
            FTcpDeviceStateChangedEventArgs fArgs = null;

            try
            {
                fArgs = (FTcpDeviceStateChangedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FTcpDriverCommon.resetLocked(fArgs.fTcpDeviceStateChangedLog.fXmlNode);

                // --

                fArgs.fTcpDeviceStateChangedLog.fXmlNode.set_attrVal(FXmlTagTDVL.A_Time, FXmlTagTDVL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fTcdCore.fLogWriter.pushTcpLog(fArgs.fTcpDeviceStateChangedLog.fXmlNode);

                // --

                if (TcpDeviceStateChanged != null)
                {
                    TcpDeviceStateChanged(this, fArgs);
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

        internal void onTcpDeviceDataReceived(
            FEventArgsBase fArgsBase
            )
        {
            FTcpDeviceDataReceivedEventArgs fArgs = null;

            try
            {
                fArgs = (FTcpDeviceDataReceivedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FTcpDriverCommon.resetLocked(fArgs.fTcpDeviceDataReceivedLog.fXmlNode);

                // --

                fArgs.fTcpDeviceDataReceivedLog.fXmlNode.set_attrVal(FXmlTagTDVL.A_Time, FXmlTagTDVL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fTcdCore.fLogWriter.pushTcpLog(fArgs.fTcpDeviceDataReceivedLog.fXmlNode);

                // --

                if (TcpDeviceDataReceived != null)
                {
                    TcpDeviceDataReceived(this, fArgs);
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

        internal void onTcpDeviceDataSent(
            FEventArgsBase fArgsBase
            )
        {
            FTcpDeviceDataSentEventArgs fArgs = null;

            try
            {
                fArgs = (FTcpDeviceDataSentEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FTcpDriverCommon.resetLocked(fArgs.fTcpDeviceDataSentLog.fXmlNode);

                // --

                fArgs.fTcpDeviceDataSentLog.fXmlNode.set_attrVal(FXmlTagTDVL.A_Time, FXmlTagTDVL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fTcdCore.fLogWriter.pushTcpLog(fArgs.fTcpDeviceDataSentLog.fXmlNode);

                // --

                if (TcpDeviceDataSent != null)
                {
                    TcpDeviceDataSent(this, fArgs);
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

        internal void onTcpDeviceXmlReceived(
            FEventArgsBase fArgsBase
            )
        {
            FTcpDeviceXmlReceivedEventArgs fArgs = null;

            try
            {
                fArgs = (FTcpDeviceXmlReceivedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FTcpDriverCommon.resetLocked(fArgs.fTcpDeviceXmlReceivedLog.fXmlNode);

                // --

                fArgs.fTcpDeviceXmlReceivedLog.fXmlNode.set_attrVal(FXmlTagXMLL.A_Time, FXmlTagXMLL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fTcdCore.fLogWriter.pushTcpLog(fArgs.fTcpDeviceXmlReceivedLog.fXmlNode);

                // --

                if (TcpDeviceXmlReceived != null)
                {
                    TcpDeviceXmlReceived(this, fArgs);
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

        internal void onTcpDeviceXmlSent(
            FEventArgsBase fArgsBase
            )
        {
            FTcpDeviceXmlSentEventArgs fArgs = null;

            try
            {
                fArgs = (FTcpDeviceXmlSentEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FTcpDriverCommon.resetLocked(fArgs.fTcpDeviceXmlSentLog.fXmlNode);

                // --

                fArgs.fTcpDeviceXmlSentLog.fXmlNode.set_attrVal(FXmlTagXMLL.A_Time, FXmlTagXMLL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fTcdCore.fLogWriter.pushTcpLog(fArgs.fTcpDeviceXmlSentLog.fXmlNode);

                // --

                if (TcpDeviceXmlSent != null)
                {
                    TcpDeviceXmlSent(this, fArgs);
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

        internal void onTcpDeviceErrorRaised(
            FEventArgsBase fArgsBase
            )
        {
            FTcpDeviceErrorRaisedEventArgs fArgs = null;

            try
            {
                fArgs = (FTcpDeviceErrorRaisedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FTcpDriverCommon.resetLocked(fArgs.fTcpDeviceErrorRaisedLog.fXmlNode);

                // --

                fArgs.fTcpDeviceErrorRaisedLog.fXmlNode.set_attrVal(FXmlTagTDEL.A_Time, FXmlTagTDEL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fTcdCore.fLogWriter.pushTcpLog(fArgs.fTcpDeviceErrorRaisedLog.fXmlNode);

                // --

                if (TcpDeviceErrorRaised != null)
                {
                    TcpDeviceErrorRaised(this, fArgs);
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

        internal void onTcpDeviceTimeoutRaised(
            FEventArgsBase fArgsBase
            )
        {
            FTcpDeviceTimeoutRaisedEventArgs fArgs = null;

            try
            {
                fArgs = (FTcpDeviceTimeoutRaisedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FTcpDriverCommon.resetLocked(fArgs.fTcpDeviceTimeoutRaisedLog.fXmlNode);

                // --

                fArgs.fTcpDeviceTimeoutRaisedLog.fXmlNode.set_attrVal(FXmlTagTDTL.A_Time, FXmlTagTDTL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fTcdCore.fLogWriter.pushTcpLog(fArgs.fTcpDeviceTimeoutRaisedLog.fXmlNode);

                // --

                if (TcpDeviceTimeoutRaised != null)
                {
                    TcpDeviceTimeoutRaised(this, fArgs);
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

        internal void onTcpDeviceDataMessageReceived(
            FEventArgsBase fArgsBase
            )
        {
            FTcpDeviceDataMessageReceivedEventArgs fArgs = null;

            try
            {
                fArgs = (FTcpDeviceDataMessageReceivedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FTcpDriverCommon.resetLocked(fArgs.fTcpDeviceDataMessageReceivedLog.fXmlNode);

                // --

                fArgs.fTcpDeviceDataMessageReceivedLog.fXmlNode.set_attrVal(FXmlTagTMGL.A_Time, FXmlTagTMGL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                // Modify by Jeff.Kim 2015.09.17
                // Modeling 에서 Log Enable 되었을 경우만 Log Write
                // --
                if (fArgs.fTcpDeviceDataMessageReceivedLog.logEnabled && confirmlogLevelEnabled(fArgs.fTcpDeviceDataMessageReceivedLog.logLevel))
                {
                    this.fTcdCore.fLogWriter.pushTcpLog(fArgs.fTcpDeviceDataMessageReceivedLog.fXmlNode);
                }

                // --

                if (TcpDeviceDataMessageReceived != null)
                {
                    TcpDeviceDataMessageReceived(this, fArgs);
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

        internal void onTcpDeviceDataMessageSent(
            FEventArgsBase fArgsBase
            )
        {
            FTcpDeviceDataMessageSentEventArgs fArgs = null;

            try
            {
                fArgs = (FTcpDeviceDataMessageSentEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FTcpDriverCommon.resetLocked(fArgs.fTcpDeviceDataMessageSentLog.fXmlNode);

                // --

                fArgs.fTcpDeviceDataMessageSentLog.fXmlNode.set_attrVal(FXmlTagTMGL.A_Time, FXmlTagTMGL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                // Modify by Jeff.Kim 2015.09.17
                // Modeling 에서 Log Enable 되었을 경우만 Log Write
                if (fArgs.fTcpDeviceDataMessageSentLog.logEnabled && confirmlogLevelEnabled(fArgs.fTcpDeviceDataMessageSentLog.logLevel))
                {
                    this.fTcdCore.fLogWriter.pushTcpLog(fArgs.fTcpDeviceDataMessageSentLog.fXmlNode);
                }
                // --

                if (TcpDeviceDataMessageSent != null)
                {
                    TcpDeviceDataMessageSent(this, fArgs);
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
                FTcpDriverCommon.resetLocked(fArgs.fHostDeviceStateChangedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Host Device State Changed Log Write
                // ***
                fArgs.fHostDeviceStateChangedLog.fXmlNode.set_attrVal(FXmlTagHDVL.A_Time, FXmlTagHDVL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fTcdCore.fLogWriter.pushTcpLog(fArgs.fHostDeviceStateChangedLog.fXmlNode);

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
                FTcpDriverCommon.resetLocked(fArgs.fHostDeviceErrorRaisedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Host Device Error Raised Log Write
                // ***
                fArgs.fHostDeviceErrorRaisedLog.fXmlNode.set_attrVal(FXmlTagHDEL.A_Time, FXmlTagHDEL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fTcdCore.fLogWriter.pushTcpLog(fArgs.fHostDeviceErrorRaisedLog.fXmlNode);

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
                FTcpDriverCommon.resetLocked(fArgs.fHostDeviceVfeiReceivedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Host Device VFEI Received Log Write
                // ***
                fArgs.fHostDeviceVfeiReceivedLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_Time, FXmlTagVFEL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fTcdCore.fLogWriter.pushTcpLog(fArgs.fHostDeviceVfeiReceivedLog.fXmlNode);

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
                FTcpDriverCommon.resetLocked(fArgs.fHostDeviceVfeiSentLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Host Device VFEI Sent Log Write
                // ***
                fArgs.fHostDeviceVfeiSentLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_Time, FXmlTagVFEL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fTcdCore.fLogWriter.pushTcpLog(fArgs.fHostDeviceVfeiSentLog.fXmlNode);

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
                FTcpDriverCommon.resetLocked(fArgs.fHostDeviceDataMessageReceivedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Host Device Data Message Received Log Write
                // ***
                fArgs.fHostDeviceDataMessageReceivedLog.fXmlNode.set_attrVal(FXmlTagHMGL.A_Time, FXmlTagHMGL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fHostDeviceDataMessageReceivedLog.logEnabled && confirmlogLevelEnabled(fArgs.fHostDeviceDataMessageReceivedLog.logLevel))
                {
                    this.fTcdCore.fLogWriter.pushTcpLog(fArgs.fHostDeviceDataMessageReceivedLog.fXmlNode);
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
                FTcpDriverCommon.resetLocked(fArgs.fHostDeviceDataMessageSentLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Host Device Data Message Sent Log Write
                // ***
                fArgs.fHostDeviceDataMessageSentLog.fXmlNode.set_attrVal(FXmlTagHMGL.A_Time, FXmlTagHMGL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fHostDeviceDataMessageSentLog.logEnabled && confirmlogLevelEnabled(fArgs.fHostDeviceDataMessageSentLog.logLevel))
                {
                    // --
                    this.fTcdCore.fLogWriter.pushTcpLog(fArgs.fHostDeviceDataMessageSentLog.fXmlNode);
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

        internal void onTcpTriggerRaised(
            FEventArgsBase fArgsBase
            )
        {
            FTcpTriggerRaisedEventArgs fArgs = null;

            try
            {
                fArgs = (FTcpTriggerRaisedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FTcpDriverCommon.resetLocked(fArgs.fTcpTriggerRaisedLog.fXmlNode);

                // --

                // ***
                // TCP Trigger Raised Log Write
                // ***
                fArgs.fTcpTriggerRaisedLog.fXmlNode.set_attrVal(FXmlTagTTRL.A_Time, FXmlTagTTRL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    this.fTcdCore.fLogWriter.pushTcpLog(fArgs.fTcpTriggerRaisedLog.fXmlNode);
                }

                // --

                if (TcpTriggerRaised != null)
                {
                    TcpTriggerRaised(this, fArgs);
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

        internal void onTcpTransmitterRaised(
            FEventArgsBase fArgsBase
            )
        {
            FTcpTransmitterRaisedEventArgs fArgs = null;

            try
            {
                fArgs = (FTcpTransmitterRaisedEventArgs)fArgsBase;

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FTcpDriverCommon.resetLocked(fArgs.fTcpTransmitterRaisedLog.fXmlNode);

                // --

                // ***
                // TCP Transmitter Raised Log Write
                // ***
                fArgs.fTcpTransmitterRaisedLog.fXmlNode.set_attrVal(FXmlTagTTNL.A_Time, FXmlTagTTNL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    this.fTcdCore.fLogWriter.pushTcpLog(fArgs.fTcpTransmitterRaisedLog.fXmlNode);
                }

                // --

                if (TcpTransmitterRaised != null)
                {
                    TcpTransmitterRaised(this, fArgs);
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
                FTcpDriverCommon.resetLocked(fArgs.fHostTriggerRaisedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Host Trigger Raised Log Write
                // ***
                fArgs.fHostTriggerRaisedLog.fXmlNode.set_attrVal(FXmlTagHTRL.A_Time, FXmlTagHTRL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    this.fTcdCore.fLogWriter.pushTcpLog(fArgs.fHostTriggerRaisedLog.fXmlNode);
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
                FTcpDriverCommon.resetLocked(fArgs.fHostTransmitterRaisedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Host Transmitter Raised Log Write
                // ***
                fArgs.fHostTransmitterRaisedLog.fXmlNode.set_attrVal(FXmlTagHTNL.A_Time, FXmlTagHTNL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    // --
                    this.fTcdCore.fLogWriter.pushTcpLog(fArgs.fHostTransmitterRaisedLog.fXmlNode);
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
                FTcpDriverCommon.resetLocked(fArgs.fJudgementPerformedLog.fXmlNode);

                // --

                // ***
                // Judgement Performed Log Write
                // ***
                fArgs.fJudgementPerformedLog.fXmlNode.set_attrVal(FXmlTagJDML.A_Time, FXmlTagJDML.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {                    
                    this.fTcdCore.fLogWriter.pushTcpLog(fArgs.fJudgementPerformedLog.fXmlNode);
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
                FTcpDriverCommon.resetLocked(fArgs.fMapperPerformedLog.fXmlNode);

                // --

                // ***
                // Mapper Performed Log Write
                // ***
                fArgs.fMapperPerformedLog.fXmlNode.set_attrVal(FXmlTagMAPL.A_Time, FXmlTagMAPL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {                    
                    this.fTcdCore.fLogWriter.pushTcpLog(fArgs.fMapperPerformedLog.fXmlNode);
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
                FTcpDriverCommon.resetLocked(fArgs.fEquipmentStateSetAltererPerformedLog.fXmlNode);

                // --

                // ***
                // Equipment State Set Alterer Performed Log Write
                // ***
                fArgs.fEquipmentStateSetAltererPerformedLog.fXmlNode.set_attrVal(FXmlTagESAL.A_Time, FXmlTagESAL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {                    
                    this.fTcdCore.fLogWriter.pushTcpLog(fArgs.fEquipmentStateSetAltererPerformedLog.fXmlNode);
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
                FTcpDriverCommon.resetLocked(fArgs.fStoragePerformedLog.fXmlNode);

                // --

                // ***
                // Storage Performed Log Write
                // ***
                fArgs.fStoragePerformedLog.fXmlNode.set_attrVal(FXmlTagSTGL.A_Time, FXmlTagSTGL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {                    
                    this.fTcdCore.fLogWriter.pushTcpLog(fArgs.fStoragePerformedLog.fXmlNode);
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
                FTcpDriverCommon.resetLocked(fArgs.fCallbackRaisedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Callback Raised Log Write
                // ***
                fArgs.fCallbackRaisedLog.fXmlNode.set_attrVal(FXmlTagCBKL.A_Time, FXmlTagCBKL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {                    
                    this.fTcdCore.fLogWriter.pushTcpLog(fArgs.fCallbackRaisedLog.fXmlNode);
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
                FTcpDriverCommon.resetLocked(fArgs.fFunctionCalledLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Function Called Log Write
                // ***
                fArgs.fFunctionCalledLog.fXmlNode.set_attrVal(FXmlTagFUNL.A_Time, FXmlTagFUNL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {                    
                    this.fTcdCore.fLogWriter.pushTcpLog(fArgs.fFunctionCalledLog.fXmlNode);
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
                FTcpDriverCommon.resetLocked(fArgs.fBranchRaisedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Bransh Raised Log Write
                // ***
                fArgs.fBranchRaisedLog.fXmlNode.set_attrVal(FXmlTagBRNL.A_Time, FXmlTagBRNL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {                    
                    this.fTcdCore.fLogWriter.pushTcpLog(fArgs.fBranchRaisedLog.fXmlNode);
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
                FTcpDriverCommon.resetLocked(fArgs.fCommentWrittenLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Comment Written Log Write
                // ***
                fArgs.fCommentWrittenLog.fXmlNode.set_attrVal(FXmlTagCMTL.A_Time, FXmlTagCMTL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {                    
                    this.fTcdCore.fLogWriter.pushTcpLog(fArgs.fCommentWrittenLog.fXmlNode);
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
                FTcpDriverCommon.resetLocked(fArgs.fPauserRaisedLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Comment Written Log Write
                // ***
                fArgs.fPauserRaisedLog.fXmlNode.set_attrVal(FXmlTagPAUL.A_Time, FXmlTagPAUL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {                    
                    this.fTcdCore.fLogWriter.pushTcpLog(fArgs.fPauserRaisedLog.fXmlNode);
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
                FTcpDriverCommon.resetLocked(fArgs.fEntryPointCalledLog.fXmlNode);

                // --

                fArgs.fEntryPointCalledLog.fXmlNode.set_attrVal(FXmlTagETPL.A_Time, FXmlTagETPL.D_Time, FDataConvert.defaultNowDateTimeToString());
                if (fArgs.fScenarioData.fScenario.logEnabled && confirmlogLevelEnabled(fArgs.fScenarioData.fScenario.logLevel))
                {
                    this.fTcdCore.fLogWriter.pushTcpLog(fArgs.fEntryPointCalledLog.fXmlNode);
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
                FTcpDriverCommon.resetLocked(fArgs.fApplicationWrittenLog.fXmlNode);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // Application Written Log Write
                // ***
                fArgs.fApplicationWrittenLog.fXmlNode.set_attrVal(FXmlTagCMTL.A_Time, FXmlTagCMTL.D_Time, FDataConvert.defaultNowDateTimeToString());
                // --
                this.fTcdCore.fLogWriter.pushTcpLog(fArgs.fApplicationWrittenLog.fXmlNode);

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
                if (!this.fTcdCore.fConfig.enabledEventsOfApplication)
                {
                    return;
                }

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Log Object의 Lock 제거
                // ***
                FTcpDriverCommon.resetLocked(fApplicationWrittenLog.fXmlNode);

                // --
                
                this.fTcdCore.fEventPusher.pushApplicationWrittenEvent(fApplicationWrittenLog.fXmlNode);
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
