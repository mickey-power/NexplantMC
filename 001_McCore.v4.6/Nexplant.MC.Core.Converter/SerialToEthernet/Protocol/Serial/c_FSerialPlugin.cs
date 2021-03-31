/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSerial.cs
--  Creator         : mjkim
--  Create Date     : 2020.02.26
--  Description     : FAmate Converter FaSerialToEthernet Serial Protocol Class
--  History         : Created by mjkim at 2020.02.26
----------------------------------------------------------------------------------------------------------*/
using System;
using System.IO.Ports;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSerialToEthernet
{
    internal class FSerialPlugin: IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const int AutoCycleRunTime = 50;    // 추후 설정 여부 판단

        // --

        private bool m_disposed = false;
        // --
        private FSerialToEthernet m_fSerialToEthernet = null;
        private FSerial m_fSerial = null;
        private string m_portName = string.Empty;
        private int m_baudRate = 9600;
        // --
        private FCodeLock m_fMainSync = null;
        private FThread m_fThdMain = null;
        private FStaticTimer m_fTmrAutoCycle = null;
        private FSerialPluginRecvBuffer m_fRecvBuffer = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSerialPlugin(
            FSerialToEthernet fSerialToEthernet
            )
        {
            m_fSerialToEthernet = fSerialToEthernet;
            m_portName = fSerialToEthernet.fSerialConfig.serialPort;
            m_baudRate = fSerialToEthernet.fSerialConfig.baud;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSerialPlugin(
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
                    // --
                    m_fSerialToEthernet = null;
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

        private void init(
            )
        {
            try
            {
                m_fSerial = new FSerial(
                    m_fSerialToEthernet.fSerialConfig.serialPort,
                    m_fSerialToEthernet.fSerialConfig.baud,
                    m_fSerialToEthernet.fSerialConfig.parity,
                    m_fSerialToEthernet.fSerialConfig.dataBits,
                    m_fSerialToEthernet.fSerialConfig.stopBits
                    );
                // --
                m_fSerial.SerialStateChanged += new FSerialStateChangedEventHandler(m_fSerial_SerialStateChanged);
                m_fSerial.SerialDataReceived += new FSerialDataReceivedEventHandler(m_fSerial_SerialDataReceived);
                m_fSerial.SerialDataSent += new FSerialDataSentEventHandler(m_fSerial_SerialDataSent);
                m_fSerial.SerialDataSendFailed += new FSerialDataSendFailedEventHandler(m_fSerial_SerialDataSendFailed);
                m_fSerial.SerialErrorRaised += new FSerialErrorRaisedEventHandler(m_fSerial_SerialErrorRaised);

                // --

                m_fTmrAutoCycle = new FStaticTimer();
                m_fMainSync = new FCodeLock();
                m_fThdMain = new FThread("SerialMainThread");
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

                if (m_fSerial != null)
                {
                    m_fSerial.close();
                    m_fSerial.Dispose();
                    // --
                    m_fSerial.SerialStateChanged -= new FSerialStateChangedEventHandler(m_fSerial_SerialStateChanged);
                    m_fSerial.SerialDataReceived -= new FSerialDataReceivedEventHandler(m_fSerial_SerialDataReceived);
                    m_fSerial.SerialDataSent -= new FSerialDataSentEventHandler(m_fSerial_SerialDataSent);
                    m_fSerial.SerialDataSendFailed -= new FSerialDataSendFailedEventHandler(m_fSerial_SerialDataSendFailed);
                    m_fSerial.SerialErrorRaised -= new FSerialErrorRaisedEventHandler(m_fSerial_SerialErrorRaised);
                    // -- 
                    m_fSerial = null;
                }

                // --

                if (m_fTmrAutoCycle != null)
                {
                    m_fTmrAutoCycle.Dispose();
                    m_fTmrAutoCycle = null;
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

        public void open(
            )
        {
            try
            {
                procSerialPortOpen();

                // --

                m_fSerialToEthernet.changeSerialState(FCommunicationState.Opened, m_portName, m_baudRate);

                // --

                // ***
                // Auto Cycle Run Time 실행
                // ***
                //m_fTmrAutoCycle.start(AutoCycleRunTime);
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
                procSerialPortClose();

                // --

                m_fSerialToEthernet.changeSerialState(FCommunicationState.Closed, m_portName, m_baudRate);
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

        public void send(
            FSerialSendData fSerialSendData
            )
        {
            try
            {
                sendData(fSerialSendData);
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

        private void sendData(
            FSerialSendData fSerialSendData
            )
        {
            try
            {
                m_fSerial.send(fSerialSendData);
            }
            catch (Exception ex)
            {
                procSerialErrorRaised(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procSerialPortOpen(
            )
        {
            try
            {
                m_fSerial.open();
            }
            catch (Exception ex)
            {
                procSerialErrorRaised(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procSerialPortClose(
            )
        {
            try
            {
                if (m_fSerial == null)
                {
                    return;
                }

                // --

                if (m_fSerial.fState == FSerialState.Opened)
                {
                    while (m_fSerialToEthernet.fEventPusher.serialEventCount > 0 || !m_fSerial.sendCompleted)
                    {
                        if (System.Windows.Forms.Application.MessageLoop)
                        {
                            System.Windows.Forms.Application.DoEvents();
                        }
                        System.Threading.Thread.Sleep(1);
                    }
                }

                // --

                m_fSerial.close();
                //// --
                //m_fSerial.SerialStateChanged -= new FSerialStateChangedEventHandler(m_fSerial_SerialStateChanged);
                //m_fSerial.SerialDataReceived -= new FSerialDataReceivedEventHandler(m_fSerial_SerialDataReceived);
                //m_fSerial.SerialDataSent -= new FSerialDataSentEventHandler(m_fSerial_SerialDataSent);
                //m_fSerial.SerialDataSendFailed -= new FSerialDataSendFailedEventHandler(m_fSerial_SerialDataSendFailed);
                //m_fSerial.SerialErrorRaised -= new FSerialErrorRaisedEventHandler(m_fSerial_SerialErrorRaised);
                //// -- 
                //m_fSerial = null;
            }
            catch (Exception ex)
            {
                procSerialErrorRaised(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procSerialStateConnected(
            )
        {
            try
            {
                m_fSerialToEthernet.changeSerialState(FCommunicationState.Connected, m_portName, m_baudRate);

                // --

                // ***
                // Auto Cycle Run Time 중지
                // ***
                //m_fTmrAutoCycle.stop();
            }
            catch (Exception ex)
            {
                procSerialErrorRaised(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procSerialErrorRaised(
            Exception inEx
            )
        {
            try
            {
                FDebug.writeLog(inEx);
                // --
                m_fSerialToEthernet.fEventPusher.pushSerialEvent(
                    new FSerialPluginErrorRaisedEventArgs(m_fSerialToEthernet, FEventId.SerialErrorRaised, inEx.Message)
                    );
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

                if (m_fSerialToEthernet.fSerialState == FCommunicationState.Connected)
                {
                    e.sleepThread(1);
                    return;
                }

                // --

                // ***
                // Auto Cycle Transmitter 처리
                // ***
                if (m_fTmrAutoCycle.elasped(true))
                {
                    try
                    {
                        //procSerialPortClose();
                        procSerialPortOpen();
                        m_fTmrAutoCycle.stop();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(
                            ex.Message
                            );
                    }
                }

                // --

                e.sleepThread(1);
            }
            catch (Exception ex)
            {
                procSerialErrorRaised(ex);
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

        //-----------------------------------------------------------------------------------------------------------------------

        #region m_fSerial Object Evnet Handler

        private void m_fSerial_SerialStateChanged(
            object sender,
            FSerialStateChangedEventArgs e
            )
        {
            try
            {
                m_fMainSync.wait();

                // --

                if (e.fState == FSerialState.Opened)
                {
                    procSerialStateConnected();
                }
                else if (e.fState == FSerialState.Closed)
                {
                    //procSerialStateClosed();
                }
            }
            catch (Exception ex)
            {
                procSerialErrorRaised(ex);
            }
            finally
            {
                m_fMainSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSerial_SerialDataReceived(
            object sender,
            FSerialDataReceivedEventArgs e
            )
        {
            FSerialPluginRecvData fSerialData = null;

            try
            {
                m_fMainSync.wait();

                // --

                if (e.dataLength > 0)
                {
                    if (m_fRecvBuffer == null)
                    {
                        m_fRecvBuffer = new FSerialPluginRecvBuffer(m_fSerialToEthernet.fSerialConfig.suffix);
                    }

                    // --

                    m_fRecvBuffer.input(e.data);

                    // --

                    if (m_fRecvBuffer.isCompleted)
                    {
                        fSerialData = new FSerialPluginRecvData(m_fSerialToEthernet, m_fRecvBuffer.binData);
                        m_fSerialToEthernet.fEventPusher.pushSerialEvent(
                            new FSerialPluginDataReceivedEventArgs(
                                m_fSerialToEthernet,
                                FEventId.SerialDataReceived,
                                FResultCode.Success,
                                string.Empty,
                                fSerialData
                                )
                            );
                        // --
                        m_fRecvBuffer = null;
                    }

                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                m_fMainSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSerial_SerialDataSent(
            object sender,
            FSerialDataSentEventArgs e
            )
        {
            try
            {
                m_fMainSync.wait();

                // --

                m_fSerialToEthernet.fEventPusher.pushSerialEvent(
                    new FSerialPluginDataSentEventArgs(
                        m_fSerialToEthernet, 
                        FEventId.SerialDataSent, 
                        FResultCode.Success, 
                        string.Empty, 
                        new FSerialSendData(e.data)
                        )
                    );
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                m_fMainSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSerial_SerialDataSendFailed(
            object sender,
            FSerialDataSendFailedEventArgs e
            )
        {
            try
            {
                m_fMainSync.wait();

                // --

                m_fSerialToEthernet.fEventPusher.pushSerialEvent(
                    new FSerialPluginDataSentEventArgs(
                        m_fSerialToEthernet, 
                        FEventId.SerialDataSent, 
                        FResultCode.Error, 
                        string.Empty, 
                        new FSerialSendData(e.data)
                        )
                    );
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                m_fMainSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSerial_SerialErrorRaised(
            object sender,
            FSerialErrorRaisedEventArgs e
            )
        {
            try
            {
                procSerialErrorRaised(e.exception);
                procSerialPortClose();

                // --

                m_fSerialToEthernet.changeSerialState(FCommunicationState.Opened, m_portName, m_baudRate);

                // --

                // ***
                // Auto Cycle Run Time 실행
                // ***
                m_fTmrAutoCycle.start(AutoCycleRunTime);
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
