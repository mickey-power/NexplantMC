/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_ADMADS_TolEapIssueEventRefresh_Nrp.cs
--  Creator         : spike.lee
--  Create Date     : 2017.07.14
--  Description     : FAmate Admin Manager EAP Issue Event Refresh Function
--  History         : Created by spike.lee at 2017.07.14
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

        public override void ADMADS_TolEapIssueEventRefresh_Nrp(
            FXmlNode fXmlNodeIn
            )
        {
            string factory = string.Empty;

            try
            {
                factory = fXmlNodeIn.get_elemVal(FADMADS_TolEapIssueEventRefresh_In.A_hFactory, FADMADS_TolEapIssueEventRefresh_In.D_hFactory);
                if (factory != m_fAdmCore.fOption.factory)
                {
                    return;
                }
                // --
                m_fAdmCore.onEapIssueEventRefresh(new EventArgs());
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
