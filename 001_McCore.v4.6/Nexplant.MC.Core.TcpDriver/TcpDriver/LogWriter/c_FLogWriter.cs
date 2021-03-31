/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FLogWriter.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.15
--  Description     : FAMate Core FaTcpDriver Log Writer Class
--  History         : Created by Jeff.Kim at 2013.07.15
----------------------------------------------------------------------------------------------------------*/
using System;
using Nexplant.MC.Core.FaCommon;
using System.IO;
using System.Collections;
using System.Text;

namespace Nexplant.MC.Core.FaTcpDriver
{
    internal class FLogWriter : IDisposable
    {
        //------------------------------------------------------------------------------------------------------------------------

        private const string BinaryLogFileExt = "bng";
        private const string XmlLogFileExt = "xlg";
        private const string VfeiLogFileExt = "vfe";
        private const string TcpLogFileExt = "tsl";
        private const string TcpLogTail = "\t</TCD>\r\n</FAM>";
        private const int TcpLogTailLength = 15;

        //--
        private bool m_disposed = false;
        // -- 
        private FTcdCore m_fTcdCore = null;        
        // --       
        private FCodeLock m_fBinaryLogLock = null;
        private string m_binaryLogEapName = string.Empty;
        private FQueue<string> m_fBinaryLogQueue = null;
        private FileStream m_fsBinaryLogFile = null;
        private StreamWriter m_swBinaryLogFile = null;
        private long m_binaryLogCount = 0;
        // --
        private FCodeLock m_fXmlLogLock = null;
        private string m_xmlLogEapName = string.Empty;
        private FQueue<string> m_fXmlLogQueue = null;
        private FileStream m_fsXmlLogFile = null;
        private StreamWriter m_swXmlLogFile = null;
        private long m_xmlLogCount = 0;
        // --
        private FCodeLock m_fVfeiLogLock = null;
        private string m_vfeiLogEapName = string.Empty;
        private FQueue<string> m_fVfeiLogQueue = null;
        private FileStream m_fsVfeiLogFile = null;
        private StreamWriter m_swVfeiLogFile = null;
        private long m_vfeiLogCount = 0;
        // --
        private FCodeLock m_fTcpLogLock = null;
        private string m_tcpLogEapName = string.Empty;
        private FQueue<string> m_fTcpLogQueue = null;
        private FileStream m_fsTcpLogFile = null;
        private StreamWriter m_swTcpLogFile = null;
        private long m_tcpLogCount = 0;
        // --
        private FCodeLock m_fThdSync = null;    // Log Write Thread와 Log Cut Method Sync로 사용됨.
        private FThread m_fThdMain = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FLogWriter(
            FTcdCore fTcdCore
            )
        {
            m_fTcdCore = fTcdCore;
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
                m_binaryLogEapName = m_fTcdCore.fConfig.eapName;
                m_fBinaryLogQueue = new FQueue<string>();
                m_fBinaryLogLock = new FCodeLock();
                // --
                m_xmlLogEapName = m_fTcdCore.fConfig.eapName;
                m_fXmlLogQueue = new FQueue<string>();
                m_fXmlLogLock = new FCodeLock();
                // --
                m_vfeiLogEapName = m_fTcdCore.fConfig.eapName;
                m_fVfeiLogQueue = new FQueue<string>();
                m_fVfeiLogLock = new FCodeLock();                      
                // --
                m_tcpLogEapName = m_fTcdCore.fConfig.eapName;
                m_fTcpLogQueue = new FQueue<string>();
                m_fTcpLogLock = new FCodeLock();
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
                    while (
                        m_fVfeiLogQueue.count > 0 ||
                        m_fTcpLogQueue.count > 0
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

                closeXmlLogFile();
                // --
                if (m_fXmlLogQueue != null)
                {
                    m_fXmlLogQueue.Dispose();
                    m_fXmlLogQueue = null;
                }
                // --
                if (m_fXmlLogLock != null)
                {
                    m_fXmlLogLock.Dispose();
                    m_fXmlLogLock = null;
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

                closeTcpLogFile();
                // --
                if (m_fTcpLogQueue != null)
                {
                    m_fTcpLogQueue.Dispose();
                    m_fTcpLogQueue = null;
                }
                // --
                if (m_fTcpLogLock != null)
                {
                    m_fTcpLogLock.Dispose();
                    m_fTcpLogLock = null;
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

        private void openVfeiLogFile(
            )
        {
            string filename = string.Empty;

            try
            {
                if (!Directory.Exists(m_fTcdCore.fConfig.logDirectory))
                {
                    Directory.CreateDirectory(m_fTcdCore.fConfig.logDirectory);
                }

                // --

                if (
                    m_swVfeiLogFile == null ||
                    m_fsVfeiLogFile == null ||
                    m_fsVfeiLogFile.Length >= m_fTcdCore.fConfig.maxLogFileSizeOfVfei ||
                    m_vfeiLogEapName != m_fTcdCore.fConfig.eapName ||
                    m_vfeiLogCount >= m_fTcdCore.fConfig.maxLogCountOfVfei
                    )
                {
                    closeVfeiLogFile();

                    // --

                    m_vfeiLogEapName = m_fTcdCore.fConfig.eapName;
                    filename = makeLogFileName(m_fTcdCore.fConfig.logDirectory, m_vfeiLogEapName, VfeiLogFileExt);
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
                log.AppendLine("[" + time + "] " + eventType + ", TcpDevice=<" + deviceName + ">, SessionId=<" + sessionId + ">");
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

        private void openTcpLogFile(
            )
        {
            string filename = string.Empty;

            try
            {
                if (!Directory.Exists(m_fTcdCore.fConfig.logDirectory))
                {
                    Directory.CreateDirectory(m_fTcdCore.fConfig.logDirectory);
                }

                // --

                if (
                    m_swTcpLogFile == null ||
                    m_fsTcpLogFile == null ||
                    m_fsTcpLogFile.Length >= m_fTcdCore.fConfig.maxLogFileSizeOfTcp ||
                    m_tcpLogCount >= m_fTcdCore.fConfig.maxLogCountOfTcp
                    )
                {
                    closeTcpLogFile();

                    // --

                    m_tcpLogEapName = m_fTcdCore.fConfig.eapName;
                    filename = makeLogFileName(m_fTcdCore.fConfig.logDirectory, m_tcpLogEapName, TcpLogFileExt);
                    // --
                    m_fsTcpLogFile = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
                    m_swTcpLogFile = new StreamWriter(m_fsTcpLogFile);
                    m_tcpLogCount = 0;

                    // --

                    initTcpLogFile();
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

        private void writeTcpLogFile(
            )
        {
            try
            {
                openTcpLogFile();

                // --

                // ***
                // <?xml version="1.0"?>
                // <FAM>
                //     <TCD>
                //          ...
                //     </TCD>
                //    ↑
                // </FAM>
                // ***
                m_fsTcpLogFile.Seek(-(TcpLogTailLength + 2), SeekOrigin.Current);

                // -- 

                while (m_fTcpLogQueue.count > 0)
                {
                    m_swTcpLogFile.WriteLine(m_fTcpLogQueue.dequeue());
                    // --
                    m_tcpLogCount++;
                    if (m_tcpLogCount >= m_fTcdCore.fConfig.maxLogCountOfTcp)
                    {
                        break;
                    }
                }

                // -- 

                // ***
                // <?xml version="1.0"?>
                // <FAM>
                //     <TCD>
                //          ... + α
                //     </TCD>
                // </FAM>
                //      ↑
                // ***
                m_swTcpLogFile.WriteLine(TcpLogTail);

                // --

                m_swTcpLogFile.Flush();
                m_fsTcpLogFile.Flush();
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

        public void pushTcpLog(
            FXmlNode fXmlNode
            )
        {
            try
            {
                m_fTcpLogLock.wait();

                // --

                // ***
                // 2017.04.04 by spike.lee
                // TCP Log File Enable Option 적용
                // *** 
                if (m_fTcdCore.fConfig.enabledLogOfTcp)
                {
                    m_fTcpLogQueue.enqueue(fXmlNode.xmlToString(true));
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fTcpLogLock.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void closeTcpLogFile(
            )
        {
            try
            {
                if (m_swTcpLogFile != null)
                {
                    m_swTcpLogFile.Flush();
                    m_swTcpLogFile.Close();
                    m_swTcpLogFile.Dispose();
                    m_swTcpLogFile = null;
                }

                if (m_fsTcpLogFile != null)
                {
                    m_fsTcpLogFile.Close();
                    m_fsTcpLogFile.Dispose();
                    m_fsTcpLogFile = null;
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

        public void cutTcpLogFile(
            )
        {
            try
            {
                m_fThdSync.wait();

                // --

                closeTcpLogFile();
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

        private void initTcpLogFile(
            )
        {
            const string XmlDeclarationString = "<?xml version=\"1.0\"?>";
            const string TcpLogFirstTail = ">\r\n\t</TCD>\r\n</FAM>";
            const int TcpLogFirstTailLength = 13;

            // -- 

            FXmlDocument fXmlDoc = null;
            FXmlNode fXmlNodeFam = null;
            FXmlNode fXmlNodeTcdl = null;

            try
            {
                fXmlDoc = new FXmlDocument();
                fXmlDoc.preserveWhiteSpace = false;
                //fXmlDoc.appendChild(fXmlDoc.createXmlDeclaration("1.0", string.Empty, string.Empty));
                // --
                fXmlNodeFam = fXmlDoc.appendChild(FTcpDriverLogCommon.createXmlNodeFAM(fXmlDoc));
                fXmlNodeTcdl = fXmlNodeFam.appendChild(FTcpDriverLogCommon.createXmlNodeTCDL(fXmlDoc));
                fXmlNodeTcdl.set_attrVal(FXmlTagTCDL.A_Name, FXmlTagTCDL.D_Name, m_fTcdCore.fTcpDriver.name);
                fXmlNodeTcdl.set_attrVal(FXmlTagTCDL.A_Description, FXmlTagTCDL.D_Description, m_fTcdCore.fTcpDriver.description);
                fXmlNodeTcdl.set_attrVal(FXmlTagTCDL.A_FontBold, FXmlTagTCDL.D_FontBold, FBoolean.fromBool(m_fTcdCore.fTcpDriver.fontBold));
                fXmlNodeTcdl.set_attrVal(FXmlTagTCDL.A_FontColor, FXmlTagTCDL.D_FontColor, m_fTcdCore.fTcpDriver.fontColor.Name);
                fXmlNodeTcdl.set_attrVal(FXmlTagTCDL.A_EapName, FXmlTagTCDL.D_EapName, m_fTcdCore.fTcpDriver.eapName);
                // -- 
                fXmlNodeTcdl.set_attrVal(FXmlTagTCDL.A_UserTag1, FXmlTagTCDL.D_UserTag1, m_fTcdCore.fTcpDriver.userTag1);
                fXmlNodeTcdl.set_attrVal(FXmlTagTCDL.A_UserTag2, FXmlTagTCDL.D_UserTag2, m_fTcdCore.fTcpDriver.userTag2);
                fXmlNodeTcdl.set_attrVal(FXmlTagTCDL.A_UserTag3, FXmlTagTCDL.D_UserTag3, m_fTcdCore.fTcpDriver.userTag3);
                fXmlNodeTcdl.set_attrVal(FXmlTagTCDL.A_UserTag4, FXmlTagTCDL.D_UserTag4, m_fTcdCore.fTcpDriver.userTag4);
                fXmlNodeTcdl.set_attrVal(FXmlTagTCDL.A_UserTag5, FXmlTagTCDL.D_UserTag5, m_fTcdCore.fTcpDriver.userTag5);

                // --

                // ***
                // <?xml version="1.0"?>
                // <FAM>
                //     <TCD/>
                // </FAM>
                //      ↑
                // ***
                m_swTcpLogFile.WriteLine(XmlDeclarationString);
                m_swTcpLogFile.WriteLine(fXmlNodeFam.xmlToString(true));
                m_swTcpLogFile.Flush();

                // ***
                // <?xml version="1.0"?>
                // <FAM>
                //     <TCD/>
                //    ↑
                // </FAM>
                // ***
                m_fsTcpLogFile.Seek(-TcpLogFirstTailLength, SeekOrigin.Current);

                // ***
                // <?xml version="1.0"?>
                // <FAM>
                //     <TCD>
                //     </TCD>
                // </FAM>
                //      ↑
                // ***
                m_swTcpLogFile.WriteLine(TcpLogFirstTail);


                // --

                m_swTcpLogFile.Flush();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeTcdl != null)
                {
                    fXmlNodeTcdl.Dispose();
                    fXmlNodeTcdl = null;
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

        //------------------------------------------------------------------------------------------------------------------------

        private void openBinaryLogFile(
            )
        {
            string filename = string.Empty;

            try
            {
                if (!Directory.Exists(m_fTcdCore.fConfig.logDirectory))
                {
                    Directory.CreateDirectory(m_fTcdCore.fConfig.logDirectory);
                }

                // -- 

                if (
                    m_fsBinaryLogFile == null ||
                    m_swBinaryLogFile == null ||
                    m_fsBinaryLogFile.Length >= m_fTcdCore.fConfig.maxLogFileSizeOfBinary ||
                    m_binaryLogEapName != m_fTcdCore.fConfig.eapName ||
                    m_binaryLogCount >= m_fTcdCore.fConfig.maxLogCountOfBinary
                    )
                {
                    closeBinaryLogFile();

                    // --

                    m_binaryLogEapName = m_fTcdCore.fConfig.eapName;
                    filename = makeLogFileName(m_fTcdCore.fConfig.logDirectory, m_binaryLogEapName, BinaryLogFileExt);
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
                    if (m_binaryLogCount >= m_fTcdCore.fConfig.maxLogCountOfBinary)
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
            
            try
            {
                m_fBinaryLogLock.wait();

                // -- 

                log = new StringBuilder();

                // --

                if (fEventId == FEventId.TcpDeviceDataReceived)
                {
                    eventType = "DataReceived";
                }
                else if (fEventId == FEventId.TcpDeviceDataSent)
                {
                    eventType = "DataSent    ";
                }

                // --

                // ***
                // Header
                // ***
                log.AppendLine("[" + time + "] " + eventType + ", TcpDevice=<" + deviceName + ">, Protocol=<" + fProtocol + ">, Length=<" + data.Length.ToString() + ">");
                log.AppendLine("[" + time + "] ConnectMode=<" + fConnectMode + ">, LocalIP=<" + localIp + ">, LocalPort=<" + localPort + ">, RemoteIP=<" + remoteIp + ">, RemotePort=<" + remotePort + ">");

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

        private void openXmlLogFile(
            )
        {
            string filename = string.Empty;

            try
            {
                if (!Directory.Exists(m_fTcdCore.fConfig.logDirectory))
                {
                    Directory.CreateDirectory(m_fTcdCore.fConfig.logDirectory);
                }

                // -- 

                if (
                    m_fsXmlLogFile == null ||
                    m_swXmlLogFile == null ||
                    m_fsXmlLogFile.Length >= m_fTcdCore.fConfig.maxLogFileSizeOfXml ||
                    m_xmlLogEapName != m_fTcdCore.fConfig.eapName ||
                    m_xmlLogCount >= m_fTcdCore.fConfig.maxLogCountOfXml
                    )
                {
                    closeXmlLogFile();

                    // --

                    m_xmlLogEapName = m_fTcdCore.fConfig.eapName;
                    filename = makeLogFileName(m_fTcdCore.fConfig.logDirectory, m_xmlLogEapName, XmlLogFileExt);
                    // --
                    m_fsXmlLogFile = new FileStream(filename, FileMode.OpenOrCreate | FileMode.Append, FileAccess.Write, FileShare.Read);
                    m_swXmlLogFile = new StreamWriter(m_fsXmlLogFile);
                    m_xmlLogCount = 0;
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

        private void writeXmlLogFile(
            )
        {
            try
            {
                openXmlLogFile();

                // -- 

                while (m_fXmlLogQueue.count > 0)
                {
                    m_swXmlLogFile.Write(m_fXmlLogQueue.dequeue());
                    // --
                    m_xmlLogCount++;
                    if (m_xmlLogCount >= m_fTcdCore.fConfig.maxLogCountOfXml)
                    {
                        break;
                    }
                }

                // -- 

                m_swXmlLogFile.Flush();
                m_fsXmlLogFile.Flush();
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

        public void pushXmlLog(
            FEventId fEventId,
            string time,
            string deviceName,
            UInt16 sessionId,
            UInt32 tid,
            UInt32 length,
            FResultCode fResultCode,
            string resultMessage,
            string xml
            )
        {
            string eventType = string.Empty;
            StringBuilder log = null;
            
            try
            {
                m_fXmlLogLock.wait();

                // --

                log = new StringBuilder();

                // --

                if (fEventId == FEventId.TcpDeviceXmlReceived)
                {
                    eventType = "DataReceived";
                }
                else if (fEventId == FEventId.TcpDeviceXmlSent)
                {
                    eventType = "DataSent    ";
                }

                // --

                // ***
                // Header
                // ***
                log.AppendLine("[" + time + "] " + eventType + ", TcpDevice=<" + deviceName + ">, SessionId=<" + sessionId + ">, SystemBytes=<" + tid + ">, Length=<" + length + ">");
                log.AppendLine("[" + time + "] ResultCode=<" + fResultCode + ">, ResultMessage=<" + resultMessage + ">");

                // --

                // ***
                // Body
                // ***
                foreach (string s in xml.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                {
                    log.AppendLine("[" + time + "] " + s);
                }
                log.AppendLine("--");

                // --

                m_fXmlLogQueue.enqueue(log.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                log = null;
                m_fXmlLogLock.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void closeXmlLogFile(
            )
        {
            try
            {
                if (m_swXmlLogFile != null)
                {
                    m_swXmlLogFile.Flush();
                    m_swXmlLogFile.Close();
                    m_swXmlLogFile.Dispose();
                    m_swXmlLogFile = null;
                }

                if (m_fsXmlLogFile != null)
                {
                    m_fsXmlLogFile.Close();
                    m_fsXmlLogFile.Dispose();
                    m_fsXmlLogFile = null;
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

        public void cutXmlLogFile(
            )
        {
            try
            {
                m_fThdSync.wait();

                // --

                closeXmlLogFile();
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
                    m_fVfeiLogQueue.count == 0 &&
                    m_fTcpLogQueue.count == 0 &&
                    m_fBinaryLogQueue.count == 0 &&
                    m_fXmlLogQueue.count == 0
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
                if (m_fTcpLogQueue.count > 0)
                {
                    writeTcpLogFile();
                }                
                // --
                if (m_fVfeiLogQueue.count > 0)
                {
                    writeVfeiLogFile();
                }
                // --
                if (m_fXmlLogQueue.count > 0)
                {
                    writeXmlLogFile();
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