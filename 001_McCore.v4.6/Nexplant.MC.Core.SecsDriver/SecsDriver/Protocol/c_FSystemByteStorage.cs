/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSystemByteStorage.cs
--  Creator         : spike.lee
--  Create Date     : 2011.10.28
--  Description     : FAMate Core FaSecsDriver System Byte Storage Class 
--  History         : Created by spike.lee at 2011.10.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal class FSystemByteStorage : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string KeyFormat = "{0}-{1}-{2}"; // SecsDevice Unique ID + SecsSession Unique ID + Message Unique ID

        // --

        private bool m_disposed = false;
        // --
        private int m_maxKeepingCount = 100;
        private FCodeLock m_fCodeLock = null;
        
        // --

        // ***
        // 2014.09.16 by spike.lee
        // 동일한 Key로 다른 SystemBytes를 Add할 경우 기존 SystemBytes를 Update하는 문제가 발생함.
        // 동일한 Key로 다른 SystemBytes를 처리하기 위해 SystemBytes 영역을 List로 변경
        // ***
        private Dictionary<string, List<UInt32>> m_storage = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSystemByteStorage(                        
            )
        {
            m_fCodeLock = new FCodeLock();
            m_storage = new Dictionary<string, List<UInt32>>();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSystemByteStorage(
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
            UInt64 sdvUniqueId, 
            UInt64 ssnUniqueId, 
            UInt64 smgUniqueId
            )
        {
            try
            {
                return string.Format(KeyFormat, sdvUniqueId, ssnUniqueId, smgUniqueId);
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
            UInt64 sdvUniqueId,
            UInt64 ssnUniqueId,
            UInt64 smgUniqueId, 
            UInt32 systemBytes
            )
        {
            string key = string.Empty;
            List<UInt32> sbList = null;
            int count = 0;

            try
            {
                m_fCodeLock.wait();

                // --

                // ***
                // 2014.09.16 by spike.lee
                // 존재하는 Key의 SystemBytes를 Add할 경우,
                // m_storage에 마지막 데이터로 처리하기 위해 지우고 다시 등록하도록 수정
                // ***
                key = makeKey(sdvUniqueId, ssnUniqueId, smgUniqueId);
                // --
                if (m_storage.ContainsKey(key))
                {
                    sbList = m_storage[key];
                    m_storage.Remove(key);
                }
                else
                {
                    sbList = new List<UInt32>();                    
                }
                sbList.Add(systemBytes);
                m_storage.Add(key, sbList);                

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
                sbList = null;

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
            UInt64 sdvUniqueId,
            UInt64 ssnUniqueId,
            UInt64 smgUniqueId
            )
        {
            try
            {
                return m_storage.ContainsKey(
                    makeKey(sdvUniqueId, ssnUniqueId, smgUniqueId)
                    );
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

        public bool getSystemBytes(
            UInt64 sdvUniqueId,
            UInt64 ssnUniqueId,
            UInt64 smgUniqueId,
            ref UInt32 systemBytes
            )
        {
            string key = string.Empty;

            try
            {
                m_fCodeLock.wait();

                // --

                key = makeKey(sdvUniqueId, ssnUniqueId, smgUniqueId);
                // --
                if (!m_storage.ContainsKey(key))
                {
                    return false;
                }
                
                // --

                systemBytes = m_storage[key][0];                                
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
