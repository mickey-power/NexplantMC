/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : e_FEnum.cs
--  Creator         : spike.lee
--  Create Date     : 2015.06.16
--  Description     : FAMate Core FaOpcDriver Enumerator Definition
--  History         : Created by spike.lee at 2015.06.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaOpcDriver
{

    //------------------------------------------------------------------------------------------------------------------------

    public enum FOpcRunMode : int
    {
        WorkspaceManager,
        Eap
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FStringOption : int
    {
        Default,
        Detail
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FObjectType : int
    {
        OpcDriver,
        // --
        ObjectNameList,
        ObjectName,
        FunctionNameList,
        FunctionName,
        ParameterName,
        Argument,
        UserTagName,
        DataConversionSetList,
        DataConversionSet,
        DataConversion,
        EquipmentStateSetList,
        EquipmentStateSet,
        EquipmentState,
        EquipmentStateMaterial,
        StateValue,
        RepositoryList,
        Repository,
        RepositoryMaterial,
        Column,
        EnvironmentList,
        Environment,
        DataSetList,
        DataSet,
        Data,
        // --
        OpcLibraryGroup,
        OpcLibrary,
        OpcMessageList,
        OpcMessages,
        OpcMessage,        
        OpcEventItemList,
        OpcEventItem,
        OpcItemList,
        OpcItem,
        OpcMessageTransfer,
        // --
        OpcReadMessage,
        OpcWriteMessage,
        // --
        OpcDevice,
        OpcSession,
        ItemName,
        // --
        HostLibraryGroup,
        HostLibrary,
        HostMessageList,
        HostMessages,
        HostMessage,
        HostItem,
        HostMessageTransfer,
        HostDriverDataMessage,
        // --
        HostDevice,
        HostSession,
        // --
        Equipment,
        ScenarioGroup,
        Scenario,
        OpcTrigger,
        OpcCondition,
        OpcExpression,
        OpcTransmitter,
        OpcTransfer,
        HostTrigger,
        HostCondition,
        HostExpression,
        HostTransmitter,
        HostTransfer,
        EquipmentStateSetAlterer,
        EquipmentStateAlterer,
        Judgement,
        JudgementCondition,
        JudgementExpression,
        Mapper,
        Storage,
        Callback,    
        Function,
        Branch,
        Comment,
        Pauser,
        EntryPoint
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FObjectLogType : int
    {
        OpcDriverLog,
        // --
        OpcDeviceStateChangedLog,
        OpcDeviceErrorRaisedLog,
        OpcDeviceTimeoutRaisedLog,        
        OpcDeviceDataMessageReadLog,
        OpcDeviceDataMessageWrittenLog,
        OpcEventItemListLog,
        OpcEventItemLog,
        OpcItemListLog,
        OpcItemLog,
        // --
        HostDeviceStateChangedLog,
        HostDeviceErrorRaisedLog,
        HostDeviceVfeiReceivedLog,
        HostDeviceVfeiSentLog,
        HostDeviceDataMessageReceivedLog,
        HostDeviceDataMessageSentLog,
        HostItemLog,
        // --
        OpcTriggerRaisedLog,
        OpcTransmitterRaisedLog,
        HostTriggerRaisedLog,
        HostTransmitterRaisedLog,
        EquipmentStateSetAltererPerformedLog,
        EquipmentStateAltererLog,
        JudgementPerformedLog,
        MapperPerformedLog,
        DataSetLog,
        DataLog,
        StoragePerformedLog,
        RepositoryLog,
        ColumnLog,
        CallbackRaisedLog,
        FunctionCalledLog,
        BranchRaisedLog,
        CommentWrittenLog,
        PauserRaisedLog,
        EntryPointCalledLog,
        // --
        ApplicationWrittenLog,
        ContentLog
    }

    //------------------------------------------------------------------------------------------------------------------------

    internal enum FEventId : int
    {
        None,
        // --        
        ModelingFileOpenCompleted,
        ModelingFileReopenCompleted,
        ModelingFileReopenFailed,
        ModelingFileSaveCompleted,
        // --
        ObjectModifyCompleted,
        ObjectAppendCompleted,
        ObjectInsertBeforeCompleted,
        ObjectInsertAfterCompleted,
        ObjectRemoveCompleted,
        ObjectMoveUpCompleted,
        ObjectMoveDownCompleted,
        ObjectMoveToCompleted,
        // --
        OpcDeviceStateChanged,
        OpcDeviceErrorRaised,
        OpcDeviceTimeoutRaised,        
        OpcDeviceDataMessageRead,
        OpcDeviceDataMessageWritten,
        // --
        OpcSessionItemNameRefreshed,
        // --
        HostDeviceStateChanged,
        HostDeviceErrorRaised,
        HostDeviceVfeiReceived,
        HostDeviceVfeiSent,
        HostDeviceDataMessageReceived,
        HostDeviceDataMessageSent,
        // --
        OpcTriggerRaised,
        OpcTransmitterRaised,
        HostTriggerRaised,
        HostTransmitterRaised,
        EquipmentStateSetAltererPerformed,
        JudgementPerformed,
        MapperPerformed,
        StoragePerformed,
        CallbackRaised,
        BranchRaised,
        FunctionCalled,
        CommentWritten,
        PauserRaised,
        EntryPointCalled,
        // --
        ApplicationWritten,
        // ***
        // 2017.05.31 by spike.lee 추가
        // Repository Saved Event
        // ***
        RecpsitoryMaterialSaved
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FLibraryType : int
    {
        OpcLibrary = FObjectType.OpcLibrary,
        HostLibrary = FObjectType.HostLibrary
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FDeviceType : int
    {
        OpcDevice = FObjectType.OpcDevice,
        HostDevice = FObjectType.HostDevice
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FSessionType : int
    {
        OpcSession = FObjectType.OpcSession,
        HostSession = FObjectType.HostSession
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FConnectMode : int
    {
        Active,
        Passive
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FProtocol : int
    {
        KEPWARE,
        OPCDA,
        OPCUA
    }

    //------------------------------------------------------------------------------------------------------------------------

    internal enum FProtocolType : int
    {
        KEPWARE,
        OPCDA,
        OPCUA,
        HOST
    }

    //------------------------------------------------------------------------------------------------------------------------
    // ***
    // 2019.06.27 at Sunghoon.Park Kepware Security Policy 지원
    // ***
    public enum FSecurityPolicy : int
    {
        None,
        Basic128Rsa15,
        Basic256
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FSecurityMode : byte
    {
        Sign = 2,
        SignAndEncrypt =3
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FDeviceState : int
    {
        Closed,
        Opened,
        Connected,
        Selected,
        Undefined,
        ErrorShutdown,
        ErrorWatchDog
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FSessionState : int
    {
        Closed,
        Opened,
        Connected,
        Selected
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FDirection : int
    {
        Equipment,
        Host,
        Both
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FOpcDirection : int
    {
        Read,
        Write
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FFormat : int
    {
        List = 0,       // Oct: 00
        AsciiList = 1,  // Oct: 01
        Binary = 8,     // Oct: 10
        Boolean = 9,    // Oct: 11
        Ascii = 16,     // Oct: 20
        JIS8 = 17,      // Oct: 21
        A2 = 18,        // Oct: 22
        I8 = 24,        // Oct: 30
        I4 = 28,        // Oct: 34
        I2 = 26,        // Oct: 32
        I1 = 25,        // Oct: 31
        F8 = 32,        // Oct: 40
        F4 = 36,        // Oct: 44
        U8 = 40,        // Oct: 50
        U4 = 44,        // Oct: 54
        U2 = 42,        // Oct: 52
        U1 = 41,        // Oct: 51
        Unknown = 63,   // Oct: 77
        Raw = 64        // Oct: 78
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FFormatShortName : int
    {
        L = 0,          // Oct: 00
        AL = 1,         // Oct: 01
        B = 8,          // Oct: 10
        BL = 9,         // Oct: 11
        A = 16,         // Oct: 20
        J8 = 17,        // Oct: 21
        A2 = 18,        // Oct: 22
        I8 = 24,        // Oct: 30
        I4 = 28,        // Oct: 34
        I2 = 26,        // Oct: 32
        I1 = 25,        // Oct: 31
        F8 = 32,        // Oct: 40
        F4 = 36,        // Oct: 44
        U8 = 40,        // Oct: 50
        U4 = 44,        // Oct: 54
        U2 = 42,        // Oct: 52
        U1 = 41,        // Oct: 51
        UN = 63,        // Oct: 77
        R = 64          // Oct: 78
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FOpcFormat : int
    {
        Binary = 8,     // Oct: 10
        Boolean = 9,    // Oct: 11
        Ascii = 16,     // Oct: 20
        I8 = 24,        // Oct: 30
        I4 = 28,        // Oct: 34
        I2 = 26,        // Oct: 32
        I1 = 25,        // Oct: 31
        F8 = 32,        // Oct: 40
        F4 = 36,        // Oct: 44
        U8 = 40,        // Oct: 50
        U4 = 44,        // Oct: 54
        U2 = 42,        // Oct: 52
        U1 = 41         // Oct: 51
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FOpcFormatShortName : int
    {
        B = 8,          // Oct: 10
        BL = 9,         // Oct: 11
        A = 16,         // Oct: 20
        I8 = 24,        // Oct: 30
        I4 = 28,        // Oct: 34
        I2 = 26,        // Oct: 32
        I1 = 25,        // Oct: 31
        F8 = 32,        // Oct: 40
        F4 = 36,        // Oct: 44
        U8 = 40,        // Oct: 50
        U4 = 44,        // Oct: 54
        U2 = 42,        // Oct: 52
        U1 = 41         // Oct: 51
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FTagFormat : int
    {
        Boolean = 9,
        // DBB = 500, 
        // DBW = 501,
        // DBD = 502,
        Char = 100,
        Byte = 41,
        Short = 26,
        Word = 42,
        Long = 24,
        DWord = 44,
        Float = 36,
        Double = 32,
        String = 16,
        BCD = 200,
        LBCD = 300,
        Date = 400
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FTagFormatShortName : int
    {
        BL = 9,
        // DBB = 500,
        // DBW = 501,
        // DBD = 502,
        C = 100,
        BT = 41,
        ST = 26,
        W = 42,
        L = 24,
        DW = 44,
        F = 36,
        D = 32,
        S = 16,
        B = 200,
        LB = 300,
        DT = 400
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FSecsLengthBytes : int
    {
        Auto,
        Byte1,
        Byte2,
        Byte3
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FDeviceMode : int
    {
        Equipment,
        Host,
        Both
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FMessageTransferType : int
    {
        OpcMessageTransfer = FObjectType.OpcMessage,
        HostMessageTransfer = FObjectType.HostMessage
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FHostMessageType : int
    {
        Command,
        Unsolicited,
        Reply
    }
    
    //------------------------------------------------------------------------------------------------------------------------

    public enum FHostOperandType : int
    {
        HostItem = FObjectType.HostItem,
        Environment = FObjectType.Environment,
        EquipmentState = FObjectType.EquipmentState
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FOperandIndexType : int
    {
        All,
        Position
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FOperandIndexOption : int
    {
        And,
        Or
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FOperandValueType : int
    {
        Value,
        Data
    }   

    //------------------------------------------------------------------------------------------------------------------------

    public enum FPattern : int
    {
        Fixed,
        Variable
    }

    //------------------------------------------------------------------------------------------------------------------------
    
    public enum FDataScanMode : int
    {
        Local,
        Global
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FMessageType : int
    {
        OpcMessage = FObjectType.OpcMessage,
        HostMessage = FObjectType.HostMessage
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FMessageLogType : int
    {
        OpcDeviceDataMessageReadLog = FObjectLogType.OpcDeviceDataMessageReadLog,
        OpcDeviceDataMessageWrittenLog = FObjectLogType.OpcDeviceDataMessageWrittenLog,
        HostDeviceDataMessageReceivedLog = FObjectLogType.HostDeviceDataMessageReceivedLog,
        HostDeviceDataMessageSentLog = FObjectLogType.HostDeviceDataMessageSentLog        
    }       

    //------------------------------------------------------------------------------------------------------------------------

    public enum FTransferType : int
    {
        OpcTransfer = FObjectType.OpcTransfer,
        HostTransfer = FObjectType.HostTransfer
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FFlowType : int
    {
        OpcTrigger = FObjectType.OpcTrigger,
        OpcTransmitter = FObjectType.OpcTransmitter,        
        HostTrigger = FObjectType.HostTrigger,
        HostTransmitter = FObjectType.HostTransmitter,
        EquipmentStateSetAlterer = FObjectType.EquipmentStateSetAlterer,
        Judgement = FObjectType.Judgement,
        Mapper = FObjectType.Mapper,
        Storage = FObjectType.Storage,
        Callback = FObjectType.Callback,
        Branch = FObjectType.Branch,
        Comment = FObjectType.Comment,
        Pauser = FObjectType.Pauser,
        EntryPoint = FObjectType.EntryPoint
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FHostDriverState : int
    {
        Closed,
        Opened,
        Connected,
        Selected
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FResultCode : int
    {
        Success,
        Warninig,
        Error,
        CriticalError
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FLogical : int
    {
        And,
        Or
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FExpressionType : int
    {
        Bracket,
        Comparison
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FExpressionValueType : int
    {
        Value,
        Resource
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FAutoCycleAction : int
    {
        Once,
        Repeat
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FValueFormulaType : int
    {
        Choose,
        ChooseR,
        ChooseIncluded,
        ChooseIncludedR,
        DateTime,
        DecimalToHex,   // 2017.03.27 by spike.lee add
        FixLength,
        FixLengthR,
        HexToDecimal,   // 2017.03.27 by spike.lee add
        Insert,
        InsertR,
        Length,
        PadLeft,
        PadRight,
        Prefix,
        Remove,
        RemoveR,
        Replace,
        Select,
        SelectR,
        SelectIncluded,
        SelectIncludedR,
        SubString,
        SubStringR,
        SelectArray,
        SelectArrayR,
        StringCount,
        Suffix,
        ToBit,
        ToLower,
        ToUpper,
        Trim,
        TrimAll, // 개행 문자를 포함하여 Trim 시키기 위해 추가
        TrimStart,
        TrimEnd,
        // --
        Add,         // 더하기
        Subtract,    // 빼기
        Multiply,    // 곱하기
        Divide,      // 나누기
        Round,       // 반올림
        Trunc,       // 버림
        Ceil,        // 올림
        Mod          // 나머지
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FConditionMode : int
    {
        Expression,
        Timeout,
        Connection
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FOpcConditionMode : int
    {
        Expression = FConditionMode.Expression,
        Connection = FConditionMode.Connection
    }
    
    //------------------------------------------------------------------------------------------------------------------------

    public enum FOperation : int
    {
        Equal,
        NotEqual,
        MoreThan,
        MoreThanOrEqual,
        LessThan,
        LessThanOrEqual
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FComparisonMode : int
    {
        Length,
        Value
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FConversionMode : int
    {
        Value,
        Range
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FHostResourceSourceType : int
    {
        None,
        EapName,
        EquipmentName,
        HostDeviceName,
        HostSessionName,
        HostSessionId,
        HostMachineId
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FOpcMessageType : int
    {
        OpcReadMessage = FObjectType.OpcReadMessage,
        OpcWriteMessage = FObjectType.OpcWriteMessage
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FOpcResourceSourceType : int
    {
        None,
        EapName,
        EquipmentName,
        OpcDeviceName,
        OpcSessionName,
        OpcSessionId
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FOpcOperandType : int
    {
        OpcItem = FObjectType.OpcItem,
        OpcEventItem = FObjectType.OpcEventItem,
        Environment = FObjectType.Environment,
        EquipmentState = FObjectType.EquipmentState
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FStorageAction : int
    {
        Create,
        Select,
        Update,         // 2017.04.03 by spike.lee Update 구현
        Remove,
        RemoveAll       // 2017.03.31 by spike.lee Remove All 구현
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FPauserMode : int
    {
        Fixed,
        Random
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FErrorAction : int
    {
        Stop,
        Ignore
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FDataSourceType : int
    {
        Constant,
        Resource,
        EquipmentState,
        Environment,
        Column,
        Item,
        ItemName,
        ItemTag1,
        ItemTag2,
        ItemTag3,
        ItemTag4,
        ItemTag5
    }

    //------------------------------------------------------------------------------------------------------------------------
    
    public enum FDataTargetType : int
    {
        Constant,
        Column,
        Item
    }
    

    //------------------------------------------------------------------------------------------------------------------------

    public enum FOpcDeviceTimeout : int
    {
        T2 = 2,
        T3 = 3,
        T5 = 5
    }

    //------------------------------------------------------------------------------------------------------------------------    

    public enum FResourceSourceType : int
    {
        None,
        EapName,
        EquipmentName,
        OpcDeviceName,
        OpcSessionName,
        OpcSessionId,
        HostDeviceName,
        HostSessionName,
        HostSessionId,
        HostMachineId
    }
    

    //------------------------------------------------------------------------------------------------------------------------

    public enum FOpcMessageTransferAreaType : int
    {
        Unknown,
        Read,
        Write
    }

    //------------------------------------------------------------------------------------------------------------------------    

    // ***
    // 2017.03.17 by spike.lee Storage Mode 지원
    // ***
    public enum FStorageMode : int
    {
        All = 0,            // Repository 전체 데이터 반환
        Part = 1            // Repository 부분 데이터 반환
    }

    //------------------------------------------------------------------------------------------------------------------------

    // ***
    // 2017.07.04 by spike.lee Log Level 지원
    // ***
    public enum FLogLevel : int
    {
        Level1 = 1,
        Level2 = 2,
        Level3 = 3,
        Level4 = 4,
        Level5 = 5,
        Level6 = 6,
        Level7 = 7,
        Level8 = 8,
        Level9 = 9,
        Level10 = 10
    }

    //------------------------------------------------------------------------------------------------------------------------    

}   // Namespace end