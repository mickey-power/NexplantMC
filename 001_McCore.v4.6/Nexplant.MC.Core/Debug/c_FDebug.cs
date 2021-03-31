/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FDebug.cs
--  Creator         : spike.lee
--  Create Date     : 2010.11.25
--  Description     : FAMate Core FaCommon Debug Class
--  History         : Created by spike.lee at 2010.11.25
                    : Modified by spike.lee at 2012.12.03
                        - enabledAutoDelete Property 추가
                          (Auto Delete 기능 사용 여부 처리)
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Nexplant.MC.Core.FaCommon
{
    public static class FDebug
    {

        //------------------------------------------------------------------------------------------------------------------------

        private static FCodeLock m_fCodeLock = new FCodeLock();
        private static string m_logFilePath = string.Empty;
        private static string m_logFileSuffix = string.Empty;
        private static int m_logFileKeepingPeriod = 30;     // 30 Day
        private static bool m_logFileAutoDeleteEnabled = false;
        private static int m_maxLogFileSize = 1024 * 1024 * 20;     // 20M

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        static FDebug(
            )
        {
             
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------        

        #region Properties

        public static string logFilePath
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

        public static string logFileSuffix
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

        public static bool logFileAutoDeleteEnabled
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

        public static int logFileKeepingPeriod
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

        //------------------------------------------------------------------------------------------------------------------------

        public static int maxLogFileSize
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


        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods        

        public static void throwFException(
            string message
            )
        {
            throw new FException(message);            
        }

        //------------------------------------------------------------------------------------------------------------------------
       
        public static void throwException(
            Exception innerException
            )
        {
            writeLog(innerException);
            // --
            if (innerException.InnerException != null)
            {
                throw innerException;
            }
            else
            {
                throw new Exception(innerException.Message, innerException);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void writeLog(
            Exception exception
            )
        {
            FDebugLogArgs args = null;

            try
            {
                if (exception.InnerException != null)
                {
                    return;
                }

                // --                

                if (exception.GetBaseException() is FException)
                {
                    args = new FDebugLogArgs(
                        FDebugLogCategory.FException, 
                        "FExceptionTrace", 
                        "Miracom.FAMate.Core.FaCommon",
                        "FDebug",
                        "writeLog"
                        );
                }                
                else
                {
                    args = new FDebugLogArgs(
                        FDebugLogCategory.Exception,
                        "ExceptionTrace",
                        "Miracom.FAMate.Core.FaCommon",
                        "FDebug",
                        "writeLog"
                        );
                }
                args.additionInfo = exception.ToString();
                writeLog(args);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            finally
            {
                args = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void writeLog(
            FDebugLogArgs args
            )
        {
            const string HeaderFormat = "[{0}] Category=<{1}>, ";            
            const string ContentsFormat = "Action=<{0}>, Namespace=<{1}>, TypeName=<{2}>, Function=<{3}>";

            string filePath = string.Empty;
            string fileSuffix = string.Empty;            
            int fileKeepingPeriod = 0;
            bool autoDeleteEnabled = false;
            string header = string.Empty;
            StringBuilder log = null;
            DateTime dt;
            string fileName = string.Empty;
            string[] files = null;
            StreamWriter sw = null;
            FileInfo fileInfo = null;
            FileStream fs = null;

            try
            {
                m_fCodeLock.wait();

                // --

                if (m_logFilePath == string.Empty)
                {
                    m_logFilePath = Application.StartupPath + "\\Log";
                }
                filePath = m_logFilePath;
                fileSuffix = m_logFileSuffix;
                fileKeepingPeriod = m_logFileKeepingPeriod;
                autoDeleteEnabled = m_logFileAutoDeleteEnabled;

                // --

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                // --

                header = string.Format(
                    HeaderFormat, 
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), 
                    getDebugLogCategoryFlag(args.fCategory)
                    );
                // --
                log = new StringBuilder();
                log.Append(header);
                log.Append(
                    string.Format(ContentsFormat, args.action, args.typeNamespace, args.typeName, args.functionName)
                    );
                
                // --

                // ***
                // Addition Information write
                // ***
                if (args.additionInfo != string.Empty)
                {
                    // ***
                    // 1 Depth add
                    // ***
                    header += " ";

                    log.Append(Environment.NewLine);
                    log.Append(header);
                    log.Append("/* Addition Information */");                   

                    foreach (string s in args.additionInfo.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                    {
                        log.Append(Environment.NewLine);
                        log.Append(header);                        
                        log.Append(s);
                    }
                }
                // --
                log.Append(Environment.NewLine);
                log.Append("-");

                // --

                // ***
                // Log write
                //  * Log File Format                
                //    (오늘날짜의 Log가 존재할 경우 사용하고 그렇지 않을 경우 새롭게 생성한다.
                //    - yyyyMMddHHmmssfff_fileSubffix.dlg
                // ***
                dt = DateTime.Now;
                fileName = dt.ToString("yyyyMMdd") + "*" + (fileSuffix == string.Empty ? string.Empty : "_" + fileSuffix) + ".dlg";
                files = Directory.GetFiles(filePath, fileName);
                if (files.Length > 0)
                {
                    fileName = files[files.Length - 1];
                    fileInfo = new FileInfo(fileName);
                    if (fileInfo.Length > m_maxLogFileSize)
                    {
                        fileName = filePath + "\\" + dt.ToString("yyyyMMddHHmmssfff") + (fileSuffix == string.Empty ? string.Empty : "_" + fileSuffix) + ".dlg";                        
                    }
                }
                else
                {
                    fileName = filePath + "\\" + dt.ToString("yyyyMMddHHmmssfff") + (fileSuffix == string.Empty ? string.Empty : "_" + fileSuffix) + ".dlg";
                }
                // --                
                sw = new StreamWriter(fileName, true, Encoding.Default);
                sw.WriteLine(log.ToString());
                sw.Flush();
                sw.Close();
                sw = null;

                // --

                // ***
                // Old Log File delete
                // ***
                if (autoDeleteEnabled)
                {
                    fileName = dt.AddDays(fileKeepingPeriod * -1).ToString("yyyyMMdd");
                    foreach (string s in Directory.GetFiles(filePath, "*.dlg"))
                    {
                        if (fileName.CompareTo(Path.GetFileName(s)) < 0)
                        {
                            break;
                        }
                        File.Delete(s);
                    }
                }                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            finally
            {
                if (sw != null)
                {
                    sw.Flush();
                    sw.Close();
                    sw = null;
                }
                log = null;
                m_fCodeLock.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private static string getDebugLogCategoryFlag(
            FDebugLogCategory fCategory
            )
        {
            try
            {
                if (fCategory == FDebugLogCategory.FException)
                {
                    return "F";
                }
                else if (fCategory == FDebugLogCategory.Exception)
                {
                    return "E";
                }               
                else
                {
                    return "I";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            finally
            {

            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static long start(
            )
        {
            try
            {
                return DateTime.Now.Ticks;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.ToString());
            }
            finally
            {

            }
            return 0;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void end(
            string className,
            string methodName,
            string description,
            long start
            )
        {
            long end = 0;
            string output = string.Empty;
            DateTime now = DateTime.Now;
            try
            {
                end = DateTime.Now.Ticks;
                output = 
                    string.Format("'{0}.{1};{2};{3};{4};{5}", 
                    now.ToString("yyyy-MM-dd hh:mm:ss.mmm"), 
                    now.Millisecond, 
                    className, 
                    methodName, 
                    description,
                    (double)(end - start) / 10000000.0F
                    );
                System.Diagnostics.Debug.WriteLine(output);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.ToString());
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void end(
            string className,
            string methodName,
            long start
            )
        {
            long end = 0;
            string output = string.Empty;
            DateTime now = DateTime.Now;
            try
            {
                end = DateTime.Now.Ticks;
                output =
                    string.Format("'{0}.{1};{2};{3};;{4}",
                    now.ToString("yyyy-MM-dd hh:mm:ss.mmm"), 
                    now.Millisecond,
                    className,
                    methodName,                        
                    (double)(end - start) / 10000000.0F
                    );
                System.Diagnostics.Debug.WriteLine(output);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.ToString());
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void writeTrace(
            string message,
            params object[] add
            )
        {
            StringBuilder sb = null;
            try
            {
                if (add.Length == 0)
                {
                    System.Diagnostics.Debug.WriteLine("[{0}] Message=<{1}>\n--", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), message);
                }
                else
                {
                    sb = new StringBuilder();
                    sb.AppendLine("[{0}]\n  Message=<{1}>");
                    for (int i = 0; i < add.Length; i++)
                    {
                        sb.AppendFormat("  Add #{0:d02}=<{1}>\n", i + 1, add[i]);
                    }
                    sb.Append("--");
                    System.Diagnostics.Debug.WriteLine(sb.ToString(), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), message);                    
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.ToString());
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
