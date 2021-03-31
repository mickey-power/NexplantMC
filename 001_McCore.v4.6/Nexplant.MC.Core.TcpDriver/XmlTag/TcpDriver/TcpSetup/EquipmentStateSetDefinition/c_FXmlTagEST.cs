/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlTagEST.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2013.08.06
--  Description     : FAMate Core FaTcpDriver Equipment State XML Tag Definition Class 
--  History         : Created by jungyoul.moon at 2013.08.06
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    internal static class FXmlTagEST
    {

        //------------------------------------------------------------------------------------------------------------------------
        
        // ***
        // Equipment State Type
        // ***
        public const string R_EquipmentState = "E";
        public const string R_EquipmentStateMaterial = "M";

        // ***
        // Equipment State Element and Attribute 
        // ***
        public const string E_EquipmentState = "EST";
        // --
        public const string A_EquipmentStateType = "E";
        public const string A_UniqueId = "I";
        public const string A_Locked = "LC";
        public const string A_Name = "N";
        public const string A_Description = "D";
        public const string A_FontColor = "FC";
        public const string A_FontBold = "FB";
        public const string A_DefaultValue = "V";
        public const string A_Queuing = "Q";
        public const string A_Duplication = "DP";
        public const string A_DuplicationIgnoreValue = "DI";
        public const string A_UserTag1 = "TG1";
        public const string A_UserTag2 = "TG2";
        public const string A_UserTag3 = "TG3";
        public const string A_UserTag4 = "TG4";
        public const string A_UserTag5 = "TG5";
        // --
        public const string D_EquipmentStateType = "E";
        public const string D_UniqueId = "";
        public const string D_Locked = "F";
        public const string D_Name = "";
        public const string D_Description = "";
        public const string D_FontColor = "Black";
        public const string D_FontBold = "F";
        public const string D_DefaultValue = "";
        public const string D_Queuing = "F";
        public const string D_Duplication = "T";
        public const string D_DuplicationIgnoreValue = "";
        public const string D_UserTag1 = "";
        public const string D_UserTag2 = "";
        public const string D_UserTag3 = "";
        public const string D_UserTag4 = "";
        public const string D_UserTag5 = "";

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
