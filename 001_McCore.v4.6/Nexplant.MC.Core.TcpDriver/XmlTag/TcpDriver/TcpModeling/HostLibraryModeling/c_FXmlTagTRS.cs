/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlTagHMT.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.12
--  Description     : FAMate Core FaTcpDriver Host Message Transfer XML Tag Definition Class 
--  History         : Created by Jeff.Kim at 2013.07.12
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    internal static class FXmlTagTRS
    {

        //------------------------------------------------------------------------------------------------------------------------
        
        // ***
        // Trs Element and Attribute 
        // ***
        public const string E_Body = "B";
        public const string E_Data = "D";
        public const string E_List = "L";
        // --
        public const string A_Version = "Version";
        public const string A_FunctionName = "Name";
        public const string A_Name = "N";
        public const string A_Type = "T";
        public const string A_Encription = "E";
        // --
        public const string D_SERVICE_NAME = "_SERVICE_NAME";
        public const string D_MODULE_NAME = "_MODULE_NAME";
        public const string D_Version = "";
        public const string D_FunctionName = "";
        public const string D_Name = "";
        public const string D_Type = "";
        public const string D_Encription = "";

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
