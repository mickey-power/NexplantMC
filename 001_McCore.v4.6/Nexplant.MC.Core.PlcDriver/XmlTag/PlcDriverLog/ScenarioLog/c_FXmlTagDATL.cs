/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlTagDATL.cs
--  Creator         : spike.lee
--  Create Date     : 2011.12.07
--  Description     : FAMate Core FaPlcDriver Data Log XML Tag Definition Class 
--  History         : Created by spike.lee at 2011.12.07
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal static class FXmlTagDATL
    {

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Data Log Element and Attribute 
        // ***
        public const string E_Data = "DAT";
        // --
        public const string A_LogUniqueId = "Q";
        public const string A_UniqueId = "I";
        public const string A_Name = "N";
        public const string A_Description = "D";
        public const string A_FontColor = "FC";
        public const string A_FontBold = "FB";
        public const string A_SourceType = "ST";
        public const string A_SourceConstant = "SC";
        public const string A_SourceResource = "SR";
        public const string A_SourceEquipmentState = "SS";
        public const string A_SourceEnvironment = "SE";
        public const string A_SourceColumn = "SO";
        public const string A_SourceItem = "SI";        
        public const string A_TargetType = "TT";
        public const string A_TargetConstant = "TC";
        public const string A_TargetColumn = "TO";
        public const string A_TargetItem = "TI";
        public const string A_Pattern = "P";
        public const string A_FixedLength = "FL";        
        public const string A_Format = "F";
        public const string A_ScanMode = "SM";
        public const string A_Value = "V";
        public const string A_Length = "L";
        public const string A_Transformer = "TF";
        public const string A_DataConversionSetID = "DS";
        public const string A_DataConversionSetName = "DA";
        public const string A_DataConversionSetExpression = "DX";
        public const string A_UserTag1 = "TG1";
        public const string A_UserTag2 = "TG2";
        public const string A_UserTag3 = "TG3";
        public const string A_UserTag4 = "TG4";
        public const string A_UserTag5 = "TG5";
        // --
        public const string D_LogUniqueId = "0";
        public const string D_UniqueId = "";
        public const string D_Name = "";
        public const string D_Description = "";
        public const string D_FontColor = "Black";
        public const string D_FontBold = "F";
        public const string D_SourceType = "";
        public const string D_SourceConstant = "";
        public const string D_SourceResource = "";
        public const string D_SourceEquipmentState = "";
        public const string D_SourceEnvironment = "";
        public const string D_SourceColumn = "";
        public const string D_SourceItem = "";        
        public const string D_TargetType = "";
        public const string D_TargetConstant = "";
        public const string D_TargetColumn = "";
        public const string D_TargetItem = "";
        public const string D_Pattern = "";
        public const string D_FixedLength = "1";
        public const string D_Format = "";
        public const string D_ScanMode = "L";
        public const string D_Value = "";
        public const string D_Length = "0";
        public const string D_Transformer = "";
        public const string D_DataConversionSetID = "";
        public const string D_DataConversionSetName = "";
        public const string D_DataConversionSetExpression = "";
        public const string D_UserTag1 = "";
        public const string D_UserTag2 = "";
        public const string D_UserTag3 = "";
        public const string D_UserTag4 = "";
        public const string D_UserTag5 = "";

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
