/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FTcpLogViewer.cs
--  Creator         : mjkim
--  Create Date     : 2013.01.11
--  Description     : FAMate Admin Manager TCP Log Viewer Form Class 
--  History         : Created by mjkim at 2013.01.11             
----------------------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinTree;
using Nexplant.MC.AdminManager.FaTcpLogViewer;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaTcpDriver;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public partial class FTcpLogViewer : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private string m_eapId = string.Empty;
        private string m_backupFileName = string.Empty;
        private string m_fileName = string.Empty;
        private FAdmCore m_fAdmCore = null;
        private FTcpDriverLog m_fTcpDriverLog = null;
        private FTcpLogFilter m_fLogFilter = null;
        private string m_beforeKey = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTcpLogViewer(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpLogViewer(
            FAdmCore fAdmCore,
            string fileName
            )
            : this(fAdmCore, string.Empty, string.Empty, fileName)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpLogViewer(
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

        public FTcpLogViewer(
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
                return string.Empty;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

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
                tvwTree.ImageList.Images.Add("TcpDriverLog", Properties.Resources.TcpDriverLog);
                // --
                tvwTree.ImageList.Images.Add("TdvStateChangedLog_Closed", Properties.Resources.TdvStateChangedLog_Closed);
                tvwTree.ImageList.Images.Add("TdvStateChangedLog_Opened", Properties.Resources.TdvStateChangedLog_Opened);
                tvwTree.ImageList.Images.Add("TdvStateChangedLog_Connected", Properties.Resources.TdvStateChangedLog_Connected);
                tvwTree.ImageList.Images.Add("TdvStateChangedLog_Selected", Properties.Resources.TdvStateChangedLog_Selected);
                tvwTree.ImageList.Images.Add("TdvDataMessageReceivedLog_Command", Properties.Resources.TdvDataMessageReceivedLog_Command);
                tvwTree.ImageList.Images.Add("TdvDataMessageReceivedLog_Reply", Properties.Resources.TdvDataMessageReceivedLog_Reply);
                tvwTree.ImageList.Images.Add("TdvDataMessageReceivedLog_Unsolicited", Properties.Resources.TdvDataMessageReceivedLog_Unsolicited);
                tvwTree.ImageList.Images.Add("TdvDataMessageSentLog_Command", Properties.Resources.TdvDataMessageSentLog_Command);
                tvwTree.ImageList.Images.Add("TdvDataMessageSentLog_Reply", Properties.Resources.TdvDataMessageSentLog_Reply);
                tvwTree.ImageList.Images.Add("TdvDataMessageSentLog_Unsolicited", Properties.Resources.TdvDataMessageSentLog_Unsolicited);
                tvwTree.ImageList.Images.Add("TcpItemLog_List", Properties.Resources.TcpItemLog_List);
                tvwTree.ImageList.Images.Add("TcpItemLog", Properties.Resources.TcpItemLog);             
                tvwTree.ImageList.Images.Add("TdvDataReceivedLog", Properties.Resources.TdvDataReceivedLog);
                tvwTree.ImageList.Images.Add("TdvDataSentLog", Properties.Resources.TdvDataSentLog);
                tvwTree.ImageList.Images.Add("TdvErrorRaisedLog", Properties.Resources.TdvErrorRaisedLog);
                tvwTree.ImageList.Images.Add("TdvTimeoutRaisedLog", Properties.Resources.TdvTimeoutRaisedLog);
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
                tvwTree.ImageList.Images.Add("TcpTriggerRaisedLog", Properties.Resources.TcpTriggerRaisedLog);
                tvwTree.ImageList.Images.Add("TcpTransmitterRaisedLog", Properties.Resources.TcpTransmitterRaisedLog);
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
                    fObjectLog = m_fTcpDriverLog;
                }

                // --

                mnuMenu.Tools[FMenuKey.MenuTlvFilter].SharedProps.Enabled = true;

                // -- 

                if (fObjectLog.fObjectLogType == FObjectLogType.TcpDriverLog)
                {
                    mnuMenu.Tools[FMenuKey.MenuTlvExpand].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuTlvCollapse].SharedProps.Enabled = false;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuTlvExpand].SharedProps.Enabled = true;
                    mnuMenu.Tools[FMenuKey.MenuTlvCollapse].SharedProps.Enabled = true;
                }

                // --

                if (
                    fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.TcpItemLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.HostItemLog
                    )
                {
                    mnuMenu.Tools[FMenuKey.MenuTlvCopy].SharedProps.Enabled = true;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuTlvCopy].SharedProps.Enabled = false;
                }

                // --

                if (
                    fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog
                    )
                {
                    mnuMenu.Tools[FMenuKey.MenuTlvConvertToXlg].SharedProps.Enabled = true;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuTlvConvertToXlg].SharedProps.Enabled = false;
                }

                // --

                if (
                   fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog ||
                   fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog
                   )
                {
                    mnuMenu.Tools[FMenuKey.MenuTlvConvertToVfei].SharedProps.Enabled = true;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuTlvConvertToVfei].SharedProps.Enabled = false;
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
                tNode = null;
                fObjectLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void refreshLog(
            )
        {
            string beforeKey = string.Empty;

            try
            {
                if (tvwTree.ActiveNode != null)
                {
                    beforeKey = tvwTree.ActiveNode.Key;
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
                    loadTcpLogFile(beforeKey);
                }
                else
                {
                    loadTcpBackupLogFile(beforeKey);
                }

                // --

                tvwTree.Focus();
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
                FCursor.waitCursor();

                // --

                tvwTree.beginUpdate();

                // -- 

                tvwTree.ActiveNode.ExpandAll();

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
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
            try
            {
                FCursor.waitCursor();

                // --

                tvwTree.beginUpdate();

                // --

                tvwTree.ActiveNode.CollapseAll();

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
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

            try
            {
                FCursor.waitCursor();

                // --

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
                foreach (UltraTreeNode node in tvwTree.SelectedNodes)
                {
                    fObjectLog = (FIObjectLog)node.Tag;

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

        private void procMenuConvertToTcpInterfaceLog(
            )
        {
            FTcpInterfaceLogViewer fTcpIftViewer = null;
            string beforeKey = string.Empty;

            try
            {
                if (tvwTree.ActiveNode != null)
                {
                    beforeKey = tvwTree.ActiveNode.Key;
                }

                // --

                foreach (FBaseTabChildForm fChildForm in m_fAdmCore.fAdmContainer.fChilds)
                {
                    if (
                        fChildForm is FTcpInterfaceLogViewer &&
                        ((FTcpInterfaceLogViewer)fChildForm).fileName == m_fileName
                        )
                    {
                        fTcpIftViewer = (FTcpInterfaceLogViewer)fChildForm;
                        fTcpIftViewer.refreshLog(beforeKey);
                        fTcpIftViewer.activate();
                        return;
                    }
                }
                // --
                fTcpIftViewer = new FTcpInterfaceLogViewer(m_fAdmCore, m_eapId, m_backupFileName, m_fileName, beforeKey);
                m_fAdmCore.fAdmContainer.showChild(fTcpIftViewer);
                fTcpIftViewer.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fTcpIftViewer = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuFilterSelector(
            )
        {
            FProgress fProgress = null;
            FTcpLogFilterSelector fLogFilterSelector = null;
            string beforeKey = string.Empty;

            try
            {
                fLogFilterSelector = new FTcpLogFilterSelector(m_fAdmCore, m_fLogFilter);
                if (fLogFilterSelector.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }
                m_fLogFilter = fLogFilterSelector.fLogFilter;
                m_fAdmCore.changeTcpLogFilter(m_fLogFilter);

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

                fFirstLog = m_fTcpDriverLog.searchLogSeries(fBaseLog, searchWord);
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
                        fResultLog = m_fTcpDriverLog.searchLogSeries(fResultLog, searchWord);
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
                if (fObjectLog.fObjectLogType == FObjectLogType.TcpDriverLog)
                {
                    return;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceStateChangedLog)
                {
                    fParentLog = ((FTcpDeviceStateChangedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceErrorRaisedLog)
                {
                    fParentLog = ((FTcpDeviceErrorRaisedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceTimeoutRaisedLog)
                {
                    fParentLog = ((FTcpDeviceTimeoutRaisedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataReceivedLog)
                {
                    fParentLog = ((FTcpDeviceDataReceivedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataSentLog)
                {
                    fParentLog = ((FTcpDeviceDataSentLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceXmlReceivedLog)
                {
                    fParentLog = ((FTcpDeviceXmlReceivedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceXmlSentLog)
                {
                    fParentLog = ((FTcpDeviceXmlSentLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog)
                {
                    fParentLog = ((FTcpDeviceDataMessageReceivedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog)
                {
                    fParentLog = ((FTcpDeviceDataMessageSentLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpItemLog)
                {
                    fParentLog = ((FTcpItemLog)fObjectLog).fParent;
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
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceVfeiReceivedLog)
                {
                    fParentLog = ((FHostDeviceVfeiReceivedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceVfeiSentLog)
                {
                    fParentLog = ((FHostDeviceVfeiSentLog)fObjectLog).fParent;
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
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpTriggerRaisedLog)
                {
                    fParentLog = ((FTcpTriggerRaisedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpTransmitterRaisedLog)
                {
                    fParentLog = ((FTcpTransmitterRaisedLog)fObjectLog).fParent;
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

                if (fType == FObjectLogType.TcpDriverLog)
                {
                    return true;
                }
                else if (fType == FObjectLogType.TcpDeviceStateChangedLog)
                {
                    return m_fLogFilter.enabledEventsOfTcpDeviceState;
                }
                else if (fType == FObjectLogType.TcpDeviceErrorRaisedLog)
                {
                    return m_fLogFilter.enabledEventsOfTcpDeviceError;
                }
                else if (fType == FObjectLogType.TcpDeviceTimeoutRaisedLog)
                {
                    return m_fLogFilter.enabledEventsOfTcpDeviceTimeout;
                }
                else if (
                    fType == FObjectLogType.TcpDeviceDataReceivedLog ||
                    fType == FObjectLogType.TcpDeviceDataSentLog
                    )
                {
                    return m_fLogFilter.enabledEventsOfTcpDeviceData;
                }
                else if (
                    fType == FObjectLogType.TcpDeviceXmlReceivedLog ||
                    fType == FObjectLogType.TcpDeviceXmlSentLog
                    )
                {
                    return m_fLogFilter.enabledEventsOfTcpDeviceXlg;
                }
                else if (
                    fType == FObjectLogType.TcpDeviceDataMessageReceivedLog ||
                    fType == FObjectLogType.TcpDeviceDataMessageSentLog ||
                    fType == FObjectLogType.TcpItemLog
                    )
                {
                    return m_fLogFilter.enabledEventsOfTcpDeviceDataMessage;
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
                    fType == FObjectLogType.HostDeviceVfeiReceivedLog ||
                    fType == FObjectLogType.HostDeviceVfeiSentLog
                    )
                {
                    return m_fLogFilter.enabledEventsOfHostDeviceVfei;
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
                    fType == FObjectLogType.TcpTriggerRaisedLog ||
                    fType == FObjectLogType.TcpTransmitterRaisedLog ||
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

        private void loadTcpLogFile(
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
                loadTreeOfObjectLog(beforeKey, FLogContinuity.Previous);

                // --

                controlMenu();
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

        private void loadTcpBackupLogFile(
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

                tvwTree.beginUpdate();
                tvwTree.Nodes.Clear();
                tvwTree.endUpdate();

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
                loadTreeOfObjectLog(beforeKey, FLogContinuity.Previous);

                // --

                controlMenu();
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

                tvwTree.beginUpdate();
                tvwTree.Nodes.Clear();
                tvwTree.endUpdate();

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
                loadTreeOfObjectLog(string.Empty, fLogContinuity);

                // --

                controlMenu();
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

                tvwTree.beginUpdate();
                tvwTree.Nodes.Clear();
                tvwTree.endUpdate();

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
                loadTreeOfObjectLog(string.Empty, fLogContinuity);

                // --

                controlMenu();
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

        private void loadTreeOfObjectLog(
            string beforeKey,
            FLogContinuity fLogContinuity
           )
        {
            UltraTreeNode tNodeTcdl = null;
            UltraTreeNode tNodeLog = null;
            UltraTreeNode tNodeChildLog = null;
            UltraTreeNode tNodeBeforeActived = null;

            try
            {
                tvwTree.beginUpdate();
                tvwTree.Nodes.Clear();

                // --

                // ***
                // TCP Driver Log Load
                // ***
                tNodeTcdl = new UltraTreeNode(m_fTcpDriverLog.logUniqueIdToString);
                tNodeTcdl.Tag = m_fTcpDriverLog;
                refreshTreeNodeOfObjectLog(m_fTcpDriverLog, tvwTree, tNodeTcdl);

                // --

                // ***
                // Log Object Load
                // ***
                foreach (FIObjectLog fObjectLog in m_fTcpDriverLog.fChildObjectLogCollection)
                {
                    if (isEnabledEventsOfObjectLog(fObjectLog))
                    {

                        tNodeLog = new UltraTreeNode(fObjectLog.logUniqueIdToString);
                        tNodeLog.Tag = fObjectLog;
                        refreshTreeNodeOfObjectLog(fObjectLog, tvwTree, tNodeLog);

                        // --

                        if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog)
                        {
                            foreach (FTcpItemLog fTitl in ((FTcpDeviceDataMessageReceivedLog)fObjectLog).fChildTcpItemLogCollection)
                            {
                                tNodeChildLog = new UltraTreeNode(fTitl.logUniqueIdToString);
                                tNodeChildLog.Tag = fTitl;
                                refreshTreeNodeOfObjectLog(fTitl, tvwTree, tNodeChildLog);
                                tNodeLog.Nodes.Add(tNodeChildLog);
                            }
                        }
                        else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog)
                        {
                            foreach (FTcpItemLog fTitl in ((FTcpDeviceDataMessageSentLog)fObjectLog).fChildTcpItemLogCollection)
                            {
                                tNodeChildLog = new UltraTreeNode(fTitl.logUniqueIdToString);
                                tNodeChildLog.Tag = fTitl;
                                refreshTreeNodeOfObjectLog(fTitl, tvwTree, tNodeChildLog);
                                tNodeLog.Nodes.Add(tNodeChildLog);
                            }
                        }
                        else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                        {
                            foreach (FHostItemLog fHitl in ((FHostDeviceDataMessageReceivedLog)fObjectLog).fChildHostItemLogCollection)
                            {
                                tNodeChildLog = new UltraTreeNode(fHitl.logUniqueIdToString);
                                tNodeChildLog.Tag = fHitl;
                                refreshTreeNodeOfObjectLog(fHitl, tvwTree, tNodeChildLog);
                                tNodeLog.Nodes.Add(tNodeChildLog);
                            }
                        }
                        else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                        {
                            foreach (FHostItemLog fHitl in ((FHostDeviceDataMessageSentLog)fObjectLog).fChildHostItemLogCollection)
                            {
                                tNodeChildLog = new UltraTreeNode(fHitl.logUniqueIdToString);
                                tNodeChildLog.Tag = fHitl;
                                refreshTreeNodeOfObjectLog(fHitl, tvwTree, tNodeChildLog);
                                tNodeLog.Nodes.Add(tNodeChildLog);
                            }
                        }
                        else if (fObjectLog.fObjectLogType == FObjectLogType.MapperPerformedLog)
                        {
                            foreach (FDataSetLog fDtsl in ((FMapperPerformedLog)fObjectLog).fChildDataSetLogCollection)
                            {
                                tNodeChildLog = new UltraTreeNode(fDtsl.logUniqueIdToString);
                                tNodeChildLog.Tag = fDtsl;
                                refreshTreeNodeOfObjectLog(fDtsl, tvwTree, tNodeChildLog);
                                tNodeLog.Nodes.Add(tNodeChildLog);
                            }
                        }
                        else if (fObjectLog.fObjectLogType == FObjectLogType.StoragePerformedLog)
                        {
                            foreach (FRepositoryLog fRpsl in ((FStoragePerformedLog)fObjectLog).fChildRepositoryLogCollection)
                            {
                                tNodeChildLog = new UltraTreeNode(fRpsl.logUniqueIdToString);
                                tNodeChildLog.Tag = fRpsl;
                                refreshTreeNodeOfObjectLog(fRpsl, tvwTree, tNodeChildLog);
                                tNodeLog.Nodes.Add(tNodeChildLog);
                            }
                        }
                        else if (fObjectLog.fObjectLogType == FObjectLogType.EquipmentStateSetAltererPerformedLog)
                        {
                            foreach (FEquipmentStateAltererLog fEatl in ((FEquipmentStateSetAltererPerformedLog)fObjectLog).fChildEquipmentStateAltererLogCollection)
                            {
                                tNodeChildLog = new UltraTreeNode(fEatl.logUniqueIdToString);
                                tNodeChildLog.Tag = fEatl;
                                refreshTreeNodeOfObjectLog(fEatl, tvwTree, tNodeChildLog);
                                tNodeLog.Nodes.Add(tNodeChildLog);
                            }
                        }
                        else if (fObjectLog.fObjectLogType == FObjectLogType.ApplicationWrittenLog)
                        {
                            foreach (FContentLog fCttl in ((FApplicationWrittenLog)fObjectLog).fChildContentLogCollection)
                            {
                                tNodeChildLog = new UltraTreeNode(fCttl.logUniqueIdToString);
                                tNodeChildLog.Tag = fCttl;
                                refreshTreeNodeOfObjectLog(fCttl, tvwTree, tNodeChildLog);
                                tNodeLog.Nodes.Add(tNodeChildLog);
                            }
                        }

                        // --

                        tNodeTcdl.Nodes.Add(tNodeLog);
                    }
                }

                // --

                tNodeTcdl.Expanded = true;
                tvwTree.Nodes.Add(tNodeTcdl);
                
                // --

                if (beforeKey != string.Empty)
                {
                    tNodeBeforeActived = tvwTree.GetNodeByKey(beforeKey);
                }

                // --

                tvwTree.ScrollBounds = ScrollBounds.ScrollToFill;
                if (tNodeBeforeActived != null)
                {
                    if (!tNodeBeforeActived.Parent.Expanded)
                    {
                        tNodeBeforeActived.Parent.Expanded = true;
                    }
                    // --
                    tvwTree.ActiveNode = tNodeBeforeActived;
                    tvwTree.TopNode = tvwTree.ActiveNode;
                }
                else
                {
                    if (tNodeTcdl.Nodes.Count == 0)
                    {
                        tvwTree.ActiveNode = tNodeTcdl;
                    }
                    else
                    {
                        if (fLogContinuity == FLogContinuity.Previous)
                        {
                            tvwTree.ActiveNode = tNodeTcdl.Nodes[tNodeTcdl.Nodes.Count - 1];
                            tvwTree.TopNode = tvwTree.ActiveNode;
                        }
                        else
                        {
                            tvwTree.ActiveNode = tNodeTcdl.Nodes[0];
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
                tNodeTcdl = null;
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
                if (fParent.fObjectLogType == FObjectLogType.TcpDriverLog)
                {

                }
                else if (fParent.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog)
                {
                    foreach (FTcpItemLog fTitl in ((FTcpDeviceDataMessageReceivedLog)fParent).fChildTcpItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fTitl.logUniqueIdToString);
                        tNodeChild.Tag = fTitl;
                        refreshTreeNodeOfObjectLog(fTitl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
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
                    }
                }
                // --
                else if (fParent.fObjectLogType == FObjectLogType.MapperPerformedLog)
                {
                    foreach (FDataSetLog fDtsl in ((FMapperPerformedLog)fParent).fChildDataSetLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fDtsl.logUniqueIdToString);
                        tNodeChild.Tag = fDtsl;
                        refreshTreeNodeOfObjectLog(fDtsl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.DataSetLog)
                {
                    foreach (FDataLog fDatl in ((FDataSetLog)fParent).fChildDataLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fDatl.logUniqueIdToString);
                        tNodeChild.Tag = fDatl;
                        refreshTreeNodeOfObjectLog(fDatl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.DataLog)
                {
                    foreach (FDataLog fDatl in ((FDataLog)fParent).fChildDataLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fDatl.logUniqueIdToString);
                        tNodeChild.Tag = fDatl;
                        refreshTreeNodeOfObjectLog(fDatl, tvwTree, tNodeChild);
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
                        refreshTreeNodeOfObjectLog(fRpsl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.EquipmentStateSetAltererPerformedLog)
                {
                    foreach (FEquipmentStateAltererLog fEatl in ((FEquipmentStateSetAltererPerformedLog)fParent).fChildEquipmentStateAltererLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fEatl.logUniqueIdToString);
                        tNodeChild.Tag = fEatl;
                        refreshTreeNodeOfObjectLog(fEatl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.RepositoryLog)
                {
                    foreach (FColumnLog fColl in ((FRepositoryLog)fParent).fChildColumnLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fColl.logUniqueIdToString);
                        tNodeChild.Tag = fColl;
                        refreshTreeNodeOfObjectLog(fColl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.ColumnLog)
                {
                    foreach (FColumnLog fColl in ((FColumnLog)fParent).fChildColumnLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fColl.logUniqueIdToString);
                        tNodeChild.Tag = fColl;
                        refreshTreeNodeOfObjectLog(fColl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.ApplicationWrittenLog)
                {
                    foreach (FContentLog fCttl in ((FApplicationWrittenLog)fParent).fChildContentLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fCttl.logUniqueIdToString);
                        tNodeChild.Tag = fCttl;
                        refreshTreeNodeOfObjectLog(fCttl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.ContentLog)
                {
                    foreach (FContentLog fCttl in ((FContentLog)fParent).fChildContentLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fCttl.logUniqueIdToString);
                        tNodeChild.Tag = fCttl;
                        refreshTreeNodeOfObjectLog(fCttl, tvwTree, tNodeChild);
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

        #region FTcpLogViewer Form Event Handler

        private void FTcpLogViewer_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fTcpDriverLog = new FTcpDriverLog();
                m_fLogFilter = new FTcpLogFilter(m_fAdmCore.fTcpLogFilter);

                // --

                designTreeOfLog();

                // --

                tvwTree.setPopupMenu((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuTlvPopupMenu]);

                // --

                controlMenu();

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

        private void FTcpLogViewer_Shown(
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

        private void FTcpLogViewer_FormClosing(
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

        private void FTcpLogViewer_KeyDown(
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
                if (e.Tool.Key == FMenuKey.MenuTlvRefresh)
                {
                    procMenuRefresh();
                }
                else if (e.Tool.Key == FMenuKey.MenuTlvPrevious)
                {
                    procMenuPrevious();
                }
                else if (e.Tool.Key == FMenuKey.MenuTlvNext)
                {
                    procMenuNext();
                }
                else if (e.Tool.Key == FMenuKey.MenuTlvExpand)
                {
                    procMenuExpand();
                }
                else if (e.Tool.Key == FMenuKey.MenuTlvCollapse)
                {
                    procMenuCollapse();
                }
                else if (e.Tool.Key == FMenuKey.MenuTlvCopy)
                {
                    procMenuCopy();
                }
                else if (e.Tool.Key == FMenuKey.MenuTlvConvertToXlg)
                {
                    procMenuXlgViewer();
                }
                else if (e.Tool.Key == FMenuKey.MenuTlvConvertToVfei)
                {
                    procMenuVfeiViewer();
                }
                else if (e.Tool.Key == FMenuKey.MenuTlvConvertToTcpInterfaceLog)
                {
                    procMenuConvertToTcpInterfaceLog();
                }
                else if (e.Tool.Key == FMenuKey.MenuTlvFilter)
                {
                    procMenuFilterSelector();
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
                if (fObjectLog.fObjectLogType == FObjectLogType.TcpDriverLog)
                {
                    pgdProp.selectedObject = new FPropTcdl(m_fAdmCore, pgdProp, (FTcpDriverLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceStateChangedLog)
                {
                    pgdProp.selectedObject = new FPropTdcl(m_fAdmCore, pgdProp, (FTcpDeviceStateChangedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceErrorRaisedLog)
                {
                    pgdProp.selectedObject = new FPropTdel(m_fAdmCore, pgdProp, (FTcpDeviceErrorRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceTimeoutRaisedLog)
                {
                    pgdProp.selectedObject = new FPropTdtl(m_fAdmCore, pgdProp, (FTcpDeviceTimeoutRaisedLog)fObjectLog);
                }                
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog)
                {
                    pgdProp.selectedObject = new FPropTdmrl(m_fAdmCore, pgdProp, (FTcpDeviceDataMessageReceivedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog)
                {
                    pgdProp.selectedObject = new FPropTdmsl(m_fAdmCore, pgdProp, (FTcpDeviceDataMessageSentLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpItemLog)
                {
                    pgdProp.selectedObject = new FPropTitl(m_fAdmCore, pgdProp, (FTcpItemLog)fObjectLog);
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
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpTriggerRaisedLog)
                {
                    pgdProp.selectedObject = new FPropTtrl(m_fAdmCore, pgdProp, (FTcpTriggerRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpTransmitterRaisedLog)
                {
                    pgdProp.selectedObject = new FPropTtnl(m_fAdmCore, pgdProp, (FTcpTransmitterRaisedLog)fObjectLog);
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
                    pgdProp.selectedObject = new FPropTtgl(m_fAdmCore, pgdProp, (FStoragePerformedLog)fObjectLog);
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

    }   // Class end
}   // Namespace end
