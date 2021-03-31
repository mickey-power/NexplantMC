/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlTagLvwOption.cs
--  Creator         : mjkim
--  Create Date     : 2012.08.13
--  Description     : FAmate Log Viewer Option XML Tag Definition Class 
--  History         : Created by mjkim at 2012.08.13                   
----------------------------------------------------------------------------------------------------------*/
using System;

namespace Nexplant.MC.LogViewer
{
    public static class FXmlTagLvwOption
    {
        
        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // FAmate Log Viewer Option Element and Attribute
        // ***
        public const string E_LVWOption = "LVO";
        // --
        public const string A_FontName = "FNA";
        public const string A_FontSize = "FSZ";
        // --
        public const string D_FontName = "Verdana";
        public const string D_FontSize = "8";
        // --
        public const string A_BngViewerRecentOpenPath = "BVO";
        public const string D_BngViewerRecentOpenPath = "";

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end