/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlTagLFEOption.cs
--  Creator         : kitae
--  Create Date     : 2012.03.28
--  Description     : FAMate Language File Editor Option Class 
--  History         : Created by kitae at 2012.03.28                     
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.LanguageFileEditor
{
    public static class FXmlTagLFEOption
    {
        
        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // FAMate Language File Editor Option Element and Attribute
        // ***
        public const string E_LFEOption = "LFE";        

        // --

        // ***
        // Common Attribute - RecentInfo, Info
        // ***        
        public const string A_RecentLibraryOpenPath = "ROP";
        public const string A_RecentLibrarySavePath = "RSP";
        public const string A_RecentExportPath = "REP";
        public const string A_RecentImportPath = "RIP";                
        // --
        public const string D_RecentLibraryOpenPath = "";
        public const string D_RecentLibrarySavePath = "";
        public const string D_RecentExportPath = "";
        public const string D_RecentImportPath = "";                

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end