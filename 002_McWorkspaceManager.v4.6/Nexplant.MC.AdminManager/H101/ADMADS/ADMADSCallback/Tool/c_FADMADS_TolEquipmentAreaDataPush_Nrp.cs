/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_ADMADS_TolEquipmentAreaDataPush_Nrp.cs
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

        public override void ADMADS_TolEquipmentAreaDataPush_Nrp(
            FXmlNode fXmlNodeIn
            )
        {
            FXmlNode fXmlNodeInAre = null;
            FMonitoringEquipmentAreaDataReceivedEventArgs e = null;
            string type = string.Empty;
            string factory = string.Empty;
            string equipmentArea = string.Empty;

            try
            {
                factory = fXmlNodeIn.get_elemVal(FADMADS_TolEquipmentAreaDataPush_In.A_hFactory, FADMADS_TolEquipmentAreaDataPush_In.D_hFactory);
                if (factory != m_fAdmCore.fOption.factory)
                {
                    return;
                }

                // --
                
                fXmlNodeInAre = fXmlNodeIn.get_elem(FADMADS_TolEquipmentAreaDataPush_In.FEquipmentArea.E_EquipmentArea);
                type = fXmlNodeInAre.get_elemVal(FADMADS_TolEquipmentAreaDataPush_In.FEquipmentArea.A_MonDataType, FADMADS_TolEquipmentAreaDataPush_In.FEquipmentArea.D_MonDataType);
                equipmentArea = fXmlNodeInAre.get_elemVal(FADMADS_TolEquipmentAreaDataPush_In.FEquipmentArea.A_Name, FADMADS_TolEquipmentAreaDataPush_In.FEquipmentArea.D_Name);

                // --

                e = new FMonitoringEquipmentAreaDataReceivedEventArgs(
                    (FMonitoringDataType)Enum.Parse(typeof(FMonitoringDataType), type),
                    factory,
                    equipmentArea,
                    fXmlNodeInAre
                    );
                // --
                m_fAdmCore.onMonitoringEquipmentAreaDataReceived(e);
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                fXmlNodeInAre = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
