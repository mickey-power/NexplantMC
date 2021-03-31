/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FMainContainer.cs
--  Creator         : mjkim
--  Create Date     : 2019.09.10
--  Description     : Nexplant MC Counter Main Container Form Class
--  History         : Created by mjkim at 2019.09.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using System.Text;
using System.IO;
using System.Media;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaSecs1ToHsms;

namespace Nexplant.MC.Counter
{
    public partial class FMainContainer : Form
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FCntCore m_fCntCore = null;
        private FEventHandler m_fEventHandler = null;
        private FQueue<FEventArgsBase> m_fSecs1RecvQueue = null;
        private FQueue<FEventArgsBase> m_fSecs1SentQueue = null;
        private FQueue<FEventArgsBase> m_fHsmsQueue = null;
        private string m_lastPortId = string.Empty;
        private UInt64 m_secs1RecvCount = 0;
        private UInt64 m_secs1SentCount = 0;
        private UInt64 m_hsmsRecvCount = 0;
        private UInt64 m_hsmsSentCount = 0;
        // --
        private FTerminalMessageBox m_fTermianlMessageBox = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FMainContainer(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------       

        public FMainContainer(
            FCntCore fCntCore
            )
            : this()
        {
            m_fCntCore = fCntCore;
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
                    m_fCntCore = null;
                }
            }

