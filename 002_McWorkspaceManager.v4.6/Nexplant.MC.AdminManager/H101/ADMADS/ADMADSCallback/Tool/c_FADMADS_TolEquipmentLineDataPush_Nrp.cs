/*----------------------------------------------------------------------------------------------------------
--  ��� ���α׷��� ���� ���۱��� ������ ���������� (��)�̶��޾��̾ؾ��� ������, (��)�̶��޾��̾ؾ���
--  ��������� ������� ���� ���, ����, ����, ��3�ڿ��� ����, ������ ������ �����Ǹ�, (��)�̶��޾��̾ؾ���
--  �������� ħ�ؿ� �ش�˴ϴ�.
--  (Copyright �� 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_ADMADS_TolEquipmentLineDataPush_Nrp.cs
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

        public override void ADMADS_TolEquipmentLineDataPush_Nrp(
            FXmlNode fXmlNodeIn
            )
        {
            FXmlNode fXmlNodeInLin = null;
            FMonitoringEquipmentLineDataReceivedEventArgs e = null;
            string type = string.Empty;
            string factory = string.Empty;
            string equipmentLine = string.Empty;

            try
            {
                factory = fXmlNodeIn.get_elemVal(FADMADS_TolEquipmentLineDataPush_In.A_hFactory, FADMADS_TolEquipmentLineDataPush_In.D_hFactory);
                if (factory != m_fAdmCore.fOption.factory)
                {
                    return;
                }

                // --
                
                fXmlNodeInLin = fXmlNodeIn.get_elem(FADMADS_TolEquipmentLineDataPush_In.FEquipmentLine.E_EquipmentLine);
                type = fXmlNodeInLin.get_elemVal(FADMADS_TolEquipmentLineDataPush_In.FEquipmentLine.A_MonDataType, FADMADS_TolEquipmentLineDataPush_In.FEquipmentLine.D_MonDataType);
                equipmentLine = fXmlNodeInLin.get_elemVal(FADMADS_TolEquipmentLineDataPush_In.FEquipmentLine.A_Name, FADMADS_TolEquipmentLineDataPush_In.FEquipmentLine.D_Name);

                // --

                e = new FMonitoringEquipmentLineDataReceivedEventArgs(
                    (FMonitoringDataType)Enum.Parse(typeof(FMonitoringDataType), type),
                    factory,
                    equipmentLine,
                    fXmlNodeInLin
                    );
                // --
                m_fAdmCore.onMonitoringEquipmentLineDataReceived(e);
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                fXmlNodeInLin = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
