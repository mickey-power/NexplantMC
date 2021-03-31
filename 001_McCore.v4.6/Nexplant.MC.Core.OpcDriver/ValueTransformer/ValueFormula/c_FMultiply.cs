/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FMultiply.cs
--  Creator         : jeff.kim
--  Create Date     : 2013.06.03
--  Description     : FAMate Core FaOpcDriver Multiply Formula Class 
--  History         : Created by jeff.kim at 2013.06.03
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    public class FMultiply : FValueFormulaBase, FIValueFormula
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        private string m_multiplyValue = "0";
        // --  

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FMultiply(            
            )
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FMultiply(
            string value
            )
        {
            m_multiplyValue = value;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FMultiply(
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

                }

                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FValueFormulaType fType
        {
            get
            {
                try
                {
                    return FValueFormulaType.Multiply;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FValueFormulaType.Multiply;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string multiplyValue
        {
            get
            {
                try
                {
                    return m_multiplyValue;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
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
                    if (value == "0")
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Subtract Value"));
                    }
                    // --
                    m_multiplyValue = value;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public override string ToString(
           )
        {
            const string Format = "{0}(\"{1}\")";

            try
            {
                return string.Format(Format, this.fType.ToString(), m_multiplyValue);
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

        //------------------------------------------------------------------------------------------------------------------------

        internal override string getValue(
            )
        {
            StringBuilder value = null;

            try
            {
                value = new StringBuilder();
                // --
                value.Append(this.fType.ToString());
                value.Append(FConstants.ValueFormulaUnitSeparator);
                value.Append(m_multiplyValue);                
                // --
                return value.ToString();
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
