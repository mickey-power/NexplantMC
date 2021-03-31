/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTidStorage.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.15
--  Description     : FAMate Core FaOpcDriver TID Storage Class 
--  History         : Created by Jeff.Kim at 2013.07.15
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    internal class FTidStorage : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string KeyFormat = "{0}-{1}-{2}";

        // --

        private bool m_disposed = false;
        // --
        private int m_maxKeepingCount = 100;
        private FCodeLock m_fCodeLock = null;
        private Dictionary<string, List<UInt32>> m_storage = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTidStorage(                        
            )
        {
            m_fCodeLock = new FCodeLock();
            m_storage = new Dictionary<string, List<UInt32>>();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FTidStorage(
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
                    m_storage = null;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private string makeKey(
            UInt64 hdvUniqueId, 
            UInt64 hsnUniqueId, 
            UInt64 hmgUniqueId
            )
        {
            try
            {
                return string.Format(KeyFormat, hdvUniqueId, hsnUniqueId, hmgUniqueId);
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

        //------------------------------------------------------------------------------------------------------------------------

        public void add(
            UInt64 hdvUniqueId, 
            UInt64 hsnUniqueId, 
            UInt64 hmgUniqueId,
            UInt32 tid
            )
        {
            string key = string.Empty;
            List<UInt32> tidList = null;
            int count = 0;

            try
            {
                m_fCodeLock.wait();

                // --

                key = makeKey(hdvUniqueId, hsnUniqueId, hmgUniqueId);
                // --        
                if (m_storage.ContainsKey(key))
                {
                    tidList = m_storage[key];
                    m_storage.Remove(key);
                }
                else
                {
                    tidList = new List<uint>();
                }
                tidList.Add(tid);
                m_storage.Add(key, tidList);

                // --

                // ***
                // Keeping된 SystemBytes가 maxKeepingCount를 초과할 경우, 초과된 개수만큼 제거
                // ***
                count = m_storage.Count - m_maxKeepingCount;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        m_storage.Remove(m_storage.Keys.First());
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tidList = null;

                m_fCodeLock.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void clear(
            )
        {
            try
            {
                m_fCodeLock.wait();

                // --

                m_storage.Clear();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fCodeLock.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool contains(
            UInt64 hdvUniqueId, 
            UInt64 hsnUniqueId, 
            UInt64 hmgUniqueId
            )
        {
            try
            {
                return m_storage.ContainsKey(makeKey(hdvUniqueId, hsnUniqueId, hmgUniqueId));
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

        public bool getTid(
            UInt64 hdvUniqueId,
            UInt64 hsnUniqueId,
            UInt64 hmgUniqueId,
            ref UInt32 tid
            )
        {
            string key = string.Empty;

            try
            {
                m_fCodeLock.wait();

                // --

                key = makeKey(hdvUniqueId, hsnUniqueId, hmgUniqueId);
                // --
                if (!m_storage.ContainsKey(key))
                {
                    return false;
                }
                
                // --

                tid = m_storage[key][0];
                m_storage[key].RemoveAt(0);
                // --
                if (m_storage[key].Count == 0)
                {
                    m_storage.Remove(key);
                }

                // --

                return true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fCodeLock.set();
            }
            return false;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
