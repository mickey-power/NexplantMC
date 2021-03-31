/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FSecsInterfaceLogViewer.cs
--  Creator         : jungyoul
--  Create Date     : 2016.07.15
--  Description     : FAMate Admin Manager Secs Interface Log Viewer Form Class (WISOL)
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
using Nexplant.MC.Core.FaSecsDriver;

namespace Nexplant.MC.AdminManager
{
    public partial class FSecsInterfaceObjectLogViewer : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        // --
        private FIObjectLog m_fLogObject = null; 

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecsInterfaceObjectLogViewer(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsInterfaceObjectLogViewer(
            FAdmCore fAdmCore,
            FIObjectLog fLogObject
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            // --
            m_fAdmCore = fAdmCore;
            m_fLogObject = fLogObject;
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
                    m_fLogObject = null;
                    // --
                    m_fAdmCore = null;
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
                tvwTree.ImageList.Images.Add("SdvDataMessageReceivedLog", Properties.Resources.SdvDataMessageReceivedLog);
                tvwTree.ImageList.Images.Add("SdvDataMessageReceivedLog_Primary", Properties.Resources.SdvDataMessageReceivedLog_Primary);
                tvwTree.ImageList.Images.Add("SdvDataMessageReceivedLog_Secondary", Properties.Resources.SdvDataMessageReceivedLog_Secondary);
                tvwTree.ImageList.Images.Add("SdvDataMessageSentLog", Properties.Resources.SdvDataMessageSentLog);
                tvwTree.ImageList.Images.Add("SdvDataMessageSentLog_Primary", Properties.Resources.SdvDataMessageSentLog_Primary);
                tvwTree.ImageList.Images.Add("SdvDataMessageSentLog_Secondary", Properties.Resources.SdvDataMessageSentLog_Secondary);
                tvwTree.ImageList.Images.Add("SecsItemLog", Properties.Resources.SecsItemLog);
                tvwTree.ImageList.Images.Add("SecsItemLog_List", Properties.Resources.SecsItemLog_List);
                // --
                tvwTree.ImageList.Images.Add("Result_Warning", Properties.Resources.Result_Warning);
                tvwTree.ImageList.Images.Add("Result_Error", Properties.Resources.Result_Error);

                // --
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

        private void clear(
            )
        {
            try
            {
                // --

                tvwTree.beginUpdate();
                tvwTree.Nodes.Clear();
                tvwTree.endUpdate();

                // -- 
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
                FCommon.refreshTreeNodeOfObjectLog(fObjectLog, tvwTree, tNode);

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

        public void refreshLog(
            FIObjectLog fLogObject
            )
        {
            string beforeKey = string.Empty;

            try
            {
                if (fLogObject != null)
                {
                    loadTreeOfObjectLog(fLogObject);
                    loadTextOfObjectLog(fLogObject);
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
                if (fParent.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog)
                {
                    foreach (FSecsItemLog fSitl in ((FSecsDeviceDataMessageReceivedLog)fParent).fChildSecsItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fSitl.logUniqueIdToString);
                        tNodeChild.Tag = fSitl;
                        FCommon.refreshTreeNodeOfObjectLog(fSitl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                        // --
                        loadTreeOfChildObjectLog(tNodeChild);
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
                        // --
                        loadTreeOfChildObjectLog(tNodeChild);
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
                        FCommon.refreshTreeNodeOfObjectLog(fHitl, tvwTree, tNodeChild);
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
                        FCommon.refreshTreeNodeOfObjectLog(fHitl, tvwTree, tNodeChild);
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
                        FCommon.refreshTreeNodeOfObjectLog(fHitl, tvwTree, tNodeChild);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FSecsInterfaceLogViewer Form Event Handler

        private void FSecsInterfaceLogViewer_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                txtLog.Appearance.FontData.Name = m_fAdmCore.fOption.fontName;
                txtLog.Appearance.FontData.SizeInPoints = m_fAdmCore.fOption.fontSize;


                // --

                designTreeOfLog();

                // --

                m_fAdmCore.fOption.fChildFormList.add(this, this.Text);
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

        private void FSecsInterfaceLogViewer_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                loadTreeOfObjectLog(m_fLogObject);
                loadTextOfObjectLog(m_fLogObject);
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

        private void FSecsInterfaceLogViewer_FormClosing(
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

        #endregion
      
        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
