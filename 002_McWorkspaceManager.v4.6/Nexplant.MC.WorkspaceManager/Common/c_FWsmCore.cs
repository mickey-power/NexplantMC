/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FWsmCore.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.27
--  Description     : FAMate Workspace Manager Core Class 
--  History         : Created by spike.lee at 2010.12.27
----------------------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.WorkspaceInterface;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.WorkspaceManager
{
    public class FWsmCore : FIWsmCore, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        // private const string LicenseFileName = "license_test.lic";
        private const string LicenseFileName = "license.lic";

        //------------------------------------------------------------------------------------------------------------------------

        public event FMainStatusBarChangedEventHandler MainStatusBarChanged = null;

        // --

        private bool m_disposed = false;
        // --        
        private string m_appPath = string.Empty;
        private string m_licenseFileName = string.Empty;
        private string m_usrPath = string.Empty;
        private string m_hostDriverPath = string.Empty;
        private string m_tempPath = string.Empty;
        private string m_optionPath = string.Empty;
        private FOption m_fOption = null;
        private FUIWizard m_fUIWizard = null;
        private FWsmContainer m_fWsmContainer = null;
        private FH101 m_fH101 = null;
        private FLic2Info m_fLicInfo = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FWsmCore(
            string[] openFileNames
            )           
        {
            init(openFileNames);
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FWsmCore(
           )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    term();
                }                
                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region IDisposable 멤버

        public void Dispose(
            )
        {
            myDispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public string appPath
        {
            get
            {
                try
                {
                    return m_appPath;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string licenseFileName
        {
            get
            {
                try
                {
                    return m_licenseFileName;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string usrPath
        {
            get
            {
                try
                {
                    return m_usrPath;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;


            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string hostDriverPath
        {
            get
            {
                try
                {
                    if (!Directory.Exists(m_hostDriverPath))
                    {
                        Directory.CreateDirectory(m_hostDriverPath);
                    }
                    // --
                    return m_hostDriverPath;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string tempPath
        {
            get
            {
                try
                {
                    if (!Directory.Exists(m_tempPath))
                    {
                        Directory.CreateDirectory(m_tempPath);
                    }
                    // --
                    return m_tempPath;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string optionPath
        {
            get
            {
                try
                {
                    return m_optionPath;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOption fOption
        {
            get
            {
                try
                {
                    return m_fOption;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIWsmOption fWsmOption
        {
            get
            {
                try
                {
                    return m_fOption;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FUIWizard fUIWizard
        {
            get
            {
                try
                {
                    return m_fUIWizard;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FBaseRibbonMdiForm fWsmContainer
        {
            get
            {
                try
                {
                    return m_fWsmContainer;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FH101 fH101
        {
            get
            {
                try
                {
                    return m_fH101;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FLic2Info fLicInfo
        {
            get
            {
                try
                {
                    return m_fLicInfo;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            string[] openFileNames
            )
        {
            // ***
            // New License File 적용
            // *** 

            FLic2License fLic = null;

            try
            {
                m_appPath = Application.StartupPath;
                m_usrPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Miracom\\Nexplant MC Workspace Manager v4.6";
                m_hostDriverPath = Path.Combine(m_usrPath, "HostDriver");
                m_tempPath = Path.Combine(m_usrPath, "temp");
                m_optionPath = Path.Combine(m_usrPath, "config");
                
                // --

                // ***
                // 2017.08.29 by spike.lee
                // 라이센스 검사 기능 추가
                // ***
                m_licenseFileName = m_appPath + "\\license\\" + LicenseFileName;
                // --
                fLic = new FLic2License();
                m_fLicInfo = fLic.validate(m_licenseFileName);

                // --

                m_fOption = new FOption(this);                                
                
                // --                
                
#if (DEBUG)
                // ***
                // HostDriver Copy (App Path -> User Path)
                // ***
                copyHostDriver();
#endif

                // -- 

                // ***
                // Debug Log 설정
                // ***
                setDebugLog();                
                
                // --                
                
                // ***
                // UIWizard 생성
                // ***
                m_fUIWizard = new FUIWizard(m_appPath + "\\LanguageFile\\NexplantMcLanguageFile.xml", m_fOption.language.ToString(), m_fOption.fontName);                
                
                // --                

                // ***
                // WorkspaceManager Main Container 생성
                // ***
                m_fWsmContainer = new FWsmContainer(this, openFileNames);                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fLic != null)
                {
                    fLic.Dispose();
                    fLic = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void term(
            )
        {
            // ***
            // New License File 적용
            // *** 

            try
            {               
                if (m_fWsmContainer != null)
                {
                    m_fWsmContainer.Dispose();
                    m_fWsmContainer = null;
                }

                if (m_fUIWizard != null)
                {
                    m_fUIWizard.Dispose();
                    m_fUIWizard = null;
                }

                if (m_fOption != null)
                {
                    m_fOption.save();
                    // --
                    m_fOption.Dispose();
                    m_fOption = null;
                }

                if (m_fLicInfo != null)
                {
                    m_fLicInfo.Dispose();
                    m_fLicInfo = null;
                }

                // --
                
                deleteTempDir(m_tempPath);
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

        public void initH101(
            )
        {
            try
            {
                termH101();

                // --

                m_fH101 = new FH101(
                    FConstants.StationSessionID,
                    fOption.stationConnectString,
                    FConstants.StationVersion,
                    fOption.stationTimeout,
                    FConstants.GuaranteedTimeout,
                    true,
                    false
                    );
                m_fH101.init(FH101StationMode.Inter);
                // --
                FWSMADSCaster.wsmadsChannel = m_fOption.castChannelId;
                FWSMADSCaster.wsmadsTtl = m_fOption.stationTimeout;
                // --
                m_fH101.registerDispatcher("WSMADS", new FWSMADSCallback(this));
                // --
                m_fH101.tune(m_fOption.tuneChannelId + "/" + m_fOption.factory, true, false);
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

        public void termH101(
            )
        {
            try
            {
                if (m_fH101 == null)
                {
                    return;
                }

                // --

                if (m_fH101.started)
                {
                    m_fH101.untune(m_fOption.tuneChannelId + "/" + m_fOption.factory, true, false);
                }
                // --
                m_fH101.term();
                m_fH101.Dispose();
                m_fH101 = null;
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

        public void setDebugLog(
            )
        {
            try
            {
                FDebug.logFilePath = Path.Combine(m_usrPath, "log");
                FDebug.logFileSuffix = m_fOption.debugLogFileSubfix;
                FDebug.logFileKeepingPeriod = m_fOption.debugLogFileKeepingPeriod;
                FDebug.logFileAutoDeleteEnabled = true;
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

        private void copyHostDriver(
            )
        {
            string appDirPath = string.Empty;            
            string usrFilePath = string.Empty;

            try
            {
                if (!Directory.Exists(m_hostDriverPath))
                {
                    Directory.CreateDirectory(m_hostDriverPath);
                }

                // -- 

                appDirPath = Path.Combine(m_appPath, "HostDriver");
                foreach (string appFilePath in Directory.GetFiles(appDirPath))
                {
                    usrFilePath = Path.Combine(m_hostDriverPath, Path.GetFileName(appFilePath));
                    File.Copy(appFilePath, usrFilePath, true);
                }
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
            
        private void deleteTempDir(
            string path
            )
        {
            try
            {
                if (Directory.Exists(path))
                {
                    foreach (string directory in Directory.GetDirectories(path))
                    {
                        Directory.Delete(directory, true);
                    }

                    // --
                    
                    foreach (string file in Directory.GetFiles(path))
                    {
                        if ((File.GetAttributes(file) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                        {
                            File.SetAttributes(file, FileAttributes.Normal);
                        }
                        File.Delete(file);
                    }
                }
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

        public void onMainStatusBarChanged(
            bool enabled
            )
        {
            string contents = string.Empty;
            string factory = string.Empty;
            string userGroup = string.Empty;
            string user = string.Empty;
            string version = string.Empty;

            try
            {
                if (enabled)
                {
                    contents = FConstants.ApplicationName;
                    // --
                    if (fOption.isLogIn)
                    {
                        contents += " - [" + fOption.site + "]";

                        // --

                        factory = fOption.factory;
                        userGroup = fOption.userGroup;
                        user = fOption.user;
                    }
                    // --
                    if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                    {
                        version = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
                    }
                    else
                    {
                        version = Application.ProductVersion;
                    }
                }

                // --

                onMainStatusBarChanged(enabled, contents, factory, userGroup, user, version);
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

        public void onMainStatusBarChanged(
            bool enabled,
            string contents,
            string factory,
            string userGroup,
            string user,
            string version
            )
        {
            try
            {
                if (MainStatusBarChanged != null)
                {
                    MainStatusBarChanged(this, new FMainStatusBarChangedEventArgs(enabled, contents, factory, userGroup, user, version));
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end