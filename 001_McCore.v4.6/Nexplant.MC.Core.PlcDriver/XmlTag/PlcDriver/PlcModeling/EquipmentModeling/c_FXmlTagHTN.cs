/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlTagHTN.cs
--  Creator         : spike.lee
--  Create Date     : 2011.05.30
--  Description     : FAMate Core FaPlcDriver Host Transmitter XML Tag Definition Class 
--  History         : Created by spike.lee at 2011.05.30
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal static class FXmlTagHTN
    {

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Host Transmitter Element and Attribute 
        // ***
        public const string E_HostTransmitter = "HTN";
        // --
        public const string A_UniqueId = "I";
        public const string A_Name = "N";
        public const string A_Description = "D";
        public const string A_FontColor = "FC";
        public const string A_FontBold = "FB";
        public const string A_AutoActionFirstSelect = "A1";
        public const string A_AutoActionFirstClose = "A2";
        public const string A_AutoActionAlwaysSelect = "A3";
        public const string A_AutoActionAlwaysClose = "A4";
        public const string A_UsedAutoCycle = "CU";
        public const string A_AutoCyclePeriod = "CP";
        public const string A_AutoCycleAction = "CA";
        public const string A_UserTag1 = "TG1";
        public const string A_UserTag2 = "TG2";
        public const string A_UserTag3 = "TG3";
        public const string A_UserTag4 = "TG4";
        public const string A_UserTag5 = "TG5";
        // --
        public const string D_UniqueId = "";
        public const string D_Name = "";
        public const string D_Description = "";
        public const string D_FontColor = "Black";
        public const string D_FontBold = "F";
        public const string D_AutoActionFirstSelect = "F";
        public const string D_AutoActionFirstClose = "F";
        public const string D_AutoActionAlwaysSelect = "F";
        public const string D_AutoActionAlwaysClose = "F";
        public const string D_UsedAutoCycle = "F";
        public const string D_AutoCyclePeriod = "1000";
        public const string D_AutoCycleAction = "R";
        public const string D_UserTag1 = "";
        public const string D_UserTag2 = "";
        public const string D_UserTag3 = "";
        public const string D_UserTag4 = "";
        public const string D_UserTag5 = "";

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
