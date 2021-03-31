/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecs1ToHsms.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.06
--  Description     : FAmate Converter FaSecs1ToHsms Secs1 to Hsms Class
--  History         : Created by spike.lee at 2017.04.06
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecs1ToHsms
{
    public class FSecs1ToHsms: IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        public event FEventRaisedEventHandler EventRaised = null;

        // --

        private bool m_disposed = false;
        // --
        private bool m_logEnabled = false;
        private string m_logDirectory = string.Empty;
        private string m_logFileNameSuffix = string.Empty;
        private int m_logFileMaxSize = 0;
        private bool m_logMonitoringEnabled = false;
        // --
        private FCommunicationState m_fSecs1State = FCommunicationState.Closed;
        private FCommunicationState m_fHsmsState = FCommunicationState.Closed;
        private FSecs1Config m_fSecs1Config = null;
        private FHsmsConfig m_fHsmsConfig = null;
        private FEventPusher m_fEventPusher = null;
        private FSECS1 m_fSecs1 = null;
        private FBaseHsms m_fHsms = null;
        private FLogWriter m_fLogWriter = null;
        private FIDPointer32 m_fSystemBytesPointer = null;
        // --
        private Dictionary<string, FInterceptingDataMessage> m_fSecs1InterceptingDataMessages = null;
        private Dictionary<string, FInterceptingDataMessage> m_fHsmsInterceptingDataMessages = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecs1ToHsms(
            string licFileName
            )
        {
            validateLicense(licFileName);     

            // --

            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSecs1ToHsms(
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

        public FSecs1Config fSecs1Config
        {
            get
            {
                try
                {
                    return m_fSecs1Config;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHsmsConfig fHsmsConfig
        {
            get
            {
                try
                {
                    return m_fHsmsConfig;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FCommunicationState fSecs1State
        {
            get
            {
                try
                {
                    return m_fSecs1State;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FCommunicationState.Closed;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FCommunicationState fHsmsState
        {
            get
            {
                try
                {
                    return m_fHsmsState;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FCommunicationState.Closed;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FEventPusher fEventPusher
        {
            get
            {
                try
                {
                    return m_fEventPusher;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool logEnabled
        {
            get
            {
                try
                {
                    return m_logEnabled;
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

            set
            {
                try
                {
                    m_logEnabled = value;
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

        public string logDirectory
        {
            get
            {
                try
                {
                    return m_logDirectory;
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
                    m_logDirectory = value;
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

        public string logFileNameSuffix
        {
            get
            {
                try
                {
                    return m_logFileNameSuffix;
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
                    m_logFileNameSuffix = value;
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

        public int logFileMaxSize
        {
            get
            {
                try
                {
                    return m_logFileMaxSize;
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
                    m_logFileMaxSize = value;
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

        public bool logMonitoringEnabled
        {
            get
            {
                try
                {
                    return m_logMonitoringEnabled;
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

            set
            {
                try
                {
                    m_logMonitoringEnabled = value;
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

        public int secs1InterceptingDataMessageCount
        {
            get
            {
                try
                {
                    return m_fSecs1InterceptingDataMessages.Count;
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

        public int hsmsInterceptingDataMessageCount
        {
            get
            {
                try
                {
                    return m_fHsmsInterceptingDataMessages.Count;
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

        internal FIDPointer32 fSystemBytesPointer
        {
            get
            {
                try
                {
                    return m_fSystemBytesPointer;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void validateLicense(
            string fileName
            )
        {
            // ***
            // New License File 적용
            // *** 
            FLic2License fLic = null;
            FLic2Info fLicInfo = null;

            try
            {
                fLic = new FLic2License();
                fLicInfo = fLic.validate(fileName);

                // --

                // ***
                // Product 허가 여부 체크
                // ***
                if (fLicInfo.fLicS2hCvt.productEnabled == FYesNo.No)
                {
                    fLic.rasieValidationError("product.enabled");
                }

                // --

                // ***
                // 사용기간 체크
                // ***
                if (fLicInfo.fLicS2hCvt.expireIssuedCheck == FYesNo.Yes && !fLic.validateExpireIssueDate(fLicInfo.fLicS2hCvt.expireIssuedDate))
                {
                    fLic.rasieValidationError("expire.issued.date");
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fLic != null)
                {
                    fLic.Dispose();
                    fLic = null;
                }

                if (fLicInfo != null)
                {
                    fLicInfo.Dispose();
                    fLicInfo = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void init(
            )
        {
            try
            {
                m_logDirectory = Application.StartupPath + "\\Log";
                m_logFileNameSuffix = "Secs1ToHsms";
                m_logFileMaxSize = 5; // 5MB

                // --

                m_fLogWriter = new FLogWriter(this);
                m_fSystemBytesPointer = new FIDPointer32(10000);

                // -- 

                // ***
                // SECS1/HSMS Config 생성
                // ***
                m_fSecs1Config = new FSecs1Config(this);
                m_fHsmsConfig = new FHsmsConfig(this);

                // -

                m_fSecs1InterceptingDataMessages = new Dictionary<string, FInterceptingDataMessage>();
                m_fHsmsInterceptingDataMessages = new Dictionary<string, FInterceptingDataMessage>();

                // --

                m_fEventPusher = new FEventPusher(this);
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
                closeAll();

                // --

                if (m_fEventPusher != null)
                {
                    m_fEventPusher.Dispose();
                    m_fEventPusher = null;
                }

                // --

                if (m_fSecs1Config != null)
                {
                    m_fSecs1Config.Dispose();
                    m_fSecs1Config = null;
                }
                if (m_fHsmsConfig != null)
                {
                    m_fHsmsConfig.Dispose();
                    m_fHsmsConfig = null;
                }

                // --

                m_fSecs1InterceptingDataMessages = null;
                m_fHsmsInterceptingDataMessages = null;
                
                // --

                if (m_fLogWriter != null)
                {
                    m_fLogWriter.Dispose();
                    m_fLogWriter = null;
                }

                if (m_fSystemBytesPointer != null)
                {
                    m_fSystemBytesPointer.Dispose();
                    m_fSystemBytesPointer = null;
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

        public void openSecs1(
            )
        {
            try
            {
                if (m_fSecs1State != FCommunicationState.Closed)
                {
                    return;
                }

                // --

                m_fSecs1 = new FSECS1(this);
                m_fSecs1.open();
            }
            catch (Exception ex)
            {
                if (m_fSecs1 != null)
                {
                    m_fSecs1.Dispose();
                    m_fSecs1 = null;
                }
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void closeSecs1(
            )
        {
            try
            {
                if (m_fSecs1State == FCommunicationState.Closed)
                {
                    return;
                }

                // --

                if (m_fSecs1 != null)
                {
                    m_fSecs1.close();
                    m_fSecs1.Dispose();
                    m_fSecs1 = null;
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

        public void openHsms(
            )
        {
            try
            {
                if (m_fHsmsState != FCommunicationState.Closed)
                {
                    return;
                }

                // --

                if (m_fHsmsConfig.fConnectMode == FConnectMode.Passive)
                {
                    m_fHsms = new FHsmsPassive(this);
                }
                else
                {
                    m_fHsms = new FHsmsActive(this);
                }
                // --                
                m_fHsms.open();
            }
            catch (Exception ex)
            {
                if (m_fHsms != null)
                {
                    m_fHsms.Dispose();
                    m_fHsms = null;
                }
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void closeHsms(
            )
        {
            try
            {
                if (m_fHsmsState == FCommunicationState.Closed)
                {
                    return;
                }

                // --

                if (m_fHsms != null)
                {
                    m_fHsms.close();
                    m_fHsms.Dispose();
                    m_fHsms = null;
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

        public void openAll(
            )
        {
            try
            {
                openHsms();
                openSecs1();
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

        public void closeAll(
            )
        {
            try
            {
                closeSecs1();
                closeHsms();
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

        internal void changeSecs1State(
            FCommunicationState fState,
            string serialPort,
            int baud
            )
        {
            try
            {
                if (m_fSecs1State == fState)
                {
                    return;
                }
                m_fSecs1State = fState;
                
                // --
                
                m_fEventPusher.pushSecs1Event(
                    new FSecs1StateChangedEventArgs(this, FEventId.Secs1StateChanged, FResultCode.Success, string.Empty, fState, serialPort, baud)
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

        internal void changeHsmsState(
            FConnectMode fConnectMode,
            string localIp,
            int localPort,
            string remoteIp,
            int remotePort,
            FCommunicationState fState
            )
        {
            try
            {
                if (m_fHsmsState == fState)
                {
                    return;
                }
                m_fHsmsState = fState;

                // --

                m_fEventPusher.pushHsmsEvent(
                    new FHsmsStateChangedEventArgs(
                        this, 
                        FEventId.HsmsStateChanged, 
                        FResultCode.Success, 
                        string.Empty, 
                        fConnectMode,
                        localIp, 
                        localPort,
                        remoteIp,
                        remotePort,
                        fState
                        )
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

        internal void onEventRaised(
            FEventArgsBase fArgs
            )
        {
            FSecsDataMessage fSecsDataMessage = null;

            try
            {
                if (m_logEnabled)
                {
                    m_fLogWriter.write(fArgs);
                }

                // --

                if (EventRaised != null)
                {
                    EventRaised(this, fArgs);
                }

                // --

                if (fArgs.fEventId == FEventId.Secs1DataMessageReceived)
                {
                    if (((FSecs1DataMessageReceivedEventArgs)fArgs).fResult == FResultCode.Success)
                    {
                        fSecsDataMessage = ((FSecs1DataMessageReceivedEventArgs)fArgs).fSecsDataMessage;
                        if (!isSecs1InterceptingDataMessage(fSecsDataMessage.stream, fSecsDataMessage.function))
                        {
                            sendHsmsDataMessage(((FSecs1DataMessageReceivedEventArgs)fArgs).fSecsDataMessage);
                        }                        
                    }
                }
                else if (fArgs.fEventId == FEventId.HsmsDataMessageReceived)
                {
                    if (((FHsmsDataMessageReceivedEventArgs)fArgs).fResult == FResultCode.Success)
                    {
                        fSecsDataMessage = ((FHsmsDataMessageReceivedEventArgs)fArgs).fSecsDataMessage;
                        if (!isHsmsInterceptingDataMessage(fSecsDataMessage.stream, fSecsDataMessage.function))
                        {
                            sendSecs1DataMessage(((FHsmsDataMessageReceivedEventArgs)fArgs).fSecsDataMessage);
                        }                        
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecsDataMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void sendHsmsDataMessage(
            FSecsDataMessage fSecsDataMessage
            )
        {
            FSecsDataMessage fMsg = null;

            try
            {
                fMsg = fSecsDataMessage.clone();

                // --

                if (this.fHsmsState == FCommunicationState.Selected)
                {
                    m_fHsms.send(fMsg);
                }
                else
                {
                    m_fEventPusher.pushHsmsEvent(
                        new FHsmsDataMessageSentEventArgs(this, FEventId.HsmsDataMessageSent, FResultCode.Error, string.Format(FConstants.err_m_0030, "HSMS"), fMsg)
                        );
                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                fMsg = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void sendSecs1DataMessage(
            FSecsDataMessage fSecsDataMessage
            )
        {
            FSecsDataMessage fMsg = null;

            try
            {
                fMsg = fSecsDataMessage.clone();

                // --

                if (this.fSecs1State == FCommunicationState.Selected)
                {
                    m_fSecs1.send(fMsg);
                }
                else
                {
                    m_fEventPusher.pushSecs1Event(
                        new FSecs1DataMessageSentEventArgs(this, FEventId.Secs1DataMessageSent, FResultCode.Error, string.Format(FConstants.err_m_0030, "SECS1"), fMsg)
                        );
                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                fMsg = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void waitEventHandlingCompleted(
            )
        {
            try
            {
                m_fEventPusher.waitEventHandlingCompleted();
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

        public bool containsSecs1InterceptingDataMessage(
            FInterceptingDataMessage fInterceptingDataMessage
            )
        {
            try
            {
                return m_fSecs1InterceptingDataMessages.ContainsKey(fInterceptingDataMessage.getKey());
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

        //------------------------------------------------------------------------------------------------------------------------

        public bool containsHsmsInterceptingDataMessage(
            FInterceptingDataMessage fInterceptingDataMessage
            )
        {
            try
            {
                return m_fHsmsInterceptingDataMessages.ContainsKey(fInterceptingDataMessage.getKey());
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

        //------------------------------------------------------------------------------------------------------------------------

        public void addSecs1InterceptingDataMessage(
            FInterceptingDataMessage fInterceptingDataMessage
            )
        {
            try
            {
                if (m_fSecs1InterceptingDataMessages.ContainsKey(fInterceptingDataMessage.getKey()))
                {
                    return;
                }
                m_fSecs1InterceptingDataMessages.Add(fInterceptingDataMessage.getKey(), fInterceptingDataMessage);
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

        public void addHsmsInterceptingDataMessage(
            FInterceptingDataMessage fInterceptingDataMessage
            )
        {
            try
            {
                if (m_fHsmsInterceptingDataMessages.ContainsKey(fInterceptingDataMessage.getKey()))
                {
                    return;
                }
                m_fHsmsInterceptingDataMessages.Add(fInterceptingDataMessage.getKey(), fInterceptingDataMessage);
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

        public void removeSecs1InterceptingDataMessage(
            FInterceptingDataMessage fInterceptingDataMessage
            )
        {
            try
            {
                if (!m_fSecs1InterceptingDataMessages.ContainsKey(fInterceptingDataMessage.getKey()))
                {
                    return;
                }
                m_fSecs1InterceptingDataMessages.Remove(fInterceptingDataMessage.getKey());
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

        public void removeHsmsInterceptingDataMessage(
            FInterceptingDataMessage fInterceptingDataMessage
            )
        {
            try
            {
                if (!m_fHsmsInterceptingDataMessages.ContainsKey(fInterceptingDataMessage.getKey()))
                {
                    return;
                }
                m_fHsmsInterceptingDataMessages.Remove(fInterceptingDataMessage.getKey());
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

        public void removeAllSecs1InterceptingDataMessage(
            )
        {
            try
            {
                m_fSecs1InterceptingDataMessages.Clear();
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

        public void removeAllHsmsInterceptingDataMessage(
            )
        {
            try
            {
                m_fHsmsInterceptingDataMessages.Clear();
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

        internal bool isSecs1InterceptingDataMessage(
            byte stream, 
            byte function
            )
        {
            const string KeyFormat = "{0}-{1}";            

            try
            {
                return m_fSecs1InterceptingDataMessages.ContainsKey(string.Format(KeyFormat, stream.ToString(), function.ToString()));
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

        //------------------------------------------------------------------------------------------------------------------------

        internal bool isHsmsInterceptingDataMessage(
            byte stream,
            byte function
            )
        {
            const string KeyFormat = "{0}-{1}";

            try
            {
                return m_fHsmsInterceptingDataMessages.ContainsKey(string.Format(KeyFormat, stream.ToString(), function.ToString()));
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

        //------------------------------------------------------------------------------------------------------------------------

        public void sendSecs1DataMessage(
            FSecsDataMessageTransfer fSecsDataMessageTransfer
            )
        {
            try
            {
                sendSecs1DataMessage(fSecsDataMessageTransfer.getSecsDataMessage());
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

        public void sendHsmsDataMessage(
            FSecsDataMessageTransfer fSecsDataMessageTransfer
            )
        {
            try
            {
                sendHsmsDataMessage(fSecsDataMessageTransfer.getSecsDataMessage());
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

        public void writeAppLog(
            string log
            )
        {
            try
            {
                m_fLogWriter.write(log);
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

    }   // Class end
}   // Namespace end
