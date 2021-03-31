/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FDbNumber.cs
--  Creator         : byjeon
--  Create Date     : 2014.08.11
--  Description     : FAMate Core FaCommon Database Number Output Type Class
--  History         : Created by byjeon at 2014.08.11
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    public class FDbNumber : FIDbOutput, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        
        // -- 

        private string m_name = string.Empty;
        private double m_value = double.NaN;
        private int m_floating = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction 

        public FDbNumber(
            string name
            )
            : this(name, "0")
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDbNumber(
            string name,
            string value,
            int floating = 0
            )
        {
            double tryVal = 0;
            m_name = name;
            m_value = double.TryParse(value, out tryVal) ? tryVal : 0;
            m_floating = floating;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FDbNumber(
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
            }
            m_disposed = true;
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

        public string name
        {
            get
            {
                try
                {
                    return m_name;
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
                    m_name = value;
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

        public FOutputType fType
        {
            get
            {
                try
                {
                    return FOutputType.Number;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FOutputType.Number;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public double value
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
                return 0;
            }

            set
            {
                try
                {
                    m_value = value;
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

        public string toString(
            )
        {
            try
            {
                return m_value.ToString("F" + m_floating);
            }
            catch(Exception ex)
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
    
    } // End Class
} // End Namespace
