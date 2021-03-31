/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FManualEvent.cs
--  Creator         : spike.lee
--  Create Date     : 2013.11.11
--  Description     : FAMate Core FaCommon Manual Event Class
--  History         : Created by spike.lee at 2013.11.24
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Nexplant.MC.Core.FaCommon
{
    public class FManualEvent : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private bool m_locked = false;
        private ManualResetEvent m_event = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FManualEvent(
            )
        {
            m_event = new ManualResetEvent(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FManualEvent(
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
                    if (m_event != null)
                    {
                        m_event.Close();
                        m_event.Dispose();
                        m_event = null;
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

        public bool locked
        {
            get
            {
                try
                {
                    return m_locked;
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public bool tryWait(
            int time
            )
        {
            bool isWait = false;

            try
            {
                isWait = m_event.WaitOne(time);
                if (isWait)
                {
                    m_locked = true;
                }
                return isWait;
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

        public void set(
            )
        {
            try
            {
                m_locked = false;
                m_event.Set();
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

        public void reset(
            )
        {
            try
            {
                m_event.Reset();
                m_locked = false;
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
