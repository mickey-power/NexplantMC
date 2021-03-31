/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FOcdCore.cs
--  Creator         : spike.lee
--  Create Date     : 2015.06.16
--  Description     : FAMate Core FaOpcDriver OPC Driver Core Class 
--  History         : Created by spike.lee at 2015.06.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using System.Collections.Generic;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    internal class FOcdCore : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------       

        public event FModelingFileChangedEventHandler ModelingFileChanged = null;

        //--
        private bool m_disposed = false;
        // --
        private static FIDPointer32 m_fOpcCoreIdPointer = null;
        private UInt32 m_fOcdCoreId = 0;
        // --
        private FOpcDriver m_fOpcDriver = null;
        private FXmlDocument m_fXmlDoc = null;
        private FXmlNode m_fXmlNodeOcd = null;
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

         public FOcdCore(
            )
        {
            init();              
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOcdCore(
            FXmlDocument fXmlDoc
            )
        {
            init(fXmlDoc);
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FOcdCore(
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

        public FOpcDriver fOpcDriver
        {
            get
            {
                try
                {
                    return m_fOpcDriver;
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
                    m_fOpcDriver = value;
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

        public FXmlNode fXmlNodeOcd
        {
            get
            {
                try
                {
                    return m_fXmlNodeOcd;
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
            FXmlNode fXmlNodeOcd = null;
            FXmlNode fXmlNodeSet = null;
            FXmlNode fXmlNodeOnd = null;
            FXmlNode fXmlNodeOnl = null;
            FXmlNode fXmlNodeUtd = null;
            FXmlNode fXmlNodeUtn = null;          

            try
            {
                if (m_fOpcCoreIdPointer == null)
                {
                    m_fOpcCoreIdPointer = new FIDPointer32();
                }
                m_fOcdCoreId = m_fOpcCoreIdPointer.uniqueId;

                // --

                // ***
                // FOcdCore Creation Log Write
                // ***               
                fDebugLogArgs = new FDebugLogArgs(FDebugLogCategory.Information, "FOcdCoreCreate", this.GetType(), "init");
                fDebugLogArgs.additionInfo = "FOcdCoreId=<" + m_fOcdCoreId.ToString() + ">";
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

                fXmlNodeFam = m_fXmlDoc.appendChild(FOpcDriverCommon.createXmlNodeFAM(m_fXmlDoc));
                // --
                fXmlNodeOcd = fXmlNodeFam.appendChild(FOpcDriverCommon.createXmlNodeOCD(m_fXmlDoc));
                fXmlNodeOcd.set_attrVal(FXmlTagOCD.A_UniqueId, FXmlTagOCD.D_UniqueId, m_fIdPointer.uniqueId.ToString());

                // --

                // ***
                // 기본 Setup Object 생성
                // ***
                fXmlNodeSet = fXmlNodeOcd.appendChild(FOpcDriverCommon.createXmlNodeSET(m_fXmlDoc));
                // --
                fXmlNodeOnd = fXmlNodeSet.appendChild(FOpcDriverCommon.createXmlNodeOND(m_fXmlDoc));   // Object Name Definition
                foreach (FObjectType type in Enum.GetValues(typeof(FObjectType)))
                {
                    fXmlNodeOnl = fXmlNodeOnd.appendChild(FOpcDriverCommon.createXmlNodeONL(m_fXmlDoc));
                    fXmlNodeOnl.set_attrVal(FXmlTagONL.A_UniqueId, FXmlTagONL.D_UniqueId, m_fIdPointer.uniqueId.ToString());
                    fXmlNodeOnl.set_attrVal(FXmlTagONL.A_Name, FXmlTagONL.D_Name, type.ToString());
                    fXmlNodeOnl.set_attrVal(FXmlTagONL.A_ObjectType, FXmlTagONL.D_ObjectType, type.ToString());
                }
                // --
                fXmlNodeSet.appendChild(FOpcDriverCommon.createXmlNodeFND(m_fXmlDoc));                 // Function Name Definition
                // --
                fXmlNodeUtd = fXmlNodeSet.appendChild(FOpcDriverCommon.createXmlNodeUTD(m_fXmlDoc));   // User Tag Definition
                foreach (FObjectType type in Enum.GetValues(typeof(FObjectType)))
                {
                    fXmlNodeUtn = fXmlNodeUtd.appendChild(FOpcDriverCommon.createXmlNodeUTN(m_fXmlDoc));
                    fXmlNodeUtn.set_attrVal(FXmlTagUTN.A_UniqueId, FXmlTagUTN.D_UniqueId, m_fIdPointer.uniqueId.ToString());
                    fXmlNodeUtn.set_attrVal(FXmlTagUTN.A_Name, FXmlTagUTN.D_Name, type.ToString());
                    fXmlNodeUtn.set_attrVal(FXmlTagUTN.A_ObjectType, FXmlTagUTN.D_ObjectType, type.ToString());
                }

                fXmlNodeSet.appendChild(FOpcDriverCommon.createXmlNodeDCD(m_fXmlDoc));     // Data Conversion Set Definition
                fXmlNodeSet.appendChild(FOpcDriverCommon.createXmlNodeESD(m_fXmlDoc));     // Equipment State Set Definition
                fXmlNodeSet.appendChild(FOpcDriverCommon.createXmlNodeRPD(m_fXmlDoc));     // Repository Definition           
                fXmlNodeSet.appendChild(FOpcDriverCommon.createXmlNodeEND(m_fXmlDoc));     // Environment Definition
                fXmlNodeSet.appendChild(FOpcDriverCommon.createXmlNodeDSD(m_fXmlDoc));     // Data Set Definition

                // --

                // ***
                // 기본 Modeling Object 생성
                // ***
                fXmlNodeOcd.appendChild(FOpcDriverCommon.createXmlNodeOLM(m_fXmlDoc));     // OPC Library Modeling
                fXmlNodeOcd.appendChild(FOpcDriverCommon.createXmlNodeODM(m_fXmlDoc));     // OPc Device Modeling
                fXmlNodeOcd.appendChild(FOpcDriverCommon.createXmlNodeHLM(m_fXmlDoc));     // Host Library Modeling               
                fXmlNodeOcd.appendChild(FOpcDriverCommon.createXmlNodeHDM(m_fXmlDoc));     // Host Device Modeling               
                fXmlNodeOcd.appendChild(FOpcDriverCommon.createXmlNodeEQM(m_fXmlDoc));     // Equipment Modeling
                
                // --

                m_fXmlNodeOcd = fXmlNodeOcd;

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
                fXmlNodeOcd = null;

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
                if (m_fOpcCoreIdPointer == null)
                {
                    m_fOpcCoreIdPointer = new FIDPointer32();
                }
                m_fOcdCoreId = m_fOpcCoreIdPointer.uniqueId;

                // --

                // ***
                // FOcdCore Creation Log Write
                // ***               
                fDebugLogArgs = new FDebugLogArgs(FDebugLogCategory.Information, "FOcdCoreCreate", this.GetType(), "init");
                fDebugLogArgs.additionInfo = "FOcdCoreId=<" + m_fOcdCoreId.ToString() + ">";
                FDebug.writeLog(fDebugLogArgs);

                // --

                m_fXmlDoc = fXmlDoc;

                // --

                fXmlNodeFam = m_fXmlDoc.selectSingleNode(FXmlTagFAM.E_FAMate);
                m_fXmlNodeOcd = fXmlNodeFam.selectSingleNode(FXmlTagOCD.E_OpcDriver);

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

                m_fConfig.eapName = m_fXmlNodeOcd.get_attrVal(FXmlTagOCD.A_EapName, FXmlTagOCD.D_EapName);

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

                m_fOpcDriver = null;

                if (m_fXmlNodeOcd != null)
                {
                    m_fXmlNodeOcd.Dispose();
                    m_fXmlNodeOcd = null;
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
                fDebugLogArgs = new FDebugLogArgs(FDebugLogCategory.Information, "FOcdCoreTerminate", this.GetType(), "term");
                fDebugLogArgs.additionInfo = "FOcdCoreId=<" + m_fOcdCoreId.ToString() + ">";
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
                // Opc Device State를 Closed로 초기화
                // ***
                foreach (FXmlNode fXmlNodeSdv in m_fXmlNodeOcd.selectNodes(FXmlTagODM.E_OpcDeviceModeling + "/" + FXmlTagODV.E_OpcDevice))
                {
                    fXmlNodeSdv.set_attrVal(FXmlTagODV.A_State, FXmlTagODV.D_State, FEnumConverter.fromDeviceState(FDeviceState.Closed));
                }

                // ***
                // Opc Session State를 Closed로 초기화
                // ***
                foreach (FXmlNode fXmlNodeOsn in m_fXmlNodeOcd.selectNodes(FXmlTagODM.E_OpcDeviceModeling + "/" + FXmlTagODV.E_OpcDevice + "/" + FXmlTagOSN.E_OpcSession))
                {
                    fXmlNodeOsn.set_attrVal(FXmlTagOSN.A_State, FXmlTagOSN.D_State, FEnumConverter.fromSessionState(FSessionState.Closed));
                }

                // ***
                // Host Device State를 Closed로 초기화
                // ***
                foreach (FXmlNode fXmlNodeHdv in m_fXmlNodeOcd.selectNodes(FXmlTagHDM.E_HostDeviceModeling + "/" + FXmlTagHDV.E_HostDevice))
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
                    new FModelingFileOpenCompletedEventArgs(FEventId.ModelingFileOpenCompleted, m_fOpcDriver, fileName)
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
            FOpcDriver fNewPdr = null;            
            string message = string.Empty;

            try
            {
                // ***
                // 새로운 Modeling File를 Open 한다.
                // ***
                fNewPdr = new FOpcDriver();
                fNewPdr.openModelingFile(fileName);

                // --

                if (!validateReopenModelingFile(m_fOpcDriver, fNewPdr, ref message))
                {
                    m_fEventPusher.pushEvent(
                        new FModelingFileReopenFailedEventArgs(FEventId.ModelingFileReopenFailed, m_fOpcDriver, fileName, message)
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

                m_fOpcDriver.onModelingFileReopenPrecompleted(new FModelingFileReopenPrecompletedEventArgs(m_fOpcDriver, fileName));
                m_fProtocolAgent.continueProtocol();

                // --

                m_fEventPusher.pushEvent(
                    new FModelingFileReopenCompletedEventArgs(FEventId.ModelingFileReopenCompleted, m_fOpcDriver, fileName)
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
                    new FModelingFileSaveCompletedEventArgs(FEventId.ModelingFileSaveCompleted, m_fOpcDriver, fileName)
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
            FXmlNode fXmlNodeOcd = null;

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
                fXmlNodeOcd = fXmlNodeFam.selectSingleNode(FXmlTagOCD.E_OpcDriver);

                // --                

                if (m_fIdPointer != null)
                {
                    m_fIdPointer.Dispose();
                    m_fIdPointer = null;
                }

                // --

                m_fIdPointer = fNewIdPointer;                
                m_fXmlNodeOcd = fXmlNodeOcd;
                // --
                this.fOpcDriver.replace(this, m_fXmlNodeOcd);

                // --

                // ***
                // 2012.11.19 by spike.lee
                // FLogWriter Class에서 사용될 EAP Name 설정
                // ***
                m_fConfig.eapName = m_fXmlNodeOcd.get_attrVal(FXmlTagOCD.A_EapName, FXmlTagOCD.D_EapName);

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
                fXmlNodeOcd = null;
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
                fXmlNodeSet = m_fXmlNodeOcd.selectSingleNode(FXmlTagSET.E_Setup);
                if (fXmlNodeSet == null)
                {
                    fXmlNodeSet = m_fXmlNodeOcd.appendChild(FOpcDriverCommon.createXmlNodeSET(m_fXmlDoc));
                }
                // --
                fXmlNodeOnd = fXmlNodeSet.selectSingleNode(FXmlTagOND.E_ObjectNameDefinition);
                if (fXmlNodeOnd == null)
                {
                    fXmlNodeOnd = fXmlNodeSet.appendChild(FOpcDriverCommon.createXmlNodeOND(m_fXmlDoc));
                }
                // --
                fXmlNodeFnd = fXmlNodeSet.selectSingleNode(FXmlTagFND.E_FunctionNameDefinition);
                if (fXmlNodeFnd == null)
                {
                    fXmlNodeFnd = fXmlNodeSet.appendChild(FOpcDriverCommon.createXmlNodeFND(m_fXmlDoc));
                }
                // --
                fXmlNodeUtd = fXmlNodeSet.selectSingleNode(FXmlTagUTD.E_UserTagNameDefinition);
                if (fXmlNodeUtd == null)
                {
                    fXmlNodeUtd = fXmlNodeSet.appendChild(FOpcDriverCommon.createXmlNodeUTD(m_fXmlDoc));
                }
                // --
                fXmlNodeDcd = fXmlNodeSet.selectSingleNode(FXmlTagDCD.E_DataConversionSetDefinition);
                if (fXmlNodeDcd == null)
                {
                    fXmlNodeDcd = fXmlNodeSet.appendChild(FOpcDriverCommon.createXmlNodeDCD(m_fXmlDoc));
                }
                // --
                fXmlNodeEsd = fXmlNodeSet.selectSingleNode(FXmlTagESD.E_EquipmentStateSetDefinition);
                if (fXmlNodeEsd == null)
                {
                    fXmlNodeEsd = fXmlNodeSet.appendChild(FOpcDriverCommon.createXmlNodeESD(m_fXmlDoc));
                }
                // --
                fXmlNodeRpd = fXmlNodeSet.selectSingleNode(FXmlTagRPD.E_RepositoryDefinition);
                if (fXmlNodeRpd == null)
                {
                    fXmlNodeRpd = fXmlNodeSet.appendChild(FOpcDriverCommon.createXmlNodeRPD(m_fXmlDoc));
                }
                // --
                fXmlNodeEnd = fXmlNodeSet.selectSingleNode(FXmlTagEND.E_EnvironmentDefinition);
                if (fXmlNodeEnd == null)
                {
                    fXmlNodeEnd = fXmlNodeSet.appendChild(FOpcDriverCommon.createXmlNodeEND(m_fXmlDoc));
                }
                // --
                fXmlNodeDsd = fXmlNodeSet.selectSingleNode(FXmlTagDSD.E_DataSetDefinition);
                if (fXmlNodeDsd == null)
                {
                    fXmlNodeDsd = fXmlNodeSet.appendChild(FOpcDriverCommon.createXmlNodeDSD(m_fXmlDoc));
                }
                // --

                // ***
                // Modeling 계열
                // ***
                fXmlNodePlm = m_fXmlNodeOcd.selectSingleNode(FXmlTagOLM.E_OpcLibraryModeling);
                if (fXmlNodePlm == null)
                {
                    fXmlNodePlm = m_fXmlNodeOcd.appendChild(FOpcDriverCommon.createXmlNodeOLM(m_fXmlDoc));
                }
                // --
                fXmlNodePdm = m_fXmlNodeOcd.selectSingleNode(FXmlTagODM.E_OpcDeviceModeling);
                if (fXmlNodePdm == null)
                {
                    fXmlNodePdm = m_fXmlNodeOcd.appendChild(FOpcDriverCommon.createXmlNodeODM(m_fXmlDoc));
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
                fXmlNodeOnd = m_fXmlNodeOcd.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagOND.E_ObjectNameDefinition);
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
                                fXmlNodeOnl = fXmlNodeOnd.appendChild(FOpcDriverCommon.createXmlNodeONL(m_fXmlDoc));
                            }
                            else
                            {
                                fXmlNodeOnl = fXmlNodeOnd.insertBefore(FOpcDriverCommon.createXmlNodeONL(m_fXmlDoc), fXmlNodeOnd.fFirstChild);
                            }
                        }
                        else
                        {
                            fXmlNodeOnl = fXmlNodeOnd.insertAfter(FOpcDriverCommon.createXmlNodeONL(m_fXmlDoc), fXmlNodeTmp);
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
                fXmlNodeUtd = m_fXmlNodeOcd.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagUTD.E_UserTagNameDefinition);
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
                                fXmlNodeUtn = fXmlNodeUtd.appendChild(FOpcDriverCommon.createXmlNodeUTN(m_fXmlDoc));
                            }
                            else
                            {
                                fXmlNodeUtn = fXmlNodeUtd.insertBefore(FOpcDriverCommon.createXmlNodeUTN(m_fXmlDoc), fXmlNodeUtd.fFirstChild);
                            }
                        }
                        else
                        {
                            fXmlNodeUtn = fXmlNodeUtd.insertAfter(FOpcDriverCommon.createXmlNodeUTN(m_fXmlDoc), fXmlNodeTmp);
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
            FOpcDriver fOldOdr,
            FOpcDriver fNewOdr,
            ref string message
            )
        {
            FOpcDevice fOldOdv = null;
            FOpcSession fOldOsn = null;
            FHostDevice fOldHdv = null;
            FHostSession fOldHsn = null;
            // --
            FOpcDevice fNewOdv = null;
            FOpcSession fNewOsn = null;
            FHostDevice fNewHdv = null;
            FHostSession fNewHsn = null;

            try
            {
                message = string.Format(FConstants.err_m_0035, "File");

                // --

                // ***
                // OPC Device의 개수가 동일한지 검사
                // ***
                if (fOldOdr.fChildOpcDeviceCollection.count != fNewOdr.fChildOpcDeviceCollection.count)
                {
                    return false;
                }

                // --

                for (int i = 0; i < fOldOdr.fChildOpcDeviceCollection.count; i++)
                {
                    fOldOdv = fOldOdr.fChildOpcDeviceCollection[i];
                    fNewOdv = fNewOdr.fChildOpcDeviceCollection[i];

                    // --

                    // ***
                    // OPC Device의 Unique ID가 동일한지 검사 OPC Device의 구조가 변경되었는지 검사
                    // ***
                    if (fOldOdv.uniqueId != fNewOdv.uniqueId)
                    {
                        return false;
                    }

                    // ***
                    // OPC Device의 주요 Properties 정보가 변경되었는지 검사
                    // ***
                    if (fOldOdv.fProtocol != fNewOdv.fProtocol)
                    {
                        return false;
                    }

                    if (fOldOdv.fProtocol == FProtocol.KEPWARE)
                    {
                        if (fOldOdv.url != fNewOdv.url)
                        {
                            return false;
                        }

                        if (fOldOdv.clientHandle != fNewOdv.clientHandle)
                        {
                            return false;
                        }

                        if (fOldOdv.localId != fNewOdv.localId)
                        {
                            return false;
                        }

                        if (fOldOdv.defaultNamespace != fNewOdv.defaultNamespace)
                        {
                            return false;
                        }

                        if (fOldOdv.keepAliveTime != fNewOdv.keepAliveTime)
                        {
                            return false;
                        }

                        if (fOldOdv.eventReloadTime != fNewOdv.eventReloadTime)
                        {
                            return false;
                        }

                        if (fOldOdv.t2Timeout != fNewOdv.t2Timeout)
                        {
                            return false;
                        }

                        if (fOldOdv.t3Timeout != fNewOdv.t3Timeout)
                        {
                            return false;
                        }

                        if (fOldOdv.t5Timeout != fNewOdv.t5Timeout)
                        {
                            return false;
                        }                        
                    }

                    // --

                    // ***
                    // OPC Session의 개수가 동일한지 검사
                    // ***
                    if (fOldOdv.fChildOpcSessionCollection.count != fNewOdv.fChildOpcSessionCollection.count)
                    {
                        return false;
                    }

                    // --

                    for (int j = 0; j < fOldOdv.fChildOpcSessionCollection.count; j++)
                    {
                        fOldOsn = fOldOdv.fChildOpcSessionCollection[j];
                        fNewOsn = fNewOdv.fChildOpcSessionCollection[j];

                        // --

                        // ***
                        // OPC Session의 Unique ID가 동일한지 검사 OPC Session의 구조가 변경되었는지 검사
                        // ***
                        if (fOldOsn.uniqueId != fNewOsn.uniqueId)
                        {
                            return false;
                        }

                        if (fOldOsn.sessionId != fNewOsn.sessionId)
                        {
                            return false;
                        }

                        if (fOldOsn.channel != fNewOsn.channel)
                        {
                            return false;
                        }
                    }   // OPC Session for end 
                }   // OPC Device for end

                // --

                // ***
                // Host Device의 개수가 동일한지 검사
                // ***
                if (fOldOdr.fChildHostDeviceCollection.count != fNewOdr.fChildHostDeviceCollection.count)
                {
                    return false;
                }

                // --

                for (int i = 0; i < fOldOdr.fChildHostDeviceCollection.count; i++)
                {
                    fOldHdv = fOldOdr.fChildHostDeviceCollection[i];
                    fNewHdv = fNewOdr.fChildHostDeviceCollection[i];

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
                fOldOdv = null;
                fOldOsn = null;
                fOldHdv = null;
                fOldHsn = null;
                // --
                fNewOdv = null;
                fNewOsn = null;
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
                    ModelingFileChanged(this, new FModelingFileChangedEventArgs(m_fOpcDriver));
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
                        m_fOpcDriver, 
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
                fEventPusher.pushPreEvent(new FStoragePerformedEventArgs(FEventId.StoragePerformed, this.fOpcDriver, fLog, fScenarioData));
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
                fEventPusher.pushPreEvent(new FStoragePerformedEventArgs(FEventId.StoragePerformed, this.fOpcDriver, fLog, fScenarioData));

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
                fEventPusher.pushPreEvent(new FStoragePerformedEventArgs(FEventId.StoragePerformed, this.fOpcDriver, fLog, fScenarioData));

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
