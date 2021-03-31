/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FDataConversionExpression.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2013.08.06
--  Description     : FAMate Core FaOpcDriver Data Conversion Expression Class 
--  History         : Created by jungyoul.moon at 2013.08.06
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    public class FDataConversionExpression : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private FComparisonMode m_comparisonMode = FComparisonMode.Value;
        private FFormat m_operandFormat = FFormat.Ascii;
        private int m_operandIndex = 0;
        private FConversionMode m_conversionMode = FConversionMode.Value;
        private FOperation m_operation = FOperation.Equal;
        private string m_value = string.Empty;
        private string m_min = string.Empty;
        private string m_max = string.Empty;
        private string m_conversionValue = string.Empty;
        private string m_valueTransformerExpression = string.Empty;

        private bool m_disposed = false;
        // --

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FDataConversionExpression(
            string expression
            )
        {
            init(expression);
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FDataConversionExpression(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected void myDispose(
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
        
        public FComparisonMode fComparisonMode
        {
            get
            {
                try
                {
                    return m_comparisonMode;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FComparisonMode.Value;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FFormat fOperandFormat
        {
            get
            {
                try
                {
                    return m_operandFormat;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FFormat.Ascii;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int operandIndex
        {
            get
            {
                try
                {
                    return m_operandIndex;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FConversionMode fConversionMode
        {
            get
            {
                try
                {
                    return m_conversionMode;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FConversionMode.Value;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOperation fOperation
        {
            get
            {
                try
                {
                    return m_operation;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FOperation.Equal;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string stringValue
        {
            get
            {
                try
                {
                    return m_value;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string min
        {
            get
            {
                try
                {
                    return m_min;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string max
        {
            get
            {
                try
                {
                    return m_max;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string conversionValue
        {
            get
            {
                try
                {
                    return m_conversionValue;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string valueTransformerExpression
        {
            get
            {
                try
                {
                    return m_valueTransformerExpression;
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            string expression
            )
        {
            string[] exList = null;
            string[] exUnitList = null;
            try
            {
                // --

                // Value Transformer Expression 과 Data Conversion Expression 분리
                // Dataconversion 에 걸려 있는 Value Transformer 가 있다면 먼져 수행
                exList = expression.Split(FConstants.DataCovnersionExpressionSeparator);
                if (exList[0] != string.Empty)
                {
                    m_valueTransformerExpression = exList[0];
                }

                // --

                exUnitList = exList[1].Split(FConstants.DataConversionUnitSeparator);
                // --
                m_comparisonMode = FEnumConverter.toComparisonMode(exUnitList[0]);
                m_operandFormat = FEnumConverter.toFormat(exUnitList[1]);
                m_operandIndex = int.Parse(exUnitList[2]);
                m_operation = FEnumConverter.toOperation(exUnitList[3]);
                m_conversionMode = FEnumConverter.toConversionMode(exUnitList[4]);
                if (m_conversionMode == FConversionMode.Value)
                {
                    m_value = exUnitList[5];
                    m_conversionValue = exUnitList[6];
                }
                else
                {
                    m_min = exUnitList[5];
                    m_max = exUnitList[6];
                    m_conversionValue = exUnitList[7];
                }                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                exList = null;
                exUnitList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal static FDataConversionExpression createDataConversionExpression(
            string expression
            )
        {
            FDataConversionExpression dataConExp = null;
            try
            {
                dataConExp = new FDataConversionExpression(expression);
                return dataConExp;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                dataConExp = null;
            }
            return null;
        }
 
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
