/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlTagSCGOption.cs
--  Creator         : baehyun.seo
--  Create Date     : 2011.11.14
--  Description     : FAMate SQL Manager Option Class 
--  History         : Created by baehyun seo at 2011.11.14
                    : Modified by kitae at 2012.03.20
                        - Recent Library 
                        - D_SavePath 수정
                        - D_CopyRightContens 수정                        
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.SourceGenerator
{
    // ***
    // 2012.11.16 by spike.lee
    // 이게 뭡니까? 파일 이름은 SCG, Tag 상수는 SGT 통일성이 없잖아요.
    // ***
    public static class FXmlTagSCGOption
    {
        
        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // FAMate Source Generator Option Element and Attribute
        // ***
        public const string E_SCGOption = "SGO";        

        // ***
        // Common Attribute - RecentInfo, Info
        // ***
        public const string A_SavePath = "SVP";
        public const string A_Creator = "CRT";
        public const string A_Description = "DSC";
        public const string A_CopyRightContents = "CRC";
        public const string A_UsingNamespace = "UNS";
        // --
        public const string A_ParamGenerator = "PGT";
        public const string A_FuncGenerator = "FGT";
        public const string A_H101BaseGenerator = "HBG";
        public const string A_InternalClass = "ICS";
        public const string A_OldFilesClear = "OFC";
        // --        
        public const string A_RecentOpenPath = "ROP";
        public const string A_RecentSavePath = "RSP";
        // --
        public const string A_FontName = "FNA";
        public const string A_FontSize = "FSZ";

        // --

        public const string D_SavePath = "";
        public const string D_Creator = "<Generated Class File Creator>";
        public const string D_Description = "<Generated Class File Description>";
        public const string D_CopyRightContens = "";
        public const string D_UsingNamespace = "using Nexplant.MC.Core.FaCommon;";
        // --
        public const string D_ParamGenerator = "F";
        public const string D_FuncGenerator = "F";
        public const string D_H101BaseGenerator = "F";
        public const string D_InternalClass = "F";
        public const string D_OldFilesClear = "F";
        // --
        public const string D_RecentOpenPath = "";
        public const string D_RecentSavePath = "";
        // --
        public const string D_FontName = "Verdana";
        public const string D_FontSize = "8";

        // ***
        // Recent File
        // ***
        public const string E_Recent = "RCT";
        // --
        public const string A_File = "FIL";
        // --
        public const string D_File = "";

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end