/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FSecsDeviceModeler.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.27
--  Description     : FAMate SECS Modeler SECS Device Modeler Form Class 
--  History         : Created by spike.lee at 2011.01.27
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using System.Text;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinTree;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.SecsModeler
{
    public partial class FSecsDeviceModeler : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSsmCore m_fSsmCore = null;
        private FEventHandler m_fEventHandler = null;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecsDeviceModeler(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsDeviceModeler(
            FSsmCore fSsmCore
            )
            : this()
        {
            base.fUIWizard = fSsmCore.fUIWizard;
            m_fSsmCore = fSsmCore;
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

        private void designTreeOfSecsLibraryModeler(
            )
        {
            try
            {
                tvwTree.ImageList = new ImageList();
                // --
                tvwTree.ImageList.Images.Add("SecsDriver", Properties.Resources.SecsDriver);
                tvwTree.ImageList.Images.Add("SecsDevice", Properties.Resources.SecsDevice);
                tvwTree.ImageList.Images.Add("SecsDevice_Closed_unlock", Properties.Resources.SecsDevice_Closed_unlock);
                tvwTree.ImageList.Images.Add("SecsDevice_Closed_lock", Properties.Resources.SecsDevice_Closed_lock);
                tvwTree.ImageList.Images.Add("SecsDevice_Opened_unlock", Properties.Resources.SecsDevice_Opened_unlock);
                tvwTree.ImageList.Images.Add("SecsDevice_Opened_lock", Properties.Resources.SecsDevice_Opened_lock);
                tvwTree.ImageList.Images.Add("SecsDevice_Connected_unlock", Properties.Resources.SecsDevice_Connected_unlock);
                tvwTree.ImageList.Images.Add("SecsDevice_Connected_lock", Properties.Resources.SecsDevice_Connected_lock);
                tvwTree.ImageList.Images.Add("SecsDevice_Selected_unlock", Properties.Resources.SecsDevice_Selected_unlock);
                tvwTree.ImageList.Images.Add("SecsDevice_Selected_lock", Properties.Resources.SecsDevice_Selected_lock);
                tvwTree.ImageList.Images.Add("SecsSession_unlock", Properties.Resources.SecsSession_unlock);
                tvwTree.ImageList.Images.Add("SecsSession_lock", Properties.Resources.SecsSession_lock);
                tvwTree.ImageList.Images.Add("SecsMessageList_unlock", Properties.Resources.SecsMessageList_unlock);
                tvwTree.ImageList.Images.Add("SecsMessageList_lock", Properties.Resources.SecsMessageList_lock);
                tvwTree.ImageList.Images.Add("SecsMessages_Eq_unlock", Properties.Resources.SecsMessages_Eq_unlock);
                tvwTree.ImageList.Images.Add("SecsMessages_Eq_lock", Properties.Resources.SecsMessages_Eq_lock);
                tvwTree.ImageList.Images.Add("SecsMessages_Host_unlock", Properties.Resources.SecsMessages_Host_unlock);
                tvwTree.ImageList.Images.Add("SecsMessages_Host_lock", Properties.Resources.SecsMessages_Host_lock);
                tvwTree.ImageList.Images.Add("SecsMessages_Both_unlock", Properties.Resources.SecsMessages_Both_unlock);
                tvwTree.ImageList.Images.Add("SecsMessages_Both_lock", Properties.Resources.SecsMessages_Both_lock);
                tvwTree.ImageList.Images.Add("SecsMessage_Primary_unlock", Properties.Resources.SecsMessage_Primary_unlock);
                tvwTree.ImageList.Images.Add("SecsMessage_Primary_lock", Properties.Resources.SecsMessage_Primary_lock);
                tvwTree.ImageList.Images.Add("SecsMessage_Secondary_unlock", Properties.Resources.SecsMessage_Secondary_unlock);
                tvwTree.ImageList.Images.Add("SecsMessage_Secondary_lock", Properties.Resources.SecsMessage_Secondary_lock);
                tvwTree.ImageList.Images.Add("SecsItem_List_unlock", Properties.Resources.SecsItem_List_unlock);
                tvwTree.ImageList.Images.Add("SecsItem_List_lock", Properties.Resources.SecsItem_List_lock);
                tvwTree.ImageList.Images.Add("SecsItem_unlock", Properties.Resources.SecsItem_unlock);
                tvwTree.ImageList.Images.Add("SecsItem_lock", Properties.Resources.SecsItem_lock);
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
            FIObject fObject = null;

            try
            {
                mnuMenu.beginUpdate();

                // --

                foreach (ToolBase t in mnuMenu.Tools)
                {
                    if (
                        t.Key == FMenuKey.MenuSdmExpand ||
                        t.Key == FMenuKey.MenuSdmCollapse ||
                        t.Key == FMenuKey.MenuSdmRelation
                        )
                    {
                        continue;
                    }
                    else if (
                        t.Key == FMenuKey.MenuSdmOpenSecsDevice ||
                        t.Key == FMenuKey.MenuSdmCloseSecsDevice ||
                        t.Key == FMenuKey.MenuSdmSendSecsMessage ||
                        t.Key == FMenuKey.MenuSdmCut ||
                        t.Key == FMenuKey.MenuSdmCopy ||
                        t.Key == FMenuKey.MenuSdmPasteSibling ||
                        t.Key == FMenuKey.MenuSdmPasteChild ||
                        t.Key == FMenuKey.MenuSdmPastePrimarySecsMessage ||
                        t.Key == FMenuKey.MenuSdmPasteSecondarySecsMessage ||
                        t.Key == FMenuKey.MenuSdmRemove ||
                        t.Key == FMenuKey.MenuSdmMoveUp ||
                        t.Key == FMenuKey.MenuSdmMoveDown ||
                        t.Key == FMenuKey.MenuSdmConvertToSml                        
                        )
                    {
                        t.SharedProps.Enabled = false;
                    }
                    else
                    {
                        t.SharedProps.Visible = false;
                    }
                }

                // --

                fObject = (FIObject)tvwTree.ActiveNode.Tag;
                if (fObject.fObjectType == FObjectType.SecsDriver)
                {
                    mnuMenu.Tools[FMenuKey.MenuSdmAppendSecsDevice].SharedProps.Visible = ((FSecsDriver)fObject).canAppendChildSecsDevice;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSdmPasteChild].SharedProps.Enabled = ((FSecsDriver)fObject).canPasteChildSecsDevice;
                }
                else if (fObject.fObjectType == FObjectType.SecsDevice)
                {
                    if (((FSecsDevice)fObject).fState == FDeviceState.Closed)
                    {
                        mnuMenu.Tools[FMenuKey.MenuSdmOpenSecsDevice].SharedProps.Enabled = true;
                    }
                    else
                    {
                        mnuMenu.Tools[FMenuKey.MenuSdmCloseSecsDevice].SharedProps.Enabled = true;
                    }                    
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSdmInsertBeforeSecsDevice].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuSdmInsertAfterSecsDevice].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSdmAppendSecsSession].SharedProps.Visible = fObject.canAppendChild;
                }
                else if (fObject.fObjectType == FObjectType.SecsSession)
                {
                    mnuMenu.Tools[FMenuKey.MenuSdmGemInspector].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuSdmGemInspector].SharedProps.Enabled = ((FSecsSession)fObject).hasLibrary;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSdmInsertBeforeSecsSession].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuSdmInsertAfterSecsSession].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSdmAppendSecsMessageList].SharedProps.Visible = ((FSecsSession)fObject).hasLibrary;
                }
                else if (fObject.fObjectType == FObjectType.SecsMessageList)
                {
                    mnuMenu.Tools[FMenuKey.MenuSdmResetVersion].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuSdmResetVersion].SharedProps.Enabled = fObject.hasChild;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSdmImportStandardSecsMessages].SharedProps.Visible = true;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSdmInsertBeforeSecsMessageList].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuSdmInsertAfterSecsMessageList].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSdmAppendSecsMessages].SharedProps.Visible = fObject.canAppendChild;
                }
                else if (fObject.fObjectType == FObjectType.SecsMessages)
                {
                    mnuMenu.Tools[FMenuKey.MenuSdmReplace].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuSdmInsertBeforeSecsMessages].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuSdmInsertAfterSecsMessages].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSdmAppendPrimarySecsMessage].SharedProps.Visible = ((FSecsMessages)fObject).canAppendChildPrimarySecsMessage;                    
                    if (((FSecsMessages)fObject).canAppendChildSecondarySecsMessage)
                    {
                        mnuMenu.Tools[FMenuKey.MenuSdmAppendSecondarySecsMessage].SharedProps.Visible = true;
                        // --
                        mnuMenu.Toolbars[0].Tools[FMenuKey.MenuSdmAppendSecondarySecsMessage].InstanceProps.IsFirstInGroup = !((FSecsMessages)fObject).canAppendChildPrimarySecsMessage;
                        ((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuSdmPopupMenu]).Tools[FMenuKey.MenuSdmAppendSecondarySecsMessage].InstanceProps.IsFirstInGroup = !((FSecsMessages)fObject).canAppendChildPrimarySecsMessage;                        
                    }

                    // --

                    if (((FSecsDevice)tvwTree.ActiveNode.Parent.Parent.Parent.Tag).fState == FDeviceState.Selected)
                    {
                        foreach (FSecsMessage fSmg in ((FSecsMessages)tvwTree.ActiveNode.Tag).fChildSecsMessageCollection)
                        {
                            if (fSmg.isPrimary)
                            {
                                mnuMenu.Tools[FMenuKey.MenuSdmSendSecsMessage].SharedProps.Enabled = true;
                                break;
                            }                            
                        }
                    }

                    // --

                    mnuMenu.Tools[FMenuKey.MenuSdmConvertToSml].SharedProps.Enabled = true;
                }
                else if (fObject.fObjectType == FObjectType.SecsMessage)
                {
                    if (((FSecsDevice)tvwTree.ActiveNode.Parent.Parent.Parent.Parent.Tag).fState == FDeviceState.Selected)
                    {
                        mnuMenu.Tools[FMenuKey.MenuSdmSendSecsMessage].SharedProps.Enabled = true;
                    }
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSdmReplace].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuSdmAppendSecsItem].SharedProps.Visible = fObject.canAppendChild;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSdmConvertToSml].SharedProps.Enabled = true;
                }
                else if (fObject.fObjectType == FObjectType.SecsItem)
                {
                    mnuMenu.Tools[FMenuKey.MenuSdmReplace].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuSdmInsertBeforeSecsItem].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuSdmInsertAfterSecsItem].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSdmAppendSecsItem].SharedProps.Visible = fObject.canAppendChild;
                }

                if (
                    fObject.fObjectType == FObjectType.SecsDevice ||
                    fObject.fObjectType == FObjectType.SecsSession ||
                    fObject.fObjectType == FObjectType.SecsMessageList ||
                    fObject.fObjectType == FObjectType.SecsMessages ||
                    fObject.fObjectType == FObjectType.SecsMessage ||
                    fObject.fObjectType == FObjectType.SecsItem
                    )
                {
                    mnuMenu.Tools[FMenuKey.MenuSdmPasteSibling].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuSdmPasteChild].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuSdmPastePrimarySecsMessage].SharedProps.Visible = false;
                    mnuMenu.Tools[FMenuKey.MenuSdmPasteSecondarySecsMessage].SharedProps.Visible = false;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSdmRemove].SharedProps.Enabled = fObject.canRemove;
                    //--
                    mnuMenu.Tools[FMenuKey.MenuSdmMoveUp].SharedProps.Enabled = fObject.canMoveUp;
                    mnuMenu.Tools[FMenuKey.MenuSdmMoveDown].SharedProps.Enabled = fObject.canMoveDown;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSdmCut].SharedProps.Enabled = fObject.canCut;
                    mnuMenu.Tools[FMenuKey.MenuSdmCopy].SharedProps.Enabled = fObject.canCopy;
                    mnuMenu.Tools[FMenuKey.MenuSdmPasteSibling].SharedProps.Enabled = fObject.canPasteSibling;
                    if (fObject.fObjectType == FObjectType.SecsSession)
                    {
                        mnuMenu.Tools[FMenuKey.MenuSdmPasteChild].SharedProps.Enabled =
                            ((FSecsSession)fObject).hasLibrary ? fObject.canPasteChild : false;
                    }
                    else
                    {
                        mnuMenu.Tools[FMenuKey.MenuSdmPasteChild].SharedProps.Enabled = fObject.canPasteChild;
                    }
                }

                // --

                if (fObject.fObjectType == FObjectType.SecsMessages)
                {
                    if (
                        ((FSecsMessages)fObject).canPastePrimarySecsMessage ||
                        ((FSecsMessages)fObject).canPasteSecondarySecsMessage
                        )
                    {
                        mnuMenu.Tools[FMenuKey.MenuSdmPasteSibling].SharedProps.Visible = false;
                        mnuMenu.Tools[FMenuKey.MenuSdmPasteChild].SharedProps.Visible = false;
                        mnuMenu.Tools[FMenuKey.MenuSdmPastePrimarySecsMessage].SharedProps.Visible = true;
                        mnuMenu.Tools[FMenuKey.MenuSdmPasteSecondarySecsMessage].SharedProps.Visible = true;
                    }
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSdmPastePrimarySecsMessage].SharedProps.Enabled = ((FSecsMessages)fObject).canPastePrimarySecsMessage;
                    mnuMenu.Tools[FMenuKey.MenuSdmPasteSecondarySecsMessage].SharedProps.Enabled = ((FSecsMessages)fObject).canPasteSecondarySecsMessage;
                }

                // --

                // ***
                // 2016.04.26 by spike.lee
                // Replace Menu 제어
                // ***
                //if (
                //    fObject.fObjectType == FObjectType.SecsMessages ||
                //    fObject.fObjectType == FObjectType.SecsMessage ||
                //    fObject.fObjectType == FObjectType.SecsItem
                //    )
                //{
                //    mnuMenu.Tools[FMenuKey.MenuSdmReplace].SharedProps.Enabled = true;
                //}

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

        private string createTreeId(
            string ssnUniqueId, 
            string objUniqueId
            )
        {
            try
            {
                return ssnUniqueId + "-" + objUniqueId;
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

        private string getSecsSessionId(
            string uniqueId
            )
        {
            try
            {
                return uniqueId.Substring(0, uniqueId.IndexOf("-"));
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

        private void loadTreeOfObject(
            )
        {
            FSecsDriver fScd = null;
            UltraTreeNode tNodeScd = null;
            UltraTreeNode tNodeSdv = null;
            UltraTreeNode tNodeSsn = null;
            UltraTreeNode tNodeSml = null;
            UltraTreeNode tNodeSms = null;
            UltraTreeNode tNodeSmg = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                // ***
                // SECS Driver Load
                // ***
                fScd = m_fSsmCore.fSsmFileInfo.fSecsDriver;
                tNodeScd = new UltraTreeNode(fScd.uniqueIdToString);
                tNodeScd.Tag = fScd;
                FCommon.refreshTreeNodeOfObject(fScd, tvwTree, tNodeScd);

                // --

                // ***
                // SECS Device Load
                // ***
                foreach (FSecsDevice fSdv in fScd.fChildSecsDeviceCollection)
                {
                    tNodeSdv = new UltraTreeNode(fSdv.uniqueIdToString);
                    tNodeSdv.Tag = fSdv;
                    FCommon.refreshTreeNodeOfObject(fSdv, tvwTree, tNodeSdv);

                    // --

                    // ***
                    // SECS Session Load
                    // ***
                    foreach (FSecsSession fSsn in fSdv.fChildSecsSessionCollection)
                    {
                        tNodeSsn = new UltraTreeNode(fSsn.uniqueIdToString);
                        tNodeSsn.Tag = fSsn;
                        FCommon.refreshTreeNodeOfObject(fSsn, tvwTree, tNodeSsn);

                        // --

                        // ***
                        // SECS Message List, SECS Messages, SECS Item 개체의 Tree Node ID는
                        // SECS Session 개체의 ID와 해당 개체의 ID를 조합으로 구성한다.
                        // (SecsSessionUniqueID + "-" + ObjectUniqueID)
                        // ***
                        if (fSsn.hasLibrary)
                        {
                            // ***
                            // SECS Message List Load
                            // *** 
                            foreach (FSecsMessageList fSml in fSsn.fLibrary.fChildSecsMessageListCollection)
                            {
                                tNodeSml = new UltraTreeNode(createTreeId(fSsn.uniqueIdToString, fSml.uniqueIdToString));
                                tNodeSml.Tag = fSml;
                                FCommon.refreshTreeNodeOfObject(fSml, tvwTree, tNodeSml);

                                // --

                                // ***
                                // SECS Messages Load
                                // ***
                                foreach (FSecsMessages fSms in fSml.fChildSecsMessagesCollection)
                                {
                                    tNodeSms = new UltraTreeNode(createTreeId(fSsn.uniqueIdToString, fSms.uniqueIdToString));
                                    tNodeSms.Tag = fSms;
                                    FCommon.refreshTreeNodeOfObject(fSms, tvwTree, tNodeSms);

                                    // --

                                    // ***
                                    // SECS Message Load
                                    // ***
                                    foreach (FSecsMessage fSmg in fSms.fChildSecsMessageCollection)
                                    {
                                        tNodeSmg = new UltraTreeNode(createTreeId(fSsn.uniqueIdToString, fSmg.uniqueIdToString));
                                        tNodeSmg.Tag = fSmg;
                                        FCommon.refreshTreeNodeOfObject(fSmg, tvwTree, tNodeSmg);
                                        // --
                                        tNodeSmg.Expanded = false;
                                        tNodeSms.Nodes.Add(tNodeSmg);
                                    }

                                    // --

                                    tNodeSms.Expanded = false;
                                    tNodeSml.Nodes.Add(tNodeSms);
                                }

                                // --

                                tNodeSml.Expanded = true;
                                tNodeSsn.Nodes.Add(tNodeSml);
                            }
                        }

                        // --

                        tNodeSsn.Expanded = true;
                        tNodeSdv.Nodes.Add(tNodeSsn);
                    }

                    // --

                    tNodeSdv.Expanded = true;
                    tNodeScd.Nodes.Add(tNodeSdv);
                }

                // --

                tNodeScd.Expanded = true;
                tvwTree.Nodes.Add(tNodeScd);
                tvwTree.ActiveNode = tNodeScd;

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
                fScd = null;
                tNodeScd = null;
                tNodeSdv = null;
                tNodeSsn = null;
                tNodeSml = null;
                tNodeSms = null;
                tNodeSmg = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfChildObject(
            UltraTreeNode tNodeParent
            )
        {
            FIObject fParent = null;
            UltraTreeNode tNodeChild = null;
            string ssnUniqueId = string.Empty;

            try
            {
                tvwTree.beginUpdate();

                // --

                fParent = (FIObject)tNodeParent.Tag;
                // --
                if (fParent.fObjectType == FObjectType.SecsDriver)
                {
                    foreach (FSecsDevice fSdv in ((FSecsDriver)fParent).fChildSecsDeviceCollection)
                    {
                        tNodeChild = new UltraTreeNode(fSdv.uniqueIdToString);
                        tNodeChild.Tag = fSdv;
                        FCommon.refreshTreeNodeOfObject(fSdv, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.SecsDevice)
                {
                    foreach (FSecsSession fSsn in ((FSecsDevice)fParent).fChildSecsSessionCollection)
                    {
                        tNodeChild = new UltraTreeNode(fSsn.uniqueIdToString);
                        tNodeChild.Tag = fSsn;
                        FCommon.refreshTreeNodeOfObject(fSsn, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.SecsSession)
                {
                    if (((FSecsSession)fParent).hasLibrary)
                    {
                        ssnUniqueId = ((FSecsSession)fParent).uniqueIdToString;
                        foreach (FSecsMessageList fSml in (((FSecsSession)fParent).fLibrary.fChildSecsMessageListCollection))
                        {
                            tNodeChild = new UltraTreeNode(createTreeId(ssnUniqueId, fSml.uniqueIdToString));
                            tNodeChild.Tag = fSml;
                            FCommon.refreshTreeNodeOfObject(fSml, tvwTree, tNodeChild);
                            tNodeParent.Nodes.Add(tNodeChild);
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.SecsMessageList)
                {
                    ssnUniqueId = getSecsSessionId(tNodeParent.Key);
                    foreach (FSecsMessages fSms in ((FSecsMessageList)fParent).fChildSecsMessagesCollection)
                    {
                        tNodeChild = new UltraTreeNode(createTreeId(ssnUniqueId, fSms.uniqueIdToString));
                        tNodeChild.Tag = fSms;
                        FCommon.refreshTreeNodeOfObject(fSms, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.SecsMessages)
                {
                    ssnUniqueId = getSecsSessionId(tNodeParent.Key);
                    foreach (FSecsMessage fSmg in ((FSecsMessages)fParent).fChildSecsMessageCollection)
                    {
                        tNodeChild = new UltraTreeNode(createTreeId(ssnUniqueId, fSmg.uniqueIdToString));
                        tNodeChild.Tag = fSmg;
                        FCommon.refreshTreeNodeOfObject(fSmg, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.SecsMessage)
                {
                    ssnUniqueId = getSecsSessionId(tNodeParent.Key);
                    foreach (FSecsItem fSit in ((FSecsMessage)fParent).fChildSecsItemCollection)
                    {
                        tNodeChild = new UltraTreeNode(createTreeId(ssnUniqueId, fSit.uniqueIdToString));
                        tNodeChild.Tag = fSit;
                        FCommon.refreshTreeNodeOfObject(fSit, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.SecsItem)
                {
                    ssnUniqueId = getSecsSessionId(tNodeParent.Key);
                    foreach (FSecsItem fSit in ((FSecsItem)fParent).fChildSecsItemCollection)
                    {
                        tNodeChild = new UltraTreeNode(createTreeId(ssnUniqueId, fSit.uniqueIdToString));
                        tNodeChild.Tag = fSit;
                        FCommon.refreshTreeNodeOfObject(fSit, tvwTree, tNodeChild);
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

        private void addTreeOfObject(
            FIObject fParent,
            FIObject fNewChild
            )
        {
            FIObject fRefChild = null;
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeNewChild = null;
            UltraTreeNode tNodeRefChild = null;

            try
            {
                tNodeNewChild = tvwTree.GetNodeByKey(fNewChild.uniqueIdToString);
                if (tNodeNewChild != null)
                {
                    return;
                }

                // --

                if (fNewChild.fObjectType == FObjectType.SecsDevice)
                {
                    tNodeParent = tvwTree.GetNodeByKey(fParent.uniqueIdToString);                  
                    fRefChild = ((FSecsDevice)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.SecsSession)
                {
                    tNodeParent = tvwTree.GetNodeByKey(fParent.uniqueIdToString);
                    if (
                        tNodeParent == null ||
                        (!tNodeParent.Parent.Expanded && tNodeParent.Nodes.Count == 0)
                        )
                    {
                        if (tNodeParent != null && tNodeParent.Expanded)
                        {
                            tNodeParent.Expanded = false;
                        }
                        return;
                    }
                    fRefChild = ((FSecsSession)fNewChild).fNextSibling;
                }               
                else
                {
                    return;
                }

                // --

                tvwTree.beginUpdate();

                // --

                tNodeNewChild = new UltraTreeNode(fNewChild.uniqueIdToString);
                tNodeNewChild.Tag = fNewChild;
                FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNodeNewChild);

                // --

                if (fRefChild != null)
                {
                    tNodeRefChild = tvwTree.GetNodeByKey(fRefChild.uniqueIdToString);
                }
                // --
                if (tNodeRefChild != null)
                {
                    tNodeParent.Nodes.Insert(tNodeRefChild.Index, tNodeNewChild);
                }
                else
                {
                    tNodeParent.Nodes.Add(tNodeNewChild);
                }

                // --

                loadTreeOfChildObject(tNodeNewChild);

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fRefChild = null;
                tNodeParent = null;
                tNodeNewChild = null;
                tNodeRefChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void addTreeOfObject2(
            FIObject fParent,
            FIObject fNewChild
            )
        {
            FSecsLibrary fSlb = null;
            FIObject fRefChild = null;            
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeNewChild = null;
            UltraTreeNode tNodeRefChild = null;
            string uniqueId = string.Empty;

            try
            {
                if (fNewChild.fObjectType == FObjectType.SecsMessageList)
                {
                    fSlb = ((FSecsMessageList)fNewChild).fAncestorSecsLibrary;
                }
                else if (fNewChild.fObjectType == FObjectType.SecsMessages)
                {
                    fSlb = ((FSecsMessages)fNewChild).fAncestorSecsLibrary;
                }
                else if (fNewChild.fObjectType == FObjectType.SecsMessage)
                {
                    fSlb = ((FSecsMessage)fNewChild).fAncestorSecsLibrary;
                }
                else if (fNewChild.fObjectType == FObjectType.SecsItem)
                {
                    fSlb = ((FSecsItem)fNewChild).fAncestorSecsLibrary;
                }
                else
                {
                    return;
                }

                // --

                tvwTree.beginUpdate();

                // --

                foreach (FSecsDevice fSdv in this.m_fSsmCore.fSsmFileInfo.fSecsDriver.fChildSecsDeviceCollection)
                {
                    foreach (FSecsSession fSsn in fSdv.fChildSecsSessionCollection)
                    {
                        if (fSsn.fLibrary != fSlb)
                        {
                            continue;
                        }

                        // --

                        uniqueId = createTreeId(fSsn.uniqueIdToString, fNewChild.uniqueIdToString);
                        tNodeNewChild = tvwTree.GetNodeByKey(uniqueId);
                        if (tNodeNewChild != null)
                        {
                            continue;
                        }

                        // --

                        if (fNewChild.fObjectType == FObjectType.SecsMessageList)
                        {
                            tNodeParent = tvwTree.GetNodeByKey(fSsn.uniqueIdToString);
                            if (
                                tNodeParent == null ||
                                (!tNodeParent.Parent.Expanded && tNodeParent.Nodes.Count == 0)
                                )
                            {
                                if (tNodeParent != null && tNodeParent.Expanded)
                                {
                                    tNodeParent.Expanded = false;
                                }
                                continue;
                            }                       
                            fRefChild = ((FSecsMessageList)fNewChild).fNextSibling;
                        }
                        else if (fNewChild.fObjectType == FObjectType.SecsMessages)
                        {   
                            tNodeParent = tvwTree.GetNodeByKey(createTreeId(fSsn.uniqueIdToString, fParent.uniqueIdToString));
                            if (
                                tNodeParent == null ||
                                (!tNodeParent.Parent.Expanded && tNodeParent.Nodes.Count == 0)
                                )
                            {
                                if (tNodeParent != null && tNodeParent.Expanded)
                                {
                                    tNodeParent.Expanded = false;
                                }                                
                                continue;
                            }
                            fRefChild = ((FSecsMessages)fNewChild).fNextSibling;
                        }
                        else if (fNewChild.fObjectType == FObjectType.SecsMessage)
                        {
                            tNodeParent = tvwTree.GetNodeByKey(createTreeId(fSsn.uniqueIdToString, fParent.uniqueIdToString));
                            if (
                                tNodeParent == null ||
                                (!tNodeParent.Parent.Expanded && tNodeParent.Nodes.Count == 0)
                                )
                            {
                                if (tNodeParent != null && tNodeParent.Expanded)
                                {
                                    tNodeParent.Expanded = false;
                                }
                                continue;
                            }
                            fRefChild = ((FSecsMessage)fNewChild).fNextSibling;
                        }
                        else if (fNewChild.fObjectType == FObjectType.SecsItem)
                        {
                            tNodeParent = tvwTree.GetNodeByKey(createTreeId(fSsn.uniqueIdToString, fParent.uniqueIdToString));
                            if (
                                tNodeParent == null ||
                                (!tNodeParent.Parent.Expanded && tNodeParent.Nodes.Count == 0)
                                )
                            {
                                if (tNodeParent != null && tNodeParent.Expanded)
                                {
                                    tNodeParent.Expanded = false;
                                }
                                continue;
                            }
                            fRefChild = ((FSecsItem)fNewChild).fNextSibling;
                        }

                        // --

                        tNodeNewChild = new UltraTreeNode(uniqueId);
                        tNodeNewChild.Tag = fNewChild;
                        FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNodeNewChild);

                        // --

                        if (fRefChild != null)
                        {
                            tNodeRefChild = tvwTree.GetNodeByKey(createTreeId(fSsn.uniqueIdToString, fRefChild.uniqueIdToString));
                        }
                        else
                        {
                            tNodeRefChild = null;
                        }
                        // --
                        if (tNodeRefChild != null)
                        {
                            tNodeParent.Nodes.Insert(tNodeRefChild.Index, tNodeNewChild);
                        }
                        else
                        {
                            tNodeParent.Nodes.Add(tNodeNewChild);
                        }

                        // --

                        loadTreeOfChildObject(tNodeNewChild);
                    }
                }       
         
                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fSlb = null;
                fRefChild = null;
                tNodeParent = null;
                tNodeNewChild = null;
                tNodeRefChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void removeTreeOfObject(
            FIObject fChild
            )
        {
            UltraTreeNode tNodeChild = null;

            try
            {
                tNodeChild = tvwTree.GetNodeByKey(fChild.uniqueIdToString);
                if (tNodeChild == null)
                {
                    return;
                }

                // --

                tvwTree.beginUpdate();
                tNodeChild.Remove();
                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void removeTreeOfObject2(
            FIObject fChild
            )
        {
            UltraTreeNode tNodeChild = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                foreach (FSecsDevice fSdv in this.m_fSsmCore.fSsmFileInfo.fSecsDriver.fChildSecsDeviceCollection)
                {
                    foreach (FSecsSession fSsn in fSdv.fChildSecsSessionCollection)
                    {
                        tNodeChild = tvwTree.GetNodeByKey(createTreeId(fSsn.uniqueIdToString, fChild.uniqueIdToString));
                        if (tNodeChild == null)
                        {
                            continue;
                        }

                        // --
                        
                        tNodeChild.Remove();                        
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
                tNodeChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void moveUpTreeOfObject(
            FIObject fObject
            )
        {
            UltraTreeNode tNode = null;
            UltraTreeNode tPrevNode = null;

            try
            {
                tNode = tvwTree.GetNodeByKey(fObject.uniqueIdToString);
                if (tNode == null)
                {
                    return;
                }
                tPrevNode = tNode.GetSibling(NodePosition.Previous);

                // --

                if (fObject.fObjectType == FObjectType.SecsDevice)
                {
                    if (((FSecsDevice)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FSecsDevice)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.SecsSession)
                {
                    if (((FSecsSession)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FSecsSession)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else
                {
                    return;
                }
                
                // --

                tvwTree.beginUpdate();
                tvwTree.moveUpNode(tNode);
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
                tPrevNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void moveUpTreeOfObject2(
            FIObject fObject
            )
        {
            UltraTreeNode tNode = null;
            UltraTreeNode tPrevNode = null;

            try
            {
                tvwTree.beginUpdate();
                
                // --

                foreach (FSecsDevice fSdv in this.m_fSsmCore.fSsmFileInfo.fSecsDriver.fChildSecsDeviceCollection)
                {
                    foreach (FSecsSession fSsn in fSdv.fChildSecsSessionCollection)
                    {
                        tNode = tvwTree.GetNodeByKey(createTreeId(fSsn.uniqueIdToString, fObject.uniqueIdToString));
                        if (tNode == null)
                        {
                            continue;
                        }
                        tPrevNode = tNode.GetSibling(NodePosition.Previous);

                        // --

                        if (fObject.fObjectType == FObjectType.SecsDevice)
                        {
                            if (((FSecsDevice)fObject).fPreviousSibling == null)
                            {
                                if (tPrevNode == null)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                if (((FSecsDevice)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                                {
                                    continue;
                                }
                            }
                        }
                        else if (fObject.fObjectType == FObjectType.SecsSession)
                        {
                            if (((FSecsSession)fObject).fPreviousSibling == null)
                            {
                                if (tPrevNode == null)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                if (((FSecsSession)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                                {
                                    continue;
                                }
                            }
                        }
                        else if (fObject.fObjectType == FObjectType.SecsMessageList)
                        {
                            if (((FSecsMessageList)fObject).fPreviousSibling == null)
                            {
                                if (tPrevNode == null)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                if (((FSecsMessageList)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                                {
                                    continue;
                                }
                            }
                        }
                        else if (fObject.fObjectType == FObjectType.SecsMessages)
                        {
                            if (((FSecsMessages)fObject).fPreviousSibling == null)
                            {
                                if (tPrevNode == null)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                if (((FSecsMessages)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                                {
                                    continue;
                                }
                            }
                        }
                        else if (fObject.fObjectType == FObjectType.SecsMessage)
                        {
                            if (((FSecsMessage)fObject).fPreviousSibling == null)
                            {
                                if (tPrevNode == null)
                                {
                                    return;
                                }
                            }
                            else
                            {
                                if (((FSecsMessage)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                                {
                                    continue;
                                }
                            }
                        }
                        else if (fObject.fObjectType == FObjectType.SecsItem)
                        {
                            if (((FSecsItem)fObject).fPreviousSibling == null)
                            {
                                if (tPrevNode == null)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                if (((FSecsItem)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                                {
                                    continue;
                                }
                            }
                        }

                        // --

                        tvwTree.moveUpNode(tNode);    
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
                tNode = null;
                tPrevNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void moveDownTreeOfObject(
            FIObject fObject
            )
        {
            UltraTreeNode tNode = null;
            UltraTreeNode tNextNode = null;

            try
            {
                tNode = tvwTree.GetNodeByKey(fObject.uniqueIdToString);
                if (tNode == null)
                {
                    return;
                }
                tNextNode = tNode.GetSibling(NodePosition.Next);

                // --

                if (fObject.fObjectType == FObjectType.SecsDevice)
                {
                    if (((FSecsDevice)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FSecsDevice)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.SecsSession)
                {
                    if (((FSecsSession)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FSecsSession)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else
                {
                    return;
                } 

                // -- 

                tvwTree.beginUpdate();
                tvwTree.moveDownNode(tNode);
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
                tNextNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void moveToTreeOfObject(
            FIObject fObject,
            FIObject fRefObject
            )
        {   
            UltraTreeNode tRefNode = null;
            UltraTreeNode tNode = null;

            try
            {   
                tvwTree.beginUpdate();
                
                // --                

                tRefNode = tvwTree.GetNodeByKey(fRefObject.uniqueIdToString);
                tNode = tvwTree.GetNodeByKey(fObject.uniqueIdToString);

                // --

                if (tRefNode == null)
                {                    
                    if (tNode != null)
                    {
                        tNode.Remove();
                    }
                }
                else
                {
                    if (tNode != null)
                    {
                        if (fRefObject.fObjectType == fObject.fObjectType)
                        {
                            if (tRefNode.Parent != tNode.Parent || tRefNode.Index != tNode.Index - 1)
                            {
                                tNode.Remove();
                                tNode = null;
                            }
                        }
                        else
                        {
                            if (tRefNode.Nodes.Count == 0 || tRefNode.Nodes[tRefNode.Nodes.Count - 1] != tNode)
                            {
                                tNode.Remove();
                                tNode = null;
                            }  
                        }
                    }    
                    // --
                    if (tNode == null)
                    {
                        tNode = new UltraTreeNode(fObject.uniqueIdToString);
                        tNode.Tag = fObject;
                        FCommon.refreshTreeNodeOfObject(fObject, tvwTree, tNode);   
                     
                        // --

                        if (fRefObject.fObjectType == fObject.fObjectType)
                        {
                            tRefNode.Parent.Nodes.Insert(tRefNode.Index + 1, tNode);
                            loadTreeOfChildObject(tNode);
                        }
                        else
                        {
                            if (tRefNode.Nodes.Count == 0)
                            {
                                loadTreeOfChildObject(tRefNode);
                                // --
                                if (tRefNode.Nodes.Exists(tNode.Key))
                                {
                                    tNode = tRefNode.Nodes[tNode.Key];
                                    loadTreeOfChildObject(tNode);
                                }
                                // --
                                tRefNode.Expanded = false;
                            }
                            else
                            {
                                tRefNode.Nodes.Add(tNode);
                                loadTreeOfChildObject(tNode);
                            }
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
                tRefNode = null;
                tNode = null;                
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void moveToTreeOfObject2(
            FIObject fObject,
            FIObject fRefObject
            )
        {
            FSecsLibrary fSlb = null;
            UltraTreeNode tRefNode = null;
            UltraTreeNode tNode = null;

            try
            {
                if (fObject.fObjectType == FObjectType.SecsMessageList)
                {
                    fSlb = ((FSecsMessageList)fObject).fAncestorSecsLibrary;
                }
                else if (fObject.fObjectType == FObjectType.SecsMessages)
                {
                    fSlb = ((FSecsMessages)fObject).fAncestorSecsLibrary;
                }
                else if (fObject.fObjectType == FObjectType.SecsMessage)
                {
                    fSlb = ((FSecsMessage)fObject).fAncestorSecsLibrary;
                }
                else if (fObject.fObjectType == FObjectType.SecsItem)
                {
                    fSlb = ((FSecsItem)fObject).fAncestorSecsLibrary;
                }
                else
                {
                    return;
                }

                // --

                tvwTree.beginUpdate();

                // --

                foreach (FSecsDevice fSdv in this.m_fSsmCore.fSsmFileInfo.fSecsDriver.fChildSecsDeviceCollection)
                {
                    foreach (FSecsSession fSsn in fSdv.fChildSecsSessionCollection)
                    {
                        if (fSsn.fLibrary != fSlb)
                        {
                            continue;
                        }

                        // --

                        if (fRefObject.fObjectType == FObjectType.SecsLibrary)
                        {
                            tRefNode = tvwTree.GetNodeByKey(fSsn.uniqueIdToString);
                        }
                        else
                        {
                            tRefNode = tvwTree.GetNodeByKey(createTreeId(fSsn.uniqueIdToString, fRefObject.uniqueIdToString));
                        }
                        tNode = tvwTree.GetNodeByKey(createTreeId(fSsn.uniqueIdToString, fObject.uniqueIdToString));

                        // --

                        if (tRefNode == null)
                        {
                            if (tNode != null)
                            {
                                tNode.Remove();
                            }
                        }
                        else
                        {
                            if (tNode != null)
                            {
                                if (fRefObject.fObjectType == fObject.fObjectType)
                                {
                                    if (tRefNode.Parent != tNode.Parent || tRefNode.Index != tNode.Index - 1)
                                    {
                                        tNode.Remove();
                                        tNode = null;
                                    }
                                }
                                else
                                {
                                    if (tRefNode.Nodes.Count == 0 || tRefNode.Nodes[tRefNode.Nodes.Count - 1] != tNode)
                                    {
                                        tNode.Remove();
                                        tNode = null;
                                    }  
                                }
                            }
                            // --
                            if (tNode == null)
                            {
                                tNode = new UltraTreeNode(createTreeId(fSsn.uniqueIdToString, fObject.uniqueIdToString));
                                tNode.Tag = fObject;
                                FCommon.refreshTreeNodeOfObject(fObject, tvwTree, tNode);

                                // --

                                if (fRefObject.fObjectType == fObject.fObjectType)
                                {
                                    tRefNode.Parent.Nodes.Insert(tRefNode.Index + 1, tNode);
                                    loadTreeOfChildObject(tNode);
                                }
                                else
                                {
                                    if (tRefNode.Nodes.Count == 0)
                                    {
                                        loadTreeOfChildObject(tRefNode);
                                        // --
                                        if (tRefNode.Nodes.Exists(tNode.Key))
                                        {
                                            tNode = tRefNode.Nodes[tNode.Key];
                                            loadTreeOfChildObject(tNode);
                                        }  
                                    }
                                    else
                                    {
                                        tRefNode.Nodes.Add(tNode);
                                        loadTreeOfChildObject(tNode);
                                    }
                                }  
                            }
                        }
                    }
                }

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fSlb = null;
                tRefNode = null;
                tNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void moveDownTreeOfObject2(
            FIObject fObject
            )
        {
            UltraTreeNode tNode = null;
            UltraTreeNode tNextNode = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                foreach (FSecsDevice fSdv in this.m_fSsmCore.fSsmFileInfo.fSecsDriver.fChildSecsDeviceCollection)
                {
                    foreach (FSecsSession fSsn in fSdv.fChildSecsSessionCollection)
                    {

                        tNode = tvwTree.GetNodeByKey(createTreeId(fSsn.uniqueIdToString, fObject.uniqueIdToString));
                        if (tNode == null)
                        {
                            continue;
                        }
                        tNextNode = tNode.GetSibling(NodePosition.Next);

                        // --

                        if (fObject.fObjectType == FObjectType.SecsDevice)
                        {
                            if (((FSecsDevice)fObject).fNextSibling == null)
                            {
                                if (tNextNode == null)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                if (((FSecsDevice)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                                {
                                    continue;
                                }
                            }
                        }
                        else if (fObject.fObjectType == FObjectType.SecsSession)
                        {
                            if (((FSecsSession)fObject).fNextSibling == null)
                            {
                                if (tNextNode == null)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                if (((FSecsSession)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                                {
                                    continue;
                                }
                            }
                        }
                        else if (fObject.fObjectType == FObjectType.SecsMessageList)
                        {
                            if (((FSecsMessageList)fObject).fNextSibling == null)
                            {
                                if (tNextNode == null)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                if (((FSecsMessageList)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                                {
                                    continue;
                                }
                            }
                        }
                        else if (fObject.fObjectType == FObjectType.SecsMessages)
                        {
                            if (((FSecsMessages)fObject).fNextSibling == null)
                            {
                                if (tNextNode == null)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                if (((FSecsMessages)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                                {
                                    continue;
                                }
                            }
                        }
                        else if (fObject.fObjectType == FObjectType.SecsMessage)
                        {
                            if (((FSecsMessage)fObject).fNextSibling == null)
                            {
                                if (tNextNode == null)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                if (((FSecsMessage)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                                {
                                    continue;
                                }
                            }
                        }
                        else if (fObject.fObjectType == FObjectType.SecsItem)
                        {
                            if (((FSecsItem)fObject).fNextSibling == null)
                            {
                                if (tNextNode == null)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                if (((FSecsItem)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                                {
                                    continue;
                                }
                            }
                        }

                        // --

                        tvwTree.moveDownNode(tNode);
                    }
                }

                // -- 
                
                tvwTree.endUpdate();

                // --

                //controlMenu();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
                tNextNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshObject(
            FIObject fObject
            )
        {
            UltraTreeNode tNode = null;

            try
            {
                tNode = tvwTree.GetNodeByKey(fObject.uniqueIdToString);
                if (tNode == null)
                {
                    return;
                }

                // --

                if (tNode.IsActive && !pgdProp.Focused)
                {
                    pgdProp.onDynPropGridRefreshRequested();
                }
                // --

                tvwTree.beginUpdate();
                FCommon.refreshTreeNodeOfObject(fObject, tvwTree, tNode);
                tvwTree.endUpdate();

                // --

                controlMenu();                
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

        private void refreshObject2(
            FIObject fObject
            )
        {
            UltraTreeNode tNode = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                foreach (FSecsDevice fSdv in this.m_fSsmCore.fSsmFileInfo.fSecsDriver.fChildSecsDeviceCollection)
                {
                    foreach (FSecsSession fSsn in fSdv.fChildSecsSessionCollection)
                    {
                        tNode = tvwTree.GetNodeByKey(createTreeId(fSsn.uniqueIdToString, fObject.uniqueIdToString));
                        if (tNode == null)
                        {
                            continue;
                        }

                        // --

                        if (tNode.IsActive && !pgdProp.Focused)
                        {
                            pgdProp.onDynPropGridRefreshRequested();
                        }

                        // --

                        FCommon.refreshTreeNodeOfObject(fObject, tvwTree, tNode);
                    }
                }               

                // --
                
                tvwTree.endUpdate();

                // --

                controlMenu();
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

        private void changeSecsSessionLibrary(
            FSecsSession fSsn
            )
        {
            UltraTreeNode tNodeSsn = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                tNodeSsn = tvwTree.GetNodeByKey(fSsn.uniqueIdToString);
                tNodeSsn.Expanded = false;
                tNodeSsn.Nodes.Clear();                

                // --

                if (fSsn.hasLibrary)
                {
                    loadTreeOfChildObject(tNodeSsn);
                    
                    // --
                    tNodeSsn.Expanded = true;
                    foreach (UltraTreeNode tNodeSml in tNodeSsn.Nodes)
                    {
                        tNodeSml.Expanded = true;                        
                        foreach (UltraTreeNode tNodeSms in tNodeSml.Nodes)
                        {
                            tNodeSms.Expanded = false;
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
                tNodeSsn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuAppendObject(
            string menuKey
            )
        {
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeNewChild = null;
            FIObject fParent = null;
            FIObject fNewChild = null;
            string uniqueId = string.Empty;

            try
            {
                tvwTree.beginUpdate();

                // --

                tNodeParent = tvwTree.ActiveNode;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                if (fParent.fObjectType == FObjectType.SecsDriver)
                {
                    fNewChild = ((FSecsDriver)fParent).appendChildSecsDevice(new FSecsDevice(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                    uniqueId = fNewChild.uniqueIdToString;
                }
                else if (fParent.fObjectType == FObjectType.SecsDevice)
                {
                    fNewChild = ((FSecsDevice)fParent).appendChildSecsSession(new FSecsSession(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                    uniqueId = fNewChild.uniqueIdToString;
                }
                else if (fParent.fObjectType == FObjectType.SecsSession)
                {
                    fNewChild = ((FSecsSession)fParent).fLibrary.appendChildSecsMessageList(new FSecsMessageList(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                    uniqueId = createTreeId(tNodeParent.Key, fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.SecsMessageList)
                {
                    fNewChild = ((FSecsMessageList)fParent).appendChildSecsMessages(new FSecsMessages(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                    uniqueId = createTreeId(getSecsSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.SecsMessages)
                {
                    if (menuKey == FMenuKey.MenuSdmAppendPrimarySecsMessage)
                    {
                        fNewChild = ((FSecsMessages)fParent).appendChildPrimarySecsMessage(new FSecsMessage(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                    }
                    else
                    {
                        fNewChild = ((FSecsMessages)fParent).appendChildSecondarySecsMessage(new FSecsMessage(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                    }
                    uniqueId = createTreeId(getSecsSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.SecsMessage)
                {
                    fNewChild = ((FSecsMessage)fParent).appendChildSecsItem(new FSecsItem(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                    uniqueId = createTreeId(getSecsSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.SecsItem)
                {
                    fNewChild = new FSecsItem(this.m_fSsmCore.fSsmFileInfo.fSecsDriver);
                    if (((FSecsItem)fParent).fFormat == FFormat.AsciiList)
                    {
                        ((FSecsItem)fNewChild).fFormat = FFormat.Ascii;
                    }
                    fNewChild = ((FSecsItem)fParent).appendChildSecsItem((FSecsItem)fNewChild);
                    uniqueId = createTreeId(getSecsSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }

                // --

                tNodeNewChild = new UltraTreeNode(uniqueId);
                tNodeNewChild.Tag = fNewChild;
                FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNodeNewChild);
                // --
                if (fParent.fObjectType == FObjectType.SecsMessages)
                {
                    if (((FSecsMessage)fNewChild).isPrimary)
                    {
                        tNodeParent.Nodes.Insert(0, tNodeNewChild);
                    }
                    else
                    {
                        tNodeParent.Nodes.Add(tNodeNewChild);
                    }
                }
                else
                {
                    tNodeParent.Nodes.Add(tNodeNewChild);
                }
                // --
                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tNodeNewChild;

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
                tNodeParent = null;
                tNodeNewChild = null;
                fParent = null;
                fNewChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuInsertBeforeObject(
            string menuKey
            )
        {
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeRefChild = null;
            UltraTreeNode tNodeNewChild = null;
            FIObject fParent = null;
            FIObject fRefChild = null;
            FIObject fNewChild = null;
            string uniqueId = string.Empty;

            try
            {
                tvwTree.beginUpdate();

                // --

                tNodeRefChild = tvwTree.ActiveNode;
                tNodeParent = tNodeRefChild.Parent;
                fRefChild = (FIObject)tNodeRefChild.Tag;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                if (fParent.fObjectType == FObjectType.SecsDriver)
                {
                    fNewChild = ((FSecsDriver)fParent).insertBeforeChildSecsDevice(
                        new FSecsDevice(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FSecsDevice)fRefChild
                        );
                    uniqueId = fNewChild.uniqueIdToString;
                }
                else if (fParent.fObjectType == FObjectType.SecsDevice)
                {
                    fNewChild = ((FSecsDevice)fParent).insertBeforeChildSecsSession(
                        new FSecsSession(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FSecsSession)fRefChild
                        );
                    uniqueId = fNewChild.uniqueIdToString;
                }
                else if (fParent.fObjectType == FObjectType.SecsSession)
                {
                    fNewChild = ((FSecsSession)fParent).fLibrary.insertBeforeChildSecsMessageList(
                        new FSecsMessageList(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FSecsMessageList)fRefChild
                        );
                    uniqueId = createTreeId(tNodeParent.Key, fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.SecsMessageList)
                {
                    fNewChild = ((FSecsMessageList)fParent).insertBeforeChildSecsMessages(
                        new FSecsMessages(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FSecsMessages)fRefChild
                        );
                    uniqueId = createTreeId(getSecsSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.SecsMessages)
                {
                    // ***
                    // 사용안함.
                    // ***
                }
                else if (fParent.fObjectType == FObjectType.SecsMessage)
                {
                    // ***
                    // 사용안함.
                    // ***
                }
                else if (fParent.fObjectType == FObjectType.SecsItem)
                {
                    fNewChild = new FSecsItem(this.m_fSsmCore.fSsmFileInfo.fSecsDriver);
                    if (((FSecsItem)fParent).fFormat == FFormat.AsciiList)
                    {
                        ((FSecsItem)fNewChild).fFormat = FFormat.Ascii;
                    }
                    fNewChild = ((FSecsItem)fParent).insertBeforeChildSecsItem((FSecsItem)fNewChild, (FSecsItem)fRefChild);
                    uniqueId = createTreeId(getSecsSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }

                // --

                tNodeNewChild = new UltraTreeNode(uniqueId);
                tNodeNewChild.Tag = fNewChild;
                FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNodeNewChild);
                tNodeParent.Nodes.Insert(tNodeRefChild.Index, tNodeNewChild);
                // --
                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tNodeNewChild;

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
                tNodeParent = null;
                tNodeRefChild = null;
                tNodeNewChild = null;
                fParent = null;
                fRefChild = null;
                fNewChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuInsertAfterObject(
            string menuKey
            )
        {
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeRefChild = null;
            UltraTreeNode tNodeNewChild = null;
            FIObject fParent = null;
            FIObject fRefChild = null;
            FIObject fNewChild = null;
            string uniqueId = string.Empty;

            try
            {
                tvwTree.beginUpdate();

                // --

                tNodeRefChild = tvwTree.ActiveNode;
                tNodeParent = tNodeRefChild.Parent;
                fRefChild = (FIObject)tNodeRefChild.Tag;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                if (fParent.fObjectType == FObjectType.SecsDriver)
                {
                    fNewChild = ((FSecsDriver)fParent).insertAfterChildSecsDevice(
                        new FSecsDevice(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FSecsDevice)fRefChild
                        );
                    uniqueId = fNewChild.uniqueIdToString;
                }
                else if (fParent.fObjectType == FObjectType.SecsDevice)
                {
                    fNewChild = ((FSecsDevice)fParent).insertAfterChildSecsSession(
                        new FSecsSession(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FSecsSession)fRefChild
                        );
                    uniqueId = fNewChild.uniqueIdToString;
                }
                else if (fParent.fObjectType == FObjectType.SecsSession)
                {
                    fNewChild = ((FSecsSession)fParent).fLibrary.insertAfterChildSecsMessageList(
                        new FSecsMessageList(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FSecsMessageList)fRefChild
                        );
                    uniqueId = createTreeId(tNodeParent.Key, fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.SecsMessageList)
                {
                    fNewChild = ((FSecsMessageList)fParent).insertAfterChildSecsMessages(
                        new FSecsMessages(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FSecsMessages)fRefChild
                        );
                    uniqueId = createTreeId(getSecsSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.SecsMessages)
                {
                    // ***
                    // 사용안함.
                    // ***
                }
                else if (fParent.fObjectType == FObjectType.SecsMessage)
                {
                    // ***
                    // 사용안함.
                    // ***
                }
                else if (fParent.fObjectType == FObjectType.SecsItem)
                {
                    fNewChild = new FSecsItem(this.m_fSsmCore.fSsmFileInfo.fSecsDriver);
                    if (((FSecsItem)fParent).fFormat == FFormat.AsciiList)
                    {
                        ((FSecsItem)fNewChild).fFormat = FFormat.Ascii;
                    }
                    fNewChild = ((FSecsItem)fParent).insertAfterChildSecsItem((FSecsItem)fNewChild, (FSecsItem)fRefChild);
                    uniqueId = createTreeId(getSecsSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }

                // --

                tNodeNewChild = new UltraTreeNode(uniqueId);
                tNodeNewChild.Tag = fNewChild;
                FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNodeNewChild);
                tNodeParent.Nodes.Insert(tNodeRefChild.Index + 1, tNodeNewChild);
                // --
                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tNodeNewChild;

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
                tNodeParent = null;
                tNodeRefChild = null;
                tNodeNewChild = null;
                fParent = null;
                fRefChild = null;
                fNewChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuRemoveObject(
            )
        {
            UltraTreeNode tNodeParent = null;
            FIObject fParent = null;
            FIObject fChild = null;
            FIObject[] fChilds = null;
            DialogResult dialogResult;
            string ssnUniqueId = string.Empty;

            try
            {
                tvwTree.ActiveNode.Selected = true;
                tNodeParent = tvwTree.ActiveNode.Parent;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                // ***
                // Removing SECS Object Validate
                // ***
                if (fParent.fObjectType == FObjectType.SecsDriver)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FSecsDevice)fChild).locked)
                        {
                            FDebug.throwFException(m_fSsmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.SecsDevice)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FSecsSession)fChild).locked)
                        {
                            FDebug.throwFException(m_fSsmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.SecsSession)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FSecsMessageList)fChild).locked)
                        {
                            FDebug.throwFException(m_fSsmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.SecsMessageList)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FSecsMessages)fChild).locked)
                        {
                            FDebug.throwFException(m_fSsmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.SecsMessages)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FSecsMessage)fChild).locked)
                        {
                            FDebug.throwFException(m_fSsmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.SecsMessage)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FSecsItem)fChild).locked)
                        {
                            FDebug.throwFException(m_fSsmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.SecsItem)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FSecsItem)fChild).locked)
                        {
                            FDebug.throwFException(m_fSsmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }

                // --

                // ***
                // Remove SECS Object가 1개 이상일 경우 사용자에게 Confirm를 받는다.
                // ***
                if (tvwTree.SelectedNodes.Count > 1)
                {
                    dialogResult = FMessageBox.showQuestion(
                        FConstants.ApplicationName,
                        m_fSsmCore.fWsmCore.fUIWizard.generateMessage("Q0004", new object[] { "Object" }),
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button2,
                        m_fSsmCore.fWsmCore.fWsmContainer
                        );
                    if (dialogResult == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                }

                // --

                // ***
                // SECS Object Remove
                // ***
                if (fParent.fObjectType == FObjectType.SecsDriver)
                {
                    fChilds = new FSecsDevice[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FSecsDevice)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FSecsDriver)fParent).removeChildSecsDevice((FSecsDevice[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.SecsDevice)
                {
                    fChilds = new FSecsSession[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FSecsSession)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FSecsDevice)fParent).removeChildSecsSession((FSecsSession[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.SecsSession)
                {
                    fChilds = new FSecsMessageList[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FSecsMessageList)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FSecsSession)fParent).fLibrary.removeChildSecsMessageList((FSecsMessageList[])fChilds);
                    ssnUniqueId = tNodeParent.Key;
                }
                else if (fParent.fObjectType == FObjectType.SecsMessageList)
                {
                    fChilds = new FSecsMessages[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FSecsMessages)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FSecsMessageList)fParent).removeChildSecsMessages((FSecsMessages[])fChilds);
                    ssnUniqueId = getSecsSessionId(tNodeParent.Key);
                }
                else if (fParent.fObjectType == FObjectType.SecsMessages)
                {
                    fChilds = new FSecsMessage[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FSecsMessage)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FSecsMessages)fParent).removeChildSecsMessage((FSecsMessage[])fChilds);
                    ssnUniqueId = getSecsSessionId(tNodeParent.Key);
                }
                else if (fParent.fObjectType == FObjectType.SecsMessage)
                {
                    fChilds = new FSecsItem[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FSecsItem)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FSecsMessage)fParent).removeChildSecsItem((FSecsItem[])fChilds);
                    ssnUniqueId = getSecsSessionId(tNodeParent.Key);
                }
                else if (fParent.fObjectType == FObjectType.SecsItem)
                {
                    fChilds = new FSecsItem[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FSecsItem)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FSecsItem)fParent).removeChildSecsItem((FSecsItem[])fChilds);
                    ssnUniqueId = getSecsSessionId(tNodeParent.Key);
                }

                // --

                tvwTree.beginUpdate();

                // --

                if (ssnUniqueId == string.Empty)
                {
                    foreach (FIObject f in fChilds)
                    {
                        tvwTree.GetNodeByKey(f.uniqueIdToString).Remove();
                    }
                }
                else
                {
                    foreach (FIObject f in fChilds)
                    {
                        tvwTree.GetNodeByKey(createTreeId(ssnUniqueId, f.uniqueIdToString)).Remove();
                    }
                }               

                // --

                // ***
                // 모든 자식 노드가 삭제될 경우 Parent Node가 Active되게 처리
                // (그렇지 않을 경우 Root Node가 Active되나 Active Event가 발생하지 않음)
                // ***
                if (tNodeParent.Nodes.Count == 0)
                {
                    tvwTree.ActiveNode = tNodeParent;
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
                tNodeParent = null;
                fParent = null;
                fChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuMoveUpObject(
            string menuKey
            )
        {
            UltraTreeNode tNode = null;
            FIObject fObject = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                tNode = tvwTree.ActiveNode;
                fObject = (FIObject)tNode.Tag;

                //--

                if (fObject.fObjectType == FObjectType.SecsDevice)
                {
                    ((FSecsDevice)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.SecsSession)
                {
                    ((FSecsSession)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.SecsMessageList)
                {
                    ((FSecsMessageList)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.SecsMessages)
                {
                    ((FSecsMessages)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.SecsMessage)
                {
                    
                }
                else if (fObject.fObjectType == FObjectType.SecsItem)
                {
                    ((FSecsItem)fObject).moveUp();
                }

                // -- 

                tvwTree.moveUpNode(tNode);
                tvwTree.SelectedNodes.Clear();
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
                fObject = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuMoveDownObject(
            string menuKey
            )
        {
            UltraTreeNode tNode = null;
            FIObject fObject = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                tNode = tvwTree.ActiveNode;
                fObject = (FIObject)tNode.Tag;

                //--

                if (fObject.fObjectType == FObjectType.SecsDevice)
                {
                    ((FSecsDevice)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.SecsSession)
                {
                    ((FSecsSession)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.SecsMessageList)
                {
                    ((FSecsMessageList)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.SecsMessages)
                {
                    ((FSecsMessages)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.SecsMessage)
                {
                    
                }
                else if (fObject.fObjectType == FObjectType.SecsItem)
                {
                    ((FSecsItem)fObject).moveDown();
                }

                // --

                tvwTree.moveDownNode(tNode);
                tvwTree.SelectedNodes.Clear();
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
                fObject = null;
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuRelation(
            )
        {
            try
            {
                if (tvwTree.ActiveNode == null)
                {
                    return;
                }

                // --

                m_fSsmCore.fSsmContainer.showRelationViewer((FIObject)tvwTree.ActiveNode.Tag);
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
            FIObject fObject = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                fObject = (FIObject)tvwTree.ActiveNode.Tag;

                // --

                if (fObject.fObjectType == FObjectType.SecsDriver)
                {
                    tvwTree.ActiveNode.Expanded = true;
                    // --
                    foreach (UltraTreeNode tNodeSdv in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeSdv.Expanded = true;
                        // --
                        foreach (UltraTreeNode tNodeSsn in tNodeSdv.Nodes)
                        {
                            tNodeSsn.Expanded = true;
                            // --
                            foreach (UltraTreeNode tNodeSml in tNodeSsn.Nodes)
                            {
                                tNodeSml.Expanded = true;
                                // --
                                foreach (UltraTreeNode tNodeSms in tNodeSml.Nodes)
                                {
                                    tNodeSms.Expanded = true;
                                }
                            }
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.SecsDevice)
                {
                    tvwTree.ActiveNode.Expanded = true;
                    // --
                    foreach (UltraTreeNode tNodeSsn in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeSsn.Expanded = true;
                        // --
                        foreach (UltraTreeNode tNodeSml in tNodeSsn.Nodes)
                        {
                            tNodeSml.Expanded = true;
                            // --
                            foreach (UltraTreeNode tNodeSms in tNodeSml.Nodes)
                            {
                                tNodeSms.Expanded = true;
                            }
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.SecsSession)
                {
                    tvwTree.ActiveNode.Expanded = true;
                    // --
                    foreach (UltraTreeNode tNodeSml in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeSml.Expanded = true;
                        // --
                        foreach (UltraTreeNode tNodeSms in tNodeSml.Nodes)
                        {
                            tNodeSms.Expanded = true;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.SecsMessageList)
                {
                    tvwTree.ActiveNode.Expanded = true;
                    // --
                    foreach (UltraTreeNode tNodeSms in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeSms.Expanded = true;
                    }
                }
                else
                {
                    tvwTree.ActiveNode.ExpandAll();
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
                fObject = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuCollapse(
            )
        {
            FIObject fObject = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                fObject = (FIObject)tvwTree.ActiveNode.Tag;

                // --

                if (fObject.fObjectType == FObjectType.SecsDriver)
                {
                    foreach (UltraTreeNode tNodeSdv in tvwTree.ActiveNode.Nodes)
                    {
                        foreach (UltraTreeNode tNodeSsn in tNodeSdv.Nodes)
                        {
                            foreach (UltraTreeNode tNodeSml in tNodeSsn.Nodes)
                            {
                                foreach (UltraTreeNode tNodeSms in tNodeSml.Nodes)
                                {
                                    tNodeSms.Expanded = false;
                                }
                                // --
                                tNodeSml.Expanded = false;
                            }
                            // --
                            tNodeSsn.Expanded = false;
                        }
                        // --
                        tNodeSdv.Expanded = false;
                    }
                    // --
                    tvwTree.ActiveNode.Expanded = false;
                }
                else if (fObject.fObjectType == FObjectType.SecsDevice)
                {
                    foreach (UltraTreeNode tNodeSsn in tvwTree.ActiveNode.Nodes)
                    {
                        foreach (UltraTreeNode tNodeSml in tNodeSsn.Nodes)
                        {
                            foreach (UltraTreeNode tNodeSms in tNodeSml.Nodes)
                            {
                                tNodeSms.Expanded = false;
                            }
                            // --
                            tNodeSml.Expanded = false;
                        }
                        // --
                        tNodeSsn.Expanded = false;
                    }
                    // --
                    tvwTree.ActiveNode.Expanded = false;
                }
                else if (fObject.fObjectType == FObjectType.SecsSession)
                {
                    foreach (UltraTreeNode tNodeSml in tvwTree.ActiveNode.Nodes)
                    {
                        foreach (UltraTreeNode tNodeSms in tNodeSml.Nodes)
                        {
                            tNodeSms.Expanded = false;
                        }
                        // --
                        tNodeSml.Expanded = false;
                    }
                    // --
                    tvwTree.ActiveNode.Expanded = false;
                }
                else if (fObject.fObjectType == FObjectType.SecsMessageList)
                {
                    foreach (UltraTreeNode tNodeSms in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeSms.Expanded = false;
                    }
                    // --
                    tvwTree.ActiveNode.Expanded = false;
                }
                else
                {
                    tvwTree.ActiveNode.CollapseAll();
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
                fObject = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSmlViewer(
            )
        {
            FSmlViewer fSmlViewer = null;
            FIObject fObject = null;
            StringBuilder sb = null;

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

                foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                {
                    fObject = (FIObject)tNode.Tag;
                    // --
                    if (fObject.fObjectType == FObjectType.SecsMessage)
                    {
                        sb.Append(((FSecsMessage)fObject).convertToSml());
                    }
                    else if (fObject.fObjectType == FObjectType.SecsMessages)
                    {
                        sb.Append(((FSecsMessages)fObject).convertToSml());
                    }
                }
                // --
                fSmlViewer.appendSml(sb.ToString());
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fSmlViewer = null;
                sb = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuOpenSecsDevice(
            )
        {
            FSecsDevice fSecsDevice = null;

            try
            {
                fSecsDevice = (FSecsDevice)tvwTree.ActiveNode.Tag;
                fSecsDevice.open();  
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecsDevice = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuCloseSecsDevice(
            )
        {
            FSecsDevice fSecsDevice = null;

            try
            {
                fSecsDevice = (FSecsDevice)tvwTree.ActiveNode.Tag;
                fSecsDevice.close();                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecsDevice = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSendSecsMessage(
            )
        {
            FIObject fObject = null;
            FSecsMessageTransfer fSecsMessageTransfer = null;

            try
            {
                fObject = (FIObject)tvwTree.ActiveNode.Tag;
                // --
                if (fObject.fObjectType == FObjectType.SecsMessages)
                {
                    foreach (FSecsMessage fSmg in ((FSecsMessages)fObject).fChildSecsMessageCollection)
                    {
                        if (fSmg.isPrimary)
                        {
                            fSecsMessageTransfer = fSmg.createTransfer();
                            fSecsMessageTransfer.send((FSecsSession)tvwTree.ActiveNode.Parent.Parent.Tag);
                            break;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.SecsMessage)
                {
                    fSecsMessageTransfer = ((FSecsMessage)tvwTree.ActiveNode.Tag).createTransfer();                    
                    fSecsMessageTransfer.send((FSecsSession)tvwTree.ActiveNode.Parent.Parent.Parent.Tag);
                }
                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fObject = null;
                fSecsMessageTransfer = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSecsLibraryGemInspector(
            )
        {
            FIObject fObject = null;

            try
            {
                fObject = (FIObject)tvwTree.ActiveNode.Tag;

                // --

                if (fObject != null)
                {
                    m_fSsmCore.fSsmContainer.showGemInspector(((FSecsSession)fObject).fLibrary);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fObject = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuResetVersion(
            )
        {
            FResetVersionDialog dialog = null;
            FIObject fObject = null;
            FSecsMessageList fMsgList = null;
            // --
            int stream = 0;
            int function = 0;
            // --
            int version = 0;
            try
            {
                fObject = (FIObject)tvwTree.ActiveNode.Tag;
                if (fObject.fObjectType != FObjectType.SecsMessageList)
                {
                    return;
                }

                // --
                fMsgList = fObject as FSecsMessageList;

                // --

                dialog = new FResetVersionDialog(
                    m_fSsmCore,
                    fMsgList
                    );
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                // --
                stream = dialog.stream;
                function = dialog.function;
                version = dialog.version;
                // --                
                foreach (FSecsMessages msgs in fMsgList.fChildSecsMessagesCollection)
                {
                    if (msgs.stream == stream && msgs.function == function)
                    {
                        msgs.version = (version++);
                    }
                }

                // --

            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fObject = null;
                fMsgList = null;
                if (dialog != null)
                {
                    dialog.Dispose();
                    dialog = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuReplace(
            )
        {
            FReplaceNameDialog dialog = null;
            FIObject fObject = null;
            string findWhat = string.Empty;

            try
            {
                fObject = (FIObject)tvwTree.ActiveNode.Tag;
                if (fObject.fObjectType == FObjectType.SecsMessages)
                {
                    findWhat = ((FSecsMessages)fObject).name;
                }
                else if (fObject.fObjectType == FObjectType.SecsMessage)
                {
                    findWhat = ((FSecsMessage)fObject).name;
                }
                else if (fObject.fObjectType == FObjectType.SecsItem)
                {
                    findWhat = ((FSecsItem)fObject).name;
                }
                else
                {
                    return;
                }

                // --

                dialog = new FReplaceNameDialog(
                    m_fSsmCore,
                    findWhat
                    );
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                // --

                procMenuReplaceObject(fObject, dialog.findWhat, dialog.replaceWith);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (dialog != null)
                {
                    dialog.Dispose();
                    dialog = null;
                }
                fObject = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuReplaceObject(
            FIObject fObject,
            string findWhat,
            string replaceWith
            )
        {
            try
            {
                if (fObject.fObjectType == FObjectType.SecsMessages)
                {
                    foreach (FIObject o in ((FSecsMessages)fObject).fChildSecsMessageCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FSecsMessages)fObject).name = ((FSecsMessages)fObject).name.Replace(findWhat, replaceWith);
                    ((FSecsMessages)fObject).description = ((FSecsMessages)fObject).description.Replace(findWhat, replaceWith);
                }
                else if (fObject.fObjectType == FObjectType.SecsMessage)
                {
                    foreach (FIObject o in ((FSecsMessage)fObject).fChildSecsItemCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FSecsMessage)fObject).name = ((FSecsMessage)fObject).name.Replace(findWhat, replaceWith);
                    ((FSecsMessage)fObject).description = ((FSecsMessage)fObject).description.Replace(findWhat, replaceWith);
                }
                else if (fObject.fObjectType == FObjectType.SecsItem)
                {
                    foreach (FIObject o in ((FSecsItem)fObject).fChildSecsItemCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FSecsItem)fObject).name = ((FSecsItem)fObject).name.Replace(findWhat, replaceWith);
                    ((FSecsItem)fObject).description = ((FSecsItem)fObject).description.Replace(findWhat, replaceWith);                    
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

        private void procMenuCut(
            )
        {
            UltraTreeNode tNode = null;
            UltraTreeNode tNodeParent = null;
            FIObject fObject = null;

            try
            {
                tNode = tvwTree.ActiveNode;
                tNodeParent = tNode.Parent;
                fObject = (FIObject)tNode.Tag;

                // --

                if (fObject.fObjectType == FObjectType.SecsDevice)
                {
                    ((FSecsDevice)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.SecsSession)
                {
                    ((FSecsSession)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.SecsMessageList)
                {
                    ((FSecsMessageList)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.SecsMessages)
                {
                    ((FSecsMessages)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.SecsMessage)
                {
                    ((FSecsMessage)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.SecsItem)
                {
                    ((FSecsItem)fObject).cut();
                }

                // -- 

                tvwTree.beginUpdate();
                
                // --
                
                tNode.Remove();
                
                // --

                // ***
                // 모든 자식 노드가 삭제될 경우 Parent Node가 Active되게 처리
                // (그렇지 않을 경우 Root Node가 Active되나 Active Event가 발생하지 않음)
                // ***
                if (tNodeParent.Nodes.Count == 0)
                {
                    tvwTree.ActiveNode = tNodeParent;
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
                tNode = null;
                tNodeParent = null;
                fObject = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuCopy(
            )
        {
            UltraTreeNode tNode = null;
            FIObject fObject = null;

            try
            {
                tNode = tvwTree.ActiveNode;
                fObject = (FIObject)tNode.Tag;

                // --

                if (fObject.fObjectType == FObjectType.SecsDevice)
                {
                    ((FSecsDevice)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.SecsSession)
                {
                    ((FSecsSession)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.SecsMessageList)
                {
                    ((FSecsMessageList)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.SecsMessages)
                {
                    ((FSecsMessages)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.SecsMessage)
                {
                    ((FSecsMessage)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.SecsItem)
                {
                    ((FSecsItem)fObject).copy();
                }

                // --

                controlMenu();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
                fObject = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuPasteSibling(
            )
        {
            UltraTreeNode tNodeRef = null;
            UltraTreeNode tNodeNew = null;
            FIObject fRefObject = null;
            FIObject fNewObject = null;
            string uniqueId = string.Empty;

            try
            {
                tNodeRef = tvwTree.ActiveNode;
                fRefObject = (FIObject)tNodeRef.Tag;

                // --

                tvwTree.beginUpdate();

                // --

                if (fRefObject.fObjectType == FObjectType.SecsDevice)
                {
                    fNewObject = ((FSecsDevice)fRefObject).pasteSibling();
                    uniqueId = fNewObject.uniqueIdToString;
                }
                else if (fRefObject.fObjectType == FObjectType.SecsSession)
                {
                    fNewObject = ((FSecsSession)fRefObject).pasteSibling();
                    //uniqueId = createTreeId(tNodeRef.Key, fNewObject.uniqueIdToString);
                    uniqueId = fNewObject.uniqueIdToString;
                }
                else if (fRefObject.fObjectType == FObjectType.SecsMessageList)
                {
                    fNewObject = ((FSecsMessageList)fRefObject).pasteSibling();
                    uniqueId = createTreeId(getSecsSessionId(tNodeRef.Key), fNewObject.uniqueIdToString);
                }
                else if (fRefObject.fObjectType == FObjectType.SecsMessages)
                {
                    fNewObject = ((FSecsMessages)fRefObject).pasteSibling();
                    uniqueId = createTreeId(getSecsSessionId(tNodeRef.Key), fNewObject.uniqueIdToString);
                }
                else if (fRefObject.fObjectType == FObjectType.SecsMessage)
                {
                    // ***
                    // 사용하지 않음
                    // ***
                }
                else if (fRefObject.fObjectType == FObjectType.SecsItem)
                {
                    fNewObject = ((FSecsItem)fRefObject).pasteSibling();
                    uniqueId = createTreeId(getSecsSessionId(tNodeRef.Key), fNewObject.uniqueIdToString);
                }

                tNodeNew = new UltraTreeNode(uniqueId);
                tNodeNew.Tag = fNewObject;
                FCommon.refreshTreeNodeOfObject(fNewObject, tvwTree, tNodeNew);

                // --

                loadTreeOfChildObject(tNodeNew);
                tNodeRef.Parent.Nodes.Insert(tNodeRef.Index + 1, tNodeNew);
                // --
                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tNodeNew;

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
                tNodeRef = null;
                tNodeNew = null;
                fRefObject = null;
                fNewObject = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuPasteChild(
            )
        {
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeNewChild = null;
            FIObject fParent = null;
            FIObject fNewChild = null;
            string uniqueId = string.Empty;

            try
            {
                tNodeParent = tvwTree.ActiveNode;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                tvwTree.beginUpdate();

                // --

                if (fParent.fObjectType == FObjectType.SecsDriver)
                {
                    fNewChild = ((FSecsDriver)fParent).pasteChildSecsDevice();
                    uniqueId = fNewChild.uniqueIdToString;
                }
                else if (fParent.fObjectType == FObjectType.SecsDevice)
                {
                    fNewChild = ((FSecsDevice)fParent).pasteChild();
                    uniqueId = fNewChild.uniqueIdToString;
                }
                else if (fParent.fObjectType == FObjectType.SecsSession)
                {
                    fNewChild = ((FSecsSession)fParent).fLibrary.pasteChild();
                    uniqueId = createTreeId(tNodeParent.Key, fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.SecsMessageList)
                {
                    fNewChild = ((FSecsMessageList)fParent).pasteChild();
                    uniqueId = createTreeId(getSecsSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.SecsMessages)
                {
                    // *** 
                    // 사용하지 않음
                    // ***
                }
                else if (fParent.fObjectType == FObjectType.SecsMessage)
                {
                    fNewChild = ((FSecsMessage)fParent).pasteChild();
                    uniqueId = createTreeId(getSecsSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.SecsItem)
                {
                    fNewChild = ((FSecsItem)fParent).pasteChild();
                    uniqueId = createTreeId(getSecsSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }

                tNodeNewChild = new UltraTreeNode(uniqueId);
                tNodeNewChild.Tag = fNewChild;
                FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNodeNewChild);

                // --

                loadTreeOfChildObject(tNodeNewChild);
                tNodeParent.Nodes.Add(tNodeNewChild);
                // --
                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tNodeNewChild;

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
                tNodeParent = null;
                tNodeNewChild = null;
                fParent = null;
                fNewChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuPastePrimarySecsMessage(
            )
        {
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeNewChild = null;
            FIObject fParent = null;
            FIObject fNewChild = null;
            string uniqueId = string.Empty;

            try
            {
                tNodeParent = tvwTree.ActiveNode;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                tvwTree.beginUpdate();

                // --

                if (fParent.fObjectType == FObjectType.SecsMessages)
                {
                    fNewChild = ((FSecsMessages)fParent).pastePrimarySecsMessage();
                    uniqueId = createTreeId(getSecsSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }

                // --

                tNodeNewChild = new UltraTreeNode(uniqueId);
                tNodeNewChild.Tag = fNewChild;
                FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNodeNewChild);

                // --

                loadTreeOfChildObject(tNodeNewChild);
                tNodeParent.Nodes.Insert(0, tNodeNewChild);
                // --
                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tNodeNewChild;

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
                tNodeParent = null;
                tNodeNewChild = null;
                fParent = null;
                fNewChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuPasteSecondarySecsMessage(
            )
        {
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeNewChild = null;
            FIObject fParent = null;
            FIObject fNewChild = null;
            string uniqueId = string.Empty;

            try
            {
                tNodeParent = tvwTree.ActiveNode;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                tvwTree.beginUpdate();

                // --              

                if (fParent.fObjectType == FObjectType.SecsMessages)
                {
                    fNewChild = ((FSecsMessages)fParent).pasteSecondarySecsMessage();
                    uniqueId = createTreeId(getSecsSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }

                // --

                tNodeNewChild = new UltraTreeNode(uniqueId);
                tNodeNewChild.Tag = fNewChild;
                FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNodeNewChild);

                // --

                loadTreeOfChildObject(tNodeNewChild);
                tNodeParent.Nodes.Add(tNodeNewChild);
                // --
                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tNodeNewChild;

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
                tNodeParent = null;
                tNodeNewChild = null;
                fParent = null;
                fNewChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSearch(
            string searchWord
            )
        {
            UltraTreeNode tNode = null;
            FIObject fBase = null;
            FSecsSession fSsn = null;
            FIObject fResult = null;                           
            string uniqueId = null;
            string[] uniqueIds = null;            

            try
            {
                tNode = tvwTree.ActiveNode;
                fBase = (FIObject)tNode.Tag;                                

                // --              
                                
                uniqueIds = tNode.Key.Split('-');
                if (uniqueIds.Length == 2)
                {
                    fSsn = (FSecsSession)tvwTree.GetNodeByKey(uniqueIds[0]).Tag;
                }                
                
                // --

                fResult = m_fSsmCore.fSsmFileInfo.fSecsDriver.searchSecsDeviceSeries(fBase, ref fSsn, searchWord);
                if (fResult == null)
                {
                    FMessageBox.showInformation("Search", m_fSsmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { searchWord }), this);
                    return;
                }

                // --

                tvwTree.beginUpdate();

                // --

                expandTreeForSearch(fSsn, fResult);
                // --
                if (fSsn == null)
                {
                    uniqueId = fResult.uniqueIdToString;
                }
                else
                {   
                    uniqueId = createTreeId(fSsn.uniqueIdToString, fResult.uniqueIdToString);
                }
                tNode = tvwTree.GetNodeByKey(uniqueId);
                tvwTree.SelectedNodes.Clear();
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
                fBase = null;
                fSsn = null;
                fResult = null;
            }
        }        

        //------------------------------------------------------------------------------------------------------------------------

        public void searchObject(
            FIObject fObject
            )
        {
            UltraTreeNode tNode = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                // ***
                // SECS Device와 SECS Session 검색에만 사용된다.
                // *** 
                expandTreeForSearch(null, fObject);
                tNode = tvwTree.GetNodeByKey(fObject.uniqueIdToString);
                tvwTree.ActiveNode = tNode;
                tvwTree.TopNode = tNode;

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

        private void expandTreeForSearch(
            FIObject fSsn,
            FIObject fObject            
            )
        {
            FIObject fParent = null;
            UltraTreeNode tNodeParent = null;
            string parentUid = string.Empty;

            try
            {
                if (fObject.fObjectType == FObjectType.SecsDriver)
                {
                    return;
                }
                
                // --

                fParent = m_fSsmCore.fSsmFileInfo.fSecsDriver.getParentOfObject(fObject);

                // --             

                if (
                    fParent.fObjectType == FObjectType.SecsDriver ||
                    fParent.fObjectType == FObjectType.SecsDevice ||
                    fParent.fObjectType == FObjectType.SecsSession
                    )
                {
                    parentUid = fParent.uniqueIdToString;
                }
                else
                {
                    parentUid = string.Format("{0}-{1}", fSsn.uniqueIdToString, fParent.uniqueIdToString);
                }

                // --

                tNodeParent = tvwTree.GetNodeByKey(parentUid);
                if (tNodeParent == null || !tNodeParent.Expanded)
                {
                    expandTreeForSearch(fSsn, fParent);
                }

                // --

                if (tNodeParent == null)
                {
                    tNodeParent = tvwTree.GetNodeByKey(parentUid);
                }

                if (tNodeParent != null)
                {
                    tNodeParent.Expanded = true;
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fParent = null;
                tNodeParent = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuStandardSecsMessages(
           )
        {   
            FIObject fSelectedObject = null;
            FIObject fChild = null;
            UltraTreeNode tNodeChild = null;
            UltraTreeNode tNodeParent = null;
            string uniqueId = string.Empty;
            FStandardSecsLibrarySelector fStandardSecsLibrarySelector = null;

            try
            {
                tNodeParent = tvwTree.ActiveNode;
                fSelectedObject = (FIObject)tNodeParent.Tag;                

                // --

                fStandardSecsLibrarySelector = new FStandardSecsLibrarySelector(m_fSsmCore);                    
                fStandardSecsLibrarySelector.ShowDialog(this);
                // --
                if (fStandardSecsLibrarySelector.fSelectedSecsMessages != null)
                {
                    foreach (FIObject fObject in fStandardSecsLibrarySelector.fSelectedSecsMessages)
                    {
                        ((FSecsMessages)fObject).copy();
                        // --
                        fChild = ((FSecsMessageList)fSelectedObject).pasteChild();
                        uniqueId = createTreeId(getSecsSessionId(tNodeParent.Key), fChild.uniqueIdToString);
                        tNodeChild = new UltraTreeNode(uniqueId);
                        tNodeChild.Tag = fChild;
                        FCommon.refreshTreeNodeOfObject(fChild, tvwTree, tNodeChild);
                        // --
                        loadTreeOfChildObject(tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                // --                
                tNodeParent.Expanded = true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSelectedObject = null;
                fChild = null;
                tNodeChild = null;
                tNodeParent = null;
                // --
                if (fStandardSecsLibrarySelector != null)
                {
                    fStandardSecsLibrarySelector.Dispose();
                    fStandardSecsLibrarySelector = null;
                }                
            }
        }               

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FSecsDeviceModeler Form Event Handler

        private void FSecsDeviceModeler_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designTreeOfSecsLibraryModeler();

                // --

                tvwTree.setPopupMenu((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuSdmPopupMenu]);                

                // --

                m_fEventHandler = new FEventHandler(m_fSsmCore.fSsmFileInfo.fSecsDriver, tvwTree);
                // --
                m_fEventHandler.ObjectModifyCompleted += new FObjectModifyCompletedEventHandler(m_fEventHandler_ObjectModifyCompleted);
                m_fEventHandler.ObjectInsertBeforeCompleted += new FObjectInsertBeforeCompletedEventHandler(m_fEventHandler_ObjectInsertBeforeCompleted);
                m_fEventHandler.ObjectInsertAfterCompleted += new FObjectInsertAfterCompletedEventHandler(m_fEventHandler_ObjectInsertAfterCompleted);
                m_fEventHandler.ObjectAppendCompleted += new FObjectAppendCompletedEventHandler(m_fEventHandler_ObjectAppendCompleted);
                m_fEventHandler.ObjectRemoveCompleted += new FObjectRemoveCompletedEventHandler(m_fEventHandler_ObjectRemoveCompleted);
                m_fEventHandler.ObjectMoveUpCompleted += new FObjectMoveUpCompletedEventHandler(m_fEventHandler_ObjectMoveUpCompleted);
                m_fEventHandler.ObjectMoveDownCompleted += new FObjectMoveDownCompletedEventHandler(m_fEventHandler_ObjectMoveDownCompleted);
                m_fEventHandler.ObjectMoveToCompleted += new FObjectMoveToCompletedEventHandler(m_fEventHandler_ObjectMoveToCompleted);
                m_fEventHandler.SecsDeviceStateChanged += new FSecsDeviceStateChangedEventHandler(m_fEventHandler_SecsDeviceStateChanged);                

                // --

                pgdProp.DynPropNoticeRaised += new FDynPropNoticeRaisedEventHandler(pgdProp_DynPropNoticeRaised);

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

        private void FSecsDeviceModeler_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                loadTreeOfObject();

                // --

                tvwTree.Focus();
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

        private void FSecsDeviceModeler_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                if (m_fEventHandler != null)
                {
                    m_fSsmCore.fSsmFileInfo.fSecsDriver.waitEventHandlingCompleted();

                    // --

                    m_fEventHandler.Dispose();
                    // --
                    m_fEventHandler.ObjectModifyCompleted -= new FObjectModifyCompletedEventHandler(m_fEventHandler_ObjectModifyCompleted);
                    m_fEventHandler.ObjectInsertBeforeCompleted -= new FObjectInsertBeforeCompletedEventHandler(m_fEventHandler_ObjectInsertBeforeCompleted);
                    m_fEventHandler.ObjectInsertAfterCompleted -= new FObjectInsertAfterCompletedEventHandler(m_fEventHandler_ObjectInsertAfterCompleted);
                    m_fEventHandler.ObjectAppendCompleted -= new FObjectAppendCompletedEventHandler(m_fEventHandler_ObjectAppendCompleted);
                    m_fEventHandler.ObjectRemoveCompleted -= new FObjectRemoveCompletedEventHandler(m_fEventHandler_ObjectRemoveCompleted);
                    m_fEventHandler.ObjectMoveUpCompleted -= new FObjectMoveUpCompletedEventHandler(m_fEventHandler_ObjectMoveUpCompleted);
                    m_fEventHandler.ObjectMoveDownCompleted -= new FObjectMoveDownCompletedEventHandler(m_fEventHandler_ObjectMoveDownCompleted);
                    m_fEventHandler.ObjectMoveToCompleted -= new FObjectMoveToCompletedEventHandler(m_fEventHandler_ObjectMoveToCompleted);
                    m_fEventHandler.SecsDeviceStateChanged -= new FSecsDeviceStateChangedEventHandler(m_fEventHandler_SecsDeviceStateChanged);                    
                    // --
                    m_fEventHandler = null;
                }

                // --

                pgdProp.DynPropNoticeRaised -= new FDynPropNoticeRaisedEventHandler(pgdProp_DynPropNoticeRaised);

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

        private void m_fEventHandler_ObjectInsertBeforeCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.SecsDevice ||
                    e.fObject.fObjectType == FObjectType.SecsSession
                    )
                {
                    addTreeOfObject(e.fParentObject, e.fObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.SecsMessageList ||
                    e.fObject.fObjectType == FObjectType.SecsMessages ||
                    e.fObject.fObjectType == FObjectType.SecsMessage ||
                    e.fObject.fObjectType == FObjectType.SecsItem
                    )
                {
                    addTreeOfObject2(e.fParentObject, e.fObject);
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

        private void m_fEventHandler_ObjectInsertAfterCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.SecsDevice ||
                    e.fObject.fObjectType == FObjectType.SecsSession
                    )
                {
                    addTreeOfObject(e.fParentObject, e.fObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.SecsMessageList ||
                    e.fObject.fObjectType == FObjectType.SecsMessages ||
                    e.fObject.fObjectType == FObjectType.SecsMessage ||
                    e.fObject.fObjectType == FObjectType.SecsItem
                    )
                {
                    addTreeOfObject2(e.fParentObject, e.fObject);
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

        private void m_fEventHandler_ObjectAppendCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.SecsDevice ||
                    e.fObject.fObjectType == FObjectType.SecsSession
                    )
                {
                    addTreeOfObject(e.fParentObject, e.fObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.SecsMessageList ||
                    e.fObject.fObjectType == FObjectType.SecsMessages ||
                    e.fObject.fObjectType == FObjectType.SecsMessage ||
                    e.fObject.fObjectType == FObjectType.SecsItem
                    )
                {
                    addTreeOfObject2(e.fParentObject, e.fObject);
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

        private void m_fEventHandler_ObjectRemoveCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.SecsDevice ||
                    e.fObject.fObjectType == FObjectType.SecsSession
                    )
                {
                    removeTreeOfObject(e.fObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.SecsMessageList ||
                    e.fObject.fObjectType == FObjectType.SecsMessages ||
                    e.fObject.fObjectType == FObjectType.SecsMessage ||
                    e.fObject.fObjectType == FObjectType.SecsItem
                    )
                {
                    removeTreeOfObject2(e.fObject);
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

        private void m_fEventHandler_ObjectMoveUpCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.SecsDevice ||
                    e.fObject.fObjectType == FObjectType.SecsSession 
                    )
                {
                    moveUpTreeOfObject(e.fObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.SecsMessageList ||
                    e.fObject.fObjectType == FObjectType.SecsMessages ||
                    e.fObject.fObjectType == FObjectType.SecsMessage ||
                    e.fObject.fObjectType == FObjectType.SecsItem
                    )
                {
                    moveUpTreeOfObject2(e.fObject);
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

        private void m_fEventHandler_ObjectMoveDownCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.SecsDevice ||
                    e.fObject.fObjectType == FObjectType.SecsSession
                    )
                {
                    moveDownTreeOfObject(e.fObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.SecsMessageList ||
                    e.fObject.fObjectType == FObjectType.SecsMessages ||
                    e.fObject.fObjectType == FObjectType.SecsMessage ||
                    e.fObject.fObjectType == FObjectType.SecsItem
                    )
                {
                    moveDownTreeOfObject2(e.fObject);
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

        private void m_fEventHandler_ObjectMoveToCompleted(
            object sender, 
            FObjectMoveToCompletedEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.SecsDevice ||
                    e.fObject.fObjectType == FObjectType.SecsSession
                    )
                {
                    moveToTreeOfObject(e.fObject, e.fRefObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.SecsMessageList ||
                    e.fObject.fObjectType == FObjectType.SecsMessages ||
                    e.fObject.fObjectType == FObjectType.SecsMessage ||
                    e.fObject.fObjectType == FObjectType.SecsItem
                    )
                {
                    moveToTreeOfObject2(e.fObject, e.fRefObject);
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

        private void m_fEventHandler_ObjectModifyCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.SecsDriver ||
                    e.fObject.fObjectType == FObjectType.SecsDevice ||
                    e.fObject.fObjectType == FObjectType.SecsSession
                    )
                {
                    refreshObject(e.fObject);
                }
                else if (e.fObject.fObjectType == FObjectType.SecsLibrary)
                {
                    foreach (FIObject fObject in ((FSecsLibrary)e.fObject).fReferenceObjectCollection)
                    {
                        if (fObject.fObjectType == FObjectType.SecsSession)
                        {
                            refreshObject(fObject);
                        }                        
                    }
                }               
                else if (
                    e.fObject.fObjectType == FObjectType.SecsMessageList ||
                    e.fObject.fObjectType == FObjectType.SecsMessages ||
                    e.fObject.fObjectType == FObjectType.SecsMessage ||
                    e.fObject.fObjectType == FObjectType.SecsItem
                    )
                {
                    refreshObject2(e.fObject);
                }
                else if (e.fObject.fObjectType == FObjectType.DataSet)
                {
                    foreach (FIObject fObject in ((FDataSet)e.fObject).fReferenceObjectCollection)
                    {
                        if (fObject.fObjectType == FObjectType.SecsMessage)
                        {
                            refreshObject2(fObject);
                        }
                    }
                }
                else if (e.fObject.fObjectType == FObjectType.DataConversionSet)
                {
                    foreach (FIObject fObject in ((FDataConversionSet)e.fObject).fReferenceObjectCollection)
                    {
                        if (fObject.fObjectType == FObjectType.SecsItem)
                        {
                            refreshObject2(fObject);
                        }
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

        private void m_fEventHandler_SecsDeviceStateChanged(
            object sender, 
            FSecsDeviceStateChangedEventArgs e
            )
        {
            UltraTreeNode tNode = null;

            try
            {
                if (e.fSecsDeviceStateChangedLog.fResultCode != FResultCode.Success)
                {
                    return;
                }

                // --

                tNode = tvwTree.GetNodeByKey(e.fSecsDeviceStateChangedLog.uniqueIdToString);
                if (
                    e.fSecsDeviceStateChangedLog.fState == FDeviceState.Opened || 
                    e.fSecsDeviceStateChangedLog.fState == FDeviceState.Closed
                    )
                {
                    if (tNode != null && tNode.IsActive)
                    {
                        ((FPropSdv)pgdProp.selectedObject).setChangedState(e.fSecsDeviceStateChangedLog.fState);
                        controlMenu();             
                    }                    
                }                

                // --

                if (tvwTree.ActiveNode != null)
                {
                    if (
                        ((FIObject)tvwTree.ActiveNode.Tag).fObjectType == FObjectType.SecsMessages ||
                        ((FIObject)tvwTree.ActiveNode.Tag).fObjectType == FObjectType.SecsMessage
                        )
                    {
                        controlMenu();
                    }
                }

                // --

                FCommon.refreshTreeNodeOfObject((FIObject)tNode.Tag, tvwTree, tNode);
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

        private void m_fEventHandler_SecsDeviceDataReceived(
            object sender, 
            FSecsDeviceDataReceivedEventArgs e
            )
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(
                    e.fSecsDeviceDataReceivedLog.ToString(FStringOption.Detail) + " [R]"
                    );
                System.Diagnostics.Debug.WriteLine(e.dataToString(30));
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

        private void m_fEventHandler_SecsDeviceDataSent(
            object sender, 
            FSecsDeviceDataSentEventArgs e
            )
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(
                    e.fSecsDeviceDataSentLog.ToString(FStringOption.Detail) + " [S]"
                    );
                System.Diagnostics.Debug.WriteLine(e.dataToString(30));
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
                System.Diagnostics.Debug.WriteLine(
                    e.fSecsDeviceErrorRaisedLog.ToString(FStringOption.Detail)
                    );
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
                System.Diagnostics.Debug.WriteLine(
                    e.fSecsDeviceControlMessageReceivedLog.ToString(FStringOption.Detail) + " [R]"
                    );
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
                System.Diagnostics.Debug.WriteLine(
                    e.fSecsDeviceControlMessageSentLog.ToString(FStringOption.Detail) + " [S]"
                    );
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

        private void m_fEventHandler_SecsDeviceSmlReceived(
            object sender, 
            FSecsDeviceSmlReceivedEventArgs e
            )
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(
                    e.fSecsDeviceSmlReceivedLog.ToString(FStringOption.Detail)
                    );
                System.Diagnostics.Debug.WriteLine(e.sml);
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
                System.Diagnostics.Debug.WriteLine(
                    e.fSecsDeviceDataMessageReceivedLog.ToString(FStringOption.Detail) + " [R]"
                    );
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
                System.Diagnostics.Debug.WriteLine(
                    e.fSecsDeviceDataMessageSentLog.ToString(FStringOption.Detail) + " [S]"
                    );
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
                System.Diagnostics.Debug.WriteLine(
                    e.fSecsDeviceTimeoutRaisedLog.ToString(FStringOption.Detail)
                    );                
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
                System.Diagnostics.Debug.WriteLine(
                    e.fSecsTriggerRaisedLog.ToString(FStringOption.Detail)
                    );                
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
                System.Diagnostics.Debug.WriteLine(
                    e.fSecsTransmitterRaisedLog.ToString(FStringOption.Detail)
                    );
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
                System.Diagnostics.Debug.WriteLine(
                    e.fCallbackRaisedLog.ToString(FStringOption.Detail)
                    );
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
                System.Diagnostics.Debug.WriteLine(
                    e.fFunctionCalledLog.ToString(FStringOption.Detail) + ", Parameter1=[" + e.fFunctionCalledLog.parameter1 + "]"
                    );                
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
                System.Diagnostics.Debug.WriteLine(
                    e.fBranchRaisedLog.ToString(FStringOption.Detail)
                    );
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
                System.Diagnostics.Debug.WriteLine(
                    e.fPauserRaisedLog.ToString(FStringOption.Detail)
                    );
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
                System.Diagnostics.Debug.WriteLine(
                    e.fCommentWrittenLog.ToString(FStringOption.Detail)
                    );
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

        #region tvwTree Control Event Handler

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
                    loadTreeOfChildObject(tNode);
                }

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwTree_AfterActivate(
            object sender,
            NodeEventArgs e
            )
        {
            FIObject fObject = null;
            
            try
            {
                if (tvwTree.ActiveNode == null)
                {
                    return;
                }

                // --

                fObject = (FIObject)tvwTree.ActiveNode.Tag;
                // --
                if (fObject.fObjectType == FObjectType.SecsDriver)
                {
                    pgdProp.selectedObject = new FPropScd(m_fSsmCore, pgdProp, (FSecsDriver)fObject);
                }
                else if (fObject.fObjectType == FObjectType.SecsDevice)
                {
                    pgdProp.selectedObject = new FPropSdv(m_fSsmCore, pgdProp, (FSecsDevice)fObject);
                }
                else if (fObject.fObjectType == FObjectType.SecsSession)
                {
                    pgdProp.selectedObject = new FPropSsn(m_fSsmCore, pgdProp, (FSecsSession)fObject);
                }
                else if (fObject.fObjectType == FObjectType.SecsMessageList)
                {
                    pgdProp.selectedObject = new FPropSml(m_fSsmCore, pgdProp, (FSecsMessageList)fObject);
                }
                else if (fObject.fObjectType == FObjectType.SecsMessages)
                {
                    pgdProp.selectedObject = new FPropSms(m_fSsmCore, pgdProp, (FSecsMessages)fObject);
                }
                else if (fObject.fObjectType == FObjectType.SecsMessage)
                {
                    pgdProp.selectedObject = new FPropSmg(m_fSsmCore, pgdProp, (FSecsMessage)fObject);
                }
                else if (fObject.fObjectType == FObjectType.SecsItem)
                {
                    if (((FSecsItem)fObject).fParent == null)
                    {
                        return;
                    }
                    pgdProp.selectedObject = new FPropSit(m_fSsmCore, pgdProp, (FSecsItem)fObject);
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

        private void tvwTree_KeyDown(
            object sender,
            KeyEventArgs e
            )
        {
            FIObject fObject = null;

            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSdmRemove].SharedProps.Enabled)
                    {
                        procMenuRemoveObject();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.X)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSdmCut].SharedProps.Enabled)
                    {
                        procMenuCut();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.C)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSdmCopy].SharedProps.Enabled)
                    {
                        procMenuCopy();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.V)
                {
                    fObject = (FIObject)this.tvwTree.ActiveNode.Tag;

                    if (fObject.fObjectType == FObjectType.SecsMessages)
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuSdmPastePrimarySecsMessage].SharedProps.Enabled)
                        {
                            procMenuPastePrimarySecsMessage();
                        }
                        else if (mnuMenu.Tools[FMenuKey.MenuSdmPasteSibling].SharedProps.Enabled)
                        {
                            procMenuPasteSibling();
                        }
                    }
                    else
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuSdmPasteSibling].SharedProps.Enabled)
                        {
                            procMenuPasteSibling();
                        }
                    }
                }
                else if (e.Control && e.KeyCode == Keys.B)
                {
                    fObject = (FIObject)this.tvwTree.ActiveNode.Tag;

                    if (fObject.fObjectType == FObjectType.SecsMessages)
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuSdmPasteSecondarySecsMessage].SharedProps.Enabled)
                        {
                            procMenuPasteSecondarySecsMessage();
                        }
                    }
                    else
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuSdmPasteChild].SharedProps.Enabled)
                        {
                            procMenuPasteChild();
                        }
                    }
                }
                else if (e.Control && e.KeyCode == Keys.U)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSdmMoveUp].SharedProps.Enabled)
                    {
                        procMenuMoveUpObject(FMenuKey.MenuSdmMoveUp);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.D)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSdmMoveDown].SharedProps.Enabled)
                    {
                        procMenuMoveDownObject(FMenuKey.MenuSdmMoveDown);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.E)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSdmExpand].SharedProps.Enabled)
                    {
                        procMenuExpand();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.L)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSdmCollapse].SharedProps.Enabled)
                    {
                        procMenuCollapse();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.R)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSdmRelation].SharedProps.Enabled)
                    {
                        procMenuRelation();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.S)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSdmSendSecsMessage].SharedProps.Enabled)
                    {
                        procMenuSendSecsMessage();
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

        private void tvwTree_Enter(
            object sender,
            EventArgs e
            )
        {
            try
            {
                if (tvwTree.ActiveNode != null)
                {
                    controlMenu();
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

        private void tvwTree_MouseMove(
            object sender,
            MouseEventArgs e
            )
        {
            UltraTreeNode tNode = null;
            FIObject fObject = null;
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

                fObject = (FIObject)tNode.Tag;
                fDragDropData = new FDragDropData(fObject);
                // --
                if (
                    fObject.fObjectType != FObjectType.SecsDriver &&
                    fObject.fObjectType != FObjectType.SecsDevice &&
                    fObject.fObjectType != FObjectType.SecsSession
                    )
                {
                    fDragDropData.sessionUniqueId = getSecsSessionId(tNode.Key);
                }
                // --
                tvwTree.DoDragDrop(new DataObject(fDragDropData), DragDropEffects.All);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                tNode = null;
                fObject = null;
                fDragDropData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwTree_DragOver(
            object sender, 
            DragEventArgs e
            )
        {
            FDragDropData fDragDropData = null;
            UltraTreeNode tRefNode = null;
            FIObject fRefObject = null;            
            int cnt = 0;
            string ssnUniqueId = string.Empty;
            FFormat fFormat = FFormat.Unknown;

            try
            {
                tRefNode = tvwTree.GetNodeFromPoint(tvwTree.PointToClient(new System.Drawing.Point(e.X, e.Y)));
                fDragDropData = e.Data.GetData(typeof(FDragDropData).ToString(), true) as FDragDropData;
                if (tRefNode == null || fDragDropData == null || !fDragDropData.serializableSuccess)
                {
                    if (fDragDropData != null && fDragDropData.oldRefNode != null)
                    {
                        FCommon.resetDragOverTreeNode(fDragDropData.oldRefNode);
                        fDragDropData.oldRefNode = null;
                    }
                    // --
                    e.Effect = DragDropEffects.None;
                    return;
                }
                              
                // --

                if (fDragDropData.oldRefNode != null)
                {
                    FCommon.resetDragOverTreeNode(fDragDropData.oldRefNode);
                }
                // --
                FCommon.setDragOverTreeNode(tRefNode);
                fDragDropData.oldRefNode = tRefNode;

                // --

                fRefObject = (FIObject)tRefNode.Tag;
                
                // --

                if (fDragDropData.fObject != null)
                {
                    #region FObject

                    if (fRefObject.fObjectType == FObjectType.SecsDriver)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsDevice)
                        {
                            #region SecsDevice

                            if (((FSecsDriver)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                cnt = ((FSecsDriver)fRefObject).fChildSecsDeviceCollection.count;
                                fRefObject = ((FSecsDriver)fRefObject).fChildSecsDeviceCollection[cnt - 1];
                                if (!fRefObject.Equals(fDragDropData.fObject))
                                {
                                    e.Effect = DragDropEffects.Move;
                                    return;
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.SecsDevice)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsDevice)
                        {
                            #region SecsDevice

                            if (((FSecsDevice)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FSecsDevice)fRefObject).fNextSibling == null || !((FSecsDevice)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                    )
                                {
                                    e.Effect = DragDropEffects.Move;
                                    return;
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsSession)
                        {
                            #region SecsSession

                            if (((FSecsDevice)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                cnt = ((FSecsDevice)fRefObject).fChildSecsSessionCollection.count;
                                if (cnt == 0)
                                {
                                    if (!((FSecsSession)fDragDropData.fObject).locked)
                                    {
                                        e.Effect = DragDropEffects.Move;
                                        return;
                                    }
                                }
                                else
                                {
                                    fRefObject = ((FSecsDevice)fRefObject).fChildSecsSessionCollection[cnt - 1];
                                    if (!fRefObject.Equals(fDragDropData.fObject))
                                    {
                                        if (((FSecsSession)fDragDropData.fObject).locked)
                                        {
                                            if (((FSecsSession)fRefObject).fParent == ((FSecsSession)fDragDropData.fObject).fParent)
                                            {
                                                e.Effect = DragDropEffects.Move;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            e.Effect = DragDropEffects.Move;
                                            return;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.SecsSession)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsSession)
                        {
                            #region SecsSession

                            if (((FSecsSession)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FSecsSession)fRefObject).fNextSibling == null || !((FSecsSession)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                    )
                                {
                                    if (((FSecsSession)fDragDropData.fObject).locked)
                                    {
                                        if (((FSecsSession)fRefObject).fParent == ((FSecsSession)fDragDropData.fObject).fParent)
                                        {
                                            e.Effect = DragDropEffects.Move;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        e.Effect = DragDropEffects.Move;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsLibrary)
                        {
                            #region SecsLibrary

                            if (
                                !((FSecsSession)fRefObject).locked &&
                                ((FSecsSession)fRefObject).equalsModelingFile(fDragDropData.fObject)
                                )
                            {
                                if (((FSecsSession)fRefObject).hasLibrary)
                                {
                                    if (!((FSecsSession)fRefObject).fLibrary.Equals((FSecsLibrary)fDragDropData.fObject))
                                    {
                                        e.Effect = DragDropEffects.Copy;
                                        return;
                                    }
                                }
                                else
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsMessageList)
                        {
                            #region SecsMessageList

                            if (((FSecsSession)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (fRefObject.uniqueIdToString == fDragDropData.sessionUniqueId)
                                {
                                    cnt = ((FSecsSession)fRefObject).fLibrary.fChildSecsMessageListCollection.count;
                                    fRefObject = ((FSecsSession)fRefObject).fLibrary.fChildSecsMessageListCollection[cnt - 1];
                                    if (!fRefObject.Equals(fDragDropData.fObject))
                                    {
                                        e.Effect = DragDropEffects.Move;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.SecsMessageList)
                    {
                        ssnUniqueId = getSecsSessionId(tRefNode.Key);

                        // --

                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsMessageList)
                        {
                            #region SecsMessageList

                            if (((FSecsMessageList)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (ssnUniqueId == fDragDropData.sessionUniqueId)
                                {
                                    if (
                                        !fRefObject.Equals(fDragDropData.fObject) &&
                                        (((FSecsMessageList)fRefObject).fNextSibling == null || !((FSecsMessageList)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                        )
                                    {
                                        e.Effect = DragDropEffects.Move;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsMessages)
                        {
                            #region SecsMessages

                            if (((FSecsMessageList)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                // ***
                                // SECS Messages는 다른 SECS Library로 Move 할 수 없다.
                                // ***
                                if (
                                    fDragDropData.sessionUniqueId == ssnUniqueId &&
                                    ((FSecsMessageList)fRefObject).fAncestorSecsLibrary.Equals(((FSecsMessages)fDragDropData.fObject).fAncestorSecsLibrary)
                                    )
                                {
                                    cnt = ((FSecsMessageList)fRefObject).fChildSecsMessagesCollection.count;
                                    if (cnt == 0)
                                    {
                                        e.Effect = DragDropEffects.Move;
                                        return;
                                    }
                                    else
                                    {
                                        fRefObject = ((FSecsMessageList)fRefObject).fChildSecsMessagesCollection[cnt - 1];
                                        if (!fRefObject.Equals(fDragDropData.fObject))
                                        {
                                            e.Effect = DragDropEffects.Move;
                                            return;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.SecsMessages)
                    {
                        ssnUniqueId = getSecsSessionId(tRefNode.Key);

                        // --

                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsMessages)
                        {
                            #region SecsMessages

                            if (((FSecsMessages)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                // ***
                                // SECS Messages는 다른 SECS Library로 Move 할 수 없다.
                                // ***
                                if (
                                    fDragDropData.sessionUniqueId == ssnUniqueId &&
                                    ((FSecsMessages)fRefObject).fAncestorSecsLibrary.Equals(((FSecsMessages)fDragDropData.fObject).fAncestorSecsLibrary)
                                    )
                                {
                                    if (
                                        !fRefObject.Equals(fDragDropData.fObject) &&
                                        (((FSecsMessages)fRefObject).fNextSibling == null || !((FSecsMessages)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                        )
                                    {
                                        e.Effect = DragDropEffects.Move;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsMessage)
                        {
                            #region SecsMessage

                            if (!((FSecsMessages)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FSecsMessage)fDragDropData.fObject).isPrimary)
                                {
                                    if (((FSecsMessages)fRefObject).canAppendChildPrimarySecsMessage)
                                    {
                                        e.Effect = DragDropEffects.Copy;
                                        return;
                                    }
                                }
                                else
                                {
                                    if (((FSecsMessages)fRefObject).canAppendChildSecondarySecsMessage)
                                    {
                                        e.Effect = DragDropEffects.Copy;
                                        return;
                                    }
                                }
                            }

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.SecsMessage)
                    {
                        ssnUniqueId = getSecsSessionId(tRefNode.Key);

                        // --

                        if (fDragDropData.fObject.fObjectType == FObjectType.DataSet)
                        {
                            #region DataSet

                            if (((FSecsMessage)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (!((FDataSet)fDragDropData.fObject).hasChild)
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }
                            }

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.SecsItem)
                    {
                        ssnUniqueId = getSecsSessionId(tRefNode.Key);

                        // --

                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsItem)
                        {
                            #region SecsItem

                            if (((FSecsItem)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    fDragDropData.sessionUniqueId == ssnUniqueId &&
                                    !((FSecsItem)fDragDropData.fObject).containsObject(fRefObject) &&
                                    ((FSecsItem)fRefObject).fParent.fObjectType == FObjectType.SecsItem &&
                                    ((FSecsItem)fRefObject).fAncestorSecsMessage.Equals(((FSecsItem)fDragDropData.fObject).fAncestorSecsMessage) &&
                                    (((FSecsItem)fRefObject).fNextSibling == null || !(((FSecsItem)fRefObject).fNextSibling.Equals((FSecsItem)fDragDropData.fObject)))
                                    )
                                {
                                    if (((FSecsItem)((FSecsItem)fRefObject).fParent).hasVariableChild)
                                    {
                                        if (((FSecsItem)fDragDropData.fObject).fPattern == FPattern.Variable)
                                        {
                                            if (
                                                ((FSecsItem)fDragDropData.fObject).fParent.Equals(((FSecsItem)fRefObject).fParent) &&
                                                (((FSecsItem)fDragDropData.fObject).fPreviousSibling == null || ((FSecsItem)fDragDropData.fObject).fPreviousSibling.fPattern == FPattern.Fixed) &&
                                                (((FSecsItem)fDragDropData.fObject).fNextSibling == null || ((FSecsItem)fDragDropData.fObject).fNextSibling.fPattern == FPattern.Fixed)
                                                )
                                            {
                                                e.Effect = DragDropEffects.Move;
                                                return;
                                            }
                                            else if (
                                                ((FSecsItem)fRefObject).fPattern == FPattern.Variable ||
                                                (((FSecsItem)fRefObject).fNextSibling != null && ((FSecsItem)fRefObject).fNextSibling.fPattern == FPattern.Variable)
                                                )
                                            {
                                                e.Effect = DragDropEffects.Move;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            if (
                                                ((FSecsItem)fRefObject).fPattern == FPattern.Fixed ||
                                                ((FSecsItem)fRefObject).fNextSibling == null ||
                                                ((FSecsItem)fRefObject).fNextSibling.fPattern == FPattern.Fixed
                                                )
                                            {
                                                e.Effect = DragDropEffects.Move;
                                                return;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        e.Effect = DragDropEffects.Move;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                if (((FSecsItem)fRefObject).fParent.fObjectType == FObjectType.SecsItem)
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.DataConversionSet)
                        {
                            #region DataConversionSet

                            if (((FSecsItem)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                fFormat = ((FSecsItem)fRefObject).fFormat;
                                // --
                                if (
                                    fFormat != FFormat.List &&
                                    fFormat != FFormat.AsciiList &&
                                    fFormat != FFormat.Raw &&
                                    fFormat != FFormat.Unknown
                                    )
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Data)
                        {
                            #region Data

                            if (((FSecsItem)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                    }

                    #endregion
                }
                else if (fDragDropData.fObjectLog != null)
                {
                    #region FObjectLog

                    if (fRefObject.fObjectType == FObjectType.SecsMessageList)
                    {
                        if (
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog ||
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog
                            )
                        {
                            #region SecsMessageLog

                            e.Effect = DragDropEffects.Copy;
                            return;

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.SecsMessages)
                    {
                        if (
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog ||
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog
                            )
                        {
                            #region SecsMessageLog

                            e.Effect = DragDropEffects.Copy;
                            return;

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.SecsItem)
                    {
                        if (fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.SecsItemLog)
                        {
                            #region SecsItemLog

                            if (((FSecsItem)fRefObject).fParent.fObjectType == FObjectType.SecsItem)
                            {
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                    }

                    #endregion
                }                

                // --

                FCommon.resetDragOverTreeNode(tRefNode);
                e.Effect = DragDropEffects.None;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                tRefNode = null;                
                fRefObject = null;
                fDragDropData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tvwTree_DragDrop(
            object sender,
            DragEventArgs e
            )
        {
            FDragDropAction fAction = FDragDropAction.Move;
            FDragDropData fDragDropData = null;
            UltraTreeNode tRefNode = null;
            UltraTreeNode tNode = null;
            FIObject fRefObject = null;            
            int cnt = 0;
            string uniqueId = string.Empty;
            string refUniqueId = string.Empty;
            FSecsMessages fSms = null;
            FDataSetGenerator fDataSetGenertor = null;

            try
            {
                tRefNode = tvwTree.GetNodeFromPoint(tvwTree.PointToClient(new System.Drawing.Point(e.X, e.Y)));
                fDragDropData = e.Data.GetData(typeof(FDragDropData).ToString(), true) as FDragDropData;
                if (tRefNode == null || fDragDropData == null)
                {
                    if (fDragDropData != null && fDragDropData.oldRefNode != null)
                    {
                        FCommon.resetDragOverTreeNode(fDragDropData.oldRefNode);
                        fDragDropData.oldRefNode = null;
                    }
                    return;
                }

                // --

                if (m_fSsmCore.fOption.dragDropConfirm)
                {
                    if (FMessageBox.showQuestion("Drag & Drop Confirm", "Do you want drop it?", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2, this) != System.Windows.Forms.DialogResult.Yes)
                    {
                        return;
                    }
                }

                // --

                if (fDragDropData.oldRefNode != null)
                {
                    FCommon.resetDragOverTreeNode(fDragDropData.oldRefNode);
                }

                // --

                fRefObject = (FIObject)tRefNode.Tag;

                // --

                if (fDragDropData.fObject != null)
                {
                    #region FObject

                    if (fRefObject.fObjectType == FObjectType.SecsDriver)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsDevice)
                        {
                            #region SecsDevice

                            if (e.Effect == DragDropEffects.Move)
                            {
                                cnt = ((FSecsDriver)fRefObject).fChildSecsDeviceCollection.count;
                                fRefObject = ((FSecsDriver)fRefObject).fChildSecsDeviceCollection[cnt - 1];
                                ((FSecsDevice)fDragDropData.fObject).moveTo((FSecsDevice)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FSecsDevice)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FSecsDriver)fRefObject).pasteChildSecsDevice();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.SecsDevice)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsDevice)
                        {
                            #region SecsDevice

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FSecsDevice)fDragDropData.fObject).moveTo((FSecsDevice)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FSecsDevice)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FSecsDevice)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsSession)
                        {
                            #region SecsSession

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FSecsSession)fDragDropData.fObject).moveTo((FSecsDevice)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FSecsSession)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FSecsDevice)fRefObject).pasteChild();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.SecsSession)
                    {
                        fDragDropData.refSessionUniqueId = tRefNode.Key;

                        // --

                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsSession)
                        {
                            #region SecsSession

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FSecsSession)fDragDropData.fObject).moveTo((FSecsSession)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FSecsSession)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FSecsSession)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsLibrary)
                        {
                            #region SecsLibrary

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FSecsSession)fRefObject).setLibrary((FSecsLibrary)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsMessageList)
                        {
                            #region SecsMessageList

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FSecsMessageList)fDragDropData.fObject).moveTo(((FSecsSession)fRefObject).fLibrary);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FSecsMessageList)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FSecsSession)fRefObject).fLibrary.pasteChild();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.SecsMessageList)
                    {
                        fDragDropData.refSessionUniqueId = getSecsSessionId(tRefNode.Key);

                        // --

                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsMessageList)
                        {
                            #region SecsMessageList

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FSecsMessageList)fDragDropData.fObject).moveTo((FSecsMessageList)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FSecsMessageList)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FSecsMessageList)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsMessages)
                        {
                            #region SecsMessages

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FSecsMessages)fDragDropData.fObject).moveTo((FSecsMessageList)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FSecsMessages)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FSecsMessageList)fRefObject).pasteChild();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.SecsMessages)
                    {
                        fDragDropData.refSessionUniqueId = getSecsSessionId(tRefNode.Key);

                        // --

                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsMessages)
                        {
                            #region SecsMessages

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FSecsMessages)fDragDropData.fObject).moveTo((FSecsMessages)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FSecsMessages)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FSecsMessages)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsMessage)
                        {
                            #region SecsMessage

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FSecsMessage)fDragDropData.fObject).copy();
                                // --
                                if (((FSecsMessage)fDragDropData.fObject).isPrimary)
                                {
                                    fDragDropData.fObject = ((FSecsMessages)fRefObject).pastePrimarySecsMessage();
                                    fAction = FDragDropAction.Copy;
                                }
                                else
                                {
                                    fDragDropData.fObject = ((FSecsMessages)fRefObject).pasteSecondarySecsMessage();
                                    fAction = FDragDropAction.Copy;
                                }
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.SecsMessage)
                    {
                        fDragDropData.refSessionUniqueId = getSecsSessionId(tRefNode.Key);

                        // --

                        if (fDragDropData.fObject.fObjectType == FObjectType.DataSet)
                        {
                            #region DataSet

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fDataSetGenertor = new FDataSetGenerator(m_fSsmCore, (FDataSet)fDragDropData.fObject, fRefObject);
                                if (fDataSetGenertor.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                                {
                                    return;
                                }
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.SecsItem)
                    {
                        fDragDropData.refSessionUniqueId = getSecsSessionId(tRefNode.Key);

                        // --

                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsItem)
                        {
                            #region SecsItem

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FSecsItem)fDragDropData.fObject).moveTo((FSecsItem)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FSecsItem)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FSecsItem)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.DataConversionSet)
                        {
                            #region DataConversionSet

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FSecsItem)fRefObject).setDataConversionSet((FDataConversionSet)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Data)
                        {
                            #region Data

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FData)fDragDropData.fObject).fTargetType = FDataTargetType.Item;
                                ((FData)fDragDropData.fObject).name = fRefObject.name;
                                ((FData)fDragDropData.fObject).targetItem = fRefObject.name;
                                ((FData)fDragDropData.fObject).fontBold = fRefObject.fontBold;
                                ((FData)fDragDropData.fObject).fontColor = fRefObject.fontColor;
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }

                    #endregion
                }
                else if (fDragDropData.fObjectLog != null)
                {
                    #region FObjectLog

                    if (fRefObject.fObjectType == FObjectType.SecsMessageList)
                    {
                        fDragDropData.refSessionUniqueId = getSecsSessionId(tRefNode.Key);

                        // --

                        if (
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog ||
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog
                            )
                        {
                            #region SecsMessageLog

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fSms = new FSecsMessages(m_fSsmCore.fSsmFileInfo.fSecsDriver);

                                if (fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog)
                                {
                                    ((FSecsDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).copy();
                                    // --
                                    fSms.stream = ((FSecsDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).stream;
                                    fSms.version = ((FSecsDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).version;
                                    fSms.name = ((FSecsDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).name;
                                    fSms.description = ((FSecsDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).description;
                                    // --
                                    if (((FSecsDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).isPrimary)
                                    {
                                        fSms.function = ((FSecsDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).function;
                                        fDragDropData.fObject = fSms.pastePrimarySecsMessage();
                                    }
                                    else
                                    {
                                        fSms.function = ((FSecsDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).function - 1;
                                        fDragDropData.fObject = fSms.pasteSecondarySecsMessage();
                                    }
                                }
                                else
                                {
                                    ((FSecsDeviceDataMessageSentLog)fDragDropData.fObjectLog).copy();
                                    // --
                                    fSms.stream = ((FSecsDeviceDataMessageSentLog)fDragDropData.fObjectLog).stream;
                                    fSms.version = ((FSecsDeviceDataMessageSentLog)fDragDropData.fObjectLog).version;
                                    fSms.name = ((FSecsDeviceDataMessageSentLog)fDragDropData.fObjectLog).name;
                                    fSms.description = ((FSecsDeviceDataMessageSentLog)fDragDropData.fObjectLog).description;
                                    // --
                                    if (((FSecsDeviceDataMessageSentLog)fDragDropData.fObjectLog).isPrimary)
                                    {
                                        fSms.function = ((FSecsDeviceDataMessageSentLog)fDragDropData.fObjectLog).function;
                                        fDragDropData.fObject = fSms.pastePrimarySecsMessage();
                                    }
                                    else
                                    {
                                        fSms.function = ((FSecsDeviceDataMessageSentLog)fDragDropData.fObjectLog).function - 1;
                                        fDragDropData.fObject = fSms.pasteSecondarySecsMessage();
                                    }
                                }

                                // --

                                tvwTree.beginUpdate();

                                // --

                                fSms = ((FSecsMessageList)fRefObject).appendChildSecsMessages(fSms);
                                tNode = new UltraTreeNode(createTreeId(fDragDropData.refSessionUniqueId, fSms.uniqueIdToString));
                                tNode.Tag = fSms;
                                FCommon.refreshTreeNodeOfObject(fSms, tvwTree, tNode);
                                tRefNode.Nodes.Add(tNode);

                                // --

                                fRefObject = fSms;
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }                            

                            #endregion
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.SecsMessages)
                    {
                        fDragDropData.refSessionUniqueId = getSecsSessionId(tRefNode.Key);

                        // --

                        if (
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog ||
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog
                            )
                        {
                            #region SecsMessageLog

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fSms = new FSecsMessages(m_fSsmCore.fSsmFileInfo.fSecsDriver);

                                if (fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog)
                                {
                                    ((FSecsDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).copy();
                                    // --
                                    fSms.stream = ((FSecsDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).stream;
                                    fSms.version = ((FSecsDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).version;
                                    fSms.name = ((FSecsDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).name;
                                    fSms.description = ((FSecsDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).description;
                                    // --
                                    if (((FSecsDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).isPrimary)
                                    {
                                        fSms.function = ((FSecsDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).function;
                                        fDragDropData.fObject = fSms.pastePrimarySecsMessage();
                                    }
                                    else
                                    {
                                        fSms.function = ((FSecsDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).function - 1;
                                        fDragDropData.fObject = fSms.pasteSecondarySecsMessage();
                                    }
                                }
                                else
                                {
                                    ((FSecsDeviceDataMessageSentLog)fDragDropData.fObjectLog).copy();
                                    // --
                                    fSms.stream = ((FSecsDeviceDataMessageSentLog)fDragDropData.fObjectLog).stream;
                                    fSms.version = ((FSecsDeviceDataMessageSentLog)fDragDropData.fObjectLog).version;
                                    fSms.name = ((FSecsDeviceDataMessageSentLog)fDragDropData.fObjectLog).name;
                                    fSms.description = ((FSecsDeviceDataMessageSentLog)fDragDropData.fObjectLog).description;
                                    // --
                                    if (((FSecsDeviceDataMessageSentLog)fDragDropData.fObjectLog).isPrimary)
                                    {
                                        fSms.function = ((FSecsDeviceDataMessageSentLog)fDragDropData.fObjectLog).function;
                                        fDragDropData.fObject = fSms.pastePrimarySecsMessage();
                                    }
                                    else
                                    {
                                        fSms.function = ((FSecsDeviceDataMessageSentLog)fDragDropData.fObjectLog).function - 1;
                                        fDragDropData.fObject = fSms.pasteSecondarySecsMessage();
                                    }
                                }

                                // --

                                tvwTree.beginUpdate();

                                // --

                                fSms = ((FSecsMessages)fRefObject).fParent.insertAfterChildSecsMessages(fSms, (FSecsMessages)fRefObject);
                                tNode = new UltraTreeNode(createTreeId(fDragDropData.refSessionUniqueId, fSms.uniqueIdToString));
                                tNode.Tag = fSms;
                                FCommon.refreshTreeNodeOfObject(fSms, tvwTree, tNode);
                                tRefNode.Parent.Nodes.Insert(tRefNode.Index + 1, tNode);

                                // --

                                fRefObject = fSms;
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }                            

                            #endregion
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.SecsItem)
                    {
                        fDragDropData.refSessionUniqueId = getSecsSessionId(tRefNode.Key);

                        // --

                        if (fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.SecsItemLog)
                        {
                            #region SecsItemLog

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FSecsItemLog)fDragDropData.fObjectLog).copy();
                                fDragDropData.fObject = ((FSecsItem)fRefObject).pasteSibling();
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }

                    #endregion
                }
                else
                {
                    return;
                }                

                // --

                tvwTree.beginUpdate();

                // --

                if (fAction == FDragDropAction.Move || fAction == FDragDropAction.Copy)
                {
                    if (
                        fDragDropData.fObject.fObjectType == FObjectType.SecsDriver ||
                        fDragDropData.fObject.fObjectType == FObjectType.SecsDevice ||
                        fDragDropData.fObject.fObjectType == FObjectType.SecsSession
                        )
                    {
                        uniqueId = fDragDropData.fObject.uniqueIdToString;
                    }
                    else
                    {   
                        uniqueId = createTreeId(fDragDropData.refSessionUniqueId, fDragDropData.fObject.uniqueIdToString);
                    }
                    // --
                    tNode = tvwTree.GetNodeByKey(uniqueId);
                    if (tNode != null)
                    {
                        tNode.Remove();
                    }
                    tNode = new UltraTreeNode(uniqueId);
                    tNode.Tag = fDragDropData.fObject;
                    FCommon.refreshTreeNodeOfObject(fDragDropData.fObject, tvwTree, tNode);
                    loadTreeOfChildObject(tNode);                    
                    
                    // --

                    if (
                        fRefObject.fObjectType == FObjectType.SecsDriver ||
                        fRefObject.fObjectType == FObjectType.SecsDevice ||
                        fRefObject.fObjectType == FObjectType.SecsSession
                        )
                    {
                        refUniqueId = fRefObject.uniqueIdToString;
                    }
                    else
                    {
                        refUniqueId = createTreeId(fDragDropData.refSessionUniqueId, fRefObject.uniqueIdToString);
                    }
                    // --
                    tRefNode = tvwTree.GetNodeByKey(refUniqueId);
                    if (fRefObject.fObjectType == fDragDropData.fObject.fObjectType)
                    {
                        tRefNode.Parent.Nodes.Insert(tRefNode.Index + 1, tNode);
                    }
                    else
                    {
                        tRefNode.Nodes.Add(tNode);
                    }                    
                    // --
                    tvwTree.SelectedNodes.Clear();
                    tvwTree.ActiveNode = tNode;
                }
                else if (fAction == FDragDropAction.Set)
                {
                    if (fRefObject.fObjectType == FObjectType.SecsSession)
                    {
                        changeSecsSessionLibrary((FSecsSession)fRefObject); 
                        // --
                        tRefNode = tvwTree.GetNodeByKey(fRefObject.uniqueIdToString);
                        if (tRefNode != null)
                        {
                            tvwTree.SelectedNodes.Clear();
                            tvwTree.ActiveNode = tRefNode;
                        }
                    }
                    else if (
                        fRefObject.fObjectType == FObjectType.SecsMessage ||
                        fRefObject.fObjectType == FObjectType.SecsItem
                        )
                    {
                        refUniqueId = createTreeId(fDragDropData.refSessionUniqueId, fRefObject.uniqueIdToString);
                        // --
                        tRefNode = tvwTree.GetNodeByKey(refUniqueId);
                        if (tRefNode != null)
                        {
                            tvwTree.SelectedNodes.Clear();
                            tvwTree.ActiveNode = tRefNode;
                        }
                    }
                }

                // --

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fDragDropData = null;
                tRefNode = null;
                tNode = null;
                fRefObject = null;
                fSms = null;
                // --
                if (fDataSetGenertor != null)
                {
                    fDataSetGenertor.Dispose();
                    fDataSetGenertor = null;
                }
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

                if (e.Tool.Key == FMenuKey.MenuSdmOpenSecsDevice)
                {
                    procMenuOpenSecsDevice();
                }
                else if (e.Tool.Key == FMenuKey.MenuSdmCloseSecsDevice)
                {
                    procMenuCloseSecsDevice();
                }                
                // --
                else if (e.Tool.Key == FMenuKey.MenuSdmSendSecsMessage)
                {
                    procMenuSendSecsMessage();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuSdmExpand)
                {
                    procMenuExpand();
                }
                else if (e.Tool.Key == FMenuKey.MenuSdmCollapse)
                {
                    procMenuCollapse();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuSdmGemInspector)
                {
                    procMenuSecsLibraryGemInspector();
                }
                else if (e.Tool.Key == FMenuKey.MenuSdmResetVersion)
                {
                    procMenuResetVersion();
                }
                else if (e.Tool.Key == FMenuKey.MenuSdmReplace)
                {
                    procMenuReplace();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuSdmCut)
                {
                    procMenuCut();
                }
                else if (e.Tool.Key == FMenuKey.MenuSdmCopy)
                {
                    procMenuCopy();
                }
                else if (e.Tool.Key == FMenuKey.MenuSdmPasteSibling)
                {
                    procMenuPasteSibling();
                }
                else if (e.Tool.Key == FMenuKey.MenuSdmPasteChild)
                {
                    procMenuPasteChild();
                }
                else if (e.Tool.Key == FMenuKey.MenuSdmPastePrimarySecsMessage)
                {
                    procMenuPastePrimarySecsMessage();
                }
                else if (e.Tool.Key == FMenuKey.MenuSdmPasteSecondarySecsMessage)
                {
                    procMenuPasteSecondarySecsMessage();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuSdmRemove)
                {
                    procMenuRemoveObject();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuSdmMoveUp)
                {
                    procMenuMoveUpObject(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuSdmMoveDown)
                {
                    procMenuMoveDownObject(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuSdmRelation)
                {
                    procMenuRelation();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuSdmConvertToSml)
                {
                    procMenuSmlViewer();
                }
                else if (e.Tool.Key == FMenuKey.MenuSdmImportStandardSecsMessages)
                {
                    procMenuStandardSecsMessages();
                }
                // --
                else if (
                    e.Tool.Key == FMenuKey.MenuSdmInsertBeforeSecsDevice ||
                    e.Tool.Key == FMenuKey.MenuSdmInsertBeforeSecsSession ||
                    e.Tool.Key == FMenuKey.MenuSdmInsertBeforeSecsMessageList ||
                    e.Tool.Key == FMenuKey.MenuSdmInsertBeforeSecsMessages ||
                    e.Tool.Key == FMenuKey.MenuSdmInsertBeforeSecsItem
                    )
                {
                    procMenuInsertBeforeObject(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuSdmInsertAfterSecsDevice ||
                    e.Tool.Key == FMenuKey.MenuSdmInsertAfterSecsSession ||
                    e.Tool.Key == FMenuKey.MenuSdmInsertAfterSecsMessageList ||
                    e.Tool.Key == FMenuKey.MenuSdmInsertAfterSecsMessages ||
                    e.Tool.Key == FMenuKey.MenuSdmInsertAfterSecsItem
                    )
                {
                    procMenuInsertAfterObject(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuSdmAppendSecsDevice ||
                    e.Tool.Key == FMenuKey.MenuSdmAppendSecsSession ||
                    e.Tool.Key == FMenuKey.MenuSdmAppendSecsMessageList ||
                    e.Tool.Key == FMenuKey.MenuSdmAppendSecsMessages ||
                    e.Tool.Key == FMenuKey.MenuSdmAppendPrimarySecsMessage ||
                    e.Tool.Key == FMenuKey.MenuSdmAppendSecondarySecsMessage ||
                    e.Tool.Key == FMenuKey.MenuSdmAppendSecsItem
                    )
                {
                    procMenuAppendObject(e.Tool.Key);
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

        #region pgdProp Control Event Handler

        private void pgdProp_DynPropNoticeRaised(
            object sender, 
            FDynPropNoticeRaisedEventArgs e            
            )
        {
            try
            {
                if (e.fDynProp is FPropSsn)
                {                    
                    if (e.contents == "LibraryChanged")
                    {
                        changeSecsSessionLibrary(((FPropSsn)e.fDynProp).fSecsSession);                        
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

    }   // Class end
}   // Namespace end
