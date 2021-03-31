/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : d_FDelegate.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.07
--  Description     : FAMate Core FaUIs Delegate Definition File
--  History         : Created by spike.lee at 2011.01.07
--                  : Modified by spike.lee at 2011.07.21
--                      - FFlowContainer Control Event 추가
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaUIs
{

    //------------------------------------------------------------------------------------------------------------------------       

    // ***
    // FDynPropGrid Control Event
    // ***
    public delegate void FDynPropNoticeRaisedEventHandler(object sender, FDynPropNoticeRaisedEventArgs e);
    public delegate void FDynPropGridRefreshRequestedEventHandler(object sender, EventArgs e);

    //------------------------------------------------------------------------------------------------------------------------       

    // ***
    // FRefreshAndSearchToolbar Control Event
    // ***
    public delegate void FRefreshRequestedEventHandler(object sender, EventArgs e);
    public delegate void FSearchRequestedEventHandler(object sender, FSearchRequestedEventArgs e);

    //------------------------------------------------------------------------------------------------------------------------       

    // ***
    // FTextSearcher Form Event
    // ***
    public delegate void FSearchWordSelectionRequestedEventHandler(object sender, FSearchWordSelectionRequestedEventArgs e);

    //------------------------------------------------------------------------------------------------------------------------       

    // ***
    // FUIWizard Object Event
    // ***
    public delegate void FFontNameChangedEventHandler(object sender, FFontNameChangedEventArgs e);
    public delegate void FLanguageChangedEventHandler(object sender, FLanguageChangedEventArgs e);    

    //------------------------------------------------------------------------------------------------------------------------       

    // ***
    // FFlowContainer Control Event
    // ***
    public delegate void FFlowContainerActivatedEventHandler(object sender, FFlowContainerActivatedEventArgs e);
    public delegate void FFlowCtrlActivatedEventHandler(object sender, FFlowCtrlActivatedEventArgs e);

    //------------------------------------------------------------------------------------------------------------------------       

    // ***
    // FBaseForm Form Event 
    // ***
    public delegate void FFormCloseConfirmEventHandler(object sender, FFormCloseConfirmEventArgs e);

    //------------------------------------------------------------------------------------------------------------------------       

    // ***
    // FTreeView Control Event 
    // ***
    public delegate void FTreeViewBeforeMouseDownEventHandler(object sender, FTreeViewBeforeMouseDownEventArgs e);

    //------------------------------------------------------------------------------------------------------------------------       

    // ***
    // FSequenceFlowContainer Control Event (삭제 예정)
    // *** 
    public delegate void FScenarioActivatedEventHandler(object sender, FScenarioActivatedEventArgs e);
    public delegate void FSequenceFlowActivatedEventHandler(object sender, FSequenceFlowActivatedEventArgs e);

    //------------------------------------------------------------------------------------------------------------------------  

}   // Namespace end
