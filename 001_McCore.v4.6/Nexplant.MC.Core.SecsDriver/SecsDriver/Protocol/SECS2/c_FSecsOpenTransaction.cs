/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecsOpenTransaction.cs
--  Creator         : spike.lee
--  Create Date     : 2011.10.19
--  Description     : FAMate Core FaSecsDriver SECS Open Transaction Class 
--  History         : Created by spike.lee at 2011.10.19
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal class FSecsOpenTransaction : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------
        
        private const string KeyFormat1 = "{0}-{1}-{2}";        // SessionID + Stream + Function (Ignore System Bytes 용)        
        private const string KeyFormat2 = "{0}-{1}-{2}-{3}";    // SessionID + Stream + Function + SystemBytes

        // --

        private bool m_disposed = false;
        // --
        private FSecsDriver m_fSecsDriver = null;
        private int m_t3Timeout = 0;
        private bool m_ignoreSystemBytes = false;
        private List<string> m_tranKeyList = null;        
        private List<FSecsDeviceDataMessageSentLog> m_tranLogList = null;
        private List<long> m_tranTickList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecsOpenTransaction(             
            FSecsDriver fSecsDriver,
            int t3Timeout,
            bool ignoreSystemBytes
            )
        {
            m_fSecsDriver = fSecsDriver;
            m_t3Timeout = t3Timeout;
            m_ignoreSystemBytes = ignoreSystemBytes;
            // --
            m_tranKeyList = new List<string>();            
            m_tranLogList = new List<FSecsDeviceDataMessageSentLog>();
            m_tranTickList = new List<long>();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSecsOpenTransaction(
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
                    m_fSecsDriver = null;
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
            int stream, 
            int function, 
            UInt32 systemBytes
            )
        {
            try
            {
                if (m_ignoreSystemBytes)
                {
                    return string.Format(KeyFormat1, sessionId, stream, function);
                }
                return string.Format(KeyFormat2, sessionId, stream, function, systemBytes);
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
            FSecsDeviceDataMessageSentLog fLog
            )
        {
            try
            {
                m_tranKeyList.Add(makeKey(fLog.sessionId, fLog.stream, fLog.function + 1, fLog.systemBytes));   // Function은 Secondary Message Funtion으로 설정
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
            FSecsDeviceDataMessageSentLog fLog
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

        public FSecsDeviceDataMessageSentLog getTransaction(
            int sessionId,
            int stream,
            int function,
            UInt32 systemBytes
            )
        {
            string key = string.Empty;

            try
            {
                key = makeKey(sessionId, stream, function, systemBytes);
                // --
                if (!m_tranKeyList.Contains(key))
                {
                    return null;
                }
                return m_tranLogList[m_tranKeyList.IndexOf(key)];

                //key = makeKey(sessionId, stream, function, systemBytes);
                //for (int i = 0; i < m_tranKeyList.Count; i++)
                //{
                //    if (key == m_tranKeyList[i])
                //    {
                //        return m_tranLogList[i];
                //    }
                //}
                //return null;
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

        public FSecsDeviceDataMessageSentLog getTimeoutTransaction(
            )
        {
            FSecsDeviceDataMessageSentLog fLog = null;

            try
            {
                if (m_tranTickList.Count == 0)
                {
                    return null;
                }

                // --

                if (FTickCount.timeout(m_tranTickList[0], m_t3Timeout))
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
