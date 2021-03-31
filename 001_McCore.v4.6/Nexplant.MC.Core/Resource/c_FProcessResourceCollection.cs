/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FProcessResourceCollection.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2013.03.06
--  Description     : FAMate Core FaCommon Process Resource Collection Class
--  History         : Created by jungyoul.moon at 2013.03.06
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    public class FProcessResourceCollection : IDisposable, IEnumerable 
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private Dictionary<string, FProcessResource> m_fProcResDict = null;
        private List<FProcessResource> m_fProcResList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FProcessResourceCollection(
            Dictionary<string, FProcessResource> fProcResDict,
            List<FProcessResource> fProcResList
            )
        {
            m_fProcResDict = fProcResDict;
            m_fProcResList = fProcResList;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FProcessResourceCollection(
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
                    m_fProcResDict = null;
                    m_fProcResList = null;
                }
            }

            m_disposed = true;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region IDisposable
        
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
                return new FProcessResourceCollectionEnumerator(this);
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
                    return m_fProcResList.Count;
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

        public FProcessResource this[int i]
        {
            get
            {
                try
                {
                    if (i < 0 || i >= m_fProcResList.Count)
                    {
                        return null;
                    }
                    return m_fProcResList[i];
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

        public FProcessResource this[string name]
        {
            get
            {
                try
                {
                    if (!m_fProcResDict.ContainsKey(name))
                    {
                        return null;
                    }
                    return m_fProcResDict[name];
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

        public object item(
            string name
            )
        {
            try
            {
                return this[name];
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

    } // Class end
} // Namespace end 
