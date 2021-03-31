/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlTagODVL.cs
--  Creator         : spike.lee
--  Create Date     : 2013.07.10
--  Description     : FAMate Core FaOpcDriver OPC Device XML Tag Definition Class 
--  History         : Created by spike.lee at 2013.07.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    internal static class FXmlTagODVL
    {

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Device Log Type
        // ***
        public const string L_StateChanged = "C";
        public const string L_DataReceived = "R";
        public const string L_DataSent = "S";

        // --
        // ***
        // OPC Device Element and Attribute 
        // ***
        public const string E_OpcDevice = "ODV";
        // --
        public const string A_LogUniqueId = "Q";
        public const string A_LogType = "L";
        public const string A_Time = "T";
        public const string A_ResultCode = "RC";
        public const string A_ResultMessage = "RM";
        public const string A_UniqueId = "I";
        public const string A_Index = "IX";
        public const string A_Locked = "LC";
        public const string A_Name = "N";
        public const string A_Description = "D";
        public const string A_FontColor = "FC";
        public const string A_FontBold = "FB";
        public const string A_Protocol = "PT";
        public const string A_Url = "UL";
        public const string A_ProgId = "PI";
        public const string A_ClientHandle = "HI";
        public const string A_LocalId = "LD";
        public const string A_DefaultNamespace = "NS";
        public const string A_KeepAliveTime = "KT";
        public const string A_EventReloadTime = "ET";
        public const string A_T2Timeout = "T2";
        public const string A_T3Timeout = "T3";
        public const string A_T5Timeout = "T5";
        public const string A_State = "ST";
        public const string A_UserTag1 = "TG1";
        public const string A_UserTag2 = "TG2";
        public const string A_UserTag3 = "TG3";
        public const string A_UserTag4 = "TG4";
        public const string A_UserTag5 = "TG5";
        // --
        public const string D_LogUniqueId = "0";
        public const string D_LogType = "";
        public const string D_Time = "";
        public const string D_ResultCode = "S";
        public const string D_ResultMessage = "";
        public const string D_Index = "0";
        public const string D_UniqueId = "";
        public const string D_Locked = "F";
        public const string D_Name = "";
        public const string D_Description = "";
        public const string D_FontColor = "Black";
        public const string D_FontBold = "F";
        public const string D_Protocol = "KEPWARE";
        public const string D_Url = "opc.tcp://127.0.0.1:49320";
        public const string D_ProgId = "ProgID";
        public const string D_ClientHandle = "0";
        public const string D_LocalId = "en";
        public const string D_DefaultNamespace = "2";
        public const string D_KeepAliveTime = "10";
        public const string D_EventReloadTime = "1";
        public const string D_T2Timeout = "3";
        public const string D_T3Timeout = "3";
        public const string D_T5Timeout = "10";
        public const string D_State = "C";
        public const string D_UserTag1 = "";
        public const string D_UserTag2 = "";
        public const string D_UserTag3 = "";
        public const string D_UserTag4 = "";
        public const string D_UserTag5 = "";

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