            m_disposed = true;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void openPort(
            )
        {
            string message = string.Empty;
            string appendLog = string.Empty;

            try
            {
                try
                {
                    m_fCntCore.fSecs1ToHsms.openHsms();
                }
                catch (Exception hsmsEx)
                {
                    message = "HSMS 통신 포트 Open이 실패했습니다. [Detail: " + hsmsEx.Message + "]";
                    displayMessage(message);
                    // --
                    appendLog = "Open, ConnectMode=<" + m_fCntCore.fOption.hsmsConnectMode.ToString() + ">, LocalIp=< " + m_fCntCore.fOption.hsmsLocalIp + ">, LocalPort=<" + m_fCntCore.fOption.hsmsLocalPort.ToString() + "> RemoteIp=<" + m_fCntCore.fOption.hsmsRemoteIp + ">, RemotePort=<" + m_fCntCore.fOption.hsmsRemotePort.ToString() + ">";
                    m_fCntCore.fSecs1ToHsms.writeAppLog(
                        FCommon.getAppLog("HsmsOpen", FResultCode.Error, message, appendLog)
                        );
                }

                // --

                try
                {
                    m_fCntCore.fSecs1ToHsms.openSecs1();
                }
                catch (Exception secs1Ex)
                {
                    message = "SECS1 통신 포트 Open이 실패했습니다. [Detail: " + secs1Ex.Message + "]";
                    displayMessage(message);
                    // --
                    appendLog = "Open, SerialPort=<" + m_fCntCore.fOption.secs1SerialPort + ">, Baud=<" + m_fCntCore.fOption.secs1Baud.ToString() + ">";
                    m_fCntCore.fSecs1ToHsms.writeAppLog(
                        FCommon.getAppLog("Secs1Open", FResultCode.Error, message, appendLog)
                        );
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

        private void closePort(
            )
        {
            try
            {
                m_fCntCore.fSecs1ToHsms.closeSecs1();
                m_fCntCore.fSecs1ToHsms.closeHsms();                
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

        private void displayMessage(
            string message
            )
        {
            StringBuilder sb = null;
            int length = 0;

            try
            {
                sb = new StringBuilder();
                sb.Append(lblMessage.Text);

                // --

                message = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "] " + message + Environment.NewLine;
                sb.Insert(0, message);

                // --

                if (sb.Length > 3000)
                {
                    length = 3000;
                }
                else
                {
                    length = sb.Length;
                }
                lblMessage.Text = sb.ToString(0, length);

                // --

                playSoundInformation();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                sb = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void playSoundBcr(
            )
        {
            SoundPlayer sp = null;

            try
            {
                sp = new SoundPlayer(Path.Combine(m_fCntCore.appPath, "bcr.wav"));
                sp.Play();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (sp != null)
                {
                    sp.Dispose();
                    sp = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void playSoundInformation(
            )
        {
            SoundPlayer sp = null;

            try
            {
                sp = new SoundPlayer(Path.Combine(m_fCntCore.appPath, "information.wav"));
                sp.Play();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (sp != null)
                {
                    sp.Dispose();
                    sp = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void playSoundMessage(
            )
        {
            SoundPlayer sp = null;

            try
            {
                sp = new SoundPlayer(Path.Combine(m_fCntCore.appPath, "message.wav"));
                sp.Play();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (sp != null)
                {
                    sp.Dispose();
                    sp = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procSecs1StateChanged(
            FSecs1StateChangedEventArgs fArgs
            )
        {
            Color ColorClosed = Color.White;
            Color ColorOpened = Color.OrangeRed;
            Color ColorConnected = Color.Gold;
            Color ColorSelected = Color.Lime;
            Color ColorOff = Color.Black;

            try
            {
                if (fArgs.fResult != FResultCode.Success)
                {
                    return;
                }

                // --

                lblSecs1State.Text = fArgs.fState.ToString();
                if (fArgs.fState == FCommunicationState.Closed)
                {
                    lblSecs1State.BackColor = ColorClosed;
                }
                else if (fArgs.fState == FCommunicationState.Opened)
                {
                    lblSecs1State.BackColor = ColorOpened;
                }
                else if (fArgs.fState == FCommunicationState.Connected)
                {
                    lblSecs1State.BackColor = ColorConnected;
                }
                else if (fArgs.fState == FCommunicationState.Selected)
                {
                    lblSecs1State.BackColor = ColorSelected;
                }

                // --

                if (fArgs.fState != FCommunicationState.Selected)
                {
                    lblSecs1RecvEnq.BackColor = ColorOff;
                    lblSecs1RecvEot.BackColor = ColorOff;
                    lblSecs1RecvBlock.BackColor = ColorOff;
                    lblSecs1RecvAck.BackColor = ColorOff;
                    lblSecs1RecvAck.BackColor = ColorOff;
                    // --
                    lblSecs1SentEnq.BackColor = ColorOff;
                    lblSecs1SentEot.BackColor = ColorOff;
                    lblSecs1SentBlock.BackColor = ColorOff;
                    lblSecs1SentAck.BackColor = ColorOff;
                    lblSecs1SentAck.BackColor = ColorOff;
                    // --
                    m_secs1RecvCount = 0;
                    m_secs1SentCount = 0;
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

        private void procSecs1ErrorRaised(
            FSecs1ErrorRaisedEventArgs fArgs
            )
        {
            string message = string.Empty;

            try
            {
                message = "SECS1에서 오류가 발생했습니다. [Deatil: " + fArgs.errorMessage + "]";
                displayMessage(message);
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

        private void procSecs1TimeoutRaised(
            FSecs1TimeoutRaisedEventArgs fArgs
            )
        {
            string message = string.Empty;

            try
            {               
                message = "SECS1에서 타임아웃이 발생했습니다. [Deatil: " + fArgs.errorMessage + "]";
                displayMessage(message);
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

        private void procSecs1HandshakeReceived(
            FSecs1HandshakeReceivedEventArgs fArgs
            )
        {
            try
            {
                if (fArgs.fResult != FResultCode.Success)
                {
                    return;
                }

                // --

                if (fArgs.fHandshakeCode == FSecs1HandshakeCode.ENQ)
                {
                    m_fSecs1RecvQueue.enqueue(fArgs);
                }
                else if (
                    fArgs.fHandshakeCode == FSecs1HandshakeCode.EOT ||
                    fArgs.fHandshakeCode == FSecs1HandshakeCode.ACK ||
                    fArgs.fHandshakeCode == FSecs1HandshakeCode.NAK
                    )
                {
                    m_fSecs1SentQueue.enqueue(fArgs);
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

        private void procSecs1HandshakeSent(
            FSecs1HandshakeSentEventArgs fArgs
            )
        {
            try
            {
                if (fArgs.fResult != FResultCode.Success)
                {
                    return;
                }

                // --

                if (fArgs.fHandshakeCode == FSecs1HandshakeCode.ENQ)
                {
                    m_fSecs1SentQueue.enqueue(fArgs);
                }
                else if (
                    fArgs.fHandshakeCode == FSecs1HandshakeCode.EOT ||
                    fArgs.fHandshakeCode == FSecs1HandshakeCode.ACK ||
                    fArgs.fHandshakeCode == FSecs1HandshakeCode.NAK
                    )
                {
                    m_fSecs1RecvQueue.enqueue(fArgs);
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

        private void procSecs1BlockReceived(
            FSecs1BlockReceivedEventArgs fArgs
            )
        {
            try
            {
                if (fArgs.fResult != FResultCode.Success)
                {
                    return;
                }

                // --

                m_fSecs1RecvQueue.enqueue(fArgs);
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

        private void procSecs1BlockSent(
            FSecs1BlockSentEventArgs fArgs
            )
        {
            try
            {
                if (fArgs.fResult != FResultCode.Success)
                {
                    return;
                }

                // --

                m_fSecs1SentQueue.enqueue(fArgs);
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

        private void procSecs1DataMessageReceived(
            FSecs1DataMessageReceivedEventArgs fArgs
            )
        {
            try
            {
                if (fArgs.fResult != FResultCode.Success)
                {
                    return;
                }

                // --

                m_secs1RecvCount++;
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

        private void procSecs1DataMessageSent(
            FSecs1DataMessageSentEventArgs fArgs
            )
        {
            try
            {
                if (fArgs.fResult != FResultCode.Success)
                {
                    return;
                }

                // --

                m_secs1SentCount++;
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

        private void procHsmsStateChanged(
            FHsmsStateChangedEventArgs fArgs
            )
        {
            Color ColorClosed = Color.White;
            Color ColorOpened = Color.OrangeRed;
            Color ColorConnected = Color.Gold;
            Color ColorSelected = Color.Lime;
            Color ColorOff = Color.Black;
            Color ColorOffCtrlMode = Color.White;
            
            try
            {
                if (fArgs.fResult != FResultCode.Success)
                {
                    return;
                }

                // --

                lblHsmsState.Text = fArgs.fState.ToString();
                if (fArgs.fState == FCommunicationState.Closed)
                {
                    lblHsmsState.BackColor = ColorClosed;
                }
                else if (fArgs.fState == FCommunicationState.Opened)
                {
                    lblHsmsState.BackColor = ColorOpened;
                }
                else if (fArgs.fState == FCommunicationState.Connected)
                {
                    lblHsmsState.BackColor = ColorConnected;
                }
                else if (fArgs.fState == FCommunicationState.Selected)
                {
                    lblHsmsState.BackColor = ColorSelected;
                }

                // --

                if (fArgs.fState != FCommunicationState.Selected)
                {
                    lblHsmsRecv.BackColor = ColorOff;
                    lblHsmsSent.BackColor = ColorOff;
                    // --
                    lblOffline.BackColor = ColorOffCtrlMode;
                    lblLocal.BackColor = ColorOffCtrlMode;
                    lblRemote.BackColor = ColorOffCtrlMode;
                    // --
                    m_hsmsRecvCount = 0;
                    m_hsmsSentCount = 0;
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

        private void procHsmsErrorRaised(
            FHsmsErrorRaisedEventArgs fArgs
            )
        {
            string message = string.Empty;

            try
            {
                message = "HSMS에서 오류가 발생했습니다. [Deatil: " + fArgs.errorMessage + "]";
                displayMessage(message);
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

        private void procHsmsTimeoutRaised(
            FHsmsTimeoutRaisedEventArgs fArgs
            )
        {
            string message = string.Empty;

            try
            {
                message = "HSMS에서 타임아웃이 발생했습니다. [Deatil: " + fArgs.errorMessage + "]";
                displayMessage(message);
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

        private void procHsmsControlMessageReceived(
            FHsmsControlMessageReceivedEventArgs fArgs
            )
        {
            try
            {
                if (fArgs.fResult != FResultCode.Success)
                {
                    return;
                }

                // --

                m_fHsmsQueue.enqueue(fArgs);
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

        private void procHsmsControlMessageSent(
            FHsmsControlMessageSentEventArgs fArgs
            )
        {
            try
            {
                if (fArgs.fResult != FResultCode.Success)
                {
                    return;
                }

                // --

                m_fHsmsQueue.enqueue(fArgs);
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

        private void procHsmsDataMessageReceived(
            FHsmsDataMessageReceivedEventArgs fArgs
            )
        {
            try
            {
                if (fArgs.fResult != FResultCode.Success)
                {
                    return;
                }

                // --

                m_fHsmsQueue.enqueue(fArgs);

                // --

                m_hsmsRecvCount++;
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

        private void procHsmsDataMessageSent(
            FHsmsDataMessageSentEventArgs fArgs
            )
        {
            try
            {
                if (fArgs.fResult != FResultCode.Success)
                {
                    return;
                }

                // --

                m_fHsmsQueue.enqueue(fArgs);

                // --

                m_hsmsSentCount++;
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

        private void procHsmsInterceptingDataMessageReceived(
            FHsmsInterceptingDataMessageReceivedEventArgs fArgs
            )
        {
            Color ColorOn = Color.OrangeRed;
            Color ColorOff = Color.White;
            Color ColorOffBcr = Color.Black;
            Color ColorLCMP = Color.Silver;
            Color ColorMVIN = Color.Lime;
            Color ColorMVOU = Color.Gold;
            Color ColorUCMP = Color.White;
            Color ColorOffline = Color.OrangeRed;
            Color ColorLocal = Color.Gold;
            Color ColorRemote = Color.Lime;

            // --

            FXmlNode fXmlNodeSmg = null;
            string s = string.Empty;
            string f = string.Empty;
            string rcmd = string.Empty;
            string portId = string.Empty;
            string lotId = string.Empty;
            string text = string.Empty;
            string appendLog = string.Empty;

            try
            {
                fXmlNodeSmg = fArgs.fSecsDataMessage.convertToXmlNode();
                // --
                s = fXmlNodeSmg.get_attrVal(FSecsTag.A_Stream, string.Empty);
                f = fXmlNodeSmg.get_attrVal(FSecsTag.A_Function, string.Empty);

                // --

                if (s == "2" && f == "101")
                {
                    #region S2F101

                    rcmd = fXmlNodeSmg.fChildNodes[0].fChildNodes[0].get_attrVal(FSecsTag.A_Value, string.Empty);
                    portId = fXmlNodeSmg.fChildNodes[0].fChildNodes[1].fChildNodes[0].fChildNodes[0].get_attrVal(FSecsTag.A_Value, string.Empty);
                    lotId = fXmlNodeSmg.fChildNodes[0].fChildNodes[1].fChildNodes[0].fChildNodes[1].get_attrVal(FSecsTag.A_Value, string.Empty);
                    // --
                    if (rcmd == "LCMP")
                    {
                        // ***
                        // PORT ARRIVED
                        // ***
                        appendLog = "PortArrived, Rcmd=<" + rcmd + ">, PortId=<" + portId + ">, LotId=<" + lotId + ">";
                        m_fCntCore.fSecs1ToHsms.writeAppLog(
                            FCommon.getAppLog("PortStateChanged", FResultCode.Success, string.Empty, appendLog)
                            );

                        // --

                        if (portId == "1")
                        {
                            lblPort1.BackColor = ColorOffBcr;
                            lblLot1.BackColor = ColorOffBcr;
                            lblLot1.Text = string.Empty;
                            // --
                            lblAsignLot1.Text = lotId;
                            lblAsignLot1.BackColor = ColorLCMP;
                            picPort1.BackgroundImage = Properties.Resources.LotArrived;
                        }
                        else if (portId == "2")
                        {
                            lblPort2.BackColor = ColorOffBcr;
                            lblLot2.BackColor = ColorOffBcr;
                            lblLot2.Text = string.Empty;
                            // --
                            lblAsignLot2.Text = lotId;
                            lblAsignLot2.BackColor = ColorLCMP;
                            picPort2.BackgroundImage = Properties.Resources.LotArrived;
                        }
                        else if (portId == "3")
                        {
                            lblPort3.BackColor = ColorOffBcr;
                            lblLot3.BackColor = ColorOffBcr;
                            lblLot3.Text = string.Empty;
                            // --
                            lblAsignLot3.Text = lotId;
                            lblAsignLot3.BackColor = ColorLCMP;
                            picPort3.BackgroundImage = Properties.Resources.LotArrived;
                        }
                        else if (portId == "4")
                        {
                            lblPort4.BackColor = ColorOffBcr;
                            lblLot4.BackColor = ColorOffBcr;
                            lblLot4.Text = string.Empty;
                            // --
                            lblAsignLot4.Text = lotId;
                            lblAsignLot4.BackColor = ColorLCMP;
                            picPort4.BackgroundImage = Properties.Resources.LotArrived;
                        }
                    }
                    else if (rcmd == "MVIN")
                    {
                        // ***
                        // MOVE IN
                        // ***
                        appendLog = "MoveIn, Rcmd=<" + rcmd + ">, PortId=<" + portId + ">, LotId=<" + lotId + ">";
                        m_fCntCore.fSecs1ToHsms.writeAppLog(
                            FCommon.getAppLog("PortStateChanged", FResultCode.Success, string.Empty, appendLog)
                            );

                        // --

                        if (portId == "1")
                        {
                            lblAsignLot1.Text = lotId;
                            lblAsignLot1.BackColor = ColorMVIN;
                            picPort1.BackgroundImage = Properties.Resources.LotMoveIn;
                        }
                        else if (portId == "2")
                        {
                            lblAsignLot2.Text = lotId;
                            lblAsignLot2.BackColor = ColorMVIN;
                            picPort2.BackgroundImage = Properties.Resources.LotMoveIn;
                        }
                        else if (portId == "3")
                        {
                            lblAsignLot3.Text = lotId;
                            lblAsignLot3.BackColor = ColorMVIN;
                            picPort3.BackgroundImage = Properties.Resources.LotMoveIn;
                        }
                        else if (portId == "4")
                        {
                            lblAsignLot4.Text = lotId;
                            lblAsignLot4.BackColor = ColorMVIN;
                            picPort4.BackgroundImage = Properties.Resources.LotMoveIn;
                        }
                    }
                    else if (rcmd == "MVOU")
                    {
                        // ***
                        // MOVE OUT
                        // ***
                        appendLog = "MoveOut, Rcmd=<" + rcmd + ">, PortId=<" + portId + ">, LotId=<" + lotId + ">";
                        m_fCntCore.fSecs1ToHsms.writeAppLog(
                            FCommon.getAppLog("PortStateChanged", FResultCode.Success, string.Empty, appendLog)
                            );

                        // --
                        
                        if (portId == "1")
                        {
                            lblAsignLot1.Text = lotId;
                            lblAsignLot1.BackColor = ColorMVOU;
                            picPort1.BackgroundImage = Properties.Resources.LotMoveOut;
                        }
                        else if (portId == "2")
                        {
                            lblAsignLot2.Text = lotId;
                            lblAsignLot2.BackColor = ColorMVOU;
                            picPort2.BackgroundImage = Properties.Resources.LotMoveOut;
                        }
                        else if (portId == "3")
                        {
                            lblAsignLot3.Text = lotId;
                            lblAsignLot3.BackColor = ColorMVOU;
                            picPort3.BackgroundImage = Properties.Resources.LotMoveOut;
                        }
                        else if (portId == "4")
                        {
                            lblAsignLot4.Text = lotId;
                            lblAsignLot4.BackColor = ColorMVOU;
                            picPort4.BackgroundImage = Properties.Resources.LotMoveOut;
                        }
                    }
                    else if (rcmd == "UCMP")
                    {
                        // ***
                        // PORT UNLOAD
                        // ***
                        appendLog = "PortUnload, Rcmd=<" + rcmd + ">, PortId=<" + portId + ">, LotId=<" + lotId + ">";
                        m_fCntCore.fSecs1ToHsms.writeAppLog(
                            FCommon.getAppLog("PortStateChanged", FResultCode.Success, string.Empty, appendLog)
                            );

                        // --

                        if (portId == "1")
                        {
                            lblAsignLot1.Text = string.Empty;
                            lblAsignLot1.BackColor = ColorUCMP;
                            picPort1.BackgroundImage = Properties.Resources.LotUnload;
                        }
                        else if (portId == "2")
                        {
                            lblAsignLot2.Text = string.Empty;
                            lblAsignLot2.BackColor = ColorUCMP;
                            picPort2.BackgroundImage = Properties.Resources.LotUnload;
                        }
                        else if (portId == "3")
                        {
                            lblAsignLot3.Text = string.Empty;
                            lblAsignLot3.BackColor = ColorUCMP;
                            picPort3.BackgroundImage = Properties.Resources.LotUnload;
                        }
                        else if (portId == "4")
                        {
                            lblAsignLot4.Text = string.Empty;
                            lblAsignLot4.BackColor = ColorUCMP;
                            picPort4.BackgroundImage = Properties.Resources.LotUnload;
                        }
                    }

                    #endregion
                }
                else if (s == "2" && f == "103")
                {
                    #region S2F103

                    rcmd = fXmlNodeSmg.fChildNodes[0].fChildNodes[0].get_attrVal(FSecsTag.A_Value, string.Empty);
                    // --
                    if (rcmd == "OF")
                    {
                        appendLog = "Offline, Rcmd=<" + rcmd + ">";
                        m_fCntCore.fSecs1ToHsms.writeAppLog(
                            FCommon.getAppLog("ControlModeChanged", FResultCode.Success, string.Empty, appendLog)
                            );

                        // --

                        lblOffline.BackColor = ColorOffline;
                        lblLocal.BackColor = ColorOff;
                        lblRemote.BackColor = ColorOff;
                    }
                    else if (rcmd == "OL")
                    {
                        appendLog = "OnlineLocal, Rcmd=<" + rcmd + ">";
                        m_fCntCore.fSecs1ToHsms.writeAppLog(
                            FCommon.getAppLog("ControlModeChanged", FResultCode.Success, string.Empty, appendLog)
                            );

                        // --

                        lblOffline.BackColor = ColorOff;
                        lblLocal.BackColor = ColorLocal;
                        lblRemote.BackColor = ColorOff;
                    }
                    else if (rcmd == "OR")
                    {
                        appendLog = "OnlineRemote, Rcmd=<" + rcmd + ">";
                        m_fCntCore.fSecs1ToHsms.writeAppLog(
                            FCommon.getAppLog("ControlModeChanged", FResultCode.Success, string.Empty, appendLog)
                            );

                        // --

                        lblOffline.BackColor = ColorOff;
                        lblLocal.BackColor = ColorOff;
                        lblRemote.BackColor = ColorRemote;
                    }

                    #endregion
                }
                else if (s == "10" && f == "101")
                {
                    #region S10F101

                    foreach (FXmlNode x in fXmlNodeSmg.fChildNodes[0].fChildNodes[1].fChildNodes)
                    {
                        text += x.get_attrVal(FSecsTag.A_Value, string.Empty) + Environment.NewLine;
                    }
                    
                    // --
                    
                    if (text != string.Empty)
                    {
                        writeTerminalMessage(text);


                        // --
                        // 삭제 예정

                        //appendLog = "Text=<" + text + ">";
                        //m_fBcrCore.fSecs1ToHsms.writeAppLog(
                        //    FCommon.getAppLog("TerminalMessageReceived", FResultCode.Success, string.Empty, appendLog)
                        //    );

                        //// --

                        //displayMessage(text);
                    }                    

                    #endregion
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

        private void procBcrRead(
            string bcrData
            )
        {
            Color ColorOn = Color.OrangeRed;
            Color ColorOff = Color.Black;
            string message = string.Empty;
            string appendLog = string.Empty;

            try
            {
                if (bcrData == string.Empty)
                {
                    return;
                }

                // --

                if (bcrData.Length == 1)
                {
                    #region Port ID Read

                    if (bcrData != "1" && bcrData != "2" && bcrData != "3" && bcrData != "4")
                    {
                        message = "BCR Port ID가 잘 못 되었습니다. [Port ID: " + bcrData + "]";
                        displayMessage(message);
                        // --
                        appendLog = "PortIdRead, PortId=<" + bcrData + ">";
                        m_fCntCore.fSecs1ToHsms.writeAppLog(
                            FCommon.getAppLog("BcrRead", FResultCode.Error, message, appendLog)
                            );
                        return;
                    }

                    if (m_fCntCore.fSecs1ToHsms.fHsmsState != FCommunicationState.Selected)
                    {
                        message = "HSMS 통신이 연결되어 있지 않아 BCR Port ID를 전송하지 못 했습니다. [Port ID: " + bcrData + "]";
                        displayMessage(message);
                        // --
                        appendLog = "PortIdRead, PortId=<" + bcrData + ">";
                        m_fCntCore.fSecs1ToHsms.writeAppLog(
                            FCommon.getAppLog("BcrRead", FResultCode.Error, message, appendLog)
                            );
                        return;
                    }

                    // --

                    appendLog = "PortIdRead, PortId=<" + bcrData + ">";
                    m_fCntCore.fSecs1ToHsms.writeAppLog(
                        FCommon.getAppLog("BcrRead", FResultCode.Success, string.Empty, appendLog)
                        );

                    // --

                    sendBcrPortId(bcrData);
                    
                    // --

                    playSoundBcr();

                    // --

                    if (bcrData == "1")
                    {
                        lblPort1.BackColor = ColorOn;
                        // --
                        lblLot1.BackColor = ColorOff;
                        lblLot1.Text = string.Empty;
                    }
                    else if (bcrData == "2")
                    {
                        lblPort2.BackColor = ColorOn;
                        // --
                        lblLot2.BackColor = ColorOff;
                        lblLot2.Text = string.Empty;
                    }
                    else if (bcrData == "3")
                    {
                        lblPort3.BackColor = ColorOn;
                        // --
                        lblLot3.BackColor = ColorOff;
                        lblLot3.Text = string.Empty;
                    }
                    else if (bcrData == "4")
                    {
                        lblPort4.BackColor = ColorOn;
                        // --
                        lblLot4.BackColor = ColorOff;
                        lblLot4.Text = string.Empty;
                    }

                    // --

                    m_lastPortId = bcrData;

                    // --

                    // *** 
                    // Lot ID가 없는 포트 초기화
                    // ***
                    if (m_lastPortId != "1")
                    {
                        if (lblLot1.Text == string.Empty)
                        {
                            lblPort1.BackColor = ColorOff;
                        }
                    }
                    if (m_lastPortId != "2")
                    {
                        if (lblLot2.Text == string.Empty)
                        {
                            lblPort2.BackColor = ColorOff;
                        }
                    }
                    if (m_lastPortId != "3")
                    {
                        if (lblLot3.Text == string.Empty)
                        {
                            lblPort3.BackColor = ColorOff;
                        }
                    }
                    if (m_lastPortId != "4")
                    {
                        if (lblLot4.Text == string.Empty)
                        {
                            lblPort4.BackColor = ColorOff;
                        }
                    }

                    #endregion
                }
                else
                {
                    #region Lot ID Read

                    if (m_lastPortId == string.Empty)
                    {
                        message = "BCR Port ID가 Read 되지 않았습니다. [Lot ID: " + bcrData + "]";
                        displayMessage(message);
                        // --
                        appendLog = "LotIdRead, LotId=<" + bcrData + ">";
                        m_fCntCore.fSecs1ToHsms.writeAppLog(
                            FCommon.getAppLog("BcrRead", FResultCode.Error, message, appendLog)
                            );
                        return;
                    }

                    if (m_fCntCore.fSecs1ToHsms.fHsmsState != FCommunicationState.Selected)
                    {
                        message = "HSMS 통신이 연결되어 있지 않아 BCR Lot ID를 전송하지 못 했습니다. [Lot ID: " + bcrData + "]";
                        displayMessage(message);
                        // --
                        appendLog = "LotIdRead, PortId=<" + m_lastPortId + ">, LotId=<" + bcrData + ">";
                        m_fCntCore.fSecs1ToHsms.writeAppLog(
                            FCommon.getAppLog("BcrRead", FResultCode.Error, message, appendLog)
                            );
                        return;
                    }

                    // --

                    appendLog = "LotIdRead, PortId=<" + m_lastPortId + ">, LotId=<" + bcrData + ">";
                    m_fCntCore.fSecs1ToHsms.writeAppLog(
                        FCommon.getAppLog("BcrRead", FResultCode.Success, string.Empty, appendLog)
                        );

                    // --

                    sendBcrLotId(bcrData);

                    // --

                    playSoundBcr();

                    // --

                    if (m_lastPortId == "1")
                    {
                        lblLot1.BackColor = ColorOn;
                        lblLot1.Text = bcrData;
                    }
                    else if (m_lastPortId == "2")
                    {
                        lblLot2.BackColor = ColorOn;
                        lblLot2.Text = bcrData;
                    }
                    else if (m_lastPortId == "3")
                    {
                        lblLot3.BackColor = ColorOn;
                        lblLot3.Text = bcrData;
                    }
                    else if (m_lastPortId == "4")
                    {
                        lblLot4.BackColor = ColorOn;
                        lblLot4.Text = bcrData;
                    }

                    // --

                    // ***
                    // Last Port ID 초기화
                    // ***
                    m_lastPortId = string.Empty;

                    #endregion
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

        private void sendBcrPortId(
            string portId
            )
        {
            FXmlDocument fXmlDoc = null;
            FXmlNode fXmlNodeSmg = null;
            FXmlNode fXmlNodeSitList01 = null;
            FXmlNode fXmlNodeSitList02 = null;
            FXmlNode fXmlNodeSitList03 = null;
            FXmlNode fXmlNodeSitList04 = null;
            FXmlNode fXmlNodeSitValue = null;
            FSecsDataMessageTransfer fSecsDataMessageTransfer = null;

            try
            {
                // -- 
                // S6F101
                // --
                // L_01
                //   A DATAID (1)
                //   A CEID (10000)
                //   L_02
                //     L_03
                //       A RPTID (100)
                //       L_04
                //         A V (PORT ID)
                // --

                fXmlDoc = new FXmlDocument();
                fXmlDoc.preserveWhiteSpace = false;

                // --

                fXmlNodeSmg = fXmlDoc.createNode(FSecsTag.E_SecsMessage);
                fXmlNodeSmg.set_attrVal(FSecsTag.A_SessionId, m_fCntCore.fSecs1ToHsms.fHsmsConfig.sessionId.ToString());
                fXmlNodeSmg.set_attrVal(FSecsTag.A_Stream, "6");
                fXmlNodeSmg.set_attrVal(FSecsTag.A_Function, "101");
                fXmlNodeSmg.set_attrVal(FSecsTag.A_WBit, false.ToString());

                // --

                // ***
                // L_01
                // ***
                fXmlNodeSitList01 = fXmlDoc.createNode(FSecsTag.E_SecsItem);
                fXmlNodeSitList01.set_attrVal(FSecsTag.A_Format, FFormat.L.ToString());
                fXmlNodeSmg.appendChild(fXmlNodeSitList01);

                // --

                // ***
                // DATAID
                // *** 
                fXmlNodeSitValue = fXmlDoc.createNode(FSecsTag.E_SecsItem);
                fXmlNodeSitValue.set_attrVal(FSecsTag.A_Format, FFormat.A.ToString());
                fXmlNodeSitValue.set_attrVal(FSecsTag.A_Value, "1");
                fXmlNodeSitList01.appendChild(fXmlNodeSitValue);

                // --

                // ***
                // CEID
                // *** 
                fXmlNodeSitValue = fXmlDoc.createNode(FSecsTag.E_SecsItem);
                fXmlNodeSitValue.set_attrVal(FSecsTag.A_Format, FFormat.A.ToString());
                fXmlNodeSitValue.set_attrVal(FSecsTag.A_Value, "10000");
                fXmlNodeSitList01.appendChild(fXmlNodeSitValue);

                // --

                // ***
                // L_02
                // ***
                fXmlNodeSitList02 = fXmlDoc.createNode(FSecsTag.E_SecsItem);
                fXmlNodeSitList02.set_attrVal(FSecsTag.A_Format, FFormat.L.ToString());
                fXmlNodeSitList01.appendChild(fXmlNodeSitList02);

                // --

                // ***
                // L_03
                // ***
                fXmlNodeSitList03 = fXmlDoc.createNode(FSecsTag.E_SecsItem);
                fXmlNodeSitList03.set_attrVal(FSecsTag.A_Format, FFormat.L.ToString());
                fXmlNodeSitList02.appendChild(fXmlNodeSitList03);

                // --

                // ***
                // RPTID
                // *** 
                fXmlNodeSitValue = fXmlDoc.createNode(FSecsTag.E_SecsItem);
                fXmlNodeSitValue.set_attrVal(FSecsTag.A_Format, FFormat.A.ToString());
                fXmlNodeSitValue.set_attrVal(FSecsTag.A_Value, "100");
                fXmlNodeSitList03.appendChild(fXmlNodeSitValue);

                // --

                // ***
                // L_04
                // ***
                fXmlNodeSitList04 = fXmlDoc.createNode(FSecsTag.E_SecsItem);
                fXmlNodeSitList04.set_attrVal(FSecsTag.A_Format, FFormat.L.ToString());
                fXmlNodeSitList03.appendChild(fXmlNodeSitList04);

                // --

                // ***
                // PORT ID
                // *** 
                fXmlNodeSitValue = fXmlDoc.createNode(FSecsTag.E_SecsItem);
                fXmlNodeSitValue.set_attrVal(FSecsTag.A_Format, FFormat.A.ToString());
                fXmlNodeSitValue.set_attrVal(FSecsTag.A_Value, portId);
                fXmlNodeSitList04.appendChild(fXmlNodeSitValue);

                // --

                fSecsDataMessageTransfer = new FSecsDataMessageTransfer(m_fCntCore.fSecs1ToHsms, fXmlNodeSmg);
                fSecsDataMessageTransfer.resetSystembytes();
                // -- 
                m_fCntCore.fSecs1ToHsms.sendHsmsDataMessage(fSecsDataMessageTransfer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fXmlDoc = null;
                fXmlNodeSmg = null;
                fXmlNodeSitList01 = null;
                fXmlNodeSitList02 = null;
                fXmlNodeSitList03 = null;
                fXmlNodeSitList04 = null;
                fXmlNodeSitValue = null;
                fSecsDataMessageTransfer = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void sendBcrLotId(
            string lotId
            )
        {
            FXmlDocument fXmlDoc = null;
            FXmlNode fXmlNodeSmg = null;
            FXmlNode fXmlNodeSitList01 = null;
            FXmlNode fXmlNodeSitList02 = null;
            FXmlNode fXmlNodeSitList03 = null;
            FXmlNode fXmlNodeSitList04 = null;
            FXmlNode fXmlNodeSitValue = null;
            FSecsDataMessageTransfer fSecsDataMessageTransfer = null;

            try
            {
                // -- 
                // S6F101
                // --
                // L_01
                //   A DATAID (1)
                //   A CEID (20000)
                //   L_02
                //     L_03
                //       A RPTID (100)
                //       L_04
                //         A V (PORT ID)
                //         A V (LOT ID)
                // --

                fXmlDoc = new FXmlDocument();
                fXmlDoc.preserveWhiteSpace = false;

                // --

                fXmlNodeSmg = fXmlDoc.createNode(FSecsTag.E_SecsMessage);
                fXmlNodeSmg.set_attrVal(FSecsTag.A_SessionId, m_fCntCore.fSecs1ToHsms.fHsmsConfig.sessionId.ToString());
                fXmlNodeSmg.set_attrVal(FSecsTag.A_Stream, "6");
                fXmlNodeSmg.set_attrVal(FSecsTag.A_Function, "101");
                fXmlNodeSmg.set_attrVal(FSecsTag.A_WBit, false.ToString());

                // --

                // ***
                // L_01
                // ***
                fXmlNodeSitList01 = fXmlDoc.createNode(FSecsTag.E_SecsItem);
                fXmlNodeSitList01.set_attrVal(FSecsTag.A_Format, FFormat.L.ToString());
                fXmlNodeSmg.appendChild(fXmlNodeSitList01);

                // --

                // ***
                // DATAID
                // *** 
                fXmlNodeSitValue = fXmlDoc.createNode(FSecsTag.E_SecsItem);
                fXmlNodeSitValue.set_attrVal(FSecsTag.A_Format, FFormat.A.ToString());
                fXmlNodeSitValue.set_attrVal(FSecsTag.A_Value, "1");
                fXmlNodeSitList01.appendChild(fXmlNodeSitValue);

                // --

                // ***
                // CEID
                // *** 
                fXmlNodeSitValue = fXmlDoc.createNode(FSecsTag.E_SecsItem);
                fXmlNodeSitValue.set_attrVal(FSecsTag.A_Format, FFormat.A.ToString());
                fXmlNodeSitValue.set_attrVal(FSecsTag.A_Value, "20000");
                fXmlNodeSitList01.appendChild(fXmlNodeSitValue);

                // --

                // ***
                // L_02
                // ***
                fXmlNodeSitList02 = fXmlDoc.createNode(FSecsTag.E_SecsItem);
                fXmlNodeSitList02.set_attrVal(FSecsTag.A_Format, FFormat.L.ToString());
                fXmlNodeSitList01.appendChild(fXmlNodeSitList02);

                // --

                // ***
                // L_03
                // ***
                fXmlNodeSitList03 = fXmlDoc.createNode(FSecsTag.E_SecsItem);
                fXmlNodeSitList03.set_attrVal(FSecsTag.A_Format, FFormat.L.ToString());
                fXmlNodeSitList02.appendChild(fXmlNodeSitList03);

                // --

                // ***
                // RPTID
                // *** 
                fXmlNodeSitValue = fXmlDoc.createNode(FSecsTag.E_SecsItem);
                fXmlNodeSitValue.set_attrVal(FSecsTag.A_Format, FFormat.A.ToString());
                fXmlNodeSitValue.set_attrVal(FSecsTag.A_Value, "100");
                fXmlNodeSitList03.appendChild(fXmlNodeSitValue);

                // --

                // ***
                // L_04
                // ***
                fXmlNodeSitList04 = fXmlDoc.createNode(FSecsTag.E_SecsItem);
                fXmlNodeSitList04.set_attrVal(FSecsTag.A_Format, FFormat.L.ToString());
                fXmlNodeSitList03.appendChild(fXmlNodeSitList04);

                // --

                // ***
                // PORT ID
                // *** 
                fXmlNodeSitValue = fXmlDoc.createNode(FSecsTag.E_SecsItem);
                fXmlNodeSitValue.set_attrVal(FSecsTag.A_Format, FFormat.A.ToString());
                fXmlNodeSitValue.set_attrVal(FSecsTag.A_Value, m_lastPortId);
                fXmlNodeSitList04.appendChild(fXmlNodeSitValue);

                // --

                // ***
                // LOT ID
                // *** 
                fXmlNodeSitValue = fXmlDoc.createNode(FSecsTag.E_SecsItem);
                fXmlNodeSitValue.set_attrVal(FSecsTag.A_Format, FFormat.A.ToString());
                fXmlNodeSitValue.set_attrVal(FSecsTag.A_Value, lotId);
                fXmlNodeSitList04.appendChild(fXmlNodeSitValue);

                // --

                fSecsDataMessageTransfer = new FSecsDataMessageTransfer(m_fCntCore.fSecs1ToHsms, fXmlNodeSmg);
                fSecsDataMessageTransfer.resetSystembytes();
                // -- 
                m_fCntCore.fSecs1ToHsms.sendHsmsDataMessage(fSecsDataMessageTransfer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fXmlDoc = null;
                fXmlNodeSmg = null;
                fXmlNodeSitList01 = null;
                fXmlNodeSitList02 = null;
                fXmlNodeSitList03 = null;
                fXmlNodeSitList04 = null;
                fXmlNodeSitValue = null;
                fSecsDataMessageTransfer = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void controlTermianlMessageBox(
            )
        {
            try
            {
                if (m_fTermianlMessageBox == null)
                {
                    m_fTermianlMessageBox = new FTerminalMessageBox(m_fCntCore);
                    // --
                    m_fTermianlMessageBox.Location = new Point(this.Location.X, this.Location.Y + 36);
                    m_fTermianlMessageBox.Width = this.Width;
                    m_fTermianlMessageBox.Height = this.Height - 140;
                    // --
                    m_fTermianlMessageBox.Show(this);

                    // --

                    btnPreviousMessage.Visible = true;
                    btnNextMessage.Visible = true;

                    // --

                    m_fTermianlMessageBox.initMessage();
                }
                else if (m_fTermianlMessageBox.Visible)
                {
                    m_fTermianlMessageBox.Visible = false;
                    btnPreviousMessage.Visible = false;
                    btnNextMessage.Visible = false;
                }
                else
                {
                    m_fTermianlMessageBox.Location = new Point(this.Location.X, this.Location.Y + 36);
                    m_fTermianlMessageBox.Width = this.Width;
                    m_fTermianlMessageBox.Height = this.Height - 140;

                    // --

                    m_fTermianlMessageBox.initMessage();

                    // --

                    m_fTermianlMessageBox.Visible = true;
                    btnPreviousMessage.Visible = true;
                    btnNextMessage.Visible = true;
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

        private void writeTerminalMessage_old(
            string message
            )
        {
            try
            {
                if (m_fTermianlMessageBox == null)
                {
                    m_fTermianlMessageBox = new FTerminalMessageBox(m_fCntCore);
                    // --
                    m_fTermianlMessageBox.Location = new Point(this.Location.X, this.Location.Y + 36);
                    m_fTermianlMessageBox.Width = this.Width;
                    m_fTermianlMessageBox.Height = this.Height - 140;
                    // --
                    m_fTermianlMessageBox.Show(this);                         
                }                
                else
                {
                    m_fTermianlMessageBox.Visible = true;
                }
                // --
                btnPreviousMessage.Visible = true;
                btnNextMessage.Visible = true;

                // --

                m_fTermianlMessageBox.writeMessage(message);

                // --

                playSoundMessage();
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

        private void writeTerminalMessage(
            string message
            )
        {
            bool bcrFocused = false;

            try
            {
                bcrFocused = txtBcrRead.Focused;

                // --

                if (m_fTermianlMessageBox == null)
                {
                    m_fTermianlMessageBox = new FTerminalMessageBox(m_fCntCore);
                    // --
                    m_fTermianlMessageBox.Location = new Point(this.Location.X, this.Location.Y + 36);
                    m_fTermianlMessageBox.Width = this.Width;
                    m_fTermianlMessageBox.Height = this.Height - 140;
                    // --
                    m_fTermianlMessageBox.Show(this);
                    m_fTermianlMessageBox.Visible = false;
                }
                
                // --

                m_fTermianlMessageBox.writeMessage(message);
                // --
                playSoundMessage();

                // --

                if (bcrFocused)
                {
                    m_fTermianlMessageBox.Visible = true;
                    // --
                    btnPreviousMessage.Visible = true;
                    btnNextMessage.Visible = true;
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

        public void focusBcrRead(
            )
        {
            try
            {
                txtBcrRead.Focus();
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

        #region FMainContainer Form Event Handdler

        private void FMainContainer_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;

                // ***
                // FAmate BCR Start Log write
                // ***
                m_fCntCore.fSecs1ToHsms.writeAppLog(FCommon.getAppLog("FAmateBcrStart", FResultCode.Success, string.Empty, string.Empty));

                // --

                m_fSecs1RecvQueue = new FQueue<FEventArgsBase>();
                m_fSecs1SentQueue = new FQueue<FEventArgsBase>();
                m_fHsmsQueue = new FQueue<FEventArgsBase>();

                // --

                picPort1.BackgroundImage = Properties.Resources.LotUnload;
                picPort2.BackgroundImage = Properties.Resources.LotUnload;
                picPort3.BackgroundImage = Properties.Resources.LotUnload;
                picPort4.BackgroundImage = Properties.Resources.LotUnload;

                // --

                m_fEventHandler = new FEventHandler(m_fCntCore.fSecs1ToHsms, this);
                m_fEventHandler.EventRaised += new FEventRaisedEventHandler(m_fEventHandler_EventRaised);

                // --

                openPort();

                // --

                txtBcrRead.Focus();

                // --

                // ***
                // Main Timer Enabled
                // ***
                tmrMain.Enabled = true;

                // --

                #if !DEBUG
                Cursor.Hide();
                #endif
            }
            catch (Exception ex)
            {
                FCommon.showErrorMessageBox(this, ex);
            }
            finally
            {

            }
        }        

        //------------------------------------------------------------------------------------------------------------------------

        private void FMainContainer_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            string path = string.Empty;

            try
            {
                if (FCommon.showConfirmMessageBox(this, "FAmate BCR v4.5 프로그램을 종료하시겠습니까?") == System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

                // --

                tmrMain.Enabled = false;
  
                // --

                if (m_fCntCore != null && m_fCntCore.fSecs1ToHsms != null)
                {
                    closePort();
                }

                // --

                if (m_fEventHandler != null)
                {
                    m_fEventHandler.waitEventHandlingCompleted();

                    // --

                    m_fEventHandler.EventRaised -= new FEventRaisedEventHandler(m_fEventHandler_EventRaised);
                    // --
                    m_fEventHandler.Dispose();                    
                    m_fEventHandler = null;
                }

                if (m_fSecs1RecvQueue != null)
                {
                    m_fSecs1RecvQueue.Dispose();
                    m_fSecs1RecvQueue = null;
                }

                if (m_fSecs1SentQueue != null)
                {
                    m_fSecs1SentQueue.Dispose();
                    m_fSecs1SentQueue = null;
                }

                if (m_fHsmsQueue != null)
                {
                    m_fHsmsQueue.Dispose();
                    m_fHsmsQueue = null;
                }

                // --

                if (m_fTermianlMessageBox != null)
                {
                    m_fTermianlMessageBox.Dispose();
                    m_fTermianlMessageBox = null;
                }

                // --

                // ***
                // FAmate BCR Stop Log write
                // ***                
                m_fCntCore.fSecs1ToHsms.writeAppLog(FCommon.getAppLog("FAmateBcrStop", FResultCode.Success, string.Empty, string.Empty));

                // --

                #if !DEBUG
                Cursor.Show();
                #endif                
            }
            catch (Exception ex)
            {
                FCommon.showErrorMessageBox(this, ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region txtBcrRead Control Event Handler

        private void txtBcrRead_KeyDown(
            object sender,
            KeyEventArgs e
            )
        {
            string readData = string.Empty;

            try
            {
                if (m_fTermianlMessageBox != null && m_fTermianlMessageBox.Visible)
                {
                    m_fTermianlMessageBox.Visible = false;
                    btnPreviousMessage.Visible = false;
                    btnNextMessage.Visible = false;
                }

                // --

                if (e.KeyCode == Keys.Return)
                {
                    procBcrRead(txtBcrRead.Text);
                    txtBcrRead.Text = string.Empty;
                    e.SuppressKeyPress = true;
                }
                else if (e.KeyCode == Keys.LineFeed)
                {
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                FCommon.showErrorMessageBox(this, ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnMenu Control Event Handler

        private void btnMenu_Click(
            object sender, 
            EventArgs e
            )
        {
            FMenuSelector fMenuSelector = null;

            try
            {
                fMenuSelector = new FMenuSelector(m_fCntCore);
                fMenuSelector.ShowDialog();
            }
            catch (Exception ex)
            {
                FCommon.showErrorMessageBox(this, ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void btnMenu_Enter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                txtBcrRead.Focus();
            }
            catch (Exception ex)
            {
                FCommon.showErrorMessageBox(this, ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnClear Control EVent Handler

        private void btnClear_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                lblMessage.Text = string.Empty;
            }
            catch (Exception ex)
            {
                FCommon.showErrorMessageBox(this, ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void btnClear_Enter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                txtBcrRead.Focus();
            }
            catch (Exception ex)
            {
                FCommon.showErrorMessageBox(this, ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnExit Control Event Handler

        private void btnExit_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                FCommon.showErrorMessageBox(this, ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void btnExit_Enter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                txtBcrRead.Focus();
            }
            catch (Exception ex)
            {
                FCommon.showErrorMessageBox(this, ex);
            }
            finally
            {

            }
        }

        #endregion
        
        //------------------------------------------------------------------------------------------------------------------------

        #region tmrMain Control Event Handler

        private void tmrMain_Tick(
            object sender, 
            EventArgs e
            )
        {
            Color ColorOn = Color.OrangeRed;
            Color ColorOff = Color.Black;
            FSecs1HandshakeCode fHsc;
            FEventArgsBase fArgs = null;

            try
            {
                if (this.WindowState != FormWindowState.Minimized)
                {
                    #if !DEBUG
                    if (Form.ActiveForm == null)
                    {
                        this.Activate();
                    }
                    #endif
                }

                // --

                #region SECS1 Recv Queue

                fArgs = m_fSecs1RecvQueue.dequeue();
                if (m_fCntCore.fSecs1ToHsms.fSecs1State == FCommunicationState.Selected && fArgs != null)
                {
                    lblSecs1RecvEnq.BackColor = ColorOff;
                    lblSecs1RecvEot.BackColor = ColorOff;
                    lblSecs1RecvBlock.BackColor = ColorOff;
                    lblSecs1RecvAck.BackColor = ColorOff;
                    lblSecs1RecvNak.BackColor = ColorOff;

                    // --

                    if (fArgs.fEventId == FEventId.Secs1HandshakeReceived)
                    {
                        fHsc = ((FSecs1HandshakeReceivedEventArgs)fArgs).fHandshakeCode;
                        if (fHsc == FSecs1HandshakeCode.ENQ)
                        {
                            lblSecs1RecvEnq.BackColor = ColorOn;
                        }
                    }
                    else if (fArgs.fEventId == FEventId.Secs1HandshakeSent)
                    {
                        fHsc = ((FSecs1HandshakeSentEventArgs)fArgs).fHandshakeCode;
                        if (fHsc == FSecs1HandshakeCode.EOT)
                        {
                            lblSecs1RecvEot.BackColor = ColorOn;
                        }
                        else if (fHsc == FSecs1HandshakeCode.ACK)
                        {
                            lblSecs1RecvAck.BackColor = ColorOn;
                        }
                        else if (fHsc == FSecs1HandshakeCode.NAK)
                        {
                            lblSecs1RecvNak.BackColor = ColorOn;
                        }
                    }
                    else if (fArgs.fEventId == FEventId.Secs1BlockReceived)
                    {
                        lblSecs1RecvBlock.BackColor = ColorOn;
                    }
                }

                #endregion

                // --

                #region SECS1 Sent Qeueue

                fArgs = m_fSecs1SentQueue.dequeue();
                if (m_fCntCore.fSecs1ToHsms.fSecs1State == FCommunicationState.Selected && fArgs != null)
                {
                    lblSecs1SentEnq.BackColor = ColorOff;
                    lblSecs1SentEot.BackColor = ColorOff;
                    lblSecs1SentBlock.BackColor = ColorOff;
                    lblSecs1SentAck.BackColor = ColorOff;
                    lblSecs1SentNak.BackColor = ColorOff;

                    // --

                    if (fArgs.fEventId == FEventId.Secs1HandshakeReceived)
                    {
                        fHsc = ((FSecs1HandshakeReceivedEventArgs)fArgs).fHandshakeCode;
                        if (fHsc == FSecs1HandshakeCode.EOT)
                        {
                            lblSecs1SentEot.BackColor = ColorOn;
                        }
                        else if (fHsc == FSecs1HandshakeCode.ACK)
                        {
                            lblSecs1SentAck.BackColor = ColorOn;
                        }
                        else if (fHsc == FSecs1HandshakeCode.NAK)
                        {
                            lblSecs1SentNak.BackColor = ColorOn;
                        }
                    }
                    else if (fArgs.fEventId == FEventId.Secs1HandshakeSent)
                    {
                        fHsc = ((FSecs1HandshakeSentEventArgs)fArgs).fHandshakeCode;
                        if (fHsc == FSecs1HandshakeCode.ENQ)
                        {
                            lblSecs1SentEnq.BackColor = ColorOn;
                        }
                    }
                    else if (fArgs.fEventId == FEventId.Secs1BlockSent)
                    {
                        lblSecs1SentBlock.BackColor = ColorOn;
                    }
                }

                #endregion

                // --

                #region HSMS Queue

                fArgs = m_fHsmsQueue.dequeue();
                if (m_fCntCore.fSecs1ToHsms.fHsmsState == FCommunicationState.Selected && fArgs != null)
                {
                    lblHsmsRecv.BackColor = ColorOff;
                    lblHsmsSent.BackColor = ColorOff;

                    // --

                    if (fArgs.fEventId == FEventId.HsmsControlMessageReceived || fArgs.fEventId == FEventId.HsmsDataMessageReceived)
                    {
                        lblHsmsRecv.BackColor = ColorOn;
                    }
                    else if (fArgs.fEventId == FEventId.HsmsControlMessageSent || fArgs.fEventId == FEventId.HsmsDataMessageSent)
                    {
                        lblHsmsSent.BackColor = ColorOn;
                    }
                }

                #endregion

                // --

                #region Received and Sent Count

                if (lblSecs1RecvCount.Text != m_secs1RecvCount.ToString())
                {
                    lblSecs1RecvCount.Text = m_secs1RecvCount.ToString();
                }

                if (lblSecs1SentCount.Text != m_secs1SentCount.ToString())
                {
                    lblSecs1SentCount.Text = m_secs1SentCount.ToString();
                }

                // --

                if (lblHsmsRecvCount.Text != m_hsmsRecvCount.ToString())
                {
                    lblHsmsRecvCount.Text = m_hsmsRecvCount.ToString();
                }

                if (lblHsmsSentCount.Text != m_hsmsSentCount.ToString())
                {
                    lblHsmsSentCount.Text = m_hsmsSentCount.ToString();
                }

                #endregion
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                fArgs = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fEventHandler Object Event Handler

        private void m_fEventHandler_EventRaised(
            object sender, 
            FEventArgsBase e
            )
        {
            try
            {
                if (e.fEventId == FEventId.Secs1StateChanged)
                {
                    procSecs1StateChanged((FSecs1StateChangedEventArgs)e);
                }
                else if (e.fEventId == FEventId.Secs1ErrorRaised)
                {
                    procSecs1ErrorRaised((FSecs1ErrorRaisedEventArgs)e);
                }
                else if (e.fEventId == FEventId.Secs1TimeoutRaised)
                {
                    procSecs1TimeoutRaised((FSecs1TimeoutRaisedEventArgs)e);
                }
                else if (e.fEventId == FEventId.Secs1HandshakeReceived)
                {
                    procSecs1HandshakeReceived((FSecs1HandshakeReceivedEventArgs)e);
                }
                else if (e.fEventId == FEventId.Secs1HandshakeSent)
                {
                    procSecs1HandshakeSent((FSecs1HandshakeSentEventArgs)e);
                }
                else if (e.fEventId == FEventId.Secs1BlockReceived)
                {
                    procSecs1BlockReceived((FSecs1BlockReceivedEventArgs)e);
                }
                else if (e.fEventId == FEventId.Secs1BlockSent)
                {
                    procSecs1BlockSent((FSecs1BlockSentEventArgs)e);
                }
                else if (e.fEventId == FEventId.Secs1DataMessageReceived)
                {
                    procSecs1DataMessageReceived((FSecs1DataMessageReceivedEventArgs)e);
                }
                else if (e.fEventId == FEventId.Secs1DataMessageSent)
                {
                    procSecs1DataMessageSent((FSecs1DataMessageSentEventArgs)e);
                }
                // --
                else if (e.fEventId == FEventId.HsmsStateChanged)
                {
                    procHsmsStateChanged((FHsmsStateChangedEventArgs)e);
                }
                else if (e.fEventId == FEventId.HsmsErrorRaised)
                {
                    procHsmsErrorRaised((FHsmsErrorRaisedEventArgs)e);
                }
                else if (e.fEventId == FEventId.HsmsTimeoutRaised)
                {
                    procHsmsTimeoutRaised((FHsmsTimeoutRaisedEventArgs)e);
                }
                else if (e.fEventId == FEventId.HsmsControlMessageReceived)
                {
                    procHsmsControlMessageReceived((FHsmsControlMessageReceivedEventArgs)e);
                }
                else if (e.fEventId == FEventId.HsmsControlMessageSent)
                {
                    procHsmsControlMessageSent((FHsmsControlMessageSentEventArgs)e);
                }
                else if (e.fEventId == FEventId.HsmsDataMessageReceived)
                {
                    procHsmsDataMessageReceived((FHsmsDataMessageReceivedEventArgs)e);
                }
                else if (e.fEventId == FEventId.HsmsDataMessageSent)
                {
                    procHsmsDataMessageSent((FHsmsDataMessageSentEventArgs)e);
                }
                else if (e.fEventId == FEventId.HsmsInterceptingDataMessageReceived)
                {
                    procHsmsInterceptingDataMessageReceived((FHsmsInterceptingDataMessageReceivedEventArgs)e);
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

        #region btnMin Control Event Handler

        private void btnMin_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                this.WindowState = FormWindowState.Minimized;
            }
            catch (Exception ex)
            {
                FCommon.showErrorMessageBox(this, ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void btnMin_Enter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                txtBcrRead.Focus();
            }
            catch (Exception ex)
            {
                FCommon.showErrorMessageBox(this, ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnTerminalMessage Control Event Handler

        private void btnTerminalMessage_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                controlTermianlMessageBox();
            }
            catch (Exception ex)
            {
                FCommon.showErrorMessageBox(this, ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void btnTerminalMessage_Enter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                txtBcrRead.Focus();
            }
            catch (Exception ex)
            {
                FCommon.showErrorMessageBox(this, ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnPreviousMessage Control Event Handler

        private void btnPreviousMessage_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                m_fTermianlMessageBox.previousMessage();
            }
            catch (Exception ex)
            {
                FCommon.showErrorMessageBox(this, ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void btnPreviousMessage_Enter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                txtBcrRead.Focus();
            }
            catch (Exception ex)
            {
                FCommon.showErrorMessageBox(this, ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnNextMessage Control Event Handler

        private void btnNextMessage_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                m_fTermianlMessageBox.nextMessage();
            }
            catch (Exception ex)
            {
                FCommon.showErrorMessageBox(this, ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void btnNextMessage_Enter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                txtBcrRead.Focus();
            }
            catch (Exception ex)
            {
                FCommon.showErrorMessageBox(this, ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // class end
}   // namespace end
