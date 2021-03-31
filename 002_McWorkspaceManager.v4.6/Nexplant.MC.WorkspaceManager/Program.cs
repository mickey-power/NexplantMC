/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : Program.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.28
--  Description     : FAMate Workspace Manager Program (주 진입점) Class 
--  History         : Created by spike.lee at 2010.12.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Deployment.Application;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.WorkspaceManager
{
    static class Program
    {

        //------------------------------------------------------------------------------------------------------------------------
        
        #region Methods

        [STAThread]
        static void Main(
            string[] args
            )
        {
            Process currentProcess = null;
            Process[] processes = null;
            IntPtr hFindWindow = IntPtr.Zero;
            FNativeAPIs.COPYDATASTRUCT dataArgs;
            FWsmCore fWsmCore = null;
            string startTime = string.Empty;
            bool isFirstProcess = false;
            string windowTitle = string.Empty;       
            // --
            string runtimePath = string.Empty;
            string[] files = null;
            string fileName = string.Empty;
            string zipFile = string.Empty;

            try
            {
                if (ApplicationDeployment.IsNetworkDeployed)
                {
#if (!DEBUG)
                    // ***
                    // Nexplant.MC.WorkspaceManager.v4.6.zip 파일이 있을 경우 Nexplant.MC.WorkspaceStarter로 실행 요청
                    // ***
                    zipFile = Path.Combine(Application.StartupPath, "Nexplant.MC.WorkspaceManager.v4.6.zip");
                    // --
                    if (File.Exists(zipFile))
                    {
                        Process.Start(Path.Combine(Application.StartupPath, "Nexplant.MC.WorkspaceStarter.exe"), ApplicationDeployment.CurrentDeployment.UpdateLocation.AbsoluteUri);
                        return;
                    }
#endif

                    // --

                    args = AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData;
                    if (args != null)
                    {
                        for (int i = 0; i < args.Length; i++)
                        {
                            if (args[i].StartsWith("file:///"))
                            {
                                args[i] = new Uri(args[i]).LocalPath;
                            }
                        }
                    }
                }

                // ***
                // 파일 열기 Option으로 WorkspaceManager를 실행할 경우, 기존에 실행중인 WorkspaceManager로 연다
                // 파일 열기 Option이 아닌 경우는 새로운 WorkspaceManager를 실행한다.
                // (WorksapceManager를 여러개 실행 할 수 있도록 지원)
                // ***
                if (args != null && args.Length > 0)
                {
                    // ***
                    // 실행중인 WorksapceManager 검색
                    // ***
                    currentProcess = Process.GetCurrentProcess();                    
                    processes = Process.GetProcessesByName(currentProcess.ProcessName);

                    // --

                    if (processes.Length > 1)
                    {
                        startTime = currentProcess.StartTime.ToString("yyyyMMddHHmmssfff");

                        // --

                        // ***
                        // 첫번째 Process인지 검사
                        // ***
                        isFirstProcess = true;
                        foreach (Process p in processes)
                        {
                            // MessageBox.Show("CurrentProcess=" + startTime + ", OtherProcess=" + p.StartTime.ToString("yyyyMMddHHmmssfff"));

                            if (startTime.CompareTo(p.StartTime.ToString("yyyyMMddHHmmssfff")) > 0)
                            {
                                isFirstProcess = false;
                                break;
                            }
                        }

                        // --

                        // ***
                        // 첫번째 Process가 아닐 경우, 첫번째 Process가 완료될때 까지 대기
                        // ***
                        if (!isFirstProcess)
                        {
                            while (windowTitle == string.Empty)
                            {
                                processes = Process.GetProcessesByName(currentProcess.ProcessName);
                                // --
                                foreach (Process p in processes)
                                {
                                    if (p.MainWindowTitle != string.Empty)
                                    {
                                        windowTitle = p.MainWindowTitle;
                                        break;
                                    }
                                }

                                // --

                                Thread.Sleep(10);
                            }

                            // --

                            // ***
                            // 실행중인 WorkspaceManager가 검색될 경우, 파일 열기 Option의 파일이름을 실행중인 WorkspaceManager에 전달한다.
                            // ***
                            hFindWindow = FNativeAPIs.FindWindow(null, windowTitle);
                            if (hFindWindow.ToInt32() > 0)
                            {
                                dataArgs = new FNativeAPIs.COPYDATASTRUCT();
                                // --
                                foreach (string f in args)
                                {
                                    dataArgs.cbData = (uint)f.Length * sizeof(char);
                                    dataArgs.lpData = f;
                                    FNativeAPIs.SendMessage(hFindWindow, (uint)FNativeAPIs.FWinMsgs.WM_COPYDATA, IntPtr.Zero, ref dataArgs);
                                }
                                return;
                            }
                        }   // isFistProcess end                   
                    }
                }

                // --          

                // ***
                // 2016.05.20 by spike.lee
                // 플랫폼이 Any인 경우 사용하세요.
                // ***
                //if (Environment.Is64BitOperatingSystem)
                //{
                //    runtimePath = Application.StartupPath + "\\RunTimeDll\\x64";
                //}
                //else
                //{
                //    runtimePath = Application.StartupPath + "\\RunTimeDll\\x86";
                //}

                // ***
                // 2016.05.20 by spike.lee
                // 플랫폼이 x86인 경우 사용하세요.
                // ***
                runtimePath = Application.StartupPath + "\\RunTimeDll\\x86";

                // --
                
                files = new string[] { "msvcp100.dll", "msvcp100d.dll", "msvcr100.dll", "msvcr100d.dll" };
                // --
                foreach (string f in files)
                {
                    fileName = f;
                    if (!File.Exists(Application.StartupPath + "\\" + fileName))
                    {
                        File.Copy(runtimePath + "\\" + fileName, Application.StartupPath + "\\" + fileName);
                    }
                }

                // --
                
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);   
                
                // --

                fWsmCore = new FWsmCore(args);
                Application.Run(fWsmCore.fWsmContainer);                    

                // --

                if (fWsmCore != null)
                {
                    fWsmCore.Dispose();
                    fWsmCore = null;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, null);
            }
            finally
            {
                if (fWsmCore != null)
                {
                    fWsmCore.Dispose();
                    fWsmCore = null;
                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
