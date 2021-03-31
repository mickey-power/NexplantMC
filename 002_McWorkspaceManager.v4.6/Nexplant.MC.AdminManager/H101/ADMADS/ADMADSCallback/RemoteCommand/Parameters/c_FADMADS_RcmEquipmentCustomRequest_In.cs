/*----------------------------------------------------------------------------------------------------------
--  ��� ���α׷��� ���� ���۱��� ������ ���������� (��)�̶��޾��̾ؾ��� ������, (��)�̶��޾��̾ؾ���
--  ��������� ������� ���� ���, ����, ����, ��3�ڿ��� ����, ������ ������ �����Ǹ�, (��)�̶��޾��̾ؾ���
--  �������� ħ�ؿ� �ش�˴ϴ�.
--  (Copyright �� 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FADMADS_RcmEquipmentCustomRequest_In.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2013.06.18
--  Description     : <Generated Class File Description>
--  History         : Created by jungyoul.moon at 2013.06.18
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.H101Interface
{
    internal static class FADMADS_RcmEquipmentCustomRequest_In
    {

        //------------------------------------------------------------------------------------------------------------------------

        public const string E_ADMADS_RcmEquipmentCustomRequest_In = "ADMADS_RcmEquipmentCustomRequest_In";

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

        public static class FEap
        {
            public const string E_Eap = "Eap";

            // --

            public const string A_EapId = "EapId";
            public const string A_Command = "Command";

            // --

            public const string D_EapId = "";
            public const string D_Command = "";

            // --

            public static class FEquipment
            {
                public const string E_Equipment = "Equipment";

                // --

                public const string A_EquipmentId = "EquipmentId";

                // --

                public const string D_EquipmentId = "";

                // --

                public static class FDataList
                {
                    public const string E_DataList = "DataList";

                    // --

                    public const string A_Data = "Data";

                    // --

                    public const string D_Data = "";
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
