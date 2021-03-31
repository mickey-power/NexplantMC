/*----------------------------------------------------------------------------------------------------------
--  ��� ���α׷��� ���� ���۱��� ������ ���������� (��)�̶��޾��̾ؾ��� ������, (��)�̶��޾��̾ؾ���
--  ��������� ������� ���� ���, ����, ����, ��3�ڿ��� ����, ������ ������ �����Ǹ�, (��)�̶��޾��̾ؾ���
--  �������� ħ�ؿ� �ش�˴ϴ�.
--  (Copyright �� 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_ADMADS_TolServerIssueEventRefresh_Nrp.cs
--  Creator         : spike.lee
--  Create Date     : 2017.07.14
--  Description     : FAmate Admin Manager Server Issue Event Refresh Function
--  History         : Created by spike.lee at 2017.07.14
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.AdminManager;

namespace Nexplant.MC.H101Interface
{
    internal partial class FADMADSCallback
    {

        //------------------------------------------------------------------------------------------------------------------------

        public override void ADMADS_TolServerIssueEventRefresh_Nrp(
            FXmlNode fXmlNodeIn
            )
        {
            string factory = string.Empty;

            try
            {
                factory = fXmlNodeIn.get_elemVal(FADMADS_TolServerIssueEventRefresh_In.A_hFactory, FADMADS_TolServerIssueEventRefresh_In.D_hFactory);
                if (factory != m_fAdmCore.fOption.factory)
                {
                    return;
                }
                // --
                m_fAdmCore.onServerIssueEventRefresh(new EventArgs());
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
