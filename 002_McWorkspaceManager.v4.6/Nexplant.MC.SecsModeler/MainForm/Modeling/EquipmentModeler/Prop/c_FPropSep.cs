/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropSep.cs
--  Creator         : spike.lee
--  Create Date     : 2011.07.27
--  Description     : FAMate SECS Modeler SECS Expression Property Source Object Class 
--  History         : Created by spike.lee at 2011.07.27
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
    public class FPropSep : FDynPropCusBase<FSsmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryFont = "[02] Font";
        private const string CategoryLogical = "[03] Logical";
        private const string CategoryBehaivor = "[04] Behavior";
        private const string CategoryOperand = "[05] Operand";
        private const string CategoryOperation = "[06] Operation";
        private const string CategoryValue = "[07] Value";
        private const string CategoryTransformation = "[08] Transformation";
        private const string CategoryUserTag = "[09] User Tag";   

        // --

        private bool m_disposed = false;
        // --
        private FSecsExpression m_fSep = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropSep(
            FSsmCore fSsmCore,
            FDynPropGrid fPropGrid,
            FSecsExpression fSep
            )
            : base(fSsmCore, fSsmCore.fUIWizard, fPropGrid)
        {
            m_fSep = fSep;
            // --
            init();   
        }        

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropSep(
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
                    m_fSep = null;
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
                    return m_fSep.fObjectType.ToString();
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
                    return m_fSep.uniqueIdToString;
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
                    return m_fSep.name;
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

                    m_fSep.name = value;
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
                    return m_fSep.description;
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
                    m_fSep.description = value;
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
                    return m_fSep.fontColor;
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
                    m_fSep.fontColor = value;
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
                    return m_fSep.fontBold;
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
                    m_fSep.fontBold = value;
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

        #region Logical

        [Category(CategoryLogical)]
        public FLogical Logical
        {
            get
            {
                try
                {
                    return m_fSep.fLogical;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FLogical.And;                    
            }

            set
            {
                try
                {
                    m_fSep.fLogical = value;
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
        public FExpressionType ExpressionType
        {
            get
            {
                try
                {
                    return m_fSep.fExpressionType;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FExpressionType.Comparison;
            }

            set
            {
                try
                {
                    m_fSep.fExpressionType = value;
                    setChangedExpressionType();
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
        public FComparisonMode ComparisonMode
        {
            get
            {
                try
                {
                    return m_fSep.fComparisonMode;
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
                    m_fSep.fComparisonMode = value;
                    setChangedOperand();
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
        public FSecsOperandType OperandType
        {
            get
            {
                try
                {
                    return m_fSep.fOperandType;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FSecsOperandType.SecsItem;
            }

            set
            {
                try
                {
                    m_fSep.fOperandType = value;
                    setChangedOperand();
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
        [Editor(typeof(FPropAttrSepOperandUITypeEditor), typeof(UITypeEditor))]
        public string Operand
        {
            get
            {
                try
                {
                    return m_fSep.operandName;
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

        [Category(CategoryOperand)]
        public FFormat Format
        {
            get
            {
                try
                {
                    return m_fSep.fOperandFormat;
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

        [Category(CategoryOperand)]
        public int Index
        {
            get
            {
                try
                {
                    return m_fSep.operandIndex;
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

                    m_fSep.operandIndex = value;
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
                    return m_fSep.fOperation;
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
                    m_fSep.fOperation = value;
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
        public FExpressionValueType ExpressionValueType
        {
            get
            {
                try
                {
                    return m_fSep.fExpressionValueType;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FExpressionValueType.Value;
            }

            set
            {
                try
                {
                    m_fSep.fExpressionValueType = value;
                    // --
                    setChangedExpressionValueType();
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
        public FSecsResourceSourceType Resource
        {
            get
            {
                try
                {
                    return m_fSep.fResource;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FSecsResourceSourceType.None;
            }

            set
            {
                try
                {
                    m_fSep.fResource = value;
                    setChangedOperand();
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
        [TypeConverter(typeof(FPropAttrSepValueStringConverter))]
        public string Value
        {
            get
            {
                try
                {
                    return m_fSep.stringValue;
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
                    m_fSep.stringValue = value;
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
        public string EncodingValue
        {
            get
            {
                try
                {
                    return m_fSep.encodingValue;
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

        #region Transformation

        [Category(CategoryTransformation)]
        [Editor(typeof(FPropAttrSepValueTransformerUITypeEditor), typeof(UITypeEditor))]
        public string ValueTransformer
        {
            get
            {
                try
                {
                    return m_fSep.fValueTransformer.ToString();
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
        [Editor(typeof(FPropAttrSepDataConversionSetUITypeEditor), typeof(UITypeEditor))]
        public string DataConversionSet
        {
            get
            {
                try
                {
                    return m_fSep.hasDataConversionSet ? m_fSep.fDataConversionSet.name : string.Empty;
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
                    return m_fSep.userTag1;
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
                    m_fSep.userTag1 = value;
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
                    return m_fSep.userTag2;
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
                    m_fSep.userTag2 = value;
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
                    return m_fSep.userTag3;
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
                    m_fSep.userTag3 = value;
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
                    return m_fSep.userTag4;
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
                    m_fSep.userTag4 = value;
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
                    return m_fSep.userTag5;
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
                    m_fSep.userTag5 = value;
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
        public FSecsExpression fSecsExpression
        {
            get
            {
                try
                {
                    return m_fSep;
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
                base.fTypeDescriptor.properties["Logical"].attributes.replace(new DisplayNameAttribute("Logical"));
                // --
                base.fTypeDescriptor.properties["ExpressionType"].attributes.replace(new DisplayNameAttribute("Expression Type"));
                base.fTypeDescriptor.properties["ComparisonMode"].attributes.replace(new DisplayNameAttribute("Comparison Mode"));
                // --
                base.fTypeDescriptor.properties["OperandType"].attributes.replace(new DisplayNameAttribute("Operand Type"));
                base.fTypeDescriptor.properties["Operand"].attributes.replace(new DisplayNameAttribute("Operand"));
                base.fTypeDescriptor.properties["Format"].attributes.replace(new DisplayNameAttribute("Format"));
                base.fTypeDescriptor.properties["Index"].attributes.replace(new DisplayNameAttribute("Index"));
                // --
                base.fTypeDescriptor.properties["Operation"].attributes.replace(new DisplayNameAttribute("Operation"));
                // --
                base.fTypeDescriptor.properties["ExpressionValueType"].attributes.replace(new DisplayNameAttribute("Expression Value Type"));
                base.fTypeDescriptor.properties["Resource"].attributes.replace(new DisplayNameAttribute("Resource"));
                base.fTypeDescriptor.properties["Value"].attributes.replace(new DisplayNameAttribute("Value"));
                base.fTypeDescriptor.properties["EncodingValue"].attributes.replace(new DisplayNameAttribute("Encoding Value"));
                // --
                base.fTypeDescriptor.properties["ValueTransformer"].attributes.replace(new DisplayNameAttribute("Value Transformer"));
                base.fTypeDescriptor.properties["DataConversionSet"].attributes.replace(new DisplayNameAttribute("Data Conversion Set"));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DisplayNameAttribute(m_fSep.defUserTagName1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DisplayNameAttribute(m_fSep.defUserTagName2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DisplayNameAttribute(m_fSep.defUserTagName3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DisplayNameAttribute(m_fSep.defUserTagName4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DisplayNameAttribute(m_fSep.defUserTagName5));

                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_fSep.fObjectType.ToString()));
                base.fTypeDescriptor.properties["ID"].attributes.replace(new DefaultValueAttribute(m_fSep.uniqueIdToString));
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(m_fSep.name));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_fSep.description));
                // --
                base.fTypeDescriptor.properties["FontColor"].attributes.replace(new DefaultValueAttribute(m_fSep.fontColor));
                base.fTypeDescriptor.properties["FontBold"].attributes.replace(new DefaultValueAttribute(m_fSep.fontBold));
                // --
                base.fTypeDescriptor.properties["Logical"].attributes.replace(new DefaultValueAttribute(m_fSep.fLogical));
                // --
                base.fTypeDescriptor.properties["ExpressionType"].attributes.replace(new DefaultValueAttribute(m_fSep.fExpressionType));
                base.fTypeDescriptor.properties["ComparisonMode"].attributes.replace(new DefaultValueAttribute(m_fSep.fComparisonMode));
                // --
                base.fTypeDescriptor.properties["OperandType"].attributes.replace(new DefaultValueAttribute(m_fSep.fOperandType));
                base.fTypeDescriptor.properties["Operand"].attributes.replace(new DefaultValueAttribute(m_fSep.operandName));
                base.fTypeDescriptor.properties["Format"].attributes.replace(new DefaultValueAttribute(m_fSep.fOperandFormat));
                base.fTypeDescriptor.properties["Index"].attributes.replace(new DefaultValueAttribute(m_fSep.operandIndex));
                // --
                base.fTypeDescriptor.properties["Operation"].attributes.replace(new DefaultValueAttribute(m_fSep.fOperation));
                // --
                base.fTypeDescriptor.properties["ExpressionValueType"].attributes.replace(new DefaultValueAttribute(m_fSep.fExpressionValueType));
                base.fTypeDescriptor.properties["Resource"].attributes.replace(new DefaultValueAttribute(m_fSep.fResource));                
                base.fTypeDescriptor.properties["Value"].attributes.replace(new DefaultValueAttribute(m_fSep.stringValue));
                base.fTypeDescriptor.properties["EncodingValue"].attributes.replace(new DefaultValueAttribute(m_fSep.encodingValue));
                // --
                base.fTypeDescriptor.properties["ValueTransformer"].attributes.replace(new DefaultValueAttribute(m_fSep.fValueTransformer.ToString()));
                base.fTypeDescriptor.properties["DataConversionSet"].attributes.replace(new DefaultValueAttribute(m_fSep.hasDataConversionSet ? m_fSep.fDataConversionSet.name : string.Empty));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DefaultValueAttribute(m_fSep.userTag1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DefaultValueAttribute(m_fSep.userTag2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DefaultValueAttribute(m_fSep.userTag3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DefaultValueAttribute(m_fSep.userTag4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DefaultValueAttribute(m_fSep.userTag5));

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
                if (m_fSep.fPreviousSibling == null)
                {
                    base.fTypeDescriptor.properties["Logical"].attributes.replace(new BrowsableAttribute(false));
                }
                else
                {
                    base.fTypeDescriptor.properties["Logical"].attributes.replace(new BrowsableAttribute(true));
                }

                // --

                if (m_fSep.hasChild)
                {
                    base.fTypeDescriptor.properties["ExpressionType"].attributes.replace(new ReadOnlyAttribute(true));
                }
                else
                {
                    base.fTypeDescriptor.properties["ExpressionType"].attributes.replace(new ReadOnlyAttribute(false));
                }

                // --

                setChangedExpressionType();       
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

        private void setChangedExpressionType(
            )
        {
            try
            {
                if (m_fSep.fExpressionType == FExpressionType.Comparison)
                {
                    base.fTypeDescriptor.properties["ComparisonMode"].attributes.replace(new BrowsableAttribute(true));
                }
                else
                {
                    base.fTypeDescriptor.properties["ComparisonMode"].attributes.replace(new BrowsableAttribute(false));
                }

                // --

                setChangedOperand();
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

        public void setChangedOperand(
            )
        {
            FFormat fFormat;

            try
            {
                if (m_fSep.fExpressionType == FExpressionType.Comparison)
                {
                    if (m_fSep.fOperandType == FSecsOperandType.SecsItem || m_fSep.fOperandType == FSecsOperandType.Environment)
                    {
                        fFormat = m_fSep.fOperandFormat;

                        // --
                        
                        base.fTypeDescriptor.properties["OperandType"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["Operand"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["Format"].attributes.replace(new BrowsableAttribute(true));
                        // --
                        base.fTypeDescriptor.properties["Operation"].attributes.replace(new BrowsableAttribute(true));
                        
                        // --

                        if (
                            m_fSep.fComparisonMode == FComparisonMode.Length ||
                            fFormat == FFormat.List ||
                            fFormat == FFormat.AsciiList ||
                            fFormat == FFormat.Raw ||
                            fFormat == FFormat.Unknown ||
                            fFormat == FFormat.Ascii ||
                            fFormat == FFormat.A2 ||
                            fFormat == FFormat.JIS8
                            )
                        {
                            base.fTypeDescriptor.properties["Index"].attributes.replace(new BrowsableAttribute(false));
                        }
                        else
                        {
                            base.fTypeDescriptor.properties["Index"].attributes.replace(new BrowsableAttribute(true));
                        }

                        // --

                        if (m_fSep.hasOperand)
                        {
                            if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Raw || fFormat == FFormat.Unknown)
                            {
                                base.fTypeDescriptor.properties["ValueTransformer"].attributes.replace(new BrowsableAttribute(false));
                                base.fTypeDescriptor.properties["DataConversionSet"].attributes.replace(new BrowsableAttribute(false));
                            }
                            else
                            {
                                base.fTypeDescriptor.properties["ValueTransformer"].attributes.replace(new BrowsableAttribute(true));
                                base.fTypeDescriptor.properties["DataConversionSet"].attributes.replace(new BrowsableAttribute(true));
                            }
                        }
                        else
                        {
                            base.fTypeDescriptor.properties["ValueTransformer"].attributes.replace(new BrowsableAttribute(false));
                            base.fTypeDescriptor.properties["DataConversionSet"].attributes.replace(new BrowsableAttribute(false));
                        }
                    }
                    else
                    {
                        base.fTypeDescriptor.properties["OperandType"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["Operand"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["Format"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["Index"].attributes.replace(new BrowsableAttribute(false));
                        // --
                        base.fTypeDescriptor.properties["Operation"].attributes.replace(new BrowsableAttribute(true));
                        // --
                        base.fTypeDescriptor.properties["ValueTransformer"].attributes.replace(new BrowsableAttribute(false));
                        base.fTypeDescriptor.properties["DataConversionSet"].attributes.replace(new BrowsableAttribute(false));
                    }
                }
                else
                {
                    base.fTypeDescriptor.properties["OperandType"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["Operand"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["Format"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["Index"].attributes.replace(new BrowsableAttribute(false));
                    // --
                    base.fTypeDescriptor.properties["Operation"].attributes.replace(new BrowsableAttribute(false));
                    // --
                    base.fTypeDescriptor.properties["ValueTransformer"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["DataConversionSet"].attributes.replace(new BrowsableAttribute(false));
                }

                // --

                setChangedExpressionValueType();
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

        private void setChangedExpressionValueType(
            )
        {
            FFormat fFormat;

            try
            {
                if (m_fSep.fExpressionType == FExpressionType.Comparison)
                {
                    if (
                        m_fSep.fComparisonMode == FComparisonMode.Length ||
                        m_fSep.fOperandType == FSecsOperandType.EquipmentState
                        )
                    {
                        base.fTypeDescriptor.properties["ExpressionValueType"].attributes.replace(new BrowsableAttribute(false));
                        base.fTypeDescriptor.properties["Resource"].attributes.replace(new BrowsableAttribute(false));
                        base.fTypeDescriptor.properties["Value"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["EncodingValue"].attributes.replace(new BrowsableAttribute(false));
                    }
                    else
                    {
                        if (m_fSep.fExpressionValueType == FExpressionValueType.Value)
                        {
                            fFormat = m_fSep.fOperandFormat;

                            // --

                            base.fTypeDescriptor.properties["ExpressionValueType"].attributes.replace(new BrowsableAttribute(true));
                            base.fTypeDescriptor.properties["Resource"].attributes.replace(new BrowsableAttribute(false));
                            base.fTypeDescriptor.properties["Value"].attributes.replace(new BrowsableAttribute(true));

                            // --

                            if (fFormat == FFormat.Ascii || fFormat == FFormat.A2 || fFormat == FFormat.JIS8 || fFormat == FFormat.Binary)
                            {
                                base.fTypeDescriptor.properties["EncodingValue"].attributes.replace(new BrowsableAttribute(true));
                            }
                            else
                            {
                                base.fTypeDescriptor.properties["EncodingValue"].attributes.replace(new BrowsableAttribute(false));
                            }
                        }
                        else
                        {
                            base.fTypeDescriptor.properties["ExpressionValueType"].attributes.replace(new BrowsableAttribute(true));
                            base.fTypeDescriptor.properties["Resource"].attributes.replace(new BrowsableAttribute(true));
                            base.fTypeDescriptor.properties["Value"].attributes.replace(new BrowsableAttribute(false));
                            base.fTypeDescriptor.properties["EncodingValue"].attributes.replace(new BrowsableAttribute(false));
                        }
                    }
                }
                else
                {
                    base.fTypeDescriptor.properties["ExpressionValueType"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["Resource"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["Value"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["EncodingValue"].attributes.replace(new BrowsableAttribute(false));
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
