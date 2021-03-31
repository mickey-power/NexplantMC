/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FLogTracer.cs
--  Creator         : kitae
--  Create Date     : 2011.09.09
--  Description     : FAMate TCP Modeler Log Tracer  Class
--  History         : Created by kitae at 2011.09.09
----------------------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinTree;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaTcpDriver;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.TcpModeler
{
    public partial class FLogTracer : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
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

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FLogTracer(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FLogTracer(
            FTcmCore fTcmCore
            )
            :this()
        {
            base.fUIWizard = fTcmCore.fUIWizard;
            m_fTcmCore = fTcmCore;            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FLogTracer(
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
                    if (m_fEapCore != null)
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

        private void designTreeOfLog(
            )
        {
            try
            {
                tvwTree.ImageList = new ImageList();
                // --
                tvwTree.ImageList.Images.Add("ApplicationLog", Properties.Resources.ApplicationLog);
                tvwTree.ImageList.Images.Add("ApplicationWritedLog", Properties.Resources.ApplicationWritedLog);
                tvwTree.ImageList.Images.Add("BranchRaisedLog", Properties.Resources.BranchRaisedLog);
                tvwTree.ImageList.Images.Add("CallbackRaisedLog", Properties.Resources.CallbackRaisedLog);
                tvwTree.ImageList.Images.Add("CommentWritedLog", Properties.Resources.CommentWritedLog);
                tvwTree.ImageList.Images.Add("PauserRaisedLog", Properties.Resources.PauserRaisedLog);
                tvwTree.ImageList.Images.Add("EntryPointCalledLog", Properties.Resources.EntryPointCalledLog);
                tvwTree.ImageList.Images.Add("ContentLog", Properties.Resources.ContentLog);
                tvwTree.ImageList.Images.Add("ContentLog_List", Properties.Resources.ContentLog_List);
                tvwTree.ImageList.Images.Add("ConvertToVfei", Properties.Resources.ConvertToVfei);
                tvwTree.ImageList.Images.Add("DataLog", Properties.Resources.DataLog);
                tvwTree.ImageList.Images.Add("DataLog_List", Properties.Resources.DataLog_List);
                tvwTree.ImageList.Images.Add("DataSetLog", Properties.Resources.DataSetLog);
                tvwTree.ImageList.Images.Add("FunctionCalledLog", Properties.Resources.FunctionCalledLog);
                tvwTree.ImageList.Images.Add("HdvDataMessageReceivedLog", Properties.Resources.HdvDataMessageReceivedLog);
                tvwTree.ImageList.Images.Add("HdvDataMessageReceivedLog_Command", Properties.Resources.HdvDataMessageReceivedLog_Command);
                tvwTree.ImageList.Images.Add("HdvDataMessageReceivedLog_Reply", Properties.Resources.HdvDataMessageReceivedLog_Reply);
                tvwTree.ImageList.Images.Add("HdvDataMessageReceivedLog_Unsolicited", Properties.Resources.HdvDataMessageReceivedLog_Unsolicited);
                tvwTree.ImageList.Images.Add("HdvDataMessageSentLog", Properties.Resources.HdvDataMessageSentLog);
                tvwTree.ImageList.Images.Add("HdvDataMessageSentLog_Command", Properties.Resources.HdvDataMessageSentLog_Command);
                tvwTree.ImageList.Images.Add("HdvDataMessageSentLog_Reply", Properties.Resources.HdvDataMessageSentLog_Reply);
                tvwTree.ImageList.Images.Add("HdvDataMessageSentLog_Unsolicited", Properties.Resources.HdvDataMessageSentLog_Unsolicited);
                tvwTree.ImageList.Images.Add("HdvErrorRaisedLog", Properties.Resources.HdvErrorRaisedLog);
                tvwTree.ImageList.Images.Add("HdvStateChangedLog", Properties.Resources.HdvStateChangedLog);
                tvwTree.ImageList.Images.Add("HdvStateChangedLog_Closed", Properties.Resources.HdvStateChangedLog_Closed);
                tvwTree.ImageList.Images.Add("HdvStateChangedLog_Connected", Properties.Resources.HdvStateChangedLog_Connected);
                tvwTree.ImageList.Images.Add("HdvStateChangedLog_Opened", Properties.Resources.HdvStateChangedLog_Opened);
                tvwTree.ImageList.Images.Add("HdvStateChangedLog_Selected", Properties.Resources.HdvStateChangedLog_Selected);
                tvwTree.ImageList.Images.Add("HostDeviceLog", Properties.Resources.HostDeviceLog);
                tvwTree.ImageList.Images.Add("HostItemLog", Properties.Resources.HostItemLog);
                tvwTree.ImageList.Images.Add("HostItemLog_List", Properties.Resources.HostItemLog_List);
                tvwTree.ImageList.Images.Add("HostTransmitterRaisedLog", Properties.Resources.HostTransmitterRaisedLog);
                tvwTree.ImageList.Images.Add("HostTriggerRaisedLog", Properties.Resources.HostTriggerRaisedLog);
                tvwTree.ImageList.Images.Add("JudgementPerformedLog", Properties.Resources.JudgementPerformedLog);
                tvwTree.ImageList.Images.Add("MapperPerformedLog", Properties.Resources.MapperPerformedLog);
                tvwTree.ImageList.Images.Add("EquipmentStateSetAltererPerformedLog", Properties.Resources.EquipmentStateSetAltererPerformedLog);
                tvwTree.ImageList.Images.Add("EquipmentStateAltererLog", Properties.Resources.EquipmentStateAltererLog);
                tvwTree.ImageList.Images.Add("Result_Error", Properties.Resources.Result_Error);
                tvwTree.ImageList.Images.Add("Result_Warning", Properties.Resources.Result_Warning);
                tvwTree.ImageList.Images.Add("ScenarioLog", Properties.Resources.ScenarioLog);
                tvwTree.ImageList.Images.Add("TdvDataMessageReceivedLog", Properties.Resources.TdvDataMessageReceivedLog);
                tvwTree.ImageList.Images.Add("TdvDataMessageReceivedLog_Command", Properties.Resources.TdvDataMessageReceivedLog_Command);
                tvwTree.ImageList.Images.Add("TdvDataMessageReceivedLog_Reply", Properties.Resources.TdvDataMessageReceivedLog_Reply);
                tvwTree.ImageList.Images.Add("TdvDataMessageReceivedLog_Unsolicited", Properties.Resources.TdvDataMessageReceivedLog_Unsolicited);
                tvwTree.ImageList.Images.Add("TdvDataMessageSentLog", Properties.Resources.TdvDataMessageSentLog);
                tvwTree.ImageList.Images.Add("TdvDataMessageSentLog_Command", Properties.Resources.TdvDataMessageSentLog_Command);
                tvwTree.ImageList.Images.Add("TdvDataMessageSentLog_Reply", Properties.Resources.TdvDataMessageSentLog_Reply);
                tvwTree.ImageList.Images.Add("TdvDataMessageSentLog_Unsolicited", Properties.Resources.TdvDataMessageSentLog_Unsolicited);
                tvwTree.ImageList.Images.Add("TdvErrorRaisedLog", Properties.Resources.TdvErrorRaisedLog);
                tvwTree.ImageList.Images.Add("TdvStateChangedLog", Properties.Resources.TdvStateChangedLog);
                tvwTree.ImageList.Images.Add("TdvStateChangedLog_Closed", Properties.Resources.TdvStateChangedLog_Closed);
                tvwTree.ImageList.Images.Add("TdvStateChangedLog_Opened", Properties.Resources.TdvStateChangedLog_Opened);
                tvwTree.ImageList.Images.Add("TdvStateChangedLog_Connected", Properties.Resources.TdvStateChangedLog_Connected);
                tvwTree.ImageList.Images.Add("TdvStateChangedLog_Selected", Properties.Resources.TdvStateChangedLog_Selected);
                tvwTree.ImageList.Images.Add("TdvTimeoutRaisedLog", Properties.Resources.TdvTimeoutRaisedLog);
                tvwTree.ImageList.Images.Add("TcpDeviceLog", Properties.Resources.TcpDeviceLog);
                tvwTree.ImageList.Images.Add("TcpDriverLog", Properties.Resources.TcpDriverLog);
                tvwTree.ImageList.Images.Add("TcpItemLog", Properties.Resources.TcpItemLog);
                tvwTree.ImageList.Images.Add("TcpItemLog_List", Properties.Resources.TcpItemLog_List);
                tvwTree.ImageList.Images.Add("TcpLogFilter", Properties.Resources.TcpLogFilter);
                tvwTree.ImageList.Images.Add("TcpTransmitterRaisedLog", Properties.Resources.TcpTransmitterRaisedLog);
                tvwTree.ImageList.Images.Add("TcpTriggerRaisedLog", Properties.Resources.TcpTriggerRaisedLog);
                tvwTree.ImageList.Images.Add("StoragePerformedLog", Properties.Resources.StoragePerformedLog);

                // --

                // --

                // ***
                // 2017.04.05 by spike.lee
                // RepositoryLog 관련 Image 추가
                // ***
                tvwTree.ImageList.Images.Add("RepositoryLog", Properties.Resources.Repository_unlock);
                tvwTree.ImageList.Images.Add("ColumnLog_List", Properties.Resources.Column_List);
                tvwTree.ImageList.Images.Add("ColumnLog", Properties.Resources.Column);
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
                fObjectLog = m_fTcpDriverLog.appendChildObjectLog(fObjectLog);
                tvwTree.beginUpdate();

                if (isEnabledFilterOfObjectLog(fObjectLog))
                {
                    tNodeChild = new UltraTreeNode(fObjectLog.logUniqueIdToString);
                    tNodeChild.Tag = fObjectLog;

                    //--

                    FCommon.refreshTreeNodeOfObjectLog(fObjectLog, tNodeChild, tvwTree);

                    // --  

                    tNodeTcdl = tvwTree.Nodes[0].RootNode;
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
                        tvwTree.ActiveNode = tNodeChild;
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
                tvwTree.beginUpdate();
                tvwTree.Nodes.Clear();

                // --

                // ***
                // TCP Driver Log Load
                // ***
                tNodeTcdl = new UltraTreeNode(m_fTcpDriverLog.logUniqueIdToString);
                tNodeTcdl.Tag = m_fTcpDriverLog;
                FCommon.refreshTreeNodeOfObjectLog(m_fTcpDriverLog, tNodeTcdl, tvwTree);

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
                    FCommon.refreshTreeNodeOfObjectLog(fObjectLog, tNodeLog, tvwTree);

                    // --

                    if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog)
                    {
                        foreach (FTcpItemLog fTitl in ((FTcpDeviceDataMessageReceivedLog)fObjectLog).fChildTcpItemLogCollection)
                        {
                            tNodeChildLog = new UltraTreeNode(fTitl.logUniqueIdToString);
                            tNodeChildLog.Tag = fTitl;
                            FCommon.refreshTreeNodeOfObjectLog(fTitl, tNodeChildLog, tvwTree);
                            tNodeLog.Nodes.Add(tNodeChildLog);
                        }
                    }
                    else if (fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog)
                    {
                        foreach (FTcpItemLog fTitl in ((FTcpDeviceDataMessageSentLog)fObjectLog).fChildTcpItemLogCollection)
                        {
                            tNodeChildLog = new UltraTreeNode(fTitl.logUniqueIdToString);
                            tNodeChildLog.Tag = fTitl;
                            FCommon.refreshTreeNodeOfObjectLog(fTitl, tNodeChildLog, tvwTree);
                            tNodeLog.Nodes.Add(tNodeChildLog);
                        }
                    }
                    else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                    {
                        foreach (FHostItemLog fHitl in ((FHostDeviceDataMessageReceivedLog)fObjectLog).fChildHostItemLogCollection)
                        {
                            tNodeChildLog = new UltraTreeNode(fHitl.logUniqueIdToString);
                            tNodeChildLog.Tag = fHitl;
                            FCommon.refreshTreeNodeOfObjectLog(fHitl, tNodeChildLog, tvwTree);
                            tNodeLog.Nodes.Add(tNodeChildLog);
                        }
                    }
                    else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                    {
                        foreach (FHostItemLog fHitl in ((FHostDeviceDataMessageSentLog)fObjectLog).fChildHostItemLogCollection)
                        {
                            tNodeChildLog = new UltraTreeNode(fHitl.logUniqueIdToString);
                            tNodeChildLog.Tag = fHitl;
                            FCommon.refreshTreeNodeOfObjectLog(fHitl, tNodeChildLog, tvwTree);
                            tNodeLog.Nodes.Add(tNodeChildLog);
                        }
                    }
                    else if (fObjectLog.fObjectLogType == FObjectLogType.MapperPerformedLog)
                    {
                        foreach (FDataSetLog fDtsl in ((FMapperPerformedLog)fObjectLog).fChildDataSetLogCollection)
                        {
                            tNodeChildLog = new UltraTreeNode(fDtsl.logUniqueIdToString);
                            tNodeChildLog.Tag = fDtsl;
                            FCommon.refreshTreeNodeOfObjectLog(fDtsl, tNodeChildLog, tvwTree);
                            tNodeLog.Nodes.Add(tNodeChildLog);
                        }
                    }
                    else if (fObjectLog.fObjectLogType == FObjectLogType.StoragePerformedLog)
                    {
                        foreach (FRepositoryLog fRpsl in ((FStoragePerformedLog)fObjectLog).fChildRepositoryLogCollection)
                        {
                            tNodeChildLog = new UltraTreeNode(fRpsl.logUniqueIdToString);
                            tNodeChildLog.Tag = fRpsl;
                            FCommon.refreshTreeNodeOfObjectLog(fRpsl, tNodeChildLog, tvwTree);
                            tNodeLog.Nodes.Add(tNodeChildLog);
                        }
                    }
                    else if (fObjectLog.fObjectLogType == FObjectLogType.EquipmentStateSetAltererPerformedLog)
                    {
                        foreach (FEquipmentStateAltererLog fEatl in ((FEquipmentStateSetAltererPerformedLog)fObjectLog).fChildEquipmentStateAltererLogCollection)
                        {
                            tNodeChildLog = new UltraTreeNode(fEatl.logUniqueIdToString);
                            tNodeChildLog.Tag = fEatl;
                            FCommon.refreshTreeNodeOfObjectLog(fEatl, tNodeChildLog, tvwTree);
                            tNodeLog.Nodes.Add(tNodeChildLog);
                        }
                    }
                    else if (fObjectLog.fObjectLogType == FObjectLogType.ApplicationWrittenLog)
                    {
                        foreach (FContentLog fCttl in ((FApplicationWrittenLog)fObjectLog).fChildContentLogCollection)
                        {
                            tNodeChildLog = new UltraTreeNode(fCttl.logUniqueIdToString);
                            tNodeChildLog.Tag = fCttl;
                            FCommon.refreshTreeNodeOfObjectLog(fCttl, tNodeChildLog, tvwTree);
                            tNodeLog.Nodes.Add(tNodeChildLog);
                        }
                    }

                    // --

                    tNodeTcdl.Nodes.Add(tNodeLog);
                }

                // --

                tNodeTcdl.Expanded = true;
                tvwTree.Nodes.Add(tNodeTcdl);
                tvwTree.ActiveNode = tNodeTcdl;

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
                        FCommon.refreshTreeNodeOfObjectLog(fTitl, tNodeChild, tvwTree);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog)
                {
                    foreach (FTcpItemLog fTitl in ((FTcpDeviceDataMessageSentLog)fParent).fChildTcpItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fTitl.logUniqueIdToString);
                        tNodeChild.Tag = fTitl;
                        FCommon.refreshTreeNodeOfObjectLog(fTitl, tNodeChild, tvwTree);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.TcpItemLog)
                {
                    foreach (FTcpItemLog fTitl in ((FTcpItemLog)fParent).fChildTcpItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fTitl.logUniqueIdToString);
                        tNodeChild.Tag = fTitl;
                        FCommon.refreshTreeNodeOfObjectLog(fTitl, tNodeChild, tvwTree);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                {
                    foreach (FHostItemLog fHitl in ((FHostDeviceDataMessageReceivedLog)fParent).fChildHostItemLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fHitl.logUniqueIdToString);
                        tNodeChild.Tag = fHitl;
                        FCommon.refreshTreeNodeOfObjectLog(fHitl, tNodeChild, tvwTree);
                        tNodeParent.Nodes.Add(tNodeChild);
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
                    }
                }
                // --
                else if (fParent.fObjectLogType == FObjectLogType.MapperPerformedLog)
                {
                    foreach (FDataSetLog fDtsl in ((FMapperPerformedLog)fParent).fChildDataSetLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fDtsl.logUniqueIdToString);
                        tNodeChild.Tag = fDtsl;
                        FCommon.refreshTreeNodeOfObjectLog(fDtsl, tNodeChild, tvwTree);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.DataSetLog)
                {
                    foreach (FDataLog fDatl in ((FDataSetLog)fParent).fChildDataLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fDatl.logUniqueIdToString);
                        tNodeChild.Tag = fDatl;
                        FCommon.refreshTreeNodeOfObjectLog(fDatl, tNodeChild, tvwTree);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.DataLog)
                {
                    foreach (FDataLog fDatl in ((FDataLog)fParent).fChildDataLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fDatl.logUniqueIdToString);
                        tNodeChild.Tag = fDatl;
                        FCommon.refreshTreeNodeOfObjectLog(fDatl, tNodeChild, tvwTree);
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
                        FCommon.refreshTreeNodeOfObjectLog(fRpsl, tNodeChild, tvwTree);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.RepositoryLog)
                {
                    foreach (FColumnLog fColl in ((FRepositoryLog)fParent).fChildColumnLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fColl.logUniqueIdToString);
                        tNodeChild.Tag = fColl;
                        FCommon.refreshTreeNodeOfObjectLog(fColl, tNodeChild, tvwTree);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.EquipmentStateSetAltererPerformedLog)
                {
                    foreach (FEquipmentStateAltererLog fEatl in ((FEquipmentStateSetAltererPerformedLog)fParent).fChildEquipmentStateAltererLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fEatl.logUniqueIdToString);
                        tNodeChild.Tag = fEatl;
                        FCommon.refreshTreeNodeOfObjectLog(fEatl, tNodeChild, tvwTree);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.ColumnLog)
                {
                    foreach (FColumnLog fColl in ((FColumnLog)fParent).fChildColumnLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fColl.logUniqueIdToString);
                        tNodeChild.Tag = fColl;
                        FCommon.refreshTreeNodeOfObjectLog(fColl, tNodeChild, tvwTree);
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
                        FCommon.refreshTreeNodeOfObjectLog(fCttl, tNodeChild, tvwTree);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectLogType == FObjectLogType.ContentLog)
                {
                    foreach (FContentLog fCttl in ((FContentLog)fParent).fChildContentLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fCttl.logUniqueIdToString);
                        tNodeChild.Tag = fCttl;
                        FCommon.refreshTreeNodeOfObjectLog(fCttl, tNodeChild, tvwTree);
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

            try
            {
                openFileName = FCommon.loadFile(m_fTcmCore, fileName);
                
                // --  

                tvwTree.beginUpdate();
                // --
                tvwTree.Nodes.Clear();
                // --
                tvwTree.endUpdate();

                // --

                m_fTcpDriverLog.openLogFile(openFileName);
                loadTreeOfObjectLog();

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

        private void saveLogFile(
            string fileName
            )
        {
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

        private void procMenuClear(
            )
        {
            try
            {
                m_fTcpDriverLog.removeAllObjectLog();

                // -- 

                tvwTree.beginUpdate();
                // --
                tvwTree.Nodes[0].RootNode.Nodes.Clear();
                // --
                tvwTree.endUpdate();

                // --

                m_isModifiedFile = true;
                m_isCleared = true;                

                // --

                refreshFileName();
                controlMenu();
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

        private void procMenuXlgViewer(
            )
        {
            FTcpProtocolSelector fProtocolSelector = null;
            FIObjectLog fObjectLog = null;
            FXlgViewer fXlgViewer = null;
            StringBuilder sb = null;

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
                    m_fComponent = FReflection.createInstance( ofd.FileName,
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

        private void procMenuConvertToInterfaceTrace(
            )
        {
            FInterfaceTracer fIfTracer = null;

            try
            {
                fIfTracer = (FInterfaceTracer)m_fTcmCore.fTcmContainer.getChild(typeof(FInterfaceTracer));
                if (fIfTracer == null)
                {
                    fIfTracer = new FInterfaceTracer(m_fTcmCore);
                    m_fTcmCore.fTcmContainer.showChild(fIfTracer);
                }
                fIfTracer.activate();

                // -- 

                fIfTracer.loadLogTrace(m_fTcpDriverLog);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fIfTracer = null;
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
                    FMessageBox.showInformation("Search", m_fTcmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { searchWord }), this);
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
                    tNode = tvwTree.GetNodeByKey(fResultLog.logUniqueIdToString);
                }

                // --

                tvwTree.endUpdate();

                // --

                if (tNode == null)
                {
                    FMessageBox.showInformation("Search", m_fTcmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { searchWord }), this);
                }
                else
                {
                    tvwTree.SelectedNodes.Clear();
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FLogTracer Form Event Handler

        private void FLogTracer_Load(
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

                tvwTree.setPopupMenu((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuLgtPopupMenu]);

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

                m_fEventHandler = new FEventHandler(m_fTcmCore.fTcmFileInfo.fTcpDriver, tvwTree);                
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

        private void FLogTracer_Shown(
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

                tvwTree.Focus();
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

        private void FLogTracer_FormCloseConfirm(
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

        private void FLogTracer_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                if (m_fEventHandler != null)
                {
                    if(m_fComponent != null) procMenuUnplugComponent();
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
                appendTreeOfObjectLog(e.fTcpDeviceDataMessageReceivedLog);
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
                appendTreeOfObjectLog(e.fTcpDeviceDataMessageSentLog);
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
                appendTreeOfObjectLog(e.fHostDeviceDataMessageReceivedLog);
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
                appendTreeOfObjectLog(e.fHostDeviceDataMessageSentLog);
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
                else if (e.Tool.Key == FMenuKey.MenuLgtConvertToInterfaceTrace)
                {
                    procMenuConvertToInterfaceTrace();
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
        
    }   // Class end
}   // Namespace end
