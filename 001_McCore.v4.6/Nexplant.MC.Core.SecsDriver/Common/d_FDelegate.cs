/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : d_FDelegate.cs
--  Creator         : spike.lee
--  Create Date     : 2011.02.01
--  Description     : FAMate Core FaSecsDriver Delegate Definition File
--  History         : Created by spike.lee at 2011.02.01
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaSecsDriver
{

    //------------------------------------------------------------------------------------------------------------------------       

    public delegate void FModelingFileOpenCompletedEventHandler(object sender, FModelingFileOpenCompletedEventArgs e);
    public delegate void FModelingFileReopenPrecompletedEventHandler(object sender, FModelingFileReopenPrecompletedEventArgs e);
    public delegate void FModelingFileReopenCompletedEventHandler(object sender, FModelingFileReopenCompletedEventArgs e);
    public delegate void FModelingFileReopenFailedEventHandler(object sender, FModelingFileReopenFailedEventArgs e);
    public delegate void FModelingFileSaveCompletedEventHandler(object sender, FModelingFileSaveCompletedEventArgs e);
    // --
    public delegate void FObjectInsertBeforeCompletedEventHandler(object sender, FObjectEventArgs e);
    public delegate void FObjectInsertAfterCompletedEventHandler(object sender, FObjectEventArgs e);
    public delegate void FObjectAppendCompletedEventHandler(object sender, FObjectEventArgs e);
    public delegate void FObjectRemoveCompletedEventHandler(object sender, FObjectEventArgs e);
    public delegate void FObjectModifyCompletedEventHandler(object sender, FObjectEventArgs e);
    public delegate void FObjectMoveUpCompletedEventHandler(object sender, FObjectEventArgs e);
    public delegate void FObjectMoveDownCompletedEventHandler(object sender, FObjectEventArgs e);
    public delegate void FObjectMoveToCompletedEventHandler(object sender, FObjectMoveToCompletedEventArgs e);
    // --
    public delegate void FSecsDeviceStateChangedEventHandler(object sender, FSecsDeviceStateChangedEventArgs e);
    public delegate void FSecsDeviceDataReceivedEventHandler(object sender, FSecsDeviceDataReceivedEventArgs e);
    public delegate void FSecsDeviceDataSentEventHandler(object sender, FSecsDeviceDataSentEventArgs e);
    public delegate void FSecsDeviceErrorRaisedEventHandler(object sender, FSecsDeviceErrorRaisedEventArgs e);
    public delegate void FSecsDeviceControlMessageReceivedEventHandler(object sender, FSecsDeviceControlMessageReceivedEventArgs e);
    public delegate void FSecsDeviceControlMessageSentEventHandler(object sender, FSecsDeviceControlMessageSentEventArgs e);
    public delegate void FSecsDeviceSmlReceivedEventHandler(object sender, FSecsDeviceSmlReceivedEventArgs e);
    public delegate void FSecsDeviceSmlSentEventHandler(object sender, FSecsDeviceSmlSentEventArgs e);
    public delegate void FSecsDeviceDataMessageReceivedEventHandler(object sender, FSecsDeviceDataMessageReceivedEventArgs e);
    public delegate void FSecsDeviceDataMessageSentEventHandler(object sender, FSecsDeviceDataMessageSentEventArgs e);
    public delegate void FSecsDeviceTimeoutRaisedEventHandler(object sender, FSecsDeviceTimeoutRaisedEventArgs e);
    // --
    public delegate void FSecsDeviceHandshakeReceivedEventHandler(object sender, FSecsDeviceHandshakeReceivedEventArgs e);
    public delegate void FSecsDeviceHandshakeSentEventHandler(object sender, FSecsDeviceHandshakeSentEventArgs e);
    public delegate void FSecsDeviceBlockReceivedEventHandler(object sender, FSecsDeviceBlockReceivedEventArgs e);
    public delegate void FSecsDeviceBlockSentEventHandler(object sender, FSecsDeviceBlockSentEventArgs e);
    // --
    public delegate void FSecsDeviceTelnetPacketReceivedEventHandler(object sender, FSecsDeviceTelnetPacketReceivedEventArgs e);
    public delegate void FSecsDeviceTelnetPacketSentEventHandler(object sender, FSecsDeviceTelnetPacketSentEventArgs e);
    public delegate void FSecsDeviceTelnetStateChangedEventHandler(object sender, FSecsDeviceTelnetStateChangedEventArgs e);
    // -- 
    public delegate void FHostDeviceStateChangedEventHandler(object sender, FHostDeviceStateChangedEventArgs e);
    public delegate void FHostDeviceErrorRaisedEventHandler(object sender, FHostDeviceErrorRaisedEventArgs e);
    public delegate void FHostDeviceVfeiReceivedEventHandler(object sender, FHostDeviceVfeiReceivedEventArgs e);
    public delegate void FHostDeviceVfeiSentEventHandler(object sender, FHostDeviceVfeiSentEventArgs e);
    public delegate void FHostDeviceDataMessageReceivedEventHandler(object sender, FHostDeviceDataMessageReceivedEventArgs e);
    public delegate void FHostDeviceDataMessageSentEventHandler(object sender, FHostDeviceDataMessageSentEventArgs e);
    // --
    public delegate void FSecsTriggerRaisedEventHandler(object sender, FSecsTriggerRaisedEventArgs e);
    public delegate void FSecsTransmitterRaisedEventHandler(object sender, FSecsTransmitterRaisedEventArgs e);
    public delegate void FHostTriggerRaisedEventHandler(object sender, FHostTriggerRaisedEventArgs e);
    public delegate void FHostTransmitterRaisedEventHandler(object sender, FHostTransmitterRaisedEventArgs e);
    public delegate void FJudgementPerformedEventHandler(object sender, FJudgementPerformedEventArgs e);
    public delegate void FMapperPerformedEventHandler(object sender, FMapperPerformedEventArgs e);
    public delegate void FEquipmentStateSetAltererPerformedEventHandler(object sender, FEquipmentStateSetAltererPerformedEventArgs e);
    public delegate void FStoragePerformedEventHandler(object sender, FStoragePerformedEventArgs e);
    public delegate void FCallbackRaisedEventHandler(object sender, FCallbackRaisedEventArgs e);
    public delegate void FBranchRaisedEventHandler(object sender, FBranchRaisedEventArgs e);
    public delegate void FFunctionCalledEventHandler(object sender, FFunctionCalledEventArgs e);
    public delegate void FCommentWrittenEventHandler(object sender, FCommentWrittenEventArgs e);
    public delegate void FPauserRaisedEventHandler(object sender, FPauserRaisedEventArgs e);
    public delegate void FEntryPointCalledEventHandler(object sender, FEntryPointCalledEventArgs e);
    public delegate void FApplicationWrittenEventHandler(object sender, FApplicationWrittenEventArgs e);    
    // --
    public delegate void FHostDriverStateChangedEventHandler(object sender, FHostDriverStateChangedEventArgs e);
    public delegate void FHostDriverDataMessageReceivedEventHandler(object sender, FHostDriverDataMessageReceivedEventArgs e);
    public delegate void FHostDriverDataMessageSentEventHandler(object sender, FHostDriverDataMessageSentEventArgs e);
    public delegate void FHostDriverErrorRaisedEventHandler(object sender, FHostDriverErrorRaisedEventArgs e);
    public delegate void FHostDriverSpoolingMessageErrorRaisedEventHandler(object sender, FHostDriverSpoolingMessageErrorRaisedEventArgs e); 
    // --
    public delegate void FModelingFileChangedEventHandler(object sender, FModelingFileChangedEventArgs e);

    // ***
    // 2017.05.31 by spike.lee
    // Repository Material Saved Event Delegate 추가
    // ***
    public delegate void FRepositoryMaterialSavedEventHandler(object sender, FRepositoryMaterialSavedEventArgs e);

    //------------------------------------------------------------------------------------------------------------------------       

}   // Namespace end
