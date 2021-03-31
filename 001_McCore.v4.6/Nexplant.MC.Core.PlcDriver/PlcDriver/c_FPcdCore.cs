/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPcdCore.cs
--  Creator         : spike.lee
--  Create Date     : 2013.07.10
--  Description     : FAMate Core FaPlcDriver PLC Driver Core Class 
--  History         : Created by spike.lee at 2013.07.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using System.Collections.Generic;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal class FPcdCore : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------       

        public event FModelingFileChangedEventHandler ModelingFileChanged = null;

        //--
        private bool m_disposed = false;
        // --
        private static FIDPointer32 m_fPcdCoreIdPointer = null;
        private UInt32 m_fPcdCoreId = 0;
        // --
        private FPlcDriver m_fPlcDriver = null;
        private FXmlDocument m_fXmlDoc = null;
        private FXmlNode m_fXmlNodePcd = null;
        private FIDPointer64 m_fIdPointer = null;
        private FIDPointer64 m_fRpmIdPointer = null;    // 2017.04.04 by spike.lee Repository Material Save 구현
        // --
        private FConfig m_fConfig = null;
        private FLogWriter m_fLogWriter = null;
        private FProtocolAgent m_fProtocolAgent = null;      
        private FEventPusher m_fEventPusher = null;
        private FRepositoryMaterialStorage m_fRepositoryMaterialStorage = null;
        private FEquipmentStateMaterialStorage m_fEquipmentStateMaterialStorage = null;

        //------------------------------------------------------------------------------------------------------------------------       

        #region Class Construction and Destruction

         public FPcdCore(
            )
        {
            init();              
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPcdCore(
            FXmlDocument fXmlDoc
            )
        {
            init(fXmlDoc);
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPcdCore(
           )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    term();
                }                
                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------       

        #region IDisposable 멤버

        public void Dispose(
            )
        {
            myDispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------       

        #region Properties

        public FPlcDriver fPlcDriver
        {
            get
            {
                try
                {
                    return m_fPlcDriver;
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

            set
            {
                try
                {
                    m_fPlcDriver = value;
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

        public FXmlDocument fXmlDoc
        {
            get
            {
                try
                {
                    return m_fXmlDoc;
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

        public FXmlNode fXmlNodePcd
        {
            get
            {
                try
                {
                    return m_fXmlNodePcd;
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

        public FIDPointer64 fIdPointer
        {
            get
            {
                try
                {
                    return m_fIdPointer;
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

        public FLogWriter fLogWriter
        {
            get
            {
                try
                {
                    return m_fLogWriter;
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

        public FProtocolAgent fProtocolAgent
        {
            get
            {
                try
                {
                    return m_fProtocolAgent;
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

        public FEventPusher fEventPusher
        {
            get
            {
                try
                {
                    return m_fEventPusher;
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
                    return m_fRepositoryMaterialStorage;
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
                    return m_fEquipmentStateMaterialStorage;
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

        public FConfig fConfig
        {
            get
            {
                try
                {
                    return m_fConfig;
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

        public FIDPointer64 fRpmIdPointer
        {
            get
            {
                // ***
                // 2017.04.04 by spike.lee
                // Repository Material Save 구현
                // ***
                try
                {
                    return m_fRpmIdPointer;
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

        // ***
        // New Object Init
        // ***
        private void init(
            )
        {
            FDebugLogArgs fDebugLogArgs = null;
            FXmlNode fXmlNodeFam = null;
            FXmlNode fXmlNodePcd = null;
            FXmlNode fXmlNodeSet = null;
            FXmlNode fXmlNodeOnd = null;
            FXmlNode fXmlNodeOnl = null;
            FXmlNode fXmlNodeUtd = null;
            FXmlNode fXmlNodeUtn = null;          

            try
            {
                if (m_fPcdCoreIdPointer == null)
                {
                    m_fPcdCoreIdPointer = new FIDPointer32();
                }
                m_fPcdCoreId = m_fPcdCoreIdPointer.uniqueId;

                // --

                // ***
                // FPcdCore Creation Log Write
                // ***               
                fDebugLogArgs = new FDebugLogArgs(FDebugLogCategory.Information, "FPcdCoreCreate", this.GetType(), "init");
                fDebugLogArgs.additionInfo = "FPcdCoreId=<" + m_fPcdCoreId.ToString() + ">";
                FDebug.writeLog(fDebugLogArgs);

                // --

                // ***
                // Default Modeling Document Create
                // ***
                m_fIdPointer = new FIDPointer64();
                m_fXmlDoc = new FXmlDocument();
                m_fXmlDoc.preserveWhiteSpace = false;
                m_fXmlDoc.appendChild(m_fXmlDoc.createXmlDeclaration("1.0", string.Empty, string.Empty));

                // --

                fXmlNodeFam = m_fXmlDoc.appendChild(FPlcDriverCommon.createXmlNodeFAM(m_fXmlDoc));
                // --
                fXmlNodePcd = fXmlNodeFam.appendChild(FPlcDriverCommon.createXmlNodePCD(m_fXmlDoc));
                fXmlNodePcd.set_attrVal(FXmlTagPCD.A_UniqueId, FXmlTagPCD.D_UniqueId, m_fIdPointer.uniqueId.ToString());

                // --

                // ***
                // 기본 Setup Object 생성
                // ***
                fXmlNodeSet = fXmlNodePcd.appendChild(FPlcDriverCommon.createXmlNodeSET(m_fXmlDoc));
                // --
                fXmlNodeOnd = fXmlNodeSet.appendChild(FPlcDriverCommon.createXmlNodeOND(m_fXmlDoc));   // Object Name Definition
                foreach (FObjectType type in Enum.GetValues(typeof(FObjectType)))
                {
                    fXmlNodeOnl = fXmlNodeOnd.appendChild(FPlcDriverCommon.createXmlNodeONL(m_fXmlDoc));
                    fXmlNodeOnl.set_attrVal(FXmlTagONL.A_UniqueId, FXmlTagONL.D_UniqueId, m_fIdPointer.uniqueId.ToString());
                    fXmlNodeOnl.set_attrVal(FXmlTagONL.A_Name, FXmlTagONL.D_Name, type.ToString());
                    fXmlNodeOnl.set_attrVal(FXmlTagONL.A_ObjectType, FXmlTagONL.D_ObjectType, type.ToString());
                }
                // --
                fXmlNodeSet.appendChild(FPlcDriverCommon.createXmlNodeFND(m_fXmlDoc));                 // Function Name Definition
                // --
                fXmlNodeUtd = fXmlNodeSet.appendChild(FPlcDriverCommon.createXmlNodeUTD(m_fXmlDoc));   // User Tag Definition
                foreach (FObjectType type in Enum.GetValues(typeof(FObjectType)))
                {
                    fXmlNodeUtn = fXmlNodeUtd.appendChild(FPlcDriverCommon.createXmlNodeUTN(m_fXmlDoc));
                    fXmlNodeUtn.set_attrVal(FXmlTagUTN.A_UniqueId, FXmlTagUTN.D_UniqueId, m_fIdPointer.uniqueId.ToString());
                    fXmlNodeUtn.set_attrVal(FXmlTagUTN.A_Name, FXmlTagUTN.D_Name, type.ToString());
                    fXmlNodeUtn.set_attrVal(FXmlTagUTN.A_ObjectType, FXmlTagUTN.D_ObjectType, type.ToString());
                }

                fXmlNodeSet.appendChild(FPlcDriverCommon.createXmlNodeDCD(m_fXmlDoc));     // Data Conversion Set Definition
                fXmlNodeSet.appendChild(FPlcDriverCommon.createXmlNodeESD(m_fXmlDoc));     // Equipment State Set Definition
                fXmlNodeSet.appendChild(FPlcDriverCommon.createXmlNodeRPD(m_fXmlDoc));     // Repository Definition           
                fXmlNodeSet.appendChild(FPlcDriverCommon.createXmlNodeEND(m_fXmlDoc));     // Environment Definition
                fXmlNodeSet.appendChild(FPlcDriverCommon.createXmlNodeDSD(m_fXmlDoc));     // Data Set Definition

                // --

                // ***
                // 기본 Modeling Object 생성
                // ***
                fXmlNodePcd.appendChild(FPlcDriverCommon.createXmlNodePLM(m_fXmlDoc));     // PLC Library Modeling
                fXmlNodePcd.appendChild(FPlcDriverCommon.createXmlNodePDM(m_fXmlDoc));     // PLC Device Modeling
                fXmlNodePcd.appendChild(FPlcDriverCommon.createXmlNodeHLM(m_fXmlDoc));     // Host Library Modeling               
                fXmlNodePcd.appendChild(FPlcDriverCommon.createXmlNodeHDM(m_fXmlDoc));     // Host Device Modeling               
                fXmlNodePcd.appendChild(FPlcDriverCommon.createXmlNodeEQM(m_fXmlDoc));     // Equipment Modeling
                
                // --

                m_fXmlNodePcd = fXmlNodePcd;

                // --

                initCommon();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeFam != null)
                {
                    fXmlNodeFam.Dispose();
                    fXmlNodeFam = null;
                }
                fXmlNodePcd = null;

                // --

                if (fXmlNodeSet != null)
                {
                    fXmlNodeSet.Dispose();
                    fXmlNodeSet = null;
                }
                if (fXmlNodeOnd != null)
                {
                    fXmlNodeOnd.Dispose();
                    fXmlNodeOnd = null;
                }
                if (fXmlNodeOnl != null)
                {
                    fXmlNodeOnl.Dispose();
                    fXmlNodeOnl = null;
                }
                if (fXmlNodeUtd != null)
                {
                    fXmlNodeUtd.Dispose();
                    fXmlNodeUtd = null;
                }
                if (fXmlNodeUtn != null)
                {
                    fXmlNodeUtn.Dispose();
                    fXmlNodeUtn = null;
                }   
            }
        }

        //------------------------------------------------------------------------------------------------------------------------       

        // ***
        // Clone Object init
        // ***
        private void init(
            FXmlDocument fXmlDoc
            )
        {
            FDebugLogArgs fDebugLogArgs = null;
            FXmlNode fXmlNodeFam = null;

            try
            {
                if (m_fPcdCoreIdPointer == null)
                {
                    m_fPcdCoreIdPointer = new FIDPointer32();
                }
                m_fPcdCoreId = m_fPcdCoreIdPointer.uniqueId;

                // --

                // ***
                // FPcdCore Creation Log Write
                // ***               
                fDebugLogArgs = new FDebugLogArgs(FDebugLogCategory.Information, "FPcdCoreCreate", this.GetType(), "init");
                fDebugLogArgs.additionInfo = "FPcdCoreId=<" + m_fPcdCoreId.ToString() + ">";
                FDebug.writeLog(fDebugLogArgs);

                // --

                m_fXmlDoc = fXmlDoc;

                // --

                fXmlNodeFam = m_fXmlDoc.selectSingleNode(FXmlTagFAM.E_FAMate);
                m_fXmlNodePcd = fXmlNodeFam.selectSingleNode(FXmlTagPCD.E_PlcDriver);

                // --

                // ***
                // 2012.11.19 by spike.lee
                // SECS Device나 Host Device가 Closed 상태가 아닌 상태에서 SECS Driver를 Clone할 경우
                // 기존 SECS Driver의 SECS Device와 Host Device의 State가 유지되어 State 정보가 잘 못 설정됩니다.
                // 그렇기 때문에 SECS Driver를 Clone한 후에 SECS Device와 Host Device의 State를 Closed로 초기화 했어야 합니다.
                // ***
                resetDeviceState();

                // --

                m_fIdPointer = new FIDPointer64(UInt64.Parse(fXmlNodeFam.get_attrVal(FXmlTagFAM.A_UniqueIdPointer, FXmlTagFAM.D_UniqueIdPointer)));

                // --

                initCommon();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeFam != null)
                {
                    fXmlNodeFam.Dispose();
                    fXmlNodeFam = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------       

        private void initCommon(
            )
        {
            try
            {
                m_fConfig = new FConfig();

                // --

                m_fConfig.eapName = m_fXmlNodePcd.get_attrVal(FXmlTagPCD.A_EapName, FXmlTagPCD.D_EapName);

                // --

                m_fLogWriter = new FLogWriter(this);
                m_fProtocolAgent = new FProtocolAgent(this);
                m_fRepositoryMaterialStorage = new FRepositoryMaterialStorage(this);
                m_fEquipmentStateMaterialStorage = new FEquipmentStateMaterialStorage(this);

                // --

                // ***
                // Repository Material Auto Remove 구현으로 Event Pusher 생성 위치 변경
                // ***
                m_fEventPusher = new FEventPusher(this);

                // --

                // ***
                // 2017.04.04 by spike.lee
                // Repository Material Save 구현
                // ***
                m_fRpmIdPointer = new FIDPointer64();
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

        private void term(
            )
        {
            FDebugLogArgs fDebugLogArgs = null;

            try
            {
                if (m_fProtocolAgent != null)
                {
                    m_fProtocolAgent.Dispose();
                    m_fProtocolAgent = null;
                }

                // --

                if (m_fEventPusher != null)
                {
                    m_fEventPusher.Dispose();
                    m_fEventPusher = null;
                }

                if (m_fRepositoryMaterialStorage != null)
                {
                    m_fRepositoryMaterialStorage.Dispose();
                    m_fRepositoryMaterialStorage = null;
                }

                // --

                if (m_fLogWriter != null)
                {
                    m_fLogWriter.Dispose();
                    m_fLogWriter = null;
                }

                // --

                m_fPlcDriver = null;

                if (m_fXmlNodePcd != null)
                {
                    m_fXmlNodePcd.Dispose();
                    m_fXmlNodePcd = null;
                }

                if (m_fXmlDoc != null)
                {
                    m_fXmlDoc.Dispose();
                    m_fXmlDoc = null;
                }

                if (m_fIdPointer != null)
                {
                    m_fIdPointer.Dispose();
                    m_fIdPointer = null;
                }

                // ***
                // 2017.04.04 by spike.lee
                // Repository Material Save 구현
                // ***
                if (m_fRpmIdPointer != null)
                {
                    m_fRpmIdPointer.Dispose();
                    m_fRpmIdPointer = null;
                }

                // -- 

                // ***
                // FPcdCore Termination Log Write
                // ***
                fDebugLogArgs = new FDebugLogArgs(FDebugLogCategory.Information, "FPcdCoreTerminate", this.GetType(), "term");
                fDebugLogArgs.additionInfo = "FPcdCoreId=<" + m_fPcdCoreId.ToString() + ">";
                FDebug.writeLog(fDebugLogArgs);                
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

        private void resetDeviceState(
            )
        {
            try
            {
                // ***
                // Plc Device State를 Closed로 초기화
                // ***
                foreach (FXmlNode fXmlNodeSdv in m_fXmlNodePcd.selectNodes(FXmlTagPDM.E_PlcDeviceModeling + "/" + FXmlTagPDV.E_PlcDevice))
                {
                    fXmlNodeSdv.set_attrVal(FXmlTagPDV.A_State, FXmlTagPDV.D_State, FEnumConverter.fromDeviceState(FDeviceState.Closed));
                }

                // ***
                // Host Device State를 Closed로 초기화
                // ***
                foreach (FXmlNode fXmlNodeHdv in m_fXmlNodePcd.selectNodes(FXmlTagHDM.E_HostDeviceModeling + "/" + FXmlTagHDV.E_HostDevice))
                {
                    fXmlNodeHdv.set_attrVal(FXmlTagHDV.A_State, FXmlTagHDV.D_State, FEnumConverter.fromDeviceState(FDeviceState.Closed));
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

        public void openModelingFile(
            string fileName
            )
        {
            try
            {
                loadModelingFile(fileName);
                
                // -- 

                resetDeviceState();

                // --

                // ***
                // Modeling File Open Completed Event
                // ***
                m_fEventPusher.pushEvent(
                    new FModelingFileOpenCompletedEventArgs(FEventId.ModelingFileOpenCompleted, m_fPlcDriver, fileName)
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

        public bool reopenModelingFile(
            string fileName
            )
        {
            FPlcDriver fNewPdr = null;            
            string message = string.Empty;

            try
            {
                // ***
                // 새로운 Modeling File를 Open 한다.
                // ***
                fNewPdr = new FPlcDriver();
                fNewPdr.openModelingFile(fileName);

                // --

                if (!validateReopenModelingFile(m_fPlcDriver, fNewPdr, ref message))
                {
                    m_fEventPusher.pushEvent(
                        new FModelingFileReopenFailedEventArgs(FEventId.ModelingFileReopenFailed, m_fPlcDriver, fileName, message)
                        );
                    // --
                    return false;
                }

                // --

                fNewPdr.Dispose();
                fNewPdr = null;

                // --

                m_fProtocolAgent.pauseProtocol();
                m_fEventPusher.waitEventHandlingCompleted();

                // --

                loadModelingFile(fileName);
                onModelingFileChanged();
                
                // --

                m_fPlcDriver.onModelingFileReopenPrecompleted(new FModelingFileReopenPrecompletedEventArgs(m_fPlcDriver, fileName));
                m_fProtocolAgent.continueProtocol();

                // --

                m_fEventPusher.pushEvent(
                    new FModelingFileReopenCompletedEventArgs(FEventId.ModelingFileReopenCompleted, m_fPlcDriver, fileName)
                    );

                // --

                return true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fNewPdr != null)
                {
                    fNewPdr.Dispose();
                    fNewPdr = null;
                }
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void saveModelingFile(
            string fileName
            )
        {
            FXmlNode fXmlNodeFam = null;

            try
            {
                fXmlNodeFam = m_fXmlDoc.selectSingleNode(FXmlTagFAM.E_FAMate);
                fXmlNodeFam.set_attrVal(FXmlTagFAM.A_UniqueIdPointer, FXmlTagFAM.D_UniqueIdPointer, m_fIdPointer.currentId.ToString());
                fXmlNodeFam.set_attrVal(FXmlTagFAM.A_FileUpdateTime, FXmlTagFAM.D_FileUpdateTime, FDataConvert.defaultNowDateTimeToString());

                // --

                m_fXmlDoc.save(fileName);

                // --

                // ***
                // Modeling File Save Completed Event
                // ***
                m_fEventPusher.pushEvent(
                    new FModelingFileSaveCompletedEventArgs(FEventId.ModelingFileSaveCompleted, m_fPlcDriver, fileName)
                    );
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeFam != null)
                {
                    fXmlNodeFam.Dispose();
                    fXmlNodeFam = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadModelingFile(
            string fileName
            )
        {
            FIDPointer64 fNewIdPointer = null;            
            FXmlNode fXmlNodeFam = null;
            FXmlNode fXmlNodePcd = null;

            try
            {
                fNewIdPointer = new FIDPointer64();
                if (m_fXmlDoc == null)
                {
                    m_fXmlDoc = new FXmlDocument();
                    m_fXmlDoc.preserveWhiteSpace = false;
                }                
                m_fXmlDoc.load(fileName);

                // --

                fXmlNodeFam = m_fXmlDoc.selectSingleNode(FXmlTagFAM.E_FAMate);
                fNewIdPointer.reset(UInt64.Parse(fXmlNodeFam.get_attrVal(FXmlTagFAM.A_UniqueIdPointer, FXmlTagFAM.D_UniqueIdPointer)));
                // --
                fXmlNodePcd = fXmlNodeFam.selectSingleNode(FXmlTagPCD.E_PlcDriver);

                // --                

                if (m_fIdPointer != null)
                {
                    m_fIdPointer.Dispose();
                    m_fIdPointer = null;
                }

                // --

                m_fIdPointer = fNewIdPointer;                
                m_fXmlNodePcd = fXmlNodePcd;
                // --
                this.fPlcDriver.replace(this, m_fXmlNodePcd);

                // --

                // ***
                // 2012.11.19 by spike.lee
                // FLogWriter Class에서 사용될 EAP Name 설정
                // ***
                m_fConfig.eapName = m_fXmlNodePcd.get_attrVal(FXmlTagPCD.A_EapName, FXmlTagPCD.D_EapName);

                // --

                // ***
                // Modeling File Structure Migration
                // ***
                migrateModelingStructure();
                restoreObjectNameList();
                restoreUserTagName();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fNewIdPointer = null;                
                fXmlNodeFam = null;
                fXmlNodePcd = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void migrateModelingStructure(
            )
        {
            FXmlNode fXmlNodeSet = null;
            FXmlNode fXmlNodeOnd = null;
            FXmlNode fXmlNodeFnd = null;
            FXmlNode fXmlNodeUtd = null;
            FXmlNode fXmlNodeDcd = null;
            FXmlNode fXmlNodeEsd = null;
            FXmlNode fXmlNodeRpd = null;
            FXmlNode fXmlNodeEnd = null;
            FXmlNode fXmlNodeDsd = null;
            // --
            FXmlNode fXmlNodePlm = null;
            FXmlNode fXmlNodePdm = null;
            // --
            string xpath = string.Empty;

            try
            {
                // ***
                // Setup 계열
                // ***
                fXmlNodeSet = m_fXmlNodePcd.selectSingleNode(FXmlTagSET.E_Setup);
                if (fXmlNodeSet == null)
                {
                    fXmlNodeSet = m_fXmlNodePcd.appendChild(FPlcDriverCommon.createXmlNodeSET(m_fXmlDoc));
                }
                // --
                fXmlNodeOnd = fXmlNodeSet.selectSingleNode(FXmlTagOND.E_ObjectNameDefinition);
                if (fXmlNodeOnd == null)
                {
                    fXmlNodeOnd = fXmlNodeSet.appendChild(FPlcDriverCommon.createXmlNodeOND(m_fXmlDoc));
                }
                // --
                fXmlNodeFnd = fXmlNodeSet.selectSingleNode(FXmlTagFND.E_FunctionNameDefinition);
                if (fXmlNodeFnd == null)
                {
                    fXmlNodeFnd = fXmlNodeSet.appendChild(FPlcDriverCommon.createXmlNodeFND(m_fXmlDoc));
                }
                // --
                fXmlNodeUtd = fXmlNodeSet.selectSingleNode(FXmlTagUTD.E_UserTagNameDefinition);
                if (fXmlNodeUtd == null)
                {
                    fXmlNodeUtd = fXmlNodeSet.appendChild(FPlcDriverCommon.createXmlNodeUTD(m_fXmlDoc));
                }
                // --
                fXmlNodeDcd = fXmlNodeSet.selectSingleNode(FXmlTagDCD.E_DataConversionSetDefinition);
                if (fXmlNodeDcd == null)
                {
                    fXmlNodeDcd = fXmlNodeSet.appendChild(FPlcDriverCommon.createXmlNodeDCD(m_fXmlDoc));
                }
                // --
                fXmlNodeEsd = fXmlNodeSet.selectSingleNode(FXmlTagESD.E_EquipmentStateSetDefinition);
                if (fXmlNodeEsd == null)
                {
                    fXmlNodeEsd = fXmlNodeSet.appendChild(FPlcDriverCommon.createXmlNodeESD(m_fXmlDoc));
                }
                // --
                fXmlNodeRpd = fXmlNodeSet.selectSingleNode(FXmlTagRPD.E_RepositoryDefinition);
                if (fXmlNodeRpd == null)
                {
                    fXmlNodeRpd = fXmlNodeSet.appendChild(FPlcDriverCommon.createXmlNodeRPD(m_fXmlDoc));
                }
                // --
                fXmlNodeEnd = fXmlNodeSet.selectSingleNode(FXmlTagEND.E_EnvironmentDefinition);
                if (fXmlNodeEnd == null)
                {
                    fXmlNodeEnd = fXmlNodeSet.appendChild(FPlcDriverCommon.createXmlNodeEND(m_fXmlDoc));
                }
                // --
                fXmlNodeDsd = fXmlNodeSet.selectSingleNode(FXmlTagDSD.E_DataSetDefinition);
                if (fXmlNodeDsd == null)
                {
                    fXmlNodeDsd = fXmlNodeSet.appendChild(FPlcDriverCommon.createXmlNodeDSD(m_fXmlDoc));
                }
                // --

                // ***
                // Modeling 계열
                // ***
                fXmlNodePlm = m_fXmlNodePcd.selectSingleNode(FXmlTagPLM.E_PlcLibraryModeling);
                if (fXmlNodePlm == null)
                {
                    fXmlNodePlm = m_fXmlNodePcd.appendChild(FPlcDriverCommon.createXmlNodePLM(m_fXmlDoc));
                }
                // --
                fXmlNodePdm = m_fXmlNodePcd.selectSingleNode(FXmlTagPDM.E_PlcDeviceModeling);
                if (fXmlNodePdm == null)
                {
                    fXmlNodePdm = m_fXmlNodePcd.appendChild(FPlcDriverCommon.createXmlNodePDM(m_fXmlDoc));
                }

                // --

                // ***
                // PLC Word Format 설정
                // ***
                xpath = "//" + FXmlTagPWD.E_PlcWord + "[not(@" + FXmlTagPWD.A_Format + ")]";
                // --
                foreach (FXmlNode x in m_fXmlNodePcd.selectNodes(xpath))
                {
                    x.set_attrVal(FXmlTagPWD.A_Format, FXmlTagPWD.D_Format, FEnumConverter.fromPlcWordFormat(FPlcWordFormat.Ascii));
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeSet != null)
                {
                    fXmlNodeSet.Dispose();
                    fXmlNodeSet = null;
                }
                if (fXmlNodeOnd != null)
                {
                    fXmlNodeOnd.Dispose();
                    fXmlNodeOnd = null;
                }
                if (fXmlNodeFnd != null)
                {
                    fXmlNodeFnd.Dispose();
                    fXmlNodeFnd = null;
                }
                if (fXmlNodeUtd != null)
                {
                    fXmlNodeUtd.Dispose();
                    fXmlNodeUtd = null;
                }
                if (fXmlNodeDcd != null)
                {
                    fXmlNodeDcd.Dispose();
                    fXmlNodeDcd = null;
                }
                if (fXmlNodeEsd != null)
                {
                    fXmlNodeEsd.Dispose();
                    fXmlNodeEsd = null;
                }
                if (fXmlNodeRpd != null)
                {
                    fXmlNodeRpd.Dispose();
                    fXmlNodeRpd = null;
                }
                if (fXmlNodeEnd != null)
                {
                    fXmlNodeEnd.Dispose();
                    fXmlNodeEnd = null;
                }
                if (fXmlNodeDsd != null)
                {
                    fXmlNodeDsd.Dispose();
                    fXmlNodeDsd = null;
                }
                // --
                if (fXmlNodePlm != null)
                {
                    fXmlNodePlm.Dispose();
                    fXmlNodePlm = null;
                }
                if (fXmlNodePdm != null)
                {
                    fXmlNodePdm.Dispose();
                    fXmlNodePdm = null;
                }
                if (fXmlNodeDcd != null)
                {
                    fXmlNodeDcd.Dispose();
                    fXmlNodeDcd = null;
                }
                if (fXmlNodeEsd != null)
                {
                    fXmlNodeEsd.Dispose();
                    fXmlNodeEsd = null;
                }
                if (fXmlNodeEnd != null)
                {
                    fXmlNodeEnd.Dispose();
                    fXmlNodeEnd = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void restoreObjectNameList(
            )
        {
            FXmlNode fXmlNodeOnd = null;
            FXmlNode fXmlNodeOnl = null;
            FXmlNode fXmlNodeTmp = null;
            string xpath = string.Empty;

            try
            {
                // ***
                // Object Name List 복원
                // ***
                fXmlNodeOnd = m_fXmlNodePcd.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagOND.E_ObjectNameDefinition);
                // --
                xpath = FXmlTagONL.E_ObjectNameList + "[@" + FXmlTagONL.A_ObjectType + "='{0}']";
                fXmlNodeTmp = null;
                foreach (FObjectType type in Enum.GetValues(typeof(FObjectType)))
                {
                    fXmlNodeOnl = fXmlNodeOnd.selectSingleNode(string.Format(xpath, type.ToString()));
                    if (fXmlNodeOnl == null)
                    {
                        if (fXmlNodeTmp == null)
                        {
                            if (fXmlNodeOnd.fFirstChild == null)
                            {
                                fXmlNodeOnl = fXmlNodeOnd.appendChild(FPlcDriverCommon.createXmlNodeONL(m_fXmlDoc));
                            }
                            else
                            {
                                fXmlNodeOnl = fXmlNodeOnd.insertBefore(FPlcDriverCommon.createXmlNodeONL(m_fXmlDoc), fXmlNodeOnd.fFirstChild);
                            }
                        }
                        else
                        {
                            fXmlNodeOnl = fXmlNodeOnd.insertAfter(FPlcDriverCommon.createXmlNodeONL(m_fXmlDoc), fXmlNodeTmp);
                        }
                        // --
                        fXmlNodeOnl.set_attrVal(FXmlTagONL.A_UniqueId, FXmlTagONL.D_UniqueId, m_fIdPointer.uniqueId.ToString());
                        fXmlNodeOnl.set_attrVal(FXmlTagONL.A_Name, FXmlTagONL.D_Name, type.ToString());
                        fXmlNodeOnl.set_attrVal(FXmlTagONL.A_ObjectType, FXmlTagONL.D_ObjectType, type.ToString());
                    }
                    fXmlNodeTmp = fXmlNodeOnl;
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
                if (fXmlNodeOnl != null)
                {
                    fXmlNodeOnl.Dispose();
                    fXmlNodeOnl = null;
                }
                if (fXmlNodeTmp != null)
                {
                    fXmlNodeTmp.Dispose();
                    fXmlNodeTmp = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void restoreUserTagName(
            )
        {
            FXmlNode fXmlNodeUtd = null;
            FXmlNode fXmlNodeUtn = null;
            FXmlNode fXmlNodeTmp = null;
            string xpath = string.Empty;

            try
            {
                // ***
                // User Tag Name 복원
                // ***
                fXmlNodeUtd = m_fXmlNodePcd.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagUTD.E_UserTagNameDefinition);
                // --
                xpath = FXmlTagUTN.E_UserTagName + "[@" + FXmlTagUTN.A_ObjectType + "='{0}']";
                fXmlNodeTmp = null;
                foreach (FObjectType type in Enum.GetValues(typeof(FObjectType)))
                {
                    fXmlNodeUtn = fXmlNodeUtd.selectSingleNode(string.Format(xpath, type.ToString()));
                    if (fXmlNodeUtn == null)
                    {
                        if (fXmlNodeTmp == null)
                        {
                            if (fXmlNodeUtd.fFirstChild == null)
                            {
                                fXmlNodeUtn = fXmlNodeUtd.appendChild(FPlcDriverCommon.createXmlNodeUTN(m_fXmlDoc));
                            }
                            else
                            {
                                fXmlNodeUtn = fXmlNodeUtd.insertBefore(FPlcDriverCommon.createXmlNodeUTN(m_fXmlDoc), fXmlNodeUtd.fFirstChild);
                            }
                        }
                        else
                        {
                            fXmlNodeUtn = fXmlNodeUtd.insertAfter(FPlcDriverCommon.createXmlNodeUTN(m_fXmlDoc), fXmlNodeTmp);
                        }
                        // --
                        fXmlNodeUtn.set_attrVal(FXmlTagUTN.A_UniqueId, FXmlTagUTN.D_UniqueId, m_fIdPointer.uniqueId.ToString());
                        fXmlNodeUtn.set_attrVal(FXmlTagUTN.A_Name, FXmlTagUTN.D_Name, type.ToString());
                        fXmlNodeUtn.set_attrVal(FXmlTagUTN.A_ObjectType, FXmlTagUTN.D_ObjectType, type.ToString());
                    }
                    fXmlNodeTmp = fXmlNodeUtn;
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeUtd != null)
                {
                    fXmlNodeUtd.Dispose();
                    fXmlNodeUtd = null;
                }
                if (fXmlNodeUtn != null)
                {
                    fXmlNodeUtn.Dispose();
                    fXmlNodeUtn = null;
                }
                if (fXmlNodeTmp != null)
                {
                    fXmlNodeTmp.Dispose();
                    fXmlNodeTmp = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private bool validateReopenModelingFile(
            FPlcDriver fOldPdr,
            FPlcDriver fNewPdr,
            ref string message
            )
        {
            FPlcDevice fOldPdv = null;
            FPlcSession fOldPsn = null;
            FHostDevice fOldHdv = null;
            FHostSession fOldHsn = null;
            // --
            FPlcDevice fNewPdv = null;
            FPlcSession fNewPsn = null;
            FHostDevice fNewHdv = null;
            FHostSession fNewHsn = null;

            try
            {
                message = string.Format(FConstants.err_m_0035, "File");

                // --

                // ***
                // PLC Device의 개수가 동일한지 검사
                // ***
                if (fOldPdr.fChildPlcDeviceCollection.count != fNewPdr.fChildPlcDeviceCollection.count)
                {
                    return false;
                }

                // --

                for (int i = 0; i < fOldPdr.fChildPlcDeviceCollection.count; i++)
                {
                    fOldPdv = fOldPdr.fChildPlcDeviceCollection[i];
                    fNewPdv = fNewPdr.fChildPlcDeviceCollection[i];

                    // --

                    // ***
                    // PLC Device의 Unique ID가 동일한지 검사 PLC Device의 구조가 변경되었는지 검사
                    // ***
                    if (fOldPdv.uniqueId != fNewPdv.uniqueId)
                    {
                        return false;
                    }

                    // ***
                    // PLC Device의 주요 Properties 정보가 변경되었는지 검사
                    // ***
                    if (fOldPdv.fProtocol != fNewPdv.fProtocol)
                    {
                        return false;
                    }

                    if (fOldPdv.fProtocol == FProtocol.MELSECE)
                    {
                        if (fOldPdv.localIp != fNewPdv.localIp)
                        {
                            return false;
                        }

                        if (fOldPdv.remoteIp != fNewPdv.remoteIp)
                        {
                            return false;
                        }

                        if (fOldPdv.remotePort != fNewPdv.remotePort)
                        {
                            return false;
                        }

                        if (fOldPdv.t2Timeout != fNewPdv.t2Timeout)
                        {
                            return false;
                        }

                        if (fOldPdv.t3Timeout != fNewPdv.t3Timeout)
                        {
                            return false;
                        }

                        if (fOldPdv.t5Timeout != fNewPdv.t5Timeout)
                        {
                            return false;
                        }                        
                    }

                    // --

                    // ***
                    // PLC Session의 개수가 동일한지 검사
                    // ***
                    if (fOldPdv.fChildPlcSessionCollection.count != fNewPdv.fChildPlcSessionCollection.count)
                    {
                        return false;
                    }

                    // --

                    for (int j = 0; j < fOldPdv.fChildPlcSessionCollection.count; j++)
                    {
                        fOldPsn = fOldPdv.fChildPlcSessionCollection[j];
                        fNewPsn = fNewPdv.fChildPlcSessionCollection[j];

                        // --

                        // ***
                        // PLC Session의 Unique ID가 동일한지 검사 PLC Session의 구조가 변경되었는지 검사
                        // ***
                        if (fOldPsn.uniqueId != fNewPsn.uniqueId)
                        {
                            return false;
                        }
                    }   // PLC Session for end 
                }   // PLC Device for end

                // --

                // ***
                // Host Device의 개수가 동일한지 검사
                // ***
                if (fOldPdr.fChildHostDeviceCollection.count != fNewPdr.fChildHostDeviceCollection.count)
                {
                    return false;
                }

                // --

                for (int i = 0; i < fOldPdr.fChildHostDeviceCollection.count; i++)
                {
                    fOldHdv = fOldPdr.fChildHostDeviceCollection[i];
                    fNewHdv = fNewPdr.fChildHostDeviceCollection[i];

                    // --

                    // ***
                    // Host Device의 Unique ID가 동일한지 검사 Host Device의 구조가 변경되었는지 검사
                    // ***
                    if (fOldHdv.uniqueId != fNewHdv.uniqueId)
                    {
                        return false;
                    }

                    // ***
                    // Host Device의 주요 Properties 정보가 변경되었는지 검사
                    // ***
                    if (fOldHdv.fDeviceMode != fNewHdv.fDeviceMode)
                    {
                        return false;
                    }

                    if (fOldHdv.driver != fNewHdv.driver)
                    {
                        return false;
                    }

                    if (fOldHdv.transactionTimeout != fNewHdv.transactionTimeout)
                    {
                        return false;
                    }

                    // --

                    // ***
                    // Host Session의 개수가 동일한지 검사
                    // ***
                    if (fOldHdv.fChildHostSessionCollection.count != fNewHdv.fChildHostSessionCollection.count)
                    {
                        return false;
                    }

                    // --

                    for (int j = 0; j < fOldHdv.fChildHostSessionCollection.count; j++)
                    {
                        fOldHsn = fOldHdv.fChildHostSessionCollection[j];
                        fNewHsn = fNewHdv.fChildHostSessionCollection[j];

                        // --

                        // ***
                        // Host Session의 Unique ID가 동일한지 검사 Host Session의 구조가 변경되었는지 검사
                        // ***
                        if (fOldHsn.uniqueId != fNewHsn.uniqueId)
                        {
                            return false;
                        }
                    }   // Host Session for end 
                }   // Host Device for end

                // --

                message = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
                message = ex.Message;
            }
            finally
            {
                fOldPdv = null;
                fOldPsn = null;
                fOldHdv = null;
                fOldHsn = null;
                // --
                fNewPdv = null;
                fNewPsn = null;
                fNewHdv = null;
                fNewHsn = null;
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void onModelingFileChanged(
            )
        {
            try
            {
                if (ModelingFileChanged != null)
                {
                    ModelingFileChanged(this, new FModelingFileChangedEventArgs(m_fPlcDriver));
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

        public void saveRepositoryMaterial(
            FStorageAction fAction
            )
        {
            // ***
            // 2017.04.04 by spike.lee
            // Repoistory Material Save 구현
            // ***
            FXmlDocument fXmlDoc = null;
            FXmlNode fXmlNodeFam = null;
            string dateTime = string.Empty;
            string fileName = string.Empty;

            try
            {
                dateTime = FDataConvert.defaultNowDateTimeToString();

                // --

                fXmlDoc = new FXmlDocument();
                fXmlDoc.preserveWhiteSpace = false;
                fXmlDoc.appendChild(m_fXmlDoc.createXmlDeclaration("1.0", string.Empty, string.Empty));

                // --

                fXmlNodeFam = fXmlDoc.createNode(FXmlTagFAM.E_FAMate);
                // --
                fXmlNodeFam.set_attrVal(FXmlTagFAM.A_FileFormat, FXmlTagFAM.D_FileFormat, "RPM");
                fXmlNodeFam.set_attrVal(FXmlTagFAM.A_FileVersion, FXmlTagFAM.D_FileVersion, "4.5.0.1");
                fXmlNodeFam.set_attrVal(FXmlTagFAM.A_FileCreationTime, FXmlTagFAM.D_FileCreationTime, dateTime);
                fXmlNodeFam.set_attrVal(FXmlTagFAM.A_FileUpdateTime, FXmlTagFAM.D_FileUpdateTime, dateTime);
                fXmlNodeFam.set_attrVal(FXmlTagFAM.A_FileDescription, FXmlTagFAM.D_FileDescription, "FAmate Repository File");
                fXmlNodeFam.set_attrVal(FXmlTagFAM.A_UniqueIdPointer, FXmlTagFAM.D_UniqueIdPointer, m_fRpmIdPointer.currentId.ToString());
                // --
                fXmlDoc.appendChild(fXmlNodeFam);

                // --

                foreach (FRepositoryMaterial fRpm in m_fRepositoryMaterialStorage.fRepositoryMaterialCollection)
                {
                    if (fRpm.keeping)
                    {
                        fXmlNodeFam.appendChild(fRpm.fXmlNode.clone(true));
                    }
                }

                // --

                if (!Directory.Exists(m_fConfig.repositorySaveDirectory))
                {
                    Directory.CreateDirectory(m_fConfig.repositorySaveDirectory);
                }
                // --
                fileName = Path.Combine(m_fConfig.repositorySaveDirectory, FConstants.RepositoryFileName);
                // --
                fXmlDoc.save(fileName);

                // -- 

                // ***
                // 2017.05.31 by spike.lee
                // Repository Material Saved 이벤트 추가
                // ***
                m_fEventPusher.pushEvent(
                    new FRepositoryMaterialSavedEventArgs(
                        FEventId.RecpsitoryMaterialSaved, 
                        m_fPlcDriver, 
                        m_fRepositoryMaterialStorage, 
                        fAction,
                        fXmlDoc.outerXml
                        )
                    ); 
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeFam = null;
                // --
                if (fXmlDoc != null)
                {
                    fXmlDoc.Dispose();
                    fXmlDoc = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void saveRepositoryMaterial(
            string rawData
            )
        {
            // ***
            // 2017.06.01 by spike.lee
            // Repoistory Material Save 구현
            // ***
            FXmlDocument fXmlDoc = null;
            string fileName = string.Empty;

            try
            {
                fXmlDoc = new FXmlDocument();
                fXmlDoc.preserveWhiteSpace = false;
                fXmlDoc.loadXml(rawData);

                // --

                if (!Directory.Exists(m_fConfig.repositorySaveDirectory))
                {
                    Directory.CreateDirectory(m_fConfig.repositorySaveDirectory);
                }
                // --
                fileName = Path.Combine(m_fConfig.repositorySaveDirectory, FConstants.RepositoryFileName);
                // --
                fXmlDoc.save(fileName);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlDoc = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void loadRepositoryMaterial(
            string rawData
            )
        {
            // ***
            // 2017.06.05 by spike.lee
            // Repoistory Material Load 구현
            // ***
            FXmlDocument fXmlDoc = null;
            FXmlNode fXmlNodeFam = null;
            FXmlNodeList fXmlNodeListRpm = null;
            FRepositoryMaterial fRpm = null;

            try
            {
                // ***
                // Repository를 Load한 경우 이전 Repository Material 모두 제거
                // ***
                m_fRepositoryMaterialStorage.clear();

                // --

                fXmlDoc = new FXmlDocument();
                fXmlDoc.preserveWhiteSpace = false;
                fXmlDoc.loadXml(rawData);

                // --

                fXmlNodeFam = fXmlDoc.selectSingleNode(FXmlTagFAM.E_FAMate);
                fXmlNodeListRpm = fXmlNodeFam.selectNodes(FXmlTagRPM.E_RepositoryMaterial);
                if (fXmlNodeListRpm.count == 0)
                {
                    return;
                }

                // --

                foreach (FXmlNode x in fXmlNodeListRpm)
                {
                    fRpm = new FRepositoryMaterial(this, x.clone(true));
                    m_fRepositoryMaterialStorage.add(fRpm);
                }

                // --

                // ***
                // Repository Material ID Pointer 재 설정
                // ***
                m_fRpmIdPointer.reset(UInt64.Parse(fXmlNodeFam.get_attrVal(FXmlTagFAM.A_UniqueIdPointer, FXmlTagFAM.D_UniqueIdPointer)));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlDoc = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void openRepositoryMaterial(
            )
        {
            // ***
            // 2017.04.04 by spike.lee
            // Repoistory Material Save 구현
            // ***
            FXmlDocument fXmlDoc = null;
            FXmlNode fXmlNodeFam = null;
            FXmlNodeList fXmlNodeListRpm = null;
            FXmlNode fXmlNodeStgl = null;
            FXmlNode fXmlNodeRpsl = null;
            FXmlNode fXmlNodeSnr = null;
            FRepositoryMaterial fRpm = null;
            FStoragePerformedLog fLog = null;
            FScenarioData fScenarioData = null;
            string fileName = string.Empty;

            try
            {
                fileName = Path.Combine(m_fConfig.repositorySaveDirectory, FConstants.RepositoryFileName);
                if (!File.Exists(fileName))
                {
                    return;
                }

                // --

                // ***
                // Repository File를 Open한 경우 이전 Repository Material 모두 제거
                // ***
                m_fRepositoryMaterialStorage.clear();

                // --

                fXmlDoc = new FXmlDocument();
                fXmlDoc.preserveWhiteSpace = false;
                fXmlDoc.load(fileName);

                // --

                fXmlNodeFam = fXmlDoc.selectSingleNode(FXmlTagFAM.E_FAMate);
                fXmlNodeListRpm = fXmlNodeFam.selectNodes(FXmlTagRPM.E_RepositoryMaterial);
                if (fXmlNodeListRpm.count == 0)
                {
                    return;
                }

                // --

                foreach (FXmlNode x in fXmlNodeListRpm)
                {
                    fRpm = new FRepositoryMaterial(this, x.clone(true));
                    m_fRepositoryMaterialStorage.add(fRpm);
                }

                // --

                // ***
                // Repository Material ID Pointer 재 설정
                // ***
                m_fRpmIdPointer.reset(UInt64.Parse(fXmlNodeFam.get_attrVal(FXmlTagFAM.A_UniqueIdPointer, FXmlTagFAM.D_UniqueIdPointer)));

                // --

                // ***
                // StoragePerformed 이벤트 등록
                // ***
                fXmlNodeStgl = fXmlDoc.createNode(FXmlTagSTGL.E_Storage);
                // --
                fXmlNodeStgl.set_attrVal(FXmlTagSTGL.A_ResultCode, FXmlTagSTGL.D_ResultCode, FEnumConverter.fromResultCode(FResultCode.Success));
                fXmlNodeStgl.set_attrVal(FXmlTagSTGL.A_ResultMessage, FXmlTagSTGL.D_ResultMessage, "Repository file has been opened.");
                // --
                fXmlNodeStgl.set_attrVal(FXmlTagSTGL.A_UniqueId, FXmlTagSTGL.D_UniqueId, m_fIdPointer.uniqueId.ToString());
                fXmlNodeStgl.set_attrVal(FXmlTagSTGL.A_Name, FXmlTagSTGL.D_Name, "RepositoryFileOpen");
                fXmlNodeStgl.set_attrVal(FXmlTagSTGL.A_Action, FXmlTagSTGL.D_Action, FEnumConverter.fromStorageAction(FStorageAction.Create));
                fXmlNodeStgl.set_attrVal(FXmlTagSTGL.A_RepositoryMaterialCount, FXmlTagSTGL.D_RepositoryMaterialCount, m_fRepositoryMaterialStorage.fRepositoryMaterialCollection.count.ToString());
                // --
                foreach (FXmlNode x in fXmlNodeListRpm)
                {
                    fXmlNodeRpsl = x.clone(true);
                    fXmlNodeRpsl.set_attrVal(FXmlTagRPSL.A_RepositoryType, FXmlTagRPSL.D_RepositoryType, FXmlTagRPSL.R_Repository);
                    // --
                    fXmlNodeStgl.appendChild(fXmlNodeRpsl);
                }

                // --

                // ***
                // 기본 Scenario 개체 생성
                // ***
                fXmlNodeSnr = fXmlDoc.createNode(FXmlTagSNR.E_Scenario);
                fXmlNodeSnr.set_attrVal(FXmlTagSNR.A_Name, FXmlTagSNR.D_Name, "RepositoryFileOpen");

                // --

                fLog = new FStoragePerformedLog(fXmlNodeStgl);
                // --
                fScenarioData = new FScenarioData(this);
                fScenarioData.setStoragePerformedLog(fLog);
                fScenarioData.setScenario(new FScenario(this, fXmlNodeSnr));
                // --
                fEventPusher.pushPreEvent(new FStoragePerformedEventArgs(FEventId.StoragePerformed, this.fPlcDriver, fLog, fScenarioData));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeFam = null;
                fXmlNodeListRpm = null;
                fXmlNodeStgl = null;
                fXmlNodeRpsl = null;
                fXmlNodeSnr = null;
                fRpm = null;
                fXmlDoc = null;
                fLog = null;
                fScenarioData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------       

        public void removeAutoRepositoryMaterial(
            )
        {
            List<FRepositoryMaterial> fRemovalRpmList = null;
            FXmlNode fXmlNodeStgl = null;
            FXmlNode fXmlNodeRpsl = null;
            FXmlNode fXmlNodeSnr = null;
            FStoragePerformedLog fLog = null;
            FScenarioData fScenarioData = null;
            string dateTime = string.Empty;

            try
            {
                dateTime = DateTime.Now.AddHours(-1 * m_fConfig.repositoryKeepingPeriod).ToString("yyyy-MM-dd HH:mm:ss.fff");

                // --

                fRemovalRpmList = new List<FRepositoryMaterial>();
                // --
                foreach (FRepositoryMaterial fRpm in m_fRepositoryMaterialStorage.fRepositoryMaterialCollection)
                {
                    if (dateTime.CompareTo(fRpm.lastAccessTime) > 0)
                    {
                        fRemovalRpmList.Add(fRpm);
                    }
                }

                // --

                if (fRemovalRpmList.Count == 0)
                {
                    return;
                }

                // --

                foreach (FRepositoryMaterial fRpm in fRemovalRpmList)
                {
                    m_fRepositoryMaterialStorage.remove(fRpm);
                }

                // --

                // ***
                // StoragePerformed 이벤트 등록
                // ***
                fXmlNodeStgl = this.fXmlDoc.createNode(FXmlTagSTGL.E_Storage);
                // --
                fXmlNodeStgl.set_attrVal(FXmlTagSTGL.A_ResultCode, FXmlTagSTGL.D_ResultCode, FEnumConverter.fromResultCode(FResultCode.Warninig));
                fXmlNodeStgl.set_attrVal(FXmlTagSTGL.A_ResultMessage, FXmlTagSTGL.D_ResultMessage, "Repository has been automatically removed.");
                // --
                fXmlNodeStgl.set_attrVal(FXmlTagSTGL.A_UniqueId, FXmlTagSTGL.D_UniqueId, m_fIdPointer.uniqueId.ToString());
                fXmlNodeStgl.set_attrVal(FXmlTagSTGL.A_Name, FXmlTagSTGL.D_Name, "RepositoryAutoRemove");
                fXmlNodeStgl.set_attrVal(FXmlTagSTGL.A_Action, FXmlTagSTGL.D_Action, FEnumConverter.fromStorageAction(FStorageAction.Remove));
                fXmlNodeStgl.set_attrVal(FXmlTagSTGL.A_RepositoryMaterialCount, FXmlTagSTGL.D_RepositoryMaterialCount, m_fRepositoryMaterialStorage.fRepositoryMaterialCollection.count.ToString());
                // --
                foreach (FRepositoryMaterial fRpm in fRemovalRpmList)
                {
                    fXmlNodeRpsl = fRpm.fXmlNode.clone(true);
                    fXmlNodeRpsl.set_attrVal(FXmlTagRPSL.A_RepositoryType, FXmlTagRPSL.D_RepositoryType, FXmlTagRPSL.R_Repository);
                    // --
                    fXmlNodeStgl.appendChild(fXmlNodeRpsl);
                }

                // --

                // ***
                // 기본 Scenario 개체 생성
                // ***
                fXmlNodeSnr = fXmlDoc.createNode(FXmlTagSNR.E_Scenario);
                fXmlNodeSnr.set_attrVal(FXmlTagSNR.A_Name, FXmlTagSNR.D_Name, "RepositoryAutoRemove");

                // --

                fLog = new FStoragePerformedLog(fXmlNodeStgl);
                // --
                fScenarioData = new FScenarioData(this);
                fScenarioData.setStoragePerformedLog(fLog);
                fScenarioData.setScenario(new FScenario(this, fXmlNodeSnr));
                // --
                fEventPusher.pushPreEvent(new FStoragePerformedEventArgs(FEventId.StoragePerformed, this.fPlcDriver, fLog, fScenarioData));

                // --

                if (m_fConfig.enabledRepositorySave)
                {
                    saveRepositoryMaterial(FStorageAction.Remove);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fRemovalRpmList = null;
                fXmlNodeStgl = null;
                fXmlNodeRpsl = null;
                fXmlNodeSnr = null;
                fLog = null;
                fScenarioData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------       

        public string getRepositoryMaterialRawData(
            )
        {
            // ***
            // 2017.06.08 by spike.lee
            // Get Repoistory Material RawData 구현
            // ***
            FXmlDocument fXmlDoc = null;
            FXmlNode fXmlNodeFam = null;
            string dateTime = string.Empty;

            try
            {
                dateTime = FDataConvert.defaultNowDateTimeToString();

                // --

                fXmlDoc = new FXmlDocument();
                fXmlDoc.preserveWhiteSpace = false;
                fXmlDoc.appendChild(m_fXmlDoc.createXmlDeclaration("1.0", string.Empty, string.Empty));

                // --

                fXmlNodeFam = fXmlDoc.createNode(FXmlTagFAM.E_FAMate);
                // --
                fXmlNodeFam.set_attrVal(FXmlTagFAM.A_FileFormat, FXmlTagFAM.D_FileFormat, "RPM");
                fXmlNodeFam.set_attrVal(FXmlTagFAM.A_FileVersion, FXmlTagFAM.D_FileVersion, "4.5.0.1");
                fXmlNodeFam.set_attrVal(FXmlTagFAM.A_FileCreationTime, FXmlTagFAM.D_FileCreationTime, dateTime);
                fXmlNodeFam.set_attrVal(FXmlTagFAM.A_FileUpdateTime, FXmlTagFAM.D_FileUpdateTime, dateTime);
                fXmlNodeFam.set_attrVal(FXmlTagFAM.A_FileDescription, FXmlTagFAM.D_FileDescription, "FAmate Repository File");
                fXmlNodeFam.set_attrVal(FXmlTagFAM.A_UniqueIdPointer, FXmlTagFAM.D_UniqueIdPointer, m_fRpmIdPointer.currentId.ToString());
                // --
                fXmlDoc.appendChild(fXmlNodeFam);

                // --

                foreach (FRepositoryMaterial fRpm in m_fRepositoryMaterialStorage.fRepositoryMaterialCollection)
                {
                    if (fRpm.keeping)
                    {
                        fXmlNodeFam.appendChild(fRpm.fXmlNode.clone(true));
                    }
                }

                // --

                return fXmlDoc.outerXml;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeFam = null;
                // --
                if (fXmlDoc != null)
                {
                    fXmlDoc.Dispose();
                    fXmlDoc = null;
                }
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------       

        public void removeRepositoryMaterialById(
            UInt64[] rpmIds
            )
        {
            List<FRepositoryMaterial> fRemovalRpmList = null;
            FRepositoryMaterial fRpm = null;
            FXmlNode fXmlNodeStgl = null;
            FXmlNode fXmlNodeRpsl = null;
            FXmlNode fXmlNodeSnr = null;
            FStoragePerformedLog fLog = null;
            FScenarioData fScenarioData = null;
            string dateTime = string.Empty;

            try
            {
                fRemovalRpmList = new List<FRepositoryMaterial>();
                // --
                foreach (UInt16 id in rpmIds)
                {
                    fRpm = m_fRepositoryMaterialStorage.getRepositoryMaterialByRpmId(id);
                    // --
                    if (fRpm != null)
                    {
                        fRemovalRpmList.Add(fRpm);
                        m_fRepositoryMaterialStorage.remove(fRpm);
                    }
                }

                // --

                if (fRemovalRpmList.Count == 0)
                {
                    return;
                }

                // --

                // ***
                // StoragePerformed 이벤트 등록
                // ***
                fXmlNodeStgl = this.fXmlDoc.createNode(FXmlTagSTGL.E_Storage);
                // --
                fXmlNodeStgl.set_attrVal(FXmlTagSTGL.A_ResultCode, FXmlTagSTGL.D_ResultCode, FEnumConverter.fromResultCode(FResultCode.Success));
                fXmlNodeStgl.set_attrVal(FXmlTagSTGL.A_ResultMessage, FXmlTagSTGL.D_ResultMessage, "The Repository has been removed by the command.");
                // --
                fXmlNodeStgl.set_attrVal(FXmlTagSTGL.A_UniqueId, FXmlTagSTGL.D_UniqueId, m_fIdPointer.uniqueId.ToString());
                fXmlNodeStgl.set_attrVal(FXmlTagSTGL.A_Name, FXmlTagSTGL.D_Name, "RepositoryRemoveByCommand");
                fXmlNodeStgl.set_attrVal(FXmlTagSTGL.A_Action, FXmlTagSTGL.D_Action, FEnumConverter.fromStorageAction(FStorageAction.Remove));
                fXmlNodeStgl.set_attrVal(FXmlTagSTGL.A_RepositoryMaterialCount, FXmlTagSTGL.D_RepositoryMaterialCount, m_fRepositoryMaterialStorage.fRepositoryMaterialCollection.count.ToString());
                // --
                foreach (FRepositoryMaterial r in fRemovalRpmList)
                {
                    fXmlNodeRpsl = r.fXmlNode.clone(true);
                    fXmlNodeRpsl.set_attrVal(FXmlTagRPSL.A_RepositoryType, FXmlTagRPSL.D_RepositoryType, FXmlTagRPSL.R_Repository);
                    // --
                    fXmlNodeStgl.appendChild(fXmlNodeRpsl);
                }

                // --

                // ***
                // 기본 Scenario 개체 생성
                // ***
                fXmlNodeSnr = fXmlDoc.createNode(FXmlTagSNR.E_Scenario);
                fXmlNodeSnr.set_attrVal(FXmlTagSNR.A_Name, FXmlTagSNR.D_Name, "RepositoryRemoveByCommand");

                // --

                fLog = new FStoragePerformedLog(fXmlNodeStgl);
                // --
                fScenarioData = new FScenarioData(this);
                fScenarioData.setStoragePerformedLog(fLog);
                fScenarioData.setScenario(new FScenario(this, fXmlNodeSnr));
                // --
                fEventPusher.pushPreEvent(new FStoragePerformedEventArgs(FEventId.StoragePerformed, this.fPlcDriver, fLog, fScenarioData));

                // --

                if (m_fConfig.enabledRepositorySave)
                {
                    saveRepositoryMaterial(FStorageAction.Remove);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fRemovalRpmList = null;
                fRpm = null;
                fXmlNodeStgl = null;
                fXmlNodeRpsl = null;
                fXmlNodeSnr = null;
                fLog = null;
                fScenarioData = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------       

    }   // Class end
}   // Namespace end
