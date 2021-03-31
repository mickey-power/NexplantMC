/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FChoose.cs
--  Creator         : spike.lee
--  Create Date     : 2011.02.21
--  Description     : FAMate Core FaOpcDriver Choose Formula Class 
--  History         : Created by spike.lee at 2011.02.21
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    public class FChoose : FValueFormulaBase, FIValueFormula
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private string m_startString = " ";
        private int m_startPosition = 0;
        private string m_endString = " ";
        private int m_endPosition = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FChoose(            
            )
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FChoose(
            string startString,
            int startPosition,
            string endString,
            int endPosition
            )
        {
            m_startString = FValueConverter.fromStringValue(FFormat.Ascii, startString);
            m_startPosition = startPosition;
            m_endString = FValueConverter.fromStringValue(FFormat.Ascii, endString);
            m_endPosition = endPosition;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FChoose(
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
                    return FValueFormulaType.Choose;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FValueFormulaType.Choose;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string startString
        {
            get
            {
                try
                {
                    return m_startString;
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
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Start String"));
                    }
                    // --
                    m_startString = FValueConverter.fromStringValue(FFormat.Ascii, value);
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

        public int startPosition
        {
            get
            {
                try
                {
                    return m_startPosition;
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
                    if (value < 0)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Start Position"));
                    }
                    // --
                    m_startPosition = value;
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

        public string endString
        {
            get
            {
                try
                {
                    return m_endString;
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
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "End String"));
                    }
                    // --
                    m_endString = FValueConverter.fromStringValue(FFormat.Ascii, value);
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

        public int endPosition
        {
            get
            {
                try
                {
                    return m_endPosition;
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
                    if (value < 0)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "End Position"));
                    }
                    // --
                    m_endPosition = value;
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
            const string Format = "{0}(\"{1}\", {2}, \"{3}\", {4})";

            try
            {
                return string.Format(Format, this.fType.ToString(), m_startString, m_startPosition, m_endString, m_endPosition);
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
                value.Append(m_startString);
                value.Append(FConstants.ValueFormulaUnitSeparator);
                value.Append(m_startPosition.ToString());
                value.Append(FConstants.ValueFormulaUnitSeparator);
                value.Append(m_endString);
                value.Append(FConstants.ValueFormulaUnitSeparator);
                value.Append(m_endPosition.ToString());
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
