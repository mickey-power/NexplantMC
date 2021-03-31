/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSqlErrorCollectionEnumerator.cs
--  Creator         : spike.lee
--  Create Date     : 2013.02.25
--  Description     : FAMate Core FaCommon Database SQL Error Collection Enumerator Class
--  History         : Created by spike.lee at 2013.02.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    public class FSqlErrorCollectionEnumerator : IEnumerator, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        private int m_index = -1;
        // --
        private FSqlErrorCollection m_fSqlErrorCollection = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSqlErrorCollectionEnumerator(
            FSqlErrorCollection fSqlErrorCollection
            )
        {
            m_fSqlErrorCollection = fSqlErrorCollection;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSqlErrorCollectionEnumerator(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected void myDispose(
            bool disposing)
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    m_fSqlErrorCollection = null;
                }
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
                    return m_fSqlErrorCollection[m_index];
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
                m_index++;
                return (m_index < m_fSqlErrorCollection.count);
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

    } // Class end
} // Namespace end
