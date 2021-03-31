/*----------------------------------------------------------------------------------------------------------
--  ��� ���α׷��� ���� ���۱��� ������ ���������� (��)�̶��޾��̾ؾ��� ������, (��)�̶��޾��̾ؾ���
--  ��������� ������� ���� ���, ����, ����, ��3�ڿ��� ����, ������ ������ �����Ǹ�, (��)�̶��޾��̾ؾ���
--  �������� ħ�ؿ� �ش�˴ϴ�.
--  (Copyright �� 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_ADMADS_TolComponentVerDataPush_Nrp.cs
--  Creator         : spike.lee
--  Create Date     : 2013.01.17
--  Description     : <Generated Class File Description>
--  History         : Created by spike.lee at 2013.01.17
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

        public override void ADMADS_TolComponentVerDataPush_Nrp(
            FXmlNode fXmlNodeIn
            )
        {
            FXmlNode fXmlNodeInComVer = null;
            FMonitoringComponentVerDataReceivedEventArgs e = null;
            string type = string.Empty;
            string factory = string.Empty;
            string component = string.Empty;
            string componentVer = string.Empty;

            try
            {
                factory = fXmlNodeIn.get_elemVal(FADMADS_TolComponentVerDataPush_In.A_hFactory, FADMADS_TolComponentVerDataPush_In.D_hFactory);
                // --
                if (factory != m_fAdmCore.fOption.factory)
                {
                    return;
                }

                // --

                fXmlNodeInComVer = fXmlNodeIn.get_elem(FADMADS_TolComponentVerDataPush_In.FComponentVer.E_ComponentVer);
                type = fXmlNodeInComVer.get_elemVal(FADMADS_TolComponentVerDataPush_In.FComponentVer.A_MonDataType, FADMADS_TolComponentVerDataPush_In.FComponentVer.D_MonDataType);
                component = fXmlNodeInComVer.get_elemVal(FADMADS_TolComponentVerDataPush_In.FComponentVer.A_Name, FADMADS_TolComponentVerDataPush_In.FComponentVer.D_Name);
                componentVer = fXmlNodeInComVer.get_elemVal(FADMADS_TolComponentVerDataPush_In.FComponentVer.A_Version, FADMADS_TolComponentVerDataPush_In.FComponentVer.D_Version);

                // --

                e = new FMonitoringComponentVerDataReceivedEventArgs(
                    (FMonitoringDataType)Enum.Parse(typeof(FMonitoringDataType), type),
                    factory,
                    component,
                    int.Parse(componentVer),
                    fXmlNodeInComVer
                    );
                // --
                m_fAdmCore.onMonitoringComponentVerDataReceived(e);
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                fXmlNodeInComVer = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
