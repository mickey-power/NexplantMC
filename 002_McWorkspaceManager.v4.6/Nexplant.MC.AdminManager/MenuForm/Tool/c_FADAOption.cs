/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2012 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FADAOption.cs
--  Creator         : baehyun.seo
--  Create Date     : 2012.12.21
--  Description     : FAMate Admin Manager Agent Option Class 
--  History         : Created by baehyun.seo at 2012.12.21
----------------------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public class FADAOption : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        // ***
        // General
        // ***
        private string m_factory = string.Empty;
        private string m_server = string.Empty;       
        private string m_user = string.Empty;        
        private int m_serverThreadingCount = 0;        
        private string m_dataFolder = string.Empty;        
        private string m_logFolder = string.Empty;        
        private string m_ftpIp = string.Empty;        
        private bool m_ftpUsedAnonymous = true;
        private string m_ftpUser = string.Empty;
        private string m_ftpPassword = string.Empty;        
        // --
        // ***
        // Highway 101
        // ***
        private string m_stationConnectString = string.Empty;        
        private int m_stationTimeout = 0;        
        private string m_adsTuneChannel = string.Empty;        
        private string m_adsCastChannel = string.Empty;
        // --
        // ***
        // Direction Policy
        // ***
        private FYesNo m_eapWatchEnabled = FYesNo.No;
        private int m_eapWatchCycleTime = 0;
        // --
        private FYesNo m_opcServerWatchEnabled = FYesNo.No;
        private int m_opcServerWatchCycleTime = 0;
        private string m_opcServerProcessName = string.Empty;
        // --
        // ***
        // Resource Collection
        // ***
        private FYesNo m_resourceCollectionEnabled = FYesNo.No;        
        private int m_resourceCollectionCycleTime = 0;        
        // --
        // ***
        // Log Policy
        // ***
        private int m_adaLogFileSize = 0;        
        private int m_adaLogBackupCycleTime = 0;        
        private int m_adaLogFileCompressCount = 0;        
        private int m_adaLogFileKeepingPeriod = 0;        
        private int m_eapBackupCycleTime = 0;        
        private int m_eapLogFileCompressCount = 0;        
        private int m_eapLogFileKeepingPeriod = 0;        
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FADAOption(
            )
        {
                    
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FADAOption(
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

        #region General

        public string factory
        {
            get
            {
                try
                {
                    return m_factory;
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
                    m_factory = value;
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

        public string server
        {
            get
            {
                try
                {
                    return m_server;
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
                    m_server = value;
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

        public string user
        {
            get
            {
                try
                {
                    return m_user;
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
                    m_user = value;
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

        public int serverThreadingCount
        {
            get
            {
                try
                {
                    return m_serverThreadingCount;

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
                    m_serverThreadingCount = value;
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

        public string dataFolder
        {
            get
            {
                try
                {
                    return m_dataFolder;
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
                    m_dataFolder = value;
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

        public string logFolder
        {
            get
            {
                try
                {
                    return m_logFolder;
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
                    m_logFolder = value;
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

        public string ftpIp
        {
            get
            {
                try
                {
                    return m_ftpIp;
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
                    m_ftpIp = value;
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

        public bool ftpUsedAnonymous
        {
            get
            {
                try
                {
                    return m_ftpUsedAnonymous;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return true;
            }

            set
            {
                try
                {
                    m_ftpUsedAnonymous = value;
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

        public string ftpUser
        {
            get
            {
                try
                {
                    return m_ftpUser;
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
                    m_ftpUser = value;
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

        public string ftpPassword
        {
            get
            {
                try
                {
                    return m_ftpPassword;
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
                    m_ftpPassword = value;
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

        #region Highway 101

        public string stationConnectString
        {
            get
            {
                try
                {
                    return m_stationConnectString;
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
                    m_stationConnectString = value;
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

        public int stationTimeout
        {
            get
            {
                try
                {
                    return m_stationTimeout;
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
                    m_stationTimeout = value;
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

        public string adsTuneChannel
        {
            get
            {
                try
                {
                    return m_adsTuneChannel;
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
                    m_adsTuneChannel = value;
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

        public string adsCastChannel
        {
            get
            {
                try
                {
                    return m_adsCastChannel;
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
                    m_adsCastChannel = value;
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

        #region Detection Policy

        public FYesNo eapWatchEnabled
        {
            get
            {
                try
                {
                    return m_eapWatchEnabled;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FYesNo.No;
            }

            set
            {
                try
                {
                    m_eapWatchEnabled = value;
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

        public int eapWatchCycleTime
        {
            get
            {
                try
                {
                    return m_eapWatchCycleTime;
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
                    m_eapWatchCycleTime = value;
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

        public FYesNo opcServerWatchEnabled
        {
            get
            {
                try
                {          
                    return m_opcServerWatchEnabled;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FYesNo.No;
            }

            set
            {
                try
                {
                    m_opcServerWatchEnabled = value;
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

        public int opcServerWatchCycleTime
        {
            get
            {
                try
                {
                    return m_opcServerWatchCycleTime;
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
                    m_opcServerWatchCycleTime = value;
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

        public string opcServerProcessName
        {
            get
            {
                try
                {
                    return m_opcServerProcessName;
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
                    m_opcServerProcessName = value;
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

        #region Resource Collection

        public FYesNo resourceCollectionEnabled
        {
            get 
            {
                try
                {
                    return m_resourceCollectionEnabled;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
 
                }
                return FYesNo.No;
            }

            set
            {
                try
                {
                    m_resourceCollectionEnabled = value;
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

        public int resourceCollectionCycleTime
        {
            get
            {
                try
                {
                    return m_resourceCollectionCycleTime;
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
                    m_resourceCollectionCycleTime = value;
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

        #region Log Policy

        public int adaLogFileSize
        {
            get
            {
                try
                {
                    return m_adaLogFileSize;
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
                    m_adaLogFileSize = value;
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

        public int adaLogBackupCycleTime
        {
            get
            {
                try
                {
                    return m_adaLogBackupCycleTime;
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
                    m_adaLogBackupCycleTime = value;
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

        public int adaLogFileCompressCount
        {
            get
            {
                try
                {
                    return m_adaLogFileCompressCount;
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
                    m_adaLogFileCompressCount = value;
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

        public int adaLogFileKeepingPeriod
        {
            get
            {
                try
                {
                    return m_adaLogFileKeepingPeriod;
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
                    m_adaLogFileKeepingPeriod = value;
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

        public int eapBackupCycleTime
        {
            get
            {
                try
                {
                    return m_eapBackupCycleTime;
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
                    m_eapBackupCycleTime = value;
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

        public int eapLogFileCompressCount
        {
            get
            {
                try
                {
                    return m_eapLogFileCompressCount;
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
                    m_eapLogFileCompressCount = value;
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

        public int eapLogFileKeepingPeriod
        {
            get
            {
                try
                {
                    return m_eapLogFileKeepingPeriod;
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
                    m_eapLogFileKeepingPeriod = value;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods
        
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
