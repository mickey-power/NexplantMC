/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FTcpHostMessageSender.cs
--  Creator         : mjkim
--  Create Date     : 2020.07.03
--  Description     : FAmate Admin Manager TCP Host Message Sender Dialog Form Class 
--  History         : Created by mjkim at 2020.07.03
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
// --
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinTree;
// --
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaTcpDriver;

namespace Nexplant.MC.AdminManager
{
    public partial class FTcpHostMessageSender : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm, FITransaction
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_cancel = false;
        // --
        private List<FIObjectLog> m_fIObjectLogList = null;
        // -- 
        private FHostDevice m_fHostDevice = null;
        private FTcpDriver m_fTcpDriver = null;
        private object m_fHostDriver = null;
        private string m_hostDriverPath = string.Empty;
        private const string typeName = "Nexplant.MC.HostDriver.TCP.FHostDriver";

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTcpHostMessageSender(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpHostMessageSender(
            FAdmCore fAdmCore,
            List<FIObjectLog> fIObjectLogList
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
            m_fIObjectLogList = fIObjectLogList;
            // --
            
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
                    m_fIObjectLogList = null;
                    m_fTcpDriver = null;
                    m_fHostDevice = null;
                }
                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public bool cancel
        {
            get
            {
                try
                {
                    return m_cancel;
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

            set
            {
                try
                {
                    m_cancel = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void designGridOfHostMessage(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;

                // --

                uds.Band.Columns.Add("Check", typeof(bool));
                uds.Band.Columns.Add("Command");
                uds.Band.Columns.Add("Station");
                uds.Band.Columns.Add("Module");
                uds.Band.Columns.Add("Channel");
                uds.Band.Columns.Add("Result");
                uds.Band.Columns.Add("Proc. Time (ms)");
                uds.Band.Columns.Add("Message");

                // --

                grdList.DisplayLayout.Bands[0].Columns["Command"].CellAppearance.Image = Properties.Resources.HdvDataMessageSentLog_Unsolicited;
                grdList.DisplayLayout.Bands[0].Columns["Proc. Time (ms)"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Command"].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
                grdList.DisplayLayout.Bands[0].Columns["Station"].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
                grdList.DisplayLayout.Bands[0].Columns["Channel"].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
                grdList.DisplayLayout.Bands[0].Columns["Module"].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
                grdList.DisplayLayout.Bands[0].Columns["Result"].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
                grdList.DisplayLayout.Bands[0].Columns["Proc. Time (ms)"].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
                grdList.DisplayLayout.Bands[0].Columns["Message"].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = string.Empty;
                grdList.DisplayLayout.Bands[0].Columns["Check"].Header.CheckBoxVisibility = Infragistics.Win.UltraWinGrid.HeaderCheckBoxVisibility.Always;
                grdList.DisplayLayout.Bands[0].Columns["Check"].Header.Fixed = true;
                grdList.DisplayLayout.Bands[0].Columns["Command"].Header.Fixed = true;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Station"].Hidden = true;
                grdList.DisplayLayout.Bands[0].Columns["Channel"].Hidden = true;
                grdList.DisplayLayout.Bands[0].Columns["Module"].Hidden = true;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Check"].Width = 22;
                grdList.DisplayLayout.Bands[0].Columns["Command"].Width = 238;
                grdList.DisplayLayout.Bands[0].Columns["Station"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Channel"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Module"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Result"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Proc. Time (ms)"].Width = 90;
                grdList.DisplayLayout.Bands[0].Columns["Message"].Width = 120;

                // --

                grdList.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;

                // --

                grdList.ImageList = new ImageList();
                // --
                grdList.ImageList.Images.Add("Transaction_Target", Properties.Resources.Trn_Target);
                grdList.ImageList.Images.Add("Transaction_Result_Success", Properties.Resources.Trn_Result_Success);
                grdList.ImageList.Images.Add("Transaction_Result_Fail", Properties.Resources.Trn_Result_Fail);
                grdList.ImageList.Images.Add("Transaction_Result_Cancel", Properties.Resources.Trn_Result_Cancel);
                grdList.ImageList.Images.Add("Transaction_Result_Skip", Properties.Resources.Trn_Result_Skip);

                // --

                btnSend.Enabled = false;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                uds = null;
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
                tvwTree.ImageList.Images.Add("HdvDataMessageSentLog", Properties.Resources.HdvDataMessageSentLog);
                tvwTree.ImageList.Images.Add("HdvDataMessageSentLog_Command", Properties.Resources.HdvDataMessageSentLog_Command);
                tvwTree.ImageList.Images.Add("HdvDataMessageSentLog_Reply", Properties.Resources.HdvDataMessageSentLog_Reply);
                tvwTree.ImageList.Images.Add("HdvDataMessageSentLog_Unsolicited", Properties.Resources.HdvDataMessageSentLog_Unsolicited);
                tvwTree.ImageList.Images.Add("HostItemLog", Properties.Resources.HostItemLog);
                tvwTree.ImageList.Images.Add("HostItemLog_List", Properties.Resources.HostItemLog_List);
                // --
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
                tNode = null;
            }
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
                if (fParent.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
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

        private Image getImageOfList(
            string result
            )
        {
            try
            {
                if (result == "Success")
                {
                    return grdList.ImageList.Images["Transaction_Result_Success"];
                }
                else if (result == "Fail")
                {
                    return grdList.ImageList.Images["Transaction_Result_Fail"];
                }
                else if (result == "Cancel")
                {
                    return grdList.ImageList.Images["Transaction_Result_Cancel"];
                }
                else if (result == "Skip")
                {
                    return grdList.ImageList.Images["Transaction_Result_Skip"];
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return grdList.ImageList.Images["Transaction_Target"];
        }

        //------------------------------------------------------------------------------------------------------------------------

        public Image getImageOfObjectLog(
        FIObjectLog fObjectLog,
        FTreeView tvwTree
        )
        {
            FHostMessageType fHostMessageType;

            try
            {
                // ***
                // HostDevice
                // ***
                if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
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
                // HostDevice
                // ***
                if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                {
                    fResultCode = ((FHostDeviceDataMessageSentLog)fObjectLog).fResultCode;
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

        

        //------------------------------------------------------------------------------------------------------------------------

        public void action(
            )
        {
            string key = string.Empty;
            string result = string.Empty;
            string msg = string.Empty;
            Stopwatch sw = null;
            bool sendComplete = false;
            int sucCnt = 0;
            int faCnt = 0;
            int skCnt = 0;
            int canCnt = 0;
            
            try
            {
                sw = new Stopwatch();

                // --

                foreach (UltraGridRow r in grdList.Rows)
                {
                    sw.Reset();
                    sw.Start();
                    // --
                    Application.DoEvents();

                    // --

                    key = grdList.getDataRowKey(r.Index);

                    // --

                    grdList.activateDataRow(key);

                    // --

                    if (!Convert.ToBoolean(r.Cells["Check"].Value))
                    {
                        grdList.Rows[r.Index].Cells["Command"].Appearance.Image = getImageOfList("Skip");
                        result = this.fUIWizard.searchCaption("Skip");
                        msg = this.fUIWizard.generateMessage("M0015");
                        skCnt++;
                    }
                    else if (m_cancel)
                    {
                        grdList.Rows[r.Index].Cells["Command"].Appearance.Image = getImageOfList("Cancel");
                        result = this.fUIWizard.searchCaption("Cancel");
                        msg = this.fUIWizard.generateMessage("M0011");
                        canCnt++;
                    }
                    else
                    {
                        try
                        {
                            sendComplete = procSend(r.Tag as FHostDeviceDataMessageSentLog);

                            // --

                            if (sendComplete)
                            {
                                grdList.Rows[r.Index].Cells["Command"].Appearance.Image = getImageOfList("Success");
                                result = "Success";
                                msg = this.fUIWizard.generateMessage("M0012");
                                sucCnt++;
                            }
                            else
                            {
                                grdList.Rows[r.Index].Cells["Command"].Appearance.Image = getImageOfList("Fail");
                                result = "Fail";
                                msg = this.fUIWizard.generateMessage("M0011");
                                faCnt++;
                            }
                        }
                        catch (Exception ex)
                        {
                            grdList.Rows[r.Index].Cells["Command"].Appearance.Image = getImageOfList("Fail");
                            result = "Fail";
                            msg = ex.Message;
                            faCnt++;
                        }
                    }

                    // --

                    sw.Stop();

                    // ---

                    r.Cells["Result"].Value = result;
                    r.Cells["Proc. Time (ms)"].Value = sw.ElapsedMilliseconds.ToString();
                    r.Cells["Message"].Value = msg;
                }

                lblSuccess.Text = sucCnt.ToString();
                lblFail.Text = faCnt.ToString();
                lblSkip.Text = skCnt.ToString();
                lblCancel.Text = canCnt.ToString();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                sw = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void attachHostMessage(
            List<FIObjectLog> msgList
            )
        {
            object[] cellValues = null;
            FHostDeviceDataMessageSentLog fSentLog = null;
            int key = 0;
            int index = 0;

            try
            {
                grdList.beginUpdate(false);

                // --

                foreach (FIObjectLog log in msgList)
                {
                    if (log.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                    {
                        fSentLog = log as FHostDeviceDataMessageSentLog;
                        // --
                        cellValues = new object[] {
                            true,                   // Check
                            fSentLog.command,       // Command
                            fSentLog.connectString, // Station
                            fSentLog.moduleName,    // Module
                            fSentLog.castChannel,   // Channel
                            "",                     // Result 
                            "",                     // Proc. Time (ms)
                            ""                      // Message
                            };
                        index = grdList.appendOrUpdateDataRow((key++).ToString(), cellValues).Index;
                        grdList.Rows[index].Tag = fSentLog;
                    }
                }

                // --

                grdList.endUpdate(false);
                
                // --

                if (grdList.Rows.Count > 0)
                {
                    if (grdList.activeDataRow == null)
                    {
                        grdList.ActiveRow = grdList.Rows[0];
                    }
                }

                // --

                lblTotal.Text = grdList.Rows.Count.ToString("#,##0");

                // --

                //grdList.Focus();
            }
            catch (Exception ex)
            {
                grdList.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                cellValues = null;
                fSentLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private bool procSend(
            FHostDeviceDataMessageSentLog sentLog
            )
        {
            FHostDriverDataMessage fHdmg = null;
            bool sendComplete = false;

            try
            {
                Type type = FReflection.getType(m_hostDriverPath, typeName);

                fHdmg = new FHostDriverDataMessage(m_fTcpDriver);
                fHdmg.name = "HostMessage";
                fHdmg.command = sentLog.command;
                fHdmg.tid = sentLog.tid;
                fHdmg.multiCastMessage = sentLog.multiCastMessage;
                fHdmg.guaranteedMessage = sentLog.guaranteedMessage;
                fHdmg.fHostMessageType = sentLog.fHostMessageType;

                foreach (FHostItemLog fHitL in sentLog.fChildHostItemLogCollection)
                {
                    convertLogtoMsg(fHitL, fHdmg);
                }

                sendComplete = (bool)FReflection.invokeMethod(
                    m_fHostDriver,
                    type,
                    "sendMessage",
                    new object[]{
                        fHdmg
                    });

                return sendComplete;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fHdmg = null;
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void convertLogtoMsg(
            FHostItemLog fitemLog,
            FIObject fParent
            )
        {
            FHostItem fHit = null;

            try
            {
                if (fitemLog.fFormat == FFormat.List || fitemLog.fFormat == FFormat.AsciiList)
                {
                    fHit = new FHostItem(m_fTcpDriver);
                    fHit.name = fitemLog.name;
                    fHit.fFormat = fitemLog.fFormat;

                    if (fParent.fObjectType == FObjectType.HostDriverDataMessage)
                    {
                        ((FHostDriverDataMessage)fParent).appendChildHostItem(fHit);
                    }
                    else
                    {
                        ((FHostItem)fParent).appendChildHostItem(fHit);
                    }

                    // --

                    foreach (FHostItemLog fChild in fitemLog.fChildHostItemLogCollection)
                    {
                        convertLogtoMsg(fChild, fHit);
                    }
                }
                else
                {
                    fHit = new FHostItem(m_fTcpDriver);
                    fHit.name = fitemLog.name;
                    fHit.fFormat = fitemLog.fFormat;
                    fHit.originalValue = fitemLog.value;

                    if (fParent.fObjectType == FObjectType.HostDriverDataMessage)
                    {
                        ((FHostDriverDataMessage)fParent).appendChildHostItem(fHit);
                    }
                    else
                    {
                        ((FHostItem)fParent).appendChildHostItem(fHit);
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fHit = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FTcpHostMessageSender Form Event Handler

        private void FTcpHostMessageSender_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fTcpDriver = new FTcpDriver(m_fAdmCore.fWsmCore.appPath + "\\License\\license.lic");
                m_fHostDevice = m_fTcpDriver.appendChildHostDevice(new FHostDevice(m_fTcpDriver));
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

        private void FTcpHostMessageSender_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfHostMessage();
                designTreeOfLog();

                // --

                attachHostMessage(m_fIObjectLogList);
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

        private void FTcpHostMessageSender_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.defaultCursor();

                // --

                if (m_fHostDriver != null)
                {
                    Type type = FReflection.getType(m_hostDriverPath, typeName);

                    FReflection.invokeMethod(
                    m_fHostDriver,
                    type,
                    "close2",
                    new object[] { });
                    
                    FReflection.invokeMethod(m_fHostDriver, type, "Dispose", new object[] { });

                    m_fHostDriver = null;
                }
                // --
                if (m_fHostDevice != null)
                {
                    m_fHostDevice.close();
                    m_fHostDevice.Dispose();
                    m_fHostDevice = null;
                }
                // --
                if (m_fTcpDriver != null)
                {
                    m_fTcpDriver.closeAllDevice();
                    m_fTcpDriver.Dispose();
                    m_fTcpDriver = null;
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
            try
            {
                FCursor.waitCursor();

                // --

                //if (txtStation.Text != string.Empty)
                //{
                //    txtStation.Text = (String)grdList.activeDataRow["Station"];
                //}
                //if (txtModuleName.Text != string.Empty)
                //{
                //    txtModuleName.Text = (String)grdList.activeDataRow["Module"];
                //}
                //if (txtCastChannel.Text != string.Empty)
                //{
                //    txtCastChannel.Text = (String)grdList.activeDataRow["Channel"];
                //}

                // --

                if (grdList.activeDataRow == null)
                {
                    return;
                }

                // --
                
                loadTreeOfObjectLog((FIObjectLog)grdList.ActiveRow.Tag);
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

        #region btnSend Control Event Handler

        private void btnSend_Click(
            object sender, 
            EventArgs e
            )
        {
            FTransactionProgress fPrgDialog = null;
            Type type = null;

            try
            {
                FCursor.waitCursor();

                // --

                #region Validation

                if (string.IsNullOrEmpty(txtStation.Text))
                {
                    FDebug.throwFException("Station connect string is empty.");
                }
                // --
                else if (string.IsNullOrEmpty(txtCastChannel.Text))
                {
                    FDebug.throwFException("Cast channel is empty.");
                }
                // --
                else if (string.IsNullOrEmpty(txtModuleName.Text))
                {
                    FDebug.throwFException("Module is empty.");
                }

                #endregion

                // --

                type = FReflection.getType(m_hostDriverPath, typeName);

                FReflection.invokeMethod(
                    m_fHostDriver,
                    type,
                    "setDriverOption",
                    new object[] {
                        txtStation.Text,
                        "4.5",
                        5000,
                        86400000,
                        50,
                        (ushort)0,
                        txtModuleName.Text,
                        "/FMS/EISEAP",
                        txtCastChannel.Text
                    });

                // --

                FReflection.invokeMethod(
                    m_fHostDriver,
                    type,
                    "open2",
                    new object[] { });

                // --

                lblSuccess.Text = "0";
                lblFail.Text = "0";
                lblSkip.Text = "0";
                lblCancel.Text = "0";
                m_cancel = false;

                // --

                fPrgDialog = new FTransactionProgress(
                    m_fAdmCore,
                    this,
                    this.fUIWizard.generateMessage("M0010", new object[] { "Start" })
                    );
                fPrgDialog.ShowDialog();

            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                if (fPrgDialog != null)
                {
                    fPrgDialog.Dispose();
                    fPrgDialog = null;
                }

                FReflection.invokeMethod(
                    m_fHostDriver,
                    type,
                    "close2",
                    new object[] { });

                // --

                FCursor.defaultCursor();
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
            FTcpHostDriverSelector dialog = null;
            string[] selectNames = null;
            char[] splitChar = { '\\' };

            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tool.Key == FMenuKey.MenuThsOpen)
                {
                    dialog = new FTcpHostDriverSelector(m_fAdmCore, m_fHostDevice);
                    if (dialog.ShowDialog() == DialogResult.Cancel)
                    {
                        FMessageBox.showError(FConstants.ApplicationName, "There are no selected items.", m_fAdmCore.fWsmCore.fWsmContainer);
                    }
                    else
                    {
                        if (m_fHostDriver != null)
                        {
                            Type type = FReflection.getType(m_hostDriverPath, typeName);

                            FReflection.invokeMethod(
                            m_fHostDriver,
                            type,
                            "close2",
                            new object[] { });

                            FReflection.invokeMethod(m_fHostDriver, type, "Dispose", new object[] { });

                            m_fHostDriver = null;
                        }

                        // --

                        m_hostDriverPath = dialog.selectedFileName;
                        selectNames = m_hostDriverPath.Split(splitChar, StringSplitOptions.RemoveEmptyEntries);
                        
                        // --
                        
                        m_fHostDevice.createHostDriverOption(m_hostDriverPath);
                        // --
                        m_fHostDriver = FReflection.createInstance(
                            m_hostDriverPath,
                            typeName,
                            new object[] { m_fTcpDriver, m_fHostDevice
                            });
                        
                        // --

                        if (m_fHostDriver != null)
                        {
                            this.Text = "Host Message Sender [" + selectNames[selectNames.Length - 1] + "]";
                            // --
                            this.txtModuleName.Text = "MESPLUS";
                            this.txtStation.Text = "127.0.0.1:10101";
                            this.txtCastChannel.Text = "/FMS/EAPEIS";

                            btnSend.Enabled = true;
                        }
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

                // --

                selectNames = null;
                if (dialog != null)
                {
                    dialog.Dispose();
                    dialog = null;
                }
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

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------


    }   // Class end
}   // Namespace end
