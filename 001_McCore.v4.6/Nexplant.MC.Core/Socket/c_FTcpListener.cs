/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTcpListener.cs
--  Creator         : spike.lee
--  Create Date     : 2011.08.17
--  Description     : FAMate Core FaCommon TCP Listener Class
--  History         : Created by spike.lee at 2011.08.17
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Nexplant.MC.Core.FaCommon
{
    public class FTcpListener : FISocket, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        public event FTcpListenerAcceptCompletedEventHandler TcpListenerAcceptCompleted = null;
        public event FTcpListenerErrorRaisedEventHandler TcpListenerErrorRaised = null;

        private bool m_disposed = false;
        // --
        private string m_localIp = string.Empty;
        private int m_localPort = 0;
        private int m_backlog = 1;
        private bool m_started = false;
        private TcpListener m_tcpListener = null;
        private FSocketFlag m_fSocketFlag = null;        
        // --
        private FCodeLock m_fMainSync = null;
        private FSocketEventPusher m_fEventPusher = null;
        private FThread m_fThdMain = null;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTcpListener(
            string localIp,
            int localPort,
            int backlog
            )
        {
            m_localIp = localIp;
            m_localPort = localPort;
            m_backlog = backlog;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FTcpListener(
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
                    return FSocketType.Listener;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FSocketType.Listener;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

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
                fLogArgs.additionInfo = "SocketErrorCode=<" + sckEx.SocketErrorCode.ToString() + ">" + Environment.NewLine + sckEx.ToString();
                FDebug.writeLog(fLogArgs);
                // --
                m_fEventPusher.pushEvent(
                    new FTcpListenerErrorRaisedEventArgs(this, sckEx.Message, sckEx)
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
                m_fEventPusher.pushEvent(new FTcpListenerErrorRaisedEventArgs(this, ex.Message, ex));
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

        private void init(
            )
        {
            try
            {
                m_fMainSync = new FCodeLock();
                m_fSocketFlag = new FSocketFlag();
                m_fEventPusher = new FSocketEventPusher(this, false);                
                // --
                m_fThdMain = new FThread("FTcpListenerMainThread");
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

                if (m_fSocketFlag != null)
                {
                    m_fSocketFlag.Dispose();
                    m_fSocketFlag = null;
                }

                // --

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
                    FDebug.throwFException(string.Format(FConstants.err_m_0001, "TCP Listener"));
                }
                
                // --

                // ***
                // Debug Log Write about TCP Listener Start
                // ***
                fLogArgs = new FDebugLogArgs(FDebugLogCategory.Information, "TcpListenerStart", this.GetType(), "start");                
                FDebug.writeLog(fLogArgs);

                // --

                initTcpListener();
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

                m_started = false;
                termTcpListener();

                // --

                // ***
                // Debug Log Write about TCP Listener Stop
                // ***
                fLogArgs = new FDebugLogArgs(FDebugLogCategory.Information, "TcpListenerStop", this.GetType(), "stop");
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

        private void initTcpListener(
            )
        {
            try
            {
                termTcpListener();

                // --

                m_fSocketFlag.init();

                // --

                m_tcpListener = new TcpListener(Dns.GetHostAddresses(m_localIp)[0], m_localPort);
                m_tcpListener.Start(m_backlog);                
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

        private void termTcpListener(
            )
        {
            try
            {
                if (m_tcpListener == null)
                {
                    return;
                }
                m_tcpListener.Stop();

                // --

                // ***
                // 비동기 작업 완료 대기
                // ***
                m_fSocketFlag.waitAllCompleted();                

                // --

                m_tcpListener = null;
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

        private void doAccept(
            )
        {
            try
            {
                m_fSocketFlag.beginAccept();
                m_tcpListener.BeginAcceptTcpClient(new AsyncCallback(doAcceptCallback), this);
            }
            catch (Exception ex)
            {
                if (ex is SocketException)
                {
                    pushSocketErrorEvent("doAccept", (SocketException)ex);
                }
                else if (ex is ObjectDisposedException)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
                else
                {
                    pushErrorEvent(ex);
                }                
                m_fSocketFlag.endAccept();
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void doAcceptCallback(
            IAsyncResult ar
            )
        {
            TcpClient tcpClient = null;
            FDebugLogArgs fLogArgs = null;
            IPEndPoint localIpEndPoint = null;
            IPEndPoint remoteIpEndPoint = null;

            try
            {
                tcpClient = m_tcpListener.EndAcceptTcpClient(ar);
                localIpEndPoint = (IPEndPoint)tcpClient.Client.LocalEndPoint;
                remoteIpEndPoint = (IPEndPoint)tcpClient.Client.RemoteEndPoint;

                // --

                // ***
                // Debug Log Write about Accept Information
                // ***
                fLogArgs = new FDebugLogArgs(FDebugLogCategory.Information, "TcpListenerAccept", this.GetType(), "doAcceptCallback");
                fLogArgs.additionInfo = "LocalIP=<" + localIpEndPoint.Address.ToString() + ">, LocalPort=<" + localIpEndPoint.Port.ToString() + ">, RemoteIP=<" + remoteIpEndPoint.Address.ToString() + ">, RemotePort=<" + remoteIpEndPoint.Port.ToString() + ">";
                FDebug.writeLog(fLogArgs);

                // --

                m_fEventPusher.pushEvent(new FTcpListenerAcceptCompletedEventArgs(this, new FTcpClient(tcpClient)));                             
            }
            catch (Exception ex)
            {
                if (ex is SocketException)
                {
                    pushSocketErrorEvent("doAcceptCallback", (SocketException)ex);
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
                tcpClient = null;
                fLogArgs = null;
                localIpEndPoint = null;
                remoteIpEndPoint = null;
                // --
                m_fSocketFlag.endAccept();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onTcpListenerAcceptCompleted(
            FSocketEventArgsBase args
            )
        {
            try
            {
                if (TcpListenerAcceptCompleted != null)
                {
                    TcpListenerAcceptCompleted(this, (FTcpListenerAcceptCompletedEventArgs)args);
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

        internal void onTcpListenerErrorRaised(
            FSocketEventArgsBase args
            )
        {
            try
            {
                if (TcpListenerErrorRaised != null)
                {
                    TcpListenerErrorRaised(this, (FTcpListenerErrorRaisedEventArgs)args);
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

                if (m_started)
                {
                    if (m_fSocketFlag.doAcceptCompleted)
                    {
                        doAccept();
                        return;
                    }
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
