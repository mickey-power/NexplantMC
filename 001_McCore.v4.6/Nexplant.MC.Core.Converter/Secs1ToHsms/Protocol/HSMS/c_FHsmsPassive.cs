/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FHsmsPassive.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.11
--  Description     : FAmate Converter FaSecs1ToHsms HSMS Passive Protocol Class
--  History         : Created by spike.lee at 2017.04.11
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecs1ToHsms
{
    internal class FHsmsPassive : FBaseHsms
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FHsmsRecvBuffer m_fRecvBuf = null;
        private FTcpListener m_fTcpListener = null;
        private FTcpClient m_fTcpClient = null;
        private FCodeLock m_fMainSync = null;
        private FThread m_fThdMain = null;
        private FStaticTimer m_fTmrLinktest = null;
        private FStaticTimer m_fTmrT7 = null;
        private FStaticTimer m_fTmrT8 = null;
        private FHsmsControlMessageTransaction m_fTranLinktestReq = null;
        // --
        private FStaticTimer m_fTmrHsmsPassive2Cleanup = null;
        private List<FHsmsPassive2> m_fHsmsPassive2List = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FHsmsPassive(    
            FSecs1ToHsms fSecs1ToHsms
            )
            : base(fSecs1ToHsms)
        {
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FHsmsPassive(
           )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override void myDispose(
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

                // --

                base.myDispose(disposing);
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
                m_fTmrLinktest = new FStaticTimer();
                m_fTmrT7 = new FStaticTimer();
                m_fTmrT8 = new FStaticTimer();
                m_fTranLinktestReq = new FHsmsControlMessageTransaction(this.fSecs1ToHsms);
                m_fRecvBuf = new FHsmsRecvBuffer();

                // --

                m_fTmrHsmsPassive2Cleanup = new FStaticTimer();
                m_fTmrHsmsPassive2Cleanup.start(1000 * 10); // 10초 주기
                // --
                m_fHsmsPassive2List = new List<FHsmsPassive2>();


                // --

                m_fMainSync = new FCodeLock();
                m_fThdMain = new FThread("FHsmsPassiveMainThread");
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

                if (m_fTcpListener != null)
                {
                    m_fTcpListener.stop();
                    m_fTcpListener.Dispose();
                    // --
                    m_fTcpListener.TcpListenerAcceptCompleted -= new FTcpListenerAcceptCompletedEventHandler(m_fTcpListener_TcpListenerAcceptCompleted);
                    m_fTcpListener.TcpListenerErrorRaised -= new FTcpListenerErrorRaisedEventHandler(m_fTcpListener_TcpListenerErrorRaised);
                    // --
                    m_fTcpListener = null;
                }

                if (m_fTcpClient != null)
                {
                    m_fTcpClient.close();
                    m_fTcpClient.Dispose();
                    // --
                    m_fTcpClient.TcpClientStateChanged -= new FTcpClientStateChangedEventHandler(m_fTcpClient_TcpClientStateChanged);
                    m_fTcpClient.TcpClientDataReceived -= new FTcpClientDataReceivedEventHandler(m_fTcpClient_TcpClientDataReceived);
                    m_fTcpClient.TcpClientDataSent -= new FTcpClientDataSentEventHandler(m_fTcpClient_TcpClientDataSent);
                    m_fTcpClient.TcpClientDataSendFailed -= new FTcpClientDataSendFailedEventHandler(m_fTcpClient_TcpClientDataSendFailed);
                    m_fTcpClient.TcpClientErrorRaised -= new FTcpClientErrorRaisedEventHandler(m_fTcpClient_TcpClientErrorRaised);
                    // --
                    m_fTcpClient = null;
                }

                // --

                closeAllHsmsPassvie2();
                // --
                if (m_fTmrHsmsPassive2Cleanup != null)
                {
                    m_fTmrHsmsPassive2Cleanup.Dispose();
                    m_fTmrHsmsPassive2Cleanup = null;
                    // --
                    m_fHsmsPassive2List = null;
                }

                // --

                if (m_fTmrLinktest != null)
                {
                    m_fTmrLinktest.Dispose();
                    m_fTmrLinktest = null;
                }

                if (m_fTmrT7 != null)
                {
                    m_fTmrT7.Dispose();
                    m_fTmrT7 = null;
                }

                if (m_fTmrT8 != null)
                {
                    m_fTmrT8.Dispose();
                    m_fTmrT8 = null;
                }

                if (m_fTranLinktestReq != null)
                {
                    m_fTranLinktestReq.Dispose();
                    m_fTranLinktestReq = null;
                }

                if (m_fRecvBuf != null)
                {
                    m_fRecvBuf.Dispose();
                    m_fRecvBuf = null;
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

        public override void open(
            )
        {
            try
            {
                m_fTcpListener = new FTcpListener(this.fSecs1ToHsms.fHsmsConfig.localIp, this.fSecs1ToHsms.fHsmsConfig.localPort, 1);
                // --
                m_fTcpListener.TcpListenerAcceptCompleted += new FTcpListenerAcceptCompletedEventHandler(m_fTcpListener_TcpListenerAcceptCompleted);
                m_fTcpListener.TcpListenerErrorRaised += new FTcpListenerErrorRaisedEventHandler(m_fTcpListener_TcpListenerErrorRaised);
                // --
                m_fTcpListener.start();

                // --

                this.fSecs1ToHsms.changeHsmsState(FConnectMode.Passive, this.localIp, this.localPort, this.remoteIp, this.remotePort, FCommunicationState.Opened);
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

        public override void close(
            )
        {
            try
            {
                m_fTcpListener.stop();
                m_fTcpListener.Dispose();
                // --
                m_fTcpListener.TcpListenerAcceptCompleted -= new FTcpListenerAcceptCompletedEventHandler(m_fTcpListener_TcpListenerAcceptCompleted);
                m_fTcpListener.TcpListenerErrorRaised -= new FTcpListenerErrorRaisedEventHandler(m_fTcpListener_TcpListenerErrorRaised);
                // --
                m_fTcpListener = null;

                // --

                closeTcpClient();
                resetResource();

                // --

                this.fSecs1ToHsms.changeHsmsState(FConnectMode.Passive, this.localIp, this.localPort, this.remoteIp, this.remotePort, FCommunicationState.Closed);
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

        public override void send(
            FSecsDataMessage fSecsDataMessage
            )
        {
            try
            {
                sendDataMessage(fSecsDataMessage);
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

        private void closeAllHsmsPassvie2(
            )
        {
            try
            {
                foreach (FHsmsPassive2 hp in m_fHsmsPassive2List)
                {
                    hp.Dispose();
                }
                m_fHsmsPassive2List.Clear();
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

        private void cleanUpHsmsPassive2(
            )
        {
            List<int> indexList = null;

            try
            {
                if (m_fHsmsPassive2List.Count == 0)
                {
                    return;
                }

                // --

                indexList = new List<int>();
                // --
                for (int i = m_fHsmsPassive2List.Count - 1; i >= 0; i--)
                {
                    if (m_fHsmsPassive2List[i].fState == FCommunicationState.Closed)
                    {
                        indexList.Add(i);
                    }
                }

                // -- 

                foreach (int index in indexList)
                {
                    m_fHsmsPassive2List[index].Dispose();
                    m_fHsmsPassive2List.RemoveAt(index);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                indexList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void resetResource(
            )
        {
            try
            {
                // ***
                // Timer, Transaction, Buffer 초기화
                // ***
                m_fTmrLinktest.stop();
                m_fTmrT7.stop();
                m_fTmrT8.stop();
                m_fTranLinktestReq.reset();
                m_fRecvBuf.clear();
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

        private void closeTcpClient(
            )
        {
            try
            {
                if (m_fTcpClient == null)
                {
                    return;
                }

                // --                

                if (m_fTcpClient.fState == FTcpClientState.Connected)
                {
                    if (this.fSecs1ToHsms.fHsmsState == FCommunicationState.Selected)
                    {
                        while (this.fSecs1ToHsms.fEventPusher.hsmsEventCount > 0 || !m_fTcpClient.sendCompleted)
                        {
                            if (System.Windows.Forms.Application.MessageLoop)
                            {
                                System.Windows.Forms.Application.DoEvents();
                            }
                            System.Threading.Thread.Sleep(1);
                        }
                    }
                    // --
                    sendSeparateReq();
                }

                // --

                m_fTcpClient.close();
                m_fTcpClient.Dispose();
                // --
                m_fTcpClient.TcpClientStateChanged -= new FTcpClientStateChangedEventHandler(m_fTcpClient_TcpClientStateChanged);
                m_fTcpClient.TcpClientDataReceived -= new FTcpClientDataReceivedEventHandler(m_fTcpClient_TcpClientDataReceived);
                m_fTcpClient.TcpClientDataSent -= new FTcpClientDataSentEventHandler(m_fTcpClient_TcpClientDataSent);
                m_fTcpClient.TcpClientDataSendFailed -= new FTcpClientDataSendFailedEventHandler(m_fTcpClient_TcpClientDataSendFailed);
                m_fTcpClient.TcpClientErrorRaised -= new FTcpClientErrorRaisedEventHandler(m_fTcpClient_TcpClientErrorRaised);
                // --
                m_fTcpClient = null;
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

        private void sendSelectRsp(
            UInt16 sessionId,
            byte status,
            UInt32 systemBytes
            )
        {
            FHsmsSendBuffer fBuf = null;
            FSecsControlMessage fSecsControlMessage = null;

            try
            {
                fBuf = new FHsmsSendBuffer();
                fBuf.genSelectRsp(sessionId, status, systemBytes);
                // --
                fSecsControlMessage = new FSecsControlMessage(
                    this.fSecs1ToHsms,
                    FHsmsControlMessageType.SelectRsp,
                    fBuf.sessionId,
                    fBuf.byte2,
                    fBuf.byte3,
                    fBuf.ptype,
                    fBuf.stype,
                    fBuf.systemBytes,
                    string.Empty
                    );
                // --
                m_fTcpClient.send(new FSocketSendData(fBuf.getBinaryData(), fSecsControlMessage));
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fBuf = null;
                fSecsControlMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void sendDeselectRsp(
            UInt16 sessionId,
            UInt32 systemBytes
            )
        {
            FHsmsSendBuffer fBuf = null;
            FSecsControlMessage fSecsControlMessage = null;

            try
            {
                fBuf = new FHsmsSendBuffer();
                fBuf.genDeselectRsp(sessionId, systemBytes);
                // --
                fSecsControlMessage = new FSecsControlMessage(
                    this.fSecs1ToHsms,
                    FHsmsControlMessageType.DeselectRsp,
                    fBuf.sessionId,
                    fBuf.byte2,
                    fBuf.byte3,
                    fBuf.ptype,
                    fBuf.stype,
                    fBuf.systemBytes,
                    string.Empty
                    );
                // --
                m_fTcpClient.send(new FSocketSendData(fBuf.getBinaryData(), fSecsControlMessage));
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fBuf = null;
                fSecsControlMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void sendLinktestReq(
            )
        {
            FHsmsSendBuffer fBuf = null;
            FSecsControlMessage fSecsControlMessage = null;

            try
            {
                fBuf = new FHsmsSendBuffer();
                fBuf.genLinktestReq(this.fSystemBytesPointer.uniqueId);
                // --
                fSecsControlMessage = new FSecsControlMessage(
                    this.fSecs1ToHsms,
                    FHsmsControlMessageType.LinktestReq,
                    fBuf.sessionId,
                    fBuf.byte2,
                    fBuf.byte3,
                    fBuf.ptype,
                    fBuf.stype,
                    fBuf.systemBytes,
                    string.Empty
                    );
                // --
                m_fTcpClient.send(new FSocketSendData(fBuf.getBinaryData(), fSecsControlMessage));

                // --

                // ***
                // Linktest Transaction Open
                // ***
                m_fTranLinktestReq.set(fBuf.sessionId, fBuf.systemBytes);
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fBuf = null;
                fSecsControlMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void sendLinktestRsp(
            UInt16 sessionId,
            UInt32 systemBytes
            )
        {
            FHsmsSendBuffer fBuf = null;
            FSecsControlMessage fSecsControlMessage = null;

            try
            {
                fBuf = new FHsmsSendBuffer();
                fBuf.genLinktestRsp(sessionId, systemBytes);
                // --
                fSecsControlMessage = new FSecsControlMessage(
                    this.fSecs1ToHsms,
                    FHsmsControlMessageType.LinktestRsp,
                    fBuf.sessionId,
                    fBuf.byte2,
                    fBuf.byte3,
                    fBuf.ptype,
                    fBuf.stype,
                    fBuf.systemBytes,
                    string.Empty
                    );
                // --
                m_fTcpClient.send(new FSocketSendData(fBuf.getBinaryData(), fSecsControlMessage));
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fBuf = null;
                fSecsControlMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void sendRejectReq(
            UInt16 sessionId,
            byte stype,
            byte reasonCode,
            UInt32 systemBytes
            )
        {
            FHsmsSendBuffer fBuf = null;
            FSecsControlMessage fSecsControlMessage = null;

            try
            {
                fBuf = new FHsmsSendBuffer();
                fBuf.genRejectReq(sessionId, stype, reasonCode, systemBytes);
                // --
                fSecsControlMessage = new FSecsControlMessage(
                    this.fSecs1ToHsms,
                    FHsmsControlMessageType.RejectReq,
                    fBuf.sessionId,
                    fBuf.byte2,
                    fBuf.byte3,
                    fBuf.ptype,
                    fBuf.stype,
                    fBuf.systemBytes,
                    string.Empty
                    );
                // --
                m_fTcpClient.send(new FSocketSendData(fBuf.getBinaryData(), fSecsControlMessage));
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fBuf = null;
                fSecsControlMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void sendSeparateReq(
            )
        {
            FHsmsSendBuffer fBuf = null;
            FSecsControlMessage fSecsControlMessage = null;

            try
            {
                fBuf = new FHsmsSendBuffer();
                fBuf.genSeparateReq(this.fSystemBytesPointer.uniqueId);
                // --
                fSecsControlMessage = new FSecsControlMessage(
                    this.fSecs1ToHsms, 
                    FHsmsControlMessageType.SeparateReq,
                    fBuf.sessionId, 
                    fBuf.byte2, 
                    fBuf.byte3, 
                    fBuf.ptype, 
                    fBuf.stype, 
                    fBuf.systemBytes,
                    string.Empty
                    );
                // --
                m_fTcpClient.send(new FSocketSendData(fBuf.getBinaryData(), fSecsControlMessage));
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fBuf = null;
                fSecsControlMessage = null;
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        private void sendDataMessage(
            FSecsDataMessage fSecsDataMessage
            )
        {
            try
            {
                m_fTcpClient.send(new FSocketSendData(fSecsDataMessage.getHsmsBinaryData(true), fSecsDataMessage));
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void recvSelectReq(
            )
        {
            FResultCode fResult = FResultCode.Success;
            string errorMessage = string.Empty;
            byte status = 0;
            FSecsControlMessage fSecsControlMessage = null;

            try
            {
                if (this.fSecs1ToHsms.fHsmsState == FCommunicationState.Selected)
                {
                    fResult = FResultCode.Warninig;                    
                    status = 1;
                }
                else
                {
                    // ***
                    // T7 Timer 해제
                    // ***
                    m_fTmrT7.stop();
                }

                // --

                errorMessage = getSelectStatusMessage(status);
                
                // --

                fSecsControlMessage = new FSecsControlMessage(
                    this.fSecs1ToHsms, 
                    FHsmsControlMessageType.SelectReq, 
                    m_fRecvBuf.sessionId, 
                    m_fRecvBuf.byte2,
                    m_fRecvBuf.byte3, 
                    m_fRecvBuf.ptype, 
                    m_fRecvBuf.stype, 
                    m_fRecvBuf.systemBytes, 
                    errorMessage
                    );
                // --
                this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                    new FHsmsControlMessageReceivedEventArgs(this.fSecs1ToHsms, FEventId.HsmsControlMessageReceived, fResult, errorMessage, fSecsControlMessage)
                    );

                // --

                sendSelectRsp(m_fRecvBuf.sessionId, status, m_fRecvBuf.systemBytes);
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fSecsControlMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void recvDeselectReq(
            )
        {
            FSecsControlMessage fSecsControlMessage = null;

            try
            {
                fSecsControlMessage = new FSecsControlMessage(
                    this.fSecs1ToHsms,
                    FHsmsControlMessageType.DeselectReq,
                    m_fRecvBuf.sessionId,
                    m_fRecvBuf.byte2,
                    m_fRecvBuf.byte3,
                    m_fRecvBuf.ptype,
                    m_fRecvBuf.stype,
                    m_fRecvBuf.systemBytes,
                    string.Empty
                    );
                // --
                this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                    new FHsmsControlMessageReceivedEventArgs(this.fSecs1ToHsms, FEventId.HsmsControlMessageReceived, FResultCode.Success, string.Empty, fSecsControlMessage)
                    );

                // --

                sendDeselectRsp(m_fRecvBuf.sessionId, m_fRecvBuf.systemBytes);

                // --

                // ***
                // 통신 포트 Close
                // ***
                m_fTcpClient.close();
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fSecsControlMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void recvSelectRsp(
            )
        {
            FSecsControlMessage fSecsControlMessage = null;
            string errorMessage = string.Empty;

            try
            {
                errorMessage = getRejectReasonMessage(1);

                // --

                fSecsControlMessage = new FSecsControlMessage(
                    this.fSecs1ToHsms,
                    FHsmsControlMessageType.SelectRsp,
                    m_fRecvBuf.sessionId,
                    m_fRecvBuf.byte2,
                    m_fRecvBuf.byte3,
                    m_fRecvBuf.ptype,
                    m_fRecvBuf.stype,
                    m_fRecvBuf.systemBytes,
                    errorMessage
                    );
                // --
                this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                    new FHsmsControlMessageReceivedEventArgs(this.fSecs1ToHsms, FEventId.HsmsControlMessageReceived, FResultCode.Warninig, errorMessage, fSecsControlMessage)
                    );

                // --

                sendRejectReq(m_fRecvBuf.sessionId, m_fRecvBuf.stype, 1, m_fRecvBuf.systemBytes);
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fSecsControlMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void recvDeselectRsp(
            )
        {
            FSecsControlMessage fSecsControlMessage = null;
            string errorMessage = string.Empty;

            try
            {
                errorMessage = getRejectReasonMessage(3);

                // --

                fSecsControlMessage = new FSecsControlMessage(
                    this.fSecs1ToHsms,
                    FHsmsControlMessageType.DeselectRsp,
                    m_fRecvBuf.sessionId,
                    m_fRecvBuf.byte2,
                    m_fRecvBuf.byte3,
                    m_fRecvBuf.ptype,
                    m_fRecvBuf.stype,
                    m_fRecvBuf.systemBytes,
                    errorMessage
                    );
                // --
                this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                    new FHsmsControlMessageReceivedEventArgs(this.fSecs1ToHsms, FEventId.HsmsControlMessageReceived, FResultCode.Warninig, errorMessage, fSecsControlMessage)
                    );

                // --

                sendRejectReq(m_fRecvBuf.sessionId, m_fRecvBuf.stype, 3, m_fRecvBuf.systemBytes);
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fSecsControlMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void recvLinktestReq(
            )
        {
            FSecsControlMessage fSecsControlMessage = null;

            try
            {
                fSecsControlMessage = new FSecsControlMessage(
                    this.fSecs1ToHsms,
                    FHsmsControlMessageType.LinktestReq,
                    m_fRecvBuf.sessionId,
                    m_fRecvBuf.byte2,
                    m_fRecvBuf.byte3,
                    m_fRecvBuf.ptype,
                    m_fRecvBuf.stype,
                    m_fRecvBuf.systemBytes,
                    string.Empty
                    );
                // --
                this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                    new FHsmsControlMessageReceivedEventArgs(this.fSecs1ToHsms, FEventId.HsmsControlMessageReceived, FResultCode.Success, string.Empty, fSecsControlMessage)
                    );

                // --

                sendLinktestRsp(m_fRecvBuf.sessionId, m_fRecvBuf.systemBytes);
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fSecsControlMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void recvLinktestRsp(
            )
        {
            FSecsControlMessage fSecsControlMessage = null;
            FResultCode fResult = FResultCode.Success;
            string errorMessage = string.Empty;

            try
            {
                if (!m_fTranLinktestReq.enabled)
                {
                    fResult = FResultCode.Warninig;
                    errorMessage = getRejectReasonMessage(3);
                    // --
                    sendRejectReq(m_fRecvBuf.sessionId, m_fRecvBuf.stype, 3, m_fRecvBuf.systemBytes);
                }
                else if (m_fTranLinktestReq.sessionId != m_fRecvBuf.sessionId)
                {
                    fResult = FResultCode.Warninig;
                    errorMessage = string.Format(FConstants.err_m_0015, "Session ID of the Linktst.Rsp");
                }
                else if (m_fTranLinktestReq.systemBytes != m_fRecvBuf.systemBytes)
                {
                    fResult = FResultCode.Warninig;
                    errorMessage = string.Format(FConstants.err_m_0015, "System Bytes of the Linktest.Rsp");
                }
                else if (m_fRecvBuf.byte3 != 0)
                {
                    fResult = FResultCode.Warninig;
                    errorMessage = this.getSelectStatusMessage(m_fRecvBuf.byte3);
                }
                else
                {
                    // ***
                    // Linktest Transaction Close
                    // ***
                    m_fTranLinktestReq.reset();
                }

                // --

                fSecsControlMessage = new FSecsControlMessage(
                    this.fSecs1ToHsms,
                    FHsmsControlMessageType.LinktestRsp,
                    m_fRecvBuf.sessionId,
                    m_fRecvBuf.byte2,
                    m_fRecvBuf.byte3,
                    m_fRecvBuf.ptype,
                    m_fRecvBuf.stype,
                    m_fRecvBuf.systemBytes,
                    errorMessage
                    );
                // --
                this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                    new FHsmsControlMessageReceivedEventArgs(this.fSecs1ToHsms, FEventId.HsmsControlMessageReceived, fResult, errorMessage, fSecsControlMessage)
                    );
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fSecsControlMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void recvRejectReq(
            )
        {
            FSecsControlMessage fSecsControlMessage = null;
            string errorMessage = string.Empty;

            try
            {
                errorMessage = getRejectReasonMessage(m_fRecvBuf.byte3);

                // --

                fSecsControlMessage = new FSecsControlMessage(
                    this.fSecs1ToHsms,
                    FHsmsControlMessageType.DeselectRsp,
                    m_fRecvBuf.sessionId,
                    m_fRecvBuf.byte2,
                    m_fRecvBuf.byte3,
                    m_fRecvBuf.ptype,
                    m_fRecvBuf.stype,
                    m_fRecvBuf.systemBytes,
                    errorMessage
                    );
                // --
                this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                    new FHsmsControlMessageReceivedEventArgs(this.fSecs1ToHsms, FEventId.HsmsControlMessageReceived, FResultCode.Warninig, errorMessage, fSecsControlMessage)
                    );
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fSecsControlMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void recvSeparateReq(
            )
        {
            FSecsControlMessage fSecsControlMessage = null;

            try
            {
                fSecsControlMessage = new FSecsControlMessage(
                    this.fSecs1ToHsms,
                    FHsmsControlMessageType.SeparateReq,
                    m_fRecvBuf.sessionId,
                    m_fRecvBuf.byte2,
                    m_fRecvBuf.byte3,
                    m_fRecvBuf.ptype,
                    m_fRecvBuf.stype,
                    m_fRecvBuf.systemBytes,
                    string.Empty
                    );
                // --
                this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                    new FHsmsControlMessageReceivedEventArgs(this.fSecs1ToHsms, FEventId.HsmsControlMessageReceived, FResultCode.Success, string.Empty, fSecsControlMessage)
                    );

                // --

                // ***
                // 통신 포트 Close
                // ***
                m_fTcpClient.close();
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fSecsControlMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void recvDataMessage(
            )
        {
            FResultCode fResult = FResultCode.Success;
            string errorMessage = string.Empty;
            FSecsDataMessage fSecsDataMessage = null;

            try
            {
                if (this.fSecs1ToHsms.fHsmsState != FCommunicationState.Selected)
                {
                    fResult = FResultCode.Warninig;
                    errorMessage = getRejectReasonMessage(4);
                    // --
                    sendRejectReq(m_fRecvBuf.sessionId, m_fRecvBuf.stype, 4, m_fRecvBuf.systemBytes);
                }

                // --

                fSecsDataMessage = new FSecsDataMessage(
                    this.fSecs1ToHsms, 
                    m_fRecvBuf.sessionId, 
                    m_fRecvBuf.wbit, 
                    m_fRecvBuf.stream, 
                    m_fRecvBuf.function, 
                    m_fRecvBuf.systemBytes, 
                    m_fRecvBuf.body.ToArray()
                    );
                // --
                this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                    new FHsmsDataMessageReceivedEventArgs(this.fSecs1ToHsms, FEventId.HsmsDataMessageReceived, fResult, errorMessage, fSecsDataMessage)
                    );

                // --

                if (fResult == FResultCode.Success)
                {
                    if (this.fSecs1ToHsms.isHsmsInterceptingDataMessage(fSecsDataMessage.stream, fSecsDataMessage.function))
                    {
                        this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                            new FHsmsInterceptingDataMessageReceivedEventArgs(
                                this.fSecs1ToHsms,
                                FEventId.HsmsInterceptingDataMessageReceived,
                                fResult,
                                errorMessage,
                                fSecsDataMessage
                                )
                            );
                    }
                }
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fSecsDataMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procHsmsErrorRaised(
            Exception inEx
            )
        {
            try
            {
                FDebug.writeLog(inEx);
                // --
                this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                    new FHsmsErrorRaisedEventArgs(this.fSecs1ToHsms, FEventId.HsmsErrorRaised, inEx.Message)
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

        private void procT7Timeout(
            )
        {
            try
            {
                this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                    new FHsmsTimeoutRaisedEventArgs(this.fSecs1ToHsms, FEventId.HsmsTimeoutRaised, FSecsTimeout.T7, getTimeoutMessage(FSecsTimeout.T7))
                     );
                // --
                sendSeparateReq();

                // --

                // ***
                // 통신 포트 Close
                // ***
                m_fTcpClient.close();
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

        private void procT8Timeout(
            )
        {
            try
            {
                this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                    new FHsmsTimeoutRaisedEventArgs(this.fSecs1ToHsms, FEventId.HsmsTimeoutRaised, FSecsTimeout.T8, getTimeoutMessage(FSecsTimeout.T8))
                    );
                // --
                sendSeparateReq();

                // --

                // ***
                // 통신 포트 Close
                // ***
                m_fTcpClient.close();
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

        private void procLinktestTimeout(
            )
        {
            try
            {
                this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                    new FHsmsTimeoutRaisedEventArgs(this.fSecs1ToHsms, FEventId.HsmsTimeoutRaised, FSecsTimeout.T6, getTimeoutMessage(FSecsTimeout.T6))
                        );
                // --
                sendSeparateReq();

                // --

                // ***
                // 통신 포트 Close
                // ***
                m_fTcpClient.close();
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

                /// ***
                // HSMS Passive Clean Up Timer Check
                // ***
                if (m_fTmrHsmsPassive2Cleanup.elasped(true))
                {
                    cleanUpHsmsPassive2();
                }

                // --

                if (m_fTcpClient == null || m_fTcpClient.fState != FTcpClientState.Connected)
                {
                    e.sleepThread(1);
                    return;
                }

                if (this.fSecs1ToHsms.fHsmsState != FCommunicationState.Connected && this.fSecs1ToHsms.fHsmsState != FCommunicationState.Selected)
                {
                    e.sleepThread(1);
                    return;
                }

                // --

                // ***
                // T7 Timeout 체크
                // ***
                if (m_fTmrT7.elasped(false))
                {
                    procT7Timeout();
                    return;
                }

                // --

                // ***
                // Linktest Transaction Timeout 체크
                // ***
                if (m_fTranLinktestReq.timeout())
                {
                    procLinktestTimeout();
                    return;
                }

                // --

                // ***
                // T8 Timeout 체크
                // ***
                if (m_fTmrT8.elasped(false))
                {
                    procT8Timeout();
                    return;
                }

                // --

                // ***
                // Linktest 요청 
                // ***
                if (m_fTmrLinktest.elasped(true))
                {
                    if (!m_fTranLinktestReq.enabled)
                    {
                        sendLinktestReq();
                    }
                }

                // --

                e.sleepThread(1);
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
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

        #region m_fTcpListener Object Event Handler

        private void m_fTcpListener_TcpListenerAcceptCompleted(
            object sender,
            FTcpListenerAcceptCompletedEventArgs e
            )
        {
            try
            {
                m_fMainSync.wait();

                // --

                if (this.fSecs1ToHsms.fHsmsState != FCommunicationState.Opened)
                {
                    m_fHsmsPassive2List.Add(new FHsmsPassive2(this.fSecs1ToHsms, e.fTcpClient));
                    return;
                }

                // --

                closeTcpClient();

                // --

                this.localIp = e.fTcpClient.localIp;
                this.localPort = e.fTcpClient.localPort;
                this.remoteIp = e.fTcpClient.remoteIp;
                this.remotePort = e.fTcpClient.remotePort;

                // --

                m_fTcpClient = e.fTcpClient;
                // --
                m_fTcpClient.TcpClientStateChanged += new FTcpClientStateChangedEventHandler(m_fTcpClient_TcpClientStateChanged);
                m_fTcpClient.TcpClientDataReceived += new FTcpClientDataReceivedEventHandler(m_fTcpClient_TcpClientDataReceived);
                m_fTcpClient.TcpClientDataSent += new FTcpClientDataSentEventHandler(m_fTcpClient_TcpClientDataSent);
                m_fTcpClient.TcpClientDataSendFailed += new FTcpClientDataSendFailedEventHandler(m_fTcpClient_TcpClientDataSendFailed);
                m_fTcpClient.TcpClientErrorRaised += new FTcpClientErrorRaisedEventHandler(m_fTcpClient_TcpClientErrorRaised);
                // --
                m_fTcpClient.resumeEvent();

                // -- 

                this.fSecs1ToHsms.changeHsmsState(FConnectMode.Passive, this.localIp, this.localPort, this.remoteIp, this.remotePort, FCommunicationState.Connected);

                // --

                // ***
                // T7 Timer 설정
                // ***
                m_fTmrT7.start(this.fSecs1ToHsms.fHsmsConfig.t8Timeout * 1000);
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

        private void m_fTcpListener_TcpListenerErrorRaised(
            object sender,
            FTcpListenerErrorRaisedEventArgs e
            )
        {
            try
            {
                procHsmsErrorRaised(e.exception);
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

        #region m_fTcpClient Object Event Handler

        private void m_fTcpClient_TcpClientStateChanged(
            object sender, 
            FTcpClientStateChangedEventArgs e
            )
        {
            try
            {
                m_fMainSync.wait();

                // --

                if (m_fTcpListener != null && e.fState == FTcpClientState.Closed)
                {
                    this.fSecs1ToHsms.changeHsmsState(FConnectMode.Passive, this.localIp, this.localPort, this.remoteIp, this.remotePort, FCommunicationState.Opened);
                    // --
                    resetResource();
                }
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                m_fMainSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpClient_TcpClientDataReceived(
            object sender, 
            FTcpClientDataReceivedEventArgs e
            )
        {
            try
            {
                m_fMainSync.wait();

                // --

                // ***
                // Data Receive 시 T8 Timer 해제
                // ***
                m_fTmrT8.stop();

                // --

                // ***
                // Linktest Timer 재 설정
                // ***
                if (m_fTmrLinktest.enabled)
                {
                    m_fTmrLinktest.restart(this.fSecs1ToHsms.fHsmsConfig.linkTestPeriod * 1000);
                }

                // --

                m_fRecvBuf.input(e.data);
                // --
                while (m_fRecvBuf.parse())
                {
                    if (m_fRecvBuf.stype == 0)
                    {
                        recvDataMessage();
                    }
                    else if (m_fRecvBuf.stype == 1)
                    {
                        recvSelectReq();
                    }
                    else if (m_fRecvBuf.stype == 2)
                    {
                        recvSelectRsp();
                    }
                    else if (m_fRecvBuf.stype == 3)
                    {
                        recvDeselectReq();
                    }
                    else if (m_fRecvBuf.stype == 4)
                    {
                        recvDeselectRsp();
                    }
                    else if (m_fRecvBuf.stype == 5)
                    {
                        recvLinktestReq();
                    }
                    else if (m_fRecvBuf.stype == 6)
                    {
                        recvLinktestRsp();
                    }
                    else if (m_fRecvBuf.stype == 7)
                    {
                        recvRejectReq();
                    }
                    else if (m_fRecvBuf.stype == 9)
                    {
                        recvSeparateReq();
                    }
                    else
                    {
                        // ***
                        // SType 지원 불가 오류 처리
                        // ***
                        // --
                        sendRejectReq(m_fRecvBuf.sessionId, m_fRecvBuf.stype, 1, m_fRecvBuf.systemBytes);
                    }

                    // --

                    m_fRecvBuf.init();
                }

                // --

                // ***
                // Parsing이 완료되지 않을 경우 T8 Timer 설정
                // ***
                if (!m_fRecvBuf.isCompleted)
                {
                    m_fTmrT8.start(this.fSecs1ToHsms.fHsmsConfig.t8Timeout * 1000);
                }
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                m_fMainSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpClient_TcpClientDataSent(
            object sender, 
            FTcpClientDataSentEventArgs e
            )
        {
            FSecsControlMessage fSecsControlMessage = null;
            FSecsDataMessage fSecsDataMessage = null;

            try
            {
                m_fMainSync.wait();

                // --

                if (e.fData.state is FSecsControlMessage)
                {
                    fSecsControlMessage = (FSecsControlMessage)e.fData.state;
                    this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                        new FHsmsControlMessageSentEventArgs(this.fSecs1ToHsms, FEventId.HsmsControlMessageSent, FResultCode.Success, string.Empty, fSecsControlMessage)
                        );

                    // --

                    if (
                        fSecsControlMessage.fType == FHsmsControlMessageType.SelectRsp &&
                        fSecsControlMessage.byte3 == 0
                        )
                    {
                        this.fSecs1ToHsms.changeHsmsState(FConnectMode.Passive, this.localIp, this.localPort, this.remoteIp, this.remotePort, FCommunicationState.Selected);

                        // --

                        // ***
                        // Linktest Timer 설정
                        // ***
                        if (this.fSecs1ToHsms.fHsmsConfig.linkTestPeriod > 0)
                        {
                            m_fTmrLinktest.start(this.fSecs1ToHsms.fHsmsConfig.linkTestPeriod * 1000);
                        }
                    }
                }
                else if (e.fData.state is FSecsDataMessage)
                {
                    fSecsDataMessage = (FSecsDataMessage)e.fData.state;
                    this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                        new FHsmsDataMessageSentEventArgs(this.fSecs1ToHsms, FEventId.HsmsDataMessageSent, FResultCode.Success, string.Empty, fSecsDataMessage)
                        );
                }
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fSecsControlMessage = null;
                fSecsDataMessage = null;
                // --
                m_fMainSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpClient_TcpClientDataSendFailed(
            object sender, 
            FTcpClientDataSendFailedEventArgs e
            )
        {
            FSecsControlMessage fSecsControlMessage = null;
            FSecsDataMessage fSecsDataMessage = null;

            try
            {
                m_fMainSync.wait();

                // --

                if (e.fData.state is FSecsControlMessage)
                {
                    fSecsControlMessage = (FSecsControlMessage)e.fData.state;
                    this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                        new FHsmsControlMessageSentEventArgs(this.fSecs1ToHsms, FEventId.HsmsControlMessageSent, FResultCode.Error, e.message, fSecsControlMessage)
                        );                    
                }
                else if (e.fData.state is FSecsDataMessage)
                {
                    fSecsDataMessage = (FSecsDataMessage)e.fData.state;
                    this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                        new FHsmsDataMessageSentEventArgs(this.fSecs1ToHsms, FEventId.HsmsDataMessageSent, FResultCode.Error, e.message, fSecsDataMessage)
                        );  
                }
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fSecsControlMessage = null;
                fSecsDataMessage = null;
                m_fMainSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpClient_TcpClientErrorRaised(
            object sender, 
            FTcpClientErrorRaisedEventArgs e
            )
        {
            try
            {
                procHsmsErrorRaised(e.exception);
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
