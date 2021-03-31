/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlTagPMGL.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2013.10.30
--  Description     : FAMate Core FaPlcDriver PLC Message Log XML Tag Definition Class 
--  History         : Created by jungyoul.moon at 2013.10.30
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal static class FXmlTagPMGL
    {

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Data Message Log Type
        // ***
        public const string L_Read = "R";
        public const string L_Written = "W";

        // --

        // ***
        // PLC Message Type
        // ***
        public const string M_Message = "M";
        public const string M_MessageTransfer = "T";

        // --

        // ***
        // PLC Message Log Element and Attribute 
        // ***
        public const string E_PlcMessage = "PMG";
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
        public const string A_PlcDeviceId = "DI";
        public const string A_PlcDeviceName = "DN";
        public const string A_PlcSessionId = "SI";
        public const string A_PlcSessionName = "SN";
        public const string A_SessionId = "EI";
        public const string A_LinkMapExpression = "E";
        public const string A_BitDeviceCode = "BC";
        public const string A_BitStartAddress = "BS";
        public const string A_WordDeviceCode = "WC";
        public const string A_WordStartAddress = "WS";
        public const string A_AutoReply = "A";
        public const string A_AutoReset = "R";
        public const string A_UsedAutoTrace = "TU";
        public const string A_AutoTracePeriod = "TP";
        public const string A_LogEnabled = "LE";
        public const string A_LogLevel = "LV";      // 2017.07.04 by spike.lee Log Level Add
        public const string A_IsPrimary = "P";
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
        public const string D_Locked = "F";
        public const string D_Name = "";
        public const string D_Description = "";
        public const string D_FontColor = "Black";
        public const string D_FontBold = "F";
        public const string D_PlcDeviceId = "0";
        public const string D_PlcDeviceName = "";
        public const string D_PlcSessionId = "0";
        public const string D_PlcSessionName = "";
        public const string D_SessionId = "0";
        public const string D_LinkMapExpression = "D";
        public const string D_BitDeviceCode = "L";
        public const string D_BitStartAddress = "0";
        public const string D_WordDeviceCode = "R";
        public const string D_WordStartAddress = "0";
        public const string D_AutoReply = "T";
        public const string D_AutoReset = "F";
        public const string D_UsedAutoTrace = "F";
        public const string D_AutoTracePeriod = "0";
        public const string D_LogEnabled = "T";
        public const string D_LogLevel = "1";       // 2017.07.04 by spike.lee Log Level Add
        public const string D_IsPrimary = "T";
        public const string D_UserTag1 = "";
        public const string D_UserTag2 = "";
        public const string D_UserTag3 = "";
        public const string D_UserTag4 = "";
        public const string D_UserTag5 = "";

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
