/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FMenuKey.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.27
--  Description     : FAMate SECS Modeler Menu Key Class 
--  History         : Created by spike.lee at 2011.01.27
--                    Modified by spike.lee at 2011.07.25
--                      - Scenario Modeler Menu add
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.SecsModeler
{
    public static class FMenuKey
    {

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Main Menu
        // ***
        public const string MenuFile = "File";
        // --
        public const string MenuNew = "New";
        public const string MenuOpen = "Open";
        public const string MenuClose = "Close";
        // --
        public const string MenuClone = "Clone";
        // --
        public const string MenuSave = "Save";
        public const string MenuSaveAs = "Save As";
        // --
        public const string MenuRecentLibrary = "Recent Library";
        // --
        // ***
        // 2012.11.15 by spike.lee
        // LogLibary 이름을 Log로 변경 (LogLibrary란 용어는 없음, 생각좀하면서 했으면 좋겠음)
        // ***
        public const string MenuRecentLog = "Recent Log";
        // --
        public const string MenuOption = "Option";
        // --
        public const string MenuExport = "Export";
        // --
        public const string MenuExit = "Exit";

        // --

        public const string MenuSetup = "Setup";
        // --
        public const string MenuObjectNameDefinition = "Object Name Definition";
        public const string MenuFunctionNameDefinition = "Function Name Definition";
        public const string MenuUserTagNameDefinition = "User Tag Name Definition";
        // --
        public const string MenuDataConversionSetDefinition = "Data Conversion Set Definition";
        // --
        public const string MenuEquipmentStateSetDefinition = "Equipment State Set Definition";
        public const string MenuRepositoryDefinition = "Repository Definition";        
        public const string MenuEnvironmentDefinition = "Environment Definition";
        // --
        public const string MenuDataSetDefinition = "Data Set Definition";

        // --

        public const string MenuModeling = "Modeling";
        // --
        public const string MenuSecsLibraryModeler = "SECS Library Modeler";
        public const string MenuSecsDeviceModeler = "SECS Device Modeler";
        // --
        public const string MenuHostLibraryModeler = "Host Library Modeler";
        public const string MenuHostDeviceModeler = "Host Device Modeler";
        // --
        public const string MenuEquipmentModeler = "Equipment Modeler";    
        // --
        public const string MenuAllInOneModeler = "All In One Modeler";
        
        // --

        public const string MenuTool = "Tool";
        // --
        public const string MenuOpenAllDevice = "Open All Device";
        public const string MenuCloseAllDevice = "Close All Device";
        // --
        public const string MenuSecsBinaryLogCut = "SECS Binary Log Cut";
        public const string MenuSmlLogCut = "SML Log Cut";
        public const string MenuVfeiLogCut = "VFEI Log Cut";
        // --
        public const string MenuSecsLogCut = "SECS Log Cut";        

        // --

        public const string MenuTrace = "Trace";
        // --
        public const string MenuSecsBinaryTracer = "SECS Binary Tracer";
        public const string MenuSmlTracer = "Sml Tracer";
        public const string MenuVfeiTracer = "Vfei Tracer";
        public const string MenuLogTracer = "Log Tracer";
        public const string MenuInterfaceTracer = "Interface Tracer";

        // --

        public const string MenuView = "View";
        // --
        public const string MenuVfeiViewer = "VFEI Viewer";
        public const string MenuSmlViewer = "SML Viewer";
        public const string MenuRelationViewer = "Relation Viewer";

        // --

        public const string MenuWindow = "Window";
        // --
        public const string MenuWinCloseAllWindows = "WinCloseAllWindows";        
        public const string MenuWinWindow0 = "WinWindow0";
        public const string MenuWinWindow1 = "WinWindow1";
        public const string MenuWinWindow2 = "WinWindow2";
        public const string MenuWinWindow3 = "WinWindow3";
        public const string MenuWinWindow4 = "WinWindow4";
        public const string MenuWinWindow5 = "WinWindow5";
        public const string MenuWinWindow6 = "WinWindow6";
        public const string MenuWinWindow7 = "WinWindow7";
        public const string MenuWinWindow8 = "WinWindow8";
        public const string MenuWinWindow9 = "WinWindow9";
        public const string MenuWinMoreWindows = "WinMoreWindows";

        // --
        
        public const string MenuHelp = "Help";
        // --
        public const string MenuAbout = "About";

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Object Name Definition Menu
        // ***
        public const string MenuOndExpand = "Expand";
        public const string MenuOndCollapse = "Collapse";
        // --        
        public const string MenuOndCut = "Cut";
        public const string MenuOndCopy = "Copy";        
        public const string MenuOndPasteSibling = "Paste Sibling";
        public const string MenuOndPasteChild = "Paste Child";
        // --
        public const string MenuOndRemove = "Remove";
        // --
        public const string MenuOndMoveUp = "Move Up";
        public const string MenuOndMoveDown = "Move Down";
        // --
        public const string MenuOndRelation = "Relation";
        // --
        public const string MenuOndInsertBeforeObjectName = "Insert Before ObjectName";
        public const string MenuOndInsertAfterObjectName = "Insert After ObjectName";
        public const string MenuOndAppendObjectName = "Append ObjectName";
        
        // --

        public const string MenuOndPopupMenu = "PopupMenu";

        //------------------------------------------------------------------------------------------------------------------------
        
        // ***
        // Function Name Definition Menu
        // ***
        public const string MenuFndExpand = "Expand";
        public const string MenuFndCollapse = "Collapse";
        // --
        public const string MenuFndCut = "Cut";
        public const string MenuFndCopy = "Copy";        
        public const string MenuFndPasteSibling = "Paste Sibling";
        public const string MenuFndPasteChild = "Paste Child";        
        // --
        public const string MenuFndRemove = "Remove";
        // --
        public const string MenuFndMoveUp = "Move Up";
        public const string MenuFndMoveDown = "Move Down";
        // --
        public const string MenuFndRelation = "Relation";
        // --
        public const string MenuFndInsertBeforeFunctionNameList = "Insert Before Function Name List";
        public const string MenuFndInsertAfterFunctionNameList = "Insert After Function Name List";
        public const string MenuFndAppendFunctionNameList = "Append Function Name List";
        // --
        public const string MenuFndInsertBeforeFunctionName = "Insert Before Function Name";
        public const string MenuFndInsertAfterFunctionName = "Insert After Function Name";
        public const string MenuFndAppendFunctionName = "Append Function Name";
        // --
        public const string MenuFndInsertBeforeParameterName = "Insert Before Parameter Name";
        public const string MenuFndInsertAfterParameterName = "Insert After Parameter Name";
        public const string MenuFndAppendParameterName = "Append Parameter Name";
        // -- 
        public const string MenuFndInsertBeforeArgument = "Insert Before Argument";
        public const string MenuFndInsertAfterArgument = "Insert After Argument";
        public const string MenuFndAppendArgument = "Append Argument";

        // --

        public const string MenuFndPopupMenu = "PopupMenu";

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Data Conversion Definition Menu
        // ***
        public const string MenuDcdExpand = "Expand";
        public const string MenuDcdCollapse = "Collapse";
        // --
        public const string MenuDcdCut = "Cut";
        public const string MenuDcdCopy = "Copy";
        public const string MenuDcdPasteSibling = "Paste Sibling";
        public const string MenuDcdPasteChild = "Paste Child";
        // --
        public const string MenuDcdRemove = "Remove";
        // --
        public const string MenuDcdMoveUp = "Move Up";
        public const string MenuDcdMoveDown = "Move Down";
        // --
        public const string MenuDcdRelation = "Relation";
        // --
        public const string MenuDcdInsertBeforeDataConversionSetList = "Insert Before Data Conversion Set List";
        public const string MenuDcdInsertAfterDataConversionSetList = "Insert After Data Conversion Set List";
        public const string MenuDcdAppendDataConversionSetList = "Append Data Conversion Set List";
        // --
        public const string MenuDcdInsertBeforeDataConversionSet = "Insert Before Data Conversion Set";
        public const string MenuDcdInsertAfterDataConversionSet = "Insert After Data Conversion Set";
        public const string MenuDcdAppendDataConversionSet = "Append Data Conversion Set";
        // -- 
        public const string MenuDcdInsertBeforeDataConversion = "Insert Before Data Conversion";
        public const string MenuDcdInsertAfterDataConversion = "Insert After Data Conversion";
        public const string MenuDcdAppendDataConversion = "Append Data Conversion";

        // --

        public const string MenuDcdPopupMenu = "PopupMenu";

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Equipment State Set Definition Menu
        // ***
        public const string MenuEsdExpand = "Expand";
        public const string MenuEsdCollapse = "Collapse";
        // --
        public const string MenuEsdCut = "Cut";
        public const string MenuEsdCopy = "Copy";
        public const string MenuEsdPasteSibling = "Paste Sibling";
        public const string MenuEsdPasteChild = "Paste Child";
        // --
        public const string MenuEsdRemove = "Remove";
        // --
        public const string MenuEsdMoveUp = "Move Up";
        public const string MenuEsdMoveDown = "Move Down";
        // --
        public const string MenuEsdRelation = "Relation";
        // --
        public const string MenuEsdInsertBeforeEquipmentStateSetList = "Insert Before Equipment State Set List";
        public const string MenuEsdInsertAfterEquipmentStateSetList = "Insert After Equipment State Set List";
        public const string MenuEsdAppendEquipmentStateSetList = "Append Equipment State Set List";
        // --
        public const string MenuEsdInsertBeforeEquipmentStateSet = "Insert Before Equipment State Set";
        public const string MenuEsdInsertAfterEquipmentStateSet = "Insert After Equipment State Set";
        public const string MenuEsdAppendEquipmentStateSet = "Append Equipment State Set";
        // --
        public const string MenuEsdInsertBeforeEquipmentState = "Insert Before Equipment State";
        public const string MenuEsdInsertAfterEquipmentState = "Insert After Equipment State";
        public const string MenuEsdAppendEquipmentState = "Append Equipment State";
        // --
        public const string MenuEsdInsertBeforeStateValue = "Insert Before State Value";
        public const string MenuEsdInsertAfterStateValue = "Insert After State Value";
        public const string MenuEsdAppendStateValue = "Append State Value";
        
        // --

        public const string MenuEsdPopupMenu = "PopupMenu";

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Repository Definition Menu
        // ***
        public const string MenuRpdExpand = "Expand";
        public const string MenuRpdCollapse = "Collapse";
        // --
        public const string MenuRpdCut = "Cut";
        public const string MenuRpdCopy = "Copy";
        public const string MenuRpdPasteSibling = "Paste Sibling";
        public const string MenuRpdPasteChild = "Paste Child";
        // --
        public const string MenuRpdMoveUp = "Move Up";
        public const string MenuRpdMoveDown = "Move Down";
        // --
        public const string MenuRpdRelation = "Relation";
        // --
        public const string MenuRpdRemove = "Remove";
        // --
        public const string MenuRpdInsertBeforeRepositoryList = "Insert Before Repository List";
        public const string MenuRpdInsertAfterRepositoryist = "Insert After Repository List";
        public const string MenuRpdAppendRepositoryList = "Append Repository List";
        // --
        public const string MenuRpdInsertBeforeRepository = "Insert Before Repository";
        public const string MenuRpdInsertAfterRepository = "Insert After Repository";
        public const string MenuRpdAppendRepository = "Append Repository";
        // --
        public const string MenuRpdInsertBeforeColumn = "Insert Before Column";
        public const string MenuRpdInsertAfterColumn = "Insert After Column";
        public const string MenuRpdAppendColumn = "Append Column";
        
        // --

        public const string MenuRpdPopupMenu = "PopupMenu";       

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Environment Definition Menu
        // ***
        public const string MenuEndExpand = "Expand";
        public const string MenuEndCollapse = "Collapse";
        // --
        public const string MenuEndCut = "Cut";
        public const string MenuEndCopy = "Copy";                
        public const string MenuEndPasteSibling = "Paste Sibling";
        public const string MenuEndPasteChild = "Paste Child";
        // --
        public const string MenuEndRemove = "Remove";
        // --
        public const string MenuEndMoveUp = "Move Up";
        public const string MenuEndMoveDown = "Move Down";
        // --
        public const string MenuEndRelation = "Relation";
        // --
        public const string MenuEndInsertBeforeEnvironmentList = "Insert Before Environment List";
        public const string MenuEndInsertAfterEnvironmentList = "Insert After Environment List";
        public const string MenuEndAppendEnvironmentList = "Append Environment List";
        // --
        public const string MenuEndInsertBeforeEnvironment = "Insert Before Environment";
        public const string MenuEndInsertAfterEnvironment = "Insert After Environment";
        public const string MenuEndAppendEnvironment = "Append Environment";
        
        // --

        public const string MenuEndPopupMenu = "PopupMenu";

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Data Set Definition Menu        
        // ***
        public const string MenuDsdValidation = "Validation";
        // --
        public const string MenuDsdExpand = "Expand";
        public const string MenuDsdCollapse = "Collapse";
        // --
        public const string MenuDsdCut = "Cut";
        public const string MenuDsdCopy = "Copy";
        public const string MenuDsdPasteSibling = "Paste Sibling";
        public const string MenuDsdPasteChild = "Paste Child";
        // --
        public const string MenuDsdMoveUp = "Move Up";
        public const string MenuDsdMoveDown = "Move Down";
        // --
        public const string MenuDsdImportText = "Import Text";
        // --
        public const string MenuDsdRelation = "Relation";
        // --
        public const string MenuDsdRemove = "Remove";
        // --
        public const string MenuDsdInsertBeforeDataSetList = "Insert Before Data Set List";
        public const string MenuDsdInsertAfterDataSetList = "Insert After Data Set List";
        public const string MenuDsdAppendDataSetList = "Append Data Set List";
        // --
        public const string MenuDsdInsertBeforeDataSet = "Insert Before Data Set";
        public const string MenuDsdInsertAfterDataSet = "Insert After Data Set";
        public const string MenuDsdAppendDataSet = "Append Data Set";
        // --
        public const string MenuDsdInsertBeforeData = "Insert Before Data";
        public const string MenuDsdInsertAfterData = "Insert After Data";
        public const string MenuDsdAppendData = "Append Data";

        // --
        public const string MenuDsdGotoData = "GotoData";
        public const string MenuDsdGotoSource = "GotoSource";
        
        // --

        public const string MenuDsdPopupMenu = "PopupMenu";

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // SECS Library Modeler Menu
        // ***        
        public const string MenuSlmExpand = "Expand";
        public const string MenuSlmCollapse = "Collapse";
        // --
        public const string MenuSlmBatchModifier = "BatchModifier";
        public const string MenuSlmGemInspector = "GEM Inspector";
        public const string MenuSlmResetVersion = "ResetVersion";
        public const string MenuSlmReplace = "Replace";
        // --
        public const string MenuSlmCut = "Cut";
        public const string MenuSlmCopy = "Copy";
        public const string MenuSlmPasteSibling = "Paste Sibling";
        public const string MenuSlmPasteChild = "Paste Child";
        public const string MenuSlmPastePrimarySecsMessage = "Paste Primary SECS Message";
        public const string MenuSlmPasteSecondarySecsMessage = "Paste Secondary SECS Message";
        // --
        public const string MenuSlmImportStandardSecsMessages = "Import Standard SECS Messages";
        // --
        public const string MenuSlmRemove = "Remove";
        // --
        public const string MenuSlmMoveUp = "Move Up";
        public const string MenuSlmMoveDown = "Move Down";
        // --
        public const string MenuSlmRelation = "Relation";
        // --
        public const string MenuSlmConvertToSml = "Convert To SML";
        // --       
        public const string MenuSlmInsertBeforeSecsLibraryGroup = "Insert Before SECS Library Group";
        public const string MenuSlmInsertAfterSecsLibraryGroup = "Insert After SECS Library Group";
        public const string MenuSlmAppendSecsLibraryGroup = "Append SECS Library Group";
        // --        
        public const string MenuSlmInsertBeforeSecsLibrary = "Insert Before SECS Library";
        public const string MenuSlmInsertAfterSecsLibrary = "Insert After SECS Library";
        public const string MenuSlmAppendSecsLibrary = "Append SECS Library";
        // --
        public const string MenuSlmInsertBeforeSecsMessageList = "Insert Before SECS Message List";
        public const string MenuSlmInsertAfterSecsMessageList = "Insert After SECS Message List";
        public const string MenuSlmAppendSecsMessageList = "Append SECS Message List";
        // --        
        public const string MenuSlmInsertBeforeSecsMessages = "Insert Before SECS Messages";
        public const string MenuSlmInsertAfterSecsMessages = "Insert After SECS Messages";
        public const string MenuSlmAppendSecsMessages = "Append SECS Messages";
        // --
        public const string MenuSlmAppendPrimarySecsMessage = "Append Primary SECS Message";
        public const string MenuSlmAppendSecondarySecsMessage = "Append Secondary SECS Message";       
        // --
        public const string MenuSlmInsertBeforeSecsItem = "Insert Before SECS Item";
        public const string MenuSlmInsertAfterSecsItem = "Insert After SECS Item";
        public const string MenuSlmAppendSecsItem = "Append SECS Item";
        // --
        public const string MenuSlmSearch = "Search";

        // --
        
        public const string MenuSlmPopupMenu = "PopupMenu";

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // SECS Device Modeler Menu
        // ***        
        public const string MenuSdmOpenSecsDevice = "Open SECS Device";
        public const string MenuSdmCloseSecsDevice = "Close SECS Device";
        // --
        public const string MenuSdmSendSecsMessage = "Send SECS Message";
        // --
        public const string MenuSdmExpand = "Expand";
        public const string MenuSdmCollapse = "Collapse";
        // --
        public const string MenuSdmGemInspector = "GEM Inspector";
        public const string MenuSdmResetVersion = "ResetVersion";
        public const string MenuSdmReplace = "Replace";
        // --
        public const string MenuSdmCut = "Cut";
        public const string MenuSdmCopy = "Copy";
        public const string MenuSdmPasteSibling = "Paste Sibling";
        public const string MenuSdmPasteChild = "Paste Child";
        public const string MenuSdmPastePrimarySecsMessage = "Paste Primary SECS Message";
        public const string MenuSdmPasteSecondarySecsMessage = "Paste Secondary SECS Message";
        // --
        public const string MenuSdmRemove = "Remove";
        // --
        public const string MenuSdmMoveUp = "Move Up";
        public const string MenuSdmMoveDown = "Move Down";
        // --
        public const string MenuSdmRelation = "Relation";
        // --
        public const string MenuSdmConvertToSml = "Convert To SML";
        // --
        public const string MenuSdmImportStandardSecsMessages = "Import Standard SECS Messages";
        // --
        public const string MenuSdmInsertBeforeSecsDevice = "Insert Before SECS Device";
        public const string MenuSdmInsertAfterSecsDevice = "Insert After SECS Device";
        public const string MenuSdmAppendSecsDevice = "Append SECS Device";
        // --        
        public const string MenuSdmInsertBeforeSecsSession = "Insert Before SECS Session";
        public const string MenuSdmInsertAfterSecsSession = "Insert After SECS Session";
        public const string MenuSdmAppendSecsSession = "Append SECS Session";
        // --
        public const string MenuSdmInsertBeforeSecsMessageList = "Insert Before SECS Message List";
        public const string MenuSdmInsertAfterSecsMessageList = "Insert After SECS Message List";
        public const string MenuSdmAppendSecsMessageList = "Append SECS Message List";
        // --        
        public const string MenuSdmInsertBeforeSecsMessages = "Insert Before SECS Messages";
        public const string MenuSdmInsertAfterSecsMessages = "Insert After SECS Messages";
        public const string MenuSdmAppendSecsMessages = "Append SECS Messages";
        // --
        public const string MenuSdmAppendPrimarySecsMessage = "Append Primary SECS Message";
        public const string MenuSdmAppendSecondarySecsMessage = "Append Secondary SECS Message";
        // --
        public const string MenuSdmInsertBeforeSecsItem = "Insert Before SECS Item";
        public const string MenuSdmInsertAfterSecsItem = "Insert After SECS Item";
        public const string MenuSdmAppendSecsItem = "Append SECS Item";

        // --

        public const string MenuSdmPopupMenu = "PopupMenu";

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Host Library Modeler Menu
        // ***        
        public const string MenuHlmExpand = "Expand";
        public const string MenuHlmCollapse = "Collapse";
        // --
        public const string MenuHlmReplace = "Replace";
        // --
        public const string MenuHlmCut = "Cut";
        public const string MenuHlmCopy = "Copy";
        public const string MenuHlmPasteSibling = "Paste Sibling";
        public const string MenuHlmPasteChild = "Paste Child";
        public const string MenuHlmPastePrimaryHostMessage = "Paste Primary Host Message";
        public const string MenuHlmPasteSecondaryHostMessage = "Paste Secondary Host Message";
        // --
        public const string MenuHlmRemove = "Remove";
        // --
        public const string MenuHlmMoveUp = "Move Up";
        public const string MenuHlmMoveDown = "Move Down";
        // --
        public const string MenuHlmRelation = "Relation";
        // --
        public const string MenuHlmGenerate = "Generate";
        // --    
        public const string MenuHlmConvertToVfei = "Convert To VFEI";
        public const string MenuHlmInsertBeforeHostLibraryGroup = "Insert Before Host Library Group";
        public const string MenuHlmInsertAfterHostLibraryGroup = "Insert After Host Library Group";
        public const string MenuHlmAppendHostLibraryGroup = "Append Host Library Group";
        // --        
        public const string MenuHlmInsertBeforeHostLibrary = "Insert Before Host Library";
        public const string MenuHlmInsertAfterHostLibrary = "Insert After Host Library";
        public const string MenuHlmAppendHostLibrary = "Append Host Library";
        // --
        public const string MenuHlmInsertBeforeHostMessageList = "Insert Before Host Message List";
        public const string MenuHlmInsertAfterHostMessageList = "Insert After Host Message List";
        public const string MenuHlmAppendHostMessageList = "Append Host Message List";
        // --        
        public const string MenuHlmInsertBeforeHostMessages = "Insert Before Host Messages";
        public const string MenuHlmInsertAfterHostMessages = "Insert After Host Messages";
        public const string MenuHlmAppendHostMessages = "Append Host Messages";
        // --
        public const string MenuHlmAppendPrimaryHostMessage = "Append Primary Host Message";
        public const string MenuHlmAppendSecondaryHostMessage = "Append Secondary Host Message";
        // --
        public const string MenuHlmInsertBeforeHostItem = "Insert Before Host Item";
        public const string MenuHlmInsertAfterHostItem = "Insert After Host Item";
        public const string MenuHlmAppendHostItem = "Append Host Item";
        
        // --

        public const string MenuHlmPopupMenu = "PopupMenu";

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Host Device Modeler Menu
        // ***    
        public const string MenuHdmOpenHostDevice = "Open Host Device";
        public const string MenuHdmCloseHostDevice = "Close Host Device";
        // --
        public const string MenuHdmSendHostMessage = "Send Host Message";
        // --
        public const string MenuHdmExpand = "Expand";
        public const string MenuHdmCollapse = "Collapse";
        // --
        public const string MenuHdmReplace = "Replace";
        // --
        public const string MenuHdmCut = "Cut";
        public const string MenuHdmCopy = "Copy";
        public const string MenuHdmPasteSibling = "Paste Sibling";
        public const string MenuHdmPasteChild = "Paste Child";
        public const string MenuHdmPastePrimaryHostMessage = "Paste Primary Host Message";
        public const string MenuHdmPasteSecondaryHostMessage = "Paste Secondary Host Message";
        // --
        public const string MenuHdmRemove = "Remove";
        // --
        public const string MenuHdmMoveUp = "Move Up";
        public const string MenuHdmMoveDown = "Move Down";
        // --
        public const string MenuHdmRelation = "Relation";
        public const string MenuHdmResetHostDriver = "Reset Host Driver";
        // --       
        public const string MenuHdmConvertToVfei = "Convert To VFEI";
        // --
        public const string MenuHdmInsertBeforeHostDevice = "Insert Before Host Device";
        public const string MenuHdmInsertAfterHostDevice = "Insert After Host Device";
        public const string MenuHdmAppendHostDevice = "Append Host Device";
        // --        
        public const string MenuHdmInsertBeforeHostSession = "Insert Before Host Session";
        public const string MenuHdmInsertAfterHostSession = "Insert After Host Session";
        public const string MenuHdmAppendHostSession = "Append Host Session";
        // --
        public const string MenuHdmInsertBeforeHostMessageList = "Insert Before Host Message List";
        public const string MenuHdmInsertAfterHostMessageList = "Insert After Host Message List";
        public const string MenuHdmAppendHostMessageList = "Append Host Message List";
        // --        
        public const string MenuHdmInsertBeforeHostMessages = "Insert Before Host Messages";
        public const string MenuHdmInsertAfterHostMessages = "Insert After Host Messages";
        public const string MenuHdmAppendHostMessages = "Append Host Messages";
        // --
        public const string MenuHdmAppendPrimaryHostMessage = "Append Primary Host Message";
        public const string MenuHdmAppendSecondaryHostMessage = "Append Secondary Host Message";
        // --
        public const string MenuHdmInsertBeforeHostItem = "Insert Before Host Item";
        public const string MenuHdmInsertAfterHostItem = "Insert After Host Item";
        public const string MenuHdmAppendHostItem = "Append Host Item";
        
        // --        

        public const string MenuHdmPopupMenu = "PopupMenu";

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Equipment Modeler Menu
        // ***
        public const string MenuEqmSendSecsMessage = "Send SECS Message";
        public const string MenuEqmSendHostMessage = "Send Host Message";
        // --
        public const string MenuEqmExpand = "Expand";
        public const string MenuEqmCollapse = "Collapse";
        // --
        public const string MenuEqmReplace = "Replace";
        // --
        public const string MenuEqmCut = "Cut";
        public const string MenuEqmCopy = "Copy";
        public const string MenuEqmPasteSibling = "Paste Sibling";
        public const string MenuEqmPasteChild = "Paste Child";
        // --
        public const string MenuEqmClone = "Clone";
        public const string MenuEqmMerge = "Merge";
        // --
        public const string MenuEqmRemove = "Remove";
        // --
        public const string MenuEqmMoveUp = "Move Up";
        public const string MenuEqmMoveDown = "Move Down";
        // --
        public const string MenuEqmRelation = "Relation";
        // --
        public const string MenuEqmScenarioModeler = "Scenario Modeler";
        // --
        public const string MenuEqmInsertBefore = "Insert Before";
        public const string MenuEqmInsertAfter = "Insert After";
        // --
        public const string MenuEqmInsertBeforeEquipment = "Insert Before Equipment";
        public const string MenuEqmInsertAfterEquipment = "Insert After Equipment";
        public const string MenuEqmAppendEquipment = "Append Equipment";
        // --
        public const string MenuEqmInsertBeforeScenarioGroup = "Insert Before Scenario Group";
        public const string MenuEqmInsertAfterScenarioGroup = "Insert After Scenario Group";
        public const string MenuEqmAppendScenarioGroup = "Append Scenario Group";
        // --
        public const string MenuEqmInsertBeforeScenario = "Insert Before Scenario";
        public const string MenuEqmInsertAfterScenario = "Insert After Scenario";
        public const string MenuEqmAppendScenario = "Append Scenario";
        // --
        public const string MenuEqmInsertBeforeSecsTrigger = "Insert Before SECS Trigger";
        public const string MenuEqmInsertAfterSecsTrigger = "Insert After SECS Trigger";
        public const string MenuEqmAppendSecsTrigger = "Append SECS Trigger";
        // --
        public const string MenuEqmInsertBeforeSecsTransmitter = "Insert Before SECS Transmitter";
        public const string MenuEqmInsertAfterSecsTransmitter = "Insert After SECS Transmitter";
        public const string MenuEqmAppendSecsTransmitter = "Append SECS Transmitter";
        // --
        public const string MenuEqmInsertBeforeHostTrigger = "Insert Before Host Trigger";
        public const string MenuEqmInsertAfterHostTrigger = "Insert After Host Trigger";
        public const string MenuEqmAppendHostTrigger = "Append Host Trigger";
        // --
        public const string MenuEqmInsertBeforeHostTransmitter = "Insert Before Host Transmitter";
        public const string MenuEqmInsertAfterHostTransmitter = "Insert After Host Transmitter";
        public const string MenuEqmAppendHostTransmitter = "Append Host Transmitter";
        // --
        public const string MenuEqmInsertBeforeEquipmentStateSetAlterer = "Insert Before Equipment State Set Alterer";
        public const string MenuEqmInsertAfterEquipmentStateSetAlterer = "Insert After Equipment State Set Alterer";
        public const string MenuEqmAppendEquipmentStateSetAlterer = "Append Equipment State Set Alterer";
        // --
        public const string MenuEqmInsertBeforeJudgement = "Insert Before Judgement";
        public const string MenuEqmInsertAfterJudgement = "Insert After Judgement";
        public const string MenuEqmAppendJudgement = "Append Judgement";
        // --
        public const string MenuEqmInsertBeforeMapper = "Insert Before Mapper";
        public const string MenuEqmInsertAfterMapper = "Insert After Mapper";
        public const string MenuEqmAppendMapper = "Append Mapper";
        // --
        public const string MenuEqmInsertBeforeStorage = "Insert Before Storage";
        public const string MenuEqmInsertAfterStorage = "Insert After Storage";
        public const string MenuEqmAppendStorage = "Append Storage";
        // --
        public const string MenuEqmInsertBeforeCallback = "Insert Before Callback";
        public const string MenuEqmInsertAfterCallback = "Insert After Callback";
        public const string MenuEqmAppendCallback = "Append Callback";
        // --
        public const string MenuEqmInsertBeforeBranch = "Insert Before Branch";
        public const string MenuEqmInsertAfterBranch = "Insert After Branch";
        public const string MenuEqmAppendBranch = "Append Branch";
        // --
        public const string MenuEqmInsertBeforeComment = "Insert Before Comment";
        public const string MenuEqmInsertAfterComment = "Insert After Comment";
        public const string MenuEqmAppendComment = "Append Comment";
        // --
        public const string MenuEqmInsertBeforePauser = "Insert Before Pauser";
        public const string MenuEqmInsertAfterPauser = "Insert After Pauser";
        public const string MenuEqmAppendPauser = "Append Pauser";
        // --
        public const string MenuEqmInsertBeforeEntryPoint = "Insert Before Entry Point";
        public const string MenuEqmInsertAfterEntryPoint = "Insert After Entry Point";
        public const string MenuEqmAppendEntryPoint = "Append Entry Point";
        // --
        public const string MenuEqmInsertBeforeSecsCondition = "Insert Before SECS Condition";
        public const string MenuEqmInsertAfterSecsCondition = "Insert After SECS Condition";
        public const string MenuEqmAppendSecsCondition = "Append SECS Condition";
        // --
        public const string MenuEqmInsertBeforeSecsExpression = "Insert Before SECS Expression";
        public const string MenuEqmInsertAfterSecsExpression = "Insert After SECS Expression";
        public const string MenuEqmAppendSecsExpression = "Append SECS Expression";
        // -- 
        public const string MenuEqmInsertBeforeSecsTransfer = "Insert Before SECS Transfer";
        public const string MenuEqmInsertAfterSecsTransfer = "Insert After SECS Transfer";
        public const string MenuEqmAppendSecsTransfer = "Append SECS Transfer";
        // --
        public const string MenuEqmInsertBeforeHostCondition = "Insert Before Host Condition";
        public const string MenuEqmInsertAfterHostCondition = "Insert After Host Condition";
        public const string MenuEqmAppendHostCondition = "Append Host Condition";
        // --
        public const string MenuEqmInsertBeforeHostExpression = "Insert Before Host Expression";
        public const string MenuEqmInsertAfterHostExpression = "Insert After Host Expression";
        public const string MenuEqmAppendHostExpression = "Append Host Expression";
        // --
        public const string MenuEqmInsertBeforeHostTransfer = "Insert Before Host Transfer";
        public const string MenuEqmInsertAfterHostTransfer = "Insert After Host Transfer";
        public const string MenuEqmAppendHostTransfer = "Append Host Transfer";
        // --
        public const string MenuEqmInsertBeforeEquipmentStateAlterer = "Insert Before Equipment State Alterer";
        public const string MenuEqmInsertAfterEquipmentStateAlterer = "Insert After Equipment State Alterer";
        public const string MenuEqmAppendEquipmentStateAlterer = "Append Equipment State Alterer";
        // --
        public const string MenuEqmInsertBeforeJudgementCondition = "Insert Before Judgement Condition";
        public const string MenuEqmInsertAfterJudgementCondition = "Insert After Judgement Condition";
        public const string MenuEqmAppendJudgementCondition = "Append Judgement Condition";
        // --
        public const string MenuEqmInsertBeforeJudgementExpression = "Insert Before Judgement Expression";
        public const string MenuEqmInsertAfterJudgementExpression = "Insert After Judgement Expression";
        public const string MenuEqmAppendJudgementExpression = "Append Judgement Expression";
        // --
        public const string MenuEqmInsertBeforeFunction = "Insert Before Function";
        public const string MenuEqmInsertAfterFunction = "Insert After Function";
        public const string MenuEqmAppendFunction = "Append Function";      
        
        // --

        public const string MenuEqmPopupMenu = "PopupMenu";        

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Scenario Modeler Menu
        // ***
        public const string MenuSnrExpand = "Expand";
        public const string MenuSnrCollapse = "Collapse";
        // --
        public const string MenuSnrReplace = "Replace";
        // 
        public const string MenuSnrCut = "Cut";
        public const string MenuSnrCopy = "Copy";
        public const string MenuSnrPasteSibling = "Paste Sibling";
        public const string MenuSnrPasteChild = "Paste Child";
        // --
        public const string MenuSnrMoveUp = "Move Up";
        public const string MenuSnrMoveDown = "Move Down";
        // --
        public const string MenuSnrRelation = "Relation";
        // --
        public const string MenuSnrRemove = "Remove";
        // --
        public const string MenuSnrInsertBefore = "Insert Before";
        public const string MenuSnrInsertAfter = "Insert After";
        // --
        public const string MenuSnrInsertBeforeSecsTrigger = "Insert Before SECS Trigger";
        public const string MenuSnrInsertAfterSecsTrigger = "Insert After SECS Trigger";
        public const string MenuSnrAppendSecsTrigger = "Append SECS Trigger";
        // --
        public const string MenuSnrInsertBeforeSecsTransmitter = "Insert Before SECS Transmitter";
        public const string MenuSnrInsertAfterSecsTransmitter = "Insert After SECS Transmitter";
        public const string MenuSnrAppendSecsTransmitter = "Append SECS Transmitter";
        // --
        public const string MenuSnrInsertBeforeHostTrigger = "Insert Before Host Trigger";
        public const string MenuSnrInsertAfterHostTrigger = "Insert After Host Trigger";
        public const string MenuSnrAppendHostTrigger = "Append Host Trigger";
        // --
        public const string MenuSnrInsertBeforeHostTransmitter = "Insert Before Host Transmitter";
        public const string MenuSnrInsertAfterHostTransmitter = "Insert After Host Transmitter";
        public const string MenuSnrAppendHostTransmitter = "Append Host Transmitter";
        // --
        public const string MenuSnrInsertBeforeEquipmentStateSetAlterer = "Insert Before Equipment State Set Alterer";
        public const string MenuSnrInsertAfterEquipmentStateSetAlterer = "Insert After Equipment State Set Alterer";
        public const string MenuSnrAppendEquipmentStateSetAlterer = "Append Equipment State Set Alterer";
        // --
        public const string MenuSnrInsertBeforeJudgement = "Insert Before Judgement";
        public const string MenuSnrInsertAfterJudgement = "Insert After Judgement";
        public const string MenuSnrAppendJudgement = "Append Judgement";
        // --
        public const string MenuSnrInsertBeforeMapper = "Insert Before Mapper";
        public const string MenuSnrInsertAfterMapper = "Insert After Mapper";
        public const string MenuSnrAppendMapper = "Append Mapper";
        // --
        public const string MenuSnrInsertBeforeStorage = "Insert Before Storage";
        public const string MenuSnrInsertAfterStorage = "Insert After Storage";
        public const string MenuSnrAppendStorage = "Append Storage";
        // --
        public const string MenuSnrInsertBeforeCallback = "Insert Before Callback";
        public const string MenuSnrInsertAfterCallback = "Insert After Callback";
        public const string MenuSnrAppendCallback = "Append Callback";
        // --
        public const string MenuSnrInsertBeforeBranch = "Insert Before Branch";
        public const string MenuSnrInsertAfterBranch = "Insert After Branch";
        public const string MenuSnrAppendBranch = "Append Branch";
        // --
        public const string MenuSnrInsertBeforeComment = "Insert Before Comment";
        public const string MenuSnrInsertAfterComment = "Insert After Comment";
        public const string MenuSnrAppendComment = "Append Comment";
        // --
        public const string MenuSnrInsertBeforePauser = "Insert Before Pauser";
        public const string MenuSnrInsertAfterPauser = "Insert After Pauser";
        public const string MenuSnrAppendPauser = "Append Pauser";
        // --
        public const string MenuSnrInsertBeforeEntryPoint = "Insert Before Entry Point";
        public const string MenuSnrInsertAfterEntryPoint = "Insert After Entry Point";
        public const string MenuSnrAppendEntryPoint = "Append Entry Point";
        // --
        public const string MenuSnrInsertBeforeSecsCondition = "Insert Before SECS Condition";
        public const string MenuSnrInsertAfterSecsCondition = "Insert After SECS Condition";
        public const string MenuSnrAppendSecsCondition = "Append SECS Condition";
        // --
        public const string MenuSnrInsertBeforeSecsExpression = "Insert Before SECS Expression";
        public const string MenuSnrInsertAfterSecsExpression = "Insert After SECS Expression";
        public const string MenuSnrAppendSecsExpression = "Append SECS Expression";
        // -- 
        public const string MenuSnrInsertBeforeSecsTransfer = "Insert Before SECS Transfer";
        public const string MenuSnrInsertAfterSecsTransfer = "Insert After SECS Transfer";
        public const string MenuSnrAppendSecsTransfer = "Append SECS Transfer";
        // --
        public const string MenuSnrInsertBeforeHostCondition = "Insert Before Host Condition";
        public const string MenuSnrInsertAfterHostCondition = "Insert After Host Condition";
        public const string MenuSnrAppendHostCondition = "Append Host Condition";
        // --
        public const string MenuSnrInsertBeforeHostExpression = "Insert Before Host Expression";
        public const string MenuSnrInsertAfterHostExpression = "Insert After Host Expression";
        public const string MenuSnrAppendHostExpression = "Append Host Expression";
        // --
        public const string MenuSnrInsertBeforeHostTransfer = "Insert Before Host Transfer";
        public const string MenuSnrInsertAfterHostTransfer = "Insert After Host Transfer";
        public const string MenuSnrAppendHostTransfer = "Append Host Transfer";
        // --
        public const string MenuSnrInsertBeforeEquipmentStateAlterer = "Insert Before Equipment State Alterer";
        public const string MenuSnrInsertAfterEquipmentStateAlterer = "Insert After Equipment State Alterer";
        public const string MenuSnrAppendEquipmentStateAlterer = "Append Equipment State Alterer";
        // --
        public const string MenuSnrInsertBeforeJudgementCondition = "Insert Before Judgement Condition";
        public const string MenuSnrInsertAfterJudgementCondition = "Insert After Judgement Condition";
        public const string MenuSnrAppendJudgementCondition = "Append Judgement Condition";
        // --
        public const string MenuSnrInsertBeforeJudgementExpression = "Insert Before Judgement Expression";
        public const string MenuSnrInsertAfterJudgementExpression = "Insert After Judgement Expression";
        public const string MenuSnrAppendJudgementExpression = "Append Judgement Expression";
        // --
        public const string MenuSnrInsertBeforeFunction = "Insert Before Function";
        public const string MenuSnrInsertAfterFunction = "Insert After Function";
        public const string MenuSnrAppendFunction = "Append Function";      
        
        // --

        public const string MenuSnrPopupMenu = "PopupMenu";

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Value Transformation Editor Menu
        // ***
        public const string MenuVteMoveUp = "Move Up";
        public const string MenuVteMoveDown = "Move Down";
        // --
        public const string MenuVteRemoveValueFormula = "Remove Value Formula";
        public const string MenuVteRemoveAllValueFormula = "Remove All Value Formula";
        // --       
        public const string MenuVteInsertBeforeValueFormula = "Insert Before Value Formula";
        public const string MenuVteInsertAfterValueFormula = "Insert After Value Formula";
        // --
        public const string MenuVteAppendValueFormula = "Append Value Formula";
        
        // --       

        public const string MenuVtePopupMenu = "PopupMenu";

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Precondition Editor Menu
        // ***
        public const string MenuPrcMoveUp = "Move Up";
        public const string MenuPrcMoveDown = "Move Down";
        // --
        public const string MenuPrcRemoveValue = "Remove Value";
        public const string MenuPrcRemoveAllValue = "Remove All Value";
        // --
        public const string MenuPrcInsertBeforeValue = "Insert Before Value";
        public const string MenuPrcInsertAfterValue = "Insert After Value";
        //--
        public const string MenuPrcAppendValue = "Append Value";

        // --

        public const string MenuPrcPopupMenu = "PopupMenu";

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Font Option Menu
        // ***
        public const string MenuFontName = "Font Name";
        public const string MenuFontSize = "Font Size";

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2012.11.16 by spike.lee
        // Menu 이름 정할때 신경 좀 씁시다. 기존에 기능이 변경되었으면 전체적으로 확인하고 생각해서 처리해야 합니다.
        // Trace View와 Trace Stop는 관련된 기능인데 Menu 명은 전혀 관련이 없는거 같습니다.
        // --
        // SECS Binary Tracer Menu
        // ***        
        public const string MenuSbtTraceEnabled = "Trace Enabled";
        public const string MenuSbtTraceDisabled = "Trace Disabled";
        public const string MenuSbtFreezeScreen = "Freeze Screen";
        public const string MenuSbtUnfreezeScreen = "Unfreeze Screen";
        public const string MenuSbtMaxTraceCount = "Max Trace Count";
        public const string MenuSbtClear = "Clear";

        //------------------------------------------------------------------------------------------------------------------------

        // ***        
        // 2012.11.16 by spike.lee
        // SECS Binary Tracer Menu과 동일합니다.
        // --
        // Sml Tracer Menu
        // ***
        public const string MenuSmtTraceEnabled = "Trace Enabled";
        public const string MenuSmtTraceDisabled = "Trace Disabled";
        public const string MenuSmtFreezeScreen = "Freeze Screen";
        public const string MenuSmtUnfreezeScreen = "Unfreeze Screen";
        public const string MenuSmtMaxTraceCount = "Max Trace Count";
        public const string MenuSmtClear = "Clear";

        //------------------------------------------------------------------------------------------------------------------------

        // ***        
        // 2012.11.16 by spike.lee
        // SECS Binary Tracer Menu과 동일합니다.
        // --
        // Vfei Tracer Menu
        // ***
        public const string MenuVftTraceEnabled = "Trace Enabled";
        public const string MenuVftTraceDisabled = "Trace Disabled";
        public const string MenuVftFreezeScreen = "Freeze Screen";
        public const string MenuVftUnfreezeScreen = "Unfreeze Screen";
        public const string MenuVftMaxTraceCount = "Max Trace Count";
        public const string MenuVftClear = "Clear";

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Log Tracer Menu
        // ***
        public const string MenuLgtFreezeScreen = "Freeze Screen";
        public const string MenuLgtUnfreezeScreen = "Unfreeze Screen";
        // --
        public const string MenuLgtExpand = "Expand";
        public const string MenuLgtCollapse = "Collapse";        
        // --
        public const string MenuLgtOpen = "Open";
        public const string MenuLgtNew = "New";
        public const string MenuLgtSave = "Save";
        public const string MenuLgtSaveAs = "Save As";
        // --
        public const string MenuLgtCopy = "Copy";
        // --
        public const string MenuLgtClear = "Clear";
        // --
        public const string MenuLgtConvertToSml = "Convert To SML";
        public const string MenuLgtConvertToVfei = "Convert To VFEI";
        // --
        public const string MenuLgtConvertToInterfaceTrace = "Convert To Interface Trace";
        // --
        public const string MenuLgtFilterSelector = "Log Filter";
        // --
        public const string MenuLgtPlugInComponent = "Plug in Component";
        public const string MenuLgtReloadComponent = "Reload Component";
        // --

        // --

        public const string MenuLgtPopupMenu = "PopupMenu";

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Interface Tracer Menu
        // ***
        public const string MenuIftFreezeScreen = "Freeze Screen";
        public const string MenuIftUnfreezeScreen = "Unfreeze Screen";        
        // --
        public const string MenuIftClear = "Clear";     
        // --
        public const string MenuIftConvertToSml = "Convert To SML";
        public const string MenuIftConvertToVfei = "Convert To VFEI";
        // --        
        public const string MenuIftExpand = "Expand";
        public const string MenuIftCollapse = "Collapse";
        //
        public const string MenuIftCopy = "Copy";
        // --
        public const string MenuIftPopupMenuGrid = "PopupMenuGrid";
        public const string MenuIftPopupMenuTree = "PopupMenuTree";

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // SML Viewer Menu
        // ***
        public const string menuSmvRefresh = "Refresh";
        public const string MenuSmvFind = "Find";
        public const string MenuSmvOpen = "Open";
        public const string MenuSmvSave = "Save";
        public const string MenuSmvSaveAs = "Save As";
        public const string MenuSmvClear = "Clear";

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // VFEI Viewer Menu
        // ***
        public const string menuVfeRefresh = "Refresh";
        public const string MenuVfeFind = "Find";
        public const string MenuVfeOpen = "Open";
        public const string MenuVfeSave = "Save";
        public const string MenuVfeSaveAs = "Save As";
        public const string MenuVfeClear = "Clear";

        //------------------------------------------------------------------------------------------------------------------------
        
        // ***
        // 2012.11.16 by spike.lee
        // 주석 정확이 기록합시다. Function Name Definition Menu가 아닙니다.
        // Relation Viewer Menu        
        // ***
        public const string MenuRelGoto = "Goto";
        public const string MenuRefresh = "Refresh";

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
