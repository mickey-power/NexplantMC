/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : e_FEnum.cs
--  Creator         : spike.lee
--  Create Date     : 2015.06.16
--  Description     : FAMate Core FaTcpDriver Enumerator Definition
--  History         : Created by spike.lee at 2015.06.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaTcpDriver
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
        TcpDriver,
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
        TcpLibraryGroup,
        TcpLibrary,
        TcpMessageList,
        TcpMessages,
        TcpMessage,      
        TcpItem,
        TcpMessageTransfer,        
        // --
        TcpDevice,
        TcpSession,
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
        TcpTrigger,
        TcpCondition,
        TcpExpression,
        TcpTransmitter,
        TcpTransfer,
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
        TcpDriverLog,
        // --
        TcpDeviceStateChangedLog,
        TcpDeviceDataReceivedLog,
        TcpDeviceDataSentLog,
        TcpDeviceErrorRaisedLog,
        TcpDeviceTimeoutRaisedLog,        
        TcpDeviceXmlReceivedLog,
        TcpDeviceXmlSentLog,
        TcpDeviceDataMessageReceivedLog,
        TcpDeviceDataMessageSentLog,       
        TcpItemLog,
        // --
        HostDeviceStateChangedLog,
        HostDeviceErrorRaisedLog,
        HostDeviceVfeiReceivedLog,
        HostDeviceVfeiSentLog,
        HostDeviceDataMessageReceivedLog,
        HostDeviceDataMessageSentLog,
        HostItemLog,
        // --
        TcpTriggerRaisedLog,
        TcpTransmitterRaisedLog,
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
        TcpDeviceStateChanged,
        TcpDeviceDataReceived,
        TcpDeviceDataSent,
        TcpDeviceErrorRaised,
        TcpDeviceTimeoutRaised,
        TcpDeviceXmlReceived,
        TcpDeviceXmlSent,
        TcpDeviceDataMessageReceived,
        TcpDeviceDataMessageSent,        
        // --
        HostDeviceStateChanged,
        HostDeviceErrorRaised,
        HostDeviceVfeiReceived,
        HostDeviceVfeiSent,
        HostDeviceDataMessageReceived,
        HostDeviceDataMessageSent,
        // --
        TcpTriggerRaised,
        TcpTransmitterRaised,
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
        TcpLibrary = FObjectType.TcpLibrary,
        HostLibrary = FObjectType.HostLibrary
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FDeviceType : int
    {
        TcpDevice = FObjectType.TcpDevice,
        HostDevice = FObjectType.HostDevice
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FSessionType : int
    {
        TcpSession = FObjectType.TcpSession,
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
        CUSTOM_001
    }

    //------------------------------------------------------------------------------------------------------------------------

    internal enum FProtocolType : int
    {
        CUSTOM_001,     
        TCP,   
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
        TcpMessageTransfer = FObjectType.TcpMessage,
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

    public enum FTcpMessageType : int
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
        TcpMessage = FObjectType.TcpMessage,
        HostMessage = FObjectType.HostMessage
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FMessageLogType : int
    {
        TcpDeviceDataMessageReceivedLog = FObjectLogType.TcpDeviceDataMessageReceivedLog,
        TcpDeviceDataMessageSentLog = FObjectLogType.TcpDeviceDataMessageSentLog,
        HostDeviceDataMessageReceivedLog = FObjectLogType.HostDeviceDataMessageReceivedLog,
        HostDeviceDataMessageSentLog = FObjectLogType.HostDeviceDataMessageSentLog        
    }       

    //------------------------------------------------------------------------------------------------------------------------

    public enum FTransferType : int
    {
        TcpTransfer = FObjectType.TcpTransfer,
        HostTransfer = FObjectType.HostTransfer
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FFlowType : int
    {
        TcpTrigger = FObjectType.TcpTrigger,
        TcpTransmitter = FObjectType.TcpTransmitter,
        TcpTransfer = FObjectType.TcpTransfer,
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
    // ***
    // 2021.03.29 add by Sunghoon.Park 
    // Tcp Device Driver 상태 추가
    public enum FTcpDeviceDriverState : int
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

    public enum FTcpResourceSourceType : int
    {
        None,
        EapName,
        EquipmentName,
        TcpDeviceName,
        TcpSessionName,
        TcpSessionId
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FTcpOperandType : int
    {
        TcpItem = FObjectType.TcpItem,        
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

    public enum FResourceSourceType : int
    {
        None,
        EapName,
        EquipmentName,
        TcpDeviceName,
        TcpSessionName,
        TcpSessionId,
        HostDeviceName,
        HostSessionName,
        HostSessionId,
        HostMachineId
    }

    //------------------------------------------------------------------------------------------------------------------------    
    
    public enum FTcpDeviceTimeout : int
    {
        T3 = 3,
        T5 = 5,
        T8 = 8
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