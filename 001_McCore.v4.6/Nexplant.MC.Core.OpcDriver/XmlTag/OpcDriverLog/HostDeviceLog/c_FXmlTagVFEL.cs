/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlTagVFEL.cs
--  Creator         : spike.lee
--  Create Date     : 2011.11.11
--  Description     : FAMate Core FaOpcDriver Host Device VFEL Log XML Tag Definition Class 
--  History         : Created by spike.lee at 2011.11.11
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    internal static class FXmlTagVFEL
    {

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // VFEI Log Type
        // ***
        public const string L_Received = "R";
        public const string L_Sent = "S";        

        // --

        // ***
        // VFEI Log Element and Attribute 
        // ***
        public const string E_Vfei = "VFE";        
        // --
        public const string A_LogUniqueId = "Q";
        public const string A_LogType = "L";
        public const string A_Time = "T";
        public const string A_ResultCode = "RC";
        public const string A_ResultMessage = "RM";
        public const string A_UniqueId = "I";
        public const string A_Index = "IX";
        public const string A_Name = "N";
        public const string A_Description = "D";        
        public const string A_FontColor = "FC";
        public const string A_FontBold = "FB";
        public const string A_MachineId = "E";
        public const string A_SessionId = "EI";
        public const string A_Command = "C";        
        public const string A_HostMessageType = "MT";
        public const string A_TID = "B";        
        // --
        public const string D_LogUniqueId = "0";
        public const string D_LogType = "";
        public const string D_Time = "";
        public const string D_ResultCode = "S";
        public const string D_ResultMessage = "";
        public const string D_UniqueId = "";
        public const string D_Index = "0";
        public const string D_Name = "";        
        public const string D_Description = "";
        public const string D_FontColor = "Black";
        public const string D_FontBold = "F";
        public const string D_MachineId = "";
        public const string D_SessionId = "0";
        public const string D_Command = "";
        public const string D_HostMessageType = "";        
        public const string D_TID = "0";        

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
