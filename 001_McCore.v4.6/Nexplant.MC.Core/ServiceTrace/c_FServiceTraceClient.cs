/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FServiceTraceClient.cs
--  Creator         : spike.lee
--  Create Date     : 2011.09.16
--  Description     : FAMate Core FaCommon Service Trace Client Class
--  History         : Created by spike.lee at 2011.09.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    public class FServiceTraceClient : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        public event FServiceTraceMessageReceivedEventHandler ServiceTraceMessageReceived = null;
        public event FServiceTraceErrorRaisedEventHandler ServiceTraceErrorRaised = null;

        private bool m_disposed = false;
        // --
        private string m_serviceName = string.Empty;
        private FPipeClient m_fPipeClient = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FServiceTraceClient(
            string serviceName
            )
        {
            m_serviceName = serviceName;
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FServiceTraceClient(
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
                    term();
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

        public string serviceName
        {
            get
            {
                try
                {
                    return m_serviceName;
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods     

        private void init(
            )
        {
            try
            {
                m_fPipeClient = new FPipeClient(m_serviceName);
                m_fPipeClient.PipeDataReceived += new FPipeDataReceivedEventHandler(m_fPipeClient_PipeDataReceived);
                m_fPipeClient.PipeErrorRaised += new FPipeErrorRaisedEventHandler(m_fPipeClient_PipeErrorRaised);
                m_fPipeClient.start();
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

        private void term(
            )
        {
            try
            {
                if (m_fPipeClient != null)
                {
                    m_fPipeClient.stop();
                    m_fPipeClient.Dispose();
                    m_fPipeClient.PipeDataReceived -= new FPipeDataReceivedEventHandler(m_fPipeClient_PipeDataReceived);
                    m_fPipeClient = null;
                }
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

        private void onServiceTraceErrorRaised(
            Exception ex
            )
        {
            try
            {
                FDebug.writeLog(ex);
                // --
                if (ServiceTraceErrorRaised != null)
                {
                    ServiceTraceErrorRaised(this, new FServiceTraceErrorRaisedEventArgs(ex.Message, ex));
                }
            }
            catch (Exception ex1)
            {
                FDebug.writeLog(ex1);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fPipeClient Object Event Handler

        private void m_fPipeClient_PipeDataReceived(
            object sender, 
            FPipeDataReceivedEventArgs e
            )
        {
            string message = string.Empty;

            try
            {
                if (ServiceTraceMessageReceived != null)
                {
                    message = Encoding.Default.GetString(e.data);
                    ServiceTraceMessageReceived(this, new FServiceTraceMessageReceivedEventArgs(message));
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

        private void m_fPipeClient_PipeErrorRaised(
            object sender, 
            FPipeErrorRaisedEventArgs e
            )
        {
            try
            {
                onServiceTraceErrorRaised(e.exception);
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
