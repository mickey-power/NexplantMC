/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FColumn.cs
--  Creator         : kitae
--  Create Date     : 2011.10.10
--  Description     : FAMate Core FaSecsDriver Column Class
--  History         : Created by kitae at 2011.10.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public class FColumn : FBaseObject<FColumn>, FIObject
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --

        #region Class Construction and Destruction

        public FColumn(
            FSecsDriver fsecsDriver
            )
            : base(fsecsDriver.fScdCore,FSecsDriverCommon.createXmlNodeCOL(fsecsDriver.fScdCore.fXmlDoc))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FColumn(
            FScdCore fScdCore,
            FXmlNode fXmlNode
            )
            : base(fScdCore, fXmlNode)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FColumn(
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

        //-----------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FObjectType fObjectType
        {
            get
            {
                try
                {
                    return FObjectType.Column;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.Column;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
      
        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagCOL.A_UniqueId, FXmlTagCOL.D_UniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagCOL.A_Name, FXmlTagCOL.D_Name);
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

                    this.fXmlNode.set_attrVal(FXmlTagCOL.A_Name, FXmlTagCOL.D_Name, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagCOL.A_Description, FXmlTagCOL.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagCOL.A_Description, FXmlTagCOL.D_Description, value, true);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagCOL.A_FontColor, FXmlTagCOL.D_FontColor));
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
                    this.fXmlNode.set_attrVal(FXmlTagCOL.A_FontColor, FXmlTagCOL.D_FontColor, value.Name, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagCOL.A_FontBold, FXmlTagCOL.D_FontBold));
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
                    this.fXmlNode.set_attrVal(FXmlTagCOL.A_FontBold, FXmlTagCOL.D_FontBold, FBoolean.fromBool(value), true);
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

        public bool primaryKey
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagCOL.A_PrimaryKey, FXmlTagCOL.D_PrimaryKey));
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
                    this.fXmlNode.set_attrVal(FXmlTagCOL.A_PrimaryKey, FXmlTagCOL.D_PrimaryKey, FBoolean.fromBool(value), true);
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

        public bool duplicationKey
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagCOL.A_DuplicationKey, FXmlTagCOL.D_DuplicationKey));
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
                    this.fXmlNode.set_attrVal(FXmlTagCOL.A_DuplicationKey, FXmlTagCOL.D_DuplicationKey, FBoolean.fromBool(value), true);
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
                    return FEnumConverter.toPattern(this.fXmlNode.get_attrVal(FXmlTagCOL.A_Pattern, FXmlTagCOL.D_Pattern));
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
                    // Parent가 없는 Column의 Pattern은 변경할 수 없다.
                    // ***
                    if (this.fParent == null)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, "Column without the Parent", "Pattern"));
                    }

                    // --

                    if (value == FPattern.Fixed)
                    {
                        // ***
                        // Previous와 Next 형제가 Variable Column이 아니어야 한다.
                        // ***
                        if (
                            (this.fPreviousSibling != null && this.fPreviousSibling.fPattern == FPattern.Variable) &&
                            (this.fNextSibling != null && this.fNextSibling.fPattern == FPattern.Variable)
                            )
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0010, "Pattern of the Previous Column and the Next Column", "Variable"));
                        }
                    }
                    else if (value == FPattern.Variable)
                    {
                        if (
                            (this.fParent.fObjectType == FObjectType.Repository && ((FRepository)this.fParent).hasVariableChild) ||
                            (this.fParent.fObjectType == FObjectType.Column && ((FColumn)this.fParent).hasVariableChild)
                            )
                        {
                            // ***
                            // 형제 Variable Column과 연속적으로 이어져야 한다.
                            // ***
                            if (this.fPreviousSibling == null && this.fNextSibling.fPattern != FPattern.Variable)
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0011, "Pattern of the Previous Column and the Next Column", "Variable"));
                            }
                            else if (this.fNextSibling == null && this.fPreviousSibling.fPattern != FPattern.Variable)
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0011, "Pattern of the Previous Column and the Next Column", "Variable"));
                            }
                            else if (
                                this.fPreviousSibling != null &&
                                this.fNextSibling != null &&
                                (this.fPreviousSibling.fPattern != FPattern.Variable && this.fNextSibling.fPattern != FPattern.Variable)
                                )
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0011, "Pattern of the Previous Column and the Next Column", "Variable"));
                            }                            
                        }
                    }

                    // --

                    // ***
                    // Pattern 변경시, Fixed Length와 Scan Mode는 초기화
                    // ***
                    this.fXmlNode.set_attrVal(FXmlTagCOL.A_FixedLength, FXmlTagCOL.D_FixedLength, "1");
                    this.fXmlNode.set_attrVal(FXmlTagCOL.A_ScanMode, FXmlTagCOL.D_ScanMode, FXmlTagCOL.D_ScanMode);
                    this.fXmlNode.set_attrVal(FXmlTagCOL.A_Pattern, FXmlTagCOL.A_Pattern, FEnumConverter.fromPattern(value), true);
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
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagCOL.A_FixedLength, FXmlTagCOL.D_FixedLength));
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
                    // Parent가 없는 Column의 Fixed Length는 변경할 수 없다.
                    // ***
                    if (this.fParent == null)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, "Column without the Parent", "Fixed Length"));
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

                    this.fXmlNode.set_attrVal(FXmlTagCOL.A_FixedLength, FXmlTagCOL.D_FixedLength, value.ToString(), true);
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
                    return FEnumConverter.toFormat(this.fXmlNode.get_attrVal(FXmlTagCOL.A_Format, FXmlTagCOL.D_Format));
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
                    // 자식이 존재하는 List Format의 Column은 Format을 변경할 수 없다.
                    // ***
                    if (this.hasChild)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0013, "Object's Child"));
                    }

                    // ***
                    // 부모가 Column이고 부모의 Format이 AsciiList인 경우 Format를 변경할 수 없다.
                    // ***
                    if (this.fParent != null && this.fParent.fObjectType == FObjectType.Column && ((FColumn)this.fParent).fFormat == FFormat.AsciiList)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0010, "Parent's Format", "AsciiList"));
                    }

                    // --

                    setChangedFormat();
                    this.fXmlNode.set_attrVal(FXmlTagCOL.A_Format, FXmlTagCOL.D_Format, FEnumConverter.fromFormat(value), true);
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
                    return FEnumConverter.toDataScanMode(this.fXmlNode.get_attrVal(FXmlTagCOL.A_ScanMode, FXmlTagCOL.D_ScanMode));
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

                    fXmlNode.set_attrVal(FXmlTagCOL.A_ScanMode, FXmlTagCOL.D_ScanMode, FEnumConverter.fromDataScanMode(value), true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagCOL.A_Value, FXmlTagCOL.D_Value);
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
                    // List, Unknown, Raw Format은 Value를 설정할 수 없다.
                    // ***
                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, fFormat.ToString() + " Format", "Value"));
                    }

                    // --

                    val = FValueConverter.fromStringValue(fFormat, value, out length);
                    // --
                    this.fXmlNode.set_attrVal(FXmlTagCOL.A_Length, FXmlTagCOL.D_Length, length.ToString());
                    this.fXmlNode.set_attrVal(FXmlTagCOL.A_Value, FXmlTagCOL.D_Value, val, true);
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
                    // List, Unknown, Raw Format은 Value를 설정할 수 없다.
                    // ***

                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, fFormat.ToString() + " Format", "Value"));
                    }

                    // -- 

                    val = FValueConverter.fromStringArrayValue(fFormat, value, out length);
                    // --
                    this.fXmlNode.set_attrVal(FXmlTagCOL.A_Length, FXmlTagCOL.D_Length, length.ToString());
                    this.fXmlNode.set_attrVal(FXmlTagCOL.A_Value, FXmlTagCOL.D_Value, val, true);
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
                    this.fXmlNode.set_attrVal(FXmlTagCOL.A_Length, FXmlTagCOL.D_Length, length.ToString());
                    this.fXmlNode.set_attrVal(FXmlTagCOL.A_Value, FXmlTagCOL.D_Value, val, true);
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
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagCOL.A_Length, FXmlTagCOL.D_Length));
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
                        this.fXmlNode.get_attrVal(FXmlTagCOL.A_Transformer, FXmlTagCOL.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagCOL.A_DataConversionSetExpression, FXmlTagCOL.D_DataConversionSetExpression),
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
                        this.fXmlNode.get_attrVal(FXmlTagCOL.A_Transformer, FXmlTagCOL.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagCOL.A_DataConversionSetExpression, FXmlTagCOL.D_DataConversionSetExpression)
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
                        this.fXmlNode.get_attrVal(FXmlTagCOL.A_Transformer, FXmlTagCOL.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagCOL.A_DataConversionSetExpression, FXmlTagCOL.D_DataConversionSetExpression),
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
                        this.fXmlNode.get_attrVal(FXmlTagCOL.A_Transformer, FXmlTagCOL.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagCOL.A_DataConversionSetExpression, FXmlTagCOL.D_DataConversionSetExpression)
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
                        this.fXmlNode.get_attrVal(FXmlTagCOL.A_Transformer, FXmlTagCOL.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagCOL.A_DataConversionSetExpression, FXmlTagCOL.D_DataConversionSetExpression),
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
                        fFormat == FFormat.Char ||
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

        public FColumnValueTransformer fValueTransformer
        {
            get
            {
                try
                {
                    return new FColumnValueTransformer(this);
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
                    id = this.fXmlNode.get_attrVal(FXmlTagCOL.A_DataConversionSetID, FXmlTagCOL.D_DataConversionSetID);
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
                    return this.fXmlNode.get_attrVal(FXmlTagCOL.A_DataConversionSetName, FXmlTagCOL.D_DataConversionSetName);
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
                    this.fXmlNode.set_attrVal(FXmlTagCOL.A_DataConversionSetName, FXmlTagCOL.D_DataConversionSetName, value, false);
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
                    return this.fXmlNode.get_attrVal(FXmlTagCOL.A_DataConversionSetExpression, FXmlTagCOL.D_DataConversionSetExpression);
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
                    this.fXmlNode.set_attrVal(FXmlTagCOL.A_DataConversionSetExpression, FXmlTagCOL.D_DataConversionSetExpression, value, false);
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
                    return this.fXmlNode.get_attrVal(FXmlTagCOL.A_UserTag1, FXmlTagCOL.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagCOL.A_UserTag1, FXmlTagCOL.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagCOL.A_UserTag2, FXmlTagCOL.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagCOL.A_UserTag2, FXmlTagCOL.D_UserTag2, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagCOL.A_UserTag3, FXmlTagCOL.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagCOL.A_UserTag3, FXmlTagCOL.D_UserTag3, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagCOL.A_UserTag4, FXmlTagCOL.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagCOL.A_UserTag4, FXmlTagCOL.D_UserTag4, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagCOL.A_UserTag5, FXmlTagCOL.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagCOL.A_UserTag5, FXmlTagCOL.D_UserTag5, value, true);
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

        public FColumnCollection fChildColumnCollection
        {
            get
            {
                try
                {
                    return new FColumnCollection(this.fScdCore, this.fXmlNode.selectNodes(FXmlTagCOL.E_Column));
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
                try
                {
                    return new FObjectCollection(this.fScdCore, this.fXmlNode.selectNodes("NULL"));
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
                try
                {
                    return new FObjectCollection(this.fScdCore, this.fXmlNode.selectNodes("NULL"));
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

                    if (this.fXmlNode.fParentNode.name == FXmlTagRPS.E_Repository)
                    {
                        return new FRepository(this.fScdCore, this.fXmlNode.fParentNode);
                    }
                    return new FColumn(this.fScdCore, this.fXmlNode.fParentNode);
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

        public FColumn fPreviousSibling
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

                    return new FColumn(this.fScdCore, this.fXmlNode.fPreviousSibling);
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

        public FColumn fNextSibling
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

                    return new FColumn(this.fScdCore, this.fXmlNode.fNextSibling);
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
                    return this.fXmlNode.containsNode(FXmlTagCOL.E_Column);
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
                    xpath = FXmlTagCOL.E_Column + "[@" + FXmlTagCOL.A_Pattern + "='" + FEnumConverter.fromPattern(FPattern.Fixed) + "']";
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
                    xpath = FXmlTagCOL.E_Column + "[@" + FXmlTagCOL.A_Pattern + "='" + FEnumConverter.fromPattern(FPattern.Variable) + "']";
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

        //-----------------------------------------------------------------------------------------------------------------------

        public bool hasValueTransformer
        {
            get
            {
                try
                {
                    if (this.fXmlNode.get_attrVal(FXmlTagCOL.A_Transformer, FXmlTagCOL.D_Transformer) == string.Empty)
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
                    if (this.fXmlNode.get_attrVal(FXmlTagCOL.A_DataConversionSetID, FXmlTagCOL.D_DataConversionSetID) == string.Empty)
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

        //-----------------------------------------------------------------------------------------------------------------------

        public bool canAppendChild
        {
            get
            {
                try
                {
                    // ***
                    // Column 이 List인 경우에만 Child Item을 가질 수 있다.(SECS Protocol)
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

        //-----------------------------------------------------------------------------------------------------------------------

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

        //-----------------------------------------------------------------------------------------------------------------------

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

        //-----------------------------------------------------------------------------------------------------------------------

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

        //-----------------------------------------------------------------------------------------------------------------------

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

        //-----------------------------------------------------------------------------------------------------------------------

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

        //-----------------------------------------------------------------------------------------------------------------------

        public FRepository fAncestorRepository
        {
            get
            {
                try
                {
                    return this.getAncestorRepository();
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

        //-----------------------------------------------------------------------------------------------------------------------

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

        //-----------------------------------------------------------------------------------------------------------------------

        public bool canPasteSibling
        {
            get
            {
                try
                {
                    if (
                        this.fXmlNode.fParentNode == null ||
                        !FClipboard.containsData(FCbObjectFormat.Column)
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

        //-----------------------------------------------------------------------------------------------------------------------

        public bool canPasteChild
        {
            get
            {
                try
                {
                    if (!FClipboard.containsData(FCbObjectFormat.Column))
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
            StringBuilder info = null;
            FPattern fPattern;
            FFormat fFormat;
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

                    if (this.primaryKey)
                    {
                        info.Append("[pk.] ");
                    }

                    if (this.duplicationKey)
                    {
                        info.Append("[dk.] ");
                    }

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

                    // ***
                    // 2017.03.27 by spike.lee Scan Mode Attribute 추가
                    // ***
                    if (this.fScanMode == FDataScanMode.Global)
                    {
                        info.Append("[g.]");
                    }

                    // --

                    info.Append(FEnumConverter.fromFormat(fFormat));
                    length = this.originalLength;
                    // --
                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                    {
                        info.Append("[" + length.ToString() + "] " + this.name);
                    }
                    else if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2 || fFormat == FFormat.Char)
                    {
                        value = FValueConverter.toDataConversionedEncodingValue(
                            fFormat,
                            this.originalStringValue,
                            this.fXmlNode.get_attrVal(FXmlTagCOL.A_Transformer, FXmlTagCOL.D_Transformer),
                            this.fXmlNode.get_attrVal(FXmlTagCOL.A_DataConversionSetExpression, FXmlTagCOL.D_DataConversionSetExpression),
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
                            this.fXmlNode.get_attrVal(FXmlTagCOL.A_Transformer, FXmlTagCOL.D_Transformer),
                            this.fXmlNode.get_attrVal(FXmlTagCOL.A_DataConversionSetExpression, FXmlTagCOL.D_DataConversionSetExpression),
                            ref length
                            );

                        // --
                        
                        info.Append("[" + length.ToString() + "] " + this.name + "=\"");
                        // --
                        if (info.Length > 1000)
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
                }

                // --
                                
                if (this.description != string.Empty)
                {
                    info.Append(" Desc=[" + this.description + "]");
                }
                
                // --
                
                return info.ToString();
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

        public FColumn appendChildColumn(
            FColumn fNewChild
            )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                // ***
                // Format이 List인 Data만이 Child를 가질 수 있다.
                // ***
                if (this.fFormat != FFormat.List && this.fFormat != FFormat.AsciiList)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Column's Format", "List or the AsciiList"));
                }

                // ***
                // Format이 AsciiList인 경우 Ascii Format의 Child만을 가질 수 있다.
                // ***
                if (this.fFormat == FFormat.AsciiList && fNewChild.fFormat != FFormat.Ascii)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Format of New Child", "Ascii"));
                }

                // --

                fNewChild.replace(this.fScdCore, this.fXmlNode.appendChild(fNewChild.fXmlNode));

                // --

                // ***
                // 현재 Column의 Length 1 증가
                // ***
                this.fXmlNode.set_attrVal(FXmlTagCOL.A_Length, FXmlTagCOL.D_Length, (this.length + 1).ToString());

                // --
                
                if (this.isModelingObject)
                {
                    FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fScdCore.fEventPusher.pushEvent(new FEventArgsBase[]{
                        new FObjectEventArgs(FEventId.ObjectAppendCompleted, this.fSecsDriver, this, fNewChild),
                        new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fSecsDriver, this.fParent, this)
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

        public FColumn insertBeforeChildData(
            FColumn fNewChild,
            FColumn fRefChild
            )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);
                // --
                if (this.fFormat != FFormat.List && this.fFormat != FFormat.AsciiList)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Column's Format", "List or the AsciiList"));
                }

                // ***
                // Format이 AsciiList인 경우 Ascii Format의 Child 만을 가질 수 있다.
                // ***
                if (this.fFormat == FFormat.AsciiList && fNewChild.fFormat != FFormat.Ascii)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Format of New Child", "Ascii"));
                }

                // --

                fNewChild.replace(this.fScdCore, this.fXmlNode.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));

                // --

                // ***
                // 현재 Column의 Length 1 증가
                // ***
                this.fXmlNode.set_attrVal(FXmlTagCOL.A_Length, FXmlTagCOL.D_Length,(this.length + 1).ToString());

                // --

                // ***
                // 추가된 Child의 Previous Column과 Next Column의 Pattern이 Variable일 경우,
                // 추가된 Child의 Pattern를 Variable로 설정한다.
                // ***                
                if (
                    (fNewChild.fPreviousSibling != null && fNewChild.fPreviousSibling.fPattern == FPattern.Variable) &&
                    (fNewChild.fNextSibling != null && fNewChild.fNextSibling.fPattern == FPattern.Variable)
                    )
                {
                    fNewChild.fXmlNode.set_attrVal(FXmlTagCOL.A_Pattern, FXmlTagCOL.D_Pattern, FEnumConverter.fromPattern(FPattern.Variable));
                }

                // --

                if (this.isModelingObject)
                {
                    FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fScdCore.fEventPusher.pushEvent(new FEventArgsBase[]{
                        new FObjectEventArgs(FEventId.ObjectInsertBeforeCompleted, this.fSecsDriver, this, fNewChild),
                        new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fSecsDriver, this.fParent, this)
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

        public FColumn insertAfterChildColumn(
            FColumn fNewChild,
            FColumn fRefChild
            )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // --

                if (this.fFormat != FFormat.List && this.fFormat != FFormat.AsciiList)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Column's Format", "List or The AsciiList"));
                }

                // ***
                // Format이 AsciiList인 경우 Ascii Format의 Child 만을 가질 수 있다.
                // ***
                if (this.fFormat == FFormat.AsciiList && fNewChild.fFormat != FFormat.Ascii)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Format of New Child", "Ascii"));
                }

                // --

                fNewChild.replace(this.fScdCore, this.fXmlNode.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));

                // --

                // ***
                // 현재 Column의 Length 1 증가
                // ***
                this.fXmlNode.set_attrVal(FXmlTagCOL.A_Length, FXmlTagCOL.D_Length, (this.length + 1).ToString());

                // --
                
                // ***
                // 추가된 Child의 Previous Column과 Next Column의 Pattern이 Variable일 경우,
                // 추가된 Child의 Pattern를 Variable로 설정한다.
                // ***                
                if (
                    (fNewChild.fPreviousSibling != null && fNewChild.fPreviousSibling.fPattern == FPattern.Variable) &&
                    (fNewChild.fNextSibling != null && fNewChild.fNextSibling.fPattern == FPattern.Variable)
                    )
                {
                    fNewChild.fXmlNode.set_attrVal(FXmlTagCOL.A_Pattern, FXmlTagCOL.D_Pattern, FEnumConverter.fromPattern(FPattern.Variable));
                }

                // --

                if (this.isModelingObject)
                {
                    FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fScdCore.fEventPusher.pushEvent(new FEventArgsBase[]{
                        new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this.fSecsDriver,this, fNewChild),
                        new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fSecsDriver, this.fParent, this)
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
                FSecsDriverCommon.validateRemoveChildObject(this.fXmlNode.fParentNode, this.fXmlNode);

                // --

                // ***
                // 2013.08.12 by spike.lee
                // DataConversionSet Reset Add
                // ***
                resetRelation();

                // --

                isModelingObject = this.isModelingObject;
                fParent = this.fParent;
                if (fParent.fObjectType == FObjectType.Repository)
                {
                    this.replace(this.fScdCore, ((FRepository)fParent).fXmlNode.removeChild(this.fXmlNode));
                }
                else
                {
                    this.replace(this.fScdCore, ((FColumn)fParent).fXmlNode.removeChild(this.fXmlNode));
                    // --
                    length = int.Parse(((FColumn)fParent).fXmlNode.get_attrVal(FXmlTagCOL.A_Length, FXmlTagCOL.D_Length)) - 1;
                    ((FColumn)fParent).fXmlNode.set_attrVal(FXmlTagCOL.A_Length, FXmlTagCOL.D_Length, length.ToString());
                }

                // --

                // ***
                // Remove 시, Pattern(Fixed)과 Fixed Length(1) 초기화
                // ***
                this.fXmlNode.set_attrVal(FXmlTagCOL.A_Pattern, FXmlTagCOL.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));
                this.fXmlNode.set_attrVal(FXmlTagCOL.A_FixedLength, FXmlTagCOL.D_FixedLength, "1");

                // --

                if (isModelingObject)
                {
                    if (fParent.fObjectType == FObjectType.Repository)
                    {
                        this.fScdCore.fEventPusher.pushEvent(
                            new FObjectEventArgs(FEventId.ObjectRemoveCompleted, this.fSecsDriver, fParent, this)
                            );
                    }
                    else
                    {
                        this.fScdCore.fEventPusher.pushEvent(new FEventArgsBase[]{
                            new FObjectEventArgs(FEventId.ObjectRemoveCompleted, this.fSecsDriver, fParent, this),
                            new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fSecsDriver, ((FColumn)fParent).fParent, fParent)
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

        public FColumn removeChildColumn(
            FColumn fChild
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

        public void removeChildColumn(
            FColumn[] fChilds
            )
        {
            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                foreach (FColumn fCol in fChilds)
                {
                    FSecsDriverCommon.validateRemoveChildObject(this.fXmlNode, fCol.fXmlNode);                    
                }

                // --

                foreach (FColumn fCol in fChilds)
                {
                    fCol.remove();
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

        public void removeAllChildColumn(
            )
        {
            FColumnCollection fColumnCollection = null;
            try
            {
                fColumnCollection = this.fChildColumnCollection;
                if (fColumnCollection == 0)
                {
                    return;
                }

                // --

                foreach (FColumn fCol in fColumnCollection)
                {
                    fCol.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fColumnCollection != null)
                {
                    fColumnCollection.Dispose();
                    fColumnCollection = null;
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
                FSecsDriverCommon.validateMoveUpObject(this.fXmlNode);
                // --
                if (!this.canMoveUp)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0021, "Object"));
                }

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fScdCore, this.fXmlNode.moveUp());

                // --

                if (isModelingObject)
                {
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveUpCompleted, this.fSecsDriver, fParent, this)
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
                FSecsDriverCommon.validateMoveDownObject(this.fXmlNode);
                // -- 
                if (!this.canMoveDown)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0022, "Object"));
                }

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fScdCore, this.fXmlNode.moveDown());

                // --

                if (isModelingObject)
                {
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveDownCompleted, this.fSecsDriver, fParent, this)
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
            FColumn fRefObject
            )
        {
            FIObject fOldParent = null;

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

                if (!this.fAncestorRepository.Equals(fRefObject.fAncestorRepository))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Ancestor Repository", "same"));
                }

                if (this.containsObject(fRefObject))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0060, "Object", "Child"));
                }

                if (
                    (fRefObject.fParent.fObjectType == FObjectType.Repository && ((FRepository)fRefObject.fParent).hasVariableChild) ||
                    (fRefObject.fParent.fObjectType == FObjectType.Column && ((FColumn)fRefObject.fParent).hasVariableChild)
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
                                FDebug.throwFException(string.Format(FConstants.err_m_0011, "Pattern of the Previous Column and the Next Column", "Variable"));
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
                            FDebug.throwFException(string.Format(FConstants.err_m_0010, "Pattern of the Previous Column and the Next Column", "Variable"));
                        }
                    }
                }

                // --

                fOldParent = this.fParent;

                // --                

                this.replace(this.fScdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fScdCore, fRefObject.fXmlNode.fParentNode.insertAfter(this.fXmlNode, fRefObject.fXmlNode));

                // --

                if (!this.fParent.Equals(fOldParent))
                {
                    if (fOldParent.fObjectType == FObjectType.Column)
                    {
                        ((FColumn)fOldParent).fXmlNode.set_attrVal(FXmlTagCOL.A_Length, FXmlTagCOL.D_Length, (((FColumn)fOldParent).length - 1).ToString(), true);
                    }
                    // --
                    if (this.fParent.fObjectType == FObjectType.Column)
                    {
                        ((FColumn)this.fParent).fXmlNode.set_attrVal(FXmlTagCOL.A_Length, FXmlTagCOL.D_Length, (((FColumn)this.fParent).length + 1).ToString(), true);
                    }
                }

                // --

                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fSecsDriver, this, fRefObject)
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
            FRepository fRefObject
            )
        {
            FIObject fOldParent = null;

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

                if (!this.fAncestorRepository.Equals(fRefObject))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Column", "child"));
                }

                if (fRefObject.fChildColumnCollection.count > 0)
                {
                    if (this.Equals(fRefObject.fChildColumnCollection[fRefObject.fChildColumnCollection.count - 1]))
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0060, "Object", "same localtion"));
                    }
                }  

                if (fRefObject.hasVariableChild)
                {
                    if (this.fPattern == FPattern.Variable)
                    {
                        if (fRefObject.fChildColumnCollection[fRefObject.fChildColumnCollection.count - 1].fPattern != FPattern.Variable)
                        {
                            if (
                                !this.fParent.Equals(fRefObject) ||
                                (this.fPreviousSibling != null && this.fPreviousSibling.fPattern == FPattern.Variable) ||
                                (this.fNextSibling != null && this.fNextSibling.fPattern == FPattern.Variable)
                                )
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0011, "Pattern of the Previous Column and the Next Column", "Variable"));
                            }
                        }
                    }
                }

                // --      

                fOldParent = this.fParent;

                // --

                this.replace(this.fScdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fScdCore, fRefObject.fXmlNode.appendChild(this.fXmlNode));

                // --

                if (!this.fParent.Equals(fOldParent))
                {
                    ((FColumn)fOldParent).fXmlNode.set_attrVal(FXmlTagCOL.A_Length, FXmlTagCOL.D_Length, (((FColumn)fOldParent).length - 1).ToString(), true);
                }

                // --

                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fSecsDriver, this, fRefObject)
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
                this.fXmlNode.set_attrVal(FXmlTagCOL.A_Value, FXmlTagCOL.D_Value);
                this.fXmlNode.set_attrVal(FXmlTagCOL.A_Length, FXmlTagCOL.D_Length, FXmlTagCOL.D_Length);
                // --
                this.fXmlNode.set_attrVal(FXmlTagCOL.A_Transformer, FXmlTagCOL.D_Transformer, FXmlTagCOL.D_Transformer);

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
                FSecsDriverCommon.validateCutObject(this.fXmlNode);

                // --

                this.remove();

                // --

                resetFlowNode(this.fXmlNode);
                this.copyObject(FCbObjectFormat.Column, this.fXmlNode);
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
                fXmlNode.set_attrVal(FXmlTagCOL.A_Pattern, FXmlTagCOL.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));
                fXmlNode.set_attrVal(FXmlTagCOL.A_FixedLength, FXmlTagCOL.D_FixedLength, "1");

                // --

                resetFlowNode(fXmlNode);
                this.copyObject(FCbObjectFormat.Column, fXmlNode);
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

        public FColumn pasteSibling(
            )
        {
            FColumn fColumn = null;

            try
            {
                FSecsDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.Column);

                // --

                fColumn = (FColumn)this.pasteObject(FCbObjectFormat.Column);
                if (this.fParent.fObjectType == FObjectType.Repository)
                {
                    return ((FRepository)this.fParent).insertAfterChildColumn(fColumn, this);
                }
                return ((FColumn)this.fParent).insertAfterChildColumn(fColumn, this);
            }
            catch(Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fColumn = null;                    
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FColumn pasteChild(
            )
        {
            FColumn fColumn = null;
            
            try
            {
                FSecsDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.Column);

                // --

                fColumn = (FColumn)this.pasteObject(FCbObjectFormat.Column);
                return this.appendChildColumn(fColumn);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fColumn = null;
            }
            return null;
        }

        //-----------------------------------------------------------------------------------------------------------------------

        public FColumnCollection selectColumnByName(
            string name
            )
        {
            const string xpath = FXmlTagCOL.E_Column + "[@" + FXmlTagCOL.A_Name + "='{0}']";

            try
            {
                return new FColumnCollection(
                    this.fScdCore,
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

        public FColumn selectSingleColumnByName(
            string name
            )
        {
            const string xpath = FXmlTagCOL.E_Column + "[@" + FXmlTagCOL.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FColumn(this.fScdCore, fXmlNode);
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

        public FColumnCollection selectAllColumnByName(
            string name
            )
        {
            const string xpath = ".//" + FXmlTagCOL.E_Column + "[@" + FXmlTagCOL.A_Name + "='{0}']";

            try
            {
                return new FColumnCollection(
                    this.fScdCore,
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

        public FColumn selectSingleAllColumnByName(
            string name
            )
        {
            const string xpath = ".//" + FXmlTagCOL.E_Column + "[@" + FXmlTagCOL.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FColumn(this.fScdCore, fXmlNode);
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

        public FColumn selectSingleAllColumnByIndex(
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
                return new FColumn(this.fScdCore, fXmlNode);
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
                // Data Set 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fDataConversionSet.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Data Conversion Set", "Modeling File"));
                }

                // ***
                // 이 Mapper 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Column", "Modeling File"));
                }

                // ***
                // Data Conversion Set와 Column의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fDataConversionSet))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the Data Conversion Set and the Column", "same"));
                }

                // --

                fFormat = this.fFormat;
                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0006, fFormat.ToString() + " Format", "Data Conversion Set"));
                }

                // --

                oldDcsId = this.fXmlNode.get_attrVal(FXmlTagCOL.A_DataConversionSetID, FXmlTagCOL.D_DataConversionSetID);
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
                
                this.fXmlNode.set_attrVal(FXmlTagCOL.A_DataConversionSetExpression, FXmlTagCOL.D_DataConversionSetExpression, fDataConversionSet.expression, false);
                this.fXmlNode.set_attrVal(FXmlTagCOL.A_DataConversionSetName, FXmlTagCOL.D_DataConversionSetName, fDataConversionSet.name, false);
                this.fXmlNode.set_attrVal(FXmlTagCOL.A_DataConversionSetID, FXmlTagCOL.D_DataConversionSetID, newDcsId, true);
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
                foreach (FColumn fCol in this.fChildColumnCollection)
                {
                    fCol.resetDataConversionSet(isModifyEvent);
                }

                // --
                
                fDcs = this.fDataConversionSet;
                if (fDcs == null)
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagCOL.A_DataConversionSetExpression, FXmlTagCOL.D_DataConversionSetExpression, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagCOL.A_DataConversionSetName, FXmlTagCOL.D_DataConversionSetName, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagCOL.A_DataConversionSetID, FXmlTagCOL.D_DataConversionSetID, string.Empty, isModifyEvent);
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
                fXmlNode.set_attrVal(FXmlTagCOL.A_DataConversionSetExpression, FXmlTagCOL.D_DataConversionSetExpression, string.Empty);
                fXmlNode.set_attrVal(FXmlTagCOL.A_DataConversionSetName, FXmlTagCOL.D_DataConversionSetName, string.Empty);
                fXmlNode.set_attrVal(FXmlTagCOL.A_DataConversionSetID, FXmlTagCOL.D_DataConversionSetID, string.Empty);

                // --

                foreach (FXmlNode fXmlNodeCol in fXmlNode.selectNodes(FXmlTagCOL.E_Column))
                {
                    FColumn.resetFlowNode(fXmlNodeCol);
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
        public FColumn clone(
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
                fXmlNode.set_attrVal(FXmlTagCOL.A_Pattern, FXmlTagCOL.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));
                fXmlNode.set_attrVal(FXmlTagCOL.A_FixedLength, FXmlTagCOL.D_FixedLength, "1");

                // --

                resetFlowNode(fXmlNode);
                FSecsDriverCommon.resetLocked(fXmlNode);
                return new FColumn(this.fScdCore, fXmlNode);
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
