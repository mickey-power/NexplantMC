/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FSecs1ToHsmsConverterLogViewer.cs
--  Creator         : spike.lee
--  Create Date     : 2017.05.15
--  Description     : FAmate Admin Manager SECS1 To HSMS Converter Log Viewer Form Class 
--  History         : Created by spike.lee at 2017.05.15
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using System.IO;
using System.Text;
using Infragistics.Win.UltraWinToolbars;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public partial class FSecs1ToHsmsConverterLogViewer : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private string m_converter = string.Empty;
        private string m_backupFileName = string.Empty;
        private string m_fileName = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecs1ToHsmsConverterLogViewer(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecs1ToHsmsConverterLogViewer(
            FAdmCore fAdmCore
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecs1ToHsmsConverterLogViewer(
            FAdmCore fAdmCore,
            string convereter,
            string backupFileName,
            string fileName
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
            m_converter = convereter;
            m_backupFileName = backupFileName;
            m_fileName = fileName;
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

        public string converter
        {
            get
            {
                try
                {
                    return m_converter;
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

        public string backupFileName
        {
            get
            {
                try
                {
                    return m_backupFileName;
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

        private void controlMenu(
            )
        {
            try
            {
                mnuMenu.beginUpdate();

                // --

                mnuMenu.Tools[FMenuKey.MenuS2HCvtLogViewerRefresh].SharedProps.Enabled = m_fileName == string.Empty ? false : true;
                // --
                mnuMenu.Tools[FMenuKey.MenuS2HCvtLogViewerFind].SharedProps.Enabled = true;

                // --

                mnuMenu.endUpdate();
            }
            catch (Exception ex)
            {
                mnuMenu.endUpdate();
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
                preFontName = ((FontListTool)mnuMenu.Tools[FMenuKey.MenuS2HCvtLogViewerFontName]).Value.ToString();
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

        private void setFileInfo(
            string fileName
            )
        {
            FileInfo fileInfo = null;
            string toTime = string.Empty;
            DateTime tmpDateTime;
            int index = 0;

            try
            {
                fileInfo = new FileInfo(fileName);
                txtSize.Text = FDataConvert.volumeSizeToString(fileInfo.Length, FVolumnOption.KiloByte);

                // --

                txtFromTime.Text = txtLog.Text.Substring(1, 23);

                // --

                index = txtLog.Text.Length - 1;
                do
                {
                    index = txtLog.Text.LastIndexOf(']', index);
                    if (index < 24)
                    {
                        toTime = string.Empty;
                        break;
                    }
                    // --
                    toTime = txtLog.Text.Substring(index - 23, 23);
                    index -= 1;
                } while (!DateTime.TryParse(toTime, out tmpDateTime));
                // --
                txtToTime.Text = toTime;
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

        private void loadSecs1ToHsmsConvereterLogFile(
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
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TolSecs1ToHsmsConverterLogDownload_In.E_ADMADS_TolSecs1ToHsmsConverterLogDownload_In);
                fXmlNodeIn.set_elemVal(FADMADS_TolSecs1ToHsmsConverterLogDownload_In.A_hLanguage, FADMADS_TolSecs1ToHsmsConverterLogDownload_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TolSecs1ToHsmsConverterLogDownload_In.A_hFactory, FADMADS_TolSecs1ToHsmsConverterLogDownload_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TolSecs1ToHsmsConverterLogDownload_In.A_hUserId, FADMADS_TolSecs1ToHsmsConverterLogDownload_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TolSecs1ToHsmsConverterLogDownload_In.A_hStep, FADMADS_TolSecs1ToHsmsConverterLogDownload_In.D_hStep, "1");
                // --
                fXmlNodeInLog = fXmlNodeIn.set_elem(FADMADS_TolSecs1ToHsmsConverterLogDownload_In.FLog.E_Log);
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolSecs1ToHsmsConverterLogDownload_In.FLog.A_Converter, 
                    FADMADS_TolSecs1ToHsmsConverterLogDownload_In.FLog.D_Converter, 
                    m_converter
                    );
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolSecs1ToHsmsConverterLogDownload_In.FLog.A_File, 
                    FADMADS_TolSecs1ToHsmsConverterLogDownload_In.FLog.D_File, 
                    Path.GetFileName(m_fileName)
                    );

                // --

                FADMADSCaster.ADMADS_TolSecs1ToHsmsConverterLogDownload_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_TolSecs1ToHsmsConverterLogDownload_Out.A_hStatus, FADMADS_TolSecs1ToHsmsConverterLogDownload_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_TolSecs1ToHsmsConverterLogDownload_Out.A_hStatusMessage, FADMADS_TolSecs1ToHsmsConverterLogDownload_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeOutLog = fXmlNodeOut.get_elem(FADMADS_TolSecs1ToHsmsConverterLogDownload_Out.FLog.E_Log);
                zipFileName = fXmlNodeOutLog.get_elemVal(
                    FADMADS_TolSecs1ToHsmsConverterLogDownload_Out.FLog.A_Path, 
                    FADMADS_TolSecs1ToHsmsConverterLogDownload_Out.FLog.D_Path
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

                // --

                txtLog.openLogFile(fileName);
                setFileInfo(fileName);
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

        private void loadSecs1ToHsmsConverterBackupLogFile(
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
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TolSecs1ToHsmsConverterBackupLogDownload_In.E_ADMADS_TolSecs1ToHsmsConverterBackupLogDownload_In);
                fXmlNodeIn.set_elemVal(FADMADS_TolSecs1ToHsmsConverterBackupLogDownload_In.A_hLanguage, FADMADS_TolSecs1ToHsmsConverterBackupLogDownload_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TolSecs1ToHsmsConverterBackupLogDownload_In.A_hFactory, FADMADS_TolSecs1ToHsmsConverterBackupLogDownload_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TolSecs1ToHsmsConverterBackupLogDownload_In.A_hUserId, FADMADS_TolSecs1ToHsmsConverterBackupLogDownload_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TolSecs1ToHsmsConverterBackupLogDownload_In.A_hStep, FADMADS_TolSecs1ToHsmsConverterBackupLogDownload_In.D_hStep, "1");
                // --
                fXmlNodeInLog = fXmlNodeIn.set_elem(FADMADS_TolSecs1ToHsmsConverterBackupLogDownload_In.FLog.E_Log);
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolSecs1ToHsmsConverterBackupLogDownload_In.FLog.A_Converter,
                    FADMADS_TolSecs1ToHsmsConverterBackupLogDownload_In.FLog.D_Converter,
                    m_converter
                    );
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolSecs1ToHsmsConverterBackupLogDownload_In.FLog.A_File,
                    FADMADS_TolSecs1ToHsmsConverterBackupLogDownload_In.FLog.D_File,
                    m_backupFileName
                    );

                // --

                FADMADSCaster.ADMADS_TolSecs1ToHsmsConverterBackupLogDownload_Req(
                     m_fAdmCore.fH101,
                     fXmlNodeIn,
                     ref fXmlNodeOut
                     );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_TolSecs1ToHsmsConverterBackupLogDownload_Out.A_hStatus, FADMADS_TolSecs1ToHsmsConverterBackupLogDownload_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_TolSecs1ToHsmsConverterBackupLogDownload_Out.A_hStatusMessage, FADMADS_TolSecs1ToHsmsConverterBackupLogDownload_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeOutLog = fXmlNodeOut.get_elem(FADMADS_TolSecs1ToHsmsConverterBackupLogDownload_Out.FLog.E_Log);
                zipFileName = fXmlNodeOutLog.get_elemVal(
                    FADMADS_TolSecs1ToHsmsConverterBackupLogDownload_Out.FLog.A_Path,
                    FADMADS_TolSecs1ToHsmsConverterBackupLogDownload_Out.FLog.D_Path
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

                // --

                txtLog.openLogFile(fileName);
                setFileInfo(fileName);
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

                if (m_backupFileName == string.Empty)
                {
                    loadSecs1ToHsmsConvereterLogFile();
                }
                else
                {
                    loadSecs1ToHsmsConverterBackupLogFile();
                }

                // --

                txtLog.Select(txtLog.TextLength, 0);
                txtLog.ScrollToCaret();
                txtLog.Focus();

                // --

                txtLogType.Text = "Converter - [ " + m_converter + " ]";
                txtFileName.Text = Path.GetFileName(m_fileName);
                controlMenu();

                // --

                txtLog.Focus();
            }
            catch (Exception ex)
            {
                if (fProgress != null)
                {
                    fProgress.Dispose();
                    fProgress = null;
                }

                // --

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

        private void continueSecs1ToHsmsConverterLogFile(
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
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TolSecs1ToHsmsConverterLogContinue_In.E_ADMADS_TolSecs1ToHsmsConverterLogContinue_In);
                fXmlNodeIn.set_elemVal(FADMADS_TolSecs1ToHsmsConverterLogContinue_In.A_hLanguage, FADMADS_TolSecs1ToHsmsConverterLogContinue_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TolSecs1ToHsmsConverterLogContinue_In.A_hFactory, FADMADS_TolSecs1ToHsmsConverterLogContinue_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TolSecs1ToHsmsConverterLogContinue_In.A_hUserId, FADMADS_TolSecs1ToHsmsConverterLogContinue_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TolSecs1ToHsmsConverterLogContinue_In.A_hStep, FADMADS_TolSecs1ToHsmsConverterLogContinue_In.D_hStep, "1");
                // --
                fXmlNodeInLog = fXmlNodeIn.set_elem(FADMADS_TolSecs1ToHsmsConverterLogContinue_In.FLog.E_Log);
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolSecs1ToHsmsConverterLogContinue_In.FLog.A_Converter,
                    FADMADS_TolSecs1ToHsmsConverterLogContinue_In.FLog.D_Converter,
                    m_converter
                    );
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolSecs1ToHsmsConverterLogContinue_In.FLog.A_File,
                    FADMADS_TolSecs1ToHsmsConverterLogContinue_In.FLog.D_File,
                    Path.GetFileName(m_fileName)
                    );
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolSecs1ToHsmsConverterLogContinue_In.FLog.A_Type,
                    FADMADS_TolSecs1ToHsmsConverterLogContinue_In.FLog.D_Type,
                    FLogType.Application.ToString()
                    );
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolSecs1ToHsmsConverterLogContinue_In.FLog.A_Continuity,
                    FADMADS_TolSecs1ToHsmsConverterLogContinue_In.FLog.D_Continuity,
                    fLogContinuity.ToString()
                    );

                // --

                FADMADSCaster.ADMADS_TolSecs1ToHsmsConverterLogContinue_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_TolSecs1ToHsmsConverterLogContinue_Out.A_hStatus, FADMADS_TolSecs1ToHsmsConverterLogContinue_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_TolSecs1ToHsmsConverterLogContinue_Out.A_hStatusMessage, FADMADS_TolSecs1ToHsmsConverterLogContinue_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeOutLog = fXmlNodeOut.get_elem(FADMADS_TolSecs1ToHsmsConverterLogContinue_Out.FLog.E_Log);
                zipFileName = fXmlNodeOutLog.get_elemVal(
                    FADMADS_TolSecs1ToHsmsConverterLogContinue_Out.FLog.A_Path,
                    FADMADS_TolSecs1ToHsmsConverterLogContinue_Out.FLog.D_Path
                    );
                m_fileName = fXmlNodeOutLog.get_elemVal(
                    FADMADS_TolSecs1ToHsmsConverterLogContinue_Out.FLog.A_File,
                    FADMADS_TolSecs1ToHsmsConverterLogContinue_Out.FLog.D_File
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

                // --

                txtLog.openLogFile(fileName);
                setFileInfo(fileName);
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

        private void continueSecs1ToHsmsConverterBackupLogFile(
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
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TolSecs1ToHsmsConverterBackupLogContinue_In.E_ADMADS_TolSecs1ToHsmsConverterBackupLogContinue_In);
                fXmlNodeIn.set_elemVal(FADMADS_TolSecs1ToHsmsConverterBackupLogContinue_In.A_hLanguage, FADMADS_TolSecs1ToHsmsConverterBackupLogContinue_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TolSecs1ToHsmsConverterBackupLogContinue_In.A_hFactory, FADMADS_TolSecs1ToHsmsConverterBackupLogContinue_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TolSecs1ToHsmsConverterBackupLogContinue_In.A_hUserId, FADMADS_TolSecs1ToHsmsConverterBackupLogContinue_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TolSecs1ToHsmsConverterBackupLogContinue_In.A_hStep, FADMADS_TolSecs1ToHsmsConverterBackupLogContinue_In.D_hStep, "1");
                // --
                fXmlNodeInLog = fXmlNodeIn.set_elem(FADMADS_TolSecs1ToHsmsConverterBackupLogContinue_In.FLog.E_Log);
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolSecs1ToHsmsConverterBackupLogContinue_In.FLog.A_Converter,
                    FADMADS_TolSecs1ToHsmsConverterBackupLogContinue_In.FLog.D_Converter,
                    m_converter
                    );
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolSecs1ToHsmsConverterBackupLogContinue_In.FLog.A_Type,
                    FADMADS_TolSecs1ToHsmsConverterBackupLogContinue_In.FLog.D_Type,
                    FLogType.Application.ToString()
                    );
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolSecs1ToHsmsConverterBackupLogContinue_In.FLog.A_BackupFile,
                    FADMADS_TolSecs1ToHsmsConverterBackupLogContinue_In.FLog.D_BackupFile,
                    m_backupFileName
                    );
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolSecs1ToHsmsConverterBackupLogContinue_In.FLog.A_File,
                    FADMADS_TolSecs1ToHsmsConverterBackupLogContinue_In.FLog.D_File,
                    m_fileName
                    );
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolSecs1ToHsmsConverterBackupLogContinue_In.FLog.A_Continuity,
                    FADMADS_TolSecs1ToHsmsConverterBackupLogContinue_In.FLog.D_Continuity,
                    fLogContinuity.ToString()
                    );

                // --

                FADMADSCaster.ADMADS_TolSecs1ToHsmsConverterBackupLogContinue_Req(
                     m_fAdmCore.fH101,
                     fXmlNodeIn,
                     ref fXmlNodeOut
                     );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_TolSecs1ToHsmsConverterBackupLogContinue_Out.A_hStatus, FADMADS_TolSecs1ToHsmsConverterBackupLogContinue_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_TolSecs1ToHsmsConverterBackupLogContinue_Out.A_hStatusMessage, FADMADS_TolSecs1ToHsmsConverterBackupLogContinue_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeOutLog = fXmlNodeOut.get_elem(FADMADS_TolSecs1ToHsmsConverterBackupLogContinue_Out.FLog.E_Log);
                zipFileName = fXmlNodeOutLog.get_elemVal(
                    FADMADS_TolSecs1ToHsmsConverterBackupLogContinue_Out.FLog.A_Path,
                    FADMADS_TolSecs1ToHsmsConverterBackupLogContinue_Out.FLog.D_Path
                    );
                m_backupFileName = fXmlNodeOutLog.get_elemVal(
                    FADMADS_TolSecs1ToHsmsConverterBackupLogContinue_Out.FLog.A_BackupFile,
                    FADMADS_TolSecs1ToHsmsConverterBackupLogContinue_Out.FLog.D_BackupFile
                    );
                m_fileName = fXmlNodeOutLog.get_elemVal(
                    FADMADS_TolSecs1ToHsmsConverterBackupLogContinue_Out.FLog.A_File,
                    FADMADS_TolSecs1ToHsmsConverterBackupLogContinue_Out.FLog.D_File
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

                // --

                txtLog.openLogFile(fileName);
                setFileInfo(fileName);
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

        private void continueLog(
            FLogContinuity fLogContinuity
            )
        {
            FProgress fProgress = null;

            try
            {
                fProgress = new FProgress();
                fProgress.show(m_fAdmCore.fWsmCore.fWsmContainer);

                // -- 

                if (m_backupFileName == string.Empty)
                {
                    continueSecs1ToHsmsConverterLogFile(fLogContinuity);                    
                }
                else
                {
                    continueSecs1ToHsmsConverterBackupLogFile(fLogContinuity);
                }

                // --

                if (fLogContinuity == FLogContinuity.Previous)
                {
                    txtLog.Select(txtLog.TextLength, 0);
                }
                else
                {
                    txtLog.Select(0, 0);
                }
                txtLog.ScrollToCaret();
                txtLog.Focus();

                // --

                txtLogType.Text = "Converter - [ " + m_converter + " ]";
                txtFileName.Text = Path.GetFileName(m_fileName);
                controlMenu();
            }
            catch (Exception ex)
            {
                if (fProgress != null)
                {
                    fProgress.Dispose();
                    fProgress = null;
                }

                // --

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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FSecs1ToHsmsConverterLogViewer Form Event Handler

        private void FSecs1ToHsmsConverterLogViewer_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                ((FontListTool)mnuMenu.Tools[FMenuKey.MenuS2HCvtLogViewerFontName]).Text = m_fAdmCore.fOption.fontName;
                numFontSize.Value = m_fAdmCore.fOption.fontSize;

                // --

                txtLog.Appearance.FontData.Name = ((FontListTool)mnuMenu.Tools[FMenuKey.MenuS2HCvtLogViewerFontName]).Value.ToString();
                txtLog.Appearance.FontData.SizeInPoints = float.Parse(numFontSize.Value.ToString());

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

        private void FSecs1ToHsmsConverterLogViewer_Shown(
            object sender, 
            EventArgs e
            )
        {

            try
            {
                FCursor.waitCursor();

                // --

                if (m_fileName == string.Empty)
                {
                    return;
                }

                // --

                refreshLog();

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

        private void FSecs1ToHsmsConverterLogViewer_FormClosing(
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

        private void FSecs1ToHsmsConverterLogViewer_KeyDown(
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

                if (e.Tool.Key == FMenuKey.MenuS2HCvtLogViewerRefresh)
                {
                    refreshLog();
                }
                else if (e.Tool.Key == FMenuKey.MenuS2HCvtLogViewerPrevious)
                {
                    continueLog(FLogContinuity.Previous);
                }
                else if (e.Tool.Key == FMenuKey.MenuS2HCvtLogViewerNext)
                {
                    continueLog(FLogContinuity.Next);
                }
                if (e.Tool.Key == FMenuKey.MenuS2HCvtLogViewerFind)
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

                if (e.Tool.Key == FMenuKey.MenuS2HCvtLogViewerFontName)
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

                if (e.Tool.Key == FMenuKey.MenuS2HCvtLogViewerFontName)
                {
                    if (!procMenuChangeFontName())
                    {
                        ((FontListTool)mnuMenu.Tools[FMenuKey.MenuS2HCvtLogViewerFontName]).Value = m_fAdmCore.fOption.fontName;
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

    }   // Class end
}   // Namespace end
