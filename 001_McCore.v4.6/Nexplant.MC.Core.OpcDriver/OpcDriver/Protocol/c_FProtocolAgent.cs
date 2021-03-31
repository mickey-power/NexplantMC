/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FProtocolAgent.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.15
--  Description     : FAMate Core FaOpcDriver Protocol Agent Class
--  History         : Created by Jeff.Kim at 2013.07.15
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.IO;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    internal class FProtocolAgent : IDisposable
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FOcdCore m_fOcdCore = null;
        private Dictionary<UInt64, FBaseProtocol> m_protocolList = null;
        // --
        private FTidStorage m_fHostTidStorage = null;
        // --
        private HashSet<UInt64> m_autoActionFirstSelectKeys = null;
        private HashSet<UInt64> m_autoActionFirstCloseKeys = null;
        private Dictionary<UInt64, FAutoCycleAgent> m_autoCycleAgentList = null;
        private Dictionary<UInt64, FAutoTraceAgent> m_autoTraceAgnetList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FProtocolAgent(        
            FOcdCore fScdCore
            )
        {
            m_fOcdCore = fScdCore;
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FProtocolAgent(
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
                    m_fOcdCore = null;
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

        public FOcdCore fOcdCore
        {
            get
            {
                try
                {
                    return m_fOcdCore;
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

        public FOpcDriver fOpcDriver
        {
            get
            {
                try
                {
                    return m_fOcdCore.fOpcDriver;
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

        public FTidStorage fHostTidStorage
        {
            get
            {
                try
                {
                    return m_fHostTidStorage;
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

        private void init(
            )
        {
            try
            {
                m_protocolList = new Dictionary<UInt64, FBaseProtocol>();
                m_fHostTidStorage = new FTidStorage();
                // --
                m_autoActionFirstSelectKeys = new HashSet<UInt64>();
                m_autoActionFirstCloseKeys = new HashSet<UInt64>();
                m_autoCycleAgentList = new Dictionary<UInt64, FAutoCycleAgent>();
                m_autoTraceAgnetList = new Dictionary<UInt64, FAutoTraceAgent>();
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
            try
            {
                m_protocolList = null;               
                // --
                if (m_fHostTidStorage != null)
                {
                    m_fHostTidStorage.Dispose();
                    m_fHostTidStorage = null;
                }
                // --
                m_autoActionFirstSelectKeys = null;
                m_autoActionFirstCloseKeys = null;
                m_autoCycleAgentList = null;
                m_autoTraceAgnetList = null;
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

        public void openOpcDevice(
            FOpcDevice fOpcDevice
            )
        {
            FBaseProtocol fProtocol = null;

            try
            {
                // --

                fOpcDevice.init();
                if (
                    fOpcDevice.fProtocol == FProtocol.KEPWARE ||
                    fOpcDevice.fProtocol == FProtocol.OPCDA ||
                    fOpcDevice.fProtocol == FProtocol.OPCUA
                    )
                {
                    fProtocol = new FKepwareProtocol(m_fOcdCore, fOpcDevice);
                }                
                fProtocol.open();

                // --

                m_protocolList.Add(fOpcDevice.uniqueId, fProtocol);                
                foreach (FOpcSession fOsn in fOpcDevice.fChildOpcSessionCollection)
                {
                    if (fOsn.hasLibrary)
                    {
                        m_autoCycleAgentList.Add(fOsn.uniqueId, new FAutoCycleAgent(this.fOpcDriver));
                        m_autoTraceAgnetList.Add(fOsn.uniqueId, new FAutoTraceAgent(this.fOpcDriver));
                    }
                }
            }
            catch (Exception ex)
            {
                if (fProtocol != null)
                {
                    fProtocol.Dispose();
                }
                // --
                FDebug.throwException(ex);
            }
            finally
            {
                fProtocol = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void closeOpcDevice(
            FOpcDevice fOpcDevice
            )
        {
            FBaseProtocol fProtocol = null;

            try
            {
                if (!m_protocolList.ContainsKey(fOpcDevice.uniqueId))
                {
                    return;
                }

                // --

                fProtocol = m_protocolList[fOpcDevice.uniqueId];
                fProtocol.close();
                fProtocol.Dispose();
                fProtocol = null;

                // --

                m_protocolList.Remove(fOpcDevice.uniqueId);                
                foreach (FOpcSession fOsn in fOpcDevice.fChildOpcSessionCollection)
                {
                    if (fOsn.hasLibrary)
                    {
                        m_autoCycleAgentList.Remove(fOsn.uniqueId);
                        m_autoTraceAgnetList.Remove(fOsn.uniqueId);
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fProtocol = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void refreshOpcSessionItemName(
            FOpcSession fOpcSession
            )
        {
            try
            {
                if (!m_protocolList.ContainsKey(fOpcSession.fParent.uniqueId))
                {
                    return;
                }

                // --

                ((FKepwareProtocol)m_protocolList[fOpcSession.fParent.uniqueId]).refreshOpcSessionItemName(fOpcSession);
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

        public void writeOpcMessageTransfer(
            FOpcSession fOpcSession,
            FOpcMessageTransfer fOpcMessageTransfer
            )
        {

            FOpcDevice fOdv = null;

            try
            {
                fOdv = fOpcSession.fParent;
                if (fOdv == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "Device"));
                }

                if (!m_protocolList.ContainsKey(fOdv.uniqueId))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0029, "Device"));
                }

                // --

                 FOpcDriverCommon.setOpcItemRandomValue(fOpcMessageTransfer.fXmlNode);

                // --

                m_protocolList[fOdv.uniqueId].write(fOpcSession, fOpcMessageTransfer);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fOdv = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void readOpcMessageTransfer(
            FOpcSession fOpcSession,
            FOpcMessageTransfer fOpcMessageTransfer
            )
        {
            FOpcDevice fOdv = null;

            try
            {
                fOdv = fOpcSession.fParent;
                if (fOdv == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "Device"));
                }

                if (!m_protocolList.ContainsKey(fOdv.uniqueId))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0029, "Device"));
                }

                // --

                m_protocolList[fOdv.uniqueId].read(fOpcSession, fOpcMessageTransfer);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fOdv = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void openHostDevice(
            FHostDevice fHostDevice
            )
        {
            FBaseProtocol fProtocol = null;

            try
            {
                // ***
                // Host Driver가 설정되어 있는지 검사
                // ***
                if (fHostDevice.driver == string.Empty)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0033, "Host Driver"));
                }

                // ***
                // Host Driver가 존재하는지 검사
                // ***
                if (!File.Exists(this.fOpcDriver.hostDriverDirectory + "//" + fHostDevice.driver))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "Host Driver"));
                }

                // --

                fHostDevice.init();
                fProtocol = new FHostProtocol(m_fOcdCore, fHostDevice);
                fProtocol.open();

                // --

                m_protocolList.Add(fHostDevice.uniqueId, fProtocol);
                m_autoCycleAgentList.Add(fHostDevice.uniqueId, new FAutoCycleAgent(this.fOpcDriver));
            }
            catch (Exception ex)
            {
                if (fProtocol != null)
                {
                    fProtocol.Dispose();
                }
                FDebug.throwException(ex);
            }
            finally
            {
                fProtocol = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void closeHostDevice(
            FHostDevice fHostDevice
            )
        {
            FBaseProtocol fProtocol = null;

            try
            {
                fProtocol = m_protocolList[fHostDevice.uniqueId];
                fProtocol.close();
                fProtocol.Dispose();
                fProtocol = null;

                // --

                m_protocolList.Remove(fHostDevice.uniqueId);
                m_autoCycleAgentList.Remove(fHostDevice.uniqueId);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fProtocol = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void sendHostMessageTransfer(
            FHostSession fHostSession,
            FHostMessageTransfer fHostMessageTransfer
            )
        {
            FHostDevice fHdv = null;

            try
            {
                fHdv = fHostSession.fParent;
                if (fHdv == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "Device"));
                }

                if (!m_protocolList.ContainsKey(fHdv.uniqueId))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0029, "Device"));
                }

                // --

                FOpcDriverCommon.setHostItemRandomValue(fHostMessageTransfer.fXmlNode);

                // --

                m_protocolList[fHdv.uniqueId].send(fHostSession, fHostMessageTransfer);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fHdv = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void runOpcAutoTransmitter(
            FXmlNode fXmlNodeOtn
            )
        {
            FScenarioData fScenarioData = null;

            try
            {
                // ***
                // 최초 Scenario Data 생성
                // ***
                fScenarioData = new FScenarioData(this.fOcdCore);
                fScenarioData.setScenario(new FScenario(this.fOcdCore, fXmlNodeOtn.fParentNode));
                fScenarioData.setEquipment(new FEquipment(this.fOcdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));

                // --

                m_fOcdCore.fEventPusher.pushOpcTransmitterRaisedEvent(
                    FResultCode.Success,
                    string.Empty,
                    fXmlNodeOtn,
                    fScenarioData,
                    false
                    );

                // --

                // ***
                // Transmitter가 처리될 때까지 대기
                // ***
                while (!fScenarioData.transmitterCompleted)
                {
                    if (System.Windows.Forms.Application.MessageLoop)
                    {
                        System.Windows.Forms.Application.DoEvents();
                    }
                    System.Threading.Thread.Sleep(1);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fScenarioData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void runOpcAutoActionFirstSelectTransmitter(
            FOpcDevice fOpcDevice
            )
        {
            const string Query =
                FXmlTagEQM.E_EquipmentModeling + "/" +
                FXmlTagEQP.E_Equipment + "/" +
                FXmlTagSNG.E_ScenarioGroup + "/" +
                FXmlTagSNR.E_Scenario + "/" +
                FXmlTagOTN.E_OpcTransmitter +
                "[" +
                "@" + FXmlTagOTN.A_AutoActionFirstSelect + "='{0}' and " +
                FXmlTagOTF.E_OpcTransfer + "[@" + FXmlTagOTF.A_OpcDeviceId + "='{1}']" +
                "]";

            // --

            FXmlNodeList fXmlNodeListOtn = null;

            try
            {
                if (m_autoActionFirstSelectKeys.Contains(fOpcDevice.uniqueId))
                {
                    return;
                }
                m_autoActionFirstSelectKeys.Add(fOpcDevice.uniqueId);

                // --

                fXmlNodeListOtn = this.fOpcDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fOpcDevice.uniqueIdToString));
                foreach (FXmlNode fXmlNodePtn in fXmlNodeListOtn)
                {
                    runOpcAutoTransmitter(fXmlNodePtn);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListOtn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void runOpcAutoActionFirstSelectTransmitter(
            FOpcDevice fOpcDevice,
            FOpcSession fOpcSession
            )
        {
            const string Query =
                FXmlTagEQM.E_EquipmentModeling + "/" +
                FXmlTagEQP.E_Equipment + "/" +
                FXmlTagSNG.E_ScenarioGroup + "/" +
                FXmlTagSNR.E_Scenario + "/" +
                FXmlTagOTN.E_OpcTransmitter +
                "[" +
                "@" + FXmlTagOTN.A_AutoActionFirstSelect + "='{0}' and " +
                FXmlTagOTF.E_OpcTransfer + "[@" + FXmlTagOTF.A_OpcSessionId + "='{1}']" +
                "]";

            // --

            FXmlNodeList fXmlNodeListOtn = null;

            try
            {
                if (m_autoActionFirstSelectKeys.Contains(fOpcDevice.uniqueId))
                {
                    return;
                }
                m_autoActionFirstSelectKeys.Add(fOpcDevice.uniqueId);

                // --

                fXmlNodeListOtn = this.fOpcDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fOpcSession.uniqueIdToString));
                foreach (FXmlNode fXmlNodePtn in fXmlNodeListOtn)
                {
                    runOpcAutoTransmitter(fXmlNodePtn);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListOtn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void runOpcAutoActionFirstCloseTransmitter(
            FOpcDevice fOpcDevice
            )
        {
            const string Query =
                FXmlTagEQM.E_EquipmentModeling + "/" +
                FXmlTagEQP.E_Equipment + "/" +
                FXmlTagSNG.E_ScenarioGroup + "/" +
                FXmlTagSNR.E_Scenario + "/" +
                FXmlTagOTN.E_OpcTransmitter +
                "[" +
                "@" + FXmlTagOTN.A_AutoActionFirstClose + "='{0}' and " +
                FXmlTagOTF.E_OpcTransfer + "[@" + FXmlTagOTF.A_OpcDeviceId + "='{1}']" +
                "]";

            // --

            FXmlNodeList fXmlNodeListOtn = null;

            try
            {
                if (m_autoActionFirstCloseKeys.Contains(fOpcDevice.uniqueId))
                {
                    return;
                }
                m_autoActionFirstCloseKeys.Add(fOpcDevice.uniqueId);

                // --

                fXmlNodeListOtn = this.fOpcDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fOpcDevice.uniqueIdToString));
                foreach (FXmlNode fXmlNodePtn in fXmlNodeListOtn)
                {
                    runOpcAutoTransmitter(fXmlNodePtn);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListOtn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void runOpcAutoActionAlwaysSelectTransmitter(
            FOpcDevice fOpcDevice
            )
        {
            const string Query =
                FXmlTagEQM.E_EquipmentModeling + "/" +
                FXmlTagEQP.E_Equipment + "/" +
                FXmlTagSNG.E_ScenarioGroup + "/" +
                FXmlTagSNR.E_Scenario + "/" +
                FXmlTagOTN.E_OpcTransmitter +
                "[" +
                "@" + FXmlTagOTN.A_AutoActionAlwaysSelect + "='{0}' and " +
                FXmlTagOTF.E_OpcTransfer + "[@" + FXmlTagOTF.A_OpcDeviceId + "='{1}']" +
                "]";

            // --

            FXmlNodeList fXmlNodeListOtn = null;

            try
            {
                fXmlNodeListOtn = this.fOpcDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fOpcDevice.uniqueIdToString));
                foreach (FXmlNode fXmlNodePtn in fXmlNodeListOtn)
                {
                    runOpcAutoTransmitter(fXmlNodePtn);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListOtn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void runOpcAutoActionAlwaysSelectTransmitter(
            FOpcDevice fOpcDevice,
            FOpcSession fOpcSession
            )
        {
            const string Query =
                FXmlTagEQM.E_EquipmentModeling + "/" +
                FXmlTagEQP.E_Equipment + "/" +
                FXmlTagSNG.E_ScenarioGroup + "/" +
                FXmlTagSNR.E_Scenario + "/" +
                FXmlTagOTN.E_OpcTransmitter +
                "[" +
                "@" + FXmlTagOTN.A_AutoActionAlwaysSelect + "='{0}' and " +
                FXmlTagOTF.E_OpcTransfer + "[@" + FXmlTagOTF.A_OpcSessionId + "='{1}']" +
                "]";

            // --

            FXmlNodeList fXmlNodeListOtn = null;

            try
            {
                fXmlNodeListOtn = this.fOpcDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fOpcSession.uniqueIdToString));
                foreach (FXmlNode fXmlNodePtn in fXmlNodeListOtn)
                {
                    runOpcAutoTransmitter(fXmlNodePtn);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListOtn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void runOpcAutoActionAlwaysCloseTransmitter(
            FOpcDevice fOpcDevice
            )
        {
            const string Query =
                FXmlTagEQM.E_EquipmentModeling + "/" +
                FXmlTagEQP.E_Equipment + "/" +
                FXmlTagSNG.E_ScenarioGroup + "/" +
                FXmlTagSNR.E_Scenario + "/" +
                FXmlTagOTN.E_OpcTransmitter +
                "[" +
                "@" + FXmlTagOTN.A_AutoActionAlwaysClose + "='{0}' and " +
                FXmlTagOTF.E_OpcTransfer + "[@" + FXmlTagOTF.A_OpcDeviceId + "='{1}']" +
                "]";

            // --

            FXmlNodeList fXmlNodeListOtn = null;

            try
            {
                fXmlNodeListOtn = this.fOpcDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fOpcDevice.uniqueIdToString));
                foreach (FXmlNode fXmlNodePtn in fXmlNodeListOtn)
                {
                    runOpcAutoTransmitter(fXmlNodePtn);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListOtn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void runOpcAutoCycleTransmitter(
            FOpcDevice fOpcDevice
            )
        {
            FAutoCycleAgent fAutoCycleAgent = null;

            try
            {
                if (!m_autoCycleAgentList.ContainsKey(fOpcDevice.uniqueId))
                {
                    return;
                }

                // --

                fAutoCycleAgent = m_autoCycleAgentList[fOpcDevice.uniqueId];
                fAutoCycleAgent.collectOpcAutoCycleData(fOpcDevice);
                foreach (FAutoCycleData fData in fAutoCycleAgent.getTimeoutAutoCycleData())
                {
                    runOpcAutoTransmitter(fData.fXmlNode);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fAutoCycleAgent = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void clearOpcAutoCycleTransmitter(
            FOpcDevice fOpcDevice
            )
        {
            try
            {
                if (m_autoCycleAgentList.ContainsKey(fOpcDevice.uniqueId))
                {
                    m_autoCycleAgentList[fOpcDevice.uniqueId].clear();
                }               

                // --

                foreach (FOpcSession fOsn in fOpcDevice.fChildOpcSessionCollection)
                {
                    if (!m_autoCycleAgentList.ContainsKey(fOsn.uniqueId))
                    {
                        continue;
                    }
                    m_autoCycleAgentList[fOsn.uniqueId].clear();
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

        public void runOpcAutoCycleTransmitter(
            FOpcSession fOpcSession
            )
        {
            FAutoCycleAgent fAutoCycleAgent = null;

            try
            {
                if (!m_autoCycleAgentList.ContainsKey(fOpcSession.uniqueId))
                {
                    return;
                }

                // --

                fAutoCycleAgent = m_autoCycleAgentList[fOpcSession.uniqueId];
                fAutoCycleAgent.collectOpcAutoCycleData(fOpcSession);
                foreach (FAutoCycleData fData in fAutoCycleAgent.getTimeoutAutoCycleData())
                {
                    runOpcAutoTransmitter(fData.fXmlNode);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fAutoCycleAgent = null;
            }
        }
               
        //------------------------------------------------------------------------------------------------------------------------

        private void runHostAutoTransmitter(
            FXmlNode fXmlNodeHtn
            )
        {
            FScenarioData fScenarioData = null;

            try
            {
                // ***
                // 최초 Scenario Data 생성
                // ***
                fScenarioData = new FScenarioData(this.fOcdCore);
                fScenarioData.setScenario(new FScenario(this.fOcdCore, fXmlNodeHtn.fParentNode));
                fScenarioData.setEquipment(new FEquipment(this.fOcdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));

                // --

                m_fOcdCore.fEventPusher.pushHostTransmitterRaisedEvent(
                    FResultCode.Success,
                    string.Empty,
                    fXmlNodeHtn,
                    fScenarioData,
                    false
                    );

                // --

                // ***
                // Transmitter가 처리될 때까지 대기
                // ***
                while (!fScenarioData.transmitterCompleted)
                {
                    if (System.Windows.Forms.Application.MessageLoop)
                    {
                        System.Windows.Forms.Application.DoEvents();
                    }
                    System.Threading.Thread.Sleep(1);
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

        public void runHostAutoActionFirstSelectTransmitter(
            FHostDevice fHostDevice
            )
        {
            const string Query =
                FXmlTagEQM.E_EquipmentModeling + "/" +
                FXmlTagEQP.E_Equipment + "/" +
                FXmlTagSNG.E_ScenarioGroup + "/" +
                FXmlTagSNR.E_Scenario + "/" +
                FXmlTagHTN.E_HostTransmitter +
                "[" +
                "@" + FXmlTagHTN.A_AutoActionFirstSelect + "='{0}' and " +
                FXmlTagHTF.E_HostTransfer + "[@" + FXmlTagHTF.A_HostDeviceId + "='{1}']" +
                "]";

            // --

            FXmlNodeList fXmlNodeListHtn = null;

            try
            {
                if (m_autoActionFirstSelectKeys.Contains(fHostDevice.uniqueId))
                {
                    return;
                }
                m_autoActionFirstSelectKeys.Add(fHostDevice.uniqueId);

                // --

                fXmlNodeListHtn = this.fOpcDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fHostDevice.uniqueIdToString));
                foreach (FXmlNode fXmlNodeHtn in fXmlNodeListHtn)
                {
                    runHostAutoTransmitter(fXmlNodeHtn);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListHtn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void runHostAutoActionFirstCloseTransmitter(
            FHostDevice fHostDevice
            )
        {
            const string Query =
                FXmlTagEQM.E_EquipmentModeling + "/" +
                FXmlTagEQP.E_Equipment + "/" +
                FXmlTagSNG.E_ScenarioGroup + "/" +
                FXmlTagSNR.E_Scenario + "/" +
                FXmlTagHTN.E_HostTransmitter +
                "[" +
                "@" + FXmlTagHTN.A_AutoActionFirstClose + "='{0}' and " +
                FXmlTagHTF.E_HostTransfer + "[@" + FXmlTagHTF.A_HostDeviceId + "='{1}']" +
                "]";

            // --

            FXmlNodeList fXmlNodeListHtn = null;

            try
            {
                if (m_autoActionFirstCloseKeys.Contains(fHostDevice.uniqueId))
                {
                    return;
                }
                m_autoActionFirstCloseKeys.Add(fHostDevice.uniqueId);

                // --

                fXmlNodeListHtn = this.fOpcDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fHostDevice.uniqueIdToString));
                foreach (FXmlNode fXmlNodeHtn in fXmlNodeListHtn)
                {
                    runHostAutoTransmitter(fXmlNodeHtn);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListHtn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void runHostAutoActionAlwaysSelectTransmitter(
            FHostDevice fHostDevice
            )
        {
            const string Query =
                FXmlTagEQM.E_EquipmentModeling + "/" +
                FXmlTagEQP.E_Equipment + "/" +
                FXmlTagSNG.E_ScenarioGroup + "/" +
                FXmlTagSNR.E_Scenario + "/" +
                FXmlTagHTN.E_HostTransmitter +
                "[" +
                "@" + FXmlTagHTN.A_AutoActionAlwaysSelect + "='{0}' and " +
                FXmlTagHTF.E_HostTransfer + "[@" + FXmlTagHTF.A_HostDeviceId + "='{1}']" +
                "]";

            // --

            FXmlNodeList fXmlNodeListHtn = null;

            try
            {
                fXmlNodeListHtn = this.fOpcDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fHostDevice.uniqueIdToString));
                foreach (FXmlNode fXmlNodeHtn in fXmlNodeListHtn)
                {
                    runHostAutoTransmitter(fXmlNodeHtn);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListHtn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void runHostAutoActionAlwaysCloseTransmitter(
            FHostDevice fHostDevice
            )
        {
            const string Query =
                FXmlTagEQM.E_EquipmentModeling + "/" +
                FXmlTagEQP.E_Equipment + "/" +
                FXmlTagSNG.E_ScenarioGroup + "/" +
                FXmlTagSNR.E_Scenario + "/" +
                FXmlTagHTN.E_HostTransmitter +
                "[" +
                "@" + FXmlTagHTN.A_AutoActionAlwaysClose + "='{0}' and " +
                FXmlTagHTF.E_HostTransfer + "[@" + FXmlTagHTF.A_HostDeviceId + "='{1}']" +
                "]";

            // --

            FXmlNodeList fXmlNodeListHtn = null;

            try
            {
                fXmlNodeListHtn = this.fOpcDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fHostDevice.uniqueIdToString));
                foreach (FXmlNode fXmlNodeHtn in fXmlNodeListHtn)
                {
                    runHostAutoTransmitter(fXmlNodeHtn);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListHtn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void runHostAutoCycleTransmitter(
            FHostDevice fHostDevice
            )
        {
            FAutoCycleAgent fAutoCycleAgent = null;

            try
            {
                if (!m_autoCycleAgentList.ContainsKey(fHostDevice.uniqueId))
                {
                    return;
                }

                // --

                fAutoCycleAgent = m_autoCycleAgentList[fHostDevice.uniqueId];
                // --
                fAutoCycleAgent.collectHostAutoCycleData(fHostDevice);
                foreach (FAutoCycleData fData in fAutoCycleAgent.getTimeoutAutoCycleData())
                {
                    runHostAutoTransmitter(fData.fXmlNode);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fAutoCycleAgent = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void clearHostAutoCycleTransmitter(
            FHostDevice fHostDevice
            )
        {
            try
            {
                if (!m_autoCycleAgentList.ContainsKey(fHostDevice.uniqueId))
                {
                    return;
                }
                m_autoCycleAgentList[fHostDevice.uniqueId].clear();
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

        public void clearHostRetryCondition(
            FHostDevice fHostDevice
            )
        {
            const string HostConditionQuery =
                FXmlTagEQM.E_EquipmentModeling +
                "/" + FXmlTagEQP.E_Equipment +
                "/" + FXmlTagSNG.E_ScenarioGroup +
                "/" + FXmlTagSNR.E_Scenario +
                "/" + FXmlTagHTR.E_HostTrigger +
                "/" + FXmlTagHCN.E_HostCondition +
                "[@" + FXmlTagHCN.A_ConditionMode + "='{0}' and" +
                " @" + FXmlTagHCN.A_HostDeviceId + "='{1}' and" +
                " @" + FXmlTagHCN.A_RetryCount + "!='0']";

            // --

            FXmlNodeList fXmlNodeListHcn = null;
            string xpath = string.Empty;

            try
            {
                xpath = string.Format(
                    HostConditionQuery,
                    FEnumConverter.fromConditionMode(FConditionMode.Timeout),
                    fHostDevice.uniqueIdToString
                    );
                fXmlNodeListHcn = this.fOpcDriver.fXmlNode.selectNodes(xpath);
                // --
                foreach (FXmlNode fXmlNodeHcn in fXmlNodeListHcn)
                {
                    fXmlNodeHcn.set_attrVal(FXmlTagHCN.A_RetryCount, FXmlTagHCN.D_RetryCount, "0");
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListHcn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void runOpcAutoTraceMessage(
            FOpcDevice fOpcDevice
            )
        {
            FAutoTraceAgent fAutoTraceAgent = null;
            FOpcMessage fOpcMessage = null;

            try
            {
                foreach (FOpcSession fOsn in fOpcDevice.fChildOpcSessionCollection)
                {
                    if (!m_autoTraceAgnetList.ContainsKey(fOsn.uniqueId))
                    {
                        continue;
                    }

                    // --

                    fAutoTraceAgent = m_autoTraceAgnetList[fOsn.uniqueId];
                    fAutoTraceAgent.collectOpcAutoTraceData(fOsn);
                    foreach (FAutoTraceData fData in fAutoTraceAgent.getTimeoutAutoTraceData())
                    {
                        fOpcMessage = new FOpcMessage(this.fOcdCore, fData.fXmlNode);
                        readOpcMessageTransfer(fOsn, fOpcMessage.createTransfer());
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fAutoTraceAgent = null;
                fOpcMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void runOpcAutoTraceMessage(
            FOpcSession fOsn
            )
        {
            FAutoTraceAgent fAutoTraceAgent = null;
            // FOpcMessage fOpcMessage = null;
            FXmlNode fXmlNodeOmt = null;

            try
            {
                if (!m_autoTraceAgnetList.ContainsKey(fOsn.uniqueId))
                {
                    return;
                }

                // --

                fAutoTraceAgent = m_autoTraceAgnetList[fOsn.uniqueId];
                fAutoTraceAgent.collectOpcAutoTraceData(fOsn);
                foreach (FAutoTraceData fData in fAutoTraceAgent.getTimeoutAutoTraceData())
                {
                    //fOpcMessage = new FOpcMessage(this.fOcdCore, fData.fXmlNode);
                    //readOpcMessageTransfer(fOsn, fOpcMessage.createTransfer());

                    // --

                    fXmlNodeOmt = fData.fXmlNode.clone(true);
                    fXmlNodeOmt.set_attrVal(FXmlTagOMT.A_MessageType, FXmlTagOMT.D_MessageType, FXmlTagOMT.M_MessageTransfer);
                    readOpcMessageTransfer(fOsn, new FOpcMessageTransfer(FOpcMessageTransferAreaType.Read, this.fOcdCore, fXmlNodeOmt));
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fAutoTraceAgent = null;
                fXmlNodeOmt = null;
                // fOpcMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void clearAutoTraceMessage(
            FOpcDevice fOpcDevice
            )
        {
            try
            {
                foreach (FOpcSession fOsn in fOpcDevice.fChildOpcSessionCollection)
                {
                    if (!m_autoTraceAgnetList.ContainsKey(fOsn.uniqueId))
                    {
                        continue;
                    }
                    m_autoTraceAgnetList[fOsn.uniqueId].clear();
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

        public void resetOpcAutoTraceMessage(
            FOpcSession fOsn
            )
        {
            FAutoTraceAgent fAutoTraceAgent = null;
            try
            {
                if (!m_autoTraceAgnetList.ContainsKey(fOsn.uniqueId))
                {
                    return;
                }

                // --

                fAutoTraceAgent = m_autoTraceAgnetList[fOsn.uniqueId];
                fAutoTraceAgent.resetAutoTraceData(fOsn);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fAutoTraceAgent = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FBaseProtocol getProtocol(
            UInt64 uniqueId
            )
        {
            FBaseProtocol fRet = null;

            try
            {
                if (m_protocolList.ContainsKey(uniqueId))
                {
                    return m_protocolList[uniqueId];
                }
                return fRet;
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

        // ***
        // Modeling File Reopen를 위한 Method
        // ***
        public void pauseProtocol(
            )
        {
            try
            {
                foreach (FBaseProtocol p in m_protocolList.Values)
                {
                    p.pauseProtocol();
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

        // ***
        // Modeling File Reopen를 위한 Method
        // ***
        public void continueProtocol(
            )
        {
            try
            {
                foreach (FBaseProtocol p in m_protocolList.Values)
                {
                    p.continueProtocol();
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

    }   // Class end
}   // Namespace end
