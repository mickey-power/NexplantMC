/*----------------------------------------------------------------------------------------------------------
--  ��� ���α׷��� ���� ���۱��� ������ ���������� (��)�̶��޾��̾ؾ��� ������, (��)�̶��޾��̾ؾ���
--  ��������� ������� ���� ���, ����, ����, ��3�ڿ��� ����, ������ ������ �����Ǹ�, (��)�̶��޾��̾ؾ���
--  �������� ħ�ؿ� �ش�˴ϴ�.
--  (Copyright �� 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_ADMADS_TolModelDataPush_Nrp.cs
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

        public override void ADMADS_TolModelDataPush_Nrp(
            FXmlNode fXmlNodeIn
            )
        {
            FXmlNode fXmlNodeInMdl = null;
            FMonitoringModelDataReceivedEventArgs e = null;
            string type = string.Empty;
            string factory = string.Empty;
            string model = string.Empty;

            try
            {
                factory = fXmlNodeIn.get_elemVal(FADMADS_TolModelDataPush_In.A_hFactory, FADMADS_TolModelDataPush_In.D_hFactory);
                if (factory != m_fAdmCore.fOption.factory)
                {
                    return;
                }

                // --
                
                fXmlNodeInMdl = fXmlNodeIn.get_elem(FADMADS_TolModelDataPush_In.FModel.E_Model);
                type = fXmlNodeInMdl.get_elemVal(FADMADS_TolModelDataPush_In.FModel.A_MonDataType, FADMADS_TolModelDataPush_In.FModel.D_MonDataType);
                model = fXmlNodeInMdl.get_elemVal(FADMADS_TolModelDataPush_In.FModel.A_Name, FADMADS_TolModelDataPush_In.FModel.D_Name);

                // --

                e = new FMonitoringModelDataReceivedEventArgs(
                    (FMonitoringDataType)Enum.Parse(typeof(FMonitoringDataType), type),
                    factory,
                    model,
                    fXmlNodeInMdl
                    );
                // --
                m_fAdmCore.onMonitoringModelDataReceived(e);
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                fXmlNodeInMdl = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
