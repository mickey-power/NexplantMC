/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FMenuKey.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.28
--  Description     : FAMate Workspace Manager Menu Key Class 
--  History         : Created by spike.lee at 2010.12.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.WorkspaceManager
{
    public static class FMenuKey
    {

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // System Ribbon Menu
        // ***
        public const string MenuLogin = "Login";
        public const string MenuLogout = "Logout";
        public const string MenuPasswordChange = "Password Change";
        public const string MenuOption = "Option";
        public const string MenuListRecentFile = "listRecentFile";
        public const string MenuExit = "Exit";

        // --

        // ***
        // Development Tool Ribbon Menu
        // ***
        public const string MenuLanguageFileEditor = "Language File Editor";
        public const string MenuApplicationLogViewer = "Application Log Viewer";
        public const string MenuLogViewer = "Log Viewer";
        // --
        public const string MenuSourceGenerator = "Source Generator";
        public const string MenuSqlManager = "SQL Manager";        

        // --

        // ***
        // Application Ribbon Menu
        // ***        
        public const string MenuSecsModeler = "SECS Modeler";
        public const string MenuOpcModeler = "OPC Modeler";
        public const string MenuTcpModeler = "TCP Modeler";  
        // --
        public const string MenuAdminManager = "Admin Manager";        

        // --

        public const string MenuPopupSourceGenerator = "P_Source Generator";
        public const string MenuPopupSecsModeler = "P_SECS Modeler";
        public const string MenuPopupPlcModeler = "P_PLC Modeler";
        public const string MenuPopupLogViewer = "P_Log Viewer";
        // --
        public const string MenuRecentlyDocuments = "Recently Documents";
        
        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
