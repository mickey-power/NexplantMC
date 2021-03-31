/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : d_FDelegate.cs
--  Creator         : spike.lee
--  Create Date     : 2010.11.25
--  Description     : FAMate Core FaCommon Delegate Definition File
--  History         : Created by spike.lee at 2010.11.25
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.miracom.transceiverx.session;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaCommon
{

    //------------------------------------------------------------------------------------------------------------------------       

    // ***
    // FThread Object Event Delegate
    // ***
    public delegate void FThreadStartedEventHandler(object sender, FThreadEventArgs e);
    public delegate void FThreadStoppedEventHandler(object sender, FThreadEventArgs e);    
    public delegate void FThreadErrorRaisedEventHandler(object sender, FThreadErrorRaisedEventArgs e);
    public delegate void FThreadJobCalledEventHandler(object sender, FThreadEventArgs e);

    //------------------------------------------------------------------------------------------------------------------------       

    // ***
    // FTimer Object Event Delegate
    // ***
    public delegate void FTimerElapsedEventHandler(object sender, FTimerElapsedEventArgs e);

    //------------------------------------------------------------------------------------------------------------------------       

    // ***
    // FXmlNode Object Event Delegate
    // ***
    public delegate void FXmlNodeModifiedEventHandler(object sender, FXmlNodeModifiedEventArgs e);

    //------------------------------------------------------------------------------------------------------------------------       

    // ***
    // FTcpListener Object Event Delegate
    // ***
    public delegate void FTcpListenerAcceptCompletedEventHandler(object sender, FTcpListenerAcceptCompletedEventArgs e);
    public delegate void FTcpListenerErrorRaisedEventHandler(object sender, FTcpListenerErrorRaisedEventArgs e);

    //------------------------------------------------------------------------------------------------------------------------       

    // ***
    // FTcpClient Object Event Delegate
    // ***
    public delegate void FTcpClientStateChangedEventHandler(object sender, FTcpClientStateChangedEventArgs e);
    public delegate void FTcpClientDataReceivedEventHandler(object sender, FTcpClientDataReceivedEventArgs e);
    public delegate void FTcpClientDataSentEventHandler(object sender, FTcpClientDataSentEventArgs e);
    public delegate void FTcpClientDataSendFailedEventHandler(object sender, FTcpClientDataSendFailedEventArgs e);
    public delegate void FTcpClientErrorRaisedEventHandler(object sender, FTcpClientErrorRaisedEventArgs e);

    //------------------------------------------------------------------------------------------------------------------------       

    // ***
    // FPipe Object Event Delegate
    // ***
    public delegate void FPipeStateChangedEventHandler(object sender, FPipeStateChangedEventArgs e);
    public delegate void FPipeDataReceivedEventHandler(object sender, FPipeDataReceivedEventArgs e);
    public delegate void FPipeDataSentEventHandler(object sender, FPipeDataSentEventArgs e);
    public delegate void FPipeDataSendFailedEventHandler(object sender, FPipeDataSendFailedEventArgs e);
    public delegate void FPipeErrorRaisedEventHandler(object sender, FPipeErrorRaisedEventArgs e);

    //------------------------------------------------------------------------------------------------------------------------       

    // ***
    // FSerial Object Event Delegate
    // ***
    public delegate void FSerialStateChangedEventHandler(object sender, FSerialStateChangedEventArgs e);
    public delegate void FSerialDataReceivedEventHandler(object sender, FSerialDataReceivedEventArgs e);
    public delegate void FSerialDataSentEventHandler(object sender, FSerialDataSentEventArgs e);
    public delegate void FSerialDataSendFailedEventHandler(object sender, FSerialDataSendFailedEventArgs e);
    public delegate void FSerialErrorRaisedEventHandler(object sender, FSerialErrorRaisedEventArgs e);

    //------------------------------------------------------------------------------------------------------------------------       

    // ***
    // FServiceTrace Event Delegate
    // ***
    public delegate void FServiceTraceMessageReceivedEventHandler(object sender, FServiceTraceMessageReceivedEventArgs e);
    public delegate void FServiceTraceErrorRaisedEventHandler(object sender, FServiceTraceErrorRaisedEventArgs e);

    //------------------------------------------------------------------------------------------------------------------------       

    // ***
    // FResource Object Event Delegate
    // ***
    public delegate void FProcessResourceEventHandler(object sender, FProcessResourceEventArgs e);
    public delegate void FSystemResourceEventHandler(object sender, FSystemResourceEventArgs e);

    //------------------------------------------------------------------------------------------------------------------------       

    // ***
    // FTelnet Client Object Event Delegate
    // ***
    public delegate void FTelnetStateChangedEventHandler(object sender, FTelnetStateChangedEventArgs e);
    public delegate void FTelnetPacketReceivedEventHandler(object sender, FTelnetPacketReceivedEventArgs e);
    public delegate void FTelnetPacketSentEventHandler(object sender, FTelnetPacketSentEventArgs e);
    
    //------------------------------------------------------------------------------------------------------------------------       

    // ***
    // H101 Object Event Delegate
    // ***
    public delegate void FH101ErrorRaisedEventHandler(object sender, FH101ErrorRaisedEventArgs e);
    public delegate void FH101ConnectedEventHandler(object sender);
    public delegate void FH101DisconnectedEventHandler(object sender);
    
    //------------------------------------------------------------------------------------------------------------------------       

}   // Namespace end
