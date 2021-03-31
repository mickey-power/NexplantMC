/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropVfm.cs
--  Creator         : spike.lee
--  Create Date     : 2011.03.03
--  Description     : FAMate TCP Modeler Value Formula Property Source Object Class 
--  History         : Created by spike.lee at 2011.03.03
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
using Infragistics.Win.UltraWinDataSource;

namespace Nexplant.MC.TcpModeler
{
    public class FPropVfm : FDynPropCusBase<FTcmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryParameter = "[02] Parameter";

        // --

        private bool m_disposed = false;
        // --
        private FIValueTransformer m_fValueTransformer = null;
        private FIValueFormula m_fValueFormula = null;
        private UltraDataRow m_dataRow = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropVfm(
            FTcmCore fTcmCore,
            FDynPropGrid fPropGrid,
            FIValueTransformer fValueTransFormer,
            FIValueFormula fValueFormula,
            UltraDataRow dataRow
            )
            : base(fTcmCore, fTcmCore.fUIWizard, fPropGrid)
        {
            m_fValueTransformer = fValueTransFormer;
            m_fValueFormula = fValueFormula;
            m_dataRow = dataRow;
            // --
            init();   
        }        

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropVfm(
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
                    m_fValueTransformer = null;
                    m_fValueFormula = null;
                    m_dataRow = null;
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
        [TypeConverter(typeof(FPropAttrVfmTypeStringConverter))]
        public string Type
        {
            get
            {
                try
                {
                    return m_fValueFormula.fType.ToString();
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
                FValueFormulaType type;

                try
                {
                    type = (FValueFormulaType)Enum.Parse(typeof(FValueFormulaType), value);

                    // --

                    if (type == FValueFormulaType.Choose)
                    {
                        m_fValueFormula = new FChoose();
                    }
                    else if (type == FValueFormulaType.ChooseR)
                    {
                        m_fValueFormula = new FChooseR();
                    }
                    else if (type == FValueFormulaType.ChooseIncluded)
                    {
                        m_fValueFormula = new FChooseIncluded();
                    }
                    else if (type == FValueFormulaType.ChooseIncludedR)
                    {
                        m_fValueFormula = new FChooseIncludedR();
                    }
                    else if (type == FValueFormulaType.DateTime)
                    {
                        m_fValueFormula = new FDateTime();
                    }
                    else if (type == FValueFormulaType.FixLength)
                    {
                        m_fValueFormula = new FFixLength();
                    }
                    else if (type == FValueFormulaType.FixLengthR)
                    {
                        m_fValueFormula = new FFixLengthR();
                    }
                    else if (type == FValueFormulaType.Insert)
                    {
                        m_fValueFormula = new FInsert();
                    }
                    else if (type == FValueFormulaType.InsertR)
                    {
                        m_fValueFormula = new FInsertR();
                    }
                    else if (type == FValueFormulaType.PadLeft)
                    {
                        m_fValueFormula = new FPadLeft();
                    }
                    else if (type == FValueFormulaType.PadRight)
                    {
                        m_fValueFormula = new FPadRight();
                    }
                    else if (type == FValueFormulaType.Prefix)
                    {
                        m_fValueFormula = new FPrefix();
                    }
                    else if (type == FValueFormulaType.Remove)
                    {
                        m_fValueFormula = new FRemove();
                    }
                    else if (type == FValueFormulaType.RemoveR)
                    {
                        m_fValueFormula = new FRemoveR();
                    }
                    else if (type == FValueFormulaType.Replace)
                    {
                        m_fValueFormula = new FReplace();
                    }
                    else if (type == FValueFormulaType.Select)
                    {
                        m_fValueFormula = new FSelect();
                    }
                    else if (type == FValueFormulaType.SelectR)
                    {
                        m_fValueFormula = new FSelectR();
                    }
                    else if (type == FValueFormulaType.SelectIncluded)
                    {
                        m_fValueFormula = new FSelectIncluded();
                    }
                    else if (type == FValueFormulaType.SelectIncludedR)
                    {
                        m_fValueFormula = new FSelectIncludedR();
                    }
                    else if (type == FValueFormulaType.SubString)
                    {
                        m_fValueFormula = new FSubString();
                    }
                    else if (type == FValueFormulaType.SubStringR)
                    {
                        m_fValueFormula = new FSubStringR();
                    }
                    else if (type == FValueFormulaType.SelectArray)
                    {
                        m_fValueFormula = new FSelectArray();
                    }
                    else if (type == FValueFormulaType.SelectArrayR)
                    {
                        m_fValueFormula = new FSelectArrayR();
                    }
                    else if (type == FValueFormulaType.Suffix)
                    {
                        m_fValueFormula = new FSuffix();
                    }
                    else if (type == FValueFormulaType.ToBit)
                    {
                        m_fValueFormula = new FToBit();
                    }
                    else if (type == FValueFormulaType.ToLower)
                    {
                        m_fValueFormula = new FToLower();
                    }
                    else if (type == FValueFormulaType.ToUpper)
                    {
                        m_fValueFormula = new FToUpper();
                    }
                    else if (type == FValueFormulaType.Trim)
                    {
                        m_fValueFormula = new FTrim();
                    }
                    else if (type == FValueFormulaType.TrimAll)
                    {
                        m_fValueFormula = new FTrimAll();
                    }
                    else if (type == FValueFormulaType.TrimStart)
                    {
                        m_fValueFormula = new FTrimStart();
                    }
                    else if (type == FValueFormulaType.TrimEnd)
                    {
                        m_fValueFormula = new FTrimEnd();
                    }
                    else if (type == FValueFormulaType.Add)
                    {
                        m_fValueFormula = new FAdd();
                    }
                    else if (type == FValueFormulaType.Subtract)
                    {
                        m_fValueFormula = new FSubtract();
                    }
                    else if (type == FValueFormulaType.Multiply)
                    {
                        m_fValueFormula = new FMultiply();
                    }
                    else if (type == FValueFormulaType.Divide)
                    {
                        m_fValueFormula = new FDivide();
                    }
                    else if (type == FValueFormulaType.Round)
                    {
                        m_fValueFormula = new FRound();
                    }
                    else if (type == FValueFormulaType.Trunc)
                    {
                        m_fValueFormula = new FTrunc();
                    }
                    else if (type == FValueFormulaType.Ceil)
                    {
                        m_fValueFormula = new FCeil();
                    }
                    else if (type == FValueFormulaType.Mod)
                    {
                        m_fValueFormula = new FMod();
                    }
                    else if (type == FValueFormulaType.StringCount)
                    {
                        m_fValueFormula = new FStringCount();
                    }
                    else if (type == FValueFormulaType.Length)
                    {
                        m_fValueFormula = new FLength();
                    }
                    else if (type == FValueFormulaType.DecimalToHex)
                    {
                        m_fValueFormula = new FDecimalToHex();      // 2017.03.27 by spike.lee add
                    }
                    else if (type == FValueFormulaType.HexToDecimal)
                    {
                        m_fValueFormula = new FHexToDecimal();      // 2017.03.27 by spike.lee add
                    }

                    // --

                    replaceValueFormula();
                    setValueFormulaParameter();
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

        #region Choose Serise Parameter

        [Category(CategoryParameter)]
        public string ChooseStartString
        {
            get
            {
                try
                {
                    if (m_fValueFormula.fType == FValueFormulaType.Choose)
                    {
                        return ((FChoose)m_fValueFormula).startString;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.ChooseR)
                    {
                        return ((FChooseR)m_fValueFormula).startString;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.ChooseIncluded)
                    {
                        return ((FChooseIncluded)m_fValueFormula).startString;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.ChooseIncludedR)
                    {
                        return ((FChooseIncludedR)m_fValueFormula).startString;
                    }
                    return string.Empty;
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
                    if (m_fValueFormula.fType == FValueFormulaType.Choose)
                    {
                        ((FChoose)m_fValueFormula).startString = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.ChooseR)
                    {
                        ((FChooseR)m_fValueFormula).startString = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.ChooseIncluded)
                    {
                        ((FChooseIncluded)m_fValueFormula).startString = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.ChooseIncludedR)
                    {
                        ((FChooseIncludedR)m_fValueFormula).startString = value;
                    }
                    replaceValueFormula(); 
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

        [Category(CategoryParameter)]
        public int ChooseStartPosition
        {
            get
            {
                try
                {
                    if (m_fValueFormula.fType == FValueFormulaType.Choose)
                    {
                        return ((FChoose)m_fValueFormula).startPosition;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.ChooseR)
                    {
                        return ((FChooseR)m_fValueFormula).startPosition;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.ChooseIncluded)
                    {
                        return ((FChooseIncluded)m_fValueFormula).startPosition;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.ChooseIncludedR)
                    {
                        return ((FChooseIncludedR)m_fValueFormula).startPosition;
                    }
                    return 0;
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
                    if (m_fValueFormula.fType == FValueFormulaType.Choose)
                    {
                        ((FChoose)m_fValueFormula).startPosition = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.ChooseR)
                    {
                        ((FChooseR)m_fValueFormula).startPosition = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.ChooseIncluded)
                    {
                        ((FChooseIncluded)m_fValueFormula).startPosition = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.ChooseIncludedR)
                    {
                        ((FChooseIncludedR)m_fValueFormula).startPosition = value;
                    }
                    replaceValueFormula(); 
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

        [Category(CategoryParameter)]
        public string ChooseEndString
        {
            get
            {
                try
                {
                    if (m_fValueFormula.fType == FValueFormulaType.Choose)
                    {
                        return ((FChoose)m_fValueFormula).endString;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.ChooseR)
                    {
                        return ((FChooseR)m_fValueFormula).endString;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.ChooseIncluded)
                    {
                        return ((FChooseIncluded)m_fValueFormula).endString;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.ChooseIncludedR)
                    {
                        return ((FChooseIncludedR)m_fValueFormula).endString;
                    }
                    return string.Empty;
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
                    if (m_fValueFormula.fType == FValueFormulaType.Choose)
                    {
                        ((FChoose)m_fValueFormula).endString = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.ChooseR)
                    {
                        ((FChooseR)m_fValueFormula).endString = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.ChooseIncluded)
                    {
                        ((FChooseIncluded)m_fValueFormula).endString = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.ChooseIncludedR)
                    {
                        ((FChooseIncludedR)m_fValueFormula).endString = value;
                    }
                    replaceValueFormula(); 
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

        [Category(CategoryParameter)]
        public int ChooseEndPosition
        {
            get
            {
                try
                {
                    if (m_fValueFormula.fType == FValueFormulaType.Choose)
                    {
                        return ((FChoose)m_fValueFormula).endPosition;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.ChooseR)
                    {
                        return ((FChooseR)m_fValueFormula).endPosition;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.ChooseIncluded)
                    {
                        return ((FChooseIncluded)m_fValueFormula).endPosition;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.ChooseIncludedR)
                    {
                        return ((FChooseIncludedR)m_fValueFormula).endPosition;
                    }
                    return 0;
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
                    if (m_fValueFormula.fType == FValueFormulaType.Choose)
                    {
                        ((FChoose)m_fValueFormula).endPosition = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.ChooseR)
                    {
                        ((FChooseR)m_fValueFormula).endPosition = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.ChooseIncluded)
                    {
                        ((FChooseIncluded)m_fValueFormula).endPosition = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.ChooseIncludedR)
                    {
                        ((FChooseIncludedR)m_fValueFormula).endPosition = value;
                    }
                    replaceValueFormula(); 
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

        #region DateTime Parameter

        [Category(CategoryParameter)]
        public string DateTimeFormat
        {
            get
            {
                try
                {
                    if (m_fValueFormula.fType == FValueFormulaType.DateTime)
                    {
                        return ((FDateTime)m_fValueFormula).format;
                    }
                    return string.Empty;                    
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
                    if (m_fValueFormula.fType == FValueFormulaType.DateTime)
                    {
                        ((FDateTime)m_fValueFormula).format = value;
                    }
                    replaceValueFormula(); 
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

        #region FixLength Serise Parameter

        [Category(CategoryParameter)]
        public int FixLengthLength
        {
            get
            {
                try
                {
                    if (m_fValueFormula.fType == FValueFormulaType.FixLength)
                    {
                        return ((FFixLength)m_fValueFormula).length;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.FixLengthR)
                    {
                        return ((FFixLengthR)m_fValueFormula).length;
                    }                    
                    return 0;
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
                    if (m_fValueFormula.fType == FValueFormulaType.FixLength)
                    {
                        ((FFixLength)m_fValueFormula).length = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.FixLengthR)
                    {
                        ((FFixLengthR)m_fValueFormula).length = value;
                    }
                    replaceValueFormula(); 
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

        [Category(CategoryParameter)]
        public string FixLengthFixString
        {
            get
            {
                try
                {
                    if (m_fValueFormula.fType == FValueFormulaType.FixLength)
                    {
                        return ((FFixLength)m_fValueFormula).fixString;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.FixLengthR)
                    {
                        return ((FFixLengthR)m_fValueFormula).fixString;
                    }                    
                    return string.Empty;
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
                    if (m_fValueFormula.fType == FValueFormulaType.FixLength)
                    {
                        ((FFixLength)m_fValueFormula).fixString = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.FixLengthR)
                    {
                        ((FFixLengthR)m_fValueFormula).fixString = value;
                    }
                    replaceValueFormula(); 
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

        #region Insert Serise Parameter

        [Category(CategoryParameter)]
        public int InsertStartIndex
        {
            get
            {
                try
                {
                    if (m_fValueFormula.fType == FValueFormulaType.Insert)
                    {
                        return ((FInsert)m_fValueFormula).startIndex;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.InsertR)
                    {
                        return ((FInsertR)m_fValueFormula).startIndex;
                    }
                    return 0;
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
                    if (m_fValueFormula.fType == FValueFormulaType.Insert)
                    {
                        ((FInsert)m_fValueFormula).startIndex = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.InsertR)
                    {
                        ((FInsertR)m_fValueFormula).startIndex = value;
                    }
                    replaceValueFormula(); 
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

        [Category(CategoryParameter)]
        public string InsertValue
        {
            get
            {
                try
                {
                    if (m_fValueFormula.fType == FValueFormulaType.Insert)
                    {
                        return ((FInsert)m_fValueFormula).value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.InsertR)
                    {
                        return ((FInsertR)m_fValueFormula).value;
                    }
                    return string.Empty;
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
                    if (m_fValueFormula.fType == FValueFormulaType.Insert)
                    {
                        ((FInsert)m_fValueFormula).value = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.InsertR)
                    {
                        ((FInsertR)m_fValueFormula).value = value;
                    }
                    replaceValueFormula(); 
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

        #region Pad Serise Parameter

        [Category(CategoryParameter)]
        public int PadTotalWidth
        {
            get
            {
                try
                {
                    if (m_fValueFormula.fType == FValueFormulaType.PadLeft)
                    {
                        return ((FPadLeft)m_fValueFormula).totalWidth;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.PadRight)
                    {
                        return ((FPadRight)m_fValueFormula).totalWidth;
                    }
                    return 0;
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
                    if (m_fValueFormula.fType == FValueFormulaType.PadLeft)
                    {
                        ((FPadLeft)m_fValueFormula).totalWidth = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.PadRight)
                    {
                        ((FPadRight)m_fValueFormula).totalWidth = value;
                    }
                    replaceValueFormula(); 
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

        [Category(CategoryParameter)]
        public string PadPadString
        {
            get
            {
                try
                {
                    if (m_fValueFormula.fType == FValueFormulaType.PadLeft)
                    {
                        return ((FPadLeft)m_fValueFormula).padString;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.PadRight)
                    {
                        return ((FPadRight)m_fValueFormula).padString;
                    }
                    return string.Empty;
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
                    if (m_fValueFormula.fType == FValueFormulaType.PadLeft)
                    {
                        ((FPadLeft)m_fValueFormula).padString = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.PadRight)
                    {
                        ((FPadRight)m_fValueFormula).padString = value;
                    }
                    replaceValueFormula(); 
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

        #region Prefix Parameter

        [Category(CategoryParameter)]
        public string PrefixPrefixString
        {
            get
            {
                try
                {
                    if (m_fValueFormula.fType == FValueFormulaType.Prefix)
                    {
                        return ((FPrefix)m_fValueFormula).prefixString;
                    }
                    return string.Empty;
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
                    if (m_fValueFormula.fType == FValueFormulaType.Prefix)
                    {
                        ((FPrefix)m_fValueFormula).prefixString = value;
                    }
                    replaceValueFormula(); 
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

        #region Remove Serise Parameter

        [Category(CategoryParameter)]
        public int RemoveStartIndex
        {
            get
            {
                try
                {
                    if (m_fValueFormula.fType == FValueFormulaType.Remove)
                    {
                        return ((FRemove)m_fValueFormula).startIndex;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.RemoveR)
                    {
                        return ((FRemoveR)m_fValueFormula).startIndex;
                    }
                    return 0;
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
                    if (m_fValueFormula.fType == FValueFormulaType.Remove)
                    {
                        ((FRemove)m_fValueFormula).startIndex = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.RemoveR)
                    {
                        ((FRemoveR)m_fValueFormula).startIndex = value;
                    }
                    replaceValueFormula(); 
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

        [Category(CategoryParameter)]
        public int RemoveLength
        {
            get
            {
                try
                {
                    if (m_fValueFormula.fType == FValueFormulaType.Remove)
                    {
                        return ((FRemove)m_fValueFormula).length;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.RemoveR)
                    {
                        return ((FRemoveR)m_fValueFormula).length;
                    }
                    return 0;
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
                    if (m_fValueFormula.fType == FValueFormulaType.Remove)
                    {
                        ((FRemove)m_fValueFormula).length = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.RemoveR)
                    {
                        ((FRemoveR)m_fValueFormula).length = value;
                    }
                    replaceValueFormula(); 
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

        #region Replace Parameter

        [Category(CategoryParameter)]
        public string ReplaceOldValue
        {
            get
            {
                try
                {
                    if (m_fValueFormula.fType == FValueFormulaType.Replace)
                    {
                        return ((FReplace)m_fValueFormula).oldValue;
                    }
                    return string.Empty;
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
                    if (m_fValueFormula.fType == FValueFormulaType.Replace)
                    {
                        ((FReplace)m_fValueFormula).oldValue = value;
                    }
                    replaceValueFormula(); 
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

        [Category(CategoryParameter)]
        public string ReplaceNewValue
        {
            get
            {
                try
                {
                    if (m_fValueFormula.fType == FValueFormulaType.Replace)
                    {
                        return ((FReplace)m_fValueFormula).newValue;
                    }
                    return string.Empty;
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
                    if (m_fValueFormula.fType == FValueFormulaType.Replace)
                    {
                        ((FReplace)m_fValueFormula).newValue = value;
                    }
                    replaceValueFormula(); 
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

        #region Select Serise Parameter

        [Category(CategoryParameter)]
        public string SelectSelectString
        {
            get
            {
                try
                {
                    if (m_fValueFormula.fType == FValueFormulaType.Select)
                    {
                        return ((FSelect)m_fValueFormula).selectString;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.SelectR)
                    {
                        return ((FSelectR)m_fValueFormula).selectString;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.SelectIncluded)
                    {
                        return ((FSelectIncluded)m_fValueFormula).selectString;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.SelectIncludedR)
                    {
                        return ((FSelectIncludedR)m_fValueFormula).selectString;
                    }
                    return string.Empty;
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
                    if (m_fValueFormula.fType == FValueFormulaType.Select)
                    {
                        ((FSelect)m_fValueFormula).selectString = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.SelectR)
                    {
                        ((FSelectR)m_fValueFormula).selectString = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.SelectIncluded)
                    {
                        ((FSelectIncluded)m_fValueFormula).selectString = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.SelectIncludedR)
                    {
                        ((FSelectIncludedR)m_fValueFormula).selectString = value;
                    }
                    replaceValueFormula(); 
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

        [Category(CategoryParameter)]
        public int SelectSelectPosition
        {
            get
            {
                try
                {
                    if (m_fValueFormula.fType == FValueFormulaType.Select)
                    {
                        return ((FSelect)m_fValueFormula).selectPosition;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.SelectR)
                    {
                        return ((FSelectR)m_fValueFormula).selectPosition;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.SelectIncluded)
                    {
                        return ((FSelectIncluded)m_fValueFormula).selectPosition;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.SelectIncludedR)
                    {
                        return ((FSelectIncludedR)m_fValueFormula).selectPosition;
                    }
                    return 0;
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
                    if (m_fValueFormula.fType == FValueFormulaType.Select)
                    {
                        ((FSelect)m_fValueFormula).selectPosition = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.SelectR)
                    {
                        ((FSelectR)m_fValueFormula).selectPosition = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.SelectIncluded)
                    {
                        ((FSelectIncluded)m_fValueFormula).selectPosition = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.SelectIncludedR)
                    {
                        ((FSelectIncludedR)m_fValueFormula).selectPosition = value;
                    }
                    replaceValueFormula(); 
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

        [Category(CategoryParameter)]
        public int SelectLength
        {
            get
            {
                try
                {
                    if (m_fValueFormula.fType == FValueFormulaType.Select)
                    {
                        return ((FSelect)m_fValueFormula).length;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.SelectR)
                    {
                        return ((FSelectR)m_fValueFormula).length;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.SelectIncluded)
                    {
                        return ((FSelectIncluded)m_fValueFormula).length;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.SelectIncludedR)
                    {
                        return ((FSelectIncludedR)m_fValueFormula).length;
                    }
                    return 0;
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
                    if (m_fValueFormula.fType == FValueFormulaType.Select)
                    {
                        ((FSelect)m_fValueFormula).length = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.SelectR)
                    {
                        ((FSelectR)m_fValueFormula).length = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.SelectIncluded)
                    {
                        ((FSelectIncluded)m_fValueFormula).length = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.SelectIncludedR)
                    {
                        ((FSelectIncludedR)m_fValueFormula).length = value;
                    }
                    replaceValueFormula(); 
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

        #region Substring Serise Parameter

        [Category(CategoryParameter)]
        public int SubStringStartIndex
        {
            get
            {
                try
                {
                    if (m_fValueFormula.fType == FValueFormulaType.SubString)
                    {
                        return ((FSubString)m_fValueFormula).startIndex;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.SubStringR)
                    {
                        return ((FSubStringR)m_fValueFormula).startIndex;
                    }
                    return 0;
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
                    if (m_fValueFormula.fType == FValueFormulaType.SubString)
                    {
                        ((FSubString)m_fValueFormula).startIndex = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.SubStringR)
                    {
                        ((FSubStringR)m_fValueFormula).startIndex = value;
                    }
                    replaceValueFormula(); 
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

        [Category(CategoryParameter)]
        public int SubStringLength
        {
            get
            {
                try
                {
                    if (m_fValueFormula.fType == FValueFormulaType.SubString)
                    {
                        return ((FSubString)m_fValueFormula).length;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.SubStringR)
                    {
                        return ((FSubStringR)m_fValueFormula).length;
                    }
                    return 0;
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
                    if (m_fValueFormula.fType == FValueFormulaType.SubString)
                    {
                        ((FSubString)m_fValueFormula).length = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.SubStringR)
                    {
                        ((FSubStringR)m_fValueFormula).length = value;
                    }
                    replaceValueFormula(); 
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

        #region SelectArray Serise Parameter

        [Category(CategoryParameter)]
        public int SelectArrayStartIndex
        {
            get
            {
                try
                {
                    if (m_fValueFormula.fType == FValueFormulaType.SelectArray)
                    {
                        return ((FSelectArray)m_fValueFormula).startIndex;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.SelectArrayR)
                    {
                        return ((FSelectArrayR)m_fValueFormula).startIndex;
                    }
                    return 0;
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
                    if (m_fValueFormula.fType == FValueFormulaType.SelectArray)
                    {
                        ((FSelectArray)m_fValueFormula).startIndex = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.SelectArrayR)
                    {
                        ((FSelectArrayR)m_fValueFormula).startIndex = value;
                    }
                    replaceValueFormula(); 
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

        [Category(CategoryParameter)]
        public int SelectArrayLength
        {
            get
            {
                try
                {
                    if (m_fValueFormula.fType == FValueFormulaType.SelectArray)
                    {
                        return ((FSelectArray)m_fValueFormula).length;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.SelectArrayR)
                    {
                        return ((FSelectArrayR)m_fValueFormula).length;
                    }
                    return 0;
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
                    if (m_fValueFormula.fType == FValueFormulaType.SelectArray)
                    {
                        ((FSelectArray)m_fValueFormula).length = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.SelectArrayR)
                    {
                        ((FSelectArrayR)m_fValueFormula).length = value;
                    }
                    replaceValueFormula(); 
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

        #region Subffix Parameter

        [Category(CategoryParameter)]
        public string SuffixSuffixString
        {
            get
            {
                try
                {
                    if (m_fValueFormula.fType == FValueFormulaType.Suffix)
                    {
                        return ((FSuffix)m_fValueFormula).suffixString;
                    }
                    return string.Empty;
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
                    if (m_fValueFormula.fType == FValueFormulaType.Suffix)
                    {
                        ((FSuffix)m_fValueFormula).suffixString = value;
                    }
                    replaceValueFormula(); 
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

        #region Trim Serise Parameter

        [Category(CategoryParameter)]
        public string TrimTrimString
        {
            get
            {
                try
                {
                    if (m_fValueFormula.fType == FValueFormulaType.Trim)
                    {
                        return ((FTrim)m_fValueFormula).trimString;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.TrimStart)
                    {
                        return ((FTrimStart)m_fValueFormula).trimString;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.TrimEnd)
                    {
                        return ((FTrimEnd)m_fValueFormula).trimString;
                    }
                    return string.Empty;
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
                    if (m_fValueFormula.fType == FValueFormulaType.Trim)
                    {
                        ((FTrim)m_fValueFormula).trimString = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.TrimStart)
                    {
                        ((FTrimStart)m_fValueFormula).trimString = value;
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.TrimEnd)
                    {
                        ((FTrimEnd)m_fValueFormula).trimString = value;
                    }
                    replaceValueFormula(); 
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

        #region Add Parameter

        [Category(CategoryParameter)]
        public string AddValue
        {
            get
            {
                try
                {
                    if (m_fValueFormula.fType == FValueFormulaType.Add)
                    {
                        return ((FAdd)m_fValueFormula).addValue;
                    }
                    return string.Empty;
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
                    if (m_fValueFormula.fType == FValueFormulaType.Add)
                    {
                        #region Validation

                        if (m_fValueTransformer.fFormat == FFormat.Binary ||
                                m_fValueTransformer.fFormat == FFormat.I8 ||
                                m_fValueTransformer.fFormat == FFormat.I4 ||
                                m_fValueTransformer.fFormat == FFormat.I2 ||
                                m_fValueTransformer.fFormat == FFormat.I1)
                        {
                            long v = 0;
                            if (!long.TryParse(value, out v))
                            {
                                FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                            }
                        }
                        else if (m_fValueTransformer.fFormat == FFormat.F8)
                        {
                            double v = 0;
                            if (!double.TryParse(value, out v))
                            {
                                FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                            }
                        }
                        else if (m_fValueTransformer.fFormat == FFormat.F4)
                        {
                            float v = 0;
                            if (!float.TryParse(value, out v))
                            {
                                FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                            }
                        }
                        else if (m_fValueTransformer.fFormat == FFormat.U8 ||
                                 m_fValueTransformer.fFormat == FFormat.U4 ||
                                 m_fValueTransformer.fFormat == FFormat.U2 ||
                                 m_fValueTransformer.fFormat == FFormat.U1)
                        {
                            ulong v = 0;
                            if (!ulong.TryParse(value, out v))
                            {
                                FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                            }
                        }

                        #endregion

                        // --

                        ((FAdd)m_fValueFormula).addValue = value;
                    }
                    replaceValueFormula();
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

        #region Subtract Parameter

        [Category(CategoryParameter)]
        public string SubtractValue
        {
            get
            {
                try
                {
                    if (m_fValueFormula.fType == FValueFormulaType.Subtract)
                    {
                        return ((FSubtract)m_fValueFormula).subtractValue;
                    }
                    return string.Empty;
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
                    if (m_fValueFormula.fType == FValueFormulaType.Subtract)
                    {
                        #region Validation

                        if (m_fValueTransformer.fFormat == FFormat.Binary ||
                                m_fValueTransformer.fFormat == FFormat.I8 ||
                                m_fValueTransformer.fFormat == FFormat.I4 ||
                                m_fValueTransformer.fFormat == FFormat.I2 ||
                                m_fValueTransformer.fFormat == FFormat.I1)
                        {
                            long v = 0;
                            if (!long.TryParse(value, out v))
                            {
                                FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                            }
                        }
                        else if (m_fValueTransformer.fFormat == FFormat.F8)
                        {
                            double v = 0;
                            if (!double.TryParse(value, out v))
                            {
                                FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                            }
                        }
                        else if (m_fValueTransformer.fFormat == FFormat.F4)
                        {
                            float v = 0;
                            if (!float.TryParse(value, out v))
                            {
                                FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                            }
                        }
                        else if (m_fValueTransformer.fFormat == FFormat.U8 ||
                                 m_fValueTransformer.fFormat == FFormat.U4 ||
                                 m_fValueTransformer.fFormat == FFormat.U2 ||
                                 m_fValueTransformer.fFormat == FFormat.U1)
                        {
                            ulong v = 0;
                            if (!ulong.TryParse(value, out v))
                            {
                                FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                            }
                        }

                        #endregion

                        // --

                        ((FSubtract)m_fValueFormula).subtractValue = value;
                    }
                    replaceValueFormula();
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

        #region Multiply Parameter

        [Category(CategoryParameter)]
        public string MultiplyValue
        {
            get
            {
                try
                {
                    if (m_fValueFormula.fType == FValueFormulaType.Multiply)
                    {
                        return ((FMultiply)m_fValueFormula).multiplyValue;
                    }
                    return string.Empty;
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
                    if (m_fValueFormula.fType == FValueFormulaType.Multiply)
                    {
                        #region Validation

                        if (m_fValueTransformer.fFormat == FFormat.Binary ||
                                m_fValueTransformer.fFormat == FFormat.I8 ||
                                m_fValueTransformer.fFormat == FFormat.I4 ||
                                m_fValueTransformer.fFormat == FFormat.I2 ||
                                m_fValueTransformer.fFormat == FFormat.I1)
                        {
                            long v = 0;
                            if (!long.TryParse(value, out v))
                            {
                                FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                            }
                        }
                        else if (m_fValueTransformer.fFormat == FFormat.F8)
                        {
                            double v = 0;
                            if (!double.TryParse(value, out v))
                            {
                                FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                            }
                        }
                        else if (m_fValueTransformer.fFormat == FFormat.F4)
                        {
                            float v = 0;
                            if (!float.TryParse(value, out v))
                            {
                                FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                            }
                        }
                        else if (m_fValueTransformer.fFormat == FFormat.U8 ||
                                 m_fValueTransformer.fFormat == FFormat.U4 ||
                                 m_fValueTransformer.fFormat == FFormat.U2 ||
                                 m_fValueTransformer.fFormat == FFormat.U1)
                        {
                            ulong v = 0;
                            if (!ulong.TryParse(value, out v))
                            {
                                FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                            }
                        }

                        #endregion

                        // --

                        ((FMultiply)m_fValueFormula).multiplyValue = value;
                    }
                    replaceValueFormula();
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

        #region Divide Parameter

        [Category(CategoryParameter)]
        public string DivideValue
        {
            get
            {
                try
                {
                    if (m_fValueFormula.fType == FValueFormulaType.Divide)
                    {
                        return ((FDivide)m_fValueFormula).divideValue;
                    }
                    return string.Empty;
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
                    if (m_fValueFormula.fType == FValueFormulaType.Divide)
                    {
                        #region Validation

                        if (m_fValueTransformer.fFormat == FFormat.Binary ||
                                m_fValueTransformer.fFormat == FFormat.I8 ||
                                m_fValueTransformer.fFormat == FFormat.I4 ||
                                m_fValueTransformer.fFormat == FFormat.I2 ||
                                m_fValueTransformer.fFormat == FFormat.I1)
                        {
                            long v = 0;
                            if (!long.TryParse(value, out v))
                            {
                                FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                            }
                        }
                        else if (m_fValueTransformer.fFormat == FFormat.F8)
                        {
                            double v = 0;
                            if (!double.TryParse(value, out v))
                            {
                                FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                            }
                        }
                        else if (m_fValueTransformer.fFormat == FFormat.F4)
                        {
                            float v = 0;
                            if (!float.TryParse(value, out v))
                            {
                                FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                            }
                        }
                        else if (m_fValueTransformer.fFormat == FFormat.U8 ||
                                 m_fValueTransformer.fFormat == FFormat.U4 ||
                                 m_fValueTransformer.fFormat == FFormat.U2 ||
                                 m_fValueTransformer.fFormat == FFormat.U1)
                        {
                            ulong v = 0;
                            if (!ulong.TryParse(value, out v))
                            {
                                FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                            }
                        }

                        #endregion

                        // --

                        ((FDivide)m_fValueFormula).divideValue = value;
                    }
                    replaceValueFormula();
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

        #region Round Parameter

        [Category(CategoryParameter)]
        public int RoundDigits
        {
            get
            {
                try
                {
                    if (m_fValueFormula.fType == FValueFormulaType.Round)
                    {
                        return ((FRound)m_fValueFormula).digits;
                    }
                    return 0;
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
                    if (m_fValueFormula.fType == FValueFormulaType.Round)
                    {
                        ((FRound)m_fValueFormula).digits = value;
                    }
                    replaceValueFormula();
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

        #region Mod Parameter

        [Category(CategoryParameter)]
        public string ModValue
        {
            get
            {
                try
                {
                    if (m_fValueFormula.fType == FValueFormulaType.Mod)
                    {
                        return ((FMod)m_fValueFormula).modValue;
                    }
                    return string.Empty;
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
                    if (m_fValueFormula.fType == FValueFormulaType.Mod)
                    {
                        #region Validation

                        if (m_fValueTransformer.fFormat == FFormat.Binary ||
                                m_fValueTransformer.fFormat == FFormat.I8 ||
                                m_fValueTransformer.fFormat == FFormat.I4 ||
                                m_fValueTransformer.fFormat == FFormat.I2 ||
                                m_fValueTransformer.fFormat == FFormat.I1)
                        {
                            long v = 0;
                            if (!long.TryParse(value, out v))
                            {
                                FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                            }
                        }
                        else if (m_fValueTransformer.fFormat == FFormat.F8)
                        {
                            double v = 0;
                            if (!double.TryParse(value, out v))
                            {
                                FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                            }
                        }
                        else if (m_fValueTransformer.fFormat == FFormat.F4)
                        {
                            float v = 0;
                            if (!float.TryParse(value, out v))
                            {
                                FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                            }
                        }
                        else if (m_fValueTransformer.fFormat == FFormat.U8 ||
                                 m_fValueTransformer.fFormat == FFormat.U4 ||
                                 m_fValueTransformer.fFormat == FFormat.U2 ||
                                 m_fValueTransformer.fFormat == FFormat.U1)
                        {
                            ulong v = 0;
                            if (!ulong.TryParse(value, out v))
                            {
                                FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Value" }));
                            }
                        }

                        #endregion

                        // --

                        ((FMod)m_fValueFormula).modValue = value;
                    }
                    replaceValueFormula();
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

        #region String Count Parameter

        [Category(CategoryParameter)]
        public string StringCountCountString
        {
            get
            {
                try
                {
                    if (m_fValueFormula.fType == FValueFormulaType.StringCount)
                    {
                        return ((FStringCount)m_fValueFormula).countString;
                    }
                    return string.Empty;
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
                    if (m_fValueFormula.fType == FValueFormulaType.StringCount)
                    {
                        ((FStringCount)m_fValueFormula).countString = value;
                    }
                    replaceValueFormula();
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
        public FIValueTransformer fValueTransformer
        {
            get
            {
                try
                {
                    return m_fValueTransformer;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
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
                // ***
                // Display Name Attribute Set
                // ***
                base.fTypeDescriptor.properties["Type"].attributes.replace(new DisplayNameAttribute("Type"));

                // ***
                // Choose Serise Parameter Display Name Attribute Set
                // ***
                base.fTypeDescriptor.properties["ChooseStartString"].attributes.replace(new DisplayNameAttribute("Start String"));
                base.fTypeDescriptor.properties["ChooseStartPosition"].attributes.replace(new DisplayNameAttribute("Start Position"));
                base.fTypeDescriptor.properties["ChooseEndString"].attributes.replace(new DisplayNameAttribute("End String"));
                base.fTypeDescriptor.properties["ChooseEndPosition"].attributes.replace(new DisplayNameAttribute("End Position"));

                // ***
                // DateTime Parameter Display Name Attribute Set
                // ***
                base.fTypeDescriptor.properties["DateTimeFormat"].attributes.replace(new DisplayNameAttribute("Format"));

                // ***
                // FixLength Serise Parameter Display Name Attribute Set
                // ***
                base.fTypeDescriptor.properties["FixLengthLength"].attributes.replace(new DisplayNameAttribute("Length"));
                base.fTypeDescriptor.properties["FixLengthFixString"].attributes.replace(new DisplayNameAttribute("Fix String"));

                // ***
                // Insert Serise Parameter Display Name Attribute Set
                // ***
                base.fTypeDescriptor.properties["InsertStartIndex"].attributes.replace(new DisplayNameAttribute("Start Index"));
                base.fTypeDescriptor.properties["InsertValue"].attributes.replace(new DisplayNameAttribute("Value "));

                // ***
                // Pad Serise Parameter Display Name Attribute Set
                // ***
                base.fTypeDescriptor.properties["PadTotalWidth"].attributes.replace(new DisplayNameAttribute("Total Width"));
                base.fTypeDescriptor.properties["PadPadString"].attributes.replace(new DisplayNameAttribute("Pad String"));

                // ***
                // Prefix Parameter Display Name Attribute Set
                // ***
                base.fTypeDescriptor.properties["PrefixPrefixString"].attributes.replace(new DisplayNameAttribute("Prefix String"));

                // ***
                // Remove Serise Parameter Display Name Attribute Set
                // ***
                base.fTypeDescriptor.properties["RemoveStartIndex"].attributes.replace(new DisplayNameAttribute("Start Index"));
                base.fTypeDescriptor.properties["RemoveLength"].attributes.replace(new DisplayNameAttribute("Length"));

                // ***
                // Replace Parameter Display Name Attribute Set
                // ***
                base.fTypeDescriptor.properties["ReplaceOldValue"].attributes.replace(new DisplayNameAttribute("Old Value"));
                base.fTypeDescriptor.properties["ReplaceNewValue"].attributes.replace(new DisplayNameAttribute("New Value"));

                // ***
                // Select Serise Parameter Display Name Attribute Set
                // ***
                base.fTypeDescriptor.properties["SelectSelectString"].attributes.replace(new DisplayNameAttribute("Select String"));
                base.fTypeDescriptor.properties["SelectSelectPosition"].attributes.replace(new DisplayNameAttribute("Select Position"));
                base.fTypeDescriptor.properties["SelectLength"].attributes.replace(new DisplayNameAttribute("Length"));

                // ***
                // SubString Serise Parameter Display Name Attribute Set
                // ***
                base.fTypeDescriptor.properties["SubStringStartIndex"].attributes.replace(new DisplayNameAttribute("Start Index"));
                base.fTypeDescriptor.properties["SubStringLength"].attributes.replace(new DisplayNameAttribute("Length"));

                // ***
                // SelectArray Serise Parameter Display Name Attribute Set
                // ***
                base.fTypeDescriptor.properties["SelectArrayStartIndex"].attributes.replace(new DisplayNameAttribute("Start Index"));
                base.fTypeDescriptor.properties["SelectArrayLength"].attributes.replace(new DisplayNameAttribute("Length"));

                // ***
                // Suffix Parameter Display Name Attribute Set
                // ***
                base.fTypeDescriptor.properties["SuffixSuffixString"].attributes.replace(new DisplayNameAttribute("Suffix String"));

                // ***
                // Trim Serise Parameter Display Name Attribute Set
                // ***
                base.fTypeDescriptor.properties["TrimTrimString"].attributes.replace(new DisplayNameAttribute("Trim String"));

                // ***
                // Add Parameter Display Name Attribute Set
                // ***
                base.fTypeDescriptor.properties["AddValue"].attributes.replace(new DisplayNameAttribute("Add Value"));

                // ***
                // Subtract Parameter Display Name Attribute Set
                // ***
                base.fTypeDescriptor.properties["SubtractValue"].attributes.replace(new DisplayNameAttribute("Subtract Value"));

                // ***
                // Multiply Parameter Display Name Attribute Set
                // ***
                base.fTypeDescriptor.properties["MultiplyValue"].attributes.replace(new DisplayNameAttribute("Multiply Value"));

                // ***
                // Divide Parameter Display Name Attribute Set
                // ***
                base.fTypeDescriptor.properties["DivideValue"].attributes.replace(new DisplayNameAttribute("Divide Value"));

                // ***
                // Round Parameter Display Name Attribute Set
                // ***
                base.fTypeDescriptor.properties["RoundDigits"].attributes.replace(new DisplayNameAttribute("Round Digits"));

                // ***
                // Mod Parameter Display Name Attribute Set
                // ***
                base.fTypeDescriptor.properties["ModValue"].attributes.replace(new DisplayNameAttribute("Mod Value"));

                // ***
                // String Count Parameter Display Name Attribute Set
                // ***
                base.fTypeDescriptor.properties["StringCountCountString"].attributes.replace(new DisplayNameAttribute("Count String"));

                // --

                // ***
                // Type Default Value Attribute Set
                // ***
                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_fValueFormula.fType.ToString()));

                // --

                setValueFormulaParameter();
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

        private void setValueFormulaParameter(
            )
        {
            try
            {
                // ***
                // Parameter Browsable All Disable
                // ***
                base.fTypeDescriptor.properties["ChooseStartString"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["ChooseStartPosition"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["ChooseEndString"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["ChooseEndPosition"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["DateTimeFormat"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["FixLengthLength"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["FixLengthFixString"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["InsertStartIndex"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["InsertValue"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["PadTotalWidth"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["PadPadString"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["PrefixPrefixString"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["RemoveStartIndex"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["RemoveLength"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["ReplaceOldValue"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["ReplaceNewValue"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["SelectSelectString"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["SelectSelectPosition"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["SelectLength"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["SubStringStartIndex"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["SubStringLength"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["SelectArrayStartIndex"].attributes.replace(new BrowsableAttribute(false));
                base.fTypeDescriptor.properties["SelectArrayLength"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["SuffixSuffixString"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["TrimTrimString"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["AddValue"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["SubtractValue"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["MultiplyValue"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["DivideValue"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["RoundDigits"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["ModValue"].attributes.replace(new BrowsableAttribute(false));
                // --
                base.fTypeDescriptor.properties["StringCountCountString"].attributes.replace(new BrowsableAttribute(false));

                // --

                if (
                    m_fValueFormula.fType == FValueFormulaType.Choose ||
                    m_fValueFormula.fType == FValueFormulaType.ChooseR ||
                    m_fValueFormula.fType == FValueFormulaType.ChooseIncluded ||
                    m_fValueFormula.fType == FValueFormulaType.ChooseIncludedR
                    )
                {
                    base.fTypeDescriptor.properties["ChooseStartString"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["ChooseStartPosition"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["ChooseEndString"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["ChooseEndPosition"].attributes.replace(new BrowsableAttribute(true));

                    // --

                    if (m_fValueFormula.fType == FValueFormulaType.Choose)
                    {
                        base.fTypeDescriptor.properties["ChooseStartString"].attributes.replace(new DefaultValueAttribute(((FChoose)m_fValueFormula).startString));
                        base.fTypeDescriptor.properties["ChooseStartPosition"].attributes.replace(new DefaultValueAttribute(((FChoose)m_fValueFormula).startPosition));
                        base.fTypeDescriptor.properties["ChooseEndString"].attributes.replace(new DefaultValueAttribute(((FChoose)m_fValueFormula).endString));
                        base.fTypeDescriptor.properties["ChooseEndPosition"].attributes.replace(new DefaultValueAttribute(((FChoose)m_fValueFormula).endPosition));
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.ChooseR)
                    {
                        base.fTypeDescriptor.properties["ChooseStartString"].attributes.replace(new DefaultValueAttribute(((FChooseR)m_fValueFormula).startString));
                        base.fTypeDescriptor.properties["ChooseStartPosition"].attributes.replace(new DefaultValueAttribute(((FChooseR)m_fValueFormula).startPosition));
                        base.fTypeDescriptor.properties["ChooseEndString"].attributes.replace(new DefaultValueAttribute(((FChooseR)m_fValueFormula).endString));
                        base.fTypeDescriptor.properties["ChooseEndPosition"].attributes.replace(new DefaultValueAttribute(((FChooseR)m_fValueFormula).endPosition));                        
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.ChooseIncluded)
                    {
                        base.fTypeDescriptor.properties["ChooseStartString"].attributes.replace(new DefaultValueAttribute(((FChooseIncluded)m_fValueFormula).startString));
                        base.fTypeDescriptor.properties["ChooseStartPosition"].attributes.replace(new DefaultValueAttribute(((FChooseIncluded)m_fValueFormula).startPosition));
                        base.fTypeDescriptor.properties["ChooseEndString"].attributes.replace(new DefaultValueAttribute(((FChooseIncluded)m_fValueFormula).endString));
                        base.fTypeDescriptor.properties["ChooseEndPosition"].attributes.replace(new DefaultValueAttribute(((FChooseIncluded)m_fValueFormula).endPosition));                        
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.ChooseIncludedR)
                    {
                        base.fTypeDescriptor.properties["ChooseStartString"].attributes.replace(new DefaultValueAttribute(((FChooseIncludedR)m_fValueFormula).startString));
                        base.fTypeDescriptor.properties["ChooseStartPosition"].attributes.replace(new DefaultValueAttribute(((FChooseIncludedR)m_fValueFormula).startPosition));
                        base.fTypeDescriptor.properties["ChooseEndString"].attributes.replace(new DefaultValueAttribute(((FChooseIncludedR)m_fValueFormula).endString));
                        base.fTypeDescriptor.properties["ChooseEndPosition"].attributes.replace(new DefaultValueAttribute(((FChooseIncludedR)m_fValueFormula).endPosition));                        
                    }
                }
                else if (m_fValueFormula.fType == FValueFormulaType.DateTime)
                {
                    base.fTypeDescriptor.properties["DateTimeFormat"].attributes.replace(new BrowsableAttribute(true));

                    // --

                    base.fTypeDescriptor.properties["DateTimeFormat"].attributes.replace(new DefaultValueAttribute(((FDateTime)m_fValueFormula).format));
                }
                else if (m_fValueFormula.fType == FValueFormulaType.FixLength || m_fValueFormula.fType == FValueFormulaType.FixLengthR)
                {
                    base.fTypeDescriptor.properties["FixLengthLength"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["FixLengthFixString"].attributes.replace(new BrowsableAttribute(true));

                    // --

                    if (m_fValueFormula.fType == FValueFormulaType.FixLength)
                    {
                        base.fTypeDescriptor.properties["FixLengthLength"].attributes.replace(new DefaultValueAttribute(((FFixLength)m_fValueFormula).length));
                        base.fTypeDescriptor.properties["FixLengthFixString"].attributes.replace(new DefaultValueAttribute(((FFixLength)m_fValueFormula).fixString));
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.FixLengthR)
                    {
                        base.fTypeDescriptor.properties["FixLengthLength"].attributes.replace(new DefaultValueAttribute(((FFixLengthR)m_fValueFormula).length));
                        base.fTypeDescriptor.properties["FixLengthFixString"].attributes.replace(new DefaultValueAttribute(((FFixLengthR)m_fValueFormula).fixString));
                    }
                }
                else if (m_fValueFormula.fType == FValueFormulaType.Insert || m_fValueFormula.fType == FValueFormulaType.InsertR)
                {
                    base.fTypeDescriptor.properties["InsertStartIndex"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["InsertValue"].attributes.replace(new BrowsableAttribute(true));

                    // --

                    if (m_fValueFormula.fType == FValueFormulaType.Insert)
                    {
                        base.fTypeDescriptor.properties["InsertStartIndex"].attributes.replace(new DefaultValueAttribute(((FInsert)m_fValueFormula).startIndex));
                        base.fTypeDescriptor.properties["InsertValue"].attributes.replace(new DefaultValueAttribute(((FInsert)m_fValueFormula).value));
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.InsertR)
                    {
                        base.fTypeDescriptor.properties["InsertStartIndex"].attributes.replace(new DefaultValueAttribute(((FInsertR)m_fValueFormula).startIndex));
                        base.fTypeDescriptor.properties["InsertValue"].attributes.replace(new DefaultValueAttribute(((FInsertR)m_fValueFormula).value));
                    }
                }
                else if (m_fValueFormula.fType == FValueFormulaType.PadLeft || m_fValueFormula.fType == FValueFormulaType.PadRight)
                {
                    base.fTypeDescriptor.properties["PadTotalWidth"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["PadPadString"].attributes.replace(new BrowsableAttribute(true));

                    // --

                    if (m_fValueFormula.fType == FValueFormulaType.PadLeft)
                    {
                        base.fTypeDescriptor.properties["PadTotalWidth"].attributes.replace(new DefaultValueAttribute(((FPadLeft)m_fValueFormula).totalWidth));
                        base.fTypeDescriptor.properties["PadPadString"].attributes.replace(new DefaultValueAttribute(((FPadLeft)m_fValueFormula).padString));
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.PadRight)
                    {
                        base.fTypeDescriptor.properties["PadTotalWidth"].attributes.replace(new DefaultValueAttribute(((FPadRight)m_fValueFormula).totalWidth));
                        base.fTypeDescriptor.properties["PadPadString"].attributes.replace(new DefaultValueAttribute(((FPadRight)m_fValueFormula).padString));
                    }
                }
                else if (m_fValueFormula.fType == FValueFormulaType.Prefix)
                {
                    base.fTypeDescriptor.properties["PrefixPrefixString"].attributes.replace(new BrowsableAttribute(true));

                    // --

                    base.fTypeDescriptor.properties["PrefixPrefixString"].attributes.replace(new DefaultValueAttribute(((FPrefix)m_fValueFormula).prefixString));
                }
                else if (m_fValueFormula.fType == FValueFormulaType.Remove || m_fValueFormula.fType == FValueFormulaType.RemoveR)
                {
                    base.fTypeDescriptor.properties["RemoveStartIndex"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["RemoveLength"].attributes.replace(new BrowsableAttribute(true));

                    // --

                    if (m_fValueFormula.fType == FValueFormulaType.Remove)
                    {
                        base.fTypeDescriptor.properties["RemoveStartIndex"].attributes.replace(new DefaultValueAttribute(((FRemove)m_fValueFormula).startIndex));
                        base.fTypeDescriptor.properties["RemoveLength"].attributes.replace(new DefaultValueAttribute(((FRemove)m_fValueFormula).length));
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.RemoveR)
                    {
                        base.fTypeDescriptor.properties["RemoveStartIndex"].attributes.replace(new DefaultValueAttribute(((FRemoveR)m_fValueFormula).startIndex));
                        base.fTypeDescriptor.properties["RemoveLength"].attributes.replace(new DefaultValueAttribute(((FRemoveR)m_fValueFormula).length));
                    }
                }
                else if (m_fValueFormula.fType == FValueFormulaType.Replace)
                {
                    base.fTypeDescriptor.properties["ReplaceOldValue"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["ReplaceNewValue"].attributes.replace(new BrowsableAttribute(true));

                    // --

                    base.fTypeDescriptor.properties["ReplaceOldValue"].attributes.replace(new DefaultValueAttribute(((FReplace)m_fValueFormula).oldValue));
                    base.fTypeDescriptor.properties["ReplaceNewValue"].attributes.replace(new DefaultValueAttribute(((FReplace)m_fValueFormula).newValue));
                }
                else if (
                    m_fValueFormula.fType == FValueFormulaType.Select ||
                    m_fValueFormula.fType == FValueFormulaType.SelectR ||
                    m_fValueFormula.fType == FValueFormulaType.SelectIncluded ||
                    m_fValueFormula.fType == FValueFormulaType.SelectIncludedR
                    )
                {
                    base.fTypeDescriptor.properties["SelectSelectString"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["SelectSelectPosition"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["SelectLength"].attributes.replace(new BrowsableAttribute(true));

                    // --

                    if (m_fValueFormula.fType == FValueFormulaType.Select)
                    {
                        base.fTypeDescriptor.properties["SelectSelectString"].attributes.replace(new DefaultValueAttribute(((FSelect)m_fValueFormula).selectString));
                        base.fTypeDescriptor.properties["SelectSelectPosition"].attributes.replace(new DefaultValueAttribute(((FSelect)m_fValueFormula).selectPosition));
                        base.fTypeDescriptor.properties["SelectLength"].attributes.replace(new DefaultValueAttribute(((FSelect)m_fValueFormula).length));
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.SelectR)
                    {
                        base.fTypeDescriptor.properties["SelectSelectString"].attributes.replace(new DefaultValueAttribute(((FSelectR)m_fValueFormula).selectString));
                        base.fTypeDescriptor.properties["SelectSelectPosition"].attributes.replace(new DefaultValueAttribute(((FSelectR)m_fValueFormula).selectPosition));
                        base.fTypeDescriptor.properties["SelectLength"].attributes.replace(new DefaultValueAttribute(((FSelectR)m_fValueFormula).length));
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.SelectIncluded)
                    {
                        base.fTypeDescriptor.properties["SelectSelectString"].attributes.replace(new DefaultValueAttribute(((FSelectIncluded)m_fValueFormula).selectString));
                        base.fTypeDescriptor.properties["SelectSelectPosition"].attributes.replace(new DefaultValueAttribute(((FSelectIncluded)m_fValueFormula).selectPosition));
                        base.fTypeDescriptor.properties["SelectLength"].attributes.replace(new DefaultValueAttribute(((FSelectIncluded)m_fValueFormula).length));
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.SelectIncludedR)
                    {
                        base.fTypeDescriptor.properties["SelectSelectString"].attributes.replace(new DefaultValueAttribute(((FSelectIncludedR)m_fValueFormula).selectString));
                        base.fTypeDescriptor.properties["SelectSelectPosition"].attributes.replace(new DefaultValueAttribute(((FSelectIncludedR)m_fValueFormula).selectPosition));
                        base.fTypeDescriptor.properties["SelectLength"].attributes.replace(new DefaultValueAttribute(((FSelectIncludedR)m_fValueFormula).length));
                    }
                }
                else if (m_fValueFormula.fType == FValueFormulaType.SubString || m_fValueFormula.fType == FValueFormulaType.SubStringR)
                {
                    base.fTypeDescriptor.properties["SubStringStartIndex"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["SubStringLength"].attributes.replace(new BrowsableAttribute(true));

                    // --

                    if (m_fValueFormula.fType == FValueFormulaType.SubString)
                    {
                        base.fTypeDescriptor.properties["SubStringStartIndex"].attributes.replace(new DefaultValueAttribute(((FSubString)m_fValueFormula).startIndex));
                        base.fTypeDescriptor.properties["SubStringLength"].attributes.replace(new DefaultValueAttribute(((FSubString)m_fValueFormula).length));
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.SubStringR)
                    {
                        base.fTypeDescriptor.properties["SubStringStartIndex"].attributes.replace(new DefaultValueAttribute(((FSubStringR)m_fValueFormula).startIndex));
                        base.fTypeDescriptor.properties["SubStringLength"].attributes.replace(new DefaultValueAttribute(((FSubStringR)m_fValueFormula).length));
                    }
                }
                else if (m_fValueFormula.fType == FValueFormulaType.SelectArray || m_fValueFormula.fType == FValueFormulaType.SelectArrayR)
                {
                    base.fTypeDescriptor.properties["SelectArrayStartIndex"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["SelectArrayLength"].attributes.replace(new BrowsableAttribute(true));

                    // --

                    if (m_fValueFormula.fType == FValueFormulaType.SelectArray)
                    {
                        base.fTypeDescriptor.properties["SelectArrayStartIndex"].attributes.replace(new DefaultValueAttribute(((FSelectArray)m_fValueFormula).startIndex));
                        base.fTypeDescriptor.properties["SelectArrayLength"].attributes.replace(new DefaultValueAttribute(((FSelectArray)m_fValueFormula).length));
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.SelectArrayR)
                    {
                        base.fTypeDescriptor.properties["SelectArrayStartIndex"].attributes.replace(new DefaultValueAttribute(((FSelectArrayR)m_fValueFormula).startIndex));
                        base.fTypeDescriptor.properties["SelectArrayLength"].attributes.replace(new DefaultValueAttribute(((FSelectArrayR)m_fValueFormula).length));
                    }
                }
                else if (m_fValueFormula.fType == FValueFormulaType.Suffix)
                {
                    base.fTypeDescriptor.properties["SuffixSuffixString"].attributes.replace(new BrowsableAttribute(true));

                    // --

                    base.fTypeDescriptor.properties["SuffixSuffixString"].attributes.replace(new DefaultValueAttribute(((FSuffix)m_fValueFormula).suffixString));
                    
                }
                else if (
                    m_fValueFormula.fType == FValueFormulaType.Trim ||
                    m_fValueFormula.fType == FValueFormulaType.TrimStart ||
                    m_fValueFormula.fType == FValueFormulaType.TrimEnd
                    )
                {
                    base.fTypeDescriptor.properties["TrimTrimString"].attributes.replace(new BrowsableAttribute(true));

                    // --

                    if (m_fValueFormula.fType == FValueFormulaType.Trim)
                    {
                        base.fTypeDescriptor.properties["TrimTrimString"].attributes.replace(new DefaultValueAttribute(((FTrim)m_fValueFormula).trimString));
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.TrimStart)
                    {
                        base.fTypeDescriptor.properties["TrimTrimString"].attributes.replace(new DefaultValueAttribute(((FTrimStart)m_fValueFormula).trimString));
                    }
                    else if (m_fValueFormula.fType == FValueFormulaType.TrimEnd)
                    {
                        base.fTypeDescriptor.properties["TrimTrimString"].attributes.replace(new DefaultValueAttribute(((FTrimEnd)m_fValueFormula).trimString));
                    }
                }
                else if (m_fValueFormula.fType == FValueFormulaType.Add)
                {
                    base.fTypeDescriptor.properties["AddValue"].attributes.replace(new BrowsableAttribute(true));

                    // --
                    base.fTypeDescriptor.properties["AddValue"].attributes.replace(new DefaultValueAttribute(((FAdd)m_fValueFormula).addValue));
                }
                else if (m_fValueFormula.fType == FValueFormulaType.Subtract)
                {
                    base.fTypeDescriptor.properties["SubtractValue"].attributes.replace(new BrowsableAttribute(true));

                    // --
                    base.fTypeDescriptor.properties["SubtractValue"].attributes.replace(new DefaultValueAttribute(((FSubtract)m_fValueFormula).subtractValue));
                }
                else if (m_fValueFormula.fType == FValueFormulaType.Multiply)
                {
                    base.fTypeDescriptor.properties["MultiplyValue"].attributes.replace(new BrowsableAttribute(true));

                    // --
                    base.fTypeDescriptor.properties["MultiplyValue"].attributes.replace(new DefaultValueAttribute(((FMultiply)m_fValueFormula).multiplyValue));
                }
                else if (m_fValueFormula.fType == FValueFormulaType.Divide)
                {
                    base.fTypeDescriptor.properties["DivideValue"].attributes.replace(new BrowsableAttribute(true));

                    // --
                    base.fTypeDescriptor.properties["DivideValue"].attributes.replace(new DefaultValueAttribute(((FDivide)m_fValueFormula).divideValue));
                }
                else if (m_fValueFormula.fType == FValueFormulaType.Round)
                {
                    base.fTypeDescriptor.properties["RoundDigits"].attributes.replace(new BrowsableAttribute(true));

                    // --
                    base.fTypeDescriptor.properties["RoundDigits"].attributes.replace(new DefaultValueAttribute(((FRound)m_fValueFormula).digits));
                }
                else if (m_fValueFormula.fType == FValueFormulaType.Mod)
                {
                    base.fTypeDescriptor.properties["ModValue"].attributes.replace(new BrowsableAttribute(true));

                    // --
                    base.fTypeDescriptor.properties["ModValue"].attributes.replace(new DefaultValueAttribute(((FMod)m_fValueFormula).modValue));
                }
                else if (m_fValueFormula.fType == FValueFormulaType.StringCount)
                {
                    base.fTypeDescriptor.properties["StringCountCountString"].attributes.replace(new BrowsableAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["StringCountCountString"].attributes.replace(new DefaultValueAttribute(((FStringCount)m_fValueFormula).countString));
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

        private void replaceValueFormula(
            )
        {
            try
            {
                m_fValueTransformer.replaceValueFormula(m_dataRow.Index, m_fValueFormula);                
                // --
                m_dataRow.Tag = m_fValueFormula;
                m_dataRow.SetCellValue("Value Formula", m_fValueFormula.ToString());                
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
