/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSQMSQS_SetModuleUpdate_In.cs
--  Creator         : mj.kim
--  Create Date     : 2011.10.25
--  Description     : FAMate SQL Service Setup Module Insert / Update / Delete In XML Tag Definition Class 
--  History         : Created by mj.kim at 2011.10.25
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.H101Interface
{
    public static class FSQMSQS_SetModuleUpdate_In
    {

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // FAMate SQL Service Setup Module Insert / Update / Delete In Element and Attribute
        // ***
        public const string E_SQMSQS_SetModuleUpdate_In = "SQMSQS_SetModuleUpdate_In";
        // --
        public const string A_hLanguage = "hLanguage";
        public const string A_hStep = "hStep";
        // --
        public const string D_hLanguage = "";
        public const string D_hStep = "";

        // --

        public static class FModule
        {
            public const string E_Module = "Module";
            // --
            public const string A_System = "System";
            public const string A_UniqueId = "UniqueId";
            public const string A_Module = "Module";
            public const string A_Description = "Description";
            // --
            public const string D_System = "";
            public const string D_UniqueId = "";
            public const string D_Module = "";
            public const string D_Description = "";
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
