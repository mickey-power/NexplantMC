/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FStaticTimer.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.24
--  Description     : FAMate Core FaCommon FStaticTimer Class
--  History         : Created by spike.lee at 2010.12.24
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    public class FStaticTimer : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private int m_dueTime = 1000;   // Default 1 sec
        private bool m_enabled = false;
        private long m_ticks = 0;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FStaticTimer(            
            )
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FStaticTimer(
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

        public int dueTime
        {
            get
            {
                try
                {
                    return m_dueTime;
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

        public bool enabled
        {
            get
            {
                try
                {
                    return m_enabled;
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

        public void start(
            int dueTime
            )
        {
            try
            {
                if (m_enabled)
                {
                    return;
                }

                m_enabled = true;
                m_dueTime = dueTime;
                m_ticks = FTickCount.ticks;
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

        public void stop(
            )
        {
            try
            {
                if (!m_enabled)
                {
                    return;
                }

                m_ticks = 0;
                m_enabled = false;
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

        public void restart(
            )
        {
            try
            {
                restart(m_dueTime);
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

        public void restart(
            int dueTime
            )
        {
            try
            {
                if (m_enabled)
                {
                    stop();
                }
                start(dueTime);
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

        public bool elasped(
            bool autoRestart
            )
        {
            try
            {
                if (!m_enabled)
                {
                    return false;
                }

                if (FTickCount.timeout(m_ticks, m_dueTime))
                {
                    if (autoRestart)
                    {
                        m_ticks = FTickCount.addTicks(m_ticks, m_dueTime);
                    }
                    else
                    {
                        stop();
                    }
                    return true;
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

    }   // Class end
}   // Namespace end
