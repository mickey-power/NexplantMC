/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecsExpression.cs
--  Creator         : spike.lee
--  Create Date     : 2011.05.31
--  Description     : FAMate Core FaSecsDriver SECS Expression Class 
--  History         : Created by spike.lee at 2011.05.31
                    : Modified by spike.lee at 2011.08.10
                        - Notice Modifed 추가
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public class FSecsExpression : FBaseObject<FSecsExpression>, FIObject
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecsExpression(
            FSecsDriver fSecsDriver
            )
            : base(fSecsDriver.fScdCore, FSecsDriverCommon.createXmlNodeSEP(fSecsDriver.fScdCore.fXmlDoc))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FSecsExpression(
            FScdCore fScdCore,
            FXmlNode fXmlNode
            )
            : base(fScdCore, fXmlNode)
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSecsExpression(
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
                    return FObjectType.SecsExpression;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.SecsExpression;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSEP.A_UniqueId, FXmlTagSEP.D_UniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSEP.A_Name, FXmlTagSEP.D_Name);
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
                    FSecsDriverCommon.validateName(value, true);

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_Name, FXmlTagSEP.D_Name, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSEP.A_Description, FXmlTagSEP.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_Description, FXmlTagSEP.D_Description, value, true);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagSEP.A_FontColor, FXmlTagSEP.D_FontColor));
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
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_FontColor, FXmlTagSEP.D_FontColor, value.Name, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSEP.A_FontBold, FXmlTagSEP.D_FontBold));
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
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_FontBold, FXmlTagSEP.D_FontBold, FBoolean.fromBool(value), true);
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
                    return FEnumConverter.toLogical(this.fXmlNode.get_attrVal(FXmlTagSEP.A_Logical, FXmlTagSEP.D_Logical));
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
                    // 첫번째 SECS Expression인 경우 Logical를 변경할 수 없다.
                    // ***
                    if (this.fPreviousSibling == null)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0008, "First Expression", "Logical"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_Logical, FXmlTagSEP.D_Logical, FEnumConverter.fromLogical(value), true);
                    noticeModified(this.fAncestorSecsCondition);
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
                    return FEnumConverter.toExpressionType(this.fXmlNode.get_attrVal(FXmlTagSEP.A_ExpressionType, FXmlTagSEP.D_ExpressionType));
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
                    // 자식 SECS Expression이 존재할 경우 Expression Type를 변경할 수 없다.
                    // ***
                    if (this.hasChild)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0013, "Object's Child"));
                    }                    

                    // --                    

                    resetOperand(false);

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_ComparisonMode, FXmlTagSEP.D_ComparisonMode, FEnumConverter.fromComparisonMode(FComparisonMode.Value), false);
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_OperandType, FXmlTagSEP.D_OperandType, FEnumConverter.fromSecsOperandType(FSecsOperandType.SecsItem), false);
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_OperandIndex, FXmlTagSEP.D_OperandIndex, "0", false);
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_Operation, FXmlTagSEP.D_Operation, FEnumConverter.fromOperation(FOperation.Equal), false);
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_ExpressionValueType, FXmlTagSEP.D_ExpressionValueType, FEnumConverter.fromExpressionValueType(FExpressionValueType.Value), false);
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_Resource, FXmlTagSEP.D_Resource, FEnumConverter.fromSecsResourceSourceType(FSecsResourceSourceType.None), false);
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_Value, FXmlTagSEP.D_Value, string.Empty, false);
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_Transformer, FXmlTagSEP.D_Transformer, string.Empty, false);
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_ExpressionType, FXmlTagSEP.D_ExpressionType, FEnumConverter.fromExpressionType(value), true);
                    // --
                    noticeModified(this.fAncestorSecsCondition);
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
                    return FEnumConverter.toComparisonMode(this.fXmlNode.get_attrVal(FXmlTagSEP.A_ComparisonMode, FXmlTagSEP.D_ComparisonMode));
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

                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_OperandType, FXmlTagSEP.D_OperandType, FEnumConverter.fromSecsOperandType(FSecsOperandType.SecsItem), false);
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_OperandIndex, FXmlTagSEP.D_OperandIndex, "0", false);
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_Operation, FXmlTagSEP.D_Operation, FEnumConverter.fromOperation(FOperation.Equal), false);
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_ExpressionValueType, FXmlTagSEP.D_ExpressionValueType, FEnumConverter.fromExpressionValueType(FExpressionValueType.Value), false);
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_Value, FXmlTagSEP.D_Value, string.Empty, false);
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_Resource, FXmlTagSEP.D_Resource, FEnumConverter.fromSecsResourceSourceType(FSecsResourceSourceType.None), false);
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_Transformer, FXmlTagSEP.D_Transformer, string.Empty, false);
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_ComparisonMode, FXmlTagSEP.D_ComparisonMode, FEnumConverter.fromComparisonMode(value), true);

                    // --

                    noticeModified(this.fAncestorSecsCondition);
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

        public FSecsOperandType fOperandType
        {
            get
            {
                try
                {
                    return FEnumConverter.toSecsOperandType(this.fXmlNode.get_attrVal(FXmlTagSEP.A_OperandType, FXmlTagSEP.D_OperandType));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FSecsOperandType.SecsItem;
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

                    if (this.fComparisonMode == FComparisonMode.Length && value == FSecsOperandType.EquipmentState)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Comparison Mode", "Value"));
                    }

                    // --

                    resetOperand(false);

                    // --
                    
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_ExpressionValueType, FXmlTagSEP.D_ExpressionValueType, FEnumConverter.fromExpressionValueType(FExpressionValueType.Value), false);
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_Resource, FXmlTagSEP.D_Resource, FEnumConverter.fromSecsResourceSourceType(FSecsResourceSourceType.None), false);
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_Value, FXmlTagSEP.D_Value, string.Empty, false);
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_Transformer, FXmlTagSEP.D_Transformer, string.Empty, false);
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_OperandType, FXmlTagSEP.D_OperandType, FEnumConverter.fromSecsOperandType(value), true);

                    // --

                    noticeModified(this.fAncestorSecsCondition);
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

        public FISecsOperand fOperand
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;                

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagSEP.A_OperandId, FXmlTagSEP.D_OperandId);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    if (this.fOperandType == FSecsOperandType.SecsItem)
                    {
                        xpath =
                            FXmlTagSLM.E_SecsLibraryModeling +
                            "/" + FXmlTagSLG.E_SecsLibraryGroup +
                            "/" + FXmlTagSLB.E_SecsLibrary +
                            "/" + FXmlTagSML.E_SecsMessageList +
                            "/" + FXmlTagSMS.E_SecsMessages +
                            "/" + FXmlTagSMG.E_SecsMessage +
                            "//" + FXmlTagSIT.E_SecsItem + "[@" + FXmlTagSIT.A_UniqueId + "='" + id + "']";
                        // --
                        return new FSecsItem(this.fScdCore, this.fSecsDriver.fXmlNode.selectSingleNode(xpath));
                    }
                    else if (this.fOperandType == FSecsOperandType.Environment)
                    {
                        xpath =
                            FXmlTagSET.E_Setup +
                            "/" + FXmlTagEND.E_EnvironmentDefinition +
                            "/" + FXmlTagENL.E_EnvironmentList +
                            "//" + FXmlTagENV.E_Environment + "[@" + FXmlTagENV.A_UniqueId + "='" + id + "']";
                        // --
                        return new FEnvironment(this.fScdCore, this.fSecsDriver.fXmlNode.selectSingleNode(xpath));
                    }
                    else if (this.fOperandType == FSecsOperandType.EquipmentState)
                    {
                        xpath =
                            FXmlTagSET.E_Setup +
                            "/" + FXmlTagESD.E_EquipmentStateSetDefinition +
                            "/" + FXmlTagESL.E_EquipmentStateSetList +
                            "/" + FXmlTagESS.E_EquipmentStateSet +
                            "/" + FXmlTagEST.E_EquipmentState + "[@" + FXmlTagEST.A_UniqueId + "='" + id + "']";
                        // --
                        return new FEquipmentState(this.fScdCore, this.fSecsDriver.fXmlNode.selectSingleNode(xpath));
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
                FISecsOperand fOpd = null;

                try
                {
                    fOpd = this.fOperand;
                    if (fOpd == null)
                    {
                        return string.Empty;
                    }

                    // --

                    if (fOpd.fSecsOperandType == FSecsOperandType.SecsItem)
                    {
                        return ((FSecsItem)fOpd).name;
                    }
                    else if (fOpd.fSecsOperandType == FSecsOperandType.Environment)
                    {
                        return ((FEnvironment)fOpd).name;
                    }
                    else if (fOpd.fSecsOperandType == FSecsOperandType.EquipmentState)
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
                    return FEnumConverter.toFormat(this.fXmlNode.get_attrVal(FXmlTagSEP.A_OperandFormat, FXmlTagSEP.D_OperandFormat));
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
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSEP.A_OperandIndex, FXmlTagSEP.D_OperandIndex));
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

                    if (this.fOperandType == FSecsOperandType.EquipmentState)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0010, "Operand Type", "Equipment State"));
                    }

                    if (value < 0)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0014, "Operand Index"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_OperandIndex, FXmlTagSEP.D_OperandIndex, value.ToString(), true);
                    noticeModified(this.fAncestorSecsCondition);
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
                    return FEnumConverter.toOperation(this.fXmlNode.get_attrVal(FXmlTagSEP.A_Operation, FXmlTagSEP.D_Operation));
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

                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_Operation, FXmlTagSEP.D_Operation, FEnumConverter.fromOperation(value), true);
                    noticeModified(this.fAncestorSecsCondition);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSEP.A_Value, FXmlTagSEP.D_Value);
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
                    if (fFormat != FFormat.Ascii && fFormat != FFormat.A2 && fFormat != FFormat.JIS8 && fFormat != FFormat.Char && length > 1)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                    }

                    // --
                    
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_Value, FXmlTagSEP.D_Value, val, true);
                    noticeModified(this.fAncestorSecsCondition);
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
                    if (fFormat != FFormat.Ascii && fFormat != FFormat.A2 && fFormat != FFormat.JIS8 && fFormat != FFormat.Char && length > 1)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                    }
                    
                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_Value, FXmlTagSEP.D_Value, val, true);
                    noticeModified(this.fAncestorSecsCondition);
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

                    if (this.fOperandType == FSecsOperandType.EquipmentState)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0010, "Operand Type", "Equipment State"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_Resource, FXmlTagHEP.D_Resource, FEnumConverter.fromSecsResourceSourceType(FSecsResourceSourceType.None), false);
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_Value, FXmlTagHEP.D_Value, string.Empty, false);                    
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_ExpressionValueType, FXmlTagHEP.D_ExpressionValueType, FEnumConverter.fromExpressionValueType(value), true);
                    noticeModified(this.fAncestorSecsCondition);
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

        public FSecsResourceSourceType fResource
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = this.fXmlNode.get_attrVal(FXmlTagSEP.A_Resource, FXmlTagSEP.D_Resource);
                    if (val == string.Empty)
                    {
                        return FSecsResourceSourceType.None;
                    }
                    // --
                    return FEnumConverter.toSecsResourceSourceType(val);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FSecsResourceSourceType.None;
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
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_Resource, FXmlTagSEP.D_Resource, FEnumConverter.fromSecsResourceSourceType(value), true);
                    noticeModified(this.fAncestorSecsCondition);
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
                    if (fFormat != FFormat.Ascii && fFormat != FFormat.A2 && fFormat != FFormat.JIS8 && fFormat != FFormat.Char && length > 1)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                    }
                    
                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_Value, FXmlTagSEP.D_Value, val, true);
                    noticeModified(this.fAncestorSecsCondition);
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

        public FSecsExpressionValueTransformer fValueTransformer
        {
            get
            {
                try
                {
                    return new FSecsExpressionValueTransformer(this);
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
                    id = this.fXmlNode.get_attrVal(FXmlTagSEP.A_DataConversionSetID, FXmlTagSEP.D_DataConversionSetID);
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
                    return new FDataConversionSet(this.fScdCore, this.fSecsDriver.fXmlNode.selectSingleNode(xpath));
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
                    return this.fXmlNode.get_attrVal(FXmlTagSEP.A_DataConversionSetName, FXmlTagSEP.D_DataConversionSetName);
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
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_DataConversionSetName, FXmlTagSEP.D_DataConversionSetName, value, false);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSEP.A_DataConversionSetExpression, FXmlTagSEP.D_DataConversionSetExpression);
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
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_DataConversionSetExpression, FXmlTagSEP.D_DataConversionSetExpression, value, false);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSEP.A_UserTag1, FXmlTagSEP.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_UserTag1, FXmlTagSEP.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSEP.A_UserTag2, FXmlTagSEP.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_UserTag2, FXmlTagSEP.D_UserTag2, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSEP.A_UserTag3, FXmlTagSEP.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_UserTag3, FXmlTagSEP.D_UserTag3, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSEP.A_UserTag4, FXmlTagSEP.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_UserTag4, FXmlTagSEP.D_UserTag4, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSEP.A_UserTag5, FXmlTagSEP.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_UserTag5, FXmlTagSEP.D_UserTag5, value, true);
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

                    if (this.fXmlNode.fParentNode.name == FXmlTagSCN.E_SecsCondition)
                    {
                        return new FSecsCondition(this.fScdCore, this.fXmlNode.fParentNode);
                    }
                    return new FSecsExpression(this.fScdCore, this.fXmlNode.fParentNode);
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

        public FSecsExpression fPreviousSibling
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

                    return new FSecsExpression(this.fScdCore, this.fXmlNode.fPreviousSibling);
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

        public FSecsExpression fNextSibling
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

                    return new FSecsExpression(this.fScdCore, this.fXmlNode.fNextSibling);
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

        public FSecsExpressionCollection fChildSecsExpressionCollection
        {
            get
            {
                try
                {
                    return new FSecsExpressionCollection(this.fScdCore, this.fXmlNode.selectNodes(FXmlTagSEP.E_SecsExpression));
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
                            "../../" + FXmlTagSCN.E_SecsCondition + "[@" + FXmlTagSCN.A_UniqueId + "='" + fParent.uniqueIdToString + "']";
                    }
                    return new FObjectCollection(this.fScdCore, this.fXmlNode.selectNodes(xpath));
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
                        if (this.fOperand.fSecsOperandType == FSecsOperandType.SecsItem)
                        {
                            xpath =
                            "../../../../../../../" + FXmlTagSLM.E_SecsLibraryModeling +
                            "/" + FXmlTagSLG.E_SecsLibraryGroup +
                            "/" + FXmlTagSLB.E_SecsLibrary +
                            "/" + FXmlTagSML.E_SecsMessageList +
                            "/" + FXmlTagSMS.E_SecsMessages +
                            "/" + FXmlTagSMG.E_SecsMessage +
                            "//" + FXmlTagSIT.E_SecsItem + "[@" + FXmlTagSIT.A_UniqueId + "='" + ((FSecsItem)this.fOperand).uniqueIdToString + "']";
                        }
                        else if (this.fOperand.fSecsOperandType == FSecsOperandType.Environment)
                        {
                            xpath =
                            "../../../../../../../" + FXmlTagSET.E_Setup + "/" + FXmlTagEND.E_EnvironmentDefinition +
                            "/" + FXmlTagENL.E_EnvironmentList +
                            "//" + FXmlTagENV.E_Environment + "[@" + FXmlTagENV.A_UniqueId + "='" + ((FEnvironment)this.fOperand).uniqueIdToString + "']";
                        }
                        else if (this.fOperand.fSecsOperandType == FSecsOperandType.EquipmentState)
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
                    return new FObjectCollection(this.fScdCore, this.fXmlNode.selectNodes(xpath));
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
                    return this.fXmlNode.containsNode(FXmlTagSEP.E_SecsExpression);
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
                    if (this.fXmlNode.get_attrVal(FXmlTagSEP.A_OperandId, FXmlTagSEP.D_OperandId) == string.Empty)
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
                    if (this.fXmlNode.get_attrVal(FXmlTagSEP.A_Transformer, FXmlTagSEP.D_Transformer) == string.Empty)
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
                    if (this.fXmlNode.get_attrVal(FXmlTagSEP.A_DataConversionSetID, FXmlTagSEP.D_DataConversionSetID) == string.Empty)
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

        public FSecsCondition fAncestorSecsCondition
        {
            get
            {
                try
                {
                    return this.getAncestorSecsCondition();
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
                        !FClipboard.containsData(FCbObjectFormat.SecsExpression)
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
                    if (!FClipboard.containsData(FCbObjectFormat.SecsExpression))
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
            FISecsOperand fOpd = null;
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
                        else if (fOpd.fSecsOperandType == FSecsOperandType.SecsItem)
                        {
                            info += ((FSecsItem)fOpd).name;
                        }
                        else if (fOpd.fSecsOperandType == FSecsOperandType.Environment)
                        {
                            info += ((FEnvironment)fOpd).name;
                        }
                        else if (fOpd.fSecsOperandType == FSecsOperandType.EquipmentState)
                        {
                            info += ((FEquipmentState)fOpd).name;
                        }
                        info += "[" + this.operandIndex.ToString() + "]";
                        // --
                        info += " " + FEnumConverter.toOperationExp(this.fOperation) + " ";
                        // --
                        if (fExpressionValueType == FExpressionValueType.Value)
                        {
                            if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2 || fFormat == FFormat.Char)
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

        public FSecsExpression appendChildSecsExpression(
           FSecsExpression fNewChild
           )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // ***
                // SECS Expression의 Type이 Comparison일 경우 SECS Expression를 추가할 수 없다.
                // ***
                if (this.fExpressionType == FExpressionType.Comparison)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Expression's Type", "Bracket"));
                }

                // --

                fNewChild.replace(this.fScdCore, this.fXmlNode.appendChild(fNewChild.fXmlNode));                
                // --                
                if (this.isModelingObject)
                {
                    FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectAppendCompleted, this.fSecsDriver, this, fNewChild)
                        );
                    noticeModified(this.fAncestorSecsCondition);
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

        public FSecsExpression insertBeforeChildSecsExpression(
            FSecsExpression fNewChild,
            FSecsExpression fRefChild
            )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // ***
                // SECS Expression의 Type이 Comparison일 경우 SECS Expression를 추가할 수 없다.
                // ***
                if (this.fExpressionType == FExpressionType.Comparison)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Expression's Type", "Bracket"));
                }

                // --

                fNewChild.replace(this.fScdCore, this.fXmlNode.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                // --                
                if (this.isModelingObject)
                {
                    FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                    // ---
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectInsertBeforeCompleted, this.fSecsDriver, this, fNewChild)
                        );
                    noticeModified(this.fAncestorSecsCondition);
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

        public FSecsExpression insertAfterChildSecsExpression(
            FSecsExpression fNewChild,
            FSecsExpression fRefChild
            )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // ***
                // SECS Expression의 Type이 Comparison일 경우 SECS Expression를 추가할 수 없다.
                // ***
                if (this.fExpressionType == FExpressionType.Comparison)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Expression's Type", "Bracket"));
                }

                // --

                fNewChild.replace(this.fScdCore, this.fXmlNode.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));                
                // --                
                if (this.isModelingObject)
                {
                    FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this.fSecsDriver, this, fNewChild)
                        );
                    noticeModified(this.fAncestorSecsCondition);
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
            FSecsCondition fScn = null;
            FIObject fParent = null;
            FSecsExpression fNextSep = null;
            bool isModelingObject = false;

            try
            {
                FSecsDriverCommon.validateRemoveChildObject(this.fXmlNode.fParentNode, this.fXmlNode);                

                // --

                resetRelation();

                // --

                fScn = this.fAncestorSecsCondition;
                fParent = this.fParent;
                fNextSep = this.fNextSibling;
                isModelingObject = this.isModelingObject;                
                this.replace(this.fScdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                
                // --

                // ***
                // 제거되는 Object의 다음 Object가 최상위일 경우 Logical를 And로 변경한다.
                // ***
                if (fNextSep != null && fNextSep.fPreviousSibling == null)
                {
                    fNextSep.fXmlNode.set_attrVal(FXmlTagSEP.A_Logical, FXmlTagSEP.D_Logical, FEnumConverter.fromLogical(FLogical.And), true);
                }

                // --

                if (isModelingObject)
                {
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectRemoveCompleted, this.fSecsDriver, fParent, this)
                        );
                    noticeModified(fScn);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fScn = null;
                fParent = null;
                fNextSep = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsExpression removeChildSecsExpression(
            FSecsExpression fChild
            )
        {
            try
            {
                FSecsDriverCommon.validateRemoveChildObject(this.fXmlNode, fChild.fXmlNode);

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

        public void removeChildSecsExpression(
            FSecsExpression[] fChilds
            )
        {
            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                foreach (FSecsExpression fSep in fChilds)
                {
                    FSecsDriverCommon.validateRemoveChildObject(this.fXmlNode, fSep.fXmlNode);
                }

                // --

                foreach (FSecsExpression fSep in fChilds)
                {
                    fSep.remove();
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

        public void removeAllChildSecsExpression(
            )
        {
            FSecsExpressionCollection fSepCollction = null;

            try
            {
                fSepCollction = this.fChildSecsExpressionCollection;
                if (fSepCollction.count == 0)
                {
                    return;
                }

                // --

                foreach (FSecsExpression fSep in fSepCollction)
                {
                    fSep.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fSepCollction != null)
                {
                    fSepCollction.Dispose();
                    fSepCollction = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void setOperand(
            FSecsItem fSecsItem
            )
        {
            string oldSitId = string.Empty;
            string newSitId = string.Empty;
            FFormat fFormat;

            try
            {
                // ***
                // SECS Item 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fSecsItem.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "SECS Item", "Modeling File"));
                }

                // ***
                // SECS Expression 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "SECS Expression", "Modeling File"));
                }

                // ***
                // SECS Item과 SECS Expression의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fSecsItem))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the SECS Item and the SECS Expression", "same"));
                }

                // ***
                // SECS Condition에 SECS Message가 설정되어 있는지 검사
                // ***
                if (!this.fAncestorSecsCondition.hasMessage)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "SECS Message in the SECS Condition"));
                }

                // ***
                // SECS Item의 조상 SECS Message가 SECS Condition에 설정된 SECS Message와 동일한지 검사
                // ***
                if (this.fAncestorSecsCondition.fMessage != fSecsItem.fAncestorSecsMessage)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "SECS Message of the SECS Item and the SECS Condition", "same"));
                }
                
                // ***
                // Operand Format이 List, AsciiList, Raw일 경우 Comaprsion Mode가 Length 인지 검사
                // ***
                fFormat = fSecsItem.fFormat;
                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Raw || fFormat == FFormat.Unknown)
                {
                    if (this.fComparisonMode != FComparisonMode.Length)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Comparison Mode", "Length"));
                    }
                }

                // --

                oldSitId = this.fXmlNode.get_attrVal(FXmlTagSEP.A_OperandId, FXmlTagSEP.D_OperandId);
                newSitId = fSecsItem.uniqueIdToString;
                // --
                if (oldSitId == newSitId)
                {
                    return;
                }

                // --

                // ***
                // 이전에 설정된 Operand가 존재할 경우 Reset 한다.
                // ***
                if (oldSitId != string.Empty)
                {
                    resetOperand(false);
                }

                // --
                
                this.fXmlNode.set_attrVal(FXmlTagSEP.A_OperandFormat, FXmlTagSEP.D_OperandFormat, FEnumConverter.fromFormat(fFormat), false);
                this.fXmlNode.set_attrVal(FXmlTagSEP.A_Value, FXmlTagSEP.D_Value, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagSEP.A_Transformer, FXmlTagSEP.D_Transformer, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagSEP.A_OperandId, FXmlTagSEP.D_OperandId, newSitId, true);
                // --
                fSecsItem.lockObject();
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
                // SECS Expression 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "SECS Expression", "Modeling File"));
                }

                // ***
                // Environment와 SECS Expression의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fEnvironment))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the Environment and the SECS Expression", "same"));
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

                oldEnvId = this.fXmlNode.get_attrVal(FXmlTagSEP.A_OperandId, FXmlTagSEP.D_OperandId);
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

                this.fXmlNode.set_attrVal(FXmlTagSEP.A_OperandFormat, FXmlTagSEP.D_OperandFormat, FEnumConverter.fromFormat(fFormat), false);
                this.fXmlNode.set_attrVal(FXmlTagSEP.A_Value, FXmlTagSEP.D_Value, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagSEP.A_Transformer, FXmlTagSEP.D_Transformer, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagSEP.A_OperandId, FXmlTagSEP.D_OperandId, newEnvId, true);
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
                // SECS Expression 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "SECS Expression", "Modeling File"));
                }

                // ***
                // Equipment State와 SECS Expression의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fEquipmentState))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the Equipment State and the SECS Expression", "same"));
                }

                // --

                oldEstId = this.fXmlNode.get_attrVal(FXmlTagSEP.A_OperandId, FXmlTagSEP.D_OperandId);
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

                this.fXmlNode.set_attrVal(FXmlTagSEP.A_OperandFormat, FXmlTagSEP.D_OperandFormat, FEnumConverter.fromFormat(FFormat.Ascii), false);
                this.fXmlNode.set_attrVal(FXmlTagSEP.A_OperandIndex, FXmlTagSEP.D_OperandIndex, FXmlTagSEP.D_OperandIndex, false);
                this.fXmlNode.set_attrVal(FXmlTagSEP.A_Value, FXmlTagSEP.D_Value, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagSEP.A_Transformer, FXmlTagSEP.D_Transformer, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagSEP.A_OperandId, FXmlTagSEP.D_OperandId, newEstId, true);
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
            FISecsOperand fSecsOperand
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
                
                if (this.fOperandType == FSecsOperandType.SecsItem)
                {
                    if (fSecsOperand.fSecsOperandType != FSecsOperandType.SecsItem)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Operand's Type", "SECS Item"));
                    }
                    // --
                    setOperand((FSecsItem)fSecsOperand);
                }
                else if (this.fOperandType == FSecsOperandType.Environment)
                {
                    if (fSecsOperand.fSecsOperandType != FSecsOperandType.Environment)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Operand's Type", "Environment"));
                    }
                    // --
                    setOperand((FEnvironment)fSecsOperand);
                }
                else if (this.fOperandType == FSecsOperandType.EquipmentState)
                {
                    if (fSecsOperand.fSecsOperandType != FSecsOperandType.EquipmentState)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Operand's Type", "EquipmentState"));
                    }
                    // --
                    setOperand((FEquipmentState)fSecsOperand);
                }
                // --
                noticeModified(this.fAncestorSecsCondition);
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
            FISecsOperand fOpd = null;

            try
            {
                foreach (FSecsExpression fSep in this.fChildSecsExpressionCollection)
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

                this.fXmlNode.set_attrVal(FXmlTagSEP.A_OperandFormat, FXmlTagSEP.D_OperandFormat, FEnumConverter.fromFormat(FFormat.Ascii), false);
                this.fXmlNode.set_attrVal(FXmlTagSEP.A_OperandIndex, FXmlTagSEP.D_OperandIndex, "0", false);
                this.fXmlNode.set_attrVal(FXmlTagSEP.A_Value, FXmlTagSEP.D_Value, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagSEP.A_Transformer, FXmlTagSEP.D_Transformer, string.Empty, false);
                // --
                resetDataConversionSet(false);
                // --
                this.fXmlNode.set_attrVal(FXmlTagSEP.A_OperandId, FXmlTagSEP.D_OperandId, string.Empty, isModifyEvent);
                // --
                if (isModifyEvent)
                {
                    noticeModified(this.fAncestorSecsCondition);
                }

                // --

                if (fOpd.fSecsOperandType == FSecsOperandType.SecsItem)
                {
                    ((FSecsItem)fOpd).unlockObject();
                }
                else if (fOpd.fSecsOperandType == FSecsOperandType.Environment)
                {
                    ((FEnvironment)fOpd).unlockObject();
                }
                else if (fOpd.fSecsOperandType == FSecsOperandType.EquipmentState)
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
            FSecsCondition fScn
            )
        {
            try
            {
                if (fScn != null)
                {
                    fScn.noticeChildModified();
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
                fXmlNode.set_attrVal(FXmlTagSEP.A_OperandId, FXmlTagSEP.D_OperandId, FXmlTagSEP.D_OperandId);
                fXmlNode.set_attrVal(FXmlTagSEP.A_OperandFormat, FXmlTagSEP.D_OperandFormat, FXmlTagSEP.D_OperandFormat);
                fXmlNode.set_attrVal(FXmlTagSEP.A_OperandIndex, FXmlTagSEP.D_OperandIndex, FXmlTagSEP.D_OperandIndex);
                fXmlNode.set_attrVal(FXmlTagSEP.A_Value, FXmlTagSEP.D_Value, FXmlTagSEP.D_Value);
                fXmlNode.set_attrVal(FXmlTagSEP.A_Transformer, FXmlTagSEP.D_Transformer, FXmlTagSEP.D_Transformer);
                fXmlNode.set_attrVal(FXmlTagSEP.A_DataConversionSetExpression, FXmlTagSEP.D_DataConversionSetExpression, string.Empty);
                fXmlNode.set_attrVal(FXmlTagSEP.A_DataConversionSetName, FXmlTagSEP.D_DataConversionSetName, string.Empty);
                fXmlNode.set_attrVal(FXmlTagSEP.A_DataConversionSetID, FXmlTagSEP.D_DataConversionSetID, string.Empty);
                
                // --

                foreach (FXmlNode fXmlNodeSep in fXmlNode.selectNodes(FXmlTagSEP.E_SecsExpression))
                {
                    FSecsExpression.resetFlowNode(fXmlNodeSep);                    
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
                this.copyObject(FCbObjectFormat.SecsExpression, fXmlNode);
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
                FSecsDriverCommon.validateCutObject(this.fXmlNode);

                // --

                this.remove();

                // --

                resetFlowNode(this.fXmlNode);
                this.copyObject(FCbObjectFormat.SecsExpression, this.fXmlNode);
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

        public FSecsExpression pasteSibling(
            )
        {
            FIObject fParent = null;
            FSecsExpression fSecsExpression = null;
            
            try
            {
                FSecsDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.SecsExpression);

                // --
                
                fParent = this.fParent;

                fSecsExpression = (FSecsExpression)this.pasteObject(FCbObjectFormat.SecsExpression);
                if (fParent.fObjectType == FObjectType.SecsCondition)
                {
                    return ((FSecsCondition)fParent).insertAfterChildSecsExpression(fSecsExpression, this);
                }
                return ((FSecsExpression)fParent).insertAfterChildSecsExpression(fSecsExpression, this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecsExpression = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsExpression pasteChild(
           )
        {
            FSecsExpression fSecsExpression = null;

            try
            {
                FSecsDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.SecsExpression);

                // --

                fSecsExpression = (FSecsExpression)this.pasteObject(FCbObjectFormat.SecsExpression);
                this.appendChildSecsExpression(fSecsExpression);

                return fSecsExpression;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecsExpression = null;
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
                FSecsDriverCommon.validateMoveUpObject(this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fScdCore, this.fXmlNode.moveUp());

                // --

                if (this.fXmlNode.fPreviousSibling == null)
                {
                    this.fXmlNode.set_attrVal(FXmlTagSEP.A_Logical, FXmlTagSEP.D_Logical, FEnumConverter.fromLogical(FLogical.And));
                }

                // --

                if (isModelingObject)
                {
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveUpCompleted, this.fSecsDriver, fParent, this)
                        );
                    noticeModified(this.fAncestorSecsCondition);
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
                FSecsDriverCommon.validateMoveDownObject(this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fScdCore, this.fXmlNode.moveDown());

                // --

                if (isModelingObject)
                {
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveDownCompleted, this.fSecsDriver, fParent, this)
                        );
                    noticeModified(this.fAncestorSecsCondition);
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
            FSecsExpression fRefObject
            )
        {
            try
            {
                FSecsDriverCommon.validateMoveToObject(this.fXmlNode, fRefObject.fXmlNode);

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

                if (!this.fAncestorSecsCondition.Equals(fRefObject.fAncestorSecsCondition))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Ancestor SECS Condition ", "same"));
                }

                // --

                this.replace(this.fScdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fScdCore, fRefObject.fXmlNode.fParentNode.insertAfter(this.fXmlNode, fRefObject.fXmlNode));

                // --

                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fSecsDriver, this, fRefObject)
                    );
                noticeModified(this.fAncestorSecsCondition);
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
            FSecsCondition fRefObject
            )
        {
            try
            {
                FSecsDriverCommon.validateMoveToObject(this.fXmlNode, fRefObject.fXmlNode);

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

                if (!this.fAncestorSecsCondition.Equals(fRefObject))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Ancestor SECS Condition ", "same"));
                }

                if (fRefObject.fChildSecsExpressionCollection.count > 0)
                {
                    if (this.Equals(fRefObject.fChildSecsExpressionCollection[fRefObject.fChildSecsExpressionCollection.count - 1]))
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0060, "Object", "same localtion"));
                    }
                }

                // --

                this.replace(this.fScdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fScdCore, fRefObject.fXmlNode.appendChild(this.fXmlNode));

                // --

                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fSecsDriver, this, fRefObject)
                    );
                noticeModified(this.fAncestorSecsCondition);
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
                // 이 Secs Expression 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Secs Expression", "Modeling File"));
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

                oldDcsId = this.fXmlNode.get_attrVal(FXmlTagSEP.A_DataConversionSetID, FXmlTagSEP.D_DataConversionSetID);
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
                
                this.fXmlNode.set_attrVal(FXmlTagSEP.A_DataConversionSetExpression, FXmlTagSEP.D_DataConversionSetExpression, fDataConversionSet.expression, false);
                this.fXmlNode.set_attrVal(FXmlTagSEP.A_DataConversionSetName, FXmlTagSEP.D_DataConversionSetName, fDataConversionSet.name, false);
                this.fXmlNode.set_attrVal(FXmlTagSEP.A_DataConversionSetID, FXmlTagSEP.D_DataConversionSetID, newDcsId, true);
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
                foreach (FSecsExpression fSep in this.fChildSecsExpressionCollection)
                {
                    fSep.resetDataConversionSet(isModifyEvent);
                }

                // --

                fDcs = this.fDataConversionSet;
                if (fDcs == null)
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagSEP.A_DataConversionSetExpression, FXmlTagSEP.D_DataConversionSetExpression, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagSEP.A_DataConversionSetName, FXmlTagSEP.D_DataConversionSetName, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagSEP.A_DataConversionSetID, FXmlTagSEP.D_DataConversionSetID, string.Empty, isModifyEvent);
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
