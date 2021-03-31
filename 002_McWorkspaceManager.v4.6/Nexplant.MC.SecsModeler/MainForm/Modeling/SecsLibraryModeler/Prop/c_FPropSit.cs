/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropSit.cs
--  Creator         : spike.lee
--  Create Date     : 2011.02.14
--  Description     : FAMate SECS Modeler SECS Item Property Source Object Class 
--  History         : Created by spike.lee at 2011.02.14
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
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.SecsModeler
{
    public class FPropSit : FDynPropCusBase<FSsmCore>
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
        private FSecsItem m_fSit = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropSit(
            FSsmCore fSsmCore,
            FDynPropGrid fPropGrid,
            FSecsItem fSit
            )
            : base(fSsmCore, fSsmCore.fUIWizard, fPropGrid)
        {
            m_fSit = fSit;
            // --
            init();   
        }        

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropSit(
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
                    m_fSit = null;
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
                    return m_fSit.fObjectType.ToString();
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
                    return m_fSit.uniqueIdToString;
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
                    return m_fSit.name;
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

                    m_fSit.name = value;
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
                    return m_fSit.description;
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
                    m_fSit.description = value;
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
                    return m_fSit.fontColor;
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
                    m_fSit.fontColor = value;
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
                    return m_fSit.fontBold;
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
                    m_fSit.fontBold = value;
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
                    return m_fSit.fPattern;
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
                        // 형제 Variable SECS Item과 연속적으로 이어져야 한다.
                        // ***
                        if (((FSecsItem)m_fSit.fParent).hasVariableChild)
                        {
                            if (m_fSit.fPreviousSibling == null && m_fSit.fNextSibling.fPattern != FPattern.Variable)
                            {
                                FDebug.throwFException(fUIWizard.generateMessage("E0012", new object[] { "SECS Item" }));
                            }
                            else if (m_fSit.fNextSibling == null && m_fSit.fPreviousSibling.fPattern != FPattern.Variable)
                            {
                                FDebug.throwFException(fUIWizard.generateMessage("E0012", new object[] { "SECS Item" }));
                            }
                            else if (
                                (m_fSit.fPreviousSibling != null) &&
                                (m_fSit.fNextSibling != null) &&
                                (m_fSit.fPreviousSibling.fPattern != FPattern.Variable && m_fSit.fNextSibling.fPattern != FPattern.Variable)
                                )
                            {
                                FDebug.throwFException(fUIWizard.generateMessage("E0012", new object[] { "SECS Item" }));
                            }
                        }                        
                    }                    
                    
                    // --

                    m_fSit.fPattern = value;
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
                    return m_fSit.fixedLength;
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

                    m_fSit.fixedLength = value;
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
                    return m_fSit.fFormat;
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
                    m_fSit.fFormat = value;
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

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryFormat)]
        public FSecsLengthBytes LengthBytes
        {
            get
            {
                try
                {
                    return m_fSit.lengthBytes;
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

            set
            {
                try
                {
                    m_fSit.lengthBytes = value;
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
                    return m_fSit.fScanMode;
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
                    m_fSit.fScanMode = value;
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
        [Editor(typeof(FPropAttrSitValueUITypeEditor), typeof(UITypeEditor))]
        public string OriginalValue
        {
            get
            {
                try
                {
                    return getDisplayValue(m_fSit.originalStringValue);
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
                    m_fSit.originalStringValue = value;
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
                    return getDisplayValue(m_fSit.originalEncodingValue);
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
                    return m_fSit.originalLength;
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
                    return m_fSit.randomValue;
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
                    m_fSit.randomValue = value;
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
                    return m_fSit.randomValueMin;
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
                    m_fSit.randomValueMin = value;
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
                    return m_fSit.randomValueMax;
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
                    m_fSit.randomValueMax = value;
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
                    return m_fSit.valueType.ToString();
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
                    return m_fSit.isArrayValue;
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
                    return m_fSit.isNullValue;
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
                    return getDisplayValue(m_fSit.stringValue);
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
                    return getDisplayValue(m_fSit.encodingValue);
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
                    return m_fSit.length;
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

        #region Value Transformation

        [Category(CategoryTransformation)]
        [Editor(typeof(FPropAttrSitValueTransformerUITypeEditor), typeof(UITypeEditor))]
        public string ValueTransformer
        {
            get
            {
                try
                {
                    return m_fSit.fValueTransformer.ToString();
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
        [Editor(typeof(FPropAttrSitDataConversionSetUITypeEditor), typeof(UITypeEditor))]
        public string DataConversionSet
        {
            get
            {
                try
                {
                    return m_fSit.hasDataConversionSet ? m_fSit.fDataConversionSet.name : string.Empty;
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
        [Editor(typeof(FPropAttrSitPreconditionUITypeEditor), typeof(UITypeEditor))]
        public string Precondition
        {
            get
            {
                try
                {
                    return m_fSit.fPrecondition.ToString();
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
                    return m_fSit.reservedWord;
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
                    m_fSit.reservedWord = value;
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
                    return m_fSit.extraction;
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
                    m_fSit.extraction = value;
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
                    return m_fSit.userTag1;
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
                    m_fSit.userTag1 = value;
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
                    return m_fSit.userTag2;
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
                    m_fSit.userTag2 = value;
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
                    return m_fSit.userTag3;
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
                    m_fSit.userTag3 = value;
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
                    return m_fSit.userTag4;
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
                    m_fSit.userTag4 = value;
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
                    return m_fSit.userTag5;
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
                    m_fSit.userTag5 = value;
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
        public FSecsItem fSecsItem
        {
            get
            {
                try
                {
                    return m_fSit;
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
                base.fTypeDescriptor.properties["DataConversionSet"].attributes.replace(new DisplayNameAttribute("Data Conversion Set"));
                // --
                base.fTypeDescriptor.properties["Precondition"].attributes.replace(new DisplayNameAttribute("Precondition"));
                // --
                base.fTypeDescriptor.properties["ReservedWord"].attributes.replace(new DisplayNameAttribute("Reserved Word"));
                base.fTypeDescriptor.properties["Extraction"].attributes.replace(new DisplayNameAttribute("Extraction"));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DisplayNameAttribute(m_fSit.defUserTagName1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DisplayNameAttribute(m_fSit.defUserTagName2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DisplayNameAttribute(m_fSit.defUserTagName3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DisplayNameAttribute(m_fSit.defUserTagName4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DisplayNameAttribute(m_fSit.defUserTagName5));

                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_fSit.fObjectType.ToString()));
                base.fTypeDescriptor.properties["ID"].attributes.replace(new DefaultValueAttribute(m_fSit.uniqueIdToString));
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(m_fSit.name));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_fSit.description));
                // --
                base.fTypeDescriptor.properties["FontColor"].attributes.replace(new DefaultValueAttribute(m_fSit.fontColor));
                base.fTypeDescriptor.properties["FontBold"].attributes.replace(new DefaultValueAttribute(m_fSit.fontBold));
                // --
                base.fTypeDescriptor.properties["Pattern"].attributes.replace(new DefaultValueAttribute(m_fSit.fPattern));
                base.fTypeDescriptor.properties["FixedLength"].attributes.replace(new DefaultValueAttribute(m_fSit.fixedLength));
                base.fTypeDescriptor.properties["Format"].attributes.replace(new DefaultValueAttribute(m_fSit.fFormat));
                base.fTypeDescriptor.properties["LengthBytes"].attributes.replace(new DefaultValueAttribute(m_fSit.lengthBytes));
                // --
                base.fTypeDescriptor.properties["ScanMode"].attributes.replace(new DefaultValueAttribute(m_fSit.fScanMode));
                // --                
                base.fTypeDescriptor.properties["OriginalValue"].attributes.replace(new DefaultValueAttribute(getDisplayValue(m_fSit.originalStringValue)));
                base.fTypeDescriptor.properties["OriginalEncodingValue"].attributes.replace(new DefaultValueAttribute(getDisplayValue(m_fSit.originalEncodingValue)));
                base.fTypeDescriptor.properties["OriginalLength"].attributes.replace(new DefaultValueAttribute(m_fSit.originalLength));
                // --
                base.fTypeDescriptor.properties["RandomValue"].attributes.replace(new DefaultValueAttribute(m_fSit.randomValue));
                base.fTypeDescriptor.properties["RandomValueMin"].attributes.replace(new DefaultValueAttribute(m_fSit.randomValueMin));
                base.fTypeDescriptor.properties["RandomValueMax"].attributes.replace(new DefaultValueAttribute(m_fSit.randomValueMax));
                // --
                base.fTypeDescriptor.properties["ValueType"].attributes.replace(new DefaultValueAttribute(m_fSit.valueType.ToString()));
                base.fTypeDescriptor.properties["ArrayValue"].attributes.replace(new DefaultValueAttribute(m_fSit.isArrayValue));
                base.fTypeDescriptor.properties["NullValue"].attributes.replace(new DefaultValueAttribute(m_fSit.isNullValue));
                base.fTypeDescriptor.properties["Value"].attributes.replace(new DefaultValueAttribute(getDisplayValue(m_fSit.stringValue)));
                base.fTypeDescriptor.properties["EncodingValue"].attributes.replace(new DefaultValueAttribute(getDisplayValue(m_fSit.encodingValue)));
                base.fTypeDescriptor.properties["Length"].attributes.replace(new DefaultValueAttribute(m_fSit.length));
                // --
                base.fTypeDescriptor.properties["ValueTransformer"].attributes.replace(new DefaultValueAttribute(m_fSit.fValueTransformer.ToString()));
                base.fTypeDescriptor.properties["DataConversionSet"].attributes.replace(new DefaultValueAttribute(m_fSit.hasDataConversionSet ? m_fSit.fDataConversionSet.name : string.Empty));
                // --
                base.fTypeDescriptor.properties["Precondition"].attributes.replace(new DefaultValueAttribute(m_fSit.fPrecondition.ToString()));
                // --
                base.fTypeDescriptor.properties["ReservedWord"].attributes.replace(new DefaultValueAttribute(m_fSit.reservedWord));
                base.fTypeDescriptor.properties["Extraction"].attributes.replace(new DefaultValueAttribute(m_fSit.extraction));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DefaultValueAttribute(m_fSit.userTag1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DefaultValueAttribute(m_fSit.userTag2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DefaultValueAttribute(m_fSit.userTag3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DefaultValueAttribute(m_fSit.userTag4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DefaultValueAttribute(m_fSit.userTag5));

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
                    if (m_fSit.fParent.fObjectType == FObjectType.SecsMessage)
                    {
                        base.fTypeDescriptor.properties["Pattern"].attributes.replace(new ReadOnlyAttribute(true));
                        base.fTypeDescriptor.properties["FixedLength"].attributes.replace(new ReadOnlyAttribute(true));
                        base.fTypeDescriptor.properties["FixedLength"].attributes.replace(new BrowsableAttribute(true));
                    }
                    else
                    {
                        base.fTypeDescriptor.properties["Pattern"].attributes.replace(new ReadOnlyAttribute(false));
                        base.fTypeDescriptor.properties["FixedLength"].attributes.replace(new ReadOnlyAttribute(false));
                        base.fTypeDescriptor.properties["FixedLength"].attributes.replace(new BrowsableAttribute(true));
                    }
                    base.fTypeDescriptor.properties["ScanMode"].attributes.replace(new BrowsableAttribute(true));
                }
                else if (pattern == FPattern.Variable)
                {
                    if (
                        (m_fSit.fPreviousSibling != null && m_fSit.fPreviousSibling.fPattern == FPattern.Variable) &&
                        (m_fSit.fNextSibling != null && m_fSit.fNextSibling.fPattern == FPattern.Variable)
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
                    base.fTypeDescriptor.properties["Format"].attributes.replace(new ReadOnlyAttribute(m_fSit.hasChild | m_fSit.locked));
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
                    base.fTypeDescriptor.properties["DataConversionSet"].attributes.replace(new BrowsableAttribute(false));
                    // --
                    base.fTypeDescriptor.properties["Precondition"].attributes.replace(new BrowsableAttribute(false));
                }
                else if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2)
                {
                    if (fFormat == FFormat.Ascii && m_fSit.fParent.fObjectType == FObjectType.SecsItem && ((FSecsItem)m_fSit.fParent).fFormat == FFormat.AsciiList)
                    {
                        base.fTypeDescriptor.properties["Format"].attributes.replace(new ReadOnlyAttribute(true));
                    }
                    else
                    {
                        base.fTypeDescriptor.properties["Format"].attributes.replace(new ReadOnlyAttribute(m_fSit.locked));
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
                    base.fTypeDescriptor.properties["DataConversionSet"].attributes.replace(new BrowsableAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["Precondition"].attributes.replace(new BrowsableAttribute(true));
                }
                else if (fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                {
                    base.fTypeDescriptor.properties["Format"].attributes.replace(new ReadOnlyAttribute(m_fSit.locked));
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
                    base.fTypeDescriptor.properties["DataConversionSet"].attributes.replace(new BrowsableAttribute(false));
                    // --
                    base.fTypeDescriptor.properties["Precondition"].attributes.replace(new BrowsableAttribute(false));
                }
                else
                {
                    base.fTypeDescriptor.properties["Format"].attributes.replace(new ReadOnlyAttribute(m_fSit.locked));
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
                    base.fTypeDescriptor.properties["DataConversionSet"].attributes.replace(new BrowsableAttribute(true));
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

                if (m_fSit.fFormat == FFormat.List ||
                    m_fSit.fFormat == FFormat.AsciiList ||
                    m_fSit.fFormat == FFormat.Ascii ||
                    m_fSit.fFormat == FFormat.JIS8 ||
                    m_fSit.fFormat == FFormat.A2 ||
                    m_fSit.fFormat == FFormat.Unknown ||
                    m_fSit.fFormat == FFormat.Raw ||
                    m_fSit.fFormat == FFormat.Boolean
                    )
                {
                    base.fTypeDescriptor.properties["RandomValue"].attributes.replace(new BrowsableAttribute(false));
                }
                else
                {
                    base.fTypeDescriptor.properties["RandomValue"].attributes.replace(new BrowsableAttribute(true));
                }

                // --

                if (!m_fSit.randomValue)
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
