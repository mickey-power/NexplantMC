/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : e_FEnum.cs
--  Creator         : spike.lee
--  Create Date     : 2010.11.25
--  Description     : FAMate Core FaCommon Enumerator Definition
--  History         : Created by spike.lee at 2010.11.25
                    : Modified by spike.lee at 2011.09.08
                        - FVolumnOption Enum 추가
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{

    //------------------------------------------------------------------------------------------------------------------------

    public enum FDebugLogCategory : int
    {
        Information,
        FException,
        Exception
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FDbProvider : int
    {
        MsSqlServer,
        Oracle,
        OracleEx,
        MySql,
        MariaDb,
        PostgreSql
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FSqlErrorType : int
    {
        Normal, 
        Warning,
        Critical
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FDmlType : int
    {
        Select,
        Insert,
        Update,
        Delete,
        Unknown
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FSocketType : int
    {
        Listener,
        Client
    }

    //------------------------------------------------------------------------------------------------------------------------

    internal enum FSocketEventId : int
    {
        None,
        // --
        TcpListenerAcceptCompleted,
        TcpListenerErrorRaised,
        // --
        TcpClientStateChanged,
        TcpClientDataReceived,
        TcpClientDataSent,
        TcpClientDataSendFailed,
        TcpClientErrorRaised
    }
        
    //------------------------------------------------------------------------------------------------------------------------

    public enum FTcpClientMode : int
    {
        Server,
        Client
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FTcpClientState : int
    {
        Opened,
        Connected,
        Closed
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FVolumnOption : int
    {
        Auto,
        Byte,
        KiloByte,
        MegaByte,
        GigaByte,
        TeraByte        
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FPipeType : int
    {
        Server,
        Client
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FPipeState : int
    {
        Closed,
        Opened,
        Connected
    }

    //------------------------------------------------------------------------------------------------------------------------

    internal enum FPipeEventId : int
    {
        None,
        // --
        PipeStateChanged,
        PipeDataReceived,
        PipeDataSent,
        PipeDataSendFailed,
        PipeErrorRaised
    }
    
    //------------------------------------------------------------------------------------------------------------------------

    public enum FSerialState : int
    {
        Closed,
        Opened
    }
    
    //------------------------------------------------------------------------------------------------------------------------

    public enum FSerialType :int
    {
        Active,
        Passive
    }

    //------------------------------------------------------------------------------------------------------------------------

    internal enum FSerialEventId : int
    {
        None,
        // --
        SerialStateChanged,
        SerialDataReceived,
        SerialDataSent,
        SerialDataSendFailed,
        SerialErrorRaised
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FServiceTraceCategory : int
    {
        Information,
        Warning,
        Error
    }

    //------------------------------------------------------------------------------------------------------------------------
    
    public enum FServiceLogCategory : int
    {
        Information,
        Warning,
        Error
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FH101StationMode : int
    {
        Inner,
        Inter
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FH101DeliveryType : int
    {
        Request,
        Reply,
        Unicast,
        GuaranteedUnicast,
        Mulitcast,
        GuaranteedMulticast
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FBoolean : int
    {
        False = 0,
        True = 1
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FYesNo
    {
        No = 0,
        Yes = 1,
    }

    //------------------------------------------------------------------------------------------------------------------------

    internal enum FTelnetEventId : int
    {
        None,        
        // -- 
        TelnetStateChanged,
        TelnetPacketReceived,
        TelnetPacketSent
    }

    //------------------------------------------------------------------------------------------------------------------------

    public static class FAsciiByte
    {
        public const byte NUL = 0;
        public const byte BEL = 7;
        public const byte BS = 8;
        public const byte HT = 9;
        public const byte LF = 10;
        public const byte VT = 11;
        public const byte FF = 12;
        public const byte CR = 13;
        public const byte SP = 32;
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FTelnetParserState : int
    {
        Data,
        ReceivedCarriageReturn,
        ReceivedIAC,
        ReceivedDo,
        ReceivedDont,
        ReceivedWill,
        ReceivedWont
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FTelnetPacketType
    {
        Data,
        Command,
        Option,
        Subnegotiation
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FTelnetCommand : byte
    {
        EndSubnegotiation = 240,
        NoOperation = 241,
        DataMark = 242,
        Break = 243,
        InterruptProcess = 244,
        AbortOutput = 245,
        AreYouThere = 246,
        EraseCharacter = 247,
        EraseLine = 248,
        GoAhead = 249,
        Subnegotiation = 250,
        // --
        Will = 251,
        Wont = 252,
        Do = 253,
        Dont = 254,
        // --
        Iac = 255
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FTelnetOption : byte
    {
        // Reference (http://www.iana.org/assignments/telnet-options)                     (Last Updated 2011-12-01)
        //---------------------------------------------------------------------------------------------------------
        // Options                                  Name                                                References
        //---------------------------------------------------------------------------------------------------------
        TransmitBinary = 0,                         // Binary Transmission                              [RFC 856]
        Echo = 1,                                   // Echo                                             [RFC 857]
        Reconnection = 2,                           // Reconnection                                     [NIC 50005]
        SuppressGoAhead = 3,                        // Suppress Go Ahead                                [RFC 858]        
        ApproximateMessageSizeNegotiation = 4,      // Approximate Message Size Negotiation             [ETHERNET]
        Status = 5,                                 // Status                                           [RFC 859]
        TimingMark = 6,                             // Timing Mark                                      [RFC 860]
        Rcte = 7,                                   // Remote Controlled Transmission and Echoing       [RFC 726]
        OutputLineWidth = 8,                        // Output Line Width                                [NIC 50005]
        OutputPageSize = 9,                         // Output Page Size                                 [NIC 50005]
        OutputCarriageReturnDisposition = 10,       // Output Carriage-Return Disposition               [RFC 652]
        OutputHorizontalTabStops = 11,              // Output Horizontal Tab Stops                      [RFC 653]
        OutputHorizontalTabDisposition = 12,        // Output Horizontal Tab Disposition                [RFC 654]
        OutputFormfeedDisposition = 13,             // Output formfeed disposition                      [RFC 655]
        OutputVerticalTabStops = 14,                // Output Vertical Tab Stops                        [RFC 656]
        OutputVerticalTabDisposition = 15,          // Output Vertical Tab Disposition                  [RFC 657]
        OutputLinefeedDisposition = 16,             // Output Linefeed Disposition                      [RFC 658]
        ExtendedAscii = 17,                         // Extended ASCII                                   [RFC 698]
        Logout = 18,                                // Logout                                           [RFC 727]
        ByteMacro = 19,                             // Byte Macro                                       [RFC 735]
        DataEntryTerminal = 20,                     // Data Entry Terminal                              [RRC 1043][RFC 732]
        SUPDUP = 21,                                // SUPDUP                                           [RFC 736][RFC 734]
        SupdupOutput = 22,                          // SUPDUP Output                                    [RFC 749]
        SendLocation = 23,                          // Send Location                                    [RFC 779]
        TerminalType = 24,                          // Terminal type                                    [RFC 1091]
        EndOfRecord = 25,                           // End of Record                                    [RFC 885]
        TacacsUserId = 26,                          // TACAS User Identification                        [RFC 927]
        OutputMarking = 27,                         // Output Marking                                   [RFC 933]
        TerminalLocation = 28,                      // Terminal Location Number                         [RFC 946]
        Ibm3270Regime = 29,                         // IBM TELNET 3270 Regime                           [RFC 1041]
        X3Pad = 30,                                 // X.3-PAD                                          [RFC 1053]
        NAWS = 31,                                  // Negotiate About Window Size                      [RFC 1073]
        TerminalSpeed = 32,                         // Terminal Speed                                   [RFC 1079]
        ToggleFlowControl = 33,                     // Toggle Flow Control                              [RFC 1372]
        LineMode = 34,                              // Line Mode                                        [RFC 1184]
        XDisplayLocation = 35,                      // X Display Location                               [RFC 1096]
        Environment = 36,                           // Environment                                      [RFC 1408]
        Authentication = 37,                        // Authentication                                   [RFC 2941]
        Encryption = 38,                            // Encryption                                       [RFC 2946]
        NewEnvironment = 39,                        // New Environment                                  [RFC 1572]
        TN3270E = 40,                               // TN3270 Enhancements                              [RFC 2355]
        XAUTH = 41,                                 // XAUTH                                            [Earhart]  
        CharacterSet = 42,                          // Character Set                                    [RFC 2066]
        RemoteSerialPort = 43,                      // Telnet Remote Serial Port (RSP)                  [Barnes]
        ComPort = 44,                               // Communications Port                              [RFC 2217]
        SuppressLocalEcho = 45,                     // Telnet Suppress Local Echo                       [Atmar]
        StartTLS = 46,                              // Telnet Start TLS                                 [Boe]
        Kermit = 47,                                // Kermit                                           [RFC 2840]
        SendUrl = 48,                               // SEND-URL                                         [Croft]
        ForwardX = 49,                              // FORWARD_X                                        [Altman]
        // 50-137                                   // Unassigned                                       [IANA]
        TeloptPragmaLogon = 138,                    // TELOPT PRAGMA LOGON                              [McGregory]
        TeloptSspiLogon = 139,                      // TELOPT SSPI LOGON                                [McGregory]
        TeloptPragmaHeartBeat = 140,                // TELOPT PRAGMA HEARTBEAT                          [McGregory]
        // 141-254                                  // Unassigned
        ExtendedOptionsList = 255                   // Extended-Options-List                            [RFC861]
    }

    //------------------------------------------------------------------------------------------------------------------------    
    
    public enum FTelnetPosition : byte
    {
        Local = 0,
        Remote = 1
    }

    //------------------------------------------------------------------------------------------------------------------------    

    public enum FTelnetOptionState : byte
    {
        Off = 0,
        On = 1
    }

    //------------------------------------------------------------------------------------------------------------------------    

    public enum FOsGroup
    {
        XpAndBelow,
        VistaAndAbove,
        UnKnown
    }

    //------------------------------------------------------------------------------------------------------------------------    

    public enum FDbType 
    {
        Int16,
        Int32,
        Int64,
        // --
        Double,
        // --
        Char,
        VarChar,
        NChar,
        NVarChar,
        // --
        RefCursor
    }
       
    //------------------------------------------------------------------------------------------------------------------------    
    
    public enum FOutputType
    {
        DataSet,
        String,
        Number
    }

    //------------------------------------------------------------------------------------------------------------------------    

    public enum FXmlNodeType
    {
        None = 0,
        Element = 1,
        Attribute = 2,
        Text = 3,
        CDATA = 4,
        EntityReference = 5,
        Entity = 6,
        ProcessingInstruction = 7,
        Comment = 8,
        Document = 9,
        DocumentType = 10,
        DocumentFragment = 11,
        Notation = 12,
        Whitespace = 13,
        SignificantWhitespace = 14,
        EndElement = 15,
        EndEntity = 16,
        XmlDeclaration = 17,
    }

    //------------------------------------------------------------------------------------------------------------------------    

}   // Namespace end