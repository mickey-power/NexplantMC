/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FOpcItemLog.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2013.10.30
--  Description     : FAMate Core FaOpcDriver OPC Item Log Class
--  History         : Created by jungyoul.moon at 2013.10.30
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    public class FOpcItemLog : FBaseObjectLog<FOpcItemLog>, FIObjectLog
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FResultCode m_transformerResult = FResultCode.Success;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FOpcItemLog(
            FOpcDriverLog fOpcDriverLog
            )
            : base()
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FOpcItemLog(
            FOcdlCore fOcdlCore,
            FXmlNode fXmlNode
            )
            : base(fOcdlCore, fXmlNode)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FOpcItemLog(
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

        public FObjectLogType fObjectLogType
        {
            get
            {
                try
                {
                    return FObjectLogType.OpcItemLog;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectLogType.OpcItemLog;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOITL.A_UniqueId, FXmlTagOITL.D_UniqueId);
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

        public string logUniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOITL.A_LogUniqueId, FXmlTagOITL.D_LogUniqueId);
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

        public UInt64 logUniqueId
        {
            get
            {
                try
                {
                    return UInt64.Parse(this.logUniqueIdToString);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOITL.A_Name, FXmlTagOITL.D_Name);
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

        public string description
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOITL.A_Description, FXmlTagOITL.D_Description);
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

        public Color fontColor
        {
            get
            {
                try
                {
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagOITL.A_FontColor, FXmlTagOITL.D_FontColor));
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool fontBold
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagOITL.A_FontBold, FXmlTagOITL.D_FontBold));
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

        public string itemName
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOITL.A_ItemName, FXmlTagOITL.D_ItemName);
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

        public FTagFormat fItemFormat
        {
            get
            {
                try
                {
                    return FEnumConverter.toTagFormat(this.fXmlNode.get_attrVal(FXmlTagOITL.A_ItemFormat, FXmlTagOITL.D_ItemFormat));
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool itemArray
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagOEIL.A_ItemArray, FXmlTagOEIL.D_ItemArray));
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

        public int itemStart
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagOITL.A_ItemStart, FXmlTagOITL.D_ItemStart));
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

        public int itemLength
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagOITL.A_ItemLength, FXmlTagOITL.D_ItemLength));
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
                            this.fXmlNode.get_attrVal(FXmlTagOITL.A_Transformer, FXmlTagOITL.D_Transformer),
                            this.fXmlNode.get_attrVal(FXmlTagOITL.A_DataConversionSetExpression, FXmlTagOITL.D_DataConversionSetExpression),
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
                    return FEnumConverter.toOpcFormat(this.fXmlNode.get_attrVal(FXmlTagOITL.A_Format, FXmlTagOITL.D_Format));
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDataScanMode fScanMode
        {
            get
            {
                try
                {
                    return FEnumConverter.toDataScanMode(
                        this.fXmlNode.get_attrVal(FXmlTagOITL.A_ScanMode, FXmlTagOITL.D_ScanMode)
                        );
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string originalStringValue
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOITL.A_Value, FXmlTagOITL.D_Value);
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public object originalValue
        {
            get
            {
                try
                {
                    return FOpcValueConverter.toValue(this.fFormat, this.originalStringValue, this.originalLength);
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
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagOITL.A_Length, FXmlTagOITL.D_Length));
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
                        this.fXmlNode.get_attrVal(FXmlTagOITL.A_Transformer, FXmlTagOITL.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagOITL.A_DataConversionSetExpression, FXmlTagOITL.D_DataConversionSetExpression),
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
                        this.fXmlNode.get_attrVal(FXmlTagOITL.A_Transformer, FXmlTagOITL.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagOITL.A_DataConversionSetExpression, FXmlTagOITL.D_DataConversionSetExpression)
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
                        this.fXmlNode.get_attrVal(FXmlTagOITL.A_Transformer, FXmlTagOITL.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagOITL.A_DataConversionSetExpression, FXmlTagOITL.D_DataConversionSetExpression),
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
                        this.fXmlNode.get_attrVal(FXmlTagOITL.A_Transformer, FXmlTagOITL.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagOITL.A_DataConversionSetExpression, FXmlTagOITL.D_DataConversionSetExpression)
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

        public FResultCode valueTransformerResult
        {
            get
            {
                try
                {
                    return m_transformerResult;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FResultCode.Success;
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

        public FOpcItemLogValueTransformer fValueTransformer
        {
            get
            {
                try
                {
                    return new FOpcItemLogValueTransformer(this);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOITL.A_ReservedWord, FXmlTagOITL.D_ReservedWord);
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

        public bool extraction
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagOITL.A_Extraction, FXmlTagOITL.D_Extraction));
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

        public bool hashTag
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagOITL.A_HashTag, FXmlTagOITL.D_HashTag));
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

        public string dataConversionSetID
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOITL.A_DataConversionSetID, FXmlTagOITL.D_DataConversionSetID);
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

        public string dataConversionSetName
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOITL.A_DataConversionSetName, FXmlTagOITL.D_DataConversionSetName);
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

        public string dataConversionSetExpression
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOITL.A_DataConversionSetExpression, FXmlTagOITL.D_DataConversionSetExpression);
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

        public string result
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOITL.A_Result, FXmlTagOITL.D_Result);
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

        public string userTag1
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOITL.A_UserTag1, FXmlTagOITL.D_UserTag1);
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

        public string userTag2
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOITL.A_UserTag2, FXmlTagOITL.D_UserTag2);
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

        public string userTag3
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOITL.A_UserTag3, FXmlTagOITL.D_UserTag3);
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

        public string userTag4
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOITL.A_UserTag4, FXmlTagOITL.D_UserTag4);
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

        public string userTag5
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOITL.A_UserTag5, FXmlTagOITL.D_UserTag5);
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

        public bool hasChild
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagOITL.A_RandomValue, FXmlTagOITL.D_RandomValue));
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

        public string randomValueMin
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOITL.A_RandomValueMin, FXmlTagOITL.D_RandomValueMin);
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

        public string randomValueMax
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOITL.A_RandomValueMax, FXmlTagOITL.D_RandomValueMax);
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

        public bool hasValueTransformer
        {
            get
            {
                try
                {
                    if (this.fXmlNode.get_attrVal(FXmlTagOITL.A_Transformer, FXmlTagOITL.D_Transformer) == string.Empty)
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
                    if (this.fXmlNode.get_attrVal(FXmlTagOITL.A_DataConversionSetID, FXmlTagOITL.D_DataConversionSetID) == string.Empty)
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

        public FOpcItemListLog fParent
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

                    return new FOpcItemListLog(this.fOcdlCore, this.fXmlNode.fParentNode);
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

        public FOpcItemLog fPreviousSibling
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

                    return new FOpcItemLog(this.fOcdlCore, this.fXmlNode.fPreviousSibling);
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

        public FOpcItemLog fNextSibling
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

                    return new FOpcItemLog(this.fOcdlCore, this.fXmlNode.fPreviousSibling);
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

        public string equipmentName
        {
            get
            {
                try
                {
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
                            this.fXmlNode.get_attrVal(FXmlTagOITL.A_Transformer, FXmlTagOITL.D_Transformer),
                            this.dataConversionSetExpression,
                            ref length
                            );
                    }
                    else
                    {
                        value = FValueConverter.toDataConversionStringValue(
                            (FFormat)fFormat,
                            this.originalStringValue,
                            this.fXmlNode.get_attrVal(FXmlTagOITL.A_Transformer, FXmlTagOITL.D_Transformer),
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

                if (this.result != string.Empty)
                {
                    info.Append(" Result=[" + this.result + "]");
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

        public void copy(
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.clone(true);

                // --

                FOpcDriverLogCommon.removeLogUniqueId(fXmlNode);

                // --

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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
