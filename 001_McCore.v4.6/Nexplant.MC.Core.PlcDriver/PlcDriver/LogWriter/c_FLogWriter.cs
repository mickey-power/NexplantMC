/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FLogWriter.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.15
--  Description     : FAMate Core FaPlcDriver Log Writer Class
--  History         : Created by Jeff.Kim at 2013.07.15
----------------------------------------------------------------------------------------------------------*/
using System;
using Nexplant.MC.Core.FaCommon;
using System.IO;
using System.Collections;
using System.Text;

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal class FLogWriter : IDisposable
    {
        //------------------------------------------------------------------------------------------------------------------------

        private const string BinaryLogFileExt = "bng";
        private const string VfeiLogFileExt = "vfe";
        private const string PlcLogFileExt = "psl";
        private const string PlcLogTail = "\t</PCD>\r\n</FAM>";
        private const int PlcLogTailLength = 15;

        //--
        private bool m_disposed = false;
        // -- 
        private FPcdCore m_fPcdCore = null;
        // --
        private FCodeLock m_fBinaryLogLock = null;
        private string m_binaryLogEapName = string.Empty;
        private FQueue<string> m_fBinaryLogQueue = null;
        private FileStream m_fsBinaryLogFile = null;
        private StreamWriter m_swBinaryLogFile = null;
        private long m_binaryLogCount = 0;
        // --       
        private FCodeLock m_fVfeiLogLock = null;
        private string m_vfeiLogEapName = string.Empty;
        private FQueue<string> m_fVfeiLogQueue = null;
        private FileStream m_fsVfeiLogFile = null;
        private StreamWriter m_swVfeiLogFile = null;
        private long m_vfeiLogCount = 0;
        // --
        private FCodeLock m_fPlcLogLock = null;
        private string m_plcLogEapName = string.Empty;
        private FQueue<string> m_fPlcLogQueue = null;
        private FileStream m_fsPlcLogFile = null;
        private StreamWriter m_swPlcLogFile = null;
        private long m_plcLogCount = 0;
        // --
        private FCodeLock m_fThdSync = null;    // Log Write Thread와 Log Cut Method Sync로 사용됨.
        private FThread m_fThdMain = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FLogWriter(
            FPcdCore fPcdCore
            )
        {
            m_fPcdCore = fPcdCore;
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
                m_binaryLogEapName = m_fPcdCore.fConfig.eapName;
                m_fBinaryLogQueue = new FQueue<string>();
                m_fBinaryLogLock = new FCodeLock();
                // --
                m_vfeiLogEapName = m_fPcdCore.fConfig.eapName;
                m_fVfeiLogQueue = new FQueue<string>();
                m_fVfeiLogLock = new FCodeLock();                      
                // --
                m_plcLogEapName = m_fPcdCore.fConfig.eapName;
                m_fPlcLogQueue = new FQueue<string>();
                m_fPlcLogLock = new FCodeLock();
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
                    while (m_fBinaryLogQueue.count > 0 ||
                        m_fVfeiLogQueue.count > 0 ||
                        m_fPlcLogQueue.count > 0
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

                closePlcLogFile();
                // --
                if (m_fPlcLogQueue != null)
                {
                    m_fPlcLogQueue.Dispose();
                    m_fPlcLogQueue = null;
                }
                // --
                if (m_fPlcLogLock != null)
                {
                    m_fPlcLogLock.Dispose();
                    m_fPlcLogLock = null;
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
                if (!Directory.Exists(m_fPcdCore.fConfig.logDirectory))
                {
                    Directory.CreateDirectory(m_fPcdCore.fConfig.logDirectory);
                }

                // -- 

                if (
                    m_fsBinaryLogFile == null ||
                    m_swBinaryLogFile == null ||
                    m_fsBinaryLogFile.Length >= m_fPcdCore.fConfig.maxLogFileSizeOfBinary ||
                    m_binaryLogEapName != m_fPcdCore.fConfig.eapName ||
                    m_binaryLogCount >= m_fPcdCore.fConfig.maxLogCountOfBinary
                    )
                {
                    closeBinaryLogFile();

                    // --

                    m_binaryLogEapName = m_fPcdCore.fConfig.eapName;
                    filename = makeLogFileName(m_fPcdCore.fConfig.logDirectory, m_binaryLogEapName, BinaryLogFileExt);
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
                    if (m_binaryLogCount >= m_fPcdCore.fConfig.maxLogCountOfBinary)
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

                if (fEventId == FEventId.PlcDeviceDataReceived)
                {
                    eventType = "DataReceived";
                }
                else if (fEventId == FEventId.PlcDeviceDataSent)
                {
                    eventType = "DataSent    ";
                }

                // --

                // ***
                // Header
                // ***
                log.AppendLine("[" + time + "] " + eventType + ", PlcDevice=<" + deviceName + ">, Protocol=<" + fProtocol + ">, Length=<" + data.Length.ToString() + ">");
                log.AppendLine("[" + time + "] LocalIP=<" + localIp + ">, LocalPort=<" + localPort + ">, RemoteIP=<" + remoteIp + ">, RemotePort=<" + remotePort + ">");

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

        private void openVfeiLogFile(
            )
        {
            string filename = string.Empty;

            try
            {
                if (!Directory.Exists(m_fPcdCore.fConfig.logDirectory))
                {
                    Directory.CreateDirectory(m_fPcdCore.fConfig.logDirectory);
                }

                // --

                if (
                    m_swVfeiLogFile == null ||
                    m_fsVfeiLogFile == null ||
                    m_fsVfeiLogFile.Length >= m_fPcdCore.fConfig.maxLogFileSizeOfVfei ||
                    m_vfeiLogEapName != m_fPcdCore.fConfig.eapName ||
                    m_vfeiLogCount >= m_fPcdCore.fConfig.maxLogCountOfVfei
                    )
                {
                    closeVfeiLogFile();

                    // --

                    m_vfeiLogEapName = m_fPcdCore.fConfig.eapName;
                    filename = makeLogFileName(m_fPcdCore.fConfig.logDirectory, m_vfeiLogEapName, VfeiLogFileExt);
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
                log.AppendLine("[" + time + "] " + eventType + ", PlcDevice=<" + deviceName + ">, SessionId=<" + sessionId + ">");
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

        private void openPlcLogFile(
            )
        {
            string filename = string.Empty;

            try
            {
                if (!Directory.Exists(m_fPcdCore.fConfig.logDirectory))
                {
                    Directory.CreateDirectory(m_fPcdCore.fConfig.logDirectory);
                }

                // --

                if (
                    m_swPlcLogFile == null ||
                    m_fsPlcLogFile == null ||
                    m_fsPlcLogFile.Length >= m_fPcdCore.fConfig.maxLogFileSizeOfPlc ||
                    m_plcLogCount >= m_fPcdCore.fConfig.maxLogCountOfPlc
                    )
                {
                    closePlcLogFile();

                    // --

                    m_plcLogEapName = m_fPcdCore.fConfig.eapName;
                    filename = makeLogFileName(m_fPcdCore.fConfig.logDirectory, m_plcLogEapName, PlcLogFileExt);
                    // --
                    m_fsPlcLogFile = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
                    m_swPlcLogFile = new StreamWriter(m_fsPlcLogFile);
                    m_plcLogCount = 0;

                    // --

                    initPlcLogFile();
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

        private void writePlcLogFile(
            )
        {
            try
            {
                openPlcLogFile();

                // --

                // ***
                // <?xml version="1.0"?>
                // <FAM>
                //     <PCD>
                //          ...
                //     </PCD>
                //    ↑
                // </FAM>
                // ***
                m_fsPlcLogFile.Seek(-(PlcLogTailLength + 2), SeekOrigin.Current);

                // -- 

                while (m_fPlcLogQueue.count > 0)
                {
                    m_swPlcLogFile.WriteLine(m_fPlcLogQueue.dequeue());
                    // --
                    m_plcLogCount++;
                    if (m_plcLogCount >= m_fPcdCore.fConfig.maxLogCountOfPlc)
                    {
                        break;
                    }
                }

                // -- 

                // ***
                // <?xml version="1.0"?>
                // <FAM>
                //     <PCD>
                //          ... + α
                //     </PCD>
                // </FAM>
                //      ↑
                // ***
                m_swPlcLogFile.WriteLine(PlcLogTail);

                // --

                m_swPlcLogFile.Flush();
                m_fsPlcLogFile.Flush();
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

        public void pushPlcLog(
            FXmlNode fXmlNode
            )
        {
            try
            {
                m_fPlcLogLock.wait();

                // --

                // ***
                // 2017.04.04 by spike.lee
                // PLC Log File Enable Option 적용
                // *** 
                if (m_fPcdCore.fConfig.enabledLogOfPlc)
                {
                    m_fPlcLogQueue.enqueue(fXmlNode.xmlToString(true));
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fPlcLogLock.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void closePlcLogFile(
            )
        {
            try
            {
                if (m_swPlcLogFile != null)
                {
                    m_swPlcLogFile.Flush();
                    m_swPlcLogFile.Close();
                    m_swPlcLogFile.Dispose();
                    m_swPlcLogFile = null;
                }

                if (m_fsPlcLogFile != null)
                {
                    m_fsPlcLogFile.Close();
                    m_fsPlcLogFile.Dispose();
                    m_fsPlcLogFile = null;
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

        public void cutPlcLogFile(
            )
        {
            try
            {
                m_fThdSync.wait();

                // --

                closePlcLogFile();
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

        private void initPlcLogFile(
            )
        {
            const string XmlDeclarationString = "<?xml version=\"1.0\"?>";
            const string PlcLogFirstTail = ">\r\n\t</PCD>\r\n</FAM>";
            const int PlcLogFirstTailLength = 13;

            // -- 

            FXmlDocument fXmlDoc = null;
            FXmlNode fXmlNodeFam = null;
            FXmlNode fXmlNodePcdl = null;

            try
            {
                fXmlDoc = new FXmlDocument();
                fXmlDoc.preserveWhiteSpace = false;
                //fXmlDoc.appendChild(fXmlDoc.createXmlDeclaration("1.0", string.Empty, string.Empty));
                // --
                fXmlNodeFam = fXmlDoc.appendChild(FPlcDriverLogCommon.createXmlNodeFAM(fXmlDoc));
                fXmlNodePcdl = fXmlNodeFam.appendChild(FPlcDriverLogCommon.createXmlNodePCDL(fXmlDoc));
                fXmlNodePcdl.set_attrVal(FXmlTagPCDL.A_Name, FXmlTagPCDL.D_Name, m_fPcdCore.fPlcDriver.name);
                fXmlNodePcdl.set_attrVal(FXmlTagPCDL.A_Description, FXmlTagPCDL.D_Description, m_fPcdCore.fPlcDriver.description);
                fXmlNodePcdl.set_attrVal(FXmlTagPCDL.A_FontBold, FXmlTagPCDL.D_FontBold, FBoolean.fromBool(m_fPcdCore.fPlcDriver.fontBold));
                fXmlNodePcdl.set_attrVal(FXmlTagPCDL.A_FontColor, FXmlTagPCDL.D_FontColor, m_fPcdCore.fPlcDriver.fontColor.Name);
                fXmlNodePcdl.set_attrVal(FXmlTagPCDL.A_EapName, FXmlTagPCDL.D_EapName, m_fPcdCore.fPlcDriver.eapName);
                // -- 
                fXmlNodePcdl.set_attrVal(FXmlTagPCDL.A_UserTag1, FXmlTagPCDL.D_UserTag1, m_fPcdCore.fPlcDriver.userTag1);
                fXmlNodePcdl.set_attrVal(FXmlTagPCDL.A_UserTag2, FXmlTagPCDL.D_UserTag2, m_fPcdCore.fPlcDriver.userTag2);
                fXmlNodePcdl.set_attrVal(FXmlTagPCDL.A_UserTag3, FXmlTagPCDL.D_UserTag3, m_fPcdCore.fPlcDriver.userTag3);
                fXmlNodePcdl.set_attrVal(FXmlTagPCDL.A_UserTag4, FXmlTagPCDL.D_UserTag4, m_fPcdCore.fPlcDriver.userTag4);
                fXmlNodePcdl.set_attrVal(FXmlTagPCDL.A_UserTag5, FXmlTagPCDL.D_UserTag5, m_fPcdCore.fPlcDriver.userTag5);

                // --

                // ***
                // <?xml version="1.0"?>
                // <FAM>
                //     <PCD/>
                // </FAM>
                //      ↑
                // ***
                m_swPlcLogFile.WriteLine(XmlDeclarationString);
                m_swPlcLogFile.WriteLine(fXmlNodeFam.xmlToString(true));
                m_swPlcLogFile.Flush();

                // ***
                // <?xml version="1.0"?>
                // <FAM>
                //     <PCD/>
                //    ↑
                // </FAM>
                // ***
                m_fsPlcLogFile.Seek(-PlcLogFirstTailLength, SeekOrigin.Current);

                // ***
                // <?xml version="1.0"?>
                // <FAM>
                //     <PCD>
                //     </PCD>
                // </FAM>
                //      ↑
                // ***
                m_swPlcLogFile.WriteLine(PlcLogFirstTail);


                // --

                m_swPlcLogFile.Flush();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodePcdl != null)
                {
                    fXmlNodePcdl.Dispose();
                    fXmlNodePcdl = null;
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

                if (m_fBinaryLogQueue.count == 0 && 
                    m_fVfeiLogQueue.count == 0 &&
                    m_fPlcLogQueue.count == 0
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
                if (m_fVfeiLogQueue.count > 0)
                {
                    writeVfeiLogFile();
                }
                // --
                if (m_fPlcLogQueue.count > 0)
                {
                    writePlcLogFile();
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