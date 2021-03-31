/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2021 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : i_FITcpDeviceDriver.cs
--  Creator         : SungHoon.Park
--  Create Date     : 2021.03.10
--  Description     : NexplantMC Core FaTcpDriver TcpDeviceDriver Object Interface
--  History         : Created by SungHoon.Park at 2021.03.10
----------------------------------------------------------------------------------------------------------*/

using System;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    public interface FITcpDeviceDriver : IDisposable
    {

        #region Properties

        //------------------------------------------------------------------------------------------------------------------------

        FTcpClient fTcpclient
        {
            get;
        }

        //------------------------------------------------------------------------------------------------------------------------

        FTcpListener fTcpListener
        {
            get;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        void open(
         );

        //------------------------------------------------------------------------------------------------------------------------

        void close(
            );

        //------------------------------------------------------------------------------------------------------------------------

        void closeTcpClient(
            );

        //------------------------------------------------------------------------------------------------------------------------

        void send(
            FTcpSession fTcpSession,
            FTcpMessageTransfer fTcpMessageTransfer
            );


        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Events

        event FTcpDeviceDriverStateChangedEventHandler TcpDeviceDriverStateChanged;
        event FTcpDeviceDriverErrorRaisedEventHandler TcpDeviceDriverErrorRaised;

        // --
        // PSH Comment 
        // Event 정리

        #endregion

        //------------------------------------------------------------------------------------------------------------------------
    }
}
