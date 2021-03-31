/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropSitl.cs
--  Creator         : by.Jeon
--  Create Date     : 2011.10.14
--  Description     : FAMate SECS Modeler SECS Item Log Property Source Object Class 
--  History         : Created by byJeon at 2011.10.14
                      Modified by kitae at 2011.10.20
                       - ValueTransformerUITypeViewer Add
                       - PreconditionUITypeViewer Add
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Text;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaSecsDriver;

namespace Nexplant.MC.SecsModeler
{
    public class FPropSitl : FDynPropCusBase<FSsmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryFont = "[02] Font";
        private const string CategoryFormat = "[03] Format";
        private const string CategoryScan = "[04] Scan";
        private const string CategoryValue = "[05] Value";
        private const string CategoryValueInformation = "[06] Value Information";
        private const string CategoryTransformation = "[07] Transformation";
        private const string CategoryCondition = "[08] Condition";
        private const string CategoryCollection = "[09] Collection";
        private const string CategoryUserTag = "[10] User Tag";

        // --

        private bool m_disposed = false;
        // --
        private FSecsItemLog m_fSitl = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropSitl(
            FSsmCore fSsmCore,
            FDynPropGrid fPropGrid,
            FSecsItemLog fSitl
            )
            : base(fSsmCore, fSsmCore.fUIWizard, fPropGrid)
        {
            m_fSitl = fSitl;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropSitl(
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
                    term();
                    // --
                    m_fSitl = null;
                }
                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------
                
        #region General

        [Category(CategoryGeneral)]
        public string Type
        {
            get
            {
                try
                {
                    return m_fSitl.fObjectLogType.ToString();
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryGeneral)]
        public string ID
        {
            get
            {
                try
                {
                    return m_fSitl.uniqueIdToString;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryGeneral)]
        public string Name
        {
            get
            {
                try
                {
                    return m_fSitl.name;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryGeneral)]
        public string Description
        {
            get
            {
                try
                {
                    return m_fSitl.description;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Font

        [Category(CategoryFont)]
        public Color FontColor
        {
            get
            {
                try
                {
                    return m_fSitl.fontColor;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return Color.Black;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryFont)]
        public bool FontBold
        {
            get
            {
                try
                {
                    return m_fSitl.fontBold;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return false;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Format

        [Category(CategoryFormat)]
        public FPattern Pattern
        {
            get
            {
                try
                {
                    return m_fSitl.fPattern;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FPattern.Fixed;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryFormat)]
        public int FixedLength
        {
            get
            {
                try
                {
                    return m_fSitl.fixedLength;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return 0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryFormat)]
        public FFormat Format
        {
            get
            {
                try
                {
                    return m_fSitl.fFormat;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FFormat.Ascii;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryFormat)]
        public FSecsLengthBytes LengthBytes
        {
            get
            {
                try
                {
                    return m_fSitl.lengthBytes;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FSecsLengthBytes.Auto;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Scan

        [Category(CategoryScan)]
        public FDataScanMode ScanMode
        {
            get
            {
                try
                {
                    return m_fSitl.fScanMode;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FDataScanMode.Local;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Value

        [Category(CategoryValue)]
        [Editor(typeof(FPropAttrValueViewerUITypeEditor), typeof(UITypeEditor))]
        public string OriginalValue
        {
            get
            {
                try
                {
                    this.fPropGrid.Tag = "OriginalValue";
                    return getDisplayValue(m_fSitl.originalStringValue);
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryValue)]
        [Editor(typeof(FPropAttrValueViewerUITypeEditor), typeof(UITypeEditor))]
        public string OriginalEncodingValue
        {
            get
            {
                try
                {
                    this.fPropGrid.Tag = "OriginalEncodingValue";
                    return getDisplayValue(this.m_fSitl.originalEncodingValue);
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryValue)]
        public int OriginalLength
        {
            get
            {
                try
                {
                    return m_fSitl.originalLength;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return 0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryValue)]
        public bool RandomValue
        {
            get
            {
                try
                {
                    return m_fSitl.randomValue;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryValue)]
        public string RandomValueMin
        {
            get
            {
                try
                {
                    return m_fSitl.randomValueMin;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return "0";
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryValue)]
        public string RandomValueMax
        {
            get
            {
                try
                {
                    return m_fSitl.randomValueMax;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return "0";
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Value Information

        [Category(CategoryValueInformation)]
        public string ValueType
        {
            get
            {
                try
                {
                    return m_fSitl.valueType.ToString();
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryValueInformation)]
        public bool ArrayValue
        {
            get
            {
                try
                {
                    return m_fSitl.isArrayValue;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryValueInformation)]
        public bool NullValue
        {
            get
            {
                try
                {
                    return m_fSitl.isNullValue;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryValueInformation)]
        [Editor(typeof(FPropAttrValueViewerUITypeEditor), typeof(UITypeEditor))]
        public string Value
        {
            get
            {
                try
                {
                    this.fPropGrid.Tag = "Value";
                    return getDisplayValue(m_fSitl.stringValue);
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryValueInformation)]
        [Editor(typeof(FPropAttrValueViewerUITypeEditor), typeof(UITypeEditor))]
        public string EncodingValue
        {
            get
            {
                try
                {
                    this.fPropGrid.Tag = "EncodingValue";
                    return getDisplayValue(m_fSitl.encodingValue);
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryValueInformation)]
        public int Length
        {
            get
            {
                try
                {
                    return m_fSitl.length;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return 0;
            }
        }

        #endregion
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Transformation

        [Category(CategoryTransformation)]
        [Editor(typeof(FPropAttrSitlValueTransformerUITypeEditor), typeof(UITypeEditor))]
        public string ValueTransformer
        {
            get
            {
                try
                {
                    return m_fSitl.fValueTransformer.ToString();                    
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryTransformation)]
        public FResultCode ValueTransformerResult
        {
            get
            {
                try
                {
                    return m_fSitl.valueTransformerResult;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FResultCode.Warninig;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryTransformation)]
        public string DataConversionSet
        {
            get
            {
                try
                {
                    return m_fSitl.hasDataConversionSet ? m_fSitl.dataConversionSetName : string.Empty;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }
        }       

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Condition

        [Category(CategoryCondition)]
        [Editor(typeof(FPropAttrSitlPreconditionUITypeEditor), typeof(UITypeEditor))]
        public string Precondition
        {
            get
            {
                try
                {
                    return m_fSitl.fPrecondition.ToString();                    
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Collection

        [Category(CategoryCollection)]
        public string ReservedWord
        {
            get
            {
                try
                {
                    return m_fSitl.reservedWord;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }            
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryCollection)]
        public bool Extraction
        {
            get
            {
                try
                {
                    return m_fSitl.extraction;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return false;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region User Tag

        [Category(CategoryUserTag)]
        public string UserTag1
        {
            get
            {
                try
                {
                    return m_fSitl.userTag1;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryUserTag)]
        public string UserTag2
        {
            get
            {
                try
                {
                    return m_fSitl.userTag2;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryUserTag)]
        public string UserTag3
        {
            get
            {
                try
                {
                    return m_fSitl.userTag3;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryUserTag)]
        public string UserTag4
        {
            get
            {
                try
                {
                    return m_fSitl.userTag4;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryUserTag)]
        public string UserTag5
        {
            get
            {
                try
                {
                    return m_fSitl.userTag5;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        [Browsable(false)]
        public FSecsItemLog fSecsItemLog
        {
            get
            {
                try
                {
                    return m_fSitl;
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

        private void init(
            )
        {
            try
            {
                base.fTypeDescriptor.properties["Type"].attributes.replace(new DisplayNameAttribute("Type"));
                base.fTypeDescriptor.properties["ID"].attributes.replace(new DisplayNameAttribute("ID"));
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DisplayNameAttribute("Name"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
                // --
                base.fTypeDescriptor.properties["FontColor"].attributes.replace(new DisplayNameAttribute("Color"));
                base.fTypeDescriptor.properties["FontBold"].attributes.replace(new DisplayNameAttribute("Bold"));
                // --
                base.fTypeDescriptor.properties["Pattern"].attributes.replace(new DisplayNameAttribute("Pattern"));
                base.fTypeDescriptor.properties["FixedLength"].attributes.replace(new DisplayNameAttribute("Fixed Length"));
                base.fTypeDescriptor.properties["Format"].attributes.replace(new DisplayNameAttribute("Format"));
                base.fTypeDescriptor.properties["LengthBytes"].attributes.replace(new DisplayNameAttribute("Length Bytes"));
                // --
                base.fTypeDescriptor.properties["ScanMode"].attributes.replace(new DisplayNameAttribute("Scan Mode"));
                // --
                base.fTypeDescriptor.properties["OriginalValue"].attributes.replace(new DisplayNameAttribute("Original Value"));
                base.fTypeDescriptor.properties["OriginalEncodingValue"].attributes.replace(new DisplayNameAttribute("Original Encoding Value"));
                base.fTypeDescriptor.properties["OriginalLength"].attributes.replace(new DisplayNameAttribute("Original Length"));
                // --
                base.fTypeDescriptor.properties["RandomValue"].attributes.replace(new DisplayNameAttribute("Random Value"));
                base.fTypeDescriptor.properties["RandomValueMin"].attributes.replace(new DisplayNameAttribute("Random Value Min"));
                base.fTypeDescriptor.properties["RandomValueMax"].attributes.replace(new DisplayNameAttribute("Random Value Max"));
                // --
                base.fTypeDescriptor.properties["ValueType"].attributes.replace(new DisplayNameAttribute("Value Type"));
                base.fTypeDescriptor.properties["ArrayValue"].attributes.replace(new DisplayNameAttribute("Array"));
                base.fTypeDescriptor.properties["NullValue"].attributes.replace(new DisplayNameAttribute("Null"));
                base.fTypeDescriptor.properties["Value"].attributes.replace(new DisplayNameAttribute("Value"));
                base.fTypeDescriptor.properties["EncodingValue"].attributes.replace(new DisplayNameAttribute("Encoding Value"));
                base.fTypeDescriptor.properties["Length"].attributes.replace(new DisplayNameAttribute("Length"));
                // --
                base.fTypeDescriptor.properties["ValueTransformer"].attributes.replace(new DisplayNameAttribute("Value Transformer"));
                base.fTypeDescriptor.properties["ValueTransformerResult"].attributes.replace(new DisplayNameAttribute("Value Transformer Result"));
                base.fTypeDescriptor.properties["DataConversionSet"].attributes.replace(new DisplayNameAttribute("Data Conversion Set"));
                // --
                base.fTypeDescriptor.properties["Precondition"].attributes.replace(new DisplayNameAttribute("Precondition"));
                // --
                base.fTypeDescriptor.properties["ReservedWord"].attributes.replace(new DisplayNameAttribute("Reserved Word"));
                base.fTypeDescriptor.properties["Extraction"].attributes.replace(new DisplayNameAttribute("Extraction"));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DisplayNameAttribute("User Tag1"));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DisplayNameAttribute("User Tag2"));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DisplayNameAttribute("User Tag3"));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DisplayNameAttribute("User Tag4"));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DisplayNameAttribute("User Tag5"));

                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_fSitl.fObjectLogType.ToString()));
                base.fTypeDescriptor.properties["ID"].attributes.replace(new DefaultValueAttribute(m_fSitl.uniqueIdToString));
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(m_fSitl.name));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_fSitl.description));
                // --
                base.fTypeDescriptor.properties["FontColor"].attributes.replace(new DefaultValueAttribute(m_fSitl.fontColor));
                base.fTypeDescriptor.properties["FontBold"].attributes.replace(new DefaultValueAttribute(m_fSitl.fontBold));
                // --
                base.fTypeDescriptor.properties["Pattern"].attributes.replace(new DefaultValueAttribute(m_fSitl.fPattern));
                base.fTypeDescriptor.properties["FixedLength"].attributes.replace(new DefaultValueAttribute(m_fSitl.fixedLength));
                base.fTypeDescriptor.properties["Format"].attributes.replace(new DefaultValueAttribute(m_fSitl.fFormat));
                base.fTypeDescriptor.properties["LengthBytes"].attributes.replace(new DefaultValueAttribute(m_fSitl.lengthBytes));
                // --
                base.fTypeDescriptor.properties["ScanMode"].attributes.replace(new DefaultValueAttribute(m_fSitl.fScanMode));
                // --
                base.fTypeDescriptor.properties["OriginalValue"].attributes.replace(new DefaultValueAttribute(getDisplayValue(m_fSitl.originalStringValue)));
                base.fTypeDescriptor.properties["OriginalEncodingValue"].attributes.replace(new DefaultValueAttribute(getDisplayValue(m_fSitl.originalEncodingValue)));
                base.fTypeDescriptor.properties["OriginalLength"].attributes.replace(new DefaultValueAttribute(m_fSitl.originalLength));
                // --
                base.fTypeDescriptor.properties["RandomValue"].attributes.replace(new DefaultValueAttribute(m_fSitl.randomValue));
                base.fTypeDescriptor.properties["RandomValueMin"].attributes.replace(new DefaultValueAttribute(m_fSitl.randomValueMin));
                base.fTypeDescriptor.properties["RandomValueMax"].attributes.replace(new DefaultValueAttribute(m_fSitl.randomValueMax));
                // --
                base.fTypeDescriptor.properties["ValueType"].attributes.replace(new DefaultValueAttribute(m_fSitl.valueType.ToString()));
                base.fTypeDescriptor.properties["ArrayValue"].attributes.replace(new DefaultValueAttribute(m_fSitl.isArrayValue));
                base.fTypeDescriptor.properties["NullValue"].attributes.replace(new DefaultValueAttribute(m_fSitl.isNullValue));
                base.fTypeDescriptor.properties["Value"].attributes.replace(new DefaultValueAttribute(getDisplayValue(m_fSitl.stringValue)));
                base.fTypeDescriptor.properties["EncodingValue"].attributes.replace(new DefaultValueAttribute(getDisplayValue(m_fSitl.encodingValue)));
                base.fTypeDescriptor.properties["Length"].attributes.replace(new DefaultValueAttribute(m_fSitl.length));
                // --
                base.fTypeDescriptor.properties["ValueTransformer"].attributes.replace(new DefaultValueAttribute(m_fSitl.fValueTransformer.ToString()));
                base.fTypeDescriptor.properties["ValueTransformerResult"].attributes.replace(new DefaultValueAttribute(m_fSitl.valueTransformerResult.ToString()));
                base.fTypeDescriptor.properties["DataConversionSet"].attributes.replace(new DefaultValueAttribute(m_fSitl.hasDataConversionSet ? m_fSitl.dataConversionSetName : string.Empty));
                // --
                base.fTypeDescriptor.properties["Precondition"].attributes.replace(new DefaultValueAttribute(m_fSitl.fPrecondition.ToString()));
                // --
                base.fTypeDescriptor.properties["ReservedWord"].attributes.replace(new DefaultValueAttribute(m_fSitl.reservedWord));
                base.fTypeDescriptor.properties["Extraction"].attributes.replace(new DefaultValueAttribute(m_fSitl.extraction));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DefaultValueAttribute(m_fSitl.userTag1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DefaultValueAttribute(m_fSitl.userTag2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DefaultValueAttribute(m_fSitl.userTag3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DefaultValueAttribute(m_fSitl.userTag4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DefaultValueAttribute(m_fSitl.userTag5));

                // --

                if (Pattern == FPattern.Fixed)
                {
                    base.fTypeDescriptor.properties["FixedLength"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["ScanMode"].attributes.replace(new BrowsableAttribute(true));
                }
                else if (Pattern == FPattern.Variable)
                {
                    base.fTypeDescriptor.properties["FixedLength"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["ScanMode"].attributes.replace(new BrowsableAttribute(false));
                }

                // --

                if (Format == FFormat.List || Format == FFormat.AsciiList)
                {                    
                    base.fTypeDescriptor.properties["OriginalValue"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["OriginalEncodingValue"].attributes.replace(new BrowsableAttribute(false));
                    // --
                    base.fTypeDescriptor.properties["ValueType"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["ArrayValue"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["NullValue"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["Value"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["EncodingValue"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["Length"].attributes.replace(new BrowsableAttribute(false));
                    // --
                    base.fTypeDescriptor.properties["ValueTransformer"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["ValueTransformerResult"].attributes.replace(new BrowsableAttribute(false));
                    // --
                    base.fTypeDescriptor.properties["Precondition"].attributes.replace(new BrowsableAttribute(false));
                }
                else if (Format == FFormat.Ascii || Format == FFormat.JIS8 || Format == FFormat.A2)
                {
                    base.fTypeDescriptor.properties["OriginalValue"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["OriginalEncodingValue"].attributes.replace(new BrowsableAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["ValueType"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["ArrayValue"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["NullValue"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["Value"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["EncodingValue"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["Length"].attributes.replace(new BrowsableAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["ValueTransformer"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["ValueTransformerResult"].attributes.replace(new BrowsableAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["Precondition"].attributes.replace(new BrowsableAttribute(true));
                }
                else if (Format == FFormat.Unknown || Format == FFormat.Raw)
                {                    
                    base.fTypeDescriptor.properties["OriginalValue"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["OriginalEncodingValue"].attributes.replace(new BrowsableAttribute(false));
                    // --
                    base.fTypeDescriptor.properties["ValueType"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["ArrayValue"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["NullValue"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["Value"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["EncodingValue"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["Length"].attributes.replace(new BrowsableAttribute(false));
                    // --
                    base.fTypeDescriptor.properties["ValueTransformer"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["ValueTransformerResult"].attributes.replace(new BrowsableAttribute(false));
                    // --
                    base.fTypeDescriptor.properties["Precondition"].attributes.replace(new BrowsableAttribute(false));
                }
                else
                {                    
                    base.fTypeDescriptor.properties["OriginalValue"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["OriginalEncodingValue"].attributes.replace(new BrowsableAttribute(false));
                    // --
                    base.fTypeDescriptor.properties["ValueType"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["ArrayValue"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["NullValue"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["Value"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["EncodingValue"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["Length"].attributes.replace(new BrowsableAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["ValueTransformer"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["ValueTransformerResult"].attributes.replace(new BrowsableAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["Precondition"].attributes.replace(new BrowsableAttribute(true));
                }

                // --

                if (!m_fSitl.randomValue)
                {
                    base.fTypeDescriptor.properties["RandomValueMin"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["RandomValueMax"].attributes.replace(new BrowsableAttribute(false));
                }
                else
                {
                    base.fTypeDescriptor.properties["RandomValueMin"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["RandomValueMax"].attributes.replace(new BrowsableAttribute(true));
                }

                // --

                base.fTypeDescriptor.properties["OriginalValue"].attributes.replace(new ReadOnlyAttribute(true));
                base.fTypeDescriptor.properties["OriginalEncodingValue"].attributes.replace(new ReadOnlyAttribute(true));
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

        private void term(
            )
        {
            try
            {

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

        private string getDisplayValue(
            string value
            )
        {
            StringBuilder val = null;

            try
            {
                val = new StringBuilder();
                val.Append(value);
                if (val.Length > 1000)
                {
                    return val.ToString(0, 1000);
                }
                return val.ToString();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                val = null;
            }
            return string.Empty;
        }
        
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
