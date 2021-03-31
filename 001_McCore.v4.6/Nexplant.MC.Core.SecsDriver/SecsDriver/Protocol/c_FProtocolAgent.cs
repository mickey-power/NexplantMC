/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FProtocolAgent.cs
--  Creator         : spike.lee
--  Create Date     : 2011.09.01
--  Description     : FAMate Core FaSecsDriver Protocol Agent Class
--  History         : Created by spike.lee at 2011.08.22
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.IO;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal class FProtocolAgent : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FScdCore m_fScdCore = null;
        private Dictionary<UInt64, FBaseProtocol> m_protocolList = null;
        // --
        private FSystemByteStorage m_fSecsSystemBytesStorage = null;
        private FTidStorage m_fHostTidStorage = null;
        // --
        private HashSet<UInt64> m_autoActionFirstSelectKeys = null;
        private HashSet<UInt64> m_autoActionFirstCloseKeys = null;
        private Dictionary<UInt64, FAutoCycleAgent> m_autoCycleAgentList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FProtocolAgent(        
            FScdCore fScdCore
            )
        {
            m_fScdCore = fScdCore;
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
                    m_fScdCore = null;
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

        public FScdCore fScdCore
        {
            get
            {
                try
                {
                    return m_fScdCore;
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

        public FSecsDriver fSecsDriver
        {
            get
            {
                try
                {
                    return m_fScdCore.fSecsDriver;
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
        
        public FSystemByteStorage fSecsSystemBytesStorage
        {
            get
            {
                try
                {
                    return m_fSecsSystemBytesStorage;
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
                m_fSecsSystemBytesStorage = new FSystemByteStorage();
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
                if (m_fSecsSystemBytesStorage != null)
                {
                    m_fSecsSystemBytesStorage.Dispose();
                    m_fSecsSystemBytesStorage = null;
                }
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

        public void openSecsDevice(
            FSecsDevice fSecsDevice
            )
        {
            FBaseProtocol fProtocol = null;

            try
            {
                fSecsDevice.init();

                // -- 

                if (fSecsDevice.fProtocol == FProtocol.HSMS)
                {
                    fProtocol = new FHsmsProtocol(m_fScdCore, fSecsDevice);
                }
                else if (fSecsDevice.fProtocol == FProtocol.SECS1)
                {
                    fProtocol = new FSecs1Protocol(m_fScdCore, fSecsDevice);
                }
                else if (fSecsDevice.fProtocol == FProtocol.TCPIP)
                {
                    fProtocol = new FTcpIpProtocol(m_fScdCore, fSecsDevice);
                }
                else if (fSecsDevice.fProtocol == FProtocol.TELNET)
                {
                    fProtocol = new FTelnetProtocol(m_fScdCore, fSecsDevice);
                }
                fProtocol.open();
                
                // --

                m_protocolList.Add(fSecsDevice.uniqueId, fProtocol);
                m_autoCycleAgentList.Add(fSecsDevice.uniqueId, new FAutoCycleAgent(this.fSecsDriver));
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

        public void closeSecsDevice(
            FSecsDevice fSecsDevice
            )
        {
            FBaseProtocol fProtocol = null;

            try
            {
                fProtocol = m_protocolList[fSecsDevice.uniqueId];
                fProtocol.close();
                fProtocol.Dispose();
                fProtocol = null;

                // --

                m_protocolList.Remove(fSecsDevice.uniqueId);
                m_autoCycleAgentList.Remove(fSecsDevice.uniqueId);
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

        public void sendSecsMessageTransfer(
            FSecsSession fSecsSession, 
            FSecsMessageTransfer fSecsMessageTransfer
            )
        {
            FSecsDevice fSdv = null;

            try
            {
                fSdv = fSecsSession.fParent;
                if (fSdv == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "Device"));
                }

                if (!m_protocolList.ContainsKey(fSdv.uniqueId))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0029, "Device"));
                }

                // --

                FSecsDriverCommon.setSecsItemRandomValue(fSecsMessageTransfer.fXmlNode);
                
                // --

                m_protocolList[fSdv.uniqueId].send(fSecsSession, fSecsMessageTransfer);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSdv = null;
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
                if (!File.Exists(this.fSecsDriver.hostDriverDirectory + "//" + fHostDevice.driver))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "Host Driver"));
                }

                // --

                fHostDevice.init();
                fProtocol = new FHostProtocol(m_fScdCore, fHostDevice);
                fProtocol.open();

                // --
                
                m_protocolList.Add(fHostDevice.uniqueId, fProtocol);
                m_autoCycleAgentList.Add(fHostDevice.uniqueId, new FAutoCycleAgent(this.fSecsDriver));
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

                FSecsDriverCommon.setHostItemRandomValue(fHostMessageTransfer.fXmlNode);

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

        private void runSecsAutoTransmitter(
            FXmlNode fXmlNodeStn
            )
        {
            FScenarioData fScenarioData = null;

            try
            {
                // ***
                // 최초 Scenario Data 생성
                // ***
                fScenarioData = new FScenarioData(this.fScdCore);
                fScenarioData.setScenario(new FScenario(this.fScdCore, fXmlNodeStn.fParentNode));
                fScenarioData.setEquipment(new FEquipment(this.fScdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));

                // --

                m_fScdCore.fEventPusher.pushSecsTransmitterRaisedEvent(
                    FResultCode.Success, 
                    string.Empty, 
                    fXmlNodeStn, 
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

        public void runSecsAutoActionFirstSelectTransmitter(
            FSecsDevice fSecsDevice
            )
        {
            const string Query =
                FXmlTagEQM.E_EquipmentModeling + "/" +
                FXmlTagEQP.E_Equipment + "/" +
                FXmlTagSNG.E_ScenarioGroup + "/" +
                FXmlTagSNR.E_Scenario + "/" +
                FXmlTagSTN.E_SecsTransmitter +
                "[" +
                "@" + FXmlTagSTN.A_AutoActionFirstSelect + "='{0}' and " +
                FXmlTagSTF.E_SecsTransfer + "[@" + FXmlTagSTF.A_SecsDeviceId + "='{1}']" +
                "]";

            // --

            FXmlNodeList fXmlNodeListStn = null;

            try
            {
                if (m_autoActionFirstSelectKeys.Contains(fSecsDevice.uniqueId))
                {
                    return;
                }
                m_autoActionFirstSelectKeys.Add(fSecsDevice.uniqueId);

                // --

                fXmlNodeListStn = this.fSecsDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fSecsDevice.uniqueIdToString));
                foreach (FXmlNode fXmlNodeStn in fXmlNodeListStn)
                {
                    runSecsAutoTransmitter(fXmlNodeStn);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListStn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void runSecsAutoActionFirstCloseTransmitter(
            FSecsDevice fSecsDevice
            )
        {
            const string Query =
                FXmlTagEQM.E_EquipmentModeling + "/" +
                FXmlTagEQP.E_Equipment + "/" +
                FXmlTagSNG.E_ScenarioGroup + "/" +
                FXmlTagSNR.E_Scenario + "/" +
                FXmlTagSTN.E_SecsTransmitter +
                "[" +
                "@" + FXmlTagSTN.A_AutoActionFirstClose + "='{0}' and " +
                FXmlTagSTF.E_SecsTransfer + "[@" + FXmlTagSTF.A_SecsDeviceId + "='{1}']" +
                "]";

            // --

            FXmlNodeList fXmlNodeListStn = null;

            try
            {
                if (m_autoActionFirstCloseKeys.Contains(fSecsDevice.uniqueId))
                {
                    return;
                }
                m_autoActionFirstCloseKeys.Add(fSecsDevice.uniqueId);

                // --

                fXmlNodeListStn = this.fSecsDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fSecsDevice.uniqueIdToString));
                foreach (FXmlNode fXmlNodeStn in fXmlNodeListStn)
                {
                    runSecsAutoTransmitter(fXmlNodeStn);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListStn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void runSecsAutoActionAlwaysSelectTransmitter(
            FSecsDevice fSecsDevice
            )
        {
            const string Query =
                FXmlTagEQM.E_EquipmentModeling + "/" +
                FXmlTagEQP.E_Equipment + "/" +
                FXmlTagSNG.E_ScenarioGroup + "/" +
                FXmlTagSNR.E_Scenario + "/" +
                FXmlTagSTN.E_SecsTransmitter +
                "[" +
                "@" + FXmlTagSTN.A_AutoActionAlwaysSelect + "='{0}' and " +
                FXmlTagSTF.E_SecsTransfer + "[@" + FXmlTagSTF.A_SecsDeviceId + "='{1}']" +
                "]";

            // --

            FXmlNodeList fXmlNodeListStn = null;

            try
            {
                fXmlNodeListStn = this.fSecsDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fSecsDevice.uniqueIdToString));                
                foreach (FXmlNode fXmlNodeStn in fXmlNodeListStn)
                {
                    runSecsAutoTransmitter(fXmlNodeStn);
                }               
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListStn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void runSecsAutoActionAlwaysCloseTransmitter(
            FSecsDevice fSecsDevice
            )
        {
            const string Query =
                FXmlTagEQM.E_EquipmentModeling + "/" +
                FXmlTagEQP.E_Equipment + "/" +
                FXmlTagSNG.E_ScenarioGroup + "/" +
                FXmlTagSNR.E_Scenario + "/" +
                FXmlTagSTN.E_SecsTransmitter +
                "[" +
                "@" + FXmlTagSTN.A_AutoActionAlwaysClose + "='{0}' and " +
                FXmlTagSTF.E_SecsTransfer + "[@" + FXmlTagSTF.A_SecsDeviceId + "='{1}']" +
                "]";

            // --

            FXmlNodeList fXmlNodeListStn = null;

            try
            {
                fXmlNodeListStn = this.fSecsDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fSecsDevice.uniqueIdToString));
                foreach (FXmlNode fXmlNodeStn in fXmlNodeListStn)
                {
                    runSecsAutoTransmitter(fXmlNodeStn);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListStn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void runSecsAutoCycleTransmitter(
            FSecsDevice fSecsDevice
            )
        {
            FAutoCycleAgent fAutoCycleAgent = null;

            try
            {
                if (!m_autoCycleAgentList.ContainsKey(fSecsDevice.uniqueId))
                {
                    return;
                }

                // --

                fAutoCycleAgent = m_autoCycleAgentList[fSecsDevice.uniqueId];                
                fAutoCycleAgent.collectSecsAutoCycleData(fSecsDevice);
                foreach (FAutoCycleData fData in fAutoCycleAgent.getTimeoutAutoCycleData())
                {
                    runSecsAutoTransmitter(fData.fXmlNode);
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

        public void clearSecsAutoCycleTransmitter(
            FSecsDevice fSecsDevice 
            )
        {
            try
            {
                if (!m_autoCycleAgentList.ContainsKey(fSecsDevice.uniqueId))
                {
                    return;
                }
                m_autoCycleAgentList[fSecsDevice.uniqueId].clear();
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

        public void clearSecsRetryCondition(
            FSecsDevice fSecsDevice
            )
        {
            const string SecsConditionQuery =
                FXmlTagEQM.E_EquipmentModeling +
                "/" + FXmlTagEQP.E_Equipment +
                "/" + FXmlTagSNG.E_ScenarioGroup +
                "/" + FXmlTagSNR.E_Scenario +
                "/" + FXmlTagSTR.E_SecsTrigger +
                "/" + FXmlTagSCN.E_SecsCondition +
                "[@" + FXmlTagSCN.A_ConditionMode + "='{0}' and" +
                " @" + FXmlTagSCN.A_SecsDeviceId  + "='{1}' and" +
                " @" + FXmlTagSCN.A_RetryCount    + "!='0']";

            // --

            FXmlNodeList fXmlNodeListScn = null;
            string xpath = string.Empty;  

            try
            {
                xpath = string.Format(
                    SecsConditionQuery, 
                    FEnumConverter.fromConditionMode(FConditionMode.Timeout),
                    fSecsDevice.uniqueIdToString
                    );
                fXmlNodeListScn = this.fSecsDriver.fXmlNode.selectNodes(xpath);
                // --
                foreach (FXmlNode fXmlNodeScn in fXmlNodeListScn)
                {
                    fXmlNodeScn.set_attrVal(FXmlTagSCN.A_RetryCount, FXmlTagSCN.D_RetryCount, "0");
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListScn = null;
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
                fScenarioData = new FScenarioData(this.fScdCore);
                fScenarioData.setScenario(new FScenario(this.fScdCore, fXmlNodeHtn.fParentNode));
                fScenarioData.setEquipment(new FEquipment(this.fScdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));

                // --

                m_fScdCore.fEventPusher.pushHostTransmitterRaisedEvent(
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

                fXmlNodeListHtn = this.fSecsDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fHostDevice.uniqueIdToString));
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

                fXmlNodeListHtn = this.fSecsDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fHostDevice.uniqueIdToString));
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
                fXmlNodeListHtn = this.fSecsDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fHostDevice.uniqueIdToString));
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
                fXmlNodeListHtn = this.fSecsDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fHostDevice.uniqueIdToString));
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
                fXmlNodeListHcn = this.fSecsDriver.fXmlNode.selectNodes(xpath);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
