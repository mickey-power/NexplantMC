/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FServiceLogWriter.cs
--  Creator         : spike.lee
--  Create Date     : 2011.09.21
--  Description     : FAMate Core FaCommon Service Log Writer Class
--  History         : Created by spike.lee at 2011.09.21
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Nexplant.MC.Core.FaCommon
{
    public class FServiceLogWriter : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const int LogFileDeletePeriod = 10 * 60 * 1000; // 10 Minute

        private bool m_disposed = false;
        // --
        private string m_logFilePath = Application.StartupPath + "\\Log";
        private string m_logFileSuffix = "ServiceLog";
        private string m_logFileExt = "log";        
        private bool m_dateTimeUsed = false;
        private bool m_endStringUsed = false;
        private string m_endString = "-";
        private int m_maxLogFileSize = 1024 * 1024 * 5;     // 5M
        private static bool m_logFileAutoDeleteEnabled = false;
        private int m_logFileKeepingPeriod = 30;            // 30 Day
        // --
        private string m_filePath = string.Empty;        
        private string m_fileSuffix = string.Empty;
        private string m_fileExt = string.Empty;
        private string m_openedFileName = string.Empty;
        
        // --
        private FQueue<string> m_fLogQueue = null;
        private FileStream m_fsLogFile = null;
        private StreamWriter m_swLogFile = null;
        private FThread m_fThdMain = null;
        private FStaticTimer m_fTmrLogFileDelete = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FServiceLogWriter(
            )
        {
            init();            
        }        

        //------------------------------------------------------------------------------------------------------------------------

        public FServiceLogWriter(
            string logFilePath,
            string logFileSuffix,
            string logFileExt,
            bool dateTimeUsed,
            bool endStringUsed
            )
        {
            m_logFilePath = logFilePath;
            m_logFileSuffix = logFileSuffix;
            m_logFileExt = logFileExt;
            m_dateTimeUsed = dateTimeUsed;
            m_endStringUsed = endStringUsed;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FServiceLogWriter(
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

        public string logFilePath
        {
            get
            {
                try
                {
                    return m_logFilePath;
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
                    m_logFilePath = value;
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

        public string logFileSuffix
        {
            get
            {
                try
                {
                    return m_logFileSuffix;
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
                    m_logFileSuffix = value;
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

        public string logFileExt
        {
            get
            {
                try
                {
                    return m_logFileExt;
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
                    m_logFileExt = value;
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

        public bool dateTimeUsed
        {
            get
            {
                try
                {
                    return m_dateTimeUsed;
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
        }

        //------------------------------------------------------------------------------------------------------------------------        

        public bool endStringUsed
        {
            get
            {
                try
                {
                    return m_endStringUsed;
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
        }

        //------------------------------------------------------------------------------------------------------------------------        

        public string endString
        {
            get
            {
                try
                {
                    return m_endString;
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
                    endString = value;
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

        public int maxLogFileSize
        {
            get
            {
                try
                {
                    return m_maxLogFileSize;
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
                    m_maxLogFileSize = value;
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

        public bool logFileAutoDeleteEnabled
        {
            get
            {
                try
                {
                    return m_logFileAutoDeleteEnabled;
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
                    m_logFileAutoDeleteEnabled = value;
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

        public int logFileKeepingPeriod
        {
            get
            {
                try
                {
                    return m_logFileKeepingPeriod;
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
                    m_logFileKeepingPeriod = value;
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
                m_fTmrLogFileDelete = new FStaticTimer();
                m_fTmrLogFileDelete.start(LogFileDeletePeriod);
                // --
                m_fThdMain = new FThread("ServiceLogWriterThread");
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
                    // ***
                    // 모든 Log가 기록될 때가지 대기
                    // ***
                    while (m_fLogQueue.count > 0)
                    {
                        System.Threading.Thread.Sleep(10);
                    }                    

                    // --

                    m_fThdMain.stop();
                    m_fThdMain.Dispose();
                    m_fThdMain.ThreadJobCalled -= new FThreadJobCalledEventHandler(m_fThdMain_ThreadJobCalled);
                    m_fThdMain = null;
                }

                if (m_fTmrLogFileDelete != null)
                {
                    m_fTmrLogFileDelete.Dispose();
                    m_fTmrLogFileDelete = null;
                }

                if (m_fLogQueue != null)
                {
                    m_fLogQueue.Dispose();
                    m_fLogQueue = null;
                }

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
            string[] files = null;
            string searchPattern = string.Empty;
            string fileName = string.Empty;
            FileInfo fileInfo = null;

            try
            {
                if (!Directory.Exists(m_logFilePath))
                {
                    Directory.CreateDirectory(m_logFilePath);
                }

                // --

                if (m_swLogFile == null)
                {
                    searchPattern = "*_" + m_logFileSuffix + "." + m_logFileExt;
                    files = Directory.GetFiles(m_logFilePath, searchPattern);

                    // --

                    if (files.Length == 0)
                    {
                        m_openedFileName = string.Empty;
                    }
                    else
                    {
                        m_openedFileName = files[files.Length - 1]; // Last Log File
                        // --
                        fileInfo = new FileInfo(m_openedFileName);
                        if (fileInfo.Length >= m_maxLogFileSize)
                        {
                            m_openedFileName = string.Empty;
                        }                        
                    }

                    // --

                    m_filePath = m_logFilePath;
                    m_fileSuffix = m_logFileSuffix;
                    m_fileExt = m_logFileExt;
                }
                else if (m_logFilePath != m_filePath || m_logFileSuffix != m_fileSuffix || m_logFileExt != m_fileExt)
                {
                    closeLogFile();

                    // --

                    m_openedFileName = string.Empty;

                    // --
                    
                    m_filePath = m_logFilePath;
                    m_fileSuffix = m_logFileSuffix;
                    m_fileExt = m_logFileExt;
                }
                else
                {
                    fileInfo = new FileInfo(m_openedFileName);
                    if (fileInfo.Length >= m_maxLogFileSize)
                    {
                        closeLogFile();
                        m_openedFileName = string.Empty;
                    }
                }
                
                // --

                if (m_swLogFile == null)
                {
                    if (m_openedFileName == string.Empty)
                    {
                        m_openedFileName = m_logFilePath + "\\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + m_logFileSuffix + "." + m_logFileExt;                    
                    }
                    m_fsLogFile = new FileStream(m_openedFileName, FileMode.OpenOrCreate | FileMode.Append, FileAccess.Write, FileShare.Read);
                    m_swLogFile = new StreamWriter(m_fsLogFile, Encoding.Default);
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
            try
            {
                openLogFile();

                // --

                while (m_fLogQueue.count > 0)
                {
                    m_swLogFile.Write(m_fLogQueue.dequeue());
                }

                // --
    
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

        private void deleteLogFile(
            )
        {
            string fileName = string.Empty;

            try
            {
                fileName = DateTime.Now.AddDays(m_logFileKeepingPeriod * -1).ToString("yyyyMMdd");
                foreach (string s in Directory.GetFiles(m_logFilePath, "*." + m_logFileExt))
                {
                    if (fileName.CompareTo(Path.GetFileName(s)) < 0)
                    {
                        break;
                    }
                    File.Delete(s);
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

        public void write(
            string log
            )
        {
            StringBuilder sb = null;
            string dateTime = string.Empty;

            try
            {
                sb = new StringBuilder();

                // --

                if (m_dateTimeUsed)
                {
                    dateTime = "[" + FDataConvert.defaultNowDateTimeToString() + "] ";
                    foreach (string s in log.Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries))
                    {
                        sb.AppendLine(dateTime + s);
                    }
                }
                else
                {
                    sb.AppendLine(log);
                }

                if (m_endStringUsed)
                {
                    sb.AppendLine(m_endString);
                }

                // --

                m_fLogQueue.enqueue(sb.ToString());
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

        public void write(
            FServiceLogCategory fCategory,
            string action,
            string typeNamespace,
            string typeName,
            string functionName,
            string log
            )
        {
            StringBuilder sb = null;

            try
            {
                sb = new StringBuilder();

                if (fCategory == FServiceLogCategory.Information)
                {
                    sb.Append("Category=<I>, ");
                }
                else if (fCategory == FServiceLogCategory.Warning)
                {
                    sb.Append("Category=<W>, ");
                }
                else
                {
                    sb.Append("Category=<E>, ");
                }

                // --

                sb.Append("Action=<" + action + ">, ");
                sb.Append("Namespace=<" + typeNamespace + ">, ");
                sb.Append("TypeName=<" + typeName + ">, ");
                sb.Append("Function=<" + functionName + ">");

                // --

                if (log != string.Empty)
                {
                    sb.Append(Environment.NewLine);
                    sb.Append("/* Addition Information */");
                    // --
                    sb.Append(Environment.NewLine);
                    sb.Append(log);
                }

                // --

                write(sb.ToString());
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

        public void write(
            FServiceLogCategory fCategory,
            string action,
            Type type,
            string functionName,
            string log
            )
        {
            try
            {
                write(fCategory, action, type.Namespace, type.Name, functionName, log);
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

        public void write(
            FServiceLogData fLogData
            )
        {
            DateTime endTime;

            try
            {
                endTime = DateTime.Now;

                // --

                fLogData.logData.Append("EndTime=<" + FDataConvert.defaultNowDateTimeToString() + ">, ");
                fLogData.logData.Append("ProcTime=<" + endTime.Subtract(fLogData.startTime).TotalMilliseconds.ToString("F0") + ">");
                // --
                write(fLogData.logData.ToString());
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
            try
            {
                if (m_fLogQueue.count == 0)
                {
                    e.sleepThread(1);
                    return;                    
                }

                // --

                writeLog();

                // --

                // ***
                // Old Log File Delete
                // ***
                if (m_logFileAutoDeleteEnabled && m_fTmrLogFileDelete.elasped(false))
                {
                    m_fTmrLogFileDelete.restart();
                    deleteLogFile();
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

    }   // Class end
}   // Namespace end
