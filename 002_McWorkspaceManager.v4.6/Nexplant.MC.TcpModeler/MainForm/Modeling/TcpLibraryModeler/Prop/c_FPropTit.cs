/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropTit.cs
--  Creator         : duchoi
--  Create Date     : 2013.07.24
--  Description     : FAMate TCP Modeler TCP Item Property Source Object Class 
--  History         : Created by duchoi at 2013.07.24
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaTcpDriver;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.TcpModeler
{
    public class FPropTit : FDynPropCusBase<FTcmCore>
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
        private FTcpItem m_fTit = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropTit(
            FTcmCore fTcmCore,
            FDynPropGrid fPropGrid,
            FTcpItem fTit
            )
            : base(fTcmCore, fTcmCore.fUIWizard, fPropGrid)
        {
            m_fTit = fTit;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropTit(
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
                    m_fTit = null;
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
                    return m_fTit.fObjectType.ToString();
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
                    return m_fTit.uniqueIdToString;
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
        [TypeConverter(typeof(FPropAttrNameStringConverter))]
        public string Name
        {
            get
            {
                try
                {
                    return m_fTit.name;
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

            set
            {
                try
                {
                    FCommon.validateName(value, true, this.mainObject.fUIWizard);

                    // --

                    m_fTit.name = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
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
                    return m_fTit.description;
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

            set
            {
                try
                {
                    m_fTit.description = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
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
                    return m_fTit.fontColor;
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

            set
            {
                try
                {
                    m_fTit.fontColor = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
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
                    return m_fTit.fontBold;
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

            set
            {
                try
                {
                    m_fTit.fontBold = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
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
                    return m_fTit.fPattern;
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

            set
            {
                try
                {
                    if (this.Pattern == value)
                    {
                        return;
                    }

                    // --                    

                    if (value == FPattern.Variable)
                    {
                        // ***
                        // 형제 Variable TCP Item과 연속적으로 이어져야 한다.
                        // ***
                        if (
                            (m_fTit.fParent.fObjectType == FObjectType.TcpMessage && ((FTcpMessage)m_fTit.fParent).hasVariableChild) ||
                            (m_fTit.fParent.fObjectType == FObjectType.TcpItem && ((FTcpItem)m_fTit.fParent).hasVariableChild)
                            )
                        {
                            if (m_fTit.fPreviousSibling == null && m_fTit.fNextSibling.fPattern != FPattern.Variable)
                            {
                                FDebug.throwFException(fUIWizard.generateMessage("E0012", new object[] { "TCP Item" }));
                            }
                            else if (m_fTit.fNextSibling == null && m_fTit.fPreviousSibling.fPattern != FPattern.Variable)
                            {
                                FDebug.throwFException(fUIWizard.generateMessage("E0012", new object[] { "TCP Item" }));
                            }
                            else if (
                                (m_fTit.fPreviousSibling != null) &&
                                (m_fTit.fNextSibling != null) &&
                                (m_fTit.fPreviousSibling.fPattern != FPattern.Variable && m_fTit.fNextSibling.fPattern != FPattern.Variable)
                                )
                            {
                                FDebug.throwFException(fUIWizard.generateMessage("E0012", new object[] { "TCP Item" }));
                            }
                        }
                    }
                  
                    // --

                    m_fTit.fPattern = value;

                    // --

                    setChangedPattern();
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
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
                    return m_fTit.fixedLength;
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

            set
            {
                try
                {
                    if (value < 1)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                    }

                    // --

                    m_fTit.fixedLength = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
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
                    return m_fTit.fFormat;
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

            set
            {
                try
                {
                    m_fTit.fFormat = value;
                    setChangedFormat();
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
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
                    return m_fTit.fScanMode;
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

            set
            {
                try
                {
                    m_fTit.fScanMode = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Value

        [Category(CategoryValue)]
        [Editor(typeof(FPropAttrTitValueUITypeEditor), typeof(UITypeEditor))]
        public string OriginalValue
        {
            get
            {
                try
                {
                    return getDisplayValue(m_fTit.originalStringValue);
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

            set
            {
                try
                {
                    m_fTit.originalStringValue = value;
                    this.fPropGrid.Refresh();
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
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
                    this.fPropGrid.Tag = "OriginalEncodingValue";   // hint
                    return getDisplayValue(m_fTit.originalEncodingValue);
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

        [Category(CategoryValue)]
        public int OriginalLength
        {
            get
            {
                try
                {
                    return m_fTit.originalLength;
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
                    return m_fTit.randomValue;
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
            set
            {
                try
                {
                    m_fTit.randomValue = value;
                    setChangedRandomValue();
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
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
                    return m_fTit.randomValueMin;
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
            set
            {
                try
                {
                    m_fTit.randomValueMin = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
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
                    return m_fTit.randomValueMax;
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
            set
            {
                try
                {
                    m_fTit.randomValueMax = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
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
                    return m_fTit.valueType.ToString();
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
                    return m_fTit.isArrayValue;
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
                    return m_fTit.isNullValue;
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
                    this.fPropGrid.Tag = "Value";   // hint
                    return getDisplayValue(m_fTit.stringValue);
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
                    this.fPropGrid.Tag = "EncodingValue";   // hint
                    return getDisplayValue(m_fTit.encodingValue);
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
                    return m_fTit.length;
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
        [Editor(typeof(FPropAttrTitValueTransformerUITypeEditor), typeof(UITypeEditor))]
        public string ValueTransformer
        {
            get
            {
                try
                {
                    return m_fTit.fValueTransformer.ToString();
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
        [Editor(typeof(FPropAttrTitDataConversionSetUITypeEditor), typeof(UITypeEditor))]
        public string DataConversionSet
        {
            get
            {
                try
                {
                    return m_fTit.hasDataConversionSet ? m_fTit.fDataConversionSet.name : string.Empty;
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
        [Editor(typeof(FPropAttrTitPreconditionUITypeEditor), typeof(UITypeEditor))]
        public string Precondition
        {
            get
            {
                try
                {
                    return m_fTit.fPrecondition.ToString();
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
                    return m_fTit.reservedWord;
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

            set
            {
                try
                {
                    m_fTit.reservedWord = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
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
                    return m_fTit.extraction;
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

            set
            {
                try
                {
                    m_fTit.extraction = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
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
                    return m_fTit.userTag1;
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

            set
            {
                try
                {
                    m_fTit.userTag1 = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
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
                    return m_fTit.userTag2;
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

            set
            {
                try
                {
                    m_fTit.userTag2 = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
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
                    return m_fTit.userTag3;
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

            set
            {
                try
                {
                    m_fTit.userTag3 = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
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
                    return m_fTit.userTag4;
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

            set
            {
                try
                {
                    m_fTit.userTag4 = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
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
                    return m_fTit.userTag5;
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

            set
            {
                try
                {
                    m_fTit.userTag5 = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        [Browsable(false)]
        public FTcpItem fTcpItem
        {
            get
            {
                try
                {
                    return m_fTit;
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
                base.fTypeDescriptor.properties["DataConversionSet"].attributes.replace(new DisplayNameAttribute("Data Conversion Set"));
                // --
                base.fTypeDescriptor.properties["Precondition"].attributes.replace(new DisplayNameAttribute("Precondition"));
                // --
                base.fTypeDescriptor.properties["ReservedWord"].attributes.replace(new DisplayNameAttribute("Reserved Word"));
                base.fTypeDescriptor.properties["Extraction"].attributes.replace(new DisplayNameAttribute("Extraction"));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DisplayNameAttribute(m_fTit.defUserTagName1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DisplayNameAttribute(m_fTit.defUserTagName2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DisplayNameAttribute(m_fTit.defUserTagName3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DisplayNameAttribute(m_fTit.defUserTagName4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DisplayNameAttribute(m_fTit.defUserTagName5));

                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_fTit.fObjectType.ToString()));
                base.fTypeDescriptor.properties["ID"].attributes.replace(new DefaultValueAttribute(m_fTit.uniqueIdToString));
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(m_fTit.name));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_fTit.description));
                // --
                base.fTypeDescriptor.properties["FontColor"].attributes.replace(new DefaultValueAttribute(m_fTit.fontColor));
                base.fTypeDescriptor.properties["FontBold"].attributes.replace(new DefaultValueAttribute(m_fTit.fontBold));
                // --
                base.fTypeDescriptor.properties["Pattern"].attributes.replace(new DefaultValueAttribute(m_fTit.fPattern));
                base.fTypeDescriptor.properties["FixedLength"].attributes.replace(new DefaultValueAttribute(m_fTit.fixedLength));
                base.fTypeDescriptor.properties["Format"].attributes.replace(new DefaultValueAttribute(m_fTit.fFormat));
                // --
                base.fTypeDescriptor.properties["ScanMode"].attributes.replace(new DefaultValueAttribute(m_fTit.fScanMode));
                // --
                base.fTypeDescriptor.properties["OriginalValue"].attributes.replace(new DefaultValueAttribute(getDisplayValue(m_fTit.originalStringValue)));
                base.fTypeDescriptor.properties["OriginalEncodingValue"].attributes.replace(new DefaultValueAttribute(getDisplayValue(m_fTit.originalEncodingValue)));
                base.fTypeDescriptor.properties["OriginalLength"].attributes.replace(new DefaultValueAttribute(m_fTit.originalLength));
                // --
                base.fTypeDescriptor.properties["RandomValue"].attributes.replace(new DefaultValueAttribute(m_fTit.randomValue));
                base.fTypeDescriptor.properties["RandomValueMin"].attributes.replace(new DefaultValueAttribute(m_fTit.randomValueMin));
                base.fTypeDescriptor.properties["RandomValueMax"].attributes.replace(new DefaultValueAttribute(m_fTit.randomValueMax));
                // --
                base.fTypeDescriptor.properties["ValueType"].attributes.replace(new DefaultValueAttribute(m_fTit.valueType.ToString()));
                base.fTypeDescriptor.properties["ArrayValue"].attributes.replace(new DefaultValueAttribute(m_fTit.isArrayValue));
                base.fTypeDescriptor.properties["NullValue"].attributes.replace(new DefaultValueAttribute(m_fTit.isNullValue));
                base.fTypeDescriptor.properties["Value"].attributes.replace(new DefaultValueAttribute(getDisplayValue(m_fTit.stringValue)));
                base.fTypeDescriptor.properties["EncodingValue"].attributes.replace(new DefaultValueAttribute(getDisplayValue(m_fTit.encodingValue)));
                base.fTypeDescriptor.properties["Length"].attributes.replace(new DefaultValueAttribute(m_fTit.length));
                // --
                base.fTypeDescriptor.properties["ValueTransformer"].attributes.replace(new DefaultValueAttribute(m_fTit.fValueTransformer.ToString()));
                base.fTypeDescriptor.properties["DataConversionSet"].attributes.replace(new DefaultValueAttribute(m_fTit.hasDataConversionSet ? m_fTit.fDataConversionSet.name : string.Empty));
                // --
                base.fTypeDescriptor.properties["Precondition"].attributes.replace(new DefaultValueAttribute(m_fTit.fPrecondition.ToString()));
                // --
                base.fTypeDescriptor.properties["ReservedWord"].attributes.replace(new DefaultValueAttribute(m_fTit.reservedWord));
                base.fTypeDescriptor.properties["Extraction"].attributes.replace(new DefaultValueAttribute(m_fTit.extraction));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DefaultValueAttribute(m_fTit.userTag1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DefaultValueAttribute(m_fTit.userTag2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DefaultValueAttribute(m_fTit.userTag3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DefaultValueAttribute(m_fTit.userTag4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DefaultValueAttribute(m_fTit.userTag5));

                // --

                procRefreshRequested();

                // --

                this.fPropGrid.DynPropGridRefreshRequested += new FDynPropGridRefreshRequestedEventHandler(fPropGrid_DynPropGridRefreshRequested);
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
                this.fPropGrid.DynPropGridRefreshRequested -= new FDynPropGridRefreshRequestedEventHandler(fPropGrid_DynPropGridRefreshRequested);
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

        private void procRefreshRequested(
            )
        {
            try
            {
                setChangedPattern();
                setChangedFormat();
                setChangedRandomValue();
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

        private void setChangedPattern(
            )
        {
            FPattern pattern;

            try
            {
                pattern = this.Pattern;

                // --

                if (pattern == FPattern.Fixed)
                {  
                    base.fTypeDescriptor.properties["Pattern"].attributes.replace(new ReadOnlyAttribute(false));
                    base.fTypeDescriptor.properties["FixedLength"].attributes.replace(new ReadOnlyAttribute(false));
                    base.fTypeDescriptor.properties["FixedLength"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["ScanMode"].attributes.replace(new BrowsableAttribute(true));   
                }
                else if (pattern == FPattern.Variable)
                {
                    if (
                        (m_fTit.fPreviousSibling != null && m_fTit.fPreviousSibling.fPattern == FPattern.Variable) &&
                        (m_fTit.fNextSibling != null && m_fTit.fNextSibling.fPattern == FPattern.Variable)
                        )
                    {
                        base.fTypeDescriptor.properties["Pattern"].attributes.replace(new ReadOnlyAttribute(true));
                    }
                    else
                    {
                        base.fTypeDescriptor.properties["Pattern"].attributes.replace(new ReadOnlyAttribute(false));
                    }
                    base.fTypeDescriptor.properties["FixedLength"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["ScanMode"].attributes.replace(new BrowsableAttribute(false));   
                }             

                // --

                this.fPropGrid.Refresh();
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
            FFormat fFormat;

            try
            {
                fFormat = this.Format;

                // --

                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                {
                    base.fTypeDescriptor.properties["Format"].attributes.replace(new ReadOnlyAttribute(m_fTit.hasChild | m_fTit.locked));
                    // --
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
                    // --
                    base.fTypeDescriptor.properties["Precondition"].attributes.replace(new BrowsableAttribute(false));
                }
                else if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2)
                {
                    if (fFormat == FFormat.Ascii && m_fTit.fParent.fObjectType == FObjectType.TcpItem && ((FTcpItem)m_fTit.fParent).fFormat == FFormat.AsciiList)
                    {
                        base.fTypeDescriptor.properties["Format"].attributes.replace(new ReadOnlyAttribute(true));
                    }
                    else
                    {
                        base.fTypeDescriptor.properties["Format"].attributes.replace(new ReadOnlyAttribute(m_fTit.locked));
                    }
                    // --
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
                    // --
                    base.fTypeDescriptor.properties["Precondition"].attributes.replace(new BrowsableAttribute(true));
                }
                else if (fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                {
                    base.fTypeDescriptor.properties["Format"].attributes.replace(new ReadOnlyAttribute(m_fTit.locked));
                    // --
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
                    // --
                    base.fTypeDescriptor.properties["Precondition"].attributes.replace(new BrowsableAttribute(false));
                }
                else
                {
                    base.fTypeDescriptor.properties["Format"].attributes.replace(new ReadOnlyAttribute(m_fTit.locked));
                    // --
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
                    // --
                    base.fTypeDescriptor.properties["Precondition"].attributes.replace(new BrowsableAttribute(true));
                }
               
                // --

                this.fPropGrid.Refresh();
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

        private void setChangedRandomValue(
            )
        {
            try
            {
                // --

                if (m_fTit.fFormat == FFormat.List ||
                    m_fTit.fFormat == FFormat.AsciiList ||
                    m_fTit.fFormat == FFormat.Ascii ||
                    m_fTit.fFormat == FFormat.JIS8 ||
                    m_fTit.fFormat == FFormat.A2 ||
                    m_fTit.fFormat == FFormat.Unknown ||
                    m_fTit.fFormat == FFormat.Raw ||
                    m_fTit.fFormat == FFormat.Boolean
                    )
                {
                    base.fTypeDescriptor.properties["RandomValue"].attributes.replace(new BrowsableAttribute(false));
                }
                else
                {
                    base.fTypeDescriptor.properties["RandomValue"].attributes.replace(new BrowsableAttribute(true));
                }

                // --

                if (!m_fTit.randomValue)
                {
                    // --
                    base.fTypeDescriptor.properties["RandomValueMin"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["RandomValueMax"].attributes.replace(new BrowsableAttribute(false));
                }
                else
                {
                    // --
                    base.fTypeDescriptor.properties["RandomValueMin"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["RandomValueMax"].attributes.replace(new BrowsableAttribute(true));
                }

                // --

                this.fPropGrid.Refresh();
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

        public string getDisplayValue(
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

        #region fPropGrid Event Handler

        private void fPropGrid_DynPropGridRefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                procRefreshRequested();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
