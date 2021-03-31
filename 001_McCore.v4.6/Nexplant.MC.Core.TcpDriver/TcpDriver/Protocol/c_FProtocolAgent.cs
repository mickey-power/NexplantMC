/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FProtocolAgent.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.15
--  Description     : FAMate Core FaTcpDriver Protocol Agent Class
--  History         : Created by Jeff.Kim at 2013.07.15
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.IO;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    internal class FProtocolAgent : IDisposable
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcdCore m_fTcdCore = null;
        private Dictionary<UInt64, FBaseProtocol> m_protocolList = null;
        // --
        private FTidStorage m_fTcpTidStorage = null;
        private FTidStorage m_fHostTidStorage = null;
        // --
        private HashSet<UInt64> m_autoActionFirstSelectKeys = null;
        private HashSet<UInt64> m_autoActionFirstCloseKeys = null;
        private Dictionary<UInt64, FAutoCycleAgent> m_autoCycleAgentList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FProtocolAgent(        
            FTcdCore fTcdCore
            )
        {
            m_fTcdCore = fTcdCore;
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
                    m_fTcdCore = null;
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

        public FTcdCore fTcdCore
        {
            get
            {
                try
                {
                    return m_fTcdCore;
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

        public FTcpDriver fTcpDriver
        {
            get
            {
                try
                {
                    return m_fTcdCore.fTcpDriver;
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

        //------------------------------------------------------------------------------------------------------------------------
        
        public FTidStorage fTcpTidStorage
        {
            get
            {
                try
                {
                    return m_fTcpTidStorage;
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
                m_fTcpTidStorage = new FTidStorage();
                m_fHostTidStorage = new FTidStorage();
                // --
                m_autoActionFirstSelectKeys = new HashSet<UInt64>();
                m_autoActionFirstCloseKeys = new HashSet<UInt64>();
                m_autoCycleAgentList = new Dictionary<UInt64, FAutoCycleAgent>();
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
                if (m_fTcpTidStorage != null)
                {
                    m_fTcpTidStorage.Dispose();
                    m_fTcpTidStorage = null;
                }
                if (m_fHostTidStorage != null)
                {
                    m_fHostTidStorage.Dispose();
                    m_fHostTidStorage = null;
                }
                // --
                m_autoActionFirstSelectKeys = null;
                m_autoActionFirstCloseKeys = null;
                m_autoCycleAgentList = null;
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

        public void openTcpDevice(
            FTcpDevice fTcpDevice
            )
        {
            FBaseProtocol fProtocol = null;

            try
            {
                fTcpDevice.init();

                // --

                // ***
                // 2016.04.12 by spike.lee
                // 향후 TCP 프로토콜을 지속적으로 추가해야 함.
                // ***
                //if (fTcpDevice.fProtocol == FProtocol.CUSTOM_001)
                //{
                    //fProtocol = new FCustom001Protocol(m_fTcdCore, fTcpDevice);
                //}

                //***
                // 2021.03.19 Modify by Sunghoon.Park 
                // TCP Driver 분리
                //*** 
                fProtocol = new FTcpProtocol(m_fTcdCore, fTcpDevice);
                fProtocol.open();

                // --

                m_protocolList.Add(fTcpDevice.uniqueId, fProtocol);
                m_autoCycleAgentList.Add(fTcpDevice.uniqueId, new FAutoCycleAgent(this.fTcpDriver));                
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

        public void closeTcpDevice(
            FTcpDevice fTcpDevice
            )
        {
            FBaseProtocol fProtocol = null;

            try
            {
                if (!m_protocolList.ContainsKey(fTcpDevice.uniqueId))
                {
                    return;
                }

                // --

                fProtocol = m_protocolList[fTcpDevice.uniqueId];
                fProtocol.close();
                fProtocol.Dispose();
                fProtocol = null;

                // --

                m_protocolList.Remove(fTcpDevice.uniqueId);
                m_autoCycleAgentList.Remove(fTcpDevice.uniqueId);
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

        public void sendTcpMessageTransfer(
            FTcpSession fTcpSession,
            FTcpMessageTransfer fTcpMessageTransfer
            )
        {
            FTcpDevice fTdv = null;

            try
            {
                fTdv = fTcpSession.fParent;
                if (fTdv == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "Device"));
                }

                if (!m_protocolList.ContainsKey(fTdv.uniqueId))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0029, "Device"));
                }

                // --

                 FTcpDriverCommon.setTcpItemRandomValue(fTcpMessageTransfer.fXmlNode);

                // --

                m_protocolList[fTdv.uniqueId].send(fTcpSession, fTcpMessageTransfer);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fTdv = null;
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
                if (!File.Exists(this.fTcpDriver.hostDriverDirectory + "//" + fHostDevice.driver))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "Host Driver"));
                }

                // --

                fHostDevice.init();
                fProtocol = new FHostProtocol(m_fTcdCore, fHostDevice);
                fProtocol.open();

                // --

                m_protocolList.Add(fHostDevice.uniqueId, fProtocol);
                m_autoCycleAgentList.Add(fHostDevice.uniqueId, new FAutoCycleAgent(this.fTcpDriver));
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

                FTcpDriverCommon.setHostItemRandomValue(fHostMessageTransfer.fXmlNode);

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

        private void runTcpAutoTransmitter(
            FXmlNode fXmlNodeTtn
            )
        {
            FScenarioData fScenarioData = null;

            try
            {
                // ***
                // 최초 Scenario Data 생성
                // ***
                fScenarioData = new FScenarioData(this.fTcdCore);
                fScenarioData.setScenario(new FScenario(this.fTcdCore, fXmlNodeTtn.fParentNode));
                fScenarioData.setEquipment(new FEquipment(this.fTcdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));

                // --

                m_fTcdCore.fEventPusher.pushTcpTransmitterRaisedEvent(
                    FResultCode.Success,
                    string.Empty,
                    fXmlNodeTtn,
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

        public void runTcpAutoActionFirstSelectTransmitter(
            FTcpDevice fTcpDevice
            )
        {
            const string Query =
                FXmlTagEQM.E_EquipmentModeling + "/" +
                FXmlTagEQP.E_Equipment + "/" +
                FXmlTagSNG.E_ScenarioGroup + "/" +
                FXmlTagSNR.E_Scenario + "/" +
                FXmlTagTTN.E_TcpTransmitter +
                "[" +
                "@" + FXmlTagTTN.A_AutoActionFirstSelect + "='{0}' and " +
                FXmlTagTTF.E_TcpTransfer + "[@" + FXmlTagTTF.A_TcpDeviceId + "='{1}']" +
                "]";

            // --

            FXmlNodeList fXmlNodeListTtn = null;

            try
            {
                if (m_autoActionFirstSelectKeys.Contains(fTcpDevice.uniqueId))
                {
                    return;
                }
                m_autoActionFirstSelectKeys.Add(fTcpDevice.uniqueId);

                // --

                fXmlNodeListTtn = this.fTcpDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fTcpDevice.uniqueIdToString));
                foreach (FXmlNode fXmlNodeTtn in fXmlNodeListTtn)
                {
                    runTcpAutoTransmitter(fXmlNodeTtn);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListTtn = null;
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        public void runTcpAutoActionFirstCloseTransmitter(
            FTcpDevice fTcpDevice
            )
        {
            const string Query =
                FXmlTagEQM.E_EquipmentModeling + "/" +
                FXmlTagEQP.E_Equipment + "/" +
                FXmlTagSNG.E_ScenarioGroup + "/" +
                FXmlTagSNR.E_Scenario + "/" +
                FXmlTagTTN.E_TcpTransmitter +
                "[" +
                "@" + FXmlTagTTN.A_AutoActionFirstClose + "='{0}' and " +
                FXmlTagTTF.E_TcpTransfer + "[@" + FXmlTagTTF.A_TcpDeviceId + "='{1}']" +
                "]";

            // --

            FXmlNodeList fXmlNodeListTtn = null;

            try
            {
                if (m_autoActionFirstCloseKeys.Contains(fTcpDevice.uniqueId))
                {
                    return;
                }
                m_autoActionFirstCloseKeys.Add(fTcpDevice.uniqueId);

                // --

                fXmlNodeListTtn = this.fTcpDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fTcpDevice.uniqueIdToString));
                foreach (FXmlNode fXmlNodeTtn in fXmlNodeListTtn)
                {
                    runTcpAutoTransmitter(fXmlNodeTtn);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListTtn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void runTcpAutoActionAlwaysSelectTransmitter(
            FTcpDevice fTcpDevice
            )
        {
            const string Query =
                FXmlTagEQM.E_EquipmentModeling + "/" +
                FXmlTagEQP.E_Equipment + "/" +
                FXmlTagSNG.E_ScenarioGroup + "/" +
                FXmlTagSNR.E_Scenario + "/" +
                FXmlTagTTN.E_TcpTransmitter +
                "[" +
                "@" + FXmlTagTTN.A_AutoActionAlwaysSelect + "='{0}' and " +
                FXmlTagTTF.E_TcpTransfer + "[@" + FXmlTagTTF.A_TcpDeviceId + "='{1}']" +
                "]";

            // --

            FXmlNodeList fXmlNodeListTtn = null;

            try
            {
                fXmlNodeListTtn = this.fTcpDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fTcpDevice.uniqueIdToString));
                foreach (FXmlNode fXmlNodeTtn in fXmlNodeListTtn)
                {
                    runTcpAutoTransmitter(fXmlNodeTtn);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListTtn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void runTcpAutoActionAlwaysCloseTransmitter(
            FTcpDevice fTcpDevice
            )
        {
            const string Query =
                FXmlTagEQM.E_EquipmentModeling + "/" +
                FXmlTagEQP.E_Equipment + "/" +
                FXmlTagSNG.E_ScenarioGroup + "/" +
                FXmlTagSNR.E_Scenario + "/" +
                FXmlTagTTN.E_TcpTransmitter +
                "[" +
                "@" + FXmlTagTTN.A_AutoActionAlwaysClose + "='{0}' and " +
                FXmlTagTTF.E_TcpTransfer + "[@" + FXmlTagTTF.A_TcpDeviceId + "='{1}']" +
                "]";

            // --

            FXmlNodeList fXmlNodeListTtn = null;

            try
            {
                fXmlNodeListTtn = this.fTcpDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fTcpDevice.uniqueIdToString));
                foreach (FXmlNode fXmlNodeTtn in fXmlNodeListTtn)
                {
                    runTcpAutoTransmitter(fXmlNodeTtn);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListTtn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void runTcpAutoCycleTransmitter(
            FTcpDevice fTcpDevice
            )
        {
            FAutoCycleAgent fAutoCycleAgent = null;

            try
            {
                if (!m_autoCycleAgentList.ContainsKey(fTcpDevice.uniqueId))
                {
                    return;
                }

                // --

                fAutoCycleAgent = m_autoCycleAgentList[fTcpDevice.uniqueId];
                fAutoCycleAgent.collectTcpAutoCycleData(fTcpDevice);
                foreach (FAutoCycleData fData in fAutoCycleAgent.getTimeoutAutoCycleData())
                {
                    runTcpAutoTransmitter(fData.fXmlNode);
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

        public void clearTcpAutoCycleTransmitter(
            FTcpDevice fTcpDevice
            )
        {
            try
            {
                if (!m_autoCycleAgentList.ContainsKey(fTcpDevice.uniqueId))
                {
                    return;
                }
                m_autoCycleAgentList[fTcpDevice.uniqueId].clear();
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
                fScenarioData = new FScenarioData(this.fTcdCore);
                fScenarioData.setScenario(new FScenario(this.fTcdCore, fXmlNodeHtn.fParentNode));
                fScenarioData.setEquipment(new FEquipment(this.fTcdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));

                // --

                m_fTcdCore.fEventPusher.pushHostTransmitterRaisedEvent(
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

                fXmlNodeListHtn = this.fTcpDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fHostDevice.uniqueIdToString));
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

                fXmlNodeListHtn = this.fTcpDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fHostDevice.uniqueIdToString));
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
                fXmlNodeListHtn = this.fTcpDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fHostDevice.uniqueIdToString));
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
                fXmlNodeListHtn = this.fTcpDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fHostDevice.uniqueIdToString));
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
                fXmlNodeListHcn = this.fTcpDriver.fXmlNode.selectNodes(xpath);
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

        //------------------------------------------------------------------------------------------------------------------------

        public void clearTcpRetryCondition(
            FTcpDevice fTcpDevice
            )
        {
            const string TcpConditionQuery =
                FXmlTagEQM.E_EquipmentModeling +
                "/" + FXmlTagEQP.E_Equipment +
                "/" + FXmlTagSNG.E_ScenarioGroup +
                "/" + FXmlTagSNR.E_Scenario +
                "/" + FXmlTagTTR.E_TcpTrigger +
                "/" + FXmlTagTCN.E_TcpCondition +
                "[@" + FXmlTagTCN.A_ConditionMode + "='{0}' and" +
                " @" + FXmlTagTCN.A_TcpDeviceId + "='{1}' and" +
                " @" + FXmlTagTCN.A_RetryCount + "!='0']";

            // --

            FXmlNodeList fXmlNodeListTcn = null;
            string xpath = string.Empty;

            try
            {
                xpath = string.Format(
                    TcpConditionQuery,
                    FEnumConverter.fromConditionMode(FConditionMode.Timeout),
                    fTcpDevice.uniqueIdToString
                    );
                fXmlNodeListTcn = this.fTcpDriver.fXmlNode.selectNodes(xpath);
                // --
                foreach (FXmlNode fXmlNodeTcn in fXmlNodeListTcn)
                {
                    fXmlNodeTcn.set_attrVal(FXmlTagTCN.A_RetryCount, FXmlTagTCN.D_RetryCount, "0");
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListTcn = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
