/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : s_FAdminAgent.cs
--  Creator         : byungyun.jeon
--  Create Date     : 2012.03.27
--  Description     : FAMate Admin Agent Class 
--  History         : Created by byungyun.jeon at 2012.03.27
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.ServiceProcess;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.AdminAgent
{
    [RunInstaller(true)]
    public partial class FAdminAgentInstaller : System.Configuration.Install.Installer
    {

        //------------------------------------------------------------------------------------------------------------------------

        public FAdminAgentInstaller(
            )
        {
            ServiceProcessInstaller process = null;
            ServiceInstaller adminAgent = null;

            try
            {
                InitializeComponent();

                // --

                process = new ServiceProcessInstaller();
                process.Account = ServiceAccount.LocalSystem;
                // --
                adminAgent = new ServiceInstaller();
                adminAgent.StartType = ServiceStartMode.Manual;
                adminAgent.ServiceName = FConstants.ServiceName;
                adminAgent.DisplayName = "Nexplant MC Admin Agent";
                adminAgent.Description = "Miracom Nexplant MC Admin Agent";
                // --
                Installers.Add(process);
                Installers.Add(adminAgent);
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

        public ServiceController getService(
            )
        {
            try
            {
                return ServiceController.GetServices().Where(s => s.ServiceName == FConstants.ServiceName).FirstOrDefault();
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override void OnBeforeInstall(
            IDictionary savedState
            )
        {
            ServiceController svCtrl = null;

            try
            {
                base.OnBeforeInstall(savedState);

                // --

                svCtrl = getService();
                if (svCtrl != null && svCtrl.Status != ServiceControllerStatus.Stopped)
                {
                    svCtrl.Stop();
                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                svCtrl = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override void OnAfterInstall(
            IDictionary savedState
            )
        {
            ServiceController svCtrl = null;

            try
            {
                base.OnAfterInstall(savedState);

                // --
                
                svCtrl = getService();
                if (svCtrl != null && svCtrl.Status != ServiceControllerStatus.Running)
                {
                    svCtrl.Start();
                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                svCtrl = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override void OnBeforeUninstall(
            IDictionary savedState
            )
        {
            ServiceController svCtrl = null;

            try
            {
                base.OnBeforeUninstall(savedState);

                // --
                
                svCtrl = getService();
                if (svCtrl != null && svCtrl.Status != ServiceControllerStatus.Stopped)
                {
                    svCtrl.Stop();
                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                svCtrl = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
