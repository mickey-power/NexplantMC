/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropDcv.cs
--  Creator         : spike.lee
--  Create Date     : 2012.03.07
--  Description     : FAMate SECS Modeler Data Conversion Property Source Object Class 
--  History         : Created by spike.lee at 2012.03.07
 *                    Modified by jeff.kim at 2013.06.04 
 *                    Modified by byjeon at 2014.01.24
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.SecsModeler
{
    public class FPropDcv : FDynPropCusBase<FSsmCore>
    {
        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryFont = "[02] Font";
        private const string CategoryOperand = "[03] Operand";
        private const string CategoryBehaivor = "[04] Behavior";        
        private const string CategoryOperation = "[05] Operation";
        private const string CategoryValue = "[06] Value";
        private const string CategoryTransformation = "[07] Transformation";
        private const string CategoryUserTag = "[08] User Tag";

        // --

        private bool m_disposed = false;
        // --
        private FDataConversion m_fDcv = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropDcv(
            FSsmCore fSsmCore,
            FDynPropGrid fPropGrid,
            FDataConversion fDcv
            )
            : base(fSsmCore, fSsmCore.fUIWizard, fPropGrid)
        {
            m_fDcv = fDcv;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropDcv(
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
                    m_fDcv = null;
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
                    return m_fDcv.fObjectType.ToString();
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
                    return m_fDcv.uniqueIdToString;
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
                    return m_fDcv.name;
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

                    m_fDcv.name = value;
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
                    return m_fDcv.description;
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
                    m_fDcv.description = value;
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
                    return m_fDcv.fontColor;
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
                    m_fDcv.fontColor = value;
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
                    return m_fDcv.fontBold;
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
                    m_fDcv.fontBold = value;
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

        #region Operand

        [Category(CategoryOperand)]
        public FFormat Format
        {
            get
            {
                try
                {
                    return m_fDcv.fFormat;
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
                    m_fDcv.fFormat = value;
                    // --
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

        [Category(CategoryOperand)]
        public int Index
        {
            get
            {
                try
                {
                    return m_fDcv.operandIndex;
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
                    if (value < 0)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Operand Index" }));
                    }

                    // --

                    m_fDcv.operandIndex = value;
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

        #region Behavior

        [Category(CategoryBehaivor)]
        public FComparisonMode ComparisonMode
        {
            get
            {
                try
                {
                    return  m_fDcv.fComparisonMode;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FComparisonMode.Value;
            }

            set
            {
                try
                {
                    m_fDcv.fComparisonMode = value;
                    // --
                    setChangedComparison();
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

        [Category(CategoryBehaivor)]
        public FConversionMode ConversionMode
        {
            get
            {
                try
                {
                    return m_fDcv.fConversionMode;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FConversionMode.Value;
            }

            set
            {
                try
                {
                    m_fDcv.fConversionMode = value;
                    // --
                    setChangedConversion();
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

        #region Operation

        [Category(CategoryOperation)]
        public FOperation Operation
        {
            get
            {
                try
                {
                    return m_fDcv.fOperation;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FOperation.Equal;
            }

            set
            {
                try
                {
                    m_fDcv.fOperation = value;
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
        public string Value
        {
            get
            {
                try
                {
                    return m_fDcv.stringValue;
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
                    m_fDcv.stringValue = value;
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
        public string Min
        {
            get
            {
                try
                {
                    return m_fDcv.min;
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
                    m_fDcv.min = value;
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
        public string Max
        {
            get
            {
                try
                {
                    return m_fDcv.max;
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
                    m_fDcv.max = value;
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
        public string ConversionValue
        {
            get
            {
                try
                {
                    return m_fDcv.conversionValue;
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
                    m_fDcv.conversionValue = value;
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

        #region Transformation

        [Category(CategoryTransformation)]
        [Editor(typeof(FPropAttrDcvValueTransformerUITypeEditor), typeof(UITypeEditor))]
        public string ValueTransformer
        {
            get
            {
                try
                {
                    return m_fDcv.fValueTransformer.ToString();
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
                    return m_fDcv.userTag1;
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
                    m_fDcv.userTag1 = value;
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
                    return m_fDcv.userTag2;
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
                    m_fDcv.userTag2 = value;
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
                    return m_fDcv.userTag3;
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
                    m_fDcv.userTag3 = value;
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
                    return m_fDcv.userTag4;
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
                    m_fDcv.userTag4 = value;
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
                    return m_fDcv.userTag5;
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
                    m_fDcv.userTag5 = value;
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
        public FDataConversion fDataConversion
        {
            get
            {
                try
                {
                    return m_fDcv;
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
                base.fTypeDescriptor.properties["Format"].attributes.replace(new DisplayNameAttribute("Format"));
                base.fTypeDescriptor.properties["Index"].attributes.replace(new DisplayNameAttribute("Index"));
                // --
                base.fTypeDescriptor.properties["ComparisonMode"].attributes.replace(new DisplayNameAttribute("Comparison Mode"));
                base.fTypeDescriptor.properties["ConversionMode"].attributes.replace(new DisplayNameAttribute("Conversion Mode"));
                // --
                base.fTypeDescriptor.properties["Operation"].attributes.replace(new DisplayNameAttribute("Operation"));
                // --
                base.fTypeDescriptor.properties["Value"].attributes.replace(new DisplayNameAttribute("Value"));
                base.fTypeDescriptor.properties["Min"].attributes.replace(new DisplayNameAttribute("Min"));
                base.fTypeDescriptor.properties["Max"].attributes.replace(new DisplayNameAttribute("Max"));
                base.fTypeDescriptor.properties["ConversionValue"].attributes.replace(new DisplayNameAttribute("Conversion Value"));
                // --
                base.fTypeDescriptor.properties["ValueTransformer"].attributes.replace(new DisplayNameAttribute("Value Transformer"));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DisplayNameAttribute(m_fDcv.defUserTagName1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DisplayNameAttribute(m_fDcv.defUserTagName2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DisplayNameAttribute(m_fDcv.defUserTagName3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DisplayNameAttribute(m_fDcv.defUserTagName4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DisplayNameAttribute(m_fDcv.defUserTagName5));

                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_fDcv.fObjectType.ToString()));
                base.fTypeDescriptor.properties["ID"].attributes.replace(new DefaultValueAttribute(m_fDcv.uniqueIdToString));
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(m_fDcv.name));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_fDcv.description));
                // --
                base.fTypeDescriptor.properties["FontColor"].attributes.replace(new DefaultValueAttribute(m_fDcv.fontColor));
                base.fTypeDescriptor.properties["FontBold"].attributes.replace(new DefaultValueAttribute(m_fDcv.fontBold));
                // --
                base.fTypeDescriptor.properties["ComparisonMode"].attributes.replace(new DefaultValueAttribute(m_fDcv.fComparisonMode));
                base.fTypeDescriptor.properties["ConversionMode"].attributes.replace(new DefaultValueAttribute(m_fDcv.fConversionMode));
                // --
                base.fTypeDescriptor.properties["Format"].attributes.replace(new DefaultValueAttribute(m_fDcv.fFormat));
                base.fTypeDescriptor.properties["Index"].attributes.replace(new DefaultValueAttribute(m_fDcv.operandIndex));
                // --
                base.fTypeDescriptor.properties["Operation"].attributes.replace(new DefaultValueAttribute(m_fDcv.fOperation));
                // --
                base.fTypeDescriptor.properties["Value"].attributes.replace(new DefaultValueAttribute(m_fDcv.stringValue));
                base.fTypeDescriptor.properties["Min"].attributes.replace(new DefaultValueAttribute(m_fDcv.min));
                base.fTypeDescriptor.properties["Max"].attributes.replace(new DefaultValueAttribute(m_fDcv.max));
                base.fTypeDescriptor.properties["ConversionValue"].attributes.replace(new DefaultValueAttribute(m_fDcv.conversionValue));
                // --
                base.fTypeDescriptor.properties["ValueTransformer"].attributes.replace(new DefaultValueAttribute(m_fDcv.fValueTransformer.ToString()));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DefaultValueAttribute(m_fDcv.userTag1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DefaultValueAttribute(m_fDcv.userTag2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DefaultValueAttribute(m_fDcv.userTag3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DefaultValueAttribute(m_fDcv.userTag4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DefaultValueAttribute(m_fDcv.userTag5));

                // --

                setChangedFormat();
                setChangedComparison();
                setChangedConversion();

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
            try
            {
                // ***
                // Common
                // ***
                base.fTypeDescriptor.properties["Min"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["Max"].attributes.replace(new BrowsableAttribute(false));

                // --

                if(
                    m_fDcv.fFormat == FFormat.Ascii ||
                    m_fDcv.fFormat == FFormat.A2 ||
                    m_fDcv.fFormat == FFormat.JIS8
                    )
                {
                    base.fTypeDescriptor.properties["ComparisonMode"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["ConversionMode"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["ValueTransformer"].attributes.replace(new BrowsableAttribute(true));
                }
                else if(
                    m_fDcv.fFormat == FFormat.U1 ||
                    m_fDcv.fFormat == FFormat.U2 ||
                    m_fDcv.fFormat == FFormat.U4 ||
                    m_fDcv.fFormat == FFormat.U8 ||
                    m_fDcv.fFormat == FFormat.I1 ||
                    m_fDcv.fFormat == FFormat.I2 ||
                    m_fDcv.fFormat == FFormat.I4 ||
                    m_fDcv.fFormat == FFormat.I8 ||
                    m_fDcv.fFormat == FFormat.F4 ||
                    m_fDcv.fFormat == FFormat.F8 ||
                    m_fDcv.fFormat == FFormat.Binary
                    )
                {
                    base.fTypeDescriptor.properties["ComparisonMode"].attributes.replace(new ReadOnlyAttribute(false));
                    base.fTypeDescriptor.properties["ConversionMode"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["ConversionMode"].attributes.replace(new ReadOnlyAttribute(false));
                    base.fTypeDescriptor.properties["ValueTransformer"].attributes.replace(new BrowsableAttribute(true));
                }
                else if (
                    m_fDcv.fFormat == FFormat.List ||
                    m_fDcv.fFormat == FFormat.AsciiList ||
                    m_fDcv.fFormat == FFormat.Unknown ||
                    m_fDcv.fFormat == FFormat.Raw
                    )
                {
                    base.fTypeDescriptor.properties["ComparisonMode"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["ConversionMode"].attributes.replace(new BrowsableAttribute(false));                                        
                    base.fTypeDescriptor.properties["ValueTransformer"].attributes.replace(new BrowsableAttribute(false));
                }
                else if (
                    m_fDcv.fFormat == FFormat.Boolean
                    )
                {
                    base.fTypeDescriptor.properties["ComparisonMode"].attributes.replace(new ReadOnlyAttribute(false));
                    base.fTypeDescriptor.properties["ConversionMode"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["ValueTransformer"].attributes.replace(new BrowsableAttribute(true));
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

        private void setChangedComparison(
            )
        {
            try
            {
                if (m_fDcv.fComparisonMode == FComparisonMode.Value)
                {
                    if (
                        m_fDcv.fFormat == FFormat.Ascii ||
                        m_fDcv.fFormat == FFormat.A2 ||
                        m_fDcv.fFormat == FFormat.JIS8
                        )
                    {
                        base.fTypeDescriptor.properties["Index"].attributes.replace(new BrowsableAttribute(false));
                        base.fTypeDescriptor.properties["ConversionMode"].attributes.replace(new ReadOnlyAttribute(true));
                    }
                    else if (
                        m_fDcv.fFormat == FFormat.List ||
                        m_fDcv.fFormat == FFormat.AsciiList ||
                        m_fDcv.fFormat == FFormat.Unknown ||
                        m_fDcv.fFormat == FFormat.Raw
                        )
                    {
                        base.fTypeDescriptor.properties["Index"].attributes.replace(new BrowsableAttribute(false));
                        base.fTypeDescriptor.properties["ConversionMode"].attributes.replace(new ReadOnlyAttribute(false));
                    }
                    else if (m_fDcv.fFormat == FFormat.Boolean)
                    {
                        base.fTypeDescriptor.properties["Index"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["ConversionMode"].attributes.replace(new ReadOnlyAttribute(true));
                    }
                    else
                    {
                        base.fTypeDescriptor.properties["Index"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["ConversionMode"].attributes.replace(new ReadOnlyAttribute(false));
                    }
                }
                else if (m_fDcv.fComparisonMode == FComparisonMode.Length)
                {
                    base.fTypeDescriptor.properties["Index"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["ConversionMode"].attributes.replace(new ReadOnlyAttribute(true));
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

        private void setChangedConversion(
            )
        {
            try
            {
                if (m_fDcv.fConversionMode == FConversionMode.Value)
                {
                    base.fTypeDescriptor.properties["Min"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["Max"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["Value"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["Operation"].attributes.replace(new BrowsableAttribute(true));
                }
                else if (m_fDcv.fConversionMode == FConversionMode.Range)
                {
                    base.fTypeDescriptor.properties["Min"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["Max"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["Value"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["Operation"].attributes.replace(new BrowsableAttribute(false));
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


