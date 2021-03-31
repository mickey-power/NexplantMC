/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropDatl.cs
--  Creator         : spike.lee
--  Create Date     : 2011.12.08
--  Description     : FAMate SECS Modeler Data Log Property Source Object Class 
--  History         : Created by spike.lee at 2011.12.08
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager.FaSecsLogViewer
{
    public class FPropDatl : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryFont = "[02] Font";
        private const string CategorySource = "[03] Source";
        private const string CategoryTarget = "[04] Target";
        private const string CategoryFormat = "[05] Format";
        private const string CategoryScan = "[06] Scan";
        private const string CategoryValue = "[07] Value";
        private const string CategoryValueInformation = "[08] Value Information";
        private const string CategoryTransformation = "[09] Transformation";
        private const string CategoryUserTag = "[10] User Tag";

        // --

        private bool m_disposed = false;
        // --
        private FDataLog m_fDatl = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropDatl(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            FDataLog fDatl
            )
            :base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_fDatl = fDatl;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropDatl(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override void  myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    term();
                    // --
                    m_fDatl = null;
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
                    return m_fDatl.fObjectLogType.ToString();
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
                    return m_fDatl.uniqueIdToString;
                }
                catch(Exception ex)
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
                    return m_fDatl.name;
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
                    return m_fDatl.description;
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
                    return m_fDatl.fontColor;
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
                    return m_fDatl.fontBold;
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

        #region Source

        [Category(CategorySource)]
        public FDataSourceType SourceType
        {
            get
            {
                try
                {
                    return m_fDatl.fSourceType;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FDataSourceType.Constant;
            }                       
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategorySource)]
        public string SourceConstant
        {
            get
            {
                try
                {
                    return m_fDatl.sourceConstant;
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

        [Category(CategorySource)]
        public FResourceSourceType SourceResource
        {
            get
            {
                try
                {
                    return m_fDatl.sourceResource;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FResourceSourceType.None;
            }            
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategorySource)]
        public string SourceEquipmentState
        {
            get
            {
                try
                {
                    return m_fDatl.sourceEquipmentState;
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

        [Category(CategorySource)]
        public string SourceEnvironment
        {
            get
            {
                try
                {
                    return m_fDatl.sourceEnvironment;
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

        [Category(CategorySource)]
        public string SourceColumn
        {
            get
            {
                try
                {
                    return m_fDatl.sourceColumn;
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

        [Category(CategorySource)]
        public string SourceItem
        {
            get
            {
                try
                {
                    return m_fDatl.sourceItem;
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

        #region Target

        [Category(CategoryTarget)]
        public FDataTargetType TargetType
        {
            get
            {
                try
                {
                    return m_fDatl.fTargetType;
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

        [Category(CategoryTarget)]
        public string TargetConstant
        {
            get
            {
                try
                {
                    return m_fDatl.targetConstant;
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

        [Category(CategoryTarget)]
        public string TargetColumn
        {
            get
            {
                try
                {
                    return m_fDatl.targetColumn;
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

        [Category(CategoryTarget)]
        public string TargetItem
        {
            get
            {
                try
                {
                    return m_fDatl.targetItem;
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

        #region Format

        [Category(CategoryFormat)]
        public FPattern Pattern
        {
            get
            {
                try
                {
                    return m_fDatl.fPattern;
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
                    return m_fDatl.fixedLength;
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
                    return m_fDatl.fFormat;
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
                    return m_fDatl.fScanMode;
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
                    return m_fDatl.originalStringValue;
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
                    return m_fDatl.originalEncodingValue;
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
                    return m_fDatl.originalLength;
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

        #region Value Information

        [Category(CategoryValueInformation)]
        public string ValueType
        {
            get
            {
                try
                {
                    return m_fDatl.valueType.ToString();
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
                    return m_fDatl.isArrayValue;
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
                    return m_fDatl.isNullValue;
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
                    return m_fDatl.stringValue;
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
                    return m_fDatl.encodingValue;
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
                    return m_fDatl.length;
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
        [Editor(typeof(FPropAttrDatlValueTransformerUITypeEditor), typeof(UITypeEditor))]
        public string ValueTransformer
        {
            get
            {
                try
                {
                    return m_fDatl.fValueTransformer.ToString();
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
                    return m_fDatl.valueTransformerResult;
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
                    return m_fDatl.hasDataConversionSet ? m_fDatl.dataConversionSetName : string.Empty;
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
        
        #region User Tag

        [Category(CategoryUserTag)]
        public string UserTag1
        {
            get
            {
                try
                {
                    return m_fDatl.userTag1;
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
                    return m_fDatl.userTag2;
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
                    return m_fDatl.userTag3;
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
                    return m_fDatl.userTag4;
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
                    return m_fDatl.userTag5;
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
        public FDataLog fDataLog
        {
            get
            {
                try
                {
                    return m_fDatl;
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
            FDataSourceType fSourceType;
            FDataTargetType fTargetType;
            FFormat fFormat;

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
                base.fTypeDescriptor.properties["SourceType"].attributes.replace(new DisplayNameAttribute("Source Type"));
                base.fTypeDescriptor.properties["SourceConstant"].attributes.replace(new DisplayNameAttribute("Constant"));
                base.fTypeDescriptor.properties["SourceResource"].attributes.replace(new DisplayNameAttribute("Resource"));
                base.fTypeDescriptor.properties["SourceEquipmentState"].attributes.replace(new DisplayNameAttribute("EquipmentState"));
                base.fTypeDescriptor.properties["SourceEnvironment"].attributes.replace(new DisplayNameAttribute("Environment"));
                base.fTypeDescriptor.properties["SourceColumn"].attributes.replace(new DisplayNameAttribute("Column"));
                base.fTypeDescriptor.properties["SourceItem"].attributes.replace(new DisplayNameAttribute("Item"));                
                // --
                base.fTypeDescriptor.properties["TargetType"].attributes.replace(new DisplayNameAttribute("Target Type"));
                base.fTypeDescriptor.properties["TargetConstant"].attributes.replace(new DisplayNameAttribute("Constant"));
                base.fTypeDescriptor.properties["TargetColumn"].attributes.replace(new DisplayNameAttribute("Column"));
                base.fTypeDescriptor.properties["TargetItem"].attributes.replace(new DisplayNameAttribute("Item"));
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
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DisplayNameAttribute("User Tag1"));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DisplayNameAttribute("User Tag2"));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DisplayNameAttribute("User Tag3"));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DisplayNameAttribute("User Tag4"));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DisplayNameAttribute("User Tag5"));

                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_fDatl.fObjectLogType.ToString()));
                base.fTypeDescriptor.properties["ID"].attributes.replace(new DefaultValueAttribute(m_fDatl.uniqueIdToString));
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(m_fDatl.name));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_fDatl.description));
                // --
                base.fTypeDescriptor.properties["FontColor"].attributes.replace(new DefaultValueAttribute(m_fDatl.fontColor));
                base.fTypeDescriptor.properties["FontBold"].attributes.replace(new DefaultValueAttribute(m_fDatl.fontBold));
                // --
                base.fTypeDescriptor.properties["SourceType"].attributes.replace(new DefaultValueAttribute(m_fDatl.fSourceType));
                base.fTypeDescriptor.properties["SourceConstant"].attributes.replace(new DefaultValueAttribute(m_fDatl.sourceConstant));
                base.fTypeDescriptor.properties["SourceResource"].attributes.replace(new DefaultValueAttribute(m_fDatl.sourceResource));
                base.fTypeDescriptor.properties["SourceEquipmentState"].attributes.replace(new DefaultValueAttribute(m_fDatl.sourceEquipmentState));
                base.fTypeDescriptor.properties["SourceEnvironment"].attributes.replace(new DefaultValueAttribute(m_fDatl.sourceEnvironment));
                base.fTypeDescriptor.properties["SourceColumn"].attributes.replace(new DefaultValueAttribute(m_fDatl.sourceColumn));
                base.fTypeDescriptor.properties["SourceItem"].attributes.replace(new DefaultValueAttribute(m_fDatl.sourceItem));                
                // --
                base.fTypeDescriptor.properties["TargetType"].attributes.replace(new DefaultValueAttribute(m_fDatl.fTargetType));
                base.fTypeDescriptor.properties["TargetConstant"].attributes.replace(new DefaultValueAttribute(m_fDatl.targetConstant));
                base.fTypeDescriptor.properties["TargetColumn"].attributes.replace(new DefaultValueAttribute(m_fDatl.targetColumn));
                base.fTypeDescriptor.properties["TargetItem"].attributes.replace(new DefaultValueAttribute(m_fDatl.targetItem));
                // --
                base.fTypeDescriptor.properties["Pattern"].attributes.replace(new DefaultValueAttribute(m_fDatl.fPattern));
                base.fTypeDescriptor.properties["FixedLength"].attributes.replace(new DefaultValueAttribute(m_fDatl.fixedLength));
                base.fTypeDescriptor.properties["Format"].attributes.replace(new DefaultValueAttribute(m_fDatl.fFormat));
                // --
                base.fTypeDescriptor.properties["ScanMode"].attributes.replace(new DefaultValueAttribute(m_fDatl.fScanMode));
                // --
                base.fTypeDescriptor.properties["OriginalValue"].attributes.replace(new DefaultValueAttribute(m_fDatl.originalStringValue));
                base.fTypeDescriptor.properties["OriginalEncodingValue"].attributes.replace(new DefaultValueAttribute(m_fDatl.originalEncodingValue));
                base.fTypeDescriptor.properties["OriginalLength"].attributes.replace(new DefaultValueAttribute(m_fDatl.originalLength));
                // --
                base.fTypeDescriptor.properties["ValueType"].attributes.replace(new DefaultValueAttribute(m_fDatl.valueType.ToString()));
                base.fTypeDescriptor.properties["ArrayValue"].attributes.replace(new DefaultValueAttribute(m_fDatl.isArrayValue));
                base.fTypeDescriptor.properties["NullValue"].attributes.replace(new DefaultValueAttribute(m_fDatl.isNullValue));
                base.fTypeDescriptor.properties["Value"].attributes.replace(new DefaultValueAttribute(m_fDatl.stringValue));
                base.fTypeDescriptor.properties["EncodingValue"].attributes.replace(new DefaultValueAttribute(m_fDatl.encodingValue));
                base.fTypeDescriptor.properties["Length"].attributes.replace(new DefaultValueAttribute(m_fDatl.length));
                // --
                base.fTypeDescriptor.properties["ValueTransformer"].attributes.replace(new DefaultValueAttribute(m_fDatl.fValueTransformer.ToString()));
                base.fTypeDescriptor.properties["ValueTransformerResult"].attributes.replace(new DefaultValueAttribute(m_fDatl.valueTransformerResult.ToString()));
                base.fTypeDescriptor.properties["DataConversionSet"].attributes.replace(new DefaultValueAttribute(m_fDatl.hasDataConversionSet ? m_fDatl.dataConversionSetName : string.Empty));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DefaultValueAttribute(m_fDatl.userTag1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DefaultValueAttribute(m_fDatl.userTag2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DefaultValueAttribute(m_fDatl.userTag3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DefaultValueAttribute(m_fDatl.userTag4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DefaultValueAttribute(m_fDatl.userTag5));

                // --

                fSourceType = m_fDatl.fSourceType;
                // --
                if (fSourceType == FDataSourceType.Constant)
                {
                    base.fTypeDescriptor.properties["SourceConstant"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["SourceResource"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceEquipmentState"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceEnvironment"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceColumn"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceItem"].attributes.replace(new BrowsableAttribute(false));
                    // --
                    base.fTypeDescriptor.properties["Pattern"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["FixedLength"].attributes.replace(new BrowsableAttribute(false));
                }
                else if (fSourceType == FDataSourceType.Resource)
                {
                    base.fTypeDescriptor.properties["SourceConstant"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceResource"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["SourceEquipmentState"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceEnvironment"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceColumn"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceItem"].attributes.replace(new BrowsableAttribute(false));
                    // --
                    base.fTypeDescriptor.properties["Pattern"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["FixedLength"].attributes.replace(new BrowsableAttribute(false));
                }
                else if (fSourceType == FDataSourceType.EquipmentState)
                {
                    base.fTypeDescriptor.properties["SourceConstant"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceResource"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceEquipmentState"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["SourceEnvironment"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceColumn"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceItem"].attributes.replace(new BrowsableAttribute(false));
                    // --
                    base.fTypeDescriptor.properties["Pattern"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["FixedLength"].attributes.replace(new BrowsableAttribute(false));
                }
                else if (fSourceType == FDataSourceType.Environment)
                {
                    base.fTypeDescriptor.properties["SourceConstant"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceResource"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceEquipmentState"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceEnvironment"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["SourceColumn"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceItem"].attributes.replace(new BrowsableAttribute(false));
                    // --
                    base.fTypeDescriptor.properties["Pattern"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["FixedLength"].attributes.replace(new BrowsableAttribute(this.Pattern == FPattern.Fixed ? true : false));
                    // --
                    base.fTypeDescriptor.properties["ScanMode"].attributes.replace(new BrowsableAttribute(this.Pattern == FPattern.Fixed ? true : false));
                }
                else if (fSourceType == FDataSourceType.Column)
                {
                    base.fTypeDescriptor.properties["SourceConstant"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceResource"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceEquipmentState"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceEnvironment"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceColumn"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["SourceItem"].attributes.replace(new BrowsableAttribute(false));
                    // --
                    base.fTypeDescriptor.properties["Pattern"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["FixedLength"].attributes.replace(new BrowsableAttribute(this.Pattern == FPattern.Fixed ? true : false));
                    // --
                    base.fTypeDescriptor.properties["ScanMode"].attributes.replace(new BrowsableAttribute(this.Pattern == FPattern.Fixed ? true : false));
                }
                else
                {
                    base.fTypeDescriptor.properties["SourceConstant"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceResource"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceEquipmentState"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceEnvironment"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceColumn"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceItem"].attributes.replace(new BrowsableAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["Pattern"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["FixedLength"].attributes.replace(new BrowsableAttribute(this.Pattern == FPattern.Fixed ? true : false));
                    // --
                    base.fTypeDescriptor.properties["ScanMode"].attributes.replace(new BrowsableAttribute(this.Pattern == FPattern.Fixed ? true : false));
                }

                // --

                fFormat = m_fDatl.fFormat;
                // --
                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
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
                }
                else if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2 || fFormat == FFormat.Binary)
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
                }
                else if (fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
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
                }       
         
                // --

                fTargetType = m_fDatl.fTargetType;
                // --
                if (fTargetType == FDataTargetType.Constant)
                {
                    base.fTypeDescriptor.properties["TargetConstant"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["TargetColumn"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["TargetItem"].attributes.replace(new BrowsableAttribute(false));
                }
                else if (fTargetType == FDataTargetType.Column)
                {
                    base.fTypeDescriptor.properties["TargetConstant"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["TargetColumn"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["TargetItem"].attributes.replace(new BrowsableAttribute(false));
                }
                else
                {
                    base.fTypeDescriptor.properties["TargetConstant"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["TargetColumn"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["TargetItem"].attributes.replace(new BrowsableAttribute(true));
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
