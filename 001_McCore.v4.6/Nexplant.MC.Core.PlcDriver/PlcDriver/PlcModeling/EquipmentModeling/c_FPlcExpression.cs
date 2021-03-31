/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPlcExpression.cs
--  Creator         : spike.lee
--  Create Date     : 2013.08.12
--  Description     : FAMate Core FaPlcDriver Plc Expression Class 
--  History         : Created by spike.lee at 2013.08.12
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    public class FPlcExpression : FBaseObject<FPlcExpression>, FIObject
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPlcExpression(
            FPlcDriver fPlcDriver
            )
            : base(fPlcDriver.fPcdCore, FPlcDriverCommon.createXmlNodePEP(fPlcDriver.fPcdCore.fXmlDoc))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FPlcExpression(
            FPcdCore fPcdCore,
            FXmlNode fXmlNode
            )
            : base(fPcdCore, fXmlNode)
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPlcExpression(
           )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    
                }                

                m_disposed = true;

                // --
                
                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FObjectType fObjectType
        {
            get
            {
                try
                {
                    return FObjectType.PlcExpression;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.PlcExpression;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagPEP.A_UniqueId, FXmlTagPEP.D_UniqueId);
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public UInt64 uniqueId
        {
            get
            {
                try
                {
                    return UInt64.Parse(this.uniqueIdToString);
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string name
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagPEP.A_Name, FXmlTagPEP.D_Name);
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

            set
            {
                try
                {
                    FPlcDriverCommon.validateName(value, true);

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_Name, FXmlTagPEP.D_Name, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string description
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagPEP.A_Description, FXmlTagPEP.D_Description);
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

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_Description, FXmlTagPEP.D_Description, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public Color fontColor
        {
            get
            {
                try
                {
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagPEP.A_FontColor, FXmlTagPEP.D_FontColor));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return Color.Black;
            }

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_FontColor, FXmlTagPEP.D_FontColor, value.Name, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool fontBold
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagPEP.A_FontBold, FXmlTagPEP.D_FontBold));
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

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_FontBold, FXmlTagPEP.D_FontBold, FBoolean.fromBool(value), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        public FLogical fLogical
        {
            get
            {
                try
                {
                    return FEnumConverter.toLogical(this.fXmlNode.get_attrVal(FXmlTagPEP.A_Logical, FXmlTagPEP.D_Logical));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FLogical.And;
            }

            set
            {
                try
                {
                    // ***
                    // 첫번째 PLC Expression인 경우 Logical를 변경할 수 없다.
                    // ***
                    if (this.fPreviousSibling == null)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0008, "First Expression", "Logical"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_Logical, FXmlTagPEP.D_Logical, FEnumConverter.fromLogical(value), true);
                    noticeModified(this.fAncestorPlcCondition);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FExpressionType fExpressionType
        {
            get
            {
                try
                {
                    return FEnumConverter.toExpressionType(this.fXmlNode.get_attrVal(FXmlTagPEP.A_ExpressionType, FXmlTagPEP.D_ExpressionType));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FExpressionType.Comparison;
            }

            set
            {
                try
                {
                    // ***
                    // 자식 PLC Expression이 존재할 경우 Expression Type를 변경할 수 없다.
                    // ***
                    if (this.hasChild)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0013, "Object's Child"));
                    }                    

                    // --                    

                    resetOperand(false);

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_ComparisonMode, FXmlTagPEP.D_ComparisonMode, FEnumConverter.fromComparisonMode(FComparisonMode.Value), false);
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_OperandType, FXmlTagPEP.D_OperandType, FEnumConverter.fromPlcOperandType(FPlcOperandType.PlcWord), false);
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_OperandIndex, FXmlTagPEP.D_OperandIndex, "0", false);
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_Operation, FXmlTagPEP.D_Operation, FEnumConverter.fromOperation(FOperation.Equal), false);
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_ExpressionValueType, FXmlTagPEP.D_ExpressionValueType, FEnumConverter.fromExpressionValueType(FExpressionValueType.Value), false);
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_Resource, FXmlTagPEP.D_Resource, FEnumConverter.fromPlcResourceSourceType(FPlcResourceSourceType.None), false);
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_Value, FXmlTagPEP.D_Value, string.Empty, false);
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_Transformer, FXmlTagPEP.D_Transformer, string.Empty, false);
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_ExpressionType, FXmlTagPEP.D_ExpressionType, FEnumConverter.fromExpressionType(value), true);
                    // --
                    noticeModified(this.fAncestorPlcCondition);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FComparisonMode fComparisonMode
        {
            get
            {
                try
                {
                    return FEnumConverter.toComparisonMode(this.fXmlNode.get_attrVal(FXmlTagPEP.A_ComparisonMode, FXmlTagPEP.D_ComparisonMode));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FComparisonMode.Value;
            }

            set
            {
                try
                {
                    // ***
                    // Expression Type이 Bracket일 경우 변경할 수 없다.
                    // ***
                    if (this.fExpressionType == FExpressionType.Bracket)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Expression's Type", "Comparison"));
                    }

                    // --

                    resetOperand(false);

                    // --                    

                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_OperandType, FXmlTagPEP.D_OperandType, FEnumConverter.fromPlcOperandType(FPlcOperandType.PlcWord), false);
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_OperandIndex, FXmlTagPEP.D_OperandIndex, "0", false);
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_Operation, FXmlTagPEP.D_Operation, FEnumConverter.fromOperation(FOperation.Equal), false);
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_ExpressionValueType, FXmlTagPEP.D_ExpressionValueType, FEnumConverter.fromExpressionValueType(FExpressionValueType.Value), false);
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_Value, FXmlTagPEP.D_Value, string.Empty, false);
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_Resource, FXmlTagPEP.D_Resource, FEnumConverter.fromPlcResourceSourceType(FPlcResourceSourceType.None), false);
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_Transformer, FXmlTagPEP.D_Transformer, string.Empty, false);
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_ComparisonMode, FXmlTagPEP.D_ComparisonMode, FEnumConverter.fromComparisonMode(value), true);

                    // --

                    noticeModified(this.fAncestorPlcCondition);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPlcOperandType fOperandType
        {
            get
            {
                try
                {
                    return FEnumConverter.toPlcOperandType(this.fXmlNode.get_attrVal(FXmlTagPEP.A_OperandType, FXmlTagPEP.D_OperandType));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FPlcOperandType.PlcWord;
            }

            set
            {
                try
                {
                    // ***
                    // Expression Type이 Bracket일 경우 변경할 수 없다.
                    // ***
                    if (this.fExpressionType == FExpressionType.Bracket)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Expression's Type", "Comparison"));
                    }

                    if (this.fComparisonMode == FComparisonMode.Length && value == FPlcOperandType.EquipmentState)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Comparison Mode", "Value"));
                    }

                    // --

                    resetOperand(false);

                    // --
                    
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_ExpressionValueType, FXmlTagPEP.D_ExpressionValueType, FEnumConverter.fromExpressionValueType(FExpressionValueType.Value), false);
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_Resource, FXmlTagPEP.D_Resource, FEnumConverter.fromPlcResourceSourceType(FPlcResourceSourceType.None), false);
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_Value, FXmlTagPEP.D_Value, string.Empty, false);
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_Transformer, FXmlTagPEP.D_Transformer, string.Empty, false);
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_OperandType, FXmlTagPEP.D_OperandType, FEnumConverter.fromPlcOperandType(value), true);

                    // --

                    noticeModified(this.fAncestorPlcCondition);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIPlcOperand fOperand
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;                

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagPEP.A_OperandId, FXmlTagPEP.D_OperandId);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    if (this.fOperandType == FPlcOperandType.PlcWord)
                    {
                        xpath =
                            FXmlTagPLM.E_PlcLibraryModeling +
                            "/" + FXmlTagPLG.E_PlcLibraryGroup +
                            "/" + FXmlTagPLB.E_PlcLibrary +
                            "/" + FXmlTagPML.E_PlcMessageList +
                            "/" + FXmlTagPMS.E_PlcMessages +
                            "/" + FXmlTagPMG.E_PlcMessage +
                            "/" + FXmlTagPWL.E_PlcWordList +
                            "/" + FXmlTagPWD.E_PlcWord + "[@" + FXmlTagPWD.A_UniqueId + "='" + id + "']";
                        // --
                        return new FPlcWord(this.fPcdCore, this.fPlcDriver.fXmlNode.selectSingleNode(xpath));
                    }
                    else if (this.fOperandType == FPlcOperandType.Environment)
                    {
                        xpath =
                            FXmlTagSET.E_Setup +
                            "/" + FXmlTagEND.E_EnvironmentDefinition +
                            "/" + FXmlTagENL.E_EnvironmentList +
                            "//" + FXmlTagENV.E_Environment + "[@" + FXmlTagENV.A_UniqueId + "='" + id + "']";
                        // --
                        return new FEnvironment(this.fPcdCore, this.fPlcDriver.fXmlNode.selectSingleNode(xpath));
                    }
                    else if (this.fOperandType == FPlcOperandType.EquipmentState)
                    {
                        xpath =
                            FXmlTagSET.E_Setup +
                            "/" + FXmlTagESD.E_EquipmentStateSetDefinition +
                            "/" + FXmlTagESL.E_EquipmentStateSetList +
                            "/" + FXmlTagESS.E_EquipmentStateSet +
                            "/" + FXmlTagEST.E_EquipmentState + "[@" + FXmlTagEST.A_UniqueId + "='" + id + "']";
                        // --
                        return new FEquipmentState(this.fPcdCore, this.fPlcDriver.fXmlNode.selectSingleNode(xpath));
                    }
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string operandName
        {
            get
            {
                FIPlcOperand fOpd = null;

                try
                {
                    fOpd = this.fOperand;
                    if (fOpd == null)
                    {
                        return string.Empty;
                    }

                    // --

                    if (fOpd.fPlcOperandType == FPlcOperandType.PlcWord)
                    {
                        return ((FPlcWord)fOpd).name;
                    }
                    else if (fOpd.fPlcOperandType == FPlcOperandType.Environment)
                    {
                        return ((FEnvironment)fOpd).name;
                    }
                    else if (fOpd.fPlcOperandType == FPlcOperandType.EquipmentState)
                    {
                        return ((FEquipmentState)fOpd).name;
                    }
                    return string.Empty;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FFormat fOperandFormat
        {
            get
            {
                try
                {
                    return FEnumConverter.toFormat(this.fXmlNode.get_attrVal(FXmlTagPEP.A_OperandFormat, FXmlTagPEP.D_OperandFormat));
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int operandIndex
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagPEP.A_OperandIndex, FXmlTagPEP.D_OperandIndex));
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

            set
            {
                try
                {
                    // ***
                    // Expression Type이 Bracket일 경우 변경할 수 없다.
                    // ***
                    if (this.fExpressionType == FExpressionType.Bracket)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Expression's Type", "Comparison"));
                    }

                    if (this.fComparisonMode == FComparisonMode.Length)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Comparison Mode", "Value"));
                    }

                    if (this.fOperandType == FPlcOperandType.EquipmentState)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0010, "Operand Type", "Equipment State"));
                    }

                    if (value < 0)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0014, "Operand Index"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_OperandIndex, FXmlTagPEP.D_OperandIndex, value.ToString(), true);
                    noticeModified(this.fAncestorPlcCondition);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOperation fOperation
        {
            get
            {
                try
                {
                    return FEnumConverter.toOperation(this.fXmlNode.get_attrVal(FXmlTagPEP.A_Operation, FXmlTagPEP.D_Operation));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FOperation.Equal;
            }

            set
            {
                try
                {
                    // ***
                    // Expression Type이 Bracket일 경우 변경할 수 없다.
                    // ***
                    if (this.fExpressionType == FExpressionType.Bracket)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Expression's Type", "Comparison"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_Operation, FXmlTagPEP.D_Operation, FEnumConverter.fromOperation(value), true);
                    noticeModified(this.fAncestorPlcCondition);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FFormat fValueFormat
        {
            get
            {
                try
                {
                    if (this.fComparisonMode == FComparisonMode.Value)
                    {
                        return this.fOperandFormat;
                    }
                    return FFormat.U4;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string stringValue
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagPEP.A_Value, FXmlTagPEP.D_Value);
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

            set
            {
                FFormat fFormat;
                int length = 0;
                string val = string.Empty;

                try
                {
                    // ***
                    // Expression Type이 Bracket일 경우 변경할 수 없다.
                    // ***
                    if (this.fExpressionType == FExpressionType.Bracket)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Expression's Type", "Comparison"));
                    }

                    if (this.fExpressionValueType != FExpressionValueType.Value)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Expression Value Type", "Value"));
                    }

                    // --

                    fFormat = this.fValueFormat;
                    val = FValueConverter.fromStringValue(fFormat, value, out length);

                    // ***
                    // Format이 Ascii 계열이 아닌 경우, Value의 Length를 1보다 클 수 없다.
                    // ***
                    if (fFormat != FFormat.Ascii && fFormat != FFormat.A2 && fFormat != FFormat.JIS8 && length > 1)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                    }

                    // --
                    
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_Value, FXmlTagPEP.D_Value, val, true);
                    noticeModified(this.fAncestorPlcCondition);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string[] stringArrayValue
        {
            get
            {
                try
                {
                    return FValueConverter.toStringArrayValue(this.fValueFormat, this.stringValue);
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

            set
            {
                FFormat fFormat;
                int length = 0;
                string val = string.Empty;

                try
                {
                    // ***
                    // Expression Type이 Bracket일 경우 변경할 수 없다.
                    // ***
                    if (this.fExpressionType == FExpressionType.Bracket)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Expression's Type", "Comparison"));
                    }

                    if (this.fExpressionValueType != FExpressionValueType.Value)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Expression Value Type", "Value"));
                    }

                    // --

                    fFormat = this.fValueFormat;
                    val = FValueConverter.fromStringArrayValue(fFormat, value, out length);

                    // ***
                    // Format이 Ascii 계열이 아닐 경우, Value의 Length가 1보다 클 수 없다.
                    // ***
                    if (fFormat != FFormat.Ascii && fFormat != FFormat.A2 && fFormat != FFormat.JIS8 && length > 1)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                    }
                    
                    // --

                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_Value, FXmlTagPEP.D_Value, val, true);
                    noticeModified(this.fAncestorPlcCondition);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FExpressionValueType fExpressionValueType
        {
            get
            {
                try
                {
                    return FEnumConverter.toExpressionValueType(this.fXmlNode.get_attrVal(FXmlTagHEP.A_ExpressionValueType, FXmlTagHEP.D_ExpressionValueType));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FExpressionValueType.Value;
            }

            set
            {
                try
                {
                    // ***
                    // Expression Type이 Bracket일 경우 변경할 수 없다.
                    // ***
                    if (this.fExpressionType == FExpressionType.Bracket)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Expression Value Type", "Comparison"));
                    }

                    if (this.fComparisonMode == FComparisonMode.Length)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Comparison Mode", "Value"));
                    }

                    if (this.fOperandType == FPlcOperandType.EquipmentState)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0010, "Operand Type", "Equipment State"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_Resource, FXmlTagHEP.D_Resource, FEnumConverter.fromPlcResourceSourceType(FPlcResourceSourceType.None), false);
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_Value, FXmlTagHEP.D_Value, string.Empty, false);                    
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_ExpressionValueType, FXmlTagHEP.D_ExpressionValueType, FEnumConverter.fromExpressionValueType(value), true);
                    noticeModified(this.fAncestorPlcCondition);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPlcResourceSourceType fResource
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = this.fXmlNode.get_attrVal(FXmlTagPEP.A_Resource, FXmlTagPEP.D_Resource);
                    if (val == string.Empty)
                    {
                        return FPlcResourceSourceType.None;
                    }
                    // --
                    return FEnumConverter.toPlcResourceSourceType(val);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FPlcResourceSourceType.None;
            }

            set
            {
                try
                {
                    if (this.fExpressionValueType != FExpressionValueType.Resource)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Expression Value Type", "Resource"));
                    }
                    // --
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_Resource, FXmlTagPEP.D_Resource, FEnumConverter.fromPlcResourceSourceType(value), true);
                    noticeModified(this.fAncestorPlcCondition);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public object value
        {
            get
            {
                try
                {
                    return FValueConverter.toValue(this.fValueFormat, this.stringValue);
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

            set
            {
                FFormat fFormat;
                int length = 0;
                string val = string.Empty;

                try
                {
                    // ***
                    // Expression Type이 Bracket일 경우 변경할 수 없다.
                    // ***
                    if (this.fExpressionType == FExpressionType.Bracket)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Expression's Type", "Comparison"));
                    }

                    if (this.fExpressionValueType != FExpressionValueType.Value)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Expression Value Type", "Value"));
                    }

                    // --

                    fFormat = this.fValueFormat;
                    val = FValueConverter.fromValue(fFormat, value, out length);

                    // ***
                    // Format이 Ascii 계열이 아닐 경우, Value의 Length를 1보다 클 수 없다.
                    // ***
                    if (fFormat != FFormat.Ascii && fFormat != FFormat.A2 && fFormat != FFormat.JIS8 && length > 1)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                    }
                    
                    // --

                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_Value, FXmlTagPEP.D_Value, val, true);
                    noticeModified(this.fAncestorPlcCondition);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string encodingValue
        {
            get
            {
                try
                {
                    return FValueConverter.toEncodingValue(this.fValueFormat, this.stringValue);
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPlcExpressionValueTransformer fValueTransformer
        {
            get
            {
                try
                {
                    return new FPlcExpressionValueTransformer(this);
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

        public FDataConversionSet fDataConversionSet
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagPEP.A_DataConversionSetID, FXmlTagPEP.D_DataConversionSetID);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    xpath =
                        FXmlTagSET.E_Setup +
                        "/" + FXmlTagDCD.E_DataConversionSetDefinition +
                        "/" + FXmlTagDCL.E_DataConversionSetList +
                        "/" + FXmlTagDCS.E_DataConversionSet + "[@" + FXmlTagDCS.A_UniqueId + "='" + id + "']";
                    // --
                    return new FDataConversionSet(this.fPcdCore, this.fPlcDriver.fXmlNode.selectSingleNode(xpath));
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

        public string dataConversionSetName
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagPEP.A_DataConversionSetName, FXmlTagPEP.D_DataConversionSetName);
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
            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_DataConversionSetName, FXmlTagPEP.D_DataConversionSetName, value, false);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string dataConversionSetExpression
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagPEP.A_DataConversionSetExpression, FXmlTagPEP.D_DataConversionSetExpression);
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
            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_DataConversionSetExpression, FXmlTagPEP.D_DataConversionSetExpression, value, false);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag1
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagPEP.A_UserTag1, FXmlTagPEP.D_UserTag1);
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

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_UserTag1, FXmlTagPEP.D_UserTag1, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag2
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagPEP.A_UserTag2, FXmlTagPEP.D_UserTag2);
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

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_UserTag2, FXmlTagPEP.D_UserTag2, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag3
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagPEP.A_UserTag3, FXmlTagPEP.D_UserTag3);
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

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_UserTag3, FXmlTagPEP.D_UserTag3, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag4
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagPEP.A_UserTag4, FXmlTagPEP.D_UserTag4);
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

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_UserTag4, FXmlTagPEP.D_UserTag4, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag5
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagPEP.A_UserTag5, FXmlTagPEP.D_UserTag5);
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

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_UserTag5, FXmlTagPEP.D_UserTag5, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIObject fParent
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null)
                    {
                        return null;
                    }

                    // --

                    if (this.fXmlNode.fParentNode.name == FXmlTagPCN.E_PlcCondition)
                    {
                        return new FPlcCondition(this.fPcdCore, this.fXmlNode.fParentNode);
                    }
                    return new FPlcExpression(this.fPcdCore, this.fXmlNode.fParentNode);
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

        public string defUserTagName1
        {
            get
            {
                try
                {
                    return this.getDefUserTagName(1);
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string defUserTagName2
        {
            get
            {
                try
                {
                    return this.getDefUserTagName(2);
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string defUserTagName3
        {
            get
            {
                try
                {
                    return this.getDefUserTagName(3);
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string defUserTagName4
        {
            get
            {
                try
                {
                    return this.getDefUserTagName(4);
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string defUserTagName5
        {
            get
            {
                try
                {
                    return this.getDefUserTagName(5);
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPlcExpression fPreviousSibling
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fPreviousSibling == null)
                    {
                        return null;
                    }

                    // --

                    return new FPlcExpression(this.fPcdCore, this.fXmlNode.fPreviousSibling);
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

        public FPlcExpression fNextSibling
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fNextSibling == null)
                    {
                        return null;
                    }

                    // --

                    return new FPlcExpression(this.fPcdCore, this.fXmlNode.fNextSibling);
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

        public FPlcExpressionCollection fChildPlcExpressionCollection
        {
            get
            {
                try
                {
                    return new FPlcExpressionCollection(this.fPcdCore, this.fXmlNode.selectNodes(FXmlTagPEP.E_PlcExpression));
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

        public FObjectNameCollection fObjectNameCollection
        {
            get
            {
                try
                {
                    return this.getObjectNameCollection();
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

        public FObjectCollection fReferenceObjectCollection
        {
            get
            {
                string xpath = string.Empty;

                try
                {
                    if (this.fParent != null)
                    {
                        xpath = 
                            "../../" + FXmlTagPCN.E_PlcCondition + "[@" + FXmlTagPCN.A_UniqueId + "='" + fParent.uniqueIdToString + "']";
                    }
                    return new FObjectCollection(this.fPcdCore, this.fXmlNode.selectNodes(xpath));
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

        public FObjectCollection fInclusionObjectCollection
        {
            get
            {
                string xpath = string.Empty;

                try
                {
                    if (this.fOperand != null)
                    {
                        if (this.fOperandType == FPlcOperandType.PlcWord)
                        {
                            xpath =
                                "../../../../../../../" + FXmlTagPLM.E_PlcLibraryModeling +
                                "/" + FXmlTagPLG.E_PlcLibraryGroup +
                                "/" + FXmlTagPLB.E_PlcLibrary +
                                "/" + FXmlTagPML.E_PlcMessageList +
                                "/" + FXmlTagPMS.E_PlcMessages +
                                "/" + FXmlTagPMG.E_PlcMessage +
                                "/" + FXmlTagPWL.E_PlcWordList +
                                "/" + FXmlTagPWD.E_PlcWord + "[@" + FXmlTagPWD.A_UniqueId + "='" + ((FPlcWord)this.fOperand).uniqueIdToString + "']";
                        }
                        else if (this.fOperand.fPlcOperandType == FPlcOperandType.Environment)
                        {
                            xpath =
                            "../../../../../../../" + FXmlTagSET.E_Setup + "/" + FXmlTagEND.E_EnvironmentDefinition +
                            "/" + FXmlTagENL.E_EnvironmentList +
                            "//" + FXmlTagENV.E_Environment + "[@" + FXmlTagENV.A_UniqueId + "='" + ((FEnvironment)this.fOperand).uniqueIdToString + "']";
                        }
                        else if (this.fOperand.fPlcOperandType == FPlcOperandType.EquipmentState)
                        {
                            xpath =
                            "../../../../../../../" + FXmlTagSET.E_Setup +
                            "/" + FXmlTagESD.E_EquipmentStateSetDefinition +
                            "/" + FXmlTagESL.E_EquipmentStateSetList +
                            "/" + FXmlTagESS.E_EquipmentStateSet +
                            "/" + FXmlTagEST.E_EquipmentState + "[@" + FXmlTagEST.A_UniqueId + "='" + ((FEquipmentState)this.fOperand).uniqueIdToString + "']";
                            // --
                        }
                    }
                    else
                    {
                        xpath = "NULL";
                    }
                    // --                    
                    return new FObjectCollection(this.fPcdCore, this.fXmlNode.selectNodes(xpath));
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

        public bool hasChild
        {
            get
            {
                try
                {
                    return this.fXmlNode.containsNode(FXmlTagPEP.E_PlcExpression);
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool hasOperand
        {
            get
            {
                try
                {
                    if (this.fXmlNode.get_attrVal(FXmlTagPEP.A_OperandId, FXmlTagPEP.D_OperandId) == string.Empty)
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

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool hasValueTransformer
        {
            get
            {
                try
                {
                    if (this.fXmlNode.get_attrVal(FXmlTagPEP.A_Transformer, FXmlTagPEP.D_Transformer) == string.Empty)
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

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool hasDataConversionSet
        {
            get
            {
                try
                {
                    if (this.fXmlNode.get_attrVal(FXmlTagPEP.A_DataConversionSetID, FXmlTagPEP.D_DataConversionSetID) == string.Empty)
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

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canAppendChild
        {
            get
            {
                try
                {
                    if (this.fExpressionType == FExpressionType.Bracket)
                    {
                        return true;
                    }
                    return false;
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
        }

        //-----------------------------------------------------------------------------------------------------------------------

        public bool canInsertBefore
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null)
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

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canInsertAfter
        {
            get
            {
                try
                {
                    return this.canInsertBefore;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canRemove
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null)
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

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canMoveUp
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null || this.fXmlNode.fPreviousSibling == null)
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

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canMoveDown
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null || this.fXmlNode.fNextSibling == null)
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

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canUseValueTransformer
        {
            get
            {
                FFormat fFormat;

                try
                {
                    fFormat = this.fOperandFormat;

                    // --

                    if (!this.hasOperand || fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
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

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPlcCondition fAncestorPlcCondition
        {
            get
            {
                try
                {
                    return this.getAncestorPlcCondition();
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

        public bool canCopy
        {
            get
            {
                try
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canCut
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null)
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

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canPasteSibling
        {
            get
            {
                try
                {
                    if (
                        this.fXmlNode.fParentNode == null ||
                        !FClipboard.containsData(FCbObjectFormat.PlcExpression)
                        )
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

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canPasteChild
        {
            get
            {
                try
                {
                    if (!FClipboard.containsData(FCbObjectFormat.PlcExpression))
                    {
                        return false;
                    }

                    // --

                    if (this.fExpressionType != FExpressionType.Bracket)
                    {
                        return false;
                    }

                    // --

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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public string ToString(
            FStringOption option
            )
        {
            string info = string.Empty;
            FIPlcOperand fOpd = null;
            FFormat fFormat;

            try
            {
                if (option == FStringOption.Default)
                {
                    info = this.name;
                }
                else
                {
                    if (this.hasValueTransformer)
                    {
                        info += "[vt.] ";
                    }

                    // --

                    if (this.hasDataConversionSet)
                    {
                        info += "[dc.] ";
                    }

                    // --

                    info += this.name;

                    // --

                    if (this.fPreviousSibling != null)
                    {
                        info += " Lgc.=[" + FEnumConverter.toLogicalExp(this.fLogical) + "]";
                    }

                    // --

                    if (this.fExpressionType == FExpressionType.Comparison)
                    {
                        fFormat = this.fValueFormat;
                        fOpd = this.fOperand;

                        // --

                        info += " Exp.=[";
                        if (fOpd == null)
                        {
                            info += "'N/A'";
                        }
                        else if (fOpd.fPlcOperandType == FPlcOperandType.PlcWord)
                        {
                            info += ((FPlcWord)fOpd).name;
                        }
                        else if (fOpd.fPlcOperandType == FPlcOperandType.Environment)
                        {
                            info += ((FEnvironment)fOpd).name;
                        }
                        else if (fOpd.fPlcOperandType == FPlcOperandType.EquipmentState)
                        {
                            info += ((FEquipmentState)fOpd).name;
                        }
                        info += "[" + this.operandIndex.ToString() + "]";
                        // --
                        info += " " + FEnumConverter.toOperationExp(this.fOperation) + " ";
                        // --
                        if (fExpressionValueType == FExpressionValueType.Value)
                        {
                            if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2)
                            {
                                info += "\"" + this.encodingValue + "\"";
                            }
                            else
                            {
                                info += "\"" + this.stringValue + "\"";
                            }
                        }
                        else
                        {
                            info += this.fResource.ToString();
                        }
                        info += "]";
                    }    
                }                            

                // --
                
                if (this.description != string.Empty)
                {
                    info += (" Desc=[" + this.description + "]");
                }

                // --
                
                return info;
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

        public FPlcExpression appendChildPlcExpression(
           FPlcExpression fNewChild
           )
        {
            try
            {
                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // ***
                // PLC Expression의 Type이 Comparison일 경우 PLC Expression를 추가할 수 없다.
                // ***
                if (this.fExpressionType == FExpressionType.Comparison)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Expression's Type", "Bracket"));
                }

                // --

                fNewChild.replace(this.fPcdCore, this.fXmlNode.appendChild(fNewChild.fXmlNode));
                // --                
                if (this.isModelingObject)
                {
                    FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fPcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectAppendCompleted, this.fPlcDriver, this, fNewChild)
                        );
                    noticeModified(this.fAncestorPlcCondition);
                }

                // --

                return fNewChild;
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

        public FPlcExpression insertBeforeChildPlcExpression(
            FPlcExpression fNewChild,
            FPlcExpression fRefChild
            )
        {
            try
            {
                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FPlcDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // ***
                // PLC Expression의 Type이 Comparison일 경우 PLC Expression를 추가할 수 없다.
                // ***
                if (this.fExpressionType == FExpressionType.Comparison)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Expression's Type", "Bracket"));
                }

                // --

                fNewChild.replace(this.fPcdCore, this.fXmlNode.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                // --                
                if (this.isModelingObject)
                {
                    FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                    // ---
                    this.fPcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectInsertBeforeCompleted, this.fPlcDriver, this, fNewChild)
                        );
                    noticeModified(this.fAncestorPlcCondition);
                }

                // --

                return fNewChild;
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

        public FPlcExpression insertAfterChildPlcExpression(
            FPlcExpression fNewChild,
            FPlcExpression fRefChild
            )
        {
            try
            {
                FPlcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FPlcDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // ***
                // PLC Expression의 Type이 Comparison일 경우 PLC Expression를 추가할 수 없다.
                // ***
                if (this.fExpressionType == FExpressionType.Comparison)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Expression's Type", "Bracket"));
                }

                // --

                fNewChild.replace(this.fPcdCore, this.fXmlNode.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                // --                
                if (this.isModelingObject)
                {
                    FPlcDriverCommon.resetUniqueId(this.fPcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fPcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this.fPlcDriver, this, fNewChild)
                        );
                    noticeModified(this.fAncestorPlcCondition);
                }

                // --

                return fNewChild;
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

        public void remove(
            )
        {
            FPlcCondition fPcn = null;
            FIObject fParent = null;
            FPlcExpression fNextPlp = null;
            bool isModelingObject = false;

            try
            {
                FPlcDriverCommon.validateRemoveChildObject(this.fXmlNode.fParentNode, this.fXmlNode);                

                // --

                resetRelation();

                // --

                fPcn = this.fAncestorPlcCondition;
                fParent = this.fParent;
                fNextPlp = this.fNextSibling;
                isModelingObject = this.isModelingObject;                
                this.replace(this.fPcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                
                // --

                // ***
                // 제거되는 Object의 다음 Object가 최상위일 경우 Logical를 And로 변경한다.
                // ***
                if (fNextPlp != null && fNextPlp.fPreviousSibling == null)
                {
                    fNextPlp.fXmlNode.set_attrVal(FXmlTagPEP.A_Logical, FXmlTagPEP.D_Logical, FEnumConverter.fromLogical(FLogical.And), true);
                }

                // --

                if (isModelingObject)
                {
                    this.fPcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectRemoveCompleted, this.fPlcDriver, fParent, this)
                        );
                    noticeModified(fPcn);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPcn = null;
                fParent = null;
                fNextPlp = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPlcExpression removeChildPlcExpression(
            FPlcExpression fChild
            )
        {
            try
            {
                FPlcDriverCommon.validateRemoveChildObject(this.fXmlNode, fChild.fXmlNode);

                // --

                fChild.remove();

                // --

                return fChild;
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

        public void removeChildPlcExpression(
            FPlcExpression[] fChilds
            )
        {
            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                foreach (FPlcExpression fPlp in fChilds)
                {
                    FPlcDriverCommon.validateRemoveChildObject(this.fXmlNode, fPlp.fXmlNode);
                }

                // --

                foreach (FPlcExpression fPlp in fChilds)
                {
                    fPlp.remove();
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

        public void removeAllChildPlcExpression(
            )
        {
            FPlcExpressionCollection fPlpCollction = null;

            try
            {
                fPlpCollction = this.fChildPlcExpressionCollection;
                if (fPlpCollction.count == 0)
                {
                    return;
                }

                // --

                foreach (FPlcExpression fPlp in fPlpCollction)
                {
                    fPlp.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fPlpCollction != null)
                {
                    fPlpCollction.Dispose();
                    fPlpCollction = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void setOperand(
            FPlcBit fPlcBit
            )
        {
            string oldPbtId = string.Empty;
            string newPbtId = string.Empty;

            try
            {
                // ***
                // PLC Bit 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fPlcBit.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "PLC Bit", "Modeling File"));
                }

                // ***
                // PLC Expression 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "PLC Expression", "Modeling File"));
                }

                // ***
                // PLC Bit와 PLC Expression의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fPlcBit))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the PLC Bit and the PLC Expression", "same"));
                }

                // ***
                // PLC Condition에 PLC Read Message가 설정되어 있는지 검사
                // ***
                if (!this.fAncestorPlcCondition.hasMessage)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "PLC Read Message in the PLC Condition"));
                }

                // ***
                // PLC Bit의 조상 PLC Read Message가 PLC Condition에 설정된 PLC Read Message와 동일한지 검사
                // ***
                if (this.fAncestorPlcCondition.fMessage != fPlcBit.fAncestorPlcMessage)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "PLC Read Message of the PLC Bit and the PLC Condition", "same"));
                }

                // --

                oldPbtId = this.fXmlNode.get_attrVal(FXmlTagPEP.A_OperandId, FXmlTagPEP.D_OperandId);
                newPbtId = fPlcBit.uniqueIdToString;
                // --
                if (oldPbtId == newPbtId)
                {
                    return;
                }

                // --

                // ***
                // 이전에 설정된 Operand가 존재할 경우 Reset 한다.
                // ***
                if (oldPbtId != string.Empty)
                {
                    resetOperand(false);
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagPEP.A_OperandFormat, FXmlTagPEP.D_OperandFormat, FEnumConverter.fromPlcWordFormat(FPlcWordFormat.Binary), false);
                this.fXmlNode.set_attrVal(FXmlTagPEP.A_Value, FXmlTagPEP.D_Value, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagPEP.A_Transformer, FXmlTagPEP.D_Transformer, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagPEP.A_OperandId, FXmlTagPEP.D_OperandId, newPbtId, true);
                // --
                fPlcBit.lockObject();
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

        private void setOperand(
            FPlcWord fPlcWord
            )
        {
            string oldPwdId = string.Empty;
            string newPwdId = string.Empty;

            try
            {
                // ***
                // PLC Word 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fPlcWord.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "PLC Word", "Modeling File"));
                }

                // ***
                // PLC Expression 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "PLC Expression", "Modeling File"));
                }

                // ***
                // PLC Word와 PLC Expression의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fPlcWord))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the PLC Word and the PLC Expression", "same"));
                }

                // ***
                // PLC Condition에 PLC Message가 설정되어 있는지 검사
                // ***
                if (!this.fAncestorPlcCondition.hasMessage)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "PLC Message in the PLC Condition"));
                }

                // ***
                // PLC Word의 조상 PLC Message가 PLC Condition에 설정된 PLC Message와 동일한지 검사
                // ***
                if (this.fAncestorPlcCondition.fMessage != fPlcWord.fAncestorPlcMessage)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "PLC Message of the PLC Word and the PLC Condition", "same"));
                }

                // --

                oldPwdId = this.fXmlNode.get_attrVal(FXmlTagPEP.A_OperandId, FXmlTagPEP.D_OperandId);
                newPwdId = fPlcWord.uniqueIdToString;
                // --
                if (oldPwdId == newPwdId)
                {
                    return;
                }

                // --

                // ***
                // 이전에 설정된 Operand가 존재할 경우 Reset 한다.
                // ***
                if (oldPwdId != string.Empty)
                {
                    resetOperand(false);
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagPEP.A_OperandFormat, FXmlTagPEP.D_OperandFormat, FEnumConverter.fromPlcWordFormat(fPlcWord.fFormat), false);
                this.fXmlNode.set_attrVal(FXmlTagPEP.A_Value, FXmlTagPEP.D_Value, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagPEP.A_Transformer, FXmlTagPEP.D_Transformer, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagPEP.A_OperandId, FXmlTagPEP.D_OperandId, newPwdId, true);
                // --
                fPlcWord.lockObject();
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

        private void setOperand(
            FEnvironment fEnvironment
            )
        {
            string oldEnvId = string.Empty;
            string newEnvId = string.Empty;
            FFormat fFormat;

            try
            {
                // ***
                // Environment 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fEnvironment.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Environment", "Modeling File"));
                }

                // ***
                // PLC Expression 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "PLC Expression", "Modeling File"));
                }

                // ***
                // Environment와 PLC Expression의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fEnvironment))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the Environment and the PLC Expression", "same"));
                }

                // ***
                // Operand Format이 List, AsciiList, Raw일 경우 Comaprsion Mode가 Length 인지 검사
                // ***
                fFormat = fEnvironment.fFormat;
                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Raw || fFormat == FFormat.Unknown)
                {
                    if (this.fComparisonMode != FComparisonMode.Length)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Comparison Mode", "Length"));
                    }
                }

                // --

                oldEnvId = this.fXmlNode.get_attrVal(FXmlTagPEP.A_OperandId, FXmlTagPEP.D_OperandId);
                newEnvId = fEnvironment.uniqueIdToString;
                // --
                if (oldEnvId == newEnvId)
                {
                    return;
                }

                // --

                // ***
                // 이전에 설정된 Operand가 존재할 경우 Reset 한다.
                // ***
                if (oldEnvId != newEnvId)
                {
                    resetOperand(false);
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagPEP.A_OperandFormat, FXmlTagPEP.D_OperandFormat, FEnumConverter.fromFormat(fFormat), false);
                this.fXmlNode.set_attrVal(FXmlTagPEP.A_Value, FXmlTagPEP.D_Value, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagPEP.A_Transformer, FXmlTagPEP.D_Transformer, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagPEP.A_OperandId, FXmlTagPEP.D_OperandId, newEnvId, true);
                // --
                fEnvironment.lockObject();
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

        private void setOperand(
            FEquipmentState fEquipmentState
            )
        {
            string oldEstId = string.Empty;
            string newEstId = string.Empty;

            try
            {
                // ***
                // Equipment State 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fEquipmentState.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Equipment State", "Modeling File"));
                }

                // ***
                // PLC Expression 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "PLC Expression", "Modeling File"));
                }

                // ***
                // Equipment State와 PLC Expression의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fEquipmentState))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the Equipment State and the SECS Expression", "same"));
                }

                // --

                oldEstId = this.fXmlNode.get_attrVal(FXmlTagPEP.A_OperandId, FXmlTagPEP.D_OperandId);
                newEstId = fEquipmentState.uniqueIdToString;
                // --
                if (oldEstId == newEstId)
                {
                    return;
                }

                // --

                // ***
                // 이전에 설정된 Operand가 존재할 경우 Reset 한다.
                // ***
                if (oldEstId != newEstId)
                {
                    resetOperand(false);
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagPEP.A_OperandFormat, FXmlTagPEP.D_OperandFormat, FEnumConverter.fromFormat(FFormat.Ascii), false);
                this.fXmlNode.set_attrVal(FXmlTagPEP.A_OperandIndex, FXmlTagPEP.D_OperandIndex, FXmlTagPEP.D_OperandIndex, false);
                this.fXmlNode.set_attrVal(FXmlTagPEP.A_Value, FXmlTagPEP.D_Value, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagPEP.A_Transformer, FXmlTagPEP.D_Transformer, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagPEP.A_OperandId, FXmlTagPEP.D_OperandId, newEstId, true);
                // --
                fEquipmentState.lockObject();
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

        public void setOperand(
            FIPlcOperand fPlcOperand
            )
        {
            try
            {
                // ***
                // Expression Type이 Bracket일 경우 Operand를 설정할 수 없다.
                // ***
                if (this.fExpressionType == FExpressionType.Bracket)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Expression's Type", "Comparison"));
                }
                
                // --

                if (this.fOperandType == FPlcOperandType.PlcWord)
                {
                    if (fPlcOperand.fPlcOperandType != FPlcOperandType.PlcWord)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Operand's Type", "PLC Word"));
                    }
                    // --
                    setOperand((FPlcWord)fPlcOperand);
                }
                else if (this.fOperandType == FPlcOperandType.Environment)
                {
                    if (fPlcOperand.fPlcOperandType != FPlcOperandType.Environment)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Operand's Type", "Environment"));
                    }
                    // --
                    setOperand((FEnvironment)fPlcOperand);
                }
                else if (this.fOperandType == FPlcOperandType.EquipmentState)
                {
                    if (fPlcOperand.fPlcOperandType != FPlcOperandType.EquipmentState)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Operand's Type", "EquipmentState"));
                    }
                    // --
                    setOperand((FEquipmentState)fPlcOperand);
                }
                // --
                noticeModified(this.fAncestorPlcCondition);
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

        internal void resetOperand(
            bool isModifyEvent
            )
        {
            FIPlcOperand fOpd = null;

            try
            {
                foreach (FPlcExpression fSep in this.fChildPlcExpressionCollection)
                {
                    fSep.resetOperand(isModifyEvent);
                }

                // --

                fOpd = this.fOperand;
                if (fOpd == null)
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagPEP.A_OperandFormat, FXmlTagPEP.D_OperandFormat, FEnumConverter.fromFormat(FFormat.Ascii), false);
                this.fXmlNode.set_attrVal(FXmlTagPEP.A_OperandIndex, FXmlTagPEP.D_OperandIndex, "0", false);
                this.fXmlNode.set_attrVal(FXmlTagPEP.A_Value, FXmlTagPEP.D_Value, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagPEP.A_Transformer, FXmlTagPEP.D_Transformer, string.Empty, false);
                // --
                resetDataConversionSet(false);
                // --
                this.fXmlNode.set_attrVal(FXmlTagPEP.A_OperandId, FXmlTagPEP.D_OperandId, string.Empty, isModifyEvent);
                // --
                if (isModifyEvent)
                {
                    noticeModified(this.fAncestorPlcCondition);
                }

                // --

                if (fOpd.fPlcOperandType == FPlcOperandType.PlcWord)
                {
                    ((FPlcWord)fOpd).unlockObject();
                }
                else if (fOpd.fPlcOperandType == FPlcOperandType.Environment)
                {
                    ((FEnvironment)fOpd).unlockObject();
                }
                else if (fOpd.fPlcOperandType == FPlcOperandType.EquipmentState)
                {
                    ((FEquipmentState)fOpd).unlockObject();
                }  
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fOpd = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void resetOperand(
            )
        {
            try
            {
                resetOperand(true);
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

        internal void resetRelation(
            )
        {
            try
            {
                resetOperand(false);
                resetDataConversionSet(false);
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

        internal void noticeModified(
            FPlcCondition fPcn
            )
        {
            try
            {
                if (fPcn != null)
                {
                    fPcn.noticeChildModified();
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

        internal static void resetFlowNode(
            FXmlNode fXmlNode
            )
        {
            try
            {
                fXmlNode.set_attrVal(FXmlTagPEP.A_OperandId, FXmlTagPEP.D_OperandId, FXmlTagPEP.D_OperandId);
                fXmlNode.set_attrVal(FXmlTagPEP.A_OperandFormat, FXmlTagPEP.D_OperandFormat, FXmlTagPEP.D_OperandFormat);
                fXmlNode.set_attrVal(FXmlTagPEP.A_OperandIndex, FXmlTagPEP.D_OperandIndex, FXmlTagPEP.D_OperandIndex);
                fXmlNode.set_attrVal(FXmlTagPEP.A_Value, FXmlTagPEP.D_Value, FXmlTagPEP.D_Value);
                fXmlNode.set_attrVal(FXmlTagPEP.A_Transformer, FXmlTagPEP.D_Transformer, FXmlTagPEP.D_Transformer);
                fXmlNode.set_attrVal(FXmlTagPEP.A_DataConversionSetExpression, FXmlTagPEP.D_DataConversionSetExpression, string.Empty);
                fXmlNode.set_attrVal(FXmlTagPEP.A_DataConversionSetName, FXmlTagPEP.D_DataConversionSetName, string.Empty);
                fXmlNode.set_attrVal(FXmlTagPEP.A_DataConversionSetID, FXmlTagPEP.D_DataConversionSetID, string.Empty);
                
                // --

                foreach (FXmlNode fXmlNodeSep in fXmlNode.selectNodes(FXmlTagPEP.E_PlcExpression))
                {
                    FPlcExpression.resetFlowNode(fXmlNodeSep);                    
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

        public void copy(
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.clone(true);

                // --

                resetFlowNode(fXmlNode);
                this.copyObject(FCbObjectFormat.PlcExpression, fXmlNode);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void cut(
            )
        {
            try
            {
                FPlcDriverCommon.validateCutObject(this.fXmlNode);

                // --

                this.remove();

                // --

                resetFlowNode(this.fXmlNode);
                this.copyObject(FCbObjectFormat.PlcExpression, this.fXmlNode);
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

        public FPlcExpression pasteSibling(
            )
        {
            FIObject fParent = null;
            FPlcExpression fPlcExpression = null;
            
            try
            {
                FPlcDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.PlcExpression);

                // --
                
                fParent = this.fParent;

                fPlcExpression = (FPlcExpression)this.pasteObject(FCbObjectFormat.PlcExpression);
                if (fParent.fObjectType == FObjectType.PlcCondition)
                {
                    return ((FPlcCondition)fParent).insertAfterChildPlcExpression(fPlcExpression, this);
                }
                return ((FPlcExpression)fParent).insertAfterChildPlcExpression(fPlcExpression, this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPlcExpression = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPlcExpression pasteChild(
           )
        {
            FPlcExpression fPlcExpression = null;

            try
            {
                FPlcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.PlcExpression);

                // --

                fPlcExpression = (FPlcExpression)this.pasteObject(FCbObjectFormat.PlcExpression);
                this.appendChildPlcExpression(fPlcExpression);

                return fPlcExpression;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPlcExpression = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void moveUp(
            )
        {
            bool isModelingObject = false;

            try
            {
                FPlcDriverCommon.validateMoveUpObject(this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fPcdCore, this.fXmlNode.moveUp());

                // --

                if (this.fXmlNode.fPreviousSibling == null)
                {
                    this.fXmlNode.set_attrVal(FXmlTagPEP.A_Logical, FXmlTagPEP.D_Logical, FEnumConverter.fromLogical(FLogical.And));
                }

                // --

                if (isModelingObject)
                {
                    this.fPcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveUpCompleted, this.fPlcDriver, fParent, this)
                        );
                    noticeModified(this.fAncestorPlcCondition);
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

        public void moveDown(
            )
        {
            bool isModelingObject = false;

            try
            {
                FPlcDriverCommon.validateMoveDownObject(this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fPcdCore, this.fXmlNode.moveDown());

                // --

                if (isModelingObject)
                {
                    this.fPcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveDownCompleted, this.fPlcDriver, fParent, this)
                        );
                    noticeModified(this.fAncestorPlcCondition);
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

        public void moveTo(
            FPlcExpression fRefObject
            )
        {
            try
            {
                FPlcDriverCommon.validateMoveToObject(this.fXmlNode, fRefObject.fXmlNode);

                // --

                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Object", "Modeling Object"));
                }

                if (!fRefObject.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Reference Object", "Modeling Object"));
                }

                if (!this.equalsModelingFile(fRefObject))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Modeling File", "same"));
                }

                if (!this.fAncestorPlcCondition.Equals(fRefObject.fAncestorPlcCondition))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Ancestor PLC Condition ", "same"));
                }

                // --

                this.replace(this.fPcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fPcdCore, fRefObject.fXmlNode.fParentNode.insertAfter(this.fXmlNode, fRefObject.fXmlNode));

                // --

                this.fPcdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fPlcDriver, this, fRefObject)
                    );
                noticeModified(this.fAncestorPlcCondition);
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

        public void moveTo(
            FPlcCondition fRefObject
            )
        {
            try
            {
                FPlcDriverCommon.validateMoveToObject(this.fXmlNode, fRefObject.fXmlNode);

                // --

                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Object", "Modeling Object"));
                }

                if (!fRefObject.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Reference Object", "Modeling Object"));
                }

                if (!this.equalsModelingFile(fRefObject))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Modeling File", "same"));
                }

                if (!this.fAncestorPlcCondition.Equals(fRefObject))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Ancestor PLC Condition ", "same"));
                }

                if (fRefObject.fChildPlcExpressionCollection.count > 0)
                {
                    if (this.Equals(fRefObject.fChildPlcExpressionCollection[fRefObject.fChildPlcExpressionCollection.count - 1]))
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0060, "Object", "same localtion"));
                    }
                }

                // --

                this.replace(this.fPcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fPcdCore, fRefObject.fXmlNode.appendChild(this.fXmlNode));

                // --

                this.fPcdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fPlcDriver, this, fRefObject)
                    );
                noticeModified(this.fAncestorPlcCondition);
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

        public void setDataConversionSet(
            FDataConversionSet fDataConversionSet
            )
        {
            FFormat fFormat;
            string oldDcsId = string.Empty;
            string newDcsId = string.Empty;

            try
            {
                // ***
                // Data Conversion Set 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fDataConversionSet.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Data Conversion Set", "Modeling File"));
                }

                // ***
                // 이 Plc Expression 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Plc Expression", "Modeling File"));
                }

                // ***
                // Data Conversion Set와 Secs Expression 의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fDataConversionSet))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the Data Conversion Set and the Secs Expression", "same"));
                }

                // --

                if (this.fExpressionType == FExpressionType.Bracket)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0006, "Bracket Expression Type", "Data Conversion Set"));
                }

                if (!this.hasOperand)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "Operand"));
                }

                fFormat = this.fOperandFormat;
                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0006, fFormat.ToString() + " Format", "Data Conversion Set"));
                }

                // --

                oldDcsId = this.fXmlNode.get_attrVal(FXmlTagPEP.A_DataConversionSetID, FXmlTagPEP.D_DataConversionSetID);
                newDcsId = fDataConversionSet.uniqueIdToString;
                if (oldDcsId == newDcsId)
                {
                    return;
                }

                // --

                if (oldDcsId != string.Empty)
                {
                    resetDataConversionSet(false);
                }

                // --
                
                this.fXmlNode.set_attrVal(FXmlTagPEP.A_DataConversionSetExpression, FXmlTagPEP.D_DataConversionSetExpression, fDataConversionSet.expression, false);
                this.fXmlNode.set_attrVal(FXmlTagPEP.A_DataConversionSetName, FXmlTagPEP.D_DataConversionSetName, fDataConversionSet.name, false);
                this.fXmlNode.set_attrVal(FXmlTagPEP.A_DataConversionSetID, FXmlTagPEP.D_DataConversionSetID, newDcsId, true);
                // --
                fDataConversionSet.lockObject();
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

        internal void resetDataConversionSet(
            bool isModifyEvent
            )
        {
            FDataConversionSet fDcs = null;

            try
            {
                foreach (FPlcExpression fPlp in this.fChildPlcExpressionCollection)
                {
                    fPlp.resetDataConversionSet(isModifyEvent);
                }

                // --

                fDcs = this.fDataConversionSet;
                if (fDcs == null)
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagPEP.A_DataConversionSetExpression, FXmlTagPEP.D_DataConversionSetExpression, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagPEP.A_DataConversionSetName, FXmlTagPEP.D_DataConversionSetName, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagPEP.A_DataConversionSetID, FXmlTagPEP.D_DataConversionSetID, string.Empty, isModifyEvent);
                // --
                fDcs.unlockObject();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fDcs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void resetDataConversionSet(
            )
        {
            try
            {
                resetDataConversionSet(true);
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
