/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2018 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FADMADS_InqEquipmentGemStatus_Out.cs
--  Creator         : mjkim
--  Create Date     : 2018.04.18
--  Description     : <Generated Class File Description>
--  History         : Created by mjkim at 2018.04.18
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.H101Interface
{
    internal static class FADMADS_InqEquipmentGemStatus_Out
    {

        //------------------------------------------------------------------------------------------------------------------------

        public const string E_ADMADS_InqEquipmentGemStatus_Out = "ADMADS_InqEquipmentGemStatus_Out";

        // --

        public const string A_hStatus = "hStatus";
        public const string A_hStatusMessage = "hStatusMessage";

        // --

        public const string D_hStatus = "";
        public const string D_hStatusMessage = "";

        // --

        public static class FGem
        {
            public const string E_Gem = "Gem";

            // --


            // --


            // --

            public static class FEvent
            {
                public const string E_Event = "Event";

                // --

                public const string A_Id = "Id";
                public const string A_Name = "Name";
                public const string A_Format = "Format";
                public const string A_Description = "Description";

                // --

                public const string D_Id = "";
                public const string D_Name = "";
                public const string D_Format = "";
                public const string D_Description = "";

                // --

                public static class FReport
                {
                    public const string E_Report = "Report";

                    // --

                    public const string A_Id = "Id";
                    public const string A_Name = "Name";
                    public const string A_Format = "Format";
                    public const string A_Description = "Description";

                    // --

                    public const string D_Id = "";
                    public const string D_Name = "";
                    public const string D_Format = "";
                    public const string D_Description = "";

                    // --

                    public static class FVariable
                    {
                        public const string E_Variable = "Variable";

                        // --

                        public const string A_Id = "Id";
                        public const string A_Name = "Name";
                        public const string A_Format = "Format";
                        public const string A_Description = "Description";

                        // --

                        public const string D_Id = "";
                        public const string D_Name = "";
                        public const string D_Format = "";
                        public const string D_Description = "";
                    }
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
