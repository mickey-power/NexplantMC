/*----------------------------------------------------------------------------------------------------------
--  ��� ���α׷��� ���� ���۱��� ������ ���������� (��)�̶��޾��̾ؾ��� ������, (��)�̶��޾��̾ؾ���
--  ��������� ������� ���� ���, ����, ����, ��3�ڿ��� ����, ������ ������ �����Ǹ�, (��)�̶��޾��̾ؾ���
--  �������� ħ�ؿ� �ش�˴ϴ�.
--  (Copyright �� 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_ADMADS_TolEquipmentDataPush_Nrp.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2013.07.16
--  Description     : <Generated Class File Description>
--  History         : Created by jungyoul.moon at 2013.07.16
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

        public override void ADMADS_TolEquipmentDataPush_Nrp(
            FXmlNode fXmlNodeIn
            )
        {
            FXmlNode fXmlNodeInEqp = null;
            FMonitoringEquipmentDataReceivedEventArgs e = null;
            string type = string.Empty;
            string factory = string.Empty;
            string equipment = string.Empty;

            try
            {
                factory = fXmlNodeIn.get_elemVal(FADMADS_TolEquipmentDataPush_In.A_hFactory, FADMADS_TolEquipmentDataPush_In.D_hFactory);
                if (factory != m_fAdmCore.fOption.factory)
                {
                    return;
                }

                // --
                
                fXmlNodeInEqp = fXmlNodeIn.get_elem(FADMADS_TolEquipmentDataPush_In.FEquipment.E_Equipment);
                type = fXmlNodeInEqp.get_elemVal(FADMADS_TolEquipmentDataPush_In.FEquipment.A_MonDataType, FADMADS_TolEquipmentDataPush_In.FEquipment.D_MonDataType);
                equipment = fXmlNodeInEqp.get_elemVal(FADMADS_TolEquipmentDataPush_In.FEquipment.A_Name, FADMADS_TolEquipmentDataPush_In.FEquipment.D_Name);

                // --

                e = new FMonitoringEquipmentDataReceivedEventArgs(
                    (FMonitoringDataType)Enum.Parse(typeof(FMonitoringDataType), type),
                    factory,
                    equipment,
                    fXmlNodeInEqp
                    );
                // --
                m_fAdmCore.onMonitoringEquipmentDataReceived(e);
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                fXmlNodeInEqp = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
