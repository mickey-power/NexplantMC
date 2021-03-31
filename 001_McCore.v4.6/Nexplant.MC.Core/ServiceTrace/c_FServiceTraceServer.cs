/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FServiceTraceServer.cs
--  Creator         : spike.lee
--  Create Date     : 2011.09.16
--  Description     : FAMate Core FaCommon Service Trace Server Class
--  History         : Created by spike.lee at 2011.09.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Nexplant.MC.Core.FaCommon
{
    public class FServiceTraceServer : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        public event FServiceTraceErrorRaisedEventHandler ServiceTraceErrorRaised = null;

        private bool m_disposed = false;
        // --
        private string m_serviceName = string.Empty;
        private bool m_dateTimeUsed = false;
        private bool m_endStringUsed = false;
        private int m_messageSendPeriod = 1000;
        private string m_endString = "-";        
        // --
        private FServiceTraceMessageList m_fMessageList = null;
        private FStaticTimer m_fSendTimer = null;
        private FPipeServer m_fPipeServer = null;
        private FThread m_fThdMain = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FServiceTraceServer(
            string serviceName            
            ) 
            : this(serviceName, false, false)
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FServiceTraceServer(
            string serviceName,
            bool dataTimeUsed,
            bool endStringUsed
            )
        {
            m_serviceName = serviceName;
            m_dateTimeUsed = dataTimeUsed;
            m_endStringUsed = endStringUsed;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FServiceTraceServer(
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

        //------------------------------------------------------------------------------------------------------------------------        

        public bool dateTimeUsed
        {
            get
            {
                try
                {
                    return m_dateTimeUsed;
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

        //------------------------------------------------------------------------------------------------------------------------        

        public bool endStringUsed
        {
            get
            {
                try
                {
                    return m_endStringUsed;
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

        //------------------------------------------------------------------------------------------------------------------------        

        public string endString
        {
            get
            {
                try
                {
                    return m_endString;
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

            set
            {
                try
                {
                    endString = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        public int maxMessageCount
        {
            get
            {
                try
                {
                    return m_fMessageList.maxMessageCount;
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

            set
            {
                try
                {
                    m_fMessageList.maxMessageCount = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int messageSendPeriod
        {
            get
            {
                try
                {
                    // ***
                    // millisecond
                    // *** 
                    return m_messageSendPeriod;
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

            set
            {
                try
                {
                    if (value < 1)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0005, "Message Send Period"));
                    }

                    // --

                    // ***
                    // millisecond
                    // *** 
                    m_messageSendPeriod = value;                    
                    m_fSendTimer.restart(m_messageSendPeriod);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
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
                m_fMessageList = new FServiceTraceMessageList();
                
                // --

                m_fSendTimer = new FStaticTimer();
                m_fSendTimer.start(m_messageSendPeriod);                

                // --

                m_fPipeServer = new FPipeServer(m_serviceName);
                m_fPipeServer.PipeDataSendFailed += new FPipeDataSendFailedEventHandler(m_fPipeServer_PipeDataSendFailed);
                m_fPipeServer.PipeErrorRaised += new FPipeErrorRaisedEventHandler(m_fPipeServer_PipeErrorRaised);
                m_fPipeServer.start();

                // --

                m_fThdMain = new FThread("FServiceTraceServerMainThread");
                m_fThdMain.ThreadJobCalled += new FThreadJobCalledEventHandler(m_fThdMain_ThreadJobCalled);
                m_fThdMain.start();
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
                if (m_fThdMain != null)
                {
                    m_fThdMain.stop();
                    m_fThdMain.Dispose();
                    m_fThdMain.ThreadJobCalled -= new FThreadJobCalledEventHandler(m_fThdMain_ThreadJobCalled);
                    m_fThdMain = null;
                }

                // --

                if (m_fPipeServer != null)
                {
                    m_fPipeServer.stop();
                    m_fPipeServer.Dispose();
                    m_fPipeServer.PipeDataSendFailed -= new FPipeDataSendFailedEventHandler(m_fPipeServer_PipeDataSendFailed);
                    m_fPipeServer.PipeErrorRaised -= new FPipeErrorRaisedEventHandler(m_fPipeServer_PipeErrorRaised);
                    m_fPipeServer = null;
                }

                // --

                if (m_fSendTimer != null)
                {
                    m_fSendTimer.Dispose();
                    m_fSendTimer = null;
                }

                // --

                if (m_fMessageList != null)
                {
                    m_fMessageList.Dispose();
                    m_fMessageList = null;
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

        //------------------------------------------------------------------------------------------------------------------------

        public void sendMessage(
            string message
            )
        {
            StringBuilder sb = null;
            string dateTime = string.Empty;

            try
            {
                sb = new StringBuilder();

                // --

                if (m_dateTimeUsed)
                {
                    dateTime = "[" + FDataConvert.defaultNowDateTimeToString() + "] ";
                    foreach (string s in message.Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries))
                    {
                        sb.AppendLine(dateTime + s);
                    }
                }
                else
                {
                    sb.AppendLine(message);
                }

                if (m_endStringUsed)
                {
                    sb.AppendLine(m_endString);
                }

                // --

                m_fMessageList.add(new FServiceTraceMessage(Encoding.Default.GetBytes(sb.ToString())));
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

        public void sendMessage(
            FServiceTraceCategory fCategory, 
            string action, 
            string typeNamespace, 
            string typeName, 
            string functionName, 
            string message
            )
        {
            StringBuilder sb = null;

            try
            {
                sb = new StringBuilder();

                if (fCategory == FServiceTraceCategory.Information)
                {
                    sb.Append("Category=<I>, ");
                }
                else if (fCategory == FServiceTraceCategory.Warning)
                {
                    sb.Append("Category=<W>, ");
                }
                else
                {
                    sb.Append("Category=<E>, ");
                }

                // --

                sb.Append("Action=<" + action + ">, ");
                sb.Append("Namespace=<" + typeNamespace + ">, ");
                sb.Append("TypeName=<" + typeName + ">, ");
                sb.Append("Function=<" + functionName + ">");

                // --

                if (message != string.Empty)
                {
                    sb.Append(Environment.NewLine);
                    sb.Append("/* Addition Information */");
                    // --
                    sb.Append(Environment.NewLine);
                    sb.Append(message);
                }

                // --

                sendMessage(sb.ToString());
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

        public void sendMessage(
            FServiceTraceCategory fCategory, 
            string action, 
            Type type, 
            string functionName, 
            string message
            )
        {
            try
            {
                sendMessage(fCategory, action, type.Namespace, type.Name, functionName, message);
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

        private void transferMessage(
            )
        {
            FServiceTraceMessage[] fMessages = null;
            ArrayList data = null;
            

            try
            {
                fMessages = m_fMessageList.getMessageAll(true);
                if (fMessages == null)
                {
                    return;
                }

                // --

                data = new ArrayList();
                foreach (FServiceTraceMessage fMsg in fMessages)
                {
                    data.AddRange(fMsg.message);
                }                

                // --

                m_fPipeServer.send(
                    new FPipeSendData((byte[])data.ToArray(typeof(byte)))
                    );
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

        private void m_fPipeServer_PipeDataSendFailed(
            object sender, 
            FPipeDataSendFailedEventArgs e
            )
        {
            try
            {
                onServiceTraceErrorRaised(new FException(e.message));
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

        private void m_fPipeServer_PipeErrorRaised(
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

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fThdMain Object Event Handler

        private void m_fThdMain_ThreadJobCalled(
            object sender, 
            FThreadEventArgs e
            )
        {
            try
            {
                if (m_fPipeServer.fState == FPipeState.Connected && m_fSendTimer.elasped(true))
                {
                    transferMessage();
                    return;
                }

                e.sleepThread(1);
            }
            catch (Exception ex)
            {
                onServiceTraceErrorRaised(ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
