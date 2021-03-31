/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FMenuKey.cs
--  Creator         : mj.kim
--  Create Date     : 2011.09.23
--  Description     : FAMate SQL Manager Menu Key Class 
--  History         : Created by mj.kim at 2011.09.23
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.SqlManager
{
    public static class FMenuKey
    {

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Main Menu
        // ***
        public const string MenuFile = "File";
        // --
        public const string MenuReconnection = "Reconnection";
        public const string MenuExit = "Exit";

        // --

        public const string MenuSetup = "Setup";
        // --
        public const string MenuSystem = "System";
        public const string MenuModule = "Module";
        public const string MenuFunction = "Function";
        public const string MenuSqlCode = "SQL Code";

        // --

        public const string MenuTool = "Tool";
        // --
        public const string MenuSqlExplorer = "SQL Explorer";
        public const string MenuSqlWorksheet = "SQL Worksheet";

        // --

        public const string MenuView = "View";
        // --
        public const string MenuSqlServiceLogList = "Sql Service Log List";

        // --

        public const string MenuHelp = "Help";
        // --
        public const string MenuAbout = "About";

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // SQL Explorer Menu
        // ***        
        public const string MenuSqeRefresh = "Refresh";
        public const string MenuSqeSave = "Save";
        // --
        public const string MenuSqeExpand = "Expand";
        public const string MenuSqeCollapse = "Collapse";
        public const string MenuSqeCompatible = "Compatible";
        // --
        public const string MenuSqeDownload = "Download";
        public const string MenuSqeMigration = "Migration";
        public const string MenuSqeParameter = "Parameter";
        public const string MenuSqeExecuteSql = "Execute";
        // --        
        public const string MenuSqeCut = "Cut";
        public const string MenuSqeCopy = "Copy";
        public const string MenuSqePaste = "Paste";
        // --
        public const string MenuSqeRemove = "Remove";
        // --
        public const string MenuSqeMoveUp = "Move Up";
        public const string MenuSqeMoveDown = "Move Down";
        // --
        public const string MenuSqeAppendSystem = "Append System";
        // --
        public const string MenuSqeInsertBeforeSystem = "Insert Before System";
        public const string MenuSqeInsertAfterSystem = "Insert After System";
        // --
        public const string MenuSqeAppendModule = "Append Module";
        // --
        public const string MenuSqeInsertBeforeModule = "Insert Before Module";
        public const string MenuSqeInsertAfterModule = "Insert After Module";
        // --
        public const string MenuSqeAppendFunction = "Append Function";
        // --
        public const string MenuSqeInsertBeforeFunction = "Insert Before Function";
        public const string MenuSqeInsertAfterFunction = "Insert After Function";
        // --
        public const string MenuSqeAppendSqlCode = "Append SQL Code";
        // --
        public const string MenuSqeInsertBeforeSqlCode = "Insert Before SQL Code";
        public const string MenuSqeInsertAfterSqlCode = "Insert After SQL Code";
        // --
        public const string MenuPopupMenu = "PopupMenu";

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // SQL Worksheet Menu
        // ***      
        public const string MenuSqwRefresh = "Refresh";
        public const string MenuSqwSave = "Save";
        // --
        public const string MenuSqwExecuteSql = "Execute";
        // --        
        public const string MenuSqwClear = "Clear";
        public const string MenuSqwToUpperLowerInitCap = "ToUpper/Lower/InitCap";
        public const string MenuSqwComment = "Comment";
        public const string MenuSqwCommentRemove = "Comment Remove";
        public const string MenuSqwIndent = "Indent";
        public const string MenuSqwIndentRemove = "Indent Remove";
        // --
        public const string MenuSqwClose = "Close";
        public const string MenuSqwTotalCount = "Total Count";

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // SQL Service Log
        // ***
        public const string MenuSqlRefresh = "Refresh";
        public const string MenuSqlExport = "Export";
        public const string MenuSqlDownload = "Download";
        public const string MenuSqlView = "View";
        
        // --

        public const string MenuSqlPopupMenu = "PopupMenu";

        // --

        public const string MenuSqlFind = "Find";

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Font Option Menu
        // ***
        public const string MenuFontName = "Font Name";
        public const string MenuFontSize = "Font Size";

        //------------------------------------------------------------------------------------------------------------------------


        // ***
        // Window
        // ***
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

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
