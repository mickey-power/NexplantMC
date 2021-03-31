/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlTagFUNL.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.16
--  Description     : FAMate Core FaTcpDriver Function Called Log XML Tag Definition Class 
--  History         : Created by Jeff.Kim at 2013.07.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    internal static class FXmlTagFUNL
    {

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Function Element and Attribute 
        // ***
        public const string E_Function = "FUN";
        // --
        public const string A_LogUniqueId = "Q";
        public const string A_Time = "T";
        public const string A_ResultCode = "RC";
        public const string A_ResultMessage = "RM";
        public const string A_UniqueId = "I";
        public const string A_Name = "N";
        public const string A_Description = "D";
        public const string A_FontColor = "FC";
        public const string A_FontBold = "FB";
        public const string A_EquipmentId = "EI";
        public const string A_EquipmentName = "EN";
        public const string A_ScenarioId = "SI";
        public const string A_ScenarioName = "SN";
        public const string A_FunctionName = "FN";
        public const string A_Parameter1 = "P1";
        public const string A_Parameter2 = "P2";
        public const string A_Parameter3 = "P3";
        public const string A_Parameter4 = "P4";
        public const string A_Parameter5 = "P5";
        public const string A_ErrorAction = "EA";
        public const string A_UserTag1 = "TG1";
        public const string A_UserTag2 = "TG2";
        public const string A_UserTag3 = "TG3";
        public const string A_UserTag4 = "TG4";
        public const string A_UserTag5 = "TG5";
        // --
        public const string D_LogUniqueId = "0";        
        public const string D_Time = "";
        public const string D_ResultCode = "S";
        public const string D_ResultMessage = "";
        public const string D_UniqueId = "";
        public const string D_Locked = "F";
        public const string D_Name = "";
        public const string D_Description = "";
        public const string D_FontColor = "Black";
        public const string D_FontBold = "F";
        public const string D_EquipmentId = "0";
        public const string D_EquipmentName = "";
        public const string D_ScenarioId = "0";
        public const string D_ScenarioName = "";
        public const string D_FunctionName = "";
        public const string D_Parameter1 = "";
        public const string D_Parameter2 = "";
        public const string D_Parameter3 = "";
        public const string D_Parameter4 = "";
        public const string D_Parameter5 = "";
        public const string D_ErrorAction = "S";
        public const string D_UserTag1 = "";
        public const string D_UserTag2 = "";
        public const string D_UserTag3 = "";
        public const string D_UserTag4 = "";
        public const string D_UserTag5 = "";

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
