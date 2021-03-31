/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlTagOCMOption.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.10
--  Description     : FAMate Opc Modeler Option XML Tag Definition Class 
--  History         : Created by kitae at 2013.07.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nexplant.MC.OpcModeler
{
    public static class FXmlTagOPMOption
    {

        //------------------------------------------------------------------------------------------------------------------------

        public const string E_OPMOption = "OPM";
        // --
        public const string A_EnabledEventsOfOpcDeviceState = "E01";
        public const string A_EnabledEventsOfOpcDeviceError = "E02";
        public const string A_EnabledEventsOfOpcDeviceTimeout = "E03";
        public const string A_EnabledEventsOfOpcDeviceData = "E04";
        public const string A_EnabledEventsOfOpcDeviceTelnet = "E05";
        public const string A_EnabledEventsOfOpcDeviceHandshake = "E06";
        public const string A_EnabledEventsOfOpcDeviceControlMessage = "E07";
        public const string A_EnabledEventsOfOpcDeviceBlock = "E08";
        public const string A_EnabledEventsOfOpcDeviceSml = "E09";
        public const string A_EnabledEventsOfOpcDeviceDataMessage = "E10";
        public const string A_EnabledEventsOfHostDeviceState = "E11";
        public const string A_EnabledEventsOfHostDeviceError = "E12";
        public const string A_EnabledEventsOfHostDeviceVfei = "E13";
        public const string A_EnabledEventsOfHostDeviceDataMessage = "E14";
        public const string A_EnabledEventsOfScenario = "E15";
        public const string A_EnabledEventsOfApplication = "E16";
        // --
        public const string A_LogDirectory = "LD";
        public const string A_EnabledLogOfBinary = "L1";
        public const string A_EnabledLogOfVfei = "L2";
        public const string A_EnabledLogOfOpc = "L3";
        // --
        public const string A_MaxLogFileSizeOfBinary = "S1";
        public const string A_MaxLogFileSizeOfVfei = "S2";
        public const string A_MaxLogFileSizeOfOpc = "S3";
        // --
        public const string A_EnabledFilterOfOpcDeviceState = "F01";
        public const string A_EnabledFilterOfOpcDeviceError = "F02";
        public const string A_EnabledFilterOfOpcDeviceTimeout = "F03";
        public const string A_EnabledFilterOfOpcDeviceData = "F04";
        public const string A_EnabledFilterOfOpcDeviceTelnet = "F05";
        public const string A_EnabledFilterOfOpcDeviceHandshake = "F06";
        public const string A_EnabledFilterOfOpcDeviceControlMessage = "F07";
        public const string A_EnabledFilterOfOpcDeviceBlock = "F08";
        public const string A_EnabledFilterOfOpcDeviceSml = "F09";
        public const string A_EnabledFilterOfOpcDeviceDataMessage = "F10";

        public const string A_EnabledFilterOfHostDeviceState = "F11";
        public const string A_EnabledFilterOfHostDeviceError = "F12";
        public const string A_EnabledFilterOfHostDeviceVfei = "F13";
        public const string A_EnabledFilterOfHostDeviceDataMessage = "F14";
        public const string A_EnabledFilterOfScenario = "F15";
        public const string A_EnabledFilterOfApplication = "F16";        
        // --
        public const string A_LibRecentOpenPath = "ROP";
        public const string A_LibRecentSavePath = "RSP";
        // --
        public const string A_LogRecentOpenPath = "RLO";
        public const string A_LogRecentSavePath = "RLS";
        // --
        public const string A_LibRecentExportPath = "REP";
        // --
        public const string A_OpcBinaryTracerMaxTraceCount = "BMC";
        // --
        public const string A_VfeiTracerMaxTraceCount = "VMC";
        // --
        public const string A_VfeiViewerRecentOpenPath = "VVO";
        public const string A_VfeiViewerRecentSavePath = "VVS";
        // --
        public const string A_CommonFontName = "FNA";
        public const string A_CommonFontSize = "FSZ";
        // --
        public const string D_EnabledEventsOfOpcDeviceState = "True";
        public const string D_EnabledEventsOfOpcDeviceError = "True";
        public const string D_EnabledEventsOfOpcDeviceTimeout = "True";
        public const string D_EnabledEventsOfOpcDeviceData = "False";
        public const string D_EnabledEventsOfOpcDeviceTelnet = "False";
        public const string D_EnabledEventsOfOpcDeviceHandshake = "False";
        public const string D_EnabledEventsOfOpcDeviceControlMessage = "True";
        public const string D_EnabledEventsOfOpcDeviceBlock = "False";
        public const string D_EnabledEventsOfOpcDeviceSml = "False";
        public const string D_EnabledEventsOfOpcDeviceDataMessage = "True";
        public const string D_EnabledEventsOfHostDeviceState = "True";
        public const string D_EnabledEventsOfHostDeviceError = "True";
        public const string D_EnabledEventsOfHostDeviceVfei = "False";
        public const string D_EnabledEventsOfHostDeviceDataMessage = "True";
        public const string D_EnabledEventsOfScenario = "True";
        public const string D_EnabledEventsOfApplication = "True";
        // --
        public const string D_LogDirectory = "";
        public const string D_EnabledLogOfBinary = "False";
        public const string D_EnabledLogOfVfei = "False";
        public const string D_EnabledLogOfOpc = "False";
        // --
        public const string D_MaxLogFileSizeOfBinary = "5242880";
        public const string D_MaxLogFileSizeOfVfei = "5242880";
        public const string D_MaxLogFileSizeOfOpc = "5242880";
        // --
        public const string D_EnabledFilterOfOpcDeviceState = "True";
        public const string D_EnabledFilterOfOpcDeviceError = "True";
        public const string D_EnabledFilterOfOpcDeviceTimeout = "True";
        public const string D_EnabledFilterOfOpcDeviceData = "False";
        public const string D_EnabledFilterOfOpcDeviceTelnet = "False";
        public const string D_EnabledFilterOfOpcDeviceHandshake = "False";
        public const string D_EnabledFilterOfOpcDeviceControlMessage = "True";
        public const string D_EnabledFilterOfOpcDeviceBlock = "False";
        public const string D_EnabledFilterOfOpcDeviceSml = "False";
        public const string D_EnabledFilterOfOpcDeviceDataMessage = "True";
        public const string D_EnabledFilterOfHostDeviceState = "True";
        public const string D_EnabledFilterOfHostDeviceError = "True";
        public const string D_EnabledFilterOfHostDeviceVfei = "False";
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
        public const string D_OpcBinaryTracerMaxTraceCount = "500";
        // --
        public const string D_VfeiTracerMaxTraceCount = "500";        
        // --
        public const string D_VfeiViewerRecentOpenPath = "";
        public const string D_VfeiViewerRecentSavePath = "";
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
