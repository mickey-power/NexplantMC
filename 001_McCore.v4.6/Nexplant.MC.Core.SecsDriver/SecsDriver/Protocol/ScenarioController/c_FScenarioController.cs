/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FScenarioController.cs
--  Creator         : spike.lee
--  Create Date     : 2011.12.19
--  Description     : FAMate Core FaSecsDriver Scenario Controller Class 
--  History         : Created by spike.lee at 2011.12.19
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
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
                if (fLastEventArgs.fSecsEventId == FEventId.SecsTriggerRaised)
                {
                    fScenarioData = ((FSecsTriggerRaisedEventArgs)fLastEventArgs).fScenarioData;
                }
                else if (fLastEventArgs.fSecsEventId == FEventId.SecsTransmitterRaised)
                {
                    fScenarioData = ((FSecsTransmitterRaisedEventArgs)fLastEventArgs).fScenarioData;

                    // --

                    // ***
                    // Send Transfer
                    // ***
                    sendSecsMessageTransfer(fScenarioData);
                }
                else if (fLastEventArgs.fSecsEventId == FEventId.HostTriggerRaised)
                {
                    fScenarioData = ((FHostTriggerRaisedEventArgs)fLastEventArgs).fScenarioData;
                }
                else if (fLastEventArgs.fSecsEventId == FEventId.HostTransmitterRaised)
                {
                    fScenarioData = ((FHostTransmitterRaisedEventArgs)fLastEventArgs).fScenarioData;

                    // --

                    // ***
                    // Send Transfer
                    // ***
                    sendHostMessageTransfer(fScenarioData);
                }
                else if (fLastEventArgs.fSecsEventId == FEventId.EquipmentStateSetAltererPerformed)
                {
                    fScenarioData = ((FEquipmentStateSetAltererPerformedEventArgs)fLastEventArgs).fScenarioData;
                }               
                else if (fLastEventArgs.fSecsEventId == FEventId.JudgementPerformed)
                {
                    fScenarioData = ((FJudgementPerformedEventArgs)fLastEventArgs).fScenarioData;
                }
                else if (fLastEventArgs.fSecsEventId == FEventId.MapperPerformed)
                {
                    fScenarioData = ((FMapperPerformedEventArgs)fLastEventArgs).fScenarioData;
                }
                else if (fLastEventArgs.fSecsEventId == FEventId.StoragePerformed)
                {
                    fScenarioData = ((FStoragePerformedEventArgs)fLastEventArgs).fScenarioData;
                }
                else if (fLastEventArgs.fSecsEventId == FEventId.CallbackRaised)
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
                else if (fLastEventArgs.fSecsEventId == FEventId.FunctionCalled)
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
                else if (fLastEventArgs.fSecsEventId == FEventId.BranchRaised)
                {
                    fScenarioData = ((FBranchRaisedEventArgs)fLastEventArgs).fScenarioData;
                }
                else if (fLastEventArgs.fSecsEventId == FEventId.CommentWritten)
                {
                    fScenarioData = ((FCommentWrittenEventArgs)fLastEventArgs).fScenarioData;
                }
                else if (fLastEventArgs.fSecsEventId == FEventId.EntryPointCalled)
                {
                    fScenarioData = ((FEntryPointCalledEventArgs)fLastEventArgs).fScenarioData;
                }
                else if (fLastEventArgs.fSecsEventId == FEventId.PauserRaised)
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

                if (fScenarioData.fNextFlow.fFlowType == FFlowType.SecsTransmitter)
                {
                    executeSecsTransmitter(fScenarioData);
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

        public static void executeSecsTransmitter(
            FScenarioData fScenarioData
            )
        {
            try
            {
                fScenarioData.fScdCore.fEventPusher.pushSecsTransmitterRaisedEvent(
                    FResultCode.Success,
                    string.Empty,
                    ((FSecsTransmitter)fScenarioData.fNextFlow).fXmlNode,
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

        public static void executeHostTransmitter(
            FScenarioData fScenarioData
            )
        {
            try
            {
                fScenarioData.fScdCore.fEventPusher.pushHostTransmitterRaisedEvent(
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

        public static void executeEquipmentStateSetAlterer(
            FScenarioData fScenarioData
            )
        {
            try
            {
                fScenarioData.fScdCore.fEventPusher.pushEquipmentStateSetAltererPerformedEvent(
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
                fScenarioData.fScdCore.fEventPusher.pushJudgementPerformedEvent(
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

        public static void executeMapper(
            FScenarioData fScenarioData
            )
        {
            try
            {
                fScenarioData.fScdCore.fEventPusher.pushMapperPerformedEvent(
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
                fScenarioData.fScdCore.fEventPusher.pushStoragePerformedEvent(
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
                fScenarioData.fScdCore.fEventPusher.pushCallbackRaisedEvent(
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
                fScenarioData.fScdCore.fEventPusher.pushFunctionCalledEvent(
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
                fScenarioData.fScdCore.fEventPusher.pushBranchRaisedEvent(
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
                fScenarioData.fScdCore.fEventPusher.pushCommentWrittenEvent(
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
                fScenarioData.fScdCore.fEventPusher.pushPauserRaisedEvent(
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

        public static void sendSecsMessageTransfer(
            FScenarioData fScenarioData
            )
        {
            FSecsTransfer fStf = null;
            FSecsMessageTransfer fSmt = null;
            UInt32 systemBytes = 0;

            try
            {
                if (fScenarioData.fTransferCollection == null)
                {
                    return;
                }

                // --

                for (int i = 0; i < fScenarioData.fTransferCollection.count; i++)
                {
                    fStf = (FSecsTransfer)fScenarioData.fTransferCollection[i].fTransfer;
                    fSmt = (FSecsMessageTransfer)fScenarioData.fTransferCollection[i].fMessageTransfer;

                    // --

                    // ***
                    // Secondary SECS Message 전송 시, Last Primary SECS Message SystemBytes를 설정한다.
                    // ***
                    if (fSmt.isSecondary && !fSmt.hasSystemBytes)
                    {
                        if (fScenarioData.fScdCore.fProtocolAgent.fSecsSystemBytesStorage.getSystemBytes(fStf.fDevice.uniqueId, fStf.fSession.uniqueId, fSmt.uniqueId, ref systemBytes))
                        {
                            fSmt.setSystemBytes(systemBytes);
                        }
                    }
                    
                    // --

                    fSmt.send(fStf.fSession);                    
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
                fStf = null;
                fSmt = null;
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
                    // ***
                    // 2016.06.08 Jungyoul (WISOL)
                    // ***
                    fHmt.equipmentName = fScenarioData.fEquipment.name;

                    // --

                    // ***
                    // Reply Host Message 전송 시, Last Command Host Message Tid를 설정한다.
                    // ***
                    if (fHmt.fHostMessageType == FHostMessageType.Reply && !fHmt.hasTid)
                    {
                        if (fScenarioData.fScdCore.fProtocolAgent.fHostTidStorage.getTid(fHtf.fDevice.uniqueId, fHtf.fSession.uniqueId, fHmt.uniqueId, ref tid))
                        {
                            fHmt.setTid(tid);
                        }
                    }
                    
                    // --

                    fHmt.send(fHtf.fSession);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
