/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FMenuKey.cs
--  Creator         : mj.kim
--  Create Date     : 2011.09.22
--  Description     : FAMate Admin Manager Menu Key Class 
--  History         : Created by mj.kim at 2011.09.22
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.AdminManager
{
    public static class FMenuKey
    {

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Main Menu
        // ***

        #region System

        public const string MenuSystem = "System";
        // --
        public const string MenuPasswordChange = "Password Change";
        public const string MenuLogOut = "Log Out";
        public const string MenuClose = "Close";

        #endregion

        // --

        #region Setup

        public const string MenuSetup = "Setup";
        // --
        public const string MenuFactory = "Factory";
        // --
        public const string MenuNotice = "Notice";
        public const string MenuGeneralCode = "General Code";
        // --
        public const string MenuEvent = "Event";
        // --
        public const string MenuUserGroupApplication = "User Group Application";
        public const string MenuUserGroup = "User Group";
        public const string MenuUser = "User";
        // --
        public const string MenuServer = "Server";
        // --
        public const string MenuHostDriver = "Host Driver";
        // --
        public const string MenuPackage = "Package";
        public const string MenuModel = "Model";
        public const string MenuComponent = "Component";
        // --
        public const string MenuSecsModelObjectName = "SECS Model Object Name";
        public const string MenuSecsModelFunctionName = "SECS Model Function Name";
        public const string MenuSecsModelUserTagName = "SECS Model User Tag Name";
        // --
        //public const string MenuPlcModelObjectName = "PLC Model Object Name";
        //public const string MenuPlcModelFunctionName = "PLC Model Function Name";
        //public const string MenuPlcModelUserTagName = "PLC Model User Tag Name";
        // --
        public const string MenuOpcModelObjectName = "OPC Model Object Name";
        public const string MenuOpcModelFunctionName = "OPC Model Function Name";
        public const string MenuOpcModelUserTagName = "OPC Model User Tag Name";
        // --
        public const string MenuTcpModelObjectName = "TCP Model Object Name";
        public const string MenuTcpModelFunctionName = "TCP Model Function Name";
        public const string MenuTcpModelUserTagName = "TCP Model User Tag Name";
        // --
        public const string MenuModelSheet = "Model Sheet";
        // --
        public const string MenuMaker = "Maker";
        // --
        public const string MenuEquipmentType = "Equipment Type";
        public const string MenuEquipmentArea = "Equipment Area";
        public const string MenuEquipmentLine = "Equipment Line";
        // --
        public const string MenuCustomRemoteCommand = "Custom Remote Command";
        public const string MenuEquipment = "Equipment";
        public const string MenuInlineEquipment = "Inline Equipment";
        // --
        public const string MenuEap = "EAP";

        #endregion

        // --

        #region Transaction

        public const string MenuTransaction = "Transaction";
        // --
        public const string MenuEapBatchModification = "EAP Batch Modification";
        // --
        public const string MenuEapRelease = "EAP Release";
        // --
        public const string MenuEapStart = "EAP Start";
        public const string MenuEapStop = "EAP Stop";
        // --
        public const string MenuEapReload = "EAP Reload";
        public const string MenuEapRestart = "EAP Restart";
        public const string MenuEapAbort = "EAP Abort";
        // --
        public const string MenuEapMove = "EAP Move";      
        // --
        public const string MenuEapLogLevelSetup = "EAP Log Level Setup";
        // --
        public const string MenuServerMainSwitch = "Server Main Switch";
        public const string MenuServerBackupSwitch = "Server Backup Switch";

        #endregion

        // --

        #region Tool

        public const string MenuTool = "Tool";
        // --
        public const string MenuEapMonitor = "EAP Monitor";
        public const string MenuEquipmentMonitor = "Equipment Monitor";
        // --
        public const string MenuIssueEventMonitor = "Issue Event Monitor";
        // --
        public const string MenuEapLogList = "EAP Log List";
        public const string MenuEapBackupLogList = "EAP Backup Log List";
        // --
        public const string MenuEapInterfaceLogList = "EAP Interface Log List";
        public const string MenuEapInterfaceBackupLogList = "EAP Interface Backup Log List";
        // --
        public const string MenuAdminServiceLogList = "Admin Service Log List";
        public const string MenuAdminServiceBackupLogList = "Admin Service Backup Log List";
        // --
        public const string MenuAdminAgentLogList = "Admin Agent Log List";
        public const string MenuAdminAgentBackupLogList = "Admin Agent Backup Log List";
        // --
        public const string MenuAlertServiceLogList = "Alert Service Log List";
        public const string MenuAlertServiceBackupLogList = "Alert Service Backup Log List";
        // --
        public const string MenuAdminAgentOption = "Admin Agent Option";

        #endregion

        // --

        #region Remote Command

        public const string MenuRemoteCommand = "Remote Command";
        // --
        public const string MenuEquipmentEventDefineRequest = "Equipment Event Define Request";
        public const string MenuEquipmentVersionRequest = "Equipment Version Request";
        public const string MenuEquipmentControlModeRequest = "Equipment Control Mode Request";
        // --
        public const string MenuCustomRemoteCommandRequest = "Custom Remote Command Request";
        // --
        public const string MenuRemotePingTestByServer = "Remote Ping Test By Server";
        public const string MenuRemotePingTestByEquipment = "Remote Ping Test By Equipment";

        #endregion

        // --

        #region Inquiry

        public const string MenuInquiry = "Inquiry";
        // --
        public const string MenuRecentNotice = "Recent Notice";
        public const string MenuNoticeHistory = "Notice History";
        // --
        public const string MenuSystemCheckList = "System Check List";
        // --
        public const string MenuServerList = "Server List";
        public const string MenuServerStatus = "Server Status";
        public const string MenuServerHistory = "Server History";
        // --
        public const string MenuServerResourceList = "Server Resource List";
        public const string MenuServerResourceStatus = "Server Resource Status";
        public const string MenuServerResourceComparison = "Server Resource Comparison";
        public const string MenuServerResourceAnalysis = "Server Resource Analysis";
        public const string MenuServerResourceHistory = "Server Resource History";
        // --
        public const string MenuPackageList = "Package List";
        public const string MenuPackageStatus = "Package Status";
        // --
        public const string MenuModelList = "Model List";
        public const string MenuModelStatus = "Model Status";
        public const string MenuModelVersionSchema = "Model Version Schema";
        // --
        public const string MenuComponentList = "Component List";
        public const string MenuComponentStatus = "Component Status";
        // --
        public const string MenuEapList = "EAP List";
        public const string MenuEapStatus = "EAP Status";
        public const string MenuEapHistory = "EAP History";
        // ***
        // 2017.06.02 by spike.lee
        // MC Repository Status 메뉴 추가
        // ***
        public const string MenuEapRepositoryStatus = "EAP Repository Status";
        // *** 
        public const string MenuEapNeedActionList = "EAP Need Action List";
        // --
        public const string MenuEapResourceList = "EAP Resource List";
        public const string MenuEapResourceComparison = "EAP Resource Comparison";
        public const string MenuEapResourceHistory = "EAP Resource History";
        // --
        public const string MenuEquipmentList = "Equipment List";
        public const string MenuEquipmentStatus = "Equipment Status";
        public const string MenuEquipmentHistory = "Equipment History";        
        // --
        public const string MenuEquipmentGemStatus = "Equipment GEM Status";
        // --
        public const string MenuUserHistory = "User History";
        // ***
        // 2017.07.18 by spike.lee
        // Issue Event Report 관련 메뉴 추가
        // ***
        public const string MenuIssueEventSummary = "Issue Event Summary";
        public const string MenuServerIssueEventSummary = "Server Issue Event Summary";
        public const string MenuEapIssueEventSummary = "EAP Issue Event Summary";
        public const string MenuEquipmentIssueEventSummary = "Equipment Issue Event Summary";
        public const string MenuServerIssueEventHistory = "Server Issue Event History";
        public const string MenuEapIssueEventHistory = "EAP Issue Event History";
        public const string MenuEquipmentIssueEventHistory = "Equipment Issue Event History";
        public const string MenuServerIssueEventTotal = "Server Issue Event Total";
        public const string MenuEapIssueEventTotal = "EAP Issue Event Total";
        public const string MenuEquipmentIssueEventTotal = "Equipment Issue Event Total";
        // --
        public const string MenuOverallIssueEventReport = "Overall Issue Event Report";

        #endregion        

        // --

        #region Window

        public const string MenuWindow = "Window";
        // --
        public const string MenuWinCloseAllWindows = "WinCloseAllWindows";
        public const string MenuWinWindow0 = "WinWindow0";
        public const string MenuWinWindow1 = "WinWindow1";
        public const string MenuWinWindow2 = "WinWindow2";
        public const string MenuWinWindow3 = "WinWindow3";
        public const string MenuWinWindow4 = "WinWindow4";
        public const string MenuWinWindow5 = "WinWindow5";
        public const string MenuWinWindow6 = "WinWindow6";
        public const string MenuWinWindow7 = "WinWindow7";
        public const string MenuWinWindow8 = "WinWindow8";
        public const string MenuWinWindow9 = "WinWindow9";
        public const string MenuWinMoreWindows = "WinMoreWindows";

        #endregion

        // --

        #region Help

        public const string MenuHelp = "Help";
        // --        
        public const string MenuAbout = "About";

        #endregion

        // --

        #region SECS1 To HSMS

        // ***
        // 2017.04.26 by spike.lee
        // SECS1 To HSMS Menu 추가
        // ***
        public const string MenuSecs1ToHsms = "Secs1ToHsms";
        // --
        public const string MenuSecs1ToHsmsEvent = "Secs1ToHsmsEvent";
        public const string MenuSecs1ToHsmsConverter = "Secs1ToHsmsConverter";
        public const string MenuSecs1ToHsmsConverterList = "Secs1ToHsmsConverterList";
        public const string MenuSecs1ToHsmsConverterStatus = "Secs1ToHsmsConverterStatus";
        public const string MenuSecs1ToHsmsConverterHistory = "Secs1ToHsmsConverterHistory";
        public const string MenuSecs1ToHsmsConverterMonitor = "Secs1ToHsmsConverterMonitor";
        public const string MenuSecs1ToHsmsConverterLogList = "Secs1ToHsmsConverterLogList";
        public const string MenuSecs1ToHsmsConverterBackupLogList = "Secs1ToHsmsConverterBackupLogList";

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Setup Menu
        // ***

        #region User Popup

        public const string MenuSetUserHistory = "User History";
        // --
        public const string MenuSetUsrPopupMenu = "UserPopupMenu";

        #endregion

        // --

        #region Server Popup

        public const string MenuSetServerStatus = "Server Status";
        public const string MenuSetServerHistory = "Server History";
        // --
        public const string MenuSetServerResourceStatus = "Server Resource Status";
        public const string MenuSetServerResourceComparison = "Server Resource Comparison";
        public const string MenuSetServerResourceAnalysis = "Server Resource Analysis";
        public const string MenuSetServerResourceHistory = "Server Resource History";
        // --
        public const string MenuSetServerMainSwitch = "Server Main Switch";
        public const string MenuSetServerBackupSwitch = "Server Backup Switch";
        // --
        public const string MenuSetAdminAgentLogList = "Admin Agent Log List";
        public const string MenuSetAdminAgentBackupLogList = "Admin Agent Backup Log List";
        // --
        public const string MenuSetSvrPopupMenu = "ServerPopupMenu";

        #endregion

        // --

        #region Package Popup

        public const string MenuSetPackageStatus = "Package Status";
        // --
        public const string MenuSetPkgPopupMenu = "PopupMenu";

        #endregion

        // --

        #region Model Popup

        public const string MenuSetModelStatus = "Model Status";
        // --
        public const string MenuSetMdlPopupMenu = "PopupMenu";

        #endregion

        // --

        #region Component Popup

        public const string MenuSetComponentStatus = "Component Status";
        // --
        public const string MenuSetComPopupMenu = "PopupMenu";

        #endregion

        // --

        #region MC Popup

        public const string MenuSetEapStatus = "EAP Status";
        public const string MenuSetEapHistory = "EAP History";
        // --
        public const string MenuSetEapRepositoryStatus = "EAP Repository Status";
        // --
        public const string MenuSetEapResourceHistory = "EAP Resource History";
        // --
        public const string MenuSetEapRelease = "EAP Release";
        // --
        public const string MenuSetEapStart = "EAP Start";
        public const string MenuSetEapStop = "EAP Stop";
        // --
        public const string MenuSetEapReload = "EAP Reload";
        public const string MenuSetEapRestart = "EAP Restart";
        public const string MenuSetEapAbort = "EAP Abort";
        // --
        public const string MenuSetEapMove = "EAP Move";
        // --
        public const string MenuSetEapLogList = "EAP Log List";
        public const string MenuSetEapBackupLogList = "EAP Backup Log List";
        // --
        public const string MenuSetEapInterfaceLogList = "EAP Interface Log List";
        public const string MenuSetEapInterfaceBackupLogList = "EAP Interface Backup Log List";
        // --
        public const string MenuSetEapReferenceSheet = "EAP Reference Sheet";
        // --
        public const string MenuSetEapPopupMenu = "PopupMenu";

        #endregion

        // --

        #region Equipment Popup

        public const string MenuSetEqpPopupMenu = "PopupMenu";

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Transaction Menu
        // ***

        #region Transaction Popup
        
        public const string MenuTrnEapRelease = "EAP Release";
        // --
        public const string MenuTrnEapStart = "EAP Start";
        public const string MenuTrnEapStop = "EAP Stop";
        // --
        public const string MenuTrnEapReload = "EAP Reload";
        public const string MenuTrnEapRestart = "EAP Restart";
        public const string MenuTrnEapAbort = "EAP Abort";
        // --
        public const string MenuTrnEapMove = "EAP Move";
        // --
        public const string MenuTrnPopupMenu = "PopupMenu";

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Monitoring Menu
        // ***

        #region MC Popup

        public const string MenuMonEapStatus = "EAP Status";
        public const string MenuMonEapHistory = "EAP History";
        // --
        public const string MenuMonEapRepositoryStatus = "EAP Repository Status";
        // --
        public const string MenuMonEapResourceHistory = "EAP Resource History";
        // --
        public const string MenuMonEapWizard = "EapWizard";
        // --
        public const string MenuMonNewEap = "New EAP";
        public const string MenuMonEapUpdate = "EAP Update";
        public const string MenuMonEapClone = "EAP Clone";
        public const string MenuMonEapDelete = "EAP Delete";
        // --
        public const string MenuMonEapRelease = "EAP Release";
        // --
        public const string MenuMonEapStart = "EAP Start";
        public const string MenuMonEapStop = "EAP Stop";
        // --
        public const string MenuMonEapReload = "EAP Reload";
        public const string MenuMonEapRestart = "EAP Restart";
        public const string MenuMonEapAbort = "EAP Abort";
        // --
        public const string MenuMonEapMove = "EAP Move";
        // --
        public const string MenuMonEapLogLevelSetup = "EAP Log Level Setup";
        // --
        public const string MenuMonEapLogList = "EAP Log List";
        public const string MenuMonEapBackupLogList = "EAP Backup Log List";
        // --77
        // ***
        // 2016.07.15 Jungyoul (WISOL)
        // ***
        public const string MenuMonEapInterfaceLogList = "EAP Interface Log List";
        public const string MenuMonEapInterfaceBackupLogList = "EAP Interface Backup Log List";
        // --
        public const string MenuMonEapReferenceSheet = "EAP Reference Sheet";
        // --
        public const string MenuMonEapModelDownload = "Model Download";
        // --
        public const string MenuMonEapPopupMenu = "EapPopupMenu";

        #endregion

        // --

        #region Issue Event Monitor

        public const string MenuMonIehRefresh = "Refresh";
        public const string MenuMonIehFreezeScreen = "Freeze Screen";

        #endregion

        // --

        #region Server Popup

        public const string MenuMonServerStatus = "Server Status";
        public const string MenuMonServerHistory = "Server History";
        // --
        public const string MenuMonServerResourceStatus = "Server Resource Status";
        public const string MenuMonServerResourceHistory = "Server Resource History";
        // --
        public const string MenuMonServerMainSwitch = "Server Main Switch";
        public const string MenuMonServerBackupSwitch = "Server Backup Switch";
        // --
        public const string MenuMonAdminAgentLogList = "Admin Agent Log List";
        public const string MenuMonAdminAgentBackupLogList = "Admin Agent Backup Log List";
        // --
        public const string MenuMonRemotePingTestByServer = "Remote Ping Test By Server";
        // --
        public const string MenuMonSvrPopupMenu = "ServerPopupMenu";

        #endregion

        // --

        #region Package Popup

        public const string MenuMonPackageStatus = "Package Status";
        // --
        public const string MenuMonPkgPopupMenu = "PackagePopupMenu";

        #endregion

        // --

        #region Model Popup

        public const string MenuMonModelStatus = "Model Status";
        // --
        public const string MenuMonMdlPopupMenu = "ModelPopupMenu";

        #endregion

        // --

        #region Component Popup

        public const string MenuMonComponentStatus = "Component Status";
        // --
        public const string MenuMonComPopupMenu = "ComponentPopupMenu";

        #endregion

        // --

        #region Equipment Popup

        public const string MenuMonEquipmentStatus = "Equipment Status";
        public const string MenuMonEquipmentHistory = "Equipment History";
        // --
        public const string MenuMonEquipmentGemStatus = "Equipment GEM Status";
        // --
        public const string MenuMonEquipmentEventDefineRequest = "Equipment Event Define Request";
        public const string MenuMonEquipmentVersionRequest = "Equipment Version Request";
        public const string MenuMonEquipmentControlModeRequest = "Equipment Control Mode Request";
        public const string MenuMonCustomRemoteCommandRequest = "Custom Remote Command Request";
        // --
        public const string MenuMonRemotePingTestByEquipment = "Remote Ping Test By Equipment";
        // --
        public const string MenuMonEqpPopupMenu = "EqpPopupMenu";

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Tool Menu
        // ***

        #region Admin Agent Option

        public const string MenuAaoRefresh = "Refresh";
        public const string MenuAaoUpdate = "Update";

        #endregion

        //--

        #region Admin Service Log List

        public const string MenuAslRefresh = "Refresh";
        public const string MenuAslExport = "Export";
        public const string MenuAslDownload = "Download";
        public const string MenuAslView = "View";
        // --
        public const string MenuAslPopupMenu = "PopupMenu";

        #endregion

        //--

        #region Admin Service Backup Log List

        public const string MenuSblRefresh = "Refresh";
        public const string MenuSblDownload = "Download";
        public const string MenuSblView = "View";
        // --
        public const string MenuSblPopupMenu = "PopupMenu";

        #endregion

        //--

        #region Admin Agent Log List

        public const string MenuAalRefresh = "Refresh";
        public const string MenuAalExport = "Export";
        public const string MenuAalDownload = "Download";
        public const string MenuAalView = "View";
        // --
        public const string MenuAalPopupMenu = "PopupMenu";

        #endregion

        //--

        #region Admin Agent Backup Log List

        public const string MenuAblRefresh = "Refresh";
        public const string MenuAblDownload = "Download";
        public const string MenuAblView = "View";
        // --
        public const string MenuAblPopupMenu = "PopupMenu";

        #endregion

        //--

        #region MC Log List

        public const string MenuEalRefresh = "Refresh";
        public const string MenuEalExport = "Export";
        public const string MenuEalDownload = "Download";
        public const string MenuEalView = "View";
        // --
        public const string MenuEalPrevious = "Previous";
        public const string MenuEalNext = "Next";
        // --
        public const string MenuEalPopupMenu = "PopupMenu";

        #endregion

        //--

        #region MC Backup Log List

        public const string MenuEblRefresh = "Refresh";
        public const string MenuEblDownload = "Download";
        public const string MenuEblView = "View";
        // --
        public const string MenuEblPopupMenu = "PopupMenu";

        #endregion

        //--

        #region Application Log Viewer

        public const string MenuAlvFind = "Find";
        public const string MenuAlvFontName = "Font Name";
        public const string MenuAlvFontSize = "Font Size";
        public const string MenuAlvRefresh = "Refresh";
        public const string MenuAlvPrevious = "Previous";
        public const string MenuAlvNext = "Next";

        #endregion

        //--

        #region Eap Log Viewer

        public const string MenuElvRefresh = "Refresh";
        // --
        public const string MenuElvPrevious = "Previous";
        public const string MenuElvNext = "Next";
        // --
        public const string MenuElvFind = "Find";
        public const string MenuElvFontName = "Font Name";
        public const string MenuElvFontSize = "Font Size";

        #endregion

        // --

        #region File Log Viewer

        public const string MenuFlvFind = "Find";
        public const string MenuFlvFontName = "Font Name";
        public const string MenuFlvFontSize = "Font Size";
        // --
        public const string MenuFlvRefresh = "Refresh";
        public const string MenuFlvPrevious = "Previous";
        public const string MenuFlvNext = "Next";

        #endregion

        //--

        #region Debug Log Viewer

        public const string MenuDlvFind = "Find";
        public const string MenuDlvFontName = "Font Name";
        public const string MenuDlvFontSize = "Font Size";
        // --
        public const string MenuDlvRefresh = "Refresh";
        public const string MenuDlvPrevious = "Previous";
        public const string MenuDlvNext = "Next";

        #endregion

        //--

        #region SECS Log Viewer

        public const string MenuSlvRefresh = "Refresh";
        // --
        public const string MenuSlvPrevious = "Previous";
        public const string MenuSlvNext = "Next";
        // --
        public const string MenuSlvExpand = "Expand";
        public const string MenuSlvCollapse = "Collapse";
        // --
        public const string MenuSlvCopy = "Copy";
        // --
        public const string MenuSlvConvertToSml = "ConvertToSml";
        public const string MenuSlvConvertToVfei = "ConvertToVfei";
        // --
        public const string MenuSlvConvertToSecsInterfaceLog = "ConvertToSecsInterfaceLog";
        // --
        public const string MenuSlvFilter = "Filter";        
        // --
        public const string MenuSlvPopupMenu = "PopupMenu";

        #endregion

        //--

        #region SECS Interface Log Viewer

        public const string MenuSivRefresh = "Refresh";
        // --
        public const string MenuSivPrevious = "Previous";
        public const string MenuSivNext = "Next";
        // --
        public const string MenuSivExpand = "Expand";
        public const string MenuSivCollapse = "Collapse";
        // --
        public const string MenuSivCopy = "Copy";
        // --
        public const string MenuSivSendMessage = "SendMessage";
        // --
        public const string MenuSivConvertToSml = "ConvertToSml";
        public const string MenuSivConvertToVfei = "ConvertToVfei";
        // --
        public const string MenuSivConvertToSecsLog = "ConvertToSecsLog";
        // --
        public const string MenuSivFontName = "Font Name";
        public const string MenuSivFontSize = "Font Size";
        // --
        public const string MenuSivPopupMenuGrid = "PopupMenuGrid";
        public const string MenuSivPopupMenuTree = "PopupMenuTree";

        #endregion

        //-- 

        #region PLC Log Viewer

        public const string MenuPlvRefresh = "Refresh";
        // --
        public const string MenuPlvPrevious = "Previous";
        public const string MenuPlvNext = "Next";
        // --
        public const string MenuPlvExpand = "Expand";
        public const string MenuPlvCollapse = "Collapse";
        public const string MenuPlvCopy = "Copy";        
        public const string MenuPlvConvertToVfei = "ConvertToVfei";
        public const string MenuPlvFilter = "Filter";
        // --
        public const string MenuPlvPopupMenu = "PopupMenu";

        #endregion

        //--

        #region OPC Log Viewer

        public const string MenuOlvRefresh = "Refresh";
        // --
        public const string MenuOlvPrevious = "Previous";
        public const string menuDlvNext = "Next";
        // --
        public const string MenuOlvExpand = "Expand";
        public const string MenuOlvCollapse = "Collapse";
        public const string MenuOlvCopy = "Copy";
        public const string MenuOlvCopyValues = "Copy Values";
        public const string MenuOlvConvertToVfei = "ConvertToVfei";
        public const string MenuOlvConvertToTrs = "ConvertToTRS";
        // --
        public const string MenuOlvConvertToOpcInterfaceLog = "ConvertToOpcInterfaceLog";
        // --
        public const string MenuOlvFilter = "Filter";
        public const string MenuOlvLogObjectViewer = "Log Object Viewer";
        // --
        public const string MenuOlvApplicationLogDisable = "Application Log Disable";
        public const string MenuOlvHostMessageLogDisable = "Host Message Log Disable";
        public const string MenuOlvOpcMessageLogDisable = "Opc Message Log Disable";
        public const string MenuOlvScenarioLogDisable = "Scenario Log Disable";
        // --
        public const string MenuOlvPopupMenu = "PopupMenu";

        #endregion

        // --

        #region OPC Interface Log Viewer

        public const string MenuOivRefresh = "Refresh";
        // --
        public const string MenuOivPrevious = "Previous";
        public const string MenuOivNext = "Next";
        // --
        public const string MenuOivExpand = "Expand";
        public const string MenuOivCollapse = "Collapse";
        // --
        public const string MenuOivCopy = "Copy";
        // --
        public const string MenuOivSendMessage = "SendMessage";
        // --
        public const string MenuOivConvertToVfei = "ConvertToVfei";
        // --
        public const string MenuOivConvertToOpcLog = "ConvertToOpcLog";
        //--
        public const string MenuOivFontName = "Font Name";
        public const string MenuOivFontSize = "Font Size";
        // --
        public const string MenuOivPopupMenuGrid = "PopupMenuGrid";
        public const string MenuOivPopupMenuTree = "PopupMenuTree";

        #endregion

        //--

        #region TCP Log Viewer

        public const string MenuTlvRefresh = "Refresh";
        // --
        public const string MenuTlvPrevious = "Previous";
        public const string MenuTlvNext = "Next";
        // --
        public const string MenuTlvExpand = "Expand";
        public const string MenuTlvCollapse = "Collapse";
        // --
        public const string MenuTlvCopy = "Copy";
        // --
        public const string MenuTlvConvertToXlg = "ConvertToXlg";
        public const string MenuTlvConvertToVfei = "ConvertToVfei";
        // --
        public const string MenuTlvConvertToTcpInterfaceLog = "ConvertToTcpInterfaceLog";
        // --
        public const string MenuTlvFilter = "Filter";
        // --
        public const string MenuTlvPopupMenu = "PopupMenu";

        #endregion

        // --

        #region TCP Interface Log Viewer

        public const string MenuTivRefresh = "Refresh";
        // --
        public const string MenuTivPrevious = "Previous";
        public const string MenuTivNext = "Next";
        // --
        public const string MenuTivExpand = "Expand";
        public const string MenuTivCollapse = "Collapse";
        // --
        public const string MenuTivCopy = "Copy";
        // --
        public const string MenuTivSendMessage = "SendMessage";
        // --
        public const string MenuTivConvertToXlg = "ConvertToXlg";
        public const string MenuTivConvertToVfei = "ConvertToVfei";
        // --
        public const string MenuTivConvertToTcpLog = "ConvertToTcpLog";
        // --
        public const string MenuTivFontName = "Font Name";
        public const string MenuTivFontSize = "Font Size";
        // --
        public const string MenuTivPopupMenuGrid = "PopupMenuGrid";
        public const string MenuTivPopupMenuTree = "PopupMenuTree";

        #endregion

        //--

        #region SML Log Viewer

        public const string MenuMlvRefresh = "Refresh";
        public const string MenuMlvFind = "Find";
        public const string MenuMlvFontName = "Font Name";
        public const string MenuMlvFontSize = "Font Size";
        public const string MenuMlvPrevious = "Previous";
        public const string MenuMlvNext = "Next";

        #endregion

        //--

        #region VFEI Log Viewer

        public const string MenuVlvRefresh = "Refresh";
        public const string MenuVlvFind = "Find";
        public const string MenuVlvFontName = "Font Name";
        public const string MenuVlvFontSize = "Font Size";
        public const string MenuVlvPrevious = "Previous";
        public const string MenuVlvNext = "Next";

        #endregion

        // --

        #region XLG Log Viewer

        public const string MenuXlvRefresh = "Refresh";
        public const string MenuXlvFind = "Find";
        public const string MenuXlvFontName = "Font Name";
        public const string MenuXlvFontSize = "Font Size";
        public const string MenuXlvPrevious = "Previous";
        public const string MenuXlvNext = "Next";

        #endregion

        //--

        #region TRS Log Viewer

        public const string MenuTrsFind = "Find";
        public const string MenuTrsFontName = "Font Name";
        public const string MenuTrsFontSize = "Font Size";

        #endregion

        //--

        #region Secs Binary Log Viewer

        public const string MenuBlvRefresh = "Refresh";
        public const string MenuBlvFind = "Find";
        public const string MenuBlvFontName = "Font Name";
        public const string MenuBlvFontSize = "Font Size";
        public const string MenuBlvPrevious = "Previous";
        public const string MenuBlvNext = "Next";

        #endregion

        // --

        #region Model Version Schema

        public const string MenuMvsModelStatus = "Model Status";
        // --
        public const string MenuMvsPopupMenu = "VersionPopupMenu";

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Inquiry Menu
        // ***

        #region Server Popup

        public const string MenuInqSvrStatus = "Server Status";
        public const string MenuInqSvrHistory = "Server History";
        public const string MenuInqSvrResourceStatus = "Server Resource Status";
        public const string MenuInqSvrResourceComparison = "Server Resource Comparison";
        public const string MenuInqSvrResourceAnalysis = "Server Resource Analysis";
        public const string MenuInqSvrResourceHistory = "Server Resource History";
        public const string MenuInqSvrMainSwitch = "Server Main Switch";
        public const string MenuInqSvrBackupSwitch = "Server Backup Switch";
        public const string MenuInqSvrAdminAgentLogList = "Admin Agent Log List";
        public const string MenuInqSvrAdminAgentBackupLogList = "Admin Agent Backup Log List";
        public const string MenuInqSvrRemotePingTest = "Remote Ping Test By Server";
        // --
        public const string MenuInqSvrPopupMenu = "ServerPopupMenu";

        #endregion

        // --

        #region MC Popup

        public const string MenuInqEapStatus = "EAP Status";
        public const string MenuInqEapHistory = "EAP History";
        // --
        public const string MenuInqEapRepositoryStatus = "EAP Repository Status";
        // --
        public const string MenuInqEapResourceHistory = "EAP Resource History";
        // --
        public const string MenuInqEapRelease = "EAP Release";
        // --
        public const string MenuInqEapStart = "EAP Start";
        public const string MenuInqEapStop = "EAP Stop";
        // --
        public const string MenuInqEapReload = "EAP Reload";
        // --
        public const string MenuInqEapRestart = "EAP Restart";
        public const string MenuInqEapAbort = "EAP Abort";
        // --
        public const string MenuInqEapMove = "EAP Move";
        // --
        public const string MenuInqEapLogList = "EAP Log List";
        public const string MenuInqEapBackupLogList = "EAP Backup Log List";
        // --
        public const string MenuInqEapInterfaceLogList = "EAP Interface Log List";
        public const string MenuInqEapInterfaceBackupLogList = "EAP Interface Backup Log List";
        // --
        public const string MenuInqEapReferenceSheet = "EAP Reference Sheet";
        // --
        public const string MenuInqEapPopupMenu = "EapPopupMenu";

        #endregion

        // --

        #region Equipment Popup

        public const string MenuInqEqpStatus = "Equipment Status";
        public const string MenuInqEqpHistory = "Equipment History";
        // --
        public const string MenuInqEqpGemStatus = "Equipment GEM Status";
        // --
        public const string MenuInqEqpEventDefineRequest = "Equipment Event Define Request";
        public const string MenuInqEqpVersionRequest = "Equipment Version Request";
        public const string MenuInqEqpControlModeRequest = "Equipment Control Mode Request";
        public const string MenuInqEqpCustomRemoteCommandRequest = "Custom Remote Command Request";
        // --
        public const string MenuInqEqpRemotePingTest = "Remote Ping Test By Equipment";
        // --
        public const string MenuInqEqpPopupMenu = "EqpPopupMenu";

        #endregion

        // --

        #region Package Popup

        public const string MenuInqPackageStatus = "Package Status";
        // --
        public const string MenuInqPkgPopupMenu = "PackagePopupMenu";

        #endregion

        // --

        #region Model Popup

        public const string MenuInqModelStatus = "Model Status";
        // --
        public const string MenuInqMdlPopupMenu = "ModelPopupMenu";

        #endregion

        // --

        #region Component Popup

        public const string MenuInqComponentStatus = "Component Status";
        // --
        public const string MenuInqComPopupMenu = "ComponentPopupMenu";

        #endregion

        // --

        #region Recent Notice

        public const string MenuRntRefresh = "Refresh";

        #endregion

        // --

        #region NoticeHistory

        public const string MenuNthRefresh = "Refresh";
        public const string MenuNthExport = "Export";

        #endregion

        // --

        #region Alarm Clear

        public const string MenuAlcRefresh = "Refresh";
        public const string MenuAlcExport = "Export";

        #endregion

        // --

        #region System Check List

        public const string MenuSclRefresh = "Refresh";
        public const string MenuSclExport = "Export";
        public const string MenuSclAutoRefresh = "AutoRefresh";

        #endregion

        // --

        #region Server List

        public const string MenuSvlRefresh = "Refresh";
        public const string MenuSvlExport = "Export";

        #endregion

        //--

        #region Server Status

        public const string MenuSvsRefresh = "Refresh";
        public const string MenuSvsExport = "Export";

        #endregion

        //--

        #region Server History

        public const string MenuSvhRefresh = "Refresh";
        public const string MenuSvhRefreshAll = "RefreshAll";
        public const string MenuSvhExport = "Export";

        #endregion

        //--

        #region Server Resource List

        public const string MenuSrlRefresh = "Refresh";
        public const string MenuSrlExport = "Export";

        #endregion

        //--

        #region Server Resource Status

        public const string MenuSrsRefresh = "Refresh";
        public const string MenuSrsExport = "Export";

        #endregion

        //--

        #region Server Resource Summary

        public const string MenuSrmRefresh = "Refresh";
        public const string MenuSrmExport = "Export";

        #endregion

        //--

        #region Server Resource History

        public const string MenuSrhRefresh = "Refresh";
        public const string MenuSrhExport = "Export";

        #endregion

        //--

        #region Package List

        public const string MenuPklRefresh = "Refresh";
        public const string MenuPklExport = "Export";

        #endregion

        //--

        #region Package Status

        public const string MenuPksRefresh = "Refresh";
        public const string MenuPksExport = "Export";

        #endregion

        //--

        #region Model List

        public const string MenuMdlRefresh = "Refresh";
        public const string MenuMdlExport = "Export";

        #endregion

        //--

        #region Model Status

        public const string MenuMdsRefresh = "Refresh";
        public const string MenuMdsExport = "Export";

        #endregion

        //--

        #region Model Version Schema

        public const string MenuMvsRefresh = "Refresh";
        public const string MenuMvsExport = "Export";

        #endregion

        //--

        #region Component List

        public const string MenuCplRefresh = "Refresh";
        public const string MenuCplExport = "Export";

        #endregion

        //--

        #region Component Status

        public const string MenuCpsRefresh = "Refresh";
        public const string MenuCpsExport = "Export";

        #endregion

        //--

        #region MC List

        public const string MenuEplRefresh = "Refresh";
        public const string MenuEplExport = "Export";

        #endregion

        //--

        #region MC Status

        public const string MenuEasRefresh = "Refresh";
        public const string MenuEasExport = "Export";

        #endregion

        //--

        #region MC History

        public const string MenuEahRefresh = "Refresh";
        public const string MenuEahRefreshAll = "RefreshAll";
        public const string MenuEahExport = "Export";

        #endregion

        //--

        #region MC List

        public const string MenuEnlRefresh = "Refresh";
        public const string MenuEnlExport = "Export";

        #endregion

        // --

        #region MC Repository Status

        public const string MenuEtsRefresh = "Refresh";
        // --
        public const string MenuEtsExpand = "Expand";
        public const string MenuEtsCollapse = "Collapse";
        // --
        public const string MenuEtsRepositoryRemove = "Repository Remove";
        public const string MenuEtsRepositoryClear = "Repository Clear";
        // --
        public const string MenuPopupMenuTree = "PopupMenuTree";

        #endregion

        //--

        #region MC Resource List

        public const string MenuErlRefresh = "Refresh";
        public const string MenuErlExport = "Export";

        #endregion

        // --

        #region MC Resource History

        public const string MenuErhRefresh = "Refresh";
        public const string MenuErhExport = "Export";

        #endregion

        // --

        #region MC Resource Comparison

        public const string MenuErcRefresh = "Refresh";
        public const string MenuErcExport = "Export";

        #endregion

        //--

        #region MC Reference Sheet

        public const string MenuErsRefresh = "Refresh";
        public const string MenuErsExport = "Export";
        public const string MenuErsDownload = "Download";

        #endregion

        // --

        #region Equipment List

        public const string MenuEqlRefresh = "Refresh";
        public const string MenuEqlExport = "Export";

        #endregion

        // --

        #region Equipment Status

        public const string MenuEqsRefresh = "Refresh";
        public const string MenuEqsExport = "Export";

        #endregion

        //--

        #region Equipment History

        public const string MenuEqhRefresh = "Refresh";
        public const string MenuEqhRefreshAll = "RefreshAll";
        public const string MenuEqhExport = "Export";

        #endregion

        //--

        #region Equipment GEM Status

        public const string MenuEgsRefresh = "Refresh";
        public const string MenuEgsExport = "Export";
        // --
        public const string MenuEgsExpand = "Expand";
        public const string MenuEgsCollapse = "Collapse";
        // --
        public const string MenuEgsPopupMenuTree = "PopupMenuTree";

        #endregion

        //--

        #region User History

        public const string MenuUshRefresh = "Refresh";
        public const string MenuUshRefreshAll = "RefreshAll";
        public const string MenuUshExport = "Export";

        #endregion

        // --

        #region Issue Event Summary

        public const string MenuIesRefresh = "Refresh";
        // --
        public const string MenuIesPrevious = "Previous";
        public const string MenuIesNext = "Next";
        // --
        public const string MenuIesExport = "Export";

        #endregion

        // --

        #region Issue Event Summary

        public const string MenuOerRefresh = "Refresh";
        // --
        public const string MenuOerPrevious = "Previous";
        public const string MenuOerNext = "Next";
        // --
        public const string MenuOerExport = "Export";

        #endregion

        // --

        #region Server Issue Event Summary

        public const string MenuSisRefresh = "Refresh";
        // --
        public const string MenuSisPrevious = "Previous";
        public const string MenuSisNext = "Next";
        // --
        public const string MenuSisExport = "Export";

        #endregion

        // --

        #region MC Issue Event Summary

        public const string MenuEisRefresh = "Refresh";
        // --
        public const string MenuEisPrevious = "Previous";
        public const string MenuEisNext = "Next";
        // --
        public const string MenuEisExport = "Export";

        #endregion

        // --

        #region Equipment Issue Event Summary

        public const string MenuQisRefresh = "Refresh";
        // --
        public const string MenuQisPrevious = "Previous";
        public const string MenuQisNext = "Next";
        // --
        public const string MenuQisExport = "Export";

        #endregion

        // --

        #region Server Issue Event History

        public const string MenuSihRefresh = "Refresh";
        // --
        public const string MenuSihExport = "Export";

        #endregion

        // --

        #region MC Issue Event History

        public const string MenuEihRefresh = "Refresh";
        // --
        public const string MenuEihExport = "Export";

        #endregion

        // --

        #region Equipment Issue Event History

        public const string MenuQihRefresh = "Refresh";
        // --
        public const string MenuQihExport = "Export";

        #endregion

        // --

        #region SECS1 To HSMS Converetr

        public const string MenuS2HCvtPopupMenu = "PopupMenu";

        #endregion

        // --

        #region SECS1 To HSMS Convereter List

        // ***
        // 2017.04.24 by spike.lee
        // SECS1 To HSMS Convereter List Menu Key 추가
        // ***
        public const string MenuS2HCvtListRefresh = "Refresh";
        public const string MenuS2HCvtListExport = "Export";
        // --
        public const string MenuS2HCvtListPopupMenu = "PopupMenu";

        #endregion

        // --

        #region SECS1 To HSMS Convereter Status

        // ***
        // 2017.04.28 by spike.lee
        // SECS1 To HSMS Convereter Status Menu Key 추가
        // ***
        public const string MenuS2HCvtStatusRefresh = "Refresh";
        public const string MenuS2HCvtStatusExport = "Export";

        #endregion

        // --

        #region SECS1 To HSMS Converter Log List

        public const string MenuS2HCvtLogListRefresh = "Refresh";
        public const string MenuS2HCvtLogListExport = "Export";
        public const string MenuS2HCvtLogListDownload = "Download";
        public const string MenuS2HCvtLogListView = "View";
        // --
        public const string MenuS2HCvtLogListPopupMenu = "PopupMenu";

        #endregion

        // --

        #region SECS1 To HSMS Converter Monitor

        public const string MenuS2HCvtMonitorPopupMenu = "PopupMenu";

        #endregion

        // --

        #region SECS1 to HSMS Converetr Log Viewer

        public const string MenuS2HCvtLogViewerRefresh = "Refresh";
        public const string MenuS2HCvtLogViewerPrevious = "Previous";
        public const string MenuS2HCvtLogViewerNext = "Next";
        public const string MenuS2HCvtLogViewerFind = "Find";
        public const string MenuS2HCvtLogViewerFontName = "Font Name";
        public const string MenuS2HCvtLogViewerFontSize = "Font Size";

        #endregion

        // --

        #region SECS1 To HSMS Converter Backup Log List

        public const string MenuS2HCvtBackupLogRefresh = "Refresh";
        public const string MenuS2HCvtBackupLogDownload = "Download";
        public const string MenuS2HCvtBackupLogView = "View";
        // --
        public const string MenuS2HCvtBackupLogPopupMenu = "PopupMenu";

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Dialog Menu
        // ***

        #region TCP Host Message Sender 

        public const string MenuThsOpen = "Open";

        #endregion

        // --

        #region OPC Host Message Sender 

        public const string MenuOhsOpen = "Open";

        #endregion

        // --

        #region SECS Host Message Sender 

        public const string MenuShsOpen = "Open";

        #endregion

        #region File Eap Wizard Host Device

        public const string MenuFwhCopy = "Copy";
        public const string MenuFwhCut = "Cut";
        public const string MenuFwhPasteSibling = "Paste Sibling";
        public const string MenuFwhPasteChild = "Paste Child";
        public const string MenuFwhAppendHostDevice = "Append Host Device";
        public const string MenuFwhInsertBeforeHostDevice = "Insert Before Host Device";
        public const string MenuFwhInsertAfterHostDevice = "Insert After Host Device";
        public const string MenuFwhHdrPopUp = "HdrPopUpMenu";
        public const string MenuFwhHdvPopUp = "HdvPopUpMenu";
        public const string MenuFwhHdvRemove = "Remove Host Device";



        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
