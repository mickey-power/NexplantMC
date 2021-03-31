/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FFlagCollectionEnumerator.cs
--  Creator         : byjeon
--  Create Date     : 2013.12.02
--  Description     : FAMate UI WaferChart FFlagCollectionEnumerator Class
--  History         : Created by byjeon at 2013.12.02
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs
{
    internal class FFlagCollectionEnumerator : IEnumerator, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private int m_index = -1;
        private FFlagCollection m_fFlagCollection = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FFlagCollectionEnumerator(
            FFlagCollection fFlagCollection
            )
        {
            m_fFlagCollection = fFlagCollection;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FFlagCollectionEnumerator(
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
                    m_fFlagCollection = null;
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
                    return m_fFlagCollection[m_index];
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
                return ++m_index < m_fFlagCollection.count;
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

    } // End Class
} // End Namespace