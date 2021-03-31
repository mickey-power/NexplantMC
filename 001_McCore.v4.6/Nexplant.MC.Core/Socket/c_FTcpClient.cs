/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTcpClient.cs
--  Creator         : spike.lee
--  Create Date     : 2011.08.17
--  Description     : FAMate Core FaCommon TCP Client Class
--  History         : Created by spike.lee at 2011.08.17
                    : Modified by byjeon at 2013.04.29
                         - Add the routine that can be re-connected when specific socket exception occurred (ErrorCode : 10056)
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.InteropServices;

namespace Nexplant.MC.Core.FaCommon
{
    public class FTcpClient : FISocket, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        public event FTcpClientStateChangedEventHandler TcpClientStateChanged = null;
        public event FTcpClientDataReceivedEventHandler TcpClientDataReceived = null;
        public event FTcpClientDataSentEventHandler TcpClientDataSent = null;
        public event FTcpClientDataSendFailedEventHandler TcpClientDataSendFailed = null;
        public event FTcpClientErrorRaisedEventHandler TcpClientErrorRaised = null;

        private const int RecvBufferSize = 65535;
        private const int SendBufferSize = 65535;

        private bool m_disposed = false;
        // --
        private string m_localIp = string.Empty;
        private int m_localPort = 0;
        private string m_remoteIp = string.Empty;
        private int m_remotePort = 0;
        private int m_retryConnectPeriod = 1000;
        // --
        private FTcpClientMode m_fMode = FTcpClientMode.Client;
        private FTcpClientState m_fState = FTcpClientState.Closed;
        private TcpClient m_tcpClient = null;
        private FSocketFlag m_fSocketFlag = null;
        private NetworkStream m_networkStream = null;        
        private byte[] m_recvBuf = null;        
        private FStaticTimer m_fRetryConnectTimer = null;
        // --
        private FCodeLock m_fMainSync = null;
        private FCodeLock m_fDisconnectSync = null;
        private FSocketEventPusher m_fEventPusher = null;
        private FThread m_fThdMain = null;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTcpClient(
            string localIp,
            string remoteIp,
            int remotePort
            )
        {
            m_fMode = FTcpClientMode.Client;
            m_fState = FTcpClientState.Closed;
            // --
            m_localIp = localIp;
            m_localPort = 0;
            m_remoteIp = remoteIp;
            m_remotePort = remotePort;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FTcpClient(
            TcpClient tcpClient
            )
        {
            IPEndPoint ipEndPoint = null;

            m_fMode = FTcpClientMode.Server;
            m_fState = FTcpClientState.Connected;
            
            // --
            
            m_tcpClient = tcpClient;
            setSocketKeepAlive();
            // --
            m_tcpClient.ReceiveBufferSize = RecvBufferSize;
            m_tcpClient.SendBufferSize = SendBufferSize;
            // --
            m_networkStream = m_tcpClient.GetStream();

            // --
            
            ipEndPoint = (IPEndPoint)m_tcpClient.Client.LocalEndPoint;
            m_localIp = ipEndPoint.Address.ToString();
            m_localPort = ipEndPoint.Port;
            // --
            ipEndPoint = (IPEndPoint)m_tcpClient.Client.RemoteEndPoint;
            m_remoteIp = ipEndPoint.Address.ToString();
            m_remotePort = ipEndPoint.Port;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FTcpClient(
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

        public FSocketType fSocketType
        {
            get
            {
                try
                {
                    return FSocketType.Client;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FSocketType.Client;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpClientMode fMode
        {
            get
            {
                try
                {
                    return m_fMode;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FTcpClientMode.Client;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpClientState fState
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
                return FTcpClientState.Closed;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string localIp
        {
            get
            {
                try
                {
                    return m_localIp;
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

        public int localPort
        {
            get
            {
                try
                {
                    return m_localPort;
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

        public string remoteIp
        {
            get
            {
                try
                {
                    return m_remoteIp;
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

        public int remotePort
        {
            get
            {
                try
                {
                    return m_remotePort;
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

        public bool eventSuspended
        {
            get
            {
                try
                {
                    return m_fEventPusher.suspended;
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

        public bool receiveCompleted
        {
            get
            {
                try
                {
                    return m_fSocketFlag.doReceiveCompleted;
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

        public bool sendCompleted
        {
            get
            {
                try
                {
                    return m_fSocketFlag.doSendCompleted;
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

        private void changeState(
            FTcpClientState fState
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
                m_fEventPusher.pushEvent(
                    new FTcpClientStateChangedEventArgs(this, fState, m_localIp, m_localPort, m_remoteIp, m_remotePort)
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

        //------------------------------------------------------------------------------------------------------------------------

        private void pushDataSendFailedEvent(
            FSocketSendData fData, 
            string message
            )
        {
            try
            {
                m_fEventPusher.pushEvent(new FTcpClientDataSendFailedEventArgs(this, fData, message));                
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

        private void pushSocketErrorEvent(
            string function, 
            SocketException sckEx
            )
        {
            FDebugLogArgs fLogArgs = null;

            try
            {
                System.Diagnostics.Debug.WriteLine("SocketError=" + sckEx.SocketErrorCode.ToString());

                // --

                // ***
                // Debug Log Write about Socket Error Information
                // ***
                fLogArgs = new FDebugLogArgs(FDebugLogCategory.Exception, "SocketErrorRaised", this.GetType(), function);
                fLogArgs.additionInfo =
                    "Mode=<" + m_fMode.ToString() + ">, SocketErrorCode=<" + sckEx.SocketErrorCode.ToString() + ">" + Environment.NewLine +
                    sckEx.ToString();
                FDebug.writeLog(fLogArgs);
                // --
                m_fEventPusher.pushEvent(
                    new FTcpClientErrorRaisedEventArgs(this, sckEx.Message, sckEx)
                    );                
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                fLogArgs = null;
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
                m_fEventPusher.pushEvent(new FTcpClientErrorRaisedEventArgs(this, ex.Message, ex));                
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

        private void pushErrorEvent(
            string localIP,
            string remoteIP,
            Type funcType,
            string function,
            Exception ex
            )
        {
            FDebugLogArgs args = null;
            
            try
            {
                args = new FDebugLogArgs(FDebugLogCategory.Exception, "ExceptionTrace", funcType, function);
                args.additionInfo = "Information_LocalIP:Port=<" + localIP + "> RemoteIP:Port=<" + remoteIP + ">\n"
                                    + "Excetion=<" + ex.ToString() + ">";
                FDebug.writeLog(args);
                // --
                m_fEventPusher.pushEvent(new FTcpClientErrorRaisedEventArgs(this, ex.Message, ex));
            }
            catch (Exception ex1)
            {
                FDebug.writeLog(ex1);
            }
            finally
            {
                args = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void setSocketKeepAlive(
            )
        {
            uint dummy = 0;
            byte[] inValue = null;

            try
            {
                inValue = new byte[Marshal.SizeOf(dummy) * 3];
                BitConverter.GetBytes((uint)1).CopyTo(inValue, 0);
                BitConverter.GetBytes((uint)500).CopyTo(inValue, Marshal.SizeOf(dummy));
                BitConverter.GetBytes((uint)500).CopyTo(inValue, Marshal.SizeOf(dummy) * 2);

                // --

                m_tcpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
                m_tcpClient.Client.IOControl(IOControlCode.KeepAliveValues, inValue, null);
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

        private void init(
            )
        {
            try
            {
                m_fMainSync = new FCodeLock();
                m_fDisconnectSync = new FCodeLock();
                m_recvBuf = new byte[RecvBufferSize];
                m_fSocketFlag = new FSocketFlag();
                m_fRetryConnectTimer = new FStaticTimer();
                // --
                m_fEventPusher = new FSocketEventPusher(this, m_fMode == FTcpClientMode.Server ? true : false);                
                // --
                m_fThdMain = new FThread("FTcpClientMainThread");
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
                close();

                // --
                
                if (m_fEventPusher != null)
                {
                    m_fEventPusher.waitEventHandlingCompleted();
                    m_fEventPusher.Dispose();
                    m_fEventPusher = null;
                }

                // --
                
                if (m_fSocketFlag != null)
                {
                    m_fSocketFlag.Dispose();
                    m_fSocketFlag = null;
                }

                if (m_fRetryConnectTimer != null)
                {
                    m_fRetryConnectTimer.Dispose();
                    m_fRetryConnectTimer = null;
                }

                // --

                if (m_fDisconnectSync != null)
                {
                    m_fDisconnectSync.Dispose();
                    m_fDisconnectSync = null;
                }
                
                if (m_fMainSync != null)
                {
                    m_fMainSync.Dispose();
                    m_fMainSync = null;
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

        private void initTcpClient(
            )
        {
            try
            {
                termTcpClient();
                
                // --

                m_localPort = 0;
                m_tcpClient = new TcpClient(new IPEndPoint(Dns.GetHostAddresses(m_localIp)[0], m_localPort));
                m_tcpClient.ReceiveBufferSize = RecvBufferSize;
                m_tcpClient.SendBufferSize = SendBufferSize;

                // --

                m_fSocketFlag.init();
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

        private void termTcpClient(
            )
        {
            try
            {
                if (m_tcpClient == null)
                {
                    return;
                }

                // --

                // ***
                // Send Data 완료 대기
                // ***
                m_fSocketFlag.waitSendCompleted();
                m_tcpClient.Close();                

                // --

                // ***
                // 비동기 작업 완료 대기
                // ***
                m_fSocketFlag.waitAllCompleted();

                // --

                if (m_networkStream != null)
                {
                    m_networkStream.Dispose();
                    m_networkStream = null;
                }
                m_tcpClient = null;                
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

        public void connect(
            )
        {
            try
            {
                m_fMainSync.wait();

                // --

                // ***
                // FTcpClient가 Server Mode일 경우 connect를 실행할 수 없다.
                // ***
                if (m_fMode == FTcpClientMode.Server)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0009, "Server Mode", "Connect Method"));
                }

                // ***
                // FTcpClient 상태가 Closed가 아닐 경우 connect를 실행할 수 없다.
                // ***
                if (m_fState != FTcpClientState.Closed)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "State of TCP Client", "Closed"));
                }

                // --

                initTcpClient();
                changeState(FTcpClientState.Opened);                
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

        public void reconnect(
            )
        {
            try
            {
                m_fMainSync.wait();

                // --

                // ***
                // FTcpClient가 Server Mode일 경우 reconnect를 실행할 수 없다.
                // ***
                if (m_fMode == FTcpClientMode.Server)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0009, "Server Mode", "Reconnect Method"));
                }
                
                if (m_fState != FTcpClientState.Connected)
                {
                    return;
                }

                // --

                doReconnect();
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

        public void send(
            FSocketSendData fData
            )
        {
            try
            {
                m_fMainSync.wait();

                // --

                // ***
                // 통신 상태가 Connected가 아닐 경우 오류 처리
                // ***
                if (m_fState != FTcpClientState.Connected)
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

        public void close(
            )
        {
            try
            {
                m_fMainSync.wait();

                // --
                
                doClose();
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

        public void suspendEvent(
            )
        {
            try
            {
                m_fEventPusher.suspend();
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

        public void resumeEvent(
            )
        {
            try
            {
                m_fEventPusher.resume();
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

        private void doClose(
            )
        {
            FDebugLogArgs fLogArgs = null;

            try
            {
                if (m_fState == FTcpClientState.Closed)
                {
                    return;
                }

                // --
                
                termTcpClient();
                changeState(FTcpClientState.Closed);

                // --

                // ***
                // Debug Log Write about TCP Client Close
                // ***
                fLogArgs = new FDebugLogArgs(FDebugLogCategory.Information, "TcpClientClose", this.GetType(), "doClose");
                fLogArgs.additionInfo = "Mode=<" + m_fMode.ToString() + ">, LocalIP=<" + m_localIp + ">, LocalPort=<" + m_localPort.ToString() + ">, RemoteIP=<" + m_remoteIp + ">, RemotePort=<" + m_remotePort.ToString() + ">";
                FDebug.writeLog(fLogArgs);
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

                changeState(FTcpClientState.Opened);
                initTcpClient();                
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

        private void doDisconnect(
            )
        {
            FDebugLogArgs fLogArgs = null;

            try
            {
                m_fDisconnectSync.wait();

                // --

                if (m_fSocketFlag.disconnected)
                {
                    return;
                }

                // --

                // ***
                // Debug Log Write about Disconnection Information
                // ***
                fLogArgs = new FDebugLogArgs(FDebugLogCategory.Information, "TcpClientDisconnect", this.GetType(), "doDisconnect");
                fLogArgs.additionInfo = "Mode=<" + m_fMode.ToString() + ">, LocalIP=<" + m_localIp + ">, LocalPort=<" + m_localPort.ToString() + ">, RemoteIP=<" + m_remoteIp + ">, RemotePort=<" + m_remotePort.ToString() + ">";
                FDebug.writeLog(fLogArgs);

                // --

                m_fSocketFlag.disconnected = true;                
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

        private void doConnect(
            )
        {
            string local = string.Empty;
            string remote = string.Empty;
            try
            {
                m_fSocketFlag.beginConnect();
                m_tcpClient.BeginConnect(m_remoteIp, m_remotePort, new AsyncCallback(doConnectCallback), this);                
            }            
            catch (Exception ex)
            {
                if (ex is SocketException)
                {
                    if ((ex as SocketException).ErrorCode.Equals(10056))
                    {
                        close();
                    }

                    pushSocketErrorEvent("doConnect", (SocketException)ex);                
                }
                else if (ex is ObjectDisposedException)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
                else
                {
                    //pushErrorEvent(ex);
                    local = m_localIp + ":" + m_localPort.ToString();
                    remote = m_remoteIp + ":" + m_remotePort.ToString();
                    pushErrorEvent(local, remote, this.GetType(), "doConnect", ex);
                }                
                m_fSocketFlag.endConnect();

                // --
                
                // ***
                // [2012-06-07 by spike.lee]
                // Connect 오류 시, 연속적인 Connect 오류를 방지하기 위하여
                // Connect Delay 시간 설정
                // ***
                m_fRetryConnectTimer.start(m_retryConnectPeriod);
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
                if (m_tcpClient == null || m_tcpClient.Client == null)
                {
                    return;
                }

                // --

                m_tcpClient.EndConnect(ar);
                setSocketKeepAlive();
                // --
                m_networkStream = m_tcpClient.GetStream();
                // --
                m_localPort = ((IPEndPoint)m_tcpClient.Client.LocalEndPoint).Port;

                // --

                // ***
                // Debug Log Write about Connection Information
                // ***
                fLogArgs = new FDebugLogArgs(FDebugLogCategory.Information, "TcpClientConnect", this.GetType(), "doConnectCallback");
                fLogArgs.additionInfo = "Mode=<" + m_fMode.ToString() + ">, LocalIP=<" + m_localIp + ">, LocalPort=<" + m_localPort.ToString() + ">, RemoteIP=<" + m_remoteIp + ">, RemotePort=<" + m_remotePort.ToString() + ">";
                FDebug.writeLog(fLogArgs);

                // --

                changeState(FTcpClientState.Connected);
            }
            catch (Exception ex)
            {
                if (ex is SocketException)
                {
                    if (
                        ((SocketException)ex).SocketErrorCode == SocketError.ConnectionRefused ||
                        ((SocketException)ex).SocketErrorCode == SocketError.TimedOut
                        )
                    {
                        return;
                    }
                    else
                    {
                        pushSocketErrorEvent("doConnectCallback", (SocketException)ex);
                    }
                }
                else if (ex is ObjectDisposedException)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
                else
                {
                    pushErrorEvent(ex);
                }

                // --

                // ***
                // [2012-06-07 by spike.lee]
                // Connect 오류 시, 연속적인 Connect 오류를 방지하기 위하여
                // Connect Delay 시간 설정
                // ***
                m_fRetryConnectTimer.start(m_retryConnectPeriod);
            }            
            finally
            {
                fLogArgs = null;                
                m_fSocketFlag.endConnect();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void doReceive(
            )
        {
            try
            {
                m_fSocketFlag.beginReceive();
                m_networkStream.BeginRead(m_recvBuf, 0, m_recvBuf.Length, new AsyncCallback(doReceiveCallback), this);
            }
            catch (Exception ex)
            {
                if (ex is IOException)
                {
                    if (ex.InnerException is SocketException)
                    {
                        pushSocketErrorEvent("doReceive", (SocketException)ex.InnerException);

                        // --

                        // ***
                        // Disconnect
                        // ***
                        doDisconnect();
                    }
                    else if (ex.InnerException is ObjectDisposedException)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.InnerException.ToString());
                    }
                    else
                    {
                        pushErrorEvent(ex.InnerException == null ? ex : ex.InnerException);
                    }
                }
                else if (ex is ObjectDisposedException)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
                else
                {
                    pushErrorEvent(ex);
                }
                m_fSocketFlag.endReceive();
            }            
            finally
            {
                
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
                m_fSocketFlag.waitSendCompleted();

                // --

                length = m_networkStream.EndRead(ar);
                if (length == 0)
                {
                    doDisconnect();
                    return;
                }

                // --

                data = new byte[length];
                Buffer.BlockCopy(m_recvBuf, 0, data, 0, length);
                m_fEventPusher.pushEvent(new FTcpClientDataReceivedEventArgs(this, data));
            }
            catch (Exception ex)
            {
                if (ex is IOException)
                {
                    if (ex.InnerException is SocketException)
                    {
                        pushSocketErrorEvent("doReceiveCallback", (SocketException)ex.InnerException);

                        // --

                        // ***
                        // Disconnect
                        // ***
                        doDisconnect();
                    }
                    else if (ex.InnerException is ObjectDisposedException)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.InnerException.ToString());
                    }
                    else
                    {
                        pushErrorEvent(ex.InnerException == null ? ex : ex.InnerException);
                    }
                }
                else if (ex is ObjectDisposedException)
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
                m_fSocketFlag.endReceive();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void doSend(
            FSocketSendData fData
            )
        {
            try
            {
                m_fSocketFlag.beginSend();
                m_networkStream.BeginWrite(fData.data, 0, fData.data.Length, new AsyncCallback(doSendCallback), fData);
            }
            catch (Exception ex)
            {
                if (ex is IOException)
                {
                    if (ex.InnerException is SocketException)
                    {
                        pushSocketErrorEvent("doSend", (SocketException)ex.InnerException);
                        pushDataSendFailedEvent(fData, ex.InnerException.Message);

                        // --

                        // ***
                        // Disconnect
                        // ***
                        doDisconnect();
                    }
                    else if (ex.InnerException is ObjectDisposedException)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.InnerException.ToString());
                    }
                    else
                    {
                        pushErrorEvent(ex.InnerException == null ? ex : ex.InnerException);
                        pushDataSendFailedEvent(fData, ex.Message);
                    }
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
                m_fSocketFlag.endSend();
            }            
            finally
            {
                
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void doSendCallback(
            IAsyncResult ar
            )
        {
            FSocketSendData fData = null;

            try
            {
                fData = (FSocketSendData)ar.AsyncState;
                m_networkStream.EndWrite(ar);
                m_fEventPusher.pushEvent(new FTcpClientDataSentEventArgs(this, fData));
            }
            catch (Exception ex)
            {
                if (ex is IOException)
                {
                    if (ex.InnerException is SocketException)
                    {
                        pushSocketErrorEvent("doSendCallback", (SocketException)ex.InnerException);
                        pushDataSendFailedEvent(fData, ex.InnerException.Message);

                        // --

                        // ***
                        // Disconnect
                        // ***
                        doDisconnect();
                    }
                    else if (ex.InnerException is ObjectDisposedException)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.InnerException.ToString());
                    }
                    else
                    {
                        pushErrorEvent(ex.InnerException == null ? ex : ex.InnerException);
                        pushDataSendFailedEvent(fData, ex.Message);
                    }
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
                fData = null;                
                m_fSocketFlag.endSend();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onTcpClientStateChanged(
            FSocketEventArgsBase args
            )
        {
            try
            {
                if (TcpClientStateChanged != null)
                {
                    TcpClientStateChanged(this, (FTcpClientStateChangedEventArgs)args);
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

        internal void onTcpClientDataReceived(
            FSocketEventArgsBase args
            )
        {
            try
            {
                if (TcpClientDataReceived != null)
                {
                    TcpClientDataReceived(this, (FTcpClientDataReceivedEventArgs)args);
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

        internal void onTcpClientDataSent(
            FSocketEventArgsBase args
            )
        {
            try
            {
                if (TcpClientDataSent != null)
                {
                    TcpClientDataSent(this, (FTcpClientDataSentEventArgs)args);
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

        internal void onTcpClientDataSendFailed(
            FSocketEventArgsBase args
            )
        {
            try
            {
                if (TcpClientDataSendFailed != null)
                {
                    TcpClientDataSendFailed(this, (FTcpClientDataSendFailedEventArgs)args);
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

        internal void onTcpClientErrorRaised(
            FSocketEventArgsBase args
            )
        {
            try
            {
                if (TcpClientErrorRaised != null)
                {
                    TcpClientErrorRaised(this, (FTcpClientErrorRaisedEventArgs)args);
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

                if (m_fState == FTcpClientState.Opened)
                {
                    // ***
                    // Reconnect Time 지정
                    // ***
                    if (!m_fRetryConnectTimer.enabled || m_fRetryConnectTimer.elasped(false))
                    {
                        if (m_tcpClient == null)
                        {
                            doReconnect();
                        }
                        // --
                        if (m_fSocketFlag.doConnectCompleted)
                        {
                            doConnect();
                            return;                        
                        }
                    }                    
                }
                else if (m_fState == FTcpClientState.Connected)
                {
                    if (m_fSocketFlag.disconnected)
                    {
                        if (m_fMode == FTcpClientMode.Server)
                        {
                            doClose();
                        }
                        else
                        {
                            doReconnect();                            
                        }
                        return;
                    }

                    // --

                    if (m_fSocketFlag.doReceiveCompleted)
                    {
                        if (m_fSocketFlag.doReceiveCompleted)
                        {
                            doReceive();
                            return;
                        }                        
                    }                  
    
                    // ***
                    // 2012.11.13 by spike.lee socket disconnect test
                    // ***
                    if (!m_tcpClient.Connected)
                    {
                        System.Diagnostics.Debug.WriteLine("TcpClient Disconnect");
                    }
                }
                else if (m_fState == FTcpClientState.Closed)
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
