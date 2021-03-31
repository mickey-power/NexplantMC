/*----------------------------------------------------------------------------------------------------------
--  ��� ���α׷��� ���� ���۱��� ������ ���������� (��)�̶��޾��̾ؾ��� ������, (��)�̶��޾��̾ؾ���
--  ��������� ������� ���� ���, ����, ����, ��3�ڿ��� ����, ������ ������ �����Ǹ�, (��)�̶��޾��̾ؾ���
--  �������� ħ�ؿ� �ش�˴ϴ�.
--  (Copyright �� 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_ADMADS_TolPackageDataPush_Nrp.cs
--  Creator         : spike.lee
--  Create Date     : 2013.01.16
--  Description     : <Generated Class File Description>
--  History         : Created by spike.lee at 2013.01.16
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

        public override void ADMADS_TolPackageDataPush_Nrp(
            FXmlNode fXmlNodeIn
            )
        {

            FXmlNode fXmlNodeInPkg = null;
            FMonitoringPackageDataReceivedEventArgs e = null;
            string type = string.Empty;
            string factory = string.Empty;
            string package = string.Empty;

            try
            {
                factory = fXmlNodeIn.get_elemVal(FADMADS_TolPackageDataPush_In.A_hFactory, FADMADS_TolPackageDataPush_In.D_hFactory);
                if (factory != m_fAdmCore.fOption.factory)
                {
                    return;
                }

                // --
                
                fXmlNodeInPkg = fXmlNodeIn.get_elem(FADMADS_TolPackageDataPush_In.FPackage.E_Package);
                type = fXmlNodeInPkg.get_elemVal(FADMADS_TolPackageDataPush_In.FPackage.A_MonDataType, FADMADS_TolPackageDataPush_In.FPackage.D_MonDataType);
                package = fXmlNodeInPkg.get_elemVal(FADMADS_TolPackageDataPush_In.FPackage.A_Name, FADMADS_TolPackageDataPush_In.FPackage.D_Name);

                // --

                e = new FMonitoringPackageDataReceivedEventArgs(
                    (FMonitoringDataType)Enum.Parse(typeof(FMonitoringDataType), type),
                    factory,
                    package,
                    fXmlNodeInPkg
                    );
                // --
                m_fAdmCore.onMonitoringPackageDataReceived(e);
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                fXmlNodeInPkg = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
