/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FJudgementExpression.cs
--  Creator         : spike.lee
--  Create Date     : 2012.01.19
--  Description     : FAMate Core FaOpcDriver JudgementExpression Class 
--  History         : Created by spike.lee at 2012.01.19
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    public class FJudgementExpression : FBaseObject<FJudgementExpression>, FIObject
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FJudgementExpression(
            FOpcDriver fOpcDriver
            )
            : base(fOpcDriver.fOcdCore, FOpcDriverCommon.createXmlNodeJEP(fOpcDriver.fOcdCore.fXmlDoc))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FJudgementExpression(            
            FOcdCore fOcdCore,
            FXmlNode fXmlNode
            )
            : base(fOcdCore, fXmlNode)
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FJudgementExpression(
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
                    return FObjectType.JudgementExpression;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.JudgementExpression;
            }
        }       

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagJEP.A_UniqueId, FXmlTagJEP.D_UniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagJEP.A_Name, FXmlTagJEP.D_Name);
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
                    FOpcDriverCommon.validateName(value, true);

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_Name, FXmlTagJEP.D_Name, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagJEP.A_Description, FXmlTagJEP.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_Description, FXmlTagJEP.D_Description, value, true);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagJEP.A_FontColor, FXmlTagJEP.D_FontColor));
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
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_FontColor, FXmlTagJEP.D_FontColor, value.Name, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagJEP.A_FontBold, FXmlTagJEP.D_FontBold));
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
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_FontBold, FXmlTagJEP.D_FontBold, FBoolean.fromBool(value), true);
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
                    return FEnumConverter.toLogical(this.fXmlNode.get_attrVal(FXmlTagJEP.A_Logical, FXmlTagJEP.D_Logical));
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
                    // 첫번째 Judgement Expression인 경우 Logical를 변경할 수 없다.
                    // ***
                    if (this.fPreviousSibling == null)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0008, "First Expression", "Logical"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_Logical, FXmlTagJEP.D_Logical, FEnumConverter.fromLogical(value), true);
                    noticeModified(this.fAncestorJudgementCondition);
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
                    return FEnumConverter.toExpressionType(this.fXmlNode.get_attrVal(FXmlTagJEP.A_ExpressionType, FXmlTagJEP.D_ExpressionType));
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
                    // 자식 Judgement Expression이 존재할 경우 Expression Type를 변경할 수 없다.
                    // ***
                    if (this.hasChild)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0013, "Object's Child"));
                    }  

                    // --

                    resetOperand(false);
                    resetOperandValue(false);

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_ComparisonMode, FXmlTagJEP.D_ComparisonMode, FEnumConverter.fromComparisonMode(FComparisonMode.Value));
                    // --
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandIndexType, FXmlTagJEP.D_OperandIndexType, FEnumConverter.fromOperandIndexType(FOperandIndexType.All));
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandIndexOption, FXmlTagJEP.D_OperandIndexOption, FEnumConverter.fromOperandIndexOption(FOperandIndexOption.Or));
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandIndex, FXmlTagJEP.D_OperandIndex, "0", false);
                    // --                        
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_Operation, FXmlTagJEP.D_Operation, FEnumConverter.fromOperation(FOperation.Equal), false);
                    // --
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandValueType, FXmlTagJEP.D_OperandValueType, FEnumConverter.fromOperandValueType(FOperandValueType.Value));
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandValueIndexType, FXmlTagJEP.D_OperandValueIndexType, FEnumConverter.fromOperandIndexType(FOperandIndexType.All));
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandValueIndexOption, FXmlTagJEP.D_OperandValueIndexOption, FEnumConverter.fromOperandIndexOption(FOperandIndexOption.Or));
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandValueIndex, FXmlTagJEP.D_OperandValueIndex, "0", false);
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_Value, FXmlTagJEP.D_Value, string.Empty, false);
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_Transformer, FXmlTagJEP.D_Transformer, string.Empty, false);
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_ExpressionType, FXmlTagJEP.D_ExpressionType, FEnumConverter.fromExpressionType(value), true);
                    // --
                    noticeModified(this.fAncestorJudgementCondition);
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
                    return FEnumConverter.toComparisonMode(this.fXmlNode.get_attrVal(FXmlTagJEP.A_ComparisonMode, FXmlTagJEP.D_ComparisonMode));
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
                    resetOperandValue(false);

                    // --                    

                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandIndexType, FXmlTagJEP.D_OperandIndexType, FEnumConverter.fromOperandIndexType(FOperandIndexType.All));
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandIndexOption, FXmlTagJEP.D_OperandIndexOption, FEnumConverter.fromOperandIndexOption(FOperandIndexOption.Or));
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandIndex, FXmlTagJEP.D_OperandIndex, "0", false);
                    // --                        
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_Operation, FXmlTagJEP.D_Operation, FEnumConverter.fromOperation(FOperation.Equal), false);
                    // --
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandValueType, FXmlTagJEP.D_OperandValueType, FEnumConverter.fromOperandValueType(FOperandValueType.Value));
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandValueIndexType, FXmlTagJEP.D_OperandValueIndexType, FEnumConverter.fromOperandIndexType(FOperandIndexType.All));
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandValueIndexOption, FXmlTagJEP.D_OperandValueIndexOption, FEnumConverter.fromOperandIndexOption(FOperandIndexOption.Or));
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandValueIndex, FXmlTagJEP.D_OperandValueIndex, "0", false);
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_Value, FXmlTagJEP.D_Value, string.Empty);
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_Transformer, FXmlTagJEP.D_Transformer, string.Empty);
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_ComparisonMode, FXmlTagJEP.D_ComparisonMode, FEnumConverter.fromComparisonMode(value), true);

                    // --

                    noticeModified(this.fAncestorJudgementCondition);
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

        public FData fOperand
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagJEP.A_OperandId, FXmlTagJEP.D_OperandId);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    xpath =
                        FXmlTagSET.E_Setup +
                        "/" + FXmlTagDSD.E_DataSetDefinition +
                        "/" + FXmlTagDSL.E_DataSetList +
                        "/" + FXmlTagDTS.E_DataSet +
                        "//" + FXmlTagDAT.E_Data + "[@" + FXmlTagDAT.A_UniqueId + "='" + id + "']";
                    // --
                    return new FData(this.fOcdCore, this.fOpcDriver.fXmlNode.selectSingleNode(xpath));
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
                try
                {
                    if (this.hasOperand)
                    {
                        return this.fOperand.name;
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
                    return FEnumConverter.toFormat(this.fXmlNode.get_attrVal(FXmlTagJEP.A_OperandFormat, FXmlTagJEP.D_OperandFormat));
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

        public FOperandIndexType fOperandIndexType
        {
            get
            {
                try
                {
                    return FEnumConverter.toOperandIndexType(this.fXmlNode.get_attrVal(FXmlTagJEP.A_OperandIndexType, FXmlTagJEP.D_OperandIndexType));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FOperandIndexType.All;
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

                    if (value == FOperandIndexType.All)
                    {
                        this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandIndex, FXmlTagJEP.D_OperandIndex, "0");
                    }
                    else
                    {
                        this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandIndexOption, FXmlTagJEP.D_OperandIndexOption, FXmlTagJEP.D_OperandIndex);
                    }
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandIndexType, FXmlTagJEP.D_OperandIndexType, FEnumConverter.fromOperandIndexType(value), true);
                    noticeModified(this.fAncestorJudgementCondition);
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

        public FOperandIndexOption fOperandIndexOption
        {
            get
            {
                try
                {
                    return FEnumConverter.toOperandIndexOption(this.fXmlNode.get_attrVal(FXmlTagJEP.A_OperandIndexOption, FXmlTagJEP.D_OperandIndexOption));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FOperandIndexOption.And;
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

                    // ***
                    // Operand Index Type이 Position일 경우 변경할 수 없다.
                    // ***
                    if (this.fOperandIndexType == FOperandIndexType.Position)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Operand's Index Type", "All"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandIndexOption, FXmlTagJEP.D_OperandIndexOption, FEnumConverter.fromOperandIndexOption(value), true);
                    noticeModified(this.fAncestorJudgementCondition);
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

        public int operandIndex
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagJEP.A_OperandIndex, FXmlTagJEP.D_OperandIndex));
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

                    // ***
                    // Operand Index Type이 All일 경우 변경할 수 없다.
                    // ***
                    if (this.fOperandIndexType == FOperandIndexType.All)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Operand's Index Type", "Position"));
                    }

                    if (value < 0)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0014, "Operand Index"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandIndex, FXmlTagJEP.D_OperandIndex, value.ToString(), true);
                    noticeModified(this.fAncestorJudgementCondition);
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
                    return FEnumConverter.toOperation(this.fXmlNode.get_attrVal(FXmlTagJEP.A_Operation, FXmlTagJEP.D_Operation));
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

                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_Operation, FXmlTagJEP.D_Operation, FEnumConverter.fromOperation(value), true);
                    noticeModified(this.fAncestorJudgementCondition);
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

        public FOperandValueType fOperandValueType
        {
            get
            {
                try
                {
                    return FEnumConverter.toOperandValueType(this.fXmlNode.get_attrVal(FXmlTagJEP.A_OperandValueType, FXmlTagJEP.D_OperandValueType));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FOperandValueType.Value;
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

                    if (value == FOperandValueType.Value)
                    {
                        resetOperandValue(false);
                        this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandValueIndexType, FXmlTagJEP.D_OperandValueIndexType, FEnumConverter.fromOperandIndexType(FOperandIndexType.All));
                        this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandValueIndexOption, FXmlTagJEP.D_OperandValueIndexOption, FXmlTagJEP.D_OperandValueIndexOption);
                        this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandValueIndex, FXmlTagJEP.D_OperandValueIndex, "0", false);
                    }
                    else
                    {
                        this.fXmlNode.set_attrVal(FXmlTagJEP.A_Value, FXmlTagJEP.D_Value, string.Empty, false);
                    }
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandValueType, FXmlTagJEP.D_OperandValueType, FEnumConverter.fromOperandValueType(value), true);

                    // --

                    noticeModified(this.fAncestorJudgementCondition);
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

        public FOperandIndexType fOperandValueIndexType
        {
            get
            {
                try
                {
                    return FEnumConverter.toOperandIndexType(this.fXmlNode.get_attrVal(FXmlTagJEP.A_OperandValueIndexType, FXmlTagJEP.D_OperandValueIndexType));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                }
                return FOperandIndexType.All;
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

                    // ***
                    // Operand Value Type이 Value일 경우 변경할 수 없다.
                    // ***
                    if (this.fOperandValueType == FOperandValueType.Value)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Operand's Value Type", "Data"));
                    }

                    // --

                    if (value == FOperandIndexType.All)
                    {
                        this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandValueIndex, FXmlTagJEP.D_OperandValueIndex, "0");
                    }
                    else
                    {
                        this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandValueIndexOption, FXmlTagJEP.D_OperandValueIndexOption, FXmlTagJEP.D_OperandValueIndexOption);
                    }
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandValueIndexType, FXmlTagJEP.D_OperandValueIndexType, FEnumConverter.fromOperandIndexType(value), true);
                    noticeModified(this.fAncestorJudgementCondition);
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

        public FOperandIndexOption fOperandValueIndexOption
        {
            get
            {
                try
                {
                    return FEnumConverter.toOperandIndexOption(this.fXmlNode.get_attrVal(FXmlTagJEP.A_OperandValueIndexOption, FXmlTagJEP.D_OperandValueIndexOption));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FOperandIndexOption.And;
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

                    // ***
                    // Operand Value Type이 Value일 경우 변경할 수 없다.
                    // ***
                    if (this.fOperandValueType == FOperandValueType.Value)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Operand's Value Type", "Data"));
                    }

                    // ***
                    // Operand Value Index Type이 Position일 경우 견경할 수 없다.
                    // ***
                    if (this.fOperandValueIndexType == FOperandIndexType.Position)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Operand's Value Index Type", "All"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandValueIndexOption, FXmlTagJEP.D_OperandValueIndexOption, FEnumConverter.fromOperandIndexOption(value), true);
                    noticeModified(this.fAncestorJudgementCondition);
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

        public int operandValueIndex
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagJEP.A_OperandValueIndex, FXmlTagJEP.D_OperandValueIndex));
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

                    // ***
                    // Operand Value Type이 Value일 경우 변경할 수 없다.
                    // ***
                    if (this.fOperandValueType == FOperandValueType.Value)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Operand's Value Type", "Data"));
                    }

                    // ***
                    // Operand Value Index Type이 All일 경우 견경할 수 없다.
                    // ***
                    if (this.fOperandValueIndexType == FOperandIndexType.All)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Operand's Value Index Type", "Position"));
                    }

                    if (value < 0)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0014, "Operand Value Index"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandValueIndex, FXmlTagJEP.D_OperandValueIndex, value.ToString(), true);
                    noticeModified(this.fAncestorJudgementCondition);
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
                    return this.fXmlNode.get_attrVal(FXmlTagJEP.A_Value, FXmlTagJEP.D_Value);
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

                    // ***
                    // Operand Value Type이 Value가 아닐 경우 변경할 수 없다.
                    // ***
                    if (this.fOperandValueType == FOperandValueType.Data)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Operand's Value Type", "Value"));
                    }

                    // --

                    fFormat = this.fValueFormat;
                    val = FValueConverter.fromStringValue(fFormat, value, out length);

                    // ***
                    // Format이 Ascii 계열이 아닌 경우, Value의 Length가 1보다 클 수 없다.
                    // ***
                    if (fFormat != FFormat.Ascii && fFormat != FFormat.A2 && fFormat != FFormat.JIS8 && length > 1)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_Value, FXmlTagJEP.D_ValueId, val, true);
                    noticeModified(this.fAncestorJudgementCondition);
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

                    // ***
                    // Operand Value Type이 Value가 아닐 경우 변경할 수 없다.
                    // ***
                    if (this.fOperandValueType == FOperandValueType.Data)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Operand's Value Type", "Value"));
                    }

                    // --

                    fFormat = this.fValueFormat;
                    val = FValueConverter.fromStringArrayValue(fFormat, value, out length);

                    // ***
                    // Format이 Ascii 계열이 아닌 경우, Value의 Length가 1보다 클 수 없다.
                    // ***
                    if (fFormat != FFormat.Ascii && fFormat != FFormat.A2 && fFormat != FFormat.JIS8 && length > 1)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_Value, FXmlTagJEP.D_ValueId, val, true);
                    noticeModified(this.fAncestorJudgementCondition);
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

                    // ***
                    // Operand Value Type이 Value가 아닐 경우 변경할 수 없다.
                    // ***
                    if (this.fOperandValueType == FOperandValueType.Data)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Operand's Value Type", "Value"));
                    }

                    // --

                    fFormat = this.fValueFormat;
                    val = FValueConverter.fromValue(fFormat, value, out length);

                    // ***
                    // Format이 Ascii 계열이 아닌 경우, Value의 Length가 1보다 클 수 없다.
                    // ***
                    if (fFormat != FFormat.Ascii && fFormat != FFormat.A2 && fFormat != FFormat.JIS8 && length > 1)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_Value, FXmlTagJEP.D_Value, val, true);
                    noticeModified(this.fAncestorJudgementCondition);
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

        public FData fOperandValue
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagJEP.A_ValueId, FXmlTagJEP.D_ValueId);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    xpath =
                        FXmlTagSET.E_Setup +
                        "/" + FXmlTagDSD.E_DataSetDefinition +
                        "/" + FXmlTagDSL.E_DataSetList +
                        "/" + FXmlTagDTS.E_DataSet +
                        "//" + FXmlTagDAT.E_Data + "[@" + FXmlTagDAT.A_UniqueId + "='" + id + "']";
                    // --
                    return new FData(this.fOcdCore, this.fOpcDriver.fXmlNode.selectSingleNode(xpath));
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

        public string operandValueName
        {
            get
            {
                try
                {
                    if (this.hasOperandValue)
                    {
                        return this.fOperandValue.name;
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

        public FJudgementExpressionValueTransformer fValueTransformer
        {
            get
            {
                try
                {
                    return new FJudgementExpressionValueTransformer(this);
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
                    id = this.fXmlNode.get_attrVal(FXmlTagJEP.A_DataConversionSetID, FXmlTagJEP.D_DataConversionSetID);
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
                    return new FDataConversionSet(this.fOcdCore, this.fOpcDriver.fXmlNode.selectSingleNode(xpath));
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
                    return this.fXmlNode.get_attrVal(FXmlTagJEP.A_DataConversionSetName, FXmlTagJEP.D_DataConversionSetName);
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
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_DataConversionSetName, FXmlTagJEP.D_DataConversionSetName, value, false);
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
                    return this.fXmlNode.get_attrVal(FXmlTagJEP.A_DataConversionSetExpression, FXmlTagJEP.D_DataConversionSetExpression);
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
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_DataConversionSetExpression, FXmlTagJEP.D_DataConversionSetExpression, value, false);
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
                    return this.fXmlNode.get_attrVal(FXmlTagJEP.A_UserTag1, FXmlTagJEP.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_UserTag1, FXmlTagJEP.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagJEP.A_UserTag2, FXmlTagJEP.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_UserTag2, FXmlTagJEP.D_UserTag2, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagJEP.A_UserTag3, FXmlTagJEP.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_UserTag3, FXmlTagJEP.D_UserTag3, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagJEP.A_UserTag4, FXmlTagJEP.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_UserTag4, FXmlTagJEP.D_UserTag4, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagJEP.A_UserTag5, FXmlTagJEP.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_UserTag5, FXmlTagJEP.D_UserTag5, value, true);
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

                    if (this.fXmlNode.fParentNode.name == FXmlTagJCN.E_JudgementCondition)
                    {
                        return new FJudgementCondition(this.fOcdCore, this.fXmlNode.fParentNode);
                    }
                    return new FJudgementExpression(this.fOcdCore, this.fXmlNode.fParentNode);
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

        public FJudgementExpression fPreviousSibling
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

                    return new FJudgementExpression(this.fOcdCore, this.fXmlNode.fPreviousSibling);
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

        public FJudgementExpression fNextSibling
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

                    return new FJudgementExpression(this.fOcdCore, this.fXmlNode.fNextSibling);
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

        public FJudgementCondition fAncestorJudgementCondition
        {
            get
            {
                try
                {
                    return this.getAncestorJudgementCondition();
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

        public FJudgementExpressionCollection fChildJudgementExpressionCollection
        {
            get
            {
                try
                {
                    return new FJudgementExpressionCollection(this.fOcdCore, this.fXmlNode.selectNodes(FXmlTagJEP.E_JudgementExpression));
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
                            "../../" + FXmlTagJCN.E_JudgementCondition + "[@" + FXmlTagJCN.A_UniqueId + "='" + fParent.uniqueIdToString + "']";
                    }
                    return new FObjectCollection(this.fOcdCore, this.fXmlNode.selectNodes(xpath));
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
                        if (this.fOperandValueType == FOperandValueType.Value)
                        {
                            xpath =
                            "../../../../../../../" + FXmlTagSET.E_Setup + "/" + FXmlTagDSD.E_DataSetDefinition +
                            "/" + FXmlTagDSL.E_DataSetList +
                            "/" + FXmlTagDTS.E_DataSet +
                            "//" + FXmlTagDAT.E_Data + "[@" + FXmlTagDAT.A_UniqueId + "='" + this.fOperand.uniqueIdToString + "']";
                        }
                        else if (this.fOperandValueType == FOperandValueType.Data)
                        {
                            xpath =
                            "../../../../../../../" + FXmlTagSET.E_Setup + "/" + FXmlTagDSD.E_DataSetDefinition +
                            "/" + FXmlTagDSL.E_DataSetList +
                            "/" + FXmlTagDTS.E_DataSet +
                            "//" + FXmlTagDAT.E_Data + "[@" + FXmlTagDAT.A_UniqueId + "='" + this.fOperand.uniqueIdToString + "']";
                        }
                    }
                    else
                    {
                        xpath = "NULL";
                    }

                    // --
                    return new FObjectCollection(this.fOcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return this.fXmlNode.containsNode(FXmlTagJEP.E_JudgementExpression);
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

        public bool hasHashTagChild
        {
            get
            {
                try
                {
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

        //------------------------------------------------------------------------------------------------------------------------

        public bool hasOperand
        {
            get
            {
                try
                {
                    if (this.fXmlNode.get_attrVal(FXmlTagJEP.A_OperandId, FXmlTagJEP.D_OperandId) == string.Empty)
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

        public bool hasOperandValue
        {
            get
            {
                try
                {
                    if (this.fXmlNode.get_attrVal(FXmlTagJEP.A_ValueId, FXmlTagJEP.D_ValueId) == string.Empty)
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
                    if (this.fXmlNode.get_attrVal(FXmlTagJEP.A_Transformer, FXmlTagJEP.D_Transformer) == string.Empty)
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
                    if (this.fXmlNode.get_attrVal(FXmlTagJEP.A_DataConversionSetID, FXmlTagJEP.D_DataConversionSetID) == string.Empty)
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
                        !FClipboard.containsData(FCbObjectFormat.JudgementExpression)
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
                    if (
                        this.fExpressionType == FExpressionType.Comparison ||
                        !FClipboard.containsData(FCbObjectFormat.JudgementExpression)
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public string ToString(
            FStringOption option
            )
        {
            string info = string.Empty;
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
                        info += " Exp.=[";
                        
                        if (this.hasOperand)
                        {
                            info += this.fOperand.name;
                        }
                        else
                        {
                            info += "'N/A'";                            
                        }
                        // --
                        if (this.fOperandIndexType == FOperandIndexType.All)
                        {
                            info += "[A]";
                        }
                        else
                        {
                            info += "[" + this.operandIndex.ToString() + "]";
                        }

                        // --

                        info += " " + FEnumConverter.toOperationExp(this.fOperation) + " ";

                        // --

                        if (this.fOperandValueType == FOperandValueType.Data)
                        {
                            if (this.hasOperandValue)
                            {
                                info += this.fOperandValue.name;
                            }
                            else
                            {
                                info += "'N/A'";
                            }
                            // --
                            if (this.fOperandValueIndexType == FOperandIndexType.All)
                            {
                                info += "[A]";
                            }
                            else
                            {
                                info += "[" + this.operandValueIndex.ToString() + "]";
                            }
                        }
                        else
                        {
                            fFormat = this.fValueFormat;
                            if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2)
                            {
                                info += "\"" + this.encodingValue + "\"";
                            }
                            else
                            {
                                info += "\"" + this.stringValue + "\"";
                            }
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

        public FJudgementExpression appendChildJudgementExpression(
           FJudgementExpression fNewChild
           )
        {
            try
            {
                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // ***
                // Judgment Expression의 Type이 Comparison일 경우 Judgement Expression를 추가할 수 없다.
                // ***
                if (this.fExpressionType == FExpressionType.Comparison)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Expression's Type", "Bracket"));
                }

                // --

                fNewChild.replace(this.fOcdCore, this.fXmlNode.appendChild(fNewChild.fXmlNode));                
                // --                
                if (this.isModelingObject)
                {
                    FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fOcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectAppendCompleted, this.fOpcDriver, this, fNewChild)
                        );
                    noticeModified(this.fAncestorJudgementCondition);
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

        public FJudgementExpression insertBeforeChildJudgementExpression(
            FJudgementExpression fNewChild,
            FJudgementExpression fRefChild
            )
        {
            try
            {
                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, this.fXmlNode.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                // --                
                if (this.isModelingObject)
                {
                    FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                    // ---
                    this.fOcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectInsertBeforeCompleted, this.fOpcDriver, this, fNewChild)
                        );
                    noticeModified(this.fAncestorJudgementCondition);
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

        public FJudgementExpression insertAfterChildJudgementExpression(
            FJudgementExpression fNewChild,
            FJudgementExpression fRefChild
            )
        {
            try
            {
                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, this.fXmlNode.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                // --                
                if (this.isModelingObject)
                {
                    FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fOcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this.fOpcDriver, this, fNewChild)
                        );
                    noticeModified(this.fAncestorJudgementCondition);
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
            FJudgementCondition fJcn = null;
            FIObject fParent = null;
            FJudgementExpression fNextJep = null;
            bool isModelingObject = false;

            try
            {
                FOpcDriverCommon.validateRemoveChildObject(this.fXmlNode.fParentNode, this.fXmlNode);                                

                // --

                resetRelation();

                // --

                fJcn = this.fAncestorJudgementCondition;
                fParent = this.fParent;
                fNextJep = this.fNextSibling;
                isModelingObject = this.isModelingObject;
                this.replace(this.fOcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));

                // --

                // ***
                // 제거되는 Object의 다음 Object가 최상위일 경우 Logical를 And로 변경한다.
                // ***
                if (fNextJep != null && fNextJep.fPreviousSibling == null)
                {
                    fNextJep.fXmlNode.set_attrVal(FXmlTagJEP.A_Logical, FXmlTagJEP.D_Logical, FEnumConverter.fromLogical(FLogical.And), true);
                }

                // --

                if (isModelingObject)
                {
                    this.fOcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectRemoveCompleted, this.fOpcDriver, fParent, this)
                        );
                    noticeModified(fJcn);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fJcn = null;
                fParent = null;
                fNextJep = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FJudgementExpression removeChildJudgementExpression(
            FJudgementExpression fChild
            )
        {
            try
            {
                FOpcDriverCommon.validateRemoveChildObject(this.fXmlNode, fChild.fXmlNode);

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

        public void removeChildJudgementExpression(
            FJudgementExpression[] fChilds
            )
        {
            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                foreach (FJudgementExpression fJep in fChilds)
                {
                    FOpcDriverCommon.validateRemoveChildObject(this.fXmlNode, fJep.fXmlNode);
                }

                // --

                foreach (FJudgementExpression fJep in fChilds)
                {
                    fJep.remove();
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

        public void removeAllChildJudgementExpression(
            )
        {
            FJudgementExpressionCollection fJepCollction = null;

            try
            {
                fJepCollction = this.fChildJudgementExpressionCollection;
                if (fJepCollction.count == 0)
                {
                    return;
                }

                // --

                foreach (FJudgementExpression fJep in fJepCollction)
                {
                    fJep.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fJepCollction != null)
                {
                    fJepCollction.Dispose();
                    fJepCollction = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void setOperand(
            FData fData
            )
        {
            string oldDatId = string.Empty;
            string newDatId = string.Empty;
            FFormat fFormat;

            try
            {
                // ***
                // Data 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fData.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Data", "Modeling File"));
                }

                // ***
                // Judgement Expression 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Judgement Expression", "Modeling File"));
                }

                // ***
                // Data와 Judgement Expression의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fData))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the Data and the Judgement Expression", "same"));
                }

                // ***
                // Judgement Condition에 Data Set 설정되어 있는지 검사
                // ***
                if (!this.fAncestorJudgementCondition.hasDataSet)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "Data Set in the Judgement Condition"));
                }

                // ***
                // Data의 조상 Data Set이 Judgement Condition에 설정된 Data Set과 동일한지 검사
                // ***
                if (this.fAncestorJudgementCondition.fDataSet != fData.fAncestorDataSet)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Data Set of the Data and the Judgement Condition", "same"));
                }

                // ***
                // Operand Format이 List, AsciiList, Raw일 경우 Comaprsion Mode가 Length 인지 검사
                // ***
                fFormat = fData.fFormat;
                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Raw || fFormat == FFormat.Unknown)
                {
                    if (this.fComparisonMode != FComparisonMode.Length)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Comparison Mode", "Length"));
                    }
                }

                // --

                oldDatId = this.fXmlNode.get_attrVal(FXmlTagJEP.A_OperandId, FXmlTagJEP.D_OperandId);
                newDatId = fData.uniqueIdToString;
                // --
                if (oldDatId == newDatId)
                {
                    return;
                }

                // --

                // ***
                // 이전에 설정된 Operand가 존재할 경우 Reset 한다.
                // ***
                if (oldDatId != string.Empty)
                {
                    resetOperand(false);
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandFormat, FXmlTagJEP.D_OperandFormat, FEnumConverter.fromFormat(fFormat), false);
                this.fXmlNode.set_attrVal(FXmlTagJEP.A_Value, FXmlTagJEP.D_Value, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagJEP.A_Transformer, FXmlTagJEP.D_Transformer, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandId, FXmlTagJEP.D_OperandId, newDatId, true);

                // --

                noticeModified(this.fAncestorJudgementCondition);

                // --

                fData.lockObject();
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
            FData fDat = null;

            try
            {
                foreach (FJudgementExpression fJep in this.fChildJudgementExpressionCollection)
                {
                    fJep.resetOperand(isModifyEvent);
                }

                // --

                fDat = this.fOperand;
                if (fDat == null)
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandFormat, FXmlTagJEP.D_OperandFormat, FEnumConverter.fromFormat(FFormat.Ascii));
                this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandIndexType, FXmlTagJEP.D_OperandIndexType, FEnumConverter.fromOperandIndexType(FOperandIndexType.All));
                this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandIndexOption, FXmlTagJEP.D_OperandIndexOption, FEnumConverter.fromOperandIndexOption(FOperandIndexOption.Or));
                this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandIndex, FXmlTagJEP.D_OperandIndex, "0", false);
                this.fXmlNode.set_attrVal(FXmlTagJEP.A_Value, FXmlTagJEP.D_Value, string.Empty);
                this.fXmlNode.set_attrVal(FXmlTagJEP.A_Transformer, FXmlTagJEP.D_Transformer, string.Empty);
                // --
                resetDataConversionSet(false);
                // --
                this.fXmlNode.set_attrVal(FXmlTagJEP.A_OperandId, FXmlTagJEP.D_OperandId, string.Empty, isModifyEvent);
                // --
                if (isModifyEvent)
                {
                    noticeModified(this.fAncestorJudgementCondition);
                }

                // --

                fDat.unlockObject();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fDat = null;
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

        public void setOperandValue(
            FData fData
            )
        {
            string oldDatId = string.Empty;
            string newDatId = string.Empty;
            FFormat fFormat;

            try
            {
                // ***
                // Expression Type이 Bracket일 경우 변경할 수 없다.
                // ***
                if (this.fExpressionType == FExpressionType.Bracket)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Expression's Type", "Comparison"));
                }

                // ***
                // Operand Value Type이 Data가 아닐 경우 변경할 수 없다.
                // ***
                if (this.fOperandValueType == FOperandValueType.Value)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Operand's Value Type", "Data"));
                }

                // ***
                // Data 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fData.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Data", "Modeling File"));
                }

                // ***
                // Judgement Expression 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Judgement Expression", "Modeling File"));
                }

                // ***
                // Data와 Judgement Expression의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fData))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the Data and the Judgement Expression", "same"));
                }

                // ***
                // Operand Format이 List, AsciiList, Raw일 경우 Comaprsion Mode가 Length 인지 검사
                // ***
                fFormat = fData.fFormat;
                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Raw || fFormat == FFormat.Unknown)
                {
                    if (this.fComparisonMode != FComparisonMode.Length)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Comparison Mode", "Length"));
                    }
                }

                // --

                oldDatId = this.fXmlNode.get_attrVal(FXmlTagJEP.A_ValueId, FXmlTagJEP.D_ValueId);
                newDatId = fData.uniqueIdToString;
                // --
                if (oldDatId == newDatId)
                {
                    return;
                }

                // --

                // ***
                // 이전에 설정된 Value가 존재할 경우 Reset 한다.
                // ***
                if (oldDatId != string.Empty)
                {
                    resetOperandValue(false);
                }

                // --
                
                this.fXmlNode.set_attrVal(FXmlTagJEP.A_ValueId, FXmlTagJEP.D_ValueId, newDatId, true);

                // --

                noticeModified(this.fAncestorJudgementCondition);

                // --

                fData.lockObject();
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

        internal void resetOperandValue(
            bool isModifyEvent
            )
        {
            FData fDat = null;

            try
            {
                foreach (FJudgementExpression fJep in this.fChildJudgementExpressionCollection)
                {
                    fJep.resetOperandValue(isModifyEvent);
                }

                // --

                fDat = this.fOperandValue;
                if (fDat == null)
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagJEP.A_ValueId, FXmlTagJEP.D_ValueId, string.Empty, isModifyEvent);
                // --
                if (isModifyEvent)
                {
                    noticeModified(this.fAncestorJudgementCondition);
                }

                // --

                fDat.unlockObject();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fDat = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void resetOperandValue(
            )
        {
            try
            {
                resetOperandValue(true);
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
                resetOperandValue(false);
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

        internal static void resetFlowNode(
            FXmlNode fXmlNode
            )
        {
            try
            {
                fXmlNode.set_attrVal(FXmlTagJEP.A_OperandId, FXmlTagJEP.D_OperandId, FXmlTagJEP.D_OperandId);
                fXmlNode.set_attrVal(FXmlTagJEP.A_OperandFormat, FXmlTagJEP.D_OperandFormat, FXmlTagJEP.D_OperandFormat);
                fXmlNode.set_attrVal(FXmlTagJEP.A_Value, FXmlTagJEP.D_Value, FXmlTagJEP.D_Value);
                fXmlNode.set_attrVal(FXmlTagJEP.A_ValueId, FXmlTagJEP.D_ValueId, FXmlTagJEP.D_ValueId);
                fXmlNode.set_attrVal(FXmlTagJEP.A_Transformer, FXmlTagJEP.D_Transformer, FXmlTagJEP.D_Transformer);
                fXmlNode.set_attrVal(FXmlTagJEP.A_DataConversionSetExpression, FXmlTagJEP.D_DataConversionSetExpression, string.Empty);
                fXmlNode.set_attrVal(FXmlTagJEP.A_DataConversionSetName, FXmlTagJEP.D_DataConversionSetName, string.Empty);
                fXmlNode.set_attrVal(FXmlTagJEP.A_DataConversionSetID, FXmlTagJEP.D_DataConversionSetID, string.Empty);

                // --

                foreach (FXmlNode fXmlNodeJep in fXmlNode.selectNodes(FXmlTagJEP.E_JudgementExpression))
                {
                    FJudgementExpression.resetFlowNode(fXmlNodeJep);
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

        internal void noticeModified(
            FJudgementCondition fJcn
            )
        {
            try
            {
                if (fJcn != null)
                {
                    fJcn.noticeChildModified();
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
                this.copyObject(FCbObjectFormat.JudgementExpression, fXmlNode);
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
                FOpcDriverCommon.validateCutObject(this.fXmlNode);

                // --

                this.remove();

                // --

                resetFlowNode(fXmlNode);
                this.copyObject(FCbObjectFormat.JudgementExpression, this.fXmlNode);
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

        public FJudgementExpression pasteSibling(
              )
        {
            FIObject fParent = null;
            FJudgementExpression fJep = null;

            try
            {
                FOpcDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.JudgementExpression);

                // --

                fParent = this.fParent;
                fJep = (FJudgementExpression)this.pasteObject(FCbObjectFormat.JudgementExpression);
                // --
                if (fParent.fObjectType == FObjectType.JudgementCondition)
                {
                    return ((FJudgementCondition)this.fParent).insertAfterChildJudgementExpression(fJep, this);
                }
                return ((FJudgementExpression)this.fParent).insertAfterChildJudgementExpression(fJep, this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fParent = null;
                fJep = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FJudgementExpression pasteChild(
            ) 
        {
            FJudgementExpression fJep = null;

            try
            {
                FOpcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.JudgementExpression);

                // --

                fJep = (FJudgementExpression)this.pasteObject(FCbObjectFormat.JudgementExpression);
                return this.appendChildJudgementExpression(fJep);
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

        public void moveUp(
            )
        {
            bool isModelingObject = false;

            try
            {
                FOpcDriverCommon.validateMoveUpObject(this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fOcdCore, this.fXmlNode.moveUp());

                // --

                if (this.fXmlNode.fPreviousSibling == null)
                {
                    this.fXmlNode.set_attrVal(FXmlTagJEP.A_Logical, FXmlTagJEP.D_Logical, FEnumConverter.fromLogical(FLogical.And));
                }

                // --

                if (isModelingObject)
                {
                    this.fOcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveUpCompleted, this.fOpcDriver, fParent, this)
                        );
                    noticeModified(this.fAncestorJudgementCondition);
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
                FOpcDriverCommon.validateMoveDownObject(this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fOcdCore, this.fXmlNode.moveDown());

                // --

                if (isModelingObject)
                {
                    this.fOcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveDownCompleted, this.fOpcDriver, fParent, this)
                        );
                    noticeModified(this.fAncestorJudgementCondition);
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
            FJudgementExpression fRefObject
            )
        {
            try
            {
                FOpcDriverCommon.validateMoveToObject(this.fXmlNode, fRefObject.fXmlNode);

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

                if (!this.fAncestorJudgementCondition.Equals(fRefObject.fAncestorJudgementCondition))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Ancestor Judgement Condition ", "same"));
                }

                // --

                this.replace(this.fOcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fOcdCore, fRefObject.fXmlNode.fParentNode.insertAfter(this.fXmlNode, fRefObject.fXmlNode));

                // --

                this.fOcdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fOpcDriver, this, fRefObject)
                    );
                noticeModified(this.fAncestorJudgementCondition);
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
            FJudgementCondition fRefObject
            )
        {
            try
            {
                FOpcDriverCommon.validateMoveToObject(this.fXmlNode, fRefObject.fXmlNode);

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

                if (!this.fAncestorJudgementCondition.Equals(fRefObject))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Ancestor Judgement Condition ", "same"));
                }

                if (fRefObject.fChildJudgementExpressionCollection.count > 0)
                {
                    if (this.Equals(fRefObject.fChildJudgementExpressionCollection[fRefObject.fChildJudgementExpressionCollection.count - 1]))
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0060, "Object", "same localtion"));
                    }
                }

                // --

                this.replace(this.fOcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fOcdCore, fRefObject.fXmlNode.appendChild(this.fXmlNode));

                // --

                this.fOcdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fOpcDriver, this, fRefObject)
                    );
                noticeModified(this.fAncestorJudgementCondition);
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
                // 이 Judgement Expression 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Judgement Expression", "Modeling File"));
                }

                // ***
                // Data Conversion Set와 Judgement Expression의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fDataConversionSet))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the Data Conversion Set and the Judgement Expression", "same"));
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

                oldDcsId = this.fXmlNode.get_attrVal(FXmlTagJEP.A_DataConversionSetID, FXmlTagJEP.D_DataConversionSetID);
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
                
                this.fXmlNode.set_attrVal(FXmlTagJEP.A_DataConversionSetExpression, FXmlTagJEP.D_DataConversionSetExpression, fDataConversionSet.expression, false);
                this.fXmlNode.set_attrVal(FXmlTagJEP.A_DataConversionSetName, FXmlTagJEP.D_DataConversionSetName, fDataConversionSet.name, false);
                this.fXmlNode.set_attrVal(FXmlTagJEP.A_DataConversionSetID, FXmlTagJEP.D_DataConversionSetID, newDcsId, true);
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
                foreach (FJudgementExpression fJep in this.fChildJudgementExpressionCollection)
                {
                    fJep.resetDataConversionSet(isModifyEvent);
                }

                // --

                fDcs = this.fDataConversionSet;
                if (fDcs == null)
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagJEP.A_DataConversionSetExpression, FXmlTagJEP.D_DataConversionSetExpression, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagJEP.A_DataConversionSetName, FXmlTagJEP.D_DataConversionSetName, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagJEP.A_DataConversionSetID, FXmlTagJEP.D_DataConversionSetID, string.Empty, isModifyEvent);
                
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
