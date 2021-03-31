/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FProtocolAgent.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.15
--  Description     : FAMate Core FaPlcDriver Protocol Agent Class
--  History         : Created by Jeff.Kim at 2013.07.15
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.IO;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal class FProtocolAgent : IDisposable
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FPcdCore m_fPcdCore = null;
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
            FPcdCore fScdCore
            )
        {
            m_fPcdCore = fScdCore;
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
                    m_fPcdCore = null;
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

        public FPcdCore fPcdCore
        {
            get
            {
                try
                {
                    return m_fPcdCore;
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

        public FPlcDriver fPlcDriver
        {
            get
            {
                try
                {
                    return m_fPcdCore.fPlcDriver;
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

        public void openPlcDevice(
            FPlcDevice fPlcDevice
            )
        {
            FBaseProtocol fProtocol = null;

            try
            {
                fPlcDevice.init();

                if (fPlcDevice.fProtocol == FProtocol.MELSECE)
                {
                    fProtocol = new FMelseceProtocol(m_fPcdCore, fPlcDevice);
                }
                else if (fPlcDevice.fProtocol == FProtocol.MODBUS)
                {
                    //fProtocol = new FModbusProtocol(m_fScdCore, fSecsDevice);
                }                
                fProtocol.open();

                // --

                m_protocolList.Add(fPlcDevice.uniqueId, fProtocol);
                m_autoCycleAgentList.Add(fPlcDevice.uniqueId, new FAutoCycleAgent(this.fPlcDriver));
                foreach (FPlcSession fPsn in fPlcDevice.fChildPlcSessionCollection)
                {
                    if (fPsn.hasLibrary)
                    {
                        m_autoTraceAgnetList.Add(fPsn.uniqueId, new FAutoTraceAgent(this.fPlcDriver));
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

        public void closePlcDevice(
            FPlcDevice fPlcDevice
            )
        {
            FBaseProtocol fProtocol = null;

            try
            {
                if (!m_protocolList.ContainsKey(fPlcDevice.uniqueId))
                {
                    return;
                }

                // --

                fProtocol = m_protocolList[fPlcDevice.uniqueId];
                fProtocol.close();
                fProtocol.Dispose();
                fProtocol = null;

                // --

                m_protocolList.Remove(fPlcDevice.uniqueId);
                m_autoCycleAgentList.Remove(fPlcDevice.uniqueId);
                foreach (FPlcSession fPsn in fPlcDevice.fChildPlcSessionCollection)
                {
                    if (fPsn.hasLibrary)
                    {
                        m_autoTraceAgnetList.Remove(fPsn.uniqueId);
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

        public void writePlcMessageTransfer(
            FPlcSession fPlcSession,
            FPlcMessageTransfer fPlcMessageTransfer
            )
        {

            FPlcDevice fPdv = null;

            try
            {
                fPdv = fPlcSession.fParent;
                if (fPdv == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "Device"));
                }

                if (!m_protocolList.ContainsKey(fPdv.uniqueId))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0029, "Device"));
                }

                // --

                 FPlcDriverCommon.setPlcWordRandomValue(fPlcMessageTransfer.fXmlNode);

                // --

                m_protocolList[fPdv.uniqueId].write(fPlcSession, fPlcMessageTransfer);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPdv = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void readPlcMessageTransfer(
            FPlcSession fPlcSession,
            FPlcMessageTransfer fPlcMessageTransfer
            )
        {
            FPlcDevice fPdv = null;

            try
            {
                fPdv = fPlcSession.fParent;
                if (fPdv == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "Device"));
                }

                if (!m_protocolList.ContainsKey(fPdv.uniqueId))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0029, "Device"));
                }

                // --

                m_protocolList[fPdv.uniqueId].read(fPlcSession, fPlcMessageTransfer);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPdv = null;
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
                if (!File.Exists(this.fPlcDriver.hostDriverDirectory + "//" + fHostDevice.driver))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "Host Driver"));
                }

                // --

                fHostDevice.init();
                fProtocol = new FHostProtocol(m_fPcdCore, fHostDevice);
                fProtocol.open();

                // --
                
                m_protocolList.Add(fHostDevice.uniqueId, fProtocol);
                m_autoCycleAgentList.Add(fHostDevice.uniqueId, new FAutoCycleAgent(this.fPlcDriver));
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
                    FDebug.throwFException(string.Format(FConstants.err_m_0028, "Device"));
                }

                // --

                FPlcDriverCommon.setHostItemRandomValue(fHostMessageTransfer.fXmlNode);

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

        private void runPlcAutoTransmitter(
            FXmlNode fXmlNodePtn
            )
        {
            FScenarioData fScenarioData = null;

            try
            {
                // ***
                // 최초 Scenario Data 생성
                // ***
                fScenarioData = new FScenarioData(this.fPcdCore);
                fScenarioData.setScenario(new FScenario(this.fPcdCore, fXmlNodePtn.fParentNode));
                fScenarioData.setEquipment(new FEquipment(this.fPcdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));

                // --

                m_fPcdCore.fEventPusher.pushPlcTransmitterRaisedEvent(
                    FResultCode.Success,
                    string.Empty,
                    fXmlNodePtn,
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

        public void runPlcAutoActionFirstSelectTransmitter(
            FPlcDevice fPlcDevice
            )
        {
            const string Query =
                FXmlTagEQM.E_EquipmentModeling + "/" +
                FXmlTagEQP.E_Equipment + "/" +
                FXmlTagSNG.E_ScenarioGroup + "/" +
                FXmlTagSNR.E_Scenario + "/" +
                FXmlTagPTN.E_PlcTransmitter +
                "[" +
                "@" + FXmlTagPTN.A_AutoActionFirstSelect + "='{0}' and " +
                FXmlTagPTF.E_PlcTransfer + "[@" + FXmlTagPTF.A_PlcDeviceId + "='{1}']" +
                "]";

            // --

            FXmlNodeList fXmlNodeListPtn = null;

            try
            {
                if (m_autoActionFirstSelectKeys.Contains(fPlcDevice.uniqueId))
                {
                    return;
                }
                m_autoActionFirstSelectKeys.Add(fPlcDevice.uniqueId);

                // --

                fXmlNodeListPtn = this.fPlcDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fPlcDevice.uniqueIdToString));
                foreach (FXmlNode fXmlNodePtn in fXmlNodeListPtn)
                {
                    runPlcAutoTransmitter(fXmlNodePtn);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListPtn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void runPlcAutoActionFirstCloseTransmitter(
            FPlcDevice fPlcDevice
            )
        {
            const string Query =
                FXmlTagEQM.E_EquipmentModeling + "/" +
                FXmlTagEQP.E_Equipment + "/" +
                FXmlTagSNG.E_ScenarioGroup + "/" +
                FXmlTagSNR.E_Scenario + "/" +
                FXmlTagPTN.E_PlcTransmitter +
                "[" +
                "@" + FXmlTagPTN.A_AutoActionFirstClose + "='{0}' and " +
                FXmlTagPTF.E_PlcTransfer + "[@" + FXmlTagPTF.A_PlcDeviceId + "='{1}']" +
                "]";

            // --

            FXmlNodeList fXmlNodeListPtn = null;

            try
            {
                if (m_autoActionFirstCloseKeys.Contains(fPlcDevice.uniqueId))
                {
                    return;
                }
                m_autoActionFirstCloseKeys.Add(fPlcDevice.uniqueId);

                // --

                fXmlNodeListPtn = this.fPlcDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fPlcDevice.uniqueIdToString));
                foreach (FXmlNode fXmlNodePtn in fXmlNodeListPtn)
                {
                    runPlcAutoTransmitter(fXmlNodePtn);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListPtn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void runPlcAutoActionAlwaysSelectTransmitter(
            FPlcDevice fPlcDevice
            )
        {
            const string Query =
                FXmlTagEQM.E_EquipmentModeling + "/" +
                FXmlTagEQP.E_Equipment + "/" +
                FXmlTagSNG.E_ScenarioGroup + "/" +
                FXmlTagSNR.E_Scenario + "/" +
                FXmlTagPTN.E_PlcTransmitter +
                "[" +
                "@" + FXmlTagPTN.A_AutoActionAlwaysSelect + "='{0}' and " +
                FXmlTagPTF.E_PlcTransfer + "[@" + FXmlTagPTF.A_PlcDeviceId + "='{1}']" +
                "]";

            // --

            FXmlNodeList fXmlNodeListPtn = null;

            try
            {
                fXmlNodeListPtn = this.fPlcDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fPlcDevice.uniqueIdToString));
                foreach (FXmlNode fXmlNodePtn in fXmlNodeListPtn)
                {
                    runPlcAutoTransmitter(fXmlNodePtn);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListPtn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void runPlcAutoActionAlwaysCloseTransmitter(
            FPlcDevice fPlcDevice
            )
        {
            const string Query =
                FXmlTagEQM.E_EquipmentModeling + "/" +
                FXmlTagEQP.E_Equipment + "/" +
                FXmlTagSNG.E_ScenarioGroup + "/" +
                FXmlTagSNR.E_Scenario + "/" +
                FXmlTagPTN.E_PlcTransmitter +
                "[" +
                "@" + FXmlTagPTN.A_AutoActionAlwaysClose + "='{0}' and " +
                FXmlTagPTF.E_PlcTransfer + "[@" + FXmlTagPTF.A_PlcDeviceId + "='{1}']" +
                "]";

            // --

            FXmlNodeList fXmlNodeListPtn = null;

            try
            {
                fXmlNodeListPtn = this.fPlcDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fPlcDevice.uniqueIdToString));
                foreach (FXmlNode fXmlNodePtn in fXmlNodeListPtn)
                {
                    runPlcAutoTransmitter(fXmlNodePtn);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListPtn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void runPlcAutoCycleTransmitter(
            FPlcDevice fPlcDevice
            )
        {
            FAutoCycleAgent fAutoCycleAgent = null;

            try
            {
                if (!m_autoCycleAgentList.ContainsKey(fPlcDevice.uniqueId))
                {
                    return;
                }

                // --

                fAutoCycleAgent = m_autoCycleAgentList[fPlcDevice.uniqueId];
                fAutoCycleAgent.collectPlcAutoCycleData(fPlcDevice);
                foreach (FAutoCycleData fData in fAutoCycleAgent.getTimeoutAutoCycleData())
                {
                    runPlcAutoTransmitter(fData.fXmlNode);
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

        public void clearPlcAutoCycleTransmitter(
            FPlcDevice fPlcDevice
            )
        {
            try
            {
                if (!m_autoCycleAgentList.ContainsKey(fPlcDevice.uniqueId))
                {
                    return;
                }
                m_autoCycleAgentList[fPlcDevice.uniqueId].clear();
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
                fScenarioData = new FScenarioData(this.fPcdCore);
                fScenarioData.setScenario(new FScenario(this.fPcdCore, fXmlNodeHtn.fParentNode));
                fScenarioData.setEquipment(new FEquipment(this.fPcdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));

                // --

                m_fPcdCore.fEventPusher.pushHostTransmitterRaisedEvent(
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

                fXmlNodeListHtn = this.fPlcDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fHostDevice.uniqueIdToString));
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

                fXmlNodeListHtn = this.fPlcDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fHostDevice.uniqueIdToString));
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
                fXmlNodeListHtn = this.fPlcDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fHostDevice.uniqueIdToString));
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
                fXmlNodeListHtn = this.fPlcDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fHostDevice.uniqueIdToString));
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
                fXmlNodeListHcn = this.fPlcDriver.fXmlNode.selectNodes(xpath);
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

        public void runPlcAutoTraceMessage(
            FPlcDevice fPlcDevice
            )
        {
            FAutoTraceAgent fAutoTraceAgent = null;
            FPlcMessage fPlcMessage = null;

            try
            {
                foreach (FPlcSession fPsn in fPlcDevice.fChildPlcSessionCollection)
                {
                    if (!m_autoTraceAgnetList.ContainsKey(fPsn.uniqueId))
                    {
                        continue;
                    }

                    // --

                    fAutoTraceAgent = m_autoTraceAgnetList[fPsn.uniqueId];
                    fAutoTraceAgent.collectPlcAutoTraceData(fPsn);
                    foreach (FAutoTraceData fData in fAutoTraceAgent.getTimeoutAutoTraceData())
                    {
                        fPlcMessage = new FPlcMessage(this.fPcdCore, fData.fXmlNode);
                        readPlcMessageTransfer(fPsn, fPlcMessage.createTransfer());
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
                fPlcMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void clearAutoTraceMessage(
            FPlcDevice fPlcDevice
            )
        {
            try
            {
                foreach (FPlcSession fPsn in fPlcDevice.fChildPlcSessionCollection)
                {
                    if (!m_autoTraceAgnetList.ContainsKey(fPsn.uniqueId))
                    {
                        continue;
                    }
                    m_autoTraceAgnetList[fPsn.uniqueId].clear();
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
