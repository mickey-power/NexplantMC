/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FFhmOption.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2014.08.11
--  Description     : FAMate PMS Manager Site Option Information Class 
--  History         : Created by jungyoul.moon at 2014.08.11
----------------------------------------------------------------------------------------------------------*/
using System;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.WorkspaceManager
{
    public class FFhmSiteOption : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private string m_fhsStationConnectString = string.Empty;
        private int m_fhsStationTimeout = 0;
        private string m_fhsTuneChannelId = string.Empty;
        private string m_fhsCastChannelId = string.Empty;
        private string m_fhsFtpIp = string.Empty;
        private bool m_fhsFtpUsedAnonymous = true;
        private string m_fhsFtpUser = FXmlTagWSMOption.D_FhsFtpUser;
        private string m_fhsFtpPassword = string.Empty;
        private int m_fhsHistorySearchPeriod = 0;
        private bool m_fhsNoticePopupEnabled = true;
        private string m_fhsNoticeLastTime = string.Empty;
        private bool m_fhsDesktopAlertEnabled = true;
        private bool m_fhsDesktopAlertSoundEnabled = true;
        private bool m_fhsDesktopAlertFileEnabled = true;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FFhmSiteOption(
            )
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FFhmSiteOption(
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

        public string fhsStationConnectString
        {
            get
            {
                try
                {
                    return m_fhsStationConnectString;
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
                    m_fhsStationConnectString = value;
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

        public int fhsStationTimeout
        {
            get
            {
                try
                {
                    return m_fhsStationTimeout;
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
                    m_fhsStationTimeout = value;
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

        public string fhsTuneChannelId
        {
            get
            {
                try
                {
                    return m_fhsTuneChannelId;
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
                    m_fhsTuneChannelId = value;
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

        public string fhsCastChannelId
        {
            get
            {
                try
                {
                    return m_fhsCastChannelId;
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
                    m_fhsCastChannelId = value;
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

        public string fhsFtpIp
        {
            get
            {
                try
                {
                    return m_fhsFtpIp;
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
                    m_fhsFtpIp = value;
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

        public bool fhsFtpUsedAnonymous
        {
            get
            {
                try
                {
                    return m_fhsFtpUsedAnonymous;
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
                    m_fhsFtpUsedAnonymous = value;
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

        public string fhsFtpUser
        {
            get
            {
                try
                {
                    return m_fhsFtpUser;
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
                    m_fhsFtpUser = value;
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

        public string fhsFtpPassword
        {
            get
            {
                try
                {
                    return m_fhsFtpPassword;
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
                    m_fhsFtpPassword = value;
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

        public int fhsHistorySearchPeriod
        {
            get
            {
                try
                {
                    return m_fhsHistorySearchPeriod;
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
                    m_fhsHistorySearchPeriod = value;
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

        public bool fhsNoticePopupEnabled
        {
            get
            {
                try
                {
                    return m_fhsNoticePopupEnabled;
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
                    m_fhsNoticePopupEnabled = value;
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

        public string fhsNoticeLastTime
        {
            get
            {
                try
                {
                    return m_fhsNoticeLastTime;
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
                    m_fhsNoticeLastTime = value;
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

        public bool fhsDesktopAlertEnabled
        {
            get
            {
                try
                {
                    return m_fhsDesktopAlertEnabled;
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
                    m_fhsDesktopAlertEnabled = value;
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

        public bool fhsDesktopAlertSoundEnabled
        {
            get
            {
                try
                {
                    return m_fhsDesktopAlertSoundEnabled;
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
                    m_fhsDesktopAlertSoundEnabled = value;
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

        public bool fhsDesktopAlertFileEnabled
        {
            get
            {
                try
                {
                    return m_fhsDesktopAlertFileEnabled;
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
                    m_fhsDesktopAlertFileEnabled = value;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
