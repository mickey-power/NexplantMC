/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPipeServer.cs
--  Creator         : spike.lee
--  Create Date     : 2011.09.16
--  Description     : FAMate Core FaCommon Pipe Server Class
--  History         : Created by spike.lee at 2011.09.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Pipes;
using Microsoft.Win32.SafeHandles;

namespace Nexplant.MC.Core.FaCommon
{
    public class FPipeServer : FIPipe, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        public event FPipeStateChangedEventHandler PipeStateChanged = null;
        public event FPipeDataReceivedEventHandler PipeDataReceived = null;
        public event FPipeDataSentEventHandler PipeDataSent = null;
        public event FPipeDataSendFailedEventHandler PipeDataSendFailed = null;
        public event FPipeErrorRaisedEventHandler PipeErrorRaised = null;

        private const int RecvBufferSize = 65535;
        private const int SendBufferSize = 65535;

        private bool m_disposed = false;
        // --       
        private string m_pipeName = "PipeServer";        
        private int m_retryConnectPeriod = 1000;
        private FPipeState m_fState = FPipeState.Closed;
        private bool m_started = false;
        // --
        private NamedPipeServerStream m_pipeServer = null;
        private FPipeFlag m_fPipeFlag = null;
        private byte[] m_recvBuf = null;        
        private FStaticTimer m_fRetryConnectTimer = null;        
        // --
        private FCodeLock m_fMainSync = null;
        private FCodeLock m_fDisconnectSync = null;
        private FPipeEventPusher m_fEventPusher = null;
        private FThread m_fThdMain = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPipeServer(
            string pipeName
            )
        {
            m_pipeName = pipeName;
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPipeServer(
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

        public FPipeType fPipeType
        {
            get
            {
                try
                {
                    return FPipeType.Server;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FPipeType.Server;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string pipeName
        {
            get
            {
                try
                {
                    return m_pipeName;
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

        public bool started
        {
            get
            {
                try
                {
                    return m_started;
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

        public int retryConnectPeriod
        {
            get
            {
                try
                {
                    // ***
                    // millisecond
                    // *** 
                    return m_retryConnectPeriod;
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
                    if (value < 0)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0005, "Retry Connect Period"));
                    }

                    // --

                    // ***
                    // millisecond
                    // *** 
                    m_retryConnectPeriod = value;
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

        public FPipeState fState
        {
            get
            {
                try
                {
                    return m_fState;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FPipeState.Closed;
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
                m_fMainSync = new FCodeLock();
                m_fDisconnectSync = new FCodeLock();
                m_fPipeFlag = new FPipeFlag();
                m_fRetryConnectTimer = new FStaticTimer();
                m_recvBuf = new byte[RecvBufferSize];
                // --
                m_fEventPusher = new FPipeEventPusher(this);
                // --
                m_fThdMain = new FThread("FPipeServerMainThread");
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
                stop();

                // --

                if (m_fEventPusher != null)
                {
                    m_fEventPusher.waitEventHandlingCompleted();
                    m_fEventPusher.Dispose();
                    m_fEventPusher = null;
                }

                // --

                if (m_fPipeFlag != null)
                {
                    m_fPipeFlag.Dispose();
                    m_fPipeFlag = null;
                }

                if (m_fRetryConnectTimer != null)
                {
                    m_fRetryConnectTimer.Dispose();
                    m_fRetryConnectTimer = null;
                }                

                // --

                if (m_fMainSync != null)
                {
                    m_fMainSync.Dispose();
                    m_fMainSync = null;
                }

                if (m_fDisconnectSync != null)
                {
                    m_fDisconnectSync.Dispose();
                    m_fDisconnectSync = null;
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

        private void changeState(
            FPipeState fState
            )
        {
            try
            {
                if (m_fState == fState)
                {
                    return;
                }
                // --
                m_fState = fState;
                m_fEventPusher.pushEvent(new FPipeStateChangedEventArgs(this, fState));
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

        private void pushDataSendFailedEvent(
            FPipeSendData fData,
            string message
            )
        {
            try
            {
                m_fEventPusher.pushEvent(new FPipeDataSendFailedEventArgs(this, fData, message));
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

        private void pushErrorEvent(
            Exception ex
            )
        {
            try
            {
                FDebug.writeLog(ex);
                // --
                m_fEventPusher.pushEvent(new FPipeErrorRaisedEventArgs(this, ex.Message, ex));
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

        public void start(
            )
        {
            FDebugLogArgs fLogArgs = null;

            try
            {
                m_fMainSync.wait();

                // --

                if (m_started)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0001, "Pipe Server"));
                }

                // --

                // ***
                // Debug Log Write about Pipe Monitor Server Start
                // ***
                fLogArgs = new FDebugLogArgs(FDebugLogCategory.Information, "PipeServerStart", this.GetType(), "start");
                fLogArgs.additionInfo = "PipeName=<" + m_pipeName + ">";
                FDebug.writeLog(fLogArgs);

                // --

                changeState(FPipeState.Opened);
                m_started = true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fLogArgs = null;
                m_fMainSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void stop(
            )
        {
            FDebugLogArgs fLogArgs = null;

            try
            {
                m_fMainSync.wait();

                // --

                if (!m_started)
                {
                    return;
                }

                // --

                termPipeServer();
                changeState(FPipeState.Closed);
                m_started = false;                

                // --

                // ***
                // Debug Log Write about Pipe Server Stop
                // ***
                fLogArgs = new FDebugLogArgs(FDebugLogCategory.Information, "PipeServerStop", this.GetType(), "stop");
                fLogArgs.additionInfo = "PipeName=<" + m_pipeName + ">";
                FDebug.writeLog(fLogArgs);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fLogArgs = null;
                m_fMainSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void send(
            FPipeSendData fData
            )
        {
            try
            {
                m_fMainSync.wait();

                // --

                // ***
                // 통신 상태가 Connected가 아닐 경우 오류 처리
                // ***
                if (m_fState != FPipeState.Connected)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0012, "State"));
                }  

                // --

                doSend(fData);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fMainSync.set();
            }        
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void termPipeServer(
            )
        {
            try
            {
                if (m_pipeServer == null)
                {
                    return;
                }
                m_pipeServer.Close();

                // -- 

                // ***
                // 비동기 작업 종료 대기
                // ***
                m_fPipeFlag.waitAllCompleted();

                // --

                m_pipeServer = null;                
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

        private void doConnect(
            )
        {
            bool isReconnect = false;

            try
            {
                m_fPipeFlag.beginConnect();

                // --

                m_pipeServer = new NamedPipeServerStream(
                    m_pipeName, 
                    PipeDirection.InOut, 
                    1, 
                    PipeTransmissionMode.Byte, 
                    PipeOptions.Asynchronous, 
                    RecvBufferSize, 
                    SendBufferSize
                    );
                m_pipeServer.BeginWaitForConnection(new AsyncCallback(doConnectCallback), this);
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
                else
                {
                    pushErrorEvent(ex);
                    isReconnect = true;
                }                
                m_fPipeFlag.endConnect();
            }
            finally
            {
                if (isReconnect)
                {
                    doReconnect();
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void doDisconnect(
            )
        {
            FDebugLogArgs fLogArgs = null;

            try
            {
                m_fDisconnectSync.wait();

                // --

                if (m_fPipeFlag.disconnected)
                {
                    return;
                }

                // --

                // ***
                // Debug Log Write about Pipe Server Disconnect
                // ***
                fLogArgs = new FDebugLogArgs(FDebugLogCategory.Information, "PipeServerDisconnect", this.GetType(), "doDisconnect");
                fLogArgs.additionInfo = "PipeName=<" + m_pipeName + ">";
                FDebug.writeLog(fLogArgs);      

                // -- 

                m_fPipeFlag.disconnected = true;
            }
            catch (Exception ex)
            {
                pushErrorEvent(ex);
            }
            finally
            {
                m_fDisconnectSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void doReconnect(
            )
        {
            try
            {
                // ***
                // Retry Connect Time Set
                // ***
                m_fRetryConnectTimer.start(m_retryConnectPeriod);

                // --

                termPipeServer();

                // -

                m_fPipeFlag.init();                
                changeState(FPipeState.Opened);
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

        private void doReceive(
            )
        {
            try
            {
                m_fPipeFlag.beginReceive();
                m_pipeServer.BeginRead(m_recvBuf, 0, m_recvBuf.Length, new AsyncCallback(doReceiveCallback), this);
            }
            catch (Exception ex)
            {
                if (ex is IOException)
                {
                    pushErrorEvent(ex);

                    // --

                    // ***
                    // Disconnect
                    // ***
                    doDisconnect();
                }
                else if (ex is ObjectDisposedException)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                }
                else
                {
                    pushErrorEvent(ex);
                }
                m_fPipeFlag.endReceive();
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void doSend(
            FPipeSendData fData
            )
        {
            try
            {
                m_fPipeFlag.beginSend();
                m_pipeServer.BeginWrite(fData.data, 0, fData.data.Length, new AsyncCallback(doSendCallback), fData);
            }
            catch (Exception ex)
            {
                if (ex is IOException)
                {
                    pushErrorEvent(ex);
                    pushDataSendFailedEvent(fData, ex.Message);

                    // --

                    // ***
                    // Disconnect
                    // ***
                    doDisconnect();
                }
                else if (ex is ObjectDisposedException)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                }
                else
                {
                    pushErrorEvent(ex);
                    pushDataSendFailedEvent(fData, ex.Message);
                }
                m_fPipeFlag.endSend();
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void doConnectCallback(
            IAsyncResult ar
            )
        {
            FDebugLogArgs fLogArgs = null;

            try
            {
                if (m_pipeServer == null)
                {
                    return;
                }

                // --

                m_pipeServer.EndWaitForConnection(ar);                     

                // --

                // ***
                // Debug Log Write about Pipe Server Connect
                // ***
                fLogArgs = new FDebugLogArgs(FDebugLogCategory.Information, "PipeServerConnect", this.GetType(), "doConnectCallback");
                fLogArgs.additionInfo = "PipeName=<" + m_pipeName + ">";
                FDebug.writeLog(fLogArgs);            
    
                // --

                changeState(FPipeState.Connected);
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
                else
                {
                    pushErrorEvent(ex);
                }                
            }
            finally
            {
                fLogArgs = null;
                m_fPipeFlag.endConnect();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void doReceiveCallback(
            IAsyncResult ar
            )
        {
            int length = 0;
            byte[] data = null;

            try
            {
                length = m_pipeServer.EndRead(ar);
                if (length == 0)
                {
                    doDisconnect();
                    return;
                }                

                // --

                data = new byte[length];
                Buffer.BlockCopy(m_recvBuf, 0, data, 0, length);
                m_fEventPusher.pushEvent(new FPipeDataReceivedEventArgs(this, data));                
            }
            catch (Exception ex)
            {
                if (ex is IOException)
                {
                    pushErrorEvent(ex);

                    // --

                    // ***
                    // Disconnect
                    // ***
                    doDisconnect();
                }
                else if (ex is ObjectDisposedException)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                }
                else
                {
                    pushErrorEvent(ex);
                }
            }
            finally
            {
                m_fPipeFlag.endReceive();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void doSendCallback(
            IAsyncResult ar
            )
        {
            FPipeSendData fData = null;

            try
            {
                fData = (FPipeSendData)ar.AsyncState;
                m_pipeServer.EndWrite(ar);
                m_fEventPusher.pushEvent(new FPipeDataSentEventArgs(this, fData));
            }
            catch (Exception ex)
            {
                if (ex is IOException)
                {
                    pushErrorEvent(ex);
                    pushDataSendFailedEvent(fData, ex.Message);

                    // --
                    
                    // ***
                    // Disconnect
                    // ***
                    doDisconnect();
                }
                else if (ex is ObjectDisposedException)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
                else
                {
                    pushErrorEvent(ex);
                    pushDataSendFailedEvent(fData, ex.Message);
                }     
            }
            finally
            {
                m_fPipeFlag.endSend();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onPipeStateChanged(
            FPipeEventArgsBase args
            )
        {
            try
            {
                if (PipeStateChanged != null)
                {
                    PipeStateChanged(this, (FPipeStateChangedEventArgs)args);
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

        internal void onPipeDataReceived(
            FPipeEventArgsBase args
            )
        {
            try
            {
                if (PipeDataReceived != null)
                {
                    PipeDataReceived(this, (FPipeDataReceivedEventArgs)args);
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

        internal void onPipeDataSent(
            FPipeEventArgsBase args
            )
        {
            try
            {
                if (PipeDataSent != null)
                {
                    PipeDataSent(this, (FPipeDataSentEventArgs)args);
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

        internal void onPipeDataSendFailed(
            FPipeEventArgsBase args
            )
        {
            try
            {
                if (PipeDataSendFailed != null)
                {
                    PipeDataSendFailed(this, (FPipeDataSendFailedEventArgs)args);
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

        internal void onPipeErrorRaised(
            FPipeEventArgsBase args
            )
        {
            try
            {
                if (PipeErrorRaised != null)
                {
                    PipeErrorRaised(this, (FPipeErrorRaisedEventArgs)args);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fThdMain Object Event Handler

        private void m_fThdMain_ThreadJobCalled(
            object sender, 
            FThreadEventArgs e
            )
        {
            bool waited = false;

            try
            {
                waited = m_fMainSync.tryWait(1);
                if (!waited)
                {
                    return;
                }

                // --

                if (m_fState == FPipeState.Opened)
                {
                    if (!m_fRetryConnectTimer.enabled || m_fRetryConnectTimer.elasped(false))
                    {
                        if (m_fPipeFlag.doConnectCompleted)
                        {
                            doConnect();
                            return;
                        }
                    }                    
                }
                else if (m_fState == FPipeState.Connected)
                {
                    if (m_fPipeFlag.disconnected)
                    {
                        doReconnect();
                        return;
                    }

                    // --

                    if (m_fPipeFlag.doReceiveCompleted)
                    {
                        doReceive();
                        return;
                    }                    
                }
                else if (m_fState == FPipeState.Closed)
                {

                }                

                // --

                e.sleepThread(1);
            }
            catch (Exception ex)
            {
                pushErrorEvent(ex);
            }
            finally
            {
                if (waited)
                {
                    m_fMainSync.set();
                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
