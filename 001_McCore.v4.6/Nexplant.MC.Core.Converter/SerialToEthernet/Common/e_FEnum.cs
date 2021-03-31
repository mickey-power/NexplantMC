/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : e_FEnum.cs
--  Creator         : mjkim
--  Create Date     : 2019.09.23
--  Description     : FAmate Conveter FaSerialToEthernet Enumerator Definition
--  History         : Created by mjkim at 2019.09.23
----------------------------------------------------------------------------------------------------------*/

namespace Nexplant.MC.Core.FaSerialToEthernet
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
        Connected
        //Selected
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FEventId : int
    {
        None,
        // --
        SerialStateChanged,
        SerialErrorRaised,
        SerialDataReceived,
        SerialDataSent,
        // --
        SocketStateChanged,
        SocketErrorRaised,
        SocketTimeoutRaised,
        SocketDataReceived,
        SocketDataSent,
        SocketDataSendFailed,
        // --
        LogMonitoring
    }

    //------------------------------------------------------------------------------------------------------------------------

    public enum FResultCode : int
    {
        Success,
        Warninig,
        Error
    }

    //------------------------------------------------------------------------------------------------------------------------

}   // Namespace end