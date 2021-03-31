/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FADMADS_ComEapSchemaSearch_Out.cs
--  Creator         : spike.lee
--  Create Date     : 2017.08.23
--  Description     : <Generated Class File Description>
--  History         : Created by spike.lee at 2017.08.23
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.H101Interface
{
    internal static class FADMADS_ComEapSchemaSearch_Out
    {

        //------------------------------------------------------------------------------------------------------------------------

        public const string E_ADMADS_ComEapSchemaSearch_Out = "ADMADS_ComEapSchemaSearch_Out";

        // --

        public const string A_hStatus = "hStatus";
        public const string A_hStatusMessage = "hStatusMessage";

        // --

        public const string D_hStatus = "";
        public const string D_hStatusMessage = "";

        // --

        public static class FSchema
        {
            public const string E_Schema = "Schema";

            // --


            // --


            // --

            public static class FSecsDriver
            {
                public const string E_SecsDriver = "SecsDriver";

                // --

                public const string A_EapType = "EapType";
                public const string A_Name = "Name";
                public const string A_Description = "Description";

                // --

                public const string D_EapType = "";
                public const string D_Name = "";
                public const string D_Description = "";

                // --

                public static class FSecsDevice
                {
                    public const string E_SecsDevice = "SecsDevice";

                    // --

                    public const string A_EapType = "EapType";
                    public const string A_Seq = "Seq";
                    public const string A_Name = "Name";
                    public const string A_Description = "Description";
                    public const string A_Mode = "Mode";
                    public const string A_State = "State";
                    public const string A_Protocol = "Protocol";
                    public const string A_ConnectMode = "ConnectMode";
                    public const string A_LocalIp = "LocalIp";
                    public const string A_LocalPort = "LocalPort";
                    public const string A_RemoteIp = "RemoteIp";
                    public const string A_RemotePort = "RemotePort";
                    public const string A_SerialPort = "SerialPort";
                    public const string A_Baud = "Baud";
                    public const string A_RBit = "RBit";
                    public const string A_Interleave = "Interleave";
                    public const string A_DuplicateError = "DuplicateError";
                    public const string A_IgnoreSystemBytes = "IgnoreSystemBytes";
                    public const string A_LinkTestTimePeriod = "LinkTestTimePeriod";
                    public const string A_RetryLimit = "RetryLimit";
                    public const string A_OpcUrl = "OpcUrl";
                    public const string A_OpcHandleId = "OpcHandleId";
                    public const string A_OpcLocalId = "OpcLocalId";
                    public const string A_OpcDefaultNamespace = "OpcDefaultNamespace";
                    public const string A_OpcKeepAliveTime = "OpcKeepAliveTime";
                    public const string A_OpcEventReloadTime = "OpcEventReloadTime";
                    public const string A_T1Timeout = "T1Timeout";
                    public const string A_T2Timeout = "T2Timeout";
                    public const string A_T3Timeout = "T3Timeout";
                    public const string A_T4Timeout = "T4Timeout";
                    public const string A_T5Timeout = "T5Timeout";
                    public const string A_T6Timeout = "T6Timeout";
                    public const string A_T7Timeout = "T7Timeout";
                    public const string A_T8Timeout = "T8Timeout";

                    // --

                    public const string D_EapType = "";
                    public const string D_Seq = "";
                    public const string D_Name = "";
                    public const string D_Description = "";
                    public const string D_Mode = "";
                    public const string D_State = "";
                    public const string D_Protocol = "";
                    public const string D_ConnectMode = "";
                    public const string D_LocalIp = "";
                    public const string D_LocalPort = "";
                    public const string D_RemoteIp = "";
                    public const string D_RemotePort = "";
                    public const string D_SerialPort = "";
                    public const string D_Baud = "";
                    public const string D_RBit = "";
                    public const string D_Interleave = "";
                    public const string D_DuplicateError = "";
                    public const string D_IgnoreSystemBytes = "";
                    public const string D_LinkTestTimePeriod = "";
                    public const string D_RetryLimit = "";
                    public const string D_OpcUrl = "";
                    public const string D_OpcHandleId = "";
                    public const string D_OpcLocalId = "";
                    public const string D_OpcDefaultNamespace = "";
                    public const string D_OpcKeepAliveTime = "";
                    public const string D_OpcEventReloadTime = "";
                    public const string D_T1Timeout = "";
                    public const string D_T2Timeout = "";
                    public const string D_T3Timeout = "";
                    public const string D_T4Timeout = "";
                    public const string D_T5Timeout = "";
                    public const string D_T6Timeout = "";
                    public const string D_T7Timeout = "";
                    public const string D_T8Timeout = "";

                    // --

                    public static class FSecsSession
                    {
                        public const string E_SecsSession = "SecsSession";

                        // --

                        public const string A_EapType = "EapType";
                        public const string A_Seq = "Seq";
                        public const string A_Name = "Name";
                        public const string A_Description = "Description";
                        public const string A_SessionId = "SessionId";
                        public const string A_ScanEnabled = "ScanEnabled";
                        public const string A_ScanTime = "ScanTime";
                        public const string A_AutoClear = "AutoClear";
                        public const string A_LinkMapExpression = "LinkMapExpression";
                        public const string A_ReadBitDeviceCode = "ReadBitDeviceCode";
                        public const string A_ReadBitStartAddress = "ReadBitStartAddress";
                        public const string A_ReadBitLength = "ReadBitLength";
                        public const string A_ReadWordDeviceCode = "ReadWordDeviceCode";
                        public const string A_ReadWordStartAddress = "ReadWordStartAddress";
                        public const string A_ReadWordLength = "ReadWordLength";
                        public const string A_WriteBitDeviceCode = "WriteBitDeviceCode";
                        public const string A_WriteBitStartAddress = "WriteBitStartAddress";
                        public const string A_WriteBitLength = "WriteBitLength";
                        public const string A_WriteWordDeviceCode = "WriteWordDeviceCode";
                        public const string A_WriteWordStartAddress = "WriteWordStartAddress";
                        public const string A_WriteWordLength = "WriteWordLength";
                        public const string A_OpcChannel = "OpcChannel";
                        public const string A_OpcUpdateRate = "OpcUpdateRate";
                        public const string A_OpcDeadBand = "OpcDeadBand";

                        // --

                        public const string D_EapType = "";
                        public const string D_Seq = "";
                        public const string D_Name = "";
                        public const string D_Description = "";
                        public const string D_SessionId = "";
                        public const string D_ScanEnabled = "";
                        public const string D_ScanTime = "";
                        public const string D_AutoClear = "";
                        public const string D_LinkMapExpression = "";
                        public const string D_ReadBitDeviceCode = "";
                        public const string D_ReadBitStartAddress = "";
                        public const string D_ReadBitLength = "";
                        public const string D_ReadWordDeviceCode = "";
                        public const string D_ReadWordStartAddress = "";
                        public const string D_ReadWordLength = "";
                        public const string D_WriteBitDeviceCode = "";
                        public const string D_WriteBitStartAddress = "";
                        public const string D_WriteBitLength = "";
                        public const string D_WriteWordDeviceCode = "";
                        public const string D_WriteWordStartAddress = "";
                        public const string D_WriteWordLength = "";
                        public const string D_OpcChannel = "";
                        public const string D_OpcUpdateRate = "";
                        public const string D_OpcDeadBand = "";
                    }
                }

                // --

                public static class FHostDevice
                {
                    public const string E_HostDevice = "HostDevice";

                    // --

                    public const string A_EapType = "EapType";
                    public const string A_Seq = "Seq";
                    public const string A_Name = "Name";
                    public const string A_Description = "Description";
                    public const string A_Mode = "Mode";
                    public const string A_State = "State";
                    public const string A_Driver = "Driver";
                    public const string A_DriverDescription = "DriverDescription";
                    public const string A_DriverOption = "DriverOption";
                    public const string A_TransactionTimeout = "TransactionTimeout";

                    // --

                    public const string D_EapType = "";
                    public const string D_Seq = "";
                    public const string D_Name = "";
                    public const string D_Description = "";
                    public const string D_Mode = "";
                    public const string D_State = "";
                    public const string D_Driver = "";
                    public const string D_DriverDescription = "";
                    public const string D_DriverOption = "";
                    public const string D_TransactionTimeout = "";

                    // --

                    public static class FHostSession
                    {
                        public const string E_HostSession = "HostSession";

                        // --

                        public const string A_EapType = "EapType";
                        public const string A_Seq = "Seq";
                        public const string A_Name = "Name";
                        public const string A_Description = "Description";
                        public const string A_MachineId = "MachineId";
                        public const string A_SessionId = "SessionId";

                        // --

                        public const string D_EapType = "";
                        public const string D_Seq = "";
                        public const string D_Name = "";
                        public const string D_Description = "";
                        public const string D_MachineId = "";
                        public const string D_SessionId = "";
                    }
                }

                // --

                public static class FEquipment
                {
                    public const string E_Equipment = "Equipment";

                    // --

                    public const string A_EapType = "EapType";
                    public const string A_Seq = "Seq";
                    public const string A_Name = "Name";
                    public const string A_Description = "Description";
                    public const string A_ControlMode = "ControlMode";
                    public const string A_PrimaryState = "PrimaryState";
                    public const string A_State = "State";
                    public const string A_Alarm = "Alarm";
                    public const string A_IpAddress = "IpAddress";

                    // --

                    public const string D_EapType = "";
                    public const string D_Seq = "";
                    public const string D_Name = "";
                    public const string D_Description = "";
                    public const string D_ControlMode = "";
                    public const string D_PrimaryState = "";
                    public const string D_State = "";
                    public const string D_Alarm = "";
                    public const string D_IpAddress = "";
                }

                // --

                public static class FEnvironmentList
                {
                    public const string E_EnvironmentList = "EnvironmentList";

                    // --

                    public const string A_EapType = "EapType";
                    public const string A_Seq = "Seq";
                    public const string A_Name = "Name";
                    public const string A_Description = "Description";

                    // --

                    public const string D_EapType = "";
                    public const string D_Seq = "";
                    public const string D_Name = "";
                    public const string D_Description = "";

                    // --

                    public static class FEnvironment
                    {
                        public const string E_Environment = "Environment";

                        // --

                        public const string A_EapType = "EapType";
                        public const string A_Seq = "Seq";
                        public const string A_Name = "Name";
                        public const string A_Description = "Description";
                        public const string A_UniqueId = "UniqueId";
                        public const string A_Format = "Format";
                        public const string A_Length = "Length";
                        public const string A_Value = "Value";

                        // --

                        public const string D_EapType = "";
                        public const string D_Seq = "";
                        public const string D_Name = "";
                        public const string D_Description = "";
                        public const string D_UniqueId = "";
                        public const string D_Format = "";
                        public const string D_Length = "";
                        public const string D_Value = "";
                    }
                }

                // --

                public static class FEapConfig
                {
                    public const string E_EapConfig = "EapConfig";

                    // --

                    public const string A_EapType = "EapType";
                    public const string A_Language = "Language";
                    public const string A_UserId = "UserId";
                    public const string A_DebugLogKeepingPeriod = "DebugLogKeepingPeriod";
                    public const string A_BinaryLogEnabled = "BinaryLogEnabled";
                    public const string A_MaxBinaryLogFileSize = "MaxBinaryLogFileSize";
                    public const string A_SmlLogEnabled = "SmlLogEnabled";
                    public const string A_MaxSmlLogFileSize = "MaxSmlLogFileSize";
                    public const string A_VfeiLogEnabled = "VfeiLogEnabled";
                    public const string A_MaxVfeiLogFileSize = "MaxVfeiLogFileSize";
                    public const string A_SecsLogEnabled = "SecsLogEnabled";
                    public const string A_MaxSecsLogFileSize = "MaxSecsLogFileSize";
                    public const string A_FileNetworkPath = "FileNetworkPath";
                    public const string A_FileUser = "FileUser";
                    public const string A_FilePassword = "FilePassword";
                    public const string A_FileSearchPattern = "FileSearchPattern";
                    public const string A_FileSearchPeriod = "FileSearchPeriod";
                    public const string A_FileBackUpPath = "FileBackUpPath";
                    public const string A_FileBackUpUser = "FileBackUpUser";
                    public const string A_FileBackUpPassword = "FileBackUpPassword";
                    public const string A_FileErrorPath = "FileErrorPath";
                    public const string A_FileErrorUser = "FileErrorUser";
                    public const string A_FileErrorPassword = "FileErrorPassword";

                    // --

                    public const string D_EapType = "";
                    public const string D_Language = "";
                    public const string D_UserId = "";
                    public const string D_DebugLogKeepingPeriod = "";
                    public const string D_BinaryLogEnabled = "";
                    public const string D_MaxBinaryLogFileSize = "";
                    public const string D_SmlLogEnabled = "";
                    public const string D_MaxSmlLogFileSize = "";
                    public const string D_VfeiLogEnabled = "";
                    public const string D_MaxVfeiLogFileSize = "";
                    public const string D_SecsLogEnabled = "";
                    public const string D_MaxSecsLogFileSize = "";
                    public const string D_FileNetworkPath = "";
                    public const string D_FileUser = "";
                    public const string D_FilePassword = "";
                    public const string D_FileSearchPattern = "";
                    public const string D_FileSearchPeriod = "";
                    public const string D_FileBackUpPath = "";
                    public const string D_FileBackUpUser = "";
                    public const string D_FileBackUpPassword = "";
                    public const string D_FileErrorPath = "";
                    public const string D_FileErrorUser = "";
                    public const string D_FileErrorPassword = "";
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
