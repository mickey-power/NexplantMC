/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSqlErrorCollection.cs
--  Creator         : spike.lee
--  Create Date     : 2013.02.25
--  Description     : FAMate Core FaCommon Database SQL Error Collection Class
--  History         : Created by spike.lee at 2013.02.25
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    public class FSqlErrorCollection : IDisposable, IEnumerable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private List<FSqlError> m_fSqlErrorList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FSqlErrorCollection(
            List<FSqlError> fSqlErrorList
            )
        {
            m_fSqlErrorList = fSqlErrorList;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSqlErrorCollection(
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
                    m_fSqlErrorList = null;
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

        public IEnumerator GetEnumerator(
            )
        {
            try
            {
                return new FSqlErrorCollectionEnumerator(this);
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

        //------------------------------------------------------------------------------------------------------------------------

        public int count
        {
            get
            {
                try
                {
                    return m_fSqlErrorList.Count;
                }
                catch (System.Exception ex)
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

        public FSqlError this[int i]
        {
            get
            {
                try
                {
                    if (i < 0 || i >= m_fSqlErrorList.Count)
                    {
                        return null;
                    }
                    return m_fSqlErrorList[i];
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

        public object item(
            int index
            )
        {
            try
            {
                return this[index];
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

        //------------------------------------------------------------------------------------------------------------------------

        public bool containsErrorCode(
            int errorCode
            )
        {
            try
            {
                foreach (FSqlError ferr in m_fSqlErrorList)
                {
                    if (ferr.errorCode == errorCode)
                    {
                        return true;
                    }
                }
                return false;
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

        #endregion 

        //------------------------------------------------------------------------------------------------------------------------

    } // Class end
} // namespace end
