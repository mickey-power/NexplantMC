/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_ADMADS_TolPackageDataPush_Nrp.cs
--  Creator         : spike.lee
--  Create Date     : 2013.01.14
--  Description     : <Generated Class File Description>
--  History         : Created by spike.lee at 2013.01.14
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

        public override void ADMADS_TolServerDataPush_Nrp(
            FXmlNode fXmlNodeIn
            )
        {
            FXmlNode fXmlNodeInSvr = null;
            FMonitoringServerDataReceivedEventArgs e = null;
            string type = string.Empty;
            string factory = string.Empty;
            string server = string.Empty;            

            try
            {
                factory = fXmlNodeIn.get_elemVal(FADMADS_TolServerDataPush_In.A_hFactory, FADMADS_TolServerDataPush_In.D_hFactory);
                if (factory != m_fAdmCore.fOption.factory)
                {
                    return;
                }

                // --
                
                fXmlNodeInSvr = fXmlNodeIn.get_elem(FADMADS_TolServerDataPush_In.FServer.E_Server);
                type = fXmlNodeInSvr.get_elemVal(FADMADS_TolServerDataPush_In.FServer.A_MonDataType, FADMADS_TolServerDataPush_In.FServer.D_MonDataType);
                server = fXmlNodeInSvr.get_elemVal(FADMADS_TolServerDataPush_In.FServer.A_Name, FADMADS_TolServerDataPush_In.FServer.D_Name);

                // --

                e = new FMonitoringServerDataReceivedEventArgs(
                    (FMonitoringDataType)Enum.Parse(typeof(FMonitoringDataType), type),
                    factory,
                    server,
                    fXmlNodeInSvr
                    );
                // --
                m_fAdmCore.onMonitoringServerDataReceived(e);
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                fXmlNodeInSvr = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
