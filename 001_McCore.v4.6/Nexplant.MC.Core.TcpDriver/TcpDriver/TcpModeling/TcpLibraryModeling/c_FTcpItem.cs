/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTcpItem.cs
--  Creator         : spike.lee
--  Create Date     : 2016.04.12
--  Description     : FAMate Core FaTcpDriver TCP Item Class 
--  History         : Created by Jeff.Kim at 2016.04.12
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    public class FTcpItem : FBaseObject<FTcpItem>, FIObject, FITcpOperand
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Contruction and Destruction

        public FTcpItem(
            FTcpDriver fTcpDriver
            )
            : base(fTcpDriver.fTcdCore, FTcpDriverCommon.createXmlNodeTIT(fTcpDriver.fTcdCore.fXmlDoc))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpItem(
            FTcpDriver fTcpDriver,
            string name,
            FFormat fForamt,
            string stringValue
            )
            : base(FTcpDriverCommon.createXmlNodeTIT(fTcpDriver.fTcdCore.fXmlDoc, name, fForamt, stringValue))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FTcpItem(
            FTcdCore fTcdCore,
            FXmlNode fXmlNode
            )
            : base(fTcdCore, fXmlNode)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FTcpItem(
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
                    return FObjectType.TcpItem;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.TcpItem;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpOperandType fTcpOperandType
        {
            get
            {
                try
                {
                    return FTcpOperandType.TcpItem;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FTcpOperandType.TcpItem;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTIT.A_UniqueId, FXmlTagTIT.D_UniqueId);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagTIT.A_Locked, FXmlTagTIT.D_Locked));
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
                    return this.fXmlNode.get_attrVal(FXmlTagTIT.A_Name, FXmlTagTIT.D_Name);
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

                    this.fXmlNode.set_attrVal(FXmlTagTIT.A_Name, FXmlTagTIT.D_Name, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagTIT.A_Description, FXmlTagTIT.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagTIT.A_Description, FXmlTagTIT.D_Description, value, true);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagTIT.A_FontColor, FXmlTagTIT.D_FontColor));
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
                    this.fXmlNode.set_attrVal(FXmlTagTIT.A_FontColor, FXmlTagTIT.D_FontColor, value.Name, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagTIT.A_FontBold, FXmlTagTIT.D_FontBold));
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
                    this.fXmlNode.set_attrVal(FXmlTagTIT.A_FontBold, FXmlTagTIT.D_FontBold, FBoolean.fromBool(value), true);
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
                    return FEnumConverter.toPattern(this.fXmlNode.get_attrVal(FXmlTagTIT.A_Pattern, FXmlTagTIT.D_Pattern));
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
                    // Parent가 없는 TCP Item의 Pattern은 변경할 수 없다.
                    // ***
                    if (this.fParent == null)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, "TCP Item without the Parent", "Pattern"));
                    }

                    // --

                    if (value == FPattern.Fixed)
                    {
                        // ***
                        // Previous와 Next 형제가 Variable TCP Item이 아니어야 한다.
                        // ***                        
                        if (
                            (this.fPreviousSibling != null && this.fPreviousSibling.fPattern == FPattern.Variable) &&
                            (this.fNextSibling != null && this.fNextSibling.fPattern == FPattern.Variable)
                            )
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0010, "Pattern of the Previous TCP Item and the Next TCP Item", "Variable"));
                        }
                    }
                    else if (value == FPattern.Variable)
                    {
                        // ***
                        // 형제 Variable TCP Item과 연속적으로 이어져야 한다.                        
                        // ***
                        if (
                            (this.fParent.fObjectType == FObjectType.TcpMessage && ((FTcpMessage)this.fParent).hasVariableChild) ||
                            (this.fParent.fObjectType == FObjectType.TcpItem && ((FTcpItem)this.fParent).hasVariableChild)
                            )
                        {
                            if (this.fPreviousSibling == null && this.fNextSibling.fPattern != FPattern.Variable)
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0011, "Pattern of the Previous TCP Item and the Next TCP Item", "Variable"));
                            }
                            else if (this.fNextSibling == null && this.fPreviousSibling.fPattern != FPattern.Variable)
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0011, "Pattern of the Previous TCP Item and the Next TCP Item", "Variable"));
                            }
                            else if (this.fPreviousSibling.fPattern != FPattern.Variable && this.fNextSibling.fPattern != FPattern.Variable)
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0011, "Pattern of the Previous TCP Item and the Next TCP Item", "Variable"));
                            }
                        }
                    }

                    // --

                    // ***
                    // Pattern 변경 시, Fixed Length와 Scan Mode 초기화
                    // ***
                    this.fXmlNode.set_attrVal(FXmlTagTIT.A_FixedLength, FXmlTagTIT.D_FixedLength, "1");
                    this.fXmlNode.set_attrVal(FXmlTagTIT.A_ScanMode, FXmlTagTIT.D_ScanMode, FXmlTagTIT.D_ScanMode);
                    this.fXmlNode.set_attrVal(FXmlTagTIT.A_Pattern, FXmlTagTIT.D_Pattern, FEnumConverter.fromPattern(value), true);
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
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagTIT.A_FixedLength, FXmlTagTIT.D_FixedLength));
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
                    // Parent가 없는 TCP Item의 Fixed Length는 변경할 수 없다.
                    // ***
                    if (this.fParent == null)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, "TCP Item without the Parent", "Fixed Length"));
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

                    this.fXmlNode.set_attrVal(FXmlTagTIT.A_FixedLength, FXmlTagTIT.D_FixedLength, value.ToString(), true);
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
                    return FEnumConverter.toFormat(this.fXmlNode.get_attrVal(FXmlTagTIT.A_Format, FXmlTagTIT.D_Format));
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
                    // Locked되어 있는 TCP Item의 Format은 변경할 수 없다.
                    // ***
                    if (this.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }

                    // ***
                    // 자식이 존재하는 List Format의 TCP Item은 Format를 변경할 수 없다.
                    // (자식이 존재하는 TCP Item의 Format은 변경할 수 없다.)
                    // ***
                    if (this.hasChild)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0013, "Object's Child"));
                    }

                    // ***
                    // 부모가 TCP Item이고 부모의 Format이 AsciiList인 경우 Format를 변경할 수 없다.
                    // ***
                    if (this.fParent != null && this.fParent.fObjectType == FObjectType.TcpItem && ((FTcpItem)this.fParent).fFormat == FFormat.AsciiList)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0010, "Parent's Format", "AsciiList"));
                    }

                    // --

                    setChangedFormat();
                    this.fXmlNode.set_attrVal(FXmlTagTIT.A_Format, FXmlTagTIT.D_Format, FEnumConverter.fromFormat(value), true);
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
                    return FEnumConverter.toDataScanMode(this.fXmlNode.get_attrVal(FXmlTagTIT.A_ScanMode, FXmlTagTIT.D_ScanMode));
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

                    fXmlNode.set_attrVal(FXmlTagTIT.A_ScanMode, FXmlTagTIT.D_ScanMode, FEnumConverter.fromDataScanMode(value), true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagTIT.A_Value, FXmlTagTIT.D_Value);
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
                    this.fXmlNode.set_attrVal(FXmlTagTIT.A_Length, FXmlTagTIT.D_Length, length.ToString());
                    this.fXmlNode.set_attrVal(FXmlTagTIT.A_Value, FXmlTagTIT.D_Value, val, true);
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
                    this.fXmlNode.set_attrVal(FXmlTagTIT.A_Length, FXmlTagTIT.D_Length, length.ToString());
                    this.fXmlNode.set_attrVal(FXmlTagTIT.A_Value, FXmlTagTIT.D_Value, val, true);
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
                    this.fXmlNode.set_attrVal(FXmlTagTIT.A_Length, FXmlTagTIT.D_Length, length.ToString());
                    this.fXmlNode.set_attrVal(FXmlTagTIT.A_Value, FXmlTagTIT.D_Value, val, true);
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
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagTIT.A_Length, FXmlTagTIT.D_Length));
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
                        this.fXmlNode.get_attrVal(FXmlTagTIT.A_Transformer, FXmlTagTIT.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagTIT.A_DataConversionSetExpression, FXmlTagTIT.D_DataConversionSetExpression),
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
                        this.fXmlNode.get_attrVal(FXmlTagTIT.A_Transformer, FXmlTagTIT.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagTIT.A_DataConversionSetExpression, FXmlTagTIT.D_DataConversionSetExpression)
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
                        this.fXmlNode.get_attrVal(FXmlTagTIT.A_Transformer, FXmlTagTIT.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagTIT.A_DataConversionSetExpression, FXmlTagTIT.D_DataConversionSetExpression),
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
                        this.fXmlNode.get_attrVal(FXmlTagTIT.A_Transformer, FXmlTagTIT.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagTIT.A_DataConversionSetExpression, FXmlTagTIT.D_DataConversionSetExpression)
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
                        this.fXmlNode.get_attrVal(FXmlTagTIT.A_Transformer, FXmlTagTIT.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagTIT.A_DataConversionSetExpression, FXmlTagTIT.D_DataConversionSetExpression),
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

        public FTcpItemValueTransformer fValueTransformer
        {
            get
            {
                try
                {
                    return new FTcpItemValueTransformer(this);
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

        public FTcpItemPrecondition fPrecondition
        {
            get
            {
                try
                {
                    return new FTcpItemPrecondition(this);
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

        public string reservedWord
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTIT.A_ReservedWord, FXmlTagTIT.D_ReservedWord);
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
                    this.fXmlNode.set_attrVal(FXmlTagTIT.A_ReservedWord, FXmlTagTIT.D_ReservedWord, value, true);
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

        public bool extraction
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagTIT.A_Extraction, FXmlTagTIT.D_Extraction));
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
                    fXmlNode.set_attrVal(FXmlTagTIT.A_Extraction, FXmlTagTIT.D_Extraction, FBoolean.fromBool(value), true);
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

        public FDataConversionSet fDataConversionSet
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagTIT.A_DataConversionSetID, FXmlTagTIT.D_DataConversionSetID);
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
                    return this.fXmlNode.get_attrVal(FXmlTagTIT.A_DataConversionSetName, FXmlTagTIT.D_DataConversionSetName);
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
                    this.fXmlNode.set_attrVal(FXmlTagTIT.A_DataConversionSetName, FXmlTagTIT.D_DataConversionSetName, value, false);
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
                    return this.fXmlNode.get_attrVal(FXmlTagTIT.A_DataConversionSetExpression, FXmlTagTIT.D_DataConversionSetExpression);
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
                    this.fXmlNode.set_attrVal(FXmlTagTIT.A_DataConversionSetExpression, FXmlTagTIT.D_DataConversionSetExpression, value, false);
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
                    return this.fXmlNode.get_attrVal(FXmlTagTIT.A_UserTag1, FXmlTagTIT.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagTIT.A_UserTag1, FXmlTagTIT.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagTIT.A_UserTag2, FXmlTagTIT.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagTIT.A_UserTag2, FXmlTagTIT.D_UserTag2, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagTIT.A_UserTag3, FXmlTagTIT.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagTIT.A_UserTag3, FXmlTagTIT.D_UserTag3, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagTIT.A_UserTag4, FXmlTagTIT.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagTIT.A_UserTag4, FXmlTagTIT.D_UserTag4, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagTIT.A_UserTag5, FXmlTagTIT.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagTIT.A_UserTag5, FXmlTagTIT.D_UserTag5, value, true);
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

        public FTcpItemCollection fChildTcpItemCollection
        {
            get
            {
                try
                {
                    return new FTcpItemCollection(this.fTcdCore, this.fXmlNode.selectNodes(FXmlTagTIT.E_TcpItem));
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
                FXmlNode fXmlNodeParent = null;
                string messageType = string.Empty;

                try
                {
                    fXmlNodeParent = this.fXmlNode.fParentNode;
                    if (fXmlNodeParent == null)
                    {
                        return null;
                    }

                    // --

                    if (fXmlNodeParent.name == FXmlTagTMG.E_TcpMessage)
                    {
                        messageType = fXmlNodeParent.get_attrVal(FXmlTagTMG.A_MessageType, FXmlTagTMG.D_MessageType);
                        if (messageType == FXmlTagTMG.M_Message)
                        {
                            return new FTcpMessage(this.fTcdCore, fXmlNodeParent);
                        }
                        else if (messageType == FXmlTagTMG.M_MessageTransfer)
                        {
                            return new FTcpMessageTransfer(this.fTcdCore, fXmlNodeParent);
                        }                        
                        return null;
                    }
                    return new FTcpItem(this.fTcdCore, fXmlNodeParent);
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

        public FTcpItem fPreviousSibling
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

                    return new FTcpItem(this.fTcdCore, this.fXmlNode.fPreviousSibling);
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

        public FTcpItem fNextSibling
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

                    return new FTcpItem(this.fTcdCore, this.fXmlNode.fNextSibling);
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
                    return this.fXmlNode.containsNode(FXmlTagTIT.E_TcpItem);
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
                    xpath = FXmlTagTIT.E_TcpItem + "[@" + FXmlTagTIT.A_Pattern + "='" + FEnumConverter.fromPattern(FPattern.Fixed) + "']";
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
                    xpath = FXmlTagTIT.E_TcpItem + "[@" + FXmlTagTIT.A_Pattern + "='" + FEnumConverter.fromPattern(FPattern.Variable) + "']";
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

        public bool randomValue
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagTIT.A_RandomValue, FXmlTagTIT.D_RandomValue));
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
                string minValue = string.Empty;
                string maxValue = string.Empty;

                try
                {
                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.A2 || fFormat == FFormat.Ascii || fFormat == FFormat.JIS8)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, fFormat.ToString() + " Format", "Random Value"));
                    }

                    // --

                    if (value == true)
                    {
                        minValue = FValueConverter.getDataTypeMin(this.valueType);
                        maxValue = FValueConverter.getDataTypeMax(this.valueType);
                    }

                    this.fXmlNode.set_attrVal(FXmlTagTIT.A_RandomValueMin, FXmlTagTIT.D_RandomValueMin, minValue, false);
                    this.fXmlNode.set_attrVal(FXmlTagTIT.A_RandomValueMax, FXmlTagTIT.D_RandomValueMax, maxValue, false);
                    // --
                    this.fXmlNode.set_attrVal(FXmlTagTIT.A_RandomValue, FXmlTagTIT.D_RandomValue, FBoolean.fromBool(value), true);
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

        public string randomValueMin
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTIT.A_RandomValueMin, FXmlTagTIT.D_RandomValueMin);
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
                    if (!this.randomValue)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Random Value", "True"));
                    }

                    if (fFormat == FFormat.F8)
                    {
                        if (!FTcpDriverCommon.validateFormatRange(FFormat.F4, value))
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0014, "Min"));
                        }

                        if (!FTcpDriverCommon.validateMinMax(FFormat.F4, value, randomValueMax))
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0014, "Min"));
                        }
                    }
                    else
                    {
                        if (!FTcpDriverCommon.validateFormatRange(fFormat, value))
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0014, "Min"));
                        }

                        if (!FTcpDriverCommon.validateMinMax(fFormat, value, randomValueMax))
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0014, "Min"));
                        }
                    }

                    this.fXmlNode.set_attrVal(FXmlTagTIT.A_RandomValueMin, FXmlTagTIT.D_RandomValueMin, value, true);
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

        public string randomValueMax
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagTIT.A_RandomValueMax, FXmlTagTIT.D_RandomValueMax);
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
                    if (!randomValue)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Random Value", "True"));
                    }

                    if (fFormat == FFormat.F8)
                    {
                        if (!FTcpDriverCommon.validateFormatRange(FFormat.F4, value))
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0014, "Max"));
                        }

                        if (!FTcpDriverCommon.validateMinMax(FFormat.F4, randomValueMin, value))
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0014, "Max"));
                        }
                    }
                    else
                    {
                        if (!FTcpDriverCommon.validateFormatRange(fFormat, value))
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0014, "Max"));
                        }

                        if (!FTcpDriverCommon.validateMinMax(fFormat, randomValueMin, value))
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0014, "Max"));
                        }
                    }


                    this.fXmlNode.set_attrVal(FXmlTagTIT.A_RandomValueMax, FXmlTagTIT.D_RandomValueMax, value, true);
                    // --
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

        public bool hasValueTransformer
        {
            get
            {
                try
                {
                    if (this.fXmlNode.get_attrVal(FXmlTagTIT.A_Transformer, FXmlTagTIT.D_Transformer) == string.Empty)
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
                    if (this.fXmlNode.get_attrVal(FXmlTagTIT.A_DataConversionSetID, FXmlTagTIT.D_DataConversionSetID) == string.Empty)
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

        public bool hasPrecondition
        {
            get
            {
                try
                {
                    if (this.fXmlNode.get_attrVal(FXmlTagTIT.A_Precondition, FXmlTagTIT.D_Precondition) == string.Empty)
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
                    // TCP Item Format이 List인 경우에만 Child Item을 가질 수 있다.                     
                    // ***
                    if (this.fFormat == FFormat.List || fFormat == FFormat.AsciiList)
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
                    if (this.fParent == null)
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

        public bool canUsePrecondition
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

        public FTcpLibrary fAncestorTcpLibrary
        {
            get
            {
                try
                {
                    return this.getAncestorTcpLibrary();
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

        public FTcpMessage fAncestorTcpMessage
        {
            get
            {
                try
                {
                    return this.getAncestorTcpMessage();
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
                FTcpMessage fTmg = null;
                string xpath = string.Empty;

                try
                {
                    fTmg = this.fAncestorTcpMessage;
                    if (fTmg == null)
                    {
                        xpath = "NULL";
                    }
                    else
                    {
                        xpath =
                            "../../../../../../" + FXmlTagEQM.E_EquipmentModeling +
                            "/" + FXmlTagEQP.E_Equipment +
                            "/" + FXmlTagSNG.E_ScenarioGroup +
                            "/" + FXmlTagSNR.E_Scenario +
                            "/" + FXmlTagTTR.E_TcpTrigger +
                            "/" + FXmlTagTCN.E_TcpCondition +
                            "//" + FXmlTagTEP.E_TcpExpression + "[@" + FXmlTagTEP.A_OperandId + "='" + this.uniqueIdToString + "']";
                    }
                    // --
                    return new FObjectCollection(this.fTcdCore, fTmg.fXmlNode.selectNodes(xpath));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    fTmg = null;
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

        public bool canPasteSibling
        {
            get
            {
                try
                {
                    if (
                        this.fXmlNode.fParentNode == null ||
                        !FClipboard.containsData(FCbObjectFormat.TcpItem)
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
                        !FClipboard.containsData(FCbObjectFormat.TcpItem) ||
                        (this.fFormat != FFormat.List && this.fFormat != FFormat.AsciiList)
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

                    if (this.hasPrecondition)
                    {
                        info.Append("[pc.] ");
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
                    else if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2)
                    {
                        value = FValueConverter.toDataConversionedEncodingValue(
                             fFormat,
                             this.originalStringValue,
                             this.fXmlNode.get_attrVal(FXmlTagTIT.A_Transformer, FXmlTagTIT.D_Transformer),
                             this.fXmlNode.get_attrVal(FXmlTagTIT.A_DataConversionSetExpression, FXmlTagTIT.D_DataConversionSetExpression),
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
                            this.fXmlNode.get_attrVal(FXmlTagTIT.A_Transformer, FXmlTagTIT.D_Transformer),
                            this.fXmlNode.get_attrVal(FXmlTagTIT.A_DataConversionSetExpression, FXmlTagTIT.D_DataConversionSetExpression),
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

        public FTcpItem appendChildTcpItem(
            FTcpItem fNewChild
            )
        {
            try
            {
                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                // --
                // ***
                // Format이 List인 TCP Item만이 Child TCP Item을 가질 수 있다.
                // ***
                if (this.fFormat != FFormat.List && this.fFormat != FFormat.AsciiList)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Item's Format", "List or the AsciiList"));
                }

                // ***
                // Format이 AsciiList인 경우 Ascii Format의 Child TCP Item만을 가질 수 있다.
                // ***
                if (this.fFormat == FFormat.AsciiList && fNewChild.fFormat != FFormat.Ascii)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Format of New Child", "Ascii"));
                }

                // --

                fNewChild.replace(this.fTcdCore, this.fXmlNode.appendChild(fNewChild.fXmlNode));

                // --

                // ***
                // 현재 TCP Item의 Length 1 증가
                // ***
                this.fXmlNode.set_attrVal(FXmlTagTIT.A_Length, FXmlTagTIT.D_Length, (this.originalLength + 1).ToString());

                // --

                if (this.isModelingObject)
                {
                    FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fTcdCore.fEventPusher.pushEvent(new FEventArgsBase[]{
                        new FObjectEventArgs(FEventId.ObjectAppendCompleted, this.fTcpDriver, this, fNewChild),
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

        public FTcpItem appendChildTcpItem(
            FTcpDriver fTcpDriver,
            string name,
            FFormat fFormat,
            string stringValue
            )
        {
            try
            {
                return appendChildTcpItem(new FTcpItem(fTcpDriver, name, fFormat, stringValue));
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

        public FTcpItem insertBeforeChildTcpItem(
            FTcpItem fNewChild,
            FTcpItem fRefChild
            )
        {
            try
            {
                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);
                // --
                if (this.fFormat != FFormat.List && this.fFormat != FFormat.AsciiList)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Item's Format", "List or the AsciiList"));
                }

                // ***
                // Format이 AsciiList인 경우 Ascii Format의 Child TCP Item만을 가질 수 있다.
                // ***
                if (this.fFormat == FFormat.AsciiList && fNewChild.fFormat != FFormat.Ascii)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Format of New Child", "Ascii"));
                }

                // --

                fNewChild.replace(this.fTcdCore, this.fXmlNode.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));

                // --

                // ***
                // 현재 TCP Item의 Length 1 증가
                // ***
                this.fXmlNode.set_attrVal(FXmlTagTIT.A_Length, FXmlTagTIT.D_Length, (this.originalLength + 1).ToString());

                // --

                // ***
                // 추가된 Child의 Previous TCP Item과 Next TCP Item의 Pattern이 Variable일 경우,
                // 추가된 Child의 Pattern를 Variable로 설정한다.
                // ***                
                if (
                    (fNewChild.fPreviousSibling != null && fNewChild.fPreviousSibling.fPattern == FPattern.Variable) &&
                    (fNewChild.fNextSibling != null && fNewChild.fNextSibling.fPattern == FPattern.Variable)
                    )
                {
                    fNewChild.fXmlNode.set_attrVal(FXmlTagTIT.A_Pattern, FXmlTagTIT.D_Pattern, FEnumConverter.fromPattern(FPattern.Variable));
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

        public FTcpItem insertBeforeChildTcpItem(
            FTcpDriver fTcpDriver,
            string name,
            FFormat fFromat,
            string stringValue,
            FTcpItem fRefChild
            )
        {
            try
            {
                return insertBeforeChildTcpItem(
                    new FTcpItem(fTcpDriver, name, fFormat, stringValue),
                    fRefChild
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

        public FTcpItem insertAfterChildTcpItem(
            FTcpItem fNewChild,
            FTcpItem fRefChild
            )
        {
            try
            {
                FTcpDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FTcpDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);
                // --
                if (this.fFormat != FFormat.List && this.fFormat != FFormat.AsciiList)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Item's Format", "List or AsciiList"));
                }

                // ***
                // Format이 AsciiList인 경우 Ascii Format의 Child TCP Item만을 가질 수 있다.
                // ***
                if (this.fFormat == FFormat.AsciiList && fNewChild.fFormat != FFormat.Ascii)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Format of New Child", "Ascii"));
                }

                // --

                fNewChild.replace(this.fTcdCore, this.fXmlNode.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));

                // --

                // ***
                // 현재 TCP Item의 Length 1 증가
                // ***
                this.fXmlNode.set_attrVal(FXmlTagTIT.A_Length, FXmlTagTIT.D_Length, (this.originalLength + 1).ToString());

                // --

                // ***
                // 추가된 Child의 Previous TCP Item과 Next TCP Item의 Pattern이 Variable일 경우,
                // 추가된 Child의 Pattern를 Variable로 설정한다.
                // ***                
                if (
                    (fNewChild.fPreviousSibling != null && fNewChild.fPreviousSibling.fPattern == FPattern.Variable) &&
                    (fNewChild.fNextSibling != null && fNewChild.fNextSibling.fPattern == FPattern.Variable)
                    )
                {
                    fNewChild.fXmlNode.set_attrVal(FXmlTagTIT.A_Pattern, FXmlTagTIT.D_Pattern, FEnumConverter.fromPattern(FPattern.Variable));
                }

                // --                

                if (this.isModelingObject)
                {
                    FTcpDriverCommon.resetUniqueId(this.fTcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --                    
                    this.fTcdCore.fEventPusher.pushEvent(new FEventArgsBase[]{
                        new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this.fTcpDriver, this, fNewChild),
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

        public FTcpItem insertAfterChildTcpItem(
            FTcpDriver fTcpDriver,
            string name,
            FFormat fFormat,
            string stringValue,
            FTcpItem fRefChild
            )
        {
            try
            {
                return insertAfterChildTcpItem(
                    new FTcpItem(fTcpDriver, name, fFormat, stringValue),
                    fRefChild
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

                resetRelation();

                // --

                isModelingObject = this.isModelingObject;
                fParent = this.fParent;
                if (fParent.fObjectType == FObjectType.TcpMessage)
                {
                    this.replace(this.fTcdCore, ((FTcpMessage)fParent).fXmlNode.removeChild(this.fXmlNode));
                }
                else if (fParent.fObjectType == FObjectType.TcpMessageTransfer)
                {
                    this.replace(this.fTcdCore, ((FTcpMessageTransfer)fParent).fXmlNode.removeChild(this.fXmlNode));
                }
                else
                {
                    this.replace(this.fTcdCore, ((FTcpItem)fParent).fXmlNode.removeChild(this.fXmlNode));
                    // --
                    length = int.Parse(((FTcpItem)fParent).fXmlNode.get_attrVal(FXmlTagTIT.A_Length, FXmlTagTIT.D_Length)) - 1;
                    ((FTcpItem)fParent).fXmlNode.set_attrVal(FXmlTagTIT.A_Length, FXmlTagTIT.D_Length, length.ToString());
                }

                // --

                // ***
                // Remove 시, Pattern(Fixed)과 Fixed Length(1) 초기화
                // ***
                this.fXmlNode.set_attrVal(FXmlTagTIT.A_Pattern, FXmlTagTIT.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));
                this.fXmlNode.set_attrVal(FXmlTagTIT.A_FixedLength, FXmlTagTIT.D_FixedLength, "1");

                // --

                if (isModelingObject)
                {
                    if (fParent.fObjectType == FObjectType.TcpMessage)
                    {
                        this.fTcdCore.fEventPusher.pushEvent(
                            new FObjectEventArgs(FEventId.ObjectRemoveCompleted, this.fTcpDriver, fParent, this)
                            );
                    }
                    else
                    {
                        this.fTcdCore.fEventPusher.pushEvent(new FEventArgsBase[]{
                            new FObjectEventArgs(FEventId.ObjectRemoveCompleted, this.fTcpDriver, fParent, this),
                            new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fTcpDriver, ((FTcpItem)fParent).fParent, fParent)
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
                fParent = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpItem removeChildTcpItem(
            FTcpItem fChild
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

        public void removeChildTcpItem(
            FTcpItem[] fChilds
            )
        {
            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                foreach (FTcpItem fTit in fChilds)
                {
                    FTcpDriverCommon.validateRemoveChildObject(this.fXmlNode, fTit.fXmlNode);
                }

                // --

                foreach (FTcpItem fTit in fChilds)
                {
                    fTit.remove();
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

        public void removeAllChildTcpItem(
            )
        {
            FTcpItemCollection fTitCollection = null;

            try
            {
                fTitCollection = this.fChildTcpItemCollection;
                if (fTitCollection.count == 0)
                {
                    return;
                }

                // --

                foreach (FTcpItem fTit in fTitCollection)
                {
                    if (fTit.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }
                }

                // --

                foreach (FTcpItem fTit in fTitCollection)
                {
                    fTit.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fTitCollection != null)
                {
                    fTitCollection.Dispose();
                    fTitCollection = null;
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
            FTcpItem fRefObject
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

                if (!this.fAncestorTcpMessage.Equals(fRefObject.fAncestorTcpMessage))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Ancestor TCP Message ", "same"));
                }

                if (this.containsObject(fRefObject))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0060, "Object", "Child"));
                }

                if (
                    (fRefObject.fParent.fObjectType == FObjectType.TcpMessage && ((FTcpMessage)fRefObject.fParent).hasVariableChild) ||
                    (fRefObject.fParent.fObjectType == FObjectType.TcpItem && ((FTcpItem)fRefObject.fParent).hasVariableChild) 
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
                                FDebug.throwFException(string.Format(FConstants.err_m_0011, "Pattern of the Previous TCP Item and the Next TCP Item", "Variable"));
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
                            FDebug.throwFException(string.Format(FConstants.err_m_0010, "Pattern of the Previous TCP Item and the Next TCP Item", "Variable"));
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
                        if (fOldParent.fObjectType == FObjectType.TcpMessage)
                        {
                            ((FTcpMessage)fOldParent).unlockObject();
                        }
                        else
                        {
                            ((FTcpItem)fOldParent).unlockObject();
                        }
                        // --
                        if (this.fParent.fObjectType == FObjectType.TcpMessage)
                        {
                            ((FTcpMessage)this.fParent).lockObject();
                        }
                        else
                        {
                            ((FTcpItem)this.fParent).lockObject();
                        }
                    }
                    
                    // --

                    if (fOldParent.fObjectType == FObjectType.TcpItem)
                    {
                        ((FTcpItem)fOldParent).fXmlNode.set_attrVal(FXmlTagTIT.A_Length, FXmlTagTIT.D_Length, (((FTcpItem)fOldParent).length - 1).ToString(), true);
                    }                    
                    // --
                    if (this.fParent.fObjectType == FObjectType.TcpItem)
                    {
                        ((FTcpItem)this.fParent).fXmlNode.set_attrVal(FXmlTagTIT.A_Length, FXmlTagTIT.D_Length, (((FTcpItem)this.fParent).length + 1).ToString(), true);                    
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
            FTcpMessage fRefObject
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

                if (!this.fAncestorTcpMessage.Equals(fRefObject))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "TCP Item", "child"));
                }
                
                if (fRefObject.hasVariableChild)
                {
                    if (this.fPattern == FPattern.Variable)
                    {
                        if (fRefObject.fChildTcpItemCollection[fRefObject.fChildTcpItemCollection.count - 1].fPattern != FPattern.Variable)
                        {
                            if (
                                !this.fParent.Equals(fRefObject) ||
                                (this.fPreviousSibling != null && this.fPreviousSibling.fPattern == FPattern.Variable) ||
                                (this.fNextSibling != null && this.fNextSibling.fPattern == FPattern.Variable)
                                )
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0011, "Pattern of the Previous TCP Item and the Next TCP Item", "Variable"));
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

                if (!fRefObject.Equals(fOldParent))
                {
                    if (this.locked)
                    {
                        ((FTcpItem)fOldParent).unlockObject();
                        fRefObject.lockObject();
                    }
                    // --
                    ((FTcpItem)fOldParent).fXmlNode.set_attrVal(FXmlTagTIT.A_Length, FXmlTagTIT.D_Length, (((FTcpItem)fOldParent).length - 1).ToString(), true);
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
                this.fXmlNode.set_attrVal(FXmlTagTIT.A_Value, FXmlTagTIT.D_Value, FXmlTagTIT.D_Value);
                this.fXmlNode.set_attrVal(FXmlTagTIT.A_Length, FXmlTagTIT.D_Length, FXmlTagTIT.D_Length);
                // --
                this.fXmlNode.set_attrVal(FXmlTagTIT.A_Transformer, FXmlTagTIT.D_Transformer, FXmlTagTIT.D_Transformer);
                // --
                this.fXmlNode.set_attrVal(FXmlTagTIT.A_Precondition, FXmlTagTIT.D_Precondition, FXmlTagTIT.D_Precondition);
                // --
                this.fXmlNode.set_attrVal(FXmlTagTIT.A_RandomValue, FXmlTagTIT.D_RandomValue, FXmlTagTIT.D_RandomValue);
                this.fXmlNode.set_attrVal(FXmlTagTIT.A_RandomValueMin, FXmlTagTIT.D_RandomValueMin, FXmlTagTIT.D_RandomValueMin);
                this.fXmlNode.set_attrVal(FXmlTagTIT.A_RandomValueMax, FXmlTagTIT.D_RandomValueMax, FXmlTagTIT.D_RandomValueMax);

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
                // TCP Item에 대한 Lock 처리
                // ***
                this.fXmlNode.set_attrVal(FXmlTagTIT.A_Locked, FXmlTagTIT.D_Locked, FBoolean.True, true);

                // --

                // ***
                // Parent TCP Item에 대한 Lock 처리
                // ***
                if (this.fParent.fObjectType == FObjectType.TcpItem)
                {
                    ((FTcpItem)this.fParent).lockObject();
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
                // Lock이 설정된 자식 TCP Item이 존재할 경우 Unlock 작업을 취소한다.
                // ***
                xpath = FXmlTagTIT.E_TcpItem + "[@" + FXmlTagTIT.A_Locked + "='" + FBoolean.True + "']";
                if (this.fXmlNode.containsNode(xpath))
                {
                    return;
                }

                // ***
                // TCP Item이 TCP Expression에 사용되었을 경우 Unlock 작업을 취소한다.
                // ***
                xpath =
                    FXmlTagEQM.E_EquipmentModeling +
                    "/" + FXmlTagEQP.E_Equipment +
                    "/" + FXmlTagSNG.E_ScenarioGroup +
                    "/" + FXmlTagSNR.E_Scenario +
                    "/" + FXmlTagTTR.E_TcpTrigger +
                    "/" + FXmlTagTCN.E_TcpCondition +
                    "//" + FXmlTagTEP.E_TcpExpression + "[@" + FXmlTagTEP.A_OperandId + "='" + this.uniqueIdToString + "']";
                if (this.fTcpDriver.fXmlNode.containsNode(xpath))
                {
                    return;
                }

                // --

                // ***
                // TCP Item에 대한 Unlock 처리
                // ***
                this.fXmlNode.set_attrVal(FXmlTagTIT.A_Locked, FXmlTagTIT.D_Locked, FBoolean.False, true);

                // --

                // ***
                // Parent TCP Item에 대한 Unlcok 처리
                // ***
                if (this.fParent.fObjectType == FObjectType.TcpItem)
                {
                    ((FTcpItem)this.fParent).unlockObject();
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
                this.copyObject(FCbObjectFormat.TcpItem, this.fXmlNode);
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
                fXmlNode.set_attrVal(FXmlTagTIT.A_Pattern, FXmlTagTIT.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));
                fXmlNode.set_attrVal(FXmlTagTIT.A_FixedLength, FXmlTagTIT.D_FixedLength, "1");

                // --

                resetFlowNode(fXmlNode);
                this.copyObject(FCbObjectFormat.TcpItem, fXmlNode);
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

        public FTcpItem pasteSibling(
            )
        {
            FIObject fParent = null;
            FTcpItem fTcpItem = null;

            try
            {
                FTcpDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.TcpItem);

                // --

                fParent = this.fParent;
                fTcpItem = (FTcpItem)this.pasteObject(FCbObjectFormat.TcpItem);
                if (fParent.fObjectType == FObjectType.TcpMessage)
                {
                    return ((FTcpMessage)fParent).insertAfterChildTcpItem(fTcpItem, this);
                }
                else if (fParent.fObjectType == FObjectType.TcpMessageTransfer)
                {
                    return ((FTcpMessageTransfer)fParent).insertAfterChildTcpItem(fTcpItem, this);
                }
                return ((FTcpItem)fParent).insertAfterChildTcpItem(fTcpItem, this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fParent = null;
                fTcpItem = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpItem pasteChild(
            )
        {
            FTcpItem fTcpItem = null;

            try
            {
                FTcpDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.TcpItem);

                // --

                fTcpItem = (FTcpItem)this.pasteObject(FCbObjectFormat.TcpItem);
                return this.appendChildTcpItem(fTcpItem);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fTcpItem = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpItemCollection selectTcpItemByName(
            string name
            )
        {
            const string xpath = FXmlTagTIT.E_TcpItem + "[@" + FXmlTagTIT.A_Name + "='{0}']";

            try
            {
                return new FTcpItemCollection(
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

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpItem selectSingleTcpItemByName(
            string name
            )
        {
            const string xpath = FXmlTagTIT.E_TcpItem + "[@" + FXmlTagTIT.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FTcpItem(this.fTcdCore, fXmlNode);
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

        public FTcpItemCollection selectAllTcpItemByName(
            string name
            )
        {
            const string xpath = ".//" + FXmlTagTIT.E_TcpItem + "[@" + FXmlTagTIT.A_Name + "='{0}']";

            try
            {
                return new FTcpItemCollection(
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

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpItem selectSingleAllTcpItemByName(
            string name
            )
        {
            const string xpath = ".//" + FXmlTagTIT.E_TcpItem + "[@" + FXmlTagTIT.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FTcpItem(this.fTcdCore, fXmlNode);
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

        public FTcpItemCollection selectTcpItemByReservedWord(
            string reservedWord
            )
        {
            const string xpath = FXmlTagTIT.E_TcpItem + "[@" + FXmlTagTIT.A_ReservedWord + "='{0}']";

            try
            {
                return new FTcpItemCollection(
                    this.fTcdCore,
                    this.fXmlNode.selectNodes(string.Format(xpath, reservedWord))
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

        public FTcpItem selectSingleTcpItemByReservedWord(
            string reservedWord
            )
        {
            const string xpath = FXmlTagTIT.E_TcpItem + "[@" + FXmlTagTIT.A_ReservedWord + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, reservedWord));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FTcpItem(this.fTcdCore, fXmlNode);
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

        public FTcpItemCollection selectAllTcpItemByReservedWord(
            string reservedWord
            )
        {
            const string xpath = ".//" + FXmlTagTIT.E_TcpItem + "[@" + FXmlTagTIT.A_ReservedWord + "='{0}']";

            try
            {
                return new FTcpItemCollection(
                    this.fTcdCore,
                    this.fXmlNode.selectNodes(string.Format(xpath, reservedWord))
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

        public FTcpItem selectSingleAllTcpItemByReservedWord(
            string reservedWord
            )
        {
            const string xpath = ".//" + FXmlTagTIT.E_TcpItem + "[@" + FXmlTagTIT.A_ReservedWord + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, reservedWord));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FTcpItem(this.fTcdCore, fXmlNode);
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

        public FTcpItemCollection selectTcpItemByExtraction(
            )
        {
            const string xpath = FXmlTagTIT.E_TcpItem + "[@" + FXmlTagTIT.A_Extraction + "='{0}']";

            try
            {
                return new FTcpItemCollection(
                    this.fTcdCore,
                    this.fXmlNode.selectNodes(string.Format(xpath, FBoolean.True))
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

        public FTcpItem selectSingleTcpItemByExtraction(
            )
        {
            const string xpath = FXmlTagTIT.E_TcpItem + "[@" + FXmlTagTIT.A_Extraction + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, FBoolean.True));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FTcpItem(this.fTcdCore, fXmlNode);
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

        public FTcpItemCollection selectAllTcpItemByExtraction(
            )
        {
            const string xpath = ".//" + FXmlTagTIT.E_TcpItem + "[@" + FXmlTagTIT.A_Extraction + "='{0}']";

            try
            {
                return new FTcpItemCollection(
                    this.fTcdCore,
                    this.fXmlNode.selectNodes(string.Format(xpath, FBoolean.True))
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

        public FTcpItem selectSingleAllTcpItemByExtraction(
            )
        {
            const string xpath = ".//" + FXmlTagTIT.E_TcpItem + "[@" + FXmlTagTIT.A_Extraction + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, FBoolean.True));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FTcpItem(this.fTcdCore, fXmlNode);
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

        public FTcpItem selectSingleAllTcpItemByIndex(
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
                //--
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
                return new FTcpItem(this.fTcdCore, fXmlNode);
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
                // 이 TCP Item 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "TCP Item", "Modeling File"));
                }

                // ***
                // Data Conversion Set와 TCP Item의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fDataConversionSet))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the Data Conversion Set and the TCP Item", "same"));
                }

                // --

                fFormat = this.fFormat;
                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0006, fFormat.ToString() + " Format", "Data Conversion Set"));
                }

                // --

                oldDcsId = this.fXmlNode.get_attrVal(FXmlTagTIT.A_DataConversionSetID, FXmlTagTIT.D_DataConversionSetID);
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

                this.fXmlNode.set_attrVal(FXmlTagTIT.A_DataConversionSetExpression, FXmlTagTIT.D_DataConversionSetExpression, fDataConversionSet.expression, false);
                this.fXmlNode.set_attrVal(FXmlTagTIT.A_DataConversionSetName, FXmlTagTIT.D_DataConversionSetName, fDataConversionSet.name, false);
                this.fXmlNode.set_attrVal(FXmlTagTIT.A_DataConversionSetID, FXmlTagTIT.D_DataConversionSetID, newDcsId, true);
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
                foreach (FTcpItem fHit in this.fChildTcpItemCollection)
                {
                    fHit.resetDataConversionSet(isModifyEvent);
                }

                // --

                fDcs = this.fDataConversionSet;
                if (fDcs == null)
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagTIT.A_DataConversionSetExpression, FXmlTagTIT.D_DataConversionSetExpression, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagTIT.A_DataConversionSetName, FXmlTagTIT.D_DataConversionSetName, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagTIT.A_DataConversionSetID, FXmlTagTIT.D_DataConversionSetID, string.Empty, isModifyEvent);
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
                fXmlNode.set_attrVal(FXmlTagTIT.A_DataConversionSetExpression, FXmlTagTIT.D_DataConversionSetExpression, string.Empty);
                fXmlNode.set_attrVal(FXmlTagTIT.A_DataConversionSetName, FXmlTagTIT.D_DataConversionSetName, string.Empty);
                fXmlNode.set_attrVal(FXmlTagTIT.A_DataConversionSetID, FXmlTagTIT.D_DataConversionSetID, string.Empty);

                // --

                foreach (FXmlNode fXmlNodeHit in fXmlNode.selectNodes(FXmlTagTIT.E_TcpItem))
                {
                    FTcpItem.resetFlowNode(fXmlNodeHit);
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
        public FTcpItem clone(
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
                fXmlNode.set_attrVal(FXmlTagTIT.A_Pattern, FXmlTagTIT.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));
                fXmlNode.set_attrVal(FXmlTagTIT.A_FixedLength, FXmlTagTIT.D_FixedLength, "1");

                // --

                resetFlowNode(fXmlNode);
                FTcpDriverCommon.resetLocked(fXmlNode);
                return new FTcpItem(this.fTcdCore, fXmlNode);
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
