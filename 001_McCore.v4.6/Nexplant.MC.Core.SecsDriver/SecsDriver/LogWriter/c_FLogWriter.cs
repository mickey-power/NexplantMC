/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FLogWriter.cs
--  Creator         : byungyun.jeon
--  Create Date     : 2012.03.14
--  Description     : FAMate Core FaSecsDriver Log Writer Class
--  History         : Created by byungyun.jeon at 2012.03.14
                      Modified by spike.lee at 2012.11.19
                        - FConfig의 eapName이 변경되었을 경우 사용하던 Log를 Cut하고 Log File를 다시 생성하도록 수정
----------------------------------------------------------------------------------------------------------*/
using System;
using Nexplant.MC.Core.FaCommon;
using System.IO;
using System.Collections;
using System.Text;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal class FLogWriter : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string BinaryLogFileExt = "bng";
        private const string SmlLogFileExt = "sml";
        private const string VfeiLogFileExt = "vfe";
        private const string SecsLogFileExt = "ssl";
        private const string SecsLogTail = "\t</SCD>\r\n</FAM>";
        private const int SecsLogTailLength = 15;

        //--

        private bool m_disposed = false;
        // -- 
        private FScdCore m_fScdCore = null;        
        // --
        private FCodeLock m_fBinaryLogLock = null;
        private string m_binaryLogEapName = string.Empty;
        private FQueue<string> m_fBinaryLogQueue = null;
        private FileStream m_fsBinaryLogFile = null;
        private StreamWriter m_swBinaryLogFile = null;
        private long m_binaryLogCount = 0;
        // --
        private FCodeLock m_fSmlLogLock = null;
        private string m_smlLogEapName = string.Empty;
        private FQueue<string> m_fSmlLogQueue = null;
        private FileStream m_fsSmlLogFile = null;
        private StreamWriter m_swSmlLogFile = null;
        private long m_smlLogCount = 0;
        // --
        private FCodeLock m_fVfeiLogLock = null;
        private string m_vfeiLogEapName = string.Empty;
        private FQueue<string> m_fVfeiLogQueue = null;
        private FileStream m_fsVfeiLogFile = null;
        private StreamWriter m_swVfeiLogFile = null;
        private long m_vfeiLogCount = 0;
        // --
        private FCodeLock m_fSecsLogLock = null;
        private string m_secsLogEapName = string.Empty;
        private FQueue<string> m_fSecsLogQueue = null;
        private FileStream m_fsSecsLogFile = null;
        private StreamWriter m_swSecsLogFile = null;
        private long m_secsLogCount = 0;
        // --
        private FCodeLock m_fThdSync = null;    // Log Write Thread와 Log Cut Method Sync로 사용됨.
        private FThread m_fThdMain = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FLogWriter(
            FScdCore fScdCore
            )
        {
            m_fScdCore = fScdCore;
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FLogWriter(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void myDispose(
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            try
            {
                m_binaryLogEapName = m_fScdCore.fConfig.eapName;
                m_fBinaryLogQueue = new FQueue<string>();
                m_fBinaryLogLock = new FCodeLock();
                // --
                m_smlLogEapName = m_fScdCore.fConfig.eapName;
                m_fSmlLogQueue = new FQueue<string>();
                m_fSmlLogLock = new FCodeLock();
                // --
                m_vfeiLogEapName = m_fScdCore.fConfig.eapName;
                m_fVfeiLogQueue = new FQueue<string>();
                m_fVfeiLogLock = new FCodeLock();
                // --
                m_secsLogEapName = m_fScdCore.fConfig.eapName;
                m_fSecsLogQueue = new FQueue<string>();
                m_fSecsLogLock = new FCodeLock();
                
                // --

                m_fThdSync = new FCodeLock();
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
                    while(
                        m_fBinaryLogQueue.count > 0 ||
                        m_fSmlLogQueue.count > 0 ||
                        m_fVfeiLogQueue.count > 0 ||
                        m_fSecsLogQueue.count > 0
                        )
                    {
                        System.Threading.Thread.Sleep(1);
                    }

                    // -- 

                    m_fThdMain.stop();
                    m_fThdMain.Dispose();
                    m_fThdMain.ThreadJobCalled -= new FThreadJobCalledEventHandler(m_fThdMain_ThreadJobCalled);
                    m_fThdMain = null;
                }
                // --
                if (m_fThdSync != null)
                {
                    m_fThdSync.Dispose();
                    m_fThdSync = null;
                }
                
                // -- 

                closeBinaryLogFile();
                // --
                if (m_fBinaryLogQueue != null)
                {
                    m_fBinaryLogQueue.Dispose();
                    m_fBinaryLogQueue = null;
                }
                // --
                if (m_fBinaryLogLock != null)
                {
                    m_fBinaryLogLock.Dispose();
                    m_fBinaryLogLock = null;
                }

                // --

                closeSmlLogFile();
                // --
                if (m_fSmlLogQueue != null)
                {
                    m_fSmlLogQueue.Dispose();
                    m_fSmlLogQueue = null;
                }
                // --
                if (m_fSmlLogLock != null)
                {
                    m_fSmlLogLock.Dispose();
                    m_fSmlLogLock = null;
                }

                // --

                closeVfeiLogFile();
                // --
                if (m_fVfeiLogQueue != null)
                {
                    m_fVfeiLogQueue.Dispose();
                    m_fVfeiLogQueue = null;
                }
                // --
                if (m_fVfeiLogLock != null)
                {
                    m_fVfeiLogLock.Dispose();
                    m_fVfeiLogLock = null;
                }

                // --

                closeSecsLogFile();
                // --
                if (m_fSecsLogQueue != null)
                {
                    m_fSecsLogQueue.Dispose();
                    m_fSecsLogQueue = null;
                }
                // --
                if (m_fSecsLogLock != null)
                {
                    m_fSecsLogLock.Dispose();
                    m_fSecsLogLock = null;
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

        private void openBinaryLogFile(
            )
        {
            string filename = string.Empty;

            try
            {
                if (!Directory.Exists(m_fScdCore.fConfig.logDirectory))
                {
                    Directory.CreateDirectory(m_fScdCore.fConfig.logDirectory);
                }

                // -- 

                if (
                    m_fsBinaryLogFile == null || 
                    m_swBinaryLogFile == null ||
                    m_fsBinaryLogFile.Length >= m_fScdCore.fConfig.maxLogFileSizeOfBinary ||
                    m_binaryLogEapName != m_fScdCore.fConfig.eapName ||
                    m_binaryLogCount >= m_fScdCore.fConfig.maxLogCountOfBinary
                    )
                {
                    closeBinaryLogFile();

                    // --

                    m_binaryLogEapName = m_fScdCore.fConfig.eapName;
                    filename = makeLogFileName(m_fScdCore.fConfig.logDirectory, m_binaryLogEapName, BinaryLogFileExt);
                    // --
                    m_fsBinaryLogFile = new FileStream(filename, FileMode.OpenOrCreate | FileMode.Append, FileAccess.Write, FileShare.Read);
                    m_swBinaryLogFile = new StreamWriter(m_fsBinaryLogFile);
                    m_binaryLogCount = 0;
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

        private void writeBinaryLogFile(
            )
        {
            try
            {
                openBinaryLogFile();

                // -- 

                while (m_fBinaryLogQueue.count > 0)
                {
                    m_swBinaryLogFile.Write(m_fBinaryLogQueue.dequeue());
                    // --
                    m_binaryLogCount++;
                    if (m_binaryLogCount >= m_fScdCore.fConfig.maxLogCountOfBinary)
                    {
                        break;
                    }
                }

                // -- 

                m_swBinaryLogFile.Flush();
                m_fsBinaryLogFile.Flush();
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

        // ***
        // 2012.11.26 by spike.lee
        // Length는 data Array의 Length를 사용하면 됩니다.
        // length Argument 제거합니다.
        // ***
        public void pushBinaryLog(
            FEventId fEventId,
            string time,
            string deviceName,
            FProtocol fProtocol,            
            FConnectMode fConnectMode,
            string localIp,
            int localPort,
            string remoteIp,
            int remotePort,
            byte[] data            
            )
        {
            string eventType = string.Empty;
            StringBuilder log = null;

            // ***
            // 2012.11.26 by spike.lee
            // 만약 여러개의 SECS Device가 Log를 기록할 경우 어떻게 되겠습니까?
            // SECS Device 별로 Log가 기록되지 않고 뒤섞기지 않겠습니까?
            // Multi-Thread에서의 처리가 잘 못 되었습니다.
            // Log 단위로 기록하도록 처리하고 Sync 처리합니다.
            // *** 
            try
            {
                m_fBinaryLogLock.wait();

                // -- 

                log = new StringBuilder();

                // --

                if (fEventId == FEventId.SecsDeviceDataReceived)
                {
                    eventType = "DataReceived";
                }
                else if (fEventId == FEventId.SecsDeviceDataSent)
                {
                    eventType = "DataSent    ";
                }

                // --

                // ***
                // Header
                // ***
                log.AppendLine("[" + time + "] " + eventType + ", SecsDevice=<" + deviceName + ">, Protocol=<" + fProtocol + ">, Length=<" + data.Length.ToString() + ">");
                log.AppendLine("[" + time + "] ConnectMode=<" + fConnectMode + ">, LocalIP=<" + localIp + ">, LocalPort=<" + localPort + ">, RemoteIP=<" + remoteIp + ">, RemotePort=<" + remotePort + ">");

                // --

                // ***
                // Body
                // ***
                foreach(string s in FMessageConverter.convertBinToString(data, 30).Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                {
                    log.AppendLine("[" + time + "] " + s);
                }
                log.AppendLine("--");

                // --

                m_fBinaryLogQueue.enqueue(log.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                log = null;
                m_fBinaryLogLock.set();
            }
        }
       
        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2012.11.26 by spike.lee
        // Length는 data Array의 Length를 사용하면 됩니다.
        // length Argument 제거합니다.
        // fConnectMode는 SECS1에서는 사용되지 않는 Parameter입니다.
        // 또한 Log로 기록하지도 않습니다. fConnectMode Argument 제거합니다.
        // ***
        public void pushBinaryLog(
            FEventId fEventId,
            string time,
            string deviceName,
            FProtocol fProtocol,                        
            string serialPort,
            int baud,
            byte[] data
            )
        {
            string eventType = string.Empty;
            StringBuilder log = null;

            // ***
            // 2012.11.26 by spike.lee
            // 만약 여러개의 SECS Device가 Log를 기록할 경우 어떻게 되겠습니까?
            // SECS Device 별로 Log가 기록되지 않고 뒤섞기지 않겠습니까?
            // Multi-Thread에서의 처리가 잘 못 되었습니다.
            // Log 단위로 기록하도록 처리하고 Sync 처리합니다.
            // *** 
            try
            {
                m_fBinaryLogLock.wait();

                // --

                log = new StringBuilder();

                // -- 

                if (fEventId == FEventId.SecsDeviceDataReceived)
                {
                    eventType = "DataReceived";
                }
                else if (fEventId == FEventId.SecsDeviceDataSent)
                {
                    eventType = "DataSent    ";
                }

                // --

                // ***
                // 2012.11.26 by spike.lee
                // BaudRate란 용어는 FAMate에서 사용하지 않습니다.
                // Baud로 정정합니다.
                // --
                // Header
                // ***
                log.AppendLine("[" + time + "] " + eventType + ", SecsDevice=<" + deviceName + ">, Protocol=<" + fProtocol + ">, Length=<" + data.Length.ToString() + ">");
                log.AppendLine("[" + time + "] SerialPort=<" + serialPort + ">, Baud=<" + baud + ">");

                // --

                // ***
                // Body
                // ***
                foreach (string s in FMessageConverter.convertBinToString(data, 30).Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                {
                    log.AppendLine("[" + time + "] " + s);
                }
                log.AppendLine("--");

                // --

                m_fBinaryLogQueue.enqueue(log.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                log = null;
                m_fBinaryLogLock.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void closeBinaryLogFile(
            )
        {
            try
            {
                if (m_swBinaryLogFile != null)
                {
                    m_swBinaryLogFile.Flush();
                    m_swBinaryLogFile.Close();
                    m_swBinaryLogFile.Dispose();
                    m_swBinaryLogFile = null;
                }                

                if (m_fsBinaryLogFile != null)
                {
                    m_fsBinaryLogFile.Close();
                    m_fsBinaryLogFile.Dispose();
                    m_fsBinaryLogFile = null;
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

        public void cutBinaryLogFile(
            )
        {
            // ***
            // 2012.11.26 by spike.lee
            // Log 기록은 별도의 Thread로 기록되고 있습니다.
            // Log 기록중에 Log Cut 명령으로 인해 Log File 개체가 모두 null 처리된다면 어떻게 될까요?
            // Multi-Thread에 대한 기본적인 이해를 못 하셨나 봅니다. 공부좀 합시다.
            // ***
            try
            {
                m_fThdSync.wait();

                // --

                closeBinaryLogFile();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fThdSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void openSmlLogFile(
            )
        {
            string filename = string.Empty;

            try
            {
                if (!Directory.Exists(m_fScdCore.fConfig.logDirectory))
                {
                    Directory.CreateDirectory(m_fScdCore.fConfig.logDirectory);    
                }

                // -- 

                if (
                    m_swSmlLogFile == null ||
                    m_fsSmlLogFile == null ||
                    m_fsSmlLogFile.Length > m_fScdCore.fConfig.maxLogFileSizeOfSml ||
                    m_smlLogEapName != m_fScdCore.fConfig.eapName ||
                    m_smlLogCount >= m_fScdCore.fConfig.maxLogCountOfSml
                    )
                {
                    closeSmlLogFile();

                    // --

                    m_smlLogEapName = m_fScdCore.fConfig.eapName;
                    filename = makeLogFileName(m_fScdCore.fConfig.logDirectory, m_smlLogEapName, SmlLogFileExt);
                    // --
                    m_fsSmlLogFile = new FileStream(filename, FileMode.OpenOrCreate | FileMode.Append, FileAccess.Write, FileShare.Read);
                    m_swSmlLogFile = new StreamWriter(m_fsSmlLogFile);
                    m_smlLogCount = 0;
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

        private void writeSmlLogFile(
            )
        {
            try
            {
                openSmlLogFile();

                // -- 

                while (m_fSmlLogQueue.count > 0)
                {
                    m_swSmlLogFile.Write(m_fSmlLogQueue.dequeue());
                    // --
                    m_smlLogCount++;
                    if (m_smlLogCount >= m_fScdCore.fConfig.maxLogCountOfSml)
                    {
                        break;
                    }
                }

                // -- 

                m_swSmlLogFile.Flush();
                m_fsSmlLogFile.Flush();
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

        public void pushSmlLog(
            FEventId fEventId,
            string time,
            string deviceName,
            UInt16 sessionId,
            UInt32 systemBytes,
            UInt32 length,
            FResultCode fResultCode,
            string resultMessage,
            string sml
            )
        {
            string eventType = string.Empty;
            StringBuilder log = null;

            // ***
            // 2012.11.26 by spike.lee
            // 만약 여러개의 SECS Device가 Log를 기록할 경우 어떻게 되겠습니까?
            // SECS Device 별로 Log가 기록되지 않고 뒤섞기지 않겠습니까?
            // Multi-Thread에서의 처리가 잘 못 되었습니다.
            // Log 단위로 기록하도록 처리하고 Sync 처리합니다.
            // *** 
            try
            {
                m_fSmlLogLock.wait();

                // --

                log = new StringBuilder();

                // --

                if (fEventId == FEventId.SecsDeviceSmlReceived)
                {
                    eventType = "DataReceived";
                }
                else if (fEventId == FEventId.SecsDeviceSmlSent)
                {
                    eventType = "DataSent    ";
                }

                // --

                // ***
                // Header
                // ***
                log.AppendLine("[" + time + "] " + eventType + ", SecsDevice=<" + deviceName + ">, SessionId=<" + sessionId + ">, SystemBytes=<" + systemBytes + ">, Length=<" + length + ">" );
                log.AppendLine("[" + time + "] ResultCode=<" + fResultCode + ">, ResultMessage=<" + resultMessage + ">");

                // --

                // ***
                // Body
                // ***
                foreach (string s in sml.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                {
                    log.AppendLine("[" + time + "] " + s);
                }
                log.AppendLine("--");

                // --

                m_fSmlLogQueue.enqueue(log.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                log = null;
                m_fSmlLogLock.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void closeSmlLogFile(
           )
        {
            try
            {
                if (m_swSmlLogFile != null)
                {
                    m_swSmlLogFile.Flush();
                    m_swSmlLogFile.Close();
                    m_swSmlLogFile.Dispose();
                    m_swSmlLogFile = null;
                }

                if (m_fsSmlLogFile != null)
                {
                    m_fsSmlLogFile.Close();
                    m_fsSmlLogFile.Dispose();
                    m_fsSmlLogFile = null;
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

        public void cutSmlLogFile(
            )
        {
            // ***
            // 2012.11.26 by spike.lee
            // Log 기록은 별도의 Thread로 기록되고 있습니다.
            // Log 기록중에 Log Cut 명령으로 인해 Log File 개체가 모두 null 처리된다면 어떻게 될까요?
            // Multi-Thread에 대한 기본적인 이해를 못 하셨나 봅니다. 공부좀 합시다.
            // ***
            try
            {
                m_fThdSync.wait();

                // --

                closeSmlLogFile();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fThdSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void openVfeiLogFile(
            )
        {
            string filename = string.Empty;

            try
            {
                if (!Directory.Exists(m_fScdCore.fConfig.logDirectory))
                {
                    Directory.CreateDirectory(m_fScdCore.fConfig.logDirectory);
                }

                // --

                if (
                    m_swVfeiLogFile == null ||
                    m_fsVfeiLogFile == null ||
                    m_fsVfeiLogFile.Length >= m_fScdCore.fConfig.maxLogFileSizeOfVfei ||
                    m_vfeiLogEapName != m_fScdCore.fConfig.eapName ||
                    m_vfeiLogCount >= m_fScdCore.fConfig.maxLogCountOfVfei
                    )
                {
                    closeVfeiLogFile();

                    // --

                    m_vfeiLogEapName = m_fScdCore.fConfig.eapName;
                    filename = makeLogFileName(m_fScdCore.fConfig.logDirectory, m_vfeiLogEapName, VfeiLogFileExt);
                    // --
                    m_fsVfeiLogFile = new FileStream(filename, FileMode.OpenOrCreate | FileMode.Append, FileAccess.Write, FileShare.Read);
                    m_swVfeiLogFile = new StreamWriter(m_fsVfeiLogFile);
                    m_vfeiLogCount = 0;
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

        private void writeVfeiLogFile(
            )
        {
            try
            {
                openVfeiLogFile();

                // -- 

                while (m_fVfeiLogQueue.count > 0)
                {
                    m_swVfeiLogFile.Write(m_fVfeiLogQueue.dequeue());
                    // --
                    m_vfeiLogCount++;
                    if (m_vfeiLogCount >= 0)
                    {
                        break;
                    }
                }

                // -- 

                m_swVfeiLogFile.Flush();
                m_fsVfeiLogFile.Flush();
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

        public void pushVfeiLog(
            FEventId fEventId,
            string time,
            string deviceName,
            UInt16 sessionId,
            FResultCode fResultCode,
            string resultMessage,
            string vfei
            )
        {
            string eventType = string.Empty;
            StringBuilder log = null;

            // ***
            // 2012.11.26 by spike.lee
            // 만약 여러개의 SECS Device가 Log를 기록할 경우 어떻게 되겠습니까?
            // SECS Device 별로 Log가 기록되지 않고 뒤섞기지 않겠습니까?
            // Multi-Thread에서의 처리가 잘 못 되었습니다.
            // Log 단위로 기록하도록 처리하고 Sync 처리합니다.
            // *** 
            try
            {
                m_fVfeiLogLock.wait();

                // --

                log = new StringBuilder();

                // --

                if (fEventId == FEventId.HostDeviceVfeiReceived)
                {
                    eventType = "DataReceived";
                }
                else if (fEventId == FEventId.HostDeviceVfeiSent)
                {
                    eventType = "DataSent    ";
                }

                // --

                // ***
                // Header
                // ***
                log.AppendLine("[" + time + "] " + eventType + ", SecsDevice=<" + deviceName + ">, SessionId=<" + sessionId + ">");
                log.AppendLine("[" + time + "] ResultCode=<" + fResultCode + ">, ResultMessage=<" + resultMessage + ">");

                // --

                // ***
                // Body
                // ***
                foreach (string s in vfei.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                {
                    log.AppendLine("[" + time + "] " + s);
                }
                log.AppendLine("--");

                // --

                m_fVfeiLogQueue.enqueue(log.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                log = null;
                m_fVfeiLogLock.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void closeVfeiLogFile(
            )
        {
            try
            {
                if (m_swVfeiLogFile != null)
                {
                    m_swVfeiLogFile.Flush();
                    m_swVfeiLogFile.Close();
                    m_swVfeiLogFile.Dispose();
                    m_swVfeiLogFile = null;
                }

                if (m_fsVfeiLogFile != null)
                {
                    m_fsVfeiLogFile.Close();
                    m_fsVfeiLogFile.Dispose();
                    m_fsVfeiLogFile = null;
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

        public void cutVfeiLogFile(
            )
        {
            // ***
            // 2012.11.26 by spike.lee
            // Log 기록은 별도의 Thread로 기록되고 있습니다.
            // Log 기록중에 Log Cut 명령으로 인해 Log File 개체가 모두 null 처리된다면 어떻게 될까요?
            // Multi-Thread에 대한 기본적인 이해를 못 하셨나 봅니다. 공부좀 합시다.
            // ***
            try
            {
                m_fThdSync.wait();

                // --

                closeVfeiLogFile();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fThdSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void openSecsLogFile(
            )
        {
            string filename = string.Empty;

            try
            {
                if (!Directory.Exists(m_fScdCore.fConfig.logDirectory))
                {
                    Directory.CreateDirectory(m_fScdCore.fConfig.logDirectory);
                }

                // --

                if (
                    m_swSecsLogFile == null ||
                    m_fsSecsLogFile == null ||
                    m_fsSecsLogFile.Length >= m_fScdCore.fConfig.maxLogFileSizeOfSecs ||
                    m_secsLogCount >= m_fScdCore.fConfig.maxLogCountOfSecs
                    )
                {
                    closeSecsLogFile();
                    
                    // --

                    m_secsLogEapName = m_fScdCore.fConfig.eapName;
                    filename = makeLogFileName(m_fScdCore.fConfig.logDirectory, m_secsLogEapName, SecsLogFileExt);
                    // --
                    m_fsSecsLogFile = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
                    m_swSecsLogFile = new StreamWriter(m_fsSecsLogFile);
                    m_secsLogCount = 0;
                    
                    // --
                    
                    initSecsLogFile();
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

        private void writeSecsLogFile(
            FThreadEventArgs e
            )
        {
            try
            {
                openSecsLogFile();

                // --

                // ***
                // <?xml version="1.0"?>
                // <FAM>
                //     <SCD>
                //          ...
                //     </SCD>
                //    ↑
                // </FAM>
                // ***
                m_fsSecsLogFile.Seek(-(SecsLogTailLength + 2), SeekOrigin.Current);

                // -- 

                while (m_fSecsLogQueue.count > 0)
                {
                    m_swSecsLogFile.WriteLine(m_fSecsLogQueue.dequeue());
                    // --
                    m_secsLogCount++;
                    if (m_secsLogCount >= m_fScdCore.fConfig.maxLogCountOfSecs)
                    {
                        break;
                    }
                }

                // -- 

                // ***
                // <?xml version="1.0"?>
                // <FAM>
                //     <SCD>
                //          ... + α
                //     </SCD>
                // </FAM>
                //      ↑
                // ***
                m_swSecsLogFile.WriteLine(SecsLogTail);

                // --

                m_swSecsLogFile.Flush();
                m_fsSecsLogFile.Flush();
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

        public void pushSecsLog(
            FXmlNode fXmlNode
            )
        {
            // ***
            // 2012.11.26 by spike.lee
            // 만약 여러개의 SECS Device가 Log를 기록할 경우 어떻게 되겠습니까?
            // SECS Device 별로 Log가 기록되지 않고 뒤섞기지 않겠습니까?
            // Multi-Thread에서의 처리가 잘 못 되었습니다.
            // Log 단위로 기록하도록 처리하고 Sync 처리합니다.
            // *** 
            try
            {
                m_fSecsLogLock.wait();

                // --

                // ***
                // 2017.04.04 by spike.lee
                // SECS Log File Enable Option 적용
                // *** 
                if (m_fScdCore.fConfig.enabledLogOfSecs)
                {
                    m_fSecsLogQueue.enqueue(fXmlNode.xmlToString(true));                
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fSecsLogLock.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void closeSecsLogFile(
            )
        {
            try
            {
                if (m_swSecsLogFile != null)
                {
                    m_swSecsLogFile.Flush();
                    m_swSecsLogFile.Close();
                    m_swSecsLogFile.Dispose();
                    m_swSecsLogFile = null;
                }

                if (m_fsSecsLogFile != null)
                {
                    m_fsSecsLogFile.Close();
                    m_fsSecsLogFile.Dispose();
                    m_fsSecsLogFile = null;
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

        public void cutSecsLogFile(
            )
        {
            // ***
            // 2012.11.26 by spike.lee
            // Log 기록은 별도의 Thread로 기록되고 있습니다.
            // Log 기록중에 Log Cut 명령으로 인해 Log File 개체가 모두 null 처리된다면 어떻게 될까요?
            // Multi-Thread에 대한 기본적인 이해를 못 하셨나 봅니다. 공부좀 합시다.
            // ***
            try
            {
                m_fThdSync.wait();

                // --

                closeSecsLogFile();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fThdSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void initSecsLogFile(
            )
        {
            const string XmlDeclarationString = "<?xml version=\"1.0\"?>";
            const string SecsLogFirstTail = ">\r\n\t</SCD>\r\n</FAM>";
            const int SecsLogFirstTailLength = 13;

            // -- 

            FXmlDocument fXmlDoc = null;
            FXmlNode fXmlNodeFam = null;
            FXmlNode fXmlNodeScdl = null;

            try
            {
                fXmlDoc = new FXmlDocument();
                fXmlDoc.preserveWhiteSpace = false;
                //fXmlDoc.appendChild(fXmlDoc.createXmlDeclaration("1.0", string.Empty, string.Empty));
                // --
                fXmlNodeFam = fXmlDoc.appendChild(FSecsDriverLogCommon.createXmlNodeFAM(fXmlDoc));
                fXmlNodeScdl = fXmlNodeFam.appendChild(FSecsDriverLogCommon.createXmlNodeSCDL(fXmlDoc));
                fXmlNodeScdl.set_attrVal(FXmlTagSCDL.A_Name, FXmlTagSCDL.D_Name, m_fScdCore.fSecsDriver.name);
                fXmlNodeScdl.set_attrVal(FXmlTagSCDL.A_Description, FXmlTagSCDL.D_Description, m_fScdCore.fSecsDriver.description);
                fXmlNodeScdl.set_attrVal(FXmlTagSCDL.A_FontBold, FXmlTagSCDL.D_FontBold, FBoolean.fromBool(m_fScdCore.fSecsDriver.fontBold));
                fXmlNodeScdl.set_attrVal(FXmlTagSCDL.A_FontColor, FXmlTagSCDL.D_FontColor, m_fScdCore.fSecsDriver.fontColor.Name);
                fXmlNodeScdl.set_attrVal(FXmlTagSCDL.A_EapName, FXmlTagSCDL.D_EapName, m_fScdCore.fSecsDriver.eapName);
                // -- 
                fXmlNodeScdl.set_attrVal(FXmlTagSCDL.A_UserTag1, FXmlTagSCDL.D_UserTag1, m_fScdCore.fSecsDriver.userTag1);
                fXmlNodeScdl.set_attrVal(FXmlTagSCDL.A_UserTag2, FXmlTagSCDL.D_UserTag2, m_fScdCore.fSecsDriver.userTag2);
                fXmlNodeScdl.set_attrVal(FXmlTagSCDL.A_UserTag3, FXmlTagSCDL.D_UserTag3, m_fScdCore.fSecsDriver.userTag3);
                fXmlNodeScdl.set_attrVal(FXmlTagSCDL.A_UserTag4, FXmlTagSCDL.D_UserTag4, m_fScdCore.fSecsDriver.userTag4);
                fXmlNodeScdl.set_attrVal(FXmlTagSCDL.A_UserTag5, FXmlTagSCDL.D_UserTag5, m_fScdCore.fSecsDriver.userTag5);

                // --

                // ***
                // <?xml version="1.0"?>
                // <FAM>
                //     <SCD/>
                // </FAM>
                //      ↑
                // ***
                m_swSecsLogFile.WriteLine(XmlDeclarationString);
                m_swSecsLogFile.WriteLine(fXmlNodeFam.xmlToString(true));
                m_swSecsLogFile.Flush();

                // ***
                // <?xml version="1.0"?>
                // <FAM>
                //     <SCD/>
                //    ↑
                // </FAM>
                // ***
                m_fsSecsLogFile.Seek(-SecsLogFirstTailLength, SeekOrigin.Current);

                // ***
                // <?xml version="1.0"?>
                // <FAM>
                //     <SCD>
                //     </SCD>
                // </FAM>
                //      ↑
                // ***
                m_swSecsLogFile.WriteLine(SecsLogFirstTail);


                // --

                m_swSecsLogFile.Flush();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeScdl != null)
                {
                    fXmlNodeScdl.Dispose();
                    fXmlNodeScdl = null;
                }

                if (fXmlNodeFam != null)
                {
                    fXmlNodeFam.Dispose();
                    fXmlNodeFam = null;
                }

                if (fXmlDoc != null)
                {
                    fXmlDoc.Dispose();
                    fXmlDoc = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        private string makeLogFileName(
            string directory,
            string eapName,
            string logFileExt
            )
        {
            string fileName = string.Empty;

            try
            {
                fileName = string.Format("{0}_{1}.{2}", DateTime.Now.ToString("yyyyMMddHHmmssfff"), eapName, logFileExt);
                return Path.Combine(directory, fileName);
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
                m_fThdSync.wait();

                // --

                if (
                    m_fBinaryLogQueue.count == 0 &&
                    m_fSmlLogQueue.count == 0 &&
                    m_fVfeiLogQueue.count == 0 &&
                    m_fSecsLogQueue.count == 0
                    )
                {
                    e.sleepThread(1);
                    return;
                }
                
                // -- 

                if (m_fBinaryLogQueue.count > 0)
                {
                    writeBinaryLogFile();
                }
                // --
                if (m_fSmlLogQueue.count > 0)
                {
                    writeSmlLogFile();
                }
                // --
                if (m_fVfeiLogQueue.count > 0)
                {
                    writeVfeiLogFile();
                }
                // --
                if (m_fSecsLogQueue.count > 0)
                {
                    writeSecsLogFile(e);
                }               
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fThdSync.set();
            }
        }
        
        #endregion
        
        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end