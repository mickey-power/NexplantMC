/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FOpcItem.cs
--  Creator         : heonsik
--  Create Date     : 2013.07.15
--  Description     : FAMate Core FaOpcDriver OPC Item Class 
--  History         : Created by heonsik at 2013.07.15
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    public class FOpcItem : FBaseObject<FOpcItem>, FIObject, FIOpcOperand
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FOpcItem(
            FOpcDriver fOpcDriver
            )
            : base(fOpcDriver.fOcdCore, FOpcDriverCommon.createXmlNodeOIT(fOpcDriver.fOcdCore.fXmlDoc))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FOpcItem(
            FOcdCore fOcdCore,
            FXmlNode fXmlNode
            )
            : base(fOcdCore, fXmlNode)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FOpcItem(
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
                    return FObjectType.OpcItem;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.OpcDriver;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOpcOperandType fOpcOperandType
        {
            get
            {
                try
                {
                    return FOpcOperandType.OpcItem;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOIT.A_UniqueId, FXmlTagOIT.D_UniqueId);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagOIT.A_Locked, FXmlTagOIT.D_Locked));
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
                    return this.fXmlNode.get_attrVal(FXmlTagOIT.A_Name, FXmlTagOIT.D_Name);
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

                    this.fXmlNode.set_attrVal(FXmlTagOIT.A_Name, FXmlTagOIT.D_Name, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOIT.A_Description, FXmlTagOIT.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagOIT.A_Description, FXmlTagOIT.D_Description, value, true);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagOIT.A_FontColor, FXmlTagOIT.D_FontColor));
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
                    this.fXmlNode.set_attrVal(FXmlTagOIT.A_FontColor, FXmlTagOIT.D_FontColor, value.Name, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagOIT.A_FontBold, FXmlTagOIT.D_FontBold));
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
                    this.fXmlNode.set_attrVal(FXmlTagOIT.A_FontBold, FXmlTagOIT.D_FontBold, FBoolean.fromBool(value), true);
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

        public string itemName
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOIT.A_ItemName, FXmlTagOIT.D_ItemName);
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
                    if (value.Trim() == string.Empty)
                    {
                        FDebug.throwFException(FConstants.err_m_0002);
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagOIT.A_ItemName, FXmlTagOIT.D_ItemName, value, true);
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

        public FTagFormat fItemFormat
        {
            get
            {
                try
                {
                    return FEnumConverter.toTagFormat(this.fXmlNode.get_attrVal(FXmlTagOIT.A_ItemFormat, FXmlTagOIT.D_ItemFormat));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FTagFormat.Boolean;
            }

            set
            {
                try
                {
                    if (this.fItemFormat == value)
                    {
                        return;
                    }

                    // --                   

                    this.fXmlNode.set_attrVal(FXmlTagOIT.A_ItemFormat, FXmlTagOIT.D_ItemFormat, FEnumConverter.fromTagFormat(value), true);
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

        public bool itemArray
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagOIT.A_ItemArray, FXmlTagOIT.D_ItemArray));
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
                    this.fXmlNode.set_attrVal(FXmlTagOIT.A_ItemArray, FXmlTagOIT.D_ItemArray, FBoolean.fromBool(value), true);
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

        public int itemStart
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagOIT.A_ItemStart, FXmlTagOIT.D_ItemStart));
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
                    if (value < 0)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Item Start"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagOIT.A_ItemStart, FXmlTagOIT.D_ItemStart, value.ToString(), true);
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

        public int itemLength
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagOIT.A_ItemLength, FXmlTagOIT.D_ItemLength));
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
                    if (value < 1)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Item Start"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagOIT.A_ItemLength, FXmlTagOIT.D_ItemLength, value.ToString(), true);
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

        public int length
        {
            get
            {
                try
                {
                    int length = 0;

                    try
                    {
                        length = this.originalLength;
                        FValueConverter.toDataConversionStringValue(
                            (FFormat)this.fFormat,
                            this.originalStringValue,
                            this.fXmlNode.get_attrVal(FXmlTagOIT.A_Transformer, FXmlTagOIT.D_Transformer),
                            this.fXmlNode.get_attrVal(FXmlTagOIT.A_DataConversionSetExpression, FXmlTagOIT.D_DataConversionSetExpression),
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

        public FOpcFormat fFormat
        {
            get
            {
                try
                {
                    return FEnumConverter.toOpcFormat(this.fXmlNode.get_attrVal(FXmlTagOIT.A_Format, FXmlTagOIT.D_Format));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FOpcFormat.Ascii;
            }

            set
            {
                string val = string.Empty;

                try
                {
                    if (this.fFormat == value)
                    {
                        return;
                    }

                    // --

                    // ***
                    // Locked되어 있는 OPC Item의 Format은 변경할 수 없다.
                    // ***
                    if (this.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }

                    // --


                    setChangedFormat();
                    this.fXmlNode.set_attrVal(FXmlTagOIT.A_Format, FXmlTagOIT.D_Format, FEnumConverter.fromOpcFormat(value), true);
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
                    return FEnumConverter.toDataScanMode(this.fXmlNode.get_attrVal(FXmlTagOIT.A_ScanMode, FXmlTagOIT.D_ScanMode));
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
                    fXmlNode.set_attrVal(FXmlTagOIT.A_ScanMode, FXmlTagOIT.D_ScanMode, FEnumConverter.fromDataScanMode(value), true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOIT.A_Value, FXmlTagOIT.D_Value);
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
                int length = 0;
                string val = string.Empty;

                try
                {
                    val = FOpcValueConverter.fromStringValue(this.fFormat, value, out length);
                    // --
                    this.fXmlNode.set_attrVal(FXmlTagOIT.A_Length, FXmlTagOIT.D_Length, length.ToString());
                    this.fXmlNode.set_attrVal(FXmlTagOIT.A_Value, FXmlTagOIT.D_Value, val, true);                    
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
                    return FOpcValueConverter.toStringArrayValue(this.fFormat, this.originalStringValue);
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
                int length = 0;
                string val = string.Empty;

                try
                {
                    val = FOpcValueConverter.fromStringArrayValue(fFormat, value, out length);
                    // --
                    this.fXmlNode.set_attrVal(FXmlTagOIT.A_Length, FXmlTagOIT.D_Length, length.ToString());
                    this.fXmlNode.set_attrVal(FXmlTagOIT.A_Value, FXmlTagOIT.D_Value, val, true);                    
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
                    return FOpcValueConverter.toValue(this.fFormat, this.originalStringValue, this.originalLength );
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
                int length = 0;
                string val = string.Empty;

                try
                {
                    val = FOpcValueConverter.fromValue(fFormat, value, out length);
                    // --
                    this.fXmlNode.set_attrVal(FXmlTagOIT.A_Length, FXmlTagOIT.D_Length, length.ToString());
                    this.fXmlNode.set_attrVal(FXmlTagOIT.A_Value, FXmlTagOIT.D_Value, val, true);
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
                    return FOpcValueConverter.toEncodingValue(this.fFormat, this.originalStringValue);
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
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagOIT.A_Length, FXmlTagOIT.D_Length));
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
                        (FFormat)this.fFormat,
                        this.originalStringValue,
                        this.fXmlNode.get_attrVal(FXmlTagOIT.A_Transformer, FXmlTagOIT.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagOIT.A_DataConversionSetExpression, FXmlTagOIT.D_DataConversionSetExpression),
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
                        (FFormat)this.fFormat,
                        this.originalStringValue,
                        this.fXmlNode.get_attrVal(FXmlTagOIT.A_Transformer, FXmlTagOIT.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagOIT.A_DataConversionSetExpression, FXmlTagOIT.D_DataConversionSetExpression)
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
                        (FFormat)this.fFormat,
                        this.originalStringValue,
                        this.fXmlNode.get_attrVal(FXmlTagOIT.A_Transformer, FXmlTagOIT.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagOIT.A_DataConversionSetExpression, FXmlTagOIT.D_DataConversionSetExpression),
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
                        (FFormat)this.fFormat,
                        this.originalStringValue,
                        this.fXmlNode.get_attrVal(FXmlTagOIT.A_Transformer, FXmlTagOIT.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagOIT.A_DataConversionSetExpression, FXmlTagOIT.D_DataConversionSetExpression)
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

        public Type valueType
        {
            get
            {
                try
                {
                    return FOpcValueConverter.getValueType(this.fFormat);
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

        public bool isArrayValue
        {
            get
            {   
                try
                {
                    if (this.fFormat == FOpcFormat.Ascii)
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

        public FOpcItemValueTransformer fValueTransformer
        {
            get
            {
                try
                {
                    return new FOpcItemValueTransformer(this);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOIT.A_ReservedWord, FXmlTagOIT.D_ReservedWord);
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
                    this.fXmlNode.set_attrVal(FXmlTagOIT.A_ReservedWord, FXmlTagOIT.D_ReservedWord, value, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagOIT.A_Extraction, FXmlTagOIT.D_Extraction));
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
                    fXmlNode.set_attrVal(FXmlTagOIT.A_Extraction, FXmlTagOIT.D_Extraction, FBoolean.fromBool(value), true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagOIT.A_HashTag, FXmlTagOIT.D_HashTag));
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
                    fXmlNode.set_attrVal(FXmlTagOIT.A_HashTag, FXmlTagOIT.D_HashTag, FBoolean.fromBool(value), true);
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
                    id = this.fXmlNode.get_attrVal(FXmlTagOIT.A_DataConversionSetID, FXmlTagOIT.D_DataConversionSetID);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOIT.A_DataConversionSetName, FXmlTagOIT.D_DataConversionSetName);
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
                    this.fXmlNode.set_attrVal(FXmlTagOIT.A_DataConversionSetName, FXmlTagOIT.D_DataConversionSetName, value, false);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOIT.A_DataConversionSetExpression, FXmlTagOIT.D_DataConversionSetExpression);
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
                    this.fXmlNode.set_attrVal(FXmlTagOIT.A_DataConversionSetExpression, FXmlTagOIT.D_DataConversionSetExpression, value, false);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOIT.A_UserTag1, FXmlTagOIT.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagOIT.A_UserTag1, FXmlTagOIT.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOIT.A_UserTag2, FXmlTagOIT.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagOIT.A_UserTag2, FXmlTagOIT.D_UserTag2, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOIT.A_UserTag3, FXmlTagOIT.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagOIT.A_UserTag3, FXmlTagOIT.D_UserTag3, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOIT.A_UserTag4, FXmlTagOIT.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagOIT.A_UserTag4, FXmlTagOIT.D_UserTag4, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOIT.A_UserTag5, FXmlTagOIT.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagOIT.A_UserTag5, FXmlTagOIT.D_UserTag5, value, true);
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

        public FOpcItemList fParent
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

                    return new FOpcItemList(this.fOcdCore, this.fXmlNode.fParentNode);
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

        public FOpcItem fPreviousSibling
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

                    return new FOpcItem(this.fOcdCore, this.fXmlNode.fPreviousSibling);
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

        public FOpcItem fNextSibling
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

                    return new FOpcItem(this.fOcdCore, this.fXmlNode.fNextSibling);
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

        public bool randomValue
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagOIT.A_RandomValue, FXmlTagOIT.D_RandomValue));
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
                    if (fFormat == FOpcFormat.Ascii)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, fFormat.ToString() + " Format", "Random Value"));
                    }

                    // --

                    if (value == true)
                    {
                        minValue = FValueConverter.getDataTypeMin(this.valueType);
                        maxValue = FValueConverter.getDataTypeMax(this.valueType);
                    }

                    this.fXmlNode.set_attrVal(FXmlTagOIT.A_RandomValueMin, FXmlTagOIT.D_RandomValueMin, minValue, false);
                    this.fXmlNode.set_attrVal(FXmlTagOIT.A_RandomValueMax, FXmlTagOIT.D_RandomValueMax, maxValue, false);
                    // --
                    this.fXmlNode.set_attrVal(FXmlTagOIT.A_RandomValue, FXmlTagOIT.D_RandomValue, FBoolean.fromBool(value), true); 
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
                    return this.fXmlNode.get_attrVal(FXmlTagOIT.A_RandomValueMin, FXmlTagOIT.D_RandomValueMin);
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

                    if (fFormat == FOpcFormat.F8) 
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
                        if (!FOpcDriverCommon.validateFormatRange((FFormat)fFormat, value))
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0014, "Min"));
                        }

                        if (!FOpcDriverCommon.validateMinMax((FFormat)fFormat, value, randomValueMax))
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
                    return this.fXmlNode.get_attrVal(FXmlTagOIT.A_RandomValueMax, FXmlTagOIT.D_RandomValueMax);
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

                    if (fFormat == FOpcFormat.F8)
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
                        if (!FOpcDriverCommon.validateFormatRange((FFormat)fFormat, value))
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0014, "Max"));
                        }

                        if (!FOpcDriverCommon.validateMinMax((FFormat)fFormat, randomValueMin, value))
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
                    if (this.fXmlNode.get_attrVal(FXmlTagOIT.A_Transformer, FXmlTagOIT.D_Transformer) == string.Empty)
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
                    if (this.fXmlNode.get_attrVal(FXmlTagOIT.A_DataConversionSetID, FXmlTagOIT.D_DataConversionSetID) == string.Empty)
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

        public FOpcLibrary fAncestorOpcLibrary
        {
            get
            {
                try
                {
                    return this.getAncestorOpcLibrary();
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

        public FOpcMessage fAncestorOpcMessage
        {
            get
            {
                try
                {
                    return this.getAncestorOpcMessage();
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

        public FOpcItemList fAncestorOpcItemList
        {
            get
            {
                try
                {
                    return this.getAncestorOpcItemList();
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
                FOpcItemList fOil = null;
                string xpath = string.Empty;

                try
                {
                    fOil = this.fAncestorOpcItemList;
                    if (fOil == null)
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
                            "/" + FXmlTagOTR.E_OpcTrigger +
                            "/" + FXmlTagOCN.E_OpcCondition +
                            "//" + FXmlTagOEP.E_OpcExpression + "[@" + FXmlTagOEP.A_OperandId + "='" + this.uniqueIdToString + "']";
                    }
                    // --
                    return new FObjectCollection(this.fOcdCore, fOil.fXmlNode.selectNodes(xpath));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    fOil = null;
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
                        !(FClipboard.containsData(FCbObjectFormat.OpcItem) || 
                        FClipboard.containsData(FCbObjectFormat.OpcEventItem))
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

        public bool canAppendChild
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public string ToString(
            FStringOption option
            )
        {
            StringBuilder info = null;
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

                    info.Append("[" + this.itemName + "] " + FEnumConverter.fromOpcFormat(this.fFormat) + "[" + this.length.ToString() + "] " + this.name);

                    // --

                    if (fFormat == FOpcFormat.Ascii)
                    {
                        value = FValueConverter.toDataConversionedEncodingValue(
                            (FFormat)fFormat,
                            this.originalStringValue,
                            this.fXmlNode.get_attrVal(FXmlTagOIT.A_Transformer, FXmlTagOIT.D_Transformer),
                            this.dataConversionSetExpression,
                            ref length
                            );
                    }
                    else
                    {
                        value = FValueConverter.toDataConversionStringValue(
                            (FFormat)fFormat,
                            this.originalStringValue,
                            this.fXmlNode.get_attrVal(FXmlTagOIT.A_Transformer, FXmlTagOIT.D_Transformer),
                            this.dataConversionSetExpression,
                            ref length
                            );
                    }

                    // --

                    info.Append("=\"");
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

        public void remove(
            )
        {
            FIObject fParent = null;
            bool isModelingObject = false;            

            try
            {
                FOpcDriverCommon.validateRemoveChildObject(this.fXmlNode.fParentNode, this.fXmlNode);

                // --

                resetRelation();

                // --

                isModelingObject = this.isModelingObject;
                fParent = this.fParent;
                this.replace(this.fOcdCore, ((FOpcItemList)fParent).fXmlNode.removeChild(this.fXmlNode));                

                // --

                if (isModelingObject)
                {
                    this.fOcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectRemoveCompleted, this.fOpcDriver, fParent, this)
                        );                    
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
            FOpcItem fRefObject
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

                if (!this.fAncestorOpcMessage.Equals(fRefObject.fAncestorOpcMessage))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Ancestor OPC Message ", "same"));
                }

                // --                

                this.replace(this.fOcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fOcdCore, fRefObject.fXmlNode.fParentNode.insertAfter(this.fXmlNode, fRefObject.fXmlNode));

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

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void moveTo(
            FOpcItemList fRefObject
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

                if (!this.fAncestorOpcMessage.Equals(fRefObject.fAncestorOpcMessage))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Ancestor OPC Message ", "same"));
                }

                if (fRefObject.fChildOpcItemCollection.count > 0)
                {
                    if (this.Equals(fRefObject.fChildOpcItemCollection[fRefObject.fChildOpcItemCollection.count - 1]))
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
            FOpcEventItemList fRefObject
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

                if (!this.fAncestorOpcMessage.Equals(fRefObject.fAncestorOpcMessage))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Ancestor OPC Message ", "same"));
                }

                if (fRefObject.fChildOpcEventItemCollection.count > 0)
                {
                    if (this.Equals(fRefObject.fChildOpcEventItemCollection[fRefObject.fChildOpcEventItemCollection.count - 1]))
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
                // OPC Item에 대한 Lock 처리
                // ***
                this.fXmlNode.set_attrVal(FXmlTagOIT.A_Locked, FXmlTagOIT.D_Locked, FBoolean.True, true);

                // --

                // ***
                // OPC Item List에 대한 Lock 처리
                // ***
                this.fParent.lockObject();
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
                // OPC Item이 OPc Expression에 사용되었을 경우 Unlock 작업을 취소한다.
                // ***
                xpath =
                    FXmlTagEQM.E_EquipmentModeling +
                    "/" + FXmlTagEQP.E_Equipment +
                    "/" + FXmlTagSNG.E_ScenarioGroup +
                    "/" + FXmlTagSNR.E_Scenario +
                    "/" + FXmlTagOTR.E_OpcTrigger +
                    "/" + FXmlTagOCN.E_OpcCondition +
                    "//" + FXmlTagOEP.E_OpcExpression + "[@" + FXmlTagOEP.A_OperandId + "='" + this.uniqueIdToString + "']";
                if (this.fOpcDriver.fXmlNode.containsNode(xpath))
                {
                    return;
                }

                // --

                // ***
                // OPC Item에 대한 Unlock 처리
                // ***
                this.fXmlNode.set_attrVal(FXmlTagOIT.A_Locked, FXmlTagOIT.D_Locked, FBoolean.False, true);

                // --

                // ***
                // OPC Item List에 대한 Unlock 처리
                // ***
                this.fParent.unlockObject();
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
                this.copyObject(FCbObjectFormat.OpcItem, this.fXmlNode);
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
                this.copyObject(FCbObjectFormat.OpcItem, fXmlNode);
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

        public FOpcItem pasteSibling(
            )
        {
            FOpcItem fOpcItem = null;
            FOpcEventItem fOpcEventItem = null;

            try
            {
                if (FClipboard.containsData(FCbObjectFormat.OpcItem))
                {
                    FOpcDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.OpcItem);

                    // --

                    fOpcItem = (FOpcItem)this.pasteObject(FCbObjectFormat.OpcItem);
                }
                else
                {
                    FOpcDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.OpcEventItem);

                    // --

                    fOpcEventItem = (FOpcEventItem)this.pasteObject(FCbObjectFormat.OpcEventItem);
                    fOpcItem = changeEventItemToOpcItem(fOpcEventItem);
                }
                return this.fParent.insertAfterChildOpcItem(fOpcItem, this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fOpcItem = null;
                fOpcEventItem = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------
        private FOpcItem changeEventItemToOpcItem(FOpcEventItem tempOpcEventItem)
        {
            FOpcItem tempOpcItem = null;

            try
            {
                tempOpcItem = new FOpcItem(tempOpcEventItem.fOpcDriver);

                tempOpcItem.name = tempOpcEventItem.name;
                tempOpcItem.description = tempOpcEventItem.description;
                // --
                tempOpcItem.fontColor = tempOpcEventItem.fontColor;
                tempOpcItem.fontBold = tempOpcEventItem.fontBold;
                // --
                tempOpcItem.itemName = tempOpcEventItem.itemName;
                tempOpcItem.fItemFormat = tempOpcEventItem.fItemFormat;
                tempOpcItem.itemArray = tempOpcEventItem.itemArray;
                // --
                tempOpcItem.fFormat = tempOpcEventItem.fFormat;
                // --
                tempOpcItem.originalValue = tempOpcEventItem.originalValue;
                // --
                tempOpcItem.userTag1 = tempOpcEventItem.userTag1;
                tempOpcItem.userTag2 = tempOpcEventItem.userTag2;
                tempOpcItem.userTag3 = tempOpcEventItem.userTag3;
                tempOpcItem.userTag4 = tempOpcEventItem.userTag4;
                tempOpcItem.userTag5 = tempOpcEventItem.userTag5;

                if (tempOpcEventItem.hasChild)
                {
                    foreach (FXmlNode childXmlNodeOpcItem in tempOpcEventItem.fXmlNode.fChildNodes)
                    {
                        tempOpcItem.fXmlNode.appendChild(changeEventItemToOpcItem(new FOpcEventItem(tempOpcEventItem.fOcdCore, childXmlNodeOpcItem)).fXmlNode);
                    }
                }
                return tempOpcItem;
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

        public void setDataConversionSet(
            FDataConversionSet fDataConversionSet
            )
        {
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
                // 이 OPC Item 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "OPC Item", "Modeling File"));
                }

                // ***
                // Data Conversion Set와 OPC Item의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fDataConversionSet))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the Data Conversion Set and the OPC Item", "same"));
                }

                // --

                oldDcsId = this.fXmlNode.get_attrVal(FXmlTagOIT.A_DataConversionSetID, FXmlTagOIT.D_DataConversionSetID);
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
                
                this.fXmlNode.set_attrVal(FXmlTagOIT.A_DataConversionSetExpression, FXmlTagOIT.D_DataConversionSetExpression, fDataConversionSet.expression, false);
                this.fXmlNode.set_attrVal(FXmlTagOIT.A_DataConversionSetName, FXmlTagOIT.D_DataConversionSetName, fDataConversionSet.name, false);
                this.fXmlNode.set_attrVal(FXmlTagOIT.A_DataConversionSetID, FXmlTagOIT.D_DataConversionSetID, newDcsId, true);

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
                fDcs = this.fDataConversionSet;
                if (fDcs == null)
                {
                    return;
                }
                
                // --

                this.fXmlNode.set_attrVal(FXmlTagOIT.A_DataConversionSetExpression, FXmlTagOIT.D_DataConversionSetExpression, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagOIT.A_DataConversionSetName, FXmlTagOIT.D_DataConversionSetName, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagOIT.A_DataConversionSetID, FXmlTagOIT.D_DataConversionSetID, string.Empty, isModifyEvent);
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

        internal static void resetFlowNode(
            FXmlNode fXmlNode
            )
        {
            try
            {
                fXmlNode.set_attrVal(FXmlTagOIT.A_DataConversionSetExpression, FXmlTagOIT.D_DataConversionSetExpression, string.Empty);
                fXmlNode.set_attrVal(FXmlTagOIT.A_DataConversionSetName, FXmlTagOIT.D_DataConversionSetName, string.Empty);
                fXmlNode.set_attrVal(FXmlTagOIT.A_DataConversionSetID, FXmlTagOIT.D_DataConversionSetID, string.Empty);                
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

        private void setChangedFormat(
            )
        {
            try
            {
                this.fXmlNode.set_attrVal(FXmlTagOIT.A_Value, FXmlTagOIT.D_Value, FXmlTagOIT.D_Value);
                this.fXmlNode.set_attrVal(FXmlTagOIT.A_Length, FXmlTagOIT.D_Length, FXmlTagOIT.D_Length);
                // --
                this.fXmlNode.set_attrVal(FXmlTagOIT.A_Transformer, FXmlTagOIT.D_Transformer, FXmlTagOIT.D_Transformer);                                
                // --
                this.fXmlNode.set_attrVal(FXmlTagOIT.A_RandomValue, FXmlTagOIT.D_RandomValue, FXmlTagOIT.D_RandomValue);
                this.fXmlNode.set_attrVal(FXmlTagOIT.A_RandomValueMin, FXmlTagOIT.D_RandomValueMin, FXmlTagOIT.D_RandomValueMin);
                this.fXmlNode.set_attrVal(FXmlTagOIT.A_RandomValueMax, FXmlTagOIT.D_RandomValueMax, FXmlTagOIT.D_RandomValueMax);

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

        // ***
        // 2017.03.22 by spike.lee
        // 객체 Clone 기능 추가
        // ***
        public FOpcItem clone(
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.clone(true);

                // --

                resetFlowNode(fXmlNode);
                FOpcDriverCommon.resetLocked(fXmlNode);
                return new FOpcItem(this.fOcdCore, fXmlNode);
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
