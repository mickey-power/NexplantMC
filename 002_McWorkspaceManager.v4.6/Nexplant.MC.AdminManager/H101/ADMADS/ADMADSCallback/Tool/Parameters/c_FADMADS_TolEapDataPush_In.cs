/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FADMADS_TolEapDataPush_In.cs
--  Creator         : <Generated Class File Creator>
--  Create Date     : 2017.06.07
--  Description     : <Generated Class File Description>
--  History         : Created by <Generated Class File Creator> at 2017.06.07
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.H101Interface
{
    internal static class FADMADS_TolEapDataPush_In
    {

        //------------------------------------------------------------------------------------------------------------------------

        public const string E_ADMADS_TolEapDataPush_In = "ADMADS_TolEapDataPush_In";

        // --

        public const string A_hLanguage = "hLanguage";
        public const string A_hFactory = "hFactory";
        public const string A_hUserId = "hUserId";
        public const string A_hStep = "hStep";

        // --

        public const string D_hLanguage = "";
        public const string D_hFactory = "";
        public const string D_hUserId = "";
        public const string D_hStep = "";

        // --

        public static class FEap
        {
            public const string E_Eap = "Eap";

            // --

            public const string A_MonDataType = "MonDataType";
            public const string A_Name = "Name";
            public const string A_Description = "Description";
            public const string A_RpmCount = "RpmCount";
            public const string A_EapType = "EapType";
            public const string A_OperMode = "OperMode";
            public const string A_Server = "Server";
            public const string A_Step = "Step";
            public const string A_UpDown = "UpDown";
            public const string A_Status = "Status";
            public const string A_Alarm = "Alarm";
            public const string A_ReloadCount = "ReloadCount";
            public const string A_NeedAction = "NeedAction";
            public const string A_NextNeedAction = "NextNeedAction";
            public const string A_SetPackage = "SetPackage";
            public const string A_SetPackageVer = "SetPackageVer";
            public const string A_RelPackage = "RelPackage";
            public const string A_RelPackageVer = "RelPackageVer";
            public const string A_AplPackage = "AplPackage";
            public const string A_AplPackageVer = "AplPackageVer";
            public const string A_SetModel = "SetModel";
            public const string A_SetModelVer = "SetModelVer";
            public const string A_RelModel = "RelModel";
            public const string A_RelModelVer = "RelModelVer";
            public const string A_AplModel = "AplModel";
            public const string A_AplModelVer = "AplModelVer";
            public const string A_SetUsedComponent = "SetUsedComponent";
            public const string A_SetComponent = "SetComponent";
            public const string A_SetComponentVer = "SetComponentVer";
            public const string A_RelUsedComponent = "RelUsedComponent";
            public const string A_RelComponent = "RelComponent";
            public const string A_RelComponentVer = "RelComponentVer";
            public const string A_AplUsedComponent = "AplUsedComponent";
            public const string A_AplComponent = "AplComponent";
            public const string A_AplComponentVer = "AplComponentVer";
            public const string A_LastEventId = "LastEventId";

            // --

            public const string D_MonDataType = "";
            public const string D_Name = "";
            public const string D_Description = "";
            public const string D_RpmCount = "";
            public const string D_EapType = "";
            public const string D_OperMode = "";
            public const string D_Server = "";
            public const string D_Step = "";
            public const string D_UpDown = "";
            public const string D_Status = "";
            public const string D_Alarm = "";
            public const string D_ReloadCount = "";
            public const string D_NeedAction = "";
            public const string D_NextNeedAction = "";
            public const string D_SetPackage = "";
            public const string D_SetPackageVer = "";
            public const string D_RelPackage = "";
            public const string D_RelPackageVer = "";
            public const string D_AplPackage = "";
            public const string D_AplPackageVer = "";
            public const string D_SetModel = "";
            public const string D_SetModelVer = "";
            public const string D_RelModel = "";
            public const string D_RelModelVer = "";
            public const string D_AplModel = "";
            public const string D_AplModelVer = "";
            public const string D_SetUsedComponent = "";
            public const string D_SetComponent = "";
            public const string D_SetComponentVer = "";
            public const string D_RelUsedComponent = "";
            public const string D_RelComponent = "";
            public const string D_RelComponentVer = "";
            public const string D_AplUsedComponent = "";
            public const string D_AplComponent = "";
            public const string D_AplComponentVer = "";
            public const string D_LastEventId = "";

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
                    public const string A_State = "State";

                    // --

                    public const string D_EapType = "";
                    public const string D_Seq = "";
                    public const string D_Name = "";
                    public const string D_Description = "";
                    public const string D_Mode = "";
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
                    public const string D_State = "";

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
                    public const string A_Driver = "Driver";
                    public const string A_DriverDescription = "DriverDescription";
                    public const string A_DriverOption = "DriverOption";
                    public const string A_TransactionTimeout = "TransactionTimeout";
                    public const string A_State = "State";

                    // --

                    public const string D_EapType = "";
                    public const string D_Seq = "";
                    public const string D_Name = "";
                    public const string D_Description = "";
                    public const string D_Mode = "";
                    public const string D_Driver = "";
                    public const string D_DriverDescription = "";
                    public const string D_DriverOption = "";
                    public const string D_TransactionTimeout = "";
                    public const string D_State = "";

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
                    public const string A_Type = "Type";
                    public const string A_Area = "Area";
                    public const string A_Line = "Line";
                    public const string A_Mdln = "Mdln";
                    public const string A_SoftRev = "SoftRev";
                    public const string A_ControlMode = "ControlMode";
                    public const string A_PrimaryState = "PrimaryState";
                    public const string A_State = "State";
                    public const string A_Alarm = "Alarm";
                    public const string A_EventDefine = "EventDefine";

                    // --

                    public const string D_EapType = "";
                    public const string D_Seq = "";
                    public const string D_Name = "";
                    public const string D_Description = "";
                    public const string D_Type = "";
                    public const string D_Area = "";
                    public const string D_Line = "";
                    public const string D_Mdln = "";
                    public const string D_SoftRev = "";
                    public const string D_ControlMode = "";
                    public const string D_PrimaryState = "";
                    public const string D_State = "";
                    public const string D_Alarm = "";
                    public const string D_EventDefine = "";
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
