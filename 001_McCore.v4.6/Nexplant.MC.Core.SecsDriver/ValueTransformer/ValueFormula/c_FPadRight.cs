/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPadRight.cs
--  Creator         : spike.lee
--  Create Date     : 2011.02.21
--  Description     : FAMate Core FaSecsDriver Pad Right Formula Class 
--  History         : Created by spike.lee at 2011.02.21
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public class FPadRight : FValueFormulaBase, FIValueFormula
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private int m_totalWidth = 1;
        private string m_padString = " ";        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPadRight(            
            )
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FPadRight(
            int totalWidth,
            string padString
            )
        {
            m_totalWidth = totalWidth;
            m_padString = FValueConverter.fromStringValue(FFormat.Ascii, padString);
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPadRight(
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
                    return FValueFormulaType.PadRight;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FValueFormulaType.PadRight;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int totalWidth
        {
            get
            {
                try
                {
                    return m_totalWidth;
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
                    if (value < 1)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Total Width"));
                    }
                    // --
                    m_totalWidth = value;
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

        public string padString
        {
            get
            {
                try
                {
                    return m_padString;
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

            set
            {
                try
                {
                    if (value == string.Empty)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Pad String"));
                    }
                    // --
                    m_padString = FValueConverter.fromStringValue(FFormat.Ascii, value);
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
            const string Format = "{0}({1}, \"{2}\")";

            try
            {
                return string.Format(Format, this.fType.ToString(), m_totalWidth, m_padString);
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
                value.Append(m_totalWidth.ToString());
                value.Append(FConstants.ValueFormulaUnitSeparator);
                value.Append(m_padString);
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
