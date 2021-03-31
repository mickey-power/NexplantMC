/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlCore.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.24
--  Description     : FAMate Core FaCommon XML Core Class
--  History         : Created by spike.lee at 2010.12.24
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    internal class FXmlCore : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FCodeLock m_fCodeLock = null;
        private FXmlDocument m_fXmlDocument = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FXmlCore(
            FXmlDocument fXmlDocument
            )
        {
            m_fCodeLock = new FCodeLock();
            m_fXmlDocument = fXmlDocument;
        }

        //------------------------------------------------------------------------------------------------------------------------       

        ~FXmlCore(
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
                    if (m_fCodeLock != null)
                    {
                        m_fCodeLock.Dispose();
                        m_fCodeLock = null;
                    }
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

        public FXmlDocument xmlDocument
        {
            get
            {
                try
                {
                    return m_fXmlDocument;
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public void wait(
            )
        {
            try
            {
                m_fCodeLock.wait();
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

        public void set(
            )
        {
            try
            {
                m_fCodeLock.set();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------        

    }   // Class end
}   // Namespace end
