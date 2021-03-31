/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FCommon.cs
--  Creator         : spike.lee
--  Create Date     : 2011.02.09
--  Description     : FAMate SECS Modeler Common Function Class 
--  History         : Created by spike.lee at 2011.02.09
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using System.IO;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinTree;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.SecsModeler
{
    public static class FCommon
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private static Image getImageOfEnvironment(
            FEnvironment fEnv,
            FTreeView tvwTree
            )
        {
            try
            {
                if (fEnv.fFormat == FFormat.List)
                {
                    if (fEnv.locked)
                    {
                        return tvwTree.ImageList.Images["Environment_List_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["Environment_List_unlock"];
                    }
                }
                else
                {
                    if (fEnv.locked)
                    {
                        return tvwTree.ImageList.Images["Environment_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["Environment_unlock"];
                    }
                }
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

        private static Image getImageOfData(
            FData fDat,
            FTreeView tvwTree
            )
        {
            try
            {
                if (fDat.fFormat == FFormat.List)
                {
                    if (fDat.locked)
                    {
                        return tvwTree.ImageList.Images["Data_List_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["Data_List_unlock"];
                    }
                }
                else
                {
                    if (fDat.locked)
                    {
                        return tvwTree.ImageList.Images["Data_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["Data_unlock"];
                    }
                }
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

        private static Image getImageOfSecsDevice(
            FSecsDevice fSdv,
            FTreeView tvwTree
            )
        {
            try
            {
                if (fSdv.fState == FDeviceState.Opened)
                {
                    if (fSdv.locked)
                    {
                        return tvwTree.ImageList.Images["SecsDevice_Opened_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["SecsDevice_Opened_unlock"];
                    }
                }
                else if (fSdv.fState == FDeviceState.Connected)
                {
                    if (fSdv.locked)
                    {
                        return tvwTree.ImageList.Images["SecsDevice_Connected_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["SecsDevice_Connected_unlock"];
                    }
                }
                else if (fSdv.fState == FDeviceState.Selected)
                {
                    if (fSdv.locked)
                    {
                        return tvwTree.ImageList.Images["SecsDevice_Selected_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["SecsDevice_Selected_unlock"];
                    }
                }
                else if (fSdv.fState == FDeviceState.Closed)
                {
                    if (fSdv.locked)
                    {
                        return tvwTree.ImageList.Images["SecsDevice_Closed_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["SecsDevice_Closed_unlock"];
                    }
                }
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

        private static Image getImageOfSecsMessages(
            FSecsMessages fSms,
            FTreeView tvwTree
            )
        {
            try
            {
                if (fSms.fDirection == FDirection.Equipment)
                {
                    if (fSms.locked)
                    {
                        return tvwTree.ImageList.Images["SecsMessages_Eq_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["SecsMessages_Eq_unlock"];
                    }
                }
                else if (fSms.fDirection == FDirection.Host)
                {
                    if (fSms.locked)
                    {
                        return tvwTree.ImageList.Images["SecsMessages_Host_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["SecsMessages_Host_unlock"];
                    }
                }
                else
                {
                    if (fSms.locked)
                    {
                        return tvwTree.ImageList.Images["SecsMessages_Both_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["SecsMessages_Both_unlock"];
                    }
                }
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

        private static Image getImageOfSecsMessage(
            FSecsMessage fSmg,
            FTreeView tvwTree
            )
        {
            try
            {
                if (fSmg.isPrimary)
                {
                    if (fSmg.locked)
                    {
                        return tvwTree.ImageList.Images["SecsMessage_Primary_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["SecsMessage_Primary_unlock"];
                    }
                }
                else if (fSmg.isSecondary)
                {
                    if (fSmg.locked)
                    {
                        return tvwTree.ImageList.Images["SecsMessage_Secondary_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["SecsMessage_Secondary_unlock"];
                    }
                }
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

        private static Image getImageOfSecsItem(
            FSecsItem fSit,
            FTreeView tvwTree
            )
        {
            try
            {
                if (fSit.fFormat == FFormat.List)
                {
                    if (fSit.locked)
                    {
                        return tvwTree.ImageList.Images["SecsItem_List_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["SecsItem_List_unlock"];
                    }
                }
                else
                {
                    if (fSit.locked)
                    {
                        return tvwTree.ImageList.Images["SecsItem_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["SecsItem_unlock"];
                    }
                }
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

        private static Image getImageOfHostDevice(
            FHostDevice fHdv,
            FTreeView tvwTree
            )
        {
            try
            {
                if (fHdv.fState == FDeviceState.Opened)
                {
                    if (fHdv.locked)
                    {
                        return tvwTree.ImageList.Images["HostDevice_Opened_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["HostDevice_Opened_unlock"];
                    }
                }
                else if (fHdv.fState == FDeviceState.Connected)
                {
                    if (fHdv.locked)
                    {
                        return tvwTree.ImageList.Images["HostDevice_Connected_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["HostDevice_Connected_unlock"];
                    }
                }
                else if (fHdv.fState == FDeviceState.Selected)
                {
                    if (fHdv.locked)
                    {
                        return tvwTree.ImageList.Images["HostDevice_Selected_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["HostDevice_Selected_unlock"];
                    }
                }
                else if (fHdv.fState == FDeviceState.Closed)
                {
                    if (fHdv.locked)
                    {
                        return tvwTree.ImageList.Images["HostDevice_Closed_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["HostDevice_Closed_unlock"];
                    }
                }
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

        private static Image getImageOfHostMessages(
            FHostMessages fHms,
            FTreeView tvwTree
            )
        {
            try
            {
                if (fHms.fDirection == FDirection.Host)
                {
                    if (fHms.locked)
                    {
                        return tvwTree.ImageList.Images["HostMessages_Host_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["HostMessages_Host_unlock"];
                    }
                }
                else if (fHms.fDirection == FDirection.Equipment)
                {
                    if (fHms.locked)
                    {
                        return tvwTree.ImageList.Images["HostMessages_Eq_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["HostMessages_Eq_unlock"];
                    }
                }
                else
                {
                    if (fHms.locked)
                    {
                        return tvwTree.ImageList.Images["HostMessages_Both_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["HostMessages_Both_unlock"];
                    }
                }
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

        private static Image getImageOfHostMessage(
            FHostMessage fHmg,
            FTreeView tvwTree
            )
        {
            try
            {
                if (fHmg.fHostMessageType == FHostMessageType.Command)
                {
                    if (fHmg.locked)
                    {
                        return tvwTree.ImageList.Images["HostMessage_Command_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["HostMessage_Command_unlock"];
                    }
                }
                else if (fHmg.fHostMessageType == FHostMessageType.Unsolicited)
                {
                    if (fHmg.locked)
                    {
                        return tvwTree.ImageList.Images["HostMessage_Unsolicited_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["HostMessage_Unsolicited_unlock"];
                    }
                }
                else if (fHmg.fHostMessageType == FHostMessageType.Reply)
                {
                    if (fHmg.locked)
                    {
                        return tvwTree.ImageList.Images["HostMessage_Reply_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["HostMessage_Reply_unlock"];
                    }
                }
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

        private static Image getImageOfHostItem(
            FHostItem fHit,
            FTreeView tvwTree
            )
        {
            try
            {
                if (fHit.fFormat == FFormat.List)
                {
                    if (fHit.locked)
                    {
                        return tvwTree.ImageList.Images["HostItem_List_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["HostItem_List_unlock"];
                    }
                }
                else
                {
                    if (fHit.locked)
                    {
                        return tvwTree.ImageList.Images["HostItem_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["HostItem_unlock"];
                    }
                }
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

        private static Image getImageOfSecsExpression(
            FSecsExpression fSep,
            FTreeView tvwTree
            )
        {
            try
            {
                if (fSep.fExpressionType == FExpressionType.Bracket)
                {
                    return tvwTree.ImageList.Images["SecsExpression_Bracket"];
                }
                else if (fSep.fExpressionType == FExpressionType.Comparison)
                {
                    if (fSep.fComparisonMode == FComparisonMode.Value)
                    {
                        if (fSep.fOperandType == FSecsOperandType.EquipmentState)
                        {
                            return tvwTree.ImageList.Images["SecsExpression_Comparison_Value_EquipmentState"];
                        }
                        else if (fSep.fOperandType == FSecsOperandType.Environment)
                        {
                            return tvwTree.ImageList.Images["SecsExpression_Comparison_Value_Environment"];
                        }
                        else if (fSep.fOperandType == FSecsOperandType.SecsItem)
                        {
                            return tvwTree.ImageList.Images["SecsExpression_Comparison_Value_SecsItem"];
                        }
                    }
                    else if (fSep.fComparisonMode == FComparisonMode.Length)
                    {
                        if (fSep.fOperandType == FSecsOperandType.Environment)
                        {
                            return tvwTree.ImageList.Images["SecsExpression_Comparison_Length_Environment"];
                        }
                        else if (fSep.fOperandType == FSecsOperandType.SecsItem)
                        {
                            return tvwTree.ImageList.Images["SecsExpression_Comparison_Length_SecsItem"];
                        }
                    }
                }
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

        private static Image getImageOfHostExpression(
            FHostExpression fHep,
            FTreeView tvwTree
            )
        {
            try
            {
                if (fHep.fExpressionType == FExpressionType.Bracket)
                {
                    return tvwTree.ImageList.Images["HostExpression_Bracket"];
                }
                else if (fHep.fExpressionType == FExpressionType.Comparison)
                {
                    if (fHep.fComparisonMode == FComparisonMode.Value)
                    {
                        if (fHep.fOperandType == FHostOperandType.EquipmentState)
                        {
                            return tvwTree.ImageList.Images["HostExpression_Comparison_Value_EquipmentState"];
                        }
                        else if (fHep.fOperandType == FHostOperandType.Environment)
                        {
                            return tvwTree.ImageList.Images["HostExpression_Comparison_Value_Environment"];
                        }
                        else if (fHep.fOperandType == FHostOperandType.HostItem)
                        {
                            return tvwTree.ImageList.Images["HostExpression_Comparison_Value_HostItem"];
                        }
                    }
                    else if (fHep.fComparisonMode == FComparisonMode.Length)
                    {
                        if (fHep.fOperandType == FHostOperandType.Environment)
                        {
                            return tvwTree.ImageList.Images["HostExpression_Comparison_Length_Environment"];
                        }
                        else if (fHep.fOperandType == FHostOperandType.HostItem)
                        {
                            return tvwTree.ImageList.Images["HostExpression_Comparison_Length_HostItem"];
                        }
                    }
                }
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

        private static Image getImageOfSecsCondition(
            FSecsCondition fScn,
            FTreeView tvwTree
            )
        {
            try
            {
                if (fScn.fConditionMode == FConditionMode.Expression)
                {
                    return tvwTree.ImageList.Images["SecsCondition_Expression"];
                }
                else if (fScn.fConditionMode == FConditionMode.Timeout)
                {
                    return tvwTree.ImageList.Images["SecsCondition_Timeout"];
                }
                else if (fScn.fConditionMode == FConditionMode.Connection)
                {
                    if (fScn.fConnectionState == FDeviceState.Closed)
                    {
                        return tvwTree.ImageList.Images["SecsCondition_Connection_Closed"];
                    }
                    else if (fScn.fConnectionState == FDeviceState.Opened)
                    {
                        return tvwTree.ImageList.Images["SecsCondition_Connection_Opened"];
                    }
                    else if (fScn.fConnectionState == FDeviceState.Connected)
                    {
                        return tvwTree.ImageList.Images["SecsCondition_Connection_Connected"];
                    }
                    else if (fScn.fConnectionState == FDeviceState.Selected)
                    {
                        return tvwTree.ImageList.Images["SecsCondition_Connection_Selected"];
                    }
                }
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

        private static Image getImageOfHostCondition(
            FHostCondition fHcn,
            FTreeView tvwTree
            )
        {
            try
            {
                if (fHcn.fConditionMode == FConditionMode.Expression)
                {
                    return tvwTree.ImageList.Images["HostCondition_Expression"];
                }
                else if (fHcn.fConditionMode == FConditionMode.Timeout)
                {
                    return tvwTree.ImageList.Images["HostCondition_Timeout"];
                }
                else if (fHcn.fConditionMode == FConditionMode.Connection)
                {
                    if (fHcn.fConnectionState == FDeviceState.Closed)
                    {
                        return tvwTree.ImageList.Images["HostCondition_Connection_Closed"];
                    }
                    else if (fHcn.fConnectionState == FDeviceState.Opened)
                    {
                        return tvwTree.ImageList.Images["HostCondition_Connection_Opened"];
                    }
                    else if (fHcn.fConnectionState == FDeviceState.Connected)
                    {
                        return tvwTree.ImageList.Images["HostCondition_Connection_Connected"];
                    }
                    else if (fHcn.fConnectionState == FDeviceState.Selected)
                    {
                        return tvwTree.ImageList.Images["HostCondition_Connection_Selected"];
                    }
                }
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

        private static Image getImageOfJudgementExpression(
            FJudgementExpression fJep,
            FTreeView tvwTree
            )
        {
            try
            {
                if (fJep.fExpressionType == FExpressionType.Bracket)
                {
                    return tvwTree.ImageList.Images["JudgementExpression_Bracket"];
                }
                else if (fJep.fExpressionType == FExpressionType.Comparison)
                {
                    if (fJep.fComparisonMode == FComparisonMode.Value)
                    {
                        return tvwTree.ImageList.Images["JudgementExpression_Comparison_Value"];
                    }
                    else if (fJep.fComparisonMode == FComparisonMode.Length)
                    {
                        return tvwTree.ImageList.Images["JudgementExpression_Comparison_Length"];
                    }
                }
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

        private static FResultCode getResultCode(
            FIObjectLog fObjectLog
            )
        {
            FResultCode fResultCode = FResultCode.Success;

            try
            {
                // ***
                // SecsDevice
                // ***
                if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceStateChangedLog)
                {
                    fResultCode = ((FSecsDeviceStateChangedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceControlMessageReceivedLog)
                {
                    fResultCode = ((FSecsDeviceControlMessageReceivedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceControlMessageSentLog)
                {
                    fResultCode = ((FSecsDeviceControlMessageSentLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTelnetPacketReceivedLog)
                {
                    fResultCode = ((FSecsDeviceTelnetPacketReceivedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTelnetPacketSentLog)
                {
                    fResultCode = ((FSecsDeviceTelnetPacketSentLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTelnetStateChangedLog)
                {
                    fResultCode = ((FSecsDeviceTelnetStateChangedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceHandshakeReceivedLog)
                {
                    fResultCode = ((FSecsDeviceHandshakeReceivedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceHandshakeSentLog)
                {
                    fResultCode = ((FSecsDeviceHandshakeSentLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceBlockReceivedLog)
                {
                    fResultCode = ((FSecsDeviceBlockReceivedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceBlockSentLog)
                {
                    fResultCode = ((FSecsDeviceBlockSentLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog)
                {
                    fResultCode = ((FSecsDeviceDataMessageReceivedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog)
                {
                    fResultCode = ((FSecsDeviceDataMessageSentLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataReceivedLog)
                {
                    fResultCode = ((FSecsDeviceDataReceivedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataSentLog)
                {
                    fResultCode = ((FSecsDeviceDataSentLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceSmlReceivedLog)
                {
                    fResultCode = ((FSecsDeviceSmlReceivedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceSmlSentLog)
                {
                    fResultCode = ((FSecsDeviceSmlSentLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceErrorRaisedLog)
                {
                    fResultCode = ((FSecsDeviceErrorRaisedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTimeoutRaisedLog)
                {
                    fResultCode = ((FSecsDeviceTimeoutRaisedLog)fObjectLog).fResultCode;
                }
                // ***
                // HostDevice
                // ***
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceStateChangedLog)
                {
                    fResultCode = ((FHostDeviceStateChangedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                {
                    fResultCode = ((FHostDeviceDataMessageReceivedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                {
                    fResultCode = ((FHostDeviceDataMessageSentLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceVfeiReceivedLog)
                {
                    fResultCode = ((FHostDeviceVfeiReceivedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceVfeiSentLog)
                {
                    fResultCode = ((FHostDeviceVfeiSentLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceErrorRaisedLog)
                {
                    fResultCode = ((FHostDeviceErrorRaisedLog)fObjectLog).fResultCode;
                }
                // ***
                // Scenario
                // ***
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsTriggerRaisedLog)
                {
                    fResultCode = ((FSecsTriggerRaisedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsTransmitterRaisedLog)
                {
                    fResultCode = ((FSecsTransmitterRaisedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTriggerRaisedLog)
                {
                    fResultCode = ((FHostTriggerRaisedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTransmitterRaisedLog)
                {
                    fResultCode = ((FHostTransmitterRaisedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.JudgementPerformedLog)
                {
                    fResultCode = ((FJudgementPerformedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.MapperPerformedLog)
                {
                    fResultCode = ((FMapperPerformedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EquipmentStateSetAltererPerformedLog)
                {
                    fResultCode = ((FEquipmentStateSetAltererPerformedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.StoragePerformedLog)
                {
                    fResultCode = ((FStoragePerformedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CallbackRaisedLog)
                {
                    fResultCode = ((FCallbackRaisedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.BranchRaisedLog)
                {
                    fResultCode = ((FBranchRaisedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.FunctionCalledLog)
                {
                    fResultCode = ((FFunctionCalledLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CommentWrittenLog)
                {
                    fResultCode = ((FCommentWrittenLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PauserRaisedLog)
                {
                    fResultCode = ((FPauserRaisedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EntryPointCalledLog)
                {
                    fResultCode = ((FEntryPointCalledLog)fObjectLog).fResultCode;
                }
                // ***
                // Application
                // ***
                else if (fObjectLog.fObjectLogType == FObjectLogType.ApplicationWrittenLog)
                {
                    fResultCode = ((FApplicationWrittenLog)fObjectLog).fResultCode;
                }

                // --

                return fResultCode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FResultCode.Success;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static Image getImageOfObject(
            FIObject fObject,
            FTreeView tvwTree
            )
        {
            try
            {
                // ***
                // SecsDriver
                // ***
                if (fObject.fObjectType == FObjectType.SecsDriver)
                {
                    return tvwTree.ImageList.Images["SecsDriver"];
                }
                // ***
                // SecsSetup
                // ***
                else if (fObject.fObjectType == FObjectType.ObjectNameList)
                {
                    return tvwTree.ImageList.Images["ObjectNameList"];
                }
                else if (fObject.fObjectType == FObjectType.ObjectName)
                {
                    return tvwTree.ImageList.Images["ObjectName"];
                }
                else if (fObject.fObjectType == FObjectType.FunctionNameList)
                {
                    return tvwTree.ImageList.Images["FunctionNameList"];
                }
                else if (fObject.fObjectType == FObjectType.FunctionName)
                {
                    return tvwTree.ImageList.Images["FunctionName"];
                }
                else if (fObject.fObjectType == FObjectType.ParameterName)
                {
                    return tvwTree.ImageList.Images["ParameterName"];
                }
                else if (fObject.fObjectType == FObjectType.Argument)
                {
                    return tvwTree.ImageList.Images["Argument"];
                }
                else if (fObject.fObjectType == FObjectType.DataConversionSetList)
                {
                    return ((FDataConversionSetList)fObject).locked ? tvwTree.ImageList.Images["DataConversionSetList_lock"] : tvwTree.ImageList.Images["DataConversionSetList_unlock"];
                }
                else if (fObject.fObjectType == FObjectType.DataConversionSet)
                {
                    return ((FDataConversionSet)fObject).locked ? tvwTree.ImageList.Images["DataConversionSet_lock"] : tvwTree.ImageList.Images["DataConversionSet_unlock"];
                }
                else if (fObject.fObjectType == FObjectType.DataConversion)
                {
                    return tvwTree.ImageList.Images["DataConversion"];
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateSetList)
                {
                    return ((FEquipmentStateSetList)fObject).locked ? tvwTree.ImageList.Images["EquipmentStateSetList_lock"] : tvwTree.ImageList.Images["EquipmentStateSetList_unlock"];
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateSet)
                {
                    return ((FEquipmentStateSet)fObject).locked ? tvwTree.ImageList.Images["EquipmentStateSet_lock"] : tvwTree.ImageList.Images["EquipmentStateSet_unlock"];
                }
                else if (fObject.fObjectType == FObjectType.EquipmentState)
                {
                    return ((FEquipmentState)fObject).locked ? tvwTree.ImageList.Images["EquipmentState_lock"] : tvwTree.ImageList.Images["EquipmentState_unlock"];
                }
                else if (fObject.fObjectType == FObjectType.StateValue)
                {
                    return tvwTree.ImageList.Images["StateValue"];
                }
                else if (fObject.fObjectType == FObjectType.RepositoryList)
                {
                    return ((FRepositoryList)fObject).locked ? tvwTree.ImageList.Images["RepositoryList_lock"] : tvwTree.ImageList.Images["RepositoryList_unlock"];
                }
                else if (fObject.fObjectType == FObjectType.Repository)
                {
                    return ((FRepository)fObject).locked ? tvwTree.ImageList.Images["Repository_lock"] : tvwTree.ImageList.Images["Repository_unlock"];
                }
                else if (fObject.fObjectType == FObjectType.Column)
                {
                    return ((FColumn)fObject).fFormat == FFormat.List ? tvwTree.ImageList.Images["Column_List"] : tvwTree.ImageList.Images["Column"];
                }
                else if (fObject.fObjectType == FObjectType.EnvironmentList)
                {
                    return ((FEnvironmentList)fObject).locked ? tvwTree.ImageList.Images["EnvironmentList_lock"] : tvwTree.ImageList.Images["EnvironmentList_unlock"];
                }
                else if (fObject.fObjectType == FObjectType.Environment)
                {
                    return getImageOfEnvironment((FEnvironment)fObject, tvwTree);
                }
                else if (fObject.fObjectType == FObjectType.DataSetList)
                {
                    return ((FDataSetList)fObject).locked ? tvwTree.ImageList.Images["DataSetList_lock"] : tvwTree.ImageList.Images["DataSetList_unlock"];
                }
                else if (fObject.fObjectType == FObjectType.DataSet)
                {
                    return ((FDataSet)fObject).locked ? tvwTree.ImageList.Images["DataSet_lock"] : tvwTree.ImageList.Images["DataSet_unlock"];
                }
                else if (fObject.fObjectType == FObjectType.Data)
                {
                    return getImageOfData((FData)fObject, tvwTree);
                }
                // ***
                // SecsModeling
                // ***
                else if (fObject.fObjectType == FObjectType.SecsLibraryGroup)
                {
                    return ((FSecsLibraryGroup)fObject).locked ? tvwTree.ImageList.Images["SecsLibraryGroup_lock"] : tvwTree.ImageList.Images["SecsLibraryGroup_unlock"];
                }
                else if (fObject.fObjectType == FObjectType.SecsLibrary)
                {
                    return ((FSecsLibrary)fObject).locked ? tvwTree.ImageList.Images["SecsLibrary_lock"] : tvwTree.ImageList.Images["SecsLibrary_unlock"];
                }
                else if (fObject.fObjectType == FObjectType.SecsDevice)
                {
                    return getImageOfSecsDevice((FSecsDevice)fObject, tvwTree);
                }
                else if (fObject.fObjectType == FObjectType.SecsSession)
                {
                    return ((FSecsSession)fObject).locked ? tvwTree.ImageList.Images["SecsSession_lock"] : tvwTree.ImageList.Images["SecsSession_unlock"];
                }
                else if (fObject.fObjectType == FObjectType.SecsMessageList)
                {
                    return ((FSecsMessageList)fObject).locked ? tvwTree.ImageList.Images["SecsMessageList_lock"] : tvwTree.ImageList.Images["SecsMessageList_unlock"];
                }
                else if (fObject.fObjectType == FObjectType.SecsMessages)
                {
                    return getImageOfSecsMessages((FSecsMessages)fObject, tvwTree);
                }
                else if (fObject.fObjectType == FObjectType.SecsMessage)
                {
                    return getImageOfSecsMessage((FSecsMessage)fObject, tvwTree);
                }
                else if (fObject.fObjectType == FObjectType.SecsItem)
                {
                    return getImageOfSecsItem((FSecsItem)fObject, tvwTree);
                }
                else if (fObject.fObjectType == FObjectType.HostLibraryGroup)
                {
                    return ((FHostLibraryGroup)fObject).locked ? tvwTree.ImageList.Images["HostLibraryGroup_lock"] : tvwTree.ImageList.Images["HostLibraryGroup_unlock"];
                }
                else if (fObject.fObjectType == FObjectType.HostLibrary)
                {
                    return ((FHostLibrary)fObject).locked ? tvwTree.ImageList.Images["HostLibrary_lock"] : tvwTree.ImageList.Images["HostLibrary_unlock"];
                }
                else if (fObject.fObjectType == FObjectType.HostDevice)
                {
                    return getImageOfHostDevice((FHostDevice)fObject, tvwTree);
                }
                else if (fObject.fObjectType == FObjectType.HostSession)
                {
                    return ((FHostSession)fObject).locked ? tvwTree.ImageList.Images["HostSession_lock"] : tvwTree.ImageList.Images["HostSession_unlock"];
                }
                else if (fObject.fObjectType == FObjectType.HostMessageList)
                {
                    return ((FHostMessageList)fObject).locked ? tvwTree.ImageList.Images["HostMessageList_lock"] : tvwTree.ImageList.Images["HostMessageList_unlock"];
                }
                else if (fObject.fObjectType == FObjectType.HostMessages)
                {
                    return getImageOfHostMessages((FHostMessages)fObject, tvwTree);
                }
                else if (fObject.fObjectType == FObjectType.HostMessage)
                {
                    return getImageOfHostMessage((FHostMessage)fObject, tvwTree);
                }
                else if (fObject.fObjectType == FObjectType.HostItem)
                {
                    return getImageOfHostItem((FHostItem)fObject, tvwTree);
                }
                else if (fObject.fObjectType == FObjectType.Equipment)
                {
                    return ((FEquipment)fObject).locked ? tvwTree.ImageList.Images["Equipment_lock"] : tvwTree.ImageList.Images["Equipment_unlock"];
                }
                else if (fObject.fObjectType == FObjectType.ScenarioGroup)
                {
                    return ((FScenarioGroup)fObject).locked ? tvwTree.ImageList.Images["ScenarioGroup_lock"] : tvwTree.ImageList.Images["ScenarioGroup_unlock"];
                }
                else if (fObject.fObjectType == FObjectType.Scenario)
                {
                    return ((FScenario)fObject).locked ? tvwTree.ImageList.Images["Scenario_lock"] : tvwTree.ImageList.Images["Scenario_unlock"];
                }
                else if (fObject.fObjectType == FObjectType.SecsTrigger)
                {
                    return tvwTree.ImageList.Images["SecsTrigger"];
                }
                else if (fObject.fObjectType == FObjectType.SecsCondition)
                {
                    return getImageOfSecsCondition((FSecsCondition)fObject, tvwTree);
                }
                else if (fObject.fObjectType == FObjectType.SecsExpression)
                {
                    return getImageOfSecsExpression((FSecsExpression)fObject, tvwTree);
                }
                else if (fObject.fObjectType == FObjectType.SecsTransmitter)
                {
                    return tvwTree.ImageList.Images["SecsTransmitter"];
                }
                else if (fObject.fObjectType == FObjectType.SecsTransfer)
                {
                    return tvwTree.ImageList.Images["SecsTransfer"];
                }
                else if (fObject.fObjectType == FObjectType.HostTrigger)
                {
                    return tvwTree.ImageList.Images["HostTrigger"];
                }
                else if (fObject.fObjectType == FObjectType.HostCondition)
                {
                    return getImageOfHostCondition((FHostCondition)fObject, tvwTree);
                }
                else if (fObject.fObjectType == FObjectType.HostExpression)
                {
                    return getImageOfHostExpression((FHostExpression)fObject, tvwTree);
                }
                else if (fObject.fObjectType == FObjectType.HostTransmitter)
                {
                    return tvwTree.ImageList.Images["HostTransmitter"];
                }
                else if (fObject.fObjectType == FObjectType.HostTransfer)
                {
                    return tvwTree.ImageList.Images["HostTransfer"];
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                {
                    return tvwTree.ImageList.Images["EquipmentStateSetAlterer"];
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateAlterer)
                {
                    return tvwTree.ImageList.Images["EquipmentStateAlterer"];
                }
                else if (fObject.fObjectType == FObjectType.Callback)
                {
                    return tvwTree.ImageList.Images["Callback"];
                }
                else if (fObject.fObjectType == FObjectType.Function)
                {
                    return tvwTree.ImageList.Images["Function"];
                }
                else if (fObject.fObjectType == FObjectType.Judgement)
                {
                    return tvwTree.ImageList.Images["Judgement"];
                }
                else if (fObject.fObjectType == FObjectType.JudgementCondition)
                {
                    return tvwTree.ImageList.Images["JudgementCondition"];
                }
                else if (fObject.fObjectType == FObjectType.JudgementExpression)
                {
                    return getImageOfJudgementExpression((FJudgementExpression)fObject, tvwTree);
                }
                else if (fObject.fObjectType == FObjectType.Mapper)
                {
                    return tvwTree.ImageList.Images["Mapper"];
                }
                else if (fObject.fObjectType == FObjectType.Storage)
                {
                    return tvwTree.ImageList.Images["Storage"];
                }
                else if (fObject.fObjectType == FObjectType.Branch)
                {
                    return tvwTree.ImageList.Images["Branch"];
                }
                else if (fObject.fObjectType == FObjectType.Comment)
                {
                    return tvwTree.ImageList.Images["Comment"];
                }
                else if (fObject.fObjectType == FObjectType.Pauser)
                {
                    return tvwTree.ImageList.Images["Pauser"];
                }
                else if (fObject.fObjectType == FObjectType.EntryPoint)
                {
                    return tvwTree.ImageList.Images["EntryPoint"];
                }
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

        public static Image getImageOfObjectLog(
            FIObjectLog fObjectLog,
            FTreeView tvwTree
            )
        {
            FDeviceState fDeviceState;
            FHostMessageType fHostMessageType;

            try
            {
                // ***
                // SecsDriver
                // ***
                if (fObjectLog.fObjectLogType == FObjectLogType.SecsDriverLog)
                {
                    return tvwTree.ImageList.Images["SecsDriverLog"];
                }
                // ***
                // SecsDevice
                // ***
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceStateChangedLog)
                {
                    fDeviceState = ((FSecsDeviceStateChangedLog)fObjectLog).fState;
                    if (fDeviceState == FDeviceState.Opened)
                    {
                        return tvwTree.ImageList.Images["SdvStateChangedLog_Opened"];
                    }
                    else if (fDeviceState == FDeviceState.Connected)
                    {
                        return tvwTree.ImageList.Images["SdvStateChangedLog_Connected"];
                    }
                    else if (fDeviceState == FDeviceState.Selected)
                    {
                        return tvwTree.ImageList.Images["SdvStateChangedLog_Selected"];
                    }
                    else if (fDeviceState == FDeviceState.Closed)
                    {
                        return tvwTree.ImageList.Images["SdvStateChangedLog_Closed"];
                    }
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceControlMessageReceivedLog)
                {
                    return tvwTree.ImageList.Images["SdvControlMessageReceivedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceControlMessageSentLog)
                {
                    return tvwTree.ImageList.Images["SdvControlMessageSentLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTelnetPacketReceivedLog)
                {
                    return tvwTree.ImageList.Images["SdvTelnetPacketReceivedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTelnetPacketSentLog)
                {
                    return tvwTree.ImageList.Images["SdvTelnetPacketSentLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTelnetStateChangedLog)
                {
                    return tvwTree.ImageList.Images["SdvTelnetStateChangedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceHandshakeReceivedLog)
                {
                    return tvwTree.ImageList.Images["SdvHandshakeReceivedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceHandshakeSentLog)
                {
                    return tvwTree.ImageList.Images["SdvHandshakeSentLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceBlockReceivedLog)
                {
                    return tvwTree.ImageList.Images["SdvBlockReceivedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceBlockSentLog)
                {
                    return tvwTree.ImageList.Images["SdvBlockSentLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog)
                {
                    return ((FSecsDeviceDataMessageReceivedLog)fObjectLog).isPrimary ? tvwTree.ImageList.Images["SdvDataMessageReceivedLog_Primary"] : tvwTree.ImageList.Images["SdvDataMessageReceivedLog_Secondary"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog)
                {
                    return ((FSecsDeviceDataMessageSentLog)fObjectLog).isPrimary ? tvwTree.ImageList.Images["SdvDataMessageSentLog_Primary"] : tvwTree.ImageList.Images["SdvDataMessageSentLog_Secondary"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsItemLog)
                {
                    return ((FSecsItemLog)fObjectLog).fFormat == FFormat.List? tvwTree.ImageList.Images["SecsItemLog_List"] : tvwTree.ImageList.Images["SecsItemLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataReceivedLog)
                {
                    return tvwTree.ImageList.Images["SdvDataReceivedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataSentLog)
                {
                    return tvwTree.ImageList.Images["SdvDataSentLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceSmlReceivedLog)
                {
                    return tvwTree.ImageList.Images["SdvSmlReceivedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceSmlSentLog)
                {
                    return tvwTree.ImageList.Images["SdvSmlSentLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceErrorRaisedLog)
                {
                    return tvwTree.ImageList.Images["SdvErrorRaisedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTimeoutRaisedLog)
                {
                    return tvwTree.ImageList.Images["SdvTimeoutRaisedLog"];
                }
                // ***
                // HostDevice
                // ***
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceStateChangedLog)
                {
                    fDeviceState = ((FHostDeviceStateChangedLog)fObjectLog).fState;
                    if (fDeviceState == FDeviceState.Opened)
                    {
                        return tvwTree.ImageList.Images["HdvStateChangedLog_Opened"];
                    }
                    else if (fDeviceState == FDeviceState.Connected)
                    {
                        return tvwTree.ImageList.Images["HdvStateChangedLog_Connected"];
                    }
                    else if (fDeviceState == FDeviceState.Selected)
                    {
                        return tvwTree.ImageList.Images["HdvStateChangedLog_Selected"];
                    }
                    else if (fDeviceState == FDeviceState.Closed)
                    {
                        return tvwTree.ImageList.Images["HdvStateChangedLog_Closed"];
                    }
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                {
                    fHostMessageType = ((FHostDeviceDataMessageReceivedLog)fObjectLog).fHostMessageType;
                    if (fHostMessageType == FHostMessageType.Command)
                    {
                        return tvwTree.ImageList.Images["HdvDataMessageReceivedLog_Command"];
                    }
                    else if (fHostMessageType == FHostMessageType.Unsolicited)
                    {
                        return tvwTree.ImageList.Images["HdvDataMessageReceivedLog_Unsolicited"];
                    }
                    else if (fHostMessageType == FHostMessageType.Reply)
                    {
                        return tvwTree.ImageList.Images["HdvDataMessageReceivedLog_Reply"];
                    }
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                {
                    fHostMessageType = ((FHostDeviceDataMessageSentLog)fObjectLog).fHostMessageType;
                    if (fHostMessageType == FHostMessageType.Command)
                    {
                        return tvwTree.ImageList.Images["HdvDataMessageSentLog_Command"];
                    }
                    else if (fHostMessageType == FHostMessageType.Unsolicited)
                    {
                        return tvwTree.ImageList.Images["HdvDataMessageSentLog_Unsolicited"];
                    }
                    else if (fHostMessageType == FHostMessageType.Reply)
                    {
                        return tvwTree.ImageList.Images["HdvDataMessageSentLog_Reply"];
                    }
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostItemLog)
                {
                    return ((FHostItemLog)fObjectLog).fFormat == FFormat.List ? tvwTree.ImageList.Images["HostItemLog_List"] : tvwTree.ImageList.Images["HostItemLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceVfeiReceivedLog)
                {
                    return tvwTree.ImageList.Images["HdvVfeiReceivedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceVfeiSentLog)
                {
                    return tvwTree.ImageList.Images["HdvVfeiSentLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceErrorRaisedLog)
                {
                    return tvwTree.ImageList.Images["HdvErrorRaisedLog"];
                }
                // ***
                // Scenario
                // ***
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsTriggerRaisedLog)
                {
                    return tvwTree.ImageList.Images["SecsTriggerRaisedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsTransmitterRaisedLog)
                {
                    return tvwTree.ImageList.Images["SecsTransmitterRaisedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTriggerRaisedLog)
                {
                    return tvwTree.ImageList.Images["HostTriggerRaisedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTransmitterRaisedLog)
                {
                    return tvwTree.ImageList.Images["HostTransmitterRaisedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.JudgementPerformedLog)
                {
                    return tvwTree.ImageList.Images["JudgementPerformedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.MapperPerformedLog)
                {
                    return tvwTree.ImageList.Images["MapperPerformedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EquipmentStateSetAltererPerformedLog)
                {
                    return tvwTree.ImageList.Images["EquipmentStateSetAltererPerformedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EquipmentStateAltererLog)
                {
                    return tvwTree.ImageList.Images["EquipmentStateAltererLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.DataSetLog)
                {
                    return tvwTree.ImageList.Images["DataSetLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.DataLog)
                {
                    return ((FDataLog)fObjectLog).fFormat == FFormat.List ? tvwTree.ImageList.Images["DataLog_List"] : tvwTree.ImageList.Images["DataLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.StoragePerformedLog)
                {
                    return tvwTree.ImageList.Images["StoragePerformedLog"];
                }
                // ***
                // 2017.04.05 by spike.lee
                // RepositoryLog 관련 Image 추가
                // ***
                else if (fObjectLog.fObjectLogType == FObjectLogType.RepositoryLog)
                {
                    return tvwTree.ImageList.Images["RepositoryLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.ColumnLog)
                {
                    return ((FColumnLog)fObjectLog).fFormat == FFormat.List ? tvwTree.ImageList.Images["ColumnLog_List"] : tvwTree.ImageList.Images["ColumnLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CallbackRaisedLog)
                {
                    return tvwTree.ImageList.Images["CallbackRaisedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.BranchRaisedLog)
                {
                    return tvwTree.ImageList.Images["BranchRaisedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.FunctionCalledLog)
                {
                    return tvwTree.ImageList.Images["FunctionCalledLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CommentWrittenLog)
                {
                    return tvwTree.ImageList.Images["CommentWritedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PauserRaisedLog)
                {
                    return tvwTree.ImageList.Images["PauserRaisedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EntryPointCalledLog)
                {
                    return tvwTree.ImageList.Images["EntryPointCalledLog"];
                }
                // ***
                // Application
                // ***
                else if (fObjectLog.fObjectLogType == FObjectLogType.ApplicationWrittenLog)
                {
                    return tvwTree.ImageList.Images["ApplicationWritedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.ContentLog)
                {
                    return ((FContentLog)fObjectLog).fFormat == FFormat.List ? tvwTree.ImageList.Images["ContentLog_List"] : tvwTree.ImageList.Images["ContentLog"];
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

        public static void validateName(
            string name,
            bool emptyError,
            FUIWizard fUIWizard
            )
        {
            char[] c = { ' ', '\\', '/', '.', ',', '\'', '"', '&', '|', '[', ']', '(', ')', ':', ';', '`', '~', '!', '@', '#', '$', '%', '^', '*', '+', '=', '\n', '\r' };

            try
            {
                if (name == string.Empty && emptyError)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0004", new object[] { "string literal" }));
                }

                if (name.IndexOfAny(c) > -1)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0003"));
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

        public static void refreshTreeNodeOfObject(
            FIObject fObject,
            FTreeView tvwTree,
            UltraTreeNode tNode
            )
        {
            try
            {
                tNode.Text = fObject.ToString(FStringOption.Detail);
                // --
                tNode.Override.NodeAppearance.ForeColor = fObject.fontColor;
                tNode.Override.NodeAppearance.FontData.Bold = fObject.fontBold ? DefaultableBoolean.True : DefaultableBoolean.False;
                // --
                tNode.Override.ActiveNodeAppearance.ForeColor = fObject.fontColor;
                tNode.Override.ActiveNodeAppearance.FontData.Bold = fObject.fontBold ? DefaultableBoolean.True : DefaultableBoolean.False;
                // --
                tNode.Override.SelectedNodeAppearance.ForeColor = fObject.fontColor;
                tNode.Override.SelectedNodeAppearance.FontData.Bold = fObject.fontBold ? DefaultableBoolean.True : DefaultableBoolean.False;
                // --
                tNode.Override.ImageSize = new Size(16, 16);
                tNode.Override.NodeAppearance.Image = getImageOfObject(fObject, tvwTree);
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

        public static void refreshGridRowOfObject(
            FIObject fObject,
            UltraGridRow gridRow
            )
        {
            try
            { 
                foreach (UltraGridCell cell in gridRow.Cells)
                {
                    cell.Appearance.ForeColor = fObject.fontColor;
                    cell.SelectedAppearance.ForeColor = cell.Appearance.ForeColor;
                    cell.ActiveAppearance.ForeColor = cell.Appearance.ForeColor;

                    // --

                    cell.Appearance.FontData.Bold = fObject.fontBold ? DefaultableBoolean.True : DefaultableBoolean.False;
                    cell.SelectedAppearance.FontData.Bold = cell.Appearance.FontData.Bold;
                    cell.ActiveAppearance.FontData.Bold = cell.Appearance.FontData.Bold;
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

        public static void refreshFlowContainerOfObject(
            FIObject fObject, 
            FFlowContainer fFlowContainer
            )
        {
            try
            {
                fFlowContainer.text = fObject.ToString(FStringOption.Detail);
                fFlowContainer.fontBold = fObject.fontBold;
                fFlowContainer.fontColor = fObject.fontColor;
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

        public static void refreshFlowContainerOfObject(
            FIObject fObject,
            Nexplant.MC.Core.FaUIs.WPF.FFlowContainer fFlowContainer
            )
        {
            try
            {
                if (fObject.fObjectType == FObjectType.Scenario)
                {
                    fFlowContainer.title = fObject.ToString(FStringOption.Detail);
                    fFlowContainer.fontBold = fObject.fontBold;
                    fFlowContainer.fontColor = fromColor(fObject.fontColor);
                }
                else
                {
                    fFlowContainer.title = string.Empty;
                    fFlowContainer.fontBold = false;
                    fFlowContainer.fontColor = fromColor(Color.Black);
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

        public static void refreshFlowCtrlOfObject(
            FIObject fObject, 
            FIFlowCtrl fFlowCtrl,
            FTreeView tvwTree
            )
        {
            try
            {
                fFlowCtrl.text = fObject.name;
                fFlowCtrl.fontBold = fObject.fontBold;
                fFlowCtrl.fontColor = fObject.fontColor;
                fFlowCtrl.image = getImageOfObject(fObject, tvwTree);
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

        public static void refreshFlowCtrlOfObject(
            FIObject fObject,
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fFlowCtrl,
            FTreeView tvwTree
            )
        {
            int childCount = 0;
            System.Windows.Controls.TextBlock textBlock = null;
            System.Windows.DependencyObject obj = null;

            try
            {    
                fFlowCtrl.text = fObject.name;
                fFlowCtrl.fontBold = fObject.fontBold;
                fFlowCtrl.fontColor = fObject.fontColor;
                fFlowCtrl.image = getImageOfObject(fObject, tvwTree);

                // -- 

                // ***
                // 객체가 생성되어 있는 경우, 컨트롤에 반영
                // ***
                childCount = System.Windows.Media.VisualTreeHelper.GetChildrenCount(fFlowCtrl.panel);
                if (childCount > 0)
                {                    
                    for (int i = 0; i < childCount; i++)
                    {
                        obj = System.Windows.Media.VisualTreeHelper.GetChild(fFlowCtrl.panel, i);
                        if (obj is System.Windows.Controls.TextBlock)
                        {
                            textBlock = obj as System.Windows.Controls.TextBlock;
                            textBlock.Text = fObject.name;
                            textBlock.Foreground = new System.Windows.Media.SolidColorBrush(Nexplant.MC.Core.FaUIs.WPF.FCommon.convertWinColorToWpfColor(fObject.fontColor));
                            textBlock.FontWeight = (fObject.fontBold) ? System.Windows.FontWeights.Bold : System.Windows.FontWeights.Normal;                            
                            break;
                        }
                    }
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

        public static void refreshTreeNodeOfObjectLog(
            FIObjectLog fObjectLog,
            UltraTreeNode tNode,
            FTreeView tvwTree
            )
        {
            FResultCode fResultCode = FResultCode.Success;

            try
            {
                tNode.Text = fObjectLog.ToString(FStringOption.Detail);
                // --
                tNode.Override.NodeAppearance.ForeColor = fObjectLog.fontColor;
                tNode.Override.NodeAppearance.FontData.Bold = fObjectLog.fontBold ? DefaultableBoolean.True : DefaultableBoolean.False;
                // --
                tNode.Override.ActiveNodeAppearance.ForeColor = fObjectLog.fontColor;
                tNode.Override.ActiveNodeAppearance.FontData.Bold = fObjectLog.fontBold ? DefaultableBoolean.True : DefaultableBoolean.False;
                // --
                tNode.Override.SelectedNodeAppearance.ForeColor = fObjectLog.fontColor;
                tNode.Override.SelectedNodeAppearance.FontData.Bold = fObjectLog.fontBold ? DefaultableBoolean.True : DefaultableBoolean.False;
                // --
                tNode.Override.ImageSize = new Size(16, 16);
                tNode.Override.NodeAppearance.Image = getImageOfObjectLog(fObjectLog, tvwTree);

                // --

                fResultCode = getResultCode(fObjectLog);
                if (fResultCode != FResultCode.Success)
                {
                    tNode.LeftImages.Add(fResultCode == FResultCode.Warninig ?
                        tvwTree.ImageList.Images["Result_Warning"] : tvwTree.ImageList.Images["Result_Error"]
                        );
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

        private static System.Windows.Media.Brush fromColor(
            System.Drawing.Color color
            )
        {
            try
            {
                return new System.Windows.Media.SolidColorBrush(
                        System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B)
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

        internal static string loadFile(
            FSsmCore fSsmCore,
            string filePath
            )
        {
            int fileOrder = 0;
            string tmpFilePath = string.Empty;

            try
            {
                tmpFilePath = filePath;
                if (isInUseFile(filePath))
                {
                    FMessageBox.showInformation(
                        FConstants.ApplicationName,
                        fSsmCore.fWsmCore.fUIWizard.generateMessage("M0018"),
                        fSsmCore.fWsmCore.fWsmContainer
                        );

                    // -- 

                    if (!Directory.Exists(fSsmCore.fWsmCore.tempPath))
                    {
                        Directory.CreateDirectory(fSsmCore.fWsmCore.tempPath);
                    }

                    // --

                    tmpFilePath =
                        fSsmCore.fWsmCore.tempPath + "\\" +
                        Path.GetFileNameWithoutExtension(filePath) + " - " + fSsmCore.fWsmCore.fUIWizard.searchCaption("Copy") +
                        Path.GetExtension(filePath);

                    // --

                    // ***
                    // 동일한 파일명이 발생하지 않도록 체크
                    // ***
                    fileOrder = 2;
                    while (File.Exists(tmpFilePath))
                    {
                        tmpFilePath =
                            fSsmCore.fWsmCore.tempPath + "\\" +
                            Path.GetFileNameWithoutExtension(filePath) + " - " + fSsmCore.fWsmCore.fUIWizard.searchCaption("Copy") + " (" + (fileOrder++) + ")" +
                            Path.GetExtension(filePath);
                    }

                    // --

                    File.Copy(filePath, tmpFilePath);
                }
                return tmpFilePath;
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

        private static bool isInUseFile(
            string filepath
            )
        {
            try
            {
                if ((File.GetAttributes(filepath) & FileAttributes.ReadOnly) != FileAttributes.ReadOnly)
                {
                    using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                    {
                        try
                        {
                            if (fs.CanWrite)
                            {
                                return false;
                            }
                            return true;
                        }
                        catch (IOException)
                        {
                            return true;
                        }
                        finally
                        {
                            fs.Close();
                        }
                    }
                }
                else
                {
                    return true;
                }
            }
            catch (IOException)
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

        //------------------------------------------------------------------------------------------------------------------------

        public static void setDragOverTreeNode(
           UltraTreeNode tNode
           )
        {
            try
            {
                tNode.Override.NodeAppearance.FontData.Italic = DefaultableBoolean.True;
                tNode.Override.NodeAppearance.FontData.Underline = DefaultableBoolean.True;
                // --
                tNode.Override.NodeAppearance.BackColor = Color.WhiteSmoke;
                tNode.Override.NodeAppearance.BackColor2 = Color.LightGray;
                tNode.Override.NodeAppearance.BackGradientStyle = GradientStyle.VerticalBump;
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

        public static void resetDragOverTreeNode(
            UltraTreeNode tNode
            )
        {
            try
            {
                tNode.Override.NodeAppearance.FontData.Italic = DefaultableBoolean.False;
                tNode.Override.NodeAppearance.FontData.Underline = DefaultableBoolean.False;
                // --
                tNode.Override.NodeAppearance.BackColor = Color.WhiteSmoke;
                tNode.Override.NodeAppearance.BackColor2 = Color.WhiteSmoke;
                tNode.Override.NodeAppearance.BackGradientStyle = GradientStyle.Default;
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

        public static void setDragOverFlowCtrl(
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fFlowCtrl
            )
        {
            int childCount = 0;
            System.Windows.Controls.TextBlock textBlock = null;
            System.Windows.DependencyObject obj = null;

            try
            {
                childCount = System.Windows.Media.VisualTreeHelper.GetChildrenCount(fFlowCtrl.panel);
                if (childCount > 0)
                {
                    for (int i = 0; i < childCount; i++)
                    {
                        obj = System.Windows.Media.VisualTreeHelper.GetChild(fFlowCtrl.panel, i);
                        if (obj is System.Windows.Controls.TextBlock)
                        {
                            textBlock = obj as System.Windows.Controls.TextBlock;
                            textBlock.FontStyle = System.Windows.FontStyles.Italic;
                            textBlock.TextDecorations = System.Windows.TextDecorations.Underline;
                            break;
                        }
                    }
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

        public static void resetDragOverFlowCtrl(
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fFlowCtrl
            )
        {
            int childCount = 0;
            System.Windows.Controls.TextBlock textBlock = null;
            System.Windows.DependencyObject obj = null;

            try
            {
                childCount = System.Windows.Media.VisualTreeHelper.GetChildrenCount(fFlowCtrl.panel);
                if (childCount > 0)
                {
                    for (int i = 0; i < childCount; i++)
                    {
                        obj = System.Windows.Media.VisualTreeHelper.GetChild(fFlowCtrl.panel, i);
                        if (obj is System.Windows.Controls.TextBlock)
                        {
                            textBlock = obj as System.Windows.Controls.TextBlock;
                            textBlock.FontStyle = System.Windows.FontStyles.Normal;
                            textBlock.TextDecorations = null;
                            break;
                        }
                    }
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