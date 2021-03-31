/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FSecsTotalLogViewer.cs
--  Creator         : hongmi.park
--  Create Date     : 2020.08.26
--  Description     : Nexplant MC Admin Manager SECS Log Total Viewer Form Class 
--  History         : Created by hongmi.park at 2020.08.26           
----------------------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Nexplant.MC.AdminManager.FaSecsLogViewer;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public partial class FSecsTotalLogViewer : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private string m_eapId = string.Empty;
        private string m_backupFileName = string.Empty;
        private string m_fileName = string.Empty;
        private FAdmCore m_fAdmCore = null;
        private FSecsDriverLog m_fSecsDriverLog = null;
        private FSecsLogFilter m_fLogFilter = null;
        private string m_beforeKey = string.Empty;
        private string m_selectTagKey = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecsTotalLogViewer(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsTotalLogViewer(
            FAdmCore fAdmCore,
            string fileName
            )
            : this(fAdmCore, string.Empty, string.Empty, fileName)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsTotalLogViewer(
            FAdmCore fAdmCore,
            string eapId,
            string backupFileName,
            string fileName
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
            m_eapId = eapId;
            m_backupFileName = backupFileName;
            m_fileName = fileName;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsTotalLogViewer(
            FAdmCore fAdmCore,
            string eapId,
            string backupFileName,
            string fileName,
            string beforeKey
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
            m_eapId = eapId;
            m_backupFileName = backupFileName;
            m_fileName = fileName;
            m_beforeKey = beforeKey;
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
                    if (m_fSecsDriverLog != null)
                    {
                        m_fSecsDriverLog.Dispose();
                        m_fSecsDriverLog = null;
                    }
                    // --
                    m_fAdmCore = null;
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public string eapId
        {
            get
            {
                try
                {
                    return m_eapId;
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

        #region Common Methods

        private void loadSecsLogFile(
            string beforeKey
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
            // --
            string key = string.Empty;

            try
            {
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TolEapLogDownload_In.E_ADMADS_TolEapLogDownload_In);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapLogDownload_In.A_hLanguage, FADMADS_TolEapLogDownload_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TolEapLogDownload_In.A_hFactory, FADMADS_TolEapLogDownload_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapLogDownload_In.A_hUserId, FADMADS_TolEapLogDownload_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapLogDownload_In.A_hStep, FADMADS_TolEapLogDownload_In.D_hStep, "1");
                // --
                fXmlNodeInLog = fXmlNodeIn.set_elem(FADMADS_TolEapLogDownload_In.FLog.E_Log);
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolEapLogDownload_In.FLog.A_Eap,
                    FADMADS_TolEapLogDownload_In.FLog.D_Eap,
                    m_eapId
                    );
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolEapLogDownload_In.FLog.A_File,
                    FADMADS_TolEapLogDownload_In.FLog.D_File,
                    Path.GetFileName(m_fileName)
                    );

                // --

                FADMADSCaster.ADMADS_TolEapLogDownload_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_TolEapLogDownload_Out.A_hStatus, FADMADS_TolEapLogDownload_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_TolEapLogDownload_Out.A_hStatusMessage, FADMADS_TolEapLogDownload_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeOutLog = fXmlNodeOut.get_elem(FADMADS_TolEapLogDownload_Out.FLog.E_Log);
                zipFileName = fXmlNodeOutLog.get_elemVal(
                    FADMADS_TolEapLogDownload_Out.FLog.A_Path,
                    FADMADS_TolEapLogDownload_Out.FLog.D_Path
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
                F7Zip.unpack(Path.Combine(tempFilePath, zipFileName), tempFilePath);

                // --

                tvwTree.beginUpdate();
                tvwTree.Nodes.Clear();
                tvwTree.endUpdate();

                clear();

                // --

                fileName = Path.Combine(tempFilePath, Path.GetFileName(this.fileName));
                txtSize.Text = getFileSize(fileName);

                // --

                m_fSecsDriverLog.openLogFile(fileName);
                // --
                if (m_fSecsDriverLog.fChildObjectLogCollection.count == 0)
                {
                    txtFromTime.Text = string.Empty;
                    txtToTime.Text = string.Empty;
                }
                else
                {
                    txtFromTime.Text = getLogTime(m_fSecsDriverLog.fChildObjectLogCollection[0]);
                    txtToTime.Text = getLogTime(m_fSecsDriverLog.fChildObjectLogCollection[m_fSecsDriverLog.fChildObjectLogCollection.count - 1]);
                }
                // --

                key = tabMain.ActiveTab.Key;
                // --
                if (key == "Log")
                {
                    loadTreeOfObjectLog(beforeKey, FLogContinuity.Previous);

                    // --

                    controlMenu();
                }
                else if (key == "Interface")
                {
                    loadGridOfObjectLog(beforeKey, FLogContinuity.Previous);

                    // --

                    controlInterfaceMenu();
                }

                
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

        private void loadSecsBackupLogFile(
            string beforeKey
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
            // --
            string key = string.Empty;

            try
            {
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TolEapBackupLogDownload_In.E_ADMADS_TolEapBackupLogDownload_In);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapBackupLogDownload_In.A_hLanguage, FADMADS_TolEapBackupLogDownload_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TolEapBackupLogDownload_In.A_hFactory, FADMADS_TolEapBackupLogDownload_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapBackupLogDownload_In.A_hUserId, FADMADS_TolEapBackupLogDownload_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapBackupLogDownload_In.A_hStep, FADMADS_TolEapBackupLogDownload_In.D_hStep, "1");
                // --
                fXmlNodeInLog = fXmlNodeIn.set_elem(FADMADS_TolEapBackupLogDownload_In.FLog.E_Log);
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolEapBackupLogDownload_In.FLog.A_Eap,
                    FADMADS_TolEapBackupLogDownload_In.FLog.D_Eap,
                    this.eapId
                    );
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolEapBackupLogDownload_In.FLog.A_File,
                    FADMADS_TolEapBackupLogDownload_In.FLog.D_File,
                    m_backupFileName
                    );

                // --

                FADMADSCaster.ADMADS_TolEapBackupLogDownload_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_TolEapBackupLogDownload_Out.A_hStatus, FADMADS_TolEapBackupLogDownload_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_TolEapBackupLogDownload_Out.A_hStatusMessage, FADMADS_TolEapBackupLogDownload_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeOutLog = fXmlNodeOut.get_elem(FADMADS_TolEapBackupLogDownload_Out.FLog.E_Log);
                zipFileName = fXmlNodeOutLog.get_elemVal(
                    FADMADS_TolEapBackupLogDownload_Out.FLog.A_Path,
                    FADMADS_TolEapBackupLogDownload_Out.FLog.D_Path
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
                F7Zip.unpack(Path.Combine(tempFilePath, zipFileName), tempFilePath);
                F7Zip.unpack(Path.Combine(tempFilePath, m_backupFileName), tempFilePath);

                // --

                tvwTree.beginUpdate();
                tvwTree.Nodes.Clear();
                tvwTree.endUpdate();
                // --
                clear();

                // --

                fileName = Path.Combine(tempFilePath, Path.GetFileName(this.fileName));
                txtSize.Text = getFileSize(fileName);

                // --

                m_fSecsDriverLog.openLogFile(fileName);
                // --
                if (m_fSecsDriverLog.fChildObjectLogCollection.count == 0)
                {
                    txtFromTime.Text = string.Empty;
                    txtToTime.Text = string.Empty;
                }
                else
                {
                    txtFromTime.Text = getLogTime(m_fSecsDriverLog.fChildObjectLogCollection[0]);
                    txtToTime.Text = getLogTime(m_fSecsDriverLog.fChildObjectLogCollection[m_fSecsDriverLog.fChildObjectLogCollection.count - 1]);
                }
                // --

                key = tabMain.ActiveTab.Key;
                // --
                if (key == "Log")
                {
                    loadTreeOfObjectLog(beforeKey, FLogContinuity.Previous);

                    // --

                    controlMenu();
                }
                else if (key == "Interface")
                {
                    loadGridOfObjectLog(beforeKey, FLogContinuity.Previous);

                    // --

                    controlInterfaceMenu();
                }
                
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

        public void continueSecsLog(
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
                    continueSecsLogFile(fLogContinuity);
                }
                else
                {
                    continueSecsBackupLogFile(fLogContinuity);
                }

                // --

                txtFileName.Text = m_fileName;
            }
            catch (Exception ex)
            {
                if (fProgress != null)
                {
                    fProgress.Dispose();
                    fProgress = null;
                }

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

        private void continueSecsLogFile(
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
            // --
            string key = string.Empty;

            try
            {
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TolEapLogContinue_In.E_ADMADS_TolEapLogContinue_In);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapLogContinue_In.A_hLanguage, FADMADS_TolEapLogContinue_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TolEapLogContinue_In.A_hFactory, FADMADS_TolEapLogContinue_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapLogContinue_In.A_hUserId, FADMADS_TolEapLogContinue_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapLogContinue_In.A_hStep, FADMADS_TolEapLogContinue_In.D_hStep, "1");
                // --
                fXmlNodeInLog = fXmlNodeIn.set_elem(FADMADS_TolEapLogContinue_In.FLog.E_Log);
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolEapLogContinue_In.FLog.A_Eap,
                    FADMADS_TolEapLogContinue_In.FLog.D_Eap,
                    m_eapId
                    );
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolEapLogContinue_In.FLog.A_Type,
                    FADMADS_TolEapLogContinue_In.FLog.D_Type,
                    FEapLogType.SECS.ToString()
                    );
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolEapLogContinue_In.FLog.A_File,
                    FADMADS_TolEapLogContinue_In.FLog.D_File,
                    m_fileName
                    );
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolEapLogContinue_In.FLog.A_Continuity,
                    FADMADS_TolEapLogContinue_In.FLog.D_Continuity,
                    fLogContinuity.ToString()
                    );

                // --

                FADMADSCaster.ADMADS_TolEapLogContinue_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_TolEapLogContinue_Out.A_hStatus, FADMADS_TolEapLogContinue_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_TolEapLogContinue_Out.A_hStatusMessage, FADMADS_TolEapLogContinue_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeOutLog = fXmlNodeOut.get_elem(FADMADS_TolEapLogContinue_Out.FLog.E_Log);
                zipFileName = fXmlNodeOutLog.get_elemVal(
                    FADMADS_TolEapLogContinue_Out.FLog.A_Path,
                    FADMADS_TolEapLogContinue_Out.FLog.D_Path
                    );
                m_fileName = fXmlNodeOutLog.get_elemVal(
                    FADMADS_TolEapLogContinue_Out.FLog.A_File,
                    FADMADS_TolEapLogContinue_Out.FLog.D_File
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
                F7Zip.unpack(Path.Combine(tempFilePath, zipFileName), tempFilePath);

                // --

                tvwTree.beginUpdate();
                tvwTree.Nodes.Clear();
                tvwTree.endUpdate();
                // --
                clear(); 
                
                // --

                fileName = Path.Combine(tempFilePath, Path.GetFileName(this.fileName));
                txtSize.Text = getFileSize(fileName);

                // --

                m_fSecsDriverLog.openLogFile(fileName);
                // --
                if (m_fSecsDriverLog.fChildObjectLogCollection.count == 0)
                {
                    txtFromTime.Text = string.Empty;
                    txtToTime.Text = string.Empty;
                }
                else
                {
                    txtFromTime.Text = getLogTime(m_fSecsDriverLog.fChildObjectLogCollection[0]);
                    txtToTime.Text = getLogTime(m_fSecsDriverLog.fChildObjectLogCollection[m_fSecsDriverLog.fChildObjectLogCollection.count - 1]);
                }
                // --

                key = tabMain.ActiveTab.Key;
                // --
                if (key == "Log")
                {
                    loadTreeOfObjectLog(string.Empty, fLogContinuity);

                    // --

                    controlMenu();
                }
                else if (key == "Interface")
                {
                    loadGridOfObjectLog(string.Empty, fLogContinuity);

                    // --

                    controlInterfaceMenu();
                }
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

        private void continueSecsBackupLogFile(
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
            // --
            string key = string.Empty;

            try
            {
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TolEapBackupLogContinue_In.E_ADMADS_TolEapBackupLogContinue_In);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapBackupLogContinue_In.A_hLanguage, FADMADS_TolEapBackupLogContinue_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TolEapBackupLogContinue_In.A_hFactory, FADMADS_TolEapBackupLogContinue_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapBackupLogContinue_In.A_hUserId, FADMADS_TolEapBackupLogContinue_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapBackupLogContinue_In.A_hStep, FADMADS_TolEapBackupLogContinue_In.D_hStep, "1");
                // --
                fXmlNodeInLog = fXmlNodeIn.set_elem(FADMADS_TolEapBackupLogContinue_In.FLog.E_Log);
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolEapBackupLogContinue_In.FLog.A_Eap,
                    FADMADS_TolEapBackupLogContinue_In.FLog.D_Eap,
                    this.eapId
                    );
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolEapBackupLogContinue_In.FLog.A_Type,
                    FADMADS_TolEapBackupLogContinue_In.FLog.D_Type,
                    FEapLogType.SECS.ToString()
                    );
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolEapBackupLogContinue_In.FLog.A_BackupFile,
                    FADMADS_TolEapBackupLogContinue_In.FLog.D_BackupFile,
                    m_backupFileName
                    );
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolEapBackupLogContinue_In.FLog.A_File,
                    FADMADS_TolEapBackupLogContinue_In.FLog.D_File,
                    m_fileName
                    );
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolEapBackupLogContinue_In.FLog.A_Continuity,
                    FADMADS_TolEapBackupLogContinue_In.FLog.D_Continuity,
                    fLogContinuity.ToString()
                    );

                // --

                FADMADSCaster.ADMADS_TolEapBackupLogContinue_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_TolEapBackupLogContinue_Out.A_hStatus, FADMADS_TolEapBackupLogContinue_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_TolEapBackupLogContinue_Out.A_hStatusMessage, FADMADS_TolEapBackupLogContinue_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeOutLog = fXmlNodeOut.get_elem(FADMADS_TolEapBackupLogContinue_Out.FLog.E_Log);
                zipFileName = fXmlNodeOutLog.get_elemVal(
                    FADMADS_TolEapBackupLogContinue_Out.FLog.A_Path,
                    FADMADS_TolEapBackupLogContinue_Out.FLog.D_Path
                    );
                m_backupFileName = fXmlNodeOutLog.get_elemVal(
                    FADMADS_TolEapBackupLogContinue_Out.FLog.A_BackupFile,
                    FADMADS_TolEapBackupLogContinue_Out.FLog.D_BackupFile
                    );
                m_fileName = fXmlNodeOutLog.get_elemVal(
                    FADMADS_TolEapBackupLogContinue_Out.FLog.A_File,
                    FADMADS_TolEapBackupLogContinue_Out.FLog.D_File
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
                F7Zip.unpack(Path.Combine(tempFilePath, zipFileName), tempFilePath);
                F7Zip.unpack(Path.Combine(tempFilePath, m_backupFileName), tempFilePath);

                // --

                tvwTree.beginUpdate();
                tvwTree.Nodes.Clear();
                tvwTree.endUpdate();
                // --
                clear();

                // --

                fileName = Path.Combine(tempFilePath, Path.GetFileName(this.fileName));
                txtSize.Text = getFileSize(fileName);

                // --

                m_fSecsDriverLog.openLogFile(fileName);
                // --
                if (m_fSecsDriverLog.fChildObjectLogCollection.count == 0)
                {
                    txtFromTime.Text = string.Empty;
                    txtToTime.Text = string.Empty;
                }
                else
                {
                    txtFromTime.Text = getLogTime(m_fSecsDriverLog.fChildObjectLogCollection[0]);
                    txtToTime.Text = getLogTime(m_fSecsDriverLog.fChildObjectLogCollection[m_fSecsDriverLog.fChildObjectLogCollection.count - 1]);
                }
                // --

                key = tabMain.ActiveTab.Key;
                // --
                if (key == "Log")
                {
                    loadTreeOfObjectLog(string.Empty, fLogContinuity);

                    // --

                    controlMenu();
                }
                else if (key == "Interface")
                {
                    loadGridOfObjectLog(string.Empty, fLogContinuity);

                    // -- 

                    controlInterfaceMenu();
                }
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

        private string writeHeader(
            FSecsDeviceDataMessageReceivedLog receivedLog
            )
        {
            StringBuilder logBuilder = null;

            try
            {
                logBuilder = new StringBuilder();

                // --

                if (receivedLog.isPrimary)
                {
                    logBuilder.AppendLine(
                        "[" + receivedLog.time + "] " +
                        "DataReceived, " +
                        "SecsDevice=<" + receivedLog.deviceName + ">, " +
                        "SessionId=<" + receivedLog.sessionId + ">, " +
                        "Length=<" + receivedLog.length + ">, " +
                        "W-Bit=<" + receivedLog.wBit.ToString() + ">"
                        );
                }
                else
                {
                    logBuilder.AppendLine(
                        "[" + receivedLog.time + "] " +
                        "DataReceived, " +
                        "SecsDevice=<" + receivedLog.deviceName + ">, " +
                        "SessionId=<" + receivedLog.sessionId + ">, " +
                        "Length=<" + receivedLog.length + ">, " +
                        "AutoReply=<" + receivedLog.autoReply.ToString() + ">"
                        );
                }
                // --
                logBuilder.AppendLine(
                    "[" + receivedLog.time + "] " +
                    "ResultCode=<" + receivedLog.fResultCode + ">, " +
                    "ResultMessage=<" + receivedLog.resultMessage + ">"
                    );

                // -- 

                return logBuilder.ToString();
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

        //------------------------------------------------------------------------------------------------------------------------

        public string writeHeader(
            FSecsDeviceDataMessageSentLog sentLog
            )
        {
            StringBuilder logBuilder = null;

            try
            {
                logBuilder = new StringBuilder();

                // --

                if (sentLog.isPrimary)
                {
                    logBuilder.AppendLine(
                        "[" + sentLog.time + "] " +
                        "DataSent, " +
                        "SecsDevice=<" + sentLog.deviceName + ">, " +
                        "SessionId=<" + sentLog.sessionId + ">, " +
                        "Length=<" + sentLog.length + ">, " +
                        "W-Bit=<" + sentLog.wBit.ToString() + ">"
                        );
                }
                else
                {
                    logBuilder.AppendLine(
                        "[" + sentLog.time + "] " +
                        "DataSent, " +
                        "SecsDevice=<" + sentLog.deviceName + ">, " +
                        "SessionId=<" + sentLog.sessionId + ">, " +
                        "Length=<" + sentLog.length + ">, " +
                        "AutoReply=<" + sentLog.autoReply.ToString() + ">"
                        );
                }
                // --
                logBuilder.AppendLine(
                    "[" + sentLog.time + "] " +
                    "ResultCode=<" + sentLog.fResultCode + ">, " +
                    "ResultMessage=<" + sentLog.resultMessage + ">"
                    );

                // --

                return logBuilder.ToString();
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

        //------------------------------------------------------------------------------------------------------------------------

        private string writeHeader(
            FHostDeviceDataMessageReceivedLog receivedLog
            )
        {
            StringBuilder logBuilder = null;

            try
            {
                logBuilder = new StringBuilder();

                // --

                logBuilder.AppendLine(
                    "[" + receivedLog.time + "] " +
                    "DataReceived, " +
                    "HostDevice=<" + receivedLog.deviceName + ">, " +
                    "SessionId=<" + receivedLog.sessionId + ">, " +
                    "TID=<" + receivedLog.tid + ">"
                    );
                logBuilder.AppendLine(
                    "[" + receivedLog.time + "] " +
                    "ResultCode=<" + receivedLog.fResultCode + ">, " +
                    "ResultMessage=<" + receivedLog.resultMessage + ">"
                    );

                // -- 

                return logBuilder.ToString();
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

        //------------------------------------------------------------------------------------------------------------------------

        public string writeHeader(
            FHostDeviceDataMessageSentLog sentLog
            )
        {
            StringBuilder logBuilder = null;

            try
            {
                logBuilder = new StringBuilder();

                // --

                logBuilder.AppendLine(
                    "[" + sentLog.time + "] " +
                    "DataSent, " +
                    "HostDevice=<" + sentLog.deviceName + ">, " +
                    "SessionId=<" + sentLog.sessionId + ">, " +
                    "TID=<" + sentLog.tid + ">"
                    );
                logBuilder.AppendLine(
                    "[" + sentLog.time + "] " +
                    "ResultCode=<" + sentLog.fResultCode + ">, " +
                    "ResultMessage=<" + sentLog.resultMessage + ">"
                    );

                // --

                return logBuilder.ToString();
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

        //------------------------------------------------------------------------------------------------------------------------

        public void refreshLog(
            )
        {
            string beforeKey = string.Empty;
            string key = string.Empty;

            try
            {
                key = tabMain.ActiveTab.Key;
                // --
                if (key == "Log")
                {
                    if (tvwTree.ActiveNode != null)
                    {
                        beforeKey = tvwTree.ActiveNode.Key;
                    }
                }
                else if (key == "Interface")
                {
                    if (grdList.activeDataRow != null)
                    {
                        beforeKey = grdList.activeDataRowKey;
                    }
                }

                // --
                refreshLog(beforeKey);
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

        public void refreshLog(
            string beforeKey
            )
        {
            FProgress fProgress = null;
            string key = string.Empty;

            try
            {
                fProgress = new FProgress();
                fProgress.show(m_fAdmCore.fWsmCore.fWsmContainer);

                // --

                if (m_backupFileName == string.Empty)
                {
                    loadSecsLogFile(beforeKey);
                }
                else
                {
                    loadSecsBackupLogFile(beforeKey);
                }

                // --

                key = tabMain.ActiveTab.Key;
                // --
                if (key == "Log")
                {
                    tvwTree.Focus();
                    if (
                        m_selectTagKey != string.Empty &&
                        tvwTree.GetNodeByKey(m_selectTagKey) != null
                        )
                    {
                        tvwTree.ActiveNode = tvwTree.GetNodeByKey(m_selectTagKey);
                        tvwTree.ActiveNode.Selected = true;
                    }


                    // --

                    if (!pgdProp.Enabled)
                    {
                        tvwTree_AfterActivate(null, null);
                        pgdProp.Enabled = true;
                    }
                }
                else if (key == "Interface")
                {
                    grdList.Focus();
                    if (
                        m_selectTagKey != string.Empty &&
                        grdList.Rows[grdList.getDataRowIndex(m_selectTagKey)] != null
                        )
                    {
                        grdList.ActiveRow = grdList.Rows[grdList.getDataRowIndex(m_selectTagKey)];
                    }
                }

                // --

                m_selectTagKey = string.Empty;
            }
            catch (Exception ex)
            {
                if (fProgress != null)
                {
                    fProgress.Dispose();
                    fProgress = null;
                }
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

        private void procMenuRefresh(
            )
        {
            try
            {
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

        private void procMenuPrevious(
            )
        {
            try
            {
                continueSecsLog(FLogContinuity.Previous);
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

        private void procMenuNext(
            )
        {
            try
            {
                continueSecsLog(FLogContinuity.Next);
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

        private void procMenuExpand(
            )
        {
            string key = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                key = tabMain.ActiveTab.Key;
                // --
                if (key == "Log")
                {
                    tvwTree.beginUpdate();
                    tvwTree.ActiveNode.ExpandAll();
                    tvwTree.endUpdate();
                }
                else if (key == "Interface")
                {
                    tvwInterfaceTree.beginUpdate();
                    tvwInterfaceTree.ActiveNode.ExpandAll();
                    tvwInterfaceTree.endUpdate();
                }
            }
            catch (Exception ex)
            {
                if (key == "Log")
                {
                    tvwTree.endUpdate();
                }
                else if (key == "interface")
                {
                    tvwInterfaceTree.endUpdate();
                }

                // --

                FCursor.defaultCursor();
                FDebug.throwException(ex);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuCollapse(
            )
        {
            string key = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                key = tabMain.ActiveTab.Key;
                // --
                if (key == "Log")
                {
                    tvwTree.beginUpdate();
                    tvwTree.ActiveNode.CollapseAll();
                    tvwTree.endUpdate();
                }
                else if (key == "Interface")
                {
                    tvwInterfaceTree.beginUpdate();
                    tvwInterfaceTree.ActiveNode.CollapseAll();
                    tvwInterfaceTree.endUpdate();
                }
            }
            catch (Exception ex)
            {
                if (key == "Log")
                {
                    tvwTree.endUpdate();
                }
                else if (key == "Interface")
                {
                    tvwInterfaceTree.endUpdate();
                }

                // --

                FCursor.defaultCursor();
                FDebug.throwException(ex);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuCopy(
            )
        {
            UltraTreeNode tNode = null;
            FIObjectLog fObjectLog = null;
            string key = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                key = tabMain.ActiveTab.Key;
                // --
                if (key == "Log")
                {
                    tNode = tvwTree.ActiveNode;
                }
                else if (key == "Interface")
                {
                    tNode = tvwInterfaceTree.ActiveNode;
                }
                // --
                fObjectLog = (FIObjectLog)tNode.Tag;

                // --

                if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog)
                {
                    ((FSecsDeviceDataMessageReceivedLog)fObjectLog).copy();
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog)
                {
                    ((FSecsDeviceDataMessageSentLog)fObjectLog).copy();
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsItemLog)
                {
                    ((FSecsItemLog)fObjectLog).copy();
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                {
                    ((FHostDeviceDataMessageReceivedLog)fObjectLog).copy();
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                {
                    ((FHostDeviceDataMessageSentLog)fObjectLog).copy();
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostItemLog)
                {
                    ((FHostItemLog)fObjectLog).copy();
                }
            }
            catch (Exception ex)
            {
                FCursor.defaultCursor();
                FDebug.throwException(ex);
            }
            finally
            {
                FCursor.defaultCursor();
                // --
                tNode = null;
                fObjectLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSmlViewer(
            )
        {
            FSmlLogViewer fSmlLogViewer = null;
            FIObjectLog fObjectLog = null;
            StringBuilder sb = null;
            string key = string.Empty;

            try
            {
                sb = new StringBuilder();

                // --

                key = tabMain.ActiveTab.Key;
                //--
                if (key == "Log")
                {
                    foreach (UltraTreeNode node in tvwTree.SelectedNodes)
                    {
                        fObjectLog = (FIObjectLog)node.Tag;
                        // -- 
                        if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog)
                        {
                            sb.Append(writeHeader((FSecsDeviceDataMessageReceivedLog)fObjectLog));
                            sb.Append(((FSecsDeviceDataMessageReceivedLog)fObjectLog).convertToSml());
                        }
                        else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog)
                        {
                            sb.Append(writeHeader((FSecsDeviceDataMessageSentLog)fObjectLog));
                            sb.Append(((FSecsDeviceDataMessageSentLog)fObjectLog).convertToSml());
                        }
                    }
                }
                else if (key == "Interface")
                {
                    foreach (UltraDataRow row in grdList.selectedDataRows)
                    {
                        fObjectLog = (FIObjectLog)row.Tag;
                        // -- 
                        if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog)
                        {
                            sb.Append(writeHeader((FSecsDeviceDataMessageReceivedLog)fObjectLog));
                            sb.Append(((FSecsDeviceDataMessageReceivedLog)fObjectLog).convertToSml());
                        }
                        else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog)
                        {
                            sb.Append(writeHeader((FSecsDeviceDataMessageSentLog)fObjectLog));
                            sb.Append(((FSecsDeviceDataMessageSentLog)fObjectLog).convertToSml());
                        }
                    }
                }

                // --

                foreach (FBaseTabChildForm f in m_fAdmCore.fAdmContainer.fChilds)
                {
                    if (f is FSmlLogViewer && ((FSmlLogViewer)f).fileName == string.Empty)
                    {
                        fSmlLogViewer = ((FSmlLogViewer)f);
                        fSmlLogViewer.appendSml(sb.ToString());
                        fSmlLogViewer.activate();
                        return;
                    }
                }

                // --

                fSmlLogViewer = new FSmlLogViewer(m_fAdmCore);
                fSmlLogViewer.appendSml(sb.ToString());
                m_fAdmCore.fAdmContainer.showChild(fSmlLogViewer);
                fSmlLogViewer.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fObjectLog = null;
                fSmlLogViewer = null;
                sb = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuVfeiViewer(
            )
        {
            FVfeiLogViewer fVfeiLogViewer = null;
            FIObjectLog fObjectLog = null;
            StringBuilder sb = null;
            string key = string.Empty;

            try
            {
                sb = new StringBuilder();

                // --

                key = tabMain.ActiveTab.Key;
                // --
                if (key == "Log")
                {
                    foreach (UltraTreeNode node in tvwTree.SelectedNodes)
                    {
                        fObjectLog = (FIObjectLog)node.Tag;
                        // -- 
                        if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                        {
                            sb.Append(writeHeader((FHostDeviceDataMessageReceivedLog)fObjectLog));
                            sb.Append(((FHostDeviceDataMessageReceivedLog)fObjectLog).convertToVfei());
                        }
                        else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                        {
                            sb.Append(writeHeader((FHostDeviceDataMessageSentLog)fObjectLog));
                            sb.Append(((FHostDeviceDataMessageSentLog)fObjectLog).convertToVfei());
                        }
                    }
                }
                else if (key == "Interface")
                {
                    foreach (UltraDataRow row in grdList.selectedDataRows)
                    {
                        fObjectLog = (FIObjectLog)row.Tag;
                        // -- 
                        if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                        {
                            sb.Append(writeHeader((FHostDeviceDataMessageReceivedLog)fObjectLog));
                            sb.Append(((FHostDeviceDataMessageReceivedLog)fObjectLog).convertToVfei());
                        }
                        else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                        {
                            sb.Append(writeHeader((FHostDeviceDataMessageSentLog)fObjectLog));
                            sb.Append(((FHostDeviceDataMessageSentLog)fObjectLog).convertToVfei());
                        }
                    }
                }

                // -- 

                foreach (FBaseTabChildForm f in m_fAdmCore.fAdmContainer.fChilds)
                {
                    if (f is FVfeiLogViewer && ((FVfeiLogViewer)f).fileName == string.Empty)
                    {
                        fVfeiLogViewer = ((FVfeiLogViewer)f);
                        fVfeiLogViewer.appendVfei(sb.ToString());
                        fVfeiLogViewer.activate();
                        return;
                    }
                }

                // --

                fVfeiLogViewer = new FVfeiLogViewer(m_fAdmCore);
                fVfeiLogViewer.appendVfei(sb.ToString());
                m_fAdmCore.fAdmContainer.showChild(fVfeiLogViewer);
                fVfeiLogViewer.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fObjectLog = null;
                fVfeiLogViewer = null;
                sb = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void searchParentLog(
            FIObjectLog fChildLog
            )
        {
            try
            {
                if (fChildLog.fObjectLogType == FObjectLogType.SecsItemLog)
                {
                    searchParentLog(((FSecsItemLog)fChildLog).fParent);
                }
                else if (fChildLog.fObjectLogType == FObjectLogType.HostItemLog)
                {
                    searchParentLog(((FHostItemLog)fChildLog).fParent);
                }
                else if (
                    fChildLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog ||
                    fChildLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog ||
                    fChildLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog ||
                    fChildLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog
                    )
                {
                    m_selectTagKey = fChildLog.logUniqueIdToString;
                }
                else
                {
                    m_selectTagKey = string.Empty;
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

        #region Log Viewer Methods

        private void setTitle(
            )
        {
            try
            {
                this.Text = m_fAdmCore.fWsmCore.fUIWizard.searchCaption(this.Text);
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

        private void designTreeOfLog(
            )
        {
            try
            {
                tvwTree.ImageList = new ImageList();
                // --
                tvwTree.ImageList.Images.Add("SecsDriverLog", Properties.Resources.SecsDriverLog);
                tvwTree.ImageList.Images.Add("SdvStateChangedLog_Closed", Properties.Resources.SdvStateChangedLog_Closed);
                tvwTree.ImageList.Images.Add("SdvStateChangedLog_Opened", Properties.Resources.SdvStateChangedLog_Opened);
                tvwTree.ImageList.Images.Add("SdvStateChangedLog_Connected", Properties.Resources.SdvStateChangedLog_Connected);
                tvwTree.ImageList.Images.Add("SdvStateChangedLog_Selected", Properties.Resources.SdvStateChangedLog_Selected);
                tvwTree.ImageList.Images.Add("SdvControlMessageReceivedLog", Properties.Resources.SdvControlMessageReceivedLog);
                tvwTree.ImageList.Images.Add("SdvControlMessageSentLog", Properties.Resources.SdvControlMessageSentLog);
                tvwTree.ImageList.Images.Add("SdvTelnetPacketReceivedLog", Properties.Resources.SdvTelnetPacketReceivedLog);
                tvwTree.ImageList.Images.Add("SdvTelnetPacketSentLog", Properties.Resources.SdvTelnetPacketSentLog);
                tvwTree.ImageList.Images.Add("SdvTelnetStateChangedLog", Properties.Resources.SdvTelnetStateChangedLog);
                tvwTree.ImageList.Images.Add("SdvHandshakeReceivedLog", Properties.Resources.SdvHandshakeReceivedLog);
                tvwTree.ImageList.Images.Add("SdvHandshakeSentLog", Properties.Resources.SdvHandshakeSentLog);
                tvwTree.ImageList.Images.Add("SdvBlockReceivedLog", Properties.Resources.SdvBlockReceivedLog);
                tvwTree.ImageList.Images.Add("SdvBlockSentLog", Properties.Resources.SdvBlockSentLog);
                tvwTree.ImageList.Images.Add("SdvDataMessageReceivedLog_Primary", Properties.Resources.SdvDataMessageReceivedLog_Primary);
                tvwTree.ImageList.Images.Add("SdvDataMessageReceivedLog_Secondary", Properties.Resources.SdvDataMessageReceivedLog_Secondary);
                tvwTree.ImageList.Images.Add("SdvDataMessageSentLog_Primary", Properties.Resources.SdvDataMessageSentLog_Primary);
                tvwTree.ImageList.Images.Add("SdvDataMessageSentLog_Secondary", Properties.Resources.SdvDataMessageSentLog_Secondary);
                tvwTree.ImageList.Images.Add("SecsItemLog_List", Properties.Resources.SecsItemLog_List);
                tvwTree.ImageList.Images.Add("SecsItemLog", Properties.Resources.SecsItemLog);
                tvwTree.ImageList.Images.Add("SdvDataReceivedLog", Properties.Resources.SdvDataReceivedLog);
                tvwTree.ImageList.Images.Add("SdvDataSentLog", Properties.Resources.SdvDataSentLog);
                tvwTree.ImageList.Images.Add("SdvSmlReceivedLog", Properties.Resources.SdvSmlReceivedLog);
                tvwTree.ImageList.Images.Add("SdvSmlSentLog", Properties.Resources.SdvSmlSentLog);
                tvwTree.ImageList.Images.Add("SdvErrorRaisedLog", Properties.Resources.SdvErrorRaisedLog);
                tvwTree.ImageList.Images.Add("SdvTimeoutRaisedLog", Properties.Resources.SdvTimeoutRaisedLog);
                tvwTree.ImageList.Images.Add("HdvStateChangedLog_Closed", Properties.Resources.HdvStateChangedLog_Closed);
                tvwTree.ImageList.Images.Add("HdvStateChangedLog_Opened", Properties.Resources.HdvStateChangedLog_Opened);
                tvwTree.ImageList.Images.Add("HdvStateChangedLog_Connected", Properties.Resources.HdvStateChangedLog_Connected);
                tvwTree.ImageList.Images.Add("HdvStateChangedLog_Selected", Properties.Resources.HdvStateChangedLog_Selected);
                tvwTree.ImageList.Images.Add("HdvDataMessageReceivedLog_Command", Properties.Resources.HdvDataMessageReceivedLog_Command);
                tvwTree.ImageList.Images.Add("HdvDataMessageReceivedLog_Unsolicited", Properties.Resources.HdvDataMessageReceivedLog_Unsolicited);
                tvwTree.ImageList.Images.Add("HdvDataMessageReceivedLog_Reply", Properties.Resources.HdvDataMessageReceivedLog_Reply);
                tvwTree.ImageList.Images.Add("HdvDataMessageSentLog_Command", Properties.Resources.HdvDataMessageSentLog_Command);
                tvwTree.ImageList.Images.Add("HdvDataMessageSentLog_Unsolicited", Properties.Resources.HdvDataMessageSentLog_Unsolicited);
                tvwTree.ImageList.Images.Add("HdvDataMessageSentLog_Reply", Properties.Resources.HdvDataMessageSentLog_Reply);
                tvwTree.ImageList.Images.Add("HostItemLog_List", Properties.Resources.HostItemLog_List);
                tvwTree.ImageList.Images.Add("HostItemLog", Properties.Resources.HostItemLog);
                tvwTree.ImageList.Images.Add("HdvVfeiReceivedLog", Properties.Resources.HdvVfeiReceivedLog);
                tvwTree.ImageList.Images.Add("HdvVfeiSentLog", Properties.Resources.HdvVfeiSentLog);
                tvwTree.ImageList.Images.Add("HdvErrorRaisedLog", Properties.Resources.HdvErrorRaisedLog);
                tvwTree.ImageList.Images.Add("SecsTriggerRaisedLog", Properties.Resources.SecsTriggerRaisedLog);
                tvwTree.ImageList.Images.Add("SecsTransmitterRaisedLog", Properties.Resources.SecsTransmitterRaisedLog);
                tvwTree.ImageList.Images.Add("HostTriggerRaisedLog", Properties.Resources.HostTriggerRaisedLog);
                tvwTree.ImageList.Images.Add("HostTransmitterRaisedLog", Properties.Resources.HostTransmitterRaisedLog);
                tvwTree.ImageList.Images.Add("JudgementPerformedLog", Properties.Resources.JudgementPerformedLog);
                tvwTree.ImageList.Images.Add("MapperPerformedLog", Properties.Resources.MapperPerformedLog);
                tvwTree.ImageList.Images.Add("EquipmentStateSetAltererPerformedLog", Properties.Resources.EquipmentStateSetAltererPerformedLog);
                tvwTree.ImageList.Images.Add("EquipmentStateAltererLog", Properties.Resources.EquipmentStateAltererLog);
                tvwTree.ImageList.Images.Add("DataSetLog", Properties.Resources.DataSetLog);
                tvwTree.ImageList.Images.Add("DataLog_List", Properties.Resources.DataLog_List);
                tvwTree.ImageList.Images.Add("DataLog", Properties.Resources.DataLog);
                tvwTree.ImageList.Images.Add("StoragePerformedLog", Properties.Resources.StoragePerformedLog);
                tvwTree.ImageList.Images.Add("RepositoryLog", Properties.Resources.RepositoryLog);
                tvwTree.ImageList.Images.Add("ColumnLog_List", Properties.Resources.ColumnLog_List);
                tvwTree.ImageList.Images.Add("ColumnLog", Properties.Resources.ColumnLog);
                tvwTree.ImageList.Images.Add("CallbackRaisedLog", Properties.Resources.CallbackRaisedLog);
                tvwTree.ImageList.Images.Add("BranchRaisedLog", Properties.Resources.BranchRaisedLog);
                tvwTree.ImageList.Images.Add("FunctionCalledLog", Properties.Resources.FunctionCalledLog);
                tvwTree.ImageList.Images.Add("CommentWritedLog", Properties.Resources.CommentWritedLog);
                tvwTree.ImageList.Images.Add("PauserRaisedLog", Properties.Resources.PauserRaisedLog);
                tvwTree.ImageList.Images.Add("EntryPointCalledLog", Properties.Resources.EntryPointCalledLog);
                tvwTree.ImageList.Images.Add("ApplicationWritedLog", Properties.Resources.ApplicationWritedLog);
                tvwTree.ImageList.Images.Add("ContentLog_List", Properties.Resources.ContentLog_List);
                tvwTree.ImageList.Images.Add("ContentLog", Properties.Resources.ContentLog);
                tvwTree.ImageList.Images.Add("Result_Warning", Properties.Resources.Result_Warning);
                tvwTree.ImageList.Images.Add("Result_Error", Properties.Resources.Result_Error);
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
            UltraTreeNode tNode = null;
            FIObjectLog fObjectLog = null;

            try
            {
                mnuMenu.beginUpdate();

                // --

                tNode = tvwTree.ActiveNode;
                if (tNode != null)
                {
                    fObjectLog = (FIObjectLog)tNode.Tag;
                }
                else
                {
                    fObjectLog = m_fSecsDriverLog;
                }

                // --

                mnuMenu.Tools[FMenuKey.MenuSlvFilter].SharedProps.Enabled = true;
                mnuMenu.Tools[FMenuKey.MenuSivSendMessage].SharedProps.Enabled = false;

                // -- 

                if (fObjectLog.fObjectLogType == FObjectLogType.SecsDriverLog)
                {
                    mnuMenu.Tools[FMenuKey.MenuSlvExpand].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuSlvCollapse].SharedProps.Enabled = false;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuSlvExpand].SharedProps.Enabled = true;
                    mnuMenu.Tools[FMenuKey.MenuSlvCollapse].SharedProps.Enabled = true;
                }

                // --

                if (
                    fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.SecsItemLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.HostItemLog
                    )
                {
                    mnuMenu.Tools[FMenuKey.MenuSlvCopy].SharedProps.Enabled = true;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuSlvCopy].SharedProps.Enabled = false;
                }

                // --

                if (
                    fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog
                    )
                {
                    mnuMenu.Tools[FMenuKey.MenuSlvConvertToSml].SharedProps.Enabled = true;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuSlvConvertToSml].SharedProps.Enabled = false;
                }

                // --

                if (
                   fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog ||
                   fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog
                   )
                {
                    mnuMenu.Tools[FMenuKey.MenuSlvConvertToVfei].SharedProps.Enabled = true;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuSlvConvertToVfei].SharedProps.Enabled = false;
                }

                // --

                if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                {
                    mnuMenu.Tools[FMenuKey.MenuSivSendMessage].SharedProps.Enabled = true;
                }

                mnuMenu.endUpdate();
            }
            catch (Exception ex)
            {
                mnuMenu.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
                fObjectLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        private void procMenuFilterSelector(
            )
        {
            FProgress fProgress = null;
            FSecsLogFilterSelector fLogFilterSelector = null;
            string beforeKey = string.Empty;

            try
            {
                fLogFilterSelector = new FSecsLogFilterSelector(m_fAdmCore, m_fLogFilter);
                if (fLogFilterSelector.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }
                m_fLogFilter = fLogFilterSelector.fLogFilter;
                m_fAdmCore.changeSecsLogFilter(m_fLogFilter);

                // --

                fProgress = new FProgress();
                fProgress.show(m_fAdmCore.fWsmCore.fWsmContainer);

                // --

                if (tvwTree.ActiveNode != null)
                {
                    beforeKey = tvwTree.ActiveNode.Key;
                }
                loadTreeOfObjectLog(beforeKey, FLogContinuity.Previous);
            }
            catch (Exception ex)
            {
                if (fProgress != null)
                {
                    fProgress.Dispose();
                    fProgress = null;
                }

                FDebug.throwException(ex);
            }
            finally
            {
                if (fProgress != null)
                {
                    fProgress.Dispose();
                    fProgress = null;
                }
                // --
                fLogFilterSelector = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSearch(
            string searchWord
            )
        {
            UltraTreeNode tNode = null;
            FIObjectLog fBaseLog = null;
            FIObjectLog fFirstLog = null;
            FIObjectLog fResultLog = null;

            try
            {
                tNode = tvwTree.ActiveNode;
                fBaseLog = (FIObjectLog)tNode.Tag;

                // --

                fFirstLog = m_fSecsDriverLog.searchLogSeries(fBaseLog, searchWord);
                if (fFirstLog == null)
                {
                    FMessageBox.showInformation("Search", m_fAdmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { searchWord }), this);
                    return;
                }

                // --

                tvwTree.beginUpdate();

                // --

                fResultLog = fFirstLog;
                tNode = null;
                // --
                while (tNode == null)
                {
                    if (!isEnabledEventsOfObjectLog(fResultLog))
                    {
                        fResultLog = m_fSecsDriverLog.searchLogSeries(fResultLog, searchWord);
                        if (fResultLog == null || fResultLog == fFirstLog)
                        {
                            break;
                        }
                        continue;
                    }

                    // --

                    expandTreeForSearch(fResultLog);
                    tNode = tvwTree.GetNodeByKey(fResultLog.logUniqueIdToString);
                }

                // --

                tvwTree.endUpdate();

                // --

                if (tNode == null)
                {
                    FMessageBox.showInformation("Search", m_fAdmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { searchWord }), this);
                }
                else
                {
                    tvwTree.ActiveNode = tNode;
                }
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
                fBaseLog = null;
                fFirstLog = null;
                fResultLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void expandTreeForSearch(
            FIObjectLog fObjectLog
            )
        {
            FIObjectLog fParentLog = null;
            UltraTreeNode tNodeParent = null;

            try
            {
                if (fObjectLog.fObjectLogType == FObjectLogType.SecsDriverLog)
                {
                    return;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceStateChangedLog)
                {
                    fParentLog = ((FSecsDeviceStateChangedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceErrorRaisedLog)
                {
                    fParentLog = ((FSecsDeviceErrorRaisedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTimeoutRaisedLog)
                {
                    fParentLog = ((FSecsDeviceTimeoutRaisedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTelnetStateChangedLog)
                {
                    fParentLog = ((FSecsDeviceTelnetStateChangedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTelnetPacketReceivedLog)
                {
                    fParentLog = ((FSecsDeviceTelnetPacketReceivedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTelnetPacketSentLog)
                {
                    fParentLog = ((FSecsDeviceTelnetPacketSentLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceHandshakeReceivedLog)
                {
                    fParentLog = ((FSecsDeviceHandshakeReceivedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceHandshakeSentLog)
                {
                    fParentLog = ((FSecsDeviceHandshakeSentLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceControlMessageReceivedLog)
                {
                    fParentLog = ((FSecsDeviceControlMessageReceivedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceControlMessageSentLog)
                {
                    fParentLog = ((FSecsDeviceControlMessageSentLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceBlockReceivedLog)
                {
                    fParentLog = ((FSecsDeviceBlockReceivedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceBlockSentLog)
                {
                    fParentLog = ((FSecsDeviceBlockSentLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog)
                {
                    fParentLog = ((FSecsDeviceDataMessageReceivedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog)
                {
                    fParentLog = ((FSecsDeviceDataMessageSentLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsItemLog)
                {
                    fParentLog = ((FSecsItemLog)fObjectLog).fParent;
                }
                // --
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceStateChangedLog)
                {
                    fParentLog = ((FHostDeviceStateChangedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceErrorRaisedLog)
                {
                    fParentLog = ((FHostDeviceErrorRaisedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                {
                    fParentLog = ((FHostDeviceDataMessageReceivedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                {
                    fParentLog = ((FHostDeviceDataMessageSentLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostItemLog)
                {
                    fParentLog = ((FHostItemLog)fObjectLog).fParent;
                }
                // --
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsTriggerRaisedLog)
                {
                    fParentLog = ((FSecsTriggerRaisedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsTransmitterRaisedLog)
                {
                    fParentLog = ((FSecsTransmitterRaisedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTriggerRaisedLog)
                {
                    fParentLog = ((FHostTriggerRaisedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTransmitterRaisedLog)
                {
                    fParentLog = ((FHostTransmitterRaisedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.MapperPerformedLog)
                {
                    fParentLog = ((FMapperPerformedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EquipmentStateSetAltererPerformedLog)
                {
                    fParentLog = ((FEquipmentStateSetAltererPerformedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.DataSetLog)
                {
                    fParentLog = ((FDataSetLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.DataLog)
                {
                    fParentLog = ((FDataLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.StoragePerformedLog)
                {
                    fParentLog = ((FStoragePerformedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.RepositoryLog)
                {
                    fParentLog = ((FRepositoryLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.ColumnLog)
                {
                    fParentLog = ((FColumnLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CallbackRaisedLog)
                {
                    fParentLog = ((FCallbackRaisedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.FunctionCalledLog)
                {
                    fParentLog = ((FFunctionCalledLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.BranchRaisedLog)
                {
                    fParentLog = ((FBranchRaisedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CommentWrittenLog)
                {
                    fParentLog = ((FCommentWrittenLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PauserRaisedLog)
                {
                    fParentLog = ((FPauserRaisedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EntryPointCalledLog)
                {
                    fParentLog = ((FEntryPointCalledLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.ApplicationWrittenLog)
                {
                    fParentLog = ((FApplicationWrittenLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.ContentLog)
                {
                    fParentLog = ((FContentLog)fObjectLog).fParent;
                }

                // --

                tNodeParent = tvwTree.GetNodeByKey(fParentLog.logUniqueIdToString);
                if (tNodeParent == null || !tNodeParent.Expanded)
                {
                    expandTreeForSearch(fParentLog);
                }

                // --

                if (tNodeParent == null)
                {
                    tNodeParent = tvwTree.GetNodeByKey(fParentLog.logUniqueIdToString);
                }
                tNodeParent.Expanded = true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fParentLog = null;
                tNodeParent = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private bool isEnabledEventsOfObjectLog(
            FIObjectLog fObjectLog
            )
        {
            FObjectLogType fType;

            try
            {
                fType = fObjectLog.fObjectLogType;

                // --

                if (fType == FObjectLogType.SecsDriverLog)
                {
                    return true;
                }
                else if (fType == FObjectLogType.SecsDeviceStateChangedLog)
                {
                    return m_fLogFilter.enabledEventsOfSecsDeviceState;
                }
                else if (fType == FObjectLogType.SecsDeviceErrorRaisedLog)
                {
                    return m_fLogFilter.enabledEventsOfSecsDeviceError;
                }
                else if (fType == FObjectLogType.SecsDeviceTimeoutRaisedLog)
                {
                    return m_fLogFilter.enabledEventsOfSecsDeviceTimeout;
                }
                else if (
                    fType == FObjectLogType.SecsDeviceTelnetStateChangedLog ||
                    fType == FObjectLogType.SecsDeviceTelnetPacketReceivedLog ||
                    fType == FObjectLogType.SecsDeviceTelnetPacketSentLog
                    )
                {
                    return m_fLogFilter.enabledEventsOfSecsDeviceTelnet;
                }
                else if (
                    fType == FObjectLogType.SecsDeviceHandshakeReceivedLog ||
                    fType == FObjectLogType.SecsDeviceHandshakeSentLog
                    )
                {
                    return m_fLogFilter.enabledEventsOfSecsDeviceHandshake;
                }
                else if (
                    fType == FObjectLogType.SecsDeviceControlMessageReceivedLog ||
                    fType == FObjectLogType.SecsDeviceControlMessageSentLog
                    )
                {
                    return m_fLogFilter.enabledEventsOfSecsDeviceControlMessage;
                }
                else if (
                    fType == FObjectLogType.SecsDeviceBlockReceivedLog ||
                    fType == FObjectLogType.SecsDeviceBlockSentLog
                    )
                {
                    return m_fLogFilter.enabledEventsOfSecsDeviceBlock;
                }
                else if (
                    fType == FObjectLogType.SecsDeviceDataMessageReceivedLog ||
                    fType == FObjectLogType.SecsDeviceDataMessageSentLog ||
                    fType == FObjectLogType.SecsItemLog
                    )
                {
                    return m_fLogFilter.enabledEventsOfSecsDeviceDataMessage;
                }
                else if (fType == FObjectLogType.HostDeviceStateChangedLog)
                {
                    return m_fLogFilter.enabledEventsOfHostDeviceState;
                }
                else if (fType == FObjectLogType.HostDeviceErrorRaisedLog)
                {
                    return m_fLogFilter.enabledEventsOfHostDeviceError;
                }
                else if (
                    fType == FObjectLogType.HostDeviceDataMessageReceivedLog ||
                    fType == FObjectLogType.HostDeviceDataMessageSentLog ||
                    fType == FObjectLogType.HostItemLog
                    )
                {
                    return m_fLogFilter.enabledEventsOfHostDeviceDataMessage;
                }
                else if (
                    fType == FObjectLogType.SecsTriggerRaisedLog ||
                    fType == FObjectLogType.SecsTransmitterRaisedLog ||
                    fType == FObjectLogType.HostTriggerRaisedLog ||
                    fType == FObjectLogType.HostTransmitterRaisedLog ||
                    fType == FObjectLogType.EquipmentStateSetAltererPerformedLog ||
                    fType == FObjectLogType.JudgementPerformedLog ||
                    fType == FObjectLogType.MapperPerformedLog ||
                    fType == FObjectLogType.DataSetLog ||
                    fType == FObjectLogType.DataLog ||
                    fType == FObjectLogType.StoragePerformedLog ||
                    fType == FObjectLogType.RepositoryLog ||
                    fType == FObjectLogType.ColumnLog ||
                    fType == FObjectLogType.CallbackRaisedLog ||
                    fType == FObjectLogType.FunctionCalledLog ||
                    fType == FObjectLogType.BranchRaisedLog ||
                    fType == FObjectLogType.CommentWrittenLog ||
                    fType == FObjectLogType.PauserRaisedLog ||
                    fType == FObjectLogType.EntryPointCalledLog
                    )
                {
                    return m_fLogFilter.enabledEventsOfScenario;
                }
                else if (
                    fType == FObjectLogType.ApplicationWrittenLog ||
                    fType == FObjectLogType.ContentLog
                    )
                {
                    return m_fLogFilter.enabledEventsOfApplication;
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private string getFileSize(
            string fileName
            )
        {
            FileInfo fileInfo = null;

            try
            {
                fileInfo = new FileInfo(fileName);
                return FDataConvert.volumeSizeToString(fileInfo.Length, FVolumnOption.KiloByte);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fileInfo = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private string getLogTime(
            FIObjectLog fObjectLog
            )
        {
            try
            {
                if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceStateChangedLog)
                {
                    return ((FSecsDeviceStateChangedLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceErrorRaisedLog)
                {
                    return ((FSecsDeviceErrorRaisedLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTimeoutRaisedLog)
                {
                    return ((FSecsDeviceTimeoutRaisedLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTelnetStateChangedLog)
                {
                    return ((FSecsDeviceTelnetStateChangedLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTelnetPacketReceivedLog)
                {
                    return ((FSecsDeviceTelnetPacketReceivedLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTelnetPacketSentLog)
                {
                    return ((FSecsDeviceTelnetPacketSentLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceHandshakeReceivedLog)
                {
                    return ((FSecsDeviceHandshakeReceivedLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceHandshakeSentLog)
                {
                    return ((FSecsDeviceHandshakeSentLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceControlMessageReceivedLog)
                {
                    return ((FSecsDeviceControlMessageReceivedLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceControlMessageSentLog)
                {
                    return ((FSecsDeviceControlMessageSentLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceBlockReceivedLog)
                {
                    return ((FSecsDeviceBlockReceivedLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceBlockSentLog)
                {
                    return ((FSecsDeviceBlockSentLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog)
                {
                    return ((FSecsDeviceDataMessageReceivedLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog)
                {
                    return ((FSecsDeviceDataMessageSentLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceStateChangedLog)
                {
                    return ((FHostDeviceStateChangedLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceErrorRaisedLog)
                {
                    return ((FHostDeviceErrorRaisedLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                {
                    return ((FHostDeviceDataMessageReceivedLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                {
                    return ((FHostDeviceDataMessageSentLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsTriggerRaisedLog)
                {
                    return ((FSecsTriggerRaisedLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsTransmitterRaisedLog)
                {
                    return ((FSecsTransmitterRaisedLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTriggerRaisedLog)
                {
                    return ((FHostTriggerRaisedLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTransmitterRaisedLog)
                {
                    return ((FHostTransmitterRaisedLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EquipmentStateSetAltererPerformedLog)
                {
                    return ((FEquipmentStateSetAltererPerformedLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.JudgementPerformedLog)
                {
                    return ((FJudgementPerformedLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.MapperPerformedLog)
                {
                    return ((FMapperPerformedLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.StoragePerformedLog)
                {
                    return ((FStoragePerformedLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CallbackRaisedLog)
                {
                    return ((FCallbackRaisedLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.FunctionCalledLog)
                {
                    return ((FFunctionCalledLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.BranchRaisedLog)
                {
                    return ((FBranchRaisedLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CommentWrittenLog)
                {
                    return ((FCommentWrittenLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PauserRaisedLog)
                {
                    return ((FPauserRaisedLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EntryPointCalledLog)
                {
                    return ((FEntryPointCalledLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.ApplicationWrittenLog)
                {
                    return ((FApplicationWrittenLog)fObjectLog).time;
                }
                return string.Empty;
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

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfObjectLog(
            string beforeKey,
            FLogContinuity fLogContinuity
           )
        {
            UltraTreeNode tNodeScdl = null;
            UltraTreeNode tNodeLog = null;
            UltraTreeNode tNodeChildLog = null;
            UltraTreeNode tNodeBeforeActived = null;

            try
            {
                tvwTree.beginUpdate();
                tvwTree.Nodes.Clear();

                // --

                // ***
                // SECS Driver Log Load
                // ***
                tNodeScdl = new UltraTreeNode(m_fSecsDriverLog.logUniqueIdToString);
                tNodeScdl.Tag = m_fSecsDriverLog;
                FCommon.refreshTreeNodeOfObjectLog(m_fSecsDriverLog, tvwTree, tNodeScdl);

                // --

                // ***
                // Log Object Load
                // ***
                foreach (FIObjectLog fObjectLog in m_fSecsDriverLog.fChildObjectLogCollection)
                {
                    if (isEnabledEventsOfObjectLog(fObjectLog))
                    {
                        tNodeLog = new UltraTreeNode(fObjectLog.logUniqueIdToString);
                        tNodeLog.Tag = fObjectLog;
                        FCommon.refreshTreeNodeOfObjectLog(fObjectLog, tvwTree, tNodeLog);

                        // --

                        if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog)
                        {
                            foreach (FSecsItemLog fSitl in ((FSecsDeviceDataMessageReceivedLog)fObjectLog).fChildSecsItemLogCollection)
                            {
                                tNodeChildLog = new UltraTreeNode(fSitl.logUniqueIdToString);
                                tNodeChildLog.Tag = fSitl;
                                FCommon.refreshTreeNodeOfObjectLog(fSitl, tvwTree, tNodeChildLog);
                                tNodeLog.Nodes.Add(tNodeChildLog);
                            }
                        }
                        else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog)
                        {
                            foreach (FSecsItemLog fSitl in ((FSecsDeviceDataMessageSentLog)fObjectLog).fChildSecsItemLogCollection)
                            {
                                tNodeChildLog = new UltraTreeNode(fSitl.logUniqueIdToString);
                                tNodeChildLog.Tag = fSitl;
                                FCommon.refreshTreeNodeOfObjectLog(fSitl, tvwTree, tNodeChildLog);
                                tNodeLog.Nodes.Add(tNodeChildLog);
                            }
                        }
                        else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                        {
                            foreach (FHostItemLog fHitl in ((FHostDeviceDataMessageReceivedLog)fObjectLog).fChildHostItemLogCollection)
                            {
                                tNodeChildLog = new UltraTreeNode(fHitl.logUniqueIdToString);
                                tNodeChildLog.Tag = fHitl;
                                FCommon.refreshTreeNodeOfObjectLog(fHitl, tvwTree, tNodeChildLog);
                                tNodeLog.Nodes.Add(tNodeChildLog);
                            }
                        }
                        else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                        {
                            foreach (FHostItemLog fHitl in ((FHostDeviceDataMessageSentLog)fObjectLog).fChildHostItemLogCollection)
                            {
                                tNodeChildLog = new UltraTreeNode(fHitl.logUniqueIdToString);
                                tNodeChildLog.Tag = fHitl;
                                FCommon.refreshTreeNodeOfObjectLog(fHitl, tvwTree, tNodeChildLog);
                                tNodeLog.Nodes.Add(tNodeChildLog);
                            }
                        }
                        else if (fObjectLog.fObjectLogType == FObjectLogType.MapperPerformedLog)
                        {
                            foreach (FDataSetLog fDtsl in ((FMapperPerformedLog)fObjectLog).fChildDataSetLogCollection)
                            {
                                tNodeChildLog = new UltraTreeNode(fDtsl.logUniqueIdToString);
                                tNodeChildLog.Tag = fDtsl;
                                FCommon.refreshTreeNodeOfObjectLog(fDtsl, tvwTree, tNodeChildLog);
                                tNodeLog.Nodes.Add(tNodeChildLog);
                            }
                        }
                        else if (fObjectLog.fObjectLogType == FObjectLogType.StoragePerformedLog)
                        {
                            foreach (FRepositoryLog fRpsl in ((FStoragePerformedLog)fObjectLog).fChildRepositoryLogCollection)
                            {
                                tNodeChildLog = new UltraTreeNode(fRpsl.logUniqueIdToString);
                                tNodeChildLog.Tag = fRpsl;
                                FCommon.refreshTreeNodeOfObjectLog(fRpsl, tvwTree, tNodeChildLog);
                                tNodeLog.Nodes.Add(tNodeChildLog);
                            }
                        }
                        else if (fObjectLog.fObjectLogType == FObjectLogType.EquipmentStateSetAltererPerformedLog)
                        {
                            foreach (FEquipmentStateAltererLog fEatl in ((FEquipmentStateSetAltererPerformedLog)fObjectLog).fChildEquipmentStateAltererLogCollection)
                            {
                                tNodeChildLog = new UltraTreeNode(fEatl.logUniqueIdToString);
                                tNodeChildLog.Tag = fEatl;
                                FCommon.refreshTreeNodeOfObjectLog(fEatl, tvwTree, tNodeChildLog);
                                tNodeLog.Nodes.Add(tNodeChildLog);
                            }
                        }
                        else if (fObjectLog.fObjectLogType == FObjectLogType.ApplicationWrittenLog)
                        {
                            foreach (FContentLog fCttl in ((FApplicationWrittenLog)fObjectLog).fChildContentLogCollection)
                            {
                                tNodeChildLog = new UltraTreeNode(fCttl.logUniqueIdToString);
                                tNodeChildLog.Tag = fCttl;
                                FCommon.refreshTreeNodeOfObjectLog(fCttl, tvwTree, tNodeChildLog);
                                tNodeLog.Nodes.Add(tNodeChildLog);
                            }
                        }

                        // --

                        tNodeScdl.Nodes.Add(tNodeLog);
                    }
                }

                // --

                tNodeScdl.Expanded = true;
                tvwTree.Nodes.Add(tNodeScdl);

                // --

                if (beforeKey != string.Empty)
                {
                    tNodeBeforeActived = tvwTree.GetNodeByKey(beforeKey);
                }

                // --

                tvwTree.ScrollBounds =  Infragistics.Win.UltraWinTree.ScrollBounds.ScrollToFill;
                if (tNodeBeforeActived != null)
                {
                    if (
                        tNodeBeforeActived.Parent != null &&
                        !tNodeBeforeActived.Parent.Expanded
                        )
                    {
                        tNodeBeforeActived.Parent.Expanded = true;
                    }
                    // --
                    tvwTree.ActiveNode = tNodeBeforeActived;
                    tvwTree.TopNode = tvwTree.ActiveNode;
                }
                else
                {
                    if (tNodeScdl.Nodes.Count == 0)
                    {
                        tvwTree.ActiveNode = tNodeScdl;
                    }
                    else
                    {
                        if (fLogContinuity == FLogContinuity.Previous)
                        {
                            tvwTree.ActiveNode = tNodeScdl.Nodes[tNodeScdl.Nodes.Count - 1];
                            tvwTree.TopNode = tvwTree.ActiveNode;
                        }
                        else
                        {
                            tvwTree.ActiveNode = tNodeScdl.Nodes[0];
                            tvwTree.TopNode = tvwTree.ActiveNode;
                        }
                    }
                }

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeScdl = null;
                tNodeLog = null;
                tNodeChildLog = null;
                tNodeBeforeActived = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfChildObjectLog(
            UltraTreeNode tNodeParent
            )
        {
            FIObjectLog fParent = null;
            UltraTreeNode tNodeChild = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                fParent = (FIObjectLog)tNodeParent.Tag;
                // --
                if (fParent.fObjectLogType == FObjectLogType.SecsDriverLog)
                {

                }
                else if (fParent.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog)
                {
                    foreach (FSecsItemLog fSitl in ((FSecsDeviceDataMessageReceivedLog)fParent).fChildSecsItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fSitl.logUniqueIdToString);
                        tNodeChild.Tag = fSitl;
                        FCommon.refreshTreeNodeOfObjectLog(fSitl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog)
                {
                    foreach (FSecsItemLog fSitl in ((FSecsDeviceDataMessageSentLog)fParent).fChildSecsItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fSitl.logUniqueIdToString);
                        tNodeChild.Tag = fSitl;
                        FCommon.refreshTreeNodeOfObjectLog(fSitl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.SecsItemLog)
                {
                    foreach (FSecsItemLog fSitl in ((FSecsItemLog)fParent).fChildSecsItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fSitl.logUniqueIdToString);
                        tNodeChild.Tag = fSitl;
                        FCommon.refreshTreeNodeOfObjectLog(fSitl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                // --
                else if (fParent.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                {
                    foreach (FHostItemLog fHitl in ((FHostDeviceDataMessageReceivedLog)fParent).fChildHostItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fHitl.logUniqueIdToString);
                        tNodeChild.Tag = fHitl;
                        FCommon.refreshTreeNodeOfObjectLog(fHitl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                {
                    foreach (FHostItemLog fHitl in ((FHostDeviceDataMessageSentLog)fParent).fChildHostItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fHitl.logUniqueIdToString);
                        tNodeChild.Tag = fHitl;
                        FCommon.refreshTreeNodeOfObjectLog(fHitl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.HostItemLog)
                {
                    foreach (FHostItemLog fHitl in ((FHostItemLog)fParent).fChildHostItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fHitl.logUniqueIdToString);
                        tNodeChild.Tag = fHitl;
                        FCommon.refreshTreeNodeOfObjectLog(fHitl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                // --
                else if (fParent.fObjectLogType == FObjectLogType.MapperPerformedLog)
                {
                    foreach (FDataSetLog fDtsl in ((FMapperPerformedLog)fParent).fChildDataSetLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fDtsl.logUniqueIdToString);
                        tNodeChild.Tag = fDtsl;
                        FCommon.refreshTreeNodeOfObjectLog(fDtsl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.DataSetLog)
                {
                    foreach (FDataLog fDatl in ((FDataSetLog)fParent).fChildDataLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fDatl.logUniqueIdToString);
                        tNodeChild.Tag = fDatl;
                        FCommon.refreshTreeNodeOfObjectLog(fDatl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.DataLog)
                {
                    foreach (FDataLog fDatl in ((FDataLog)fParent).fChildDataLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fDatl.logUniqueIdToString);
                        tNodeChild.Tag = fDatl;
                        FCommon.refreshTreeNodeOfObjectLog(fDatl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                // --
                else if (fParent.fObjectLogType == FObjectLogType.StoragePerformedLog)
                {
                    foreach (FRepositoryLog fRpsl in ((FStoragePerformedLog)fParent).fChildRepositoryLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fRpsl.logUniqueIdToString);
                        tNodeChild.Tag = fRpsl;
                        FCommon.refreshTreeNodeOfObjectLog(fRpsl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.EquipmentStateSetAltererPerformedLog)
                {
                    foreach (FEquipmentStateAltererLog fEatl in ((FEquipmentStateSetAltererPerformedLog)fParent).fChildEquipmentStateAltererLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fEatl.logUniqueIdToString);
                        tNodeChild.Tag = fEatl;
                        FCommon.refreshTreeNodeOfObjectLog(fEatl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.RepositoryLog)
                {
                    foreach (FColumnLog fColl in ((FRepositoryLog)fParent).fChildColumnLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fColl.logUniqueIdToString);
                        tNodeChild.Tag = fColl;
                        FCommon.refreshTreeNodeOfObjectLog(fColl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.ColumnLog)
                {
                    foreach (FColumnLog fColl in ((FColumnLog)fParent).fChildColumnLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fColl.logUniqueIdToString);
                        tNodeChild.Tag = fColl;
                        FCommon.refreshTreeNodeOfObjectLog(fColl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.ApplicationWrittenLog)
                {
                    foreach (FContentLog fCttl in ((FApplicationWrittenLog)fParent).fChildContentLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fCttl.logUniqueIdToString);
                        tNodeChild.Tag = fCttl;
                        FCommon.refreshTreeNodeOfObjectLog(fCttl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.ContentLog)
                {
                    foreach (FContentLog fCttl in ((FContentLog)fParent).fChildContentLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fCttl.logUniqueIdToString);
                        tNodeChild.Tag = fCttl;
                        FCommon.refreshTreeNodeOfObjectLog(fCttl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fParent = null;
                tNodeChild = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region InterfaceLog Viewer Method

        private void designGridOfLog(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --
                uds.Band.Columns.Add("Time");
                uds.Band.Columns.Add("Device");
                uds.Band.Columns.Add("Filter1");
                uds.Band.Columns.Add("Filter2");
                uds.Band.Columns.Add("Message");
                uds.Band.Columns.Add("Session");

                // --

                grdList.DisplayLayout.Bands[0].Columns["Time"].Width = 170;
                grdList.DisplayLayout.Bands[0].Columns["Device"].Width = 56;
                grdList.DisplayLayout.Bands[0].Columns["Filter1"].Width = 97;
                grdList.DisplayLayout.Bands[0].Columns["Filter2"].Width = 47;
                grdList.DisplayLayout.Bands[0].Columns["Message"].Width = 300;
                grdList.DisplayLayout.Bands[0].Columns["Session"].Width = 100;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Device"].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                grdList.DisplayLayout.Bands[0].Columns["Filter1"].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                grdList.DisplayLayout.Bands[0].Columns["Filter2"].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                grdList.DisplayLayout.Bands[0].Columns["Message"].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                grdList.DisplayLayout.Bands[0].Columns["Session"].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Filter1"].Header.Caption = m_fAdmCore.fOption.secsInterfaceLogFilterCaption1;
                grdList.DisplayLayout.Bands[0].Columns["Filter2"].Header.Caption = m_fAdmCore.fOption.secsInterfaceLogFilterCaption2;
                if (m_fAdmCore.fOption.secsInterfaceLogFilterCaption1 == string.Empty)
                {
                    grdList.DisplayLayout.Bands[0].Columns["Filter1"].Hidden = true;
                }
                if (m_fAdmCore.fOption.secsInterfaceLogFilterCaption2 == string.Empty)
                {
                    grdList.DisplayLayout.Bands[0].Columns["Filter2"].Hidden = true;
                }
                // --                
                grdList.DisplayLayout.Override.FilterUIProvider = this.grdFilter;

                // --

                grdList.multiSelected = true;

                // --

                grdList.ImageList = new ImageList();
                // --
                grdList.ImageList.Images.Add("HdvDataMessageReceivedLog", Properties.Resources.HdvDataMessageReceivedLog);
                grdList.ImageList.Images.Add("HdvDataMessageReceivedLog_Command", Properties.Resources.HdvDataMessageReceivedLog_Command);
                grdList.ImageList.Images.Add("HdvDataMessageReceivedLog_Reply", Properties.Resources.HdvDataMessageReceivedLog_Reply);
                grdList.ImageList.Images.Add("HdvDataMessageReceivedLog_Unsolicited", Properties.Resources.HdvDataMessageReceivedLog_Unsolicited);
                grdList.ImageList.Images.Add("HdvDataMessageSentLog", Properties.Resources.HdvDataMessageSentLog);
                grdList.ImageList.Images.Add("HdvDataMessageSentLog_Command", Properties.Resources.HdvDataMessageSentLog_Command);
                grdList.ImageList.Images.Add("HdvDataMessageSentLog_Reply", Properties.Resources.HdvDataMessageSentLog_Reply);
                grdList.ImageList.Images.Add("HdvDataMessageSentLog_Unsolicited", Properties.Resources.HdvDataMessageSentLog_Unsolicited);
                // --
                grdList.ImageList.Images.Add("SdvDataMessageReceivedLog", Properties.Resources.SdvDataMessageReceivedLog);
                grdList.ImageList.Images.Add("SdvDataMessageReceivedLog_Primary", Properties.Resources.SdvDataMessageReceivedLog_Primary);
                grdList.ImageList.Images.Add("SdvDataMessageReceivedLog_Secondary", Properties.Resources.SdvDataMessageReceivedLog_Secondary);
                grdList.ImageList.Images.Add("SdvDataMessageSentLog", Properties.Resources.SdvDataMessageSentLog);
                grdList.ImageList.Images.Add("SdvDataMessageSentLog_Primary", Properties.Resources.SdvDataMessageSentLog_Primary);
                grdList.ImageList.Images.Add("SdvDataMessageSentLog_Secondary", Properties.Resources.SdvDataMessageSentLog_Secondary);
                // --
                grdList.ImageList.Images.Add("Result_Warning", Properties.Resources.Result_Warning);
                grdList.ImageList.Images.Add("Result_Error", Properties.Resources.Result_Error);
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

        private void designInterfaceTreeOfLog(
            )
        {
            try
            {
                tvwInterfaceTree.ImageList = new ImageList();
                // --
                tvwInterfaceTree.ImageList.Images.Add("HdvDataMessageReceivedLog", Properties.Resources.HdvDataMessageReceivedLog);
                tvwInterfaceTree.ImageList.Images.Add("HdvDataMessageReceivedLog_Command", Properties.Resources.HdvDataMessageReceivedLog_Command);
                tvwInterfaceTree.ImageList.Images.Add("HdvDataMessageReceivedLog_Reply", Properties.Resources.HdvDataMessageReceivedLog_Reply);
                tvwInterfaceTree.ImageList.Images.Add("HdvDataMessageReceivedLog_Unsolicited", Properties.Resources.HdvDataMessageReceivedLog_Unsolicited);
                tvwInterfaceTree.ImageList.Images.Add("HdvDataMessageSentLog", Properties.Resources.HdvDataMessageSentLog);
                tvwInterfaceTree.ImageList.Images.Add("HdvDataMessageSentLog_Command", Properties.Resources.HdvDataMessageSentLog_Command);
                tvwInterfaceTree.ImageList.Images.Add("HdvDataMessageSentLog_Reply", Properties.Resources.HdvDataMessageSentLog_Reply);
                tvwInterfaceTree.ImageList.Images.Add("HdvDataMessageSentLog_Unsolicited", Properties.Resources.HdvDataMessageSentLog_Unsolicited);
                tvwInterfaceTree.ImageList.Images.Add("HostItemLog", Properties.Resources.HostItemLog);
                tvwInterfaceTree.ImageList.Images.Add("HostItemLog_List", Properties.Resources.HostItemLog_List);
                // --
                tvwInterfaceTree.ImageList.Images.Add("SdvDataMessageReceivedLog", Properties.Resources.SdvDataMessageReceivedLog);
                tvwInterfaceTree.ImageList.Images.Add("SdvDataMessageReceivedLog_Primary", Properties.Resources.SdvDataMessageReceivedLog_Primary);
                tvwInterfaceTree.ImageList.Images.Add("SdvDataMessageReceivedLog_Secondary", Properties.Resources.SdvDataMessageReceivedLog_Secondary);
                tvwInterfaceTree.ImageList.Images.Add("SdvDataMessageSentLog", Properties.Resources.SdvDataMessageSentLog);
                tvwInterfaceTree.ImageList.Images.Add("SdvDataMessageSentLog_Primary", Properties.Resources.SdvDataMessageSentLog_Primary);
                tvwInterfaceTree.ImageList.Images.Add("SdvDataMessageSentLog_Secondary", Properties.Resources.SdvDataMessageSentLog_Secondary);
                tvwInterfaceTree.ImageList.Images.Add("SecsItemLog", Properties.Resources.SecsItemLog);
                tvwInterfaceTree.ImageList.Images.Add("SecsItemLog_List", Properties.Resources.SecsItemLog_List);
                // --
                tvwInterfaceTree.ImageList.Images.Add("Result_Warning", Properties.Resources.Result_Warning);
                tvwInterfaceTree.ImageList.Images.Add("Result_Error", Properties.Resources.Result_Error);

                // --

                tvwInterfaceTree.setPopupMenu((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuSivPopupMenuTree]);
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

        private void controlInterfaceMenu(
            )
        {
            FIObjectLog fObjectLog = null;

            try
            {
                mnuMenu.beginUpdate();

                // --
                
                if (grdList.activeDataRow != null)
                {
                    mnuMenu.Tools[FMenuKey.MenuSivExpand].SharedProps.Enabled = true;
                    mnuMenu.Tools[FMenuKey.MenuSivCollapse].SharedProps.Enabled = true;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSivCopy].SharedProps.Enabled = true;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSivSendMessage].SharedProps.Enabled = false;

                    // --

                    fObjectLog = (FIObjectLog)grdList.activeDataRow.Tag;
                    // --
                    if (
                        fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog ||
                        fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog
                        )
                    {
                        mnuMenu.Tools[FMenuKey.MenuSivConvertToSml].SharedProps.Enabled = true;
                        mnuMenu.Tools[FMenuKey.MenuSivConvertToVfei].SharedProps.Enabled = false;
                    }
                    else if (
                        fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog ||
                        fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog
                        )
                    {
                        if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                        {
                            mnuMenu.Tools[FMenuKey.MenuSivSendMessage].SharedProps.Enabled = true;
                        }
                        // --
                        mnuMenu.Tools[FMenuKey.MenuSivConvertToSml].SharedProps.Enabled = false;
                        mnuMenu.Tools[FMenuKey.MenuSivConvertToVfei].SharedProps.Enabled = true;
                    }
                }

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

        private void clear(
            )
        {
            try
            {
                grdList.beginUpdate();
                grdList.removeAllDataRow();
                grdList.endUpdate();

                // --

                tvwInterfaceTree.beginUpdate();
                tvwInterfaceTree.Nodes.Clear();
                tvwInterfaceTree.endUpdate();

                // -- 

                controlInterfaceMenu();
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

        private void loadGridOfObjectLog(
            string beforeKey,
            FLogContinuity fLogContinuity
            )
        {
            string time = string.Empty;
            string device = string.Empty;
            string direction = string.Empty;
            string filter1 = string.Empty;
            string filter2 = string.Empty;
            string message = string.Empty;
            string session = string.Empty;
            string imagekey = string.Empty;
            FResultCode fResultCode = FResultCode.Success;
            // --
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            UltraGridRow gridRow = null;
            // --
            FSecsItemLog fSecsItemLog = null;
            FHostItemLog fHostItemLog = null;

            try
            {
                grdList.beginUpdate(false);

                // --

                foreach (FIObjectLog fObjectLog in m_fSecsDriverLog.fChildObjectLogCollection)
                {
                    if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog)
                    {
                        time = ((FSecsDeviceDataMessageReceivedLog)fObjectLog).time;
                        device = ((FSecsDeviceDataMessageReceivedLog)fObjectLog).deviceName;
                        direction = "→";
                        // --
                        if (m_fAdmCore.fOption.secsInterfaceLogFilterCaption1 != string.Empty)
                        {
                            fSecsItemLog = ((FSecsDeviceDataMessageReceivedLog)fObjectLog).selectSingleAllSecsItemLogByName(
                                m_fAdmCore.fOption.secsInterfaceLogFilterSecsItem1// "EQPID"
                                );
                            filter1 = fSecsItemLog != null ? fSecsItemLog.stringValue : string.Empty;
                        }
                        if (m_fAdmCore.fOption.secsInterfaceLogFilterCaption2 != string.Empty)
                        {
                            fSecsItemLog = ((FSecsDeviceDataMessageReceivedLog)fObjectLog).selectSingleAllSecsItemLogByName(
                                m_fAdmCore.fOption.secsInterfaceLogFilterSecsItem2// "CEID"
                                );
                            filter2 = fSecsItemLog != null ? fSecsItemLog.stringValue : string.Empty;
                        }
                        // --
                        message =
                            "[" +
                            "S" + ((FSecsDeviceDataMessageReceivedLog)fObjectLog).stream.ToString() + " " +
                            "F" + ((FSecsDeviceDataMessageReceivedLog)fObjectLog).function.ToString() + " " +
                            "V" + ((FSecsDeviceDataMessageReceivedLog)fObjectLog).version.ToString() +
                            "] " + ((FSecsDeviceDataMessageReceivedLog)fObjectLog).name;
                        session = ((FSecsDeviceDataMessageReceivedLog)fObjectLog).sessionName +
                            "(" + ((FSecsDeviceDataMessageReceivedLog)fObjectLog).sessionId +
                            ")";
                        if (((FSecsDeviceDataMessageReceivedLog)fObjectLog).isPrimary)
                        {
                            imagekey = "SdvDataMessageReceivedLog_Primary";
                        }
                        else
                        {
                            imagekey = "SdvDataMessageReceivedLog_Secondary";
                        }
                        fResultCode = ((FSecsDeviceDataMessageReceivedLog)fObjectLog).fResultCode;
                    }
                    else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog)
                    {
                        time = ((FSecsDeviceDataMessageSentLog)fObjectLog).time;
                        device = ((FSecsDeviceDataMessageSentLog)fObjectLog).deviceName;
                        direction = "←";
                        // --
                        if (m_fAdmCore.fOption.secsInterfaceLogFilterCaption1 != string.Empty)
                        {
                            fSecsItemLog = ((FSecsDeviceDataMessageSentLog)fObjectLog).selectSingleAllSecsItemLogByName(
                                m_fAdmCore.fOption.secsInterfaceLogFilterSecsItem1// "EQPID"
                                );
                            filter1 = fSecsItemLog != null ? fSecsItemLog.stringValue : string.Empty;
                        }
                        if (m_fAdmCore.fOption.secsInterfaceLogFilterCaption2 != string.Empty)
                        {
                            fSecsItemLog = ((FSecsDeviceDataMessageSentLog)fObjectLog).selectSingleAllSecsItemLogByName(
                                m_fAdmCore.fOption.secsInterfaceLogFilterSecsItem2// "CEID"
                                );
                            filter2 = fSecsItemLog != null ? fSecsItemLog.stringValue : string.Empty;
                        }
                        // --
                        message =
                            "[" +
                            "S" + ((FSecsDeviceDataMessageSentLog)fObjectLog).stream.ToString() + " " +
                            "F" + ((FSecsDeviceDataMessageSentLog)fObjectLog).function.ToString() + " " +
                            "V" + ((FSecsDeviceDataMessageSentLog)fObjectLog).version.ToString() +
                            "] " + ((FSecsDeviceDataMessageSentLog)fObjectLog).name;
                        session = ((FSecsDeviceDataMessageSentLog)fObjectLog).sessionName +
                            "(" + ((FSecsDeviceDataMessageSentLog)fObjectLog).sessionId +
                            ")";
                        if (((FSecsDeviceDataMessageSentLog)fObjectLog).isPrimary)
                        {
                            imagekey = "SdvDataMessageSentLog_Primary";
                        }
                        else
                        {
                            imagekey = "SdvDataMessageSentLog_Secondary";
                        }
                        fResultCode = ((FSecsDeviceDataMessageSentLog)fObjectLog).fResultCode;
                    }
                    else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                    {
                        time = ((FHostDeviceDataMessageReceivedLog)fObjectLog).time;
                        device = ((FHostDeviceDataMessageReceivedLog)fObjectLog).deviceName;
                        direction = "→";
                        // --
                        if (m_fAdmCore.fOption.secsInterfaceLogFilterCaption1 != string.Empty)
                        {
                            fHostItemLog = ((FHostDeviceDataMessageReceivedLog)fObjectLog).selectSingleAllHostItemLogByName(
                                m_fAdmCore.fOption.secsInterfaceLogFilterHostItem1// "RES_ID"
                                );
                            filter1 = fHostItemLog != null ? fHostItemLog.stringValue : string.Empty;
                        }
                        if (m_fAdmCore.fOption.secsInterfaceLogFilterCaption2 != string.Empty)
                        {
                            fHostItemLog = ((FHostDeviceDataMessageReceivedLog)fObjectLog).selectSingleAllHostItemLogByName(
                                m_fAdmCore.fOption.secsInterfaceLogFilterHostItem2// "CEID"
                                );
                            filter2 = fHostItemLog != null ? fHostItemLog.stringValue : string.Empty;
                        }
                        //--
                        message =
                            "[" + ((FHostDeviceDataMessageReceivedLog)fObjectLog).command + " " +
                            "V" + ((FHostDeviceDataMessageReceivedLog)fObjectLog).version.ToString() +
                            "] " + ((FHostDeviceDataMessageReceivedLog)fObjectLog).name;
                        session = ((FHostDeviceDataMessageReceivedLog)fObjectLog).sessionName +
                           "(" + ((FHostDeviceDataMessageReceivedLog)fObjectLog).sessionId +
                           ")";
                        // --
                        if (((FHostDeviceDataMessageReceivedLog)fObjectLog).fHostMessageType == FHostMessageType.Command)
                        {
                            imagekey = "HdvDataMessageReceivedLog_Command";
                        }
                        else if (((FHostDeviceDataMessageReceivedLog)fObjectLog).fHostMessageType == FHostMessageType.Unsolicited)
                        {
                            imagekey = "HdvDataMessageReceivedLog_Unsolicited";
                        }
                        else
                        {
                            imagekey = "HdvDataMessageReceivedLog_Reply";
                        }
                        // --
                        fResultCode = ((FHostDeviceDataMessageReceivedLog)fObjectLog).fResultCode;
                    }
                    else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                    {
                        time = ((FHostDeviceDataMessageSentLog)fObjectLog).time;
                        device = ((FHostDeviceDataMessageSentLog)fObjectLog).deviceName;
                        direction = "←";
                        // --
                        if (m_fAdmCore.fOption.secsInterfaceLogFilterCaption1 != string.Empty)
                        {
                            fHostItemLog = ((FHostDeviceDataMessageSentLog)fObjectLog).selectSingleAllHostItemLogByName(
                                m_fAdmCore.fOption.secsInterfaceLogFilterHostItem1// "RES_ID"
                                );
                            filter1 = fHostItemLog != null ? fHostItemLog.stringValue : string.Empty;
                        }
                        if (m_fAdmCore.fOption.secsInterfaceLogFilterCaption2 != string.Empty)
                        {
                            fHostItemLog = ((FHostDeviceDataMessageSentLog)fObjectLog).selectSingleAllHostItemLogByName(
                                m_fAdmCore.fOption.secsInterfaceLogFilterHostItem2// "CEID"
                                );
                            filter2 = fHostItemLog != null ? fHostItemLog.stringValue : string.Empty;
                        }
                        //--
                        message =
                            "[" + ((FHostDeviceDataMessageSentLog)fObjectLog).command + " " +
                            "V" + ((FHostDeviceDataMessageSentLog)fObjectLog).version.ToString() +
                            "] " + ((FHostDeviceDataMessageSentLog)fObjectLog).name;
                        session = ((FHostDeviceDataMessageSentLog)fObjectLog).sessionName +
                            "(" + ((FHostDeviceDataMessageSentLog)fObjectLog).sessionId +
                            ")";
                        // --
                        if (((FHostDeviceDataMessageSentLog)fObjectLog).fHostMessageType == FHostMessageType.Command)
                        {
                            imagekey = "HdvDataMessageSentLog_Command";
                        }
                        else if (((FHostDeviceDataMessageSentLog)fObjectLog).fHostMessageType == FHostMessageType.Unsolicited)
                        {
                            imagekey = "HdvDataMessageSentLog_Unsolicited";
                        }
                        else
                        {
                            imagekey = "HdvDataMessageSentLog_Reply";
                        }
                        // --
                        fResultCode = ((FHostDeviceDataMessageSentLog)fObjectLog).fResultCode;
                    }
                    else
                    {
                        continue;
                    }

                    // --

                    cellValues = new object[]
                    {
                        time,
                        device + " " + direction,
                        filter1,
                        filter2,
                        message,
                        session
                    };
                    dataRow = grdList.appendOrUpdateDataRow(fObjectLog.logUniqueIdToString, cellValues);
                    dataRow.Tag = fObjectLog;

                    // --

                    gridRow = grdList.Rows.GetRowWithListIndex(dataRow.Index);
                    gridRow.Appearance.FontData.Bold = (fObjectLog.fontBold ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False);
                    gridRow.Appearance.ForeColor = fObjectLog.fontColor;
                    gridRow.Cells["Time"].Appearance.Image = grdList.ImageList.Images[imagekey];
                    // --
                    if (fResultCode == FResultCode.Warninig)
                    {
                        gridRow.Cells["Message"].Appearance.Image = grdList.ImageList.Images["Result_Warning"];
                    }
                    else if (fResultCode == FResultCode.Error)
                    {
                        gridRow.Cells["Message"].Appearance.Image = grdList.ImageList.Images["Result_Error"];
                    }
                }

                // --

                grdList.endUpdate(false);

                // --

                if (grdList.Rows.Count > 0)
                {
                    gridRow = null;
                    if (beforeKey != string.Empty && grdList.containsDataRow(beforeKey))
                    {
                        gridRow = grdList.Rows[grdList.getDataRowIndex(beforeKey)];
                    }

                    // --

                    if (gridRow != null && !gridRow.IsFilteredOut)
                    {
                        grdList.ActiveRow = gridRow;
                    }
                    else
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
                }
                else
                {
                    tvwInterfaceTree.beginUpdate();
                    tvwInterfaceTree.Nodes.Clear();
                    tvwInterfaceTree.endUpdate();

                    // --

                    txtLog.beginUpdate();
                    txtLog.Text = string.Empty;
                    txtLog.endUpdate();
                }

                // --

                controlMenu();
            }
            catch (Exception ex)
            {
                grdList.endUpdate(false);
                // --
                FDebug.throwException(ex);
            }
            finally
            {
                cellValues = null;
                dataRow = null;
                gridRow = null;
                fSecsItemLog = null;
                fHostItemLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadInterfaceTreeOfObjectLog(
            FIObjectLog fObjectLog
            )
        {
            UltraTreeNode tNode = null;

            try
            {
                tvwInterfaceTree.beginUpdate();
                tvwInterfaceTree.Nodes.Clear();

                // --

                tNode = new UltraTreeNode(fObjectLog.logUniqueIdToString, fObjectLog.ToString(FStringOption.Detail));
                tNode.Tag = fObjectLog;
                FCommon.refreshTreeNodeOfObjectLog(fObjectLog, tvwInterfaceTree, tNode);

                // --

                loadInterfaceTreeOfChildObjectLog(tNode);

                // --

                tNode.ExpandAll();
                tvwInterfaceTree.Nodes.Add(tNode);
                tvwInterfaceTree.ActiveNode = tNode;

                // --

                tvwInterfaceTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwInterfaceTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadInterfaceTreeOfChildObjectLog(
            UltraTreeNode tNodeParent
            )
        {
            FIObjectLog fParent = null;
            UltraTreeNode tNodeChild = null;

            try
            {
                fParent = (FIObjectLog)tNodeParent.Tag;
                // --
                if (fParent.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog)
                {
                    foreach (FSecsItemLog fSitl in ((FSecsDeviceDataMessageReceivedLog)fParent).fChildSecsItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fSitl.logUniqueIdToString);
                        tNodeChild.Tag = fSitl;
                        FCommon.refreshTreeNodeOfObjectLog(fSitl, tvwInterfaceTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                        // --
                        loadInterfaceTreeOfChildObjectLog(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog)
                {
                    foreach (FSecsItemLog fSitl in ((FSecsDeviceDataMessageSentLog)fParent).fChildSecsItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fSitl.logUniqueIdToString);
                        tNodeChild.Tag = fSitl;
                        FCommon.refreshTreeNodeOfObjectLog(fSitl, tvwInterfaceTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                        // --
                        loadInterfaceTreeOfChildObjectLog(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.SecsItemLog)
                {
                    foreach (FSecsItemLog fSitl in ((FSecsItemLog)fParent).fChildSecsItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fSitl.logUniqueIdToString);
                        tNodeChild.Tag = fSitl;
                        FCommon.refreshTreeNodeOfObjectLog(fSitl, tvwInterfaceTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                        // --
                        loadInterfaceTreeOfChildObjectLog(tNodeChild);
                    }
                }
                // --
                else if (fParent.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                {
                    foreach (FHostItemLog fHitl in ((FHostDeviceDataMessageReceivedLog)fParent).fChildHostItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fHitl.logUniqueIdToString);
                        tNodeChild.Tag = fHitl;
                        FCommon.refreshTreeNodeOfObjectLog(fHitl, tvwInterfaceTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                        // --
                        loadInterfaceTreeOfChildObjectLog(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                {
                    foreach (FHostItemLog fHitl in ((FHostDeviceDataMessageSentLog)fParent).fChildHostItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fHitl.logUniqueIdToString);
                        tNodeChild.Tag = fHitl;
                        FCommon.refreshTreeNodeOfObjectLog(fHitl, tvwInterfaceTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                        // --
                        loadInterfaceTreeOfChildObjectLog(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.HostItemLog)
                {
                    foreach (FHostItemLog fHitl in ((FHostItemLog)fParent).fChildHostItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fHitl.logUniqueIdToString);
                        tNodeChild.Tag = fHitl;
                        FCommon.refreshTreeNodeOfObjectLog(fHitl, tvwInterfaceTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                        // --
                        loadInterfaceTreeOfChildObjectLog(tNodeChild);
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fParent = null;
                tNodeChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTextOfObjectLog(
            FIObjectLog fObjectLog
            )
        {
            StringBuilder sb = null;

            try
            {
                sb = new StringBuilder();

                // --

                if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog)
                {
                    sb.Append(writeHeader((FSecsDeviceDataMessageReceivedLog)fObjectLog));
                    sb.Append(((FSecsDeviceDataMessageReceivedLog)fObjectLog).convertToXml());
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog)
                {
                    sb.Append(writeHeader((FSecsDeviceDataMessageSentLog)fObjectLog));
                    sb.Append(((FSecsDeviceDataMessageSentLog)fObjectLog).convertToXml());
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                {
                    sb.Append(writeHeader((FHostDeviceDataMessageReceivedLog)fObjectLog));
                    sb.Append(((FHostDeviceDataMessageReceivedLog)fObjectLog).convertToXml());
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                {
                    sb.Append(writeHeader((FHostDeviceDataMessageSentLog)fObjectLog));
                    sb.Append(((FHostDeviceDataMessageSentLog)fObjectLog).convertToXml());
                }
                else
                {
                    return;
                }

                // --

                txtLog.beginUpdate();
                txtLog.Text = sb.ToString();
                txtLog.endUpdate();
            }
            catch (Exception ex)
            {
                txtLog.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                sb = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSendMessage(
            )
        {
            FSecsHostMessageSender fHostMsgSender = null;
            FIObjectLog fObjectLog = null;
            List<FIObjectLog> fSentLogList = null;
            string key = string.Empty;

            try
            {
                fSentLogList = new List<FIObjectLog>();
                // --
                key = tabMain.ActiveTab.Key;

                // --

                if (key == "Log")
                {
                    fObjectLog = (FIObjectLog)tvwTree.ActiveNode.Tag;
                    fSentLogList.Add(fObjectLog);
                }
                else if (key == "Interface")
                {
                    foreach (UltraDataRow row in grdList.selectedDataRows)
                    {
                        fObjectLog = (FIObjectLog)row.Tag;
                        // -- 
                        if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                        {
                            fSentLogList.Add(fObjectLog);
                        }
                    }
                }

                // -- 

                fHostMsgSender = new FSecsHostMessageSender(m_fAdmCore, fSentLogList);
                fHostMsgSender.ShowDialog();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fHostMsgSender != null)
                {
                    fHostMsgSender.Dispose();
                    fHostMsgSender = null;
                }
                fObjectLog = null;
                fSentLogList = null;
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
                preFontName = ((FontListTool)mnuLogMenu.Tools[FMenuKey.MenuAlvFontName]).Value.ToString();
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FSecsTotalLogViewer Form Event Handler

        private void FSecsTotalLogViewer_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fSecsDriverLog = new FSecsDriverLog();
                m_fLogFilter = new FSecsLogFilter(m_fAdmCore.fSecsLogFilter);

                // --

                designTreeOfLog();

                // --

                tvwTree.setPopupMenu((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuSlvPopupMenu]);

                // --

                controlMenu();

                // --

                ((FontListTool)mnuLogMenu.Tools[FMenuKey.MenuSivFontName]).Text = m_fAdmCore.fOption.fontName;
                numFontSize.Value = m_fAdmCore.fOption.fontSize;

                // --

                txtLog.Appearance.FontData.Name = ((FontListTool)mnuLogMenu.Tools[FMenuKey.MenuSivFontName]).Value.ToString();
                txtLog.Appearance.FontData.SizeInPoints = float.Parse(numFontSize.Value.ToString());

                // --
                
                designGridOfLog();
                designInterfaceTreeOfLog();

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

        private void FSecsTotalLogViewer_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                txtFileName.Text = Path.GetFileName(m_fileName);
                txtLogType.Text = "EAP - [ " + m_eapId + " ]";

                // -- 

                refreshLog(m_beforeKey);

                // --

                setTitle();

                // --

                tvwTree.Focus();
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

        private void FSecsTotalLogViewer_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                pgdProp.selectedObject = null;

                // --

                if (m_fLogFilter != null)
                {
                    m_fLogFilter.Dispose();
                    m_fLogFilter = null;
                }

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

        private void FSecsTotalLogViewer_KeyDown(
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
                if (e.Tool.Key == FMenuKey.MenuSlvRefresh)
                {
                    procMenuRefresh();
                }
                else if (e.Tool.Key == FMenuKey.MenuSlvPrevious)
                {
                    procMenuPrevious();
                }
                else if (e.Tool.Key == FMenuKey.MenuSlvNext)
                {
                    procMenuNext();
                }
                else if (e.Tool.Key == FMenuKey.MenuSlvExpand)
                {
                    procMenuExpand();
                }
                else if (e.Tool.Key == FMenuKey.MenuSlvCollapse)
                {
                    procMenuCollapse();
                }
                else if (e.Tool.Key == FMenuKey.MenuSlvCopy)
                {
                    procMenuCopy();
                }
                else if (e.Tool.Key == FMenuKey.MenuSlvConvertToSml)
                {
                    procMenuSmlViewer();
                }
                else if (e.Tool.Key == FMenuKey.MenuSlvConvertToVfei)
                {
                    procMenuVfeiViewer();
                }
                else if (e.Tool.Key == FMenuKey.MenuSlvFilter)
                {
                    procMenuFilterSelector();
                }
                else if (e.Tool.Key == FMenuKey.MenuSivSendMessage)
                {
                    procMenuSendMessage();
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region tvwTree Control Event Handler

        private void tvwTree_AfterActivate(
            object sender, 
            NodeEventArgs e
            )
        {
            FIObjectLog fObjectLog = null;

            try
            {
                if (tvwTree.ActiveNode == null)
                {
                    return;
                }

                // --

                fObjectLog = (FIObjectLog)tvwTree.ActiveNode.Tag;
                // --
                if (fObjectLog.fObjectLogType == FObjectLogType.SecsDriverLog)
                {
                    pgdProp.selectedObject = new FPropScdl(m_fAdmCore, pgdProp, (FSecsDriverLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceStateChangedLog)
                {
                    pgdProp.selectedObject = new FPropSdcl(m_fAdmCore, pgdProp, (FSecsDeviceStateChangedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceErrorRaisedLog)
                {
                    pgdProp.selectedObject = new FPropSdel(m_fAdmCore, pgdProp, (FSecsDeviceErrorRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTimeoutRaisedLog)
                {
                    pgdProp.selectedObject = new FPropSdtl(m_fAdmCore, pgdProp, (FSecsDeviceTimeoutRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceControlMessageReceivedLog)
                {
                    pgdProp.selectedObject = new FPropCmrl(m_fAdmCore, pgdProp, (FSecsDeviceControlMessageReceivedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceControlMessageSentLog)
                {
                    pgdProp.selectedObject = new FPropCmsl(m_fAdmCore, pgdProp, (FSecsDeviceControlMessageSentLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceSmlReceivedLog)
                {
                    pgdProp.selectedObject = new FPropSmrl(m_fAdmCore, pgdProp, (FSecsDeviceSmlReceivedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceSmlSentLog)
                {
                    pgdProp.selectedObject = new FPropSmsl(m_fAdmCore, pgdProp, (FSecsDeviceSmlSentLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog)
                {
                    pgdProp.selectedObject = new FPropSdmrl(m_fAdmCore, pgdProp, (FSecsDeviceDataMessageReceivedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog)
                {
                    pgdProp.selectedObject = new FPropSdmsl(m_fAdmCore, pgdProp, (FSecsDeviceDataMessageSentLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsItemLog)
                {
                    pgdProp.selectedObject = new FPropSitl(m_fAdmCore, pgdProp, (FSecsItemLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTelnetPacketReceivedLog)
                {
                    pgdProp.selectedObject = new FPropSdtprl(m_fAdmCore, pgdProp, (FSecsDeviceTelnetPacketReceivedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTelnetPacketSentLog)
                {
                    pgdProp.selectedObject = new FPropSdtpsl(m_fAdmCore, pgdProp, (FSecsDeviceTelnetPacketSentLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTelnetStateChangedLog)
                {
                    pgdProp.selectedObject = new FPropSdtscl(m_fAdmCore, pgdProp, (FSecsDeviceTelnetStateChangedLog)fObjectLog);
                }
                // --
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceStateChangedLog)
                {
                    pgdProp.selectedObject = new FPropHdcl(m_fAdmCore, pgdProp, (FHostDeviceStateChangedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceErrorRaisedLog)
                {
                    pgdProp.selectedObject = new FPropHdel(m_fAdmCore, pgdProp, (FHostDeviceErrorRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                {
                    pgdProp.selectedObject = new FPropHdmrl(m_fAdmCore, pgdProp, (FHostDeviceDataMessageReceivedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                {
                    pgdProp.selectedObject = new FPropHdmsl(m_fAdmCore, pgdProp, (FHostDeviceDataMessageSentLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostItemLog)
                {
                    pgdProp.selectedObject = new FPropHitl(m_fAdmCore, pgdProp, (FHostItemLog)fObjectLog);
                }
                // --
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsTriggerRaisedLog)
                {
                    pgdProp.selectedObject = new FPropStrl(m_fAdmCore, pgdProp, (FSecsTriggerRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsTransmitterRaisedLog)
                {
                    pgdProp.selectedObject = new FPropStnl(m_fAdmCore, pgdProp, (FSecsTransmitterRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTriggerRaisedLog)
                {
                    pgdProp.selectedObject = new FPropHtrl(m_fAdmCore, pgdProp, (FHostTriggerRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTransmitterRaisedLog)
                {
                    pgdProp.selectedObject = new FPropHtnl(m_fAdmCore, pgdProp, (FHostTransmitterRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.JudgementPerformedLog)
                {
                    pgdProp.selectedObject = new FPropJdml(m_fAdmCore, pgdProp, (FJudgementPerformedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.MapperPerformedLog)
                {
                    pgdProp.selectedObject = new FPropMapl(m_fAdmCore, pgdProp, (FMapperPerformedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EquipmentStateSetAltererPerformedLog)
                {
                    pgdProp.selectedObject = new FPropEsal(m_fAdmCore, pgdProp, (FEquipmentStateSetAltererPerformedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.StoragePerformedLog)
                {
                    pgdProp.selectedObject = new FPropStgl(m_fAdmCore, pgdProp, (FStoragePerformedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CallbackRaisedLog)
                {
                    pgdProp.selectedObject = new FPropCbkl(m_fAdmCore, pgdProp, (FCallbackRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.FunctionCalledLog)
                {
                    pgdProp.selectedObject = new FPropFunl(m_fAdmCore, pgdProp, (FFunctionCalledLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.BranchRaisedLog)
                {
                    pgdProp.selectedObject = new FPropBrnl(m_fAdmCore, pgdProp, (FBranchRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CommentWrittenLog)
                {
                    pgdProp.selectedObject = new FPropCmtl(m_fAdmCore, pgdProp, (FCommentWrittenLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PauserRaisedLog)
                {
                    pgdProp.selectedObject = new FPropPaul(m_fAdmCore, pgdProp, (FPauserRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EntryPointCalledLog)
                {
                    pgdProp.selectedObject = new FPropEtpl(m_fAdmCore, pgdProp, (FEntryPointCalledLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.DataSetLog)
                {
                    pgdProp.selectedObject = new FPropDtsl(m_fAdmCore, pgdProp, (FDataSetLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.DataLog)
                {
                    pgdProp.selectedObject = new FPropDatl(m_fAdmCore, pgdProp, (FDataLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.RepositoryLog)
                {
                    pgdProp.selectedObject = new FPropRpsl(m_fAdmCore, pgdProp, (FRepositoryLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.ColumnLog)
                {
                    pgdProp.selectedObject = new FPropColl(m_fAdmCore, pgdProp, (FColumnLog)fObjectLog);
                }
                // --
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceHandshakeReceivedLog)
                {
                    pgdProp.selectedObject = new FPropSdhrl(m_fAdmCore, pgdProp, (FSecsDeviceHandshakeReceivedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceHandshakeSentLog)
                {
                    pgdProp.selectedObject = new FPropSdhsl(m_fAdmCore, pgdProp, (FSecsDeviceHandshakeSentLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceBlockReceivedLog)
                {
                    pgdProp.selectedObject = new FPropSdbrl(m_fAdmCore, pgdProp, (FSecsDeviceBlockReceivedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceBlockSentLog)
                {
                    pgdProp.selectedObject = new FPropSdbsl(m_fAdmCore, pgdProp, (FSecsDeviceBlockSentLog)fObjectLog);
                }
                // --
                else if (fObjectLog.fObjectLogType == FObjectLogType.ApplicationWrittenLog)
                {
                    pgdProp.selectedObject = new FPropAppl(m_fAdmCore, pgdProp, (FApplicationWrittenLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.ContentLog)
                {
                    pgdProp.selectedObject = new FPropCttl(m_fAdmCore, pgdProp, (FContentLog)fObjectLog);
                }

                // --

                controlMenu();
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

        private void tvwTree_AfterExpand(
            object sender, 
            NodeEventArgs e
            )
        {
            try
            {
                tvwTree.beginUpdate();

                // --

                foreach (UltraTreeNode tNode in e.TreeNode.Nodes)
                {
                    if (tNode.Nodes.Count > 0)
                    {
                        continue;
                    }
                    loadTreeOfChildObjectLog(tNode);
                }

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwTree_KeyDown(
            object sender, 
            KeyEventArgs e
            )
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.C)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuTlvCopy].SharedProps.Enabled == true)
                    {
                        procMenuCopy();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.E)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuTlvExpand].SharedProps.Enabled == true)
                    {
                        procMenuExpand();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.L)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuTlvCollapse].SharedProps.Enabled == true)
                    {
                        procMenuCollapse();
                    }
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region rstToolbar Event Handler

        private void rstToolbar_SearchRequested(
            object sender, 
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                procMenuSearch(e.searchWord);
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

        #region rstInterfaceToolbar Event Handler

        private void rstInterfaceToolbar_SearchRequested(
            object sender, 
            FSearchRequestedEventArgs e
            )
        {
            UltraTreeNode tNode = null;
            FIObjectLog fBase = null;
            FIObjectLog fFirst = null;
            FIObjectLog fResult = null;
            FIObjectLog fMessage = null;
            FIObjectLog fTemp = null;

            try
            {
                FCursor.waitCursor();

                // --

                if (tvwInterfaceTree.ActiveNode == null)
                {
                    return;
                }

                // --

                tNode = tvwInterfaceTree.ActiveNode;
                fBase = (FIObjectLog)tNode.Tag;
                // --
                fFirst = m_fSecsDriverLog.searchLogSeries(fBase, e.searchWord);
                if (fFirst == null)
                {
                    FMessageBox.showInformation("Search", m_fAdmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { e.searchWord }), this);
                    return;
                }

                // --

                fResult = fFirst;
                tNode = null;

                // --

                while (fMessage == null)
                {
                    if (
                        fResult.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog ||
                        fResult.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog ||
                        fResult.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog ||
                        fResult.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog
                        )
                    {
                        fMessage = fResult;
                    }
                    else if (fResult.fObjectLogType == FObjectLogType.SecsItemLog)
                    {
                        fTemp = fResult;
                        while (((FSecsItemLog)fTemp).fParent.fObjectLogType != FObjectLogType.SecsDriverLog)
                        {
                            if (
                                ((FSecsItemLog)fTemp).fParent.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog ||
                                ((FSecsItemLog)fTemp).fParent.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog
                                )
                            {
                                fMessage = ((FSecsItemLog)fTemp).fParent;
                                break;
                            }
                            else
                            {
                                fTemp = ((FSecsItemLog)fTemp).fParent;
                            }
                        }
                    }
                    else if (fResult.fObjectLogType == FObjectLogType.HostItemLog)
                    {
                        fTemp = fResult;
                        while (((FHostItemLog)fTemp).fParent.fObjectLogType != FObjectLogType.SecsDriverLog)
                        {
                            if (
                                ((FHostItemLog)fTemp).fParent.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog ||
                                ((FHostItemLog)fTemp).fParent.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog
                                )
                            {
                                fMessage = ((FHostItemLog)fTemp).fParent;
                                break;
                            }
                            else
                            {
                                fTemp = ((FHostItemLog)fTemp).fParent;
                            }
                        }
                    }

                    // --

                    if (
                        fMessage == null ||
                        !grdList.containsDataRow(fMessage.logUniqueIdToString) ||
                        grdList.Rows[grdList.getDataRowIndex(fMessage.logUniqueIdToString)].IsFilteredOut
                        )
                    {
                        fMessage = null;
                        fResult = m_fSecsDriverLog.searchLogSeries(fResult, e.searchWord);
                        if (fResult == null || fResult.logUniqueId == fFirst.logUniqueId)
                        {
                            break;
                        }
                    }
                }

                // --

                if (fMessage == null)
                {
                    FMessageBox.showInformation("Search", m_fAdmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { e.searchWord }), this);
                    return;
                }

                // --

                grdList.Selected.Rows.Clear();
                grdList.ActiveRow = grdList.Rows[grdList.getDataRowIndex(fMessage.logUniqueIdToString)];
                // --
                tvwInterfaceTree.SelectedNodes.Clear();
                tvwInterfaceTree.ActiveNode = tvwInterfaceTree.GetNodeByKey(fResult.logUniqueIdToString);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                tNode = null;
                fBase = null;
                fFirst = null;
                fResult = null;
                fMessage = null;
                fTemp = null;

                // --

                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region grdList Event Handler

        private void grdList_AfterRowActivate(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (grdList.ActiveRow == null)
                {
                    tvwInterfaceTree.beginUpdate();
                    tvwInterfaceTree.Nodes.Clear();
                    tvwInterfaceTree.endUpdate();

                    // --

                    txtLog.beginUpdate();
                    txtLog.Text = string.Empty;
                    txtLog.endUpdate();
                }
                else
                {
                    loadInterfaceTreeOfObjectLog((FIObjectLog)grdList.activeDataRow.Tag);
                    loadTextOfObjectLog((FIObjectLog)grdList.activeDataRow.Tag);
                }

                // --

                controlInterfaceMenu();
            }
            catch (Exception ex)
            {
                tvwInterfaceTree.endUpdate();
                txtLog.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                // --

                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        private void grdList_AfterRowFilterChanged(
            object sender, 
            AfterRowFilterChangedEventArgs e
            )
        {
            int activateIndex = -1;

            try
            {
                FCursor.waitCursor();

                // --

                if (e.Rows.VisibleRowCount == 0)
                {
                    tvwInterfaceTree.beginUpdate();
                    tvwInterfaceTree.Nodes.Clear();
                    tvwInterfaceTree.endUpdate();

                    // --

                    txtLog.beginUpdate();
                    txtLog.Text = string.Empty;
                    txtLog.endUpdate();

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

        private void grdList_MouseDown(
            object sender, 
            MouseEventArgs e
            )
        {
            UltraGridRow r = null;

            try
            {
                FCursor.waitCursor();

                // --

                if (e.Button != MouseButtons.Right || grdList.Rows.Count == 0)
                {
                    return;
                }

                // --

                r = (UltraGridRow)grdList.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y)).GetContext(typeof(UltraGridRow));
                if (r != null)
                {
                    grdList.ActiveRow = grdList.Rows[r.Index];
                }

                // --

                mnuMenu.ShowPopup(FMenuKey.MenuSivPopupMenuGrid);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                r = null;
                // --
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region mnuLogMenu Event Handler

        private void mnuLogMenu_AfterToolDeactivate(
            object sender, 
            ToolEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tool.Key == FMenuKey.MenuSivFontName)
                {
                    if (!procMenuChangeFontName())
                    {
                        ((FontListTool)mnuLogMenu.Tools[FMenuKey.MenuSivFontName]).Value = m_fAdmCore.fOption.fontName;
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

        //------------------------------------------------------------------------------------------------------------------------

        private void mnuLogMenu_ToolValueChanged(
            object sender, 
            ToolEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tool.Key == FMenuKey.MenuSivFontName)
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region tabMain Event Handler

        private void tabMain_ActiveTabChanging(
            object sender, 
            Infragistics.Win.UltraWinTabControl.ActiveTabChangingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tab.Key == "Log")
                {
                    if (grdList.ActiveRow != null)
                    {
                        m_selectTagKey = ((FIObjectLog)grdList.activeDataRow.Tag).logUniqueIdToString;
                    }
                }
                else if (e.Tab.Key == "Interface")
                {
                    if (tvwTree.ActiveNode != null)
                    {
                        searchParentLog((FIObjectLog)tvwTree.ActiveNode.Tag);
                    }

                    pgdProp.Enabled = false;
                }

                e.Tab.Visible = true;
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

        private void tabMain_ActiveTabChanged(
            object sender, 
            Infragistics.Win.UltraWinTabControl.ActiveTabChangedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();
                
                // --
                 
                if (
                    tabMain.ActiveTab != null &&
                    m_fSecsDriverLog != null
                    )
                {
                    refreshLog();
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

        private void pnlClient_Paint(object sender, PaintEventArgs e)
        {

        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
