/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FFtpDirectoryEntryEnumerator.cs
--  Creator         : baehyun seo
--  Create Date     : 2011.09.14
--  Description     : FAMate Core FaCommon FFtpDirectoryEntryEnumerator class 
--  History         : Created by baehyun seo at 2011.09.14
----------------------------------------------------------------------------------------------------------*/

using System;
using System.Collections;

namespace Nexplant.MC.Core.FaCommon
{
    class FFtpDirectoryEntryEnumerator : IEnumerator, IDisposable
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        private int m_index = -1;
        // --
        private FFtpDirectoryEntryCollection m_ftpCollection = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FFtpDirectoryEntryEnumerator(
            FFtpDirectoryEntryCollection ftpCollection
            )
        {
            m_ftpCollection = ftpCollection;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FFtpDirectoryEntryEnumerator(
            )
        {

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
                    m_ftpCollection = null;
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
                    return m_ftpCollection[m_index];
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
                return (m_index < m_ftpCollection.count);
            }
            catch (System.Exception ex)
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
            catch (System.Exception ex)
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
