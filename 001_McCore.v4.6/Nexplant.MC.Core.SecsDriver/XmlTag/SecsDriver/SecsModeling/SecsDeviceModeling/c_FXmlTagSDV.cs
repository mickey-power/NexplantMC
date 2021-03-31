/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlTagSDV.cs
--  Creator         : spike.lee
--  Create Date     : 2011.03.14
--  Description     : FAMate Core FaSecsDriver SECS Device XML Tag Definition Class 
--  History         : Created by spike.lee at 2011.03.14
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal static class FXmlTagSDV
    {

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // SECS Device Element and Attribute 
        // ***
        public const string E_SecsDevice = "SDV";
        // --
        public const string A_UniqueId = "I";
        public const string A_Locked = "LC";
        public const string A_Name = "N";
        public const string A_Description = "D";
        public const string A_FontColor = "FC";
        public const string A_FontBold = "FB";
        public const string A_Mode = "MD";
        public const string A_Protocol = "PT";
        public const string A_ConnectMode = "CM";
        public const string A_LocalIp = "LI";
        public const string A_LocalPort = "LP";
        public const string A_RemoteIp = "RI";
        public const string A_RemotePort = "RP";
        public const string A_SerialPort = "SP";
        public const string A_Baud = "BD";
        public const string A_RBit = "RB";
        public const string A_Interleave = "IT";
        public const string A_DuplicateError = "DE";
        public const string A_IgnoreSytemBytes = "IS";
        public const string A_LinkTestPeriod = "LT";
        public const string A_RetryLimit = "RL";
        // --
        // 2018.12.13 by Jeff.Kim
        // System Byte Max 값 설정가능하도록 수정
        public const string A_MaxSystemBytes = "MS";
        public const string A_T1Timeout = "T1";
        public const string A_T2Timeout = "T2";
        public const string A_T3Timeout = "T3";
        public const string A_T4Timeout = "T4";
        public const string A_T5Timeout = "T5";
        public const string A_T6Timeout = "T6";
        public const string A_T7Timeout = "T7";
        public const string A_T8Timeout = "T8";        
        public const string A_UserTag1 = "TG1";
        public const string A_UserTag2 = "TG2";
        public const string A_UserTag3 = "TG3";
        public const string A_UserTag4 = "TG4";
        public const string A_UserTag5 = "TG5";
        public const string A_State = "ST";
        // --
        public const string D_UniqueId = "";
        public const string D_Locked = "F";
        public const string D_Name = "";
        public const string D_Description = "";
        public const string D_FontColor = "Black";
        public const string D_FontBold = "F";
        public const string D_Mode = "Both";
        public const string D_Protocol = "HSMS";
        public const string D_ConnectMode = "Active";
        public const string D_LocalIp = "localhost";
        public const string D_LocalPort = "5000";
        public const string D_RemoteIp = "localhost";
        public const string D_RemotePort = "5000";
        public const string D_SerialPort = "COM1";
        public const string D_Baud = "9600";
        public const string D_RBit = "T";
        public const string D_Interleave = "T";
        public const string D_DuplicateError = "T";
        public const string D_IgnoreSytemBytes = "F";
        public const string D_LinkTestPeriod = "10";
        public const string D_RetryLimit = "3";
        // --
        // 2018.12.13 by Jeff.Kim
        // System Byte Max 값 설정가능하도록 수정
        public const string D_MaxSystemBytes = "0";
        public const string D_T1Timeout = "0.5";
        public const string D_T2Timeout = "10";
        public const string D_T3Timeout = "45";
        public const string D_T4Timeout = "45";
        public const string D_T5Timeout = "10";
        public const string D_T6Timeout = "5";
        public const string D_T7Timeout = "10";
        public const string D_T8Timeout = "5";
        public const string D_UserTag1 = "";
        public const string D_UserTag2 = "";
        public const string D_UserTag3 = "";
        public const string D_UserTag4 = "";
        public const string D_UserTag5 = "";
        public const string D_State = "C";

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
