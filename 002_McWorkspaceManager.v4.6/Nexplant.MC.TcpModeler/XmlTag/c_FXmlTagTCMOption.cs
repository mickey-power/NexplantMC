/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlTagTCMOption.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.10
--  Description     : FAMate TCP Modeler Option XML Tag Definition Class 
--  History         : Created by kitae at 2013.07.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nexplant.MC.TcpModeler
{
    public static class FXmlTagTCMOption
    {

        //------------------------------------------------------------------------------------------------------------------------

        public const string E_TCMOption = "TCM";
        // --
        public const string A_EnabledEventsOfTcpDeviceState = "E01";
        public const string A_EnabledEventsOfTcpDeviceError = "E02";
        public const string A_EnabledEventsOfTcpDeviceTimeout = "E03";
        public const string A_EnabledEventsOfTcpDeviceXlg = "E04";
        public const string A_EnabledEventsOfTcpDeviceDataMessage = "E05";
        public const string A_EnabledEventsOfHostDeviceState = "E06";
        public const string A_EnabledEventsOfHostDeviceError = "E07";
        public const string A_EnabledEventsOfHostDeviceVfei = "E08";
        public const string A_EnabledEventsOfHostDeviceDataMessage = "E09";
        public const string A_EnabledEventsOfScenario = "E10";
        public const string A_EnabledEventsOfApplication = "E11";
        // --
        public const string A_LogDirectory = "LD";
        public const string A_EnabledLogOfBinary = "L1";
        public const string A_EnabledLogOfXlg = "L2";
        public const string A_EnabledLogOfVfei = "L3";
        public const string A_EnabledLogOfTcp = "L4";
        // --
        public const string A_MaxLogFileSizeOfBinary = "S1";
        public const string A_MaxLogFileSizeOfXlg = "S2";
        public const string A_MaxLogFileSizeOfVfei = "S3";
        public const string A_MaxLogFileSizeOfTcp = "S4";
        // --
        public const string A_EnabledFilterOfTcpDeviceState = "F01";
        public const string A_EnabledFilterOfTcpDeviceError = "F02";
        public const string A_EnabledFilterOfTcpDeviceTimeout = "F03";
        public const string A_EnabledFilterOfTcpDeviceDataMessage = "F04";
        public const string A_EnabledFilterOfHostDeviceState = "F05";
        public const string A_EnabledFilterOfHostDeviceError = "F06";
        public const string A_EnabledFilterOfHostDeviceDataMessage = "F07";
        public const string A_EnabledFilterOfScenario = "F08";
        public const string A_EnabledFilterOfApplication = "F09";        
        // --
        public const string A_LibRecentOpenPath = "ROP";
        public const string A_LibRecentSavePath = "RSP";
        // --
        public const string A_LogRecentOpenPath = "RLO";
        public const string A_LogRecentSavePath = "RLS";
        // --
        public const string A_LibRecentExportPath = "REP";
        // --
        public const string A_TcpBinaryTracerMaxTraceCount = "BMC";
        // --
        public const string A_VfeiTracerMaxTraceCount = "VMC";
        // --
        public const string A_XlgTracerMaxTraceCount = "XMC";
        // --
        public const string A_VfeiViewerRecentOpenPath = "VVO";
        public const string A_VfeiViewerRecentSavePath = "VVS";
        // --
        public const string A_XlgViewerRecentOpenPath = "XVO";
        public const string A_XlgViewerRecentSavePath = "XVS";
        // --
        public const string A_CommonFontName = "FNA";
        public const string A_CommonFontSize = "FSZ";

        // --

        public const string D_EnabledEventsOfTcpDeviceState = "True";
        public const string D_EnabledEventsOfTcpDeviceError = "True";
        public const string D_EnabledEventsOfTcpDeviceTimeout = "True";
        public const string D_EnabledEventsOfTcpDeviceXlg = "False";
        public const string D_EnabledEventsOfTcpDeviceDataMessage = "True";
        public const string D_EnabledEventsOfHostDeviceState = "True";
        public const string D_EnabledEventsOfHostDeviceError = "True";
        public const string D_EnabledEventsOfHostDeviceVfei = "False";
        public const string D_EnabledEventsOfHostDeviceDataMessage = "True";
        public const string D_EnabledEventsOfScenario = "True";
        public const string D_EnabledEventsOfApplication = "True";
        // --
        public const string D_LogDirectory = "";
        public const string D_EnabledLogOfBinary = "False";
        public const string D_EnabledLogOfXlg = "False";
        public const string D_EnabledLogOfVfei = "False";
        public const string D_EnabledLogOfTcp = "False";
        // --
        public const string D_MaxLogFileSizeOfBinary = "5242880";
        public const string D_MaxLogFileSizeOfXlg = "5242880";
        public const string D_MaxLogFileSizeOfVfei = "5242880";
        public const string D_MaxLogFileSizeOfTcp = "5242880";
        // --
        public const string D_EnabledFilterOfTcpDeviceState = "True";
        public const string D_EnabledFilterOfTcpDeviceError = "True";
        public const string D_EnabledFilterOfTcpDeviceTimeout = "True";
        public const string D_EnabledFilterOfTcpDeviceXlg = "False";
        public const string D_EnabledFilterOfTcpDeviceDataMessage = "True";
        public const string D_EnabledFilterOfHostDeviceState = "True";
        public const string D_EnabledFilterOfHostDeviceError = "True";
        public const string D_EnabledFilterOfHostDeviceDataMessage = "True";
        public const string D_EnabledFilterOfScenario = "True";
        public const string D_EnabledFilterOfApplication = "True";
        // --
        public const string D_LibRecentOpenPath = "";
        public const string D_LibRecentSavePath = "";
        // --
        public const string D_LogRecentOpenPath = "";
        public const string D_LogRecentSavePath = "";
        // --
        public const string D_LibRecentExportPath = "";
        // --
        public const string D_TcpBinaryTracerMaxTraceCount = "500";
        // --
        public const string D_VfeiTracerMaxTraceCount = "500";    
        // --
        public const string D_XlgTracerMaxTraceCount = "500";
        // --
        public const string D_VfeiViewerRecentOpenPath = "";
        public const string D_VfeiViewerRecentSavePath = "";
        // --
        public const string D_XlgViewerRecentOpenPath = "";
        public const string D_XlgViewerRecentSavePath = "";
        // --
        public const string D_CommonFontName = "Verdana";
        public const string D_CommonFontSize = "8";

        // ***
        // Recent File
        // ***
        public const string E_Recent = "RCT";
        // --
        public const string A_File = "FIL";
        // --
        public const string D_File = "";

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
