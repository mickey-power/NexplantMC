/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlTagSqlCode.cs
--  Creator         : mj.kim
--  Create Date     : 2012.01.12
--  Description     : FAMate Core FaCommon SQL Code XML Tag Definition Class 
--  History         : Created by mj.kim at 2012.01.12
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    public static class FXmlTagSqlCode
    {

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // FAMate Core FaCommon SQL Code Element and Attribute
        // ***
        public const string E_SqlCode = "SQC";

        // --

        public const string A_UniqueId = "I";
        public const string A_SqlCode = "SQC";
        public const string A_Description = "D";
        public const string A_UsedSqlMigration = "UMG";
        public const string A_MsSqlQuery = "MSQ";
        public const string A_MsSqlParameter = "MSP";
        public const string A_OracleQuery = "ORQ";
        public const string A_OracleParameter = "ORP";
        public const string A_MySqlQuery = "MYQ";
        public const string A_MySqlParameter = "MYP";
        public const string A_MariaDbQuery = "MDQ";
        public const string A_MariaDbParameter = "MDP";
        public const string A_PostgreSqlQuery = "PGQ";
        public const string A_PostgreSqlParameter = "PGP";

        // --

        public const string D_UniqueId = "";
        public const string D_SqlCode = "";
        public const string D_Description = "";
        public const string D_UsedSqlMigration = "Yes";
        public const string D_MsSqlQuery = "";
        public const string D_MsSqlParameter = "";
        public const string D_OracleQuery = "";
        public const string D_OracleParameter = "";
        public const string D_MySqlQuery = "";
        public const string D_MySqlParameter = "";
        public const string D_MariaDbQuery = "";
        public const string D_MariaDbParameter = "";
        public const string D_PostgreSqlQuery = "";
        public const string D_PostgreSqlParameter = "";

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
