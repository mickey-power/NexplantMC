/*----------------------------------------------------------------------------------------------------------
--  ��� ���α׷��� ���� ���۱��� ������ ���������� (��)�̶��޾��̾ؾ��� ������, (��)�̶��޾��̾ؾ���
--  ��������� ������� ���� ���, ����, ����, ��3�ڿ��� ����, ������ ������ �����Ǹ�, (��)�̶��޾��̾ؾ���
--  �������� ħ�ؿ� �ش�˴ϴ�.
--  (Copyright �� 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_ADMADS_TolSecs1ToHsmsConverterDataPush_Nrp.cs
--  Creator         : spike.lee
--  Create Date     : 2017.05.11
--  Description     : FAmate Admin Manager SECS1 To HSMS Convertrer Data Push Function
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

        public override void ADMADS_TolSecs1ToHsmsConverterDataPush_Nrp(
            FXmlNode fXmlNodeIn
            )
        {
            FXmlNode fXmlNodeInCvt = null;
            FMonitoringSecs1ToHsmsConverterDataReceivedEventArgs e = null;
            string type = string.Empty;
            string factory = string.Empty;
            string converter = string.Empty;

            try
            {
                factory = fXmlNodeIn.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.A_hFactory, FADMADS_TolSecs1ToHsmsConverterDataPush_In.D_hFactory);
                if (factory != m_fAdmCore.fOption.factory)
                {
                    return;
                }

                // --

                fXmlNodeInCvt = fXmlNodeIn.get_elem(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.E_Secs1ToHsmsConverter);
                type = fXmlNodeInCvt.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_MonDataType, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_MonDataType);
                converter = fXmlNodeInCvt.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_Converter, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_Converter);

                // --

                e = new FMonitoringSecs1ToHsmsConverterDataReceivedEventArgs(
                    (FMonitoringDataType)Enum.Parse(typeof(FMonitoringDataType), type),
                    factory,
                    converter,
                    fXmlNodeInCvt
                    );
                // --
                m_fAdmCore.onMonitoringSecs1ToHsmsConverterDataReceived(e);
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
