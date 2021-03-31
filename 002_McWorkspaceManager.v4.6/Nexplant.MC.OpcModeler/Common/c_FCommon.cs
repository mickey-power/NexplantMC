/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FCommon.cs
--  Creator         : spike.lee
--  Create Date     : 2011.02.09
--  Description     : FAMate OPC Modeler Common Function Class 
--  History         : Created by spike.lee at 2011.02.09
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using System.IO;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinTree;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.OpcModeler
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

        private static Image getImageOfOpcExpression(
            FOpcExpression fOep,
            FTreeView tvwTree
            )
        {
            try
            {
                if (fOep.fExpressionType == FExpressionType.Bracket)
                {
                    return tvwTree.ImageList.Images["OpcExpression_Bracket"];
                }
                else if (fOep.fExpressionType == FExpressionType.Comparison)
                {
                    if (fOep.fComparisonMode == FComparisonMode.Value)
                    {
                        if (fOep.fOperandType == FOpcOperandType.EquipmentState)
                        {
                            return tvwTree.ImageList.Images["OpcExpression_Comparison_Value_EquipmentState"];
                        }
                        else if (fOep.fOperandType == FOpcOperandType.Environment)
                        {
                            return tvwTree.ImageList.Images["OpcExpression_Comparison_Value_Environment"];
                        }
                        else if (fOep.fOperandType == FOpcOperandType.OpcItem)
                        {
                            return tvwTree.ImageList.Images["OpcExpression_Comparison_Value_Item"];
                        }
                        else if (fOep.fOperandType == FOpcOperandType.OpcEventItem)
                        {
                            return tvwTree.ImageList.Images["OpcExpression_Comparison_Value_Item"];
                        }
                    }
                    else if (fOep.fComparisonMode == FComparisonMode.Length)
                    {
                        if (fOep.fOperandType == FOpcOperandType.Environment)
                        {
                            return tvwTree.ImageList.Images["OpcExpression_Comparison_Length_Environment"];
                        }
                        else if (fOep.fOperandType == FOpcOperandType.OpcItem)
                        {
                            return tvwTree.ImageList.Images["OpcExpression_Comparison_Length_Item"];
                        }
                        else if (fOep.fOperandType == FOpcOperandType.OpcEventItem)
                        {
                            return tvwTree.ImageList.Images["OpcExpression_Comparison_Length_Item"];
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

        private static Image getImageOfOpcCondition(
            FOpcCondition fOcn,
            FTreeView tvwTree
            )
        {
            try
            {
                if (fOcn.fConditionMode == FOpcConditionMode.Expression)
                {
                    return tvwTree.ImageList.Images["OpcCondition_Expression"];
                }
                else if (fOcn.fConditionMode == FOpcConditionMode.Connection)
                {
                    if (fOcn.fConnectionState == FDeviceState.Closed)
                    {
                        return tvwTree.ImageList.Images["OpcCondition_Connection_Closed"];
                    }
                    else if (fOcn.fConnectionState == FDeviceState.Opened)
                    {
                        return tvwTree.ImageList.Images["OpcCondition_Connection_Opened"];
                    }
                    else if (fOcn.fConnectionState == FDeviceState.Connected)
                    {
                        return tvwTree.ImageList.Images["OpcCondition_Connection_Connected"];
                    }
                    else if (fOcn.fConnectionState == FDeviceState.Selected)
                    {
                        return tvwTree.ImageList.Images["OpcCondition_Connection_Selected"];
                    }
                    else if (fOcn.fConnectionState == FDeviceState.ErrorShutdown || fOcn.fConnectionState == FDeviceState.ErrorWatchDog || fOcn.fConnectionState == FDeviceState.Undefined)
                    {
                        return tvwTree.ImageList.Images["OpcCondition_Connection_Error"];
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
                // OpcDevice
                // ***
                if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceStateChangedLog)
                {
                    fResultCode = ((FOpcDeviceStateChangedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageReadLog)
                {
                    fResultCode = ((FOpcDeviceDataMessageReadLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageWrittenLog)
                {
                    fResultCode = ((FOpcDeviceDataMessageWrittenLog)fObjectLog).fResultCode;
                }
                //else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataReceivedLog)
                //{
                //    fResultCode = ((FOpcDeviceDataReceivedLog)fObjectLog).fResultCode;
                //}
                //else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataSentLog)
                //{
                //    fResultCode = ((FOpcDeviceDataSentLog)fObjectLog).fResultCode;
                //}
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceErrorRaisedLog)
                {
                    fResultCode = ((FOpcDeviceErrorRaisedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceTimeoutRaisedLog)
                {
                    fResultCode = ((FOpcDeviceTimeoutRaisedLog)fObjectLog).fResultCode;
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
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcTriggerRaisedLog)
                {
                    fResultCode = ((FOpcTriggerRaisedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcTransmitterRaisedLog)
                {
                    fResultCode = ((FOpcTransmitterRaisedLog)fObjectLog).fResultCode;
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
                // OpcDriver
                // ***
                if (fObject.fObjectType == FObjectType.OpcDriver)
                {
                    return tvwTree.ImageList.Images["OpcDriver"];
                }
                // ***
                // OpcSetup
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
                // OpcModeling
                // ***
                else if (fObject.fObjectType == FObjectType.OpcLibraryGroup)
                {
                    return ((FOpcLibraryGroup)fObject).locked ? tvwTree.ImageList.Images["OpcLibraryGroup_lock"] : tvwTree.ImageList.Images["OpcLibraryGroup_unlock"];
                }
                else if (fObject.fObjectType == FObjectType.OpcLibrary)
                {
                    return ((FOpcLibrary)fObject).locked ? tvwTree.ImageList.Images["OpcLibrary_lock"] : tvwTree.ImageList.Images["OpcLibrary_unlock"];
                }
                else if (fObject.fObjectType == FObjectType.OpcDevice)
                {
                    return getImageOfOpcDevice((FOpcDevice)fObject, tvwTree);
                }
                else if (fObject.fObjectType == FObjectType.OpcSession)
                {
                    return ((FOpcSession)fObject).locked ? tvwTree.ImageList.Images["OpcSession_lock"] : tvwTree.ImageList.Images["OpcSession_unlock"];
                }
                else if (fObject.fObjectType == FObjectType.ItemName)
                {
                    return tvwTree.ImageList.Images["OpcItem_unlock"];
                }
                else if (fObject.fObjectType == FObjectType.OpcMessageList)
                {
                    return ((FOpcMessageList)fObject).locked ? tvwTree.ImageList.Images["OpcMessageList_lock"] : tvwTree.ImageList.Images["OpcMessageList_unlock"];
                }
                else if (fObject.fObjectType == FObjectType.OpcMessages)
                {
                    return getImageOfOpcMessages((FOpcMessages)fObject, tvwTree);
                }
                else if (fObject.fObjectType == FObjectType.OpcMessage)
                {
                    return getImageOfOpcMessage((FOpcMessage)fObject, tvwTree);
                }
                else if (fObject.fObjectType == FObjectType.OpcEventItemList)
                {
                    return ((FOpcEventItemList)fObject).locked ? tvwTree.ImageList.Images["OpcEventItemList_lock"] : tvwTree.ImageList.Images["OpcEventItemList_unlock"];
                }
                else if (fObject.fObjectType == FObjectType.OpcEventItem)
                {
                    return ((FOpcEventItem)fObject).locked ? tvwTree.ImageList.Images["OpcEventItem_lock"] : tvwTree.ImageList.Images["OpcEventItem_unlock"];
                }
                else if (fObject.fObjectType == FObjectType.OpcItemList)
                {
                    return ((FOpcItemList)fObject).locked ? tvwTree.ImageList.Images["OpcItemList_lock"] : tvwTree.ImageList.Images["OpcItemList_unlock"];
                }
                else if (fObject.fObjectType == FObjectType.OpcItem)
                {
                    return ((FOpcItem)fObject).locked ? tvwTree.ImageList.Images["OpcItem_lock"] : tvwTree.ImageList.Images["OpcItem_unlock"];
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
                else if (fObject.fObjectType == FObjectType.OpcTrigger)
                {
                    return tvwTree.ImageList.Images["OpcTrigger"];
                }
                else if (fObject.fObjectType == FObjectType.OpcCondition)
                {
                    return getImageOfOpcCondition((FOpcCondition)fObject, tvwTree);
                }
                else if (fObject.fObjectType == FObjectType.OpcExpression)
                {
                    return getImageOfOpcExpression((FOpcExpression)fObject, tvwTree);
                }
                else if (fObject.fObjectType == FObjectType.OpcTransmitter)
                {
                    return tvwTree.ImageList.Images["OpcTransmitter"];
                }
                else if (fObject.fObjectType == FObjectType.OpcTransfer)
                {
                    return tvwTree.ImageList.Images["OpcTransfer"];
                }
                else if (fObject.fObjectType == FObjectType.HostTrigger)
                {
                    return tvwTree.ImageList.Images["HostTrigger"];
                }
                else if (fObject.fObjectType == FObjectType.HostCondition)
                {
                    return ((FHostCondition)fObject).fConditionMode == FConditionMode.Expression ? tvwTree.ImageList.Images["HostCondition_Expression"] : tvwTree.ImageList.Images["HostCondition_Timeout"];
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
                // OpcDriver
                // ***
                if (fObjectLog.fObjectLogType == FObjectLogType.OpcDriverLog)
                {
                    return tvwTree.ImageList.Images["OpcDriverLog"];
                }
                // ***
                // OpcDevice
                // ***
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceStateChangedLog)
                {
                    fDeviceState = ((FOpcDeviceStateChangedLog)fObjectLog).fState;
                    if (fDeviceState == FDeviceState.Opened)
                    {
                        return tvwTree.ImageList.Images["OdvStateChangedLog_Opened"];
                    }
                    else if (fDeviceState == FDeviceState.Connected)
                    {
                        return tvwTree.ImageList.Images["OdvStateChangedLog_Connected"];
                    }
                    else if (fDeviceState == FDeviceState.Selected)
                    {
                        return tvwTree.ImageList.Images["OdvStateChangedLog_Selected"];
                    }
                    else if (fDeviceState == FDeviceState.Closed)
                    {
                        return tvwTree.ImageList.Images["OdvStateChangedLog_Closed"];
                    }
                    else if (fDeviceState == FDeviceState.ErrorShutdown || fDeviceState == FDeviceState.ErrorWatchDog || fDeviceState == FDeviceState.Undefined)
                    {
                        return tvwTree.ImageList.Images["OdvStateChangedLog_Error"];
                    }
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageReadLog)
                {
                    return ((FOpcDeviceDataMessageReadLog)fObjectLog).isPrimary ? tvwTree.ImageList.Images["OdvDataMessageReadLog_Primary"] : tvwTree.ImageList.Images["OdvDataMessageReadLog_Secondary"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageWrittenLog)
                {
                    return ((FOpcDeviceDataMessageWrittenLog)fObjectLog).isPrimary ? tvwTree.ImageList.Images["OdvDataMessageWrittenLog_Primary"] : tvwTree.ImageList.Images["OdvDataMessageWrittenLog_Secondary"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcEventItemListLog)
                {
                    return tvwTree.ImageList.Images["OpcEventItemListLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcEventItemLog)
                {
                    return tvwTree.ImageList.Images["OpcEventItemLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcItemListLog)
                {
                    return tvwTree.ImageList.Images["OpcItemListLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcItemLog)
                {
                    return tvwTree.ImageList.Images["OpcItemLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceErrorRaisedLog)
                {
                    return tvwTree.ImageList.Images["OdvErrorRaisedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceTimeoutRaisedLog)
                {
                    return tvwTree.ImageList.Images["OdvTimeoutRaisedLog"];                
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
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcTriggerRaisedLog)
                {
                    return tvwTree.ImageList.Images["OpcTriggerRaisedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcTransmitterRaisedLog)
                {
                    return tvwTree.ImageList.Images["OpcTransmitterRaisedLog"];
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

        private static Image getImageOfOpcDevice(
            FOpcDevice fOdv,
            FTreeView tvwTree
            )
        {
            try
            {
                if (fOdv.fState == FDeviceState.Opened)
                {
                    if (fOdv.locked)
                    {
                        return tvwTree.ImageList.Images["OpcDevice_Opened_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["OpcDevice_Opened_unlock"];
                    }
                }
                else if (fOdv.fState == FDeviceState.Connected)
                {
                    if (fOdv.locked)
                    {
                        return tvwTree.ImageList.Images["OpcDevice_Connected_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["OpcDevice_Connected_unlock"];
                    }
                }
                else if (fOdv.fState == FDeviceState.Selected)
                {
                    if (fOdv.locked)
                    {
                        return tvwTree.ImageList.Images["OpcDevice_Selected_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["OpcDevice_Selected_unlock"];
                    }
                }
                else if (fOdv.fState == FDeviceState.Closed)
                {
                    if (fOdv.locked)
                    {
                        return tvwTree.ImageList.Images["OpcDevice_Closed_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["OpcDevice_Closed_unlock"];
                    }
                }
                else if (fOdv.fState == FDeviceState.ErrorShutdown || fOdv.fState == FDeviceState.ErrorWatchDog || fOdv.fState == FDeviceState.Undefined)
                {
                    if (fOdv.locked)
                    {
                        return tvwTree.ImageList.Images["OpcDevice_Error_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["OpcDevice_Error_unlock"];
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

        private static Image getImageOfOpcMessages(
            FOpcMessages fOms,
            FTreeView tvwTree
            )
        {
            try
            {
                if (fOms.fDirection == FOpcDirection.Read)
                {
                    if (fOms.locked)
                    {
                        return tvwTree.ImageList.Images["OpcMessages_Read_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["OpcMessages_Read_unlock"];
                    }
                }
                else if (fOms.fDirection == FOpcDirection.Write)
                {
                    if (fOms.locked)
                    {
                        return tvwTree.ImageList.Images["OpcMessages_Write_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["OpcMessages_Write_unlock"];
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

        private static Image getImageOfOpcMessage(
            FOpcMessage fOmg,
            FTreeView tvwTree
            )
        {
            try
            {
                if (fOmg.isPrimary)
                {
                    if (fOmg.locked)
                    {
                        return tvwTree.ImageList.Images["OpcMessage_Primary_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["OpcMessage_Primary_unlock"];
                    }
                }
                else if (fOmg.isSecondary)
                {
                    if (fOmg.locked)
                    {
                        return tvwTree.ImageList.Images["OpcMessage_Secondary_lock"];
                    }
                    else
                    {
                        return tvwTree.ImageList.Images["OpcMessage_Secondary_unlock"];
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

        public static string addressConverter(
            string oldAddress,
            int dataBlock,
            int adjustValue
            )
        {
            // --
            string dataType = string.Empty;
            string subfixAddress = string.Empty;
            string tempAddress = string.Empty;
            string oldStringValue = string.Empty;
            string convertValue = string.Empty;
            // --
            int oldDataBlock = 0;
            int oldVal = 0;
            try
            {
                // --

                if (!getSimensAddress(oldAddress, out oldDataBlock, out dataType, out oldVal, out subfixAddress))
                {
                    return string.Empty;
                }
               
                // --

                if (subfixAddress != string.Empty)
                {
                    convertValue = string.Format("DB{0}.{1}{2}.{3}", dataBlock, dataType, (oldVal + adjustValue), subfixAddress);
                }
                else
                {
                    convertValue = string.Format("DB{0}.{1}{2}", dataBlock, dataType, (oldVal + adjustValue));
                }

                // --
                return convertValue;
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

        public static bool getSimensAddress(
            string stringAddress,
            out int db,
            out string dataType,
            out int address,
            out string subfixAddress
            )
        {
            string[] spliteString = null;
            char[] tempCharArray = null;
            // --
            string tempAddress = string.Empty;
            string strVal = string.Empty;
            // --
            int digitIdx = 0;
            // --
            db = 0;
            dataType = string.Empty;
            address = 0;
            subfixAddress = string.Empty;

            try
            {
                // --
                spliteString = stringAddress.Split(new char[] { '.' });
                if (spliteString.Length < 2)
                {
                    return false;
                }
                                
                // --

                db = int.Parse(spliteString[0].Substring(2));

                // --

                tempAddress = spliteString[1];
                if (spliteString.Length == 3)
                {
                    subfixAddress = spliteString[2];
                }

                // --
                tempCharArray = tempAddress.ToCharArray();
                for (int i = tempCharArray.Length - 1; i >= 0; i--)
                {
                    if (!char.IsDigit(tempCharArray[i]))
                    {
                        digitIdx = i + 1;
                        break;
                    }
                }

                // --
                dataType = tempAddress.Substring(0, digitIdx);
                strVal = tempAddress.Substring(digitIdx);

                // --
                address = int.Parse(strVal);

                // --
                return true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                spliteString = null;
                tempCharArray = null;
            }
            return false;
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
            FOpmCore fOpmCore,
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
                        fOpmCore.fWsmCore.fUIWizard.generateMessage("M0018"),
                        fOpmCore.fWsmCore.fWsmContainer
                        );

                    // -- 

                    if (!Directory.Exists(fOpmCore.fWsmCore.tempPath))
                    {
                        Directory.CreateDirectory(fOpmCore.fWsmCore.tempPath);
                    }

                    // --

                    tmpFilePath =
                        fOpmCore.fWsmCore.tempPath + "\\" +
                        Path.GetFileNameWithoutExtension(filePath) + " - " + fOpmCore.fWsmCore.fUIWizard.searchCaption("Copy") +
                        Path.GetExtension(filePath);

                    // --

                    // ***
                    // 동일한 파일명이 발생하지 않도록 체크
                    // ***
                    fileOrder = 2;
                    while (File.Exists(tmpFilePath))
                    {
                        tmpFilePath =
                            fOpmCore.fWsmCore.tempPath + "\\" +
                            Path.GetFileNameWithoutExtension(filePath) + " - " + fOpmCore.fWsmCore.fUIWizard.searchCaption("Copy") + " (" + (fileOrder++) + ")" +
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