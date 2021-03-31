/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FValueFormulaBase.cs
--  Creator         : spike.lee
--  Create Date     : 2011.02.25
--  Description     : FAMate Core FaTcpDriver Value Formula Base Class 
--  History         : Created by spike.lee at 2011.02.25
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    public abstract class FValueFormulaBase : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------        

        private bool m_disposed = false;
        // --

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FValueFormulaBase(            
            )
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FValueFormulaBase(
           )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected virtual void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {

                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region IDisposable 멤버

        public void Dispose(
            )
        {
            myDispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        internal abstract string getValue(
            );

        //------------------------------------------------------------------------------------------------------------------------

        internal static FIValueFormula createValueFormula(
            string valueFormula
            )
        {
            string[] unitList = null;
            FValueFormulaType fType;
            FIValueFormula fValueFormula = null;

            try
            {
                // ***
                // unitList
                // [0] : Value Formula Type
                // [1] ~ [n] : Value Formula Parameter
                // ***
                unitList = valueFormula.Split(FConstants.ValueFormulaUnitSeparator);

                // --

                fType = (FValueFormulaType)Enum.Parse(typeof(FValueFormulaType), unitList[0]);
                // --
                if (fType == FValueFormulaType.Choose)
                {
                    fValueFormula = new FChoose(unitList[1], int.Parse(unitList[2]), unitList[3], int.Parse(unitList[4]));
                }
                else if (fType == FValueFormulaType.ChooseR)
                {
                    fValueFormula = new FChooseR(unitList[1], int.Parse(unitList[2]), unitList[3], int.Parse(unitList[4]));
                }
                else if (fType == FValueFormulaType.ChooseIncluded)
                {
                    fValueFormula = new FChooseIncluded(unitList[1], int.Parse(unitList[2]), unitList[3], int.Parse(unitList[4]));
                }
                else if (fType == FValueFormulaType.ChooseIncludedR)
                {
                    fValueFormula = new FChooseIncludedR(unitList[1], int.Parse(unitList[2]), unitList[3], int.Parse(unitList[4]));
                }
                else if (fType == FValueFormulaType.DateTime)
                {
                    fValueFormula = new FDateTime(unitList[1]);
                }
                else if (fType == FValueFormulaType.FixLength)
                {
                    fValueFormula = new FFixLength(int.Parse(unitList[1]), unitList[2]);
                }
                else if (fType == FValueFormulaType.FixLengthR)
                {
                    fValueFormula = new FFixLengthR(int.Parse(unitList[1]), unitList[2]);
                }
                else if (fType == FValueFormulaType.Insert)
                {
                    fValueFormula = new FInsert(int.Parse(unitList[1]), unitList[2]);
                }
                else if (fType == FValueFormulaType.InsertR)
                {
                    fValueFormula = new FInsertR(int.Parse(unitList[1]), unitList[2]);
                }
                else if (fType == FValueFormulaType.PadLeft)
                {
                    fValueFormula = new FPadLeft(int.Parse(unitList[1]), unitList[2]);
                }
                else if (fType == FValueFormulaType.PadRight)
                {
                    fValueFormula = new FPadRight(int.Parse(unitList[1]), unitList[2]);
                }
                else if (fType == FValueFormulaType.Prefix)
                {
                    fValueFormula = new FPrefix(unitList[1]);
                }
                else if (fType == FValueFormulaType.Remove)
                {
                    fValueFormula = new FRemove(int.Parse(unitList[1]), int.Parse(unitList[2]));
                }
                else if (fType == FValueFormulaType.RemoveR)
                {
                    fValueFormula = new FRemoveR(int.Parse(unitList[1]), int.Parse(unitList[2]));
                }
                else if (fType == FValueFormulaType.Replace)
                {
                    fValueFormula = new FReplace(unitList[1], unitList[2]);
                }
                else if (fType == FValueFormulaType.Select)
                {
                    fValueFormula = new FSelect(unitList[1], int.Parse(unitList[2]), int.Parse(unitList[3]));
                }
                else if (fType == FValueFormulaType.SelectR)
                {
                    fValueFormula = new FSelectR(unitList[1], int.Parse(unitList[2]), int.Parse(unitList[3]));
                }
                else if (fType == FValueFormulaType.SelectIncluded)
                {
                    fValueFormula = new FSelectIncluded(unitList[1], int.Parse(unitList[2]), int.Parse(unitList[3]));
                }
                else if (fType == FValueFormulaType.SelectIncludedR)
                {
                    fValueFormula = new FSelectIncludedR(unitList[1], int.Parse(unitList[2]), int.Parse(unitList[3]));
                }
                else if (fType == FValueFormulaType.SelectArray)
                {
                    fValueFormula = new FSelectArray(int.Parse(unitList[1]), int.Parse(unitList[2]));
                }
                else if (fType == FValueFormulaType.SelectArrayR)
                {
                    fValueFormula = new FSelectArrayR(int.Parse(unitList[1]), int.Parse(unitList[2]));
                }
                else if (fType == FValueFormulaType.SubString)
                {
                    fValueFormula = new FSubString(int.Parse(unitList[1]), int.Parse(unitList[2]));
                }
                else if (fType == FValueFormulaType.SubStringR)
                {
                    fValueFormula = new FSubStringR(int.Parse(unitList[1]), int.Parse(unitList[2]));
                }
                else if (fType == FValueFormulaType.Suffix)
                {
                    fValueFormula = new FSuffix(unitList[1]);
                }
                else if (fType == FValueFormulaType.ToBit)
                {
                    fValueFormula = new FToBit();
                }
                else if (fType == FValueFormulaType.ToLower)
                {
                    fValueFormula = new FToLower();
                }
                else if (fType == FValueFormulaType.ToUpper)
                {
                    fValueFormula = new FToUpper();
                }
                else if (fType == FValueFormulaType.Trim)
                {
                    fValueFormula = new FTrim(unitList[1]);
                }
                else if (fType == FValueFormulaType.TrimAll)
                {
                    fValueFormula = new FTrimAll();
                }
                else if (fType == FValueFormulaType.TrimStart)
                {
                    fValueFormula = new FTrimStart(unitList[1]);
                }
                else if (fType == FValueFormulaType.TrimEnd)
                {
                    fValueFormula = new FTrimEnd(unitList[1]);
                }
                else if (fType == FValueFormulaType.Add)
                {
                    fValueFormula = new FAdd(unitList[1]);
                }
                else if (fType == FValueFormulaType.Subtract)
                {
                    fValueFormula = new FSubtract(unitList[1]);
                }
                else if (fType == FValueFormulaType.Multiply)
                {
                    fValueFormula = new FMultiply(unitList[1]);
                }
                else if (fType == FValueFormulaType.Divide)
                {
                    fValueFormula = new FDivide(unitList[1]);
                }
                else if (fType == FValueFormulaType.Round)
                {
                    fValueFormula = new FRound(int.Parse(unitList[1]));
                }
                else if (fType == FValueFormulaType.Trunc)
                {
                    fValueFormula = new FTrunc();
                }
                else if (fType == FValueFormulaType.Ceil)
                {
                    fValueFormula = new FCeil();
                }
                else if (fType == FValueFormulaType.Mod)
                {
                    fValueFormula = new FMod(unitList[1]);
                }
                else if (fType == FValueFormulaType.StringCount)
                {
                    fValueFormula = new FStringCount(unitList[1]);
                }
                else if (fType == FValueFormulaType.Length)
                {
                    fValueFormula = new FLength();
                }
                else if (fType == FValueFormulaType.DecimalToHex)
                {
                    fValueFormula = new FDecimalToHex();        // 2017.03.27 by spike.lee add 
                }
                else if (fType == FValueFormulaType.HexToDecimal)
                {
                    fValueFormula = new FHexToDecimal();        // 2017.03.27 by spike.lee add
                }

                return fValueFormula;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fValueFormula = null;
            }
            return null;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
