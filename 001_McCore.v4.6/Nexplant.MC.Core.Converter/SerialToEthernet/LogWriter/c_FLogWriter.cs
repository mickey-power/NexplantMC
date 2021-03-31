/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FLogWriter.cs
--  Creator         : mjkim
--  Create Date     : 2019.09.23
--  Description     : FAmate Converter FaSerialToEthernet Log Writer Class
--  History         : Created by mjkim at 2019.09.23
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSerialToEthernet
{
    internal class FLogWriter: IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        const string LogFileExt = "log";

        // --

        private bool m_disposed = false;
        // --
        private FSerialToEthernet m_fRS232ToEthernet = null;
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
            FSerialToEthernet fRS232ToEthernet
            )
        {
            m_fRS232ToEthernet = fRS232ToEthernet;
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
                    m_fRS232ToEthernet = null;
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

                m_logFileNameSuffix = m_fRS232ToEthernet.logFileNameSuffix;

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
                if (!Directory.Exists(m_fRS232ToEthernet.logDirectory))
                {
                    Directory.CreateDirectory(m_fRS232ToEthernet.logDirectory);
                }

                // --

                if (m_fsLogFile == null)
                {
                    m_logFileNameSuffix = m_fRS232ToEthernet.logFileNameSuffix;
                    searchPattern = "*_" + m_logFileNameSuffix + "." + LogFileExt;
                    files = Directory.GetFiles(m_fRS232ToEthernet.logDirectory, searchPattern);
                    // --
                    if (files.Length == 0)
                    {
                        m_logFileName = string.Empty;
                    }
                    else
                    {
                        m_logFileName = files[files.Length - 1];
                        fileInfo = new FileInfo(m_logFileName);
                        if (fileInfo.Length >= (m_fRS232ToEthernet.logFileMaxSize * 1024 * 1024))
                        {
                            m_logFileName = string.Empty;
                        }
                    }
                }
                else
                {
                    fileInfo = new FileInfo(m_logFileName);
                    if (fileInfo.Length >= (m_fRS232ToEthernet.logFileMaxSize * 1024 * 1024))
                    {
                        closeLogFile();
                        m_logFileName = string.Empty;
                    }
                    else if (m_logFileNameSuffix != m_fRS232ToEthernet.logFileNameSuffix)
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
                        m_logFileNameSuffix = m_fRS232ToEthernet.logFileNameSuffix;
                        m_logFileName = m_fRS232ToEthernet.logDirectory + "\\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + m_logFileNameSuffix + "." + LogFileExt;
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

        private void writeSerialStateChanged(
            FSerialPluginStateChangedEventArgs fArgs
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

        private void writeSerialErrorRaised(
            FSerialPluginErrorRaisedEventArgs fArgs
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

        private void writeSerialDataReceived(
            FSerialPluginDataReceivedEventArgs fArgs
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

                if (fArgs.fSerialData.data.Length > 0)
                {
                    foreach (string s in binToString(fArgs.fSerialData.data))
                    {
                        logData.AppendLine(s);
                    }
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

        private void writeSerialDataSent(
            FSerialPluginDataSentEventArgs fArgs
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

                if (fArgs.fSerialData.data.Length > 0)
                {
                    foreach (string s in binToString(fArgs.fSerialData.data))
                    {
                        logData.AppendLine(s);
                    }
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

        private void writeSocketStateChanged(
            FSocketStateChangedEventArgs fArgs
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

        private void writeSocketErrorRaised(
            FSocketErrorRaisedEventArgs fArgs
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

        private void writeSocketDataReceived(
            FSocketDataReceivedEventArgs fArgs
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

                foreach (string s in binToString(fArgs.fSocketData))
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

        private void writeSocketDataSent(
            FSocketDataSentEventArgs fArgs
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

                foreach (string s in binToString(fArgs.fSocketData.data))
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

                if (fArgs.fEventId == FEventId.SerialStateChanged)
                {
                    writeSerialStateChanged((FSerialPluginStateChangedEventArgs)fArgs);
                }
                else if (fArgs.fEventId == FEventId.SerialErrorRaised)
                {
                    writeSerialErrorRaised((FSerialPluginErrorRaisedEventArgs)fArgs);
                }
                else if (fArgs.fEventId == FEventId.SerialDataReceived)
                {
                    writeSerialDataReceived((FSerialPluginDataReceivedEventArgs)fArgs);
                }
                else if (fArgs.fEventId == FEventId.SerialDataSent)
                {
                    writeSerialDataSent((FSerialPluginDataSentEventArgs)fArgs);
                }
                // --
                else if (fArgs.fEventId == FEventId.SocketStateChanged)
                {
                    writeSocketStateChanged((FSocketStateChangedEventArgs)fArgs);
                }
                else if (fArgs.fEventId == FEventId.SocketErrorRaised)
                {
                    writeSocketErrorRaised((FSocketErrorRaisedEventArgs)fArgs);
                }
                else if (fArgs.fEventId == FEventId.SocketDataReceived)
                {
                    writeSocketDataReceived((FSocketDataReceivedEventArgs)fArgs);
                }
                else if (fArgs.fEventId == FEventId.SocketDataSent)
                {
                    writeSocketDataSent((FSocketDataSentEventArgs)fArgs);
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
