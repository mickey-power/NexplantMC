/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FApplicationLogViewer.cs
--  Creator         : baehyun seo
--  Create Date     : 2012.06.26
--  Description     : FAMate Admin Manager Application Log Viewer Form Class 
--  History         : Created by baehyun seo at 2012.06.26
                    : Modified by iskim at 2013.06.03
----------------------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using System.Windows.Forms;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public partial class FApplicationLogViewer : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private string m_serverName = string.Empty;
        private string m_eapId = string.Empty;
        private string m_backupFileName = string.Empty;
        private string m_fileName = string.Empty;
        private FLogFileType m_logFileType;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FApplicationLogViewer(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FApplicationLogViewer(
            FAdmCore fAdmCore,
            string fileName,
            FLogFileType logFileType
            )
            : this(fAdmCore, string.Empty, string.Empty, string.Empty, fileName, logFileType)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        public FApplicationLogViewer(
            FAdmCore fAdmCore,
            string server,
            string eapId,
            string backupFileName,
            string fileName,
            FLogFileType logFileType
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
            m_serverName = server;
            m_eapId = eapId;
            m_backupFileName = backupFileName;
            m_fileName = fileName;
            m_logFileType = logFileType;
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    m_fAdmCore = null;
                }
                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public string serverName
        {
            get
            {
                try
                {
                    return m_serverName;
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

        public string fileName
        {
            get
            {
                try
                {
                    return m_fileName;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        protected override void changeControlCaption(
            )
        {
            try
            {
                base.changeControlCaption();
                base.fUIWizard.changeControlCaption(mnuMenu);
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

        protected override void changeControlFontName(
            )
        {
            try
            {
                base.changeControlFontName();
                base.fUIWizard.changeControlFontName(mnuMenu);
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

        private bool procMenuChangeFontName(
            )
        {
            bool isValidFontName = true;
            string preFontName = string.Empty;

            try
            {
                preFontName = ((FontListTool)mnuMenu.Tools[FMenuKey.MenuAlvFontName]).Value.ToString();
                // --
                txtLog.Appearance.FontData.Name = (new System.Drawing.FontFamily(preFontName)).Name;
                m_fAdmCore.fOption.fontName = preFontName;
            }
            catch (Exception)
            {
                isValidFontName = false;
            }
            finally
            {

            }
            return isValidFontName;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuChangeFontSize(
            )
        {
            try
            {
                txtLog.Appearance.FontData.SizeInPoints = float.Parse(numFontSize.Value.ToString());
                m_fAdmCore.fOption.fontSize = float.Parse(numFontSize.Value.ToString());
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

        private void loadAdminServiceLogFile(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlnodeInLog = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutLog = null;
            string zipFileName = string.Empty;
            string tempFilePath = string.Empty;
            FFtp fFtp = null;
            string fileName = string.Empty;

            try
            {
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TolAdminServiceLogDownload_In.E_ADMADS_TolAdminServiceLogDownload_In);
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminServiceLogDownload_In.A_hLanguage, FADMADS_TolAdminServiceLogDownload_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminServiceLogDownload_In.A_hFactory, FADMADS_TolAdminServiceLogDownload_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminServiceLogDownload_In.A_hUserId, FADMADS_TolAdminServiceLogDownload_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminServiceLogDownload_In.A_hStep, FADMADS_TolAdminServiceLogDownload_In.D_hStep, "1");
                // --
                fXmlnodeInLog = fXmlNodeIn.set_elem(FADMADS_TolAdminServiceLogDownload_In.FLog.E_Log);
                fXmlnodeInLog.set_elemVal(FADMADS_TolAdminServiceLogDownload_In.FLog.A_File, FADMADS_TolAdminServiceLogDownload_In.FLog.D_File, Path.GetFileName(this.fileName));

                // --

                FADMADSCaster.ADMADS_TolAdminServiceLogDownload_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_TolAdminServiceLogDownload_Out.A_hStatus, FADMADS_TolAdminServiceLogDownload_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_TolAdminServiceLogDownload_Out.A_hStatusMessage, FADMADS_TolAdminServiceLogDownload_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeOutLog = fXmlNodeOut.get_elem(FADMADS_TolAdminServiceLogDownload_Out.FLog.E_Log);
                zipFileName = fXmlNodeOutLog.get_elemVal(FADMADS_TolAdminServiceLogDownload_Out.FLog.A_Path, FADMADS_TolAdminServiceLogDownload_Out.FLog.D_Path);

                // --

                // ***
                // Temp Directory create
                // ***
                tempFilePath = Path.Combine(m_fAdmCore.fWsmCore.tempPath, Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempFilePath);

                // --

                // ***
                // FTP Download & DeleteFiles
                // ***
                fFtp = FCommon.createFtp(m_fAdmCore);
                // --
                fFtp.downloadFiles(tempFilePath, Path.GetFileName(zipFileName));
                fFtp.deleteFiles(Path.GetFileName(zipFileName));

                // --

                // ***
                // Download File unpack
                // ***
                F7Zip.unpack(tempFilePath + "\\" + zipFileName, tempFilePath);

                // --

                fileName = tempFilePath + "\\" + Path.GetFileName(this.fileName);
                txtLog.openLogFile(fileName);
                setLogFileSize(fileName);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlnodeInLog = null;
                fXmlNodeOut = null;
                fXmlNodeOutLog = null;
                fFtp = null;

                // --

                FCommon.deleteDirectory(tempFilePath);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadAdminServiceBackupLogFile(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInLog = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutLog = null;
            string zipFileName = string.Empty;
            string tempFilePath = string.Empty;
            FFtp fFtp = null;
            string fileName = string.Empty;

            try
            {
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TolAdminServiceBackupLogDownload_In.E_ADMADS_TolAdminServiceBackupLogDownload_In);
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminServiceBackupLogDownload_In.A_hLanguage, FADMADS_TolAdminServiceBackupLogDownload_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminServiceBackupLogDownload_In.A_hFactory, FADMADS_TolAdminServiceBackupLogDownload_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminServiceBackupLogDownload_In.A_hUserId, FADMADS_TolAdminServiceBackupLogDownload_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminServiceBackupLogDownload_In.A_hStep, FADMADS_TolAdminServiceBackupLogDownload_In.D_hStep, "1");
                // --
                fXmlNodeInLog = fXmlNodeIn.set_elem(FADMADS_TolAdminServiceBackupLogDownload_In.FLog.E_Log);
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolAdminServiceBackupLogDownload_In.FLog.A_File, 
                    FADMADS_TolAdminServiceBackupLogDownload_In.FLog.D_File, 
                    m_backupFileName
                    );

                // --

                FADMADSCaster.ADMADS_TolAdminServiceBackupLogDownload_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_TolAdminServiceBackupLogDownload_Out.A_hStatus, FADMADS_TolAdminServiceBackupLogDownload_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_TolAdminServiceBackupLogDownload_Out.A_hStatusMessage, FADMADS_TolAdminServiceBackupLogDownload_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeOutLog = fXmlNodeOut.get_elem(FADMADS_TolAdminServiceBackupLogDownload_Out.FLog.E_Log);
                zipFileName = fXmlNodeOutLog.get_elemVal(FADMADS_TolAdminServiceBackupLogDownload_Out.FLog.A_Path, FADMADS_TolAdminServiceBackupLogDownload_Out.FLog.D_Path);

                // --

                // ***
                // Temp Directory create
                // ***
                tempFilePath = Path.Combine(m_fAdmCore.fWsmCore.tempPath, Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempFilePath);

                // --

                fFtp = FCommon.createFtp(m_fAdmCore);
                // --
                fFtp.downloadFiles(tempFilePath, Path.GetFileName(zipFileName));
                fFtp.deleteFiles(Path.GetFileName(zipFileName));

                // --

                // ***
                // Download File unpack
                // ***
                F7Zip.unpack(Path.Combine(tempFilePath, zipFileName), tempFilePath);
                F7Zip.unpack(Path.Combine(tempFilePath, m_backupFileName), tempFilePath);

                // --

                fileName = tempFilePath + "\\" + Path.GetFileName(this.fileName);
                txtLog.openLogFile(fileName);
                setLogFileSize(fileName);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInLog = null;
                fXmlNodeOut = null;
                fXmlNodeOutLog = null;
                fFtp = null;

                // --

                FCommon.deleteDirectory(tempFilePath);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadAdminAgentLogFile(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInLog = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutLog = null;
            string zipFileName = string.Empty;
            string tempFilePath = string.Empty;
            FFtp fFtp = null;
            string fileName = string.Empty;

            try
            {
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TolAdminAgentLogDownload_In.E_ADMADS_TolAdminAgentLogDownload_In);
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminAgentLogDownload_In.A_hLanguage, FADMADS_TolAdminAgentLogDownload_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminAgentLogDownload_In.A_hFactory, FADMADS_TolAdminAgentLogDownload_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminAgentLogDownload_In.A_hUserId, FADMADS_TolAdminAgentLogDownload_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminAgentLogDownload_In.A_hStep, FADMADS_TolAdminAgentLogDownload_In.D_hStep, "1");
                // --
                fXmlNodeInLog = fXmlNodeIn.set_elem(FADMADS_TolAdminAgentLogDownload_In.FLog.E_Log);
                fXmlNodeInLog.set_elemVal(FADMADS_TolAdminAgentLogDownload_In.FLog.A_File, FADMADS_TolAdminAgentLogDownload_In.FLog.D_File, Path.GetFileName(this.fileName));
                fXmlNodeInLog.set_elemVal(FADMADS_TolAdminAgentLogDownload_In.FLog.A_Server, FADMADS_TolAdminAgentLogDownload_In.FLog.D_Server, this.serverName);

                // --

                FADMADSCaster.ADMADS_TolAdminAgentLogDownload_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_TolAdminAgentLogDownload_Out.A_hStatus, FADMADS_TolAdminAgentLogDownload_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_TolAdminAgentLogDownload_Out.A_hStatusMessage, FADMADS_TolAdminAgentLogDownload_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeOutLog = fXmlNodeOut.get_elem(FADMADS_TolAdminAgentLogDownload_Out.FLog.E_Log);
                zipFileName = fXmlNodeOutLog.get_elemVal(FADMADS_TolAdminAgentLogDownload_Out.FLog.A_Path, FADMADS_TolAdminAgentLogDownload_Out.FLog.D_Path);

                // --

                // ***
                // Temp Directory create
                // ***
                tempFilePath = Path.Combine(m_fAdmCore.fWsmCore.tempPath, Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempFilePath);

                // --

                // ***
                // FTP Download & DeleteFiles
                // ***
                fFtp = FCommon.createFtp(m_fAdmCore);
                // --
                fFtp.downloadFiles(tempFilePath, Path.GetFileName(zipFileName));
                fFtp.deleteFiles(Path.GetFileName(zipFileName));

                // --

                // ***
                // Download File unpack
                // ***
                F7Zip.unpack(tempFilePath + "\\" + zipFileName, tempFilePath);

                // --

                fileName = tempFilePath + "\\" + Path.GetFileName(this.fileName);
                txtLog.openLogFile(fileName);
                setLogFileSize(fileName);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInLog = null;
                fXmlNodeOut = null;
                fXmlNodeOutLog = null;
                fFtp = null;

                // --

                FCommon.deleteDirectory(tempFilePath);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadAdminAgentBackupLogFile(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInLog = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutLog = null;
            string zipFileName = string.Empty;
            string tempFilePath = string.Empty;
            FFtp fFtp = null;
            string fileName = string.Empty;

            try
            {
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TolAdminAgentBackupLogDownload_In.E_ADMADS_TolAdminAgentBackupLogDownload_In);
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminAgentBackupLogDownload_In.A_hLanguage, FADMADS_TolAdminAgentBackupLogDownload_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminAgentBackupLogDownload_In.A_hFactory, FADMADS_TolAdminAgentBackupLogDownload_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminAgentBackupLogDownload_In.A_hUserId, FADMADS_TolAdminAgentBackupLogDownload_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminAgentBackupLogDownload_In.A_hStep, FADMADS_TolAdminAgentBackupLogDownload_In.D_hStep, "1");
                // --
                fXmlNodeInLog = fXmlNodeIn.set_elem(FADMADS_TolAdminAgentBackupLogDownload_In.FLog.E_Log);
                fXmlNodeInLog.set_elemVal(FADMADS_TolAdminAgentBackupLogDownload_In.FLog.A_Server, FADMADS_TolAdminAgentBackupLogDownload_In.FLog.D_Server, this.serverName);
                fXmlNodeInLog.set_elemVal(FADMADS_TolAdminAgentBackupLogDownload_In.FLog.A_File, FADMADS_TolAdminAgentBackupLogDownload_In.FLog.D_File, m_backupFileName);

                // --

                FADMADSCaster.ADMADS_TolAdminAgentBackupLogDownload_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_TolAdminAgentBackupLogDownload_Out.A_hStatus, FADMADS_TolAdminAgentBackupLogDownload_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_TolAdminAgentBackupLogDownload_Out.A_hStatusMessage, FADMADS_TolAdminAgentBackupLogDownload_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeOutLog = fXmlNodeOut.get_elem(FADMADS_TolAdminAgentBackupLogDownload_Out.FLog.E_Log);
                zipFileName = fXmlNodeOutLog.get_elemVal(FADMADS_TolAdminAgentBackupLogDownload_Out.FLog.A_Path, FADMADS_TolAdminAgentBackupLogDownload_Out.FLog.D_Path);

                // --

                // ***
                // Temp Directory create
                // ***
                tempFilePath = Path.Combine(m_fAdmCore.fWsmCore.tempPath, Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempFilePath);

                // --

                fFtp = FCommon.createFtp(m_fAdmCore);
                // --
                fFtp.downloadFiles(tempFilePath, Path.GetFileName(zipFileName));
                fFtp.deleteFiles(Path.GetFileName(zipFileName));

                // --

                // ***
                // Download File unpack
                // ***
                F7Zip.unpack(Path.Combine(tempFilePath, zipFileName), tempFilePath);
                F7Zip.unpack(Path.Combine(tempFilePath, m_backupFileName), tempFilePath);

                // --

                fileName = tempFilePath + "\\" + Path.GetFileName(this.fileName);
                txtLog.openLogFile(fileName);
                setLogFileSize(fileName);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInLog = null;
                fXmlNodeOut = null;
                fXmlNodeOutLog = null;
                fFtp = null;

                // --

                FCommon.deleteDirectory(tempFilePath);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadAlertServiceLogFile(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInLog = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutLog = null;
            string zipFileName = string.Empty;
            string tempFilePath = string.Empty;
            FFtp fFtp = null;
            string fileName = string.Empty;

            try
            {
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TolAlertServiceLogDownload_In.E_ADMADS_TolAlertServiceLogDownload_In);
                fXmlNodeIn.set_elemVal(FADMADS_TolAlertServiceLogDownload_In.A_hLanguage, FADMADS_TolAlertServiceLogDownload_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TolAlertServiceLogDownload_In.A_hFactory, FADMADS_TolAlertServiceLogDownload_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TolAlertServiceLogDownload_In.A_hUserId, FADMADS_TolAlertServiceLogDownload_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TolAlertServiceLogDownload_In.A_hStep, FADMADS_TolAlertServiceLogDownload_In.D_hStep, "1");
                // --
                fXmlNodeInLog = fXmlNodeIn.set_elem(FADMADS_TolAlertServiceLogDownload_In.FLog.E_Log);
                fXmlNodeInLog.set_elemVal(FADMADS_TolAlertServiceLogDownload_In.FLog.A_File, FADMADS_TolAlertServiceLogDownload_In.FLog.D_File, Path.GetFileName(this.fileName));

                // --

                FADMADSCaster.ADMADS_TolAlertServiceLogDownload_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_TolAlertServiceLogDownload_Out.A_hStatus, FADMADS_TolAlertServiceLogDownload_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_TolAlertServiceLogDownload_Out.A_hStatusMessage, FADMADS_TolAlertServiceLogDownload_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeOutLog = fXmlNodeOut.get_elem(FADMADS_TolAlertServiceLogDownload_Out.FLog.E_Log);
                zipFileName = fXmlNodeOutLog.get_elemVal(FADMADS_TolAlertServiceLogDownload_Out.FLog.A_Path, FADMADS_TolAlertServiceLogDownload_Out.FLog.D_Path);

                // --

                // ***
                // Temp Directory create
                // ***
                tempFilePath = Path.Combine(m_fAdmCore.fWsmCore.tempPath, Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempFilePath);

                // --

                // ***
                // FTP Download & DeleteFiles
                // ***
                fFtp = FCommon.createFtp(m_fAdmCore);
                // --
                fFtp.downloadFiles(tempFilePath, Path.GetFileName(zipFileName));
                fFtp.deleteFiles(Path.GetFileName(zipFileName));

                // --

                // ***
                // Download File unpack
                // ***
                F7Zip.unpack(tempFilePath + "\\" + zipFileName, tempFilePath);

                // --

                fileName = tempFilePath + "\\" + Path.GetFileName(this.fileName);
                txtLog.openLogFile(fileName);
                setLogFileSize(fileName);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInLog = null;
                fXmlNodeOut = null;
                fXmlNodeOutLog = null;
                fFtp = null;

                // --

                FCommon.deleteDirectory(tempFilePath);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadAlertServiceBackupLogFile(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInLog = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutLog = null;
            string zipFileName = string.Empty;
            string tempFilePath = string.Empty;
            FFtp fFtp = null;
            string fileName = string.Empty;

            try
            {
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TolAlertServiceBackupLogDownload_In.E_ADMADS_TolAlertServiceBackupLogDownload_In);
                fXmlNodeIn.set_elemVal(FADMADS_TolAlertServiceBackupLogDownload_In.A_hLanguage, FADMADS_TolAlertServiceBackupLogDownload_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TolAlertServiceBackupLogDownload_In.A_hFactory, FADMADS_TolAlertServiceBackupLogDownload_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TolAlertServiceBackupLogDownload_In.A_hUserId, FADMADS_TolAlertServiceBackupLogDownload_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TolAlertServiceBackupLogDownload_In.A_hStep, FADMADS_TolAlertServiceBackupLogDownload_In.D_hStep, "1");
                // --
                fXmlNodeInLog = fXmlNodeIn.set_elem(FADMADS_TolAlertServiceBackupLogDownload_In.FLog.E_Log);
                fXmlNodeInLog.set_elemVal(FADMADS_TolAlertServiceBackupLogDownload_In.FLog.A_File, FADMADS_TolAlertServiceBackupLogDownload_In.FLog.D_File, m_backupFileName);

                // --

                FADMADSCaster.ADMADS_TolAlertServiceBackupLogDownload_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_TolAlertServiceBackupLogDownload_Out.A_hStatus, FADMADS_TolAlertServiceBackupLogDownload_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_TolAlertServiceBackupLogDownload_Out.A_hStatusMessage, FADMADS_TolAlertServiceBackupLogDownload_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeOutLog = fXmlNodeOut.get_elem(FADMADS_TolAlertServiceBackupLogDownload_Out.FLog.E_Log);
                zipFileName = fXmlNodeOutLog.get_elemVal(FADMADS_TolAlertServiceBackupLogDownload_Out.FLog.A_Path, FADMADS_TolAlertServiceBackupLogDownload_Out.FLog.D_Path);

                // --

                // ***
                // Temp Directory create
                // ***
                tempFilePath = Path.Combine(m_fAdmCore.fWsmCore.tempPath, Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempFilePath);

                // --

                fFtp = FCommon.createFtp(m_fAdmCore);
                // --
                fFtp.downloadFiles(tempFilePath, Path.GetFileName(zipFileName));
                fFtp.deleteFiles(Path.GetFileName(zipFileName));

                // --

                // ***
                // Download File unpack
                // ***
                F7Zip.unpack(Path.Combine(tempFilePath, zipFileName), tempFilePath);
                F7Zip.unpack(Path.Combine(tempFilePath, m_backupFileName), tempFilePath);

                // --

                fileName = tempFilePath + "\\" + Path.GetFileName(this.fileName);
                txtLog.openLogFile(fileName);
                setLogFileSize(fileName);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInLog = null;
                fXmlNodeOut = null;
                fXmlNodeOutLog = null;
                fFtp = null;

                // --

                FCommon.deleteDirectory(tempFilePath);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void refreshLog(
            )
        {
            FProgress fProgress = null;

            try
            {
                fProgress = new FProgress();
                fProgress.show(m_fAdmCore.fWsmCore.fWsmContainer);

                // --

                if (m_logFileType == FLogFileType.AdminServiceLogFile)
                {
                    if (m_backupFileName == string.Empty)
                    {
                        loadAdminServiceLogFile();
                    }
                    else
                    {
                        loadAdminServiceBackupLogFile();
                    }
                }
                else if (m_logFileType == FLogFileType.AlertServiceLogFile)
                {
                    if (m_backupFileName == string.Empty)
                    {
                        loadAlertServiceLogFile();
                    }
                    else
                    {
                        loadAlertServiceBackupLogFile();
                    }
                }
                else
                {
                    if (m_backupFileName == string.Empty)
                    {
                        loadAdminAgentLogFile();
                    }
                    else
                    {
                        loadAdminAgentBackupLogFile();
                    }
                }

                // --

                Application.DoEvents();
                // --
                if (txtLog.TextLength > 0)
                {
                    txtLog.Select(0, 1);
                    txtLog.ScrollToCaret();
                }

                // --

                refreshLogOfGrid(FLogContinuity.Previous);

                // --

                grdList.Focus();
            }
            catch (Exception ex)
            {
                if (fProgress != null)
                {
                    fProgress.Dispose();
                    fProgress = null;
                }

                // --

                grdList.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                if (fProgress != null)
                {
                    fProgress.Dispose();
                    fProgress = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void refreshLogOfGrid(
            FLogContinuity fLogContinuity
            )
        {
            string key = string.Empty;
            string startTime = string.Empty;
            string serverName = string.Empty;
            string namespace_ = string.Empty;
            string typeName = string.Empty;
            string functionName = string.Empty;
            string endTime = string.Empty;
            string procTime = string.Empty;
            // --
            int preIndex = 0;
            int startIndex = 0;
            int endIndex = 0;
            object[] cellValues = null;
            // --
            string blockLog = string.Empty;
            int blockStartIndex = 0;
            int blockEndIndex = 0;
            int blockLength = 0;

            try
            {
                grdList.beginUpdate();
                grdList.removeAllDataRow();
                grdList.DisplayLayout.Bands[0].SortedColumns.Clear();

                // --

                do
                {
                    blockEndIndex = txtLog.Text.IndexOf("\r\n-\r\n", blockStartIndex);

                    // -- 
                    if (blockEndIndex == -1)
                    {
                        break;
                    }

                    // --

                    blockLength = blockEndIndex - blockStartIndex;
                    blockLog = txtLog.Text.Substring(blockStartIndex, blockLength);

                    // --

                    key = blockStartIndex.ToString();

                    // --

                    startTime = string.Empty;
                    serverName = string.Empty;
                    namespace_ = string.Empty;
                    typeName = string.Empty;
                    functionName = string.Empty;
                    endTime = string.Empty;
                    procTime = string.Empty;

                    // --

                    startIndex = blockLog.IndexOf("StartTime=<");

                    // --

                    if (startIndex == -1)
                    {
                        break;
                    }

                    // ***
                    // Start Time
                    // ***
                    preIndex = startIndex;
                    if (startIndex > blockLength)
                    {
                        continue;
                    }
                    if (startIndex < blockLength)
                    {
                        startIndex += 11;
                        endIndex = blockLog.IndexOf(">", startIndex);
                        startTime = blockLog.Substring(startIndex, endIndex - startIndex);
                    }

                    // --

                    // ***
                    // Server Name
                    // ***
                    preIndex = startIndex;
                    startIndex = blockLog.IndexOf("ServerName=<", startIndex);
                    if (startIndex == -1)
                    {
                        startIndex = preIndex;
                    }
                    else if (startIndex > blockLength)
                    {
                        startIndex = preIndex;
                    }
                    else if (startIndex < blockLength)
                    {
                        startIndex += 12;
                        endIndex = blockLog.IndexOf(">", startIndex);
                        serverName = blockLog.Substring(startIndex, endIndex - startIndex);
                    }

                    // --

                    // ***
                    // Namespace
                    // ***
                    preIndex = startIndex;
                    startIndex = blockLog.IndexOf("Namespace=<", startIndex);
                    if (startIndex < blockLength)
                    {
                        startIndex += 11;
                        endIndex = blockLog.IndexOf(">", startIndex);
                        namespace_ = blockLog.Substring(startIndex, endIndex - startIndex);
                    }
                    else
                    {
                        startIndex = preIndex;
                    }

                    // --

                    // ***
                    // Type Name
                    // ***
                    preIndex = startIndex;
                    startIndex = blockLog.IndexOf("TypeName=<", startIndex);
                    if (startIndex < blockLength)
                    {
                        startIndex += 10;
                        endIndex = blockLog.IndexOf(">", startIndex);
                        typeName = blockLog.Substring(startIndex, endIndex - startIndex);
                    }
                    else
                    {
                        startIndex = preIndex;
                    }

                    // --

                    // ***
                    // Function Name
                    // ***
                    preIndex = startIndex;
                    startIndex = blockLog.IndexOf("FunctionName=<", startIndex);
                    if (startIndex < blockLength)
                    {
                        startIndex += 14;
                        endIndex = blockLog.IndexOf(">", startIndex);
                        functionName = blockLog.Substring(startIndex, endIndex - startIndex);
                    }
                    else
                    {
                        startIndex = preIndex;
                    }

                    // --

                    // ***
                    // End Time
                    // ***
                    preIndex = startIndex;
                    startIndex = blockLog.IndexOf("EndTime=<", startIndex);
                    if (startIndex < blockLength)
                    {
                        startIndex += 9;
                        endIndex = blockLog.IndexOf(">", startIndex);
                        endTime = blockLog.Substring(startIndex, endIndex - startIndex);
                    }
                    else
                    {
                        startIndex = preIndex;
                    }

                    // --

                    // ***
                    // Proc Time
                    // ***
                    preIndex = startIndex;
                    startIndex = blockLog.IndexOf("ProcTime=<", startIndex);
                    if (startIndex < blockLength)
                    {
                        startIndex += 10;
                        endIndex = blockLog.IndexOf(">", startIndex);
                        procTime = blockLog.Substring(startIndex, endIndex - startIndex);
                    }
                    else
                    {
                        startIndex = preIndex;
                    }

                    // --

                    cellValues = new object[] {
                        startTime,
                        functionName,
                        namespace_,
                        typeName,
                        serverName,   
                        procTime,
                        endTime
                        };
                    grdList.appendDataRow(key, cellValues);

                    // --

                    blockStartIndex = blockStartIndex + blockLength + 5;
                } while (blockStartIndex < txtLog.Text.Length);

                // --

                grdList.endUpdate();
                grdList.DisplayLayout.Bands[0].SortedColumns.Add("Start Time", false);

                // --

                lblTotal.Text = grdList.Rows.VisibleRowCount.ToString("#,##0") + " / " + grdList.Rows.Count.ToString("#,##0");

                // --

                if (grdList.Rows.Count > 0)
                {
                    if (fLogContinuity == FLogContinuity.Previous)
                    {
                        grdList.ActiveRow = grdList.Rows[grdList.Rows.Count - 1];
                    }
                    else
                    {
                        grdList.ActiveRow = grdList.Rows[0];
                    }
                }
                setLogTime();
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void setLogTime(
            )
        {
            try
            {
                if (grdList.Rows.Count == 0)
                {
                    txtFromTime.Text = string.Empty;
                    txtToTime.Text = string.Empty;
                }
                else
                {
                    txtFromTime.Text = grdList.Rows[0].Cells["Start Time"].Text;
                    txtToTime.Text = grdList.Rows[grdList.Rows.Count - 1].Cells["Start Time"].Text;
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

        private void setLogFileSize(
            string fileName
            )
        {
            FileInfo fileInfo = null;

            try
            {
                fileInfo = new FileInfo(fileName);
                txtSize.Text = FDataConvert.volumeSizeToString(fileInfo.Length, FVolumnOption.KiloByte);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fileInfo = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void designGridOfIndex(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --
                uds.Band.Columns.Add("Start Time");
                uds.Band.Columns.Add("Function Name");
                uds.Band.Columns.Add("Namespace");
                uds.Band.Columns.Add("Type Name");
                uds.Band.Columns.Add("Server Name");
                uds.Band.Columns.Add("Proc Time");
                uds.Band.Columns.Add("End Time");

                // --

                grdList.DisplayLayout.Bands[0].Columns["Start Time"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["Function Name"].Width = 270;
                grdList.DisplayLayout.Bands[0].Columns["Namespace"].Width = 188;
                grdList.DisplayLayout.Bands[0].Columns["Type Name"].Width = 113;
                grdList.DisplayLayout.Bands[0].Columns["Server Name"].Width = 94;
                grdList.DisplayLayout.Bands[0].Columns["Proc Time"].Width = 62;
                grdList.DisplayLayout.Bands[0].Columns["End Time"].Width = 160;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Function Name"].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                grdList.DisplayLayout.Bands[0].Columns["Namespace"].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                grdList.DisplayLayout.Bands[0].Columns["Type Name"].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                grdList.DisplayLayout.Bands[0].Columns["Server Name"].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                // --
                grdList.DisplayLayout.Bands[0].Columns["End Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdList.DisplayLayout.Bands[0].Columns["Proc Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                // --
                grdList.DisplayLayout.Override.FilterUIProvider = this.grdFilter;

                // --

                grdList.DisplayLayout.Bands[0].Columns["Start Time"].CellAppearance.Image = Properties.Resources.History;
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

        private void refreshGridOfIndex(
            )
        {
            try
            {
                if (m_fileName == string.Empty)
                {
                    return;
                }

                // --

                if (m_logFileType == FLogFileType.AdminServiceLogFile)
                {
                    txtLogType.Text = "Admin Service";
                }
                else if (m_logFileType == FLogFileType.AdminAgentLogFile)
                {
                    txtLogType.Text = "Agent - [ " + m_serverName + " ]";
                }
                else if (m_logFileType == FLogFileType.EapLogFile)
                {
                    txtLogType.Text = "EAP - [ " + m_eapId + " ]";
                }
                else if (m_logFileType == FLogFileType.AlertServiceLogFile)
                {
                    txtLogType.Text = "Alert Service";
                }

                // --
                
                txtFileName.Text = Path.GetFileName(m_fileName);
                
                // --

                refreshLog();
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

        public void continueLogFile(
            FLogContinuity fLogContinuity
            )
        {
            FProgress fProgress = null;

            try
            {
                fProgress = new FProgress();
                fProgress.show(m_fAdmCore.fWsmCore.fWsmContainer);

                // --

                if (m_logFileType == FLogFileType.AdminServiceLogFile)
                {
                    if (m_backupFileName == string.Empty)
                    {
                        continueAdminServiceLogFile(fLogContinuity);
                    }
                    else
                    {
                        continueAdminServiceBackupLogFile(fLogContinuity);
                    }
                }
                else if (m_logFileType == FLogFileType.AlertServiceLogFile)
                {
                    if (m_backupFileName == string.Empty)
                    {
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (m_backupFileName == string.Empty)
                    {
                        continueAdminAgentLogFile(fLogContinuity);
                    }
                    else
                    {
                        continueAdminAgentBackupLogFile(fLogContinuity);
                    }
                }

                // --

                Application.DoEvents();
                // --
                if (txtLog.TextLength > 0)
                {
                    txtLog.Select(0, 1);
                    txtLog.ScrollToCaret();
                }
                // --
                txtFileName.Text = m_fileName;

                // --

                refreshLogOfGrid(FLogContinuity.Previous);
            }
            catch (Exception ex)
            {
                if (fProgress != null)
                {
                    fProgress.Dispose();
                    fProgress = null;
                }

                // --

                grdList.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                if (fProgress != null)
                {
                    fProgress.Dispose();
                    fProgress = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void continueAdminServiceLogFile(
            FLogContinuity fLogContinuity
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInLog = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutLog = null;
            FFtp fFtp = null;
            string zipFileName = string.Empty;
            string tempFilePath = string.Empty;
            string fileName = string.Empty;

            try
            {
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TolAdminServiceLogContinue_In.E_ADMADS_TolAdminServiceLogContinue_In);
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminServiceLogContinue_In.A_hLanguage, FADMADS_TolAdminServiceLogContinue_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminServiceLogContinue_In.A_hFactory, FADMADS_TolAdminServiceLogContinue_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminServiceLogContinue_In.A_hUserId, FADMADS_TolAdminServiceLogContinue_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminServiceLogContinue_In.A_hStep, FADMADS_TolAdminServiceLogContinue_In.D_hStep, "1");
                // --
                fXmlNodeInLog = fXmlNodeIn.set_elem(FADMADS_TolAdminServiceLogContinue_In.FLog.E_Log);
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolAdminServiceLogContinue_In.FLog.A_File,
                    FADMADS_TolAdminServiceLogContinue_In.FLog.D_File,
                    Path.GetFileName(m_fileName)
                    );
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolAdminServiceLogContinue_In.FLog.A_Type,
                    FADMADS_TolAdminServiceLogContinue_In.FLog.D_Type,
                    FLogType.Application.ToString()
                    );
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolAdminServiceLogContinue_In.FLog.A_Continuity,
                    FADMADS_TolAdminServiceLogContinue_In.FLog.D_Continuity,
                    fLogContinuity.ToString()
                    );

                // --

                FADMADSCaster.ADMADS_TolAdminServiceLogContinue_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_TolAdminServiceLogContinue_Out.A_hStatus, FADMADS_TolAdminServiceLogContinue_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_TolAdminServiceLogContinue_Out.A_hStatusMessage, FADMADS_TolAdminServiceLogContinue_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeOutLog = fXmlNodeOut.get_elem(FADMADS_TolAdminServiceLogContinue_Out.FLog.E_Log);
                zipFileName = fXmlNodeOutLog.get_elemVal(
                    FADMADS_TolAdminServiceLogContinue_Out.FLog.A_Path,
                    FADMADS_TolAdminServiceLogContinue_Out.FLog.D_Path
                    );
                m_fileName = fXmlNodeOutLog.get_elemVal(
                    FADMADS_TolAdminServiceLogContinue_Out.FLog.A_File,
                    FADMADS_TolAdminServiceLogContinue_Out.FLog.D_File
                    );

                // --

                // ***
                // Temp Directory create
                // ***
                tempFilePath = Path.Combine(m_fAdmCore.fWsmCore.tempPath, Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempFilePath);

                // --

                fFtp = FCommon.createFtp(m_fAdmCore);
                // --
                fFtp.downloadFiles(tempFilePath, Path.GetFileName(zipFileName));
                fFtp.deleteFiles(Path.GetFileName(zipFileName));

                // --

                // ***
                // Download File unpack
                // ***
                F7Zip.unpack(tempFilePath + "\\" + zipFileName, tempFilePath);

                // --

                fileName = tempFilePath + "\\" + Path.GetFileName(this.fileName);
                txtLog.openLogFile(fileName);
                setLogFileSize(fileName);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInLog = null;
                fXmlNodeOut = null;
                fXmlNodeOutLog = null;
                fFtp = null;

                // --

                FCommon.deleteDirectory(tempFilePath);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void continueAdminServiceBackupLogFile(
            FLogContinuity fLogContinuity
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInLog = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutLog = null;
            FFtp fFtp = null;
            string zipFileName = string.Empty;
            string tempFilePath = string.Empty;
            string fileName = string.Empty;

            try
            {
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TolAdminServiceBackupLogContinue_In.E_ADMADS_TolAdminServiceBackupLogContinue_In);
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminServiceBackupLogContinue_In.A_hLanguage, FADMADS_TolAdminServiceBackupLogContinue_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminServiceBackupLogContinue_In.A_hFactory, FADMADS_TolAdminServiceBackupLogContinue_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminServiceBackupLogContinue_In.A_hUserId, FADMADS_TolAdminServiceBackupLogContinue_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminServiceBackupLogContinue_In.A_hStep, FADMADS_TolAdminServiceBackupLogContinue_In.D_hStep, "1");
                // --
                fXmlNodeInLog = fXmlNodeIn.set_elem(FADMADS_TolAdminServiceBackupLogContinue_In.FLog.E_Log);
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolAdminServiceBackupLogContinue_In.FLog.A_Type,
                    FADMADS_TolAdminServiceBackupLogContinue_In.FLog.D_Type,
                    FLogType.Application.ToString()
                    );
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolAdminServiceBackupLogContinue_In.FLog.A_BackupFile,
                    FADMADS_TolAdminServiceBackupLogContinue_In.FLog.D_BackupFile,
                    m_backupFileName
                    );
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolAdminServiceBackupLogContinue_In.FLog.A_File,
                    FADMADS_TolAdminServiceBackupLogContinue_In.FLog.D_File,
                    m_fileName
                    );
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolAdminServiceBackupLogContinue_In.FLog.A_Continuity,
                    FADMADS_TolAdminServiceBackupLogContinue_In.FLog.D_Continuity,
                    fLogContinuity.ToString()
                    );

                // --

                FADMADSCaster.ADMADS_TolAdminServiceBackupLogContinue_Req(
                     m_fAdmCore.fH101,
                     fXmlNodeIn,
                     ref fXmlNodeOut
                     );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_TolAdminServiceBackupLogContinue_Out.A_hStatus, FADMADS_TolAdminServiceBackupLogContinue_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_TolAdminServiceBackupLogContinue_Out.A_hStatusMessage, FADMADS_TolAdminServiceBackupLogContinue_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeOutLog = fXmlNodeOut.get_elem(FADMADS_TolAdminServiceBackupLogContinue_Out.FLog.E_Log);
                zipFileName = fXmlNodeOutLog.get_elemVal(
                    FADMADS_TolAdminServiceBackupLogContinue_Out.FLog.A_Path,
                    FADMADS_TolAdminServiceBackupLogContinue_Out.FLog.D_Path
                    );
                m_backupFileName = fXmlNodeOutLog.get_elemVal(
                    FADMADS_TolAdminServiceBackupLogContinue_Out.FLog.A_BackupFile,
                    FADMADS_TolAdminServiceBackupLogContinue_Out.FLog.D_BackupFile
                    );
                m_fileName = fXmlNodeOutLog.get_elemVal(
                    FADMADS_TolAdminServiceBackupLogContinue_Out.FLog.A_File,
                    FADMADS_TolAdminServiceBackupLogContinue_Out.FLog.D_File
                    );

                // --

                // ***
                // Temp Directory create
                // ***
                tempFilePath = Path.Combine(m_fAdmCore.fWsmCore.tempPath, Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempFilePath);

                // --

                fFtp = FCommon.createFtp(m_fAdmCore);
                // --
                fFtp.downloadFiles(tempFilePath, Path.GetFileName(zipFileName));
                fFtp.deleteFiles(Path.GetFileName(zipFileName));

                // --

                // ***
                // Download File unpack
                // ***
                F7Zip.unpack(tempFilePath + "\\" + zipFileName, tempFilePath);
                F7Zip.unpack(Path.Combine(tempFilePath, m_backupFileName), tempFilePath);

                // --

                fileName = tempFilePath + "\\" + Path.GetFileName(this.fileName);
                txtLog.openLogFile(fileName);
                setLogFileSize(fileName);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInLog = null;
                fXmlNodeOut = null;
                fXmlNodeOutLog = null;
                fFtp = null;

                // --

                FCommon.deleteDirectory(tempFilePath);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void continueAdminAgentLogFile(
            FLogContinuity fLogContinuity
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInLog = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutLog = null;
            FFtp fFtp = null;
            string zipFileName = string.Empty;
            string tempFilePath = string.Empty;
            string fileName = string.Empty;

            try
            {
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TolAdminAgentLogContinue_In.E_ADMADS_TolAdminAgentLogContinue_In);
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminAgentLogContinue_In.A_hLanguage, FADMADS_TolAdminAgentLogContinue_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminAgentLogContinue_In.A_hFactory, FADMADS_TolAdminAgentLogContinue_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminAgentLogContinue_In.A_hUserId, FADMADS_TolAdminAgentLogContinue_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminAgentLogContinue_In.A_hStep, FADMADS_TolAdminAgentLogContinue_In.D_hStep, "1");
                // --
                fXmlNodeInLog = fXmlNodeIn.set_elem(FADMADS_TolAdminAgentLogContinue_In.FLog.E_Log);
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolAdminAgentLogContinue_In.FLog.A_Server,
                    FADMADS_TolAdminAgentLogContinue_In.FLog.D_Server,
                    m_serverName
                    );
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolAdminAgentLogContinue_In.FLog.A_File,
                    FADMADS_TolAdminAgentLogContinue_In.FLog.D_File,
                    Path.GetFileName(m_fileName)
                    );
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolAdminAgentLogContinue_In.FLog.A_Type,
                    FADMADS_TolAdminAgentLogContinue_In.FLog.D_Type,
                    FLogType.Application.ToString()
                    );
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolAdminAgentLogContinue_In.FLog.A_Continuity,
                    FADMADS_TolAdminAgentLogContinue_In.FLog.D_Continuity,
                    fLogContinuity.ToString()
                    );

                // --

                FADMADSCaster.ADMADS_TolAdminAgentLogContinue_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_TolAdminAgentLogContinue_Out.A_hStatus, FADMADS_TolAdminAgentLogContinue_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_TolAdminAgentLogContinue_Out.A_hStatusMessage, FADMADS_TolAdminAgentLogContinue_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeOutLog = fXmlNodeOut.get_elem(FADMADS_TolAdminAgentLogContinue_Out.FLog.E_Log);
                zipFileName = fXmlNodeOutLog.get_elemVal(
                    FADMADS_TolAdminAgentLogContinue_Out.FLog.A_Path,
                    FADMADS_TolAdminAgentLogContinue_Out.FLog.D_Path
                    );
                m_fileName = fXmlNodeOutLog.get_elemVal(
                    FADMADS_TolAdminAgentLogContinue_Out.FLog.A_File,
                    FADMADS_TolAdminAgentLogContinue_Out.FLog.D_File
                    );

                // --

                // ***
                // Temp Directory create
                // ***
                tempFilePath = Path.Combine(m_fAdmCore.fWsmCore.tempPath, Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempFilePath);

                // --

                fFtp = FCommon.createFtp(m_fAdmCore);
                // --
                fFtp.downloadFiles(tempFilePath, Path.GetFileName(zipFileName));
                fFtp.deleteFiles(Path.GetFileName(zipFileName));

                // --

                // ***
                // Download File unpack
                // ***
                F7Zip.unpack(tempFilePath + "\\" + zipFileName, tempFilePath);

                // --

                fileName = tempFilePath + "\\" + Path.GetFileName(this.fileName);
                txtLog.openLogFile(fileName);
                setLogFileSize(fileName);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInLog = null;
                fXmlNodeOut = null;
                fXmlNodeOutLog = null;
                fFtp = null;

                // --

                FCommon.deleteDirectory(tempFilePath);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void continueAdminAgentBackupLogFile(
            FLogContinuity fLogContinuity
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInLog = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutLog = null;
            FFtp fFtp = null;
            string zipFileName = string.Empty;
            string tempFilePath = string.Empty;
            string fileName = string.Empty;

            try
            {
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TolAdminAgentBackupLogContinue_In.E_ADMADS_TolAdminAgentBackupLogContinue_In);
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminAgentBackupLogContinue_In.A_hLanguage, FADMADS_TolAdminAgentBackupLogContinue_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminAgentBackupLogContinue_In.A_hFactory, FADMADS_TolAdminAgentBackupLogContinue_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminAgentBackupLogContinue_In.A_hUserId, FADMADS_TolAdminAgentBackupLogContinue_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TolAdminAgentBackupLogContinue_In.A_hStep, FADMADS_TolAdminAgentBackupLogContinue_In.D_hStep, "1");
                // --
                fXmlNodeInLog = fXmlNodeIn.set_elem(FADMADS_TolAdminAgentBackupLogContinue_In.FLog.E_Log);
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolAdminAgentBackupLogContinue_In.FLog.A_Server,
                    FADMADS_TolAdminAgentBackupLogContinue_In.FLog.D_Server,
                    m_serverName
                    );
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolAdminAgentBackupLogContinue_In.FLog.A_Type,
                    FADMADS_TolAdminAgentBackupLogContinue_In.FLog.D_Type,
                    FLogType.Application.ToString()
                    );
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolAdminAgentBackupLogContinue_In.FLog.A_BackupFile,
                    FADMADS_TolAdminAgentBackupLogContinue_In.FLog.D_BackupFile,
                    m_backupFileName
                    );
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolAdminAgentBackupLogContinue_In.FLog.A_File,
                    FADMADS_TolAdminAgentBackupLogContinue_In.FLog.D_File,
                    m_fileName
                    );
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolAdminAgentBackupLogContinue_In.FLog.A_Continuity,
                    FADMADS_TolAdminAgentBackupLogContinue_In.FLog.D_Continuity,
                    fLogContinuity.ToString()
                    );

                // --

                FADMADSCaster.ADMADS_TolAdminAgentBackupLogContinue_Req(
                     m_fAdmCore.fH101,
                     fXmlNodeIn,
                     ref fXmlNodeOut
                     );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_TolAdminAgentBackupLogContinue_Out.A_hStatus, FADMADS_TolAdminAgentBackupLogContinue_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_TolAdminAgentBackupLogContinue_Out.A_hStatusMessage, FADMADS_TolAdminAgentBackupLogContinue_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeOutLog = fXmlNodeOut.get_elem(FADMADS_TolAdminAgentBackupLogContinue_Out.FLog.E_Log);
                zipFileName = fXmlNodeOutLog.get_elemVal(
                    FADMADS_TolAdminAgentBackupLogContinue_Out.FLog.A_Path,
                    FADMADS_TolAdminAgentBackupLogContinue_Out.FLog.D_Path
                    );
                m_backupFileName = fXmlNodeOutLog.get_elemVal(
                    FADMADS_TolAdminAgentBackupLogContinue_Out.FLog.A_BackupFile,
                    FADMADS_TolAdminAgentBackupLogContinue_Out.FLog.D_BackupFile
                    );
                m_fileName = fXmlNodeOutLog.get_elemVal(
                    FADMADS_TolAdminAgentBackupLogContinue_Out.FLog.A_File,
                    FADMADS_TolAdminAgentBackupLogContinue_Out.FLog.D_File
                    );

                // --

                // ***
                // Temp Directory create
                // ***
                tempFilePath = Path.Combine(m_fAdmCore.fWsmCore.tempPath, Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempFilePath);

                // --

                fFtp = FCommon.createFtp(m_fAdmCore);
                // --
                fFtp.downloadFiles(tempFilePath, Path.GetFileName(zipFileName));
                fFtp.deleteFiles(Path.GetFileName(zipFileName));

                // --

                // ***
                // Download File unpack
                // ***
                F7Zip.unpack(tempFilePath + "\\" + zipFileName, tempFilePath);
                F7Zip.unpack(Path.Combine(tempFilePath, m_backupFileName), tempFilePath);

                // --

                fileName = tempFilePath + "\\" + Path.GetFileName(this.fileName);
                txtLog.openLogFile(fileName);
                setLogFileSize(fileName);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInLog = null;
                fXmlNodeOut = null;
                fXmlNodeOutLog = null;
                fFtp = null;

                // --

                FCommon.deleteDirectory(tempFilePath);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FApplicationLogViewer Form Event Handler

        private void FApplicationLogViewer_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                ((FontListTool)mnuMenu.Tools[FMenuKey.MenuAlvFontName]).Text = m_fAdmCore.fOption.fontName;
                numFontSize.Value = m_fAdmCore.fOption.fontSize;

                // --

                txtLog.Appearance.FontData.Name = ((FontListTool)mnuMenu.Tools[FMenuKey.MenuAlvFontName]).Value.ToString();
                txtLog.Appearance.FontData.SizeInPoints = float.Parse(numFontSize.Value.ToString());

                // --

                designGridOfIndex();

                // --

                m_fAdmCore.fOption.fChildFormList.add(this, this.Text + " - [" + m_fileName + "]");
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        private void FApplicationLogViewer_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfIndex();

                // --

                grdList.Focus();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FApplicationLogViewer_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fAdmCore.fOption.fChildFormList.remove(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FApplicationLogViewer_KeyDown(
            object sender, 
            KeyEventArgs e
            )
        {
            try
            {
                if (e.KeyCode == Keys.F5)
                {
                    FCursor.waitCursor();
                    // --
                    refreshLog();
                    // --
                    FCursor.defaultCursor();
                }
            }
            catch (Exception ex)
            {
                FCursor.defaultCursor();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region mnuMenu Control Event Handler

        private void mnuMenu_ToolClick(
            object sender, 
            Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tool.Key == FMenuKey.MenuAlvFind)
                {
                    txtLog.showSearcher();
                }
                else if (e.Tool.Key == FMenuKey.MenuAlvRefresh)
                {
                    refreshGridOfIndex();
                }
                else if (e.Tool.Key == FMenuKey.MenuAlvPrevious)
                {
                    continueLogFile(FLogContinuity.Previous);
                }
                else if (e.Tool.Key == FMenuKey.MenuAlvNext)
                {
                    continueLogFile(FLogContinuity.Next);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void mnuMenu_ToolValueChanged(
            object sender, 
            ToolEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --
                
                if (e.Tool.Key == FMenuKey.MenuAlvFontName)
                {
                    procMenuChangeFontName();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void mnuMenu_AfterToolDeactivate(
            object sender,
            ToolEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tool.Key == FMenuKey.MenuAlvFontName)
                {
                    if (!procMenuChangeFontName())
                    {
                        ((FontListTool)mnuMenu.Tools[FMenuKey.MenuAlvFontName]).Value = m_fAdmCore.fOption.fontName;
                        txtLog.Appearance.FontData.Name = m_fAdmCore.fOption.fontName;
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region grdList Control Event Handler

        private void grdList_AfterRowActivate(
            object sender,
            EventArgs e
            )
        {
            int startIndex = 0;
            int position = 0;

            try
            {
                FCursor.waitCursor();

                // --

                startIndex = int.Parse(grdList.activeDataRowKey);
                position = txtLog.Text.IndexOf(">", startIndex);
                // --
                txtLog.Select(startIndex, position - startIndex + 1);
                txtLog.ScrollToCaret();                
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void grdList_AfterRowFilterChanged(
            object sender,
            Infragistics.Win.UltraWinGrid.AfterRowFilterChangedEventArgs e
            )
        {
            int activateIndex = -1;

            try
            {
                FCursor.waitCursor();

                // --

                if (e.Rows.VisibleRowCount == 0)
                {
                    return;
                }

                // --

                grdList.beginUpdate();

                // --

                grdList.Selected.Rows.Clear();
                foreach (UltraGridRow r in e.Rows.GetFilteredInNonGroupByRows())
                {
                    if (r == grdList.ActiveRow)
                    {
                        activateIndex = r.VisibleIndex;
                        break;
                    }
                }
                // --
                if (activateIndex == -1)
                {
                    activateIndex = e.Rows.VisibleRowCount - 1;
                }
                grdList.ActiveRow = e.Rows.GetRowAtVisibleIndex(activateIndex);
                grdList.DisplayLayout.RowScrollRegions[0].ScrollRowIntoView(grdList.ActiveRow);

                // --

                grdList.endUpdate();

                // --

                lblTotal.Text = grdList.Rows.VisibleRowCount.ToString("#,##0") + " / " + grdList.Rows.Count.ToString("#,##0");
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void grdList_DoubleClickRow(
            object sender, 
            Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                txtLog.Focus();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void grdList_KeyDown(
            object sender, 
            KeyEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.KeyCode == Keys.Enter)
                {
                    txtLog.Focus();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }
        
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region txtLog Control Event Handler

        private void txtLog_KeyDown(
            object sender,
            KeyEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --                

                if (e.Control && e.KeyCode == Keys.F)
                {
                    txtLog.showSearcher();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion    

        //------------------------------------------------------------------------------------------------------------------------

        #region numFontSize Control Event Handler

        private void numFontSize_BeforeExitEditMode(
            object sender, 
            Infragistics.Win.BeforeExitEditModeEventArgs e
            )
        {
            float fontSize = 0;

            try
            {
                FCursor.waitCursor();

                // --

                fontSize = float.Parse(numFontSize.Value.ToString());
                if (fontSize < FConstants.FontMinSize)
                {
                    numFontSize.Value = FConstants.FontMinSize;
                }
                else if (fontSize > FConstants.FontMaxSize)
                {
                    numFontSize.Value = FConstants.FontMaxSize;
                }

                // --

                procMenuChangeFontSize();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void numFontSize_EditorSpinButtonClick(
            object sender,
            Infragistics.Win.UltraWinEditors.SpinButtonClickEventArgs e
            )
        {
            float fontSize = 0;

            try
            {
                FCursor.waitCursor();

                // --

                fontSize = float.Parse(numFontSize.Value.ToString());
                if (e.ButtonType == Infragistics.Win.UltraWinEditors.SpinButtonItem.NextItem)
                {
                    numFontSize.Value = fontSize < FConstants.FontMaxSize ? (int)++fontSize : FConstants.FontMaxSize;
                }
                else if (e.ButtonType == Infragistics.Win.UltraWinEditors.SpinButtonItem.PreviousItem)
                {
                    numFontSize.Value = fontSize > FConstants.FontMinSize ? (int)--fontSize : FConstants.FontMinSize;
                }

                // --

                procMenuChangeFontSize();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void numFontSize_KeyDown(
            object sender,
            KeyEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.KeyCode == Keys.Enter)
                {
                    procMenuChangeFontSize();
                    txtLog.Focus();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion             

        //------------------------------------------------------------------------------------------------------------------------

        #region rstToolbar Control Event Handler

        private void rstToolbar_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdList.searchGridRow(e.searchWord))
                {
                    FMessageBox.showInformation("Search", m_fAdmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { e.searchWord }), this);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion                        

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
