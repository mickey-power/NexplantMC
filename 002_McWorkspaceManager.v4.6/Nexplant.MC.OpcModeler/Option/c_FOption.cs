/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FOption.cs
--  Creator         : baehyun.seo
--  Create Date     : 2013.01.29
--  Description     : FAMate OPC Modeler Option Class 
--  History         : Created by baehyun.seo at 2013.01.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.IO;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.OpcModeler
{
    public class FOption : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FOpmCore m_fOpmCore = null;
        // --
        private FFormList m_fChildFormList = null;
        // --
        private string m_optionFileName = string.Empty;
        private FXmlDocument m_fXmlDocOpt = null;
        // --
        private bool m_enabledEventsOfOpcDeviceState = false;
        private bool m_enabledEventsOfOpcDeviceError = false;
        private bool m_enabledEventsOfOpcDeviceTimeout = false;
        private bool m_enabledEventsOfOpcDeviceDataMessage = false;
        // --
        private bool m_enabledEventsOfHostDeviceState = false;
        private bool m_enabledEventsOfHostDeviceError = false;
        private bool m_enabledEventsOfHostDeviceVfei = false;
        private bool m_enabledEventsOfHostDeviceDataMessage = false;
        private bool m_enabledEventsOfScenario = false;
        private bool m_enabledEventsOfApplication = false;
        // --
        private string m_logDirectory = string.Empty;
        private bool m_enabledLogOfVfei = false;
        private bool m_enabledLogOfOpc = false;
        // --
        private long m_maxLogFileSizeOfVfei = 0;
        private long m_maxLogFileSizeOfOpc = 0;    
        // --
        private bool m_enabledFilterOfOpcDeviceState = false;
        private bool m_enabledFilterOfOpcDeviceError = false;
        private bool m_enabledFilterOfOpcDeviceTimeout = false;
        private bool m_enabledFilterOfOpcDeviceDataMessage = false;
        // --
        private bool m_enabledFilterOfHostDeviceState = false;
        private bool m_enabledFilterOfHostDeviceError = false;
        private bool m_enabledFilterOfHostDeviceDataMessage = false;
        private bool m_enabledFilterOfScenario = false;
        private bool m_enabledFilterOfApplication = false;
        // --
        private string m_libRecentOpenPath = string.Empty;
        private string m_libRecentSavePath = string.Empty;
        private List<string> m_libRecentFileList = null;
        // --
        private string m_logRecentOpenPath = string.Empty;
        private string m_logRecentSavePath = string.Empty;
        private List<string> m_logRecentFileList = null;
        // --
        private string m_libRecentExportPath = string.Empty;
        // --       
        private int m_vfeiTracerMaxTraceCount = 0;
        // --
        private string m_vfeiViewerRecentOpenPath = string.Empty;
        private string m_vfeiViewerRecentSavePath = string.Empty;
        // --
        private string m_commonFontName = string.Empty;
        private float m_commonFontSize = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FOption(
            FOpmCore fOpmCore 
            )
        {
            m_fOpmCore = fOpmCore;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FOption(
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
                    m_fOpmCore = null;
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

        public FFormList fChildFormList
        {
            get
            {
                try
                {
                    return m_fChildFormList;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string logDirectory
        {
            get
            {
                try
                {
                    return m_logDirectory;
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
                    m_logDirectory = Directory.Exists(value) ? value : Path.Combine(m_fOpmCore.fWsmCore.usrPath, "Log");
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

        public bool enabledEventsOfOpcDeviceState
        {
            get
            {
                try
                {
                    return m_enabledEventsOfOpcDeviceState;
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
                    m_enabledEventsOfOpcDeviceState = value;
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

        public bool enabledEventsOfOpcDeviceError
        {
            get
            {
                try
                {
                    return m_enabledEventsOfOpcDeviceError;
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
                    m_enabledEventsOfOpcDeviceError = value;
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

        public bool enabledEventsOfOpcDeviceTimeout
        {
            get
            {
                try
                {
                    return m_enabledEventsOfOpcDeviceTimeout;
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
                    m_enabledEventsOfOpcDeviceTimeout = value;
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

        public bool enabledEventsOfOpcDeviceDataMessage
        {
            get
            {
                try
                {
                    return m_enabledEventsOfOpcDeviceDataMessage;
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
                    m_enabledEventsOfOpcDeviceDataMessage = value;
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

        public bool enabledEventsOfHostDeviceState
        {
            get
            {
                try
                {
                    return m_enabledEventsOfHostDeviceState;
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
                    m_enabledEventsOfHostDeviceState = value;
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

        public bool enabledEventsOfHostDeviceError
        {
            get
            {
                try
                {
                    return m_enabledEventsOfHostDeviceError;
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
                    m_enabledEventsOfHostDeviceError = value;
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

        public bool enabledEventsOfHostDeviceVfei
        {
            get
            {
                try
                {
                    return m_enabledEventsOfHostDeviceVfei;
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
                    m_enabledEventsOfHostDeviceVfei = value;
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

        public bool enabledEventsOfHostDeviceDataMessage
        {
            get
            {
                try
                {
                    return m_enabledEventsOfHostDeviceDataMessage;
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
                    m_enabledEventsOfHostDeviceDataMessage = value;
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

        public bool enabledEventsOfScenario
        {
            get
            {
                try
                {
                    return m_enabledEventsOfScenario;
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
                    m_enabledEventsOfScenario = value;
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

        public bool enabledEventsOfApplication
        {
            get
            {
                try
                {
                    return m_enabledEventsOfApplication;
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
                    m_enabledEventsOfApplication = value;
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

        public bool enabledFilterOfOpcDeviceState
        {
            get
            {
                try
                {
                    return m_enabledFilterOfOpcDeviceState;
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
                    m_enabledFilterOfOpcDeviceState = value;
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

        public bool enabledFilterOfOpcDeviceError
        {
            get
            {
                try
                {
                    return m_enabledFilterOfOpcDeviceError;
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
                    m_enabledFilterOfOpcDeviceError = value;
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

        public bool enabledFilterOfOpcDeviceTimeout
        {
            get
            {
                try
                {
                    return m_enabledFilterOfOpcDeviceTimeout;
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
                    m_enabledFilterOfOpcDeviceTimeout = value;
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

        public bool enabledFilterOfOpcDeviceDataMessage
        {
            get
            {
                try
                {
                    return m_enabledFilterOfOpcDeviceDataMessage;
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
                    m_enabledFilterOfOpcDeviceDataMessage = value;
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

        public bool enabledFilterOfHostDeviceState
        {
            get
            {
                try
                {
                    return m_enabledFilterOfHostDeviceState;
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
                    m_enabledFilterOfHostDeviceState = value;
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

        public bool enabledFilterOfHostDeviceError
        {
            get
            {
                try
                {
                    return m_enabledFilterOfHostDeviceError;
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
                    m_enabledFilterOfHostDeviceError = value;
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

        public bool enabledFilterOfHostDeviceDataMessage
        {
            get
            {
                try
                {
                    return m_enabledFilterOfHostDeviceDataMessage;
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
                    m_enabledFilterOfHostDeviceDataMessage = value;
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

        public bool enabledFilterOfScenario
        {
            get
            {
                try
                {
                    return m_enabledFilterOfScenario;
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
                    m_enabledFilterOfScenario = value;
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

        public bool enabledFilterOfApplication
        {
            get
            {
                try
                {
                    return m_enabledFilterOfApplication;
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
                    m_enabledFilterOfApplication = value;
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

        public bool enabledLogOfVfei
        {
            get
            {
                try
                {
                    return m_enabledLogOfVfei;
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
                    m_enabledLogOfVfei = value;
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

        public bool enabledLogOfOpc
        {
            get
            {
                try
                {
                    return m_enabledLogOfOpc;
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
                    m_enabledLogOfOpc = value;
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

        public long maxLogFileSizeOfVfei
        {
            get
            {
                try
                {
                    return m_maxLogFileSizeOfVfei;
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
                    m_maxLogFileSizeOfVfei = value;
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

        public long maxLogFileSizeOfOpc
        {
            get
            {
                try
                {
                    return m_maxLogFileSizeOfOpc;
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
                    m_maxLogFileSizeOfOpc = value;
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

        public string libRecentOpenPath
        {
            get
            {
                try
                {
                    return m_libRecentOpenPath;
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
                    m_libRecentOpenPath = Directory.Exists(value) ? value : m_fOpmCore.fWsmCore.usrPath;
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

        public string libRecentSavePath
        {
            get
            {
                try
                {
                    return m_libRecentSavePath;
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
                    m_libRecentSavePath = Directory.Exists(value) ? value : m_fOpmCore.fWsmCore.usrPath;
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

        public List<string> libRecentFileList
        {
            get
            {
                try
                {
                    return m_libRecentFileList;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string logRecentOpenPath
        {
            get
            {
                try
                {
                    return m_logRecentOpenPath;
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
                    m_logRecentOpenPath = Directory.Exists(value) ? value : Path.Combine(m_fOpmCore.fWsmCore.usrPath, "Log");
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

        public string logRecentSavePath
        {
            get
            {
                try
                {
                    return m_logRecentSavePath;
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
                    m_logRecentSavePath = Directory.Exists(value) ? value : m_fOpmCore.fWsmCore.usrPath;
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

        public List<string> logRecentFileList
        {
            get
            {
                try
                {
                    return m_logRecentFileList;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string libRecentExportPath
        {
            get
            {
                try
                {
                    return m_libRecentExportPath;
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
                    m_libRecentExportPath = Directory.Exists(value) ? value : m_fOpmCore.fWsmCore.usrPath;
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

        public int vfeiTracerMaxTraceCount
        {
            get
            {
                try
                {
                    return m_vfeiTracerMaxTraceCount;
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
                    m_vfeiTracerMaxTraceCount = value;
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

        public string vfeiViewerRecentOpenPath
        {
            get
            {
                try
                {
                    return m_vfeiViewerRecentOpenPath;
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
                    m_vfeiViewerRecentOpenPath = Directory.Exists(value) ? value : Path.Combine(m_fOpmCore.fWsmCore.usrPath, "Log");
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

        public string vfeiViewerRecentSavePath
        {
            get
            {
                try
                {
                    return m_vfeiViewerRecentSavePath;
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
                    m_vfeiViewerRecentSavePath = Directory.Exists(value) ? value : m_fOpmCore.fWsmCore.usrPath;
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

        public string commonFontName
        {
            get
            {
                try
                {
                    return m_commonFontName;
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
                    m_commonFontName = (new System.Drawing.FontFamily(value)).Name;
                }
                catch (Exception ex)
                {
                    m_commonFontName = FXmlTagOPMOption.D_CommonFontName;
                    FDebug.writeLog(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public float commonFontSize
        {
            get
            {
                try
                {
                    return m_commonFontSize;
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
                    m_commonFontSize = value;
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
                m_optionFileName = Path.Combine(m_fOpmCore.fWsmCore.optionPath, "NexplantMCOpcModeler.cfg");

                // --

                m_fChildFormList = new FFormList(m_fOpmCore);
                // --
                m_libRecentFileList = new List<string>(FConstants.RecentMaxCount);
                m_logRecentFileList = new List<string>(FConstants.RecentMaxCount);

                // --

                if (File.Exists(m_optionFileName))
                {
                    loadOption();
                }
                else
                {
                    createOption();
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

        private void term(
            )
        {
            try
            {
                if (m_fXmlDocOpt != null)
                {
                    m_fXmlDocOpt.Dispose();
                    m_fXmlDocOpt = null;
                }

                if (m_fChildFormList != null)
                {
                    m_fChildFormList.Dispose();
                    m_fChildFormList = null;
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

        private void createOption(
            )
        {
            FXmlNode fXmlNodeFam = null;
            FXmlNode fXmlNodePlm = null;
            string creationTime = string.Empty;
            string dirName = string.Empty;

            try
            {
                creationTime = FDataConvert.defaultNowDateTimeToString();

                // --
                // ***
                // Default Value Set                
                // ***
                m_enabledEventsOfOpcDeviceState = true;
                m_enabledEventsOfOpcDeviceError = true;
                m_enabledEventsOfOpcDeviceTimeout = true;
                m_enabledEventsOfOpcDeviceDataMessage = true;
                m_enabledEventsOfHostDeviceState = true;
                m_enabledEventsOfHostDeviceError = true;
                m_enabledEventsOfHostDeviceVfei = false;
                m_enabledEventsOfHostDeviceDataMessage = true;
                m_enabledEventsOfScenario = true;
                m_enabledEventsOfApplication = true;            
                // --
                logDirectory = Path.Combine(m_fOpmCore.fWsmCore.usrPath, "Log");
                m_enabledLogOfVfei = false;
                m_enabledLogOfOpc = false;
                // --
                m_maxLogFileSizeOfVfei = int.Parse(FXmlTagOPMOption.D_MaxLogFileSizeOfVfei);
                m_maxLogFileSizeOfOpc = int.Parse(FXmlTagOPMOption.D_MaxLogFileSizeOfOpc);
                // --
                m_enabledFilterOfOpcDeviceState = true;
                m_enabledFilterOfOpcDeviceError = true;
                m_enabledFilterOfOpcDeviceTimeout = true;
                m_enabledFilterOfOpcDeviceDataMessage = true;
                m_enabledFilterOfHostDeviceState = true;
                m_enabledFilterOfHostDeviceError = true;
                m_enabledFilterOfHostDeviceDataMessage = true;
                m_enabledFilterOfScenario = true;
                m_enabledFilterOfApplication = true;
                // --
                libRecentOpenPath = m_fOpmCore.fWsmCore.usrPath;
                libRecentSavePath = m_fOpmCore.fWsmCore.usrPath;
                // --
                logRecentOpenPath = m_logDirectory;
                logRecentSavePath = m_fOpmCore.fWsmCore.usrPath;
                libRecentExportPath = m_fOpmCore.fWsmCore.usrPath;
                // --
                m_vfeiTracerMaxTraceCount = int.Parse(FXmlTagOPMOption.D_VfeiTracerMaxTraceCount);
                // --
                vfeiViewerRecentOpenPath = m_logDirectory;
                vfeiViewerRecentSavePath = m_fOpmCore.fWsmCore.usrPath;
                // --
                m_commonFontName = FXmlTagOPMOption.D_CommonFontName;
                m_commonFontSize = float.Parse(FXmlTagOPMOption.D_CommonFontSize);
                // --
                // ***
                // Option XML Document Create
                // ***                
                if (m_fXmlDocOpt != null)
                {
                    m_fXmlDocOpt.Dispose();
                    m_fXmlDocOpt = null;
                }
                // --
                m_fXmlDocOpt = new FXmlDocument();
                m_fXmlDocOpt.preserveWhiteSpace = false;
                m_fXmlDocOpt.appendChild(m_fXmlDocOpt.createXmlDeclaration("1.0", string.Empty, string.Empty));
                // --

                // ***
                // FAMate Element Create
                // ***
                fXmlNodeFam = m_fXmlDocOpt.appendChild(m_fXmlDocOpt.createNode(FXmlTagFAMate.E_FAMate));
                // --
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileFormat, FXmlTagFAMate.D_FileFormat, "CFG");
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileVersion, FXmlTagFAMate.D_FileVersion, "4.5.1.10");
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileCreationTime, FXmlTagFAMate.D_FileCreationTime, creationTime);
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileUpdateTime, FXmlTagFAMate.D_FileUpdateTime, creationTime);
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileDescription, FXmlTagFAMate.D_FileDescription, "Nexplant MC OPC Modeler Option File");
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_UniqueIdPointer, FXmlTagFAMate.D_UniqueIdPointer, "0");

                // --

                // ***
                // OPC Modeler Option Element Create
                // ***
                fXmlNodePlm = fXmlNodeFam.appendChild(m_fXmlDocOpt.createNode(FXmlTagOPMOption.E_OPMOption));

                // ---

                // ***
                // Default Option Save
                // *** 
                save();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeFam = null;
                fXmlNodePlm = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadOption(
            )
        {
            FXmlNode fXmlNodePlm = null;

            try
            {
                // ***
                // Option XML Document Load
                // *** 
                if (m_fXmlDocOpt != null)
                {
                    m_fXmlDocOpt.Dispose();
                    m_fXmlDocOpt = null;
                }
                m_fXmlDocOpt = new FXmlDocument();
                m_fXmlDocOpt.preserveWhiteSpace = false;
                m_fXmlDocOpt.load(m_optionFileName);

                // --

                fXmlNodePlm = m_fXmlDocOpt.selectSingleNode(FXmlTagFAMate.E_FAMate + "/" + FXmlTagOPMOption.E_OPMOption);
                if (fXmlNodePlm == null)
                {
                    createOption();
                    return;
                }

                // --

                // --
                // OPC Modeler Option Load
                // ***                                
                enabledEventsOfOpcDeviceState = (fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_EnabledEventsOfOpcDeviceState, FXmlTagOPMOption.D_EnabledEventsOfOpcDeviceState) == FBoolean.True.ToString());
                enabledEventsOfOpcDeviceError = (fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_EnabledEventsOfOpcDeviceError, FXmlTagOPMOption.D_EnabledEventsOfOpcDeviceError) == FBoolean.True.ToString());
                enabledEventsOfOpcDeviceTimeout = (fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_EnabledEventsOfOpcDeviceTimeout, FXmlTagOPMOption.D_EnabledEventsOfOpcDeviceTimeout) == FBoolean.True.ToString());
                enabledEventsOfOpcDeviceDataMessage = (fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_EnabledEventsOfOpcDeviceControlMessage, FXmlTagOPMOption.D_EnabledEventsOfOpcDeviceDataMessage) == FBoolean.True.ToString());
                enabledEventsOfHostDeviceState = (fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_EnabledEventsOfHostDeviceState, FXmlTagOPMOption.D_EnabledEventsOfHostDeviceState) == FBoolean.True.ToString());
                enabledEventsOfHostDeviceError = (fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_EnabledEventsOfHostDeviceError, FXmlTagOPMOption.D_EnabledEventsOfHostDeviceError) == FBoolean.True.ToString());
                enabledEventsOfHostDeviceVfei = (fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_EnabledEventsOfHostDeviceVfei, FXmlTagOPMOption.D_EnabledEventsOfHostDeviceVfei) == FBoolean.True.ToString());
                enabledEventsOfHostDeviceDataMessage = (fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_EnabledEventsOfHostDeviceDataMessage, FXmlTagOPMOption.D_EnabledEventsOfHostDeviceDataMessage) == FBoolean.True.ToString());
                enabledEventsOfScenario = (fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_EnabledEventsOfScenario, FXmlTagOPMOption.D_EnabledEventsOfScenario) == FBoolean.True.ToString());
                enabledEventsOfApplication = (fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_EnabledEventsOfApplication, FXmlTagOPMOption.D_EnabledEventsOfApplication) == FBoolean.True.ToString());
                // --
                logDirectory = fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_LogDirectory, FXmlTagOPMOption.D_LogDirectory);
                // --
                enabledLogOfVfei = (fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_EnabledLogOfVfei, FXmlTagOPMOption.D_EnabledLogOfVfei) == FBoolean.True.ToString());
                enabledLogOfOpc = (fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_EnabledLogOfOpc, FXmlTagOPMOption.D_EnabledLogOfOpc) == FBoolean.True.ToString());
                // --
                maxLogFileSizeOfVfei = int.Parse(fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_MaxLogFileSizeOfVfei, FXmlTagOPMOption.D_MaxLogFileSizeOfVfei));
                maxLogFileSizeOfOpc = int.Parse(fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_MaxLogFileSizeOfOpc, FXmlTagOPMOption.D_MaxLogFileSizeOfOpc));
                // --
                enabledFilterOfOpcDeviceState = (fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_EnabledFilterOfOpcDeviceState, FXmlTagOPMOption.D_EnabledFilterOfOpcDeviceState) == FBoolean.True.ToString());
                enabledFilterOfOpcDeviceError = (fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_EnabledFilterOfOpcDeviceError, FXmlTagOPMOption.D_EnabledFilterOfOpcDeviceError) == FBoolean.True.ToString());
                enabledFilterOfOpcDeviceTimeout = (fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_EnabledFilterOfOpcDeviceTimeout, FXmlTagOPMOption.D_EnabledFilterOfOpcDeviceTimeout) == FBoolean.True.ToString());
                enabledFilterOfOpcDeviceDataMessage = (fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_EnabledFilterOfOpcDeviceDataMessage, FXmlTagOPMOption.D_EnabledFilterOfOpcDeviceDataMessage) == FBoolean.True.ToString());
                enabledFilterOfHostDeviceState = (fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_EnabledFilterOfHostDeviceState, FXmlTagOPMOption.D_EnabledFilterOfHostDeviceState) == FBoolean.True.ToString());
                enabledFilterOfHostDeviceError = (fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_EnabledFilterOfHostDeviceError, FXmlTagOPMOption.D_EnabledFilterOfHostDeviceError) == FBoolean.True.ToString());
                enabledFilterOfHostDeviceDataMessage = (fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_EnabledFilterOfHostDeviceDataMessage, FXmlTagOPMOption.D_EnabledFilterOfHostDeviceDataMessage) == FBoolean.True.ToString());
                enabledFilterOfScenario = (fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_EnabledFilterOfScenario, FXmlTagOPMOption.D_EnabledFilterOfScenario) == FBoolean.True.ToString());
                enabledFilterOfApplication = (fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_EnabledFilterOfApplication, FXmlTagOPMOption.D_EnabledFilterOfApplication) == FBoolean.True.ToString());
                // --
                libRecentOpenPath = fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_LibRecentOpenPath, FXmlTagOPMOption.D_LibRecentOpenPath);
                libRecentSavePath = fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_LibRecentSavePath, FXmlTagOPMOption.D_LibRecentSavePath);
                // --
                logRecentOpenPath = fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_LogRecentOpenPath, FXmlTagOPMOption.D_LogRecentOpenPath);
                logRecentSavePath = fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_LogRecentSavePath, FXmlTagOPMOption.D_LogRecentSavePath);
                // --
                libRecentExportPath = fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_LibRecentExportPath, FXmlTagOPMOption.D_LibRecentExportPath);
                // --
                vfeiTracerMaxTraceCount = int.Parse(fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_VfeiTracerMaxTraceCount, FXmlTagOPMOption.D_VfeiTracerMaxTraceCount));
                // --
                vfeiViewerRecentOpenPath = fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_VfeiViewerRecentOpenPath, FXmlTagOPMOption.D_VfeiViewerRecentOpenPath);
                vfeiViewerRecentSavePath = fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_VfeiViewerRecentSavePath, FXmlTagOPMOption.D_VfeiViewerRecentSavePath);
                // --
                commonFontName = fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_CommonFontName, FXmlTagOPMOption.D_CommonFontName);
                commonFontSize = float.Parse(fXmlNodePlm.get_attrVal(FXmlTagOPMOption.A_CommonFontSize, FXmlTagOPMOption.D_CommonFontSize));

                // ***
                // Recent File Load
                // ***    
                libRecentFileList.Clear();
                foreach (FXmlNode n in fXmlNodePlm.selectNodes(FXmlTagOPMOption.E_Recent + "[contains(@" + FXmlTagOPMOption.A_File + ",'.osm')]"))
                {
                    libRecentFileList.Add(n.get_attrVal(FXmlTagOPMOption.A_File, FXmlTagOPMOption.D_File));
                }
                // --
                logRecentFileList.Clear();
                foreach (FXmlNode n in fXmlNodePlm.selectNodes(FXmlTagOPMOption.E_Recent + "[not(contains(@" + FXmlTagOPMOption.A_File + ",'.osm'))]"))
                {
                    logRecentFileList.Add(n.get_attrVal(FXmlTagOPMOption.A_File, FXmlTagOPMOption.D_File));
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodePlm = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void save(
            )
        {
            FXmlNode fXmlNodeFam = null;
            FXmlNode fXmlNodePlm = null;
            string updateTime = string.Empty;
            string dirName = string.Empty;

            try
            {
                if (m_fXmlDocOpt == null)
                {
                    return;
                }

                // --

                updateTime = FDataConvert.defaultNowDateTimeToString();

                // --

                // ***
                // FAMate Element Set
                // ***
                fXmlNodeFam = m_fXmlDocOpt.selectSingleNode(FXmlTagFAMate.E_FAMate);
                // --
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileUpdateTime, FXmlTagFAMate.D_FileUpdateTime, updateTime);

                // --

                // ***
                // OPC Modeler Option Element set
                // ***
                fXmlNodePlm = fXmlNodeFam.selectSingleNode(FXmlTagOPMOption.E_OPMOption);
                // --
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_EnabledEventsOfOpcDeviceState, FXmlTagOPMOption.D_EnabledEventsOfOpcDeviceState, enabledEventsOfOpcDeviceState ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_EnabledEventsOfOpcDeviceError, FXmlTagOPMOption.D_EnabledEventsOfOpcDeviceError, enabledEventsOfOpcDeviceError ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_EnabledEventsOfOpcDeviceTimeout, FXmlTagOPMOption.D_EnabledEventsOfOpcDeviceTimeout, enabledEventsOfOpcDeviceTimeout ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_EnabledEventsOfOpcDeviceDataMessage, FXmlTagOPMOption.D_EnabledEventsOfOpcDeviceDataMessage, enabledEventsOfOpcDeviceDataMessage ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_EnabledEventsOfHostDeviceState, FXmlTagOPMOption.D_EnabledEventsOfHostDeviceState, enabledEventsOfHostDeviceState ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_EnabledEventsOfHostDeviceError, FXmlTagOPMOption.D_EnabledEventsOfHostDeviceError, enabledEventsOfHostDeviceError ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_EnabledEventsOfHostDeviceVfei, FXmlTagOPMOption.D_EnabledEventsOfHostDeviceVfei, enabledEventsOfHostDeviceVfei ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_EnabledEventsOfHostDeviceDataMessage, FXmlTagOPMOption.D_EnabledEventsOfHostDeviceDataMessage, enabledEventsOfHostDeviceDataMessage ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_EnabledEventsOfScenario, FXmlTagOPMOption.D_EnabledEventsOfScenario, enabledEventsOfScenario ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_EnabledEventsOfApplication, FXmlTagOPMOption.D_EnabledEventsOfApplication, enabledEventsOfApplication ? FBoolean.True.ToString() : FBoolean.False.ToString());                
                // --
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_LogDirectory, FXmlTagOPMOption.D_LogDirectory, logDirectory);
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_EnabledLogOfVfei, FXmlTagOPMOption.D_EnabledLogOfVfei, enabledLogOfVfei ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_EnabledLogOfOpc, FXmlTagOPMOption.D_EnabledLogOfOpc, enabledLogOfOpc ? FBoolean.True.ToString() : FBoolean.False.ToString());
                // --
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_MaxLogFileSizeOfVfei, FXmlTagOPMOption.D_MaxLogFileSizeOfVfei, maxLogFileSizeOfVfei.ToString());
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_MaxLogFileSizeOfOpc, FXmlTagOPMOption.D_MaxLogFileSizeOfOpc, maxLogFileSizeOfOpc.ToString());
                // --
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_LibRecentOpenPath, FXmlTagOPMOption.D_LibRecentOpenPath, libRecentOpenPath);
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_LibRecentSavePath, FXmlTagOPMOption.D_LibRecentSavePath, libRecentSavePath);
                // --
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_LogRecentOpenPath, FXmlTagOPMOption.D_LogRecentOpenPath, logRecentOpenPath);
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_LogRecentSavePath, FXmlTagOPMOption.D_LogRecentSavePath, logRecentSavePath);
                // --
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_EnabledFilterOfOpcDeviceState, FXmlTagOPMOption.D_EnabledFilterOfOpcDeviceState, enabledFilterOfOpcDeviceState ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_EnabledFilterOfOpcDeviceError, FXmlTagOPMOption.D_EnabledFilterOfOpcDeviceError, enabledFilterOfOpcDeviceError ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_EnabledFilterOfOpcDeviceTimeout, FXmlTagOPMOption.D_EnabledFilterOfOpcDeviceTimeout, enabledFilterOfOpcDeviceTimeout ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_EnabledFilterOfOpcDeviceDataMessage, FXmlTagOPMOption.D_EnabledFilterOfOpcDeviceDataMessage, enabledFilterOfOpcDeviceDataMessage ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_EnabledFilterOfHostDeviceState, FXmlTagOPMOption.D_EnabledFilterOfHostDeviceState, enabledFilterOfHostDeviceState ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_EnabledFilterOfHostDeviceError, FXmlTagOPMOption.D_EnabledFilterOfHostDeviceError, enabledFilterOfHostDeviceError ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_EnabledFilterOfHostDeviceDataMessage, FXmlTagOPMOption.D_EnabledFilterOfHostDeviceDataMessage, enabledFilterOfHostDeviceDataMessage ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_EnabledFilterOfScenario, FXmlTagOPMOption.D_EnabledFilterOfScenario, enabledFilterOfScenario ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_EnabledFilterOfApplication, FXmlTagOPMOption.D_EnabledFilterOfApplication, enabledFilterOfApplication ? FBoolean.True.ToString() : FBoolean.False.ToString());
                // --
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_LibRecentExportPath, FXmlTagOPMOption.D_LibRecentExportPath, libRecentExportPath);
                // --
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_VfeiTracerMaxTraceCount, FXmlTagOPMOption.D_VfeiTracerMaxTraceCount, vfeiTracerMaxTraceCount.ToString());
                // --
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_VfeiViewerRecentOpenPath, FXmlTagOPMOption.D_VfeiViewerRecentOpenPath, vfeiViewerRecentOpenPath);
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_VfeiViewerRecentSavePath, FXmlTagOPMOption.D_VfeiViewerRecentSavePath, vfeiViewerRecentSavePath);
                // --
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_CommonFontName, FXmlTagOPMOption.D_CommonFontName, commonFontName);
                fXmlNodePlm.set_attrVal(FXmlTagOPMOption.A_CommonFontSize, FXmlTagOPMOption.D_CommonFontSize, commonFontSize.ToString());

                // ***
                // Recent File
                // ***
                foreach (FXmlNode n in fXmlNodePlm.selectNodes(FXmlTagOPMOption.E_Recent))
                {
                    fXmlNodePlm.removeChild(n);
                }
                foreach (string s in libRecentFileList)
                {
                    fXmlNodePlm.add_elem(FXmlTagOPMOption.E_Recent).
                        set_attrVal(FXmlTagOPMOption.A_File, FXmlTagOPMOption.D_File, s);
                }
                foreach (string s in logRecentFileList)
                {
                    fXmlNodePlm.add_elem(FXmlTagOPMOption.E_Recent).
                        set_attrVal(FXmlTagOPMOption.A_File, FXmlTagOPMOption.D_File, s);
                }

                // --

                // ***
                // Option save
                // ***  
                dirName = Path.GetDirectoryName(m_optionFileName);
                if (!Directory.Exists(dirName))
                {
                    Directory.CreateDirectory(dirName);
                }
                m_fXmlDocOpt.save(m_optionFileName);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeFam = null;
                fXmlNodePlm = null;
            }
        }        

        #endregion

        //------------------------------------------------------------------------------------------------------------------------
        
    }   // Class end
}   // Namespace end
