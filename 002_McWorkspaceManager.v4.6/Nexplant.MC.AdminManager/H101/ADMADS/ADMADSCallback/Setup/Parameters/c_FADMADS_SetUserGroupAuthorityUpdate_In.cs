/*----------------------------------------------------------------------------------------------------------
--  ��� ���α׷��� ���� ���۱��� ������ ���������� (��)�̶��޾��̾ؾ��� ������, (��)�̶��޾��̾ؾ���
--  ��������� ������� ���� ���, ����, ����, ��3�ڿ��� ����, ������ ������ �����Ǹ�, (��)�̶��޾��̾ؾ���
--  �������� ħ�ؿ� �ش�˴ϴ�.
--  (Copyright �� 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FADMADS_SetUserGroupAuthorityUpdate_In.cs
--  Creator         : hsshim
--  Create Date     : 2013.04.09
--  Description     :  <Generated Class File Description>
--  History         : Created by hsshim at 2013.04.09
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.H101Interface
{
    internal static class FADMADS_SetUserGroupAuthorityUpdate_In
    {

        //------------------------------------------------------------------------------------------------------------------------

        public const string E_ADMADS_SetUserGroupAuthorityUpdate_In = "ADMADS_SetUserGroupAuthorityUpdate_In";

        // --

        public const string A_hLanguage = "hLanguage";
        public const string A_hFactory = "hFactory";
        public const string A_hUserId = "hUserId";
        public const string A_hHostIp = "hHostIp";
        public const string A_hHostName = "hHostName";
        public const string A_hStep = "hStep";

        // --

        public const string D_hLanguage = "";
        public const string D_hFactory = "";
        public const string D_hUserId = "";
        public const string D_hHostIp = "";
        public const string D_hHostName = "";
        public const string D_hStep = "";

        // --

        public static class FAuthority
        {
            public const string E_Authority = "Authority";

            // --

            public const string A_UserGroup = "UserGroup";
            public const string A_Application = "Application";

            // --

            public const string D_UserGroup = "";
            public const string D_Application = "";

            // --

            public static class FFunction
            {
                public const string E_Function = "Function";

                // --

                public const string A_Function = "Function";
                public const string A_EnabledTransaction = "EnabledTransaction";

                // --

                public const string D_Function = "";
                public const string D_EnabledTransaction = "";
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
