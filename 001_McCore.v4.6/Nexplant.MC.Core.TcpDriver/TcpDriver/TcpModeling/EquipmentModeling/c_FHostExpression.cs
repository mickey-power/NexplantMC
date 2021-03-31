/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FHostExpression.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.16
--  Description     : FAMate Core FaTcpDriver Host Expression Class 
--  History         : Created by Jeff.Kim at 2013.07.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    public class FHostExpression : FBaseObject<FHostExpression>, FIObject
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FHostExpression(
            FTcpDriver fTcpDriver
            )
            : base(fTcpDriver.fTcdCore, FTcpDriverCommon.createXmlNodeHEP(fTcpDriver.fTcdCore.fXmlDoc))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FHostExpression(
            FTcdCore fTcdCore,
            FXmlNode fXmlNode
            )
            : base(fTcdCore, fXmlNode)
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FHostExpression(
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
                    return FObjectType.HostExpression;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.HostExpression;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagHEP.A_UniqueId, FXmlTagHEP.D_UniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHEP.A_Name, FXmlTagHEP.D_Name);
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
                    FTcpDriverCommon.validateName(value, true);

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_Name, FXmlTagHEP.D_Name, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHEP.A_Description, FXmlTagHEP.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_Description, FXmlTagHEP.D_Description, value, true);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagHEP.A_FontColor, FXmlTagHEP.D_FontColor));
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
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_FontColor, FXmlTagHEP.D_FontColor, value.Name, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagHEP.A_FontBold, FXmlTagHEP.D_FontBold));
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
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_FontBold, FXmlTagHEP.D_FontBold, FBoolean.fromBool(value), true);
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
                    return FEnumConverter.toLogical(this.fXmlNode.get_attrVal(FXmlTagHEP.A_Logical, FXmlTagHEP.D_Logical));
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
                    // 첫번째 Host Expression인 경우 Logical를 변경할 수 없다.
                    // ***
                    if (this.fPreviousSibling == null)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0008, "First Expression", "Logical"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_Logical, FXmlTagHEP.D_Logical, FEnumConverter.fromLogical(value), true);
                    noticeModified(this.fAncestorHostCondition);
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
                    return FEnumConverter.toExpressionType(this.fXmlNode.get_attrVal(FXmlTagHEP.A_ExpressionType, FXmlTagHEP.D_ExpressionType));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FExpressionType.Bracket;
            }

            set
            {
                try
                {
                    // ***
                    // 자식(Host Expression)이 존재할 경우 Expression Type를 변경할 수 없다.
                    // ***
                    if (this.hasChild)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0013, "Object's Child"));
                    }

                    // -- 

                    resetOperand(false);

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_ComparisonMode, FXmlTagHEP.D_ComparisonMode, FEnumConverter.fromComparisonMode(FComparisonMode.Value), false);
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_OperandType, FXmlTagHEP.D_OperandType, FEnumConverter.fromHostOperandType(FHostOperandType.HostItem), false);
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_OperandIndex, FXmlTagHEP.D_OperandIndex, "0", false);
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_Operation, FXmlTagHEP.D_Operation, FEnumConverter.fromOperation(FOperation.Equal), false);
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_ExpressionValueType, FXmlTagHEP.D_ExpressionValueType, FEnumConverter.fromExpressionValueType(FExpressionValueType.Value), false);
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_Resource, FXmlTagHEP.D_Resource, FEnumConverter.fromHostResourceSourceType(FHostResourceSourceType.None), false);
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_Value, FXmlTagHEP.D_Value, string.Empty, false);
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_Transformer, FXmlTagHEP.D_Transformer, string.Empty, false);
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_ExpressionType, FXmlTagHEP.D_ExpressionType, FEnumConverter.fromExpressionType(value), true);
                    // --
                    noticeModified(this.fAncestorHostCondition);
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
                    return FEnumConverter.toComparisonMode(this.fXmlNode.get_attrVal(FXmlTagHEP.A_ComparisonMode, FXmlTagHEP.D_ComparisonMode));
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

                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_OperandType, FXmlTagHEP.D_OperandType, FEnumConverter.fromHostOperandType(FHostOperandType.HostItem), false);
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_OperandIndex, FXmlTagHEP.D_OperandIndex, "0", false);
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_Operation, FXmlTagHEP.D_Operation, FEnumConverter.fromOperation(FOperation.Equal), false);
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_ExpressionValueType, FXmlTagHEP.D_ExpressionValueType, FEnumConverter.fromExpressionValueType(FExpressionValueType.Value), false);
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_Value, FXmlTagHEP.D_Value, string.Empty, false);
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_Resource, FXmlTagHEP.D_Resource, FEnumConverter.fromHostResourceSourceType(FHostResourceSourceType.None), false);
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_Transformer, FXmlTagHEP.D_Transformer, string.Empty, false);
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_ComparisonMode, FXmlTagHEP.D_ComparisonMode, FEnumConverter.fromComparisonMode(value), true);

                    // --

                    noticeModified(this.fAncestorHostCondition);
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

        public FHostOperandType fOperandType
        {
            get
            {
                try
                {
                    return FEnumConverter.toHostOperandType(this.fXmlNode.get_attrVal(FXmlTagHEP.A_OperandType, FXmlTagHEP.D_OperandType));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FHostOperandType.HostItem;
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

                    if (this.fComparisonMode == FComparisonMode.Length && value == FHostOperandType.EquipmentState)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Comparison Mode", "Value"));
                    }

                    // --

                    resetOperand(false);

                    // --


                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_ExpressionValueType, FXmlTagHEP.D_ExpressionValueType, FEnumConverter.fromExpressionValueType(FExpressionValueType.Value), false);
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_Resource, FXmlTagHEP.D_Resource, FEnumConverter.fromHostResourceSourceType(FHostResourceSourceType.None), false);
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_Value, FXmlTagHEP.D_Value, string.Empty, false);
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_Transformer, FXmlTagHEP.D_Transformer, string.Empty, false);
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_OperandType, FXmlTagHEP.D_OperandType, FEnumConverter.fromHostOperandType(value), true);

                    // --

                    noticeModified(this.fAncestorHostCondition);
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

        public FIHostOperand fOperand
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagHEP.A_OperandId, FXmlTagHEP.D_OperandId);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    if (this.fOperandType == FHostOperandType.HostItem)
                    {
                        xpath =
                            FXmlTagHLM.E_HostLibraryModeling +
                            "/" + FXmlTagHLG.E_HostLibraryGroup +
                            "/" + FXmlTagHLB.E_HostLibrary +
                            "/" + FXmlTagHML.E_HostMessageList +
                            "/" + FXmlTagHMS.E_HostMessages +
                            "/" + FXmlTagHMG.E_HostMessage +
                            "//" + FXmlTagHIT.E_HostItem + "[@" + FXmlTagHIT.A_UniqueId + "='" + id + "']";
                        // --
                        return new FHostItem(this.fTcdCore, this.fTcpDriver.fXmlNode.selectSingleNode(xpath));
                    }
                    else if (this.fOperandType == FHostOperandType.Environment)
                    {
                        xpath =
                            FXmlTagSET.E_Setup +
                            "/" + FXmlTagEND.E_EnvironmentDefinition +
                            "/" + FXmlTagENL.E_EnvironmentList +
                            "//" + FXmlTagENV.E_Environment + "[@" + FXmlTagENV.A_UniqueId + "='" + id + "']";
                        // --
                        return new FEnvironment(this.fTcdCore, this.fTcpDriver.fXmlNode.selectSingleNode(xpath));
                    }
                    else if (this.fOperandType == FHostOperandType.EquipmentState)
                    {
                        xpath =
                            FXmlTagSET.E_Setup +
                            "/" + FXmlTagESD.E_EquipmentStateSetDefinition +
                            "/" + FXmlTagESL.E_EquipmentStateSetList +
                            "/" + FXmlTagESS.E_EquipmentStateSet +
                            "/" + FXmlTagEST.E_EquipmentState + "[@" + FXmlTagEST.A_UniqueId + "='" + id + "']";
                        // --
                        return new FEquipmentState(this.fTcdCore, this.fTcpDriver.fXmlNode.selectSingleNode(xpath));
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
                FIHostOperand fOpd = null;

                try
                {
                    fOpd = this.fOperand;
                    if (fOpd == null)
                    {
                        return string.Empty;
                    }

                    // --

                    if (fOpd.fHostOperandType == FHostOperandType.HostItem)
                    {
                        return ((FHostItem)fOpd).name;
                    }
                    else if (fOpd.fHostOperandType == FHostOperandType.Environment)
                    {
                        return ((FEnvironment)fOpd).name;
                    }
                    else if (fOpd.fHostOperandType == FHostOperandType.EquipmentState)
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
                    return FEnumConverter.toFormat(this.fXmlNode.get_attrVal(FXmlTagHEP.A_OperandFormat, FXmlTagHEP.D_OperandFormat));
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
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagHEP.A_OperandIndex, FXmlTagHEP.D_OperandIndex));
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

                    if (this.fOperandType == FHostOperandType.EquipmentState)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0010, "Operand Type", "Equipment State"));
                    }

                    if (value < 0)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0014, "Operand Index"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_OperandIndex, FXmlTagHEP.D_OperandIndex, value.ToString(), true);
                    noticeModified(this.fAncestorHostCondition);
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
                    return FEnumConverter.toOperation(this.fXmlNode.get_attrVal(FXmlTagHEP.A_Operation, FXmlTagHEP.D_Operation));
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

                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_Operation, FXmlTagHEP.D_Operation, FEnumConverter.fromOperation(value), true);
                    noticeModified(this.fAncestorHostCondition);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHEP.A_Value, FXmlTagHEP.D_Value);
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
                    // Format이 Ascii 계열이 아닐 경우, Value의 Length를 1보다 클 수 없다.
                    // ***
                    if (fFormat != FFormat.Ascii && fFormat != FFormat.A2 && fFormat != FFormat.JIS8 && length > 1)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_Value, FXmlTagHEP.D_Value, val, true);
                    noticeModified(this.fAncestorHostCondition);
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
                    // Format이 Ascii 계열이 아닐 경우, Value의 Length를 1보다 클 수 없다.
                    // ***
                    if (fFormat != FFormat.Ascii && fFormat != FFormat.A2 && fFormat != FFormat.JIS8 && length > 1)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Value"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_Value, FXmlTagHEP.D_Value, val, true);
                    noticeModified(this.fAncestorHostCondition);
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

                    if (this.fOperandType == FHostOperandType.EquipmentState)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0010, "Operand Type", "Equipment State"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_Resource, FXmlTagHEP.D_Resource, FEnumConverter.fromHostResourceSourceType(FHostResourceSourceType.None), false);
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_Value, FXmlTagHEP.D_Value, string.Empty, false);
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_ExpressionValueType, FXmlTagHEP.D_ExpressionValueType, FEnumConverter.fromExpressionValueType(value), true);
                    noticeModified(this.fAncestorHostCondition);
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

        public FHostResourceSourceType fResource
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = this.fXmlNode.get_attrVal(FXmlTagHEP.A_Resource, FXmlTagHEP.D_Resource);
                    if (val == string.Empty)
                    {
                        return FHostResourceSourceType.None;
                    }
                    // --
                    return FEnumConverter.toHostResourceSourceType(val);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FHostResourceSourceType.None;
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
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_Resource, FXmlTagHEP.D_Resource, FEnumConverter.fromHostResourceSourceType(value), true);
                    noticeModified(this.fAncestorHostCondition);
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

                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_Value, FXmlTagHEP.D_Value, val, true);
                    noticeModified(this.fAncestorHostCondition);
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

        public FHostExpressionValueTransformer fValueTransformer
        {
            get
            {
                try
                {
                    return new FHostExpressionValueTransformer(this);
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
                    id = this.fXmlNode.get_attrVal(FXmlTagHEP.A_DataConversionSetID, FXmlTagHEP.D_DataConversionSetID);
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
                    return new FDataConversionSet(this.fTcdCore, this.fTcpDriver.fXmlNode.selectSingleNode(xpath));
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
                    return this.fXmlNode.get_attrVal(FXmlTagHEP.A_DataConversionSetName, FXmlTagHEP.D_DataConversionSetName);
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
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_DataConversionSetName, FXmlTagHEP.D_DataConversionSetName, value, false);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHEP.A_DataConversionSetExpression, FXmlTagHEP.D_DataConversionSetExpression);
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
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_DataConversionSetExpression, FXmlTagHEP.D_DataConversionSetExpression, value, false);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHEP.A_UserTag1, FXmlTagHEP.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_UserTag1, FXmlTagHEP.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHEP.A_UserTag2, FXmlTagHEP.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_UserTag2, FXmlTagHEP.D_UserTag2, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHEP.A_UserTag3, FXmlTagHEP.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_UserTag3, FXmlTagHEP.D_UserTag3, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHEP.A_UserTag4, FXmlTagHEP.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_UserTag4, FXmlTagHEP.D_UserTag4, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHEP.A_UserTag5, FXmlTagHEP.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_UserTag5, FXmlTagHEP.D_UserTag5, value, true);
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

                    if (this.fXmlNode.fParentNode.name == FXmlTagHCN.E_HostCondition)
                    {
                        return new FHostCondition(this.fTcdCore, this.fXmlNode.fParentNode);
                    }
                    return new FHostExpression(this.fTcdCore, this.fXmlNode.fParentNode);
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

        public FHostExpression fPreviousSibling
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

                    return new FHostExpression(this.fTcdCore, this.fXmlNode.fPreviousSibling);
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

        public FHostExpression fNextSibling
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

                    return new FHostExpression(this.fTcdCore, this.fXmlNode.fNextSibling);
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

        public FHostExpressionCollection fChildHostExpressionCollection
        {
            get
            {
                try
                {
                    return new FHostExpressionCollection(this.fTcdCore, this.fXmlNode.selectNodes(FXmlTagHEP.E_HostExpression));
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
                            "../../" + FXmlTagHCN.E_HostCondition + "[@" + FXmlTagHCN.A_UniqueId + "='" + fParent.uniqueIdToString + "']";
                    }
                    return new FObjectCollection(this.fTcdCore, this.fXmlNode.selectNodes(xpath));
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
                    if (this.hasOperand)
                    {
                        if (this.fOperand.fHostOperandType == FHostOperandType.HostItem)
                        {
                            xpath =
                            "../../../../../../../" + FXmlTagHLM.E_HostLibraryModeling +
                            "/" + FXmlTagHLG.E_HostLibraryGroup +
                            "/" + FXmlTagHLB.E_HostLibrary +
                            "/" + FXmlTagHML.E_HostMessageList +
                            "/" + FXmlTagHMS.E_HostMessages +
                            "/" + FXmlTagHMG.E_HostMessage +
                            "//" + FXmlTagHIT.E_HostItem + "[@" + FXmlTagHIT.A_UniqueId + "='" + ((FHostItem)this.fOperand).uniqueIdToString + "']";
                        }
                        else if (this.fOperand.fHostOperandType == FHostOperandType.Environment)
                        {
                            xpath =
                            "../../../../../../../" + FXmlTagSET.E_Setup + "/" + FXmlTagEND.E_EnvironmentDefinition +
                            "/" + FXmlTagENL.E_EnvironmentList +
                            "//" + FXmlTagENV.E_Environment + "[@" + FXmlTagENV.A_UniqueId + "='" + ((FEnvironment)this.fOperand).uniqueIdToString + "']";
                        }
                        else if (this.fOperand.fHostOperandType == FHostOperandType.EquipmentState)
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
                    return new FObjectCollection(this.fTcdCore, this.fXmlNode.selectNodes(xpath));
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
                    return this.fXmlNode.containsNode(FXmlTagHEP.E_HostExpression);
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
                    if (this.fXmlNode.get_attrVal(FXmlTagHEP.A_OperandId, FXmlTagHEP.D_OperandId) == string.Empty)
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
                    if (this.fXmlNode.get_attrVal(FXmlTagHEP.A_Transformer, FXmlTagHEP.D_Transformer) == string.Empty)
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
                    if (this.fXmlNode.get_attrVal(FXmlTagHEP.A_DataConversionSetID, FXmlTagHEP.D_DataConversionSetID) == string.Empty)
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

        public FHostCondition fAncestorHostCondition
        {
            get
            {
                try
                {
                    return this.getAncestorHostCondition();
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
                        !FClipboard.containsData(FCbObjectFormat.HostExpression)
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
                    if (!FClipboard.containsData(FCbObjectFormat.HostExpression))
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
            FIHostOperand fOpd = null;
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
                        else if (fOpd.fHostOperandType == FHostOperandType.HostItem)
                        {
                            info += ((FHostItem)fOpd).name;
                        }
                        else if (fOpd.fHostOperandType == FHostOperandType.Environment)
                        {
                            info += ((FEnvironment)fOpd).name;
                        }
                        else if (fOpd.fHostOperandType == FHostOperandType.EquipmentState)
                        {
                            info += ((FEquipmentState)fOpd).name;
                        }
                        info += "[" + this.operandIndex.ToString() + "]";
                        // --
                        info += " " + FEnumConverter.toOperationExp(this.fOperation) + " ";
                        // --
                        if (this.fExpressionValueType == FExpressionValueType.Value)
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
                fOpd = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostExpression appendChildHostExpression(
           FHostExpression fNewChild
           )
        {
            try
            {
                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // ***
                // Host Expression의 Type이 Comparison일 경우 Host Expression를 추가할 수 없다.
                // ***
                if (this.fExpressionType == FExpressionType.Comparison)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Expression's Type", "Bracket"));
                }

                // --

                fNewChild.replace(this.fTcdCore, this.fXmlNode.appendChild(fNewChild.fXmlNode));
                // --                
                if (this.isModelingObject)
                {
                    FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fTcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectAppendCompleted, this.fTcpDriver, this, fNewChild)
                        );
                    noticeModified(this.fAncestorHostCondition);
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

        public FHostExpression insertBeforeChildHostExpression(
            FHostExpression fNewChild,
            FHostExpression fRefChild
            )
        {
            try
            {
                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // ***
                // Host Expression의 Type이 Comparison일 경우 Host Expression를 추가할 수 없다.
                // ***
                if (this.fExpressionType == FExpressionType.Comparison)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Expression's Type", "Bracket"));
                }

                // --

                fNewChild.replace(this.fTcdCore, this.fXmlNode.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                // --                
                if (this.isModelingObject)
                {
                    FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                    // ---
                    this.fTcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectInsertBeforeCompleted, this.fTcpDriver, this, fNewChild)
                        );
                    noticeModified(this.fAncestorHostCondition);
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

        public FHostExpression insertAfterChildHostExpression(
            FHostExpression fNewChild,
            FHostExpression fRefChild
            )
        {
            try
            {
                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // ***
                // Host Expression의 Type이 Comparison일 경우 Host Expression를 추가할 수 없다.
                // ***
                if (this.fExpressionType == FExpressionType.Comparison)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Expression's Type", "Bracket"));
                }

                // --

                fNewChild.replace(this.fTcdCore, this.fXmlNode.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                // --                
                if (this.isModelingObject)
                {
                    FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fTcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this.fTcpDriver, this, fNewChild)
                        );
                    noticeModified(this.fAncestorHostCondition);
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
            FHostCondition fHcn = null;
            FIObject fParent = null;
            FHostExpression fNextHep = null;
            bool isModelingObject = false;

            try
            {
                FTcpDriverCommon.validateRemoveChildObject(this.fXmlNode.fParentNode, this.fXmlNode);

                // --

                resetRelation();

                // --

                fHcn = this.fAncestorHostCondition;
                fParent = this.fParent;
                fNextHep = this.fNextSibling;
                isModelingObject = this.isModelingObject;
                this.replace(this.fTcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));

                // --

                // ***
                // 제거되는 Object의 다음 Object가 최상위일 경우 Logical를 And로 변경한다.
                // ***
                if (fNextHep != null && fNextHep.fPreviousSibling == null)
                {
                    fNextHep.fXmlNode.set_attrVal(FXmlTagHEP.A_Logical, FXmlTagHEP.D_Logical, FEnumConverter.fromLogical(FLogical.And), true);
                }

                // --

                if (isModelingObject)
                {
                    this.fTcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectRemoveCompleted, this.fTcpDriver, fParent, this)
                        );
                    noticeModified(fHcn);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fHcn = null;
                fParent = null;
                fNextHep = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostExpression removeChildHostExpression(
            FHostExpression fChild
            )
        {
            try
            {
                FTcpDriverCommon.validateRemoveChildObject(this.fXmlNode, fChild.fXmlNode);

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

        public void removeChildHostExpression(
            FHostExpression[] fChilds
            )
        {
            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                foreach (FHostExpression fHep in fChilds)
                {
                    FTcpDriverCommon.validateRemoveChildObject(this.fXmlNode, fHep.fXmlNode);
                }

                // --

                foreach (FHostExpression fHep in fChilds)
                {
                    fHep.remove();
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

        public void removeAllChildHostExpression(
            )
        {
            FHostExpressionCollection fHepCollction = null;

            try
            {
                fHepCollction = this.fChildHostExpressionCollection;
                if (fHepCollction.count == 0)
                {
                    return;
                }

                // --

                foreach (FHostExpression fHep in fHepCollction)
                {
                    fHep.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fHepCollction != null)
                {
                    fHepCollction.Dispose();
                    fHepCollction = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void setOperand(
            FHostItem fHostItem
            )
        {
            string oldHitId = string.Empty;
            string newHitId = string.Empty;
            FFormat fFormat;

            try
            {
                // ***
                // Host Item 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fHostItem.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Host Item", "Modeling File"));
                }

                // ***
                // Host Expression 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Host Expression", "Modeling File"));
                }

                // ***
                // Host Item과 Host Expression의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fHostItem))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the Host Item and the Host Expression", "same"));
                }

                // ***
                // Host Condition에 Host Message가 설정되어 있는지 검사
                // ***
                if (!this.fAncestorHostCondition.hasMessage)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "Host Message in the Host Condition"));
                }

                // ***
                // Host Item의 조상 Host Message가 Host Condition에 설정된 Host Message와 동일한지 검사
                // ***
                if (this.fAncestorHostCondition.fMessage != fHostItem.fAncestorHostMessage)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Host Message of the Host Item and the Host Condition", "same"));
                }

                // ***
                // Operand Format이 List, AsciiList, Raw일 경우 Comaprsion Mode가 Length 인지 검사
                // ***
                fFormat = fHostItem.fFormat;
                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Raw || fFormat == FFormat.Unknown)
                {
                    if (this.fComparisonMode != FComparisonMode.Length)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Comparison Mode", "Length"));
                    }
                }

                // --

                oldHitId = this.fXmlNode.get_attrVal(FXmlTagHEP.A_OperandId, FXmlTagHEP.D_OperandId);
                newHitId = fHostItem.uniqueIdToString;
                // --
                if (oldHitId == newHitId)
                {
                    return;
                }

                // --

                // ***
                // 이전에 설정된 Operand가 존재할 경우 Reset 한다.
                // ***
                if (oldHitId != string.Empty)
                {
                    resetOperand(false);
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagHEP.A_OperandFormat, FXmlTagHEP.D_OperandFormat, FEnumConverter.fromFormat(fFormat), false);
                this.fXmlNode.set_attrVal(FXmlTagHEP.A_Value, FXmlTagHEP.D_Value, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagHEP.A_Transformer, FXmlTagHEP.D_Transformer, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagHEP.A_OperandId, FXmlTagHEP.D_OperandId, newHitId, true);
                // --
                fHostItem.lockObject();
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
                // Host Expression 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Host Expression", "Modeling File"));
                }

                // ***
                // Environment와 Host Expression의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fEnvironment))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the Environment and the Host Expression", "same"));
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

                oldEnvId = this.fXmlNode.get_attrVal(FXmlTagHEP.A_OperandId, FXmlTagHEP.D_OperandId);
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

                this.fXmlNode.set_attrVal(FXmlTagHEP.A_OperandFormat, FXmlTagHEP.D_OperandFormat, FEnumConverter.fromFormat(fFormat), false);
                this.fXmlNode.set_attrVal(FXmlTagHEP.A_Value, FXmlTagHEP.D_Value, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagHEP.A_Transformer, FXmlTagHEP.D_Transformer, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagHEP.A_OperandId, FXmlTagHEP.D_OperandId, newEnvId, true);
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
                // Host Expression 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Host Expression", "Modeling File"));
                }

                // ***
                // Environment와 Host Expression의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fEquipmentState))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the Equipment State and the Host Expression", "same"));
                }

                // --

                oldEstId = this.fXmlNode.get_attrVal(FXmlTagHEP.A_OperandId, FXmlTagHEP.D_OperandId);
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

                this.fXmlNode.set_attrVal(FXmlTagHEP.A_OperandFormat, FXmlTagHEP.D_OperandFormat, FEnumConverter.fromFormat(FFormat.Ascii), false);
                this.fXmlNode.set_attrVal(FXmlTagHEP.A_OperandIndex, FXmlTagHEP.D_OperandIndex, FXmlTagHEP.D_OperandIndex, false);
                this.fXmlNode.set_attrVal(FXmlTagHEP.A_Value, FXmlTagHEP.D_Value, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagHEP.A_Transformer, FXmlTagHEP.D_Transformer, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagHEP.A_OperandId, FXmlTagHEP.D_OperandId, newEstId, true);
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
            FIHostOperand fHostOperand
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

                if (this.fOperandType == FHostOperandType.HostItem)
                {
                    if (fHostOperand.fHostOperandType != FHostOperandType.HostItem)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Operand's Type", "Host Item"));
                    }
                    // --
                    setOperand((FHostItem)fHostOperand);
                }
                else if (this.fOperandType == FHostOperandType.Environment)
                {
                    if (fHostOperand.fHostOperandType != FHostOperandType.Environment)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Operand's Type", "Environment"));
                    }
                    // --
                    setOperand((FEnvironment)fHostOperand);
                }
                else if (this.fOperandType == FHostOperandType.EquipmentState)
                {
                    if (fHostOperand.fHostOperandType != FHostOperandType.EquipmentState)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Operand's Type", "EquipmentState"));
                    }
                    // --
                    setOperand((FEquipmentState)fHostOperand);
                }
                // --
                noticeModified(this.fAncestorHostCondition);
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
            FIHostOperand fOpd = null;

            try
            {
                foreach (FHostExpression fHep in this.fChildHostExpressionCollection)
                {
                    fHep.resetOperand(isModifyEvent);
                }

                // --

                fOpd = this.fOperand;
                if (fOpd == null)
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagHEP.A_OperandFormat, FXmlTagHEP.D_OperandFormat, FEnumConverter.fromFormat(FFormat.Ascii), false);
                this.fXmlNode.set_attrVal(FXmlTagHEP.A_OperandIndex, FXmlTagHEP.D_OperandIndex, "0", false);
                this.fXmlNode.set_attrVal(FXmlTagHEP.A_Value, FXmlTagHEP.D_Value, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagHEP.A_Transformer, FXmlTagHEP.D_Transformer, string.Empty, false);
                // --
                resetDataConversionSet(false);
                // --
                this.fXmlNode.set_attrVal(FXmlTagHEP.A_OperandId, FXmlTagHEP.D_OperandId, string.Empty, isModifyEvent);
                // --
                if (isModifyEvent)
                {
                    noticeModified(this.fAncestorHostCondition);
                }

                // --

                if (fOpd.fHostOperandType == FHostOperandType.HostItem)
                {
                    ((FHostItem)fOpd).unlockObject();
                }
                else if (fOpd.fHostOperandType == FHostOperandType.Environment)
                {
                    ((FEnvironment)fOpd).unlockObject();
                }
                else if (fOpd.fHostOperandType == FHostOperandType.EquipmentState)
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
            FHostCondition fHcn
            )
        {
            try
            {
                if (fHcn != null)
                {
                    fHcn.noticeChildModified();
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
                fXmlNode.set_attrVal(FXmlTagHEP.A_OperandId, FXmlTagHEP.D_OperandId, FXmlTagHEP.D_OperandId);
                fXmlNode.set_attrVal(FXmlTagHEP.A_OperandFormat, FXmlTagHEP.D_OperandFormat, FXmlTagHEP.D_OperandFormat);
                fXmlNode.set_attrVal(FXmlTagHEP.A_OperandIndex, FXmlTagHEP.D_OperandIndex, FXmlTagHEP.D_OperandIndex);
                fXmlNode.set_attrVal(FXmlTagHEP.A_Value, FXmlTagHEP.D_Value, FXmlTagHEP.D_Value);
                fXmlNode.set_attrVal(FXmlTagHEP.A_Transformer, FXmlTagHEP.D_Transformer, FXmlTagHEP.D_Transformer);
                fXmlNode.set_attrVal(FXmlTagHEP.A_DataConversionSetExpression, FXmlTagHEP.D_DataConversionSetExpression, string.Empty);
                fXmlNode.set_attrVal(FXmlTagHEP.A_DataConversionSetName, FXmlTagHEP.D_DataConversionSetName, string.Empty);
                fXmlNode.set_attrVal(FXmlTagHEP.A_DataConversionSetID, FXmlTagHEP.D_DataConversionSetID, string.Empty);

                // --

                foreach (FXmlNode fXmlNodeHep in fXmlNode.selectNodes(FXmlTagHEP.E_HostExpression))
                {
                    FHostExpression.resetFlowNode(fXmlNodeHep);
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
                this.copyObject(FCbObjectFormat.HostExpression, fXmlNode);
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
                FTcpDriverCommon.validateCutObject(this.fXmlNode);

                // --

                this.remove();

                // --

                resetFlowNode(this.fXmlNode);
                this.copyObject(FCbObjectFormat.HostExpression, this.fXmlNode);
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

        public FHostExpression pasteSibling(
            )
        {
            FIObject fParent = null;
            FHostExpression fHostExpression = null;

            try
            {
                FTcpDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.HostExpression);

                // --

                fParent = this.fParent;
                fHostExpression = (FHostExpression)this.pasteObject(FCbObjectFormat.HostExpression);
                if (fParent.fObjectType == FObjectType.HostCondition)
                {
                    return ((FHostCondition)fParent).insertAfterChildHostExpression(fHostExpression, this);
                }
                return ((FHostExpression)fParent).insertAfterChildHostExpression(fHostExpression, this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fParent = null;
                fHostExpression = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostExpression pasteChild(
            )
        {
            FHostExpression fHostExpression = null;

            try
            {
                FTcpDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.HostExpression);

                // --

                fHostExpression = (FHostExpression)this.pasteObject(FCbObjectFormat.HostExpression);
                this.appendChildHostExpression(fHostExpression);

                return fHostExpression;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fHostExpression = null;
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
                FTcpDriverCommon.validateMoveUpObject(this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fTcdCore, this.fXmlNode.moveUp());

                // --

                if (this.fXmlNode.fPreviousSibling == null)
                {
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_Logical, FXmlTagHEP.D_Logical, FEnumConverter.fromLogical(FLogical.And));
                }

                // --

                if (isModelingObject)
                {
                    this.fTcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveUpCompleted, this.fTcpDriver, fParent, this)
                        );
                    noticeModified(this.fAncestorHostCondition);
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
                FTcpDriverCommon.validateMoveDownObject(this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fTcdCore, this.fXmlNode.moveDown());

                // --

                if (isModelingObject)
                {
                    this.fTcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveDownCompleted, this.fTcpDriver, fParent, this)
                        );
                    noticeModified(this.fAncestorHostCondition);
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
            FHostExpression fRefObject
            )
        {
            try
            {
                FTcpDriverCommon.validateMoveToObject(this.fXmlNode, fRefObject.fXmlNode);

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

                if (!this.fAncestorHostCondition.Equals(fRefObject.fAncestorHostCondition))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Ancestor Host Condition ", "same"));
                }

                // --

                this.replace(this.fTcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fTcdCore, fRefObject.fXmlNode.fParentNode.insertAfter(this.fXmlNode, fRefObject.fXmlNode));

                // --

                this.fTcdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fTcpDriver, this, fRefObject)
                    );
                noticeModified(this.fAncestorHostCondition);
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
            FHostCondition fRefObject
            )
        {
            try
            {
                FTcpDriverCommon.validateMoveToObject(this.fXmlNode, fRefObject.fXmlNode);

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

                if (!this.fAncestorHostCondition.Equals(fRefObject))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Ancestor Host Condition ", "same"));
                }

                if (fRefObject.fChildHostExpressionCollection.count > 0)
                {
                    if (this.Equals(fRefObject.fChildHostExpressionCollection[fRefObject.fChildHostExpressionCollection.count - 1]))
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0060, "Object", "same localtion"));
                    }
                }

                // --

                this.replace(this.fTcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fTcdCore, fRefObject.fXmlNode.appendChild(this.fXmlNode));

                // --

                this.fTcdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fTcpDriver, this, fRefObject)
                    );
                noticeModified(this.fAncestorHostCondition);
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
                // 이 Host Expression 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Host Expression", "Modeling File"));
                }

                // ***
                // Data Conversion Set와 Host Expression의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fDataConversionSet))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the Data Conversion Set and the Host Expression", "same"));
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

                oldDcsId = this.fXmlNode.get_attrVal(FXmlTagHEP.A_DataConversionSetID, FXmlTagHEP.D_DataConversionSetID);
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

                this.fXmlNode.set_attrVal(FXmlTagHEP.A_DataConversionSetExpression, FXmlTagHEP.D_DataConversionSetExpression, fDataConversionSet.expression, false);
                this.fXmlNode.set_attrVal(FXmlTagHEP.A_DataConversionSetName, FXmlTagHEP.D_DataConversionSetName, fDataConversionSet.name, false);
                this.fXmlNode.set_attrVal(FXmlTagHEP.A_DataConversionSetID, FXmlTagHEP.D_DataConversionSetID, newDcsId, true);
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
                foreach (FHostExpression fHep in this.fChildHostExpressionCollection)
                {
                    fHep.resetDataConversionSet(isModifyEvent);
                }

                // --

                fDcs = this.fDataConversionSet;
                if (fDcs == null)
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagHEP.A_DataConversionSetExpression, FXmlTagHEP.D_DataConversionSetExpression, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagHEP.A_DataConversionSetName, FXmlTagHEP.D_DataConversionSetName, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagHEP.A_DataConversionSetID, FXmlTagHEP.D_DataConversionSetID, string.Empty, isModifyEvent);

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
