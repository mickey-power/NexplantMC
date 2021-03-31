/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FDataConversionExpression.cs
--  Creator         : spike.lee
--  Create Date     : 2012.03.06
--  Description     : FAMate Core FaSecsDriver Data Conversion Expression Class 
--  History         : Created by spike.lee at 2012.03.06
----------------------------------------------------------------------------------------------------------*/
using System;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public class FDataConversionExpression : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FFormat m_fFormat = FFormat.Ascii;
        private int m_operandIndex = 0;
        private FConversionMode m_conversionMode = FConversionMode.Value;
        private FComparisonMode m_comparisonMode = FComparisonMode.Value;
        private FOperation m_operation = FOperation.Equal;
        private string m_value = string.Empty;
        private string m_min = string.Empty;
        private string m_max = string.Empty;
        private string m_conversionValue = string.Empty;
        private string m_transformerExpression = string.Empty;

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

        public FFormat fFormat
        {
            get
            {
                try
                {
                    return m_fFormat;
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

        public string transformerExpression
        {
            get
            {
                try
                {
                    return m_transformerExpression;
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
            string[] allExprList = null;
            string[] dceUnitList = null;

            try
            {
                allExprList = expression.Split(FConstants.DataCovnersionExpressionSeparator);

                // ***
                // Initialize Transformer Expression
                // ***
                if (!string.IsNullOrWhiteSpace(allExprList[0]))
                {
                    m_transformerExpression = allExprList[0];
                }

                // --

                // ***
                // Initialize Data Conversion 
                // ***
                dceUnitList = allExprList[1].Split(FConstants.DataConversionUnitSeparator);
                
                // --
                
                m_comparisonMode = FEnumConverter.toComparisonMode(dceUnitList[0]);
                m_fFormat = FEnumConverter.toFormat(dceUnitList[1]);
                m_operandIndex = int.Parse(dceUnitList[2]);
                m_operation = FEnumConverter.toOperation(dceUnitList[3]);
                m_conversionMode = FEnumConverter.toConversionMode(dceUnitList[4]);
                
                // --

                if (m_conversionMode == FConversionMode.Value)
                {
                    m_value = dceUnitList[5];
                    m_conversionValue = dceUnitList[6];
                }
                else if (m_conversionMode == FConversionMode.Range)
                {
                    m_min = dceUnitList[5];
                    m_max = dceUnitList[6];
                    m_conversionValue = dceUnitList[7];
                }                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                allExprList = null;
                dceUnitList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal static FDataConversionExpression createDataConversionExpression(
            string expression
            )
        {
            try
            {
                return new FDataConversionExpression(expression);
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
 
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
