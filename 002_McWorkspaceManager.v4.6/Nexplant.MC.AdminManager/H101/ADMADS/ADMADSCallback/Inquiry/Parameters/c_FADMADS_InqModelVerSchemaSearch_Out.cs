/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FADMADS_InqModelVerSchemaSearch_Out.cs
--  Creator         : iskim
--  Create Date     : 2014.03.14
--  Description     : <Generated Class File Description>
--  History         : Created by iskim at 2014.03.14
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.H101Interface
{
    internal static class FADMADS_InqModelVerSchemaSearch_Out
    {

        //------------------------------------------------------------------------------------------------------------------------

        public const string E_ADMADS_InqModelVerSchemaSearch_Out = "ADMADS_InqModelVerSchemaSearch_Out";

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

                public const string A_ModelType = "ModelType";
                public const string A_Name = "Name";
                public const string A_Description = "Description";

                // --

                public const string D_ModelType = "";
                public const string D_Name = "";
                public const string D_Description = "";

                // --

                public static class FSecsDevice
                {
                    public const string E_SecsDevice = "SecsDevice";

                    // --

                    public const string A_ModelType = "ModelType";
                    public const string A_Seq = "Seq";
                    public const string A_Name = "Name";
                    public const string A_Description = "Description";
                    public const string A_Protocol = "Protocol";

                    // --

                    public const string D_ModelType = "";
                    public const string D_Seq = "";
                    public const string D_Name = "";
                    public const string D_Description = "";
                    public const string D_Protocol = "";

                    // --

                    public static class FSecsSession
                    {
                        public const string E_SecsSession = "SecsSession";

                        // --

                        public const string A_ModelType = "ModelType";
                        public const string A_Seq = "Seq";
                        public const string A_Name = "Name";
                        public const string A_Description = "Description";
                        public const string A_SessionId = "SessionId";

                        // --

                        public const string D_ModelType = "";
                        public const string D_Seq = "";
                        public const string D_Name = "";
                        public const string D_Description = "";
                        public const string D_SessionId = "";
                    }
                }

                // --

                public static class FHostDevice
                {
                    public const string E_HostDevice = "HostDevice";

                    // --

                    public const string A_ModelType = "ModelType";
                    public const string A_Seq = "Seq";
                    public const string A_Name = "Name";
                    public const string A_Description = "Description";
                    public const string A_Driver = "Driver";
                    public const string A_DriverDescription = "DriverDescription";

                    // --

                    public const string D_ModelType = "";
                    public const string D_Seq = "";
                    public const string D_Name = "";
                    public const string D_Description = "";
                    public const string D_Driver = "";
                    public const string D_DriverDescription = "";

                    // --

                    public static class FHostSession
                    {
                        public const string E_HostSession = "HostSession";

                        // --

                        public const string A_ModelType = "ModelType";
                        public const string A_Seq = "Seq";
                        public const string A_Name = "Name";
                        public const string A_Description = "Description";
                        public const string A_MachineId = "MachineId";
                        public const string A_SessionId = "SessionId";

                        // --

                        public const string D_ModelType = "";
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

                    public const string A_ModelType = "ModelType";
                    public const string A_Seq = "Seq";
                    public const string A_Name = "Name";
                    public const string A_Description = "Description";

                    // --

                    public const string D_ModelType = "";
                    public const string D_Seq = "";
                    public const string D_Name = "";
                    public const string D_Description = "";
                }

                // --

                public static class FEnvironmentList
                {
                    public const string E_EnvironmentList = "EnvironmentList";

                    // --

                    public const string A_ModelType = "ModelType";
                    public const string A_Seq = "Seq";
                    public const string A_Name = "Name";
                    public const string A_Description = "Description";

                    // --

                    public const string D_ModelType = "";
                    public const string D_Seq = "";
                    public const string D_Name = "";
                    public const string D_Description = "";

                    // --

                    public static class FEnvironment
                    {
                        public const string E_Environment = "Environment";

                        // --

                        public const string A_ModelType = "ModelType";
                        public const string A_Seq = "Seq";
                        public const string A_Name = "Name";
                        public const string A_Description = "Description";
                        public const string A_UniqueId = "UniqueId";
                        public const string A_Format = "Format";
                        public const string A_Length = "Length";
                        public const string A_Value = "Value";

                        // --

                        public const string D_ModelType = "";
                        public const string D_Seq = "";
                        public const string D_Name = "";
                        public const string D_Description = "";
                        public const string D_UniqueId = "";
                        public const string D_Format = "";
                        public const string D_Length = "";
                        public const string D_Value = "";
                    }
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
