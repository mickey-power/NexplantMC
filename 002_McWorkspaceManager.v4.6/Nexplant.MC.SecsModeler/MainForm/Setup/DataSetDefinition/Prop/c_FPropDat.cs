/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropDat.cs
--  Creator         : kitae
--  Create Date     : 2011.04.25
--  Description     : FAMate SECS Modeler Data Property Source Object Class  
--  History         : Created by kitae at 2011.04.25
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.SecsModeler
{
    public class FPropDat : FDynPropCusBase<FSsmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryFont = "[02] Font";
        private const string CategorySource = "[03] Source";
        private const string CategoryTarget = "[04] Target";
        private const string CategoryFormat = "[05] Format";
        private const string CategoryScan = "[06] Scan";
        private const string CategoryMerge = "[07] Merge";
        private const string CategoryValue = "[08] Value";
        private const string CategoryValueInformation = "[09] Value Information";
        private const string CategoryTransformation = "[10] Transformation";        
        private const string CategoryUserTag = "[11] User Tag";

        // --

        private bool m_disposed = false;
        // --
        private FData m_fDat = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropDat(
            FSsmCore fSsmCore,
            FDynPropGrid fPropGrid,
            FData fDat
            )
            : base(fSsmCore, fSsmCore.fUIWizard, fPropGrid)
        {
            m_fDat = fDat;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropDat(
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
                term();
                // --
                m_fDat = null;
            }

            m_disposed = true;

            base.myDispose(disposing);
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
                    return m_fDat.fObjectType.ToString();
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
                    return m_fDat.uniqueIdToString;
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
                    return m_fDat.name;
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

                    m_fDat.name = value;
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
                    return m_fDat.description;
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
                    m_fDat.description = value;
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
                    return m_fDat.fontColor;
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
                    m_fDat.fontColor = value;
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
                    return m_fDat.fontBold;
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
                    m_fDat.fontBold = value;
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

        #region Source

        [Category(CategorySource)]
        public FDataSourceType SourceType
        {
            get
            {
                try
                {
                    return m_fDat.fSourceType;
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

            set
            {
                try
                {
                    if (value == FDataSourceType.Resource && m_fDat.hasChild)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0014", new object[] { "Resource Source Type" }));
                    }

                    // --

                    m_fDat.fSourceType = value;
                    setChangedSourceType();
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

        [Category(CategorySource)]
        public string SourceConstant
        {
            get
            {
                try
                {
                    return m_fDat.sourceConstant;
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

                    m_fDat.sourceConstant = value;
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

        [Category(CategorySource)]
        public FResourceSourceType SourceResource
        {
            get
            {
                try
                {
                    return m_fDat.sourceResource;
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

            set
            {
                try
                {
                    m_fDat.sourceResource = value;
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

        [Category(CategorySource)]
        public FMessageSourceType SourceMessage
        {
            get
            {
                try
                {
                    return m_fDat.sourceMessage;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FMessageSourceType.None;
            }

            set
            {
                try
                {
                    m_fDat.sourceMessage = value;
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

        [Category(CategorySource)]
        public string SourceEquipmentState
        {
            get
            {
                try
                {
                    return m_fDat.sourceEquipmentState;
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

                    m_fDat.sourceEquipmentState = value;
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

        [Category(CategorySource)]
        public string SourceEnvironment
        {
            get
            {
                try
                {
                    return m_fDat.sourceEnvironment;
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

                    m_fDat.sourceEnvironment = value;
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

        [Category(CategorySource)]
        public string SourceColumn
        {
            get
            {
                try
                {
                    return m_fDat.sourceColumn;
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

                    m_fDat.sourceColumn = value;
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

        [Category(CategorySource)]
        public string SourceItem
        {
            get
            {
                try
                {
                    return m_fDat.sourceItem;
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

            set
            {
                try
                {
                    FCommon.validateName(value, true, this.mainObject.fUIWizard);

                    // --

                    m_fDat.sourceItem = value;                    
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

        #region Target

        [Category(CategoryTarget)]
        public FDataTargetType TargetType
        {
            get
            {
                try
                {
                    return m_fDat.fTargetType;
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

            set
            {
                try
                {
                    m_fDat.fTargetType = value;
                    setChangedTargetType();
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

        [Category(CategoryTarget)]
        public string TargetConstant
        {
            get
            {
                try
                {
                    return m_fDat.targetConstant;
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
                    FCommon.validateName(value, false, this.mainObject.fUIWizard);

                    // --

                    m_fDat.targetConstant = value;
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

        [Category(CategoryTarget)]
        public string TargetColumn
        {
            get
            {
                try
                {
                    return m_fDat.targetColumn;
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
                    FCommon.validateName(value, false, this.mainObject.fUIWizard);

                    // --

                    m_fDat.targetColumn = value;
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

        [Category(CategoryTarget)]
        public string TargetItem
        {
            get
            {
                try
                {
                    return m_fDat.targetItem;
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
                    FCommon.validateName(value, false, this.mainObject.fUIWizard);

                    // --

                    m_fDat.targetItem = value;
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
                    return m_fDat.fPattern;
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
                        if (
                            (m_fDat.fParent.fObjectType == FObjectType.DataSet && ((FDataSet)m_fDat.fParent).hasVariableChild) ||
                            (m_fDat.fParent.fObjectType == FObjectType.Data && ((FData)m_fDat.fParent).hasVariableChild)
                            )
                        {
                            // ***
                            // 형제 Variable과 연속적으로 이어져야 한다.
                            // ***
                            if (m_fDat.fPreviousSibling == null && m_fDat.fNextSibling.fPattern != FPattern.Variable)
                            {
                                FDebug.throwFException(fUIWizard.generateMessage("E0012", new object[] { "Data" }));
                            }
                            else if (m_fDat.fNextSibling == null && m_fDat.fPreviousSibling.fPattern != FPattern.Variable)
                            {
                                FDebug.throwFException(fUIWizard.generateMessage("E0012", new object[] { "Data" }));
                            }
                            else if (
                                m_fDat.fPreviousSibling != null &&
                                m_fDat.fNextSibling != null &&
                                (m_fDat.fPreviousSibling.fPattern != FPattern.Variable && m_fDat.fNextSibling.fPattern != FPattern.Variable)
                                )
                            {
                                FDebug.throwFException(fUIWizard.generateMessage("E0012", new object[] { "Data" }));
                            }

                            // --

                            // ***
                            // Variable은 한 종류의 Source Type만을 설정할 수 있다.
                            // ***
                            if (
                                (m_fDat.fPreviousSibling != null && m_fDat.fPreviousSibling.fPattern == FPattern.Variable && m_fDat.fPreviousSibling.fSourceType != m_fDat.fSourceType) ||
                                (m_fDat.fNextSibling != null && m_fDat.fNextSibling.fPattern == FPattern.Variable && m_fDat.fNextSibling.fSourceType != m_fDat.fSourceType)
                                )
                            {
                                FDebug.throwFException(fUIWizard.generateMessage("E0015", new object[] { "Source Type" }));
                            }
                        }
                    }

                    // --

                    m_fDat.fPattern = value;
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
                    return m_fDat.fixedLength;
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
                    m_fDat.fixedLength = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
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
                    return m_fDat.fFormat;
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
                    m_fDat.fFormat = value;
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

        #region Merge

        [Category(CategoryMerge)]
        public bool Merge
        {
            get
            {
                try
                {
                    return m_fDat.merge;
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
                    m_fDat.merge = value;
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
                    return m_fDat.fScanMode;
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
                    m_fDat.fScanMode = value;
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
        [Editor(typeof(FPropAttrDatValueUITypeEditor), typeof(UITypeEditor))]
        public string OriginalValue
        {
            get
            {
                try
                {
                    return getDisplayValue(m_fDat.originalStringValue);
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
                    m_fDat.originalStringValue = value;
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
                    return getDisplayValue(m_fDat.originalEncodingValue);
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
                    return m_fDat.originalLength;
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
                    return m_fDat.valueType.ToString();
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
                    return m_fDat.isArrayValue;
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
                    return m_fDat.isNullValue;
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
                    return getDisplayValue(m_fDat.stringValue);
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
                    return getDisplayValue(m_fDat.encodingValue);
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
                    return m_fDat.length;
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
        [Editor(typeof(FPropAttrDatValueTransformerUITypeEditor), typeof(UITypeEditor))]
        public string ValueTransformer
        {
            get
            {
                try
                {
                    return m_fDat.fValueTransformer.ToString();
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
        [Editor(typeof(FPropAttrDatDataConversionSetUITypeEditor), typeof(UITypeEditor))]
        public string DataConversionSet
        {
            get
            {
                try
                {
                    return m_fDat.hasDataConversionSet ? m_fDat.fDataConversionSet.name : string.Empty;
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
                    return m_fDat.userTag1;
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

            set
            {
                try
                {
                    m_fDat.userTag1 = value;
                }
                catch(Exception ex)
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
                    return m_fDat.userTag2;
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

            set
            {
                try
                {
                    m_fDat.userTag2 = value;
                }
                catch(Exception ex)
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
                    return m_fDat.userTag3;
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
            
            set
            {
                try
                {
                    m_fDat.userTag3 = value;
                }
                catch(Exception ex)
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
                    return m_fDat.userTag4;
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

            set
            {
                try
                {
                    m_fDat.userTag4 = value;
                }
                catch(Exception ex)
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
                    return m_fDat.userTag5;
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

            set
            {
                try
                {
                    m_fDat.userTag5 = value;
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
        
        #region  Properties

        [Browsable(false)]
        public FData fData
        {
            get
            {
                try
                {
                    return m_fDat;
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

        public void init(
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
                base.fTypeDescriptor.properties["SourceType"].attributes.replace(new DisplayNameAttribute("Source Type"));
                base.fTypeDescriptor.properties["SourceConstant"].attributes.replace(new DisplayNameAttribute("Constant"));
                base.fTypeDescriptor.properties["SourceResource"].attributes.replace(new DisplayNameAttribute("Resource"));
                base.fTypeDescriptor.properties["SourceMessage"].attributes.replace(new DisplayNameAttribute("Message"));
                base.fTypeDescriptor.properties["SourceEquipmentState"].attributes.replace(new DisplayNameAttribute("Equipment State"));
                base.fTypeDescriptor.properties["SourceEnvironment"].attributes.replace(new DisplayNameAttribute("Environment"));
                base.fTypeDescriptor.properties["SourceColumn"].attributes.replace(new DisplayNameAttribute("Column "));
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
                base.fTypeDescriptor.properties["Merge"].attributes.replace(new DisplayNameAttribute("Merge"));
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
                base.fTypeDescriptor.properties["DataConversionSet"].attributes.replace(new DisplayNameAttribute("Data Conversion Set"));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DisplayNameAttribute(m_fDat.defUserTagName1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DisplayNameAttribute(m_fDat.defUserTagName2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DisplayNameAttribute(m_fDat.defUserTagName3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DisplayNameAttribute(m_fDat.defUserTagName4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DisplayNameAttribute(m_fDat.defUserTagName5));

                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_fDat.fObjectType.ToString()));
                base.fTypeDescriptor.properties["ID"].attributes.replace(new DefaultValueAttribute(m_fDat.uniqueIdToString));
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(m_fDat.name));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_fDat.description));
                // --
                base.fTypeDescriptor.properties["FontColor"].attributes.replace(new DefaultValueAttribute(m_fDat.fontColor));
                base.fTypeDescriptor.properties["FontBold"].attributes.replace(new DefaultValueAttribute(m_fDat.fontBold));
                // --
                base.fTypeDescriptor.properties["SourceType"].attributes.replace(new DefaultValueAttribute(m_fDat.fSourceType));
                base.fTypeDescriptor.properties["SourceConstant"].attributes.replace(new DefaultValueAttribute(m_fDat.sourceConstant));
                base.fTypeDescriptor.properties["SourceResource"].attributes.replace(new DefaultValueAttribute(m_fDat.sourceResource));
                base.fTypeDescriptor.properties["SourceMessage"].attributes.replace(new DefaultValueAttribute(m_fDat.sourceMessage));
                base.fTypeDescriptor.properties["SourceEquipmentState"].attributes.replace(new DefaultValueAttribute(m_fDat.sourceEquipmentState));
                base.fTypeDescriptor.properties["SourceEnvironment"].attributes.replace(new DefaultValueAttribute(m_fDat.sourceEnvironment));
                base.fTypeDescriptor.properties["SourceColumn"].attributes.replace(new DefaultValueAttribute(m_fDat.sourceColumn));
                base.fTypeDescriptor.properties["SourceItem"].attributes.replace(new DefaultValueAttribute(m_fDat.sourceItem));                
                // --
                base.fTypeDescriptor.properties["TargetType"].attributes.replace(new DefaultValueAttribute(m_fDat.fTargetType));
                base.fTypeDescriptor.properties["TargetConstant"].attributes.replace(new DefaultValueAttribute(m_fDat.targetConstant));
                base.fTypeDescriptor.properties["TargetColumn"].attributes.replace(new DefaultValueAttribute(m_fDat.targetColumn));                
                base.fTypeDescriptor.properties["TargetItem"].attributes.replace(new DefaultValueAttribute(m_fDat.targetItem));                
                // --
                base.fTypeDescriptor.properties["Pattern"].attributes.replace(new DefaultValueAttribute(m_fDat.fPattern));
                base.fTypeDescriptor.properties["FixedLength"].attributes.replace(new DefaultValueAttribute(m_fDat.fixedLength));
                base.fTypeDescriptor.properties["Format"].attributes.replace(new DefaultValueAttribute(m_fDat.fFormat));
                // --
                base.fTypeDescriptor.properties["Merge"].attributes.replace(new DefaultValueAttribute(m_fDat.merge));
                // --
                base.fTypeDescriptor.properties["ScanMode"].attributes.replace(new DefaultValueAttribute(m_fDat.fScanMode));
                // --
                base.fTypeDescriptor.properties["OriginalValue"].attributes.replace(new DefaultValueAttribute(getDisplayValue(m_fDat.originalStringValue)));
                base.fTypeDescriptor.properties["OriginalEncodingValue"].attributes.replace(new DefaultValueAttribute(getDisplayValue(m_fDat.originalEncodingValue)));
                base.fTypeDescriptor.properties["OriginalLength"].attributes.replace(new DefaultValueAttribute(m_fDat.originalLength));
                // --
                base.fTypeDescriptor.properties["ValueType"].attributes.replace(new DefaultValueAttribute(m_fDat.valueType.ToString()));
                base.fTypeDescriptor.properties["ArrayValue"].attributes.replace(new DefaultValueAttribute(m_fDat.isArrayValue));
                base.fTypeDescriptor.properties["NullValue"].attributes.replace(new DefaultValueAttribute(m_fDat.isNullValue));
                base.fTypeDescriptor.properties["Value"].attributes.replace(new DefaultValueAttribute(getDisplayValue(m_fDat.stringValue)));
                base.fTypeDescriptor.properties["EncodingValue"].attributes.replace(new DefaultValueAttribute(getDisplayValue(m_fDat.encodingValue)));
                base.fTypeDescriptor.properties["Length"].attributes.replace(new DefaultValueAttribute(m_fDat.length));
                // --
                base.fTypeDescriptor.properties["ValueTransformer"].attributes.replace(new DefaultValueAttribute(m_fDat.fValueTransformer.ToString()));
                base.fTypeDescriptor.properties["DataConversionSet"].attributes.replace(new DefaultValueAttribute(m_fDat.hasDataConversionSet ? m_fDat.fDataConversionSet.name : string.Empty));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DefaultValueAttribute(m_fDat.userTag1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DefaultValueAttribute(m_fDat.userTag2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DefaultValueAttribute(m_fDat.userTag3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DefaultValueAttribute(m_fDat.userTag4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DefaultValueAttribute(m_fDat.userTag5));

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
                setChangedSourceType();
                setChangedPattern();
                setChangedFormat();
                // --
                setChangedTargetType();
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

        private void setChangedSourceType(
            )
        {
            FDataSourceType fType;

            try
            {
                fType = m_fDat.fSourceType;

                // --

                if (fType == FDataSourceType.Constant)
                {
                    base.fTypeDescriptor.properties["SourceConstant"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["SourceResource"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceMessage"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceEquipmentState"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceEnvironment"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceColumn"].attributes.replace(new BrowsableAttribute(false));                    
                    base.fTypeDescriptor.properties["SourceItem"].attributes.replace(new BrowsableAttribute(false));                    
                    // --
                    base.fTypeDescriptor.properties["Pattern"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["FixedLength"].attributes.replace(new BrowsableAttribute(false));                    
                    base.fTypeDescriptor.properties["Format"].attributes.replace(new ReadOnlyAttribute(false));
                    // --
                    base.fTypeDescriptor.properties["ScanMode"].attributes.replace(new BrowsableAttribute(false));                    
                }
                else if (fType == FDataSourceType.Resource)
                {
                    base.fTypeDescriptor.properties["SourceConstant"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceResource"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["SourceMessage"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceEquipmentState"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceEnvironment"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceColumn"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceItem"].attributes.replace(new BrowsableAttribute(false));                    
                    // --
                    base.fTypeDescriptor.properties["Pattern"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["FixedLength"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["Format"].attributes.replace(new ReadOnlyAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["ScanMode"].attributes.replace(new BrowsableAttribute(false));                    
                }
                else if (fType == FDataSourceType.Message)
                {
                    base.fTypeDescriptor.properties["SourceConstant"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceResource"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceMessage"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["SourceEquipmentState"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceEnvironment"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceColumn"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceItem"].attributes.replace(new BrowsableAttribute(false));
                    // --
                    base.fTypeDescriptor.properties["Pattern"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["FixedLength"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["Format"].attributes.replace(new ReadOnlyAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["ScanMode"].attributes.replace(new BrowsableAttribute(false));
                }
                else if (fType == FDataSourceType.EquipmentState)
                {
                    base.fTypeDescriptor.properties["SourceConstant"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceResource"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceMessage"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceEquipmentState"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["SourceEnvironment"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceColumn"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceItem"].attributes.replace(new BrowsableAttribute(false));
                    // --
                    base.fTypeDescriptor.properties["Pattern"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["FixedLength"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["Format"].attributes.replace(new ReadOnlyAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["ScanMode"].attributes.replace(new BrowsableAttribute(false));
                }
                else if (fType == FDataSourceType.Environment)                    
                {
                    base.fTypeDescriptor.properties["SourceConstant"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceResource"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceMessage"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceEquipmentState"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceEnvironment"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["SourceColumn"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceItem"].attributes.replace(new BrowsableAttribute(false));                    
                    // --
                    base.fTypeDescriptor.properties["Pattern"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["FixedLength"].attributes.replace(new BrowsableAttribute(this.Pattern == FPattern.Fixed ? true : false));
                    base.fTypeDescriptor.properties["Format"].attributes.replace(new ReadOnlyAttribute(false));
                    // --
                    base.fTypeDescriptor.properties["ScanMode"].attributes.replace(new BrowsableAttribute(this.Pattern == FPattern.Fixed ? true : false));                    
                }
                else if (fType == FDataSourceType.Column)
                {
                    base.fTypeDescriptor.properties["SourceConstant"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceResource"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceMessage"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceEquipmentState"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceEnvironment"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceColumn"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["SourceItem"].attributes.replace(new BrowsableAttribute(false));
                    // --
                    base.fTypeDescriptor.properties["Pattern"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["FixedLength"].attributes.replace(new BrowsableAttribute(this.Pattern == FPattern.Fixed ? true : false));
                    base.fTypeDescriptor.properties["Format"].attributes.replace(new ReadOnlyAttribute(false));
                    // --
                    base.fTypeDescriptor.properties["ScanMode"].attributes.replace(new BrowsableAttribute(this.Pattern == FPattern.Fixed ? true : false));                    
                }
                else
                {
                    base.fTypeDescriptor.properties["SourceConstant"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceResource"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceMessage"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceEquipmentState"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceEnvironment"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceColumn"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["SourceItem"].attributes.replace(new BrowsableAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["Pattern"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["FixedLength"].attributes.replace(new BrowsableAttribute(this.Pattern == FPattern.Fixed ? true : false));
                    base.fTypeDescriptor.properties["Format"].attributes.replace(new ReadOnlyAttribute(false));
                    // --
                    base.fTypeDescriptor.properties["ScanMode"].attributes.replace(new BrowsableAttribute(this.Pattern == FPattern.Fixed ? true : false));
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

        private void setChangedPattern(
            )
        {
            FPattern fPattern;
                        
            try
            {
                fPattern = m_fDat.fPattern;

                // --

                if (fPattern == FPattern.Fixed)
                {
                    base.fTypeDescriptor.properties["SourceType"].attributes.replace(new ReadOnlyAttribute(false));
                    // --
                    if (m_fDat.fSourceType == FDataSourceType.Constant || 
                        m_fDat.fSourceType == FDataSourceType.Resource ||
                        m_fDat.fSourceType == FDataSourceType.Message || 
                        m_fDat.fSourceType == FDataSourceType.EquipmentState)
                    {
                        base.fTypeDescriptor.properties["FixedLength"].attributes.replace(new BrowsableAttribute(false));
                        base.fTypeDescriptor.properties["ScanMode"].attributes.replace(new BrowsableAttribute(false));
                    }
                    else
                    {
                        base.fTypeDescriptor.properties["FixedLength"].attributes.replace(new BrowsableAttribute(true));
                        base.fTypeDescriptor.properties["ScanMode"].attributes.replace(new BrowsableAttribute(true));
                    }                    
                }
                else if (fPattern == FPattern.Variable)
                {
                    if (
                        (m_fDat.fPreviousSibling != null && m_fDat.fPreviousSibling.fPattern == FPattern.Variable) &&
                        (m_fDat.fNextSibling != null && m_fDat.fNextSibling.fPattern == FPattern.Variable)
                        )
                    {
                        base.fTypeDescriptor.properties["SourceType"].attributes.replace(new ReadOnlyAttribute(true));
                        base.fTypeDescriptor.properties["Pattern"].attributes.replace(new ReadOnlyAttribute(true));                        
                    }
                    else if (
                        (m_fDat.fPreviousSibling != null && m_fDat.fPreviousSibling.fPattern == FPattern.Variable) ||
                        (m_fDat.fNextSibling != null && m_fDat.fNextSibling.fPattern == FPattern.Variable)
                        )
                    {
                        base.fTypeDescriptor.properties["SourceType"].attributes.replace(new ReadOnlyAttribute(true));
                        base.fTypeDescriptor.properties["Pattern"].attributes.replace(new ReadOnlyAttribute(false));
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
            catch(Exception ex)
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
                fFormat = m_fDat.fFormat;

                // --

                if (m_fDat.fSourceType == FDataSourceType.Resource)
                {
                    base.fTypeDescriptor.properties["Format"].attributes.replace(new ReadOnlyAttribute(true));
                }
                else
                {
                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList)
                    {
                        base.fTypeDescriptor.properties["Format"].attributes.replace(new ReadOnlyAttribute(m_fDat.hasChild | m_fDat.locked));
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
                        base.fTypeDescriptor.properties["Merge"].attributes.replace(new BrowsableAttribute(false));
                    }
                    else if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2)
                    {
                        if (fFormat == FFormat.Ascii && m_fDat.fParent.fObjectType == FObjectType.Data && ((FData)m_fDat.fParent).fFormat == FFormat.AsciiList)
                        {
                            base.fTypeDescriptor.properties["Format"].attributes.replace(new ReadOnlyAttribute(true));
                        }
                        else
                        {
                            base.fTypeDescriptor.properties["Format"].attributes.replace(new ReadOnlyAttribute(m_fDat.locked));
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
                        base.fTypeDescriptor.properties["Merge"].attributes.replace(new BrowsableAttribute(true));
                    }
                    else if (fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                    {
                        base.fTypeDescriptor.properties["Format"].attributes.replace(new ReadOnlyAttribute(m_fDat.locked));
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
                        base.fTypeDescriptor.properties["Merge"].attributes.replace(new BrowsableAttribute(false));
                    }
                    else
                    {
                        base.fTypeDescriptor.properties["Format"].attributes.replace(new ReadOnlyAttribute(m_fDat.locked));
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
                        base.fTypeDescriptor.properties["Merge"].attributes.replace(new BrowsableAttribute(false));
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

        private void setChangedTargetType(
            )
        {
            FDataTargetType fType;

            try
            {
                fType = m_fDat.fTargetType;

                // --

                if (fType == FDataTargetType.Constant)
                {
                    base.fTypeDescriptor.properties["TargetConstant"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["TargetColumn"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["TargetItem"].attributes.replace(new BrowsableAttribute(false));
                }
                else if (fType == FDataTargetType.Column)
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
    