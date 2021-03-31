/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FLogWriter.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.14
--  Description     : FAmate Converter FaSecs1ToHsms Log Writer Class
--  History         : Created by spike.lee at 2017.04.14
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecs1ToHsms
{
    internal class FLogWriter: IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        const string LogFileExt = "log";

        // --

        private bool m_disposed = false;
        // --
        private FSecs1ToHsms m_fSecs1ToHsms = null;
        private FQueue<string> m_fLogQueue = null;
        private FThread m_fThdMain = null;
        // --
        private string m_logFileName = string.Empty;
        private FileStream m_fsLogFile = null;
        private StreamWriter m_swLogFile = null;
        private string m_logFileNameSuffix = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FLogWriter(            
            FSecs1ToHsms fSecs1ToHsms
            )
        {
            m_fSecs1ToHsms = fSecs1ToHsms;
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FLogWriter(
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
                m_fLogQueue = new FQueue<string>();

                // --

                m_logFileNameSuffix = m_fSecs1ToHsms.logFileNameSuffix;

                // --

                m_fThdMain = new FThread("LogWriterThread");
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
                    if (m_fLogQueue != null)
                    {
                        while (m_fLogQueue.count > 0)
                        {
                            System.Threading.Thread.Sleep(10);
                        }
                    }

                    // --

                    m_fThdMain.stop();
                    m_fThdMain.Dispose();
                    m_fThdMain.ThreadJobCalled -= new FThreadJobCalledEventHandler(m_fThdMain_ThreadJobCalled);
                    m_fThdMain = null;
                }

                // --

                if (m_fLogQueue != null)
                {
                    m_fLogQueue.Dispose();
                    m_fLogQueue = null;
                }

                // --

                closeLogFile();
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

        private void openLogFile(
            )
        {
            string searchPattern = string.Empty;
            string[] files = null;
            FileInfo fileInfo = null;
            string newLogFileName = string.Empty;

            try
            {
                if (!Directory.Exists(m_fSecs1ToHsms.logDirectory))
                {
                    Directory.CreateDirectory(m_fSecs1ToHsms.logDirectory);
                }

                // --

                if (m_fsLogFile == null)
                {
                    m_logFileNameSuffix = m_fSecs1ToHsms.logFileNameSuffix;
                    searchPattern = "*_" + m_logFileNameSuffix + "." + LogFileExt;
                    files = Directory.GetFiles(m_fSecs1ToHsms.logDirectory, searchPattern);
                    // --
                    if (files.Length == 0)
                    {
                        m_logFileName = string.Empty;
                    }
                    else
                    {
                        m_logFileName = files[files.Length - 1];
                        fileInfo = new FileInfo(m_logFileName);
                        if (fileInfo.Length >= (m_fSecs1ToHsms.logFileMaxSize * 1024 * 1024))
                        {
                            m_logFileName = string.Empty;
                        }
                    }
                }
                else
                {
                    fileInfo = new FileInfo(m_logFileName);
                    if (fileInfo.Length >= (m_fSecs1ToHsms.logFileMaxSize * 1024 * 1024))
                    {
                        closeLogFile();
                        m_logFileName = string.Empty;
                    }
                    else if (m_logFileNameSuffix != m_fSecs1ToHsms.logFileNameSuffix)
                    {
                        closeLogFile();
                        m_logFileName = string.Empty;
                    }
                }

                // --

                if (m_swLogFile == null)
                {
                    if (m_logFileName == string.Empty)
                    {
                        m_logFileNameSuffix = m_fSecs1ToHsms.logFileNameSuffix;
                        m_logFileName = m_fSecs1ToHsms.logDirectory + "\\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + m_logFileNameSuffix + "." + LogFileExt;
                    }
                    m_fsLogFile = new FileStream(m_logFileName, FileMode.OpenOrCreate | FileMode.Append, FileAccess.Write, FileShare.Read);
                    m_swLogFile = new StreamWriter(m_fsLogFile, Encoding.Default);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                files = null;
                fileInfo = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void closeLogFile(
            )
        {
            try
            {
                if (m_swLogFile != null)
                {
                    m_swLogFile.Flush();
                }

                if (m_fsLogFile != null)
                {
                    m_fsLogFile.Flush();
                }

                // --

                if (m_swLogFile != null)
                {
                    m_swLogFile.Close();
                    m_swLogFile.Dispose();
                    m_swLogFile = null;
                }

                if (m_fsLogFile != null)
                {
                    m_fsLogFile.Close();
                    m_fsLogFile.Dispose();
                    m_fsLogFile = null;
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

        private void writeLog(
            )
        {
            string log = string.Empty;

            try
            {
                openLogFile();
                while (m_fLogQueue.count > 0)
                {
                    log = m_fLogQueue.dequeue();
                    m_swLogFile.Write(log);
                    // --
                    // 2019-09-04 by mjkim
                    // Queue에는 쌓으나 실제 사용하지 않음
                    //if (m_fSecs1ToHsms.logMonitoringEnabled)
                    //{
                    //    m_fSecs1ToHsms.fEventPusher.pushSecs1Event(new FLogMonitoringEventArgs(m_fSecs1ToHsms, FEventId.LogMonitoring, log));
                    //}
                }
                m_swLogFile.Flush();
                m_fsLogFile.Flush();
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

        private string[] binToString(
            byte[] byteData
            )
        {
            List<string> strData = null;
            StringBuilder sb = null;
            int index = 0;

            try
            {
                strData = new List<string>();
                strData.Add("--");
                sb = new StringBuilder();
                foreach (byte b in byteData)
                {
                    sb.Append(b.ToString("X2") + " ");
                    index++;
                    if (index % 40 == 0)
                    {
                        strData.Add(sb.ToString());
                        sb.Clear();
                    }
                }
                if (sb.Length > 0)
                {
                    strData.Add(sb.ToString());
                }
                
                // --

                return strData.ToArray();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                strData = null;
                sb = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void writeSecs1StateChanged(
            FSecs1StateChangedEventArgs fArgs
            )
        {
            StringBuilder logData = new StringBuilder();

            try
            {
                logData.AppendLine("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]");

                // -- 

                logData.Append(fArgs.fEventId.ToString());
                logData.Append(", Result=<" + fArgs.fResult.ToString() + ">");
                if (fArgs.fResult != FResultCode.Success)
                {
                    logData.Append(", ErrorMessage=<" + fArgs.errorMessage + ">");
                }
                logData.AppendLine();

                // --

                logData.AppendLine(fArgs.fState.ToString() + ", SerialPort=<" + fArgs.serialPort + ">, Baud=<" + fArgs.baud.ToString() + ">");

                // --

                logData.AppendLine();
                m_fLogQueue.enqueue(logData.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                logData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void writeSecs1ErrorRaised(
            FSecs1ErrorRaisedEventArgs fArgs
            )
        {
            StringBuilder logData = new StringBuilder();

            try
            {
                logData.AppendLine("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]");

                // -- 

                logData.Append(fArgs.fEventId.ToString());
                logData.Append(", ErrorMessage=<" + fArgs.errorMessage + ">");
                logData.AppendLine();

                // --                

                logData.AppendLine();
                m_fLogQueue.enqueue(logData.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                logData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void writeSecs1TimeoutRaised(
            FSecs1TimeoutRaisedEventArgs fArgs
            )
        {
            StringBuilder logData = new StringBuilder();

            try
            {
                logData.AppendLine("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]");

                // -- 

                logData.Append(fArgs.fEventId.ToString());
                logData.Append(", ErrorMessage=<" + fArgs.errorMessage + ">");
                logData.AppendLine();

                // --                

                logData.AppendLine(fArgs.fTimeout.ToString());
                
                // --

                logData.AppendLine();
                m_fLogQueue.enqueue(logData.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                logData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void writeSecs1HandshakeReceived(
            FSecs1HandshakeReceivedEventArgs fArgs
            )
        {
            StringBuilder logData = new StringBuilder();

            try
            {
                logData.AppendLine("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]");

                // -- 

                logData.Append(fArgs.fEventId.ToString());
                logData.Append(", Result=<" + fArgs.fResult.ToString() + ">");
                if (fArgs.fResult != FResultCode.Success)
                {
                    logData.Append(", ErrorMessage=<" + fArgs.errorMessage + ">");
                }
                logData.AppendLine();

                // --                

                logData.AppendLine(fArgs.fHandshakeCode.ToString());

                // --

                foreach (string s in binToString(fArgs.getBinaryData()))
                {
                    logData.AppendLine(s);
                }

                // --

                logData.AppendLine();
                m_fLogQueue.enqueue(logData.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                logData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void writeSecs1HandshakeSent(
            FSecs1HandshakeSentEventArgs fArgs
            )
        {
            StringBuilder logData = new StringBuilder();

            try
            {
                logData.AppendLine("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]");

                // -- 

                logData.Append(fArgs.fEventId.ToString());
                logData.Append(", Result=<" + fArgs.fResult.ToString() + ">");
                if (fArgs.fResult != FResultCode.Success)
                {
                    logData.Append(", ErrorMessage=<" + fArgs.errorMessage + ">");
                }
                logData.AppendLine();

                // --                

                logData.AppendLine(fArgs.fHandshakeCode.ToString());

                // --

                foreach (string s in binToString(fArgs.getBinaryData()))
                {
                    logData.AppendLine(s);
                }

                // --

                logData.AppendLine();
                m_fLogQueue.enqueue(logData.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                logData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void writeSecs1BlockReceived(
            FSecs1BlockReceivedEventArgs fArgs
            )
        {
            StringBuilder logData = new StringBuilder();

            try
            {
                logData.AppendLine("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]");

                // -- 

                logData.Append(fArgs.fEventId.ToString());
                logData.Append(", Result=<" + fArgs.fResult.ToString() + ">");
                if (fArgs.fResult != FResultCode.Success)
                {
                    logData.Append(", ErrorMessage=<" + fArgs.errorMessage + ">");
                }
                logData.AppendLine();

                // --                

                logData.Append("S" + fArgs.fSecsBlock.stream.ToString() + "F" + fArgs.fSecsBlock.function.ToString());
                if (fArgs.fSecsBlock.wbit)
                {
                    logData.Append(" W");
                }
                logData.Append(", BlockNo=<" + fArgs.fSecsBlock.blockNo.ToString() + ">, EBit=<" + fArgs.fSecsBlock.ebit.ToString() + ">, SystemBytes=<" + fArgs.fSecsBlock.systemBytes.ToString() + ">, Length=<" + fArgs.fSecsBlock.length.ToString() + ">");
                logData.Append(", SessionId=<" + fArgs.fSecsBlock.sessionId.ToString() + ">, RBit=<" + fArgs.fSecsBlock.rbit.ToString() + ">, CheckSum=<" + fArgs.fSecsBlock.checkSum.ToString() + ">");
                logData.AppendLine();

                // --

                foreach (string s in binToString(fArgs.fSecsBlock.blockData))
                {
                    logData.AppendLine(s);
                }

                // --

                logData.AppendLine();
                m_fLogQueue.enqueue(logData.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                logData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void writeSecs1BlockSent(
            FSecs1BlockSentEventArgs fArgs
            )
        {
            StringBuilder logData = new StringBuilder();

            try
            {
                logData.AppendLine("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]");

                // -- 

                logData.Append(fArgs.fEventId.ToString());
                logData.Append(", Result=<" + fArgs.fResult.ToString() + ">");
                if (fArgs.fResult != FResultCode.Success)
                {
                    logData.Append(", ErrorMessage=<" + fArgs.errorMessage + ">");
                }
                logData.AppendLine();

                // --                

                logData.Append("S" + fArgs.fSecsBlock.stream.ToString() + "F" + fArgs.fSecsBlock.function.ToString());
                if (fArgs.fSecsBlock.wbit)
                {
                    logData.Append(" W");
                }
                logData.Append(", BlockNo=<" + fArgs.fSecsBlock.blockNo.ToString() + ">, EBit=<" + fArgs.fSecsBlock.ebit.ToString() + ">, SystemBytes=<" + fArgs.fSecsBlock.systemBytes.ToString() + ">, Length=<" + fArgs.fSecsBlock.length.ToString() + ">");
                logData.Append(", SessionId=<" + fArgs.fSecsBlock.sessionId.ToString() + ">, RBit=<" + fArgs.fSecsBlock.rbit.ToString() + ">, CheckSum=<" + fArgs.fSecsBlock.checkSum.ToString() + ">");
                logData.AppendLine();

                // --

                foreach (string s in binToString(fArgs.fSecsBlock.blockData))
                {
                    logData.AppendLine(s);
                }

                // --

                logData.AppendLine();
                m_fLogQueue.enqueue(logData.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                logData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void writeSecs1DataMessageReceivedSml(
            FSecs1DataMessageReceivedEventArgs fArgs
            )
        {
            StringBuilder logData = new StringBuilder();

            try
            {
                logData.AppendLine("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]");

                // -- 

                logData.Append(fArgs.fEventId.ToString() + " SML");
                logData.Append(", Result=<" + fArgs.fResult.ToString() + ">");
                if (fArgs.fResult != FResultCode.Success)
                {
                    logData.Append(", ErrorMessage=<" + fArgs.errorMessage + ">");
                }
                logData.AppendLine();

                // --                

                logData.Append("S" + fArgs.fSecsDataMessage.stream.ToString() + "F" + fArgs.fSecsDataMessage.function.ToString());
                if (fArgs.fSecsDataMessage.wbit)
                {
                    logData.Append(" W");
                }
                logData.Append(", SystemBytes=<" + fArgs.fSecsDataMessage.systemBytes.ToString() + ">, Length=<" + fArgs.fSecsDataMessage.length.ToString() + ">, SessionId=<" + fArgs.fSecsDataMessage.sessionId.ToString() + ">");
                logData.AppendLine();

                // --

                if (fArgs.fSecsDataMessage.body.Length > 0)
                {
                    logData.AppendLine(FSecsConverter.convertBinToSml(fArgs.fSecsDataMessage.body));
                }

                // --

                logData.AppendLine();
                m_fLogQueue.enqueue(logData.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                logData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void writeSecs1DataMessageSentSml(
            FSecs1DataMessageSentEventArgs fArgs
            )
        {
            StringBuilder logData = new StringBuilder();

            try
            {
                logData.AppendLine("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]");

                // -- 

                logData.Append(fArgs.fEventId.ToString() + " SML");
                logData.Append(", Result=<" + fArgs.fResult.ToString() + ">");
                if (fArgs.fResult != FResultCode.Success)
                {
                    logData.Append(", ErrorMessage=<" + fArgs.errorMessage + ">");
                }
                logData.AppendLine();

                // --                

                logData.Append("S" + fArgs.fSecsDataMessage.stream.ToString() + "F" + fArgs.fSecsDataMessage.function.ToString());
                if (fArgs.fSecsDataMessage.wbit)
                {
                    logData.Append(" W");
                }
                logData.Append(", SystemBytes=<" + fArgs.fSecsDataMessage.systemBytes.ToString() + ">, Length=<" + fArgs.fSecsDataMessage.length.ToString() + ">, SessionId=<" + fArgs.fSecsDataMessage.sessionId.ToString() + ">");
                logData.AppendLine();

                // --

                if (fArgs.fSecsDataMessage.body.Length > 0)
                {
                    logData.AppendLine(FSecsConverter.convertBinToSml(fArgs.fSecsDataMessage.body));
                }

                // --

                logData.AppendLine();
                m_fLogQueue.enqueue(logData.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                logData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void writeHsmsStateChanged(
            FHsmsStateChangedEventArgs fArgs
            )
        {
            StringBuilder logData = new StringBuilder();

            try
            {
                logData.AppendLine("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]");

                // -- 

                logData.Append(fArgs.fEventId.ToString());
                logData.Append(", Result=<" + fArgs.fResult.ToString() + ">");
                if (fArgs.fResult != FResultCode.Success)
                {
                    logData.Append(", ErrorMessage=<" + fArgs.errorMessage + ">");
                }
                logData.AppendLine();

                // --

                logData.AppendLine(fArgs.fState.ToString() + ", ConnectMode=<" + fArgs.fConnectMode + ">, LocalIp=<" + fArgs.localIp + ">, LocalPort=<" + fArgs.localPort.ToString() + ">, RemoteIp=<" + fArgs.remoteIp + ">, RemotePort=<" + fArgs.remotePort.ToString() +">");

                // --

                logData.AppendLine();
                m_fLogQueue.enqueue(logData.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                logData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void writeHsmsErrorRaised(
            FHsmsErrorRaisedEventArgs fArgs
            )
        {
            StringBuilder logData = new StringBuilder();

            try
            {
                logData.AppendLine("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]");

                // -- 

                logData.Append(fArgs.fEventId.ToString());
                logData.Append(", ErrorMessage=<" + fArgs.errorMessage + ">");
                logData.AppendLine();

                // --                

                logData.AppendLine();
                m_fLogQueue.enqueue(logData.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                logData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void writeHsmsTimeoutRaised(
            FHsmsTimeoutRaisedEventArgs fArgs
            )
        {
            StringBuilder logData = new StringBuilder();

            try
            {
                logData.AppendLine("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]");

                // -- 

                logData.Append(fArgs.fEventId.ToString());
                logData.Append(", ErrorMessage=<" + fArgs.errorMessage + ">");
                logData.AppendLine();

                // --                

                logData.AppendLine(fArgs.fTimeout.ToString());

                // --

                logData.AppendLine();
                m_fLogQueue.enqueue(logData.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                logData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void writeHsmsControlMessageReceived(
            FHsmsControlMessageReceivedEventArgs fArgs
            )
        {
            StringBuilder logData = new StringBuilder();

            try
            {
                logData.AppendLine("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]");

                // -- 

                logData.Append(fArgs.fEventId.ToString());
                logData.Append(", Result=<" + fArgs.fResult.ToString() + ">");
                if (fArgs.fResult != FResultCode.Success)
                {
                    logData.Append(", ErrorMessage=<" + fArgs.errorMessage + ">");
                }
                logData.AppendLine();

                // --                

                logData.Append(fArgs.fSecsControlMessage.fType.ToString());
                logData.Append(", Byte2=<" + fArgs.fSecsControlMessage.byte2.ToString() + ">, Byte3=<" + fArgs.fSecsControlMessage.byte3.ToString() + ">, PType=<" + fArgs.fSecsControlMessage.ptype.ToString() + ">, SType=<" + fArgs.fSecsControlMessage.stype.ToString() + ">, SystemBytes=<" + fArgs.fSecsControlMessage.systemBytes.ToString() + ">");
                logData.Append(", Length=<" + fArgs.fSecsControlMessage.length.ToString() +">, SessionId=<" + fArgs.fSecsControlMessage.sessionId.ToString() + ">");
                if (fArgs.fSecsControlMessage.reason != string.Empty)
                {
                    logData.Append(", Reason=<" + fArgs.fSecsControlMessage.reason + ">");
                }
                logData.AppendLine();

                // --

                foreach (string s in binToString(fArgs.fSecsControlMessage.getBinaryData()))
                {
                    logData.AppendLine(s);
                }

                // --

                logData.AppendLine();
                m_fLogQueue.enqueue(logData.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                logData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void writeHsmsControlMessageSent(
            FHsmsControlMessageSentEventArgs fArgs
            )
        {
            StringBuilder logData = new StringBuilder();

            try
            {
                logData.AppendLine("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]");

                // -- 

                logData.Append(fArgs.fEventId.ToString());
                logData.Append(", Result=<" + fArgs.fResult.ToString() + ">");
                if (fArgs.fResult != FResultCode.Success)
                {
                    logData.Append(", ErrorMessage=<" + fArgs.errorMessage + ">");
                }
                logData.AppendLine();

                // --                

                logData.Append(fArgs.fSecsControlMessage.fType.ToString());
                logData.Append(", Byte2=<" + fArgs.fSecsControlMessage.byte2.ToString() + ">, Byte3=<" + fArgs.fSecsControlMessage.byte3.ToString() + ">, PType=<" + fArgs.fSecsControlMessage.ptype.ToString() + ">, SType=<" + fArgs.fSecsControlMessage.stype.ToString() + ">, SystemBytes=<" + fArgs.fSecsControlMessage.systemBytes.ToString() + ">");
                logData.Append(", Length=<" + fArgs.fSecsControlMessage.length.ToString() +">, SessionId=<" + fArgs.fSecsControlMessage.sessionId.ToString() + ">");
                if (fArgs.fSecsControlMessage.reason != string.Empty)
                {
                    logData.Append(", Reason=<" + fArgs.fSecsControlMessage.reason + ">");
                }
                logData.AppendLine();

                // --

                foreach (string s in binToString(fArgs.fSecsControlMessage.getBinaryData()))
                {
                    logData.AppendLine(s);
                }

                // --

                logData.AppendLine();
                m_fLogQueue.enqueue(logData.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                logData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void writeHsmsDataMessageReceived(
            FHsmsDataMessageReceivedEventArgs fArgs
            )
        {
            StringBuilder logData = new StringBuilder();

            try
            {
                logData.AppendLine("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]");

                // -- 

                logData.Append(fArgs.fEventId.ToString());
                logData.Append(", Result=<" + fArgs.fResult.ToString() + ">");
                if (fArgs.fResult != FResultCode.Success)
                {
                    logData.Append(", ErrorMessage=<" + fArgs.errorMessage + ">");
                }
                logData.AppendLine();

                // --                

                logData.Append("S" + fArgs.fSecsDataMessage.stream.ToString() + "F" + fArgs.fSecsDataMessage.function.ToString());
                if (fArgs.fSecsDataMessage.wbit)
                {
                    logData.Append(" W");
                }
                logData.Append(", SystemBytes=<" + fArgs.fSecsDataMessage.systemBytes.ToString() + ">, Length=<" + fArgs.fSecsDataMessage.length.ToString() + ">, SessionId=<" + fArgs.fSecsDataMessage.sessionId.ToString() + ">");
                logData.AppendLine();

                // --

                foreach (string s in binToString(fArgs.fSecsDataMessage.getHsmsBinaryData(true)))
                {
                    logData.AppendLine(s);
                }

                // --

                logData.AppendLine();
                m_fLogQueue.enqueue(logData.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                logData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void writeHsmsDataMessageSent(
            FHsmsDataMessageSentEventArgs fArgs
            )
        {
            StringBuilder logData = new StringBuilder();

            try
            {
                logData.AppendLine("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]");

                // -- 

                logData.Append(fArgs.fEventId.ToString());
                logData.Append(", Result=<" + fArgs.fResult.ToString() + ">");
                if (fArgs.fResult != FResultCode.Success)
                {
                    logData.Append(", ErrorMessage=<" + fArgs.errorMessage + ">");
                }
                logData.AppendLine();

                // --                

                logData.Append("S" + fArgs.fSecsDataMessage.stream.ToString() + "F" + fArgs.fSecsDataMessage.function.ToString());
                if (fArgs.fSecsDataMessage.wbit)
                {
                    logData.Append(" W");
                }
                logData.Append(", SystemBytes=<" + fArgs.fSecsDataMessage.systemBytes.ToString() + ", Length=<" + fArgs.fSecsDataMessage.length.ToString() + ">, SessionId=<" + fArgs.fSecsDataMessage.sessionId.ToString() + ">");
                logData.AppendLine();

                // --

                foreach (string s in binToString(fArgs.fSecsDataMessage.getHsmsBinaryData(true)))
                {
                    logData.AppendLine(s);
                }

                // --

                logData.AppendLine();
                m_fLogQueue.enqueue(logData.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                logData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void writeHsmsDataMessageReceivedSml(
            FHsmsDataMessageReceivedEventArgs fArgs
            )
        {
            StringBuilder logData = new StringBuilder();

            try
            {
                logData.AppendLine("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]");

                // -- 

                logData.Append(fArgs.fEventId.ToString() + " SML");
                logData.Append(", Result=<" + fArgs.fResult.ToString() + ">");
                if (fArgs.fResult != FResultCode.Success)
                {
                    logData.Append(", ErrorMessage=<" + fArgs.errorMessage + ">");
                }
                logData.AppendLine();

                // --                

                logData.Append("S" + fArgs.fSecsDataMessage.stream.ToString() + "F" + fArgs.fSecsDataMessage.function.ToString());
                if (fArgs.fSecsDataMessage.wbit)
                {
                    logData.Append(" W");
                }
                logData.Append(", SystemBytes=<" + fArgs.fSecsDataMessage.systemBytes.ToString() + ">, Length=<" + fArgs.fSecsDataMessage.length.ToString() + ">, SessionId=<" + fArgs.fSecsDataMessage.sessionId.ToString() + ">");
                logData.AppendLine();

                // --

                if (fArgs.fSecsDataMessage.body.Length > 0)
                {
                    logData.AppendLine(FSecsConverter.convertBinToSml(fArgs.fSecsDataMessage.body));
                }

                // --

                logData.AppendLine();
                m_fLogQueue.enqueue(logData.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                logData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void writeHsmsDataMessageSentSml(
            FHsmsDataMessageSentEventArgs fArgs
            )
        {
            StringBuilder logData = new StringBuilder();

            try
            {
                logData.AppendLine("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]");

                // -- 

                logData.Append(fArgs.fEventId.ToString() + " SML");
                logData.Append(", Result=<" + fArgs.fResult.ToString() + ">");
                if (fArgs.fResult != FResultCode.Success)
                {
                    logData.Append(", ErrorMessage=<" + fArgs.errorMessage + ">");
                }
                logData.AppendLine();

                // --                

                logData.Append("S" + fArgs.fSecsDataMessage.stream.ToString() + "F" + fArgs.fSecsDataMessage.function.ToString());
                if (fArgs.fSecsDataMessage.wbit)
                {
                    logData.Append(" W");
                }
                logData.Append(", SystemBytes=<" + fArgs.fSecsDataMessage.systemBytes.ToString() + ">, Length=<" + fArgs.fSecsDataMessage.length.ToString() + ">, SessionId=<" + fArgs.fSecsDataMessage.sessionId.ToString() + ">");
                logData.AppendLine();

                // --

                if (fArgs.fSecsDataMessage.body.Length > 0)
                {
                    logData.AppendLine(FSecsConverter.convertBinToSml(fArgs.fSecsDataMessage.body));
                }

                // --

                logData.AppendLine();
                m_fLogQueue.enqueue(logData.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                logData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void write(
            FEventArgsBase fArgs
            )
        {
            try
            {
                if (fArgs.fEventId == FEventId.LogMonitoring)
                {
                    return;
                }

                // -- 

                if (fArgs.fEventId == FEventId.Secs1StateChanged)
                {
                    writeSecs1StateChanged((FSecs1StateChangedEventArgs)fArgs);
                }
                else if (fArgs.fEventId == FEventId.Secs1ErrorRaised)
                {
                    writeSecs1ErrorRaised((FSecs1ErrorRaisedEventArgs)fArgs);
                }
                else if (fArgs.fEventId == FEventId.Secs1TimeoutRaised)
                {
                    writeSecs1TimeoutRaised((FSecs1TimeoutRaisedEventArgs)fArgs);
                }
                else if (fArgs.fEventId == FEventId.Secs1HandshakeReceived)
                {
                    writeSecs1HandshakeReceived((FSecs1HandshakeReceivedEventArgs)fArgs);
                }
                else if (fArgs.fEventId == FEventId.Secs1HandshakeSent)
                {
                    writeSecs1HandshakeSent((FSecs1HandshakeSentEventArgs)fArgs);
                }
                else if (fArgs.fEventId == FEventId.Secs1BlockReceived)
                {
                    writeSecs1BlockReceived((FSecs1BlockReceivedEventArgs)fArgs);
                }
                else if (fArgs.fEventId == FEventId.Secs1BlockSent)
                {
                    writeSecs1BlockSent((FSecs1BlockSentEventArgs)fArgs);
                }
                else if (fArgs.fEventId == FEventId.Secs1DataMessageReceived)
                {
                    writeSecs1DataMessageReceivedSml((FSecs1DataMessageReceivedEventArgs)fArgs);
                }
                else if (fArgs.fEventId == FEventId.Secs1DataMessageSent)
                {
                    writeSecs1DataMessageSentSml((FSecs1DataMessageSentEventArgs)fArgs);
                }
                // --
                else if (fArgs.fEventId == FEventId.HsmsStateChanged)
                {
                    writeHsmsStateChanged((FHsmsStateChangedEventArgs)fArgs);
                }
                else if (fArgs.fEventId == FEventId.HsmsErrorRaised)
                {
                    writeHsmsErrorRaised((FHsmsErrorRaisedEventArgs)fArgs);
                }
                else if (fArgs.fEventId == FEventId.HsmsTimeoutRaised)
                {
                    writeHsmsTimeoutRaised((FHsmsTimeoutRaisedEventArgs)fArgs);
                }
                else if (fArgs.fEventId == FEventId.HsmsControlMessageReceived)
                {
                    writeHsmsControlMessageReceived((FHsmsControlMessageReceivedEventArgs)fArgs);
                }
                else if (fArgs.fEventId == FEventId.HsmsControlMessageSent)
                {
                    writeHsmsControlMessageSent((FHsmsControlMessageSentEventArgs)fArgs);
                }
                else if (fArgs.fEventId == FEventId.HsmsDataMessageReceived)
                {
                    writeHsmsDataMessageReceived((FHsmsDataMessageReceivedEventArgs)fArgs);
                    writeHsmsDataMessageReceivedSml((FHsmsDataMessageReceivedEventArgs)fArgs);
                }
                else if (fArgs.fEventId == FEventId.HsmsDataMessageSent)
                {
                    writeHsmsDataMessageSent((FHsmsDataMessageSentEventArgs)fArgs);
                    writeHsmsDataMessageSentSml((FHsmsDataMessageSentEventArgs)fArgs);
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

        public void write(
            string log
            )
        {
            StringBuilder logData = new StringBuilder();

            try
            {
                logData.AppendLine("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]");
                logData.Append(log);
                m_fLogQueue.enqueue(logData.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                logData = null;
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
            try
            {
                if (m_fLogQueue.count == 0)
                {
                    e.sleepThread(1);
                    return;
                }
                writeLog();
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
                e.sleepThread(1);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
