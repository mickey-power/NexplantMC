/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlTagWSMOption.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.31
--  Description     : FAMate Workspace Manager Option XML Tag Definition Class 
--  History         : Created by spike.lee at 2010.12.31
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.WorkspaceManager
{
    public static class FXmlTagWSMOption
    {

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // FAMate Workspace Manager Option Element
        // ***
        public const string E_WSMOption = "WMO";

        // --

        // ***
        // FAMate Workspace Manager Option Attribute
        // ***
        public const string A_Language = "LNG";
        public const string A_FontName = "FNA";
        public const string A_DebugLogFileSubfix = "DLS";
        public const string A_DebugLogFileKeepingPeriod = "DLK";
        public const string A_DevelopmentToolEnabled = "DTE";
        // --
        public const string D_Language = "Default";
        public const string D_FontName = "Verdana";
        public const string D_DebugLogFileSubfix = "WorkspaceManager";
        public const string D_DebugLogFileKeepingPeriod = "30";
        public const string D_DevelopmentToolEnabled = "No";

        // --

        // ***
        // Recent File Element
        // ***
        public const string E_Recent = "RCT";

        // --

        // ***
        // Recent File Attribute
        // ***
        public const string A_File = "FIL";
        // --
        public const string D_File = "";

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // FAMate Workspace Manager Sit Option Element
        // ***
        public const string E_WSMSiteOption = "WSO";

        // --

        // ***
        // FAMate Workspace Manager Site Option Attribute
        // ***
        public const string A_CheckedIdSave = "CIS";
        public const string A_User = "USR";
        // --
        // --
        public const string D_CheckedIdSave = "False";
        public const string D_User = "guest";

        // --

        // ***
        // Manager Option List Element
        // ***
        public const string E_ManagerOptionList = "MOL";

        // --

        // ***
        // Admin Manager Option Element
        // ***
        public const string E_AdsManagerOption = "AMO";

        // --

        // ***
        // Admin Manager Option Attribute
        // ***
        public const string A_AdsRecentDownloadPath = "ARD";
        public const string A_AdsRecentLogDownloadPath = "ARL";
        public const string A_AdsRecentExportPath = "ARE";
        public const string A_AdsFontName = "AFN";
        public const string A_AdsFontSize = "AFS";
        // --
        public const string D_AdsRecentDownloadPath = "";
        public const string D_AdsRecentLogDownloadPath = "";
        public const string D_AdsRecentExportPath = "";
        public const string D_AdsFontName = "Verdana";
        public const string D_AdsFontSize = "8";

        // --

        // ***
        // DCS Manager Option Element
        // ***
        public const string E_DcsManagerOption = "DMO";

        // --

        // ***
        // DCS Manager Option Attribute
        // ***
        public const string A_DcsRecentDownloadPath = "DRD";
        public const string A_DcsRecentLogDownloadPath = "DRL";
        public const string A_DcsRecentExportPath = "DRE";
        public const string A_DcsFontName = "DFN";
        public const string A_DcsFontSize = "DFS";
        // --
        public const string D_DcsRecentDownloadPath = "";
        public const string D_DcsRecentLogDownloadPath = "";
        public const string D_DcsRecentExportPath = "";
        public const string D_DcsFontName = "Verdana";
        public const string D_DcsFontSize = "8";

        // --

        // ***
        // RMS Manager Option Element
        // ***
        public const string E_RmsManagerOption = "RMO";

        // --

        // ***
        // RMS Manager Option Attribute
        // ***
        public const string A_RmsRecentDownloadPath = "RRD";
        public const string A_RmsRecentLogDownloadPath = "RRL";
        public const string A_RmsRecentExportPath = "RRE";
        public const string A_RmsFontName = "RFN";
        public const string A_RmsFontSize = "RFS";
        // --
        public const string D_RmsRecentDownloadPath = "";
        public const string D_RmsRecentLogDownloadPath = "";
        public const string D_RmsRecentExportPath = "";
        public const string D_RmsFontName = "Verdana";
        public const string D_RmsFontSize = "8";

        // --

        // ***
        // PMS Manager Option Element
        // ***
        public const string E_PmsManagerOption = "PMO";

        // --

        // ***
        // PMS Manager Option Attribute
        // ***
        public const string A_PmsRecentDownloadPath = "PRD";
        public const string A_PmsRecentLogDownloadPath = "PRL";
        public const string A_PmsRecentExportPath = "PRE";
        public const string A_PmsFontName = "PFN";
        public const string A_PmsFontSize = "PFS";
        // --
        public const string D_PmsRecentDownloadPath = "";
        public const string D_PmsRecentLogDownloadPath = "";
        public const string D_PmsRecentExportPath = "";
        public const string D_PmsFontName = "Verdana";
        public const string D_PmsFontSize = "8";
        
        // --

        // ***
        // FHS Manager Option Element
        // ***
        public const string E_FhsManagerOption = "FMO";

        // --

        // ***
        // FHS Manager Option Attribute
        // ***
        public const string A_FhsRecentDownloadPath = "FRD";
        public const string A_FhsRecentLogDownloadPath = "FRL";
        public const string A_FhsRecentExportPath = "FRE";
        public const string A_FhsFontName = "FFN";
        public const string A_FhsFontSize = "FFS";
        // --
        public const string D_FhsRecentDownloadPath = "";
        public const string D_FhsRecentLogDownloadPath = "";
        public const string D_FhsRecentExportPath = "";
        public const string D_FhsFontName = "Verdana";
        public const string D_FhsFontSize = "8";
        // --

        // ***
        // Recent Site Option Element
        // ***
        public const string E_RecentSiteOption = "RSO";

        // --

        // ***
        // Site Option List Element
        // ***
        public const string E_SiteOptionList = "SOL";

        // --

        // ***
        // Site Option Element
        // ***
        public const string E_SiteOption = "SOP";

        // --

        // ***
        // Site Option Attribute - (Recent) Site
        // ***
        public const string A_Site = "SIT";
        public const string A_Factory = "FAB";
        public const string A_Description = "DEC";
        public const string A_StationConnectString = "SCS";
        public const string A_StationTimeout = "STO";
        public const string A_TuneChannelId = "TCI";
        public const string A_CastChannelId = "CCI";
        public const string A_AdsStationConnectString = "ASC";
        public const string A_AdsStationTimeout = "AST";
        public const string A_AdsTuneChannelId = "ATI";
        public const string A_AdsCastChannelId = "ACI";
        public const string A_AdsFtpIp = "AFI";
        public const string A_AdsFtpUsedAnonymous = "AFA";
        public const string A_AdsFtpUser = "AFU";
        public const string A_AdsFtpPassword = "AFP";
        public const string A_AdsHistorySearchPeriod = "AHP";
        public const string A_AdsNoticePopupEnabled = "ANP";
        public const string A_AdsNoticeLastTime = "ANL";
        public const string A_AdsDesktopAlertEnabled = "ADE";
        public const string A_AdsDesktopAlertSoundEnabled = "ADS";
        public const string A_AdsDesktopAlertServerEnabled = "ADR";
        public const string A_AdsDesktopAlertEapEnabled = "ADP";
        public const string A_AdsDesktopAlertDeviceEnabled = "ADD";
        public const string A_AdsServerIssueMonitoringCount = "ASI";
        public const string A_AdsEapIssueMonitoringCount = "AEI";
        public const string A_AdsEquipmentIssueMonitoringCount = "AQI";
        public const string A_AdsSecsInterfaceLogFilterCaption1 = "AF1";
        public const string A_AdsSecsInterfaceLogFilterSecsItem1 = "AS1";
        public const string A_AdsSecsInterfaceLogFilterHostItem1 = "AH1";
        public const string A_AdsSecsInterfaceLogFilterCaption2 = "AF2";
        public const string A_AdsSecsInterfaceLogFilterSecsItem2 = "AS2";
        public const string A_AdsSecsInterfaceLogFilterHostItem2 = "AH2";
        public const string A_DcsStationConnectString = "DSC";
        public const string A_DcsStationTimeout = "DST";
        public const string A_DcsTuneChannelId = "DTI";
        public const string A_DcsCastChannelId = "DCI";
        public const string A_DcsFtpIp = "DFI";
        public const string A_DcsFtpUsedAnonymous = "DFA";
        public const string A_DcsFtpUser = "DFU";
        public const string A_DcsFtpPassword = "DFP";
        public const string A_DcsHistorySearchPeriod = "DHP";
        public const string A_DcsNoticePopupEnabled = "DNP";
        public const string A_DcsNoticeLastTime = "DNL";
        public const string A_RmsStationConnectString = "RSC";
        public const string A_RmsStationTimeout = "RST";
        public const string A_RmsTuneChannelId = "RTI";
        public const string A_RmsCastChannelId = "RCI";
        public const string A_RmsFtpIp = "RFI";
        public const string A_RmsFtpUsedAnonymous = "RFA";
        public const string A_RmsFtpUser = "RFU";
        public const string A_RmsFtpPassword = "RFP";
        public const string A_RmsHistorySearchPeriod = "RHP";
        public const string A_RmsNoticePopupEnabled = "RNP";
        public const string A_RmsNoticeLastTime = "RNL";
        public const string A_RmsDesktopAlertEnabled = "RDE";
        public const string A_RmsDesktopAlertSoundEnabled = "RDS";
        public const string A_RmsDesktopAlertRecipeEnabled = "RDR";
        public const string A_PmsStationConnectString = "PSC";
        public const string A_PmsStationTimeout = "PST";
        public const string A_PmsTuneChannelId = "PTI";
        public const string A_PmsCastChannelId = "PCI";
        public const string A_PmsFtpIp = "PFI";
        public const string A_PmsFtpUsedAnonymous = "PFA";
        public const string A_PmsFtpUser = "PFU";
        public const string A_PmsFtpPassword = "PFP";
        public const string A_PmsHistorySearchPeriod = "PHP";
        public const string A_PmsNoticePopupEnabled = "PNE";
        public const string A_PmsNoticeLastTime = "PNL";
        public const string A_PmsDesktopAlertEnabled = "PDE";
        public const string A_PmsDesktopAlertSoundEnabled = "PDS";
        public const string A_PmsDesktopAlertParameterEnabled = "PDP";
        public const string A_FhsStationConnectString = "FSC";
        public const string A_FhsStationTimeout = "FST";
        public const string A_FhsTuneChannelId = "FTI";
        public const string A_FhsCastChannelId = "FCI";
        public const string A_FhsFtpIp = "FFI";
        public const string A_FhsFtpUsedAnonymous = "FFA";
        public const string A_FhsFtpUser = "FFU";
        public const string A_FhsFtpPassword = "FFP";
        public const string A_FhsHistorySearchPeriod = "FHP";
        public const string A_FhsNoticePopupEnabled = "FNP";
        public const string A_FhsNoticeLastTime = "FNL";
        public const string A_FhsDesktopAlertEnabled = "FDE";
        public const string A_FhsDesktopAlertSoundEnabled = "FDS";
        public const string A_FhsDesktopAlertFileEnabled = "FDF";
        // --
        public const string D_Site = "SITE1";
        public const string D_Factory = "FAB1";
        public const string D_Description = "Factory No.1";
        public const string D_StationConnectString = "localhost:10101";
        public const string D_StationTimeout = "30000";
        public const string D_TuneChannelId = "/FMS/ADSWSM";
        public const string D_CastChannelId = "/FMS/WSMADS";
        public const string D_AdsStationConnectString = "localhost:10101";
        public const string D_AdsStationTimeout = "30000";
        public const string D_AdsTuneChannelId = "/FMS/ADSADM";
        public const string D_AdsCastChannelId = "/FMS/ADMADS";
        public const string D_AdsFtpIp = "localhost";
        public const string D_AdsFtpUsedAnonymous = "True";
        public const string D_AdsFtpUser = "anonymous";
        public const string D_AdsFtpPassword = "";
        public const string D_AdsHistorySearchPeriod = "7";
        public const string D_AdsNoticePopupEnabled = "True";
        public const string D_AdsNoticeLastTime = "";
        public const string D_AdsDesktopAlertEnabled = "True";
        public const string D_AdsDesktopAlertSoundEnabled = "True";
        public const string D_AdsDesktopAlertServerEnabled = "True";
        public const string D_AdsDesktopAlertEapEnabled = "True";
        public const string D_AdsDesktopAlertDeviceEnabled = "True";
        public const string D_AdsServerIssueMonitoringCount = "100";
        public const string D_AdsEapIssueMonitoringCount = "100";
        public const string D_AdsEquipmentIssueMonitoringCount = "100";
        public const string D_AdsSecsInterfaceLogFilterCaption1 = "";
        public const string D_AdsSecsInterfaceLogFilterSecsItem1 = "";
        public const string D_AdsSecsInterfaceLogFilterHostItem1 = "";
        public const string D_AdsSecsInterfaceLogFilterCaption2 = "";
        public const string D_AdsSecsInterfaceLogFilterSecsItem2 = "";
        public const string D_AdsSecsInterfaceLogFilterHostItem2 = "";
        public const string D_DcsStationConnectString = "localhost:10101";
        public const string D_DcsStationTimeout = "30000";
        public const string D_DcsTuneChannelId = "/FMS/DCSDCM";
        public const string D_DcsCastChannelId = "/FMS/DCMDCS";
        public const string D_DcsFtpIp = "localhost";
        public const string D_DcsFtpUsedAnonymous = "True";
        public const string D_DcsFtpUser = "anonymous";
        public const string D_DcsFtpPassword = "";
        public const string D_DcsHistorySearchPeriod = "7";
        public const string D_DcsNoticePopupEnabled = "True";
        public const string D_DcsNoticeLastTime = "";
        public const string D_RmsStationConnectString = "localhost:10101";
        public const string D_RmsStationTimeout = "30000";
        public const string D_RmsTuneChannelId = "/FMS/RMSRMM";
        public const string D_RmsCastChannelId = "/FMS/RMMRMS";
        public const string D_RmsFtpIp = "localhost";
        public const string D_RmsFtpUsedAnonymous = "True";
        public const string D_RmsFtpUser = "anonymous";
        public const string D_RmsFtpPassword = "";
        public const string D_RmsHistorySearchPeriod = "7";
        public const string D_RmsNoticePopupEnabled = "True";
        public const string D_RmsNoticeLastTime = "";
        public const string D_RmsDesktopAlertEnabled = "True";
        public const string D_RmsDesktopAlertSoundEnabled = "True";
        public const string D_RmsDesktopAlertRecipeEnabled = "True";
        public const string D_PmsStationConnectString = "localhost:10101";
        public const string D_PmsStationTimeout = "30000";
        public const string D_PmsTuneChannelId = "/FMS/PMSPMM";
        public const string D_PmsCastChannelId = "/FMS/PMMPMS";
        public const string D_PmsFtpIp = "localhost";
        public const string D_PmsFtpUsedAnonymous = "True";
        public const string D_PmsFtpUser = "anonymous";
        public const string D_PmsFtpPassword = "";
        public const string D_PmsHistorySearchPeriod = "7";
        public const string D_PmsNoticePopupEnabled = "True";
        public const string D_PmsNoticeLastTime = "";
        public const string D_PmsDesktopAlertEnabled = "True";
        public const string D_PmsDesktopAlertSoundEnabled = "True";
        public const string D_PmsDesktopAlertParameterEnabled = "True";
        public const string D_FhsStationConnectString = "localhost:10101";
        public const string D_FhsStationTimeout = "30000";
        public const string D_FhsTuneChannelId = "/FMS/FHSFHM";
        public const string D_FhsCastChannelId = "/FMS/FHMFHS";
        public const string D_FhsFtpIp = "localhost";
        public const string D_FhsFtpUsedAnonymous = "True";
        public const string D_FhsFtpUser = "anonymous";
        public const string D_FhsFtpPassword = "";
        public const string D_FhsHistorySearchPeriod = "7";
        public const string D_FhsNoticePopupEnabled = "True";
        public const string D_FhsNoticeLastTime = "";
        public const string D_FhsDesktopAlertEnabled = "True";
        public const string D_FhsDesktopAlertSoundEnabled = "True";
        public const string D_FhsDesktopAlertFileEnabled = "True";

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
