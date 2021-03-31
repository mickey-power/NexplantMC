/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FInterceptingDataMessage.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.17
--  Description     : FAmate Converter FaSecs1ToHsms Intercepting Data Message Class
--  History         : Created by spike.lee at 2017.04.17
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecs1ToHsms
{
    public class FInterceptingDataMessage: IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private byte m_stream = 0;
        private byte m_function = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FInterceptingDataMessage(
            byte stream,
            byte function
            )
        {
            m_stream = stream;
            m_function = function;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FInterceptingDataMessage(
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

        public byte stream
        {
            get
            {
                try
                {
                    return m_stream;
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

        public byte function
        {
            get
            {
                try
                {
                    return m_function;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods        

        internal string getKey(
            )
        {
            const string KeyFormat = "{0}-{1}";

            try
            {
                return string.Format(KeyFormat, m_stream.ToString(), m_function.ToString());
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
