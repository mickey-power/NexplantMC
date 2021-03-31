/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlTagSSMOption.cs
--  Creator         : kitae
--  Create Date     : 2012.03.16
--  Description     : FAMate SECS Modeler Option XML Tag Definition Class 
--  History         : Created by kitae at 2012.03.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nexplant.MC.SecsModeler
{
    public static class FXmlTagSSMOption
    {

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2012.11.15 by spike.lee
        // Config. XML Tag 변수 Name 수정 (너무 일관성 없음)
        // 이 XML Tag는 Workspace Manager Option XML Tag가 아닙니다. SECS Modeler Option XML Tag 입니다. (주석 똑바로 씁시다.)
        // --
        // FAMate SECS Modeler Option Element and Attribute
        // ***
        public const string E_SSMOption = "SSM";
        // --
        public const string A_EnabledEventsOfSecsDeviceState = "E01";
        public const string A_EnabledEventsOfSecsDeviceError = "E02";
        public const string A_EnabledEventsOfSecsDeviceTimeout = "E03";
        public const string A_EnabledEventsOfSecsDeviceData = "E04";
        public const string A_EnabledEventsOfSecsDeviceTelnet = "E05";
        public const string A_EnabledEventsOfSecsDeviceHandshake = "E06";
        public const string A_EnabledEventsOfSecsDeviceControlMessage = "E07";
        public const string A_EnabledEventsOfSecsDeviceBlock = "E08";
        public const string A_EnabledEventsOfSecsDeviceSml = "E09";
        public const string A_EnabledEventsOfSecsDeviceDataMessage = "E10";
        public const string A_EnabledEventsOfHostDeviceState = "E11";
        public const string A_EnabledEventsOfHostDeviceError = "E12";
        public const string A_EnabledEventsOfHostDeviceVfei = "E13";
        public const string A_EnabledEventsOfHostDeviceDataMessage = "E14";
        public const string A_EnabledEventsOfScenario = "E15";
        public const string A_EnabledEventsOfApplication = "E16";
        // --
        public const string A_LogDirectory = "LD";
        public const string A_EnabledLogOfBinary = "L1";
        public const string A_EnabledLogOfSml = "L2";
        public const string A_EnabledLogOfVfei = "L3";
        public const string A_EnabledLogOfSecs = "L4";
        // --
        public const string A_MaxLogFileSizeOfBinary = "S1";
        public const string A_MaxLogFileSizeOfSml = "S2";
        public const string A_MaxLogFileSizeOfVfei = "S3";
        public const string A_MaxLogFileSizeOfSecs = "S4";
        // --
        public const string A_EnabledFilterOfSecsDeviceState = "F01";
        public const string A_EnabledFilterOfSecsDeviceError = "F02";
        public const string A_EnabledFilterOfSecsDeviceTimeout = "F03";
        public const string A_EnabledFilterOfSecsDeviceData = "F04";
        public const string A_EnabledFilterOfSecsDeviceTelnet = "F05";
        public const string A_EnabledFilterOfSecsDeviceHandshake = "F06";
        public const string A_EnabledFilterOfSecsDeviceControlMessage = "F07";
        public const string A_EnabledFilterOfSecsDeviceBlock = "F08";
        public const string A_EnabledFilterOfSecsDeviceSml = "F09";
        public const string A_EnabledFilterOfSecsDeviceDataMessage = "F10";
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
        public const string A_SecsBinaryTracerMaxTraceCount = "BMC";
        // --
        public const string A_VfeiTracerMaxTraceCount = "VMC";
        // --
        public const string A_SmlTracerMaxTraceCount = "SMC";
        // --
        public const string A_SmlViewerRecentOpenPath = "SVO";
        public const string A_SmlViewerRecentSavePath = "SVS";
        // --
        public const string A_VfeiViewerRecentOpenPath = "VVO";
        public const string A_VfeiViewerRecentSavePath = "VVS";
        // --
        public const string A_CommonFontName = "FNA";
        public const string A_CommonFontSize = "FSZ";
        // --
        // 2018.12.27 Jeff
        // Drag & Drop Confirm
        public const string A_DrapDropConfirm = "FDD";
        
        // --

        public const string D_EnabledEventsOfSecsDeviceState = "True";
        public const string D_EnabledEventsOfSecsDeviceError = "True";
        public const string D_EnabledEventsOfSecsDeviceTimeout = "True";
        public const string D_EnabledEventsOfSecsDeviceData = "False";
        public const string D_EnabledEventsOfSecsDeviceTelnet = "False";
        public const string D_EnabledEventsOfSecsDeviceHandshake = "False";
        public const string D_EnabledEventsOfSecsDeviceControlMessage = "True";
        public const string D_EnabledEventsOfSecsDeviceBlock = "False";
        public const string D_EnabledEventsOfSecsDeviceSml = "False";
        public const string D_EnabledEventsOfSecsDeviceDataMessage = "True";
        public const string D_EnabledEventsOfHostDeviceState = "True";
        public const string D_EnabledEventsOfHostDeviceError = "True";
        public const string D_EnabledEventsOfHostDeviceVfei = "False";
        public const string D_EnabledEventsOfHostDeviceDataMessage = "True";
        public const string D_EnabledEventsOfScenario = "True";
        public const string D_EnabledEventsOfApplication = "True";
        // --
        public const string D_LogDirectory = "";
        public const string D_EnabledLogOfBinary = "False";
        public const string D_EnabledLogOfSml = "False";
        public const string D_EnabledLogOfVfei = "False";
        public const string D_EnabledLogOfSecs = "False";
        // --
        public const string D_MaxLogFileSizeOfBinary = "5242880";
        public const string D_MaxLogFileSizeOfSml = "5242880";
        public const string D_MaxLogFileSizeOfVfei = "5242880";
        public const string D_MaxLogFileSizeOfSecs = "5242880";
        // --
        public const string D_EnabledFilterOfSecsDeviceState = "True";
        public const string D_EnabledFilterOfSecsDeviceError = "True";
        public const string D_EnabledFilterOfSecsDeviceTimeout = "True";
        public const string D_EnabledFilterOfSecsDeviceData = "False";
        public const string D_EnabledFilterOfSecsDeviceTelnet = "False";
        public const string D_EnabledFilterOfSecsDeviceHandshake = "False";
        public const string D_EnabledFilterOfSecsDeviceControlMessage = "True";
        public const string D_EnabledFilterOfSecsDeviceBlock = "False";
        public const string D_EnabledFilterOfSecsDeviceSml = "False";
        public const string D_EnabledFilterOfSecsDeviceDataMessage = "True";
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
        public const string D_SecsBinaryTracerMaxTraceCount = "500";
        // --
        public const string D_VfeiTracerMaxTraceCount = "500";
        // --
        public const string D_SmlTracerMaxTraceCount = "500";
        // --
        public const string D_SmlViewerRecentOpenPath = "";
        public const string D_SmlViewerRecentSavePath = "";
        // --
        public const string D_VfeiViewerRecentOpenPath = "";
        public const string D_VfeiViewerRecentSavePath = "";
        // --
        public const string D_CommonFontName = "Verdana";
        public const string D_CommonFontSize = "8";
        // --
        // 2018.12.27 Jeff
        // Drag & Drop Confirm
        public const string D_DrapDropConfirm = "False";

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
