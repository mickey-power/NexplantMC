/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : e_FEnum.cs
--  Creator         : spike.lee
--  Create Date     : 2013.07.10
--  Description     : FAMate Core FaPlcDriver Enumerator Definition
--  History         : Created by spike.lee at 2013.07.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaPlcDriver
{

    //------------------------------------------------------------------------------------------------------------------------

    public enum FStringOption : int
    {
        Default,
        Detail
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FObjectType : int
    {
        PlcDriver,
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
        PlcLibraryGroup,
        PlcLibrary,
        PlcMessageList,
        PlcMessages,
        PlcMessage,        
        PlcBitList,
        PlcBit,
        PlcWordList,
        PlcWord,
        PlcMessageTransfer,
        // --
        PlcReadMessage,
        PlcWriteMessage,
        // --
        PlcDevice,
        PlcSession,
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
        PlcTrigger,
        PlcCondition,
        PlcExpression,
        PlcTransmitter,
        PlcTransfer,
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
        PlcDriverLog,
        // --
        PlcDeviceStateChangedLog,
        PlcDeviceErrorRaisedLog,
        PlcDeviceTimeoutRaisedLog,
        PlcDeviceDataReceivedLog,
        PlcDeviceDataSentLog,
        PlcDeviceDataMessageReadLog,
        PlcDeviceDataMessageWrittenLog,
        PlcBitListLog,
        PlcBitLog,
        PlcWordListLog,
        PlcWordLog,
        // --
        HostDeviceStateChangedLog,
        HostDeviceErrorRaisedLog,
        HostDeviceVfeiReceivedLog,
        HostDeviceVfeiSentLog,
        HostDeviceDataMessageReceivedLog,
        HostDeviceDataMessageSentLog,
        HostItemLog,
        // --
        PlcTriggerRaisedLog,
        PlcTransmitterRaisedLog,
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
        PlcDeviceStateChanged,
        PlcDeviceErrorRaised,
        PlcDeviceTimeoutRaised,
        PlcDeviceDataReceived,
        PlcDeviceDataSent,
        PlcDeviceDataMessageRead,
        PlcDeviceDataMessageWritten,
        // --
        HostDeviceStateChanged,
        HostDeviceErrorRaised,
        HostDeviceVfeiReceived,
        HostDeviceVfeiSent,
        HostDeviceDataMessageReceived,
        HostDeviceDataMessageSent,
        // --
        PlcTriggerRaised,
        PlcTransmitterRaised,
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
        PlcLibrary = FObjectType.PlcLibrary,
        HostLibrary = FObjectType.HostLibrary
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FDeviceType : int
    {
        PlcDevice = FObjectType.PlcDevice,
        HostDevice = FObjectType.HostDevice
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FSessionType : int
    {
        PlcSession = FObjectType.PlcSession,
        HostSession = FObjectType.HostSession
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FProtocol : int
    {
        MELSECE,
        MODBUS
    }

    //------------------------------------------------------------------------------------------------------------------------

    internal enum FProtocolType : int
    {
        MELSECE,
        MODBUS,
        HOST
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

    public enum FDirection : int
    {
        Equipment,
        Host,
        Both
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FPlcDirection : int
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

    public enum FPlcWordFormat : int
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
        U1 = 41        // Oct: 51
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FPlcWordFormatShortName : int
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
        PlcMessageTransfer = FObjectType.PlcMessage,
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
        PlcMessage = FObjectType.PlcMessage,
        HostMessage = FObjectType.HostMessage
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FMessageLogType : int
    {
        PlcDeviceDataMessageReadLog = FObjectLogType.PlcDeviceDataMessageReadLog,
        PlcDeviceDataMessageWrittenLog = FObjectLogType.PlcDeviceDataMessageWrittenLog,
        HostDeviceDataMessageReceivedLog = FObjectLogType.HostDeviceDataMessageReceivedLog,
        HostDeviceDataMessageSentLog = FObjectLogType.HostDeviceDataMessageSentLog        
    }       

    //------------------------------------------------------------------------------------------------------------------------

    public enum FTransferType : int
    {
        PlcTransfer = FObjectType.PlcTransfer,
        HostTransfer = FObjectType.HostTransfer
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FFlowType : int
    {
        PlcTrigger = FObjectType.PlcTrigger,
        PlcTransmitter = FObjectType.PlcTransmitter,
        PlcTransfer = FObjectType.PlcTransfer,
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
        Error
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
        StringCount,
        SubString,
        SubStringR,
        SelectArray,
        SelectArrayR,
        Suffix,
        ToBit,
        ToLower,
        ToUpper,
        Trim,
        TrimAll,
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

    public enum FPlcConditionMode : int
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

    public enum FPlcMessageType : int
    {
        PlcReadMessage = FObjectType.PlcReadMessage,
        PlcWriteMessage = FObjectType.PlcWriteMessage
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FPlcResourceSourceType : int
    {
        None,
        EapName,
        EquipmentName,
        PlcDeviceName,
        PlcSessionName,
        PlcSessionId
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FPlcOperandType : int
    {
        PlcWord = FObjectType.PlcWord,
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
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FDataTargetType : int
    {
        Constant,
        Column,
        Item
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FLinkMapExpression : int
    {
        Decimal,
        Hex
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FPlcDeviceTimeout : int
    {
        TimeOut = 1
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FPlcDataType : int
    {
        BitRead = 0,
        WordRead = 1,
        BitWrite = 2,
        WordWrite = 3,
        RandomWordRead = 4,
        RandomWordWrite = 5,
        MultiblockRead = 6,
        MultiblockWrite = 7,
        RandomBitWrite = 8,
        Unknown = 9999
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FResourceSourceType : int
    {
        None,
        EapName,
        EquipmentName,
        PlcDeviceName,
        PlcSessionName,
        PlcSessionId,
        HostDeviceName,
        HostSessionName,
        HostSessionId,
        HostMachineId
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FMelseceLinkMapDataType : int
    {
        SessionRead,
        MessageRead,
        MessageWrite,
        AutoReset
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FPlcMessageTransferAreaType : int
    {
        Unknown,
        Read,
        Write
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FPlcResultType : int
    {
        Bit,
        Word
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