/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FZipEntryCollection.cs
--  Creator         : mj.kim
--  Create Date     : 2011.09.09
--  Description     : FAMate Core FaCommon Zip Entry Collection class
--  History         : Created by mj.kim at 2011.09.09
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    public class FZipEntryCollection : IDisposable, IEnumerable 
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private Dictionary<string, FZipEntry> m_zipEntryDict = null;
        private List<FZipEntry> m_zipEntryList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FZipEntryCollection(
            Dictionary<string, FZipEntry> zipEntryDict,
            List<FZipEntry> zipEntryList
            )
        {
            m_zipEntryDict = zipEntryDict;
            m_zipEntryList = zipEntryList;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FZipEntryCollection(
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
                    m_zipEntryDict = null;
                    m_zipEntryList = null;
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
                return new FZipEntryCollectionEnumerator(this);
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
                    return m_zipEntryList.Count;
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

        public FZipEntry this[int i]
        {
            get
            {
                try
                {
                    if (i < 0 || i >= m_zipEntryList.Count)
                    {
                        return null;
                    }
                    return m_zipEntryList[i];
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

        public FZipEntry this[string name]
        {
            get
            {
                try
                {
                    if (!m_zipEntryDict.ContainsKey(name))
                    {
                        return null;
                    }
                    return m_zipEntryDict[name];
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
