/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FHostDeviceModeler.cs
--  Creator         : spike.lee
--  Create Date     : 2011.03.15
--  Description     : FAMate SECS Modeler Host Device Modeler Form Class 
--  History         : Created by spike.lee at 2011.03.15
                      Modified by spike.lee at 2012.11.22
                        - Search 관련 코드가 너무 불명확하고 너저분해서 Truning 함.
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
    public partial class FHostDeviceModeler : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSsmCore m_fSsmCore = null;
        private FEventHandler m_fEventHandler = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FHostDeviceModeler(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostDeviceModeler(
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

        private void designTreeOfHostDeviceModeler(
            )
        {
            try
            {
                tvwTree.ImageList = new ImageList();
                // --
                tvwTree.ImageList.Images.Add("SecsDriver", Properties.Resources.SecsDriver);
                tvwTree.ImageList.Images.Add("HostDevice", Properties.Resources.HostDevice);
                tvwTree.ImageList.Images.Add("HostDevice_Closed_unlock", Properties.Resources.HostDevice_Closed_unlock);
                tvwTree.ImageList.Images.Add("HostDevice_Closed_lock", Properties.Resources.HostDevice_Closed_lock);
                tvwTree.ImageList.Images.Add("HostDevice_Opened_unlock", Properties.Resources.HostDevice_Opened_unlock);
                tvwTree.ImageList.Images.Add("HostDevice_Opened_lock", Properties.Resources.HostDevice_Opened_lock);
                tvwTree.ImageList.Images.Add("HostDevice_Connected_unlock", Properties.Resources.HostDevice_Connected_unlock);
                tvwTree.ImageList.Images.Add("HostDevice_Connected_lock", Properties.Resources.HostDevice_Connected_lock);
                tvwTree.ImageList.Images.Add("HostDevice_Selected_unlock", Properties.Resources.HostDevice_Selected_unlock);
                tvwTree.ImageList.Images.Add("HostDevice_Selected_lock", Properties.Resources.HostDevice_Selected_lock);
                tvwTree.ImageList.Images.Add("HostSession_unlock", Properties.Resources.HostSession_unlock);
                tvwTree.ImageList.Images.Add("HostSession_lock", Properties.Resources.HostSession_lock);
                tvwTree.ImageList.Images.Add("HostMessageList_unlock", Properties.Resources.HostMessageList_unlock);
                tvwTree.ImageList.Images.Add("HostMessageList_lock", Properties.Resources.HostMessageList_lock);
                tvwTree.ImageList.Images.Add("HostMessages_Eq_unlock", Properties.Resources.HostMessages_Eq_unlock);
                tvwTree.ImageList.Images.Add("HostMessages_Eq_lock", Properties.Resources.HostMessages_Eq_lock);
                tvwTree.ImageList.Images.Add("HostMessages_Host_unlock", Properties.Resources.HostMessages_Host_unlock);
                tvwTree.ImageList.Images.Add("HostMessages_Host_lock", Properties.Resources.HostMessages_Host_lock);
                tvwTree.ImageList.Images.Add("HostMessages_Both_unlock", Properties.Resources.HostMessages_Both_unlock);
                tvwTree.ImageList.Images.Add("HostMessages_Both_lock", Properties.Resources.HostMessages_Both_lock);
                tvwTree.ImageList.Images.Add("HostMessage_Command_unlock", Properties.Resources.HostMessage_Command_unlock);
                tvwTree.ImageList.Images.Add("HostMessage_Command_lock", Properties.Resources.HostMessage_Command_lock);
                tvwTree.ImageList.Images.Add("HostMessage_Reply_unlock", Properties.Resources.HostMessage_Reply_unlock);
                tvwTree.ImageList.Images.Add("HostMessage_Reply_lock", Properties.Resources.HostMessage_Reply_lock);
                tvwTree.ImageList.Images.Add("HostMessage_Unsolicited_unlock", Properties.Resources.HostMessage_Unsolicited_unlock);
                tvwTree.ImageList.Images.Add("HostMessage_Unsolicited_lock", Properties.Resources.HostMessage_Unsolicited_lock);
                tvwTree.ImageList.Images.Add("HostItem_List_unlock", Properties.Resources.HostItem_List_unlock);
                tvwTree.ImageList.Images.Add("HostItem_List_lock", Properties.Resources.HostItem_List_lock);
                tvwTree.ImageList.Images.Add("HostItem_unlock", Properties.Resources.HostItem_unlock);
                tvwTree.ImageList.Images.Add("HostItem_lock", Properties.Resources.HostItem_lock);
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
                        t.Key == FMenuKey.MenuHdmExpand ||
                        t.Key == FMenuKey.MenuHdmCollapse ||
                        t.Key == FMenuKey.MenuHdmRelation
                        )
                    {
                        continue;
                    }
                    else if (
                        t.Key == FMenuKey.MenuHdmOpenHostDevice ||
                        t.Key == FMenuKey.MenuHdmCloseHostDevice ||
                        t.Key == FMenuKey.MenuHdmSendHostMessage ||
                        t.Key == FMenuKey.MenuHdmReplace ||
                        t.Key == FMenuKey.MenuHdmCut ||
                        t.Key == FMenuKey.MenuHdmCopy ||
                        t.Key == FMenuKey.MenuHdmPasteSibling ||
                        t.Key == FMenuKey.MenuHdmPasteChild ||
                        t.Key == FMenuKey.MenuHdmPastePrimaryHostMessage ||
                        t.Key == FMenuKey.MenuHdmPasteSecondaryHostMessage ||
                        t.Key == FMenuKey.MenuHdmRemove ||
                        t.Key == FMenuKey.MenuHdmMoveUp ||
                        t.Key == FMenuKey.MenuHdmMoveDown ||
                        t.Key == FMenuKey.MenuHdmConvertToVfei ||
                        t.Key == FMenuKey.MenuHdmResetHostDriver
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
                    mnuMenu.Tools[FMenuKey.MenuHdmAppendHostDevice].SharedProps.Visible = ((FSecsDriver)fObject).canAppendChildHostDevice;
                    //--
                    mnuMenu.Tools[FMenuKey.MenuHdmPasteChild].SharedProps.Enabled = ((FSecsDriver)fObject).canPasteChildHostDevice; 
                }
                else if (fObject.fObjectType == FObjectType.HostDevice)
                {
                    if (((FHostDevice)fObject).fState == FDeviceState.Closed)
                    {
                        if (((FHostDevice)fObject).hasDriver)
                        {
                            mnuMenu.Tools[FMenuKey.MenuHdmOpenHostDevice].SharedProps.Enabled = true;
                            mnuMenu.Tools[FMenuKey.MenuHdmResetHostDriver].SharedProps.Enabled = true;
                        }
                    }
                    else
                    {
                        mnuMenu.Tools[FMenuKey.MenuHdmCloseHostDevice].SharedProps.Enabled = true;
                    }       
                    // --
                    mnuMenu.Tools[FMenuKey.MenuHdmInsertBeforeHostDevice].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuHdmInsertAfterHostDevice].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuHdmAppendHostSession].SharedProps.Visible = fObject.canAppendChild;                    
                }
                else if (fObject.fObjectType == FObjectType.HostSession)
                {
                    mnuMenu.Tools[FMenuKey.MenuHdmInsertBeforeHostSession].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuHdmInsertAfterHostSession].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuHdmAppendHostMessageList].SharedProps.Visible = ((FHostSession)fObject).hasLibrary;
                }
                else if (fObject.fObjectType == FObjectType.HostMessageList)
                {
                    mnuMenu.Tools[FMenuKey.MenuHdmInsertBeforeHostMessageList].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuHdmInsertAfterHostMessageList].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuHdmAppendHostMessages].SharedProps.Visible = fObject.canAppendChild;
                }
                else if (fObject.fObjectType == FObjectType.HostMessages)
                {
                    mnuMenu.Tools[FMenuKey.MenuHdmInsertBeforeHostMessages].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuHdmInsertAfterHostMessages].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuHdmAppendPrimaryHostMessage].SharedProps.Visible = ((FHostMessages)fObject).canAppendChildPrimaryHostMessage;
                    if (((FHostMessages)fObject).canAppendChildSecondaryHostMessage)
                    {
                        mnuMenu.Tools[FMenuKey.MenuHdmAppendSecondaryHostMessage].SharedProps.Visible = true;
                        // --
                        mnuMenu.Toolbars[0].Tools[FMenuKey.MenuHdmAppendSecondaryHostMessage].InstanceProps.IsFirstInGroup = !((FHostMessages)fObject).canAppendChildPrimaryHostMessage;
                        ((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuHdmPopupMenu]).Tools[FMenuKey.MenuHdmAppendSecondaryHostMessage].InstanceProps.IsFirstInGroup = !((FHostMessages)fObject).canAppendChildPrimaryHostMessage;
                    }

                    // -- 

                    if (((FHostDevice)tvwTree.ActiveNode.Parent.Parent.Parent.Tag).fState == FDeviceState.Selected)
                    {
                        foreach (FHostMessage fHmg in ((FHostMessages)tvwTree.ActiveNode.Tag).fChildHostMessageCollection)
                        {
                            if (fHmg.isPrimary)
                            {
                                mnuMenu.Tools[FMenuKey.MenuHdmSendHostMessage].SharedProps.Enabled = true;
                                break;
                            }
                        }
                    }

                    // --

                    mnuMenu.Tools[FMenuKey.MenuHdmConvertToVfei].SharedProps.Enabled = true;
                }
                else if (fObject.fObjectType == FObjectType.HostMessage)
                {
                    if (((FHostDevice)tvwTree.ActiveNode.Parent.Parent.Parent.Parent.Tag).fState == FDeviceState.Selected)
                    {
                        mnuMenu.Tools[FMenuKey.MenuHdmSendHostMessage].SharedProps.Enabled = true;
                    }
                    // --
                    mnuMenu.Tools[FMenuKey.MenuHdmAppendHostItem].SharedProps.Visible = fObject.canAppendChild;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuHdmConvertToVfei].SharedProps.Enabled = true;
                }
                else if (fObject.fObjectType == FObjectType.HostItem)
                {
                    mnuMenu.Tools[FMenuKey.MenuHdmInsertBeforeHostItem].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuHdmInsertAfterHostItem].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuHdmAppendHostItem].SharedProps.Visible = fObject.canAppendChild;                    
                }

                // --

                if (
                    fObject.fObjectType == FObjectType.HostDevice ||
                    fObject.fObjectType == FObjectType.HostSession ||
                    fObject.fObjectType == FObjectType.HostMessageList ||
                    fObject.fObjectType == FObjectType.HostMessages ||
                    fObject.fObjectType == FObjectType.HostMessage ||
                    fObject.fObjectType == FObjectType.HostItem
                    )
                {
                    mnuMenu.Tools[FMenuKey.MenuHdmPasteSibling].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuHdmPasteChild].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuHdmPastePrimaryHostMessage].SharedProps.Visible = false;
                    mnuMenu.Tools[FMenuKey.MenuHdmPasteSecondaryHostMessage].SharedProps.Visible = false;
                    // -
                    mnuMenu.Tools[FMenuKey.MenuHdmRemove].SharedProps.Enabled = fObject.canRemove;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuHdmMoveUp].SharedProps.Enabled = fObject.canMoveUp;
                    mnuMenu.Tools[FMenuKey.MenuHdmMoveDown].SharedProps.Enabled = fObject.canMoveDown;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuHdmCut].SharedProps.Enabled = fObject.canCut;
                    mnuMenu.Tools[FMenuKey.MenuHdmCopy].SharedProps.Enabled = fObject.canCopy;
                    mnuMenu.Tools[FMenuKey.MenuHdmPasteSibling].SharedProps.Enabled = fObject.canPasteSibling;
                    if (fObject.fObjectType == FObjectType.HostSession)
                    {
                        mnuMenu.Tools[FMenuKey.MenuHdmPasteChild].SharedProps.Enabled =
                            ((FHostSession)fObject).hasLibrary ? fObject.canPasteChild : false;
                    }
                    else
                    {
                        mnuMenu.Tools[FMenuKey.MenuHdmPasteChild].SharedProps.Enabled = fObject.canPasteChild;
                    }
                }

                // --

                if (fObject.fObjectType == FObjectType.HostMessages)
                {
                    if (
                        ((FHostMessages)fObject).canPastePrimaryHostMessage ||
                        ((FHostMessages)fObject).canPasteSecondaryHostMessage
                        )
                    {
                        mnuMenu.Tools[FMenuKey.MenuHdmPasteSibling].SharedProps.Visible = false;
                        mnuMenu.Tools[FMenuKey.MenuHdmPasteChild].SharedProps.Visible = false;
                        mnuMenu.Tools[FMenuKey.MenuHdmPastePrimaryHostMessage].SharedProps.Visible = true;
                        mnuMenu.Tools[FMenuKey.MenuHdmPasteSecondaryHostMessage].SharedProps.Visible = true;
                    }                    
                    // --
                    mnuMenu.Tools[FMenuKey.MenuHdmPastePrimaryHostMessage].SharedProps.Enabled = ((FHostMessages)fObject).canPastePrimaryHostMessage;
                    mnuMenu.Tools[FMenuKey.MenuHdmPasteSecondaryHostMessage].SharedProps.Enabled = ((FHostMessages)fObject).canPasteSecondaryHostMessage;                    
                }

                // --

                // ***
                // 2016.04.26 by spike.lee
                // Replace Menu 제어
                // ***
                if (
                    fObject.fObjectType == FObjectType.HostMessages ||
                    fObject.fObjectType == FObjectType.HostMessage ||
                    fObject.fObjectType == FObjectType.HostItem
                    )
                {
                    mnuMenu.Tools[FMenuKey.MenuHdmReplace].SharedProps.Enabled = true;
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

        private string createTreeId(
            string hsnUniqueId,
            string objUniqueId
            )
        {
            try
            {
                return hsnUniqueId + "-" + objUniqueId;
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

        private string getHostSessionId(
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
            UltraTreeNode tNodeHcd = null;
            UltraTreeNode tNodeHdv = null;
            UltraTreeNode tNodeHsn = null;
            UltraTreeNode tNodeHml = null;
            UltraTreeNode tNodeHms = null;
            UltraTreeNode tNodeHmg = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                // ***
                // SECS Driver Load
                // ***
                fScd = m_fSsmCore.fSsmFileInfo.fSecsDriver;
                tNodeHcd = new UltraTreeNode(fScd.uniqueIdToString);
                tNodeHcd.Tag = fScd;
                FCommon.refreshTreeNodeOfObject(fScd, tvwTree, tNodeHcd);

                // --

                // ***
                // Host Device Load
                // ***
                foreach (FHostDevice fHdv in fScd.fChildHostDeviceCollection)
                {
                    tNodeHdv = new UltraTreeNode(fHdv.uniqueIdToString);
                    tNodeHdv.Tag = fHdv;
                    FCommon.refreshTreeNodeOfObject(fHdv, tvwTree, tNodeHdv);

                    // --

                    // ***
                    // Host Session Load
                    // ***
                    foreach (FHostSession fHsn in fHdv.fChildHostSessionCollection)
                    {
                        tNodeHsn = new UltraTreeNode(fHsn.uniqueIdToString);
                        tNodeHsn.Tag = fHsn;
                        FCommon.refreshTreeNodeOfObject(fHsn, tvwTree, tNodeHsn);

                        // --

                        // ***
                        // Host Message List, Host Messages, Host Item 개체의 Tree Node ID는
                        // Host Session 개체의 ID와 해당 개체의 ID를 조합으로 구성한다.
                        // (HostSessionUniqueID + "-" + ObjectUniqueID)
                        // ***
                        if (fHsn.hasLibrary)
                        {
                            // ***
                            // Host Message List Load
                            // *** 
                            foreach (FHostMessageList fHml in fHsn.fLibrary.fChildHostMessageListCollection)
                            {
                                tNodeHml = new UltraTreeNode(createTreeId(fHsn.uniqueIdToString, fHml.uniqueIdToString));
                                tNodeHml.Tag = fHml;
                                FCommon.refreshTreeNodeOfObject(fHml, tvwTree, tNodeHml);

                                // --

                                // ***
                                // Host Messages Load
                                // ***
                                foreach (FHostMessages fHms in fHml.fChildHostMessagesCollection)
                                {
                                    tNodeHms = new UltraTreeNode(createTreeId(fHsn.uniqueIdToString, fHms.uniqueIdToString));
                                    tNodeHms.Tag = fHms;
                                    FCommon.refreshTreeNodeOfObject(fHms, tvwTree, tNodeHms);

                                    // --

                                    // ***
                                    // Host Message Load
                                    // ***
                                    foreach (FHostMessage fHmg in fHms.fChildHostMessageCollection)
                                    {
                                        tNodeHmg = new UltraTreeNode(createTreeId(fHsn.uniqueIdToString, fHmg.uniqueIdToString));
                                        tNodeHmg.Tag = fHmg;
                                        FCommon.refreshTreeNodeOfObject(fHmg, tvwTree, tNodeHmg);
                                        // --
                                        tNodeHmg.Expanded = false;
                                        tNodeHms.Nodes.Add(tNodeHmg);
                                    }

                                    // --

                                    tNodeHms.Expanded = false;
                                    tNodeHml.Nodes.Add(tNodeHms);
                                }

                                // --

                                tNodeHml.Expanded = true;
                                tNodeHsn.Nodes.Add(tNodeHml);
                            }
                        }

                        // --

                        tNodeHsn.Expanded = true;
                        tNodeHdv.Nodes.Add(tNodeHsn);
                    }

                    // --

                    tNodeHdv.Expanded = true;
                    tNodeHcd.Nodes.Add(tNodeHdv);
                }

                // --

                tNodeHcd.Expanded = true;
                tvwTree.Nodes.Add(tNodeHcd);
                tvwTree.ActiveNode = tNodeHcd;

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
                tNodeHcd = null;
                tNodeHdv = null;
                tNodeHsn = null;
                tNodeHml = null;
                tNodeHms = null;
                tNodeHmg = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfChildObject(
            UltraTreeNode tNodeParent
            )
        {
            FIObject fParent = null;
            UltraTreeNode tNodeChild = null;
            string hsnUniqueId = string.Empty;

            try
            {
                tvwTree.beginUpdate();

                // --

                fParent = (FIObject)tNodeParent.Tag;
                // --
                if (fParent.fObjectType == FObjectType.SecsDriver)
                {
                    foreach (FHostDevice fHdv in ((FSecsDriver)fParent).fChildHostDeviceCollection)
                    {
                        tNodeChild = new UltraTreeNode(fHdv.uniqueIdToString);
                        tNodeChild.Tag = fHdv;
                        FCommon.refreshTreeNodeOfObject(fHdv, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.HostDevice)
                {
                    foreach (FHostSession fHsn in ((FHostDevice)fParent).fChildHostSessionCollection)
                    {
                        tNodeChild = new UltraTreeNode(fHsn.uniqueIdToString);
                        tNodeChild.Tag = fHsn;
                        FCommon.refreshTreeNodeOfObject(fHsn, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.HostSession)
                {
                    if (((FHostSession)fParent).hasLibrary)
                    {
                        hsnUniqueId = ((FHostSession)fParent).uniqueIdToString;
                        foreach (FHostMessageList fHml in (((FHostSession)fParent).fLibrary.fChildHostMessageListCollection))
                        {
                            tNodeChild = new UltraTreeNode(createTreeId(hsnUniqueId, fHml.uniqueIdToString));
                            tNodeChild.Tag = fHml;
                            FCommon.refreshTreeNodeOfObject(fHml, tvwTree, tNodeChild);
                            tNodeParent.Nodes.Add(tNodeChild);
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.HostMessageList)
                {
                    hsnUniqueId = getHostSessionId(tNodeParent.Key);
                    foreach (FHostMessages fHms in ((FHostMessageList)fParent).fChildHostMessagesCollection)
                    {
                        tNodeChild = new UltraTreeNode(createTreeId(hsnUniqueId, fHms.uniqueIdToString));
                        tNodeChild.Tag = fHms;
                        FCommon.refreshTreeNodeOfObject(fHms, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.HostMessages)
                {
                    hsnUniqueId = getHostSessionId(tNodeParent.Key);
                    foreach (FHostMessage fHmg in ((FHostMessages)fParent).fChildHostMessageCollection)
                    {
                        tNodeChild = new UltraTreeNode(createTreeId(hsnUniqueId, fHmg.uniqueIdToString));
                        tNodeChild.Tag = fHmg;
                        FCommon.refreshTreeNodeOfObject(fHmg, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.HostMessage)
                {
                    hsnUniqueId = getHostSessionId(tNodeParent.Key);
                    foreach (FHostItem fHit in ((FHostMessage)fParent).fChildHostItemCollection)
                    {
                        tNodeChild = new UltraTreeNode(createTreeId(hsnUniqueId, fHit.uniqueIdToString));
                        tNodeChild.Tag = fHit;
                        FCommon.refreshTreeNodeOfObject(fHit, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.HostItem)
                {
                    hsnUniqueId = getHostSessionId(tNodeParent.Key);
                    foreach (FHostItem fHit in ((FHostItem)fParent).fChildHostItemCollection)
                    {
                        tNodeChild = new UltraTreeNode(createTreeId(hsnUniqueId, fHit.uniqueIdToString));
                        tNodeChild.Tag = fHit;
                        FCommon.refreshTreeNodeOfObject(fHit, tvwTree, tNodeChild);
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

                if (fNewChild.fObjectType == FObjectType.HostDevice)
                {
                    tNodeParent = tvwTree.GetNodeByKey(fParent.uniqueIdToString);                    
                    fRefChild = ((FHostDevice)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.HostSession)
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
                    fRefChild = ((FHostSession)fNewChild).fNextSibling;
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
            FHostLibrary fHlb = null;
            FIObject fRefChild = null;
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeNewChild = null;
            UltraTreeNode tNodeRefChild = null;
            string uniqueId = string.Empty;

            try
            {
                if (fNewChild.fObjectType == FObjectType.HostMessageList)
                {
                    fHlb = ((FHostMessageList)fNewChild).fAncestorHostLibrary;
                }
                else if (fNewChild.fObjectType == FObjectType.HostMessages)
                {
                    fHlb = ((FHostMessages)fNewChild).fAncestorHostLibrary;
                }
                else if (fNewChild.fObjectType == FObjectType.HostMessage)
                {
                    fHlb = ((FHostMessage)fNewChild).fAncestorHostLibrary;
                }
                else if (fNewChild.fObjectType == FObjectType.HostItem)
                {
                    fHlb = ((FHostItem)fNewChild).fAncestorHostLibrary;
                }
                else
                {
                    return;
                }

                // --

                tvwTree.beginUpdate();

                // --

                foreach (FHostDevice fHdv in this.m_fSsmCore.fSsmFileInfo.fSecsDriver.fChildHostDeviceCollection)
                {
                    foreach (FHostSession fHsn in fHdv.fChildHostSessionCollection)
                    {
                        if (fHsn.fLibrary != fHlb)
                        {
                            continue;
                        }

                        // --

                        uniqueId = createTreeId(fHsn.uniqueIdToString, fNewChild.uniqueIdToString);
                        tNodeNewChild = tvwTree.GetNodeByKey(uniqueId);
                        if (tNodeNewChild != null)
                        {
                            continue;
                        }

                        // --

                        if (fNewChild.fObjectType == FObjectType.HostMessageList)
                        {
                            tNodeParent = tvwTree.GetNodeByKey(fHsn.uniqueIdToString);
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
                            fRefChild = ((FHostMessageList)fNewChild).fNextSibling;
                        }
                        else if (fNewChild.fObjectType == FObjectType.HostMessages)
                        {
                            tNodeParent = tvwTree.GetNodeByKey(createTreeId(fHsn.uniqueIdToString, fParent.uniqueIdToString));
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
                            fRefChild = ((FHostMessages)fNewChild).fNextSibling;
                        }
                        else if (fNewChild.fObjectType == FObjectType.HostMessage)
                        {
                            tNodeParent = tvwTree.GetNodeByKey(createTreeId(fHsn.uniqueIdToString, fParent.uniqueIdToString));
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
                            fRefChild = ((FHostMessage)fNewChild).fNextSibling;
                        }
                        else if (fNewChild.fObjectType == FObjectType.HostItem)
                        {
                            tNodeParent = tvwTree.GetNodeByKey(createTreeId(fHsn.uniqueIdToString, fParent.uniqueIdToString));
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
                            fRefChild = ((FHostItem)fNewChild).fNextSibling;
                        }

                        // --

                        tNodeNewChild = new UltraTreeNode(uniqueId);
                        tNodeNewChild.Tag = fNewChild;
                        FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNodeNewChild);

                        // --

                        if (fRefChild != null)
                        {
                            tNodeRefChild = tvwTree.GetNodeByKey(createTreeId(fHsn.uniqueIdToString, fRefChild.uniqueIdToString));
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
                fHlb = null;
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

                foreach (FHostDevice fHdv in this.m_fSsmCore.fSsmFileInfo.fSecsDriver.fChildHostDeviceCollection)
                {
                    foreach (FHostSession fHsn in fHdv.fChildHostSessionCollection)
                    {
                        tNodeChild = tvwTree.GetNodeByKey(createTreeId(fHsn.uniqueIdToString, fChild.uniqueIdToString));
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

                if (fObject.fObjectType == FObjectType.HostDevice)
                {
                    if (((FHostDevice)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FHostDevice)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.HostSession)
                {
                    if (((FHostSession)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FHostSession)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
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

                foreach (FHostDevice fHdv in this.m_fSsmCore.fSsmFileInfo.fSecsDriver.fChildHostDeviceCollection)
                {
                    foreach (FHostSession fHsn in fHdv.fChildHostSessionCollection)
                    {
                        tNode = tvwTree.GetNodeByKey(createTreeId(fHsn.uniqueIdToString, fObject.uniqueIdToString));
                        if (tNode == null)
                        {
                            continue;
                        }
                        tPrevNode = tNode.GetSibling(NodePosition.Previous);

                        // --
                                                
                        if (fObject.fObjectType == FObjectType.HostMessageList)
                        {
                            if (((FHostMessageList)fObject).fPreviousSibling == null)
                            {
                                if (tPrevNode == null)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                if (((FHostMessageList)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                                {
                                    continue;
                                }
                            }
                        }
                        else if (fObject.fObjectType == FObjectType.HostMessages)
                        {
                            if (((FHostMessages)fObject).fPreviousSibling == null)
                            {
                                if (tPrevNode == null)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                if (((FHostMessages)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                                {
                                    continue;
                                }
                            }
                        }
                        else if (fObject.fObjectType == FObjectType.HostMessage)
                        {
                            if (((FHostMessage)fObject).fPreviousSibling == null)
                            {
                                if (tPrevNode == null)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                if (((FHostMessage)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                                {
                                    continue;
                                }
                            }
                        }
                        else if (fObject.fObjectType == FObjectType.HostItem)
                        {
                            if (((FHostItem)fObject).fPreviousSibling == null)
                            {
                                if (tPrevNode == null)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                if (((FHostItem)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
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

                if (fObject.fObjectType == FObjectType.HostDevice)
                {
                    if (((FHostDevice)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FHostDevice)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.HostSession)
                {
                    if (((FHostSession)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FHostSession)fObject).fNextSibling == (FIObject)tNextNode.Tag)
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

                foreach (FHostDevice fHdv in this.m_fSsmCore.fSsmFileInfo.fSecsDriver.fChildHostDeviceCollection)
                {
                    foreach (FHostSession fHsn in fHdv.fChildHostSessionCollection)
                    {
                        tNode = tvwTree.GetNodeByKey(createTreeId(fHsn.uniqueIdToString, fObject.uniqueIdToString));
                        if (tNode == null)
                        {
                            continue;
                        }
                        tNextNode = tNode.GetSibling(NodePosition.Next);

                        // --
                                                
                        if (fObject.fObjectType == FObjectType.HostMessageList)
                        {
                            if (((FHostMessageList)fObject).fNextSibling == null)
                            {
                                if (tNextNode == null)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                if (((FHostMessageList)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                                {
                                    continue;
                                }
                            }
                        }
                        else if (fObject.fObjectType == FObjectType.HostMessages)
                        {
                            if (((FHostMessages)fObject).fNextSibling == null)
                            {
                                if (tNextNode == null)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                if (((FHostMessages)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                                {
                                    continue;
                                }
                            }
                        }
                        else if (fObject.fObjectType == FObjectType.HostMessage)
                        {
                            if (((FHostMessage)fObject).fNextSibling == null)
                            {
                                if (tNextNode == null)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                if (((FHostMessage)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                                {
                                    continue;
                                }
                            }
                        }
                        else if (fObject.fObjectType == FObjectType.HostItem)
                        {
                            if (((FHostItem)fObject).fNextSibling == null)
                            {
                                if (tNextNode == null)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                if (((FHostItem)fObject).fNextSibling == (FIObject)tNextNode.Tag)
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
            FHostLibrary fHlb = null;
            UltraTreeNode tRefNode = null;
            UltraTreeNode tNode = null;

            try
            {
                if (fObject.fObjectType == FObjectType.HostMessageList)
                {
                    fHlb = ((FHostMessageList)fObject).fAncestorHostLibrary;
                }
                else if (fObject.fObjectType == FObjectType.HostMessages)
                {
                    fHlb = ((FHostMessages)fObject).fAncestorHostLibrary;
                }
                else if (fObject.fObjectType == FObjectType.HostMessage)
                {
                    fHlb = ((FHostMessage)fObject).fAncestorHostLibrary;
                }
                else if (fObject.fObjectType == FObjectType.HostItem)
                {
                    fHlb = ((FHostItem)fObject).fAncestorHostLibrary;
                }
                else
                {
                    return;
                }

                // --

                tvwTree.beginUpdate();

                // --

                foreach (FHostDevice fHdv in this.m_fSsmCore.fSsmFileInfo.fSecsDriver.fChildHostDeviceCollection)
                {
                    foreach (FHostSession fHsn in fHdv.fChildHostSessionCollection)
                    {
                        if (fHsn.fLibrary != fHlb)
                        {
                            continue;
                        }

                        // --

                        if (fRefObject.fObjectType == FObjectType.HostSession)
                        {
                            tRefNode = tvwTree.GetNodeByKey(fHsn.uniqueIdToString);
                        }
                        else
                        {
                            tRefNode = tvwTree.GetNodeByKey(createTreeId(fHsn.uniqueIdToString, fRefObject.uniqueIdToString));
                        }
                        tNode = tvwTree.GetNodeByKey(createTreeId(fHsn.uniqueIdToString, fObject.uniqueIdToString));

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
                                tNode = new UltraTreeNode(createTreeId(fHsn.uniqueIdToString, fObject.uniqueIdToString));
                                tNode.Tag = fObject;
                                FCommon.refreshTreeNodeOfObject(fObject, tvwTree, tNode);

                                // --

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
                fHlb = null;
                tRefNode = null;
                tNode = null;
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

                foreach (FHostDevice fHdv in this.m_fSsmCore.fSsmFileInfo.fSecsDriver.fChildHostDeviceCollection)
                {
                    foreach (FHostSession fHsn in fHdv.fChildHostSessionCollection)
                    {
                        tNode = tvwTree.GetNodeByKey(createTreeId(fHsn.uniqueIdToString, fObject.uniqueIdToString));
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

        private void changeHostSessionLibrary(
            FHostSession fHsn
            )
        {
            UltraTreeNode tNodeHsn = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                tNodeHsn = tvwTree.GetNodeByKey(fHsn.uniqueIdToString);
                tNodeHsn.Expanded = false;
                tNodeHsn.Nodes.Clear();

                // --

                if (fHsn.hasLibrary)
                {
                    loadTreeOfChildObject(tNodeHsn);

                    // --
                    tNodeHsn.Expanded = true;
                    foreach (UltraTreeNode tNodeHml in tNodeHsn.Nodes)
                    {
                        tNodeHml.Expanded = true;
                        foreach (UltraTreeNode tNodeHms in tNodeHml.Nodes)
                        {
                            tNodeHms.Expanded = false;
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
                tNodeHsn = null;
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
                    fNewChild = ((FSecsDriver)fParent).appendChildHostDevice(new FHostDevice(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                    uniqueId = fNewChild.uniqueIdToString;
                }
                else if (fParent.fObjectType == FObjectType.HostDevice)
                {
                    fNewChild = ((FHostDevice)fParent).appendChildHostSession(new FHostSession(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                    uniqueId = fNewChild.uniqueIdToString;
                }
                else if (fParent.fObjectType == FObjectType.HostSession)
                {
                    fNewChild = ((FHostSession)fParent).fLibrary.appendChildHostMessageList(new FHostMessageList(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                    uniqueId = createTreeId(tNodeParent.Key, fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.HostMessageList)
                {
                    fNewChild = ((FHostMessageList)fParent).appendChildHostMessages(new FHostMessages(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                    uniqueId = createTreeId(getHostSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.HostMessages)
                {
                    if (menuKey == FMenuKey.MenuHdmAppendPrimaryHostMessage)
                    {
                        fNewChild = ((FHostMessages)fParent).appendChildPrimaryHostMessage(new FHostMessage(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                    }
                    else
                    {
                        fNewChild = ((FHostMessages)fParent).appendChildSecondaryHostMessage(new FHostMessage(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                    }
                    uniqueId = createTreeId(getHostSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.HostMessage)
                {
                    fNewChild = ((FHostMessage)fParent).appendChildHostItem(new FHostItem(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                    uniqueId = createTreeId(getHostSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.HostItem)
                {
                    fNewChild = new FHostItem(this.m_fSsmCore.fSsmFileInfo.fSecsDriver);
                    if (((FHostItem)fParent).fFormat == FFormat.AsciiList)
                    {
                        ((FHostItem)fNewChild).fFormat = FFormat.Ascii;
                    }
                    fNewChild = ((FHostItem)fParent).appendChildHostItem((FHostItem)fNewChild);
                    uniqueId = createTreeId(getHostSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);

                }

                // --

                tNodeNewChild = new UltraTreeNode(uniqueId);
                tNodeNewChild.Tag = fNewChild;
                FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNodeNewChild);
                // --
                if (fParent.fObjectType == FObjectType.HostMessages)
                {
                    if (((FHostMessage)fNewChild).isPrimary)
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
                    fNewChild = ((FSecsDriver)fParent).insertBeforeChildHostDevice(
                        new FHostDevice(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FHostDevice)fRefChild
                        );
                    uniqueId = fNewChild.uniqueIdToString;
                }
                else if (fParent.fObjectType == FObjectType.HostDevice)
                {
                    fNewChild = ((FHostDevice)fParent).insertBeforeChildHostSession(
                        new FHostSession(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FHostSession)fRefChild
                        );
                    uniqueId = fNewChild.uniqueIdToString;
                }
                else if (fParent.fObjectType == FObjectType.HostSession)
                {
                    fNewChild = ((FHostSession)fParent).fLibrary.insertBeforeChildHostMessageList(
                        new FHostMessageList(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FHostMessageList)fRefChild
                        );
                    uniqueId = createTreeId(tNodeParent.Key, fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.HostMessageList)
                {
                    fNewChild = ((FHostMessageList)fParent).insertBeforeChildHostMessages(
                        new FHostMessages(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FHostMessages)fRefChild
                        );
                    uniqueId = createTreeId(getHostSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.HostMessages)
                {
                    // ***
                    // 사용안함.
                    // ***
                }
                else if (fParent.fObjectType == FObjectType.HostMessage)
                {
                    fNewChild = ((FHostMessage)fParent).insertBeforeChildHostItem(
                        new FHostItem(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FHostItem)fRefChild
                        );
                    uniqueId = createTreeId(getHostSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.HostItem)
                {
                    fNewChild = new FHostItem(this.m_fSsmCore.fSsmFileInfo.fSecsDriver);
                    if (((FHostItem)fParent).fFormat == FFormat.AsciiList)
                    {
                        ((FHostItem)fNewChild).fFormat = FFormat.Ascii;
                    }
                    fNewChild = ((FHostItem)fParent).insertBeforeChildHostItem((FHostItem)fNewChild, (FHostItem)fRefChild);
                    uniqueId = createTreeId(getHostSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
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
                    fNewChild = ((FSecsDriver)fParent).insertAfterChildHostDevice(
                        new FHostDevice(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FHostDevice)fRefChild
                        );
                    uniqueId = fNewChild.uniqueIdToString;
                }
                else if (fParent.fObjectType == FObjectType.HostDevice)
                {
                    fNewChild = ((FHostDevice)fParent).insertAfterChildHostSession(
                        new FHostSession(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FHostSession)fRefChild
                        );
                    uniqueId = fNewChild.uniqueIdToString;
                }
                else if (fParent.fObjectType == FObjectType.HostSession)
                {
                    fNewChild = ((FHostSession)fParent).fLibrary.insertAfterChildHostMessageList(
                        new FHostMessageList(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FHostMessageList)fRefChild
                        );
                    uniqueId = createTreeId(tNodeParent.Key, fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.HostMessageList)
                {
                    fNewChild = ((FHostMessageList)fParent).insertAfterChildHostMessages(
                        new FHostMessages(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FHostMessages)fRefChild
                        );
                    uniqueId = createTreeId(getHostSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.HostMessages)
                {
                    // ***
                    // 사용안함.
                    // ***
                }
                else if (fParent.fObjectType == FObjectType.HostMessage)
                {
                    fNewChild = ((FHostMessage)fParent).insertAfterChildHostItem(
                        new FHostItem(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FHostItem)fRefChild
                        );
                    uniqueId = createTreeId(getHostSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.HostItem)
                {
                    fNewChild = new FHostItem(this.m_fSsmCore.fSsmFileInfo.fSecsDriver);
                    if (((FHostItem)fParent).fFormat == FFormat.AsciiList)
                    {
                        ((FHostItem)fNewChild).fFormat = FFormat.Ascii;
                    }
                    fNewChild = ((FHostItem)fParent).insertAfterChildHostItem((FHostItem)fNewChild, (FHostItem)fRefChild);
                    uniqueId = createTreeId(getHostSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
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
            string hsnUniqueId = string.Empty;

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
                        if (((FHostDevice)fChild).locked)
                        {
                            FDebug.throwFException(m_fSsmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.HostDevice)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FHostSession)fChild).locked)
                        {
                            FDebug.throwFException(m_fSsmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.HostSession)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FHostMessageList)fChild).locked)
                        {
                            FDebug.throwFException(m_fSsmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.HostMessageList)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FHostMessages)fChild).locked)
                        {
                            FDebug.throwFException(m_fSsmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.HostMessages)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FHostMessage)fChild).locked)
                        {
                            FDebug.throwFException(m_fSsmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.HostMessage)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FHostItem)fChild).locked)
                        {
                            FDebug.throwFException(m_fSsmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.HostItem)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FHostItem)fChild).locked)
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
                    fChilds = new FHostDevice[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FHostDevice)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FSecsDriver)fParent).removeChildHostDevice((FHostDevice[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.HostDevice)
                {
                    fChilds = new FHostSession[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FHostSession)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FHostDevice)fParent).removeChildHostSession((FHostSession[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.HostSession)
                {
                    fChilds = new FHostMessageList[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FHostMessageList)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FHostSession)fParent).fLibrary.removeChildHostMessageList((FHostMessageList[])fChilds);
                    hsnUniqueId = tNodeParent.Key;
                }
                else if (fParent.fObjectType == FObjectType.HostMessageList)
                {
                    fChilds = new FHostMessages[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FHostMessages)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FHostMessageList)fParent).removeChildHostMessages((FHostMessages[])fChilds);
                    hsnUniqueId = getHostSessionId(tNodeParent.Key);
                }
                else if (fParent.fObjectType == FObjectType.HostMessages)
                {
                    fChilds = new FHostMessage[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FHostMessage)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FHostMessages)fParent).removeChildHostMessage((FHostMessage[])fChilds);
                    hsnUniqueId = getHostSessionId(tNodeParent.Key);
                }
                else if (fParent.fObjectType == FObjectType.HostMessage)
                {
                    fChilds = new FHostItem[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FHostItem)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FHostMessage)fParent).removeChildHostItem((FHostItem[])fChilds);
                    hsnUniqueId = getHostSessionId(tNodeParent.Key);
                }
                else if (fParent.fObjectType == FObjectType.HostItem)
                {
                    fChilds = new FHostItem[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FHostItem)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FHostItem)fParent).removeChildHostItem((FHostItem[])fChilds);
                    hsnUniqueId = getHostSessionId(tNodeParent.Key);
                }

                // --

                tvwTree.beginUpdate();

                // --

                if (hsnUniqueId == string.Empty)
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
                        tvwTree.GetNodeByKey(createTreeId(hsnUniqueId, f.uniqueIdToString)).Remove();
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

                if (fObject.fObjectType == FObjectType.HostDevice)
                {
                    ((FHostDevice)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.HostSession)
                {
                    ((FHostSession)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.HostMessageList)
                {
                    ((FHostMessageList)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.HostMessages)
                {
                    ((FHostMessages)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.HostMessage)
                {
                    
                }
                else if (fObject.fObjectType == FObjectType.HostItem)
                {
                    ((FHostItem)fObject).moveUp();
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

                if (fObject.fObjectType == FObjectType.HostDevice)
                {
                    ((FHostDevice)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.HostSession)
                {
                    ((FHostSession)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.HostMessageList)
                {
                    ((FHostMessageList)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.HostMessages)
                {
                    ((FHostMessages)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.HostMessage)
                {
                    
                }
                else if (fObject.fObjectType == FObjectType.HostItem)
                {
                    ((FHostItem)fObject).moveDown();
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

        private void procMenuResetHostDriver(
            )
        {
            FHostDevice fHostDevice = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                fHostDevice = (FHostDevice)tvwTree.ActiveNode.Tag;
                fHostDevice.resetHostDriver();

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
                fHostDevice = null;
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
                    foreach (UltraTreeNode tNodeHdv in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeHdv.Expanded = true;
                        // --
                        foreach (UltraTreeNode tNodeHsn in tNodeHdv.Nodes)
                        {
                            tNodeHsn.Expanded = true;
                            // --
                            foreach (UltraTreeNode tNodeHml in tNodeHsn.Nodes)
                            {
                                tNodeHml.Expanded = true;
                                // --
                                foreach (UltraTreeNode tNodeHms in tNodeHml.Nodes)
                                {
                                    tNodeHms.Expanded = true;
                                }
                            }
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.HostDevice)
                {
                    tvwTree.ActiveNode.Expanded = true;
                    // --
                    foreach (UltraTreeNode tNodeHsn in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeHsn.Expanded = true;
                        // --
                        foreach (UltraTreeNode tNodeHml in tNodeHsn.Nodes)
                        {
                            tNodeHml.Expanded = true;
                            // --
                            foreach (UltraTreeNode tNodeHms in tNodeHml.Nodes)
                            {
                                tNodeHms.Expanded = true;
                            }
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.SecsSession)
                {
                    tvwTree.ActiveNode.Expanded = true;
                    // --
                    foreach (UltraTreeNode tNodeHml in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeHml.Expanded = true;
                        // --
                        foreach (UltraTreeNode tNodeHms in tNodeHml.Nodes)
                        {
                            tNodeHms.Expanded = true;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.SecsMessageList)
                {
                    tvwTree.ActiveNode.Expanded = true;
                    // --
                    foreach (UltraTreeNode tNodeHms in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeHms.Expanded = true;
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
                    foreach (UltraTreeNode tNodeHdv in tvwTree.ActiveNode.Nodes)
                    {
                        foreach (UltraTreeNode tNodeHsn in tNodeHdv.Nodes)
                        {
                            foreach (UltraTreeNode tNodeHml in tNodeHsn.Nodes)
                            {
                                foreach (UltraTreeNode tNodeHms in tNodeHml.Nodes)
                                {
                                    tNodeHms.Expanded = false;
                                }
                                // --
                                tNodeHml.Expanded = false;
                            }
                            // --
                            tNodeHsn.Expanded = false;
                        }
                        // --
                        tNodeHdv.Expanded = false;
                    }
                    // --
                    tvwTree.ActiveNode.Expanded = false;
                }
                else if (fObject.fObjectType == FObjectType.HostDevice)
                {
                    foreach (UltraTreeNode tNodeHsn in tvwTree.ActiveNode.Nodes)
                    {
                        foreach (UltraTreeNode tNodeHml in tNodeHsn.Nodes)
                        {
                            foreach (UltraTreeNode tNodeHms in tNodeHml.Nodes)
                            {
                                tNodeHms.Expanded = false;
                            }
                            // --
                            tNodeHml.Expanded = false;
                        }
                        // --
                        tNodeHsn.Expanded = false;
                    }
                    // --
                    tvwTree.ActiveNode.Expanded = false;
                }
                else if (fObject.fObjectType == FObjectType.HostSession)
                {
                    foreach (UltraTreeNode tNodeHml in tvwTree.ActiveNode.Nodes)
                    {
                        foreach (UltraTreeNode tNodeHms in tNodeHml.Nodes)
                        {
                            tNodeHms.Expanded = false;
                        }
                        // --
                        tNodeHml.Expanded = false;
                    }
                    // --
                    tvwTree.ActiveNode.Expanded = false;
                }
                else if (fObject.fObjectType == FObjectType.HostMessageList)
                {
                    foreach (UltraTreeNode tNodeHms in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeHms.Expanded = false;
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

        private void procMenuVfeiViewer(
            )
        {
            FVfeiViewer fVfeiViewer = null;
            FIObject fObject = null;
            StringBuilder sb = null;

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

                foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                {
                    fObject = (FIObject)tNode.Tag;
                    // --
                    if (fObject.fObjectType == FObjectType.HostMessage)
                    {
                        sb.Append(((FHostMessage)fObject).convertToVfei());
                    }
                    else if (fObject.fObjectType == FObjectType.HostMessages)
                    {
                        sb.Append(((FHostMessages)fObject).convertToVfei());
                    }
                }
                // --
                fVfeiViewer.appendVfei(sb.ToString());
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fVfeiViewer = null;
                fObject = null;
                sb = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuOpenHostDevice(
            )
        {
            FHostDevice fHostDevice = null;

            try
            {
                fHostDevice = (FHostDevice)tvwTree.ActiveNode.Tag;
                fHostDevice.open();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fHostDevice = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuCloseHostDevice(
            )
        {
            FHostDevice fHostDevice = null;

            try
            {
                fHostDevice = (FHostDevice)tvwTree.ActiveNode.Tag;
                fHostDevice.close();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fHostDevice = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSendHostMessage(
            )
        {
            FIObject fObject = null;
            FHostMessageTransfer fHostMessageTransfer = null;

            try
            {
                fObject = (FIObject)tvwTree.ActiveNode.Tag;
                if (fObject.fObjectType == FObjectType.HostMessages)
                {
                    foreach (FHostMessage fHmg in ((FHostMessages)fObject).fChildHostMessageCollection)
                    {
                        if (fHmg.isPrimary)
                        {
                            fHostMessageTransfer = fHmg.createTransfer();
                            fHostMessageTransfer.send((FHostSession)tvwTree.ActiveNode.Parent.Parent.Tag);
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.HostMessage)
                {
                    fHostMessageTransfer = ((FHostMessage)tvwTree.ActiveNode.Tag).createTransfer();
                    // --
                    // ***
                    // 2011.10.21 by spike.lee
                    //  - SECS Message Transfer Test
                    // ***
                    //if (fHostMessageTransfer.fChildSecsItemCollection.count == 0)
                    //{
                    //    FSecsItem fSit = fHostMessageTransfer.appendChildSecsItem(new FSecsItem(m_fSsmCore.fSsmFileInfo.fSecsDriver));
                    //    fSit.fFormat = FFormat.List;
                    //    FSecsItem fSit2 = fSit.appendChildSecsItem(new FSecsItem(m_fSsmCore.fSsmFileInfo.fSecsDriver));
                    //    fSit2.fFormat = FFormat.Ascii;
                    //    fSit2.originalStringValue = "한들나라";
                    //}
                    // --
                    fHostMessageTransfer.send((FHostSession)tvwTree.ActiveNode.Parent.Parent.Parent.Tag);
                }                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fObject = null;
                fHostMessageTransfer = null;
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
                if (fObject.fObjectType == FObjectType.HostMessages)
                {
                    findWhat = ((FHostMessages)fObject).name;
                }
                else if (fObject.fObjectType == FObjectType.HostMessage)
                {
                    findWhat = ((FHostMessage)fObject).name;
                }
                else if (fObject.fObjectType == FObjectType.HostItem)
                {
                    findWhat = ((FHostItem)fObject).name;
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
                if (fObject.fObjectType == FObjectType.HostMessages)
                {
                    foreach (FIObject o in ((FHostMessages)fObject).fChildHostMessageCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FHostMessages)fObject).name = ((FHostMessages)fObject).name.Replace(findWhat, replaceWith);
                    ((FHostMessages)fObject).command = ((FHostMessages)fObject).command.Replace(findWhat, replaceWith);
                    ((FHostMessages)fObject).description = ((FHostMessages)fObject).description.Replace(findWhat, replaceWith);
                }
                else if (fObject.fObjectType == FObjectType.HostMessage)
                {
                    foreach (FIObject o in ((FHostMessage)fObject).fChildHostItemCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FHostMessage)fObject).name = ((FHostMessage)fObject).name.Replace(findWhat, replaceWith);
                    ((FHostMessage)fObject).command = ((FHostMessage)fObject).command.Replace(findWhat, replaceWith);
                    ((FHostMessage)fObject).description = ((FHostMessage)fObject).description.Replace(findWhat, replaceWith);
                }
                else if (fObject.fObjectType == FObjectType.HostItem)
                {
                    foreach (FIObject o in ((FHostItem)fObject).fChildHostItemCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FHostItem)fObject).name = ((FHostItem)fObject).name.Replace(findWhat, replaceWith);
                    ((FHostItem)fObject).description = ((FHostItem)fObject).description.Replace(findWhat, replaceWith);                    
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

                if (fObject.fObjectType == FObjectType.HostDevice)
                {
                    ((FHostDevice)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.HostSession)
                {
                    ((FHostSession)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.HostMessageList)
                {
                    ((FHostMessageList)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.HostMessages)
                {
                    ((FHostMessages)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.HostMessage)
                {
                    ((FHostMessage)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.HostItem)
                {
                    ((FHostItem)fObject).cut();
                }

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

                if (fObject.fObjectType == FObjectType.HostDevice)
                {
                    ((FHostDevice)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.HostSession)
                {
                    ((FHostSession)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.HostMessageList)
                {
                    ((FHostMessageList)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.HostMessages)
                {
                    ((FHostMessages)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.HostMessage)
                {
                    ((FHostMessage)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.HostItem)
                {
                    ((FHostItem)fObject).copy();
                }

                // --

                controlMenu();
            }
            catch (Exception ex)
            {
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

                if (fRefObject.fObjectType == FObjectType.HostDevice)
                {
                    fNewObject = ((FHostDevice)fRefObject).pasteSibling();
                    uniqueId = fNewObject.uniqueIdToString;
                }
                else if (fRefObject.fObjectType == FObjectType.HostSession)
                {
                    fNewObject = ((FHostSession)fRefObject).pasteSibling();
                    //uniqueId = createTreeId(tNodeRef.Key, fNewObject.uniqueIdToString);
                    uniqueId = fNewObject.uniqueIdToString;
                }
                else if (fRefObject.fObjectType == FObjectType.HostMessageList)
                {
                    fNewObject = ((FHostMessageList)fRefObject).pasteSibling();
                    uniqueId = createTreeId(getHostSessionId(tNodeRef.Key), fNewObject.uniqueIdToString);
                }
                else if (fRefObject.fObjectType == FObjectType.HostMessages)
                {
                    fNewObject = ((FHostMessages)fRefObject).pasteSibling();
                    uniqueId = createTreeId(getHostSessionId(tNodeRef.Key), fNewObject.uniqueIdToString);
                }
                else if (fRefObject.fObjectType == FObjectType.HostMessage)
                {
                    // ***
                    // 사용하지 않음
                    // ***
                }
                else if (fRefObject.fObjectType == FObjectType.HostItem)
                {
                    fNewObject = ((FHostItem)fRefObject).pasteSibling();
                    uniqueId = createTreeId(getHostSessionId(tNodeRef.Key), fNewObject.uniqueIdToString);
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
                    fNewChild = ((FSecsDriver)fParent).pasteChildHostDevice();
                    uniqueId = fNewChild.uniqueIdToString;
                }
                else if (fParent.fObjectType == FObjectType.HostDevice)
                {
                    fNewChild = ((FHostDevice)fParent).pasteChild();
                    uniqueId = fNewChild.uniqueIdToString;
                }
                else if (fParent.fObjectType == FObjectType.HostSession)
                {
                    fNewChild = ((FHostSession)fParent).fLibrary.pasteChild();
                    uniqueId = createTreeId(tNodeParent.Key, fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.HostMessageList)
                {
                    fNewChild = ((FHostMessageList)fParent).pasteChild();
                    uniqueId = createTreeId(getHostSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.HostMessages)
                {
                    // ***
                    // 사용하지 않음
                    // ***
                }
                else if (fParent.fObjectType == FObjectType.HostMessage)
                {
                    fNewChild = ((FHostMessage)fParent).pasteChild();
                    uniqueId = createTreeId(getHostSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
                }
                else if (fParent.fObjectType == FObjectType.HostItem)
                {
                    fNewChild = ((FHostItem)fParent).pasteChild();
                    uniqueId = createTreeId(getHostSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
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

        private void procMenuPastePrimaryHostMessage(
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

                if (fParent.fObjectType == FObjectType.HostMessages)
                {
                    fNewChild = ((FHostMessages)fParent).pastePrimaryHostMessage();
                    uniqueId = createTreeId(getHostSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
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
            catch (Exception Ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(Ex);
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

        private void procMenuPasteSecondaryHostMessage(
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

                if (fParent.fObjectType == FObjectType.HostMessages)
                {
                    fNewChild = ((FHostMessages)fParent).pasteSecondaryHostMessage();
                    uniqueId = createTreeId(getHostSessionId(tNodeParent.Key), fNewChild.uniqueIdToString);
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
            catch (Exception Ex)
            {
                tvwTree.endUpdate();
                FDebug.throwException(Ex);
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
            FHostSession fHsn = null;
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
                    fHsn = (FHostSession)tvwTree.GetNodeByKey(uniqueIds[0]).Tag;
                }

                // --

                fResult = m_fSsmCore.fSsmFileInfo.fSecsDriver.searchHostDeviceSeries(fBase, ref fHsn, searchWord);
                if (fResult == null)
                {
                    FMessageBox.showInformation("Search", m_fSsmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { searchWord }), this);
                    return;
                }

                // --

                tvwTree.beginUpdate();

                // --

                expandTreeForSearch(fHsn, fResult);
                // --
                if (fHsn == null)
                {
                    uniqueId = fResult.uniqueIdToString;
                }
                else
                {
                    uniqueId = createTreeId(fHsn.uniqueIdToString, fResult.uniqueIdToString);
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
                fHsn = null;
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
                // Host Device와 Host Session 검색에만 사용된다.
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
            FIObject fHsn,
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
                    fParent.fObjectType == FObjectType.HostDevice ||
                    fParent.fObjectType == FObjectType.HostSession
                    )
                {
                    parentUid = fParent.uniqueIdToString;
                }
                else
                {
                    parentUid = string.Format("{0}-{1}", fHsn.uniqueIdToString, fParent.uniqueIdToString);
                }

                // --

                tNodeParent = tvwTree.GetNodeByKey(parentUid);
                if (tNodeParent == null || !tNodeParent.Expanded)
                {
                    expandTreeForSearch(fHsn, fParent);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FHostDeviceModeler Form Event Handler

        private void FHostDeviceModeler_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designTreeOfHostDeviceModeler();

                // --

                tvwTree.setPopupMenu((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuHdmPopupMenu]);

                // --

                m_fEventHandler = new FEventHandler(m_fSsmCore.fSsmFileInfo.fSecsDriver, tvwTree);
                // --
                m_fEventHandler.ObjectInsertBeforeCompleted += new FObjectInsertBeforeCompletedEventHandler(m_fEventHandler_ObjectInsertBeforeCompleted);
                m_fEventHandler.ObjectInsertAfterCompleted += new FObjectInsertAfterCompletedEventHandler(m_fEventHandler_ObjectInsertAfterCompleted);
                m_fEventHandler.ObjectAppendCompleted += new FObjectAppendCompletedEventHandler(m_fEventHandler_ObjectAppendCompleted);
                m_fEventHandler.ObjectRemoveCompleted += new FObjectRemoveCompletedEventHandler(m_fEventHandler_ObjectRemoveCompleted);
                m_fEventHandler.ObjectMoveUpCompleted += new FObjectMoveUpCompletedEventHandler(m_fEventHandler_ObjectMoveUpCompleted);
                m_fEventHandler.ObjectMoveDownCompleted += new FObjectMoveDownCompletedEventHandler(m_fEventHandler_ObjectMoveDownCompleted);
                m_fEventHandler.ObjectMoveToCompleted += new FObjectMoveToCompletedEventHandler(m_fEventHandler_ObjectMoveToCompleted);
                m_fEventHandler.ObjectModifyCompleted += new FObjectModifyCompletedEventHandler(m_fEventHandler_ObjectModifyCompleted);                
                m_fEventHandler.HostDeviceStateChanged += new FHostDeviceStateChangedEventHandler(m_fEventHandler_HostDeviceStateChanged);                

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

        private void FHostDeviceModeler_Shown(
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

        private void FHostDeviceModeler_FormClosing(
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
                    m_fEventHandler.ObjectInsertBeforeCompleted -= new FObjectInsertBeforeCompletedEventHandler(m_fEventHandler_ObjectInsertBeforeCompleted);                    
                    m_fEventHandler.ObjectInsertAfterCompleted -= new FObjectInsertAfterCompletedEventHandler(m_fEventHandler_ObjectInsertAfterCompleted);
                    m_fEventHandler.ObjectAppendCompleted -= new FObjectAppendCompletedEventHandler(m_fEventHandler_ObjectAppendCompleted);
                    m_fEventHandler.ObjectRemoveCompleted -= new FObjectRemoveCompletedEventHandler(m_fEventHandler_ObjectRemoveCompleted);
                    m_fEventHandler.ObjectMoveUpCompleted -= new FObjectMoveUpCompletedEventHandler(m_fEventHandler_ObjectMoveUpCompleted);
                    m_fEventHandler.ObjectMoveDownCompleted -= new FObjectMoveDownCompletedEventHandler(m_fEventHandler_ObjectMoveDownCompleted);
                    m_fEventHandler.ObjectMoveToCompleted -= new FObjectMoveToCompletedEventHandler(m_fEventHandler_ObjectMoveToCompleted);
                    m_fEventHandler.ObjectModifyCompleted -= new FObjectModifyCompletedEventHandler(m_fEventHandler_ObjectModifyCompleted);                    
                    m_fEventHandler.HostDeviceStateChanged -= new FHostDeviceStateChangedEventHandler(m_fEventHandler_HostDeviceStateChanged);                    
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
                    e.fObject.fObjectType == FObjectType.HostDevice ||
                    e.fObject.fObjectType == FObjectType.HostSession
                    )
                {
                    addTreeOfObject(e.fParentObject, e.fObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.HostMessageList ||
                    e.fObject.fObjectType == FObjectType.HostMessages ||
                    e.fObject.fObjectType == FObjectType.HostMessage ||
                    e.fObject.fObjectType == FObjectType.HostItem
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
                    e.fObject.fObjectType == FObjectType.HostDevice ||
                    e.fObject.fObjectType == FObjectType.HostSession
                    )
                {
                    addTreeOfObject(e.fParentObject, e.fObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.HostMessageList ||
                    e.fObject.fObjectType == FObjectType.HostMessages ||
                    e.fObject.fObjectType == FObjectType.HostMessage ||
                    e.fObject.fObjectType == FObjectType.HostItem
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
                    e.fObject.fObjectType == FObjectType.HostDevice ||
                    e.fObject.fObjectType == FObjectType.HostSession
                    )
                {
                    addTreeOfObject(e.fParentObject, e.fObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.HostMessageList ||
                    e.fObject.fObjectType == FObjectType.HostMessages ||
                    e.fObject.fObjectType == FObjectType.HostMessage ||
                    e.fObject.fObjectType == FObjectType.HostItem
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
                    e.fObject.fObjectType == FObjectType.HostDevice ||
                    e.fObject.fObjectType == FObjectType.HostSession
                    )
                {
                    removeTreeOfObject(e.fObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.HostMessageList ||
                    e.fObject.fObjectType == FObjectType.HostMessages ||
                    e.fObject.fObjectType == FObjectType.HostMessage ||
                    e.fObject.fObjectType == FObjectType.HostItem
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
                    e.fObject.fObjectType == FObjectType.HostDevice ||
                    e.fObject.fObjectType == FObjectType.HostSession
                    )
                {
                    moveUpTreeOfObject(e.fObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.HostMessageList ||
                    e.fObject.fObjectType == FObjectType.HostMessages ||
                    e.fObject.fObjectType == FObjectType.HostMessage ||
                    e.fObject.fObjectType == FObjectType.HostItem
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
                    e.fObject.fObjectType == FObjectType.HostDevice ||
                    e.fObject.fObjectType == FObjectType.HostSession 
                    )
                {
                    moveDownTreeOfObject(e.fObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.HostMessageList ||
                    e.fObject.fObjectType == FObjectType.HostMessages ||
                    e.fObject.fObjectType == FObjectType.HostMessage ||
                    e.fObject.fObjectType == FObjectType.HostItem
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
                    e.fObject.fObjectType == FObjectType.HostDevice ||
                    e.fObject.fObjectType == FObjectType.HostSession
                    )
                {
                    moveToTreeOfObject(e.fObject, e.fRefObject);
                }
                else if (
                    e.fObject.fObjectType == FObjectType.HostMessageList ||
                    e.fObject.fObjectType == FObjectType.HostMessages ||
                    e.fObject.fObjectType == FObjectType.HostMessage ||
                    e.fObject.fObjectType == FObjectType.HostItem
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
                    e.fObject.fObjectType == FObjectType.HostDevice ||
                    e.fObject.fObjectType == FObjectType.HostSession
                    )
                {
                    refreshObject(e.fObject);
                }
                else if (e.fObject.fObjectType == FObjectType.HostLibrary)
                {
                    foreach (FIObject fObject in ((FHostLibrary)e.fObject).fReferenceObjectCollection)
                    {
                        if (fObject.fObjectType == FObjectType.HostSession)
                        {
                            refreshObject(fObject);
                        }                        
                    }
                }
                else if (
                    e.fObject.fObjectType == FObjectType.HostMessageList ||
                    e.fObject.fObjectType == FObjectType.HostMessages ||
                    e.fObject.fObjectType == FObjectType.HostMessage ||
                    e.fObject.fObjectType == FObjectType.HostItem
                    )
                {
                    refreshObject2(e.fObject);
                }
                else if (e.fObject.fObjectType == FObjectType.DataSet)
                {
                    foreach (FIObject fObject in ((FDataSet)e.fObject).fReferenceObjectCollection)
                    {
                        if (fObject.fObjectType == FObjectType.HostMessage)
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

        private void m_fEventHandler_HostDeviceStateChanged(
            object sender, 
            FHostDeviceStateChangedEventArgs e
            )
        {
            UltraTreeNode tNode = null;

            try
            {
                if (e.fHostDeviceStateChangedLog.fResultCode != FResultCode.Success)
                {
                    return;
                }

                // --

                tNode = tvwTree.GetNodeByKey(e.fHostDeviceStateChangedLog.uniqueIdToString);
                if (
                    e.fHostDeviceStateChangedLog.fState == FDeviceState.Opened ||
                    e.fHostDeviceStateChangedLog.fState == FDeviceState.Closed
                    )
                {                    
                    if (tNode != null && tNode.IsActive)
                    {
                        ((FPropHdv)pgdProp.selectedObject).setChangedState(e.fHostDeviceStateChangedLog.fState);
                        controlMenu();
                    }
                }

                // --

                if (tvwTree.ActiveNode != null && ((FIObject)tvwTree.ActiveNode.Tag).fObjectType == FObjectType.HostMessage)
                {
                    if (
                        ((FIObject)tvwTree.ActiveNode.Tag).fObjectType == FObjectType.HostMessages ||
                        ((FIObject)tvwTree.ActiveNode.Tag).fObjectType == FObjectType.HostMessage
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
                else if (fObject.fObjectType == FObjectType.HostDevice)
                {
                    pgdProp.selectedObject = new FPropHdv(m_fSsmCore, pgdProp, (FHostDevice)fObject);
                }
                else if (fObject.fObjectType == FObjectType.HostSession)
                {
                    pgdProp.selectedObject = new FPropHsn(m_fSsmCore, pgdProp, (FHostSession)fObject);
                }
                else if (fObject.fObjectType == FObjectType.HostMessageList)
                {
                    pgdProp.selectedObject = new FPropHml(m_fSsmCore, pgdProp, (FHostMessageList)fObject);
                }
                else if (fObject.fObjectType == FObjectType.HostMessages)
                {
                    pgdProp.selectedObject = new FPropHms(m_fSsmCore, pgdProp, (FHostMessages)fObject);
                }
                else if (fObject.fObjectType == FObjectType.HostMessage)
                {
                    pgdProp.selectedObject = new FPropHmg(m_fSsmCore, pgdProp, (FHostMessage)fObject);
                }
                else if (fObject.fObjectType == FObjectType.HostItem)
                {
                    if (((FHostItem)fObject).removed)
                    {
                        return;
                    }
                    pgdProp.selectedObject = new FPropHit(m_fSsmCore, pgdProp, (FHostItem)fObject);
                }

                // --

                controlMenu();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
                if (fObject.fObjectType == FObjectType.HostDevice)
                {
                    pgdProp.selectedObject = new FPropHdv(m_fSsmCore, pgdProp, (FHostDevice)fObject);
                }
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
                    if (mnuMenu.Tools[FMenuKey.MenuHlmRemove].SharedProps.Enabled)
                    {
                        procMenuRemoveObject();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.X)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuHlmCut].SharedProps.Enabled)
                    {
                        procMenuCut();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.C)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuHlmCopy].SharedProps.Enabled)
                    {
                        procMenuCopy();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.V)
                {
                    fObject = (FIObject)this.tvwTree.ActiveNode.Tag;

                    if (fObject.fObjectType == FObjectType.HostMessages)
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuHlmPastePrimaryHostMessage].SharedProps.Enabled)
                        {
                            procMenuPastePrimaryHostMessage();
                        }
                        else if (mnuMenu.Tools[FMenuKey.MenuHlmPasteSibling].SharedProps.Enabled)
                        {
                            procMenuPasteSibling();
                        }
                        else if (mnuMenu.Tools[FMenuKey.MenuHlmPasteSecondaryHostMessage].SharedProps.Enabled)
                        {
                            procMenuPasteSecondaryHostMessage();
                        }
                    }
                    else
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuHlmPasteSibling].SharedProps.Enabled)
                        {
                            procMenuPasteSibling();
                        }
                    }
                }
                else if (e.Control && e.KeyCode == Keys.B)
                {
                    fObject = (FIObject)this.tvwTree.ActiveNode.Tag;

                    if (fObject.fObjectType == FObjectType.HostMessages)
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuHlmPasteSecondaryHostMessage].SharedProps.Enabled)
                        {
                            procMenuPasteSecondaryHostMessage();
                        }
                    }
                    else
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuHlmPasteChild].SharedProps.Enabled)
                        {
                            procMenuPasteChild();
                        }
                    }
                }
                else if (e.Control && e.KeyCode == Keys.U)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuHlmMoveUp].SharedProps.Enabled)
                    {
                        procMenuMoveUpObject(FMenuKey.MenuHlmMoveUp);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.D)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuHlmMoveDown].SharedProps.Enabled)
                    {
                        procMenuMoveDownObject(FMenuKey.MenuHlmMoveDown);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.E)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuHlmExpand].SharedProps.Enabled)
                    {
                        procMenuExpand();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.L)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuHlmCollapse].SharedProps.Enabled)
                    {
                        procMenuCollapse();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.R)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuHdmRelation].SharedProps.Enabled)
                    {
                        procMenuRelation();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.S)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuHdmSendHostMessage].SharedProps.Enabled)
                    {
                        procMenuSendHostMessage();
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
                    fObject.fObjectType != FObjectType.HostDevice &&
                    fObject.fObjectType != FObjectType.HostSession
                    )
                {
                    fDragDropData.sessionUniqueId = getHostSessionId(tNode.Key);
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
            string hsnUniqueId = string.Empty;
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
                        if (fDragDropData.fObject.fObjectType == FObjectType.HostDevice)
                        {
                            #region HostDevice

                            if (((FSecsDriver)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                cnt = ((FSecsDriver)fRefObject).fChildHostDeviceCollection.count;
                                fRefObject = ((FSecsDriver)fRefObject).fChildHostDeviceCollection[cnt - 1];
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
                    else if (fRefObject.fObjectType == FObjectType.HostDevice)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.HostDevice)
                        {
                            #region HostDevice

                            if (((FHostDevice)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FHostDevice)fRefObject).fNextSibling == null || !((FHostDevice)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostSession)
                        {
                            #region HostSession

                            if (((FHostDevice)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                cnt = ((FHostDevice)fRefObject).fChildHostSessionCollection.count;
                                if (cnt == 0)
                                {
                                    if (!((FHostSession)fDragDropData.fObject).locked)
                                    {
                                        e.Effect = DragDropEffects.Move;
                                        return;
                                    }
                                }
                                else
                                {
                                    fRefObject = ((FHostDevice)fRefObject).fChildHostSessionCollection[cnt - 1];
                                    if (!fRefObject.Equals(fDragDropData.fObject))
                                    {
                                        if (((FHostSession)fDragDropData.fObject).locked)
                                        {
                                            if (((FHostSession)fRefObject).fParent == ((FHostSession)fDragDropData.fObject).fParent)
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
                    else if (fRefObject.fObjectType == FObjectType.HostSession)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.HostSession)
                        {
                            #region HostSession

                            if (((FHostSession)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FHostSession)fRefObject).fNextSibling == null || !((FHostSession)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                    )
                                {
                                    if (((FHostSession)fDragDropData.fObject).locked)
                                    {
                                        if (((FHostSession)fRefObject).fParent == ((FHostSession)fDragDropData.fObject).fParent)
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostLibrary)
                        {
                            #region HostLibrary

                            if (
                                !((FHostSession)fRefObject).locked &&
                                ((FHostSession)fRefObject).equalsModelingFile(fDragDropData.fObject)
                                )
                            {
                                if (((FHostSession)fRefObject).hasLibrary)
                                {
                                    if (!((FHostSession)fRefObject).fLibrary.Equals((FHostLibrary)fDragDropData.fObject))
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostMessageList)
                        {
                            #region HostMessageList

                            if (((FHostSession)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (fRefObject.uniqueIdToString == fDragDropData.sessionUniqueId)
                                {
                                    cnt = ((FHostSession)fRefObject).fLibrary.fChildHostMessageListCollection.count;
                                    fRefObject = ((FHostSession)fRefObject).fLibrary.fChildHostMessageListCollection[cnt - 1];
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
                    else if (fRefObject.fObjectType == FObjectType.HostMessageList)
                    {
                        hsnUniqueId = getHostSessionId(tRefNode.Key);

                        // --

                        if (fDragDropData.fObject.fObjectType == FObjectType.HostMessageList)
                        {
                            #region HostMessageList

                            if (((FHostMessageList)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (hsnUniqueId == fDragDropData.sessionUniqueId)
                                {
                                    if (
                                        !fRefObject.Equals(fDragDropData.fObject) &&
                                        (((FHostMessageList)fRefObject).fNextSibling == null || !((FHostMessageList)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostMessages)
                        {
                            #region HostMessages

                            if (((FHostMessageList)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                // ***
                                // Host Messages는 다른 Host Library로 Move 할 수 없다.
                                // ***
                                if (
                                    fDragDropData.sessionUniqueId == hsnUniqueId &&
                                    ((FHostMessageList)fRefObject).fAncestorHostLibrary.Equals(((FHostMessages)fDragDropData.fObject).fAncestorHostLibrary)
                                    )
                                {
                                    cnt = ((FHostMessageList)fRefObject).fChildHostMessagesCollection.count;
                                    if (cnt == 0)
                                    {
                                        e.Effect = DragDropEffects.Move;
                                        return;
                                    }
                                    else
                                    {
                                        fRefObject = ((FHostMessageList)fRefObject).fChildHostMessagesCollection[cnt - 1];
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
                    else if (fRefObject.fObjectType == FObjectType.HostMessages)
                    {
                        hsnUniqueId = getHostSessionId(tRefNode.Key);

                        // --

                        if (fDragDropData.fObject.fObjectType == FObjectType.HostMessages)
                        {
                            #region HostMessages

                            if (((FHostMessages)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                // ***
                                // Host Messages는 다른 Host Library로 Move 할 수 없다.
                                // ***
                                if (
                                    fDragDropData.sessionUniqueId == hsnUniqueId &&
                                    ((FHostMessages)fRefObject).fAncestorHostLibrary.Equals(((FHostMessages)fDragDropData.fObject).fAncestorHostLibrary)
                                    )
                                {
                                    if (
                                        !fRefObject.Equals(fDragDropData.fObject) &&
                                        (((FHostMessages)fRefObject).fNextSibling == null || !((FHostMessages)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostMessage)
                        {
                            #region HostMessage

                            if (!((FHostMessages)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FHostMessage)fDragDropData.fObject).isPrimary)
                                {
                                    if (((FHostMessages)fRefObject).canAppendChildPrimaryHostMessage)
                                    {
                                        e.Effect = DragDropEffects.Copy;
                                        return;
                                    }
                                }
                                else
                                {
                                    if (((FHostMessages)fRefObject).canAppendChildSecondaryHostMessage)
                                    {
                                        e.Effect = DragDropEffects.Copy;
                                        return;
                                    }
                                }
                            }

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.HostMessage)
                    {
                        hsnUniqueId = getHostSessionId(tRefNode.Key);

                        // --

                        if (fDragDropData.fObject.fObjectType == FObjectType.HostItem)
                        {
                            #region HostItem

                            if (((FHostMessage)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FHostMessage)fRefObject).Equals(((FHostItem)fDragDropData.fObject).fAncestorHostMessage) &&
                                    !((FHostMessage)fRefObject).fChildHostItemCollection[((FHostMessage)fRefObject).fChildHostItemCollection.count - 1].Equals(fDragDropData.fObject) &&
                                    fDragDropData.sessionUniqueId == hsnUniqueId
                                    )
                                {
                                    if (((FHostMessage)fRefObject).hasVariableChild)
                                    {
                                        if (((FHostItem)fDragDropData.fObject).fPattern == FPattern.Variable)
                                        {
                                            if (
                                                ((FHostMessage)fRefObject).Equals(((FHostItem)fDragDropData.fObject).fParent) &&
                                                (((FHostItem)fDragDropData.fObject).fPreviousSibling == null || ((FHostItem)fDragDropData.fObject).fPreviousSibling.fPattern == FPattern.Fixed) &&
                                                (((FHostItem)fDragDropData.fObject).fNextSibling == null || ((FHostItem)fDragDropData.fObject).fNextSibling.fPattern == FPattern.Fixed)
                                                )
                                            {
                                                e.Effect = DragDropEffects.Move;
                                                return;
                                            }
                                            else if (((FHostMessage)fRefObject).fChildHostItemCollection[((FHostMessage)fRefObject).fChildHostItemCollection.count - 1].fPattern == FPattern.Variable)
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.DataSet)
                        {
                            #region DataSet

                            if (((FHostMessage)fRefObject).equalsModelingFile(fDragDropData.fObject))
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
                    else if (fRefObject.fObjectType == FObjectType.HostItem)
                    {
                        hsnUniqueId = getHostSessionId(tRefNode.Key);

                        // --

                        if (fDragDropData.fObject.fObjectType == FObjectType.HostItem)
                        {
                            #region HostItem

                            if (((FHostItem)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    fDragDropData.sessionUniqueId == hsnUniqueId &&
                                    !((FHostItem)fDragDropData.fObject).containsObject(fRefObject) &&
                                    ((FHostItem)fRefObject).fAncestorHostMessage.Equals(((FHostItem)fDragDropData.fObject).fAncestorHostMessage) &&
                                    (((FHostItem)fRefObject).fNextSibling == null || !(((FHostItem)fRefObject).fNextSibling.Equals((FHostItem)fDragDropData.fObject)))
                                    )
                                {
                                    if (
                                        (((FHostItem)fRefObject).fParent.fObjectType == FObjectType.HostMessage && ((FHostMessage)((FHostItem)fRefObject).fParent).hasVariableChild) ||
                                        (((FHostItem)fRefObject).fParent.fObjectType == FObjectType.HostItem && ((FHostItem)((FHostItem)fRefObject).fParent).hasVariableChild)
                                        )
                                    {
                                        if (((FHostItem)fDragDropData.fObject).fPattern == FPattern.Variable)
                                        {
                                            if (
                                                ((FHostItem)fDragDropData.fObject).fParent.Equals(((FHostItem)fRefObject).fParent) &&
                                                (((FHostItem)fDragDropData.fObject).fPreviousSibling == null || ((FHostItem)fDragDropData.fObject).fPreviousSibling.fPattern == FPattern.Fixed) &&
                                                (((FHostItem)fDragDropData.fObject).fNextSibling == null || ((FHostItem)fDragDropData.fObject).fNextSibling.fPattern == FPattern.Fixed)
                                                )
                                            {
                                                e.Effect = DragDropEffects.Move;
                                                return;
                                            }
                                            else if (
                                                ((FHostItem)fRefObject).fPattern == FPattern.Variable ||
                                                (((FHostItem)fRefObject).fNextSibling != null && ((FHostItem)fRefObject).fNextSibling.fPattern == FPattern.Variable)
                                                )
                                            {
                                                e.Effect = DragDropEffects.Move;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            if (
                                                ((FHostItem)fRefObject).fPattern == FPattern.Fixed ||
                                                ((FHostItem)fRefObject).fNextSibling == null ||
                                                ((FHostItem)fRefObject).fNextSibling.fPattern == FPattern.Fixed
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
                                e.Effect = DragDropEffects.Copy;
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.DataConversionSet)
                        {
                            #region DataConversionSet

                            if (((FHostItem)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                fFormat = ((FHostItem)fRefObject).fFormat;
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

                            if (((FHostItem)fRefObject).equalsModelingFile(fDragDropData.fObject))
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

                    if (fRefObject.fObjectType == FObjectType.HostMessageList)
                    {
                        if (
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog ||
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog
                            )
                        {
                            #region HostMessageLog

                            e.Effect = DragDropEffects.Copy;
                            return;

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.HostMessages)
                    {
                        if (
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog ||
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog
                            )
                        {
                            #region HostMessageLog

                            e.Effect = DragDropEffects.Copy;
                            return;

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.HostMessage)
                    {
                        if (fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.HostItemLog)
                        {
                            #region HostItemLog

                            e.Effect = DragDropEffects.Copy;
                            return;

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.HostItem)
                    {
                        if (fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.HostItemLog)
                        {
                            #region HostItemLog

                            e.Effect = DragDropEffects.Copy;
                            return;

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
            FHostMessages fHms = null;
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
                        if (fDragDropData.fObject.fObjectType == FObjectType.HostDevice)
                        {
                            #region HostDevice

                            if (e.Effect == DragDropEffects.Move)
                            {
                                cnt = ((FSecsDriver)fRefObject).fChildHostDeviceCollection.count;
                                fRefObject = ((FSecsDriver)fRefObject).fChildHostDeviceCollection[cnt - 1];
                                ((FHostDevice)fDragDropData.fObject).moveTo((FHostDevice)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FHostDevice)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FSecsDriver)fRefObject).pasteChildHostDevice();
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
                    else if (fRefObject.fObjectType == FObjectType.HostDevice)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.HostDevice)
                        {
                            #region HostDevice

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FHostDevice)fDragDropData.fObject).moveTo((FHostDevice)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FHostDevice)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FHostDevice)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostSession)
                        {
                            #region HostSession

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FHostSession)fDragDropData.fObject).moveTo((FHostDevice)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FHostSession)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FHostDevice)fRefObject).pasteChild();
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
                    else if (fRefObject.fObjectType == FObjectType.HostSession)
                    {
                        fDragDropData.refSessionUniqueId = tRefNode.Key;

                        // --

                        if (fDragDropData.fObject.fObjectType == FObjectType.HostSession)
                        {
                            #region HostSession

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FHostSession)fDragDropData.fObject).moveTo((FHostSession)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FHostSession)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FHostSession)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostLibrary)
                        {
                            #region HostLibrary

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FHostSession)fRefObject).setLibrary((FHostLibrary)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostMessageList)
                        {
                            #region HostMessageList

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FHostMessageList)fDragDropData.fObject).moveTo(((FHostSession)fRefObject).fLibrary);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FHostMessageList)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FHostSession)fRefObject).fLibrary.pasteChild();
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
                    else if (fRefObject.fObjectType == FObjectType.HostMessageList)
                    {
                        fDragDropData.refSessionUniqueId = getHostSessionId(tRefNode.Key);

                        // --

                        if (fDragDropData.fObject.fObjectType == FObjectType.HostMessageList)
                        {
                            #region HostMessageList

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FHostMessageList)fDragDropData.fObject).moveTo((FHostMessageList)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FHostMessageList)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FHostMessageList)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostMessages)
                        {
                            #region HostMessages

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FHostMessages)fDragDropData.fObject).moveTo((FHostMessageList)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FHostMessages)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FHostMessageList)fRefObject).pasteChild();
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
                    else if (fRefObject.fObjectType == FObjectType.HostMessages)
                    {
                        fDragDropData.refSessionUniqueId = getHostSessionId(tRefNode.Key);

                        // --

                        if (fDragDropData.fObject.fObjectType == FObjectType.HostMessages)
                        {
                            #region HostMessages

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FHostMessages)fDragDropData.fObject).moveTo((FHostMessages)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FHostMessages)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FHostMessages)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostMessage)
                        {
                            #region HostMessage

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FHostMessage)fDragDropData.fObject).copy();
                                // --
                                if (((FHostMessage)fDragDropData.fObject).isPrimary)
                                {
                                    fDragDropData.fObject = ((FHostMessages)fRefObject).pastePrimaryHostMessage();
                                    fAction = FDragDropAction.Copy;
                                }
                                else
                                {
                                    fDragDropData.fObject = ((FHostMessages)fRefObject).pasteSecondaryHostMessage();
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
                    else if (fRefObject.fObjectType == FObjectType.HostMessage)
                    {
                        fDragDropData.refSessionUniqueId = getHostSessionId(tRefNode.Key);

                        // -- 

                        if (fDragDropData.fObject.fObjectType == FObjectType.HostItem)
                        {
                            #region HostItem

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FHostItem)fDragDropData.fObject).moveTo((FHostMessage)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FHostItem)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FHostMessage)fRefObject).pasteChild();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.DataSet)
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
                    else if (fRefObject.fObjectType == FObjectType.HostItem)
                    {
                        fDragDropData.refSessionUniqueId = getHostSessionId(tRefNode.Key);

                        // --

                        if (fDragDropData.fObject.fObjectType == FObjectType.HostItem)
                        {
                            #region HostItem

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FHostItem)fDragDropData.fObject).moveTo((FHostItem)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FHostItem)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FHostItem)fRefObject).pasteSibling();
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
                                ((FHostItem)fRefObject).setDataConversionSet((FDataConversionSet)fDragDropData.fObject);
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

                    if (fRefObject.fObjectType == FObjectType.HostMessageList)
                    {
                        fDragDropData.refSessionUniqueId = getHostSessionId(tRefNode.Key);

                        // --

                        if (
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog ||
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog
                            )
                        {
                            #region HostMessageLog

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fHms = new FHostMessages(m_fSsmCore.fSsmFileInfo.fSecsDriver);

                                if (fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                                {
                                    ((FHostDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).copy();
                                    // --
                                    fHms.command = ((FHostDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).command;
                                    fHms.version = ((FHostDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).version;
                                    fHms.name = ((FHostDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).name;
                                    fHms.description = ((FHostDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).description;
                                    // --
                                    if (((FHostDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).isPrimary)
                                    {
                                        fDragDropData.fObject = fHms.pastePrimaryHostMessage();
                                    }
                                    else
                                    {
                                        fDragDropData.fObject = fHms.pasteSecondaryHostMessage();
                                    }
                                }
                                else
                                {
                                    ((FHostDeviceDataMessageSentLog)fDragDropData.fObjectLog).copy();
                                    // --
                                    fHms.command = ((FHostDeviceDataMessageSentLog)fDragDropData.fObjectLog).command;
                                    fHms.version = ((FHostDeviceDataMessageSentLog)fDragDropData.fObjectLog).version;
                                    fHms.name = ((FHostDeviceDataMessageSentLog)fDragDropData.fObjectLog).name;
                                    fHms.description = ((FHostDeviceDataMessageSentLog)fDragDropData.fObjectLog).description;
                                    // --
                                    if (((FHostDeviceDataMessageSentLog)fDragDropData.fObjectLog).isPrimary)
                                    {
                                        fDragDropData.fObject = fHms.pastePrimaryHostMessage();
                                    }
                                    else
                                    {
                                        fDragDropData.fObject = fHms.pasteSecondaryHostMessage();
                                    }
                                }

                                // --

                                tvwTree.beginUpdate();

                                // --

                                fHms = ((FHostMessageList)fRefObject).appendChildHostMessages(fHms);
                                tNode = new UltraTreeNode(createTreeId(fDragDropData.refSessionUniqueId, fHms.uniqueIdToString));
                                tNode.Tag = fHms;
                                FCommon.refreshTreeNodeOfObject(fHms, tvwTree, tNode);
                                tRefNode.Nodes.Add(tNode);

                                // --

                                fRefObject = fHms;
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
                    else if (fRefObject.fObjectType == FObjectType.HostMessages)
                    {
                        fDragDropData.refSessionUniqueId = getHostSessionId(tRefNode.Key);

                        // --

                        if (
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog ||
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog
                            )
                        {
                            #region HostMessageLog

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fHms = new FHostMessages(m_fSsmCore.fSsmFileInfo.fSecsDriver);

                                if (fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog)
                                {
                                    ((FHostDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).copy();
                                    // --
                                    fHms.command = ((FHostDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).command;
                                    fHms.version = ((FHostDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).version;
                                    fHms.name = ((FHostDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).name;
                                    fHms.description = ((FHostDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).description;
                                    // --
                                    if (((FHostDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).isPrimary)
                                    {
                                        fDragDropData.fObject = fHms.pastePrimaryHostMessage();
                                    }
                                    else
                                    {
                                        fDragDropData.fObject = fHms.pasteSecondaryHostMessage();
                                    }
                                }
                                else
                                {
                                    ((FHostDeviceDataMessageSentLog)fDragDropData.fObjectLog).copy();
                                    // --
                                    fHms.command = ((FHostDeviceDataMessageSentLog)fDragDropData.fObjectLog).command;
                                    fHms.version = ((FHostDeviceDataMessageSentLog)fDragDropData.fObjectLog).version;
                                    fHms.name = ((FHostDeviceDataMessageSentLog)fDragDropData.fObjectLog).name;
                                    fHms.description = ((FHostDeviceDataMessageSentLog)fDragDropData.fObjectLog).description;
                                    // --
                                    if (((FHostDeviceDataMessageSentLog)fDragDropData.fObjectLog).isPrimary)
                                    {
                                        fDragDropData.fObject = fHms.pastePrimaryHostMessage();
                                    }
                                    else
                                    {
                                        fDragDropData.fObject = fHms.pasteSecondaryHostMessage();
                                    }
                                }

                                // --

                                tvwTree.beginUpdate();

                                // --

                                fHms = ((FHostMessages)fRefObject).fParent.insertAfterChildHostMessages(fHms, (FHostMessages)fRefObject);
                                tNode = new UltraTreeNode(createTreeId(fDragDropData.refSessionUniqueId, fHms.uniqueIdToString));
                                tNode.Tag = fHms;
                                FCommon.refreshTreeNodeOfObject(fHms, tvwTree, tNode);
                                tRefNode.Parent.Nodes.Insert(tRefNode.Index + 1, tNode);

                                // --

                                fRefObject = fHms;
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
                    else if (fRefObject.fObjectType == FObjectType.HostMessage)
                    {
                        fDragDropData.refSessionUniqueId = getHostSessionId(tRefNode.Key);

                        // --

                        if (fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.HostItemLog)
                        {
                            #region HostItemLog

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FHostItemLog)fDragDropData.fObjectLog).copy();
                                fDragDropData.fObject = ((FHostMessage)fRefObject).pasteChild();
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.HostItem)
                    {
                        fDragDropData.refSessionUniqueId = getHostSessionId(tRefNode.Key);

                        // --

                        if (fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.HostItemLog)
                        {
                            #region HostItemLog

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FHostItemLog)fDragDropData.fObjectLog).copy();
                                fDragDropData.fObject = ((FHostItem)fRefObject).pasteSibling();
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
                        fDragDropData.fObject.fObjectType == FObjectType.HostDevice ||
                        fDragDropData.fObject.fObjectType == FObjectType.HostSession
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
                        fRefObject.fObjectType == FObjectType.HostDevice ||
                        fRefObject.fObjectType == FObjectType.HostSession
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
                    if (fRefObject.fObjectType == FObjectType.HostSession)
                    {
                        changeHostSessionLibrary((FHostSession)fRefObject);
                        // --
                        tRefNode = tvwTree.GetNodeByKey(fRefObject.uniqueIdToString);
                        if (tRefNode != null)
                        {
                            tvwTree.SelectedNodes.Clear();
                            tvwTree.ActiveNode = tRefNode;
                        }
                    }                    
                    else if (
                        fRefObject.fObjectType == FObjectType.HostMessage ||
                        fRefObject.fObjectType == FObjectType.HostItem
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
                fHms = null;
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

                if (e.Tool.Key == FMenuKey.MenuHdmOpenHostDevice)
                {
                    procMenuOpenHostDevice();
                }
                else if (e.Tool.Key == FMenuKey.MenuHdmCloseHostDevice)
                {
                    procMenuCloseHostDevice();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuHdmSendHostMessage)
                {
                    procMenuSendHostMessage();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuHdmExpand)
                {
                    procMenuExpand();
                }
                else if (e.Tool.Key == FMenuKey.MenuHdmCollapse)
                {
                    procMenuCollapse();
                }
                else if (e.Tool.Key == FMenuKey.MenuHdmReplace)
                {
                    procMenuReplace();
                }
                else if (e.Tool.Key == FMenuKey.MenuHdmCut)
                {
                    procMenuCut();
                }
                else if (e.Tool.Key == FMenuKey.MenuHdmCopy)
                {
                    procMenuCopy();
                }
                else if (e.Tool.Key == FMenuKey.MenuHdmPasteSibling)
                {
                    procMenuPasteSibling();
                }
                else if (e.Tool.Key == FMenuKey.MenuHdmPasteChild)
                {
                    procMenuPasteChild();
                }
                else if (e.Tool.Key == FMenuKey.MenuHdmPastePrimaryHostMessage)
                {
                    procMenuPastePrimaryHostMessage();
                }
                else if (e.Tool.Key == FMenuKey.MenuHdmPasteSecondaryHostMessage)
                {
                    procMenuPasteSecondaryHostMessage();
                }
                else if (e.Tool.Key == FMenuKey.MenuHdmRemove)
                {
                    procMenuRemoveObject();
                }
                else if (e.Tool.Key == FMenuKey.MenuHdmMoveUp)
                {
                    procMenuMoveUpObject(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuHdmMoveDown)
                {
                    procMenuMoveDownObject(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuHdmConvertToVfei)
                {
                    procMenuVfeiViewer();
                }
                else if (e.Tool.Key == FMenuKey.MenuHdmRelation)
                {
                    procMenuRelation();
                }
                else if (e.Tool.Key == FMenuKey.MenuHdmResetHostDriver)
                {
                    procMenuResetHostDriver();
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuHdmInsertBeforeHostDevice ||
                    e.Tool.Key == FMenuKey.MenuHdmInsertBeforeHostSession ||
                    e.Tool.Key == FMenuKey.MenuHdmInsertBeforeHostMessageList ||
                    e.Tool.Key == FMenuKey.MenuHdmInsertBeforeHostMessages ||
                    e.Tool.Key == FMenuKey.MenuHdmInsertBeforeHostItem
                    )
                {
                    procMenuInsertBeforeObject(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuHdmInsertAfterHostDevice ||
                    e.Tool.Key == FMenuKey.MenuHdmInsertAfterHostSession ||
                    e.Tool.Key == FMenuKey.MenuHdmInsertAfterHostMessageList ||
                    e.Tool.Key == FMenuKey.MenuHdmInsertAfterHostMessages ||
                    e.Tool.Key == FMenuKey.MenuHdmInsertAfterHostItem
                    )
                {
                    procMenuInsertAfterObject(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuHdmAppendHostDevice ||
                    e.Tool.Key == FMenuKey.MenuHdmAppendHostSession ||
                    e.Tool.Key == FMenuKey.MenuHdmAppendHostMessageList ||
                    e.Tool.Key == FMenuKey.MenuHdmAppendHostMessages ||
                    e.Tool.Key == FMenuKey.MenuHdmAppendPrimaryHostMessage ||
                    e.Tool.Key == FMenuKey.MenuHdmAppendSecondaryHostMessage ||
                    e.Tool.Key == FMenuKey.MenuHdmAppendHostItem
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
                if (e.fDynProp is FPropHsn)
                {
                    if (e.contents == "LibraryChanged")
                    {
                        changeHostSessionLibrary(((FPropHsn)e.fDynProp).fHostSession);
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
