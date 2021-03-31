/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : e_FEnum.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.31
--  Description     : FAMate Core FaSecsDriver Enumerator Definition
--  History         : Created by spike.lee at 2011.01.31
                    : Modified by spike.lee at 2011.09.08
                        - FResultCode Enum Add (Log Result)
                        - FSecsDeviceTimeout Enum Add (SECS Device Timeout)
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaSecsDriver
{

    //------------------------------------------------------------------------------------------------------------------------

    public enum FStringOption : int
    {
        Default,
        Detail
    }

    //------------------------------------------------------------------------------------------------------------------------
    // 2018.03.24 Add by Jeff.Kim
    // Library Batch Modifier 에서 사용하기 위해 정의
    public enum FBatchModifierType : int
    {
        SecsItem
    }

    //------------------------------------------------------------------------------------------------------------------------
    // 2018.03.24 Add by Jeff.Kim
    // Library Batch Modifier 에서 사용하기 위해 정의
    public enum FBatchModifierTarget : int
    {
        Format,
        Value
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FObjectType : int
    {
        SecsDriver,
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
        SecsLibraryGroup,
        SecsLibrary,
        SecsMessageList,
        SecsMessages,
        SecsMessage,        
        SecsItem,
        SecsMessageTransfer,
        // --
        SecsDevice,
        SecsSession,
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
        SecsTrigger,
        SecsCondition,
        SecsExpression,
        SecsTransmitter,
        SecsTransfer,
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

    // ***
    // 2012.11.21 by spike.lee
    // Object Log Type Tuning
    // ***
    public enum FObjectLogType : int
    {
        SecsDriverLog,
        // --
        SecsDeviceStateChangedLog,
        SecsDeviceErrorRaisedLog,
        SecsDeviceTimeoutRaisedLog,
        SecsDeviceDataReceivedLog,
        SecsDeviceDataSentLog,
        SecsDeviceTelnetStateChangedLog,
        SecsDeviceTelnetPacketReceivedLog,
        SecsDeviceTelnetPacketSentLog,
        SecsDeviceHandshakeReceivedLog,
        SecsDeviceHandshakeSentLog,
        SecsDeviceControlMessageReceivedLog,
        SecsDeviceControlMessageSentLog,
        SecsDeviceBlockReceivedLog,
        SecsDeviceBlockSentLog,
        SecsDeviceSmlReceivedLog,
        SecsDeviceSmlSentLog,
        SecsDeviceDataMessageReceivedLog,
        SecsDeviceDataMessageSentLog,
        SecsItemLog,
        // --
        HostDeviceStateChangedLog,
        HostDeviceErrorRaisedLog,
        HostDeviceVfeiReceivedLog,
        HostDeviceVfeiSentLog,
        HostDeviceDataMessageReceivedLog,
        HostDeviceDataMessageSentLog,
        HostItemLog,
        // --
        SecsTriggerRaisedLog,
        SecsTransmitterRaisedLog,
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
        SecsDeviceStateChanged,
        SecsDeviceDataReceived,
        SecsDeviceDataSent,
        SecsDeviceErrorRaised,
        SecsDeviceControlMessageReceived,
        SecsDeviceControlMessageSent,
        SecsDeviceSmlReceived,
        SecsDeviceSmlSent,
        SecsDeviceDataMessageReceived,
        SecsDeviceDataMessageSent,
        SecsDeviceTimeoutRaised,
        // --
        SecsDeviceBlockReceived,
        SecsDeviceBlockSent,
        SecsDeviceHandshakeReceived,
        SecsDeviceHandshakeSent,
        // --
        SecsDeviceTelnetPacketReceived,
        SecsDeviceTelnetPacketSent,
        SecsDeviceTelnetStateChanged,
        // --
        HostDeviceStateChanged,
        HostDeviceErrorRaised,
        HostDeviceVfeiReceived,
        HostDeviceVfeiSent,
        HostDeviceDataMessageReceived,
        HostDeviceDataMessageSent,
        // --
        SecsTriggerRaised,
        SecsTransmitterRaised,
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
        ApplicationWritten,
        // ***
        // 2017.05.31 by spike.lee 추가
        // Repository Saved Event
        // ***
        RecpsitoryMaterialSaved
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FDirection : int
    {
        Equipment,
        Host,
        Both
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FPattern : int
    {
        Fixed,       
        Variable
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
        Raw = 64,       // Oct: 78
        Char = 65       // Oct: 79
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
        R = 64,         // Oct: 78
        C = 65          // Oct: 79
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

    public enum FConnectMode : int
    {
        Active,
        Passive
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FProtocol : int
    {
        SECS1,
        TCPIP,
        HSMS,
        TELNET
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FValueFormulaType : int
    {
        Choose,
        ChooseR,
        ChooseIncluded,
        ChooseIncludedR,
        DateTime,
        DateTimeTicks,
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
        TrimAll,
        TrimStart,
        TrimEnd,
        RemoveNonPrintable, // ASCII 1F-7F 이외 문자 제거
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

    public enum FLibraryType : int
    {
        SecsLibrary = FObjectType.SecsLibrary,
        HostLibrary = FObjectType.HostLibrary
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FDeviceType : int
    {
        SecsDevice = FObjectType.SecsDevice,
        HostDevice = FObjectType.HostDevice
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FSessionType : int
    {
        SecsSession = FObjectType.SecsSession,
        HostSession = FObjectType.HostSession
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FMessageType : int
    {
        SecsMessage = FObjectType.SecsMessage,
        HostMessage = FObjectType.HostMessage
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FMessageLogType : int
    {
        SecsDeviceDataMessageReceivedLog = FObjectLogType.SecsDeviceDataMessageReceivedLog,
        SecsDeviceDataMessageSentLog = FObjectLogType.SecsDeviceDataMessageSentLog,
        HostDeviceDataMessageReceivedLog = FObjectLogType.HostDeviceDataMessageReceivedLog,
        HostDeviceDataMessageSentLog = FObjectLogType.HostDeviceDataMessageSentLog
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FMessageTransferType : int
    {
        SecsMessageTransfer = FObjectType.SecsMessage,
        HostMessageTransfer = FObjectType.HostMessage
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FTransferType : int
    {
        SecsTransfer = FObjectType.SecsTransfer,
        HostTransfer = FObjectType.HostTransfer
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FFlowType : int
    {
        SecsTrigger = FObjectType.SecsTrigger,
        SecsTransmitter = FObjectType.SecsTransmitter,
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

    public enum FConditionMode : int
    {
        Expression,
        Timeout,
        Connection
    }

    //------------------------------------------------------------------------------------------------------------------------
    
    public enum FExpressionValueType : int
    {
        Value,
        Resource
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
        Message,
        Item,
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

    public enum FHostMessageType : int
    {
        Command,
        Unsolicited,
        Reply
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

    public enum FComparisonMode : int
    {
        Value,
        Length
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FSecsOperandType : int
    {
        SecsItem = FObjectType.SecsItem,
        Environment = FObjectType.Environment,
        EquipmentState = FObjectType.EquipmentState
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
    
    public enum FConversionMode : int
    {
        Value,
        Range
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FPauserMode : int
    {
        Fixed,
        Random
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FDeviceState : int
    {
        Closed,
        Opened,
        Connected,
        Selected
    }

    //------------------------------------------------------------------------------------------------------------------------

    internal enum FProtocolType : int
    {
        HSMS,
        SECS1,
        TCPIP,
        TELNET,
        HOST
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FControlMessageType : int
    {
        SelectReq = 1,
        SelectRsp = 2,
        DeselectReq = 3,
        DeselectRsp = 4,
        LinktestReq = 5,
        LinktestRsp = 6,
        RejectReq = 7,
        SeparateReq = 9
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FResultCode : int
    {
        Success,
        Warninig,
        Error
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FSecsDeviceTimeout : int
    {
        T1 = 1,
        T2 = 2,
        T3 = 3,
        T4 = 4,
        T5 = 5,
        T6 = 6,
        T7 = 7,
        T8 = 8
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

    public enum FSecs1HandshakeCode : int
    {
        ENQ = 0x05,
        EOT = 0x04,
        ACK = 0x06,
        NAK = 0x15
    }

    //------------------------------------------------------------------------------------------------------------------------
    
    internal enum FSecs1StatusType : int
    {
        Idle,
        LineControl,
        Send,
        Receive,
        ReceiveCompletion,
        SendCompletion,
        Contention
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FAutoCycleAction : int
    {
        Once,
        Repeat
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

    public enum FSecsResourceSourceType : int
    {
        None,
        EapName,
        EquipmentName,
        SecsDeviceName,
        SecsSessionName,
        SecsSessionId
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FMessageSourceType : int
    {
        None,
        SystemBytes
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FResourceSourceType : int
    {
        None,
        EapName,
        EquipmentName,
        SecsDeviceName,
        SecsSessionName,
        SecsSessionId,
        HostDeviceName,
        HostSessionName,
        HostSessionId,
        HostMachineId
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FDataScanMode : int
    {
        Local, 
        Global
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

    public enum FTelnetEventId : int
    {
        None,
        // -- 
        TelnetPacketReceived,
        TelnetPacketSent,
        TelnetTimeoutRaised,
        TelnetStateChanged        
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