/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2014 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FADMADS_DlgEapWizardEapSchemaSearch_Out.cs
--  Creator         : <Generated Class File Creator>
--  Create Date     : 2015.07.24
--  Description     : <Generated Class File Description>
--  History         : Created by <Generated Class File Creator> at 2015.07.24
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Adminmanager
{
    internal static class FFileDriver
    {

        //------------------------------------------------------------------------------------------------------------------------

        public const string E_FileDriver = "FileDriver";

        // --

        public const string A_Name = "Name";
        public const string A_Description = "Description";

        // --

        public const string D_Name = "";
        public const string D_Description = "";

        // --

        public static class FHostDevice
        {
            public const string E_HostDevice = "HostDevice";

            // --

            public const string A_Seq = "Seq";
            public const string A_Name = "Name";
            public const string A_Description = "Description";
            public const string A_Mode = "Mode";
            public const string A_Driver = "Driver";
            public const string A_DriverDescription = "DriverDescription";
            public const string A_DriverOption = "DriverOption";
            public const string A_TransactionTimeout = "TransactionTimeout";

            // --

            public const string D_Seq = "";
            public const string D_Name = "";
            public const string D_Description = "";
            public const string D_Mode = "";
            public const string D_Driver = "";
            public const string D_DriverDescription = "";
            public const string D_DriverOption = "";
            public const string D_TransactionTimeout = "45";

            public static class FHostOption
            {
                public static string E_HostOption = "HostDriverOption";

                // --

                public const string A_StationConnectString = "StationConnectString";
                public const string A_StationVersion = "StationVer";
                public const string A_StationTimeOut = "StationTimeOut";
                public const string A_GuaranteedtimeOut = "GuaranteedTimOut";
                public const string A_MaxSpoling = "MaxSpooling";
                public const string A_SessionId = "SessionId";
                public const string A_ModuleName = "ModuleName";
                public const string A_TuneChannel = "TuneChannel";
                public const string A_CastChannel = "CastChannel";
                public const string A_ParsingType = "ParsingType";

                // --

                public const string D_StationConnectString = "localhost:10101";
                public const string D_StationVersion = "4.5";
                public const string D_StationTimeOut = "5000";
                public const string D_GuaranteedtimeOut = "86400000";
                public const string D_MaxSpoling = "50";
                public const string D_SessionId = "0";
                public const string D_ModuleName = "EAPADS";
                public const string D_TuneChannel = "/FMS/ADSEAP";
                public const string D_CastChannel = "/FMS/EAPADS";
                public const string D_ParsingType = "Json";
            }
        }   

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
