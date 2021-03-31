/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FData.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2013.08.26
--  Description     : FAMate Core FaTcpDriver Data Class
--  History         : Created by jungyoul.moon at 2013.08.26
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    public class FData : FBaseObject<FData>, FIObject
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FData(
            FTcpDriver fTcpDriver
            )
            : base(fTcpDriver.fTcdCore, FTcpDriverCommon.createXmlNodeDAT(fTcpDriver.fTcdCore.fXmlDoc))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FData(
            FTcdCore fTcdCore,
            FXmlNode fXmlNode
            )
            : base(fTcdCore, fXmlNode)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FData(
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
                    return FObjectType.Data;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.Data;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagDAT.A_UniqueId, FXmlTagDAT.D_UniqueId);
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

        public bool locked
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagDAT.A_Locked, FXmlTagDAT.D_Locked));
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

        public string name
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagDAT.A_Name, FXmlTagDAT.D_Name);
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

                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_Name, FXmlTagDAT.D_Name, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagDAT.A_Description, FXmlTagDAT.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_Description, FXmlTagDAT.D_Description, value, true);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagDAT.A_FontColor, FXmlTagDAT.D_FontColor));
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
                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_FontColor, FXmlTagDAT.D_FontColor, value.Name, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagDAT.A_FontBold, FXmlTagDAT.D_FontBold));
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
                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_FontBold, FXmlTagDAT.D_FontBold, FBoolean.fromBool(value), true);
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

        public FDataSourceType fSourceType
        {
            get
            {
                try
                {
                    return FEnumConverter.toDataSourceType(this.fXmlNode.get_attrVal(FXmlTagDAT.A_SourceType, FXmlTagDAT.D_SourceType));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FDataSourceType.Constant;
            }

            set
            {
                try
                {
                    if (this.fSourceType == value)
                    {
                        return;
                    }

                    // --                    

                    // ***
                    // 자식 Data를 가지고 있을 경우 Resource Type으로 변경 불가
                    // ***
                    if (value == FDataSourceType.Resource && this.hasChild)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0009, "Resource Source Type", "Child"));
                    }

                    // ***
                    // 형제 중에 Variable Data 가 존재하지 않아야 한다.
                    // ***
                    if (
                        (this.fPreviousSibling != null && this.fPreviousSibling.fPattern == FPattern.Variable) &&
                        (this.fNextSibling != null && this.fNextSibling.fPattern == FPattern.Variable)
                       )
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0013, "Variable Data"));
                    }

                    // ***
                    // Variable은 한 종류의 Source Type만을 설정할 수 있다.
                    // ***
                    if (this.fPattern == FPattern.Variable && (value == FDataSourceType.Item || value == FDataSourceType.Column))
                    {
                        if (
                            (this.fPreviousSibling != null && this.fPreviousSibling.fPattern == FPattern.Variable && this.fPreviousSibling.fSourceType != value) &&
                            (this.fNextSibling != null && this.fNextSibling.fPattern == FPattern.Variable && this.fNextSibling.fSourceType != value)
                            )
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0015, "Source Type"));
                        }
                    }

                    // --                    

                    if (value == FDataSourceType.Constant || value == FDataSourceType.Resource || value == FDataSourceType.EquipmentState)
                    {
                        this.fXmlNode.set_attrVal(FXmlTagDAT.A_Pattern, FXmlTagDAT.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));
                        this.fXmlNode.set_attrVal(FXmlTagDAT.A_FixedLength, FXmlTagDAT.D_FixedLength, "1");
                    }                    
                    // --
                    if (value == FDataSourceType.Resource && this.fFormat != FFormat.Ascii)
                    {
                        this.fXmlNode.set_attrVal(FXmlTagDAT.A_Format, FXmlTagDAT.D_Format, FEnumConverter.fromFormat(FFormat.Ascii));
                        this.fXmlNode.set_attrVal(FXmlTagDAT.A_Value, FXmlTagDAT.D_Value, string.Empty);
                        this.fXmlNode.set_attrVal(FXmlTagDAT.A_Length, FXmlTagDAT.D_Length, "0");
                    }    
                    
                    // --

                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_SourceConstant, FXmlTagDAT.D_SourceConstant, "");
                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_SourceResource, FXmlTagDAT.D_SourceResource, "");
                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_SourceEquipmentState, FXmlTagDAT.D_SourceEquipmentState, "");
                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_SourceEnvironment, FXmlTagDAT.D_SourceEnvironment, "");
                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_SourceColumn, FXmlTagDAT.D_SourceColumn, "");
                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_SourceItem, FXmlTagDAT.D_SourceItem, "");        
                    // --
                    if (value == FDataSourceType.Constant)
                    {
                        this.fXmlNode.set_attrVal(FXmlTagDAT.A_SourceConstant, FXmlTagDAT.D_SourceConstant, "Constant");
                    }
                    else if (value == FDataSourceType.Resource)
                    {
                        this.fXmlNode.set_attrVal(FXmlTagDAT.A_SourceResource, FXmlTagDAT.D_SourceResource, "N");
                    }
                    else if (value == FDataSourceType.EquipmentState)
                    {
                        this.fXmlNode.set_attrVal(FXmlTagDAT.A_SourceEquipmentState, FXmlTagDAT.D_SourceEquipmentState, "EquipmentState");
                    }
                    else if (value == FDataSourceType.Environment)
                    {
                        this.fXmlNode.set_attrVal(FXmlTagDAT.A_SourceEnvironment, FXmlTagDAT.D_SourceEnvironment, "Environment");
                    }
                    else if (value == FDataSourceType.Column)
                    {
                        this.fXmlNode.set_attrVal(FXmlTagDAT.A_SourceColumn, FXmlTagDAT.D_SourceColumn, "Column");
                    }
                    else if (
                        value == FDataSourceType.Item || 
                        value == FDataSourceType.ItemTag1 ||
                        value == FDataSourceType.ItemTag2 ||
                        value == FDataSourceType.ItemTag3 ||
                        value == FDataSourceType.ItemTag4 ||
                        value == FDataSourceType.ItemTag5
                        )
                    {
                        this.fXmlNode.set_attrVal(FXmlTagDAT.A_SourceItem, FXmlTagDAT.D_SourceItem, "Item");
                    }                    

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_SourceType, FXmlTagDAT.D_SourceType, FEnumConverter.fromDataSourceType(value), true);
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

        public string sourceConstant
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagDAT.A_SourceConstant, FXmlTagDAT.D_SourceConstant);
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
                    if (this.fSourceType != FDataSourceType.Constant)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Source Type", "Constant"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_SourceConstant, FXmlTagDAT.D_SourceConstant, value, true);
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

        public FResourceSourceType sourceResource
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = this.fXmlNode.get_attrVal(FXmlTagDAT.A_SourceResource, FXmlTagDAT.D_SourceResource);
                    if (val == string.Empty)
                    {
                        return FResourceSourceType.None;
                    }
                    // --
                    return FEnumConverter.toResourceSourceType(val);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FResourceSourceType.None;
            }

            set
            {
                try
                {
                    if (this.fSourceType != FDataSourceType.Resource)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Source Type", "Resource"));
                    }
                    // --
                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_SourceResource, FXmlTagDAT.D_SourceResource, FEnumConverter.fromResourceSourceType(value), true);
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

        public string sourceEquipmentState
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagDAT.A_SourceEquipmentState, FXmlTagDAT.D_SourceEquipmentState);
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
                    if (this.fSourceType != FDataSourceType.EquipmentState)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Source Type", "EquipmentState"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_SourceEquipmentState, FXmlTagDAT.D_SourceEquipmentState, value, true);
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

        public string sourceItem
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagDAT.A_SourceItem, FXmlTagDAT.D_SourceItem);
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
                    if (
                        this.fSourceType != FDataSourceType.Item && 
                        this.fSourceType != FDataSourceType.ItemTag1 &&
                        this.fSourceType != FDataSourceType.ItemTag2 &&
                        this.fSourceType != FDataSourceType.ItemTag3 &&
                        this.fSourceType != FDataSourceType.ItemTag4 &&
                        this.fSourceType != FDataSourceType.ItemTag5
                        )
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Source Type", "Item"));
                    }

                    // --
                    
                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_SourceItem, FXmlTagDAT.D_SourceItem, value, true);
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

        public string sourceColumn
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagDAT.A_SourceColumn, FXmlTagDAT.D_SourceColumn);
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
                    if (this.fSourceType != FDataSourceType.Column)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Source Type", "Column"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_SourceColumn, FXmlTagDAT.D_SourceColumn, value, true);
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

        public string sourceEnvironment
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagDAT.A_SourceEnvironment, FXmlTagDAT.D_SourceEnvironment);
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
                    if (this.fSourceType != FDataSourceType.Environment)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Source Type", "Environment"));
                    }

                    // --
                    
                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_SourceEnvironment, FXmlTagDAT.D_SourceEnvironment, value, true);
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

        public FDataTargetType fTargetType
        {
            get
            {
                try
                {
                    return FEnumConverter.toDataTargetType(this.fXmlNode.get_attrVal(FXmlTagDAT.A_TargetType, FXmlTagDAT.D_TargetType));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FDataTargetType.Item;
            }

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_TargetConstant, FXmlTagDAT.D_TargetConstant, "");
                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_TargetColumn, FXmlTagDAT.D_TargetColumn, "");
                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_TargetItem, FXmlTagDAT.D_TargetItem, "");                    
                    // --
                    if (value == FDataTargetType.Constant)
                    {
                        this.fXmlNode.set_attrVal(FXmlTagDAT.A_TargetConstant, FXmlTagDAT.D_TargetConstant, "Constant");
                    }
                    else if (value == FDataTargetType.Column)
                    {
                        this.fXmlNode.set_attrVal(FXmlTagDAT.A_TargetColumn, FXmlTagDAT.D_TargetColumn, "Column");
                    }
                    else if (value == FDataTargetType.Item)
                    {
                        this.fXmlNode.set_attrVal(FXmlTagDAT.A_TargetItem, FXmlTagDAT.D_TargetItem, "Item");
                    }                   

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_TargetType, FXmlTagDAT.D_TargetType, FEnumConverter.fromDataTargetType(value), true);
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

        public string targetConstant
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagDAT.A_TargetConstant, FXmlTagDAT.D_TargetConstant);
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
                    FTcpDriverCommon.validateName(value, false);
                    // --
                    if (this.fTargetType != FDataTargetType.Constant)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Target Type", "Constant"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_TargetConstant, FXmlTagDAT.D_TargetConstant, value, true);
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

        public string targetColumn
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagDAT.A_TargetColumn, FXmlTagDAT.D_TargetColumn);
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
                    FTcpDriverCommon.validateName(value, false);
                    // --
                    if (this.fTargetType != FDataTargetType.Column)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Target Type", "Column"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_TargetColumn, FXmlTagDAT.D_TargetColumn, value, true);
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

        public string targetItem
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagDAT.A_TargetItem, FXmlTagDAT.D_TargetItem);
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
                    FTcpDriverCommon.validateName(value, false);
                    // --
                    if (this.fTargetType != FDataTargetType.Item)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Target Type", "Item"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_TargetItem, FXmlTagDAT.D_TargetItem, value, true);
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

        public FPattern fPattern
        {
            get
            {
                try
                {
                    return FEnumConverter.toPattern(this.fXmlNode.get_attrVal(FXmlTagDAT.A_Pattern, FXmlTagDAT.D_Pattern));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FPattern.Fixed;
            }

            set
            {
                try
                {
                    if (this.fPattern == value)
                    {
                        return;
                    }

                    // --

                    // ***
                    // Parent가 없는 Data의 Source Pattern은 변경할 수 없다.
                    // ***
                    if (this.fParent == null)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, "Data without the Parent", "Pattern"));
                    }

                    if (value == FPattern.Fixed)
                    {
                        // ***
                        // Previous와 Next 형제가 Variable Data가 아니어야 한다.
                        // ***
                        if (
                            (this.fPreviousSibling != null && this.fPreviousSibling.fPattern == FPattern.Variable) &&
                            (this.fNextSibling != null && this.fNextSibling.fPattern == FPattern.Variable)
                            )
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0010, "Pattern of the Previous Data and the Next Data", "Variable"));
                        }
                    }
                    else if (value == FPattern.Variable)
                    {
                        // ***
                        // Constant Source Type과 Resource Source Type & EquipmentState Source Type은 Variable로 설정할 수 없다.
                        // ***
                        if (this.fSourceType == FDataSourceType.Constant || this.fSourceType == FDataSourceType.Resource || this.fSourceType == FDataSourceType.EquipmentState)
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0015, "Source Type"));
                        }

                        // --

                        if (
                            (this.fParent.fObjectType == FObjectType.DataSet && ((FDataSet)this.fParent).hasVariableChild) ||
                            (this.fParent.fObjectType == FObjectType.Data && ((FData)this.fParent).hasVariableChild)
                            )
                        {
                            // ***
                            // 형제 Variable Data와 연속적으로 이어져야 한다.
                            // ***
                            if (this.fPreviousSibling == null && this.fNextSibling.fPattern != FPattern.Variable)
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0011, "Pattern of the Previous Data and the Next Data", "Variable"));
                            }
                            else if (this.fNextSibling == null && this.fPreviousSibling.fPattern != FPattern.Variable)
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0011, "Pattern of the Previous Data and the Next Data", "Variable"));
                            }
                            else if (
                                this.fPreviousSibling != null &&
                                this.fNextSibling != null &&
                                (this.fPreviousSibling.fPattern != FPattern.Variable && this.fNextSibling.fPattern != FPattern.Variable)
                                )
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0011, "Pattern of the Previous Data and the Next Data", "Variable"));
                            }

                            // --

                            // ***
                            // Variable은 한 종류의 Source Type만을 설정할 수 있다.
                            // ***
                            if (
                                (this.fPreviousSibling != null && this.fPreviousSibling.fPattern == FPattern.Variable && this.fPreviousSibling.fSourceType != this.fSourceType) ||
                                (this.fNextSibling != null && this.fNextSibling.fPattern == FPattern.Variable && this.fNextSibling.fSourceType != this.fSourceType)
                                )
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0015, "Type"));
                            }
                        }
                    }

                    // --

                    // ***
                    // Pattern 변경시, Fixed Length와 Scan Mode는 초기화
                    // ***
                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_FixedLength, FXmlTagDAT.D_FixedLength, "1");
                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_ScanMode, FXmlTagDAT.D_ScanMode, FXmlTagDAT.D_ScanMode);
                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_Pattern, FXmlTagDAT.A_Pattern, FEnumConverter.fromPattern(value), true);
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

        public int fixedLength
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagDAT.A_FixedLength, FXmlTagDAT.D_FixedLength));
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
                    // Parent가 없는 Data의 Fixed Length는 변경할 수 없다.
                    // ***
                    if (this.fParent == null)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, "Data without the Parent", "Fixed Length"));
                    }

                    // ***
                    // Pattern이 Fixed가 아닌 경우 Fixed Length를 변경할 수 없다.
                    // ***
                    if (this.fPattern != FPattern.Fixed)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Pattern", "Fixed"));
                    }

                    if (value < 1)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Fixed Length"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_FixedLength, FXmlTagDAT.D_FixedLength, value.ToString(), true);
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

        public FFormat fFormat
        {
            get
            {
                try
                {
                    return FEnumConverter.toFormat(this.fXmlNode.get_attrVal(FXmlTagDAT.A_Format, FXmlTagDAT.D_Format));
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

            set
            {
                try
                {
                    if (this.fFormat == value)
                    {
                        return;
                    }

                    // --            

                    // ***
                    // Locked되어 있는 Data의 Format은 변경할 수 없다.
                    // ***
                    if (this.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }

                    // ***
                    // Resource는 Ascii Format만을 지원
                    // ***
                    if (this.fSourceType == FDataSourceType.Resource)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0008, "Resource Source Type", "Format"));
                    }

                    // ***
                    // 자식이 존재하는 List Format의 Data는 Format을 변경할 수 없다.
                    // ***
                    if (this.hasChild)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0013, "Object's Child"));
                    }

                    // ***
                    // 부모가 Data이고 부모의 Format이 AsciiList인 경우 Format를 변경할 수 없다.
                    // ***
                    if (this.fParent != null && this.fParent.fObjectType == FObjectType.Data && ((FData)this.fParent).fFormat == FFormat.AsciiList)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0010, "Parent's Format", "Ascii List"));
                    }

                    // --

                    setChangedFormat();
                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_Format, FXmlTagDAT.D_Format, FEnumConverter.fromFormat(value), true);
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

        public bool merge
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagDAT.A_Merge, FXmlTagDAT.D_Merge));
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
                    // --

                    if (this.fFormat != FFormat.Ascii)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Format"));
                    }

                    // --
                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_Merge, FXmlTagDAT.D_Merge, FBoolean.fromBool(value), true);
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

        public FDataScanMode fScanMode
        {
            get
            {
                try
                {
                    return FEnumConverter.toDataScanMode(this.fXmlNode.get_attrVal(FXmlTagDAT.A_ScanMode, FXmlTagDAT.D_ScanMode));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FDataScanMode.Local;
            }

            set
            {
                try
                {
                    if (this.fPattern != FPattern.Fixed)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Pattern", "Fixed"));
                    }

                    // --

                    fXmlNode.set_attrVal(FXmlTagDAT.A_ScanMode, FXmlTagDAT.D_ScanMode, FEnumConverter.fromDataScanMode(value), true);
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

        public string originalStringValue
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagDAT.A_Value, FXmlTagDAT.D_Value);
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
                    fFormat = this.fFormat;

                    // --

                    // ***
                    // List, Unknown, Raw, Format은 Value를 설정할 수 없다.
                    // ***
                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, fFormat.ToString() + " Format", "Value"));
                    }

                    // --

                    val = FValueConverter.fromStringValue(fFormat, value, out length);
                    // --
                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_Length, FXmlTagDAT.D_Length, length.ToString());
                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_Value, FXmlTagDAT.D_Value, val, true);
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

        public string[] originalStringArrayValue
        {
            get
            {
                try
                {
                    return FValueConverter.toStringArrayValue(this.fFormat, this.originalStringValue);
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
                    fFormat = this.fFormat;

                    // --

                    // ***
                    // List,Unknown, Raw Format은 Value를 설정할 수 없다.
                    // ***

                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, fFormat.ToString() + " Format", "Value"));
                    }

                    // --

                    val = FValueConverter.fromStringArrayValue(fFormat, value, out length);
                    // --
                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_Length, FXmlTagDAT.D_Length, length.ToString());
                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_Value, FXmlTagDAT.D_Value, val, true);
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

        public object originalValue
        {
            get
            {
                try
                {
                    return FValueConverter.toValue(this.fFormat, this.originalStringValue, this.originalLength);
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
                    fFormat = this.fFormat;

                    // -- 

                    // ***
                    // List, Unknown, Raw Format은 Value를 설정할 수 없다.
                    // ***
                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, fFormat.ToString() + " Format", "Value"));
                    }

                    // --

                    val = FValueConverter.fromValue(fFormat, value, out length);
                    // --
                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_Length, FXmlTagDAT.D_Length, length.ToString());
                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_Value, FXmlTagDAT.D_Value, val, true);
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

        public string originalEncodingValue
        {
            get
            {
                try
                {
                    return FValueConverter.toEncodingValue(this.fFormat, this.originalStringValue);
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

        public int originalLength
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagDAT.A_Length, FXmlTagDAT.D_Length));
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

        public string stringValue
        {
            get
            {
                int length = 0;

                try
                {
                    return FValueConverter.toDataConversionStringValue(
                        this.fFormat,
                        this.originalStringValue,
                        this.fXmlNode.get_attrVal(FXmlTagDAT.A_Transformer, FXmlTagDAT.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagDAT.A_DataConversionSetExpression, FXmlTagDAT.D_DataConversionSetExpression),
                        ref length
                        );
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

        public string[] stringArrayValue
        {
            get
            {
                try
                {
                    return FValueConverter.toConversionedStringArrayValue(
                        this.fFormat,
                        this.originalStringValue,
                        this.fXmlNode.get_attrVal(FXmlTagDAT.A_Transformer, FXmlTagDAT.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagDAT.A_DataConversionSetExpression, FXmlTagDAT.D_DataConversionSetExpression)
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public object value
        {
            get
            {
                try
                {
                    return FValueConverter.toDataConversionedValue(
                        this.fFormat,
                        this.originalStringValue,
                        this.fXmlNode.get_attrVal(FXmlTagDAT.A_Transformer, FXmlTagDAT.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagDAT.A_DataConversionSetExpression, FXmlTagDAT.D_DataConversionSetExpression),
                        this.originalLength
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string encodingValue
        {
            get
            {
                try
                {
                    return FValueConverter.toDataConversionedEncodingValue(
                        this.fFormat,
                        this.originalStringValue,
                        this.fXmlNode.get_attrVal(FXmlTagDAT.A_Transformer, FXmlTagDAT.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagDAT.A_DataConversionSetExpression, FXmlTagDAT.D_DataConversionSetExpression)
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int length
        {
            get
            {
                int length = 0;

                try
                {
                    length = this.originalLength;
                    FValueConverter.toDataConversionStringValue(
                        this.fFormat,
                        this.originalStringValue,
                        this.fXmlNode.get_attrVal(FXmlTagDAT.A_Transformer, FXmlTagDAT.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagDAT.A_DataConversionSetExpression, FXmlTagDAT.D_DataConversionSetExpression),
                        ref length
                        );
                    return length;
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

        public bool isArrayValue
        {
            get
            {
                FFormat fFormat;

                try
                {
                    fFormat = this.fFormat;
                    if (
                        fFormat == FFormat.List ||
                        fFormat == FFormat.AsciiList ||
                        fFormat == FFormat.Ascii ||
                        fFormat == FFormat.JIS8 ||
                        fFormat == FFormat.A2 ||
                        fFormat == FFormat.Unknown ||
                        fFormat == FFormat.Raw
                        )
                    {
                        return false;
                    }

                    // --

                    if (this.length > 1)
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

        //------------------------------------------------------------------------------------------------------------------------

        public bool isNullValue
        {
            get
            {
                FFormat fFormat;

                try
                {
                    fFormat = this.fFormat;
                    if (
                        fFormat == FFormat.List ||
                        fFormat == FFormat.AsciiList ||
                        fFormat == FFormat.Unknown ||
                        fFormat == FFormat.Raw
                        )
                    {
                        return true;
                    }

                    // --

                    if (this.length == 0)
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

        //------------------------------------------------------------------------------------------------------------------------

        public Type valueType
        {
            get
            {
                try
                {
                    return FValueConverter.getValueType(this.fFormat);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return typeof(object);
            }
        }   

        //------------------------------------------------------------------------------------------------------------------------

        public FDataValueTransformer fValueTransformer
        {
            get
            {
                try
                {
                    return new FDataValueTransformer(this);
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
                    id = this.fXmlNode.get_attrVal(FXmlTagDAT.A_DataConversionSetID, FXmlTagDAT.D_DataConversionSetID);
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
                    return this.fXmlNode.get_attrVal(FXmlTagDAT.A_DataConversionSetName, FXmlTagDAT.D_DataConversionSetName);
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
                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_DataConversionSetName, FXmlTagDAT.D_DataConversionSetName, value, false);
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
                    return this.fXmlNode.get_attrVal(FXmlTagDAT.A_DataConversionSetExpression, FXmlTagDAT.D_DataConversionSetExpression);
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
                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_DataConversionSetExpression, FXmlTagDAT.D_DataConversionSetExpression, value, false);
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
                    return this.fXmlNode.get_attrVal(FXmlTagDAT.A_UserTag1, FXmlTagDAT.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_UserTag1, FXmlTagDAT.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagDAT.A_UserTag2, FXmlTagDAT.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_UserTag2, FXmlTagDAT.D_UserTag2, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagDAT.A_UserTag3, FXmlTagDAT.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_UserTag3, FXmlTagDAT.D_UserTag3, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagDAT.A_UserTag4, FXmlTagDAT.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_UserTag4, FXmlTagDAT.D_UserTag4, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagDAT.A_UserTag5, FXmlTagDAT.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagDAT.A_UserTag5, FXmlTagDAT.D_UserTag5, value, true);
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

        public FDataCollection fChildDataCollection
        {
            get
            {
                try
                {
                    return new FDataCollection(this.fTcdCore, this.fXmlNode.selectNodes(FXmlTagDAT.E_Data));
                }
                catch(Exception ex)
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

        public FDataCollection fFixedChildDataCollection
        {
            get
            {
                string xpath = string.Empty;

                try
                {
                    xpath = FXmlTagDAT.E_Data + "[@" + FXmlTagDAT.A_Pattern + "='" + FEnumConverter.fromPattern(FPattern.Fixed) + "']";
                    return new FDataCollection(this.fTcdCore, this.fXmlNode.selectNodes(xpath));
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

        //-----------------------------------------------------------------------------------------------------------------------

        public FDataCollection fVariableChildDataColection
        {
            get
            {
                string xpath = string.Empty;

                try
                {
                    xpath = FXmlTagDAT.E_Data + "[@" + FXmlTagDAT.A_Pattern + "='" + FEnumConverter.fromPattern(FPattern.Variable) + "']";
                    return new FDataCollection(this.fTcdCore, this.fXmlNode.selectNodes(xpath));
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

                    if (this.fXmlNode.fParentNode.name == FXmlTagDTS.E_DataSet)
                    {
                        return new FDataSet(this.fTcdCore, this.fXmlNode.fParentNode);
                    }
                    return new FData(this.fTcdCore, this.fXmlNode.fParentNode);
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
                
        public FData fPreviousSibling
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fPreviousSibling == null)
                    {
                        return null;
                    }
                    return new FData(this.fTcdCore, this.fXmlNode.fPreviousSibling);
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

        public FData fNextSibling
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fNextSibling == null)
                    {
                        return null;
                    }
                    return new FData(this.fTcdCore, this.fXmlNode.fNextSibling);
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

        public FDataSet fAncestorDataSet
        {
            get
            {
                try
                {
                    return this.getAncestorDataSet();
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
                FDataSet fDts = null;
                string xpath = string.Empty;

                try
                {
                    fDts = this.fAncestorDataSet;
                    if (fDts == null)
                    {
                        xpath = "NULL";
                    }
                    else
                    {
                        xpath =
                            "../../../../" + FXmlTagEQM.E_EquipmentModeling +
                            "/" + FXmlTagEQP.E_Equipment +
                            "/" + FXmlTagSNG.E_ScenarioGroup +
                            "/" + FXmlTagSNR.E_Scenario +
                            "/" + FXmlTagJDM.E_Judgement +
                            "/" + FXmlTagJCN.E_JudgementCondition +                            
                            "//" + FXmlTagJEP.E_JudgementExpression + "[@" + FXmlTagJEP.A_OperandId + "='" + this.uniqueIdToString + "' or @" + FXmlTagJEP.A_ValueId + "='" + this.uniqueIdToString + "']";
                    }
                    // --
                    return new FObjectCollection(this.fTcdCore, fDts.fXmlNode.selectNodes(xpath));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    fDts = null;
                }
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FObjectCollection fInclusionObjectCollection
        {
            get
            {
                try
                {
                    return new FObjectCollection(this.fTcdCore, this.fXmlNode.selectNodes("NULL"));
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
                    return this.fXmlNode.containsNode(FXmlTagDAT.E_Data);
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

        public bool hasFixedChild
        {
            get
            {
                string xpath = string.Empty;

                try
                {
                    xpath = FXmlTagDAT.E_Data + "[@" + FXmlTagDAT.A_Pattern + "='" + FEnumConverter.fromPattern(FPattern.Fixed) + "']";
                    return this.fXmlNode.containsNode(xpath);
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
        
        public bool hasVariableChild
        {
            get
            {
                string xpath = string.Empty;

                try
                {
                    xpath = FXmlTagDAT.E_Data + "[@" + FXmlTagDAT.A_Pattern + "='" + FEnumConverter.fromPattern(FPattern.Variable) + "']";
                    return this.fXmlNode.containsNode(xpath);                    
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
                    if (this.fXmlNode.get_attrVal(FXmlTagDAT.A_Transformer, FXmlTagDAT.D_Transformer) == string.Empty)
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
                    if (this.fXmlNode.get_attrVal(FXmlTagDAT.A_DataConversionSetID, FXmlTagDAT.D_DataConversionSetID) == string.Empty)
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

        public bool hasMerge
        {
            get
            {
                try
                {
                    if (this.fXmlNode.get_attrVal(FXmlTagDAT.A_Merge, FXmlTagDAT.D_Merge) == "F")
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
                    // ***
                    // Data Format이 List인 경우에만 Child Item을 가질 수 있다.
                    // ***
                    if (this.fFormat == FFormat.List || this.fFormat == FFormat.AsciiList)
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

        //------------------------------------------------------------------------------------------------------------------------

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
                    if (this.fXmlNode.fParentNode == null || this.locked)
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
                    fFormat = this.fFormat;

                    // --

                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
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

                    // --

                    if (this.fPattern == FPattern.Variable)
                    {
                        if (
                            this.fPreviousSibling.fPattern == FPattern.Fixed && 
                            this.fNextSibling != null &&
                            this.fNextSibling.fPattern == FPattern.Variable
                            )
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (
                            this.fPreviousSibling.fPattern == FPattern.Variable && 
                            this.fPreviousSibling.fPreviousSibling != null &&
                            this.fPreviousSibling.fPreviousSibling.fPattern == FPattern.Variable
                            )
                        {
                            return false;
                        }
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
                    // --
                    if (this.fPattern == FPattern.Variable)
                    {
                        if (
                            this.fNextSibling.fPattern == FPattern.Fixed && 
                            this.fPreviousSibling != null &&
                            this.fPreviousSibling.fPattern == FPattern.Variable
                            )
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (
                            this.fNextSibling.fPattern == FPattern.Variable && 
                            this.fNextSibling.fNextSibling != null &&
                            this.fNextSibling.fNextSibling.fPattern == FPattern.Variable
                            )
                        {
                            return false;
                        }
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
                    if (this.fXmlNode.fParentNode == null || this.locked)
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
                FData fDat = null;

                try
                {
                    if (
                        this.fXmlNode.fParentNode == null ||
                        !FClipboard.containsData(FCbObjectFormat.Data)
                        )
                    {
                        return false;
                    }

                    // --

                    if (this.fParent.fObjectType == FObjectType.Data && ((FData)this.fParent).fFormat == FFormat.AsciiList)
                    {
                        fDat = (FData)this.pasteObject(FCbObjectFormat.Data);
                        if (fDat.fFormat != FFormat.Ascii)
                        {
                            return false;
                        }
                    }

                    // --

                    if (
                        this.fPattern == FPattern.Variable &&
                        (this.fNextSibling != null && this.fNextSibling.fPattern == FPattern.Variable)
                        )
                    {
                        if (fDat == null)
                        {
                            fDat = (FData)this.pasteObject(FCbObjectFormat.Data);
                        }
                        // --                        
                        if (this.fSourceType != fDat.fSourceType)
                        {
                            return false;
                        }
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
                    fDat = null;
                }
                return false;
            }
        }
                
        //------------------------------------------------------------------------------------------------------------------------

        public bool canPasteChild
        {
            get
            {
                FData fDat = null;

                try
                {
                    if (
                        !FClipboard.containsData(FCbObjectFormat.Data) || 
                        (this.fFormat != FFormat.List && this.fFormat != FFormat.AsciiList)
                        )
                    {
                        return false;
                    }

                    // --

                    if (this.fFormat == FFormat.AsciiList)
                    {
                        fDat = (FData)this.pasteObject(FCbObjectFormat.Data);
                        if (fDat.fFormat != FFormat.Ascii)
                        {
                            return false;
                        }
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
                    fDat = null;
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
            StringBuilder info = null;
            FDataSourceType fSourceType;
            FDataTargetType fTargetType;
            FPattern fPattern;
            FFormat fFormat;
            FDataScanMode fScanMode;
            int length = 0;
            string value = string.Empty;

            try
            {
                info = new StringBuilder();

                // --

                if (option == FStringOption.Default)
                {
                    info.Append(this.name);
                }
                else
                {
                    fPattern = this.fPattern;
                    fFormat = this.fFormat;

                    // --

                    if (fPattern == FPattern.Fixed && this.fixedLength > 1)
                    {
                        info.Append("[fx(" + this.fixedLength.ToString() + ").] ");
                    }
                    else if (fPattern == FPattern.Variable)
                    {
                        info.Append("[vr.] ");
                    }

                    // --

                    if (this.hasValueTransformer)
                    {
                        info.Append("[vt.] ");
                    }

                    // --

                    if (this.hasDataConversionSet)
                    {
                        info.Append("[dc.] ");
                    }

                    // --

                    if (this.hasMerge)
                    {
                        info.Append("[mg.] ");
                    }

                    // --

                    info.Append(FEnumConverter.fromFormat(fFormat));
                    length = this.originalLength;
                    // --
                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                    {
                        info.Append("[" + length.ToString() + "] " + this.name);
                    }
                    else if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2)
                    {
                        value = FValueConverter.toDataConversionedEncodingValue(
                            fFormat,
                            this.originalStringValue,
                            this.fXmlNode.get_attrVal(FXmlTagDAT.A_Transformer, FXmlTagDAT.D_Transformer),
                            this.fXmlNode.get_attrVal(FXmlTagDAT.A_DataConversionSetExpression, FXmlTagDAT.D_DataConversionSetExpression),
                            ref length
                            );

                        // --

                        info.Append("[" + length.ToString() + "] " + this.name + "=\"");
                        // --
                        if (value.Length > 1000)
                        {
                            info.Append(value.Substring(0, 1000));
                        }
                        else
                        {
                            info.Append(value);
                        }
                        // --
                        info.Append("\"");
                    }
                    else
                    {
                        value = FValueConverter.toDataConversionStringValue(
                            fFormat,
                            this.originalStringValue,
                            this.fXmlNode.get_attrVal(FXmlTagDAT.A_Transformer, FXmlTagDAT.D_Transformer),
                            this.fXmlNode.get_attrVal(FXmlTagDAT.A_DataConversionSetExpression, FXmlTagDAT.D_DataConversionSetExpression),
                            ref length
                            );

                        // --

                        info.Append("[" + length.ToString() + "] " + this.name + "=\"");
                        // --
                        if (value.Length > 1000)
                        {
                            info.Append(value.Substring(0, 1000));
                        }
                        else
                        {
                            info.Append(value);
                        }
                        // --
                        info.Append("\"");
                    }

                    // --

                    fScanMode = FEnumConverter.toDataScanMode(this.fXmlNode.get_attrVal(FXmlTagDAT.A_ScanMode, FXmlTagDAT.D_ScanMode));
                    if (fScanMode == FDataScanMode.Global)
                    {
                        info.Append(" [g.]");
                    }

                    // --

                    fSourceType = this.fSourceType;                    
                    // --                    
                    info.Append(" Source=[");
                    // --
                    if (fSourceType == FDataSourceType.Constant)
                    {
                        info.Append("con: " + this.sourceConstant);
                    }
                    else if (fSourceType == FDataSourceType.Resource)
                    {
                        info.Append("res: " + this.sourceResource.ToString());
                    }
                    else if (fSourceType == FDataSourceType.EquipmentState)
                    {
                        info.Append("est:" + this.sourceEquipmentState.ToString());
                    }
                    else if (fSourceType == FDataSourceType.Environment)
                    {
                        info.Append("env: " + this.sourceEnvironment);
                    }
                    else if (fSourceType == FDataSourceType.Column)
                    {
                        info.Append("col: " + this.sourceColumn);
                    }
                    else if (fSourceType == FDataSourceType.Item)
                    {
                        info.Append("itm: " + this.sourceItem);
                    }
                    else if (fSourceType == FDataSourceType.ItemTag1)
                    {
                        info.Append("it1: " + this.sourceItem);
                    }
                    else if (fSourceType == FDataSourceType.ItemTag2)
                    {
                        info.Append("it2: " + this.sourceItem);
                    }
                    else if (fSourceType == FDataSourceType.ItemTag3)
                    {
                        info.Append("it3: " + this.sourceItem);
                    }
                    else if (fSourceType == FDataSourceType.ItemTag4)
                    {
                        info.Append("it4: " + this.sourceItem);
                    }
                    else if (fSourceType == FDataSourceType.ItemTag5)
                    {
                        info.Append("it5: " + this.sourceItem);
                    }
                    // --
                    info.Append("]");

                    // --

                    fTargetType = this.fTargetType;                    
                    // --
                    info.Append(" → Target=[");
                    // --
                    if (fTargetType == FDataTargetType.Constant)
                    {
                        info.Append("con: " + this.targetConstant);
                    }
                    else if (fTargetType == FDataTargetType.Column)
                    {
                        info.Append("col: " + this.targetColumn);
                    }
                    else if (fTargetType == FDataTargetType.Item)
                    {
                        info.Append("itm: " + this.targetItem);
                    }
                    // --
                    info.Append("]");
                }

                // --

                if (this.description != string.Empty)
                {
                    info.Append(" Desc=[" + this.description + "]");
                }

                // --
                
                return info.ToString();
            }
            catch(Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FData appendChildData(
            FData fNewChild
            )
        {
            try
            {
                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                
                // --
                
                // ***
                // Format이 List인 Data만이 Child Data를 가질 수 있다.
                // ***
                if (this.fFormat != FFormat.List && this.fFormat != FFormat.AsciiList)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Data's Format", "List or the AsciiList"));
                }

                // ***
                // Format이 AsciiList인 경우 Ascii Format의 Child Data만을 가질 수 있다.
                // ***
                if (this.fFormat == FFormat.AsciiList && fNewChild.fFormat != FFormat.Ascii)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Format of New Child", "Ascii"));
                }

                // --

                fNewChild.replace(this.fTcdCore, this.fXmlNode.appendChild(fNewChild.fXmlNode));

                // --

                // ***
                // 현재 Data의 Length 1 증가
                // ***
                this.fXmlNode.set_attrVal(FXmlTagDAT.A_Length, FXmlTagDAT.D_Length, (this.originalLength + 1).ToString());

                // --

                if (this.isModelingObject)
                {
                    FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fTcdCore.fEventPusher.pushEvent(new FEventArgsBase[]{
                        new FObjectEventArgs(FEventId.ObjectAppendCompleted,this.fTcpDriver,this,fNewChild),
                        new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fTcpDriver,this.fParent,this)
                    });
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

        public FData insertBeforeChildData(
            FData fNewChild,
            FData fRefChild
            )
        {
            try
            {
                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);
                // --
                if (this.fFormat != FFormat.List && this.fFormat != FFormat.AsciiList)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Data's Format", "List or the AsciiList"));
                }

                // ***
                // Format이 AsciiList인 경우 Ascii Format의 Child Data만을 가질 수 있다.
                // ***
                if (this.fFormat == FFormat.AsciiList && fNewChild.fFormat != FFormat.Ascii)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Format of New Child", "Ascii"));
                }

                // ***
                // Pattern이 Variable인 Data 사이에 들어갈 경우, Source Type이 동일해야 한다.
                // ***
                if (
                    fRefChild.fPattern == FPattern.Variable &&
                    (fRefChild.fPreviousSibling != null && fRefChild.fPreviousSibling.fPattern == FPattern.Variable)
                    )
                {
                    if (fRefChild.fSourceType != fNewChild.fSourceType)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Source Type of New Child"));
                    }
                }

                // --

                fNewChild.replace(this.fTcdCore, this.fXmlNode.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));

                // --

                // ***
                // 현재 Data의 Length 1 증가
                // ***
                this.fXmlNode.set_attrVal(FXmlTagDAT.A_Length, FXmlTagDAT.D_Length, (this.originalLength + 1).ToString());

                // --

                // ***
                // 추가된 Child의 Previous Data와 Next Data의 Pattern이 Variable일 경우,
                // 추가된 Child의 Pattern을 Variable로 설정한다.
                // ***
                if (
                    (fNewChild.fPreviousSibling != null && fNewChild.fPreviousSibling.fPattern == FPattern.Variable) &&
                    (fNewChild.fNextSibling != null && fNewChild.fNextSibling.fPattern == FPattern.Variable)
                    )
                {
                    fNewChild.fXmlNode.set_attrVal(FXmlTagDAT.A_Pattern, FXmlTagDAT.D_Pattern, FEnumConverter.fromPattern(FPattern.Variable));
                }

                // --

                if (this.isModelingObject)
                {
                    FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fTcdCore.fEventPusher.pushEvent(new FEventArgsBase[]{
                        new FObjectEventArgs(FEventId.ObjectInsertBeforeCompleted, this.fTcpDriver, this, fNewChild),
                        new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fTcpDriver, this.fParent, this)
                    });
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

        public FData insertAfterChildData(
            FData fNewChild,
            FData fRefChild
            )
        {
            try
            {
                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);
                // --
                if (this.fFormat != FFormat.List && this.fFormat != FFormat.AsciiList)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Data's Format", "List or the AsciiList"));
                }

                // ***
                // Format이 AsciiList인 경우 Ascii Format의 Child Data만을 가질 수 있다.
                // ***
                if (this.fFormat == FFormat.AsciiList && fNewChild.fFormat != FFormat.Ascii)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Format of New Child", "Ascii"));
                }

                // ***
                // Pattern이 Variable인 Data 사이에 들어갈 경우, Source Type이 동일해야 한다.
                // ***
                if (
                    fRefChild.fPattern == FPattern.Variable &&
                    (fRefChild.fNextSibling != null && fRefChild.fNextSibling.fPattern == FPattern.Variable)
                    )
                {
                    if (fRefChild.fSourceType != fNewChild.fSourceType)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Source Type of New Child"));
                    }
                }

                // --

                fNewChild.replace(this.fTcdCore, this.fXmlNode.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));

                // --

                // ***
                // 현재 Data의 Length 1증가
                // ***
                this.fXmlNode.set_attrVal(FXmlTagDAT.A_Length, FXmlTagDAT.D_Length, (this.originalLength + 1).ToString());

                // --

                // ***
                // 추가된 Child의 Previous Data와 Next Data의 Pattern이 Variable일 경우,
                // 추가된 Child의 Pattern을 Variable로 설정한다.
                // ***
                if (
                    (fNewChild.fPreviousSibling != null && fNewChild.fPreviousSibling.fPattern == FPattern.Variable) &&
                    (fNewChild.fNextSibling != null && fNewChild.fNextSibling.fPattern == FPattern.Variable)
                    )
                {
                    fNewChild.fXmlNode.set_attrVal(FXmlTagDAT.A_Pattern, FXmlTagDAT.D_Pattern, FEnumConverter.fromPattern(FPattern.Variable));
                }

                // --

                if (this.isModelingObject)
                {
                    FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fTcdCore.fEventPusher.pushEvent(new FEventArgsBase[]{
                        new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this.fTcpDriver,this, fNewChild),
                        new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fTcpDriver, this.fParent, this)
                    });
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
            FIObject fParent = null;
            bool isModelingObject = false;
            int length = 0;

            try
            {
                FTcpDriverCommon.validateRemoveChildObject(this.fXmlNode.fParentNode, this.fXmlNode);

                // --

                // ***
                // 2013.08.12 by spike.lee
                // DataConversionSet Reset Add
                // ***
                resetRelation();

                // --

                isModelingObject = this.isModelingObject;
                fParent = this.fParent;
                if (fParent.fObjectType == FObjectType.DataSet)
                {
                    this.replace(this.fTcdCore, ((FDataSet)fParent).fXmlNode.removeChild(this.fXmlNode));
                }
                else
                {
                    this.replace(this.fTcdCore, ((FData)fParent).fXmlNode.removeChild(this.fXmlNode));
                    // --
                    length = int.Parse(((FData)fParent).fXmlNode.get_attrVal(FXmlTagDAT.A_Length, FXmlTagDAT.D_Length)) - 1;
                    ((FData)fParent).fXmlNode.set_attrVal(FXmlTagDAT.A_Length, FXmlTagDAT.D_Length, length.ToString());
                }

                // --

                // ***
                // Remove 시, Pattern(Fixed)과 Fixed Length(1) 초기화
                // ***
                this.fXmlNode.set_attrVal(FXmlTagDAT.A_Pattern, FXmlTagDAT.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));
                this.fXmlNode.set_attrVal(FXmlTagDAT.A_FixedLength, FXmlTagDAT.D_FixedLength, "1");

                // --

                if (isModelingObject)
                {
                    if (fParent.fObjectType == FObjectType.DataSet)
                    {
                        this.fTcdCore.fEventPusher.pushEvent(
                            new FObjectEventArgs(FEventId.ObjectRemoveCompleted, this.fTcpDriver, fParent, this)
                            );
                    }
                    else
                    {
                        this.fTcdCore.fEventPusher.pushEvent(new FEventArgsBase[]{
                            new FObjectEventArgs(FEventId.ObjectRemoveCompleted, this.fTcpDriver, fParent, this),
                            new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fTcpDriver, ((FData)fParent).fParent, fParent)
                        });
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

        public FData removeChildData(
            FData fChild
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

        public void removeChildData(
            FData[] fChilds
            )
        {
            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                foreach (FData fDat in fChilds)
                {
                    FTcpDriverCommon.validateRemoveChildObject(this.fXmlNode, fDat.fXmlNode);
                }

                // --

                foreach (FData fDat in fChilds)
                {
                    fDat.remove();
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

        public void removeAllChildData(
            )
        {
            FDataCollection fDatCollection = null;
            try
            {
                fDatCollection = this.fChildDataCollection;
                if (fDatCollection == 0)
                {
                    return;
                }

                // --

                foreach (FData fDat in fDatCollection)
                {
                    if (fDat.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }
                }

                // --

                foreach (FData fDat in fDatCollection)
                {
                    fDat.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fDatCollection != null)
                {
                    fDatCollection.Dispose();
                    fDatCollection = null;
                }
            }
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
                if (!this.canMoveUp)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0021, "Object"));
                }

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fTcdCore, this.fXmlNode.moveUp());

                // --

                if (isModelingObject)
                {
                    this.fTcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveUpCompleted, this.fTcpDriver, fParent, this)
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

        public void moveDown(
            )
        {
            bool isModelingObject = false;

            try
            {
                FTcpDriverCommon.validateMoveDownObject(this.fXmlNode);
                // -- 
                if (!this.canMoveDown)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0022, "Object"));
                }

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fTcdCore, this.fXmlNode.moveDown());

                // --

                if (isModelingObject)
                {
                    this.fTcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveDownCompleted, this.fTcpDriver, fParent, this)
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

        public void moveTo(
            FData fRefObject
            )
        {
            FIObject fOldParent = null;

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

                if (!this.fAncestorDataSet.Equals(fRefObject.fAncestorDataSet))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Ancestor Data Set", "same"));
                }

                if (this.containsObject(fRefObject))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0060, "Object", "Child"));
                }

                if (
                    (fRefObject.fParent.fObjectType == FObjectType.DataSet && ((FDataSet)fRefObject.fParent).hasVariableChild) ||
                    (fRefObject.fParent.fObjectType == FObjectType.Data && ((FData)fRefObject.fParent).hasVariableChild)
                    )
                {
                    if (this.fPattern == FPattern.Variable)
                    {
                        if (
                            fRefObject.fPattern != FPattern.Variable &&
                            (fRefObject.fNextSibling == null || fRefObject.fNextSibling.fPattern == FPattern.Fixed)
                            )
                        {
                            if (
                                !this.fParent.Equals(fRefObject.fParent) ||
                                (this.fPreviousSibling != null && this.fPreviousSibling.fPattern == FPattern.Variable) ||
                                (this.fNextSibling != null && this.fNextSibling.fPattern == FPattern.Variable)
                                )
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0011, "Pattern of the Previous Data and the Next Data", "Variable"));
                            }
                        }
                    }
                    else
                    {
                        if (
                            fRefObject.fPattern != FPattern.Fixed &&
                            fRefObject.fNextSibling != null &&
                            fRefObject.fNextSibling.fPattern != FPattern.Fixed
                            )
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0010, "Pattern of the Previous Data and the Next Data", "Variable"));
                        }
                    }
                }

                // --

                fOldParent = this.fParent;

                // --                

                this.replace(this.fTcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fTcdCore, fRefObject.fXmlNode.fParentNode.insertAfter(this.fXmlNode, fRefObject.fXmlNode));

                // --

                if (!this.fParent.Equals(fOldParent))
                {
                    if (this.locked)
                    {
                        if (fOldParent.fObjectType == FObjectType.Data)
                        {
                            ((FData)fOldParent).unlockObject();
                        }
                        // --
                        if (this.fParent.fObjectType == FObjectType.Data)
                        {
                            ((FData)this.fParent).lockObject();
                        }
                    }

                    // --

                    if (fOldParent.fObjectType == FObjectType.Data)
                    {
                        ((FData)fOldParent).fXmlNode.set_attrVal(FXmlTagDAT.A_Length, FXmlTagDAT.D_Length, (((FData)fOldParent).length - 1).ToString(), true);
                    }
                    // --
                    if (this.fParent.fObjectType == FObjectType.Data)
                    {
                        ((FData)this.fParent).fXmlNode.set_attrVal(FXmlTagDAT.A_Length, FXmlTagDAT.D_Length, (((FData)this.fParent).length + 1).ToString(), true);
                    }
                }

                // --

                this.fTcdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fTcpDriver, this, fRefObject)
                    );
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fOldParent = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void moveTo(
            FDataSet fRefObject
            )
        {
            FIObject fOldParent = null;

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

                if (!this.fAncestorDataSet.Equals(fRefObject))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Data", "child"));
                }

                if (fRefObject.fChildDataCollection.count > 0)
                {
                    if (this.Equals(fRefObject.fChildDataCollection[fRefObject.fChildDataCollection.count - 1]))
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0060, "Object", "same localtion"));
                    }
                }  

                if (fRefObject.hasVariableChild)
                {
                    if (this.fPattern == FPattern.Variable)
                    {
                        if (fRefObject.fChildDataCollection[fRefObject.fChildDataCollection.count - 1].fPattern != FPattern.Variable)
                        {
                            if (
                                !this.fParent.Equals(fRefObject) ||
                                (this.fPreviousSibling != null && this.fPreviousSibling.fPattern == FPattern.Variable) ||
                                (this.fNextSibling != null && this.fNextSibling.fPattern == FPattern.Variable)
                                )
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0011, "Pattern of the Previous Data and the Next Data", "Variable"));
                            }
                        }
                    }
                }

                // --      

                fOldParent = this.fParent;

                // --

                this.replace(this.fTcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fTcdCore, fRefObject.fXmlNode.appendChild(this.fXmlNode));

                // --

                if (!this.fParent.Equals(fOldParent))
                {
                    if (this.locked)
                    {
                        ((FData)fOldParent).unlockObject();
                        fRefObject.lockObject();
                    }
                    // --
                    ((FData)fOldParent).fXmlNode.set_attrVal(FXmlTagDAT.A_Length, FXmlTagDAT.D_Length, (((FData)fOldParent).length - 1).ToString(), true);
                }

                // --

                this.fTcdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fTcpDriver, this, fRefObject)
                    );
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fOldParent = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void setChangedFormat(
            )
        {
            try
            {
                this.fXmlNode.set_attrVal(FXmlTagDAT.A_Value, FXmlTagDAT.D_Value, FXmlTagDAT.D_Value);
                this.fXmlNode.set_attrVal(FXmlTagDAT.A_Length, FXmlTagDAT.D_Length, FXmlTagDAT.D_Length);
                // --
                this.fXmlNode.set_attrVal(FXmlTagDAT.A_Transformer, FXmlTagDAT.D_Transformer, FXmlTagDAT.D_Transformer);

                // --

                resetRelation();
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
                this.copyObject(FCbObjectFormat.Data, this.fXmlNode);
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

                // ***
                // Copy 시, Pattern(Fixed)과 Fixed Length(1) 초기화
                // ***
                fXmlNode.set_attrVal(FXmlTagDAT.A_Pattern, FXmlTagDAT.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));
                fXmlNode.set_attrVal(FXmlTagDAT.A_FixedLength, FXmlTagDAT.D_FixedLength, "1");

                // --

                resetFlowNode(fXmlNode);
                this.copyObject(FCbObjectFormat.Data, fXmlNode);
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

        public FData pasteSibling(
            )
        {
            FData fData = null;

            try
            {
                FTcpDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.Data);

                // --

                fData = (FData)this.pasteObject(FCbObjectFormat.Data);
                if (this.fParent.fObjectType == FObjectType.DataSet)
                {
                    return ((FDataSet)this.fParent).insertAfterChildData(fData, this);
                }
                return ((FData)this.fParent).insertAfterChildData(fData, this);
            }
            catch(Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fData = null;                    
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FData pasteChild(
            )
        {
            FData fData = null;
            
            try
            {
                FTcpDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.Data);

                // --

                fData = (FData)this.pasteObject(FCbObjectFormat.Data);
                return this.appendChildData(fData);                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fData = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void lockObject(
            )
        {
            try
            {
                if (this.locked)
                {
                    return;
                }

                // --

                // ***
                // Data에 대한 Lock 처리
                // ***
                this.fXmlNode.set_attrVal(FXmlTagDAT.A_Locked, FXmlTagDAT.D_Locked, FBoolean.True, true);

                // --

                // ***
                // Parent에 대한 Lock 처리
                // ***
                if (this.fParent.fObjectType == FObjectType.Data)
                {
                    ((FData)this.fParent).lockObject();
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

        internal void unlockObject(
            )
        {
            string xpath = string.Empty;

            try
            {
                if (!this.locked)
                {
                    return;
                }

                // --

                // ***
                // Lock이 설정된 자식 Data가 존재할 경우 Unlock 작업을 취소한다.
                // ***
                xpath = FXmlTagDAT.E_Data + "[@" + FXmlTagDAT.A_Locked + "='" + FBoolean.True + "']";
                if (this.fXmlNode.containsNode(xpath))
                {
                    return;
                }

                // ***
                // Data가 Judgement Expression에 사용되어 있을 경우 Unlock 작업을 취소한다.
                // ***
                xpath =
                    FXmlTagEQM.E_EquipmentModeling +
                    "/" + FXmlTagEQP.E_Equipment +
                    "/" + FXmlTagSNG.E_ScenarioGroup +
                    "/" + FXmlTagSNR.E_Scenario +
                    "/" + FXmlTagJDM.E_Judgement +
                    "/" + FXmlTagJCN.E_JudgementCondition +
                    "//" + FXmlTagJEP.E_JudgementExpression + "[@" + FXmlTagJEP.A_OperandId + "='" + this.uniqueIdToString + "' or @" + FXmlTagJEP.A_ValueId + "='" + this.uniqueIdToString + "']";
                // --
                if (this.fTcpDriver.fXmlNode.containsNode(xpath))
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagDAT.A_Locked, FXmlTagDAT.D_Locked, FBoolean.False, true);

                // --

                // ***
                // Parent에 대한 Unlock처리
                // ***
                if (this.fParent.fObjectType == FObjectType.Data)
                {
                    ((FData)this.fParent).unlockObject();
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

        //-----------------------------------------------------------------------------------------------------------------------

        public FDataCollection selectDataByName(
            string name
            )
        {
            const string xpath = FXmlTagDAT.E_Data + "[@" + FXmlTagDAT.A_Name + "='{0}']";

            try
            {
                return new FDataCollection(
                    this.fTcdCore,
                    this.fXmlNode.selectNodes(string.Format(xpath, name))
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

        //-----------------------------------------------------------------------------------------------------------------------

        public FData selectSingleDataByName(
            string name
            )
        {
            const string xpath = FXmlTagDAT.E_Data + "[@" + FXmlTagDAT.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FData(this.fTcdCore, fXmlNode);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //-----------------------------------------------------------------------------------------------------------------------

        public FDataCollection selectAllDataByName(
            string name
            )
        {
            const string xpath = ".//" + FXmlTagDAT.E_Data + "[@" + FXmlTagDAT.A_Name + "='{0}']";

            try
            {
                return new FDataCollection(
                    this.fTcdCore,
                    this.fXmlNode.selectNodes(string.Format(xpath, name))
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

        //-----------------------------------------------------------------------------------------------------------------------

        public FData selectSingleAllDataByName(
            string name
            )
        {
            const string xpath = ".//" + FXmlTagDAT.E_Data + "[@" + FXmlTagDAT.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FData(this.fTcdCore, fXmlNode);
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

        public FData selectSingleAllDataByIndex(
            params object[] args
            )
        {
            FXmlNode fXmlNode = null;
            int index = 0;

            try
            {
                if (args == null || args.Length == 0)
                {
                    return null;
                }

                // --

                fXmlNode = this.fXmlNode;
                // --
                foreach (object obj in args)
                {
                    index = (int)obj;
                    // --
                    if (index >= fXmlNode.fChildNodes.count)
                    {
                        return null;
                    }
                    // --
                    fXmlNode = fXmlNode.fChildNodes[index];
                }
                // --
                return new FData(this.fTcdCore, fXmlNode);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
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
                // 이 Data 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Data", "Modeling File"));
                }

                // ***
                // Data Conversion Set와 Data의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fDataConversionSet))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the Data Conversion Set and the Data", "same"));
                }

                // --

                fFormat = this.fFormat;
                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0006, fFormat.ToString() + " Format", "Data Conversion Set"));
                }

                // --

                oldDcsId = this.fXmlNode.get_attrVal(FXmlTagDAT.A_DataConversionSetID, FXmlTagDAT.D_DataConversionSetID);
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
                
                this.fXmlNode.set_attrVal(FXmlTagDAT.A_DataConversionSetExpression, FXmlTagDAT.D_DataConversionSetExpression, fDataConversionSet.expression, false);
                this.fXmlNode.set_attrVal(FXmlTagDAT.A_DataConversionSetName, FXmlTagDAT.D_DataConversionSetName, fDataConversionSet.name, false);
                this.fXmlNode.set_attrVal(FXmlTagDAT.A_DataConversionSetID, FXmlTagDAT.D_DataConversionSetID, newDcsId, true);
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
                foreach (FData fDat in this.fChildDataCollection)
                {
                    fDat.resetDataConversionSet(isModifyEvent);
                }

                // --

                fDcs = this.fDataConversionSet;
                if (fDcs == null)
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagDAT.A_DataConversionSetExpression, FXmlTagDAT.D_DataConversionSetExpression, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagDAT.A_DataConversionSetName, FXmlTagDAT.D_DataConversionSetName, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagDAT.A_DataConversionSetID, FXmlTagDAT.D_DataConversionSetID, string.Empty, isModifyEvent);
                // --
                fDcs.unlockObject();
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

        //------------------------------------------------------------------------------------------------------------------------

        internal void resetRelation(
            )
        {
            try
            {
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
                fXmlNode.set_attrVal(FXmlTagDAT.A_DataConversionSetExpression, FXmlTagDAT.D_DataConversionSetExpression, string.Empty);
                fXmlNode.set_attrVal(FXmlTagDAT.A_DataConversionSetName, FXmlTagDAT.D_DataConversionSetName, string.Empty);
                fXmlNode.set_attrVal(FXmlTagDAT.A_DataConversionSetID, FXmlTagDAT.D_DataConversionSetID, string.Empty);

                // --

                foreach (FXmlNode fXmlNodeDat in fXmlNode.selectNodes(FXmlTagDAT.E_Data))
                {
                    FData.resetFlowNode(fXmlNodeDat);
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

        // ***
        // 2017.03.22 by spike.lee
        // 객체 Clone 기능 추가
        // ***
        public FData clone(
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.clone(true);

                // --

                // ***
                // Copy 시, Pattern(Fixed)과 Fixed Length(1) 초기화
                // ***
                fXmlNode.set_attrVal(FXmlTagDAT.A_Pattern, FXmlTagDAT.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));
                fXmlNode.set_attrVal(FXmlTagDAT.A_FixedLength, FXmlTagDAT.D_FixedLength, "1");

                // --

                resetFlowNode(fXmlNode);
                FTcpDriverCommon.resetLocked(fXmlNode);
                return new FData(this.fTcdCore, fXmlNode);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
