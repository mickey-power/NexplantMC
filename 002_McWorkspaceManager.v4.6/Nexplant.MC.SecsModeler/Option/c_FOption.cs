/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FOption.cs 
--  Creator         : kitae
--  Create Date     : 2012.03.16
--  Description     : FAMate Secs Modeler Option Class 
--  History         : Created by kitae at 2012.03.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.IO;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.SecsModeler
{
    public class FOption : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSsmCore m_fSsmCore = null;
        // --        
        private FFormList m_fChildFormList = null;
        // --
        private string m_optionFileName = string.Empty;
        private FXmlDocument m_fXmlDocOpt = null;
        // --
        private bool m_enabledEventsOfSecsDeviceState = false;
        private bool m_enabledEventsOfSecsDeviceError = false;
        private bool m_enabledEventsOfSecsDeviceTimeout = false;
        private bool m_enabledEventsOfSecsDeviceData = false;
        private bool m_enabledEventsOfSecsDeviceTelnet = false;
        private bool m_enabledEventsOfSecsDeviceHandshake = false;
        private bool m_enabledEventsOfSecsDeviceControlMessage = false;
        private bool m_enabledEventsOfSecsDeviceBlock = false;
        private bool m_enabledEventsOfSecsDeviceSml = false;
        private bool m_enabledEventsOfSecsDeviceDataMessage = false;
        private bool m_enabledEventsOfHostDeviceState = false;
        private bool m_enabledEventsOfHostDeviceError = false;
        private bool m_enabledEventsOfHostDeviceVfei = false;
        private bool m_enabledEventsOfHostDeviceDataMessage = false;
        private bool m_enabledEventsOfScenario = false;
        private bool m_enabledEventsOfApplication = false;
        // --
        private string m_logDirectory = string.Empty;
        private bool m_enabledLogOfBinary = false;
        private bool m_enabledLogOfSml = false;
        private bool m_enabledLogOfVfei = false;
        private bool m_enabledLogOfSecs = false;
        // --
        private long m_maxLogFileSizeOfBinary = 0;
        private long m_maxLogFileSizeOfSml = 0;
        private long m_maxLogFileSizeOfVfei = 0;
        private long m_maxLogFileSizeOfSecs = 0;
        // --
        private bool m_enabledFilterOfSecsDeviceState = false;
        private bool m_enabledFilterOfSecsDeviceError = false;
        private bool m_enabledFilterOfSecsDeviceTimeout = false;        
        private bool m_enabledFilterOfSecsDeviceTelnet = false;
        private bool m_enabledFilterOfSecsDeviceHandshake = false;
        private bool m_enabledFilterOfSecsDeviceControlMessage = false;
        private bool m_enabledFilterOfSecsDeviceBlock = false;        
        private bool m_enabledFilterOfSecsDeviceDataMessage = false;
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
        private int m_secsBinaryTracerMaxTraceCount = 0;
        private int m_smlTracerMaxTraceCount = 0;        
        private int m_vfeiTracerMaxTraceCount = 0;
        // --
        private string m_smlViewerRecentOpenPath = string.Empty;
        private string m_smlViewerRecentSavePath = string.Empty;
        // --
        private string m_vfeiViewerRecentOpenPath = string.Empty;
        private string m_vfeiViewerRecentSavePath = string.Empty;
        // --
        // ***
        // SECS Modeler Trace & Viewer 겸용 Font Name과 Font Size
        // ***
        private string m_commonFontName = string.Empty;
        private float m_commonFontSize = 0;
        // --
        // 2018.12.27 Jeff.Kim
        private bool m_drapDropConfirm = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FOption(
            FSsmCore fSsmCore 
            )
        {
            m_fSsmCore = fSsmCore;
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
                    m_fSsmCore = null;
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

        public bool enabledEventsOfSecsDeviceState
        {
            get
            {
                try
                {
                    return m_enabledEventsOfSecsDeviceState;
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
                    m_enabledEventsOfSecsDeviceState = value;
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

        public bool enabledEventsOfSecsDeviceError
        {
            get
            {
                try
                {
                    return m_enabledEventsOfSecsDeviceError;
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
                    m_enabledEventsOfSecsDeviceError = value;
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

        public bool enabledEventsOfSecsDeviceTimeout
        {
            get
            {
                try
                {
                    return m_enabledEventsOfSecsDeviceTimeout;
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
                    m_enabledEventsOfSecsDeviceTimeout = value;
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

        public bool enabledEventsOfSecsDeviceData
        {
            get
            {
                try
                {
                    return m_enabledEventsOfSecsDeviceData;
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
                    m_enabledEventsOfSecsDeviceData = value;
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

        public bool enabledEventsOfSecsDeviceTelnet
        {
            get
            {
                try
                {
                    return m_enabledEventsOfSecsDeviceTelnet;
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
                    m_enabledEventsOfSecsDeviceTelnet = value;
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

        public bool enabledEventsOfSecsDeviceHandshake
        {
            get
            {
                try
                {
                    return m_enabledEventsOfSecsDeviceHandshake;
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
                    m_enabledEventsOfSecsDeviceHandshake = value;
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

        public bool enabledEventsOfSecsDeviceControlMessage
        {
            get
            {
                try
                {
                    return m_enabledEventsOfSecsDeviceControlMessage;
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
                    m_enabledEventsOfSecsDeviceControlMessage = value;
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

        public bool enabledEventsOfSecsDeviceBlock
        {
            get
            {
                try
                {
                    return m_enabledEventsOfSecsDeviceBlock;
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
                    m_enabledEventsOfSecsDeviceBlock = value;
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

        public bool enabledEventsOfSecsDeviceSml
        {
            get
            {
                try
                {
                    return m_enabledEventsOfSecsDeviceSml;
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
                    m_enabledEventsOfSecsDeviceSml = value;
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

        public bool enabledEventsOfSecsDeviceDataMessage
        {
            get
            {
                try
                {
                    return m_enabledEventsOfSecsDeviceDataMessage;
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
                    m_enabledEventsOfSecsDeviceDataMessage = value;
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
   
        public bool enabledFilterOfSecsDeviceState
        {
            get
            {
                try
                {
                    return m_enabledFilterOfSecsDeviceState;
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
                    m_enabledFilterOfSecsDeviceState = value;
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

        public bool enabledFilterOfSecsDeviceError
        {
            get
            {
                try
                {
                    return m_enabledFilterOfSecsDeviceError;
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
                    m_enabledFilterOfSecsDeviceError = value;
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

        public bool enabledFilterOfSecsDeviceTimeout
        {
            get
            {
                try
                {
                    return m_enabledFilterOfSecsDeviceTimeout;
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
                    m_enabledFilterOfSecsDeviceTimeout = value;
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

        public bool enabledFilterOfSecsDeviceTelnet
        {
            get
            {
                try
                {
                    return m_enabledFilterOfSecsDeviceTelnet;
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
                    m_enabledFilterOfSecsDeviceTelnet = value;
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

        public bool enabledFilterOfSecsDeviceHandshake
        {
            get
            {
                try
                {
                    return m_enabledFilterOfSecsDeviceHandshake;
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
                    m_enabledFilterOfSecsDeviceHandshake = value;
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

        public bool enabledFilterOfSecsDeviceControlMessage
        {
            get
            {
                try
                {
                    return m_enabledFilterOfSecsDeviceControlMessage;
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
                    m_enabledFilterOfSecsDeviceControlMessage = value;
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

        public bool enabledFilterOfSecsDeviceBlock
        {
            get
            {
                try
                {
                    return m_enabledFilterOfSecsDeviceBlock;
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
                    m_enabledFilterOfSecsDeviceBlock = value;
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

        public bool enabledFilterOfSecsDeviceDataMessage
        {
            get
            {
                try
                {
                    return m_enabledFilterOfSecsDeviceDataMessage;
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
                    m_enabledFilterOfSecsDeviceDataMessage = value;
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
                    m_logDirectory = Directory.Exists(value) ? value : Path.Combine(m_fSsmCore.fWsmCore.usrPath, "Log");
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

        public bool enabledLogOfSml
        {
            get
            {
                try
                {
                    return m_enabledLogOfSml;
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
                    m_enabledLogOfSml = value;
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

        public bool enabledLogOfSecs
        {
            get
            {
                try
                {
                    return m_enabledLogOfSecs;
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
                    m_enabledLogOfSecs = value;
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

        public long maxLogFileSizeOfSml
        {
            get
            {
                try
                {
                    return m_maxLogFileSizeOfSml;
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
                    m_maxLogFileSizeOfSml = value;
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

        public long maxLogFileSizeOfSecs
        {
            get
            {
                try
                {
                    return m_maxLogFileSizeOfSecs;
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
                    m_maxLogFileSizeOfSecs = value;
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
                    m_libRecentOpenPath = value;
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
                    m_libRecentSavePath = Directory.Exists(value) ? value : m_fSsmCore.fWsmCore.usrPath;
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
                    m_logRecentOpenPath = Directory.Exists(value) ? value : Path.Combine(m_fSsmCore.fWsmCore.usrPath, "Log");
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
                    m_logRecentSavePath = Directory.Exists(value) ? value : m_fSsmCore.fWsmCore.usrPath;
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
                    m_libRecentExportPath = Directory.Exists(value) ? value : m_fSsmCore.fWsmCore.usrPath;
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

        public int secsBinaryTracerMaxTraceCount
        {
            get
            {
                try
                {
                    return m_secsBinaryTracerMaxTraceCount;
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
                    m_secsBinaryTracerMaxTraceCount = value;
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

        public int smlTracerMaxTraceCount
        {
            get 
            {
                try
                {
                    return m_smlTracerMaxTraceCount;
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
                    m_smlTracerMaxTraceCount = value;
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

        public string smlViewerRecentOpenPath
        {
            get
            {
                try
                {
                    return m_smlViewerRecentOpenPath;
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
                    m_smlViewerRecentOpenPath = Directory.Exists(value) ? value : Path.Combine(m_fSsmCore.fWsmCore.usrPath, "Log");
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

        public string smlViewerRecentSavePath
        {
            get
            {
                try
                {
                    return m_smlViewerRecentSavePath;
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
                    m_smlViewerRecentSavePath = Directory.Exists(value) ? value : m_fSsmCore.fWsmCore.usrPath;
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
                    m_vfeiViewerRecentOpenPath = Directory.Exists(value) ? value : Path.Combine(m_fSsmCore.fWsmCore.usrPath, "Log");
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
                    m_vfeiViewerRecentSavePath = Directory.Exists(value) ? value : m_fSsmCore.fWsmCore.usrPath;
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
                    m_commonFontName = FXmlTagSSMOption.D_CommonFontName;
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

        //------------------------------------------------------------------------------------------------------------------------

        public bool dragDropConfirm
        {
            get
            {
                try
                {
                    return m_drapDropConfirm;
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
                    m_drapDropConfirm = value;
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
                m_optionFileName = Path.Combine(m_fSsmCore.fWsmCore.optionPath, "NexplantMCSecsModeler.cfg");
                
                // --
                
                m_fChildFormList = new FFormList(m_fSsmCore);
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

                // --

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
            FXmlNode fXmlNodeSsm = null;
            string creationTime = string.Empty;
            string dirName = string.Empty;

            try
            {
                creationTime = FDataConvert.defaultNowDateTimeToString();

                // --

                // ***
                // Default Value Set                
                // ***
                m_enabledEventsOfSecsDeviceState = true;
                m_enabledEventsOfSecsDeviceError = true;
                m_enabledEventsOfSecsDeviceTimeout = true;
                m_enabledEventsOfSecsDeviceData = false;
                m_enabledEventsOfSecsDeviceTelnet = false;
                m_enabledEventsOfSecsDeviceHandshake = false;
                m_enabledEventsOfSecsDeviceControlMessage = true;
                m_enabledEventsOfSecsDeviceBlock = false;
                m_enabledEventsOfSecsDeviceSml = false;
                m_enabledEventsOfSecsDeviceDataMessage = true;
                m_enabledEventsOfHostDeviceState = true;
                m_enabledEventsOfHostDeviceError = true;
                m_enabledEventsOfHostDeviceVfei = false;
                m_enabledEventsOfHostDeviceDataMessage = true;
                m_enabledEventsOfScenario = true;
                m_enabledEventsOfApplication = true;
                // --
                m_logDirectory = Path.Combine(m_fSsmCore.fWsmCore.usrPath, "Log");
                m_enabledLogOfBinary = false;
                m_enabledLogOfSml = false;
                m_enabledLogOfVfei = false;
                m_enabledLogOfSecs = false;
                // --
                m_maxLogFileSizeOfBinary = 5242880;
                m_maxLogFileSizeOfSml = 5242880;
                m_maxLogFileSizeOfVfei = 5242880;
                m_maxLogFileSizeOfSecs = 5242880;
                // --
                m_enabledFilterOfSecsDeviceState = true;
                m_enabledFilterOfSecsDeviceError = true;
                m_enabledFilterOfSecsDeviceTimeout = true;
                m_enabledFilterOfSecsDeviceTelnet = false;
                m_enabledFilterOfSecsDeviceHandshake = false;
                m_enabledFilterOfSecsDeviceControlMessage = true;
                m_enabledFilterOfSecsDeviceBlock = false;
                m_enabledFilterOfSecsDeviceDataMessage = true;
                m_enabledFilterOfHostDeviceState = true;
                m_enabledFilterOfHostDeviceError = true;
                m_enabledFilterOfHostDeviceDataMessage = true;
                m_enabledFilterOfScenario = true;
                m_enabledFilterOfApplication = true;
                // --
                m_libRecentOpenPath = m_fSsmCore.fWsmCore.usrPath;
                m_libRecentSavePath = m_fSsmCore.fWsmCore.usrPath;
                // --
                m_logRecentOpenPath = m_logDirectory;
                m_logRecentSavePath = m_fSsmCore.fWsmCore.usrPath;
                m_libRecentExportPath = m_fSsmCore.fWsmCore.usrPath;
                // --
                m_secsBinaryTracerMaxTraceCount = int.Parse(FXmlTagSSMOption.D_SecsBinaryTracerMaxTraceCount);
                // --
                m_smlTracerMaxTraceCount = int.Parse(FXmlTagSSMOption.D_SmlTracerMaxTraceCount);
                // --
                m_vfeiTracerMaxTraceCount = int.Parse(FXmlTagSSMOption.D_VfeiTracerMaxTraceCount);
                // --
                m_smlViewerRecentOpenPath = m_logDirectory;
                m_smlViewerRecentSavePath = m_fSsmCore.fWsmCore.usrPath;
                m_vfeiViewerRecentOpenPath = m_logDirectory;
                m_vfeiViewerRecentSavePath = m_fSsmCore.fWsmCore.usrPath;
                // --
                m_commonFontName = FXmlTagSSMOption.D_CommonFontName;
                m_commonFontSize = float.Parse(FXmlTagSSMOption.D_CommonFontSize);
                // --
                // 2018.12.27 Jeff
                // Drag & Drop Confirm
                m_drapDropConfirm = false;

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
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileDescription, FXmlTagFAMate.D_FileDescription, "Nexplant MC SECS Modeler Option File");
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_UniqueIdPointer, FXmlTagFAMate.D_UniqueIdPointer, "0");
               
                // --

                // ***
                // SECS Modeler Option Element Create
                // ***
                fXmlNodeSsm = fXmlNodeFam.appendChild(m_fXmlDocOpt.createNode(FXmlTagSSMOption.E_SSMOption));
                
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
                fXmlNodeSsm = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadOption(
            )
        {
            FXmlNode fXmlNodeSsm = null;

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

                fXmlNodeSsm = m_fXmlDocOpt.selectSingleNode(FXmlTagFAMate.E_FAMate + "/" + FXmlTagSSMOption.E_SSMOption);
                if (fXmlNodeSsm == null)
                {
                    createOption();
                    return;
                }

                // --

                // ***
                // SECS Modeler Option Load
                // ***                                
                enabledEventsOfSecsDeviceState = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledEventsOfSecsDeviceState, FXmlTagSSMOption.D_EnabledEventsOfSecsDeviceState) == FBoolean.True.ToString());
                enabledEventsOfSecsDeviceError = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledEventsOfSecsDeviceError, FXmlTagSSMOption.D_EnabledEventsOfSecsDeviceError) == FBoolean.True.ToString());
                enabledEventsOfSecsDeviceTimeout = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledEventsOfSecsDeviceTimeout, FXmlTagSSMOption.D_EnabledEventsOfSecsDeviceTimeout) == FBoolean.True.ToString());
                enabledEventsOfSecsDeviceData = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledEventsOfSecsDeviceData, FXmlTagSSMOption.D_EnabledEventsOfSecsDeviceData) == FBoolean.True.ToString());
                enabledEventsOfSecsDeviceTelnet = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledEventsOfSecsDeviceTelnet, FXmlTagSSMOption.D_EnabledEventsOfSecsDeviceTelnet) == FBoolean.True.ToString());
                enabledEventsOfSecsDeviceHandshake = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledEventsOfSecsDeviceHandshake, FXmlTagSSMOption.D_EnabledEventsOfSecsDeviceHandshake) == FBoolean.True.ToString());
                enabledEventsOfSecsDeviceControlMessage = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledEventsOfSecsDeviceControlMessage, FXmlTagSSMOption.D_EnabledEventsOfSecsDeviceControlMessage) == FBoolean.True.ToString());
                enabledEventsOfSecsDeviceBlock = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledEventsOfSecsDeviceBlock, FXmlTagSSMOption.D_EnabledEventsOfSecsDeviceBlock) == FBoolean.True.ToString());
                enabledEventsOfSecsDeviceSml = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledEventsOfSecsDeviceSml, FXmlTagSSMOption.D_EnabledEventsOfSecsDeviceSml) == FBoolean.True.ToString());
                enabledEventsOfSecsDeviceDataMessage = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledEventsOfSecsDeviceDataMessage, FXmlTagSSMOption.D_EnabledEventsOfSecsDeviceDataMessage) == FBoolean.True.ToString());
                enabledEventsOfHostDeviceState = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledEventsOfHostDeviceState, FXmlTagSSMOption.D_EnabledEventsOfHostDeviceState) == FBoolean.True.ToString());
                enabledEventsOfHostDeviceError = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledEventsOfHostDeviceError, FXmlTagSSMOption.D_EnabledEventsOfHostDeviceError) == FBoolean.True.ToString());
                enabledEventsOfHostDeviceVfei = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledEventsOfHostDeviceVfei, FXmlTagSSMOption.D_EnabledEventsOfHostDeviceVfei) == FBoolean.True.ToString());
                enabledEventsOfHostDeviceDataMessage = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledEventsOfHostDeviceDataMessage, FXmlTagSSMOption.D_EnabledEventsOfHostDeviceDataMessage) == FBoolean.True.ToString());
                enabledEventsOfScenario = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledEventsOfScenario, FXmlTagSSMOption.D_EnabledEventsOfScenario) == FBoolean.True.ToString());
                enabledEventsOfApplication = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledEventsOfApplication, FXmlTagSSMOption.D_EnabledEventsOfApplication) == FBoolean.True.ToString());
                // --
                logDirectory = fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_LogDirectory, FXmlTagSSMOption.D_LogDirectory);
                // --
                enabledLogOfBinary = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledLogOfBinary, FXmlTagSSMOption.D_EnabledLogOfBinary) == FBoolean.True.ToString());
                enabledLogOfSml = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledLogOfSml, FXmlTagSSMOption.D_EnabledLogOfSml) == FBoolean.True.ToString());
                enabledLogOfVfei = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledLogOfVfei, FXmlTagSSMOption.D_EnabledLogOfVfei) == FBoolean.True.ToString());
                enabledLogOfSecs = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledLogOfSecs, FXmlTagSSMOption.D_EnabledLogOfSecs) == FBoolean.True.ToString());
                // --
                maxLogFileSizeOfBinary = int.Parse(fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_MaxLogFileSizeOfBinary, FXmlTagSSMOption.D_MaxLogFileSizeOfBinary));
                maxLogFileSizeOfSml = int.Parse(fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_MaxLogFileSizeOfSml, FXmlTagSSMOption.D_MaxLogFileSizeOfSml));
                maxLogFileSizeOfVfei = int.Parse(fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_MaxLogFileSizeOfVfei, FXmlTagSSMOption.D_MaxLogFileSizeOfVfei));
                maxLogFileSizeOfSecs = int.Parse(fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_MaxLogFileSizeOfSecs, FXmlTagSSMOption.D_MaxLogFileSizeOfSecs));
                // --
                enabledFilterOfSecsDeviceState = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledFilterOfSecsDeviceState, FXmlTagSSMOption.D_EnabledFilterOfSecsDeviceState) == FBoolean.True.ToString());
                enabledFilterOfSecsDeviceError = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledFilterOfSecsDeviceError, FXmlTagSSMOption.D_EnabledFilterOfSecsDeviceError) == FBoolean.True.ToString());
                enabledFilterOfSecsDeviceTimeout = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledFilterOfSecsDeviceTimeout, FXmlTagSSMOption.D_EnabledFilterOfSecsDeviceTimeout) == FBoolean.True.ToString());
                enabledFilterOfSecsDeviceTelnet = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledFilterOfSecsDeviceTelnet, FXmlTagSSMOption.D_EnabledFilterOfSecsDeviceTelnet) == FBoolean.True.ToString());
                enabledFilterOfSecsDeviceHandshake = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledFilterOfSecsDeviceHandshake, FXmlTagSSMOption.D_EnabledFilterOfSecsDeviceHandshake) == FBoolean.True.ToString());
                enabledFilterOfSecsDeviceControlMessage = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledFilterOfSecsDeviceControlMessage, FXmlTagSSMOption.D_EnabledFilterOfSecsDeviceControlMessage) == FBoolean.True.ToString());
                enabledFilterOfSecsDeviceBlock = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledFilterOfSecsDeviceBlock, FXmlTagSSMOption.D_EnabledFilterOfSecsDeviceBlock) == FBoolean.True.ToString());
                enabledFilterOfSecsDeviceDataMessage = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledFilterOfSecsDeviceControlMessage, FXmlTagSSMOption.D_EnabledFilterOfSecsDeviceDataMessage) == FBoolean.True.ToString());
                enabledFilterOfHostDeviceState = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledFilterOfHostDeviceState, FXmlTagSSMOption.D_EnabledFilterOfHostDeviceState) == FBoolean.True.ToString());
                enabledFilterOfHostDeviceError = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledFilterOfHostDeviceError, FXmlTagSSMOption.D_EnabledFilterOfHostDeviceError) == FBoolean.True.ToString());
                enabledFilterOfHostDeviceDataMessage = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledFilterOfHostDeviceDataMessage, FXmlTagSSMOption.D_EnabledFilterOfHostDeviceDataMessage) == FBoolean.True.ToString());
                enabledFilterOfScenario = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledFilterOfScenario, FXmlTagSSMOption.D_EnabledFilterOfScenario) == FBoolean.True.ToString());
                enabledFilterOfApplication = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_EnabledFilterOfApplication, FXmlTagSSMOption.D_EnabledFilterOfApplication) == FBoolean.True.ToString());
                // --
                libRecentOpenPath = fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_LibRecentOpenPath, FXmlTagSSMOption.D_LibRecentOpenPath);
                libRecentSavePath = fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_LibRecentSavePath, FXmlTagSSMOption.D_LibRecentSavePath);
                // --
                logRecentOpenPath = fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_LogRecentOpenPath, FXmlTagSSMOption.D_LogRecentOpenPath);
                logRecentSavePath = fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_LogRecentSavePath, FXmlTagSSMOption.D_LogRecentSavePath);                
                // --
                libRecentExportPath = fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_LibRecentExportPath, FXmlTagSSMOption.D_LibRecentExportPath);                
                // --
                secsBinaryTracerMaxTraceCount = int.Parse(fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_SecsBinaryTracerMaxTraceCount, FXmlTagSSMOption.D_SecsBinaryTracerMaxTraceCount));
                // --
                smlTracerMaxTraceCount = int.Parse(fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_SmlTracerMaxTraceCount, FXmlTagSSMOption.D_SmlTracerMaxTraceCount));
                // --
                vfeiTracerMaxTraceCount = int.Parse(fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_VfeiTracerMaxTraceCount, FXmlTagSSMOption.D_VfeiTracerMaxTraceCount));
                // --
                smlViewerRecentOpenPath = fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_SmlViewerRecentOpenPath, FXmlTagSSMOption.D_SmlViewerRecentOpenPath);
                smlViewerRecentSavePath = fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_SmlViewerRecentSavePath, FXmlTagSSMOption.D_SmlViewerRecentSavePath);
                // --
                vfeiViewerRecentOpenPath = fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_VfeiViewerRecentOpenPath, FXmlTagSSMOption.D_VfeiViewerRecentOpenPath);
                vfeiViewerRecentSavePath = fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_VfeiViewerRecentSavePath, FXmlTagSSMOption.D_VfeiViewerRecentSavePath);
                // --
                commonFontName = fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_CommonFontName, FXmlTagSSMOption.D_CommonFontName);
                commonFontSize = float.Parse(fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_CommonFontSize, FXmlTagSSMOption.D_CommonFontSize));
                // --
                dragDropConfirm = (fXmlNodeSsm.get_attrVal(FXmlTagSSMOption.A_DrapDropConfirm, FXmlTagSSMOption.D_DrapDropConfirm) == FBoolean.True.ToString());

                // ***
                // Recent File Load
                // ***    
                libRecentFileList.Clear();
                foreach (FXmlNode n in fXmlNodeSsm.selectNodes(FXmlTagSSMOption.E_Recent + "[contains(@" + FXmlTagSSMOption.A_File + ",'.ssm')]"))
                {
                    libRecentFileList.Add(n.get_attrVal(FXmlTagSSMOption.A_File, FXmlTagSSMOption.D_File));
                }
                // --
                logRecentFileList.Clear();
                foreach (FXmlNode n in fXmlNodeSsm.selectNodes(FXmlTagSSMOption.E_Recent + "[not(contains(@" + FXmlTagSSMOption.A_File + ",'.ssm'))]"))
                {
                    logRecentFileList.Add(n.get_attrVal(FXmlTagSSMOption.A_File, FXmlTagSSMOption.D_File));
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeSsm = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void save(
            )
        {
            FXmlNode fXmlNodeFam = null;
            FXmlNode fXmlNodeSsm = null;
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
                // SECS Modeler Option Element set
                // ***
                fXmlNodeSsm = fXmlNodeFam.selectSingleNode(FXmlTagSSMOption.E_SSMOption);
                // --
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledEventsOfSecsDeviceState, FXmlTagSSMOption.D_EnabledEventsOfSecsDeviceState, enabledEventsOfSecsDeviceState ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledEventsOfSecsDeviceError, FXmlTagSSMOption.D_EnabledEventsOfSecsDeviceError, enabledEventsOfSecsDeviceError ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledEventsOfSecsDeviceTimeout, FXmlTagSSMOption.D_EnabledEventsOfSecsDeviceTimeout, enabledEventsOfSecsDeviceTimeout ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledEventsOfSecsDeviceData, FXmlTagSSMOption.D_EnabledEventsOfSecsDeviceData, enabledEventsOfSecsDeviceData ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledEventsOfSecsDeviceTelnet, FXmlTagSSMOption.D_EnabledEventsOfSecsDeviceTelnet, enabledEventsOfSecsDeviceTelnet ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledEventsOfSecsDeviceHandshake, FXmlTagSSMOption.D_EnabledEventsOfSecsDeviceHandshake, enabledEventsOfSecsDeviceHandshake ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledEventsOfSecsDeviceControlMessage, FXmlTagSSMOption.D_EnabledEventsOfSecsDeviceControlMessage, enabledEventsOfSecsDeviceControlMessage ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledEventsOfSecsDeviceBlock, FXmlTagSSMOption.D_EnabledEventsOfSecsDeviceBlock, enabledEventsOfSecsDeviceBlock ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledEventsOfSecsDeviceSml, FXmlTagSSMOption.D_EnabledEventsOfSecsDeviceSml, enabledEventsOfSecsDeviceSml ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledEventsOfSecsDeviceDataMessage, FXmlTagSSMOption.D_EnabledEventsOfSecsDeviceDataMessage, enabledEventsOfSecsDeviceDataMessage ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledEventsOfHostDeviceState, FXmlTagSSMOption.D_EnabledEventsOfHostDeviceState, enabledEventsOfHostDeviceState ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledEventsOfHostDeviceError, FXmlTagSSMOption.D_EnabledEventsOfHostDeviceError, enabledEventsOfHostDeviceError ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledEventsOfHostDeviceVfei, FXmlTagSSMOption.D_EnabledEventsOfHostDeviceVfei, enabledEventsOfHostDeviceVfei ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledEventsOfHostDeviceDataMessage, FXmlTagSSMOption.D_EnabledEventsOfHostDeviceDataMessage, enabledEventsOfHostDeviceDataMessage ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledEventsOfScenario, FXmlTagSSMOption.D_EnabledEventsOfScenario, enabledEventsOfScenario ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledEventsOfApplication, FXmlTagSSMOption.D_EnabledEventsOfApplication, enabledEventsOfApplication ? FBoolean.True.ToString() : FBoolean.False.ToString());
                // --
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_LogDirectory, FXmlTagSSMOption.D_LogDirectory, logDirectory);
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledLogOfBinary, FXmlTagSSMOption.D_EnabledLogOfBinary, enabledLogOfBinary ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledLogOfSml, FXmlTagSSMOption.D_EnabledLogOfSml, enabledLogOfSml ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledLogOfVfei, FXmlTagSSMOption.D_EnabledLogOfVfei, enabledLogOfVfei ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledLogOfSecs, FXmlTagSSMOption.D_EnabledLogOfSecs, enabledLogOfSecs ? FBoolean.True.ToString() : FBoolean.False.ToString());
                // --
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_MaxLogFileSizeOfBinary, FXmlTagSSMOption.D_MaxLogFileSizeOfBinary, maxLogFileSizeOfBinary.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_MaxLogFileSizeOfSml, FXmlTagSSMOption.D_MaxLogFileSizeOfSml, maxLogFileSizeOfSml.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_MaxLogFileSizeOfVfei, FXmlTagSSMOption.D_MaxLogFileSizeOfVfei, maxLogFileSizeOfVfei.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_MaxLogFileSizeOfSecs, FXmlTagSSMOption.D_MaxLogFileSizeOfSecs, maxLogFileSizeOfSecs.ToString()); 
                // --
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledFilterOfSecsDeviceState, FXmlTagSSMOption.D_EnabledFilterOfSecsDeviceState, enabledFilterOfSecsDeviceState ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledFilterOfSecsDeviceError, FXmlTagSSMOption.D_EnabledFilterOfSecsDeviceError, enabledFilterOfSecsDeviceError ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledFilterOfSecsDeviceTimeout, FXmlTagSSMOption.D_EnabledFilterOfSecsDeviceTimeout, enabledFilterOfSecsDeviceTimeout ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledFilterOfSecsDeviceTelnet, FXmlTagSSMOption.D_EnabledFilterOfSecsDeviceTelnet, enabledFilterOfSecsDeviceTelnet ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledFilterOfSecsDeviceHandshake, FXmlTagSSMOption.D_EnabledFilterOfSecsDeviceHandshake, enabledFilterOfSecsDeviceHandshake ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledFilterOfSecsDeviceControlMessage, FXmlTagSSMOption.D_EnabledFilterOfSecsDeviceControlMessage, enabledFilterOfSecsDeviceControlMessage ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledFilterOfSecsDeviceBlock, FXmlTagSSMOption.D_EnabledFilterOfSecsDeviceBlock, enabledFilterOfSecsDeviceBlock ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledFilterOfSecsDeviceDataMessage, FXmlTagSSMOption.D_EnabledFilterOfSecsDeviceDataMessage, enabledFilterOfSecsDeviceDataMessage ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledFilterOfHostDeviceState, FXmlTagSSMOption.D_EnabledFilterOfHostDeviceState, enabledFilterOfHostDeviceState ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledFilterOfHostDeviceError, FXmlTagSSMOption.D_EnabledFilterOfHostDeviceError, enabledFilterOfHostDeviceError ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledFilterOfHostDeviceDataMessage, FXmlTagSSMOption.D_EnabledFilterOfHostDeviceDataMessage, enabledFilterOfHostDeviceDataMessage ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledFilterOfScenario, FXmlTagSSMOption.D_EnabledFilterOfScenario, enabledFilterOfScenario ? FBoolean.True.ToString() : FBoolean.False.ToString());
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_EnabledFilterOfApplication, FXmlTagSSMOption.D_EnabledFilterOfApplication, enabledFilterOfApplication ? FBoolean.True.ToString() : FBoolean.False.ToString());
                // --
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_LibRecentOpenPath, FXmlTagSSMOption.D_LibRecentOpenPath, libRecentOpenPath);
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_LibRecentSavePath, FXmlTagSSMOption.D_LibRecentSavePath, libRecentSavePath);
                // --
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_LogRecentOpenPath, FXmlTagSSMOption.D_LogRecentOpenPath, logRecentOpenPath);
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_LogRecentSavePath, FXmlTagSSMOption.D_LogRecentSavePath, logRecentSavePath);
                // --
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_LibRecentExportPath, FXmlTagSSMOption.D_LibRecentExportPath, libRecentExportPath);
                // --
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_SecsBinaryTracerMaxTraceCount, FXmlTagSSMOption.D_SecsBinaryTracerMaxTraceCount, secsBinaryTracerMaxTraceCount.ToString());
                // --
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_SmlTracerMaxTraceCount, FXmlTagSSMOption.D_SmlTracerMaxTraceCount, smlTracerMaxTraceCount.ToString());
                // --
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_VfeiTracerMaxTraceCount, FXmlTagSSMOption.D_VfeiTracerMaxTraceCount, vfeiTracerMaxTraceCount.ToString());
                // --
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_SmlViewerRecentOpenPath, FXmlTagSSMOption.D_SmlViewerRecentOpenPath, smlViewerRecentOpenPath);
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_SmlViewerRecentSavePath, FXmlTagSSMOption.D_SmlViewerRecentSavePath, smlViewerRecentSavePath);
                // --
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_VfeiViewerRecentOpenPath, FXmlTagSSMOption.D_VfeiViewerRecentOpenPath, vfeiViewerRecentOpenPath);
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_VfeiViewerRecentSavePath, FXmlTagSSMOption.D_VfeiViewerRecentSavePath, vfeiViewerRecentSavePath);
                // --
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_CommonFontName, FXmlTagSSMOption.D_CommonFontName, commonFontName);
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_CommonFontSize, FXmlTagSSMOption.D_CommonFontSize, commonFontSize.ToString());
                // --
                fXmlNodeSsm.set_attrVal(FXmlTagSSMOption.A_DrapDropConfirm, FXmlTagSSMOption.D_DrapDropConfirm, m_drapDropConfirm ? FBoolean.True.ToString() : FBoolean.False.ToString());

                // ***
                // Recent File
                // ***
                foreach (FXmlNode n in fXmlNodeSsm.selectNodes(FXmlTagSSMOption.E_Recent))
                {
                    fXmlNodeSsm.removeChild(n);
                }
                foreach (string s in libRecentFileList)
                {
                    fXmlNodeSsm.add_elem(FXmlTagSSMOption.E_Recent).
                        set_attrVal(FXmlTagSSMOption.A_File, FXmlTagSSMOption.D_File, s);
                }
                foreach (string s in logRecentFileList)
                {
                    fXmlNodeSsm.add_elem(FXmlTagSSMOption.E_Recent).
                        set_attrVal(FXmlTagSSMOption.A_File, FXmlTagSSMOption.D_File, s);
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
                fXmlNodeSsm = null;
            }
        }        

        #endregion

        //------------------------------------------------------------------------------------------------------------------------
        
    }   // Class end
}   // Namespace end
