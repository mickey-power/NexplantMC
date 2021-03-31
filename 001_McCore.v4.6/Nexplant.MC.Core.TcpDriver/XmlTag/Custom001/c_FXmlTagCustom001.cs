/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlTagCustom001.cs
--  Creator         : spike.lee
--  Create Date     : 2013.07.09
--  Description     : FAMate Core FaTcpDriver FAMate XML Tag Definition Class 
--  History         : Created by spike.lee at 2013.07.09
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    internal static class FXmlTagCustom001
    {
        
        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Custom001 Message Format
        // <MESSAGE>
        //  <HEADER>
        //   <MSG_ID></MSG_ID> 
        //   <EQUIP_ID></EQUIP_ID>
        //   <DATE></DATE>
        //  </HEADER>
        //  <BODY>
        //   ...
        //   ...
        //  </BODY>
        // </MESSAGE>
        // ***

        // --

        // ***
        // Custom001 Element
        // ***
        public const string E_MESSAGE = "MESSAGE";
        public const string E_HEADER = "HEADER";
        public const string E_MSG_ID = "MSG_ID";
        public const string E_EQUIP_ID = "EQUIP_ID";
        public const string E_DATE = "DATE";
        public const string E_BODY = "BODY";

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
