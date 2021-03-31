/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_ADMADS_TolEquipmentTypeDataPush_Nrp.cs
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

        public override void ADMADS_TolEquipmentTypeDataPush_Nrp(
            FXmlNode fXmlNodeIn
            )
        {
            FXmlNode fXmlNodeInTyp = null;
            FMonitoringEquipmentTypeDataReceivedEventArgs e = null;
            string type = string.Empty;
            string factory = string.Empty;
            string equipmentType = string.Empty;

            try
            {
                factory = fXmlNodeIn.get_elemVal(FADMADS_TolEquipmentTypeDataPush_In.A_hFactory, FADMADS_TolEquipmentTypeDataPush_In.D_hFactory);
                if (factory != m_fAdmCore.fOption.factory)
                {
                    return;
                }

                // --
                
                fXmlNodeInTyp = fXmlNodeIn.get_elem(FADMADS_TolEquipmentTypeDataPush_In.FEquipmentType.E_EquipmentType);
                type = fXmlNodeInTyp.get_elemVal(FADMADS_TolEquipmentTypeDataPush_In.FEquipmentType.A_MonDataType, FADMADS_TolEquipmentTypeDataPush_In.FEquipmentType.D_MonDataType);
                equipmentType = fXmlNodeInTyp.get_elemVal(FADMADS_TolEquipmentTypeDataPush_In.FEquipmentType.A_Name, FADMADS_TolEquipmentTypeDataPush_In.FEquipmentType.D_Name);

                // --

                e = new FMonitoringEquipmentTypeDataReceivedEventArgs(
                    (FMonitoringDataType)Enum.Parse(typeof(FMonitoringDataType), type),
                    factory,
                    equipmentType,
                    fXmlNodeInTyp
                    );
                // --
                m_fAdmCore.onMonitoringEquipmentTypeDataReceived(e);
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                fXmlNodeInTyp = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
