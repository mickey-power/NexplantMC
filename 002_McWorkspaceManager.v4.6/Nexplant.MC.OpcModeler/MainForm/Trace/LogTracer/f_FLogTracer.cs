/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FLogTracer.cs
--  Creator         : kitae
--  Create Date     : 2011.09.09
--  Description     : Nexplant MC OPC Modeler Log Tracer Class
--  History         : Created by kitae at 2011.09.09
----------------------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using System.Windows.Forms;
using System.Text;
using System.Reflection;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinTree;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.OpcModeler
{
    public partial class FLogTracer : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FOpmCore m_fOpmCore = null;
        private string m_fileName = string.Empty;
        private bool m_isTempFile = false;
        private bool m_isNewFile = true;
        private bool m_isModifiedFile = false;
        private bool m_isCleared = false;
        private FEventHandler m_fEventHandler = null;
        private FOpcDriverLog m_fOpcDriverLog = null;
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
            FOpmCore fOpmCore
            )
            :this()
        {
            base.fUIWizard = fOpmCore.fUIWizard;
            m_fOpmCore = fOpmCore;            
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
                    m_fOpmCore = null;
                    if (m_fComponent != null) procMenuUnplugComponent();

                    if(m_fEapCore != null)
                    {
                        m_fEapCore.Dispose();
                        m_fEapCore = null;
                    }

                    m_fEventHandler = null;
                    m_fOpcDriverLog = null;
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
                tvwTree.ImageList.Images.Add("HdvVfeiReceivedLog", Properties.Resources.HdvVfeiReceivedLog);
                tvwTree.ImageList.Images.Add("HdvVfeiSentLog", Properties.Resources.HdvVfeiSentLog);
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
                tvwTree.ImageList.Images.Add("OdvDataMessageReadLog", Properties.Resources.OdvDataMessageReadLog);
                tvwTree.ImageList.Images.Add("OdvDataMessageReadLog_Primary", Properties.Resources.OdvDataMessageReadLog_Primary);
                tvwTree.ImageList.Images.Add("OdvDataMessageReadLog_Secondary", Properties.Resources.OdvDataMessageReadLog_Secondary);
                tvwTree.ImageList.Images.Add("OdvDataMessageWrittenLog", Properties.Resources.OdvDataMessageWrittenLog);
                tvwTree.ImageList.Images.Add("OdvDataMessageWrittenLog_Primary", Properties.Resources.OdvDataMessageWrittenLog_Primary);
                tvwTree.ImageList.Images.Add("OdvDataMessageWrittenLog_Secondary", Properties.Resources.OdvDataMessageWrittenLog_Secondary);
                tvwTree.ImageList.Images.Add("OdvDataReceivedLog", Properties.Resources.OdvDataReceivedLog);
                tvwTree.ImageList.Images.Add("OdvDataSentLog", Properties.Resources.OdvDataSentLog);
                tvwTree.ImageList.Images.Add("OdvErrorRaisedLog", Properties.Resources.OdvErrorRaisedLog);
                tvwTree.ImageList.Images.Add("OdvStateChangedLog", Properties.Resources.OdvStateChangedLog);
                tvwTree.ImageList.Images.Add("OdvStateChangedLog_Closed", Properties.Resources.OdvStateChangedLog_Closed);
                tvwTree.ImageList.Images.Add("OdvStateChangedLog_Opened", Properties.Resources.OdvStateChangedLog_Opened);
                tvwTree.ImageList.Images.Add("OdvStateChangedLog_Connected", Properties.Resources.OdvStateChangedLog_Connected);
                tvwTree.ImageList.Images.Add("OdvStateChangedLog_Selected", Properties.Resources.OdvStateChangedLog_Selected);
                tvwTree.ImageList.Images.Add("OdvStateChangedLog_Error", Properties.Resources.OdvStateChangedLog_Error);
                tvwTree.ImageList.Images.Add("OdvTimeoutRaisedLog", Properties.Resources.OdvTimeoutRaisedLog);
                tvwTree.ImageList.Images.Add("OpcDeviceLog", Properties.Resources.OpcDeviceLog);
                tvwTree.ImageList.Images.Add("OpcDriverLog", Properties.Resources.OpcDriverLog);
                tvwTree.ImageList.Images.Add("OpcEventItemListLog", Properties.Resources.OpcEventItemListLog);
                tvwTree.ImageList.Images.Add("OpcEventItemLog", Properties.Resources.OpcEventItemLog);
                tvwTree.ImageList.Images.Add("OpcItemListLog", Properties.Resources.OpcItemListLog);
                tvwTree.ImageList.Images.Add("OpcItemLog", Properties.Resources.OpcItemLog);
                tvwTree.ImageList.Images.Add("OpcLogFilter", Properties.Resources.OpcLogFilter);
                tvwTree.ImageList.Images.Add("OpcTransmitterRaisedLog", Properties.Resources.OpcTransmitterRaisedLog);
                tvwTree.ImageList.Images.Add("OpcTriggerRaisedLog", Properties.Resources.OpcTriggerRaisedLog);
                tvwTree.ImageList.Images.Add("StoragePerformedLog", Properties.Resources.StoragePerformedLog);

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
                    fObjectLog = m_fOpcDriverLog;
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
                    fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageReadLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageWrittenLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.OpcEventItemLog ||
                    fObjectLog.fObjectLogType == FObjectLogType.OpcItemLog ||
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
                if (m_fOpmCore.fOption.logRecentFileList.Contains(fileName))
                {
                    m_fOpmCore.fOption.logRecentFileList.Remove(fileName);
                }
                else if (m_fOpmCore.fOption.logRecentFileList.Count == FConstants.RecentMaxCount)
                {
                    m_fOpmCore.fOption.logRecentFileList.RemoveAt(m_fOpmCore.fOption.logRecentFileList.Count - 1);
                }
                m_fOpmCore.fOption.logRecentFileList.Insert(0, fileName);

                // --

                m_fOpmCore.fWsmOption.recentFile = fileName;
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
            UltraTreeNode tNodeOcdl = null;
            UltraTreeNode tNodeChild = null;

            try
            {
                fObjectLog = m_fOpcDriverLog.appendChildObjectLog(fObjectLog);
                tvwTree.beginUpdate();

                if (isEnabledFilterOfObjectLog(fObjectLog))
                {
                    tNodeChild = new UltraTreeNode(fObjectLog.logUniqueIdToString);
                    tNodeChild.Tag = fObjectLog;

                    //--

                    FCommon.refreshTreeNodeOfObjectLog(fObjectLog, tNodeChild, tvwTree);

                    // --  

                    tNodeOcdl = tvwTree.Nodes[0].RootNode;
                    tNodeOcdl.Nodes.Add(tNodeChild);

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
                tNodeOcdl = null;
                tNodeChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        private void loadTreeOfObjectLog(
           )
        {
            UltraTreeNode tNodeOcdl = null;
            UltraTreeNode tNodeLog = null;
            UltraTreeNode tNodeChildLog = null;

            try
            {
                tvwTree.beginUpdate();
                tvwTree.Nodes.Clear();

                // --

                // ***
                // OPC Driver Log Load
                // ***
                
                tNodeOcdl = new UltraTreeNode(m_fOpcDriverLog.logUniqueIdToString);
                tNodeOcdl.Tag = m_fOpcDriverLog;
                FCommon.refreshTreeNodeOfObjectLog(m_fOpcDriverLog, tNodeOcdl, tvwTree);

                // --

                // ***
                // Log Object Load
                // ***
                foreach (FIObjectLog fObjectLog in m_fOpcDriverLog.fChildObjectLogCollection)
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

                    if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageReadLog)
                    {
                        foreach (FOpcEventItemListLog fOell in ((FOpcDeviceDataMessageReadLog)fObjectLog).fChildOpcEventItemListLogCollection)
                        {
                            tNodeChildLog = new UltraTreeNode(fOell.logUniqueIdToString);
                            tNodeChildLog.Tag = fOell;
                            FCommon.refreshTreeNodeOfObjectLog(fOell, tNodeChildLog, tvwTree);
                            tNodeLog.Nodes.Add(tNodeChildLog);
                        }
                        // --
                        foreach (FOpcItemListLog fOill in ((FOpcDeviceDataMessageReadLog)fObjectLog).fChildOpcItemListLogCollection)
                        {
                            tNodeChildLog = new UltraTreeNode(fOill.logUniqueIdToString);
                            tNodeChildLog.Tag = fOill;
                            FCommon.refreshTreeNodeOfObjectLog(fOill, tNodeChildLog, tvwTree);
                            tNodeLog.Nodes.Add(tNodeChildLog);
                        }
                    }
                    else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageWrittenLog)
                    {
                        foreach (FOpcEventItemListLog fOell in ((FOpcDeviceDataMessageWrittenLog)fObjectLog).fChildOpcEventItemListLogCollection)
                        {
                            tNodeChildLog = new UltraTreeNode(fOell.logUniqueIdToString);
                            tNodeChildLog.Tag = fOell;
                            FCommon.refreshTreeNodeOfObjectLog(fOell, tNodeChildLog, tvwTree);
                            tNodeLog.Nodes.Add(tNodeChildLog);
                        }
                        // --
                        foreach (FOpcItemListLog fOill in ((FOpcDeviceDataMessageWrittenLog)fObjectLog).fChildOpcItemListLogCollection)
                        {
                            tNodeChildLog = new UltraTreeNode(fOill.logUniqueIdToString);
                            tNodeChildLog.Tag = fOill;
                            FCommon.refreshTreeNodeOfObjectLog(fOill, tNodeChildLog, tvwTree);
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

                    tNodeOcdl.Nodes.Add(tNodeLog);
                }

                // --

                tNodeOcdl.Expanded = true;
                tvwTree.Nodes.Add(tNodeOcdl);
                tvwTree.ActiveNode = tNodeOcdl;

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
                tNodeOcdl = null;
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
                if (fParent.fObjectLogType == FObjectLogType.OpcDriverLog)
                {
                        
                }
                else if (fParent.fObjectLogType == FObjectLogType.OpcDeviceDataMessageReadLog)
                {
                    foreach (FOpcEventItemListLog fOell in ((FOpcDeviceDataMessageReadLog)fParent).fChildOpcEventItemListLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fOell.logUniqueIdToString);
                        tNodeChild.Tag = fOell;
                        FCommon.refreshTreeNodeOfObjectLog(fOell, tNodeChild, tvwTree);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                    // --
                    foreach (FOpcItemListLog fOill in ((FOpcDeviceDataMessageReadLog)fParent).fChildOpcItemListLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fOill.logUniqueIdToString);
                        tNodeChild.Tag = fOill;
                        FCommon.refreshTreeNodeOfObjectLog(fOill, tNodeChild, tvwTree);
                        tNodeParent.Nodes.Add(tNodeChild);
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
                    }
                    // --
                    foreach (FOpcItemListLog fOill in ((FOpcDeviceDataMessageWrittenLog)fParent).fChildOpcItemListLogCollection)
                    {
                        tNodeChild = new UltraTreeNode(fOill.logUniqueIdToString);
                        tNodeChild.Tag = fOill;
                        FCommon.refreshTreeNodeOfObjectLog(fOill, tNodeChild, tvwTree);
                        tNodeParent.Nodes.Add(tNodeChild);
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
                else if (fParent.fObjectLogType == FObjectLogType.OpcEventItemLog)
                {
                    
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
                else if (fParent.fObjectLogType == FObjectLogType.OpcItemLog)
                {
                   
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
                        m_fOpmCore.fWsmCore.fUIWizard.generateMessage("Q0002", new object[] { Path.GetFileName(m_fileName) }),
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxDefaultButton.Button3,
                        m_fOpmCore.fWsmCore.fWsmContainer
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
                openFileName = FCommon.loadFile(m_fOpmCore, fileName);
                
                // --  

                tvwTree.beginUpdate();
                // --
                tvwTree.Nodes.Clear();
                // --
                tvwTree.endUpdate();

                // --

                m_fOpcDriverLog.openLogFile(openFileName);
                loadTreeOfObjectLog();

                // --

                m_isTempFile = (fileName != openFileName) ? true : false;
                m_isNewFile = false;
                m_isModifiedFile = false;                
                m_isCleared = false;
                // --
                m_fOpmCore.fOption.logRecentOpenPath = Path.GetDirectoryName(fileName);
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
                m_fOpcDriverLog.saveLogFile(fileName);

                // --

                m_isNewFile = false;
                m_isModifiedFile = false;                
                m_isCleared = false;
                // --
                m_fOpmCore.fOption.logRecentSavePath = Path.GetDirectoryName(fileName);
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

                if (fType == FObjectLogType.OpcDriverLog)
                {
                    return true;
                }
                else if (fType == FObjectLogType.OpcDeviceStateChangedLog)
                {
                    return m_fOpmCore.fOption.enabledFilterOfOpcDeviceState;
                }
                else if (fType == FObjectLogType.OpcDeviceErrorRaisedLog)
                {
                    return m_fOpmCore.fOption.enabledFilterOfOpcDeviceError;
                }
                else if (fType == FObjectLogType.OpcDeviceTimeoutRaisedLog)
                {
                    return m_fOpmCore.fOption.enabledFilterOfOpcDeviceTimeout;
                }
                else if (
                    fType == FObjectLogType.OpcDeviceDataMessageReadLog ||
                    fType == FObjectLogType.OpcDeviceDataMessageWrittenLog ||
                    fType == FObjectLogType.OpcEventItemListLog ||
                    fType == FObjectLogType.OpcEventItemLog ||
                    fType == FObjectLogType.OpcItemListLog ||
                    fType == FObjectLogType.OpcItemLog
                    )
                {
                    return m_fOpmCore.fOption.enabledFilterOfOpcDeviceDataMessage;
                }

                else if (fType == FObjectLogType.HostDeviceStateChangedLog)
                {
                    return m_fOpmCore.fOption.enabledFilterOfHostDeviceState;
                }
                else if (fType == FObjectLogType.HostDeviceErrorRaisedLog)
                {
                    return m_fOpmCore.fOption.enabledFilterOfHostDeviceError;
                }
                else if (
                    fType == FObjectLogType.HostDeviceDataMessageReceivedLog ||
                    fType == FObjectLogType.HostDeviceDataMessageSentLog ||
                    fType == FObjectLogType.HostItemLog
                    )
                {
                    return m_fOpmCore.fOption.enabledFilterOfHostDeviceDataMessage;
                }
                else if (
                    fType == FObjectLogType.OpcTriggerRaisedLog ||
                    fType == FObjectLogType.OpcTransmitterRaisedLog ||
                    fType == FObjectLogType.HostTriggerRaisedLog ||
                    fType == FObjectLogType.HostTransmitterRaisedLog ||
                    fType == FObjectLogType.EquipmentStateSetAltererPerformedLog ||
                    fType == FObjectLogType.JudgementPerformedLog ||
                    fType == FObjectLogType.MapperPerformedLog ||
                    fType == FObjectLogType.DataSetLog||
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
                    return m_fOpmCore.fOption.enabledFilterOfScenario;
                }
                else if (
                    fType == FObjectLogType.ApplicationWrittenLog ||
                    fType == FObjectLogType.ContentLog
                    )
                {
                    return m_fOpmCore.fOption.enabledFilterOfApplication;
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

                m_fOpcDriverLog = m_fOpmCore.fOpmFileInfo.fOpcDriver.createOpcDriverLog();

                // --

                loadTreeOfObjectLog();

                // --

                m_isNewFile = true;
                m_isModifiedFile = false;
                m_isCleared = true;
                // --
                m_fileName = m_fOpcDriverLog.name + ".osl";

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
                dialog.InitialDirectory = m_fOpmCore.fOption.logRecentOpenPath;
                dialog.Title = fUIWizard.searchCaption("Open Log Trace File");
                dialog.Filter = "OSL File | *.osl";
                dialog.DefaultExt = "osl";

                // --

                if (dialog.ShowDialog(m_fOpmCore.fWsmCore.fWsmContainer) == DialogResult.Cancel)
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
                dialog.Filter = "OSL File | *.osl";
                dialog.DefaultExt = "osl";
                dialog.FileName = txtFileName.Text;
                // --
                if (m_isNewFile)
                {
                    dialog.InitialDirectory = m_fOpmCore.fOption.logRecentSavePath;
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
                m_fOpcDriverLog.removeAllObjectLog();

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

                if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageReadLog)
                {
                    ((FOpcDeviceDataMessageReadLog)fObjectLog).copy();
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageWrittenLog)
                {
                    ((FOpcDeviceDataMessageWrittenLog)fObjectLog).copy();
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcEventItemListLog)
                {
                    ((FOpcEventItemListLog)fObjectLog).copy();
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcItemListLog)
                {
                    ((FOpcItemListLog)fObjectLog).copy();
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

        private void procMenuConvertToInterfaceTrace(
            )
        {
            FInterfaceTracer fIfTracer = null;

            try
            {
                fIfTracer = (FInterfaceTracer)m_fOpmCore.fOpmContainer.getChild(typeof(FInterfaceTracer));
                if (fIfTracer == null)
                {
                    fIfTracer = new FInterfaceTracer(m_fOpmCore);
                    m_fOpmCore.fOpmContainer.showChild(fIfTracer);
                }
                fIfTracer.activate();
                // -- 
                fIfTracer.loadLogTrace(m_fOpcDriverLog);
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

        private void procMenuFilterSelector(
            )
        {
            FLogFilter fLogFilter = null;

            try
            {
                fLogFilter = new FLogFilter(m_fOpmCore);
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
                    m_fEapCore = new FEapCore(m_fOpmCore, m_fOpmCore.fOpmFileInfo.fOpcDriver, m_fEventHandler);
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
                    FDebug.throwFException(m_fOpmCore.fUIWizard.generateMessage("E0010", new object[] { "File" }));
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
                if(m_fEapCore != null)
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
                if (fObjectLog.fObjectLogType == FObjectLogType.OpcDriverLog)
                {
                    return;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceStateChangedLog)
                {
                    fParentLog = ((FOpcDeviceStateChangedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceErrorRaisedLog)
                {
                    fParentLog = ((FOpcDeviceErrorRaisedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceTimeoutRaisedLog)
                {
                    fParentLog = ((FOpcDeviceTimeoutRaisedLog)fObjectLog).fParent;
                }  
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageReadLog)
                {
                    fParentLog = ((FOpcDeviceDataMessageReadLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageWrittenLog)
                {
                    fParentLog = ((FOpcDeviceDataMessageWrittenLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcEventItemListLog)
                {
                    fParentLog = ((FOpcEventItemListLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcEventItemLog)
                {
                    fParentLog = ((FOpcEventItemLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcItemListLog)
                {
                    fParentLog = ((FOpcItemListLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcItemLog)
                {
                    fParentLog = ((FOpcItemLog)fObjectLog).fParent;
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
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcTriggerRaisedLog)
                {
                    fParentLog = ((FOpcTriggerRaisedLog)fObjectLog).fParent;
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcTransmitterRaisedLog)
                {
                    fParentLog = ((FOpcTransmitterRaisedLog)fObjectLog).fParent;
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

                fFirstLog = m_fOpcDriverLog.searchLogSeries(fBaseLog, searchWord);
                if (fFirstLog == null)
                {
                    FMessageBox.showInformation("Search", m_fOpmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { searchWord }), this);
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
                        fResultLog = m_fOpcDriverLog.searchLogSeries(fResultLog, searchWord);
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
                    FMessageBox.showInformation("Search", m_fOpmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { searchWord }), this);
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

                if (m_fOpmCore.fOpmFileInfo.fOpcDriver == null)
                {
                    m_fOpmCore.fOpmFileInfo.newFile();
                }

                m_fOpcDriverLog = m_fOpmCore.fOpmFileInfo.fOpcDriver.createOpcDriverLog();
                // --
                m_fileName = m_fOpcDriverLog.name + ".osl";
                // --
                m_isNewFile = true;
                m_isModifiedFile = false;
                m_isCleared = true;

                // --

                m_fEventHandler = new FEventHandler(m_fOpmCore.fOpmFileInfo.fOpcDriver, tvwTree);                
                // --
                m_fEventHandler.OpcDeviceStateChanged += new FOpcDeviceStateChangedEventHandler(m_fEventHandler_OpcDeviceStateChanged);
                m_fEventHandler.OpcDeviceErrorRaised += new FOpcDeviceErrorRaisedEventHandler(m_fEventHandler_OpcDeviceErrorRaised);
                m_fEventHandler.OpcDeviceTimeoutRaised += new FOpcDeviceTimeoutRaisedEventHandler(m_fEventHandler_OpcDeviceTimeoutRaised);
                m_fEventHandler.OpcDeviceDataMessageRead += new FOpcDeviceDataMessageReadEventHandler(m_fEventHandler_OpcDeviceDataMessageRead);
                m_fEventHandler.OpcDeviceDataMessageWritten += new FOpcDeviceDataMessageWrittenEventHandler(m_fEventHandler_OpcDeviceDataMessageWritten);
                // -- 
                m_fEventHandler.HostDeviceStateChanged += new FHostDeviceStateChangedEventHandler(m_fEventHandler_HostDeviceStateChanged);
                m_fEventHandler.HostDeviceErrorRaised += new FHostDeviceErrorRaisedEventHandler(m_fEventHandler_HostDeviceErrorRaised);
                m_fEventHandler.HostDeviceDataMessageReceived += new FHostDeviceDataMessageReceivedEventHandler(m_fEventHandler_HostDeviceDataMessageReceived);
                m_fEventHandler.HostDeviceDataMessageSent += new FHostDeviceDataMessageSentEventHandler(m_fEventHandler_HostDeviceDataMessageSent);                
                // --
                m_fEventHandler.OpcTriggerRaised += new FOpcTriggerRaisedEventHandler(m_fEventHandler_OpcTriggerRaised);
                m_fEventHandler.OpcTransmitterRaised += new FOpcTransmitterRaisedEventHandler(m_fEventHandler_OpcTransmitterRaised);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                    if (m_fComponent != null) procMenuUnplugComponent();
                    m_fOpmCore.fOpmFileInfo.fOpcDriver.waitEventHandlingCompleted();
                    m_fEventHandler.Dispose();
                    
                    // --

                    m_fEventHandler.OpcDeviceStateChanged -= new FOpcDeviceStateChangedEventHandler(m_fEventHandler_OpcDeviceStateChanged);
                    m_fEventHandler.OpcDeviceErrorRaised -= new FOpcDeviceErrorRaisedEventHandler(m_fEventHandler_OpcDeviceErrorRaised);
                    m_fEventHandler.OpcDeviceTimeoutRaised -= new FOpcDeviceTimeoutRaisedEventHandler(m_fEventHandler_OpcDeviceTimeoutRaised);
                    m_fEventHandler.OpcDeviceDataMessageRead -= new FOpcDeviceDataMessageReadEventHandler(m_fEventHandler_OpcDeviceDataMessageRead);
                    m_fEventHandler.OpcDeviceDataMessageWritten -= new FOpcDeviceDataMessageWrittenEventHandler(m_fEventHandler_OpcDeviceDataMessageWritten);
                    // --
                    m_fEventHandler.HostDeviceStateChanged -= new FHostDeviceStateChangedEventHandler(m_fEventHandler_HostDeviceStateChanged);
                    m_fEventHandler.HostDeviceErrorRaised -= new FHostDeviceErrorRaisedEventHandler(m_fEventHandler_HostDeviceErrorRaised);
                    m_fEventHandler.HostDeviceDataMessageReceived -= new FHostDeviceDataMessageReceivedEventHandler(m_fEventHandler_HostDeviceDataMessageReceived);
                    m_fEventHandler.HostDeviceDataMessageSent -= new FHostDeviceDataMessageSentEventHandler(m_fEventHandler_HostDeviceDataMessageSent);
                    // --
                    m_fEventHandler.OpcTriggerRaised -= new FOpcTriggerRaisedEventHandler(m_fEventHandler_OpcTriggerRaised);
                    m_fEventHandler.OpcTransmitterRaised -= new FOpcTransmitterRaisedEventHandler(m_fEventHandler_OpcTransmitterRaised);
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

        private void m_fEventHandler_OpcDeviceStateChanged(
            object sender,
            FOpcDeviceStateChangedEventArgs e
            )
        {
            try
            {
                appendTreeOfObjectLog(e.fOpcDeviceStateChangedLog);
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

        private void m_fEventHandler_OpcDeviceErrorRaised(
            object sender,
            FOpcDeviceErrorRaisedEventArgs e
            )
        {
            try
            {
                appendTreeOfObjectLog(e.fOpcDeviceErrorRaisedLog);
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

        private void m_fEventHandler_OpcDeviceTimeoutRaised(
            object sender,
            FOpcDeviceTimeoutRaisedEventArgs e
            )
        {
            try
            {
                appendTreeOfObjectLog(e.fOpcDeviceTimeoutRaisedLog);
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

        private void m_fEventHandler_OpcDeviceDataMessageRead(
            object sender,
            FOpcDeviceDataMessageReadEventArgs e
            )
        {
            try
            {
                appendTreeOfObjectLog(e.fOpcDeviceDataMessageReadLog);
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
                appendTreeOfObjectLog(e.fOpcDeviceDataMessageWrittenLog);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                appendTreeOfObjectLog(e.fHostDeviceDataMessageReceivedLog);
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
                appendTreeOfObjectLog(e.fHostDeviceDataMessageSentLog);
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

        private void m_fEventHandler_OpcTriggerRaised(
            object sender, 
            FOpcTriggerRaisedEventArgs e
            )
        {
            try
            {
                appendTreeOfObjectLog(e.fOpcTriggerRaisedLog);
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

        private void m_fEventHandler_OpcTransmitterRaised(
            object sender, 
            FOpcTransmitterRaisedEventArgs e
            )
        {
            try
            {
                appendTreeOfObjectLog(e.fOpcTransmitterRaisedLog);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                else if (e.Tool.Key == FMenuKey.MenuLgtConvertToVfei)
                {
                    procMenuVfeiViewer();
                }
                else if (e.Tool.Key == FMenuKey.MenuLgtConvertToInterfaceTrace)
                {
                    procMenuConvertToInterfaceTrace();
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
                if (fObjectLog.fObjectLogType == FObjectLogType.OpcDriverLog)
                {
                    pgdProp.selectedObject = new FPropOcdl(m_fOpmCore, pgdProp, (FOpcDriverLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceStateChangedLog)
                {
                    pgdProp.selectedObject = new FPropOdcl(m_fOpmCore, pgdProp, (FOpcDeviceStateChangedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceErrorRaisedLog)
                {
                    pgdProp.selectedObject = new FPropOdel(m_fOpmCore, pgdProp, (FOpcDeviceErrorRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceTimeoutRaisedLog)
                {
                    pgdProp.selectedObject = new FPropOdtl(m_fOpmCore, pgdProp, (FOpcDeviceTimeoutRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageReadLog)
                {
                    pgdProp.selectedObject = new FPropOdmrl(m_fOpmCore, pgdProp, (FOpcDeviceDataMessageReadLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcDeviceDataMessageWrittenLog)
                {
                    pgdProp.selectedObject = new FPropOdmwl(m_fOpmCore, pgdProp, (FOpcDeviceDataMessageWrittenLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcEventItemListLog)
                {
                    pgdProp.selectedObject = new FPropOell(m_fOpmCore, pgdProp, (FOpcEventItemListLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcEventItemLog)
                {
                    pgdProp.selectedObject = new FPropOeil(m_fOpmCore, pgdProp, (FOpcEventItemLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcItemListLog)
                {
                    pgdProp.selectedObject = new FPropOill(m_fOpmCore, pgdProp, (FOpcItemListLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcItemLog)
                {
                    pgdProp.selectedObject = new FPropOitl(m_fOpmCore, pgdProp, (FOpcItemLog)fObjectLog);
                }
                // --
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceStateChangedLog)
                {
                    pgdProp.selectedObject = new FPropHdcl(m_fOpmCore, pgdProp, (FHostDeviceStateChangedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceErrorRaisedLog)
                {
                    pgdProp.selectedObject = new FPropHdel(m_fOpmCore, pgdProp, (FHostDeviceErrorRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceVfeiReceivedLog)
                {
                    pgdProp.selectedObject = new FPropHvrl(m_fOpmCore, pgdProp, (FHostDeviceVfeiReceivedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceVfeiSentLog)
                {
                    pgdProp.selectedObject = new FPropHvsl(m_fOpmCore, pgdProp, (FHostDeviceVfeiSentLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                {
                    pgdProp.selectedObject = new FPropHdmrl(m_fOpmCore, pgdProp, (FHostDeviceDataMessageReceivedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                {
                    pgdProp.selectedObject = new FPropHdmsl(m_fOpmCore, pgdProp, (FHostDeviceDataMessageSentLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostItemLog)
                {
                    pgdProp.selectedObject = new FPropHitl(m_fOpmCore, pgdProp, (FHostItemLog)fObjectLog);
                }
                // --
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcTriggerRaisedLog)
                {
                    pgdProp.selectedObject = new FPropOtrl(m_fOpmCore, pgdProp, (FOpcTriggerRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.OpcTransmitterRaisedLog)
                {
                    pgdProp.selectedObject = new FPropOtnl(m_fOpmCore, pgdProp, (FOpcTransmitterRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTriggerRaisedLog)
                {
                    pgdProp.selectedObject = new FPropHtrl(m_fOpmCore, pgdProp, (FHostTriggerRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.HostTransmitterRaisedLog)
                {
                    pgdProp.selectedObject = new FPropHtnl(m_fOpmCore, pgdProp, (FHostTransmitterRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.JudgementPerformedLog)
                {
                    pgdProp.selectedObject = new FPropJdml(m_fOpmCore, pgdProp, (FJudgementPerformedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.MapperPerformedLog)
                {
                    pgdProp.selectedObject = new FPropMapl(m_fOpmCore, pgdProp, (FMapperPerformedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EquipmentStateSetAltererPerformedLog)
                {
                    pgdProp.selectedObject = new FPropEsal(m_fOpmCore, pgdProp, (FEquipmentStateSetAltererPerformedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.StoragePerformedLog)
                {
                    pgdProp.selectedObject = new FPropStgl(m_fOpmCore, pgdProp, (FStoragePerformedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CallbackRaisedLog)
                {
                    pgdProp.selectedObject = new FPropCbkl(m_fOpmCore, pgdProp, (FCallbackRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.FunctionCalledLog)
                {
                    pgdProp.selectedObject = new FPropFunl(m_fOpmCore, pgdProp, (FFunctionCalledLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.BranchRaisedLog)
                {
                    pgdProp.selectedObject = new FPropBrnl(m_fOpmCore, pgdProp, (FBranchRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.CommentWrittenLog)
                {
                    pgdProp.selectedObject = new FPropCmtl(m_fOpmCore, pgdProp, (FCommentWrittenLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.PauserRaisedLog)
                {
                    pgdProp.selectedObject = new FPropPaul(m_fOpmCore, pgdProp, (FPauserRaisedLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.EntryPointCalledLog)
                {
                    pgdProp.selectedObject = new FPropEtpl(m_fOpmCore, pgdProp, (FEntryPointCalledLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.DataSetLog)
                {
                    pgdProp.selectedObject = new FPropDtsl(m_fOpmCore, pgdProp, (FDataSetLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.DataLog)
                {
                    pgdProp.selectedObject = new FPropDatl(m_fOpmCore, pgdProp, (FDataLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.RepositoryLog)
                {
                    pgdProp.selectedObject = new FPropRpsl(m_fOpmCore, pgdProp, (FRepositoryLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.ColumnLog)
                {
                    pgdProp.selectedObject = new FPropColl(m_fOpmCore, pgdProp, (FColumnLog)fObjectLog);
                }
                // --
                else if (fObjectLog.fObjectLogType == FObjectLogType.ApplicationWrittenLog)
                {
                    pgdProp.selectedObject = new FPropAppl(m_fOpmCore, pgdProp, (FApplicationWrittenLog)fObjectLog);
                }
                else if (fObjectLog.fObjectLogType == FObjectLogType.ContentLog)
                {
                    pgdProp.selectedObject = new FPropCttl(m_fOpmCore, pgdProp, (FContentLog)fObjectLog);
                }

                // --

                controlMenu();
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
