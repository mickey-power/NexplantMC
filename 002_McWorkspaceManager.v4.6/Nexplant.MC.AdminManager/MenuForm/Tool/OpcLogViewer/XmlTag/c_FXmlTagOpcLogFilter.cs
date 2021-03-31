/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlTagOpcLogFilter.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2015.11.04
--  Description     : FAMate Admin Manager Opc Log Viewer Log Filter XML Tag Definition Class 
--  History         : Created by Jeff.kim at 2015.11.04
----------------------------------------------------------------------------------------------------------*/

namespace Nexplant.MC.AdminManager
{
    public static class FXmlTagOpcLogFilter
    {

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // FAMate Admin Manager Opc Log Filter Element and Attribute
        // ***
        public const string E_OpcLogFilter = "OLF";

        // --
        // ***
        // Opc Device
        // ***
        public const string A_OpcDeviceState = "ODS";
        public const string A_OpcDeviceError = "ODE";
        public const string A_OpcDeviceTimeOut = "ODT";
        public const string A_OpcDeviceDataMessage = "ODD";
        // --
        // ***
        // Host Device
        // ***
        public const string A_HostDeviceState = "HDS";
        public const string A_HostDeviceError = "HDE";
        public const string A_HostDeviceVfei = "HDV";
        public const string A_HostDeviceDataMessage = "HDD";
        // --
        // ***
        // Scenario
        // ***
        public const string A_Scenario = "SCN";
        // --
        // ***
        // Application
        // ***
        public const string A_Application = "APP";

        // --

        // --
        // ***
        // Opc Device
        // ***
        public const string D_OpcDeviceState = "True";
        public const string D_OpcDeviceError = "True";
        public const string D_OpcDeviceTimeOut = "True";
        public const string D_OpcDeviceDataMessage = "True";
        // --
        // ***
        // Host Device
        // ***
        public const string D_HostDeviceState = "True";
        public const string D_HostDeviceError = "True";
        public const string D_HostDeviceVfei = "True";
        public const string D_HostDeviceDataMessage = "True";
        // --
        // ***
        // Scenario
        // ***
        public const string D_Scenario = "True";
        // --
        // ***
        // Application
        // ***
        public const string D_Application = "True";

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
