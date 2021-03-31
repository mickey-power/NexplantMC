/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlTagSQMOption.cs
--  Creator         : mj.kim
--  Create Date     : 2011.09.23
--  Description     : FAMate SQL Manager Option XML Tag Definition Class 
--  History         : Created by mj.kim at 2011.09.23
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.SqlManager
{
    public static class FXmlTagSQMOption
    {

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // - E_SQMOption
        //   - E_RecentConnection
        //   - E_ConnectionList
        //     - Connection
        //   - E_RecentDatabase
        //     - DatabaseList
        //     - Database        
        // ***

        // ***
        // FAMate SQL Manager Option Element
        // ***
        public const string E_SQMOption = "SQO";

        // --

        // ***
        // FAMate SQL Manager Option Attribute
        // ***
        public const string A_FontName = "FNA";
        public const string A_FontSize = "FSZ";
        // --
        public const string D_FontName = "Verdana";
        public const string D_FontSize = "8";

        // --

        // ***
        // Recent Connection Option Element
        // ***
        public const string E_RecentConnectionOption = "RCO";

        //--

        // ***
        // Connection Option List Element
        // ***
        public const string E_ConnectionOptionList = "COL";
        
        // --
        
        // ***
        // Connection Option Element
        // ***
        public const string E_ConnectionOption = "CNO";

        // --

        // ***
        // Common Connection Option Attribute - RecentConnection, Connection
        // ***
        public const string A_Connection = "CNN";
        public const string A_ConnectionDescription = "DEC";
        public const string A_ConnectionStationConnectString = "SCS";
        public const string A_ConnectionStationTimeout = "STO";
        public const string A_ConnectionTuneChannelId = "TCI";
        public const string A_ConnectionCastChannelId = "CCI";
        public const string A_ConnectionFtpIp = "FTI";
        public const string A_ConnectionFtpAnonymous = "FAN";
        public const string A_ConnectionFtpUser = "FUR";
        public const string A_ConnectionFtpPassword = "FPW";
        // --
        public const string D_Connection = "local";
        public const string D_ConnectionDescription = "";
        public const string D_ConnectionStationConnectString = "127.0.0.1:10101";
        public const string D_ConnectionStationTimeout = "30000";
        public const string D_ConnectionTuneChannelId = "/FMS/SQSSQM";
        public const string D_ConnectionCastChannelId = "/FMS/SQMSQS";
        public const string D_ConnectionFtpIp = "127.0.0.1";
        public const string D_ConnectionFtpAnonymous = "True";
        public const string D_ConnectionFtpUser = "anonymous";
        public const string D_ConnectionFtpPassword = "";
        
        // --

        // ***
        // Recent Database Option Element
        // ***
        public const string E_RecentDatabaseOption = "RDO";

        //--

        // ***
        // Database Option List Element
        // ***
        public const string E_DatabaseOptionList = "DOL";

        // --
        
        // ***
        // Database Option Element
        // ***
        public const string E_DatabaseOption = "DBO";

        // --
        
        // ***
        // Common DataBase Option Attribute - RecentDatabase, Database
        // ***
        public const string A_Database = "DBS";
        public const string A_DatabaseDescription = "DEC";
        public const string A_DatabaseProvider = "DPV";
        public const string A_DatabaseConnectString = "DCS";
        public const string A_DatabasePassword = "DPW";
        public const string A_DatabaseTimeout = "DTO";
        public const string A_DownloadDatabase = "DDB";
        // --
        public const string D_Database = "FADB";
        public const string D_DatabaseDescription = "";
        public const string D_DatabaseProvider = "MsSqlServer";
        public const string D_DatabaseConnectString = "Persist Security Info=False;User ID=fa;Password={0};Initial Catalog=FADB;Server=";
        public const string D_DatabasePassword = "";
        public const string D_DatabaseTimeout = "30"; // sec
        public const string D_DownloadDatabase = "";

        // --

        // ***
        // Recent Path
        // ***
        public const string A_RecentDownloadPath = "RFP";
        public const string A_RecentLogDownloadPath = "RLP";
        public const string A_RecentExportPath = "REP";
        // --
        public const string D_RecentDownloadPath = "";
        public const string D_RecentLogDownloadPath = "";
        public const string D_RecentExportPath = "";

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
