/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2014 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FADMADS_SysUserLogIn_Out.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2014.08.29
--  Description     : <Generated Class File Description>
--  History         : Created by jungyoul.moon at 2014.08.29
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.H101Interface
{
    internal static class FADMADS_SysUserLogIn_Out
    {

        //------------------------------------------------------------------------------------------------------------------------

        public const string E_ADMADS_SysUserLogIn_Out = "ADMADS_SysUserLogIn_Out";

        // --

        public const string A_hStatus = "hStatus";
        public const string A_hStatusMessage = "hStatusMessage";

        // --

        public const string D_hStatus = "";
        public const string D_hStatusMessage = "";

        // --

        public static class FUser
        {
            public const string E_User = "User";

            // --

            public const string A_AllAuthority = "AllAuthority";

            // --

            public const string D_AllAuthority = "";

            // --

            public static class FAuthority
            {
                public const string E_Authority = "Authority";

                // --

                public const string A_Function = "Function";
                public const string A_EnabledTransaction = "EnabledTransaction";

                // --

                public const string D_Function = "";
                public const string D_EnabledTransaction = "";
            }
        }

        // --

        public static class FNotice
        {
            public const string E_Notice = "Notice";

            // --

            public const string A_NewNotice = "NewNotice";
            public const string A_UpdateTime = "UpdateTime";
            public const string A_Contents = "Contents";

            // --

            public const string D_NewNotice = "";
            public const string D_UpdateTime = "";
            public const string D_Contents = "";
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
