/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTcp2.cs
--  Creator         : sunghoon.Park
--  Create Date     : 2021.03.12
--  Description     : NexplantMC Core FaTcpDriver FTcp2 Parser Class
--  History         : Created by spike.lee at 2021.03.12
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    internal static class FTcp2
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private static void setTcpMessageLogInfo(
            FXmlNode fXmlNodeTmgl,
            FXmlNode fXmlNodeTdv,
            FXmlNode fXmlNodeTsn,
            string sessionName,
            int sessionId,
            UInt32 tid,
            UInt32 length
            )
        {
            try
            {
                if (fXmlNodeTdv != null)
                {
                    fXmlNodeTmgl.set_attrVal(FXmlTagTMGL.A_TcpDeviceId, FXmlTagTMGL.D_TcpDeviceId, fXmlNodeTdv.get_attrVal(FXmlTagTDV.A_UniqueId, FXmlTagTDV.D_UniqueId));
                    fXmlNodeTmgl.set_attrVal(FXmlTagTMGL.A_TcpDeviceName, FXmlTagTMGL.D_TcpDeviceName, fXmlNodeTdv.get_attrVal(FXmlTagTDV.A_Name, FXmlTagTDV.D_Name));
                }
                // --
                if (fXmlNodeTsn != null)
                {
                    fXmlNodeTmgl.set_attrVal(FXmlTagTMGL.A_TcpSessionId, FXmlTagTMGL.D_TcpSessionId, fXmlNodeTsn.get_attrVal(FXmlTagTSN.A_UniqueId, FXmlTagTSN.D_UniqueId));

                }
                // --
                fXmlNodeTmgl.set_attrVal(FXmlTagTMGL.A_TcpSessionName, FXmlTagTMGL.D_TcpSessionName, sessionName);
                fXmlNodeTmgl.set_attrVal(FXmlTagTMGL.A_SessionId, FXmlTagTMGL.D_SessionId, sessionId.ToString());
                fXmlNodeTmgl.set_attrVal(FXmlTagTMGL.A_TID, FXmlTagTMGL.A_TID, tid.ToString());
                fXmlNodeTmgl.set_attrVal(FXmlTagTMGL.A_Length, FXmlTagTMGL.D_Length, length.ToString());
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

        private static void setTcpMessageLogInfo(
            FXmlNode fXmlNodeTmgl,
            FXmlNode fXmlNodeTdv,
            FXmlNode fXmlNodeTsn,
            string sessionName,
            int sessionId,
            string command,
            int version,
            FTcpMessageType fTcpMessageType,
            UInt32 tid,
            UInt32 length
            )
        {
            try
            {
                setTcpMessageLogInfo(fXmlNodeTmgl, fXmlNodeTdv, fXmlNodeTsn, sessionName, sessionId, tid, length);
                // --
                fXmlNodeTmgl.set_attrVal(FXmlTagTMGL.A_UniqueId, FXmlTagTMGL.D_UniqueId, "0");
                fXmlNodeTmgl.set_attrVal(FXmlTagTMGL.A_Command, FXmlTagTMGL.D_Command, command);
                fXmlNodeTmgl.set_attrVal(FXmlTagTMGL.A_Version, FXmlTagTMGL.D_Version, version.ToString());
                fXmlNodeTmgl.set_attrVal(FXmlTagTMGL.A_TcpMessageType, FXmlTagTMGL.D_TcpMessageType, FEnumConverter.fromTcpMessageType(fTcpMessageType));
                fXmlNodeTmgl.set_attrVal(FXmlTagTMGL.A_AutoReply, FXmlTagTMGL.D_AutoReply, FBoolean.False);
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

        public static void setTcpMessageLogInfo(
            FXmlNode fXmlNodeTmgl,
            FXmlNode fXmlNodeTdv,
            FXmlNode fXmlNodeTsn
            )
        {
            try
            {
                if (fXmlNodeTdv != null)
                {
                    fXmlNodeTmgl.set_attrVal(FXmlTagTMGL.A_TcpDeviceId, FXmlTagTMGL.D_TcpDeviceId, fXmlNodeTdv.get_attrVal(FXmlTagTDV.A_UniqueId, FXmlTagTDV.D_UniqueId));
                    fXmlNodeTmgl.set_attrVal(FXmlTagTMGL.A_TcpDeviceName, FXmlTagTMGL.D_TcpDeviceName, fXmlNodeTdv.get_attrVal(FXmlTagTDV.A_Name, FXmlTagTDV.D_Name));
                }
                // --
                if (fXmlNodeTsn != null)
                {
                    fXmlNodeTmgl.set_attrVal(FXmlTagTMGL.A_TcpSessionId, FXmlTagTMGL.D_TcpSessionId, fXmlNodeTsn.get_attrVal(FXmlTagTSN.A_UniqueId, FXmlTagTSN.D_UniqueId));
                    fXmlNodeTmgl.set_attrVal(FXmlTagTMGL.A_TcpSessionName, FXmlTagTMGL.D_TcpSessionName, fXmlNodeTsn.get_attrVal(FXmlTagTSN.A_Name, FXmlTagTSN.D_Name));
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

        public static FXmlNode[] parseConnectionTrigger(
            FTcpDriver fTcd,
            FXmlNode fXmlNodeDvcl,
            FDeviceState fDeviceState
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
                " @" + FXmlTagTCN.A_ConnectionState + "='{2}']";

            // --

            FXmlNodeList fXmlNodeListTcn = null;
            FXmlNode fXmlNodeTtr = null;
            string xpath = string.Empty;
            HashSet<string> ttrKeys = null;
            List<FXmlNode> ttrList = null;
            string ttrUniqueId = string.Empty;

            try
            {
                xpath = string.Format(
                    TcpConditionQuery,
                    FEnumConverter.fromConditionMode(FConditionMode.Connection),
                    fXmlNodeDvcl.get_attrVal(FXmlTagTDV.A_UniqueId, FXmlTagTDV.D_UniqueId),
                    FEnumConverter.fromDeviceState(fDeviceState)
                    );
                fXmlNodeListTcn = fTcd.fXmlNode.selectNodes(xpath);

                // --

                ttrKeys = new HashSet<string>();
                ttrList = new List<FXmlNode>();
                // --
                foreach (FXmlNode fXmlNodeTcn in fXmlNodeListTcn)
                {
                    // ***
                    // 중복 조건 검사
                    // ***
                    fXmlNodeTtr = fXmlNodeTcn.fParentNode;
                    ttrUniqueId = fXmlNodeTtr.get_attrVal(FXmlTagTTR.A_UniqueId, FXmlTagTTR.D_UniqueId);
                    if (ttrKeys.Contains(ttrUniqueId))
                    {
                        continue;
                    }

                    // --

                    ttrList.Add(fXmlNodeTtr);
                    ttrKeys.Add(ttrUniqueId);
                }

                // --

                return ttrList.ToArray();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListTcn = null;
                fXmlNodeTtr = null;
                ttrKeys = null;
                ttrList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode[] parseExpressionTrigger(
            FTcpDriver fTcd,
            FXmlNode fXmlNodeTmgl
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
                " @" + FXmlTagTCN.A_TcpSessionId + "='{2}' and" +
                " @" + FXmlTagTCN.A_TcpMessageId + "='{3}']";

            // --

            FXmlNodeList fXmlNodeListTcn = null;
            FXmlNodeList fXmlNodeListTep = null;
            FXmlNode fXmlNodeTtr = null;
            bool result = false;
            string xpath = string.Empty;
            HashSet<string> ttrKeys = null;
            ArrayList ttrList = null;
            string ttrUniqueId = string.Empty;

            try
            {
                xpath = string.Format(
                    TcpConditionQuery,
                    FEnumConverter.fromConditionMode(FConditionMode.Expression),
                    fXmlNodeTmgl.get_attrVal(FXmlTagTMGL.A_TcpDeviceId, FXmlTagTMGL.D_TcpDeviceId),
                    fXmlNodeTmgl.get_attrVal(FXmlTagTMGL.A_TcpSessionId, FXmlTagTMGL.D_TcpSessionId),
                    fXmlNodeTmgl.get_attrVal(FXmlTagTMGL.A_UniqueId, FXmlTagTMGL.D_UniqueId)
                    );
                fXmlNodeListTcn = fTcd.fXmlNode.selectNodes(xpath);

                // --

                ttrKeys = new HashSet<string>();
                ttrList = new ArrayList();
                // --
                foreach (FXmlNode fXmlNodeTcn in fXmlNodeListTcn)
                {
                    // ***
                    // 중복 조건 검색
                    // ***
                    fXmlNodeTtr = fXmlNodeTcn.fParentNode;
                    ttrUniqueId = fXmlNodeTtr.get_attrVal(FXmlTagTTR.A_UniqueId, FXmlTagTTR.D_UniqueId);
                    if (ttrKeys.Contains(ttrUniqueId))
                    {
                        continue;
                    }

                    // --

                    result = true;
                    fXmlNodeListTep = fXmlNodeTcn.selectNodes(FXmlTagTEP.E_TcpExpression);
                    foreach (FXmlNode fXmlNodeTep in fXmlNodeListTep)
                    {
                        compareCondition(fTcd, fXmlNodeTmgl, fXmlNodeTep, ref result);
                    }

                    if (result)
                    {
                        ttrList.Add(fXmlNodeTtr);
                        ttrKeys.Add(ttrUniqueId);
                    }
                }

                // --

                return (FXmlNode[])ttrList.ToArray(typeof(FXmlNode));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListTcn = null;
                fXmlNodeListTep = null;
                fXmlNodeTtr = null;
                ttrKeys = null;
                ttrList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode[] parseTimeoutTrigger(
            FTcpDriver fTcd,
            FXmlNode fXmlNodeTmgl,
            ref FXmlNode fXmlNodeRetryTcn
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
                " @" + FXmlTagTCN.A_TcpSessionId + "='{2}' and" +
                " @" + FXmlTagTCN.A_TcpMessageId + "='{3}']";

            // --

            FXmlNodeList fXmlNodeListTcn = null;
            FXmlNode fXmlNodeTtr = null;
            HashSet<string> ttrKeys = null;
            ArrayList ttrList = null;
            string ttrUniqueId = string.Empty;
            string xpath = string.Empty;

            try
            {
                xpath = string.Format(
                    TcpConditionQuery,
                    FEnumConverter.fromConditionMode(FConditionMode.Timeout),
                    fXmlNodeTmgl.get_attrVal(FXmlTagTMGL.A_TcpDeviceId, FXmlTagTMGL.D_TcpDeviceId),
                    fXmlNodeTmgl.get_attrVal(FXmlTagTMGL.A_TcpSessionId, FXmlTagTMGL.D_TcpSessionId),
                    fXmlNodeTmgl.get_attrVal(FXmlTagTMGL.A_UniqueId, FXmlTagTMGL.D_UniqueId)
                    );
                fXmlNodeListTcn = fTcd.fXmlNode.selectNodes(xpath);

                // --

                ttrKeys = new HashSet<string>();
                ttrList = new ArrayList();
                // --
                foreach (FXmlNode fXmlNodeTcn in fXmlNodeListTcn)
                {
                    // ***
                    // 첫번째 Retry Limit가 설정되어 있는 Condition 검색
                    // ***
                    if (fXmlNodeRetryTcn == null)
                    {
                        if (fXmlNodeTcn.get_attrVal(FXmlTagTCN.A_RetryLimit, FXmlTagTCN.D_RetryLimit) != "0")
                        {
                            fXmlNodeRetryTcn = fXmlNodeTcn;
                        }
                    }

                    // --

                    // ***
                    // 중복 조건 검사
                    // ***
                    fXmlNodeTtr = fXmlNodeTcn.fParentNode;
                    ttrUniqueId = fXmlNodeTtr.get_attrVal(FXmlTagTTR.A_UniqueId, FXmlTagTTR.D_UniqueId);
                    if (ttrKeys.Contains(ttrUniqueId))
                    {
                        continue;
                    }

                    // --

                    ttrList.Add(fXmlNodeTtr);
                    ttrKeys.Add(ttrUniqueId);
                }

                // --

                return (FXmlNode[])ttrList.ToArray(typeof(FXmlNode));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListTcn = null;
                ttrKeys = null;
                ttrList = null;
                fXmlNodeTtr = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static void compareCondition(
            FTcpDriver fTcd,
            FXmlNode fXmlNodeTmgl,
            FXmlNode fXmlNodeTep,
            ref bool oldResult
            )
        {
            const string TcpItemLogQuery = ".//" + FXmlTagTITL.E_TcpItem + "[@" + FXmlTagTITL.A_UniqueId + "='{0}']";
            // --
            const string EnvironmentQuery =
                FXmlTagSET.E_Setup +
                "/" + FXmlTagEND.E_EnvironmentDefinition +
                "/" + FXmlTagENL.E_EnvironmentList +
                "//" + FXmlTagENV.E_Environment + "[@" + FXmlTagENV.A_UniqueId + "='{0}']";
            // --
            const string EquipmentStateQuery =
                FXmlTagSET.E_Setup +
                "/" + FXmlTagESD.E_EquipmentStateSetDefinition +
                "/" + FXmlTagESL.E_EquipmentStateSetList +
                "/" + FXmlTagESS.E_EquipmentStateSet +
                "/" + FXmlTagEST.E_EquipmentState + "[@" + FXmlTagEST.A_UniqueId + "='{0}']";

            // --

            FXmlNodeList fXmlNodeListChild = null;
            FXmlNodeList fXmlNodeListOpe = null;
            FXmlNode fXmlNodeOpe = null;
            FXmlNode fXmlNodeEq = null;
            string operandUniqueId = string.Empty;
            int operandIndex = 0;
            FFormat fOperandFormat = FFormat.Ascii;
            FOperation fOperation = FOperation.Equal;
            FLogical fLogical = FLogical.And;
            FExpressionType fExpressionType = FExpressionType.Bracket;
            FComparisonMode fComparisonMode = FComparisonMode.Value;
            FTcpOperandType fOperandType = FTcpOperandType.TcpItem;
            FExpressionValueType fExpressionValueType = FExpressionValueType.Value;
            FTcpResourceSourceType fResourceSourceType = FTcpResourceSourceType.None;
            FEquipmentStateMaterial fEquipmentStateMaterial = null;
            string operandValue = string.Empty;
            int operandValueLength = 0;
            string value = string.Empty;
            string eqUniqueId = string.Empty;
            int length = 0;
            object oVal1 = null;
            object oVal2 = null;
            bool newResult = false;

            try
            {
                fExpressionType = FEnumConverter.toExpressionType(fXmlNodeTep.get_attrVal(FXmlTagTEP.A_ExpressionType, FXmlTagTEP.D_ExpressionType));
                fLogical = FEnumConverter.toLogical(fXmlNodeTep.get_attrVal(FXmlTagTEP.A_Logical, FXmlTagTEP.D_Logical));

                // --

                if (fExpressionType == FExpressionType.Bracket)
                {
                    newResult = true;
                    fXmlNodeListChild = fXmlNodeTep.selectNodes(FXmlTagTEP.E_TcpExpression);
                    foreach (FXmlNode fXmlNodeChild in fXmlNodeListChild)
                    {
                        compareCondition(fTcd, fXmlNodeTmgl, fXmlNodeChild, ref newResult);
                    }
                    oldResult = compareResult(fLogical, oldResult, newResult);
                    return;
                }

                // --

                // ***
                // Operand가 존재하지 않을 경우 False 설정
                // ***
                operandUniqueId = fXmlNodeTep.get_attrVal(FXmlTagTEP.A_OperandId, FXmlTagTEP.D_OperandId);
                if (operandUniqueId == string.Empty)
                {
                    oldResult = compareResult(fLogical, oldResult, false);
                    return;
                }

                // --

                fComparisonMode = FEnumConverter.toComparisonMode(fXmlNodeTep.get_attrVal(FXmlTagTEP.A_ComparisonMode, FXmlTagTEP.D_ComparisonMode));
                operandIndex = int.Parse(fXmlNodeTep.get_attrVal(FXmlTagTEP.A_OperandIndex, FXmlTagTEP.D_OperandIndex));
                fOperation = FEnumConverter.toOperation(fXmlNodeTep.get_attrVal(FXmlTagTEP.A_Operation, FXmlTagTEP.D_Operation));
                fOperandType = FEnumConverter.toTcpOperandType(fXmlNodeTep.get_attrVal(FXmlTagTEP.A_OperandType, FXmlTagTEP.D_OperandType));
                fOperandFormat = FEnumConverter.toFormat(fXmlNodeTep.get_attrVal(FXmlTagTEP.A_OperandFormat, FXmlTagTEP.D_OperandFormat));
                fExpressionValueType = FEnumConverter.toExpressionValueType(fXmlNodeTep.get_attrVal(FXmlTagTEP.A_ExpressionValueType, FXmlTagTEP.D_ExpressionValueType));

                // --

                // ***
                // Operand Length는 Ascii 계열이외에만 사용되고 Operand Length는 0 또는 1만을 가질수 있기 때문에
                // 값이 존재하지 않을 경우 0처리하고 값이 존재할 경우 1처리한다.
                // Operand Format이 Ascii 계열인 경우 Operand Length를 사용하지 않는다.
                // ***
                if (fExpressionValueType == FExpressionValueType.Value)
                {
                    operandValue = fXmlNodeTep.get_attrVal(FXmlTagTEP.A_Value, FXmlTagTEP.D_Value);
                }
                else
                {
                    fResourceSourceType = FEnumConverter.toTcpResourceSourceType(fXmlNodeTep.get_attrVal(FXmlTagTEP.A_Resource, FXmlTagTEP.D_Resource));

                    // --

                    if (fResourceSourceType == FTcpResourceSourceType.EapName)
                    {
                        operandValue = fTcd.eapName;
                    }
                    else if (fResourceSourceType == FTcpResourceSourceType.EquipmentName)
                    {
                        fXmlNodeEq = fXmlNodeTep.fParentNode.fParentNode.fParentNode.fParentNode.fParentNode;
                        operandValue = fXmlNodeEq.get_attrVal(FXmlTagEQP.A_Name, FXmlTagEQP.D_Name);
                    }
                    else if (fResourceSourceType == FTcpResourceSourceType.TcpDeviceName)
                    {
                        operandValue = fXmlNodeTmgl.get_attrVal(FXmlTagTMGL.A_TcpDeviceName, FXmlTagTMGL.D_TcpDeviceName);
                    }
                    else if (fResourceSourceType == FTcpResourceSourceType.TcpSessionName)
                    {
                        operandValue = fXmlNodeTmgl.get_attrVal(FXmlTagTMGL.A_TcpSessionName, FXmlTagTMGL.D_TcpSessionName);
                    }
                    else if (fResourceSourceType == FTcpResourceSourceType.TcpSessionId)
                    {
                        operandValue = fXmlNodeTmgl.get_attrVal(FXmlTagTMGL.A_TcpSessionId, FXmlTagTMGL.D_TcpSessionId);
                    }
                    else
                    {
                        operandValue = string.Empty;
                    }
                }

                operandValueLength = (operandValue == string.Empty ? 0 : 1);

                // --

                if (fOperandType == FTcpOperandType.TcpItem)
                {
                    // ***
                    // Operand가 존재하지 않을 경우 False 설정
                    // ***
                    fXmlNodeListOpe = fXmlNodeTmgl.selectNodes(string.Format(TcpItemLogQuery, operandUniqueId));
                    if (operandIndex >= fXmlNodeListOpe.count)
                    {
                        oldResult = compareResult(fLogical, oldResult, false);
                        return;
                    }

                    // --

                    fXmlNodeOpe = fXmlNodeListOpe[operandIndex];
                    length = int.Parse(fXmlNodeOpe.get_attrVal(FXmlTagTITL.A_Length, FXmlTagTITL.D_Length));
                    value = FValueConverter.toDataConversionStringValue(
                        fOperandFormat,
                        fXmlNodeOpe.get_attrVal(FXmlTagTITL.A_Value, FXmlTagTITL.D_Value),
                        fXmlNodeOpe.get_attrVal(FXmlTagTITL.A_Transformer, FXmlTagTITL.D_Transformer),
                        fXmlNodeOpe.get_attrVal(FXmlTagTITL.A_DataConversionSetExpression, FXmlTagTITL.D_DataConversionSetExpression),
                        ref length
                        );
                }
                else if (fOperandType == FTcpOperandType.Environment)
                {
                    // ***
                    // Operand가 존재하지 않을 경우 False 설정
                    // ***
                    fXmlNodeListOpe = fTcd.fXmlNode.selectNodes(string.Format(EnvironmentQuery, operandUniqueId));
                    if (operandIndex >= fXmlNodeListOpe.count)
                    {
                        oldResult = compareResult(fLogical, oldResult, false);
                        return;
                    }

                    // --

                    fXmlNodeOpe = fXmlNodeListOpe[operandIndex];
                    length = int.Parse(fXmlNodeOpe.get_attrVal(FXmlTagENV.A_Length, FXmlTagENV.D_Length));
                    value = fXmlNodeOpe.get_attrVal(FXmlTagENV.A_Value, FXmlTagENV.D_Value);
                }
                else if (fOperandType == FTcpOperandType.EquipmentState)
                {
                    // ***
                    // Operand가 존재하지 않을 경우 False 설정
                    // ***
                    fXmlNodeListOpe = fTcd.fXmlNode.selectNodes(string.Format(EquipmentStateQuery, operandUniqueId));
                    if (operandIndex >= fXmlNodeListOpe.count)
                    {
                        oldResult = compareResult(fLogical, oldResult, false);
                        return;
                    }

                    // --

                    fXmlNodeEq = fXmlNodeTep.fParentNode.fParentNode.fParentNode.fParentNode.fParentNode;
                    eqUniqueId = fXmlNodeEq.get_attrVal(FXmlTagEQP.A_UniqueId, FXmlTagEQP.D_UniqueId);

                    // --

                    fEquipmentStateMaterial = fTcd.fEquipmentStateMaterialStorage.getEquipmentStateMaterial(
                        eqUniqueId,
                        operandUniqueId
                        );
                    if (fEquipmentStateMaterial == null)
                    {
                        oldResult = compareResult(fLogical, oldResult, false);
                        return;
                    }

                    // --

                    length = 1;
                    value = fEquipmentStateMaterial.stateValue;
                }

                // --

                // ***
                // TCP Expression Transformer 적용
                // ***
                value = FValueConverter.toDataConversionStringValue(
                    fOperandFormat,
                    value,
                    fXmlNodeTep.get_attrVal(FXmlTagTEP.A_Transformer, FXmlTagTEP.D_Transformer),
                    fXmlNodeTep.get_attrVal(FXmlTagTEP.A_DataConversionSetExpression, FXmlTagTEP.D_DataConversionSetExpression),
                    ref length
                    );

                // --

                if (fComparisonMode == FComparisonMode.Value)
                {
                    if (fOperandFormat == FFormat.Ascii || fOperandFormat == FFormat.A2 || fOperandFormat == FFormat.JIS8)
                    {
                        if (fOperation == FOperation.Equal)
                        {
                            newResult = (string.Compare(value, operandValue) == 0 ? true : false);
                        }
                        else if (fOperation == FOperation.NotEqual)
                        {
                            newResult = (string.Compare(value, operandValue) != 0 ? true : false);
                        }
                        else if (fOperation == FOperation.MoreThan)
                        {
                            newResult = (string.Compare(value, operandValue) > 0 ? true : false);
                        }
                        else if (fOperation == FOperation.MoreThanOrEqual)
                        {
                            newResult = (string.Compare(value, operandValue) >= 0 ? true : false);
                        }
                        else if (fOperation == FOperation.LessThan)
                        {
                            newResult = (string.Compare(value, operandValue) < 0 ? true : false);
                        }
                        else if (fOperation == FOperation.LessThanOrEqual)
                        {
                            newResult = (string.Compare(value, operandValue) <= 0 ? true : false);
                        }
                    }
                    else
                    {
                        if (length > 1)
                        {
                            // ***
                            // Ascii 계열이 아니고 Length가 1 보다 클 경우 False 처리
                            // ***
                            newResult = false;
                        }
                        else if (length == 0)
                        {
                            if (operandValueLength > 1)
                            {
                                newResult = false;
                            }
                            else if (operandValueLength == 0)
                            {
                                if (
                                    fOperation == FOperation.Equal ||
                                    fOperation == FOperation.MoreThanOrEqual ||
                                    fOperation == FOperation.LessThanOrEqual
                                    )
                                {
                                    newResult = true;
                                }
                                else
                                {
                                    newResult = false;
                                }
                            }
                            else
                            {
                                if (
                                    fOperation == FOperation.NotEqual ||
                                    fOperation == FOperation.LessThan ||
                                    fOperation == FOperation.LessThanOrEqual
                                    )
                                {
                                    newResult = true;
                                }
                                else
                                {
                                    newResult = false;
                                }
                            }
                        }
                        else
                        {
                            oVal1 = FValueConverter.toValue(fOperandFormat, value);

                            // --

                            if (operandValueLength > 1)
                            {
                                newResult = false;
                            }
                            else if (operandValueLength == 0)
                            {
                                if (
                                    fOperation == FOperation.NotEqual ||
                                    fOperation == FOperation.MoreThan ||
                                    fOperation == FOperation.MoreThanOrEqual
                                    )
                                {
                                    newResult = true;
                                }
                                else
                                {
                                    newResult = false;
                                }
                            }
                            else
                            {
                                oVal2 = FValueConverter.toValue(fOperandFormat, operandValue);

                                // --

                                if (fOperandFormat == FFormat.Binary)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((byte)oVal1 == (byte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((byte)oVal1 != (byte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((byte)oVal1 > (byte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((byte)oVal1 >= (byte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((byte)oVal1 < (byte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((byte)oVal1 <= (byte)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.Boolean)
                                {
                                    if (
                                        fOperation == FOperation.Equal ||
                                        fOperation == FOperation.MoreThanOrEqual ||
                                        fOperation == FOperation.LessThanOrEqual
                                        )
                                    {
                                        newResult = ((bool)oVal1 == (bool)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((bool)oVal1 != (bool)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.I8)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((Int64)oVal1 == (Int64)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((Int64)oVal1 != (Int64)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((Int64)oVal1 > (Int64)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((Int64)oVal1 >= (Int64)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((Int64)oVal1 < (Int64)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((Int64)oVal1 <= (Int64)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.I4)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((Int32)oVal1 == (Int32)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((Int32)oVal1 != (Int32)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((Int32)oVal1 > (Int32)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((Int32)oVal1 >= (Int32)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((Int32)oVal1 < (Int32)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((Int32)oVal1 <= (Int32)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.I2)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((Int16)oVal1 == (Int16)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((Int16)oVal1 != (Int16)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((Int16)oVal1 > (Int16)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((Int16)oVal1 >= (Int16)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((Int16)oVal1 < (Int16)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((Int16)oVal1 <= (Int16)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.I1)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((sbyte)oVal1 == (sbyte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((sbyte)oVal1 != (sbyte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((sbyte)oVal1 > (sbyte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((sbyte)oVal1 >= (sbyte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((sbyte)oVal1 < (sbyte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((sbyte)oVal1 <= (sbyte)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.F8)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((Double)oVal1 == (Double)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((Double)oVal1 != (Double)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((Double)oVal1 > (Double)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((Double)oVal1 >= (Double)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((Double)oVal1 < (Double)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((Double)oVal1 <= (Double)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.F4)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((Single)oVal1 == (Single)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((Single)oVal1 != (Single)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((Single)oVal1 > (Single)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((Single)oVal1 >= (Single)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((Single)oVal1 < (Single)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((Single)oVal1 <= (Single)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.U8)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((UInt64)oVal1 == (UInt64)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((UInt64)oVal1 != (UInt64)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((UInt64)oVal1 > (UInt64)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((UInt64)oVal1 >= (UInt64)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((UInt64)oVal1 < (UInt64)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((UInt64)oVal1 <= (UInt64)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.U4)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((UInt32)oVal1 == (UInt32)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((UInt32)oVal1 != (UInt32)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((UInt32)oVal1 > (UInt32)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((UInt32)oVal1 >= (UInt32)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((UInt32)oVal1 < (UInt32)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((UInt32)oVal1 <= (UInt32)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.U2)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((UInt16)oVal1 == (UInt16)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((UInt16)oVal1 != (UInt16)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((UInt16)oVal1 > (UInt16)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((UInt16)oVal1 >= (UInt16)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((UInt16)oVal1 < (UInt16)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((UInt16)oVal1 <= (UInt16)oVal2 ? true : false);
                                    }
                                }
                                else if (fOperandFormat == FFormat.U1)
                                {
                                    if (fOperation == FOperation.Equal)
                                    {
                                        newResult = ((byte)oVal1 == (byte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.NotEqual)
                                    {
                                        newResult = ((byte)oVal1 != (byte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThan)
                                    {
                                        newResult = ((byte)oVal1 > (byte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.MoreThanOrEqual)
                                    {
                                        newResult = ((byte)oVal1 >= (byte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThan)
                                    {
                                        newResult = ((byte)oVal1 < (byte)oVal2 ? true : false);
                                    }
                                    else if (fOperation == FOperation.LessThanOrEqual)
                                    {
                                        newResult = ((byte)oVal1 <= (byte)oVal2 ? true : false);
                                    }
                                }
                            }
                        }   // length compare end
                    }   // ascii or no ascii if end                          
                }
                else
                {
                    if (fOperation == FOperation.Equal)
                    {
                        newResult = (length == operandValueLength ? true : false);
                    }
                    else if (fOperation == FOperation.NotEqual)
                    {
                        newResult = (length != operandValueLength ? true : false);
                    }
                    else if (fOperation == FOperation.MoreThan)
                    {
                        newResult = (length < operandValueLength ? true : false);
                    }
                    else if (fOperation == FOperation.MoreThanOrEqual)
                    {
                        newResult = (length <= operandValueLength ? true : false);
                    }
                    else if (fOperation == FOperation.LessThan)
                    {
                        newResult = (length > operandValueLength ? true : false);
                    }
                    else if (fOperation == FOperation.LessThanOrEqual)
                    {
                        newResult = (length >= operandValueLength ? true : false);
                    }
                }   // comparison if end

                // --

                oldResult = compareResult(fLogical, oldResult, newResult);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListChild = null;
                fXmlNodeListOpe = null;
                fXmlNodeOpe = null;
                fXmlNodeEq = null;
                fEquipmentStateMaterial = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static bool compareResult(
            FLogical fLogical,
            bool oldResult,
            bool newResult
            )
        {
            try
            {
                if (fLogical == FLogical.And)
                {
                    return oldResult & newResult;
                }
                return oldResult | newResult;
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

        public static FXmlNode parseMsgToTmg(
            FTcpDriver fTcd,
            FTcpDevice fTdv,
            FXmlNode fXmlNodeTsn,
            string sessionName,
            int sessionId,
            string command,
            UInt32 tid,
            FXmlNode fXmlNodeMsg,
            UInt32 length,
            ref FResultCode fResultCode,
            ref string resultMessage,
            ref FXmlNode fXmlNodeTmg
            )
        {
            const string TcpMessageQuery =
                FXmlTagTLM.E_TcpLibraryModeling +
                "/" + FXmlTagTLG.E_TcpLibraryGroup +
                "/" + FXmlTagTLB.E_TcpLibrary + "[@" + FXmlTagTLB.A_UniqueId + "='{0}']" +
                "/" + FXmlTagTML.E_TcpMessageList +
                "/" + FXmlTagTMS.E_TcpMessages +
                "/" + FXmlTagTMG.E_TcpMessage + "[@" + FXmlTagTMG.A_Command + "='{1}']";

            // --

            FXmlNodeList fXmlNodeListTmg = null;
            FXmlNode fXmlNodeTmgl = null;
            FTcpMessageType fTcpMessageType = FTcpMessageType.Command;
            FDirection fDirection = FDirection.Both;
            string xpath = string.Empty;

            try
            {
                if (fXmlNodeTsn == null || fResultCode != FResultCode.Success)
                {
                    // ***
                    // Session이 존재하지 않을 경우 Message를 Generate하고 Warning 처리
                    // ***
                    fXmlNodeTmgl = FTcpDriverLogCommon.createXmlNodeTMGL(fTcd.fTcdCore.fXmlDoc);
                    setTcpMessageLogInfo(
                        fXmlNodeTmgl,
                        fTdv.fXmlNode,
                        fXmlNodeTsn,
                        sessionName,
                        sessionId,
                        command,
                        0,
                        FTcpMessageType.Unsolicited,
                        tid,
                        length
                        );
                    fXmlNodeTmgl.set_attrVal(FXmlTagTMGL.A_Name, FXmlTagTMGL.D_Name, "Undefined");

                    // --

                    // ***
                    // 기본 메시지의 XML 구조가 잘 못 되었을 경우 오류 처리
                    // ***
                    if (fResultCode != FResultCode.Success)
                    {
                        if (fXmlNodeMsg != null)
                        {
                            generateMsgToTmg(fTcd.fTcdCore.fXmlDoc, fXmlNodeTmgl, fXmlNodeMsg);
                        }
                        return fXmlNodeTmgl;
                    }

                    // --

                    generateMsgToTmg(fTcd.fTcdCore.fXmlDoc, fXmlNodeTmgl, fXmlNodeMsg);
                    // --
                    fResultCode = FResultCode.Warninig;
                    resultMessage = string.Format(FConstants.err_m_0028, "Session");
                    // --
                    return fXmlNodeTmgl;
                }

                // --

                // ***
                // Parsing를 위한 모델링 TcpMessage 검색
                // ***
                xpath = string.Format(
                    TcpMessageQuery,
                    fXmlNodeTsn.get_attrVal(FXmlTagTSN.A_TcpLibraryId, FXmlTagTSN.D_TcpLibraryId),
                    command
                    );
                // --
                fXmlNodeListTmg = fTcd.fXmlNode.selectNodes(xpath);
                // --
                foreach (FXmlNode x in fXmlNodeListTmg)
                {
                    fDirection = FEnumConverter.toDirection(
                        x.fParentNode.get_attrVal(FXmlTagTMS.A_Direction, FXmlTagTMS.D_Direction)
                        );
                    fTcpMessageType = FEnumConverter.toTcpMessageType(
                        x.get_attrVal(FXmlTagTMG.A_TcpMessageType, FXmlTagTMG.D_TcpMessageType)
                        );
                    // --                   
                    if (fTdv.fDeviceMode == FDeviceMode.Equipment)
                    {
                        if (fDirection == FDirection.Equipment)
                        {
                            if (fTcpMessageType != FTcpMessageType.Reply)
                            {
                                continue;
                            }
                        }
                        else if (fDirection == FDirection.Host)
                        {
                            if (fTcpMessageType == FTcpMessageType.Reply)
                            {
                                continue;
                            }
                        }
                    }
                    else if (fTdv.fDeviceMode == FDeviceMode.Host)
                    {
                        if (fDirection == FDirection.Equipment)
                        {
                            if (fTcpMessageType == FTcpMessageType.Reply)
                            {
                                continue;
                            }
                        }
                        else if (fDirection == FDirection.Host)
                        {
                            if (fTcpMessageType != FTcpMessageType.Reply)
                            {
                                continue;
                            }
                        }
                    }

                    // --

                    if (compareMsgWithSmg(x, fXmlNodeMsg))
                    {
                        fXmlNodeTmgl = x.clone(true);
                        break;
                    }
                }

                // --

                // ***
                // Not Define Message
                // ***
                if (fXmlNodeTmgl == null)
                {
                    fXmlNodeTmgl = FTcpDriverLogCommon.createXmlNodeTMGL(fTcd.fTcdCore.fXmlDoc);
                    setTcpMessageLogInfo(
                        fXmlNodeTmgl,
                        fTdv.fXmlNode,
                        fXmlNodeTsn,
                        sessionName,
                        sessionId,
                        command,
                        0,
                        FTcpMessageType.Unsolicited,
                        tid,
                        length
                        );
                    fXmlNodeTmgl.set_attrVal(FXmlTagTMGL.A_Name, FXmlTagTMGL.D_Name, "Undefined");
                    // --
                    generateMsgToTmg(fTcd.fTcdCore.fXmlDoc, fXmlNodeTmgl, fXmlNodeMsg);
                    // --
                    fResultCode = FResultCode.Warninig;
                    resultMessage = string.Format(FConstants.err_m_0028, "Message");
                    // --
                    return fXmlNodeTmgl;
                }

                // --

                setTcpMessageLogInfo(fXmlNodeTmgl, fTdv.fXmlNode, fXmlNodeTsn, sessionName, sessionId, tid, length);
                // --
                parseMsgToTit(
                    fXmlNodeTmgl,
                    fXmlNodeTmgl.selectNodes(FXmlTagTIT.E_TcpItem),
                    fXmlNodeMsg.fChildNodes
                    );

                // --

                fResultCode = FResultCode.Success;
                return fXmlNodeTmgl;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListTmg = null;
                fXmlNodeTmgl = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static void parseMsgToTit(
            FXmlNode fXmlNodeParent,
            FXmlNodeList fXmlNodeListTit,
            FXmlNodeList fXmlNodeListItem
            )
        {
            FXmlNode fXmlNodeTit = null;
            FXmlNode fXmlNodeTitCalc = null;
            FXmlNode fXmlNodeTitC = null;
            FXmlNode fXmlNodeTitChild = null;
            FXmlNode fXmlNodeItem = null;
            FXmlNodeList fXmlNodeListItemChild = null;
            int titLen = 0;
            int titIndex = 0;
            int titFixLen = 0;
            int titVarLen = 0;
            int titVarCnt = 0;
            int itemLen = 0;
            int itemIndex = 0;
            FFormat fItemFormat = FFormat.Unknown;
            FFormat fTitFormat = FFormat.Unknown;
            FPattern fTitPattern = FPattern.Fixed;
            string titName = string.Empty;
            string itemValue = string.Empty;
            int rawBytes = 0;
            string value = string.Empty;
            int length = 0;
            FXmlNode[] fXmlNodeArr = null;
            string genName = string.Empty;

            try
            {
                titLen = fXmlNodeListTit.count;
                itemLen = fXmlNodeListItem.count;
                // --
                if (titLen == 0)
                {
                    return;
                }

                // --

                while (titIndex < titLen)
                {
                    titFixLen = 0;
                    titVarLen = 0;
                    titVarCnt = 0;

                    // --

                    fXmlNodeTit = fXmlNodeListTit[titIndex];
                    fTitPattern = FEnumConverter.toPattern(fXmlNodeTit.get_attrVal(FXmlTagTIT.A_Pattern, FXmlTagTIT.D_Pattern));

                    // --

                    if (fTitPattern == FPattern.Fixed)
                    {
                        #region Fixed TcpItem Parse

                        titFixLen = int.Parse(fXmlNodeTit.get_attrVal(FXmlTagTIT.A_FixedLength, FXmlTagTIT.D_FixedLength));
                        fTitFormat = FEnumConverter.toFormat(fXmlNodeTit.get_attrVal(FXmlTagTIT.A_Format, FXmlTagTIT.D_Format));

                        // --

                        for (int i = 0; i < titFixLen; i++)
                        {
                            fXmlNodeItem = fXmlNodeListItem[itemIndex + i];
                            fItemFormat = getMessageItemFormat(fXmlNodeItem);
                            // --
                            if (i == 0)
                            {
                                fXmlNodeArr = new FXmlNode[1] { fXmlNodeTit.clone(true) };
                            }
                            else
                            {
                                fXmlNodeTit = fXmlNodeParent.insertAfter(fXmlNodeArr[0].clone(true), fXmlNodeTit);
                            }
                            // --
                            fXmlNodeTit.set_attrVal(FXmlTagTIT.A_FixedLength, FXmlTagTIT.D_FixedLength, "1");

                            // --

                            if (fTitFormat == FFormat.Raw)
                            {
                                rawBytes = calculateMsgToRawBytes(fXmlNodeItem);
                                // --
                                fXmlNodeTit.set_attrVal(FXmlTagTIT.A_Length, FXmlTagTIT.D_Length, rawBytes.ToString());
                            }
                            else if (fTitFormat == FFormat.Unknown)
                            {
                                if (fItemFormat == FFormat.List)
                                {
                                    // ***
                                    // 2017.03.23 by spike.lee
                                    // Unknown Format Item 하위 Item이 동일 이름으로 생성되어 DataSet에서 원하는 구조로 Parsing 할 수 없어 이름을
                                    // 다르게 생성하도록 처리
                                    genName = fXmlNodeTit.get_attrVal(FXmlTagTIT.A_Name, FXmlTagTIT.D_Name) + "_n";
                                    fXmlNodeTitC = fXmlNodeTit.clone(false);
                                    fXmlNodeTitC.set_attrVal(FXmlTagTIT.A_FixedLength, FXmlTagTIT.D_FixedLength, "1");
                                    fXmlNodeListItemChild = fXmlNodeItem.fChildNodes;
                                    for (int j = 0; j < fXmlNodeListItemChild.count; j++)
                                    {
                                        fXmlNodeTitChild = fXmlNodeTitC.clone(false);
                                        fXmlNodeTitChild.set_attrVal(FXmlTagTIT.A_Name, FXmlTagTIT.D_Name, genName);
                                        fXmlNodeTit.appendChild(fXmlNodeTitChild);
                                    }
                                    // --
                                    parseMsgToTit(
                                        fXmlNodeTit,
                                        fXmlNodeTit.selectNodes(FXmlTagTIT.E_TcpItem),
                                        fXmlNodeListItemChild
                                        );
                                    // --
                                    fXmlNodeTit.set_attrVal(FXmlTagTIT.A_Format, FXmlTagTIT.D_Format, FEnumConverter.fromFormat(fItemFormat));
                                    fXmlNodeTit.set_attrVal(FXmlTagTIT.A_Length, FXmlTagTIT.D_Length, fXmlNodeListItem.count.ToString());
                                }
                                else
                                {
                                    value = FValueConverter.fromStringValue(
                                        fItemFormat,
                                        convertMsgItemValue(fXmlNodeItem.innerText),
                                        out length
                                        );
                                    // --
                                    fXmlNodeTit.set_attrVal(FXmlTagTIT.A_Format, FXmlTagTIT.D_Format, FEnumConverter.fromFormat(fItemFormat));
                                    fXmlNodeTit.set_attrVal(FXmlTagTIT.A_Length, FXmlTagTIT.D_Length, length.ToString());
                                    fXmlNodeTit.set_attrVal(FXmlTagTIT.A_Value, FXmlTagTIT.D_Value, value);
                                }
                            }
                            else
                            {
                                if (fItemFormat == FFormat.List)
                                {
                                    fXmlNodeListItemChild = fXmlNodeItem.fChildNodes;
                                    // --
                                    parseMsgToTit(
                                        fXmlNodeTit,
                                        fXmlNodeTit.selectNodes(FXmlTagTIT.E_TcpItem),
                                        fXmlNodeListItemChild
                                        );
                                    // --
                                    fXmlNodeTit.set_attrVal(
                                        FXmlTagHIT.A_Length,
                                        FXmlTagHIT.D_Length,
                                        fXmlNodeListItemChild.count.ToString()
                                        );
                                }
                                else
                                {
                                    value = FValueConverter.fromStringValue(
                                        fItemFormat,
                                        convertMsgItemValue(fXmlNodeItem.innerText),
                                        out length
                                        );
                                    // --
                                    fXmlNodeTit.set_attrVal(FXmlTagTIT.A_Length, FXmlTagTIT.D_Length, length.ToString());
                                    fXmlNodeTit.set_attrVal(FXmlTagTIT.A_Value, FXmlTagTIT.D_Value, value);
                                }
                            }
                        }   // for i end
                        titIndex++;
                        itemIndex += titFixLen;

                        #endregion
                    }
                    else
                    {
                        #region Variable TcpItem Parse

                        // ***
                        // 하위 Variable, Fixed Item 개수 계산
                        // ***
                        for (int i = titIndex; i < titLen; i++)
                        {
                            fXmlNodeTitCalc = fXmlNodeListTit[i];
                            fTitPattern = FEnumConverter.toPattern(fXmlNodeTitCalc.get_attrVal(FXmlTagTIT.A_Pattern, FXmlTagTIT.D_Pattern));
                            // --
                            if (fTitPattern == FPattern.Variable)
                            {
                                titVarLen++;
                            }
                            else
                            {
                                titFixLen += int.Parse(fXmlNodeTitCalc.get_attrVal(FXmlTagTIT.A_FixedLength, FXmlTagTIT.D_FixedLength));
                            }
                        }

                        // --

                        // ***
                        // Variable 회수 구하기
                        // ***
                        titVarCnt = (itemLen - itemIndex - titFixLen) / titVarLen;

                        // --

                        if (titVarCnt == 0)
                        {
                            for (int i = titIndex; i < titIndex + titVarLen; i++)
                            {
                                fXmlNodeParent.removeChild(fXmlNodeListTit[i]);
                            }
                        }
                        else
                        {
                            fXmlNodeArr = new FXmlNode[titVarLen];

                            // --

                            for (int i = 0; i < titVarCnt; i++)
                            {
                                for (int j = 0; j < titVarLen; j++)
                                {
                                    if (i == 0)
                                    {
                                        fXmlNodeTit = fXmlNodeListTit[titIndex + j];
                                        fXmlNodeArr[j] = fXmlNodeTit.clone(true);
                                    }
                                    else
                                    {
                                        fXmlNodeTit = fXmlNodeParent.insertAfter(fXmlNodeArr[j].clone(true), fXmlNodeTit);
                                    }
                                    // --
                                    fXmlNodeTit.set_attrVal(FXmlTagTIT.A_Pattern, FXmlTagTIT.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));

                                    // --

                                    fTitFormat = FEnumConverter.toFormat(fXmlNodeTit.get_attrVal(FXmlTagTIT.A_Format, FXmlTagTIT.D_Format));
                                    //
                                    fXmlNodeItem = fXmlNodeListItem[itemIndex];
                                    fItemFormat = getMessageItemFormat(fXmlNodeItem);
                                    itemIndex++;

                                    // --

                                    if (fTitFormat == FFormat.Raw)
                                    {
                                        rawBytes = calculateMsgToRawBytes(fXmlNodeItem);
                                        // --
                                        fXmlNodeTit.set_attrVal(FXmlTagTIT.A_Length, FXmlTagTIT.D_Length, rawBytes.ToString());
                                    }
                                    else if (fTitFormat == FFormat.Unknown)
                                    {
                                        if (fItemFormat == FFormat.List)
                                        {
                                            // ***
                                            // 2017.03.23 by spike.lee
                                            // Unknown Format Item 하위 Item이 동일 이름으로 생성되어 DataSet에서 원하는 구조로 Parsing 할 수 없어 이름을
                                            // 다르게 생성하도록 처리
                                            genName = fXmlNodeTit.get_attrVal(FXmlTagTIT.A_Name, FXmlTagTIT.D_Name) + "_n";
                                            fXmlNodeTitC = fXmlNodeTit.clone(false);
                                            fXmlNodeTitC.set_attrVal(FXmlTagTIT.A_FixedLength, FXmlTagTIT.D_FixedLength, "1");
                                            fXmlNodeListItemChild = fXmlNodeItem.fChildNodes;
                                            for (int k = 0; k < fXmlNodeListItemChild.count; k++)
                                            {
                                                fXmlNodeTitChild = fXmlNodeTitC.clone(false);
                                                fXmlNodeTitChild.set_attrVal(FXmlTagTIT.A_Name, FXmlTagTIT.D_Name, genName);
                                                fXmlNodeTit.appendChild(fXmlNodeTitChild);
                                            }
                                            // --
                                            parseMsgToTit(
                                                fXmlNodeTit,
                                                fXmlNodeTit.selectNodes(FXmlTagTIT.E_TcpItem),
                                                fXmlNodeListItemChild
                                                );
                                            // --
                                            fXmlNodeTit.set_attrVal(FXmlTagTIT.A_Format, FXmlTagTIT.D_Format, FEnumConverter.fromFormat(fItemFormat));
                                            fXmlNodeTit.set_attrVal(FXmlTagTIT.A_Length, FXmlTagTIT.D_Length, fXmlNodeListItem.count.ToString());
                                        }
                                        else
                                        {
                                            value = FValueConverter.fromStringValue(
                                                fItemFormat,
                                                convertMsgItemValue(fXmlNodeItem.innerText),
                                                out length
                                                );
                                            // --
                                            fXmlNodeTit.set_attrVal(FXmlTagTIT.A_Format, FXmlTagTIT.D_Format, FEnumConverter.fromFormat(fItemFormat));
                                            fXmlNodeTit.set_attrVal(FXmlTagTIT.A_Length, FXmlTagTIT.D_Length, length.ToString());
                                            fXmlNodeTit.set_attrVal(FXmlTagTIT.A_Value, FXmlTagTIT.D_Value, value);
                                        }
                                    }
                                    else
                                    {
                                        if (fItemFormat == FFormat.List)
                                        {
                                            fXmlNodeListItemChild = fXmlNodeItem.fChildNodes;
                                            // --
                                            parseMsgToTit(
                                                fXmlNodeTit,
                                                fXmlNodeTit.selectNodes(FXmlTagTIT.E_TcpItem),
                                                fXmlNodeListItemChild
                                                );
                                            // --
                                            fXmlNodeTit.set_attrVal(
                                                FXmlTagHIT.A_Length,
                                                FXmlTagHIT.D_Length,
                                                fXmlNodeListItemChild.count.ToString()
                                                );
                                        }
                                        else
                                        {
                                            value = FValueConverter.fromStringValue(
                                                fItemFormat,
                                                convertMsgItemValue(fXmlNodeItem.innerText),
                                                out length
                                                );
                                            // --
                                            fXmlNodeTit.set_attrVal(FXmlTagTIT.A_Length, FXmlTagTIT.D_Length, length.ToString());
                                            fXmlNodeTit.set_attrVal(FXmlTagTIT.A_Value, FXmlTagTIT.D_Value, value);
                                        }
                                    }
                                }   // for j end
                            }   // for i end
                        }
                        titIndex += titVarLen;

                        #endregion
                    }
                }   // while titIndex end 
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeTit = null;
                fXmlNodeTitCalc = null;
                fXmlNodeTitC = null;
                fXmlNodeTitChild = null;
                fXmlNodeItem = null;
                fXmlNodeListItemChild = null;
                fXmlNodeArr = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static int calculateMsgToRawBytes(
            FXmlNode fXmlNodeItem
            )
        {
            FFormat fFormat;
            int rawBytes = 0;

            try
            {
                // ***
                // 2016.04.21 by spike.lee
                // Custom001의 RawBytes는 정확이 산정할 수 없어
                // List는 1, Ascii는 문자 길이로 산정 함.
                // ***

                // --

                fFormat = getMessageItemFormat(fXmlNodeItem);

                // --

                if (fFormat == FFormat.List)
                {
                    rawBytes = 1;
                    foreach (FXmlNode x in fXmlNodeItem.fChildNodes)
                    {
                        rawBytes += calculateMsgToRawBytes(x);
                    }
                }
                else
                {
                    rawBytes = Encoding.Default.GetByteCount(fXmlNodeItem.innerText);
                }

                // --

                return rawBytes;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return 0;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static bool compareMsgWithSmg(
            FXmlNode fXmlNodeTmg,
            FXmlNode fXmlNodeMsg
            )
        {
            FXmlNodeList fXmlNodeListTit = null;

            try
            {
                // ***
                // Header Only Message
                // ***
                fXmlNodeListTit = fXmlNodeTmg.selectNodes(FXmlTagTIT.E_TcpItem);
                if (fXmlNodeListTit.count == 0)
                {
                    return fXmlNodeMsg.hasChildNode ? false : true;
                }
                // --
                return compareMsgWithTit(fXmlNodeListTit, fXmlNodeMsg.fChildNodes);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListTit = null;
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static bool compareMsgWithTit(
            FXmlNodeList fXmlNodeListTit,
            FXmlNodeList fXmlNodeListItem
            )
        {
            FXmlNode fXmlNodeTit = null;
            FXmlNode fXmlNodeTitCalc = null;
            FXmlNode fXmlNodeItem = null;
            int titLen = 0;
            int titIndex = 0;
            int titFixLen = 0;
            int titVarLen = 0;
            int titVarCnt = 0;
            int itemLen = 0;
            int itemIndex = 0;
            FFormat fItemFormat = FFormat.Unknown;
            FFormat fTitFormat = FFormat.Unknown;
            FPattern fTitPattern = FPattern.Fixed;
            string titName = string.Empty;
            string itemValue = string.Empty;
            string preCondition = string.Empty;
            bool isPreCondition = false;

            try
            {
                titLen = fXmlNodeListTit.count;
                itemLen = fXmlNodeListItem.count;

                // --

                while (titIndex < titLen)
                {
                    titFixLen = 0;
                    titVarLen = 0;
                    titVarCnt = 0;

                    // --

                    fXmlNodeTit = fXmlNodeListTit[titIndex];
                    fTitPattern = FEnumConverter.toPattern(fXmlNodeTit.get_attrVal(FXmlTagTIT.A_Pattern, FXmlTagTIT.D_Pattern));

                    // --

                    if (fTitPattern == FPattern.Fixed)
                    {
                        #region Fixed TcpItem Compare

                        titFixLen = int.Parse(fXmlNodeTit.get_attrVal(FXmlTagTIT.A_FixedLength, FXmlTagTIT.D_FixedLength));
                        // --
                        if (itemIndex + titFixLen > itemLen)
                        {
                            return false;
                        }

                        // --

                        fTitFormat = FEnumConverter.toFormat(fXmlNodeTit.get_attrVal(FXmlTagTIT.A_Format, FXmlTagTIT.D_Format));
                        titName = fXmlNodeTit.get_attrVal(FXmlTagTIT.A_Name, FXmlTagTIT.D_Name);
                        // --
                        for (int i = 0; i < titFixLen; i++)
                        {
                            fXmlNodeItem = fXmlNodeListItem[itemIndex + i];

                            // --

                            // ***
                            // 이름이 동일한지 검사
                            // ***
                            if (titName != fXmlNodeItem.name)
                            {
                                return false;
                            }

                            // --

                            if (fTitFormat == FFormat.Unknown || fTitFormat == FFormat.Raw)
                            {
                                continue;
                            }

                            // --

                            fItemFormat = getMessageItemFormat(fXmlNodeItem);
                            if (fTitFormat == FFormat.List || fTitFormat == FFormat.AsciiList)
                            {
                                if (fItemFormat != FFormat.List)
                                {
                                    return false;
                                }
                                // --
                                if (!compareMsgWithTit(fXmlNodeTit.selectNodes(FXmlTagTIT.E_TcpItem), fXmlNodeItem.fChildNodes))
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                if (fItemFormat == FFormat.List)
                                {
                                    return false;
                                }

                                // --

                                // ***
                                // Format 변경 가능 여부 판단
                                // ***
                                itemValue = convertMsgItemValue(fXmlNodeItem.innerText);
                                // --
                                if (!FValueConverter.canConvertStringValue(fTitFormat, itemValue))
                                {
                                    return false;
                                }

                                // --

                                // ***
                                // Precondition Validation
                                // ***
                                preCondition = fXmlNodeTit.get_attrVal(FXmlTagTIT.A_Precondition, FXmlTagTIT.D_Precondition);
                                if (preCondition != string.Empty)
                                {
                                    isPreCondition = false;
                                    foreach (string s in preCondition.Split(FConstants.PreconditionValueSeparator))
                                    {
                                        if (itemValue == s)
                                        {
                                            isPreCondition = true;
                                            break;
                                        }
                                    }
                                    // --
                                    if (!isPreCondition)
                                    {
                                        return false;
                                    }
                                }
                            }
                        }   // for i end
                        titIndex++;
                        itemIndex += titFixLen;

                        #endregion
                    }
                    else
                    {
                        #region Variable TcpItem Compare

                        // ***
                        // 하위 Variable, Fixed Item 개수 계산
                        // ***
                        for (int i = titIndex; i < titLen; i++)
                        {
                            fXmlNodeTitCalc = fXmlNodeListTit[i];
                            fTitPattern = FEnumConverter.toPattern(fXmlNodeTitCalc.get_attrVal(FXmlTagTIT.A_Pattern, FXmlTagTIT.D_Pattern));
                            // --
                            if (fTitPattern == FPattern.Variable)
                            {
                                titVarLen++;
                            }
                            else
                            {
                                titFixLen += int.Parse(fXmlNodeTitCalc.get_attrVal(FXmlTagTIT.A_FixedLength, FXmlTagTIT.D_FixedLength));
                            }
                        }

                        // --

                        // ***
                        // Variable 회수 구하기
                        // ***
                        if (itemIndex + titFixLen > itemLen)
                        {
                            return false;   // Fixed Item 개수가 부족할 경우
                        }
                        titVarCnt = (itemLen - itemIndex - titFixLen) / titVarLen;

                        // --

                        for (int i = 0; i < titVarCnt; i++)
                        {
                            for (int j = 0; j < titVarLen; j++)
                            {
                                fXmlNodeTit = fXmlNodeListTit[titIndex + j];
                                fTitFormat = FEnumConverter.toFormat(fXmlNodeTit.get_attrVal(FXmlTagTIT.A_Format, FXmlTagTIT.D_Format));
                                titName = fXmlNodeTit.get_attrVal(FXmlTagTIT.A_Name, FXmlTagTIT.D_Name);
                                // --
                                fXmlNodeItem = fXmlNodeListItem[itemIndex];
                                fItemFormat = getMessageItemFormat(fXmlNodeItem);
                                itemIndex++;

                                // --

                                // ***
                                // 이름이 동일한지 검사
                                // ***
                                if (titName != fXmlNodeItem.name)
                                {
                                    return false;
                                }

                                // --

                                if (fTitFormat == FFormat.Unknown || fTitFormat == FFormat.Raw)
                                {
                                    continue;
                                }
                                else
                                {
                                    if (fTitFormat == FFormat.List || fTitFormat == FFormat.AsciiList)
                                    {
                                        if (fItemFormat != FFormat.List)
                                        {
                                            return false;
                                        }
                                        // --
                                        if (!compareMsgWithTit(fXmlNodeTit.selectNodes(FXmlTagTIT.E_TcpItem), fXmlNodeItem.fChildNodes))
                                        {
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        if (fItemFormat == FFormat.List)
                                        {
                                            return false;
                                        }

                                        // --

                                        // ***
                                        // Format 변경 가능 여부 판단
                                        // ***
                                        itemValue = convertMsgItemValue(fXmlNodeItem.innerText);
                                        // --
                                        if (!FValueConverter.canConvertStringValue(fTitFormat, itemValue))
                                        {
                                            return false;
                                        }

                                        // --

                                        // ***
                                        // Precondition Validation
                                        // ***
                                        preCondition = fXmlNodeTit.get_attrVal(FXmlTagTIT.A_Precondition, FXmlTagTIT.D_Precondition);
                                        if (preCondition != string.Empty)
                                        {
                                            isPreCondition = false;
                                            foreach (string s in preCondition.Split(FConstants.PreconditionValueSeparator))
                                            {
                                                if (itemValue == s)
                                                {
                                                    isPreCondition = true;
                                                    break;
                                                }
                                            }
                                            // --
                                            if (!isPreCondition)
                                            {
                                                return false;
                                            }
                                        }
                                    }
                                }
                            }   // for j end
                        }   // for i end
                        titIndex += titVarLen;

                        #endregion
                    }
                }   // while titIndex end 

                // --

                // ***
                // Custom Message의 Item이 남아 있을 경우 Comare False 처리
                // ***
                if (itemIndex != itemLen)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeTit = null;
                fXmlNodeTitCalc = null;
                fXmlNodeItem = null;
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static void generateMsgToTmg(
            FXmlDocument fXmlDoc,
            FXmlNode fXmlNodeTmgl,
            FXmlNode fXmlNodeMsg
            )
        {
            try
            {
                if (fXmlNodeMsg.fChildNodes.count == 0)
                {
                    return;
                }
                // --
                generateMsgToTit(fXmlDoc, fXmlNodeTmgl, fXmlNodeMsg.fChildNodes);
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

        private static bool generateMsgToTit(
            FXmlDocument fXmlDoc,
            FXmlNode fXmlNodeParent,
            FXmlNodeList fXmlNodeListItem
            )
        {
            FXmlNode fXmlNodeTitl = null;
            FFormat fItemFormat = FFormat.Unknown;
            int length = 0;

            try
            {
                foreach (FXmlNode fXmlNodeItem in fXmlNodeListItem)
                {
                    fItemFormat = getMessageItemFormat(fXmlNodeItem);

                    // --

                    fXmlNodeTitl = FTcpDriverLogCommon.createXmlNodeTITL(fXmlDoc);
                    fXmlNodeTitl.set_attrVal(FXmlTagTITL.A_Name, FXmlTagTITL.D_Name, fXmlNodeItem.name);
                    fXmlNodeTitl.set_attrVal(FXmlTagTITL.A_Format, FXmlTagTITL.D_Format, FEnumConverter.fromFormat(fItemFormat));

                    // --

                    if (fItemFormat == FFormat.List)
                    {
                        generateMsgToTit(fXmlDoc, fXmlNodeTitl, fXmlNodeItem.fChildNodes);
                        length = fXmlNodeItem.fChildNodes.count;
                    }
                    else
                    {
                        fXmlNodeTitl.set_attrVal(
                            FXmlTagTITL.A_Value,
                            FXmlTagTITL.D_Value,
                            FValueConverter.fromValue(fItemFormat, convertMsgItemValue(fXmlNodeItem.innerText), out length)
                            );
                    }
                    fXmlNodeTitl.set_attrVal(FXmlTagTITL.A_Length, FXmlTagTITL.D_Length, length.ToString());
                    // --
                    fXmlNodeParent.appendChild(fXmlNodeTitl);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeTitl = null;
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static FFormat getMessageItemFormat(
            FXmlNode fXmlNodeItem
            )
        {
            try
            {
                // ***
                // Custom Message의 Item Format 검색
                // Text가 비어있고 자식 Element가 있을 경우 List로 판단, 이외는 Ascii 처리
                // ***
                if (fXmlNodeItem.hasChildNode && fXmlNodeItem.fChildNodes[0].fNodeType == FXmlNodeType.Element)
                {
                    return FFormat.List;
                }
                return FFormat.Ascii;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FFormat.Ascii;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode parseTmtToMsg(
            FTcpDevice fTdv,
            FXmlNode fXmlNodeTsn,
            FXmlNode fXmlNodeTmt,
            UInt32 tid,
            ref int sessionId,
            ref FXmlNode fXmlNodeMsg
            )
        {
            FXmlDocument fXmlDoc = null;
            FXmlNode fXmlNodeTmgl = null;
            FXmlNode fXmlNodeTitl = null;
            string sessionName = string.Empty;
            string command = string.Empty;

            try
            {
                sessionName = fXmlNodeTsn.get_attrVal(FXmlTagTSN.A_Name, FXmlTagTSN.D_Name);
                sessionId = int.Parse(fXmlNodeTsn.get_attrVal(FXmlTagTSN.A_SessionId, FXmlTagTSN.D_SessionId));

                // --

                fXmlNodeTmgl = fXmlNodeTmt.clone(true);
                // --
                command = fXmlNodeTmgl.get_attrVal(FXmlTagTMGL.A_Command, FXmlTagTMGL.D_Command);

                // --

                // ***
                // MSG_ID, EQUIP_ID, DATE 설정
                // 해당 Item이 존재하고 값이 설정되어 있지 않을 경우 설정한다.
                // ***
                fXmlNodeTitl = fXmlNodeTmgl.selectSingleNode(
                    FXmlTagTITL.E_TcpItem + "[@" + FXmlTagTITL.A_Name + "='" + FXmlTagCustom001.E_HEADER + "']/" +
                    FXmlTagTITL.E_TcpItem + "[@" + FXmlTagTITL.A_Name + "='" + FXmlTagCustom001.E_MSG_ID + "']"
                    );
                if (
                    fXmlNodeTitl != null &&
                    FEnumConverter.toFormat(fXmlNodeTitl.get_attrVal(FXmlTagTITL.A_Format, FXmlTagTITL.D_Format)) == FFormat.Ascii &&
                    fXmlNodeTitl.get_attrVal(FXmlTagTITL.A_Value, FXmlTagTITL.D_Value) == string.Empty
                    )
                {
                    fXmlNodeTitl.set_attrVal(FXmlTagTITL.A_Value, FXmlTagTITL.D_Value, command);
                }

                fXmlNodeTitl = fXmlNodeTmgl.selectSingleNode(
                    FXmlTagTITL.E_TcpItem + "[@" + FXmlTagTITL.A_Name + "='" + FXmlTagCustom001.E_HEADER + "']/" +
                    FXmlTagTITL.E_TcpItem + "[@" + FXmlTagTITL.A_Name + "='" + FXmlTagCustom001.E_EQUIP_ID + "']"
                    );
                if (
                    fXmlNodeTitl != null &&
                    FEnumConverter.toFormat(fXmlNodeTitl.get_attrVal(FXmlTagTITL.A_Format, FXmlTagTITL.D_Format)) == FFormat.Ascii &&
                    fXmlNodeTitl.get_attrVal(FXmlTagTITL.A_Value, FXmlTagTITL.D_Value) == string.Empty
                    )
                {
                    fXmlNodeTitl.set_attrVal(FXmlTagTITL.A_Value, FXmlTagTITL.D_Value, sessionName);
                }

                fXmlNodeTitl = fXmlNodeTmgl.selectSingleNode(
                    FXmlTagTITL.E_TcpItem + "[@" + FXmlTagTITL.A_Name + "='" + FXmlTagCustom001.E_HEADER + "']/" +
                    FXmlTagTITL.E_TcpItem + "[@" + FXmlTagTITL.A_Name + "='" + FXmlTagCustom001.E_DATE + "']"
                    );
                if (
                    fXmlNodeTitl != null &&
                    FEnumConverter.toFormat(fXmlNodeTitl.get_attrVal(FXmlTagTITL.A_Format, FXmlTagTITL.D_Format)) == FFormat.Ascii &&
                    fXmlNodeTitl.get_attrVal(FXmlTagTITL.A_Value, FXmlTagTITL.D_Value) == string.Empty
                    )
                {
                    fXmlNodeTitl.set_attrVal(FXmlTagTITL.A_Value, FXmlTagTITL.D_Value, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                }

                // --

                fXmlDoc = new FXmlDocument();
                fXmlDoc.preserveWhiteSpace = false;

                // --

                // ***
                // MESSAGE Element Create
                // ***
                fXmlNodeMsg = fXmlDoc.createNode(FXmlTagCustom001.E_MESSAGE);

                // --

                parseTitToMsg(
                    fXmlDoc,
                    fXmlNodeMsg,
                    fXmlNodeTmgl,
                    fXmlNodeTmgl.selectNodes(FXmlTagTITL.E_TcpItem)
                    );

                // --

                setTcpMessageLogInfo(
                    fXmlNodeTmgl,
                    fTdv.fXmlNode,
                    fXmlNodeTsn,
                    sessionName,
                    sessionId,
                    tid,
                    0
                    );

                // --

                return fXmlNodeTmgl;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlDoc = null;
                fXmlNodeTitl = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static void parseTitToMsg(
            FXmlDocument fXmlDoc,
            FXmlNode fXmlNodeItemParent,
            FXmlNode fXmlNodeTitParent,
            FXmlNodeList fXmlNodeListTit
            )
        {
            FXmlNode fXmlNodeTit = null;
            FXmlNode fXmlNodeItem = null;
            FPattern fPattern = FPattern.Fixed;
            string titName = string.Empty;
            FFormat fTitFormat = FFormat.Unknown;
            int titFixedLen = 0;
            string value = string.Empty;
            int parentLen = 0;

            try
            {
                for (int i = 0; i < fXmlNodeListTit.count; i++)
                {
                    fXmlNodeTit = fXmlNodeListTit[i];
                    fPattern = FEnumConverter.toPattern(fXmlNodeTit.get_attrVal(FXmlTagTIT.A_Pattern, FXmlTagTIT.D_Pattern));

                    // --

                    if (fPattern == FPattern.Fixed)
                    {
                        titName = fXmlNodeTit.get_attrVal(FXmlTagTIT.A_Name, FXmlTagTIT.D_Name);
                        fTitFormat = FEnumConverter.toFormat(fXmlNodeTit.get_attrVal(FXmlTagTIT.A_Format, FXmlTagTIT.D_Format));
                        titFixedLen = int.Parse(fXmlNodeTit.get_attrVal(FXmlTagTIT.A_FixedLength, FXmlTagTIT.D_FixedLength));

                        // --

                        fXmlNodeItem = fXmlNodeItemParent.appendChild(fXmlDoc.createNode(titName));

                        // --

                        if (fTitFormat != FFormat.Raw && fTitFormat != FFormat.Unknown)
                        {
                            if (fTitFormat == FFormat.List || fTitFormat == FFormat.AsciiList)
                            {
                                parseTitToMsg(
                                    fXmlDoc,
                                    fXmlNodeItem,
                                    fXmlNodeTit,
                                    fXmlNodeTit.selectNodes(FXmlTagTIT.E_TcpItem)
                                    );
                            }
                            else
                            {
                                value = FValueConverter.toTransformedEncodingValue(
                                    fTitFormat,
                                    fXmlNodeTit.get_attrVal(FXmlTagTIT.A_Value, FXmlTagTIT.D_Value),
                                    fXmlNodeTit.get_attrVal(FXmlTagTIT.A_Transformer, FXmlTagTIT.D_Transformer)
                                    );
                                fXmlNodeItem.innerText = value;
                            }
                        }

                        // --

                        if (titFixedLen > 1)
                        {
                            fXmlNodeTit.set_attrVal(FXmlTagTIT.A_FixedLength, FXmlTagTIT.D_FixedLength, "1");
                            // --
                            for (int j = 1; j < titFixedLen; j++)
                            {
                                fXmlNodeTit = fXmlNodeTitParent.insertAfter(fXmlNodeTit.clone(true), fXmlNodeTit);
                                fXmlNodeItem = fXmlNodeItemParent.insertAfter(fXmlNodeItem.clone(true), fXmlNodeItem);
                            }

                            // --

                            if (fXmlNodeTitParent.name == FXmlTagTIT.E_TcpItem)
                            {
                                parentLen = int.Parse(fXmlNodeTitParent.get_attrVal(FXmlTagTIT.A_Length, FXmlTagTIT.D_Length));
                                fXmlNodeTitParent.set_attrVal(FXmlTagTIT.A_Length, FXmlTagTIT.D_Length, (parentLen + titFixedLen - 1).ToString());
                            }
                        }
                    }
                    else
                    {
                        fXmlNodeTitParent.removeChild(fXmlNodeTit);
                        // --
                        if (fXmlNodeTitParent.name == FXmlTagTIT.E_TcpItem)
                        {
                            parentLen = int.Parse(fXmlNodeTitParent.get_attrVal(FXmlTagTIT.A_Length, FXmlTagTIT.D_Length));
                            fXmlNodeTitParent.set_attrVal(FXmlTagTIT.A_Length, FXmlTagTIT.D_Length, (parentLen - 1).ToString());
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
                fXmlNodeTit = null;
                fXmlNodeItem = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static string convertMsgItemValue(
            string value
            )
        {
            try
            {
                value = value.Replace("{", "{7B");
                value = value.Replace("}", "7D}");
                // --
                value = value.Replace("{7B", "{7B}");
                value = value.Replace("7D}", "{7D}");
                // --
                return value;
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

        public static FXmlNode getReplyMessage(
            FTcpDriver fTcd,
            FXmlNode fXmlNodeTsn,
            string primaryUniqueId
            )
        {
            const string TcpMessageQuery =
                FXmlTagTLM.E_TcpLibraryModeling +
                "/" + FXmlTagTLG.E_TcpLibraryGroup +
                "/" + FXmlTagTLB.E_TcpLibrary + "[@" + FXmlTagTLB.A_UniqueId + "='{0}']" +
                "/" + FXmlTagTML.E_TcpMessageList +
                "/" + FXmlTagTMS.E_TcpMessages +
                "/" + FXmlTagTMG.E_TcpMessage + "[@" + FXmlTagTMG.A_UniqueId + "='{1}']";

            // --

            FXmlNode fXmlNodeTmg = null;

            try
            {
                fXmlNodeTmg = fTcd.fXmlNode.selectSingleNode(
                    string.Format(TcpMessageQuery, fXmlNodeTsn.get_attrVal(FXmlTagTSN.A_TcpLibraryId, FXmlTagTSN.D_TcpLibraryId), primaryUniqueId)
                    );
                if (fXmlNodeTmg == null)
                {
                    return null;
                }
                return fXmlNodeTmg.fNextSibling;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeTmg = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNodeList getRetryCondition(
            FTcpDriver fTcd,
            FXmlNode fXmlNodeTmgl
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
                " @" + FXmlTagTCN.A_TcpSessionId + "='{2}' and" +
                " @" + FXmlTagTCN.A_TcpMessageId + "='{3}' and" +
                " @" + FXmlTagTCN.A_RetryCount + "!='0']";

            // --

            string xpath = string.Empty;

            try
            {
                xpath = string.Format(
                   TcpConditionQuery,
                   FEnumConverter.fromConditionMode(FConditionMode.Timeout),
                   fXmlNodeTmgl.get_attrVal(FXmlTagTMGL.A_TcpDeviceId, FXmlTagTMGL.D_TcpDeviceId),
                   fXmlNodeTmgl.get_attrVal(FXmlTagTMGL.A_TcpSessionId, FXmlTagTMGL.D_TcpSessionId),
                   fXmlNodeTmgl.get_attrVal(FXmlTagTMGL.A_UniqueId, FXmlTagTMGL.D_UniqueId)
                   );
                return fTcd.fXmlNode.selectNodes(xpath);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
