/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FTcpLibraryModeler.cs
--  Creator         : duchoi
--  Create Date     : 2013.07.24
--  Description     : FAMate TCP Modeler TCP Library Modeler Form Class 
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
using Nexplant.MC.Core.FaTcpDriver;
using Nexplant.MC.WorkspaceInterface;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinToolbars;

namespace Nexplant.MC.TcpModeler
{
    public partial class FTcpLibraryModeler : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcmCore m_fTcmCore = null;
        private FEventHandler m_fEventHandler = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTcpLibraryModeler(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpLibraryModeler(
            FTcmCore fTcmCore
            )
            : this()
        {
            base.fUIWizard = fTcmCore.fUIWizard;
            m_fTcmCore = fTcmCore;
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

        private void designTreeOfTcpLibraryModeler(
            )
        {
            try
            {
                tvwTree.ImageList = new ImageList();
                // --
                tvwTree.ImageList.Images.Add("TcpDriver", Properties.Resources.TcpDriver);
                tvwTree.ImageList.Images.Add("TcpLibraryGroup_unlock", Properties.Resources.TcpLibraryGroup_unlock);
                tvwTree.ImageList.Images.Add("TcpLibraryGroup_lock", Properties.Resources.TcpLibraryGroup_lock);
                // --
                tvwTree.ImageList.Images.Add("TcpLibrary_unlock", Properties.Resources.TcpLibrary_unlock);
                tvwTree.ImageList.Images.Add("TcpLibrary_lock", Properties.Resources.TcpLibrary_lock);
                // --
                tvwTree.ImageList.Images.Add("TcpMessageList_unlock", Properties.Resources.TcpMessageList_unlock);
                tvwTree.ImageList.Images.Add("TcpMessageList_lock", Properties.Resources.TcpMessageList_lock);
                // --
                tvwTree.ImageList.Images.Add("TcpMessages_Eq_unlock", Properties.Resources.TcpMessages_Eq_unlock);
                tvwTree.ImageList.Images.Add("TcpMessages_Eq_lock", Properties.Resources.TcpMessages_Eq_lock);
                tvwTree.ImageList.Images.Add("TcpMessages_Host_unlock", Properties.Resources.TcpMessages_Host_unlock);
                tvwTree.ImageList.Images.Add("TcpMessages_Host_lock", Properties.Resources.TcpMessages_Host_lock);
                tvwTree.ImageList.Images.Add("TcpMessages_Both_unlock", Properties.Resources.TcpMessages_Both_unlock);
                tvwTree.ImageList.Images.Add("TcpMessages_Both_lock", Properties.Resources.TcpMessages_Both_lock);
                // --
                tvwTree.ImageList.Images.Add("TcpMessage_Command_unlock", Properties.Resources.TcpMessage_Command_unlock);
                tvwTree.ImageList.Images.Add("TcpMessage_Command_lock", Properties.Resources.TcpMessage_Command_lock);
                tvwTree.ImageList.Images.Add("TcpMessage_Reply_unlock", Properties.Resources.TcpMessage_Reply_unlock);
                tvwTree.ImageList.Images.Add("TcpMessage_Reply_lock", Properties.Resources.TcpMessage_Reply_lock);
                tvwTree.ImageList.Images.Add("TcpMessage_Unsolicited_unlock", Properties.Resources.TcpMessage_Unsolicited_unlock);
                tvwTree.ImageList.Images.Add("TcpMessage_Unsolicited_lock", Properties.Resources.TcpMessage_Unsolicited_lock);
                // --
                tvwTree.ImageList.Images.Add("TcpItem_List_unlock", Properties.Resources.TcpItem_List_unlock);
                tvwTree.ImageList.Images.Add("TcpItem_List_lock", Properties.Resources.TcpItem_List_lock);
                tvwTree.ImageList.Images.Add("TcpItem_unlock", Properties.Resources.TcpItem_unlock);
                tvwTree.ImageList.Images.Add("TcpItem_lock", Properties.Resources.TcpItem_lock);
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
                        t.Key == FMenuKey.MenuTlmExpand ||
                        t.Key == FMenuKey.MenuTlmCollapse ||
                        t.Key == FMenuKey.MenuTlmRelation
                        )
                    {
                        continue;
                    }
                    else if (
                        t.Key == FMenuKey.MenuTlmReplace ||
                        t.Key == FMenuKey.MenuTlmCut||
                        t.Key == FMenuKey.MenuTlmCopy||
                        t.Key == FMenuKey.MenuTlmPasteSibling||
                        t.Key == FMenuKey.MenuTlmPasteChild||
                        t.Key == FMenuKey.MenuTlmRemove ||
                        t.Key == FMenuKey.MenuTlmMoveUp ||
                        t.Key == FMenuKey.MenuTlmMoveDown ||
                        t.Key == FMenuKey.MenuTlmConvertToXlg
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
                // --
                if (fObject.fObjectType == FObjectType.TcpDriver)
                {
                    mnuMenu.Tools[FMenuKey.MenuTlmAppendTcpLibraryGroup].SharedProps.Visible = ((FTcpDriver)fObject).canAppendChildTcpLibraryGroup;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuTlmPasteChild].SharedProps.Enabled = ((FTcpDriver)fObject).canPasteChildTcpLibraryGroup;
                }
                else if (fObject.fObjectType == FObjectType.TcpLibraryGroup)
                {
                    mnuMenu.Tools[FMenuKey.MenuTlmInsertBeforeTcpLibraryGroup].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuTlmInsertAfterTcpLibraryGroup].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuTlmAppendTcpLibrary].SharedProps.Visible = fObject.canAppendChild;
                }
                else if (fObject.fObjectType == FObjectType.TcpLibrary)
                {
                    mnuMenu.Tools[FMenuKey.MenuTlmInsertBeforeTcpLibrary].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuTlmInsertAfterTcpLibrary].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuTlmAppendTcpMessageList].SharedProps.Visible = fObject.canAppendChild;
                }
                else if (fObject.fObjectType == FObjectType.TcpMessageList)
                {
                    mnuMenu.Tools[FMenuKey.MenuTlmInsertBeforeTcpMessageList].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuTlmInsertAfterTcpMessageList].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuTlmAppendTcpMessages].SharedProps.Visible = fObject.canAppendChild;
                }
                else if (fObject.fObjectType == FObjectType.TcpMessages)
                {
                    mnuMenu.Tools[FMenuKey.MenuTlmInsertBeforeTcpMessages].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuTlmInsertAfterTcpMessages].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuTlmAppendPrimaryTcpMessage].SharedProps.Visible = ((FTcpMessages)fObject).canAppendChildPrimaryTcpMessage;                    
                    if (((FTcpMessages)fObject).canAppendChildSecondaryTcpMessage)
                    {
                        mnuMenu.Tools[FMenuKey.MenuTlmAppendSecondaryTcpMessage].SharedProps.Visible = true;
                        // --
                        mnuMenu.Toolbars[0].Tools[FMenuKey.MenuTlmAppendSecondaryTcpMessage].InstanceProps.IsFirstInGroup = !((FTcpMessages)fObject).canAppendChildPrimaryTcpMessage;
                        ((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuTlmPopupMenu]).Tools[FMenuKey.MenuTlmAppendSecondaryTcpMessage].InstanceProps.IsFirstInGroup = !((FTcpMessages)fObject).canAppendChildPrimaryTcpMessage;
                    }
                    // --
                    mnuMenu.Tools[FMenuKey.MenuTlmConvertToXlg].SharedProps.Enabled = true;
                }
                else if (fObject.fObjectType == FObjectType.TcpMessage)
                {
                    mnuMenu.Tools[FMenuKey.MenuTlmAppendTcpItem].SharedProps.Visible = fObject.canAppendChild;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuTlmConvertToXlg].SharedProps.Enabled = true;
                }
                else if (fObject.fObjectType == FObjectType.TcpItem)
                {
                    mnuMenu.Tools[FMenuKey.MenuTlmInsertBeforeTcpItem].SharedProps.Visible = fObject.canInsertAfter;
                    mnuMenu.Tools[FMenuKey.MenuTlmInsertAfterTcpItem].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuTlmAppendTcpItem].SharedProps.Visible = fObject.canAppendChild;
                }

                if (
                    fObject.fObjectType == FObjectType.TcpLibraryGroup ||
                    fObject.fObjectType == FObjectType.TcpLibrary ||
                    fObject.fObjectType == FObjectType.TcpMessageList ||
                    fObject.fObjectType == FObjectType.TcpMessages ||
                    fObject.fObjectType == FObjectType.TcpMessage ||
                    fObject.fObjectType == FObjectType.TcpItem
                    )
                {
                    mnuMenu.Tools[FMenuKey.MenuTlmPasteSibling].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuTlmPasteChild].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuTlmPastePrimaryTcpMessage].SharedProps.Visible = false;
                    mnuMenu.Tools[FMenuKey.MenuTlmPasteSecondaryTcpMessage].SharedProps.Visible = false;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuTlmRemove].SharedProps.Enabled = fObject.canRemove;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuTlmMoveUp].SharedProps.Enabled = fObject.canMoveUp;
                    mnuMenu.Tools[FMenuKey.MenuTlmMoveDown].SharedProps.Enabled = fObject.canMoveDown;
                    // -- 
                    mnuMenu.Tools[FMenuKey.MenuTlmCut].SharedProps.Enabled = fObject.canCut;
                    mnuMenu.Tools[FMenuKey.MenuTlmCopy].SharedProps.Enabled = fObject.canCopy;
                    mnuMenu.Tools[FMenuKey.MenuTlmPasteSibling].SharedProps.Enabled = fObject.canPasteSibling;
                    mnuMenu.Tools[FMenuKey.MenuTlmPasteChild].SharedProps.Enabled = fObject.canPasteChild;
                }

                if (fObject.fObjectType == FObjectType.TcpMessages)
                {

                    if (
                        ((FTcpMessages)fObject).canPastePrimaryTcpMessage ||
                        ((FTcpMessages)fObject).canPasteSecondaryTcpMessage
                        )
                    {
                        mnuMenu.Tools[FMenuKey.MenuTlmPasteSibling].SharedProps.Visible = false;
                        mnuMenu.Tools[FMenuKey.MenuTlmPasteChild].SharedProps.Visible = false;
                        mnuMenu.Tools[FMenuKey.MenuTlmPastePrimaryTcpMessage].SharedProps.Visible = true;
                        mnuMenu.Tools[FMenuKey.MenuTlmPasteSecondaryTcpMessage].SharedProps.Visible = true;
                    }
                    // --
                    mnuMenu.Tools[FMenuKey.MenuTlmPastePrimaryTcpMessage].SharedProps.Enabled = ((FTcpMessages)fObject).canPastePrimaryTcpMessage;
                    mnuMenu.Tools[FMenuKey.MenuTlmPasteSecondaryTcpMessage].SharedProps.Enabled = ((FTcpMessages)fObject).canPasteSecondaryTcpMessage; 
                }

                // --

                // ***
                // 2016.04.26 by spike.lee
                // Replace Menu 제어
                // ***
                if (
                    fObject.fObjectType == FObjectType.TcpMessages ||
                    fObject.fObjectType == FObjectType.TcpMessage ||
                    fObject.fObjectType == FObjectType.TcpItem
                    )
                {
                    mnuMenu.Tools[FMenuKey.MenuTlmReplace].SharedProps.Enabled = true;
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
            FTcpDriver fTcd = null;
            UltraTreeNode tNodeTcd = null;
            UltraTreeNode tNodeTlg = null;
            UltraTreeNode tNodeTlb = null;
            UltraTreeNode tNodeTml = null;
            UltraTreeNode tNodeTms = null;
            UltraTreeNode tNodeTmg = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                // ***
                // TCP Driver Load
                // ***
                fTcd = m_fTcmCore.fTcmFileInfo.fTcpDriver;
                tNodeTcd = new UltraTreeNode(fTcd.uniqueIdToString);
                tNodeTcd.Tag = fTcd;
                FCommon.refreshTreeNodeOfObject(fTcd, tvwTree, tNodeTcd);

                // --

                // ***
                // TCP Library Group Load
                // ***
                foreach (FTcpLibraryGroup fTlg in fTcd.fChildTcpLibraryGroupCollection)
                {
                    tNodeTlg = new UltraTreeNode(fTlg.uniqueIdToString);
                    tNodeTlg.Tag = fTlg;
                    FCommon.refreshTreeNodeOfObject(fTlg, tvwTree, tNodeTlg);

                    // --

                    // ***
                    // TCP Library Load
                    // ***
                    foreach (FTcpLibrary fTlb in fTlg.fChildTcpLibraryCollection)
                    {
                        tNodeTlb = new UltraTreeNode(fTlb.uniqueIdToString);
                        tNodeTlb.Tag = fTlb;
                        FCommon.refreshTreeNodeOfObject(fTlb, tvwTree, tNodeTlb);

                        // --

                        // ***
                        // TCP Message List Load
                        // ***
                        foreach (FTcpMessageList fTml in fTlb.fChildTcpMessageListCollection)
                        {
                            tNodeTml = new UltraTreeNode(fTml.uniqueIdToString);
                            tNodeTml.Tag = fTml;
                            FCommon.refreshTreeNodeOfObject(fTml, tvwTree, tNodeTml);

                            // --

                            // ***
                            // TCP Messages Load
                            // ***
                            foreach (FTcpMessages fTms in fTml.fChildTcpMessagesCollection)
                            {
                                tNodeTms = new UltraTreeNode(fTms.uniqueIdToString);
                                tNodeTms.Tag = fTms;
                                FCommon.refreshTreeNodeOfObject(fTms, tvwTree, tNodeTms);

                                // --

                                // ***
                                // TCP Message Load
                                // ***
                                foreach (FTcpMessage fTmg in fTms.fChildTcpMessageCollection)
                                {
                                    tNodeTmg = new UltraTreeNode(fTmg.uniqueIdToString);
                                    tNodeTmg.Tag = fTmg;
                                    FCommon.refreshTreeNodeOfObject(fTmg, tvwTree, tNodeTmg);
                                    // --
                                    tNodeTmg.Expanded = false;
                                    tNodeTms.Nodes.Add(tNodeTmg);
                                }

                                // --

                                tNodeTms.Expanded = false;
                                tNodeTml.Nodes.Add(tNodeTms);
                            }

                            // --

                            tNodeTml.Expanded = true;
                            tNodeTlb.Nodes.Add(tNodeTml);
                        }

                        tNodeTlb.Expanded = true;
                        tNodeTlg.Nodes.Add(tNodeTlb);
                    }

                    // --

                    tNodeTlg.Expanded = true;
                    tNodeTcd.Nodes.Add(tNodeTlg);
                }

                // --

                tNodeTcd.Expanded = true;
                tvwTree.Nodes.Add(tNodeTcd);
                tvwTree.ActiveNode = tNodeTcd;

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
                fTcd = null;
                tNodeTcd = null;
                tNodeTlg = null;
                tNodeTlb = null;
                tNodeTml = null;
                tNodeTmg = null;
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
                if (fParent.fObjectType == FObjectType.TcpDriver)
                {
                    foreach (FTcpLibraryGroup fTlg in ((FTcpDriver)fParent).fChildTcpLibraryGroupCollection)
                    {
                        tNodeChild = new UltraTreeNode(fTlg.uniqueIdToString);
                        tNodeChild.Tag = fTlg;
                        FCommon.refreshTreeNodeOfObject(fTlg, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.TcpLibraryGroup)
                {
                    foreach (FTcpLibrary fTlb in ((FTcpLibraryGroup)fParent).fChildTcpLibraryCollection)
                    {
                        tNodeChild = new UltraTreeNode(fTlb.uniqueIdToString);
                        tNodeChild.Tag = fTlb;
                        FCommon.refreshTreeNodeOfObject(fTlb, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.TcpLibrary)
                {
                    foreach (FTcpMessageList fTml in ((FTcpLibrary)fParent).fChildTcpMessageListCollection)
                    {
                        tNodeChild = new UltraTreeNode(fTml.uniqueIdToString);
                        tNodeChild.Tag = fTml;
                        FCommon.refreshTreeNodeOfObject(fTml, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.TcpMessageList)
                {
                    foreach (FTcpMessages fTms in ((FTcpMessageList)fParent).fChildTcpMessagesCollection)
                    {
                        tNodeChild = new UltraTreeNode(fTms.uniqueIdToString);
                        tNodeChild.Tag = fTms;
                        FCommon.refreshTreeNodeOfObject(fTms, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.TcpMessages)
                {
                    foreach (FTcpMessage fTmg in ((FTcpMessages)fParent).fChildTcpMessageCollection)
                    {
                        tNodeChild = new UltraTreeNode(fTmg.uniqueIdToString);
                        tNodeChild.Tag = fTmg;
                        FCommon.refreshTreeNodeOfObject(fTmg, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.TcpMessage)
                {
                    foreach (FTcpItem fTit in ((FTcpMessage)fParent).fChildTcpItemCollection)
                    {
                        tNodeChild = new UltraTreeNode(fTit.uniqueIdToString);
                        tNodeChild.Tag = fTit;
                        FCommon.refreshTreeNodeOfObject(fTit, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.TcpItem)
                {
                    foreach (FTcpItem fTit in ((FTcpItem)fParent).fChildTcpItemCollection)
                    {
                        tNodeChild = new UltraTreeNode(fTit.uniqueIdToString);
                        tNodeChild.Tag = fTit;
                        FCommon.refreshTreeNodeOfObject(fTit, tvwTree, tNodeChild);
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

                if (fNewChild.fObjectType == FObjectType.TcpLibraryGroup)
                {
                    tNodeParent = tvwTree.GetNodeByKey(fParent.uniqueIdToString);                   
                    fRefChild = ((FTcpLibraryGroup)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.TcpLibrary)
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
                    fRefChild = ((FTcpLibrary)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.TcpMessageList)
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
                    fRefChild = ((FTcpMessageList)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.TcpMessages)
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
                    fRefChild = ((FTcpMessages)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.TcpMessage)
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
                    fRefChild = ((FTcpMessage)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.TcpItem)
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
                    fRefChild = ((FTcpItem)fNewChild).fNextSibling;
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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

                if (fObject.fObjectType == FObjectType.TcpLibraryGroup)
                {
                    if (((FTcpLibraryGroup)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FTcpLibraryGroup)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.TcpLibrary)
                {
                    if (((FTcpLibrary)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FTcpLibrary)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.TcpMessageList)
                {
                    if (((FTcpMessageList)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FTcpMessageList)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.TcpMessages)
                {
                    if (((FTcpMessages)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FTcpMessages)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.TcpMessage)
                {
                    if (((FTcpMessage)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FTcpMessage)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.TcpItem)
                {
                    if (((FTcpItem)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FTcpItem)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
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

                if (fObject.fObjectType == FObjectType.TcpLibraryGroup)
                {
                    if (((FTcpLibraryGroup)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FTcpLibraryGroup)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.TcpLibrary)
                {
                    if (((FTcpLibrary)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FTcpLibrary)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.TcpMessageList)
                {
                    if (((FTcpMessageList)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FTcpMessageList)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.TcpMessages)
                {
                    if (((FTcpMessages)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FTcpMessages)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.TcpMessage)
                {
                    if (((FTcpMessage)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FTcpMessage)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.TcpItem)
                {
                    if (((FTcpItem)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FTcpItem)fObject).fNextSibling == (FIObject)tNextNode.Tag)
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

                if (fParent.fObjectType == FObjectType.TcpDriver)
                {
                    fNewChild = ((FTcpDriver)fParent).appendChildTcpLibraryGroup(new FTcpLibraryGroup(this.m_fTcmCore.fTcmFileInfo.fTcpDriver));
                }
                else if (fParent.fObjectType == FObjectType.TcpLibraryGroup)
                {
                    fNewChild = ((FTcpLibraryGroup)fParent).appendChildTcpLibrary(new FTcpLibrary(this.m_fTcmCore.fTcmFileInfo.fTcpDriver));
                }
                else if (fParent.fObjectType == FObjectType.TcpLibrary)
                {
                    fNewChild = ((FTcpLibrary)fParent).appendChildTcpMessageList(new FTcpMessageList(this.m_fTcmCore.fTcmFileInfo.fTcpDriver));
                }
                else if (fParent.fObjectType == FObjectType.TcpMessageList)
                {
                    fNewChild = ((FTcpMessageList)fParent).appendChildTcpMessages(new FTcpMessages(this.m_fTcmCore.fTcmFileInfo.fTcpDriver));
                }
                else if (fParent.fObjectType == FObjectType.TcpMessages)
                {
                    if (menuKey == FMenuKey.MenuTlmAppendPrimaryTcpMessage)
                    {
                        fNewChild = ((FTcpMessages)fParent).appendChildPrimaryTcpMessage(new FTcpMessage(this.m_fTcmCore.fTcmFileInfo.fTcpDriver));
                    }
                    else
                    {
                        fNewChild = ((FTcpMessages)fParent).appendChildSecondaryTcpMessage(new FTcpMessage(this.m_fTcmCore.fTcmFileInfo.fTcpDriver));
                    }
                }
                else if (fParent.fObjectType == FObjectType.TcpMessage)
                {
                    fNewChild = ((FTcpMessage)fParent).appendChildTcpItem(new FTcpItem(this.m_fTcmCore.fTcmFileInfo.fTcpDriver));
                }
                else if (fParent.fObjectType == FObjectType.TcpItem)
                {
                    fNewChild = new FTcpItem(this.m_fTcmCore.fTcmFileInfo.fTcpDriver);
                    if (((FTcpItem)fParent).fFormat == FFormat.AsciiList)
                    {
                        ((FTcpItem)fNewChild).fFormat = FFormat.Ascii;
                    }
                    fNewChild = ((FTcpItem)fParent).appendChildTcpItem((FTcpItem)fNewChild);
                }

                // --

                tNodeNewChild = new UltraTreeNode(fNewChild.uniqueIdToString);
                tNodeNewChild.Tag = fNewChild;
                FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNodeNewChild);
                // --
                if (fParent.fObjectType == FObjectType.TcpMessages)
                {
                    if (((FTcpMessage)fNewChild).isPrimary)
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

                if (fParent.fObjectType == FObjectType.TcpDriver)
                {
                    fNewChild = ((FTcpDriver)fParent).insertBeforeChildTcpLibraryGroup(
                        new FTcpLibraryGroup(this.m_fTcmCore.fTcmFileInfo.fTcpDriver),
                        (FTcpLibraryGroup)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.TcpLibraryGroup)
                {
                    fNewChild = ((FTcpLibraryGroup)fParent).insertBeforeChildTcpLibrary(
                        new FTcpLibrary(this.m_fTcmCore.fTcmFileInfo.fTcpDriver),
                        (FTcpLibrary)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.TcpLibrary)
                {
                    fNewChild = ((FTcpLibrary)fParent).insertBeforeChildTcpMessageList(
                        new FTcpMessageList(this.m_fTcmCore.fTcmFileInfo.fTcpDriver),
                        (FTcpMessageList)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.TcpMessageList)
                {
                    fNewChild = ((FTcpMessageList)fParent).insertBeforeChildTcpMessages(
                        new FTcpMessages(this.m_fTcmCore.fTcmFileInfo.fTcpDriver),
                        (FTcpMessages)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.TcpMessages)
                {
                    // ***
                    // 사용안함.
                    // ***
                }
                else if (fParent.fObjectType == FObjectType.TcpMessage)
                {
                    fNewChild = ((FTcpMessage)fParent).insertBeforeChildTcpItem(
                        new FTcpItem(this.m_fTcmCore.fTcmFileInfo.fTcpDriver),
                        (FTcpItem)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.TcpItem)
                {
                    fNewChild = new FTcpItem(this.m_fTcmCore.fTcmFileInfo.fTcpDriver);
                    if (((FTcpItem)fParent).fFormat == FFormat.AsciiList)
                    {
                        ((FTcpItem)fNewChild).fFormat = FFormat.Ascii;
                    }
                    fNewChild = ((FTcpItem)fParent).insertBeforeChildTcpItem((FTcpItem)fNewChild, (FTcpItem)fRefChild);
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

                if (fParent.fObjectType == FObjectType.TcpDriver)
                {
                    fNewChild = ((FTcpDriver)fParent).insertAfterChildTcpLibraryGroup(
                        new FTcpLibraryGroup(this.m_fTcmCore.fTcmFileInfo.fTcpDriver),
                        (FTcpLibraryGroup)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.TcpLibraryGroup)
                {
                    fNewChild = ((FTcpLibraryGroup)fParent).insertAfterChildTcpLibrary(
                        new FTcpLibrary(this.m_fTcmCore.fTcmFileInfo.fTcpDriver),
                        (FTcpLibrary)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.TcpLibrary)
                {
                    fNewChild = ((FTcpLibrary)fParent).insertAfterChildTcpMessageList(
                        new FTcpMessageList(this.m_fTcmCore.fTcmFileInfo.fTcpDriver),
                        (FTcpMessageList)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.TcpMessageList)
                {
                    fNewChild = ((FTcpMessageList)fParent).insertAfterChildTcpMessages(
                        new FTcpMessages(this.m_fTcmCore.fTcmFileInfo.fTcpDriver),
                        (FTcpMessages)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.TcpMessages)
                {
                    // ***
                    // 사용안함.
                    // ***
                }
                else if (fParent.fObjectType == FObjectType.TcpMessage)
                {
                    fNewChild = ((FTcpMessage)fParent).insertAfterChildTcpItem(
                        new FTcpItem(this.m_fTcmCore.fTcmFileInfo.fTcpDriver),
                        (FTcpItem)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.TcpItem)
                {
                    fNewChild = new FTcpItem(this.m_fTcmCore.fTcmFileInfo.fTcpDriver);
                    if (((FTcpItem)fParent).fFormat == FFormat.AsciiList)
                    {
                        ((FTcpItem)fNewChild).fFormat = FFormat.Ascii;
                    }
                    fNewChild = ((FTcpItem)fParent).insertAfterChildTcpItem((FTcpItem)fNewChild, (FTcpItem)fRefChild);
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
                // Removing TCP Object Validate
                // ***
                if (fParent.fObjectType == FObjectType.TcpDriver)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FTcpLibraryGroup)fChild).locked)
                        {
                            FDebug.throwFException(m_fTcmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.TcpLibraryGroup)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FTcpLibrary)fChild).locked)
                        {
                            FDebug.throwFException(m_fTcmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.TcpLibrary)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FTcpMessageList)fChild).locked)
                        {
                            FDebug.throwFException(m_fTcmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.TcpMessageList)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FTcpMessages)fChild).locked)
                        {
                            FDebug.throwFException(m_fTcmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.TcpMessages)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FTcpMessage)fChild).locked)
                        {
                            FDebug.throwFException(m_fTcmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.TcpMessage)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FTcpItem)fChild).locked)
                        {
                            FDebug.throwFException(m_fTcmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.TcpItem)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FTcpItem)fChild).locked)
                        {
                            FDebug.throwFException(m_fTcmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }

                // --

                // ***
                // Remove TCP Object가 1개 이상일 경우 사용자에게 Confirm를 받는다.
                // ***
                if (tvwTree.SelectedNodes.Count > 1)
                {
                    dialogResult = FMessageBox.showQuestion(
                        FConstants.ApplicationName,
                        m_fTcmCore.fWsmCore.fUIWizard.generateMessage("Q0004", new object[] { "Object" }),
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button2,
                        m_fTcmCore.fWsmCore.fWsmContainer
                        );
                    if (dialogResult == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                }

                // --

                // ***
                // TCP Object Remove
                // ***
                if (fParent.fObjectType == FObjectType.TcpDriver)
                {
                    fChilds = new FTcpLibraryGroup[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FTcpLibraryGroup)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FTcpDriver)fParent).removeChildTcpLibraryGroup((FTcpLibraryGroup[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.TcpLibraryGroup)
                {
                    fChilds = new FTcpLibrary[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FTcpLibrary)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FTcpLibraryGroup)fParent).removeChildTcpLibrary((FTcpLibrary[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.TcpLibrary)
                {
                    fChilds = new FTcpMessageList[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FTcpMessageList)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FTcpLibrary)fParent).removeChildTcpMessageList((FTcpMessageList[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.TcpMessageList)
                {
                    fChilds = new FTcpMessages[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FTcpMessages)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FTcpMessageList)fParent).removeChildTcpMessages((FTcpMessages[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.TcpMessages)
                {
                    fChilds = new FTcpMessage[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FTcpMessage)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FTcpMessages)fParent).removeChildTcpMessage((FTcpMessage[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.TcpMessage)
                {
                    fChilds = new FTcpItem[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FTcpItem)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FTcpMessage)fParent).removeChildTcpItem((FTcpItem[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.TcpItem)
                {
                    fChilds = new FTcpItem[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FTcpItem)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FTcpItem)fParent).removeChildTcpItem((FTcpItem[])fChilds);
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

                if (fObject.fObjectType == FObjectType.TcpLibraryGroup)
                {
                    ((FTcpLibraryGroup)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.TcpLibrary)
                {
                    ((FTcpLibrary)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.TcpMessageList)
                {
                    ((FTcpMessageList)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.TcpMessages)
                {
                    ((FTcpMessages)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.TcpMessage)
                {
                    // --
                }
                else if (fObject.fObjectType == FObjectType.TcpItem)
                {
                    ((FTcpItem)fObject).moveUp();
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

                if (fObject.fObjectType == FObjectType.TcpLibraryGroup)
                {
                    ((FTcpLibraryGroup)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.TcpLibrary)
                {
                    ((FTcpLibrary)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.TcpMessageList)
                {
                    ((FTcpMessageList)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.TcpMessages)
                {
                    ((FTcpMessages)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.TcpMessage)
                {
                    // --
                }
                else if (fObject.fObjectType == FObjectType.TcpItem)
                {
                    ((FTcpItem)fObject).moveDown();
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

                m_fTcmCore.fTcmContainer.showRelationViewer((FIObject)tvwTree.ActiveNode.Tag);
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

        private void procMenuXlgViewer(
            )
        {
            FTcpProtocolSelector fProtocolSelector = null;
            FXlgViewer fXlgViewer = null;
            FIObject fObject = null;
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
                    fObject = (FIObject)node.Tag;
                    // --
                    if (fObject.fObjectType == FObjectType.TcpMessage)
                    {
                        sb.Append(((FTcpMessage)fObject).convertToXml(fProtocolSelector.fSelectedProtocol));
                    }
                    else if (fObject.fObjectType == FObjectType.TcpMessages)
                    {
                        sb.Append(((FTcpMessages)fObject).convertToXml(fProtocolSelector.fSelectedProtocol));
                    }
                }
                // --
                fXlgViewer.appendXlg(sb.ToString());
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fProtocolSelector = null;
                fXlgViewer = null;
                fObject = null;
                sb = null;
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

                if (fObject.fObjectType == FObjectType.TcpDriver)
                {
                    tvwTree.ActiveNode.Expanded = true;
                    // --
                    foreach (UltraTreeNode tNodeTlg in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeTlg.Expanded = true;
                        // -- 
                        foreach (UltraTreeNode tNodeTlb in tNodeTlg.Nodes)
                        {
                            tNodeTlb.Expanded = true;
                            // --
                            foreach (UltraTreeNode tNodeTml in tNodeTlb.Nodes)
                            {
                                tNodeTml.Expanded = true;
                                // --
                                foreach (UltraTreeNode tNodeTms in tNodeTml.Nodes)
                                {
                                    tNodeTms.Expanded = true;
                                }
                            }
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.TcpLibraryGroup)
                {
                    tvwTree.ActiveNode.Expanded = true;
                    // --
                    foreach (UltraTreeNode tNodeTlb in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeTlb.Expanded = true;
                        // --
                        foreach (UltraTreeNode tNodeTml in tNodeTlb.Nodes)
                        {
                            tNodeTml.Expanded = true;
                            // --
                            foreach (UltraTreeNode tNodeTms in tNodeTml.Nodes)
                            {
                                tNodeTms.Expanded = true;
                            }
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.TcpLibrary)
                {
                    tvwTree.ActiveNode.Expanded = true;
                    // --
                    foreach (UltraTreeNode tNodeTml in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeTml.Expanded = true;
                        // --
                        foreach (UltraTreeNode tNodeTms in tNodeTml.Nodes)
                        {
                            tNodeTms.Expanded = true;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.TcpMessageList)
                {
                    tvwTree.ActiveNode.Expanded = true;
                    // --
                    foreach (UltraTreeNode tNodeTms in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeTms.Expanded = true;
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

                if (fObject.fObjectType == FObjectType.TcpDriver)
                {
                    foreach (UltraTreeNode tNodeTlg in tvwTree.ActiveNode.Nodes)
                    {
                        foreach (UltraTreeNode tNodeTlb in tNodeTlg.Nodes)
                        {
                            foreach (UltraTreeNode tNodeTml in tNodeTlb.Nodes)
                            {
                                foreach (UltraTreeNode tNodeTms in tNodeTml.Nodes)
                                {
                                    tNodeTms.Expanded = false;
                                }
                                // --
                                tNodeTml.Expanded = false;
                            }
                            // --
                            tNodeTlb.Expanded = false;
                        }
                        // --
                        tNodeTlg.Expanded = false;
                    }
                    // --
                    tvwTree.ActiveNode.Expanded = false;
                }
                else if (fObject.fObjectType == FObjectType.TcpLibraryGroup)
                {
                    foreach (UltraTreeNode tNodeTlb in tvwTree.ActiveNode.Nodes)
                    {
                        foreach (UltraTreeNode tNodeTml in tNodeTlb.Nodes)
                        {
                            foreach (UltraTreeNode tNodeTms in tNodeTml.Nodes)
                            {
                                tNodeTms.Expanded = false;
                            }
                            // --
                            tNodeTml.Expanded = false;
                        }
                        // --
                        tNodeTlb.Expanded = false;
                    }
                    // --
                    tvwTree.ActiveNode.Expanded = false;
                }
                else if (fObject.fObjectType == FObjectType.TcpLibrary)
                {
                    foreach (UltraTreeNode tNodeTml in tvwTree.ActiveNode.Nodes)
                    {
                        foreach (UltraTreeNode tNodeTms in tNodeTml.Nodes)
                        {
                            tNodeTms.Expanded = false;
                        }
                        // --
                        tNodeTml.Expanded = false;
                    }
                    // --
                    tvwTree.ActiveNode.Expanded = false;
                }
                else if (fObject.fObjectType == FObjectType.TcpMessageList)
                {
                    foreach (UltraTreeNode tNodeTms in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeTms.Expanded = false;
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

        private void procMenuReplace(
            )
        {
            FReplaceNameDialog dialog = null;
            FIObject fObject = null;
            string findWhat = string.Empty;

            try
            {
                fObject = (FIObject)tvwTree.ActiveNode.Tag;
                if (fObject.fObjectType == FObjectType.TcpMessages)
                {
                    findWhat = ((FTcpMessages)fObject).name;
                }
                else if (fObject.fObjectType == FObjectType.TcpMessage)
                {
                    findWhat = ((FTcpMessage)fObject).name;
                }
                else if (fObject.fObjectType == FObjectType.TcpItem)
                {
                    findWhat = ((FTcpItem)fObject).name;
                }
                else
                {
                    return;
                }

                // --

                dialog = new FReplaceNameDialog(
                    m_fTcmCore,
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
                if (fObject.fObjectType == FObjectType.TcpMessages)
                {
                    foreach (FIObject o in ((FTcpMessages)fObject).fChildTcpMessageCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FTcpMessages)fObject).name = ((FTcpMessages)fObject).name.Replace(findWhat, replaceWith);
                    ((FTcpMessages)fObject).command = ((FTcpMessages)fObject).command.Replace(findWhat, replaceWith);
                    ((FTcpMessages)fObject).description = ((FTcpMessages)fObject).description.Replace(findWhat, replaceWith);
                }
                else if (fObject.fObjectType == FObjectType.TcpMessage)
                {
                    foreach (FIObject o in ((FTcpMessage)fObject).fChildTcpItemCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FTcpMessage)fObject).name = ((FTcpMessage)fObject).name.Replace(findWhat, replaceWith);
                    ((FTcpMessage)fObject).command = ((FTcpMessage)fObject).command.Replace(findWhat, replaceWith);
                    ((FTcpMessage)fObject).description = ((FTcpMessage)fObject).description.Replace(findWhat, replaceWith);
                }
                else if (fObject.fObjectType == FObjectType.TcpItem)
                {
                    foreach (FIObject o in ((FTcpItem)fObject).fChildTcpItemCollection)
                    {
                        procMenuReplaceObject(o, findWhat, replaceWith);
                    }
                    // --
                    ((FTcpItem)fObject).name = ((FTcpItem)fObject).name.Replace(findWhat, replaceWith);
                    ((FTcpItem)fObject).description = ((FTcpItem)fObject).description.Replace(findWhat, replaceWith);
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

                if (fObject.fObjectType == FObjectType.TcpLibraryGroup)
                {
                    ((FTcpLibraryGroup)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.TcpLibrary)
                {
                    ((FTcpLibrary)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.TcpMessageList)
                {
                    ((FTcpMessageList)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.TcpMessages)
                {
                    ((FTcpMessages)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.TcpMessage)
                {
                    ((FTcpMessage)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.TcpItem)
                {
                    ((FTcpItem)fObject).cut();
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

                if (fObject.fObjectType == FObjectType.TcpLibraryGroup)
                {
                    ((FTcpLibraryGroup)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.TcpLibrary)
                {
                    ((FTcpLibrary)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.TcpMessageList)
                {
                    ((FTcpMessageList)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.TcpMessages)
                {
                    ((FTcpMessages)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.TcpMessage)
                {
                    ((FTcpMessage)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.TcpItem)
                {
                    ((FTcpItem)fObject).copy();
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

            try
            {
                tNodeRef = tvwTree.ActiveNode;
                fRefObject = (FIObject)tNodeRef.Tag;

                // --

                tvwTree.beginUpdate();
                // --
                if (fRefObject.fObjectType == FObjectType.TcpLibraryGroup)
                {
                    fNewObject = ((FTcpLibraryGroup)fRefObject).pasteSibling();
                }
                else if (fRefObject.fObjectType == FObjectType.TcpLibrary)
                {
                    fNewObject = ((FTcpLibrary)fRefObject).pasteSibling();
                }
                else if (fRefObject.fObjectType == FObjectType.TcpMessageList)
                {
                    fNewObject = ((FTcpMessageList)fRefObject).pasteSibling();
                }
                else if (fRefObject.fObjectType == FObjectType.TcpMessages)
                {
                    fNewObject = ((FTcpMessages)fRefObject).pasteSibling();
                }
                else if (fRefObject.fObjectType == FObjectType.TcpMessage)
                {
                    // ***
                    // 사용하지 않음
                    // ***
                }
                else if (fRefObject.fObjectType == FObjectType.TcpItem)
                {
                    fNewObject = ((FTcpItem)fRefObject).pasteSibling();
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

                if (fParent.fObjectType == FObjectType.TcpDriver)
                {
                    fChild = ((FTcpDriver)fParent).pasteChildTcpLibraryGroup();
                }
                else if (fParent.fObjectType == FObjectType.TcpLibraryGroup)
                {
                    fChild = ((FTcpLibraryGroup)fParent).pasteChild();
                }
                else if (fParent.fObjectType == FObjectType.TcpLibrary)
                {
                    fChild = ((FTcpLibrary)fParent).pasteChild();
                }
                else if (fParent.fObjectType == FObjectType.TcpMessageList)
                {
                    fChild = ((FTcpMessageList)fParent).pasteChild();
                }
                else if (fParent.fObjectType == FObjectType.TcpMessages)
                {
                    // ***
                    // 사용하지 않음
                    // ***
                }
                else if (fParent.fObjectType == FObjectType.TcpMessage)
                {
                    fChild = ((FTcpMessage)fParent).pasteChild();
                }
                else if (fParent.fObjectType == FObjectType.TcpItem)
                {
                    fChild = ((FTcpItem)fParent).pasteChild();
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

        private void procMenuPastePrimaryTcpMessage(
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

                if (fParent.fObjectType == FObjectType.TcpMessages)
                {
                    fChild = ((FTcpMessages)fParent).pastePrimaryTcpMessage();
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

        private void procMenuPasteSecondaryTcpMessage(
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

                if (fParent.fObjectType == FObjectType.TcpMessages)
                {
                    fChild = ((FTcpMessages)fParent).pasteSecondaryTcpMessage();
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

                fResult = m_fTcmCore.fTcmFileInfo.fTcpDriver.searchTcpLibrarySeries(fBase, searchWord);
                if (fResult == null)
                {
                    FMessageBox.showInformation("Search", m_fTcmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { searchWord }), this);
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
                if (fObject.fObjectType == FObjectType.TcpDriver)
                {
                    return;
                }
                
                // --

                fParent = m_fTcmCore.fTcmFileInfo.fTcpDriver.getParentOfObject(fObject);

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

        #region FTcpLibraryModeler Form Event Handler

        private void FTcpLibraryModeler_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designTreeOfTcpLibraryModeler();

                // --

                tvwTree.setPopupMenu((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuTlmPopupMenu]);

                // --

                m_fEventHandler = new FEventHandler(m_fTcmCore.fTcmFileInfo.fTcpDriver, tvwTree);
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

        private void FTcpLibraryModeler_Shown(
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FTcpLibraryModeler_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                if (m_fEventHandler != null)
                {
                    m_fTcmCore.fTcmFileInfo.fTcpDriver.waitEventHandlingCompleted();

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

        #region m_fEventHandler Object Event Handler

        private void m_fEventHandler_ObjectInsertBeforeCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.TcpLibraryGroup ||
                    e.fObject.fObjectType == FObjectType.TcpLibrary ||
                    e.fObject.fObjectType == FObjectType.TcpMessageList ||
                    e.fObject.fObjectType == FObjectType.TcpMessages ||
                    e.fObject.fObjectType == FObjectType.TcpMessage ||
                    e.fObject.fObjectType == FObjectType.TcpItem
                    )
                {
                    addTreeOfObject(e.fParentObject, e.fObject);
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

        private void m_fEventHandler_ObjectInsertAfterCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.TcpLibraryGroup ||
                    e.fObject.fObjectType == FObjectType.TcpLibrary ||
                    e.fObject.fObjectType == FObjectType.TcpMessageList ||
                    e.fObject.fObjectType == FObjectType.TcpMessages ||
                    e.fObject.fObjectType == FObjectType.TcpMessage ||
                    e.fObject.fObjectType == FObjectType.TcpItem
                    )
                {
                    addTreeOfObject(e.fParentObject, e.fObject);
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

        private void m_fEventHandler_ObjectAppendCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.TcpLibraryGroup ||
                    e.fObject.fObjectType == FObjectType.TcpLibrary ||
                    e.fObject.fObjectType == FObjectType.TcpMessageList ||
                    e.fObject.fObjectType == FObjectType.TcpMessages ||
                    e.fObject.fObjectType == FObjectType.TcpMessage ||
                    e.fObject.fObjectType == FObjectType.TcpItem
                    )
                {
                    addTreeOfObject(e.fParentObject, e.fObject);
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

        private void m_fEventHandler_ObjectRemoveCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.TcpLibraryGroup ||
                    e.fObject.fObjectType == FObjectType.TcpLibrary ||
                    e.fObject.fObjectType == FObjectType.TcpMessageList ||
                    e.fObject.fObjectType == FObjectType.TcpMessages ||
                    e.fObject.fObjectType == FObjectType.TcpMessage ||
                    e.fObject.fObjectType == FObjectType.TcpItem
                    )
                {
                    removeTreeOfObject(e.fObject);
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

        private void m_fEventHandler_ObjectMoveUpCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.TcpLibraryGroup ||
                    e.fObject.fObjectType == FObjectType.TcpLibrary ||
                    e.fObject.fObjectType == FObjectType.TcpMessageList ||
                    e.fObject.fObjectType == FObjectType.TcpMessages ||
                    e.fObject.fObjectType == FObjectType.TcpMessage ||
                    e.fObject.fObjectType == FObjectType.TcpItem
                    )
                {
                    moveUpTreeOfObject(e.fObject);
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

        private void m_fEventHandler_ObjectMoveDownCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.TcpLibraryGroup ||
                    e.fObject.fObjectType == FObjectType.TcpLibrary ||
                    e.fObject.fObjectType == FObjectType.TcpMessageList ||
                    e.fObject.fObjectType == FObjectType.TcpMessages ||
                    e.fObject.fObjectType == FObjectType.TcpMessage ||
                    e.fObject.fObjectType == FObjectType.TcpItem
                    )
                {
                    moveDownTreeOfObject(e.fObject);
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

        private void m_fEventHandler_ObjectMoveToCompleted(
            object sender,
            FObjectMoveToCompletedEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.TcpLibraryGroup ||
                    e.fObject.fObjectType == FObjectType.TcpLibrary ||
                    e.fObject.fObjectType == FObjectType.TcpMessageList ||
                    e.fObject.fObjectType == FObjectType.TcpMessages ||
                    e.fObject.fObjectType == FObjectType.TcpMessage ||
                    e.fObject.fObjectType == FObjectType.TcpItem
                    )
                {
                    moveToTreeOfObject(e.fObject, e.fRefObject);
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

        private void m_fEventHandler_ObjectModifyCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.TcpDriver ||
                    e.fObject.fObjectType == FObjectType.TcpLibraryGroup ||
                    e.fObject.fObjectType == FObjectType.TcpLibrary ||
                    e.fObject.fObjectType == FObjectType.TcpMessageList ||
                    e.fObject.fObjectType == FObjectType.TcpMessages ||
                    e.fObject.fObjectType == FObjectType.TcpMessage ||
                    e.fObject.fObjectType == FObjectType.TcpItem
                    )
                {
                    refreshObject(e.fObject);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                if (fObject.fObjectType == FObjectType.TcpDriver)
                {
                    pgdProp.selectedObject = new FPropTcd(m_fTcmCore, pgdProp, (FTcpDriver)fObject);
                }
                else if (fObject.fObjectType == FObjectType.TcpLibraryGroup)
                {
                    pgdProp.selectedObject = new FPropTlg(m_fTcmCore, pgdProp, (FTcpLibraryGroup)fObject);
                }
                else if (fObject.fObjectType == FObjectType.TcpLibrary)
                {
                    pgdProp.selectedObject = new FPropTlb(m_fTcmCore, pgdProp, (FTcpLibrary)fObject);
                }
                else if (fObject.fObjectType == FObjectType.TcpMessageList)
                {
                    pgdProp.selectedObject = new FPropTml(m_fTcmCore, pgdProp, (FTcpMessageList)fObject);
                }
                else if (fObject.fObjectType == FObjectType.TcpMessages)
                {
                    pgdProp.selectedObject = new FPropTms(m_fTcmCore, pgdProp, (FTcpMessages)fObject);
                }
                else if (fObject.fObjectType == FObjectType.TcpMessage)
                {
                    pgdProp.selectedObject = new FPropTmg(m_fTcmCore, pgdProp, (FTcpMessage)fObject);                    
                }
                else if (fObject.fObjectType == FObjectType.TcpItem)
                {
                    if (((FTcpItem)fObject).removed)
                    {
                        return;
                    }
                    pgdProp.selectedObject = new FPropTit(m_fTcmCore, pgdProp, (FTcpItem)fObject);
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
            FIObject fObject = null;

            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuTlmRemove].SharedProps.Enabled == true)
                    {
                        procMenuRemoveObject();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.X)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuTlmCut].SharedProps.Enabled == true)
                    {
                        procMenuCut();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.C)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuTlmCopy].SharedProps.Enabled == true)
                    {
                        procMenuCopy();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.V)
                {
                    fObject = (FIObject)this.tvwTree.ActiveNode.Tag;

                    if (fObject.fObjectType == FObjectType.TcpMessages)
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuTlmPastePrimaryTcpMessage].SharedProps.Enabled == true)
                        {
                            procMenuPastePrimaryTcpMessage();                           
                        }
                        else if (mnuMenu.Tools[FMenuKey.MenuTlmPasteSibling].SharedProps.Enabled == true)
                        {
                            procMenuPasteSibling();                            
                        }
                    }
                    else
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuTlmPasteSibling].SharedProps.Enabled == true)
                        {
                            procMenuPasteSibling();
                        }
                    }
                }
                else if (e.Control && e.KeyCode == Keys.B)
                {
                    fObject = (FIObject)this.tvwTree.ActiveNode.Tag;

                    if (fObject.fObjectType == FObjectType.TcpMessages)
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuTlmPasteSecondaryTcpMessage].SharedProps.Enabled == true)
                        {
                            procMenuPasteSecondaryTcpMessage();
                        }
                        else if(mnuMenu.Tools[FMenuKey.MenuTlmPasteChild].SharedProps.Enabled == true)
                        {
                            procMenuPasteChild();
                        }
                    }
                    else
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuTlmPasteChild].SharedProps.Enabled == true)
                        {
                            procMenuPasteChild();
                        }
                    }
                }
                else if (e.Control && e.KeyCode == Keys.U)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuTlmMoveUp].SharedProps.Enabled == true)
                    {
                        procMenuMoveUpObject(FMenuKey.MenuTlmMoveUp);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.D)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuTlmMoveDown].SharedProps.Enabled == true)
                    {
                        procMenuMoveDownObject(FMenuKey.MenuTlmMoveDown);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.E)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuTlmExpand].SharedProps.Enabled == true)
                    {
                        procMenuExpand();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.L)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuTlmCollapse].SharedProps.Enabled == true)
                    {
                        procMenuCollapse();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.R)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuTlmRelation].SharedProps.Enabled == true)
                    {
                        procMenuRelation();
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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

                    if (fRefObject.fObjectType == FObjectType.TcpDriver)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.TcpLibraryGroup)
                        {
                            #region TcpLibraryGroup

                            if (((FTcpDriver)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                cnt = ((FTcpDriver)fRefObject).fChildTcpLibraryGroupCollection.count;
                                fRefObject = ((FTcpDriver)fRefObject).fChildTcpLibraryGroupCollection[cnt - 1];
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
                    else if (fRefObject.fObjectType == FObjectType.TcpLibraryGroup)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.TcpLibraryGroup)
                        {
                            #region TcpLibraryGroup

                            if (((FTcpLibraryGroup)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FTcpLibraryGroup)fRefObject).fNextSibling == null || !((FTcpLibraryGroup)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.TcpLibrary)
                        {
                            #region TcpLibrary

                            if (((FTcpLibraryGroup)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                cnt = ((FTcpLibraryGroup)fRefObject).fChildTcpLibraryCollection.count;
                                if (cnt == 0)
                                {
                                    e.Effect = DragDropEffects.Move;
                                    return;
                                }
                                else
                                {
                                    fRefObject = ((FTcpLibraryGroup)fRefObject).fChildTcpLibraryCollection[cnt - 1];
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
                    else if (fRefObject.fObjectType == FObjectType.TcpLibrary)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.TcpLibrary)
                        {
                            #region TcpLibrary

                            if (((FTcpLibrary)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FTcpLibrary)fRefObject).fNextSibling == null || !((FTcpLibrary)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.TcpMessageList)
                        {
                            #region TcpMessageList

                            if (((FTcpLibrary)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                // ***
                                // TCP Message List는 다른 TCP Library로 Move 할 수 없다.
                                // ***
                                if (
                                    fDragDropData.sessionUniqueId == string.Empty &&
                                    ((FTcpLibrary)fRefObject).Equals(((FTcpMessageList)fDragDropData.fObject).fParent)
                                    )
                                {
                                    cnt = ((FTcpLibrary)fRefObject).fChildTcpMessageListCollection.count;
                                    fRefObject = ((FTcpLibrary)fRefObject).fChildTcpMessageListCollection[cnt - 1];
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
                    else if (fRefObject.fObjectType == FObjectType.TcpMessageList)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.TcpMessageList)
                        {
                            #region TcpMessageList

                            if (!fRefObject.Equals(fDragDropData.fObject))
                            {
                                if (((FTcpMessageList)fRefObject).equalsModelingFile(fDragDropData.fObject))
                                {
                                    // ***
                                    // TCP Message List는 다른 TCP Library로 Move 할 수 없다.
                                    // ***
                                    if (
                                        fDragDropData.sessionUniqueId == string.Empty &&
                                        ((FTcpMessageList)fRefObject).fParent.Equals(((FTcpMessageList)fDragDropData.fObject).fParent)
                                        )
                                    {
                                        if (
                                            ((FTcpMessageList)fRefObject).fNextSibling == null ||
                                            !((FTcpMessageList)fRefObject).fNextSibling.Equals(fDragDropData.fObject)
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.TcpMessages)
                        {
                            #region TcpMessages

                            if (((FTcpMessageList)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                // ***
                                // TCP Messages는 다른 TCP Library로 Move 할 수 없다.
                                // ***
                                if (
                                    fDragDropData.sessionUniqueId == string.Empty &&
                                    ((FTcpMessageList)fRefObject).fAncestorTcpLibrary.Equals(((FTcpMessages)fDragDropData.fObject).fAncestorTcpLibrary)
                                    )
                                {
                                    cnt = ((FTcpMessageList)fRefObject).fChildTcpMessagesCollection.count;
                                    if (cnt == 0)
                                    {
                                        e.Effect = DragDropEffects.Move;
                                        return;
                                    }
                                    else
                                    {
                                        fRefObject = ((FTcpMessageList)fRefObject).fChildTcpMessagesCollection[cnt - 1];
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
                    else if (fRefObject.fObjectType == FObjectType.TcpMessages)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.TcpMessages)
                        {
                            #region TcpMessages

                            if (((FTcpMessages)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                // ***
                                // TCP Messages는 다른 TCP Library로 Move 할 수 없다.
                                // ***
                                if (
                                    fDragDropData.sessionUniqueId == string.Empty &&
                                    ((FTcpMessages)fRefObject).fAncestorTcpLibrary.Equals(((FTcpMessages)fDragDropData.fObject).fAncestorTcpLibrary)
                                    )
                                {
                                    if (
                                        !fRefObject.Equals(fDragDropData.fObject) &&
                                        (((FTcpMessages)fRefObject).fNextSibling == null || !((FTcpMessages)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.TcpMessage)
                        {
                            #region TcpMessage

                            if (!((FTcpMessages)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FTcpMessage)fDragDropData.fObject).isPrimary)
                                {
                                    if (((FTcpMessages)fRefObject).canAppendChildPrimaryTcpMessage)
                                    {
                                        e.Effect = DragDropEffects.Copy;
                                        return;
                                    }
                                }
                                else
                                {
                                    if (((FTcpMessages)fRefObject).canAppendChildSecondaryTcpMessage)
                                    {
                                        e.Effect = DragDropEffects.Copy;
                                        return;
                                    }
                                }
                            }

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.TcpMessage)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.TcpItem)
                        {
                            #region TcpItem

                            if (((FTcpMessage)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FTcpMessage)fRefObject).Equals(((FTcpItem)fDragDropData.fObject).fAncestorTcpMessage) &&
                                    !((FTcpMessage)fRefObject).fChildTcpItemCollection[((FTcpMessage)fRefObject).fChildTcpItemCollection.count - 1].Equals(fDragDropData.fObject) &&
                                    fDragDropData.sessionUniqueId == string.Empty
                                    )
                                {
                                    if (((FTcpMessage)fRefObject).hasVariableChild)
                                    {
                                        if (((FTcpItem)fDragDropData.fObject).fPattern == FPattern.Variable)
                                        {
                                            if (
                                                ((FTcpMessage)fRefObject).Equals(((FTcpItem)fDragDropData.fObject).fParent) &&
                                                (((FTcpItem)fDragDropData.fObject).fPreviousSibling == null || ((FTcpItem)fDragDropData.fObject).fPreviousSibling.fPattern == FPattern.Fixed) &&
                                                (((FTcpItem)fDragDropData.fObject).fNextSibling == null || ((FTcpItem)fDragDropData.fObject).fNextSibling.fPattern == FPattern.Fixed)
                                                )
                                            {
                                                e.Effect = DragDropEffects.Move;
                                                return;
                                            }
                                            else if (((FTcpMessage)fRefObject).fChildTcpItemCollection[((FTcpMessage)fRefObject).fChildTcpItemCollection.count - 1].fPattern == FPattern.Variable)
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

                            if (((FTcpMessage)fRefObject).equalsModelingFile(fDragDropData.fObject))
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
                    else if (fRefObject.fObjectType == FObjectType.TcpItem)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.TcpItem)
                        {
                            #region TcpItem

                            if (((FTcpItem)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    fDragDropData.sessionUniqueId == string.Empty &&
                                    !((FTcpItem)fDragDropData.fObject).containsObject(fRefObject) &&
                                    ((FTcpItem)fRefObject).fAncestorTcpMessage.Equals(((FTcpItem)fDragDropData.fObject).fAncestorTcpMessage) &&
                                    (((FTcpItem)fRefObject).fNextSibling == null || !(((FTcpItem)fRefObject).fNextSibling.Equals((FTcpItem)fDragDropData.fObject)))
                                    )
                                {
                                    if (
                                        (((FTcpItem)fRefObject).fParent.fObjectType == FObjectType.TcpMessage && ((FTcpMessage)((FTcpItem)fRefObject).fParent).hasVariableChild) ||
                                        (((FTcpItem)fRefObject).fParent.fObjectType == FObjectType.TcpItem && ((FTcpItem)((FTcpItem)fRefObject).fParent).hasVariableChild)
                                        )
                                    {
                                        if (((FTcpItem)fDragDropData.fObject).fPattern == FPattern.Variable)
                                        {
                                            if (
                                                ((FTcpItem)fDragDropData.fObject).fParent.Equals(((FTcpItem)fRefObject).fParent) &&
                                                (((FTcpItem)fDragDropData.fObject).fPreviousSibling == null || ((FTcpItem)fDragDropData.fObject).fPreviousSibling.fPattern == FPattern.Fixed) &&
                                                (((FTcpItem)fDragDropData.fObject).fNextSibling == null || ((FTcpItem)fDragDropData.fObject).fNextSibling.fPattern == FPattern.Fixed)
                                                )
                                            {
                                                e.Effect = DragDropEffects.Move;
                                                return;
                                            }
                                            else if (
                                                ((FTcpItem)fRefObject).fPattern == FPattern.Variable ||
                                                (((FTcpItem)fRefObject).fNextSibling != null && ((FTcpItem)fRefObject).fNextSibling.fPattern == FPattern.Variable)
                                                )
                                            {
                                                e.Effect = DragDropEffects.Move;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            if (
                                                ((FTcpItem)fRefObject).fPattern == FPattern.Fixed ||
                                                ((FTcpItem)fRefObject).fNextSibling == null ||
                                                ((FTcpItem)fRefObject).fNextSibling.fPattern == FPattern.Fixed
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

                            if (((FTcpItem)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                fFormat = ((FTcpItem)fRefObject).fFormat;
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

                            if (((FTcpItem)fRefObject).equalsModelingFile(fDragDropData.fObject))
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

                    if (fRefObject.fObjectType == FObjectType.TcpMessageList)
                    {
                        if (
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog ||
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog
                            )
                        {
                            #region TcpMessageLog

                            e.Effect = DragDropEffects.Copy;
                            return;

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.TcpMessages)
                    {
                        if (
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog ||
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog
                            )
                        {
                            #region TcpMessageLog

                            e.Effect = DragDropEffects.Copy;
                            return;

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.TcpMessage)
                    {
                        if (fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.TcpItemLog)
                        {
                            #region TcpItemLog

                            e.Effect = DragDropEffects.Copy;
                            return;

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.TcpItem)
                    {
                        if (fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.TcpItemLog)
                        {
                            #region TcpItemLog

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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
            FTcpMessages fTms = null;
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

                    if (fRefObject.fObjectType == FObjectType.TcpDriver)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.TcpLibraryGroup)
                        {
                            #region TcpLibraryGroup

                            if (e.Effect == DragDropEffects.Move)
                            {
                                cnt = ((FTcpDriver)fRefObject).fChildTcpLibraryGroupCollection.count;
                                fRefObject = ((FTcpDriver)fRefObject).fChildTcpLibraryGroupCollection[cnt - 1];
                                ((FTcpLibraryGroup)fDragDropData.fObject).moveTo((FTcpLibraryGroup)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FTcpLibraryGroup)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FTcpDriver)fRefObject).pasteChildTcpLibraryGroup();
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
                    else if (fRefObject.fObjectType == FObjectType.TcpLibraryGroup)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.TcpLibraryGroup)
                        {
                            #region TcpLibraryGroup

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FTcpLibraryGroup)fDragDropData.fObject).moveTo((FTcpLibraryGroup)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FTcpLibraryGroup)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FTcpLibraryGroup)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.TcpLibrary)
                        {
                            #region TcpLibrary

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FTcpLibrary)fDragDropData.fObject).moveTo((FTcpLibraryGroup)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FTcpLibrary)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FTcpLibraryGroup)fRefObject).pasteChild();
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
                    else if (fRefObject.fObjectType == FObjectType.TcpLibrary)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.TcpLibrary)
                        {
                            #region TcpLibrary

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FTcpLibrary)fDragDropData.fObject).moveTo((FTcpLibrary)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FTcpLibrary)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FTcpLibrary)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.TcpMessageList)
                        {
                            #region TcpMessageList

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FTcpMessageList)fDragDropData.fObject).moveTo((FTcpLibrary)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FTcpMessageList)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FTcpLibrary)fRefObject).pasteChild();
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
                    else if (fRefObject.fObjectType == FObjectType.TcpMessageList)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.TcpMessageList)
                        {
                            #region TcpMessageList

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FTcpMessageList)fDragDropData.fObject).moveTo((FTcpMessageList)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FTcpMessageList)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FTcpMessageList)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.TcpMessages)
                        {
                            #region TcpMessages

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FTcpMessages)fDragDropData.fObject).moveTo((FTcpMessageList)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FTcpMessages)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FTcpMessageList)fRefObject).pasteChild();
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
                    else if (fRefObject.fObjectType == FObjectType.TcpMessages)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.TcpMessages)
                        {
                            #region TcpMessages

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FTcpMessages)fDragDropData.fObject).moveTo((FTcpMessages)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FTcpMessages)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FTcpMessages)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.TcpMessage)
                        {
                            #region TcpMessage

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FTcpMessage)fDragDropData.fObject).copy();
                                // --
                                if (((FTcpMessage)fDragDropData.fObject).isPrimary)
                                {
                                    fDragDropData.fObject = ((FTcpMessages)fRefObject).pastePrimaryTcpMessage();
                                    fAction = FDragDropAction.Copy;
                                }
                                else
                                {
                                    fDragDropData.fObject = ((FTcpMessages)fRefObject).pasteSecondaryTcpMessage();
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
                    else if (fRefObject.fObjectType == FObjectType.TcpMessage)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.TcpItem)
                        {
                            #region TcpItem

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FTcpItem)fDragDropData.fObject).moveTo((FTcpMessage)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FTcpItem)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FTcpMessage)fRefObject).pasteChild();
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
                                fDataSetGenertor = new FDataSetGenerator(m_fTcmCore, (FDataSet)fDragDropData.fObject, fRefObject);
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
                    else if (fRefObject.fObjectType == FObjectType.TcpItem)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.TcpItem)
                        {
                            #region TcpItem

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FTcpItem)fDragDropData.fObject).moveTo((FTcpItem)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FTcpItem)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FTcpItem)fRefObject).pasteSibling();
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
                                ((FTcpItem)fRefObject).setDataConversionSet((FDataConversionSet)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
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

                    if (fRefObject.fObjectType == FObjectType.TcpMessageList)
                    {
                        if (
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog ||
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog
                            )
                        {
                            #region TcpMessageLog

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fTms = new FTcpMessages(m_fTcmCore.fTcmFileInfo.fTcpDriver);

                                if (fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog)
                                {
                                    ((FTcpDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).copy();
                                    // --
                                    fTms.command = ((FTcpDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).command;
                                    fTms.version = ((FTcpDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).version;
                                    fTms.name = ((FTcpDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).name;
                                    fTms.description = ((FTcpDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).description;
                                    // --
                                    if (((FTcpDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).isPrimary)
                                    {
                                        fDragDropData.fObject = fTms.pastePrimaryTcpMessage();
                                    }
                                    else
                                    {
                                        fDragDropData.fObject = fTms.pasteSecondaryTcpMessage();
                                    }
                                }
                                else
                                {
                                    ((FTcpDeviceDataMessageSentLog)fDragDropData.fObjectLog).copy();
                                    // --
                                    fTms.command = ((FTcpDeviceDataMessageSentLog)fDragDropData.fObjectLog).command;
                                    fTms.version = ((FTcpDeviceDataMessageSentLog)fDragDropData.fObjectLog).version;
                                    fTms.name = ((FTcpDeviceDataMessageSentLog)fDragDropData.fObjectLog).name;
                                    fTms.description = ((FTcpDeviceDataMessageSentLog)fDragDropData.fObjectLog).description;
                                    // --
                                    if (((FTcpDeviceDataMessageSentLog)fDragDropData.fObjectLog).isPrimary)
                                    {
                                        fDragDropData.fObject = fTms.pastePrimaryTcpMessage();
                                    }
                                    else
                                    {
                                        fDragDropData.fObject = fTms.pasteSecondaryTcpMessage();
                                    }
                                }

                                // --

                                tvwTree.beginUpdate();

                                // --

                                fTms = ((FTcpMessageList)fRefObject).appendChildTcpMessages(fTms);
                                tNode = new UltraTreeNode(fTms.uniqueIdToString);
                                tNode.Tag = fTms;
                                FCommon.refreshTreeNodeOfObject(fTms, tvwTree, tNode);
                                tRefNode.Nodes.Add(tNode);

                                // --

                                fRefObject = fTms;
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
                    else if (fRefObject.fObjectType == FObjectType.TcpMessages)
                    {
                        if (
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog ||
                            fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageSentLog
                            )
                        {
                            #region TcpMessageLog

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                fTms = new FTcpMessages(m_fTcmCore.fTcmFileInfo.fTcpDriver);

                                if (fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.TcpDeviceDataMessageReceivedLog)
                                {
                                    ((FTcpDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).copy();
                                    // --
                                    fTms.command = ((FTcpDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).command;
                                    fTms.version = ((FTcpDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).version;
                                    fTms.name = ((FTcpDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).name;
                                    fTms.description = ((FTcpDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).description;
                                    // --
                                    if (((FTcpDeviceDataMessageReceivedLog)fDragDropData.fObjectLog).isPrimary)
                                    {
                                        fDragDropData.fObject = fTms.pastePrimaryTcpMessage();
                                    }
                                    else
                                    {
                                        fDragDropData.fObject = fTms.pasteSecondaryTcpMessage();
                                    }
                                }
                                else
                                {
                                    ((FTcpDeviceDataMessageSentLog)fDragDropData.fObjectLog).copy();
                                    // --
                                    fTms.command = ((FTcpDeviceDataMessageSentLog)fDragDropData.fObjectLog).command;
                                    fTms.version = ((FTcpDeviceDataMessageSentLog)fDragDropData.fObjectLog).version;
                                    fTms.name = ((FTcpDeviceDataMessageSentLog)fDragDropData.fObjectLog).name;
                                    fTms.description = ((FTcpDeviceDataMessageSentLog)fDragDropData.fObjectLog).description;
                                    // --
                                    if (((FTcpDeviceDataMessageSentLog)fDragDropData.fObjectLog).isPrimary)
                                    {
                                        fDragDropData.fObject = fTms.pastePrimaryTcpMessage();
                                    }
                                    else
                                    {
                                        fDragDropData.fObject = fTms.pasteSecondaryTcpMessage();
                                    }
                                }

                                // --

                                tvwTree.beginUpdate();

                                // --

                                fTms = ((FTcpMessages)fRefObject).fParent.insertAfterChildTcpMessages(fTms, (FTcpMessages)fRefObject);
                                tNode = new UltraTreeNode(fTms.uniqueIdToString);
                                tNode.Tag = fTms;
                                FCommon.refreshTreeNodeOfObject(fTms, tvwTree, tNode);
                                tRefNode.Parent.Nodes.Insert(tRefNode.Index + 1, tNode);

                                // --

                                fRefObject = fTms;
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
                    else if (fRefObject.fObjectType == FObjectType.TcpMessage)
                    {
                        if (fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.TcpItemLog)
                        {
                            #region TcpItemLog

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FTcpItemLog)fDragDropData.fObjectLog).copy();
                                fDragDropData.fObject = ((FTcpMessage)fRefObject).pasteChild();
                            }

                            #endregion
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.TcpItem)
                    {
                        if (fDragDropData.fObjectLog.fObjectLogType == FObjectLogType.TcpItemLog)
                        {
                            #region TcpItemLog

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FTcpItemLog)fDragDropData.fObjectLog).copy();
                                fDragDropData.fObject = ((FTcpItem)fRefObject).pasteSibling();
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
                        fRefObject.fObjectType == FObjectType.TcpMessage ||
                        fRefObject.fObjectType == FObjectType.TcpItem
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fDragDropData = null;
                tRefNode = null;
                tNode = null;
                fRefObject = null;
                fTms = null;
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

                if (e.Tool.Key == FMenuKey.MenuTlmExpand)
                {
                    procMenuExpand();
                }
                else if (e.Tool.Key == FMenuKey.MenuTlmCollapse)
                {
                    procMenuCollapse();
                }
                else if (e.Tool.Key == FMenuKey.MenuTlmReplace)
                {
                    procMenuReplace(); 
                }
                else if (e.Tool.Key == FMenuKey.MenuTlmCut)
                {
                    procMenuCut();
                }
                else if (e.Tool.Key == FMenuKey.MenuTlmCopy)
                {
                    procMenuCopy();
                }
                else if (e.Tool.Key == FMenuKey.MenuTlmPasteSibling)
                {
                    procMenuPasteSibling();
                }
                else if (e.Tool.Key == FMenuKey.MenuTlmPasteChild)
                {
                    procMenuPasteChild();
                }
                else if (e.Tool.Key == FMenuKey.MenuTlmPastePrimaryTcpMessage)
                {
                    procMenuPastePrimaryTcpMessage();
                }
                else if (e.Tool.Key == FMenuKey.MenuTlmPasteSecondaryTcpMessage)
                {
                    procMenuPasteSecondaryTcpMessage();
                }
                else if (e.Tool.Key == FMenuKey.MenuTlmRemove)
                {
                    procMenuRemoveObject();
                }
                else if (e.Tool.Key == FMenuKey.MenuTlmMoveUp)
                {
                    procMenuMoveUpObject(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuTlmMoveDown)
                {
                    procMenuMoveDownObject(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuTlmRelation)
                {
                    procMenuRelation();
                }
                else if (e.Tool.Key == FMenuKey.MenuTlmConvertToXlg)
                {
                    procMenuXlgViewer();
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuTlmInsertBeforeTcpLibraryGroup ||
                    e.Tool.Key == FMenuKey.MenuTlmInsertBeforeTcpLibrary ||
                    e.Tool.Key == FMenuKey.MenuTlmInsertBeforeTcpMessageList ||
                    e.Tool.Key == FMenuKey.MenuTlmInsertBeforeTcpMessages ||
                    e.Tool.Key == FMenuKey.MenuTlmInsertBeforeTcpItem
                    )
                {
                    procMenuInsertBeforeObject(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuTlmInsertAfterTcpLibraryGroup ||
                    e.Tool.Key == FMenuKey.MenuTlmInsertAfterTcpLibrary ||
                    e.Tool.Key == FMenuKey.MenuTlmInsertAfterTcpMessageList ||
                    e.Tool.Key == FMenuKey.MenuTlmInsertAfterTcpMessages ||
                    e.Tool.Key == FMenuKey.MenuTlmInsertAfterTcpItem
                    )
                {
                    procMenuInsertAfterObject(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuTlmAppendTcpLibraryGroup ||
                    e.Tool.Key == FMenuKey.MenuTlmAppendTcpLibrary ||
                    e.Tool.Key == FMenuKey.MenuTlmAppendTcpMessageList ||
                    e.Tool.Key == FMenuKey.MenuTlmAppendTcpMessages ||
                    e.Tool.Key == FMenuKey.MenuTlmAppendPrimaryTcpMessage ||
                    e.Tool.Key == FMenuKey.MenuTlmAppendSecondaryTcpMessage ||
                    e.Tool.Key == FMenuKey.MenuTlmAppendTcpItem
                    )
                {
                    procMenuAppendObject(e.Tool.Key);
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
