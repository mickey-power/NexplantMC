/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FConstants.cs
--  Creator         : mj.kim
--  Create Date     : 2011.09.22
--  Description     : FAMate Admin Manager Constants Definition Class 
--  History         : Created by mj.kim at 2011.09.22
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.AdminManager
{
    public static class FConstants
    {

        //------------------------------------------------------------------------------------------------------------------------

        public const string ApplicationName = "Nexplant MC Admin Manager v4.6";

        // --

        public const string StationSessionID = "ADM";
        public const string StationVersion = "4.6";
        public const int GuaranteedTimeout = 86400000;

        // --

        public const string TempFileFormat = "\\{0}.{1}";       // Manager Temp File Format
        public const string ZipFileExtension = "zip";           // Packing File Extension
        public const string HdrFileFilter = "DLL (*.dll)|*.dll";
        public const string ComFileFilter = "DLL (*.dll)|*.dll";
        public const string SsmFileFilter = "SECS Modeling Files (*.ssm)|*.ssm";
        public const string PsmFileFilter = "PLC Modeling Files (*.psm)|*.psm"; 
        public const string OsmFileFilter = "OPC Modeling Files (*.osm)|*.osm";
        public const string TsmFileFilter = "TCP Modeling Files (*.tsm)|*.tsm";
        public const string AllFileFilter = "All Types (*.*)|*.*";

        // --

        public const int FontMaxSize = 72;
        public const int FontMinSize = 8;

        // --

        public const char KeySeparator = (char)0x1F;

        // --

        public const int HistorySearchPeriod = 6 * 60 * 60 * 1000; // 6 Hours

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
