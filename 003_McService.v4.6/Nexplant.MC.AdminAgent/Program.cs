/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : Program.cs
--  Creator         : byungyun.jeon
--  Create Date     : 2012.04.09
--  Description     : FAMate Admin Agent Program (주 진입점) Class 
--  History         : Created by byungyun.jeon 2012.04.09
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;
using System.ServiceProcess;

namespace Nexplant.MC.AdminAgent
{
    static class Program
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Comments
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        #endregion
        static void Main()
        {
            FAdminAgent fAgentService = null;

            try
            {
                ServiceBase[] ServicesToRun;
                // --
                fAgentService = new FAdminAgent();
                fAgentService.ServiceName = FConstants.ServiceName;
                fAgentService.AutoLog = true;
                // --
                ServicesToRun = new ServiceBase[]
                {
                    fAgentService
                };
                ServiceBase.Run(ServicesToRun);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
