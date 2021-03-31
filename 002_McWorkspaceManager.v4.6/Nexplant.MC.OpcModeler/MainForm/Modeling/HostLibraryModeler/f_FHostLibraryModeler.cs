/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FHostLibraryModeler.cs
--  Creator         : duchoi
--  Create Date     : 2013.07.24
--  Description     : FAMate OPC Modeler Host Library Modeler Form Class 
--  History         : Created by duchoi at 2013.07.24
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.WorkspaceInterface;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinToolbars;

namespace Nexplant.MC.OpcModeler
{
    public partial class FHostLibraryModeler : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FOpmCore m_fOpmCore = null;
        private FEventHandler m_fEventHandler = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FHostLibraryModeler(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostLibraryModeler(
            FOpmCore fOpmCore
            )
            : this()
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

        protected override void changeControlFontName()
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

        private void designTreeOfHostLibraryModeler(
            )
        {
            try
            {
                tvwTree.ImageList = new ImageList();
                // --
                tvwTree.ImageList.Images.Add("OpcDriver", Properties.Resources.OpcDriver);
                tvwTree.ImageList.Images.Add("HostLibraryGroup_unlock", Properties.Resources.HostLibraryGroup_unlock);
                tvwTree.ImageList.Images.Add("HostLibraryGroup_lock", Properties.Resources.HostLibraryGroup_lock);
                tvwTree.ImageList.Images.Add("HostLibrary_unlock", Properties.Resources.HostLibrary_unlock);
                tvwTree.ImageList.Images.Add("HostLibrary_lock", Properties.Resources.HostLibrary_lock);
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
                        t.Key == FMenuKey.MenuHlmExpand ||
                        t.Key == FMenuKey.MenuHlmCollapse ||
                        t.Key == FMenuKey.MenuHlmRelation
                        )
                    {
                        continue;
                    }
                    else if (
                        t.Key == FMenuKey.MenuHlmReplace || 
                        t.Key == FMenuKey.MenuHlmCut||
                        t.Key == FMenuKey.MenuHlmCopy||
                        t.Key == FMenuKey.MenuHlmPasteSibling||
                        t.Key == FMenuKey.MenuHlmPasteChild||
                        t.Key == FMenuKey.MenuHlmRemove ||
                        t.Key == FMenuKey.MenuHlmMoveUp ||
                        t.Key == FMenuKey.MenuHlmMoveDown||
                        t.Key == FMenuKey.MenuHlmConvertToVfei
                        //t.Key == FMenuKey.MenuHlmConvertToTrs
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
                if (fObject.fObjectType == FObjectType.OpcDriver)
                {
                    mnuMenu.Tools[FMenuKey.MenuHlmAppendHostLibraryGroup].SharedProps.Visible = ((FOpcDriver)fObject).canAppendChildHostLibraryGroup;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuHlmPasteChild].SharedProps.Enabled = ((FOpcDriver)fObject).canPasteChildHostLibraryGroup;
                }
                else if (fObject.fObjectType == FObjectType.HostLibraryGroup)
                {
                    mnuMenu.Tools[FMenuKey.MenuHlmInsertBeforeHostLibraryGroup].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuHlmInsertAfterHostLibraryGroup].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuHlmAppendHostLibrary].SharedProps.Visible = fObject.canAppendChild;
                }
                else if (fObject.fObjectType == FObjectType.HostLibrary)
                {
                    mnuMenu.Tools[FMenuKey.MenuHlmInsertBeforeHostLibrary].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuHlmInsertAfterHostLibrary].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuHlmAppendHostMessageList].SharedProps.Visible = fObject.canAppendChild;
                }
                else if (fObject.fObjectType == FObjectType.HostMessageList)
                {
                    mnuMenu.Tools[FMenuKey.MenuHlmInsertBeforeHostMessageList].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuHlmInsertAfterHostMessageList].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuHlmAppendHostMessages].SharedProps.Visible = fObject.canAppendChild;
                    // --
                    //mnuMenu.Tools[FMenuKey.MenuHlmConvertToTrs].SharedProps.Enabled = true;
                }
                else if (fObject.fObjectType == FObjectType.HostMessages)
                {
                    // mnuMenu.Tools[FMenuKey.MenuHlmApplyOsmFiles].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuHlmInsertBeforeHostMessages].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuHlmInsertAfterHostMessages].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuHlmAppendPrimaryHostMessage].SharedProps.Visible = ((FHostMessages)fObject).canAppendChildPrimaryHostMessage;                    
                    if (((FHostMessages)fObject).canAppendChildSecondaryHostMessage)
                    {
                        mnuMenu.Tools[FMenuKey.MenuHlmAppendSecondaryHostMessage].SharedProps.Visible = true;
                        // --
                        mnuMenu.Toolbars[0].Tools[FMenuKey.MenuHlmAppendSecondaryHostMessage].InstanceProps.IsFirstInGroup = !((FHostMessages)fObject).canAppendChildPrimaryHostMessage;
                        ((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuHlmPopupMenu]).Tools[FMenuKey.MenuHlmAppendSecondaryHostMessage].InstanceProps.IsFirstInGroup = !((FHostMessages)fObject).canAppendChildPrimaryHostMessage;
                    }
                    mnuMenu.Tools[FMenuKey.MenuHlmConvertToVfei].SharedProps.Enabled = true;
                    //mnuMenu.Tools[FMenuKey.MenuHlmConvertToTrs].SharedProps.Enabled = true;
                }
                else if (fObject.fObjectType == FObjectType.HostMessage)
                {
                    mnuMenu.Tools[FMenuKey.MenuHlmAppendHostItem].SharedProps.Visible = fObject.canAppendChild;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuHlmConvertToVfei].SharedProps.Enabled = true;
                }
                else if (fObject.fObjectType == FObjectType.HostItem)
                {
                    mnuMenu.Tools[FMenuKey.MenuHlmInsertBeforeHostItem].SharedProps.Visible = fObject.canInsertAfter;
                    mnuMenu.Tools[FMenuKey.MenuHlmInsertAfterHostItem].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuHlmAppendHostItem].SharedProps.Visible = fObject.canAppendChild;
                }

                if (
                    fObject.fObjectType == FObjectType.HostLibraryGroup ||
                    fObject.fObjectType == FObjectType.HostLibrary ||
                    fObject.fObjectType == FObjectType.HostMessageList ||
                    fObject.fObjectType == FObjectType.HostMessages ||
                    fObject.fObjectType == FObjectType.HostMessage ||
                    fObject.fObjectType == FObjectType.HostItem
                    )
                {
                    mnuMenu.Tools[FMenuKey.MenuHlmPasteSibling].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuHlmPasteChild].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuHlmPastePrimaryHostMessage].SharedProps.Visible = false;
                    mnuMenu.Tools[FMenuKey.MenuHlmPasteSecondaryHostMessage].SharedProps.Visible = false;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuHlmRemove].SharedProps.Enabled = fObject.canRemove;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuHlmMoveUp].SharedProps.Enabled = fObject.canMoveUp;
                    mnuMenu.Tools[FMenuKey.MenuHlmMoveDown].SharedProps.Enabled = fObject.canMoveDown;
                    // -- 
                    mnuMenu.Tools[FMenuKey.MenuHlmCut].SharedProps.Enabled = fObject.canCut;
                    mnuMenu.Tools[FMenuKey.MenuHlmCopy].SharedProps.Enabled = fObject.canCopy;
                    mnuMenu.Tools[FMenuKey.MenuHlmPasteSibling].SharedProps.Enabled = fObject.canPasteSibling;
                    mnuMenu.Tools[FMenuKey.MenuHlmPasteChild].SharedProps.Enabled = fObject.canPasteChild;
                }

                if (fObject.fObjectType == FObjectType.HostMessages)
                {

                    if (
                        ((FHostMessages)fObject).canPastePrimaryHostMessage ||
                        ((FHostMessages)fObject).canPasteSecondaryHostMessage
                        )
                    {
                        mnuMenu.Tools[FMenuKey.MenuHlmPasteSibling].SharedProps.Visible = false;
                        mnuMenu.Tools[FMenuKey.MenuHlmPasteChild].SharedProps.Visible = false;
                        mnuMenu.Tools[FMenuKey.MenuHlmPastePrimaryHostMessage].SharedProps.Visible = true;
                        mnuMenu.Tools[FMenuKey.MenuHlmPasteSecondaryHostMessage].SharedProps.Visible = true;
                    }
                    // --
                    mnuMenu.Tools[FMenuKey.MenuHlmPastePrimaryHostMessage].SharedProps.Enabled = ((FHostMessages)fObject).canPastePrimaryHostMessage;
                    mnuMenu.Tools[FMenuKey.MenuHlmPasteSecondaryHostMessage].SharedProps.Enabled = ((FHostMessages)fObject).canPasteSecondaryHostMessage; 
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
                    mnuMenu.Tools[FMenuKey.MenuHlmReplace].SharedProps.Enabled = true;
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

        private void loadTreeOfObject(
            )
        {
            FOpcDriver fOcd = null;
            UltraTreeNode tNodeOcd = null;
            UltraTreeNode tNodeHlg = null;
            UltraTreeNode tNodeHlb = null;
            UltraTreeNode tNodeHml = null;
            UltraTreeNode tNodeHms = null;
            UltraTreeNode tNodeHmg = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                // ***
                // OPC Driver Load
                // ***
                fOcd = m_fOpmCore.fOpmFileInfo.fOpcDriver;
                tNodeOcd = new UltraTreeNode(fOcd.uniqueIdToString);
                tNodeOcd.Tag = fOcd;
                FCommon.refreshTreeNodeOfObject(fOcd, tvwTree, tNodeOcd);

                // --

                // ***
                // Host Library Group Load
                // ***
                foreach (FHostLibraryGroup fHlg in fOcd.fChildHostLibraryGroupCollection)
                {
                    tNodeHlg = new UltraTreeNode(fHlg.uniqueIdToString);
                    tNodeHlg.Tag = fHlg;
                    FCommon.refreshTreeNodeOfObject(fHlg, tvwTree, tNodeHlg);

                    // --

                    // ***
                    // Host Library Load
                    // ***
                    foreach (FHostLibrary fHlb in fHlg.fChildHostLibraryCollection)
                    {
                        tNodeHlb = new UltraTreeNode(fHlb.uniqueIdToString);
                        tNodeHlb.Tag = fHlb;
                        FCommon.refreshTreeNodeOfObject(fHlb, tvwTree, tNodeHlb);

                        // --

                        // ***
                        // Host Message List Load
                        // ***
                        foreach (FHostMessageList fHml in fHlb.fChildHostMessageListCollection)
                        {
                            tNodeHml = new UltraTreeNode(fHml.uniqueIdToString);
                            tNodeHml.Tag = fHml;
                            FCommon.refreshTreeNodeOfObject(fHml, tvwTree, tNodeHml);

                            // --

                            // ***
                            // Host Messages Load
                            // ***
                            foreach (FHostMessages fHms in fHml.fChildHostMessagesCollection)
                            {
                                tNodeHms = new UltraTreeNode(fHms.uniqueIdToString);
                                tNodeHms.Tag = fHms;
                                FCommon.refreshTreeNodeOfObject(fHms, tvwTree, tNodeHms);

                                // --

                                // ***
                                // Host Message Load
                                // ***
                                foreach (FHostMessage fHmg in fHms.fChildHostMessageCollection)
                                {
                                    tNodeHmg = new UltraTreeNode(fHmg.uniqueIdToString);
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
                            tNodeHlb.Nodes.Add(tNodeHml);
                        }

                        tNodeHlb.Expanded = true;
                        tNodeHlg.Nodes.Add(tNodeHlb);
                    }

                    // --

                    tNodeHlg.Expanded = true;
                    tNodeOcd.Nodes.Add(tNodeHlg);
                }

                // --

                tNodeOcd.Expanded = true;
                tvwTree.Nodes.Add(tNodeOcd);
                tvwTree.ActiveNode = tNodeOcd;

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
                fOcd = null;
                tNodeOcd = null;
                tNodeHlg = null;
                tNodeHlb = null;
                tNodeHml = null;
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

            try
            {
                tvwTree.beginUpdate();

                // --

                fParent = (FIObject)tNodeParent.Tag;
                // --
                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    foreach (FHostLibraryGroup fHlg in ((FOpcDriver)fParent).fChildHostLibraryGroupCollection)
                    {
                        tNodeChild = new UltraTreeNode(fHlg.uniqueIdToString);
                        tNodeChild.Tag = fHlg;
                        FCommon.refreshTreeNodeOfObject(fHlg, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.HostLibraryGroup)
                {
                    foreach (FHostLibrary fHlb in ((FHostLibraryGroup)fParent).fChildHostLibraryCollection)
                    {
                        tNodeChild = new UltraTreeNode(fHlb.uniqueIdToString);
                        tNodeChild.Tag = fHlb;
                        FCommon.refreshTreeNodeOfObject(fHlb, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.HostLibrary)
                {
                    foreach (FHostMessageList fHml in ((FHostLibrary)fParent).fChildHostMessageListCollection)
                    {
                        tNodeChild = new UltraTreeNode(fHml.uniqueIdToString);
                        tNodeChild.Tag = fHml;
                        FCommon.refreshTreeNodeOfObject(fHml, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.HostMessageList)
                {
                    foreach (FHostMessages fHms in ((FHostMessageList)fParent).fChildHostMessagesCollection)
                    {
                        tNodeChild = new UltraTreeNode(fHms.uniqueIdToString);
                        tNodeChild.Tag = fHms;
                        FCommon.refreshTreeNodeOfObject(fHms, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.HostMessages)
                {
                    foreach (FHostMessage fHmg in ((FHostMessages)fParent).fChildHostMessageCollection)
                    {
                        tNodeChild = new UltraTreeNode(fHmg.uniqueIdToString);
                        tNodeChild.Tag = fHmg;
                        FCommon.refreshTreeNodeOfObject(fHmg, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.HostMessage)
                {
                    foreach (FHostItem fHit in ((FHostMessage)fParent).fChildHostItemCollection)
                    {
                        tNodeChild = new UltraTreeNode(fHit.uniqueIdToString);
                        tNodeChild.Tag = fHit;
                        FCommon.refreshTreeNodeOfObject(fHit, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.HostItem)
                {
                    foreach (FHostItem fHit in ((FHostItem)fParent).fChildHostItemCollection)
                    {
                        tNodeChild = new UltraTreeNode(fHit.uniqueIdToString);
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

                if (fNewChild.fObjectType == FObjectType.HostLibraryGroup)
                {
                    tNodeParent = tvwTree.GetNodeByKey(fParent.uniqueIdToString);                   
                    fRefChild = ((FHostLibraryGroup)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.HostLibrary)
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
                    fRefChild = ((FHostLibrary)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.HostMessageList)
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
                    fRefChild = ((FHostMessageList)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.HostMessages)
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
                    fRefChild = ((FHostMessages)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.HostMessage)
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
                    fRefChild = ((FHostMessage)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.HostItem)
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
                    fRefChild = ((FHostItem)fNewChild).fNextSibling;
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                tNodeParent = null;
                tNodeNewChild = null;
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

                if (fObject.fObjectType == FObjectType.HostLibraryGroup)
                {
                    if (((FHostLibraryGroup)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FHostLibraryGroup)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.HostLibrary)
                {
                    if (((FHostLibrary)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FHostLibrary)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.HostMessageList)
                {
                    if (((FHostMessageList)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FHostMessageList)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.HostMessages)
                {
                    if (((FHostMessages)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FHostMessages)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.HostMessage)
                {
                    if (((FHostMessage)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FHostMessage)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.HostItem)
                {
                    if (((FHostItem)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FHostItem)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
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

                if (fObject.fObjectType == FObjectType.HostLibraryGroup)
                {
                    if (((FHostLibraryGroup)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FHostLibraryGroup)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.HostLibrary)
                {
                    if (((FHostLibrary)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FHostLibrary)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.HostMessageList)
                {
                    if (((FHostMessageList)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FHostMessageList)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.HostMessages)
                {
                    if (((FHostMessages)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FHostMessages)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.HostMessage)
                {
                    if (((FHostMessage)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FHostMessage)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.HostItem)
                {
                    if (((FHostItem)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FHostItem)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
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

        private void procMenuAppendObject(
            string menuKey
            )
        {
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeNewChild = null;
            FIObject fParent = null;
            FIObject fNewChild = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                tNodeParent = tvwTree.ActiveNode;
                fParent = (FIObject)tNodeParent.Tag;                                

                // --

                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    fNewChild = ((FOpcDriver)fParent).appendChildHostLibraryGroup(new FHostLibraryGroup(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                }
                else if (fParent.fObjectType == FObjectType.HostLibraryGroup)
                {
                    fNewChild = ((FHostLibraryGroup)fParent).appendChildHostLibrary(new FHostLibrary(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                }
                else if (fParent.fObjectType == FObjectType.HostLibrary)
                {
                    fNewChild = ((FHostLibrary)fParent).appendChildHostMessageList(new FHostMessageList(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                }
                else if (fParent.fObjectType == FObjectType.HostMessageList)
                {
                    fNewChild = ((FHostMessageList)fParent).appendChildHostMessages(new FHostMessages(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                }
                else if (fParent.fObjectType == FObjectType.HostMessages)
                {
                    if (menuKey == FMenuKey.MenuHlmAppendPrimaryHostMessage)
                    {
                        fNewChild = ((FHostMessages)fParent).appendChildPrimaryHostMessage(new FHostMessage(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                    }
                    else
                    {
                        fNewChild = ((FHostMessages)fParent).appendChildSecondaryHostMessage(new FHostMessage(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                    }
                }
                else if (fParent.fObjectType == FObjectType.HostMessage)
                {
                    fNewChild = ((FHostMessage)fParent).appendChildHostItem(new FHostItem(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                }
                else if (fParent.fObjectType == FObjectType.HostItem)
                {
                    fNewChild = new FHostItem(this.m_fOpmCore.fOpmFileInfo.fOpcDriver);
                    if (((FHostItem)fParent).fFormat == FFormat.AsciiList)
                    {
                        ((FHostItem)fNewChild).fFormat = FFormat.Ascii;
                    }
                    fNewChild = ((FHostItem)fParent).appendChildHostItem((FHostItem)fNewChild);
                }

                // --

                tNodeNewChild = new UltraTreeNode(fNewChild.uniqueIdToString);
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

            try
            {
                tvwTree.beginUpdate();

                // --

                tNodeRefChild = tvwTree.ActiveNode;
                tNodeParent = tNodeRefChild.Parent;
                fRefChild = (FIObject)tNodeRefChild.Tag;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    fNewChild = ((FOpcDriver)fParent).insertBeforeChildHostLibraryGroup(
                        new FHostLibraryGroup(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FHostLibraryGroup)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.HostLibraryGroup)
                {
                    fNewChild = ((FHostLibraryGroup)fParent).insertBeforeChildHostLibrary(
                        new FHostLibrary(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FHostLibrary)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.HostLibrary)
                {
                    fNewChild = ((FHostLibrary)fParent).insertBeforeChildHostMessageList(
                        new FHostMessageList(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FHostMessageList)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.HostMessageList)
                {
                    fNewChild = ((FHostMessageList)fParent).insertBeforeChildHostMessages(
                        new FHostMessages(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FHostMessages)fRefChild
                        );
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
                        new FHostItem(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FHostItem)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.HostItem)
                {
                    fNewChild = new FHostItem(this.m_fOpmCore.fOpmFileInfo.fOpcDriver);
                    if (((FHostItem)fParent).fFormat == FFormat.AsciiList)
                    {
                        ((FHostItem)fNewChild).fFormat = FFormat.Ascii;
                    }
                    fNewChild = ((FHostItem)fParent).insertBeforeChildHostItem((FHostItem)fNewChild, (FHostItem)fRefChild);
                }

                // --

                tNodeNewChild = new UltraTreeNode(fNewChild.uniqueIdToString);
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

            try
            {
                tvwTree.beginUpdate();

                // --

                tNodeRefChild = tvwTree.ActiveNode;
                tNodeParent = tNodeRefChild.Parent;
                fRefChild = (FIObject)tNodeRefChild.Tag;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    fNewChild = ((FOpcDriver)fParent).insertAfterChildHostLibraryGroup(
                        new FHostLibraryGroup(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FHostLibraryGroup)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.HostLibraryGroup)
                {
                    fNewChild = ((FHostLibraryGroup)fParent).insertAfterChildHostLibrary(
                        new FHostLibrary(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FHostLibrary)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.HostLibrary)
                {
                    fNewChild = ((FHostLibrary)fParent).insertAfterChildHostMessageList(
                        new FHostMessageList(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FHostMessageList)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.HostMessageList)
                {
                    fNewChild = ((FHostMessageList)fParent).insertAfterChildHostMessages(
                        new FHostMessages(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FHostMessages)fRefChild
                        );
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
                        new FHostItem(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FHostItem)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.HostItem)
                {
                    fNewChild = new FHostItem(this.m_fOpmCore.fOpmFileInfo.fOpcDriver);
                    if (((FHostItem)fParent).fFormat == FFormat.AsciiList)
                    {
                        ((FHostItem)fNewChild).fFormat = FFormat.Ascii;
                    }
                    fNewChild = ((FHostItem)fParent).insertAfterChildHostItem((FHostItem)fNewChild, (FHostItem)fRefChild);
                }

                // --

                tNodeNewChild = new UltraTreeNode(fNewChild.uniqueIdToString);
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

            try
            {
                tvwTree.ActiveNode.Selected = true;
                tNodeParent = tvwTree.ActiveNode.Parent;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                // ***
                // Removing HOST Object Validate
                // ***
                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FHostLibraryGroup)fChild).locked)
                        {
                            FDebug.throwFException(m_fOpmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.HostLibraryGroup)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FHostLibrary)fChild).locked)
                        {
                            FDebug.throwFException(m_fOpmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.HostLibrary)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FHostMessageList)fChild).locked)
                        {
                            FDebug.throwFException(m_fOpmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
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
                            FDebug.throwFException(m_fOpmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
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
                            FDebug.throwFException(m_fOpmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
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
                            FDebug.throwFException(m_fOpmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
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
                            FDebug.throwFException(m_fOpmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }

                // --

                // ***
                // Remove HOST Object가 1개 이상일 경우 사용자에게 Confirm를 받는다.
                // ***
                if (tvwTree.SelectedNodes.Count > 1)
                {
                    dialogResult = FMessageBox.showQuestion(
                        FConstants.ApplicationName,
                        m_fOpmCore.fWsmCore.fUIWizard.generateMessage("Q0004", new object[] { "Object" }),
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button2,
                        m_fOpmCore.fWsmCore.fWsmContainer
                        );
                    if (dialogResult == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                }

                // --

                // ***
                // HOST Object Remove
                // ***
                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    fChilds = new FHostLibraryGroup[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FHostLibraryGroup)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FOpcDriver)fParent).removeChildHostLibraryGroup((FHostLibraryGroup[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.HostLibraryGroup)
                {
                    fChilds = new FHostLibrary[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FHostLibrary)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FHostLibraryGroup)fParent).removeChildHostLibrary((FHostLibrary[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.HostLibrary)
                {
                    fChilds = new FHostMessageList[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FHostMessageList)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FHostLibrary)fParent).removeChildHostMessageList((FHostMessageList[])fChilds);
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
                }

                // --

                tvwTree.beginUpdate();

                // --

                foreach (FIObject f in fChilds)
                {
                    tvwTree.GetNodeByKey(f.uniqueIdToString).Remove();
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
                tNode = tvwTree.ActiveNode;
                fObject = (FIObject)tNode.Tag;

                //--

                if (fObject.fObjectType == FObjectType.HostLibraryGroup)
                {
                    ((FHostLibraryGroup)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.HostLibrary)
                {
                    ((FHostLibrary)fObject).moveUp();
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

                tvwTree.beginUpdate();
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
                tNode = tvwTree.ActiveNode;
                fObject = (FIObject)tNode.Tag;

                //--

                if (fObject.fObjectType == FObjectType.HostLibraryGroup)
                {
                    ((FHostLibraryGroup)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.HostLibrary)
                {
                    ((FHostLibrary)fObject).moveDown();
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

                tvwTree.beginUpdate();
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

                m_fOpmCore.fOpmContainer.showRelationViewer((FIObject)tvwTree.ActiveNode.Tag);
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

                if (fObject.fObjectType == FObjectType.OpcDriver)
                {
                    tvwTree.ActiveNode.Expanded = true;
                    // --
                    foreach (UltraTreeNode tNodeHlg in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeHlg.Expanded = true;
                        // -- 
                        foreach (UltraTreeNode tNodeHlb in tNodeHlg.Nodes)
                        {
                            tNodeHlb.Expanded = true;
                            // --
                            foreach (UltraTreeNode tNodeHml in tNodeHlb.Nodes)
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
                else if (fObject.fObjectType == FObjectType.HostLibraryGroup)
                {
                    tvwTree.ActiveNode.Expanded = true;
                    // --
                    foreach (UltraTreeNode tNodeHlb in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeHlb.Expanded = true;
                        // --
                        foreach (UltraTreeNode tNodeHml in tNodeHlb.Nodes)
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
                else if (fObject.fObjectType == FObjectType.HostLibrary)
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
                else if (fObject.fObjectType == FObjectType.HostMessageList)
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

                if (fObject.fObjectType == FObjectType.OpcDriver)
                {
                    foreach (UltraTreeNode tNodeHlg in tvwTree.ActiveNode.Nodes)
                    {
                        foreach (UltraTreeNode tNodeHlb in tNodeHlg.Nodes)
                        {
                            foreach (UltraTreeNode tNodeHml in tNodeHlb.Nodes)
                            {
                                foreach (UltraTreeNode tNodeHms in tNodeHml.Nodes)
                                {
                                    tNodeHms.Expanded = false;
                                }
                                // --
                                tNodeHml.Expanded = false;
                            }
                            // --
                            tNodeHlb.Expanded = false;
                        }
                        // --
                        tNodeHlg.Expanded = false;
                    }
                    // --
                    tvwTree.ActiveNode.Expanded = false;
                }
                else if (fObject.fObjectType == FObjectType.HostLibraryGroup)
                {
                    foreach (UltraTreeNode tNodeHlb in tvwTree.ActiveNode.Nodes)
                    {
                        foreach (UltraTreeNode tNodeHml in tNodeHlb.Nodes)
                        {
                            foreach (UltraTreeNode tNodeHms in tNodeHml.Nodes)
                            {
                                tNodeHms.Expanded = false;
                            }
                            // --
                            tNodeHml.Expanded = false;
                        }
                        // --
                        tNodeHlb.Expanded = false;
                    }
                    // --
                    tvwTree.ActiveNode.Expanded = false;
                }
                else if (fObject.fObjectType == FObjectType.HostLibrary)
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
                    tvwTree.ActiveNode.CollapseAll();
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
                    fObject = (FIObject)tvwTree.ActiveNode.Tag;
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fVfeiViewer = null;
                fObject = null;
                sb = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuTrsViewer(
            )
        {
            //FView fView = null;
            //FTrsViewer fTrsViewer = null;
            //FIObject fObject = null;

            //try
            //{
            //    fView = (FView)m_fOpmCore.fOpmContainer.getChild(typeof(FView));

            //    // --
            //    if (fView == null)
            //    {
            //        fView = new FView(m_fOpmCore);
            //        m_fOpmCore.fOpmContainer.showChild(fView);
            //    }

            //    fView.activate();

            //    fTrsViewer = (FTrsViewer)fView.getChild(typeof(FVfeiViewer));

            //    if (fTrsViewer == null)
            //    {
            //        fTrsViewer = new FTrsViewer(m_fOpmCore);
            //        fView.showChild(fTrsViewer);
            //    }

            //    fTrsViewer.activate();

            //    fObject = (FIObject)tvwTree.ActiveNode.Tag;

            //    // --

            //    if (fObject.fObjectType == FObjectType.HostMessages)
            //    {
            //        fTrsViewer.appendTrs(((FHostMessages)fObject).convertToTrs());
            //    }
            //    else if (fObject.fObjectType == FObjectType.HostMessageList)
            //    {
            //        fTrsViewer.appendTrs(((FHostMessageList)fObject).convertToTrs());
            //    }
            //}
            //catch (Exception ex)
            //{
            //    FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            //}
            //finally
            //{
            //    fView = null;
            //    fTrsViewer = null;
            //}
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
                    m_fOpmCore,
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

                if (fObject.fObjectType == FObjectType.HostLibraryGroup)
                {
                    ((FHostLibraryGroup)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.HostLibrary)
                {
                    ((FHostLibrary)fObject).cut();
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

                if (fObject.fObjectType == FObjectType.HostLibraryGroup)
                {
                    ((FHostLibraryGroup)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.HostLibrary)
                {
                    ((FHostLibrary)fObject).copy();
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

        private void procMenuApplyOSMFiles(
            )
        {
            UltraTreeNode tNode = null;
            FIObject fObject = null;

            try
            {
                tNode = tvwTree.ActiveNode;
                fObject = (FIObject)tNode.Tag;

                // --

                if (fObject.fObjectType == FObjectType.HostMessages)
                {
                    ((FHostMessages)fObject).copy();
                    // --
                    m_fOpmCore.fOpmContainer.procMenuApplyOSMFiles();
                }

                // --
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

            try
            {
                tNodeRef = tvwTree.ActiveNode;
                fRefObject = (FIObject)tNodeRef.Tag;

                // --

                tvwTree.beginUpdate();
                // --
                if (fRefObject.fObjectType == FObjectType.HostLibraryGroup)
                {
                    fNewObject = ((FHostLibraryGroup)fRefObject).pasteSibling();
                }
                else if (fRefObject.fObjectType == FObjectType.HostLibrary)
                {
                    fNewObject = ((FHostLibrary)fRefObject).pasteSibling();
                }
                else if (fRefObject.fObjectType == FObjectType.HostMessageList)
                {
                    fNewObject = ((FHostMessageList)fRefObject).pasteSibling();
                }
                else if (fRefObject.fObjectType == FObjectType.HostMessages)
                {
                    fNewObject = ((FHostMessages)fRefObject).pasteSibling();
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
                }

                tNodeNew = new UltraTreeNode(fNewObject.uniqueIdToString);
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
            UltraTreeNode tNodeChild = null;
            FIObject fParent = null;
            FIObject fChild = null;

            try
            {
                tNodeParent = tvwTree.ActiveNode;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    fChild = ((FOpcDriver)fParent).pasteChildHostLibraryGroup();
                }
                else if (fParent.fObjectType == FObjectType.HostLibraryGroup)
                {
                    fChild = ((FHostLibraryGroup)fParent).pasteChild();
                }
                else if (fParent.fObjectType == FObjectType.HostLibrary)
                {
                    fChild = ((FHostLibrary)fParent).pasteChild();
                }
                else if (fParent.fObjectType == FObjectType.HostMessageList)
                {
                    fChild = ((FHostMessageList)fParent).pasteChild();
                }
                else if (fParent.fObjectType == FObjectType.HostMessages)
                {
                    // ***
                    // 사용하지 않음
                    // ***
                }
                else if (fParent.fObjectType == FObjectType.HostMessage)
                {
                    fChild = ((FHostMessage)fParent).pasteChild();
                }
                else if (fParent.fObjectType == FObjectType.HostItem)
                {
                    fChild = ((FHostItem)fParent).pasteChild();
                }

                tNodeChild = new UltraTreeNode(fChild.uniqueIdToString);
                tNodeChild.Tag = fChild;
                FCommon.refreshTreeNodeOfObject(fChild, tvwTree, tNodeChild);

                // --

                loadTreeOfChildObject(tNodeChild);
                tNodeParent.Nodes.Add(tNodeChild);
                // --
                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tNodeChild;

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
                tNodeChild = null;
                fParent = null;
                fChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuPastePrimaryHostMessage(
            )
        {
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeChild = null;
            FIObject fParent = null;
            FIObject fChild = null;

            try
            {
                tNodeParent = tvwTree.ActiveNode;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                if (fParent.fObjectType == FObjectType.HostMessages)
                {
                    fChild = ((FHostMessages)fParent).pastePrimaryHostMessage();
                }


                tNodeChild = new UltraTreeNode(fChild.uniqueIdToString);
                tNodeChild.Tag = fChild;
                FCommon.refreshTreeNodeOfObject(fChild, tvwTree, tNodeChild);

                // --

                loadTreeOfChildObject(tNodeChild);
                tNodeParent.Nodes.Insert(0, tNodeChild);
                // --
                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tNodeChild;

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
                tNodeChild = null;
                fParent = null;
                fChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuPasteSecondaryHostMessage(
            )
        {
            UltraTreeNode tNodeParent = null;
            UltraTreeNode tNodeChild = null;
            FIObject fParent = null;
            FIObject fChild = null;

            try
            {
                tNodeParent = tvwTree.ActiveNode;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                if (fParent.fObjectType == FObjectType.HostMessages)
                {
                    fChild = ((FHostMessages)fParent).pasteSecondaryHostMessage();
                }


                tNodeChild = new UltraTreeNode(fChild.uniqueIdToString);
                tNodeChild.Tag = fChild;
                FCommon.refreshTreeNodeOfObject(fChild, tvwTree, tNodeChild);

                // --

                loadTreeOfChildObject(tNodeChild);
                tNodeParent.Nodes.Add(tNodeChild);
                // --
                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tNodeChild;

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
                tNodeChild = null;
                fParent = null;
                fChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSearch(
            string searchWord
            )
        {
            UltraTreeNode tNode = null;
            FIObject fBase = null;
            FIObject fResult = null;

            try
            {
                tNode = tvwTree.ActiveNode;
                fBase = (FIObject)tNode.Tag;

                // --

                fResult = m_fOpmCore.fOpmFileInfo.fOpcDriver.searchHostLibrarySeries(fBase, searchWord);
                if (fResult == null)
                {
                    FMessageBox.showInformation("Search", m_fOpmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { searchWord }), this);
                    return;
                }

                // --

                tvwTree.beginUpdate();

                // --

                expandTreeForSearch(fResult);
                tNode = tvwTree.GetNodeByKey(fResult.uniqueIdToString);
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

                expandTreeForSearch(fObject);
                tNode = tvwTree.GetNodeByKey(fObject.uniqueIdToString);
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

        private void expandTreeForSearch(
            FIObject fObject
            )
        {
            FIObject fParent = null;
            UltraTreeNode tNodeParent = null;

            try
            {
                if (fObject.fObjectType == FObjectType.OpcDriver)
                {
                    return;
                }
                
                // --

                fParent = m_fOpmCore.fOpmFileInfo.fOpcDriver.getParentOfObject(fObject);

                // --

                tNodeParent = tvwTree.GetNodeByKey(fParent.uniqueIdToString);
                if (tNodeParent == null || !tNodeParent.Expanded)
                {
                    expandTreeForSearch(fParent);
                }

                // --

                if (tNodeParent == null)
                {
                    tNodeParent = tvwTree.GetNodeByKey(fParent.uniqueIdToString);
                }
                tNodeParent.Expanded = true;
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

        #region FHostLibraryModeler Form Event Handler

        private void FHostLibraryModeler_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designTreeOfHostLibraryModeler();

                // --

                tvwTree.setPopupMenu((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuHlmPopupMenu]);

                // --

                m_fEventHandler = new FEventHandler(m_fOpmCore.fOpmFileInfo.fOpcDriver, tvwTree);
                // --
                m_fEventHandler.ObjectInsertBeforeCompleted += new FObjectInsertBeforeCompletedEventHandler(m_fEventHandler_ObjectInsertBeforeCompleted);
                m_fEventHandler.ObjectInsertAfterCompleted += new FObjectInsertAfterCompletedEventHandler(m_fEventHandler_ObjectInsertAfterCompleted);
                m_fEventHandler.ObjectAppendCompleted += new FObjectAppendCompletedEventHandler(m_fEventHandler_ObjectAppendCompleted);
                m_fEventHandler.ObjectRemoveCompleted += new FObjectRemoveCompletedEventHandler(m_fEventHandler_ObjectRemoveCompleted);
                m_fEventHandler.ObjectMoveUpCompleted += new FObjectMoveUpCompletedEventHandler(m_fEventHandler_ObjectMoveUpCompleted);
                m_fEventHandler.ObjectMoveDownCompleted += new FObjectMoveDownCompletedEventHandler(m_fEventHandler_ObjectMoveDownCompleted);
                m_fEventHandler.ObjectMoveToCompleted += new FObjectMoveToCompletedEventHandler(m_fEventHandler_ObjectMoveToCompleted);
                m_fEventHandler.ObjectModifyCompleted += new FObjectModifyCompletedEventHandler(m_fEventHandler_ObjectModifyCompleted);

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

        private void FHostLibraryModeler_Shown(
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FHostLibraryModeler_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                if (m_fEventHandler != null)
                {
                    m_fOpmCore.fOpmFileInfo.fOpcDriver.waitEventHandlingCompleted();

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

        #region m_fEventHandler Object Event Handler

        private void m_fEventHandler_ObjectInsertBeforeCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.HostLibraryGroup ||
                    e.fObject.fObjectType == FObjectType.HostLibrary ||
                    e.fObject.fObjectType == FObjectType.HostMessageList ||
                    e.fObject.fObjectType == FObjectType.HostMessages ||
                    e.fObject.fObjectType == FObjectType.HostMessage ||
                    e.fObject.fObjectType == FObjectType.HostItem
                    )
                {
                    addTreeOfObject(e.fParentObject, e.fObject);
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

        private void m_fEventHandler_ObjectInsertAfterCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.HostLibraryGroup ||
                    e.fObject.fObjectType == FObjectType.HostLibrary ||
                    e.fObject.fObjectType == FObjectType.HostMessageList ||
                    e.fObject.fObjectType == FObjectType.HostMessages ||
                    e.fObject.fObjectType == FObjectType.HostMessage ||
                    e.fObject.fObjectType == FObjectType.HostItem
                    )
                {
                    addTreeOfObject(e.fParentObject, e.fObject);
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

        private void m_fEventHandler_ObjectAppendCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.HostLibraryGroup ||
                    e.fObject.fObjectType == FObjectType.HostLibrary ||
                    e.fObject.fObjectType == FObjectType.HostMessageList ||
                    e.fObject.fObjectType == FObjectType.HostMessages ||
                    e.fObject.fObjectType == FObjectType.HostMessage ||
                    e.fObject.fObjectType == FObjectType.HostItem
                    )
                {
                    addTreeOfObject(e.fParentObject, e.fObject);
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

        private void m_fEventHandler_ObjectRemoveCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.HostLibraryGroup ||
                    e.fObject.fObjectType == FObjectType.HostLibrary ||
                    e.fObject.fObjectType == FObjectType.HostMessageList ||
                    e.fObject.fObjectType == FObjectType.HostMessages ||
                    e.fObject.fObjectType == FObjectType.HostMessage ||
                    e.fObject.fObjectType == FObjectType.HostItem
                    )
                {
                    removeTreeOfObject(e.fObject);
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

        private void m_fEventHandler_ObjectMoveUpCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.HostLibraryGroup ||
                    e.fObject.fObjectType == FObjectType.HostLibrary ||
                    e.fObject.fObjectType == FObjectType.HostMessageList ||
                    e.fObject.fObjectType == FObjectType.HostMessages ||
                    e.fObject.fObjectType == FObjectType.HostMessage ||
                    e.fObject.fObjectType == FObjectType.HostItem
                    )
                {
                    moveUpTreeOfObject(e.fObject);
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

        private void m_fEventHandler_ObjectMoveDownCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.HostLibraryGroup ||
                    e.fObject.fObjectType == FObjectType.HostLibrary ||
                    e.fObject.fObjectType == FObjectType.HostMessageList ||
                    e.fObject.fObjectType == FObjectType.HostMessages ||
                    e.fObject.fObjectType == FObjectType.HostMessage ||
                    e.fObject.fObjectType == FObjectType.HostItem
                    )
                {
                    moveDownTreeOfObject(e.fObject);
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

        private void m_fEventHandler_ObjectMoveToCompleted(
            object sender,
            FObjectMoveToCompletedEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.HostLibraryGroup ||
                    e.fObject.fObjectType == FObjectType.HostLibrary ||
                    e.fObject.fObjectType == FObjectType.HostMessageList ||
                    e.fObject.fObjectType == FObjectType.HostMessages ||
                    e.fObject.fObjectType == FObjectType.HostMessage ||                    
                    e.fObject.fObjectType == FObjectType.HostItem
                    )
                {
                    moveToTreeOfObject(e.fObject, e.fRefObject);
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

        private void m_fEventHandler_ObjectModifyCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.OpcDriver ||
                    e.fObject.fObjectType == FObjectType.HostLibraryGroup ||
                    e.fObject.fObjectType == FObjectType.HostLibrary ||
                    e.fObject.fObjectType == FObjectType.HostMessageList ||
                    e.fObject.fObjectType == FObjectType.HostMessages ||
                    e.fObject.fObjectType == FObjectType.HostMessage ||
                    e.fObject.fObjectType == FObjectType.HostItem
                    )
                {
                    refreshObject(e.fObject);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region tvwTree Contol Event Handler

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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                if (fObject.fObjectType == FObjectType.OpcDriver)
                {
                    pgdProp.selectedObject = new FPropOcd(m_fOpmCore, pgdProp, (FOpcDriver)fObject);
                }
                else if (fObject.fObjectType == FObjectType.HostLibraryGroup)
                {
                    pgdProp.selectedObject = new FPropHlg(m_fOpmCore, pgdProp, (FHostLibraryGroup)fObject);
                }
                else if (fObject.fObjectType == FObjectType.HostLibrary)
                {
                    pgdProp.selectedObject = new FPropHlb(m_fOpmCore, pgdProp, (FHostLibrary)fObject);
                }
                else if (fObject.fObjectType == FObjectType.HostMessageList)
                {
                    pgdProp.selectedObject = new FPropHml(m_fOpmCore, pgdProp, (FHostMessageList)fObject);
                }
                else if (fObject.fObjectType == FObjectType.HostMessages)
                {
                    pgdProp.selectedObject = new FPropHms(m_fOpmCore, pgdProp, (FHostMessages)fObject);
                }
                else if (fObject.fObjectType == FObjectType.HostMessage)
                {
                    pgdProp.selectedObject = new FPropHmg(m_fOpmCore, pgdProp, (FHostMessage)fObject);                    
                }
                else if (fObject.fObjectType == FObjectType.HostItem)
                {
                    if (((FHostItem)fObject).removed)
                    {
                        return;
                    }
                    pgdProp.selectedObject = new FPropHit(m_fOpmCore, pgdProp, (FHostItem)fObject);
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
            FIObject fObject = null;

            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuHlmRemove].SharedProps.Enabled == true)
                    {
                        procMenuRemoveObject();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.X)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuHlmCut].SharedProps.Enabled == true)
                    {
                        procMenuCut();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.C)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuHlmCopy].SharedProps.Enabled == true)
                    {
                        procMenuCopy();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.V)
                {
                    fObject = (FIObject)this.tvwTree.ActiveNode.Tag;

                    if (fObject.fObjectType == FObjectType.HostMessages)
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuHlmPastePrimaryHostMessage].SharedProps.Enabled == true)
                        {
                            procMenuPastePrimaryHostMessage();                           
                        }
                        else if (mnuMenu.Tools[FMenuKey.MenuHlmPasteSibling].SharedProps.Enabled == true)
                        {
                            procMenuPasteSibling();                            
                        }
                    }
                    else
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuHlmPasteSibling].SharedProps.Enabled == true)
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
                        if (mnuMenu.Tools[FMenuKey.MenuHlmPasteSecondaryHostMessage].SharedProps.Enabled == true)
                        {
                            procMenuPasteSecondaryHostMessage();
                        }
                        else if(mnuMenu.Tools[FMenuKey.MenuHlmPasteChild].SharedProps.Enabled == true)
                        {
                            procMenuPasteChild();
                        }
                    }
                    else
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuHlmPasteChild].SharedProps.Enabled == true)
                        {
                            procMenuPasteChild();
                        }
                    }
                }
                else if (e.Control && e.KeyCode == Keys.U)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuHlmMoveUp].SharedProps.Enabled == true)
                    {
                        procMenuMoveUpObject(FMenuKey.MenuHlmMoveUp);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.D)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuHlmMoveDown].SharedProps.Enabled == true)
                    {
                        procMenuMoveDownObject(FMenuKey.MenuHlmMoveDown);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.E)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuHlmExpand].SharedProps.Enabled == true)
                    {
                        procMenuExpand();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.L)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuHlmCollapse].SharedProps.Enabled == true)
                    {
                        procMenuCollapse();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.R)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuHlmRelation].SharedProps.Enabled == true)
                    {
                        procMenuRelation();
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
                tvwTree.DoDragDrop(new DataObject(fDragDropData), DragDropEffects.All);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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

                    if (fRefObject.fObjectType == FObjectType.OpcDriver)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.HostLibraryGroup)
                        {
                            #region HostLibraryGroup

                            if (((FOpcDriver)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                cnt = ((FOpcDriver)fRefObject).fChildHostLibraryGroupCollection.count;
                                fRefObject = ((FOpcDriver)fRefObject).fChildHostLibraryGroupCollection[cnt - 1];
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
                    else if (fRefObject.fObjectType == FObjectType.HostLibraryGroup)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.HostLibraryGroup)
                        {
                            #region HostLibraryGroup

                            if (((FHostLibraryGroup)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FHostLibraryGroup)fRefObject).fNextSibling == null || !((FHostLibraryGroup)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostLibrary)
                        {
                            #region HostLibrary

                            if (((FHostLibraryGroup)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                cnt = ((FHostLibraryGroup)fRefObject).fChildHostLibraryCollection.count;
                                if (cnt == 0)
                                {
                                    e.Effect = DragDropEffects.Move;
                                    return;
                                }
                                else
                                {
                                    fRefObject = ((FHostLibraryGroup)fRefObject).fChildHostLibraryCollection[cnt - 1];
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
                    else if (fRefObject.fObjectType == FObjectType.HostLibrary)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.HostLibrary)
                        {
                            #region HostLibrary

                            if (((FHostLibrary)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FHostLibrary)fRefObject).fNextSibling == null || !((FHostLibrary)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostMessageList)
                        {
                            #region HostMessageList

                            if (((FHostLibrary)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                // ***
                                // Host Message List는 다른 Host Library로 Move 할 수 없다.
                                // ***
                                if (
                                    fDragDropData.sessionUniqueId == string.Empty &&
                                    ((FHostLibrary)fRefObject).Equals(((FHostMessageList)fDragDropData.fObject).fParent)
                                    )
                                {
                                    cnt = ((FHostLibrary)fRefObject).fChildHostMessageListCollection.count;
                                    fRefObject = ((FHostLibrary)fRefObject).fChildHostMessageListCollection[cnt - 1];
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
                        if (fDragDropData.fObject.fObjectType == FObjectType.HostMessageList)
                        {
                            #region HostMessageList

                            if (!fRefObject.Equals(fDragDropData.fObject))
                            {
                                if (((FHostMessageList)fRefObject).equalsModelingFile(fDragDropData.fObject))
                                {
                                    // ***
                                    // Host Message List는 다른 Host Library로 Move 할 수 없다.
                                    // ***
                                    if (
                                        fDragDropData.sessionUniqueId == string.Empty &&
                                        ((FHostMessageList)fRefObject).fParent.Equals(((FHostMessageList)fDragDropData.fObject).fParent)
                                        )
                                    {
                                        if (
                                            ((FHostMessageList)fRefObject).fNextSibling == null ||
                                            !((FHostMessageList)fRefObject).fNextSibling.Equals(fDragDropData.fObject)
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
                                    fDragDropData.sessionUniqueId == string.Empty &&
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
                        if (fDragDropData.fObject.fObjectType == FObjectType.HostMessages)
                        {
                            #region HostMessages

                            if (((FHostMessages)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                // ***
                                // Host Messages는 다른 Host Library로 Move 할 수 없다.
                                // ***
                                if (
                                    fDragDropData.sessionUniqueId == string.Empty &&
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
                        if (fDragDropData.fObject.fObjectType == FObjectType.HostItem)
                        {
                            #region HostItem

                            if (((FHostMessage)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FHostMessage)fRefObject).Equals(((FHostItem)fDragDropData.fObject).fAncestorHostMessage) &&
                                    !((FHostMessage)fRefObject).fChildHostItemCollection[((FHostMessage)fRefObject).fChildHostItemCollection.count - 1].Equals(fDragDropData.fObject) &&
                                    fDragDropData.sessionUniqueId == string.Empty
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
                        if (fDragDropData.fObject.fObjectType == FObjectType.HostItem)
                        {
                            #region HostItem

                            if (((FHostItem)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    fDragDropData.sessionUniqueId == string.Empty &&
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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

                    if (fRefObject.fObjectType == FObjectType.OpcDriver)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.HostLibraryGroup)
                        {
                            #region HostLibraryGroup

                            if (e.Effect == DragDropEffects.Move)
                            {
                                cnt = ((FOpcDriver)fRefObject).fChildHostLibraryGroupCollection.count;
                                fRefObject = ((FOpcDriver)fRefObject).fChildHostLibraryGroupCollection[cnt - 1];
                                ((FHostLibraryGroup)fDragDropData.fObject).moveTo((FHostLibraryGroup)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FHostLibraryGroup)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FOpcDriver)fRefObject).pasteChildHostLibraryGroup();
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
                    else if (fRefObject.fObjectType == FObjectType.HostLibraryGroup)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.HostLibraryGroup)
                        {
                            #region HostLibraryGroup

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FHostLibraryGroup)fDragDropData.fObject).moveTo((FHostLibraryGroup)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FHostLibraryGroup)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FHostLibraryGroup)fRefObject).pasteSibling();
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

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FHostLibrary)fDragDropData.fObject).moveTo((FHostLibraryGroup)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FHostLibrary)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FHostLibraryGroup)fRefObject).pasteChild();
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
                    else if (fRefObject.fObjectType == FObjectType.HostLibrary)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.HostLibrary)
                        {
                            #region HostLibrary

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FHostLibrary)fDragDropData.fObject).moveTo((FHostLibrary)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FHostLibrary)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FHostLibrary)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
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
                                ((FHostMessageList)fDragDropData.fObject).moveTo((FHostLibrary)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FHostMessageList)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FHostLibrary)fRefObject).pasteChild();
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
                                fDataSetGenertor = new FDataSetGenerator(m_fOpmCore, (FDataSet)fDragDropData.fObject, fRefObject);
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
                        else
                        {
                            return;
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.HostItem)
                    {
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
                        if (
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog ||
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog
                            )
                        {
                            #region HostMessageLog

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fHms = new FHostMessages(m_fOpmCore.fOpmFileInfo.fOpcDriver);

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
                                tNode = new UltraTreeNode(fHms.uniqueIdToString);
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
                        if (
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog ||
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog
                            )
                        {
                            #region HostMessageLog

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fHms = new FHostMessages(m_fOpmCore.fOpmFileInfo.fOpcDriver);

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
                                tNode = new UltraTreeNode(fHms.uniqueIdToString);
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
                    uniqueId = fDragDropData.fObject.uniqueIdToString;
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

                    refUniqueId = fRefObject.uniqueIdToString;
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
                    if (
                        fRefObject.fObjectType == FObjectType.HostMessage ||
                        fRefObject.fObjectType == FObjectType.HostItem
                        )
                    {
                        tRefNode = tvwTree.GetNodeByKey(fRefObject.uniqueIdToString);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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

                if (e.Tool.Key == FMenuKey.MenuHlmExpand)
                {
                    procMenuExpand();
                }
                else if (e.Tool.Key == FMenuKey.MenuHlmCollapse)
                {
                    procMenuCollapse();
                }
                else if (e.Tool.Key == FMenuKey.MenuHlmReplace)
                {
                    procMenuReplace();
                }
                else if (e.Tool.Key == FMenuKey.MenuHlmCut)
                {
                    procMenuCut();
                }
                else if (e.Tool.Key == FMenuKey.MenuHlmCopy)
                {
                    procMenuCopy();
                }
                else if (e.Tool.Key == FMenuKey.MenuHlmPasteSibling)
                {
                    procMenuPasteSibling();
                }
                else if (e.Tool.Key == FMenuKey.MenuHlmPasteChild)
                {
                    procMenuPasteChild();
                }
                else if (e.Tool.Key == FMenuKey.MenuHlmPastePrimaryHostMessage)
                {
                    procMenuPastePrimaryHostMessage();
                }
                else if (e.Tool.Key == FMenuKey.MenuHlmPasteSecondaryHostMessage)
                {
                    procMenuPasteSecondaryHostMessage();
                }
                else if (e.Tool.Key == FMenuKey.MenuHlmRemove)
                {
                    procMenuRemoveObject();
                }
                else if (e.Tool.Key == FMenuKey.MenuHlmMoveUp)
                {
                    procMenuMoveUpObject(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuHlmMoveDown)
                {
                    procMenuMoveDownObject(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuHlmConvertToVfei)
                {
                    procMenuVfeiViewer();
                }
                //else if (e.Tool.Key == FMenuKey.MenuHlmConvertToTrs)
                //{
                //    procMenuTrsViewer();
                //}
                else if (e.Tool.Key == FMenuKey.MenuHlmRelation)
                {
                    procMenuRelation();
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuHlmInsertBeforeHostLibraryGroup ||
                    e.Tool.Key == FMenuKey.MenuHlmInsertBeforeHostLibrary ||
                    e.Tool.Key == FMenuKey.MenuHlmInsertBeforeHostMessageList ||
                    e.Tool.Key == FMenuKey.MenuHlmInsertBeforeHostMessages ||
                    e.Tool.Key == FMenuKey.MenuHlmInsertBeforeHostItem
                    )
                {
                    procMenuInsertBeforeObject(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuHlmInsertAfterHostLibraryGroup ||
                    e.Tool.Key == FMenuKey.MenuHlmInsertAfterHostLibrary ||
                    e.Tool.Key == FMenuKey.MenuHlmInsertAfterHostMessageList ||
                    e.Tool.Key == FMenuKey.MenuHlmInsertAfterHostMessages ||
                    e.Tool.Key == FMenuKey.MenuHlmInsertAfterHostItem
                    )
                {
                    procMenuInsertAfterObject(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuHlmAppendHostLibraryGroup ||
                    e.Tool.Key == FMenuKey.MenuHlmAppendHostLibrary ||
                    e.Tool.Key == FMenuKey.MenuHlmAppendHostMessageList ||
                    e.Tool.Key == FMenuKey.MenuHlmAppendHostMessages ||
                    e.Tool.Key == FMenuKey.MenuHlmAppendPrimaryHostMessage ||
                    e.Tool.Key == FMenuKey.MenuHlmAppendSecondaryHostMessage ||
                    e.Tool.Key == FMenuKey.MenuHlmAppendHostItem
                    )
                {
                    procMenuAppendObject(e.Tool.Key);
                }
                //else if (e.Tool.Key == FMenuKey.MenuHlmApplyOsmFiles)
                //{
                //    procMenuApplyOSMFiles();         
                //}          
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
