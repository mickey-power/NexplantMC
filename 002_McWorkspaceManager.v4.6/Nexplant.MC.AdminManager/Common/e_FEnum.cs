/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : e_FEnum.cs
--  Creator         : mj.kim
--  Create Date     : 2012.01.11
--  Description     : FAMate Admin Manager Enumerator Class 
--  History         : Created by mj.kim at 2012.01.11
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.AdminManager
{

    //------------------------------------------------------------------------------------------------------------------------

    public enum FBackupMode : int
    {
        Manual,
        Auto
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FPackageFileType : int
    {
        Execution = 0,
        Etc = 1
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FAllAuthority : int
    {
        No = 0,
        Yes = 1
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FLogType : int
    {
        All,
        Application,
        Debug
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FEapLogType : int
    {
        All,
        SECS,
        SML,
        //PLC,
        OPC,
        TCP,
        XLG,
        Binary,
        VFEI,
        Debug,        
        Log,
        WLG
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FExtensionType : int 
    {
        log,
        dlg,
        ssl,
        //psl,
        osl,
        tsl,
        bng,
        sml,
        xlg,
        vfe,
        wlg
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FLogFileType : int
    {
        AdminServiceLogFile,
        AdminAgentLogFile,
        AlertServiceLogFile,
        EapLogFile,
        // ***
        // 2017.05.12 by spike.lee
        // SECS1 To HSMS Converter Log Type 추가
        // ***
        Secs1ToHsmsConverter
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FEapAttrCategory : int
    {
        Setup,
        Released,
        Applied
    }

    //------------------------------------------------------------------------------------------------------------------------

    internal enum FEquipmentControlMode : int
    {
        Offline,
        OnlineLocal,
        OnlineRemote
    }

    //------------------------------------------------------------------------------------------------------------------------

    internal enum FEquipmentCommState : int
    {
        Connect,
        Disconnect
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FEapWizardMode : int
    {
        New,
        Update,
        Clone
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FUpDown : int
    {
        Down = 0,
        Up = 1
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FEapStatusEnum : int
    {
        Main,
        Backup
    }

    //------------------------------------------------------------------------------------------------------------------------

    internal enum FEapNeedAction : int
    {
        Release,
        Reload,
        Restart
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FServerStatusEnum : int
    {
        Main,
        Backup
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FGeneralCodeFormat : int
    {
        Ascii,
        Number,
        Double
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FAdminAgentOptionCategory : int
    {
        General,
        Highway101,
        DetectionPolicy,
        ResourceCollectionPolicy,
        LogPolicy
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FDatabaseErrorType
    {
        MsSqlServerCriticalError,
        MsSqlServerWarningError,
        OracleCriticalError,
        OracleWarningError
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FMonitoringDataType : int
    {
        Update,
        Delete
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FUserFunction : int
    {
        PasswordChange,
        // --
        Factory,
        Notice,
        GeneralCode,
        Event,
        UserGroupApplication,
        UserGroup,
        User,
        Server,
        HostDriver,
        Package,
        Model,
        ModelSheet,
        Component,
        SecsModelObjectName,
        SecsModelFunctionName,
        SecsModelUserTagName,
        //PlcModelObjectName,
        //PlcModelFunctionName,
        //PlcModelUserTagName,
        OpcModelObjectName,
        OpcModelFunctionName,
        OpcModelUserTagName,
        TcpModelObjectName,
        TcpModelFunctionName,
        TcpModelUserTagName,
        Maker,
        EquipmentType,
        EquipmentArea,
        EquipmentLine,
        EquipmentCommand,
        Equipment,
        InlineEquipment,
        CustomRemoteCommand,        
        Eap,        
        // --
        EapBatchModification,
        EapRelease,
        EapStart,
        EapStop,
        EapReload,
        EapRestart,
        EapAbort,
        EapMove,        
        EapLogLevelSetup,   // 2017.07.04 by spike.lee add
        ServerMainSwitch,
        ServerBackupSwitch,
        AlarmClear,
        // --
        EapMonitor,
        EquipmentMonitor,
        IssueEventMonitor,  // 2017.07.14 by spike.lee add
        EapLogList,
        EapBackupLogList,
        // ***
        // 2017.06.02 by spike.lee
        // Interface Log 관련 Function 추가
        // ***
        EapInterfaceLogList,
        EapInterfaceBackupLogList,
        // ***
        AdminServiceLogList,
        AdminServiceBackupLogList,
        AdminAgentLogList,
        AdminAgentBackupLogList,        
        AlertServiceLogList,
        AlertServiceBackupLogList,        
        ModelVersionSchema,
        AdminAgentOption,
        // --
        EquipmentEventDefineRequest,
        EquipmentVersionRequest,
        EquipmentControlModeRequest,
        CustomRemoteCommandRequest,
        RemotePingTestByServer,
        RemotePingTestByEquipment,
        // --
        // ***
        // 2017.04.21 by spike.lee
        // SECS1 To HSMS Menu 추가
        // ***
        Secs1ToHsmsEvent,
        Secs1ToHsmsConverter,
        Secs1ToHsmsConverterList,
        Secs1ToHsmsConverterStatus,
        Secs1ToHsmsConverterHistory,
        Secs1ToHsmsConverterMonitor,
        Secs1ToHsmsConverterLogList,
        Secs1ToHsmsConverterBackupLogList,
        // --
        RecentNotice,
        NoticeHistory,
        SystemCheckList,
        ServerList,
        ServerStatus,
        ServerHistory,
        ServerResourceList,
        ServerResourceStatus,
        ServerResourceComparison,
        ServerResourceAnalysis,
        ServerResourceHistory,
        PackageList,
        PackageStatus,
        ModelList,
        ModelStatus,
        ComponentList,
        ComponentStatus,
        EapList,
        EapStatus,
        EapHistory,
        // ***
        // 2017.06.02 by spike.lee
        // EAP Repository Status 메뉴 추가
        // ***
        EapRepositoryStatus,
        // ***
        EapNeedActionList,
        EapResourceList,
        EapResourceHistory,
        EapResourceSummary,
        EapReferenceSheet,
        EquipmentList,
        EquipmentStatus,
        EquipmentHistory,
        EquipmentGemStatus,
        UserHistory,
        // ***
        // 2017.07.18 by spike.lee
        // ***
        IssueEventSummary,
        ServerIssueEventSummary,
        EapIssueEventSummary,
        EquipmentIssueEventSummary,
        ServerIssueEventHistory,
        EapIssueEventHistory,
        EquipmentIssueEventHistory,
        ServerIssueEventTotal,
        EapIssueEventTotal,
        EquipmentIssueEventTotal,
        // --
        OverallIssueEventReport
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FEquipmentPrimaryState : int
    {
        IDLE,
        RUN,
        DOWN,
        POWER_OFF
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FEventType : int
    {
        User,
        Server,
        MC,
        Equipment
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FAlarmLevel : int
    {
        Highest,
        High,
        Low,
        Lowest
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FModelObjectUserTag : int
    {
        UserTagName1,
        UserTagName2,
        UserTagName3,
        UserTagName4,
        UserTagName5
    }

    //------------------------------------------------------------------------------------------------------------------------   

    public enum FSystemCode
    {
        ADM,
        BIS,
        OEE,
        PMS,
        RMS
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FServerResourceType : int
    {
        Cpu,
        Memory,
        Disk
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FEapType : int
    {
        SECS,
        //PLC,
        OPC,
        TCP,
        FILE,   // 2017.06.21 by spike.lee add (File Parser EAP Type)
        CHD,// Custom Host Driver
        Process
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FModelType : int
    {
        SECS,
        //PLC,
        OPC,
        TCP
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FServerType : int
    {
        Real,
        Virtual
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FEapOperationMode : int
    {
        Server,
        Client
    }

    //------------------------------------------------------------------------------------------------------------------------    

    public enum FProcessMode : int
    {
        SingleLot,
        MultiLot,
        MixLot
    }

    //------------------------------------------------------------------------------------------------------------------------    

    public enum FRecipeType : int
    {
        Parameter,
        File,
        ParameterAndFile
    }

    //------------------------------------------------------------------------------------------------------------------------    

    public enum FQtyUnit : int
    {
        Panel,
        Strip
    }

    //------------------------------------------------------------------------------------------------------------------------    

    public enum FAutoRecipeMode : int
    {
        Spec,
        Generate
    }

    //------------------------------------------------------------------------------------------------------------------------    

    public enum FRecipeDownloadRule : int
    {
        FwLotRecipe,
        FwItemRecipe,
        WoLotRecipe,
        WoItemRecipe,
        StandardRecipe,
        NotUsed
    }

    //------------------------------------------------------------------------------------------------------------------------    

    public enum FStandardRecipeRule : int
    {
        Master,
        Equipment,
        MasterOrEquipment
    }

    //------------------------------------------------------------------------------------------------------------------------    

    public enum FEquipmentClass : int
    {
        Standalone,
        InlineMain,
        InlineSub
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FLotCancelRule : int
    {
        Single,
        Multi
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FRecipeCreationMode : int
    {
        NotUsed,
        BaseParameter,
        BaseRecipe
    }

    //------------------------------------------------------------------------------------------------------------------------

    // ***
    // 2017.04.24 by spike.lee
    // SECS1 To HSMS Converter에서 HSMS Connect Mode를 셋업하기 위해 추가
    // ***
    public enum FS2HConnectMode : int
    {
        Active,
        Passive
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FStartStop : int
    {
        Start,
        Stop
    }

    //------------------------------------------------------------------------------------------------------------------------

    // ***
    // 2017.04.24 by spike.lee
    // SECS1 To HSMS Converter의 SECS1 State, HSMS State를 처리를 위해 추가
    // ***
    public enum FCommunicationState : int
    {
        Closed,
        Opened,
        Connected,
        Selected
    }

    //------------------------------------------------------------------------------------------------------------------------

    // ***
    // 2017.05.18 by spike.lee
    // Previous, Next Log 요청 구분
    // ***
    public enum FLogContinuity : int
    {
        Previous,
        Next
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FFileDeviceType : int
    {
        NetWork = 0,
        Backup = 1,
        Error = 2
    }
    
    //------------------------------------------------------------------------------------------------------------------------

    public enum FParsingType : int
    {
        Xml,
        Json
    }
    //------------------------------------------------------------------------------------------------------------------------

}   // Namespace end
