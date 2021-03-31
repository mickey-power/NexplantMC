/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSQMSQS_SetFunctionSearch_Out.cs
--  Creator         : mj.kim
--  Create Date     : 2011.10.28
--  Description     : FAMate SQL Service Setup Function Inforamtion Out XML Tag Definition Class 
--  History         : Created by mj.kim at 2011.10.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.H101Interface
{
    public static class FSQMSQS_SetFunctionSearch_Out
    {

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // FAMate SQL Service Function Information Out Element and Attribute
        // ***
        public const string E_SQMSQS_SetFunctionSearch_Out = "SQMSQS_SetFunctionSearch_Out";
        // --
        public const string A_hStatus = "hStatus";
        public const string A_hStatusMessage = "hStatusMessage";
        // --
        public const string D_hStatus = "";
        public const string D_hStatusMessage = "";

        // --

        public static class FTable
        {
            public const string E_Table = "Table";

            // --

            public const string A_Columns = "Columns";
            public const string A_Rows = "Rows";

            // --

            public const string D_Columns = "";
            public const string D_Rows = "";
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
