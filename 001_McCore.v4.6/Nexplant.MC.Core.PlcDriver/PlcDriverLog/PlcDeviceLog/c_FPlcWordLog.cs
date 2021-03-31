/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPlcWordLog.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2013.10.30
--  Description     : FAMate Core FaPlcDriver PLC Word Log Class
--  History         : Created by jungyoul.moon at 2013.10.30
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    public class FPlcWordLog : FBaseObjectLog<FPlcWordLog>, FIObjectLog
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FResultCode m_transformerResult = FResultCode.Success;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPlcWordLog(
            FPlcDriverLog fPlcDriverLog
            )
            : base()
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FPlcWordLog(
            FPcdlCore fPcdlCore,
            FXmlNode fXmlNode
            )
            : base(fPcdlCore, fXmlNode)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPlcWordLog(
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
                    return FObjectLogType.PlcWordLog;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectLogType.PlcWordLog;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagPWDL.A_UniqueId, FXmlTagPWDL.D_UniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPWDL.A_LogUniqueId, FXmlTagPWDL.D_LogUniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPWDL.A_Name, FXmlTagPWDL.D_Name);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPWDL.A_Description, FXmlTagPWDL.D_Description);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagPWDL.A_FontColor, FXmlTagPWDL.D_FontColor));
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagPWDL.A_FontBold, FXmlTagPWDL.D_FontBold));
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

        public FLinkMapExpression fLinkMapExpression
        {
            get
            {

                try
                {
                    return FEnumConverter.toLinkMapExpression(
                        this.fXmlNode.get_attrVal(FXmlTagPWDL.A_LinkMapExpression, FXmlTagPWDL.D_LinkMapExpression)
                        );
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FLinkMapExpression.Decimal;
            }    
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string address
        {
            get
            {
                try
                {
                    return FPlcValueConverter.toLinkMapValue(
                        this.fLinkMapExpression,
                        this.fXmlNode.get_attrVal(FXmlTagPWDL.A_Address, FXmlTagPWDL.D_Address)
                        );
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return "0";
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public UInt32 addr
        {
            get
            {
                try
                {
                    return UInt32.Parse(this.fXmlNode.get_attrVal(FXmlTagPWDL.A_Address, FXmlTagPWDL.D_Address));
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
                    return int.Parse(
                        this.fXmlNode.get_attrVal(FXmlTagPWDL.A_Length, FXmlTagPWDL.D_Length)
                        );
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

        public int fixedLength
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagPWDL.A_FixedLength, FXmlTagPWDL.D_FixedLength));
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
                    return FEnumConverter.toFormat(
                        this.fXmlNode.get_attrVal(FXmlTagPWDL.A_Format, FXmlTagPWDL.D_Format)
                        );
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

        public FDataScanMode fScanMode
        {
            get
            {
                try
                {
                    return FEnumConverter.toDataScanMode(
                        this.fXmlNode.get_attrVal(FXmlTagPWDL.A_ScanMode, FXmlTagPWDL.D_ScanMode)
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
                    return this.fXmlNode.get_attrVal(FXmlTagPWDL.A_Value, FXmlTagPWDL.D_Value);
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
                    return FValueConverter.toValue(this.fFormat, this.originalStringValue, this.length);
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
                    if (this.length == 0)
                    {
                        return 0;
                    }

                    // --

                    if (this.fFormat == FFormat.Binary)
                    {
                        return this.length * 2;
                    }
                    else if (this.fFormat == FFormat.Boolean)
                    {
                        return this.length * 2;
                    }
                    else if (this.fFormat == FFormat.Ascii)
                    {
                        return this.length * 2;
                    }
                    else if (this.fFormat == FFormat.I8)
                    {
                        return this.length / 4;
                    }
                    else if (this.fFormat == FFormat.I4)
                    {
                        return this.length / 2;
                    }
                    else if (this.fFormat == FFormat.I2)
                    {
                        return this.length;
                    }
                    else if (this.fFormat == FFormat.I1)
                    {
                        return this.length * 2;
                    }
                    else if (this.fFormat == FFormat.F8)
                    {
                        return this.length / 4;
                    }
                    else if (this.fFormat == FFormat.F4)
                    {
                        return this.length / 2;
                    }
                    else if (this.fFormat == FFormat.U8)
                    {
                        return this.length / 4;
                    }
                    else if (this.fFormat == FFormat.U4)
                    {
                        return this.length / 2;
                    }
                    else if (this.fFormat == FFormat.U2)
                    {
                        return this.length;
                    }
                    else if (this.fFormat == FFormat.U1)
                    {
                        return this.length * 2;
                    }

                    // --

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
                        this.fXmlNode.get_attrVal(FXmlTagPWDL.A_Transformer, FXmlTagPWDL.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagPWDL.A_DataConversionSetExpression, FXmlTagPWDL.D_DataConversionSetExpression),
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
                    return this.originalStringArrayValue;
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
                        this.fXmlNode.get_attrVal(FXmlTagPWDL.A_Transformer, FXmlTagPWDL.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagPWDL.A_DataConversionSetExpression, FXmlTagPWDL.D_DataConversionSetExpression),
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
                        this.fXmlNode.get_attrVal(FXmlTagPWDL.A_Transformer, FXmlTagPWDL.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagPWDL.A_DataConversionSetExpression, FXmlTagPWDL.D_DataConversionSetExpression)
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

        public bool isArrayValue
        {
            get
            {
                FFormat fFormat;

                try
                {
                    if (this.length == 0)
                    {
                        return false;
                    }

                    // --

                    fFormat = this.fFormat;

                    // --

                    if (fFormat == FFormat.Ascii)
                    {
                        return false;
                    }

                    // --

                    if (fFormat == FFormat.I8)
                    {
                        return (length / 4 == 1 ? false : true);
                    }
                    else if (fFormat == FFormat.I4)
                    {
                        return (length / 2 == 1 ? false : true);
                    }
                    else if (fFormat == FFormat.I2)
                    {
                        return (length == 1 ? false : true);
                    }
                    else if (fFormat == FFormat.F8)
                    {
                        return (length / 4 == 1 ? false : true);
                    }
                    else if (fFormat == FFormat.F4)
                    {
                        return (length / 2 == 1 ? false : true);
                    }
                    else if (fFormat == FFormat.U8)
                    {
                        return (length / 4 == 1 ? false : true);
                    }
                    else if (fFormat == FFormat.U4)
                    {
                        return (length / 2 == 1 ? false : true);
                    }
                    else if (fFormat == FFormat.U2)
                    {
                        return (length == 1 ? false : true);
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

        public FPlcWordLogValueTransformer fValueTransformer
        {
            get
            {
                try
                {
                    return new FPlcWordLogValueTransformer(this);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPWDL.A_ReservedWord, FXmlTagPWDL.D_ReservedWord);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagPWDL.A_Extraction, FXmlTagPWDL.D_Extraction));
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
                    return this.fXmlNode.get_attrVal(FXmlTagPWDL.A_DataConversionSetID, FXmlTagPWDL.D_DataConversionSetID);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPWDL.A_DataConversionSetName, FXmlTagPWDL.D_DataConversionSetName);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPWDL.A_DataConversionSetExpression, FXmlTagPWDL.D_DataConversionSetExpression);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPWDL.A_UserTag1, FXmlTagPWDL.D_UserTag1);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPWDL.A_UserTag2, FXmlTagPWDL.D_UserTag2);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPWDL.A_UserTag3, FXmlTagPWDL.D_UserTag3);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPWDL.A_UserTag4, FXmlTagPWDL.D_UserTag4);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPWDL.A_UserTag5, FXmlTagPWDL.D_UserTag5);
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

        public FPlcWordLogCollection fChildPlcWordLogCollection
        {
            get
            {
                try
                {
                    // 필요 있을까?
                    return new FPlcWordLogCollection(this.fPcdlCore, this.fXmlNode.selectNodes(FXmlTagPWDL.E_PlcWord));
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
                    return this.fXmlNode.containsNode(FXmlTagPWDL.E_PlcWord);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagPWDL.A_RandomValue, FXmlTagPWDL.D_RandomValue));
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
                    return this.fXmlNode.get_attrVal(FXmlTagPWDL.A_RandomValueMin, FXmlTagPWDL.D_RandomValueMin);
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
                    return this.fXmlNode.get_attrVal(FXmlTagPWDL.A_RandomValueMax, FXmlTagPWDL.D_RandomValueMax);
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
                    if (this.fXmlNode.get_attrVal(FXmlTagPWDL.A_Transformer, FXmlTagPWDL.D_Transformer) == string.Empty)
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
                    if (this.fXmlNode.get_attrVal(FXmlTagPWDL.A_DataConversionSetID, FXmlTagPWDL.D_DataConversionSetID) == string.Empty)
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

        public FPlcWordListLog fParent
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

                    return new FPlcWordListLog(this.fPcdlCore, this.fXmlNode.fParentNode);
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

        public FPlcWordLog fPreviousSibling
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

                    return new FPlcWordLog(this.fPcdlCore, this.fXmlNode.fPreviousSibling);
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

        public FPlcWordLog fNextSibling
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

                    return new FPlcWordLog(this.fPcdlCore, this.fXmlNode.fPreviousSibling);
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

                    info.Append(FEnumConverter.fromFormat(this.fFormat) + "[" + this.address + ", " + this.length.ToString() + "] " + this.name);

                    // --

                    if (fFormat == FFormat.Ascii)
                    {
                        value = FValueConverter.toDataConversionedEncodingValue(
                            (FFormat)fFormat,
                            this.originalStringValue,
                            this.fXmlNode.get_attrVal(FXmlTagPWDL.A_Transformer, FXmlTagPWDL.D_Transformer),
                            this.dataConversionSetExpression,
                            ref length
                            );
                    }
                    else
                    {
                        value = FValueConverter.toDataConversionStringValue(
                            (FFormat)fFormat,
                            this.originalStringValue,
                            this.fXmlNode.get_attrVal(FXmlTagPWDL.A_Transformer, FXmlTagPWDL.D_Transformer),
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

        public void copy(
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.clone(true);

                // --

                FPlcDriverLogCommon.removeLogUniqueId(fXmlNode);

                // --

                this.copyObject(FCbObjectFormat.PlcWord, fXmlNode);
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

        public FPlcWordLogCollection selectPlcWordLogByName(
            string name
            )
        {
            const string xpath = FXmlTagPWDL.E_PlcWord + "[@" + FXmlTagPWDL.A_Name + "='{0}']";

            try
            {
                return new FPlcWordLogCollection(
                    this.fPcdlCore,
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

        public FPlcWordLog selectSinglePlcWordLogByName(
            string name
            )
        {
            const string xpath = FXmlTagPWDL.E_PlcWord + "[@" + FXmlTagPWDL.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FPlcWordLog(this.fPcdlCore, fXmlNode);
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

        public FPlcWordLogCollection selectAllPlcWordLogByName(
            string name
            )
        {
            const string xpath = ".//" + FXmlTagPWDL.E_PlcWord + "[@" + FXmlTagPWDL.A_Name + "='{0}']";

            try
            {
                return new FPlcWordLogCollection(
                    this.fPcdlCore,
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

        public FPlcWordLog selectSingleAllPlcWordLogByName(
            string name
            )
        {
            const string xpath = ".//" + FXmlTagPWDL.E_PlcWord + "[@" + FXmlTagPWDL.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FPlcWordLog(this.fPcdlCore, fXmlNode);
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

        public FPlcWordLog selectSingleAllPlcWordLogByIndex(
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
                return new FPlcWordLog(this.fPcdlCore, fXmlNode);
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
