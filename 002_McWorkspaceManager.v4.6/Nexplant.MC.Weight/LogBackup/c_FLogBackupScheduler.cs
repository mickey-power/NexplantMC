/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FLogBackupScheduler.cs
--  Creator         : mjkim
--  Create Date     : 2019.09.10
--  Description     : Nexplant MC Counter Log Backup Scheduler Class 
--  History         : Created by mjkim at 2019.09.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaSecs1ToHsms;

namespace Nexplant.MC.Counter
{
    internal class FLogBackupScheduler : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // -- 
        private FCntCore m_fCntCore = null;
        private FThread m_fThdSch = null;
        private FSecs1ToHsmsConverterLogFileType m_fLogType = FSecs1ToHsmsConverterLogFileType.Application;
        private FStaticTimer m_fTmrSch = null;
        private FStaticTimer m_fTmrSubSch = null;
        private bool m_logBackupCompleted = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FLogBackupScheduler(
            FCntCore fCntCore
            )
        {
            m_fCntCore = fCntCore;
            // -- 
            init();
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        ~FLogBackupScheduler(
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
                    // --
                    m_fCntCore = null;
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
                // ***
                // Log Backup Schdulder Thread Create
                // ***
                m_fThdSch = new FThread("LogBackupSchdulderThread");
                m_fThdSch.ThreadJobCalled += new FThreadJobCalledEventHandler(m_fThdSch_ThreadJobCalled);
                m_fThdSch.start();
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
                if (m_fThdSch != null)
                {
                    m_fThdSch.stop();
                    m_fThdSch.Dispose();
                    m_fThdSch.ThreadJobCalled -= new FThreadJobCalledEventHandler(m_fThdSch_ThreadJobCalled);
                    m_fThdSch = null;
                }

                // --

                if (m_fTmrSch != null)
                {
                    m_fTmrSch.Dispose();
                    m_fTmrSch = null;
                }

                // --

                if (m_fTmrSubSch != null)
                {
                    m_fTmrSubSch.Dispose();
                    m_fTmrSubSch = null;
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

        private string[] getBackupLogFile(
            )
        {
            List<string> logFiles = null;
            string searchFileName = string.Empty;
            string searchPatten = string.Empty;

            try
            {
                // ***
                // 수집할 Log File의 날짜 계산, Log Keeping Period로 계산
                // ***
                searchFileName = DateTime.Now.AddDays(-1 * m_fCntCore.fOption.adsLogKeepingPeriod).ToString("yyyyMMddHHmmssfff");

                // --
                
                logFiles = new List<string>();
                if (m_fLogType == FSecs1ToHsmsConverterLogFileType.Application)
                {
                    searchPatten = "*.log";
                }
                else
                {
                    searchPatten = "*.dlg";
                }

                // --

                foreach (string f in Directory.GetFiles(m_fCntCore.logPath, searchPatten))
                {
                    // ***
                    // Log File이 Keeping Period 보다 클 경우 Log File 수집 종료
                    // ***
                    if (searchFileName.CompareTo(Path.GetFileName(f)) < 0)
                    {
                        break;
                    }

                    // --

                    logFiles.Add(f);
                    
                    // --                    
                    
                    // ***
                    // Log File이 압축 File 개수 보다 클 경우 수집 종료
                    // 압축 개수 보다 크게 비교하는 이유는 현제 사용하고 있는 Log File은 압축에
                    // 포함시키지 않도록 처리하기 위함이다.
                    // 즉, Log File 압축은 압축 파일 개수보다 파일의 개수가 1개 클 경우에만 동작한다.
                    // ***
                    if (logFiles.Count > m_fCntCore.fOption.adsLogCompressCount)
                    {
                        break;
                    }
                }

                // --

                // ***
                // Log File이 압축 File 개수 보다 작을 경우 압축하지 않도록 처리
                // ***
                if (logFiles.Count < m_fCntCore.fOption.adsLogCompressCount + 1)
                {
                    logFiles.Clear();
                }

                // --

                // ***
                // 압축할 Log File를 압축 File 개수로 조정한다.
                // ***
                if (logFiles.Count > m_fCntCore.fOption.adsLogCompressCount)
                {
                    logFiles.RemoveRange(m_fCntCore.fOption.adsLogCompressCount, logFiles.Count - m_fCntCore.fOption.adsLogCompressCount);
                }

                // --
                
                return logFiles.ToArray();
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

        //------------------------------------------------------------------------------------------------------------------------

        private void procBackupLogFile(
            )
        {
            StringBuilder logData = new StringBuilder();
            string[] logFiles = null;
            string log = string.Empty;

            try
            {
                logFiles = getBackupLogFile();
                if (logFiles == null || logFiles.Length == 0)
                {
                    m_logBackupCompleted = true;
                    return;
                }
                m_logBackupCompleted = false;

                // --

                m_fCntCore.fSecs1ToHsms.writeAppLog(
                    FCommon.getAdminLog("procBackupLogFile", FResultCode.Success, string.Empty, logData.ToString())
                    );
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);

                // --

                logData.Append(FCommon.getAdminExceptionLog(ex));
                // --
                m_fCntCore.fSecs1ToHsms.writeAppLog(
                    FCommon.getAdminLog("procBackupLogFile", FResultCode.Error, ex.Message, logData.ToString())
                    );

                // --

                // ***
                // 압축 작업이 실패할 경우, 계속적으로 빈번히 발생할 수 있기 때문에
                // 다음 Backup Cycle 시간에 시도하도록 Completed를 true로 설정한다.
                // ***
                m_logBackupCompleted = true;
            }
            finally
            {
                logData = null;         
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fThdMain Object Event Handler

        private void m_fThdSch_ThreadJobCalled(
            object sender, 
            FThreadEventArgs e
            )
        {
            try
            {
                if (m_fTmrSch == null)
                {
                    m_fTmrSch = new FStaticTimer();                                       
                }
                else if (m_fTmrSch.enabled && !m_fTmrSch.elasped(false))
                {
                    e.sleepThread(1);
                    return;
                }                

                // --

                if (m_fTmrSubSch == null)
                {
                    m_fTmrSubSch = new FStaticTimer();
                }
                else if (m_fTmrSubSch.enabled && !m_fTmrSubSch.elasped(false))
                {
                    e.sleepThread(1);
                    return;
                }

                // --

                procBackupLogFile();

                // --

                // ***
                // Log Backup은 Application Log와 Debug Log를 번갈아 가며 수행한다.
                // Log Backup이 완료되지 않을 경우 일정 시간 지연후 수행하도록 처리한다.
                // 한번에 많은 Log를 처리할 경우 CPU 점유로 인해 Server에 과부하를 발생할 수 있기 때문이다.
                // ***
                if (m_logBackupCompleted)
                {
                    if (m_fLogType == FSecs1ToHsmsConverterLogFileType.Application)
                    {
                        m_fLogType = FSecs1ToHsmsConverterLogFileType.Debug;                        
                        // --
                        m_fTmrSubSch.start(1000);
                    }
                    else
                    {
                        m_fLogType = FSecs1ToHsmsConverterLogFileType.Application;
                        // --
                        // m_fTmrSch.start(m_fBcrCore.fOption.adsLogBackupTime * 60 * 1000);  // to min
                        m_fTmrSch.start(m_fCntCore.fOption.adsLogBackupTime * 100);  // to min
                    }
                }
                else
                {
                    m_fTmrSubSch.start(1000);
                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);

                // --

                // ***
                // Thread 작업 실패 시, 빈번히 발생할 수 있기 때문에 1초간 Delay 한다.
                // ***
                e.sleepThread(1000);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
