/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSECS1.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.06
--  Description     : FAmate Converter FaSecs1ToHsms SECS1 Protocol Class
--  History         : Created by spike.lee at 2017.04.06
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecs1ToHsms
{
    internal class FSECS1: IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSecs1ToHsms m_fSecs1ToHsms = null;
        // --
        private FSecs1RecvState m_fRecvState = FSecs1RecvState.Completed;
        private FSecs1SendState m_fSendState = FSecs1SendState.Completed;
        private FSecs1RecvBuffer m_fRecvBuf = null;
        private FSecs1RecvBlock m_fRecvBlock = null;
        private FSecs1RecvBlockList m_fRecvBlockList = null;
        private FSecs1SendBlock m_fSendBlock = null;
        private FQueue<FSecs1SendBlockList> m_fSendBlockListQueue = null;
        private FSerial m_fSerial = null;
        private FCodeLock m_fMainSync = null;
        private FThread m_fThdMain = null;
        private FStaticTimer m_fTmrT1 = null;
        private FStaticTimer m_fTmrT2 = null;
        private FStaticTimer m_fTmrT4Runner = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSECS1(
            FSecs1ToHsms fSecs1ToHsms
            )
        {
            m_fSecs1ToHsms = fSecs1ToHsms;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSECS1(
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
                    m_fSecs1ToHsms = null;
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
                m_fRecvBuf = new FSecs1RecvBuffer();
                m_fRecvBlockList = new FSecs1RecvBlockList(m_fSecs1ToHsms);
                m_fSendBlockListQueue = new FQueue<FSecs1SendBlockList>();

                // --

                m_fTmrT1 = new FStaticTimer();
                m_fTmrT2 = new FStaticTimer();
                m_fTmrT4Runner = new FStaticTimer();
                m_fTmrT4Runner.start(1000);     // T4 Timeout 체크는 1초 주기 수행

                // --

                m_fMainSync = new FCodeLock();
                m_fThdMain = new FThread("Secs1MainThread");
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

                if (m_fRecvBuf != null)
                {
                    m_fRecvBuf.Dispose();
                    m_fRecvBuf = null;
                }

                if (m_fRecvBlockList != null)
                {
                    m_fRecvBlockList.Dispose();
                    m_fRecvBlockList = null;
                }

                if (m_fSendBlock != null)
                {
                    m_fSendBlock.Dispose();
                    m_fSendBlock = null;
                }

                if (m_fSendBlockListQueue != null)
                {
                    m_fSendBlockListQueue.Dispose();
                    m_fSendBlockListQueue = null;
                }

                if (m_fTmrT1 != null)
                {
                    m_fTmrT1.Dispose();
                    m_fTmrT1 = null;
                }

                if (m_fTmrT2 != null)
                {
                    m_fTmrT2.Dispose();
                    m_fTmrT2 = null;
                }

                if (m_fTmrT4Runner != null)
                {
                    m_fTmrT4Runner.Dispose();
                    m_fTmrT4Runner = null;
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
                m_fSerial = new FSerial(
                    this.m_fSecs1ToHsms.fSecs1Config.serialPort, 
                    this.m_fSecs1ToHsms.fSecs1Config.baud
                    );
                // --
                m_fSerial.SerialStateChanged += new FSerialStateChangedEventHandler(m_fSerial_SerialStateChanged);
                m_fSerial.SerialDataReceived += new FSerialDataReceivedEventHandler(m_fSerial_SerialDataReceived);
                m_fSerial.SerialDataSent += new FSerialDataSentEventHandler(m_fSerial_SerialDataSent);
                m_fSerial.SerialDataSendFailed += new FSerialDataSendFailedEventHandler(m_fSerial_SerialDataSendFailed);
                m_fSerial.SerialErrorRaised += new FSerialErrorRaisedEventHandler(m_fSerial_SerialErrorRaised);
                // --
                m_fSerial.open();
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
                if (m_fSerial.fState == FSerialState.Opened)
                {
                    while (m_fSecs1ToHsms.fEventPusher.secs1EventCount > 0 || !m_fSerial.sendCompleted)
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
            FSecsDataMessage fSecsDataMessage
            )
        {
            try
            {
                m_fSendBlockListQueue.enqueue(fSecsDataMessage.getSecs1SendBlockList());
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

        private void sendHandshakeENQ(
            )
        {
            FSecs1HandshakeSendData fData = null;

            try
            {
                // ***
                // Send Sate를 ENQ로 변경
                // ***
                m_fSendState = FSecs1SendState.Enq;

                // --

                // ***
                // ENQ 전송 후, T2 Timer 설정
                // ***
                m_fTmrT2.restart((int)(m_fSecs1ToHsms.fSecs1Config.t2Timeout * 1000));

                // -- 

                fData = new FSecs1HandshakeSendData(FSecs1HandshakeCode.ENQ);
                // --
                m_fSerial.send(
                    new FSerialSendData(fData.handshakeToBytes(), fData)
                    );
            }
            catch (Exception ex)
            {
                procSecs1ErrorRaised(ex);
            }
            finally
            {
                fData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void sendHandshakeEOT(
            )
        {
            FSecs1HandshakeSendData fData = null;

            try
            {
                // ***
                // Receive Sate를 EOT로 변경
                // ***
                m_fRecvState = FSecs1RecvState.Eot;

                // --

                // ***
                // EOT 전송 후, T2 Timer 설정
                // ***
                m_fTmrT2.restart((int)(m_fSecs1ToHsms.fSecs1Config.t2Timeout * 1000));

                // --

                fData = new FSecs1HandshakeSendData(FSecs1HandshakeCode.EOT);
                // --
                m_fSerial.send(
                    new FSerialSendData(fData.handshakeToBytes(), fData)
                    );
            }
            catch (Exception ex)
            {
                procSecs1ErrorRaised(ex);
            }
            finally
            {
                fData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void sendHandshakeACK(
            FSecsDataMessage fSecsDataMessage
            )
        {
            FSecs1HandshakeSendData fData = null;

            try
            {
                // ***
                // Receive Sate를 Completed로 변경
                // ***
                m_fRecvState = FSecs1RecvState.Completed;

                // --

                fData = new FSecs1HandshakeSendData(FSecs1HandshakeCode.ACK, fSecsDataMessage);
                // --
                m_fSerial.send(
                    new FSerialSendData(fData.handshakeToBytes(), fData)
                    );
            }
            catch (Exception ex)
            {
                procSecs1ErrorRaised(ex);
            }
            finally
            {
                fData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void sendHandshakeNAK(
            )
        {
            FSecs1HandshakeSendData fData = null;

            try
            {
                // ***
                // Receive Sate를 Completed로 변경
                // ***
                m_fRecvState = FSecs1RecvState.Completed;

                // --

                fData = new FSecs1HandshakeSendData(FSecs1HandshakeCode.NAK);
                // --
                m_fSerial.send(
                    new FSerialSendData(fData.handshakeToBytes(), fData)
                    );
            }
            catch (Exception ex)
            {
                procSecs1ErrorRaised(ex);
            }
            finally
            {
                fData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void sendBlock(
            )
        {
            FSecsBlock fSecsBlock = null;

            try
            {
                // ***
                // Block 전송 후, T2 Timer 설정
                // ***
                m_fTmrT2.restart((int)(m_fSecs1ToHsms.fSecs1Config.t2Timeout * 1000));

                // --

                fSecsBlock = new FSecsBlock(
                    m_fSecs1ToHsms,
                    m_fSendBlock.length,
                    m_fSendBlock.blockData,
                    m_fSendBlock.rbit,
                    m_fSendBlock.sessionId,
                    m_fSendBlock.wbit,
                    m_fSendBlock.stream,
                    m_fSendBlock.function,
                    m_fSendBlock.ebit,
                    m_fSendBlock.blockNo,
                    m_fSendBlock.systemBytes,
                    m_fSendBlock.body,
                    m_fSendBlock.checkSum
                    );
                // --
                m_fSerial.send(new FSerialSendData(m_fSendBlock.blockData, fSecsBlock));
            }
            catch (Exception ex)
            {
                procSecs1ErrorRaised(ex);
            }
            finally
            {
                fSecsBlock = null; 
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void retrySendBlock(
            )
        {
            try
            {
                // ***
                // Send State를 Completed로 변경
                // *** 
                m_fSendState = FSecs1SendState.Completed;

                // --                    

                // ***
                // ENQ 또는 Block 전송 후, EOT, ACK, NAK가 전송되지 않아 T2 Timeout이 발생한 경우 Retry 회수 만큼 재 전송
                // *** 
                if (m_fSendBlock.retryCount < m_fSecs1ToHsms.fSecs1Config.retryLimit)
                {
                    m_fSendBlock.addRetryCount();
                    m_fSendBlock.isRetry = true;
                }
                else
                {
                    m_fSecs1ToHsms.fEventPusher.pushSecs1Event(
                        new FSecs1DataMessageSentEventArgs(
                            m_fSecs1ToHsms,
                            FEventId.Secs1DataMessageSent,
                            FResultCode.Error,
                            FConstants.err_m_16002,
                            m_fSendBlock.fBlockList.fSecsDataMessage
                            )
                        );
                    // --
                    m_fSendBlock = null;
                }
            }
            catch (Exception ex)
            {
                procSecs1ErrorRaised(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private bool sendDataMessage(
            )
        {
            try
            {
                // ***
                // Handshake 처리 중인지 체크
                // ***
                if (m_fRecvState != FSecs1RecvState.Completed || m_fSendState != FSecs1SendState.Completed)
                {
                    return false;
                }

                // --

                if (m_fSendBlock != null)
                {
                    if (m_fSendBlock.isRetry)
                    {
                        // ***
                        // Retry 요청 해제
                        // ***
                        m_fSendBlock.isRetry = false;
                        // --
                        sendHandshakeENQ();
                        return true;
                    }
                    return false;
                }

                // --

                // ***
                // 전송할 Block이 있는지 체크
                // ***
                if (m_fSendBlockListQueue.count == 0)
                {
                    return false;
                }

                // --

                m_fSendBlock = m_fSendBlockListQueue.dequeue().fCurrentBlock;
                sendHandshakeENQ();
                return true;
            }
            catch (Exception ex)
            {
                procSecs1ErrorRaised(ex);
            }
            finally
            {

            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procSecs1T1Timeout(
            )
        {
            try
            {
                // ***
                // T1 Timeout Event 발생
                // ***
                m_fSecs1ToHsms.fEventPusher.pushSecs1Event(
                    new FSecs1TimeoutRaisedEventArgs(m_fSecs1ToHsms, FEventId.Secs1TimeoutRaised, FSecsTimeout.T1, FConstants.err_m_20001)
                    );

                // --

                // ***
                // Receive Block 삭제
                // ***
                m_fRecvBlock = null;

                // --

                // ***
                // NAK 전송
                // ***
                sendHandshakeNAK();
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

        private void procSecs1T2Timeout(
            )
        {
            try
            {
                // ***
                // T2 Timeout Event 발생
                // ***
                m_fSecs1ToHsms.fEventPusher.pushSecs1Event(
                    new FSecs1TimeoutRaisedEventArgs(m_fSecs1ToHsms, FEventId.Secs1TimeoutRaised, FSecsTimeout.T2, FConstants.err_m_20002)
                    );

                // --

                if (m_fRecvState == FSecs1RecvState.Eot)
                {
                    // ***
                    // EOT 전송 후, Block이 전송되지 않아 T2 Timeout이 발생할 경우 NAK 전송
                    // ***
                    sendHandshakeNAK();
                }
                else if (
                    m_fSendState == FSecs1SendState.Enq ||
                    m_fSendState == FSecs1SendState.Eot
                    )
                {
                    retrySendBlock();
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

        private void procSecs1T4Timeout(
            FSecs1T4TimeoutBlock fBlock
            )
        {
            string errorMessage = string.Empty;

            try
            {
                errorMessage = string.Format(FConstants.err_m_20004, fBlock.stream, fBlock.function, fBlock.sessionId, fBlock.systemBytes);

                // --

                // ***
                // T4 Timeout Event 발생
                // ***
                m_fSecs1ToHsms.fEventPusher.pushSecs1Event(
                    new FSecs1TimeoutRaisedEventArgs(m_fSecs1ToHsms, FEventId.Secs1TimeoutRaised, FSecsTimeout.T4, errorMessage)
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

        private void procSecs1ErrorRaised(
            Exception inEx
            )
        {
            try
            {
                FDebug.writeLog(inEx);
                // --
                m_fSecs1ToHsms.fEventPusher.pushSecs1Event(
                    new FSecs1ErrorRaisedEventArgs(m_fSecs1ToHsms, FEventId.Secs1ErrorRaised, inEx.Message)
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

        //------------------------------------------------------------------------------------------------------------------------

        private void procSecs1ErrorRaised(
            string errorMessage
            )
        {
            Exception inEx = null;

            try
            {
                inEx = new Exception(errorMessage);
                // --
                procSecs1ErrorRaised(inEx);
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

                if (m_fSerial == null || m_fSerial.fState != FSerialState.Opened || m_fSecs1ToHsms.fSecs1State != FCommunicationState.Selected)
                {
                    e.sleepThread(1);
                    return;
                }

                // --

                // ***
                // T1 Timeout 체크
                // *** 
                if (m_fTmrT1.elasped(false))
                {
                    procSecs1T1Timeout();
                    return;
                }

                // ***
                // T2 Timeout 체크
                // ***
                if (m_fTmrT2.elasped(false))
                {
                    procSecs1T2Timeout();
                    return;
                }

                // ***
                // T4 Timeout 체크
                // ***
                if (m_fTmrT4Runner.elasped(true))
                {
                    foreach (FSecs1T4TimeoutBlock b in m_fRecvBlockList.removeT4TimeoutBlock())
                    {
                        procSecs1T4Timeout(b);
                    }
                }

                // --

                // ***
                // Data Message Send
                // *** 
                if (sendDataMessage())
                {
                    return;
                }

                // --

                e.sleepThread(1);
            }
            catch (Exception ex)
            {
                procSecs1ErrorRaised(ex);
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
                    m_fSecs1ToHsms.changeSecs1State(FCommunicationState.Opened, m_fSecs1ToHsms.fSecs1Config.serialPort, m_fSecs1ToHsms.fSecs1Config.baud);
                    m_fSecs1ToHsms.changeSecs1State(FCommunicationState.Connected, m_fSecs1ToHsms.fSecs1Config.serialPort, m_fSecs1ToHsms.fSecs1Config.baud);
                    m_fSecs1ToHsms.changeSecs1State(FCommunicationState.Selected, m_fSecs1ToHsms.fSecs1Config.serialPort, m_fSecs1ToHsms.fSecs1Config.baud);
                }
                else if (e.fState == FSerialState.Closed)
                {
                    m_fSecs1ToHsms.changeSecs1State(FCommunicationState.Closed, m_fSecs1ToHsms.fSecs1Config.serialPort, m_fSecs1ToHsms.fSecs1Config.baud);
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

        private void m_fSerial_SerialDataReceived(
            object sender, 
            FSerialDataReceivedEventArgs e
            )
        {
            byte byteData = 0;
            int needLength = 0;
            int copyLength = 0;
            FResultCode fResult = FResultCode.Success;
            string errorMessage = string.Empty;
            FSecsBlock fSecsBlock = null;
            FSecsDataMessage fSecsDataMessage = null;

            try
            {
                m_fMainSync.wait();

                // --

                m_fRecvBuf.input(e.data);
                // --
                while (m_fRecvBuf.length > 0)
                {
                    if (m_fRecvState == FSecs1RecvState.Enq)
                    {
                        #region Receive State ENQ

                        // ***
                        // Receive 상태가 ENQ인 경우에 데이터가 전송되면 오류 처리
                        // ***
                        procSecs1ErrorRaised(string.Format(FConstants.err_m_16001, m_fRecvBuf.output()));

                        #endregion
                    }
                    else if (m_fRecvState == FSecs1RecvState.Eot)
                    {
                        #region Receive State EOT

                        if (m_fRecvBlock == null)
                        {
                            // ***
                            // Get Length
                            // ***
                            byteData = m_fRecvBuf.output();
                            // --
                            if (byteData < 10 || byteData > 254)
                            {
                                // ***
                                // Block 길이가 10보다 작거나 254 보다 클 경우 오류 처리
                                // ***
                                procSecs1ErrorRaised(string.Format(FConstants.err_m_16012, byteData));
                                continue;
                            }
                            else
                            {
                                // ***
                                // EOT 전송 후 설정한 T2 Timer 해제
                                // ***
                                m_fTmrT2.stop();
                                // --
                                m_fRecvBlock = new FSecs1RecvBlock(byteData);
                            }
                        }

                        // --

                        // ***
                        // Block Data 수집
                        // ***
                        needLength = m_fRecvBlock.calculateNeedLength();
                        if (m_fRecvBuf.length > needLength)
                        {
                            copyLength = needLength;
                        }
                        else
                        {
                            copyLength = m_fRecvBuf.length;
                        }
                        m_fRecvBlock.input(m_fRecvBuf.output(copyLength));

                        // --

                        // ***
                        // Block Data 수집 미완료 후 설정한 T1 Timer 해제
                        // *** 
                        m_fTmrT1.stop();

                        // --

                        // ***
                        // Block Data 수집 완료
                        // ***
                        if (m_fRecvBlock.blockDataCollectionCompleted)
                        {
                            // ***
                            // Block Data Parse
                            // ***
                            m_fRecvBlock.parse();

                            // --

                            // ***
                            // Block Data Validation
                            // ***
                            if (!m_fRecvBlock.validateCheckSum())
                            {
                                fResult = FResultCode.Error;
                                errorMessage = FConstants.err_m_16010;
                            }
                            else if (!m_fRecvBlock.validateRbit(m_fSecs1ToHsms.fSecs1Config.rbit))
                            {
                                fResult = FResultCode.Error;
                                errorMessage = string.Format(FConstants.err_m_0061, "R-Bit", "valid");
                            }
                            else if (!m_fRecvBlock.validateSessionId(m_fSecs1ToHsms.fSecs1Config.sessionId))
                            {
                                fResult = FResultCode.Error;
                                errorMessage = string.Format(FConstants.err_m_0061, "Session ID", "valid");
                            }
                            else if (!m_fRecvBlockList.validateInterleave(m_fRecvBlock))
                            {
                                fResult = FResultCode.Error;
                                errorMessage = FConstants.err_m_16008;
                            }
                            else if (!m_fRecvBlockList.validateBlockNo(m_fRecvBlock))
                            {
                                fResult = FResultCode.Error;
                                errorMessage = FConstants.err_m_16006;
                            }
                            else if (!m_fRecvBlockList.validateDuplidateBlock(m_fRecvBlock))
                            {
                                fResult = FResultCode.Error;
                                errorMessage = FConstants.err_m_16005;
                            }
                            else
                            {
                                fResult = FResultCode.Success;
                            }

                            // --

                            fSecsBlock = new FSecsBlock(
                                m_fSecs1ToHsms,
                                m_fRecvBlock.length,
                                m_fRecvBlock.blockData,
                                m_fRecvBlock.rbit,
                                m_fRecvBlock.sessionId,
                                m_fRecvBlock.wbit, 
                                m_fRecvBlock.stream, 
                                m_fRecvBlock.function, 
                                m_fRecvBlock.ebit, 
                                m_fRecvBlock.blockNo, 
                                m_fRecvBlock.systemBytes, 
                                m_fRecvBlock.body, 
                                m_fRecvBlock.checkSum
                                );
                            // --
                            m_fSecs1ToHsms.fEventPusher.pushSecs1Event(
                                new FSecs1BlockReceivedEventArgs(m_fSecs1ToHsms, FEventId.Secs1BlockReceived, fResult, errorMessage, fSecsBlock)
                                );

                            // --

                            if (fResult == FResultCode.Success)
                            {
                                fSecsDataMessage = m_fRecvBlockList.addBlock(m_fRecvBlock);
                                // --
                                sendHandshakeACK(fSecsDataMessage);
                            }
                            else
                            {
                                sendHandshakeNAK();
                            }
                            m_fRecvBlock = null;
                        }
                        else
                        {
                            // ***
                            // Block Data 수집이 완료되지 않을 경우 T1 Timer 설정
                            // *** 
                            m_fTmrT1.restart((int)(m_fSecs1ToHsms.fSecs1Config.t1Timeout * 1000));
                        }

                        #endregion
                    }
                    else if (m_fSendState == FSecs1SendState.Enq)
                    {
                        #region Send State ENQ

                        byteData = m_fRecvBuf.output();
                        // --
                        if (byteData == (byte)FSecs1HandshakeCode.ENQ)
                        {
                            m_fSecs1ToHsms.fEventPusher.pushSecs1Event(
                                new FSecs1HandshakeReceivedEventArgs(m_fSecs1ToHsms, FEventId.Secs1HandshakeReceived, FResultCode.Success, string.Empty, FSecs1HandshakeCode.ENQ)
                                );

                            // --

                            // ***
                            // rbit가 True인 경우, Block 전송을 중단하고 Block 수신 상태로 전환
                            // ***
                            if (!m_fSecs1ToHsms.fSecs1Config.rbit)
                            {
                                // ***
                                // ENQ 전송 후 설정한 T2 Timer 해제
                                // ***
                                m_fTmrT2.stop();
                                
                                // --

                                // ***
                                // Send State를 Completed로 변경
                                // ***
                                m_fSendState = FSecs1SendState.Completed;
                                
                                // --

                                // ***
                                // Retry 요청
                                // ***
                                m_fSendBlock.isRetry = true;

                                // --

                                // *** 
                                // Receive State를 ENQ로 변경
                                // ***
                                m_fRecvState = FSecs1RecvState.Enq;
                                // --
                                sendHandshakeEOT();
                            }
                        }
                        else if (byteData == (byte)FSecs1HandshakeCode.EOT)
                        {
                            // ***
                            // ENQ 전송 후 설정한 T2 Timer 해제
                            // ***
                            m_fTmrT2.stop();

                            // --

                            // *** 
                            // Send State를 EOT로 변경
                            // ***
                            m_fSendState = FSecs1SendState.Eot;
                            // --
                            m_fSecs1ToHsms.fEventPusher.pushSecs1Event(
                                new FSecs1HandshakeReceivedEventArgs(m_fSecs1ToHsms, FEventId.Secs1HandshakeReceived, FResultCode.Success, string.Empty, FSecs1HandshakeCode.EOT)
                                );
                            sendBlock();
                        }
                        else
                        {
                            procSecs1ErrorRaised(string.Format(FConstants.err_m_16001, byteData));
                        }

                        #endregion
                    }
                    else if (m_fSendState == FSecs1SendState.Eot)
                    {
                        #region Send State EOT

                        byteData = m_fRecvBuf.output();
                        // --
                        if (byteData == (byte)FSecs1HandshakeCode.ACK)
                        {
                            // ***
                            // Block 전송 후 설정한 T2 Timer 해제
                            // ***
                            m_fTmrT2.stop();

                            // --

                            // ***
                            // Send State를 Completed로 변경
                            // ***
                            m_fSendState = FSecs1SendState.Completed;
                            // --
                            m_fSecs1ToHsms.fEventPusher.pushSecs1Event(
                                new FSecs1HandshakeReceivedEventArgs(m_fSecs1ToHsms, FEventId.Secs1HandshakeReceived, FResultCode.Success, string.Empty, FSecs1HandshakeCode.ACK)
                                );

                            // --

                            if (m_fSendBlock.fBlockList.next())
                            {
                                // ***
                                // Next Block 전송 시작
                                // ***
                                m_fSendBlock = m_fSendBlock.fBlockList.fCurrentBlock;
                                sendHandshakeENQ();
                            }
                            else
                            {
                                // ***
                                // All Block 전송 완료
                                // ***
                                m_fSecs1ToHsms.fEventPusher.pushSecs1Event(
                                    new FSecs1DataMessageSentEventArgs(m_fSecs1ToHsms, FEventId.Secs1DataMessageSent, FResultCode.Success, string.Empty, m_fSendBlock.fBlockList.fSecsDataMessage)
                                    );
                                m_fSendBlock = null;
                            }
                        }
                        else if (byteData == (byte)FSecs1HandshakeCode.NAK)
                        {
                            // ***
                            // Block 전송 후 설정한 T2 Timer 해제
                            // ***
                            m_fTmrT2.stop();

                            // --

                            m_fSecs1ToHsms.fEventPusher.pushSecs1Event(
                                new FSecs1HandshakeReceivedEventArgs(m_fSecs1ToHsms, FEventId.Secs1HandshakeReceived, FResultCode.Success, string.Empty, FSecs1HandshakeCode.NAK)
                                );

                            // --

                            retrySendBlock();
                        }
                        else
                        {
                            procSecs1ErrorRaised(string.Format(FConstants.err_m_16001, byteData));
                        }

                        #endregion
                    }
                    else
                    {
                        #region State Completed

                        byteData = m_fRecvBuf.output();
                        // --
                        if (byteData == (byte)FSecs1HandshakeCode.ENQ)
                        {
                            // *** 
                            // Receive State를 ENQ로 변경
                            // ***
                            m_fRecvState = FSecs1RecvState.Enq;
                            // --
                            m_fSecs1ToHsms.fEventPusher.pushSecs1Event(
                                new FSecs1HandshakeReceivedEventArgs(m_fSecs1ToHsms, FEventId.Secs1HandshakeReceived, FResultCode.Success, string.Empty, FSecs1HandshakeCode.ENQ)
                                );
                            sendHandshakeEOT();
                        }
                        else
                        {
                            procSecs1ErrorRaised(string.Format(FConstants.err_m_16001, byteData));
                        }

                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                fSecsBlock = null;
                fSecsDataMessage = null;

                // --

                m_fMainSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSerial_SerialDataSent(
            object sender, 
            FSerialDataSentEventArgs e
            )
        {
            FSecs1HandshakeSendData fHandshakeData = null;

            try
            {
                m_fMainSync.wait();

                // --

                if (e.fData.state is FSecs1HandshakeSendData)
                {
                    #region FSecs1HandshakeSendData

                    fHandshakeData = (FSecs1HandshakeSendData)e.fData.state;
                    // --
                    if (fHandshakeData.fHandshakeCode == FSecs1HandshakeCode.ENQ)
                    {
                        #region ENQ

                        m_fSecs1ToHsms.fEventPusher.pushSecs1Event(
                            new FSecs1HandshakeSentEventArgs(m_fSecs1ToHsms, FEventId.Secs1HandshakeSent, FResultCode.Success, string.Empty, FSecs1HandshakeCode.ENQ)
                            );

                        #endregion
                    }
                    else if (fHandshakeData.fHandshakeCode == FSecs1HandshakeCode.EOT)
                    {
                        #region EOT
                        
                        m_fSecs1ToHsms.fEventPusher.pushSecs1Event(
                            new FSecs1HandshakeSentEventArgs(m_fSecs1ToHsms, FEventId.Secs1HandshakeSent, FResultCode.Success, string.Empty, FSecs1HandshakeCode.EOT)
                            );

                        #endregion
                    }
                    else if (fHandshakeData.fHandshakeCode == FSecs1HandshakeCode.ACK)
                    {
                        #region ACK

                        m_fSecs1ToHsms.fEventPusher.pushSecs1Event(
                            new FSecs1HandshakeSentEventArgs(m_fSecs1ToHsms, FEventId.Secs1HandshakeSent, FResultCode.Success, string.Empty, FSecs1HandshakeCode.ACK)
                            );
                        // --
                        if (fHandshakeData.hasSecsDataMesssage)
                        {
                            m_fSecs1ToHsms.fEventPusher.pushSecs1Event(
                                new FSecs1DataMessageReceivedEventArgs(
                                    m_fSecs1ToHsms, 
                                    FEventId.Secs1DataMessageReceived, 
                                    FResultCode.Success, 
                                    string.Empty, 
                                    fHandshakeData.fSecsDataMessage
                                    )
                                );
                            
                            // --

                            if (m_fSecs1ToHsms.isSecs1InterceptingDataMessage(fHandshakeData.fSecsDataMessage.stream, fHandshakeData.fSecsDataMessage.function))
                            {
                                m_fSecs1ToHsms.fEventPusher.pushSecs1Event(
                                    new FSecs1InterceptingDataMessageReceivedEventArgs(
                                        m_fSecs1ToHsms, 
                                        FEventId.Secs1InterceptingDataMessageReceived, 
                                        FResultCode.Success, 
                                        string.Empty, 
                                        fHandshakeData.fSecsDataMessage
                                        )
                                );
                            }                            
                        }

                        #endregion
                    }
                    else if (fHandshakeData.fHandshakeCode == FSecs1HandshakeCode.NAK)
                    {
                        #region NAK

                        m_fSecs1ToHsms.fEventPusher.pushSecs1Event(
                            new FSecs1HandshakeSentEventArgs(m_fSecs1ToHsms, FEventId.Secs1HandshakeSent, FResultCode.Success, string.Empty, FSecs1HandshakeCode.NAK)
                            );

                        #endregion
                    }

                    #endregion
                }
                else if (e.fData.state is FSecsBlock)
                {
                    #region Send Block

                    m_fSecs1ToHsms.fEventPusher.pushSecs1Event(
                        new FSecs1BlockSentEventArgs(m_fSecs1ToHsms, FEventId.Secs1BlockSent, FResultCode.Success, string.Empty, (FSecsBlock)e.fData.state)
                        );

                    #endregion
                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                fHandshakeData = null;

                // --

                m_fMainSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSerial_SerialDataSendFailed(
            object sender, 
            FSerialDataSendFailedEventArgs e
            )
        {
            FSecs1HandshakeSendData fHandshakeData = null;

            try
            {
                m_fMainSync.wait();

                // --

                if (e.fData.state is FSecs1HandshakeSendData)
                {
                    #region FSecs1HandshakeSendData

                    fHandshakeData = (FSecs1HandshakeSendData)e.fData.state;
                    // --
                    if (fHandshakeData.fHandshakeCode == FSecs1HandshakeCode.ENQ)
                    {
                        #region ENQ

                        m_fSecs1ToHsms.fEventPusher.pushSecs1Event(
                            new FSecs1HandshakeSentEventArgs(m_fSecs1ToHsms, FEventId.Secs1HandshakeSent, FResultCode.Error, e.message, FSecs1HandshakeCode.ENQ)
                            );

                        #endregion
                    }
                    else if (fHandshakeData.fHandshakeCode == FSecs1HandshakeCode.EOT)
                    {
                        #region EOT

                        m_fSecs1ToHsms.fEventPusher.pushSecs1Event(
                            new FSecs1HandshakeSentEventArgs(m_fSecs1ToHsms, FEventId.Secs1HandshakeSent, FResultCode.Error, e.message, FSecs1HandshakeCode.EOT)
                            );

                        #endregion
                    }
                    else if (fHandshakeData.fHandshakeCode == FSecs1HandshakeCode.ACK)
                    {
                        #region ACK

                        m_fSecs1ToHsms.fEventPusher.pushSecs1Event(
                            new FSecs1HandshakeSentEventArgs(m_fSecs1ToHsms, FEventId.Secs1HandshakeSent, FResultCode.Error, e.message, FSecs1HandshakeCode.ACK)
                            );
                        // --
                        if (fHandshakeData.hasSecsDataMesssage)
                        {
                            m_fSecs1ToHsms.fEventPusher.pushSecs1Event(
                                new FSecs1DataMessageReceivedEventArgs(m_fSecs1ToHsms, FEventId.Secs1DataMessageReceived, FResultCode.Error, string.Format(FConstants.err_m_0062, "ACK"), fHandshakeData.fSecsDataMessage)
                                );
                        }

                        #endregion
                    }
                    else if (fHandshakeData.fHandshakeCode == FSecs1HandshakeCode.NAK)
                    {
                        #region NAK

                        m_fSecs1ToHsms.fEventPusher.pushSecs1Event(
                            new FSecs1HandshakeSentEventArgs(m_fSecs1ToHsms, FEventId.Secs1HandshakeSent, FResultCode.Error, e.message, FSecs1HandshakeCode.NAK)
                            );

                        #endregion
                    }

                    #endregion
                }
                else if (e.fData.state is FSecsBlock)
                {
                    #region Send Block

                    m_fSecs1ToHsms.fEventPusher.pushSecs1Event(
                        new FSecs1BlockSentEventArgs(m_fSecs1ToHsms, FEventId.Secs1BlockSent, FResultCode.Error, e.message, (FSecsBlock)e.fData.state)
                        );

                    // --

                    // Retry 구현 필요

                    #endregion
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

        private void m_fSerial_SerialErrorRaised(
            object sender, 
            FSerialErrorRaisedEventArgs e
            )
        {
            try
            {
                procSecs1ErrorRaised(e.exception);
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
