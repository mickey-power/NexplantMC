/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FScdCore.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.28
--  Description     : FAMate Core FaSecsDriver SECS Driver Core Class 
--  History         : Created by spike.lee at 2011.01.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.IO;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal class FScdCore : IDisposable
    {
        
        //------------------------------------------------------------------------------------------------------------------------

        public event FModelingFileChangedEventHandler ModelingFileChanged = null;

        // --

        private bool m_disposed = false;
        // --                
        private static FIDPointer32 m_fScdCoreIdPointer = null;
        private UInt32 m_fScdCoreId = 0;
        // --
        private FSecsDriver m_fSecsDriver = null;
        private FXmlDocument m_fXmlDoc = null;
        private FXmlNode m_fXmlNodeScd = null;
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

        public FScdCore(
            )
        {
            init();              
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FScdCore(
            FXmlDocument fXmlDoc
            )
        {
            // ***
            // SECS Driver Clone 전용
            // *** 
            init(fXmlDoc);
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FScdCore(
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

        public FSecsDriver fSecsDriver
        {
            get
            {
                try
                {
                    return m_fSecsDriver;
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
                    m_fSecsDriver = value;
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

        public FXmlNode fXmlNodeScd
        {
            get
            {
                try
                {
                    return m_fXmlNodeScd;
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
        // 2012.11.19 by spike.lee
        // New Object init
        // ***
        private void init(
            )
        {
            FDebugLogArgs fDebugLogArgs = null;
            FXmlNode fXmlNodeFam = null;
            FXmlNode fXmlNodeScd = null;
            FXmlNode fXmlNodeSet = null;
            FXmlNode fXmlNodeOnd = null;
            FXmlNode fXmlNodeOnl = null;
            FXmlNode fXmlNodeUtd = null;
            FXmlNode fXmlNodeUtn = null;            

            try
            {
                if (m_fScdCoreIdPointer == null)
                {
                    m_fScdCoreIdPointer = new FIDPointer32();
                }
                m_fScdCoreId = m_fScdCoreIdPointer.uniqueId;

                // --

                // ***
                // FScdCore Creation Log Write
                // ***               
                fDebugLogArgs = new FDebugLogArgs(FDebugLogCategory.Information, "FScdCoreCreate", this.GetType(), "init");
                fDebugLogArgs.additionInfo = "FScdCoreId=<" + m_fScdCoreId.ToString() + ">";
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

                fXmlNodeFam = m_fXmlDoc.appendChild(FSecsDriverCommon.createXmlNodeFAM(m_fXmlDoc));                
                // --
                fXmlNodeScd = fXmlNodeFam.appendChild(FSecsDriverCommon.createXmlNodeSCD(m_fXmlDoc));
                fXmlNodeScd.set_attrVal(FXmlTagSCD.A_UniqueId, FXmlTagSCD.D_UniqueId, m_fIdPointer.uniqueId.ToString());

                // --

                // ***
                // 기본 Setup Object 생성
                // ***
                fXmlNodeSet = fXmlNodeScd.appendChild(FSecsDriverCommon.createXmlNodeSET(m_fXmlDoc));
                // --
                fXmlNodeOnd = fXmlNodeSet.appendChild(FSecsDriverCommon.createXmlNodeOND(m_fXmlDoc));   // Object Name Definition
                foreach (FObjectType type in Enum.GetValues(typeof(FObjectType)))
                {
                    fXmlNodeOnl = fXmlNodeOnd.appendChild(FSecsDriverCommon.createXmlNodeONL(m_fXmlDoc));
                    fXmlNodeOnl.set_attrVal(FXmlTagONL.A_UniqueId, FXmlTagONL.D_UniqueId, m_fIdPointer.uniqueId.ToString());
                    fXmlNodeOnl.set_attrVal(FXmlTagONL.A_Name, FXmlTagONL.D_Name, type.ToString());
                    fXmlNodeOnl.set_attrVal(FXmlTagONL.A_ObjectType, FXmlTagONL.D_ObjectType, type.ToString());
                }
                // --
                fXmlNodeSet.appendChild(FSecsDriverCommon.createXmlNodeFND(m_fXmlDoc));                 // Function Name Definition
                // --
                fXmlNodeUtd = fXmlNodeSet.appendChild(FSecsDriverCommon.createXmlNodeUTD(m_fXmlDoc));   // User Tag Definition
                foreach (FObjectType type in Enum.GetValues(typeof(FObjectType)))
                {
                    fXmlNodeUtn = fXmlNodeUtd.appendChild(FSecsDriverCommon.createXmlNodeUTN(m_fXmlDoc));
                    fXmlNodeUtn.set_attrVal(FXmlTagUTN.A_UniqueId, FXmlTagUTN.D_UniqueId, m_fIdPointer.uniqueId.ToString());
                    fXmlNodeUtn.set_attrVal(FXmlTagUTN.A_Name, FXmlTagUTN.D_Name, type.ToString());
                    fXmlNodeUtn.set_attrVal(FXmlTagUTN.A_ObjectType, FXmlTagUTN.D_ObjectType, type.ToString());
                }
                // --
                fXmlNodeSet.appendChild(FSecsDriverCommon.createXmlNodeDCD(m_fXmlDoc));     // Data Conversion Set Definition
                fXmlNodeSet.appendChild(FSecsDriverCommon.createXmlNodeESD(m_fXmlDoc));     // Equipment State Set Definition
                fXmlNodeSet.appendChild(FSecsDriverCommon.createXmlNodeRPD(m_fXmlDoc));     // Repository Definition           
                fXmlNodeSet.appendChild(FSecsDriverCommon.createXmlNodeEND(m_fXmlDoc));     // Environment Definition
                fXmlNodeSet.appendChild(FSecsDriverCommon.createXmlNodeDSD(m_fXmlDoc));     // Data Set Definition

                // --

                // ***
                // 기본 Modeling Object 생성
                // ***
                fXmlNodeScd.appendChild(FSecsDriverCommon.createXmlNodeSLM(m_fXmlDoc));     // SECS Library Modeling
                fXmlNodeScd.appendChild(FSecsDriverCommon.createXmlNodeSDM(m_fXmlDoc));     // SECS Device Modeling
                fXmlNodeScd.appendChild(FSecsDriverCommon.createXmlNodeHLM(m_fXmlDoc));     // Host Library Modeling               
                fXmlNodeScd.appendChild(FSecsDriverCommon.createXmlNodeHDM(m_fXmlDoc));     // Host Device Modeling               
                fXmlNodeScd.appendChild(FSecsDriverCommon.createXmlNodeEQM(m_fXmlDoc));     // Equipment Modeling

                // --

                m_fXmlNodeScd = fXmlNodeScd;

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
                fXmlNodeScd = null;

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
        // 2012.11.19 by spike.lee
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
                if (m_fScdCoreIdPointer == null)
                {
                    m_fScdCoreIdPointer = new FIDPointer32();
                }
                m_fScdCoreId = m_fScdCoreIdPointer.uniqueId;

                // --

                // ***
                // FScdCore Creation Log Write
                // ***               
                fDebugLogArgs = new FDebugLogArgs(FDebugLogCategory.Information, "FScdCoreCreate", this.GetType(), "init");
                fDebugLogArgs.additionInfo = "FScdCoreId=<" + m_fScdCoreId.ToString() + ">";
                FDebug.writeLog(fDebugLogArgs);
                
                // --

                m_fXmlDoc = fXmlDoc;

                // --

                fXmlNodeFam = m_fXmlDoc.selectSingleNode(FXmlTagFAM.E_FAMate);
                m_fXmlNodeScd = fXmlNodeFam.selectSingleNode(FXmlTagSCD.E_SecsDriver);

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

                // ***
                // 2012.11.19 by spike.lee
                // FLogWriter Class에서 사용될 EAP Name 설정
                // (SECS Driver에서 EAP 이름을 변경할 경우에도 m_fConfig의 eapName Property를 변경해야 한다.)
                // ***
                m_fConfig.eapName = m_fXmlNodeScd.get_attrVal(FXmlTagSCD.A_EapName, FXmlTagSCD.D_EapName);

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

                if (m_fLogWriter != null)
                {
                    m_fLogWriter.Dispose();
                    m_fLogWriter = null;
                }

                // --

                m_fSecsDriver = null;

                if (m_fXmlNodeScd != null)
                {
                    m_fXmlNodeScd.Dispose();
                    m_fXmlNodeScd = null;
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
                // FScdCore Termination Log Write
                // ***
                fDebugLogArgs = new FDebugLogArgs(FDebugLogCategory.Information, "FScdCoreTerminate", this.GetType(), "term");
                fDebugLogArgs.additionInfo = "FScdCoreId=<" + m_fScdCoreId.ToString() + ">";
                FDebug.writeLog(fDebugLogArgs);                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fDebugLogArgs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void resetDeviceState(
            )
        {
            try
            {
                // ***
                // SECS Device State를 Closed로 초기화
                // ***
                foreach (FXmlNode fXmlNodeSdv in m_fXmlNodeScd.selectNodes(FXmlTagSDM.E_SecsDeviceModeling + "/" + FXmlTagSDV.E_SecsDevice))
                {
                    fXmlNodeSdv.set_attrVal(FXmlTagSDV.A_State, FXmlTagSDV.D_State, FEnumConverter.fromDeviceState(FDeviceState.Closed));
                }

                // ***
                // Host Device State를 Closed로 초기화
                // ***
                foreach (FXmlNode fXmlNodeHdv in m_fXmlNodeScd.selectNodes(FXmlTagHDM.E_HostDeviceModeling + "/" + FXmlTagHDV.E_HostDevice))
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

                // ***
                // 2012.11.19 by spike.lee
                // SECS Device와 Host Device의 State를 Closed로 초기화
                // ***
                resetDeviceState();

                // --

                // ***
                // Modeling File Open Completed Event
                // ***
                m_fEventPusher.pushEvent(
                    new FModelingFileOpenCompletedEventArgs(FEventId.ModelingFileOpenCompleted, m_fSecsDriver, fileName)
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
            FSecsDriver fNewSdr = null;            
            string message = string.Empty;

            try
            {
                // ***
                // 새로운 Modeling File를 Open 한다.
                // ***
                fNewSdr = new FSecsDriver();
                fNewSdr.openModelingFile(fileName);

                // --

                if (!validateReopenModelingFile(m_fSecsDriver, fNewSdr, ref message))
                {
                    System.Diagnostics.Debug.WriteLine("ReopenFiled=" + message);
                    // --
                    m_fEventPusher.pushEvent(
                        new FModelingFileReopenFailedEventArgs(FEventId.ModelingFileReopenFailed, m_fSecsDriver, fileName, message)
                        );
                    // --
                    return false;
                }

                // --

                fNewSdr.Dispose();
                fNewSdr = null;

                // --

                m_fProtocolAgent.pauseProtocol();
                m_fEventPusher.waitEventHandlingCompleted();
                
                // --

                loadModelingFile(fileName);
                onModelingFileChanged();

                // --

                // ***
                // 2015.04.13 by spike.lee
                // SECS/Host Device State Setting
                // ***
                //foreach (FSecsDevice fSdv in m_fSecsDriver.fChildSecsDeviceCollection)
                //{
                //    fSdv.changeModelingFile(); 
                //}

                //foreach (FHostDevice fHdv in m_fSecsDriver.fChildHostDeviceCollection)
                //{
                //    fHdv.changeModelingFile(); 
                //}                  
                
                // --
                
                m_fSecsDriver.onModelingFileReopenPrecompleted(new FModelingFileReopenPrecompletedEventArgs(m_fSecsDriver, fileName));
                m_fProtocolAgent.continueProtocol();

                // --

                m_fEventPusher.pushEvent(
                    new FModelingFileReopenCompletedEventArgs(FEventId.ModelingFileReopenCompleted, m_fSecsDriver, fileName)
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
                if (fNewSdr != null)
                {
                    fNewSdr.Dispose();
                    fNewSdr = null;
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
                    new FModelingFileSaveCompletedEventArgs(FEventId.ModelingFileSaveCompleted, m_fSecsDriver, fileName)
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
            FXmlNode fXmlNodeScd = null;

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
                fXmlNodeScd = fXmlNodeFam.selectSingleNode(FXmlTagSCD.E_SecsDriver);

                // --                

                if (m_fIdPointer != null)
                {
                    m_fIdPointer.Dispose();
                    m_fIdPointer = null;
                }

                // --

                m_fIdPointer = fNewIdPointer;
                m_fXmlNodeScd = fXmlNodeScd;
                // --
                this.fSecsDriver.replace(this, m_fXmlNodeScd); 

                // --

                // ***
                // 2012.11.19 by spike.lee
                // FLogWriter Class에서 사용될 EAP Name 설정
                // (SECS Driver에서 EAP 이름을 변경할 경우에도 m_fConfig의 eapName Property를 변경해야 한다.)
                // ***
                m_fConfig.eapName = m_fXmlNodeScd.get_attrVal(FXmlTagSCD.A_EapName, FXmlTagSCD.D_EapName);

                // --

                // ***
                // 2012.02.22 by spike.lee 
                // - Modeling File Structure Migration
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
                fXmlNodeScd = null;
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
            FXmlNode fXmlNodeSlm = null;
            FXmlNode fXmlNodeSdm = null;
            FXmlNode fXmlNodeHlm = null;
            FXmlNode fXmlNodeHdm = null;
            FXmlNode fXmlNodeEqm = null;

            try
            {
                // ***
                // Setup 계열
                // ***
                fXmlNodeSet = m_fXmlNodeScd.selectSingleNode(FXmlTagSET.E_Setup);
                if (fXmlNodeSet == null)
                {
                    fXmlNodeSet = m_fXmlNodeScd.appendChild(FSecsDriverCommon.createXmlNodeSET(m_fXmlDoc));
                }
                // --
                fXmlNodeOnd = fXmlNodeSet.selectSingleNode(FXmlTagOND.E_ObjectNameDefinition);
                if (fXmlNodeOnd == null)
                {
                    fXmlNodeOnd = fXmlNodeSet.appendChild(FSecsDriverCommon.createXmlNodeOND(m_fXmlDoc));
                }
                // --
                fXmlNodeFnd = fXmlNodeSet.selectSingleNode(FXmlTagFND.E_FunctionNameDefinition);
                if (fXmlNodeFnd == null)
                {
                    fXmlNodeFnd = fXmlNodeSet.appendChild(FSecsDriverCommon.createXmlNodeFND(m_fXmlDoc));
                }
                // --
                fXmlNodeUtd = fXmlNodeSet.selectSingleNode(FXmlTagUTD.E_UserTagNameDefinition);
                if (fXmlNodeUtd == null)
                {
                    fXmlNodeUtd = fXmlNodeSet.appendChild(FSecsDriverCommon.createXmlNodeUTD(m_fXmlDoc));
                }
                // --
                fXmlNodeDcd = fXmlNodeSet.selectSingleNode(FXmlTagDCD.E_DataConversionSetDefinition);
                if (fXmlNodeDcd == null)
                {
                    fXmlNodeDcd = fXmlNodeSet.appendChild(FSecsDriverCommon.createXmlNodeDCD(m_fXmlDoc));
                }
                // --
                fXmlNodeEsd = fXmlNodeSet.selectSingleNode(FXmlTagESD.E_EquipmentStateSetDefinition);
                if (fXmlNodeEsd == null)
                {
                    fXmlNodeEsd = fXmlNodeSet.appendChild(FSecsDriverCommon.createXmlNodeESD(m_fXmlDoc));
                }
                // --
                fXmlNodeRpd = fXmlNodeSet.selectSingleNode(FXmlTagRPD.E_RepositoryDefinition);
                if (fXmlNodeRpd == null)
                {
                    fXmlNodeRpd = fXmlNodeSet.appendChild(FSecsDriverCommon.createXmlNodeRPD(m_fXmlDoc));
                }
                // --
                fXmlNodeEnd = fXmlNodeSet.selectSingleNode(FXmlTagEND.E_EnvironmentDefinition);
                if (fXmlNodeEnd == null)
                {
                    fXmlNodeEnd = fXmlNodeSet.appendChild(FSecsDriverCommon.createXmlNodeEND(m_fXmlDoc));
                }
                // --
                fXmlNodeDsd = fXmlNodeSet.selectSingleNode(FXmlTagDSD.E_DataSetDefinition);
                if (fXmlNodeDsd == null)
                {
                    fXmlNodeDsd = fXmlNodeSet.appendChild(FSecsDriverCommon.createXmlNodeDSD(m_fXmlDoc));
                }

                // --

                // ***
                // Modeling 계열
                // ***
                fXmlNodeSlm = m_fXmlNodeScd.selectSingleNode(FXmlTagSLM.E_SecsLibraryModeling);
                if (fXmlNodeSlm == null)
                {
                    fXmlNodeSlm = m_fXmlNodeScd.appendChild(FSecsDriverCommon.createXmlNodeSLM(m_fXmlDoc));
                }
                // --
                fXmlNodeSdm = m_fXmlNodeScd.selectSingleNode(FXmlTagSDM.E_SecsDeviceModeling);
                if (fXmlNodeSdm == null)
                {
                    fXmlNodeSdm = m_fXmlNodeScd.appendChild(FSecsDriverCommon.createXmlNodeSDM(m_fXmlDoc));
                }
                // --
                fXmlNodeHlm = m_fXmlNodeScd.selectSingleNode(FXmlTagHLM.E_HostLibraryModeling);
                if (fXmlNodeHlm == null)
                {
                    fXmlNodeHlm = m_fXmlNodeScd.appendChild(FSecsDriverCommon.createXmlNodeHLM(m_fXmlDoc));
                }
                // --
                fXmlNodeHdm = m_fXmlNodeScd.selectSingleNode(FXmlTagHDM.E_HostDeviceModeling);
                if (fXmlNodeHdm == null)
                {
                    fXmlNodeHdm = m_fXmlNodeScd.appendChild(FSecsDriverCommon.createXmlNodeHDM(m_fXmlDoc));
                }
                // --
                fXmlNodeEqm = m_fXmlNodeScd.selectSingleNode(FXmlTagEQM.E_EquipmentModeling);
                if (fXmlNodeEqm == null)
                {
                    fXmlNodeEqm = m_fXmlNodeScd.appendChild(FSecsDriverCommon.createXmlNodeEQM(m_fXmlDoc));
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
                if (fXmlNodeSlm != null)
                {
                    fXmlNodeSlm.Dispose();
                    fXmlNodeSlm = null;
                }
                if (fXmlNodeSdm != null)
                {
                    fXmlNodeSdm.Dispose();
                    fXmlNodeSdm = null;
                }
                if (fXmlNodeHlm != null)
                {
                    fXmlNodeHlm.Dispose();
                    fXmlNodeHlm = null;
                }
                if (fXmlNodeHdm != null)
                {
                    fXmlNodeHdm.Dispose();
                    fXmlNodeHdm = null;
                }
                if (fXmlNodeEqm != null)
                {
                    fXmlNodeEqm.Dispose();
                    fXmlNodeEqm = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void migrateModelingFile(
            )
        {
            FXmlNodeList fXmlNodeList = null;
            string xpath = string.Empty;

            try
            {
                // ***
                // No Format SECS Item Migration
                // ***
                xpath = "//" + FXmlTagSIT.E_SecsItem + "[not(@" + FXmlTagSIT.A_Format + ")]";
                fXmlNodeList = m_fXmlDoc.selectNodes(xpath);
                if (fXmlNodeList.count > 0)
                {
                    System.Diagnostics.Debug.WriteLine("NoFormatSecsItemCount=" + fXmlNodeList.count.ToString());
                    // --
                    foreach (FXmlNode fXmlNode in fXmlNodeList)
                    {
                        fXmlNode.set_attrVal(FXmlTagSIT.A_Format, FXmlTagSIT.D_Format, "L");    // Default Format: List
                    }
                }

                // --

                // ***
                // No Pattern Secs Item Migration
                // ***
                xpath = "//" + FXmlTagSIT.E_SecsItem + "[not(@" + FXmlTagSIT.A_Pattern + ")]";
                fXmlNodeList = m_fXmlDoc.selectNodes(xpath);
                if (fXmlNodeList.count > 0)
                {
                    System.Diagnostics.Debug.WriteLine("NoPatternSecsItemCount=" + fXmlNodeList.count.ToString());
                    // --
                    foreach (FXmlNode fXmlNode in fXmlNodeList)
                    {
                        fXmlNode.set_attrVal(FXmlTagSIT.A_Pattern, FXmlTagSIT.D_Pattern, "F");  // Default Pattern: Fixed
                    }
                }                

                // -- 

                // ***
                // No Format Host Item Migration
                // ***
                xpath = "//" + FXmlTagHIT.E_HostItem + "[not(@" + FXmlTagHIT.A_Format + ")]";
                fXmlNodeList = m_fXmlDoc.selectNodes(xpath);
                if (fXmlNodeList.count > 0)
                {
                    System.Diagnostics.Debug.WriteLine("NoFormatHostItemCount=" + fXmlNodeList.count.ToString());
                    // --
                    foreach (FXmlNode fXmlNode in fXmlNodeList)
                    {
                        fXmlNode.set_attrVal(FXmlTagHIT.A_Format, FXmlTagHIT.D_Format, "L");    // Default Format: List
                    }
                }

                // --

                // ***
                // No Pattern Host Item Migration
                // ***
                xpath = "//" + FXmlTagHIT.E_HostItem + "[not(@" + FXmlTagHIT.A_Pattern + ")]";
                fXmlNodeList = m_fXmlDoc.selectNodes(xpath);
                if (fXmlNodeList.count > 0)
                {
                    System.Diagnostics.Debug.WriteLine("NoPatternHostItemCount=" + fXmlNodeList.count.ToString());
                    // --
                    foreach (FXmlNode fXmlNode in fXmlNodeList)
                    {
                        fXmlNode.set_attrVal(FXmlTagHIT.A_Pattern, FXmlTagHIT.D_Pattern, "F");    // Default Pattern: Fxied
                    }
                }

                // --

                // ***
                // No Format Column Migration
                // ***
                xpath = "//" + FXmlTagCOL.E_Column + "[not(@" + FXmlTagCOL.A_Format + ")]";
                fXmlNodeList = m_fXmlDoc.selectNodes(xpath);
                if (fXmlNodeList.count > 0)
                {
                    System.Diagnostics.Debug.WriteLine("NoFormatColumnCount=" + fXmlNodeList.count.ToString());
                    // --
                    foreach (FXmlNode fXmlNode in fXmlNodeList)
                    {
                        fXmlNode.set_attrVal(FXmlTagCOL.A_Format, FXmlTagCOL.D_Format, "L");    // Default Format: List
                    }
                }

                // --

                // ***
                // No Format Environment Migration
                // ***
                xpath = "//" + FXmlTagENV.E_Environment + "[not(@" + FXmlTagENV.A_Format + ")]";
                fXmlNodeList = m_fXmlDoc.selectNodes(xpath);
                if (fXmlNodeList.count > 0)
                {
                    System.Diagnostics.Debug.WriteLine("NoFormatEnvironmentCount=" + fXmlNodeList.count.ToString());
                    // --
                    foreach (FXmlNode fXmlNode in fXmlNodeList)
                    {
                        fXmlNode.set_attrVal(FXmlTagENV.A_Format, FXmlTagENV.D_Format, "L");    // Default Format: List
                    }
                }

                // --

                // ***
                // No Format Data Migration
                // ***
                xpath = "//" + FXmlTagDAT.E_Data + "[not(@" + FXmlTagDAT.A_Format + ")]";
                fXmlNodeList = m_fXmlDoc.selectNodes(xpath);
                if (fXmlNodeList.count > 0)
                {
                    System.Diagnostics.Debug.WriteLine("NoFormatDataCount=" + fXmlNodeList.count.ToString());
                    // --
                    foreach (FXmlNode fXmlNode in fXmlNodeList)
                    {
                        fXmlNode.set_attrVal(FXmlTagDAT.A_Format, FXmlTagDAT.D_Format, "L");    // Default Format: List
                    }
                }

                // --

                // ***
                // No Pattern Data Migration
                // ***
                xpath = "//" + FXmlTagDAT.E_Data + "[not(@" + FXmlTagDAT.A_Pattern + ")]";
                fXmlNodeList = m_fXmlDoc.selectNodes(xpath);
                if (fXmlNodeList.count > 0)
                {
                    System.Diagnostics.Debug.WriteLine("NoPatternDataCount=" + fXmlNodeList.count.ToString());
                    // --
                    foreach (FXmlNode fXmlNode in fXmlNodeList)
                    {
                        fXmlNode.set_attrVal(FXmlTagDAT.A_Pattern, FXmlTagDAT.D_Pattern, "F");  // Default Pattern: Fixed
                    }
                }     
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeList = null;
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
                fXmlNodeOnd = m_fXmlNodeScd.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagOND.E_ObjectNameDefinition);
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
                                fXmlNodeOnl = fXmlNodeOnd.appendChild(FSecsDriverCommon.createXmlNodeONL(m_fXmlDoc));
                            }
                            else
                            {
                                fXmlNodeOnl = fXmlNodeOnd.insertBefore(FSecsDriverCommon.createXmlNodeONL(m_fXmlDoc), fXmlNodeOnd.fFirstChild);
                            }
                        }
                        else
                        {
                            fXmlNodeOnl = fXmlNodeOnd.insertAfter(FSecsDriverCommon.createXmlNodeONL(m_fXmlDoc), fXmlNodeTmp);
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
                fXmlNodeUtd = m_fXmlNodeScd.selectSingleNode(FXmlTagSET.E_Setup + "/" + FXmlTagUTD.E_UserTagNameDefinition);
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
                                fXmlNodeUtn = fXmlNodeUtd.appendChild(FSecsDriverCommon.createXmlNodeUTN(m_fXmlDoc));
                            }
                            else
                            {
                                fXmlNodeUtn = fXmlNodeUtd.insertBefore(FSecsDriverCommon.createXmlNodeUTN(m_fXmlDoc), fXmlNodeUtd.fFirstChild);
                            }
                        }
                        else
                        {
                            fXmlNodeUtn = fXmlNodeUtd.insertAfter(FSecsDriverCommon.createXmlNodeUTN(m_fXmlDoc), fXmlNodeTmp);
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
            FSecsDriver fOldSdr,
            FSecsDriver fNewSdr,
            ref string message
            )
        {
            FSecsDevice fOldSdv = null;
            FSecsSession fOldSsn = null;
            FHostDevice fOldHdv = null;
            FHostSession fOldHsn = null;
            // --
            FSecsDevice fNewSdv = null;
            FSecsSession fNewSsn = null;
            FHostDevice fNewHdv = null;
            FHostSession fNewHsn = null;

            try
            {
                message = string.Format(FConstants.err_m_0035, "File");

                // --

                // ***
                // SECS Device의 개수가 동일한지 검사
                // ***
                if (fOldSdr.fChildSecsDeviceCollection.count != fNewSdr.fChildSecsDeviceCollection.count)
                {
                    return false;
                }

                // --

                for (int i = 0; i < fOldSdr.fChildSecsDeviceCollection.count; i++)
                {
                    fOldSdv = fOldSdr.fChildSecsDeviceCollection[i];
                    fNewSdv = fNewSdr.fChildSecsDeviceCollection[i];

                    // --

                    // ***
                    // SECS Device의 Unique ID가 동일한지 검사 SECS Device의 구조가 변경되었는지 검사
                    // ***
                    if (fOldSdv.uniqueId != fNewSdv.uniqueId)
                    {
                        return false;
                    }

                    // ***
                    // SECS Device의 주요 Properties 정보가 변경되었는지 검사
                    // ***
                    if (fOldSdv.fDeviceMode != fNewSdv.fDeviceMode)
                    {
                        return false;
                    }

                    if (fOldSdv.fProtocol != fNewSdv.fProtocol)
                    {
                        return false;
                    }

                    if (fOldSdv.fProtocol == FProtocol.HSMS)
                    {
                        if (fOldSdv.fConnectMode != fNewSdv.fConnectMode)
                        {
                            return false;
                        }

                        if (fOldSdv.fConnectMode == FConnectMode.Active)
                        {
                            if (fOldSdv.localIp != fNewSdv.localIp)
                            {
                                return false;
                            }

                            if (fOldSdv.remoteIp != fNewSdv.remoteIp)
                            {
                                return false;
                            }

                            if (fOldSdv.remotePort != fNewSdv.remotePort)
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (fOldSdv.localIp != fNewSdv.localIp)
                            {
                                return false;
                            }

                            if (fOldSdv.localPort != fNewSdv.localPort)
                            {
                                return false;
                            }
                        }

                        if (fOldSdv.linkTestTimePeriod != fNewSdv.linkTestTimePeriod)
                        {
                            return false;
                        }

                        if (fOldSdv.t3Timeout != fNewSdv.t3Timeout)
                        {
                            return false;
                        }

                        if (fOldSdv.t5Timeout != fNewSdv.t5Timeout)
                        {
                            return false;
                        }

                        if (fOldSdv.t6Timeout != fNewSdv.t6Timeout)
                        {
                            return false;
                        }

                        if (fOldSdv.t7Timeout != fNewSdv.t7Timeout)
                        {
                            return false;
                        }

                        if (fOldSdv.t8Timeout != fNewSdv.t8Timeout)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (fOldSdv.fProtocol == FProtocol.TCPIP || fOldSdv.fProtocol == FProtocol.TELNET)
                        {
                            if (fOldSdv.fConnectMode != fNewSdv.fConnectMode)
                            {
                                return false;
                            }

                            if (fOldSdv.fConnectMode == FConnectMode.Active)
                            {
                                if (fOldSdv.localIp != fNewSdv.localIp)
                                {
                                    return false;
                                }

                                if (fOldSdv.remoteIp != fNewSdv.remoteIp)
                                {
                                    return false;
                                }

                                if (fOldSdv.remotePort != fNewSdv.remotePort)
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                if (fOldSdv.localIp != fNewSdv.localIp)
                                {
                                    return false;
                                }

                                if (fOldSdv.localPort != fNewSdv.localPort)
                                {
                                    return false;
                                }
                            }
                        }
                        else if (fOldSdv.fProtocol == FProtocol.SECS1)
                        {
                            if (fOldSdv.serialPort != fNewSdv.serialPort)
                            {
                                return false;
                            }

                            if (fOldSdv.baud != fNewSdv.baud)
                            {
                                return false;
                            }
                        }

                        if (fOldSdv.rbit != fNewSdv.rbit)
                        {
                            return false;
                        }

                        if (fOldSdv.interleave != fNewSdv.interleave)
                        {
                            return false;
                        }

                        if (fOldSdv.duplicateError != fNewSdv.duplicateError)
                        {
                            return false;
                        }

                        if (fOldSdv.ignoreSystemBytes != fNewSdv.ignoreSystemBytes)
                        {
                            return false;
                        }

                        if (fOldSdv.retryLimit != fNewSdv.retryLimit)
                        {
                            return false;
                        }

                        if (fOldSdv.t1Timeout != fNewSdv.t1Timeout)
                        {
                            return false;
                        }

                        if (fOldSdv.t2Timeout != fNewSdv.t2Timeout)
                        {
                            return false;
                        }

                        if (fOldSdv.t3Timeout != fNewSdv.t3Timeout)
                        {
                            return false;
                        }

                        if (fOldSdv.t4Timeout != fNewSdv.t4Timeout)
                        {
                            return false;
                        }
                    }

                    // --

                    // ***
                    // SECS Session의 개수가 동일한지 검사
                    // ***
                    if (fOldSdv.fChildSecsSessionCollection.count != fNewSdv.fChildSecsSessionCollection.count)
                    {
                        return false;
                    }

                    // --

                    for (int j = 0; j < fOldSdv.fChildSecsSessionCollection.count; j++)
                    {
                        fOldSsn = fOldSdv.fChildSecsSessionCollection[j];
                        fNewSsn = fNewSdv.fChildSecsSessionCollection[j];

                        // --

                        // ***
                        // SECS Session의 Unique ID가 동일한지 검사 SECS Session의 구조가 변경되었는지 검사
                        // ***
                        if (fOldSsn.uniqueId != fNewSsn.uniqueId)
                        {
                            return false;
                        }
                    }   // Secs Session for end 
                }   // Secs Device for end

                // --

                // ***
                // Host Device의 개수가 동일한지 검사
                // ***
                if (fOldSdr.fChildHostDeviceCollection.count != fNewSdr.fChildHostDeviceCollection.count)
                {
                    return false;
                }

                // --

                for (int i = 0; i < fOldSdr.fChildHostDeviceCollection.count; i++)
                {
                    fOldHdv = fOldSdr.fChildHostDeviceCollection[i];
                    fNewHdv = fNewSdr.fChildHostDeviceCollection[i];

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

                    // ***
                    // Host Driver Option은 Check 불가
                    // ***
                    //if (fOldHdv.driverOption != fNewHdv.driverOption)
                    //{
                    //    return false;
                    //}

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
                fOldSdv = null;
                fOldSsn = null;
                fOldHdv = null;
                fOldHsn = null;
                // --
                fNewSdv = null;
                fNewSsn = null;
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
                    ModelingFileChanged(this, new FModelingFileChangedEventArgs(m_fSecsDriver));
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
                        m_fSecsDriver, 
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
                fEventPusher.pushPreEvent(new FStoragePerformedEventArgs(FEventId.StoragePerformed, this.fSecsDriver, fLog, fScenarioData));                
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
                fEventPusher.pushPreEvent(new FStoragePerformedEventArgs(FEventId.StoragePerformed, this.fSecsDriver, fLog, fScenarioData));   
             
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
                fEventPusher.pushPreEvent(new FStoragePerformedEventArgs(FEventId.StoragePerformed, this.fSecsDriver, fLog, fScenarioData)); 

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
