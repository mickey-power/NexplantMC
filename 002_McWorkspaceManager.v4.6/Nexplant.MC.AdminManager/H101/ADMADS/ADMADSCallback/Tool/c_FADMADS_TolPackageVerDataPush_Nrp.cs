/*----------------------------------------------------------------------------------------------------------
--  ��� ���α׷��� ���� ���۱��� ������ ���������� (��)�̶��޾��̾ؾ��� ������, (��)�̶��޾��̾ؾ���
--  ��������� ������� ���� ���, ����, ����, ��3�ڿ��� ����, ������ ������ �����Ǹ�, (��)�̶��޾��̾ؾ���
--  �������� ħ�ؿ� �ش�˴ϴ�.
--  (Copyright �� 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_ADMADS_TolPackageVerDataPush_Nrp.cs
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

        public override void ADMADS_TolPackageVerDataPush_Nrp(
            FXmlNode fXmlNodeIn
            )
        {
            FXmlNode fXmlNodeInPkgVer = null;
            FMonitoringPackageVerDataReceivedEventArgs e = null;
            string type = string.Empty;
            string factory = string.Empty;
            string package = string.Empty;
            string packageVer = string.Empty;            

            try
            {
                factory = fXmlNodeIn.get_elemVal(FADMADS_TolPackageVerDataPush_In.A_hFactory, FADMADS_TolPackageVerDataPush_In.D_hFactory);
                if (factory != m_fAdmCore.fOption.factory)
                {
                    return;
                }

                // --
                
                fXmlNodeInPkgVer = fXmlNodeIn.get_elem(FADMADS_TolPackageVerDataPush_In.FPackageVer.E_PackageVer);
                type = fXmlNodeInPkgVer.get_elemVal(FADMADS_TolPackageVerDataPush_In.FPackageVer.A_MonDataType, FADMADS_TolPackageVerDataPush_In.FPackageVer.D_MonDataType);
                package = fXmlNodeInPkgVer.get_elemVal(FADMADS_TolPackageVerDataPush_In.FPackageVer.A_Name, FADMADS_TolPackageVerDataPush_In.FPackageVer.D_Name);
                packageVer = fXmlNodeInPkgVer.get_elemVal(FADMADS_TolPackageVerDataPush_In.FPackageVer.A_Version, FADMADS_TolPackageVerDataPush_In.FPackageVer.D_Version);

                // --

                e = new FMonitoringPackageVerDataReceivedEventArgs(
                    (FMonitoringDataType)Enum.Parse(typeof(FMonitoringDataType), type),
                    factory,
                    package,
                    int.Parse(packageVer),
                    fXmlNodeInPkgVer
                    );
                // --
                m_fAdmCore.onMonitoringPackageVerDataReceived(e);
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                fXmlNodeInPkgVer = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
