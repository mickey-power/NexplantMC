/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FLogWriter.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.15
--  Description     : FAMate Core FaOpcDriver Log Writer Class
--  History         : Created by Jeff.Kim at 2013.07.15
----------------------------------------------------------------------------------------------------------*/
using System;
using Nexplant.MC.Core.FaCommon;
using System.IO;
using System.Collections;
using System.Text;

namespace Nexplant.MC.Core.FaOpcDriver
{
    internal class FLogWriter : IDisposable
    {
        //------------------------------------------------------------------------------------------------------------------------
        
        private const string VfeiLogFileExt = "vfe";
        private const string OpcLogFileExt = "osl";
        private const string OpcLogTail = "\t</OCD>\r\n</FAM>";
        private const int OpcLogTailLength = 15;

        //--
        private bool m_disposed = false;
        // -- 
        private FOcdCore m_fOcdCore = null;        
        // --       
        private FCodeLock m_fVfeiLogLock = null;
        private string m_vfeiLogEapName = string.Empty;
        private FQueue<string> m_fVfeiLogQueue = null;
        private FileStream m_fsVfeiLogFile = null;
        private StreamWriter m_swVfeiLogFile = null;
        private long m_vfeiLogCount = 0;
        // --
        private FCodeLock m_fOpcLogLock = null;
        private string m_opcLogEapName = string.Empty;
        private FQueue<string> m_fOpcLogQueue = null;
        private FileStream m_fsOpcLogFile = null;
        private StreamWriter m_swOpcLogFile = null;
        private long m_opcLogCount = 0;
        // --
        private FCodeLock m_fThdSync = null;    // Log Write Thread와 Log Cut Method Sync로 사용됨.
        private FThread m_fThdMain = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FLogWriter(
            FOcdCore fOcdCore
            )
        {
            m_fOcdCore = fOcdCore;
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
                m_vfeiLogEapName = m_fOcdCore.fConfig.eapName;
                m_fVfeiLogQueue = new FQueue<string>();
                m_fVfeiLogLock = new FCodeLock();                      
                // --
                m_opcLogEapName = m_fOcdCore.fConfig.eapName;
                m_fOpcLogQueue = new FQueue<string>();
                m_fOpcLogLock = new FCodeLock();
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
                        m_fOpcLogQueue.count > 0
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

                closeOpcLogFile();
                // --
                if (m_fOpcLogQueue != null)
                {
                    m_fOpcLogQueue.Dispose();
                    m_fOpcLogQueue = null;
                }
                // --
                if (m_fOpcLogLock != null)
                {
                    m_fOpcLogLock.Dispose();
                    m_fOpcLogLock = null;
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
                if (!Directory.Exists(m_fOcdCore.fConfig.logDirectory))
                {
                    Directory.CreateDirectory(m_fOcdCore.fConfig.logDirectory);
                }

                // --

                if (
                    m_swVfeiLogFile == null ||
                    m_fsVfeiLogFile == null ||
                    m_fsVfeiLogFile.Length >= m_fOcdCore.fConfig.maxLogFileSizeOfVfei ||
                    m_vfeiLogEapName != m_fOcdCore.fConfig.eapName ||
                    m_vfeiLogCount >= m_fOcdCore.fConfig.maxLogCountOfVfei
                    )
                {
                    closeVfeiLogFile();

                    // --

                    m_vfeiLogEapName = m_fOcdCore.fConfig.eapName;
                    filename = makeLogFileName(m_fOcdCore.fConfig.logDirectory, m_vfeiLogEapName, VfeiLogFileExt);
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
                log.AppendLine("[" + time + "] " + eventType + ", OpcDevice=<" + deviceName + ">, SessionId=<" + sessionId + ">");
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

        private void openOpcLogFile(
            )
        {
            string filename = string.Empty;

            try
            {
                if (!Directory.Exists(m_fOcdCore.fConfig.logDirectory))
                {
                    Directory.CreateDirectory(m_fOcdCore.fConfig.logDirectory);
                }

                // --

                if (
                    m_swOpcLogFile == null ||
                    m_fsOpcLogFile == null ||
                    m_fsOpcLogFile.Length >= m_fOcdCore.fConfig.maxLogFileSizeOfOpc ||
                    m_opcLogCount >= m_fOcdCore.fConfig.maxLogCountOfOpc
                    )
                {
                    closeOpcLogFile();

                    // --

                    m_opcLogEapName = m_fOcdCore.fConfig.eapName;
                    filename = makeLogFileName(m_fOcdCore.fConfig.logDirectory, m_opcLogEapName, OpcLogFileExt);
                    // --
                    m_fsOpcLogFile = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
                    m_swOpcLogFile = new StreamWriter(m_fsOpcLogFile);
                    m_opcLogCount = 0;

                    // --

                    initOpcLogFile();
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

        private void writeOpcLogFile(
            )
        {
            try
            {
                openOpcLogFile();

                // --

                // ***
                // <?xml version="1.0"?>
                // <FAM>
                //     <OCD>
                //          ...
                //     </OCD>
                //    ↑
                // </FAM>
                // ***
                m_fsOpcLogFile.Seek(-(OpcLogTailLength + 2), SeekOrigin.Current);

                // -- 

                while (m_fOpcLogQueue.count > 0)
                {
                    m_swOpcLogFile.WriteLine(m_fOpcLogQueue.dequeue());
                    // --
                    m_opcLogCount++;
                    if (m_opcLogCount >= m_fOcdCore.fConfig.maxLogCountOfOpc)
                    {
                        break;
                    }
                }

                // -- 

                // ***
                // <?xml version="1.0"?>
                // <FAM>
                //     <OCD>
                //          ... + α
                //     </OCD>
                // </FAM>
                //      ↑
                // ***
                m_swOpcLogFile.WriteLine(OpcLogTail);

                // --

                m_swOpcLogFile.Flush();
                m_fsOpcLogFile.Flush();
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

        public void pushOpcLog(
            FXmlNode fXmlNode
            )
        {
            try
            {
                m_fOpcLogLock.wait();

                // --

                // ***
                // 2017.04.04 by spike.lee
                // OPC Log File Enable Option 적용
                // *** 
                if (m_fOcdCore.fConfig.enabledLogOfOpc)
                {
                    m_fOpcLogQueue.enqueue(fXmlNode.xmlToString(true));
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fOpcLogLock.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void closeOpcLogFile(
            )
        {
            try
            {
                if (m_swOpcLogFile != null)
                {
                    m_swOpcLogFile.Flush();
                    m_swOpcLogFile.Close();
                    m_swOpcLogFile.Dispose();
                    m_swOpcLogFile = null;
                }

                if (m_fsOpcLogFile != null)
                {
                    m_fsOpcLogFile.Close();
                    m_fsOpcLogFile.Dispose();
                    m_fsOpcLogFile = null;
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

        public void cutOpcLogFile(
            )
        {
            try
            {
                m_fThdSync.wait();

                // --

                closeOpcLogFile();
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

        private void initOpcLogFile(
            )
        {
            const string XmlDeclarationString = "<?xml version=\"1.0\"?>";
            const string OpcLogFirstTail = ">\r\n\t</OCD>\r\n</FAM>";
            const int OpcLogFirstTailLength = 13;

            // -- 

            FXmlDocument fXmlDoc = null;
            FXmlNode fXmlNodeFam = null;
            FXmlNode fXmlNodeOcdl = null;

            try
            {
                fXmlDoc = new FXmlDocument();
                fXmlDoc.preserveWhiteSpace = false;
                //fXmlDoc.appendChild(fXmlDoc.createXmlDeclaration("1.0", string.Empty, string.Empty));
                // --
                fXmlNodeFam = fXmlDoc.appendChild(FOpcDriverLogCommon.createXmlNodeFAM(fXmlDoc));
                fXmlNodeOcdl = fXmlNodeFam.appendChild(FOpcDriverLogCommon.createXmlNodeOCDL(fXmlDoc));
                fXmlNodeOcdl.set_attrVal(FXmlTagOCDL.A_Name, FXmlTagOCDL.D_Name, m_fOcdCore.fOpcDriver.name);
                fXmlNodeOcdl.set_attrVal(FXmlTagOCDL.A_Description, FXmlTagOCDL.D_Description, m_fOcdCore.fOpcDriver.description);
                fXmlNodeOcdl.set_attrVal(FXmlTagOCDL.A_FontBold, FXmlTagOCDL.D_FontBold, FBoolean.fromBool(m_fOcdCore.fOpcDriver.fontBold));
                fXmlNodeOcdl.set_attrVal(FXmlTagOCDL.A_FontColor, FXmlTagOCDL.D_FontColor, m_fOcdCore.fOpcDriver.fontColor.Name);
                fXmlNodeOcdl.set_attrVal(FXmlTagOCDL.A_EapName, FXmlTagOCDL.D_EapName, m_fOcdCore.fOpcDriver.eapName);
                // -- 
                fXmlNodeOcdl.set_attrVal(FXmlTagOCDL.A_UserTag1, FXmlTagOCDL.D_UserTag1, m_fOcdCore.fOpcDriver.userTag1);
                fXmlNodeOcdl.set_attrVal(FXmlTagOCDL.A_UserTag2, FXmlTagOCDL.D_UserTag2, m_fOcdCore.fOpcDriver.userTag2);
                fXmlNodeOcdl.set_attrVal(FXmlTagOCDL.A_UserTag3, FXmlTagOCDL.D_UserTag3, m_fOcdCore.fOpcDriver.userTag3);
                fXmlNodeOcdl.set_attrVal(FXmlTagOCDL.A_UserTag4, FXmlTagOCDL.D_UserTag4, m_fOcdCore.fOpcDriver.userTag4);
                fXmlNodeOcdl.set_attrVal(FXmlTagOCDL.A_UserTag5, FXmlTagOCDL.D_UserTag5, m_fOcdCore.fOpcDriver.userTag5);

                // --

                // ***
                // <?xml version="1.0"?>
                // <FAM>
                //     <OCD/>
                // </FAM>
                //      ↑
                // ***
                m_swOpcLogFile.WriteLine(XmlDeclarationString);
                m_swOpcLogFile.WriteLine(fXmlNodeFam.xmlToString(true));
                m_swOpcLogFile.Flush();

                // ***
                // <?xml version="1.0"?>
                // <FAM>
                //     <OCD/>
                //    ↑
                // </FAM>
                // ***
                m_fsOpcLogFile.Seek(-OpcLogFirstTailLength, SeekOrigin.Current);

                // ***
                // <?xml version="1.0"?>
                // <FAM>
                //     <OCD>
                //     </OCD>
                // </FAM>
                //      ↑
                // ***
                m_swOpcLogFile.WriteLine(OpcLogFirstTail);


                // --

                m_swOpcLogFile.Flush();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeOcdl != null)
                {
                    fXmlNodeOcdl.Dispose();
                    fXmlNodeOcdl = null;
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
                    m_fVfeiLogQueue.count == 0 &&
                    m_fOpcLogQueue.count == 0
                    )
                {
                    e.sleepThread(1);
                    return;
                }                                               

                // --
                
                if (m_fVfeiLogQueue.count > 0)
                {
                    writeVfeiLogFile();
                }
                // --
                if (m_fOpcLogQueue.count > 0)
                {
                    writeOpcLogFile();
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