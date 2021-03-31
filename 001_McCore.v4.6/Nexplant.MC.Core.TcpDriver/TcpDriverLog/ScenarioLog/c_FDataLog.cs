/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FDataLog.cs
--  Creator         : spike.lee
--  Create Date     : 2011.12.08
--  Description     : FAMate Core FaTcpDriver Data Log Class 
--  History         : Created by spike.lee at 2011.12.08
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    public class FDataLog : FBaseObjectLog<FDataLog>, FIObjectLog
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        private FResultCode m_transformerResult = FResultCode.Success;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FDataLog(
            FTcdlCore fTcdlCore, 
            FXmlNode fXmlNode
            )
            : base(fTcdlCore, fXmlNode)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FDataLog(
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
                    return FObjectLogType.DataLog;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectLogType.DataLog;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string logUniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagDATL.A_LogUniqueId, FXmlTagDATL.D_LogUniqueId);
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

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagDATL.A_UniqueId, FXmlTagDATL.D_UniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagDATL.A_Name, FXmlTagDATL.D_Name);
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
                    return this.fXmlNode.get_attrVal(FXmlTagDATL.A_Description, FXmlTagDATL.D_Description);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagDATL.A_FontColor, FXmlTagDATL.D_FontColor));
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagDATL.A_FontBold, FXmlTagDATL.D_FontBold));
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

        public FDataSourceType fSourceType
        {
            get
            {
                try
                {
                    return FEnumConverter.toDataSourceType(this.fXmlNode.get_attrVal(FXmlTagDATL.A_SourceType, FXmlTagDATL.D_SourceType));
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
        }

        //------------------------------------------------------------------------------------------------------------------------       

        public string sourceConstant
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagDATL.A_SourceConstant, FXmlTagDATL.D_SourceConstant);
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

        public FResourceSourceType sourceResource
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = this.fXmlNode.get_attrVal(FXmlTagDATL.A_SourceResource, FXmlTagDATL.D_SourceResource);
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string sourceEquipmentState
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagDATL.A_SourceEquipmentState, FXmlTagDATL.D_SourceEquipmentState);
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

        public string sourceEnvironment
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagDATL.A_SourceEnvironment, FXmlTagDATL.D_SourceEnvironment);
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

        public string sourceColumn
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagDATL.A_SourceColumn, FXmlTagDATL.D_SourceColumn);
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

        public string sourceItem
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagDATL.A_SourceItem, FXmlTagDATL.D_SourceItem);
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

        public FDataTargetType fTargetType
        {
            get
            {
                try
                {
                    return FEnumConverter.toDataTargetType(this.fXmlNode.get_attrVal(FXmlTagDATL.A_TargetType, FXmlTagDATL.D_TargetType));
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string targetConstant
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagDATL.A_TargetConstant, FXmlTagDATL.D_TargetConstant);
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

        public string targetColumn
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagDATL.A_TargetColumn, FXmlTagDATL.D_TargetColumn);
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

        public string targetItem
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagDATL.A_TargetItem, FXmlTagDATL.D_TargetItem);
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

        public FPattern fPattern
        {
            get
            {
                try
                {
                    return FEnumConverter.toPattern(this.fXmlNode.get_attrVal(FXmlTagDATL.A_Pattern, FXmlTagDATL.D_Pattern));
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int fixedLength
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagDATL.A_FixedLength, FXmlTagDATL.D_FixedLength));
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

        public FFormat fFormat
        {
            get
            {
                try
                {
                    return FEnumConverter.toFormat(this.fXmlNode.get_attrVal(FXmlTagDATL.A_Format, FXmlTagDATL.D_Format));
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

        public bool merge
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagDATL.A_Merge, FXmlTagDATL.D_Merge));
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
                    return FEnumConverter.toDataScanMode(this.fXmlNode.get_attrVal(FXmlTagDATL.A_ScanMode, FXmlTagDATL.D_ScanMode));
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
                    return this.fXmlNode.get_attrVal(FXmlTagDATL.A_Value, FXmlTagDATL.D_Value);
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
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagDATL.A_Length, FXmlTagDATL.D_Length));
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
                        this.fXmlNode.get_attrVal(FXmlTagDATL.A_Transformer, FXmlTagDATL.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagDATL.A_DataConversionSetExpression, FXmlTagDATL.D_DataConversionSetExpression),
                        ref length,
                        ref m_transformerResult
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

        public string[] stringArrayValue
        {
            get
            {
                try
                {
                    return FValueConverter.toConversionedStringArrayValue(
                        this.fFormat,
                        this.originalStringValue,
                        this.fXmlNode.get_attrVal(FXmlTagDATL.A_Transformer, FXmlTagDATL.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagDATL.A_DataConversionSetExpression, FXmlTagDATL.D_DataConversionSetExpression)
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
                        this.fXmlNode.get_attrVal(FXmlTagDATL.A_Transformer, FXmlTagDATL.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagDATL.A_DataConversionSetExpression, FXmlTagDATL.D_DataConversionSetExpression),
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
                        this.fXmlNode.get_attrVal(FXmlTagDATL.A_Transformer, FXmlTagDATL.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagDATL.A_DataConversionSetExpression, FXmlTagDATL.D_DataConversionSetExpression)
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
                        this.fXmlNode.get_attrVal(FXmlTagDATL.A_Transformer, FXmlTagDATL.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagDATL.A_DataConversionSetExpression, FXmlTagDATL.D_DataConversionSetExpression),
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

        public FDataLogValueTransformer fValueTransformer
        {
            get
            {
                try
                {
                    return new FDataLogValueTransformer(this);
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

        public string dataConversionSetID
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagDATL.A_DataConversionSetID, FXmlTagDATL.D_DataConversionSetID);
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
                    return this.fXmlNode.get_attrVal(FXmlTagDATL.A_DataConversionSetName, FXmlTagDATL.D_DataConversionSetName);
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
                    return this.fXmlNode.get_attrVal(FXmlTagDATL.A_DataConversionSetExpression, FXmlTagDATL.D_DataConversionSetExpression);
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
                    return this.fXmlNode.get_attrVal(FXmlTagDATL.A_UserTag1, FXmlTagDATL.D_UserTag1);
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
                    return this.fXmlNode.get_attrVal(FXmlTagDATL.A_UserTag2, FXmlTagDATL.D_UserTag2);
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
                    return this.fXmlNode.get_attrVal(FXmlTagDATL.A_UserTag3, FXmlTagDATL.D_UserTag3);
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
                    return this.fXmlNode.get_attrVal(FXmlTagDATL.A_UserTag4, FXmlTagDATL.D_UserTag4);
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
                    return this.fXmlNode.get_attrVal(FXmlTagDATL.A_UserTag5, FXmlTagDATL.D_UserTag5);
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

        public FDataLogCollection fChildDataLogCollection
        {
            get
            {
                try
                {
                    return new FDataLogCollection(this.fTcdlCore, this.fXmlNode.selectNodes(FXmlTagDATL.E_Data));
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
                    return this.fXmlNode.containsNode(FXmlTagDATL.E_Data);
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

        public bool hasValueTransformer
        {
            get
            {
                try
                {
                    if (this.fXmlNode.get_attrVal(FXmlTagDATL.A_Transformer, FXmlTagDATL.D_Transformer) == string.Empty)
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
                    if (this.fXmlNode.get_attrVal(FXmlTagDATL.A_DataConversionSetID, FXmlTagDATL.D_DataConversionSetID) == string.Empty)
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
                    if (this.fXmlNode.get_attrVal(FXmlTagDATL.A_Merge, FXmlTagDATL.D_Merge) == "F")
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

        public FIObjectLog fParent
        {
            get
            {
                FXmlNode fXmlNodeParent = null;
                string logType = string.Empty;

                try
                {
                    if (this.fXmlNode.fParentNode == null)
                    {
                        return null;
                    }

                    // --

                    fXmlNodeParent = this.fXmlNode.fParentNode;

                    // --

                    if (fXmlNodeParent.name == FXmlTagDTSL.E_DataSet)
                    {
                        return new FDataSetLog(this.fTcdlCore, fXmlNodeParent);
                    }
                    else if (fXmlNodeParent.name == FXmlTagDATL.E_Data)
                    {
                        return new FDataLog(this.fTcdlCore, fXmlNodeParent);
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

        public FDataLog fPreviousSibling
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

                    return new FDataLog(this.fTcdlCore, this.fXmlNode.fPreviousSibling);
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

        public FDataLog fNextSibling
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

                    return new FDataLog(this.fTcdlCore, this.fXmlNode.fNextSibling);
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
                            this.fXmlNode.get_attrVal(FXmlTagDATL.A_Transformer, FXmlTagDATL.D_Transformer),
                            this.fXmlNode.get_attrVal(FXmlTagDATL.A_DataConversionSetExpression, FXmlTagDATL.D_DataConversionSetExpression),
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
                            this.fXmlNode.get_attrVal(FXmlTagDATL.A_Transformer, FXmlTagDATL.D_Transformer),
                            this.fXmlNode.get_attrVal(FXmlTagDATL.A_DataConversionSetExpression, FXmlTagDATL.D_DataConversionSetExpression),
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

                    fScanMode = FEnumConverter.toDataScanMode(this.fXmlNode.get_attrVal(FXmlTagDATL.A_ScanMode, FXmlTagDATL.D_ScanMode));
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
                        info.Append("est: " + this.sourceEquipmentState);
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

        public FDataLogCollection selectDataLogByName(
            string name
            )
        {
            const string xpath = FXmlTagDATL.E_Data + "[@" + FXmlTagDATL.A_Name + "='{0}']";

            try
            {
                return new FDataLogCollection(
                    this.fTcdlCore,
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

        public FDataLog selectSingleDataLogByName(
            string name
            )
        {
            const string xpath = FXmlTagDATL.E_Data + "[@" + FXmlTagDATL.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FDataLog(this.fTcdlCore, fXmlNode);
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

        public FDataLogCollection selectAllDataLogByName(
            string name
            )
        {
            const string xpath = ".//" + FXmlTagDATL.E_Data + "[@" + FXmlTagDATL.A_Name + "='{0}']";

            try
            {
                return new FDataLogCollection(
                    this.fTcdlCore,
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

        public FDataLog selectSingleAllDataLogByName(
            string name
            )
        {
            const string xpath = ".//" + FXmlTagDATL.E_Data + "[@" + FXmlTagDATL.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FDataLog(this.fTcdlCore, fXmlNode);
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

        public FDataLog selectSingleAllDataLogByIndex(
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
                return new FDataLog(this.fTcdlCore, fXmlNode);
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
