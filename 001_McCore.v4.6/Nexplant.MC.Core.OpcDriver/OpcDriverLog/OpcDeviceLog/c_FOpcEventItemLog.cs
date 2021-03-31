/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FOpcEventItemLog.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2013.10.30
--  Description     : FAMate Core FaOpcDriver OPC Event Item Log Class
--  History         : Created by jungyoul.moon at 2013.10.30
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    public class FOpcEventItemLog : FBaseObjectLog<FOpcEventItemLog>, FIObjectLog
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FOpcEventItemLog(
            FOpcDriverLog fOpcDriverLog
            )
            : base()
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FOpcEventItemLog(
            FOcdlCore fOcdlCore,
            FXmlNode fXmlNode
            )
            : base(fOcdlCore, fXmlNode)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FOpcEventItemLog(
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
                    return FObjectLogType.OpcEventItemLog;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectLogType.OpcEventItemLog;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOEIL.A_UniqueId, FXmlTagOEIL.D_UniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOEIL.A_LogUniqueId, FXmlTagOEIL.D_LogUniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOEIL.A_Name, FXmlTagOEIL.D_Name);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOEIL.A_Description, FXmlTagOEIL.D_Description);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagOEIL.A_FontColor, FXmlTagOEIL.D_FontColor));
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagOEIL.A_FontBold, FXmlTagOEIL.D_FontBold));
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
                    return this.fXmlNode.get_attrVal(FXmlTagOEIL.A_ItemName, FXmlTagOEIL.D_ItemName);
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

        public FTagFormat fItemForamt
        {
            get
            {
                try
                {
                    return FEnumConverter.toTagFormat(this.fXmlNode.get_attrVal(FXmlTagOEIL.A_ItemFormat, FXmlTagOEIL.D_ItemFormat));
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

        public bool hashTag
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagOEIL.A_HashTag, FXmlTagOEIL.D_HashTag));
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
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagOEIL.A_ItemStart, FXmlTagOEIL.D_ItemStart));
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
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagOEIL.A_ItemLength, FXmlTagOEIL.D_ItemLength));
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

        public bool alwaysEvent
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagOEIL.A_AlwaysEvent, FXmlTagOEIL.D_AlwaysEvent));
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

        public bool ignoreFirst
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagOEIL.A_IgnoreFirst, FXmlTagOEIL.D_IgnoreFirst));
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

        public FOpcFormat fFormat
        {
            get
            {
                try
                {
                    return FEnumConverter.toOpcFormat(this.fXmlNode.get_attrVal(FXmlTagOEIL.A_Format, FXmlTagOEIL.D_Format));
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
                            this.fXmlNode.get_attrVal(FXmlTagOEIL.A_Transformer, FXmlTagOEIL.D_Transformer),
                            string.Empty,
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

        public string originalStringValue
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOEIL.A_Value, FXmlTagOEIL.D_Value);
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
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagOEIL.A_Length, FXmlTagOEIL.D_Length));
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
                        this.fXmlNode.get_attrVal(FXmlTagOEIL.A_Transformer, FXmlTagOEIL.D_Transformer),
                        string.Empty,
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
                        this.fXmlNode.get_attrVal(FXmlTagOEIL.A_Transformer, FXmlTagOEIL.D_Transformer),
                        string.Empty
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
                        this.fXmlNode.get_attrVal(FXmlTagOEIL.A_Transformer, FXmlTagOEIL.D_Transformer),
                        string.Empty,
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
                        this.fXmlNode.get_attrVal(FXmlTagOEIL.A_Transformer, FXmlTagOEIL.D_Transformer),
                        string.Empty
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

        public FOpcEventItemLogValueTransformer fValueTransformer
        {
            get
            {
                try
                {
                    return new FOpcEventItemLogValueTransformer(this);
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

        public string result
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagOEIL.A_Result, FXmlTagOEIL.D_Result);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOEIL.A_UserTag1, FXmlTagOEIL.D_UserTag1);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOEIL.A_UserTag2, FXmlTagOEIL.D_UserTag2);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOEIL.A_UserTag3, FXmlTagOEIL.D_UserTag3);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOEIL.A_UserTag4, FXmlTagOEIL.D_UserTag4);
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
                    return this.fXmlNode.get_attrVal(FXmlTagOEIL.A_UserTag5, FXmlTagOEIL.D_UserTag5);
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

        public bool hasValueTransformer
        {
            get
            {
                try
                {
                    if (this.fXmlNode.get_attrVal(FXmlTagOEIL.A_Transformer, FXmlTagOEIL.D_Transformer) == string.Empty)
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

        public FOpcEventItemListLog fParent
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

                    return new FOpcEventItemListLog(this.fOcdlCore, this.fXmlNode.fParentNode);
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

        public FOpcEventItemLog fPreviousSibling
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

                    return new FOpcEventItemLog(this.fOcdlCore, this.fXmlNode.fPreviousSibling);
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

        public FOpcEventItemLog fNextSibling
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

                    return new FOpcEventItemLog(this.fOcdlCore, this.fXmlNode.fPreviousSibling);
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
            string value = string.Empty;
            int length = 0;

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
                    if (this.alwaysEvent)
                    {
                        info.Append("[ae.] ");
                    }

                    // --

                    if (this.ignoreFirst)
                    {
                        info.Append("[ig.] ");
                    }

                    // --

                    if (this.hasValueTransformer)
                    {
                        info.Append("[vt.] ");
                    }

                    // --

                    info.Append("[" + this.itemName + "] " + FEnumConverter.fromOpcFormat(this.fFormat) + "[" + this.length.ToString() + "] " + this.name);

                    // --

                    if (fFormat == FOpcFormat.Ascii)
                    {
                        value = FValueConverter.toDataConversionedEncodingValue(
                            (FFormat)fFormat,
                            this.originalStringValue,
                            this.fXmlNode.get_attrVal(FXmlTagOEIL.A_Transformer, FXmlTagOEIL.D_Transformer),
                            string.Empty,
                            ref length
                            );
                    }
                    else
                    {
                        value = FValueConverter.toDataConversionStringValue(
                            (FFormat)fFormat,
                            this.originalStringValue,
                            this.fXmlNode.get_attrVal(FXmlTagOEIL.A_Transformer, FXmlTagOEIL.D_Transformer),
                            string.Empty,
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
                info = null;
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

                this.copyObject(FCbObjectFormat.OpcEventItem, fXmlNode);
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
