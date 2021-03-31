/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlNodeListEnumerator.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.27
--  Description     : FAMate Core FaCommon XML Node List Enumerator Class
--  History         : Created by spike.lee at 2010.12.27
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    public class FXmlNodeListEnumerator : IDisposable, IEnumerator
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FXmlNodeList m_fXmlNodeList = null;
        private int m_index = -1;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FXmlNodeListEnumerator(
            FXmlNodeList fXmlNodeList
            )
        {
            m_fXmlNodeList = fXmlNodeList;
        }
        
        //------------------------------------------------------------------------------------------------------------------------       

        ~FXmlNodeListEnumerator(
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
                    m_fXmlNodeList = null;                    
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

        #region IEnumerator 멤버

        public object Current
        {
            get
            {
                try
                {
                    return m_fXmlNodeList[m_index];
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

        //------------------------------------------------------------------------------------------------------------------------

        public bool MoveNext(
            )
        {
            try
            {
                return (++m_index < m_fXmlNodeList.count);
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

        //------------------------------------------------------------------------------------------------------------------------

        public void Reset(
            )
        {
            try
            {
                m_index = -1;
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
