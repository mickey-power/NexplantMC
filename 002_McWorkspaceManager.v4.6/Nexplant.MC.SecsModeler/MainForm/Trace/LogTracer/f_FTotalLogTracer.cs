/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FTotalLogTracer.cs
--  Creator         : hongmi.park
--  Create Date     : 2020.09.09
--  Description     : Nexplant MC SECS Modeler Total Log Tracer Class
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
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.Core.FaUIs;
using Infragistics.Win.UltraWinGrid;
using System.Drawing;

namespace Nexplant.MC.SecsModeler
{ 
    public partial class FTotalLogTracer : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSsmCore m_fSsmCore = null;
        private string m_fileName = string.Empty;
        private bool m_isTempFile = false;
        private bool m_isNewFile = true;
        private bool m_isModifiedFile = false;
        private bool m_isCleared = false;
        private FEventHandler m_fEventHandler = null;
        private FSecsDriverLog m_fSecsDriverLog = null;
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
            FSsmCore fSsmCore
            )
            :this()
        {
            base.fUIWizard = fSsmCore.fUIWizard;
            m_fSsmCore = fSsmCore;            
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
                    m_fSsmCore = null;
                    if (m_fComponent != null) procMenuUnplugComponent();

                    if(m_fEapCore != null)
                    {
                        m_fEapCore.Dispose();
                        m_fEapCore = null;
                    }

                    m_fEventHandler = null;
                    m_fSecsDriverLog = null;
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
                m_fSecsDriverLog.removeAllObjectLog();

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

        private void procMenuVfeiViewer(
            )
        {
            FIObjectLog fObjectLog = null;
            FVfeiViewer fVfeiViewer = null;
            StringBuilder sb = null;
            string key = string.Empty;

            try
            {
                fVfeiViewer = (FVfeiViewer)m_fSsmCore.fSsmContainer.getChild(typeof(FVfeiViewer));
                if (fVfeiViewer == null)
                {
                    fVfeiViewer = new FVfeiViewer(m_fSsmCore);
                    m_fSsmCore.fSsmContainer.showChild(fVfeiViewer);
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
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
                fObjectLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSmlViewer(
            )
        {
            FIObjectLog fObjectLog = null;
            FSmlViewer fSmlViewer = null;
            StringBuilder sb = null;
            string key = string.Empty;

            try
            {
                fSmlViewer = (FSmlViewer)m_fSsmCore.fSsmContainer.getChild(typeof(FSmlViewer));
                if (fSmlViewer == null)
                {
                    fSmlViewer = new FSmlViewer(m_fSsmCore);
                    m_fSsmCore.fSsmContainer.showChild(fSmlViewer);
                }
                fSmlViewer.activate();

                // -- 

                sb = new StringBuilder();
                // --
                key = tabMain.ActiveTab.Key;
                if (key == tabKLog)
                {
                    foreach (UltraTreeNode node in tvwLogTree.SelectedNodes)
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
                else if (key == tabKInterface)
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
                fSmlViewer.appendSml(sb.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fObjectLog = null;
                fSmlViewer = null;
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
                tvwLogTree.ImageList.Images.Add("ConvertToSml", Properties.Resources.ConvertToSml);
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
                tvwLogTree.ImageList.Images.Add("HdvStateChangedLog_Opened", Properties.Resources.HdvStateChangedLog_Opened);
                tvwLogTree.ImageList.Images.Add("HdvStateChangedLog_Connected", Properties.Resources.HdvStateChangedLog_Connected);
                tvwLogTree.ImageList.Images.Add("HdvStateChangedLog_Selected", Properties.Resources.HdvStateChangedLog_Selected);
                tvwLogTree.ImageList.Images.Add("HdvVfeiReceivedLog", Properties.Resources.HdvVfeiReceivedLog);
                tvwLogTree.ImageList.Images.Add("HdvVfeiSentLog", Properties.Resources.HdvVfeiSentLog);
                tvwLogTree.ImageList.Images.Add("HostDeviceLog", Properties.Resources.HostDeviceLog);
                tvwLogTree.ImageList.Images.Add("HostItemLog", Properties.Resources.HostItemLog);
                tvwLogTree.ImageList.Images.Add("HostItemLog_List", Properties.Resources.HostItemLog_List);
                tvwLogTree.ImageList.Images.Add("HostTransmitterRaisedLog", Properties.Resources.HostTransmitterRaisedLog);
                tvwLogTree.ImageList.Images.Add("HostTriggerRaisedLog", Properties.Resources.HostTriggerRaisedLog);
                tvwLogTree.ImageList.Images.Add("ImportStandardSecsMessages", Properties.Resources.ImportStandardSecsMessages);
                tvwLogTree.ImageList.Images.Add("JudgementPerformedLog", Properties.Resources.JudgementPerformedLog);
                tvwLogTree.ImageList.Images.Add("MapperPerformedLog", Properties.Resources.MapperPerformedLog);
                tvwLogTree.ImageList.Images.Add("EquipmentStateSetAltererPerformedLog", Properties.Resources.EquipmentStateSetAltererPerformedLog);
                tvwLogTree.ImageList.Images.Add("EquipmentStateAltererLog", Properties.Resources.EquipmentStateAltererLog);
                tvwLogTree.ImageList.Images.Add("Result_Error", Properties.Resources.Result_Error);
                tvwLogTree.ImageList.Images.Add("Result_Warning", Properties.Resources.Result_Warning);
                tvwLogTree.ImageList.Images.Add("ScenarioLog", Properties.Resources.ScenarioLog);
                tvwLogTree.ImageList.Images.Add("SdvBlockReceivedLog", Properties.Resources.SdvBlockReceivedLog);
                tvwLogTree.ImageList.Images.Add("SdvBlockSentLog", Properties.Resources.SdvBlockSentLog);
                tvwLogTree.ImageList.Images.Add("SdvControlMessageReceivedLog", Properties.Resources.SdvControlMessageReceivedLog);
                tvwLogTree.ImageList.Images.Add("SdvControlMessageSentLog", Properties.Resources.SdvControlMessageSentLog);
                tvwLogTree.ImageList.Images.Add("SdvDataMessageReceivedLog", Properties.Resources.SdvDataMessageReceivedLog);
                tvwLogTree.ImageList.Images.Add("SdvDataMessageReceivedLog_Primary", Properties.Resources.SdvDataMessageReceivedLog_Primary);
                tvwLogTree.ImageList.Images.Add("SdvDataMessageReceivedLog_Secondary", Properties.Resources.SdvDataMessageReceivedLog_Secondary);
                tvwLogTree.ImageList.Images.Add("SdvDataMessageSentLog", Properties.Resources.SdvDataMessageSentLog);
                tvwLogTree.ImageList.Images.Add("SdvDataMessageSentLog_Primary", Properties.Resources.SdvDataMessageSentLog_Primary);
                tvwLogTree.ImageList.Images.Add("SdvDataMessageSentLog_Secondary", Properties.Resources.SdvDataMessageSentLog_Secondary);
                tvwLogTree.ImageList.Images.Add("SdvDataReceivedLog", Properties.Resources.SdvDataReceivedLog);
                tvwLogTree.ImageList.Images.Add("SdvDataSentLog", Properties.Resources.SdvDataSentLog);
                tvwLogTree.ImageList.Images.Add("SdvErrorRaisedLog", Properties.Resources.SdvErrorRaisedLog);
                tvwLogTree.ImageList.Images.Add("SdvHandshakeReceivedLog", Properties.Resources.SdvHandshakeReceivedLog);
                tvwLogTree.ImageList.Images.Add("SdvHandshakeSentLog", Properties.Resources.SdvHandshakeSentLog);
                tvwLogTree.ImageList.Images.Add("SdvSmlReceivedLog", Properties.Resources.SdvSmlReceivedLog);
                tvwLogTree.ImageList.Images.Add("SdvSmlSentLog", Properties.Resources.SdvSmlSentLog);
                tvwLogTree.ImageList.Images.Add("SdvStateChangedLog", Properties.Resources.SdvStateChangedLog);
                tvwLogTree.ImageList.Images.Add("SdvStateChangedLog_Closed", Properties.Resources.SdvStateChangedLog_Closed);
                tvwLogTree.ImageList.Images.Add("SdvStateChangedLog_Opened", Properties.Resources.SdvStateChangedLog_Opened);
                tvwLogTree.ImageList.Images.Add("SdvStateChangedLog_Connected", Properties.Resources.SdvStateChangedLog_Connected);
                tvwLogTree.ImageList.Images.Add("SdvStateChangedLog_Selected", Properties.Resources.SdvStateChangedLog_Selected);
                tvwLogTree.ImageList.Images.Add("SdvTelnetPacketReceivedLog", Properties.Resources.SdvTelnetPacketReceivedLog);
                tvwLogTree.ImageList.Images.Add("SdvTelnetPacketSentLog", Properties.Resources.SdvTelnetPacketSentLog);
                tvwLogTree.ImageList.Images.Add("SdvTelnetStateChangedLog", Properties.Resources.SdvTelnetStateChangedLog);
                tvwLogTree.ImageList.Images.Add("SdvTimeoutRaisedLog", Properties.Resources.SdvTimeoutRaisedLog);
                tvwLogTree.ImageList.Images.Add("SecsDeviceLog", Properties.Resources.SecsDeviceLog);
                tvwLogTree.ImageList.Images.Add("SecsDriverLog", Properties.Resources.SecsDriverLog);
                tvwLogTree.ImageList.Images.Add("SecsItemLog", Properties.Resources.SecsItemLog);
                tvwLogTree.ImageList.Images.Add("SecsItemLog_List", Properties.Resources.SecsItemLog_List);
                tvwLogTree.ImageList.Images.Add("SecsLogFilter", Properties.Resources.SecsLogFilter);
                tvwLogTree.ImageList.Images.Add("SecsTransmitterRaisedLog", Properties.Resources.SecsTransmitterRaisedLog);
                tvwLogTree.ImageList.Images.Add("SecsTriggerRaisedLog", Properties.Resources.SecsTriggerRaisedLog);
                tvwLogTree.ImageList.Images.Add("StoragePerformedLog", Properties.Resources.StoragePerformedLog);

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
                    fObjectLog = m_fSecsDriverLog;
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
                    fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.SecsItemLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.HostItemLog
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
                    fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog
                    )
                {
                    mnuMenu.Tools[FMenuKey.MenuLgtConvertToSml].SharedProps.Enabled = true;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuLgtConvertToSml].SharedProps.Enabled = false;
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
                if (m_fSsmCore.fOption.logRecentFileList.Contains(fileName))
                {
                    m_fSsmCore.fOption.logRecentFileList.Remove(fileName);
                }
                else if (m_fSsmCore.fOption.logRecentFileList.Count == FConstants.RecentMaxCount)
                {
                    m_fSsmCore.fOption.logRecentFileList.RemoveAt(m_fSsmCore.fOption.logRecentFileList.Count - 1);
                }
                m_fSsmCore.fOption.logRecentFileList.Insert(0, fileName);

                // --

                m_fSsmCore.fWsmOption.recentFile = fileName;
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
            UltraTreeNode tNodeScdl = null;
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

                    tNodeScdl = tvwLogTree.Nodes[0].RootNode;
                    tNodeScdl.Nodes.Add(tNodeChild);

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
                tNodeScdl = null;
                tNodeChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfObjectLog(
           )
        {
            UltraTreeNode tNodeScdl = null;
            UltraTreeNode tNodeLog = null;
            UltraTreeNode tNodeChildLog = null;

            try
            {
                tvwLogTree.beginUpdate();
                tvwLogTree.Nodes.Clear();

                // --

                // ***
                // SECS Driver Log Load
                // ***

                tNodeScdl = new UltraTreeNode(m_fSecsDriverLog.logUniqueIdToString);
                tNodeScdl.Tag = m_fSecsDriverLog;
                FCommon.refreshTreeNodeOfObjectLog(m_fSecsDriverLog, tNodeScdl, tvwLogTree);

                // --

                // ***
                // Log Object Load
                // ***
                foreach (FIObjectLog fObjectLog in m_fSecsDriverLog.fChildObjectLogCollection)
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

                    if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog)
                    {
                        foreach (FSecsItemLog fSitl in ((FSecsDeviceDataMessageReceivedLog)fObjectLog).fChildSecsItemLogCollection)
                        {
                            tNodeChildLog = new UltraTreeNode(fSitl.logUniqueIdToString);
                            tNodeChildLog.Tag = fSitl;
                            FCommon.refreshTreeNodeOfObjectLog(fSitl, tNodeChildLog, tvwLogTree);
                            tNodeLog.Nodes.Add(tNodeChildLog);
                        }
                    }
                    else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog)
                    {
                        foreach (FSecsItemLog fSitl in ((FSecsDeviceDataMessageSentLog)fObjectLog).fChildSecsItemLogCollection)
                        {
                            tNodeChildLog = new UltraTreeNode(fSitl.logUniqueIdToString);
                            tNodeChildLog.Tag = fSitl;
                            FCommon.refreshTreeNodeOfObjectLog(fSitl, tNodeChildLog, tvwLogTree);
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

                    tNodeScdl.Nodes.Add(tNodeLog);
                }

                // --

                tNodeScdl.Expanded = true;
                tvwLogTree.Nodes.Add(tNodeScdl);
                tvwLogTree.ActiveNode = tNodeScdl;

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
                tNodeScdl = null;
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
                if (fParent.fObjectLogType == FObjectLogType.SecsDriverLog)
                {

                }
                else if (fParent.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog)
                {
                    foreach (FSecsItemLog fSitl in ((FSecsDeviceDataMessageReceivedLog)fParent).fChildSecsItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fSitl.logUniqueIdToString);
                        tNodeChild.Tag = fSitl;
                        FCommon.refreshTreeNodeOfObjectLog(fSitl, tNodeChild, tvwLogTree);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog)
                {
                    foreach (FSecsItemLog fSitl in ((FSecsDeviceDataMessageSentLog)fParent).fChildSecsItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fSitl.logUniqueIdToString);
                        tNodeChild.Tag = fSitl;
                        FCommon.refreshTreeNodeOfObjectLog(fSitl, tNodeChild, tvwLogTree);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.SecsItemLog)
                {
                    foreach (FSecsItemLog fSitl in ((FSecsItemLog)fParent).fChildSecsItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fSitl.logUniqueIdToString);
                        tNodeChild.Tag = fSitl;
                        FCommon.refreshTreeNodeOfObjectLog(fSitl, tNodeChild, tvwLogTree);
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
                        m_fSsmCore.fWsmCore.fUIWizard.generateMessage("Q0002", new object[] { Path.GetFileName(m_fileName) }),
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxDefaultButton.Button3,
                        m_fSsmCore.fWsmCore.fWsmContainer
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
                openFileName = FCommon.loadFile(m_fSsmCore, fileName);

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

                m_fSecsDriverLog.openLogFile(openFileName);
                
                // --

                m_isTempFile = (fileName != openFileName) ? true : false;
                m_isNewFile = false;
                m_isModifiedFile = false;
                m_isCleared = false;
                // --
                m_fSsmCore.fOption.logRecentOpenPath = Path.GetDirectoryName(fileName);
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
                m_fSecsDriverLog.saveLogFile(fileName);

                // --

                m_isNewFile = false;
                m_isModifiedFile = false;
                m_isCleared = false;
                // --
                m_fSsmCore.fOption.logRecentSavePath = Path.GetDirectoryName(fileName);
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

                if (fType == FObjectLogType.SecsDriverLog)
                {
                    return true;    // FSecsDriverLog는 항상 존재합니다.
                }
                else if (fType == FObjectLogType.SecsDeviceStateChangedLog)
                {
                    return m_fSsmCore.fOption.enabledFilterOfSecsDeviceState;
                }
                else if (fType == FObjectLogType.SecsDeviceErrorRaisedLog)
                {
                    return m_fSsmCore.fOption.enabledFilterOfSecsDeviceError;
                }
                else if (fType == FObjectLogType.SecsDeviceTimeoutRaisedLog)
                {
                    return m_fSsmCore.fOption.enabledFilterOfSecsDeviceTimeout;
                }
                else if (
                    fType == FObjectLogType.SecsDeviceTelnetStateChangedLog ||
                    fType == FObjectLogType.SecsDeviceTelnetPacketReceivedLog ||
                    fType == FObjectLogType.SecsDeviceTelnetPacketSentLog
                    )
                {
                    return m_fSsmCore.fOption.enabledFilterOfSecsDeviceTelnet;
                }
                else if (
                    fType == FObjectLogType.SecsDeviceHandshakeReceivedLog ||
                    fType == FObjectLogType.SecsDeviceHandshakeSentLog
                    )
                {
                    return m_fSsmCore.fOption.enabledFilterOfSecsDeviceHandshake;
                }
                else if (
                    fType == FObjectLogType.SecsDeviceControlMessageReceivedLog ||
                    fType == FObjectLogType.SecsDeviceControlMessageSentLog
                    )
                {
                    return m_fSsmCore.fOption.enabledFilterOfSecsDeviceControlMessage;
                }
                else if (
                    fType == FObjectLogType.SecsDeviceBlockReceivedLog ||
                    fType == FObjectLogType.SecsDeviceBlockSentLog
                    )
                {
                    return m_fSsmCore.fOption.enabledFilterOfSecsDeviceBlock;
                }
                else if (
                    fType == FObjectLogType.SecsDeviceDataMessageReceivedLog ||
                    fType == FObjectLogType.SecsDeviceDataMessageSentLog ||
                    fType == FObjectLogType.SecsItemLog
                    )
                {
                    return m_fSsmCore.fOption.enabledFilterOfSecsDeviceDataMessage;
                }
                else if (fType == FObjectLogType.HostDeviceStateChangedLog)
                {
                    return m_fSsmCore.fOption.enabledFilterOfHostDeviceState;
                }
                else if (fType == FObjectLogType.HostDeviceErrorRaisedLog)
                {
                    return m_fSsmCore.fOption.enabledFilterOfHostDeviceError;
                }
                else if (
                    fType == FObjectLogType.HostDeviceDataMessageReceivedLog ||
                    fType == FObjectLogType.HostDeviceDataMessageSentLog ||
                    fType == FObjectLogType.HostItemLog
                    )
                {
                    return m_fSsmCore.fOption.enabledFilterOfHostDeviceDataMessage;
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
                    return m_fSsmCore.fOption.enabledFilterOfScenario;
                }
                else if (
                    fType == FObjectLogType.ApplicationWrittenLog ||
                    fType == FObjectLogType.ContentLog
                    )
                {
                    return m_fSsmCore.fOption.enabledFilterOfApplication;
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

                m_fSecsDriverLog = m_fSsmCore.fSsmFileInfo.fSecsDriver.createSecsDriverLog();

                // --

                loadTreeOfObjectLog();

                // --

                m_isNewFile = true;
                m_isModifiedFile = false;
                m_isCleared = true;
                // --
                m_fileName = m_fSecsDriverLog.name + ".ssl";

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
                dialog.InitialDirectory = m_fSsmCore.fOption.logRecentOpenPath;
                dialog.Title = fUIWizard.searchCaption("Open Log Trace File");
                dialog.Filter = "SSL File | *.ssl";
                dialog.DefaultExt = "ssl";

                // --

                if (dialog.ShowDialog(m_fSsmCore.fWsmCore.fWsmContainer) == DialogResult.Cancel)
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
                dialog.Filter = "SSL File | *.ssl";
                dialog.DefaultExt = "ssl";
                dialog.FileName = txtFileName.Text;
                // --
                if (m_isNewFile)
                {
                    dialog.InitialDirectory = m_fSsmCore.fOption.logRecentSavePath;
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
                fLogFilter = new FLogFilter(m_fSsmCore);
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
                ofd.Filter = FConstants.ComFileFilter;
                ofd.Multiselect = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    m_fEapCore = new FEapCore(m_fSsmCore, m_fSsmCore.fSsmFileInfo.fSecsDriver, m_fEventHandler);
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
                    FDebug.throwFException(m_fSsmCore.fUIWizard.generateMessage("E0010", new object[] { "File" }));
                }

                // --

                m_fComponent = FReflection.createInstance(m_compoFilePath,
                                                           typeName,
                                                           new object[] {
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
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataReceivedLog)
                {
                    fParentLog = ((FSecsDeviceDataReceivedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataSentLog)
                {
                    fParentLog = ((FSecsDeviceDataSentLog)fObjectLog).fParent;
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
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceSmlReceivedLog)
                {
                    fParentLog = ((FSecsDeviceSmlReceivedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceSmlSentLog)
                {
                    fParentLog = ((FSecsDeviceSmlSentLog)fObjectLog).fParent;
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

                fFirstLog = m_fSecsDriverLog.searchLogSeries(fBaseLog, searchWord);
                if (fFirstLog == null)
                {
                    FMessageBox.showInformation("Search", m_fSsmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { searchWord }), this);
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
                        fResultLog = m_fSecsDriverLog.searchLogSeries(fResultLog, searchWord);
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
                    FMessageBox.showInformation("Search", m_fSsmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { searchWord }), this);
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
                mnuMenu.beginUpdate();

                // --
                
                if (grdList.activeDataRow != null)
                {
                    fObjectLog = (FIObjectLog)grdList.activeDataRow.Tag;
                }

                // --

                mnuMenu.endUpdate();
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
                grdList.ImageList.Images.Add("SdvDataMessageReceivedLog", Properties.Resources.SdvDataMessageReceivedLog);
                grdList.ImageList.Images.Add("SdvDataMessageReceivedLog_Primary", Properties.Resources.SdvDataMessageReceivedLog_Primary);
                grdList.ImageList.Images.Add("SdvDataMessageReceivedLog_Secondary", Properties.Resources.SdvDataMessageReceivedLog_Secondary);
                grdList.ImageList.Images.Add("SdvDataMessageSentLog", Properties.Resources.SdvDataMessageSentLog);
                grdList.ImageList.Images.Add("SdvDataMessageSentLog_Primary", Properties.Resources.SdvDataMessageSentLog_Primary);
                grdList.ImageList.Images.Add("SdvDataMessageSentLog_Secondary", Properties.Resources.SdvDataMessageSentLog_Secondary);
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
                tvwInterfaceTree.ImageList.Images.Add("SdvDataMessageReceivedLog", Properties.Resources.SdvDataMessageReceivedLog);
                tvwInterfaceTree.ImageList.Images.Add("SdvDataMessageReceivedLog_Primary", Properties.Resources.SdvDataMessageReceivedLog_Primary);
                tvwInterfaceTree.ImageList.Images.Add("SdvDataMessageReceivedLog_Secondary", Properties.Resources.SdvDataMessageReceivedLog_Secondary);
                tvwInterfaceTree.ImageList.Images.Add("SdvDataMessageSentLog", Properties.Resources.SdvDataMessageSentLog);
                tvwInterfaceTree.ImageList.Images.Add("SdvDataMessageSentLog_Primary", Properties.Resources.SdvDataMessageSentLog_Primary);
                tvwInterfaceTree.ImageList.Images.Add("SdvDataMessageSentLog_Secondary", Properties.Resources.SdvDataMessageSentLog_Secondary);
                tvwInterfaceTree.ImageList.Images.Add("SecsItemLog", Properties.Resources.SecsItemLog);
                tvwInterfaceTree.ImageList.Images.Add("SecsItemLog_List", Properties.Resources.SecsItemLog_List);
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
                if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog)
                {
                    time = ((FSecsDeviceDataMessageReceivedLog)fObjectLog).time;
                    direction = "EAP ← " + ((FSecsDeviceDataMessageReceivedLog)fObjectLog).sessionName;
                    message =
                        "[" +
                        "S" + ((FSecsDeviceDataMessageReceivedLog)fObjectLog).stream.ToString() + " " +
                        "F" + ((FSecsDeviceDataMessageReceivedLog)fObjectLog).function.ToString() + " " +
                        "V" + ((FSecsDeviceDataMessageReceivedLog)fObjectLog).version.ToString() +
                        "] " + ((FSecsDeviceDataMessageReceivedLog)fObjectLog).name;
                    device = ((FSecsDeviceDataMessageReceivedLog)fObjectLog).deviceName;
                    session = ((FSecsDeviceDataMessageReceivedLog)fObjectLog).sessionName;
                    // --
                    if (((FSecsDeviceDataMessageReceivedLog)fObjectLog).isPrimary)
                    {
                        imagekey = "SdvDataMessageReceivedLog_Primary";
                    }
                    else
                    {
                        imagekey = "SdvDataMessageReceivedLog_Secondary";
                    }
                    // --
                    fResultCode = ((FSecsDeviceDataMessageReceivedLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog)
                {
                    time = ((FSecsDeviceDataMessageSentLog)fObjectLog).time;
                    direction = "EAP → " + ((FSecsDeviceDataMessageSentLog)fObjectLog).sessionName;
                    message =
                        "[" +
                        "S" + ((FSecsDeviceDataMessageSentLog)fObjectLog).stream.ToString() + " " +
                        "F" + ((FSecsDeviceDataMessageSentLog)fObjectLog).function.ToString() + " " +
                        "V" + ((FSecsDeviceDataMessageSentLog)fObjectLog).version.ToString() +
                        "] " + ((FSecsDeviceDataMessageSentLog)fObjectLog).name;
                    device = ((FSecsDeviceDataMessageSentLog)fObjectLog).deviceName;
                    session = ((FSecsDeviceDataMessageSentLog)fObjectLog).sessionName;
                    // --
                    if (((FSecsDeviceDataMessageSentLog)fObjectLog).isPrimary)
                    {
                        imagekey = "SdvDataMessageSentLog_Primary";
                    }
                    else
                    {
                        imagekey = "SdvDataMessageSentLog_Secondary";
                    }
                    // --
                    fResultCode = ((FSecsDeviceDataMessageSentLog)fObjectLog).fResultCode;
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
                foreach (FIObjectLog fLog in m_fSecsDriverLog.fChildObjectLogCollection)
                {
                    if (
                        fLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog ||
                        fLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog ||
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
                if (fParent.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog)
                {
                    foreach (FSecsItemLog fSitl in ((FSecsDeviceDataMessageReceivedLog)fParent).fChildSecsItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fSitl.logUniqueIdToString);
                        tNodeChild.Tag = fSitl;
                        FCommon.refreshTreeNodeOfObjectLog(fSitl, tNodeChild, tvwInterfaceTree);
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
                        FCommon.refreshTreeNodeOfObjectLog(fSitl, tNodeChild, tvwInterfaceTree);
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
                        FCommon.refreshTreeNodeOfObjectLog(fSitl, tNodeChild, tvwInterfaceTree);
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
                m_fSsmCore.fOption.commonFontName = preFontName;
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
                m_fSsmCore.fOption.commonFontSize = float.Parse(numFontSize.Value.ToString());
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

                ((FontListTool)mnuLogMenu.Tools[FMenuKey.MenuFontName]).Value = m_fSsmCore.fOption.commonFontName;
                numFontSize.Value = m_fSsmCore.fOption.commonFontSize;

                // --

                txtLog.Appearance.FontData.Name = ((FontListTool)mnuLogMenu.Tools[FMenuKey.MenuFontName]).Value.ToString();
                txtLog.Appearance.FontData.SizeInPoints = float.Parse(numFontSize.Value.ToString());

                // --

                if (m_fSsmCore.fSsmFileInfo.fSecsDriver == null)
                {
                    m_fSsmCore.fSsmFileInfo.newFile();
                }

                m_fSecsDriverLog = m_fSsmCore.fSsmFileInfo.fSecsDriver.createSecsDriverLog();
                // --
                m_fileName = m_fSecsDriverLog.name + ".ssl";
                // --
                m_isNewFile = true;
                m_isModifiedFile = false;
                m_isCleared = true;

                // --

                m_fEventHandler = new FEventHandler(m_fSsmCore.fSsmFileInfo.fSecsDriver, this);
                // --
                m_fEventHandler.SecsDeviceStateChanged += new FSecsDeviceStateChangedEventHandler(m_fEventHandler_SecsDeviceStateChanged);
                m_fEventHandler.SecsDeviceErrorRaised += new FSecsDeviceErrorRaisedEventHandler(m_fEventHandler_SecsDeviceErrorRaised);
                m_fEventHandler.SecsDeviceTimeoutRaised += new FSecsDeviceTimeoutRaisedEventHandler(m_fEventHandler_SecsDeviceTimeoutRaised);
                m_fEventHandler.SecsDeviceTelnetPacketReceived += new FSecsDeviceTelnetPacketReceivedEventHandler(m_fEventHandler_SecsDeviceTelnetPacketReceived);
                m_fEventHandler.SecsDeviceTelnetPacketSent += new FSecsDeviceTelnetPacketSentEventHandler(m_fEventHandler_SecsDeviceTelnetPacketSent);
                m_fEventHandler.SecsDeviceTelnetStateChanged += new FSecsDeviceTelnetStateChangedEventHandler(m_fEventHandler_SecsDeviceTelnetStateChanged);
                m_fEventHandler.SecsDeviceHandshakeReceived += new FSecsDeviceHandshakeReceivedEventHandler(m_fEventHandler_SecsDeviceHandshakeReceived);
                m_fEventHandler.SecsDeviceHandshakeSent += new FSecsDeviceHandshakeSentEventHandler(m_fEventHandler_SecsDeviceHandshakeSent);
                m_fEventHandler.SecsDeviceControlMessageReceived += new FSecsDeviceControlMessageReceivedEventHandler(m_fEventHandler_SecsDeviceControlMessageReceived);
                m_fEventHandler.SecsDeviceControlMessageSent += new FSecsDeviceControlMessageSentEventHandler(m_fEventHandler_SecsDeviceControlMessageSent);
                m_fEventHandler.SecsDeviceBlockReceived += new FSecsDeviceBlockReceivedEventHandler(m_fEventHandler_SecsDeviceBlockReceived);
                m_fEventHandler.SecsDeviceBlockSent += new FSecsDeviceBlockSentEventHandler(m_fEventHandler_SecsDeviceBlockSent);
                m_fEventHandler.SecsDeviceDataMessageReceived += new FSecsDeviceDataMessageReceivedEventHandler(m_fEventHandler_SecsDeviceDataMessageReceived);
                m_fEventHandler.SecsDeviceDataMessageSent += new FSecsDeviceDataMessageSentEventHandler(m_fEventHandler_SecsDeviceDataMessageSent);
                // -- 
                m_fEventHandler.HostDeviceStateChanged += new FHostDeviceStateChangedEventHandler(m_fEventHandler_HostDeviceStateChanged);
                m_fEventHandler.HostDeviceErrorRaised += new FHostDeviceErrorRaisedEventHandler(m_fEventHandler_HostDeviceErrorRaised);
                m_fEventHandler.HostDeviceDataMessageReceived += new FHostDeviceDataMessageReceivedEventHandler(m_fEventHandler_HostDeviceDataMessageReceived);
                m_fEventHandler.HostDeviceDataMessageSent += new FHostDeviceDataMessageSentEventHandler(m_fEventHandler_HostDeviceDataMessageSent);
                // --
                m_fEventHandler.SecsTriggerRaised += new FSecsTriggerRaisedEventHandler(m_fEventHandler_SecsTriggerRaised);
                m_fEventHandler.SecsTransmitterRaised += new FSecsTransmitterRaisedEventHandler(m_fEventHandler_SecsTransmitterRaised);
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

                m_fSsmCore.fOption.fChildFormList.add(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                    m_fSsmCore.fSsmFileInfo.fSecsDriver.waitEventHandlingCompleted();
                    m_fEventHandler.Dispose();

                    // --

                    m_fEventHandler.SecsDeviceStateChanged -= new FSecsDeviceStateChangedEventHandler(m_fEventHandler_SecsDeviceStateChanged);
                    m_fEventHandler.SecsDeviceErrorRaised -= new FSecsDeviceErrorRaisedEventHandler(m_fEventHandler_SecsDeviceErrorRaised);
                    m_fEventHandler.SecsDeviceTimeoutRaised -= new FSecsDeviceTimeoutRaisedEventHandler(m_fEventHandler_SecsDeviceTimeoutRaised);
                    m_fEventHandler.SecsDeviceTelnetPacketReceived -= new FSecsDeviceTelnetPacketReceivedEventHandler(m_fEventHandler_SecsDeviceTelnetPacketReceived);
                    m_fEventHandler.SecsDeviceTelnetPacketSent -= new FSecsDeviceTelnetPacketSentEventHandler(m_fEventHandler_SecsDeviceTelnetPacketSent);
                    m_fEventHandler.SecsDeviceTelnetStateChanged -= new FSecsDeviceTelnetStateChangedEventHandler(m_fEventHandler_SecsDeviceTelnetStateChanged);
                    m_fEventHandler.SecsDeviceHandshakeReceived -= new FSecsDeviceHandshakeReceivedEventHandler(m_fEventHandler_SecsDeviceHandshakeReceived);
                    m_fEventHandler.SecsDeviceHandshakeSent -= new FSecsDeviceHandshakeSentEventHandler(m_fEventHandler_SecsDeviceHandshakeSent);
                    m_fEventHandler.SecsDeviceControlMessageReceived -= new FSecsDeviceControlMessageReceivedEventHandler(m_fEventHandler_SecsDeviceControlMessageReceived);
                    m_fEventHandler.SecsDeviceControlMessageSent -= new FSecsDeviceControlMessageSentEventHandler(m_fEventHandler_SecsDeviceControlMessageSent);
                    m_fEventHandler.SecsDeviceBlockReceived -= new FSecsDeviceBlockReceivedEventHandler(m_fEventHandler_SecsDeviceBlockReceived);
                    m_fEventHandler.SecsDeviceBlockSent -= new FSecsDeviceBlockSentEventHandler(m_fEventHandler_SecsDeviceBlockSent);
                    m_fEventHandler.SecsDeviceDataMessageReceived -= new FSecsDeviceDataMessageReceivedEventHandler(m_fEventHandler_SecsDeviceDataMessageReceived);
                    m_fEventHandler.SecsDeviceDataMessageSent -= new FSecsDeviceDataMessageSentEventHandler(m_fEventHandler_SecsDeviceDataMessageSent);
                    // --
                    m_fEventHandler.HostDeviceStateChanged -= new FHostDeviceStateChangedEventHandler(m_fEventHandler_HostDeviceStateChanged);
                    m_fEventHandler.HostDeviceErrorRaised -= new FHostDeviceErrorRaisedEventHandler(m_fEventHandler_HostDeviceErrorRaised);
                    m_fEventHandler.HostDeviceDataMessageReceived -= new FHostDeviceDataMessageReceivedEventHandler(m_fEventHandler_HostDeviceDataMessageReceived);
                    m_fEventHandler.HostDeviceDataMessageSent -= new FHostDeviceDataMessageSentEventHandler(m_fEventHandler_HostDeviceDataMessageSent);
                    // --
                    m_fEventHandler.SecsTriggerRaised -= new FSecsTriggerRaisedEventHandler(m_fEventHandler_SecsTriggerRaised);
                    m_fEventHandler.SecsTransmitterRaised -= new FSecsTransmitterRaisedEventHandler(m_fEventHandler_SecsTransmitterRaised);
                    m_fEventHandler.HostTriggerRaised -= new FHostTriggerRaisedEventHandler(m_fEventHandler_HostTriggerRaised);
                    m_fEventHandler.HostTransmitterRaised -= new FHostTransmitterRaisedEventHandler(m_fEventHandler_HostTransmitterRaised);
                    m_fEventHandler.JudgementPerformed -= new FJudgementPerformedEventHandler(m_fEventHandler_JudgementPerformed);
                    m_fEventHandler.MapperPerformed -= new FMapperPerformedEventHandler(m_fEventHandler_MapperPerformed);
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

                m_fSsmCore.fOption.fChildFormList.remove(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }        

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fEventHandler Object Evnet Handler

        private void m_fEventHandler_SecsDeviceStateChanged(
            object sender,
            FSecsDeviceStateChangedEventArgs e
            )
        {
            try
            {
                m_fSecsDriverLog.appendChildObjectLog(e.fSecsDeviceStateChangedLog);
                appendTreeOfObjectLog(e.fSecsDeviceStateChangedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_SecsDeviceErrorRaised(
            object sender,
            FSecsDeviceErrorRaisedEventArgs e
            )
        {
            try
            {
                m_fSecsDriverLog.appendChildObjectLog(e.fSecsDeviceErrorRaisedLog);
                // --
                appendTreeOfObjectLog(e.fSecsDeviceErrorRaisedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_SecsDeviceTimeoutRaised(
            object sender,
            FSecsDeviceTimeoutRaisedEventArgs e
            )
        {
            try
            {
                m_fSecsDriverLog.appendChildObjectLog(e.fSecsDeviceTimeoutRaisedLog);
                // --
                appendTreeOfObjectLog(e.fSecsDeviceTimeoutRaisedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_SecsDeviceTelnetStateChanged(
            object sender,
            FSecsDeviceTelnetStateChangedEventArgs e
            )
        {
            try
            {
                m_fSecsDriverLog.appendChildObjectLog(e.fSecsDeviceTelnetStateChangedLog);
                appendTreeOfObjectLog(e.fSecsDeviceTelnetStateChangedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_SecsDeviceTelnetPacketReceived(
            object sender,
            FSecsDeviceTelnetPacketReceivedEventArgs e
            )
        {
            try
            {
                m_fSecsDriverLog.appendChildObjectLog(e.fSecsDeviceTelnetPacketReceivedLog);
                appendTreeOfObjectLog(e.fSecsDeviceTelnetPacketReceivedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }

        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_SecsDeviceTelnetPacketSent(
            object sender,
            FSecsDeviceTelnetPacketSentEventArgs e
            )
        {
            try
            {
                m_fSecsDriverLog.appendChildObjectLog(e.fSecsDeviceTelnetPacketSentLog);
                appendTreeOfObjectLog(e.fSecsDeviceTelnetPacketSentLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_SecsDeviceHandshakeReceived(
            object sender,
            FSecsDeviceHandshakeReceivedEventArgs e
            )
        {
            try
            {
                m_fSecsDriverLog.appendChildObjectLog(e.fSecsDeviceHandshakeReceivedLog);
                appendTreeOfObjectLog(e.fSecsDeviceHandshakeReceivedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_SecsDeviceHandshakeSent(
            object sender,
            FSecsDeviceHandshakeSentEventArgs e
            )
        {
            try
            {
                m_fSecsDriverLog.appendChildObjectLog(e.fSecsDeviceHandshakeSentLog);
                appendTreeOfObjectLog(e.fSecsDeviceHandshakeSentLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_SecsDeviceControlMessageReceived(
            object sender,
            FSecsDeviceControlMessageReceivedEventArgs e
            )
        {
            try
            {
                m_fSecsDriverLog.appendChildObjectLog(e.fSecsDeviceControlMessageReceivedLog);
                appendTreeOfObjectLog(e.fSecsDeviceControlMessageReceivedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_SecsDeviceControlMessageSent(
            object sender,
            FSecsDeviceControlMessageSentEventArgs e
            )
        {
            try
            {
                m_fSecsDriverLog.appendChildObjectLog(e.fSecsDeviceControlMessageSentLog);
                appendTreeOfObjectLog(e.fSecsDeviceControlMessageSentLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }


        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_SecsDeviceBlockReceived(
            object sender,
            FSecsDeviceBlockReceivedEventArgs e
            )
        {
            try
            {
                m_fSecsDriverLog.appendChildObjectLog(e.fSecsDeviceBlockReceivedLog);
                appendTreeOfObjectLog(e.fSecsDeviceBlockReceivedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_SecsDeviceBlockSent(
            object sender,
            FSecsDeviceBlockSentEventArgs e
            )
        {
            try
            {
                m_fSecsDriverLog.appendChildObjectLog(e.fSecsDeviceBlockSentLog);
                appendTreeOfObjectLog(e.fSecsDeviceBlockSentLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_SecsDeviceDataMessageSent(
            object sender,
            FSecsDeviceDataMessageSentEventArgs e
            )
        {
            try
            {
                m_fSecsDriverLog.appendChildObjectLog(e.fSecsDeviceDataMessageSentLog);
                appendTreeOfObjectLog(e.fSecsDeviceDataMessageSentLog);
                appendObjectLog(e.fSecsDeviceDataMessageSentLog, true);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_SecsDeviceDataMessageReceived(
            object sender,
            FSecsDeviceDataMessageReceivedEventArgs e
            )
        {
            try
            {
                m_fSecsDriverLog.appendChildObjectLog(e.fSecsDeviceDataMessageReceivedLog);
                appendTreeOfObjectLog(e.fSecsDeviceDataMessageReceivedLog);
                appendObjectLog(e.fSecsDeviceDataMessageReceivedLog, true);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                m_fSecsDriverLog.appendChildObjectLog(e.fHostDeviceStateChangedLog);
                appendTreeOfObjectLog(e.fHostDeviceStateChangedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                m_fSecsDriverLog.appendChildObjectLog(e.fHostDeviceErrorRaisedLog);
                appendTreeOfObjectLog(e.fHostDeviceErrorRaisedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                m_fSecsDriverLog.appendChildObjectLog(e.fHostDeviceDataMessageReceivedLog);
                appendTreeOfObjectLog(e.fHostDeviceDataMessageReceivedLog);
                appendObjectLog(e.fHostDeviceDataMessageReceivedLog, true);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                m_fSecsDriverLog.appendChildObjectLog(e.fHostDeviceDataMessageSentLog);
                appendTreeOfObjectLog(e.fHostDeviceDataMessageSentLog);
                appendObjectLog(e.fHostDeviceDataMessageSentLog, true);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_SecsTriggerRaised(
            object sender,
            FSecsTriggerRaisedEventArgs e
            )
        {
            try
            {
                m_fSecsDriverLog.appendChildObjectLog(e.fSecsTriggerRaisedLog);
                appendTreeOfObjectLog(e.fSecsTriggerRaisedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_SecsTransmitterRaised(
            object sender,
            FSecsTransmitterRaisedEventArgs e
            )
        {
            try
            {
                m_fSecsDriverLog.appendChildObjectLog(e.fSecsTransmitterRaisedLog);
                appendTreeOfObjectLog(e.fSecsTransmitterRaisedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                m_fSecsDriverLog.appendChildObjectLog(e.fHostTriggerRaisedLog);
                appendTreeOfObjectLog(e.fHostTriggerRaisedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                m_fSecsDriverLog.appendChildObjectLog(e.fHostTransmitterRaisedLog);
                appendTreeOfObjectLog(e.fHostTransmitterRaisedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                m_fSecsDriverLog.appendChildObjectLog(e.fJudgementPerformedLog);
                appendTreeOfObjectLog(e.fJudgementPerformedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                m_fSecsDriverLog.appendChildObjectLog(e.fMapperPerformedLog);
                appendTreeOfObjectLog(e.fMapperPerformedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                m_fSecsDriverLog.appendChildObjectLog(e.fEquipmentStateSetAltererPerformedLog);
                appendTreeOfObjectLog(e.fEquipmentStateSetAltererPerformedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                m_fSecsDriverLog.appendChildObjectLog(e.fStoragePerformedLog);
                appendTreeOfObjectLog(e.fStoragePerformedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                m_fSecsDriverLog.appendChildObjectLog(e.fCallbackRaisedLog);
                appendTreeOfObjectLog(e.fCallbackRaisedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                m_fSecsDriverLog.appendChildObjectLog(e.fFunctionCalledLog);
                appendTreeOfObjectLog(e.fFunctionCalledLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                m_fSecsDriverLog.appendChildObjectLog(e.fBranchRaisedLog);
                appendTreeOfObjectLog(e.fBranchRaisedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                m_fSecsDriverLog.appendChildObjectLog(e.fCommentWrittenLog);
                appendTreeOfObjectLog(e.fCommentWrittenLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                m_fSecsDriverLog.appendChildObjectLog(e.fPauserRaisedLog);
                appendTreeOfObjectLog(e.fPauserRaisedLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                m_fSecsDriverLog.appendChildObjectLog(e.fEntryPointCalledLog);
                appendTreeOfObjectLog(e.fEntryPointCalledLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                m_fSecsDriverLog.appendChildObjectLog(e.fApplicationWrittenLog);
                appendTreeOfObjectLog(e.fApplicationWrittenLog);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                else if (e.Tool.Key == FMenuKey.MenuLgtConvertToSml)
                {
                    procMenuSmlViewer();
                }
                else if (e.Tool.Key == FMenuKey.MenuLgtConvertToVfei)
                {
                    procMenuVfeiViewer();
                }
                else if (e.Tool.Key == FMenuKey.MenuLgtFilterSelector)
                {
                    procMenuFilterSelector();
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                        ((FontListTool)mnuLogMenu.Tools[FMenuKey.MenuFontName]).Value = m_fSsmCore.fOption.commonFontName;
                        txtLog.Appearance.FontData.Name = m_fSsmCore.fOption.commonFontName;
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                if (fObjectLog.fObjectLogType == FObjectLogType.SecsDriverLog)
                {
                    pgdProp.selectedObject = new FPropScdl(m_fSsmCore, pgdProp, (FSecsDriverLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceStateChangedLog)
                {
                    pgdProp.selectedObject = new FPropSdcl(m_fSsmCore, pgdProp, (FSecsDeviceStateChangedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceErrorRaisedLog)
                {
                    pgdProp.selectedObject = new FPropSdel(m_fSsmCore, pgdProp, (FSecsDeviceErrorRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTimeoutRaisedLog)
                {
                    pgdProp.selectedObject = new FPropSdtl(m_fSsmCore, pgdProp, (FSecsDeviceTimeoutRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceControlMessageReceivedLog)
                {
                    pgdProp.selectedObject = new FPropCmrl(m_fSsmCore, pgdProp, (FSecsDeviceControlMessageReceivedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceControlMessageSentLog)
                {
                    pgdProp.selectedObject = new FPropCmsl(m_fSsmCore, pgdProp, (FSecsDeviceControlMessageSentLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog)
                {
                    pgdProp.selectedObject = new FPropSdmrl(m_fSsmCore, pgdProp, (FSecsDeviceDataMessageReceivedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog)
                {
                    pgdProp.selectedObject = new FPropSdmsl(m_fSsmCore, pgdProp, (FSecsDeviceDataMessageSentLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsItemLog)
                {
                    pgdProp.selectedObject = new FPropSitl(m_fSsmCore, pgdProp, (FSecsItemLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTelnetPacketReceivedLog)
                {
                    pgdProp.selectedObject = new FPropSdtprl(m_fSsmCore, pgdProp, (FSecsDeviceTelnetPacketReceivedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTelnetPacketSentLog)
                {
                    pgdProp.selectedObject = new FPropSdtpsl(m_fSsmCore, pgdProp, (FSecsDeviceTelnetPacketSentLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceTelnetStateChangedLog)
                {
                    pgdProp.selectedObject = new FPropSdtscl(m_fSsmCore, pgdProp, (FSecsDeviceTelnetStateChangedLog)fObjectLog);
                }
                // --
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceStateChangedLog)
                {
                    pgdProp.selectedObject = new FPropHdcl(m_fSsmCore, pgdProp, (FHostDeviceStateChangedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceErrorRaisedLog)
                {
                    pgdProp.selectedObject = new FPropHdel(m_fSsmCore, pgdProp, (FHostDeviceErrorRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                {
                    pgdProp.selectedObject = new FPropHdmrl(m_fSsmCore, pgdProp, (FHostDeviceDataMessageReceivedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                {
                    pgdProp.selectedObject = new FPropHdmsl(m_fSsmCore, pgdProp, (FHostDeviceDataMessageSentLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostItemLog)
                {
                    pgdProp.selectedObject = new FPropHitl(m_fSsmCore, pgdProp, (FHostItemLog)fObjectLog);
                }
                // --
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsTriggerRaisedLog)
                {
                    pgdProp.selectedObject = new FPropStrl(m_fSsmCore, pgdProp, (FSecsTriggerRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsTransmitterRaisedLog)
                {
                    pgdProp.selectedObject = new FPropStnl(m_fSsmCore, pgdProp, (FSecsTransmitterRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTriggerRaisedLog)
                {
                    pgdProp.selectedObject = new FPropHtrl(m_fSsmCore, pgdProp, (FHostTriggerRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTransmitterRaisedLog)
                {
                    pgdProp.selectedObject = new FPropHtnl(m_fSsmCore, pgdProp, (FHostTransmitterRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.JudgementPerformedLog)
                {
                    pgdProp.selectedObject = new FPropJdml(m_fSsmCore, pgdProp, (FJudgementPerformedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.MapperPerformedLog)
                {
                    pgdProp.selectedObject = new FPropMapl(m_fSsmCore, pgdProp, (FMapperPerformedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EquipmentStateSetAltererPerformedLog)
                {
                    pgdProp.selectedObject = new FPropEsal(m_fSsmCore, pgdProp, (FEquipmentStateSetAltererPerformedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.StoragePerformedLog)
                {
                    pgdProp.selectedObject = new FPropStgl(m_fSsmCore, pgdProp, (FStoragePerformedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CallbackRaisedLog)
                {
                    pgdProp.selectedObject = new FPropCbkl(m_fSsmCore, pgdProp, (FCallbackRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.FunctionCalledLog)
                {
                    pgdProp.selectedObject = new FPropFunl(m_fSsmCore, pgdProp, (FFunctionCalledLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.BranchRaisedLog)
                {
                    pgdProp.selectedObject = new FPropBrnl(m_fSsmCore, pgdProp, (FBranchRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CommentWrittenLog)
                {
                    pgdProp.selectedObject = new FPropCmtl(m_fSsmCore, pgdProp, (FCommentWrittenLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PauserRaisedLog)
                {
                    pgdProp.selectedObject = new FPropPaul(m_fSsmCore, pgdProp, (FPauserRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EntryPointCalledLog)
                {
                    pgdProp.selectedObject = new FPropEtpl(m_fSsmCore, pgdProp, (FEntryPointCalledLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.DataSetLog)
                {
                    pgdProp.selectedObject = new FPropDtsl(m_fSsmCore, pgdProp, (FDataSetLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.DataLog)
                {
                    pgdProp.selectedObject = new FPropDatl(m_fSsmCore, pgdProp, (FDataLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.RepositoryLog)
                {
                    pgdProp.selectedObject = new FPropRpsl(m_fSsmCore, pgdProp, (FRepositoryLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.ColumnLog)
                {
                    pgdProp.selectedObject = new FPropColl(m_fSsmCore, pgdProp, (FColumnLog)fObjectLog);
                }
                // --
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceHandshakeReceivedLog)
                {
                    pgdProp.selectedObject = new FPropSdhrl(m_fSsmCore, pgdProp, (FSecsDeviceHandshakeReceivedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceHandshakeSentLog)
                {
                    pgdProp.selectedObject = new FPropSdhsl(m_fSsmCore, pgdProp, (FSecsDeviceHandshakeSentLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceBlockReceivedLog)
                {
                    pgdProp.selectedObject = new FPropSdbrl(m_fSsmCore, pgdProp, (FSecsDeviceBlockReceivedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceBlockSentLog)
                {
                    pgdProp.selectedObject = new FPropSdbsl(m_fSsmCore, pgdProp, (FSecsDeviceBlockSentLog)fObjectLog);
                }
                // --
                else if (fObjectLog.fObjectLogType == FObjectLogType.ApplicationWrittenLog)
                {
                    pgdProp.selectedObject = new FPropAppl(m_fSsmCore, pgdProp, (FApplicationWrittenLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.ContentLog)
                {
                    pgdProp.selectedObject = new FPropCttl(m_fSsmCore, pgdProp, (FContentLog)fObjectLog);
                }

                // --

                controlMenu();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                tNode = null;
                fObjectLog = null;
                fDragDropData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwInterfaceTree_AfterActivate(
            object sender,
            NodeEventArgs e
            )
        {
            UltraTreeNode tNode = null;
            FIObjectLog fObjectLog = null;

            try
            {
                tNode = tvwInterfaceTree.ActiveNode;
                if (tNode == null)
                {
                    mnuMenu.Tools[FMenuKey.MenuIftCopy].SharedProps.Enabled = false;
                    return;
                }

                // --

                fObjectLog = (FIObjectLog)tNode.Tag;
                // --
                if (
                    fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.SecsItemLog
                    )
                {
                    mnuMenu.Tools[FMenuKey.MenuIftCopy].SharedProps.Enabled = true;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuIftCopy].SharedProps.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                tNode = null;
                fObjectLog = null;
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                fFirst = m_fSecsDriverLog.searchLogSeries(fBase, e.searchWord);
                if (fFirst == null)
                {
                    FMessageBox.showInformation("Search", m_fSsmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { e.searchWord }), this);
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
                    FMessageBox.showInformation("Search", m_fSsmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { e.searchWord }), this);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
