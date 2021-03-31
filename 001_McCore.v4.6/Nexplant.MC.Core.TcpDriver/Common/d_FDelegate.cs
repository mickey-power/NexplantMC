/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : d_FDelegate.cs
--  Creator         : spike.lee
--  Create Date     : 2013.07.10
--  Description     : FAMate Core FaTcpDriver Delegate Definition File
--  History         : Created by spike.lee at 2013.07.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaTcpDriver
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
    public delegate void FTcpDeviceStateChangedEventHandler(object sender, FTcpDeviceStateChangedEventArgs e);
    public delegate void FTcpDeviceDataReceivedEventHandler(object sender, FTcpDeviceDataReceivedEventArgs e);
    public delegate void FTcpDeviceDataSentEventHandler(object sender, FTcpDeviceDataSentEventArgs e);
    public delegate void FTcpDeviceErrorRaisedEventHandler(object sender, FTcpDeviceErrorRaisedEventArgs e);
    public delegate void FTcpDeviceXmlReceivedEventHandler(object sender, FTcpDeviceXmlReceivedEventArgs e);
    public delegate void FTcpDeviceXmlSentEventHandler(object sender, FTcpDeviceXmlSentEventArgs e);
    public delegate void FTcpDeviceDataMessageReceivedEventHandler(object sender, FTcpDeviceDataMessageReceivedEventArgs e);
    public delegate void FTcpDeviceDataMessageSentEventHandler(object sender, FTcpDeviceDataMessageSentEventArgs e);
    public delegate void FTcpDeviceTimeoutRaisedEventHandler(object sender, FTcpDeviceTimeoutRaisedEventArgs e);   
    // --
    public delegate void FHostDeviceStateChangedEventHandler(object sender, FHostDeviceStateChangedEventArgs e);
    public delegate void FHostDeviceErrorRaisedEventHandler(object sender, FHostDeviceErrorRaisedEventArgs e);
    public delegate void FHostDeviceVfeiReceivedEventHandler(object sender, FHostDeviceVfeiReceivedEventArgs e);
    public delegate void FHostDeviceVfeiSentEventHandler(object sender, FHostDeviceVfeiSentEventArgs e);
    public delegate void FHostDeviceDataMessageReceivedEventHandler(object sender, FHostDeviceDataMessageReceivedEventArgs e);
    public delegate void FHostDeviceDataMessageSentEventHandler(object sender, FHostDeviceDataMessageSentEventArgs e);
    // --
    public delegate void FTcpTriggerRaisedEventHandler(object sender, FTcpTriggerRaisedEventArgs e);
    public delegate void FTcpTransmitterRaisedEventHandler(object sender, FTcpTransmitterRaisedEventArgs e);
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

    // ***
    // 2021.03.30 add by Sunghoon.Park
    // Tcp Device Driver Event Delegate 추가 
    // ***
    public delegate void FTcpDeviceDriverStateChangedEventHandler(object sender, FTcpDeviceDriverStateChangedEventArgs e);
    public delegate void FTcpDeviceDriverErrorRaisedEventHandler(object sender, FTcpDeviceDriverErrorRaisedEventArgs e);

    //------------------------------------------------------------------------------------------------------------------------       

}   // Namespace end
