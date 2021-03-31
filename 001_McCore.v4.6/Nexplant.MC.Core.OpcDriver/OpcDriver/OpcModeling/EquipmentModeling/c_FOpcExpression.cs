/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FOpcExpression.cs
--  Creator         : spike.lee
--  Create Date     : 2013.08.12
--  Description     : FAMate Core FaOpcDriver OPC Expression Class 
--  History         : Created by spike.lee at 2013.08.12
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    public class FOpcExpression : FBaseObject<FOpcExpression>, FIObject
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FOpcExpression(
            FOpcDriver fOpcDriver
            )
            : base(fOpcDriver.fOcdCore, FOpcDriverCommon.createXmlNodeOEP(fOpcDriver.fOcdCore.fXmlDoc))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FOpcExpression(
            FOcdCore fOcdCore,
            FXmlNode fXmlNode
            )
            : base(fOcdCore, fXmlNode)
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FOpcExpression(
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
                    return FObjectType.OpcExpression;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.OpcExpression;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOEP.A_UniqueId, FXmlTagOEP.D_UniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOEP.A_Name, FXmlTagOEP.D_Name);
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

                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_Name, FXmlTagOEP.D_Name, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOEP.A_Description, FXmlTagOEP.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_Description, FXmlTagOEP.D_Description, value, true);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagOEP.A_FontColor, FXmlTagOEP.D_FontColor));
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
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_FontColor, FXmlTagOEP.D_FontColor, value.Name, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagOEP.A_FontBold, FXmlTagOEP.D_FontBold));
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
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_FontBold, FXmlTagOEP.D_FontBold, FBoolean.fromBool(value), true);
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
                    return FEnumConverter.toLogical(this.fXmlNode.get_attrVal(FXmlTagOEP.A_Logical, FXmlTagOEP.D_Logical));
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
                    // 첫번째 OPC Expression인 경우 Logical를 변경할 수 없다.
                    // ***
                    if (this.fPreviousSibling == null)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0008, "First Expression", "Logical"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_Logical, FXmlTagOEP.D_Logical, FEnumConverter.fromLogical(value), true);
                    noticeModified(this.fAncestorOpcCondition);
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
                    return FEnumConverter.toExpressionType(this.fXmlNode.get_attrVal(FXmlTagOEP.A_ExpressionType, FXmlTagOEP.D_ExpressionType));
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
                    // 자식 OPC Expression이 존재할 경우 Expression Type를 변경할 수 없다.
                    // ***
                    if (this.hasChild)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0013, "Object's Child"));
                    }                    

                    // --                    

                    resetOperand(false);

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_ComparisonMode, FXmlTagOEP.D_ComparisonMode, FEnumConverter.fromComparisonMode(FComparisonMode.Value), false);
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_OperandType, FXmlTagOEP.D_OperandType, FEnumConverter.fromOpcOperandType(FOpcOperandType.OpcItem), false);
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_OperandIndex, FXmlTagOEP.D_OperandIndex, "0", false);
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_Operation, FXmlTagOEP.D_Operation, FEnumConverter.fromOperation(FOperation.Equal), false);
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_ExpressionValueType, FXmlTagOEP.D_ExpressionValueType, FEnumConverter.fromExpressionValueType(FExpressionValueType.Value), false);
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_Resource, FXmlTagOEP.D_Resource, FEnumConverter.fromOpcResourceSourceType(FOpcResourceSourceType.None), false);
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_Value, FXmlTagOEP.D_Value, string.Empty, false);
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_Transformer, FXmlTagOEP.D_Transformer, string.Empty, false);
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_ExpressionType, FXmlTagOEP.D_ExpressionType, FEnumConverter.fromExpressionType(value), true);
                    // --
                    noticeModified(this.fAncestorOpcCondition);
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
                    return FEnumConverter.toComparisonMode(this.fXmlNode.get_attrVal(FXmlTagOEP.A_ComparisonMode, FXmlTagOEP.D_ComparisonMode));
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

                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_OperandType, FXmlTagOEP.D_OperandType, FEnumConverter.fromOpcOperandType(FOpcOperandType.OpcItem), false);
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_OperandIndex, FXmlTagOEP.D_OperandIndex, "0", false);
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_Operation, FXmlTagOEP.D_Operation, FEnumConverter.fromOperation(FOperation.Equal), false);
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_ExpressionValueType, FXmlTagOEP.D_ExpressionValueType, FEnumConverter.fromExpressionValueType(FExpressionValueType.Value), false);
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_Value, FXmlTagOEP.D_Value, string.Empty, false);
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_Resource, FXmlTagOEP.D_Resource, FEnumConverter.fromOpcResourceSourceType(FOpcResourceSourceType.None), false);
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_Transformer, FXmlTagOEP.D_Transformer, string.Empty, false);
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_ComparisonMode, FXmlTagOEP.D_ComparisonMode, FEnumConverter.fromComparisonMode(value), true);

                    // --

                    noticeModified(this.fAncestorOpcCondition);
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

        public FOpcOperandType fOperandType
        {
            get
            {
                try
                {
                    return FEnumConverter.toOpcOperandType(this.fXmlNode.get_attrVal(FXmlTagOEP.A_OperandType, FXmlTagOEP.D_OperandType));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FOpcOperandType.OpcItem;
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

                    if (this.fComparisonMode == FComparisonMode.Length && value == FOpcOperandType.EquipmentState)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Comparison Mode", "Value"));
                    }

                    // --

                    resetOperand(false);

                    // --
                    
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_ExpressionValueType, FXmlTagOEP.D_ExpressionValueType, FEnumConverter.fromExpressionValueType(FExpressionValueType.Value), false);
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_Resource, FXmlTagOEP.D_Resource, FEnumConverter.fromOpcResourceSourceType(FOpcResourceSourceType.None), false);
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_Value, FXmlTagOEP.D_Value, string.Empty, false);
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_Transformer, FXmlTagOEP.D_Transformer, string.Empty, false);
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_OperandType, FXmlTagOEP.D_OperandType, FEnumConverter.fromOpcOperandType(value), true);

                    // --

                    noticeModified(this.fAncestorOpcCondition);
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

        public FIOpcOperand fOperand
        {
            get
            {
                // --
                string id = string.Empty;
                string xpath = string.Empty;                

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagOEP.A_OperandId, FXmlTagOEP.D_OperandId);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    if (this.fOperandType == FOpcOperandType.OpcItem)
                    {
                        xpath =
                            FXmlTagOLM.E_OpcLibraryModeling +
                            "/" + FXmlTagOLG.E_OpcLibraryGroup +
                            "/" + FXmlTagOLB.E_OpcLibrary +
                            "/" + FXmlTagOML.E_OpcMessageList +
                            "/" + FXmlTagOMS.E_OpcMessages +
                            "/" + FXmlTagOMG.E_OpcMessage +
                            "/" + FXmlTagOIL.E_OpcItemList +
                            "/" + FXmlTagOIT.E_OpcItem + "[@" + FXmlTagOIT.A_UniqueId + "='" + id + "']";
                        // --
                        return new FOpcItem(this.fOcdCore, this.fOpcDriver.fXmlNode.selectSingleNode(xpath));
                    }
                    else if (this.fOperandType == FOpcOperandType.OpcEventItem)
                    {
                        xpath =
                            FXmlTagOLM.E_OpcLibraryModeling +
                            "/" + FXmlTagOLG.E_OpcLibraryGroup +
                            "/" + FXmlTagOLB.E_OpcLibrary +
                            "/" + FXmlTagOML.E_OpcMessageList +
                            "/" + FXmlTagOMS.E_OpcMessages +
                            "/" + FXmlTagOMG.E_OpcMessage +
                            "/" + FXmlTagOEL.E_OpcEventItemList +
                            "/" + FXmlTagOEI.E_OpcEventItem + "[@" + FXmlTagOEI.A_UniqueId + "='" + id + "']";
                        // --
                        return new FOpcEventItem(this.fOcdCore, this.fOpcDriver.fXmlNode.selectSingleNode(xpath));
                    }
                    else if (this.fOperandType == FOpcOperandType.Environment)
                    {
                        xpath =
                            FXmlTagSET.E_Setup +
                            "/" + FXmlTagEND.E_EnvironmentDefinition +
                            "/" + FXmlTagENL.E_EnvironmentList +
                            "//" + FXmlTagENV.E_Environment + "[@" + FXmlTagENV.A_UniqueId + "='" + id + "']";
                        // --
                        return new FEnvironment(this.fOcdCore, this.fOpcDriver.fXmlNode.selectSingleNode(xpath));
                    }
                    else if (this.fOperandType == FOpcOperandType.EquipmentState)
                    {
                        xpath =
                            FXmlTagSET.E_Setup +
                            "/" + FXmlTagESD.E_EquipmentStateSetDefinition +
                            "/" + FXmlTagESL.E_EquipmentStateSetList +
                            "/" + FXmlTagESS.E_EquipmentStateSet +
                            "/" + FXmlTagEST.E_EquipmentState + "[@" + FXmlTagEST.A_UniqueId + "='" + id + "']";
                        // --
                        return new FEquipmentState(this.fOcdCore, this.fOpcDriver.fXmlNode.selectSingleNode(xpath));
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
                FIOpcOperand fOpd = null;

                try
                {
                    fOpd = this.fOperand;
                    if (fOpd == null)
                    {
                        return string.Empty;
                    }

                    // --

                    if (fOpd.fOpcOperandType == FOpcOperandType.OpcItem)
                    {
                        return ((FOpcItem)fOpd).name;
                    }
                    else if (fOpd.fOpcOperandType == FOpcOperandType.OpcEventItem)
                    {
                        return ((FOpcEventItem)fOpd).name;
                    }
                    else if (fOpd.fOpcOperandType == FOpcOperandType.Environment)
                    {
                        return ((FEnvironment)fOpd).name;
                    }
                    else if (fOpd.fOpcOperandType == FOpcOperandType.EquipmentState)
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
        // Add by Jeff.Kim 2015.12.01
        // Osm 파일 일괄 적용을 위해 추가
        public string operandName2
        {
            get
            {
                try
                {
                    // Modify by Jeff.Kim 2015.12.01
                    // fOperand 값이 없을 경우 Xml 있는 값을 리턴해준다.
                    return this.fXmlNode.get_attrVal(FXmlTagOEP.A_OperandName, FXmlTagOEP.D_OperandName);
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
                    // Modify by Jeff.Kim 2015.12.01
                    // fOperand 값이 없을 경우 Xml 있는 값을 리턴해준다.
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_OperandName, FXmlTagOEP.D_OperandName, value);
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

        public FFormat fOperandFormat
        {
            get
            {
                try
                {
                    return FEnumConverter.toFormat(this.fXmlNode.get_attrVal(FXmlTagOEP.A_OperandFormat, FXmlTagOEP.D_OperandFormat));
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
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagOEP.A_OperandIndex, FXmlTagOEP.D_OperandIndex));
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

                    if (this.fOperandType == FOpcOperandType.EquipmentState)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0010, "Operand Type", "Equipment State"));
                    }

                    if (value < 0)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0014, "Operand Index"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_OperandIndex, FXmlTagOEP.D_OperandIndex, value.ToString(), true);
                    noticeModified(this.fAncestorOpcCondition);
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
                    return FEnumConverter.toOperation(this.fXmlNode.get_attrVal(FXmlTagOEP.A_Operation, FXmlTagOEP.D_Operation));
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

                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_Operation, FXmlTagOEP.D_Operation, FEnumConverter.fromOperation(value), true);
                    noticeModified(this.fAncestorOpcCondition);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOEP.A_Value, FXmlTagOEP.D_Value);
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
                    
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_Value, FXmlTagOEP.D_Value, val, true);
                    noticeModified(this.fAncestorOpcCondition);
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

                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_Value, FXmlTagOEP.D_Value, val, true);
                    noticeModified(this.fAncestorOpcCondition);
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

                    if (this.fOperandType == FOpcOperandType.EquipmentState)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0010, "Operand Type", "Equipment State"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_Resource, FXmlTagHEP.D_Resource, FEnumConverter.fromOpcResourceSourceType(FOpcResourceSourceType.None), false);
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_Value, FXmlTagHEP.D_Value, string.Empty, false);                    
                    this.fXmlNode.set_attrVal(FXmlTagHEP.A_ExpressionValueType, FXmlTagHEP.D_ExpressionValueType, FEnumConverter.fromExpressionValueType(value), true);
                    noticeModified(this.fAncestorOpcCondition);
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

        public FOpcResourceSourceType fResource
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = this.fXmlNode.get_attrVal(FXmlTagOEP.A_Resource, FXmlTagOEP.D_Resource);
                    if (val == string.Empty)
                    {
                        return FOpcResourceSourceType.None;
                    }
                    // --
                    return FEnumConverter.toOpcResourceSourceType(val);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FOpcResourceSourceType.None;
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
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_Resource, FXmlTagOEP.D_Resource, FEnumConverter.fromOpcResourceSourceType(value), true);
                    noticeModified(this.fAncestorOpcCondition);
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

                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_Value, FXmlTagOEP.D_Value, val, true);
                    noticeModified(this.fAncestorOpcCondition);
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

        public FOpcExpressionValueTransformer fValueTransformer
        {
            get
            {
                try
                {
                    return new FOpcExpressionValueTransformer(this);
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
                    id = this.fXmlNode.get_attrVal(FXmlTagOEP.A_DataConversionSetID, FXmlTagOEP.D_DataConversionSetID);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOEP.A_DataConversionSetName, FXmlTagOEP.D_DataConversionSetName);
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
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_DataConversionSetName, FXmlTagOEP.D_DataConversionSetName, value, false);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOEP.A_DataConversionSetExpression, FXmlTagOEP.D_DataConversionSetExpression);
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
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_DataConversionSetExpression, FXmlTagOEP.D_DataConversionSetExpression, value, false);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOEP.A_UserTag1, FXmlTagOEP.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_UserTag1, FXmlTagOEP.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOEP.A_UserTag2, FXmlTagOEP.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_UserTag2, FXmlTagOEP.D_UserTag2, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOEP.A_UserTag3, FXmlTagOEP.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_UserTag3, FXmlTagOEP.D_UserTag3, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOEP.A_UserTag4, FXmlTagOEP.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_UserTag4, FXmlTagOEP.D_UserTag4, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOEP.A_UserTag5, FXmlTagOEP.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_UserTag5, FXmlTagOEP.D_UserTag5, value, true);
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

                    if (this.fXmlNode.fParentNode.name == FXmlTagOCN.E_OpcCondition)
                    {
                        return new FOpcCondition(this.fOcdCore, this.fXmlNode.fParentNode);
                    }
                    return new FOpcExpression(this.fOcdCore, this.fXmlNode.fParentNode);
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

        public FOpcExpression fPreviousSibling
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

                    return new FOpcExpression(this.fOcdCore, this.fXmlNode.fPreviousSibling);
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

        public FOpcExpression fNextSibling
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

                    return new FOpcExpression(this.fOcdCore, this.fXmlNode.fNextSibling);
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

        public FOpcExpressionCollection fChildOpcExpressionCollection
        {
            get
            {
                try
                {
                    return new FOpcExpressionCollection(this.fOcdCore, this.fXmlNode.selectNodes(FXmlTagOEP.E_OpcExpression));
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
                            "../../" + FXmlTagOCN.E_OpcCondition + "[@" + FXmlTagOCN.A_UniqueId + "='" + fParent.uniqueIdToString + "']";
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
                        if (this.fOperandType == FOpcOperandType.OpcItem)
                        {
                            xpath =
                                "../../../../../../../" + FXmlTagOLM.E_OpcLibraryModeling +
                                "/" + FXmlTagOLG.E_OpcLibraryGroup +
                                "/" + FXmlTagOLB.E_OpcLibrary +
                                "/" + FXmlTagOML.E_OpcMessageList +
                                "/" + FXmlTagOMS.E_OpcMessages +
                                "/" + FXmlTagOMG.E_OpcMessage +
                                "/" + FXmlTagOIL.E_OpcItemList +
                                "/" + FXmlTagOIT.E_OpcItem + "[@" + FXmlTagOIT.A_UniqueId + "='" + ((FOpcItem)this.fOperand).uniqueIdToString + "']";
                        }
                        else if (this.fOperandType == FOpcOperandType.OpcEventItem)
                        {
                            xpath =
                                "../../../../../../../" + FXmlTagOLM.E_OpcLibraryModeling +
                                "/" + FXmlTagOLG.E_OpcLibraryGroup +
                                "/" + FXmlTagOLB.E_OpcLibrary +
                                "/" + FXmlTagOML.E_OpcMessageList +
                                "/" + FXmlTagOMS.E_OpcMessages +
                                "/" + FXmlTagOMG.E_OpcMessage +
                                "/" + FXmlTagOEL.E_OpcEventItemList +
                                "/" + FXmlTagOEI.E_OpcEventItem + "[@" + FXmlTagOEI.A_UniqueId + "='" + ((FOpcEventItem)this.fOperand).uniqueIdToString + "']";
                        }
                        else if (this.fOperand.fOpcOperandType == FOpcOperandType.Environment)
                        {
                            xpath =
                            "../../../../../../../" + FXmlTagSET.E_Setup + "/" + FXmlTagEND.E_EnvironmentDefinition +
                            "/" + FXmlTagENL.E_EnvironmentList +
                            "//" + FXmlTagENV.E_Environment + "[@" + FXmlTagENV.A_UniqueId + "='" + ((FEnvironment)this.fOperand).uniqueIdToString + "']";
                        }
                        else if (this.fOperand.fOpcOperandType == FOpcOperandType.EquipmentState)
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
                    return this.fXmlNode.containsNode(FXmlTagOEP.E_OpcExpression);
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
                    if (this.fXmlNode.get_attrVal(FXmlTagOEP.A_OperandId, FXmlTagOEP.D_OperandId) == string.Empty)
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
                    if (this.fXmlNode.get_attrVal(FXmlTagOEP.A_Transformer, FXmlTagOEP.D_Transformer) == string.Empty)
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
                    if (this.fXmlNode.get_attrVal(FXmlTagOEP.A_DataConversionSetID, FXmlTagOEP.D_DataConversionSetID) == string.Empty)
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

        public FOpcCondition fAncestorOpcCondition
        {
            get
            {
                try
                {
                    return this.getAncestorOpcCondition();
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
                        !FClipboard.containsData(FCbObjectFormat.OpcExpression)
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
                    if (!FClipboard.containsData(FCbObjectFormat.OpcExpression))
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
            FIOpcOperand fOpd = null;
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
                        else if (fOpd.fOpcOperandType == FOpcOperandType.OpcItem)
                        {
                            info += ((FOpcItem)fOpd).name;
                        }
                        else if (fOpd.fOpcOperandType == FOpcOperandType.OpcEventItem)
                        {
                            info += ((FOpcEventItem)fOpd).name;
                        }
                        else if (fOpd.fOpcOperandType == FOpcOperandType.Environment)
                        {
                            info += ((FEnvironment)fOpd).name;
                        }
                        else if (fOpd.fOpcOperandType == FOpcOperandType.EquipmentState)
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

        public FOpcExpression appendChildOpcExpression(
           FOpcExpression fNewChild
           )
        {
            try
            {
                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // ***
                // OPC Expression의 Type이 Comparison일 경우 OPC Expression를 추가할 수 없다.
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
                    noticeModified(this.fAncestorOpcCondition);
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

        public FOpcExpression insertBeforeChildOpcExpression(
            FOpcExpression fNewChild,
            FOpcExpression fRefChild
            )
        {
            try
            {
                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // ***
                // OPC Expression의 Type이 Comparison일 경우 OPC Expression를 추가할 수 없다.
                // ***
                if (this.fExpressionType == FExpressionType.Comparison)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Expression's Type", "Bracket"));
                }

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
                    noticeModified(this.fAncestorOpcCondition);
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

        public FOpcExpression insertAfterChildOpcExpression(
            FOpcExpression fNewChild,
            FOpcExpression fRefChild
            )
        {
            try
            {
                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // ***
                // OPC Expression의 Type이 Comparison일 경우 OPC Expression를 추가할 수 없다.
                // ***
                if (this.fExpressionType == FExpressionType.Comparison)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Expression's Type", "Bracket"));
                }

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
                    noticeModified(this.fAncestorOpcCondition);
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
            FOpcCondition fOcn = null;
            FIObject fParent = null;
            FOpcExpression fNextOep = null;
            bool isModelingObject = false;

            try
            {
                FOpcDriverCommon.validateRemoveChildObject(this.fXmlNode.fParentNode, this.fXmlNode);                

                // --

                resetRelation();

                // --

                fOcn = this.fAncestorOpcCondition;
                fParent = this.fParent;
                fNextOep = this.fNextSibling;
                isModelingObject = this.isModelingObject;                
                this.replace(this.fOcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                
                // --

                // ***
                // 제거되는 Object의 다음 Object가 최상위일 경우 Logical를 And로 변경한다.
                // ***
                if (fNextOep != null && fNextOep.fPreviousSibling == null)
                {
                    fNextOep.fXmlNode.set_attrVal(FXmlTagOEP.A_Logical, FXmlTagOEP.D_Logical, FEnumConverter.fromLogical(FLogical.And), true);
                }

                // --

                if (isModelingObject)
                {
                    this.fOcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectRemoveCompleted, this.fOpcDriver, fParent, this)
                        );
                    noticeModified(fOcn);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fOcn = null;
                fParent = null;
                fNextOep = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOpcExpression removeChildOpcExpression(
            FOpcExpression fChild
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

        public void removeChildOpcExpression(
            FOpcExpression[] fChilds
            )
        {
            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                foreach (FOpcExpression fPep in fChilds)
                {
                    FOpcDriverCommon.validateRemoveChildObject(this.fXmlNode, fPep.fXmlNode);
                }

                // --

                foreach (FOpcExpression fPep in fChilds)
                {
                    fPep.remove();
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

        public void removeAllChildOpcExpression(
            )
        {
            FOpcExpressionCollection fPepCollction = null;

            try
            {
                fPepCollction = this.fChildOpcExpressionCollection;
                if (fPepCollction.count == 0)
                {
                    return;
                }

                // --

                foreach (FOpcExpression fPep in fPepCollction)
                {
                    fPep.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fPepCollction != null)
                {
                    fPepCollction.Dispose();
                    fPepCollction = null;
                }
            }
        }        

        //------------------------------------------------------------------------------------------------------------------------

        private void setOperand(
            FOpcItem fOpcItem
            )
        {
            string oldOitId = string.Empty;
            string newOitId = string.Empty;

            try
            {
                // ***
                // OPC Item 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fOpcItem.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "OPC Item", "Modeling File"));
                }

                // ***
                // OPC Expression 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "OPC Expression", "Modeling File"));
                }

                // ***
                // OPC Item과 OPC Expression의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fOpcItem))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the OPC Item and the OPC Expression", "same"));
                }

                // ***
                // OPC Condition에 OPC Message가 설정되어 있는지 검사
                // ***
                if (!this.fAncestorOpcCondition.hasMessage)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "OPC Message in the OPC Condition"));
                }

                // ***
                // OPC Item 조상 OPC Message가 OPC Condition에 설정된 OPC Message와 동일한지 검사
                // ***
                if (this.fAncestorOpcCondition.fMessage != fOpcItem.fAncestorOpcMessage)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "OPC Message of the OPC Item and the OPC Condition", "same"));
                }

                // --

                oldOitId = this.fXmlNode.get_attrVal(FXmlTagOEP.A_OperandId, FXmlTagOEP.D_OperandId);
                newOitId = fOpcItem.uniqueIdToString;
                // --
                if (oldOitId == newOitId)
                {
                    return;
                }

                // --

                // ***
                // 이전에 설정된 Operand가 존재할 경우 Reset 한다.
                // ***
                if (oldOitId != string.Empty)
                {
                    resetOperand(false);
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagOEP.A_OperandFormat, FXmlTagOEP.D_OperandFormat, FEnumConverter.fromOpcFormat(fOpcItem.fFormat), false);
                this.fXmlNode.set_attrVal(FXmlTagOEP.A_Value, FXmlTagOEP.D_Value, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagOEP.A_Transformer, FXmlTagOEP.D_Transformer, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagOEP.A_OperandId, FXmlTagOEP.D_OperandId, newOitId, true);
                // --
                fOpcItem.lockObject();
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
            FOpcEventItem fOpcEventItem
            )
        {
            string oldOeiId = string.Empty;
            string newOeiId = string.Empty;

            try
            {
                // ***
                // OPC Event Item 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fOpcEventItem.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "OPC Event Item", "Modeling File"));
                }

                // ***
                // OPC Expression 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "OPC Expression", "Modeling File"));
                }

                // ***
                // OPC Event Item과 OPC Expression의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fOpcEventItem))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the OPC Event Item and the OPC Expression", "same"));
                }

                // ***
                // OPC Condition에 OPC Message가 설정되어 있는지 검사
                // ***
                if (!this.fAncestorOpcCondition.hasMessage)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "OPC Message in the OPC Condition"));
                }

                // ***
                // OPC Event Item 조상 OPC Message가 OPC Condition에 설정된 OPC Message와 동일한지 검사
                // ***
                if (this.fAncestorOpcCondition.fMessage != fOpcEventItem.fAncestorOpcMessage)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "OPC Message of the OPC Event Item and the OPC Condition", "same"));
                }

                // --

                oldOeiId = this.fXmlNode.get_attrVal(FXmlTagOEP.A_OperandId, FXmlTagOEP.D_OperandId);
                newOeiId = fOpcEventItem.uniqueIdToString;
                // --
                if (oldOeiId == newOeiId)
                {
                    return;
                }

                // --

                // ***
                // 이전에 설정된 Operand가 존재할 경우 Reset 한다.
                // ***
                if (oldOeiId != string.Empty)
                {
                    resetOperand(false);
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagOEP.A_OperandFormat, FXmlTagOEP.D_OperandFormat, FEnumConverter.fromOpcFormat(fOpcEventItem.fFormat), false);
                this.fXmlNode.set_attrVal(FXmlTagOEP.A_Value, FXmlTagOEP.D_Value, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagOEP.A_Transformer, FXmlTagOEP.D_Transformer, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagOEP.A_OperandId, FXmlTagOEP.D_OperandId, newOeiId, true);
                // --
                fOpcEventItem.lockObject();
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
                // OPC Expression 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "OPC Expression", "Modeling File"));
                }

                // ***
                // Environment와 OPC Expression의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fEnvironment))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the Environment and the OPC Expression", "same"));
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

                oldEnvId = this.fXmlNode.get_attrVal(FXmlTagOEP.A_OperandId, FXmlTagOEP.D_OperandId);
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

                this.fXmlNode.set_attrVal(FXmlTagOEP.A_OperandFormat, FXmlTagOEP.D_OperandFormat, FEnumConverter.fromFormat(fFormat), false);
                this.fXmlNode.set_attrVal(FXmlTagOEP.A_Value, FXmlTagOEP.D_Value, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagOEP.A_Transformer, FXmlTagOEP.D_Transformer, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagOEP.A_OperandId, FXmlTagOEP.D_OperandId, newEnvId, true);
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
                // OPC Expression 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "OPC Expression", "Modeling File"));
                }

                // ***
                // Equipment State와 OPC Expression의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fEquipmentState))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the Equipment State and the SECS Expression", "same"));
                }

                // --

                oldEstId = this.fXmlNode.get_attrVal(FXmlTagOEP.A_OperandId, FXmlTagOEP.D_OperandId);
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

                this.fXmlNode.set_attrVal(FXmlTagOEP.A_OperandFormat, FXmlTagOEP.D_OperandFormat, FEnumConverter.fromFormat(FFormat.Ascii), false);
                this.fXmlNode.set_attrVal(FXmlTagOEP.A_OperandIndex, FXmlTagOEP.D_OperandIndex, FXmlTagOEP.D_OperandIndex, false);
                this.fXmlNode.set_attrVal(FXmlTagOEP.A_Value, FXmlTagOEP.D_Value, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagOEP.A_Transformer, FXmlTagOEP.D_Transformer, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagOEP.A_OperandId, FXmlTagOEP.D_OperandId, newEstId, true);
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
            FIOpcOperand fOpcOperand
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

                if (this.fOperandType == FOpcOperandType.OpcItem)
                {
                    if (fOpcOperand.fOpcOperandType != FOpcOperandType.OpcItem)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Operand's Type", "OPC Item"));
                    }
                    // --
                    setOperand((FOpcItem)fOpcOperand);
                }
                else if (this.fOperandType == FOpcOperandType.OpcEventItem)
                {
                    if (fOpcOperand.fOpcOperandType != FOpcOperandType.OpcEventItem)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Operand's Type", "OPC Event Item"));
                    }
                    // --
                    setOperand((FOpcEventItem)fOpcOperand);
                }
                else if (this.fOperandType == FOpcOperandType.Environment)
                {
                    if (fOpcOperand.fOpcOperandType != FOpcOperandType.Environment)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Operand's Type", "Environment"));
                    }
                    // --
                    setOperand((FEnvironment)fOpcOperand);
                }
                else if (this.fOperandType == FOpcOperandType.EquipmentState)
                {
                    if (fOpcOperand.fOpcOperandType != FOpcOperandType.EquipmentState)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Operand's Type", "Equipment State"));
                    }
                    // --
                    setOperand((FEquipmentState)fOpcOperand);
                }
                // --
                noticeModified(this.fAncestorOpcCondition);
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
            FIOpcOperand fOpd = null;

            try
            {
                foreach (FOpcExpression fSep in this.fChildOpcExpressionCollection)
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

                this.fXmlNode.set_attrVal(FXmlTagOEP.A_OperandFormat, FXmlTagOEP.D_OperandFormat, FEnumConverter.fromFormat(FFormat.Ascii), false);
                this.fXmlNode.set_attrVal(FXmlTagOEP.A_OperandIndex, FXmlTagOEP.D_OperandIndex, "0", false);
                this.fXmlNode.set_attrVal(FXmlTagOEP.A_Value, FXmlTagOEP.D_Value, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagOEP.A_Transformer, FXmlTagOEP.D_Transformer, string.Empty, false);
                // --
                resetDataConversionSet(false);
                // --
                this.fXmlNode.set_attrVal(FXmlTagOEP.A_OperandId, FXmlTagOEP.D_OperandId, string.Empty, isModifyEvent);
                // --
                if (isModifyEvent)
                {
                    noticeModified(this.fAncestorOpcCondition);
                }

                // --

                if (fOpd.fOpcOperandType == FOpcOperandType.OpcItem)
                {
                    ((FOpcItem)fOpd).unlockObject();
                }
                else if (fOpd.fOpcOperandType == FOpcOperandType.OpcEventItem)
                {
                    ((FOpcEventItem)fOpd).unlockObject();
                }
                else if (fOpd.fOpcOperandType == FOpcOperandType.Environment)
                {
                    ((FEnvironment)fOpd).unlockObject();
                }
                else if (fOpd.fOpcOperandType == FOpcOperandType.EquipmentState)
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
            FOpcCondition fOcn
            )
        {
            try
            {
                if (fOcn != null)
                {
                    fOcn.noticeChildModified();
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
                fXmlNode.set_attrVal(FXmlTagOEP.A_OperandId, FXmlTagOEP.D_OperandId, FXmlTagOEP.D_OperandId);
                fXmlNode.set_attrVal(FXmlTagOEP.A_OperandFormat, FXmlTagOEP.D_OperandFormat, FXmlTagOEP.D_OperandFormat);
                fXmlNode.set_attrVal(FXmlTagOEP.A_OperandIndex, FXmlTagOEP.D_OperandIndex, FXmlTagOEP.D_OperandIndex);
                fXmlNode.set_attrVal(FXmlTagOEP.A_Value, FXmlTagOEP.D_Value, FXmlTagOEP.D_Value);
                fXmlNode.set_attrVal(FXmlTagOEP.A_Transformer, FXmlTagOEP.D_Transformer, FXmlTagOEP.D_Transformer);
                fXmlNode.set_attrVal(FXmlTagOEP.A_DataConversionSetExpression, FXmlTagOEP.D_DataConversionSetExpression, string.Empty);
                fXmlNode.set_attrVal(FXmlTagOEP.A_DataConversionSetName, FXmlTagOEP.D_DataConversionSetName, string.Empty);
                fXmlNode.set_attrVal(FXmlTagOEP.A_DataConversionSetID, FXmlTagOEP.D_DataConversionSetID, string.Empty);
                
                // --

                foreach (FXmlNode fXmlNodeSep in fXmlNode.selectNodes(FXmlTagOEP.E_OpcExpression))
                {
                    FOpcExpression.resetFlowNode(fXmlNodeSep);                    
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
                this.copyObject(FCbObjectFormat.OpcExpression, fXmlNode);
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

                resetFlowNode(this.fXmlNode);
                this.copyObject(FCbObjectFormat.OpcExpression, this.fXmlNode);
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

        public FOpcExpression pasteSibling(
            )
        {
            FIObject fParent = null;
            FOpcExpression fOpcExpression = null;
            
            try
            {
                FOpcDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.OpcExpression);

                // --
                
                fParent = this.fParent;

                fOpcExpression = (FOpcExpression)this.pasteObject(FCbObjectFormat.OpcExpression);
                if (fParent.fObjectType == FObjectType.OpcCondition)
                {
                    return ((FOpcCondition)fParent).insertAfterChildOpcExpression(fOpcExpression, this);
                }
                return ((FOpcExpression)fParent).insertAfterChildOpcExpression(fOpcExpression, this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fOpcExpression = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOpcExpression pasteChild(
           )
        {
            FOpcExpression fOpcExpression = null;

            try
            {
                FOpcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.OpcExpression);

                // --

                fOpcExpression = (FOpcExpression)this.pasteObject(FCbObjectFormat.OpcExpression);
                this.appendChildOpcExpression(fOpcExpression);

                return fOpcExpression;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fOpcExpression = null;
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
                    this.fXmlNode.set_attrVal(FXmlTagOEP.A_Logical, FXmlTagOEP.D_Logical, FEnumConverter.fromLogical(FLogical.And));
                }

                // --

                if (isModelingObject)
                {
                    this.fOcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveUpCompleted, this.fOpcDriver, fParent, this)
                        );
                    noticeModified(this.fAncestorOpcCondition);
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
                    noticeModified(this.fAncestorOpcCondition);
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
            FOpcExpression fRefObject
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

                if (!this.fAncestorOpcCondition.Equals(fRefObject.fAncestorOpcCondition))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Ancestor OPC Condition ", "same"));
                }

                // --

                this.replace(this.fOcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fOcdCore, fRefObject.fXmlNode.fParentNode.insertAfter(this.fXmlNode, fRefObject.fXmlNode));

                // --

                this.fOcdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fOpcDriver, this, fRefObject)
                    );
                noticeModified(this.fAncestorOpcCondition);
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
            FOpcCondition fRefObject
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

                if (!this.fAncestorOpcCondition.Equals(fRefObject))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Ancestor OPC Condition ", "same"));
                }

                if (fRefObject.fChildOpcExpressionCollection.count > 0)
                {
                    if (this.Equals(fRefObject.fChildOpcExpressionCollection[fRefObject.fChildOpcExpressionCollection.count - 1]))
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
                noticeModified(this.fAncestorOpcCondition);
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
                // 이 OPC Expression 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "OPC Expression", "Modeling File"));
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

                oldDcsId = this.fXmlNode.get_attrVal(FXmlTagOEP.A_DataConversionSetID, FXmlTagOEP.D_DataConversionSetID);
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
                
                this.fXmlNode.set_attrVal(FXmlTagOEP.A_DataConversionSetExpression, FXmlTagOEP.D_DataConversionSetExpression, fDataConversionSet.expression, false);
                this.fXmlNode.set_attrVal(FXmlTagOEP.A_DataConversionSetName, FXmlTagOEP.D_DataConversionSetName, fDataConversionSet.name, false);
                this.fXmlNode.set_attrVal(FXmlTagOEP.A_DataConversionSetID, FXmlTagOEP.D_DataConversionSetID, newDcsId, true);
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
                foreach (FOpcExpression fPlp in this.fChildOpcExpressionCollection)
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

                this.fXmlNode.set_attrVal(FXmlTagOEP.A_DataConversionSetExpression, FXmlTagOEP.D_DataConversionSetExpression, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagOEP.A_DataConversionSetName, FXmlTagOEP.D_DataConversionSetName, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagOEP.A_DataConversionSetID, FXmlTagOEP.D_DataConversionSetID, string.Empty, isModifyEvent);
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
