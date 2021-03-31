/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_ADMADS_TolEapDataPush_Nrp.cs
--  Creator         : spike.lee
--  Create Date     : 2013.01.18
--  Description     : <Generated Class File Description>
--  History         : Created by spike.lee at 2013.01.18
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

        public override void ADMADS_TolEapDataPush_Nrp(
            FXmlNode fXmlNodeIn
            )
        {
            FXmlNode fXmlNodeInEap = null;
            FMonitoringEapDataReceivedEventArgs e = null;
            string type = string.Empty;
            string factory = string.Empty;
            string eap = string.Empty;            

            try
            {
                factory = fXmlNodeIn.get_elemVal(FADMADS_TolEapDataPush_In.A_hFactory, FADMADS_TolEapDataPush_In.D_hFactory);
                // --
                if (factory != m_fAdmCore.fOption.factory)
                {
                    return;
                }
                
                // --
                
                fXmlNodeInEap = fXmlNodeIn.get_elem(FADMADS_TolEapDataPush_In.FEap.E_Eap);
                type = fXmlNodeInEap.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_MonDataType, FADMADS_TolEapDataPush_In.FEap.D_MonDataType);
                eap = fXmlNodeInEap.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_Name, FADMADS_TolEapDataPush_In.FEap.D_Name);                               

                // --

                e = new FMonitoringEapDataReceivedEventArgs(
                    (FMonitoringDataType)Enum.Parse(typeof(FMonitoringDataType), type),
                    factory,
                    eap,
                    fXmlNodeInEap
                    );
                // --
                m_fAdmCore.onMonitoringEapDataReceived(e);
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                fXmlNodeInEap = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
