/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FGeneralCodeColumn.cs
--  Creator         : mjkim
--  Create Date     : 2012.03.21
--  Description     : FAMate Admin Manager General Code Column Class 
--  History         : Created by mjkim at 2012.03.21
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaSecsDriver;

namespace Nexplant.MC.AdminManager
{
    public class FGeneralCodeColumn : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private string m_prompt;
        private FGeneralCodeFormat m_format;
        private int m_size;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FGeneralCodeColumn(
            string prompt,
            string format,
            string size
            )
        {
            m_prompt = prompt;
            m_format = (FGeneralCodeFormat)Enum.Parse(typeof(FGeneralCodeFormat), format);
            m_size = int.Parse(size);
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FGeneralCodeColumn(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void myDispose(
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

        public string prt
        {
            get 
            {
                try
                {
                    return m_prompt;
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

            set
            {
                try
                {
                    m_prompt = value;
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

        public FGeneralCodeFormat fmt
        {
            get 
            {
                try
                {
                    return m_format;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
 
                }
                return FGeneralCodeFormat.Ascii;
            }

            set
            {
                try
                {
                    m_format = value;
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

        public int size
        {
            get 
            {
                try
                {
                    return m_size;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
 
                }
                return -1;
            }

            set
            {
                try
                {
                    m_size = value;
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

    }   //  Class end
}    // Namespace end
