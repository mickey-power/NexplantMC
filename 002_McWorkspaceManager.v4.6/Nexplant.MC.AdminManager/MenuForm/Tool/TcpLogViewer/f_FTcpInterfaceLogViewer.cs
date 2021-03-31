/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FTcpInterfaceLogViewer.cs
--  Creator         : jungyoul
--  Create Date     : 2016.07.15
--  Description     : FAMate Admin Manager TCP Interface Log Viewer Form Class (WISOL)
--  History         : Created by jungyoul at 2016.07.15
----------------------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinTree;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;
using Nexplant.MC.Core.FaTcpDriver;

namespace Nexplant.MC.AdminManager
{
    public partial class FTcpInterfaceLogViewer : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private FTcpDriverLog m_fTcpDriverLog = null;
        private string m_eapId = string.Empty;
        private string m_backupFileName = null;
        private string m_fileName = null;
        private string m_beforeKey = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTcpInterfaceLogViewer(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpInterfaceLogViewer(
            FAdmCore fAdmCore,
            string eapId,
            string backupFileName,
            string fileName
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            // --
            m_fAdmCore = fAdmCore;
            m_eapId = eapId;
            m_backupFileName = backupFileName;
            m_fileName = fileName;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpInterfaceLogViewer(
            FAdmCore fAdmCore,
            string eapId,
            string backupFileName,
            string fileName,
            string beforeKey
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            // --
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
                    if (m_fTcpDriverLog != null)
                    {
                        m_fTcpDriverLog.Dispose();
                        m_fTcpDriverLog = null;
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
                return null;
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

        private void designGridOfLog(
           )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --
                uds.Band.Columns.Add("Time");
                uds.Band.Columns.Add("Direction");
                uds.Band.Columns.Add("Message");
                uds.Band.Columns.Add("Device");
                uds.Band.Columns.Add("Session");

                // --

                grdList.DisplayLayout.Bands[0].Columns["Time"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["Direction"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Message"].Width = 250;
                grdList.DisplayLayout.Bands[0].Columns["Device"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Session"].Width = 100;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Direction"].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                grdList.DisplayLayout.Bands[0].Columns["Message"].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                grdList.DisplayLayout.Bands[0].Columns["Device"].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                grdList.DisplayLayout.Bands[0].Columns["Session"].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
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
                grdList.ImageList.Images.Add("TdvDataMessageReceivedLog_Command", Properties.Resources.TdvDataMessageReceivedLog_Command);
                grdList.ImageList.Images.Add("TdvDataMessageReceivedLog_Reply", Properties.Resources.TdvDataMessageReceivedLog_Reply);
                grdList.ImageList.Images.Add("TdvDataMessageReceivedLog_Unsolicited", Properties.Resources.TdvDataMessageReceivedLog_Unsolicited);
                grdList.ImageList.Images.Add("TdvDataMessageSentLog_Command", Properties.Resources.TdvDataMessageSentLog_Command);
                grdList.ImageList.Images.Add("TdvDataMessageSentLog_Reply", Properties.Resources.TdvDataMessageSentLog_Reply);
                grdList.ImageList.Images.Add("TdvDataMessageSentLog_Unsolicited", Properties.Resources.TdvDataMessageSentLog_Unsolicited);
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

        private void designTreeOfLog(
            )
        {
            try
            {
                tvwTree.ImageList = new ImageList();
                // --
                tvwTree.ImageList.Images.Add("HdvDataMessageReceivedLog", Properties.Resources.HdvDataMessageReceivedLog);
                tvwTree.ImageList.Images.Add("HdvDataMessageReceivedLog_Command", Properties.Resources.HdvDataMessageReceivedLog_Command);
                tvwTree.ImageList.Images.Add("HdvDataMessageReceivedLog_Reply", Properties.Resources.HdvDataMessageReceivedLog_Reply);
                tvwTree.ImageList.Images.Add("HdvDataMessageReceivedLog_Unsolicited", Properties.Resources.HdvDataMessageReceivedLog_Unsolicited);
                tvwTree.ImageList.Images.Add("HdvDataMessageSentLog", Properties.Resources.HdvDataMessageSentLog);
                tvwTree.ImageList.Images.Add("HdvDataMessageSentLog_Command", Properties.Resources.HdvDataMessageSentLog_Command);
                tvwTree.ImageList.Images.Add("HdvDataMessageSentLog_Reply", Properties.Resources.HdvDataMessageSentLog_Reply);
                tvwTree.ImageList.Images.Add("HdvDataMessageSentLog_Unsolicited", Properties.Resources.HdvDataMessageSentLog_Unsolicited);
                tvwTree.ImageList.Images.Add("HostItemLog", Properties.Resources.HostItemLog);
                tvwTree.ImageList.Images.Add("HostItemLog_List", Properties.Resources.HostItemLog_List);
                // --
                tvwTree.ImageList.Images.Add("TdvDataMessageReceivedLog", Properties.Resources.TdvDataMessageReceivedLog);
                tvwTree.ImageList.Images.Add("TdvDataMessageReceivedLog_Command", Properties.Resources.TdvDataMessageReceivedLog_Command);
                tvwTree.ImageList.Images.Add("TdvDataMessageReceivedLog_Reply", Properties.Resources.TdvDataMessageReceivedLog_Reply);
                tvwTree.ImageList.Images.Add("TdvDataMessageReceivedLog_Unsolicited", Properties.Resources.TdvDataMessageReceivedLog_Unsolicited);
                tvwTree.ImageList.Images.Add("TdvDataMessageSentLog_Command", Properties.Resources.TdvDataMessageSentLog_Command);
                tvwTree.ImageList.Images.Add("TdvDataMessageSentLog_Reply", Properties.Resources.TdvDataMessageSentLog_Reply);
                tvwTree.ImageList.Images.Add("TdvDataMessageSentLog_Unsolicited", Properties.Resources.TdvDataMessageSentLog_Unsolicited);
                tvwTree.ImageList.Images.Add("TcpItemLog", Properties.Resources.TcpItemLog);
                tvwTree.ImageList.Images.Add("TcpItemLog_List", Properties.Resources.TcpItemLog_List);
                // --
                tvwTree.ImageList.Images.Add("Result_Warning", Properties.Resources.Result_Warning);
                tvwTree.ImageList.Images.Add("Result_Error", Properties.Resources.Result_Error);

                // --

                tvwTree.setPopupMenu((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuTivPopupMenuTree]);
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
            FIObjectLog fObjectLog = null;

            try
            {
                mnuMenu.beginUpdate();

                // --

                if (grdList.activeDataRow == null)
                {
                    mnuMenu.Tools[FMenuKey.MenuTivExpand].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuTivCollapse].SharedProps.Enabled = false;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuTivCopy].SharedProps.Enabled = false;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuTivSendMessage].SharedProps.Enabled = false;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuTivConvertToXlg].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuTivConvertToVfei].SharedProps.Enabled = false;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuTivExpand].SharedProps.Enabled = true;
                    mnuMenu.Tools[FMenuKey.MenuTivCollapse].SharedProps.Enabled = true;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuTivCopy].SharedProps.Enabled = true;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuTivSendMessage].SharedProps.Enabled = false;

                    // --

                    fObjectLog = (FIObjectLog)grdList.activeDataRow.Tag;
                    // --
                    if (
                        fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog ||
                        fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog
                        )
                    {
                        mnuMenu.Tools[FMenuKey.MenuTivConvertToXlg].SharedProps.Enabled = true;
                        mnuMenu.Tools[FMenuKey.MenuTivConvertToVfei].SharedProps.Enabled = false;
                    }
                    else if (
                        fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog ||
                        fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog
                        )
                    {
                        if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                        {
                            mnuMenu.Tools[FMenuKey.MenuTivSendMessage].SharedProps.Enabled = true;
                        }
                        // --
                        mnuMenu.Tools[FMenuKey.MenuTivConvertToXlg].SharedProps.Enabled = false;
                        mnuMenu.Tools[FMenuKey.MenuTivConvertToVfei].SharedProps.Enabled = true;
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

                tvwTree.beginUpdate();
                tvwTree.Nodes.Clear();
                tvwTree.endUpdate();

                // -- 

                controlMenu();
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

        private void loadEapInterfaceLogFile(
            string beforeKey
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInLog = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutLog = null;
            FFtp fFtp = null;
            string tempFilePath = string.Empty;
            string zipFileName = string.Empty;
            string fileName = string.Empty;

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

                clear();

                // --

                fileName = Path.Combine(tempFilePath, Path.GetFileName(this.fileName));
                txtSize.Text = getFileSize(fileName);

                // --

                m_fTcpDriverLog.openLogFile(fileName);
                // --
                if (m_fTcpDriverLog.fChildObjectLogCollection.count == 0)
                {
                    txtFromTime.Text = string.Empty;
                    txtToTime.Text = string.Empty;
                }
                else
                {
                    txtFromTime.Text = getLogTime(m_fTcpDriverLog.fChildObjectLogCollection[0]);
                    txtToTime.Text = getLogTime(m_fTcpDriverLog.fChildObjectLogCollection[m_fTcpDriverLog.fChildObjectLogCollection.count - 1]);
                }
                // --
                loadGridOfObjectLog(beforeKey, FLogContinuity.Previous);
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

        private void loadEapInterfaceBackupLogFile(
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

                clear();

                // --

                fileName = Path.Combine(tempFilePath, Path.GetFileName(this.fileName));
                txtSize.Text = getFileSize(fileName);

                // --

                m_fTcpDriverLog.openLogFile(fileName);
                // --
                if (m_fTcpDriverLog.fChildObjectLogCollection.count == 0)
                {
                    txtFromTime.Text = string.Empty;
                    txtToTime.Text = string.Empty;
                }
                else
                {
                    txtFromTime.Text = getLogTime(m_fTcpDriverLog.fChildObjectLogCollection[0]);
                    txtToTime.Text = getLogTime(m_fTcpDriverLog.fChildObjectLogCollection[m_fTcpDriverLog.fChildObjectLogCollection.count - 1]);
                }
                // --
                loadGridOfObjectLog(beforeKey, FLogContinuity.Previous);
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

        public void continueTcpLog(
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
                    continueTcpLogFile(fLogContinuity);
                }
                else
                {
                    continueTcpBackupLogFile(fLogContinuity);
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

        private void continueTcpLogFile(
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
                    FEapLogType.TCP.ToString()
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

                clear();

                // --

                fileName = Path.Combine(tempFilePath, Path.GetFileName(this.fileName));
                txtSize.Text = getFileSize(fileName);

                // --

                m_fTcpDriverLog.openLogFile(fileName);
                // --
                if (m_fTcpDriverLog.fChildObjectLogCollection.count == 0)
                {
                    txtFromTime.Text = string.Empty;
                    txtToTime.Text = string.Empty;
                }
                else
                {
                    txtFromTime.Text = getLogTime(m_fTcpDriverLog.fChildObjectLogCollection[0]);
                    txtToTime.Text = getLogTime(m_fTcpDriverLog.fChildObjectLogCollection[m_fTcpDriverLog.fChildObjectLogCollection.count - 1]);
                }
                // --
                loadGridOfObjectLog(string.Empty, fLogContinuity);
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

        private void continueTcpBackupLogFile(
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
                    FEapLogType.TCP.ToString()
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

                clear();

                // --

                fileName = Path.Combine(tempFilePath, Path.GetFileName(this.fileName));
                txtSize.Text = getFileSize(fileName);

                // --

                m_fTcpDriverLog.openLogFile(fileName);
                // --
                if (m_fTcpDriverLog.fChildObjectLogCollection.count == 0)
                {
                    txtFromTime.Text = string.Empty;
                    txtToTime.Text = string.Empty;
                }
                else
                {
                    txtFromTime.Text = getLogTime(m_fTcpDriverLog.fChildObjectLogCollection[0]);
                    txtToTime.Text = getLogTime(m_fTcpDriverLog.fChildObjectLogCollection[m_fTcpDriverLog.fChildObjectLogCollection.count - 1]);
                }
                // --
                loadGridOfObjectLog(string.Empty, fLogContinuity);
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

        private void loadGridOfObjectLog(
            string beforeKey,
            FLogContinuity fLogContinuity
            )
        {
            string time = string.Empty;
            string direction = string.Empty;
            string message = string.Empty;
            string device = string.Empty;
            string session = string.Empty;
            string imagekey = string.Empty;
            FResultCode fResultCode = FResultCode.Success;
            // --
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            UltraGridRow gridRow = null;

            try
            {
                grdList.beginUpdate(false);

                // --

                foreach (FIObjectLog fObjectLog in m_fTcpDriverLog.fChildObjectLogCollection)
                {
                    if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog)
                    {
                        time = ((FTcpDeviceDataMessageReceivedLog)fObjectLog).time;
                        direction = "EAP ← " + ((FTcpDeviceDataMessageReceivedLog)fObjectLog).sessionName;
                        message =
                            "[" +
                            ((FTcpDeviceDataMessageReceivedLog)fObjectLog).command.ToString() + " " +
                            "V" + ((FTcpDeviceDataMessageReceivedLog)fObjectLog).version.ToString() +
                            "] " + ((FTcpDeviceDataMessageReceivedLog)fObjectLog).name;
                        device = ((FTcpDeviceDataMessageReceivedLog)fObjectLog).deviceName;
                        session = ((FTcpDeviceDataMessageReceivedLog)fObjectLog).sessionName;
                        // --
                        if (((FTcpDeviceDataMessageReceivedLog)fObjectLog).fTcpMessageType == FTcpMessageType.Command)
                        {
                            imagekey = "TdvDataMessageReceivedLog_Command";
                        }
                        else if (((FTcpDeviceDataMessageReceivedLog)fObjectLog).fTcpMessageType == FTcpMessageType.Unsolicited)
                        {
                            imagekey = "TdvDataMessageReceivedLog_Unsolicited";
                        }
                        else
                        {
                            imagekey = "TdvDataMessageReceivedLog_Reply";
                        }
                        // --
                        fResultCode = ((FTcpDeviceDataMessageReceivedLog)fObjectLog).fResultCode;
                    }
                    else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog)
                    {
                        time = ((FTcpDeviceDataMessageSentLog)fObjectLog).time;
                        direction = "EAP → " + ((FTcpDeviceDataMessageSentLog)fObjectLog).sessionName;
                        message =
                            "[" +
                            "S" + ((FTcpDeviceDataMessageSentLog)fObjectLog).command.ToString() + " " +
                            "V" + ((FTcpDeviceDataMessageSentLog)fObjectLog).version.ToString() +
                            "] " + ((FTcpDeviceDataMessageSentLog)fObjectLog).name;
                        device = ((FTcpDeviceDataMessageSentLog)fObjectLog).deviceName;
                        session = ((FTcpDeviceDataMessageSentLog)fObjectLog).sessionName;
                        // --
                        if (((FTcpDeviceDataMessageSentLog)fObjectLog).fTcpMessageType == FTcpMessageType.Command)
                        {
                            imagekey = "TdvDataMessageSentLog_Command";
                        }
                        else if (((FTcpDeviceDataMessageSentLog)fObjectLog).fTcpMessageType == FTcpMessageType.Unsolicited)
                        {
                            imagekey = "TdvDataMessageSentLog_Unsolicited";
                        }
                        else
                        {
                            imagekey = "TdvDataMessageSentLog_Reply";
                        }
                        // --
                        fResultCode = ((FTcpDeviceDataMessageSentLog)fObjectLog).fResultCode;
                    }
                    else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                    {
                        time = ((FHostDeviceDataMessageReceivedLog)fObjectLog).time;
                        direction = "EAP ← " + ((FHostDeviceDataMessageReceivedLog)fObjectLog).sessionName;
                        message =
                            "[" +
                            ((FHostDeviceDataMessageReceivedLog)fObjectLog).command + " " +
                            "V" + ((FHostDeviceDataMessageReceivedLog)fObjectLog).version.ToString() +
                            "] " + ((FHostDeviceDataMessageReceivedLog)fObjectLog).name;
                        device = ((FHostDeviceDataMessageReceivedLog)fObjectLog).deviceName;
                        session = ((FHostDeviceDataMessageReceivedLog)fObjectLog).sessionName;
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
                        direction = "EAP → " + ((FHostDeviceDataMessageSentLog)fObjectLog).sessionName;
                        message =
                            "[" +
                            ((FHostDeviceDataMessageSentLog)fObjectLog).command + " " +
                            "V" + ((FHostDeviceDataMessageSentLog)fObjectLog).version.ToString() +
                            "] " + ((FHostDeviceDataMessageSentLog)fObjectLog).name;
                        device = ((FHostDeviceDataMessageSentLog)fObjectLog).deviceName;
                        session = ((FHostDeviceDataMessageSentLog)fObjectLog).sessionName;
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
                        direction,
                        message,
                        device,
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

                    if (gridRow != null && !gridRow.IsFilteredOut )
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
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfObjectLog(
            FIObjectLog fObjectLog
            )
        {
            UltraTreeNode tNode = null;

            try
            {
                tvwTree.beginUpdate();
                tvwTree.Nodes.Clear();

                // --

                tNode = new UltraTreeNode(fObjectLog.logUniqueIdToString, fObjectLog.ToString(FStringOption.Detail));
                tNode.Tag = fObjectLog;
                refreshTreeNodeOfObjectLog(fObjectLog, tvwTree, tNode);

                // --

                loadTreeOfChildObjectLog(tNode);

                // --

                tNode.ExpandAll();
                tvwTree.Nodes.Add(tNode);
                tvwTree.ActiveNode = tNode;

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
                fParent = (FIObjectLog)tNodeParent.Tag;
                // --
                if (fParent.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog)
                {
                    foreach (FTcpItemLog fTitl in ((FTcpDeviceDataMessageReceivedLog)fParent).fChildTcpItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fTitl.logUniqueIdToString);
                        tNodeChild.Tag = fTitl;
                        refreshTreeNodeOfObjectLog(fTitl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                        // --
                        loadTreeOfChildObjectLog(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog)
                {
                    foreach (FTcpItemLog fTitl in ((FTcpDeviceDataMessageSentLog)fParent).fChildTcpItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fTitl.logUniqueIdToString);
                        tNodeChild.Tag = fTitl;
                        refreshTreeNodeOfObjectLog(fTitl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                        // --
                        loadTreeOfChildObjectLog(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.TcpItemLog)
                {
                    foreach (FTcpItemLog fTitl in ((FTcpItemLog)fParent).fChildTcpItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fTitl.logUniqueIdToString);
                        tNodeChild.Tag = fTitl;
                        refreshTreeNodeOfObjectLog(fTitl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                        // --
                        loadTreeOfChildObjectLog(tNodeChild);
                    }
                }
                // --
                else if (fParent.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                {
                    foreach (FHostItemLog fHitl in ((FHostDeviceDataMessageReceivedLog)fParent).fChildHostItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fHitl.logUniqueIdToString);
                        tNodeChild.Tag = fHitl;
                        refreshTreeNodeOfObjectLog(fHitl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                        // --
                        loadTreeOfChildObjectLog(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                {
                    foreach (FHostItemLog fHitl in ((FHostDeviceDataMessageSentLog)fParent).fChildHostItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fHitl.logUniqueIdToString);
                        tNodeChild.Tag = fHitl;
                        refreshTreeNodeOfObjectLog(fHitl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                        // --
                        loadTreeOfChildObjectLog(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.HostItemLog)
                {
                    foreach (FHostItemLog fHitl in ((FHostItemLog)fParent).fChildHostItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fHitl.logUniqueIdToString);
                        tNodeChild.Tag = fHitl;
                        refreshTreeNodeOfObjectLog(fHitl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                        // --
                        loadTreeOfChildObjectLog(tNodeChild);
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

                if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog)
                {
                    sb.Append(writeHeader((FTcpDeviceDataMessageReceivedLog)fObjectLog));
                    sb.Append(((FTcpDeviceDataMessageReceivedLog)fObjectLog).convertToXml());
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog)
                {
                    sb.Append(writeHeader((FTcpDeviceDataMessageSentLog)fObjectLog));
                    sb.Append(((FTcpDeviceDataMessageSentLog)fObjectLog).convertToXml());
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

        private string writeHeader(
            FTcpDeviceDataMessageReceivedLog receivedLog
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
                    "TcpDevice=<" + receivedLog.name + ">, " +
                    "SessionId=<" + receivedLog.sessionId + ">, " +
                    "Length=<" + receivedLog.length + ">"
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
            FTcpDeviceDataMessageSentLog sentLog
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
                    "TcpDevice=<" + sentLog.name + ">, " +
                    "SessionId=<" + sentLog.sessionId + ">, " +
                    "Length=<" + sentLog.length + ">"
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
            
            try
            {
                if (grdList.activeDataRow != null)
                {
                    beforeKey = grdList.activeDataRowKey;
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

            try
            {
                fProgress = new FProgress();
                fProgress.show(m_fAdmCore.fWsmCore.fWsmContainer);

                // --

                if (m_backupFileName == string.Empty)
                {
                    loadEapInterfaceLogFile(beforeKey);
                }
                else
                {
                    loadEapInterfaceBackupLogFile(beforeKey);
                }

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

        private void procMenuRefreshLog(
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
                continueTcpLog(FLogContinuity.Previous);
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
                continueTcpLog(FLogContinuity.Next);
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
            try
            {
                tvwTree.beginUpdate();

                // -- 

                tvwTree.ActiveNode.ExpandAll();

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

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuCollapse(
            )
        {
            try
            {
                tvwTree.beginUpdate();

                // --

                tvwTree.ActiveNode.CollapseAll();

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

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuCopy(
            )
        {
            UltraTreeNode tNode = null;
            FIObjectLog fObjectLog = null;

            try
            {
                tNode = tvwTree.ActiveNode;
                fObjectLog = (FIObjectLog)tNode.Tag;

                // --

                if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog)
                {
                    ((FTcpDeviceDataMessageReceivedLog)fObjectLog).copy();
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog)
                {
                    ((FTcpDeviceDataMessageSentLog)fObjectLog).copy();
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpItemLog)
                {
                    ((FTcpItemLog)fObjectLog).copy();
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
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
                fObjectLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSendMessage(
            )
        {
            FTcpHostMessageSender fHostMsgSender = null;
            FIObjectLog fObjectLog = null;
            List<FIObjectLog> fSentLogList = null;

            try
            {
                fSentLogList = new List<FIObjectLog>();
                foreach (UltraDataRow row in grdList.selectedDataRows)
                {
                    fObjectLog = (FIObjectLog)row.Tag;
                    // -- 
                    if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                    {
                        fSentLogList.Add(fObjectLog);
                    }
                }

                // -- 

                fHostMsgSender = new FTcpHostMessageSender(m_fAdmCore, fSentLogList);
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

        private void procMenuXlgViewer(
            )
        {
            FTcpProtocolSelector fProtocolSelector = null;
            FXlgLogViewer fXlgLogViewer = null;
            FIObjectLog fObjectLog = null;
            StringBuilder sb = null;

            try
            {
                fProtocolSelector = new FTcpProtocolSelector(m_fAdmCore);
                if (fProtocolSelector.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }

                // --

                sb = new StringBuilder();
                foreach (UltraDataRow row in grdList.selectedDataRows)
                {
                    fObjectLog = (FIObjectLog)row.Tag;
                    // -- 
                    if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog)
                    {
                        sb.Append(writeHeader((FTcpDeviceDataMessageReceivedLog)fObjectLog));
                        sb.Append(((FTcpDeviceDataMessageReceivedLog)fObjectLog).convertToXml(fProtocolSelector.fSelectedProtocol));
                    }
                    else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog)
                    {
                        sb.Append(writeHeader((FTcpDeviceDataMessageSentLog)fObjectLog));
                        sb.Append(((FTcpDeviceDataMessageSentLog)fObjectLog).convertToXml(fProtocolSelector.fSelectedProtocol));
                    }
                }

                // --

                foreach (FBaseTabChildForm f in m_fAdmCore.fAdmContainer.fChilds)
                {
                    if (f is FXlgLogViewer && ((FXlgLogViewer)f).fileName == string.Empty)
                    {
                        fXlgLogViewer = ((FXlgLogViewer)f);
                        fXlgLogViewer.appendXlg(sb.ToString());
                        fXlgLogViewer.activate();
                        return;
                    }
                }

                // --

                fXlgLogViewer = new FXlgLogViewer(m_fAdmCore);
                fXlgLogViewer.appendXlg(sb.ToString());
                m_fAdmCore.fAdmContainer.showChild(fXlgLogViewer);
                fXlgLogViewer.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fProtocolSelector = null;
                fObjectLog = null;
                fXlgLogViewer = null;
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

            try
            {
                sb = new StringBuilder();
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

        private void procMenuConvertToTcpLog(
            )
        {
            FTcpLogViewer fTcpLogViewer = null;
            string beforeKey = string.Empty;

            try
            {
                if (grdList.activeDataRow != null)
                {
                    beforeKey = grdList.activeDataRowKey;
                }

                // --

                foreach (FBaseTabChildForm fChildForm in m_fAdmCore.fAdmContainer.fChilds)
                {
                    if (
                        fChildForm is FTcpLogViewer &&
                        ((FTcpLogViewer)fChildForm).fileName == m_fileName
                        )
                    {
                        fTcpLogViewer = (FTcpLogViewer)fChildForm;
                        fTcpLogViewer.refreshLog(beforeKey);
                        fTcpLogViewer.activate();
                        return;
                    }
                }
                // --
                fTcpLogViewer = new FTcpLogViewer(m_fAdmCore, m_eapId, m_backupFileName, m_fileName, beforeKey);
                m_fAdmCore.fAdmContainer.showChild(fTcpLogViewer);
                fTcpLogViewer.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fTcpLogViewer = null;
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
                if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceStateChangedLog)
                {
                    return ((FTcpDeviceStateChangedLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceErrorRaisedLog)
                {
                    return ((FTcpDeviceErrorRaisedLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceTimeoutRaisedLog)
                {
                    return ((FTcpDeviceTimeoutRaisedLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog)
                {
                    return ((FTcpDeviceDataMessageReceivedLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog)
                {
                    return ((FTcpDeviceDataMessageSentLog)fObjectLog).time;
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
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpTriggerRaisedLog)
                {
                    return ((FTcpTriggerRaisedLog)fObjectLog).time;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpTransmitterRaisedLog)
                {
                    return ((FTcpTransmitterRaisedLog)fObjectLog).time;
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

        public void refreshTreeNodeOfObjectLog(
            FIObjectLog fObjectLog,
            FTreeView tvwTree,
            UltraTreeNode tNode
            )
        {
            FResultCode fResultCode = FResultCode.Success;

            try
            {
                tNode.Text = fObjectLog.ToString(FStringOption.Detail);
                // --
                tNode.Override.NodeAppearance.ForeColor = fObjectLog.fontColor;
                tNode.Override.NodeAppearance.FontData.Bold = fObjectLog.fontBold ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False;
                // --
                tNode.Override.ActiveNodeAppearance.ForeColor = fObjectLog.fontColor;
                tNode.Override.ActiveNodeAppearance.FontData.Bold = fObjectLog.fontBold ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False;
                // --
                tNode.Override.SelectedNodeAppearance.ForeColor = fObjectLog.fontColor;
                tNode.Override.SelectedNodeAppearance.FontData.Bold = fObjectLog.fontBold ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False;
                // --
                tNode.Override.ImageSize = new System.Drawing.Size(16, 16);
                tNode.Override.NodeAppearance.Image = getImageOfObjectLog(fObjectLog, tvwTree);

                // --

                fResultCode = getResultCode(fObjectLog);
                if (fResultCode != FResultCode.Success)
                {
                    tNode.LeftImages.Add(fResultCode == FResultCode.Warninig ?
                        tvwTree.ImageList.Images["Result_Warning"] : tvwTree.ImageList.Images["Result_Error"]
                        );
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

        public Image getImageOfObjectLog(
            FIObjectLog fObjectLog,
            FTreeView tvwTree
            )
        {
            FDeviceState fDeviceState;
            FTcpMessageType fTcpMessageType;
            FHostMessageType fHostMessageType;

            try
            {
                // ***
                // TcpDriver
                // ***
                if (fObjectLog.fObjectLogType == FObjectLogType.TcpDriverLog)
                {
                    return tvwTree.ImageList.Images["TcpDriverLog"];
                }
                // ***
                // TcpDevice
                // ***
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceStateChangedLog)
                {
                    fDeviceState = ((FTcpDeviceStateChangedLog)fObjectLog).fState;
                    if (fDeviceState == FDeviceState.Opened)
                    {
                        return tvwTree.ImageList.Images["TdvStateChangedLog_Opened"];
                    }
                    else if (fDeviceState == FDeviceState.Connected)
                    {
                        return tvwTree.ImageList.Images["TdvStateChangedLog_Connected"];
                    }
                    else if (fDeviceState == FDeviceState.Selected)
                    {
                        return tvwTree.ImageList.Images["TdvStateChangedLog_Selected"];
                    }
                    else if (fDeviceState == FDeviceState.Closed)
                    {
                        return tvwTree.ImageList.Images["TdvStateChangedLog_Closed"];
                    }
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog)
                {
                    fTcpMessageType = ((FTcpDeviceDataMessageReceivedLog)fObjectLog).fTcpMessageType;
                    if (fTcpMessageType == FTcpMessageType.Command)
                    {
                        return tvwTree.ImageList.Images["TdvDataMessageReceivedLog_Command"];
                    }
                    else if (fTcpMessageType == FTcpMessageType.Unsolicited)
                    {
                        return tvwTree.ImageList.Images["TdvDataMessageReceivedLog_Unsolicited"];
                    }
                    else if (fTcpMessageType == FTcpMessageType.Reply)
                    {
                        return tvwTree.ImageList.Images["TdvDataMessageReceivedLog_Reply"];
                    }
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog)
                {
                    fTcpMessageType = ((FTcpDeviceDataMessageSentLog)fObjectLog).fTcpMessageType;
                    if (fTcpMessageType == FTcpMessageType.Command)
                    {
                        return tvwTree.ImageList.Images["TdvDataMessageSentLog_Command"];
                    }
                    else if (fTcpMessageType == FTcpMessageType.Unsolicited)
                    {
                        return tvwTree.ImageList.Images["TdvDataMessageSentLog_Unsolicited"];
                    }
                    else if (fTcpMessageType == FTcpMessageType.Reply)
                    {
                        return tvwTree.ImageList.Images["TdvDataMessageSentLog_Reply"];
                    }
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpItemLog)
                {
                    return ((FTcpItemLog)fObjectLog).fFormat == FFormat.List ? tvwTree.ImageList.Images["TcpItemLog_List"] : tvwTree.ImageList.Images["TcpItemLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataReceivedLog)
                {
                    return tvwTree.ImageList.Images["TdvDataReceivedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataSentLog)
                {
                    return tvwTree.ImageList.Images["TdvDataSentLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceXmlReceivedLog)
                {
                    return tvwTree.ImageList.Images["TdvXlgReceivedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceXmlSentLog)
                {
                    return tvwTree.ImageList.Images["TdvXlgSentLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceErrorRaisedLog)
                {
                    return tvwTree.ImageList.Images["TdvErrorRaisedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceTimeoutRaisedLog)
                {
                    return tvwTree.ImageList.Images["TdvTimeoutRaisedLog"];
                }
                // ***
                // HostDevice
                // ***
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceStateChangedLog)
                {
                    fDeviceState = ((FHostDeviceStateChangedLog)fObjectLog).fState;
                    if (fDeviceState == FDeviceState.Opened)
                    {
                        return tvwTree.ImageList.Images["HdvStateChangedLog_Opened"];
                    }
                    else if (fDeviceState == FDeviceState.Connected)
                    {
                        return tvwTree.ImageList.Images["HdvStateChangedLog_Connected"];
                    }
                    else if (fDeviceState == FDeviceState.Selected)
                    {
                        return tvwTree.ImageList.Images["HdvStateChangedLog_Selected"];
                    }
                    else if (fDeviceState == FDeviceState.Closed)
                    {
                        return tvwTree.ImageList.Images["HdvStateChangedLog_Closed"];
                    }
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                {
                    fHostMessageType = ((FHostDeviceDataMessageReceivedLog)fObjectLog).fHostMessageType;
                    if (fHostMessageType == FHostMessageType.Command)
                    {
                        return tvwTree.ImageList.Images["HdvDataMessageReceivedLog_Command"];
                    }
                    else if (fHostMessageType == FHostMessageType.Unsolicited)
                    {
                        return tvwTree.ImageList.Images["HdvDataMessageReceivedLog_Unsolicited"];
                    }
                    else if (fHostMessageType == FHostMessageType.Reply)
                    {
                        return tvwTree.ImageList.Images["HdvDataMessageReceivedLog_Reply"];
                    }
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                {
                    fHostMessageType = ((FHostDeviceDataMessageSentLog)fObjectLog).fHostMessageType;
                    if (fHostMessageType == FHostMessageType.Command)
                    {
                        return tvwTree.ImageList.Images["HdvDataMessageSentLog_Command"];
                    }
                    else if (fHostMessageType == FHostMessageType.Unsolicited)
                    {
                        return tvwTree.ImageList.Images["HdvDataMessageSentLog_Unsolicited"];
                    }
                    else if (fHostMessageType == FHostMessageType.Reply)
                    {
                        return tvwTree.ImageList.Images["HdvDataMessageSentLog_Reply"];
                    }
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostItemLog)
                {
                    return ((FHostItemLog)fObjectLog).fFormat == FFormat.List ? tvwTree.ImageList.Images["HostItemLog_List"] : tvwTree.ImageList.Images["HostItemLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceVfeiReceivedLog)
                {
                    return tvwTree.ImageList.Images["HdvVfeiReceivedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceVfeiSentLog)
                {
                    return tvwTree.ImageList.Images["HdvVfeiSentLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceErrorRaisedLog)
                {
                    return tvwTree.ImageList.Images["HdvErrorRaisedLog"];
                }
                // ***
                // Scenario
                // ***
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpTriggerRaisedLog)
                {
                    return tvwTree.ImageList.Images["TcpTriggerRaisedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpTransmitterRaisedLog)
                {
                    return tvwTree.ImageList.Images["TcpTransmitterRaisedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTriggerRaisedLog)
                {
                    return tvwTree.ImageList.Images["HostTriggerRaisedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTransmitterRaisedLog)
                {
                    return tvwTree.ImageList.Images["HostTransmitterRaisedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.JudgementPerformedLog)
                {
                    return tvwTree.ImageList.Images["JudgementPerformedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.MapperPerformedLog)
                {
                    return tvwTree.ImageList.Images["MapperPerformedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EquipmentStateSetAltererPerformedLog)
                {
                    return tvwTree.ImageList.Images["EquipmentStateSetAltererPerformedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EquipmentStateAltererLog)
                {
                    return tvwTree.ImageList.Images["EquipmentStateAltererLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.DataSetLog)
                {
                    return tvwTree.ImageList.Images["DataSetLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.DataLog)
                {
                    return ((FDataLog)fObjectLog).fFormat == FFormat.List ? tvwTree.ImageList.Images["DataLog_List"] : tvwTree.ImageList.Images["DataLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.StoragePerformedLog)
                {
                    return tvwTree.ImageList.Images["StoragePerformedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.RepositoryLog)
                {
                    return tvwTree.ImageList.Images["RepositoryLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.ColumnLog)
                {
                    return ((FColumnLog)fObjectLog).fFormat == FFormat.List ? tvwTree.ImageList.Images["ColumnLog_List"] : tvwTree.ImageList.Images["ColumnLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CallbackRaisedLog)
                {
                    return tvwTree.ImageList.Images["CallbackRaisedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.BranchRaisedLog)
                {
                    return tvwTree.ImageList.Images["BranchRaisedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.FunctionCalledLog)
                {
                    return tvwTree.ImageList.Images["FunctionCalledLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CommentWrittenLog)
                {
                    return tvwTree.ImageList.Images["CommentWritedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PauserRaisedLog)
                {
                    return tvwTree.ImageList.Images["PauserRaisedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EntryPointCalledLog)
                {
                    return tvwTree.ImageList.Images["EntryPointCalledLog"];
                }
                // ***
                // Application
                // ***
                else if (fObjectLog.fObjectLogType == FObjectLogType.ApplicationWrittenLog)
                {
                    return tvwTree.ImageList.Images["ApplicationWritedLog"];
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.ContentLog)
                {
                    return ((FContentLog)fObjectLog).fFormat == FFormat.List ? tvwTree.ImageList.Images["ContentLog_List"] : tvwTree.ImageList.Images["ContentLog"];
                }

                // --

                return null;
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

        //------------------------------------------------------------------------------------------------------------------------

        public FResultCode getResultCode(
            FIObjectLog fObjectLog
            )
        {
            FResultCode fResultCode = FResultCode.Success;

            try
            {
                // ***
                // TcpDevice
                // ***
                if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceStateChangedLog)
                {
                    fResultCode = ((FTcpDeviceStateChangedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog)
                {
                    fResultCode = ((FTcpDeviceDataMessageReceivedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog)
                {
                    fResultCode = ((FTcpDeviceDataMessageSentLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataReceivedLog)
                {
                    fResultCode = ((FTcpDeviceDataReceivedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataSentLog)
                {
                    fResultCode = ((FTcpDeviceDataSentLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceXmlReceivedLog)
                {
                    fResultCode = ((FTcpDeviceXmlReceivedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceXmlSentLog)
                {
                    fResultCode = ((FTcpDeviceXmlSentLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceErrorRaisedLog)
                {
                    fResultCode = ((FTcpDeviceErrorRaisedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceTimeoutRaisedLog)
                {
                    fResultCode = ((FTcpDeviceTimeoutRaisedLog)fObjectLog).fResultCode;
                }
                // ***
                // HostDevice
                // ***
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceStateChangedLog)
                {
                    fResultCode = ((FHostDeviceStateChangedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                {
                    fResultCode = ((FHostDeviceDataMessageReceivedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                {
                    fResultCode = ((FHostDeviceDataMessageSentLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceVfeiReceivedLog)
                {
                    fResultCode = ((FHostDeviceVfeiReceivedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceVfeiSentLog)
                {
                    fResultCode = ((FHostDeviceVfeiSentLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceErrorRaisedLog)
                {
                    fResultCode = ((FHostDeviceErrorRaisedLog)fObjectLog).fResultCode;
                }
                // ***
                // Scenario
                // ***
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpTriggerRaisedLog)
                {
                    fResultCode = ((FTcpTriggerRaisedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpTransmitterRaisedLog)
                {
                    fResultCode = ((FTcpTransmitterRaisedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTriggerRaisedLog)
                {
                    fResultCode = ((FHostTriggerRaisedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTransmitterRaisedLog)
                {
                    fResultCode = ((FHostTransmitterRaisedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.JudgementPerformedLog)
                {
                    fResultCode = ((FJudgementPerformedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.MapperPerformedLog)
                {
                    fResultCode = ((FMapperPerformedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EquipmentStateSetAltererPerformedLog)
                {
                    fResultCode = ((FEquipmentStateSetAltererPerformedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.StoragePerformedLog)
                {
                    fResultCode = ((FStoragePerformedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CallbackRaisedLog)
                {
                    fResultCode = ((FCallbackRaisedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.BranchRaisedLog)
                {
                    fResultCode = ((FBranchRaisedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.FunctionCalledLog)
                {
                    fResultCode = ((FFunctionCalledLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CommentWrittenLog)
                {
                    fResultCode = ((FCommentWrittenLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PauserRaisedLog)
                {
                    fResultCode = ((FPauserRaisedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EntryPointCalledLog)
                {
                    fResultCode = ((FEntryPointCalledLog)fObjectLog).fResultCode;
                }
                // ***
                // Application
                // ***
                else if (fObjectLog.fObjectLogType == FObjectLogType.ApplicationWrittenLog)
                {
                    fResultCode = ((FApplicationWrittenLog)fObjectLog).fResultCode;
                }

                // --

                return fResultCode;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FResultCode.Success;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FTcpInterfaceLogViewer Form Event Handler

        private void FTcpInterfaceLogViewer_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                ((FontListTool)mnuLogMenu.Tools[FMenuKey.MenuTivFontName]).Text = m_fAdmCore.fOption.fontName;
                numFontSize.Value = m_fAdmCore.fOption.fontSize;

                // --

                txtLog.Appearance.FontData.Name = ((FontListTool)mnuLogMenu.Tools[FMenuKey.MenuTivFontName]).Value.ToString();
                txtLog.Appearance.FontData.SizeInPoints = float.Parse(numFontSize.Value.ToString());

                // --

                m_fTcpDriverLog = new FTcpDriverLog();

                // --

                designGridOfLog();
                designTreeOfLog();

                // --

                m_fAdmCore.fOption.fChildFormList.add(this, this.Text + " - [" + string.Join(",", m_fileName) + "]");
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

        private void FTcpInterfaceLogViewer_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                txtLogType.Text = "EAP - [ " + m_eapId + " ]";
                txtFileName.Text = string.Join(",", m_fileName);

                // --

                refreshLog(m_beforeKey);
                
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

        private void FTcpInterfaceLogViewer_FormClosing(
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

        private void FTcpInterfaceLogViewer_KeyDown(
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
            ToolClickEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tool.Key == FMenuKey.MenuTivRefresh)
                {
                    procMenuRefreshLog();
                }
                else if (e.Tool.Key == FMenuKey.MenuTivPrevious)
                {
                    procMenuPrevious();
                }
                else if (e.Tool.Key == FMenuKey.MenuTivNext)
                {
                    procMenuNext();
                }
                else if (e.Tool.Key == FMenuKey.MenuTivExpand)
                {
                    procMenuExpand();
                }
                else if (e.Tool.Key == FMenuKey.MenuTivCollapse)
                {
                    procMenuCollapse();
                }
                else if (e.Tool.Key == FMenuKey.MenuTivCopy)
                {
                    procMenuCopy();
                }
                else if (e.Tool.Key == FMenuKey.MenuTivSendMessage)
                {
                    procMenuSendMessage();
                }
                else if (e.Tool.Key == FMenuKey.MenuTivConvertToXlg)
                {
                    procMenuXlgViewer();
                }
                else if (e.Tool.Key == FMenuKey.MenuTivConvertToVfei)
                {
                    procMenuVfeiViewer();
                }                
                else if (e.Tool.Key == FMenuKey.MenuTivConvertToTcpLog)
                {
                    procMenuConvertToTcpLog();
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

        #region mnuLogMenu Control Event Handler

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

        //------------------------------------------------------------------------------------------------------------------------

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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region grdList Control Event Handler

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

                mnuMenu.ShowPopup(FMenuKey.MenuTivPopupMenuGrid);
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

        //------------------------------------------------------------------------------------------------------------------------

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
                    tvwTree.beginUpdate();
                    tvwTree.Nodes.Clear();
                    tvwTree.endUpdate();

                    // --

                    txtLog.beginUpdate();
                    txtLog.Text = string.Empty;
                    txtLog.endUpdate();
                }
                else
                {
                    loadTreeOfObjectLog((FIObjectLog)grdList.activeDataRow.Tag);
                    loadTextOfObjectLog((FIObjectLog)grdList.activeDataRow.Tag);
                }
                
                // --

                controlMenu();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region rstToolbar Control Event Handler

        private void rstToolbar_SearchRequested(
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

                if (tvwTree.ActiveNode == null)
                {
                    return;
                }

                // --

                tNode = tvwTree.ActiveNode;
                fBase = (FIObjectLog)tNode.Tag;
                // --
                fFirst = m_fTcpDriverLog.searchLogSeries(fBase, e.searchWord);
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
                        fResult.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog ||
                        fResult.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog ||
                        fResult.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog ||
                        fResult.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog
                        )
                    {
                        fMessage = fResult;
                    }
                    else if (fResult.fObjectLogType == FObjectLogType.TcpItemLog)
                    {
                        fTemp = fResult;
                        while (((FTcpItemLog)fTemp).fParent.fObjectLogType != FObjectLogType.TcpDriverLog)
                        {
                            if (
                                ((FTcpItemLog)fTemp).fParent.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog ||
                                ((FTcpItemLog)fTemp).fParent.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog
                                )
                            {
                                fMessage = ((FTcpItemLog)fTemp).fParent;
                                break;
                            }
                            else
                            {
                                fTemp = ((FTcpItemLog)fTemp).fParent;
                            }
                        }
                    }
                    else if (fResult.fObjectLogType == FObjectLogType.HostItemLog)
                    {
                        fTemp = fResult;
                        while (((FHostItemLog)fTemp).fParent.fObjectLogType != FObjectLogType.TcpDriverLog)
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
                        fResult = m_fTcpDriverLog.searchLogSeries(fResult, e.searchWord);
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
                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tvwTree.GetNodeByKey(fResult.logUniqueIdToString);                
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
