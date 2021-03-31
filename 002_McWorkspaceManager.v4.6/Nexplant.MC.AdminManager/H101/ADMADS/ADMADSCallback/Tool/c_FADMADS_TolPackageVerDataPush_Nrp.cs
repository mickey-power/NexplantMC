/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
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
