/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlTagTMGL.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2013.10.30
--  Description     : FAMate Core FaTcpDriver TCP Message Log XML Tag Definition Class 
--  History         : Created by jungyoul.moon at 2013.10.30
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    internal static class FXmlTagTMGL
    {

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Data Message Log Type
        // ***
        public const string L_Received = "R";
        public const string L_Sent = "W";

        // --

        // ***
        // TCP Message Type
        // ***
        public const string M_Message = "M";
        public const string M_MessageTransfer = "T";

        // --

        // ***
        // TCP Message Log Element and Attribute 
        // ***
        public const string E_TcpMessage = "TMG";
        // --
        public const string A_LogUniqueId = "Q";
        public const string A_LogType = "L";
        public const string A_Time = "T";
        public const string A_ResultCode = "RC";
        public const string A_ResultMessage = "RM";
        public const string A_MessageType = "M";
        public const string A_UniqueId = "I";
        public const string A_Locked = "LC";
        public const string A_Name = "N";
        public const string A_Description = "D";
        public const string A_FontColor = "FC";
        public const string A_FontBold = "FB";
        public const string A_TcpDeviceId = "DI";
        public const string A_TcpDeviceName = "DN";        
        public const string A_TcpSessionId = "SI";
        public const string A_TcpSessionName = "SN";
        public const string A_SessionId = "EI";
        public const string A_Command = "C";
        public const string A_Version = "V";
        public const string A_TcpMessageType = "MT";
        public const string A_TID = "B";
        public const string A_AutoReply = "A";
        public const string A_LogEnabled = "LE";
        public const string A_LogLevel = "LV";      // 2017.07.04 by spike.lee Log Level Add
        public const string A_UserTag1 = "TG1";
        public const string A_UserTag2 = "TG2";
        public const string A_UserTag3 = "TG3";
        public const string A_UserTag4 = "TG4";
        public const string A_UserTag5 = "TG5";
        public const string A_Length = "LN";
        // --
        public const string D_LogUniqueId = "0";
        public const string D_LogType = "";
        public const string D_Time = "";
        public const string D_ResultCode = "S";
        public const string D_ResultMessage = "";
        public const string D_MessageType = "M";
        public const string D_UniqueId = "";
        public const string D_Locked = "F";
        public const string D_Name = "";
        public const string D_Description = "";
        public const string D_FontColor = "Black";
        public const string D_FontBold = "F";
        public const string D_TcpDeviceId = "0";
        public const string D_TcpDeviceName = "";        
        public const string D_TcpSessionId = "0";
        public const string D_TcpSessionName = "";      
        public const string D_SessionId = "0";
        public const string D_Command = "";
        public const string D_Version = "";
        public const string D_TcpMessageType = "";        
        public const string D_TID = "0";
        public const string D_AutoReply = "T";
        public const string D_LogEnabled = "T";
        public const string D_LogLevel = "1";       // 2017.07.04 by spike.lee Log Level Add
        public const string D_UserTag1 = "";
        public const string D_UserTag2 = "";
        public const string D_UserTag3 = "";
        public const string D_UserTag4 = "";
        public const string D_UserTag5 = "";
        public const string D_Length = "0";

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
