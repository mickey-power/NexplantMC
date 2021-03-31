/*----------------------------------------------------------------------------------------------------------
--  ��� ���α׷��� ���� ���۱��� ������ ���������� (��)�̶��޾��̾ؾ��� ������, (��)�̶��޾��̾ؾ���
--  ��������� ������� ���� ���, ����, ����, ��3�ڿ��� ����, ������ ������ �����Ǹ�, (��)�̶��޾��̾ؾ���
--  �������� ħ�ؿ� �ش�˴ϴ�.
--  (Copyright �� 2012 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FADMADS_TolEapBackupLogList_In.cs
--  Creator         : baehyun.seo
--  Create Date     : 2013.01.14
--  Description     : Admin Agent Option 
--  History         : Created by baehyun.seo at 2013.01.14
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.H101Interface
{
    internal static class FADMADS_TolEapBackupLogList_In
    {

        //------------------------------------------------------------------------------------------------------------------------

        public const string E_ADMADS_TolEapBackupLogList_In = "ADMADS_TolEapBackupLogList_In";

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

        public static class FLog
        {
            public const string E_Log = "Log";

            // --

            public const string A_Eap = "Eap";
            public const string A_Type = "Type";
            public const string A_NextRowNumber = "NextRowNumber";

            // --

            public const string D_Eap = "";
            public const string D_Type = "";
            public const string D_NextRowNumber = "";
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
