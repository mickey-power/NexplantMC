/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropJep.cs
--  Creator         : spike.lee
--  Create Date     : 2012.01.20
--  Description     : FAMate OPC Modeler Judgement Expression Property Source Object Class 
--  History         : Created by spike.lee at 2012.01.20
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
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.OpcModeler
{
    public class FPropJep : FDynPropCusBase<FOpmCore>
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
        private FJudgementExpression m_fJep = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropJep(
            FOpmCore fOpmCore,
            FDynPropGrid fPropGrid,
            FJudgementExpression fJep
            )
            : base(fOpmCore, fOpmCore.fUIWizard, fPropGrid)
        {
            m_fJep = fJep;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropJep(
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
                    m_fJep = null;
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
                    return m_fJep.fObjectType.ToString();
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
                    return m_fJep.uniqueIdToString;
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
                    return m_fJep.name;
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

                    m_fJep.name = value;
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
                    return m_fJep.description;
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
                    m_fJep.description = value;
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
                    return m_fJep.fontColor;
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
                    m_fJep.fontColor = value;
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
                    return m_fJep.fontBold;
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
                    m_fJep.fontBold = value;
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
                    return m_fJep.fLogical;
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
                    m_fJep.fLogical = value;
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
                    return m_fJep.fExpressionType;
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
                    m_fJep.fExpressionType = value;
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
                    return m_fJep.fComparisonMode;
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
                    m_fJep.fComparisonMode = value;
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
        [Editor(typeof(FPropAttrJepOperandUITypeEditor), typeof(UITypeEditor))]
        public string Operand
        {
            get
            {
                try
                {
                    return m_fJep.operandName;
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
                    return m_fJep.fOperandFormat;
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
        public FOperandIndexType IndexType
        {
            get
            {
                try
                {
                    return m_fJep.fOperandIndexType;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FOperandIndexType.All;
            }

            set
            {
                try
                {
                    m_fJep.fOperandIndexType = value;
                    setChangedIndexType();
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
        public FOperandIndexOption IndexOption
        {
            get
            {
                try
                {
                    return m_fJep.fOperandIndexOption;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FOperandIndexOption.And;
            }

            set
            {
                try
                {
                    m_fJep.fOperandIndexOption = value;
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
                    return m_fJep.operandIndex;
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

                    m_fJep.operandIndex = value;
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
                    return m_fJep.fOperation;
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
                    m_fJep.fOperation = value;
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
        public FOperandValueType ValueType
        {
            get
            {
                try
                {
                    return m_fJep.fOperandValueType;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FOperandValueType.Value;
            }

            set
            {
                try
                {
                    m_fJep.fOperandValueType = value;
                    setChangedValueTypeOrValueIndexType();
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
        public FOperandIndexType ValueIndexType
        {
            get
            {
                try
                {
                    return m_fJep.fOperandValueIndexType;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FOperandIndexType.All;
            }

            set
            {
                try
                {
                    m_fJep.fOperandValueIndexType = value;
                    setChangedValueTypeOrValueIndexType();
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

        [Category(CategoryValue)]
        public FOperandIndexOption ValueIndexOption
        {
            get
            {
                try
                {
                    return m_fJep.fOperandValueIndexOption;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FOperandIndexOption.And;
            }

            set
            {
                try
                {
                    m_fJep.fOperandValueIndexOption = value;
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
        public int ValueIndex
        {
            get
            {
                try
                {
                    return m_fJep.operandValueIndex;
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

            set
            {
                try
                {
                    m_fJep.operandValueIndex = value;
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

        [Category(CategoryValue)]
        public string Value
        {
            get
            {
                try
                {
                    return m_fJep.stringValue;
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
                    m_fJep.stringValue = value;
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
                    return m_fJep.encodingValue;
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
        [Editor(typeof(FPropAttrJepOperandValueUITypeEditor), typeof(UITypeEditor))]
        public string OperandValue
        {
            get
            {
                try
                {
                    return m_fJep.operandValueName;
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
        [Editor(typeof(FPropAttrJepValueTransformerUITypeEditor), typeof(UITypeEditor))]
        public string ValueTransformer
        {
            get
            {
                try
                {
                    return m_fJep.fValueTransformer.ToString();
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
        [Editor(typeof(FPropAttrJepDataConversionSetUITypeEditor), typeof(UITypeEditor))]
        public string DataConversionSet
        {
            get
            {
                try
                {
                    return m_fJep.hasDataConversionSet ? m_fJep.fDataConversionSet.name : string.Empty;
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
                    return m_fJep.userTag1;
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
                    m_fJep.userTag1 = value;
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
                    return m_fJep.userTag2;
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
                    m_fJep.userTag2 = value;
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
                    return m_fJep.userTag3;
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
                    m_fJep.userTag3 = value;
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
                    return m_fJep.userTag4;
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
                    m_fJep.userTag4 = value;
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
                    return m_fJep.userTag5;
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
                    m_fJep.userTag5 = value;
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
        public FJudgementExpression fJudgementExpression
        {
            get
            {
                try
                {
                    return m_fJep;
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
                base.fTypeDescriptor.properties["Operand"].attributes.replace(new DisplayNameAttribute("Operand"));
                base.fTypeDescriptor.properties["Format"].attributes.replace(new DisplayNameAttribute("Format"));
                base.fTypeDescriptor.properties["IndexType"].attributes.replace(new DisplayNameAttribute("Index Type"));
                base.fTypeDescriptor.properties["IndexOption"].attributes.replace(new DisplayNameAttribute("Index Option"));
                base.fTypeDescriptor.properties["Index"].attributes.replace(new DisplayNameAttribute("Index"));
                // --
                base.fTypeDescriptor.properties["Operation"].attributes.replace(new DisplayNameAttribute("Operation"));
                // --
                base.fTypeDescriptor.properties["ValueType"].attributes.replace(new DisplayNameAttribute("Value Type"));
                base.fTypeDescriptor.properties["ValueIndexType"].attributes.replace(new DisplayNameAttribute("Index Type "));
                base.fTypeDescriptor.properties["ValueIndexOption"].attributes.replace(new DisplayNameAttribute("Index Option "));
                base.fTypeDescriptor.properties["ValueIndex"].attributes.replace(new DisplayNameAttribute("Index "));
                base.fTypeDescriptor.properties["Value"].attributes.replace(new DisplayNameAttribute("Value"));
                base.fTypeDescriptor.properties["EncodingValue"].attributes.replace(new DisplayNameAttribute("Encoding Value"));
                base.fTypeDescriptor.properties["OperandValue"].attributes.replace(new DisplayNameAttribute("Value"));
                // --
                base.fTypeDescriptor.properties["ValueTransformer"].attributes.replace(new DisplayNameAttribute("Value Transformer"));
                base.fTypeDescriptor.properties["DataConversionSet"].attributes.replace(new DisplayNameAttribute("Data Conversion Set"));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DisplayNameAttribute(m_fJep.defUserTagName1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DisplayNameAttribute(m_fJep.defUserTagName2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DisplayNameAttribute(m_fJep.defUserTagName3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DisplayNameAttribute(m_fJep.defUserTagName4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DisplayNameAttribute(m_fJep.defUserTagName5));

                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_fJep.fObjectType.ToString()));
                base.fTypeDescriptor.properties["ID"].attributes.replace(new DefaultValueAttribute(m_fJep.uniqueIdToString));
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(m_fJep.name));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_fJep.description));
                // --
                base.fTypeDescriptor.properties["FontColor"].attributes.replace(new DefaultValueAttribute(m_fJep.fontColor));
                base.fTypeDescriptor.properties["FontBold"].attributes.replace(new DefaultValueAttribute(m_fJep.fontBold));
                // --
                base.fTypeDescriptor.properties["Logical"].attributes.replace(new DefaultValueAttribute(m_fJep.fLogical));
                // --
                base.fTypeDescriptor.properties["ExpressionType"].attributes.replace(new DefaultValueAttribute(m_fJep.fExpressionType));
                base.fTypeDescriptor.properties["ComparisonMode"].attributes.replace(new DefaultValueAttribute(m_fJep.fComparisonMode));
                // --
                base.fTypeDescriptor.properties["Operand"].attributes.replace(new DefaultValueAttribute(m_fJep.operandName));
                base.fTypeDescriptor.properties["Format"].attributes.replace(new DefaultValueAttribute(m_fJep.fOperandFormat));
                base.fTypeDescriptor.properties["IndexType"].attributes.replace(new DefaultValueAttribute(m_fJep.fOperandIndexType));
                base.fTypeDescriptor.properties["IndexOption"].attributes.replace(new DefaultValueAttribute(m_fJep.fOperandIndexOption));
                base.fTypeDescriptor.properties["Index"].attributes.replace(new DefaultValueAttribute(m_fJep.operandIndex));
                // --
                base.fTypeDescriptor.properties["Operation"].attributes.replace(new DefaultValueAttribute(m_fJep.fOperation));
                // --
                base.fTypeDescriptor.properties["ValueType"].attributes.replace(new DefaultValueAttribute(m_fJep.fOperandValueType));
                base.fTypeDescriptor.properties["ValueIndexType"].attributes.replace(new DefaultValueAttribute(m_fJep.fOperandValueIndexType));
                base.fTypeDescriptor.properties["ValueIndexOption"].attributes.replace(new DefaultValueAttribute(m_fJep.fOperandValueIndexOption));
                base.fTypeDescriptor.properties["ValueIndex"].attributes.replace(new DefaultValueAttribute(m_fJep.operandValueIndex));
                base.fTypeDescriptor.properties["Value"].attributes.replace(new DefaultValueAttribute(m_fJep.stringValue));
                base.fTypeDescriptor.properties["EncodingValue"].attributes.replace(new DefaultValueAttribute(m_fJep.encodingValue));
                base.fTypeDescriptor.properties["OperandValue"].attributes.replace(new DefaultValueAttribute(m_fJep.operandValueName));
                // --
                base.fTypeDescriptor.properties["ValueTransformer"].attributes.replace(new DefaultValueAttribute(m_fJep.fValueTransformer.ToString()));
                base.fTypeDescriptor.properties["DataConversionSet"].attributes.replace(new DefaultValueAttribute(m_fJep.hasDataConversionSet ? m_fJep.fDataConversionSet.name : string.Empty));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DefaultValueAttribute(m_fJep.userTag1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DefaultValueAttribute(m_fJep.userTag2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DefaultValueAttribute(m_fJep.userTag3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DefaultValueAttribute(m_fJep.userTag4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DefaultValueAttribute(m_fJep.userTag5));

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
                if (m_fJep.fPreviousSibling == null)
                {
                    base.fTypeDescriptor.properties["Logical"].attributes.replace(new BrowsableAttribute(false));
                }
                else
                {
                    base.fTypeDescriptor.properties["Logical"].attributes.replace(new BrowsableAttribute(true));
                }

                // --

                if (m_fJep.hasChild)
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

        private void setChangedExpressionType2(
            )
        {
            bool browsable = false;

            try
            {
                if (m_fJep.fExpressionType == FExpressionType.Bracket)
                {
                    browsable = false;
                }
                else
                {
                    browsable = true;
                }

                // --

                base.fTypeDescriptor.properties["ComparisonMode"].attributes.replace(new BrowsableAttribute(browsable));
                // --
                base.fTypeDescriptor.properties["OperandType"].attributes.replace(new BrowsableAttribute(browsable));
                base.fTypeDescriptor.properties["Operand"].attributes.replace(new BrowsableAttribute(browsable));
                base.fTypeDescriptor.properties["Format"].attributes.replace(new BrowsableAttribute(browsable));
                // --
                base.fTypeDescriptor.properties["Operation"].attributes.replace(new BrowsableAttribute(browsable));

                // --

                setChangedOperand();
                setChangedIndexType();
                setChangedValueTypeOrValueIndexType();
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

        public void setChangedOperand2(
            )
        {
            FFormat fFormat;
            bool browsable = false;

            try
            {
                if (m_fJep.hasOperand)
                {
                    fFormat = m_fJep.fOperandFormat;
                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Raw || fFormat == FFormat.Unknown)
                    {
                        browsable = false;
                    }
                    else
                    {
                        browsable = true;
                    }
                }
                else
                {
                    browsable = false;
                }

                // --

                base.fTypeDescriptor.properties["ValueTransformer"].attributes.replace(new BrowsableAttribute(browsable));
                base.fTypeDescriptor.properties["DataConversionSet"].attributes.replace(new BrowsableAttribute(browsable));

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

        private void setChangedIndexType2(
            )
        {
            try
            {
                if (m_fJep.fExpressionType == FExpressionType.Bracket)
                {
                    base.fTypeDescriptor.properties["IndexType"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["IndexOption"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["Index"].attributes.replace(new BrowsableAttribute(false));
                }
                else
                {
                    base.fTypeDescriptor.properties["IndexType"].attributes.replace(new BrowsableAttribute(true));
                    // --
                    if (m_fJep.fOperandIndexType == FOperandIndexType.All)
                    {
                        base.fTypeDescriptor.properties["IndexOption"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["Index"].attributes.replace(new BrowsableAttribute(false));
                    }
                    else
                    {
                        base.fTypeDescriptor.properties["IndexOption"].attributes.replace(new BrowsableAttribute(false));
                        base.fTypeDescriptor.properties["Index"].attributes.replace(new BrowsableAttribute(true));
                    }
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

        private void setChangedValueTypeOrValueIndexType2(
            )
        {
            try
            {
                if (m_fJep.fExpressionType == FExpressionType.Bracket)
                {
                    base.fTypeDescriptor.properties["ValueType"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["ValueIndexType"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["ValueOption"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["ValueIndex"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["Value"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["OperandValue"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["EncodingValue"].attributes.replace(new BrowsableAttribute(false));
                }
                else
                {
                    base.fTypeDescriptor.properties["ValueType"].attributes.replace(new BrowsableAttribute(true));

                    // --

                    if (m_fJep.fOperandValueType == FOperandValueType.Value)
                    {
                        base.fTypeDescriptor.properties["Value"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["EncodingValue"].attributes.replace(new BrowsableAttribute(true));

                        // --

                        base.fTypeDescriptor.properties["ValueIndexType"].attributes.replace(new BrowsableAttribute(false));
                        base.fTypeDescriptor.properties["ValueIndexOption"].attributes.replace(new BrowsableAttribute(false));
                        base.fTypeDescriptor.properties["ValueIndex"].attributes.replace(new BrowsableAttribute(false));
                        base.fTypeDescriptor.properties["OperandValue"].attributes.replace(new BrowsableAttribute(false));

                    }
                    else
                    {
                        base.fTypeDescriptor.properties["Value"].attributes.replace(new BrowsableAttribute(false));
                        base.fTypeDescriptor.properties["EncodingValue"].attributes.replace(new BrowsableAttribute(false));

                        // --

                        base.fTypeDescriptor.properties["ValueIndexType"].attributes.replace(new BrowsableAttribute(true));
                        if (m_fJep.fOperandValueIndexType == FOperandIndexType.All)
                        {
                            base.fTypeDescriptor.properties["ValueIndexOption"].attributes.replace(new BrowsableAttribute(true));
                            base.fTypeDescriptor.properties["ValueIndex"].attributes.replace(new BrowsableAttribute(false));
                        }
                        else
                        {
                            base.fTypeDescriptor.properties["ValueIndexOption"].attributes.replace(new BrowsableAttribute(false));
                            base.fTypeDescriptor.properties["ValueIndex"].attributes.replace(new BrowsableAttribute(true));
                        }
                        base.fTypeDescriptor.properties["OperandValue"].attributes.replace(new BrowsableAttribute(true));
                    }
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

        private void setChangedExpressionType(
            )
        {
            try
            {
                if (m_fJep.fExpressionType == FExpressionType.Comparison)
                {
                    base.fTypeDescriptor.properties["ComparisonMode"].attributes.replace(new BrowsableAttribute(true));
                }
                else
                {
                    base.fTypeDescriptor.properties["ComparisonMode"].attributes.replace(new BrowsableAttribute(false));
                }

                // --

                setChangedOperand();
                setChangedIndexType();
                setChangedValueTypeOrValueIndexType();
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
                if (m_fJep.fExpressionType == FExpressionType.Bracket)
                {
                    base.fTypeDescriptor.properties["OperandType"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["Operand"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["Format"].attributes.replace(new BrowsableAttribute(false));
                    // --
                    base.fTypeDescriptor.properties["Operation"].attributes.replace(new BrowsableAttribute(false));
                    // --
                    base.fTypeDescriptor.properties["ValueTransformer"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["DataConversionSet"].attributes.replace(new BrowsableAttribute(false));
                }
                else
                {
                    fFormat = m_fJep.fOperandFormat;

                    // --

                    base.fTypeDescriptor.properties["OperandType"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["Operand"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["Format"].attributes.replace(new BrowsableAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["Operation"].attributes.replace(new BrowsableAttribute(true));

                    // --

                    if (m_fJep.hasOperand)
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

                // --

                setChangedValueTypeOrValueIndexType();
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

        private void setChangedIndexType(
            )
        {
            try
            {
                if (m_fJep.fExpressionType == FExpressionType.Bracket)
                {
                    base.fTypeDescriptor.properties["IndexType"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["IndexOption"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["Index"].attributes.replace(new BrowsableAttribute(false));
                }
                else
                {
                    base.fTypeDescriptor.properties["IndexType"].attributes.replace(new BrowsableAttribute(true));
                    // --
                    if (m_fJep.fOperandIndexType == FOperandIndexType.All)
                    {
                        base.fTypeDescriptor.properties["IndexOption"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["Index"].attributes.replace(new BrowsableAttribute(false));
                    }
                    else
                    {
                        base.fTypeDescriptor.properties["IndexOption"].attributes.replace(new BrowsableAttribute(false));
                        base.fTypeDescriptor.properties["Index"].attributes.replace(new BrowsableAttribute(true));
                    }
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

        private void setChangedValueTypeOrValueIndexType(
            )
        {
            FFormat fFormat;

            try
            {
                if (m_fJep.fExpressionType == FExpressionType.Bracket)
                {
                    base.fTypeDescriptor.properties["ValueType"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["ValueIndexType"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["ValueOption"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["ValueIndex"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["Value"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["OperandValue"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["EncodingValue"].attributes.replace(new BrowsableAttribute(false));
                }
                else
                {
                    base.fTypeDescriptor.properties["ValueType"].attributes.replace(new BrowsableAttribute(true));

                    // --

                    if (m_fJep.fOperandValueType == FOperandValueType.Value)
                    {
                        fFormat = m_fJep.fOperandFormat;

                        // --

                        base.fTypeDescriptor.properties["Value"].attributes.replace(new BrowsableAttribute(true));
                        // --
                        base.fTypeDescriptor.properties["ValueIndexType"].attributes.replace(new BrowsableAttribute(false));
                        base.fTypeDescriptor.properties["ValueIndexOption"].attributes.replace(new BrowsableAttribute(false));
                        base.fTypeDescriptor.properties["ValueIndex"].attributes.replace(new BrowsableAttribute(false));
                        base.fTypeDescriptor.properties["OperandValue"].attributes.replace(new BrowsableAttribute(false));

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
                        base.fTypeDescriptor.properties["Value"].attributes.replace(new BrowsableAttribute(false));
                        base.fTypeDescriptor.properties["EncodingValue"].attributes.replace(new BrowsableAttribute(false));

                        // --

                        base.fTypeDescriptor.properties["ValueIndexType"].attributes.replace(new BrowsableAttribute(true));
                        if (m_fJep.fOperandValueIndexType == FOperandIndexType.All)
                        {
                            base.fTypeDescriptor.properties["ValueIndexOption"].attributes.replace(new BrowsableAttribute(true));
                            base.fTypeDescriptor.properties["ValueIndex"].attributes.replace(new BrowsableAttribute(false));
                        }
                        else
                        {
                            base.fTypeDescriptor.properties["ValueIndexOption"].attributes.replace(new BrowsableAttribute(false));
                            base.fTypeDescriptor.properties["ValueIndex"].attributes.replace(new BrowsableAttribute(true));
                        }
                        base.fTypeDescriptor.properties["OperandValue"].attributes.replace(new BrowsableAttribute(true));
                    }
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
