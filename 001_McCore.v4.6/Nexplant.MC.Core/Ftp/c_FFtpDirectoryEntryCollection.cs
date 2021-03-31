/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FFtpDirectoryCollection.cs
--  Creator         : baehyun seo
--  Create Date     : 2011.09.14
--  Description     : FAMate Core FaCommon FFtpDirectoryCollection class 
--  History         : Created by baehyun seo at 2011.09.14
----------------------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Collections;

namespace Nexplant.MC.Core.FaCommon
{
    public class FFtpDirectoryEntryCollection : IDisposable, IEnumerable
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        private Dictionary<string, FFtpDirectoryEntry> m_ftpDirectoryEntryDict = null;
        private List<FFtpDirectoryEntry> m_ftpDirectoryEntryList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FFtpDirectoryEntryCollection(
            Dictionary<string, FFtpDirectoryEntry> ftpDirectoryEntryDict,
            List<FFtpDirectoryEntry> ftpDirectoryEntryList
            )
        {
            m_ftpDirectoryEntryDict = ftpDirectoryEntryDict;
            m_ftpDirectoryEntryList = ftpDirectoryEntryList;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FFtpDirectoryEntryCollection(
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
                    m_ftpDirectoryEntryDict = null;
                    m_ftpDirectoryEntryList = null;
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
                return new FFtpDirectoryEntryEnumerator(this);
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
                    return m_ftpDirectoryEntryList.Count;
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

        public FFtpDirectoryEntry this[int i]
        {
            get
            {
                try
                {
                    if (i < 0 || i >= m_ftpDirectoryEntryList.Count)
                    {
                        return null;
                    }
                    return m_ftpDirectoryEntryList[i];
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

        public FFtpDirectoryEntry this[string name]
        {
            get
            {
                try
                {
                    if (!m_ftpDirectoryEntryDict.ContainsKey(name))
                    {
                        return null;
                    }
                    return m_ftpDirectoryEntryDict[name];
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