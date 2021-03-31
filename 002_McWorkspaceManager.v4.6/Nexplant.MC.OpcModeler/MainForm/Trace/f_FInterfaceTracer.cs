/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FInterfaceTracer.cs
--  Creator         : spike.lee
--  Create Date     : 2017.05.29
--  Description     : FAmate OPC Modeler Interface Tracer  Class
--  History         : Created by spike.lee at 2017.05.29
----------------------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinDataSource;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.Core.FaUIs;
using Infragistics.Win.UltraWinGrid;
using System.Drawing;

namespace Nexplant.MC.OpcModeler
{
    public partial class FInterfaceTracer : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FOpmCore m_fOpmCore = null;
        private FEventHandler m_fEventHandler = null;
        private FOpcDriverLog m_fOpcDriverLog = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FInterfaceTracer(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FInterfaceTracer(
            FOpmCore fOpmCore
            )
            :this()
        {
            base.fUIWizard = fOpmCore.fUIWizard;
            m_fOpmCore = fOpmCore;            
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
                    m_fOpmCore = null;
                }
                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

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

        private void controlMenu(
            )
        {
            FIObjectLog fObjectLog = null;

            try
            {
                if (grdList.activeDataRow == null)
                {
                    mnuMenu.Tools[FMenuKey.MenuIftExpand].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuIftCollapse].SharedProps.Enabled = false;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuIftCopy].SharedProps.Enabled = false;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuIftConvertToVfei].SharedProps.Enabled = false;
                }
                else
                {
                    fObjectLog = (FIObjectLog)grdList.activeDataRow.Tag;

                    // --

                    mnuMenu.Tools[FMenuKey.MenuIftExpand].SharedProps.Enabled = true;
                    mnuMenu.Tools[FMenuKey.MenuIftCollapse].SharedProps.Enabled = true;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuIftCopy].SharedProps.Enabled = true;

                    // --

                    if (
                        fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog ||
                        fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog
                        )
                    {
                        mnuMenu.Tools[FMenuKey.MenuIftConvertToVfei].SharedProps.Enabled = true;
                    }
                    else
                    {
                        mnuMenu.Tools[FMenuKey.MenuIftConvertToVfei].SharedProps.Enabled = false;
                    }
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
                grdList.ImageList.Images.Add("OdvDataMessageReadLog", Properties.Resources.OdvDataMessageReadLog);
                grdList.ImageList.Images.Add("OdvDataMessageReadLog_Primary", Properties.Resources.OdvDataMessageReadLog_Primary);
                grdList.ImageList.Images.Add("OdvDataMessageReadLog_Secondary", Properties.Resources.OdvDataMessageReadLog_Secondary);
                grdList.ImageList.Images.Add("OdvDataMessageWrittenLog", Properties.Resources.OdvDataMessageWrittenLog);
                grdList.ImageList.Images.Add("OdvDataMessageWrittenLog_Primary", Properties.Resources.OdvDataMessageWrittenLog_Primary);
                grdList.ImageList.Images.Add("OdvDataMessageWrittenLog_Secondary", Properties.Resources.OdvDataMessageWrittenLog_Secondary);
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
                tvwTree.ImageList.Images.Add("OdvDataMessageReadLog", Properties.Resources.OdvDataMessageReadLog);
                tvwTree.ImageList.Images.Add("OdvDataMessageReadLog_Primary", Properties.Resources.OdvDataMessageReadLog_Primary);
                tvwTree.ImageList.Images.Add("OdvDataMessageReadLog_Secondary", Properties.Resources.OdvDataMessageReadLog_Secondary);
                tvwTree.ImageList.Images.Add("OdvDataMessageWrittenLog", Properties.Resources.OdvDataMessageWrittenLog);
                tvwTree.ImageList.Images.Add("OdvDataMessageWrittenLog_Primary", Properties.Resources.OdvDataMessageWrittenLog_Primary);
                tvwTree.ImageList.Images.Add("OdvDataMessageWrittenLog_Secondary", Properties.Resources.OdvDataMessageWrittenLog_Secondary);
                tvwTree.ImageList.Images.Add("OpcEventItemListLog", Properties.Resources.OpcEventItemListLog);
                tvwTree.ImageList.Images.Add("OpcEventItemLog", Properties.Resources.OpcEventItemLog);
                tvwTree.ImageList.Images.Add("OpcItemListLog", Properties.Resources.OpcItemListLog);
                tvwTree.ImageList.Images.Add("OpcItemLog", Properties.Resources.OpcItemLog);
                // --
                tvwTree.ImageList.Images.Add("Result_Warning", Properties.Resources.Result_Warning);
                tvwTree.ImageList.Images.Add("Result_Error", Properties.Resources.Result_Error);

