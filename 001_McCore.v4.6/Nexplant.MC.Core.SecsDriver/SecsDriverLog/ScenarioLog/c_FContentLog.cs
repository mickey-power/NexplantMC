/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FContentLog.cs
--  Creator         : spike.lee
--  Create Date     : 2012.04.25
--  Description     : FAMate Core FaSecsDriver Content Log Class 
--  History         : Created by spike.lee at 2012.04.25
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public class FContentLog : FBaseObjectLog<FContentLog>, FIObjectLog
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;    
        // --

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FContentLog(      
            FSecsDriver fSecsDriver
            )
            : base(FSecsDriverLogCommon.createXmlNodeCTTL(fSecsDriver.fScdCore.fXmlDoc))
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FContentLog(
            FSecsDriver fSecsDriver,
            string name,
            FFormat fFormat,
            string stringValue
            )
            : base (FSecsDriverLogCommon.createXmlNodeCTTL(fSecsDriver.fScdCore.fXmlDoc, name, fFormat, stringValue))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FContentLog(
            FScdlCore fScdlCore, 
            FXmlNode fXmlNode
            )
            : base(fScdlCore, fXmlNode)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FContentLog(
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
                    return FObjectLogType.ContentLog;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectLogType.ContentLog;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string logUniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagCTTL.A_LogUniqueId, FXmlTagCTTL.D_LogUniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagCTTL.A_UniqueId, FXmlTagCTTL.D_UniqueId);
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
                    return this.fXmlNode.get_attrVal(FXmlTagCTTL.A_Name, FXmlTagCTTL.D_Name);
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
                    return this.fXmlNode.get_attrVal(FXmlTagCTTL.A_Description, FXmlTagCTTL.D_Description);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagCTTL.A_FontColor, FXmlTagCTTL.D_FontColor));
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
                    this.fXmlNode.set_attrVal(FXmlTagCTTL.A_FontColor, FXmlTagCTTL.D_FontColor, value.Name);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagCTTL.A_FontBold, FXmlTagCTTL.D_FontBold));
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
                    this.fXmlNode.set_attrVal(FXmlTagCTTL.A_FontBold, FXmlTagCTTL.D_FontBold, FBoolean.fromBool(value));
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
                    return FEnumConverter.toFormat(this.fXmlNode.get_attrVal(FXmlTagCTTL.A_Format, FXmlTagCTTL.D_Format));
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

        public string stringValue
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagCTTL.A_Value, FXmlTagCTTL.D_Value);
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
                    return FValueConverter.toStringArrayValue(this.fFormat, this.stringValue);
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
                    return FValueConverter.toValue(this.fFormat, this.stringValue, this.length);
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
                    return FValueConverter.toEncodingValue(this.fFormat, this.stringValue);
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

        public int length
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagCTTL.A_Length, FXmlTagCTTL.D_Length));
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

        public string userTag1
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagCTTL.A_UserTag1, FXmlTagCTTL.D_UserTag1);
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
                    return this.fXmlNode.get_attrVal(FXmlTagCTTL.A_UserTag2, FXmlTagCTTL.D_UserTag2);
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
                    return this.fXmlNode.get_attrVal(FXmlTagCTTL.A_UserTag3, FXmlTagCTTL.D_UserTag3);
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
                    return this.fXmlNode.get_attrVal(FXmlTagCTTL.A_UserTag4, FXmlTagCTTL.D_UserTag4);
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
                    return this.fXmlNode.get_attrVal(FXmlTagCTTL.A_UserTag5, FXmlTagCTTL.D_UserTag5);
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
                    return this.fXmlNode.containsNode(FXmlTagCTTL.E_Content);
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

                try
                {
                    if (this.fXmlNode.fParentNode == null)
                    {
                        return null;
                    }

                    // --

                    fXmlNodeParent = this.fXmlNode.fParentNode;

                    // --

                    if (fXmlNodeParent.name == FXmlTagAPPL.E_Application)
                    {
                        return new FApplicationWrittenLog(this.fScdlCore, fXmlNodeParent);
                    }
                    return new FContentLog(this.fScdlCore, fXmlNodeParent);
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

        public FContentLog fPreviousSibling
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

                    return new FContentLog(this.fScdlCore, this.fXmlNode.fPreviousSibling);
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

        public FContentLog fNextSibling
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

                    return new FContentLog(this.fScdlCore, this.fXmlNode.fNextSibling);
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

        public FContentLogCollection fChildContentLogCollection
        {
            get
            {
                try
                {
                    return new FContentLogCollection(this.fScdlCore, this.fXmlNode.selectNodes(FXmlTagCTTL.E_Content));
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
            string info = string.Empty;
            FFormat fFormat;

            try
            {
                if (option == FStringOption.Default)
                {
                    info = this.name;
                }
                else
                {
                    fFormat = this.fFormat;

                    // --

                    info += FEnumConverter.fromFormat(fFormat) + "[" + this.length.ToString() + "]";
                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                    {
                        info += " " + this.name;
                    }
                    else if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2 || fFormat == FFormat.Char)
                    {
                        info += " " + this.name + "=\"" + this.encodingValue + "\"";
                    }
                    else
                    {
                        info += " " + this.name + "=\"" + this.stringValue + "\"";
                    }
                }

                // --

                if (this.description != string.Empty)
                {
                    info += (" Desc=[" + this.description + "]");
                }
                // --
                return info;
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

        public FContentLog appendChildContentLog(
            FContentLog fNewChild
            )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                
                // ***
                // Format이 list인 Environment,만이  Child enviroment를 가질수 있다.
                // ***
                if (this.fFormat != FFormat.List && this.fFormat != FFormat.AsciiList)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Content Log's Format", "List or the AsciiList"));
                }

                // ***
                // Format이 AsciiList인 경우 Ascii Format의 Child Content Log만을 가질 수 있다.
                // ***
                if (this.fFormat == FFormat.AsciiList && fNewChild.fFormat != FFormat.Ascii)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Format of New Child", "Ascii"));
                }

                // -- 

                fNewChild.replace(this.fScdlCore, this.fXmlNode.appendChild(fNewChild.fXmlNode));

                // --

                // ***
                // 현재 Content Log의 Length 1증가
                // ***
                this.fXmlNode.set_attrVal(FXmlTagCTTL.A_Length, FXmlTagCTTL.D_Length, (this.length + 1).ToString());

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

        public FContentLog appendChildContentLog(
            FSecsDriver fSecsDriver,
            string name,
            FFormat fFormat,
            string stringValue
            )
        {
            try
            {
                return appendChildContentLog(new FContentLog(fSecsDriver, name, fFormat, stringValue));
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

        public FContentLog insertBeforeChildContentLog(
            FContentLog fNewChild,
            FContentLog fRefChild
            )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                if (this.fFormat != FFormat.List && this.fFormat != FFormat.AsciiList)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Content Log's Format", "List or the AsciiList"));
                }

                // ***
                // Format이 AsciiList인 경우 Ascii Format의 Child Environment만을 가질 수 있다.
                // ***
                if (this.fFormat == FFormat.AsciiList && fNewChild.fFormat != FFormat.Ascii)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Format of New Child", "Ascii"));
                }

                // --

                fNewChild.replace(this.fScdlCore, this.fXmlNode.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));

                // --

                // ***
                // 현재 Environment 의 Length 1증가
                // ***
                this.fXmlNode.set_attrVal(FXmlTagCTTL.A_Length, FXmlTagCTTL.D_Length, (this.length + 1).ToString());

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

        public FContentLog insertBeforeChildContentLog(
            FSecsDriver fSecsDriver,
            string name,
            FFormat fFormat,
            string stringValue,
            FContentLog fRefChild
            )
        {
            try
            {
                return insertBeforeChildContentLog(
                    new FContentLog(fSecsDriver, name, fFormat, stringValue),
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

        public FContentLog insertAfterChildContentLog(
            FContentLog fNewChild,
            FContentLog fRefChild
            )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                if (this.fFormat != FFormat.List && this.fFormat != FFormat.AsciiList)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Content Log's Format", "List or the AsciiList"));
                }

                // ***
                // Format이 AsciiList인 경우 Ascii Format의 Child Environment만을 가질 수 있다.
                // ***
                if (this.fFormat == FFormat.AsciiList && fNewChild.fFormat != FFormat.Ascii)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Format of New Child", "Ascii"));
                }

                // --

                fNewChild.replace(this.fScdlCore, this.fXmlNode.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));

                // --

                // ***
                // 현재 Environment 의 Length 1증가
                // ***
                this.fXmlNode.set_attrVal(FXmlTagCTTL.A_Length, FXmlTagCTTL.D_Length, (this.length + 1).ToString());

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

        public FContentLog insertAfterChildContentLog(
            FSecsDriver fSecsDriver,
            string name,
            FFormat fFormat,
            string stringValue,
            FContentLog fRefChild
            )
        {
            try
            {
                return insertAfterChildContentLog(
                    new FContentLog(fSecsDriver, name, fFormat, stringValue),
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

        public FContentLog removeChildContentLog(
            FContentLog fChild
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

        public void removeChildContentLog(
            FContentLog[] fChilds
            )
        {
            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                foreach (FContentLog fCttl in fChilds)
                {
                    FSecsDriverCommon.validateRemoveChildObject(this.fXmlNode, fCttl.fXmlNode);
                }

                // --

                foreach (FContentLog fCttl in fChilds)
                {
                    fCttl.remove();
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

        public void removeAllChildContentLog(
            )
        {
            FContentLogCollection fCttlCollection = null;

            try
            {
                fCttlCollection = this.fChildContentLogCollection;
                if (fCttlCollection.count == 0)
                {
                    return;
                }

                // --

                foreach (FContentLog fCttl in fCttlCollection)
                {
                    fCttl.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fCttlCollection != null)
                {
                    fCttlCollection.Dispose();
                    fCttlCollection = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void remove(
            )
        {
            FIObjectLog fParent = null;
            int length = 0;

            try
            {
                FSecsDriverCommon.validateRemoveChildObject(this.fXmlNode.fParentNode, this.fXmlNode);

                // --

                fParent = this.fParent;
                if (fParent.fObjectLogType == FObjectLogType.ApplicationWrittenLog)
                {
                    this.replace(this.fScdlCore, ((FApplicationWrittenLog)fParent).fXmlNode.removeChild(this.fXmlNode));
                }
                else
                {
                    this.replace(this.fScdlCore, ((FContentLog)fParent).fXmlNode.removeChild(this.fXmlNode));
                    // --
                    length = int.Parse(((FContentLog)fParent).fXmlNode.get_attrVal(FXmlTagCTTL.A_Length, FXmlTagCTTL.D_Length)) - 1;
                    ((FContentLog)fParent).fXmlNode.set_attrVal(FXmlTagCTTL.A_Length, FXmlTagCTTL.D_Length, length.ToString());
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

        private void setChangedFormat(
            )
        {
            try
            {
                this.fXmlNode.set_attrVal(FXmlTagCTTL.A_Value, FXmlTagCTTL.D_Value, FXmlTagCTTL.D_Value);
                this.fXmlNode.set_attrVal(FXmlTagCTTL.A_Length, FXmlTagCTTL.D_Length, FXmlTagCTTL.D_Length);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
