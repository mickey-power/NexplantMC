/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FConstants.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.06
--  Description     : FAmate Converter FaSecs1ToHsms Constants Class
--  History         : Created by spike.lee at 2017.04.06
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecs1ToHsms
{
    public static class FSecsTag
    {

        //------------------------------------------------------------------------------------------------------------------------

        public const string E_SecsMessage = "SMG";
        public const string A_SessionId = "I";
        public const string A_Stream = "S";
        public const string A_Function = "F";
        public const string A_WBit = "W";
        public const string A_SystemBytes = "SB";

        // --

        public const string E_SecsItem = "SIT";
        public const string A_Format = "F";
        public const string A_Length = "L";
        public const string A_Value = "V";        

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
