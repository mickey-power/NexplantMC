/*----------------------------------------------------------------------------------------------------------
--  ��� ���α׷��� ���� ���۱��� ������ ���������� (��)�̶��޾��̾ؾ��� ������, (��)�̶��޾��̾ؾ���
--  ��������� ������� ���� ���, ����, ����, ��3�ڿ��� ����, ������ ������ �����Ǹ�, (��)�̶��޾��̾ؾ���
--  �������� ħ�ؿ� �ش�˴ϴ�.
--  (Copyright �� 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_ADMADS_TolSecs1ToHsmsConverterDisconnectDataPush_Nrp.cs
--  Creator         : spike.lee
--  Create Date     : 2017.05.11
--  Description     : FAmate Admin Manager SECS1 To HSMS Convertrer Disconnect Data Push Function
--  History         : Created by spike.lee at 2017.05.11
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

        public override void ADMADS_TolSecs1ToHsmsConverterDisconnectDataPush_Nrp(
            FXmlNode fXmlNodeIn
            )
        {
            FXmlNode fXmlNodeInCvt = null;
            FMonitoringSecs1ToHsmsConverterDisconnectDataReceivedEventArgs e = null;
            string type = string.Empty;
            string factory = string.Empty;
            string converter = string.Empty;

            try
            {
                factory = fXmlNodeIn.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDisconnectDataPush_In.A_hFactory, FADMADS_TolSecs1ToHsmsConverterDisconnectDataPush_In.D_hFactory);
                if (factory != m_fAdmCore.fOption.factory)
                {
                    return;
                }

                // --

                fXmlNodeInCvt = fXmlNodeIn.get_elem(FADMADS_TolSecs1ToHsmsConverterDisconnectDataPush_In.FSecs1ToHsmsConverterDisconnect.E_Secs1ToHsmsConverterDisconnect);
                type = fXmlNodeInCvt.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDisconnectDataPush_In.FSecs1ToHsmsConverterDisconnect.A_MonDataType, FADMADS_TolSecs1ToHsmsConverterDisconnectDataPush_In.FSecs1ToHsmsConverterDisconnect.D_MonDataType);
                converter = fXmlNodeInCvt.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDisconnectDataPush_In.FSecs1ToHsmsConverterDisconnect.A_Converter, FADMADS_TolSecs1ToHsmsConverterDisconnectDataPush_In.FSecs1ToHsmsConverterDisconnect.D_Converter);

                // --

                e = new FMonitoringSecs1ToHsmsConverterDisconnectDataReceivedEventArgs(
                    (FMonitoringDataType)Enum.Parse(typeof(FMonitoringDataType), type),
                    factory,
                    converter,
                    fXmlNodeInCvt
                    );
                // --
                m_fAdmCore.onMonitoringSecs1ToHsmsConverterDisconnectDataReceived(e);
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                fXmlNodeInCvt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
