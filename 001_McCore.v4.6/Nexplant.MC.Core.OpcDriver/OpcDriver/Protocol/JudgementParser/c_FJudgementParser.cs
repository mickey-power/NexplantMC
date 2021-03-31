/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FJudgementParser.cs
--  Creator         : spike.lee
--  Create Date     : 2013.11.14
--  Description     : FAMate Core FaOpcDriver Judgement Parser Class 
--  History         : Created by spike.lee at 2013.11.14
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    internal static class FJudgementParser
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public static bool parseJudgement(
            FScenarioData fScenarioData, 
            FXmlNode fXmlNodeJdm
            )
        {
            FXmlNode fXmlNodeDtsl = null;
            string dataSetUniqueId = string.Empty;
            bool result = false;

            try
            {
                if (!fScenarioData.hasMapperPerformedLog || !fScenarioData.fMapperPerformedLog.hasDataSetLog)
                {
                    return false;
                }
                
                // --

                fXmlNodeDtsl = fScenarioData.fMapperPerformedLog.getDataSetLog().fXmlNode;
                dataSetUniqueId = fXmlNodeDtsl.get_attrVal(FXmlTagDTSL.A_UniqueId, FXmlTagDTSL.D_UniqueId);
                
                // --
                
                foreach (FXmlNode fXmlNodeJcn in fXmlNodeJdm.selectNodes(FXmlTagJCN.E_JudgementCondition))
                {
                    // ***
                    // Data Set 일치 여부 비교
                    // ***
                    if (fXmlNodeJcn.get_attrVal(FXmlTagJCN.A_DataSetId, FXmlTagJCN.D_DataSetId) != dataSetUniqueId)
                    {
                        continue;
                    }

                    // --

                    result = true;
                    foreach (FXmlNode fXmlNodeJep in fXmlNodeJcn.selectNodes(FXmlTagJEP.E_JudgementExpression))
                    {
                        compareCondition(fXmlNodeDtsl, fXmlNodeJep, ref result);                        
                    }

                    if (result)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeDtsl = null;
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static void compareCondition(
            FXmlNode fXmlNodeDtsl,
            FXmlNode fXmlNodeJep,
            ref bool oldResult
            )
        {
            const string DataQuery = ".//" + FXmlTagDATL.E_Data + "[@" + FXmlTagDATL.A_UniqueId + "='{0}']";

            // --

            FXmlNodeList fXmlNodeListDatl = null;
            FXmlNode fXmlNodeOpe = null;
            FExpressionType fExpressionType;
            FLogical fLogical = FLogical.And;
            string operandUniqueId = string.Empty;
            FComparisonMode fComparisonMode;
            FOperandIndexType fOperandIndexType;
            FOperandIndexOption fOperandIndexOption;
            int operandIndex = 0;
            FFormat fOperandFormat;
            FOperation fOperation;
            FOperandValueType fOperandValueType;
            FOperandIndexType fOperandValueIndexType;
            FOperandIndexOption fOperandValueIndexOption;
            int operandValueIndex = 0;
            string operandValueId = string.Empty;
            List<string> operandValue = null;
            List<int> operandValueLength = null;
            List<string> operand = null;
            List<int> operandLength = null;
            int length = 0;
            string val = string.Empty;
            object oVal1 = null;
            object oVal2 = null;
            bool result1 = true;
            bool result2 = true;
            bool newResult = false;

            try
            {
                fExpressionType = FEnumConverter.toExpressionType(fXmlNodeJep.get_attrVal(FXmlTagJEP.A_ExpressionType, FXmlTagJEP.D_ExpressionType));
                fLogical = FEnumConverter.toLogical(fXmlNodeJep.get_attrVal(FXmlTagJEP.A_Logical, FXmlTagJEP.D_Logical));                

                // --

                if (fExpressionType == FExpressionType.Bracket)
                {
                    newResult = true;
                    foreach (FXmlNode fXmlNodeChild in fXmlNodeJep.selectNodes(FXmlTagJEP.E_JudgementExpression))
                    {
                        compareCondition(fXmlNodeDtsl, fXmlNodeChild, ref newResult);
                    }
                    oldResult = compareResult(fLogical, oldResult, newResult);
                    return;
                }

                // --

                // ***
                // Operand가 존재하지 않을 경우 False 설정
                // ***
                operandUniqueId = fXmlNodeJep.get_attrVal(FXmlTagJEP.A_OperandId, FXmlTagJEP.D_OperandId);
                if (operandUniqueId == string.Empty)
                {
                    oldResult = compareResult(fLogical, oldResult, false);
                    return;
                }

                // --

                fComparisonMode = FEnumConverter.toComparisonMode(fXmlNodeJep.get_attrVal(FXmlTagJEP.A_ComparisonMode, FXmlTagJEP.D_ComparisonMode));
                fOperandIndexType = FEnumConverter.toOperandIndexType(fXmlNodeJep.get_attrVal(FXmlTagJEP.A_OperandIndexType, FXmlTagJEP.D_OperandIndexType));
                fOperandIndexOption = FEnumConverter.toOperandIndexOption(fXmlNodeJep.get_attrVal(FXmlTagJEP.A_OperandIndexOption, FXmlTagJEP.D_OperandIndexOption));
                fOperandFormat = FEnumConverter.toFormat(fXmlNodeJep.get_attrVal(FXmlTagJEP.A_OperandFormat, FXmlTagJEP.D_OperandFormat));
                fOperation = FEnumConverter.toOperation(fXmlNodeJep.get_attrVal(FXmlTagJEP.A_Operation, FXmlTagJEP.D_Operation));
                fOperandValueType = FEnumConverter.toOperandValueType(fXmlNodeJep.get_attrVal(FXmlTagJEP.A_OperandValueType, FXmlTagJEP.D_OperandValueType));
                fOperandValueIndexType = FEnumConverter.toOperandIndexType(fXmlNodeJep.get_attrVal(FXmlTagJEP.A_OperandValueIndexType, FXmlTagJEP.D_OperandValueIndexType));
                fOperandValueIndexOption = FEnumConverter.toOperandIndexOption(fXmlNodeJep.get_attrVal(FXmlTagJEP.A_OperandValueIndexOption, FXmlTagJEP.D_OperandValueIndexOption));
                // --
                operandValue = new List<string>();
                operandValueLength = new List<int>();
                operand = new List<string>();
                operandLength = new List<int>();

                // --

                // ***
                // Operand Value 검색
                // ***
                if (fOperandValueType == FOperandValueType.Data)
                {
                    // ***
                    // Operand Value ID가 설정되어 있지 않을 경우 False 처리
                    // ***
                    operandValueId = fXmlNodeJep.get_attrVal(FXmlTagJEP.A_ValueId, FXmlTagJEP.D_ValueId);
                    if (operandValueId == string.Empty)
                    {
                        oldResult = compareResult(fLogical, oldResult, false);
                        return;
                    }

                    // --

                    fXmlNodeListDatl = fXmlNodeDtsl.selectNodes(string.Format(DataQuery, operandValueId));                    

                    // --

                    if (fOperandValueIndexType == FOperandIndexType.All)
                    {
                        // ***
                        // Data Set에 Operand Value가 존재하지 않을 경우 False 처리
                        // ***
                        if (fXmlNodeListDatl.count == 0)
                        {
                            oldResult = compareResult(fLogical, oldResult, false);
                            return;
                        }

                        // --

                        foreach (FXmlNode fXmlNodeDatl in fXmlNodeListDatl)
                        {
                            length = int.Parse(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length));
                            val = FValueConverter.toDataConversionStringValue(
                                FEnumConverter.toFormat(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format)),
                                fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value),
                                fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Transformer, FXmlTagDATL.D_Transformer),
                                fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_DataConversionSetExpression, FXmlTagDATL.D_DataConversionSetExpression),
                                ref length
                                );  // Data Transformer 적용

                            // --

                            if (fComparisonMode == FComparisonMode.Value)
                            {
                                val = FValueConverter.convertStringValue(fOperandFormat, val, out length);  // Judgement Expression Format으로 변경
                                // --
                                if (operandValue.Contains(val))
                                {
                                    continue;
                                }
                                // --                        
                                operandValue.Add(val);
                                operandValueLength.Add(length);
                            }
                            else
                            {
                                if (operandValueLength.Contains(length))
                                {
                                    continue;
                                }
                                operandValueLength.Add(length);
                            }
                        }
                    }
                    else
                    {
                        operandValueIndex = int.Parse(fXmlNodeJep.get_attrVal(FXmlTagJEP.A_OperandValueIndex, FXmlTagJEP.D_OperandValueIndex));

                        // --

                        // ***
                        // Data Set에 Operand Value가 존재하지 않을 경우 False 처리
                        // ***
                        if (operandValueIndex >= fXmlNodeListDatl.count)
                        {
                            oldResult = compareResult(fLogical, oldResult, false);
                            return;
                        }

                        // --

                        fXmlNodeOpe = fXmlNodeListDatl[operandValueIndex];
                        length = int.Parse(fXmlNodeOpe.get_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length));
                        val = FValueConverter.toDataConversionStringValue(
                            FEnumConverter.toFormat(fXmlNodeOpe.get_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format)),
                            fXmlNodeOpe.get_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value),
                            fXmlNodeOpe.get_attrVal(FXmlTagDATL.A_Transformer, FXmlTagDATL.D_Transformer),
                            fXmlNodeOpe.get_attrVal(FXmlTagDATL.A_DataConversionSetExpression, FXmlTagDATL.D_DataConversionSetExpression),
                            ref length
                            );  // Data Transformer 적용
                        // --

                        if (fComparisonMode == FComparisonMode.Value)
                        {
                            val = FValueConverter.convertStringValue(fOperandFormat, val, out length);  // Judgement Expression Format으로 변경
                            // --
                            operandValue.Add(val);
                            operandValueLength.Add(length);
                        }
                        else
                        {
                            operandValueLength.Add(length);
                        }
                    }
                }
                else
                {
                    if (fComparisonMode == FComparisonMode.Value)
                    {
                        val = fXmlNodeJep.get_attrVal(FXmlTagJEP.A_Value, FXmlTagJEP.D_Value);
                        
                        // --
                        
                        // ***
                        // Operand Length는 Ascii 계열이외에만 사용되고 Operand Length는 0 또는 1만을 가질수 있기 때문에
                        // 값이 존재하지 않을 경우 0처리하고 값이 존재할 경우 1처리한다.
                        // Operand Format이 Ascii 계열인 경우 Operand Length를 사용하지 않는다.
                        // ***
                        operandValue.Add(val);
                        operandValueLength.Add(val == string.Empty ? 0 : 1);                        
                    }
                    else
                    {
                        operandValueLength.Add(
                            int.Parse(fXmlNodeJep.get_attrVal(FXmlTagJEP.A_Value, FXmlTagJEP.D_Value))
                            );
                    }
                }

                // --

                // ***
                // Operand 검색
                // ***
                fXmlNodeListDatl = fXmlNodeDtsl.selectNodes(string.Format(DataQuery, operandUniqueId));
                if (fOperandIndexType == FOperandIndexType.All)
                {
                    // ***
                    // Operand가 존재하지 않을 경우 False 처리
                    // ***
                    if (fXmlNodeListDatl.count == 0)
                    {
                        oldResult = compareResult(fLogical, oldResult, false);
                        return;
                    }

                    // --

                    foreach (FXmlNode fXmlNodeDatl in fXmlNodeListDatl)
                    {
                        length = int.Parse(fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length));
                        val = FValueConverter.toDataConversionStringValue(
                            fOperandFormat,
                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value),
                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_Transformer, FXmlTagDATL.D_Transformer),
                            fXmlNodeDatl.get_attrVal(FXmlTagDATL.A_DataConversionSetExpression, FXmlTagDATL.D_DataConversionSetExpression),
                            ref length
                            );  // Data Transformer 적용

                        // --

                        val = FValueConverter.toDataConversionStringValue(
                            fOperandFormat,
                            val,
                            fXmlNodeJep.get_attrVal(FXmlTagJEP.A_Transformer, FXmlTagJEP.D_Transformer),
                            fXmlNodeJep.get_attrVal(FXmlTagJEP.A_DataConversionSetExpression, FXmlTagJEP.D_DataConversionSetExpression),
                            ref length
                            );  // Judgement Expression Transformer 적용

                        // --

                        if (operand.Contains(val))
                        {
                            continue;
                        }

                        // --

                        operand.Add(val);
                        operandLength.Add(length);                        
                    }
                }
                else
                {
                    operandIndex = int.Parse(fXmlNodeJep.get_attrVal(FXmlTagJEP.A_OperandIndex, FXmlTagJEP.D_OperandIndex));
                    
                    // --

                    // ***
                    // Operand가 존재하지 않을 경우 False 처리
                    // ***                    
                    if (operandIndex >= fXmlNodeListDatl.count)
                    {
                        oldResult = compareResult(fLogical, oldResult, false);
                        return;
                    }

                    // --

                    fXmlNodeOpe = fXmlNodeListDatl[operandIndex];
                    length = int.Parse(fXmlNodeOpe.get_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length));
                    val = FValueConverter.toDataConversionStringValue(
                        fOperandFormat,
                        fXmlNodeOpe.get_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value),
                        fXmlNodeOpe.get_attrVal(FXmlTagDATL.A_Transformer, FXmlTagDATL.D_Transformer),
                        fXmlNodeOpe.get_attrVal(FXmlTagDATL.A_DataConversionSetExpression, FXmlTagDATL.D_DataConversionSetExpression),
                        ref length
                        );  // Data Transformer 적용

                    // --

                    val = FValueConverter.toDataConversionStringValue(
                        fOperandFormat,
                        val,
                        fXmlNodeJep.get_attrVal(FXmlTagJEP.A_Transformer, FXmlTagJEP.D_Transformer),
                        fXmlNodeJep.get_attrVal(FXmlTagJEP.A_DataConversionSetExpression, FXmlTagJEP.D_DataConversionSetExpression),
                        ref length
                        );  // Judgement Expression Transformer 적용

                    // --

                    operand.Add(val);
                    operandLength.Add(length);                    
                }

                // --                

                if (fComparisonMode == FComparisonMode.Value)
                {
                    for (int i = 0; i < operand.Count; i++)
                    {
                        val = operand[i];
                        length = operandLength[i];                        

                        // --                         

                        if (fOperandFormat == FFormat.Ascii || fOperandFormat == FFormat.A2 || fOperandFormat == FFormat.JIS8)
                        {
                            for (int j = 0; j < operandValue.Count; j++)
                            {
                                if (fOperation == FOperation.Equal)
                                {
                                    result2 = (string.Compare(val, operandValue[j]) == 0 ? true : false);                                    
                                }
                                else if (fOperation == FOperation.NotEqual)
                                {
                                    result2 = (string.Compare(val, operandValue[j]) != 0 ? true : false);                                    
                                }
                                else if (fOperation == FOperation.MoreThan)
                                {
                                    result2 = (string.Compare(val, operandValue[j]) > 0 ? true : false);
                                }
                                else if (fOperation == FOperation.MoreThanOrEqual)
                                {
                                    result2 = (string.Compare(val, operandValue[j]) >= 0 ? true : false);
                                }
                                else if (fOperation == FOperation.LessThan)
                                {
                                    result2 = (string.Compare(val, operandValue[j]) < 0 ? true : false);
                                }
                                else if (fOperation == FOperation.LessThanOrEqual)
                                {
                                    result2 = (string.Compare(val, operandValue[j]) <= 0 ? true : false);
                                }

                                // --

                                if (j == 0)
                                {
                                    result1 = result2;
                                }
                                else
                                {
                                    result1 = compareResult(fOperandValueIndexOption, result1, result2);                                    
                                }

                                // --

                                if (result1)
                                {
                                    if (fOperandValueIndexOption == FOperandIndexOption.Or)
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    if (fOperandValueIndexOption == FOperandIndexOption.And)
                                    {
                                        break;
                                    }
                                }
                            }                                                        
                        }
                        else
                        {
                            if (length > 1)
                            {
                                // ***
                                // Ascii 계열이 아니고 Length가 1 보다 클 경우 False 처리
                                // ***
                                result1 = false;
                            }
                            else if (length == 0)
                            {
                                for (int j = 0; j < operandValue.Count; j++)
                                {
                                    if (operandValueLength[j] > 1)
                                    {
                                        result2 = false;
                                    }
                                    else if (operandValueLength[j] == 0)
                                    {
                                        if (
                                            fOperation == FOperation.Equal ||
                                            fOperation == FOperation.MoreThanOrEqual ||
                                            fOperation == FOperation.LessThanOrEqual
                                            )
                                        {
                                            result2 = true;
                                        }
                                        else
                                        {
                                            result2 = false;
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
                                            result2 = true;
                                        }
                                        else
                                        {
                                            result2 = false;
                                        }
                                    }

                                    // --

                                    if (j == 0)
                                    {
                                        result1 = result2;
                                    }
                                    else
                                    {
                                        result1 = compareResult(fOperandValueIndexOption, result1, result2);
                                    }

                                    // --

                                    if (result1)
                                    {
                                        if (fOperandValueIndexOption == FOperandIndexOption.Or)
                                        {
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        if (fOperandValueIndexOption == FOperandIndexOption.And)
                                        {
                                            break;
                                        }
                                    }
                                }   // for j end
                            }
                            else
                            {
                                oVal1 = FValueConverter.toValue(fOperandFormat, val);

                                // --

                                for (int j = 0; j < operandValue.Count; j++)
                                {
                                    if (operandValueLength[j] > 1)
                                    {
                                        // ***
                                        // Operand Value가 길이가 1보다 큰 경우 False 처리
                                        // ***
                                        result2 = false;
                                    }
                                    else if (operandValueLength[j] == 0)
                                    {
                                        if (
                                            fOperation == FOperation.NotEqual ||
                                            fOperation == FOperation.MoreThan ||
                                            fOperation == FOperation.MoreThanOrEqual
                                            )
                                        {
                                            result2 = true;
                                        }
                                        else
                                        {
                                            result2 = false;
                                        }
                                    }
                                    else
                                    {
                                        oVal2 = FValueConverter.toValue(fOperandFormat, operandValue[j]);

                                        // --

                                        if (fOperandFormat == FFormat.Binary)
                                        {
                                            if (fOperation == FOperation.Equal)
                                            {
                                                result2 = ((byte)oVal1 == (byte)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.NotEqual)
                                            {
                                                result2 = ((byte)oVal1 != (byte)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.MoreThan)
                                            {
                                                result2 = ((byte)oVal1 > (byte)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.MoreThanOrEqual)
                                            {
                                                result2 = ((byte)oVal1 >= (byte)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.LessThan)
                                            {
                                                result2 = ((byte)oVal1 < (byte)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.LessThanOrEqual)
                                            {
                                                result2 = ((byte)oVal1 <= (byte)oVal2 ? true : false);
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
                                                result2 = ((bool)oVal1 == (bool)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.NotEqual)
                                            {
                                                result2 = ((bool)oVal1 != (bool)oVal2 ? true : false);                                                
                                            }
                                        }
                                        else if (fOperandFormat == FFormat.I8)
                                        {
                                            if (fOperation == FOperation.Equal)
                                            {
                                                result2 = ((Int64)oVal1 == (Int64)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.NotEqual)
                                            {
                                                result2 = ((Int64)oVal1 != (Int64)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.MoreThan)
                                            {
                                                result2 = ((Int64)oVal1 > (Int64)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.MoreThanOrEqual)
                                            {
                                                result2 = ((Int64)oVal1 >= (Int64)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.LessThan)
                                            {
                                                result2 = ((Int64)oVal1 < (Int64)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.LessThanOrEqual)
                                            {
                                                result2 = ((Int64)oVal1 <= (Int64)oVal2 ? true : false);                                               
                                            }
                                        }
                                        else if (fOperandFormat == FFormat.I4)
                                        {
                                            if (fOperation == FOperation.Equal)
                                            {
                                                result2 = ((Int32)oVal1 == (Int32)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.NotEqual)
                                            {
                                                result2 = ((Int32)oVal1 != (Int32)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.MoreThan)
                                            {
                                                result2 = ((Int32)oVal1 > (Int32)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.MoreThanOrEqual)
                                            {
                                                result2 = ((Int32)oVal1 >= (Int32)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.LessThan)
                                            {
                                                result2 = ((Int32)oVal1 < (Int32)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.LessThanOrEqual)
                                            {
                                                result2 = ((Int32)oVal1 <= (Int32)oVal2 ? true : false);
                                            }
                                        }
                                        else if (fOperandFormat == FFormat.I2)
                                        {
                                            if (fOperation == FOperation.Equal)
                                            {
                                                result2 = ((Int16)oVal1 == (Int16)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.NotEqual)
                                            {
                                                result2 = ((Int16)oVal1 != (Int16)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.MoreThan)
                                            {
                                                result2 = ((Int16)oVal1 > (Int16)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.MoreThanOrEqual)
                                            {
                                                result2 = ((Int16)oVal1 >= (Int16)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.LessThan)
                                            {
                                                result2 = ((Int16)oVal1 < (Int16)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.LessThanOrEqual)
                                            {
                                                result2 = ((Int16)oVal1 <= (Int16)oVal2 ? true : false);
                                            }
                                        }
                                        else if (fOperandFormat == FFormat.I1)
                                        {
                                            if (fOperation == FOperation.Equal)
                                            {
                                                result2 = ((sbyte)oVal1 == (sbyte)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.NotEqual)
                                            {
                                                result2 = ((sbyte)oVal1 != (sbyte)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.MoreThan)
                                            {
                                                result2 = ((sbyte)oVal1 > (sbyte)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.MoreThanOrEqual)
                                            {
                                                result2 = ((sbyte)oVal1 >= (sbyte)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.LessThan)
                                            {
                                                result2 = ((sbyte)oVal1 < (sbyte)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.LessThanOrEqual)
                                            {
                                                result2 = ((sbyte)oVal1 <= (sbyte)oVal2 ? true : false);
                                            }
                                        }
                                        else if (fOperandFormat == FFormat.F8)
                                        {
                                            if (fOperation == FOperation.Equal)
                                            {
                                                result2 = ((Double)oVal1 == (Double)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.NotEqual)
                                            {
                                                result2 = ((Double)oVal1 != (Double)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.MoreThan)
                                            {
                                                result2 = ((Double)oVal1 > (Double)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.MoreThanOrEqual)
                                            {
                                                result2 = ((Double)oVal1 >= (Double)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.LessThan)
                                            {
                                                result2 = ((Double)oVal1 < (Double)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.LessThanOrEqual)
                                            {
                                                result2 = ((Double)oVal1 <= (Double)oVal2 ? true : false);
                                            }                                            
                                        }
                                        else if (fOperandFormat == FFormat.F4)
                                        {
                                            if (fOperation == FOperation.Equal)
                                            {
                                                result2 = ((Single)oVal1 == (Single)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.NotEqual)
                                            {
                                                result2 = ((Single)oVal1 != (Single)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.MoreThan)
                                            {
                                                result2 = ((Single)oVal1 > (Single)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.MoreThanOrEqual)
                                            {
                                                result2 = ((Single)oVal1 >= (Single)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.LessThan)
                                            {
                                                result2 = ((Single)oVal1 < (Single)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.LessThanOrEqual)
                                            {
                                                result2 = ((Single)oVal1 <= (Single)oVal2 ? true : false);
                                            }                                                      
                                        }
                                        else if (fOperandFormat == FFormat.U8)
                                        {
                                            if (fOperation == FOperation.Equal)
                                            {
                                                result2 = ((UInt64)oVal1 == (UInt64)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.NotEqual)
                                            {
                                                result2 = ((UInt64)oVal1 != (UInt64)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.MoreThan)
                                            {
                                                result2 = ((UInt64)oVal1 > (UInt64)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.MoreThanOrEqual)
                                            {
                                                result2 = ((UInt64)oVal1 >= (UInt64)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.LessThan)
                                            {
                                                result2 = ((UInt64)oVal1 < (UInt64)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.LessThanOrEqual)
                                            {
                                                result2 = ((UInt64)oVal1 <= (UInt64)oVal2 ? true : false);
                                            }        
                                        }
                                        else if (fOperandFormat == FFormat.U4)
                                        {
                                            if (fOperation == FOperation.Equal)
                                            {
                                                result2 = ((UInt32)oVal1 == (UInt32)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.NotEqual)
                                            {
                                                result2 = ((UInt32)oVal1 != (UInt32)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.MoreThan)
                                            {
                                                result2 = ((UInt32)oVal1 > (UInt32)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.MoreThanOrEqual)
                                            {
                                                result2 = ((UInt32)oVal1 >= (UInt32)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.LessThan)
                                            {
                                                result2 = ((UInt32)oVal1 < (UInt32)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.LessThanOrEqual)
                                            {
                                                result2 = ((UInt32)oVal1 <= (UInt32)oVal2 ? true : false);
                                            }        
                                        }
                                        else if (fOperandFormat == FFormat.U2)
                                        {
                                            if (fOperation == FOperation.Equal)
                                            {
                                                result2 = ((UInt16)oVal1 == (UInt16)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.NotEqual)
                                            {
                                                result2 = ((UInt16)oVal1 != (UInt16)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.MoreThan)
                                            {
                                                result2 = ((UInt16)oVal1 > (UInt16)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.MoreThanOrEqual)
                                            {
                                                result2 = ((UInt16)oVal1 >= (UInt16)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.LessThan)
                                            {
                                                result2 = ((UInt16)oVal1 < (UInt16)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.LessThanOrEqual)
                                            {
                                                result2 = ((UInt16)oVal1 <= (UInt16)oVal2 ? true : false);
                                            }        
                                        }
                                        else if (fOperandFormat == FFormat.U1)
                                        {
                                            if (fOperation == FOperation.Equal)
                                            {
                                                result2 = ((byte)oVal1 == (byte)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.NotEqual)
                                            {
                                                result2 = ((byte)oVal1 != (byte)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.MoreThan)
                                            {
                                                result2 = ((byte)oVal1 > (byte)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.MoreThanOrEqual)
                                            {
                                                result2 = ((byte)oVal1 >= (byte)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.LessThan)
                                            {
                                                result2 = ((byte)oVal1 < (byte)oVal2 ? true : false);
                                            }
                                            else if (fOperation == FOperation.LessThanOrEqual)
                                            {
                                                result2 = ((byte)oVal1 <= (byte)oVal2 ? true : false);
                                            }                                                 
                                        }

                                        // --

                                        if (j == 0)
                                        {
                                            result1 = result2;
                                        }
                                        else
                                        {
                                            result1 = compareResult(fOperandValueIndexOption, result1, result2);
                                        }

                                        // --

                                        if (result1)
                                        {
                                            if (fOperandValueIndexOption == FOperandIndexOption.Or)
                                            {
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            if (fOperandValueIndexOption == FOperandIndexOption.And)
                                            {
                                                break;
                                            }
                                        }
                                    } 
                                }   // for j end
                            }   // length compare if end
                        }   // ascii or no ascii if end             

                        // --

                        if (i == 0)
                        {
                            newResult = result1;
                        }
                        else
                        {
                            newResult = compareResult(fOperandIndexOption, newResult, result1);
                        }

                        // --

                        if (newResult)
                        {
                            if (fOperandIndexOption == FOperandIndexOption.Or)
                            {
                                break;
                            }
                        }
                        else
                        {
                            if (fOperandIndexOption == FOperandIndexOption.And)
                            {
                                break;
                            }
                        }
                    }   // for i end  
                }   // comparison value end
                else
                {
                    for (int i = 0; i < operandLength.Count; i++)
                    {
                        length = operandLength[i];

                        // --

                        //*** 2017.02.13
                        for (int j = 0; j < operandValueLength.Count; j++)
                        {
                            if (fOperation == FOperation.Equal)
                            {
                                result2 = (length == operandValueLength[j] ? true : false);                                
                            }
                            else if (fOperation == FOperation.NotEqual)
                            {
                                result2 = (length != operandValueLength[j] ? true : false);
                            }
                            else if (fOperation == FOperation.MoreThan)
                            {
                                result2 = (length > operandValueLength[j] ? true : false);
                            }
                            else if (fOperation == FOperation.MoreThanOrEqual)
                            {
                                result2 = (length >= operandValueLength[j] ? true : false);
                            }
                            else if (fOperation == FOperation.LessThan)
                            {
                                result2 = (length < operandValueLength[j] ? true : false);                                
                            }
                            else if (fOperation == FOperation.LessThanOrEqual)
                            {
                                result2 = (length <= operandValueLength[j] ? true : false);                                
                            }

                            // --

                            if (j == 0)
                            {
                                result1 = result2;
                            }
                            else
                            {
                                result1 = compareResult(fOperandValueIndexOption, result1, result2);
                            }

                            // --

                            if (result1)
                            {
                                if (fOperandValueIndexOption == FOperandIndexOption.Or)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                if (fOperandValueIndexOption == FOperandIndexOption.And)
                                {
                                    break;
                                }
                            }
                        }   // for j end

                        // --

                        if (i == 0)
                        {
                            newResult = result1;
                        }
                        else
                        {
                            newResult = compareResult(fOperandIndexOption, newResult, result1);
                        }

                        // --

                        if (newResult)
                        {
                            if (fOperandIndexOption == FOperandIndexOption.Or)
                            {
                                break;
                            }
                        }
                        else
                        {
                            if (fOperandIndexOption == FOperandIndexOption.And)
                            {
                                break;
                            }
                        }
                    }   // for i end
                }   // comparison length end

                // --

                oldResult = compareResult(fLogical, oldResult, newResult);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListDatl = null;
                fXmlNodeOpe = null;
                operandValue = null;
                operandValueLength = null;
                operand = null;
                operandLength = null;
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

        private static bool compareResult(
            FOperandIndexOption fOption, 
            bool oldResult, 
            bool newResult
            )
        {
            try
            {
                if (fOption == FOperandIndexOption.And)
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
