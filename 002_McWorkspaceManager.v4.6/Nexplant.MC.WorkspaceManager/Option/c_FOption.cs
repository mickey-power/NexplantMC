/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FOption.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.28
--  Description     : FAMate Workspace Manager Option Class 
--  History         : Created by spike.lee at 2010.12.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using System.Collections.Generic;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.WorkspaceManager
{
    public class FOption : FIWsmOption, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FWsmCore m_fWsmCore = null;
        // --
        private string m_optionFileName = string.Empty;
        private FXmlDocument m_fXmlDocOpt = null;
        // --
        private FLanguage m_language = FLanguage.Default;
        private string m_fontName = string.Empty;
        private string m_debugLogFileSubfix = string.Empty;
        private int m_debugLogFileKeepingPeriod = 0;
        private FYesNo m_developmentToolEnabled = FYesNo.No;
        // --
        private string m_adsRecentDownloadPath = string.Empty;
        private string m_adsRecentLogDownloadPath = string.Empty;
        private string m_adsRecentExportPath = string.Empty;
        private string m_adsFontName = string.Empty;
        private float m_adsFontSize = 0;
        private string m_dcsRecentDownloadPath = string.Empty;
        private string m_dcsRecentLogDownloadPath = string.Empty;
        private string m_dcsRecentExportPath = string.Empty;
        private string m_dcsFontName = string.Empty;
        private float m_dcsFontSize = 0;
        private string m_rmsRecentDownloadPath = string.Empty;
        private string m_rmsRecentLogDownloadPath = string.Empty;
        private string m_rmsRecentExportPath = string.Empty;
        private string m_rmsFontName = string.Empty;
        private float m_rmsFontSize = 0;
        private string m_pmsRecentDownloadPath = string.Empty;
        private string m_pmsRecentLogDownloadPath = string.Empty;
        private string m_pmsRecentExportPath = string.Empty;
        private string m_pmsFontName = string.Empty;
        private float m_pmsFontSize = 0;
        private string m_fhsRecentDownloadPath = string.Empty;
        private string m_fhsRecentLogDownloadPath = string.Empty;
        private string m_fhsRecentExportPath = string.Empty;
        private string m_fhsFontName = string.Empty;
        private float m_fhsFontSize = 0;
        // --
        private bool m_checkedIdSave = false;
        // --
        private string m_user = string.Empty;
        private string m_userName = string.Empty;
        private string m_userGroup = string.Empty;
        // --
        private string m_site = string.Empty;
        // --
        private string m_factory = string.Empty;
        private string m_description = string.Empty;
        // --
        private string m_stationConnectString = string.Empty;
        private int m_stationTimeout = 0;
        private string m_tuneChannelId = string.Empty;
        private string m_castChannelId = string.Empty;
        // --
        private string m_adsStationConnectString = string.Empty;
        private int m_adsStationTimeout = 0;
        private string m_adsTuneChannelId = string.Empty;
        private string m_adsCastChannelId = string.Empty;
        private string m_adsFtpIp = string.Empty;
        private bool m_adsFtpUsedAnonymous = false;
        private string m_adsFtpUser = string.Empty;
        private string m_adsFtpPassword = string.Empty;
        private int m_adsHistorySearchPeriod = 0;
        private bool m_adsNoticePopupEnabled = true;
        private string m_adsNoticeLastTime = string.Empty;
        private bool m_adsDesktopAlertEnabled = true;
        private bool m_adsDesktopAlertSoundEnabled = true;
        private bool m_adsDesktopAlertServerEnabled = true;
        private bool m_adsDesktopAlertEapEnabled = true;
        private bool m_adsDesktopAlertDeviceEnabled = true;
        private int m_adsServerIssueMonitoringCount = 0;
        private int m_adsEapIssueMonitoringCount = 0;
        private int m_adsEquipmentIssueMonitoringCount = 0;
        private string m_adsSecsInterfaceLogFilterCaption1 = string.Empty;
        private string m_adsSecsInterfaceLogFilterSecsItem1 = string.Empty;
        private string m_adsSecsInterfaceLogFilterHostItem1 = string.Empty;
        private string m_adsSecsInterfaceLogFilterCaption2 = string.Empty;
        private string m_adsSecsInterfaceLogFilterSecsItem2 = string.Empty;
        private string m_adsSecsInterfaceLogFilterHostItem2 = string.Empty;
        // --
        private string m_dcsStationConnectString = string.Empty;
        private int m_dcsStationTimeout = 0;
        private string m_dcsTuneChannelId = string.Empty;
        private string m_dcsCastChannelId = string.Empty;
        private string m_dcsFtpIp = string.Empty;
        private bool m_dcsFtpUsedAnonymous = false;
        private string m_dcsFtpUser = string.Empty;
        private string m_dcsFtpPassword = string.Empty;
        private int m_dcsHistorySearchPeriod = 0;
        private bool m_dcsNoticePopupEnabled = true;
        private string m_dcsNoticeLastTime = string.Empty;
        // --
        private string m_rmsStationConnectString = string.Empty;
        private int m_rmsStationTimeout = 0;
        private string m_rmsTuneChannelId = string.Empty;
        private string m_rmsCastChannelId = string.Empty;
        private string m_rmsFtpIp = string.Empty;
        private bool m_rmsFtpUsedAnonymous = false;
        private string m_rmsFtpUser = string.Empty;
        private string m_rmsFtpPassword = string.Empty;
        private int m_rmsHistorySearchPeriod = 0;
        private bool m_rmsNoticePopupEnabled = true;
        private string m_rmsNoticeLastTime = string.Empty;
        private bool m_rmsDesktopAlertEnabled = true;
        private bool m_rmsDesktopAlertSoundEnabled = true;
        private bool m_rmsDesktopAlertRecipeEnabled = true;
        // --
        private string m_pmsStationConnectString = string.Empty;
        private int m_pmsStationTimeout = 0;
        private string m_pmsTuneChannelId = string.Empty;
        private string m_pmsCastChannelId = string.Empty;
        private string m_pmsFtpIp = string.Empty;
        private bool m_pmsFtpUsedAnonymous = false;
        private string m_pmsFtpUser = string.Empty;
        private string m_pmsFtpPassword = string.Empty;
        private int m_pmsHistorySearchPeriod = 0;
        private bool m_pmsNoticePopupEnabled = true;
        private string m_pmsNoticeLastTime = string.Empty;
        private bool m_pmsDesktopAlertEnabled = true;
        private bool m_pmsDesktopAlertSoundEnabled = true;
        private bool m_pmsDesktopAlertParameterEnabled = true;
        // --
        private string m_fhsStationConnectString = string.Empty;
        private int m_fhsStationTimeout = 0;
        private string m_fhsTuneChannelId = string.Empty;
        private string m_fhsCastChannelId = string.Empty;
        private string m_fhsFtpIp = string.Empty;
        private bool m_fhsFtpUsedAnonymous = false;
        private string m_fhsFtpUser = string.Empty;
        private string m_fhsFtpPassword = string.Empty;
        private int m_fhsHistorySearchPeriod = 0;
        private bool m_fhsNoticePopupEnabled = true;
        private string m_fhsNoticeLastTime = string.Empty;
        private bool m_fhsDesktopAlertEnabled = true;
        private bool m_fhsDesktopAlertSoundEnabled = true;
        private bool m_fhsDesktopAlertFileEnabled = true;
        // --
        private bool m_isLogIn = false;
        // --
        private string m_hostIP = string.Empty;
        private string m_hostName = string.Empty;
        // --
        private string m_libRecentOpenPath = string.Empty;
        private string m_libRecentSavePath = string.Empty;
        // --
        private string m_logRecentOpenPath = string.Empty;
        private string m_logRecentSavePath = string.Empty;
        // --
        private string m_defaultOptionFileName = string.Empty;
        private FXmlDocument m_fXmlDocDefaultOpt = null;


        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FOption(
            FWsmCore fWsmCore
            )
        {
            m_fWsmCore = fWsmCore;
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
                    m_fWsmCore = null;
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

        public FLanguage language
        {
            get
            {
                try
                {
                    return m_language;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FLanguage.Default;
            }

            set
            {
                try
                {
                    m_language = value;
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

        public string fontName
        {
            get
            {
                try
                {
                    return m_fontName;
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
                    m_fontName = (new System.Drawing.FontFamily(value)).Name;
                }
                catch (Exception ex)
                {
                    m_fontName = FXmlTagWSMOption.D_FontName;
                    FDebug.writeLog(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string debugLogFileSubfix
        {
            get
            {
                try
                {
                    return m_debugLogFileSubfix;
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
                    m_debugLogFileSubfix = value;
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

        public int debugLogFileKeepingPeriod
        {
            get
            {
                try
                {
                    return m_debugLogFileKeepingPeriod;
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
                    m_debugLogFileKeepingPeriod = value;
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

        public FYesNo developmentToolEnabled
        {
            get
            {
                try
                {
                    return m_developmentToolEnabled;
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
                    m_developmentToolEnabled = value;
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

        public string recentFile
        {
            set
            {
                FXmlNode fXmlNodeWmo = null;
                FXmlNode fXmlNodeRct = null;
                FXmlNodeList fXmlNodeList = null;
                string extension = string.Empty;
                string xPath = string.Empty;

                try
                {
                    fXmlNodeWmo = m_fXmlDocOpt.selectSingleNode(FXmlTagFAMate.E_FAMate + "/" + FXmlTagWSMOption.E_WSMOption);

                    // --

                    // ***
                    // Recent Generate/Modeler/Log File 목록의 동일하거나 마지막 노드 삭제
                    // ***
                    fXmlNodeRct = fXmlNodeWmo.selectSingleNode(FXmlTagWSMOption.E_Recent + "[@" + FXmlTagWSMOption.A_File + "='" + value + "']");
                    if (fXmlNodeRct == null)
                    {
                        extension = Path.GetExtension(value);
                        if (extension != ".gen" && extension != ".ssm" && extension != ".psm")
                        {
                            xPath = string.Format("{0}[not(contains(@{1},'.gen')) and not(contains(@{1},'.ssm')) and not(contains(@{1},'.psm'))]", FXmlTagWSMOption.E_Recent, FXmlTagWSMOption.A_File);
                        }
                        else
                        {
                            xPath = FXmlTagWSMOption.E_Recent + "[contains(@" + FXmlTagWSMOption.A_File + ",'" + extension + "')]";
                        }
                        fXmlNodeList = fXmlNodeWmo.selectNodes(xPath);
                        if (fXmlNodeList.count >= FConstants.RecentMaxCount)
                        {
                            fXmlNodeRct = fXmlNodeList[fXmlNodeList.count - 1];
                        }
                    }
                    if (fXmlNodeRct != null)
                    {
                        fXmlNodeWmo.removeChild(fXmlNodeRct);
                    }

                    // --

                    // ***
                    // Recent All File 목록의 처음 노드로 추가
                    // ***
                    fXmlNodeRct = m_fXmlDocOpt.createNode(FXmlTagWSMOption.E_Recent);
                    fXmlNodeRct.set_attrVal(FXmlTagWSMOption.A_File, FXmlTagWSMOption.D_File, value.ToString());
                    // --
                    if (fXmlNodeWmo.fChildNodes.count == 0)
                    {
                        fXmlNodeWmo.appendChild(fXmlNodeRct);
                    }
                    else
                    {
                        fXmlNodeWmo.insertBefore(
                            fXmlNodeRct,
                            fXmlNodeWmo.selectSingleNode(FXmlTagWSMOption.E_Recent)
                            );
                    }
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    fXmlNodeWmo = null;
                    fXmlNodeRct = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string[] recentGenFileList
        {
            get
            {
                FXmlNode fXmlNode = null;
                FXmlNodeList fXmlNodeList = null;
                string[] fileList = null;

                try
                {
                    fXmlNode = m_fXmlDocOpt.selectSingleNode(FXmlTagFAMate.E_FAMate + "/" + FXmlTagWSMOption.E_WSMOption);
                    fXmlNodeList = fXmlNode.get_elemList(
                        FXmlTagWSMOption.E_Recent + "[contains(@" + FXmlTagWSMOption.A_File + ",'.gen')]"
                        );
                    // --
                    fileList = new string[fXmlNodeList.count];
                    for (int i = 0; i < fXmlNodeList.count; i++)
                    {
                        fileList[i] = fXmlNodeList[i].get_attrVal(FXmlTagWSMOption.A_File, FXmlTagWSMOption.D_File);
                    }

                    // --

                    return fileList;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    fXmlNodeList = null;
                    fXmlNode = null;
                }
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string[] recentSecsModelerFileList
        {
            get
            {
                FXmlNode fXmlNode = null;
                FXmlNodeList fXmlNodeList = null;
                string[] fileList = null;

                try
                {
                    fXmlNode = m_fXmlDocOpt.selectSingleNode(FXmlTagFAMate.E_FAMate + "/" + FXmlTagWSMOption.E_WSMOption);
                    fXmlNodeList = fXmlNode.get_elemList(
                        FXmlTagWSMOption.E_Recent + "[contains(@" + FXmlTagWSMOption.A_File + ",'.ssm')]"
                        );
                    // --
                    fileList = new string[fXmlNodeList.count];
                    for (int i = 0; i < fXmlNodeList.count; i++)
                    {
                        fileList[i] = fXmlNodeList[i].get_attrVal(FXmlTagWSMOption.A_File, FXmlTagWSMOption.D_File);
                    }

                    // --

                    return fileList;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    fXmlNodeList = null;
                    fXmlNode = null;
                }
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string[] recentPlcModelerFileList
        {
            get
            {
                FXmlNode fXmlNode = null;
                FXmlNodeList fXmlNodeList = null;
                string[] fileList = null;

                try
                {
                    fXmlNode = m_fXmlDocOpt.selectSingleNode(FXmlTagFAMate.E_FAMate + "/" + FXmlTagWSMOption.E_WSMOption);
                    fXmlNodeList = fXmlNode.get_elemList(
                        FXmlTagWSMOption.E_Recent + "[contains(@" + FXmlTagWSMOption.A_File + ",'.psm')]"
                        );
                    // --
                    fileList = new string[fXmlNodeList.count];
                    for (int i = 0; i < fXmlNodeList.count; i++)
                    {
                        fileList[i] = fXmlNodeList[i].get_attrVal(FXmlTagWSMOption.A_File, FXmlTagWSMOption.D_File);
                    }

                    // --

                    return fileList;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    fXmlNodeList = null;
                    fXmlNode = null;
                }
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string[] recentLogFileList
        {
            get
            {
                FXmlNode fXmlNode = null;
                FXmlNodeList fXmlNodeList = null;
                string[] fileList = null;

                try
                {
                    fXmlNode = m_fXmlDocOpt.selectSingleNode(FXmlTagFAMate.E_FAMate + "/" + FXmlTagWSMOption.E_WSMOption);
                    fXmlNodeList = fXmlNode.get_elemList(
                        string.Format("{0}[not(contains(@{1},'.gen')) and not(contains(@{1},'.ssm')) and not(contains(@{1},'.psm'))]", FXmlTagWSMOption.E_Recent, FXmlTagWSMOption.A_File)
                        );
                    // --
                    fileList = new string[fXmlNodeList.count];
                    for (int i = 0; i < fXmlNodeList.count; i++)
                    {
                        fileList[i] = fXmlNodeList[i].get_attrVal(FXmlTagWSMOption.A_File, FXmlTagWSMOption.D_File);
                    }

                    // --

                    return fileList;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    fXmlNodeList = null;
                    fXmlNode = null;
                }
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string adsRecentDownloadPath
        {
            get
            {
                try
                {
                    return m_adsRecentDownloadPath;
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

            set
            {
                try
                {
                    m_adsRecentDownloadPath = value;
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

        public string adsRecentLogDownloadPath
        {
            get
            {
                try
                {
                    return m_adsRecentLogDownloadPath;
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

            set
            {
                try
                {
                    m_adsRecentLogDownloadPath = value;
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

        public string adsRecentExportPath
        {
            get
            {
                try
                {
                    return m_adsRecentExportPath;
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

            set
            {
                try
                {
                    m_adsRecentExportPath = value;
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

        public string adsFontName
        {
            get
            {
                try
                {
                    return m_adsFontName;
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
                    m_adsFontName = (new System.Drawing.FontFamily(value)).Name;
                }
                catch (Exception ex)
                {
                    m_adsFontName = FXmlTagWSMOption.D_AdsFontName;
                    FDebug.writeLog(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public float adsFontSize
        {
            get
            {
                try
                {
                    return m_adsFontSize;
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
                    m_adsFontSize = value;
                }
                catch (Exception ex)
                {
                    FDebug.writeLog(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string dcsRecentDownloadPath
        {
            get
            {
                try
                {
                    return m_dcsRecentDownloadPath;
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

            set
            {
                try
                {
                    m_dcsRecentDownloadPath = value;
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

        public string dcsRecentLogDownloadPath
        {
            get
            {
                try
                {
                    return m_dcsRecentLogDownloadPath;
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

            set
            {
                try
                {
                    m_dcsRecentLogDownloadPath = value;
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

        public string dcsRecentExportPath
        {
            get
            {
                try
                {
                    return m_dcsRecentExportPath;
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

            set
            {
                try
                {
                    m_dcsRecentExportPath = value;
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

        public string dcsFontName
        {
            get
            {
                try
                {
                    return m_dcsFontName;
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
                    m_dcsFontName = (new System.Drawing.FontFamily(value)).Name;
                }
                catch (Exception ex)
                {
                    m_dcsFontName = FXmlTagWSMOption.D_DcsFontName;
                    FDebug.writeLog(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public float dcsFontSize
        {
            get
            {
                try
                {
                    return m_dcsFontSize;
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
                    m_dcsFontSize = value;
                }
                catch (Exception ex)
                {
                    FDebug.writeLog(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string rmsRecentDownloadPath
        {
            get
            {
                try
                {
                    return m_rmsRecentDownloadPath;
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

            set
            {
                try
                {
                    m_rmsRecentDownloadPath = value;
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

        public string rmsRecentLogDownloadPath
        {
            get
            {
                try
                {
                    return m_rmsRecentLogDownloadPath;
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

            set
            {
                try
                {
                    m_rmsRecentLogDownloadPath = value;
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

        public string rmsRecentExportPath
        {
            get
            {
                try
                {
                    return m_rmsRecentExportPath;
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

            set
            {
                try
                {
                    m_rmsRecentExportPath = value;
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

        public string rmsFontName
        {
            get
            {
                try
                {
                    return m_rmsFontName;
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
                    m_rmsFontName = (new System.Drawing.FontFamily(value)).Name;
                }
                catch (Exception ex)
                {
                    m_rmsFontName = FXmlTagWSMOption.D_RmsFontName;
                    FDebug.writeLog(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public float rmsFontSize
        {
            get
            {
                try
                {
                    return m_rmsFontSize;
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
                    m_rmsFontSize = value;
                }
                catch (Exception ex)
                {
                    FDebug.writeLog(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string pmsRecentDownloadPath
        {
            get
            {
                try
                {
                    return m_pmsRecentDownloadPath;
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

            set
            {
                try
                {
                    m_pmsRecentDownloadPath = value;
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

        public string pmsRecentLogDownloadPath
        {
            get
            {
                try
                {
                    return m_pmsRecentLogDownloadPath;
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

            set
            {
                try
                {
                    m_pmsRecentLogDownloadPath = value;
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

        public string pmsRecentExportPath
        {
            get
            {
                try
                {
                    return m_pmsRecentExportPath;
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

            set
            {
                try
                {
                    m_pmsRecentExportPath = value;
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

        public string pmsFontName
        {
            get
            {
                try
                {
                    return m_pmsFontName;
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
                    m_pmsFontName = (new System.Drawing.FontFamily(value)).Name;
                }
                catch (Exception ex)
                {
                    m_fontName = FXmlTagWSMOption.D_PmsFontName;
                    FDebug.writeLog(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public float pmsFontSize
        {
            get
            {
                try
                {
                    return m_pmsFontSize;
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
                    m_pmsFontSize = value;
                }
                catch (Exception ex)
                {
                    FDebug.writeLog(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string fhsRecentDownloadPath
        {
            get
            {
                try
                {
                    return m_fhsRecentDownloadPath;
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

            set
            {
                try
                {
                    m_fhsRecentDownloadPath = value;
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

        public string fhsRecentLogDownloadPath
        {
            get
            {
                try
                {
                    return m_fhsRecentLogDownloadPath;
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

            set
            {
                try
                {
                    m_fhsRecentLogDownloadPath = value;
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

        public string fhsRecentExportPath
        {
            get
            {
                try
                {
                    return m_fhsRecentExportPath;
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

            set
            {
                try
                {
                    m_fhsRecentExportPath = value;
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

        public string fhsFontName
        {
            get
            {
                try
                {
                    return m_fhsFontName;
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
                    m_fhsFontName = (new System.Drawing.FontFamily(value)).Name;
                }
                catch (Exception ex)
                {
                    m_fontName = FXmlTagWSMOption.D_PmsFontName;
                    FDebug.writeLog(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public float fhsFontSize
        {
            get
            {
                try
                {
                    return m_fhsFontSize;
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
                    m_fhsFontSize = value;
                }
                catch (Exception ex)
                {
                    FDebug.writeLog(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool checkedIdSave
        {
            get
            {
                try
                {
                    return m_checkedIdSave;
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
                    m_checkedIdSave = value;
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
                return null;
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

        public string userName
        {
            get
            {
                try
                {
                    return m_userName;
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

            set
            {
                try
                {
                    m_userName = value;
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

        public string userGroup
        {
            get
            {
                try
                {
                    return m_userGroup;
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

            set
            {
                try
                {
                    m_userGroup = value;
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

        public string site
        {
            get
            {
                try
                {
                    return m_site;
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

            set
            {
                try
                {
                    m_site = value;
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
                return null;
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

        public string description
        {
            get
            {
                try
                {
                    return m_description;
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

            set
            {
                try
                {
                    m_description = value;
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
                return null;
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

        public string tuneChannelId
        {
            get
            {
                try
                {
                    return m_tuneChannelId;
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

            set
            {
                try
                {
                    m_tuneChannelId = value;
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

        public string castChannelId
        {
            get
            {
                try
                {
                    return m_castChannelId;
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

            set
            {
                try
                {
                    m_castChannelId = value;
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

        public string adsStationConnectString
        {
            get
            {
                try
                {
                    return m_adsStationConnectString;
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

            set
            {
                try
                {
                    m_adsStationConnectString = value;
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

        public int adsStationTimeout
        {
            get
            {
                try
                {
                    return m_adsStationTimeout;
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
                    m_adsStationTimeout = value;
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

        public string adsTuneChannelId
        {
            get
            {
                try
                {
                    return m_adsTuneChannelId;
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

            set
            {
                try
                {
                    m_adsTuneChannelId = value;
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

        public string adsCastChannelId
        {
            get
            {
                try
                {
                    return m_adsCastChannelId;
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

            set
            {
                try
                {
                    m_adsCastChannelId = value;
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

        public string adsFtpIp
        {
            get
            {
                try
                {
                    return m_adsFtpIp;
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

            set
            {
                try
                {
                    m_adsFtpIp = value;
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

        public bool adsFtpUsedAnonymous
        {
            get
            {
                try
                {
                    return m_adsFtpUsedAnonymous;
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
                    m_adsFtpUsedAnonymous = value;
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

        public string adsFtpUser
        {
            get
            {
                try
                {
                    return m_adsFtpUser;
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

            set
            {
                try
                {
                    m_adsFtpUser = value;
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

        public string adsFtpPassword
        {
            get
            {
                try
                {
                    return m_adsFtpPassword;
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

            set
            {
                try
                {
                    m_adsFtpPassword = value;
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

        public int adsHistorySearchPeriod
        {
            get
            {
                try
                {
                    return m_adsHistorySearchPeriod;
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
                    m_adsHistorySearchPeriod = value;
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

        public bool adsNoticePopupEnabled
        {
            get
            {
                try
                {
                    return m_adsNoticePopupEnabled;
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
                    m_adsNoticePopupEnabled = value;
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

        public string adsNoticeLastTime
        {
            get
            {
                try
                {
                    return m_adsNoticeLastTime;
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

            set
            {
                try
                {
                    m_adsNoticeLastTime = value;
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

        public bool adsDesktopAlertEnabled
        {
            get
            {
                try
                {
                    return m_adsDesktopAlertEnabled;
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
                    m_adsDesktopAlertEnabled = value;
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

        public bool adsDesktopAlertSoundEnabled
        {
            get
            {
                try
                {
                    return m_adsDesktopAlertSoundEnabled;
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
                    m_adsDesktopAlertSoundEnabled = value;
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

        public bool adsDesktopAlertServerEnabled
        {
            get
            {
                try
                {
                    return m_adsDesktopAlertServerEnabled;
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
                    m_adsDesktopAlertServerEnabled = value;
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

        public bool adsDesktopAlertEapEnabled
        {
            get
            {
                try
                {
                    return m_adsDesktopAlertEapEnabled;
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
                    m_adsDesktopAlertEapEnabled = value;
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

        public bool adsDesktopAlertDeviceEnabled
        {
            get
            {
                try
                {
                    return m_adsDesktopAlertDeviceEnabled;
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
                    m_adsDesktopAlertDeviceEnabled = value;
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

        public int adsServerIssueMonitoringCount
        {
            get
            {
                try
                {
                    return m_adsServerIssueMonitoringCount;
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
                    m_adsServerIssueMonitoringCount = value;
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

        public int adsEapIssueMonitoringCount
        {
            get
            {
                try
                {
                    return m_adsEapIssueMonitoringCount;
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
                    m_adsEapIssueMonitoringCount = value;
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

        public int adsEquipmentIssueMonitoringCount
        {
            get
            {
                try
                {
                    return m_adsEquipmentIssueMonitoringCount;
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
                    m_adsEquipmentIssueMonitoringCount = value;
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

        public string adsSecsInterfaceLogFilterCaption1
        {
            get
            {
                try
                {
                    return m_adsSecsInterfaceLogFilterCaption1;
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
                    m_adsSecsInterfaceLogFilterCaption1 = value;
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

        public string adsSecsInterfaceLogFilterSecsItem1
        {
            get
            {
                try
                {
                    return m_adsSecsInterfaceLogFilterSecsItem1;
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
                    m_adsSecsInterfaceLogFilterSecsItem1 = value;
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

        public string adsSecsInterfaceLogFilterHostItem1
        {
            get
            {
                try
                {
                    return m_adsSecsInterfaceLogFilterHostItem1;
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
                    m_adsSecsInterfaceLogFilterHostItem1 = value;
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

        public string adsSecsInterfaceLogFilterCaption2
        {
            get
            {
                try
                {
                    return m_adsSecsInterfaceLogFilterCaption2;
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
                    m_adsSecsInterfaceLogFilterCaption2 = value;
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

        public string adsSecsInterfaceLogFilterSecsItem2
        {
            get
            {
                try
                {
                    return m_adsSecsInterfaceLogFilterSecsItem2;
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
                    m_adsSecsInterfaceLogFilterSecsItem2 = value;
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

        public string adsSecsInterfaceLogFilterHostItem2
        {
            get
            {
                try
                {
                    return m_adsSecsInterfaceLogFilterHostItem2;
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
                    m_adsSecsInterfaceLogFilterHostItem2 = value;
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

        public string dcsStationConnectString
        {
            get
            {
                try
                {
                    return m_dcsStationConnectString;
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

            set
            {
                try
                {
                    m_dcsStationConnectString = value;
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

        public int dcsStationTimeout
        {
            get
            {
                try
                {
                    return m_dcsStationTimeout;
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
                    m_dcsStationTimeout = value;
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

        public string dcsTuneChannelId
        {
            get
            {
                try
                {
                    return m_dcsTuneChannelId;
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

            set
            {
                try
                {
                    m_dcsTuneChannelId = value;
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

        public string dcsCastChannelId
        {
            get
            {
                try
                {
                    return m_dcsCastChannelId;
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

            set
            {
                try
                {
                    m_dcsCastChannelId = value;
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

        public string dcsFtpIp
        {
            get
            {
                try
                {
                    return m_dcsFtpIp;
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

            set
            {
                try
                {
                    m_dcsFtpIp = value;
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

        public bool dcsFtpUsedAnonymous
        {
            get
            {
                try
                {
                    return m_dcsFtpUsedAnonymous;
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
                    m_dcsFtpUsedAnonymous = value;
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

        public string dcsFtpUser
        {
            get
            {
                try
                {
                    return m_dcsFtpUser;
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

            set
            {
                try
                {
                    m_dcsFtpUser = value;
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

        public string dcsFtpPassword
        {
            get
            {
                try
                {
                    return m_dcsFtpPassword;
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

            set
            {
                try
                {
                    m_dcsFtpPassword = value;
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

        public int dcsHistorySearchPeriod
        {
            get
            {
                try
                {
                    return m_dcsHistorySearchPeriod;
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
                    m_dcsHistorySearchPeriod = value;
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

        public bool dcsNoticePopupEnabled
        {
            get
            {
                try
                {
                    return m_dcsNoticePopupEnabled;
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
                    m_dcsNoticePopupEnabled = value;
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

        public string dcsNoticeLastTime
        {
            get
            {
                try
                {
                    return m_dcsNoticeLastTime;
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

            set
            {
                try
                {
                    m_dcsNoticeLastTime = value;
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

        //---------- --------------------------------------------------------------------------------------------------------------

        public string rmsStationConnectString
        {
            get
            {
                try
                {
                    return m_rmsStationConnectString;
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

            set
            {
                try
                {
                    m_rmsStationConnectString = value;
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

        public int rmsStationTimeout
        {
            get
            {
                try
                {
                    return m_rmsStationTimeout;
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
                    m_rmsStationTimeout = value;
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

        public string rmsTuneChannelId
        {
            get
            {
                try
                {
                    return m_rmsTuneChannelId;
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

            set
            {
                try
                {
                    m_rmsTuneChannelId = value;
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

        public string rmsCastChannelId
        {
            get
            {
                try
                {
                    return m_rmsCastChannelId;
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

            set
            {
                try
                {
                    m_rmsCastChannelId = value;
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

        public string rmsFtpIp
        {
            get
            {
                try
                {
                    return m_rmsFtpIp;
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

            set
            {
                try
                {
                    m_rmsFtpIp = value;
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

        public bool rmsFtpUsedAnonymous
        {
            get
            {
                try
                {
                    return m_rmsFtpUsedAnonymous;
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
                    m_rmsFtpUsedAnonymous = value;
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

        public string rmsFtpUser
        {
            get
            {
                try
                {
                    return m_rmsFtpUser;
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

            set
            {
                try
                {
                    m_rmsFtpUser = value;
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

        public string rmsFtpPassword
        {
            get
            {
                try
                {
                    return m_rmsFtpPassword;
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

            set
            {
                try
                {
                    m_rmsFtpPassword = value;
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

        public int rmsHistorySearchPeriod
        {
            get
            {
                try
                {
                    return m_rmsHistorySearchPeriod;
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
                    m_rmsHistorySearchPeriod = value;
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

        public bool rmsNoticePopupEnabled
        {
            get
            {
                try
                {
                    return m_rmsNoticePopupEnabled;
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
                    m_rmsNoticePopupEnabled = value;
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

        public string rmsNoticeLastTime
        {
            get
            {
                try
                {
                    return m_rmsNoticeLastTime;
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

            set
            {
                try
                {
                    m_rmsNoticeLastTime = value;
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

        public bool rmsDesktopAlertEnabled
        {
            get
            {
                try
                {
                    return m_rmsDesktopAlertEnabled;
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
                    m_rmsDesktopAlertEnabled = value;
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

        public bool rmsDesktopAlertSoundEnabled
        {
            get
            {
                try
                {
                    return m_rmsDesktopAlertSoundEnabled;
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
                    m_rmsDesktopAlertSoundEnabled = value;
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

        public bool rmsDesktopAlertRecipeEnabled
        {
            get
            {
                try
                {
                    return m_rmsDesktopAlertRecipeEnabled;
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
                    m_rmsDesktopAlertRecipeEnabled = value;
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

        public string pmsStationConnectString
        {
            get
            {
                try
                {
                    return m_pmsStationConnectString;
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

            set
            {
                try
                {
                    m_pmsStationConnectString = value;
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

        public int pmsStationTimeout
        {
            get
            {
                try
                {
                    return m_pmsStationTimeout;
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
                    m_pmsStationTimeout = value;
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

        public string pmsTuneChannelId
        {
            get
            {
                try
                {
                    return m_pmsTuneChannelId;
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

            set
            {
                try
                {
                    m_pmsTuneChannelId = value;
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

        public string pmsCastChannelId
        {
            get
            {
                try
                {
                    return m_pmsCastChannelId;
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

            set
            {
                try
                {
                    m_pmsCastChannelId = value;
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

        public string pmsFtpIp
        {
            get
            {
                try
                {
                    return m_pmsFtpIp;
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

            set
            {
                try
                {
                    m_pmsFtpIp = value;
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

        public bool pmsFtpUsedAnonymous
        {
            get
            {
                try
                {
                    return m_pmsFtpUsedAnonymous;
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
                    m_pmsFtpUsedAnonymous = value;
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

        public string pmsFtpUser
        {
            get
            {
                try
                {
                    return m_pmsFtpUser;
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

            set
            {
                try
                {
                    m_pmsFtpUser = value;
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

        public string pmsFtpPassword
        {
            get
            {
                try
                {
                    return m_pmsFtpPassword;
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

            set
            {
                try
                {
                    m_pmsFtpPassword = value;
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

        public int pmsHistorySearchPeriod
        {
            get
            {
                try
                {
                    return m_pmsHistorySearchPeriod;
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
                    m_pmsHistorySearchPeriod = value;
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

        public bool pmsNoticePopupEnabled
        {
            get
            {
                try
                {
                    return m_pmsNoticePopupEnabled;
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
                    m_pmsNoticePopupEnabled = value;
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

        public string pmsNoticeLastTime
        {
            get
            {
                try
                {
                    return m_pmsNoticeLastTime;
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

            set
            {
                try
                {
                    m_pmsNoticeLastTime = value;
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

        public bool pmsDesktopAlertEnabled
        {
            get
            {
                try
                {
                    return m_pmsDesktopAlertEnabled;
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
                    m_pmsDesktopAlertEnabled = value;
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

        public bool pmsDesktopAlertSoundEnabled
        {
            get
            {
                try
                {
                    return m_pmsDesktopAlertSoundEnabled;
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
                    m_pmsDesktopAlertSoundEnabled = value;
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

        public bool pmsDesktopAlertParameterEnabled
        {
            get
            {
                try
                {
                    return m_pmsDesktopAlertParameterEnabled;
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
                    m_pmsDesktopAlertParameterEnabled = value;
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
                return null;
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
                return null;
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
                return null;
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
                return null;
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
                return false;
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
                return null;
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
                return null;
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
                return null;
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

        //------------------------------------------------------------------------------------------------------------------------

        public bool isLogIn
        {
            get
            {
                try
                {
                    return m_isLogIn;
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
                    m_isLogIn = value;
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

        public string hostIP
        {
            get
            {
                try
                {
                    return m_hostIP;
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
                    m_hostIP = value;
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

        public string hostName
        {
            get
            {
                try
                {
                    return m_hostName;
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
                    m_hostName = value;
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

        public FWsmSiteOption[] fSiteOptionList
        {
            get
            {
                FCrypt fCrypt = null;
                List<FWsmSiteOption> fWsmOptionList = null;
                FWsmSiteOption fWsmOption = null;
                FXmlNodeList fXmlNodeSopList = null;
                string xpath = string.Empty;

                try
                {
                    fCrypt = new FCrypt();

                    // --

                    xpath =
                        FXmlTagFAMate.E_FAMate +
                        "/" + FXmlTagWSMOption.E_WSMSiteOption +
                        "/" + FXmlTagWSMOption.E_SiteOptionList +
                        "/" + FXmlTagWSMOption.E_SiteOption;
                    // --
                    fXmlNodeSopList = m_fXmlDocOpt.selectNodes(xpath);

                    // --

                    fWsmOptionList = new List<FWsmSiteOption>();

                    // --

                    foreach (FXmlNode fXmlNodeSop in fXmlNodeSopList)
                    {
                        fWsmOption = new FWsmSiteOption();

                        // --

                        fWsmOption.site = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_Site, FXmlTagWSMOption.D_Site);
                        // --
                        fWsmOption.factory = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_Factory, FXmlTagWSMOption.D_Factory);
                        fWsmOption.description = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_Description, FXmlTagWSMOption.D_Description);
                        // --
                        fWsmOption.stationConnectString = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_StationConnectString, FXmlTagWSMOption.D_StationConnectString);
                        fWsmOption.stationTimeout = int.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_StationTimeout, FXmlTagWSMOption.D_StationTimeout));
                        fWsmOption.tuneChannelId = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_TuneChannelId, FXmlTagWSMOption.D_TuneChannelId);
                        fWsmOption.castChannelId = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_CastChannelId, FXmlTagWSMOption.D_CastChannelId);
                        // --
                        fWsmOption.fAdmOption = new FAdmSiteOption();
                        fWsmOption.fAdmOption.adsStationConnectString = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_AdsStationConnectString, FXmlTagWSMOption.D_AdsStationConnectString);
                        fWsmOption.fAdmOption.adsStationTimeout = int.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_AdsStationTimeout, FXmlTagWSMOption.D_AdsStationTimeout));
                        fWsmOption.fAdmOption.adsTuneChannelId = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_AdsTuneChannelId, FXmlTagWSMOption.D_AdsTuneChannelId);
                        fWsmOption.fAdmOption.adsCastChannelId = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_AdsCastChannelId, FXmlTagWSMOption.D_AdsCastChannelId);
                        fWsmOption.fAdmOption.adsFtpIp = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_AdsFtpIp, FXmlTagWSMOption.D_AdsFtpIp);
                        fWsmOption.fAdmOption.adsFtpUsedAnonymous = Boolean.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_AdsFtpUsedAnonymous, FXmlTagWSMOption.D_AdsFtpUsedAnonymous));
                        fWsmOption.fAdmOption.adsFtpUser = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_AdsFtpUser, FXmlTagWSMOption.D_AdsFtpUser);
                        fWsmOption.fAdmOption.adsFtpPassword = fCrypt.decrypt2(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_AdsFtpPassword, FXmlTagWSMOption.D_AdsFtpPassword));
                        fWsmOption.fAdmOption.adsHistorySearchPeriod = int.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_AdsHistorySearchPeriod, FXmlTagWSMOption.D_AdsHistorySearchPeriod));
                        fWsmOption.fAdmOption.adsNoticePopupEnabled = Boolean.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_AdsNoticePopupEnabled, FXmlTagWSMOption.D_AdsNoticePopupEnabled));
                        fWsmOption.fAdmOption.adsNoticeLastTime = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_AdsNoticeLastTime, FXmlTagWSMOption.D_AdsNoticeLastTime);
                        fWsmOption.fAdmOption.adsDesktopAlertEnabled = Boolean.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_AdsDesktopAlertEnabled, FXmlTagWSMOption.D_AdsDesktopAlertEnabled));
                        fWsmOption.fAdmOption.adsDesktopAlertSoundEnabled = Boolean.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_AdsDesktopAlertSoundEnabled, FXmlTagWSMOption.D_AdsDesktopAlertSoundEnabled));
                        fWsmOption.fAdmOption.adsDesktopAlertServerEnabled = Boolean.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_AdsDesktopAlertServerEnabled, FXmlTagWSMOption.D_AdsDesktopAlertServerEnabled));
                        fWsmOption.fAdmOption.adsDesktopAlertEapEnabled = Boolean.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_AdsDesktopAlertEapEnabled, FXmlTagWSMOption.D_AdsDesktopAlertEapEnabled));
                        fWsmOption.fAdmOption.adsDesktopAlertDeviceEnabled = Boolean.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_AdsDesktopAlertDeviceEnabled, FXmlTagWSMOption.D_AdsDesktopAlertDeviceEnabled));
                        fWsmOption.fAdmOption.adsServerIssueMonitoringCount = int.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_AdsServerIssueMonitoringCount, FXmlTagWSMOption.D_AdsServerIssueMonitoringCount));
                        fWsmOption.fAdmOption.adsEapIssueMonitoringCount = int.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_AdsEapIssueMonitoringCount, FXmlTagWSMOption.D_AdsEapIssueMonitoringCount));
                        fWsmOption.fAdmOption.adsEquipmentIssueMonitoringCount = int.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_AdsEquipmentIssueMonitoringCount, FXmlTagWSMOption.D_AdsEquipmentIssueMonitoringCount));
                        fWsmOption.fAdmOption.adsSecsInterfaceLogFilterCaption1 = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_AdsSecsInterfaceLogFilterCaption1, FXmlTagWSMOption.D_AdsSecsInterfaceLogFilterCaption1);
                        fWsmOption.fAdmOption.adsSecsInterfaceLogFilterSecsItem1 = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_AdsSecsInterfaceLogFilterSecsItem1, FXmlTagWSMOption.D_AdsSecsInterfaceLogFilterSecsItem1);
                        fWsmOption.fAdmOption.adsSecsInterfaceLogFilterHostItem1 = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_AdsSecsInterfaceLogFilterHostItem1, FXmlTagWSMOption.D_AdsSecsInterfaceLogFilterHostItem1);
                        fWsmOption.fAdmOption.adsSecsInterfaceLogFilterCaption2 = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_AdsSecsInterfaceLogFilterCaption2, FXmlTagWSMOption.D_AdsSecsInterfaceLogFilterCaption2);
                        fWsmOption.fAdmOption.adsSecsInterfaceLogFilterSecsItem2 = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_AdsSecsInterfaceLogFilterSecsItem2, FXmlTagWSMOption.D_AdsSecsInterfaceLogFilterSecsItem2);
                        fWsmOption.fAdmOption.adsSecsInterfaceLogFilterHostItem2 = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_AdsSecsInterfaceLogFilterHostItem2, FXmlTagWSMOption.D_AdsSecsInterfaceLogFilterHostItem2);
                        // --
                        fWsmOption.fDcmOption = new FDcmSiteOption();
                        fWsmOption.fDcmOption.dcsStationConnectString = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_DcsStationConnectString, FXmlTagWSMOption.D_DcsStationConnectString);
                        fWsmOption.fDcmOption.dcsStationTimeout = int.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_DcsStationTimeout, FXmlTagWSMOption.D_DcsStationTimeout));
                        fWsmOption.fDcmOption.dcsTuneChannelId = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_DcsTuneChannelId, FXmlTagWSMOption.D_DcsTuneChannelId);
                        fWsmOption.fDcmOption.dcsCastChannelId = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_DcsCastChannelId, FXmlTagWSMOption.D_DcsCastChannelId);
                        fWsmOption.fDcmOption.dcsFtpIp = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_DcsFtpIp, FXmlTagWSMOption.D_DcsFtpIp);
                        fWsmOption.fDcmOption.dcsFtpUsedAnonymous = Boolean.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_DcsFtpUsedAnonymous, FXmlTagWSMOption.D_DcsFtpUsedAnonymous));
                        fWsmOption.fDcmOption.dcsFtpUser = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_DcsFtpUser, FXmlTagWSMOption.D_DcsFtpUser);
                        fWsmOption.fDcmOption.dcsFtpPassword = fCrypt.decrypt2(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_DcsFtpPassword, FXmlTagWSMOption.D_DcsFtpPassword));
                        fWsmOption.fDcmOption.dcsHistorySearchPeriod = int.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_DcsHistorySearchPeriod, FXmlTagWSMOption.D_DcsHistorySearchPeriod));
                        fWsmOption.fDcmOption.dcsNoticePopupEnabled = Boolean.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_DcsNoticePopupEnabled, FXmlTagWSMOption.D_DcsNoticePopupEnabled));
                        fWsmOption.fDcmOption.dcsNoticeLastTime = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_DcsNoticeLastTime, FXmlTagWSMOption.D_DcsNoticeLastTime);
                        // --
                        fWsmOption.fRmmOption = new FRmmSiteOption();
                        fWsmOption.fRmmOption.rmsStationConnectString = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_RmsStationConnectString, FXmlTagWSMOption.D_RmsStationConnectString);
                        fWsmOption.fRmmOption.rmsStationTimeout = int.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_RmsStationTimeout, FXmlTagWSMOption.D_RmsStationTimeout));
                        fWsmOption.fRmmOption.rmsTuneChannelId = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_RmsTuneChannelId, FXmlTagWSMOption.D_RmsTuneChannelId);
                        fWsmOption.fRmmOption.rmsCastChannelId = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_RmsCastChannelId, FXmlTagWSMOption.D_RmsCastChannelId);
                        fWsmOption.fRmmOption.rmsFtpIp = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_RmsFtpIp, FXmlTagWSMOption.D_RmsFtpIp);
                        fWsmOption.fRmmOption.rmsFtpUsedAnonymous = Boolean.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_RmsFtpUsedAnonymous, FXmlTagWSMOption.D_RmsFtpUsedAnonymous));
                        fWsmOption.fRmmOption.rmsFtpUser = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_RmsFtpUser, FXmlTagWSMOption.D_RmsFtpUser);
                        fWsmOption.fRmmOption.rmsFtpPassword = fCrypt.decrypt2(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_RmsFtpPassword, FXmlTagWSMOption.D_RmsFtpPassword));
                        fWsmOption.fRmmOption.rmsHistorySearchPeriod = int.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_RmsHistorySearchPeriod, FXmlTagWSMOption.D_RmsHistorySearchPeriod));
                        fWsmOption.fRmmOption.rmsNoticePopupEnabled = Boolean.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_RmsNoticePopupEnabled, FXmlTagWSMOption.D_RmsNoticePopupEnabled));
                        fWsmOption.fRmmOption.rmsNoticeLastTime = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_RmsNoticeLastTime, FXmlTagWSMOption.D_RmsNoticeLastTime);
                        fWsmOption.fRmmOption.rmsDesktopAlertEnabled = Boolean.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_RmsDesktopAlertEnabled, FXmlTagWSMOption.D_RmsDesktopAlertEnabled));
                        fWsmOption.fRmmOption.rmsDesktopAlertSoundEnabled = Boolean.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_RmsDesktopAlertSoundEnabled, FXmlTagWSMOption.D_RmsDesktopAlertSoundEnabled));
                        fWsmOption.fRmmOption.rmsDesktopAlertRecipeEnabled = Boolean.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_RmsDesktopAlertRecipeEnabled, FXmlTagWSMOption.D_RmsDesktopAlertRecipeEnabled));
                        // --
                        fWsmOption.fPmmOption = new FPmmSiteOption();
                        fWsmOption.fPmmOption.pmsStationConnectString = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_PmsStationConnectString, FXmlTagWSMOption.D_PmsStationConnectString);
                        fWsmOption.fPmmOption.pmsStationTimeout = int.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_PmsStationTimeout, FXmlTagWSMOption.D_PmsStationTimeout));
                        fWsmOption.fPmmOption.pmsTuneChannelId = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_PmsTuneChannelId, FXmlTagWSMOption.D_PmsTuneChannelId);
                        fWsmOption.fPmmOption.pmsCastChannelId = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_PmsCastChannelId, FXmlTagWSMOption.D_PmsCastChannelId);
                        fWsmOption.fPmmOption.pmsFtpIp = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_PmsFtpIp, FXmlTagWSMOption.D_PmsFtpIp);
                        fWsmOption.fPmmOption.pmsFtpUsedAnonymous = Boolean.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_PmsFtpUsedAnonymous, FXmlTagWSMOption.D_PmsFtpUsedAnonymous));
                        fWsmOption.fPmmOption.pmsFtpUser = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_PmsFtpUser, FXmlTagWSMOption.D_PmsFtpUser);
                        fWsmOption.fPmmOption.pmsFtpPassword = fCrypt.decrypt2(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_PmsFtpPassword, FXmlTagWSMOption.D_PmsFtpPassword));
                        fWsmOption.fPmmOption.pmsHistorySearchPeriod = int.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_PmsHistorySearchPeriod, FXmlTagWSMOption.D_PmsHistorySearchPeriod));
                        fWsmOption.fPmmOption.pmsNoticePopupEnabled = Boolean.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_PmsNoticePopupEnabled, FXmlTagWSMOption.D_PmsNoticePopupEnabled));
                        fWsmOption.fPmmOption.pmsNoticeLastTime = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_PmsNoticeLastTime, FXmlTagWSMOption.D_PmsNoticeLastTime);
                        fWsmOption.fPmmOption.pmsDesktopAlertEnabled = Boolean.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_PmsDesktopAlertEnabled, FXmlTagWSMOption.D_PmsDesktopAlertEnabled));
                        fWsmOption.fPmmOption.pmsDesktopAlertSoundEnabled = Boolean.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_PmsDesktopAlertSoundEnabled, FXmlTagWSMOption.D_PmsDesktopAlertSoundEnabled));
                        fWsmOption.fPmmOption.pmsDesktopAlertParameterEnabled = Boolean.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_PmsDesktopAlertParameterEnabled, FXmlTagWSMOption.D_PmsDesktopAlertParameterEnabled));
                        // --
                        fWsmOption.fFhmOption = new FFhmSiteOption();
                        fWsmOption.fFhmOption.fhsStationConnectString = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_FhsStationConnectString, FXmlTagWSMOption.D_FhsStationConnectString);
                        fWsmOption.fFhmOption.fhsStationTimeout = int.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_FhsStationTimeout, FXmlTagWSMOption.D_FhsStationTimeout));
                        fWsmOption.fFhmOption.fhsTuneChannelId = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_FhsTuneChannelId, FXmlTagWSMOption.D_FhsTuneChannelId);
                        fWsmOption.fFhmOption.fhsCastChannelId = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_FhsCastChannelId, FXmlTagWSMOption.D_FhsCastChannelId);
                        fWsmOption.fFhmOption.fhsFtpIp = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_FhsFtpIp, FXmlTagWSMOption.D_FhsFtpIp);
                        fWsmOption.fFhmOption.fhsFtpUsedAnonymous = Boolean.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_FhsFtpUsedAnonymous, FXmlTagWSMOption.D_FhsFtpUsedAnonymous));
                        fWsmOption.fFhmOption.fhsFtpUser = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_FhsFtpUser, FXmlTagWSMOption.D_FhsFtpUser);
                        fWsmOption.fFhmOption.fhsFtpPassword = fCrypt.decrypt2(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_FhsFtpPassword, FXmlTagWSMOption.D_FhsFtpPassword));
                        fWsmOption.fFhmOption.fhsHistorySearchPeriod = int.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_FhsHistorySearchPeriod, FXmlTagWSMOption.D_FhsHistorySearchPeriod));
                        fWsmOption.fFhmOption.fhsNoticePopupEnabled = Boolean.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_FhsNoticePopupEnabled, FXmlTagWSMOption.D_FhsNoticePopupEnabled));
                        fWsmOption.fFhmOption.fhsNoticeLastTime = fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_FhsNoticeLastTime, FXmlTagWSMOption.D_FhsNoticeLastTime);
                        fWsmOption.fFhmOption.fhsDesktopAlertEnabled = Boolean.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_FhsDesktopAlertEnabled, FXmlTagWSMOption.D_FhsDesktopAlertEnabled));
                        fWsmOption.fFhmOption.fhsDesktopAlertSoundEnabled = Boolean.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_FhsDesktopAlertSoundEnabled, FXmlTagWSMOption.D_FhsDesktopAlertSoundEnabled));
                        fWsmOption.fFhmOption.fhsDesktopAlertFileEnabled = Boolean.Parse(fXmlNodeSop.get_attrVal(FXmlTagWSMOption.A_FhsDesktopAlertFileEnabled, FXmlTagWSMOption.D_FhsDesktopAlertFileEnabled));
                        // --

                        fWsmOptionList.Add(fWsmOption);
                    }

                    // --

                    return fWsmOptionList.ToArray();
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    if (fCrypt != null)
                    {
                        fCrypt.Dispose();
                        fCrypt = null;
                    }
                    fWsmOptionList = null;
                    fWsmOption = null;
                    fXmlNodeSopList = null;
                }
                return null;
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
                m_optionFileName = m_fWsmCore.optionPath + "\\NexplantMCWorkspaceManager.cfg";

                // --

                if (!File.Exists(m_optionFileName))
                {
                    copyOption();
                    
                }
                loadOption();
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

                if (m_fXmlDocDefaultOpt != null)
                {
                    m_fXmlDocDefaultOpt.Dispose();
                    m_fXmlDocDefaultOpt = null;
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
            FXmlNode fXmlNodeWmo = null;
            FXmlNode fXmlNodeWso = null;
            FXmlNode fXmlNodeMol = null;
            FXmlNode fXmlNodeAmo = null;
            FXmlNode fXmlNodeDmo = null;
            FXmlNode fXmlNodeRmo = null;
            FXmlNode fXmlNodePmo = null;
            FXmlNode fXmlNodeFmo = null;
            FXmlNode fXmlNodeRso = null;
            FXmlNode fXmlNodeSol = null;
            string creationTime = string.Empty;
            string dirName = string.Empty;

            try
            {
                creationTime = FDataConvert.defaultNowDateTimeToString();

                // --

                // ***
                // Workspace Option Default Value Set             
                // ***
                m_language = (FLanguage)Enum.Parse(typeof(FLanguage), FXmlTagWSMOption.D_Language);
                m_fontName = FXmlTagWSMOption.D_FontName;
                m_debugLogFileSubfix = FXmlTagWSMOption.D_DebugLogFileSubfix;
                m_debugLogFileKeepingPeriod = int.Parse(FXmlTagWSMOption.D_DebugLogFileKeepingPeriod);
                m_developmentToolEnabled = (FYesNo)Enum.Parse(typeof(FYesNo), FXmlTagWSMOption.D_DevelopmentToolEnabled);

                // --

                // ***
                // Workspace Site Option Default Value Set
                // ***
                m_adsRecentDownloadPath = FXmlTagWSMOption.D_AdsRecentDownloadPath;
                m_adsRecentLogDownloadPath = FXmlTagWSMOption.D_AdsRecentLogDownloadPath;
                m_adsRecentExportPath = FXmlTagWSMOption.D_AdsRecentExportPath;
                m_adsFontName = FXmlTagWSMOption.D_AdsFontName;
                // --
                m_site = "";
                m_factory = "";
                m_description = "";
                // --
                m_stationConnectString = "";
                m_stationTimeout = int.Parse(FXmlTagWSMOption.D_StationTimeout);
                m_tuneChannelId = FXmlTagWSMOption.D_TuneChannelId;
                m_castChannelId = FXmlTagWSMOption.D_CastChannelId;
                // --
                m_adsStationConnectString = "";
                m_adsStationTimeout = int.Parse(FXmlTagWSMOption.D_AdsStationTimeout);
                m_adsTuneChannelId = FXmlTagWSMOption.D_AdsTuneChannelId;
                m_adsCastChannelId = FXmlTagWSMOption.D_AdsCastChannelId;
                m_adsFtpIp = "";
                m_adsFtpUsedAnonymous = Boolean.Parse(FXmlTagWSMOption.D_AdsFtpUsedAnonymous); //Boolean.Parse("False");
                m_adsFtpUser = FXmlTagWSMOption.D_AdsFtpUser; //"appadmin";
                m_adsFtpPassword = FXmlTagWSMOption.D_AdsFtpPassword; //"APPadmin!@";
                m_adsHistorySearchPeriod = int.Parse(FXmlTagWSMOption.D_AdsHistorySearchPeriod);
                m_adsNoticePopupEnabled = Boolean.Parse(FXmlTagWSMOption.D_AdsNoticePopupEnabled);
                m_adsNoticeLastTime = FXmlTagWSMOption.D_AdsNoticeLastTime;
                m_adsDesktopAlertEnabled = Boolean.Parse(FXmlTagWSMOption.D_AdsDesktopAlertEnabled);
                m_adsDesktopAlertSoundEnabled = Boolean.Parse(FXmlTagWSMOption.D_AdsDesktopAlertSoundEnabled);
                m_adsDesktopAlertServerEnabled = Boolean.Parse(FXmlTagWSMOption.D_AdsDesktopAlertServerEnabled);
                m_adsDesktopAlertEapEnabled = Boolean.Parse(FXmlTagWSMOption.D_AdsDesktopAlertEapEnabled);
                m_adsDesktopAlertDeviceEnabled = Boolean.Parse(FXmlTagWSMOption.D_AdsDesktopAlertDeviceEnabled);
                m_adsServerIssueMonitoringCount = int.Parse(FXmlTagWSMOption.D_AdsServerIssueMonitoringCount);
                m_adsEapIssueMonitoringCount = int.Parse(FXmlTagWSMOption.D_AdsEapIssueMonitoringCount);
                m_adsEquipmentIssueMonitoringCount = int.Parse(FXmlTagWSMOption.D_AdsEquipmentIssueMonitoringCount);
                m_adsSecsInterfaceLogFilterCaption1 = "Equipment";
                m_adsSecsInterfaceLogFilterSecsItem1 = "EQPID";
                m_adsSecsInterfaceLogFilterHostItem1 = "RES_ID";
                m_adsSecsInterfaceLogFilterCaption2 = "CEID";
                m_adsSecsInterfaceLogFilterSecsItem2 = "CEID";
                m_adsSecsInterfaceLogFilterHostItem2 = "CEID";

                // --

                // ***
                // Option XML Document Create
                // ***                
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
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileVersion, FXmlTagFAMate.D_FileVersion, "4.6.1.1");
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileCreationTime, FXmlTagFAMate.D_FileCreationTime, creationTime);
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileUpdateTime, FXmlTagFAMate.D_FileUpdateTime, creationTime);
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileDescription, FXmlTagFAMate.D_FileDescription, "NexplantMC Workspace Manager Option File");
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_UniqueIdPointer, FXmlTagFAMate.D_UniqueIdPointer, "0");

                // --

                // ***
                // Workspace Manager Option Element Create
                // ***
                fXmlNodeWmo = fXmlNodeFam.appendChild(m_fXmlDocOpt.createNode(FXmlTagWSMOption.E_WSMOption));

                // --

                // ***
                // Workspace Manager Site Option Element Create
                // ***
                fXmlNodeWso = fXmlNodeFam.appendChild(m_fXmlDocOpt.createNode(FXmlTagWSMOption.E_WSMSiteOption));

                // --

                // ***
                // Manager Option List Element Create
                // ***
                fXmlNodeMol = fXmlNodeWso.appendChild(m_fXmlDocOpt.createNode(FXmlTagWSMOption.E_ManagerOptionList));

                // --

                // ***
                // Admin/DCS/PMS/RMS/FHS Manager Option Element Create
                // ***
                fXmlNodeAmo = fXmlNodeMol.appendChild(m_fXmlDocOpt.createNode(FXmlTagWSMOption.E_AdsManagerOption));
                fXmlNodeDmo = fXmlNodeMol.appendChild(m_fXmlDocOpt.createNode(FXmlTagWSMOption.E_DcsManagerOption));
                fXmlNodeRmo = fXmlNodeMol.appendChild(m_fXmlDocOpt.createNode(FXmlTagWSMOption.E_RmsManagerOption));
                fXmlNodePmo = fXmlNodeMol.appendChild(m_fXmlDocOpt.createNode(FXmlTagWSMOption.E_PmsManagerOption));
                fXmlNodeFmo = fXmlNodeMol.appendChild(m_fXmlDocOpt.createNode(FXmlTagWSMOption.E_FhsManagerOption));

                // --

                // ***
                // Recent Site Option Element Create
                // ***
                fXmlNodeRso = fXmlNodeWso.appendChild(m_fXmlDocOpt.createNode(FXmlTagWSMOption.E_RecentSiteOption));

                // --

                // ***
                // Site Option List Element Create
                // ***
                fXmlNodeSol = fXmlNodeWso.appendChild(m_fXmlDocOpt.createNode(FXmlTagWSMOption.E_SiteOptionList));

                // --

                // ***
                // Create Default Site Option
                // ***
                createSiteOption(fXmlNodeSol);

                // --

                // ***
                // Option Save
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
                fXmlNodeWmo = null;
                fXmlNodeWso = null;
                fXmlNodeMol = null;
                fXmlNodeAmo = null;
                fXmlNodeDmo = null;
                fXmlNodeRmo = null;
                fXmlNodePmo = null;
                fXmlNodeFmo = null;
                fXmlNodeRso = null;
                fXmlNodeSol = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void createSiteOption(
            FXmlNode fXmlNodeSol
            )
        {
            FCrypt fCrypt = null;
            FXmlNode fXmlNodeSop = null;

            try
            {
                fCrypt = new FCrypt();

                // --

                // ***
                // Miracom DEV Site Option Element Create
                // ***
                fXmlNodeSop = fXmlNodeSol.appendChild(m_fXmlDocOpt.createNode(FXmlTagWSMOption.E_SiteOption));
                // --
                
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_Site, FXmlTagWSMOption.D_Site, fXmlNodeSol.get_attrVal(FXmlTagWSMOption.A_Site));
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_Factory, FXmlTagWSMOption.D_Factory, fXmlNodeSol.get_attrVal(FXmlTagWSMOption.A_Factory));
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_Description, FXmlTagWSMOption.D_Description, fXmlNodeSol.get_attrVal(FXmlTagWSMOption.A_Description));

                // ***
                // Development Site IP Setting
                // ***
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_StationConnectString, FXmlTagWSMOption.D_StationConnectString, fXmlNodeSol.get_attrVal(FXmlTagWSMOption.A_StationConnectString));
                // --
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsStationConnectString, FXmlTagWSMOption.D_AdsStationConnectString, fXmlNodeSol.get_attrVal(FXmlTagWSMOption.A_AdsStationConnectString));
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsFtpIp, FXmlTagWSMOption.D_AdsFtpIp, fXmlNodeSol.get_attrVal(FXmlTagWSMOption.A_AdsFtpIp));
                //fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsFtpUsedAnonymous, FXmlTagWSMOption.D_AdsFtpUsedAnonymous, "False");
                //fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsFtpUser, FXmlTagWSMOption.D_AdsFtpUser, "appadmin");
                //fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsFtpPassword, FXmlTagWSMOption.D_AdsFtpPassword, fCrypt.encrypt2("APPadmin!@"));
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsSecsInterfaceLogFilterCaption1, FXmlTagWSMOption.D_AdsSecsInterfaceLogFilterCaption1, "Equipment");
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsSecsInterfaceLogFilterSecsItem1, FXmlTagWSMOption.D_AdsSecsInterfaceLogFilterSecsItem1, "EQPID");
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsSecsInterfaceLogFilterHostItem1, FXmlTagWSMOption.D_AdsSecsInterfaceLogFilterHostItem1, "RES_ID");
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsSecsInterfaceLogFilterCaption2, FXmlTagWSMOption.D_AdsSecsInterfaceLogFilterCaption2, "CEID");
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsSecsInterfaceLogFilterSecsItem2, FXmlTagWSMOption.D_AdsSecsInterfaceLogFilterSecsItem2, "CEID");
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsSecsInterfaceLogFilterHostItem2, FXmlTagWSMOption.D_AdsSecsInterfaceLogFilterHostItem2, "CEID");
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fCrypt != null)
                {
                    fCrypt.Dispose();
                    fCrypt = null;
                }
                fXmlNodeSop = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void copyOption(
            )
        {
            string dirName = string.Empty;

            try
            {
                dirName = Path.GetDirectoryName(m_optionFileName);
                if (!Directory.Exists(dirName))
                {
                    Directory.CreateDirectory(dirName);
                }

                // --

                m_defaultOptionFileName = m_fWsmCore.appPath + "\\Config\\" + "\\NexplantMCWorkspaceManager.cfg";
                if (File.Exists(m_defaultOptionFileName))
                {
                    File.Copy(m_defaultOptionFileName, m_optionFileName);
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

        private void loadOption(
            )
        {
            FCrypt fCrypt = null;
            FXmlNode fXmlNodeWmo = null;
            FXmlNode fXmlNodeWso = null;
            FXmlNode fXmlNodeAmo = null;
            FXmlNode fXmlNodeRso = null;
            FXmlNode fXmlNodeSol = null;
            string xPath = string.Empty;
            string defaultFileName = string.Empty;
            // --
            FXmlNode fXmlNodeDefaultWso = null;
            FXmlNode fXmlNodeDefaultSop = null;
            FXmlNode fXmlNodeFind = null;
            string defFactory = string.Empty;
            string defPath = string.Empty;

            try
            {
                fCrypt = new FCrypt();

                // --

                // ***
                // Option XML Document Load
                // *** 
                m_fXmlDocOpt = new FXmlDocument();
                m_fXmlDocOpt.preserveWhiteSpace = false;
                m_fXmlDocOpt.load(m_optionFileName);

                // --

                // ***
                // Workspace Manager Option Load
                // ***
                fXmlNodeWmo = m_fXmlDocOpt.selectSingleNode(FXmlTagFAMate.E_FAMate + "/" + FXmlTagWSMOption.E_WSMOption);
                // --
                m_language = (FLanguage)Enum.Parse(typeof(FLanguage), fXmlNodeWmo.get_attrVal(FXmlTagWSMOption.A_Language, FXmlTagWSMOption.D_Language));
                m_fontName = fXmlNodeWmo.get_attrVal(FXmlTagWSMOption.A_FontName, FXmlTagWSMOption.D_FontName);
                m_debugLogFileSubfix = fXmlNodeWmo.get_attrVal(FXmlTagWSMOption.A_DebugLogFileSubfix, FXmlTagWSMOption.D_DebugLogFileSubfix);
                m_debugLogFileKeepingPeriod = int.Parse(fXmlNodeWmo.get_attrVal(FXmlTagWSMOption.A_DebugLogFileKeepingPeriod, FXmlTagWSMOption.D_DebugLogFileKeepingPeriod.ToString()));
                m_developmentToolEnabled = (FYesNo)Enum.Parse(typeof(FYesNo), fXmlNodeWmo.get_attrVal(FXmlTagWSMOption.A_DevelopmentToolEnabled, FXmlTagWSMOption.D_DevelopmentToolEnabled));

                // --

                // ***
                // Workspace Manager Site Option Load
                // ***
                fXmlNodeWso = m_fXmlDocOpt.selectSingleNode(FXmlTagFAMate.E_FAMate + "/" + FXmlTagWSMOption.E_WSMSiteOption);
                // --
                m_checkedIdSave = Boolean.Parse(fXmlNodeWso.get_attrVal(FXmlTagWSMOption.A_CheckedIdSave, FXmlTagWSMOption.D_CheckedIdSave));
                if (m_checkedIdSave)
                {
                    m_user = fXmlNodeWso.get_attrVal(FXmlTagWSMOption.A_User, FXmlTagWSMOption.D_User);
                }

                // --

                // ***
                // Admin Manager Option Load
                // ***
                fXmlNodeAmo = fXmlNodeWso.selectSingleNode(FXmlTagWSMOption.E_ManagerOptionList + "/" + FXmlTagWSMOption.E_AdsManagerOption);
                // --
                m_adsRecentDownloadPath = fXmlNodeAmo.get_attrVal(FXmlTagWSMOption.A_AdsRecentDownloadPath, FXmlTagWSMOption.D_AdsRecentDownloadPath);
                m_adsRecentLogDownloadPath = fXmlNodeAmo.get_attrVal(FXmlTagWSMOption.A_AdsRecentLogDownloadPath, FXmlTagWSMOption.D_AdsRecentLogDownloadPath);
                m_adsRecentExportPath = fXmlNodeAmo.get_attrVal(FXmlTagWSMOption.A_AdsRecentExportPath, FXmlTagWSMOption.D_AdsRecentExportPath);
                m_adsFontName = fXmlNodeAmo.get_attrVal(FXmlTagWSMOption.A_AdsFontName, FXmlTagWSMOption.D_AdsFontName);
                m_adsFontSize = float.Parse(fXmlNodeAmo.get_attrVal(FXmlTagWSMOption.A_AdsFontSize, FXmlTagWSMOption.D_AdsFontSize));

                // --

                // ***
                // Recent Site Option Load
                // ***
                fXmlNodeRso = fXmlNodeWso.selectSingleNode(FXmlTagWSMOption.E_RecentSiteOption);
                // --
                m_site = fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_Site, FXmlTagWSMOption.D_Site);
                // --
                m_factory = fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_Factory, FXmlTagWSMOption.D_Factory);
                m_description = fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_Description, FXmlTagWSMOption.D_Description);
                // --
                m_stationConnectString = fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_StationConnectString, FXmlTagWSMOption.D_StationConnectString);
                m_stationTimeout = int.Parse(fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_StationTimeout, FXmlTagWSMOption.D_StationTimeout));
                m_tuneChannelId = fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_TuneChannelId, FXmlTagWSMOption.D_TuneChannelId);
                m_castChannelId = fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_CastChannelId, FXmlTagWSMOption.D_CastChannelId);
                // --
                m_adsStationConnectString = fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_AdsStationConnectString, FXmlTagWSMOption.D_AdsStationConnectString);
                m_adsStationTimeout = int.Parse(fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_AdsStationTimeout, FXmlTagWSMOption.D_AdsStationTimeout));
                m_adsTuneChannelId = fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_AdsTuneChannelId, FXmlTagWSMOption.D_AdsTuneChannelId);
                m_adsCastChannelId = fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_AdsCastChannelId, FXmlTagWSMOption.D_AdsCastChannelId);
                m_adsFtpIp = fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_AdsFtpIp, FXmlTagWSMOption.D_AdsFtpIp);
                m_adsFtpUsedAnonymous = Boolean.Parse(fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_AdsFtpUsedAnonymous, FXmlTagWSMOption.D_AdsFtpUsedAnonymous));
                m_adsFtpUser = fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_AdsFtpUser, FXmlTagWSMOption.D_AdsFtpUser);
                m_adsFtpPassword = fCrypt.decrypt2(fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_AdsFtpPassword, FXmlTagWSMOption.D_AdsFtpPassword));
                m_adsHistorySearchPeriod = int.Parse(fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_AdsHistorySearchPeriod, FXmlTagWSMOption.D_AdsHistorySearchPeriod));
                m_adsNoticePopupEnabled = Boolean.Parse(fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_AdsNoticePopupEnabled, FXmlTagWSMOption.D_AdsNoticePopupEnabled));
                m_adsNoticeLastTime = fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_AdsNoticeLastTime, FXmlTagWSMOption.D_AdsNoticeLastTime);
                m_adsDesktopAlertEnabled = Boolean.Parse(fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_AdsDesktopAlertEnabled, FXmlTagWSMOption.D_AdsDesktopAlertEnabled));
                m_adsDesktopAlertSoundEnabled = Boolean.Parse(fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_AdsDesktopAlertSoundEnabled, FXmlTagWSMOption.D_AdsDesktopAlertSoundEnabled));
                m_adsDesktopAlertServerEnabled = Boolean.Parse(fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_AdsDesktopAlertServerEnabled, FXmlTagWSMOption.D_AdsDesktopAlertServerEnabled));
                m_adsDesktopAlertEapEnabled = Boolean.Parse(fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_AdsDesktopAlertEapEnabled, FXmlTagWSMOption.D_AdsDesktopAlertEapEnabled));
                m_adsDesktopAlertDeviceEnabled = Boolean.Parse(fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_AdsDesktopAlertDeviceEnabled, FXmlTagWSMOption.D_AdsDesktopAlertDeviceEnabled));
                m_adsServerIssueMonitoringCount = int.Parse(fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_AdsServerIssueMonitoringCount, FXmlTagWSMOption.D_AdsServerIssueMonitoringCount));
                m_adsEapIssueMonitoringCount = int.Parse(fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_AdsEapIssueMonitoringCount, FXmlTagWSMOption.D_AdsEapIssueMonitoringCount));
                m_adsEquipmentIssueMonitoringCount = int.Parse(fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_AdsEquipmentIssueMonitoringCount, FXmlTagWSMOption.D_AdsEquipmentIssueMonitoringCount));
                m_adsEquipmentIssueMonitoringCount = int.Parse(fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_AdsEquipmentIssueMonitoringCount, FXmlTagWSMOption.D_AdsEquipmentIssueMonitoringCount));
                m_adsSecsInterfaceLogFilterCaption1 = fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_AdsSecsInterfaceLogFilterCaption1, FXmlTagWSMOption.D_AdsSecsInterfaceLogFilterCaption1);
                m_adsSecsInterfaceLogFilterSecsItem1 = fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_AdsSecsInterfaceLogFilterSecsItem1, FXmlTagWSMOption.D_AdsSecsInterfaceLogFilterSecsItem1);
                m_adsSecsInterfaceLogFilterHostItem1 = fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_AdsSecsInterfaceLogFilterHostItem1, FXmlTagWSMOption.D_AdsSecsInterfaceLogFilterHostItem1);
                m_adsSecsInterfaceLogFilterCaption2 = fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_AdsSecsInterfaceLogFilterCaption2, FXmlTagWSMOption.D_AdsSecsInterfaceLogFilterCaption2);
                m_adsSecsInterfaceLogFilterSecsItem2 = fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_AdsSecsInterfaceLogFilterSecsItem2, FXmlTagWSMOption.D_AdsSecsInterfaceLogFilterSecsItem2);
                m_adsSecsInterfaceLogFilterHostItem2 = fXmlNodeRso.get_attrVal(FXmlTagWSMOption.A_AdsSecsInterfaceLogFilterHostItem2, FXmlTagWSMOption.D_AdsSecsInterfaceLogFilterHostItem2);

                // --

                // ***
                // Default Site Option Copy
                // ***
                if (m_defaultOptionFileName == string.Empty)
                {
                    m_defaultOptionFileName = m_fWsmCore.appPath + "\\Config\\" + "\\NexplantMCWorkspaceManager.cfg";
                }
                // --
                if (File.Exists(m_defaultOptionFileName))
                {
                    m_fXmlDocDefaultOpt = new FXmlDocument();
                    m_fXmlDocDefaultOpt.preserveWhiteSpace = false;
                    m_fXmlDocDefaultOpt.load(m_defaultOptionFileName);

                    fXmlNodeDefaultWso = m_fXmlDocDefaultOpt.selectSingleNode(FXmlTagFAMate.E_FAMate + "/" + FXmlTagWSMOption.E_WSMSiteOption);
                    fXmlNodeDefaultSop = fXmlNodeDefaultWso.selectSingleNode(FXmlTagWSMOption.E_SiteOptionList + "/ " + FXmlTagWSMOption.E_SiteOption);
                    defFactory = fXmlNodeDefaultSop.get_attrVal(FXmlTagWSMOption.A_Factory, FXmlTagWSMOption.D_Factory);
                    defPath = FXmlTagWSMOption.E_SiteOption + "[@" + FXmlTagWSMOption.A_Factory + "='" + defFactory + "']";


                    // --

                    fXmlNodeSol = fXmlNodeWso.selectSingleNode(FXmlTagWSMOption.E_SiteOptionList);
                    // - -
                    fXmlNodeFind = fXmlNodeSol.get_elem(defPath);
                    if (fXmlNodeFind != null)
                    {
                        fXmlNodeSol.removeChild(fXmlNodeFind);
                    }
                    fXmlNodeSol.appendChild(fXmlNodeDefaultSop);
                }
                else
                {
                    fXmlNodeSol = fXmlNodeWso.selectSingleNode(FXmlTagWSMOption.E_SiteOptionList);
                }

                //--

                // ***
                // Recent Site Option Load
                // ***                   
                xPath = FXmlTagWSMOption.E_SiteOption + "[@" + FXmlTagWSMOption.A_Site + "='" + m_site + "']";
                // --
                if (fXmlNodeSol.get_elem(xPath) == null)
                {
                    createSiteOption(fXmlNodeSol);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fCrypt = null;
                fXmlNodeWmo = null;
                fXmlNodeWso = null;
                fXmlNodeAmo = null;
                fXmlNodeRso = null;
                fXmlNodeSol = null;
                fXmlNodeDefaultWso = null;
                fXmlNodeDefaultSop = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        public void save(
            )
        {
            FCrypt fCrypt = null;
            FXmlNode fXmlNodeFam = null;
            FXmlNode fXmlNodeWmo = null;
            FXmlNode fXmlNodeWso = null;
            FXmlNode fXmlNodeAmo = null;
            FXmlNode fXmlNodeRso = null;
            string updateTime = string.Empty;
            string dirName = string.Empty;

            try
            {
                if (m_fXmlDocOpt == null)
                {
                    return;
                }

                // --

                fCrypt = new FCrypt();

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
                // Workspace Manager Option Element set
                // ***
                fXmlNodeWmo = fXmlNodeFam.selectSingleNode(FXmlTagWSMOption.E_WSMOption);
                // --
                fXmlNodeWmo.set_attrVal(FXmlTagWSMOption.A_Language, FXmlTagWSMOption.D_Language, m_language.ToString());
                fXmlNodeWmo.set_attrVal(FXmlTagWSMOption.A_FontName, FXmlTagWSMOption.D_FontName, m_fontName);
                fXmlNodeWmo.set_attrVal(FXmlTagWSMOption.A_DebugLogFileSubfix, FXmlTagWSMOption.D_DebugLogFileSubfix, m_debugLogFileSubfix);
                fXmlNodeWmo.set_attrVal(FXmlTagWSMOption.A_DebugLogFileKeepingPeriod, FXmlTagWSMOption.D_DebugLogFileKeepingPeriod, m_debugLogFileKeepingPeriod.ToString());
                fXmlNodeWmo.set_attrVal(FXmlTagWSMOption.A_DevelopmentToolEnabled, FXmlTagWSMOption.D_DevelopmentToolEnabled, m_developmentToolEnabled.ToString());

                // --

                // ***
                // Workspace Manager Site Option Element set
                // ***
                fXmlNodeWso = fXmlNodeFam.selectSingleNode(FXmlTagWSMOption.E_WSMSiteOption);
                // --
                fXmlNodeWso.set_attrVal(FXmlTagWSMOption.A_CheckedIdSave, FXmlTagWSMOption.D_CheckedIdSave, m_checkedIdSave.ToString());
                fXmlNodeWso.set_attrVal(FXmlTagWSMOption.A_User, FXmlTagWSMOption.D_User, m_user);

                // --

                // ***
                // Admin Manager Option Element Set
                // ***
                fXmlNodeAmo = fXmlNodeWso.selectSingleNode(FXmlTagWSMOption.E_ManagerOptionList + "/" + FXmlTagWSMOption.E_AdsManagerOption);
                // --
                fXmlNodeAmo.set_attrVal(FXmlTagWSMOption.A_AdsRecentDownloadPath, FXmlTagWSMOption.D_AdsRecentDownloadPath, m_adsRecentDownloadPath);
                fXmlNodeAmo.set_attrVal(FXmlTagWSMOption.A_AdsRecentLogDownloadPath, FXmlTagWSMOption.D_AdsRecentLogDownloadPath, m_adsRecentLogDownloadPath);
                fXmlNodeAmo.set_attrVal(FXmlTagWSMOption.A_AdsRecentExportPath, FXmlTagWSMOption.D_AdsRecentExportPath, m_adsRecentExportPath);
                fXmlNodeAmo.set_attrVal(FXmlTagWSMOption.A_AdsFontName, FXmlTagWSMOption.D_AdsFontName, m_adsFontName);
                fXmlNodeAmo.set_attrVal(FXmlTagWSMOption.A_AdsFontSize, FXmlTagWSMOption.D_AdsFontSize, m_adsFontSize.ToString());

                // --

                // ***
                // Recent Site Option Element Set
                // ***
                fXmlNodeRso = fXmlNodeWso.selectSingleNode(FXmlTagWSMOption.E_RecentSiteOption);
                // --
                fXmlNodeRso.set_attrVal(FXmlTagWSMOption.A_Site, m_site);
                // --
                fXmlNodeRso.set_attrVal(FXmlTagWSMOption.A_Factory, FXmlTagWSMOption.D_Factory, m_factory);
                fXmlNodeRso.set_attrVal(FXmlTagWSMOption.A_Description, FXmlTagWSMOption.D_Description, m_description);
                // --
                fXmlNodeRso.set_attrVal(FXmlTagWSMOption.A_StationConnectString, FXmlTagWSMOption.D_StationConnectString, m_stationConnectString);
                fXmlNodeRso.set_attrVal(FXmlTagWSMOption.A_StationTimeout, FXmlTagWSMOption.D_StationTimeout, m_stationTimeout.ToString());
                fXmlNodeRso.set_attrVal(FXmlTagWSMOption.A_TuneChannelId, FXmlTagWSMOption.D_TuneChannelId, m_tuneChannelId);
                fXmlNodeRso.set_attrVal(FXmlTagWSMOption.A_CastChannelId, FXmlTagWSMOption.D_CastChannelId, m_castChannelId);
                // --
                fXmlNodeRso.set_attrVal(FXmlTagWSMOption.A_AdsStationConnectString, FXmlTagWSMOption.D_AdsStationConnectString, m_adsStationConnectString);
                fXmlNodeRso.set_attrVal(FXmlTagWSMOption.A_AdsStationTimeout, FXmlTagWSMOption.D_AdsStationTimeout, m_adsStationTimeout.ToString());
                fXmlNodeRso.set_attrVal(FXmlTagWSMOption.A_AdsTuneChannelId, FXmlTagWSMOption.D_AdsTuneChannelId, m_adsTuneChannelId);
                fXmlNodeRso.set_attrVal(FXmlTagWSMOption.A_AdsCastChannelId, FXmlTagWSMOption.D_AdsCastChannelId, m_adsCastChannelId);
                fXmlNodeRso.set_attrVal(FXmlTagWSMOption.A_AdsFtpIp, FXmlTagWSMOption.D_AdsFtpIp, m_adsFtpIp);
                fXmlNodeRso.set_attrVal(FXmlTagWSMOption.A_AdsFtpUsedAnonymous, FXmlTagWSMOption.D_AdsFtpUsedAnonymous, m_adsFtpUsedAnonymous.ToString());
                fXmlNodeRso.set_attrVal(FXmlTagWSMOption.A_AdsFtpUser, FXmlTagWSMOption.D_AdsFtpUser, m_adsFtpUser);
                fXmlNodeRso.set_attrVal(FXmlTagWSMOption.A_AdsFtpPassword, FXmlTagWSMOption.D_AdsFtpPassword, fCrypt.encrypt2(m_adsFtpPassword));
                fXmlNodeRso.set_attrVal(FXmlTagWSMOption.A_AdsHistorySearchPeriod, FXmlTagWSMOption.D_AdsHistorySearchPeriod, m_adsHistorySearchPeriod.ToString());
                fXmlNodeRso.set_attrVal(FXmlTagWSMOption.A_AdsNoticePopupEnabled, FXmlTagWSMOption.D_AdsNoticePopupEnabled, m_adsNoticePopupEnabled.ToString());
                fXmlNodeRso.set_attrVal(FXmlTagWSMOption.A_AdsNoticeLastTime, FXmlTagWSMOption.D_AdsNoticeLastTime, m_adsNoticeLastTime);
                fXmlNodeRso.set_attrVal(FXmlTagWSMOption.A_AdsDesktopAlertEnabled, FXmlTagWSMOption.D_AdsDesktopAlertEnabled, m_adsDesktopAlertEnabled.ToString());
                fXmlNodeRso.set_attrVal(FXmlTagWSMOption.A_AdsDesktopAlertSoundEnabled, FXmlTagWSMOption.D_AdsDesktopAlertSoundEnabled, m_adsDesktopAlertSoundEnabled.ToString());
                fXmlNodeRso.set_attrVal(FXmlTagWSMOption.A_AdsDesktopAlertServerEnabled, FXmlTagWSMOption.D_AdsDesktopAlertServerEnabled, m_adsDesktopAlertServerEnabled.ToString());
                fXmlNodeRso.set_attrVal(FXmlTagWSMOption.A_AdsDesktopAlertEapEnabled, FXmlTagWSMOption.D_AdsDesktopAlertEapEnabled, m_adsDesktopAlertEapEnabled.ToString());
                fXmlNodeRso.set_attrVal(FXmlTagWSMOption.A_AdsDesktopAlertDeviceEnabled, FXmlTagWSMOption.D_AdsDesktopAlertDeviceEnabled, m_adsDesktopAlertDeviceEnabled.ToString());
                fXmlNodeRso.set_attrVal(FXmlTagWSMOption.A_AdsServerIssueMonitoringCount, FXmlTagWSMOption.D_AdsServerIssueMonitoringCount, m_adsServerIssueMonitoringCount.ToString());
                fXmlNodeRso.set_attrVal(FXmlTagWSMOption.A_AdsEapIssueMonitoringCount, FXmlTagWSMOption.D_AdsEapIssueMonitoringCount, m_adsEapIssueMonitoringCount.ToString());
                fXmlNodeRso.set_attrVal(FXmlTagWSMOption.A_AdsEquipmentIssueMonitoringCount, FXmlTagWSMOption.D_AdsEquipmentIssueMonitoringCount, m_adsEquipmentIssueMonitoringCount.ToString());
                fXmlNodeRso.set_attrVal(FXmlTagWSMOption.A_AdsSecsInterfaceLogFilterCaption1, FXmlTagWSMOption.D_AdsSecsInterfaceLogFilterCaption1, m_adsSecsInterfaceLogFilterCaption1);
                fXmlNodeRso.set_attrVal(FXmlTagWSMOption.A_AdsSecsInterfaceLogFilterSecsItem1, FXmlTagWSMOption.D_AdsSecsInterfaceLogFilterSecsItem1, m_adsSecsInterfaceLogFilterSecsItem1);
                fXmlNodeRso.set_attrVal(FXmlTagWSMOption.A_AdsSecsInterfaceLogFilterHostItem1, FXmlTagWSMOption.D_AdsSecsInterfaceLogFilterHostItem1, m_adsSecsInterfaceLogFilterHostItem1);
                fXmlNodeRso.set_attrVal(FXmlTagWSMOption.A_AdsSecsInterfaceLogFilterCaption2, FXmlTagWSMOption.D_AdsSecsInterfaceLogFilterCaption2, m_adsSecsInterfaceLogFilterCaption2);
                fXmlNodeRso.set_attrVal(FXmlTagWSMOption.A_AdsSecsInterfaceLogFilterSecsItem2, FXmlTagWSMOption.D_AdsSecsInterfaceLogFilterSecsItem2, m_adsSecsInterfaceLogFilterSecsItem2);
                fXmlNodeRso.set_attrVal(FXmlTagWSMOption.A_AdsSecsInterfaceLogFilterHostItem2, FXmlTagWSMOption.D_AdsSecsInterfaceLogFilterHostItem2, m_adsSecsInterfaceLogFilterHostItem2);

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
                fCrypt = null;
                fXmlNodeFam = null;
                fXmlNodeWmo = null;
                fXmlNodeWso = null;
                fXmlNodeAmo = null;
                fXmlNodeRso = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void changeOption(
            FPropSetupOption fPropSetupOption
            )
        {
            bool languageChanged = false;
            bool fontNameChanged = false;

            try
            {
                if (m_language != fPropSetupOption.Language)
                {
                    languageChanged = true;
                }

                if (m_fontName != fPropSetupOption.FontName)
                {
                    fontNameChanged = true;
                }

                // --

                m_language = fPropSetupOption.Language;
                m_fontName = fPropSetupOption.FontName;
                m_debugLogFileSubfix = fPropSetupOption.DebugLogFileSubfix;
                m_debugLogFileKeepingPeriod = fPropSetupOption.DebugLogFileKeepingPeriod;
                m_developmentToolEnabled = fPropSetupOption.DevelopmentToolEnabled;

                // --

                save();

                // --

                m_fWsmCore.setDebugLog();
                // --
                if (languageChanged)
                {
                    m_fWsmCore.fUIWizard.onLanguageChanged(m_language.ToString());
                }
                // --
                if (fontNameChanged)
                {
                    m_fWsmCore.fUIWizard.onFontNameChanged(m_fontName);
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

        public void updateWsmOption(
            FWsmSiteOption source
            )
        {
            FCrypt fCrypt = null;
            FXmlNode fXmlNodeSop = null;
            string xpath = string.Empty;

            try
            {
                fCrypt = new FCrypt();

                // --

                xpath =
                    FXmlTagFAMate.E_FAMate +
                    "/" + FXmlTagWSMOption.E_WSMSiteOption +
                    "/" + FXmlTagWSMOption.E_SiteOptionList +
                    "/" + FXmlTagWSMOption.E_SiteOption + "[@" + FXmlTagWSMOption.A_Site + "='" + source.site + "']";
                // --
                fXmlNodeSop = m_fXmlDocOpt.selectSingleNode(xpath);

                // --

                if (fXmlNodeSop == null)
                {
                    xpath =
                        FXmlTagFAMate.E_FAMate +
                        "/" + FXmlTagWSMOption.E_WSMSiteOption +
                        "/" + FXmlTagWSMOption.E_SiteOptionList;
                    // --
                    fXmlNodeSop = m_fXmlDocOpt.selectSingleNode(xpath).appendChild(m_fXmlDocOpt.createNode(FXmlTagWSMOption.E_SiteOption));
                }

                // --

                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_Site, source.site);
                // --
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_Factory, FXmlTagWSMOption.D_Factory, source.factory);
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_Description, FXmlTagWSMOption.D_Description, source.description);
                // --
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_StationConnectString, FXmlTagWSMOption.D_StationConnectString, source.stationConnectString);
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_StationTimeout, FXmlTagWSMOption.D_StationTimeout, source.stationTimeout.ToString());
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_TuneChannelId, FXmlTagWSMOption.D_TuneChannelId, source.tuneChannelId);
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_CastChannelId, FXmlTagWSMOption.D_CastChannelId, source.castChannelId);
                // --
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsStationConnectString, FXmlTagWSMOption.D_AdsStationConnectString, source.fAdmOption.adsStationConnectString);
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsStationTimeout, FXmlTagWSMOption.D_AdsStationTimeout, source.fAdmOption.adsStationTimeout.ToString());
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsTuneChannelId, FXmlTagWSMOption.D_AdsTuneChannelId, source.fAdmOption.adsTuneChannelId);
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsCastChannelId, FXmlTagWSMOption.D_AdsCastChannelId, source.fAdmOption.adsCastChannelId);
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsFtpIp, FXmlTagWSMOption.D_AdsFtpIp, source.fAdmOption.adsFtpIp);
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsFtpUsedAnonymous, FXmlTagWSMOption.D_AdsFtpUsedAnonymous, source.fAdmOption.adsFtpUsedAnonymous.ToString());
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsFtpUser, FXmlTagWSMOption.D_AdsFtpUser, source.fAdmOption.adsFtpUser);
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsFtpPassword, FXmlTagWSMOption.D_AdsFtpPassword, fCrypt.encrypt2(source.fAdmOption.adsFtpPassword));
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsHistorySearchPeriod, FXmlTagWSMOption.D_AdsHistorySearchPeriod, source.fAdmOption.adsHistorySearchPeriod.ToString());
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsNoticePopupEnabled, FXmlTagWSMOption.D_AdsNoticePopupEnabled, source.fAdmOption.adsNoticePopupEnabled.ToString());
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsNoticeLastTime, FXmlTagWSMOption.D_AdsNoticeLastTime, source.fAdmOption.adsNoticeLastTime);
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsDesktopAlertEnabled, FXmlTagWSMOption.D_AdsDesktopAlertEnabled, source.fAdmOption.adsDesktopAlertEnabled.ToString());
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsDesktopAlertSoundEnabled, FXmlTagWSMOption.D_AdsDesktopAlertSoundEnabled, source.fAdmOption.adsDesktopAlertSoundEnabled.ToString());
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsDesktopAlertServerEnabled, FXmlTagWSMOption.D_AdsDesktopAlertServerEnabled, source.fAdmOption.adsDesktopAlertServerEnabled.ToString());
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsDesktopAlertEapEnabled, FXmlTagWSMOption.D_AdsDesktopAlertEapEnabled, source.fAdmOption.adsDesktopAlertEapEnabled.ToString());
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsDesktopAlertDeviceEnabled, FXmlTagWSMOption.D_AdsDesktopAlertDeviceEnabled, source.fAdmOption.adsDesktopAlertDeviceEnabled.ToString());
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsServerIssueMonitoringCount, FXmlTagWSMOption.D_AdsServerIssueMonitoringCount, source.fAdmOption.adsServerIssueMonitoringCount.ToString());
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsEapIssueMonitoringCount, FXmlTagWSMOption.D_AdsEapIssueMonitoringCount, source.fAdmOption.adsEapIssueMonitoringCount.ToString());
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsEquipmentIssueMonitoringCount, FXmlTagWSMOption.D_AdsEquipmentIssueMonitoringCount, source.fAdmOption.adsEquipmentIssueMonitoringCount.ToString());
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsSecsInterfaceLogFilterCaption1, FXmlTagWSMOption.D_AdsSecsInterfaceLogFilterCaption1, source.fAdmOption.adsSecsInterfaceLogFilterCaption1);
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsSecsInterfaceLogFilterSecsItem1, FXmlTagWSMOption.D_AdsSecsInterfaceLogFilterSecsItem1, source.fAdmOption.adsSecsInterfaceLogFilterSecsItem1);
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsSecsInterfaceLogFilterHostItem1, FXmlTagWSMOption.D_AdsSecsInterfaceLogFilterHostItem1, source.fAdmOption.adsSecsInterfaceLogFilterHostItem1);
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsSecsInterfaceLogFilterCaption2, FXmlTagWSMOption.D_AdsSecsInterfaceLogFilterCaption2, source.fAdmOption.adsSecsInterfaceLogFilterCaption2);
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsSecsInterfaceLogFilterSecsItem2, FXmlTagWSMOption.D_AdsSecsInterfaceLogFilterSecsItem2, source.fAdmOption.adsSecsInterfaceLogFilterSecsItem2);
                fXmlNodeSop.set_attrVal(FXmlTagWSMOption.A_AdsSecsInterfaceLogFilterHostItem2, FXmlTagWSMOption.D_AdsSecsInterfaceLogFilterHostItem2, source.fAdmOption.adsSecsInterfaceLogFilterHostItem2);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fCrypt != null)
                {
                    fCrypt.Dispose();
                    fCrypt = null;
                }

                if (fXmlNodeSop != null)
                {
                    fXmlNodeSop.Dispose();
                    fXmlNodeSop = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void deleteSiteOption(
            FWsmSiteOption source
            )
        {
            FXmlNode fXmlNodeSop = null;
            string xpath = string.Empty;

            try
            {
                xpath =
                    FXmlTagFAMate.E_FAMate +
                    "/" + FXmlTagWSMOption.E_WSMSiteOption +
                    "/" + FXmlTagWSMOption.E_SiteOptionList +
                    "/" + FXmlTagWSMOption.E_SiteOption + "[@" + FXmlTagWSMOption.A_Site + "='" + source.site + "']";
                // --
                fXmlNodeSop = m_fXmlDocOpt.selectSingleNode(xpath);

                // --

                if (fXmlNodeSop != null)
                {
                    fXmlNodeSop.fParentNode.removeChild(fXmlNodeSop);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeSop != null)
                {
                    fXmlNodeSop.Dispose();
                    fXmlNodeSop = null;
                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
