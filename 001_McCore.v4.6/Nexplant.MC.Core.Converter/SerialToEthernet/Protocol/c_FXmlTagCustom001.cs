/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlSocketTag.cs
--  Creator         : mjkim
--  Create Date     : 2019.09.23
--  Description     : FAMate Core FaSerialToEthernet TCP XML Tag Definition Class 
--  History         : Created by mjkim at 2019.09.23
----------------------------------------------------------------------------------------------------------*/

namespace Nexplant.MC.Core.FaSerialToEthernet
{
    public static class FXmlSocketTag
    {
        
        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // TCP Message Format
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
        // TCP Element
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
