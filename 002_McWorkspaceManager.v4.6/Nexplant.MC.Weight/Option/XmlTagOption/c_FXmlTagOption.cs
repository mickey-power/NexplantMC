/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlTagOption.cs
--  Creator         : mjkim
--  Create Date     : 2019.09.10
--  Description     : Nexplant MC Counter Option Xml Tag Class
--  History         : Created by mjkim at 2019.09.10
----------------------------------------------------------------------------------------------------------*/

namespace Nexplant.MC.Counter
{
    public static class FXmlTagOption
    {

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // FAmate Element & Attribute
        // *** 
        public const string E_FAmate = "FAM";
        // --
        public const string A_FileCreationTime = "FCT";
        public const string A_FileDescription = "FDE";
        public const string A_FileFormat = "FFT";
        public const string A_FileUpdateTime = "FUT";
        public const string A_FileVersion = "FVR";
        public const string A_UniqueIdPointer = "UIP";
        // --
        public const string D_FileCreationTime = "";
        public const string D_FileDescription = "";
        public const string D_FileFormat = "";
        public const string D_FileUpdateTime = "";
        public const string D_FileVersion = "";
        public const string D_UniqueIdPointer = "0";

        // --

        // ***
        // FAmate BCR Option Element
        // ***
        public const string E_BcrOption = "BRO";

        // --

        // ***
        // FAmate Admin Service I/F Option Elelment & Attribute
        // ***
        public const string E_AdsOption = "ADO";
        // --
        public const string A_AdsBcrName = "ABN";
        public const string A_AdsFtpIp = "AFI";
        public const string A_AdsFtpUsedAnonymous = "AFA";
        public const string A_AdsFtpUser = "AFU";
        public const string A_AdsFtpPassword = "AFP";
        public const string A_AdsLogSize = "ALS";
        public const string A_AdsLogBackupTime = "ALB";
        public const string A_AdsLogCompressCount = "ALC";
        public const string A_AdsLogKeepingPeriod = "ALK";
        // --
        public const string D_AdsBcrName = "Counter";
        public const string D_AdsFtpIp = "10.20.10.216/FAmateFtp/ads_ftp";
        public const string D_AdsFtpUsedAnonymous = "True";
        public const string D_AdsFtpUser = "";
        public const string D_AdsFtpPassword = "";
        public const string D_AdsLogSize = "5";                 // 5 MB
        public const string D_AdsLogBackupTime = "60";          // 60 min
        public const string D_AdsLogCompressCount = "10";
        public const string D_AdsLogKeepingPeriod = "7";        // 7 Day

        // --

        public const string E_Secs1Option = "S1O";
        // --
        public const string A_Secs1SessionId = "SSI";
        public const string A_Secs1SerialPort = "SSP";
        public const string A_Secs1Baud = "SBU";
        public const string A_Secs1Rbit = "SRB";
        public const string A_Secs1Interleave = "SIL";
        public const string A_Secs1DuplidateError = "SDE";
        public const string A_Secs1IgnoreSystemBytes = "SIS";
        public const string A_Secs1RetryLimit = "SRL";
        public const string A_Secs1T1Timeout = "ST1";
        public const string A_Secs1T2Timeout = "ST2";
        public const string A_Secs1T3Timeout = "ST3";
        public const string A_Secs1T4Timeout = "ST4";
        // --
        public const string D_Secs1SessionId = "0";
        public const string D_Secs1SerialPort = "COM1";
        public const string D_Secs1Baud = "9600";
        public const string D_Secs1Rbit = "False";
        public const string D_Secs1Interleave = "True";
        public const string D_Secs1DuplidateError = "True";
        public const string D_Secs1IgnoreSystemBytes = "False";
        public const string D_Secs1RetryLimit = "3";
        public const string D_Secs1T1Timeout = "0.5";
        public const string D_Secs1T2Timeout = "10";
        public const string D_Secs1T3Timeout = "45";
        public const string D_Secs1T4Timeout = "45";

        // --

        public const string E_HsmsOption = "HMO";
        // --
        public const string A_HsmsSessionId = "HSI";
        public const string A_HsmsConnectMode = "HCM";
        public const string A_HsmsLocalIp = "HLI";
        public const string A_HsmsLocalPort = "HLP";
        public const string A_HsmsRemoteIp = "HRI";
        public const string A_HsmsRemotePort = "HRP";
        public const string A_HsmsLinkTestPeriod = "HLT";
        public const string A_HsmsT3Timeout = "HT3";
        public const string A_HsmsT5Timeout = "HT5";
        public const string A_HsmsT6Timeout = "HT6";
        public const string A_HsmsT7Timeout = "HT7";
        public const string A_HsmsT8Timeout = "HT8";
        // --
        public const string D_HsmsSessionId = "0";
        public const string D_HsmsConnectMode = "Passive";
        public const string D_HsmsLocalIp = "127.0.0.1";
        public const string D_HsmsLocalPort = "5000";
        public const string D_HsmsRemoteIp = "127.0.0.1";
        public const string D_HsmsRemotePort = "5000";
        public const string D_HsmsLinkTestPeriod = "10";
        public const string D_HsmsT3Timeout = "45";
        public const string D_HsmsT5Timeout = "10";
        public const string D_HsmsT6Timeout = "5";
        public const string D_HsmsT7Timeout = "10";
        public const string D_HsmsT8Timeout = "5";

        //------------------------------------------------------------------------------------------------------------------------

    }   // class end
}   // namespace end
