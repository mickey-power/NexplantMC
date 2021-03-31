/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FValueTransformer.cs
--  Creator         : spike.lee
--  Create Date     : 2011.08.02
--  Description     : FAMate Core FaSecsDriver Value Transformer Base Class 
--  History         : Created by spike.lee at 2011.08.02
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public abstract class FValueTransformerBase : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FValueTransformerBase(                    
            )            
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FValueTransformerBase(
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

        public abstract FFormat fFormat
        {
            get;            
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canInsertBeforeValueFormula
        {
            get
            {
                FFormat fFormat;
                List<string> valueFormulaList = null;

                try
                {
                    fFormat = this.fFormat;
                    // --
                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                    {
                        return false;
                    }

                    // --

                    valueFormulaList = getValueFormulaList();
                    // --
                    if (valueFormulaList.Count == 0)
                    {
                        return false;
                    }

                    // --

                    return true;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canInsertAfterValueFormula
        {
            get
            {
                try
                {
                    return canInsertBeforeValueFormula;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canAppendValueFormula
        {
            get
            {
                FFormat fFormat;

                try
                {

                    fFormat = this.fFormat;
                    // --
                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canReplaceValueFormula
        {
            get
            {
                try
                {
                    return canInsertBeforeValueFormula;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canRemoveValueFormula
        {
            get
            {
                FFormat fFormat;
                List<string> valueFormulaList = null;

                try
                {

                    fFormat = this.fFormat;
                    // --
                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                    {
                        return false;
                    }

                    // --

                    valueFormulaList = getValueFormulaList();
                    // --
                    if (valueFormulaList.Count == 0)
                    {
                        return false;
                    }

                    // --

                    return true;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canRemoveAllValueFormula
        {
            get
            {
                FFormat fFormat;

                try
                {

                    fFormat = this.fFormat;
                    // --
                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        internal abstract List<string> getValueFormulaList(
            );

        //------------------------------------------------------------------------------------------------------------------------

        internal abstract void setValueFormulaList(
            List<string> valueFormulaList
            );

        //------------------------------------------------------------------------------------------------------------------------

        public override string ToString(
            )
        {
            List<string> valueFormulaList = null;
            StringBuilder info = null;

            try
            {
                valueFormulaList = getValueFormulaList();                

                // --

                info = new StringBuilder();
                foreach (string valueFormula in valueFormulaList)
                {
                    info.Append(FValueFormulaBase.createValueFormula(valueFormula).ToString());
                    info.Append(";");
                }

                // --

                return info.ToString();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                valueFormulaList = null;
                info = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void validateFormat(
            )
        {
            FFormat fFormat;

            try
            {
                fFormat = this.fFormat;

                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0006, fFormat.ToString() + " Format", "Value Formula"));
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

        private void validateValueFormula(
            FValueFormulaType fType
            )
        {
            FFormat fFormat;

            try
            {
                fFormat = this.fFormat;

                if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2 || fFormat == FFormat.Char)
                {
                    if (fType == FValueFormulaType.SelectArray ||
                        fType == FValueFormulaType.SelectArrayR ||
                        fType == FValueFormulaType.ToBit ||
                        fType == FValueFormulaType.Add ||
                        fType == FValueFormulaType.Subtract ||
                        fType == FValueFormulaType.Multiply ||
                        fType == FValueFormulaType.Divide ||
                        fType == FValueFormulaType.Round ||
                        fType == FValueFormulaType.Trunc ||
                        fType == FValueFormulaType.Ceil ||
                        fType == FValueFormulaType.Mod
                        )
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, fFormat.ToString() + " Format", fType.ToString() + " Formula"));
                    }
                }
                else
                {
                    if (fType != FValueFormulaType.SelectArray && 
                        fType != FValueFormulaType.SelectArrayR && 
                        fType != FValueFormulaType.ToBit && 
                        fType != FValueFormulaType.Add && 
                        fType != FValueFormulaType.Subtract && 
                        fType != FValueFormulaType.Multiply && 
                        fType != FValueFormulaType.Divide && 
                        fType != FValueFormulaType.Round &&
                        fType != FValueFormulaType.Trunc &&
                        fType != FValueFormulaType.Ceil &&
                        fType != FValueFormulaType.Mod &&
                        fType != FValueFormulaType.DateTimeTicks 
                        )
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, fFormat.ToString() + " Format", fType.ToString() + " Formula"));
                    }
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

        public FIValueFormula insertBeforeValueFormula(
            int index, 
            FIValueFormula fNewValueFormula
            )
        {
            List<string> valueFormulaList = null;

            try
            {
                validateFormat();
                validateValueFormula(fNewValueFormula.fType);

                // --

                valueFormulaList = getValueFormulaList();
                // --
                if (index < 0 || index >= valueFormulaList.Count)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0014, "Index"));
                }
                // --
                valueFormulaList.Insert(index, ((FValueFormulaBase)fNewValueFormula).getValue());
                setValueFormulaList(valueFormulaList);

                // --

                return fNewValueFormula;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                valueFormulaList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIValueFormula insertAfterValueFormula(
            int index,
            FIValueFormula fNewValueFormula
            )
        {
            List<string> valueFormulaList = null;

            try
            {
                validateFormat();
                validateValueFormula(fNewValueFormula.fType);

                // --

                valueFormulaList = getValueFormulaList();
                // --
                if (index < 0 || index >= valueFormulaList.Count)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0014, "Index"));
                }
                // --
                valueFormulaList.Insert(index + 1, ((FValueFormulaBase)fNewValueFormula).getValue());
                setValueFormulaList(valueFormulaList);

                // --

                return fNewValueFormula;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                valueFormulaList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIValueFormula appendValueFormula(
            FIValueFormula fNewValueFormula
            )
        {
            List<string> valueFormulaList = null;

            try
            {
                validateFormat();
                validateValueFormula(fNewValueFormula.fType);                

                // --

                valueFormulaList = getValueFormulaList();                
                valueFormulaList.Add(((FValueFormulaBase)fNewValueFormula).getValue());
                setValueFormulaList(valueFormulaList);

                // --
                return fNewValueFormula;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                valueFormulaList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIValueFormula replaceValueFormula(
            int index,
            FIValueFormula fNewValueFormula
            )
        {
            List<string> valueFormulaList = null;

            try
            {
                validateFormat();
                validateValueFormula(fNewValueFormula.fType);

                // --

                valueFormulaList = getValueFormulaList();
                // --
                if (index < 0 || index >= valueFormulaList.Count)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0014, "Index"));
                }
                // --
                valueFormulaList[index] = ((FValueFormulaBase)fNewValueFormula).getValue();
                setValueFormulaList(valueFormulaList);

                // --

                return fNewValueFormula;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                valueFormulaList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIValueFormula removeValueFormula(
            int index
            )
        {
            List<string> valueFormulaList = null;
            string valueFormula = string.Empty;

            try
            {
                validateFormat();

                // --

                valueFormulaList = getValueFormulaList();
                // --
                if (index < 0 || index >= valueFormulaList.Count)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0014, "Index"));
                }
                // --
                valueFormula = valueFormulaList[index];
                valueFormulaList.RemoveAt(index);
                setValueFormulaList(valueFormulaList);

                // --

                return FValueFormulaBase.createValueFormula(valueFormula);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                valueFormulaList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeAllValueFormula(
            )
        {
            try
            {
                validateFormat();

                // --

                setValueFormulaList(new List<string>());
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

        public FIValueFormula moveUpValueFormula(
            int index
            )
        {
            List<string> valueFormulaList = null;
            string valueFormula = string.Empty;

            try
            {
                validateFormat();

                // --

                valueFormulaList = getValueFormulaList();
                if (index <= 0 || index >= valueFormulaList.Count)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0014, "Index"));
                }

                // --

                valueFormula = valueFormulaList[index];                
                valueFormulaList.RemoveAt(index);                
                valueFormulaList.Insert(--index, valueFormula);
                setValueFormulaList(valueFormulaList);
                
                // --

                return FValueFormulaBase.createValueFormula(valueFormula);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                valueFormulaList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIValueFormula moveDownValueFormula(
            int index
            )
        {
            List<string> valueFormulaList = null;
            string valueFormula = string.Empty;

            try
            {
                validateFormat();

                // --

                valueFormulaList = getValueFormulaList();
                if (index < 0 || index >= valueFormulaList.Count - 1)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0014, "Index"));
                }

                // --

                valueFormula = valueFormulaList[index];
                valueFormulaList.RemoveAt(index);
                valueFormulaList.Insert(++index, valueFormula);
                setValueFormulaList(valueFormulaList);

                // --

                return FValueFormulaBase.createValueFormula(valueFormula);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                valueFormulaList = null;
            }
            return null;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
