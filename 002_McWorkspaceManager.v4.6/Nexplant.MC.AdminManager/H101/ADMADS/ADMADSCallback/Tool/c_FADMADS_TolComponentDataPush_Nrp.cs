/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_ADMADS_TolComponentDataPush_Nrp.cs
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

        public override void ADMADS_TolComponentDataPush_Nrp(
            FXmlNode fXmlNodeIn
            )
        {
            FXmlNode fXmlNodeInCom = null;
            FMonitoringComponentDataReceivedEventArgs e = null;
            string type = string.Empty;
            string factory = string.Empty;
            string component = string.Empty;

            try
            {
                factory = fXmlNodeIn.get_elemVal(FADMADS_TolComponentDataPush_In.A_hFactory, FADMADS_TolComponentDataPush_In.D_hFactory);
                if (factory != m_fAdmCore.fOption.factory)
                {
                    return;
                }

                // --
                
                fXmlNodeInCom = fXmlNodeIn.get_elem(FADMADS_TolComponentDataPush_In.FComponent.E_Component);
                type = fXmlNodeInCom.get_elemVal(FADMADS_TolComponentDataPush_In.FComponent.A_MonDataType, FADMADS_TolComponentDataPush_In.FComponent.D_MonDataType);
                component = fXmlNodeInCom.get_elemVal(FADMADS_TolComponentDataPush_In.FComponent.A_Name, FADMADS_TolComponentDataPush_In.FComponent.D_Name);

                // --

                e = new FMonitoringComponentDataReceivedEventArgs(
                    (FMonitoringDataType)Enum.Parse(typeof(FMonitoringDataType), type),
                    factory,
                    component,
                    fXmlNodeInCom
                    );
                // --
                m_fAdmCore.onMonitoringComponentDataReceived(e);
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                fXmlNodeInCom = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
