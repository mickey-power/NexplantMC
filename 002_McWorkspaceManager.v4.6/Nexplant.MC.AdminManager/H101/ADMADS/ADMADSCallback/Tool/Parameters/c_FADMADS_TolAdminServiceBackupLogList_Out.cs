/*----------------------------------------------------------------------------------------------------------
--  ��� ���α׷��� ���� ���۱��� ������ ���������� (��)�̶��޾��̾ؾ��� ������, (��)�̶��޾��̾ؾ���
--  ��������� ������� ���� ���, ����, ����, ��3�ڿ��� ����, ������ ������ �����Ǹ�, (��)�̶��޾��̾ؾ���
--  �������� ħ�ؿ� �ش�˴ϴ�.
--  (Copyright �� 2012 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FADMADS_TolAdminServiceBackupLogList_Out.cs
--  Creator         : baehyun.seo
--  Create Date     : 2013.01.08
--  Description     : Admin Agent Option 
--  History         : Created by baehyun.seo at 2013.01.08
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.H101Interface
{
    internal static class FADMADS_TolAdminServiceBackupLogList_Out
    {

        //------------------------------------------------------------------------------------------------------------------------

        public const string E_ADMADS_TolAdminServiceBackupLogList_Out = "ADMADS_TolAdminServiceBackupLogList_Out";

        // --

        public const string A_hStatus = "hStatus";
        public const string A_hStatusMessage = "hStatusMessage";

        // --

        public const string D_hStatus = "";
        public const string D_hStatusMessage = "";

        // --

        public static class FTable
        {
            public const string E_Table = "Table";

            // --

            public const string A_Rows = "Rows";
            public const string A_RowCount = "RowCount";
            public const string A_NextRowNumber = "NextRowNumber";

            // --

            public const string D_Rows = "";
            public const string D_RowCount = "";
            public const string D_NextRowNumber = "";
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
