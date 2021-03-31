/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FHostOpenTransaction.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.16
--  Description     : FAMate Core FaOpcDriver Host Open Transaction Class 
--  History         : Created by Jeff.Kim at 2013.07.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    internal class FHostOpenTransaction : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------
        
        private const string KeyFormat = "{0}-{1}";        // SessionID + TID

        // --

        private bool m_disposed = false;
        // --
        private FOpcDriver m_fOpcDriver = null;
        private int m_tranTimeout = 0;
        private List<string> m_tranKeyList = null;        
        private List<FHostDeviceDataMessageSentLog> m_tranLogList = null;
        private List<long> m_tranTickList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FHostOpenTransaction(             
            FOpcDriver fOpcDriver,
            int tranTimeout
            )
        {
            m_fOpcDriver = fOpcDriver;
            m_tranTimeout = tranTimeout;
            // --
            m_tranKeyList = new List<string>();            
            m_tranLogList = new List<FHostDeviceDataMessageSentLog>();
            m_tranTickList = new List<long>();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FHostOpenTransaction(
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
                    m_fOpcDriver = null;
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
            UInt32 tid
            )
        {
            try
            {
                return string.Format(KeyFormat, sessionId, tid);
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
            FHostDeviceDataMessageSentLog fLog
            )
        {
            try
            {
                m_tranKeyList.Add(makeKey(fLog.sessionId, fLog.tid));
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
            FHostDeviceDataMessageSentLog fLog
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

        public FHostDeviceDataMessageSentLog getTransaction(
            int sessionId,            
            UInt32 tid
            )
        {
            string key = string.Empty;

            try
            {
                key = makeKey(sessionId, tid);
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

        public FHostDeviceDataMessageSentLog getTimeoutTransaction(
            )
        {
            FHostDeviceDataMessageSentLog fLog = null;

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
