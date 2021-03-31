/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FProgress.cs
--  Creator         : spike.lee
--  Create Date     : 2010.11.26
--  Description     : FAMate Core FaUIs Progress Dialog Control Class
--  History         : Created by spike.lee at 2010.11.26
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs
{
    public class FProgress : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private bool m_showed = false;
        private int m_left = 0;
        private int m_top = 0;
        private FThread m_fthdPrg = null;
        private FProgressDialog m_fPrgDialog = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FProgress(            
            )
        {
            
        }        

        //------------------------------------------------------------------------------------------------------------------------

        ~FProgress(
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
                    close();
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

        public bool showed
        {
            get
            {
                try
                {
                    return m_showed;
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

        public void show(
            Form owner
            )
        {
            try
            {
                if (m_showed)
                {
                    return;
                }

                // --

                m_left = (owner.Width - FProgressDialog.DialogWidth) / 2 + owner.Left;
                m_top = (owner.Height - FProgressDialog.DialogHeight) / 2 + owner.Top;

                // --

                m_fthdPrg = new FThread("FProgressThread");
                // --
                m_fthdPrg.ThreadStarted += new FThreadStartedEventHandler(m_fthdPrg_ThreadStarted);
                m_fthdPrg.ThreadStopped += new FThreadStoppedEventHandler(m_fthdPrg_ThreadStopped);
                m_fthdPrg.ThreadJobCalled += new FThreadJobCalledEventHandler(m_fthdPrg_ThreadJobCalled);
                m_fthdPrg.ThreadErrorRaised += new FThreadErrorRaisedEventHandler(m_fthdPrg_ThreadErrorRaised);
                // --
                m_fthdPrg.start();

                // --

                m_showed = true;
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

        public void close(
            )
        {
            try
            {
                if (!m_showed)
                {
                    return;
                }

                // --

                if (m_fthdPrg != null)
                {
                    m_fthdPrg.stop();
                    // --
                    m_fthdPrg.ThreadStarted -= new FThreadStartedEventHandler(m_fthdPrg_ThreadStarted);
                    m_fthdPrg.ThreadStopped -= new FThreadStoppedEventHandler(m_fthdPrg_ThreadStopped);
                    m_fthdPrg.ThreadJobCalled -= new FThreadJobCalledEventHandler(m_fthdPrg_ThreadJobCalled);
                    m_fthdPrg.ThreadErrorRaised -= new FThreadErrorRaisedEventHandler(m_fthdPrg_ThreadErrorRaised);
                    // --
                    m_fthdPrg.Dispose();
                    m_fthdPrg = null;
                }   
          
                // --

                m_showed = false;
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

        #region m_ftdPrg Object Event Handler

        private void m_fthdPrg_ThreadStarted(
            object sender,
            FThreadEventArgs e
            )
        {
            try
            {
                m_fPrgDialog = new FProgressDialog();
                m_fPrgDialog.Left = m_left;
                m_fPrgDialog.Top = m_top;
                m_fPrgDialog.Show();               
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fthdPrg_ThreadStopped(
            object sender, 
            FThreadEventArgs e
            )
        {
            try
            {
                if (m_fPrgDialog != null)
                {
                    m_fPrgDialog.Close();
                    m_fPrgDialog.Dispose();
                    m_fPrgDialog = null;
                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fthdPrg_ThreadJobCalled(
            object sender,
            FThreadEventArgs e
            )
        {
            try
            {
                Application.DoEvents();
                e.sleepThread(10);
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
        }        

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fthdPrg_ThreadErrorRaised(
            object sender, 
            FThreadErrorRaisedEventArgs e
            )
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(e.exception.ToString());
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