                // --

                tvwTree.setPopupMenu((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuIftPopupMenuTree]);
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
                m_fOpcDriverLog.appendChildObjectLog(fObjectLog);

                // --

                if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageReadLog)
                {
                    time = ((FOpcDeviceDataMessageReadLog)fObjectLog).time;
                    direction = "EAP ← " + ((FOpcDeviceDataMessageReadLog)fObjectLog).sessionName;
                    message = ((FOpcDeviceDataMessageReadLog)fObjectLog).name;
                    device = ((FOpcDeviceDataMessageReadLog)fObjectLog).deviceName;
                    session = ((FOpcDeviceDataMessageReadLog)fObjectLog).sessionName;
                    // --
                    if (((FOpcDeviceDataMessageReadLog)fObjectLog).isPrimary)
                    {
                        imagekey = "OdvDataMessageReadLog_Primary";
                    }
                    else
                    {
                        imagekey = "OdvDataMessageReadLog_Secondary";
                    }
                    // --
                    fResultCode = ((FOpcDeviceDataMessageReadLog)fObjectLog).fResultCode;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageWrittenLog)
                {
                    time = ((FOpcDeviceDataMessageWrittenLog)fObjectLog).time;
                    direction = "EAP → " + ((FOpcDeviceDataMessageWrittenLog)fObjectLog).sessionName;
                    message = ((FOpcDeviceDataMessageWrittenLog)fObjectLog).name;
                    device = ((FOpcDeviceDataMessageWrittenLog)fObjectLog).deviceName;
                    session = ((FOpcDeviceDataMessageWrittenLog)fObjectLog).sessionName;
                    // --
                    if (((FOpcDeviceDataMessageWrittenLog)fObjectLog).isPrimary)
                    {
                        imagekey = "OdvDataMessageWrittenLog_Primary";
                    }
                    else
                    {
                        imagekey = "OdvDataMessageWrittenLog_Secondary";
                    }
                    // --
                    fResultCode = ((FOpcDeviceDataMessageWrittenLog)fObjectLog).fResultCode;
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
                FCommon.refreshTreeNodeOfObjectLog(fObjectLog, tNode, tvwTree);

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
                if (fParent.fObjectLogType == FObjectLogType.OpcDeviceDataMessageReadLog)
                {
                    foreach (FOpcEventItemListLog fOell in ((FOpcDeviceDataMessageReadLog)fParent).fChildOpcEventItemListLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fOell.logUniqueIdToString);
                        tNodeChild.Tag = fOell;
                        FCommon.refreshTreeNodeOfObjectLog(fOell, tNodeChild, tvwTree);
                        tNodeParent.Nodes.Add(tNodeChild);
                        // --
                        loadTreeOfChildObjectLog(tNodeChild);
                    }
                    // --
                    foreach (FOpcItemListLog fOill in ((FOpcDeviceDataMessageReadLog)fParent).fChildOpcItemListLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fOill.logUniqueIdToString);
                        tNodeChild.Tag = fOill;
                        FCommon.refreshTreeNodeOfObjectLog(fOill, tNodeChild, tvwTree);
                        tNodeParent.Nodes.Add(tNodeChild);
                        // --
                        loadTreeOfChildObjectLog(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.OpcDeviceDataMessageWrittenLog)
                {
                    foreach (FOpcEventItemListLog fOell in ((FOpcDeviceDataMessageWrittenLog)fParent).fChildOpcEventItemListLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fOell.logUniqueIdToString);
                        tNodeChild.Tag = fOell;
                        FCommon.refreshTreeNodeOfObjectLog(fOell, tNodeChild, tvwTree);
                        tNodeParent.Nodes.Add(tNodeChild);
                        // --
                        loadTreeOfChildObjectLog(tNodeChild);
                    }
                    // --
                    foreach (FOpcItemListLog fOill in ((FOpcDeviceDataMessageWrittenLog)fParent).fChildOpcItemListLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fOill.logUniqueIdToString);
                        tNodeChild.Tag = fOill;
                        FCommon.refreshTreeNodeOfObjectLog(fOill, tNodeChild, tvwTree);
                        tNodeParent.Nodes.Add(tNodeChild);
                        // --
                        loadTreeOfChildObjectLog(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.OpcEventItemListLog)
                {
                    foreach (FOpcEventItemLog fOeil in ((FOpcEventItemListLog)fParent).fChildOpcEventItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fOeil.logUniqueIdToString);
                        tNodeChild.Tag = fOeil;
                        FCommon.refreshTreeNodeOfObjectLog(fOeil, tNodeChild, tvwTree);
                        tNodeParent.Nodes.Add(tNodeChild);                        
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.OpcItemListLog)
                {
                    foreach (FOpcItemLog fOitl in ((FOpcItemListLog)fParent).fChildOpcItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fOitl.logUniqueIdToString);
                        tNodeChild.Tag = fOitl;
                        FCommon.refreshTreeNodeOfObjectLog(fOitl, tNodeChild, tvwTree);
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
                        FCommon.refreshTreeNodeOfObjectLog(fHitl, tNodeChild, tvwTree);
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
                        FCommon.refreshTreeNodeOfObjectLog(fHitl, tNodeChild, tvwTree);
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
                        FCommon.refreshTreeNodeOfObjectLog(fHitl, tNodeChild, tvwTree);
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

        private string writeHeader(
            FOpcDeviceDataMessageReadLog readLog
            )
        {
            StringBuilder logBuilder = null;

            try
            {
                logBuilder = new StringBuilder();

                // --

                logBuilder.AppendLine(
                    "[" + readLog.time + "] " +
                    "DataRead, " +
                    "HostDevice=<" + readLog.deviceName + ">, " +
                    "SessionId=<" + readLog.sessionId + ">,"
                    );
                logBuilder.AppendLine(
                    "[" + readLog.time + "] " +
                    "ResultCode=<" + readLog.fResultCode + ">, " +
                    "ResultMessage=<" + readLog.resultMessage + ">"
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
            FOpcDeviceDataMessageWrittenLog writtenLog
            )
        {
            StringBuilder logBuilder = null;

            try
            {
                logBuilder = new StringBuilder();

                // --

                logBuilder.AppendLine(
                    "[" + writtenLog.time + "] " +
                    "DataWritten, " +
                    "HostDevice=<" + writtenLog.deviceName + ">, " +
                    "SessionId=<" + writtenLog.sessionId + ">"
                    );
                logBuilder.AppendLine(
                    "[" + writtenLog.time + "] " +
                    "ResultCode=<" + writtenLog.fResultCode + ">, " +
                    "ResultMessage=<" + writtenLog.resultMessage + ">"
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
                m_fOpcDriverLog.removeAllObjectLog();

                // --

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
                grdList.endUpdate();
                tvwTree.endUpdate();
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

            try
            {
                fVfeiViewer = (FVfeiViewer)m_fOpmCore.fOpmContainer.getChild(typeof(FVfeiViewer));
                if (fVfeiViewer == null)
                {
                    fVfeiViewer = new FVfeiViewer(m_fOpmCore);
                    m_fOpmCore.fOpmContainer.showChild(fVfeiViewer);
                }
                fVfeiViewer.activate();

                // -- 

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

                if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageReadLog)
                {
                    ((FOpcDeviceDataMessageReadLog)fObjectLog).copy();
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageWrittenLog)
                {
                    ((FOpcDeviceDataMessageWrittenLog)fObjectLog).copy();
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcEventItemLog)
                {
                    ((FOpcEventItemLog)fObjectLog).copy();
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcItemLog)
                {
                    ((FOpcItemLog)fObjectLog).copy();
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

        public void loadLogTrace(
            FOpcDriverLog fOpcDriverLog
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                procMenuClear();

                // --

                grdList.beginUpdate(false);
                // --
                foreach (FIObjectLog fLog in fOpcDriverLog.fChildObjectLogCollection)
                {
                    if (
                        fLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageReadLog || 
                        fLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageWrittenLog ||
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
                m_fOpmCore.fOption.commonFontName = preFontName;
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
                m_fOpmCore.fOption.commonFontSize = float.Parse(numFontSize.Value.ToString());
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

                if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageReadLog)
                {
                    sb.Append(writeHeader((FOpcDeviceDataMessageReadLog)fObjectLog));
                    sb.Append(((FOpcDeviceDataMessageReadLog)fObjectLog).convertToXml());
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageWrittenLog)
                {
                    sb.Append(writeHeader((FOpcDeviceDataMessageWrittenLog)fObjectLog));
                    sb.Append(((FOpcDeviceDataMessageWrittenLog)fObjectLog).convertToXml());
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

        #region FInterfaceTracer Form Event Handler

        private void FInterfaceTracer_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // -- 

                ((FontListTool)mnuLogMenu.Tools[FMenuKey.MenuFontName]).Value = m_fOpmCore.fOption.commonFontName;
                numFontSize.Value = m_fOpmCore.fOption.commonFontSize;

                // --

                txtLog.Appearance.FontData.Name = ((FontListTool)mnuLogMenu.Tools[FMenuKey.MenuFontName]).Value.ToString();
                txtLog.Appearance.FontData.SizeInPoints = float.Parse(numFontSize.Value.ToString());

                // --

                designGridOfLog();
                designTreeOfLog();                

                // --

                m_fOpcDriverLog = new FOpcDriverLog();

                // --

                m_fEventHandler = new FEventHandler(m_fOpmCore.fOpmFileInfo.fOpcDriver, this);
                // --
                m_fEventHandler.OpcDeviceDataMessageRead += new FOpcDeviceDataMessageReadEventHandler(m_fEventHandler_OpcDeviceDataMessageRead);
                m_fEventHandler.OpcDeviceDataMessageWritten += new FOpcDeviceDataMessageWrittenEventHandler(m_fEventHandler_OpcDeviceDataMessageWritten);
                m_fEventHandler.HostDeviceDataMessageReceived += new FHostDeviceDataMessageReceivedEventHandler(m_fEventHandler_HostDeviceDataMessageReceived);
                m_fEventHandler.HostDeviceDataMessageSent += new FHostDeviceDataMessageSentEventHandler(m_fEventHandler_HostDeviceDataMessageSent);  

                // --

                m_fOpmCore.fOption.fChildFormList.add(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FInterfaceTracer_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                controlMenu();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FInterfaceTracer_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                if (m_fEventHandler != null)
                {
                    m_fOpmCore.fOpmFileInfo.fOpcDriver.waitEventHandlingCompleted();
                    m_fEventHandler.Dispose();

                    // --

                    m_fEventHandler.OpcDeviceDataMessageRead -= new FOpcDeviceDataMessageReadEventHandler(m_fEventHandler_OpcDeviceDataMessageRead);
                    m_fEventHandler.OpcDeviceDataMessageWritten -= new FOpcDeviceDataMessageWrittenEventHandler(m_fEventHandler_OpcDeviceDataMessageWritten);
                    m_fEventHandler.HostDeviceDataMessageReceived -= new FHostDeviceDataMessageReceivedEventHandler(m_fEventHandler_HostDeviceDataMessageReceived);
                    m_fEventHandler.HostDeviceDataMessageSent -= new FHostDeviceDataMessageSentEventHandler(m_fEventHandler_HostDeviceDataMessageSent);

                    // --

                    m_fEventHandler = null;
                }

                // --

                if (m_fOpcDriverLog != null)
                {
                    m_fOpcDriverLog.Dispose();
                    m_fOpcDriverLog = null;
                }

                // --

                m_fOpmCore.fOption.fChildFormList.remove(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }        

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fEventHandler Object Evnet Handler

        private void m_fEventHandler_OpcDeviceDataMessageRead(
            object sender,
            FOpcDeviceDataMessageReadEventArgs e
            )
        {
            try
            {
                appendObjectLog(e.fOpcDeviceDataMessageReadLog, true);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_OpcDeviceDataMessageWritten(
            object sender,
            FOpcDeviceDataMessageWrittenEventArgs e
            )
        {
            try
            {
                appendObjectLog(e.fOpcDeviceDataMessageWrittenLog, true);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                appendObjectLog(e.fHostDeviceDataMessageReceivedLog, true);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                appendObjectLog(e.fHostDeviceDataMessageSentLog, true);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                        ((FontListTool)mnuLogMenu.Tools[FMenuKey.MenuFontName]).Value = m_fOpmCore.fOption.commonFontName;
                        txtLog.Appearance.FontData.Name = m_fOpmCore.fOption.commonFontName;
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
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

                if (e.Tool.Key == FMenuKey.MenuIftFreezeScreen)
                {
                    
                }
                else if (e.Tool.Key == FMenuKey.MenuIftUnfreezeScreen)
                {

                }
                else if (e.Tool.Key == FMenuKey.MenuIftClear)
                {
                    procMenuClear();
                }
                else if (e.Tool.Key == FMenuKey.MenuIftConvertToVfei)
                {
                    procMenuVfeiViewer();
                }
                else if (e.Tool.Key == FMenuKey.MenuIftExpand)
                {
                    procMenuExpand();
                }
                else if (e.Tool.Key == FMenuKey.MenuIftCollapse)
                {
                    procMenuCollapse();
                }
                else if (e.Tool.Key == FMenuKey.MenuIftCopy)
                {
                    procMenuCopy();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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

                mnuMenu.ShowPopup(FMenuKey.MenuIftPopupMenuGrid);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
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
                fFirst = m_fOpcDriverLog.searchLogSeries(fBase, e.searchWord);
                if (fFirst == null)
                {
                    FMessageBox.showInformation("Search", m_fOpmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { e.searchWord }), this);
                    return;
                }

                // --

                fResult = fFirst;
                tNode = null;

                // --

                while (fMessage == null)
                {
                    if (
                        fResult.fObjectLogType == FObjectLogType.OpcDeviceDataMessageReadLog ||
                        fResult.fObjectLogType == FObjectLogType.OpcDeviceDataMessageWrittenLog ||
                        fResult.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog ||
                        fResult.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog
                        )
                    {
                        fMessage = fResult;
                    }
                    else if (fResult.fObjectLogType == FObjectLogType.OpcEventItemListLog)
                    {
                        fMessage = ((FOpcEventItemListLog)fResult).fParent;                        
                    }
                    else if (fResult.fObjectLogType == FObjectLogType.OpcEventItemLog)
                    {
                        fMessage = ((FOpcEventItemLog)fResult).fParent.fParent;
                    }
                    else if (fResult.fObjectLogType == FObjectLogType.OpcItemListLog)
                    {
                        fMessage = ((FOpcItemListLog)fResult).fParent;
                    }
                    else if (fResult.fObjectLogType == FObjectLogType.OpcItemLog)
                    {
                        fMessage = ((FOpcItemLog)fResult).fParent.fParent;
                    }

                    else if (fResult.fObjectLogType == FObjectLogType.HostItemLog)
                    {
                        fTemp = fResult;
                        while (((FHostItemLog)fTemp).fParent.fObjectLogType != FObjectLogType.OpcDriverLog)
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
                        fResult = m_fOpcDriverLog.searchLogSeries(fResult, e.searchWord);
                        if (fResult == null || fResult.logUniqueId == fFirst.logUniqueId)
                        {
                            break;
                        }
                    }
                }

                // --

                if (fMessage == null)
                {
                    FMessageBox.showInformation("Search", m_fOpmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { e.searchWord }), this);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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

        #region tvwTree Control Event Handler

        private void tvwTree_KeyDown(
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwTree_MouseMove(
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

                tNode = tvwTree.GetNodeFromPoint(e.X, e.Y);
                if (tNode == null)
                {
                    return;
                }                

                // --                               

                fObjectLog = (FIObjectLog)tNode.Tag;
                fDragDropData = new FDragDropData(fObjectLog);
                // --
                tvwTree.DoDragDrop(new DataObject(fDragDropData), DragDropEffects.All);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                tNode = null;
                fObjectLog = null;
                fDragDropData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwTree_AfterActivate(
            object sender, 
            NodeEventArgs e
            )
        {
            UltraTreeNode tNode = null;
            FIObjectLog fObjectLog = null;

            try
            {
                tNode = tvwTree.ActiveNode;
                if (tNode == null)
                {
                    mnuMenu.Tools[FMenuKey.MenuIftCopy].SharedProps.Enabled = false;
                    return;
                }

                // --

                fObjectLog = (FIObjectLog)tNode.Tag;
                // --
                if (
                    fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageReadLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageWrittenLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.OpcEventItemLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.OpcItemLog
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                tNode = null;
                fObjectLog = null;
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void mumFontSize_BeforeExitEditMode(
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void mumFontSize_KeyDown(
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void mnbFontSize_ValueChanged(
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
