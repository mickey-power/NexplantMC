/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FScenarioController.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.16
--  Description     : FAMate Core FaOpcDriver Scenario Controller Class 
--  History         : Created by Jeff.Kim at 2013.07.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    internal static class FScenarioController
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public static void controlScenario(
            FEventArgsBase fLastEventArgs
            )
        {
            FScenarioData fScenarioData = null;

            try
            {
                if (fLastEventArgs.fOpcEventId == FEventId.OpcTriggerRaised)
                {
                    fScenarioData = ((FOpcTriggerRaisedEventArgs)fLastEventArgs).fScenarioData;
                }
                else if (fLastEventArgs.fOpcEventId == FEventId.OpcTransmitterRaised)
                {
                    fScenarioData = ((FOpcTransmitterRaisedEventArgs)fLastEventArgs).fScenarioData;

                    // --

                    // ***
                    // Send Transfer
                    // ***
                    sendOpcMessageTransfer(fScenarioData);
                }
                else if (fLastEventArgs.fOpcEventId == FEventId.HostTriggerRaised)
                {
                    fScenarioData = ((FHostTriggerRaisedEventArgs)fLastEventArgs).fScenarioData;
                }
                else if (fLastEventArgs.fOpcEventId == FEventId.HostTransmitterRaised)
                {
                    fScenarioData = ((FHostTransmitterRaisedEventArgs)fLastEventArgs).fScenarioData;

                    // --

                    // ***
                    // Send Transfer
                    // ***
                    sendHostMessageTransfer(fScenarioData);
                }
                else if (fLastEventArgs.fOpcEventId == FEventId.EquipmentStateSetAltererPerformed)
                {
                    fScenarioData = ((FEquipmentStateSetAltererPerformedEventArgs)fLastEventArgs).fScenarioData;
                }
                else if (fLastEventArgs.fOpcEventId == FEventId.JudgementPerformed)
                {
                    fScenarioData = ((FJudgementPerformedEventArgs)fLastEventArgs).fScenarioData;
                }
                else if (fLastEventArgs.fOpcEventId == FEventId.MapperPerformed)
                {
                    fScenarioData = ((FMapperPerformedEventArgs)fLastEventArgs).fScenarioData;
                }
                else if (fLastEventArgs.fOpcEventId == FEventId.StoragePerformed)
                {
                    fScenarioData = ((FStoragePerformedEventArgs)fLastEventArgs).fScenarioData;
                }
                else if (fLastEventArgs.fOpcEventId == FEventId.CallbackRaised)
                {
                    fScenarioData = ((FCallbackRaisedEventArgs)fLastEventArgs).fScenarioData;

                    // --

                    // ***
                    // Function Called
                    // ***
                    if (fScenarioData.hasNextFunction)
                    {
                        executeFunction(fScenarioData);
                        return;
                    }
                }
                else if (fLastEventArgs.fOpcEventId == FEventId.FunctionCalled)
                {
                    // ***
                    // 2013.07.02 by spike.lee
                    // EAP로 호출한 Function이 오류를 반환하고 Error Action이 Stop일 경우, Next 시나리오를 처리하지 않는다
                    // ***
                    if (
                        !((FFunctionCalledEventArgs)fLastEventArgs).functionCalledResult &&
                        ((FFunctionCalledEventArgs)fLastEventArgs).fFunctionCalledLog.fErrorAction == FErrorAction.Stop
                        )
                    {
                        return;
                    }

                    // --

                    fScenarioData = ((FFunctionCalledEventArgs)fLastEventArgs).fScenarioData;

                    // --

                    // ***
                    // Function Called
                    // ***
                    if (fScenarioData.hasNextFunction)
                    {
                        executeFunction(fScenarioData);
                        return;
                    }
                }
                else if (fLastEventArgs.fOpcEventId == FEventId.BranchRaised)
                {
                    fScenarioData = ((FBranchRaisedEventArgs)fLastEventArgs).fScenarioData;
                }
                else if (fLastEventArgs.fOpcEventId == FEventId.CommentWritten)
                {
                    fScenarioData = ((FCommentWrittenEventArgs)fLastEventArgs).fScenarioData;
                }
                else if (fLastEventArgs.fOpcEventId == FEventId.EntryPointCalled)
                {
                    fScenarioData = ((FEntryPointCalledEventArgs)fLastEventArgs).fScenarioData;
                }
                else if (fLastEventArgs.fOpcEventId == FEventId.PauserRaised)
                {
                    // ***
                    // Pauser 의 경우 지정된 시간 이후 지정된 Flow가 실행되므로 여기서는 Return.
                    // ***
                    return;
                }
                
                // --

                if (!fScenarioData.hasNextFlow)
                {
                    return;
                }

                // --

                if (fScenarioData.fNextFlow.fFlowType == FFlowType.OpcTransmitter)
                {
                    executeOpcTransmitter(fScenarioData);
                }
                else if (fScenarioData.fNextFlow.fFlowType == FFlowType.HostTransmitter)
                {
                    executeHostTransmitter(fScenarioData);
                }
                else if (fScenarioData.fNextFlow.fFlowType == FFlowType.EquipmentStateSetAlterer)
                {
                    executeEquipmentStateSetAlterer(fScenarioData);
                }
                else if (fScenarioData.fNextFlow.fFlowType == FFlowType.Judgement)
                {
                    executeJudgement(fScenarioData);
                }
                else if (fScenarioData.fNextFlow.fFlowType == FFlowType.Mapper)
                {
                    executeMapper(fScenarioData);
                }
                else if (fScenarioData.fNextFlow.fFlowType == FFlowType.Storage)
                {
                    executeStorage(fScenarioData);
                }
                else if (fScenarioData.fNextFlow.fFlowType == FFlowType.Callback)
                {
                    executeCallback(fScenarioData);
                }
                else if (fScenarioData.fNextFlow.fFlowType == FFlowType.Branch)
                {
                    executeBranch(fScenarioData);
                }
                else if (fScenarioData.fNextFlow.fFlowType == FFlowType.Comment)
                {
                    executeComment(fScenarioData);
                }
                else if (fScenarioData.fNextFlow.fFlowType == FFlowType.Pauser)
                {
                    executePauser(fScenarioData);
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

        public static void executeOpcTransmitter(
            FScenarioData fScenarioData
            )
        {
            try
            {
                fScenarioData.fOcdCore.fEventPusher.pushOpcTransmitterRaisedEvent(
                    FResultCode.Success,
                    string.Empty,
                    ((FOpcTransmitter)fScenarioData.fNextFlow).fXmlNode,
                    fScenarioData,
                    true
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

        public static void executeEquipmentStateSetAlterer(
            FScenarioData fScenarioData
            )
        {
            try
            {
                fScenarioData.fOcdCore.fEventPusher.pushEquipmentStateSetAltererPerformedEvent(
                    FResultCode.Success,
                    string.Empty,
                    ((FEquipmentStateSetAlterer)fScenarioData.fNextFlow).fXmlNode,
                    fScenarioData
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

        public static void executeJudgement(
            FScenarioData fScenarioData
            )
        {
            try
            {
                fScenarioData.fOcdCore.fEventPusher.pushJudgementPerformedEvent(
                    FResultCode.Success,
                    string.Empty,
                    ((FJudgement)fScenarioData.fNextFlow).fXmlNode,
                    fScenarioData
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

        public static void executeHostTransmitter(
            FScenarioData fScenarioData
            )
        {
            try
            {
                fScenarioData.fOcdCore.fEventPusher.pushHostTransmitterRaisedEvent(
                    FResultCode.Success,
                    string.Empty,
                    ((FHostTransmitter)fScenarioData.fNextFlow).fXmlNode,
                    fScenarioData,
                    true
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

        public static void executeMapper(
            FScenarioData fScenarioData
            )
        {
            try
            {
                fScenarioData.fOcdCore.fEventPusher.pushMapperPerformedEvent(
                    FResultCode.Success,
                    string.Empty,
                    ((FMapper)fScenarioData.fNextFlow).fXmlNode,
                    fScenarioData
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

        public static void executeStorage(
            FScenarioData fScenarioData
            )
        {
            try
            {
                fScenarioData.fOcdCore.fEventPusher.pushStoragePerformedEvent(
                    FResultCode.Success,
                    string.Empty,
                    ((FStorage)fScenarioData.fNextFlow).fXmlNode,
                    fScenarioData
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

        public static void executeCallback(
            FScenarioData fScenarioData
            )
        {
            try
            {
                fScenarioData.fOcdCore.fEventPusher.pushCallbackRaisedEvent(
                    FResultCode.Success,
                    string.Empty,
                    ((FCallback)fScenarioData.fNextFlow).fXmlNode,
                    fScenarioData
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

        public static void executeFunction(
            FScenarioData fScenarioData
            )
        {
            try
            {
                fScenarioData.fOcdCore.fEventPusher.pushFunctionCalledEvent(
                    FResultCode.Success,
                    string.Empty,
                    ((FFunction)fScenarioData.fNextFunction).fXmlNode,
                    fScenarioData
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

        public static void executeBranch(
            FScenarioData fScenarioData
            )
        {
            try
            {
                fScenarioData.fOcdCore.fEventPusher.pushBranchRaisedEvent(
                    FResultCode.Success,
                    string.Empty,
                    ((FBranch)fScenarioData.fNextFlow).fXmlNode,
                    fScenarioData
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

        public static void executeComment(
            FScenarioData fScenarioData
            )
        {
            try
            {
                fScenarioData.fOcdCore.fEventPusher.pushCommentWrittenEvent(
                    FResultCode.Success,
                    string.Empty,
                    ((FComment)fScenarioData.fNextFlow).fXmlNode,
                    fScenarioData
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

        public static void executePauser(
            FScenarioData fScenarioData
            )
        {
            try
            {
                fScenarioData.fOcdCore.fEventPusher.pushPauserRaisedEvent(
                    FResultCode.Success,
                    string.Empty,
                    ((FPauser)fScenarioData.fNextFlow).fXmlNode,
                    fScenarioData
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

        public static void sendOpcMessageTransfer(
            FScenarioData fScenarioData
            )
        {
            FOpcMessageTransferAreaType fType = FOpcMessageTransferAreaType.Unknown;
            FOpcTransfer fOtf = null;
            FOpcMessageTransfer fOmt = null;

            try
            {
                if (fScenarioData.fTransferCollection == null)
                {
                    return;
                }

                // --

                for (int i = 0; i < fScenarioData.fTransferCollection.count; i++)
                {
                    fOtf = (FOpcTransfer)fScenarioData.fTransferCollection[i].fTransfer;
                    fOmt = (FOpcMessageTransfer)fScenarioData.fTransferCollection[i].fMessageTransfer;
                    fType = fOmt.fOpcMessageTransferAreaType;

                    // --

                    try
                    {
                        if (fType == FOpcMessageTransferAreaType.Write)
                        {
                            fOmt.write(fOtf.fSession);
                        }
                        else if (fType == FOpcMessageTransferAreaType.Read)
                        {
                            fOmt.read(fOtf.fSession);
                        }
                    }
                    catch (Exception inEx)
                    {
                        procOpcMessageTransferSendError(
                            fType,
                            fScenarioData.fOcdCore.fEventPusher,
                            fOtf.fSession.fParent,
                            fOtf.fSession,
                            fOmt,
                            inEx.Message
                            );
                    }   
                }

                // --

                // ***
                // Message Send 완료 후, Transfer Collection 초기화
                // ***
                fScenarioData.setTransferCollection(null);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fScenarioData != null)
                {
                    fScenarioData.transmitterCompleted = true;
                }
                // --
                fOtf = null;
                fOmt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static void procOpcMessageTransferSendError(
            FOpcMessageTransferAreaType fType,
            FEventPusher fEventPusher,
            FOpcDevice fOpcDevice,
            FOpcSession fOpcSession,
            FOpcMessageTransfer fOmt,
            string errorMessage
            )
        {
            FXmlNode fXmlNodeOmgl = null;
            FOpcDeviceDataMessageWrittenLog fWrittenLog = null;
            FOpcDeviceDataMessageReadLog fReadLog = null;

            try
            {
                fXmlNodeOmgl = fOmt.fXmlNode.clone(true);                
                FKepware2.setOpcMessageLogInfo(fXmlNodeOmgl, fOpcDevice, fOpcSession);

                // --

                if (fType == FOpcMessageTransferAreaType.Write)
                {
                    fWrittenLog = fEventPusher.createOpcDeviceDataMessageWrittenLog(fOpcSession.fXmlNode, fXmlNodeOmgl);
                    fEventPusher.pushOpcDeviceDataMessageWrittenEvent(fOpcDevice, FResultCode.Error, errorMessage, fWrittenLog);
                }
                else if (fType == FOpcMessageTransferAreaType.Read)
                {
                    fReadLog = fEventPusher.createOpcDeviceDataMessageReadLog(fOpcSession.fXmlNode, fXmlNodeOmgl);
                    fEventPusher.pushOpcDeviceDataMessageReadEvent(fOpcDevice, FResultCode.Error, errorMessage, fReadLog);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeOmgl = null;
                fWrittenLog = null;
                fReadLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void sendHostMessageTransfer(
            FScenarioData fScenarioData
            )
        {
            FHostTransfer fHtf = null;
            FHostMessageTransfer fHmt = null;
            UInt32 tid = 0;

            try
            {
                if (fScenarioData.fTransferCollection == null)
                {
                    return;
                }                

                // --

                for (int i = 0; i < fScenarioData.fTransferCollection.count; i++)
                {
                    fHtf = (FHostTransfer)fScenarioData.fTransferCollection[i].fTransfer;
                    fHmt = (FHostMessageTransfer)fScenarioData.fTransferCollection[i].fMessageTransfer;
                    fHmt.equipmentName = fScenarioData.fEquipment.name;

                    // --

                    // ***
                    // Reply Host Message 전송 시, Last Command Host Message Tid를 설정한다.
                    // ***
                    if (fHmt.fHostMessageType == FHostMessageType.Reply && !fHmt.hasTid)
                    {
                        if (fScenarioData.fOcdCore.fProtocolAgent.fHostTidStorage.getTid(fHtf.fDevice.uniqueId, fHtf.fSession.uniqueId, fHmt.uniqueId, ref tid))
                        {
                            fHmt.setTid(tid);
                        }
                    }
                    
                    // --

                    try
                    {
                        fHmt.send(fHtf.fSession);        
                    }
                    catch (Exception inEx)
                    {
                        procHostMessageTransferSendError(
                            fScenarioData.fOcdCore.fEventPusher,
                            fHtf.fSession.fParent,
                            fHtf.fSession,
                            fHmt,
                            inEx.Message
                            );
                    }                  
                }

                // --

                // ***
                // Message Send 완료 후, Transfer Collection 초기화
                // ***
                fScenarioData.setTransferCollection(null);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fScenarioData != null)
                {
                    fScenarioData.transmitterCompleted = true;
                }
                // --
                fHtf = null;
                fHmt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static void procHostMessageTransferSendError(
            FEventPusher fEventPusher,
            FHostDevice fHostDevice,
            FHostSession fHostSession,
            FHostMessageTransfer fHmt,
            string errorMessage
            )
        {
            FXmlNode fXmlNodeHmgl = null;
            FHostDeviceDataMessageSentLog fLog = null;

            try
            {
                fXmlNodeHmgl = fHmt.fXmlNode.clone(true);                
                FHost2.setHostMessageLogInfo(fXmlNodeHmgl, fHostDevice.fXmlNode, fHostSession.fXmlNode);

                // --

                fLog = fEventPusher.createHostDeviceDataMessageSentLog(fHostSession.fXmlNode, fXmlNodeHmgl);
                fEventPusher.pushHostDeviceDataMessageSentEvent(fHostDevice, FResultCode.Error, errorMessage, fLog); 
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
