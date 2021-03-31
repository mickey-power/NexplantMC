/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlTagFunction.cs
--  Creator         : baehyun seo
--  Create Date     : 2011.10.26
--  Description     : FAMate XML Tag Generator Function XML Tag Definition Class 
--  History         : Created by baehyun seo at 2011.10.26
----------------------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.SourceGenerator
{
    public class FXmlTagFunction
    {
        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Function Element and Attribute 
        // ***
        public const string E_Function = "Function";

        // --

        public const string A_FunctionClass = "Class";
        public const string A_FunctionDeliveryMode = "DeliveryMode";
        public const string A_FunctionName = "Name";
        public const string A_FunctionAsync = "Async";
        public const string A_FunctionGuaranteed = "Guaranteed";

        // --

        public const string D_FunctionClass = "";
        public const string D_FunctionDeliveryMode = "UNICAST";
        public const string D_FunctionName = "";
        public const string D_FunctionAsync = "False";
        public const string D_FunctionGuaranteed = "False";

        //------------------------------------------------------------------------------------------------------------------------
    }
}
