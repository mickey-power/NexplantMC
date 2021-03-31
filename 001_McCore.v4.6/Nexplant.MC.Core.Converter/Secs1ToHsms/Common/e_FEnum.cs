/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : e_FEnum.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.06
--  Description     : FAmate Conveter FaSecs1ToHsms Enumerator Definition
--  History         : Created by spike.lee at 2017.04.06
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaSecs1ToHsms
{

    //------------------------------------------------------------------------------------------------------------------------

    public enum FConnectMode : int
    {
        Active,
        Passive
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FCommunicationState : int
    {
        Closed,
        Opened,
        Connected,
        Selected
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FEventId : int
    {
        None,
        // --
        Secs1StateChanged,
        Secs1ErrorRaised,
        Secs1TimeoutRaised,
        Secs1HandshakeReceived,
        Secs1HandshakeSent,
        Secs1BlockReceived,
        Secs1BlockSent,
        Secs1DataMessageReceived,
        Secs1DataMessageSent,
        Secs1InterceptingDataMessageReceived,
        // --
        HsmsStateChanged,
        HsmsErrorRaised,
        HsmsTimeoutRaised,
        HsmsControlMessageReceived,
        HsmsControlMessageSent,
        HsmsDataMessageReceived,
        HsmsDataMessageSent,
        HsmsInterceptingDataMessageReceived,
        // --
        LogMonitoring
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FSecsTimeout : int
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

    public enum FSecs1HandshakeCode : int
    {
        ENQ = 0x05,
        EOT = 0x04,
        ACK = 0x06,
        NAK = 0x15
    }

    //------------------------------------------------------------------------------------------------------------------------

    internal enum FSecs1RecvState : int
    {
        Enq,
        Eot,        
        Completed
    }

    //------------------------------------------------------------------------------------------------------------------------

    internal enum FSecs1SendState : int
    {
        Enq,
        Eot,
        Completed        
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FHsmsControlMessageType : int
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

    public enum FFormat : int
    {
        L = 0,          // Oct: 00
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
    }

    //------------------------------------------------------------------------------------------------------------------------

}   // Namespace end