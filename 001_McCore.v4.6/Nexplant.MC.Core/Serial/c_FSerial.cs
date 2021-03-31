/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSerial.cs
--  Creator         : byungyun.jeon
--  Create Date     : 2011.10.21
--  Description     : FAMate Core FaCommon Serial Class
--  History         : Created by byungyun.jeon at 2011.10.21
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;

namespace Nexplant.MC.Core.FaCommon
{
    public class FSerial : FISerial, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        public event FSerialStateChangedEventHandler SerialStateChanged = null;
        public event FSerialDataReceivedEventHandler SerialDataReceived = null;
        public event FSerialDataSentEventHandler SerialDataSent = null;
        public event FSerialDataSendFailedEventHandler SerialDataSendFailed = null;
        public event FSerialErrorRaisedEventHandler SerialErrorRaised = null;

        private bool m_disposed = false;
        // --       
        private string m_portName = string.Empty;
        private int m_baudRate = 9600;
        private Parity m_parity = Parity.None;
        private int m_dataBits = 8;
        private StopBits m_stopBits = StopBits.One;
        // --
        private FSerialState m_fState = FSerialState.Closed;
        private SerialPort m_serialPort = null;
        private FSerialFlag m_fSerialFlag = null;
        // --
        private byte[] m_recvBuf = null;
        private const int RecvBufferSize = 8192;
        private const int SendBufferSize = 4096;
        // --
        private FCodeLock m_fMainSync = null;
        private FSerialEventPusher m_fEventPusher = null;
        private FThread m_fThdMain = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSerial(
            )
        {
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSerial(
            string portName,
            int baudRate
            )
            : this()
        {
            m_fState = FSerialState.Closed;
            // -- 
            m_portName = portName;
            m_baudRate = baudRate;
            // --
            m_parity = Parity.None;
            m_dataBits = 8;
            m_stopBits = StopBits.One;
        }

        public FSerial(
            string portName,
            int baudRate,
            Parity parity,
            int dataBits,
            StopBits stopBits
            )
            : this()
        {
            m_fState = FSerialState.Closed;
            // --
            m_portName = portName;
            m_baudRate = baudRate;
            m_parity = parity;
            m_dataBits = dataBits;
            m_stopBits = stopBits;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSerial(
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

        public string portName
        {
            get
            {
                try
                {
                    return m_portName;
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
                    m_portName = value;
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

        public int baudRate
        {
            get
            {
                try
                {
                    return m_baudRate;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 9600;
            }

            set
            {
                try
                {
                    m_baudRate = value;
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

        public Parity parity
        {
            get
            {
                try
                {
                    return m_parity;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return Parity.None;
            }

            set
            {
                try
                {
                    m_parity = value;
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

        public int dataBits
        {
            get
            {
                try
                {
                    return m_dataBits;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 8;
            }

            set
            {
                try
                {
                    m_dataBits = value;
                }
                catch(Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public StopBits stopBits
        {
            get
            {
                try
                {
                    return m_stopBits;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return StopBits.One;
            }

            set
            {
                try
                {
                    m_stopBits = value;
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

        public FSerialState fState
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
                return FSerialState.Closed;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool sendCompleted
        {
            get
            {
                try
                {
                    return m_fSerialFlag.doSendCompleted;
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

        private void init(
            )
        {
            try
            {
                m_fMainSync = new FCodeLock();
                m_fSerialFlag = new FSerialFlag();
                m_recvBuf = new byte[RecvBufferSize];
                // --
                m_fEventPusher = new FSerialEventPusher(this);
                // --
                m_fThdMain = new FThread("FSerialMainThread");
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

                if (m_fSerialFlag != null)
                {
                    m_fSerialFlag.Dispose();
                    m_fSerialFlag = null;
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

        private void changeState(
            FSerialState fState
            )
        {
            try
            {
                m_fState = fState;
                m_fEventPusher.pushEvent(
                    new FSerialStateChangedEventArgs(this, fState, m_portName, m_baudRate)
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
            FSerialSendData fData,
            string message
            )
        {
            try
            {
                m_fEventPusher.pushEvent(new FSerialDataSendFailedEventArgs(this, fData, message));
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
                m_fEventPusher.pushEvent(new FSerialErrorRaisedEventArgs(this, ex.Message, ex));
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

        private void initPort(
            )
        {
            try
            {
                termSerial();

                // --

                m_fSerialFlag.init();

                // -- 

                m_serialPort = new SerialPort();
                // --                
                m_serialPort.PortName = m_portName;
                m_serialPort.BaudRate = m_baudRate;
                m_serialPort.Parity = m_parity;
                m_serialPort.DataBits = m_dataBits;
                m_serialPort.StopBits = m_stopBits;
                // -- 
                m_serialPort.ReadBufferSize = RecvBufferSize;
                m_serialPort.WriteBufferSize = SendBufferSize;
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

        public void open(
            )
        {
            try
            {
                m_fMainSync.wait();

                // --

                // ***
                // FSerialActive 상태가 Closed가 아닐 경우 connect를 실행할 수 없다.
                // ***
                if (m_fState != FSerialState.Closed)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "State of Serial Port", "Closed"));
                }

                // --

                initPort();
                // -- 
                m_serialPort.Open();
                m_fSerialFlag.closed = false;
                // -- 
                changeState(FSerialState.Opened);
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
            FSerialSendData fData
            )
        {
            try
            {
                m_fMainSync.wait();

                // --

                // ***
                // 통신 상태가 Connected가 아닐 경우 오류 처리
                // ***
                if (m_fState != FSerialState.Opened)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0013, "State"));
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

        private void termSerial(
            )
        {
            try
            {
                if (m_serialPort == null)
                {
                    return;
                }

                // -- 

                // ***
                // Send Data 완료 대기
                // ***
                m_fSerialFlag.waitSendCompleted();
                m_serialPort.Close();
                m_fSerialFlag.closed = true;
                // --

                // ***
                // 비동기 작업 종료 대기
                // ***
                m_fSerialFlag.waitAllCompleted();

                // --                                
                m_serialPort = null;
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

        private void doOpen(
            )
        {
            FDebugLogArgs fLogArgs = null;

            try
            {
                m_fSerialFlag.beginOpen();

                open();

                changeState(FSerialState.Opened);

                // ***
                // Debug Log Write about Connection Information
                // ***
                fLogArgs = new FDebugLogArgs(FDebugLogCategory.Information, "SerialPortOpen", this.GetType(), "doOpen");
                fLogArgs.additionInfo = "PortName=<" + m_portName + ">, BaudRate=<" + m_baudRate + ">, Parity=<" + m_parity.ToString() + ">, DataBits=<" + m_dataBits.ToString() + ">, StopBits=<" + m_stopBits.ToString() + ">";
                FDebug.writeLog(fLogArgs);

                // --

                m_fSerialFlag.endOpen();
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
                m_fSerialFlag.endOpen();
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
                if (m_fSerialFlag.closed)
                {
                    return;
                }

                // --
                termSerial();
                changeState(FSerialState.Closed);

                // ***
                // Debug Log Write about Serial Server Disconnect
                // ***
                fLogArgs = new FDebugLogArgs(FDebugLogCategory.Information, "SerialPortClose", this.GetType(), "doClose");
                fLogArgs.additionInfo = "PortName=<" + m_portName + ">";
                FDebug.writeLog(fLogArgs);

                // -- 


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
                m_fSerialFlag.beginReceive();
                m_serialPort.BaseStream.BeginRead(m_recvBuf, 0, m_recvBuf.Length, new AsyncCallback(doReceiveCallback), this);
            }
            catch (Exception ex)
            {
                if (ex is IOException)
                {
                    pushErrorEvent(ex);

                    // --

                    // ***
                    // Close                    
                    // ***
                    doClose();
                }
                else if (ex is ObjectDisposedException)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                }
                else
                {
                    pushErrorEvent(ex);
                }
                m_fSerialFlag.endReceive();
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void doSend(
            FSerialSendData fData
            )
        {
            try
            {
                m_fSerialFlag.beginSend();
                m_serialPort.BaseStream.BeginWrite(fData.data, 0, fData.data.Length, new AsyncCallback(doSendCallback), fData);
            }
            catch (Exception ex)
            {
                if (ex is IOException)
                {
                    pushErrorEvent(ex);
                    pushDataSendFailedEvent(fData, ex.Message);

                    // --

                    // ***
                    // Close
                    // ***
                    doClose();
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
                m_fSerialFlag.endSend();
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
                if (!m_serialPort.IsOpen) return;
                length = m_serialPort.BaseStream.EndRead(ar);
                if (length == 0)
                {
                    doClose();
                    return;
                }

                // --

                data = new byte[length];
                Buffer.BlockCopy(m_recvBuf, 0, data, 0, length);
                m_fEventPusher.pushEvent(new FSerialDataReceivedEventArgs(this, data, m_serialPort.BytesToRead));
            }
            catch (Exception ex)
            {
                if (ex is IOException)
                {
                    pushErrorEvent(ex);

                    // --

                    // ***
                    // Close
                    // ***
                    doClose();
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
                m_fSerialFlag.endReceive();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void doSendCallback(
            IAsyncResult ar
            )
        {
            FSerialSendData fData = null;

            try
            {
                fData = (FSerialSendData)ar.AsyncState;
                m_serialPort.BaseStream.EndWrite(ar);
                m_fEventPusher.pushEvent(new FSerialDataSentEventArgs(this, fData));
            }
            catch (Exception ex)
            {
                if (ex is IOException)
                {
                    pushErrorEvent(ex);
                    pushDataSendFailedEvent(fData, ex.Message);

                    // --

                    // ***
                    // Close
                    // ***
                    doClose();
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
                m_fSerialFlag.endSend();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onSerialStateChanged(
            FSerialEventArgsBase args
            )
        {
            try
            {
                if (SerialStateChanged != null)
                {
                    SerialStateChanged(this, (FSerialStateChangedEventArgs)args);
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

        internal void onSerialDataReceived(
            FSerialEventArgsBase args
            )
        {
            try
            {
                if (SerialDataReceived != null)
                {
                    SerialDataReceived(this, (FSerialDataReceivedEventArgs)args);
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

        internal void onSerialDataSent(
            FSerialEventArgsBase args
            )
        {
            try
            {
                if (SerialDataSent != null)
                {
                    SerialDataSent(this, (FSerialDataSentEventArgs)args);
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

        internal void onSerialDataSendFailed(
            FSerialEventArgsBase args
            )
        {
            try
            {
                if (SerialDataSendFailed != null)
                {
                    SerialDataSendFailed(this, (FSerialDataSendFailedEventArgs)args);
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

        internal void onSerialErrorRaised(
            FSerialEventArgsBase args
            )
        {
            try
            {
                if (SerialErrorRaised != null)
                {
                    SerialErrorRaised(this, (FSerialErrorRaisedEventArgs)args);
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

                if (m_fState == FSerialState.Opened)
                {
                    if (m_fSerialFlag.doReceiveCompleted)
                    {
                        doReceive();
                        return;
                    }
                }
                else if (m_fState == FSerialState.Closed)
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