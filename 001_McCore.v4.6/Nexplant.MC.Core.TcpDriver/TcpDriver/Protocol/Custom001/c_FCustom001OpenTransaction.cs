/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FCustom001OpenTransaction.cs
--  Creator         : spike.lee
--  Create Date     : 2016.04.22
--  Description     : FAMate Core FaTcpDriver Custom001 Open Transaction Class 
--  History         : Created by spike.lee at 2016.04.22
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    internal class FCustom001OpenTransaction : IDisposable
    {
        
        //------------------------------------------------------------------------------------------------------------------------
        
        private const string KeyFormat = "{0}-{1}";        // SessionID + Reply Unique ID

        // --

        private bool m_disposed = false;
        // --
        private FTcpDriver m_fTcpDriver = null;
        private int m_tranTimeout = 0;
        private List<string> m_tranKeyList = null;        
        private List<FTcpDeviceDataMessageSentLog> m_tranLogList = null;
        private List<long> m_tranTickList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FCustom001OpenTransaction(             
            FTcpDriver fTcpDriver,
            int tranTimeout
            )
        {
            m_fTcpDriver = fTcpDriver;
            m_tranTimeout = tranTimeout;
            // --
            m_tranKeyList = new List<string>();            
            m_tranLogList = new List<FTcpDeviceDataMessageSentLog>();
            m_tranTickList = new List<long>();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FCustom001OpenTransaction(
           )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected virtual void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    m_fTcpDriver = null;
                    // --
                    m_tranKeyList = null;                    
                    m_tranLogList = null;
                    m_tranTickList = null;
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
            int sessionId, 
            UInt64 repUniqueId
            )
        {
            try
            {
                return string.Format(KeyFormat, sessionId, repUniqueId);
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

        public void openTransaction(
            FTcpDeviceDataMessageSentLog fLog,
            UInt64 repUniqueId
            )
        {
            try
            {
                m_tranKeyList.Add(makeKey(fLog.sessionId, repUniqueId));
                m_tranLogList.Add(fLog);
                m_tranTickList.Add(FTickCount.ticks);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void closeTransaction(
            FTcpDeviceDataMessageSentLog fLog
            )
        {
            int index = 0;

            try
            {
                if (!m_tranLogList.Contains(fLog))
                {
                    return;
                }                

                // --

                index = m_tranLogList.IndexOf(fLog);
                // --
                m_tranKeyList.RemoveAt(index);
                m_tranLogList.RemoveAt(index);
                m_tranTickList.RemoveAt(index);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
               
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpDeviceDataMessageSentLog getTransaction(
            int sessionId,
            UInt64 repUniqueId
            )
        {
            string key = string.Empty;

            try
            {
                key = makeKey(sessionId, repUniqueId);
                // --
                if (!m_tranKeyList.Contains(key))
                {
                    return null;
                }
                return m_tranLogList[m_tranKeyList.IndexOf(key)];
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

        public FTcpDeviceDataMessageSentLog getTimeoutTransaction(
            )
        {
            FTcpDeviceDataMessageSentLog fLog = null;

            try
            {
                if (m_tranTickList.Count == 0)
                {
                    return null;
                }

                // --

                if (FTickCount.timeout(m_tranTickList[0], m_tranTimeout))
                {
                    fLog = m_tranLogList[0];
                    // --
                    m_tranKeyList.RemoveAt(0);
                    m_tranLogList.RemoveAt(0);
                    m_tranTickList.RemoveAt(0);
                }                
                return fLog;
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

        public void clearTransaction(
            )
        {
            try
            {
                m_tranKeyList.Clear();
                m_tranLogList.Clear();
                m_tranTickList.Clear();
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
