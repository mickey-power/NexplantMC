/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSQMSQS_SetSqlCodeUpdate_In.cs
--  Creator         : mjkim
--  Create Date     : 2013.11.11
--  Description     : <Generated Class File Description>
--  History         : Created by mjkim at 2013.11.11
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.H101Interface
{
    internal static class FSQMSQS_SetSqlCodeUpdate_In
    {

        //------------------------------------------------------------------------------------------------------------------------

        public const string E_SQMSQS_SetSqlCodeUpdate_In = "SQMSQS_SetSqlCodeUpdate_In";

        // --

        public const string A_hLanguage = "hLanguage";
        public const string A_hStep = "hStep";

        // --

        public const string D_hLanguage = "";
        public const string D_hStep = "";

        // --

        public static class FSqlCode
        {
            public const string E_SqlCode = "SqlCode";

            // --

            public const string A_System = "System";
            public const string A_Module = "Module";
            public const string A_Function = "Function";
            public const string A_UniqueId = "UniqueId";
            public const string A_SqlCode = "SqlCode";
            public const string A_Description = "Description";
            public const string A_UsedMigration = "UsedMigration";

            // --

            public const string D_System = "";
            public const string D_Module = "";
            public const string D_Function = "";
            public const string D_UniqueId = "";
            public const string D_SqlCode = "";
            public const string D_Description = "";
            public const string D_UsedMigration = "";

            // --

            public static class FQuery
            {
                public const string E_Query = "Query";

                // --

                public const string A_DbProvider = "DbProvider";
                public const string A_Query = "Query";

                // --

                public const string D_DbProvider = "";
                public const string D_Query = "";

                // --

                public static class FParameter
                {
                    public const string E_Parameter = "Parameter";

                    // --

                    public const string A_Parameter = "Parameter";

                    // --

                    public const string D_Parameter = "";
                }
            }
        }

        // --

        public static class FReference
        {
            public const string E_Reference = "Reference";

            // --

            public const string A_UniqueId = "UniqueId";

            // --

            public const string D_UniqueId = "";
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
