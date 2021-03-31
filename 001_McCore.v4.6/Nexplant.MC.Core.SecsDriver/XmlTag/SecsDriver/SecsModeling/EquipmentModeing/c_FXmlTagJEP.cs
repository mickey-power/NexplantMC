/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlTagJEP.cs
--  Creator         : spike.lee
--  Create Date     : 2012.01.19
--  Description     : FAMate Core FaSecsDriver Judgement Expression XML Tag Definition Class 
--  History         : Created by spike.lee at 2012.01.19
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal static class FXmlTagJEP
    {

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Judgement Expression Element and Attribute 
        // ***
        public const string E_JudgementExpression = "JEP";
        // --
        public const string A_UniqueId = "I";
        public const string A_Name = "N";
        public const string A_Description = "D";
        public const string A_FontColor = "FC";
        public const string A_FontBold = "FB";
        public const string A_Logical = "LG";
        public const string A_ExpressionType = "TY";
        public const string A_ComparisonMode = "CM";        
        public const string A_OperandId = "OI";
        public const string A_OperandFormat = "OF";
        public const string A_OperandIndexType = "OT";
        public const string A_OperandIndexOption = "OO";
        public const string A_OperandIndex = "OX";
        public const string A_Operation = "OP";
        public const string A_OperandValueType = "VT";
        public const string A_OperandValueIndexType = "VY";
        public const string A_OperandValueIndexOption = "VO";
        public const string A_OperandValueIndex = "VX";
        public const string A_Value = "V";
        public const string A_ValueId = "VI";        
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
        public const string D_UniqueId = "";
        public const string D_Name = "";
        public const string D_Description = "";
        public const string D_FontColor = "Black";
        public const string D_FontBold = "F";
        public const string D_Logical = "A";
        public const string D_ExpressionType = "C";
        public const string D_ComparisonMode = "V";                
        public const string D_OperandId = "";
        public const string D_OperandFormat = "A";
        public const string D_OperandIndexType = "A";
        public const string D_OperandIndexOption = "O";
        public const string D_OperandIndex = "0";
        public const string D_Operation = "E";
        public const string D_OperandValueType = "V";
        public const string D_OperandValueIndexType = "A";
        public const string D_OperandValueIndexOption = "O";
        public const string D_OperandValueIndex = "0";
        public const string D_Value = "";
        public const string D_ValueId = "";        
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
