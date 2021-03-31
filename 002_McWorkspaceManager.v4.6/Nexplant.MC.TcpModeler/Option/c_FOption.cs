/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FOption.cs
--  Creator         : baehyun.seo
--  Create Date     : 2013.01.29
--  Description     : FAMate TCP Modeler Option Class 
--  History         : Created by baehyun.seo at 2013.01.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.IO;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.TcpModeler
{
    public class FOption : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcmCore m_fTcmCore = null;
        // --
        private FFormList m_fChildFormList = null;
        // --
        private string m_optionFileName = string.Empty;
        private FXmlDocument m_fXmlDocOpt = null;
        // --
        private bool m_enabledEventsOfTcpDeviceState = false;
        private bool m_enabledEventsOfTcpDeviceError = false;
        private bool m_enabledEventsOfTcpDeviceTimeout = false;
        private bool m_enabledEventsOfTcpDeviceDataMessage = false;
        private bool m_enabledEventsOfTcpDeviceXlg = false;
        private bool m_enabledEventsOfHostDeviceState = false;
        private bool m_enabledEventsOfHostDeviceError = false;
        private bool m_enabledEventsOfHostDeviceVfei = false;
        private bool m_enabledEventsOfHostDeviceDataMessage = false;
        private bool m_enabledEventsOfScenario = false;
        private bool m_enabledEventsOfApplication = false;
        // --
        private string m_logDirectory = string.Empty;
        private bool m_enabledLogOfBinary = false;
        private bool m_enabledLogOfXlg = false;
        private bool m_enabledLogOfVfei = false;
        private bool m_enabledLogOfTcp = false;
        // --
        private long m_maxLogFileSizeOfBinary = 0;
        private long m_maxLogFileSizeOfXlg = 0;
        private long m_maxLogFileSizeOfVfei = 0;
        private long m_maxLogFileSizeOfTcp = 0;    
        // --
        private bool m_enabledFilterOfTcpDeviceState = false;
        private bool m_enabledFilterOfTcpDeviceError = false;
        private bool m_enabledFilterOfTcpDeviceTimeout = false;
        private bool m_enabledFilterOfTcpDeviceDataMessage = false;
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
        private int m_tcpBinaryTracerMaxTraceCount = 0;
        private int m_xlgTracerMaxTraceCount = 0;        
        private int m_vfeiTracerMaxTraceCount = 0;
        // --
        private string m_xlgViewerRecentOpenPath = string.Empty;
        private string m_xlgViewerRecentSavePath = string.Empty;
        // --
        private string m_vfeiViewerRecentOpenPath = string.Empty;
        private string m_vfeiViewerRecentSavePath = string.Empty;
        // --
        private string m_commonFontName = string.Empty;
        private float m_commonFontSize = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FOption(
            FTcmCore fTcmCore 
            )
        {
            m_fTcmCore = fTcmCore;
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
                    m_fTcmCore = null;
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
                    m_logDirectory = Directory.Exists(value) ? value : Path.Combine(m_fTcmCore.fWsmCore.usrPath, "Log");
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

        public bool enabledEventsOfTcpDeviceState
        {
            get
            {
                try
                {
                    return m_enabledEventsOfTcpDeviceState;
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
                    m_enabledEventsOfTcpDeviceState = value;
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

        public bool enabledEventsOfTcpDeviceError
        {
            get
            {
                try
                {
                    return m_enabledEventsOfTcpDeviceError;
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
                    m_enabledEventsOfTcpDeviceError = value;
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

        public bool enabledEventsOfTcpDeviceTimeout
        {
            get
            {
                try
                {
                    return m_enabledEventsOfTcpDeviceTimeout;
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
                    m_enabledEventsOfTcpDeviceTimeout = value;
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

        public bool enabledEventsOfTcpDeviceXlg
        {
            get
            {
                try
                {
                    return m_enabledEventsOfTcpDeviceXlg;
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
                    m_enabledEventsOfTcpDeviceXlg = value;
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

        public bool enabledEventsOfTcpDeviceDataMessage
        {
            get
            {
                try
                {
                    return m_enabledEventsOfTcpDeviceDataMessage;
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
                    m_enabledEventsOfTcpDeviceDataMessage = value;
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

        public bool enabledFilterOfTcpDeviceState
        {
            get
            {
                try
                {
                    return m_enabledFilterOfTcpDeviceState;
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
                    m_enabledFilterOfTcpDeviceState = value;
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

        public bool enabledFilterOfTcpDeviceError
        {
            get
            {
                try
                {
                    return m_enabledFilterOfTcpDeviceError;
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
                    m_enabledFilterOfTcpDeviceError = value;
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

        public bool enabledFilterOfTcpDeviceTimeout
        {
            get
            {
                try
                {
                    return m_enabledFilterOfTcpDeviceTimeout;
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
                    m_enabledFilterOfTcpDeviceTimeout = value;
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

        public bool enabledFilterOfTcpDeviceDataMessage
        {
            get
            {
                try
                {
                    return m_enabledFilterOfTcpDeviceDataMessage;
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
                    m_enabledFilterOfTcpDeviceDataMessage = value;
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

        public bool enabledLogOfBinary
        {
            get
            {
                try
                {
                    return m_enabledLogOfBinary;
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
                    m_enabledLogOfBinary = value;
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

        public bool enabledLogOfXlg
        {
            get
            {
                try
                {
                    return m_enabledLogOfXlg;
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
                    m_enabledLogOfXlg = value;
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

        public bool enabledLogOfTcp
        {
            get
            {
                try
                {
                    return m_enabledLogOfTcp;
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
                    m_enabledLogOfTcp = value;
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

        public long maxLogFileSizeOfBinary
        {
            get
            {
                try
                {
                    return m_maxLogFileSizeOfBinary;
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
                    m_maxLogFileSizeOfBinary = value;
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

        public long maxLogFileSizeOfXlg
        {
            get
            {
                try
                {
                    return m_maxLogFileSizeOfXlg;
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
                    m_maxLogFileSizeOfXlg = value;
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

        public long maxLogFileSizeOfTcp
        {
            get
            {
                try
                {
                    return m_maxLogFileSizeOfTcp;
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
                    m_maxLogFileSizeOfTcp = value;
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
                    m_libRecentOpenPath = Directory.Exists(value) ? value : m_fTcmCore.fWsmCore.usrPath;
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
                    m_libRecentSavePath = Directory.Exists(value) ? value : m_fTcmCore.fWsmCore.usrPath;
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
                    m_logRecentOpenPath = Directory.Exists(value) ? value : Path.Combine(m_fTcmCore.fWsmCore.usrPath, "Log");
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
                    m_logRecentSavePath = Directory.Exists(value) ? value : m_fTcmCore.fWsmCore.usrPath;
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
                    m_libRecentExportPath = Directory.Exists(value) ? value : m_fTcmCore.fWsmCore.usrPath;
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

        public int tcpBinaryTracerMaxTraceCount
        {
            get
            {
                try
                {
                    return m_tcpBinaryTracerMaxTraceCount;
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
                    m_tcpBinaryTracerMaxTraceCount = value;
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

        public int xlgTracerMaxTraceCount
        {
            get
            {
                try
                {
                    return m_xlgTracerMaxTraceCount;
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
                    m_xlgTracerMaxTraceCount = value;
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

        public string xlgViewerRecentOpenPath
        {
            get
            {
                try
                {
                    return m_xlgViewerRecentOpenPath;
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
                    m_xlgViewerRecentOpenPath = Directory.Exists(value) ? value : Path.Combine(m_fTcmCore.fWsmCore.usrPath, "Log");
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

        public string xlgViewerRecentSavePath
        {
            get
            {
                try
                {
                    return m_xlgViewerRecentSavePath;
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
                    m_xlgViewerRecentSavePath = Directory.Exists(value) ? value : m_fTcmCore.fWsmCore.usrPath;
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
                    m_vfeiViewerRecentOpenPath = Directory.Exists(value) ? value : Path.Combine(m_fTcmCore.fWsmCore.usrPath, "Log");
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
                    m_vfeiViewerRecentSavePath = Directory.Exists(value) ? value : m_fTcmCore.fWsmCore.usrPath;
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
                    m_commonFontName = FXmlTagTCMOption.D_CommonFontName;
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
                m_optionFileName = Path.Combine(m_fTcmCore.fWsmCore.optionPath, "NexplantMCTcpModeler.cfg");

                // --

                m_fChildFormList = new FFormList(m_fTcmCore);
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
            FXmlNode fXmlNodeTcm = null;
            string creationTime = string.Empty;
            string dirName = string.Empty;

            try
            {
                creationTime = FDataConvert.defaultNowDateTimeToString();

                // --
                // ***
                // Default Value Set                
                // ***
                m_enabledEventsOfTcpDeviceState = true;
                m_enabledEventsOfTcpDeviceError = true;
                m_enabledEventsOfTcpDeviceTimeout = true;
                m_enabledEventsOfTcpDeviceXlg = false;
                m_enabledEventsOfTcpDeviceDataMessage = true;
                m_enabledEventsOfHostDeviceState = true;
                m_enabledEventsOfHostDeviceError = true;
                m_enabledEventsOfHostDeviceVfei = false;
                m_enabledEventsOfHostDeviceDataMessage = true;
                m_enabledEventsOfScenario = true;
                m_enabledEventsOfApplication = true;            
                // --
                logDirectory = Path.Combine(m_fTcmCore.fWsmCore.usrPath, "Log");
                m_enabledLogOfBinary = false;
                m_enabledLogOfXlg = false;
                m_enabledLogOfVfei = false;
                m_enabledLogOfTcp = false;
                // --
                m_maxLogFileSizeOfBinary = int.Parse(FXmlTagTCMOption.D_MaxLogFileSizeOfBinary);
                m_maxLogFileSizeOfXlg = int.Parse(FXmlTagTCMOption.D_MaxLogFileSizeOfXlg);
                m_maxLogFileSizeOfVfei = int.Parse(FXmlTagTCMOption.D_MaxLogFileSizeOfVfei);
                m_maxLogFileSizeOfTcp = int.Parse(FXmlTagTCMOption.D_MaxLogFileSizeOfTcp);
                // --
                m_enabledFilterOfTcpDeviceState = true;
                m_enabledFilterOfTcpDeviceError = true;
                m_enabledFilterOfTcpDeviceTimeout = true;
                m_enabledFilterOfTcpDeviceDataMessage = true;
                m_enabledFilterOfHostDeviceState = true;
                m_enabledFilterOfHostDeviceError = true;
                m_enabledFilterOfHostDeviceDataMessage = true;
                m_enabledFilterOfScenario = true;
                m_enabledFilterOfApplication = true;
                // --
                libRecentOpenPath = m_fTcmCore.fWsmCore.usrPath;
                libRecentSavePath = m_fTcmCore.fWsmCore.usrPath;
                // --
                logRecentOpenPath = m_logDirectory;
                logRecentSavePath = m_fTcmCore.fWsmCore.usrPath;
                libRecentExportPath = m_fTcmCore.fWsmCore.usrPath;
                // --
                m_tcpBinaryTracerMaxTraceCount = int.Parse(FXmlTagTCMOption.D_TcpBinaryTracerMaxTraceCount);
                // --
                m_xlgTracerMaxTraceCount = int.Parse(FXmlTagTCMOption.D_XlgTracerMaxTraceCount);
                // --
                m_vfeiTracerMaxTraceCount = int.Parse(FXmlTagTCMOption.D_VfeiTracerMaxTraceCount);
                // --
                vfeiViewerRecentOpenPath = m_logDirectory;
                vfeiViewerRecentSavePath = m_fTcmCore.fWsmCore.usrPath;
                // --
                m_xlgViewerRecentOpenPath = m_logDirectory;
                m_xlgViewerRecentSavePath = m_fTcmCore.fWsmCore.usrPath;
                // --
                m_commonFontName = FXmlTagTCMOption.D_CommonFontName;
                m_commonFontSize = float.Parse(FXmlTagTCMOption.D_CommonFontSize);
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
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileDescription, FXmlTagFAMate.D_FileDescription, "FAMate TCP Modeler Option File");
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_UniqueIdPointer, FXmlTagFAMate.D_UniqueIdPointer, "0");

                // --

                // ***
                // TCP Modeler Option Element Create
                // ***
                fXmlNodeTcm = fXmlNodeFam.appendChild(m_fXmlDocOpt.createNode(FXmlTagTCMOption.E_TCMOption));

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
                fXmlNodeTcm = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadOption(
            )
        {
            FXmlNode fXmlNodeTcm = null;

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

                fXmlNodeTcm = m_fXmlDocOpt.selectSingleNode(FXmlTagFAMate.E_FAMate + "/" + FXmlTagTCMOption.E_TCMOption);
                if (fXmlNodeTcm == null)
                {
                    createOption();
                    return;
                }

                // --

                // --
                // TCP Modeler Option Load
                // ***                                
                enabledEventsOfTcpDeviceState = (fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_EnabledEventsOfTcpDeviceState, FXmlTagTCMOption.D_EnabledEventsOfTcpDeviceState) == FBoolean.True.ToString());
                enabledEventsOfTcpDeviceError = (fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_EnabledEventsOfTcpDeviceError, FXmlTagTCMOption.D_EnabledEventsOfTcpDeviceError) == FBoolean.True.ToString());
                enabledEventsOfTcpDeviceTimeout = (fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_EnabledEventsOfTcpDeviceTimeout, FXmlTagTCMOption.D_EnabledEventsOfTcpDeviceTimeout) == FBoolean.True.ToString());
                enabledEventsOfTcpDeviceXlg = (fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_EnabledEventsOfTcpDeviceXlg, FXmlTagTCMOption.D_EnabledEventsOfTcpDeviceXlg) == FBoolean.True.ToString());
                enabledEventsOfTcpDeviceDataMessage = (fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_EnabledEventsOfTcpDeviceDataMessage, FXmlTagTCMOption.D_EnabledEventsOfTcpDeviceDataMessage) == FBoolean.True.ToString());
                enabledEventsOfHostDeviceState = (fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_EnabledEventsOfHostDeviceState, FXmlTagTCMOption.D_EnabledEventsOfHostDeviceState) == FBoolean.True.ToString());
                enabledEventsOfHostDeviceError = (fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_EnabledEventsOfHostDeviceError, FXmlTagTCMOption.D_EnabledEventsOfHostDeviceError) == FBoolean.True.ToString());
                enabledEventsOfHostDeviceVfei = (fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_EnabledEventsOfHostDeviceVfei, FXmlTagTCMOption.D_EnabledEventsOfHostDeviceVfei) == FBoolean.True.ToString());
                enabledEventsOfHostDeviceDataMessage = (fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_EnabledEventsOfHostDeviceDataMessage, FXmlTagTCMOption.D_EnabledEventsOfHostDeviceDataMessage) == FBoolean.True.ToString());
                enabledEventsOfScenario = (fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_EnabledEventsOfScenario, FXmlTagTCMOption.D_EnabledEventsOfScenario) == FBoolean.True.ToString());
                enabledEventsOfApplication = (fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_EnabledEventsOfApplication, FXmlTagTCMOption.D_EnabledEventsOfApplication) == FBoolean.True.ToString());
                // --
                logDirectory = fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_LogDirectory, FXmlTagTCMOption.D_LogDirectory);
                // --
                enabledLogOfBinary = (fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_EnabledLogOfBinary, FXmlTagTCMOption.D_EnabledLogOfBinary) == FBoolean.True.ToString());
                enabledLogOfXlg = (fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_EnabledLogOfXlg, FXmlTagTCMOption.D_EnabledLogOfXlg) == FBoolean.True.ToString());
                enabledLogOfVfei = (fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_EnabledLogOfVfei, FXmlTagTCMOption.D_EnabledLogOfVfei) == FBoolean.True.ToString());
                enabledLogOfTcp = (fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_EnabledLogOfTcp, FXmlTagTCMOption.D_EnabledLogOfTcp) == FBoolean.True.ToString());
                // --
                maxLogFileSizeOfBinary = int.Parse(fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_MaxLogFileSizeOfBinary, FXmlTagTCMOption.D_MaxLogFileSizeOfBinary));
                maxLogFileSizeOfXlg = int.Parse(fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_MaxLogFileSizeOfXlg, FXmlTagTCMOption.D_MaxLogFileSizeOfXlg));
                maxLogFileSizeOfVfei = int.Parse(fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_MaxLogFileSizeOfVfei, FXmlTagTCMOption.D_MaxLogFileSizeOfVfei));
                maxLogFileSizeOfTcp = int.Parse(fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_MaxLogFileSizeOfTcp, FXmlTagTCMOption.D_MaxLogFileSizeOfTcp));
                // --
                enabledFilterOfTcpDeviceState = (fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_EnabledFilterOfTcpDeviceState, FXmlTagTCMOption.D_EnabledFilterOfTcpDeviceState) == FBoolean.True.ToString());
                enabledFilterOfTcpDeviceError = (fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_EnabledFilterOfTcpDeviceError, FXmlTagTCMOption.D_EnabledFilterOfTcpDeviceError) == FBoolean.True.ToString());
                enabledFilterOfTcpDeviceTimeout = (fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_EnabledFilterOfTcpDeviceTimeout, FXmlTagTCMOption.D_EnabledFilterOfTcpDeviceTimeout) == FBoolean.True.ToString());
                enabledFilterOfTcpDeviceDataMessage = (fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_EnabledFilterOfTcpDeviceDataMessage, FXmlTagTCMOption.D_EnabledFilterOfTcpDeviceDataMessage) == FBoolean.True.ToString());
                enabledFilterOfHostDeviceState = (fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_EnabledFilterOfHostDeviceState, FXmlTagTCMOption.D_EnabledFilterOfHostDeviceState) == FBoolean.True.ToString());
                enabledFilterOfHostDeviceError = (fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_EnabledFilterOfHostDeviceError, FXmlTagTCMOption.D_EnabledFilterOfHostDeviceError) == FBoolean.True.ToString());
                enabledFilterOfHostDeviceDataMessage = (fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_EnabledFilterOfHostDeviceDataMessage, FXmlTagTCMOption.D_EnabledFilterOfHostDeviceDataMessage) == FBoolean.True.ToString());
                enabledFilterOfScenario = (fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_EnabledFilterOfScenario, FXmlTagTCMOption.D_EnabledFilterOfScenario) == FBoolean.True.ToString());
                enabledFilterOfApplication = (fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_EnabledFilterOfApplication, FXmlTagTCMOption.D_EnabledFilterOfApplication) == FBoolean.True.ToString());
                // --
                libRecentOpenPath = fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_LibRecentOpenPath, FXmlTagTCMOption.D_LibRecentOpenPath);
                libRecentSavePath = fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_LibRecentSavePath, FXmlTagTCMOption.D_LibRecentSavePath);
                // --
                logRecentOpenPath = fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_LogRecentOpenPath, FXmlTagTCMOption.D_LogRecentOpenPath);
                logRecentSavePath = fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_LogRecentSavePath, FXmlTagTCMOption.D_LogRecentSavePath);
                // --
                libRecentExportPath = fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_LibRecentExportPath, FXmlTagTCMOption.D_LibRecentExportPath);
                // --
                tcpBinaryTracerMaxTraceCount = int.Parse(fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_TcpBinaryTracerMaxTraceCount, FXmlTagTCMOption.D_TcpBinaryTracerMaxTraceCount));
                // --
                xlgTracerMaxTraceCount = int.Parse(fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_XlgTracerMaxTraceCount, FXmlTagTCMOption.D_XlgTracerMaxTraceCount));
                // --
                vfeiTracerMaxTraceCount = int.Parse(fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_VfeiTracerMaxTraceCount, FXmlTagTCMOption.D_VfeiTracerMaxTraceCount));
                // --
                xlgViewerRecentOpenPath = fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_XlgViewerRecentOpenPath, FXmlTagTCMOption.D_XlgViewerRecentOpenPath);
                xlgViewerRecentSavePath = fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_XlgViewerRecentSavePath, FXmlTagTCMOption.D_XlgViewerRecentSavePath);
                // --
                vfeiViewerRecentOpenPath = fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_VfeiViewerRecentOpenPath, FXmlTagTCMOption.D_VfeiViewerRecentOpenPath);
                vfeiViewerRecentSavePath = fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_VfeiViewerRecentSavePath, FXmlTagTCMOption.D_VfeiViewerRecentSavePath);
                // --
                commonFontName = fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_CommonFontName, FXmlTagTCMOption.D_CommonFontName);
                commonFontSize = float.Parse(fXmlNodeTcm.get_attrVal(FXmlTagTCMOption.A_CommonFontSize, FXmlTagTCMOption.D_CommonFontSize));

                // ***
                // Recent File Load
                // ***    
                libRecentFileList.Clear();
                foreach (FXmlNode n in fXmlNodeTcm.selectNodes(FXmlTagTCMOption.E_Recent + "[contains(@" + FXmlTagTCMOption.A_File + ",'.tsm')]"))
                {
                    libRecentFileList.Add(n.get_attrVal(FXmlTagTCMOption.A_File, FXmlTagTCMOption.D_File));
                }
                // --
                logRecentFileList.Clear();
                foreach (FXmlNode n in fXmlNodeTcm.selectNodes(FXmlTagTCMOption.E_Recent + "[not(contains(@" + FXmlTagTCMOption.A_File + ",'.tsm'))]"))
                {
                    logRecentFileList.Add(n.get_attrVal(FXmlTagTCMOption.A_File, FXmlTagTCMOption.D_File));
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeTcm = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void save(
            )
        {
            FXmlNode fXmlNodeFam = null;
            FXmlNode fXmlNodeTcm = null;
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
                // TCP Modeler Option Element set
                // ***
                fXmlNodeTcm = fXmlNodeFam.selectSingleNode(FXmlTagTCMOption.E_TCMOption);
                // --
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_EnabledEventsOfTcpDeviceState, FXmlTagTCMOption.D_EnabledEventsOfTcpDeviceState, enabledEventsOfTcpDeviceState ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_EnabledEventsOfTcpDeviceError, FXmlTagTCMOption.D_EnabledEventsOfTcpDeviceError, enabledEventsOfTcpDeviceError ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_EnabledEventsOfTcpDeviceTimeout, FXmlTagTCMOption.D_EnabledEventsOfTcpDeviceTimeout, enabledEventsOfTcpDeviceTimeout ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_EnabledEventsOfTcpDeviceXlg, FXmlTagTCMOption.D_EnabledEventsOfTcpDeviceXlg, enabledEventsOfTcpDeviceXlg ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_EnabledEventsOfTcpDeviceDataMessage, FXmlTagTCMOption.D_EnabledEventsOfTcpDeviceDataMessage, enabledEventsOfTcpDeviceDataMessage ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_EnabledEventsOfHostDeviceState, FXmlTagTCMOption.D_EnabledEventsOfHostDeviceState, enabledEventsOfHostDeviceState ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_EnabledEventsOfHostDeviceError, FXmlTagTCMOption.D_EnabledEventsOfHostDeviceError, enabledEventsOfHostDeviceError ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_EnabledEventsOfHostDeviceVfei, FXmlTagTCMOption.D_EnabledEventsOfHostDeviceVfei, enabledEventsOfHostDeviceVfei ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_EnabledEventsOfHostDeviceDataMessage, FXmlTagTCMOption.D_EnabledEventsOfHostDeviceDataMessage, enabledEventsOfHostDeviceDataMessage ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_EnabledEventsOfScenario, FXmlTagTCMOption.D_EnabledEventsOfScenario, enabledEventsOfScenario ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_EnabledEventsOfApplication, FXmlTagTCMOption.D_EnabledEventsOfApplication, enabledEventsOfApplication ? FBoolean.True.ToString() : FBoolean.False.ToString());                
                // --
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_LogDirectory, FXmlTagTCMOption.D_LogDirectory, logDirectory);
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_EnabledLogOfBinary, FXmlTagTCMOption.D_EnabledLogOfBinary, enabledLogOfBinary ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_EnabledLogOfXlg, FXmlTagTCMOption.D_EnabledLogOfXlg, enabledLogOfXlg ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_EnabledLogOfVfei, FXmlTagTCMOption.D_EnabledLogOfVfei, enabledLogOfVfei ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_EnabledLogOfTcp, FXmlTagTCMOption.D_EnabledLogOfTcp, enabledLogOfTcp ? FBoolean.True.ToString() : FBoolean.False.ToString());
                // --
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_MaxLogFileSizeOfBinary, FXmlTagTCMOption.D_MaxLogFileSizeOfBinary, maxLogFileSizeOfBinary.ToString());
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_MaxLogFileSizeOfXlg, FXmlTagTCMOption.D_MaxLogFileSizeOfXlg, maxLogFileSizeOfXlg.ToString());
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_MaxLogFileSizeOfVfei, FXmlTagTCMOption.D_MaxLogFileSizeOfVfei, maxLogFileSizeOfVfei.ToString());
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_MaxLogFileSizeOfTcp, FXmlTagTCMOption.D_MaxLogFileSizeOfTcp, maxLogFileSizeOfTcp.ToString());
                // --
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_EnabledFilterOfTcpDeviceState, FXmlTagTCMOption.D_EnabledFilterOfTcpDeviceState, enabledFilterOfTcpDeviceState ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_EnabledFilterOfTcpDeviceError, FXmlTagTCMOption.D_EnabledFilterOfTcpDeviceError, enabledFilterOfTcpDeviceError ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_EnabledFilterOfTcpDeviceTimeout, FXmlTagTCMOption.D_EnabledFilterOfTcpDeviceTimeout, enabledFilterOfTcpDeviceTimeout ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_EnabledFilterOfTcpDeviceDataMessage, FXmlTagTCMOption.D_EnabledFilterOfTcpDeviceDataMessage, enabledFilterOfTcpDeviceDataMessage ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_EnabledFilterOfHostDeviceState, FXmlTagTCMOption.D_EnabledFilterOfHostDeviceState, enabledFilterOfHostDeviceState ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_EnabledFilterOfHostDeviceError, FXmlTagTCMOption.D_EnabledFilterOfHostDeviceError, enabledFilterOfHostDeviceError ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_EnabledFilterOfHostDeviceDataMessage, FXmlTagTCMOption.D_EnabledFilterOfHostDeviceDataMessage, enabledFilterOfHostDeviceDataMessage ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_EnabledFilterOfScenario, FXmlTagTCMOption.D_EnabledFilterOfScenario, enabledFilterOfScenario ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_EnabledFilterOfApplication, FXmlTagTCMOption.D_EnabledFilterOfApplication, enabledFilterOfApplication ? FBoolean.True.ToString() : FBoolean.False.ToString());
                // --
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_LibRecentOpenPath, FXmlTagTCMOption.D_LibRecentOpenPath, libRecentOpenPath);
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_LibRecentSavePath, FXmlTagTCMOption.D_LibRecentSavePath, libRecentSavePath);
                // --
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_LogRecentOpenPath, FXmlTagTCMOption.D_LogRecentOpenPath, logRecentOpenPath);
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_LogRecentSavePath, FXmlTagTCMOption.D_LogRecentSavePath, logRecentSavePath);
                // --
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_LibRecentExportPath, FXmlTagTCMOption.D_LibRecentExportPath, libRecentExportPath);
                // --
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_TcpBinaryTracerMaxTraceCount, FXmlTagTCMOption.D_TcpBinaryTracerMaxTraceCount, tcpBinaryTracerMaxTraceCount.ToString());
                // --
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_XlgTracerMaxTraceCount, FXmlTagTCMOption.D_XlgTracerMaxTraceCount, xlgTracerMaxTraceCount.ToString());
                // --
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_VfeiTracerMaxTraceCount, FXmlTagTCMOption.D_VfeiTracerMaxTraceCount, vfeiTracerMaxTraceCount.ToString());
                // --
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_XlgViewerRecentOpenPath, FXmlTagTCMOption.D_XlgViewerRecentOpenPath, xlgViewerRecentOpenPath);
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_XlgViewerRecentSavePath, FXmlTagTCMOption.D_XlgViewerRecentSavePath, xlgViewerRecentSavePath);
                // --
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_VfeiViewerRecentOpenPath, FXmlTagTCMOption.D_VfeiViewerRecentOpenPath, vfeiViewerRecentOpenPath);
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_VfeiViewerRecentSavePath, FXmlTagTCMOption.D_VfeiViewerRecentSavePath, vfeiViewerRecentSavePath);
                // --
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_CommonFontName, FXmlTagTCMOption.D_CommonFontName, commonFontName);
                fXmlNodeTcm.set_attrVal(FXmlTagTCMOption.A_CommonFontSize, FXmlTagTCMOption.D_CommonFontSize, commonFontSize.ToString());

                // ***
                // Recent File
                // ***
                foreach (FXmlNode n in fXmlNodeTcm.selectNodes(FXmlTagTCMOption.E_Recent))
                {
                    fXmlNodeTcm.removeChild(n);
                }
                foreach (string s in libRecentFileList)
                {
                    fXmlNodeTcm.add_elem(FXmlTagTCMOption.E_Recent).
                        set_attrVal(FXmlTagTCMOption.A_File, FXmlTagTCMOption.D_File, s);
                }
                foreach (string s in logRecentFileList)
                {
                    fXmlNodeTcm.add_elem(FXmlTagTCMOption.E_Recent).
                        set_attrVal(FXmlTagTCMOption.A_File, FXmlTagTCMOption.D_File, s);
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
                fXmlNodeTcm = null;
            }
        }        

        #endregion

        //------------------------------------------------------------------------------------------------------------------------
        
    }   // Class end
}   // Namespace end
