/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlTagPSN.cs
--  Creator         : spike.lee
--  Create Date     : 2013.07.10
--  Description     : FAMate Core FaPlcDriver PLC Session Modeling XML Tag Definition Class 
--  History         : Created by spike.lee at 2013.07.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal static class FXmlTagPSN
    {

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // PLC Session Element and Attribute 
        // ***
        public const string E_PlcSession = "PSN";
        // --
        public const string A_UniqueId = "I";
        public const string A_Locked = "LC";
        public const string A_Name = "N";
        public const string A_Description = "D";        
        public const string A_FontColor = "FC";
        public const string A_FontBold = "FB";
        public const string A_SessionId = "EI";
        public const string A_PlcLibraryId = "LI";
        public const string A_ScanEnabled = "SE";
        public const string A_ScanTime = "ST";
        public const string A_AutoClear = "AC";
        public const string A_LinkMapExpression = "E";
        public const string A_ReadBitDeviceCode = "RBD";
        public const string A_ReadBitStartAddress = "RBS";
        public const string A_ReadBitLength = "RBL";
        public const string A_ReadWordDeviceCode = "RWD";
        public const string A_ReadWordStartAddress = "RWS";
        public const string A_ReadWordLength = "RWL";
        public const string A_WriteBitDeviceCode = "WBD";
        public const string A_WriteBitStartAddress = "WBS";
        public const string A_WriteBitLength = "WBL";
        public const string A_WriteWordDeviceCode = "WWD";
        public const string A_WriteWordStartAddress = "WWS";
        public const string A_WriteWordLength = "WWL";        
        public const string A_UserTag1 = "TG1";
        public const string A_UserTag2 = "TG2";
        public const string A_UserTag3 = "TG3";
        public const string A_UserTag4 = "TG4";
        public const string A_UserTag5 = "TG5";
        // --
        public const string D_UniqueId = "";
        public const string D_Locked = "F";
        public const string D_Name = "";
        public const string D_Description = "";
        public const string D_FontColor = "Black";
        public const string D_FontBold = "F";
        public const string D_SessionId = "";
        public const string D_PlcLibraryId = "";
        public const string D_ScanEnabled = "T";
        public const string D_ScanTime = "1000";
        public const string D_AutoClear = "F";
        public const string D_LinkMapExpression = "D";
        public const string D_ReadBitDeviceCode = "L";
        public const string D_ReadBitStartAddress = "0";
        public const string D_ReadBitLength = "960";
        public const string D_ReadWordDeviceCode = "R";
        public const string D_ReadWordStartAddress = "0";
        public const string D_ReadWordLength = "960";
        public const string D_WriteBitDeviceCode = "L";
        public const string D_WriteBitStartAddress = "960";
        public const string D_WriteBitLength = "960";
        public const string D_WriteWordDeviceCode = "D";
        public const string D_WriteWordStartAddress = "960";
        public const string D_WriteWordLength = "960";        
        public const string D_UserTag1 = "";
        public const string D_UserTag2 = "";
        public const string D_UserTag3 = "";
        public const string D_UserTag4 = "";
        public const string D_UserTag5 = "";

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
