/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlTagHMGL.cs
--  Creator         : Kimsh
--  Create Date     : 2011.11.08
--  Description     : FAMate Core FaSecsDriver Host Message Log XML Tag Definition Class 
--  History         : Created by Kimsh at 2011.11.08
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal static class FXmlTagHMGL
    {

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Data Message Log Type
        // ***
        public const string L_Received = "R";
        public const string L_Sent = "S";        

        // --

        // ***
        // Host Message Type
        // ***
        public const string M_Message = "M";
        public const string M_MessageTransfer = "T";
        public const string M_HostDriverDataMessage = "D";

        // --

        // ***
        // Host Message Log Element and Attribute 
        // ***
        public const string E_HostMessage = "HMG";
        // --
        public const string A_LogUniqueId = "Q";
        public const string A_LogType = "L";
        public const string A_Time = "T";
        public const string A_ResultCode = "RC";
        public const string A_ResultMessage = "RM";
        public const string A_MessageType = "M";
        public const string A_UniqueId = "I";
        public const string A_Name = "N";
        public const string A_Description = "D";
        public const string A_FontColor = "FC";
        public const string A_FontBold = "FB";
        public const string A_HostDeviceId = "DI";
        public const string A_HostDeviceName = "DN";
        public const string A_HostSessionId = "SI";
        public const string A_HostSessionName = "SN";
        public const string A_MachineId = "E";
        public const string A_SessionId = "EI";
        public const string A_Command = "C";        
        public const string A_Version = "V";        
        public const string A_HostMessageType = "MT";        
        public const string A_TID = "B";
        public const string A_MultiCastMessage = "MC";
        public const string A_GuaranteedMessage = "GT";
        public const string A_AutoReply = "A";
        public const string A_LogEnabled = "LE";
        public const string A_LogLevel = "LV";      // 2017.07.04 by spike.lee Log Level Add
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
        public const string D_MessageType = "M";
        public const string D_UniqueId = "";
        public const string D_Name = "";
        public const string D_Description = "";
        public const string D_FontColor = "Black";
        public const string D_FontBold = "F";
        public const string D_HostDeviceId = "0";
        public const string D_HostDeviceName = "";
        public const string D_HostSessionId = "0";
        public const string D_HostSessionName = "";
        public const string D_MachineId = "";
        public const string D_SessionId = "0";
        public const string D_Command = "";
        public const string D_Version = "";
        public const string D_HostMessageType = "";
        public const string D_TID = "0";
        public const string D_MultiCastMessage = "F";
        public const string D_GuaranteedMessage = "F";
        public const string D_AutoReply = "T";
        public const string D_LogEnabled = "T";
        public const string D_LogLevel = "1";       // 2017.07.04 by spike.lee Log Level Add
        public const string D_UserTag1 = "";
        public const string D_UserTag2 = "";
        public const string D_UserTag3 = "";
        public const string D_UserTag4 = "";
        public const string D_UserTag5 = "";

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
