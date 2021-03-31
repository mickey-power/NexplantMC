/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FTotalLogTracer.cs
--  Creator         : hongmi.park
--  Create Date     : 2020.09.09
--  Description     : Nexplant MC TCP Modeler Total Log Tracer Class
--  History         : Created by kitae at 2011.09.09
----------------------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using System.Windows.Forms;
using System.Text;
using System.Reflection;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinDataSource;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaTcpDriver;
using Nexplant.MC.Core.FaUIs;
using Infragistics.Win.UltraWinGrid;
using System.Drawing;


namespace Nexplant.MC.TcpModeler
{
    public partial class FTotalLogTracer : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcmCore m_fTcmCore = null;
        private string m_fileName = string.Empty;
        private bool m_isTempFile = false;
        private bool m_isNewFile = true;
        private bool m_isModifiedFile = false;
        private bool m_isCleared = false;
        private FEventHandler m_fEventHandler = null;
        private FTcpDriverLog m_fTcpDriverLog = null;
        // --
        private object m_fComponent = null;
        private string m_compoFilePath = string.Empty;
        private const string typeName = "Nexplant.MC.Component.FComponent";
        // --
        private FEapCore m_fEapCore = null;
        //--
        private const string tabKLog = "Log";
        private const string tabKInterface = "Interface";
        private string m_selectTagKey = string.Empty;


        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTotalLogTracer(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTotalLogTracer(
            FTcmCore fTcmCore
            )
            :this()
        {
            base.fUIWizard = fTcmCore.fUIWizard;
            m_fTcmCore = fTcmCore;            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FTotalLogTracer(
            )
        {
            myDispose(false);
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
                    m_fTcmCore = null;
                    if (m_fComponent != null) procMenuUnplugComponent();

                    if(m_fEapCore != null)
                    {
                        m_fEapCore.Dispose();
                        m_fEapCore = null;
                    }

                    m_fEventHandler = null;
                    m_fTcpDriverLog = null;
                }
                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Common Methods

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

        private void procMenuClear(
            )
        {
            try
            {
                m_fTcpDriverLog.removeAllObjectLog();

                // -- 

                tvwLogTree.beginUpdate();
                tvwLogTree.Nodes[0].RootNode.Nodes.Clear();
                tvwLogTree.endUpdate();

                // --

                grdList.beginUpdate();
                grdList.removeAllDataRow();
                grdList.endUpdate();

                // --

                tvwInterfaceTree.beginUpdate();
                tvwInterfaceTree.Nodes.Clear();
                tvwInterfaceTree.endUpdate();

                // --

                txtLog.Clear();

                m_isModifiedFile = true;
                m_isCleared = true;

                // --

                refreshFileName();
                controlMenu();
                controlInterfaceMenu();
            }
            catch (Exception ex)
            {
                tvwLogTree.endUpdate();
                grdList.endUpdate();
                tvwInterfaceTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuXlgViewer(
            )
        {
            FTcpProtocolSelector fProtocolSelector = null;
            FIObjectLog fObjectLog = null;
            FXlgViewer fXlgViewer = null;
            StringBuilder sb = null;
            string key = string.Empty;

            try
            {
                fProtocolSelector = new FTcpProtocolSelector(m_fTcmCore);
                if (fProtocolSelector.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }

                // -- 

                fXlgViewer = (FXlgViewer)m_fTcmCore.fTcmContainer.getChild(typeof(FXlgViewer));
                if (fXlgViewer == null)
                {
                    fXlgViewer = new FXlgViewer(m_fTcmCore);
                    m_fTcmCore.fTcmContainer.showChild(fXlgViewer);
                }
                fXlgViewer.activate();

                // -- 

                sb = new StringBuilder();
                key = tabMain.ActiveTab.Key;
                if (key == tabKLog)
                {
                    foreach (UltraTreeNode node in tvwLogTree.SelectedNodes)
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
                }
                else if (key == tabKInterface)
                {
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
                }
                
                // --
                fXlgViewer.appendXlg(sb.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fObjectLog = null;
                fXlgViewer = null;
                sb = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuVfeiViewer(
            )
        {
            FIObjectLog fObjectLog = null;
            FVfeiViewer fVfeiViewer = null;
            StringBuilder sb = null;
            string key = string.Empty;

            try
            {
                fVfeiViewer = (FVfeiViewer)m_fTcmCore.fTcmContainer.getChild(typeof(FVfeiViewer));
                if (fVfeiViewer == null)
                {
                    fVfeiViewer = new FVfeiViewer(m_fTcmCore);
                    m_fTcmCore.fTcmContainer.showChild(fVfeiViewer);
                }
                fVfeiViewer.activate();

                // -- 

                sb = new StringBuilder();
                key = tabMain.ActiveTab.Key;
                if (key == tabKLog)
                {
                    foreach (UltraTreeNode node in tvwLogTree.SelectedNodes)
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
                else if (key == tabKInterface)
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
                fVfeiViewer.appendVfei(sb.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fObjectLog = null;
                fVfeiViewer = null;
                sb = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuExpand(
            )
        {
            string key = string.Empty;

            try
            {
                key = tabMain.ActiveTab.Key;
                if (key == tabKLog)
                {
                    tvwLogTree.beginUpdate();
                    tvwLogTree.ActiveNode.ExpandAll();
                    tvwLogTree.endUpdate();
                }
                else if (key == tabKInterface)
                {
                    tvwInterfaceTree.beginUpdate();
                    tvwInterfaceTree.ActiveNode.ExpandAll();
                    tvwInterfaceTree.endUpdate();
                }
            }
            catch (Exception ex)
            {
                tvwLogTree.endUpdate();
                tvwInterfaceTree.endUpdate();
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
            string key = string.Empty;

            try
            {
                key = tabMain.ActiveTab.Key;
                if (key == tabKLog)
                {
                    tvwLogTree.beginUpdate();
                    tvwLogTree.ActiveNode.CollapseAll();
                    tvwLogTree.endUpdate();
                }
                else if (key == tabKInterface)
                {
                    tvwInterfaceTree.beginUpdate();
                    tvwInterfaceTree.ActiveNode.CollapseAll();
                    tvwInterfaceTree.endUpdate();
                }
            }
            catch (Exception ex)
            {
                tvwLogTree.endUpdate();
                tvwInterfaceTree.endUpdate();
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
            string key = string.Empty;

            try
            {
                key = tabMain.ActiveTab.Key;
                if (key == tabKLog)
                {
                    tNode = tvwLogTree.ActiveNode;
                }
                else if (key == tabKInterface)
                {
                    tNode = tvwInterfaceTree.ActiveNode;
                }
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

        private void searchParentLog(
            FIObjectLog fChildLog
            )
        {
            try
            {
                if (fChildLog.fObjectLogType == FObjectLogType.TcpItemLog)
                {
                    searchParentLog(((FTcpItemLog)fChildLog).fParent);
                }
                else if (fChildLog.fObjectLogType == FObjectLogType.HostItemLog)
                {
                    searchParentLog(((FHostItemLog)fChildLog).fParent);
                }
                else if (
                    fChildLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog ||
                    fChildLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog ||
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

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshLog(
            )
        {
            string key = string.Empty;

            try
            {
                key = tabMain.ActiveTab.Key;
                if (key == tabKLog)
                {
                    tvwLogTree.Focus();
                    if (
                        m_selectTagKey != string.Empty &&
                        tvwLogTree.GetNodeByKey(m_selectTagKey) != null
                        )
                    {
                        tvwLogTree.ActiveNode = tvwLogTree.GetNodeByKey(m_selectTagKey);
                        tvwLogTree.ActiveNode.Selected = true;
                    }

                    // --

                    if (!pgdProp.Enabled)
                    {
                        tvwLogTree_AfterActivate(null, null);
                        pgdProp.Enabled = true;
                    }
                }
                else if (key == tabKInterface)
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
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        #endregion
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Log Tracer Methods

        private void designTreeOfLog(
            )
        {
            try
            {
                tvwLogTree.ImageList = new ImageList();
                // --
                tvwLogTree.ImageList.Images.Add("ApplicationLog", Properties.Resources.ApplicationLog);
                tvwLogTree.ImageList.Images.Add("ApplicationWritedLog", Properties.Resources.ApplicationWritedLog);
                tvwLogTree.ImageList.Images.Add("BranchRaisedLog", Properties.Resources.BranchRaisedLog);
                tvwLogTree.ImageList.Images.Add("CallbackRaisedLog", Properties.Resources.CallbackRaisedLog);
                tvwLogTree.ImageList.Images.Add("CommentWritedLog", Properties.Resources.CommentWritedLog);
                tvwLogTree.ImageList.Images.Add("PauserRaisedLog", Properties.Resources.PauserRaisedLog);
                tvwLogTree.ImageList.Images.Add("EntryPointCalledLog", Properties.Resources.EntryPointCalledLog);
                tvwLogTree.ImageList.Images.Add("ContentLog", Properties.Resources.ContentLog);
                tvwLogTree.ImageList.Images.Add("ContentLog_List", Properties.Resources.ContentLog_List);
                tvwLogTree.ImageList.Images.Add("ConvertToVfei", Properties.Resources.ConvertToVfei);
                tvwLogTree.ImageList.Images.Add("DataLog", Properties.Resources.DataLog);
                tvwLogTree.ImageList.Images.Add("DataLog_List", Properties.Resources.DataLog_List);
                tvwLogTree.ImageList.Images.Add("DataSetLog", Properties.Resources.DataSetLog);
                tvwLogTree.ImageList.Images.Add("FunctionCalledLog", Properties.Resources.FunctionCalledLog);
                tvwLogTree.ImageList.Images.Add("HdvDataMessageReceivedLog", Properties.Resources.HdvDataMessageReceivedLog);
                tvwLogTree.ImageList.Images.Add("HdvDataMessageReceivedLog_Command", Properties.Resources.HdvDataMessageReceivedLog_Command);
                tvwLogTree.ImageList.Images.Add("HdvDataMessageReceivedLog_Reply", Properties.Resources.HdvDataMessageReceivedLog_Reply);
                tvwLogTree.ImageList.Images.Add("HdvDataMessageReceivedLog_Unsolicited", Properties.Resources.HdvDataMessageReceivedLog_Unsolicited);
                tvwLogTree.ImageList.Images.Add("HdvDataMessageSentLog", Properties.Resources.HdvDataMessageSentLog);
                tvwLogTree.ImageList.Images.Add("HdvDataMessageSentLog_Command", Properties.Resources.HdvDataMessageSentLog_Command);
                tvwLogTree.ImageList.Images.Add("HdvDataMessageSentLog_Reply", Properties.Resources.HdvDataMessageSentLog_Reply);
                tvwLogTree.ImageList.Images.Add("HdvDataMessageSentLog_Unsolicited", Properties.Resources.HdvDataMessageSentLog_Unsolicited);
                tvwLogTree.ImageList.Images.Add("HdvErrorRaisedLog", Properties.Resources.HdvErrorRaisedLog);
                tvwLogTree.ImageList.Images.Add("HdvStateChangedLog", Properties.Resources.HdvStateChangedLog);
                tvwLogTree.ImageList.Images.Add("HdvStateChangedLog_Closed", Properties.Resources.HdvStateChangedLog_Closed);
                tvwLogTree.ImageList.Images.Add("HdvStateChangedLog_Connected", Properties.Resources.HdvStateChangedLog_Connected);
                tvwLogTree.ImageList.Images.Add("HdvStateChangedLog_Opened", Properties.Resources.HdvStateChangedLog_Opened);
                tvwLogTree.ImageList.Images.Add("HdvStateChangedLog_Selected", Properties.Resources.HdvStateChangedLog_Selected);
                tvwLogTree.ImageList.Images.Add("HostDeviceLog", Properties.Resources.HostDeviceLog);
                tvwLogTree.ImageList.Images.Add("HostItemLog", Properties.Resources.HostItemLog);
                tvwLogTree.ImageList.Images.Add("HostItemLog_List", Properties.Resources.HostItemLog_List);
                tvwLogTree.ImageList.Images.Add("HostTransmitterRaisedLog", Properties.Resources.HostTransmitterRaisedLog);
                tvwLogTree.ImageList.Images.Add("HostTriggerRaisedLog", Properties.Resources.HostTriggerRaisedLog);
                tvwLogTree.ImageList.Images.Add("JudgementPerformedLog", Properties.Resources.JudgementPerformedLog);
                tvwLogTree.ImageList.Images.Add("MapperPerformedLog", Properties.Resources.MapperPerformedLog);
                tvwLogTree.ImageList.Images.Add("EquipmentStateSetAltererPerformedLog", Properties.Resources.EquipmentStateSetAltererPerformedLog);
                tvwLogTree.ImageList.Images.Add("EquipmentStateAltererLog", Properties.Resources.EquipmentStateAltererLog);
                tvwLogTree.ImageList.Images.Add("Result_Error", Properties.Resources.Result_Error);
                tvwLogTree.ImageList.Images.Add("Result_Warning", Properties.Resources.Result_Warning);
                tvwLogTree.ImageList.Images.Add("ScenarioLog", Properties.Resources.ScenarioLog);
                tvwLogTree.ImageList.Images.Add("TdvDataMessageReceivedLog", Properties.Resources.TdvDataMessageReceivedLog);
                tvwLogTree.ImageList.Images.Add("TdvDataMessageReceivedLog_Command", Properties.Resources.TdvDataMessageReceivedLog_Command);
                tvwLogTree.ImageList.Images.Add("TdvDataMessageReceivedLog_Reply", Properties.Resources.TdvDataMessageReceivedLog_Reply);
                tvwLogTree.ImageList.Images.Add("TdvDataMessageReceivedLog_Unsolicited", Properties.Resources.TdvDataMessageReceivedLog_Unsolicited);
                tvwLogTree.ImageList.Images.Add("TdvDataMessageSentLog", Properties.Resources.TdvDataMessageSentLog);
                tvwLogTree.ImageList.Images.Add("TdvDataMessageSentLog_Command", Properties.Resources.TdvDataMessageSentLog_Command);
                tvwLogTree.ImageList.Images.Add("TdvDataMessageSentLog_Reply", Properties.Resources.TdvDataMessageSentLog_Reply);
                tvwLogTree.ImageList.Images.Add("TdvDataMessageSentLog_Unsolicited", Properties.Resources.TdvDataMessageSentLog_Unsolicited);
                tvwLogTree.ImageList.Images.Add("TdvErrorRaisedLog", Properties.Resources.TdvErrorRaisedLog);
                tvwLogTree.ImageList.Images.Add("TdvStateChangedLog", Properties.Resources.TdvStateChangedLog);
                tvwLogTree.ImageList.Images.Add("TdvStateChangedLog_Closed", Properties.Resources.TdvStateChangedLog_Closed);
                tvwLogTree.ImageList.Images.Add("TdvStateChangedLog_Opened", Properties.Resources.TdvStateChangedLog_Opened);
                tvwLogTree.ImageList.Images.Add("TdvStateChangedLog_Connected", Properties.Resources.TdvStateChangedLog_Connected);
                tvwLogTree.ImageList.Images.Add("TdvStateChangedLog_Selected", Properties.Resources.TdvStateChangedLog_Selected);
                tvwLogTree.ImageList.Images.Add("TdvTimeoutRaisedLog", Properties.Resources.TdvTimeoutRaisedLog);
                tvwLogTree.ImageList.Images.Add("TcpDeviceLog", Properties.Resources.TcpDeviceLog);
                tvwLogTree.ImageList.Images.Add("TcpDriverLog", Properties.Resources.TcpDriverLog);
                tvwLogTree.ImageList.Images.Add("TcpItemLog", Properties.Resources.TcpItemLog);
                tvwLogTree.ImageList.Images.Add("TcpItemLog_List", Properties.Resources.TcpItemLog_List);
                tvwLogTree.ImageList.Images.Add("TcpLogFilter", Properties.Resources.TcpLogFilter);
                tvwLogTree.ImageList.Images.Add("TcpTransmitterRaisedLog", Properties.Resources.TcpTransmitterRaisedLog);
                tvwLogTree.ImageList.Images.Add("TcpTriggerRaisedLog", Properties.Resources.TcpTriggerRaisedLog);
                tvwLogTree.ImageList.Images.Add("StoragePerformedLog", Properties.Resources.StoragePerformedLog);

                // --

                // --

                // ***
                // 2017.04.05 by spike.lee
                // RepositoryLog 관련 Image 추가
                // ***
                tvwLogTree.ImageList.Images.Add("RepositoryLog", Properties.Resources.Repository_unlock);
                tvwLogTree.ImageList.Images.Add("ColumnLog_List", Properties.Resources.Column_List);
                tvwLogTree.ImageList.Images.Add("ColumnLog", Properties.Resources.Column);
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

        private void refreshFileName(
            )
        {
            try
            {
                txtFileName.Text = (m_isTempFile ? "[Temp] " : "") + m_fileName + (m_isModifiedFile ? "*" : "");
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

                tNode = tvwLogTree.ActiveNode;
                if (tNode != null)
                {
                    fObjectLog = (FIObjectLog)tNode.Tag;
                }
                else
                {
                    fObjectLog = m_fTcpDriverLog;
                }

                // --

                mnuMenu.Tools[FMenuKey.MenuLgtFreezeScreen].SharedProps.Enabled = true;
                // --                      
                mnuMenu.Tools[FMenuKey.MenuLgtOpen].SharedProps.Enabled = true;
                mnuMenu.Tools[FMenuKey.MenuLgtNew].SharedProps.Enabled = true;
                // --                      
                mnuMenu.Tools[FMenuKey.MenuLgtSave].SharedProps.Enabled = m_isNewFile | m_isModifiedFile;
                mnuMenu.Tools[FMenuKey.MenuLgtSaveAs].SharedProps.Enabled = true;
                // --                      
                mnuMenu.Tools[FMenuKey.MenuLgtClear].SharedProps.Enabled = !m_isCleared;
                // --
                mnuMenu.Tools[FMenuKey.MenuLgtPlugInComponent].SharedProps.Enabled = true;
                mnuMenu.Tools[FMenuKey.MenuLgtReloadComponent].SharedProps.Enabled = (m_fComponent != null) ? true : false;

                // -- 

                if (
                    fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog
                    )
                {
                    mnuMenu.Tools[FMenuKey.MenuLgtCopy].SharedProps.Enabled = true;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuLgtCopy].SharedProps.Enabled = false;
                }
                // --
                if (
                    fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog
                    )
                {
                    mnuMenu.Tools[FMenuKey.MenuLgtConvertToXlg].SharedProps.Enabled = true;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuLgtConvertToXlg].SharedProps.Enabled = false;

                }
                // --
                if (
                   fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog ||
                   fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog
                   )
                {
                    mnuMenu.Tools[FMenuKey.MenuLgtConvertToVfei].SharedProps.Enabled = true;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuLgtConvertToVfei].SharedProps.Enabled = false;
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

        private void changeRecentLogFile(
            string fileName
            )
        {
            try
            {
                if (m_fTcmCore.fOption.logRecentFileList.Contains(fileName))
                {
                    m_fTcmCore.fOption.logRecentFileList.Remove(fileName);
                }
                else if (m_fTcmCore.fOption.logRecentFileList.Count == FConstants.RecentMaxCount)
                {
                    m_fTcmCore.fOption.logRecentFileList.RemoveAt(m_fTcmCore.fOption.logRecentFileList.Count - 1);
                }
                m_fTcmCore.fOption.logRecentFileList.Insert(0, fileName);

                // --

                m_fTcmCore.fWsmOption.recentFile = fileName;
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

        private void appendTreeOfObjectLog(
            FIObjectLog fObjectLog
            )
        {
            UltraTreeNode tNodeTcdl = null;
            UltraTreeNode tNodeChild = null;

            try
            {
                tvwLogTree.beginUpdate();

                if (isEnabledFilterOfObjectLog(fObjectLog))
                {
                    tNodeChild = new UltraTreeNode(fObjectLog.logUniqueIdToString);
                    tNodeChild.Tag = fObjectLog;

                    //--

                    FCommon.refreshTreeNodeOfObjectLog(fObjectLog, tNodeChild, tvwLogTree);

                    // --  

                    tNodeTcdl = tvwLogTree.Nodes[0].RootNode;
                    tNodeTcdl.Nodes.Add(tNodeChild);

                    // --                

                    loadTreeOfChildObjectLog(tNodeChild);

                    // --

                    m_isModifiedFile = true;
                    m_isCleared = false;

                    // --                                

                    controlMenu();

                    // --

                    if (((StateButtonTool)mnuMenu.Tools[FMenuKey.MenuLgtUnfreezeScreen]).Checked == true)
                    {
                        tvwLogTree.ActiveNode = tNodeChild;
                    }
                }

                // --

                tvwLogTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwLogTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeTcdl = null;
                tNodeChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfObjectLog(
           )
        {
            UltraTreeNode tNodeTcdl = null;
            UltraTreeNode tNodeLog = null;
            UltraTreeNode tNodeChildLog = null;

            try
            {
                tvwLogTree.beginUpdate();
                tvwLogTree.Nodes.Clear();

                // --

                // ***
                // TCP Driver Log Load
                // ***

                tNodeTcdl = new UltraTreeNode(m_fTcpDriverLog.logUniqueIdToString);
                tNodeTcdl.Tag = m_fTcpDriverLog;
                FCommon.refreshTreeNodeOfObjectLog(m_fTcpDriverLog, tNodeTcdl, tvwLogTree);

                // --

                // ***
                // Log Object Load
                // ***
                foreach (FIObjectLog fObjectLog in m_fTcpDriverLog.fChildObjectLogCollection)
                {
                    // ***
                    // FObjectLog의 Filter가 Enabled되어 있지 않을 경우 Skip 한다.
                    // ***
                    if (!isEnabledFilterOfObjectLog(fObjectLog))
                    {
                        continue;
                    }

                    // --

                    tNodeLog = new UltraTreeNode(fObjectLog.logUniqueIdToString);
                    tNodeLog.Tag = fObjectLog;
                    FCommon.refreshTreeNodeOfObjectLog(fObjectLog, tNodeLog, tvwLogTree);

                    // --

                    if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog)
                    {
                        foreach (FTcpItemLog fTitl in ((FTcpDeviceDataMessageReceivedLog)fObjectLog).fChildTcpItemLogCollection)
                        {
                            tNodeChildLog = new UltraTreeNode(fTitl.logUniqueIdToString);
                            tNodeChildLog.Tag = fTitl;
                            FCommon.refreshTreeNodeOfObjectLog(fTitl, tNodeChildLog, tvwLogTree);
                            tNodeLog.Nodes.Add(tNodeChildLog);
                        }
                    }
                    else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog)
                    {
                        foreach (FTcpItemLog fTitl in ((FTcpDeviceDataMessageSentLog)fObjectLog).fChildTcpItemLogCollection)
                        {
                            tNodeChildLog = new UltraTreeNode(fTitl.logUniqueIdToString);
                            tNodeChildLog.Tag = fTitl;
                            FCommon.refreshTreeNodeOfObjectLog(fTitl, tNodeChildLog, tvwLogTree);
                            tNodeLog.Nodes.Add(tNodeChildLog);
                        }
                    }
                    else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                    {
                        foreach (FHostItemLog fHitl in ((FHostDeviceDataMessageReceivedLog)fObjectLog).fChildHostItemLogCollection)
                        {
                            tNodeChildLog = new UltraTreeNode(fHitl.logUniqueIdToString);
                            tNodeChildLog.Tag = fHitl;
                            FCommon.refreshTreeNodeOfObjectLog(fHitl, tNodeChildLog, tvwLogTree);
                            tNodeLog.Nodes.Add(tNodeChildLog);
                        }
                    }
                    else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                    {
                        foreach (FHostItemLog fHitl in ((FHostDeviceDataMessageSentLog)fObjectLog).fChildHostItemLogCollection)
                        {
                            tNodeChildLog = new UltraTreeNode(fHitl.logUniqueIdToString);
                            tNodeChildLog.Tag = fHitl;
                            FCommon.refreshTreeNodeOfObjectLog(fHitl, tNodeChildLog, tvwLogTree);
                            tNodeLog.Nodes.Add(tNodeChildLog);
                        }
                    }
                    else if (fObjectLog.fObjectLogType == FObjectLogType.MapperPerformedLog)
                    {
                        foreach (FDataSetLog fDtsl in ((FMapperPerformedLog)fObjectLog).fChildDataSetLogCollection)
                        {
                            tNodeChildLog = new UltraTreeNode(fDtsl.logUniqueIdToString);
                            tNodeChildLog.Tag = fDtsl;
                            FCommon.refreshTreeNodeOfObjectLog(fDtsl, tNodeChildLog, tvwLogTree);
                            tNodeLog.Nodes.Add(tNodeChildLog);
                        }
                    }
                    else if (fObjectLog.fObjectLogType == FObjectLogType.StoragePerformedLog)
                    {
                        foreach (FRepositoryLog fRpsl in ((FStoragePerformedLog)fObjectLog).fChildRepositoryLogCollection)
                        {
                            tNodeChildLog = new UltraTreeNode(fRpsl.logUniqueIdToString);
                            tNodeChildLog.Tag = fRpsl;
                            FCommon.refreshTreeNodeOfObjectLog(fRpsl, tNodeChildLog, tvwLogTree);
                            tNodeLog.Nodes.Add(tNodeChildLog);
                        }
                    }
                    else if (fObjectLog.fObjectLogType == FObjectLogType.EquipmentStateSetAltererPerformedLog)
                    {
                        foreach (FEquipmentStateAltererLog fEatl in ((FEquipmentStateSetAltererPerformedLog)fObjectLog).fChildEquipmentStateAltererLogCollection)
                        {
                            tNodeChildLog = new UltraTreeNode(fEatl.logUniqueIdToString);
                            tNodeChildLog.Tag = fEatl;
                            FCommon.refreshTreeNodeOfObjectLog(fEatl, tNodeChildLog, tvwLogTree);
                            tNodeLog.Nodes.Add(tNodeChildLog);
                        }
                    }
                    else if (fObjectLog.fObjectLogType == FObjectLogType.ApplicationWrittenLog)
                    {
                        foreach (FContentLog fCttl in ((FApplicationWrittenLog)fObjectLog).fChildContentLogCollection)
                        {
                            tNodeChildLog = new UltraTreeNode(fCttl.logUniqueIdToString);
                            tNodeChildLog.Tag = fCttl;
                            FCommon.refreshTreeNodeOfObjectLog(fCttl, tNodeChildLog, tvwLogTree);
                            tNodeLog.Nodes.Add(tNodeChildLog);
                        }
                    }

                    // --

                    tNodeTcdl.Nodes.Add(tNodeLog);
                }

                // --

                tNodeTcdl.Expanded = true;
                tvwLogTree.Nodes.Add(tNodeTcdl);
                tvwLogTree.ActiveNode = tNodeTcdl;

                // --

                tvwLogTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwLogTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeTcdl = null;
                tNodeLog = null;
                tNodeChildLog = null;
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
                tvwLogTree.beginUpdate();

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
                        FCommon.refreshTreeNodeOfObjectLog(fTitl, tNodeChild, tvwLogTree);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog)
                {
                    foreach (FTcpItemLog fTitl in ((FTcpDeviceDataMessageSentLog)fParent).fChildTcpItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fTitl.logUniqueIdToString);
                        tNodeChild.Tag = fTitl;
                        FCommon.refreshTreeNodeOfObjectLog(fTitl, tNodeChild, tvwLogTree);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.TcpItemLog)
                {
                    foreach (FTcpItemLog fTitl in ((FTcpItemLog)fParent).fChildTcpItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fTitl.logUniqueIdToString);
                        tNodeChild.Tag = fTitl;
                        FCommon.refreshTreeNodeOfObjectLog(fTitl, tNodeChild, tvwLogTree);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                {
                    foreach (FHostItemLog fHitl in ((FHostDeviceDataMessageReceivedLog)fParent).fChildHostItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fHitl.logUniqueIdToString);
                        tNodeChild.Tag = fHitl;
                        FCommon.refreshTreeNodeOfObjectLog(fHitl, tNodeChild, tvwLogTree);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                {
                    foreach (FHostItemLog fHitl in ((FHostDeviceDataMessageSentLog)fParent).fChildHostItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fHitl.logUniqueIdToString);
                        tNodeChild.Tag = fHitl;
                        FCommon.refreshTreeNodeOfObjectLog(fHitl, tNodeChild, tvwLogTree);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.HostItemLog)
                {
                    foreach (FHostItemLog fHitl in ((FHostItemLog)fParent).fChildHostItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fHitl.logUniqueIdToString);
                        tNodeChild.Tag = fHitl;
                        FCommon.refreshTreeNodeOfObjectLog(fHitl, tNodeChild, tvwLogTree);
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
                        FCommon.refreshTreeNodeOfObjectLog(fDtsl, tNodeChild, tvwLogTree);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.DataSetLog)
                {
                    foreach (FDataLog fDatl in ((FDataSetLog)fParent).fChildDataLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fDatl.logUniqueIdToString);
                        tNodeChild.Tag = fDatl;
                        FCommon.refreshTreeNodeOfObjectLog(fDatl, tNodeChild, tvwLogTree);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.DataLog)
                {
                    foreach (FDataLog fDatl in ((FDataLog)fParent).fChildDataLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fDatl.logUniqueIdToString);
                        tNodeChild.Tag = fDatl;
                        FCommon.refreshTreeNodeOfObjectLog(fDatl, tNodeChild, tvwLogTree);
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
                        FCommon.refreshTreeNodeOfObjectLog(fRpsl, tNodeChild, tvwLogTree);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.RepositoryLog)
                {
                    foreach (FColumnLog fColl in ((FRepositoryLog)fParent).fChildColumnLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fColl.logUniqueIdToString);
                        tNodeChild.Tag = fColl;
                        FCommon.refreshTreeNodeOfObjectLog(fColl, tNodeChild, tvwLogTree);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.EquipmentStateSetAltererPerformedLog)
                {
                    foreach (FEquipmentStateAltererLog fEatl in ((FEquipmentStateSetAltererPerformedLog)fParent).fChildEquipmentStateAltererLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fEatl.logUniqueIdToString);
                        tNodeChild.Tag = fEatl;
                        FCommon.refreshTreeNodeOfObjectLog(fEatl, tNodeChild, tvwLogTree);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.ColumnLog)
                {
                    foreach (FColumnLog fColl in ((FColumnLog)fParent).fChildColumnLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fColl.logUniqueIdToString);
                        tNodeChild.Tag = fColl;
                        FCommon.refreshTreeNodeOfObjectLog(fColl, tNodeChild, tvwLogTree);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                // --
                else if (fParent.fObjectLogType == FObjectLogType.ApplicationWrittenLog)
                {
                    foreach (FContentLog fCttl in ((FApplicationWrittenLog)fParent).fChildContentLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fCttl.logUniqueIdToString);
                        tNodeChild.Tag = fCttl;
                        FCommon.refreshTreeNodeOfObjectLog(fCttl, tNodeChild, tvwLogTree);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.ContentLog)
                {
                    foreach (FContentLog fCttl in ((FContentLog)fParent).fChildContentLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fCttl.logUniqueIdToString);
                        tNodeChild.Tag = fCttl;
                        FCommon.refreshTreeNodeOfObjectLog(fCttl, tNodeChild, tvwLogTree);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }

                // --

                tvwLogTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwLogTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fParent = null;
                tNodeChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private bool confirmSave(
            )
        {
            DialogResult dialogResult;

            try
            {
                if (m_isModifiedFile)
                {
                    dialogResult = FMessageBox.showQuestion(
                        FConstants.ApplicationName,
                        m_fTcmCore.fWsmCore.fUIWizard.generateMessage("Q0002", new object[] { Path.GetFileName(m_fileName) }),
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxDefaultButton.Button3,
                        m_fTcmCore.fWsmCore.fWsmContainer
                        );
                    if (dialogResult == DialogResult.Yes)
                    {
                        return procMenuSave();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
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

        public void openLogFile(
            string fileName
            )
        {
            try
            {
                if (!confirmSave())
                {
                    return;
                }

                // -- 

                loadLogFile(fileName);
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

        private void loadLogFile(
            string fileName
            )
        {
            string openFileName = string.Empty;
            string key = string.Empty;

            try
            {
                openFileName = FCommon.loadFile(m_fTcmCore, fileName);

                // --  

                tvwLogTree.beginUpdate();
                tvwLogTree.Nodes.Clear();
                tvwLogTree.endUpdate();

                // --

                grdList.beginUpdate();
                grdList.removeAllDataRow();
                grdList.endUpdate();

                // --

                tvwInterfaceTree.beginUpdate();
                tvwInterfaceTree.Nodes.Clear();
                tvwInterfaceTree.endUpdate();
                
                // --

                m_fTcpDriverLog.openLogFile(openFileName);
                
                // --

                m_isTempFile = (fileName != openFileName) ? true : false;
                m_isNewFile = false;
                m_isModifiedFile = false;
                m_isCleared = false;
                // --
                m_fTcmCore.fOption.logRecentOpenPath = Path.GetDirectoryName(fileName);
                changeRecentLogFile(fileName);
                m_fileName = fileName;

                // -- 

                refreshFileName();

                loadTreeOfObjectLog();
                loadInterfaceGridOfLog();

                key = tabMain.ActiveTab.Key;
                if (key == tabKLog)
                {
                    controlMenu();
                }
                else if (key == tabKInterface)
                {
                    controlInterfaceMenu();
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

        private void saveLogFile(
            string fileName
            )
        {
            string key = string.Empty;

            try
            {
                m_fTcpDriverLog.saveLogFile(fileName);

                // --

                m_isNewFile = false;
                m_isModifiedFile = false;
                m_isCleared = false;
                // --
                m_fTcmCore.fOption.logRecentSavePath = Path.GetDirectoryName(fileName);
                changeRecentLogFile(fileName);
                m_fileName = fileName;

                // -- 

                refreshFileName();

                // --

                key = tabMain.ActiveTab.Key;
                if (key == tabKLog)
                {
                    controlMenu();
                }
                else if (key == tabKInterface)
                {
                    controlInterfaceMenu();
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

        private bool isEnabledFilterOfObjectLog(
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
                    return m_fTcmCore.fOption.enabledFilterOfTcpDeviceState;
                }
                else if (fType == FObjectLogType.TcpDeviceErrorRaisedLog)
                {
                    return m_fTcmCore.fOption.enabledFilterOfTcpDeviceError;
                }
                else if (fType == FObjectLogType.TcpDeviceTimeoutRaisedLog)
                {
                    return m_fTcmCore.fOption.enabledFilterOfTcpDeviceTimeout;
                }
                else if (
                    fType == FObjectLogType.TcpDeviceDataMessageReceivedLog ||
                    fType == FObjectLogType.TcpDeviceDataMessageSentLog ||
                    fType == FObjectLogType.TcpItemLog
                    )
                {
                    return m_fTcmCore.fOption.enabledFilterOfTcpDeviceDataMessage;
                }

                else if (fType == FObjectLogType.HostDeviceStateChangedLog)
                {
                    return m_fTcmCore.fOption.enabledFilterOfHostDeviceState;
                }
                else if (fType == FObjectLogType.HostDeviceErrorRaisedLog)
                {
                    return m_fTcmCore.fOption.enabledFilterOfHostDeviceError;
                }
                else if (
                    fType == FObjectLogType.HostDeviceDataMessageReceivedLog ||
                    fType == FObjectLogType.HostDeviceDataMessageSentLog ||
                    fType == FObjectLogType.HostItemLog
                    )
                {
                    return m_fTcmCore.fOption.enabledFilterOfHostDeviceDataMessage;
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
                    return m_fTcmCore.fOption.enabledFilterOfScenario;
                }
                else if (
                    fType == FObjectLogType.ApplicationWrittenLog ||
                    fType == FObjectLogType.ContentLog
                    )
                {
                    return m_fTcmCore.fOption.enabledFilterOfApplication;
                }

                // --

                return false;
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

        private void procMenuNew(
            )
        {
            try
            {
                if (!confirmSave())
                {
                    return;
                }

                // --

                m_fTcpDriverLog = m_fTcmCore.fTcmFileInfo.fTcpDriver.createTcpDriverLog();

                // --

                loadTreeOfObjectLog();

                // --

                m_isNewFile = true;
                m_isModifiedFile = false;
                m_isCleared = true;
                // --
                m_fileName = m_fTcpDriverLog.name + ".tsl";

                // --

                refreshFileName();
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

        private void procMenuOpen(
            )
        {
            OpenFileDialog dialog = null;

            try
            {
                if (!confirmSave())
                {
                    return;
                }

                // --

                dialog = new OpenFileDialog();
                dialog.InitialDirectory = m_fTcmCore.fOption.logRecentOpenPath;
                dialog.Title = fUIWizard.searchCaption("Open Log Trace File");
                dialog.Filter = "TSL File | *.tsl";
                dialog.DefaultExt = "tsl";

                // --

                if (dialog.ShowDialog(m_fTcmCore.fWsmCore.fWsmContainer) == DialogResult.Cancel)
                {
                    return;
                }

                // --

                loadLogFile(dialog.FileName);
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

        private bool procMenuSave(
            )
        {
            try
            {
                if (m_isNewFile)
                {
                    return procMenuSaveAs();
                }
                saveLogFile(m_fileName);

                // --

                return true;
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

        private bool procMenuSaveAs(
            )
        {
            SaveFileDialog dialog = null;
            string fullFileName = string.Empty;

            try
            {
                dialog = new SaveFileDialog();
                dialog.Title = fUIWizard.searchCaption("Save Log Trace File");
                dialog.Filter = "TSL File | *.tsl";
                dialog.DefaultExt = "tsl";
                dialog.FileName = txtFileName.Text;
                // --
                if (m_isNewFile)
                {
                    dialog.InitialDirectory = m_fTcmCore.fOption.logRecentSavePath;
                    dialog.FileName = m_fileName;
                }
                else
                {
                    dialog.InitialDirectory = Path.GetDirectoryName(m_fileName);
                    dialog.FileName = Path.GetFileName(m_fileName);
                }

                // --

                if (dialog.ShowDialog() == DialogResult.Cancel)
                {
                    return false;
                }

                // --

                saveLogFile(dialog.FileName);

                // --

                return true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                dialog = null;
            }
            return false;
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuFilterSelector(
            )
        {
            FLogFilter fLogFilter = null;

            try
            {
                fLogFilter = new FLogFilter(m_fTcmCore);
                if (fLogFilter.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                // --

                loadTreeOfObjectLog();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fLogFilter != null)
                {
                    fLogFilter.Dispose();
                    fLogFilter = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private bool procMenuPlugInComponent(
            )
        {
            OpenFileDialog ofd = null;

            try
            {
                ofd = new OpenFileDialog();
                ofd.Title = "Open Component File";
                ofd.InitialDirectory = "";
                ofd.Multiselect = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    m_fEapCore = new FEapCore(m_fTcmCore, m_fTcmCore.fTcmFileInfo.fTcpDriver, m_fEventHandler);
                    m_fComponent = FReflection.createInstance(ofd.FileName,
                                                               typeName,
                                                               new object[] {
                                                                   m_fEapCore
                                                               });
                    if (m_fComponent != null)
                    {
                        m_compoFilePath = ofd.FileName;
                    }
                }

                // --

                return true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                ofd = null;
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private bool procMenuReloadComponent(
            )
        {
            try
            {
                if (m_fComponent != null)
                {
                    Type type = FReflection.getType(m_compoFilePath, typeName);
                    m_fComponent = FReflection.invokeMethod(m_fComponent, type, "Dispose", new object[] { });
                    m_fComponent = null;
                }

                // --

                if (!File.Exists(m_compoFilePath))
                {
                    m_compoFilePath = string.Empty;
                    FDebug.throwFException(m_fTcmCore.fUIWizard.generateMessage("E0010", new object[] { "File" }));
                }

                // --

                m_fComponent = FReflection.createInstance(m_compoFilePath,
                                                          typeName,
                                                          new object[]
                                                          {
                                                              m_fEapCore
                                                          });

                // --

                return true;
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

        private bool procMenuUnplugComponent(
            )
        {
            try
            {
                if (m_fComponent != null)
                {
                    Type type = FReflection.getType(m_compoFilePath, typeName);
                    m_fComponent = FReflection.invokeMethod(m_fComponent, type, "Dispose", new object[] { });
                    m_fComponent = null;
                }
                if (m_fEapCore != null)
                {
                    m_fEapCore.Dispose();
                    m_fEapCore = null;
                }

                // --

                m_compoFilePath = string.Empty;

                // --

                return true;
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

                tNodeParent = tvwLogTree.GetNodeByKey(fParentLog.logUniqueIdToString);
                if (tNodeParent == null || !tNodeParent.Expanded)
                {
                    expandTreeForSearch(fParentLog);
                }

                // --

                if (tNodeParent == null)
                {
                    tNodeParent = tvwLogTree.GetNodeByKey(fParentLog.logUniqueIdToString);
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
                tNode = tvwLogTree.ActiveNode;
                fBaseLog = (FIObjectLog)tNode.Tag;

                // --

                fFirstLog = m_fTcpDriverLog.searchLogSeries(fBaseLog, searchWord);
                if (fFirstLog == null)
                {
                    FMessageBox.showInformation("Search", m_fTcmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { searchWord }), this);
                    return;
                }

                // --

                tvwLogTree.beginUpdate();

                // --

                fResultLog = fFirstLog;
                tNode = null;
                // --
                while (tNode == null)
                {
                    if (!isEnabledFilterOfObjectLog(fResultLog))
                    {
                        fResultLog = m_fTcpDriverLog.searchLogSeries(fResultLog, searchWord);
                        if (fResultLog == null || fResultLog.logUniqueId == fFirstLog.logUniqueId)
                        {
                            break;
                        }
                        continue;
                    }

                    // --

                    expandTreeForSearch(fResultLog);
                    tNode = tvwLogTree.GetNodeByKey(fResultLog.logUniqueIdToString);
                }

                // --

                tvwLogTree.endUpdate();

                // --

                if (tNode == null)
                {
                    FMessageBox.showInformation("Search", m_fTcmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { searchWord }), this);
                }
                else
                {
                    tvwLogTree.SelectedNodes.Clear();
                    tvwLogTree.ActiveNode = tNode;
                }
            }
            catch (Exception ex)
            {
                tvwLogTree.endUpdate();
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
        
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Interface Log Tracer Methods

        private void controlInterfaceMenu(
            )
        {
            FIObjectLog fObjectLog = null;

            try
            {
                if (grdList.activeDataRow != null)
                {
                    fObjectLog = (FIObjectLog)grdList.activeDataRow.Tag;
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fObjectLog = null;
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
                grdList.ImageList.Images.Add("TdvDataMessageReceivedLog", Properties.Resources.TdvDataMessageReceivedLog);
                grdList.ImageList.Images.Add("TdvDataMessageReceivedLog_Command", Properties.Resources.TdvDataMessageReceivedLog_Command);
                grdList.ImageList.Images.Add("TdvDataMessageReceivedLog_Reply", Properties.Resources.TdvDataMessageReceivedLog_Reply);
                grdList.ImageList.Images.Add("TdvDataMessageReceivedLog_Unsolicited", Properties.Resources.TdvDataMessageReceivedLog_Unsolicited);
                grdList.ImageList.Images.Add("TdvDataMessageSentLog", Properties.Resources.TdvDataMessageSentLog);
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
                tvwInterfaceTree.ImageList.Images.Add("TdvDataMessageReceivedLog", Properties.Resources.TdvDataMessageReceivedLog);
                tvwInterfaceTree.ImageList.Images.Add("TdvDataMessageReceivedLog_Command", Properties.Resources.TdvDataMessageReceivedLog_Command);
                tvwInterfaceTree.ImageList.Images.Add("TdvDataMessageReceivedLog_Reply", Properties.Resources.TdvDataMessageReceivedLog_Reply);
                tvwInterfaceTree.ImageList.Images.Add("TdvDataMessageReceivedLog_Unsolicited", Properties.Resources.TdvDataMessageReceivedLog_Unsolicited);
                tvwInterfaceTree.ImageList.Images.Add("TdvDataMessageSentLog", Properties.Resources.TdvDataMessageSentLog);
                tvwInterfaceTree.ImageList.Images.Add("TdvDataMessageSentLog_Command", Properties.Resources.TdvDataMessageSentLog_Command);
                tvwInterfaceTree.ImageList.Images.Add("TdvDataMessageSentLog_Reply", Properties.Resources.TdvDataMessageSentLog_Reply);
                tvwInterfaceTree.ImageList.Images.Add("TdvDataMessageSentLog_Unsolicited", Properties.Resources.TdvDataMessageSentLog_Unsolicited);
                tvwInterfaceTree.ImageList.Images.Add("TcpItemLog", Properties.Resources.TcpItemLog);
                tvwInterfaceTree.ImageList.Images.Add("TcpItemLog_List", Properties.Resources.TcpItemLog_List);
                // --
                tvwInterfaceTree.ImageList.Images.Add("Result_Warning", Properties.Resources.Result_Warning);
                tvwInterfaceTree.ImageList.Images.Add("Result_Error", Properties.Resources.Result_Error);

                // --

                tvwInterfaceTree.setPopupMenu((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuIftPopupMenuTree]);
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

        private void appendObjectLog(
            FIObjectLog fObjectLog,
            bool isActive
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

            // ←
            // →

            try
            {
                //m_fOpcDriverLog.appendChildObjectLog(fObjectLog);

                // --

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

                // --

                grdList.beginUpdate(false);

                /// --

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

                grdList.endUpdate(false);

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

                // --

                if (isActive)
                {
                    if (((StateButtonTool)mnuMenu.Tools[FMenuKey.MenuIftUnfreezeScreen]).Checked == true)
                    {
                        grdList.activateDataRow(fObjectLog.logUniqueIdToString);
                    }
                }
            }
            catch (Exception ex)
            {
                grdList.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                cellValues = null;
                gridRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadInterfaceGridOfLog(
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                grdList.beginUpdate();
                grdList.removeAllDataRow();
                grdList.endUpdate();

                // --

                tvwInterfaceTree.beginUpdate();
                tvwInterfaceTree.Nodes.Clear();
                tvwInterfaceTree.endUpdate();

                // --

                grdList.beginUpdate(false);
                // --
                foreach (FIObjectLog fLog in m_fTcpDriverLog.fChildObjectLogCollection)
                {
                    if (
                        fLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog ||
                        fLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog ||
                        fLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog ||
                        fLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog
                        )
                    {
                        appendObjectLog(fLog, false);
                    }
                }
                // --
                grdList.endUpdate(false);

                // --

                if (grdList.Rows.Count > 0)
                {
                    grdList.ActiveRow = grdList.Rows[grdList.Rows.Count - 1];
                }
            }
            catch (Exception ex)
            {
                grdList.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                FCursor.defaultCursor();
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
                FCommon.refreshTreeNodeOfObjectLog(fObjectLog, tNode, tvwInterfaceTree);

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
                if (fParent.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog)
                {
                    foreach (FTcpItemLog fTitl in ((FTcpDeviceDataMessageReceivedLog)fParent).fChildTcpItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fTitl.logUniqueIdToString);
                        tNodeChild.Tag = fTitl;
                        FCommon.refreshTreeNodeOfObjectLog(fTitl, tNodeChild, tvwInterfaceTree);
                        tNodeParent.Nodes.Add(tNodeChild);
                        // --
                        loadInterfaceTreeOfChildObjectLog(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog)
                {
                    foreach (FTcpItemLog fTitl in ((FTcpDeviceDataMessageSentLog)fParent).fChildTcpItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fTitl.logUniqueIdToString);
                        tNodeChild.Tag = fTitl;
                        FCommon.refreshTreeNodeOfObjectLog(fTitl, tNodeChild, tvwInterfaceTree);
                        tNodeParent.Nodes.Add(tNodeChild);
                        // --
                        loadInterfaceTreeOfChildObjectLog(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.TcpItemLog)
                {
                    foreach (FTcpItemLog fTitl in ((FTcpItemLog)fParent).fChildTcpItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fTitl.logUniqueIdToString);
                        tNodeChild.Tag = fTitl;
                        FCommon.refreshTreeNodeOfObjectLog(fTitl, tNodeChild, tvwInterfaceTree);
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
                        FCommon.refreshTreeNodeOfObjectLog(fHitl, tNodeChild, tvwInterfaceTree);
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
                        FCommon.refreshTreeNodeOfObjectLog(fHitl, tNodeChild, tvwInterfaceTree);
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
                        FCommon.refreshTreeNodeOfObjectLog(fHitl, tNodeChild, tvwInterfaceTree);
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

        private bool procMenuChangeFontName(
            )
        {
            bool isValidFontName = true;
            string preFontName = string.Empty;

            try
            {
                preFontName = ((FontListTool)mnuLogMenu.Tools[FMenuKey.MenuFontName]).Value.ToString();
                // --
                txtLog.Appearance.FontData.Name = (new System.Drawing.FontFamily(preFontName)).Name;
                m_fTcmCore.fOption.commonFontName = preFontName;
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
                m_fTcmCore.fOption.commonFontSize = float.Parse(numFontSize.Value.ToString());
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FTotalLogTracer Form Event Handler

        private void FTotalLogTracer_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // -- 

                designTreeOfLog();
                // --
                designGridOfLog();
                designInterfaceTreeOfLog();

                // --

                tvwLogTree.setPopupMenu((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuLgtPopupMenu]);

                // --

                ((FontListTool)mnuLogMenu.Tools[FMenuKey.MenuFontName]).Value = m_fTcmCore.fOption.commonFontName;
                numFontSize.Value = m_fTcmCore.fOption.commonFontSize;

                // --

                txtLog.Appearance.FontData.Name = ((FontListTool)mnuLogMenu.Tools[FMenuKey.MenuFontName]).Value.ToString();
                txtLog.Appearance.FontData.SizeInPoints = float.Parse(numFontSize.Value.ToString());

                // --

                if (m_fTcmCore.fTcmFileInfo.fTcpDriver == null)
                {
                    m_fTcmCore.fTcmFileInfo.newFile();
                }

                m_fTcpDriverLog = m_fTcmCore.fTcmFileInfo.fTcpDriver.createTcpDriverLog();
                // --
                m_fileName = m_fTcpDriverLog.name + ".tsl";
                // --
                m_isNewFile = true;
                m_isModifiedFile = false;
                m_isCleared = true;

                // --

                m_fEventHandler = new FEventHandler(m_fTcmCore.fTcmFileInfo.fTcpDriver, this);
                // --
                m_fEventHandler.TcpDeviceStateChanged += new FTcpDeviceStateChangedEventHandler(m_fEventHandler_TcpDeviceStateChanged);
                m_fEventHandler.TcpDeviceErrorRaised += new FTcpDeviceErrorRaisedEventHandler(m_fEventHandler_TcpDeviceErrorRaised);
                m_fEventHandler.TcpDeviceTimeoutRaised += new FTcpDeviceTimeoutRaisedEventHandler(m_fEventHandler_TcpDeviceTimeoutRaised);
                m_fEventHandler.TcpDeviceDataMessageReceived += new FTcpDeviceDataMessageReceivedEventHandler(m_fEventHandler_TcpDeviceDataMessageReceived);
                m_fEventHandler.TcpDeviceDataMessageSent += new FTcpDeviceDataMessageSentEventHandler(m_fEventHandler_TcpDeviceDataMessageSent);
                // -- 
                m_fEventHandler.HostDeviceStateChanged += new FHostDeviceStateChangedEventHandler(m_fEventHandler_HostDeviceStateChanged);
                m_fEventHandler.HostDeviceErrorRaised += new FHostDeviceErrorRaisedEventHandler(m_fEventHandler_HostDeviceErrorRaised);
                m_fEventHandler.HostDeviceDataMessageReceived += new FHostDeviceDataMessageReceivedEventHandler(m_fEventHandler_HostDeviceDataMessageReceived);
                m_fEventHandler.HostDeviceDataMessageSent += new FHostDeviceDataMessageSentEventHandler(m_fEventHandler_HostDeviceDataMessageSent);
                // --
                m_fEventHandler.TcpTriggerRaised += new FTcpTriggerRaisedEventHandler(m_fEventHandler_TcpTriggerRaised);
                m_fEventHandler.TcpTransmitterRaised += new FTcpTransmitterRaisedEventHandler(m_fEventHandler_TcpTransmitterRaised);
                m_fEventHandler.HostTriggerRaised += new FHostTriggerRaisedEventHandler(m_fEventHandler_HostTriggerRaised);
                m_fEventHandler.HostTransmitterRaised += new FHostTransmitterRaisedEventHandler(m_fEventHandler_HostTransmitterRaised);
                m_fEventHandler.JudgementPerformed += new FJudgementPerformedEventHandler(m_fEventHandler_JudgementPerformed);
                m_fEventHandler.MapperPerformed += new FMapperPerformedEventHandler(m_fEventHandler_MapperPerformed);
                m_fEventHandler.EquipmentStateSetAltererPerformed += new FEquipmentStateSetAltererPerformedEventHandler(m_fEventHandler_EquipmentStateSetAltererPerformed);
                m_fEventHandler.StoragePerformed += new FStoragePerformedEventHandler(m_fEventHandler_StoragePerformed);
                m_fEventHandler.CallbackRaised += new FCallbackRaisedEventHandler(m_fEventHandler_CallbackRaised);
                m_fEventHandler.FunctionCalled += new FFunctionCalledEventHandler(m_fEventHandler_FunctionCalled);
                m_fEventHandler.BranchRaised += new FBranchRaisedEventHandler(m_fEventHandler_BranchRaised);
                m_fEventHandler.CommentWritten += new FCommentWrittenEventHandler(m_fEventHandler_CommentWritten);
                m_fEventHandler.PauserRaised += new FPauserRaisedEventHandler(m_fEventHandler_PauserRaised);
                m_fEventHandler.EntryPointCalled += new FEntryPointCalledEventHandler(m_fEventHandler_EntryPointCalled);
                // --
                m_fEventHandler.ApplicationWritten += new FApplicationWrittenEventHandler(m_fEventHandler_ApplicationWritten);
                // --                

                refreshFileName();
                controlMenu();
                controlInterfaceMenu();
                
                // --

                m_fTcmCore.fOption.fChildFormList.add(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }
                
        //------------------------------------------------------------------------------------------------------------------------

        private void FTotalLogTracer_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                loadTreeOfObjectLog();

                // --

                tvwLogTree.Focus();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FTotalLogTracer_FormCloseConfirm(
            object sender,
            FFormCloseConfirmEventArgs e
            )
        {
            try
            {
                if (!confirmSave())
                {
                    e.cancel = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FTotalLogTracer_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                if (m_fEventHandler != null)
                {
                    if (m_fComponent != null) procMenuUnplugComponent();
                    m_fTcmCore.fTcmFileInfo.fTcpDriver.waitEventHandlingCompleted();
                    m_fEventHandler.Dispose();

                    // --

                    m_fEventHandler.TcpDeviceStateChanged -= new FTcpDeviceStateChangedEventHandler(m_fEventHandler_TcpDeviceStateChanged);
                    m_fEventHandler.TcpDeviceErrorRaised -= new FTcpDeviceErrorRaisedEventHandler(m_fEventHandler_TcpDeviceErrorRaised);
                    m_fEventHandler.TcpDeviceTimeoutRaised -= new FTcpDeviceTimeoutRaisedEventHandler(m_fEventHandler_TcpDeviceTimeoutRaised);
                    m_fEventHandler.TcpDeviceDataMessageReceived -= new FTcpDeviceDataMessageReceivedEventHandler(m_fEventHandler_TcpDeviceDataMessageReceived);
                    m_fEventHandler.TcpDeviceDataMessageSent -= new FTcpDeviceDataMessageSentEventHandler(m_fEventHandler_TcpDeviceDataMessageSent);
                    // --
                    m_fEventHandler.HostDeviceStateChanged -= new FHostDeviceStateChangedEventHandler(m_fEventHandler_HostDeviceStateChanged);
                    m_fEventHandler.HostDeviceErrorRaised -= new FHostDeviceErrorRaisedEventHandler(m_fEventHandler_HostDeviceErrorRaised);
                    m_fEventHandler.HostDeviceDataMessageReceived -= new FHostDeviceDataMessageReceivedEventHandler(m_fEventHandler_HostDeviceDataMessageReceived);
                    m_fEventHandler.HostDeviceDataMessageSent -= new FHostDeviceDataMessageSentEventHandler(m_fEventHandler_HostDeviceDataMessageSent);
                    // --
                    m_fEventHandler.TcpTriggerRaised -= new FTcpTriggerRaisedEventHandler(m_fEventHandler_TcpTriggerRaised);
                    m_fEventHandler.TcpTransmitterRaised -= new FTcpTransmitterRaisedEventHandler(m_fEventHandler_TcpTransmitterRaised);
                    m_fEventHandler.HostTriggerRaised -= new FHostTriggerRaisedEventHandler(m_fEventHandler_HostTriggerRaised);
                    m_fEventHandler.HostTransmitterRaised -= new FHostTransmitterRaisedEventHandler(m_fEventHandler_HostTransmitterRaised);
                    m_fEventHandler.JudgementPerformed -= new FJudgementPerformedEventHandler(m_fEventHandler_JudgementPerformed);
                    m_fEventHandler.MapperPerformed -= new FMapperPerformedEventHandler(m_fEventHandler_MapperPerformed);
                    m_fEventHandler.EquipmentStateSetAltererPerformed -= new FEquipmentStateSetAltererPerformedEventHandler(m_fEventHandler_EquipmentStateSetAltererPerformed);
                    m_fEventHandler.StoragePerformed -= new FStoragePerformedEventHandler(m_fEventHandler_StoragePerformed);
                    m_fEventHandler.CallbackRaised -= new FCallbackRaisedEventHandler(m_fEventHandler_CallbackRaised);
                    m_fEventHandler.FunctionCalled -= new FFunctionCalledEventHandler(m_fEventHandler_FunctionCalled);
                    m_fEventHandler.BranchRaised -= new FBranchRaisedEventHandler(m_fEventHandler_BranchRaised);
                    m_fEventHandler.CommentWritten -= new FCommentWrittenEventHandler(m_fEventHandler_CommentWritten);
                    m_fEventHandler.PauserRaised -= new FPauserRaisedEventHandler(m_fEventHandler_PauserRaised);
                    m_fEventHandler.EntryPointCalled -= new FEntryPointCalledEventHandler(m_fEventHandler_EntryPointCalled);
                    // --
                    m_fEventHandler.ApplicationWritten -= new FApplicationWrittenEventHandler(m_fEventHandler_ApplicationWritten);
                    // --                    
                    m_fEventHandler = null;
                }

                // --

                m_fTcmCore.fOption.fChildFormList.remove(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fEventHandler Object Evnet Handler

        private void m_fEventHandler_TcpDeviceStateChanged(
            object sender,
            FTcpDeviceStateChangedEventArgs e
            )
        {
            try
            {
                m_fTcpDriverLog.appendChildObjectLog(e.fTcpDeviceStateChangedLog);
                appendTreeOfObjectLog(e.fTcpDeviceStateChangedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_TcpDeviceErrorRaised(
            object sender,
            FTcpDeviceErrorRaisedEventArgs e
            )
        {
            try
            {
                m_fTcpDriverLog.appendChildObjectLog(e.fTcpDeviceErrorRaisedLog);
                appendTreeOfObjectLog(e.fTcpDeviceErrorRaisedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_TcpDeviceTimeoutRaised(
            object sender,
            FTcpDeviceTimeoutRaisedEventArgs e
            )
        {
            try
            {
                m_fTcpDriverLog.appendChildObjectLog(e.fTcpDeviceTimeoutRaisedLog);
                appendTreeOfObjectLog(e.fTcpDeviceTimeoutRaisedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_TcpDeviceDataMessageReceived(
            object sender,
            FTcpDeviceDataMessageReceivedEventArgs e
            )
        {
            try
            {
                m_fTcpDriverLog.appendChildObjectLog(e.fTcpDeviceDataMessageReceivedLog);
                appendTreeOfObjectLog(e.fTcpDeviceDataMessageReceivedLog);
                appendObjectLog(e.fTcpDeviceDataMessageReceivedLog, true);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_TcpDeviceDataMessageSent(
            object sender,
            FTcpDeviceDataMessageSentEventArgs e
            )
        {
            try
            {
                m_fTcpDriverLog.appendChildObjectLog(e.fTcpDeviceDataMessageSentLog);
                appendTreeOfObjectLog(e.fTcpDeviceDataMessageSentLog);
                appendObjectLog(e.fTcpDeviceDataMessageSentLog, true);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_HostDeviceStateChanged(
            object sender,
            FHostDeviceStateChangedEventArgs e
            )
        {
            try
            {
                m_fTcpDriverLog.appendChildObjectLog(e.fHostDeviceStateChangedLog);
                appendTreeOfObjectLog(e.fHostDeviceStateChangedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_HostDeviceErrorRaised(
            object sender,
            FHostDeviceErrorRaisedEventArgs e
            )
        {
            try
            {
                m_fTcpDriverLog.appendChildObjectLog(e.fHostDeviceErrorRaisedLog);
                appendTreeOfObjectLog(e.fHostDeviceErrorRaisedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_HostDeviceDataMessageReceived(
            object sender,
            FHostDeviceDataMessageReceivedEventArgs e
            )
        {
            try
            {
                m_fTcpDriverLog.appendChildObjectLog(e.fHostDeviceDataMessageReceivedLog);
                appendTreeOfObjectLog(e.fHostDeviceDataMessageReceivedLog);
                appendObjectLog(e.fHostDeviceDataMessageReceivedLog, true);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_HostDeviceDataMessageSent(
            object sender,
            FHostDeviceDataMessageSentEventArgs e
            )
        {
            try
            {
                m_fTcpDriverLog.appendChildObjectLog(e.fHostDeviceDataMessageSentLog);
                appendTreeOfObjectLog(e.fHostDeviceDataMessageSentLog);
                appendObjectLog(e.fHostDeviceDataMessageSentLog, true);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_TcpTriggerRaised(
            object sender,
            FTcpTriggerRaisedEventArgs e
            )
        {
            try
            {
                m_fTcpDriverLog.appendChildObjectLog(e.fTcpTriggerRaisedLog);
                appendTreeOfObjectLog(e.fTcpTriggerRaisedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_TcpTransmitterRaised(
            object sender,
            FTcpTransmitterRaisedEventArgs e
            )
        {
            try
            {
                m_fTcpDriverLog.appendChildObjectLog(e.fTcpTransmitterRaisedLog);
                appendTreeOfObjectLog(e.fTcpTransmitterRaisedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_HostTriggerRaised(
            object sender,
            FHostTriggerRaisedEventArgs e
            )
        {
            try
            {
                m_fTcpDriverLog.appendChildObjectLog(e.fHostTriggerRaisedLog);
                appendTreeOfObjectLog(e.fHostTriggerRaisedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void m_fEventHandler_HostTransmitterRaised(
            object sender,
            FHostTransmitterRaisedEventArgs e
            )
        {
            try
            {
                m_fTcpDriverLog.appendChildObjectLog(e.fHostTransmitterRaisedLog);
                appendTreeOfObjectLog(e.fHostTransmitterRaisedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_JudgementPerformed(
            object sender,
            FJudgementPerformedEventArgs e
            )
        {
            try
            {
                m_fTcpDriverLog.appendChildObjectLog(e.fJudgementPerformedLog);
                appendTreeOfObjectLog(e.fJudgementPerformedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_MapperPerformed(
            object sender,
            FMapperPerformedEventArgs e
            )
        {
            try
            {
                m_fTcpDriverLog.appendChildObjectLog(e.fMapperPerformedLog);
                appendTreeOfObjectLog(e.fMapperPerformedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_EquipmentStateSetAltererPerformed(
            object sender,
            FEquipmentStateSetAltererPerformedEventArgs e
            )
        {
            try
            {
                m_fTcpDriverLog.appendChildObjectLog(e.fEquipmentStateSetAltererPerformedLog);
                appendTreeOfObjectLog(e.fEquipmentStateSetAltererPerformedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_StoragePerformed(
            object sender,
            FStoragePerformedEventArgs e
            )
        {
            try
            {
                m_fTcpDriverLog.appendChildObjectLog(e.fStoragePerformedLog);
                appendTreeOfObjectLog(e.fStoragePerformedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_CallbackRaised(
            object sender,
            FCallbackRaisedEventArgs e
            )
        {
            try
            {
                m_fTcpDriverLog.appendChildObjectLog(e.fCallbackRaisedLog);
                appendTreeOfObjectLog(e.fCallbackRaisedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_FunctionCalled(
            object sender,
            FFunctionCalledEventArgs e
            )
        {
            try
            {
                m_fTcpDriverLog.appendChildObjectLog(e.fFunctionCalledLog);
                appendTreeOfObjectLog(e.fFunctionCalledLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_BranchRaised(
            object sender,
            FBranchRaisedEventArgs e
            )
        {
            try
            {
                m_fTcpDriverLog.appendChildObjectLog(e.fBranchRaisedLog);
                appendTreeOfObjectLog(e.fBranchRaisedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_CommentWritten(
            object sender,
            FCommentWrittenEventArgs e
            )
        {
            try
            {
                m_fTcpDriverLog.appendChildObjectLog(e.fCommentWrittenLog);
                appendTreeOfObjectLog(e.fCommentWrittenLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_PauserRaised(
            object sender,
            FPauserRaisedEventArgs e
            )
        {
            try
            {
                m_fTcpDriverLog.appendChildObjectLog(e.fPauserRaisedLog);
                appendTreeOfObjectLog(e.fPauserRaisedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_EntryPointCalled(
            object sender,
            FEntryPointCalledEventArgs e
            )
        {
            try
            {
                m_fTcpDriverLog.appendChildObjectLog(e.fEntryPointCalledLog);
                appendTreeOfObjectLog(e.fEntryPointCalledLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void m_fEventHandler_ApplicationWritten(
            object sender,
            FApplicationWrittenEventArgs e
            )
        {
            try
            {
                m_fTcpDriverLog.appendChildObjectLog(e.fApplicationWrittenLog);
                appendTreeOfObjectLog(e.fApplicationWrittenLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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

                if (e.Tool.Key == FMenuKey.MenuLgtExpand)
                {
                    procMenuExpand();
                }
                else if (e.Tool.Key == FMenuKey.MenuLgtCollapse)
                {
                    procMenuCollapse();
                }
                else if (e.Tool.Key == FMenuKey.MenuLgtNew)
                {
                    procMenuNew();
                }
                else if (e.Tool.Key == FMenuKey.MenuLgtOpen)
                {
                    procMenuOpen();
                }
                else if (e.Tool.Key == FMenuKey.MenuLgtSave)
                {
                    procMenuSave();
                }
                else if (e.Tool.Key == FMenuKey.MenuLgtSaveAs)
                {
                    procMenuSaveAs();
                }
                else if (e.Tool.Key == FMenuKey.MenuLgtCopy)
                {
                    procMenuCopy();
                }
                else if (e.Tool.Key == FMenuKey.MenuLgtClear)
                {
                    procMenuClear();
                }
                else if (e.Tool.Key == FMenuKey.MenuLgtConvertToXlg)
                {
                    procMenuXlgViewer();
                }
                else if (e.Tool.Key == FMenuKey.MenuLgtConvertToVfei)
                {
                    procMenuVfeiViewer();
                }
                else if (e.Tool.Key == FMenuKey.MenuLgtFilterSelector)
                {
                    procMenuFilterSelector();
                }
                else if (e.Tool.Key == FMenuKey.MenuLgtFreezeScreen)
                {

                }
                else if (e.Tool.Key == FMenuKey.MenuLgtPlugInComponent)
                {
                    if (((StateButtonTool)(e.Tool)).Checked)
                    {
                        procMenuPlugInComponent();
                    }
                    else
                    {
                        procMenuUnplugComponent();
                    }
                }
                else if (e.Tool.Key == FMenuKey.MenuLgtReloadComponent)
                {
                    procMenuReloadComponent();
                }

                // --

                mnuMenu.Tools[FMenuKey.MenuLgtPlugInComponent].SharedProps.ToolTipText = m_compoFilePath;

                // --

                controlMenu();
                controlInterfaceMenu();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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

                if (e.Tool.Key == FMenuKey.MenuFontName)
                {
                    procMenuChangeFontName();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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

                if (e.Tool.Key == FMenuKey.MenuFontName)
                {
                    if (!procMenuChangeFontName())
                    {
                        ((FontListTool)mnuLogMenu.Tools[FMenuKey.MenuFontName]).Value = m_fTcmCore.fOption.commonFontName;
                        txtLog.Appearance.FontData.Name = m_fTcmCore.fOption.commonFontName;
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region tvwLogTree Control Event Handler

        private void tvwLogTree_AfterActivate(
            object sender, 
            NodeEventArgs e
            )
        {
            FIObjectLog fObjectLog = null;

            try
            {
                if (tvwLogTree.ActiveNode == null)
                {
                    return;
                }

                // --

                fObjectLog = (FIObjectLog)tvwLogTree.ActiveNode.Tag;
                // --
                if (fObjectLog.fObjectLogType == FObjectLogType.TcpDriverLog)
                {
                    pgdProp.selectedObject = new FPropTcdl(m_fTcmCore, pgdProp, (FTcpDriverLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceStateChangedLog)
                {
                    pgdProp.selectedObject = new FPropTdcl(m_fTcmCore, pgdProp, (FTcpDeviceStateChangedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceErrorRaisedLog)
                {
                    pgdProp.selectedObject = new FPropTdel(m_fTcmCore, pgdProp, (FTcpDeviceErrorRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceTimeoutRaisedLog)
                {
                    pgdProp.selectedObject = new FPropTdtl(m_fTcmCore, pgdProp, (FTcpDeviceTimeoutRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog)
                {
                    pgdProp.selectedObject = new FPropTdmrl(m_fTcmCore, pgdProp, (FTcpDeviceDataMessageReceivedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog)
                {
                    pgdProp.selectedObject = new FPropTdmsl(m_fTcmCore, pgdProp, (FTcpDeviceDataMessageSentLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpItemLog)
                {
                    pgdProp.selectedObject = new FPropTitl(m_fTcmCore, pgdProp, (FTcpItemLog)fObjectLog);
                }
                // --
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceStateChangedLog)
                {
                    pgdProp.selectedObject = new FPropHdcl(m_fTcmCore, pgdProp, (FHostDeviceStateChangedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceErrorRaisedLog)
                {
                    pgdProp.selectedObject = new FPropHdel(m_fTcmCore, pgdProp, (FHostDeviceErrorRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                {
                    pgdProp.selectedObject = new FPropHdmrl(m_fTcmCore, pgdProp, (FHostDeviceDataMessageReceivedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                {
                    pgdProp.selectedObject = new FPropHdmsl(m_fTcmCore, pgdProp, (FHostDeviceDataMessageSentLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostItemLog)
                {
                    pgdProp.selectedObject = new FPropHitl(m_fTcmCore, pgdProp, (FHostItemLog)fObjectLog);
                }
                // --
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpTriggerRaisedLog)
                {
                    pgdProp.selectedObject = new FPropTtrl(m_fTcmCore, pgdProp, (FTcpTriggerRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.TcpTransmitterRaisedLog)
                {
                    pgdProp.selectedObject = new FPropTtnl(m_fTcmCore, pgdProp, (FTcpTransmitterRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTriggerRaisedLog)
                {
                    pgdProp.selectedObject = new FPropHtrl(m_fTcmCore, pgdProp, (FHostTriggerRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTransmitterRaisedLog)
                {
                    pgdProp.selectedObject = new FPropHtnl(m_fTcmCore, pgdProp, (FHostTransmitterRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.JudgementPerformedLog)
                {
                    pgdProp.selectedObject = new FPropJdml(m_fTcmCore, pgdProp, (FJudgementPerformedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.MapperPerformedLog)
                {
                    pgdProp.selectedObject = new FPropMapl(m_fTcmCore, pgdProp, (FMapperPerformedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EquipmentStateSetAltererPerformedLog)
                {
                    pgdProp.selectedObject = new FPropEsal(m_fTcmCore, pgdProp, (FEquipmentStateSetAltererPerformedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.StoragePerformedLog)
                {
                    pgdProp.selectedObject = new FPropStgl(m_fTcmCore, pgdProp, (FStoragePerformedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CallbackRaisedLog)
                {
                    pgdProp.selectedObject = new FPropCbkl(m_fTcmCore, pgdProp, (FCallbackRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.FunctionCalledLog)
                {
                    pgdProp.selectedObject = new FPropFunl(m_fTcmCore, pgdProp, (FFunctionCalledLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.BranchRaisedLog)
                {
                    pgdProp.selectedObject = new FPropBrnl(m_fTcmCore, pgdProp, (FBranchRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CommentWrittenLog)
                {
                    pgdProp.selectedObject = new FPropCmtl(m_fTcmCore, pgdProp, (FCommentWrittenLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PauserRaisedLog)
                {
                    pgdProp.selectedObject = new FPropPaul(m_fTcmCore, pgdProp, (FPauserRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EntryPointCalledLog)
                {
                    pgdProp.selectedObject = new FPropEtpl(m_fTcmCore, pgdProp, (FEntryPointCalledLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.DataSetLog)
                {
                    pgdProp.selectedObject = new FPropDtsl(m_fTcmCore, pgdProp, (FDataSetLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.DataLog)
                {
                    pgdProp.selectedObject = new FPropDatl(m_fTcmCore, pgdProp, (FDataLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.RepositoryLog)
                {
                    pgdProp.selectedObject = new FPropRpsl(m_fTcmCore, pgdProp, (FRepositoryLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.ColumnLog)
                {
                    pgdProp.selectedObject = new FPropColl(m_fTcmCore, pgdProp, (FColumnLog)fObjectLog);
                }
                // --
                else if (fObjectLog.fObjectLogType == FObjectLogType.ApplicationWrittenLog)
                {
                    pgdProp.selectedObject = new FPropAppl(m_fTcmCore, pgdProp, (FApplicationWrittenLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.ContentLog)
                {
                    pgdProp.selectedObject = new FPropCttl(m_fTcmCore, pgdProp, (FContentLog)fObjectLog);
                }

                // --

                controlMenu();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwLogTree_KeyDown(
            object sender,
            KeyEventArgs e
            )
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.C)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuLgtCopy].SharedProps.Enabled == true)
                    {
                        procMenuCopy();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.E)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuLgtExpand].SharedProps.Enabled == true)
                    {
                        procMenuExpand();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.L)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuLgtCollapse].SharedProps.Enabled == true)
                    {
                        procMenuCollapse();
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwLogTree_AfterExpand(
            object sender,
            NodeEventArgs e
            )
        {
            try
            {
                tvwLogTree.beginUpdate();

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

                tvwLogTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwLogTree.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwLogTree_MouseMove(
            object sender, 
            MouseEventArgs e
            )
        {
            UltraTreeNode tNode = null;
            FIObjectLog fObjectLog = null;
            FDragDropData fDragDropData = null;

            try
            {
                if (e.Button != System.Windows.Forms.MouseButtons.Left)
                {
                    return;
                }

                // --

                tNode = tvwLogTree.GetNodeFromPoint(e.X, e.Y);
                if (tNode == null)
                {
                    return;
                }

                // --                               

                fObjectLog = (FIObjectLog)tNode.Tag;
                fDragDropData = new FDragDropData(fObjectLog);
                // --
                tvwLogTree.DoDragDrop(new DataObject(fDragDropData), DragDropEffects.All);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                tNode = null;
                fObjectLog = null;
                fDragDropData = null;
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

                mnuMenu.ShowPopup(FMenuKey.MenuIftPopupMenuGrid);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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

                if (grdList.activeDataRow == null)
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

                controlMenu();
            }
            catch (Exception ex)
            {
                tvwInterfaceTree.endUpdate();
                txtLog.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region tvwInterfaceTree Control Event Handler

        private void tvwInterfaceTree_KeyDown(
            object sender,
            KeyEventArgs e
            )
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.C)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuLgtCopy].SharedProps.Enabled == true)
                    {
                        procMenuCopy();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.E)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuLgtExpand].SharedProps.Enabled == true)
                    {
                        procMenuExpand();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.L)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuLgtCollapse].SharedProps.Enabled == true)
                    {
                        procMenuCollapse();
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwInterfaceTree_MouseMove(
            object sender,
            MouseEventArgs e
            )
        {
            UltraTreeNode tNode = null;
            FIObjectLog fObjectLog = null;
            FDragDropData fDragDropData = null;

            try
            {
                if (e.Button != System.Windows.Forms.MouseButtons.Left)
                {
                    return;
                }

                // --

                tNode = tvwInterfaceTree.GetNodeFromPoint(e.X, e.Y);
                if (tNode == null)
                {
                    return;
                }

                // --                               

                fObjectLog = (FIObjectLog)tNode.Tag;
                fDragDropData = new FDragDropData(fObjectLog);
                // --
                tvwInterfaceTree.DoDragDrop(new DataObject(fDragDropData), DragDropEffects.All);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                tNode = null;
                fObjectLog = null;
                fDragDropData = null;
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
                procMenuSearch(e.searchWord);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

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
                fFirst = m_fTcpDriverLog.searchLogSeries(fBase, e.searchWord);
                if (fFirst == null)
                {
                    FMessageBox.showInformation("Search", m_fTcmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { e.searchWord }), this);
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
                    FMessageBox.showInformation("Search", m_fTcmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { e.searchWord }), this);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

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
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                    txtLog.Focus();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void numFontSize_ValueChanged(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                procMenuChangeFontSize();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region tabMain Control Event Handler

        private void tabMain_ActiveTabChanging(
            object sender, 
            Infragistics.Win.UltraWinTabControl.ActiveTabChangingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tab.Key == tabKLog)
                {
                    if (grdList.ActiveRow != null)
                    {
                        m_selectTagKey = ((FIObjectLog)grdList.activeDataRow.Tag).logUniqueIdToString;
                    }
                }
                else if (e.Tab.Key == tabKInterface)
                {
                    if (tvwLogTree.ActiveNode != null)
                    {
                        searchParentLog((FIObjectLog)tvwLogTree.ActiveNode.Tag);
                    }
                    pgdProp.Enabled = false;
                }

                e.Tab.Visible = true;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                    m_fTcpDriverLog != null
                    )
                {
                    refreshLog();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
