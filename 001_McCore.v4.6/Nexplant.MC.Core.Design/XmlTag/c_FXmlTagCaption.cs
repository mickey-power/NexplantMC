/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlTagCaption.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.04
--  Description     : FAMate Core FaUIs Caption XML Tag Definition Class 
--  History         : Created by spike.lee at 2011.01.04
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaUIs
{
    public static class FXmlTagCaption
    {

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Caption Element and Attribute 
        // ***
        public const string E_Caption = "CAP";        
        // --
        // ***
        // Language Attribute는 FLanguage Enum 값을 사용한다.
        // ***
        public const string A_Description = "DEC";
        // --
        public const string D_Language = "";    // 모든 Language Caption의 Default 값
        public const string D_Description = "";

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
