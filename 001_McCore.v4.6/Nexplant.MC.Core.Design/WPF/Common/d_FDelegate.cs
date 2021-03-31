/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : d_FDelegate.cs
--  Creator         : byjeon
--  Create Date     : 2012.09.28
--  Description     : FAMate Core FaUIs WPF Delegate Definition File
--  History         : Created by byjeon at 2012.09.28
----------------------------------------------------------------------------------------------------------*/
using System.Windows;

namespace Nexplant.MC.Core.FaUIs.WPF
{

    //------------------------------------------------------------------------------------------------------------------------

    // ***
    // Drag Drop Control Delegate
    // ***
    public delegate System.Windows.Point GetPositionDelegate(IInputElement element);

    // ***
    // FFlowContainer Control Event
    // ***
    public delegate void FFlowContainerActivatedEventHandler(object sender, FFlowContainerActivatedEventArgs e);
    public delegate void FFlowMouseMoveEventHandler(object sender, FFlowMouseEventArgs e);
    public delegate void FFlowDragOverEventHandler(object sender, FFlowDragEventArgs e);
    public delegate void FFlowDragDropEventHandler(object sender, FFlowDragEventArgs e);

    // -- 

    // ***
    // FlowCtrl Control Event
    // ***
    public delegate void FFlowCtrlActivatedEventHandler(object sender, FFlowCtrlActivatedEventArgs e);
    public delegate void FFlowCtrlDroppedEventHandler(object sender, FFlowCtrlDroppedEventArgs e);    

    //------------------------------------------------------------------------------------------------------------------------

} // Namespace end
