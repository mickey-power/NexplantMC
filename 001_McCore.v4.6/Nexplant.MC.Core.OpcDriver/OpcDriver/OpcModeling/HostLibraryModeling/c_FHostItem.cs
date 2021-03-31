/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FHostItem.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.15
--  Description     : FAMate Core FaOpcDriver Host Item Class 
--  History         : Created by Jeff.Kim at 2013.07.15
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    public class FHostItem : FBaseObject<FHostItem>, FIObject, FIHostOperand
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Contruction and Destruction

        public FHostItem(
            FOpcDriver fOpcDriver
            )
            : base(fOpcDriver.fOcdCore, FOpcDriverCommon.createXmlNodeHIT(fOpcDriver.fOcdCore.fXmlDoc))
        {
 
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostItem(
            FOpcDriver fOpcDriver,
            string name,
            FFormat fForamt,
            string stringValue
            )
            : base(FOpcDriverCommon.createXmlNodeHIT(fOpcDriver.fOcdCore.fXmlDoc, name, fForamt, stringValue))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FHostItem(
            FOcdCore fOcdCore,
            FXmlNode fXmlNode
            )
            : base(fOcdCore, fXmlNode)
        { 
        
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FHostItem(
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
                    return FObjectType.HostItem;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                { 
                
                }
                return FObjectType.HostItem;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostOperandType fHostOperandType
        {
            get
            {
                try
                {
                    return FHostOperandType.HostItem;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagHIT.A_UniqueId, FXmlTagHIT.D_UniqueId);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagHIT.A_Locked, FXmlTagHIT.D_Locked));
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
                    return this.fXmlNode.get_attrVal(FXmlTagHIT.A_Name, FXmlTagHIT.D_Name);
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

                    this.fXmlNode.set_attrVal(FXmlTagHIT.A_Name, FXmlTagHIT.D_Name, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHIT.A_Description, FXmlTagHIT.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagHIT.A_Description, FXmlTagHIT.D_Description, value, true);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagHIT.A_FontColor, FXmlTagHIT.D_FontColor));
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
                    this.fXmlNode.set_attrVal(FXmlTagHIT.A_FontColor, FXmlTagHIT.D_FontColor, value.Name, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagHIT.A_FontBold, FXmlTagHIT.D_FontBold));
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
                    this.fXmlNode.set_attrVal(FXmlTagHIT.A_FontBold, FXmlTagHIT.D_FontBold, FBoolean.fromBool(value), true);
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
                    return FEnumConverter.toPattern(this.fXmlNode.get_attrVal(FXmlTagHIT.A_Pattern, FXmlTagHIT.D_Pattern));
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
                    // Parent가 없는 Host Item의 Pattern은 변경할 수 없다.
                    // ***
                    if (this.fParent == null)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, "Host Item without the Parent", "Pattern"));
                    }
                   
                    // --

                    if (value == FPattern.Fixed)
                    {
                        // ***
                        // Previous와 Next 형제가 Variable Host Item이 아니어야 한다.
                        // ***                        
                        if (
                            (this.fPreviousSibling != null && this.fPreviousSibling.fPattern == FPattern.Variable) &&
                            (this.fNextSibling != null && this.fNextSibling.fPattern == FPattern.Variable)
                            )
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0010, "Pattern of the Previous Host Item and the Next Host Item", "Variable"));
                        }
                        if (this.fFormat == FFormat.List || this.fFormat == FFormat.AsciiList)
                        {
                            this.fXmlNode.set_attrVal(FXmlTagHIT.A_ArrayList, FXmlTagHIT.D_ArrayList, "F");
                        }
                    }
                    else if (value == FPattern.Variable)
                    {
                        // ***
                        // 형제 Variable Host Item과 연속적으로 이어져야 한다.                        
                        // ***
                        if (
                            (this.fParent.fObjectType == FObjectType.HostMessage && ((FHostMessage)this.fParent).hasVariableChild) ||
                            (this.fParent.fObjectType == FObjectType.HostItem && ((FHostItem)this.fParent).hasVariableChild)
                            )
                        {
                            if (this.fPreviousSibling == null && this.fNextSibling.fPattern != FPattern.Variable)
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0011, "Pattern of the Previous Host Item and the Next Host Item", "Variable"));
                            }
                            else if (this.fNextSibling == null && this.fPreviousSibling.fPattern != FPattern.Variable)
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0011, "Pattern of the Previous Host Item and the Next Host Item", "Variable"));
                            }
                            else if (this.fPreviousSibling.fPattern != FPattern.Variable && this.fNextSibling.fPattern != FPattern.Variable)
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0011, "Pattern of the Previous Host Item and the Next Host Item", "Variable"));
                            }
                        }
                        if (this.fFormat == FFormat.List || this.fFormat == FFormat.AsciiList)
                        {
                            this.fXmlNode.set_attrVal(FXmlTagHIT.A_ArrayList, FXmlTagHIT.D_ArrayList, "T");
                        }
                    }                   

                    // --

                    // ***
                    // Pattern 변경 시, Fixed Length와 Scan Mode 초기화
                    // ***
                    this.fXmlNode.set_attrVal(FXmlTagHIT.A_FixedLength, FXmlTagHIT.D_FixedLength, "1");
                    this.fXmlNode.set_attrVal(FXmlTagHIT.A_ScanMode, FXmlTagHIT.D_ScanMode, FXmlTagHIT.D_ScanMode);
                    this.fXmlNode.set_attrVal(FXmlTagHIT.A_Pattern, FXmlTagHIT.D_Pattern, FEnumConverter.fromPattern(value), true);
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
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagHIT.A_FixedLength, FXmlTagHIT.D_FixedLength));
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
                    // Parent가 없는 Host Item의 Fixed Length는 변경할 수 없다.
                    // ***
                    if (this.fParent == null)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, "Host Item without the Parent", "Fixed Length"));
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

                    this.fXmlNode.set_attrVal(FXmlTagHIT.A_FixedLength, FXmlTagHIT.D_FixedLength, value.ToString(), true);
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
                    return FEnumConverter.toFormat(this.fXmlNode.get_attrVal(FXmlTagHIT.A_Format, FXmlTagHIT.D_Format));
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
                    // Locked되어 있는 Host Item의 Format은 변경할 수 없다.
                    // ***
                    if (this.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }

                    // ***
                    // 자식이 존재하는 List Format의 Host Item은 Format를 변경할 수 없다.
                    // (자식이 존재하는 Host Item의 Format은 변경할 수 없다.)
                    // ***
                    if (this.hasChild)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0013, "Object's Child"));
                    }

                    // ***
                    // 부모가 Host Item이고 부모의 Format이 AsciiList인 경우 Format를 변경할 수 없다.
                    // ***
                    if (this.fParent != null && this.fParent.fObjectType == FObjectType.HostItem && ((FHostItem)this.fParent).fFormat == FFormat.AsciiList)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0010, "Parent's Format", "AsciiList"));
                    }

                    // --

                    setChangedFormat();
                    this.fXmlNode.set_attrVal(FXmlTagHIT.A_Format, FXmlTagHIT.D_Format, FEnumConverter.fromFormat(value), true);
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

        public bool isArrayList
        {
            get
            {
                try
                {
                    return FEnumConverter.toArrayList(this.fXmlNode.get_attrVal(FXmlTagHIT.A_ArrayList, FXmlTagHIT.D_ArrayList));
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

        public FDataScanMode fScanMode
        {
            get
            {
                try
                {
                    return FEnumConverter.toDataScanMode(this.fXmlNode.get_attrVal(FXmlTagHIT.A_ScanMode, FXmlTagHIT.D_ScanMode));
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

                    fXmlNode.set_attrVal(FXmlTagHIT.A_ScanMode, FXmlTagHIT.D_ScanMode, FEnumConverter.fromDataScanMode(value), true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHIT.A_Value, FXmlTagHIT.D_Value);
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
                    this.fXmlNode.set_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length, length.ToString());
                    this.fXmlNode.set_attrVal(FXmlTagHIT.A_Value, FXmlTagHIT.D_Value, val, true);
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
                    this.fXmlNode.set_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length, length.ToString());
                    this.fXmlNode.set_attrVal(FXmlTagHIT.A_Value, FXmlTagHIT.D_Value, val, true);
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
                    this.fXmlNode.set_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length, length.ToString());
                    this.fXmlNode.set_attrVal(FXmlTagHIT.A_Value, FXmlTagHIT.D_Value, val, true);
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
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length));
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
                        this.fXmlNode.get_attrVal(FXmlTagHIT.A_Transformer, FXmlTagHIT.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagHIT.A_DataConversionSetExpression, FXmlTagHIT.D_DataConversionSetExpression),
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
                        this.fXmlNode.get_attrVal(FXmlTagHIT.A_Transformer, FXmlTagHIT.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagHIT.A_DataConversionSetExpression, FXmlTagHIT.D_DataConversionSetExpression)
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
                        this.fXmlNode.get_attrVal(FXmlTagHIT.A_Transformer, FXmlTagHIT.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagHIT.A_DataConversionSetExpression, FXmlTagHIT.D_DataConversionSetExpression),
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
                        this.fXmlNode.get_attrVal(FXmlTagHIT.A_Transformer, FXmlTagHIT.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagHIT.A_DataConversionSetExpression, FXmlTagHIT.D_DataConversionSetExpression)
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
                        this.fXmlNode.get_attrVal(FXmlTagHIT.A_Transformer, FXmlTagHIT.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagHIT.A_DataConversionSetExpression, FXmlTagHIT.D_DataConversionSetExpression),
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

        public FHostItemValueTransformer fValueTransformer
        {
            get
            {
                try
                {
                    return new FHostItemValueTransformer(this);
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

        public FHostItemPrecondition fPrecondition
        {
            get
            {
                try
                {
                    return new FHostItemPrecondition(this);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHIT.A_ReservedWord, FXmlTagHIT.D_ReservedWord);
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
                    this.fXmlNode.set_attrVal(FXmlTagHIT.A_ReservedWord, FXmlTagHIT.D_ReservedWord, value, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagHIT.A_Extraction, FXmlTagHIT.D_Extraction));
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
                    fXmlNode.set_attrVal(FXmlTagHIT.A_Extraction, FXmlTagHIT.D_Extraction, FBoolean.fromBool(value), true);
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
        // Add by Jeff.Kim 2015.12.10
        // Log Data 분석시 검색 키값 수집을 위해 추가
        public bool hashTag
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagHIT.A_HashTag, FXmlTagHIT.D_HashTag));
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
                    fXmlNode.set_attrVal(FXmlTagHIT.A_HashTag, FXmlTagHIT.D_HashTag, FBoolean.fromBool(value), true);
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
                    id = this.fXmlNode.get_attrVal(FXmlTagHIT.A_DataConversionSetID, FXmlTagHIT.D_DataConversionSetID);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHIT.A_DataConversionSetName, FXmlTagHIT.D_DataConversionSetName);
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
                    this.fXmlNode.set_attrVal(FXmlTagHIT.A_DataConversionSetName, FXmlTagHIT.D_DataConversionSetName, value, false);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHIT.A_DataConversionSetExpression, FXmlTagHIT.D_DataConversionSetExpression);
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
                    this.fXmlNode.set_attrVal(FXmlTagHIT.A_DataConversionSetExpression, FXmlTagHIT.D_DataConversionSetExpression, value, false);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHIT.A_UserTag1, FXmlTagHIT.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagHIT.A_UserTag1, FXmlTagHIT.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHIT.A_UserTag2, FXmlTagHIT.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagHIT.A_UserTag2, FXmlTagHIT.D_UserTag2, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHIT.A_UserTag3, FXmlTagHIT.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagHIT.A_UserTag3, FXmlTagHIT.D_UserTag3, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHIT.A_UserTag4, FXmlTagHIT.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagHIT.A_UserTag4, FXmlTagHIT.D_UserTag4, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHIT.A_UserTag5, FXmlTagHIT.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagHIT.A_UserTag5, FXmlTagHIT.D_UserTag5, value, true);
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

        public FHostItemCollection fChildHostItemCollection
        {
            get
            {
                try
                {
                    return new FHostItemCollection(this.fOcdCore, this.fXmlNode.selectNodes(FXmlTagHIT.E_HostItem));
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

                    if (fXmlNodeParent.name == FXmlTagHMG.E_HostMessage)
                    {
                        messageType = fXmlNodeParent.get_attrVal(FXmlTagHMG.A_MessageType, FXmlTagHMG.D_MessageType);
                        if (messageType == FXmlTagHMG.M_Message)
                        {
                            return new FHostMessage(this.fOcdCore, fXmlNodeParent);
                        }
                        else if (messageType == FXmlTagHMG.M_MessageTransfer)
                        {
                            return new FHostMessageTransfer(this.fOcdCore, fXmlNodeParent);
                        }
                        else if (messageType == FXmlTagHMG.M_HostDriverDataMessage)
                        {
                            return new FHostDriverDataMessage(this.fOcdCore, fXmlNodeParent);
                        }
                        return null;
                    }
                    return new FHostItem(this.fOcdCore, fXmlNodeParent);
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

        public FHostItem fPreviousSibling
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

                    return new FHostItem(this.fOcdCore, this.fXmlNode.fPreviousSibling);
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

        public FHostItem fNextSibling
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

                    return new FHostItem(this.fOcdCore, this.fXmlNode.fNextSibling);
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
                    return this.fXmlNode.containsNode(FXmlTagHIT.E_HostItem);
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
                    xpath = FXmlTagHIT.E_HostItem + "[@" + FXmlTagHIT.A_Pattern + "='" + FEnumConverter.fromPattern(FPattern.Fixed) + "']";
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
                    xpath = FXmlTagHIT.E_HostItem + "[@" + FXmlTagHIT.A_Pattern + "='" + FEnumConverter.fromPattern(FPattern.Variable) + "']";
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagHIT.A_RandomValue, FXmlTagHIT.D_RandomValue));
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

                    this.fXmlNode.set_attrVal(FXmlTagHIT.A_RandomValueMin, FXmlTagHIT.D_RandomValueMin, minValue, false);
                    this.fXmlNode.set_attrVal(FXmlTagHIT.A_RandomValueMax, FXmlTagHIT.D_RandomValueMax, maxValue, false);
                    // --
                    this.fXmlNode.set_attrVal(FXmlTagHIT.A_RandomValue, FXmlTagHIT.D_RandomValue, FBoolean.fromBool(value), true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHIT.A_RandomValueMin, FXmlTagHIT.D_RandomValueMin);
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
                        if (!FOpcDriverCommon.validateFormatRange(FFormat.F4, value))
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0014, "Min"));
                        }

                        if (!FOpcDriverCommon.validateMinMax(FFormat.F4, value, randomValueMax))
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0014, "Min"));
                        }
                    }
                    else
                    {
                        if (!FOpcDriverCommon.validateFormatRange(fFormat, value))
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0014, "Min"));
                        }

                        if (!FOpcDriverCommon.validateMinMax(fFormat, value, randomValueMax))
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0014, "Min"));
                        }
                    }

                    this.fXmlNode.set_attrVal(FXmlTagHIT.A_RandomValueMin, FXmlTagHIT.D_RandomValueMin, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagHIT.A_RandomValueMax, FXmlTagHIT.D_RandomValueMax);
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
                        if (!FOpcDriverCommon.validateFormatRange(FFormat.F4, value))
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0014, "Max"));
                        }

                        if (!FOpcDriverCommon.validateMinMax(FFormat.F4, randomValueMin, value))
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0014, "Max"));
                        }
                    }
                    else
                    {
                        if (!FOpcDriverCommon.validateFormatRange(fFormat, value))
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0014, "Max"));
                        }

                        if (!FOpcDriverCommon.validateMinMax(fFormat, randomValueMin, value))
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0014, "Max"));
                        }
                    }
                    

                    this.fXmlNode.set_attrVal(FXmlTagHIT.A_RandomValueMax, FXmlTagHIT.D_RandomValueMax, value, true);
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
                    if (this.fXmlNode.get_attrVal(FXmlTagHIT.A_Transformer, FXmlTagHIT.D_Transformer) == string.Empty)
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
                    if (this.fXmlNode.get_attrVal(FXmlTagHIT.A_DataConversionSetID, FXmlTagHIT.D_DataConversionSetID) == string.Empty)
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
                    if (this.fXmlNode.get_attrVal(FXmlTagHIT.A_Precondition, FXmlTagHIT.D_Precondition) == string.Empty)
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
                    // Host Item Format이 List인 경우에만 Child Item을 가질 수 있다.                     
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

        public FHostLibrary fAncestorHostLibrary
        {
            get
            {
                try
                {
                    return this.getAncestorHostLibrary();
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

        public FHostMessage fAncestorHostMessage
        {
            get
            {
                try
                {
                    return this.getAncestorHostMessage();
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
                FHostMessage fHmg = null;
                string xpath = string.Empty;

                try
                {
                    fHmg = this.fAncestorHostMessage;
                    if (fHmg == null)
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
                            "/" + FXmlTagHTR.E_HostTrigger +
                            "/" + FXmlTagHCN.E_HostCondition +
                            "//" + FXmlTagHEP.E_HostExpression + "[@" + FXmlTagHEP.A_OperandId + "='" + this.uniqueIdToString + "']";
                    }
                    // --
                    return new FObjectCollection(this.fOcdCore, fHmg.fXmlNode.selectNodes(xpath));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    fHmg = null;
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
                    return new FObjectCollection(this.fOcdCore, this.fXmlNode.selectNodes("NULL"));
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
                        !FClipboard.containsData(FCbObjectFormat.HostItem)
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
                        !FClipboard.containsData(FCbObjectFormat.HostItem) ||
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
                        info.Append("[" + length.ToString() +"] " + this.name);
                    }
                    else if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2)
                    {
                        value = FValueConverter.toDataConversionedEncodingValue(
                             fFormat,
                             this.originalStringValue,
                             this.fXmlNode.get_attrVal(FXmlTagHIT.A_Transformer, FXmlTagHIT.D_Transformer),
                             this.fXmlNode.get_attrVal(FXmlTagHIT.A_DataConversionSetExpression, FXmlTagHIT.D_DataConversionSetExpression),
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
                            this.fXmlNode.get_attrVal(FXmlTagHIT.A_Transformer, FXmlTagHIT.D_Transformer),
                            this.fXmlNode.get_attrVal(FXmlTagHIT.A_DataConversionSetExpression, FXmlTagHIT.D_DataConversionSetExpression),
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

        public FHostItem appendChildHostItem(
            FHostItem fNewChild
            )
        {
            try
            {
                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                // --
                // ***
                // Format이 List인 Host Item만이 Child HostItem을 가질 수 있다.
                // ***
                if (this.fFormat != FFormat.List && this.fFormat != FFormat.AsciiList)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Item's Format", "List or the AsciiList"));
                }

                // ***
                // Format이 AsciiList인 경우 Ascii Format의 Child Host Item만을 가질 수 있다.
                // ***
                if (this.fFormat == FFormat.AsciiList && fNewChild.fFormat != FFormat.Ascii)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Format of New Child", "Ascii"));
                }

                // --

                fNewChild.replace(this.fOcdCore, this.fXmlNode.appendChild(fNewChild.fXmlNode));

                // --

                // ***
                // 현재 Host Item의 Length 1 증가
                // ***
                this.fXmlNode.set_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length, (this.originalLength + 1).ToString());

                // --
                
                if (this.isModelingObject)
                {
                    FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fOcdCore.fEventPusher.pushEvent(new FEventArgsBase[]{
                        new FObjectEventArgs(FEventId.ObjectAppendCompleted, this.fOpcDriver, this, fNewChild),
                        new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fOpcDriver, this.fParent, this)
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

        public FHostItem appendChildHostItem(
            FOpcDriver fOpcDriver,
            string name,
            FFormat fFormat,
            string stringValue
            )
        {
            try
            {
                return appendChildHostItem(new FHostItem(fOpcDriver, name, fFormat, stringValue));
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

        public FHostItem insertBeforeChildHostItem(
            FHostItem fNewChild,
            FHostItem fRefChild
            )
        {
            try
            {
                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);
                // --
                if (this.fFormat != FFormat.List && this.fFormat != FFormat.AsciiList)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Item's Format", "List or the AsciiList"));
                }

                // ***
                // Format이 AsciiList인 경우 Ascii Format의 Child Host Item만을 가질 수 있다.
                // ***
                if (this.fFormat == FFormat.AsciiList && fNewChild.fFormat != FFormat.Ascii)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Format of New Child", "Ascii"));
                }

                // --

                fNewChild.replace(this.fOcdCore, this.fXmlNode.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));

                // --

                // ***
                // 현재 Host Item의 Length 1 증가
                // ***
                this.fXmlNode.set_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length, (this.originalLength + 1).ToString());

                // --
                
                // ***
                // 추가된 Child의 Previous Host Item과 Next Host Item의 Pattern이 Variable일 경우,
                // 추가된 Child의 Pattern를 Variable로 설정한다.
                // ***                
                if (
                    (fNewChild.fPreviousSibling != null && fNewChild.fPreviousSibling.fPattern == FPattern.Variable) &&
                    (fNewChild.fNextSibling != null && fNewChild.fNextSibling.fPattern == FPattern.Variable)
                    )
                {
                    fNewChild.fXmlNode.set_attrVal(FXmlTagHIT.A_Pattern, FXmlTagHIT.D_Pattern, FEnumConverter.fromPattern(FPattern.Variable));
                }

                // --                
                               
                if (this.isModelingObject)
                {
                    FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --                    
                    this.fOcdCore.fEventPusher.pushEvent(new FEventArgsBase[]{
                        new FObjectEventArgs(FEventId.ObjectInsertBeforeCompleted, this.fOpcDriver, this, fNewChild),
                        new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fOpcDriver, this.fParent, this)
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

        public FHostItem insertBeforeChildHostItem(
            FOpcDriver fOpcDriver,
            string name,
            FFormat fFromat,
            string stringValue,
            FHostItem fRefChild
            )
        {
            try
            {
                return insertBeforeChildHostItem(
                    new FHostItem(fOpcDriver, name, fFormat, stringValue),
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

        public FHostItem insertAfterChildHostItem(
            FHostItem fNewChild,
            FHostItem fRefChild
            )
        {
            try
            {
                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);
                // --
                if (this.fFormat != FFormat.List && this.fFormat != FFormat.AsciiList)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Item's Format", "List or AsciiList"));
                }

                // ***
                // Format이 AsciiList인 경우 Ascii Format의 Child Host Item만을 가질 수 있다.
                // ***
                if (this.fFormat == FFormat.AsciiList && fNewChild.fFormat != FFormat.Ascii)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Format of New Child", "Ascii"));
                }

                // --

                fNewChild.replace(this.fOcdCore, this.fXmlNode.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));

                // --

                // ***
                // 현재 Host Item의 Length 1 증가
                // ***
                this.fXmlNode.set_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length, (this.originalLength + 1).ToString());

                // --
                
                // ***
                // 추가된 Child의 Previous Host Item과 Next Host Item의 Pattern이 Variable일 경우,
                // 추가된 Child의 Pattern를 Variable로 설정한다.
                // ***                
                if (
                    (fNewChild.fPreviousSibling != null && fNewChild.fPreviousSibling.fPattern == FPattern.Variable) &&
                    (fNewChild.fNextSibling != null && fNewChild.fNextSibling.fPattern == FPattern.Variable)
                    )
                {
                    fNewChild.fXmlNode.set_attrVal(FXmlTagHIT.A_Pattern, FXmlTagHIT.D_Pattern, FEnumConverter.fromPattern(FPattern.Variable));
                }

                // --                
                            
                if (this.isModelingObject)
                {
                    FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --                    
                    this.fOcdCore.fEventPusher.pushEvent(new FEventArgsBase[]{
                        new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this.fOpcDriver, this, fNewChild),
                        new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fOpcDriver, this.fParent, this)
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

        public FHostItem insertAfterChildHostItem(
            FOpcDriver fOpcDriver,
            string name,
            FFormat fFormat,
            string stringValue,
            FHostItem fRefChild
            )
        {
            try
            {
                return insertAfterChildHostItem(
                    new FHostItem(fOpcDriver, name, fFormat, stringValue),
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
                FOpcDriverCommon.validateRemoveChildObject(this.fXmlNode.fParentNode, this.fXmlNode);                

                // --

                resetRelation();

                // --

                isModelingObject = this.isModelingObject;
                fParent = this.fParent;
                if (fParent.fObjectType == FObjectType.HostMessage)
                {
                    this.replace(this.fOcdCore, ((FHostMessage)fParent).fXmlNode.removeChild(this.fXmlNode));
                }
                else if (fParent.fObjectType == FObjectType.HostMessageTransfer)
                {
                    this.replace(this.fOcdCore, ((FHostMessageTransfer)fParent).fXmlNode.removeChild(this.fXmlNode));
                }
                else if (fParent.fObjectType == FObjectType.HostDriverDataMessage)
                {
                    this.replace(this.fOcdCore, ((FHostDriverDataMessage)fParent).fXmlNode.removeChild(this.fXmlNode));
                }
                else
                {
                    this.replace(this.fOcdCore, ((FHostItem)fParent).fXmlNode.removeChild(this.fXmlNode));
                    // --
                    length = int.Parse(((FHostItem)fParent).fXmlNode.get_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length)) - 1;
                    ((FHostItem)fParent).fXmlNode.set_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length, length.ToString());
                }

                // --

                // ***
                // Remove 시, Pattern(Fixed)과 Fixed Length(1) 초기화
                // ***
                this.fXmlNode.set_attrVal(FXmlTagHIT.A_Pattern, FXmlTagHIT.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));
                this.fXmlNode.set_attrVal(FXmlTagHIT.A_FixedLength, FXmlTagHIT.D_FixedLength, "1");

                // --

                if (isModelingObject)
                {
                    if (fParent.fObjectType == FObjectType.HostMessage)
                    {
                        this.fOcdCore.fEventPusher.pushEvent(
                            new FObjectEventArgs(FEventId.ObjectRemoveCompleted, this.fOpcDriver, fParent, this)
                            );
                    }
                    else
                    {
                        this.fOcdCore.fEventPusher.pushEvent(new FEventArgsBase[]{
                            new FObjectEventArgs(FEventId.ObjectRemoveCompleted, this.fOpcDriver, fParent, this),
                            new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fOpcDriver, ((FHostItem)fParent).fParent, fParent)
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

        public FHostItem removeChildHostItem(
            FHostItem fChild
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

        public void removeChildHostItem(
            FHostItem[] fChilds
            )
        {
            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                foreach (FHostItem fHit in fChilds)
                {
                    FOpcDriverCommon.validateRemoveChildObject(this.fXmlNode, fHit.fXmlNode);
                }

                // --

                foreach (FHostItem fHit in fChilds)
                {
                    fHit.remove();
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

        public void removeAllChildHostItem(
            )
        {
            FHostItemCollection fHitCollection = null;

            try
            {
                fHitCollection = this.fChildHostItemCollection;
                if (fHitCollection.count == 0)
                {
                    return;
                }

                // --

                foreach (FHostItem fHit in fHitCollection)
                {
                    if (fHit.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }
                }

                // --

                foreach (FHostItem fHit in fHitCollection)
                {
                    fHit.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fHitCollection != null)
                {
                    fHitCollection.Dispose();
                    fHitCollection = null;
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
                FOpcDriverCommon.validateMoveUpObject(this.fXmlNode);
                // --
                if (!this.canMoveUp)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0021, "Object"));
                }

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fOcdCore, this.fXmlNode.moveUp());

                // --

                if (isModelingObject)
                {
                    this.fOcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveUpCompleted, this.fOpcDriver, fParent, this)
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
                FOpcDriverCommon.validateMoveDownObject(this.fXmlNode);
                // -- 
                if (!this.canMoveDown)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0022, "Object"));
                }

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fOcdCore, this.fXmlNode.moveDown());

                // --

                if (isModelingObject)
                {
                    this.fOcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveDownCompleted, this.fOpcDriver, fParent, this)
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
            FHostItem fRefObject
            )
        {
            FIObject fOldParent = null;

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

                if (!this.fAncestorHostMessage.Equals(fRefObject.fAncestorHostMessage))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Ancestor Host Message", "same"));
                }

                if (this.containsObject(fRefObject))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0060, "Object", "Child"));
                }

                if (
                    (fRefObject.fParent.fObjectType == FObjectType.HostMessage && ((FHostMessage)fRefObject.fParent).hasVariableChild) ||
                    (fRefObject.fParent.fObjectType == FObjectType.HostItem && ((FHostItem)fRefObject.fParent).hasVariableChild)
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
                                FDebug.throwFException(string.Format(FConstants.err_m_0011, "Pattern of the Previous Host Item and the Next Host Item", "Variable"));
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
                            FDebug.throwFException(string.Format(FConstants.err_m_0010, "Pattern of the Previous Host Item and the Next Host Item", "Variable"));
                        }
                    }
                }

                // --

                fOldParent = this.fParent;

                // --                

                this.replace(this.fOcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fOcdCore, fRefObject.fXmlNode.fParentNode.insertAfter(this.fXmlNode, fRefObject.fXmlNode));

                // --

                if (!this.fParent.Equals(fOldParent))
                {
                    if (this.locked)
                    {
                        if (fOldParent.fObjectType == FObjectType.HostItem)                        
                        {
                            ((FHostItem)fOldParent).unlockObject();
                        }
                        // --
                        if (this.fParent.fObjectType == FObjectType.HostItem)                        
                        {
                            ((FHostItem)this.fParent).lockObject();
                        }
                    }

                    // --

                    if (fOldParent.fObjectType == FObjectType.HostItem)
                    {
                        ((FHostItem)fOldParent).fXmlNode.set_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length, (((FHostItem)fOldParent).length - 1).ToString(), true);
                    }
                    // --
                    if (this.fParent.fObjectType == FObjectType.HostItem)
                    {
                        ((FHostItem)this.fParent).fXmlNode.set_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length, (((FHostItem)this.fParent).length + 1).ToString(), true);
                    }
                }

                // --

                this.fOcdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fOpcDriver, this, fRefObject)
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
            FHostMessage fRefObject
            )
        {
            FIObject fOldParent = null;

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

                if (!this.fAncestorHostMessage.Equals(fRefObject))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Host Item", "child"));
                }

                if (fRefObject.fChildHostItemCollection.count > 0)
                {
                    if (this.Equals(fRefObject.fChildHostItemCollection[fRefObject.fChildHostItemCollection.count - 1]))
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0060, "Object", "same localtion"));
                    }
                }

                if (fRefObject.hasVariableChild)
                {
                    if (this.fPattern == FPattern.Variable)
                    {
                        if (fRefObject.fChildHostItemCollection[fRefObject.fChildHostItemCollection.count - 1].fPattern != FPattern.Variable)
                        {
                            if (
                                !this.fParent.Equals(fRefObject) ||
                                (this.fPreviousSibling != null && this.fPreviousSibling.fPattern == FPattern.Variable) ||
                                (this.fNextSibling != null && this.fNextSibling.fPattern == FPattern.Variable)
                                )
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0011, "Pattern of the Previous Host Item and the Next Host Item", "Variable"));
                            }
                        }
                    }
                }

                // --      

                fOldParent = this.fParent;

                // --

                this.replace(this.fOcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fOcdCore, fRefObject.fXmlNode.appendChild(this.fXmlNode));

                // --

                if (!this.fParent.Equals(fOldParent))
                {
                    if (this.locked)
                    {
                        ((FHostItem)fOldParent).unlockObject();
                        fRefObject.lockObject();
                    }
                    // --
                    ((FHostItem)fOldParent).fXmlNode.set_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length, (((FHostItem)fOldParent).length - 1).ToString(), true);
                }

                // --

                this.fOcdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fOpcDriver, this, fRefObject)
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
                this.fXmlNode.set_attrVal(FXmlTagHIT.A_Value, FXmlTagHIT.D_Value, FXmlTagHIT.D_Value);
                this.fXmlNode.set_attrVal(FXmlTagHIT.A_Length, FXmlTagHIT.D_Length, FXmlTagHIT.D_Length);
                // --
                this.fXmlNode.set_attrVal(FXmlTagHIT.A_Transformer, FXmlTagHIT.D_Transformer, FXmlTagHIT.D_Transformer);
                // --
                this.fXmlNode.set_attrVal(FXmlTagHIT.A_Precondition, FXmlTagHIT.D_Precondition, FXmlTagHIT.D_Precondition);
                // --
                this.fXmlNode.set_attrVal(FXmlTagHIT.A_RandomValue, FXmlTagHIT.D_RandomValue, FXmlTagHIT.D_RandomValue);
                this.fXmlNode.set_attrVal(FXmlTagHIT.A_RandomValueMin, FXmlTagHIT.D_RandomValueMin, FXmlTagHIT.D_RandomValueMin);
                this.fXmlNode.set_attrVal(FXmlTagHIT.A_RandomValueMax, FXmlTagHIT.D_RandomValueMax, FXmlTagHIT.D_RandomValueMax);

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
                // Host Item에 대한 Lock 처리
                // ***
                this.fXmlNode.set_attrVal(FXmlTagHIT.A_Locked, FXmlTagHIT.D_Locked, FBoolean.True, true);

                // --

                // ***
                // Parent Host Item에 대한 Lock 처리
                // ***
                if (this.fParent.fObjectType == FObjectType.HostItem)
                {
                    ((FHostItem)this.fParent).lockObject();
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
                // Lock이 설정된 자식 Host Item이 존재할 경우 Unlock 작업을 취소한다.
                // ***
                xpath = FXmlTagHIT.E_HostItem + "[@" + FXmlTagHIT.A_Locked + "='" + FBoolean.True + "']";
                if (this.fXmlNode.containsNode(xpath))
                {
                    return;
                }

                // ***
                // Host Item이 Host Expression에 사용되었을 경우 Unlock 작업을 취소한다.
                // ***
                xpath =
                    FXmlTagEQM.E_EquipmentModeling +
                    "/" + FXmlTagEQP.E_Equipment +
                    "/" + FXmlTagSNG.E_ScenarioGroup +
                    "/" + FXmlTagSNR.E_Scenario +
                    "/" + FXmlTagHTR.E_HostTrigger +
                    "/" + FXmlTagHCN.E_HostCondition +
                    "//" + FXmlTagHEP.E_HostExpression + "[@" + FXmlTagHEP.A_OperandId + "='" + this.uniqueIdToString + "']";
                if (this.fOpcDriver.fXmlNode.containsNode(xpath))
                {
                    return;
                }

                // --

                // ***
                // Host Item에 대한 Unlock 처리
                // ***
                this.fXmlNode.set_attrVal(FXmlTagHIT.A_Locked, FXmlTagHIT.D_Locked, FBoolean.False, true);

                // --

                // ***
                // Parent Host Item에 대한 Unlcok 처리
                // ***
                if (this.fParent.fObjectType == FObjectType.HostItem)
                {
                    ((FHostItem)this.fParent).unlockObject();
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
                FOpcDriverCommon.validateCutObject(this.fXmlNode);

                // --

                this.remove();

                // --

                resetFlowNode(this.fXmlNode);
                this.copyObject(FCbObjectFormat.HostItem, this.fXmlNode);
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
                fXmlNode.set_attrVal(FXmlTagHIT.A_Pattern, FXmlTagHIT.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));
                fXmlNode.set_attrVal(FXmlTagHIT.A_FixedLength, FXmlTagHIT.D_FixedLength, "1");

                // --

                resetFlowNode(fXmlNode);
                this.copyObject(FCbObjectFormat.HostItem, fXmlNode);
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

        public FHostItem pasteSibling(
            )
        {
            FIObject fParent = null;
            FHostItem fHostItem = null;

            try
            {
                FOpcDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.HostItem);

                // --

                fParent = this.fParent;
                fHostItem = (FHostItem)this.pasteObject(FCbObjectFormat.HostItem);
                if (fParent.fObjectType == FObjectType.HostMessage)
                {
                    return ((FHostMessage)fParent).insertAfterChildHostItem(fHostItem, this);
                }
                else if (fParent.fObjectType == FObjectType.HostMessageTransfer)
                {
                    return ((FHostMessageTransfer)fParent).insertAfterChildHostItem(fHostItem, this);
                }
                else if (fParent.fObjectType == FObjectType.HostDriverDataMessage)
                {
                    return ((FHostDriverDataMessage)fParent).insertAfterChildHostItem(fHostItem, this);
                }
                return ((FHostItem)fParent).insertAfterChildHostItem(fHostItem, this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fParent = null;
                fHostItem = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostItem pasteChild(
            )
        {
            FHostItem fHostItem = null;

            try
            {
                FOpcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.HostItem);

                // --

                fHostItem = (FHostItem)this.pasteObject(FCbObjectFormat.HostItem);
                return this.appendChildHostItem(fHostItem);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fHostItem = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostItemCollection selectHostItemByName(
            string name
            )
        {
            const string xpath = FXmlTagHIT.E_HostItem + "[@" + FXmlTagHIT.A_Name + "='{0}']";

            try
            {
                return new FHostItemCollection(
                    this.fOcdCore,
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

        public FHostItem selectSingleHostItemByName(
            string name
            )
        {
            const string xpath = FXmlTagHIT.E_HostItem + "[@" + FXmlTagHIT.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FHostItem(this.fOcdCore, fXmlNode);
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

        public FHostItemCollection selectAllHostItemByName(
            string name
            )
        {
            const string xpath = ".//" + FXmlTagHIT.E_HostItem + "[@" + FXmlTagHIT.A_Name + "='{0}']";

            try
            {
                return new FHostItemCollection(
                    this.fOcdCore,
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

        public FHostItem selectSingleAllHostItemByName(
            string name
            )
        {
            const string xpath = ".//" + FXmlTagHIT.E_HostItem + "[@" + FXmlTagHIT.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FHostItem(this.fOcdCore, fXmlNode);
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

        public FHostItemCollection selectHostItemByReservedWord(
            string reservedWord
            )
        {
            const string xpath = FXmlTagHIT.E_HostItem + "[@" + FXmlTagHIT.A_ReservedWord + "='{0}']";

            try
            {
                return new FHostItemCollection(
                    this.fOcdCore,
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

        public FHostItem selectSingleHostItemByReservedWord(
            string reservedWord
            )
        {
            const string xpath = FXmlTagHIT.E_HostItem + "[@" + FXmlTagHIT.A_ReservedWord + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, reservedWord));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FHostItem(this.fOcdCore, fXmlNode);
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

        public FHostItemCollection selectAllHostItemByReservedWord(
            string reservedWord
            )
        {
            const string xpath = ".//" + FXmlTagHIT.E_HostItem + "[@" + FXmlTagHIT.A_ReservedWord + "='{0}']";

            try
            {
                return new FHostItemCollection(
                    this.fOcdCore,
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

        public FHostItem selectSingleAllHostItemByReservedWord(
            string reservedWord
            )
        {
            const string xpath = ".//" + FXmlTagHIT.E_HostItem + "[@" + FXmlTagHIT.A_ReservedWord + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, reservedWord));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FHostItem(this.fOcdCore, fXmlNode);
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

        public FHostItemCollection selectHostItemByExtraction(
            )
        {
            const string xpath = FXmlTagHIT.E_HostItem + "[@" + FXmlTagHIT.A_Extraction + "='{0}']";

            try
            {
                return new FHostItemCollection(
                    this.fOcdCore,
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

        public FHostItem selectSingleHostItemByExtraction(
            )
        {
            const string xpath = FXmlTagHIT.E_HostItem + "[@" + FXmlTagHIT.A_Extraction + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, FBoolean.True));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FHostItem(this.fOcdCore, fXmlNode);
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

        public FHostItemCollection selectAllHostItemByExtraction(
            )
        {
            const string xpath = ".//" + FXmlTagHIT.E_HostItem + "[@" + FXmlTagHIT.A_Extraction + "='{0}']";

            try
            {
                return new FHostItemCollection(
                    this.fOcdCore,
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

        public FHostItem selectSingleAllHostItemByExtraction(
            )
        {
            const string xpath = ".//" + FXmlTagHIT.E_HostItem + "[@" + FXmlTagHIT.A_Extraction + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, FBoolean.True));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FHostItem(this.fOcdCore, fXmlNode);
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

        public FHostItem selectSingleAllHostItemByIndex(
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
                return new FHostItem(this.fOcdCore, fXmlNode);
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
                // 이 Host Item 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Host Item", "Modeling File"));
                }

                // ***
                // Data Conversion Set와 Host Item의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fDataConversionSet))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the Data Conversion Set and the Host Item", "same"));
                }

                // --

                fFormat = this.fFormat;
                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0006, fFormat.ToString() + " Format", "Data Conversion Set"));
                }

                // --

                oldDcsId = this.fXmlNode.get_attrVal(FXmlTagHIT.A_DataConversionSetID, FXmlTagHIT.D_DataConversionSetID);
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

                this.fXmlNode.set_attrVal(FXmlTagHIT.A_DataConversionSetExpression, FXmlTagHIT.D_DataConversionSetExpression, fDataConversionSet.expression, false);
                this.fXmlNode.set_attrVal(FXmlTagHIT.A_DataConversionSetName, FXmlTagHIT.D_DataConversionSetName, fDataConversionSet.name, false);
                this.fXmlNode.set_attrVal(FXmlTagHIT.A_DataConversionSetID, FXmlTagHIT.D_DataConversionSetID, newDcsId, true);
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
                foreach (FHostItem fHit in this.fChildHostItemCollection)
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

                this.fXmlNode.set_attrVal(FXmlTagHIT.A_DataConversionSetExpression, FXmlTagHIT.D_DataConversionSetExpression, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagHIT.A_DataConversionSetName, FXmlTagHIT.D_DataConversionSetName, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagHIT.A_DataConversionSetID, FXmlTagHIT.D_DataConversionSetID, string.Empty, isModifyEvent);
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
                fXmlNode.set_attrVal(FXmlTagHIT.A_DataConversionSetExpression, FXmlTagHIT.D_DataConversionSetExpression, string.Empty);
                fXmlNode.set_attrVal(FXmlTagHIT.A_DataConversionSetName, FXmlTagHIT.D_DataConversionSetName, string.Empty);
                fXmlNode.set_attrVal(FXmlTagHIT.A_DataConversionSetID, FXmlTagHIT.D_DataConversionSetID, string.Empty);

                // --

                foreach (FXmlNode fXmlNodeHit in fXmlNode.selectNodes(FXmlTagHIT.E_HostItem))
                {
                    FHostItem.resetFlowNode(fXmlNodeHit);
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
        public FHostItem clone(
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
                fXmlNode.set_attrVal(FXmlTagHIT.A_Pattern, FXmlTagHIT.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));
                fXmlNode.set_attrVal(FXmlTagHIT.A_FixedLength, FXmlTagHIT.D_FixedLength, "1");

                // --

                resetFlowNode(fXmlNode);
                FOpcDriverCommon.resetLocked(fXmlNode);
                return new FHostItem(this.fOcdCore, fXmlNode);
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
