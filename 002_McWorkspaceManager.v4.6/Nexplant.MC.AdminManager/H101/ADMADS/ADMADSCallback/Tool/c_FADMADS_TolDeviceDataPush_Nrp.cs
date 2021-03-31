/*----------------------------------------------------------------------------------------------------------
--  ��� ���α׷��� ���� ���۱��� ������ ���������� (��)�̶��޾��̾ؾ��� ������, (��)�̶��޾��̾ؾ���
--  ��������� ������� ���� ���, ����, ����, ��3�ڿ��� ����, ������ ������ �����Ǹ�, (��)�̶��޾��̾ؾ���
--  �������� ħ�ؿ� �ش�˴ϴ�.
--  (Copyright �� 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_ADMADS_TolDeviceDataPush_Nrp.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2014.03.28
--  Description     : <Generated Class File Description>
--  History         : Created by jungyoul.moon at 2014.03.28
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

        public override void ADMADS_TolDeviceDataPush_Nrp(
            FXmlNode fXmlNodeIn
            )
        {
            FXmlNode fXmlNodeInDvc = null;
            FMonitoringDeviceDataReceivedEventArgs e = null;
            string type = string.Empty;
            string factory = string.Empty;
            string device = string.Empty;

            try
            {
                factory = fXmlNodeIn.get_elemVal(FADMADS_TolDeviceDataPush_In.A_hFactory, FADMADS_TolDeviceDataPush_In.D_hFactory);
                if (factory != m_fAdmCore.fOption.factory)
                {
                    return;
                }

                // --

                fXmlNodeInDvc = fXmlNodeIn.get_elem(FADMADS_TolDeviceDataPush_In.FDevice.E_Device);
                type = fXmlNodeInDvc.get_elemVal(FADMADS_TolDeviceDataPush_In.FDevice.A_MonDataType, FADMADS_TolDeviceDataPush_In.FDevice.D_MonDataType);
                device = fXmlNodeInDvc.get_elemVal(FADMADS_TolDeviceDataPush_In.FDevice.A_Device, FADMADS_TolDeviceDataPush_In.FDevice.D_Device);

                // --

                e = new FMonitoringDeviceDataReceivedEventArgs(
                    (FMonitoringDataType)Enum.Parse(typeof(FMonitoringDataType), type),
                    factory,
                    type,
                    fXmlNodeInDvc
                    );
                // --
                m_fAdmCore.onMonitoringDeviceDataReceived(e);
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                fXmlNodeInDvc = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
