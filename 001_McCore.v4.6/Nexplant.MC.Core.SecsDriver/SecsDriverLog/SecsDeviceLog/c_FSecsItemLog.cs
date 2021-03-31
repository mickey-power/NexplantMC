/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecsItemLog.cs
--  Creator         : kitae
--  Create Date     : 2011.10.11
--  Description     : FAMate Core FaSecsDriver SECS Item Log Class 
--  History         : Created by kitae at 2011.10.11
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public class FSecsItemLog : FBaseObjectLog<FSecsItemLog>, FIObjectLog
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        private FResultCode m_transformerResult = FResultCode.Success;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FSecsItemLog(
            FScdlCore fScdlCore, 
            FXmlNode fXmlNode
            )
            : base(fScdlCore, fXmlNode)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSecsItemLog(
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
                    return FObjectLogType.SecsItemLog;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectLogType.SecsItemLog;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string logUniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSITL.A_LogUniqueId, FXmlTagSITL.D_LogUniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSITL.A_UniqueId, FXmlTagSITL.D_UniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSITL.A_Name, FXmlTagSITL.D_Name);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSITL.A_Description, FXmlTagSITL.D_Description);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagSITL.A_FontColor, FXmlTagSITL.D_FontColor));
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSITL.A_FontBold, FXmlTagSITL.D_FontBold));
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

        public FPattern fPattern
        {
            get
            {
                try
                {
                    return FEnumConverter.toPattern(this.fXmlNode.get_attrVal(FXmlTagSITL.A_Pattern, FXmlTagSITL.D_Pattern));
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
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSITL.A_FixedLength, FXmlTagSITL.D_FixedLength));
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
                    return FEnumConverter.toFormat(this.fXmlNode.get_attrVal(FXmlTagSITL.A_Format, FXmlTagSITL.D_Format));
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

        public FSecsLengthBytes lengthBytes
        {
            get
            {
                try
                {
                    return FEnumConverter.toSecsLengthBytes(this.fXmlNode.get_attrVal(FXmlTagSITL.A_LengthBytes, FXmlTagSITL.D_LengthBytes));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FSecsLengthBytes.Auto;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDataScanMode fScanMode
        {
            get
            {
                try
                {
                    return FEnumConverter.toDataScanMode(this.fXmlNode.get_attrVal(FXmlTagSITL.A_ScanMode, FXmlTagSITL.D_ScanMode));
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
                    return this.fXmlNode.get_attrVal(FXmlTagSITL.A_Value, FXmlTagSITL.D_Value);
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
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSITL.A_Length, FXmlTagSITL.D_Length));
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
                        this.fXmlNode.get_attrVal(FXmlTagSITL.A_Transformer, FXmlTagSIT.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagSITL.A_DataConversionSetExpression, FXmlTagSITL.D_DataConversionSetExpression),
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
                        this.fXmlNode.get_attrVal(FXmlTagSITL.A_Transformer, FXmlTagSITL.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagSITL.A_DataConversionSetExpression, FXmlTagSITL.D_DataConversionSetExpression)
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
                        this.fXmlNode.get_attrVal(FXmlTagSITL.A_Transformer, FXmlTagSITL.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagSITL.A_DataConversionSetExpression, FXmlTagSITL.D_DataConversionSetExpression),
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
                        this.fXmlNode.get_attrVal(FXmlTagSITL.A_Transformer, FXmlTagSITL.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagSITL.A_DataConversionSetExpression, FXmlTagSITL.D_DataConversionSetExpression)
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
                        this.fXmlNode.get_attrVal(FXmlTagSITL.A_Transformer, FXmlTagSITL.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagSITL.A_DataConversionSetExpression, FXmlTagSITL.D_DataConversionSetExpression),
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

        public bool randomValue
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSITL.A_RandomValue, FXmlTagSITL.D_RandomValue));
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
                    return this.fXmlNode.get_attrVal(FXmlTagSITL.A_RandomValueMin, FXmlTagSITL.D_RandomValueMin);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSITL.A_RandomValueMax, FXmlTagSITL.D_RandomValueMax);
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

        public FSecsItemLogValueTransformer fValueTransformer
        {
            get
            {
                try
                {
                    return new FSecsItemLogValueTransformer(this);
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

        public FSecsItemLogPrecondition fPrecondition
        {
            get
            {
                try
                {
                    return new FSecsItemLogPrecondition(this);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSITL.A_ReservedWord, FXmlTagSITL.D_ReservedWord);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSITL.A_Extraction, FXmlTagSITL.D_Extraction));
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
                    return this.fXmlNode.get_attrVal(FXmlTagSITL.A_DataConversionSetID, FXmlTagSITL.D_DataConversionSetID);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSITL.A_DataConversionSetName, FXmlTagSITL.D_DataConversionSetName);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSITL.A_DataConversionSetExpression, FXmlTagSITL.D_DataConversionSetExpression);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSITL.A_UserTag1, FXmlTagSITL.D_UserTag1);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSITL.A_UserTag2, FXmlTagSITL.D_UserTag2);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSITL.A_UserTag3, FXmlTagSITL.D_UserTag3);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSITL.A_UserTag4, FXmlTagSITL.D_UserTag4);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSITL.A_UserTag5, FXmlTagSITL.D_UserTag5);
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

        public FSecsItemLogCollection fChildSecsItemLogCollection
        {
            get
            {
                try
                {
                    return new FSecsItemLogCollection(this.fScdlCore, this.fXmlNode.selectNodes(FXmlTagSITL.E_SecsItem));
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
                    return this.fXmlNode.containsNode(FXmlTagSITL.E_SecsItem);
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
                    if (this.fXmlNode.get_attrVal(FXmlTagSITL.A_Transformer, FXmlTagSITL.D_Transformer) == string.Empty)
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
                    if (this.fXmlNode.get_attrVal(FXmlTagSITL.A_DataConversionSetID, FXmlTagSITL.D_DataConversionSetID) == string.Empty)
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
                    if (this.fXmlNode.get_attrVal(FXmlTagSITL.A_Precondition, FXmlTagSITL.D_Precondition) == string.Empty)
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

                    if (fXmlNodeParent.name == FXmlTagSMGL.E_SecsMessage)
                    {
                        logType = fXmlNodeParent.get_attrVal(FXmlTagSMGL.A_LogType, FXmlTagSMGL.D_LogType);
                        if (logType == FXmlTagSMGL.L_Received)
                        {
                            return new FSecsDeviceDataMessageReceivedLog(this.fScdlCore, fXmlNodeParent);
                        }
                        else if (logType == FXmlTagSMGL.L_Sent)
                        {
                            return new FSecsDeviceDataMessageSentLog(this.fScdlCore, fXmlNodeParent);
                        }
                        return null;
                    }
                    return new FSecsItemLog(this.fScdlCore, fXmlNodeParent);
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

        public FSecsItemLog fPreviousSibling
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

                    return new FSecsItemLog(this.fScdlCore, this.fXmlNode.fPreviousSibling);
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

        public FSecsItemLog fNextSibling
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

                    return new FSecsItemLog(this.fScdlCore, this.fXmlNode.fNextSibling);
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
                    else if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2 || fFormat == FFormat.Char)
                    {
                        value = FValueConverter.toDataConversionedEncodingValue(
                            fFormat,
                            this.originalStringValue,
                            this.fXmlNode.get_attrVal(FXmlTagSITL.A_Transformer, FXmlTagSITL.D_Transformer),
                            this.fXmlNode.get_attrVal(FXmlTagSITL.A_DataConversionSetExpression, FXmlTagSITL.D_DataConversionSetExpression),
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
                            this.fXmlNode.get_attrVal(FXmlTagSITL.A_Transformer, FXmlTagSITL.D_Transformer),
                            this.fXmlNode.get_attrVal(FXmlTagSITL.A_DataConversionSetExpression, FXmlTagSITL.D_DataConversionSetExpression),
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

        public void copy(
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.clone(true);

                // --

                // ***
                // [2016.12.19 by spike.lee]
                // FSecsItemLog Copy 시, LengthBytes를 Auto로 변경
                // ***
                fXmlNode.set_attrVal(FXmlTagSITL.A_LengthBytes, FXmlTagSITL.D_LengthBytes, FXmlTagSITL.D_LengthBytes);
                // --
                foreach (FXmlNode x in fXmlNode.selectNodes(".//" + FXmlTagSITL.E_SecsItem))
                {
                    x.set_attrVal(FXmlTagSITL.A_LengthBytes, FXmlTagSITL.D_LengthBytes, FXmlTagSITL.D_LengthBytes);
                }

                // --

                FSecsDriverLogCommon.removeLogUniqueId(fXmlNode);

                // -- 

                this.copyObject(FCbObjectFormat.SecsItem, fXmlNode);
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

        public FSecsItemLogCollection selectSecsItemLogByName(
            string name
            )
        {
            const string xpath = FXmlTagSITL.E_SecsItem + "[@" + FXmlTagSITL.A_Name + "='{0}']";

            try
            {
                return new FSecsItemLogCollection(
                    this.fScdlCore,
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

        public FSecsItemLog selectSingleSecsItemLogByName(
            string name
            )
        {
            const string xpath = FXmlTagSITL.E_SecsItem + "[@" + FXmlTagSITL.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsItemLog(this.fScdlCore, fXmlNode);
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

        public FSecsItemLogCollection selectAllSecsItemLogByName(
            string name
            )
        {
            const string xpath = ".//" + FXmlTagSITL.E_SecsItem + "[@" + FXmlTagSITL.A_Name + "='{0}']";

            try
            {
                return new FSecsItemLogCollection(
                    this.fScdlCore,
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

        public FSecsItemLog selectSingleAllSecsItemLogByName(
            string name
            )
        {
            const string xpath = ".//" + FXmlTagSITL.E_SecsItem + "[@" + FXmlTagSITL.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsItemLog(this.fScdlCore, fXmlNode);
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

        public FSecsItemLogCollection selectSecsItemLogByReservedWord(
            string reservedWord
            )
        {
            const string xpath = FXmlTagSITL.E_SecsItem + "[@" + FXmlTagSITL.A_ReservedWord + "='{0}']";

            try
            {
                return new FSecsItemLogCollection(
                    this.fScdlCore,
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

        public FSecsItemLog selectSingleSecsItemLogByReservedWord(
            string reservedWord
            )
        {
            const string xpath = FXmlTagSITL.E_SecsItem + "[@" + FXmlTagSITL.A_ReservedWord + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, reservedWord));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsItemLog(this.fScdlCore, fXmlNode);
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

        public FSecsItemLogCollection selectAllSecsItemLogByReservedWord(
            string reservedWord
            )
        {
            const string xpath = ".//" + FXmlTagSITL.E_SecsItem + "[@" + FXmlTagSITL.A_ReservedWord + "='{0}']";

            try
            {
                return new FSecsItemLogCollection(
                    this.fScdlCore,
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

        public FSecsItemLog selectSingleAllSecsItemLogByReservedWord(
            string reservedWord
            )
        {
            const string xpath = ".//" + FXmlTagSITL.E_SecsItem + "[@" + FXmlTagSITL.A_ReservedWord + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, reservedWord));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsItemLog(this.fScdlCore, fXmlNode);
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

        public FSecsItemLogCollection selectSecsItemLogByExtraction(
            )
        {
            const string xpath = FXmlTagSITL.E_SecsItem + "[@" + FXmlTagSITL.A_Extraction + "='{0}']";

            try
            {
                return new FSecsItemLogCollection(
                    this.fScdlCore,
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

        public FSecsItemLog selectSingleSecsItemLogByExtraction(
            )
        {
            const string xpath = FXmlTagSITL.E_SecsItem + "[@" + FXmlTagSITL.A_Extraction + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, FBoolean.True));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsItemLog(this.fScdlCore, fXmlNode);
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

        public FSecsItemLogCollection selectAllSecsItemLogByExtraction(
            )
        {
            const string xpath = ".//" + FXmlTagSITL.E_SecsItem + "[@" + FXmlTagSITL.A_Extraction + "='{0}']";

            try
            {
                return new FSecsItemLogCollection(
                    this.fScdlCore,
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

        public FSecsItemLog selectSingleAllSecsItemLogByExtraction(
            )
        {
            const string xpath = ".//" + FXmlTagSITL.E_SecsItem + "[@" + FXmlTagSITL.A_Extraction + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, FBoolean.True));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsItemLog(this.fScdlCore, fXmlNode);
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

        public FSecsItemLog selectSingleAllSecsItemLogByInddex(
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

                fXmlNode = this.fXmlNode.clone(true);
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
                    fXmlNode = fXmlNode.fChildNodes[index].clone(true);
                }
                // --
                return new FSecsItemLog(this.fScdlCore, fXmlNode);
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
