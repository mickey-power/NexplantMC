/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2014 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FADMADS_TolAdminAgentOptionUpdate_In.cs
--  Creator         : <Generated Class File Creator>
--  Create Date     : 2015.08.04
--  Description     : <Generated Class File Description>
--  History         : Created by <Generated Class File Creator> at 2015.08.04
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.H101Interface
{
    internal static class FADMADS_TolAdminAgentOptionUpdate_In
    {

        //------------------------------------------------------------------------------------------------------------------------

        public const string E_ADMADS_TolAdminAgentOptionUpdate_In = "ADMADS_TolAdminAgentOptionUpdate_In";

        // --

        public const string A_hLanguage = "hLanguage";
        public const string A_hFactory = "hFactory";
        public const string A_hUserId = "hUserId";
        public const string A_hHostIp = "hHostIp";
        public const string A_hHostName = "hHostName";
        public const string A_hStep = "hStep";

        // --

        public const string D_hLanguage = "";
        public const string D_hFactory = "";
        public const string D_hUserId = "";
        public const string D_hHostIp = "";
        public const string D_hHostName = "";
        public const string D_hStep = "";

        // --

        public static class FOption
        {
            public const string E_Option = "Option";

            // --

            public const string A_Server = "Server";

            // --

            public const string D_Server = "";

            // --

            public static class FGeneral
            {
                public const string E_General = "General";

                // --

                public const string A_Factory = "Factory";
                public const string A_Server = "Server";
                public const string A_User = "User";
                public const string A_ServerThreadingCount = "ServerThreadingCount";
                public const string A_DataFolder = "DataFolder";
                public const string A_LogFolder = "LogFolder";
                public const string A_FtpIp = "FtpIp";
                public const string A_FtpUsedAnonymous = "FtpUsedAnonymous";
                public const string A_FtpUser = "FtpUser";
                public const string A_FtpPassword = "FtpPassword";

                // --

                public const string D_Factory = "";
                public const string D_Server = "";
                public const string D_User = "";
                public const string D_ServerThreadingCount = "";
                public const string D_DataFolder = "";
                public const string D_LogFolder = "";
                public const string D_FtpIp = "";
                public const string D_FtpUsedAnonymous = "";
                public const string D_FtpUser = "";
                public const string D_FtpPassword = "";
            }

            // --

            public static class FHighway101
            {
                public const string E_Highway101 = "Highway101";

                // --

                public const string A_StationConnectString = "StationConnectString";
                public const string A_StationTimeout = "StationTimeout";
                public const string A_AdsTuneChannel = "AdsTuneChannel";
                public const string A_AdsCastChannel = "AdsCastChannel";

                // --

                public const string D_StationConnectString = "";
                public const string D_StationTimeout = "";
                public const string D_AdsTuneChannel = "";
                public const string D_AdsCastChannel = "";
            }

            // --

            public static class FDetectionPolicy
            {
                public const string E_DetectionPolicy = "DetectionPolicy";

                // --

                public const string A_EapWatchEnabled = "EapWatchEnabled";
                public const string A_EapWatchCycleTime = "EapWatchCycleTime";
                public const string A_OpcServerWatchEnabled = "OpcServerWatchEnabled";
                public const string A_OpcServerWatchCycleTime = "OpcServerWatchCycleTime";
                public const string A_OpcServerProcessName = "OpcServerProcessName";

                // --

                public const string D_EapWatchEnabled = "";
                public const string D_EapWatchCycleTime = "";
                public const string D_OpcServerWatchEnabled = "";
                public const string D_OpcServerWatchCycleTime = "";
                public const string D_OpcServerProcessName = "";
            }

            // --

            public static class FResourceCollectionPolicy
            {
                public const string E_ResourceCollectionPolicy = "ResourceCollectionPolicy";

                // --

                public const string A_ResourceCollectionEnabled = "ResourceCollectionEnabled";
                public const string A_ResourceCollectionCycleTime = "ResourceCollectionCycleTime";

                // --

                public const string D_ResourceCollectionEnabled = "";
                public const string D_ResourceCollectionCycleTime = "";
            }

            // --

            public static class FLogPolicy
            {
                public const string E_LogPolicy = "LogPolicy";

                // --

                public const string A_AdaLogFileSize = "AdaLogFileSize";
                public const string A_AdaLogFileBackupCycleTime = "AdaLogFileBackupCycleTime";
                public const string A_AdaLogFileCompressCount = "AdaLogFileCompressCount";
                public const string A_AdaLogFileKeepingPeriod = "AdaLogFileKeepingPeriod";
                public const string A_EapLogFileBackupCycleTime = "EapLogFileBackupCycleTime";
                public const string A_EapLogFileCompressCount = "EapLogFileCompressCount";
                public const string A_EapLogFileKeepingPeriod = "EapLogFileKeepingPeriod";

                // --

                public const string D_AdaLogFileSize = "";
                public const string D_AdaLogFileBackupCycleTime = "";
                public const string D_AdaLogFileCompressCount = "";
                public const string D_AdaLogFileKeepingPeriod = "";
                public const string D_EapLogFileBackupCycleTime = "";
                public const string D_EapLogFileCompressCount = "";
                public const string D_EapLogFileKeepingPeriod = "";
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
